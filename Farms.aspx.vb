Imports System.Data
Partial Class Farms
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim script As String = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });"
            Dim cs As ClientScriptManager = Page.ClientScript
            cs.RegisterStartupScript(Me.GetType, "load", script, True)
        End If
        If Page.IsPostBack = False Then
            Try
                Dim isloggedIn As String = Request.Cookies("UserId").Value.Trim
            Catch ex As Exception
                Response.Redirect("~/Login.aspx")
            End Try
            GetFavouriteCount()
        End If
        PlaceHolder3.Controls.Add(New LiteralControl(LoadAnimalQuery))
    End Sub
    Private Function ResultBody() As String

        Dim SavePath As String = ""

        Dim pathname As String = "Farms\Images\FarmProfiles\"
        Dim pathnameRoot As String

        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot

        Dim htmlString As String = ""

        Dim dsFarm As New DataSet
        dsFarm = GetFarms()

        Dim dsHunting As New DataSet
        Dim dsFacilities As New DataSet

        Dim farmCount As Integer = dsFarm.Tables(0).Rows.Count - 1
        Dim farmSp As Integer

        Dim huntCount, huntSp As Integer
        Dim FacilityCount, FacilitySp As Integer
        Dim ReviewCount As String = "0"
        Dim ratingValue() As String
        If farmCount > -1 Then

            For farmSp = 0 To farmCount

                dsHunting = GetHuntingTypes(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                huntCount = dsHunting.Tables(0).Rows.Count - 1
                dsFacilities = GetFacilitiesTypes(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                FacilityCount = dsFacilities.Tables(0).Rows.Count - 1

                htmlString &= "                    <div id='famrid" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & " ' class='div_Farm_Block'  >"

                htmlString &= "                         <div class='div_Picture_Style' onclick=""window.open('farm_view.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "&hntPax=" & txtHunterPax.Text.Trim & "&gstPx=" & txtGuestPax.Text.Trim & "&dtFrom=" & txtDateFrom.Text.Trim & "&dtTo=" & txtDateTo.Text.Trim & "', '_self')"">"

                If System.IO.File.Exists(SavePath & "/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg") Then
                    htmlString &= "                             <img alt='' src='Farms/Images/FarmProfiles/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg' class='image_Style' />"
                Else
                    htmlString &= "                             <img alt='' src='Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg' />"
                End If


                htmlString &= "                         </div>"
                htmlString &= "                         <div class='div_Middle_Block' onclick=""window.open('farm_view.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "&hntPax=" & txtHunterPax.Text.Trim & "&gstPx=" & txtGuestPax.Text.Trim & "&dtFrom=" & txtDateFrom.Text.Trim & "&dtTo=" & txtDateTo.Text.Trim & "', '_self')"">"
                htmlString &= "                             <div class='div_Farm_header'>" & dsFarm.Tables(0).Rows(farmSp).Item("FarmName").ToString.Trim & " &nbsp; (" & dsFarm.Tables(0).Rows(farmSp).Item("Name").ToString.Trim & ")</div>"
                htmlString &= "                             <div>&nbsp;</div>"
                htmlString &= "                             <div class='div_text_block'>"
                Dim ShortDescription As String = dsFarm.Tables(0).Rows(farmSp).Item("Short_Description").ToString.Trim
                If ShortDescription.Length > 430 Then
                    ShortDescription = ShortDescription.Substring(0, 430)
                    ShortDescription = ShortDescription & "..."
                End If
                htmlString &= ShortDescription
                htmlString &= "                             </div>"
                htmlString &= "                             <div>&nbsp;</div>"
                htmlString &= "                             <div>"


                For huntSp = 0 To huntCount
                    htmlString &= "                                 <div class='icon_style'>"
                    htmlString &= "                                     <img alt='' src='Images/Icons/Farm_Search/HuntType/" & dsHunting.Tables(0).Rows(huntSp).Item("IconPath").ToString.Trim & "' />"
                    htmlString &= "                                 </div>"
                Next


                htmlString &= "                             </div>"
                htmlString &= "                         </div>"



                htmlString &= "                         <div class='div_right_block'>"
                htmlString &= "                             <div>"

                ratingValue = GetRating(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)

                htmlString &= "                                 <div style='text-align: right;'>"

                htmlString &= "                                     <div style='display: inline-block;'>"

                For i = 0 To CInt(ratingValue(1)) - 1
                    htmlString &= "                                         <img alt='' src='Images/Icons/star.png' class='rateStar' />"
                Next

                htmlString &= "                                     </div>"
                If ratingValue(0) > 0 Then
                    htmlString &= "                                     <div style='display: inline-block; color: #CC0000;'>(" & ratingValue(0) & ")</div>"
                Else
                    htmlString &= "                                     <div style='display: inline-block; color: #CC0000;'>&nbsp;</div>"
                End If

                htmlString &= "                                 </div>"
                htmlString &= "                             </div>"
                htmlString &= "                             <div>"
                htmlString &= "                                 <div style='display: inline-block; width: 75px'>"
                Dim Price As String = GetPrices(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                If Price = "" Then
                    htmlString &= "                                     <div style='color: #CC0000'>&nbsp;</div>"
                    htmlString &= "                                     <div style='color: #CC0000; font-weight: bold'>&nbsp;</div>"
                Else
                    htmlString &= "                                     <div style='color: #CC0000'>from</div>"
                    htmlString &= "                                     <div style='color: #CC0000; font-weight: bold'>" & Price & "</div>"
                End If

                htmlString &= "                                 </div>"

                ReviewCount = GetReviewCount(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)

                htmlString &= "                                 <div style='display: inline-block; text-align: right; width: 120px'>"
                If CInt(ReviewCount) = "1" Then
                    htmlString &= "                                     <div style='display: inline-block; float: right'>" & ReviewCount & " Review</div>"
                Else
                    htmlString &= "                                     <div style='display: inline-block; float: right'>" & ReviewCount & " Reviews</div>"
                End If

                htmlString &= "                                 </div>"
                htmlString &= "                             </div>"
                If Price <> "" Then
                    htmlString &= "                             <div style='color: #CC0000'>&nbsp;</div>"
                Else
                    htmlString &= "                             <div style='color: #CC0000'>&nbsp;</div>"
                End If

                '''''Packages Available'''''
                If GetPackagesExpiryDates(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim) Then 'Is there any valid packages for this farm?
                    htmlString &= "                             <div style='padding-top: 5px; padding-bottom: 5px; cursor:pointer; color: #CC0000; font-weight: bold' onclick=""window.open('Packages.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "', '_self')"">Packages Available</div>"
                    htmlString &= "                             <div>&nbsp;</div>"
                Else
                    htmlString &= "                             <div style='padding-top: 5px; padding-bottom: 5px; '>&nbsp;</div>"
                End If

                htmlString &= "                             <div  class='div_facility_block'>"

                For FacilitySp = 0 To FacilityCount
                    htmlString &= "                                 <div class='facilities'>"
                    htmlString &= "                                     <img alt='' src='' />&nbsp;" & dsFacilities.Tables(0).Rows(FacilitySp).Item("FacilityType").ToString.Trim
                    htmlString &= "                                 </div>"

                Next


                htmlString &= "                             </div>"
                htmlString &= "                             <div>"
                Dim Isfavourite As String = CheckIfFavorite(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                If Isfavourite = "False" Then
                    htmlString &= "                                 <div style='float: right; color: #CC0000; cursor:pointer;' onclick=""saveFavorite(" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & ")"" >Add to Favourites &nbsp;"
                    htmlString &= "                                     <img alt='' src='Images/Icons/star.png' /></div>"
                Else
                    htmlString &= "                                 <div style='float: right; color: #CC0000; cursor:pointer;' onclick=""removeFavorite(" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & ")"" >Remove from Favourites &nbsp;"
                    htmlString &= "                                     <img alt='' src='Images/Icons/correct.png' /></div>"
                End If

                htmlString &= "                             </div>"
                htmlString &= "                         </div>"
                htmlString &= "                     </div>"
                htmlString &= "                  <div>&nbsp;   </div>"

            Next

        Else
            htmlString &= "                         <div class='div_Farm_header'>"
            htmlString &= "Sorry, no farm match your search criteria."
            htmlString &= "                             </div>"

        End If
        Return htmlString
    End Function
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
    End Sub
    Private Function GetFarms() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Country", cmbCountrySelect.SelectedValue.Trim)
        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Farm.id, tbl_Farm.FarmName, tbl_Farm.Country, tbl_Farm.Province, tbl_Farm.Short_Description, tblProvince.Name "
        str &= " FROM            tbl_Farm INNER JOIN"
        str &= "                          tblProvince ON tbl_Farm.Province = tblProvince.ProvinceId AND tbl_Farm.Country = tblProvince.CountryId LEFT OUTER JOIN"
        str &= "                         tbl_Farm_EcoTourism_Types ON tbl_Farm.id = tbl_Farm_EcoTourism_Types.FarmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Packages ON tbl_Farm.id = tbl_Farm_Packages.farmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Animal ON tbl_Farm.id = tbl_Farm_Animal.FarmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Hunting_Types ON tbl_Farm.id = tbl_Farm_Hunting_Types.FarmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Facilities ON tbl_Farm.id = tbl_Farm_Facilities.FarmId"
        str &= " WHERE (tbl_Farm.Status = '2' OR tbl_Farm.Status = '4') AND (tbl_Farm.Country = @Country) "

        '///location search
        Dim strProvince As String = GetSelectedCheckBoxItems(chkLocation)
        If strProvince <> "" Then
            str &= " And (tbl_Farm.Province IN (" & strProvince & ")) "
        End If

        '///Facility Search
        Dim strFacility As String = GetSelectedCheckBoxItems(chkFacilities)
        If strFacility <> "" Then
            str &= " AND (tbl_Farm_Facilities.FacilityId IN (" & strFacility & ")) "
        End If

        '///Eco Tourism Search
        Dim strEcoTourism As String = GetSelectedCheckBoxItems(chkEco)
        If strEcoTourism <> "" Then
            str &= " AND (tbl_Farm_EcoTourism_Types.EcoTourism_Id IN (" & strEcoTourism & ")) "
        End If

        '///Hunting Type Search
        strFacility = GetSelectedCheckBoxItems(chkHuntingType)
        If strFacility <> "" Then
            str &= " AND (tbl_Farm_Hunting_Types.Hunting_Type_Id IN (" & strFacility & ")) "
        End If

        '///Animals Search
        strFacility = GetAnimalsSelected()
        If strFacility <> "" Then
            str &= " AND (tbl_Farm_Animal.AnimalId IN (" & strFacility & ")) "
        End If

        '///Packages Search
        If chkPackages.Checked Then
            str &= " AND packageId IS NOT NULL"
        End If

        '///FarmName Search
        If txtFarmSearch.Text <> "" Then
            str &= " AND (tbl_Farm.FarmName Like '%" & txtFarmSearch.Text.Trim & "%') "
        End If

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
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try

        Return ds


    End Function
    Private Function GetSelectedCheckBoxItems(ChkBox As CheckBoxList) As String

        Dim strSelected As String = ""
        For Each oItem As ListItem In ChkBox.Items
            If oItem.Selected Then
                If strSelected = "" Then
                    strSelected = ("'" & oItem.Value & "'")
                Else
                    strSelected &= (", '" & oItem.Value & "'")
                End If
            End If
        Next
        Return strSelected

    End Function
    Private Function GetAnimalsSelected() As String
        Dim valuet As String = Request.Form("blah")
        If valuet <> "" Then
            valuet = valuet.Replace(",", "','")
            valuet = "'" & valuet & "'"
        End If

        Return valuet
    End Function
    Private Function GetHuntingTypes(FarmId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""
        str &= " SELECT        tbl_Farm_Hunting_Types.id, tbl_Farm_Hunting_Types.FarmId, tbl_Farm_Hunting_Types.Hunting_Type_Id, tbl_Hunting_Types.IconPath"
        str &= " FROM            tbl_Farm_Hunting_Types INNER JOIN"
        str &= "                          tbl_Hunting_Types ON tbl_Farm_Hunting_Types.Hunting_Type_Id = tbl_Hunting_Types.id"
        str &= " WHERE        (tbl_Farm_Hunting_Types.FarmId = @FarmId)"

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
    Private Function GetFacilitiesTypes(FarmId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""
        str &= " SELECT        tbl_Facility_Types.FacilityType"
        str &= " FROM            tbl_Farm_Facilities INNER JOIN"
        str &= "                          tbl_Facility_Types ON tbl_Farm_Facilities.FacilityId = tbl_Facility_Types.id"
        str &= " WHERE        (tbl_Farm_Facilities.FarmId = @FarmId)"

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
    Private Function GetReviewCount(FarmId As String) As String

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""
        str &= " SELECT COUNT(id) AS COUNT"
        str &= " FROM tbl_Farm_Reviews"
        str &= " WHERE (FarmId = @FarmId)"

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

        Dim Count As Integer = ds.Tables(0).Rows(0).Item("Count").ToString

        Return Count


    End Function
    Private Function GetRating(FarmId As String) As String()

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""
        str &= " SELECT COUNT(id) AS COUNT, SUM(Rating) AS Rating, SUM(Rating) / COUNT(id) AS AvgRate, SUM(Rating) / COUNT(id) / 2 AS stars"
        str &= " FROM tbl_Farm_Rating"
        str &= " WHERE (FarmId = @FarmId)"

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

        Dim Count(2) As String

        Count(0) = ds.Tables(0).Rows(0).Item("AvgRate").ToString
        Count(1) = ds.Tables(0).Rows(0).Item("stars").ToString
        If Count(0) = "" Then
            Count(0) = "0"
        End If
        If Count(1) = "" Then
            Count(1) = "0"
        End If

        Return Count


    End Function
    Private Function GetPackagesExpiryDates(ByVal farmId As String) As Boolean

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@farmId", farmId.Trim)
        cmd.Parameters.AddWithValue("@thisDate", Now.Date)
        Dim Name As Boolean = False
        Dim str As String = ""
        str &= " SELECT FromDate, ToDate FROM tbl_Farm_Packages WHERE (farmId = @farmId) AND (ToDate >= @thisDate) "

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
                For sp As Integer = 0 To ds5.Tables(0).Rows.Count

                    If CDate(ds5.Tables(0).Rows(0).Item("ToDate").ToString) >= Now.Date Then
                        Name = True
                        Exit For
                    End If
                Next

            End If
        Catch ex As Exception
            Name = False
        Finally
            sqlconnection1.Close()
        End Try
        Return Name
    End Function
    Private Function LoadAnimalQuery() As String
        Dim htmlString As String = ""


        htmlString &= " <div>"
        htmlString &= " <input type='text' id='demo-input-local' name='blah' />"
        htmlString &= " <script type='text/javascript'>"
        htmlString &= " $(document).ready(function() {"
        htmlString &= " $(""#demo-input-local"").tokenInput(["


        Dim dsAnimals As New DataSet
        dsAnimals = GetAnimals()
        Dim count As Integer = dsAnimals.Tables(0).Rows.Count - 1
        Dim sp As Integer

        For sp = 0 To count
            htmlString &= " {id: " & dsAnimals.Tables(0).Rows(sp).Item("id").ToString.Trim & ", name: '" & dsAnimals.Tables(0).Rows(sp).Item("Name").ToString.Trim & "'},"
        Next


        htmlString &= " ]);"
        htmlString &= " });"
        htmlString &= " </script>"
        htmlString &= " </div>"


        Return htmlString

    End Function
    Private Function GetAnimals() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand



        Dim str As String = ""
        str &= "  SELECT id, Name"
        str &= "  FROM tbl_Animals"
        str &= "  Order By Name"

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
    Private Function GetPrices(ByVal farmId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", farmId)

        Dim str As String = ""
        str &= " SELECT tbl_Farm_Pricing.id, tbl_Farm_Pricing.FarmId, tbl_Farm_Pricing.HunterPrice, tbl_Farm_Pricing.GuestPrice, tblCountries.CurrencySymbol, tbl_Farm.Country"
        str &= " FROM            tbl_Farm_Pricing LEFT OUTER JOIN"
        str &= "                          tbl_Farm ON tbl_Farm_Pricing.FarmId = tbl_Farm.id LEFT OUTER JOIN"
        str &= "                          tblCountries ON tbl_Farm.Country = tblCountries.Country_Id"
        str &= " WHERE        (tbl_Farm_Pricing.FarmId = @Farmid)"

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

        Dim Price As String = ""

        Try
            Price = ds.Tables(0).Rows(0).Item("HunterPrice").ToString
            Price = CDbl(Price).ToString("###,##0.00")
            Price = ds.Tables(0).Rows(0).Item("CurrencySymbol").ToString & " " & Price
        Catch ex As Exception

        End Try
        Return Price
    End Function
    Private Sub LoadProvinces()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", cmbCountrySelect.SelectedValue.Trim)

        Dim str As String = ""
        str &= " SELECT        ProvinceId, CountryId, Name, Active"
        str &= " FROM            tblProvince"
        str &= " WHERE        (CountryId = @CountryId) AND (Name <> '')"
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

        Finally
            myconnection.Close()
        End Try

        Try
            chkLocation.DataSource = ds.Tables(0)
            chkLocation.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub GetFavouriteCount()

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("UserId").Value.Trim)

        Dim str As String = ""

        str &= " SELECT        COUNT(MemberId) AS Count"
        str &= " FROM            tbl_Member_Favorites"
        str &= "  WHERE        (MemberId = @MemberId)"


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

        Dim Count As String = ""

        Try
            Count = ds.Tables(0).Rows(0).Item("Count").ToString
            If Count > 0 Then
                lblFavoriteCount.Text = "(" & Count & ")"
            End If

        Catch ex As Exception

        End Try


    End Sub
    Private Function CheckIfFavorite(FarmId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("UserId").Value.Trim)
        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""

        str &= " SELECT * FROM tbl_Member_Favorites WHERE FarmId = @FarmId AND MemberId= @MemberId"


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

        Dim isFavourite As String = "False"

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                isFavourite = "True"
            Else
                isFavourite = "False"
            End If
        Catch ex As Exception

        End Try

        Return isFavourite
    End Function

    Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        txtFarmSearch.Text = ""
        chkLocation.ClearSelection()
        chkFacilities.ClearSelection()
        chkEco.ClearSelection()
        chkHuntingType.ClearSelection()
        txtDateFrom.Text = ""
        txtDateTo.Text = ""
        txtHunterPax.Text = ""
        txtGuestPax.Text = ""
    End Sub
End Class
