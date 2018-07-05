Imports System.Data
Partial Class Login
    Inherits System.Web.UI.Page

    Private Function GetUser(UserName As String, Password As String) As String()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserName", UserName.Trim)
        cmd.Parameters.AddWithValue("@Password", Password.Trim)



        Dim str As String = ""
        str &= " SELECT tbl_Users.id, tbl_Users.UserName, tbl_Users.UserType, tbl_Users.MemberId, tbl_Users.LastLoggedin, tblUserTypes.Type_Description, tblUserTypes.EntryPoint"
        str &= " FROM            tbl_Users INNER JOIN"
        str &= "                          tblUserTypes ON tbl_Users.UserType = tblUserTypes.Type_Name INNER JOIN"
        str &= "                          tbl_Password ON tbl_Users.id = tbl_Password.UserId"
        str &= " WHERE (tbl_Users.UserName = @UserName) AND (tbl_Password.Password = @Password) AND (Active = 'True')"
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
            lblMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
        Dim Path(4) As String
        Try
            Path(0) = ds.Tables(0).Rows(0).Item("EntryPoint").ToString.Trim
            Path(1) = ds.Tables(0).Rows(0).Item("UserType").ToString.Trim
            Path(2) = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim
            Path(3) = ds.Tables(0).Rows(0).Item("id").ToString.Trim
        Catch ex As Exception
            Path(0) = "False"
            lblMsg.Text &= ex.Message
        End Try

        Return Path

    End Function
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        lblMsg.Text = ""
        lblUserVal.Text = ""
        lblPasswordVal.Text = ""


        If txtUserName.Text = "" Then
            lblUserVal.Text = "* User Name is required."
        End If
        If txtPassword.Text = "" Then
            lblPasswordVal.Text = "* Password is required."
        End If

        If lblUserVal.Text = "" And lblPasswordVal.Text = "" Then
            Dim Path() As String = GetUser(txtUserName.Text.Trim, txtPassword.Text.Trim)
            If (Path(0) <> "") And (Path(0) <> "False") Then
                Response.Cookies("UserType").Value = Path(1)
                Response.Cookies("MemberId").Value = Path(2)
                Response.Cookies("UserId").Value = Path(3)
                UpdateLastLoginDate(Path(3))
                Response.Redirect(Path(0))
            Else
                lblMsg.Text &= "Your login attempt was not successful. Please try again."
            End If
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.Browser.IsMobileDevice = True Then
            Response.Redirect("LoginMobi.aspx")
        End If
        If Page.IsPostBack = False Then
            Response.Cookies("UserType").Value = Nothing
            Response.Cookies("MemberId").Value = Nothing
        End If

    End Sub
    Private Sub UpdateLastLoginDate(userid As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@LastLoggedin", Now)
        cmd.Parameters.AddWithValue("@UserId", userid)


        Dim str As String = ""
        str &= " UPDATE tbl_Users "
        str &= "  SET LastLoggedin = @LastLoggedin"
        str &= " WHERE id = @UserId"


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
    End Sub
End Class
