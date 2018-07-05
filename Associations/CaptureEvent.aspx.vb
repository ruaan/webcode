Imports System.Data
Imports System.IO
Partial Class Associations_CaptureEvent
    Inherits System.Web.UI.Page

#Region "Variants"
    Dim userId As String
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
    Protected Sub ddlEvents_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEvents.DataBound
        ddlEvents.Items.Insert(0, New ListItem("-Select-"))
        ddlEvents.Items.Insert(1, New ListItem("-Non Event-"))
    End Sub
    Protected Sub ddlAssociations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssociations.SelectedIndexChanged
        If ddlAssociations.SelectedValue.Trim <> "-Select-" Then
            pnlEvents.Visible = True
            PopulateEvents(ddlAssociations.SelectedValue.Trim)
        End If
    End Sub
    Protected Sub ddlEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEvents.SelectedIndexChanged
        If ddlEvents.SelectedValue.Trim <> "-Select-" Then
            ClearScoreSheet()
            pnlMember.Visible = True
            pnlScoreSheet.Visible = True
            PopulateMember()
            PopulateScoresheet()
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        lblError.Text = ""
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
                    SaveScoreSheet(fName.Trim)
                End If
            Catch ex As Exception
                lblError.Text &= ex.Message
            End Try
        Else
            SaveScoreSheet("")
        End If
        ClearScoreSheet()
        pnlScoreSheet.Visible = False
        pnlMember.Visible = False
        pnlEvents.Visible = False
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
    Private Sub PopulateScoresheet()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", ddlAssociations.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Event_Id", ddlEvents.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@MemberId", Request.Cookies("memberid").Value)

        Dim str As String = ""
        str &= " SELECT id, Association_Id, Event_Id, MemberId, Scoresheet, BlesbokMeters, Blesbokx30, Blesbokx20, Blesbokx15, Blesbokx10, Blesbokx5, Blesbokx01, Blesbok30, Blesbok20, Blesbok15, Blesbok10, Blesbok5, BlesbokTotal, "
        str &= " BlesbokSF, BlesbokMS, BlesbokSuccess, Blouwillebeesx30, Blouwillebeesx20, Blouwillebeesx15, Blouwillebeesx10, Blouwillebeesx5, Blouwillebeesx01, Blouwillebees30, Blouwillebees20, Blouwillebees15, Blouwillebees10,"
        str &= " Blouwillebees5, BlouwillebeesTotal, BlouwillebeesSF, BlouwillebeesMS, BlouwillebeesSuccess, Jkkelsx30, Jkkelsx20, Jkkelsx15, Jkkelsx10, Jkkelsx5, Jkkelsx01, Jkkels30, Jkkels20, Jkkels15, Jkkels10, Jkkels5, JkkelsTotal, "
        str &= " JkkelsSF, JkkelsMS, JkkelsSuccess, Rooibokx30, Rooibokx20, Rooibokx15, Rooibokx10, Rooibokx5, Rooibokx01, Rooibok30, Rooibok20, Rooibok15, Rooibok10, Rooibok5, RooibokTotal, RooibokSF, RooibokMS, "
        str &= " RooibokSuccess, Rooihartbeesx30, Rooihartbeesx20, Rooihartbeesx15, Rooihartbeesx10, Rooihartbeesx5, Rooihartbeesx01, Rooihartbees30, Rooihartbees20, Rooihartbees15, Rooihartbees10, Rooihartbees5, "
        str &= " RooihartbeesTotal, RooihartbeesSF, RooihartbeesMS, RooihartbeesSuccess, Springbokx30, Springbokx20, Springbokx15, Springbokx10, Springbokx5, Springbokx01, Springbok30, Springbok20, Springbok15, Springbok10, "
        str &= " Springbok5, SpringbokTotal, SpringbokSF, SpringbokMS, SpringbokSuccess, Vlakvarkx30, Vlakvarkx20, Vlakvarkx15, Vlakvarkx10, Vlakvarkx5, Vlakvarkx01, Vlakvark30, Vlakvark20, Vlakvark15, Vlakvark10, Vlakvark5, "
        str &= " VlakvarkTotal, VlakvarkSF, VlakvarkMS, VlakvarkSuccess, Otherx30, Otherx20, Otherx15, Otherx10, Otherx5, Otherx01, Other30, Other20, Other15, Other10, Other5, OtherTotal, OtherSF, OtherMS, OtherSuccess, Temprature, "
        str &= " WindSpeed, WindDirection, Pressure, Humidity, Altitude, TargetDirection, CalibreGun, BulletGrain, Gong1, Gong2, Gong3, Gong4, Gong5, GongTotal, GongSF, GonMS, GongSuccess, AnimalTargetTotal, AnimalTargetSF, "
        str &= " AnimalTargetMS, AnimalTargetSuccess, GongScoringTotal, GongScoringSF, GongScoringMS, GongScoringSuccess, EventTotalTotal, EventTotalSF, EventTotalMS, EventTotalSuccess, RangeName, Notes, BlouwillebeesMeters, "
        str &= " JkkelsMeters, RooibokMeters, RooihartbeesMeters, SpringbokMeters, VlakvarkMeters, OtherMeters"
        str &= " FROM tbl_Member_Events"
        str &= " WHERE (MemberId = @MemberId) AND (Association_Id = @Association_Id) AND (Event_Id = @Event_Id)"

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
                txtBlesbokMeters.Text = ds.Tables(0).Rows(0).Item("BlesbokMeters").ToString.Trim
                txtBlesbokx30.Text = ds.Tables(0).Rows(0).Item("Blesbokx30").ToString.Trim
                txtBlesbokx20.Text = ds.Tables(0).Rows(0).Item("Blesbokx20").ToString.Trim
                txtBlesbokx15.Text = ds.Tables(0).Rows(0).Item("Blesbokx10").ToString.Trim
                txtBlesbokx10.Text = ds.Tables(0).Rows(0).Item("Blesbokx15").ToString.Trim
                txtBlesbokx5.Text = ds.Tables(0).Rows(0).Item("Blesbokx5").ToString.Trim
                txtBlesbokx01.Text = ds.Tables(0).Rows(0).Item("Blesbokx01").ToString.Trim
                txtBlesbok30.Text = ds.Tables(0).Rows(0).Item("Blesbok30").ToString.Trim
                txtBlesbok20.Text = ds.Tables(0).Rows(0).Item("Blesbok20").ToString.Trim
                txtBlesbok15.Text = ds.Tables(0).Rows(0).Item("Blesbok15").ToString.Trim
                txtBlesbok10.Text = ds.Tables(0).Rows(0).Item("Blesbok10").ToString.Trim
                txtBlesbok5.Text = ds.Tables(0).Rows(0).Item("Blesbok5").ToString.Trim
                txtBlesbokTotal.Text = ds.Tables(0).Rows(0).Item("BlesbokTotal").ToString.Trim
                txtBlesbokSF.Text = ds.Tables(0).Rows(0).Item("BlesbokSF").ToString.Trim
                txtBlesbokMS.Text = ds.Tables(0).Rows(0).Item("BlesbokMS").ToString.Trim
                txtBlesbokSuccess.Text = ds.Tables(0).Rows(0).Item("BlesbokSuccess").ToString.Trim

                txtBlouwillebeesMeters.Text = ds.Tables(0).Rows(0).Item("BlouwillebeesMeters").ToString.Trim
                txtBlouwillebeesx30.Text = ds.Tables(0).Rows(0).Item("Blouwillebeesx30").ToString.Trim
                txtBlouwillebeesx20.Text = ds.Tables(0).Rows(0).Item("Blouwillebeesx20").ToString.Trim
                txtBlouwillebeesx15.Text = ds.Tables(0).Rows(0).Item("Blouwillebeesx10").ToString.Trim
                txtBlouwillebeesx10.Text = ds.Tables(0).Rows(0).Item("Blouwillebeesx15").ToString.Trim
                txtBlouwillebeesx5.Text = ds.Tables(0).Rows(0).Item("Blouwillebeesx5").ToString.Trim
                txtBlouwillebeesx01.Text = ds.Tables(0).Rows(0).Item("Blouwillebeesx01").ToString.Trim
                txtBlouwillebees30.Text = ds.Tables(0).Rows(0).Item("Blouwillebees30").ToString.Trim
                txtBlouwillebees20.Text = ds.Tables(0).Rows(0).Item("Blouwillebees20").ToString.Trim
                txtBlouwillebees15.Text = ds.Tables(0).Rows(0).Item("Blouwillebees15").ToString.Trim
                txtBlouwillebees10.Text = ds.Tables(0).Rows(0).Item("Blouwillebees10").ToString.Trim
                txtBlouwillebees5.Text = ds.Tables(0).Rows(0).Item("Blouwillebees5").ToString.Trim
                txtBlouwillebeesTotal.Text = ds.Tables(0).Rows(0).Item("BlouwillebeesTotal").ToString.Trim
                txtBlouwillebeesSF.Text = ds.Tables(0).Rows(0).Item("BlouwillebeesSF").ToString.Trim
                txtBlouwillebeesMS.Text = ds.Tables(0).Rows(0).Item("BlouwillebeesMS").ToString.Trim
                txtBlouwillebeesSuccess.Text = ds.Tables(0).Rows(0).Item("BlouwillebeesSuccess").ToString.Trim

                txtJkkelsMeters.Text = ds.Tables(0).Rows(0).Item("JkkelsMeters").ToString.Trim
                txtJkkelsx30.Text = ds.Tables(0).Rows(0).Item("Jkkelsx30").ToString.Trim
                txtJkkelsx20.Text = ds.Tables(0).Rows(0).Item("Jkkelsx20").ToString.Trim
                txtJkkelsx15.Text = ds.Tables(0).Rows(0).Item("Jkkelsx10").ToString.Trim
                txtJkkelsx10.Text = ds.Tables(0).Rows(0).Item("Jkkelsx15").ToString.Trim
                txtJkkelsx5.Text = ds.Tables(0).Rows(0).Item("Jkkelsx5").ToString.Trim
                txtJkkelsx01.Text = ds.Tables(0).Rows(0).Item("Jkkelsx01").ToString.Trim
                txtJkkels30.Text = ds.Tables(0).Rows(0).Item("Jkkels30").ToString.Trim
                txtJkkels20.Text = ds.Tables(0).Rows(0).Item("Jkkels20").ToString.Trim
                txtJkkels15.Text = ds.Tables(0).Rows(0).Item("Jkkels15").ToString.Trim
                txtJkkels10.Text = ds.Tables(0).Rows(0).Item("Jkkels10").ToString.Trim
                txtJkkels5.Text = ds.Tables(0).Rows(0).Item("Jkkels5").ToString.Trim
                txtJkkelsTotal.Text = ds.Tables(0).Rows(0).Item("JkkelsTotal").ToString.Trim
                txtJkkelsSF.Text = ds.Tables(0).Rows(0).Item("JkkelsSF").ToString.Trim
                txtJkkelsMS.Text = ds.Tables(0).Rows(0).Item("JkkelsMS").ToString.Trim
                txtJkkelsSuccess.Text = ds.Tables(0).Rows(0).Item("JkkelsSuccess").ToString.Trim

                txtRooibokMeters.Text = ds.Tables(0).Rows(0).Item("RooibokMeters").ToString.Trim
                txtRooibokx30.Text = ds.Tables(0).Rows(0).Item("Rooibokx30").ToString.Trim
                txtRooibokx20.Text = ds.Tables(0).Rows(0).Item("Rooibokx20").ToString.Trim
                txtRooibokx15.Text = ds.Tables(0).Rows(0).Item("Rooibokx10").ToString.Trim
                txtRooibokx10.Text = ds.Tables(0).Rows(0).Item("Rooibokx15").ToString.Trim
                txtRooibokx5.Text = ds.Tables(0).Rows(0).Item("Rooibokx5").ToString.Trim
                txtRooibokx01.Text = ds.Tables(0).Rows(0).Item("Rooibokx01").ToString.Trim
                txtRooibok30.Text = ds.Tables(0).Rows(0).Item("Rooibok30").ToString.Trim
                txtRooibok20.Text = ds.Tables(0).Rows(0).Item("Rooibok20").ToString.Trim
                txtRooibok15.Text = ds.Tables(0).Rows(0).Item("Rooibok15").ToString.Trim
                txtRooibok10.Text = ds.Tables(0).Rows(0).Item("Rooibok10").ToString.Trim
                txtRooibok5.Text = ds.Tables(0).Rows(0).Item("Rooibok5").ToString.Trim
                txtRooibokTotal.Text = ds.Tables(0).Rows(0).Item("RooibokTotal").ToString.Trim
                txtRooibokSF.Text = ds.Tables(0).Rows(0).Item("RooibokSF").ToString.Trim
                txtRooibokMS.Text = ds.Tables(0).Rows(0).Item("RooibokMS").ToString.Trim
                txtRooibokSuccess.Text = ds.Tables(0).Rows(0).Item("RooibokSuccess").ToString.Trim

                txtRooihartbeesMeters.Text = ds.Tables(0).Rows(0).Item("RooihartbeesMeters").ToString.Trim
                txtRooihartbeesx30.Text = ds.Tables(0).Rows(0).Item("Rooihartbeesx30").ToString.Trim
                txtRooihartbeesx20.Text = ds.Tables(0).Rows(0).Item("Rooihartbeesx20").ToString.Trim
                txtRooihartbeesx15.Text = ds.Tables(0).Rows(0).Item("Rooihartbeesx10").ToString.Trim
                txtRooihartbeesx10.Text = ds.Tables(0).Rows(0).Item("Rooihartbeesx15").ToString.Trim
                txtRooihartbeesx5.Text = ds.Tables(0).Rows(0).Item("Rooihartbeesx5").ToString.Trim
                txtRooihartbeesx01.Text = ds.Tables(0).Rows(0).Item("Rooihartbeesx01").ToString.Trim
                txtRooihartbees30.Text = ds.Tables(0).Rows(0).Item("Rooihartbees30").ToString.Trim
                txtRooihartbees20.Text = ds.Tables(0).Rows(0).Item("Rooihartbees20").ToString.Trim
                txtRooihartbees15.Text = ds.Tables(0).Rows(0).Item("Rooihartbees15").ToString.Trim
                txtRooihartbees10.Text = ds.Tables(0).Rows(0).Item("Rooihartbees10").ToString.Trim
                txtRooihartbees5.Text = ds.Tables(0).Rows(0).Item("Rooihartbees5").ToString.Trim
                txtRooihartbeesTotal.Text = ds.Tables(0).Rows(0).Item("RooihartbeesTotal").ToString.Trim
                txtRooihartbeesSF.Text = ds.Tables(0).Rows(0).Item("RooihartbeesSF").ToString.Trim
                txtRooihartbeesMS.Text = ds.Tables(0).Rows(0).Item("RooihartbeesMS").ToString.Trim
                txtRooihartbeesSuccess.Text = ds.Tables(0).Rows(0).Item("RooihartbeesSuccess").ToString.Trim

                txtSpringbokMeters.Text = ds.Tables(0).Rows(0).Item("SpringbokMeters").ToString.Trim
                txtSpringbokx30.Text = ds.Tables(0).Rows(0).Item("Springbokx30").ToString.Trim
                txtSpringbokx20.Text = ds.Tables(0).Rows(0).Item("Springbokx20").ToString.Trim
                txtSpringbokx15.Text = ds.Tables(0).Rows(0).Item("Springbokx10").ToString.Trim
                txtSpringbokx10.Text = ds.Tables(0).Rows(0).Item("Springbokx15").ToString.Trim
                txtSpringbokx5.Text = ds.Tables(0).Rows(0).Item("Springbokx5").ToString.Trim
                txtSpringbokx01.Text = ds.Tables(0).Rows(0).Item("Springbokx01").ToString.Trim
                txtSpringbok30.Text = ds.Tables(0).Rows(0).Item("Springbok30").ToString.Trim
                txtSpringbok20.Text = ds.Tables(0).Rows(0).Item("Springbok20").ToString.Trim
                txtSpringbok15.Text = ds.Tables(0).Rows(0).Item("Springbok15").ToString.Trim
                txtSpringbok10.Text = ds.Tables(0).Rows(0).Item("Springbok10").ToString.Trim
                txtSpringbok5.Text = ds.Tables(0).Rows(0).Item("Springbok5").ToString.Trim
                txtSpringbokTotal.Text = ds.Tables(0).Rows(0).Item("SpringbokTotal").ToString.Trim
                txtSpringbokSF.Text = ds.Tables(0).Rows(0).Item("SpringbokSF").ToString.Trim
                txtSpringbokMS.Text = ds.Tables(0).Rows(0).Item("SpringbokMS").ToString.Trim
                txtSpringbokSuccess.Text = ds.Tables(0).Rows(0).Item("SpringbokSuccess").ToString.Trim

                txtVlakvarkMeters.Text = ds.Tables(0).Rows(0).Item("VlakvarkMeters").ToString.Trim
                txtVlakvarkx30.Text = ds.Tables(0).Rows(0).Item("Vlakvarkx30").ToString.Trim
                txtVlakvarkx20.Text = ds.Tables(0).Rows(0).Item("Vlakvarkx20").ToString.Trim
                txtVlakvarkx15.Text = ds.Tables(0).Rows(0).Item("Vlakvarkx10").ToString.Trim
                txtVlakvarkx10.Text = ds.Tables(0).Rows(0).Item("Vlakvarkx15").ToString.Trim
                txtVlakvarkx5.Text = ds.Tables(0).Rows(0).Item("Vlakvarkx5").ToString.Trim
                txtVlakvarkx01.Text = ds.Tables(0).Rows(0).Item("Vlakvarkx01").ToString.Trim
                txtVlakvark30.Text = ds.Tables(0).Rows(0).Item("Vlakvark30").ToString.Trim
                txtVlakvark20.Text = ds.Tables(0).Rows(0).Item("Vlakvark20").ToString.Trim
                txtVlakvark15.Text = ds.Tables(0).Rows(0).Item("Vlakvark15").ToString.Trim
                txtVlakvark10.Text = ds.Tables(0).Rows(0).Item("Vlakvark10").ToString.Trim
                txtVlakvark5.Text = ds.Tables(0).Rows(0).Item("Vlakvark5").ToString.Trim
                txtVlakvarkTotal.Text = ds.Tables(0).Rows(0).Item("VlakvarkTotal").ToString.Trim
                txtVlakvarkSF.Text = ds.Tables(0).Rows(0).Item("VlakvarkSF").ToString.Trim
                txtVlakvarkMS.Text = ds.Tables(0).Rows(0).Item("VlakvarkMS").ToString.Trim
                txtVlakvarkSuccess.Text = ds.Tables(0).Rows(0).Item("VlakvarkSuccess").ToString.Trim

                txtOtherMeters.Text = ds.Tables(0).Rows(0).Item("OtherMeters").ToString.Trim
                txtOtherx30.Text = ds.Tables(0).Rows(0).Item("Otherx30").ToString.Trim
                txtOtherx20.Text = ds.Tables(0).Rows(0).Item("Otherx20").ToString.Trim
                txtOtherx15.Text = ds.Tables(0).Rows(0).Item("Otherx10").ToString.Trim
                txtOtherx10.Text = ds.Tables(0).Rows(0).Item("Otherx15").ToString.Trim
                txtOtherx5.Text = ds.Tables(0).Rows(0).Item("Otherx5").ToString.Trim
                txtOtherx01.Text = ds.Tables(0).Rows(0).Item("Otherx01").ToString.Trim
                txtOther30.Text = ds.Tables(0).Rows(0).Item("Other30").ToString.Trim
                txtOther20.Text = ds.Tables(0).Rows(0).Item("Other20").ToString.Trim
                txtOther15.Text = ds.Tables(0).Rows(0).Item("Other15").ToString.Trim
                txtOther10.Text = ds.Tables(0).Rows(0).Item("Other10").ToString.Trim
                txtOther5.Text = ds.Tables(0).Rows(0).Item("Other5").ToString.Trim
                txtOtherTotal.Text = ds.Tables(0).Rows(0).Item("OtherTotal").ToString.Trim
                txtOtherSF.Text = ds.Tables(0).Rows(0).Item("OtherSF").ToString.Trim
                txtOtherMS.Text = ds.Tables(0).Rows(0).Item("OtherMS").ToString.Trim
                txtOtherSuccess.Text = ds.Tables(0).Rows(0).Item("OtherSuccess").ToString.Trim

                txtRangeName.Text = ds.Tables(0).Rows(0).Item("RangeName").ToString.Trim
                txtTemperature.Text = ds.Tables(0).Rows(0).Item("Temprature").ToString.Trim
                txtWindSpeed.Text = ds.Tables(0).Rows(0).Item("WindSpeed").ToString.Trim
                txtWindDirection.Text = ds.Tables(0).Rows(0).Item("WindDirection").ToString.Trim
                txtPressure.Text = ds.Tables(0).Rows(0).Item("Pressure").ToString.Trim
                txtHumidity.Text = ds.Tables(0).Rows(0).Item("Humidity").ToString.Trim
                txtAltitude.Text = ds.Tables(0).Rows(0).Item("Altitude").ToString.Trim
                txtTargetDirection.Text = ds.Tables(0).Rows(0).Item("TargetDirection").ToString.Trim
                txtCalibreGun.Text = ds.Tables(0).Rows(0).Item("CalibreGun").ToString.Trim
                txtBulletGrain.Text = ds.Tables(0).Rows(0).Item("BulletGrain").ToString.Trim
                txtNotes.Text = ds.Tables(0).Rows(0).Item("Notes").ToString.Trim

                txtGong1.Text = ds.Tables(0).Rows(0).Item("Gong1").ToString.Trim
                txtGong2.Text = ds.Tables(0).Rows(0).Item("Gong2").ToString.Trim
                txtGong3.Text = ds.Tables(0).Rows(0).Item("Gong3").ToString.Trim
                txtGong4.Text = ds.Tables(0).Rows(0).Item("Gong4").ToString.Trim
                txtGong5.Text = ds.Tables(0).Rows(0).Item("Gong5").ToString.Trim
                txtGongTotal.Text = ds.Tables(0).Rows(0).Item("GongTotal").ToString.Trim
                txtGongSF.Text = ds.Tables(0).Rows(0).Item("GongSF").ToString.Trim
                txtGongMS.Text = ds.Tables(0).Rows(0).Item("GonMS").ToString.Trim
                txtGongSuccess.Text = ds.Tables(0).Rows(0).Item("GongSuccess").ToString.Trim

                txtAnimalTargetTotal.Text = ds.Tables(0).Rows(0).Item("AnimalTargetTotal").ToString.Trim
                txtAnimalTargetSF.Text = ds.Tables(0).Rows(0).Item("AnimalTargetSF").ToString.Trim
                txtAnimalTargetMS.Text = ds.Tables(0).Rows(0).Item("AnimalTargetMS").ToString.Trim
                txtAnimalTargetSuccess.Text = ds.Tables(0).Rows(0).Item("AnimalTargetSuccess").ToString.Trim

                txtGongScoringTotal.Text = ds.Tables(0).Rows(0).Item("GongScoringTotal").ToString.Trim
                txtGongScoringSF.Text = ds.Tables(0).Rows(0).Item("GongScoringSF").ToString.Trim
                txtGongScoringMS.Text = ds.Tables(0).Rows(0).Item("GongScoringMS").ToString.Trim
                txtGongScoringSuccess.Text = ds.Tables(0).Rows(0).Item("GongScoringSuccess").ToString.Trim

                txtEventTotalTotal.Text = ds.Tables(0).Rows(0).Item("EventTotalTotal").ToString.Trim
                txtEventTotalSF.Text = ds.Tables(0).Rows(0).Item("EventTotalSF").ToString.Trim
                txtEventTotalMS.Text = ds.Tables(0).Rows(0).Item("EventTotalMS").ToString.Trim
                txtEventTotalSuccess.Text = ds.Tables(0).Rows(0).Item("EventTotalSuccess").ToString.Trim

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveScoreSheet(ByVal Scoresheet As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Association_Id", ddlAssociations.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@Event_Id", ddlEvents.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@MemberId", lblMemberNo.Text.Trim)
        cmd.Parameters.AddWithValue("@Scoresheet", Scoresheet.Trim)

        cmd.Parameters.AddWithValue("@BlesbokMeters", txtBlesbokMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbokx30", txtBlesbokx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbokx20", txtBlesbokx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbokx15", txtBlesbokx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbokx10", txtBlesbokx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbokx5", txtBlesbokx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbokx01", txtBlesbokx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbok30", txtBlesbok30.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbok20", txtBlesbok20.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbok15", txtBlesbok15.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbok10", txtBlesbok10.Text.Trim)
        cmd.Parameters.AddWithValue("@Blesbok5", txtBlesbok5.Text.Trim)
        cmd.Parameters.AddWithValue("@BlesbokTotal", txtBlesbokTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@BlesbokSF", txtBlesbokSF.Text.Trim)
        cmd.Parameters.AddWithValue("@BlesbokMS", txtBlesbokMS.Text.Trim)
        cmd.Parameters.AddWithValue("@BlesbokSuccess", txtBlesbokSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@BlouwillebeesMeters", txtBlouwillebeesMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebeesx30", txtBlouwillebeesx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebeesx20", txtBlouwillebeesx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebeesx15", txtBlouwillebeesx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebeesx10", txtBlouwillebeesx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebeesx5", txtBlouwillebeesx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebeesx01", txtBlouwillebeesx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebees30", txtBlouwillebees30.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebees20", txtBlouwillebees20.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebees15", txtBlouwillebees15.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebees10", txtBlouwillebees10.Text.Trim)
        cmd.Parameters.AddWithValue("@Blouwillebees5", txtBlouwillebees5.Text.Trim)
        cmd.Parameters.AddWithValue("@BlouwillebeesTotal", txtBlouwillebeesTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@BlouwillebeesSF", txtBlouwillebeesSF.Text.Trim)
        cmd.Parameters.AddWithValue("@BlouwillebeesMS", txtBlouwillebeesMS.Text.Trim)
        cmd.Parameters.AddWithValue("@BlouwillebeesSuccess", txtBlouwillebeesSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@JkkelsMeters", txtJkkelsMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkelsx30", txtJkkelsx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkelsx20", txtJkkelsx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkelsx15", txtJkkelsx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkelsx10", txtJkkelsx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkelsx5", txtJkkelsx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkelsx01", txtJkkelsx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkels30", txtJkkels30.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkels20", txtJkkels20.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkels15", txtJkkels15.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkels10", txtJkkels10.Text.Trim)
        cmd.Parameters.AddWithValue("@Jkkels5", txtJkkels5.Text.Trim)
        cmd.Parameters.AddWithValue("@JkkelsTotal", txtJkkelsTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@JkkelsSF", txtJkkelsSF.Text.Trim)
        cmd.Parameters.AddWithValue("@JkkelsMS", txtJkkelsMS.Text.Trim)
        cmd.Parameters.AddWithValue("@JkkelsSuccess", txtJkkelsSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@RooibokMeters", txtRooibokMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibokx30", txtRooibokx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibokx20", txtRooibokx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibokx15", txtRooibokx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibokx10", txtRooibokx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibokx5", txtRooibokx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibokx01", txtRooibokx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibok30", txtRooibok30.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibok20", txtRooibok20.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibok15", txtRooibok15.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibok10", txtRooibok10.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooibok5", txtRooibok5.Text.Trim)
        cmd.Parameters.AddWithValue("@RooibokTotal", txtRooibokTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@RooibokSF", txtRooibokSF.Text.Trim)
        cmd.Parameters.AddWithValue("@RooibokMS", txtRooibokMS.Text.Trim)
        cmd.Parameters.AddWithValue("@RooibokSuccess", txtRooibokSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@RooihartbeesMeters", txtRooihartbeesMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbeesx30", txtRooihartbeesx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbeesx20", txtRooihartbeesx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbeesx15", txtRooihartbeesx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbeesx10", txtRooihartbeesx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbeesx5", txtRooihartbeesx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbeesx01", txtRooihartbeesx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbees30", txtRooihartbees30.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbees20", txtRooihartbees20.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbees15", txtRooihartbees15.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbees10", txtRooihartbees10.Text.Trim)
        cmd.Parameters.AddWithValue("@Rooihartbees5", txtRooihartbees5.Text.Trim)
        cmd.Parameters.AddWithValue("@RooihartbeesTotal", txtRooihartbeesTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@RooihartbeesSF", txtRooihartbeesSF.Text.Trim)
        cmd.Parameters.AddWithValue("@RooihartbeesMS", txtRooihartbeesMS.Text.Trim)
        cmd.Parameters.AddWithValue("@RooihartbeesSuccess", txtRooihartbeesSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@SpringbokMeters", txtSpringbokMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbokx30", txtSpringbokx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbokx20", txtSpringbokx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbokx15", txtSpringbokx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbokx10", txtSpringbokx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbokx5", txtSpringbokx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbokx01", txtSpringbokx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbok30", txtSpringbok30.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbok20", txtSpringbok20.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbok15", txtSpringbok15.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbok10", txtSpringbok10.Text.Trim)
        cmd.Parameters.AddWithValue("@Springbok5", txtSpringbok5.Text.Trim)
        cmd.Parameters.AddWithValue("@SpringbokTotal", txtSpringbokTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@SpringbokSF", txtSpringbokSF.Text.Trim)
        cmd.Parameters.AddWithValue("@SpringbokMS", txtSpringbokMS.Text.Trim)
        cmd.Parameters.AddWithValue("@SpringbokSuccess", txtSpringbokSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@VlakvarkMeters", txtVlakvarkMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvarkx30", txtVlakvarkx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvarkx20", txtVlakvarkx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvarkx15", txtVlakvarkx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvarkx10", txtVlakvarkx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvarkx5", txtVlakvarkx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvarkx01", txtVlakvarkx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvark30", txtVlakvark30.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvark20", txtVlakvark20.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvark15", txtVlakvark15.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvark10", txtVlakvark10.Text.Trim)
        cmd.Parameters.AddWithValue("@Vlakvark5", txtVlakvark5.Text.Trim)
        cmd.Parameters.AddWithValue("@VlakvarkTotal", txtVlakvarkTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@VlakvarkSF", txtVlakvarkSF.Text.Trim)
        cmd.Parameters.AddWithValue("@VlakvarkMS", txtVlakvarkMS.Text.Trim)
        cmd.Parameters.AddWithValue("@VlakvarkSuccess", txtVlakvarkSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@OtherMeters", txtOtherMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@Otherx30", txtOtherx30.Text.Trim)
        cmd.Parameters.AddWithValue("@Otherx20", txtOtherx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Otherx15", txtOtherx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Otherx10", txtOtherx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Otherx5", txtOtherx5.Text.Trim)
        cmd.Parameters.AddWithValue("@Otherx01", txtOtherx01.Text.Trim)
        cmd.Parameters.AddWithValue("@Other30", txtOther30.Text.Trim)
        cmd.Parameters.AddWithValue("@Other20", txtOther20.Text.Trim)
        cmd.Parameters.AddWithValue("@Other15", txtOther15.Text.Trim)
        cmd.Parameters.AddWithValue("@Other10", txtOther10.Text.Trim)
        cmd.Parameters.AddWithValue("@Other5", txtOther5.Text.Trim)
        cmd.Parameters.AddWithValue("@OtherTotal", txtOtherTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@OtherSF", txtOtherSF.Text.Trim)
        cmd.Parameters.AddWithValue("@OtherMS", txtOtherMS.Text.Trim)
        cmd.Parameters.AddWithValue("@OtherSuccess", txtOtherSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@RangeName", txtRangeName.Text.Trim)
        cmd.Parameters.AddWithValue("@Temprature", txtOtherMeters.Text.Trim)
        cmd.Parameters.AddWithValue("@WindSpeed", txtOtherx30.Text.Trim)
        cmd.Parameters.AddWithValue("@WindDirection", txtOtherx20.Text.Trim)
        cmd.Parameters.AddWithValue("@Pressure", txtOtherx15.Text.Trim)
        cmd.Parameters.AddWithValue("@Humidity", txtOtherx10.Text.Trim)
        cmd.Parameters.AddWithValue("@Altitude", txtOtherx5.Text.Trim)
        cmd.Parameters.AddWithValue("@TargetDirection", txtOtherx01.Text.Trim)
        cmd.Parameters.AddWithValue("@CalibreGun", txtOther30.Text.Trim)
        cmd.Parameters.AddWithValue("@BulletGrain", txtOther20.Text.Trim)
        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim)

        cmd.Parameters.AddWithValue("@Gong1", txtOther15.Text.Trim)
        cmd.Parameters.AddWithValue("@Gong2", txtOther10.Text.Trim)
        cmd.Parameters.AddWithValue("@Gong3", txtOther5.Text.Trim)
        cmd.Parameters.AddWithValue("@Gong4", txtOtherTotal.Text.Trim)
        cmd.Parameters.AddWithValue("@Gong5", txtOtherSF.Text.Trim)
        cmd.Parameters.AddWithValue("@GongTotal", txtOtherMS.Text.Trim)
        cmd.Parameters.AddWithValue("@GongSF", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@GonMS", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@GongSuccess", txtOtherSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@AnimalTargetTotal", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@AnimalTargetSF", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@AnimalTargetMS", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@AnimalTargetSuccess", txtOtherSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@GongScoringTotal", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@GongScoringSF", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@GongScoringMS", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@GongScoringSuccess", txtOtherSuccess.Text.Trim)

        cmd.Parameters.AddWithValue("@EventTotalTotal", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTotalSF", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTotalMS", txtOtherSuccess.Text.Trim)
        cmd.Parameters.AddWithValue("@EventTotalSuccess", txtOtherSuccess.Text.Trim)

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " BEGIN TRAN"
        str3 &= " IF EXISTS (SELECT * FROM tbl_Member_Events WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId)"
        str3 &= " BEGIN"
        str3 &= " UPDATE tbl_Member_Events SET Scoresheet = @Scoresheet, "
        str3 &= " BlesbokMeters = @BlesbokMeters, Blesbokx30 = @Blesbokx30, Blesbokx20 = @Blesbokx20, Blesbokx15 = @Blesbokx15,  "
        str3 &= " Blesbokx10 = @Blesbokx10, Blesbokx5 = @Blesbokx5, Blesbokx01 = @Blesbokx01, Blesbok30 = @Blesbok30,  "
        str3 &= " Blesbok20 = @Blesbok20, Blesbok15 = @Blesbok15, Blesbok10 = @Blesbok10, Blesbok5 = @Blesbok5,  "
        str3 &= " BlesbokTotal = @BlesbokTotal, BlesbokSF = @BlesbokSF, BlesbokMS = @BlesbokMS, BlesbokSuccess = @BlesbokSuccess,  "
        str3 &= " BlouwillebeesMeters = @BlouwillebeesMeters, Blouwillebeesx30 = @Blouwillebeesx30, Blouwillebeesx20 = @Blouwillebeesx20, Blouwillebeesx15 = @Blouwillebeesx15,  "
        str3 &= " Blouwillebeesx10 = @Blouwillebeesx10, Blouwillebeesx5 = @Blouwillebeesx5, Blouwillebeesx01 = @Blouwillebeesx01, Blouwillebees30 = @Blouwillebees30,  "
        str3 &= " Blouwillebees20 = @Blouwillebees20, Blouwillebees15 = @Blouwillebees15, Blouwillebees10 = @Blouwillebees10, Blouwillebees5 = @Blouwillebees5,  "
        str3 &= " BlouwillebeesTotal = @BlouwillebeesTotal, BlouwillebeesSF = @BlouwillebeesSF, BlouwillebeesMS = @BlouwillebeesMS, BlouwillebeesSuccess = @BlouwillebeesSuccess,  "
        str3 &= " JkkelsMeters = @JkkelsMeters, Jkkelsx30 = @Jkkelsx30, Jkkelsx20 = @Jkkelsx20, Jkkelsx15 = @Jkkelsx15,  "
        str3 &= " Jkkelsx10 = @Jkkelsx10, Jkkelsx5 = @Jkkelsx5, Jkkelsx01 = @Jkkelsx01, Jkkels30 = @Jkkels30,  "
        str3 &= " Jkkels20 = @Jkkels20, Jkkels15 = @Jkkels15, Jkkels10 = @Jkkels10, Jkkels5 = @Jkkels5,  "
        str3 &= " JkkelsTotal = @JkkelsTotal, JkkelsSF = @JkkelsSF, JkkelsMS = @JkkelsMS, JkkelsSuccess = @JkkelsSuccess,  "
        str3 &= " RooibokMeters = @RooibokMeters, Rooibokx30 = @Rooibokx30, Rooibokx20 = @Rooibokx20, Rooibokx15 = @Rooibokx15,  "
        str3 &= " Rooibokx10 = @Rooibokx10, Rooibokx5 = @Rooibokx5, Rooibokx01 = @Rooibokx01, Rooibok30 = @Rooibok30,  "
        str3 &= " Rooibok20 = @Rooibok20, Rooibok15 = @Rooibok15, Rooibok10 = @Rooibok10, Rooibok5 = @Rooibok5,  "
        str3 &= " RooibokTotal = @RooibokTotal, RooibokSF = @RooibokSF, RooibokMS = @RooibokMS, RooibokSuccess = @RooibokSuccess,  "
        str3 &= " RooihartbeesMeters = @RooihartbeesMeters, Rooihartbeesx30 = @Rooihartbeesx30, Rooihartbeesx20 = @Rooihartbeesx20, Rooihartbeesx15 = @Rooihartbeesx15,  "
        str3 &= " Rooihartbeesx10 = @Rooihartbeesx10, Rooihartbeesx5 = @Rooihartbeesx5, Rooihartbeesx01 = @Rooihartbeesx01, Rooihartbees30 = @Rooihartbees30,  "
        str3 &= " Rooihartbees20 = @Rooihartbees20, Rooihartbees15 = @Rooihartbees15, Rooihartbees10 = @Rooihartbees10, Rooihartbees5 = @Rooihartbees5,  "
        str3 &= " RooihartbeesTotal = @RooihartbeesTotal, RooihartbeesSF = @RooihartbeesSF, RooihartbeesMS = @RooihartbeesMS, RooihartbeesSuccess = @RooihartbeesSuccess,  "
        str3 &= " SpringbokMeters = @SpringbokMeters, Springbokx30 = @Springbokx30, Springbokx20 = @Springbokx20, Springbokx15 = @Springbokx15,  "
        str3 &= " Springbokx10 = @Springbokx10, Springbokx5 = @Springbokx5, Springbokx01 = @Springbokx01, Springbok30 = @Springbok30,  "
        str3 &= " Springbok20 = @Springbok20, Springbok15 = @Springbok15, Springbok10 = @Springbok10, Springbok5 = @Springbok5,  "
        str3 &= " SpringbokTotal = @SpringbokTotal, SpringbokSF = @SpringbokSF, SpringbokMS = @SpringbokMS, SpringbokSuccess = @SpringbokSuccess,  "
        str3 &= " VlakvarkMeters = @VlakvarkMeters, Vlakvarkx30 = @Vlakvarkx30, Vlakvarkx20 = @Vlakvarkx20, Vlakvarkx15 = @Vlakvarkx15,  "
        str3 &= " Vlakvarkx10 = @Vlakvarkx10, Vlakvarkx5 = @Vlakvarkx5, Vlakvarkx01 = @Vlakvarkx01, Vlakvark30 = @Vlakvark30,  "
        str3 &= " Vlakvark20 = @Vlakvark20, Vlakvark15 = @Vlakvark15, Vlakvark10 = @Vlakvark10, Vlakvark5 = @Vlakvark5,  "
        str3 &= " VlakvarkTotal = @VlakvarkTotal, VlakvarkSF = @VlakvarkSF, VlakvarkMS = @VlakvarkMS, VlakvarkSuccess = @VlakvarkSuccess,  "
        str3 &= " OtherMeters = @OtherMeters, Otherx30 = @Otherx30, Otherx20 = @Otherx20, Otherx15 = @Otherx15,  "
        str3 &= " Otherx10 = @Otherx10, Otherx5 = @Otherx5, Otherx01 = @Otherx01, Other30 = @Other30,  "
        str3 &= " Other20 = @Other20, Other15 = @Other15, Other10 = @Other10, Other5 = @Other5,  "
        str3 &= " OtherTotal = @OtherTotal, OtherSF = @OtherSF, OtherMS = @OtherMS, OtherSuccess = @OtherSuccess,  "
        str3 &= " RangeName = @RangeName, Temprature = @Temprature, WindSpeed = @WindSpeed, WindDirection = @WindDirection, Pressure = @Pressure,  "
        str3 &= " Humidity = @Humidity, Altitude = @Altitude, TargetDirection = @TargetDirection, CalibreGun = @CalibreGun,  "
        str3 &= " BulletGrain = @BulletGrain, Notes = @Notes, "
        str3 &= " Gong1 = @Gong1, Gong2 = @Gong2, Gong3 = @Gong3, Gong4 = @Gong4,  "
        str3 &= " Gong5 = @Gong5, GongTotal = @GongTotal, GongSF = @GongSF, GonMS = @GonMS,  "
        str3 &= " GongSuccess = @GongSuccess,  "
        str3 &= " AnimalTargetTotal = @AnimalTargetTotal, AnimalTargetSF = @AnimalTargetSF, AnimalTargetMS = @AnimalTargetMS, "
        str3 &= " AnimalTargetSuccess = @AnimalTargetSuccess,  "
        str3 &= " GongScoringTotal = @GongScoringTotal, GongScoringSF = @GongScoringSF, GongScoringMS = @GongScoringMS, "
        str3 &= " GongScoringSuccess = @GongScoringSuccess,  "
        str3 &= " EventTotalTotal = @EventTotalTotal, EventTotalSF = @EventTotalSF, EventTotalMS = @EventTotalMS, "
        str3 &= " EventTotalSuccess = @EventTotalSuccess  "
        str3 &= " WHERE Association_Id = @Association_Id AND Event_Id = @Event_Id AND MemberId = @MemberId"
        str3 &= " END "
        str3 &= " ELSE "
        str3 &= " BEGIN"
        str3 &= " INSERT INTO tbl_Member_Events (Association_Id, Event_Id, MemberId, Scoresheet, "
        str3 &= " BlesbokMeters, Blesbokx30, Blesbokx20, Blesbokx15, Blesbokx10, Blesbokx5, Blesbokx01, Blesbok30, Blesbok20, "
        str3 &= " Blesbok15, Blesbok10, BlesbokTotal, BlesbokSF, BlesbokMS, BlesbokSuccess, "
        str3 &= " BlouwillebeesMeters, Blouwillebeesx30, Blouwillebeesx20, Blouwillebeesx15, Blouwillebeesx10, Blouwillebeesx5, Blouwillebeesx01, Blouwillebees30, Blouwillebees20, "
        str3 &= " Blouwillebees15, Blouwillebees10, BlouwillebeesTotal, BlouwillebeesSF, BlouwillebeesMS, BlouwillebeesSuccess, "
        str3 &= " JkkelsMeters, Jkkelsx30, Jkkelsx20, Jkkelsx15, Jkkelsx10, Jkkelsx5, Jkkelsx01, Jkkels30, Jkkels20, "
        str3 &= " Jkkels15, Jkkels10, JkkelsTotal, JkkelsSF, JkkelsMS, JkkelsSuccess, "
        str3 &= " RooibokMeters, Rooibokx30, Rooibokx20, Rooibokx15, Rooibokx10, Rooibokx5, Rooibokx01, Rooibok30, Rooibok20, "
        str3 &= " Rooibok15, Rooibok10, RooibokTotal, RooibokSF, RooibokMS, RooibokSuccess, "
        str3 &= " RooihartbeesMeters, Rooihartbeesx30, Rooihartbeesx20, Rooihartbeesx15, Rooihartbeesx10, Rooihartbeesx5, Rooihartbeesx01, Rooihartbees30, Rooihartbees20, "
        str3 &= " Rooihartbees15, Rooihartbees10, RooihartbeesTotal, RooihartbeesSF, RooihartbeesMS, RooihartbeesSuccess, "
        str3 &= " SpringbokMeters, Springbokx30, Springbokx20, Springbokx15, Springbokx10, Springbokx5, Springbokx01, Springbok30, Springbok20, "
        str3 &= " Springbok15, Springbok10, SpringbokTotal, SpringbokSF, SpringbokMS, SpringbokSuccess, "
        str3 &= " VlakvarkMeters, Vlakvarkx30, Vlakvarkx20, Vlakvarkx15, Vlakvarkx10, Vlakvarkx5, Vlakvarkx01, Vlakvark30, Vlakvark20, "
        str3 &= " Vlakvark15, Vlakvark10, VlakvarkTotal, VlakvarkSF, VlakvarkMS, VlakvarkSuccess, "
        str3 &= " OtherMeters, Otherx30, Otherx20, Otherx15, Otherx10, Otherx5, Otherx01, Other30, Other20, "
        str3 &= " Other15, Other10, OtherTotal, OtherSF, OtherMS, OtherSuccess, "
        str3 &= " RangeName, Temprature, WindSpeed, WindDirection, Pressure, Humidity, Altitude, TargetDirection, CalibreGun, BulletGrain, Notes, "
        str3 &= " Gong1, Gong2, Gong3, Gong4, Gong5, GongTotal, GongSF, GonMS, GongSuccess, "
        str3 &= " AnimalTargetTotal, AnimalTargetSF, AnimalTargetMS, AnimalTargetSuccess, "
        str3 &= " GongScoringTotal, GongScoringSF, GongScoringMS, GongScoringSuccess, "
        str3 &= " EventTotalTotal, EventTotalSF, EventTotalMS, EventTotalSuccess) "
        str3 &= " VALUES (@Association_Id, @Event_Id, @MemberId, @Scoresheet, "
        str3 &= " @BlesbokMeters, @Blesbokx30, @Blesbokx20, @Blesbokx15, @Blesbokx10, @Blesbokx5, @Blesbokx01, @Blesbok30, @Blesbok20, "
        str3 &= " @Blesbok15, @Blesbok10, @BlesbokTotal, @BlesbokSF, @BlesbokMS, @BlesbokSuccess, "
        str3 &= " @BlouwillebeesMeters, @Blouwillebeesx30, @Blouwillebeesx20, @Blouwillebeesx15, @Blouwillebeesx10, @Blouwillebeesx5, @Blouwillebeesx01, @Blouwillebees30, @Blouwillebees20, "
        str3 &= " @Blouwillebees15, @Blouwillebees10, @BlouwillebeesTotal, @BlouwillebeesSF, @BlouwillebeesMS, @BlouwillebeesSuccess, "
        str3 &= " @JkkelsMeters, @Jkkelsx30, @Jkkelsx20, @Jkkelsx15, @Jkkelsx10, @Jkkelsx5, @Jkkelsx01, @Jkkels30, @Jkkels20, "
        str3 &= " @Jkkels15, @Jkkels10, @JkkelsTotal, @JkkelsSF, @JkkelsMS, @JkkelsSuccess, "
        str3 &= " @RooibokMeters, @Rooibokx30, @Rooibokx20, @Rooibokx15, @Rooibokx10, @Rooibokx5, @Rooibokx01, @Rooibok30, @Rooibok20, "
        str3 &= " @Rooibok15, @Rooibok10, @RooibokTotal, @RooibokSF, @RooibokMS, @RooibokSuccess, "
        str3 &= " @RooihartbeesMeters, @Rooihartbeesx30, @Rooihartbeesx20, @Rooihartbeesx15, @Rooihartbeesx10, @Rooihartbeesx5, @Rooihartbeesx01, @Rooihartbees30, @Rooihartbees20, "
        str3 &= " @Rooihartbees15, @Rooihartbees10, @RooihartbeesTotal, @RooihartbeesSF, @RooihartbeesMS, @RooihartbeesSuccess, "
        str3 &= " @SpringbokMeters, @Springbokx30, @Springbokx20, @Springbokx15, @Springbokx10, @Springbokx5, @Springbokx01, @Springbok30, @Springbok20, "
        str3 &= " @Springbok15, @Springbok10, @SpringbokTotal, @SpringbokSF, @SpringbokMS, @SpringbokSuccess, "
        str3 &= " @VlakvarkMeters, @Vlakvarkx30, @Vlakvarkx20, @Vlakvarkx15, @Vlakvarkx10, @Vlakvarkx5, @Vlakvarkx01, @Vlakvark30, @Vlakvark20, "
        str3 &= " @Vlakvark15, @Vlakvark10, @VlakvarkTotal, @VlakvarkSF, @VlakvarkMS, @VlakvarkSuccess, "
        str3 &= " @OtherMeters, @Otherx30, @Otherx20, @Otherx15, @Otherx10, @Otherx5, @Otherx01, @Other30, @Other20, "
        str3 &= " @Other15, @Other10, @OtherTotal, @OtherSF, @OtherMS, @OtherSuccess, "
        str3 &= " @RangeName, @Temprature, @WindSpeed, @WindDirection, @Pressure, @Humidity, @Altitude, @TargetDirection, @CalibreGun, @BulletGrain, @Notes, "
        str3 &= " @Gong1, @Gong2, @Gong3, @Gong4, @Gong5, @GongTotal, @GongSF, @GonMS, @GongSuccess, "
        str3 &= " @AnimalTargetTotal, @AnimalTargetSF, @AnimalTargetMS, @AnimalTargetSuccess, "
        str3 &= " @GongScoringTotal, @GongScoringSF, @GongScoringMS, @GongScoringSuccess, "
        str3 &= " @EventTotalTotal, @EventTotalSF, @EventTotalMS, @EventTotalSuccess) "
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
            lblError.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try
    End Sub
    Private Sub ClearScoreSheet()

        txtBlesbokMeters.Text = ""
        txtBlesbokx30.Text = ""
        txtBlesbokx20.Text = ""
        txtBlesbokx15.Text = ""
        txtBlesbokx10.Text = ""
        txtBlesbokx5.Text = ""
        txtBlesbokx01.Text = ""
        txtBlesbok30.Text = ""
        txtBlesbok20.Text = ""
        txtBlesbok15.Text = ""
        txtBlesbok10.Text = ""
        txtBlesbok5.Text = ""
        txtBlesbokTotal.Text = ""
        txtBlesbokSF.Text = ""
        txtBlesbokMS.Text = ""
        txtBlesbokSuccess.Text = ""

        txtBlouwillebeesMeters.Text = ""
        txtBlouwillebeesx30.Text = ""
        txtBlouwillebeesx20.Text = ""
        txtBlouwillebeesx15.Text = ""
        txtBlouwillebeesx10.Text = ""
        txtBlouwillebeesx5.Text = ""
        txtBlouwillebeesx01.Text = ""
        txtBlouwillebees30.Text = ""
        txtBlouwillebees20.Text = ""
        txtBlouwillebees15.Text = ""
        txtBlouwillebees10.Text = ""
        txtBlouwillebees5.Text = ""
        txtBlouwillebeesTotal.Text = ""
        txtBlouwillebeesSF.Text = ""
        txtBlouwillebeesMS.Text = ""
        txtBlouwillebeesSuccess.Text = ""

        txtJkkelsMeters.Text = ""
        txtJkkelsx30.Text = ""
        txtJkkelsx20.Text = ""
        txtJkkelsx15.Text = ""
        txtJkkelsx10.Text = ""
        txtJkkelsx5.Text = ""
        txtJkkelsx01.Text = ""
        txtJkkels30.Text = ""
        txtJkkels20.Text = ""
        txtJkkels15.Text = ""
        txtJkkels10.Text = ""
        txtJkkels5.Text = ""
        txtJkkelsTotal.Text = ""
        txtJkkelsSF.Text = ""
        txtJkkelsMS.Text = ""
        txtJkkelsSuccess.Text = ""

        txtRooibokMeters.Text = ""
        txtRooibokx30.Text = ""
        txtRooibokx20.Text = ""
        txtRooibokx15.Text = ""
        txtRooibokx10.Text = ""
        txtRooibokx5.Text = ""
        txtRooibokx01.Text = ""
        txtRooibok30.Text = ""
        txtRooibok20.Text = ""
        txtRooibok15.Text = ""
        txtRooibok10.Text = ""
        txtRooibok5.Text = ""
        txtRooibokTotal.Text = ""
        txtRooibokSF.Text = ""
        txtRooibokMS.Text = ""
        txtRooibokSuccess.Text = ""

        txtRooihartbeesMeters.Text = ""
        txtRooihartbeesx30.Text = ""
        txtRooihartbeesx20.Text = ""
        txtRooihartbeesx15.Text = ""
        txtRooihartbeesx10.Text = ""
        txtRooihartbeesx5.Text = ""
        txtRooihartbeesx01.Text = ""
        txtRooihartbees30.Text = ""
        txtRooihartbees20.Text = ""
        txtRooihartbees15.Text = ""
        txtRooihartbees10.Text = ""
        txtRooihartbees5.Text = ""
        txtRooihartbeesTotal.Text = ""
        txtRooihartbeesSF.Text = ""
        txtRooihartbeesMS.Text = ""
        txtRooihartbeesSuccess.Text = ""

        txtSpringbokMeters.Text = ""
        txtSpringbokx30.Text = ""
        txtSpringbokx20.Text = ""
        txtSpringbokx15.Text = ""
        txtSpringbokx10.Text = ""
        txtSpringbokx5.Text = ""
        txtSpringbokx01.Text = ""
        txtSpringbok30.Text = ""
        txtSpringbok20.Text = ""
        txtSpringbok15.Text = ""
        txtSpringbok10.Text = ""
        txtSpringbok5.Text = ""
        txtSpringbokTotal.Text = ""
        txtSpringbokSF.Text = ""
        txtSpringbokMS.Text = ""
        txtSpringbokSuccess.Text = ""

        txtVlakvarkMeters.Text = ""
        txtVlakvarkx30.Text = ""
        txtVlakvarkx20.Text = ""
        txtVlakvarkx15.Text = ""
        txtVlakvarkx10.Text = ""
        txtVlakvarkx5.Text = ""
        txtVlakvarkx01.Text = ""
        txtVlakvark30.Text = ""
        txtVlakvark20.Text = ""
        txtVlakvark15.Text = ""
        txtVlakvark10.Text = ""
        txtVlakvark5.Text = ""
        txtVlakvarkTotal.Text = ""
        txtVlakvarkSF.Text = ""
        txtVlakvarkMS.Text = ""
        txtVlakvarkSuccess.Text = ""

        txtOtherMeters.Text = ""
        txtOtherx30.Text = ""
        txtOtherx20.Text = ""
        txtOtherx15.Text = ""
        txtOtherx10.Text = ""
        txtOtherx5.Text = ""
        txtOtherx01.Text = ""
        txtOther30.Text = ""
        txtOther20.Text = ""
        txtOther15.Text = ""
        txtOther10.Text = ""
        txtOther5.Text = ""
        txtOtherTotal.Text = ""
        txtOtherSF.Text = ""
        txtOtherMS.Text = ""
        txtOtherSuccess.Text = ""
        txtRangeName.Text = ""
        txtTemperature.Text = ""
        txtWindSpeed.Text = ""
        txtWindDirection.Text = ""
        txtPressure.Text = ""
        txtHumidity.Text = ""
        txtAltitude.Text = ""
        txtTargetDirection.Text = ""
        txtCalibreGun.Text = ""
        txtBulletGrain.Text = ""
        txtGong1.Text = ""
        txtGong2.Text = ""
        txtGong3.Text = ""
        txtGong4.Text = ""
        txtGongTotal.Text = ""
        txtGongSF.Text = ""
        txtGongMS.Text = ""
        txtGongSuccess.Text = ""
        txtAnimalTargetTotal.Text = ""
        txtAnimalTargetSF.Text = ""
        txtAnimalTargetMS.Text = ""
        txtAnimalTargetSuccess.Text = ""
        txtGongScoringTotal.Text = ""
        txtGongScoringSF.Text = ""
        txtGongScoringMS.Text = ""
        txtGongScoringSuccess.Text = ""
        txtEventTotalTotal.Text = ""
        txtEventTotalSF.Text = ""
        txtEventTotalMS.Text = ""
        txtEventTotalSuccess.Text = ""

    End Sub
#End Region

#Region "Functions"

#End Region

End Class
