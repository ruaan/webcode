Imports System.Data
Partial Class Members_MemberManageGallery
    Inherits System.Web.UI.Page

#Region "Variants"

#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            PopulateMembers()
        End If
    End Sub
    Protected Sub btnAddMain_Click(sender As Object, e As EventArgs) Handles btnAddMain.Click
        pnlAddMain.Visible = True
        txtMainName.Text = ""
        TextBox1.Text = ""
        chkMainPrivate.Checked = False
        txtMainFolderId.Text = "0"
    End Sub
    Protected Sub btnSubmitMain_Click(sender As Object, e As EventArgs) Handles btnSubmitMain.Click
        AddEditMainFolderName()
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        lblMsg.Text = ""
        If e.CommandName = "ViewLine" Then
            pnlSub.Visible = True
            pnlPhotos.Visible = False
            GridView2.DataSource = Nothing
            GridView2.DataBind()
            txtSub.Text = ""
            lblMainId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text
            txtMain.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text
            PopulateSubGrid(GridView1.Rows(e.CommandArgument).Cells(1).Text)
        ElseIf e.CommandName = "EditLine" Then
            pnlAddMain.Visible = True
            txtMainFolderId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text
            txtMainName.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text
            TextBox1.Text = GetAlbumDescription(GridView1.Rows(e.CommandArgument).Cells(1).Text)
            Try
                chkMainPrivate.Checked = GetAlbumPrivate(GridView1.Rows(e.CommandArgument).Cells(1).Text).Trim
            Catch ex As Exception
                chkMainPrivate.Checked = False
            End Try
        ElseIf e.CommandName = "myDelete" Then
            DeleteMainFolderGallery(GridView1.Rows(e.CommandArgument).Cells(1).Text)
            PopulateGrid(lblId.Text.Trim)
        End If
    End Sub
    Protected Sub btnAddSubFolder_Click(sender As Object, e As EventArgs) Handles btnAddSubFolder.Click
        pnlSubFolder.Visible = True
        txtsubId.Text = ""
        txtSub.Text = ""
        TextBox2.Text = ""
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim validate As Boolean = True
        If txtMain.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the main folder name.<br>"
        End If
        If txtSub.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the sub category name.<br>"
        End If
        If validate = True Then
            SaveSubCategory(lblMainId.Text.Trim, txtSub.Text.Trim, txtsubId.Text.Trim)
            PopulateSubGrid(lblMainId.Text.Trim)
            txtSub.Text = ""
            txtsubId.Text = ""
            pnlSubFolder.Visible = False
        End If
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        lblMsg.Text = ""
        If e.CommandName = "ViewLine" Then
            pnlPhotos.Visible = True
            txtPhoto.Text = ""
            lblMain1.Text = lblMainId.Text.Trim & " " & txtMain.Text.Trim
            txtSubId1.Text = GridView2.Rows(e.CommandArgument).Cells(1).Text
            txtSub1.Text = GridView2.Rows(e.CommandArgument).Cells(2).Text
            Try
                PlaceHolder1.Controls.Add(New LiteralControl(GetPhotos(GridView2.Rows(e.CommandArgument).Cells(1).Text)))
            Catch ex As Exception
            End Try
        ElseIf e.CommandName = "EditLine" Then
            pnlSubFolder.Visible = True
            txtsubId.Text = GridView2.Rows(e.CommandArgument).Cells(1).Text
            txtSub.Text = GridView2.Rows(e.CommandArgument).Cells(2).Text
            TextBox2.Text = GetSubAlbumDescription(GridView2.Rows(e.CommandArgument).Cells(1).Text)
            Try
                chkSubPrivate.Checked = GetSubAlbumPrivate(GridView2.Rows(e.CommandArgument).Cells(1).Text).Trim
            Catch ex As Exception
                chkSubPrivate.Checked = False
            End Try
        ElseIf e.CommandName = "myDelete" Then
            DeleteSubFolderGallery(GridView2.Rows(e.CommandArgument).Cells(1).Text)
            PopulateSubGrid(lblMainId.Text.Trim)
        End If
    End Sub
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If (FileUpload1.HasFile) Then
            Dim savePath As String = ""
            Dim filename As String = ""
            Dim pathname As String = "Albums\" & txtMain.Text.Trim & "\" & txtSub1.Text.Trim & "\"
            Dim pathnameRoot As String
            pathnameRoot = Server.MapPath(pathname)
            savePath = pathnameRoot
            If System.IO.Directory.Exists(savePath) Then
            Else
                System.IO.Directory.CreateDirectory(savePath)
            End If
            Try
                filename = FileUpload1.FileName
                savePath += filename
                FileUpload1.SaveAs(savePath)
                SavePhotoUploadGallery(txtSubId1.Text.Trim, filename, txtPhoto.Text.Trim)
                txtPhoto.Text = ""
                PlaceHolder1.Controls.Add(New LiteralControl(GetPhotos(txtSubId1.Text.Trim)))
            Catch ex As Exception
                lblMsg.Text &= ex.Message
            End Try
        End If
    End Sub
    Protected Sub ddlMember_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMember.DataBound
        ddlMember.Items.Insert(0, New ListItem("-Select-"))
    End Sub
    Protected Sub ddlMember_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMember.SelectedIndexChanged
        lblId.Text = ddlMember.SelectedValue.Trim
        lblName.Text = GetMemberName(ddlMember.SelectedValue.Trim)
        pnlAlbums.Visible = True
        PopulateGrid(ddlMember.SelectedValue.Trim)
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateGrid(ByVal MemberId As String)
        Dim ds As New DataSet
        ds = GetDisplayGalleryMain(MemberId.Trim)

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AddEditMainFolderName()
        SaveMainFolderGallery(txtMainFolderId.Text.Trim, txtMainName.Text.Trim, TextBox1.Text.Trim)
        txtMainName.Text = ""
        txtMainFolderId.Text = ""
        pnlAddMain.Visible = False
        PopulateGrid(lblId.Text.Trim)
    End Sub
    Private Sub PopulateSubGrid(ByVal mainId As String)
        Dim ds As New DataSet
        ds = GetDisplayGallerySub(mainId)

        Try
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PopulateMembers()
        Dim ds As New DataSet()

        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@userId", Request.Cookies("UserId").Value.Trim)
        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Member.MemberId, tbl_Member.FullName + ' ' + tbl_Member.Surname AS Name "
        str &= " FROM tbl_Member INNER Join tbl_Users On tbl_Member.MemberId = tbl_Users.MemberId "
        If Request.Cookies("UserType").Value.Trim <> "Super Admin" Then
            str &= " WHERE (tbl_Users.id = @userId) "
        End If
        str &= " ORDER BY Name "

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
#End Region

