Imports System.Configuration
Partial Class MasterPageGreenLF
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        showMenu()
    End Sub

    Private Sub showMenu()

        divMenuFarms.Visible = False
        divMenuMember.Visible = False
        divMenuSuper.Visible = False
        divMenunotLoggedIn.Visible = False
        divMenuAss.Visible = False
        divMenuOutfitters.Visible = False
        Try


            Select Case Request.Cookies("UserType").Value.Trim
                Case = "Farm Super"
                    divMenuFarms.Visible = True
                Case = "Super Admin"
                    divMenuSuper.Visible = True
                Case = "Member"
                    divMenuMember.Visible = True
                Case = "Association"
                    divMenuAss.Visible = True
                Case = "Outfitter"
                    divMenuOutfitters.Visible = True
                Case Else
                    divMenunotLoggedIn.Visible = True
                    lblLogin.Text = "LOG IN"
            End Select
        Catch ex As Exception
            divMenunotLoggedIn.Visible = True
        End Try


    End Sub

End Class

