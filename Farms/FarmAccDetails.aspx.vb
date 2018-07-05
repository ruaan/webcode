Imports System.Data
Partial Class Farms_FarmAccDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            PopulateDetails(Request.QueryString("frmid"))
        End If

    End Sub
#Region "Common Functions"
    Private Sub CloseAll()
        pnlAddress.Visible = False
        pnlFarmDetails.Visible = False
        pnlPersonalDetails.Visible = False
    End Sub
#End Region
    Protected Sub btnFarmNext_Click(sender As Object, e As EventArgs) Handles btnFarmNext.Click
        lblFarmDtlMsg.Text = ""
        UpdateFarmDetails()
    End Sub
    Protected Sub btnPerNext_Click(sender As Object, e As EventArgs) Handles btnPerNext.Click
        lblOwnerMsg.Text = ""
        UpdateOwnerDetails()
    End Sub
    Protected Sub btnAddressPrevious_Click(sender As Object, e As EventArgs) Handles btnAddressPrevious.Click
        CloseAll()
        pnlPersonalDetails.Visible = True
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CloseAll()
        pnlFarmDetails.Visible = True
    End Sub
    Protected Sub btnAddressNext_Click(sender As Object, e As EventArgs) Handles btnAddressNext.Click
        lblMsg.Text = ""
        lblSubmitValidate.Text = ""
        UpdateAddress()
    End Sub
    Private Sub UpdateFarmDetails()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@FarmName", txtFarmName.Text.Trim)
        cmd.Parameters.AddWithValue("@Province", cmbProvince.SelectedValue.ToString.Trim)
        cmd.Parameters.AddWithValue("@Country", cmbFarmCountry.SelectedValue.ToString.Trim)
        cmd.Parameters.AddWithValue("@ClosestTown", txtClosestTown.Text.Trim)
        cmd.Parameters.AddWithValue("@GPS_Longitude", txtLongitude.Text.Trim)
        cmd.Parameters.AddWithValue("@GPS_Latitude", txtLatitide.Text.Trim)
        cmd.Parameters.AddWithValue("@TelNo", txtFarmTel.Text.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtFarmMobile.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtFarmEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim)
        cmd.Parameters.AddWithValue("@CompanyRegNo", txtCompRegNr.Text.Trim)


        Dim str As String = ""
        str &= " UPDATE tbl_Farm "
        str &= " SET FarmName = @FarmName, Province = @Province, Country = @Country, ClosestTown = @ClosestTown, GPS_Longitude = @GPS_Longitude, GPS_Latitude = @GPS_Latitude, TelNo = @TelNo, CellNo = @CellNo, Email = @Email, CompanyName = @CompanyName, CompanyRegNo = @CompanyRegNo "
        str &= " WHERE  id = @FarmId"

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
            lblFarmDtlMsg.Text = "Updated"
        Catch ex As Exception
            lblFarmDtlMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub UpdateOwnerDetails()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerName", txtFullNames.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerSurname", txtSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerTitle", cmbTitle.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OwnerInitials", txtInitials.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerPreferredNAme", txtPreferredName.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerIdNo", txtIdDoc.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerGender", rdbGender.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OwnerNationality", cmbNationality.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OwnerPassportNo", txtPassport.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerEmail", txtEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerCell", txtCell.Text.Trim)

        Dim str As String = ""
        str &= " UPDATE tbl_Farm "
        str &= " SET OwnerName = @OwnerName, OwnerSurname = @OwnerSurname, OwnerTitle = @OwnerTitle, OwnerInitials = @OwnerInitials, OwnerPreferredNAme = @OwnerPreferredNAme, OwnerIdNo = @OwnerIdNo, OwnerGender = @OwnerGender, OwnerNationality = @OwnerNationality, OwnerPassportNo = @OwnerPassportNo, OwnerEmail = @OwnerEmail, OwnerCell = @OwnerCell"
        str &= " WHERE  id = @FarmId"

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
            lblOwnerMsg.Text = "Updated"
        Catch ex As Exception
            lblOwnerMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub UpdateAddress()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_StreetName", txtHomeStreet.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_StreetNo", txtHomeStreetNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_ComplexName", txtHomeComplex.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_ComplexNo", txtComplexNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_Suburb", txtHomeSuburb.Text.Trim)

        cmd.Parameters.AddWithValue("@Owner_Res_PostalCode", txtHomePostal.Text.Trim)

        Dim str As String = ""
        str &= " UPDATE tbl_Farm "
        str &= " SET Owner_Res_StreetName = @Owner_Res_StreetName, Owner_Res_StreetNo = @Owner_Res_StreetNo, Owner_Res_ComplexName = @Owner_Res_ComplexName, Owner_Res_ComplexNo = @Owner_Res_ComplexNo, Owner_Res_Suburb = @Owner_Res_Suburb, Owner_Res_PostalCode = @Owner_Res_PostalCode"
        str &= " WHERE  id = @FarmId"

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
            lblSubmitValidate.Text = "Updated"
        Catch ex As Exception
            lblSubmitValidate.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Function InsertFarm() As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmName", txtFarmName.Text.Trim)
        cmd.Parameters.AddWithValue("@Province", cmbProvince.SelectedValue.ToString.Trim)
        cmd.Parameters.AddWithValue("@Country", cmbFarmCountry.SelectedValue.ToString.Trim)
        cmd.Parameters.AddWithValue("@ClosestTown", txtClosestTown.Text.Trim)
        cmd.Parameters.AddWithValue("@GPS_Longitude", txtLongitude.Text.Trim)
        cmd.Parameters.AddWithValue("@GPS_Latitude", txtLatitide.Text.Trim)
        cmd.Parameters.AddWithValue("@TelNo", txtFarmTel.Text.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtFarmMobile.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtFarmEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text.Trim)
        cmd.Parameters.AddWithValue("@CompanyRegNo", txtCompRegNr.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerName", txtFullNames.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerSurname", txtSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerTitle", cmbTitle.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OwnerInitials", txtInitials.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerPreferredNAme", txtPreferredName.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerIdNo", txtIdDoc.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerGender", rdbGender.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OwnerNationality", cmbNationality.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@OwnerPassportNo", txtPassport.Text.Trim)
        cmd.Parameters.AddWithValue("@OwnerEmail", txtEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_StreetName", txtHomeStreet.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_StreetNo", txtHomeStreetNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_ComplexName", txtHomeComplex.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_ComplexNo", txtComplexNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_Suburb", txtHomeSuburb.Text.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_Province", cmbHomeProvince.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Owner_Res_PostalCode", txtHomePostal.Text.Trim)

        Dim str As String = ""
        str = " INSERT INTO tbl_Farm"
        str &= " (FarmName, Province, Country, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, BookingContactName, BookingContactSurname, "
        str &= " BookingEmail, BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, Owner_Res_StreetName, "
        str &= " Owner_Res_StreetNo, Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status)"
        str &= " VALUES "
        str &= " (@FarmName, @Province, @Country, @ClosestTown, @GPS_Longitude, @GPS_Latitude, '', '', @TelNo, @CellNo, @Email, @CompanyName, @CompanyRegNo, '', '', "
        str &= " '', '', @OwnerName, @OwnerSurname, @OwnerTitle, @OwnerInitials, @OwnerPreferredNAme, @OwnerIdNo, @OwnerGender, @OwnerNationality, @OwnerPassportNo, @OwnerEmail, @Owner_Res_StreetName, "
        str &= " @Owner_Res_StreetNo, @Owner_Res_ComplexName, @Owner_Res_ComplexNo, @Owner_Res_Suburb, @Owner_Res_Province, @Owner_Res_PostalCode, '1')"
        str &= " SELECT SCOPE_IDENTITY() AS FarmId"

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
            lblMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim MemberId As String = ""
        Try
            MemberId = ds.Tables(0).Rows(0).Item("FarmId").ToString.Trim
        Catch ex As Exception

        End Try
        Return MemberId
    End Function
    Private Sub ValidatePage()
        If txtFarmName.Text = "" Then
            lblSubmitValidate.Text = "* Farm name is required"
            txtFarmEmail.BorderColor = Drawing.Color.Red
        End If
        If txtFarmEmail.Text = "" Then
            lblSubmitValidate.Text &= "</br>* Farm Email is required"
            txtFarmEmail.BorderColor = Drawing.Color.Red
        End If
        If txtFarmMobile.Text = "" Then
            lblSubmitValidate.Text &= "</br>* Farm Mobile number is required"
            txtFarmMobile.BorderColor = Drawing.Color.Red
        End If
        If txtCell.Text = "" Then
            lblSubmitValidate.Text &= "</br>* Owner Mobile number is required"
            txtCell.BorderColor = Drawing.Color.Red
        End If
        If txtEmail.Text = "" Then
            lblSubmitValidate.Text &= "</br>* Owner Email is required"
            txtEmail.BorderColor = Drawing.Color.Red
        End If
    End Sub
#Region "Mail"
    Private Sub SendApplicationMail(Ref As String)
        Dim Mailer As New MAILER
        Dim thisaddress As New Gets.GetEmailReceivers
        Dim address As String = thisaddress.GetEmialReceivers("Farms Pre Reg")
        Mailer.sendMail("Eco_Hunter", address.Trim, "Eco-Hunter Farm Application", "This is the confirmation mail", True)
    End Sub
#End Region
    Private Sub PopulateDetails(FarmId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@id", FarmId)

        Dim str As String = ""
        str &= "SELECT *  "
        str &= " FROM  tbl_Farm "
        str &= " WHERE id = @id  "
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
            txtFarmName.Text = ds.Tables(0).Rows(0).Item("FarmName").ToString.Trim
            Try
                cmbProvince.SelectedValue = ds.Tables(0).Rows(0).Item("Province").ToString.Trim
            Catch ex As Exception

            End Try
            lblFarmId.Text = FarmId
            cmbFarmCountry.SelectedValue = ds.Tables(0).Rows(0).Item("Country").ToString.Trim
            txtClosestTown.Text = ds.Tables(0).Rows(0).Item("ClosestTown").ToString.Trim
            txtLongitude.Text = ds.Tables(0).Rows(0).Item("GPS_Longitude").ToString.Trim
            txtLatitide.Text = ds.Tables(0).Rows(0).Item("GPS_Latitude").ToString.Trim
            txtFarmTel.Text = ds.Tables(0).Rows(0).Item("TelNo").ToString.Trim
            txtFarmMobile.Text = ds.Tables(0).Rows(0).Item("CellNo").ToString.Trim
            txtFarmEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
            txtCompanyName.Text = ds.Tables(0).Rows(0).Item("CompanyName").ToString.Trim
            txtCompRegNr.Text = ds.Tables(0).Rows(0).Item("CompanyRegNo").ToString.Trim
            txtFullNames.Text = ds.Tables(0).Rows(0).Item("OwnerName").ToString.Trim
            txtSurname.Text = ds.Tables(0).Rows(0).Item("OwnerSurname").ToString.Trim
            cmbTitle.SelectedValue = ds.Tables(0).Rows(0).Item("OwnerTitle").ToString.Trim
            txtInitials.Text = ds.Tables(0).Rows(0).Item("OwnerInitials").ToString.Trim
            txtPreferredName.Text = ds.Tables(0).Rows(0).Item("OwnerPreferredNAme").ToString.Trim
            txtIdDoc.Text = ds.Tables(0).Rows(0).Item("OwnerIdNo").ToString.Trim
            rdbGender.SelectedValue = ds.Tables(0).Rows(0).Item("OwnerGender").ToString.Trim
            cmbNationality.SelectedValue = ds.Tables(0).Rows(0).Item("OwnerNationality").ToString.Trim
            txtPassport.Text = ds.Tables(0).Rows(0).Item("OwnerPassportNo").ToString.Trim
            txtEmail.Text = ds.Tables(0).Rows(0).Item("OwnerEmail").ToString.Trim
            txtHomeStreet.Text = ds.Tables(0).Rows(0).Item("Owner_Res_StreetName").ToString.Trim
            txtHomeStreetNo.Text = ds.Tables(0).Rows(0).Item("Owner_Res_StreetNo").ToString.Trim
            txtHomeComplex.Text = ds.Tables(0).Rows(0).Item("Owner_Res_ComplexName").ToString.Trim
            txtComplexNo.Text = ds.Tables(0).Rows(0).Item("Owner_Res_ComplexNo").ToString.Trim
            txtHomeSuburb.Text = ds.Tables(0).Rows(0).Item("Owner_Res_Suburb").ToString.Trim
            txtCell.Text = ds.Tables(0).Rows(0).Item("OwnerCell").ToString.Trim
            Try
                cmbHomeProvince.SelectedValue = ds.Tables(0).Rows(0).Item("Owner_Res_Province").ToString.Trim
            Catch ex As Exception

            End Try

            txtHomePostal.Text = ds.Tables(0).Rows(0).Item("Owner_Res_PostalCode").ToString.Trim
        Catch ex As Exception

        End Try





    End Sub

End Class
