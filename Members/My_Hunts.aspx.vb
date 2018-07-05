Imports System.Data
Partial Class Members_My_Hunts
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateHunts()
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PopulateHunts()
    End Sub

    Private Sub PopulateHunts()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)

        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.UniqueName, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts_Status.Description"
        str &= " FROM            tbl_Hunts_Members INNER JOIN"
        str &= "                          tbl_Hunts ON tbl_Hunts_Members.Hunts_Id = tbl_Hunts.HuntId INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId"
        str &= " WHERE        (tbl_Hunts_Members.MemberId = @MemberId)"
        If CheckBox2.Checked = False Then
            str &= " AND StatusId IN('1','2','5','6','8')"
        End If
        str &= " ORDER BY tbl_Hunts.Date_From"

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

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Response.Redirect("Hunts_Detail.aspx?h=" & GridView1.Rows(e.CommandArgument).Cells(0).Text.Trim)
    End Sub
End Class
