Imports System.Data.SqlClient
Public Class MetodosProjectsActuals
    Inherits ConnectioDB
    '====================================================================================================================================================================================
    '========== METODOS PARA PROJECTS ===================================================================================================================================================
    '====================================================================================================================================================================================
    Public Function selectProjects(Optional cmb As ComboBox = Nothing) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select cl.numberClient,po.projectId,po.unit,po.description
                from projectClientEst as po 
                inner join clientsEst as cl on cl.idClientEst= po.idClientEst
                order by po.projectId", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            dt.Columns.Add("projectId")
            dt.Columns.Add("numberClient")
            dt.Columns.Add("unit")
            dt.Columns.Add("description")
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("projectId"), dr("numberClient"), dr("unit"), dr("description"))
                If cmb IsNot Nothing Then
                    cmb.Items.Add(dr("projectId") + "| " + dr("Unit"))
                End If
            End While
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

End Class
