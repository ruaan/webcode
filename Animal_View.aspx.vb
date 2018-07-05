Imports System.Data
Partial Class Animal_View
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PlaceHolder1.Controls.Add(New LiteralControl(LoadSpecy))
    End Sub
    Private Function LoadSpecy() As String
        Dim id As String = Request.QueryString("animalId")
        Dim dsAnimal As New DataSet
        dsAnimal = GetAnimal(id)

        Dim SavePath As String = ""
        Dim pathname As String = "Images\Animals\"
        Dim pathnameRoot As String

        pathnameRoot = Server.MapPath(pathname)
        pathnameRoot = pathnameRoot.Replace("\SetUp", "")
        SavePath = pathnameRoot

        Dim HtmlString As String = ""

        HtmlString = " <div id='mainPageWrapper1' style='padding: 5px'>"
        HtmlString &= "             <div class='div_Details' style='border: thin solid #333333; background-color: #CCCCCC '>"
        HtmlString &= "                 <div>&nbsp;</div>"
        If System.IO.File.Exists(SavePath & "/" & id.Trim & "Front.jpg") Then
            HtmlString &= "                 <div style='display: inline-block' class='MainImage-style'>"
            HtmlString &= "                     <img alt='' src='../Images/Animals/" & id & "Front.jpg' style='width: 100%; height: 100%' />"
            HtmlString &= "                 </div>"
        End If

        HtmlString &= "                 <div style='text-align: left; padding: 0px 0px 0px 10px; display: inline-block; vertical-align: top' id='divName' class='name-style3'>"
        HtmlString &= "                     <div style='text-align: left; border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 95%;'>"
        HtmlString &= "                         <div style='display: inline-block;'>"

        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("Name").ToString.Trim

        HtmlString &= "                         </div>"
        HtmlString &= "                         <div style='text-align: right; display: inline-block;'>"
        HtmlString &= "                         </div>"
        HtmlString &= "                     </div>"
        HtmlString &= "                 <div>&nbsp;</div>"
        HtmlString &= "                     <div style='font-weight: bold'>Scientific Name: "

        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("ScientificName").ToString.Trim

        HtmlString &= "                         </div>"
        HtmlString &= "                     <div>&nbsp;</div>"
        HtmlString &= "                     <div>"
        HtmlString &= "                         <table style='width: 100%;'>"
        HtmlString &= "                             <tr>"
        HtmlString &= "                                 <td>&nbsp;</td>"
        HtmlString &= "                                 <td style='font-weight: bold'>Male</td>"
        HtmlString &= "                                 <td style='font-weight: bold'>Female</td>"
        HtmlString &= "                             </tr>"
        HtmlString &= "                             <tr>"
        HtmlString &= "                                 <td style='font-weight: bold'>Avg Mass</td>"
        HtmlString &= "                                 <td>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("AvgMassMale").ToString.Trim & " Kg"
        HtmlString &= "                                 </td>"
        HtmlString &= "                                 <td>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("AveMassFemale").ToString.Trim & " Kg"
        HtmlString &= "                                 </td>"
        HtmlString &= "                             </tr>"
        HtmlString &= "                             <tr>"
        HtmlString &= "                                 <td style='font-weight: bold'>Avg Height</td>"
        HtmlString &= "                                 <td>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("AveHeightMale").ToString.Trim & " Cm"
        HtmlString &= "                                 </td>"
        HtmlString &= "                                 <td>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("AveHeightFemale").ToString.Trim & " Cm"
        HtmlString &= "                                 </td>"
        HtmlString &= "                             </tr>"
        HtmlString &= "                         </table>"
        HtmlString &= "                     </div>"
        HtmlString &= "                 </div>"
        HtmlString &= "                 <div>&nbsp</div>"
        HtmlString &= "                 <div id='Geninfo'>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("Comments").ToString.Trim
        HtmlString &= "                 </div>"
        HtmlString &= "                 <div>&nbsp</div>"
        HtmlString &= "                 <div align='center'>"


        If System.IO.File.Exists(SavePath & "/" & id.Trim & "Spoor.jpg") Then
            HtmlString &= "                     <div style='display: inline-block'>"
            HtmlString &= "                         <div>"
            HtmlString &= "                             <img alt='' src='../Images/Animals/" & id & "Spoor.jpg' class='img-style2' /></div>"
            HtmlString &= "                         <div>Spoor</div>"
            HtmlString &= "                     </div>"
        End If

        HtmlString &= "                     <div style='display: inline-block'>&nbsp;&nbsp;&nbsp;</div>"

        If System.IO.File.Exists(SavePath & "/" & id.Trim & "Dung.jpg") Then
            HtmlString &= "                     <div style='display: inline-block'>"
            HtmlString &= "                         <div>"
            HtmlString &= "                             <img alt='' src='../Images/Animals/" & id & "Dung.jpg' class='img-style2' /></div>"
            HtmlString &= "                         <div>Dung</div>"
            HtmlString &= "                     </div>"
        End If


        HtmlString &= "                 </div>"
        HtmlString &= "                 <div>&nbsp</div>"
        HtmlString &= "                 <div>"
        HtmlString &= "                     <asp:Panel ID='Panel1' runat='server'>"
        HtmlString &= "                         <div style='font-weight: bold'>Hunting Notes:</div>"
        HtmlString &= "                         <div>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("NotesOnHunting").ToString.Trim
        HtmlString &= "                         </div>"
        HtmlString &= "                     </asp:Panel>"
        HtmlString &= "                 </div>"
        HtmlString &= "                 <div>&nbsp</div>"
        HtmlString &= "                 <div align='center'>"

        If System.IO.File.Exists(SavePath & "/" & id.Trim & "ShotFront.jpg") Then
            HtmlString &= "                     <div style='display: inline-block'>"
            HtmlString &= "                         <div>"
            HtmlString &= "                             <img alt='' src='../Images/Animals/" & id & "ShotFront.jpg' class='img-style2' /></div>"
            HtmlString &= "                         <div>Front placement</div>"
            HtmlString &= "                     </div>"
        End If
        HtmlString &= "                     <div style='display: inline-block'>&nbsp;&nbsp;&nbsp;</div>"
        If System.IO.File.Exists(SavePath & "/" & id.Trim & "ShotSide.jpg") Then
            HtmlString &= "                     <div style='display: inline-block'>"
            HtmlString &= "                         <div>"
            HtmlString &= "                             <img alt='' src='../Images/Animals/" & id & "ShotSide.jpg' class='img-style2' /></div>"
            HtmlString &= "                         <div>Side placement</div>"
            HtmlString &= "                     </div>"
        End If

        HtmlString &= "                 </div>"
        HtmlString &= "                 <div>&nbsp</div>"
        HtmlString &= "                 <div>"
        HtmlString &= "                     <asp:Panel ID='Panel2' runat='server'>"
        HtmlString &= "                         <div style='font-weight: bold'>Shot Placements:</div>"
        HtmlString &= "                         <div>"
        HtmlString &= dsAnimal.Tables(0).Rows(0).Item("ShotPlacements").ToString.Trim
        HtmlString &= "                         </div>"
        HtmlString &= "                     </asp:Panel>"
        HtmlString &= "                 </div>"
        HtmlString &= "                 <div>&nbsp</div>"
        HtmlString &= "             </div>"
        HtmlString &= "             <div>&nbsp</div>"
        HtmlString &= "          </div>"

        Return HtmlString
    End Function
    Private Function GetAnimal(id As String) As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", id)




        Dim str As String = ""
        str &= " SELECT        id, Name, FrontPicPath, SidePicPath, SpoorPicPath, DungPicPath, AvgMassMale, AveHeightMale, AveMassFemale, AveHeightFemale, ScientificName, MinimumCalibre, RecommendedCalibre, NotesOnHunting, ShotPlacements, "
        str &= "                          ShotPlacementPicPath, Comments, Animal_Group"
        str &= " FROM            dbo.tbl_Animals"
        str &= " WHERE        (id = @id)"



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
