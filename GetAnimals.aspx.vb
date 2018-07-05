Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Script.Serialization
Imports System.Runtime.Serialization
Imports System.Data

Partial Class GetAnimals
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.ContentType = "application/json"

        Dim dsAnimal As New DataSet
        dsAnimal = GetAnimals(Request.QueryString("q"))





    End Sub

    Private Function GetAnimals(Searchstr As String) As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Searchstr", "%" & Searchstr.Trim & "%")


        Dim str As String = ""
        str &= "  SELECT        id, Name"
        str &= "  FROM            tbl_Animals"
        str &= "  WHERE        (Name LIKE @Searchstr)"

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
