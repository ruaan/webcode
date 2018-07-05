
Partial Class SetUp_Downloads
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("~/Documents/app-release.apk")
    End Sub
End Class
