Imports System.Data
Partial Class SetUp_PackageManager
    Inherits System.Web.UI.Page

#Region "Variants"

#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.Cookies("UserType").Value.Trim = "Super Admin" Then
                PopulateCompleteFarmList()
                btnAdd.Visible = True
            ElseIf Request.Cookies("UserType").Value.Trim = "Farm Super" Then
                PopulateFarmList()
                btnAdd.Visible = True
            Else
                btnAdd.Visible = False
            End If

            PopulateList()
        End If
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Response.Redirect("../Farms/frmPackagesManager.aspx")
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Response.Redirect("../Farms/frmPackagesManager.aspx?PackageId=" & GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
    End Sub
    Protected Sub cmbFarms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarms.SelectedIndexChanged
        PopulateList()
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@farmId", cmbFarms.SelectedValue.Trim)

        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Farm_Packages.packageId, tbl_Farm_Packages.Package, tbl_Farm_Packages.farmId, tbl_Farm.FarmName "
        str &= " FROM tbl_Farm_Packages INNER JOIN tbl_Farm ON tbl_Farm_Packages.farmId = tbl_Farm.id "
        str &= " WHERE tbl_Farm_Packages.farmId = @farmId "
        str &= " ORDER BY tbl_Farm_Packages.Package "

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

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Functions"
    Private Sub PopulateFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)
        Dim str As String = ""
        str &= " SELECT        tbl_Farm.FarmName, tbl_Farm.id "
        str &= " FROM            tbl_Farms_v_User INNER JOIN "
        str &= "                          tbl_Farm ON tbl_Farms_v_User.FarmId = tbl_Farm.id "
        str &= " WHERE        (tbl_Farms_v_User.UserId = @UserId) "
        str &= " ORDER BY tbl_Farm.FarmName"
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

        Try
            cmbFarms.DataSource = ds.Tables(0)
            cmbFarms.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PopulateCompleteFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)
        Dim str As String = ""
        str &= " SELECT tbl_Farm.FarmName, tbl_Farm.id "
        str &= " FROM tbl_Farm  "
        str &= " ORDER BY tbl_Farm.FarmName"
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

        Try
            cmbFarms.DataSource = ds.Tables(0)
            cmbFarms.DataBind()
        Catch ex As Exception

        End Try

    End Sub
#End Region


End Class
