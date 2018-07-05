Imports System.Data
Partial Class Associations_Association_View
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PlaceHolder1.Controls.Add(New LiteralControl(GetAssociations))
    End Sub
    Private Function GetAssociations() As String
        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"

        htmlString &= "                         <div>&nbsp;</div>"
        Dim dsTerms As New DataSet
        dsTerms = GetAssociationData()
        Dim count As Integer = dsTerms.Tables(0).Rows.Count - 1
        Dim sp As Integer

        Dim itemName As String = ""

        For sp = 0 To count
            htmlString &= " <div>&nbsp;</div>"

            htmlString &= "     <div style='background-color: #F8F8F8; border: 1px solid #333333; width:800px; cursor:pointer' onclick=""window.open('Association_Detail.aspx?id=" & dsTerms.Tables(0).Rows(sp).Item("Association_Id").ToString.Trim & "','_self')"" >"
            htmlString &= "         <div style='padding: 10px; display: inline-block'>"
            htmlString &= "             <img alt='' src='../Images/Associations/" & dsTerms.Tables(0).Rows(sp).Item("ProfilePicPath").ToString.Trim & "' class='Animal_Pic' />"
            htmlString &= "         </div>"
            htmlString &= "         <div style='padding: 10px; display: inline-block; vertical-align: top; color: #333333;'>"
            htmlString &= "             <div style='font-size: large; font-weight: bold;'>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("Name").ToString.Trim
            htmlString &= "   </div>"
            htmlString &= " <div>&nbsp;</div>"
            htmlString &= "             <div style='width:500px;'>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("ShortDescription").ToString.Trim
            htmlString &= "            </div>"
            htmlString &= "         </div>"
            htmlString &= "     </div>"

        Next
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"
        htmlString &= " <div>&nbsp;</div>"

        Return htmlString

    End Function
    Private Function GetAssociationData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""

        str &= " SELECT        Association_Id, Name, ContactPerson, ContactTel, ContactEmail, Active, ProfilePicPath, ShortDescription, LongDescription"
        str &= " FROM            tbl_Associations"
        str &= " WHERE        (Active = 'True')"
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

        Return ds
    End Function
End Class
