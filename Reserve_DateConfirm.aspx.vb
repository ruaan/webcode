Imports System.Data
Imports System.Net.Mail
Imports System.IO
Partial Class Reserve_DateConfirm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim HuntId As String = Request.QueryString("h")
        Dim Approve As String = Request.QueryString("a")
        lblHuntId.Text = HuntId
        Dim CompleteSatus As String = IsCompleted(HuntId)

        If CompleteSatus = "Reserved" Then
            If Approve = "T" Then
                pnlAccept.Visible = True
                pnlAlreadyCompleted.Visible = False
                pnlDecline.Visible = False
                UpdateStatus(HuntId, "2")
                Dim Message As String = ConfirmEmailBody(HuntId)
                sendmail("Eco_Hunter Date Confirmation", "gawie@naudeonline.co.za", "Your Hunting Trip dates ghas been confirmed!.", Message, "True")
            Else
                pnlAccept.Visible = False
                pnlAlreadyCompleted.Visible = False
                pnlDecline.Visible = True
            End If
        Else
            pnlAlreadyCompleted.Visible = True
            lblResult.Text = CompleteSatus
            pnlDecline.Visible = False
            pnlAccept.Visible = False
        End If

    End Sub
    Private Function IsCompleted(huntId As String) As String
        Dim isComplete As String = "False"

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", huntId.Trim)

        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.Status, tbl_Hunts_Status.Description"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Hunts_Status ON tbl_Hunts.Status = tbl_Hunts_Status.StatusId"
        str &= " WHERE        (tbl_Hunts.HuntId = @HuntId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")
        Catch ex As Exception
            Label1.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
        Try
            isComplete = ds.Tables(0).Rows(0).Item("Description").ToString.Trim
        Catch ex As Exception
            Label1.Text &= ex.Message
        End Try


        Return isComplete
    End Function
    Private Sub UpdateStatus(HuntId As String, Status As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)
        cmd.Parameters.AddWithValue("@Status", Status.Trim)

        Dim str As String = ""
        str &= " UPDATE tbl_Hunts"
        str &= " SET Status = @Status"
        str &= " WHERE (tbl_Hunts.HuntId = @HuntId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try


    End Sub

    Private Function sendmail(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean) As String
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress("gawie@naudeonline.co.za", "Eco_Hunter Date Confirmation")
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                If toAddresses(i).Length > 1 Then
                    Dim objMail_toaddress As New MailAddress(toAddresses(i))
                    objMail.To.Add(objMail_toaddress)
                End If
            Next

            Dim htmlBody As String = "<h1>Picture</h1><br><img src=""cid:logo""/>"

            Dim plaintext As AlternateView = AlternateView.CreateAlternateViewFromString("HTML not activated", Nothing, "text/plain")
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(message, Nothing, "text/html")




            Dim Logo As New LinkedResource(Server.MapPath("~/Images/Logos/eco-hunter-log-small.png"), System.Net.Mime.MediaTypeNames.Image.Jpeg)
            Logo.ContentId = "logo"
            htmlView.LinkedResources.Add(Logo)

            objMail.AlternateViews.Add(plaintext)
            objMail.AlternateViews.Add(htmlView)

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress

            objMail.Body = True
            objMail.Priority = MailPriority.High
            smtpClient.Host = "mail.naudeonline.co.za"
            smtpClient.Credentials = New Net.NetworkCredential("gawie@naudeonline.co.za", "Gawie.123H#")
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)

            Catch exc As Exception

                Return False
                Exit Function
            End Try
        Catch ex As Exception

            Return False
            Exit Function
        End Try
        Return True

    End Function
    Private Function generatHTMLEmail(ByVal requestString As String, ByVal emailString As String) As String
        Dim html As String
        html = ""
        html &= "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
        html &= "<html xmlns='http://www.w3.org/1999/xhtml'>"
        html &= "<head>"
        html &= "<meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1' />"
        html &= "<title>" & requestString & "</title>"

        html &= "</head>"
        html &= "<body>"
        html &= "<form id='form1' name='form1' method='post' action='' style='font-family: Calibri; background-color: #B7B9BA'>"

        html &= emailString

        html &= "</form>"
        html &= "</body>"
        html &= "</html>"
        Return html
    End Function




    Private Function ConfirmEmailBody(HuntId As String) As String
        Dim htmlString As String = ""

        Dim thisHunt As New DataSet
        thisHunt = GetHunt(HuntId)


        htmlString &= " <div>"
        htmlString &= "             <div id='masterTopBlock' style='font-family: Calibri; color: #424531;'>"
        htmlString &= "                 <div id='mainTop' style='background-color: #86B24F;'>"
        htmlString &= "                     &nbsp;"
        htmlString &= "                 </div>"
        htmlString &= "                 <div id='divHeader' style='padding-left: 40px; background-color: #3E432F; vertical-align: middle; padding-top: 10px; padding-bottom: 5px;'>"
        htmlString &= "                     <div style='display: inline-block'>"
        htmlString &= "                         <img alt='' src=""cid:logo"" class='logo-style' />"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div style='padding-left: 40px;'>"
        htmlString &= "                     <div>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= "                         <div>We are pleased to confirm that the following Hunting trip you have reserved has been confirmed!</div>"
        htmlString &= "                         <div>Please follow the link below to finalise the reservation by paying a deposit of R" & CDbl(thisHunt.Tables(0).Rows(0).Item("DepositValue").ToString.Trim).ToString("###,##0.00") & "</div>"
        htmlString &= "                         <div>Deposit must be received before " & CDate(thisHunt.Tables(0).Rows(0).Item("DepositDue").ToString.Trim).ToLongDateString & " to secure the booking. The reservation will be canceled automatically if deposit is not received by then.</div>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= "                         <div>Alternatively you can log onto Eco-Hunter and navigate to 'My Hunts' and pay deposit and do alteration to your hunting trip.</div>"
        htmlString &= "                        <div>"
        htmlString &= "                             &nbsp;"
        htmlString &= "                         </div>"
        htmlString &= " <div> Game Farm: <strong>"
        htmlString &= thisHunt.Tables(0).Rows(0).Item("FarmName").ToString.Trim
        htmlString &= "  </strong></div>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= "                         <div style='border: thin solid #333333; width: 487px'>"
        htmlString &= "                             <div>"
        htmlString &= "                                 <div style='border-width: thin; border-color: #86B24F; padding-top: 5px; padding-right: 20px; padding-left: 5px; border-bottom-style: solid;'>"
        htmlString &= "                                     <div>&nbsp;</div>"
        htmlString &= "                                     <div>&nbsp;Date From: <strong>"
        htmlString &= CDate(thisHunt.Tables(0).Rows(0).Item("Date_From").ToString.Trim).ToLongDateString
        htmlString &= "</strong></div>"
        htmlString &= "                                     <div>&nbsp;Date To: <strong>"
        htmlString &= CDate(thisHunt.Tables(0).Rows(0).Item("Date_To").ToString.Trim).ToLongDateString
        htmlString &= "</strong></div>"
        htmlString &= "                                     <div>&nbsp;</div>"
        htmlString &= "                                 </div>"
        htmlString &= "                             </div>"
        htmlString &= "                             <div style='display: inline-block; vertical-align: top'>"
        htmlString &= "                                 <div style='padding-top: 5px; padding-left: 20px; padding-bottom: 10px; '>"
        htmlString &= "                                     <div>&nbsp;Hunters: <strong>"
        htmlString &= thisHunt.Tables(0).Rows(0).Item("HunterPax").ToString.Trim & " Hunters"
        htmlString &= "  </strong></div>"

        htmlString &= "                                     <div>&nbsp;</div>"
        htmlString &= "                                     <div>&nbsp;Guests: <strong>"
        htmlString &= thisHunt.Tables(0).Rows(0).Item("GuestPax").ToString.Trim & " Guests"
        htmlString &= "  </strong></div>"
        htmlString &= "                                 </div>"
        htmlString &= "                             </div>"
        htmlString &= "                         </div>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= "                         <div>"
        htmlString &= "                             <div>"
        htmlString &= "                                 <div style='background-color: #666666; color: #FFFFFF; width: 192px;'>&nbsp;Total Cost: &nbsp;"
        htmlString &= thisHunt.Tables(0).Rows(0).Item("TotalDue").ToString.Trim
        htmlString &= "  </div>"
        htmlString &= "                                 <div>"
        htmlString &= "                                     &nbsp;"
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div>"
        htmlString &= "                                    &nbsp; Accommodation Cost: &nbsp;"
        htmlString &= thisHunt.Tables(0).Rows(0).Item("AccommValue").ToString.Trim
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div>&nbsp;</div>"
        htmlString &= "                                 <div style='background-color: #999999; width: 192px'>"
        htmlString &= "                                    &nbsp; Additional Items:&nbsp; "
        htmlString &= thisHunt.Tables(0).Rows(0).Item("AdditionalValue").ToString.Trim
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div style='width: 192px'>"
        htmlString &= "                                    &nbsp; Trackers: &nbsp;"
        htmlString &= thisHunt.Tables(0).Rows(0).Item("AdditionalValue").ToString.Trim
        htmlString &= "                                 </div>"
        htmlString &= "                                 <div style='border-top-style: solid; border-width: thin; border-color: #666666'>"
        htmlString &= "                                     &nbsp;"
        htmlString &= "                                 </div>"
        htmlString &= "                             </div>"
        htmlString &= "                         </div>"
        htmlString &= "                         <div>"
        htmlString &= "                             &nbsp;"
        htmlString &= "                         </div>"
        htmlString &= " <div> "
        htmlString &= "                             &nbsp;"
        htmlString &= "                         </div>"
        htmlString &= "                         <div>"
        htmlString &= "                             <table class='auto-style6'>"
        htmlString &= "                                 <tr>"
        htmlString &= "                                     <td class='auto-style1'>&nbsp;</td>"
        htmlString &= "                                     <td class='auto-style4'>&nbsp;</td>"
        htmlString &= "                                 </tr>"
        htmlString &= "                                 <tr>"
        htmlString &= "                                     <td align='center' class='auto-style2' style='background-color: #86B24F'><a href=""http://197.101.38.171/Payment/PaymentConfirmation.aspx?h=" & HuntId & """ Style ='cursor: pointer'>Confirm Reservation</a></td>"
        htmlString &= "                                     <td class='auto-style5'></td>"
        htmlString &= "                                 </tr>"
        htmlString &= "                                 <tr>"
        htmlString &= "                                     <td class='auto-style1'>&nbsp;</td>"
        htmlString &= "                                     <td class='auto-style4'>&nbsp;</td>"
        htmlString &= "                                 </tr>"
        htmlString &= "                             </table>"
        htmlString &= "                             &nbsp;&nbsp;"
        htmlString &= "                         </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"
        htmlString &= "             </div>"
        htmlString &= "             <div>"
        htmlString &= "                 &nbsp;"
        htmlString &= "             </div>"
        htmlString &= "             <div style='background-color: #3E432F'>&nbsp;</div>"
        htmlString &= "         </div>"


        Return htmlString
    End Function
    Private Function GetHunt(HuntId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@HuntId", HuntId.Trim)

        Dim str As String = ""
        str &= " SELECT        tbl_Hunts.HuntId, tbl_Hunts.FarmId, tbl_Hunts.Main_Member_Id, tbl_Hunts.Date_From, tbl_Hunts.Date_To, tbl_Hunts.HunterPax, tbl_Hunts.GuestPax, tbl_Hunts.TotalDue, tbl_Hunts.DepositValue, tbl_Hunts.DepositDue, "
        str &= "                          tbl_Hunts.FinalPayment, tbl_Hunts.AccommValue, tbl_Hunts.AdditionalValue, tbl_Hunts.SpeciesValue, tbl_Hunts.ExtraValue, tbl_Hunts.CountryId, tbl_Hunts.UniqueName, tbl_Hunts.FlightId, tbl_Hunts.CarId, tbl_Hunts.Status, "
        str &= "                          tbl_Hunts.PercDepositPaid, tbl_Farm.FarmName, tbl_Farm.Email, tbl_Farm.BookingEmail"
        str &= " FROM            tbl_Hunts INNER JOIN"
        str &= "                          tbl_Farm ON tbl_Hunts.FarmId = tbl_Farm.id"
        str &= " WHERE        (tbl_Hunts.HuntId = @HuntId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        Return ds

    End Function
    Protected Sub btnDeclineSubmit_Click(sender As Object, e As EventArgs) Handles btnDeclineSubmit.Click
        UpdateStatus(lblHuntId.Text.Trim, "3")
    End Sub
End Class
