Imports System.IO
Imports System.Data
Partial Class Outfitters_outfitter_Edit_Profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Dim superEntrance As String = ""
            Try
                superEntrance = Request.QueryString("OutId")
            Catch ex As Exception
                superEntrance = ""
            End Try

            If superEntrance <> "" Then
                divAllBlock.Visible = True
                lblFarmId.Text = superEntrance
                lblFarmName.Text = GetOutfitterName()
                If pnlCountries.Visible = True Then
                    pnlCountries.Visible = False
                Else
                    pnlCountries.Visible = True
                    PopulateCountries()
                End If
            Else
                divAllBlock.Visible = True
            End If
        End If
    End Sub
    Private Function GetOutfitterName() As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@id", lblFarmId.Text.Trim)
        Dim Name As String
        Dim str As String = ""
        str &= " SELECT FarmName FROM tbl_Outfitter WHERE (id = @id) "

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
                Name = ds5.Tables(0).Rows(0).Item("FarmName").ToString.Trim
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
    Protected Sub btnDRates_Click(sender As Object, e As EventArgs) Handles btnDRates.Click
        If pnlDRates.Visible = True Then
            pnlDRates.Visible = False
            Image3.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlDRates.Visible = True
            Image3.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnAccRate_Click(sender As Object, e As EventArgs) Handles btnAccRate.Click
        If pnlAccRate.Visible = True Then
            pnlAccRate.Visible = False
            Image10.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlAccRate.Visible = True
            Image10.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        If pnlR.Visible = True Then
            pnlR.Visible = False
            Image4.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlR.Visible = True
            Image4.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnAccGallery_Click(sender As Object, e As EventArgs) Handles btnAccGallery.Click
        If pnlAccGallery.Visible = True Then
            pnlAccGallery.Visible = False
            Image5.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlAccGallery.Visible = True
            Image5.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnDinnerGallery_Click(sender As Object, e As EventArgs) Handles btnDinnerGallery.Click
        If pnlDinner.Visible = True Then
            pnlDinner.Visible = False
            Image7.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlDinner.Visible = True
            Image7.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        If pnlC.Visible = True Then
            pnlC.Visible = False
            Image6.ImageUrl = "~/Images/Icons/numDown1.png"
            pnlLodges.Visible = False
        Else
            pnlC.Visible = True
            Image6.ImageUrl = "~/Images/Icons/numUp1.png"
            pnlLodges.Visible = False
        End If
    End Sub
    Protected Sub cmbCountry_DataBound(sender As Object, e As EventArgs) Handles cmbCountry.DataBound
        cmbCountry.Items.Insert(0, New ListItem("-Select-"))
    End Sub
    Protected Sub ddlLodges_DataBound(sender As Object, e As EventArgs) Handles ddlLodges.DataBound
        ddlLodges.Items.Insert(0, New ListItem("-Select-"))
    End Sub

