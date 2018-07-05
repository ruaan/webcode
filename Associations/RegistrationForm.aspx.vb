Imports System.Data
Partial Class Associations_RegistrationForm
    Inherits System.Web.UI.Page

#Region "Variants"
    Dim AssociationId As String
#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            AssociationId = Request.QueryString("AssId").ToString.Trim
            lblHeader.Text = GetAssociationName(Request.QueryString("AssId").ToString.Trim)
        Catch ex As Exception
            AssociationId = ""
        End Try
        If IsPostBack = False Then
            Try
                PopulateMember()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        lblMsg.Text = ""
        UpdateAssociationRegistration()
        SaveMember()
        If lblMsg.Text = "" Then
            SendEmail()
            lblMsg.Text = "Thank you your application is being processed."
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateMember()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT * FROM tbl_Member WHERE (MemberId = '" & Request.Cookies("memberid").Value & "')"

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

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                txtSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString.Trim
                txtName.Text = ds.Tables(0).Rows(0).Item("FullName").ToString.Trim
                txtCellphone.Text = ds.Tables(0).Rows(0).Item("CellNo").ToString.Trim
                txtIdNo.Text = ds.Tables(0).Rows(0).Item("IDNo").ToString.Trim
                txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim

                rdbSpouseSex.SelectedValue = ds.Tables(0).Rows(0).Item("SpouseSex").ToString.Trim
                txtSpouseSurname.Text = ds.Tables(0).Rows(0).Item("SpouseSurname").ToString.Trim
                txtSpouseName.Text = ds.Tables(0).Rows(0).Item("SpouseName").ToString.Trim
                txtSpouseCell.Text = ds.Tables(0).Rows(0).Item("SpouseCell").ToString.Trim
                txtSpouseIdNo.Text = ds.Tables(0).Rows(0).Item("SpouseIdNo").ToString.Trim
                txtSpouseOccupation.Text = ds.Tables(0).Rows(0).Item("SpouseOccupation").ToString.Trim

                txtSurname1.Text = ds.Tables(0).Rows(0).Item("Surname1").ToString.Trim
                txtName1.Text = ds.Tables(0).Rows(0).Item("Name1").ToString.Trim
                txtCell1.Text = ds.Tables(0).Rows(0).Item("Cell1").ToString.Trim
                txtIdNo1.Text = ds.Tables(0).Rows(0).Item("IdNo1").ToString.Trim
                rdbSex1.SelectedValue = ds.Tables(0).Rows(0).Item("Sex1").ToString.Trim
                rdbSchool1.SelectedValue = ds.Tables(0).Rows(0).Item("School1").ToString.Trim

                txtSurname2.Text = ds.Tables(0).Rows(0).Item("Surname2").ToString.Trim
                txtName2.Text = ds.Tables(0).Rows(0).Item("Name2").ToString.Trim
                txtCell2.Text = ds.Tables(0).Rows(0).Item("Cell2").ToString.Trim
                txtIdNo2.Text = ds.Tables(0).Rows(0).Item("IdNo2").ToString.Trim
                rdbSex2.SelectedValue = ds.Tables(0).Rows(0).Item("Sex2").ToString.Trim
                rdbSchool2.SelectedValue = ds.Tables(0).Rows(0).Item("School2").ToString.Trim

                txtSurname3.Text = ds.Tables(0).Rows(0).Item("Surname3").ToString.Trim
                txtName3.Text = ds.Tables(0).Rows(0).Item("Name3").ToString.Trim
                txtCell3.Text = ds.Tables(0).Rows(0).Item("Cell3").ToString.Trim
                txtIdNo3.Text = ds.Tables(0).Rows(0).Item("IdNo3").ToString.Trim
                rdbSex3.SelectedValue = ds.Tables(0).Rows(0).Item("Sex3").ToString.Trim
                rdbSchool3.SelectedValue = ds.Tables(0).Rows(0).Item("School3").ToString.Trim

                txtNominated.Text = ds.Tables(0).Rows(0).Item("NominatedBy").ToString.Trim
                txtNominatedCell.Text = ds.Tables(0).Rows(0).Item("NominatedCell").ToString.Trim
                txtNominatedEmail.Text = ds.Tables(0).Rows(0).Item("NominatedEmail").ToString.Trim
                txtNominatedMemNo.Text = ds.Tables(0).Rows(0).Item("NominatedMemNo").ToString.Trim

                txtStreetName.Text = ds.Tables(0).Rows(0).Item("Residential_StreetName").ToString.Trim
                txtStreetNo.Text = ds.Tables(0).Rows(0).Item("Residential_StreetNo").ToString.Trim
                txtComplexName.Text = ds.Tables(0).Rows(0).Item("Residential_ComplexName").ToString.Trim
                txtComplexNo.Text = ds.Tables(0).Rows(0).Item("Residential_ComplexNo").ToString.Trim
                txtSuburb.Text = ds.Tables(0).Rows(0).Item("Residential_Suburb").ToString.Trim
                txtCity.Text = ds.Tables(0).Rows(0).Item("Residential_City_Town").ToString.Trim
                txtProv.Text = ds.Tables(0).Rows(0).Item("Residential_Province_State").ToString.Trim
                txtZipCode.Text = ds.Tables(0).Rows(0).Item("Residential_Code_Zip").ToString.Trim

                txtPostalAddr1.Text = ds.Tables(0).Rows(0).Item("PostalAddr1").ToString.Trim
                txtPostalAddr2.Text = ds.Tables(0).Rows(0).Item("PostalAddr2").ToString.Trim
                txtPostalAddr3.Text = ds.Tables(0).Rows(0).Item("PostalAddr3").ToString.Trim
                txtPostalAddr4.Text = ds.Tables(0).Rows(0).Item("PostalAddr4").ToString.Trim
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdateAssociationRegistration()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Association_Id", AssociationId.Trim)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)
        cmd.Parameters.AddWithValue("@AssociationName", GetAssociationName(AssociationId.Trim))

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Association WHERE Association_Id = @Association_Id AND MemberId = @MemberId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Association SET AssociationName = @AssociationName WHERE Association_Id = @Association_Id AND MemberId = @MemberId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Association (MemberId, AssociationName, Association_Id) VALUES (@MemberId, @AssociationName, @Association_Id) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub SaveMember()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)
        cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@FullName", txtName.Text.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtCellphone.Text.Trim)
        cmd.Parameters.AddWithValue("@IDNo", txtIdNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

        cmd.Parameters.AddWithValue("@SpouseSex", rdbSpouseSex.SelectedValue)
        cmd.Parameters.AddWithValue("@SpouseSurname", txtSpouseSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@SpouseName", txtSpouseName.Text.Trim)
        cmd.Parameters.AddWithValue("@SpouseCell", txtSpouseCell.Text.Trim)
        cmd.Parameters.AddWithValue("@SpouseIdNo", txtSpouseIdNo.Text.Trim)
        cmd.Parameters.AddWithValue("@SpouseOccupation", txtSpouseOccupation.Text.Trim)

        cmd.Parameters.AddWithValue("@Surname1", txtSurname1.Text.Trim)
        cmd.Parameters.AddWithValue("@Name1", txtName1.Text.Trim)
        cmd.Parameters.AddWithValue("@Cell1", txtCell1.Text.Trim)
        cmd.Parameters.AddWithValue("@IdNo1", txtIdNo1.Text.Trim)
        cmd.Parameters.AddWithValue("@Sex1", rdbSex1.SelectedValue)
        cmd.Parameters.AddWithValue("@School1", rdbSchool1.SelectedValue)

        cmd.Parameters.AddWithValue("@Surname2", txtSurname2.Text.Trim)
        cmd.Parameters.AddWithValue("@Name2", txtName2.Text.Trim)
        cmd.Parameters.AddWithValue("@Cell2", txtCell2.Text.Trim)
        cmd.Parameters.AddWithValue("@IdNo2", txtIdNo2.Text.Trim)
        cmd.Parameters.AddWithValue("@Sex2", rdbSex2.SelectedValue)
        cmd.Parameters.AddWithValue("@School2", rdbSchool2.SelectedValue)

        cmd.Parameters.AddWithValue("@Surname3", txtSurname3.Text.Trim)
        cmd.Parameters.AddWithValue("@Name3", txtName3.Text.Trim)
        cmd.Parameters.AddWithValue("@Cell3", txtCell3.Text.Trim)
        cmd.Parameters.AddWithValue("@IdNo3", txtIdNo3.Text.Trim)
        cmd.Parameters.AddWithValue("@Sex3", rdbSex3.SelectedValue)
        cmd.Parameters.AddWithValue("@School3", rdbSchool3.SelectedValue)

        cmd.Parameters.AddWithValue("@NominatedBy", txtNominated.Text.Trim)
        cmd.Parameters.AddWithValue("@NominatedCell", txtNominatedCell.Text.Trim)
        cmd.Parameters.AddWithValue("@NominatedEmail", txtNominatedEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@NominatedMemNo", txtNominatedMemNo.Text.Trim)

        cmd.Parameters.AddWithValue("@Residential_StreetName", txtStreetName.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_StreetNo", txtStreetNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_ComplexName", txtComplexName.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_ComplexNo", txtComplexNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_Suburb", txtSuburb.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_City_Town", txtCity.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_Province_State", txtProv.Text.Trim)
        cmd.Parameters.AddWithValue("@Residential_Code_Zip", txtZipCode.Text.Trim)

        cmd.Parameters.AddWithValue("@PostalAddr1", txtPostalAddr1.Text.Trim)
        cmd.Parameters.AddWithValue("@PostalAddr2", txtPostalAddr2.Text.Trim)
        cmd.Parameters.AddWithValue("@PostalAddr3", txtPostalAddr3.Text.Trim)
        cmd.Parameters.AddWithValue("@PostalAddr4", txtPostalAddr4.Text.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member WHERE MemberId = @MemberId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member SET Surname = @Surname, FullName = @FullName, CellNo = @CellNo, IDNo = @IDNo, Email = @Email, "
        str3 &= " SpouseSex = @SpouseSex, SpouseSurname = @SpouseSurname, SpouseName = @SpouseName, SpouseCell = @SpouseCell, SpouseIdNo = @SpouseIdNo, SpouseOccupation = @SpouseOccupation, "
        str3 &= " Surname1 = @Surname1, Name1 = @Name1, Cell1 = @Cell1, IdNo1 = @IdNo1, Sex1 = @Sex1, School1 = @School1, "
        str3 &= " Surname2 = @Surname2, Name2 = @Name2, Cell2 = @Cell2, IdNo2 = @IdNo2, Sex2 = @Sex2, School2 = @School2, "
        str3 &= " Surname3 = @Surname3, Name3 = @Name3, Cell3 = @Cell3, IdNo3 = @IdNo3, Sex3 = @Sex3, School3 = @School3, "
        str3 &= " NominatedBy = @NominatedBy, NominatedCell = @NominatedCell, NominatedEmail = @NominatedEmail, NominatedMemNo = @NominatedMemNo, "
        str3 &= " Residential_StreetName = @Residential_StreetName, Residential_StreetNo = @Residential_StreetNo, Residential_ComplexName = @Residential_ComplexName, "
        str3 &= " Residential_ComplexNo = @Residential_ComplexNo, Residential_Suburb = @Residential_Suburb, Residential_City_Town = @Residential_City_Town, "
        str3 &= " Residential_Province_State = @Residential_Province_State, Residential_Code_Zip = @Residential_Code_Zip, "
        str3 &= " PostalAddr1 = @PostalAddr1, PostalAddr2 = @PostalAddr2, PostalAddr3 = @PostalAddr3, PostalAddr4 = @PostalAddr4"
        str3 &= " WHERE MemberId = @MemberId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member (Surname, FullName, CellNo, IDNo, Email, SpouseSex, SpouseSurname, SpouseName, SpouseCell, SpouseIdNo, SpouseOccupation, "
        str3 &= " Surname1, Name1, Cell1, IdNo1, Sex1, School1, Surname2, Name2, Cell2, IdNo2, Sex2, School2, "
        str3 &= " Surname3, Name3, Cell3, IdNo3, Sex3, School3, NominatedBy, NominatedCell, "
        str3 &= " NominatedEmail, NominatedMemNo, Residential_StreetName, Residential_StreetNo, Residential_ComplexName, Residential_ComplexNo, "
        str3 &= " Residential_Suburb, Residential_City_Town, Residential_Province_State, Residential_Code_Zip, PostalAddr1, PostalAddr2, "
        str3 &= " PostalAddr3, PostalAddr4) "
        str3 &= " VALUES (@Surname, @FullName, @CellNo, @IDNo, @Email, @SpouseSex, @SpouseSurname, @SpouseName, @SpouseCell, @SpouseIdNo, @SpouseOccupation, "
        str3 &= " @Surname1, @Name1, @Cell1, @IdNo1, @Sex1, @School1, @Surname2, @Name2, @Cell2, @IdNo2, @Sex2, @School2, "
        str3 &= " @Surname3, @Name3, @Cell3, @IdNo3, @Sex3, @School3, @NominatedBy, @NominatedCell, "
        str3 &= " @NominatedEmail, @NominatedMemNo, @Residential_StreetName, @Residential_StreetNo, @Residential_ComplexName, @Residential_ComplexNo, "
        str3 &= " @Residential_Suburb, @Residential_City_Town, @Residential_Province_State, @Residential_Code_Zip, @PostalAddr1, @PostalAddr2, "
        str3 &= " @PostalAddr3, @PostalAddr4) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub SendEmail()
        Dim messageBody As String = ""
        messageBody &= "<table width='70%' align='center' cellpadding='10' cellspacing='0' style='border: medium solid #3E432F'>"
        messageBody &= "    <tr style='background-color: #3E432F; '>"
        messageBody &= "        <td align='left' height='110' colspan='4'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img alt='' src='http://www.ecohunter-app.co.za/Images/Logos/eco-hunter-log-small.png' class='logo-style'  /></td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td height='35' align='center' colspan='4'><b>" & lblHeader.Text.Trim & "</b></td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td colspan='4'>&nbsp;</td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>Principal Member</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Surname</td>"
        messageBody &= "                    <td width='35%'>" & txtSurname.Text.Trim & "</td>"
        messageBody &= "                    <td width='15%'>First Name</td>"
        messageBody &= "                    <td width='35%'>" & txtName.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Cellphone</td>"
        messageBody &= "                    <td>" & txtCellphone.Text.Trim & "</td>"
        messageBody &= "                    <td> ID Number</td>"
        messageBody &= "                    <td>" & txtIdNo.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Email Address</td>"
        messageBody &= "                    <td>" & txtEmail.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>Additional Family Members</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Spouse Sex</td>"
        messageBody &= "                    <td width='35%' align='left'>" & rdbSpouseSex.SelectedValue & "</td>"
        messageBody &= "                    <td width='15%'>&nbsp;</td>"
        messageBody &= "                    <td width='35%'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Surname</td>"
        messageBody &= "                    <td>" & txtSpouseSurname.Text.Trim & "</td>"
        messageBody &= "                    <td> First Name</td>"
        messageBody &= "                    <td>" & txtSpouseName.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Cellphone</td>"
        messageBody &= "                    <td>" & txtSpouseCell.Text.Trim & "</td>"
        messageBody &= "                    <td> ID Number</td>"
        messageBody &= "                    <td>" & txtSpouseIdNo.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Occupation</td>"
        messageBody &= "                    <td>" & txtSpouseOccupation.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>1st Family Member</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Surname</td>"
        messageBody &= "                    <td width='35%'>" & txtSurname1.Text.Trim & "</td>"
        messageBody &= "                    <td width='15%'>First Name</td>"
        messageBody &= "                    <td width='35%'>" & txtName1.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Cellphone</td>"
        messageBody &= "                    <td>" & txtCell1.Text.Trim & "</td>"
        messageBody &= "                    <td>ID Number</td>"
        messageBody &= "                    <td>" & txtIdNo1.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Sex</td>"
        messageBody &= "                    <td align='left'>" & rdbSex1.SelectedValue & "</td>"
        messageBody &= "                    <td align='left' colspan='2'></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>2nd Family Member</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Surname</td>"
        messageBody &= "                    <td width='35%'>" & txtSurname2.Text.Trim & "</td>"
        messageBody &= "                    <td width='15%'>First Name</td>"
        messageBody &= "                    <td width='35%'>" & txtName2.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Cellphone</td>"
        messageBody &= "                    <td>" & txtCell2.Text.Trim & "</td>"
        messageBody &= "                    <td>ID Number</td>"
        messageBody &= "                    <td>" & txtIdNo2.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Sex</td>"
        messageBody &= "                    <td align='left'>" & rdbSex2.SelectedValue & "</td>"
        messageBody &= "                    <td align='left' colspan='2'></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr>"
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>3rd Family Member</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Surname</td>"
        messageBody &= "                    <td width='35%'>" & txtSurname3.Text.Trim & "</td>"
        messageBody &= "                    <td width='15%'>First Name</td>"
        messageBody &= "                    <td width='35%'>" & txtName3.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Cellphone</td>"
        messageBody &= "                    <td>" & txtCell3.Text.Trim & "</td>"
        messageBody &= "                    <td>ID Number</td>"
        messageBody &= "                    <td>" & txtIdNo3.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Sex</td>"
        messageBody &= "                    <td align='left'>" & rdbSex3.SelectedValue & "</td>"
        messageBody &= "                    <td align='left' colspan='2'></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr>   "
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>Nominated By</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Nominated By</td>"
        messageBody &= "                    <td width='35%'>" & txtNominated.Text.Trim & "</td>"
        messageBody &= "                    <td width='15%'>Cell No</td>"
        messageBody &= "                    <td width='35%'>" & txtNominatedCell.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Email Address</td>"
        messageBody &= "                    <td>" & txtNominatedEmail.Text.Trim & "</td>"
        messageBody &= "                    <td>Member No</td>"
        messageBody &= "                    <td>" & txtNominatedMemNo.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr> "
        messageBody &= "    <tr>"
        messageBody &= "        <td>"
        messageBody &= "            <table width='100%' align='center' celpadding='0' cellspacing='0' style='border-color: #000000; border-bottom-style: solid; border-width: thin'>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'><i><b>General Information</b></i></td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27' width='15%'>Street Name</td>"
        messageBody &= "                    <td width='35%'>" & txtStreetName.Text.Trim & "</td>"
        messageBody &= "                    <td width='15%'>Postal Address</td>"
        messageBody &= "                    <td width='35%'>" & txtPostalAddr1.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Street No</td>"
        messageBody &= "                    <td>" & txtStreetNo.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>" & txtPostalAddr2.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Complex Name</td>"
        messageBody &= "                    <td>" & txtComplexName.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>" & txtPostalAddr3.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Complex No</td>"
        messageBody &= "                    <td>" & txtComplexNo.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>" & txtPostalAddr4.Text.Trim & "</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Suburb</td>"
        messageBody &= "                    <td>" & txtSuburb.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>City/Town</td>"
        messageBody &= "                    <td>" & txtCity.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Province</td>"
        messageBody &= "                    <td>" & txtProv.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td height='27'>Code</td>"
        messageBody &= "                    <td>" & txtZipCode.Text.Trim & "</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                    <td>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "                <tr>"
        messageBody &= "                    <td colspan='4'>&nbsp;</td>"
        messageBody &= "                </tr>"
        messageBody &= "            </table>"
        messageBody &= "        </td>"
        messageBody &= "    </tr>"
        messageBody &= "</table>"

        Dim myMailer As New MAILER
        Dim success As Boolean
        success = myMailer.sendMail("Eco Hunter", "gawie@naudeonline.co.za; charlene@rupane.co.za", "Association Membership Registration", messageBody, True)

    End Sub
#End Region

#Region "Functions"
    Private Function GetAssociationName(ByVal AssociationId As String) As String

        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand
        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@Association_Id", AssociationId.Trim)

        Dim Name As String
        Dim str As String = ""
        str &= " SELECT Name FROM tbl_Associations WHERE (Association_Id = @Association_Id) "

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
                Name = ds5.Tables(0).Rows(0).Item("Name").ToString.Trim
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
#End Region



End Class
