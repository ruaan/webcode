Imports System.Data
Partial Class Reserve
    Inherits System.Web.UI.Page


    Dim MemberId As String = ""

    Private Sub Reserve_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Try
                MemberId = Request.Cookies("memberid").Value
                Label1.Text = Request.Cookies("memberid").Value
            Catch ex As Exception
                Response.Redirect("~/Login.aspx")
            End Try

            Dim Frid, Dfrm, Dto, hnt, gst, ac, ad, cntId As String

            Try
                Frid = Request.QueryString("Frid")
                Dfrm = Request.QueryString("Dfrm")
                Dto = Request.QueryString("Dto")
                hnt = Request.QueryString("hnt")
                If hnt = "" Then
                    hnt = 0
                End If
                gst = Request.QueryString("gst")
                If gst = "" Then
                    gst = 0

                End If
                ac = Request.QueryString("ac")
                ad = Request.QueryString("ad")
                cntId = "1"
            Catch ex As Exception
                Response.Redirect("farm_view.aspx")
            End Try


            If Frid <> "" Then


                HiddenFieldFarmId.Value = Frid
                HiddenFieldAccom.Value = ac
                HiddenFieldAdditional.Value = ad

                PopulateFarm(Frid)
                lblTotalParty.Text = CInt(hnt) + CInt(gst)
                lblHunterCount.Text = hnt
                lblGuestCount.Text = gst

                lblDates.Text = CDate(Dfrm).ToLongDateString & " to " & CDate(Dto).ToLongDateString

                lblDaysCount.Text = DateDiff(DateInterval.Day, CDate(Dfrm), CDate(Dto))

                If txtUniqueName.Text = "" Then
                    txtUniqueName.Text = lblGameFarm.Text.Trim & " " & Dfrm
                End If


                Dim HunterDetail() As String = GetMainMemberDetails(MemberId)

                AddMemberTable(MemberId, HunterDetail(0), "False", HunterDetail(1), "Hunter")
                PopulateFarmAnimals(Frid, cntId)
                PlaceHolderBilling.Controls.Clear()
                PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))

            Else
                Response.Redirect("farm_View.aspx")
            End If
        End If

    End Sub

    Private Function GetMainMemberDetails(MemberId As String) As String()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand




        cmd.Parameters.AddWithValue("@MemberId", MemberId)

        Dim str As String = ""
        str &= "  SELECT  MemberId, PreferredName + ' ' + Surname as Name,  PreferredName, HunterType"
        str &= "  FROM            tbl_Member"
        str &= "  WHERE (MemberId = @MemberId)"

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

        Dim hunterDetail(2) As String
        Try
            hunterDetail(0) = ds.Tables(0).Rows(0).Item("Name").ToString
            hunterDetail(1) = ds.Tables(0).Rows(0).Item("HunterType").ToString
        Catch ex As Exception
            hunterDetail(0) = MemberId
        End Try


        Return hunterDetail

    End Function

    Protected Sub btnMemberSearch_Click(sender As Object, e As EventArgs) Handles btnMemberSearch.Click

        Dim MemberDetails() As String

        MemberDetails = GetMember(txtMemberSearch.Text.Trim)

        If MemberDetails(0) <> "na" Then
            pnlMemberDetails.Visible = True
            pnlMembernotfound.Visible = False
            lblId2Add.Text = MemberDetails(0)
            lblNameToAdd.Text = MemberDetails(1)
            lblCellToAdd.Text = MemberDetails(2)
            lblEmailtoAdd.Text = MemberDetails(3)
        Else
            pnlMemberDetails.Visible = False
            pnlMembernotfound.Visible = True

        End If



        btnAddMember_ModalPopupExtender.Show()
    End Sub


    Protected Sub btnMemberYes_Click(sender As Object, e As EventArgs) Handles btnMemberYes.Click
        pnlEcoMemberYes.Visible = True
        pnlEcoMemberNo.Visible = False
        btnAddMember_ModalPopupExtender.Show()
        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))
    End Sub
    Protected Sub btnMemberNo_Click(sender As Object, e As EventArgs) Handles btnMemberNo.Click
        pnlEcoMemberYes.Visible = False
        pnlEcoMemberNo.Visible = True
        btnAddMember_ModalPopupExtender.Show()
        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))
    End Sub
    Protected Sub btnMainCancel_Click(sender As Object, e As EventArgs) Handles btnMainCancel.Click
        lblNameToAdd.Text = ""
        lblCellToAdd.Text = ""
        lblEmailtoAdd.Text = ""
        txtMemberSearch.Text = ""
        pnlMemberDetails.Visible = False
        pnlEcoMemberYes.Visible = False
        pnlEcoMemberNo.Visible = False
        btnAddMember_ModalPopupExtender.Hide()
        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))
    End Sub
    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        lblNameToAdd.Text = ""
        lblCellToAdd.Text = ""
        lblEmailtoAdd.Text = ""
        pnlMemberDetails.Visible = False
        btnAddMember_ModalPopupExtender.Show()
        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))
    End Sub
    Private Function GetMember(SearchStr As String) As String()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        SearchStr = SearchStr.Replace(" ", "")

        cmd.Parameters.AddWithValue("@SearchStr", SearchStr)

        Dim str As String = ""
        str &= "  SELECT        MemberId, Surname, FullName, PreferredName, IDNo, PassportNr, CellNo, Email, MembershipExpire"
        str &= "  FROM            tbl_Member"
        str &= "  WHERE        (IDNo = @SearchStr) OR"
        str &= "                           (PassportNr = @SearchStr) OR"
        str &= "                           (CellNo = @SearchStr) OR"
        str &= "                           (Email = @SearchStr)"

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

        Dim MemberDetails(4) As String

        Try
            MemberDetails(0) = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim
            MemberDetails(1) = ds.Tables(0).Rows(0).Item("PreferredName").ToString.Trim & " " & ds.Tables(0).Rows(0).Item("Surname").ToString.Trim
            MemberDetails(2) = ds.Tables(0).Rows(0).Item("CellNo").ToString.Trim
            MemberDetails(3) = ds.Tables(0).Rows(0).Item("Email").ToString.Trim

        Catch ex As Exception
            MemberDetails(0) = "na"
        End Try


        Return MemberDetails

    End Function
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AddMemberTable(lblId2Add.Text.Trim, lblNameToAdd.Text.Trim, CheckBox2.Checked, "Dedicated", RadioButtonList1.SelectedValue.Trim)
        lblNameToAdd.Text = ""
        lblCellToAdd.Text = ""
        lblEmailtoAdd.Text = ""
        pnlMemberDetails.Visible = False
    End Sub
    Dim Table1 As New DataTable
    Private Sub CreateTable()
        Table1.Columns.Add("id", GetType(System.String))
        Table1.Columns.Add("Name", GetType(System.String))
        Table1.Columns.Add("HunterType", GetType(System.String))
        Table1.Columns.Add("whoPays", GetType(System.String))
        Table1.Columns.Add("HunterGuest", GetType(System.String))
    End Sub
    Private Sub AddMemberTable(id As String, Name As String, OwnAccount As String, HunterType As String, hunterGuest As String)

        Try
            If Table1.Rows.Count = 0 Then
                CreateTable()
            End If
        Catch ex As Exception
            CreateTable()
        End Try




        Dim count As Integer = GridView1.Rows.Count - 1
        Dim sp As Integer

        For sp = 0 To count
            Table1.Rows.Add(GridView1.Rows(sp).Cells(0).Text.Trim, GridView1.Rows(sp).Cells(1).Text.Trim, GridView1.Rows(sp).Cells(2).Text.Trim, GridView1.Rows(sp).Cells(3).Text.Trim, GridView1.Rows(sp).Cells(4).Text.Trim)
        Next




        Table1.Rows.Add(id, Name, HunterType, OwnAccount, hunterGuest)

        GridView1.DataSource = Table1
        GridView1.DataBind()


    End Sub


    Protected Sub GridView1_DataBound(sender As Object, e As EventArgs) Handles GridView1.DataBound

        lblMemberMsg.Text = ""

        Dim count As Integer = GridView1.Rows.Count - 1
        Dim sp As Integer
        Dim TotalPax As Integer = 0
        Dim HunterPax As Integer = 0
        Dim GuestPax As Integer = 0
        Dim OwnAccountPax As Integer = 0
        For sp = 0 To count

            If GridView1.Rows(sp).Cells(4).Text.Trim = "Hunter" Then
                HunterPax += 1
            Else
                GuestPax += 1
            End If
            TotalPax += 1

            If GridView1.Rows(sp).Cells(3).Text.Trim = "True" Then
                GridView1.Rows(sp).Cells(3).Text = ""
                OwnAccountPax += 1
            ElseIf GridView1.Rows(sp).Cells(3).Text.Trim = "" Then
                GridView1.Rows(sp).Cells(3).Text = ""
                OwnAccountPax += 1
            ElseIf GridView1.Rows(sp).Cells(3).Text.Trim = "&nbsp;" Then
                GridView1.Rows(sp).Cells(3).Text = ""
                OwnAccountPax += 1
            Else
                GridView1.Rows(sp).Cells(3).Text = "Yes"

            End If

            If GridView1.Rows(sp).Cells(2).Text.Trim = "&nbsp;" Then
                GridView1.Rows(sp).Cells(2).Text = ""
            End If
        Next


        If TotalPax > CInt(lblTotalParty.Text) Then
            lblMemberMsg.Text = "You have added more members than the " & lblTotalParty.Text.Trim & " you are reserving."
        End If
        If HunterPax > CInt(lblHunterCount.Text) Then
            If lblMemberMsg.Text <> "" Then
                lblMemberMsg.Text &= "</br>"
            End If
            lblMemberMsg.Text &= "You have added more hunters than the " & lblHunterCount.Text.Trim & " you are reserving."
        End If
        If GuestPax > CInt(lblGuestCount.Text) Then
            If lblMemberMsg.Text <> "" Then
                lblMemberMsg.Text &= "</br>"
            End If
            lblMemberMsg.Text &= "You have added more guests than the " & lblGuestCount.Text.Trim & " you are reserving."
        End If

        If TotalPax = CInt(lblTotalParty.Text) Then
            btnAddMember.Enabled = False
        Else
            btnAddMember.Enabled = True
        End If


        HiddenFieldOwnAccountQty.Value = OwnAccountPax

        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))


    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim HunterType As String = DropDownList1.SelectedValue.Trim
        Dim HunterGuest As String = "Hunter"
        If HunterType.Trim = "Guest" Then
            HunterGuest = "Guest"
            HunterType = " "
        End If


        AddMemberTable(" ", txtNonMemberName.Text.Trim, "False", HunterType, HunterGuest)
        lblNameToAdd.Text = ""
        lblCellToAdd.Text = ""
        lblEmailtoAdd.Text = ""
        pnlMemberDetails.Visible = False
        txtNonMemberName.Text = ""
        pnlEcoMemberNo.Visible = False
    End Sub

    Private Sub PopulateFarmAnimals(FarmId As String, CountryId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand




        cmd.Parameters.AddWithValue("@FarmId", FarmId)
        cmd.Parameters.AddWithValue("@VisitingCountry", CountryId)
        Dim str As String = ""
        str &= " SELECT    tbl_Farm_Animal.id, tbl_Animal_Groups.Description, tbl_Animals.Name, tbl_Farm_Animal.AnimalId, tbl_Farm_Animal.AvailableToHunt, tbl_Farm_Animal.Male_Price, tbl_Farm_Animal.Female_Price, "
        Str &= "                          tbl_Farm_Animal.Trophy_Price, tbl_Farm_Animal.Inches, tbl_Farm_Animal.Visiting_Country, tbl_Farm_Animal.Active"
        Str &= " FROM            tbl_Farm_Animal INNER JOIN"
        Str &= "                          tbl_Animals ON tbl_Farm_Animal.AnimalId = tbl_Animals.id INNER JOIN"
        Str &= "                          tbl_Animal_Groups ON tbl_Animals.Animal_Group = tbl_Animal_Groups.groupId"
        Str &= " WHERE        (tbl_Farm_Animal.FarmId = @FarmId) AND (tbl_Farm_Animal.Active = 'True') AND (tbl_Farm_Animal.AvailableToHunt = 'True') AND (tbl_Farm_Animal.Visiting_Country = @VisitingCountry)"
        Str &= " ORDER BY tbl_Animal_Groups.Description, tbl_Animals.Name"

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
    Protected Sub btnAnimalClose_Click(sender As Object, e As EventArgs) Handles btnAnimalClose.Click
        Button1_ModalPopupExtender.Hide()
        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))
    End Sub
    Protected Sub btnAnimalSubmit_Click(sender As Object, e As EventArgs) Handles btnAnimalSubmit.Click

        Dim tblSpecies As New DataTable

        tblSpecies.Columns.Add("id", GetType(System.String))
        tblSpecies.Columns.Add("Name", GetType(System.String))
        tblSpecies.Columns.Add("Sex", GetType(System.String))
        tblSpecies.Columns.Add("Qty", GetType(System.String))
        tblSpecies.Columns.Add("Price", GetType(System.String))
        tblSpecies.Columns.Add("Total", GetType(System.String))

        Dim cmbAnimalMale As New DropDownList
        Dim cmbAnimalFemale As New DropDownList
        Dim cmbAnimalTrophy As New DropDownList

        Dim count As Integer = GridView3.Rows.Count - 1
        Dim sp As Integer

        For sp = 0 To count
            cmbAnimalMale = GridView3.Rows(sp).FindControl("cmbAnimalMale")
            cmbAnimalFemale = GridView3.Rows(sp).FindControl("cmbAnimalFeMale")
            cmbAnimalTrophy = GridView3.Rows(sp).FindControl("cmbAnimalTrophy")

            If cmbAnimalMale.SelectedValue <> "0" Then
                tblSpecies.Rows.Add(GridView3.Rows(sp).Cells(0).Text.Trim, GridView3.Rows(sp).Cells(2).Text.Trim, "Male", cmbAnimalMale.SelectedValue, GridView3.Rows(sp).Cells(3).Text.Trim, (CDbl(GridView3.Rows(sp).Cells(3).Text.Trim) * CDbl(cmbAnimalMale.SelectedValue)).ToString("###,##0.00"))
            End If
            If cmbAnimalFemale.SelectedValue <> "0" Then
                tblSpecies.Rows.Add(GridView3.Rows(sp).Cells(0).Text.Trim, GridView3.Rows(sp).Cells(2).Text.Trim, "Female", cmbAnimalFemale.SelectedValue, GridView3.Rows(sp).Cells(3).Text.Trim, (CDbl(GridView3.Rows(sp).Cells(3).Text.Trim) * CDbl(cmbAnimalFemale.SelectedValue)).ToString("###,##0.00"))
            End If
            If cmbAnimalTrophy.SelectedValue <> "0" Then
                tblSpecies.Rows.Add(GridView3.Rows(sp).Cells(0).Text.Trim, GridView3.Rows(sp).Cells(2).Text.Trim, "Trophy", cmbAnimalTrophy.SelectedValue, GridView3.Rows(sp).Cells(3).Text.Trim, (CDbl(GridView3.Rows(sp).Cells(3).Text.Trim) * CDbl(cmbAnimalTrophy.SelectedValue)).ToString("###,##0.00"))
            End If




        Next


        GridView2.DataSource = tblSpecies
        GridView2.DataBind()

    End Sub
    Protected Sub GridView2_DataBound(sender As Object, e As EventArgs) Handles GridView2.DataBound
        Dim count As Integer = GridView2.Rows.Count - 1
        Dim sp As Integer
        Dim Total As Double = 0
        For sp = 0 To count
            Total += CDbl(GridView2.Rows(sp).Cells(5).Text.Trim)
        Next

        GridView2.FooterRow.Cells(5).Text = (1 * Total).ToString("###,##0.00")

        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))

    End Sub
    Private Function GetBillingBody() As String


        Dim OwnAccountPax As Integer = HiddenFieldOwnAccountQty.Value

        Dim yourAccountRatio As Integer = CDbl(lblTotalParty.Text) - OwnAccountPax

        Dim SpeciesValue As Double = 0

        If GridView2.Rows.Count > 0 Then
            SpeciesValue = GridView2.FooterRow.Cells(5).Text
        End If

        Dim AccommodationValue As Double = HiddenFieldAccom.Value
        Dim AccommodationValueYour As Double = 0
        AccommodationValueYour = AccommodationValue / CDbl(lblTotalParty.Text) * yourAccountRatio


        Dim AdditionalValue As Double = HiddenFieldAdditional.Value
        Dim AdditionalValueYour As Double = 0
        AdditionalValueYour = AdditionalValue / CDbl(lblTotalParty.Text) * yourAccountRatio

        Dim TotalDue As Double = AccommodationValue + AdditionalValue + SpeciesValue
        Dim TotalYour As Double = AccommodationValueYour + AdditionalValueYour + SpeciesValue
        Dim DepositPercent As Double = HiddenFieldDepositPercentage.Value
        Dim DepositWaitingPeriod As Double = HiddenFieldDepositPeriod.Value
        Dim DepositAmount As Double = TotalDue * (DepositPercent / 100)
        Dim DepositYour As Double = TotalYour * (DepositPercent / 100)



        Dim Depositdate As Date = DateAdd(DateInterval.Day, DepositWaitingPeriod, Now.Date)


        HiddenFieldTotalDue.Value = TotalDue
        HiddenFieldTotalDueYou.Value = TotalYour

        HiddenFieldDepositValue.Value = DepositAmount
        HiddenFieldDepositValueYou.Value = DepositYour

        HiddenFieldDepositDue.Value = Depositdate

        HiddenFieldFinalPayment.Value = TotalDue - DepositAmount
        HiddenFieldFinalPaymentYou.Value = TotalYour - DepositYour

        HiddenFieldAccomValue.Value = AccommodationValue
        HiddenFieldAccomValueYou.Value = AccommodationValueYour

        HiddenFieldAdditionalValue.Value = AdditionalValue
        HiddenFieldAdditionalValueYou.Value = AdditionalValueYour
        HiddenFieldSpeciesValue.Value = SpeciesValue
        HiddenFieldExtraValue.Value = 0


        Dim htmlString As String = ""

        htmlString &= "                         <div class='div_AccountHeading'>Total Due</div>"
        htmlString &= "                          <div>"
        htmlString &= "                                 <div class='div_Totals'>"
        htmlString &= "                                     <div><strong>Total</strong></div>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * TotalDue).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div class='div_YourAccount'>"
        htmlString &= "                                     <div><strong>For your account</strong></div>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * TotalYour).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div class='div_AccountHeading'>Deposit</div>"
        htmlString &= "                                 <div class='div_Totals'>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * DepositAmount).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div style='display: inline-block; background-color: #C0C0C0; padding-bottom: 5px' class='div_YourAccount'>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * DepositYour).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div style='font-size: small; color: #666666; padding-bottom: 5px;'>Pay deposit before " & Depositdate.ToString("dd/MM/yyyy") & ".</div>"
        htmlString &= "                                 <div class='div_AccountHeading'>Final payment</div>"
        htmlString &= "                                 <div class='div_Totals'>"
        htmlString &= "                                     <div>"
        htmlString &= (TotalDue - DepositAmount).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div class='div_YourAccount'>"
        htmlString &= "                                     <div>"
        htmlString &= (TotalYour - DepositYour).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div style='font-size: small; color: #666666;'>Final payment can be done onsite.</div>"
        htmlString &= "                             </div>"
        htmlString &= "                             <div style='border-bottom-style: solid; border-width: thin; border-color: #333333'>&nbsp;</div>"
        htmlString &= "                             <div>&nbsp;</div>"
        htmlString &= "                             <div class='div_AccountSubHeading'>Accommodation</div>"
        htmlString &= "                             <div class='div_Totals'>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * AccommodationValue).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                             </div>"
        htmlString &= "                             <div class='div_YourAccount'>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * AccommodationValueYour).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                             </div>"
        htmlString &= "                             <div class='div_AccountSubHeading'>Additional</div>"
        htmlString &= "                             <div class='div_Totals'>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * AdditionalValue).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                             </div>"
        htmlString &= "                             <div class='div_YourAccount'>"
        htmlString &= "                                     <div>"
        htmlString &= (1 * AdditionalValueYour).ToString("###,##0.00")
        htmlString &= "                                     </div>"
        htmlString &= "                             </div>"



        If SpeciesValue <> 0 Then
            htmlString &= "                             <div class='div_AccountSubHeading'>Game</div>"
            htmlString &= "                             <div class='div_Totals'>"
            htmlString &= "                                     <div>"
            htmlString &= (1 * SpeciesValue).ToString("###,##0.00")
            htmlString &= "                                     </div>"
            htmlString &= "                             </div>"
            htmlString &= "                             <div class='div_YourAccount'>"
            htmlString &= "                                     <div>"
            htmlString &= (1 * SpeciesValue).ToString("###,##0.00")
            htmlString &= "                                     </div>"
            htmlString &= "                             </div>"
        End If





        htmlString &= "                             <div>&nbsp;</div>"

        Return htmlString

    End Function
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))
    End Sub

    Private Sub PopulateFarm(FarmId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand




        cmd.Parameters.AddWithValue("@FarmId", FarmId)
        Dim str As String = ""
        str &= " SELECT id, FarmName, Status, DepositPercentage, DepositPeriod, UseBookingSystem"
        str &= " FROM tbl_Farm"
        str &= " WHERE (id = @FarmId)"

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

        lblGameFarm.Text = ds.Tables(0).Rows(0).Item("FarmName").ToString.Trim
        imgFarm.ImageUrl = "Farms/Images/FarmProfiles/" & FarmId & "main.jpg"
        HiddenFieldDepositPercentage.Value = ds.Tables(0).Rows(0).Item("DepositPercentage").ToString.Trim
        HiddenFieldDepositPeriod.Value = ds.Tables(0).Rows(0).Item("DepositPeriod").ToString.Trim
    End Sub
    Protected Sub btnReserve_Click(sender As Object, e As EventArgs) Handles btnReserve.Click
        StartSave()
    End Sub

    Private Sub StartSave()
        Dim count As Integer
        count = DateDiff(DateInterval.Day, CDate(Request.QueryString("Dfrm")), CDate(Request.QueryString("Dto")))
        Dim sp As Integer
        Dim bookingdate As Date = CDate(Request.QueryString("Dfrm"))
        Dim nextGrouId As Integer = GetNextHuntGroupId()
        Dim HuntId As String = ""
        HuntId = InitialHuntSave(nextGrouId)
        For sp = 0 To count
            SaveDateDetails(HuntId, bookingdate)
            bookingdate = DateAdd(DateInterval.Day, 1, bookingdate)
        Next
        Response.Redirect("Reserve_Confirm.aspx?HuntId=" & HuntId)
    End Sub

    Private Function InitialHuntSave(nextGrouId As Integer) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@FarmId", CInt(HiddenFieldFarmId.Value))
        cmd.Parameters.AddWithValue("@Main_Member_Id", Request.Cookies("memberid").Value)
        cmd.Parameters.AddWithValue("@BookingDate", Now)
        cmd.Parameters.AddWithValue("@UniqueName", txtUniqueName.Text.Trim)
        cmd.Parameters.AddWithValue("@Date_From", Request.QueryString("Dfrm"))
        cmd.Parameters.AddWithValue("@Date_To", Request.QueryString("Dto"))
        cmd.Parameters.AddWithValue("@HunterPax", CInt(Request.QueryString("hnt")))
        If Request.QueryString("gst") = "" Then
            cmd.Parameters.AddWithValue("@GuestPax", 0)
        Else
            cmd.Parameters.AddWithValue("@GuestPax", CInt(Request.QueryString("gst")))
        End If


        cmd.Parameters.AddWithValue("@CountryId", CInt(HiddenFieldFarmId.Value))

        cmd.Parameters.AddWithValue("@TotalDue", CDbl(HiddenFieldTotalDue.Value))
        cmd.Parameters.AddWithValue("@DepositValue", CDbl(HiddenFieldDepositValue.Value))
        cmd.Parameters.AddWithValue("@DepositDue", HiddenFieldDepositDue.Value)
        cmd.Parameters.AddWithValue("@FinalPayment", CDbl(HiddenFieldFinalPayment.Value))
        cmd.Parameters.AddWithValue("@AccommValue", CDbl(HiddenFieldAccomValue.Value))
        cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(HiddenFieldAdditionalValue.Value))
        cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(HiddenFieldSpeciesValue.Value))
        cmd.Parameters.AddWithValue("@ExtraValue", CDbl(HiddenFieldExtraValue.Value))

        cmd.Parameters.AddWithValue("@HuntGroupId", nextGrouId)


        Dim str As String = ""
        str &= " INSERT INTO tbl_Hunts "
        str &= " (FarmId, Main_Member_Id, BookingDate, Date_From, Date_To, TotalDue, DepositValue, DepositDue, FinalPayment, AccommValue, AdditionalValue, SpeciesValue, ExtraValue, CountryId, UniqueName, HunterPax, GuestPax, Status, PercDepositPaid, HuntGroupId)"
        str &= " VALUES"
        str &= " (@FarmId, @Main_Member_Id, @BookingDate, @Date_From, @Date_To, @TotalDue, @DepositValue, @DepositDue, @FinalPayment, @AccommValue, @AdditionalValue, @SpeciesValue, @ExtraValue, @CountryId, @UniqueName, @HunterPax, @GuestPax, 1,0, @HuntGroupId)"
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

        Finally
            myconnection.Close()
        End Try

        Dim HuntId As String = ""
        Try
            HuntId = ds.Tables(0).Rows(0).Item(0).ToString.Trim
            SaveMembers(HuntId)
            SaveSpecies(HuntId)
        Catch ex As Exception

        End Try

        Return HuntId

    End Function
    Private Sub SaveDateDetails(HuntId As String, BookingDate As Date)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@BookingDate", BookingDate)
        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Hunts_Detail "
        str &= " (HuntId, BookingDate)"
        str &= " VALUES"
        str &= " (@HuntId, @BookingDate)"

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
    Private Sub SaveMembers(HuntsId As String)

        Dim count As Integer = GridView1.Rows.Count - 1
        Dim sp As Integer

        For sp = 0 To count
            InsertMembers(HuntsId, sp)
        Next
    End Sub
    Private Function GetNextHuntGroupId() As String
        Dim TrackNr As String = ""
        Try
            Dim myconnection As New SqlClient.SqlConnection
            myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
            Dim cmd As New SqlClient.SqlCommand

            cmd.Parameters.AddWithValue("@FarmId", CInt(HiddenFieldFarmId.Value))
            Dim str As String = ""
            str &= " SELECT NextHuntGroupId from  tbl_Farm_Control"
            str &= " WHERE (FarmId  = @FarmId)"

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

            TrackNr = ds.Tables(0).Rows(0).Item("NextHuntGroupId").ToString.Trim

            'Increase the number by one
            Dim nextnr As Integer = TrackNr + 1
            cmd.Parameters.AddWithValue("@NR", nextnr)
            Dim str1 As String = "UPDATE  tbl_Farm_Control SET NextHuntGroupId  =" & "'" & nextnr & "'" & " WHERE FarmId  = " & "'" & CInt(HiddenFieldFarmId.Value) & "'"
            cmd.CommandText = str1
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            myconnection.Open()
            cmd.ExecuteNonQuery()
            myconnection.Close()
        Catch ex As Exception

            InsertNextGroupData()
            TrackNr = "1"
        End Try


        Return TrackNr





    End Function
    Private Sub InsertNextGroupData()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", CInt(HiddenFieldFarmId.Value))
        Dim str As String = ""
        str &= " INSERT INTO tbl_Farm_Control (FarmId, NextHuntGroupId) Values ('" & CInt(HiddenFieldFarmId.Value) & "', '1')"

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
    Private Sub InsertMembers(huntersId As String, GridviewRow As Integer)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@Hunts_Id", huntersId)
        cmd.Parameters.AddWithValue("@MemberId", GridView1.Rows(GridviewRow).Cells(0).Text)
        If GridView1.Rows(GridviewRow).Cells(4).Text = "Guest" Then
            cmd.Parameters.AddWithValue("@Type", "Guest")
        Else
            cmd.Parameters.AddWithValue("@Type", GridView1.Rows(GridviewRow).Cells(2).Text)

        End If

        If GridviewRow <> 0 Then
            If GridView1.Rows(GridviewRow).Cells(3).Text = "Yes" Then
                cmd.Parameters.AddWithValue("@OwnAccount", "False")
                cmd.Parameters.AddWithValue("@AccomValue", CDbl(0))

                cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(0))
                cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(0))
                cmd.Parameters.AddWithValue("@ExtraValue", CDbl(0))
                cmd.Parameters.AddWithValue("@FlightId", 0)
                cmd.Parameters.AddWithValue("@CarId", 0)
                cmd.Parameters.AddWithValue("@DepositValue", CDbl(0))
                cmd.Parameters.AddWithValue("@FinalValue", CDbl(0))



            Else
                cmd.Parameters.AddWithValue("@OwnAccount", "True")
                cmd.Parameters.AddWithValue("@AccomValue", CDbl(HiddenFieldAccomValue.Value) / CDbl(lblTotalParty.Text))

                cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(HiddenFieldAdditionalValue.Value) / CDbl(lblTotalParty.Text))
                cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(0))
                cmd.Parameters.AddWithValue("@ExtraValue", CDbl(0))
                cmd.Parameters.AddWithValue("@FlightId", 0)
                cmd.Parameters.AddWithValue("@CarId", 0)
                cmd.Parameters.AddWithValue("@DepositValue", CDbl(HiddenFieldDepositValue.Value) / CDbl(lblTotalParty.Text))
                cmd.Parameters.AddWithValue("@FinalValue", CDbl(HiddenFieldFinalPayment.Value) / CDbl(lblTotalParty.Text))
            End If

        Else
            cmd.Parameters.AddWithValue("@OwnAccount", "True")
            cmd.Parameters.AddWithValue("@AccomValue", CDbl(HiddenFieldAccomValueYou.Value))
            cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(HiddenFieldAdditionalValueYou.Value))
            cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(HiddenFieldSpeciesValue.Value))
            cmd.Parameters.AddWithValue("@ExtraValue", CDbl(HiddenFieldExtraValue.Value))
            cmd.Parameters.AddWithValue("@FlightId", 0)
            cmd.Parameters.AddWithValue("@CarId", 0)
            cmd.Parameters.AddWithValue("@DepositValue", CDbl(HiddenFieldDepositValueYou.Value))
            cmd.Parameters.AddWithValue("@FinalValue", CDbl(HiddenFieldFinalPaymentYou.Value))
        End If

        cmd.Parameters.AddWithValue("@Name", GridView1.Rows(GridviewRow).Cells(1).Text)
        cmd.Parameters.AddWithValue("@Mobil", "")
        cmd.Parameters.AddWithValue("@Email", "")
        cmd.Parameters.AddWithValue("@CountryId", "1")

        Dim str As String = ""

        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Hunts_Members  "
        str &= " WHERE MemberId = @MemberId AND Hunts_Id = @Hunts_Id ) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Hunts_Members"
        str &= " SET SpeciesValue = @SpeciesValue, ExtraValue = @ExtraValue, FlightId = @FlightId, CarId = @CarId, DepositValue = @DepositValue, FinalValue = @FinalValue, DepositPaid = 0, Status = 1 "
        str &= " WHERE MemberId = @MemberId AND Hunts_Id = @Hunts_Id"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT INTO tbl_Hunts_Members "
        str &= " (Hunts_Id, MemberId, Type, OwnAccount, Name, Mobil, Email, AccomValue, AdditionalValue, SpeciesValue, ExtraValue, CountryId, FlightId, CarId, DepositValue, FinalValue, DepositPaid, Status)"
        str &= " VALUES"
        str &= " (@Hunts_Id, @MemberId, @Type, @OwnAccount, @Name, @Mobil, @Email, @AccomValue, @AdditionalValue, @SpeciesValue, @ExtraValue, @CountryId, @FlightId, @CarId, @DepositValue, @FinalValue, 0, 1)"
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
    Private Sub SaveSpecies(HuntsId As String)

        Dim count As Integer = GridView2.Rows.Count - 1
        Dim sp As Integer

        For sp = 0 To count
            InsertSpecies(HuntsId, sp)
        Next




    End Sub
    Private Sub InsertSpecies(HuntId As String, RowId As Integer)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand



        cmd.Parameters.AddWithValue("@HuntsId", CInt(HuntId))
        cmd.Parameters.AddWithValue("@Billable_Member_Id", CInt(Request.Cookies("memberid").Value))
        cmd.Parameters.AddWithValue("@Farm_Animal_Id", CInt(GridView2.Rows(RowId).Cells(0).Text))
        cmd.Parameters.AddWithValue("@Sex", GridView2.Rows(RowId).Cells(2).Text)
        cmd.Parameters.AddWithValue("@Qty", CInt(GridView2.Rows(RowId).Cells(3).Text))
        cmd.Parameters.AddWithValue("@UnitCost", CDbl(GridView2.Rows(RowId).Cells(4).Text))
        cmd.Parameters.AddWithValue("@TotalCost", CDbl(GridView2.Rows(RowId).Cells(5).Text))


        Dim str As String = ""

        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Hunts_Species  "
        str &= " WHERE Billable_Member_Id = @Billable_Member_Id AND HuntsId = @HuntsId AND Farm_Animal_Id = @Farm_Animal_Id AND Sex = @Sex ) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Hunts_Species"
        str &= " SET Qty = @Qty "
        str &= " WHERE Billable_Member_Id = @Billable_Member_Id AND HuntsId = @HuntsId AND Farm_Animal_Id = @Farm_Animal_Id  AND Sex = @Sex"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT INTO tbl_Hunts_Species "
        str &= " (HuntsId, Billable_Member_Id, Farm_Animal_Id, Sex, Qty, UnitCost, TotalCost)"
        str &= " VALUES"
        str &= " (@HuntsId, @Billable_Member_Id, @Farm_Animal_Id, @Sex, @Qty, @UnitCost, @TotalCost)"
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
    Private Function GetHuntMembersdiv() As String




        Dim htmlString As String = ""

        Dim count As Integer = GridView1.Rows.Count - 1
        Dim sp As Integer
        Dim HunterGuest As String = ""
        Dim AccountType As String

        Dim TotalPax As Integer = 0
        Dim HunterPax As Integer = 0
        Dim GuestPax As Integer = 0
        Dim OwnAccountPax As Integer = 0

        For sp = 0 To count

            If GridView1.Rows(sp).Cells(0).Text = MemberId Then
                AccountType = "Your Account"

            Else
                If GridView1.Rows(sp).Cells(3).Text = "True" Then
                    AccountType = "Own Account"
                Else
                    AccountType = "Your Account"

                End If
            End If



            HunterGuest = GridView1.Rows(sp).Cells(4).Text


            htmlString &= " <div style='border-width: thin; border-color: #CCCCCC; padding-left: 10px; padding-top: 5px; padding-bottom: 5px; border-bottom-style: solid;'>"
            htmlString &= "                 <div style='display: inline-block; width: 60%'>"
            htmlString &= "                     <div style='font-weight: bold'>"
            htmlString &= GridView1.Rows(sp).Cells(1).Text
            htmlString &= "                     </div>"
            htmlString &= "                     <div>"
            htmlString &= GridView1.Rows(sp).Cells(2).Text
            htmlString &= "                     </div>"
            htmlString &= " <div>"
            htmlString &= " &nbsp;"
            htmlString &= " </div>"
            htmlString &= "                 </div>"
            htmlString &= "                 <div style='display: inline-block; width: 35%'>"
            htmlString &= "                     <div>"
            htmlString &= HunterGuest
            htmlString &= "                     </div>"
            htmlString &= "                     <div>"
            htmlString &= AccountType
            htmlString &= "                     </div>"

            htmlString &= "                 </div>"
            htmlString &= " </div>"

        Next


        Return htmlString

    End Function
    Protected Sub btnAddMember_Click(sender As Object, e As EventArgs) Handles btnAddMember.Click
        btnAddMember_ModalPopupExtender.Show()
    End Sub
    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        btnAddMember_ModalPopupExtender.Show()
    End Sub
End Class
