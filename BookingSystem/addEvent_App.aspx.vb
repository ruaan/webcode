Imports System.Data
Partial Class BookingSystem_addEvent_App
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateFarmList()
        Dim farmId As String = ""
        Dim fromdate As String = ""
        Try
            farmId = Request.QueryString("farmId")
            fromdate = Request.QueryString("frmDte")
        Catch ex As Exception

        End Try


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
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblMsg.Text = ""
        startSaving()
    End Sub
    Private Sub startSaving()

        Dim count As Integer
        count = DateDiff(DateInterval.Day, CDate(txtDateFrom.Text), CDate(txtDateTo.Text))
        Dim sp As Integer
        Dim nextGrouId As Integer = GetNextHuntGroupId()
        Dim bookingdate As Date = CDate(txtDateFrom.Text)
        For sp = 0 To count

            SaveEvent(bookingdate, nextGrouId)
            bookingdate = DateAdd(DateInterval.Day, 1, bookingdate)
        Next
        Response.Redirect("CalendarView.aspx")

    End Sub
    Private Sub SaveEvent(BookingDate As Date, nextGrouId As Integer)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Main_Member_Id", "0")
        cmd.Parameters.AddWithValue("@BookingDate", BookingDate)
        cmd.Parameters.AddWithValue("@Date_From", txtDateFrom.Text)
        cmd.Parameters.AddWithValue("@Date_To", txtDateTo.Text)
        cmd.Parameters.AddWithValue("@HunterPax", txthuntersQty.Text)
        cmd.Parameters.AddWithValue("@GuestPax", txtGuestQty.Text)
        cmd.Parameters.AddWithValue("@CountryId", "1")
        cmd.Parameters.AddWithValue("@UniqueName", txtDescription.Text)
        cmd.Parameters.AddWithValue("@Status", "1")

        cmd.Parameters.AddWithValue("@HuntGroupId", nextGrouId)

        Dim str As String = ""
        str &= " INSERT INTO  tbl_Hunts"
        str &= " (FarmId, Main_Member_Id, BookingDate, Date_From, Date_To, HunterPax, GuestPax, DepositDue, FinalPayment, AccommValue, AdditionalValue, CountryId, UniqueName, Status, TotalDue, DepositValue, HuntGroupId) "
        str &= "  VALUES"
        str &= " (@FarmId, @Main_Member_Id, @BookingDate, @Date_From, @Date_To, @HunterPax, @GuestPax, @Date_From, '0', '0', '0', @CountryId, @UniqueName, @Status, '0', '0', @HuntGroupId)"

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
            lblMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

    End Sub
    Private Function GetNextHuntGroupId() As String
        Dim TrackNr As String = ""
        Try
            Dim myconnection As New SqlClient.SqlConnection
            myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
            Dim cmd As New SqlClient.SqlCommand

            cmd.Parameters.AddWithValue("@FarmId", cmbFarms.SelectedValue.Trim)
            Dim str As String = ""
            str &= " SELECT NextHuntGroupId from  tbl_Farm_Control"
            str &= " WHERE (FarmId  = @FarmId)"

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

            TrackNr = ds.Tables(0).Rows(0).Item("NextHuntGroupId").ToString.Trim

            'Increase the number by one
            Dim nextnr As Integer = TrackNr + 1
            cmd.Parameters.AddWithValue("@NR", nextnr)
            Dim str1 As String = "UPDATE  tbl_Farm_Control SET NextHuntGroupId  =" & "'" & nextnr & "'" & " WHERE FarmId  = " & "'" & cmbFarms.SelectedValue.Trim & "'"
            cmd.CommandText = str1
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            myconnection.Open()
            cmd.ExecuteNonQuery()
            myconnection.Close()
        Catch ex As Exception

        End Try
        Return TrackNr
    End Function
End Class
