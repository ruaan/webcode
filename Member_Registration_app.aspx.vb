Imports System.Data
Partial Class Member_Registration_app
    Inherits System.Web.UI.Page

#Region "Initial"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim thisId As String = ""

        Try
            thisId = Request.QueryString("id")
            lblId.Text = thisId
        Catch ex As Exception

        End Try

        If Page.IsPostBack = False Then
            PopulateFireArms()
            PopulatePermits()
            PopulateAlergies()
            PopulateMember()
            FillMembersCertificate()
            FillMembersAssociation()
            FillMemberNextKin()
            FillMembershipFees()
        End If
    End Sub
    Private Sub Member_Registration_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        DisplayProcess()
    End Sub
#End Region

#Region "Initial Populates"
    Private Sub PopulateMember()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = "  SELECT        MemberId, Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, Occupation, Dedicated_Hunter_MemberNo, Dedicated_Sport_ShooterNo, "
        str &= "                           MedicalAidScheme, MedicalAidNo, Main_Member, NextKinName, NextKin_Relationship, NextKin_CellNo, NextKin_Email, Residential_StreetName, Residential_StreetNo, Residential_ComplexName, Residential_ComplexNo, "
        str &= "                           Residential_Suburb, Residential_City_Town, Residential_Province_State, Residential_Code_Zip, Work_StreetName, Work_StreetNo, Work_ComplexName, Work_ComplexNo, Work_Suburb, Work_City_Town, Work_Province_State, "
        str &= "                           Work_Code_Zip, ReferredByNo, DateJoined, MembershipExpire"
        str &= "  FROM            tbl_Member "
        str &= " WHERE (MemberId = @MemberId)"


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
            txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString.Trim
            txtFullNames.Text = ds.Tables(0).Rows(0).Item("FullName").ToString.Trim
            txtPreferredName.Text = ds.Tables(0).Rows(0).Item("PreferredName").ToString.Trim
            txtInitials.Text = ds.Tables(0).Rows(0).Item("Initials").ToString.Trim


            txtIdDoc.Text = ds.Tables(0).Rows(0).Item("IDNo").ToString.Trim
            If txtIdDoc.Text <> "" Then
                txtIdDoc.ReadOnly = True
            Else
                txtIdDoc.ReadOnly = False
            End If
            txtPassport.Text = ds.Tables(0).Rows(0).Item("PassportNr").ToString.Trim
            If txtPassport.Text <> "" Then
                txtPassport.ReadOnly = True
            Else
                txtPassport.ReadOnly = False
            End If
            txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
            txtCell.Text = ds.Tables(0).Rows(0).Item("CellNo").ToString.Trim
            txtWorkTel.Text = ds.Tables(0).Rows(0).Item("WorkNo").ToString.Trim

            rdbGender.SelectedValue = ds.Tables(0).Rows(0).Item("Gender").ToString.Trim



            txtMedicalAidScheme.Text = ds.Tables(0).Rows(0).Item("MedicalAidScheme").ToString.Trim
            txtMedicalAidNo.Text = ds.Tables(0).Rows(0).Item("MedicalAidNo").ToString.Trim
            txtMedicalAidMainMember.Text = ds.Tables(0).Rows(0).Item("Main_Member").ToString.Trim
            txtNextKinName.Text = ds.Tables(0).Rows(0).Item("NextKinName").ToString.Trim
            txtNextKinRelationship.Text = ds.Tables(0).Rows(0).Item("NextKin_Relationship").ToString.Trim
            txtNextKinCell.Text = ds.Tables(0).Rows(0).Item("NextKin_CellNo").ToString.Trim
            txtNextKinEmail.Text = ds.Tables(0).Rows(0).Item("NextKin_Email").ToString.Trim

            txtHomeStreet.Text = ds.Tables(0).Rows(0).Item("Residential_StreetName").ToString.Trim
            txtHomeStreetNo.Text = ds.Tables(0).Rows(0).Item("Residential_StreetNo").ToString.Trim
            txtHomeComplex.Text = ds.Tables(0).Rows(0).Item("Residential_ComplexName").ToString.Trim
            txtComplexNo.Text = ds.Tables(0).Rows(0).Item("Residential_ComplexNo").ToString.Trim
            txtHomeSuburb.Text = ds.Tables(0).Rows(0).Item("Residential_Suburb").ToString.Trim
            txtHomeCity.Text = ds.Tables(0).Rows(0).Item("Residential_City_Town").ToString.Trim
            cmbHomeProvince.SelectedValue = ds.Tables(0).Rows(0).Item("Residential_Province_State").ToString.Trim
            txtHomePostal.Text = ds.Tables(0).Rows(0).Item("Residential_Code_Zip").ToString.Trim


            txtWorkStreet.Text = ds.Tables(0).Rows(0).Item("Work_StreetName").ToString.Trim
            txtworkStreetNo.Text = ds.Tables(0).Rows(0).Item("Work_StreetNo").ToString.Trim
            txtWorkComplex.Text = ds.Tables(0).Rows(0).Item("Work_ComplexName").ToString.Trim
            txtWorkComplexNo.Text = ds.Tables(0).Rows(0).Item("Work_ComplexNo").ToString.Trim
            txtWorkSuburb.Text = ds.Tables(0).Rows(0).Item("Work_Suburb").ToString.Trim
            txtWorkCity.Text = ds.Tables(0).Rows(0).Item("Work_City_Town").ToString.Trim
            cmbWorkProvince.SelectedValue = ds.Tables(0).Rows(0).Item("Work_Province_State").ToString.Trim
            txtWorkPostal.Text = ds.Tables(0).Rows(0).Item("Work_Code_Zip").ToString.Trim

            txtDedicatedHunterNo.Text = ds.Tables(0).Rows(0).Item("Dedicated_Hunter_MemberNo").ToString.Trim
            txtDedicatedSportNo.Text = ds.Tables(0).Rows(0).Item("Dedicated_Sport_ShooterNo").ToString.Trim

            lblUserName.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
            lblMemberId.Text = lblId.Text


            CheckPersonal()
            CheckMedical()
            CheckAddress()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillMembersCertificate()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = "  SELECT MemberId, Certificate_Id, Obtained, CertificateNr"
        str &= "  FROM tbl_Member_Certificates "
        str &= " WHERE (MemberId = @MemberId)"


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


        Dim Count As Integer = GridView4.Rows.Count - 1
        Dim dbCount As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp As Integer
        Dim dbSp As Integer

        Dim selectcheckbox As New CheckBox
        Dim txtCertificateNo As New TextBox
        For sp = 0 To sp
            For dbSp = 0 To dbCount
                If GridView4.Rows(sp).Cells(0).Text.Trim = ds.Tables(0).Rows(dbSp).Item("Certificate_Id").ToString.Trim Then
                    selectcheckbox = GridView4.Rows(sp).FindControl("ChkCertificate")
                    txtCertificateNo = GridView4.Rows(sp).FindControl("txtCertNo")
                    selectcheckbox.Checked = ds.Tables(0).Rows(dbSp).Item("Obtained").ToString.Trim
                    If selectcheckbox.Checked Then
                        txtCertificateNo.Text = ds.Tables(0).Rows(dbSp).Item("CertificateNr").ToString.Trim
                    End If
                End If

            Next
        Next


    End Sub
    Private Sub FillMembersAssociation()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = "  SELECT MemberId, AssociationName, Association_Id, MemberNo"
        str &= "  FROM  tbl_Member_Association "
        str &= " WHERE (MemberId = @MemberId)"


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


        Dim Count As Integer = GridView5.Rows.Count - 1
        Dim dbCount As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp As Integer
        Dim dbSp As Integer

        Dim selectcheckbox As New CheckBox
        Dim txtMemberNo As New TextBox
        For sp = 0 To sp
            For dbSp = 0 To dbCount
                If GridView5.Rows(sp).Cells(0).Text.Trim = ds.Tables(0).Rows(dbSp).Item("Association_Id").ToString.Trim Then
                    selectcheckbox = GridView5.Rows(sp).FindControl("ChkAssociation")
                    txtMemberNo = GridView5.Rows(sp).FindControl("txtAssociationMemberNo")
                    selectcheckbox.Checked = True
                    txtMemberNo.Text = ds.Tables(0).Rows(dbSp).Item("MemberNo").ToString.Trim
                Else
                    selectcheckbox.Checked = False
                    txtMemberNo.Text = ""

                End If

            Next
        Next


    End Sub
    Private Sub FillMemberNextKin()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = "  SELECT id, Name + ' ' + Surname AS Name, Relationship, EmailAddress, MobileNo, AlternativeNo"
        str &= "  FROM tbl_Member_NextKin "
        str &= " WHERE (MemberId = @MemberId)"


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
            grdNextKin.DataSource = ds.Tables(0)
            grdNextKin.DataBind()
            If grdNextKin.Rows.Count > 0 Then
                imgKinCheck.ImageUrl = "~/Images/Icons/correct.png"
            Else
                imgKinCheck.ImageUrl = "~/Images/Icons/warning.png"
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub PopulateFireArms()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = " Select MemberId, Description, SerialNo, LisenceNo, Comment"
        str &= "  FROM tbl_Member_FireArms "
        str &= " WHERE (MemberId = @MemberId)"


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
    Private Sub PopulatePermits()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = " Select MemberId, Permit_Description, Province_State, Permit_No, ExpiryDate"
        str &= "  FROM  tbl_Member_Permits "
        str &= " WHERE (MemberId = @MemberId)"


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
            GridView3.DataSource = ds.Tables(0)
            GridView3.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub PopulateAlergies()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = " Select  MemberId, Allergie, Comment"
        str &= "  FROM   tbl_Member_Allergies "
        str &= " WHERE (MemberId = @MemberId)"


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
    Private Sub FillMembershipFees()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)


        Dim str As String = ""
        str = " Select *"
        str &= "  FROM tblinternalFees "



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


        lblMembershipFee.Text = CDbl(ds.Tables(0).Rows(0).Item("AnualMembershipFee_ZAR").ToString).ToString("###,##0.00")
        lblDue.Text = lblMembershipFee.Text
        lblMembershipPeriod.Text = "Expires " & CDate(DateAdd(DateInterval.Year, 1, Now)).ToString("dd/MM/yyyy")


    End Sub
