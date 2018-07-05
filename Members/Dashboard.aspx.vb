Imports System.Data
Partial Class Members_Dashboard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Request.Browser.IsMobileDevice = True Then
            Response.Redirect("Dashboard_Mobi.aspx")
        End If
        Label1.Text = Request.Cookies("memberid").Value
        PlaceHolderadd.Controls.Add(New LiteralControl(LoadBanner))
    End Sub
    Private Function LoadBanner() As String
        Dim htmlString As String

        Dim SavePath As String = ""
        Dim SavePath1 As String = ""
        Dim pathname As String = "Farms\Images\FarmProfiles\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        pathnameRoot = pathnameRoot.Replace("\Members", "")
        SavePath = pathnameRoot
        pathname = "News\Blogs\Images\"
        pathnameRoot = Server.MapPath(pathname)
        pathnameRoot = pathnameRoot.Replace("\Members", "")
        SavePath1 = pathnameRoot

        Dim dsNews As New DataSet
        Dim dsNewFarm As New DataSet
        dsNews = getNews()
        dsNewFarm = getFarms()
        Dim newsCount As Integer = dsNews.Tables(0).Rows.Count - 1
        Dim farmCount As Integer = dsNewFarm.Tables(0).Rows.Count - 1

        Dim spNews, spFarms As Integer


        htmlString = "     <div>&nbsp;</div>"

        If newsCount > -1 Then


            htmlString &= "              <div  style='font-family: Calibri; font-size: large; color: #FFFFFF; background-color: #5B6849; text-align:center;' >Latest "
            htmlString &= " News</div>"
            htmlString &= " <div class=""cycle-slideshow"" "
            htmlString &= "     data-cycle-fx='scrollDown'"
            htmlString &= "     data-cycle-timeout='5000'"
            htmlString &= "     data-cycle-slides='> div'"
            htmlString &= "     >"

            '/////count here\\\\\\
            For spNews = 0 To newsCount
                htmlString &= "     <div  style='background:#E2E2E2; width: 100%;'  onclick=""location.href = '../../News/news_view.aspx?TopicId=" & dsNews.Tables(0).Rows(spFarms).Item("id").ToString.Trim & "'"">"
                htmlString &= "         <div>"
                htmlString &= "             <div style='display: inline-block;' class='land-style1'>"
                If System.IO.File.Exists(SavePath1 & dsNews.Tables(0).Rows(spNews).Item("topic_img").ToString.Trim) Then
                    htmlString &= "                 <img alt='' src='../News/Blogs/Images/" & dsNews.Tables(0).Rows(spNews).Item("topic_img").ToString.Trim & "' class='news-style1' />"
                Else
                    htmlString &= "     &nbsp;"

                End If

                htmlString &= "             </div>"
                htmlString &= "             <div style='display: inline-block; padding-left: 10px;'>"
                htmlString &= "                 <strong>" & dsNews.Tables(0).Rows(spNews).Item("topic_heading").ToString.Trim & "</strong>"
                htmlString &= "             </div>"
                htmlString &= "         </div>"
                htmlString &= " <p> "
                htmlString &= dsNews.Tables(0).Rows(spNews).Item("topic_description").ToString.Trim
                htmlString &= " </p>"
                htmlString &= "    </div>"
            Next

            htmlString &= "            </div> "

            htmlString &= " <div>&nbsp;</div>"
        End If

        htmlString &= "             <div  style='font-family: Calibri; font-size: large; color: #FFFFFF; background-color: #5B6849; text-align:center;' >Recently Updated Farms</div>"


        htmlString &= "  <div class='cycle-slideshow' "
        htmlString &= "      data-cycle-fx=scrollHorz"
        htmlString &= "      data-cycle-timeout=2000"
        htmlString &= "      cycle-slideshow { width: 80% }"
        htmlString &= "      cycle-slideshow img { width: 100%; height: auto }"
        htmlString &= "      >"

        htmlString &= "      <!-- empty element for overlay -->"
        htmlString &= "      <div class='cycle-overlay'></div>"



        '/////count here\\\\\\
        For spFarms = 0 To farmCount

            If System.IO.File.Exists(SavePath & dsNewFarm.Tables(0).Rows(spFarms).Item("id").ToString.Trim & "Main.jpg") Then
                htmlString &= "     <img src='../Farms/Images/FarmProfiles/" & dsNewFarm.Tables(0).Rows(spFarms).Item("id").ToString.Trim & "Main.jpg' "
                htmlString &= "          data-cycle-title='" & dsNewFarm.Tables(0).Rows(spFarms).Item("FarmName").ToString.Trim & "' "
                htmlString &= "          data-cycle-desc='" & dsNewFarm.Tables(0).Rows(spFarms).Item("Name").ToString.Trim & "' "
                htmlString &= "        onclick=""location.href = '../../farm_view.aspx?id=" & dsNewFarm.Tables(0).Rows(spFarms).Item("id").ToString.Trim & "'"">"
            Else
                htmlString &= "     <img src='../Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg'"
                htmlString &= "          data-cycle-title='" & dsNewFarm.Tables(0).Rows(spFarms).Item("FarmName").ToString.Trim & "' "
                htmlString &= "          data-cycle-desc='" & dsNewFarm.Tables(0).Rows(spFarms).Item("Name").ToString.Trim & "' "
                htmlString &= "        onclick=""location.href = '../../farm_view.aspx?id=" & dsNewFarm.Tables(0).Rows(spFarms).Item("id").ToString.Trim & "'"">"
            End If


        Next



        htmlString &= "   </div>"



        Return htmlString
    End Function

    Private Function getNews() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand

        Dim str3 As String = ""
        str3 = "  SELECT     forum_question.id, forum_question.topic_heading, forum_question.topic_description, forum_question.datetime, COUNT(forum_answer.a_id) AS Comments, "
        str3 &= "                        forum_question.name, forum_question.topic_img"
        str3 &= "  FROM         forum_question LEFT OUTER JOIN"
        str3 &= "                        forum_answer ON forum_question.id = forum_answer.question_id"
        str3 &= "  WHERE     (forum_question.Active = 'True')"
        str3 &= "  GROUP BY forum_question.id, forum_question.topic_heading, forum_question.topic_description, forum_question.datetime, forum_question.name,  forum_question.topic_img"
        str3 &= "  ORDER BY forum_question.datetime DESC"


        cmd3.CommandText = str3
        cmd3.CommandType = CommandType.Text
        cmd3.Connection = myconnection
        myconnection.Open()
        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        da3.SelectCommand = cmd3
        Try
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try

        Return ds3




    End Function
    Private Function getFarms() As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand

        Dim str3 As String = ""
        str3 &= " SELECT        TOP (10) tbl_Farm.id, tbl_Farm.FarmName, tbl_Farm.Province, tbl_Farm.Status, tblProvince.Name"
        str3 &= " FROM            tbl_Farm INNER JOIN"
        str3 &= "                          tblProvince ON tbl_Farm.Province = tblProvince.ProvinceId"
        str3 &= " WHERE        (tbl_Farm.Status = '2')"
        str3 &= "  ORDER BY tbl_Farm.id DESC"

        cmd3.CommandText = str3
        cmd3.CommandType = CommandType.Text
        cmd3.Connection = myconnection
        myconnection.Open()
        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        da3.SelectCommand = cmd3
        Try
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try

        Return ds3




    End Function

End Class
