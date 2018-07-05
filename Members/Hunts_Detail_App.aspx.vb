Imports System.Data
Partial Class Members_Hunts_Detail_App
    Inherits System.Web.UI.Page
    Dim MemberId As String = ""
    Dim HuntId As String = ""
    Private Sub Reserve_Load(sender As Object, e As EventArgs) Handles Me.Load


        Try
            MemberId = Request.Cookies("memberid").Value

        Catch ex As Exception

        End Try


        HuntId = Request.QueryString("h")

        Dim thisHunt As New DataSet
        thisHunt = GetHunt(HuntId)


        Dim Frid, Dfrm, Dto, hnt, gst, ac, ad, cntId As String

        Try
            Frid = thisHunt.Tables(0).Rows(0).Item("FarmId").ToString.Trim
            Dfrm = thisHunt.Tables(0).Rows(0).Item("Date_From").ToString.Trim
            Dto = thisHunt.Tables(0).Rows(0).Item("Date_To").ToString.Trim
            hnt = thisHunt.Tables(0).Rows(0).Item("HunterPax").ToString.Trim
            lblStatus.Text = thisHunt.Tables(0).Rows(0).Item("Description").ToString.Trim
            If hnt = "" Then
                hnt = 0
            End If
            gst = thisHunt.Tables(0).Rows(0).Item("GuestPax").ToString.Trim
            If gst = "" Then
                gst = 0

            End If
            ac = thisHunt.Tables(0).Rows(0).Item("AccommValue").ToString.Trim
            ad = thisHunt.Tables(0).Rows(0).Item("AdditionalValue").ToString.Trim
            cntId = "1"
        Catch ex As Exception
            Response.Redirect("My_Hunts_App.aspx")
        End Try

        If Page.IsPostBack = False Then
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

                PopulateFarmAnimals(Frid, cntId)
                AddSpesies(HuntId)
                PlaceHolderBilling.Controls.Clear()
                PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))

                If lblStatus.Text.Trim = "Date Confirmed" Then
                    btnReserve.Text = "Pay Deposit"
                End If

            Else
                Response.Redirect("My_Hunts_App.aspx")
            End If
        End If
        PlaceHolderHunters.Controls.Clear()
        PlaceHolderHunters.Controls.Add(New LiteralControl(GetHuntMembersdiv(HuntId)))

        If lblStatus.Text = "Deposit Paid" Then
            Response.Redirect("CurrentHuntApp.aspx?h=" & Request.QueryString("h"))
        End If

    End Sub


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
            lblHunterType.Text = MemberDetails(4)
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
        str &= "  SELECT        MemberId, Surname, FullName, PreferredName, IDNo, PassportNr, CellNo, Email, MembershipExpire, HunterType"
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

        Dim MemberDetails(5) As String

        Try
            MemberDetails(0) = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim
            MemberDetails(1) = ds.Tables(0).Rows(0).Item("PreferredName").ToString.Trim & " " & ds.Tables(0).Rows(0).Item("Surname").ToString.Trim
            MemberDetails(2) = ds.Tables(0).Rows(0).Item("CellNo").ToString.Trim
            MemberDetails(3) = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
            MemberDetails(4) = ds.Tables(0).Rows(0).Item("HunterType").ToString.Trim
        Catch ex As Exception
            MemberDetails(0) = "na"
        End Try


        Return MemberDetails

    End Function
    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        InsertMembers(HuntId, True)
        lblNameToAdd.Text = ""
        lblCellToAdd.Text = ""
        lblEmailtoAdd.Text = ""
        pnlMemberDetails.Visible = False
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim HunterType As String = DropDownList1.SelectedValue.Trim
        Dim HunterGuest As String = "Hunter"
        If HunterType.Trim = "Guest" Then
            HunterGuest = "Guest"
            HunterType = " "
        End If

        InsertMembers(HuntId, False)

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
        str &= "                          tbl_Farm_Animal.Trophy_Price, tbl_Farm_Animal.Inches, tbl_Farm_Animal.Visiting_Country, tbl_Farm_Animal.Active"
        str &= " FROM            tbl_Farm_Animal INNER JOIN"
        str &= "                          tbl_Animals ON tbl_Farm_Animal.AnimalId = tbl_Animals.id INNER JOIN"
        str &= "                          tbl_Animal_Groups ON tbl_Animals.Animal_Group = tbl_Animal_Groups.groupId"
        str &= " WHERE        (tbl_Farm_Animal.FarmId = @FarmId) AND (tbl_Farm_Animal.Active = 'True') AND (tbl_Farm_Animal.AvailableToHunt = 'True') AND (tbl_Farm_Animal.Visiting_Country = @VisitingCountry)"
        str &= " ORDER BY tbl_Animal_Groups.Description, tbl_Animals.Name"

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
        Dim DepositAmount As Double = AccommodationValue * (DepositPercent / 100)
        Dim DepositYour As Double = AccommodationValueYour * (DepositPercent / 100)



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
        imgFarm.ImageUrl = "../Farms/Images/FarmProfiles/" & FarmId & "Main.jpg"
        HiddenFieldDepositPercentage.Value = ds.Tables(0).Rows(0).Item("DepositPercentage").ToString.Trim
        HiddenFieldDepositPeriod.Value = ds.Tables(0).Rows(0).Item("DepositPeriod").ToString.Trim
    End Sub
    Protected Sub btnReserve_Click(sender As Object, e As EventArgs) Handles btnReserve.Click
        If btnReserve.Text = "Reserve" Then
            Dim HuntId As String = InitialHuntSave()
            Response.Redirect("Reserve_Confirm_App.aspx?HuntId=" & HuntId)
        ElseIf btnReserve.Text = "Pay Deposit" Then
            Response.Redirect("~/Payment/PaymentConfirmationApp.aspx?h=" & Request.QueryString("h"))
        End If

    End Sub


    Private Function InitialHuntSave() As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@FarmId", CInt(HiddenFieldFarmId.Value))
        cmd.Parameters.AddWithValue("@Main_Member_Id", CInt(Request.Cookies("memberid").Value))
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



        Dim str As String = ""
        str &= " INSERT INTO tbl_Hunts "
        str &= " (FarmId, Main_Member_Id, Date_From, Date_To, TotalDue, DepositValue, DepositDue, FinalPayment, AccommValue, AdditionalValue, SpeciesValue, ExtraValue, CountryId, UniqueName, HunterPax, GuestPax, Status, PercDepositPaid)"
        str &= " VALUES"
        str &= " (@FarmId, @Main_Member_Id, @Date_From, @Date_To, @TotalDue, @DepositValue, @DepositDue, @FinalPayment, @AccommValue, @AdditionalValue, @SpeciesValue, @ExtraValue, @CountryId, @UniqueName, @HunterPax, @GuestPax, 1,0)"
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

            SaveSpecies(ds.Tables(0).Rows(0).Item(0).ToString.Trim)
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        Return ds.Tables(0).Rows(0).Item(0).ToString.Trim

    End Function

    Private Sub InsertMembers(huntersId As String, EcoMember As Boolean)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim huntType As String = ""
        cmd.Parameters.AddWithValue("@Hunts_Id", huntersId)

        If EcoMember = True Then
            cmd.Parameters.AddWithValue("@MemberId", lblId2Add.Text.Trim)
            If RadioButtonList1.SelectedValue = "Guest" Then
                huntType = "Guest"
            Else
                huntType = lblHunterType.Text.Trim
            End If
            If CheckBox2.Checked Then
                cmd.Parameters.AddWithValue("@OwnAccount", "True")
                cmd.Parameters.AddWithValue("@AccomValue", CDbl(HiddenFieldAccomValue.Value) / CDbl(lblTotalParty.Text))

                cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(HiddenFieldAdditionalValue.Value) / CDbl(lblTotalParty.Text))
                cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(0))
                cmd.Parameters.AddWithValue("@ExtraValue", CDbl(0))
                cmd.Parameters.AddWithValue("@FlightId", 0)
                cmd.Parameters.AddWithValue("@CarId", 0)
                cmd.Parameters.AddWithValue("@DepositValue", CDbl(HiddenFieldDepositValue.Value) / CDbl(lblTotalParty.Text))
                cmd.Parameters.AddWithValue("@FinalValue", CDbl(HiddenFieldFinalPayment.Value) / CDbl(lblTotalParty.Text))
            Else
                cmd.Parameters.AddWithValue("@OwnAccount", "False")
                cmd.Parameters.AddWithValue("@AccomValue", CDbl(0))

                cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(0))
                cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(0))
                cmd.Parameters.AddWithValue("@ExtraValue", CDbl(0))
                cmd.Parameters.AddWithValue("@FlightId", 0)
                cmd.Parameters.AddWithValue("@CarId", 0)
                cmd.Parameters.AddWithValue("@DepositValue", CDbl(0))
                cmd.Parameters.AddWithValue("@FinalValue", CDbl(0))
            End If
            cmd.Parameters.AddWithValue("@Name", lblNameToAdd.Text.Trim)
            cmd.Parameters.AddWithValue("@Mobil", lblCellToAdd.Text.Trim)
            cmd.Parameters.AddWithValue("@Email", lblEmailtoAdd.Text)

        Else
            cmd.Parameters.AddWithValue("@MemberId", "")

            Dim HunterType As String = DropDownList1.SelectedValue.Trim
            Dim HunterGuest As String = "Hunter"
            If HunterType.Trim = "Guest" Then
                HunterGuest = "Guest"
                HunterType = " "
            End If



            huntType = HunterType




            cmd.Parameters.AddWithValue("@OwnAccount", "False")
            cmd.Parameters.AddWithValue("@AccomValue", CDbl(0))

            cmd.Parameters.AddWithValue("@AdditionalValue", CDbl(0))
            cmd.Parameters.AddWithValue("@SpeciesValue", CDbl(0))
            cmd.Parameters.AddWithValue("@ExtraValue", CDbl(0))
            cmd.Parameters.AddWithValue("@FlightId", 0)
            cmd.Parameters.AddWithValue("@CarId", 0)
            cmd.Parameters.AddWithValue("@DepositValue", CDbl(0))
            cmd.Parameters.AddWithValue("@FinalValue", CDbl(0))
            cmd.Parameters.AddWithValue("@Name", txtNonMemberName.Text.Trim)
            cmd.Parameters.AddWithValue("@Mobil", "")
            cmd.Parameters.AddWithValue("@Email", "")
        End If

        cmd.Parameters.AddWithValue("@Type", huntType)
        cmd.Parameters.AddWithValue("@CountryId", CInt(HiddenFieldFarmId.Value))

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
        PlaceHolderHunters.Controls.Clear()
        PlaceHolderHunters.Controls.Add(New LiteralControl(GetHuntMembersdiv(HuntId)))
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

    Private Function GetHunt(HuntId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)

        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.FarmId, tbl_Hunts.Main_Member_Id, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts.HunterPax, tbl_Hunts.GuestPax, tbl_Hunts.TotalDue, tbl_Hunts.DepositValue, tbl_Hunts.DepositDue, "
        str &= "                          tbl_Hunts.FinalPayment, tbl_Hunts.AccommValue, tbl_Hunts.AdditionalValue, tbl_Hunts.SpeciesValue, tbl_Hunts.ExtraValue, tbl_Hunts.CountryId, tbl_Hunts.UniqueName, tbl_Hunts.FlightId, tbl_Hunts.CarId, tbl_Hunts.Status, "
        str &= "                          tbl_Hunts.PercDepositPaid, tbl_Hunts_Status.Description, tbl_Farm.FarmName"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId INNER JOIN"
        str &= "                          tbl_Farm ON tbl_Hunts.FarmId = tbl_Farm.id"
        str &= "  WHERE        (tbl_Hunts.HuntId = @HuntId)"

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

        Return ds

    End Function
    Private Function GetHuntMembersdiv(huntId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", huntId.Trim)

        Dim str As String = ""
        str &= " SELECT        Id, Hunts_Id, MemberId, Type, OwnAccount, Name, Mobil, Email, AccomValue, AdditionalValue, SpeciesValue, ExtraValue, CountryId, FlightId, CarId, DepositValue, FinalValue, DepositPaid, Status"
        str &= " FROM            tbl_Hunts_Members"
        str &= "  WHERE        (Hunts_Id = @HuntId)"

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

        Dim htmlString As String = ""

        Dim count As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp As Integer
        Dim HunterGuest As String = ""
        Dim AccountType As String

        Dim TotalPax As Integer = 0
        Dim HunterPax As Integer = 0
        Dim GuestPax As Integer = 0
        Dim OwnAccountPax As Integer = 0

        For sp = 0 To count

            If ds.Tables(0).Rows(sp).Item("MemberId").ToString.Trim = MemberId Then
                AccountType = "Your Account"
                OwnAccountPax += 1
            Else
                If ds.Tables(0).Rows(sp).Item("OwnAccount").ToString.Trim = "True" Then
                    AccountType = "Own Account"
                Else
                    AccountType = "Your Account"
                    OwnAccountPax += 1
                End If
            End If



            If ds.Tables(0).Rows(sp).Item("Type").ToString.Trim = "Guest" Then
                HunterGuest = "Guest"
                GuestPax += 1
            Else
                HunterGuest = "Hunter"
                HunterPax += 1
            End If
            TotalPax += 1

            htmlString &= " <div style='border-width: thin; border-color: #CCCCCC; padding-left: 10px; padding-top: 5px; padding-bottom: 5px; border-bottom-style: solid;'>"
            htmlString &= "                 <div style='display: inline-block; width: 60%'>"
            htmlString &= "                     <div style='font-weight: bold'>"
            htmlString &= ds.Tables(0).Rows(sp).Item("Name").ToString.Trim
            htmlString &= "                     </div>"
            htmlString &= "                     <div>"
            htmlString &= ds.Tables(0).Rows(sp).Item("Type").ToString.Trim
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
            htmlString &= " <div>"
            htmlString &= ds.Tables(0).Rows(sp).Item("Status").ToString.Trim
            htmlString &= " </div>"
            htmlString &= "                 </div>"
            htmlString &= " </div>"

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
            lblSplit.Visible = False
        Else
            btnAddMember.Enabled = True
            lblSplit.Visible = True
        End If


        HiddenFieldOwnAccountQty.Value = OwnAccountPax

        PlaceHolderBilling.Controls.Clear()
        PlaceHolderBilling.Controls.Add(New LiteralControl(GetBillingBody))

        Return htmlString

    End Function


    Private Sub AddSpesies(huntId As String)

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", huntId.Trim)
        cmd.Parameters.AddWithValue("@MemberId", MemberId.Trim)

        Dim str As String = ""
        str &= " SELECT        tbl_Hunts_Species.HuntsId, tbl_Hunts_Species.Billable_Member_Id, tbl_Hunts_Species.Farm_Animal_Id AS id, tbl_Hunts_Species.Qty, tbl_Hunts_Species.UnitCost AS Price, tbl_Hunts_Species.TotalCost AS Total, "
        str &= "                          tbl_Animals.Name, tbl_Hunts_Species.Sex"
        str &= " FROM            tbl_Hunts_Species INNER JOIN"
        str &= "                          tbl_Farm_Animal ON tbl_Hunts_Species.Farm_Animal_Id = tbl_Farm_Animal.id INNER JOIN"
        str &= "                       tbl_Animals ON tbl_Farm_Animal.AnimalId = tbl_Animals.id"
        str &= " where tbl_Hunts_Species.HuntsId = @HuntId and tbl_Hunts_Species.Billable_Member_Id = @MemberId"

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

End Class
