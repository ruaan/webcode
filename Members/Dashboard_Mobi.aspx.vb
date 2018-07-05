
Partial Class Members_Dashboard_Mobi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        thisFrame.Src = "http://www.ecohunter-app.co.za/Members/Dashboard_App.aspx?member=" & Request.Cookies("memberid").Value
    End Sub
End Class
