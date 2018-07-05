Imports System.Data
Partial Class Shop_SupplierApp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PlaceHolder1.Controls.Add(New LiteralControl(ResultBody()))
    End Sub

    Private Function ResultBody() As String
        Dim SavePath As String = ""
        Dim pathname As String = "Images\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)

        SavePath = pathnameRoot
        Dim HtmlString As String = ""

        Dim dsSuppliers As New DataSet
        dsSuppliers = getSuppliers()

        Dim dsHunting As New DataSet
        Dim dsFacilities As New DataSet

        Dim farmCount As Integer = dsSuppliers.Tables(0).Rows.Count - 1
        Dim farmSp As Integer



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
                If System.IO.File.Exists(SavePath & "/" & dsSuppliers.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg") Then
                    HtmlString &= "                            <img alt='' src='Images/" & dsSuppliers.Tables(0).Rows(farmSp).Item("id").ToString.Trim & "Main.jpg' class='style-profile' onclick=""location.href = '" & dsSuppliers.Tables(0).Rows(farmSp).Item("URL").ToString.Trim & "'"" />"
                Else
                    HtmlString &= "                             <img alt='' src='Images/ProfilePlaceHolder.jpg' class='style-profile' onclick=""location.href = '" & dsSuppliers.Tables(0).Rows(farmSp).Item("URL").ToString.Trim & "'"" />"
                End If

                HtmlString &= "                 </tr>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>&nbsp;</td>"
                HtmlString &= "                     <td><div style='font-size: large; font-weight: bold;'>" & dsSuppliers.Tables(0).Rows(farmSp).Item("Supplier").ToString.Trim & " </div></td>"
                HtmlString &= "                 </tr>"
                HtmlString &= "                 <tr>"
                HtmlString &= "                     <td>"
                HtmlString &= "                         &nbsp;</td>"
                HtmlString &= "                     <td>"
                HtmlString &= "                     </td>"
                HtmlString &= "                 </tr>"

                HtmlString &= "             </table>"
                HtmlString &= "    <table style='width: 100%;'>"
                HtmlString &= "                   <tr>"
                HtmlString &= "                       <td style='background-color: #373E2E'>&nbsp;</td>"
                HtmlString &= "                   </tr>"
                HtmlString &= "                   </table>"


            Next
        Else
            HtmlString &= "                         <div  style='width:100%; background-color:#E1EAD8; font-size: large;'>"
            HtmlString &= "                           <div>&nbsp;  </div>"
                HtmlString &= "&nbsp; No store match your search criteria."
                HtmlString &= "                           <div>&nbsp;</div>"
                HtmlString &= "                             </div>"

        End If


        Return HtmlString

    End Function
    Private Function getSuppliers() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT   id, Supplier, Description, URL FROM tbl_Suppliers "



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
End Class
