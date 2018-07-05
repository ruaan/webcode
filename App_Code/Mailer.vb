Imports System.Net.Mail
Imports System.IO
Imports System.Data
Imports Microsoft.VisualBasic

Public Class MAILER
    Const SHOWHEADERSONLY As Boolean = False
#Region "Variables"
    Dim sClip, sSubject, sFrom, sDate, sTo, sCc, sMID As String
    Dim mailSettings(2) As String 'server, user, password
#End Region
#Region "Settings"
    Private Sub getSettings()
        Dim sqlStr As String
        Dim myConnection As New SqlClient.SqlConnection
        Dim cmd As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        sqlStr = "SELECT MailServer, MailUser, MailPassword FROM tblInternal_Settings"
        myConnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        cmd.CommandText = sqlStr
        cmd.CommandType = CommandType.Text
        cmd.Connection = myConnection
        Try
            myConnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tblHo")
            Dim count As Integer = ds.Tables(0).Rows.Count
            If count = 1 Then
                Try
                    mailSettings(0) = ds.Tables(0).Rows(0).Item(0).ToString.Trim
                    mailSettings(1) = ds.Tables(0).Rows(0).Item(1).ToString.Trim
                    mailSettings(2) = ds.Tables(0).Rows(0).Item(2).ToString.Trim
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
        Finally
            myConnection.Close()
        End Try
    End Sub
