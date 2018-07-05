Imports System.Data
Partial Class Farms_AddReview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Try
                lblFarmId.Text = Request.QueryString("farmid")
                HiddenFieldmem.Value = Request.Cookies("memberid").Value.Trim
                GetFarmDetails()
                DisplaypreviousReview()
                PlaceHolder1.Controls.Add(New LiteralControl(GetRatingBody))
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub GetFarmDetails()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@farmId", lblFarmId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT id, FarmName "
        str &= " FROM tbl_Farm"
        str &= " WHERE id = @farmId "


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
            lblFarmName.Text = ds.Tables(0).Rows(0).Item("FarmName").ToString.Trim
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetRatingBody() As String
        Dim dsRatingItems As New DataSet
        dsRatingItems = GetRatingTypes()
        Dim count As Integer = dsRatingItems.Tables(0).Rows.Count - 1
        Dim sp As Integer
        Dim htmlString As String = ""
        Dim Rated As String = ""
        For sp = 0 To count
            Rated = GetMembersRating(dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim)
            htmlString &= "             <div>"
            htmlString &= "                 <div>" & dsRatingItems.Tables(0).Rows(sp).Item("RatingType").ToString.Trim & "</div>"
            htmlString &= "                 <div  id='div" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "_1'   onclick=""SaveRating('" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "','1','div" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "_1') ""  "
            If Rated = "1" Then
                htmlString &= "  style='padding: 5px; display:inline-block; text-align:center; border: thin solid #86B24F;'>"
            Else
                htmlString &= "  style='padding: 5px; display:inline-block; text-align:center'>"
            End If
            htmlString &= "                     <div style='align-content:center'>"
            htmlString &= "                         <img alt='' src='../Images/Icons/not-satisfied.png'  /></div>"
            htmlString &= "                 </div>"
            htmlString &= "                 <div  id='div" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "_2'    onclick=""SaveRating('" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "','5','div" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "_2') ""  "
            If Rated = "5" Then
                htmlString &= "  style='padding: 5px; display:inline-block; text-align:center; border: thin solid #86B24F;'>"
            Else
                htmlString &= "  style='padding: 5px; display:inline-block; text-align:center'>"
            End If
            htmlString &= "                     <div>"
            htmlString &= "                         <img alt='' src='../Images/Icons/satisfied.png'  /></div>"
            htmlString &= "                 </div>"
            htmlString &= "                 <div   id='div" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "_3'    onclick=""SaveRating('" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "','9','div" & dsRatingItems.Tables(0).Rows(sp).Item("id").ToString.Trim & "_3') ""  "
            If Rated = "9" Then
                htmlString &= "  style='padding: 5px; display:inline-block; text-align:center; border: thin solid #86B24F;'>"
            Else
                htmlString &= "  style='padding: 5px; display:inline-block; text-align:center'>"
            End If
            htmlString &= "                     <div>"
            htmlString &= "                         <img alt='' src='../Images/Icons/x-satisfied.png'  /></div>"
            htmlString &= "                 </div>"
            htmlString &= "             </div>"
            htmlString &= "              <div>&nbsp;</div>"
        Next
        Return htmlString
    End Function
    Private Function GetMembersRating(RatingId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@RatingType", RatingId)
        cmd.Parameters.AddWithValue("@RatingMember", HiddenFieldmem.Value.Trim)

        Dim str As String = ""
        str &= " SELECT * FROM tbl_Farm_Rating "
        str &= " WHERE FarmId = @FarmId AND  RatingType = @RatingType AND RatingMember = @RatingMember"

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

        Dim Rated As String = ""

        Try
            Rated = ds.Tables(0).Rows(0).Item("Rating").ToString.Trim
        Catch ex As Exception

        End Try
        Return Rated

    End Function
    Private Sub DisplaypreviousReview()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@MemberId", HiddenFieldmem.Value.Trim)

        Dim str As String = ""
        str &= " SELECT * FROM tbl_Farm_Reviews "
        str &= " WHERE FarmId = @FarmId AND  MemberId = @MemberId "

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
            txtReview.Text = ds.Tables(0).Rows(0).Item("Review").ToString.Trim
        Catch ex As Exception

        End Try

    End Sub
    Private Function GetRatingTypes() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@farmId", lblFarmId.Text.Trim)

        Dim str As String = ""
        str &= " SELECT * "
        str &= " FROM tbl_RatingTypes"
        str &= " WHERE Active = 'True' "


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
    Protected Sub btnRate_Click(sender As Object, e As EventArgs) Handles btnRate.Click
        InsertRating()
    End Sub
    Private Sub InsertRating()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@RatingType", HiddenFieldrateId.Value.Trim)
        cmd.Parameters.AddWithValue("@RatingMember", HiddenFieldmem.Value.Trim)
        cmd.Parameters.AddWithValue("@Rating", HiddenFieldRateScore.Value.Trim)
        cmd.Parameters.AddWithValue("@Comment", "")

        Dim str As String = ""
        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM  tbl_Farm_Rating  "
        str &= " WHERE FarmId = @FarmId AND  RatingType = @RatingType AND RatingMember = @RatingMember) "
        str &= " BEGIN "
        str &= " UPDATE tbl_Farm_Rating"
        str &= " SET Rating = @Rating"
        str &= " WHERE FarmId = @FarmId AND  RatingType = @RatingType AND RatingMember = @RatingMember  "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT INTO tbl_Farm_Rating "
        str &= " (FarmId, RatingType, RatingMember, Rating, Comment)"
        str &= " VALUES "
        str &= " (@FarmId, @RatingType, @RatingMember, @Rating, @Comment)"
        str &= " END  "
        str &= " COMMIT TRAN"

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
            PlaceHolder1.Controls.Add(New LiteralControl(GetRatingBody))
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InsertReview()
    End Sub
    Private Sub InsertReview()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@FarmId", lblFarmId.Text.Trim)
        cmd.Parameters.AddWithValue("@Date", Now)
        cmd.Parameters.AddWithValue("@MemberId", HiddenFieldmem.Value.Trim)
        cmd.Parameters.AddWithValue("@Review", txtReview.Text.Trim)

        Dim str As String = ""

        str = " BEGIN TRAN "
        str &= " IF EXISTS (SELECT * "
        str &= " FROM   tbl_Farm_Reviews  "
        str &= " WHERE FarmId = @FarmId AND  MemberId = @MemberId) "
        str &= " BEGIN "
        str &= " UPDATE  tbl_Farm_Reviews"
        str &= " SET Review = @Review"
        str &= " WHERE FarmId = @FarmId AND  MemberId = @MemberId  "
        str &= " END "
        str &= " ELSE "
        str &= " BEGIN "
        str &= " INSERT INTO  tbl_Farm_Reviews "
        str &= " (FarmId, MemberId, Date, RatingId, Review)"
        str &= " VALUES "
        str &= " (@FarmId, @MemberId, @Date, '0', @Review)"
        str &= " END  "
        str &= " COMMIT TRAN"

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
            PlaceHolder1.Controls.Add(New LiteralControl(GetRatingBody))
        Catch ex As Exception
            Dim g As String = ex.Message
        Finally
            myconnection.Close()
        End Try
    End Sub
End Class
