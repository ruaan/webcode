Imports System.Data
Partial Class News_NewsApp
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PlaceHolder1.Controls.Add(New LiteralControl(PopulateNews))
    End Sub


    Private Function PopulateNews() As String
        Dim htmlString As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand

        Dim str3 As String = ""
        str3 = "  SELECT     forum_question.id, forum_question.topic_heading, forum_question.topic_description, forum_question.datetime, COUNT(forum_answer.a_id) AS Comments, "
        str3 &= "                        forum_question.name"
        str3 &= "  FROM         forum_question LEFT OUTER JOIN"
        str3 &= "                        forum_answer ON forum_question.id = forum_answer.question_id"
        str3 &= "  WHERE     (forum_question.Active = 'True')"
        str3 &= "  GROUP BY forum_question.id, forum_question.topic_heading, forum_question.topic_description, forum_question.datetime, forum_question.name"
        str3 &= "  ORDER BY forum_question.datetime DESC"


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
        For sp = 0 To count

            htmlString &= "     <tr>"
            htmlString &= "         <td colspan='3' style='font-size: large;  color: #336699;'>"
            htmlString &= "   <img alt='blue comment bubble' src='../images/Icons/entry_bubble.gif'/>"
            htmlString &= "            &nbsp; <strong>"
            htmlString &= ds3.Tables(0).Rows(sp).Item("topic_heading").ToString.Trim
            htmlString &= "      </strong>  </td>"
            htmlString &= "    </tr>"

            htmlString &= "    <tr>"
            htmlString &= "        <td colspan='3'>"
            htmlString &= " &nbsp; "
            htmlString &= "         </td>"
            htmlString &= "     </tr>"

            htmlString &= "    <tr>"
            htmlString &= "        <td colspan='3'>"
            htmlString &= "By: " & ds3.Tables(0).Rows(sp).Item("name").ToString.Trim & " | " & Date.Parse(ds3.Tables(0).Rows(sp).Item("datetime").ToString.Trim).ToLongDateString
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
            htmlString &= "        <td colspan='3'>"
            htmlString &= ds3.Tables(0).Rows(sp).Item("topic_description").ToString.Trim
            htmlString &= "         </td>"
            htmlString &= "     </tr>"

            htmlString &= "    <tr>"
            htmlString &= "        <td colspan='3'>"
            htmlString &= "            &nbsp;</td>"
            htmlString &= "    </tr>"

            htmlString &= "    <tr>"
            htmlString &= "      <td >"

            htmlString &= "<a href='news_viewsApp.aspx?TopicId=" & ds3.Tables(0).Rows(sp).Item("id").ToString.Trim & "'>Read ( " & ds3.Tables(0).Rows(sp).Item("Comments").ToString.Trim & " comments)</a>"
            htmlString &= "       </td>"
            htmlString &= "       <td>"
            htmlString &= "           &nbsp;"
            htmlString &= "       </td>"
            htmlString &= "        <td>"
            htmlString &= "            &nbsp;"
            htmlString &= "        </td>"
            htmlString &= "    </tr>"



            htmlString &= "  <td colspan='3'>"
            htmlString &= "   <img alt='blue comment bubble' src='../images/Icons/dotted_line.gif' width='100%' height='1' />"
            htmlString &= " </td>"
            htmlString &= " </tr>"
            htmlString &= "    <tr>"
            htmlString &= "        <td colspan='3'>"
            htmlString &= "            &nbsp;</td>"
            htmlString &= "    </tr>"
            htmlString &= "   <tr>"
            htmlString &= "    <tr>"
            htmlString &= "        <td colspan='3'>"
            htmlString &= "            &nbsp;</td>"
            htmlString &= "    </tr>"
            htmlString &= "   <tr>"
        Next

        htmlString &= "  </table>"





        Return htmlString

    End Function
End Class
