Imports System.Data
Partial Class Members_My_Hunts_App
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Dim userid As String = Request.QueryString("memberid")
            Dim memberid As String = Request.QueryString("member")
            Dim usethisid As String = ""
            Try
                If userid <> "" Then
                    Response.Cookies("memberid").Value = GetMemberId(userid)
                End If
                Try
                    If memberid <> "" Then
                        Response.Cookies("memberid").Value = memberid
                    End If
                Catch ex As Exception

                End Try
                PlaceHolder1.Controls.Add(New LiteralControl(GetHuntDetails))
            Catch ex As Exception

            End Try




        End If

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PlaceHolder1.Controls.Add(New LiteralControl(GetHuntDetails))
    End Sub
    Private Function GetHuntDetails() As String

        Dim htmlString As String = ""
        Dim dsHunt As New DataSet
        dsHunt = PopulateHunts()


        Dim count As Integer = dsHunt.Tables(0).Rows.Count - 1
        Dim sp As Integer

        htmlString &= "<div>"
        For sp = 0 To count

            htmlString &= "  <div style='background-color: #FFFFFF; padding-left: 5px;'>"

            htmlString &= "             <div style='font-weight: bold; font-size: large;'>"
            htmlString &= dsHunt.Tables(0).Rows(sp).Item("UniqueName").ToString.Trim
            htmlString &= "             </div>"
            htmlString &= "             <div>"
            htmlString &= CDate(dsHunt.Tables(0).Rows(sp).Item("Date_From").ToString.Trim).ToString("dd/MM/yyyy") & " - " & CDate(dsHunt.Tables(0).Rows(sp).Item("Date_To").ToString.Trim).ToString("dd/MM/yyyy")
            htmlString &= "             </div>"

            htmlString &= "             <div style='display:inline-block;'>"

            htmlString &= "             <div>&nbsp;</div>"
            Dim status As String = dsHunt.Tables(0).Rows(sp).Item("Description").ToString.Trim
            htmlString &= "             <div>"
            htmlString &= "                 Status: " & status
            htmlString &= "             </div>"
            htmlString &= "             <div>&nbsp;</div>"
            htmlString &= "                 </div>"
            htmlString &= "             <div  style='display:inline-block; vertical-align:middle; padding-left: 40px;'>"

            Select Case status
                Case = "Reserved"
                    htmlString &= "                 <input id='btnViewEdit' type='button' value='View / Edit' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href='Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'"" />"
                Case = "Date Confirmed"
                    htmlString &= "                 <input id='btnPayDep' type='button' value='Pay Deposit' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href = 'Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'""  />"
                Case = "Date Declined"
                    htmlString &= "                 <input id='btnView' type='button' value='View' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href ='Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'""  />"
                Case = "Canceled By Member"
                    htmlString &= "                 <input id='btnView' type='button' value='View' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href ='Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'""  />"
                Case = "Deposit Paid"
                    htmlString &= "                 <input id='btnHunt' type='button' value='Go Hunt' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href ='Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'""  />"
                Case = "Hunt Complete"
                    htmlString &= "                 <input id='btnView' type='button' value='View' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href ='Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'""  />"
                Case = "Partial Deposit Paid"
                    htmlString &= "                 <input id='btnPayDep' type='button' value='Pay Deposit' style='border-style: none; background-color: #86B24F; color: #FFFFFF' onclick=""location.href ='Hunts_Detail_App.aspx?h=" & dsHunt.Tables(0).Rows(sp).Item("HuntId").ToString.Trim & "'""  />"

            End Select
            htmlString &= "             <div>&nbsp;</div>"




            htmlString &= "                 </div>"
            htmlString &= "         </div>"



            htmlString &= "             <div>&nbsp;</div>"


        Next
        htmlString &= "</div>"


        Return htmlString

    End Function
    Private Function PopulateHunts() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)


        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.UniqueName, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts_Status.Description"
        str &= " FROM            tbl_Hunts_Members INNER JOIN"
        str &= "                          tbl_Hunts ON tbl_Hunts_Members.Hunts_Id = tbl_Hunts.HuntId INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId"
        str &= " WHERE        (tbl_Hunts_Members.MemberId = @MemberId)"

        If CheckBox2.Checked = False Then
            str &= " AND StatusId IN('1','2','5','6','8')"
        End If
        str &= " ORDER BY tbl_Hunts.Date_From"

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

    Private Function GetMemberId(userid As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", userid)


        Dim str As String = ""
        str &= " SELECT MemberId"
        str &= " FROM tbl_Users"
        str &= " where id = @id"

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

        Dim memberId As String = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim

        Return memberId


    End Function


End Class
