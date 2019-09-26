Imports System.Data
Imports System.Data.SqlClient
Public Class MetodosMaterials



    Dim conexion As New ConnectioDB

    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    Public Sub ConsultaMaterials(ByVal sql As String)
        conexion.conectar()
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion.conn)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, "materials")
    End Sub

    Function InsertarMaterials(ByVal sql)
        conexion.conectar()
        comando = New SqlCommand(sql, conexion.conn)

        Dim i As Integer = comando.ExecuteNonQuery()
        If (1 > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ModificarMaterials(ByVal sql As String)
        conexion.conectar()
        comando = New SqlCommand("sp_Update_Materials", conexion.conn)
        Dim i As Integer = comando.ExecuteNonQuery()
        If (1 > 0) Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Sub cargarMaterials(ByVal tblMaterials As DataGridView, ByVal text As String)
        Try
            conexion.conectar()
            Dim cmd As New SqlCommand("select *from materials where  like '" & text + "%" & "' ", conexion.conectar())

            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblMaterials.DataSource = dt
            Else
                MsgBox("Error in the connection to Data Base check your sever")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
