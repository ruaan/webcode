﻿Imports System.Data
Partial Class Outfitters_Mobi
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        thisFrame.Src = "http://www.ecohunter-app.co.za/Outfitters_app.aspx?member=" & Request.Cookies("memberid").Value
    End Sub

End Class
