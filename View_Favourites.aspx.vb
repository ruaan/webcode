Imports System.Data
Partial Class View_Favourites
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
        End If

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

                htmlString &= "                         <div class='div_Picture_Style' onclick=""window.open('farm_view.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "', '_blank')"">"

                If System.IO.File.Exists(SavePath & "/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg") Then
                    htmlString &= "                             <img alt='' src='Farms/Images/FarmProfiles/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg' class='image_Style' />"
                Else
                    htmlString &= "                             <img alt='' src='Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg' />"
                End If


                htmlString &= "                         </div>"
                htmlString &= "                         <div class='div_Middle_Block' onclick=""window.open('farm_view.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "', '_blank')"">"
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
                    htmlString &= "                                         <img alt='' src='Images/Icons/favorite-select.png' class='rateStar' />"
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
                    htmlString &= "                             <div style='padding-top: 5px; padding-bottom: 5px; cursor:pointer;' onclick=""window.open('Packages.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "', '_blank')"">Packages Available</div>"
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
                    htmlString &= "                                     <img alt='' src='Images/Icons/favorite-select.png' /></div>"
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
            htmlString &= "You have no favourite destinations selected."
            htmlString &= "                             </div>"

        End If
        Return htmlString
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
    Private Function GetFarms() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("UserId").Value.Trim)
        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Farm.id, tbl_Farm.FarmName, tbl_Farm.Country, tbl_Farm.Province, tbl_Farm.Short_Description, tblProvince.Name"
        str &= " FROM            tbl_Farm INNER JOIN"
        str &= "                          tblProvince ON tbl_Farm.Province = tblProvince.ProvinceId AND tbl_Farm.Country = tblProvince.CountryId INNER JOIN"
        str &= "                          tbl_Member_Favorites ON tbl_Farm.id = tbl_Member_Favorites.FarmId"
        str &= " WHERE        (tbl_Farm.Status = '2' OR"
        str &= "                          tbl_Farm.Status = '4') AND (tbl_Member_Favorites.MemberId = @MemberId)"



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
    Private Function GetPackagesExpiryDates(ByVal farmId As String) As Boolean

        Dim sqlconnection1 As New SqlClient.SqlConnection
        Dim ds5 As New DataSet
        Dim cmd As New SqlClient.SqlCommand

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.Parameters.AddWithValue("@farmId", farmId.Trim)
        Dim Name As Boolean = False
        Dim str As String = ""
        str &= " SELECT FromDate, ToDate FROM tbl_Farm_Packages WHERE (farmId = @farmId) "

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
                    If CDate(ds5.Tables(0).Rows(0).Item("FromDate").ToString) <= Now.Date And CDate(ds5.Tables(0).Rows(0).Item("ToDate").ToString) >= Now.Date Then
                        Name = True
                        Exit For
                    End If
                Next
            Else
                Name = False
            End If
        Catch ex As Exception
            Name = False
        Finally
            sqlconnection1.Close()
        End Try
        Return Name
    End Function
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

            PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
        Catch ex As Exception

        Finally
            myconnection.Close()
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

            PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
