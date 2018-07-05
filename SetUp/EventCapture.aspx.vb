Imports System.Data
Partial Class SetUp_EventCapture
    Inherits System.Web.UI.Page

#Region "Variants"
    Dim eventId As String
#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = ""
        Label2.Text = ""
        If IsPostBack = False Then
            PopulateMembers()
            Try
                eventId = Request.QueryString("eventId").ToString.Trim
                PopulateEvent(eventId.Trim)
                PopulateGrid(eventId.Trim)
            Catch ex As Exception
                eventId = ""
            End Try
        End If
    End Sub
    Protected Sub ddlMembers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMembers.DataBound
        ddlMembers.Items.Insert(0, New ListItem("-Select-"))
        ddlMembers.Items.Insert(1, New ListItem("-Add Non Member-"))
    End Sub
    Protected Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        pnlAddMember.Visible = False
        If ddlMembers.SelectedValue.Trim = "-Add Non Member-" Then
            pnlAddMember.Visible = True
        ElseIf ddlMembers.SelectedValue.Trim = "-Select-" Then

        Else
            SaveMemberEvent("DDL")
            PopulateGrid(lblEventId.Text.Trim)
        End If
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Label1.Text = ""
        Label2.Text = ""
        SaveMemberEvent("")
        PopulateGrid(lblEventId.Text.Trim)
        txtName.Text = ""
        pnlAddMember.Visible = False
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        lblMsg.Text = ""
        Label1.Text = ""
        Label2.Text = ""
        If e.CommandName = "myDelete" Then
            DeleteEventAttendance(GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim)
            PopulateGrid(lblEventId.Text.Trim)
        End If
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        For Each myRow As GridViewRow In GridView1.Rows
            Dim myCheckBox As CheckBox = DirectCast(myRow.Cells(0).Controls(1), CheckBox)
            Dim status As String = GetMemberEventStatus(myRow.Cells(1).Text.Trim)
            If status.Trim = "Attended" Then
                myCheckBox.Checked = True
            Else
                myCheckBox.Checked = False
            End If
        Next
    End Sub
    Protected Sub btnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click
        SaveAttendees()
    End Sub
    Protected Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        SaveAttendees()
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateEvent(ByVal EventId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@event_id", EventId.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Association_Events.event_id, tbl_Association_Events.Association_Id, tbl_Association_Events.Event_Name, tbl_Association_Events.ShortDescription, tbl_Association_Events.LongDescription,  "
        str &= " tbl_Association_Events.EventType, tbl_Association_Events.EventDate, tbl_Association_Events.EventTime, tbl_Association_Events.AcceptBooking, tbl_Association_Events.Period, tbl_Association_Events.Year,  "
        str &= " tbl_Association_Events.Venue, tbl_Association_Events.Venue_Adres1, tbl_Association_Events.Venue_Adres2, tbl_Association_Events.Venue_Adres3, tbl_Associations.ProfilePicPath, tbl_Associations.Name "
        str &= " FROM tbl_Association_Events LEFT OUTER JOIN "
        str &= " tbl_Associations ON tbl_Association_Events.Association_Id = tbl_Associations.Association_Id "
        str &= " WHERE (tbl_Association_Events.event_id = @event_id) "

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
            lblMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                lblEventName.Text = ds.Tables(0).Rows(0).Item("Event_Name").ToString.Trim
                lblEventId.Text = ds.Tables(0).Rows(0).Item("event_id").ToString.Trim
                If ds.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim = "" Then
                    Image1.ImageUrl = "../Images/Associations/ProfilePlaceHolder.jpg"
                Else
                    Image1.ImageUrl = "../Images/Associations/" & ds.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim
                End If
                lblAssName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
                lblShortDescription.Text = ds.Tables(0).Rows(0).Item("ShortDescription").ToString.Trim
                lblVenue.Text = ds.Tables(0).Rows(0).Item("Venue").ToString.Trim
                lblEventDate.Text = CDate(ds.Tables(0).Rows(0).Item("EventDate").ToString.Trim).ToString("yyyy/MM/dd") & " " & ds.Tables(0).Rows(0).Item("EventTime").ToString.Trim
                lblAddress1.Text = ds.Tables(0).Rows(0).Item("Venue_Adres1").ToString.Trim
                lblAddress2.Text = ds.Tables(0).Rows(0).Item("Venue_Adres2").ToString.Trim
                lblAddress3.Text = ds.Tables(0).Rows(0).Item("Venue_Adres3").ToString.Trim
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PopulateMembers()
        Dim ds As New DataSet()
        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        Dim str As String = ""
        str &= " SELECT tbl_Users.id, tbl_Member.FullName + ' ' + tbl_Member.Surname AS Name, tbl_Member.MemberId, tbl_Users.UserType "
        str &= " FROM tbl_Member RIGHT OUTER JOIN "
        str &= " tbl_Users ON tbl_Member.MemberId = tbl_Users.MemberId "
        str &= " WHERE (tbl_Users.UserType = 'Member') "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlMembers.DataSource = ds.Tables(0)
            ddlMembers.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub SaveMemberEvent(ByVal From As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@MemberId", ddlMembers.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@NoMember", txtName.Text.Trim)
        cmd.Parameters.AddWithValue("@Event_Id", lblEventId.Text.Trim)
        cmd.Parameters.AddWithValue("@Attend", "Attended")

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""

        If From.Trim = "DDL" Then
            str3 &= " INSERT INTO tbl_Association_Event_Attending (Event_Id, MemberId, Attend) VALUES (@Event_Id, @MemberId, @Attend) "
        Else
            str3 &= " INSERT INTO tbl_Association_Event_Attending (Event_Id, NoMember, Attend) VALUES (@Event_Id, @NoMember, @Attend) "
        End If

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
    Private Sub UpdateMemberAttendance(ByVal theId As String, ByVal Attend As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@theId", theId.Trim)
        cmd.Parameters.AddWithValue("@Attend", Attend.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""

        str3 &= " UPDATE tbl_Association_Event_Attending SET Attend = @Attend WHERE id = @theId "

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
    Private Sub PopulateGrid(ByVal EventId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Event_Id", EventId.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Association_Event_Attending.MemberId, CASE WHEN tbl_Association_Event_Attending.MemberId IS NULL  "
        str &= " Then tbl_Association_Event_Attending.NoMember Else tbl_Member.FullName + ' ' + tbl_Member.Surname END AS Name, tbl_Association_Event_Attending.Event_Id, tbl_Association_Event_Attending.Attend,  "
        str &= " tbl_Association_Event_Attending.NoMember, tbl_Association_Event_Attending.id "
        str &= " FROM tbl_Association_Event_Attending LEFT OUTER JOIN "
        str &= " tbl_Member ON tbl_Association_Event_Attending.MemberId = tbl_Member.MemberId "
        str &= " WHERE (tbl_Association_Event_Attending.Event_Id = @Event_Id) "
        str &= " AND (tbl_Association_Event_Attending.Attend IN ('Attended', 'Attending', 'Maybe')) "
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
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteEventAttendance(ByVal theId As String)
        Dim sqlconnection1 As New SqlClient.SqlConnection
        Try
            sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

            Dim cmd As New SqlClient.SqlCommand
            cmd.Parameters.AddWithValue("@theId", theId.Trim)
            Dim str As String = ""

            str &= " DELETE FROM tbl_Association_Event_Attending WHERE  id = @theId "
            cmd.CommandText = str
            cmd.CommandType = CommandType.Text
            cmd.Connection = sqlconnection1
            sqlconnection1.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            sqlconnection1.Close()
        End Try

    End Sub
    Private Sub SaveAttendees()
        For Each myRow As GridViewRow In GridView1.Rows
            Dim myCheckBox As CheckBox = DirectCast(myRow.Cells(0).Controls(1), CheckBox)
            If myCheckBox.Checked Then
                UpdateMemberAttendance(myRow.Cells(1).Text.Trim, "Attended")
            Else
                UpdateMemberAttendance(myRow.Cells(1).Text.Trim, "Not Attended")
            End If
        Next
        Label1.Text = "Attendance Saved!"
        Label2.Text = "Attendance Saved!"
    End Sub
#End Region

#Region "Functions"
    Private Function GetMemberEventStatus(ByVal eventId As String) As String

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@eventId", eventId.Trim)

        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Attend FROM tbl_Association_Event_Attending WHERE (id = @eventId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Try
            sqlconnection1.Open()
            Dim da3 As New SqlClient.SqlDataAdapter()
            Dim tbl3 As New DataTable
            da3.SelectCommand = cmd
            da3.Fill(ds5)
            If ds5.Tables(0).Rows.Count > 0 Then
                Name = ds5.Tables(0).Rows(0).Item("Attend").ToString.Trim
            Else
                Name = ""
            End If
        Catch ex As Exception
            Name = ""
        Finally
            sqlconnection1.Close()
        End Try
        Return Name
    End Function
#End Region

End Class
