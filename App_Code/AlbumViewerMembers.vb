Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Data

Public Class AlbumViewerMembers
    Dim thisalbumType, thisid As String
    Public Function GetAlbum(albumType As String, id As String) As String
        thisalbumType = albumType
        thisid = id
        Dim Albumstring As String = ""
        Albumstring = GetMainFolders()
        Return Albumstring
    End Function
    Private Function GetMainFolders() As String

        Dim ds As New DataSet
        ds = GetDisplayGalleryMain()

        Dim count As Integer = ds.Tables(0).Rows.Count - 1

        Dim HtmlString As String = ""
        HtmlString &= "<table align='left' width='100%'> "
        HtmlString &= "  <tr> "
        HtmlString &= "      <td> "
        HtmlString &= "          <table width='100%' align='center'> "
        HtmlString &= "              <tr> "
        HtmlString &= "                  <td valign='top'> "
        HtmlString &= "                      <table width='100%' align='center' border='0'> "
        For sp = 0 To count

            Dim ds1 As New DataSet
            ds1 = GetDisplayGallerySub(ds.Tables(0).Rows(sp).Item("id"))

            Dim count1 As Integer = ds1.Tables(0).Rows.Count - 1

            HtmlString &= "                     <tr> "
            HtmlString &= "                         <td valign='top'> "
            HtmlString &= "                             <table width='100%' align='center' border='0'> "
            HtmlString &= "                                 <tr>"
            HtmlString &= "                                     <td valign='top' width='100%' style='border-bottom-style: solid; border-width: thin; border-color: #184D43'>"
            HtmlString &= "                                         <table width='100%'>"
            HtmlString &= "                                             <tr>"

            HtmlString &= "                                                 <td align='left' height='30'><input class='ViewerButton' type='button' value='" & ds.Tables(0).Rows(sp).Item("Name") & "' onclick=""toggle_visibility('" & sp & "', '" & count1 & "');"" /></td>"
            HtmlString &= "                                                 <td align='right'><a onclick=""toggle_visibility('" & sp & "', '" & count1 & "');"" style='cursor: pointer'>more</a></td>"
            HtmlString &= "                                             </tr>"

            For sp1 = 0 To count1
                Dim test1 As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim test2 As String = ds1.Tables(0).Rows(sp1).Item("Name")
                HtmlString &= "                                         <tr>"
                HtmlString &= "                                             <td colspan='2'>"
                HtmlString &= "                                                 <div id='" & sp & sp1 & "' style='display: none'>"
                HtmlString &= "                                                     <table width='100%' border='0'>"

                HtmlString &= "                                                         <tr>"
                HtmlString &= "                                                             <td style='background-color: #999999; color: #333333' align='left' valign='top'>&nbsp;&nbsp;&nbsp;<a onclick=""toggle_visibility('" & sp & sp1 & "a', '" & sp & "');"" style='cursor: pointer'>" & ds1.Tables(0).Rows(sp1).Item("Name") & "</a></td>"
                HtmlString &= "                                                         </tr>"

                If sp1 = 0 Then
                    HtmlString &= "                                                         <tr>"
                    HtmlString &= ds.Tables(0).Rows(sp).Item("Description")
                    HtmlString &= "                                                         </tr>"
                End If

                HtmlString &= "                                                         <tr>"
                HtmlString &= "                                                             <td align='left' valign='top'>"
                HtmlString &= "                                                                 <div id='" & sp & sp1 & "a" & sp & "' style='display: none'>"
                HtmlString &= "                                                                     <table width='100%' border='0' align='center'>"

                HtmlString &= "                                                         <tr>"
                HtmlString &= ds1.Tables(0).Rows(sp1).Item("Description")
                HtmlString &= "                                                         </tr>"

                HtmlString &= "                                                                         <tr>"
                HtmlString &= "                                                                             <td>" & GetPhotos(ds1.Tables(0).Rows(sp1).Item("subId"), ds.Tables(0).Rows(sp).Item("Name"), ds1.Tables(0).Rows(sp1).Item("Name")) & "</td>"
                HtmlString &= "                                                                         </tr>"
                HtmlString &= "                                                                     </table>"
                HtmlString &= "                                                                 </div>"
                HtmlString &= "                                                             </td>"
                HtmlString &= "                                                         </tr>"
                HtmlString &= "                                                     </table>"
                HtmlString &= "                                                 </div>"
                HtmlString &= "                                             </td>"
                HtmlString &= "                                         </tr>"
            Next
            HtmlString &= "                                         </table>"
            HtmlString &= "                                     </td>"
            HtmlString &= "                                 </tr>"
            HtmlString &= "                             </table> "
            HtmlString &= "                         </td> "
            HtmlString &= "                     </tr> "
        Next
        HtmlString &= "                      </table> "
        HtmlString &= "                  </td> "
        HtmlString &= "              </tr> "
        HtmlString &= "          </table> "
        HtmlString &= "      </td> "
        HtmlString &= "  </tr> "
        HtmlString &= "</table>"
        Return HtmlString

    End Function
    Private Function GetPhotos(ByVal subId As String, ByVal MainName As String, ByVal SubName As String) As String

        Dim ds As New DataSet
        ds = GetDisplayGalleryPhotos(subId.Trim)

        Dim count As Integer = ds.Tables(0).Rows.Count
        Dim sp As Integer = 0
        Dim mycounter As Integer = 3

        Dim HtmlString As String
        HtmlString = "<table align='center' border='0'> "
        HtmlString &= "     <tr>"
        For sp = 0 To count
            Try
                If sp = 3 Or sp = 6 Or sp = 9 Or sp = 12 Or sp = 15 Or sp = 18 Or sp = 21 Or sp = 24 Or sp = 27 Or sp = 30 Or sp = 33 Or sp = 36 Or sp = 39 Or sp = 42 Or sp = 45 Then
                    HtmlString &= "     </tr>"
                    HtmlString &= "     <tr><td colspan='2'>&nbsp;</td></tr>"
                    HtmlString &= "     <tr>"
                End If
                Dim url As String = ds.Tables(0).Rows(sp).Item("Url")
                Dim Name As String = ds.Tables(0).Rows(sp).Item("Name")
                Dim photoId As String = ds.Tables(0).Rows(sp).Item("photoId")
                HtmlString &= "         <td height='275' valign='middle' align='center' bgcolor='#ffffff' width='240px'>"

                HtmlString &= " <a href='Members/Albums/" & MainName.Trim & "/" & SubName.Trim & "/" & url & "' data-lightbox='" & SubName.Trim & "' data-title='" & Name & "'><Image  runat='server'  src='Members/Albums/" & MainName.Trim & "/" & SubName.Trim & "/" & url & "' style='height: 225px; width: 225px'/></a>"


                HtmlString &= "             <span style='font-size:x-small;' class='HeaderLabel'>" & Name & "</span><br>"
                HtmlString &= "         </td>"
                HtmlString &= "         <td width='6px'>&nbsp;</td>"
            Catch ex As Exception
            End Try
        Next
        HtmlString &= "     </tr>"
        HtmlString &= "</table>"
        Return HtmlString

    End Function

    Private Function GetDisplayGalleryMain() As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@id", thisid.Trim)

        Dim str As String = ""
        str &= " SELECT * FROM AlbumMain "
        str &= " WHERE MemberId = @id"

        If thisalbumType = "Private" Then
            str &= " AND Private = 'False' "

        End If

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Private Function GetDisplayGallerySub(mainId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@mainId", mainId.Trim)
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT * FROM AlbumSub WHERE (mainId = @mainId) "
        If thisalbumType = "Private" Then
            str &= " AND Private = 'False' "
        End If
        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
    Private Function GetDisplayGalleryPhotos(ByVal subId As String) As DataSet
        Dim sqlconnection1 As New SqlClient.SqlConnection

        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@subId", subId.Trim)
        cmd.Parameters.AddWithValue("@id", thisid.Trim)
        Dim str As String = ""
        str &= " SELECT photoId, subId, Url, Name FROM AlbumPhotos WHERE (subId = @subId) "
        'If thisalbumType = "Farm" Then
        '    str &= " AND FarmId = @id"
        'End If
        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            sqlconnection1.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Email")
        Catch ex As Exception

        Finally
            sqlconnection1.Close()
        End Try
        Return ds
    End Function
End Class
