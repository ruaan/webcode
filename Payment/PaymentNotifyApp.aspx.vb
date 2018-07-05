Imports System.Data
Partial Class Payment_PaymentNotifyApp
    Inherits System.Web.UI.Page


    Dim AmountPaid As String = ""
    Dim AmountFee As String = ""
    Dim AmountNet As String = ""
    Dim paymentType As String = ""
    Dim paymentStatus As String = ""
    Dim PayfastId As String = ""

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Request.Form.Count > 0 Then
            AmountPaid = Request.Form("amount_gross")
            AmountFee = Request.Form("amount_fee")
            AmountNet = Request.Form("amount_net")
            paymentType = Request.Form("item_name")
            paymentStatus = Request.Form("payment_status")
            PayfastId = Request.Form("pf_payment_id")

        End If

        Dim memberHuntId As String = Request.QueryString("M")
        Dim huntId As String = Request.QueryString("h")

        Dim huntDetails() As String = GetHuntDetails(memberHuntId)

        RecordPayment(huntDetails(1), huntDetails(0), paymentType, huntId, memberHuntId, AmountPaid, AmountFee, AmountNet, PayfastId)
        UpdateMemberPayment(memberHuntId, AmountPaid)
        UpdateHuntPayment(huntId, AmountPaid)


    End Sub
    Private Function GetHuntDetails(memberHuntId As String) As String()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", memberHuntId)


        Dim str As String = ""
        str &= "  SELECT        tbl_Hunts_Members.Id, tbl_Hunts_Members.Hunts_Id, tbl_Hunts_Members.MemberId, tbl_Hunts.FarmId"
        str &= "  FROM            tbl_Hunts_Members INNER JOIN"
        str &= "                           tbl_Hunts ON tbl_Hunts_Members.Hunts_Id = tbl_Hunts.HuntId"
        str &= "  WHERE        (tbl_Hunts_Members.Id = @Id)"
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

        Dim statusDetail(3) As String


        Try

            statusDetail(0) = ds.Tables(0).Rows(0).Item("MemberId").ToString
            statusDetail(1) = ds.Tables(0).Rows(0).Item("FarmId").ToString
        Catch ex As Exception

        End Try

        Return statusDetail
    End Function
    Private Sub UpdateMemberPayment(memberHuntId As String, Amountpaid As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", memberHuntId)

        cmd.Parameters.AddWithValue("@DepositPaid", Amountpaid)

        cmd.Parameters.AddWithValue("@Status", "5")

        Dim str As String = ""
        str &= "  UPDATE tbl_Hunts_Members "
        str &= "  SET DepositPaid = @DepositPaid, Status = @status"
        str &= "  WHERE Id = @Id"

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
    Private Sub UpdateHuntPayment(HuntId As String, Amountpaid As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", HuntId)
        Dim thisStatus() As String = GetHuntStatus(HuntId, Amountpaid)
        cmd.Parameters.AddWithValue("@DepositPaid", thisStatus(1))
        cmd.Parameters.AddWithValue("@Status", thisStatus(0))
        cmd.Parameters.AddWithValue("@PercDepositPaid", thisStatus(2))

        Dim str As String = ""
        str &= "  UPDATE tbl_Hunts "
        str &= "  SET PercDepositPaid = @PercDepositPaid, Status = @status"
        str &= "  WHERE HuntId  = @Id"

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
    Private Function GetMemberStatus(memberHuntId As String, Amountpaid As String) As String()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", memberHuntId)
        cmd.Parameters.AddWithValue("@DepositPaid", Amountpaid)


        Dim str As String = ""
        str &= "  Select DepositValue,  DepositPaid, Status, Hunts_Id "
        str &= "  FROM tbl_Hunts_Members"
        str &= "  WHERE Id = @Id"

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

        Dim statusDetail(3) As String

        Dim DepositValue As Double = 0
        Dim DepositalreadyPaid As Double = 0
        Dim DepositnowPaid As Double = CDbl(Amountpaid)
        Dim TotalDepositPaid As Double = 0
        Dim DepositDiff As Double = 0
        Try

            DepositValue = CDbl(ds.Tables(0).Rows(0).Item("DepositValue").ToString)
            DepositalreadyPaid = CDbl(ds.Tables(0).Rows(0).Item("DepositPaid").ToString)
            TotalDepositPaid = DepositalreadyPaid + DepositnowPaid
            If DepositValue - TotalDepositPaid = 0 Then
                statusDetail(0) = "5"
            ElseIf TotalDepositPaid = 0 Then
                statusDetail(0) = "2"
            ElseIf DepositValue - TotalDepositPaid > 0 Then
                statusDetail(0) = "8"
            ElseIf DepositValue - TotalDepositPaid < 0 Then
                statusDetail(0) = "5"
            End If

            statusDetail(1) = TotalDepositPaid
            statusDetail(2) = ds.Tables(0).Rows(0).Item("Hunts_Id").ToString
        Catch ex As Exception

        End Try

        Return statusDetail

    End Function
    Private Function GetHuntStatus(HuntId As String, Amountpaid As String) As String()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Id", HuntId)
        cmd.Parameters.AddWithValue("@DepositPaid", Amountpaid)


        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.DepositValue, tbl_Hunts.DepositDue, tbl_Hunts.PercDepositPaid, SUM(tbl_Hunts_Members.DepositPaid) AS DepositPaid"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Members ON tbl_Hunts.HuntId = tbl_Hunts_Members.Hunts_Id"
        str &= " WHERE        (tbl_Hunts.HuntId = @Id)"
        str &= " GROUP BY tbl_Hunts.DepositValue, tbl_Hunts.DepositDue, tbl_Hunts.PercDepositPaid"


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

        Dim statusDetail(3) As String
        Dim DepositValue As Double = 0
        Dim DepositalreadyPaid As Double = 0
        Dim DepositnowPaid As Double = CDbl(Amountpaid)
        Dim TotalDepositPaid As Double = 0
        Dim DepositDiff As Double = 0
        Try

            DepositValue = CDbl(ds.Tables(0).Rows(0).Item("DepositValue").ToString)
            DepositalreadyPaid = CDbl(ds.Tables(0).Rows(0).Item("DepositPaid").ToString)
            TotalDepositPaid = DepositalreadyPaid + DepositnowPaid
            If DepositValue - TotalDepositPaid = 0 Then
                statusDetail(0) = "5"
            ElseIf TotalDepositPaid = 0 Then
                statusDetail(0) = "2"
            ElseIf DepositValue - TotalDepositPaid > 0 Then
                statusDetail(0) = "8"
            ElseIf DepositValue - TotalDepositPaid < 0 Then
                statusDetail(0) = "5"
            End If

            statusDetail(1) = TotalDepositPaid
            Try
                statusDetail(2) = (TotalDepositPaid / DepositValue) * 100

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

        Return statusDetail

    End Function
    Private Sub RecordPayment(FarmId As String, MemberId As String, PaymentType As String, HuntId As String, HuntMemberId As String, AmountPaid As Double, PayfastFee As Double, NetAmount As Double, PayfastId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId)
        cmd.Parameters.AddWithValue("@MemberId", MemberId)
        cmd.Parameters.AddWithValue("@PaymentType", PaymentType)
        cmd.Parameters.AddWithValue("@HuntId", HuntId)
        cmd.Parameters.AddWithValue("@HuntMemberId", HuntMemberId)
        cmd.Parameters.AddWithValue("@PaymentDate", Now)
        cmd.Parameters.AddWithValue("@AmountPaid", AmountPaid)
        cmd.Parameters.AddWithValue("@PayfastFee", PayfastFee)
        cmd.Parameters.AddWithValue("@NetAmount", NetAmount)
        cmd.Parameters.AddWithValue("@PayfastId", PayfastId)

        Dim str As String = ""
        str &= "  Insert INTO tbl_Farm_Payments "
        str &= "  (FarmId, MemberId, PaymentType, HuntId, HuntMemberId, PaymentDate, AmountPaid, PayfastFee, NetAmount, PayfastId)"
        str &= "  VALUES"
        str &= "  (@FarmId, @MemberId, @PaymentType, @HuntId, @HuntMemberId, @PaymentDate, @AmountPaid, @PayfastFee, @NetAmount, @PayfastId)"

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
End Class
