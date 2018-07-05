Imports System.Data
Partial Class Approval_MemberApproval
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        PopulateList()
    End Sub
    Private Sub PopulateList()
        lblMsg.Text = ""
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        Dim str As String = ""
        str &= " SELECT Pre_Id, Surname, PreferredName, CASE WHEN IDNo = '' THEN PassportNr ELSE IDNo END AS IDNo, DateApplied"
        str &= " FROM            tbl_Member_PreReg"
        str &= " WHERE        (Status = '1')"
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

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Approve(PreReg_Id As String)
        Dim thisMemberId As String = ""
        thisMemberId = Insert(PreReg_Id)
        If lblMsg.Text = "" Then
            Update_PreReg_Status(PreReg_Id, "2")
        End If
        If lblMsg.Text = "" Then
            '////SEND CONFIRMATION MAIL
        End If
        PopulateList()
    End Sub
    Private Function Insert(PreReg_Id As String) As String
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
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "view" Then
            PopulateIndividual(GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim)
        ElseIf e.CommandName = "approve" Then
            Approve(GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim)
        ElseIf e.CommandName = "decline" Then

        End If
    End Sub
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
    Private Sub PopulateIndividual(PreReg_Id As String)
        lblMsg.Text = ""
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Pre_Id", PreReg_Id)

        Dim str As String = ""
        str &= " SELECT        TOP (200) tbl_Member_PreReg.Pre_Id, tbl_Member_PreReg.Surname, tbl_Member_PreReg.FullName, tbl_Member_PreReg.Initials, tbl_Member_PreReg.Title, tbl_Member_PreReg.PreferredName, tbl_Member_PreReg.IDNo, "
        str &= "                          tbl_Member_PreReg.PassportNr, tbl_Member_PreReg.Nationality, tbl_Member_PreReg.Country, tbl_Member_PreReg.Gender, tbl_Member_PreReg.CellNo, tbl_Member_PreReg.WorkNo, tbl_Member_PreReg.Email, "
        str &= "                          tbl_Member_PreReg.ReferredByNo, tbl_Member_PreReg.Status, tbl_Member_PreReg.DateApplied, tbl_Member.PreferredName + ' ' + tbl_Member.Surname AS ReferredName"
        str &= " FROM            tbl_Member_PreReg LEFT OUTER JOIN"
        str &= "                          tbl_Member ON tbl_Member_PreReg.ReferredByNo = tbl_Member.MemberId"
        str &= " WHERE  (Pre_Id = @Pre_Id)"
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


        If ds.Tables(0).Rows.Count > 0 Then

            divDetails.Visible = True
            lblPreRegId.Text = ds.Tables(0).Rows(0).Item("Pre_Id").ToString.Trim
            lblDateApplied.Text = CDate(ds.Tables(0).Rows(0).Item("DateApplied").ToString.Trim).ToString("dd/MM/yyyy HH:mm")
            lblTitle.Text = ds.Tables(0).Rows(0).Item("Title").ToString.Trim
            lblSurname.Text = ds.Tables(0).Rows(0).Item("Surname").ToString.Trim
            LblPreferredName.Text = ds.Tables(0).Rows(0).Item("PreferredName").ToString.Trim
            lblGender.Text = ds.Tables(0).Rows(0).Item("Gender").ToString.Trim
            lblCountry.Text = ds.Tables(0).Rows(0).Item("Country").ToString.Trim
            lblIdNo.Text = ds.Tables(0).Rows(0).Item("IDNo").ToString.Trim
            lblEmail.Text = ds.Tables(0).Rows(0).Item("Email").ToString.Trim
            lblCell.Text = ds.Tables(0).Rows(0).Item("CellNo").ToString.Trim
            lblInitials.Text = ds.Tables(0).Rows(0).Item("Initials").ToString.Trim
            lblFullNames.Text = ds.Tables(0).Rows(0).Item("FullName").ToString.Trim
            lblNationality.Text = ds.Tables(0).Rows(0).Item("Nationality").ToString.Trim
            lblPassport.Text = ds.Tables(0).Rows(0).Item("PassportNr").ToString.Trim
            If lblPassport.Text = "" Then
                lblPassport.Text = "not supplied"
            End If
            If lblIdNo.Text = "" Then
                lblIdNo.Text = "not supplied"
            End If
            lblWorkTel.Text = ds.Tables(0).Rows(0).Item("WorkNo").ToString.Trim
            If lblWorkTel.Text = "" Then
                lblWorkTel.Text = "not supplied"
            End If
            lblRefBy.Text = ds.Tables(0).Rows(0).Item("ReferredByNo").ToString.Trim
            lblReferName.Text = ds.Tables(0).Rows(0).Item("ReferredName").ToString.Trim
            If lblRefBy.Text = "" Then
                btnViewRefBy.Visible = False
            Else
                btnViewRefBy.Visible = True
            End If
        End If


    End Sub
    Protected Sub btnapprove_Click(sender As Object, e As EventArgs) Handles btnapprove.Click
        lblMsg.Text = ""
        Approve(lblPreRegId.Text.Trim)
        If lblMsg.Text = "" Then
            divDetails.Visible = False
            PopulateList()
        End If
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        divDetails.Visible = False
    End Sub
End Class
