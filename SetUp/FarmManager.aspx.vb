Imports System.Data
Partial Class SetUp_FarmManager
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Registrations/addFarm.aspx")
    End Sub
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Search", txtSearch.Text.Trim & "%")
        Dim str As String = ""
        str = " SELECT * "
        str &= " FROM   tbl_Farm "
        str &= " WHERE (Status = '2') AND (FarmName LIKE @Search) OR (Status = '4') "
        str &= " AND FarmName LIKE @Search "
        str &= " ORDER BY FarmName"

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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateList()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "View" Then
            Response.Redirect("../Farms/farm_Edit_Profile.aspx?MemberId=" & GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
        ElseIf e.CommandName = "Animals" Then
            Response.Redirect("FarmAnimalManagementSuper.aspx?id=" & GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
        ElseIf e.CommandName = "Users" Then
            pnlUsers.Visible = True
            lblFarmId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString
            lblFarmName.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text.ToString
            PopulateUsers(GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
        End If





    End Sub
    Private Sub PopulateUsers(FarmId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", FarmId)
        Dim str As String = ""
        str &= " SELECT        tbl_Farms_v_User.id, tbl_Users.NickName, tbl_Farms_v_User.UserId, tbl_Farms_v_User.Type, tbl_Farms_v_User.Active, tbl_Users.UserName, tbl_Users.LastLoggedin, tbl_Users.Active AS UserActive"
        str &= " FROM            tbl_Farms_v_User INNER JOIN"
        str &= "                          tbl_Users ON tbl_Farms_v_User.UserId = tbl_Users.id"
        str &= " WHERE        (tbl_Farms_v_User.FarmId = @FarmId)"

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
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        End Try

    End Sub


    Private Sub SetUp_FarmManager_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Dim MemberId As String = ""
        Try
            MemberId = Request.Cookies("MemberId").Value
        Catch ex As Exception
            Response.Redirect("~/Login.aspx")
        End Try

    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtActualUser.Text = ""
        txtUserName.Text = ""
        txtPassword.Text = ""
        pnlCreateUser.Visible = False
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtActualUser.Text = ""
        txtUserName.Text = ""
        txtPassword.Text = ""
        pnlCreateUser.Visible = True
    End Sub
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lblUserMsg.Text = ""
        If txtUserName.Text = "" Then
            lblUserMsg.Text = "* User Name is Required.</br>"
        End If
        If txtPassword.Text = "" Then
            lblUserMsg.Text = "* Password is Required.</br>"
        End If
        If txtActualUser.Text = "" Then
            lblUserMsg.Text = "* Actual Name is Required.</br>"
        End If
        If lblUserMsg.Text = "" Then
            CreateUser()
        End If

    End Sub
    Private Sub CreateUser()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", "0")
        cmd.Parameters.AddWithValue("@NickName", txtActualUser.Text.Trim)
        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@UserType", "Farm Super")
        cmd.Parameters.AddWithValue("@LastLoggedin", Now)

        Dim str As String = ""
        str = " INSERT INTO tbl_Users"
        str &= "  (UserName, UserType, MemberId, LastLoggedin, Active, NickName) "
        str &= " VALUES"
        str &= "  (@UserName, @UserType, @MemberId, @LastLoggedin, 'True', @NickName) "
        str &= " SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]"
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
            '
            CreatePassword(ds.Tables(0).Rows(0).Item("SCOPE_IDENTITY").ToString)
        Catch ex As Exception
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub CreatePassword(UserId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserId", UserId.Trim)
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim)

        Dim str As String = ""
        str = " INSERT INTO tbl_Password"
        str &= "  (UserId, Password) "
        str &= " VALUES"
        str &= "  (@UserId, @Password) "

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
            LinkUserToFarm(UserId)
        Catch ex As Exception
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub LinkUserToFarm(UserId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserId", UserId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text)
        cmd.Parameters.AddWithValue("@Active", "True")
        cmd.Parameters.AddWithValue("@Type", "Farm Super")



        Dim str As String = ""
        str = " INSERT INTO  tbl_Farms_v_User"
        str &= "  (UserId, FarmId, Type, Active) "
        str &= " VALUES"
        str &= "  (@UserId, @FarmId, @Type, @Active) "

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
            PopulateUsers(lblFarmId.Text)
            txtActualUser.Text = ""
            txtUserName.Text = ""
            txtPassword.Text = ""
            pnlCreateUser.Visible = False
        Catch ex As Exception
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub imgBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnSearch.Click
        PopulateList()
    End Sub
End Class
