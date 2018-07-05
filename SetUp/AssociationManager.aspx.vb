Imports System.Data
Partial Class SetUp_AssociationManager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        PopulateList()
    End Sub
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str = " SELECT * FROM tbl_Associations ORDER BY Name"

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

        End Try
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtDescription.Text = ""
        lblId.Text = ""
        pnlDetail.Visible = False
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "View" Then
            pnlUsers.Visible = False
            pnlDetail.Visible = True
            lblId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim
            PopulateAssociationDetail(GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim)
        ElseIf e.CommandName = "Users" Then
            pnlDetail.Visible = False
            pnlUsers.Visible = True
            lblAssocId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString
            lblassociationName.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text.ToString
            PopulateUsers(GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
        End If

    End Sub
    Private Sub PopulateUsers(AssocId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@AssocId", AssocId)
        Dim str As String = ""
        str &= " SELECT        tbl_Association_v_User.id, tbl_Users.NickName, tbl_Association_v_User.UserId, tbl_Association_v_User.Type, tbl_Association_v_User.Active, tbl_Users.UserName, tbl_Users.LastLoggedin, "
        str &= "                          tbl_Users.Active AS UserActive"
        str &= " FROM            tbl_Association_v_User INNER JOIN"
        str &= "                          tbl_Users ON tbl_Association_v_User.UserId = tbl_Users.id"
        str &= " WHERE        (tbl_Association_v_User.Association_Id = @AssocId)"

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
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        pnlDetail.Visible = True
        pnlUsers.Visible = False
        lblId.Text = "New"
        txtDescription.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        txtShort.Text = ""
        txtLong.Text = ""
        Image1.ImageUrl = "../Images/ProfilePictures/Template.jpg"
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If lblId.Text = "New" Then
            AddDescription()
        Else
            UpdateDescription()
        End If
        If lblMessage.Text.Trim = "" Then
            lblId.Text = ""
            txtDescription.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            txtShort.Text = ""
            txtLong.Text = ""
            pnlDetail.Visible = False
            PopulateList()
        End If
    End Sub
    Private Sub AddDescription()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Name", txtDescription.Text.Trim)
        cmd.Parameters.AddWithValue("@ContactPerson", TextBox1.Text.Trim)
        cmd.Parameters.AddWithValue("@ContactTel", TextBox3.Text.Trim)
        cmd.Parameters.AddWithValue("@ContactEmail", TextBox2.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
        cmd.Parameters.AddWithValue("@ShortDescription", txtShort.Text.Trim)
        cmd.Parameters.AddWithValue("@LongDescription", txtLong.Text.Trim)

        Dim str As String = ""
        str = " INSERT INTO  tbl_Associations (Name, ContactPerson, ContactTel, ContactEmail, Active, ShortDescription, LongDescription) VALUES (@Name, @ContactPerson, @ContactTel, @ContactEmail, @Active, @ShortDescription, @LongDescription)"

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
    Private Sub UpdateDescription()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@Id", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Name", txtDescription.Text.Trim)
        cmd.Parameters.AddWithValue("@ContactPerson", TextBox1.Text.Trim)
        cmd.Parameters.AddWithValue("@ContactTel", TextBox3.Text.Trim)
        cmd.Parameters.AddWithValue("@ContactEmail", TextBox2.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
        cmd.Parameters.AddWithValue("@ShortDescription", txtShort.Text.Trim)
        cmd.Parameters.AddWithValue("@LongDescription", txtLong.Text.Trim)

        Dim str As String = ""
        str &= " UPDATE  tbl_Associations "
        str &= " SET Name = @Name, ContactPerson = @ContactPerson, ContactTel = @ContactTel, ContactEmail = @ContactEmail, Active = @Active, ShortDescription = @ShortDescription, LongDescription = @LongDescription"
        str &= " WHERE Association_Id = @Id"

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
    Private Sub PopulateAssociationDetail(AssociationId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("Association_Id", AssociationId.Trim)
        Dim str As String = ""
        str = " SELECT * FROM tbl_Associations WHERE Association_Id = @Association_Id ORDER BY Name"

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

        txtDescription.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
        TextBox1.Text = ds.Tables(0).Rows(0).Item("ContactPerson").ToString.Trim
        TextBox2.Text = ds.Tables(0).Rows(0).Item("ContactEmail").ToString.Trim
        TextBox3.Text = ds.Tables(0).Rows(0).Item("ContactTel").ToString.Trim
        chkActive.Checked = ds.Tables(0).Rows(0).Item("Active").ToString.Trim
        txtShort.Text = ds.Tables(0).Rows(0).Item("ShortDescription").ToString.Trim
        txtLong.Text = ds.Tables(0).Rows(0).Item("LongDescription").ToString.Trim
        If ds.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim = "" Then
            Image1.ImageUrl = "../Images/ProfilePictures/Template.jpg"
        Else
            Image1.ImageUrl = "../Images/Associations/" & ds.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim
        End If
    End Sub
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        lblUploadMsg.Text = ""
        Dim SavePath As String = ""
        Dim pathname As String = "../Images/Associations/"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot
        If System.IO.Directory.Exists(SavePath) Then
        Else
            System.IO.Directory.CreateDirectory(SavePath)
        End If

        Dim fileName As String = ""
        lblUploadMsg.Text = ""

        If (FileUpload1.HasFile) Then
            Dim fName As String = FileUpload1.FileName

            If System.IO.Directory.Exists(SavePath) Then
            Else
                System.IO.Directory.CreateDirectory(SavePath)
            End If

            Try
                If (FileUpload1.HasFile) Then
                    SavePath += fName.Trim
                    FileUpload1.SaveAs(SavePath)
                    UpdateProfilePicture(fName.Trim)
                End If
                Image1.ImageUrl = "../Images/Associations/" & fName
            Catch ex As Exception
                lblUploadMsg.Text &= ex.Message
            End Try
        Else
            lblUploadMsg.Text &= "Has no File<br>"
        End If
    End Sub
    Private Sub UpdateProfilePicture(ByVal FileName As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Association_Id", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@ProfilePicPath", FileName.Trim)

        Dim str As String = ""
        str = " UPDATE tbl_Associations SET ProfilePicPath = @ProfilePicPath WHERE (Association_Id = @Association_Id) "

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
            lblUploadMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        txtActualUser.Text = ""
        txtUserName.Text = ""
        txtPassword.Text = ""
        pnlCreateUser.Visible = True
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        txtActualUser.Text = ""
        txtUserName.Text = ""
        txtPassword.Text = ""
        pnlCreateUser.Visible = False
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lblUserMsg.Text = ""
        CreateUser()
    End Sub
    Private Sub CreateUser()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", "0")
        cmd.Parameters.AddWithValue("@NickName", txtActualUser.Text.Trim)
        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@UserType", "Association")
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
            LinkUserToAssociation(UserId)
        Catch ex As Exception
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub LinkUserToAssociation(UserId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserId", UserId.Trim)
        cmd.Parameters.AddWithValue("@Association_Id", lblAssocId.Text)
        cmd.Parameters.AddWithValue("@Active", "True")
        cmd.Parameters.AddWithValue("@Type", "Association")



        Dim str As String = ""
        str = " INSERT INTO  tbl_Association_v_User"
        str &= "  (UserId, Association_Id, Type, Active) "
        str &= " VALUES"
        str &= "  (@UserId, @Association_Id, @Type, @Active) "

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
            PopulateUsers(lblAssocId.Text)
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
End Class
