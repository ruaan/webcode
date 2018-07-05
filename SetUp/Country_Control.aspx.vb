Imports System.Data
Partial Class SetUp_Country_Control
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        PopulateCountries()



    End Sub
    Private Sub PopulateCountries()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Name", txtSearch.Text.Trim & "%")

        Dim str As String = ""

        str &= " SELECT Country_Id, Name"
        str &= " FROM tblCountries"
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
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
        Try
            grdCountries.DataSource = ds.Tables(0)
            grdCountries.DataBind()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        divDetails.Visible = True
        ClearFields()
    End Sub
    Private Sub ClearFields()
        lblCountryId.Text = ""
        txtName.Text = ""
        txtCurrencyCode.Text = ""
        txtCurencySymbol.Text = ""

    End Sub
    Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ClearFields()
        divDetails.Visible = False
    End Sub
    Protected Sub grdCountries_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdCountries.RowCommand
        divDetails.Visible = False
        divConfirmDelete.Visible = False
        If e.CommandName = "View" Then
            divDetails.Visible = True
            lblCountryId.Text = grdCountries.Rows(e.CommandArgument).Cells(0).Text.Trim


            PopulateIndCountry(lblCountryId.Text.Trim)
            PopulateCountryProvinces()
        ElseIf e.CommandName = "remove" Then
            divConfirmDelete.Visible = True
            divProvinceLinkedDenied.Visible = False
            divDenied.Visible = False
            lblDelNote.Text = grdCountries.Rows(e.CommandArgument).Cells(0).Text.Trim
            If CheckifFarmLinkedToCountry(lblDelNote.Text.Trim) = "false" Then
                If CheckProvincesLinked(lblDelNote.Text.Trim) = "false" Then
                    divareUsure.Visible = True
                    divDenied.Visible = False
                Else
                    divareUsure.Visible = False
                    divProvinceLinkedDenied.Visible = True
                End If
            Else
                divareUsure.Visible = False
                divDenied.Visible = True
            End If
        End If
    End Sub
    Private Sub PopulateIndCountry(CountryId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", CountryId.Trim)

        Dim str As String = ""

        str &= " SELECT Country_Id, Name, CurrencyCode, CurrencySymbol, Active"
        str &= " FROM   tblCountries  "
        str &= " WHERE (Country_Id = @id) "


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
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            txtName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
            txtCurencySymbol.Text = ds.Tables(0).Rows(0).Item("CurrencySymbol").ToString.Trim
            txtCurrencyCode.Text = ds.Tables(0).Rows(0).Item("CurrencyCode").ToString.Trim


        Catch ex As Exception
            lblUpdateCountry.Text &= ex.Message
        End Try


    End Sub
    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        divConfirmDelete.Visible = False
    End Sub
    Private Sub PopulateCountryProvinces()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", lblCountryId.Text.Trim)

        Dim str As String = ""

        str &= " SELECT ProvinceId, CountryId, Name, IconPath, Active"
        str &= " FROM            tblProvince"
        str &= " where CountryId = @id"
        str &= " Order By Name"


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
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            grdProvinces.DataSource = ds.Tables(0)
            grdProvinces.DataBind()

        Catch ex As Exception
            lblUpdateCountry.Text &= ex.Message
        End Try


    End Sub
    Protected Sub btnAddProvince_Click(sender As Object, e As EventArgs) Handles btnAddProvince.Click
        addProvince.Visible = True
        txtProvinceNameAdd.Text = ""
        lblProvinceId.Text = ""
    End Sub
    Protected Sub btnProvinceCancel_Click(sender As Object, e As EventArgs) Handles btnProvinceCancel.Click
        txtProvinceNameAdd.Text = ""
        lblProvinceId.Text = ""
        addProvince.Visible = False

    End Sub
    Protected Sub grdProvinces_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdProvinces.RowCommand
        If e.CommandName = "View" Then
            addProvince.Visible = True
            lblProvinceId.Text = grdProvinces.Rows(e.CommandArgument).Cells(0).Text.Trim
            txtProvinceNameAdd.Text = grdProvinces.Rows(e.CommandArgument).Cells(1).Text.Trim
        ElseIf e.CommandName = "remove" Then
            divprovinceRemoveConfirm.Visible = True
            lblProvinceDelId.Text = grdProvinces.Rows(e.CommandArgument).Cells(0).Text.Trim
            If CheckifFarmLinkedToProvince(lblProvinceDelId.Text.Trim) = "false" Then
                divareUsureProvince.Visible = True
                divDeniedProvince.Visible = False
            Else
                divareUsureProvince.Visible = False
                divDeniedProvince.Visible = True

            End If


        End If
    End Sub
    Protected Sub btnSaveProvince_Click(sender As Object, e As EventArgs) Handles btnSaveProvince.Click
        lblProvineUpdate.Text = ""
        UpdateProvince()
    End Sub
    Private Sub UpdateProvince()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@ProvinceId", lblProvinceId.Text.Trim)
        cmd.Parameters.AddWithValue("@Name", txtProvinceNameAdd.Text.Trim)
        cmd.Parameters.AddWithValue("@CountryId", lblCountryId.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", "True")


        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM   tblProvince  "
        str &= " WHERE ProvinceId = @ProvinceId) "
        str &= " BEGIN "
        str &= " UPDATE   tblProvince"
        str &= " SET Name = @Name"
        str &= " WHERE (ProvinceId = @ProvinceId) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= "   tblProvince"
        str &= " (CountryId, Name, Active)"
        str &= " VALUES "
        str &= " (@CountryId, @Name, @Active)"
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
            PopulateCountryProvinces()
            txtProvinceNameAdd.Text = ""
            lblProvinceId.Text = ""
            addProvince.Visible = False
        Catch ex As Exception
            lblProvineUpdate.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnUpdateDescription_Click(sender As Object, e As EventArgs) Handles btnUpdateDescription.Click
        UpdateCountry()
    End Sub
    Private Sub UpdateCountry()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim)
        cmd.Parameters.AddWithValue("@Country_Id", lblCountryId.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", "True")
        cmd.Parameters.AddWithValue("@CurrencyCode", txtCurrencyCode.Text.Trim)
        cmd.Parameters.AddWithValue("@CurrencySymbol", txtCurencySymbol.Text.Trim)

        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM   tblCountries  "
        str &= " WHERE Country_Id = @Country_Id) "
        str &= " BEGIN "
        str &= " UPDATE   tblCountries"
        str &= " SET Name = @Name, CurrencyCode = @CurrencyCode, CurrencySymbol = @CurrencySymbol "
        str &= " WHERE (Country_Id = @Country_Id) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= "   tblCountries"
        str &= " (Name, CurrencyCode, CurrencySymbol, Active)"
        str &= " VALUES "
        str &= " (@Name, @CurrencyCode, @CurrencySymbol, @Active)"
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
            If lblCountryId.Text = "" Then
                lblCountryId.Text = ds.Tables(0).Rows(0).Item(0).ToString.Trim
                PopulateCountryProvinces()
            End If

            If lblUpdateCountry.Text = "" Then
                lblUpdateCountry.Text = "Updated"
            End If
            PopulateCountries()
        Catch ex As Exception
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub

    Private Function CheckifFarmLinkedToProvince(ProvinceId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@ProvinceId", ProvinceId.Trim)

        Dim str As String = ""

        str &= " SELECT id, FarmName"
        str &= " FROM tbl_Farm"
        str &= " where Province  = @ProvinceId"
        str &= " Order By FarmName"


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
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try




        Dim hasFarms As String = "false"

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                hasFarms = "True"
                divDenied.Visible = True
                grdProvinceFarms.DataSource = ds.Tables(0)
                grdProvinceFarms.DataBind()
            End If
        Catch ex As Exception
            lblProvinceDelId.Text = ex.Message
        End Try
        Return hasFarms



    End Function
    Private Function CheckifFarmLinkedToCountry(CountryId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Country", CountryId.Trim)

        Dim str As String = ""

        str &= " SELECT id, FarmName"
        str &= " FROM tbl_Farm"
        str &= " where   (Country = @Country)"
        str &= " Order By FarmName"


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
            lblUpdateCountry.Text &= ex.Message
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
        RemoveCountry(lblDelNote.Text)
    End Sub
    Private Sub RemoveCountry(CountryId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", CountryId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM   tblCountries  "
        str &= " WHERE (Country_Id = @id) "


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
            divConfirmDelete.Visible = False
        Catch ex As Exception
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        divprovinceRemoveConfirm.Visible = False
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        divprovinceRemoveConfirm.Visible = False
    End Sub

    Private Sub RemoveProvince(ProvinceId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", ProvinceId.Trim)

        Dim str As String = ""

        str &= " DELETE FROM   tblProvince  "
        str &= " WHERE (ProvinceId = @id) "


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
            PopulateCountryProvinces()
            divprovinceRemoveConfirm.Visible = False
        Catch ex As Exception
            lblProvineUpdate.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RemoveProvince(lblProvinceDelId.Text.Trim)
    End Sub
    Private Function CheckProvincesLinked(CountryId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", CountryId.Trim)

        Dim str As String = ""

        str &= " SELECT ProvinceId, Name"
        str &= " FROM tblProvince"
        str &= " where CountryId  = @CountryId"
        str &= " Order By Name"


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
            lblUpdateCountry.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try




        Dim hasFarms As String = "false"

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                hasFarms = "True"

            End If
        Catch ex As Exception
            lblProvinceDelId.Text = ex.Message
        End Try
        Return hasFarms
    End Function
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        divConfirmDelete.Visible = False
    End Sub
End Class
