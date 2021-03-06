﻿Imports System.IO
Imports System.Data
Partial Class Farms_farm_Edit_Profile1
    Inherits System.Web.UI.Page

#Region "Main Shows"
    Protected Sub btnExoTourism_Click(sender As Object, e As EventArgs) Handles btnExoTourism.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
            imgecoTourism.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            Panel1.Visible = True
            imgecoTourism.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub

    Protected Sub btnFarmDescription_Click(sender As Object, e As EventArgs) Handles btnFarmDescription.Click
        If pnlFarmDesc.Visible = True Then
            pnlFarmDesc.Visible = False
            imgFarmDesc.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlFarmDesc.Visible = True
            imgFarmDesc.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnFacilities_Click(sender As Object, e As EventArgs) Handles btnFacilities.Click
        If divFacilitiesHdr.Visible = True Then
            divFacilitiesHdr.Visible = False
            imgFacilities.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            divFacilitiesHdr.Visible = True
            imgFacilities.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnGallery_Click(sender As Object, e As EventArgs) Handles btnGallery.Click
        If pnlGallery.Visible = True Then
            pnlGallery.Visible = False
            imgGallery.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlGallery.Visible = True
            imgGallery.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnHuntingSeason_Click(sender As Object, e As EventArgs) Handles btnHuntingSeason.Click
        If pnlHuntingSeason.Visible = True Then
            pnlHuntingSeason.Visible = False
            imgHuntingSeason.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlHuntingSeason.Visible = True
            imgHuntingSeason.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnhuntingTypes_Click(sender As Object, e As EventArgs) Handles btnhuntingTypes.Click
        If pnlHuntingTypes.Visible = True Then
            pnlHuntingTypes.Visible = False
            imgHuntingTypes.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlHuntingTypes.Visible = True
            imgHuntingTypes.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
    Protected Sub btnTerms_Click(sender As Object, e As EventArgs) Handles btnTerms.Click
        If pnlTerms.Visible = True Then
            pnlTerms.Visible = False
            imgTerms.ImageUrl = "~/Images/Icons/numDown1.png"
        Else
            pnlTerms.Visible = True
            imgTerms.ImageUrl = "~/Images/Icons/numUp1.png"
        End If
    End Sub
