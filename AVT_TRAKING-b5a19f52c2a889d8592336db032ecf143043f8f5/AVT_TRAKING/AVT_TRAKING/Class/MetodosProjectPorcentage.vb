Imports System.Data.SqlClient
Public Class MetodosProjectPorcentage
    Inherits ConnectioDB

    Public Function selectProject(ByVal tbl As DataGridView, ByVal idClient As String, Optional jobNo As String = "", Optional po As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tk.idAux,'' as 'Error',cl.numberClient as 'Client No' ,jb.jobNo as 'Job No' , po.idPO as 'Project Order' , CONCAT (wo.idWO ,'-',tk.task) as 'Project', tk.percentComplete as 'Complete' 
from task as tk inner join workOrder as wo on tk.idAuxWO = wo.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient like " + idClient + " " + If(jobNo = "", "", " and jb.jobNo = " + jobNo + "") + " " + If(po = "", "", "and po.idPO =  " + po + ""), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("idAux"), dr("Error"), dr("Client No"), dr("Job No"), dr("Project Order"), dr("Project"), dr("Complete"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function updateProjectPercent(ByVal tbl As DataTable, ByRef pgbPercent As ProgressBar) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = False
            For Each row As DataRow In tbl.Rows
                Dim cmd As New SqlCommand("update task set percentComplete = " + row.ItemArray(1) + " where idAux = '" + row.ItemArray(0) + "'", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
                    If pgbPercent.Value < 90 Then
                        pgbPercent.Visible = pgbPercent.Value + 1
                    End If
                    flag = True
                Else
                    flag = False
                    Exit For
                End If
            Next
            pgbPercent.Value = 95
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

End Class
