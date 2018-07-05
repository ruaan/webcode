Imports System.Data
Partial Class Package_Search
    Inherits System.Web.UI.Page

    Private Function ResultBody() As String
        Dim htmlString As String = ""

        Dim dsFarm As New DataSet
        dsFarm = GetFarms()
        Try
            Dim farmCount As Integer = dsFarm.Tables(0).Rows.Count - 1
            If farmCount > -1 Then
                Dim farmSp As Integer
                For farmSp = 0 To farmCount
                    htmlString &= "                    <div id='famrid" & dsFarm.Tables(0).Rows(farmSp).Item("id").ToString.Trim & " ' class='div_Farm_Block'  onclick=""window.open('package_view.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("packageId").ToString.Trim & "', '_self')"">"
                    htmlString &= "                         <div class='div_Picture_Style'>"
                    If dsFarm.Tables(0).Rows(farmSp).Item("LargeImage").ToString.Trim = "" Then
                        htmlString &= "                             <img alt='' src='Farms/Images/Packages/TemplateBig.jpg' class='image_Style' />"
                    Else
                        htmlString &= "                             <img alt='' src='Farms/Images/Packages/" & dsFarm.Tables(0).Rows(farmSp).Item("LargeImage").ToString.Trim & "' class='image_Style' />"
                    End If

                    htmlString &= "                         </div>"
                    htmlString &= "                         <div class='div_Middle_Block'>"
                    htmlString &= "                             <div class='div_Farm_header'>" & dsFarm.Tables(0).Rows(farmSp).Item("Package").ToString.Trim & "</div>"
                    htmlString &= "                             <div class='div_Farm_header'>" & dsFarm.Tables(0).Rows(farmSp).Item("FarmName").ToString.Trim & "</div>"
                    htmlString &= "                             <div>&nbsp;</div>"
                    htmlString &= "                             <div class='div_text_block'>"
                    htmlString &= dsFarm.Tables(0).Rows(farmSp).Item("Description").ToString.Trim
                    htmlString &= "                             </div>"
                    htmlString &= "                         </div>"
                    htmlString &= "                     </div>"
                    htmlString &= "                  <div>&nbsp;</div>"
                Next
            Else
                htmlString &= "                         <div class='div_Farm_header'>"
                htmlString &= "No package found."
                htmlString &= "                             </div>"
            End If
        Catch ex As Exception
            htmlString &= "<div>No package found..</div>"
        End Try
        Return htmlString
    End Function
    Private Function GetFarms() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@thisDate", Now.Date)
        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Farm.id, tbl_Farm.FarmName, tbl_Farm_Packages.packageId, tbl_Farm_Packages.Package, tbl_Farm_Packages.Description, tbl_Farm_Packages.LargeImage "
        str &= " FROM tbl_Farm RIGHT OUTER JOIN "
        str &= " tbl_Farm_Packages ON tbl_Farm.id = tbl_Farm_Packages.farmId "
        str &= " WHERE (tbl_Farm_Packages.ToDate >= @thisDate) AND (tbl_Farm.Status = '2') "

        Dim strProvince As String = GetSelectedCheckBoxItems(chkLocation)
        If strProvince <> "" Then
            str &= " And (tbl_Farm.Province IN (" & strProvince & ")) "
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
    Private Function GetHuntingTypes(FarmId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Farm_Hunting_Types.id, tbl_Farm_Hunting_Types.FarmId, tbl_Farm_Hunting_Types.Hunting_Type_Id, tbl_Hunting_Types.IconPath"
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
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
    End Sub
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
End Class
