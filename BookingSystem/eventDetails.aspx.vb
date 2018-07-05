Imports System.Data
Partial Class BookingSystem_eventDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As DataTable = GetBookingsData()
        If dt.Rows.Count > 0 Then
            Dim r As DataRow = dt.Rows(0)
            txtTitle.Text = r("HunterName").ToString()
            txtDate.Text = (CType(r("Date_From"), DateTime)).ToString("MM/dd/yyyy")
            txtCategory.Text = "Hunters"
            imgCategory.ImageUrl = "../Images/Icons/Farm_Search/HuntType/shotgun-hunting.png"
        End If
    End Sub
    Private Function GetBookingsData() As DataTable
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", Request("id"))

        Dim str As String = ""

        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.FarmId, tbl_Hunts.Main_Member_Id, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts.HunterPax, tbl_Hunts.GuestPax, tbl_Hunts.TotalDue, tbl_Hunts.DepositValue, "
        str &= "                          tbl_Hunts.DepositDue, tbl_Hunts.FinalPayment, tbl_Hunts.AccommValue, tbl_Hunts.AdditionalValue, tbl_Hunts.SpeciesValue, tbl_Hunts.ExtraValue, tbl_Hunts.CountryId, tbl_Hunts.UniqueName, tbl_Hunts.FlightId, "
        str &= "                          tbl_Hunts.CarId, tbl_Hunts.Status, tbl_Hunts.PercDepositPaid, tbl_Hunts_Status.Description, tbl_Member.PreferredName + ' ' + tbl_Member.Surname AS HunterName, tbl_Member.CellNo, tbl_Member.Email"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId INNER JOIN"
        str &= "                          tbl_Member ON tbl_Hunts.Main_Member_Id = tbl_Member.MemberId"
        str &= " WHERE  (tbl_Hunts.HuntId = @HuntId) "
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

        Return ds.Tables(0)
    End Function
End Class
