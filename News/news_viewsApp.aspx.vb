Imports System.Data
Partial Class News_news_viewsApp
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            BlogId.Text = Request.QueryString("TopicId").Trim
        Catch ex As Exception
            Response.Redirect("~/News/News.aspx")
        End Try
        BlogId.Text = Request.QueryString("TopicId").Trim
        PlaceHolder1.Controls.Add(New LiteralControl(CreateHTML))

    End Sub
    Private Function CreateHTML() As String
        Dim htmlString As String
        Dim thisTopic() As String = GetTopic()
        htmlString = "       <table style='width: 100%;' align='center'> "
        htmlString &= "    <tr>"
        htmlString &= "      <td >"
        htmlString &= "            &nbsp;"
        htmlString &= "       </td>"
        htmlString &= "       <td>"
        htmlString &= "           &nbsp;"
        htmlString &= "       </td>"
        htmlString &= "        <td>"
        htmlString &= "            &nbsp;"
        htmlString &= "        </td>"
        htmlString &= "    </tr>"
        htmlString &= "     <tr>"
        htmlString &= "         <td colspan='3' style='font-size: large;  color: #336699;'>"
        htmlString &= "   <img alt='blue comment bubble' src='../images/Icons/entry_bubble.gif'/>"
        htmlString &= "            &nbsp; <strong>"
        htmlString &= thisTopic(0)
        htmlString &= "      </strong>  </td>"
        htmlString &= "    </tr>"

        htmlString &= "    <tr>"
        htmlString &= "        <td colspan='3'>"
        htmlString &= " &nbsp; "
        htmlString &= "         </td>"
        htmlString &= "     </tr>"

        htmlString &= "    <tr>"
        htmlString &= "        <td colspan='3'>"
        htmlString &= "By: " & thisTopic(3) & " | " & Date.Parse(thisTopic(4)).ToLongDateString
        htmlString &= "         </td>"
        htmlString &= "     </tr>"
        htmlString &= "   <tr>"
        htmlString &= "  <td colspan='3'>"
        htmlString &= "   <img alt='blue comment bubble' src='../images/Icons/dotted_line.gif' width='100%' height='1' />"
        htmlString &= " </td>"
        htmlString &= " </tr>"
        htmlString &= "    <tr>"
        htmlString &= "        <td colspan='3'>"
        htmlString &= " &nbsp; "
        htmlString &= "         </td>"
        htmlString &= "     </tr>"
        htmlString &= "    <tr>"



        If thisTopic(5).Trim = "" Then
            htmlString &= "        <td colspan='3'>"
            htmlString &= " <strong> " & thisTopic(1) & " </strong> "
            htmlString &= "         </td>"
        Else
            htmlString &= "        <td >"
            htmlString &= "<img alt='image' src='Blogs/Images/" & thisTopic(5) & "'  />"
            htmlString &= "         </td>"
            htmlString &= "        <td colspan='2'>"
            htmlString &= "<strong> " & thisTopic(1) & " </strong>"
            htmlString &= "         </td>"
        End If



        htmlString &= "     </tr>"
        htmlString &= "    <tr>"
        htmlString &= "        <td colspan='3'>"
        htmlString &= "            &nbsp;</td>"
        htmlString &= "    </tr>"

        htmlString &= "    <tr>"

        htmlString &= "        <td colspan='3'>"
        htmlString &= thisTopic(2)
        htmlString &= "         </td>"

        htmlString &= "     </tr>"
        htmlString &= "    <tr>"
        htmlString &= "        <td colspan='3'>"
        htmlString &= "            &nbsp;</td>"
        htmlString &= "    </tr>"

        htmlString &= "    <tr>"
        htmlString &= "        <td  colspan='3'>"
        htmlString &= "            &nbsp;</td>"
        htmlString &= "    </tr>"

        htmlString &= "    <tr>"
        htmlString &= "        <td  colspan='3'>"
        htmlString &= "             &nbsp;</td>"
        htmlString &= "    </tr>"

        If thisTopic(6) = True Then
            htmlString &= GetComments()
        End If

        htmlString &= "    <tr>"
        htmlString &= "        <td  colspan='3'>"
        htmlString &= "             &nbsp;</td>"
        htmlString &= "    </tr>"
        htmlString &= "  </table>"

        If thisTopic(6) = True Then
            pnlComment.Visible = True
        Else
            pnlComment.Visible = False
        End If


        Return htmlString
    End Function
    Private Function GetTopic() As String()
        Dim topic(7) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@id", Request.QueryString("TopicId").Trim)
        Dim str3 As String = ""
        str3 = " SELECT  *"
        str3 &= "  FROM  forum_question"
        str3 &= " WHERE id = @id "


        cmd3.CommandText = str3
        cmd3.CommandType = CommandType.Text
        cmd3.Connection = myconnection
        myconnection.Open()
        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        da3.SelectCommand = cmd3
        da3.Fill(ds3, "Auto")
        myconnection.Close()

        topic(0) = ds3.Tables(0).Rows(0).Item("topic_heading").ToString.Trim
        topic(1) = ds3.Tables(0).Rows(0).Item("topic_description").ToString.Trim
        topic(2) = ds3.Tables(0).Rows(0).Item("topic_content").ToString.Trim
        topic(3) = ds3.Tables(0).Rows(0).Item("name").ToString.Trim
        topic(4) = ds3.Tables(0).Rows(0).Item("datetime").ToString.Trim
        topic(5) = ds3.Tables(0).Rows(0).Item("topic_img").ToString
        topic(6) = ds3.Tables(0).Rows(0).Item("AllowComments").ToString

        Return topic
    End Function
    Private Function GetComments() As String
        Dim htmlComments As String




        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@id", Request.QueryString("TopicId").Trim)
        Dim str3 As String = ""
        str3 = " SELECT  *"
        str3 &= "  FROM  forum_answer"
        str3 &= " WHERE  question_id = @id ORDER BY a_datetime "
        cmd3.CommandText = str3
        cmd3.CommandType = CommandType.Text
        cmd3.Connection = myconnection
        myconnection.Open()
        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        da3.SelectCommand = cmd3
        da3.Fill(ds3, "Auto")
        myconnection.Close()



        Dim count As Integer = ds3.Tables(0).Rows.Count - 1
        Dim sp As Integer

        htmlComments = "   <tr>"
        htmlComments &= "  <td colspan='3'>"
        htmlComments &= "   <img alt='blue comment bubble' src='../images/Icons/dotted_line.gif' width='100%' height='1' />"
        htmlComments &= " </td>"
        htmlComments &= "   <tr>"
        htmlComments &= "  <td colspan='3'>"
        htmlComments &= "   &nbsp;"
        htmlComments &= " </td>"
        htmlComments &= " </tr>"
        htmlComments &= " </tr>"
        htmlComments &= "    <tr>"
        htmlComments &= "        <td  colspan='3' style='color: #336699;'>"
        htmlComments &= "          <strong>   Comment (" & count + 1 & ")  </strong></td>"
        htmlComments &= "    </tr>"
        htmlComments &= "   <tr>"
        htmlComments &= "  <td colspan='3'>"
        htmlComments &= "   &nbsp;"
        htmlComments &= " </td>"
        htmlComments &= " </tr>"

        For sp = 0 To count


            htmlComments &= "     <tr>"
            htmlComments &= "           <td  colspan='3'>"
            htmlComments &= "         <table width='100%' border='0' cellpadding='3' cellspacing='1' >  "
            htmlComments &= "                      <tr>"
            htmlComments &= "       	<td colspan='3'>"
            htmlComments &= "   <img alt='blue comment bubble' src='../images/Icons/blue_comment_bubble.gif'/>"
            htmlComments &= "     &nbsp; Posted By "
            htmlComments &= "    <strong>  " & ds3.Tables(0).Rows(sp).Item("a_name").ToString.Trim & "</strong>"
            htmlComments &= "     on " & Date.Parse(ds3.Tables(0).Rows(sp).Item("a_datetime").ToString).ToString("dd MMMM yyyy HH:mm") & "</td> "
            htmlComments &= "     </tr>"
            htmlComments &= "            <tr>"
            htmlComments &= "               <td width='18%'>&nbsp;</td>"
            htmlComments &= "             <td width='5%'>&nbsp;</td>"
            htmlComments &= "           <td width=77%>"
            htmlComments &= "               &nbsp;</td>"
            htmlComments &= "         </tr>"
            htmlComments &= "            <tr>"
            htmlComments &= "               <td colspan='3' style='width: 95%'>" & ds3.Tables(0).Rows(sp).Item("a_answer").ToString.Trim & "</td>"
            htmlComments &= "         </tr>"
            htmlComments &= "            <tr>"
            htmlComments &= "               <td colspan='3' style='width: 95%'>&nbsp;</td> "
            htmlComments &= "        </tr>"
            htmlComments &= "   <tr>"
            htmlComments &= "  <td colspan='3'>"
            htmlComments &= "   <img alt='blue comment bubble' src='../images/Icons/dotted_line.gif' width='100%' height='1' />"
            htmlComments &= " </td>"
            htmlComments &= " </tr>"
            htmlComments &= " </table>"
            htmlComments &= " </td>"
            htmlComments &= " </tr>"
            htmlComments &= " <tr>"
            htmlComments &= " <td  colspan='3'>"
            htmlComments &= " &nbsp;</td>"
            htmlComments &= "  </tr>"
        Next
        Return htmlComments
    End Function
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        submitComment()
    End Sub
    Private Sub Start()
        PlaceHolder1.Controls.Clear()
        PlaceHolder1.Controls.Add(New LiteralControl(CreateHTML))

    End Sub
    Private Sub submitComment()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@question_id", BlogId.Text.Trim)
        Dim thisusername As String = Request.Cookies("UserId").Value

        cmd3.Parameters.AddWithValue("@a_name", thisusername)
        cmd3.Parameters.AddWithValue("@a_Memberidl", "1")
        cmd3.Parameters.AddWithValue("@a_answer", txtComment.Text.Trim)
        cmd3.Parameters.AddWithValue("@a_datetime", Now)

        Dim str3 As String = ""
        str3 = " INSERT INTO forum_answer"
        str3 &= "  (question_id, a_name, a_Memberidl, a_answer, a_datetime)"
        str3 &= " VALUES "
        str3 &= "  (@question_id, @a_name, @a_Memberidl, @a_answer, @a_datetime)"
        cmd3.CommandText = str3
        cmd3.CommandType = CommandType.Text
        cmd3.Connection = myconnection
        myconnection.Open()
        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        da3.SelectCommand = cmd3
        da3.Fill(ds3, "Auto")
        txtComment.Text = ""
        myconnection.Close()
        Start()
    End Sub

End Class