#End Region
#Region "Sub Shows"




    Protected Sub btnfarmDescDetail_Click(sender As Object, e As EventArgs) Handles btnfarmDescDetail.Click
        If divfarmDescDetail.Visible = True Then
            divfarmDescDetail.Visible = False
            imgfarmDescDetail.ImageUrl = "~/Images/Icons/numDown.png"
        Else
            divfarmDescDetail.Visible = True
            imgfarmDescDetail.ImageUrl = "~/Images/Icons/numUp.png"
        End If
    End Sub
    Protected Sub btnFeatures_Click(sender As Object, e As EventArgs) Handles btnFeatures.Click
        If pnlTerrain.Visible = True Then
            pnlTerrain.Visible = False
            imgTerrain.ImageUrl = "~/Images/Icons/numDown.png"
        Else
            pnlTerrain.Visible = True
            imgTerrain.ImageUrl = "~/Images/Icons/numUp.png"
        End If
    End Sub
    Protected Sub btnfacilitiesDetail_Click(sender As Object, e As EventArgs) Handles btnfacilitiesDetail.Click
        If pnlFacilitiesDetail.Visible = True Then
            pnlFacilitiesDetail.Visible = False
            imgFacilitiesDet.ImageUrl = "~/Images/Icons/numDown.png"
        Else
            pnlFacilitiesDetail.Visible = True
            imgFacilitiesDet.ImageUrl = "~/Images/Icons/numUp.png"
        End If
    End Sub
    Protected Sub btnSpecificFeature_Click(sender As Object, e As EventArgs) Handles btnSpecificFeature.Click
        If pnlSpecificFeatures.Visible = True Then
            pnlSpecificFeatures.Visible = False
            imgSpecific.ImageUrl = "~/Images/Icons/numDown.png"
        Else
            pnlSpecificFeatures.Visible = True
            imgSpecific.ImageUrl = "~/Images/Icons/numUp.png"
        End If
    End Sub
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Try
                lblFarmId.Text = Request.Cookies("MemberId").Value
                LoadFarmDetails()
                PopulateFacilities()
                PopulateHuntingTypes()
                PopulateGeneralInfo()
                PopulateHuntingMonths()
                PopulateEcoTourism()
                PopulateTerrain()
            Catch ex As Exception
                lblFarmId.Text = "1"
                LoadFarmDetails()
                PopulateFacilities()
                PopulateHuntingTypes()
                PopulateGeneralInfo()
                PopulateHuntingMonths()
                PopulateEcoTourism()
                PopulateTerrain()
            End Try

        End If
    End Sub

    Private Sub LoadFarmDetails()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        Dim str As String = ""
        str &= " SELECT        FarmName, Province, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, BookingContactName, BookingContactSurname, BookingEmail, "
        str &= "                          BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, Owner_Res_StreetName, Owner_Res_StreetNo, "
        str &= "                          Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status"
        str &= " FROM            tbl_Farm"
        str &= " WHERE        (id = @Id)"
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
        txtShortDescription.Text = ds.Tables(0).Rows(0).Item("Short_Description").ToString.Trim
        txtLongDescription.Text = ds.Tables(0).Rows(0).Item("Long_Description").ToString.Trim
        Try
            Image1.ImageUrl = "~/Farms/Images/FarmProfiles/" & lblFarmId.Text.Trim & "ProfilePic.jpg"
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PopulateFacilities()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        Dim str As String = ""
        str = " Select id, FarmId, FacilityId "
        str &= " FROM tbl_Farm_Facilities"
        str &= " WHERE  (FarmId = @Id) "

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
            lblFacilitySubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim count As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp, sp1 As Integer
        Dim Count1 As Integer = grdFacilities.Rows.Count - 1
        Dim dsItemId As String = ""
        Dim GrdItemId As String = ""
        Dim Facilitychecked As New CheckBox
        For sp = 0 To count
            dsItemId = ds.Tables(0).Rows(sp).Item("FacilityId").ToString.Trim
            For sp1 = 0 To Count1
                If dsItemId.Trim = grdFacilities.Rows(sp1).Cells(0).Text.Trim Then
                    Facilitychecked = grdFacilities.Rows(sp1).FindControl("ChkFacility")
                    Facilitychecked.Checked = True
                End If
            Next
        Next
    End Sub
    Private Sub PopulateHuntingTypes()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        Dim str As String = ""
        str = " Select id, FarmId, Hunting_Type_Id "
        str &= " FROM tbl_Farm_Hunting_Types"
        str &= " WHERE  (FarmId = @Id) "

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
            lblHuntingTypeSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim count As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp, sp1 As Integer
        Dim Count1 As Integer = grdHunting.Rows.Count - 1
        Dim dsItemId As String = ""
        Dim GrdItemId As String = ""
        Dim Huntingchecked As New CheckBox
        For sp = 0 To count
            dsItemId = ds.Tables(0).Rows(sp).Item("Hunting_Type_Id").ToString.Trim
            For sp1 = 0 To Count1
                If dsItemId.Trim = grdHunting.Rows(sp1).Cells(0).Text.Trim Then
                    Huntingchecked = grdHunting.Rows(sp1).FindControl("ChkHuntingType")
                    Huntingchecked.Checked = True
                End If
            Next
        Next
    End Sub
    Private Sub PopulateGeneralInfo()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        Dim str As String = ""
        str = " Select FarmId, MinimumHunterQty, ChildrenAllowed, OwnVehicleAlowed "
        str &= " FROM  tbl_Farm_Amentities"
        str &= " WHERE  (FarmId = @Id) "

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
            lblUpdateAmenitiesMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                cmbQtyHunters.SelectedValue = ds.Tables(0).Rows(0).Item("MinimumHunterQty").ToString.Trim
                chkChildren.Checked = ds.Tables(0).Rows(0).Item("ChildrenAllowed").ToString.Trim
                chkOwnVehicle.Checked = ds.Tables(0).Rows(0).Item("OwnVehicleAlowed").ToString.Trim
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PopulateHuntingMonths()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        Dim str As String = ""
        str = " Select FarmId, HuntingMonth, HuntingMonthInteger "
        str &= " FROM tbl_Farm_HuntingMonths"
        str &= " WHERE  (FarmId = @Id) "

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
            lblUpdateAmenitiesMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim count As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp As Integer

        For Each item In chckHuntingMonths.Items
            Dim ItemNr As String = item.Value
            Dim Checked As Boolean = item.selected
            Dim ItemName As String = item.Text

            For sp = 0 To count
                If ItemNr = ds.Tables(0).Rows(sp).Item("HuntingMonthInteger") Then
                    item.selected = True
                End If
            Next
        Next


    End Sub
    Private Sub PopulateEcoTourism()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        Dim str As String = ""
        str = " Select id, FarmId, EcoTourism_Id "
        str &= " FROM tbl_Farm_EcoTourism_Types"
        str &= " WHERE  (FarmId = @Id) "

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
            lblEcoTourismSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim count As Integer = ds.Tables(0).Rows.Count - 1
        Dim sp, sp1 As Integer
        Dim Count1 As Integer = grdEcoTourism.Rows.Count - 1
        Dim dsItemId As String = ""
        Dim GrdItemId As String = ""
        Dim EcoTourismchecked As New CheckBox
        For sp = 0 To count
            dsItemId = ds.Tables(0).Rows(sp).Item("EcoTourism_Id").ToString.Trim
            For sp1 = 0 To Count1
                If dsItemId.Trim = grdEcoTourism.Rows(sp1).Cells(0).Text.Trim Then
                    EcoTourismchecked = grdEcoTourism.Rows(sp1).FindControl("ChkEcoTourismType")
                    EcoTourismchecked.Checked = True
                End If
            Next
        Next
    End Sub
    Private Sub PopulateTerrain()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        Dim str As String = ""
        str = " Select FarmId, Hectares_withing_Gamingfence, Savannah_Perc, Mountains_Hills_Perc, Rivers, Natural_Lakes, Dam "
        str &= " FROM tbl_Farm_Terrain"
        str &= " WHERE  (FarmId = @Id) "

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
            lblUpdateTerrainMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                txtHectare.Text = ds.Tables(0).Rows(0).Item("Hectares_withing_Gamingfence").ToString.Trim
                txtSavannah.Text = ds.Tables(0).Rows(0).Item("Savannah_Perc").ToString.Trim
                txtMountains.Text = ds.Tables(0).Rows(0).Item("Mountains_Hills_Perc").ToString.Trim
                chkRivers.Checked = ds.Tables(0).Rows(0).Item("Rivers").ToString.Trim
                chkLakes.Checked = ds.Tables(0).Rows(0).Item("Natural_Lakes").ToString.Trim
                chkDam.Checked = ds.Tables(0).Rows(0).Item("Dam").ToString.Trim
            End If
        Catch ex As Exception

        End Try
    End Sub



