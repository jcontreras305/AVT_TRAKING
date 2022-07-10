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
    '====================================================================================================================================================================================
    '========== METODOS PARA HOURS ======================================================================================================================================================
    '====================================================================================================================================================================================
    Public Function SelectHoursProject(ByVal tbl As DataGridView, ByVal projectId As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select projectId , convert(nvarchar, weekend,101) as 'weekend' , scfHrs , rmvHrs , iiHrs, pntHrs from hoursProjectEst where projectId = '" + projectId + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("projectId"), dr("weekend"), dr("weekend"), If(dr("scfHrs") = 0 Or dr("scfHrs") Is DBNull.Value, "0.0", Math.Round(CDec(dr("scfHrs")), 2, MidpointRounding.ToEven).ToString("#,###.0")), If(dr("rmvHrs") = 0 Or dr("rmvHrs") Is DBNull.Value, "0.0", Math.Round(CDec(dr("rmvHrs")), 2, MidpointRounding.ToEven).ToString("#,###.0")), If(dr("iiHrs") = 0 Or dr("iiHrs") Is DBNull.Value, "0.0", Math.Round(CDec(dr("iiHrs")), 2, MidpointRounding.ToEven).ToString("#,###.0")), If(dr("pntHrs") = 0 Or dr("pntHrs") Is DBNull.Value, "0.0", Math.Round(CDec(dr("pntHrs")), 2, MidpointRounding.ToEven).ToString("#,###.0")))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function SaveUpdateHoursProject(ByVal tbl As DataGridView, ByVal projectId As String) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = Nothing
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells(0).Value Is Nothing Or row.Cells(0).Value = "") Or (row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value = "") Then
                    cmd.CommandText = "if (select count(*) from hoursProjectEst where projectId = '" + projectId + "' and weekend = '" + validaFechaParaSQl(row.Cells("WeekendHrs").Value.ToString()) + "')=0
                        begin
	                        insert into hoursProjectEst values ('" + projectId + "','" + validaFechaParaSQl(row.Cells("WeekendHrs").Value.ToString()) + "'," + row.Cells("scfHrs").Value.ToString() + ", " + row.Cells("rmvHrs").Value.ToString() + "," + row.Cells("iiHrs").Value.ToString() + "," + row.Cells("pntHrs").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if (select count(*) from hoursProjectEst where projectId = '" + row.Cells("projectIdAux").Value.ToString() + "' and weekend = '" + validaFechaParaSQl(row.Cells("weekAux").Value.ToString()) + "') =1
                        begin
	                        update hoursProjectEst set weekend='" + validaFechaParaSQl(row.Cells("WeekendHrs").Value.ToString()) + "',scfHrs=" + row.Cells("scfHrs").Value.ToString() + ",rmvHrs=" + row.Cells("rmvHrs").Value.ToString() + ",iiHrs=" + row.Cells("iiHrs").Value.ToString() + ",ptnHrs=" + row.Cells("pntHrs").Value.ToString() + " where projectId = '" + row.Cells("projectIdAux").Value.ToString() + "' and weekend = '" + validaFechaParaSQl(row.Cells("weekAux").Value.ToString()) + "'
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
                MsgBox("Successful.")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteHoursProject(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = False
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells(0).Value IsNot Nothing Or row.Cells(0).Value <> "") And (row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value <> "") Then
                    cmd.CommandText = "if (select count(*) from hoursProjectEst where projectId = '" + row.Cells("projectIdAux").Value.ToString() + "' and weekend = '" + row.Cells("weekAux").Value.ToString() + "')>0
begin
	delete from hoursProjectEst where weekend = '" + validaFechaParaSQl(row.Cells("weekAux").Value.ToString()) + "' and projectId = '" + row.Cells("projectIdAux").Value.ToString() + "'
end"
                    cmd.Connection = conn
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful.")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    '====================================================================================================================================================================================
    '========== METODOS PARA COST =======================================================================================================================================================
    '====================================================================================================================================================================================
    Public Function SelectCostProject(ByVal tbl As DataGridView, ByVal projectId As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select projectId , convert(nvarchar, weekend,101) as 'weekend' , scfCost , rmvCost , iiCost, pntCost from costProjectEst where projectId = '" + projectId + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("projectId"), dr("weekend"), dr("weekend"), If(dr("scfCost") = 0 Or dr("scfCost") Is DBNull.Value, "0.0", Math.Round(CDec(dr("scfCost")), 2, MidpointRounding.ToEven).ToString("#,###.00")), If(dr("rmvCost") = 0 Or dr("rmvCost") Is DBNull.Value, "0.0", Math.Round(CDec(dr("rmvCost")), 2, MidpointRounding.ToEven).ToString("#,###.00")), If(dr("iiCost") = 0 Or dr("iiCost") Is DBNull.Value, "0.0", Math.Round(CDec(dr("iiCost")), 2, MidpointRounding.ToEven).ToString("#,###.00")), If(dr("pntCost") = 0 Or dr("pntCost") Is DBNull.Value, "0.0", Math.Round(CDec(dr("pntCost")), 2, MidpointRounding.ToEven).ToString("#,###.00")))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveUpdateCostProject(ByVal tbl As DataGridView, ByVal projectId As String) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = Nothing
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells(0).Value Is Nothing Or row.Cells(0).Value = "") Or (row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value = "") Then
                    cmd.CommandText = "if (select count(*) from costProjectEst where projectId = '" + projectId + "' and weekend = '" + validaFechaParaSQl(row.Cells("weekendCost").Value.ToString()) + "')=0
                        begin
	                        insert into costProjectEst values ('" + projectId + "','" + validaFechaParaSQl(row.Cells("weekendCost").Value.ToString()) + "'," + row.Cells("scfCost").Value.ToString() + ", " + row.Cells("rmvCost").Value.ToString() + "," + row.Cells("iiCost").Value.ToString() + "," + row.Cells("pntCost").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if (select count(*) from costProjectEst where projectId = '" + row.Cells("projectIdCost").Value.ToString() + "' and weekend = '" + validaFechaParaSQl(row.Cells("weekendCostAux").Value.ToString()) + "') =1
                        begin
	                        update costProjectEst set weekend='" + validaFechaParaSQl(row.Cells("weekendCost").Value.ToString()) + "',scfCost=" + row.Cells("scfCost").Value.ToString() + ",rmvCost=" + row.Cells("rmvCost").Value.ToString() + ",iiCost=" + row.Cells("iiCost").Value.ToString() + ",ptnCost=" + row.Cells("pntCost").Value.ToString() + " where projectId = '" + row.Cells("projectIdCost").Value.ToString() + "' and weekend = '" + validaFechaParaSQl(row.Cells("weekendCostAux").Value.ToString()) + "'
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
                MsgBox("Successful.")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteCostProject(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = False
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells(0).Value IsNot Nothing Or row.Cells(0).Value <> "") And (row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value <> "") Then
                    cmd.CommandText = "if (select count(*) from costProjectEst where projectId = '" + row.Cells("projectIdCost").Value.ToString() + "' and weekend = '" + row.Cells("weekendCostAux").Value.ToString() + "')>0
begin
	delete from costProjectEst where weekend = '" + validaFechaParaSQl(row.Cells("weekendCostAux").Value.ToString()) + "' and projectId = '" + row.Cells("projectIdCost").Value.ToString() + "'
end"
                    cmd.Connection = conn
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful.")
                Return True
            Else
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
