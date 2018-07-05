Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class GetMenuClass
    Public Function GetMenuData(ByVal userid As String) As DataSet

        Dim myConnection As New SqlClient.SqlConnection
        myConnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString

        Dim str As String = ""
        str &= " SELECT     tblMenus.MenuId, tblMenus.MenuGroup, tblMenuGroups.Description,tblMenuPaths.Path AS NavigateUrl, tblMenus.MenuDescription"
        str &= " FROM         tblUserGroups INNER JOIN"
        str &= "                       tblMenuGroupItems ON tblUserGroups.GroupId = tblMenuGroupItems.MenuGroupId INNER JOIN"
        str &= "                       tblMenus ON tblMenuGroupItems.MenuItem = tblMenus.MenuId INNER JOIN"
        str &= "                       tblMenuGroups ON tblUserGroups.GroupId = tblMenuGroups.GourpId LEFT OUTER JOIN"
        str &= "                       tblMenuPaths ON tblMenus.Path = tblMenuPaths.MenuPathId"
        str &= " WHERE     (tblUserGroups.UserId = '" & userid & "') AND (tblMenus.Active = 'True')"
        str &= " ORDER BY tblUserGroups.LineOrder, tblMenuGroups.Description, tblMenus.LineOrder"

        Dim dadCats As New SqlDataAdapter(str, myConnection)

        Dim str1 As String = " "
        str1 &= " SELECT     tblMenuItems.MenuId, tblMenuItems.LineOrder, tblMenuItems.Active, tblMenuPaths.Name AS ChildDescription, "
        str1 &= "                      tblMenuPaths.Path AS NavigateUrl, tblMenuPaths.Active AS Expr1"
        str1 &= " FROM         tblUserGroups INNER JOIN "
        str1 &= "                       tblMenuGroupItems ON tblUserGroups.GroupId = tblMenuGroupItems.MenuGroupId INNER JOIN"
        str1 &= "                       tblMenuItems ON tblMenuGroupItems.MenuItem = tblMenuItems.MenuId LEFT OUTER JOIN"
        str1 &= "                       tblMenuPaths ON tblMenuItems.Path = tblMenuPaths.MenuPathId"
        str1 &= " WHERE     (tblMenuItems.Active = 'True') AND (tblUserGroups.UserId = '" & userid & "') AND (tblMenuPaths.Active = 'True') "
        str1 &= " ORDER BY tblUserGroups.LineOrder, tblMenuItems.LineOrder"

        Dim dadProducts As New SqlDataAdapter(str1, myConnection)

        Dim dst As New DataSet()
        dadCats.Fill(dst, "Menus")
        dadProducts.Fill(dst, "MenuItems")
        dst.Relations.Add("Children",
        dst.Tables("Menus").Columns("MenuId"),
        dst.Tables("MenuItems").Columns("MenuId"))
        Return dst

    End Function
    Dim Mesage As String = ""
    Public Function CreateMenuGroups(UserId As String) As String
        Dim dsMenu As New DataSet
        dsMenu = getMenuGroups(UserId)
        Dim menuString As String = ""
        menuString &= "         <table style=""width: 220px;"">"
        Dim count As Integer = dsMenu.Tables(0).Rows.Count - 1
        Dim sp As Integer
        Dim IconPath As String = ""
        For sp = 0 To count
            IconPath = dsMenu.Tables(0).Rows(sp).Item("IconPath").ToString.Trim
            If IconPath = "" Then
                IconPath = "47"
            End If
            menuString &= "             <tr>"
            menuString &= "                 <td class=""LineDevider"">"
            menuString &= "                     <img alt='' src=""../../../../Images/MenuItems/" & IconPath & ".png"" style=""height: 16px; width: 16px"" />"
            menuString &= "                     <input id=""Button" & sp & dsMenu.Tables(0).Rows(sp).Item("Description").ToString.Trim & """ type=""button"" value=""" & dsMenu.Tables(0).Rows(sp).Item("Description").ToString.Trim & """ class=""MenuLineButton"" onclick=""MenuClick('True','" & dsMenu.Tables(0).Rows(sp).Item("Description").ToString.Trim & "','" & dsMenu.Tables(0).Rows(sp).Item("GourpId").ToString.Trim & "')""  />"
            menuString &= "                 </td>"
            menuString &= "             </tr>"
        Next
        Return menuString
    End Function
    Private Function getMenuGroups(UserId As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim cmd As New SqlClient.SqlCommand
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        cmd.Parameters.AddWithValue("@UserId", UserId)
        Dim str As String = ""
        str = " SELECT        tblMenuGroups.GourpId, tblMenuGroups.Description, tblMenuGroups.IconPath"
        str &= " FROM            tblUserGroups INNER JOIN"
        str &= "                          tblMenuGroups ON tblUserGroups.GroupId = tblMenuGroups.GourpId"
        str &= " WHERE        (tblUserGroups.UserId = @UserId)"
        str &= " ORDER BY tblUserGroups.LineOrder"
        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection
        da.SelectCommand = cmd
        Try
            myconnection.Open()
            ds.Clear()
            da.Fill(ds)

        Catch ex As Exception
            'lblMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
        Return ds
    End Function
    Private Function GetMenuItems(id As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim cmd As New SqlClient.SqlCommand
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        cmd.Parameters.AddWithValue("@MenuGroup", id)
        Dim str As String = ""
        str = " SELECT        tblMenus.MenuId, tblMenus.MenuDescription, tblMenus.Path, tblMenuPaths.Name, tblMenuPaths.Path AS Expr1, tblMenuGroupItems.MenuGroupId, tblMenus.IconPath "
        str &= " FROM            tblMenus INNER JOIN"
        str &= "                         tblMenuGroupItems ON tblMenus.MenuId = tblMenuGroupItems.MenuItem LEFT OUTER JOIN"
        str &= "                          tblMenuPaths ON tblMenus.Path = tblMenuPaths.MenuPathId"
        str &= " WHERE        (tblMenus.Active = 'True') AND (tblMenus.MenuDescription NOT LIKE '%*%') AND (tblMenuGroupItems.MenuGroupId = @MenuGroup) AND (tblMenuPaths.Active = 'True') OR"
        str &= "                         (tblMenus.Active = 'True') AND (tblMenus.MenuDescription NOT LIKE '%*%') AND (tblMenuGroupItems.MenuGroupId = @MenuGroup) AND (tblMenuPaths.Path IS NULL)"
        str &= " ORDER BY tblMenus.MenuDescription"
        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection
        da.SelectCommand = cmd
        Try
            myconnection.Open()
            ds.Clear()
            da.Fill(ds)

        Catch ex As Exception
            Mesage = ex.Message
        Finally
            myconnection.Close()
        End Try
        Return ds
    End Function
    Public Function CreateMenuGroupItems(Id As String, Titel As String) As String
        Dim dsMenu As New DataSet
        Dim menuString As String = ""


        dsMenu = GetMenuItems(Id)
        If Mesage = "" Then
            Try


                menuString &= " <table style=""width: 240px;"">"
                menuString &= "         <tr>"
                menuString &= "             <td align=""center"" style=""color: #6A6A6A; font-size: x-large; font-weight: bold;""  >"
                menuString &= Titel
                menuString &= "             </td>"
                menuString &= "         </tr>"
                menuString &= "         <tr>"
                menuString &= "             <td>"
                menuString &= "                 &nbsp;</td>"
                menuString &= "         </tr>"
                menuString &= "         <tr>"
                menuString &= "             <td align=""right"">"
                menuString &= "   <input id=""btnBack1"" class=""Level1LineButton"" "
                menuString &= "                     style=""color: #6A6A6A; font-size: medium; font-weight: bold"" type=""button"" "
                menuString &= "                     value=""back>>"" onclick=""StartMenu()"" /> &nbsp;   "
                menuString &= "                 </td>"
                menuString &= "         </tr>"
                menuString &= "         <tr>"
                menuString &= "             <td>"
                menuString &= "         <table style=""width: 220px;"">"
                Dim count As Integer = dsMenu.Tables(0).Rows.Count - 1
                Dim sp As Integer
                Dim CarryOn As String = ""
                Dim ItemTitel As String = ""
                Dim IconPath As String = ""
                For sp = 0 To count
                    IconPath = dsMenu.Tables(0).Rows(sp).Item("IconPath").ToString.Trim
                    If IconPath = "" Then
                        IconPath = "74"
                    End If
                    menuString &= "             <tr>"
                    menuString &= "                 <td class=""LineDevider"">"
                    If dsMenu.Tables(0).Rows(sp).Item("Expr1").ToString.Trim = "" Then
                        CarryOn = "True"
                        ItemTitel = "<< " & dsMenu.Tables(0).Rows(sp).Item("MenuDescription").ToString.Trim
                    Else
                        CarryOn = "False"
                        ItemTitel = "     " & dsMenu.Tables(0).Rows(sp).Item("MenuDescription").ToString.Trim
                    End If
                    If ItemTitel.Length > 30 Then
                        ItemTitel = ItemTitel.Substring(0, 30)
                    End If
                    Dim thisPath As String = ""
                    thisPath = dsMenu.Tables(0).Rows(sp).Item("Expr1").ToString.Trim
                    If thisPath.Length > 2 Then
                        thisPath = thisPath.Remove(0, 2)
                        thisPath = "../../../../" & thisPath
                    End If


                    menuString &= "                     <img alt='' src=""../../../../../Images/MenuItems/" & IconPath & ".png"" style=""height: 16px; width: 16px"" />"
                    menuString &= "                     <input id=""Button" & sp & dsMenu.Tables(0).Rows(sp).Item("MenuDescription").ToString.Trim & """ type=""button"" value=""" & ItemTitel & """ class=""Level1LineButton"" onclick=""Menu1Click('" & CarryOn & "','" & dsMenu.Tables(0).Rows(sp).Item("MenuDescription").ToString.Trim & "','" & dsMenu.Tables(0).Rows(sp).Item("MenuId").ToString.Trim & "', '" & thisPath & "')""  />"
                    menuString &= "                 </td>"
                    menuString &= "             </tr>"
                Next
            Catch ex As Exception
                menuString = ex.Message
            End Try
        Else
            menuString &= Mesage
        End If
        Return menuString
    End Function
    Private Function GetMenuChild(Id As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim cmd As New SqlClient.SqlCommand
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        cmd.Parameters.AddWithValue("@Menu", Id)
        Dim str As String = ""
        str = " SELECT        tblMenuPaths.Name, tblMenuPaths.Path"
        str &= " FROM            tblMenuItems LEFT OUTER JOIN"
        str &= "                          tblMenuPaths ON tblMenuItems.Path = tblMenuPaths.MenuPathId"
        str &= " WHERE        (tblMenuItems.MenuId = @Menu) AND (tblMenuItems.Active = 'True')  AND (tblMenuPaths.Active = 'True')"
        str &= " ORDER BY tblMenuPaths.Name"
        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection
        da.SelectCommand = cmd
        Try
            myconnection.Open()
            ds.Clear()
            da.Fill(ds)

        Catch ex As Exception
            'lblMsg.Text = ex.Message
        Finally
            myconnection.Close()
        End Try
        Return ds
    End Function
    Public Function CreateChild(MenuId As String, Titel As String) As String
        Dim dsMenu As New DataSet
        dsMenu = GetMenuChild(MenuId)
        Dim menuString As String = ""
        menuString = " <table style=""width: 240px;"">"
        menuString &= "         <tr>"
        menuString &= "             <td align=""center"" style=""color: #6A6A6A; font-size: x-large; font-weight: bold;""  >"
        menuString &= Titel
        menuString &= "             </td>"
        menuString &= "         </tr>"
        menuString &= "         <tr>"
        menuString &= "             <td>"
        menuString &= "                 &nbsp;</td>"
        menuString &= "         </tr>"
        menuString &= "         <tr>"
        menuString &= "             <td align=""right"">"
        menuString &= "   <input id=""btnBack1"" class=""Level2LineButton"" "
        menuString &= "                     style=""color: #6A6A6A; font-size: medium; font-weight: bold"" type=""button"" "
        menuString &= "                     value=""back>>"" onclick=""CloseLevel2()"" /> &nbsp;   "
        menuString &= "                 </td>"
        menuString &= "         </tr>"
        menuString &= "         <tr>"
        menuString &= "             <td>"
        menuString &= "         <table style=""width: 220px;"">"
        Dim count As Integer = dsMenu.Tables(0).Rows.Count - 1
        Dim sp As Integer
        Dim CarryOn As String = ""
        Dim ItemTitel As String = ""
        Dim thisPath As String = ""
        For sp = 0 To count
            menuString &= "             <tr>"
            menuString &= "                 <td class=""LineDevider"">"
            ItemTitel = "   " & dsMenu.Tables(0).Rows(sp).Item("Name").ToString.Trim
            If ItemTitel.Length > 30 Then
                ItemTitel = ItemTitel.Substring(0, 30)
            End If

            thisPath = dsMenu.Tables(0).Rows(sp).Item("Path").ToString.Trim
            thisPath = thisPath.Remove(0, 2)
            thisPath = "../../../../" & thisPath
            'If thisPath <> "" Then
            '    thisPath = "'<%=Page.ResolveClientUrl(""" & thisPath & """)%>'"
            'End If

            menuString &= "                     <img alt='' src=""../../../../../Image/MenuItems/10.png"" style=""height: 16px; width: 16px"" />"
            menuString &= "                     <input id=""Button" & sp & dsMenu.Tables(0).Rows(sp).Item("Name").ToString.Trim & """ type=""button"" value=""" & ItemTitel & """ class=""Level2LineButton"" onclick=""Menu1Click('False','" & dsMenu.Tables(0).Rows(sp).Item("Name").ToString.Trim & "','', '" & thisPath & "')""  />"
            menuString &= "                 </td>"
            menuString &= "             </tr>"

        Next

        Return menuString

    End Function
End Class
