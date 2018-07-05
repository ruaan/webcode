Imports System.Data
Partial Class PasswordReset
    Inherits System.Web.UI.Page
    Dim Username, Email As String

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        lblMsg.Text = ""
        Label1.Text = ""
        If CheckEmailAddress() Then
            If txtPassword.Text.Trim <> "" And txtPassword1.Text.Trim <> "" Then
                If txtPassword.Text.Trim = txtPassword1.Text.Trim Then
                    SavePassword()
                    If lblMsg.Text = "" Then
                        Response.Redirect("Login.aspx", True)
                    End If
                Else
                    lblMsg.Text &= "The passwords does not match.<br>"
                End If
            Else
                lblMsg.Text &= "Please enter your password twice.<br>"
            End If
        Else
            pnlForgotPassword.Visible = False
            pnlNotFound.Visible = True
            Label1.Text = "This email address was not found."
        End If
    End Sub
    Private Function CheckEmailAddress() As Boolean

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserName", Username.Trim)
        cmd.Parameters.AddWithValue("@Email", Email.Trim)

        Dim Name As Boolean = True
        Dim str As String = ""
        str &= " SELECT tbl_Users.id, tbl_Users.UserName, tbl_Password.Password, tbl_Users.MemberId, tbl_Member.Email "
        str &= " FROM tbl_Users INNER JOIN "
        str &= " tbl_Password ON tbl_Users.id = tbl_Password.UserId INNER JOIN "
        str &= " tbl_Member On tbl_Users.MemberId = tbl_Member.MemberId "
        str &= " WHERE (tbl_Users.UserName = @UserName) AND (tbl_Member.Email = @Email) "

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
                Name = True
            Else
                Name = False
            End If
        Catch ex As Exception
            Name = False
        Finally
            sqlconnection1.Close()
        End Try
        Return Name
    End Function
    Private Function GetPassword() As String

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserName", Username.Trim)
        cmd.Parameters.AddWithValue("@Email", Email.Trim)

        Dim Name As String
        Dim str As String = ""
        str &= " SELECT tbl_Users.id, tbl_Users.UserName, tbl_Password.Password, tbl_Users.MemberId, tbl_Member.Email "
        str &= " FROM tbl_Users INNER JOIN "
        str &= " tbl_Password ON tbl_Users.id = tbl_Password.UserId INNER JOIN "
        str &= " tbl_Member On tbl_Users.MemberId = tbl_Member.MemberId "
        str &= " WHERE (tbl_Users.UserName = @UserName) AND (tbl_Member.Email = @Email) "

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
                Name = ds5.Tables(0).Rows(0).Item("Password").ToString.Trim
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
    Private Function GetEmail() As String

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserName", Username.Trim)
        cmd.Parameters.AddWithValue("@Email", Email.Trim)

        Dim Name As String
        Dim str As String = ""
        str &= " SELECT tbl_Users.id, tbl_Users.UserName, tbl_Password.Password, tbl_Users.MemberId, tbl_Member.Email "
        str &= " FROM tbl_Users INNER JOIN "
        str &= " tbl_Password ON tbl_Users.id = tbl_Password.UserId INNER JOIN "
        str &= " tbl_Member On tbl_Users.MemberId = tbl_Member.MemberId "
        str &= " WHERE (tbl_Users.UserName = @UserName) AND (tbl_Member.Email = @Email) "

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
                Name = ds5.Tables(0).Rows(0).Item("Email").ToString.Trim
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
    Private Function GetUserId() As String

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserName", Username.Trim)

        Dim Name As String
        Dim str As String = ""
        str &= " SELECT id FROM tbl_Users WHERE (UserName = @UserName) "

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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Username = Request.QueryString("UserName").ToString.Trim
        Email = Request.QueryString("Email").ToString.Trim

        If Not CheckEmailAddress() Then
            pnlForgotPassword.Visible = False
            pnlNotFound.Visible = True
            Label1.Text = "This email address was not found."
        End If

    End Sub
    Private Sub SavePassword()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", GetUserId())
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""

        str3 &= " UPDATE tbl_Password SET Password = @Password WHERE UserId = @UserId "

        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= "Problem occured : " & ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
