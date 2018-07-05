Imports System.Data
Partial Class Associations_Association_Event_View
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetAssociationDetails()
        PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
    End Sub
    Private Sub GetAssociationDetails()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("Association_Id", Request.QueryString("id"))

        Dim str As String = ""

        str &= " SELECT        Association_Id, Name, ContactPerson, ContactTel, ContactEmail, Active, ProfilePicPath, ShortDescription, LongDescription"
        str &= " FROM            tbl_Associations"
        str &= " WHERE        (Association_Id = @Association_Id)"
        str &= " ORDER BY Name"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
        Try
            lblAssociationName.Text = ds.Tables(0).Rows(0).Item("Name").ToString
        Catch ex As Exception

        End Try

    End Sub
    Private Function GetEvents() As String
        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"

        htmlString &= "                         <div>&nbsp;</div>"
        Dim dsTerms As New DataSet
        dsTerms = GetEventData()
        Dim count As Integer = dsTerms.Tables(0).Rows.Count - 1
        Dim sp As Integer

        Dim itemName As String = ""
        Dim month As String = "13"
        For sp = 0 To count
            If month <> CDate(dsTerms.Tables(0).Rows(sp).Item("EventDate").ToString.Trim).Month Then
                htmlString &= " <div style='background-color: #E2E2E2; font-size: large; font-weight: bold; padding-left: 10px; padding-top: 10px; padding-bottom: 10px;'>"
                htmlString &= GetMonthName(CDate(dsTerms.Tables(0).Rows(sp).Item("EventDate").ToString.Trim).Month) & " " & CDate(dsTerms.Tables(0).Rows(sp).Item("EventDate").ToString.Trim).Year
                htmlString &= "        </div>"
                month = CDate(dsTerms.Tables(0).Rows(sp).Item("EventDate").ToString.Trim).Month
            End If


            htmlString &= " <div>&nbsp;</div>"

            htmlString &= "     <div style='background-color: #F8F8F8; border: 1px solid #333333; width:800px; '>"
            htmlString &= "         <div style='padding: 10px; display: inline-block; vertical-align:top'>"
            htmlString &= " <div>  "
            htmlString &= " <div style='color: #37C4D6; font-weight: bold; font-size: x-large; text-align:center'>  "
            htmlString &= CDate(dsTerms.Tables(0).Rows(sp).Item("EventDate").ToString.Trim).Day
            htmlString &= " </div>  "
            htmlString &= " <div style='text-align:center'>  "
            htmlString &= GetMonthName(CDate(dsTerms.Tables(0).Rows(sp).Item("EventDate").ToString.Trim).Month)
            htmlString &= " </div>  "

            htmlString &= " </div>  "

            htmlString &= "         </div>"
            htmlString &= "         <div style='padding: 10px; display: inline-block; vertical-align: top; color: #333333;'>"
            htmlString &= "             <div style='font-size: large; font-weight: bold;'>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("Event_Name").ToString.Trim
            htmlString &= "   </div>"
            htmlString &= " <div>&nbsp;</div>"
            htmlString &= "             <div style='width:500px;'>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("ShortDescription").ToString.Trim
            htmlString &= "            </div>"
            htmlString &= "         </div>"

            htmlString &= "         <div style='padding: 10px; display: inline-block'>"
            htmlString &= " <div>  "
            htmlString &= " Time: " & CDate(dsTerms.Tables(0).Rows(sp).Item("EventTime").ToString.Trim).ToString("HH:mm")
            htmlString &= "     </div>"
            htmlString &= " <div>  "
            htmlString &= " Venue: " & dsTerms.Tables(0).Rows(sp).Item("Venue").ToString.Trim
            htmlString &= " <div>  "
            htmlString &= " " & dsTerms.Tables(0).Rows(sp).Item("Venue_Adres1").ToString.Trim
            htmlString &= "     </div>"
            htmlString &= " <div>  "
            htmlString &= "  " & dsTerms.Tables(0).Rows(sp).Item("Venue_Adres2").ToString.Trim
            htmlString &= "     </div>"
            htmlString &= " <div>  "
            htmlString &= "  " & dsTerms.Tables(0).Rows(sp).Item("Venue_Adres3").ToString.Trim
            htmlString &= "     </div>"
            htmlString &= "     </div>"
            htmlString &= "               <div>&nbsp;</div>"
            If dsTerms.Tables(0).Rows(sp).Item("AcceptBooking").ToString.Trim = "True" Then
                Dim isGoing As String = CheckAttending(dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim)
                If isGoing = "No" Then
                    htmlString &= "          <div id='divBtn' runat='server' style='padding: 5px; border: thin solid #333333;'>"
                    htmlString &= "             <input id='btnGoing' type='button' value='Going' style='border-style: none; background-color: #86B24F; height:32px;width:65px; Cursor:pointer' onclick=""Book('" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "','Attending') ""  />"
                    htmlString &= "             &nbsp;"
                    htmlString &= "             <input id='btnMaybe' type='button' value='Maybe' style='border-style: none; background-color: #E65B00; height:32px;width:65px; Cursor:pointer'  onclick=""Book('" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "','Maybe') ""  />"
                    htmlString &= "            </div>"
                ElseIf isGoing = "Maybe" Then
                    htmlString &= "          <div id='divBtn' runat='server' style='padding: 5px; border: thin solid #333333;'>"
                    htmlString &= "  You might go."
                    htmlString &= "               <div>&nbsp;</div>"
                    htmlString &= "            <div>"
                    htmlString &= "             <input id='btnGoingA' type='button' value='Going' style='border-style: none; background-color: #86B24F; height:32px;width:65px; Cursor:pointer'  onclick=""Book('" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "','Attending') ""  />"
                    htmlString &= "             &nbsp;"
                    htmlString &= "             <input id='btnCancelA' type='button' value='Cancel' style='border-style: none; background-color: #E65B00; height:32px;width:65px; Cursor:pointer' onclick=""RemoveBook('" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "','Remove')"" />"
                    htmlString &= "            </div>"
                    htmlString &= "            </div>"
                ElseIf isGoing = "Attending" Then
                    htmlString &= "          <div id='divBtn' runat='server' style='padding: 5px; border: thin solid #333333;'>"
                    htmlString &= "  You are going."
                    htmlString &= "               <div>&nbsp;</div>"
                    htmlString &= "            <div>"
                    htmlString &= "             <input id='btnCancel' type='button' value='Cancel' style='border-style: none; background-color: #E65B00; height:32px;width:65px; Cursor:pointer' onclick=""RemoveBook('" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "','Remove')"" />"
                    htmlString &= "            </div>"
                    htmlString &= "            </div>"
                End If

            End If

            htmlString &= "     </div>"
            htmlString &= "     </div>"

            htmlString &= " <div>&nbsp;</div>"
        Next
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"

        Return htmlString

    End Function
    Private Function GetEventData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Association_Id", Request.QueryString("id"))
        cmd.Parameters.AddWithValue("@todayDate", Now.Date)

        Dim str As String = ""

        str &= " SELECT        event_id, Association_Id, Event_Name, ShortDescription, LongDescription, EventType, EventDate, EventTime, AcceptBooking, Period, Year, Venue, Venue_Adres1, Venue_Adres2, Venue_Adres3"
        str &= " FROM            tbl_Association_Events"
        str &= " WHERE        (Association_Id = @Association_Id) AND (EventDate >= @todayDate)"
        str &= " ORDER BY EventDate"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        Return ds

    End Function
    Private Function GetMonthName(period As String) As String
        Dim MonthName As String = ""
        Select Case period
            Case = 1
                MonthName = "January"
            Case = 2
                MonthName = "February"
            Case = 3
                MonthName = "March"
            Case = 4
                MonthName = "April"
            Case = 5
                MonthName = "May"
            Case = 6
                MonthName = "June"
            Case = 7
                MonthName = "July"
            Case = 8
                MonthName = "August"
            Case = 9
                MonthName = "September"
            Case = "01"
                MonthName = "January"
            Case = "02"
                MonthName = "February"
            Case = "03"
                MonthName = "March"
            Case = "04"
                MonthName = "April"
            Case = "05"
                MonthName = "May"
            Case = "06"
                MonthName = "June"
            Case = "07"
                MonthName = "July"
            Case = "08"
                MonthName = "August"
            Case = "09"
                MonthName = "September"
            Case = 10
                MonthName = "October"
            Case = 11
                MonthName = "November"
            Case = 12
                MonthName = "December"
        End Select

        Return MonthName

    End Function
    Private Function CheckAttending(EventId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@EventId", EventId.Trim)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)

        Dim str As String = ""

        str &= "  SELECT id, Event_Id, MemberId, Attend"
        str &= " FROM tbl_Association_Event_Attending"
        str &= "  WHERE (Event_Id = @EventId) AND (MemberId = @MemberId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        Dim Attending As String = ""
        Try
            Attending = ds.Tables(0).Rows(0).Item("Attend").ToString.Trim
        Catch ex As Exception
            Attending = "No"
        End Try

        Return Attending


    End Function
    Protected Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@EventId", HiddenFieldEventId.Value.Trim)
        cmd.Parameters.AddWithValue("@Attending", HiddenFieldBookStatus.Value)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)

        Dim str As String = ""

        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Association_Event_Attending  "
        str &= " WHERE (Event_Id = @EventId) AND (MemberId = @MemberId) ) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Association_Event_Attending"
        str &= " SET Attend = @Attending "
        str &= " WHERE (Event_Id = @EventId) AND (MemberId = @MemberId) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= "  INSERT INTO tbl_Association_Event_Attending"
        str &= " (Event_Id, MemberId, Attend)"
        str &= " VALUES "
        str &= " (@EventId, @MemberId, @Attending)"
        str &= " END  "
        str &= " COMMIT TRAN"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")
            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
            HiddenFieldEventId.Value = ""
            HiddenFieldBookStatus.Value = ""
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try


    End Sub
    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@EventId", HiddenFieldEventId.Value.Trim)
        cmd.Parameters.AddWithValue("@Attending", HiddenFieldBookStatus.Value)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)

        Dim str As String = ""


        str = " DELETE FROM tbl_Association_Event_Attending  "
        str &= " WHERE (Event_Id = @EventId) AND (MemberId = @MemberId)  "



        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")
            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
            HiddenFieldEventId.Value = ""
            HiddenFieldBookStatus.Value = ""
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