#End Region

#Region "Common Functions"
    Private Sub DisplayProcess()
        lblProcessAddress.ForeColor = Drawing.ColorTranslator.FromHtml("#a3a3a3")
        lblProcessMed.ForeColor = Drawing.ColorTranslator.FromHtml("#a3a3a3")
        lblProcessNextKin.ForeColor = Drawing.ColorTranslator.FromHtml("#a3a3a3")
        lblProcessHunting.ForeColor = Drawing.ColorTranslator.FromHtml("#a3a3a3")
        lblProcessPersonal.ForeColor = Drawing.ColorTranslator.FromHtml("#a3a3a3")
        lblProcessMembership.ForeColor = Drawing.ColorTranslator.FromHtml("#a3a3a3")

        lblProcessAddress.Font.Bold = False
        lblProcessMed.Font.Bold = False
        lblProcessNextKin.Font.Bold = False
        lblProcessHunting.Font.Bold = False
        lblProcessPersonal.Font.Bold = False
        lblProcessMembership.Font.Bold = False

        If pnlMedical.Visible = True Then
            lblProcessMed.ForeColor = Drawing.ColorTranslator.FromHtml("#BBB530")
            lblProcessMed.Font.Bold = True
        End If
        If pnlNextofKin.Visible = True Then
            lblProcessNextKin.ForeColor = Drawing.ColorTranslator.FromHtml("#BBB530")
            lblProcessNextKin.Font.Bold = True
        End If
        If pnlAddress.Visible = True Then
            lblProcessAddress.ForeColor = Drawing.ColorTranslator.FromHtml("#BBB530")
            lblProcessAddress.Font.Bold = True
        End If
        If pnlHuntingDetails.Visible = True Then
            lblProcessHunting.ForeColor = Drawing.ColorTranslator.FromHtml("#BBB530")
            lblProcessHunting.Font.Bold = True
        End If
        If pnlPersonalDetails.Visible = True Then
            lblProcessPersonal.ForeColor = Drawing.ColorTranslator.FromHtml("#BBB530")
            lblProcessPersonal.Font.Bold = True
        End If
        If pnlMembershipFee.Visible = True Then
            lblProcessMembership.ForeColor = Drawing.ColorTranslator.FromHtml("#BBB530")
            lblProcessMembership.Font.Bold = True
        End If


    End Sub
    Private Sub CloseAll()
        pnlPersonalDetails.Visible = False
        pnlMedical.Visible = False
        pnlNextofKin.Visible = False
        pnlAddress.Visible = False
        pnlHuntingDetails.Visible = False
        pnlMembershipFee.Visible = False
        pnlUserDetails.Visible = False
    End Sub
