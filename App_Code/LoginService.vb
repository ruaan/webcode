Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Public Class LoginService

    Implements ILoginService
    Dim Builder As New StringBuilder()


    Public Function LoginConfirm(UserName As String, Password As String) As String Implements ILoginService.LoginConfirm

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@UserName", UserName.Trim)
        cmd.Parameters.AddWithValue("@Password", Password.Trim)



        Dim str As String = ""
        str &= " SELECT tbl_Users.id, tbl_Users.UserName, tbl_Users.UserType, tbl_Users.MemberId, tbl_Users.LastLoggedin, tblUserTypes.Type_Description, tblUserTypes.EntryPoint"
        str &= " FROM            tbl_Users INNER JOIN"
        str &= "                          tblUserTypes ON tbl_Users.UserType = tblUserTypes.Type_Name INNER JOIN"
        str &= "                          tbl_Password ON tbl_Users.id = tbl_Password.UserId"
        str &= " WHERE (tbl_Users.UserName = @UserName) AND (tbl_Password.Password = @Password) AND (Active = 'True')"
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

        Dim LoginData As String = ""

        Try

            If ds.Tables(0).Rows.Count > 0 Then
                With Builder

                    .Append("<logInDetails>")
                    .Append("<userType>" & ds.Tables(0).Rows(0).Item("UserType").ToString.Trim & "</userType>")
                    .Append("<UserId>" & ds.Tables(0).Rows(0).Item("id").ToString.Trim & "</UserId>")
                    .Append("<UserName>" & ds.Tables(0).Rows(0).Item("UserName").ToString.Trim & "</UserName>")
                    .Append("<MemberId>" & ds.Tables(0).Rows(0).Item("MemberId").ToString.Trim & "</MemberId>")

                    .Append("</logInDetails>")

                End With




            Else
                With Builder

                    .Append("<logInDetails>")
                    .Append("<userType>False</userType>")
                    .Append("<UserId></UserId>")
                    .Append("<UserName></UserName>")
                    .Append("<MemberId></MemberId>")

                    .Append("</logInDetails>")

                End With

            End If


        Catch ex As Exception

        End Try


        LoginData = Builder.ToString


        Return LoginData
    End Function



End Class
