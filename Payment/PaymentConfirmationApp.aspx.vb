
Partial Class Payment_PaymentConfirmationApp
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblHuntId.Text = Request.QueryString("h")
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("passthroughapp.aspx?h=" & Request.QueryString("h"))
    End Sub
End Class
