Imports System.Data
Partial Class BookingSystem_Farm_Booking_Manager_App
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            PopulateFarmList()
            Label1.Text = Request.QueryString("UserId")
        End If
    End Sub
    Private Sub PopulateFarmList()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@UserId", Request.QueryString("UserId"))
        Dim str As String = ""
        str &= " SELECT        tbl_Farm.FarmName, tbl_Farm.id "
        str &= " FROM            tbl_Farms_v_User INNER JOIN "
        str &= "                          tbl_Farm ON tbl_Farms_v_User.FarmId = tbl_Farm.id "
        str &= " WHERE        (tbl_Farms_v_User.UserId = @UserId) "
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
    Private Function GetBookings() As String
        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"

        htmlString &= "                         <div>&nbsp;</div>"
        Dim dsTerms As New DataSet
        dsTerms = GetBookingsData()
        Dim count As Integer = dsTerms.Tables(0).Rows.Count - 1
        Dim sp As Integer

        Dim itemName As String = ""
        Dim month As String = "13"
        For sp = 0 To count
            If month <> CDate(dsTerms.Tables(0).Rows(sp).Item("Date_From").ToString.Trim).Month Then
                htmlString &= " <div style='background-color: #E2E2E2; font-size: large; font-weight: bold; padding-left: 10px; padding-top: 10px; padding-bottom: 10px;'>"
                htmlString &= GetMonthName(CDate(dsTerms.Tables(0).Rows(sp).Item("Date_From").ToString.Trim).Month) & " " & CDate(dsTerms.Tables(0).Rows(sp).Item("Date_From").ToString.Trim).Year
                htmlString &= "        </div>"
                month = CDate(dsTerms.Tables(0).Rows(sp).Item("Date_From").ToString.Trim).Month
            End If

            htmlString &= " <div>&nbsp;</div>"
            htmlString &= "  <div style='background-color: #F8F8F8; border: 1px solid #333333; padding-left:10px '  class='auto-style4' >"
            htmlString &= "           <div>&nbsp;</div>"
            htmlString &= "           <div style='font-weight: bold'>DATES: " & CDate(dsTerms.Tables(0).Rows(sp).Item("Date_From").ToString.Trim).ToString("dd/MM/yyyy") & " - " & CDate(dsTerms.Tables(0).Rows(sp).Item("Date_To").ToString.Trim).ToString("dd/MM/yyyy") & "</div>"
            htmlString &= "           <div>No Days: " & DateDiff(DateInterval.Day, CDate(dsTerms.Tables(0).Rows(sp).Item("Date_From").ToString.Trim), CDate(dsTerms.Tables(0).Rows(sp).Item("Date_To").ToString.Trim)) & "</div>"
            htmlString &= "           <div>&nbsp;</div>"
            htmlString &= "           <div>Status: " & dsTerms.Tables(0).Rows(sp).Item("Description").ToString.Trim & "</div>"
            htmlString &= "            <div>&nbsp;</div>"
            htmlString &= "           <div>No Hunters: " & dsTerms.Tables(0).Rows(sp).Item("HunterPax").ToString.Trim & "</div>"
            htmlString &= "           <div>No Guests: " & dsTerms.Tables(0).Rows(sp).Item("GuestPax").ToString.Trim & "</div>"
            htmlString &= "            <div>&nbsp;</div>"
            htmlString &= "           <div>Contact Details:</div>"
            htmlString &= "           <div>Name: " & dsTerms.Tables(0).Rows(sp).Item("HunterName").ToString.Trim & "</div>"
            htmlString &= "           <div>Mobile: " & dsTerms.Tables(0).Rows(sp).Item("CellNo").ToString.Trim & "</div>"
            htmlString &= "           <div>Email: " & dsTerms.Tables(0).Rows(sp).Item("Email").ToString.Trim & "</div>"
            htmlString &= "           <div>&nbsp;</div>"
            htmlString &= "      </div>"
            htmlString &= " <div>&nbsp;</div>"
        Next
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"

        If count < 0 Then
            htmlString = "                 <div>"
            htmlString &= " No events booked."
            htmlString &= "                 </div>"
        End If
        Return htmlString
    End Function
    Private Function GetMonthName(period As String) As String
        Dim MonthName As String = ""
        Select Case period
            Case = 1
                MonthName = "January"
            Case = 2
                MonthName = "February"
            Case = 3
                MonthName = "March"
            Case = 4
                MonthName = "April"
            Case = 5
                MonthName = "May"
            Case = 6
                MonthName = "June"
            Case = 7
                MonthName = "July"
            Case = 8
                MonthName = "August"
            Case = 9
                MonthName = "September"
            Case = 10
                MonthName = "October"
            Case = 11
                MonthName = "November"
            Case = 12
                MonthName = "December"
        End Select

        Return MonthName

    End Function
    Private Function GetBookingsData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@todayDate", Now.Date)

        Dim str As String = ""

        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.FarmId, tbl_Hunts.Main_Member_Id, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts.HunterPax, tbl_Hunts.GuestPax, tbl_Hunts.TotalDue, tbl_Hunts.DepositValue, "
        str &= "                          tbl_Hunts.DepositDue, tbl_Hunts.FinalPayment, tbl_Hunts.AccommValue, tbl_Hunts.AdditionalValue, tbl_Hunts.SpeciesValue, tbl_Hunts.ExtraValue, tbl_Hunts.CountryId, tbl_Hunts.UniqueName, tbl_Hunts.FlightId, "
        str &= "                          tbl_Hunts.CarId, tbl_Hunts.Status, tbl_Hunts.PercDepositPaid, tbl_Hunts_Status.Description, tbl_Member.PreferredName + ' ' + tbl_Member.Surname AS HunterName, tbl_Member.CellNo, tbl_Member.Email"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId INNER JOIN"
        str &= "                          tbl_Member ON tbl_Hunts.Main_Member_Id = tbl_Member.MemberId"
        str &= " WHERE        (tbl_Hunts.FarmId = @FarmId) AND (tbl_Hunts.Date_To >= @todayDate)"
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

        Return ds
    End Function
    Protected Sub cmbFarms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarms.SelectedIndexChanged
        PlaceHolder1.Controls.Add(New LiteralControl(GetBookings))
    End Sub
    Protected Sub cmbFarms_DataBound(sender As Object, e As EventArgs) Handles cmbFarms.DataBound
        cmbFarms.Items.Add("Select")
        cmbFarms.SelectedValue = "Select"
    End Sub
End Class
