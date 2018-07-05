Imports System.Data
Partial Class farm_reserve1
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim SavePath As String = ""
        Dim pathname As String = "Farms\Images\FarmProfiles\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot
        Try
            HiddenFarmId.Value = Request.QueryString("id")
            If System.IO.File.Exists(SavePath & HiddenFarmId.Value.Trim & "Main.jpg") Then
                Image1.ImageUrl = "~/Farms/Images/FarmProfiles/" & HiddenFarmId.Value.Trim & "Main.jpg"
            Else
                Image1.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
            End If
            GetinitialData()
            GetRates()
        Catch ex As Exception

        End Try

    End Sub

    Private Function GetinitialData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        id, FarmName, Country, Province, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, UseBookingSystem, BookingContactName, "
        str &= "                          BookingContactSurname, BookingEmail, BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, "
        str &= "                          Owner_Res_StreetName, Owner_Res_StreetNo, Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status"
        str &= " FROM            tbl_Farm"
        str &= " WHERE        (id = @id)"


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


        lblHeading.Text = ds.Tables(0).Rows(0).Item("FarmName").ToString.Trim
        dsInfo = ds

        Return ds
    End Function
    Private Sub GetRates()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT  FarmId, HunterPrice, GuestPrice"
        str &= " FROM  tbl_Farm_Pricing"
        str &= " where FarmId = @FarmId"


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
            lblHunterRate.Text = CDbl(ds.Tables(0).Rows(0).Item("HunterPrice").ToString).ToString("###,##0.00")
            lblHunterPrice.Text = CDbl(ds.Tables(0).Rows(0).Item("HunterPrice").ToString).ToString("###,##0.00")
            HiddenFieldHunterPrice.Value = ds.Tables(0).Rows(0).Item("HunterPrice").ToString
            lblGuestPrice.Text = CDbl(ds.Tables(0).Rows(0).Item("GuestPrice").ToString).ToString("###,##0.00")
            lblGuestRate.Text = CDbl(ds.Tables(0).Rows(0).Item("GuestPrice").ToString).ToString("###,##0.00")
            HiddenFieldGuestPrice.Value = ds.Tables(0).Rows(0).Item("GuestPrice").ToString
        Catch ex As Exception

        End Try


    End Sub
    Protected Sub btnReserve_Click(sender As Object, e As EventArgs) Handles btnReserve.Click
        lblValidate.Text = ""
        ReservValidate()
        If lblValidate.Text = "" Then
            Response.Redirect("ReserveApp.aspx?Frid=" & HiddenFarmId.Value & "&Dfrm=" & txtDateFrom.Text.Trim & "&Dto=" & txtDateTo.Text.Trim & "&hnt=" & txtHunterPax.Text & "&gst=" & txtGuestPax.Text & "&ac=" & HiddenFieldAccomTotal.Value & "&ad=" & HiddenFieldAdditionalTotal.Value)
        End If
    End Sub
    Private Sub ReservValidate()
        If txtDateFrom.Text = "" Then
            lblValidate.Text = "Please enter Arrival Date"
        End If
        If txtDateTo.Text = "" Then
            lblValidate.Text &= "</br>Please enter Departure Date"
        End If
        If IsNumeric(txtHunterPax.Text) = False Then
            lblValidate.Text &= "</br>Please enter valid Qty of Hunters (only numerics)"
        End If
    End Sub
End Class
