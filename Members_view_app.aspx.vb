Imports System.Data
Partial Class Members_view_app
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet
    Dim memberId As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        memberId = Request.QueryString("id").ToString.Trim
        If Page.IsPostBack = False Then
            GetinitialData(memberId)

            PlaceHolder3.Controls.Add(New LiteralControl(GetRatings))
            PlaceHolder4.Controls.Add(New LiteralControl(GetGallery))
        End If
        imgBtnBack.OnClientClick = "javascript:window.history.go(-1);return false;"
    End Sub


    Private Function GetinitialData(ByVal memberId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", memberId.Trim)
        Dim str As String = ""

        str &= " SELECT  MemberId, Surname, FullName, Initials, Title, PreferredName, IDNo, PassportNr, Nationality, Country, Gender, CellNo, WorkNo, Email, Occupation, Dedicated_Hunter_MemberNo, Dedicated_Sport_ShooterNo,  "
        str &= " MedicalAidScheme, MedicalAidNo, Main_Member, NextKinName, NextKin_Relationship, NextKin_CellNo, NextKin_Email, Residential_StreetName, Residential_StreetNo, Residential_ComplexName, Residential_ComplexNo,  "
        str &= " Residential_Suburb, Residential_City_Town, Residential_Province_State, Residential_Code_Zip, Work_StreetName, Work_StreetNo, Work_ComplexName, Work_ComplexNo, Work_Suburb, Work_City_Town,  "
        str &= " Work_Province_State, Work_Code_Zip, ReferredByNo, DateJoined, MembershipExpire, HunterType, ProfilePicture, HomeNo FROM tbl_Member WHERE (MemberId = @id) "

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

        lblHeading.Text = ds.Tables(0).Rows(0).Item("FullName").ToString.Trim & " " & ds.Tables(0).Rows(0).Item("Surname").ToString.Trim & " (" & ds.Tables(0).Rows(0).Item("PreferredName").ToString.Trim & ")"
        If ds.Tables(0).Rows(0).Item("ProfilePicture").ToString.Trim = "" Then
            Image1.ImageUrl = "Images\ProfilePictures\Template.jpg"
        Else
            Image1.ImageUrl = "Images\ProfilePictures\" & ds.Tables(0).Rows(0).Item("ProfilePicture").ToString.Trim
        End If

        Try
            lblCellNo.Text = "Date Joined: " & CDate(ds.Tables(0).Rows(0).Item("DateJoined").ToString.Trim).ToString("yyyy/MM/dd")
        Catch ex As Exception
            lblCellNo.Text = "Date Joined: " & ds.Tables(0).Rows(0).Item("DateJoined").ToString.Trim
        End Try


        dsInfo = ds
        Return ds
    End Function

    Private Function GetGeninfo() As String
        GetinitialData(memberId)
        Dim htmlString As String = ""

        htmlString &= " <div id='divInfo'>"

        htmlString &= "     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "         <div id='div_info_Terms'>"

        '''''Personal Information'''''
        htmlString &= "             <div style='border-top-style: padding-left:10px;'>"

        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div style='display:inline-block;  padding: 2px;'>"
        htmlString &= "                     <div>Title:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("Title").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div style='display:inline-block; '>"
        htmlString &= "                     <div>Initials:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("Initials").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div style='display:inline-block; '>"
        htmlString &= "                     <div>FullName:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("FullName").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div style='display:inline-block; '>"
        htmlString &= "                     <div>LastName:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("Surname").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"

        htmlString &= "                 <div style='display:inline-block; width: 100px;'>"
        htmlString &= "                     <div>Gender:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("Gender").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div style='display:inline-block; width: 200px;'>"
        htmlString &= "                     <div>Preferred Name:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("PreferredName").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div style='display:inline-block; width: 300px;'>"
        htmlString &= "                     <div>Email Address:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("Email").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"

        htmlString &= "                 <div style='display:inline-block; '>"
        htmlString &= "                     <div>Mobile Number:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("CellNo").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div style='display:inline-block; '>"
        htmlString &= "                     <div>Business Telephone Number:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("WorkNo").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div style='display:inline-block; '>"
        htmlString &= "                     <div>Home Telephone Number:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("HomeNo").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"



        htmlString &= "                 <div style='display:inline-block; width: 200px;'>"
        htmlString &= "                     <div>Nationality:</div>"
        htmlString &= "                     <div class='Label_Style'>" & dsInfo.Tables(0).Rows(0).Item("Nationality").ToString.Trim & "</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"

        htmlString &= "             </div>"


        htmlString &= "                 <div style='padding: 2px;'>"
        htmlString &= "                     <div>Associations:</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"

        htmlString &= "                 <div style='display:inline-block; padding: 2px;'>"
        Dim dsAssociation As New DataSet
        dsAssociation = GetAssociationData()
        Dim associationCount, sp3 As Integer
        associationCount = dsAssociation.Tables(0).Rows.Count - 1
        If associationCount > -1 Then
            For sp3 = 0 To associationCount
                htmlString &= "                     <div>"
                htmlString &= "                         <div style='display:inline-block; padding: 2px;'>"
                htmlString &= "                             <div class='Label_Style' style='width: 300px;'>" & dsAssociation.Tables(0).Rows(sp3).Item("AssociationName").ToString.Trim & "</div>"
                htmlString &= "                         </div>"

                htmlString &= "                         </div>"
                htmlString &= "                     </div>"
            Next
        End If
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"

        htmlString &= "             </div>"
        htmlString &= "         </div>"
        htmlString &= "     </div>"
        htmlString &= " </div>"

        Return htmlString
    End Function
    Private Function GetAssociationData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", memberId.Trim)
        Dim str As String = ""

        str &= " SELECT id, MemberId, AssociationName, Association_Id, MemberNo FROM tbl_Member_Association WHERE (MemberId = @MemberId) "

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

        dsInfo = ds
        Return ds
    End Function
    Private Function GetRatings() As String
        Dim htmlString As String = ""

        htmlString &= " <div id='divInfo'>"

        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"

        htmlString &= "             <div style='border-top-style: padding-left:10px;'>"
        htmlString &= "                 <div>&nbsp;</div>"
        htmlString &= "                 <div>"


        Dim dsRating As New DataSet
        dsRating = GetRatingData()
        Dim count As Integer = dsRating.Tables(0).Rows.Count - 1
        Dim sp As Integer

        If count > -1 Then
            htmlString &= "                     <div class='side-Heading'>"
            For sp = 0 To count
                htmlString &= "                 <div style='font-weight: bold'>"
                htmlString &= dsRating.Tables(0).Rows(sp).Item("FarmName").ToString.Trim
                htmlString &= "                 </div>"
                htmlString &= "                 <div>"
                htmlString &= dsRating.Tables(0).Rows(sp).Item("Country").ToString.Trim & " " & dsRating.Tables(0).Rows(sp).Item("Province").ToString.Trim
                htmlString &= "                 </div>"

                Dim ratingCount As String = GetRatingCount(dsRating.Tables(0).Rows(sp).Item("FarmId").ToString.Trim)
                htmlString &= "                                     <div style='display: inline-block;'>"

                For i = 0 To CInt(ratingCount) - 1
                    htmlString &= "                                         <img alt='' src='Images/Icons/favorite-select.png' class='rateStar' />"
                Next

                htmlString &= "                                     </div>"
                htmlString &= "                 <div>"
                htmlString &= dsRating.Tables(0).Rows(sp).Item("Review").ToString.Trim
                htmlString &= "                 </div>"
                htmlString &= "                 <div style='color: #808080; font-size: medium;'>"
                htmlString &= dsRating.Tables(0).Rows(sp).Item("Date").ToString.Trim
                htmlString &= "                 </div>"
                htmlString &= "                 <div>&nbsp;</div>"

            Next
            htmlString &= "                 </div>"
        Else
            htmlString &= "                     <div class='side-Heading'>No Ratings. </div>"

        End If





        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"

        htmlString &= "                 <div style='display:inline-block; width: 100px; padding: 2px;'>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                     <div>&nbsp;</div>"
        htmlString &= "                 </div>"
        htmlString &= "                 <div>&nbsp;</div>"



        htmlString &= "             </div>"
        htmlString &= "         </div>"
        htmlString &= "     </div>"
        htmlString &= " </div>"

        Return htmlString
    End Function
    Private Function GetRatingData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", memberId.Trim)
        Dim str As String = ""

        str &= " SELECT        TOP (200) dbo.tbl_Farm_Reviews.id, dbo.tbl_Farm_Reviews.FarmId, dbo.tbl_Farm_Reviews.MemberId, dbo.tbl_Farm_Reviews.Date, dbo.tbl_Farm_Reviews.RatingId, dbo.tbl_Farm_Reviews.Review, dbo.tbl_Farm.FarmName, "
        str &= "                          dbo.tblProvince.Name AS Province, dbo.tblCountries.Name AS Country"
        str &= " FROM            dbo.tbl_Farm_Reviews INNER JOIN"
        str &= "                          dbo.tbl_Farm ON dbo.tbl_Farm_Reviews.FarmId = dbo.tbl_Farm.id INNER JOIN"
        str &= "                          dbo.tblProvince ON dbo.tbl_Farm.Province = dbo.tblProvince.ProvinceId INNER JOIN"
        str &= "                          dbo.tblCountries ON dbo.tbl_Farm.Country = dbo.tblCountries.Country_Id"
        str &= " WHERE        (dbo.tbl_Farm_Reviews.MemberId = @MemberId)"
        str &= " ORDER BY dbo.tbl_Farm_Reviews.Date"

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

    Private Function GetRatingCount(FarmId As String) As String
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@MemberId", memberId.Trim)
        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)
        Dim str As String = ""

        str &= " SELECT    dbo.tbl_Farm_Rating.FarmId, dbo.tbl_Farm_Rating.RatingMember, SUM(dbo.tbl_Farm_Rating.Rating) AS RatingValue, dbo.tbl_Farm.FarmName, COUNT(dbo.tbl_Farm_Rating.id) AS Count"
        str &= " FROM            dbo.tbl_Farm_Rating INNER JOIN"
        str &= "                          dbo.tbl_Farm ON dbo.tbl_Farm_Rating.FarmId = dbo.tbl_Farm.id"
        str &= " GROUP BY dbo.tbl_Farm_Rating.FarmId, dbo.tbl_Farm_Rating.RatingMember, dbo.tbl_Farm.FarmName"
        str &= "  HAVING        (dbo.tbl_Farm_Rating.RatingMember = @MemberId) AND (dbo.tbl_Farm_Rating.FarmId = @FarmId)"

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

        Dim ratingCount As String = "0"
        Try
            ratingCount = CDbl(ds.Tables(0).Rows(0).Item("RatingValue").ToString) / CDbl(ds.Tables(0).Rows(0).Item("Count").ToString)
            ratingCount = CDbl(ratingCount) / 2
        Catch ex As Exception

        End Try

        Return ratingCount

    End Function

    Private Function GetGallery() As String
        Dim htmlString As String = ""
        Dim getAlbum As New AlbumViewerMembers

        Dim AlbumString As String = ""
        AlbumString = getAlbum.GetAlbum("Private", memberId.Trim)

        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= AlbumString
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"


        Return htmlString

    End Function




End Class
