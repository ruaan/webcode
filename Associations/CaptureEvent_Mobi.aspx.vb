Imports System.Data
Imports System.IO
Partial Class Associations_CaptureEvent1_Mobi
    Inherits System.Web.UI.Page

#Region "Variants"
    Dim userId As String
    Dim eventId As String
#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        userId = Response.Cookies("UserId").Value
        Page.Form.Attributes.Add("enctype", "multipart/form-data")
        If IsPostBack = False Then
            PopulateAssociations()
        End If
    End Sub
    Protected Sub ddlAssociations_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAssociations.DataBound
        ddlAssociations.Items.Insert(0, New ListItem("-Select-"))
    End Sub
    Protected Sub ddlAssociations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssociations.SelectedIndexChanged
        If ddlAssociations.SelectedValue.Trim <> "-Select-" Then
            pnlEvents.Visible = True
            PopulateEvents(ddlAssociations.SelectedValue.Trim)
        End If
    End Sub
    Protected Sub ddlEvents_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEvents.DataBound
        ddlEvents.Items.Insert(0, New ListItem("-Select-"))
        ddlEvents.Items.Insert(1, New ListItem("-Non Event-"))
    End Sub
    Protected Sub ddlEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEvents.SelectedIndexChanged
        If ddlEvents.SelectedValue.Trim <> "-Select-" Then
            pnlMember.Visible = True
            PopulateMember()
            pnlMain.Visible = True
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateAssociations()
        Dim ds As New DataSet()
        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        Dim str As String = ""
        str &= " SELECT Association_Id, Name FROM tbl_Associations "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlAssociations.DataSource = ds.Tables(0)
            ddlAssociations.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub PopulateEvents(ByVal AssId As String)
        Dim ds As New DataSet()
        Dim sqlconnection2 As New SqlClient.SqlConnection
        sqlconnection2.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", AssId.Trim)

        Dim str As String = ""
        str &= " SELECT event_id, Event_Name FROM tbl_Association_Events WHERE Association_Id = @Association_Id "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection2

        Try
            sqlconnection2.Open()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim tbl As New DataTable
            da.SelectCommand = cmd
            da.Fill(ds)

            ddlEvents.DataSource = ds.Tables(0)
            ddlEvents.DataBind()
        Catch ex As Exception

        Finally
            sqlconnection2.Close()
        End Try
    End Sub
    Private Sub PopulateMember()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT MemberId, FullName + ' ' + Surname AS Name, IDNo FROM tbl_Member WHERE (MemberId = '" & Request.Cookies("memberid").Value & "') "

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

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                lblName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
                txtDate.Text = Now.Date.ToString("yyyy/MM/dd")
                lblMemberNo.Text = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim
                lblIdNo.Text = ds.Tables(0).Rows(0).Item("IDNo").ToString.Trim
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveHeader()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", ddlAssociations.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Event_Id", ddlEvents.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@MemberId", lblMemberNo.Text.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events SET Association_Id = @Association_Id WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events (Association_Id, Event_Id, MemberId) VALUES (@Association_Id, @Event_Id, @MemberId) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
        HiddenField1.Value = GetEventId()
        eventId = GetEventId()
    End Sub
#End Region

#Region "Functions"
    Private Function GetEventId() As String

        Dim sqlconnection1 As New SqlClient.SqlConnection
        sqlconnection1.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim ds5 As New DataSet

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", ddlAssociations.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Event_Id", ddlEvents.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@MemberId", lblMemberNo.Text.Trim)

        Dim Name As String
        Dim str As String = ""
        str &= " SELECT id FROM tbl_Member_Events WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId "

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlconnection1
        Try
            sqlconnection1.Open()
            Dim da3 As New SqlClient.SqlDataAdapter()
            Dim tbl3 As New DataTable
            da3.SelectCommand = cmd
            da3.Fill(ds5)
            If ds5.Tables(0).Rows.Count > 0 Then
                Name = ds5.Tables(0).Rows(0).Item("id").ToString.Trim
            Else
                Name = ""
            End If
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
            Name = ""
        Finally
            sqlconnection1.Close()
        End Try
        Return Name
    End Function
