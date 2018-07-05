Imports System.Data
Partial Class Outfitters_View_App
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet
    Dim thisalbumType, thisid As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            HiddenFarmId.Value = Request.QueryString("id")
        Catch ex As Exception
            HiddenFarmId.Value = "1"
        End Try

        If HiddenFarmId.Value = "" Then
            HiddenFarmId.Value = "1"
        End If

        If Page.IsPostBack = False Then
            GetinitialData()
        End If
        PlaceHolder1.Controls.Add(New LiteralControl(GetGeninfo))

        PlaceHolderLodges.Controls.Add(New LiteralControl(getLodgehtml()))


        btnFarmDescription.OnClientClick = "javascript:window.history.go(-1);return false;"
    End Sub

    Private Function GetinitialData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        id, FarmName, Country, Province, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, UseBookingSystem, BookingContactName, "
        str &= "                          BookingContactSurname, BookingEmail, BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, "
        str &= "                          Owner_Res_StreetName, Owner_Res_StreetNo, Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status, Loadedby, Website, Facebook"
        str &= " FROM            tbl_Outfitter"
        str &= " WHERE        (id = @id)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tbl_Outfitterrr")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try


        lblHeading.Text = ds.Tables(0).Rows(0).Item("FarmName").ToString.Trim


        Dim SavePath As String = ""
        Dim pathname As String = "Farms\Images\FarmProfiles\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot

        If System.IO.File.Exists(SavePath & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "Main.jpg") Then
            Image1.ImageUrl = "~/Farms/Images/FarmProfiles/" & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "Main.jpg"
        Else
            Image1.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "SideTop.jpg") Then
            Image2.ImageUrl = "~/Farms/Images/FarmProfiles/" & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "SideTop.jpg"
        Else
            Image2.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "SideMiddel.jpg") Then
            Image3.ImageUrl = "~/Farms/Images/FarmProfiles/" & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "SideMiddel.jpg"
        Else
            Image3.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "SideBottom.jpg") Then
            Image4.ImageUrl = "~/Farms/Images/FarmProfiles/" & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "SideBottom.jpg"
        Else
            Image4.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If

        dsInfo = ds

        Return ds
    End Function
    Private Function GetGenInfoData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT tbl_Outfitter.id, tbl_Outfitter.FarmName, tbl_Outfitter.Country, tbl_Outfitter.Province, tbl_Outfitter.ClosestTown, tbl_Outfitter.GPS_Longitude, tbl_Outfitter.GPS_Latitude, tbl_Outfitter.Short_Description, tbl_Outfitter.Long_Description,  "
        str &= " tbl_Outfitter.TelNo, tbl_Outfitter.CellNo, tbl_Outfitter.Email, tbl_Outfitter.CompanyName, tbl_Outfitter.CompanyRegNo, tbl_Outfitter.UseBookingSystem, tbl_Outfitter.BookingContactName, tbl_Outfitter.BookingContactSurname,  "
        str &= " tbl_Outfitter.BookingEmail, tbl_Outfitter.BookingCell, tbl_Outfitter.OwnerName, tbl_Outfitter.OwnerSurname, tbl_Outfitter.OwnerTitle, tbl_Outfitter.OwnerInitials, tbl_Outfitter.OwnerPreferredNAme, tbl_Outfitter.OwnerIdNo,  "
        str &= " tbl_Outfitter.OwnerGender, tbl_Outfitter.OwnerNationality, tbl_Outfitter.OwnerPassportNo, tbl_Outfitter.OwnerEmail, tbl_Outfitter.Owner_Res_StreetName, tbl_Outfitter.Owner_Res_StreetNo,  "
        str &= " tbl_Outfitter.Owner_Res_ComplexName, tbl_Outfitter.Owner_Res_ComplexNo, tbl_Outfitter.Owner_Res_Suburb, tbl_Outfitter.Owner_Res_Province, tbl_Outfitter.Owner_Res_PostalCode, tbl_Outfitter.Status, tbl_Outfitter.Loadedby, "
        str &= " tbl_Outfitter.Website, tbl_Outfitter.Facebook, tblCountries.Name, tblProvince.Name As Expr1 "
        str &= " FROM tbl_Outfitter LEFT OUTER JOIN "
        str &= " tblProvince On tbl_Outfitter.Province = tblProvince.ProvinceId LEFT OUTER JOIN "
        str &= " tblCountries ON tbl_Outfitter.Country = tblCountries.Country_Id "
        str &= " WHERE (tbl_Outfitter.id = @id) "


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tbl_Outfitter")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try





        dsInfo = ds

        Return ds
    End Function
    Private Function GetGeninfo() As String
        Try
            If dsInfo.Tables(0).Rows.Count = 0 Then
                GetGenInfoData()
            End If
        Catch ex As Exception
            GetGenInfoData()
        End Try
        Dim htmlString As String = ""
        htmlString &= " <div id='divInfo'>"
        htmlString &= "     <div id='divTabs'>"
        htmlString &= "         <div id='divTab_GenInfo' class='tab_Left' onclick=""ToggleDetails('GenInfo')"" style='cursor: pointer; background-color: #FFFFFF;' >General Information</div>"
        htmlString &= "         <div style='display:inline-block;' class='auto-style11'>&nbsp;</div>"
        htmlString &= "     </div>"
        htmlString &= "     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "         <div id='div_info_Terms'>"
        htmlString &= "             <div>&nbsp;</div>"
        Try
            htmlString &= "         <div Style='padding-left:10px'>"
            Dim longText As String = dsInfo.Tables(0).Rows(0).Item("Long_Description").ToString.Trim
            If longText = "" Then
                longText = dsInfo.Tables(0).Rows(0).Item("Short_Description").ToString.Trim
            End If
            longText = longText.Replace("" & vbCrLf & vbCrLf & "", "</br></br>")
            htmlString &= longText
            htmlString &= "         </div>"
        Catch ex As Exception

        End Try
        htmlString &= "             <div>&nbsp;</div>"
        htmlString &= "             <div>"
        htmlString &= "                 <div style='border-top-style: solid; border-width: thin; border-color: #333333'>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                 </div>"
        htmlString &= "             </div>"
        htmlString &= "         </div>"
        htmlString &= "     </div>"
        htmlString &= " </div>"
        Return htmlString
    End Function



    Private Function getLodgehtml() As String
        Dim htmlString As String = ""

        Dim dsLodges As New DataSet
        dsLodges = GetLodges()
        Dim dsItems As New DataSet
        Dim count As Integer
        Dim LodgeId As String = ""
        count = dsLodges.Tables(0).Rows.Count - 1

        htmlString &= " <div style='font-family: Calibri; font-size: 14px; color: #333333'>"
        If count > -1 Then
            For sp = 0 To count
                LodgeId = dsLodges.Tables(0).Rows(sp).Item("id").ToString.Trim
                htmlString &= "              <div style='background-color: #9AB37A; color: #FFFFFF; font-size: large; font-family: Calibri; ' id='divLocationHdr1' class='auto-style2' onclick=""ToggleDetails('divLodge " & LodgeId & "','LodgeImgDown " & LodgeId & "','LodgeImgUp " & LodgeId & "')"">"
                htmlString &= "                         <div style='display: inline-block' class='auto-style8'>" & dsLodges.Tables(0).Rows(sp).Item("FarmName").ToString.Trim & "</div>"
                htmlString &= "                         <div style='display: inline-block'>"
                htmlString &= "                             <asp:Image ID='imgFarmId' runat='server' ImageUrl='~/Images/Icons/numDown1.png' /> "
                htmlString &= "                                 <img id='LodgeImgDown " & LodgeId & "' alt='' src='../Images/Icons/numDown.png' />"
                htmlString &= "                                 <img id='LodgeImgUp " & LodgeId & "' alt='' src='../Images/Icons/numUp.png' style='display:none;' />"
                htmlString &= "                         </div>"

                htmlString &= "                     </div>"
                htmlString &= "             <div id='divLodge " & LodgeId & "' style='width:100%; display:none;'>"
                htmlString &= "                 <div style='font-size: 16px; font-weight: bold'>" & dsLodges.Tables(0).Rows(sp).Item("Expr1").ToString.Trim & " (" & dsLodges.Tables(0).Rows(sp).Item("Name").ToString.Trim & ")</div>"
                htmlString &= "                 <div class='spacer'>&nbsp;</div>"
                htmlString &= "                 <div style='border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;'  class='auto-style3' onclick=""ToggleDetails('dailyrates " & LodgeId & "','dalyratesImgDown " & LodgeId & "','dalyratesImgUp " & LodgeId & "')"">"
                htmlString &= "                             <div style='display: inline-block' class='auto-style5'>"
                htmlString &= "                                 <img alt='' src='../Images/Icons/numDown1.png' />&nbsp; Daily Rates"
                htmlString &= "                             </div>"
                htmlString &= "                             <div style='display: inline-block'>"

                htmlString &= "                                 <img id='dalyratesImgDown " & LodgeId & "' alt='' src='../Images/Icons/numDown.png' />"
                htmlString &= "                                 <img id='dalyratesImgUp " & LodgeId & "' alt='' src='../Images/Icons/numUp.png' style='display:none;' />"
                htmlString &= "                             </div>"

                htmlString &= "                         </div>"
                htmlString &= "                 <div id='dailyrates " & LodgeId & "' style='display:none;'  >"


                Dim dsDailyRates As DataSet = GetDailyRates(dsLodges.Tables(0).Rows(sp).Item("id").ToString.Trim)
                If dsDailyRates.Tables(0).Rows.Count > 0 Then
                    For Each myRow As DataRow In dsDailyRates.Tables(0).Rows
                        htmlString &= "                 <div style='padding: 10px;'>"
                        htmlString &= "                     <div class='divMngForm'>" & myRow.Item("RateName").ToString.Trim & "</div>"
                        htmlString &= "                     <div class='divMngForm'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>"
                        htmlString &= "                     <div class='divMngForm'>" & myRow.Item("Rate").ToString.Trim & "</div>"
                        htmlString &= "                     <div class='divMngForm'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>"
                        htmlString &= "                     <div class='divMngForm'>" & myRow.Item("PerDay").ToString.Trim & " days</div>"
                        htmlString &= "                 </div>"
                    Next
                Else
                    htmlString &= "                 <div style='padding: 10px;'>No daily rates recorded.</div>"
                End If


                htmlString &= "                 </div>"
                htmlString &= "                 <div class='spacer'>&nbsp;</div>"
                htmlString &= "                  <div style='border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;'  class='auto-style3' onclick=""ToggleDetails('Accomrates " & LodgeId & "','AccomratesImgDown " & LodgeId & "','AccomratesImgUp " & LodgeId & "')"">"
                htmlString &= "                             <div style='display: inline-block' class='auto-style5'>"
                htmlString &= "                                 <img alt='' src='../Images/Icons/numDown1.png' />&nbsp; Accommodation Rates"
                htmlString &= "                             </div>"
                htmlString &= "                             <div style='display: inline-block'>"
                htmlString &= "                                 <img id='AccomratesImgDown " & LodgeId & "' alt='' src='../Images/Icons/numDown.png' />"
                htmlString &= "                                 <img id='AccomratesImgUp " & LodgeId & "' alt='' src='../Images/Icons/numUp.png' style='display:none;' />"
                htmlString &= "                             </div>"

                htmlString &= "                         </div>"
                htmlString &= "                 <div id='Accomrates " & LodgeId & "' style='display:none;' >"

                Dim dsAccomRates As DataSet = GetAccomRates(dsLodges.Tables(0).Rows(sp).Item("id").ToString.Trim)
                If dsAccomRates.Tables(0).Rows.Count > 0 Then
                    For Each myRow1 As DataRow In dsAccomRates.Tables(0).Rows
                        htmlString &= "                 <div style='padding: 10px;'>"
                        htmlString &= "                     <div class='divMngForm'>" & myRow1.Item("RateName").ToString.Trim & "</div>"
                        htmlString &= "                     <div class='divMngForm'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>"
                        htmlString &= "                     <div class='divMngForm'>" & myRow1.Item("Rate").ToString.Trim & "</div>"
                        htmlString &= "                     <div class='divMngForm'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>"
                        htmlString &= "                     <div class='divMngForm'>" & myRow1.Item("PerDay").ToString.Trim & " days</div>"
                        htmlString &= "                 </div>"
                    Next
                Else
                    htmlString &= "                 <div style='padding: 10px;'>No accommodation rates recorded.</div>"
                End If

                htmlString &= "                 </div>"
                htmlString &= "                 <div class='spacer'>&nbsp;</div>"
                htmlString &= "                <div style='border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;'  class='auto-style3' onclick=""ToggleDetails('AccomGallery " & LodgeId & "','AccomGalleryImgDown " & LodgeId & "','AccomGalleryImgUp " & LodgeId & "')"">"
                htmlString &= "                             <div style='display: inline-block' class='auto-style5'>"
                htmlString &= "                                 <img alt='' src='../Images/Icons/numDown1.png' />&nbsp; Accommodatoin Gallery"
                htmlString &= "                             </div>"
                htmlString &= "                             <div style='display: inline-block'>"
                htmlString &= "                                  <img id='AccomGalleryImgDown " & LodgeId & "' alt='' src='../Images/Icons/numDown.png' />"
                htmlString &= "                                 <img id='AccomGalleryImgUp " & LodgeId & "' alt='' src='../Images/Icons/numUp.png' style='display:none;' />"
                htmlString &= "                             </div>"

                htmlString &= "                         </div>"
                htmlString &= "                 <div id='AccomGallery " & LodgeId & "' style='display:none;' >"

                Dim AlbumString As String = ""
                AlbumString = GetAlbumOutfitterAccommodation("AccomGallery", dsLodges.Tables(0).Rows(sp).Item("id").ToString.Trim)

                htmlString &= "                 <div style='padding: 10px;'>" & AlbumString & "</div>"

                htmlString &= "                 </div>"
                htmlString &= "                 <div class='spacer'>&nbsp;</div>"
                htmlString &= "                 <div style='border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;'  class='auto-style3' onclick=""ToggleDetails('DinnerGallery " & LodgeId & "','DinnerGalleryImgDown " & LodgeId & "','DinnerGalleryImgUp " & LodgeId & "')"">"
                htmlString &= "                             <div style='display: inline-block' class='auto-style5'>"
                htmlString &= "                                 <img alt='' src='../Images/Icons/numDown1.png' />&nbsp; Dinner Gallery"
                htmlString &= "                             </div>"
                htmlString &= "                             <div style='display: inline-block'>"
                htmlString &= "                                 <img id='DinnerGalleryImgDown " & LodgeId & "' alt='' src='../Images/Icons/numDown.png' />"
                htmlString &= "                                 <img id='DinnerGalleryImgUp " & LodgeId & "' alt='' src='../Images/Icons/numUp.png'  style='display:none;'/> "
                htmlString &= "                             </div>"

                htmlString &= "                         </div>"
                htmlString &= "                 <div id='DinnerGallery " & LodgeId & "' style='display:none;' >"

                AlbumString = GetAlbumOutfitterDinner("DinnerGallery", dsLodges.Tables(0).Rows(sp).Item("id").ToString.Trim)

                htmlString &= "                 <div style='padding: 10px;'>" & AlbumString & "</div>"
                htmlString &= "                 </div>"
                htmlString &= "                 <div class='spacer'>&nbsp;</div>"
                htmlString &= "                  <div style='border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;'  class='auto-style3' onclick=""ToggleDetails('packages " & LodgeId & "','packagesImgDown " & LodgeId & "','packagesImgUp " & LodgeId & "')"">"
                htmlString &= "                             <div style='display: inline-block' class='auto-style5'>"
                htmlString &= "                                 <img alt='' src='../Images/Icons/numDown1.png' />&nbsp; Packages"
                htmlString &= "                             </div>"
                htmlString &= "                             <div style='display: inline-block'>"
                htmlString &= "                                  <img id='packagesImgDown " & LodgeId & "' alt='' src='../Images/Icons/numDown.png' />"
                htmlString &= "                                 <img id='packagesImgUp " & LodgeId & "' alt='' src='../Images/Icons/numUp.png' style='display:none;' /> "
                htmlString &= "                             </div>"

                htmlString &= "                         </div>"
                htmlString &= "                 <div id='packages " & LodgeId & "'  style='display:none;'>"

                Dim dsPackages As DataSet = GetPackages(dsLodges.Tables(0).Rows(sp).Item("id").ToString.Trim)
                If dsPackages.Tables(0).Rows.Count > 0 Then
                    For Each myRow2 As DataRow In dsPackages.Tables(0).Rows
                        htmlString &= "                 <div style='padding: 10px;'>"
                        htmlString &= "                     <div class='divMngForm' style='width: 800px;' onclick=""location.href ='outfitter_package_view_app.aspx?packageId=" & myRow2.Item("PackageId").ToString.Trim & "'"" >" & myRow2.Item("Package").ToString.Trim & "</div>"
                        htmlString &= "                 </div>"
                    Next
                Else
                    htmlString &= "                 <div style='padding: 10px;'>No packages recorded.</div>"
                End If

                htmlString &= "                 </div>"
                htmlString &= "                 <div class='spacer'>&nbsp;</div>"

                htmlString &= "             </div>"
                htmlString &= "             <div class='spacer'>&nbsp;</div>"




            Next
        End If
        htmlString &= "       </div>"



        Return htmlString
    End Function

    Private Function GetLodges() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@OutfitterId", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT tbl_Outfitter_Lodges.id, tbl_Outfitter_Lodges.LodgeId, tbl_Outfitter_Lodges.OutfitterId, tbl_Farm.FarmName, tblCountries.Name, tblProvince.Name AS Expr1 "
        str &= " FROM tbl_Outfitter_Lodges INNER JOIN "
        str &= " tbl_Farm ON tbl_Outfitter_Lodges.LodgeId = tbl_Farm.id LEFT OUTER JOIN "
        str &= " tblProvince On tbl_Farm.Province = tblProvince.ProvinceId LEFT OUTER JOIN "
        str &= " tblCountries ON tbl_Farm.Country = tblCountries.Country_Id "
        str &= " WHERE (tbl_Outfitter_Lodges.OutfitterId = @OutfitterId) "


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



        Return ds
    End Function
    Private Function GetDailyRates(ByVal Outfitter_Lodge_Id As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", Outfitter_Lodge_Id.Trim)
        Dim str As String = ""

        str &= " SELECT RateName, Rate, PerDay FROM tbl_Outfitter_DailyRates WHERE (Outfitter_Lodge_Id = @Outfitter_Lodge_Id) "


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
    Private Function GetAccomRates(ByVal Outfitter_Lodge_Id As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", Outfitter_Lodge_Id.Trim)
        Dim str As String = ""

        str &= " SELECT RateName, Rate, PerDay FROM tbl_Outfitter_AccomRates WHERE (Outfitter_Lodge_Id = @Outfitter_Lodge_Id) "


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
    Private Function GetPackages(ByVal Outfitter_Lodge_Id As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Outfitter_Lodge_Id", Outfitter_Lodge_Id.Trim)
        Dim str As String = ""

        str &= " SELECT packageId, Package, farmId, Description, FromDate, ToDate FROM tbl_Outfitter_Packages WHERE (farmId = @Outfitter_Lodge_Id) AND (GETDATE() BETWEEN FromDate AND ToDate) "


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

#Region "Accommodation Gallery"
    Public Function GetAlbumOutfitterAccommodation(albumType As String, id As String) As String
        thisalbumType = albumType
        thisid = id
        Dim Albumstring As String = ""
        Albumstring = GetMainFoldersOutfitterAccommodation()
        Return Albumstring
    End Function
    Private Function GetMainFoldersOutfitterAccommodation() As String

        Dim ds As New DataSet
        ds = GetDisplayGalleryMainOutfitterAccommodation()

        Dim count As Integer = ds.Tables(0).Rows.Count - 1

        Dim HtmlString As String = ""
        HtmlString &= "<table align='left' width='100%'> "
        HtmlString &= "  <tr> "
        HtmlString &= "      <td> "
        HtmlString &= "          <table width='100%' align='center'> "
        HtmlString &= "              <tr> "
        HtmlString &= "                  <td valign='top'> "
        HtmlString &= "                      <table width='100%' align='center' border='0'> "
        For sp = 0 To count

            Dim ds1 As New DataSet
            ds1 = GetDisplayGallerySubutfitterAccommodation(ds.Tables(0).Rows(sp).Item("id"))

            Dim count1 As Integer = ds1.Tables(0).Rows.Count - 1

            HtmlString &= "                     <tr> "
            HtmlString &= "                         <td valign='top'> "
            HtmlString &= "                             <table width='100%' align='center' border='0'> "
            HtmlString &= "                                 <tr>"
            HtmlString &= "                                     <td valign='top' width='100%' style='border-bottom-style: solid; border-width: thin; border-color: #184D43'>"
            HtmlString &= "                                         <table width='100%'>"
            HtmlString &= "                                             <tr>"

            HtmlString &= "                                                 <td align='left' height='30'><input class='button' style='font-size: 40px;' type='button' value='" & ds.Tables(0).Rows(sp).Item("Name") & "' onclick=""toggle_visibility('" & sp & "', '" & count1 & "');"" /></td>"
            HtmlString &= "                                                 <td align='right'><a onclick=""toggle_visibility('" & sp & "', '" & count1 & "');"" style='cursor: pointer'>more</a></td>"
            HtmlString &= "                                             </tr>"

            For sp1 = 0 To count1
                Dim test1 As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim test2 As String = ds1.Tables(0).Rows(sp1).Item("Name")
                HtmlString &= "                                         <tr>"
                HtmlString &= "                                             <td colspan='2'>"
                HtmlString &= "                                                 <div id='" & sp & sp1 & "' style='display: none'>"
                HtmlString &= "                                                     <table width='100%' border='0'>"

                HtmlString &= "                                                         <tr>"
                HtmlString &= "                                                             <td style='background-color: #999999; color: #333333' align='left' valign='top'>&nbsp;&nbsp;&nbsp;<a onclick=""toggle_visibility('" & sp & sp1 & "a', '" & sp & "');"" style='cursor: pointer'>" & ds1.Tables(0).Rows(sp1).Item("Name") & "</a></td>"
                HtmlString &= "                                                         </tr>"

                If sp1 = 0 Then
                    HtmlString &= "                                                         <tr>"
                    HtmlString &= ds.Tables(0).Rows(sp).Item("Description")
                    HtmlString &= "                                                         </tr>"
                End If

                HtmlString &= "                                                         <tr>"
                HtmlString &= "                                                             <td align='left' valign='top'>"
                HtmlString &= "                                                                 <div id='" & sp & sp1 & "a" & sp & "' style='display: none'>"
                HtmlString &= "                                                                     <table width='100%' border='0' align='center'>"

                HtmlString &= "                                                         <tr>"
                HtmlString &= ds1.Tables(0).Rows(sp1).Item("Description")
                HtmlString &= "                                                         </tr>"

                HtmlString &= "                                                                         <tr>"
                HtmlString &= "                                                                             <td>" & GetPhotosOutfitterAccommodation(ds1.Tables(0).Rows(sp1).Item("subId"), ds.Tables(0).Rows(sp).Item("Name"), ds1.Tables(0).Rows(sp1).Item("Name")) & "</td>"
                HtmlString &= "                                                                         </tr>"
                HtmlString &= "                                                                     </table>"
                HtmlString &= "                                                                 </div>"
                HtmlString &= "                                                             </td>"
                HtmlString &= "                                                         </tr>"
                HtmlString &= "                                                     </table>"
                HtmlString &= "                                                 </div>"
                HtmlString &= "                                             </td>"
                HtmlString &= "                                         </tr>"
            Next
            HtmlString &= "                                         </table>"
            HtmlString &= "                                     </td>"
            HtmlString &= "                                 </tr>"
            HtmlString &= "                             </table> "
            HtmlString &= "                         </td> "
            HtmlString &= "                     </tr> "
        Next
        HtmlString &= "                      </table> "
        HtmlString &= "                  </td> "
        HtmlString &= "              </tr> "
        HtmlString &= "          </table> "
        HtmlString &= "      </td> "
        HtmlString &= "  </tr> "
        HtmlString &= "</table>"
        Return HtmlString

    End Function
    Private Function GetPhotosOutfitterAccommodation(ByVal subId As String, ByVal MainName As String, ByVal SubName As String) As String

        Dim ds As New DataSet
        ds = GetDisplayGalleryPhotosOutfitterAccommodation(subId.Trim)

        Dim count As Integer = ds.Tables(0).Rows.Count
        Dim sp As Integer = 0
        Dim mycounter As Integer = 3

        Dim HtmlString As String
        HtmlString = "<table align='center' border='0'> "
        HtmlString &= "     <tr>"
        For sp = 0 To count
            Try
                If sp = 3 Or sp = 6 Or sp = 9 Or sp = 12 Or sp = 15 Or sp = 18 Or sp = 21 Or sp = 24 Or sp = 27 Or sp = 30 Or sp = 33 Or sp = 36 Or sp = 39 Or sp = 42 Or sp = 45 Then
                    HtmlString &= "     </tr>"
                    HtmlString &= "     <tr><td colspan='2'>&nbsp;</td></tr>"
                    HtmlString &= "     <tr>"
                End If
                Dim url As String = ds.Tables(0).Rows(sp).Item("Url")
                Dim Name As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim photoId As String = ds.Tables(0).Rows(sp).Item("photoId")
                HtmlString &= "         <td height='275' valign='middle' align='center' bgcolor='#ffffff' width='240px'>"

                HtmlString &= " <a href='Outfitters/Albums/" & MainName.Trim & "/" & SubName.Trim & "/" & url & "' data-lightbox='" & SubName.Trim & "' data-title='" & Name & "'><Image  runat='server'  src='Outfitters/Albums/" & MainName.Trim & "/" & SubName.Trim & "/" & url & "' style='height: 225px; width: 225px'/></a>"


                HtmlString &= "             <br><span style='font-size:small;' class='HeaderLabel'>" & Name & "</span><br>"
                HtmlString &= "         </td>"
                HtmlString &= "         <td width='6px'>&nbsp;</td>"
            Catch ex As Exception
            End Try
        Next
        HtmlString &= "     </tr>"
        HtmlString &= "</table>"
        Return HtmlString

    End Function
    Private Function GetDisplayGalleryMainOutfitterAccommodation() As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM OutfitterGalleryMain WHERE FarmId = @id"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Private Function GetDisplayGallerySubutfitterAccommodation(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM OutfitterGallerySub WHERE (mainId = @mainId) AND FarmId = @id"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Private Function GetDisplayGalleryPhotosOutfitterAccommodation(ByVal subId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM OutfitterGalleryPhotos WHERE (subId = @subId) AND FarmId = @id"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
#End Region

#Region "Dinner Gallery"
    Public Function GetAlbumOutfitterDinner(albumType As String, id As String) As String
        thisalbumType = albumType
        thisid = id
        Dim Albumstring As String = ""
        Albumstring = GetMainFoldersOutfitterDinner()
        Return Albumstring
    End Function
    Private Function GetMainFoldersOutfitterDinner() As String

        Dim ds As New DataSet
        ds = GetDisplayGalleryMainOutfitterDinner()

        Dim count As Integer = ds.Tables(0).Rows.Count - 1

        Dim HtmlString As String = ""
        HtmlString &= "<table align='left' width='100%'> "
        HtmlString &= "  <tr> "
        HtmlString &= "      <td> "
        HtmlString &= "          <table width='100%' align='center'> "
        HtmlString &= "              <tr> "
        HtmlString &= "                  <td valign='top'> "
        HtmlString &= "                      <table width='100%' align='center' border='0'> "
        For sp = 0 To count

            Dim ds1 As New DataSet
            ds1 = GetDisplayGallerySubutfitterDinner(ds.Tables(0).Rows(sp).Item("id"))

            Dim count1 As Integer = ds1.Tables(0).Rows.Count - 1

            HtmlString &= "                     <tr> "
            HtmlString &= "                         <td valign='top'> "
            HtmlString &= "                             <table width='100%' align='center' border='0'> "
            HtmlString &= "                                 <tr>"
            HtmlString &= "                                     <td valign='top' width='100%' style='border-bottom-style: solid; border-width: thin; border-color: #184D43'>"
            HtmlString &= "                                         <table width='100%'>"
            HtmlString &= "                                             <tr>"

            HtmlString &= "                                                 <td align='left' height='30'><input class='button' style='font-size: 40px;' type='button' value='" & ds.Tables(0).Rows(sp).Item("Name") & "' onclick=""toggle_visibility('" & sp & "', '" & count1 & "');"" /></td>"
            HtmlString &= "                                                 <td align='right'><a onclick=""toggle_visibility('" & sp & "', '" & count1 & "');"" style='cursor: pointer'>more</a></td>"
            HtmlString &= "                                             </tr>"

            For sp1 = 0 To count1
                Dim test1 As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim test2 As String = ds1.Tables(0).Rows(sp1).Item("Name")
                HtmlString &= "                                         <tr>"
                HtmlString &= "                                             <td colspan='2'>"
                HtmlString &= "                                                 <div id='" & sp & sp1 & "' style='display: none'>"
                HtmlString &= "                                                     <table width='100%' border='0'>"

                HtmlString &= "                                                         <tr>"
                HtmlString &= "                                                             <td style='background-color: #999999; color: #333333' align='left' valign='top'>&nbsp;&nbsp;&nbsp;<a onclick=""toggle_visibility('" & sp & sp1 & "a', '" & sp & "');"" style='cursor: pointer'>" & ds1.Tables(0).Rows(sp1).Item("Name") & "</a></td>"
                HtmlString &= "                                                         </tr>"

                If sp1 = 0 Then
                    HtmlString &= "                                                         <tr>"
                    HtmlString &= ds.Tables(0).Rows(sp).Item("Description")
                    HtmlString &= "                                                         </tr>"
                End If

                HtmlString &= "                                                         <tr>"
                HtmlString &= "                                                             <td align='left' valign='top'>"
                HtmlString &= "                                                                 <div id='" & sp & sp1 & "a" & sp & "' style='display: none'>"
                HtmlString &= "                                                                     <table width='100%' border='0' align='center'>"

                HtmlString &= "                                                         <tr>"
                HtmlString &= ds1.Tables(0).Rows(sp1).Item("Description")
                HtmlString &= "                                                         </tr>"

                HtmlString &= "                                                                         <tr>"
                HtmlString &= "                                                                             <td>" & GetPhotosOutfitterDinner(ds1.Tables(0).Rows(sp1).Item("subId"), ds.Tables(0).Rows(sp).Item("Name"), ds1.Tables(0).Rows(sp1).Item("Name")) & "</td>"
                HtmlString &= "                                                                         </tr>"
                HtmlString &= "                                                                     </table>"
                HtmlString &= "                                                                 </div>"
                HtmlString &= "                                                             </td>"
                HtmlString &= "                                                         </tr>"
                HtmlString &= "                                                     </table>"
                HtmlString &= "                                                 </div>"
                HtmlString &= "                                             </td>"
                HtmlString &= "                                         </tr>"
            Next
            HtmlString &= "                                         </table>"
            HtmlString &= "                                     </td>"
            HtmlString &= "                                 </tr>"
            HtmlString &= "                             </table> "
            HtmlString &= "                         </td> "
            HtmlString &= "                     </tr> "
        Next
        HtmlString &= "                      </table> "
        HtmlString &= "                  </td> "
        HtmlString &= "              </tr> "
        HtmlString &= "          </table> "
        HtmlString &= "      </td> "
        HtmlString &= "  </tr> "
        HtmlString &= "</table>"
        Return HtmlString

    End Function
    Private Function GetPhotosOutfitterDinner(ByVal subId As String, ByVal MainName As String, ByVal SubName As String) As String

        Dim ds As New DataSet
        ds = GetDisplayGalleryPhotosOutfitterDinner(subId.Trim)

        Dim count As Integer = ds.Tables(0).Rows.Count
        Dim sp As Integer = 0
        Dim mycounter As Integer = 3

        Dim HtmlString As String
        HtmlString = "<table align='center' border='0'> "
        HtmlString &= "     <tr>"
        For sp = 0 To count
            Try
                If sp = 3 Or sp = 6 Or sp = 9 Or sp = 12 Or sp = 15 Or sp = 18 Or sp = 21 Or sp = 24 Or sp = 27 Or sp = 30 Or sp = 33 Or sp = 36 Or sp = 39 Or sp = 42 Or sp = 45 Then
                    HtmlString &= "     </tr>"
                    HtmlString &= "     <tr><td colspan='2'>&nbsp;</td></tr>"
                    HtmlString &= "     <tr>"
                End If
                Dim url As String = ds.Tables(0).Rows(sp).Item("Url")
                Dim Name As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim photoId As String = ds.Tables(0).Rows(sp).Item("photoId")
                HtmlString &= "         <td height='275' valign='middle' align='center' bgcolor='#ffffff' width='240px'>"

                HtmlString &= " <a href='Outfitters/Albums/" & MainName.Trim & "/" & SubName.Trim & "/" & url & "' data-lightbox='" & SubName.Trim & "' data-title='" & Name & "'><Image  runat='server'  src='Outfitters/Albums/" & MainName.Trim & "/" & SubName.Trim & "/" & url & "' style='height: 225px; width: 225px'/></a>"


                HtmlString &= "             <br><span style='font-size:small;' class='HeaderLabel'>" & Name & "</span><br>"
                HtmlString &= "         </td>"
                HtmlString &= "         <td width='6px'>&nbsp;</td>"
            Catch ex As Exception
            End Try
        Next
        HtmlString &= "     </tr>"
        HtmlString &= "</table>"
        Return HtmlString

    End Function
    Private Function GetDisplayGalleryMainOutfitterDinner() As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM OutfitterGalleryDinnerMain WHERE FarmId = @id"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Private Function GetDisplayGallerySubutfitterDinner(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM OutfitterGalleryDinnerSub WHERE (mainId = @mainId) AND FarmId = @id"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Private Function GetDisplayGalleryPhotosOutfitterDinner(ByVal subId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM OutfitterGalleryDinnerPhotos WHERE (subId = @subId) AND FarmId = @id"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
#End Region





End Class
