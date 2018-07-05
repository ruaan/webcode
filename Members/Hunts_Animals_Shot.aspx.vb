Imports System.Data
Partial Class Members_Hunts_Animals_Shot
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            lblFarmId.Text = Request.QueryString("h")

            Try
                PopulateAnimals()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub PopulateAnimals()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", lblFarmId.Text)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)
        Dim str As String = ""

        str &= " SELECT        tbl_Hunts_Shot.id, tbl_Hunts_Shot.HuntId, tbl_Hunts_Shot.SpecieId, tbl_Hunts_Shot.MemberId, tbl_Hunts_Shot.Notes, tbl_Animals.id AS Expr1, tbl_Animals.Name"
        str &= " FROM            tbl_Hunts_Shot INNER JOIN"
        str &= "                          tbl_Animals ON tbl_Hunts_Shot.SpecieId = tbl_Animals.id"
        str &= " WHERE        (tbl_Hunts_Shot.HuntId = @HuntId) AND (tbl_Hunts_Shot.MemberId = @MemberId)"


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
            Dim G As String = ex.Message
        Finally
            myconnection.Close()
        End Try

        GridView1.DataSource = ds.Tables(0)
        GridView1.DataBind()

    End Sub

    Protected Sub btnRemoveNo_Click(sender As Object, e As EventArgs) Handles btnRemoveNo.Click
        divConfirm.Visible = False
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
    Private Sub RemoveAnimal(id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", id)



        Dim str As String = ""


        str &= " DELETE FROM tbl_Hunts_Shot"

        str &= "  WHERE   tbl_Hunts_Shot.id = @Id  "



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
        SaveAnimal()
    End Sub
    Private Sub SaveAnimal()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", lblFarmId.Text)
        cmd.Parameters.AddWithValue("@SpecieId", lblAnimalId.Text)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)
        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text)


        Dim str As String = ""


        str &= " INSERT Into"
        str &= " tbl_Hunts_Shot"
        str &= " (HuntId, SpecieId, MemberId, Notes)"
        str &= " VALUES "
        str &= " (@HuntId, @SpecieId, @MemberId, @Notes)"


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
        lblAnimalId.Text = ""
        lblAnimalName.Text = ""
        txtNotes.Text = ""

        divDetail.Visible = False
        divAdd.Visible = False
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

        cmd.Parameters.AddWithValue("@Id", Id)

        Dim str As String = ""

        str &= " SELECT        tbl_Hunts_Shot.id, tbl_Hunts_Shot.HuntId, tbl_Hunts_Shot.SpecieId, tbl_Hunts_Shot.MemberId, tbl_Hunts_Shot.Notes, tbl_Animals.id AS Expr1, tbl_Animals.Name"
        str &= " FROM            tbl_Hunts_Shot INNER JOIN"
        str &= "                          tbl_Animals ON tbl_Hunts_Shot.SpecieId = tbl_Animals.id"
        str &= " WHERE   tbl_Hunts_Shot.id = @Id"



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
            Dim G As String = ex.Message
        Finally
            myconnection.Close()
        End Try


        lblAnimalId.Text = ds.Tables(0).Rows(0).Item("SpecieId").ToString.Trim
        lblAnimalName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
        txtNotes.Text = ds.Tables(0).Rows(0).Item("Notes").ToString.Trim






    End Sub



End Class
