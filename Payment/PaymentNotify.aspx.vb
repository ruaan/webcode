Imports System.Data
Partial Class Payment_PaymentNotify
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Request.Form.Count > 0 Then
            lblPaymentStatus.Text = Request.Form("payment_status")
            llbAmount_gross.Text = Request.Form("amount_gross")
        End If



        Dim HuntId As String = Request.QueryString("h")
        Dim HuntMemberId As String = Request.QueryString("m")

        UpdateMemberStatus(HuntId, "5", HuntMemberId)
        Dim DepositDS As New DataSet
        Try
            DepositDS = GetDepositDue(HuntId)
        Catch ex As Exception

        End Try

        Try

            If CDbl(DepositDS.Tables(0).Rows(0).Item("DepositValue").ToString) > CDbl(DepositDS.Tables(0).Rows(0).Item("MembersPaid").ToString) Then
                Dim DepPerPaid As Double = (CDbl(DepositDS.Tables(0).Rows(0).Item("MembersPaid").ToString) / CDbl(DepositDS.Tables(0).Rows(0).Item("DepositValue").ToString)) * 100
                UpdateStatus(HuntId, "8", DepPerPaid)
            Else
                UpdateStatus(HuntId, "5", "100")
            End If



        Catch ex As Exception

        End Try



    End Sub
    Private Sub UpdateStatus(HuntId As String, Status As String, PercDepositPaid As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)
        cmd.Parameters.AddWithValue("@Status", Status.Trim)
        cmd.Parameters.AddWithValue("@PercDepositPaid", PercDepositPaid.Trim)

        Dim str As String = ""
        str &= " UPDATE tbl_Hunts"
        str &= " SET Status = @Status, PercDepositPaid = @PercDepositPaid"
        str &= " WHERE (tbl_Hunts.HuntId = @HuntId)"

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


    End Sub

    Private Sub UpdateMemberStatus(HuntId As String, Status As String, Id As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)
        cmd.Parameters.AddWithValue("@Status", Status.Trim)
        cmd.Parameters.AddWithValue("@DepositPaid", llbAmount_gross.Text.Trim)
        cmd.Parameters.AddWithValue("@Id", Id.Trim)
        Dim str As String = ""
        str &= " UPDATE tbl_Hunts_Members"
        str &= " SET DepositPaid = @DepositPaid, Status = @Status"
        str &= " WHERE (Hunts_Id = @HuntId) AND (Id = @Id)"

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


    End Sub



    Private Function GetDepositDue(huntid As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", huntid.Trim)


        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.HuntId, MAX(tbl_Hunts.TotalDue) AS TotalDue, MAX(tbl_Hunts.DepositValue) AS DepositValue, tbl_Hunts.Status, tbl_Hunts.PercDepositPaid, SUM(tbl_Hunts_Members.DepositValue) AS MembersDue, "
        str &= "                          SUM(tbl_Hunts_Members.DepositPaid) AS MembersPaid"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Members ON tbl_Hunts.HuntId = tbl_Hunts_Members.Hunts_Id"
        str &= " GROUP BY tbl_Hunts.HuntId, tbl_Hunts.Status, tbl_Hunts.PercDepositPaid"
        str &= " HAVING        (tbl_Hunts.HuntId = @HuntId)"

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


        Return ds
    End Function

End Class