#End Region

#Region "Process Buttons"
    Protected Sub lblProcessPersonal_Click(sender As Object, e As EventArgs) Handles lblProcessPersonal.Click
        CloseAll()
        pnlPersonalDetails.Visible = True
    End Sub
    Protected Sub lblProcessMed_Click(sender As Object, e As EventArgs) Handles lblProcessMed.Click
        CloseAll()
        pnlMedical.Visible = True
    End Sub
    Protected Sub lblProcessNextKin_Click(sender As Object, e As EventArgs) Handles lblProcessNextKin.Click
        CloseAll()
        pnlNextofKin.Visible = True
    End Sub
    Protected Sub lblProcessAddress_Click(sender As Object, e As EventArgs) Handles lblProcessAddress.Click
        CloseAll()
        pnlAddress.Visible = True
    End Sub
    Protected Sub lblProcessHunting_Click(sender As Object, e As EventArgs) Handles lblProcessHunting.Click
        CloseAll()
        pnlHuntingDetails.Visible = True
    End Sub
    Protected Sub lblProcessMembership_Click(sender As Object, e As EventArgs) Handles lblProcessMembership.Click
        CloseAll()
        pnlMembershipFee.Visible = True
    End Sub
#End Region

#Region "Personal Details"
    Protected Sub btnSavePersonal_Click(sender As Object, e As EventArgs) Handles btnSavePersonal.Click
        UpdatePersonal()
    End Sub
    Protected Sub btnPerNext_Click(sender As Object, e As EventArgs) Handles btnPerNext.Click

        FinalValidate()
        If lblPreSubmit.Text = "" Then
            Insert()
            lblUserName.Text = txtEmail.Text.Trim
            CloseAll()
            pnlUserDetails.Visible = True
        End If


    End Sub
    Protected Sub btnAddAllergies_Click(sender As Object, e As EventArgs) Handles btnAddAllergies.Click
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Allergie", txtAlergies.Text.Trim)
        cmd.Parameters.AddWithValue("@Comment", "")

        Dim str As String = ""
        str = " INSERT  tbl_Member_Allergies"
        str &= "  ( MemberId, Allergie, Comment) "
        str &= " VALUES"
        str &= "  (@MemberId, @Allergie, @Comment) "

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
            PopulateAlergies()
            txtAlergies.Text = ""
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub UpdatePersonal()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@Initials", txtInitials.Text.Trim)
        cmd.Parameters.AddWithValue("@FullName", txtFullNames.Text.Trim)
        cmd.Parameters.AddWithValue("@Title", cmbTitle.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@PreferredName", txtPreferredName.Text.Trim)
        cmd.Parameters.AddWithValue("@IDNo", txtIdDoc.Text.Trim)
        cmd.Parameters.AddWithValue("@Nationality", cmbNationality.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Country", cmbCountry.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Gender", rdbGender.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtCell.Text.Trim)
        cmd.Parameters.AddWithValue("@WorkNo", txtWorkTel.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

        Dim str As String = ""
        str = " UPDATE  tbl_Member"
        str &= " SET Surname = @Surname, FullName = @FullName, Title = @Title, Initials=@Initials, PreferredName = @PreferredName, IDNo = @IDNo, PassportNr = @PassportNr, Nationality = @Nationality, Country = @Country, Gender = @Gender, CellNo = @CellNo, WorkNo = @WorkNo, Email = @Email "
        str &= " WHERE (MemberId = @MemberId) "

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
#End Region

#Region "Medical"
    Protected Sub btnSaveMedical_Click(sender As Object, e As EventArgs) Handles btnSaveMedical.Click
        UpdateMedical()
        CheckMedical()
    End Sub
    Protected Sub btnMedicalPrev_Click(sender As Object, e As EventArgs) Handles btnMedicalPrev.Click
        CloseAll()
        pnlPersonalDetails.Visible = True
    End Sub
    Protected Sub btnMedicalNext_Click(sender As Object, e As EventArgs) Handles btnMedicalNext.Click
        CloseAll()
        pnlNextofKin.Visible = True
    End Sub
    Private Sub UpdateMedical()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@MedicalAidScheme", txtMedicalAidScheme.Text.Trim)
        cmd.Parameters.AddWithValue("@MedicalAidNo", txtMedicalAidNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Main_Member", txtMedicalAidMainMember.Text.Trim)


        Dim str As String = ""
        str = " UPDATE  tbl_Member"
        str &= " SET MedicalAidScheme = @MedicalAidScheme, MedicalAidNo = @MedicalAidNo, Main_Member = @Main_Member "
        str &= " WHERE (MemberId = @MemberId) "

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
#End Region

#Region "Next of Kin"
    Protected Sub btnSaveNextKin_Click(sender As Object, e As EventArgs) Handles btnSaveNextKin.Click
        UpdateNextKin()
    End Sub
    Protected Sub btnNextKinPrevious_Click(sender As Object, e As EventArgs) Handles btnNextKinPrevious.Click
        CloseAll()
        pnlMedical.Visible = True
    End Sub
    Protected Sub btnNextKinNext_Click(sender As Object, e As EventArgs) Handles btnNextKinNext.Click

        CloseAll()
        pnlAddress.Visible = True
    End Sub
    Private Sub UpdateNextKin()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@NextKinName", txtNextKinName.Text.Trim)
        cmd.Parameters.AddWithValue("@NextKin_Relationship", txtNextKinRelationship.Text.Trim)
        cmd.Parameters.AddWithValue("@NextKin_CellNo", txtNextKinCell.Text.Trim)
        cmd.Parameters.AddWithValue("@NextKin_Email", txtNextKinEmail.Text.Trim)

        Dim str As String = ""
        str = " UPDATE  tbl_Member"
        str &= " SET NextKinName = @NextKinName, NextKin_Relationship = @NextKin_Relationship, NextKin_CellNo = @NextKin_CellNo, NextKin_Email = @NextKin_Email "
        str &= " WHERE (MemberId = @MemberId) "

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
    Protected Sub btnAddNextKin_Click(sender As Object, e As EventArgs) Handles btnAddNextKin.Click
        pnlAddNextKin.Visible = True
    End Sub
    Protected Sub btnCancelAddNextKin_Click(sender As Object, e As EventArgs) Handles btnCancelAddNextKin.Click
        pnlAddNextKin.Visible = False
    End Sub
    Protected Sub btnSaveAddNextKin_Click(sender As Object, e As EventArgs) Handles btnSaveAddNextKin.Click
        SaveNextKin()
    End Sub
    Private Sub SaveNextKin()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Name", txtNextKinName.Text.Trim)
        cmd.Parameters.AddWithValue("@Surname", txtNextKinName0.Text.Trim)
        cmd.Parameters.AddWithValue("@Relationship", txtNextKinRelationship.Text.Trim)
        cmd.Parameters.AddWithValue("@EmailAddress", txtNextKinEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@MobileNo", txtNextKinCell.Text.Trim)
        cmd.Parameters.AddWithValue("@AlternativeNo", txtNextKinCell0.Text.Trim)

        Dim str As String = ""
        str = " INSERT INTO tbl_Member_NextKin"
        str &= "  (MemberId, Name, Surname, Relationship, EmailAddress, MobileNo, AlternativeNo) "
        str &= " VALUES"
        str &= "  (@MemberId, @Name, @Surname, @Relationship, @EmailAddress, @MobileNo, @AlternativeNo) "

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
            pnlAddNextKin.Visible = False
            FillMemberNextKin()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub ClearNextKin()
        txtNextKinName.Text = ""
        txtNextKinName0.Text = ""
        txtNextKinRelationship.Text = ""
        txtNextKinEmail.Text = ""
        txtNextKinCell.Text = ""
        txtNextKinCell0.Text = ""
    End Sub

#End Region

#Region "Address"
    Protected Sub btnSaveAddress_Click(sender As Object, e As EventArgs) Handles btnSaveAddress.Click
        UpdateAddress()
        CheckAddress()
    End Sub
    Protected Sub btnAddressPrevious_Click(sender As Object, e As EventArgs) Handles btnAddressPrevious.Click

        CloseAll()
        pnlNextofKin.Visible = True
    End Sub
    Protected Sub btnAddressNext_Click(sender As Object, e As EventArgs) Handles btnAddressNext.Click

        CloseAll()
        pnlHuntingDetails.Visible = True
    End Sub
    Private Sub UpdateAddress()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_StreetName", txtHomeStreet.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_StreetNo", txtHomeStreetNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_ComplexName", txtHomeComplex.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_ComplexNo", txtComplexNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_Suburb", txtHomeSuburb.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_City_Town", txtHomeCity.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_Province_State", cmbHomeProvince.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Residential_Code_Zip", txtHomePostal.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_StreetName", txtWorkStreet.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_StreetNo", txtworkStreetNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_ComplexName", txtWorkComplex.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_ComplexNo", txtWorkComplexNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_Suburb", txtWorkSuburb.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_City_Town", txtWorkCity.Text.Trim)
        cmd.Parameters.AddWithValue("@Work_Province_State", cmbWorkProvince.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Work_Code_Zip", txtWorkPostal.Text.Trim)



        Dim str As String = ""
        str = " UPDATE  tbl_Member"
        str &= " SET Residential_StreetName = @Residential_StreetName, Residential_StreetNo = @Residential_StreetNo, Residential_ComplexName = @Residential_ComplexName, Residential_ComplexNo = @Residential_ComplexNo,  "
        str &= " Residential_Suburb = @Residential_Suburb, Residential_City_Town = @Residential_City_Town, Residential_Province_State = @Residential_Province_State, Residential_Code_Zip = @Residential_Code_Zip, Work_StreetName = @Work_StreetName, "
        str &= " Work_StreetNo = @Work_StreetNo, Work_ComplexName = @Work_ComplexName, Work_ComplexNo = @Work_ComplexNo, Work_Suburb = @Work_Suburb, Work_City_Town = @Work_City_Town, Work_Province_State = @Work_Province_State, Work_Code_Zip = @Work_Code_Zip"
        str &= " WHERE (MemberId = @MemberId) "

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
#End Region

#Region "Hunting Details"
    Protected Sub btnSaveHunting_Click(sender As Object, e As EventArgs) Handles btnSaveHunting.Click
        UpdateHunting()
    End Sub
    Protected Sub btnHuntPrev_Click(sender As Object, e As EventArgs) Handles btnHuntPrev.Click
        UpdateCertificates()
        UpdateAssociations()
        CloseAll()
        pnlAddress.Visible = True
    End Sub
    Protected Sub btnHuntNext_Click(sender As Object, e As EventArgs) Handles btnHuntNext.Click
        UpdateCertificates()
        UpdateAssociations()
        CloseAll()
        pnlMembershipFee.Visible = True
    End Sub
    Private Sub UpdateHunting()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Dedicated_Hunter_MemberNo", txtDedicatedHunterNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Dedicated_Sport_ShooterNo", txtDedicatedSportNo.Text.Trim)



        Dim str As String = ""
        str = " UPDATE  tbl_Member"
        str &= " SET  Dedicated_Hunter_MemberNo = @Dedicated_Hunter_MemberNo, Dedicated_Sport_ShooterNo = @Dedicated_Sport_ShooterNo"
        str &= " WHERE (MemberId = @MemberId) "

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
    Private Sub UpdateCertificates()
        Dim Count As Integer = GridView4.Rows.Count - 1
        Dim sp As Integer
        Dim selectcheckbox As New CheckBox
        Dim txtCertificateNo As New TextBox
        For sp = 0 To Count
            selectcheckbox = GridView4.Rows(sp).FindControl("ChkCertificate")
            txtCertificateNo = GridView4.Rows(sp).FindControl("txtCertNo")
            SaveCertificate(GridView4.Rows(sp).Cells(0).Text.Trim, selectcheckbox.Checked, txtCertificateNo.Text.Trim)
        Next
    End Sub
    Private Sub SaveCertificate(Certificate_Id As String, Obtained As String, CertificateNr As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Certificate_Id", Certificate_Id.Trim)
        cmd.Parameters.AddWithValue("@Obtained", Obtained.Trim)
        cmd.Parameters.AddWithValue("@CertificateNr", CertificateNr.Trim)
        cmd.Parameters.AddWithValue("@Comment", "")


        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Member_Certificates  "
        str &= " WHERE MemberId = @MemberId AND Certificate_Id = @Certificate_Id ) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Member_Certificates"
        str &= " SET Obtained = @Obtained, CertificateNr = @CertificateNr "
        str &= " WHERE  MemberId = @MemberId AND Certificate_Id = @Certificate_Id"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into tbl_Member_Certificates"
        str &= " (MemberId, Certificate_Id, Obtained, CertificateNr, Comment)"
        str &= " VALUES "
        str &= " (@MemberId, @Certificate_Id, @Obtained, @CertificateNr, '')"
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
            pnlAddFireArm.Visible = False
            PopulateFireArms()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub UpdateAssociations()
        Dim Count As Integer = GridView5.Rows.Count - 1
        Dim sp As Integer
        Dim selectcheckbox As New CheckBox
        Dim txtAssociationMemberNo As New TextBox
        For sp = 0 To Count
            selectcheckbox = GridView5.Rows(sp).FindControl("ChkAssociation")
            txtAssociationMemberNo = GridView5.Rows(sp).FindControl("txtAssociationMemberNo")
            If selectcheckbox.Checked Then
                SaveAssociations(GridView5.Rows(sp).Cells(1).Text.Trim, GridView5.Rows(sp).Cells(0).Text.Trim, txtAssociationMemberNo.Text.Trim)
            Else
                RemoveAssociations(GridView5.Rows(sp).Cells(0).Text.Trim)
            End If

        Next
    End Sub
    Private Sub SaveAssociations(AssociationName As String, Association_Id As String, MemberNo As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@AssociationName", AssociationName.Trim)
        cmd.Parameters.AddWithValue("@Association_Id", Association_Id.Trim)
        cmd.Parameters.AddWithValue("@MemberNo", MemberNo.Trim)


        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Member_Association  "
        str &= " WHERE MemberId = @MemberId AND Association_Id = @Association_Id ) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Member_Association"
        str &= " SET MemberNo = @MemberNo "
        str &= " WHERE  MemberId = @MemberId AND Association_Id = @Association_Id"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into tbl_Member_Association"
        str &= " (MemberId, AssociationName, Association_Id, MemberNo)"
        str &= " VALUES "
        str &= " (@MemberId, @AssociationName, @Association_Id, @MemberNo)"
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
            pnlAddFireArm.Visible = False
            PopulateFireArms()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub RemoveAssociations(Association_Id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Association_Id", Association_Id.Trim)



        Dim str As String = ""
        str = " DELETE FROM tbl_Member_Association "
        str &= " WHERE (MemberId = @MemberId) AND (Association_Id = @Association_Id) "


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
            pnlAddFireArm.Visible = False
            PopulateFireArms()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnAddFireArm_Click(sender As Object, e As EventArgs) Handles btnAddFireArm.Click
        pnlAddFireArm.Visible = True
        ClearFirearms()
    End Sub
    Protected Sub btnAddFireArmCancel_Click(sender As Object, e As EventArgs) Handles btnAddFireArmCancel.Click
        pnlAddFireArm.Visible = False
    End Sub
    Protected Sub btnAddFireArmUpdate_Click(sender As Object, e As EventArgs) Handles btnAddFireArmUpdate.Click
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Description", txtFireArmDesc.Text.Trim)
        cmd.Parameters.AddWithValue("@SerialNo", txtFireArmSerial.Text.Trim)
        cmd.Parameters.AddWithValue("@LisenceNo", txtFireArmLisence.Text.Trim)
        cmd.Parameters.AddWithValue("@Comment", "")


        Dim str As String = ""
        str = " INSERT INTO tbl_Member_FireArms "
        str &= " (MemberId, Description, SerialNo, LisenceNo, Comment)"
        str &= " VALUES"
        str &= " (@MemberId, @Description, @SerialNo, @LisenceNo, @Comment)"

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
            ClearFirearms()
            pnlAddFireArm.Visible = False
            PopulateFireArms()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub

    Protected Sub btnAddPermit_Click(sender As Object, e As EventArgs) Handles btnAddPermit.Click
        pnlPermits.Visible = True
        ClearPermit()
    End Sub
    Protected Sub btnAddPermitCancel_Click(sender As Object, e As EventArgs) Handles btnAddPermitCancel.Click
        pnlPermits.Visible = False
        ClearPermit()
    End Sub
    Protected Sub btnAddPermitUpdate_Click(sender As Object, e As EventArgs) Handles btnAddPermitUpdate.Click
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Permit_Description", txtPermitDesc.Text.Trim)
        cmd.Parameters.AddWithValue("@Province_State", txtPermitProvince.Text.Trim)
        cmd.Parameters.AddWithValue("@Permit_No", txtPermitNumber.Text.Trim)
        cmd.Parameters.AddWithValue("@ExpiryDate", txtPermitExp.Text.Trim)

        Dim str As String = ""
        str = " INSERT tbl_Member_Permits"
        str &= "  (MemberId, Permit_Description, Province_State, Permit_No, ExpiryDate) "
        str &= " VALUES"
        str &= "  (@MemberId, @Permit_Description, @Province_State, @Permit_No, @ExpiryDate) "

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
            pnlPermits.Visible = False
            PopulatePermits()
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try


    End Sub
    Private Sub ClearPermit()
        txtPermitExp.Text = ""
        txtPermitDesc.Text = ""
        txtPermitNumber.Text = ""
        txtPermitProvince.Text = ""
    End Sub
    Private Sub ClearFirearms()
        txtFireArmDesc.Text = ""
        txtFireArmSerial.Text = ""
        txtFireArmLisence.Text = ""
    End Sub
    Protected Sub GridView2_DataBound(sender As Object, e As EventArgs) Handles GridView2.DataBound
        If GridView2.Rows.Count > 0 Then
            imgHuntingCheck.ImageUrl = "~/Images/Icons/correct.png"
        Else
            imgHuntingCheck.ImageUrl = "~/Images/Icons/warning.png"
        End If
    End Sub
#End Region

#Region "Membership Fee"
    Protected Sub btnPayNow_Click(sender As Object, e As EventArgs) Handles btnPayNow.Click
        Insert()
        lblUserName.Text = txtEmail.Text.Trim
        CloseAll()
        pnlUserDetails.Visible = True
    End Sub
    Protected Sub btnPayLater_Click(sender As Object, e As EventArgs) Handles btnPayLater.Click
        Insert()
        lblUserName.Text = txtEmail.Text.Trim
        CloseAll()
        pnlUserDetails.Visible = True
        lblLimitedFunction.Text = "Limited functionality untill Membership is paid in full."
    End Sub
    Protected Sub btnMembershipPrev_Click(sender As Object, e As EventArgs) Handles btnMembershipPrev.Click

        CloseAll()

        pnlPersonalDetails.Visible = True
    End Sub

#End Region


    Private Function Insert() As String
        lblsubmitMsg.Text = ""
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@FullName", txtFullNames.Text.Trim)
        cmd.Parameters.AddWithValue("@Initials", txtInitials.Text.Trim)
        cmd.Parameters.AddWithValue("@Title", cmbTitle.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@PreferredName", txtPreferredName.Text.Trim)
        cmd.Parameters.AddWithValue("@IDNo", txtIdDoc.Text.Trim)
        cmd.Parameters.AddWithValue("@PassportNr", txtPassport.Text.Trim)
        cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text.Trim)
        cmd.Parameters.AddWithValue("@Country", cmbCountry.Text.Trim)
        cmd.Parameters.AddWithValue("@Gender", rdbGender.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtCell.Text.Trim)
        cmd.Parameters.AddWithValue("@WorkNo", txtWorkTel.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@ReferredByNo", "")
        cmd.Parameters.AddWithValue("@Status", "2")
        cmd.Parameters.AddWithValue("@DateApplied", Now)

        Dim str As String = ""
        str = " INSERT INTO tbl_Member "
        str &= " (Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, ReferredByNo,  DateJoined)"
        str &= " VALUES"
        str &= " (@Surname, @FullName, @Initials, @Title, @PreferredName, @IDNo, @PassportNr, @Nationality, @Country, @Gender, @CellNo, @WorkNo, @Email, @ReferredByNo,  @DateApplied)"
        str &= " SELECT SCOPE_IDENTITY()"
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
            lblsubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim Pre_Id As String = ds.Tables(0).Rows(0).Item(0).ToString.Trim
        lblMemberId.Text = Pre_Id
        Return Pre_Id
    End Function





#Region "Create User"
    Protected Sub btnCreateUser_Click(sender As Object, e As EventArgs) Handles btnCreateUser.Click
        If txtPassword.Text.Trim <> txtPassword0.Text.Trim Then
            lblUserMsg.Text = "Password does not match"
        Else
            CreateUser()

        End If
    End Sub
    Private Sub CreateUser()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", lblMemberId.Text.Trim)
        cmd.Parameters.AddWithValue("@UserName", lblUserName.Text.Trim)
        cmd.Parameters.AddWithValue("@NickName", txtPreferredName.Text.Trim)
        cmd.Parameters.AddWithValue("@UserType", "Member")
        cmd.Parameters.AddWithValue("@LastLoggedin", Now)


        Dim str As String = ""
        str = " INSERT INTO tbl_Users"
        str &= "  (UserName, UserType, MemberId, LastLoggedin, Active, NickName) "
        str &= " VALUES"
        str &= "  (@UserName, @UserType, @MemberId, @LastLoggedin, 'True', @NickName) "
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
            CreatePassword(ds.Tables(0).Rows(0).Item("SCOPE_IDENTITY").ToString)
        Catch ex As Exception

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
            Response.Redirect("login.aspx")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnUserPrev_Click(sender As Object, e As EventArgs) Handles btnUserPrev.Click
        CloseAll()
        pnlMembershipFee.Visible = True
    End Sub
#End Region

#Region "Validate"


    Private Sub CheckPersonal()
        If txtSurname.Text = "" Or txtEmail.Text = "" Or txtCell.Text = "" Then
            imgPersoCheck.ImageUrl = "~/Images/Icons/warning.png"
        Else
            imgPersoCheck.ImageUrl = "~/Images/Icons/correct.png"
        End If
    End Sub
    Private Sub CheckMedical()
        If txtMedicalAidMainMember.Text.Trim = "" Or txtMedicalAidScheme.Text.Trim = "" Or txtMedicalAidNo.Text.Trim = "" Then
            imgMediCheck.ImageUrl = "~/Images/Icons/warning.png"
        Else
            imgMediCheck.ImageUrl = "~/Images/Icons/correct.png"
        End If

    End Sub
    Private Sub CheckAddress()
        If txtHomeStreet.Text = "" Or txtHomeSuburb.Text = "" Or txtHomePostal.Text = "" Then
            imgAddressCheck.ImageUrl = "~/Images/Icons/warning.png"
        Else
            imgAddressCheck.ImageUrl = "~/Images/Icons/correct.png"
        End If

    End Sub
    Private Function FinalValidate() As String
        lblPreSubmit.Text = ""
        If txtFullNames.Text = "" Then
            lblPreSubmit.Text = "Please enter your Full names"
        End If
        If txtPreferredName.Text = "" Then
            lblPreSubmit.Text &= "</br>Please enter your Preferred name."
        End If
        If txtEmail.Text.Contains("@") = False Then
            lblPreSubmit.Text &= "</br>Please enter a valid Email Address."
        End If

    End Function
#End Region


    Protected Sub lblProcessMembership0_Click(sender As Object, e As EventArgs) Handles lblProcessMembership0.Click
        Response.Redirect("Setup/MemberManager.aspx", True)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FinalValidate()
        If lblsubmitMsg.Text = "" Then
            Insert()
            lblUserName.Text = txtEmail.Text.Trim
            CloseAll()
            pnlUserDetails.Visible = True
        End If
    End Sub
End Class
