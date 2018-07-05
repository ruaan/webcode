Imports System.Data
Partial Class Association_Detail_App
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Populate()
        btnFarmDescription.OnClientClick = "javascript:window.history.go(-1);return false;"
    End Sub
    Private Sub Populate()
        Dim dsAssoc As New DataSet
        dsAssoc = GetAssociationData()
        Image1.ImageUrl = "../Images/Associations/" & dsAssoc.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim
        lblShort.Text = dsAssoc.Tables(0).Rows(0).Item("ShortDescription").ToString.Trim
        lblHeading.Text = dsAssoc.Tables(0).Rows(0).Item("Name").ToString.Trim
        lblLong.Text = dsAssoc.Tables(0).Rows(0).Item("LongDescription").ToString.Trim
        lblTel.Text = dsAssoc.Tables(0).Rows(0).Item("ContactTel").ToString.Trim
        lblEmail.Text = dsAssoc.Tables(0).Rows(0).Item("ContactEmail").ToString.Trim
        Dim memberNo As String = CheckMembership()

        If memberNo <> "na" Then
            If memberNo <> "" Then
                divMember.Visible = True
                divJoin.Visible = False
                lblMembershipNr.Text = memberNo
                divEvent.Visible = True
                GetNextEvent()
                If lblNextEvent.Text.Trim = "No Current event registered" Then
                    divBook.Visible = False
                Else
                    divBook.Visible = True
                End If
            Else
                divMember.Visible = False
                divJoin.Visible = True
                divEvent.Visible = False
            End If
        Else
            divMember.Visible = False
            divJoin.Visible = True
            divEvent.Visible = False
        End If
    End Sub
    Private Function GetAssociationData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("Association_Id", Request.QueryString("id"))

        Dim str As String = ""

        str &= " SELECT        Association_Id, Name, ContactPerson, ContactTel, ContactEmail, Active, ProfilePicPath, ShortDescription, LongDescription"
        str &= " FROM            tbl_Associations"
        str &= " WHERE        (Association_Id = @Association_Id)"
        str &= " ORDER BY Name"


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
    Private Function CheckMembership() As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("Association_Id", Request.QueryString("id"))
        cmd.Parameters.AddWithValue("MemberId", Request.Cookies("memberid").Value)

        Dim str As String = ""

        str &= " SELECT       id, MemberId, AssociationName, Association_Id, MemberNo"
        str &= " FROM            tbl_Member_Association"
        str &= " where MemberId = @MemberId and Association_Id = @Association_Id"

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

        Dim memberid As String = "na"

        Try
            memberid = ds.Tables(0).Rows(0).Item("MemberNo").ToString.Trim
        Catch ex As Exception

        End Try

        Return memberid
    End Function
    Private Sub GetNextEvent()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("Association_Id", Request.QueryString("id"))
        cmd.Parameters.AddWithValue("Today", Now)

        Dim str As String = ""

        str &= " SELECT    event_id, Association_Id, Event_Name, ShortDescription, LongDescription, EventType, EventDate, EventTime, AcceptBooking, Period, Year, Venue, Venue_Adres1, Venue_Adres2, Venue_Adres3"
        str &= " FROM            tbl_Association_Events"
        str &= " WHERE        (Association_Id = @Association_Id) AND (EventDate >= @Today)"


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
            If ds.Tables(0).Rows.Count > 0 Then
                lblNextEvent.Text = ds.Tables(0).Rows(0).Item("Event_Name").ToString.Trim & " ( " & CDate(ds.Tables(0).Rows(0).Item("EventDate").ToString.Trim).ToString("dd/MM/yyyy") & " )"
            Else
                lblNextEvent.Text = "No Current event registered"
            End If
        Catch ex As Exception
            lblNextEvent.Text = "No Current event registered"
        End Try


    End Sub

    Protected Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        Response.Redirect("Associations/Association_Event_View_App.aspx?id=" & Request.QueryString("id"))
    End Sub

    Protected Sub btnJoin_Click(sender As Object, e As EventArgs) Handles btnJoin.Click
        Response.Redirect("Associations/RegistrationForm_App.aspx?AssId=" & Request.QueryString("id"))
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("Associations/Member_Report_App.aspx?AssId=" & Request.QueryString("id") & "&memId=" & Request.Cookies("memberid").Value)
    End Sub
End Class