#Region "Description"
    Protected Sub btnUpdateDescription_Click(sender As Object, e As EventArgs) Handles btnUpdateDescription.Click
        UpdateDescription()
    End Sub
    Private Sub UpdateDescription()
        lblDescriptionSubmitMesg.Text = ""
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)

        If txtShortDescription.Text.Length > 100 Then
            txtShortDescription.Text = txtShortDescription.Text.Substring(0, 97)
            txtShortDescription.Text &= "..."
        End If

        cmd.Parameters.AddWithValue("@Short_Description", txtShortDescription.Text.Trim)
        txtLongDescription.Text = txtLongDescription.Text.Replace("& vbCrLf", "CHAR(13)")
        cmd.Parameters.AddWithValue("@Long_Description", txtLongDescription.Text.Trim)

        Dim str As String = ""
        str &= " UPDATE tbl_Farm  SET Short_Description = @Short_Description, Long_Description = @Long_Description "
        str &= " WHERE        (id = @Id)"

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
            imgUpdateDescription.Visible = True
            ''ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "HideLabel();", True)
            'Page.ClientScript.RegisterStartupScript(Me.[GetType](), "somekey", "autoHide();", False)


        Catch ex As Exception
            lblDescriptionSubmitMesg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region
#Region "Terrain"
    Protected Sub btnUpdateTerrain_Click(sender As Object, e As EventArgs) Handles btnUpdateTerrain.Click
        lblUpdateTerrainMsg.Text = ""
        UpdateTerrain()
    End Sub
    Private Sub UpdateTerrain()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@Hectares_withing_Gamingfence", txtHectare.Text.Trim)
        cmd.Parameters.AddWithValue("@Savannah_Perc", txtSavannah.Text.Trim)
        cmd.Parameters.AddWithValue("@Mountains_Hills_Perc", txtMountains.Text.Trim)
        cmd.Parameters.AddWithValue("@Rivers", chkRivers.Checked)
        cmd.Parameters.AddWithValue("@Natural_Lakes", chkLakes.Checked)
        cmd.Parameters.AddWithValue("@Dam", chkDam.Checked)

        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Farm_Terrain  "
        str &= " WHERE FarmId = @FarmId) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Farm_Terrain"
        str &= " SET Hectares_withing_Gamingfence = @Hectares_withing_Gamingfence, Savannah_Perc = @Savannah_Perc, Mountains_Hills_Perc = @Mountains_Hills_Perc, Rivers = @Rivers, Natural_Lakes = @Natural_Lakes, Dam = @Dam "
        str &= " WHERE (FarmId = @FarmId) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= " tbl_Farm_Terrain"
        str &= " (FarmId, Hectares_withing_Gamingfence, Savannah_Perc, Mountains_Hills_Perc, Rivers, Natural_Lakes, Dam)"
        str &= " VALUES "
        str &= " (@FarmId, @Hectares_withing_Gamingfence, @Savannah_Perc, @Mountains_Hills_Perc, @Rivers, @Natural_Lakes, @Dam)"
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
            lblUpdateTerrainMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Facilities"

    Protected Sub btnUpdateFacilities_Click(sender As Object, e As EventArgs) Handles btnUpdateFacilities.Click
        lblFacilitySubmitMsg.Text = ""
        Dim count As Integer = grdFacilities.Rows.Count - 1
        Dim sp As Integer
        Dim Facilitychecked As New CheckBox
        Dim FacilityAdded As String = ""
        For sp = 0 To count
            FacilityAdded = CheckifFacilityIsthere(grdFacilities.Rows(sp).Cells(0).Text.Trim)
            Facilitychecked = grdFacilities.Rows(sp).FindControl("ChkFacility")
            If Facilitychecked.Checked Then
                If FacilityAdded = "False" Then
                    AddFacility(grdFacilities.Rows(sp).Cells(0).Text.Trim)
                End If
            Else
                If FacilityAdded = "True" Then
                    RemoveFacility(grdFacilities.Rows(sp).Cells(0).Text.Trim)
                End If
            End If
        Next

    End Sub
    Private Function CheckifFacilityIsthere(FacilityId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@FacilityId", FacilityId.Trim)

        Dim str As String = ""
        str = " Select id, FarmId, FacilityId "
        str &= " FROM tbl_Farm_Facilities"
        str &= " WHERE  (FarmId = @Id) AND (FacilityId = @FacilityId) "


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
            lblFacilitySubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim exist As String = ""

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                exist = "True"
            Else
                exist = "False"
            End If
        Catch ex As Exception

        End Try

        Return exist

    End Function
    Private Sub AddFacility(FacilityId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@FacilityId", FacilityId.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Farm_Facilities (FarmId, FacilityId) "
        str &= " VALUES "
        str &= " (@Id, @FacilityId) "


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
            lblDescriptionSubmitMesg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub RemoveFacility(FacilityId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@FacilityId", FacilityId.Trim)

        Dim str As String = ""
        str &= " Delete FROM tbl_Farm_Facilities  "
        str &= " WHERE  (FarmId = @Id) AND (FacilityId = @FacilityId) "


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
            lblDescriptionSubmitMesg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region
#Region "Profile Picture"
    Protected Sub btnUploadProfilePic_Click(sender As Object, e As EventArgs) Handles btnUploadProfilePic.Click
        Dim SavePath As String = ""
        Dim pathname As String = "Images\FarmProfiles\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot
        If System.IO.Directory.Exists(SavePath) Then
        Else
            System.IO.Directory.CreateDirectory(SavePath)
        End If

        Dim fileName As String = ""

        lblUploadMsg.Text = ""

        If (FileUpload1.HasFile) Then

            If System.IO.Directory.Exists(SavePath) Then
            Else
                System.IO.Directory.CreateDirectory(SavePath)
            End If
            Try
                If (FileUpload1.HasFile) Then

                    fileName = lblFarmId.Text & "ProfilePic.jpg"
                    SavePath += fileName
                    FileUpload1.SaveAs(SavePath)
                End If
                Image1.ImageUrl = "~/Farms/Images/FarmProfiles/" & fileName
            Catch ex As Exception
                lblUploadMsg.Text &= ex.Message
            End Try
        End If
    End Sub
#End Region

#Region "General Info"

    Protected Sub btnUpdateAmenities_Click(sender As Object, e As EventArgs) Handles btnUpdateAmenities.Click
        lblUpdateAmenitiesMsg.Text = ""
        UpdateAmenities()
        Dim CheckHuntingMonth As String

        For Each item In chckHuntingMonths.Items
            Dim ItemNr As String = item.Value
            Dim Checked As Boolean = item.selected
            Dim ItemName As String = item.Text

            CheckHuntingMonth = CheckifHuntingMonthIsthere(ItemNr)

            If Checked = True Then
                If CheckHuntingMonth = "False" Then
                    AddHuntingMonth(ItemName, ItemNr)
                End If
            ElseIf Checked = False Then
                If CheckHuntingMonth = "True" Then
                    RemoveHuntingMonth(ItemNr)
                End If

            End If
        Next
    End Sub
    Private Sub UpdateAmenities()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@MinimumHunterQty", cmbQtyHunters.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@ChildrenAllowed", chkChildren.Checked)
        cmd.Parameters.AddWithValue("@OwnVehicleAlowed", chkOwnVehicle.Checked)

        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM tbl_Farm_Amentities  "
        str &= " WHERE FarmId = @FarmId) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Farm_Amentities"
        str &= " SET MinimumHunterQty = @MinimumHunterQty, ChildrenAllowed = @ChildrenAllowed, OwnVehicleAlowed = @OwnVehicleAlowed "
        str &= " WHERE (FarmId = @FarmId) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= " tbl_Farm_Amentities"
        str &= " (FarmId, MinimumHunterQty, ChildrenAllowed, OwnVehicleAlowed)"
        str &= " VALUES "
        str &= " (@FarmId, @MinimumHunterQty, @ChildrenAllowed, @OwnVehicleAlowed)"
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
            lblUpdateAmenitiesMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Function CheckifHuntingMonthIsthere(HuntingMonthInteger As Integer) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@HuntingMonthInteger", HuntingMonthInteger)

        Dim str As String = ""
        str = " Select FarmId, HuntingMonth, HuntingMonthInteger "
        str &= " FROM  tbl_Farm_HuntingMonths"
        str &= " WHERE  (FarmId = @Id) AND (HuntingMonthInteger = @HuntingMonthInteger) "

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
            lblUpdateAmenitiesMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim exist As String = ""

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                exist = "True"
            Else
                exist = "False"
            End If
        Catch ex As Exception

        End Try

        Return exist

    End Function
    Private Sub AddHuntingMonth(HuntingMonth As String, HuntingMonthInteger As Integer)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@HuntingMonth", HuntingMonth.Trim)
        cmd.Parameters.AddWithValue("@HuntingMonthInteger", HuntingMonthInteger)
        Dim str As String = ""
        str &= " INSERT INTO  tbl_Farm_HuntingMonths (FarmId, HuntingMonth, HuntingMonthInteger) "
        str &= " VALUES "
        str &= " (@FarmId, @HuntingMonth, @HuntingMonthInteger) "

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
            lblUpdateAmenitiesMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub RemoveHuntingMonth(HuntingMonthInteger As Integer)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@HuntingMonthInteger", HuntingMonthInteger)

        Dim str As String = ""
        str &= " Delete FROM tbl_Farm_HuntingMonths  "
        str &= " WHERE  (FarmId = @Id) AND (HuntingMonthInteger = @HuntingMonthInteger) "

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
            lblUpdateAmenitiesMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region
#Region "Hunting"

    Protected Sub btnUpdateHunting_Click(sender As Object, e As EventArgs) Handles btnUpdateHunting.Click
        lblHuntingTypeSubmitMsg.Text = ""
        Dim count As Integer = grdHunting.Rows.Count - 1
        Dim sp As Integer
        Dim Huntingchecked As New CheckBox
        Dim HuntingAdded As String = ""
        For sp = 0 To count
            HuntingAdded = CheckifHuntingIsthere(grdHunting.Rows(sp).Cells(0).Text.Trim)
            Huntingchecked = grdHunting.Rows(sp).FindControl("ChkHuntingType")
            If Huntingchecked.Checked Then
                If HuntingAdded = "False" Then
                    AddHuntingType(grdHunting.Rows(sp).Cells(0).Text.Trim)
                End If
            Else
                If HuntingAdded = "True" Then
                    RemoveHuntingType(grdHunting.Rows(sp).Cells(0).Text.Trim)
                End If
            End If
        Next
    End Sub
    Private Function CheckifHuntingIsthere(HuntingId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@Hunting_Type_Id", HuntingId.Trim)

        Dim str As String = ""
        str = " Select FarmId, Hunting_Type_Id "
        str &= " FROM tbl_Farm_Hunting_Types"
        str &= " WHERE  (FarmId = @Id) AND (Hunting_Type_Id = @Hunting_Type_Id) "

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
            lblFacilitySubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim exist As String = ""

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                exist = "True"
            Else
                exist = "False"
            End If
        Catch ex As Exception

        End Try

        Return exist

    End Function
    Private Sub AddHuntingType(HuntingId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@Hunting_Type_Id", HuntingId.Trim)

        Dim str As String = ""
        str &= " INSERT INTO tbl_Farm_Hunting_Types (FarmId, Hunting_Type_Id) "
        str &= " VALUES "
        str &= " (@Id, @Hunting_Type_Id) "


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
            lblHuntingTypeSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub RemoveHuntingType(HuntingId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@Hunting_Type_Id", HuntingId.Trim)

        Dim str As String = ""
        str &= " Delete FROM tbl_Farm_Hunting_Types  "
        str &= " WHERE  (FarmId = @Id) AND (Hunting_Type_Id = @Hunting_Type_Id) "

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
            lblHuntingTypeSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region
#Region "Eco Tourism"

    Protected Sub btnUpdateEcoTourism_Click(sender As Object, e As EventArgs) Handles btnUpdateEcoTourism.Click
        lblEcoTourismSubmitMsg.Text = ""
        Dim count As Integer = grdEcoTourism.Rows.Count - 1
        Dim sp As Integer
        Dim EcoTourismchecked As New CheckBox
        Dim EcoTourismAdded As String = ""
        For sp = 0 To count
            EcoTourismAdded = CheckifEcoTourismIsthere(grdEcoTourism.Rows(sp).Cells(0).Text.Trim)
            EcoTourismchecked = grdEcoTourism.Rows(sp).FindControl("ChkEcoTourismType")
            If EcoTourismchecked.Checked Then
                If EcoTourismAdded = "False" Then
                    AddEcoTourismType(grdEcoTourism.Rows(sp).Cells(0).Text.Trim)
                End If
            Else
                If EcoTourismAdded = "True" Then
                    RemoveEcoTourismType(grdEcoTourism.Rows(sp).Cells(0).Text.Trim)
                End If
            End If
        Next
    End Sub
    Private Function CheckifEcoTourismIsthere(EcoTourismId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@EcoTourism_Id", EcoTourismId.Trim)

        Dim str As String = ""
        str = " Select FarmId, EcoTourism_Id "
        str &= " FROM  tbl_Farm_EcoTourism_Types"
        str &= " WHERE  (FarmId = @Id) AND (EcoTourism_Id = @EcoTourism_Id) "

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
            lblEcoTourismSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim exist As String = ""

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                exist = "True"
            Else
                exist = "False"
            End If
        Catch ex As Exception

        End Try

        Return exist

    End Function
    Private Sub AddEcoTourismType(EcoTourismId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@EcoTourism_Id", EcoTourismId.Trim)

        Dim str As String = ""
        str &= " INSERT INTO  tbl_Farm_EcoTourism_Types (FarmId, EcoTourism_Id) "
        str &= " VALUES "
        str &= " (@Id, @EcoTourism_Id) "


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
            lblEcoTourismSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub RemoveEcoTourismType(EcoTourismId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@EcoTourism_Id", EcoTourismId.Trim)

        Dim str As String = ""
        str &= " Delete FROM tbl_Farm_EcoTourism_Types  "
        str &= " WHERE  (FarmId = @Id) AND (EcoTourism_Id = @EcoTourism_Id) "

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
            lblEcoTourismSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Additional Services"












    Protected Sub btnAddAdditional_Click(sender As Object, e As EventArgs) Handles btnAddAdditional.Click
        openAddDiv()

    End Sub
    Protected Sub chkAddCharge_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddCharge.CheckedChanged
        If chkAddCharge.Checked Then
            divAdditionalCharge.Visible = True
        Else
            divAdditionalCharge.Visible = False
        End If
    End Sub
    Protected Sub btnUpdateAddService_Click(sender As Object, e As EventArgs) Handles btnUpdateAddService.Click
        UpdateService("")
    End Sub
    Private Sub UpdateService(lineId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", lineId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@ExtraServiceDescription", txtAdditServiceDesc.Text.Trim)
        cmd.Parameters.AddWithValue("@Chargeable", chkAddCharge.Checked)
        If chkAddCharge.Checked = False Then
            txtAdditPrice.Text = 0
        End If
        cmd.Parameters.AddWithValue("@Price", txtAdditPrice.Text.Trim)
        cmd.Parameters.AddWithValue("@Unit", txtAdditUnit.Text.Trim)


        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM  tbl_Farm_ExtraService  "
        str &= " WHERE FarmId = @FarmId AND id = @id) "
        str &= " BEGIN "
        str &= " UPDATE  tbl_Farm_ExtraService"
        str &= " SET ExtraServiceDescription = @ExtraServiceDescription, Chargeable = @Chargeable, Price = @Price, Unit = @Unit "
        str &= " WHERE (FarmId = @FarmId) AND (id = @id) "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT Into"
        str &= "  tbl_Farm_ExtraService"
        str &= " (FarmId, ExtraServiceDescription, Chargeable, Price, Unit)"
        str &= " VALUES "
        str &= " (@FarmId, @ExtraServiceDescription, @Chargeable, @Price, @Unit)"
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
            grdAddiotnalService.DataBind()
            ClearAdditional()
        Catch ex As Exception
            lblUpdateAddServiceMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub RemoveAdditionalService(LineId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@id", LineId)

        Dim str As String = ""
        str &= " Delete FROM  tbl_Farm_ExtraService  "
        str &= " WHERE  (FarmId = @FarmId) AND (id = @id) "

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
            grdAddiotnalService.DataBind()
        Catch ex As Exception
            lblUpdateAddServiceMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub grdAddiotnalService_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAddiotnalService.RowCommand
        If e.CommandName = "remove" Then
            RemoveAdditionalService(grdAddiotnalService.Rows(e.CommandArgument).Cells(0).Text.Trim)
        Else
            openAddDiv()
            PopulateIndividualService(grdAddiotnalService.Rows(e.CommandArgument).Cells(0).Text.Trim)

        End If




    End Sub
    Private Sub openAddDiv()
        If divAddService.Visible = False Then
            divAddService.Visible = True
        Else
            divAddService.Visible = False
        End If
    End Sub
    Private Sub PopulateIndividualService(LineId As String)

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@id", LineId)

        Dim str As String = ""
        str &= "SELECT id, FarmId, ExtraServiceDescription, Comment, Chargeable, Price, Unit  "
        str &= " FROM tbl_Farm_ExtraService "
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
            lblUpdateAddServiceMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try


        If ds.Tables(0).Rows.Count > 0 Then

            txtAdditServiceDesc.Text = ds.Tables(0).Rows(0).Item("ExtraServiceDescription").ToString.Trim
            chkAddCharge.Checked = ds.Tables(0).Rows(0).Item("Chargeable").ToString.Trim
            If chkAddCharge.Checked = True Then
                divAdditionalCharge.Visible = True
                txtAdditPrice.Text = ds.Tables(0).Rows(0).Item("Price").ToString.Trim
                txtAdditUnit.Text = ds.Tables(0).Rows(0).Item("Unit").ToString.Trim
            Else
                divAdditionalCharge.Visible = False
            End If

        End If



    End Sub
    Private Sub ClearAdditional()
        txtAdditServiceDesc.Text = ""
        txtAdditUnit.Text = ""
        txtAdditPrice.Text = ""
        chkAddCharge.Checked = False
        divAdditionalCharge.Visible = False
        divAddService.Visible = False
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        divAddService.Visible = False
    End Sub
#End Region

End Class
