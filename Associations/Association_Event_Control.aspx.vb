Imports System.Data
Imports ZXing
Imports ZXing.QrCode
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.IO
Partial Class Associations_Association_Event_Control
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            PopulateAssociations()
        End If
    End Sub
    Private Sub PopulateAssociations()
        Dim ds As New DataSet()
        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)

        Dim str As String = ""
        str &= "  SELECT        tbl_Associations.Association_Id, tbl_Associations.Name"
        str &= "  FROM            tbl_Associations INNER JOIN"
        str &= "                           tbl_Association_v_User ON tbl_Associations.Association_Id = tbl_Association_v_User.Association_Id"
        str &= "  WHERE        (tbl_Association_v_User.UserId = @UserId)"
        str &= "  ORDER BY tbl_Associations.Name"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            DropDownList1.DataSource = ds.Tables(0)
            DropDownList1.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub GetAssociationDetails()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("Association_Id", DropDownList1.SelectedValue.Trim)

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

        Dim SavePath As String = ""
        Dim pathname As String = "QrCodes\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot






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

            Dim thisAttending() As String = GetAttendance(dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim)

            htmlString &= "  <div>&nbsp;</div>"
            htmlString &= "                       <div>&nbsp;</div>"
            htmlString &= "                      <div>Attending: " & thisAttending(0) & "</div>"
            htmlString &= "                      <div>Maybe: " & thisAttending(1) & "</div>"

            htmlString &= " <div>&nbsp;</div>"

            If thisAttending(0) <> "0" Or thisAttending(1) <> "0" Then
                htmlString &= " <div class='auto-style6' style='background-color: #666666; color: #A2A3A3; display: inline-block; padding-right:  5px;  padding-left:  5px; cursor: pointer' onclick=""window.open('Association_Event_Control_Attendance.aspx?id=" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "', '_blank')"">"
                htmlString &= "                         View"
                htmlString &= " </div>"
            End If
            htmlString &= "         </div>"

            If System.IO.File.Exists(SavePath & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "QRcode.jpg") Then
                htmlString &= "         <div style='padding: 10px; display: inline-block'>"
                htmlString &= "        <img alt='' src='QrCodes/" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "QrCode.jpg'/> "
                htmlString &= "         </div>"
            End If

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
            htmlString &= "         <div>&nbsp;</div>"
            htmlString &= "                 <div id='divBtn' runat='server' style='padding: 5px; border: thin solid #333333; display:inline-block' class='auto-style7'>"
            htmlString &= "                     &nbsp;<div class='auto-style6' style='background-color: #666666; color: #A2A3A3; display:inline-block' Cursor:pointer' onclick=""EditEvent('" & dsTerms.Tables(0).Rows(sp).Item("event_id").ToString.Trim & "','Edit') "">"
            htmlString &= "                         <img alt='' src='../Images/Icons/edit.png' /> &nbsp; Edit</div>"
            htmlString &= "                     &nbsp;&nbsp;"
            If thisAttending(0) = "0" Then
                htmlString &= "                     <div class='auto-style8' style='background-color: #666666; color: #A2A3A3; display:inline-block'>"
                htmlString &= "                         <img alt='' src='../Images/Icons/trash.png' /> &nbsp; Remove</div>"

            Else
                htmlString &= "               <div  class='auto-style8' style='display:inline-block'>&nbsp;</div>"
            End If

            htmlString &= "                     </div>"
            htmlString &= "     </div>"
            htmlString &= "     </div>"
            htmlString &= " <div>&nbsp;</div>"
        Next

        If count < 0 Then
            htmlString &= "                     <div>No Current Events registered"
            htmlString &= "                     </div>"
        End If
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"

        Return htmlString

    End Function
    Private Function GetEventData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Association_Id", DropDownList1.SelectedValue.Trim)
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
        btnBook_ModalPopupExtender.Show()

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@event_id", HiddenFieldEventId.Value.Trim)
        cmd.Parameters.AddWithValue("@Attending", HiddenFieldBookStatus.Value)


        Dim str As String = ""


        str &= " SELECT         event_id, Association_Id, Event_Name, ShortDescription, LongDescription, EventType, EventDate, EventTime, AcceptBooking, Period, Year, Venue, Venue_Adres1, Venue_Adres2, Venue_Adres3"
        str &= " FROM            tbl_Association_Events"
        str &= " where event_id = @event_id"


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
            lblEditId.Text = ds.Tables(0).Rows(0).Item("event_id").ToString.Trim
            TextBox1.Text = ds.Tables(0).Rows(0).Item("Event_Name").ToString.Trim
            TextBox2.Text = ds.Tables(0).Rows(0).Item("EventDate").ToString.Trim
            TextBox3.Text = ds.Tables(0).Rows(0).Item("EventTime").ToString.Trim
            TextBox4.Text = ds.Tables(0).Rows(0).Item("ShortDescription").ToString.Trim
            TextBox5.Text = ds.Tables(0).Rows(0).Item("Venue").ToString.Trim
            TextBox6.Text = ds.Tables(0).Rows(0).Item("Venue_Adres1").ToString.Trim
            TextBox7.Text = ds.Tables(0).Rows(0).Item("Venue_Adres2").ToString.Trim
            TextBox8.Text = ds.Tables(0).Rows(0).Item("Venue_Adres3").ToString.Trim
            CheckBox1.Checked = ds.Tables(0).Rows(0).Item("AcceptBooking").ToString.Trim
            DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item("EventType").ToString.Trim
        Catch ex As Exception

        End Try

        GetAssociationDetails()
        PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))

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
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        GetAssociationDetails()
        PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetAssociationDetails()
        PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
    End Sub
    Protected Sub btnNewEvent_Click(sender As Object, e As EventArgs) Handles btnNewEvent.Click
        btnBook_ModalPopupExtender.Show()
        lblEditId.Text = "0"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        CheckBox1.Checked = "True"
        DropDownList2.SelectedValue = "Meeting"
        GetAssociationDetails()
        PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
    End Sub
    Private Sub UpdateEvent()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@EventId", HiddenFieldEventId.Value.Trim)
        cmd.Parameters.AddWithValue("@Attending", HiddenFieldBookStatus.Value)

        cmd.Parameters.AddWithValue("@Event_Name", TextBox1.Text.Trim)
        cmd.Parameters.AddWithValue("@EventDate", TextBox2.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTime", TextBox3.Text.Trim)
        cmd.Parameters.AddWithValue("@ShortDescription", TextBox4.Text.Trim)
        cmd.Parameters.AddWithValue("@Venue", TextBox5.Text.Trim)
        cmd.Parameters.AddWithValue("@Venue_Adres1", TextBox6.Text.Trim)
        cmd.Parameters.AddWithValue("@Venue_Adres2", TextBox7.Text.Trim)
        cmd.Parameters.AddWithValue("@Venue_Adres3", TextBox8.Text.Trim)
        cmd.Parameters.AddWithValue("@LongDescription", "")
        cmd.Parameters.AddWithValue("@EventType", DropDownList2.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@AcceptBooking", CheckBox1.Checked)
        cmd.Parameters.AddWithValue("@Period", CDate(TextBox2.Text.Trim).Month)
        cmd.Parameters.AddWithValue("@Year", CDate(TextBox2.Text.Trim).Year)
        cmd.Parameters.AddWithValue("@Association_Id", DropDownList1.SelectedValue.Trim)


        Dim str As String = ""


        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Association_Events  "
        str &= " WHERE (event_id = @EventId)) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Association_Events"
        str &= " SET Event_Name = @Event_Name, ShortDescription = @ShortDescription, LongDescription = @LongDescription, EventType = @EventType, EventDate = @EventDate, EventTime = @EventTime, AcceptBooking = @AcceptBooking, Period = @Period, Year = @Year, Venue = @Venue, Venue_Adres1 = @Venue_Adres1, Venue_Adres2 = @Venue_Adres2, Venue_Adres3 = @Venue_Adres3 "
        str &= " WHERE (event_id = @EventId)  "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= "  INSERT INTO tbl_Association_Events"
        str &= " (Association_Id, Event_Name, ShortDescription, LongDescription, EventType, EventDate, EventTime, AcceptBooking, Period, Year, Venue, Venue_Adres1, Venue_Adres2, Venue_Adres3)"
        str &= " VALUES "
        str &= " (@Association_Id, @Event_Name, @ShortDescription, @LongDescription, @EventType, @EventDate, @EventTime, @AcceptBooking, @Period, @Year, @Venue, @Venue_Adres1, @Venue_Adres2, @Venue_Adres3)"
        str &= " SELECT SCOPE_IDENTITY()"
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

            Try
                If CheckBox2.Checked Then
                    If HiddenFieldEventId.Value.Trim = "" Then
                        Dim eventId As String = ds.Tables(0).Rows(0).Item(0).ToString.Trim
                        CreateQrCode(eventId)
                    Else
                        If Not System.IO.File.Exists("QrCodes\" & HiddenFieldEventId.Value.Trim & "QrCode.jpg") Then
                            CreateQrCode(HiddenFieldEventId.Value.Trim)
                        End If
                    End If

                End If

            Catch ex As Exception
                Dim g As String = ex.Message
            End Try

            PlaceHolder1.Controls.Clear()
            PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
            HiddenFieldEventId.Value = ""
            HiddenFieldBookStatus.Value = ""


        Catch ex As Exception
            lblMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub CreateQrCode(EventId As String)

        Dim SavePath As String = ""
        Dim pathname As String = "QrCodes\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot

        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot
        If System.IO.Directory.Exists(SavePath) Then
        Else
            System.IO.Directory.CreateDirectory(SavePath)
        End If

        Dim qrCode As New QRCodeWriter()
        Dim qrValue As String = "http://www.ecohunter-app.co.za/Associations/dynamicAttend.aspx?evId=" & EventId
        Dim BarcodeWriter As New ZXing.BarcodeWriter
        BarcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE
        BarcodeWriter.Options.Height = 200
        BarcodeWriter.Options.Width = 400
        BarcodeWriter.Options.Margin = 1
        Dim Results = BarcodeWriter.Write(qrValue)

        Dim imagePath As String = "QrCodes/" & EventId & "QrCode.jpg"

        Dim barcodePath As String = Server.MapPath(imagePath)
        Dim barcodeBitmap = New Bitmap(Results)
        Using memory As New MemoryStream()
            Using fs As New FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite)
                barcodeBitmap.Save(memory, ImageFormat.Jpeg)
                Dim bytes As Byte() = memory.ToArray()
                fs.Write(bytes, 0, bytes.Length)
            End Using
        End Using

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lblMsg.Text = ""
        UpdateEvent()
    End Sub
    Private Function GetAttendance(EventId As String) As String()

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@EventId", EventId)


        Dim str As String = ""


        str &= " SELECT        COUNT(Event_Id) AS Count, Attend"
        str &= " FROM            tbl_Association_Event_Attending"
        str &= " WHERE        (Event_Id = @EventId)"
        str &= " GROUP BY Attend"


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

        Dim thisCounts(2) As String

        Try
            Dim count As Integer = ds.Tables(0).Rows.Count
            Dim sp As Integer

            For sp = 0 To count
                If ds.Tables(0).Rows(sp).Item("Attend").ToString.Trim = "Attending" Then
                    thisCounts(0) = ds.Tables(0).Rows(sp).Item("Count").ToString.Trim
                Else
                    thisCounts(1) = ds.Tables(0).Rows(sp).Item("Count").ToString.Trim

                End If


            Next

        Catch ex As Exception

        End Try


        If thisCounts(0) = "" Then
            thisCounts(0) = 0
        End If
        If thisCounts(1) = "" Then
            thisCounts(1) = 0
        End If

        Return thisCounts
    End Function
    Protected Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound

        If DropDownList1.Items.Count > 1 Then
            DropDownList1.Items.Add("Select")
            DropDownList1.SelectedValue = "Select"
        Else
            GetAssociationDetails()
            PlaceHolder1.Controls.Add(New LiteralControl(GetEvents))
        End If

    End Sub
End Class
