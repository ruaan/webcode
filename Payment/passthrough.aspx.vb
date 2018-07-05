Imports System.Text
Imports System.Collections.Specialized
Imports System.Data
Partial Class Payment_passthrough
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        PostData(Request.QueryString("h"))

    End Sub

    Protected Sub PostData(HuntId As String)

        Dim thisData As New DataSet
        thisData = GetHuntDetails(HuntId)

        Dim collections As New NameValueCollection()
        collections.Add("merchant_id", "10000100")
        collections.Add("merchant_key", "46f0cd694581a")
        collections.Add("return_url", "http://ecohunter-app.co.za/Payment/PaymentSuccess.aspx?h=" & thisData.Tables(0).Rows(0).Item("Hunts_Id").ToString.Trim & "&M=" & thisData.Tables(0).Rows(0).Item("Id").ToString.Trim)
        collections.Add("cancel_url", "http://ecohunter-app.co.za/Payment/PaymentCancel.aspx?h=" & thisData.Tables(0).Rows(0).Item("Hunts_Id").ToString.Trim & "&M=" & thisData.Tables(0).Rows(0).Item("Id").ToString.Trim)
        collections.Add("notify_url", "http://ecohunter-app.co.za/Payment/PaymentNotify.aspx?h=" & thisData.Tables(0).Rows(0).Item("Hunts_Id").ToString.Trim & "&M=" & thisData.Tables(0).Rows(0).Item("Id").ToString.Trim)
        collections.Add("amount", thisData.Tables(0).Rows(0).Item("DepositValue").ToString.Trim)
        collections.Add("item_name", "Deposit")
        collections.Add("m_payment_id", thisData.Tables(0).Rows(0).Item("Hunts_Id").ToString.Trim)
        collections.Add("item_description", "Deposit for Hunting Trip")
        collections.Add("name_first", thisData.Tables(0).Rows(0).Item("PreferredName").ToString.Trim)
        collections.Add("name_last", thisData.Tables(0).Rows(0).Item("Surname").ToString.Trim)
        collections.Add("email_address", thisData.Tables(0).Rows(0).Item("Expr1").ToString.Trim)
        collections.Add("cell_number", thisData.Tables(0).Rows(0).Item("CellNo").ToString.Trim)

        Dim remoteUrl As String = "https://sandbox.payfast.co.za/eng/process"

        Dim html As String = "<html><head>"
        html += "</head><body onload='document.forms[0].submit()'>"
        html += String.Format("<form name='PostForm' method='POST' action='{0}'>", remoteUrl)
        For Each key As String In collections.Keys
            html += String.Format("<input name='{0}' type='hidden' value='{1}'>", key, collections(key))
        Next
        html += "</form></body></html>"
        Response.Clear()
        Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1")
        Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1")
        Response.Charset = "ISO-8859-1"
        Response.Write(html)
        Response.End()

    End Sub


    Private Function GetHuntDetails(HuntId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)


        Dim str As String = ""
        str &= " SELECT        tbl_Hunts_Members.Id, tbl_Hunts_Members.Hunts_Id, tbl_Hunts_Members.MemberId, tbl_Hunts_Members.Type, tbl_Hunts_Members.OwnAccount, tbl_Hunts_Members.Name, tbl_Hunts_Members.Mobil, "
        str &= "                          tbl_Hunts_Members.Email, tbl_Hunts_Members.AccomValue, tbl_Hunts_Members.AdditionalValue, tbl_Hunts_Members.SpeciesValue, tbl_Hunts_Members.ExtraValue, tbl_Hunts_Members.CountryId, "
        str &= "                          tbl_Hunts_Members.FlightId, tbl_Hunts_Members.CarId, tbl_Hunts_Members.DepositValue, tbl_Hunts_Members.FinalValue, tbl_Hunts_Members.DepositPaid, tbl_Hunts_Members.Status, tbl_Member.Surname, "
        str &= "                          tbl_Member.PreferredName, tbl_Member.Email AS Expr1, tbl_Member.CellNo"
        str &= " FROM            tbl_Hunts_Members INNER JOIN"
        str &= "                          tbl_Member ON tbl_Hunts_Members.MemberId = tbl_Member.MemberId"
        str &= " WHERE        (tbl_Hunts_Members.Hunts_Id = @HuntId) AND (tbl_Hunts_Members.MemberId = @MemberId)"

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
