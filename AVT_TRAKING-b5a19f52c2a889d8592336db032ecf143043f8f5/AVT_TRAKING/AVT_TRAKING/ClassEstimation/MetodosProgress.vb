Imports System.Data.SqlClient
Public Class MetodosProgress
    Inherits ConnectioDB

    Public Function llenarComboCellScaffold(ByRef cmb As DataGridViewComboBoxCell, ByVal idDrawing As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag from scaffoldEst where idDrawingNum = '" + idDrawing + "'")
            cmb.Items.Clear()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                cmb.Items.Add(dr("tag"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectSCFProgress(ByVal tbl As DataGridView, ByVal idDrawing As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select scfp.tag as 'TagAux',scfp.weekending as 'weekendigAux',scfp.tag as 'Tag No.',scfp.weekending as 'Weekend',ISNULL(scfp.buildPercent,0) as 'buildPercent',ISNULL(scfp.demoPercent,0) as 'demoPercent' 
from ScaffoldProgress as scfp 
inner join scaffoldEst as scf on scf.tag = scfp.tag
inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
where dr.idDrawingNum = '" + idDrawing + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("tag"), dr("weekending"), dr("tag"), dr("weekending"), dr("buildPercent"), dr("demoPercent"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveUpdateSCFProgress(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = Nothing
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If row.Cells(0).Value.ToString() = "" Then
                    cmd.CommandText = "	if (select count(*) from ScaffoldProgress where tag='" + row.Cells("Tag").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("Weekend").Value.tString()) + "')=0
	                    begin
		                    insert into ScaffoldProgress values('" + row.Cells("TagAux").Value.ToString() + "','" + validaFechaParaSQl(row.Cells("Weekend").Value.ToString()) + "'," + row.Cells("Build").Value.ToString() + "," + row.Cells("Demo").Value.String() + ")
	                    end"
                Else
                    cmd.CommandText = "if (select count(*) from ScaffoldProgress where tag='" + row.Cells("TagAux").ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendAux").ToString()) + "')=1
                        begin
	                        update ScaffoldProgress set tag = '" + row.Cells("Tag").ToString() + "' , weekending = '" + validaFechaParaSQl(row.Cells("Weekend").ToString()) + "' , buildPercent = " + row.Cells("Build").ToString() + " , demoPercent = " + row.Cells("Demo").ToString() + " where tag = '" + row.Cells("TagAux").ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendAux").ToString()) + "'
                        end"
                End If
                cmd.Connection = conn
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    flag = False
                    Exit For
                End If
            Next
            If flag Then
                tran.Commit()
            End If

        Catch ex As Exception

        End Try
        Return True
    End Function

End Class
