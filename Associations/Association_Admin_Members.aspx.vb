Imports System.Data
Partial Class Associations_Association_Admin_Members
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            PopulateAssociations()
        End If
    End Sub

    Private Sub PopulateAssociations()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserId", Request.Cookies("UserId").Value)

        Dim str As String = ""
        str &= "  SELECT        tbl_Associations.Association_Id, tbl_Associations.Name"
        str &= "  FROM            tbl_Associations INNER JOIN"
        str &= "                           tbl_Association_v_User ON tbl_Associations.Association_Id = tbl_Association_v_User.Association_Id"
        str &= "  WHERE        (tbl_Association_v_User.UserId = @UserId)"
        str &= "  ORDER BY tbl_Associations.Name"
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

        Try
            DropDownList1.DataSource = ds.Tables(0)
            DropDownList1.DataBind()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PopulateMembers()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Association_Id", DropDownList1.SelectedValue)

        Dim str As String = ""
        str &= " SELECT  tbl_Member.MemberId, tbl_Member.Surname, tbl_Member.FullName, tbl_Member.Initials, tbl_Member.Title, tbl_Member.PreferredName, tbl_Member.IDNo, tbl_Member.PassportNr, tbl_Member.Nationality, "
        str &= "                          tbl_Member.Country, tbl_Member.Gender, tbl_Member.CellNo, tbl_Member.WorkNo, tbl_Member.Email, tbl_Member.Occupation, tbl_Member.Dedicated_Hunter_MemberNo, tbl_Member.Dedicated_Sport_ShooterNo, "
        str &= "                          tbl_Member.MedicalAidScheme, tbl_Member.MedicalAidNo, tbl_Member.Main_Member, tbl_Member.NextKinName, tbl_Member.NextKin_Relationship, tbl_Member.NextKin_CellNo, tbl_Member.NextKin_Email, "
        str &= "                          tbl_Member.Residential_StreetName, tbl_Member.Residential_StreetNo, tbl_Member.Residential_ComplexName, tbl_Member.Residential_ComplexNo, tbl_Member.Residential_Suburb, tbl_Member.Residential_City_Town, "
        str &= "                          tbl_Member.Residential_Province_State, tbl_Member.Residential_Code_Zip, tbl_Member.Work_StreetName, tbl_Member.Work_StreetNo, tbl_Member.Work_ComplexName, tbl_Member.Work_ComplexNo, "
        str &= "                          tbl_Member.Work_Suburb, tbl_Member.Work_City_Town, tbl_Member.Work_Province_State, tbl_Member.Work_Code_Zip, tbl_Member.ReferredByNo, tbl_Member.DateJoined, tbl_Member.MembershipExpire, "
        str &= "                          tbl_Member.HunterType, tbl_Member_Association.MemberNo"
        str &= " FROM            tbl_Member INNER JOIN"
        str &= "                          tbl_Member_Association ON tbl_Member.MemberId = tbl_Member_Association.MemberId"
        str &= " WHERE        (tbl_Member_Association.Association_Id = @Association_Id)"
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

        Try
            GridView2.DataSource = ds.Tables(0)
            GridView2.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub DropDownList1_DataBound(sender As Object, e As EventArgs) Handles DropDownList1.DataBound
        If DropDownList1.Items.Count > 1 Then
            DropDownList1.Items.Add("Select")
            DropDownList1.SelectedValue = "Select"
        Else
            PopulateMembers()
        End If
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        PopulateMembers()
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        populateMemberShearch()
    End Sub
    Private Sub populateMemberShearch()

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Value", txtMemberSearch.Text.Trim & "%")

        Dim str As String = ""
        str &= " SELECT MemberId, Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, Occupation, Dedicated_Hunter_MemberNo, Dedicated_Sport_ShooterNo, "
        str &= "                          MedicalAidScheme, MedicalAidNo, Main_Member, NextKinName, NextKin_Relationship, NextKin_CellNo, NextKin_Email, Residential_StreetName, Residential_StreetNo, Residential_ComplexName, Residential_ComplexNo, "
        str &= "                          Residential_Suburb, Residential_City_Town, Residential_Province_State, Residential_Code_Zip, Work_StreetName, Work_StreetNo, Work_ComplexName, Work_ComplexNo, Work_Suburb, Work_City_Town, "
        str &= "                          Work_Province_State, Work_Code_Zip, ReferredByNo, DateJoined, MembershipExpire, HunterType, Initials + ' ' + FullName + ' ' + Surname AS loadname"
        str &= " FROM            tbl_Member"
        str &= " WHERE        (FullName LIKE @Value) OR"
        str &= "                          (IDNo LIKE @Value) OR"
        str &= "                          (Surname LIKE @Value) OR"
        str &= "                          (CellNo LIKE @Value) OR"
        str &= "                          (Email LIKE @Value)"
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
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try

        Try
            If ds.Tables(0).Rows.Count > 0 Then
                divSelect.Visible = True
                GridView1.DataSource = ds.Tables(0)
                GridView1.DataBind()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
            End If
        Catch ex As Exception
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End Try
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearAddFields()
        divAddDetails.Visible = False
    End Sub
    Private Sub ClearAddFields()
        lblAddName.Text = ""
        lblEcohunterId.Text = ""
        txtAssociationNo.Text = ""
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        ClearAddFields()
        divAddDetails.Visible = True
        lblEcohunterId.Text = GridView1.Rows(e.CommandArgument).Cells(1).Text.Trim
        lblAddName.Text = GridView1.Rows(e.CommandArgument).Cells(4).Text.Trim & " " & GridView1.Rows(e.CommandArgument).Cells(5).Text.Trim & " " & GridView1.Rows(e.CommandArgument).Cells(2).Text.Trim
        GridView1.DataSource = Nothing
        GridView1.DataBind()
        divSelect.Visible = False
        divaddSearch.Visible = False
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearAddFields()
        divSelect.Visible = False
        divaddSearch.Visible = True
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddMembership()
    End Sub
    Private Sub AddMembership()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand


        cmd.Parameters.AddWithValue("@MemberId", lblEcohunterId.Text.Trim)
        cmd.Parameters.AddWithValue("@Association_Id", DropDownList1.SelectedValue.Trim)
        cmd.Parameters.AddWithValue("@MemberNo", txtAssociationNo.Text.Trim)


        Dim str As String = ""
        str &= " INSERT INTO tbl_Member_Association "
        str &= " (MemberId, Association_Id, MemberNo)"
        str &= " VALUES"
        str &= " (@MemberId, @Association_Id, @MemberNo)"


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
            PopulateMembers()
            divAddDetails.Visible = False
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