#Region "Countries were we hunt"
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddCounty(cmbCountry.SelectedValue.Trim)
        PopulateCountries()
    End Sub
    Private Sub AddCounty(CountryId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@CountryId", CountryId.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Outfitter_Countries (OutfitterId, CountryId) VALUES (@Id, @CountryId) "

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
    Private Function GetCountriesData() As DataSet
        Dim dsCount As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@OutfitterId", lblFarmId.Text.Trim)
        Dim str As String = ""

        str &= " SELECT tbl_Outfitter_Countries.OutfitterId, tbl_Outfitter_Countries.CountryId, tblCountries.Name "
        str &= " FROM tbl_Outfitter_Countries INNER JOIN "
        str &= " tblCountries ON tbl_Outfitter_Countries.CountryId = tblCountries.Country_Id "
        str &= " WHERE (tbl_Outfitter_Countries.OutfitterId = @OutfitterId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tbl_Outfitter")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
        dsCount = ds
        Return ds
    End Function
    Private Function GetFarms(ByVal CountryId As String) As DataSet
        Dim dsCount As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", CountryId.Trim)
        Dim str As String = ""

        str &= " SELECT id, FarmName FROM tbl_Outfitter WHERE (Country = @CountryId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tbl_Outfitter")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
        dsCount = ds
        Return ds
    End Function
    Protected Sub gridCountries_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridCountries.RowCommand
        If e.CommandName = "Remove" Then
            RemoveCountry(gridCountries.Rows(e.CommandArgument).Cells(1).Text.Trim)
        ElseIf e.CommandName = "myEdit" Then
            pnlCountry.Visible = True
            lblCountryId.Text = gridCountries.Rows(e.CommandArgument).Cells(1).Text.Trim
            lblCountry.Text = gridCountries.Rows(e.CommandArgument).Cells(2).Text.Trim
            PopulateLodges(gridCountries.Rows(e.CommandArgument).Cells(1).Text.Trim)
            PopulateLodgeGrid()

            pnlLodges.Visible = False
        End If
    End Sub
    Private Sub RemoveCountry(ByVal CountryId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", CountryId.Trim)
        cmd.Parameters.AddWithValue("@OutfitterId", lblFarmId.Text.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_Countries WHERE CountryId = @CountryId AND OutfitterId = @OutfitterId"

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
            PopulateCountries()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub PopulateCountries()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@OutfitterId", lblFarmId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_Countries.OutfitterId, tbl_Outfitter_Countries.CountryId, tblCountries.Name "
        str &= " FROM tbl_Outfitter_Countries INNER JOIN "
        str &= " tblCountries ON tbl_Outfitter_Countries.CountryId = tblCountries.Country_Id "
        str &= " WHERE (tbl_Outfitter_Countries.OutfitterId = @OutfitterId) "


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
            gridCountries.DataSource = ds.Tables(0)
            gridCountries.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    '///Lodges
    Private Sub PopulateLodges(ByVal Country As String)
        Dim ds As New DataSet()

        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@CountryId", Country.Trim)

        Dim str As String = ""
        str &= " SELECT id, FarmName FROM tbl_Farm WHERE (Country = @CountryId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlLodges.DataSource = ds.Tables(0)
            ddlLodges.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AddLodge()
        PopulateLodgeGrid()
    End Sub
    Private Sub AddLodge()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", lblCountryId.Text.Trim)
        cmd.Parameters.AddWithValue("@LodgeId", ddlLodges.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OutfitterId", lblFarmId.Text.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Outfitter_Lodges (CountryId, LodgeId, OutfitterId) VALUES (@CountryId, @LodgeId, @OutfitterId) "

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
    Private Sub PopulateLodgeGrid()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@OutfitterId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@CountryId", lblCountryId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_Lodges.id, tbl_Outfitter_Lodges.CountryId, tblCountries.Name, tbl_Outfitter_Lodges.LodgeId, tbl_Farm.FarmName, tbl_Outfitter_Lodges.OutfitterId "
        str &= " FROM tbl_Outfitter_Lodges INNER JOIN "
        str &= " tblCountries ON tbl_Outfitter_Lodges.CountryId = tblCountries.Country_Id INNER JOIN "
        str &= " tbl_Farm On tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id "
        str &= " WHERE (tbl_Outfitter_Lodges.CountryId = @CountryId) AND (tbl_Outfitter_Lodges.OutfitterId = @OutfitterId) "


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
            gridLodges.DataSource = ds.Tables(0)
            gridLodges.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gridLodges_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridLodges.RowCommand
        If e.CommandName = "Remove" Then
            RemoveLodge(gridLodges.Rows(e.CommandArgument).Cells(1).Text.Trim)
        ElseIf e.CommandName = "myEdit" Then

            lblMainId.Text = ""
            txtMain.Text = ""
            GridView2.DataSource = Nothing
            GridView2.DataBind()
            lblMain1.Text = ""
            txtSubId1.Text = ""
            txtSub1.Text = ""
            pnlSub.Visible = False
            pnlPhotos.Visible = False

            lblMainIdDinner.Text = ""
            txtMainDinner.Text = ""
            gridDinnerSub.DataSource = Nothing
            gridDinnerSub.DataBind()
            lblMain1Dinner.Text = ""
            txtSubId1Dinner.Text = ""
            txtSub1Dinner.Text = ""
            pnlDinnerSub.Visible = False
            pnlDinnerPhoto.Visible = False


            pnlLodges.Visible = True
            lblLodgeId.Text = gridLodges.Rows(e.CommandArgument).Cells(1).Text.Trim
            lblLodgeName.Text = gridLodges.Rows(e.CommandArgument).Cells(4).Text.Trim
            PopulateDailyRateGrid()
            PopulateAnimalRateGrid()
            PopulateAccRateGrid()
            PopulateGrid()
            PopulateGridDinner()
        End If
    End Sub
    Private Sub RemoveLodge(ByVal myId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", myId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_Lodges WHERE id = @id"

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
            PopulateLodgeGrid()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub

    '///Daily Rates
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label2.Text = ""
        Dim validate As Boolean = True
        If txtRateName.Text = "" Then
            validate = False
            Label2.Text &= "Please enter the Rate Name.<br>"
        End If
        If txtRate.Text = "" Then
            validate = False
            Label2.Text &= "Please enter the rate.<br>"
        Else
            If Not IsNumeric(txtRate.Text.Trim) Then
                validate = False
                Label2.Text &= "The Rate must be a numeric value."
            End If
        End If
        If validate = True Then
            AddDailyRate()
            PopulateDailyRateGrid()
            txtRateName.Text = ""
            txtRate.Text = ""
            ddlPerDays.SelectedValue = "1"
        End If
    End Sub
    Private Sub AddDailyRate()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", lblCountryId.Text.Trim)
        cmd.Parameters.AddWithValue("@LodgeId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@RateName", txtRateName.Text.Trim)
        cmd.Parameters.AddWithValue("@Rate", txtRate.Text.Trim)
        cmd.Parameters.AddWithValue("@PerDay", ddlPerDays.SelectedValue.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Outfitter_DailyRates (Outfitter_Lodge_Id, RateName, Rate, PerDay) VALUES (@LodgeId, @RateName, @Rate, @PerDay) "

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
            Label2.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub PopulateDailyRateGrid()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", lblLodgeId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_DailyRates.RateName, tbl_Outfitter_DailyRates.Rate, tbl_Outfitter_DailyRates.PerDay, tbl_Outfitter_DailyRates.id, tbl_Farm.FarmName "
        str &= " FROM tbl_Outfitter_Lodges INNER JOIN "
        str &= " tbl_Outfitter_DailyRates ON tbl_Outfitter_Lodges.id = tbl_Outfitter_DailyRates.Outfitter_Lodge_Id INNER JOIN "
        str &= " tbl_Farm On tbl_Outfitter_Lodges.CountryId = tbl_Farm.id "
        str &= " WHERE (tbl_Outfitter_DailyRates.Outfitter_Lodge_Id = @Outfitter_Lodge_Id) "


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
            Label2.Text &= ex.Message & "<BR>"
        Finally
            myconnection.Close()
        End Try

        Try
            gridDailyRates.DataSource = ds.Tables(0)
            gridDailyRates.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gridDailyRates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridDailyRates.RowCommand
        If e.CommandName = "Remove" Then
            RemoveDailyRate(gridDailyRates.Rows(e.CommandArgument).Cells(0).Text.Trim)
        End If
    End Sub
    Private Sub RemoveDailyRate(ByVal myId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", myId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_DailyRates WHERE id = @id"

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
            PopulateDailyRateGrid()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub

    '//Animal Rates
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label3.Text = ""
        Dim validate As Boolean = True
        If txtRateNameAnimal.Text = "" Then
            validate = False
            Label3.Text &= "Please enter the Rate Name.<br>"
        End If
        If txtRateAnimal.Text = "" Then
            validate = False
            Label3.Text &= "Please enter the rate.<br>"
        Else
            If Not IsNumeric(txtRateAnimal.Text.Trim) Then
                validate = False
                Label3.Text &= "The Rate must be a numeric value."
            End If
        End If
        If validate = True Then
            AddAnimalRate()
            PopulateAnimalRateGrid()
            txtRateNameAnimal.Text = ""
            txtRateAnimal.Text = ""
        End If
    End Sub
    Private Sub AddAnimalRate()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@RateName", txtRateNameAnimal.Text.Trim)
        cmd.Parameters.AddWithValue("@Rate", txtRateAnimal.Text.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Outfitter_AnimalRates (Outfitter_Lodge_Id, RateName, Rate) VALUES (@Outfitter_Lodge_Id, @RateName, @Rate) "

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
            Label3.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub PopulateAnimalRateGrid()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", lblLodgeId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_AnimalRates.id, tbl_Outfitter_AnimalRates.RateName, tbl_Outfitter_AnimalRates.Rate, tbl_Farm.FarmName "
        str &= " FROM tbl_Outfitter_AnimalRates INNER JOIN "
        str &= " tbl_Outfitter_Lodges ON tbl_Outfitter_AnimalRates.Outfitter_Lodge_Id = tbl_Outfitter_Lodges.id INNER JOIN "
        str &= " tbl_Farm On tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id "
        str &= " WHERE (tbl_Outfitter_AnimalRates.Outfitter_Lodge_Id = @Outfitter_Lodge_Id) "

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
            Label3.Text &= ex.Message & "<BR>"
        Finally
            myconnection.Close()
        End Try

        Try
            gridAnimalRates.DataSource = ds.Tables(0)
            gridAnimalRates.DataBind()
        Catch ex As Exception
            Label3.Text &= ex.Message & "<BR>"
        End Try
    End Sub
    Protected Sub gridAnimalRates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridAnimalRates.RowCommand
        If e.CommandName = "Remove" Then
            RemoveAnimalRate(gridAnimalRates.Rows(e.CommandArgument).Cells(0).Text.Trim)
        End If
    End Sub
    Private Sub RemoveAnimalRate(ByVal myId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", myId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_AnimalRates WHERE id = @id"

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
            PopulateAnimalRateGrid()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub

    '//Accommodation Rates
    Protected Sub btnAddAccRate_Click(sender As Object, e As EventArgs) Handles btnAddAccRate.Click
        Label4.Text = ""
        Dim validate As Boolean = True
        If txtRateNameAccRate.Text = "" Then
            validate = False
            Label4.Text &= "Please enter the Rate Name.<br>"
        End If
        If txtRateAccRate.Text = "" Then
            validate = False
            Label4.Text &= "Please enter the rate.<br>"
        Else
            If Not IsNumeric(txtRateAccRate.Text.Trim) Then
                validate = False
                Label4.Text &= "The Rate must be a numeric value."
            End If
        End If
        If validate = True Then
            AddAccRate()
            PopulateAccRateGrid()
            txtRateNameAccRate.Text = ""
            txtRateAccRate.Text = ""
        End If
    End Sub
    Private Sub AddAccRate()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@RateName", txtRateNameAccRate.Text.Trim)
        cmd.Parameters.AddWithValue("@Rate", txtRateAccRate.Text.Trim)
        cmd.Parameters.AddWithValue("@PerDay", ddlPerDayAccRate.SelectedValue.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Outfitter_AccomRates (Outfitter_Lodge_Id, RateName, Rate, PerDay) VALUES (@Outfitter_Lodge_Id, @RateName, @Rate, @PerDay) "

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
            Label4.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub PopulateAccRateGrid()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", lblLodgeId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Outfitter_AccomRates.id, tbl_Outfitter_AccomRates.RateName, tbl_Outfitter_AccomRates.Rate, tbl_Outfitter_AccomRates.PerDay, tbl_Farm.FarmName "
        str &= " FROM tbl_Outfitter_AccomRates INNER JOIN "
        str &= " tbl_Outfitter_Lodges ON tbl_Outfitter_AccomRates.Outfitter_Lodge_Id = tbl_Outfitter_Lodges.id INNER JOIN "
        str &= " tbl_Farm On tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id "
        str &= " WHERE (tbl_Outfitter_AccomRates.Outfitter_Lodge_Id = @Outfitter_Lodge_Id) "

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
            Label4.Text &= ex.Message & "<BR>"
        Finally
            myconnection.Close()
        End Try

        Try
            gridAccRate.DataSource = ds.Tables(0)
            gridAccRate.DataBind()
        Catch ex As Exception
            Label4.Text &= ex.Message & "<BR>"
        End Try
    End Sub
    Protected Sub gridAccRate_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridAccRate.RowCommand
        If e.CommandName = "Remove" Then
            RemoveAccRate(gridAccRate.Rows(e.CommandArgument).Cells(0).Text.Trim)
        End If
    End Sub
    Private Sub RemoveAccRate(ByVal myId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", myId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM tbl_Outfitter_AccomRates WHERE id = @id"

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
            PopulateAccRateGrid()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub

    '///Accommodation Gallery
    Protected Sub btnAddMain_Click(sender As Object, e As EventArgs) Handles btnAddMain.Click
        pnlAddMain.Visible = True
        txtMainName.Text = ""
        txtMainFolderId.Text = "0"
    End Sub
    Protected Sub btnSubmitMain_Click(sender As Object, e As EventArgs) Handles btnSubmitMain.Click
        AddEditMainFolderName()
    End Sub
    Private Sub AddEditMainFolderName()
        SaveMainFolderGallery(txtMainFolderId.Text.Trim, txtMainName.Text.Trim, TextBox1.Text.Trim)
        txtMainName.Text = ""
        txtMainFolderId.Text = ""
        pnlAddMain.Visible = False
        PopulateGrid()
    End Sub
    Public Function SaveMainFolderGallery(mainId As String, Name As String, Beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", Beskrywing.Trim)
        cmd.Parameters.AddWithValue("@UploadedBy", "")
        cmd.Parameters.AddWithValue("@DateUploaded", Now.Date)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " If EXISTS (Select * FROM OutfitterGalleryMain WHERE  id = @mainId And FarmId = @FarmId)"
        str &= " BEGIN"
        str &= " UPDATE OutfitterGalleryMain Set Name = @Name, Description = @Description WHERE  (id = @mainId) And  (FarmId = @FarmId)"
        str &= " End "
        str &= " Else "
        str &= " BEGIN"
        str &= " INSERT INTO OutfitterGalleryMain (Name, Description, UploadedBy, DateUploaded, FarmId) VALUES (@Name, @Description, @UploadedBy, @DateUploaded, @FarmId) "
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
            lblMsg.Text &= ex.Message & "<br>"
            success = ("<Success>False:" & ex.Message & " </Success>")
        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Sub PopulateGrid()
        Dim ds As New DataSet
        ds = GetDisplayGalleryMain()

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception
            lblMsg.Text &= ex.Message
        End Try

    End Sub
    Private Function GetDisplayGalleryMain() As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM [OutfitterGalleryMain] WHERE FarmId = @FarmId"

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
    Public Function DeleteMainFolderGallery(mainId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM OuitfitterGalleryMain WHERE (id = @mainId)"

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

    Protected Sub btnAddSubFolder_Click(sender As Object, e As EventArgs) Handles btnAddSubFolder.Click
        pnlSubFolder.Visible = True
        txtsubId.Text = ""
        txtSub.Text = ""
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

        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", beskrywing.Trim)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM OutfitterGallerySub WHERE mainId = @mainId AND FarmId = @FarmId AND Name = @Name)"
        str &= " BEGIN"
        str &= " UPDATE OutfitterGallerySub SET Name = @Name, Description = @Description WHERE (mainId = @mainId AND FarmId = @FarmId AND Name = @Name)"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO OutfitterGallerySub (mainId, Name, Description, FarmId) VALUES (@mainId, @Name, @Description, @FarmId) "
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
    Private Sub PopulateSubGrid(ByVal mainId As String)
        Dim ds As New DataSet
        ds = GetDisplayGallerySub(mainId)

        Try
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Function GetDisplayGallerySub(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM OutfitterGallerySub WHERE (mainId = @mainId) AND (FarmId = @FarmId) "

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
    Public Function DeleteSubFolderGallery(subId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@subId", subId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM OutfitterGallerySub WHERE (subId = @subId)"

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
        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM OutfitterGalleryPhotos WHERE (subId = @subId) AND (FarmId = @FarmId) "

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

        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Url", Url.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)

        Dim str As String = ""

        str &= " INSERT INTO OutfitterGalleryPhotos (subId, Url, Name, FarmId) VALUES (@subId, @Url, @Name, @FarmId) "
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

    '///Themed Dinner Gallery
    Protected Sub btnAddMainDinner_Click(sender As Object, e As EventArgs) Handles btnAddMainDinner.Click
        pnlAddMainDinner.Visible = True
        txtMainNameDinner.Text = ""
        txtMainFolderIdDinner.Text = "0"
    End Sub
    Protected Sub btnSubmitMainDinner_Click(sender As Object, e As EventArgs) Handles btnSubmitMainDinner.Click
        AddEditMainFolderNameDinner()
    End Sub
    Private Sub AddEditMainFolderNameDinner()
        SaveMainFolderGalleryDinner(txtMainFolderIdDinner.Text.Trim, txtMainNameDinner.Text.Trim, TextBox1Dinner.Text.Trim)
        txtMainNameDinner.Text = ""
        txtMainFolderIdDinner.Text = ""
        pnlAddMainDinner.Visible = False
        PopulateGridDinner()
    End Sub
    Public Function SaveMainFolderGalleryDinner(mainId As String, Name As String, Beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", Beskrywing.Trim)
        cmd.Parameters.AddWithValue("@UploadedBy", "")
        cmd.Parameters.AddWithValue("@DateUploaded", Now.Date)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM OutfitterGalleryDinnerMain WHERE  id = @mainId AND FarmId = @FarmId)"
        str &= " BEGIN"
        str &= " UPDATE OutfitterGalleryDinnerMain SET Name = @Name, Description = @Description WHERE  (id = @mainId) AND  (FarmId = @FarmId)"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO OutfitterGalleryDinnerMain (Name, Description, UploadedBy, DateUploaded, FarmId) VALUES (@Name, @Description, @UploadedBy, @DateUploaded, @FarmId) "
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
            lblMsg.Text &= ex.Message & "<br>"
            success = ("<Success>False:" & ex.Message & " </Success>")
        Finally
            sqlconnection1.Close()
        End Try

        Return success

    End Function
    Private Sub PopulateGridDinner()
        Dim ds As New DataSet
        ds = GetDisplayGalleryMainDinner()

        Try
            gridDinnerMain.DataSource = ds.Tables(0)
            gridDinnerMain.DataBind()
        Catch ex As Exception
            lblMsg.Text &= ex.Message
        End Try

    End Sub
    Private Function GetDisplayGalleryMainDinner() As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM [OutfitterGalleryDinnerMain] WHERE FarmId = @FarmId"

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
    Protected Sub gridDinnerMain_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridDinnerMain.RowCommand
        lblMsg.Text = ""
        If e.CommandName = "ViewLine" Then
            pnlDinnerSub.Visible = True
            pnlDinnerPhoto.Visible = False
            gridDinnerSub.DataSource = Nothing
            gridDinnerSub.DataBind()
            txtSubDinner.Text = ""
            lblMainIdDinner.Text = gridDinnerMain.Rows(e.CommandArgument).Cells(1).Text
            txtMainDinner.Text = gridDinnerMain.Rows(e.CommandArgument).Cells(2).Text
            PopulateSubGridDinner(gridDinnerMain.Rows(e.CommandArgument).Cells(1).Text)
        ElseIf e.CommandName = "EditLine" Then
            pnlAddMainDinner.Visible = True
            txtMainFolderIdDinner.Text = gridDinnerMain.Rows(e.CommandArgument).Cells(1).Text
            txtMainNameDinner.Text = gridDinnerMain.Rows(e.CommandArgument).Cells(2).Text
        ElseIf e.CommandName = "myDelete" Then
            DeleteMainFolderGalleryDinner(gridDinnerMain.Rows(e.CommandArgument).Cells(1).Text)
            PopulateGridDinner()
        End If
    End Sub
    Public Function DeleteMainFolderGalleryDinner(mainId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM OuitfitterGalleryDinnerMain WHERE (id = @mainId)"

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

    Protected Sub btnAddSubFolderDinner_Click(sender As Object, e As EventArgs) Handles btnAddSubFolderDinner.Click
        pnlSubFolderDinner.Visible = True
        txtsubIdDinner.Text = ""
        txtSubDinner.Text = ""
    End Sub
    Protected Sub btnAddDinner_Click(sender As Object, e As EventArgs) Handles btnAddDinner.Click
        Dim validate As Boolean = True
        If txtMainDinner.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the main folder name.<br>"
        End If
        If txtSubDinner.Text = "" Then
            validate = False
            lblMsg.Text &= "Please enter the sub category name.<br>"
        End If
        If validate = True Then
            SaveSubCategoryDinner(lblMainIdDinner.Text.Trim, txtSubDinner.Text.Trim, txtsubIdDinner.Text.Trim)
            PopulateSubGridDinner(lblMainIdDinner.Text.Trim)
            txtSubDinner.Text = ""
            txtsubIdDinner.Text = ""
            pnlSubFolderDinner.Visible = False
        End If
    End Sub
    Private Function SaveSubCategoryDinner(mainId As String, Name As String, subId As String) As String
        Dim Status As String = ""
        SaveGallerySubDinner(mainId, subId, Name, TextBox2Dinner.Text.Trim)
        Return Status
    End Function
    Public Function SaveGallerySubDinner(mainId As String, subId As String, Name As String, beskrywing As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)
        cmd.Parameters.AddWithValue("@Description", beskrywing.Trim)

        Dim str As String = ""

        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM OutfitterGalleryDinnerSub WHERE mainId = @mainId AND FarmId = @FarmId AND Name = @Name)"
        str &= " BEGIN"
        str &= " UPDATE OutfitterGalleryDinnerSub SET Name = @Name, Description = @Description WHERE (mainId = @mainId AND FarmId = @FarmId AND Name = @Name)"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO OutfitterGalleryDinnerSub (mainId, Name, Description, FarmId) VALUES (@mainId, @Name, @Description, @FarmId) "
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
    Private Sub PopulateSubGridDinner(ByVal mainId As String)
        Dim ds As New DataSet
        ds = GetDisplayGallerySubDinner(mainId)

        Try
            gridDinnerSub.DataSource = ds.Tables(0)
            gridDinnerSub.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Function GetDisplayGallerySubDinner(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM OutfitterGalleryDinnerSub WHERE (mainId = @mainId) AND (FarmId = @FarmId) "

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
    Protected Sub gridDinnerSub_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridDinnerSub.RowCommand
        lblMsg.Text = ""
        If e.CommandName = "ViewLine" Then
            pnlDinnerPhoto.Visible = True
            txtPhotoDinner.Text = ""
            lblMain1Dinner.Text = lblMainIdDinner.Text.Trim & " " & txtMainDinner.Text.Trim
            txtSubId1Dinner.Text = gridDinnerSub.Rows(e.CommandArgument).Cells(1).Text
            txtSub1Dinner.Text = gridDinnerSub.Rows(e.CommandArgument).Cells(2).Text
            Try
                PlaceHolder2.Controls.Add(New LiteralControl(GetPhotosDinner(gridDinnerSub.Rows(e.CommandArgument).Cells(1).Text)))
            Catch ex As Exception
            End Try
        ElseIf e.CommandName = "EditLine" Then
            pnlSubFolderDinner.Visible = True
            txtsubIdDinner.Text = gridDinnerSub.Rows(e.CommandArgument).Cells(1).Text
            txtSubDinner.Text = gridDinnerSub.Rows(e.CommandArgument).Cells(2).Text
        ElseIf e.CommandName = "myDelete" Then
            DeleteSubFolderGalleryDinner(gridDinnerSub.Rows(e.CommandArgument).Cells(1).Text)
            PopulateSubGridDinner(lblMainIdDinner.Text.Trim)
        End If
    End Sub
    Public Function DeleteSubFolderGalleryDinner(subId As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@subId", subId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM OutfitterGalleryDinnerSub WHERE (subId = @subId)"

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

    Private Function GetPhotosDinner(ByVal subId As String) As String
        Dim ds As New DataSet
        ds = GetDisplayGalleryPhotosDinner(subId.Trim)
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
                HtmlString &= "             <image  runat='server'  src='Albums/" & txtMainDinner.Text.Trim & "/" & txtSub1Dinner.Text.Trim & "/" & url & "' style='height: 225px; width: 225px'/><br>"
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
    Private Function GetDisplayGalleryPhotosDinner(ByVal subId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM OutfitterGalleryDinnerPhotos WHERE (subId = @subId) AND (FarmId = @FarmId) "

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
    Protected Sub btnUploadDinner_Click(sender As Object, e As EventArgs) Handles btnUploadDinner.Click
        If (FileUpload2.HasFile) Then
            Dim savePath As String = ""
            Dim filename As String = ""
            Dim pathname As String = "Albums\" & txtMainDinner.Text.Trim & "\" & txtSub1Dinner.Text.Trim & "\"
            Dim pathnameRoot As String
            pathnameRoot = Server.MapPath(pathname)
            savePath = pathnameRoot
            If System.IO.Directory.Exists(savePath) Then
            Else
                System.IO.Directory.CreateDirectory(savePath)
            End If
            Try
                filename = FileUpload2.FileName
                savePath += filename
                FileUpload2.SaveAs(savePath)
                SavePhotoUploadGalleryDinner(txtSubId1Dinner.Text.Trim, filename, txtPhotoDinner.Text.Trim)
                txtPhotoDinner.Text = ""
                PlaceHolder2.Controls.Add(New LiteralControl(GetPhotosDinner(txtSubId1Dinner.Text.Trim)))
            Catch ex As Exception
                lblMsg.Text &= ex.Message
            End Try
        End If
    End Sub
    Private Function SavePhotoUploadGalleryDinner(subId As String, Url As String, Name As String) As String
        Dim Status As String = ""
        Status = SaveThisPhotoUploadGalleryDinner(subId, Url, Name)
        Return Status
    End Function
    Public Function SaveThisPhotoUploadGalleryDinner(subId As String, Url As String, Name As String) As String
        Dim success As String

        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblLodgeId.Text.Trim)
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@Url", Url.Trim)
        cmd.Parameters.AddWithValue("@Name", Name.Trim)

        Dim str As String = ""

        str &= " INSERT INTO OutfitterGalleryDinnerPhotos (subId, Url, Name, FarmId) VALUES (@subId, @Url, @Name, @FarmId) "
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
#End Region

End Class
