Imports System.Data.SqlClient
Public Class MetodosProgress
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
    '========== METODOS PARA DRAWING ====================================================================================================================================================
    '====================================================================================================================================================================================

    Public Function selectProjectsDrawing(ByVal idProject As String, Optional cmb As ComboBox = Nothing) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select cl.numberClient,dr.projectId,idDrawingNum,dr.[description]
                from drawing as dr
                inner join projectClientEst as po on po.projectId = dr.projectId
                inner join clientsEst as cl on cl.idClientEst= po.idClientEst
                " + If(idProject <> "", "where po.projectId = '" + idProject + "'", "") + "
                order by dr.projectId", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            dt.Columns.Add("idDrawingNum")
            dt.Columns.Add("projectId")
            dt.Columns.Add("numberClient")
            dt.Columns.Add("description")
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("idDrawingNum"), dr("projectId"), dr("numberClient"), dr("description"))
                If cmb IsNot Nothing Then
                    cmb.Items.Add(dr("idDrawingNum") + "| " + dr("projectId"))
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
    '========== METODOS PARA DRAWING ====================================================================================================================================================
    '====================================================================================================================================================================================
    Public Function llenarComboCellScaffold(ByRef cmb As DataGridViewComboBoxCell, ByVal idDrawing As String) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag from scaffoldEst where idDrawingNum = '" + idDrawing + "'", conn)
            cmb.Items.Clear()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            dt.Columns.Add("Tag")
            While dr.Read()
                cmb.Items.Add(dr("tag"))
                dt.Rows.Add(dr("tag"))
            End While
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarComboCellEquipment(ByRef cmb As DataGridViewComboBoxCell, ByVal idDrawing As String) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEquimentEst from equipmentEst where idDrawingNum = '" + idDrawing + "'", conn)
            cmb.Items.Clear()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            dt.Columns.Add("idEquimentEst")
            While dr.Read()
                cmb.Items.Add(dr("idEquimentEst").ToString())
                dt.Rows.Add(dr("idEquimentEst").ToString())
            End While
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboCellPiping(ByRef cmb As DataGridViewComboBoxCell, ByVal idDrawing As String) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idPipingEst from pipingEst where idDrawingNum = '" + idDrawing + "'", conn)
            cmb.Items.Clear()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            dt.Columns.Add("idPipingEst")
            While dr.Read()
                cmb.Items.Add(dr("idPipingEst").ToString())
                dt.Rows.Add(dr("idPipingEst").ToString())
            End While
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function


    '====================================================================================================================================================================================
    '========== METODOS PARA DRAWING ====================================================================================================================================================
    '====================================================================================================================================================================================
    '====================================================================================================================================================================================
    '========== METODOS PARA DRAWING SCFFOLD PROGRESS ===================================================================================================================================
    '====================================================================================================================================================================================
    Public Function selectSCFProgress(ByVal tbl As DataGridView, ByVal idDrawing As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select scfp.tag as 'TagAux',convert(nvarchar,scfp.weekending,101) as 'weekendigAux',scfp.tag as 'Tag No.',convert(nvarchar,scfp.weekending,101) as 'Weekend',ISNULL(scfp.buildPercent,0) as 'buildPercent',ISNULL(scfp.demoPercent,0) as 'demoPercent' 
from ScaffoldProgress as scfp 
inner join scaffoldEst as scf on scf.tag = scfp.tag
inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
where dr.idDrawingNum = '" + idDrawing + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("TagAux"), dr("weekendigAux"), dr("Tag No."), dr("weekend"), dr("buildPercent"), dr("demoPercent"))
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
                If If(row.Cells(0).Value Is Nothing Or row.Cells(0).Value = "", True, False) Then
                    cmd.CommandText = "	if (select count(*) from ScaffoldProgress where tag='" + row.Cells("Tag").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("Weekend").Value.ToString()) + "')=0
	                    begin
		                    insert into ScaffoldProgress values('" + row.Cells("Tag").Value.ToString() + "','" + validaFechaParaSQl(row.Cells("Weekend").Value.ToString()) + "'," + If(row.Cells("Build").Value Is Nothing Or row.Cells("Build").Value = "", "0", row.Cells("Build").Value.ToString()) + "," + If(row.Cells("Demo").Value Is Nothing Or row.Cells("Demo").Value = "", "0", row.Cells("Demo").Value.ToString()) + ")
	                    end"
                Else
                    cmd.CommandText = "if (select count(*) from ScaffoldProgress where tag='" + row.Cells("TagAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendAux").Value.ToString()) + "')=1
                        begin
	                        update ScaffoldProgress set tag = '" + row.Cells("Tag").Value.ToString() + "' , weekending = '" + validaFechaParaSQl(row.Cells("Weekend").Value.ToString()) + "' , buildPercent = " + If(row.Cells("Build").Value Is Nothing Or row.Cells("Build").Value = "", "0", row.Cells("Build").Value.ToString()) + " , demoPercent = " + If(row.Cells("Demo").Value Is Nothing Or row.Cells("Demo").Value = "", "0", row.Cells("Demo").Value.ToString()) + " where tag = '" + row.Cells("TagAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendAux").Value.ToString()) + "'
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
    Public Function deleteSCFProgress(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = False
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If If(row.Cells(0).Value IsNot Nothing Or row.Cells(0).Value <> "", True, False) And If(row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value <> "", True, False) Then
                    cmd.CommandText = "	if (select count(*) from ScaffoldProgress where tag='" + row.Cells("TagAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendAux").Value.ToString()) + "')=1
                    begin
	                    delete from ScaffoldProgress where tag = '" + row.Cells("TagAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendAux").Value.ToString()) + "'
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
    '========== METODOS PARA DRAWING EQUIPMENT PROGRESS =================================================================================================================================
    '====================================================================================================================================================================================
    Public Function selectEquipmentProgress(ByVal tbl As DataGridView, ByVal idDrawing As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select eqp.tag as 'Tag No.',convert(nvarchar,eqp.weekending,101) as 'Weekend',ISNULL(eqp.insRemoval,0) as 'insRemoval',ISNULL(eqp.insInstall,0) as 'insInstall',ISNULL(eqp.paint,0) as 'paint' 
from equipmentProgress as eqp 
inner join equipmentEst as eqEst on eqEst.idEquimentEst = eqp.tag
inner join drawing as dr on dr.idDrawingNum = eqEst.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
where dr.idDrawingNum = '" + idDrawing + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("Tag No."), dr("weekend"), dr("Tag No."), dr("weekend"), dr("insRemoval"), dr("insInstall"), dr("paint"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveUpdateEqProgress(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = Nothing
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If If(row.Cells(0).Value Is Nothing Or row.Cells(0).Value = "", True, False) Then
                    cmd.CommandText = "if(select count(*) from equipmentProgress where tag = " + row.Cells("EquipmentId").Value.ToString() + " and weekending = '" + validaFechaParaSQl(row.Cells("WeekendEq").Value.ToString()) + "')=0
                        begin
	                        insert into equipmentProgress values (" + row.Cells("EquipmentId").Value.ToString() + ",'" + validaFechaParaSQl(row.Cells("WeekendEq").Value.ToString()) + "'," + If(row.Cells("InsRemovalEq").Value Is Nothing Or row.Cells("InsRemovalEq").Value = "", "0", row.Cells("InsRemovalEq").Value.ToString()) + "," + If(row.Cells("InsInstallEq").Value Is Nothing Or row.Cells("InsInstallEq").Value = "", "0", row.Cells("InsInstallEq").Value.ToString()) + "," + row.Cells("PaintEq").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if(select count(*) from equipmentProgress where tag = " + row.Cells("EquipmentIdAux").Value.ToString() + " and weekending = '" + validaFechaParaSQl(row.Cells("WeekendEqAux").Value.ToString()) + "')=1
                        begin
	                        update equipmentProgress set tag = " + row.Cells("EquipmentId").Value.ToString() + ",weekending = '" + validaFechaParaSQl(row.Cells("WeekendEq").Value.ToString()) + "', insRemoval = " + If(row.Cells("InsRemovalEq").Value Is Nothing Or row.Cells("InsRemovalEq").Value = "", "0", row.Cells("InsRemovalEq").Value.ToString()) + ", insInstall = " + If(row.Cells("InsInstallEq").Value Is Nothing Or row.Cells("InsInstallEq").Value = "", "0", row.Cells("InsInstallEq").Value.ToString()) + ", paint = " + If(row.Cells("PaintEq").Value Is Nothing Or row.Cells("PaintEq").Value = "", "0", row.Cells("PaintEq").Value.ToString()) + " where tag = " + row.Cells("EquipmentIdAux").ToString() + " and weekending ='" + validaFechaParaSQl(row.Cells("WeekendEqAux").ToString()) + "'
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
    Public Function deleteEquipmentProgress(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = False
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If If(row.Cells(0).Value IsNot Nothing Or row.Cells(0).Value <> "", True, False) And If(row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value <> "", True, False) Then
                    cmd.CommandText = "	if (select count(*) from equipmentProgress where tag='" + row.Cells("EquipmentIdAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendEqAux").Value.ToString()) + "')=1
                    begin
	                    delete from equipmentProgress where tag = '" + row.Cells("EquipmentIdAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendEqAux").Value.ToString()) + "'
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
    '========== METODOS PARA DRAWING PIPING PROGRESS ====================================================================================================================================
    '====================================================================================================================================================================================
    Public Function selectPpProgress(ByVal tbl As DataGridView, ByVal idDrawing As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ppp.tag as 'Tag',convert(nvarchar,ppp.weekending,101) as 'weekend',ISNULL(ppp.insRemoval,0) as 'insRemoval',ISNULL(ppp.insInstall,0) as 'insInstall',ISNULL(ppp.paint,0) as 'paint' 
from pipingProgress as ppp 
inner join pipingEst as ppEst on ppEst.idPipingEst = ppp.tag
inner join drawing as dr on dr.idDrawingNum = ppEst.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
where dr.idDrawingNum = '" + idDrawing + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("Tag"), dr("weekend"), dr("Tag"), dr("weekend"), dr("insRemoval"), dr("insInstall"), dr("paint"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveUpdatePpProgress(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = Nothing
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If If(row.Cells(0).Value Is Nothing Or row.Cells(0).Value = "", True, False) Then
                    cmd.CommandText = "if(select count(*) from pipingProgress where tag = " + row.Cells("PipingId").Value.ToString() + " and weekending = '" + validaFechaParaSQl(row.Cells("WeekendPp").Value.ToString()) + "')=0
                        begin
	                        insert into pipingProgress values (" + row.Cells("PipingId").Value.ToString() + ",'" + validaFechaParaSQl(row.Cells("WeekendPp").Value.ToString()) + "'," + If(row.Cells("InsRemovalPP").Value Is Nothing Or row.Cells("InsRemovalPP").Value = "", "0", row.Cells("InsRemovalPP").Value.ToString()) + "," + If(row.Cells("InsInstallPp").Value Is Nothing Or row.Cells("InsInstallPp").Value = "", "0", row.Cells("InsInstallPp").Value.ToString()) + "," + If(row.Cells("PaintPp").Value Is Nothing Or row.Cells("PaintPp").Value = "", "0", row.Cells("PaintPp").Value.ToString()) + ")
                        end"
                Else
                    cmd.CommandText = "if(select count(*) from pipingProgress where tag = " + row.Cells("EquipmentIdAux").Value.ToString() + " and weekending = '" + validaFechaParaSQl(row.Cells("WeekendEqAux").Value.ToString()) + "')=1
                        begin
	                        update pipingProgress set tag = " + row.Cells("PipingId").Value.ToString() + ",weekending = '" + validaFechaParaSQl(row.Cells("WeekendPp").Value.ToString()) + "', insRemoval = " + If(row.Cells("InsRemovalPP").Value Is Nothing Or row.Cells("InsRemovalPP").Value = "", "0", row.Cells("InsRemovalPP").Value.ToString()) + ", insInstall = " + If(row.Cells("InsInstallPp").Value Is Nothing Or row.Cells("InsInstallPp").Value = "", "0", row.Cells("InsInstallPp").Value.ToString()) + ", paint = " + If(row.Cells("PaintPp").Value Is Nothing Or row.Cells("PaintPp").Value = "", "0", row.Cells("PaintPp").Value.ToString()) + " where tag = " + row.Cells("PipingIdAux").ToString() + " and weekending ='" + validaFechaParaSQl(row.Cells("WeekendPpAux").ToString()) + "'
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
    Public Function deletePipingProgress(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction = conn.BeginTransaction
            Dim flag = False
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If If(row.Cells(0).Value IsNot Nothing Or row.Cells(0).Value <> "", True, False) And If(row.Cells(1).Value IsNot Nothing Or row.Cells(1).Value <> "", True, False) Then
                    cmd.CommandText = "	if (select count(*) from pipingProgress where tag='" + row.Cells("PipingIdAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendPpAux").Value.ToString()) + "')=1
                    begin
	                    delete from pipingProgress where tag = '" + row.Cells("PipingIdAux").Value.ToString() + "' and weekending = '" + validaFechaParaSQl(row.Cells("WeekendPpAux").Value.ToString()) + "'
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
