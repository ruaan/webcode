
Partial Class Members_PaymentConfirmation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblHuntId.Text = Request.QueryString("h")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("passthrough.aspx?h=" & Request.QueryString("h"))
    End Sub

End Class
