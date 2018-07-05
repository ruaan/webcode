Imports System.Data
Imports System.Drawing
Partial Class Outfitters_frmPackagesManager
    Inherits System.Web.UI.Page

#Region "Variants"
    Dim PackageId As String = ""
    Dim myPackageId As String = ""
#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                PackageId = Request.QueryString("PackageId").ToString.Trim
                lblPackageId.Text = Request.QueryString("PackageId").ToString.Trim
                myPackageId = Request.QueryString("PackageId").ToString.Trim
            Catch ex As Exception
                lblPackageId.Text = ""
                myPackageId = ""
            End Try

            If Request.Cookies("UserType").Value.Trim = "Super Admin" Then
                PopulateCompleteFarmList()
            ElseIf Request.Cookies("UserType").Value.Trim = "Farm Super" Then
                PopulateFarmList()
            End If

            PopulateIncluded()
            PopulateExcluded()
            txtFromDate.Text = Now.Date.ToString("yyyy/MM/dd")
            txtToDate.Text = Now.Date.AddMonths(3).ToString("yyyy/MM/dd")
            Try
                PopulatePackage()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub ddlFarms_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFarms.DataBound
        ddlFarms.Items.Insert(0, New ListItem("-Select-"))
    End Sub
    Protected Sub btnAddIncluded_Click(sender As Object, e As EventArgs) Handles btnAddIncluded.Click
        If txtIncluded.Text.Trim <> "" Then
            SaveIncluded()
            PopulateIncluded()
            txtIncluded.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Remove" Then
            RemoveIncluded(GridView1.Rows(e.CommandArgument).Cells(0).Text.Trim)
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtExcluded.Text.Trim <> "" Then
            SaveExcluded()
            PopulateExcluded()
            txtExcluded.Text = ""
        End If
    End Sub
    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "Remove" Then
            RemoveExcluded(GridView2.Rows(e.CommandArgument).Cells(0).Text.Trim)
        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        lblMsg.Text = ""
        Dim validate As Boolean = True
        If ddlFarms.SelectedValue.Trim = "-Select-" Then
            validate = False
            lblMsg.Text &= "Please select the farm.<br>"
        End If
        If txtHeading.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the package heading.<br>"
        End If
        If txtDescription.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the description.<br>"
        End If
        If txtCost.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the cost.<br>"
        End If
        If txtFromDate.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the from date.<br>"
        Else
            Try
                Dim a As Date = CDate(txtFromDate.Text.Trim)
            Catch ex As Exception
                validate = False
                lblMsg.Text &= "The from date is not in a valid format.<br>"
            End Try
        End If
        If txtToDate.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the to date.<br>"
        Else
            Try
                Dim a As Date = CDate(txtToDate.Text.Trim)
            Catch ex As Exception
                validate = False
                lblMsg.Text &= "The to date is not in a valid format.<br>"
            End Try
        End If
        If validate = True Then
            SavePackage()
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulatePackage()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)

        Dim str As String = ""
        str = "  SELECT packageId, Package, farmId, cost, LargeImage, Image1, Image2, Image3, Description, FromDate, ToDate FROM tbl_Outfitter_Packages WHERE (packageId = @packageId) "


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

        Finally
            myconnection.Close()
        End Try

        Try

            txtHeading.Text = ds.Tables(0).Rows(0).Item("Package").ToString.Trim
            ddlFarms.SelectedValue = ds.Tables(0).Rows(0).Item("farmId").ToString.Trim
            txtCost.Text = ds.Tables(0).Rows(0).Item("cost").ToString.Trim
            txtDescription.Text = ds.Tables(0).Rows(0).Item("Description").ToString.Trim
            txtFromDate.Text = CDate(ds.Tables(0).Rows(0).Item("FromDate").ToString.Trim).ToString("yyyy/MM/dd")
            txtToDate.Text = CDate(ds.Tables(0).Rows(0).Item("ToDate").ToString.Trim).ToString("yyyy/MM/dd")
            If ds.Tables(0).Rows(0).Item("LargeImage").ToString.Trim = "" Then
                Image1.ImageUrl = "Images/Packages/TemplateBig.jpg"
            Else
                Image1.ImageUrl = "Images/Packages/" & ds.Tables(0).Rows(0).Item("LargeImage").ToString.Trim
            End If
            If ds.Tables(0).Rows(0).Item("Image1").ToString.Trim = "" Then
                Image2.ImageUrl = "Images/Packages/Template.jpg"
            Else
                Image2.ImageUrl = "Images/Packages/" & ds.Tables(0).Rows(0).Item("Image1").ToString.Trim
            End If
            If ds.Tables(0).Rows(0).Item("Image2").ToString.Trim = "" Then
                Image3.ImageUrl = "Images/Packages/Template.jpg"
            Else
                Image3.ImageUrl = "Images/Packages/" & ds.Tables(0).Rows(0).Item("Image2").ToString.Trim
            End If
            If ds.Tables(0).Rows(0).Item("Image3").ToString.Trim = "" Then
                Image4.ImageUrl = "Images/Packages/Template.jpg"
            Else
                Image4.ImageUrl = "Images/Packages/" & ds.Tables(0).Rows(0).Item("Image3").ToString.Trim
            End If
        Catch ex As Exception
            Image1.ImageUrl = "Images/Packages/TemplateBig.jpg"
            Image2.ImageUrl = "Images/Packages/Template.jpg"
            Image3.ImageUrl = "Images/Packages/Template.jpg"
            Image4.ImageUrl = "Images/Packages/Template.jpg"
        End Try

    End Sub
    Private Sub PopulateFarms()
        Dim ds As New DataSet()
        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_Lodges.id, tbl_Farm.FarmName "
        str &= " FROM tbl_Outfitter_Lodges INNER JOIN "
        str &= " tbl_Farm ON tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id ORDER BY tbl_Farm.FarmName "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlFarms.DataSource = ds.Tables(0)
            ddlFarms.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try

    End Sub
    Private Sub SavePackage()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)
        cmd.Parameters.AddWithValue("@Package", txtHeading.Text.Trim)
        cmd.Parameters.AddWithValue("@farmId", ddlFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@cost", txtCost.Text.Trim)
        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim)
        cmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text.Trim)
        cmd.Parameters.AddWithValue("@ToDate", txtToDate.Text.Trim)

        Dim str As String = ""
        If lblPackageId.Text.Trim <> "" Then
            str &= " UPDATE  tbl_Outfitter_Packages SET Package = @Package, farmId = @farmId, cost = @cost, Description = @Description, FromDate = @FromDate, ToDate = @ToDate WHERE (packageId = @packageId) "
        Else
            str &= " INSERT INTO tbl_Outfitter_Packages (Package, farmId, cost, Description, FromDate, ToDate) VALUES (@Package, @farmId, @cost, @Description, @FromDate, @ToDate) "
            str &= " SELECT SCOPE_IDENTITY()"
        End If

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
            If lblPackageId.Text.Trim = "" Then
                lblPackageId.Text = ds.Tables(0).Rows(0).Item(0).ToString.Trim
            End If
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub SaveIncluded()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        SavePackage()
        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)
        cmd.Parameters.AddWithValue("@Description", txtIncluded.Text.Trim)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM tbl_Outfitter_Package_Included WHERE (packageId = @packageId) AND (Description = @Description)) "
        str &= " BEGIN"
        str &= " UPDATE  tbl_Outfitter_Package_Included SET packageId = @packageId, Description = @Description WHERE (packageId = @packageId) AND (Description = @Description) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO tbl_Outfitter_Package_Included (packageId, Description) "
        str &= " VALUES (@packageId, @Description) "
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

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub PopulateIncluded()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)


        Dim str As String = ""
        str &= " SELECT includedId, Description, packageId FROM tbl_Outfitter_Package_Included WHERE packageId = @packageId "


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

        Finally
            myconnection.Close()
        End Try

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RemoveIncluded(ByVal includedId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@includedId", includedId.Trim)
        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_Package_Included WHERE includedId = @includedId AND packageId = @packageId "

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
            PopulateIncluded()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub SaveExcluded()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        SavePackage()
        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)
        cmd.Parameters.AddWithValue("@Description", txtExcluded.Text.Trim)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM tbl_Outfitter_Package_Excluded WHERE (packageId = @packageId) AND (Description = @Description)) "
        str &= " BEGIN"
        str &= " UPDATE  tbl_Outfitter_Package_Excluded SET packageId = @packageId, Description = @Description WHERE (packageId = @packageId) AND (Description = @Description) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO tbl_Outfitter_Package_Excluded (packageId, Description) "
        str &= " VALUES (@packageId, @Description) "
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

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub PopulateExcluded()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)


        Dim str As String = ""
        str &= " SELECT excludedId, Description, packageId FROM tbl_Outfitter_Package_Excluded WHERE packageId = @packageId "


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

        Finally
            myconnection.Close()
        End Try

        Try
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RemoveExcluded(ByVal excludedId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@excludedId", excludedId.Trim)
        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_Package_Excluded WHERE excludedId = @excludedId AND packageId = @packageId "

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
            PopulateExcluded()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        lblUploadMsg.Text = ""
        If ddlPicType.SelectedValue = "-Select-" Then
            lblUploadMsg.Text &= "Please select the picture type.<br>"
        Else
            Dim SavePath As String = ""
            Dim pathname As String = "Images/Packages/"
            Dim pathnameRoot As String
            pathnameRoot = Server.MapPath(pathname)
            SavePath = pathnameRoot
            If System.IO.Directory.Exists(SavePath) Then
            Else
                System.IO.Directory.CreateDirectory(SavePath)
            End If

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
                        UpdatePicture(fName.Trim)
                    End If
                    If ddlPicType.SelectedValue.Trim = "Large" Then
                        Image1.ImageUrl = "Images/Packages/" & fName.Trim

                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream)
                        Dim height As Integer = img.Height
                        Dim width As Integer = img.Width
                        Dim size As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(5120)), 2)
                        If size > 500 Then
                            lblUploadMsg.Text &= "File size must not exceed 500 KB.<br>"
                        End If
                        If height > 400 OrElse width > 400 Then
                            lblUploadMsg.Text &= "Height and Width must not exceed 400px. The file (" & ddlPicType.SelectedValue.Trim & ") is not going to work on your package profile.<br>"
                        End If

                    ElseIf ddlPicType.SelectedValue.Trim = "Below first" Then
                        Image2.ImageUrl = "Images/Packages/" & fName.Trim

                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream)
                        Dim height As Integer = img.Height
                        Dim width As Integer = img.Width
                        Dim size As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(5120)), 2)
                        If size > 500 Then
                            lblUploadMsg.Text &= "File size must not exceed 500 KB.<br>"
                        End If
                        If height > 200 OrElse width > 200 Then
                            lblUploadMsg.Text &= "Height and Width must not exceed 200px. The file (" & ddlPicType.SelectedValue.Trim & ") is not going to work on your package profile.<br>"
                        End If

                    ElseIf ddlPicType.SelectedValue.Trim = "Below second" Then
                        Image3.ImageUrl = "Images/Packages/" & fName.Trim

                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream)
                        Dim height As Integer = img.Height
                        Dim width As Integer = img.Width
                        Dim size As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(5120)), 2)
                        If size > 500 Then
                            lblUploadMsg.Text &= "File size must not exceed 500 KB.<br>"
                        End If
                        If height > 200 OrElse width > 200 Then
                            lblUploadMsg.Text &= "Height and Width must not exceed 200px. The file (" & ddlPicType.SelectedValue.Trim & ") is not going to work on your package profile.<br>"
                        End If

                    ElseIf ddlPicType.SelectedValue.Trim = "Below third" Then
                        Image4.ImageUrl = "Images/Packages/" & fName.Trim

                        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream)
                        Dim height As Integer = img.Height
                        Dim width As Integer = img.Width
                        Dim size As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(5120)), 2)
                        If size > 500 Then
                            lblUploadMsg.Text &= "File size must not exceed 500 KB.<br>"
                        End If
                        If height > 200 OrElse width > 200 Then
                            lblUploadMsg.Text &= "Height and Width must not exceed 200px. The file (" & ddlPicType.SelectedValue.Trim & ") is not going to work on your package profile.<br>"
                        End If

                    End If
                Catch ex As Exception
                    lblUploadMsg.Text &= ex.Message
                End Try
            End If
        End If
    End Sub
    Private Sub UpdatePicture(ByVal FileName As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        Dim str As String = ""

        cmd.Parameters.AddWithValue("@packageId", lblPackageId.Text.Trim)
        If ddlPicType.SelectedValue.Trim = "Large" Then
            cmd.Parameters.AddWithValue("@LargeImage", FileName.Trim)
            str = " UPDATE tbl_Outfitter_Packages SET LargeImage = @LargeImage WHERE (packageId = @packageId) "
        ElseIf ddlPicType.SelectedValue.Trim = "Below first" Then
            cmd.Parameters.AddWithValue("@Image1", FileName.Trim)
            str = " UPDATE tbl_Outfitter_Packages SET Image1 = @Image1 WHERE (packageId = @packageId) "
        ElseIf ddlPicType.SelectedValue.Trim = "Below second" Then
            cmd.Parameters.AddWithValue("@Image2", FileName.Trim)
            str = " UPDATE tbl_Outfitter_Packages SET Image2 = @Image2 WHERE (packageId = @packageId) "
        ElseIf ddlPicType.SelectedValue.Trim = "Below third" Then
            cmd.Parameters.AddWithValue("@Image3", FileName.Trim)
            str = " UPDATE tbl_Outfitter_Packages SET Image3 = @Image3 WHERE (packageId = @packageId) "
        End If

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
#End Region

#Region "Functions"
    Private Sub PopulateFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)
        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_Lodges.id, tbl_Outfitter_Lodges.LodgeId, tbl_Outfitter_Lodges.OutfitterId, tbl_Farm.FarmName "
        str &= " FROM tbl_Outfitter_Lodges INNER JOIN "
        str &= " tbl_Farm ON tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id INNER JOIN "
        str &= " tbl_Farms_v_User On tbl_Farm.id = tbl_Farms_v_User.FarmId "
        str &= " WHERE (tbl_Farms_v_User.UserId = @UserId) "
        str &= " ORDER BY tbl_Farm.FarmName "
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

        Finally
            myconnection.Close()
        End Try

        Try
            ddlFarms.DataSource = ds.Tables(0)
            ddlFarms.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PopulateCompleteFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)
        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_Lodges.id, tbl_Outfitter_Lodges.LodgeId, tbl_Outfitter_Lodges.OutfitterId, tbl_Farm.FarmName "
        str &= " FROM tbl_Outfitter_Lodges INNER JOIN "
        str &= " tbl_Farm ON tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id "
        str &= " ORDER BY tbl_Farm.FarmName "
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

        Finally
            myconnection.Close()
        End Try

        Try
            ddlFarms.DataSource = ds.Tables(0)
            ddlFarms.DataBind()
        Catch ex As Exception

        End Try

    End Sub
#End Region

End Class
