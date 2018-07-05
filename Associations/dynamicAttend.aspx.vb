Imports System.Data
Partial Class Associations_dynamicAttend
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim EventId As String = Request.QueryString("evId")
        Dim MemberId As String = Request.QueryString("m")

        UpdateMemberAttendance(EventId, "Attended", MemberId)

        GetEvent(EventId, MemberId)

    End Sub
    Private Sub UpdateMemberAttendance(ByVal theId As String, ByVal Attend As String, MemberId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@theId", theId.Trim)
        cmd.Parameters.AddWithValue("@Attend", Attend.Trim)
        cmd.Parameters.AddWithValue("@MemberId", MemberId.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""



        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Association_Event_Attending WHERE  Event_Id = @theId AND MemberId = @MemberId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Association_Event_Attending SET Attend = @Attend  WHERE Event_Id = @theId AND MemberId = @MemberId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Association_Event_Attending (Event_Id, MemberId, Attend) VALUES (@theId, @MemberId, @Attend) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"

        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub GetEvent(EventId As String, MemberId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", EventId.Trim)
        cmd.Parameters.AddWithValue("@MemberId", MemberId.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""

        str3 &= " SELECT    tbl_Association_Event_Attending.id, tbl_Association_Event_Attending.Event_Id, tbl_Association_Event_Attending.MemberId, tbl_Association_Event_Attending.Attend, tbl_Association_Events.Event_Name, "
        str3 &= "                          tbl_Association_Events.EventType, tbl_Member.PreferredName, tbl_Member.Surname"
        str3 &= " FROM            tbl_Association_Event_Attending INNER JOIN"
        str3 &= "                          tbl_Association_Events ON tbl_Association_Event_Attending.Event_Id = tbl_Association_Events.event_id INNER JOIN"
        str3 &= "                          tbl_Member ON tbl_Association_Event_Attending.MemberId = tbl_Member.MemberId"
        str3 &= " WHERE        (tbl_Association_Event_Attending.Event_Id = @EventId) AND (tbl_Association_Event_Attending.MemberId = @MemberId )"

        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try

        Try
            If ds3.Tables(0).Rows(0).Item("EventType").ToString.Trim = "Meeting" Then
                pnlMeeting.Visible = True
                pnlShoot.Visible = False
            Else
                pnlMeeting.Visible = True
                pnlShoot.Visible = False
            End If

            lblEvent.Text = ds3.Tables(0).Rows(0).Item("Event_Name").ToString.Trim
            lblEvent1.Text = ds3.Tables(0).Rows(0).Item("Event_Name").ToString.Trim
            lblName.Text = ds3.Tables(0).Rows(0).Item("PreferredName").ToString.Trim & " " & ds3.Tables(0).Rows(0).Item("Surname").ToString.Trim
            lblName1.Text = ds3.Tables(0).Rows(0).Item("PreferredName").ToString.Trim & " " & ds3.Tables(0).Rows(0).Item("Surname").ToString.Trim
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        End Try
    End Sub

End Class
