Imports System.Data
Imports System.Data.OleDb
Partial Class BookingSystem_CalendarView_App
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not IsPostBack Then
            PopulateFarmList()

            'cal1.VisibleDate = Now.Date
            'Dim startDate As DateTime = New DateTime(cal1.VisibleDate.Year, cal1.VisibleDate.Month, 1).AddDays(-7)
            'Dim endDate As DateTime = New DateTime(cal1.VisibleDate.Date.AddMonths(1).Year, cal1.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(7)
            'cal1.DataSource = GetBookingsData(startDate, endDate)
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
            ' lblSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            cmbFarms.DataSource = ds.Tables(0)
            cmbFarms.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Sub MonthChange(o As Object, e As MonthChangedEventArgs)
        '-- triggered when the month in the calendar changes;
        '-- requery the database for the new month's events
        Dim startDate As DateTime = e.NewDate.AddDays(-7)
        Dim endDate As DateTime = e.NewDate.AddMonths(1).AddDays(7)
        cal1.DataSource = GetBookingsData(startDate, endDate)
    End Sub

    Function GetEventData(startDate As DateTime, endDate As DateTime) As DataTable
        '-- We'll avoid using a session variable this time and
        '-- query the database each time the page is called;
        '-- However, we'll make sure we're only loading events for the
        '-- currently displayed month (plus the week before and week after)

        '-- read data from an Access query
        Dim con As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Inetpub\wwwroot\DataCalendar\calendar.mdb")
        Dim cmd As OleDbCommand = New OleDbCommand()
        cmd.Connection = con
        cmd.CommandText = String.Format("Select * From EventInfo Where EventDate >= #{0}# And EventDate <= #{1}#",
                                        startDate, endDate)
        Dim ds As DataSet = New DataSet()
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd)
        da.Fill(ds)
        con.Close()

        Return ds.Tables(0)
    End Function
    Private Function GetBookingsData(startDate As DateTime, endDate As DateTime) As DataTable
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)

        Dim str As String = ""

        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.FarmId, tbl_Hunts.Main_Member_Id, tbl_Hunts.BookingDate, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts.HunterPax, tbl_Hunts.GuestPax, tbl_Hunts.TotalDue, tbl_Hunts.DepositValue, "
        str &= "                          tbl_Hunts.DepositDue, tbl_Hunts.FinalPayment, tbl_Hunts.AccommValue, tbl_Hunts.AdditionalValue, tbl_Hunts.SpeciesValue, tbl_Hunts.ExtraValue, tbl_Hunts.CountryId, tbl_Hunts.UniqueName, tbl_Hunts.FlightId, "
        str &= "                          tbl_Hunts.CarId, tbl_Hunts.Status, tbl_Hunts.PercDepositPaid, tbl_Hunts_Status.Description, "
        str &= "                          CASE WHEN tbl_Hunts.Main_Member_Id = 0 THEN tbl_Hunts.UniqueName ELSE tbl_Member.PreferredName + ' ' + tbl_Member.Surname END AS HunterName, tbl_Member.CellNo, tbl_Member.Email"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId LEFT OUTER JOIN"
        str &= "                          tbl_Member ON tbl_Hunts.Main_Member_Id = tbl_Member.MemberId"
        str &= " WHERE        (tbl_Hunts.FarmId = @FarmId) AND (tbl_Hunts.Date_To <= @endDate) AND (tbl_Hunts.Date_From >= @startDate)"
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
    Protected Sub cmbFarms_DataBound(sender As Object, e As EventArgs) Handles cmbFarms.DataBound
        cmbFarms.Items.Add("Select")
        cmbFarms.SelectedValue = "Select"
    End Sub
    Protected Sub cmbFarms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFarms.SelectedIndexChanged
        If cmbFarms.SelectedValue = "Select" Then
            cal1.Visible = False
        Else
            cal1.Visible = True
            cal1.VisibleDate = Now.Date
            Dim startDate As DateTime = New DateTime(cal1.VisibleDate.Year, cal1.VisibleDate.Month, 1).AddDays(-7)
            Dim endDate As DateTime = New DateTime(cal1.VisibleDate.Date.AddMonths(1).Year, cal1.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(7)
            cal1.DataSource = GetBookingsData(startDate, endDate)
        End If

    End Sub
    Private Sub LoadEventDetail()

        Dim dt As DataTable = GetBookingsData()
        If dt.Rows.Count > 0 Then
            Dim r As DataRow = dt.Rows(0)
            txtTitle.Text = r("HunterName").ToString()
            'txtDescription.Text = r("EventDescription").ToString()
            txtDate.Text = (CType(r("BookingDate"), DateTime)).ToString("MM/dd/yyyy")
            txtEventDate.Text = (CType(r("Date_From"), DateTime)).ToString("MM/dd/yyyy") & " - " & (CType(r("Date_To"), DateTime)).ToString("MM/dd/yyyy")
            txtStatus.Text = r("Description").ToString()
            txtCategory.Text = "Hunters"
            ' txtCategory.ForeColor = System.Drawing.Color.FromName(r("CategoryColor").ToString())
            imgCategory.ImageUrl = "../Images/Icons/Farm_Search/HuntType/shotgun-hunting.png"
        End If
    End Sub

    Private Function GetBookingsData() As DataTable
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@HuntId", HiddenFieldHuntId.Value.Trim) 'Request("id"))


        Dim str As String = ""

        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.FarmId, tbl_Hunts.Main_Member_Id, tbl_Hunts.BookingDate, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts.HunterPax, tbl_Hunts.GuestPax, tbl_Hunts.TotalDue, tbl_Hunts.DepositValue, "
        str &= "                          tbl_Hunts.DepositDue, tbl_Hunts.FinalPayment, tbl_Hunts.AccommValue, tbl_Hunts.AdditionalValue, tbl_Hunts.SpeciesValue, tbl_Hunts.ExtraValue, tbl_Hunts.CountryId, tbl_Hunts.UniqueName, tbl_Hunts.FlightId, "
        str &= "                          tbl_Hunts.CarId, tbl_Hunts.Status, tbl_Hunts.PercDepositPaid, tbl_Hunts_Status.Description, "
        str &= "                          CASE WHEN tbl_Hunts.Main_Member_Id = 0 THEN tbl_Hunts.UniqueName ELSE tbl_Member.PreferredName + ' ' + tbl_Member.Surname END AS HunterName, tbl_Member.CellNo, tbl_Member.Email"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId LEFT OUTER JOIN"
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
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pnlEventDetail_ModalPopupExtender.Show()
        cal1.VisibleDate = Now.Date
        Dim startDate As DateTime = New DateTime(cal1.VisibleDate.Year, cal1.VisibleDate.Month, 1).AddDays(-7)
        Dim endDate As DateTime = New DateTime(cal1.VisibleDate.Date.AddMonths(1).Year, cal1.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(7)
        cal1.DataSource = GetBookingsData(startDate, endDate)
        LoadEventDetail()
    End Sub
End Class
