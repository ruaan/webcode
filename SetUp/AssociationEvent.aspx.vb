Imports System.Data
Partial Class SetUp_AssociationEvent
    Inherits System.Web.UI.Page

#Region "Variants"

#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            PopulateAssociations()
        End If
    End Sub
    Protected Sub ddlAssociations_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAssociations.DataBound


        If ddlAssociations.Items.Count > 1 Then
            ddlAssociations.Items.Add("-Select-")
            ddlAssociations.SelectedValue = "-Select-"
        Else
            PopulateList(ddlAssociations.SelectedValue.Trim)
        End If


    End Sub
    Protected Sub ddlAssociations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssociations.SelectedIndexChanged
        If ddlAssociations.SelectedValue.Trim <> "-Select-" Then
            PopulateList(ddlAssociations.SelectedValue.Trim)
        End If
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Response.Redirect("EventCapture.aspx?eventId=" & GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim, True)
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateAssociations()
        Dim ds As New DataSet()
        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)

        Dim str As String = ""
        str &= "  SELECT        tbl_Associations.Association_Id, tbl_Associations.Name"
        str &= "  FROM            tbl_Associations INNER JOIN"
        str &= "                           tbl_Association_v_User ON tbl_Associations.Association_Id = tbl_Association_v_User.Association_Id"
        str &= "  WHERE        (tbl_Association_v_User.UserId = @UserId)"
        str &= "  ORDER BY tbl_Associations.Name"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlAssociations.DataSource = ds.Tables(0)
            ddlAssociations.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub PopulateList(ByVal Association As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", Association.Trim)

        Dim str As String = ""
        str = " SELECT event_id, Association_Id, Event_Name, EventType, EventDate FROM tbl_Association_Events WHERE (Association_Id = @Association_Id) "

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

#End Region


End Class
