Imports System.Data
Partial Class Animals
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            PlaceHolder4.Controls.Add(New LiteralControl(GetAnimals()))
        End If
        PlaceHolder3.Controls.Add(New LiteralControl(LoadAnimalQuery))
    End Sub


    Private Function GetAnimals() As String

        Dim SavePath As String = ""
        Dim pathname As String = "Images\Animals\"
        Dim pathnameRoot As String

        pathnameRoot = Server.MapPath(pathname)
        pathnameRoot = pathnameRoot.Replace("\SetUp", "")
        SavePath = pathnameRoot




        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"

        Dim dsTerms As New DataSet
        dsTerms = GetAnimalData()
        Dim count As Integer = dsTerms.Tables(0).Rows.Count - 1
        Dim sp As Integer

        Dim itemName As String = ""

        For sp = 0 To count


            htmlString &= " <div>&nbsp;</div>"

            htmlString &= "     <div style='background-color: #F8F8F8; border: 1px solid #333333; width:600px; cursor:pointer;' onclick=""window.open('Animal_View.aspx?animalId=" & dsTerms.Tables(0).Rows(sp).Item("id").ToString.Trim & "', '_self')"" >"
            htmlString &= "         <div style='padding: 10px; display: inline-block; width:200px;height:200px;'>"

            If System.IO.File.Exists(SavePath & "/" & dsTerms.Tables(0).Rows(sp).Item("id").ToString.Trim & "Front.jpg") Then
                htmlString &= "             <img alt='' src='Images/Animals/" & dsTerms.Tables(0).Rows(sp).Item("id").ToString.Trim & "Front.jpg' class='Animal_Pic' />"
            Else
                htmlString &= "                             <img alt='' src='Images/Animals/animal_PlaceHolder.jpg' class='Animal_Pic' />"
            End If


            htmlString &= "         </div>"
            htmlString &= "         <div style='padding: 10px; display: inline-block; vertical-align: top; color: #333333;'>"
            htmlString &= "             <div style='font-size: large; font-weight: bold;'>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("Name").ToString.Trim
            htmlString &= "   </div>"
            htmlString &= " <div>&nbsp;</div>"
            htmlString &= "             <div>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("Comments").ToString.Trim
            htmlString &= "            </div>"
            htmlString &= "         </div>"
            htmlString &= "     </div>"







        Next
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"


        Return htmlString

    End Function

    Private Function GetAnimalData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        Dim str As String = ""

        str &= " SELECT  * "
        str &= " FROM    tbl_Animals "

        Dim strAnminals As String = GetAnimalsSelected()
        If strAnminals <> "" Then
            str &= " WHERE (id IN (" & strAnminals & ")) "
        End If
        str &= " ORDER BY tbl_Animals.Name"

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

        dsInfo = ds

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
    Private Function LoadAnimalQuery() As String
        Dim htmlString As String = ""


        htmlString &= " <div>"
        htmlString &= " <input type='text' id='demo-input-local' name='blah' />"

        htmlString &= " <script type='text/javascript'>"
        htmlString &= " $(document).ready(function() {"
        htmlString &= " $(""#demo-input-local"").tokenInput(["


        Dim dsAnimals As New DataSet
        dsAnimals = GetAnimalsQuery()
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
    Private Function GetAnimalsQuery() As DataSet
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
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PlaceHolder4.Controls.Add(New LiteralControl(GetAnimals()))
    End Sub
End Class
