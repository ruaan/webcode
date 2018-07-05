Imports System.Data
Partial Class SetUp_UserManager
    Inherits System.Web.UI.Page

#Region "Variants"

#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            PopulateList()
            PopulateUserTypes()
            PopulateMembers()
        End If
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "View" Then
            pnlDetail.Visible = True
            lblId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim
            txtUserName.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text.Trim
            Dim memberInfo() As String = GetMemberDetails(GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim)
            Try
                ddlUserType.SelectedValue = GetUserTypeId(memberInfo(1).Trim)
            Catch ex As Exception
                ddlUserType.SelectedValue = "-Select-"
            End Try
            If memberInfo(4).Trim = "" Then
                chkActive.Checked = False
            Else
                chkActive.Checked = memberInfo(4).Trim
            End If
            Try
                ddlMember.SelectedValue = memberInfo(2).Trim
            Catch ex As Exception
                ddlMember.SelectedValue = "-Select-"
            End Try
            txtPassword.Text = memberInfo(5).Trim
            pnlPassword.Visible = True
        End If
    End Sub
    Protected Sub ddlUserType_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUserType.DataBound
        ddlUserType.Items.Insert(0, New ListItem("-Select-"))
    End Sub
    Protected Sub ddlMember_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMember.DataBound
        ddlMember.Items.Insert(0, New ListItem("-Select-"))
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lblMessage.Text = ""
        pnlDetail.Visible = True
        ClearAll()
        pnlPassword.Visible = False
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Label1.Text = ""
        Dim validate As Boolean = True
        If txtUserName.Text = "" Then
            validate = False
            Label1.Text &= "Please enter the username.<br>"
        End If
        If ddlUserType.SelectedValue.Trim = "-Select-" Then
            validate = False
            Label1.Text &= "Please select the user type.<br>"
        End If
        If ddlMember.SelectedValue = "-Select-" Then
            validate = False
            Label1.Text &= "Please select the member.<br>"
        End If
        If validate = True Then
            SaveUser()
            If lblId.Text = "" Then
                CreatePassword()
            End If
            PopulateList()
            ClearAll()
            pnlDetail.Visible = False
        End If
    End Sub
    Protected Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If txtPassword.Text.Trim = "" Then
            Label1.Text = "Please enter the password.<br>"
        Else
            ResetPassword()
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str = " SELECT id, UserName, UserType, MemberId, LastLoggedin, Active FROM tbl_Users ORDER BY UserName "

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
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        End Try
    End Sub
    Private Sub PopulateUserTypes()
        Dim ds As New DataSet()

        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        Dim str As String = ""
        str &= " SELECT DISTINCT UserType_Id, Type_Name FROM tblUserTypes ORDER BY Type_Name "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlUserType.DataSource = ds.Tables(0)
            ddlUserType.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub PopulateMembers()
        Dim ds As New DataSet()

        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        Dim str As String = ""
        str &= " SELECT DISTINCT MemberId, FullName + ' ' + Surname AS Name FROM tbl_Member ORDER BY Name "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlMember.DataSource = ds.Tables(0)
            ddlMember.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub ClearAll()
        lblId.Text = ""
        txtUserName.Text = ""
        ddlUserType.SelectedValue = "-Select-"
        ddlMember.SelectedValue = "-Select-"
        chkActive.Checked = False
        txtPassword.Text = ""
    End Sub
    Private Sub SaveUser()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@UserType", GetUserType(ddlUserType.SelectedValue.Trim))
        cmd.Parameters.AddWithValue("@MemberId", ddlMember.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM tbl_Users WHERE (id = @id))"
        str &= " BEGIN"
        str &= " UPDATE tbl_Users SET UserName = @UserName, UserType = @UserType, MemberId = @MemberId, Active = @Active WHERE (id = @id) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO tbl_Users (UserName, UserType, MemberId, Active) VALUES (@UserName, @UserType, @MemberId, @Active) "
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
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub CreatePassword()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim userId As String = GetUserId(txtUserName.Text.Trim, ddlUserType.SelectedValue.Trim, ddlMember.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@UserId", userId.Trim)
        cmd.Parameters.AddWithValue("@Password", "Password_" & userId.Trim)

        Dim str As String = ""

        str &= " INSERT INTO tbl_Password (UserId, Password) VALUES (@UserId, @Password) "

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
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub ResetPassword()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Password", "Password_" & lblId.Text.Trim)

        Dim str As String = ""

        str &= " UPDATE tbl_Password SET Password = @Password WHERE UserId = @UserId "

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
            txtPassword.Text = "Password_" & lblId.Text.Trim
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Functions"
    Private Function GetMemberDetails(ByVal userId As String) As String()
        Dim memInfo(6) As String

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@userId", userId.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""

        str3 &= " SELECT tbl_Users.id, tbl_Users.UserName, tbl_Users.UserType, tbl_Users.MemberId, tbl_Users.LastLoggedin, tbl_Users.Active, tbl_Password.Password "
        str3 &= " FROM tbl_Users INNER JOIN "
        str3 &= " tbl_Password ON tbl_Users.id = tbl_Password.UserId WHERE (tbl_Users.id = @userId) ORDER BY tbl_Users.UserName "

        Try
            cmd3.CommandText = str3
            cmd3.CommandType = CommandType.Text
            cmd3.Connection = myconnection
            cmd3.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd3
            da3.Fill(ds3, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        If ds3.Tables(0).Rows.Count > 0 Then
            memInfo(0) = ds3.Tables(0).Rows(0).Item("UserName").ToString.Trim
            memInfo(1) = ds3.Tables(0).Rows(0).Item("UserType").ToString.Trim
            memInfo(2) = ds3.Tables(0).Rows(0).Item("MemberId").ToString.Trim
            memInfo(3) = ds3.Tables(0).Rows(0).Item("LastLoggedin").ToString.Trim
            memInfo(4) = ds3.Tables(0).Rows(0).Item("Active").ToString.Trim
            memInfo(5) = ds3.Tables(0).Rows(0).Item("Password").ToString.Trim
        Else
            memInfo(0) = ""
            memInfo(1) = ""
            memInfo(2) = ""
            memInfo(3) = ""
            memInfo(4) = ""
            memInfo(5) = ""
        End If
        Return memInfo
    End Function
    Private Function GetUserId(ByVal UserName As String, ByVal UserType As String, ByVal MemberId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserName", UserName.Trim)
        cmd.Parameters.AddWithValue("@UserType", UserType.Trim)
        cmd.Parameters.AddWithValue("@MemberId", MemberId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT id FROM tbl_Users WHERE (UserName = @UserName) AND (UserType = @UserType) AND (MemberId = @MemberId) "

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
                Name = ds5.Tables(0).Rows(0).Item("id").ToString.Trim
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
    Private Function GetUserTypeId(ByVal UserType As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserType", UserType.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT UserType_Id FROM tblUserTypes WHERE (Type_Name = '" & UserType.Trim & "') "

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
                Name = ds5.Tables(0).Rows(0).Item("UserType_Id").ToString.Trim
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
    Private Function GetUserType(ByVal UserTypeId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserTypeId", UserTypeId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Type_Name FROM tblUserTypes WHERE (UserType_Id = @UserTypeId) "

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
                Name = ds5.Tables(0).Rows(0).Item("Type_Name").ToString.Trim
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
