Imports System.Data
Partial Class SetUp_MemberManager
    Inherits System.Web.UI.Page

#Region "Variants"

#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            PopulateList()
            If Request.Cookies("UserType").Value.Trim <> "Super Admin" Then
                btnAdd.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Response.Redirect("../Member_Registration.aspx")
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Response.Redirect("../Members/member_Edit_Profile.aspx?MemberId=" & GridView1.Rows(e.CommandArgument).Cells(1).Text.ToString)
    End Sub
    Protected Sub imgBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnSearch.Click
        PopulateList()
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@userId", Request.Cookies("UserId").Value.Trim)
        cmd.Parameters.AddWithValue("@Search", txtSearch.Text.Trim & "%")
        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Member.MemberId, tbl_Member.Surname + ', ' + tbl_Member.FullName AS MemberName "
        str &= " FROM tbl_Member INNER JOIN tbl_Users ON tbl_Member.MemberId = tbl_Users.MemberId "
        str &= " WHERE  ((Surname LIKE @Search) OR (FullName LIKE @Search) OR (PreferredName LIKE @Search))  "
        If Request.Cookies("UserType").Value.Trim <> "Super Admin" Then
            str &= " AND (tbl_Users.id = @userId) "
        End If


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
#End Region

#Region "Functions"

#End Region


End Class
