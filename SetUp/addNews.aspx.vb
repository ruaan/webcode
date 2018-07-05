Imports System.Data
Partial Class SetUp_addNews
    Inherits System.Web.UI.Page
    Private Sub PopulateTopics()
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
        GridView1.DataSource = ds3.Tables(0)
        GridView1.DataBind()
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clear()
    End Sub
    Private Sub Clear()
        txtName.Text = ""
        txtContent.Text = ""
        txtDescription.Text = ""
        txtTopic.Text = ""
        lblId.Text = ""
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lblId.Text = "" Then
            AddTopic()
        Else
            UpdateTopic()
        End If
    End Sub
    Private Sub AddTopic()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@topic_heading", txtTopic.Text.Trim)
        cmd3.Parameters.AddWithValue("@topic_description", txtDescription.Text.Trim)
        cmd3.Parameters.AddWithValue("@topic_content", txtContent.Text.Trim)
        cmd3.Parameters.AddWithValue("@name", txtName.Text.Trim)
        cmd3.Parameters.AddWithValue("@datetime", Now.Date)
        cmd3.Parameters.AddWithValue("@Active", True)
        cmd3.Parameters.AddWithValue("@AllowComments", CheckBox1.Checked)
        cmd3.Parameters.AddWithValue("@topic_img", FileUpload1.FileName)
        Dim str3 As String = ""
        str3 = "  INSERT INTO forum_question "
        str3 &= " (topic_heading, topic_description, topic_content,  name, datetime, Active, AllowComments, topic_img)"
        str3 &= "  VALUES "
        str3 &= " (@topic_heading, @topic_description, @topic_content,  @name, @datetime, @Active, @AllowComments, @topic_img)"
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
        PopulateTopics()
        Clear()
        Upload()
    End Sub
    Private Sub Archive(ByVal id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@Id", id)

        Dim str3 As String = ""
        str3 = "  UPDATE forum_question "
        str3 &= " SET Active = 'False' "
        str3 &= "  WHERE id = @Id "

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
        PopulateTopics()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Archive" Then
            Archive(GridView1.Rows(e.CommandArgument).Cells(0).Text.Trim)
        ElseIf e.CommandName = "Change" Then
            Edit(GridView1.Rows(e.CommandArgument).Cells(0).Text.Trim)
        End If
    End Sub
    Private Sub Edit(ByVal Id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@Id", Id)
        Dim str3 As String = ""
        str3 = "  SELECT  * "
        str3 &= "  FROM  forum_question "
        str3 &= "  WHERE id = @Id "



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
        lblId.Text = Id
        txtName.Text = ds3.Tables(0).Rows(0).Item("name").ToString.Trim
        txtTopic.Text = ds3.Tables(0).Rows(0).Item("topic_heading").ToString.Trim
        txtDescription.Text = ds3.Tables(0).Rows(0).Item("topic_description").ToString.Trim
        txtContent.Text = ds3.Tables(0).Rows(0).Item("topic_content").ToString.Trim
        CheckBox1.Checked = ds3.Tables(0).Rows(0).Item("AllowComments").ToString.Trim
    End Sub
    Private Sub UpdateTopic()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd3 As New SqlClient.SqlCommand
        cmd3.Parameters.AddWithValue("@topic_heading", txtTopic.Text.Trim)
        cmd3.Parameters.AddWithValue("@topic_description", txtDescription.Text.Trim)
        cmd3.Parameters.AddWithValue("@topic_content", txtContent.Text.Trim)
        cmd3.Parameters.AddWithValue("@name", txtName.Text.Trim)
        cmd3.Parameters.AddWithValue("@datetime", Now)
        cmd3.Parameters.AddWithValue("@Id", lblId.Text)
        cmd3.Parameters.AddWithValue("@AllowComments", CheckBox1.Checked)
        cmd3.Parameters.AddWithValue("@topic_img", FileUpload1.FileName)
        Dim str3 As String = ""
        str3 = "  UPDATE forum_question "
        str3 &= " SET topic_heading = @topic_heading , topic_description = @topic_description, topic_content = @topic_content,  name = @name, datetime= @datetime , AllowComments = @AllowComments"
        If FileUpload1.FileName <> "" Then
            str3 &= " , topic_img = @topic_img "
        End If
        str3 &= "  WHERE id = @Id "
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
        PopulateTopics()
        Clear()

    End Sub
    Dim savePath As String
    Private Sub Upload()

        If (FileUpload1.HasFile) Then
            Dim savePath As String = ""
            Dim filename As String = ""
            Dim pathname As String = "Blogs\Images\"
            Dim pathnameRoot As String
            pathnameRoot = Server.MapPath(pathname)
            pathnameRoot = pathnameRoot.Replace("SetUp", "News")
            savePath = pathnameRoot
            If System.IO.Directory.Exists(savePath) Then
            Else
                System.IO.Directory.CreateDirectory(savePath)
            End If
            Try
                filename = FileUpload1.FileName
                savePath += filename
                FileUpload1.SaveAs(savePath)

            Catch ex As Exception

            End Try
        End If

    End Sub
End Class
