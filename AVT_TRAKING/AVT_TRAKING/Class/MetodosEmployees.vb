Imports System.Data.SqlClient

Public Class MetodosEmployees
    Inherits ConnectioDB

    Public Sub cargarEmpleados(ByVal tblEmpledos As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from employes", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblEmpledos.DataSource = dt
            Else
                MsgBox("Error in the connection to Data Base check your sever")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class