#End Region
#Region "SMTP"
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
        html &= "<form id='form1' name='form1' method='post' action=''>"
        html &= "<p>"
        html &= emailString
        html &= "</p>"
        html &= "</form>"
        html &= "</body>"
        html &= "</html>"
        Return html
    End Function

    Public Function sendMail(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
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

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                'sendMail("ERROR", "gawie@naudeonline.co.za;", subject, exc.Message.ToString.Trim, False)
                Return False
                Exit Function
            End Try
        Catch ex As Exception
            'sendMail("ERROR", "gawie@naudeonline.co.za;", subject, ex.Message.ToString.Trim, False)
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function sendMailCC(ByVal fromname As String, ByVal toMail As String, ByVal toCC As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            Dim ccAddresses() As String = toCC.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            If ccAddresses.Length > 1 And ccAddresses(UBound(ccAddresses)) = Nothing Then
                Array.Resize(ccAddresses, UBound(ccAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim counter As Integer = UBound(ccAddresses)
            Dim i As Integer
            For i = 0 To count
                If toAddresses(i).Length > 1 Then
                    Dim objMail_toaddress As New MailAddress(toAddresses(i))
                    objMail.To.Add(objMail_toaddress)
                End If
            Next
            For i = 0 To counter
                If ccAddresses(i).Length > 1 Then
                    Dim objMail_ccaddress As New MailAddress(ccAddresses(i))
                    objMail.CC.Add(objMail_ccaddress)
                End If
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                'sendMail("ERROR", "stephen@rupane.co.za;", subject, exc.Message.ToString.Trim, False)
                Return False
                Exit Function
            End Try
        Catch ex As Exception
            'sendMail("ERROR", "stephen@rupane.co.za;", subject, ex.Message.ToString.Trim, False)
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function sendMailAttachment(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment As String) As String
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Dim wtf As String = ""
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            wtf = "after fix address"
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            wtf = "after add address"
            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment))
            wtf = "after add attachment"
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            smtpClient.Timeout = Int32.MaxValue

            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return "Mail Send:" & exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return wtf & ": " & ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function

    Public Function sendMailAttachmentFromString(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachmentString As String) As String
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Dim wtf As String = ""
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            wtf = "after fix address"
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            wtf = "after add address"
            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)

            Dim YSOD As Attachment = Attachment.CreateAttachmentFromString(attachmentString, "YSOD.htm")
            objMail.Attachments.Add(YSOD)
            wtf = "after add attachment"
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            smtpClient.Timeout = Int32.MaxValue

            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return "Mail Send:" & exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return wtf & ": " & ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function


    Public Function sendMailAttachment2(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message
            Exit Function
        End Try
        Return True
    End Function
    Public Function sendMailAttachment3(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function
    Public Function sendMailAttachment4(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function
    Public Function sendMailAttachment5(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String, ByVal attachment5 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            objMail.Attachments.Add(New Attachment(attachment5))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function
    Public Function sendMailAttachment6(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String, ByVal attachment5 As String, ByVal attachment6 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            objMail.Attachments.Add(New Attachment(attachment5))
            objMail.Attachments.Add(New Attachment(attachment6))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function
    Public Function sendMailAttachment7(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String, ByVal attachment5 As String, ByVal attachment6 As String, ByVal attachment7 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            objMail.Attachments.Add(New Attachment(attachment5))
            objMail.Attachments.Add(New Attachment(attachment6))
            objMail.Attachments.Add(New Attachment(attachment7))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function

    Public Function sendMailAttachment8(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String, ByVal attachment5 As String, ByVal attachment6 As String, ByVal attachment7 As String, ByVal attachment8 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            objMail.Attachments.Add(New Attachment(attachment5))
            objMail.Attachments.Add(New Attachment(attachment6))
            objMail.Attachments.Add(New Attachment(attachment7))
            objMail.Attachments.Add(New Attachment(attachment8))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function

    Public Function sendMailAttachment9(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String, ByVal attachment5 As String, ByVal attachment6 As String, ByVal attachment7 As String, ByVal attachment8 As String, ByVal attachment9 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            objMail.Attachments.Add(New Attachment(attachment5))
            objMail.Attachments.Add(New Attachment(attachment6))
            objMail.Attachments.Add(New Attachment(attachment7))
            objMail.Attachments.Add(New Attachment(attachment8))
            objMail.Attachments.Add(New Attachment(attachment9))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function
    Public Function sendMailAttachment10(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal message As String, ByVal htmlMail As Boolean, ByVal attachment1 As String, ByVal attachment2 As String, ByVal attachment3 As String, ByVal attachment4 As String, ByVal attachment5 As String, ByVal attachment6 As String, ByVal attachment7 As String, ByVal attachment8 As String, ByVal attachment9 As String, ByVal attachment10 As String) As Boolean
        Dim mailBody As String = ""
        If htmlMail = True Then
            mailBody = generatHTMLEmail(subject, message)
        Else
            mailBody = message
        End If
        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
            Dim toAddresses() As String = toMail.Split(";")
            If toAddresses.Length > 1 And toAddresses(UBound(toAddresses)) = Nothing Then
                Array.Resize(toAddresses, UBound(toAddresses))
            End If
            Dim count As Integer = UBound(toAddresses)
            Dim i As Integer
            For i = 0 To count
                Dim objMail_toaddress As New MailAddress(toAddresses(i))
                objMail.To.Add(objMail_toaddress)
            Next

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail
            objMail.Body = mailBody
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            objMail.Attachments.Add(New Attachment(attachment1))
            objMail.Attachments.Add(New Attachment(attachment2))
            objMail.Attachments.Add(New Attachment(attachment3))
            objMail.Attachments.Add(New Attachment(attachment4))
            objMail.Attachments.Add(New Attachment(attachment5))
            objMail.Attachments.Add(New Attachment(attachment6))
            objMail.Attachments.Add(New Attachment(attachment7))
            objMail.Attachments.Add(New Attachment(attachment8))
            objMail.Attachments.Add(New Attachment(attachment9))
            objMail.Attachments.Add(New Attachment(attachment10))
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                Return exc.Message.ToString
                Exit Function
            End Try
        Catch ex As Exception
            Return ex.Message.ToString
            Exit Function
        End Try
        Return True
    End Function

    Public Sub SystemEmails(ByVal Type As String, ByVal Recipients As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Type", Type.Trim)
        cmd.Parameters.AddWithValue("@Recipients", Recipients.Trim)
        cmd.Parameters.AddWithValue("@Date", Date.Now)
        cmd.Parameters.AddWithValue("@From", "Nulandis")

        Dim ds3 As New DataSet()
        Dim da3 As New SqlClient.SqlDataAdapter()
        Dim tbl3 As New DataTable
        Dim str3 As String = ""
        str3 &= " INSERT INTO tblSystemEmails (Type, Date, Recipients, FromWhere)"
        str3 &= " VALUES (@Type, @Date, @Recipients, @From)"
        Try
            cmd.CommandText = str3
            cmd.CommandType = CommandType.Text
            cmd.Connection = myconnection
            cmd.CommandTimeout = 2000
            myconnection.Open()

            da3.SelectCommand = cmd
            da3.Fill(ds3, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try
    End Sub

    Public Function sendMailEmbeded(ByVal fromname As String, ByVal toMail As String, ByVal subject As String, ByVal thisAlternateView As AlternateView, ByVal htmlMail As Boolean) As Boolean

        Try
            Dim smtpClient As New SmtpClient()
            Dim objMail As New MailMessage()
            Dim objMail_fromaddress As New MailAddress(mailSettings(1), fromname)
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

            Dim obj_BccAddress As New MailAddress("gawie@naudeonline.co.za")
            objMail.Bcc.Add(obj_BccAddress)

            objMail.From = objMail_fromaddress
            objMail.IsBodyHtml = htmlMail

            objMail.AlternateViews.Add(thisAlternateView)
            objMail.Priority = MailPriority.High
            smtpClient.Host = mailSettings(0)
            smtpClient.Credentials = New Net.NetworkCredential(mailSettings(1), mailSettings(2))
            Try
                objMail.Subject = subject
                smtpClient.Send(objMail)
                SystemEmails(subject, toMail)
            Catch exc As Exception
                sendMail("ERROR 1", "gawie@naudeonline.co.za;", subject, exc.Message.ToString.Trim, False)
                Return False
                Exit Function
            End Try
        Catch ex As Exception
            sendMail("ERROR 2", "gawie@naudeonline.co.za;", subject, ex.Message.ToString.Trim, False)
            Return False
            Exit Function
        End Try
        Return True
    End Function

#End Region
#Region "Constructor"
    Public Sub New()
        getSettings()
    End Sub

#End Region

End Class





