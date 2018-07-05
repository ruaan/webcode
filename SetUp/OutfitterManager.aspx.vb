Imports System.Data
Partial Class SetUp_OutfitterManager
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("../Outfitters/outfitter_Edit_Profile.aspx", True)
    End Sub
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str = " SELECT *  FROM tbl_Outfitter ORDER BY FarmName"

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
            lblMessage.Text &= ex.Message
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateList()
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Response.Redirect("../Outfitters/outfitter_Edit_Profile.aspx?OutId=" & GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
    End Sub
    Private Sub SetUp_FarmManager_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Dim MemberId As String = ""
        Try
            MemberId = Request.Cookies("MemberId").Value
        Catch ex As Exception
            Response.Redirect("~/Login.aspx")
        End Try

    End Sub
End Class
