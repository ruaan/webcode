Imports System.Data
Partial Class Outfitters_app
    Inherits System.Web.UI.Page

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

                htmlString &= " <div id='famrid" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & " ' class='div_Farm_Block' onclick=""location.href ='Outfitters_View_App.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "'"" >"
                htmlString &= "     <div class='div_Picture_Style' onclick=""location.href ='Outfitters_View_App.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "'"">"


                If System.IO.File.Exists(SavePath & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg") Then

                    htmlString &= "     <img alt='' src='Farms/Images/FarmProfiles/" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg' class='image_Style' />"
                Else
                    htmlString &= "     <img alt='' src='Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg' class='image_Style'/>"
                End If

                htmlString &= "     </div>"
                htmlString &= "     <div class='div_Middle_Block' onclick=""location.open = 'Outfitters_View_App.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "'"">"
                htmlString &= "         <div class='div_Farm_header'>" & dsFarm.Tables(0).Rows(farmSp).Item("FarmName").ToString.Trim & " &nbsp; (" & dsFarm.Tables(0).Rows(farmSp).Item("Name").ToString.Trim & ")</div>"
                htmlString &= "         <div>&nbsp;</div>"
                htmlString &= "         <div class='div_Middle_Block'>"
                Dim ShortDescription As String = dsFarm.Tables(0).Rows(farmSp).Item("Short_Description").ToString.Trim
                If ShortDescription.Length > 430 Then
                    ShortDescription = ShortDescription.Substring(0, 430)
                    ShortDescription = ShortDescription & "..."
                End If
                htmlString &= ShortDescription
                htmlString &= "         </div>"
                htmlString &= "     </div>"
                htmlString &= " </div>"

            Next

        Else
            htmlString &= "                         <div class='div_Farm_header'>"
            htmlString &= "Sorry, no outfitter matches your search criteria."
            htmlString &= "                             </div>"

        End If
        Return htmlString
    End Function

    Private Function GetFarms() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Country", cmbCountry.SelectedValue.Trim)
        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Outfitter.id, tbl_Outfitter.FarmName, tbl_Outfitter.Country, tbl_Outfitter.Province, tbl_Outfitter.Short_Description, tblProvince.Name "
        str &= " FROM tbl_Outfitter INNER JOIN "
        str &= " tblProvince ON tbl_Outfitter.Province = tblProvince.ProvinceId AND tbl_Outfitter.Country = tblProvince.CountryId LEFT OUTER JOIN "
        str &= " tbl_Farm_Packages On tbl_Outfitter.id = tbl_Farm_Packages.farmId LEFT OUTER JOIN "
        str &= " tbl_Farm_Animal ON tbl_Outfitter.id = tbl_Farm_Animal.FarmId LEFT OUTER JOIN "
        str &= " tbl_Farm_Hunting_Types On tbl_Outfitter.id = tbl_Farm_Hunting_Types.FarmId LEFT OUTER JOIN "
        str &= " tbl_Farm_Facilities ON tbl_Outfitter.id = tbl_Farm_Facilities.FarmId "
        str &= " WHERE (tbl_Outfitter.Country = @Country) "

        '///location search
        Dim strProvince As String = GetSelectedCheckBoxItems(chkLocation)
        If strProvince <> "" Then
            str &= " And (tbl_Outfitter.Province IN (" & strProvince & ")) "
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
    Private Function GetPrices() As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand



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

    Protected Sub cmbCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCountry.SelectedIndexChanged
        LoadProvinces()
    End Sub
    Protected Sub cmbCountry_DataBound(sender As Object, e As EventArgs) Handles cmbCountry.DataBound
        If Page.IsPostBack = False Then
            cmbCountry.SelectedValue = "1"
            PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
        End If
        LoadProvinces()
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
