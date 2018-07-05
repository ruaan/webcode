Imports System.Data
Partial Class Associations_Member_Report_App
    Inherits System.Web.UI.Page

#Region "Variants"
    Dim memId As String
    Dim AssId As String
#End Region

#Region "Events"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Try
                memId = Request.QueryString("memId").ToString.Trim
                AssId = Request.QueryString("AssId").ToString.Trim
                PopulateMember()
                PopulateGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        For Each myRow As GridViewRow In GridView1.Rows
            myRow.Cells(6).Text = GetSpecies(myRow.Cells(0).Text.Trim)
            myRow.Cells(9).Text = GetMeetingsAttended()
        Next
    End Sub
#End Region

#Region "Methods"
    Private Sub PopulateMember()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@memId", memId.Trim)
        cmd.Parameters.AddWithValue("@AssId", AssId.Trim)

        Dim str As String = ""
        str &= " SELECT tbl_Member_Association.MemberId, tbl_Member.FullName + ' ' + tbl_Member.Surname AS Name, tbl_Member_Association.MemberNo, tbl_Associations.Name AS Expr1, tbl_Associations.ProfilePicPath,  "
        str &= " tbl_Associations.ShortDescription, tbl_Associations.LongDescription "
        str &= " FROM tbl_Member_Association INNER JOIN "
        str &= " tbl_Member On tbl_Member_Association.MemberId = tbl_Member.MemberId INNER JOIN "
        str &= " tbl_Associations ON tbl_Member_Association.Association_Id = tbl_Associations.Association_Id "
        str &= " WHERE (tbl_Member_Association.MemberId = @memId) And (tbl_Member_Association.Association_Id = @AssId) "

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
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim = "" Then
                    Image1.ImageUrl = "../Images/Associations/ProfilePlaceHolder.jpg"
                Else
                    Image1.ImageUrl = "../Images/Associations/" & ds.Tables(0).Rows(0).Item("ProfilePicPath").ToString.Trim
                End If
                lblAssName.Text = ds.Tables(0).Rows(0).Item("Expr1").ToString.Trim
                lblMemberName.Text = ds.Tables(0).Rows(0).Item("Name").ToString.Trim
                lblMemberNo.Text = ds.Tables(0).Rows(0).Item("MemberNo").ToString.Trim
                lblHunterNo.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PopulateGrid()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", memId.Trim)
        cmd.Parameters.AddWithValue("@AssId", AssId.Trim)

        Dim str As String = ""
        str &= " SELECT DISTINCT  "
        str &= " tbl_Member_Association.MemberId, tbl_Farm.FarmName, tbl_Hunts.Status, tbl_Farm.OwnerName + ' ' + tbl_Farm.OwnerSurname AS OwnerName, tbl_Farm.CellNo, tbl_Hunts.Date_From,  "
        str &= " tbl_Hunts.Date_To, '' AS Weapon, '' AS Calibre, '' AS Species, '' AS MeetingsAttended, tbl_Hunts_Members.Hunts_Id "
        str &= " FROM tbl_Hunts_Members RIGHT OUTER JOIN "
        str &= " tbl_Member_Association ON tbl_Hunts_Members.MemberId = tbl_Member_Association.MemberId LEFT OUTER JOIN "
        str &= " tbl_Hunts On tbl_Hunts_Members.Hunts_Id = tbl_Hunts.HuntId LEFT OUTER JOIN "
        str &= " tbl_Farm ON tbl_Hunts.FarmId = tbl_Farm.id "
        str &= " WHERE (tbl_Member_Association.Association_Id = @AssId) And (tbl_Member_Association.MemberId = @MemberId) And (tbl_Hunts_Members.Status = '5') "

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
            lblMsg.Text &= ex.Message & "<br>"
        Finally
            myconnection.Close()
        End Try

        Try
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Functions"
    Public Function GetSpecies(ByVal huntId As String) As String
        Dim sqlStr As String = ""
        Dim myConnection As New SqlClient.SqlConnection()
        Dim cmd As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim tbl As New DataTable
        Dim animalList As String = ""

        myConnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.CommandType = CommandType.Text
        cmd.Connection = myConnection
        cmd.Parameters.AddWithValue("@huntId", huntId.Trim)

        sqlStr &= " SELECT DISTINCT tbl_Animals.Name, tbl_Hunts_Species.HuntsId "
        sqlStr &= " FROM tbl_Animals RIGHT OUTER JOIN "
        sqlStr &= " tbl_Hunts_Species ON tbl_Animals.id = tbl_Hunts_Species.Farm_Animal_Id RIGHT OUTER JOIN "
        sqlStr &= " tbl_Hunts_Members On tbl_Hunts_Species.HuntsId = tbl_Hunts_Members.Hunts_Id RIGHT OUTER JOIN "
        sqlStr &= " tbl_Member_Association ON tbl_Hunts_Members.MemberId = tbl_Member_Association.MemberId "
        sqlStr &= " WHERE (tbl_Hunts_Species.HuntsId = @huntId) "

        cmd.CommandText = sqlStr
        Try
            myConnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tblEmailClient")
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    animalList &= ds.Tables(0).Rows(i).Item(0).ToString.Trim & ", "
                Next
                animalList = Left(animalList.Trim, animalList.Length - 2)
            Else
                animalList &= ""
            End If
        Catch ex As Exception
            animalList &= ""
        Finally
            myConnection.Close()
        End Try
        Return animalList
    End Function
    Public Function GetMeetingsAttended() As String
        Dim sqlStr As String = ""
        Dim myConnection As New SqlClient.SqlConnection()
        Dim cmd As New SqlClient.SqlCommand
        Dim da As New SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim tbl As New DataTable
        Dim eventList As String = ""

        myConnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        cmd.CommandType = CommandType.Text
        cmd.Connection = myConnection
        cmd.Parameters.AddWithValue("@MemberId", memId.Trim)

        sqlStr &= " SELECT tbl_Association_Events.Event_Name "
        sqlStr &= " FROM tbl_Association_Event_Attending INNER JOIN "
        sqlStr &= " tbl_Association_Events ON tbl_Association_Event_Attending.Event_Id = tbl_Association_Events.event_id "
        sqlStr &= " WHERE (tbl_Association_Event_Attending.MemberId = @MemberId) And (tbl_Association_Event_Attending.Attend = 'Attended') "

        cmd.CommandText = sqlStr
        Try
            myConnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "tblEmailClient")
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    eventList &= ds.Tables(0).Rows(i).Item(0).ToString.Trim & ", "
                Next
                eventList = Left(eventList.Trim, eventList.Length - 2)
            Else
                eventList &= ""
            End If
        Catch ex As Exception
            eventList &= ""
        Finally
            myConnection.Close()
        End Try
        Return eventList
    End Function
#End Region
End Class