#Region "Functions"
    Private Function GetDisplayGalleryMain(ByVal MemberId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@MemberId", MemberId.Trim)

        Dim str As String = ""
        str &= " Select * FROM AlbumMain WHERE MemberId = @MemberId "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Public Function SaveMainFolderGallery(mainId As String, Name As String, Beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", Beskrywing.Trim)
        cmd.Parameters.AddWithValue("@UploadedBy", "")
        cmd.Parameters.AddWithValue("@DateUploaded", Now.Date)
        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        If chkMainPrivate.Checked Then
            cmd.Parameters.AddWithValue("@Private", "True")
        Else
            cmd.Parameters.AddWithValue("@Private", "False")
        End If

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " If EXISTS (Select * FROM AlbumMain WHERE id = @mainId)"
        str &= " BEGIN"
        str &= " UPDATE AlbumMain Set Name = @Name, Description = @Description, Private = @Private, MemberId = @MemberId WHERE (id = @mainId)"
        str &= " End "
        str &= " Else "
        str &= " BEGIN"
        str &= " INSERT INTO AlbumMain (Name, Description, UploadedBy, DateUploaded, Private, MemberId) VALUES (@Name, @Description, @UploadedBy, @DateUploaded, @Private, @MemberId) "
        str &= " End  "
        str &= " COMMIT TRAN"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
            success = ("<Success>True</Success>")
        Catch ex As Exception
            success = ("<Success>False:" & ex.Message & " </Success>")
            Label1.Text &= ex.Message & "<br>"
        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Function GetDisplayGallerySub(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM AlbumSub WHERE (mainId = @mainId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Public Function DeleteMainFolderGallery(mainId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM AlbumMain WHERE (id = @mainId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
            success = ("<Success>True</Success>")
        Catch ex As Exception
            success = ("<Success>False:" & ex.Message & " </Success>")

        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Function GetAlbumDescription(ByVal albumId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@id", albumId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Description FROM AlbumMain WHERE (id = @id) "

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
                Name = ds5.Tables(0).Rows(0).Item("Description").ToString.Trim
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
    Private Function SaveSubCategory(mainId As String, Name As String, subId As String) As String
        Dim Status As String = ""
        SaveGallerySub(mainId, subId, Name, TextBox2.Text.Trim)
        Return Status
    End Function
    Public Function SaveGallerySub(mainId As String, subId As String, Name As String, beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", beskrywing.Trim)
        If chkSubPrivate.Checked Then
            cmd.Parameters.AddWithValue("@Private", "True")
        Else
            cmd.Parameters.AddWithValue("@Private", "False")
        End If

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM AlbumSub WHERE mainId = @mainId And subId = @subId)"
        str &= " BEGIN"
        str &= " UPDATE AlbumSub SET Name = @Name, Description = @Description, Private = @Private WHERE (mainId = @mainId And subId = @subId)"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO AlbumSub (mainId, Name, Description, Private) VALUES (@mainId, @Name, @Description, @Private) "
        str &= " END  "
        str &= " COMMIT TRAN"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
            success = ("<Success>True</Success>")
        Catch ex As Exception
            success = ("<Success>False:" & ex.Message & " </Success>")

        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Function GetPhotos(ByVal subId As String) As String
        Dim ds As New DataSet
        ds = GetDisplayGalleryPhotos(subId.Trim)
        Dim count As Integer = ds.Tables(0).Rows.Count
        Dim sp As Integer = 0
        Dim mycounter As Integer = 3

        Dim HtmlString As String
        HtmlString = "<table align='left' border='0'> "
        HtmlString &= "     <tr>"
        For sp = 0 To count
            Try
                If sp = 3 Or sp = 6 Or sp = 9 Or sp = 12 Or sp = 15 Or sp = 18 Or sp = 21 Or sp = 24 Or sp = 27 Or sp = 30 Or sp = 33 Or sp = 36 Or sp = 39 Or sp = 42 Or sp = 45 Then
                    HtmlString &= "     </tr>"
                    HtmlString &= "     <tr><td colspan='2'>&nbsp;</td></tr>"
                    HtmlString &= "     <tr>"
                End If
                Dim url As String = ds.Tables(0).Rows(sp).Item("Url")
                Dim Name As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim photoId As String = ds.Tables(0).Rows(sp).Item("photoId")
                HtmlString &= "         <td height='275' valign='middle' align='center' bgcolor='#ffffff' width='240px'>"
                HtmlString &= "             <image  runat='server'  src='Albums/" & txtMain.Text.Trim & "/" & txtSub1.Text.Trim & "/" & url & "' style='height: 225px; width: 225px'/><br>"
                HtmlString &= "             " & Name & "<br>"
                HtmlString &= "         </td>"
                HtmlString &= "         <td width='6px'>&nbsp;</td>"
            Catch ex As Exception
            End Try
        Next
        HtmlString &= "     </tr>"
        HtmlString &= "</table>"
        Return HtmlString

    End Function
    Private Function GetDisplayGalleryPhotos(ByVal subId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM AlbumPhotos WHERE (subId = @subId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Public Function DeleteSubFolderGallery(subId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@subId", subId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM AlbumSub WHERE (subId = @subId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
            success = ("<Success>True</Success>")
        Catch ex As Exception
            success = ("<Success>False:" & ex.Message & " </Success>")

        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Function GetSubAlbumDescription(ByVal albumId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@id", albumId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Description FROM AlbumSub WHERE (subId = @id) "

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
                Name = ds5.Tables(0).Rows(0).Item("Description").ToString.Trim
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
    Private Function SavePhotoUploadGallery(subId As String, Url As String, Name As String) As String
        Dim Status As String = ""
        Status = SaveThisPhotoUploadGallery(subId, Url, Name)
        Return Status
    End Function
    Public Function SaveThisPhotoUploadGallery(subId As String, Url As String, Name As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Url", Url.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)

        Dim str As String = ""

        str &= " INSERT INTO AlbumPhotos (subId, Url, Name) VALUES (@subId, @Url, @Name) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
            success = ("<Success>True</Success>")
        Catch ex As Exception
            success = ("<Success>False:" & ex.Message & " </Success>")

        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Function GetAlbumPrivate(ByVal albumId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@id", albumId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Private FROM AlbumMain WHERE (id = @id) "

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
                Name = ds5.Tables(0).Rows(0).Item("Private").ToString.Trim
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
    Private Function GetSubAlbumPrivate(ByVal albumId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@id", albumId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Private FROM AlbumSub WHERE (subId = @id) "

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
                Name = ds5.Tables(0).Rows(0).Item("Private").ToString.Trim
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
    Private Function GetMemberName(ByVal MemberId As String) As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@MemberId ", MemberId.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT FullName + ' ' + Surname AS Name FROM tbl_Member WHERE (MemberId  = @MemberId ) "

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
                Name = ds5.Tables(0).Rows(0).Item("Name").ToString.Trim
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
