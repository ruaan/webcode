Imports System.Data
Partial Class Animals_Mobi
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        thisFrame.Src = "http://www.ecohunter-app.co.za/Animals_App.aspx?member=" & Request.Cookies("memberid").Value
    End Sub


End Class
