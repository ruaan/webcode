Imports System.Data
Partial Class SetUp_SetUp_EmailReceivers
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
        str &= " FROM  tblEmailReceivers "
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
        txtEco_Tourism.Text = ""
        lblId.Text = ""
        pnlDetail.Visible = False
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        pnlDetail.Visible = True
        lblId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim
        txtEco_Tourism.Text = GridView1.Rows(e.CommandArgument).Cells(2).Text.Trim
        Dim thisActive As New CheckBox
        GridView1.Rows(e.CommandArgument).FindControl("ChkCertificate")
        chkActive.Checked = GridView1.Rows(e.CommandArgument).Cells(3).Text.Trim
        PopulateReceiverDetailsindividual()
        PopulateMailsReceive()
        btnRemove.Visible = True
    End Sub
    Private Sub PopulateMailsReceive()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@ReceiverId", lblId.Text.Trim)


        Dim str As String = ""
        str &= " SELECT        tblEmailWhoReceives.id, tblEmailWhoReceives.EmailTypeId, tblEmailWhoReceives.ReceiverId, tblEmailWhoReceives.Active, tblEmailTypes.EmailType"
        str &= " FROM            tblEmailWhoReceives INNER JOIN"
        str &= "                          tblEmailTypes ON tblEmailWhoReceives.EmailTypeId = tblEmailTypes.id"
        str &= " where ReceiverId = @ReceiverId"

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
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        pnlDetail.Visible = True
        txtEco_Tourism.Text = ""
        lblId.Text = "New"
        pnlEmails.Visible = False
        btnRemove.Visible = False
        GridView2.DataSource = Nothing
        GridView2.DataBind()
    End Sub
    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        lblMessage.Text = ""
        If lblId.Text = "New" Then
            AddHuntingType()
            pnlEmails.Visible = True
        Else
            UpdateHuntingType()
        End If
        If lblMessage.Text.Trim = "" Then

            PopulateList()
        End If
    End Sub
    Private Sub AddHuntingType()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Name", txtEco_Tourism.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

        Dim str As String = ""
        str = " INSERT INTO tblEmailReceivers "
        str &= " (Name, Email, Active) VALUES (@Name, @Email, @Active)"
        str &= " SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]"

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
            lblId.Text = ds.Tables(0).Rows(0).Item("SCOPE_IDENTITY").ToString
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

        cmd.Parameters.AddWithValue("@Name", txtEco_Tourism.Text.Trim)
        cmd.Parameters.AddWithValue("@Id", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@Active", chkActive.Checked)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)

        Dim str As String = ""
        str = " UPDATE tblEmailReceivers "
        str &= " SET Name = @Name, Email = @Email, Active = @Active"
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
    Protected Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        pnlRemoveConfirm.Visible = True
    End Sub
    Protected Sub btnDeleteCancel_Click(sender As Object, e As EventArgs) Handles btnDeleteCancel.Click
        pnlRemoveConfirm.Visible = False
    End Sub
    Private Sub DeleteEmailReceivers()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblId.Text.Trim)

        Dim str As String = ""
        str = " DELETE FROM tblEmailReceivers "
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
    Private Sub DeleteReceiverLinks()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblId.Text.Trim)

        Dim str As String = ""
        str = " DELETE FROM tblEmailWhoReceives "
        str &= " Where ReceiverId = @Id"

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
    Protected Sub btnDeleteYes_Click(sender As Object, e As EventArgs) Handles btnDeleteYes.Click
        DeleteReceiverLinks()
        DeleteEmailReceivers()
        PopulateList()
        pnlDetail.Visible = False
        pnlEmailList.Visible = False
        pnlRemoveConfirm.Visible = False
        ClearText()
    End Sub
    Protected Sub btnaddEmail_Click(sender As Object, e As EventArgs) Handles btnaddEmail.Click
        pnlEmailList.Visible = True
        PopulateEmailtypeList()
    End Sub
    Private Sub PopulateEmailtypeList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT id, EmailType"
        str &= " FROM tblEmailTypes"
        str &= " ORDER BY EmailType"

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
            GridView3.DataSource = ds.Tables(0)
            GridView3.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView2.RowCommand
        If e.CommandName = "Remove" Then
            RemoveEmailType(GridView2.Rows(e.CommandArgument).Cells(0).Text.Trim)
        ElseIf e.CommandName = "deactive" Then
            ActivateEmailType(GridView2.Rows(e.CommandArgument).Cells(0).Text.Trim, GridView2.Rows(e.CommandArgument).Cells(2).Text.Trim)
        End If
    End Sub
    Private Sub RemoveEmailType(EmailTypeId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@ReceiverId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@EmailTypeId", EmailTypeId.Trim)

        Dim str As String = ""
        str &= " DELETE"
        str &= " FROM tblEmailWhoReceives"
        str &= " where ReceiverId = @ReceiverId AND EmailTypeId = @EmailTypeId"

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
            PopulateMailsReceive()
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub ActivateEmailType(EmailTypeId As String, Active As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@ReceiverId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@EmailTypeId", EmailTypeId.Trim)
        If Active = "True" Then
            Active = "False"
        Else
            Active = "True"
        End If
        cmd.Parameters.AddWithValue("@Active", Active)

        Dim str As String = ""
        str &= " UPDATE tblEmailWhoReceives"
        str &= " SET Active = @Active"
        str &= " where ReceiverId = @ReceiverId AND EmailTypeId = @EmailTypeId"

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
            PopulateMailsReceive()
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnSumbit_Click(sender As Object, e As EventArgs) Handles btnSumbit.Click
        Dim count As Integer = GridView3.Rows.Count - 1
        Dim sp As Integer
        Dim isChecked As New CheckBox
        For sp = 0 To count
            isChecked = GridView3.Rows(sp).FindControl("Chkreceive")
            If isChecked.Checked Then
                AddEmailType(GridView3.Rows(sp).Cells(0).Text.Trim)
            End If
        Next

        pnlEmailList.Visible = False
    End Sub
    Private Sub AddEmailType(EmailTypeId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@ReceiverId", lblId.Text.Trim)
        cmd.Parameters.AddWithValue("@EmailTypeId", EmailTypeId.Trim)
        cmd.Parameters.AddWithValue("@Active", "True")

        Dim str As String = ""
        str &= " INSERT INTO tblEmailWhoReceives"
        str &= " (EmailTypeId, ReceiverId, Active) VALUES (@EmailTypeId, @ReceiverId, @Active) "


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
            PopulateMailsReceive()
        Catch ex As Exception
            lblMessage.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub btnEmailListCancel_Click(sender As Object, e As EventArgs) Handles btnEmailListCancel.Click
        pnlEmailList.Visible = False
    End Sub
    Protected Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        pnlDetail.Visible = False
        pnlEmailList.Visible = False
        pnlRemoveConfirm.Visible = False
        ClearText()
    End Sub
    Private Sub ClearText()
        txtEco_Tourism.Text = ""
        txtEmail.Text = ""
    End Sub
    Private Sub PopulateReceiverDetailsindividual()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", lblId.Text.Trim)
        Dim str As String = ""
        str = " SELECT * "
        str &= " FROM  tblEmailReceivers "
        str &= " Where Id = @Id"

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

        txtEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
    End Sub
End Class
