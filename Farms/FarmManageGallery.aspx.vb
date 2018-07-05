Imports System.Data
Imports System.IO
Partial Class Farms_FarmManageGallery
    Inherits System.Web.UI.Page

#Region "Variants"

#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'PopulateGrid()
            PopulateFarmList()
        End If
    End Sub
    Private Sub PopulateFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)
        Dim str As String = ""
        str &= " SELECT        tbl_Farm.FarmName, tbl_Farm.id "
        str &= " FROM            tbl_Farms_v_User INNER JOIN "
        str &= "                          tbl_Farm ON tbl_Farms_v_User.FarmId = tbl_Farm.id "
        str &= " WHERE        (tbl_Farms_v_User.UserId = @UserId) "
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
            ' lblSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            cmbFarms.DataSource = ds.Tables(0)
            cmbFarms.DataBind()
        Catch ex As Exception

        End Try

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
        ElseIf e.CommandName = "myDelete" Then
            DeleteMainFolderGallery(GridView1.Rows(e.CommandArgument).Cells(1).Text)
            PopulateGrid()
        End If
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
    Protected Sub btnAddMain_Click(sender As Object, e As EventArgs) Handles btnAddMain.Click
        pnlAddMain.Visible = True
        txtMainName.Text = ""
        txtMainFolderId.Text = "0"
    End Sub
    Protected Sub btnSubmitMain_Click(sender As Object, e As EventArgs) Handles btnSubmitMain.Click
        AddEditMainFolderName()
    End Sub
    Protected Sub btnAddSubFolder_Click(sender As Object, e As EventArgs) Handles btnAddSubFolder.Click
        pnlSubFolder.Visible = True
        txtsubId.Text = ""
        txtSub.Text = ""
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateGrid()

        'Dim OutStr As String = ""
        'OutStr = GettStuff.DisplayGalleryMain("NU#342HJK")
        'Dim testTextReader As New StringReader(OutStr)
        Dim ds As New DataSet
        ds = GetDisplayGalleryMain()
        'ds.ReadXml(testTextReader, XmlReadMode.Auto)

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            lblMsg.Text &= ex.Message
        End Try

    End Sub
    Private Sub PopulateSubGrid(ByVal mainId As String)

        'Dim OutStr As String = ""
        'OutStr = GettStuff.DisplayGallerySub("NU#342HJK", mainId)
        'Dim testTextReader As New StringReader(OutStr)
        Dim ds As New DataSet
        ds = GetDisplayGallerySub(mainId)
        'ds.ReadXml(testTextReader, XmlReadMode.Auto)

        Try
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AddEditMainFolderName()
        SaveMainFolderGallery(txtMainFolderId.Text.Trim, txtMainName.Text.Trim, TextBox1.Text.Trim)
        txtMainName.Text = ""
        txtMainFolderId.Text = ""
        pnlAddMain.Visible = False
        PopulateGrid()
    End Sub
#End Region

#Region "Functions"
    Private Function SaveSubCategory(mainId As String, Name As String, subId As String) As String
        Dim Status As String = ""
        SaveGallerySub(mainId, subId, Name, TextBox2.Text.Trim)
        Return Status
    End Function
    Private Function GetPhotos(ByVal subId As String) As String

        'Dim OutStr As String = ""
        'OutStr = GettStuff.DisplayGalleryPhotos("NU#342HJK", subId.Trim)
        'Dim testTextReader As New StringReader(OutStr)
        Dim ds As New DataSet
        ds = GetDisplayGalleryPhotos(subId.Trim)
        'ds.ReadXml(testTextReader, XmlReadMode.Auto)
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
    Private Function SavePhotoUploadGallery(subId As String, Url As String, Name As String) As String
        Dim Status As String = ""
        Status = SaveThisPhotoUploadGallery(subId, Url, Name)
        Return Status
    End Function
#End Region

    Private Function GetDisplayGalleryMain() As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue)
        Dim str As String = ""
        str &= " SELECT * FROM [GalleryMain] WHERE FarmId = @FarmId"

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
    Private Function GetDisplayGallerySub(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue)
        Dim str As String = ""
        str &= " SELECT * FROM GallerySub WHERE (mainId = @mainId) AND (FarmId = @FarmId) "

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
    Private Function GetDisplayGalleryPhotos(ByVal subId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM GalleryPhotos WHERE (subId = @subId) AND (FarmId = @FarmId) "

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
    Public Function SaveThisPhotoUploadGallery(subId As String, Url As String, Name As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Url", Url.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)

        Dim str As String = ""

        str &= " INSERT INTO GalleryPhotos (subId, Url, Name, FarmId) VALUES (@subId, @Url, @Name, @FarmId) "
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
    Public Function SaveMainFolderGallery(mainId As String, Name As String, Beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", Beskrywing.Trim)
        cmd.Parameters.AddWithValue("@UploadedBy", "Gawie")
        cmd.Parameters.AddWithValue("@DateUploaded", Now.Date)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM GalleryMain WHERE  id = @mainId AND FarmId = @FarmId)"
        str &= " BEGIN"
        str &= " UPDATE GalleryMain SET Name = @Name, Description = @Description WHERE  (id = @mainId) AND  (FarmId = @FarmId)"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO GalleryMain (Name, Description, UploadedBy, DateUploaded, FarmId) VALUES (@Name, @Description, @UploadedBy, @DateUploaded, @FarmId) "
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
    Public Function DeleteMainFolderGallery(mainId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM GalleryMain WHERE (id = @mainId)"

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
    Public Function DeleteSubFolderGallery(subId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@subId", subId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM GallerySub WHERE (subId = @subId)"

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
    Public Function SaveGallerySub(mainId As String, subId As String, Name As String, beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", beskrywing.Trim)

        Dim str As String = ""


        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM GallerySub WHERE mainId = @mainId AND FarmId = @FarmId AND Name = @Name)"
        str &= " BEGIN"
        str &= " UPDATE GallerySub SET Name = @Name, Description = @Description WHERE (mainId = @mainId AND FarmId = @FarmId AND Name = @Name)"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO GallerySub (mainId, Name, Description, FarmId) VALUES (@mainId, @Name, @Description, @FarmId) "
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
    Protected Sub cmbFarms_DataBound(sender As Object, e As EventArgs) Handles cmbFarms.DataBound
        PopulateGrid()
    End Sub
    Protected Sub cmbFarms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarms.SelectedIndexChanged
        PopulateGrid()
    End Sub
End Class