#End Region

#Region "Positive Scoring"
    Protected Sub btnPostiveScoring_Click(sender As Object, e As EventArgs) Handles btnPostiveScoring.Click
        If pnl1.Visible = True Then
            pnl1.Visible = False
        Else
            pnl1.Visible = True
            PopulateGridPositive()
        End If
    End Sub
    Protected Sub btnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click
        lblMsg.Text = ""
        SaveHeader()
        For Each myRow As GridViewRow In GridView1.Rows
            Dim myId As String = myRow.Cells(0).Text
            Dim Name As String = myRow.Cells(1).Text
            Dim Meters As TextBox = DirectCast(myRow.Cells(2).Controls(1), TextBox)
            Dim my30x As TextBox = DirectCast(myRow.Cells(3).Controls(1), TextBox)
            Dim my20x As TextBox = DirectCast(myRow.Cells(4).Controls(1), TextBox)
            Dim my15x As TextBox = DirectCast(myRow.Cells(5).Controls(1), TextBox)
            Dim my10x As TextBox = DirectCast(myRow.Cells(6).Controls(1), TextBox)
            Dim my5x As TextBox = DirectCast(myRow.Cells(7).Controls(1), TextBox)
            If Meters.Text.Trim <> "" Or my30x.Text.Trim <> "" Or my20x.Text.Trim <> "" Or my15x.Text.Trim <> "" Or my10x.Text.Trim <> "" Or my5x.Text.Trim <> "" Then
                SavePositiveScoring(myId.Trim, Meters.Text.Trim, my30x.Text.Trim, my20x.Text.Trim, my15x.Text.Trim, my10x.Text.Trim, my5x.Text.Trim)
            End If
        Next
        pnl1.Visible = False
        pnl2.Visible = True
        PopulateGridVBulls()
    End Sub
    Private Sub PopulateGridPositive()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT id, Name FROM tbl_TargetType "


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
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SavePositiveScoring(targetId As String, Meters As String, my30 As String, my20 As String, my15 As String, my10 As String, my5 As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)
        cmd.Parameters.AddWithValue("@targetId", targetId.Trim)
        cmd.Parameters.AddWithValue("@Meters", Meters.Trim)
        cmd.Parameters.AddWithValue("@my30", my30.Trim)
        cmd.Parameters.AddWithValue("@my20", my20.Trim)
        cmd.Parameters.AddWithValue("@my15", my15.Trim)
        cmd.Parameters.AddWithValue("@my10", my10.Trim)
        cmd.Parameters.AddWithValue("@my5", my5.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_PositiveScoring WHERE EventId = @EventId AND targetId = @targetId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_PositiveScoring SET Meters = @Meters, my30 = @my30, my20 = @my20, my15 = @my15, my10 = @my10, my5 = @my5 WHERE EventId = @EventId AND targetId = @targetId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_PositiveScoring (EventId, targetId, Meters, my30, my20, my15, my10, my5) VALUES (@EventId, @targetId, @Meters, @my30, @my20, @my15, @my10, @my5) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "V Bulls"
    Protected Sub btnVBulls_Click(sender As Object, e As EventArgs) Handles btnVBulls.Click
        If pnl2.Visible = True Then
            pnl2.Visible = False
        Else
            pnl2.Visible = True
            PopulateGridVBulls()
        End If
    End Sub
    Protected Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        SaveHeader()
        For Each myRow As GridViewRow In GridView2.Rows
            Dim myId As String = myRow.Cells(0).Text
            Dim Name As String = myRow.Cells(1).Text
            Dim my01x As TextBox = DirectCast(myRow.Cells(2).Controls(1), TextBox)
            If my01x.Text.Trim <> "" Then
                SaveVBulls(myId.Trim, my01x.Text.Trim)
            End If
        Next
        pnl2.Visible = False
        pnl3.Visible = True
        PopulateGridNegative()
    End Sub
    Private Sub PopulateGridVBulls()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT id, Name FROM tbl_TargetType "


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
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveVBulls(targetId As String, my01 As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)
        cmd.Parameters.AddWithValue("@targetId", targetId.Trim)
        cmd.Parameters.AddWithValue("@my01", my01.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_VBulls WHERE EventId = @EventId AND targetId = @targetId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_VBulls SET my01 = @my01 WHERE EventId = @EventId AND targetId = @targetId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_VBulls (EventId, targetId, my01) VALUES (@EventId, @targetId, @my01) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Negative Scoring"
    Protected Sub btnNegativeScoring_Click(sender As Object, e As EventArgs) Handles btnNegativeScoring.Click
        If pnl3.Visible = True Then
            pnl3.Visible = False
        Else
            pnl3.Visible = True
            PopulateGridNegative()
        End If
    End Sub
    Protected Sub btnSave3_Click(sender As Object, e As EventArgs) Handles btnSave3.Click
        lblMsg.Text = ""
        SaveHeader()
        For Each myRow As GridViewRow In GridView3.Rows
            Dim myId As String = myRow.Cells(0).Text
            Dim Name As String = myRow.Cells(1).Text
            Dim Meters As TextBox = DirectCast(myRow.Cells(2).Controls(1), TextBox)
            Dim my30x As TextBox = DirectCast(myRow.Cells(3).Controls(1), TextBox)
            Dim my20x As TextBox = DirectCast(myRow.Cells(4).Controls(1), TextBox)
            Dim my15x As TextBox = DirectCast(myRow.Cells(5).Controls(1), TextBox)
            Dim my10x As TextBox = DirectCast(myRow.Cells(6).Controls(1), TextBox)
            Dim my5x As TextBox = DirectCast(myRow.Cells(7).Controls(1), TextBox)
            If Meters.Text.Trim <> "" Or my30x.Text.Trim <> "" Or my20x.Text.Trim <> "" Or my15x.Text.Trim <> "" Or my10x.Text.Trim <> "" Or my5x.Text.Trim <> "" Then
                SaveNegativeScoring(myId.Trim, Meters.Text.Trim, my30x.Text.Trim, my20x.Text.Trim, my15x.Text.Trim, my10x.Text.Trim, my5x.Text.Trim)
            End If
        Next
        pnl3.Visible = False
        pnl4.Visible = True
        PopulateGridScoringTotals()
    End Sub
    Private Sub PopulateGridNegative()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT id, Name FROM tbl_TargetType "


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
            GridView3.DataSource = ds.Tables(0)
            GridView3.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveNegativeScoring(targetId As String, Meters As String, my30 As String, my20 As String, my15 As String, my10 As String, my5 As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)
        cmd.Parameters.AddWithValue("@targetId", targetId.Trim)
        cmd.Parameters.AddWithValue("@Meters", Meters.Trim)
        cmd.Parameters.AddWithValue("@my30", my30.Trim)
        cmd.Parameters.AddWithValue("@my20", my20.Trim)
        cmd.Parameters.AddWithValue("@my15", my15.Trim)
        cmd.Parameters.AddWithValue("@my10", my10.Trim)
        cmd.Parameters.AddWithValue("@my5", my5.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_NegativeScoring WHERE EventId = @EventId AND targetId = @targetId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_NegativeScoring SET Meters = @Meters, my30 = @my30, my20 = @my20, my15 = @my15, my10 = @my10, my5 = @my5 WHERE EventId = @EventId AND targetId = @targetId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_NegativeScoring (EventId, targetId, Meters, my30, my20, my15, my10, my5) VALUES (@EventId, @targetId, @Meters, @my30, @my20, @my15, @my10, @my5) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Scoring Totals"
    Protected Sub btnScoringTotals_Click(sender As Object, e As EventArgs) Handles btnScoringTotals.Click
        If pnl4.Visible = True Then
            pnl4.Visible = False
        Else
            pnl4.Visible = True
            PopulateGridScoringTotals()
        End If
    End Sub
    Protected Sub btnSave4_Click(sender As Object, e As EventArgs) Handles btnSave4.Click
        lblMsg.Text = ""
        SaveHeader()
        For Each myRow As GridViewRow In GridView4.Rows
            Dim myId As String = myRow.Cells(0).Text
            Dim Name As String = myRow.Cells(1).Text
            Dim Total As TextBox = DirectCast(myRow.Cells(2).Controls(1), TextBox)
            Dim SF As TextBox = DirectCast(myRow.Cells(3).Controls(1), TextBox)
            Dim MS As TextBox = DirectCast(myRow.Cells(4).Controls(1), TextBox)
            Dim Success As TextBox = DirectCast(myRow.Cells(5).Controls(1), TextBox)
            If Total.Text.Trim <> "" Or SF.Text.Trim <> "" Or MS.Text.Trim <> "" Or Success.Text.Trim <> "" Then
                SaveScoringTotals(myId.Trim, Total.Text.Trim, SF.Text.Trim, MS.Text.Trim, Success.Text.Trim)
            End If
        Next
        pnl4.Visible = False
        pnl5.Visible = True
    End Sub
    Private Sub PopulateGridScoringTotals()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        Dim str As String = ""
        str &= " SELECT id, Name FROM tbl_TargetType "


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
            GridView4.DataSource = ds.Tables(0)
            GridView4.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveScoringTotals(targetId As String, Total As String, SF As String, MS As String, Success As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)
        cmd.Parameters.AddWithValue("@targetId", targetId.Trim)
        cmd.Parameters.AddWithValue("@Total", Total.Trim)
        cmd.Parameters.AddWithValue("@SF", SF.Trim)
        cmd.Parameters.AddWithValue("@MS", MS.Trim)
        cmd.Parameters.AddWithValue("@Success", Success.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_ScoringTotals WHERE EventId = @EventId AND targetId = @targetId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_ScoringTotals SET Total = @Total, SF = @SF, MS = @MS, Success = @Success WHERE EventId = @EventId AND targetId = @targetId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_ScoringTotals (EventId, targetId, Total, SF, MS, Success) VALUES (@EventId, @targetId, @Total, @SF, @MS, @Success) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Range Name and Conditions"
    Protected Sub btnRange_Click(sender As Object, e As EventArgs) Handles btnRange.Click
        If pnl5.Visible = True Then
            pnl5.Visible = False
        Else
            pnl5.Visible = True
        End If
    End Sub
    Protected Sub btnSave5_Click(sender As Object, e As EventArgs) Handles btnSave5.Click
        lblMsg.Text = ""
        SaveHeader()
        SaveRange(txtTemperature.Text.Trim, txtWindSpeed.Text.Trim, txtWindDirection.Text.Trim, txtPressure.Text.Trim, txtHumidity.Text.Trim, txtAltitude.Text.Trim, txtTargetDirection.Text.Trim, txtCalibreGun.Text.Trim, txtBulletGrain.Text.Trim)
        pnl5.Visible = False
        pnl6.Visible = True
    End Sub
    Private Sub SaveRange(Temparature As String, WindSpeed As String, WindDirection As String, Pressure As String, Humidity As String, Altitude As String, TargetDirection As String, CalibreGun As String, BulletGrain As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)
        cmd.Parameters.AddWithValue("@Temparature", Temparature.Trim)
        cmd.Parameters.AddWithValue("@WindSpeed", WindSpeed.Trim)
        cmd.Parameters.AddWithValue("@WindDirection", WindDirection.Trim)
        cmd.Parameters.AddWithValue("@Pressure", Pressure.Trim)
        cmd.Parameters.AddWithValue("@Humidity", Humidity.Trim)
        cmd.Parameters.AddWithValue("@Altitude", Altitude.Trim)
        cmd.Parameters.AddWithValue("@TargetDirection", TargetDirection.Trim)
        cmd.Parameters.AddWithValue("@CalibreGun", CalibreGun.Trim)
        cmd.Parameters.AddWithValue("@BulletGrain", BulletGrain.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_Range WHERE EventId = @EventId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_Range SET Temparature = @Temparature, WindSpeed = @WindSpeed, WindDirection = @WindDirection, "
        str3 &= " Pressure = @Pressure, Humidity = @Humidity, Altitude = @Altitude, TargetDirection = @TargetDirection, "
        str3 &= " CalibreGun = @CalibreGun, BulletGrain = @BulletGrain WHERE EventId = @EventId "
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_Range (EventId, Temparature, WindSpeed, WindDirection, Pressure, Humidity, Altitude, TargetDirection, CalibreGun, BulletGrain) "
        str3 &= " VALUES (@EventId, @Temparature, @WindSpeed, @WindDirection, @Pressure, @Humidity, @Altitude, @TargetDirection, @CalibreGun, @BulletGrain) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Gong"
    Protected Sub btnGong_Click(sender As Object, e As EventArgs) Handles btnGong.Click
        If pnl6.Visible = True Then
            pnl6.Visible = False
        Else
            pnl6.Visible = True
        End If
    End Sub
    Protected Sub btnSave6_Click(sender As Object, e As EventArgs) Handles btnSave6.Click
        lblMsg.Text = ""
        SaveHeader()
        SaveGong(txtGong1.Text.Trim, txtGong2.Text.Trim, txtGong3.Text.Trim, txtGong4.Text.Trim, txtGong5.Text.Trim, txtGongTotal.Text.Trim, txtGongSF.Text.Trim, txtGongMS.Text.Trim, txtGongSuccess.Text.Trim)
        pnl6.Visible = False
        pnl7.Visible = True
    End Sub
    Private Sub SaveGong(Gong1 As String, Gong2 As String, Gong3 As String, Gong4 As String, Gong5 As String, GongTotal As String, GongSF As String, GongMS As String, GongSuccess As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)
        cmd.Parameters.AddWithValue("@Gong1", Gong1.Trim)
        cmd.Parameters.AddWithValue("@Gong2", Gong2.Trim)
        cmd.Parameters.AddWithValue("@Gong3", Gong3.Trim)
        cmd.Parameters.AddWithValue("@Gong4", Gong4.Trim)
        cmd.Parameters.AddWithValue("@Gong5", Gong5.Trim)
        cmd.Parameters.AddWithValue("@GongTotal", GongTotal.Trim)
        cmd.Parameters.AddWithValue("@GongSF", GongSF.Trim)
        cmd.Parameters.AddWithValue("@GongMS", GongMS.Trim)
        cmd.Parameters.AddWithValue("@GongSuccess", GongSuccess.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_Gong WHERE EventId = @EventId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_Gong SET Gong1 = @Gong1, Gong2 = @Gong2, Gong3 = @Gong3, "
        str3 &= " Gong4 = @Gong4, Gong5 = @Gong5, GongTotal = @GongTotal, GongSF = @GongSF, "
        str3 &= " GongMS = @GongMS, GongSuccess = @GongSuccess WHERE EventId = @EventId "
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_Gong (EventId, Gong1, Gong2, Gong3, Gong4, Gong5, GongTotal, GongSF, GongMS, GongSuccess) "
        str3 &= " VALUES (@EventId, @Gong1, @Gong2, @Gong3, @Gong4, @Gong5, @GongTotal, @GongSF, @GongMS, @GongSuccess) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Gong Totals"
    Protected Sub btnGongTotals_Click(sender As Object, e As EventArgs) Handles btnGongTotals.Click
        If pnl7.Visible = True Then
            pnl7.Visible = False
        Else
            pnl7.Visible = True
        End If
    End Sub
    Protected Sub btnSave7_Click(sender As Object, e As EventArgs) Handles btnSave7.Click
        lblMsg.Text = ""
        SaveHeader()
        SaveGongTotals()
        pnl7.Visible = False
    End Sub
    Private Sub SaveGongTotals()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@EventId", eventId.Trim)

        cmd.Parameters.AddWithValue("@AnimalTargetTotal", txtAnimalTargetTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@AnimalTargetSF", txtAnimalTargetSF.Text.Trim)
        cmd.Parameters.AddWithValue("@AnimalTargetMS", txtAnimalTargetMS.Text.Trim)
        cmd.Parameters.AddWithValue("@AnimalTargetSuccess", txtAnimalTargetSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@GongScoringTotal", txtGongScoringTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@GongScoringSF", txtGongScoringSF.Text.Trim)
        cmd.Parameters.AddWithValue("@GongScoringMS", txtGongScoringMS.Text.Trim)
        cmd.Parameters.AddWithValue("@GongScoringSuccess", txtGongScoringSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@EventTotalTotal", txtEventTotalTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTotalSF", txtEventTotalSF.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTotalMS", txtEventTotalMS.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTotalSuccess", txtEventTotalSuccess.Text.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events_GongTotals WHERE EventId = @EventId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events_GongTotals SET AnimalTargetTotal = @AnimalTargetTotal, AnimalTargetSF = @AnimalTargetSF, AnimalTargetMS = @AnimalTargetMS, "
        str3 &= " AnimalTargetSuccess = @AnimalTargetSuccess, GongScoringTotal = @GongScoringTotal, GongScoringSF = @GongScoringSF, GongScoringMS = @GongScoringMS, "
        str3 &= " GongScoringSuccess = @GongScoringSuccess, EventTotalTotal = @EventTotalTotal, "
        str3 &= " EventTotalSF = @EventTotalSF, EventTotalMS = @EventTotalMS, EventTotalSuccess = @EventTotalSuccess WHERE EventId = @EventId "
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events_GongTotals (EventId, AnimalTargetTotal, AnimalTargetSF, AnimalTargetMS, AnimalTargetSuccess, GongScoringTotal, GongScoringSF, GongScoringMS, GongScoringSuccess, EventTotalTotal, EventTotalSF, EventTotalMS, EventTotalSuccess) "
        str3 &= " VALUES (@EventId, @AnimalTargetTotal, @AnimalTargetSF, @AnimalTargetMS, @AnimalTargetSuccess, @GongScoringTotal, @GongScoringSF, @GongScoringMS, @GongScoringSuccess, @EventTotalTotal, @EventTotalSF, @EventTotalMS, @EventTotalSuccess) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

#Region "Upload Scoresheet"
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If pnl8.Visible = True Then
            pnl8.Visible = False
        Else
            pnl8.Visible = True
        End If
    End Sub
    Protected Sub btnSave8_Click(sender As Object, e As EventArgs) Handles btnSave8.Click
        lblMsg.Text = ""
        SaveHeader()
        UploadScoresheet()
        pnl8.Visible = False
    End Sub
    Private Sub UploadScoresheet()
        Dim SavePath As String = ""
        Dim pathname As String = "../Documents/Scoresheets/"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot
        If System.IO.Directory.Exists(SavePath) Then
        Else
            System.IO.Directory.CreateDirectory(SavePath)
        End If

        If (FileUpload1.HasFile) Then
            Dim fName As String = FileUpload1.FileName
            If System.IO.Directory.Exists(SavePath) Then
            Else
                System.IO.Directory.CreateDirectory(SavePath)
            End If

            Try
                If (FileUpload1.HasFile) Then
                    SavePath += fName.Trim
                    FileUpload1.SaveAs(SavePath)
                    SaveDocument(fName.Trim)
                End If
            Catch ex As Exception

            End Try
        Else
            SaveDocument("")
        End If
    End Sub
    Private Sub SaveDocument(ByVal Scoresheet As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", ddlAssociations.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Event_Id", ddlEvents.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@MemberId", lblMemberNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Scoresheet", Scoresheet.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events SET Scoresheet = @Scoresheet WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events (Association_Id, Event_Id, MemberId, Scoresheet) "
        str3 &= " VALUES (@Association_Id, @Event_Id, @MemberId, @Scoresheet) "
        str3 &= " END  "
        str3 &= " COMMIT TRAN"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub
#End Region

End Class
