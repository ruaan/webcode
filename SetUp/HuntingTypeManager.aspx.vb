Imports System.Data
Partial Class SetUp_HuntingTypeManager
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateList()
    End Sub
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str = " SELECT * "
        str &= " FROM  tbl_Hunting_Types "
        str &= " ORDER BY HuntingType"

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
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtHuntingType.Text = ""
        lblId.Text = ""
        pnlDetail.Visible = False
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        pnlDetail.Visible = True
        lblId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim
        txtHuntingType.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text.Trim
        Dim thisActive As New CheckBox
        GridView1.Rows(e.CommandArgument).FindControl("ChkCertificate")
        chkActive.Checked = GridView1.Rows(e.CommandArgument).Cells(3).Text.Trim
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        pnlDetail.Visible = True
        txtHuntingType.Text = ""
        lblId.Text = "New"
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If lblId.Text = "New" Then
            AddHuntingType()
        Else
            UpdateHuntingType()
        End If
        If lblMessage.Text.Trim = "" Then
            txtHuntingType.Text = ""
            lblId.Text = ""
            pnlDetail.Visible = False
            PopulateList()
        End If
    End Sub
    Private Sub AddHuntingType()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntingType", txtHuntingType.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)

        Dim str As String = ""
        str = " INSERT INTO tbl_Hunting_Types "
        str &= " (HuntingType, Active) VALUES (@HuntingType, @Active)"

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
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub UpdateHuntingType()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntingType", txtHuntingType.Text.Trim)
        cmd.Parameters.AddWithValue("@Id", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)

        Dim str As String = ""
        str = " UPDATE tbl_Hunting_Types "
        str &= " SET HuntingType = @HuntingType, Active = @Active"
        str &= " Where id = @Id"

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
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
