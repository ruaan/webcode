Imports System.Data
Partial Class package_view
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet
    Dim packageId As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        packageId = Request.QueryString("id").ToString.Trim
        If Page.IsPostBack = False Then

        End If
        TabSelect()
    End Sub
    Private Sub TabSelect()
        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(New LiteralControl(GetGeninfo))
    End Sub

#Region "Package Information"
    Private Function GetGeninfo() As String
        GetinitialData(packageId)
        Dim htmlString As String = ""

        htmlString &= " <div id='divInfo'>"
        htmlString &= "     <div id='infoBlock'  class='div_infoBlock'>"

        htmlString &= "                 <div style ='display: inline-block; horizontal-align: right; vertical-align:middle; width:98%; padding: 2px;'>"
        If dsInfo.Tables(0).Rows(0).Item("LargeImage").ToString.Trim <> "" Then
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/" & dsInfo.Tables(0).Rows(0).Item("LargeImage").ToString.Trim & "' style='width:98%;' />"
        Else
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/TemplateBig.jpg' />"
        End If
        htmlString &= "                 </div>"



        htmlString &= "         <div id='div_info_Terms'>"
        '''''Personal Information'''''
        htmlString &= "             <div style='border-top-style: padding-left:10px;'>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div style='display:inline-block;  padding: 2px; vertical-align: top;'>"
        htmlString &= "                     <div>" & dsInfo.Tables(0).Rows(0).Item("Description").ToString.Trim & "</div>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                     <div style= font-weight: 700;'>Animals Included:</div>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                     <div style= 'width: 100%;'>"
        Dim dsCertificate As New DataSet
        dsCertificate = GetAnimalData(packageId.Trim)
        Dim certCount, sp As Integer
        certCount = dsCertificate.Tables(0).Rows.Count - 1
        If certCount > -1 Then
            For sp = 0 To certCount
                htmlString &= "                     <div>"
                htmlString &= "                         <div style='display:inline-block; padding: 2px;'>"
                htmlString &= "                             <div'>" & dsCertificate.Tables(0).Rows(sp).Item("Name").ToString.Trim & "</div>"
                htmlString &= "                         </div>"
                htmlString &= "                     </div>"
            Next
        End If
        htmlString &= "                     </div>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                     <div style= font-weight: 700;'>Total: " & dsInfo.Tables(0).Rows(0).Item("cost").ToString.Trim & "</div>"
        htmlString &= "                     <div>&nbsp;</div>"


        htmlString &= "                     <div style=  font-weight: 700;'>Included:</div>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                     <div >"
        Dim dsIncluded As New DataSet
        dsIncluded = GetIncludedData(packageId.Trim)
        Dim inCount, sp1 As Integer
        inCount = dsIncluded.Tables(0).Rows.Count - 1
        If inCount > -1 Then
            For sp1 = 0 To inCount
                htmlString &= "                     <div>"

                htmlString &= "                         <div style=' padding: 2px;'>"
                htmlString &= "                             <div>" & dsIncluded.Tables(0).Rows(sp1).Item("Description").ToString.Trim & "</div>"
                htmlString &= "                         </div>"
                htmlString &= "                     </div>"
            Next
        End If
        htmlString &= "                     </div>"


        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                     <div style= 'font-weight: 700; '>Excluded:</div>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                     <div>"
        Dim exIncluded As New DataSet
        exIncluded = GetExcludedData(packageId.Trim)
        Dim exCount, sp2 As Integer
        exCount = exIncluded.Tables(0).Rows.Count - 1
        If exCount > -1 Then
            For sp2 = 0 To exCount
                htmlString &= "                     <div>"
                htmlString &= "                         <div style='display:inline-block; padding: 2px;'>"
                htmlString &= "                             <div>" & exIncluded.Tables(0).Rows(sp2).Item("Description").ToString.Trim & "</div>"
                htmlString &= "                         </div>"
                htmlString &= "                     </div>"
            Next
        End If
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div style ='display: inline-block; vertical-align: middle; width: 40px; padding: 2px;'>&nbsp;</div>"
        htmlString &= "                 <div style ='display: inline-block; vertical-align: middle; width: 240px; padding: 2px;'>"
        If dsInfo.Tables(0).Rows(0).Item("Image1").ToString.Trim = "" Then
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/Template.jpg'  style='width:98%;' />"
        Else
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/" & dsInfo.Tables(0).Rows(0).Item("Image1").ToString.Trim & "' style='width:98%;' />"
        End If
        htmlString &= "                 </div>"
        htmlString &= "                 <div style ='display: inline-block; vertical-align: middle; width: 240px; padding: 2px;'>"
        If dsInfo.Tables(0).Rows(0).Item("Image2").ToString.Trim = "" Then
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/Template.jpg' style='width:98%;' />"
        Else
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/" & dsInfo.Tables(0).Rows(0).Item("Image2").ToString.Trim & "' style='width:98%;' />"
        End If
        htmlString &= "                 </div>"
        htmlString &= "                 <div style ='display: inline-block; vertical-align: middle; width: 240px; padding: 2px;'>"
        If dsInfo.Tables(0).Rows(0).Item("Image3").ToString.Trim = "" Then
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/Template.jpg' style='width:98%;' />"
        Else
            htmlString &= "                     <img alt='' src='Farms/Images/Packages/" & dsInfo.Tables(0).Rows(0).Item("Image3").ToString.Trim & "' style='width:98%;' />"
        End If
        htmlString &= "                 </div>"

        htmlString &= "                 <div style='display:inline-block; padding: 2px;'>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "             </div>"
        htmlString &= "         </div>"
        htmlString &= "     </div>"
        htmlString &= " </div>"

        Return htmlString
    End Function
    Private Function GetinitialData(ByVal packageId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", packageId.Trim)
        Dim str As String = ""

        str &= " SELECT Package, Description, cost, LargeImage, Image1, Image2, Image3 FROM tbl_Farm_Packages WHERE (packageId = @packageId) "

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

        lblHeading.Text = ds.Tables(0).Rows(0).Item("Package").ToString.Trim

        dsInfo = ds
        Return ds
    End Function
    Private Function GetAnimalData(ByVal packageId As String) As DataSet
        Dim datasetAnimal As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", packageId.Trim)
        Dim str As String = ""

        str &= " SELECT  tbl_Farm_Package_Animals.animalId, tbl_Animals.Name "
        str &= " FROM tbl_Farm_Package_Animals INNER JOIN "
        str &= " tbl_Animals ON tbl_Farm_Package_Animals.animalId = tbl_Animals.id "
        str &= " WHERE (tbl_Farm_Package_Animals.packageId = @packageId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim dsAnimal As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(dsAnimal, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        datasetAnimal = dsAnimal
        Return dsAnimal
    End Function
    Private Function GetIncludedData(ByVal packageId As String) As DataSet
        Dim datasetIncluded As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", packageId.Trim)
        Dim str As String = ""

        str &= " SELECT includedId, Description, packageId FROM tbl_Farm_Package_Included WHERE (packageId = @packageId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim dsIncluded As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(dsIncluded, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        datasetIncluded = dsIncluded
        Return dsIncluded
    End Function
    Private Function GetExcludedData(ByVal packageId As String) As DataSet
        Dim datasetExcluded As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@packageId", packageId.Trim)
        Dim str As String = ""

        str &= " SELECT excludedId, Description, packageId FROM tbl_Farm_Package_Excluded WHERE (packageId = @packageId) "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim dsAnimal As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(dsAnimal, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        datasetExcluded = dsAnimal
        Return dsAnimal
    End Function
#End Region


End Class
