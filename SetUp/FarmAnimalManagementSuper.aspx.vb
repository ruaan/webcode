Imports System.Data
Partial Class SetUp_FarmAnimalManagementSuper
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        SearchAnimal(txtSearch.Text.Trim)
    End Sub
    Private Sub SearchAnimal(searchString As String)
        grdAnimalSearch.DataSource = Nothing
        grdAnimalSearch.DataBind()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@AnimalString", "%" & searchString & "%")

        Dim str As String = ""

        str &= " SELECT id, Name"
        str &= " FROM tbl_Animals"
        str &= " WHERE (Name LIKE @AnimalString)"


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


        grdAnimalSearch.DataSource = ds.Tables(0)
        grdAnimalSearch.DataBind()


    End Sub
    Protected Sub grdAnimalSearch_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAnimalSearch.RowCommand
        divDetail.Visible = True
        lblAnimalId.Text = grdAnimalSearch.Rows(e.CommandArgument).Cells(1).Text.Trim
        lblAnimalName.Text = grdAnimalSearch.Rows(e.CommandArgument).Cells(2).Text.Trim

        grdAnimalSearch.DataSource = Nothing
        grdAnimalSearch.DataBind()
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearfields()

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblSaveMsg.Text = ""
        If Valudate() = True Then
            SaveAnimal()
        End If

    End Sub
    Private Function Valudate() As Boolean
        Dim valuMsg As String = ""
        Dim isValid As Boolean = True

        If IsNumeric(txtMalePrice.Text) = False Then
            valuMsg = "</br>* Please enter a valid Male Price value. Only numeric no symbols required. "
        End If
        If IsNumeric(txtFemaleProce.Text) = False Then
            valuMsg &= "</br>* Please enter a valid Female Price value. Only numeric no symbols required. "
        End If
        If IsNumeric(txtTrophyPrice.Text) = False Then
            valuMsg &= "</br>* Please enter a valid Trophy Price value. Only numeric no symbols required. "
        End If
        If IsNumeric(txtInches.Text) = False Then
            valuMsg &= "</br>* Please enter a valid Inches value. Only numeric no symbols required. "
        End If

        If valuMsg = "" Then
            isValid = True
        Else
            isValid = False
            lblSaveMsg.Text = valuMsg
        End If

        Return isValid

    End Function
    Private Sub SaveAnimal()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@AnimalId", lblAnimalId.Text)
        cmd.Parameters.AddWithValue("@AvailableToHunt", chkAvailHunt.Checked)
        cmd.Parameters.AddWithValue("@Male_Price", CDbl(txtMalePrice.Text))
        cmd.Parameters.AddWithValue("@Female_Price", CDbl(txtFemaleProce.Text))
        cmd.Parameters.AddWithValue("@Trophy_Price", CDbl(txtTrophyPrice.Text))
        cmd.Parameters.AddWithValue("@Inches", CDbl(txtInches.Text))
        cmd.Parameters.AddWithValue("@Visiting_Country", cmbCountry.SelectedValue)
        cmd.Parameters.AddWithValue("@Active", "True")


        Dim str As String = ""

        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Farm_Animal  "
        str &= " WHERE FarmId = @FarmId AND AnimalId = @AnimalId   AND Visiting_Country = @Visiting_Country ) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Farm_Animal"
        str &= " SET  AvailableToHunt = @AvailableToHunt, Male_Price = @Male_Price, Female_Price = @Female_Price, Trophy_Price = @Trophy_Price, Inches = @Inches, Active = @Active "
        str &= " WHERE  FarmId = @FarmId AND AnimalId = @AnimalId  AND Visiting_Country = @Visiting_Country "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= " tbl_Farm_Animal"
        str &= " (FarmId, AnimalId, AvailableToHunt, Male_Price, Female_Price, Trophy_Price, Inches, Visiting_Country, Active)"
        str &= " VALUES "
        str &= " (@FarmId, @AnimalId, @AvailableToHunt, @Male_Price, @Female_Price, @Trophy_Price, @Inches, @Visiting_Country, @Active)"
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
            clearfields()
            PopulateAnimals()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub clearfields()
        lblSaveMsg.Text = ""
        lblAnimalId.Text = ""
        lblAnimalName.Text = ""
        txtMalePrice.Text = ""
        txtFemaleProce.Text = ""
        txtInches.Text = ""
        txtTrophyPrice.Text = ""
        divDetail.Visible = False
        divAdd.Visible = False
    End Sub
    Private Sub PopulateAnimals()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Visiting_Country", cmbCountry.SelectedValue)
        Dim str As String = ""

        str &= " SELECT        tbl_Farm_Animal.id, tbl_Farm_Animal.FarmId, tbl_Farm_Animal.AnimalId, tbl_Farm_Animal.AvailableToHunt, tbl_Farm_Animal.Male_Price, tbl_Farm_Animal.Female_Price, tbl_Farm_Animal.Trophy_Price, "
        str &= "                          tbl_Farm_Animal.Inches, tbl_Animals.Name"
        str &= " FROM            tbl_Farm_Animal INNER JOIN"
        str &= "                          tbl_Animals ON tbl_Farm_Animal.AnimalId = tbl_Animals.id"
        str &= " WHERE        (tbl_Farm_Animal.FarmId = @FarmId) AND (Active = 'True') AND (Visiting_Country = @Visiting_Country)"
        str &= " ORDER BY tbl_Animals.Name"


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

        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            Try
                PopulateFarmList()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub PopulateFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@farmid", Request.QueryString("id"))
        Dim str As String = ""
        str &= " SELECT        tbl_Farm.FarmName, tbl_Farm.id "
        str &= " FROM          tbl_Farm "
        str &= " WHERE        (id = @farmid) "
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
            cmbFarms.DataSource = ds.Tables(0)
            cmbFarms.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            divAdd.Visible = True
            divDetail.Visible = True
            PopulateIndividualAnimal(GridView1.Rows(e.CommandArgument).Cells(0).Text.Trim)
        Else
            divConfirm.Visible = True
            lblRemoveId.Text = GridView1.Rows(e.CommandArgument).Cells(0).Text.Trim
        End If
    End Sub
    Private Sub PopulateIndividualAnimal(Id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@animalId", Id)

        Dim str As String = ""

        str &= " SELECT        tbl_Farm_Animal.id, tbl_Farm_Animal.FarmId, tbl_Farm_Animal.AnimalId, tbl_Farm_Animal.AvailableToHunt, tbl_Farm_Animal.Male_Price, tbl_Farm_Animal.Female_Price, tbl_Farm_Animal.Trophy_Price, "
        str &= "                          tbl_Farm_Animal.Inches, tbl_Animals.Name"
        str &= " FROM            tbl_Farm_Animal INNER JOIN"
        str &= "                          tbl_Animals ON tbl_Farm_Animal.AnimalId = tbl_Animals.id"
        str &= " WHERE        (tbl_Farm_Animal.id = @animalId)"



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


        lblAnimalId.Text = ds.Tables(0).Rows(0).Item("AnimalId").ToString.Trim
        lblAnimalName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
        chkAvailHunt.Checked = ds.Tables(0).Rows(0).Item("AvailableToHunt").ToString.Trim
        txtMalePrice.Text = ds.Tables(0).Rows(0).Item("Male_Price").ToString.Trim
        txtFemaleProce.Text = ds.Tables(0).Rows(0).Item("Female_Price").ToString.Trim
        txtTrophyPrice.Text = ds.Tables(0).Rows(0).Item("Trophy_Price").ToString.Trim
        txtInches.Text = ds.Tables(0).Rows(0).Item("Inches").ToString.Trim





    End Sub
    Protected Sub cmbCountry_DataBound(sender As Object, e As EventArgs) Handles cmbCountry.DataBound
        PopulateAnimals()
    End Sub
    Protected Sub btnRemoveNo_Click(sender As Object, e As EventArgs) Handles btnRemoveNo.Click
        divConfirm.Visible = False
    End Sub
    Private Sub RemoveAnimal(id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", id)
        cmd.Parameters.AddWithValue("@Active", "False")


        Dim str As String = ""


        str &= " UPDATE tbl_Farm_Animal"
        str &= " SET  Active = @Active "
        str &= " WHERE  Id = @Id  "



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
            divConfirm.Visible = False
            PopulateAnimals()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnRemoveYes_Click(sender As Object, e As EventArgs) Handles btnRemoveYes.Click
        RemoveAnimal(lblRemoveId.Text.Trim)
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If divAdd.Visible = False Then
            divAdd.Visible = True
        Else
            divAdd.Visible = False
        End If

    End Sub
    Protected Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
        PopulateAnimals()
    End Sub
    Protected Sub cmbFarms_DataBound(sender As Object, e As EventArgs) Handles cmbFarms.DataBound
        cmbFarms.Items.Add("Select")
        cmbFarms.SelectedValue = "Select"
    End Sub
    Protected Sub cmbFarms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarms.SelectedIndexChanged
        PopulateAnimals()
    End Sub
End Class
