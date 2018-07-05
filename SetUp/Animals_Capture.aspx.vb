Imports System.Data
Partial Class SetUp_Animals_Capture
    Inherits System.Web.UI.Page

    Protected Sub btnUpdateDescription_Click(sender As Object, e As EventArgs) Handles btnUpdateDescription.Click
        lblUpdateAnimal.Text = ""
        UpdateAnimal()
    End Sub
    Private Sub UpdateAnimal()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", lblAnimalId.Text.Trim)
        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim)
        cmd.Parameters.AddWithValue("@AvgMassMale", txtMaleMass.Text.Trim)
        cmd.Parameters.AddWithValue("@AveHeightMale", txtMaleHeight.Text.Trim)
        cmd.Parameters.AddWithValue("@AveMassFemale", txtFeMaleMass.Text.Trim)
        cmd.Parameters.AddWithValue("@AveHeightFemale", txtFemaleHeight.Text.Trim)

        cmd.Parameters.AddWithValue("@ScientificName", txtScientificName.Text.Trim)
        cmd.Parameters.AddWithValue("@MinimumCalibre", txtMinCalibre.Text.Trim)
        cmd.Parameters.AddWithValue("@RecommendedCalibre", txtRecommendedCalibre.Text.Trim)
        cmd.Parameters.AddWithValue("@NotesOnHunting", txtHuntingNotes.Text.Trim)
        cmd.Parameters.AddWithValue("@ShotPlacements", txtShotplacementNotes.Text.Trim)
        cmd.Parameters.AddWithValue("@Comments", txtInfo.Text.Trim)

        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM   tbl_Animals  "
        str &= " WHERE id = @id) "
        str &= " BEGIN "
        str &= " UPDATE   tbl_Animals"
        str &= " SET Name = @Name, AvgMassMale = @AvgMassMale,AveHeightMale= @AveHeightMale,AveMassFemale= @AveMassFemale,AveHeightFemale= @AveHeightFemale,ScientificName= @ScientificName,MinimumCalibre= @MinimumCalibre,RecommendedCalibre= @RecommendedCalibre,NotesOnHunting= @NotesOnHunting, "
        str &= "               ShotPlacements=  @ShotPlacements, Comments= @Comments"
        str &= " WHERE (id = @id) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= "   tbl_Animals"
        str &= " (Name, AvgMassMale, AveHeightMale, AveMassFemale, AveHeightFemale, ScientificName, MinimumCalibre, RecommendedCalibre, NotesOnHunting, "
        str &= "                 ShotPlacements,  Comments)"
        str &= " VALUES "
        str &= " (@Name, @AvgMassMale, @AveHeightMale, @AveMassFemale, @AveHeightFemale, @ScientificName, @MinimumCalibre, @RecommendedCalibre, @NotesOnHunting, "
        str &= "                 @ShotPlacements,  @Comments)"
        str &= " SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]"
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
            PopulateAnimalList()

        Catch ex As Exception
            lblUpdateAnimal.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            If lblAnimalId.Text = "" Then
                lblAnimalId.Text = ds.Tables(0).Rows(0).Item("SCOPE_IDENTITY").ToString
                divPic.Visible = True
            End If
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        PopulateAnimalList()

        If lblAnimalId.Text = "" Then
            divPic.Visible = False
        Else
            divPic.Visible = True
        End If
    End Sub
    Protected Sub btnUploadProfilePic_Click(sender As Object, e As EventArgs) Handles btnUploadProfilePic.Click
        lblUploadMsg.Text = ""
        If cmbPicType.SelectedValue.Trim = "SELECT" Then
            lblUploadMsg.Text = "Please select the Picture Type you are uploading."
        Else
            UploadPic()
        End If
    End Sub
    Private Sub UploadPic()
        Dim SavePath As String = ""
        Dim pathname As String = "Images\Animals\"
        Dim pathnameRoot As String

        pathnameRoot = Server.MapPath(pathname)
        pathnameRoot = pathnameRoot.Replace("\SetUp", "")
        SavePath = pathnameRoot
        If System.IO.Directory.Exists(SavePath) Then
        Else
            System.IO.Directory.CreateDirectory(SavePath)
        End If

        Dim fileName As String = ""



        If (FileUpload1.HasFile) Then

            If System.IO.Directory.Exists(SavePath) Then
            Else
                System.IO.Directory.CreateDirectory(SavePath)
            End If
            Try
                If (FileUpload1.HasFile) Then

                    fileName = lblAnimalId.Text.Trim & cmbPicType.SelectedValue.Trim & ".jpg"
                    SavePath += fileName
                    FileUpload1.SaveAs(SavePath)
                End If
                imgFront.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
                ImgSide.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
                imgSpoort.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
                imgDung.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
                imgShotSide.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
                imgShotFront.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
                ViewAnimalPic()
            Catch ex As Exception
                lblUploadMsg.Text &= ex.Message
            End Try
        End If
    End Sub
    Protected Sub grdAnimals_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAnimals.RowCommand
        If e.CommandName = "View" Then
            divDetails.Visible = True
            lblAnimalId.Text = grdAnimals.Rows(e.CommandArgument).Cells(0).Text.Trim
            divDetails.Visible = True
            divPic.Visible = True
            PopulateIndAnimal(lblAnimalId.Text.Trim)
            ViewAnimalPic()
        ElseIf e.CommandName = "remove" Then
            divConfirmDelete.Visible = True
            lblDelNote.Text = grdAnimals.Rows(e.CommandArgument).Cells(0).Text.Trim
            If CheckAnimalAtFarms(lblDelNote.Text.Trim) = "false" Then
                divareUsure.Visible = True
                divDenied.Visible = False
            Else
                divareUsure.Visible = False
                divDenied.Visible = True

            End If

        End If
    End Sub
    Private Sub ViewAnimalPic()
        Dim SavePath As String = ""
        Dim pathname As String = "Images\Animals\"
        Dim pathnameRoot As String

        pathnameRoot = Server.MapPath(pathname)
        pathnameRoot = pathnameRoot.Replace("\SetUp", "")
        SavePath = pathnameRoot


        If System.IO.File.Exists(SavePath & "/" & lblAnimalId.Text.Trim & "Front.jpg") Then
            imgFront.ImageUrl = "~/Images/Animals/" & lblAnimalId.Text.Trim & "Front.jpg"
        Else
            imgFront.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & "/" & lblAnimalId.Text.Trim & "Side.jpg") Then
            ImgSide.ImageUrl = "~/Images/Animals/" & lblAnimalId.Text.Trim & "Side.jpg"
        Else
            ImgSide.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & "/" & lblAnimalId.Text.Trim & "Spoor.jpg") Then
            imgSpoort.ImageUrl = "~/Images/Animals/" & lblAnimalId.Text.Trim & "Spoor.jpg"
        Else
            imgSpoort.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & "/" & lblAnimalId.Text.Trim & "Dung.jpg") Then
            imgDung.ImageUrl = "~/Images/Animals/" & lblAnimalId.Text.Trim & "Dung.jpg"
        Else
            imgDung.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & "/" & lblAnimalId.Text.Trim & "ShotSide.jpg") Then
            imgShotSide.ImageUrl = "~/Images/Animals/" & lblAnimalId.Text.Trim & "ShotSide.jpg"
        Else
            imgShotSide.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & "/" & lblAnimalId.Text.Trim & "ShotFront.jpg") Then
            imgShotFront.ImageUrl = "~/Images/Animals/" & lblAnimalId.Text.Trim & "ShotFront.jpg"
        Else
            imgShotFront.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        End If
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        divDetails.Visible = True
        ClearFields()
    End Sub
    Private Sub PopulateIndAnimal(AnimalId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", AnimalId.Trim)

        Dim str As String = ""

        str &= " SELECT Name, AvgMassMale, AveHeightMale, AveMassFemale, AveHeightFemale, ScientificName, MinimumCalibre, RecommendedCalibre, NotesOnHunting, "
        str &= "    ShotPlacements,  Comments"
        str &= " FROM   tbl_Animals  "
        str &= " WHERE (id = @id) "


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
            lblUpdateAnimal.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            txtName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
            txtScientificName.Text = ds.Tables(0).Rows(0).Item("ScientificName").ToString.Trim
            txtInfo.Text = ds.Tables(0).Rows(0).Item("Comments").ToString.Trim
            txtMaleMass.Text = ds.Tables(0).Rows(0).Item("AvgMassMale").ToString.Trim
            txtMaleHeight.Text = ds.Tables(0).Rows(0).Item("AveHeightMale").ToString.Trim
            txtFeMaleMass.Text = ds.Tables(0).Rows(0).Item("AveMassFemale").ToString.Trim
            txtFemaleHeight.Text = ds.Tables(0).Rows(0).Item("AveHeightFemale").ToString.Trim
            txtMinCalibre.Text = ds.Tables(0).Rows(0).Item("MinimumCalibre").ToString.Trim
            txtRecommendedCalibre.Text = ds.Tables(0).Rows(0).Item("RecommendedCalibre").ToString.Trim
            txtHuntingNotes.Text = ds.Tables(0).Rows(0).Item("NotesOnHunting").ToString.Trim
            txtShotplacementNotes.Text = ds.Tables(0).Rows(0).Item("ShotPlacements").ToString.Trim

        Catch ex As Exception
            lblUpdateAnimal.Text &= ex.Message
        End Try


    End Sub
    Private Sub ClearFields()
        lblAnimalId.Text = ""
        txtName.Text = ""
        txtScientificName.Text = ""
        txtInfo.Text = ""
        txtMaleMass.Text = ""
        txtMaleHeight.Text = ""
        txtFemaleHeight.Text = ""
        txtFeMaleMass.Text = ""
        txtMinCalibre.Text = ""
        txtRecommendedCalibre.Text = ""
        txtHuntingNotes.Text = ""
        txtShotplacementNotes.Text = ""


        imgFront.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        ImgSide.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        imgSpoort.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        imgDung.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        imgShotSide.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        imgShotFront.ImageUrl = "~/Images/Animals/animal_PlaceHolder.jpg"
        divPic.Visible = False
    End Sub
    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ClearFields()
        divDetails.Visible = False
    End Sub
    Private Sub RemoveAnimal(AnimalId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", AnimalId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM   tbl_Animals  "
        str &= " WHERE (id = @id) "


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
            PopulateAnimalList()
            divConfirmDelete.Visible = False
        Catch ex As Exception
            lblUpdateAnimal.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Function CheckAnimalAtFarms(AnimalId As String) As String

        grdfarms.DataSource = Nothing
        grdfarms.DataBind()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@AnimalId", AnimalId.Trim)

        Dim str As String = ""

        str &= " SELECT tbl_Farm.FarmName"
        str &= " FROM  tbl_Farm_Animal INNER JOIN"
        str &= "     tbl_Farm ON tbl_Farm_Animal.FarmId = tbl_Farm.id"
        str &= " WHERE  (tbl_Farm_Animal.AnimalId = @AnimalId)"


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
            lblUpdateAnimal.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim hasFarms As String = "false"

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                hasFarms = "True"
                divDenied.Visible = True
                grdfarms.DataSource = ds.Tables(0)
                grdfarms.DataBind()
            End If
        Catch ex As Exception
            lblDelNote.Text = ex.Message
        End Try
        Return hasFarms
    End Function
    Protected Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        divConfirmDelete.Visible = False
    End Sub
    Protected Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        RemoveAnimal(lblDelNote.Text.Trim)
    End Sub
    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        divConfirmDelete.Visible = False
    End Sub
    Protected Sub imgBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnSearch.Click
        PopulateAnimalList()
    End Sub
    Private Sub PopulateAnimalList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Name", txtSearch.Text.Trim & "%")

        Dim str As String = ""

        str &= " SELECT id, Name"
        str &= " FROM tbl_Animals"
        If txtSearch.Text.Trim <> "" Then
            str &= " WHERE (Name LIKE @Name)"
        End If
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
            lblUpdateAnimal.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
        Try
            grdAnimals.DataSource = ds.Tables(0)
            grdAnimals.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
