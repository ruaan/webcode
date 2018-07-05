Imports System.Data
Partial Class View_Favourites_App
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            PlaceHolder1.Controls.Add(New LiteralControl(ResultBody))
        End If
    End Sub
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
                    HtmlString &= "                     <td>Packages Available</td>"
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

            PlaceHolder1.Controls.Add(New LiteralControl(ResultBody))
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

            PlaceHolder1.Controls.Add(New LiteralControl(ResultBody))
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
