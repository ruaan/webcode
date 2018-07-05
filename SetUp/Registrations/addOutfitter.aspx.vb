Imports System.Data
Partial Class SetUp_Registrations_addOutfitter
    Inherits System.Web.UI.Page
    Private Sub Registrations_Farm_Registration_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        DisplayProcess()
    End Sub

#Region "Common Functions"
    Private Sub DisplayProcess()

    End Sub
    Private Sub CloseAll()
        pnlAddress.Visible = False
        pnlFarmDetails.Visible = False
        pnlPersonalDetails.Visible = False
    End Sub
#End Region

    Protected Sub btnFarmNext_Click(sender As Object, e As EventArgs) Handles btnFarmNext.Click
        CloseAll()
        pnlPersonalDetails.Visible = True
    End Sub
    Protected Sub btnPerNext_Click(sender As Object, e As EventArgs) Handles btnPerNext.Click
        CloseAll()
        pnlAddress.Visible = True
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
        ValidatePage()

        Dim MemberId As String = ""
        If lblSubmitValidate.Text.Trim = "" Then
            CloseAll()
            MemberId = InsertFarm()
            txtUserName.Text = txtEmail.Text.Trim

            If lblMsg.Text = "" Then

                pnlUserDetails.Visible = True
            End If
        End If
    End Sub
    Private Function InsertFarm() As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmName", txtFarmName.Text.Trim)
        cmd.Parameters.AddWithValue("@Province", cmbProvince.SelectedValue.ToString.Trim)
        cmd.Parameters.AddWithValue("@Country", cmbFarmCountry.SelectedValue.ToString.Trim)
        cmd.Parameters.AddWithValue("@ClosestTown", txtClosestTown.Text.Trim)
        cmd.Parameters.AddWithValue("@GPS_Longitude", "") 'txtLongitude.Text.Trim)
        cmd.Parameters.AddWithValue("@GPS_Latitude", "") 'txtLatitide.Text.Trim)
        cmd.Parameters.AddWithValue("@TelNo", txtFarmTel.Text.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtFarmMobile.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtFarmEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@CompanyName", "") 'txtCompanyName.Text.Trim)
        cmd.Parameters.AddWithValue("@CompanyRegNo", "") 'txtCompRegNr.Text.Trim)
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
        str = " INSERT INTO tbl_Outfitter"
        str &= " (FarmName, Province, Country, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, BookingContactName, BookingContactSurname, "
        str &= " BookingEmail, BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, Owner_Res_StreetName, "
        str &= " Owner_Res_StreetNo, Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status)"
        str &= " VALUES "
        str &= " (@FarmName, @Province, @Country, @ClosestTown, @GPS_Longitude, @GPS_Latitude, '', '', @TelNo, @CellNo, @Email, @CompanyName, @CompanyRegNo, '', '', "
        str &= " '', '', @OwnerName, @OwnerSurname, @OwnerTitle, @OwnerInitials, @OwnerPreferredNAme, @OwnerIdNo, @OwnerGender, @OwnerNationality, @OwnerPassportNo, @OwnerEmail, @Owner_Res_StreetName, "
        str &= " @Owner_Res_StreetNo, @Owner_Res_ComplexName, @Owner_Res_ComplexNo, @Owner_Res_Suburb, @Owner_Res_Province, @Owner_Res_PostalCode, '2')"
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

        Dim FarmId As String = ""
        Try
            FarmId = ds.Tables(0).Rows(0).Item("FarmId").ToString.Trim
            lblFarmId.Text = ds.Tables(0).Rows(0).Item("FarmId").ToString.Trim

        Catch ex As Exception

        End Try
        Return FarmId
    End Function
    Private Sub InsertControl(farmId As Integer)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@farmId", farmId)


        Dim str As String = ""
        str = " INSERT INTO tbl_Farm_Control"
        str &= "  (FarmId, NextHuntGroupId) "
        str &= " VALUES"
        str &= "  (@FarmId, '1') "

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
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

    End Sub

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
        '///Validations requested to be stopped
        'If txtCell.Text = "" Then
        '    lblSubmitValidate.Text &= "</br>* Owner Mobile number is required"
        '    txtCell.BorderColor = Drawing.Color.Red
        'End If
        'If txtEmail.Text = "" Then
        '    lblSubmitValidate.Text &= "</br>* Owner Email is required"
        '    txtEmail.BorderColor = Drawing.Color.Red
        'End If

        'If txtHomeStreet.Text = "" Then
        '    lblSubmitValidate.Text &= "</br>* Home address is required"
        '    txtEmail.BorderColor = Drawing.Color.Red
        'End If

    End Sub
#Region "Mail"
    Private Sub SendApplicationMail(Ref As String)
        Dim Mailer As New MAILER
        Dim thisaddress As New Gets.GetEmailReceivers
        Dim address As String = thisaddress.GetEmialReceivers("Farms Pre Reg")
        Mailer.sendMail("Eco_Hunter", address.Trim, "Eco-Hunter Farm Application", "This is the confirmation mail", True)
    End Sub
#End Region


    Protected Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        lblUserMsg.Text = ""
        If txtPassword.Text.Trim <> txtPassword0.Text.Trim Then
            lblUserMsg.Text = "Password does not match"
        Else
            CreateUser()
            Try
                If Request.Cookies("UserType").Value.Trim = "Super Admin" Then
                    Response.Redirect("../FarmManager.aspx")
                ElseIf Request.Cookies("UserType").Value.Trim = "Outfitter" Then
                    Response.Redirect("../../Outfitters/outfitter_Edit_Profile1.aspx")
                Else
                    Response.Redirect("../../Outfitters/outfitter_Edit_Profile1.aspx")
                End If
            Catch ex As Exception
                Response.Cookies("UserType").Value = "Outfitter"
                Response.Cookies("MemberId").Value = "0"
                Response.Cookies("UserId").Value = HiddenFieldUserId.Value


                Response.Redirect("../../Outfitters/outfitter_Edit_Profile1.aspx")
            End Try


        End If
    End Sub
    Private Sub CreateUser()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblMemberId.Text.Trim)
        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@UserType", "Outfitter")
        cmd.Parameters.AddWithValue("@LastLoggedin", Now)

        Dim str As String = ""
        str = " INSERT INTO tbl_Users"
        str &= "  (UserName, UserType, MemberId, LastLoggedin, Active) "
        str &= " VALUES"
        str &= "  (@UserName, @UserType, @MemberId, @LastLoggedin, 'True') "
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
            HiddenFieldUserId.Value = ds.Tables(0).Rows(0).Item("SCOPE_IDENTITY").ToString
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
            LinkUserToFarm(UserId)
        Catch ex As Exception
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub LinkUserToFarm(UserId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserId", UserId.Trim)
        cmd.Parameters.AddWithValue("@OutfitterId", lblFarmId.Text)
        cmd.Parameters.AddWithValue("@Active", "True")
        cmd.Parameters.AddWithValue("@Type", "Outfitter")



        Dim str As String = ""
        str = " INSERT INTO  tbl_Outfitter_v_User"
        str &= "  (UserId, OutfitterId, Type, Active) "
        str &= " VALUES"
        str &= "  (@UserId, @OutfitterId, @Type, @Active) "

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
            lblUserMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub cmbFarmCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarmCountry.SelectedIndexChanged
        cmbProvince.DataBind()
    End Sub
    Protected Sub cmbFarmCountry_DataBound(sender As Object, e As EventArgs) Handles cmbFarmCountry.DataBound
        If Page.IsPostBack = False Then
            cmbCountry.SelectedValue = "1"
        End If
    End Sub
    Private Sub ConfirmEntries()
        Dim firstPageValidated As Boolean = True
        Dim secondPageValidated As Boolean = True
        Dim thirdPageValidated As Boolean = True

        If txtFarmName.Text = "" Then
            firstPageValidated = False
        End If
        If txtFarmEmail.Text = "" Then
            firstPageValidated = False
        End If
        If txtFarmMobile.Text = "" Then
            firstPageValidated = False
        End If



        If txtCell.Text = "" Then
            secondPageValidated = False
        End If
        If txtEmail.Text = "" Then
            secondPageValidated = False
        End If


        If txtHomeStreet.Text = "" Then
            thirdPageValidated = False
        End If

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ConfirmEntries()
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lblMsg.Text = ""
        lblSubmitValidate.Text = ""
        ValidatePage()

        Dim MemberId As String = ""
        If lblSubmitValidate.Text.Trim = "" Then
            CloseAll()
            MemberId = InsertFarm()
            If lblMsg.Text = "" Then
                pnlUserDetails.Visible = True
            End If
        End If
    End Sub
End Class
