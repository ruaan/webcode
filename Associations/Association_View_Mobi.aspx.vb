Imports System.Data
Partial Class Associations_Association_View_Mobi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        thisFrame.Src = "http://www.ecohunter-app.co.za/Association_View_App.aspx?member=" & Request.Cookies("memberid").Value
    End Sub
End Class

