Imports System.Data
Partial Class Associations_Association_Event_Control_Attendance
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblMsg.Text = ""
        Populate(Request.QueryString("id"), "Attending")
        Populate(Request.QueryString("id"), "Maybe")
        PopulateDetails(Request.QueryString("id"))
    End Sub
    Private Sub Populate(EventId As String, Type As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@EventId", EventId)
        cmd.Parameters.AddWithValue("@Type", Type)

        Dim str As String = ""

        str &= " SELECT        tbl_Association_Event_Attending.id, tbl_Association_Event_Attending.Event_Id, tbl_Association_Event_Attending.MemberId, tbl_Association_Event_Attending.Attend, tbl_Member.Title, tbl_Member.Initials, "
        str &= "                          tbl_Member.PreferredName, tbl_Member.Surname, tbl_Member.CellNo, tbl_Member.Email, tbl_Member_Association.MemberNo"
        str &= " FROM            tbl_Association_Event_Attending INNER JOIN"
        str &= "                          tbl_Member ON tbl_Association_Event_Attending.MemberId = tbl_Member.MemberId INNER JOIN"
        str &= "                          tbl_Member_Association ON tbl_Member.MemberId = tbl_Member_Association.MemberId"
        str &= " WHERE        (tbl_Association_Event_Attending.Event_Id = @EventId) AND (tbl_Association_Event_Attending.Attend = @Type)"

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
            lblMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try


        If Type = "Attending" Then
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Else
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        End If

    End Sub
    Private Sub PopulateDetails(EventId As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@event_id", EventId)

        Dim str As String = ""

        str &= " SELECT         event_id, Association_Id, Event_Name, ShortDescription, LongDescription, EventType, EventDate, EventTime, AcceptBooking, Period, Year, Venue, Venue_Adres1, Venue_Adres2, Venue_Adres3"
        str &= " FROM            tbl_Association_Events"
        str &= " where event_id = @event_id"

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
            lblEventName.Text = ds.Tables(0).Rows(0).Item("Event_Name").ToString
            lblDate.Text = CDate(ds.Tables(0).Rows(0).Item("EventDate").ToString).ToString("dd/MM/yyyy")
            lblTime.Text = CDate(ds.Tables(0).Rows(0).Item("EventTime").ToString).ToString("HH:mm")
            lblVenue.Text = ds.Tables(0).Rows(0).Item("Venue").ToString
        Catch ex As Exception

        End Try
    End Sub
End Class
