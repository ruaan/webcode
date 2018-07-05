
Partial Class Contact
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Validatethis()

        If lblMsg.Text = "" Then
            SendMail()
        End If

    End Sub
    Private Sub Validatethis()
        lblMsg.Text = ""

        If txtEmail.Text.Contains("@") = False Then
            lblMsg.Text &= "* Valid Email address is required.</br>"
        End If
        If txtPhone.Text = "" Then
            lblMsg.Text &= "* Phone number is required.</br>"
        End If
        If DropDownList1.SelectedValue.Trim = "Select" Then
            lblMsg.Text &= "* Please select a method how we can contact you.</br>"
        End If
    End Sub

    Private Sub SendMail()
        Dim Mailer As New MAILER
        Dim thisaddress As New Gets.GetEmailReceivers
        Dim address As String = thisaddress.GetEmialReceivers("QuestionSubmit")
        Dim sentStatus As String = ""
        sentStatus = Mailer.sendMail("Eco_Hunter", address.Trim, "Eco-Hunter Question", GetMailBody, True)

        If sentStatus = "True" Then
            pnlForm.Visible = False
            pnlSucess.Visible = True
        Else
            lblMsg.Text = sentStatus
        End If

    End Sub
    Private Function GetMailBody() As String
        Dim htmlString As String = ""
        htmlString &= "   <div>"
        htmlString &= "              <div id='masterTopBlock' style='font-family: Calibri; color: #424531;'>"
        htmlString &= "                  <div id='mainTop' style='background-color: #86B24F;'>"
        htmlString &= "                      &nbsp;"
        htmlString &= "                  </div>"
        htmlString &= "                  <div id='divHeader' style='padding-left: 40px; background-color: #3E432F; vertical-align: middle; padding-top: 10px; padding-bottom: 5px;'>"
        htmlString &= "                  </div>"
        htmlString &= "                  <div style='padding-left: 40px;'>"
        htmlString &= "                      <div>"
        htmlString &= "                          <div>&nbsp;</div>"
        htmlString &= "                          <div>The following was received from Eco-Hunter:</div>"
        htmlString &= "                          <div>&nbsp;</div>"
        htmlString &= "                          <div style='border: thin solid #333333; width: 487px'>"
        htmlString &= "                              <div>"
        htmlString &= "                                  <div style='border-width: thin; border-color: #86B24F; padding-top: 5px; padding-right: 20px; padding-left: 5px; border-bottom-style: solid;'>"
        htmlString &= "                                      <div>&nbsp;</div>"
        htmlString &= "                                      <div>&nbsp;Date: <strong>" & Now & "</strong></div>"
        htmlString &= "                                      <div>&nbsp;From: <strong>" & txtContactPerson.Text.Trim & "</strong></div>"
        htmlString &= "                                      <div>&nbsp;</div>"
        htmlString &= "                                  </div>"
        htmlString &= "                              </div>"
        htmlString &= "                              <div style='display: inline-block; vertical-align: top'>"
        htmlString &= "                                  <div style='padding-top: 5px; padding-left: 20px; padding-bottom: 10px; '>"
        htmlString &= "                                      <div style='padding-left: 60px'>Email: <strong>" & txtEmail.Text.Trim & "</strong></div>"
        htmlString &= "                                      <div style='padding-left: 60px'>Tel: <strong>" & txtPhone.Text.Trim & "</strong></div>"
        htmlString &= "                                      <div>&nbsp;</div>"
        htmlString &= "                                      <div>&nbsp;Message:</div>"
        htmlString &= "                                      <div>" & txtMessage.Text.Trim & "</div>"
        htmlString &= "                                  </div>"
        htmlString &= "                              </div>"
        htmlString &= "                          </div>"
        htmlString &= "                      </div>"
        htmlString &= "                  </div>"
        htmlString &= "              </div>"
        htmlString &= "             <div>&nbsp;</div>"
        htmlString &= "              <div style='background-color: #3E432F'>&nbsp;</div>"
        htmlString &= "          </div>"
        Return htmlString
    End Function
End Class
