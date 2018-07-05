Imports System.Data
Partial Class Member_Pre_Registration
    Inherits System.Web.UI.Page
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        lblSubmitMsg.Text = ""
        ValidateFields()
        Dim Ref As String = ""
        If lblSubmitMsg.Text.Trim = "" Then
            Ref = Insert()
            If lblSubmitMsg.Text.Trim = "" Then
                SendConfirmationMail(Ref)
                pnlConfirm.Visible = True
                lblEmailSentTo.Text = txtEmail.Text.Trim
                pnlPersonalDetails.Visible = False
            End If
        End If
    End Sub
    Private Sub ValidateFields()

        If txtSurname.Text = "" Then
            lblSubmitMsg.Text = "* Surname is required."
            txtSurname.BorderColor = Drawing.Color.Red
        Else
            txtSurname.BorderColor = Nothing
        End If
        If rdbGender.SelectedIndex = -1 Then
            rdbGender.ForeColor = Drawing.Color.Red
            lblSubmitMsg.Text &= "</br>* Indicate gender."
        Else
            rdbGender.ForeColor = Nothing
        End If
        If txtIdNo.Text = "" And txtPassport.Text = "" Then
            txtPassport.BorderColor = Drawing.Color.Red
            txtIdNo.BorderColor = Drawing.Color.Red
            lblSubmitMsg.Text &= "</br>* Id No or Password no is required."
        Else
            txtPassport.BorderColor = Nothing
            txtIdNo.BorderColor = Nothing
        End If
        If txtEmail.Text.Contains("@") Then
            txtEmail.BorderColor = Nothing
        Else
            txtEmail.BorderColor = Drawing.Color.Red
            lblSubmitMsg.Text &= "</br>* Valid Email is required."
        End If
        If txtCell.Text = "" Then
            lblSubmitMsg.Text &= "</br>* Cell number is required."
            txtCell.BorderColor = Drawing.Color.Red
        Else
            txtCell.BorderColor = Nothing
        End If
    End Sub
    Private Function Insert() As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim)
        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim)
        cmd.Parameters.AddWithValue("@Initials", txtInitials.Text.Trim)
        cmd.Parameters.AddWithValue("@Title", cmbTitle.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@PreferredName", txtPreferredName.Text.Trim)
        cmd.Parameters.AddWithValue("@IDNo", txtIdNo.Text.Trim)
        cmd.Parameters.AddWithValue("@PassportNr", txtPassport.Text.Trim)
        cmd.Parameters.AddWithValue("@Nationality", cmbNationality.Text.Trim)
        cmd.Parameters.AddWithValue("@Country", cmbCountry.Text.Trim)
        cmd.Parameters.AddWithValue("@Gender", rdbGender.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@CellNo", txtCell.Text.Trim)
        cmd.Parameters.AddWithValue("@WorkNo", txtWorkTel.Text.Trim)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim)
        cmd.Parameters.AddWithValue("@ReferredByNo", txtReferredBy.Text.Trim)
        cmd.Parameters.AddWithValue("@Status", "1")
        cmd.Parameters.AddWithValue("@DateApplied", Now)

        Dim str As String = ""
        str = " INSERT INTO tbl_Member_PreReg "
        str &= " (Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, ReferredByNo, Status, DateApplied)"
        str &= " VALUES"
        str &= " (@Surname, @FullName, @Initials, @Title, @PreferredName, @IDNo, @PassportNr, @Nationality, @Country, @Gender, @CellNo, @WorkNo, @Email, @ReferredByNo, @Status, @DateApplied)"
        str &= " SELECT SCOPE_IDENTITY()"
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
            lblSubmitMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim Pre_Id As String = ds.Tables(0).Rows(0).Item(0).ToString.Trim
        lblCompleteId.Text = Pre_Id
        Return Pre_Id
    End Function
    Private Sub SendConfirmationMail(Ref As String)
        Dim Mailer As New MAILER
        Dim thisaddress As New Gets.GetEmailReceivers
        Dim address As String = thisaddress.GetEmialReceivers("Farms Pre Reg")
        Mailer.sendMail("Eco_Hunter", address.Trim, "Eco-Hunter Member Application", "This is the confirmation mail", True)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OverrideApprove(lblCompleteId.Text)
    End Sub
    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

    End Sub
    Private Sub OverrideApprove(PreReg_Id As String)
        Dim thisMemberId As String = InsertApproval(PreReg_Id)
        If lblMsg.Text = "" Then
            Update_PreReg_Status(PreReg_Id, "2")
            Response.Redirect("Member_Registration.aspx?id=" & thisMemberId.Trim)
        End If
    End Sub
    Private Function InsertApproval(PreReg_Id As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@PreRegId", PreReg_Id.Trim)


        Dim str As String = ""
        str &= " INSERT INTO tbl_Member"
        str &= "        (Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, ReferredByNo)"
        str &= " OUTPUT Inserted.MemberId"
        str &= " SELECT Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, ReferredByNo"
        str &= " FROM tbl_Member_PreReg"
        str &= " WHERE        (Pre_Id = @PreRegId)"
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
            lblMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try

        Dim Pre_Id As String = ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim
        Return Pre_Id
    End Function
    Private Sub Update_PreReg_Status(PreReg_Id As String, Status As String)
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Status", Status)
        cmd.Parameters.AddWithValue("@Pre_Id", PreReg_Id)

        Dim str As String = ""
        str &= " UPDATE tbl_Member_PreReg"
        str &= " Set Status = @Status"
        str &= " WHERE        (Pre_Id = @Pre_Id)"
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
            lblMsg.Text &= ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
