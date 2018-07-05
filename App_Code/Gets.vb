Imports System.Data
Imports Microsoft.VisualBasic

Public Class Gets
    Public Class GetEmailReceivers
        Public Function GetEmialReceivers(EmailType As String) As String
            Dim myconnection As New SqlClient.SqlConnection
            myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
            Dim cmd As New SqlClient.SqlCommand

            cmd.Parameters.AddWithValue("@EmailType", EmailType.Trim)


            Dim str As String = ""
            str &= " SELECT DISTINCT tblEmailReceivers.Email"
            str &= " FROM            tblEmailTypes INNER JOIN"
            str &= "                          tblEmailWhoReceives ON tblEmailTypes.id = tblEmailWhoReceives.EmailTypeId INNER JOIN"
            str &= "                          tblEmailReceivers ON tblEmailWhoReceives.ReceiverId = tblEmailReceivers.id"
            str &= " WHERE        (tblEmailTypes.EmailType = @EmailType)"


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
                ' lblSubmitMsg.Text &= ex.Message
            Finally
                myconnection.Close()
            End Try

            Dim thisaddress As String = ""
            Try
                Dim count As Integer = ds.Tables(0).Rows.Count - 1
                Dim sp As Integer
                For sp = 0 To count
                    If sp <> 0 Then
                        thisaddress &= "; "
                    End If
                    thisaddress &= ds.Tables(0).Rows(sp).Item("Email").ToString.Trim
                Next
            Catch ex As Exception
                thisaddress = "gawie@naudeonline.co.za"
            End Try
            If thisaddress = "" Then
                thisaddress = "gawie@naudeonline.co.za"
            End If
            Return thisaddress

        End Function
    End Class
    Public Class GetUserType
        Public Function GetUserType(MemberId As String) As String
            Dim myconnection As New SqlClient.SqlConnection
            myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
            Dim cmd As New SqlClient.SqlCommand

            cmd.Parameters.AddWithValue("@MemberId", MemberId.Trim)


            Dim str As String = ""
            str &= " SELECT tblUserTypes.MasterPageFile"
            str &= " FROM tbl_Users INNER JOIN"
            str &= "      tblUserTypes ON tbl_Users.UserType = tblUserTypes.Type_Name"
            str &= " WHERE MemberId  = @MemberId"

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
                ' lblSubmitMsg.Text &= ex.Message
            Finally
                myconnection.Close()
            End Try

            Dim UserType As String = ""
            Try
                UserType = ds.Tables(0).Rows(0).Item("MasterPageFile").ToString.Trim
            Catch ex As Exception
                UserType = "~/MasterPageGrnMbr.master"
            End Try

            Return UserType

        End Function

    End Class

End Class
