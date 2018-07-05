Imports System.Data
Partial Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        lblMsg.Text = ""
        Label1.Text = ""
        If CheckEmailAddress() Then
            lblMsg.Text = "Your password was send to " & txtUserName.Text.Trim & ".<br>"
            SendEmail()
            pnlForgotPassword.Visible = False
            pnlBack.Visible = True
            Label1.Text = "Your password reset link was send to " & txtUserName.Text.Trim & ".<br>"
        Else
            lblMsg.Text = "This email address was not found."
        End If
    End Sub
    Private Function CheckEmailAddress() As Boolean

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

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

        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

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

        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

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
    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("Login.aspx", True)
    End Sub
    Private Sub SendEmail()
        Dim messageBody As String = ""
        messageBody &= "<table width='70%' align='center' cellpadding='10' cellspacing='0' style='border: medium solid #3E432F'>"
        messageBody &= "    <tr style='background-color: #3E432F; '>"
        messageBody &= "        <td align='left' height='110' colspan='4'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img alt='' src='http://www.ecohunter-app.co.za/Images/Logos/eco-hunter-log-small.png' class='logo-style'  /></td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td height='35' align='center' colspan='4'>Click <a style='cursor:pointer' href='http://ecohunter-app.co.za/PasswordReset.aspx?UserName=" & txtUserName.Text.Trim & "&Email=" & txtEmail.Text.Trim & "'>here</a> to reset your password.</td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td colspan='4'>&nbsp;</td>"
        messageBody &= "    </tr>"
        messageBody &= "</table>"

        Dim myMailer As New MAILER
        Dim success As Boolean
        Dim receiver As String = GetEmail()
        success = myMailer.sendMail("Eco Hunter", receiver, "Eco Hunter", messageBody, True)
    End Sub
End Class
