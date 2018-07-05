Imports System.Data
Partial Class FarmsApp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            Dim userid As String = Request.QueryString("member")
            Dim memberid As String = Request.QueryString("memberid")
            Dim usethisid As String = ""
            Try
                If userid <> "" Then
                    Response.Cookies("memberid").Value = GetMemberId(userid)
                    Response.Cookies("UserId").Value = userid
                End If
            Catch ex As Exception

            End Try


            GetFavouriteCount()
        End If
        PlaceHolder3.Controls.Add(New LiteralControl(LoadAnimalQuery))
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowHide", "ShowHideDiv();", True)
        imgBtnFilter.Attributes.Add("onclick", "ShowHideDiv();")
    End Sub

    Private Function GetMemberId(userid As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", userid)


        Dim str As String = ""
        str &= " SELECT MemberId"
        str &= " FROM tbl_Users"
        str &= " where id = @id"

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

        Dim memberId As String = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim

        Return memberId


    End Function


    Private Function ResultBody() As String
        Dim SavePath As String = ""
        Dim pathname As String = "Farms\Images\FarmProfiles\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)

        SavePath = pathnameRoot
        Dim HtmlString As String = ""

        Dim dsFarm As New DataSet
        dsFarm = GetFarms()

        Dim dsHunting As New DataSet
        Dim dsFacilities As New DataSet

        Dim farmCount As Integer = dsFarm.Tables(0).Rows.Count - 1
        Dim farmSp As Integer



        Dim ReviewCount As String = "0"

        imgFarmsResult.Visible = True
        If farmCount > -1 Then

            For farmSp = 0 To farmCount

                HtmlString &= " <table align='center' style='width:100%; background-color:#E1EAD8;'>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>"
                HtmlString &= "                         &nbsp;</td>"
                HtmlString &= "                     <td>"
                HtmlString &= "                         &nbsp;</td>"
                HtmlString &= "                 </tr>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td class='auto-style5'>"
                HtmlString &= "                         </td>"
                HtmlString &= "                     <td class='auto-style5'>"
                If System.IO.File.Exists(SavePath & "/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg") Then
                    HtmlString &= "                            <img alt='' src='../Farms/Images/FarmProfiles/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg' class='style-profile' onclick=""location.href = 'farm_view_app.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "'"" />"
                Else
                    HtmlString &= "                             <img alt='' src='Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg' class='style-profile' onclick=""location.href = 'farm_view_app.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "'"" />"
                End If
                HtmlString &= "                 </tr>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>&nbsp;</td>"
                HtmlString &= "                     <td><div style='font-size: large; font-weight: bold;'>" & dsFarm.Tables(0).Rows(farmSp).Item("FarmName").ToString.Trim & " &nbsp; (" & dsFarm.Tables(0).Rows(farmSp).Item("Name").ToString.Trim & ")</div></td>"
                HtmlString &= "                 </tr>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>"
                HtmlString &= "                         &nbsp;</td>"
                HtmlString &= "                     <td>"
                HtmlString &= "                     </td>"
                HtmlString &= "                 </tr>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td align='left'>"
                HtmlString &= "                         &nbsp;</td>"
                HtmlString &= "                     <td align='left'>"
                HtmlString &= "                         <table class='auto-style2'>"
                HtmlString &= "                             <tr>"
                HtmlString &= "                                 <td class='auto-style3'>"
                HtmlString &= "                                      <asp:Image ID='Image1' runat='server' ImageUrl='~/Images/Icons/star.png' />"
                HtmlString &= "                         <asp:Image ID='Image2' runat='server' ImageUrl='~/Images/Icons/star.png' />"
                HtmlString &= "                         <asp:Image ID='Image3' runat='server' ImageUrl='~/Images/Icons/star.png' />"
                HtmlString &= "                         <asp:Image ID='Image4' runat='server' ImageUrl='~/Images/Icons/star.png' />"
                HtmlString &= "                         <asp:Image ID='Image5' runat='server' ImageUrl='~/Images/Icons/star.png' />"
                HtmlString &= "                                 </td>"
                ReviewCount = GetReviewCount(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                HtmlString &= "                                 <td style='font-size: small'>"
                HtmlString &= "                                     <img alt='' src='../Images/Icons/Farm_Search/reviews.png' class='auto-style4' />" & ReviewCount & " Reviews</td>"
                HtmlString &= "                             </tr>"
                HtmlString &= "                         </table>"
                HtmlString &= "                     </td>"
                HtmlString &= "                 </tr>"


                Dim Price As String = GetPrices(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                If Price = "" Then
                    HtmlString &= "                                     <div style='color: #CC0000'>&nbsp;</div>"
                    HtmlString &= "                                     <div style='color: #CC0000; font-weight: bold'>&nbsp;</div>"
                Else
                    HtmlString &= "                                     <div>"
                    HtmlString &= "                 <tr>"
                    HtmlString &= "                     <td style='color: #CC0000'>&nbsp;</td>"
                    HtmlString &= "                     <td style='color: #CC0000'>from</td>"
                    HtmlString &= "                 </tr>"
                    HtmlString &= "                 <tr>"
                    HtmlString &= "                     <td style='color: #CC0000'>&nbsp;</td>"
                    HtmlString &= "                     <td style='color: #CC0000'>" & Price & "</td>"
                    HtmlString &= "                 </tr>"
                    HtmlString &= "   </div>"

                End If
                '''''Packages Available'''''
                If GetPackagesExpiryDates(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim) Then 'Is there any valid packages for this farm?
                    HtmlString &= "                 <tr>"
                    HtmlString &= "                     <td>&nbsp;</td>"
                    HtmlString &= "                     <td>"
                    HtmlString &= "                             <div style='padding-top: 5px; padding-bottom: 5px; cursor:pointer; color: #CC0000; font-weight: bold' onclick=""location.href='Packages_App.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "'"">Packages Available</div>"
                    HtmlString &= "                     </td>"
                    HtmlString &= "                 </tr>"
                End If

                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>&nbsp;</td>"
                HtmlString &= "                     <td>"
                HtmlString &= "                             <div>"
                Dim Isfavourite As String = CheckIfFavorite(dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim)
                If Isfavourite = "False" Then
                    HtmlString &= "                                 <div style='float: right; color: #CC0000; cursor:pointer;' onclick=""saveFavorite(" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & ")"" >Add to Favourites &nbsp;"
                    HtmlString &= "                                     <img alt='' src='Images/Icons/favorite-select.png' /></div>"
                Else
                    HtmlString &= "                                 <div style='float: right; color: #CC0000; cursor:pointer;' onclick=""removeFavorite(" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & ")"" >Remove from Favourites &nbsp;"
                    HtmlString &= "                                     <img alt='' src='Images/Icons/correct.png' /></div>"
                End If

                HtmlString &= "                             </div>"
                HtmlString &= " </td>"
                HtmlString &= "                 </tr>"

                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>&nbsp;</td>"
                HtmlString &= "                     <td>&nbsp;</td>"
                HtmlString &= "                 </tr>"
                HtmlString &= "             </table>"
            Next
        Else
            HtmlString &= "                         <div  style='width:100%; background-color:#E1EAD8; font-size: large;'>"
            HtmlString &= "                           <div>&nbsp;  </div>"
            HtmlString &= "&nbsp; No farms match your search criteria."
            HtmlString &= "                           <div>&nbsp;</div>"
            HtmlString &= "                             </div>"
        End If


        Return HtmlString

    End Function
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
    Private Function GetFarms() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Country", cmbCountry.SelectedValue.Trim)
        Dim str As String = ""
        str &= " SELECT DISTINCT TOP(50) tbl_Farm.id, tbl_Farm.FarmName, tbl_Farm.Country, tbl_Farm.Province, tbl_Farm.Short_Description, tblProvince.Name "
        str &= " FROM            tbl_Farm INNER JOIN"
        str &= "                          tblProvince ON tbl_Farm.Province = tblProvince.ProvinceId AND tbl_Farm.Country = tblProvince.CountryId LEFT OUTER JOIN"
        str &= "                         tbl_Farm_EcoTourism_Types ON tbl_Farm.id = tbl_Farm_EcoTourism_Types.FarmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Packages ON tbl_Farm.id = tbl_Farm_Packages.farmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Animal ON tbl_Farm.id = tbl_Farm_Animal.FarmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Hunting_Types ON tbl_Farm.id = tbl_Farm_Hunting_Types.FarmId LEFT OUTER JOIN"
        str &= "                          tbl_Farm_Facilities ON tbl_Farm.id = tbl_Farm_Facilities.FarmId"

        str &= " WHERE Status = '2'  AND (tbl_Farm.Country = @Country) "

        '///location search
        Dim strProvince As String = GetSelectedCheckBoxItems(chkLocation)
        If strProvince <> "" Then
            str &= " AND (tbl_Farm.Province IN (" & strProvince & ")) "
        End If

        '///Facility Search
        Dim strFacility As String = GetSelectedCheckBoxItems(chkFacilities)
        If strFacility <> "" Then
            str &= " AND (tbl_Farm_Facilities.FacilityId IN (" & strFacility & ")) "
        End If

        '///Eco Tourism Search
        Dim strEcoTourism As String = GetSelectedCheckBoxItems(chkEco)
        If strEcoTourism <> "" Then
            str &= " AND (tbl_Farm_EcoTourism_Types IN (" & strEcoTourism & ")) "
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

        '///FarmName Search
        If txtFarmSearch.Text <> "" Then
            str &= " AND (tbl_Farm.FarmName Like '%" & txtFarmSearch.Text.Trim & "%') "
        End If

        '///Packages Search
        If chkPackages.Checked Then
            str &= " AND packageId IS NOT NULL"
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
    Private Sub LoadProvinces()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@CountryId", cmbCountry.SelectedValue.Trim)

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

    Private Function GetAnimalsSelected() As String
        Dim valuet As String = Request.Form("blah")
        If valuet <> "" Then
            valuet = valuet.Replace(",", "','")
            valuet = "'" & valuet & "'"
        End If

        Return valuet
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



    Protected Sub imgBtnFilter_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnFilter.Click
        PlaceHolder1.Controls.Add(New LiteralControl(ResultBody))
        divSearch.Style.Add("display", "none")
    End Sub
    Protected Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
        LoadProvinces()
    End Sub
    Protected Sub cmbCountry_DataBound(sender As Object, e As EventArgs) Handles cmbCountry.DataBound
        If Page.IsPostBack = False Then
            cmbCountry.SelectedValue = "1"
        End If
        LoadProvinces()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("UserId").Value.Trim)
        cmd.Parameters.AddWithValue("@FarmId", hiddenfieldFavorite.Value.Trim)

        Dim str As String = ""
        str &= " BEGIN TRAN"
        str &= " IF EXISTS (SELECT * FROM tbl_Member_Favorites WHERE FarmId = @FarmId AND MemberId= @MemberId)"
        str &= " BEGIN"
        str &= " UPDATE tbl_Member_Favorites SET FarmId = @FarmId WHERE FarmId = @FarmId AND MemberId= @MemberId"
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN"
        str &= " INSERT INTO tbl_Member_Favorites (MemberId, FarmId) VALUES (@MemberId, @FarmId) "
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
            GetFavouriteCount()
            PlaceHolder1.Controls.Add(New LiteralControl(ResultBody))
        Catch ex As Exception

        Finally
            myconnection.Close()
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
                divFavouriteView.Visible = True
                lblFavoriteCount.Text = "(" & Count & ")"
            Else
                divFavouriteView.Visible = False
            End If

        Catch ex As Exception

        End Try


    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("UserId").Value.Trim)
        cmd.Parameters.AddWithValue("@FarmId", hiddenfieldFavorite.Value.Trim)

        Dim str As String = ""

        str &= " Delete FROM tbl_Member_Favorites WHERE FarmId = @FarmId AND MemberId= @MemberId"


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
            GetFavouriteCount()
            PlaceHolder1.Controls.Add(New LiteralControl(ResultBody))
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
