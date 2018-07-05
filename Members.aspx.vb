Imports System.Data
Partial Class Members
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

        End If
    End Sub
    Protected Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        txtMemName.Text = ""
        chkLocation.ClearSelection()
        chkAnimalsHunted.ClearSelection()
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        PlaceHolder4.Controls.Add(New LiteralControl(ResultBody))
    End Sub
    Private Function ResultBody() As String
        Dim htmlString As String = ""

        Dim dsFarm As New DataSet
        dsFarm = GetMembers(txtMemName.Text.Trim)

        Dim dsHunting As New DataSet
        Dim dsFacilities As New DataSet

        Dim farmCount As Integer = dsFarm.Tables(0).Rows.Count - 1
        Dim farmSp As Integer

        Dim huntCount, huntSp As Integer
        Dim ReviewCount As String = "0"
        If farmCount > -1 Then

            For farmSp = 0 To farmCount

                dsHunting = GetHuntingTypes(dsFarm.Tables(0).Rows(farmSp).Item("MemberId").ToString.Trim)
                huntCount = dsHunting.Tables(0).Rows.Count - 1

                htmlString &= "                    <div id='famrid" & dsFarm.Tables(0).Rows(farmSp).Item("MemberId").ToString.Trim & " ' class='div_Farm_Block'  onclick=""window.open('member_view.aspx?id=" & dsFarm.Tables(0).Rows(farmSp).Item("MemberId").ToString.Trim & "', '_self')"">"
                htmlString &= "                         <div class='div_Picture_Style'>"
                If dsFarm.Tables(0).Rows(farmSp).Item("ProfilePicture").ToString.Trim = "" Then
                    htmlString &= "                             <img alt='' src='Images/ProfilePictures/Template.jpg' class='image_Style'  />"
                Else
                    htmlString &= "                             <img alt='' src='Images/ProfilePictures/" & dsFarm.Tables(0).Rows(farmSp).Item("ProfilePicture").ToString.Trim & "' class='image_Style'  />"
                End If
                htmlString &= "                         </div>"
                htmlString &= "                         <div class='div_Middle_Block'>"
                htmlString &= "                             <div class='div_Farm_header'>" & dsFarm.Tables(0).Rows(farmSp).Item("FullName").ToString.Trim & " " & dsFarm.Tables(0).Rows(farmSp).Item("Surname").ToString.Trim & " &nbsp; (" & dsFarm.Tables(0).Rows(farmSp).Item("PreferredName").ToString.Trim & ")</div>"
                htmlString &= "                             <div>&nbsp;</div>"

                htmlString &= "                             <div>"
                Try
                    htmlString &= "Date Joined: " & CDate(dsFarm.Tables(0).Rows(farmSp).Item("DateJoined").ToString.Trim).ToString("yyyy/MM/dd")
                Catch ex As Exception
                    htmlString &= "Date Joined: " & dsFarm.Tables(0).Rows(farmSp).Item("DateJoined").ToString.Trim
                End Try
                htmlString &= "                             </div>"

                htmlString &= "                             <div>"
                For huntSp = 0 To huntCount
                    htmlString &= "                                 <div class='icon_style'>"
                    htmlString &= "                                     <img alt='' src='Images/Icons/Farm_Search/HuntType/" & dsHunting.Tables(0).Rows(huntSp).Item("IconPath").ToString.Trim & "' />"
                    htmlString &= "                                 </div>"
                Next
                htmlString &= "                             </div></div></div>"
            Next

        Else
            htmlString &= "                         <div class='div_Farm_header'>"
            htmlString &= "Sorry, no member match your search criteria."
            htmlString &= "                             </div>"

        End If
        Return htmlString
    End Function
    Private Function GetMembers(ByVal SearchString As String) As DataSet

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand
        cmd.Parameters.AddWithValue("@Name", "%" & SearchString.Trim & "%")

        Dim str As String = ""
        str &= " SELECT DISTINCT tbl_Member.FullName, tbl_Member.Surname, tbl_Member.MemberId, tbl_Member.ProfilePicture, tbl_Member.PreferredName, tbl_Member.CellNo, tbl_Member.Email, tbl_Member.DateJoined, tbl_Member.MembershipExpire "
        str &= " FROM tbl_Farms_v_User RIGHT OUTER JOIN "
        str &= " tbl_Member On tbl_Farms_v_User.UserId = tbl_Member.MemberId LEFT OUTER JOIN "
        str &= " tbl_Hunts On tbl_Member.MemberId = tbl_Hunts.Main_Member_Id LEFT OUTER JOIN "
        str &= " tbl_Farm_Animal RIGHT OUTER JOIN "
        str &= " tbl_Hunts_Species On tbl_Farm_Animal.id = tbl_Hunts_Species.Farm_Animal_Id On tbl_Hunts.HuntGroupId = tbl_Hunts_Species.HuntsId "
        str &= " WHERE (tbl_Member.FullName Like @Name) "

        '///farms visited search
        Dim strProvince As String = GetSelectedCheckBoxItems(chkLocation)
        If strProvince <> "" Then
            str &= " And (tbl_Farms_v_User.FarmId In (" & strProvince & ")) "
        End If

        '///animals hunted search
        Dim strFacility As String = GetSelectedCheckBoxItems(chkAnimalsHunted)
        If strFacility <> "" Then
            str &= " And (tbl_Farm_Animal.AnimalId In (" & strFacility & "))"
        End If

        str &= " Or "
        str &= " (tbl_Member.Surname Like @Name) "

        '///farms visited search
        If strProvince <> "" Then
            str &= " And (tbl_Farms_v_User.FarmId In (" & strProvince & ")) "
        End If

        '///animals hunted search
        If strFacility <> "" Then
            str &= " And (tbl_Farm_Animal.AnimalId In (" & strFacility & "))"
        End If

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

        Return ds
    End Function
    Private Function GetSelectedCheckBoxItems(ChkBox As CheckBoxList) As String

        Dim strSelected As String = ""
        For Each oItem As ListItem In ChkBox.Items
            If oItem.Selected Then
                If strSelected = "" Then
                    strSelected = ("'" & oItem.Value & "'")
                Else
                    strSelected &= (", '" & oItem.Value & "'")
                End If
            End If
        Next
        Return strSelected

    End Function
    Private Function GetHuntingTypes(MemId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Member", MemId.Trim)

        Dim str As String = ""
        str &= " SELECT DISTINCT  tbl_Farm_Hunting_Types.Hunting_Type_Id, tbl_Hunting_Types.IconPath, tbl_Hunts.Main_Member_Id "
        str &= " FROM tbl_Farm_Hunting_Types INNER JOIN "
        str &= " tbl_Hunting_Types ON tbl_Farm_Hunting_Types.Hunting_Type_Id = tbl_Hunting_Types.id INNER JOIN "
        str &= " tbl_Hunts On tbl_Farm_Hunting_Types.FarmId = tbl_Hunts.FarmId "
        str &= " WHERE (tbl_Hunts.Main_Member_Id = @Member) "

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
End Class
