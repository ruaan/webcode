Imports System.Data
Partial Class Members_CurrentHuntApp
    Inherits System.Web.UI.Page
    Dim MemberId As String = ""
    Dim HuntId As String = ""
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MemberId = Request.Cookies("memberid").Value

        Catch ex As Exception

        End Try
        HuntId = Request.QueryString("h")
        HiddenFieldFarmId.Value = HuntId
    End Sub


    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("Hunts_Animals_Shot.aspx?h=" & HuntId)
    End Sub
    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("tracking.aspx")
    End Sub
    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("Pinpoint.aspx")
    End Sub
    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        Response.Redirect("Photo.aspx")
    End Sub
End Class
