Imports System.Data.SqlClient
Public Class MetodosScaffold
    Inherits ConnectioDB
    Public Function llenarClientsComboBoxCell(ByVal cmb As DataGridViewComboBoxCell) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("Select numberClient , CompanyName from clients where estatus = 'E'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            cmb.Items.Add("")
            While dr.Read()
                cmb.Items.Add(CStr(dr("numberClient")) + " " + dr("CompanyName"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function llenarTablaProjects() As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("if OBJECT_ID('projects','U') IS NOT NULL 
BEGIN 
	print 'exists'
	drop table projects
	select CONCAT(wo.idWO,'-',tk.task)as 'worknum' , tk.task, tk.idAux, wo.idWO,tk.idAuxWO, po.idPO , jb.jobNo , cl.numberClient , cl.idClient
		into projects 
		from task as tk 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
	create clustered index worknum_projects on projects(worknum)
END 
ELSE 
BEGIN
	print 'not exists'
	select CONCAT(wo.idWO,'-',tk.task)as 'worknum' , tk.task, tk.idAux, wo.idWO,tk.idAuxWO, po.idPO , jb.jobNo , cl.numberClient , cl.idClient
		into projects 
		from task as tk 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
	create clustered index worknum_projects on projects(worknum)
END
select * from projects", conn)
            Dim dt As New DataTable

            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("worknum")
                dt.Columns.Add("task")
                dt.Columns.Add("idAux")
                dt.Columns.Add("idWO")
                dt.Columns.Add("idAuxWO")
                dt.Columns.Add("idPO")
                dt.Columns.Add("jobNo")
                dt.Columns.Add("numberClient")
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '========================================================= Job CAT ======================================================================= 
    Public Function llenarComboJobCat(ByVal combo As ComboBox, ByVal idClient As String) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("cmb")
        tabla.Columns.Add("id")
        tabla.Columns.Add("cat")
        tabla.Columns.Add("hours")
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJobCat as 'ID' , cat as 'Description', days as 'Days' from jobCat " + If(idClient = "", "", " where idClient = '" + idClient + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("ID")) + " " + dr("Description"))
                tabla.Rows.Add(CStr(dr("ID")) + " " + dr("Description"), CStr(dr("ID")), CStr(dr("Description")), CStr(dr("Days")))
            End While
            Return tabla
        Catch ex As Exception
            MsgBox(ex.Message())
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarJobCat(ByVal tabla As DataGridView, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJobCat as 'ID' , cat as 'Description' , days as 'Days', ISNULL(CONVERT(NVARCHAR,cl.numberClient),'') as 'Client',ISNULL(CONVERT(NVARCHAR,cl.numberClient),'') as 'Client2'
from jobCat as jc 
left join clients as cl on cl.idClient = jc.idClient " + If(idClient <> "", "where cl.idClient = '" + idClient + "'", ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarJobCat(ByVal tabla As Data.DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJobCat as 'ID' , cat as 'Description' , days as 'Days' from jobCat", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function SaveJobCat(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim array() As String = row.Cells(3).Value().ToString().Split(" ")
                    Dim cmd As New SqlCommand("
declare @JobCat as varchar(25) = '" + row.Cells(0).Value().ToString() + "'
declare @numberClientN as int = " + If(array(0) = "", "0", array(0)) + "
declare @numberClientL as int = " + If(row.Cells(4).Value().ToString() = "", "0", row.Cells(4).Value().ToString()) + "

if (select COUNT(*) from jobCat as jc left join clients as cl on cl.idClient = jc.idClient where jc.idJobCat = @JobCat and (cl.numberClient = @numberClientN or cl.numberClient is Null))=0
begin 
	if (select count(*) from jobCat as jc left join clients as cl on cl.idClient = jc.idClient where jc.idJobCat = @JobCat and (cl.numberClient = @numberClientL or cl.numberClient is Null)) = 0
	begin
		insert into jobCat values(@JobCat,'" + row.Cells(1).Value().ToString() + "'," + row.Cells(2).Value().ToString() + ",(select idclient from clients where numberClient = @numberClientN)) 
	end
	else if (select count(*) from jobCat as jc left join clients as cl on cl.idClient = jc.idClient where jc.idJobCat = @JobCat and (cl.numberClient = @numberClientL or cl.numberClient is Null)) = 1
	begin 
		update jobCat set cat ='" + row.Cells(1).Value().ToString() + "',[days] = " + row.Cells(2).Value().ToString() + ",idClient = (select idclient from clients where numberClient = @numberClientN)  where idJobCat=@JobCat
	end
end
else if (select COUNT(*) from jobCat as jc left join clients as cl on cl.idClient = jc.idClient where jc.idJobCat = @JobCat and (cl.numberClient = @numberClientN or cl.numberClient is Null))=1
begin
	update jobCat set cat ='" + row.Cells(1).Value().ToString() + "',[days] = " + row.Cells(2).Value().ToString() + ",idClient = (select idclient from clients where numberClient = @numberClientN) where idJobCat=@JobCat
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsJobCat(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select COUNT(*) from jobCat where idJobCat = '" + row.Cells(0).Value.ToString() + "' ) = 1
begin 
	delete from jobCat where idJobCat = '" + row.Cells(0).Value.ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Areas ======================================================================= 
    Public Function llenarComboArea(ByVal combo As ComboBox, ByVal idClient As String) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("cmb")
        tabla.Columns.Add("id")
        tabla.Columns.Add("name")
        Try
            conectar()
            Dim cmd As New SqlCommand("select idArea as 'ID', name as 'Name' from areas " + If(idClient = "", "", " where idClient = '" + idClient + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("ID")) + "    " + dr("Name"))
                tabla.Rows.Add(CStr(dr("ID")) + "    " + dr("Name"), CStr(dr("ID")), CStr(dr("Name")))
            End While
            Return tabla
        Catch ex As Exception
            MsgBox(ex.Message())
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarAreas(ByVal tabla As DataGridView, ByVal idCliente As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ar.idArea as 'Area ID', ar.name as 'Area Name', cordinator AS 'Cordinator' , ISNULL(CONVERT(NVARCHAR,cl.numberClient),'') as 'Client',ISNULL(CONVERT(NVARCHAR,cl.numberClient),'') as 'Client2'
from areas as ar 
left join clients as cl on cl.idClient = ar.idClient " + If(idCliente <> "", "where cl.idClient = '" + idCliente + "'", ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarAreas(ByVal tabla As Data.DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ar.idArea as 'Area ID', ar.name as 'Area Name', cordinator AS 'Cordinator' from areas as ar", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function SaveAreas(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim array() As String = row.Cells(3).Value().ToString().Split(" ")
                    Dim cmd As New SqlCommand("
declare @numberClientL as int = " + If(row.Cells(4).Value().ToString() = "", "0", row.Cells(4).Value().ToString()) + "
declare @numberClientN as int = " + If(array(0) = "", "0", array(0)) + "
declare @idArea as int = " + row.Cells(0).Value().ToString() + "

if (select count(*) from areas as ar left join clients as cl on cl.idClient = ar.idClient where ar.idArea = @idArea and (cl.numberClient = @numberClientN or cl.numberClient is Null)) = 0
begin
	if (select count(*) from areas as ar left join clients as cl on cl.idClient = ar.idClient where ar.idArea = @idArea and (cl.numberClient = @numberClientL or cl.numberClient is Null)) = 0
	begin
		insert into areas values(@idArea,'" + row.Cells(1).Value().ToString() + "','" + row.Cells(2).Value().ToString() + "',(select idclient from clients where numberClient = @numberClientN)) 
	end
	else if (select count(*) from areas as ar left join clients as cl on cl.idClient = ar.idClient where ar.idArea = @idArea and (cl.numberClient = @numberClientL or cl.numberClient is Null)) = 1
	begin 
		update areas set name ='" + row.Cells(1).Value().ToString() + "',cordinator = '" + row.Cells(2).Value().ToString() + "',idClient = (select idclient from clients where numberClient = @numberClientN)  where idArea=@idArea
	end
end
else if (select count(*) from areas as ar left join clients as cl on cl.idClient = ar.idClient where ar.idArea = @idArea and (cl.numberClient = @numberClientN or cl.numberClient is Null)) = 1
begin
	update areas set name ='" + row.Cells(1).Value().ToString() + "',cordinator = '" + row.Cells(2).Value().ToString() + "',idClient = (select idclient from clients where numberClient = @numberClientN) where idArea=@idArea
end 
", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsAreas(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from areas where idArea = " + row.Cells(0).Value.ToString() + ")= 1
begin
	delete from areas where idArea = " + row.Cells(0).Value.ToString() + "
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= WO ==========================================================================

    Public Function llenarTableWO(ByVal tabla As DataTable, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select CONCAT(wo.idWO,'-',tk.task) as 'WO No',wo.idWO, tk.idAux, tk.idAuxWO,jb.jobNo as 'Job No' ,tk.description as 'Description',cl.idClient
from job as jb 
	inner join clients as cl on cl.idClient = jb.idClient 
    inner join projectOrder as po on po.jobNo = jb.jobNo
    inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.jobNo
    inner join task as tk on tk.idAuxWO = wo.idAuxWO " + If(idClient = "ALL", "", " where cl.idClient = '" + idClient + "'"), conn)
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboWO(ByVal combo As ComboBox, Optional IdCliente As String = "", Optional jobNo As String = "") As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("wono")
        tabla.Columns.Add("wo")
        tabla.Columns.Add("task")
        tabla.Columns.Add("job")
        tabla.Columns.Add("description")
        tabla.Columns.Add("cmb")
        Try
            conectar()
            Dim cmd As New SqlCommand("select CONCAT(wo.idWO,'-',tk.task) as 'WO No',wo.idWO, tk.idAux, jb.jobNo as 'Job No' ,tk.description as 'Description'
from job as jb 
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.jobNo
inner join task as tk on tk.idAuxWO = wo.idAuxWO " + If(IdCliente = "", "", "where jb.idClient = '" + IdCliente + "' ") + If(jobNo = "", "", If(IdCliente = "", " where jb.jobNo = " + jobNo, " and jb.jobNo = " + jobNo)) + " Order by 'WO No'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            combo.Items.Add("")
            While dr.Read()
                combo.Items.Add(CStr(dr("WO No")) + " " + CStr(dr("Job No")) + " " + dr("Description"))
                tabla.Rows.Add(CStr(dr("WO No")), CStr(dr("idWO")), CStr(dr("idAux")), CStr(dr("Job No")), CStr(dr("Description")), (CStr(dr("WO No")) + " " + CStr(dr("Job No")) + " " + dr("Description")))
            End While
            Return tabla
        Catch ex As Exception
            MsgBox(ex.Message())
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarWO(ByVal tabla As DataGridView, Optional IdCliente As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo as 'Job No', CONCAT(wo.idWO,'-',tk.task) as 'WO No', tk.description as 'Description'
from job as jb 
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO
inner join task as tk on tk.idAuxWO = wo.idAuxWO " + If(IdCliente = "", "", "where jb.idClient = '" + IdCliente + "'"), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function existWO(ByVal Workorder As String, ByVal JobNum As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select count(*) as 'num' from projects as pj
where pj.worknum = '" + Workorder + "' and pj.jobNo = " + JobNum + "", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim exist As Boolean = False
            While dr.Read
                exist = If(CInt(dr("num")) > 0, True, False)
            End While
            Return exist
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Sub Jobs ====================================================================
    Public Function llenarComboSubJob(ByVal combo As ComboBox, ByVal idClient As String) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("cmb")
        tabla.Columns.Add("subJob")
        tabla.Columns.Add("description")
        Try
            conectar()
            Dim cmd As New SqlCommand("select idSubJob as 'Sub Job', description as 'Description' from subJobs " + If(idClient = "", "", " where idClient = '" + idClient + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("Sub Job")) + "    " + dr("Description"))
                tabla.Rows.Add(CStr(dr("Sub Job")) + "    " + dr("Description"), CStr(dr("Sub Job")), CStr(dr("Description")))
            End While
            Return tabla
        Catch ex As Exception
            MsgBox(ex.Message())
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarSubJobs(ByVal tabla As DataGridView, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select sj.idSubJob as 'Sub Job', sj.description as 'Description', ISNULL(CONVERT(NVARCHAR,cl.numberClient),'') as 'Client',ISNULL(CONVERT(NVARCHAR,cl.numberClient),'') as 'Client2'
from subJobs as sj 
left join clients as cl on cl.idClient = sj.idClient " + If(idClient <> "", " where cl.idClient = '" + idClient + "'", ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarSubJobs(ByVal tabla As Data.DataTable) As Boolean
        Try
            conectar()
            tabla.Clear()
            Dim cmd As New SqlCommand("select idSubJob as 'Sub Job', description as 'Description' from subJobs", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveSubJobs(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim array() As String = row.Cells(2).Value().ToString().Split(" ")
                    Dim cmd As New SqlCommand("
declare @SubJob as int = " + row.Cells(0).Value().ToString() + "
declare @numberClientN as int = " + If(array(0) = "", "0", array(0)) + "
declare @numberClientL as int = " + If(row.Cells(3).Value().ToString() = "", "0", row.Cells(3).Value().ToString()) + "

if (select COUNT(*) from subJobs as sj left join clients as cl on cl.idClient = sj.idClient where sj.idSubJob = @SubJob and (cl.numberClient = @numberClientN or cl.numberClient is Null))=0
begin 
	if (select count(*) from subJobs as sj left join clients as cl on cl.idClient = sj.idClient where sj.idSubJob= @SubJob and (cl.numberClient = @numberClientL or cl.numberClient is Null)) = 0
	begin
		insert into subJobs values(@SubJob,'" + row.Cells(1).Value().ToString() + "',(select idclient from clients where numberClient = @numberClientN)) 
	end
	else if (select count(*) from subJobs as sj  left join clients as cl on cl.idClient = sj.idClient where sj.idSubJob = @SubJob and (cl.numberClient = @numberClientL or cl.numberClient is Null)) = 1
	begin 
		update subJobs set [description] ='" + row.Cells(1).Value().ToString() + "', idClient = (select idclient from clients where numberClient = @numberClientN)  where idSubJob=@SubJob
	end
end
else if (select COUNT(*) from subJobs as sj left join clients as cl on cl.idClient = sj.idClient where sj.idSubJob = @SubJob and (cl.numberClient = @numberClientN or cl.numberClient is Null))=1
begin
	update subJobs set [description] ='" + row.Cells(1).Value().ToString() + "',idClient = (select idclient from clients where numberClient = @numberClientN) where idSubJob=@SubJob	
end ", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsSubJobs(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from subJobs where idSubJob = " + row.Cells(0).Value.ToString() + ")= 1
begin
	delete from subJobs where idSubJob = " + row.Cells(0).Value.ToString() + "
end ", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= JobNum =====================================================================
    Public Function llenarJobCombo(ByVal combo As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select jobNo from job", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                combo.Items.Add(reader("jobNo"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarJobCombo(ByVal combo As ComboBox, ByVal idclient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from job as jb where jb.idClient like '" + If(idclient Is Nothing, "%%", idclient) + "'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                combo.Items.Add(reader("jobNo"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Empleados =================================================================
    Public Function llenarEmpleadosCombo(ByVal combo As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select numberEmploye , CONCAT(lastName,' ',firstName,' ',middleName) as 'name' from employees", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("numberEmploye")) + " " + dr("name"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarEmpleadosCombo(ByVal combo As ComboBox, ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEmployee, CONCAT(firstName,' ',middleName,' ',lastName) , photo as 'Photo', SAPNumber, numberEmploye from employees where estatus = 'E' ", conn)
            If tabla IsNot Nothing Then
                tabla.Rows.Clear()
            End If
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
            End If
            If combo.Items.Count > 0 Then
                combo.Items.Clear()
            End If
            For Each row As DataRow In tabla.Rows
                combo.Items.Add(row.ItemArray(1))
            Next
            If combo.Items.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Classificaation ===========================================================

    Public Sub llenarCellComboClass(ByVal combo As DataGridViewComboBoxCell)
        Try
            conectar()
            Dim cmd As New SqlCommand("select class as class from classification", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                combo.Items.Add(dr("class"))
            End While
        Catch ex As Exception
        Finally
            desconectar()
        End Try
    End Sub

    Public Function llenarClassification(ByVal tabla As Data.DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select class as 'Material', name as 'Name' from classification", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.Rows.Clear()
                tabla.Columns.Clear()
                tabla = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarClassification(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select class as 'Material', name as 'Name' from classification", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveClassification(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from classification where class = '" + row.Cells(0).Value().ToString() + "') = 0
begin 
	insert into classification values('" + row.Cells(0).Value().ToString() + "','" + row.Cells(1).Value().ToString() + "')
end
else if (select count(*) from classification where class = '" + row.Cells(0).Value().ToString() + "') = 1
begin
	update classification set name ='" + row.Cells(1).Value().ToString() + "' where class = '" + row.Cells(0).Value().ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveClassification(ByVal tabla As DataTable) As Integer
        Dim cont As Integer = 0
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            For Each row As DataRow In tabla.Rows()
                If row.ItemArray(0).ToString() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from classification where class = '" + row.ItemArray(0).ToString() + "') = 0
begin 
	insert into classification values('" + row.ItemArray(0).ToString() + "','" + row.ItemArray(1).ToString() + "')
end
else if (select count(*) from classification where class = '" + row.ItemArray(0).ToString() + "') = 1
begin
	update classification set name ='" + row.ItemArray(1).ToString() + "' where class = '" + row.ItemArray(0).ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return 0
            Else
                tran.Rollback()
                MsgBox("Error at line " + (cont))
                Return cont + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return cont + 1
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsClassification(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from classification where class = '" + row.Cells(0).Value.ToString() + "') = 1
begin 
	delete from classification where class = '" + row.Cells(0).Value.ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Unit Meassurement =========================================================
    Public Sub llenarCellComboUM(ByVal combo As DataGridViewComboBoxCell)
        Try
            conectar()
            Dim cmd As New SqlCommand("select um as um from unitMeassurements", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                combo.Items.Add(dr("um"))
            End While
        Catch ex As Exception
        Finally
            desconectar()
        End Try
    End Sub

    Public Function llenarUnitMeassurements(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select um as 'Unit', name as 'Name' from unitMeassurements", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarUnitMeassurements(ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select um as 'Unit', name as 'Name' from unitMeassurements", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveUnitMeassurement(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from unitMeassurements where um = '" + row.Cells(0).Value().ToString() + "')=0
begin 
	insert into unitMeassurements values('" + row.Cells(0).Value().ToString() + "','" + row.Cells(1).Value().ToString() + "')
end
else if (select count(*) from unitMeassurements where um = '" + row.Cells(0).Value().ToString() + "')=1
begin 
	update unitMeassurements set name = '" + row.Cells(1).Value().ToString() + "' where um= '" + row.Cells(0).Value().ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveUnitMeassurement(ByVal tabla As DataTable) As Boolean
        Dim cont As Integer = 0
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            For Each row As DataRow In tabla.Rows()
                If row.ItemArray(0) IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from unitMeassurements where um = '" + row.ItemArray(0).ToString() + "')=0
begin 
	insert into unitMeassurements values('" + row.ItemArray(0).ToString() + "','" + row.ItemArray(1).ToString() + "')
end
else if (select count(*) from unitMeassurements where um = '" + row.ItemArray(0).ToString() + "')=1
begin 
	update unitMeassurements set name = '" + row.ItemArray(1).ToString() + "' where um= '" + row.ItemArray(0).ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return 0
            Else
                tran.Rollback()
                Return cont + 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return cont + 1
        Finally
            desconectar()
        End Try
    End Function
    Public Function DeleteRowsUnitMeassurements(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from unitMeassurements where um = '" + row.Cells(0).Value.ToString() + "' )=1
begin 
	delete from unitMeassurements where um = '" + row.Cells(0).Value.ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Material Status =========================================================
    Public Function BuscarExistenciasPorStatus(ByVal idproducto As String, ByVal status As String) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select top(1)* from existencesProduct where idProduct = " + idproducto + " and idMaterialStatus = '" + status + "'", conn)
            Dim list As New List(Of String)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim flag As Boolean = False
            While dr.Read()
                list.Add(dr("idExitenciaProduct"))
                list.Add(dr("idMaterialStatus"))
                list.Add(dr("quantity"))
                flag = True
            End While
            If flag = False Then
                list.Add("")
                list.Add(status)
                list.Add("0")
            End If
            Return list
        Catch ex As Exception
            Dim listN As New List(Of String)
            listN.Add("")
            listN.Add(status)
            listN.Add("0")
            Return listN
        Finally
            desconectar()
        End Try
    End Function


    Public Sub llenarCellComboStatus(ByVal combo As DataGridViewComboBoxCell, ByVal idproducto As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(If(idproducto = "", "select * from materialStatus", "select idMaterialStatus from existencesProduct where idProduct = " + idproducto + ""), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                combo.Items.Add(dr("idMaterialStatus"))
            End While
        Catch ex As Exception
        Finally
            desconectar()
        End Try
    End Sub

    Public Function llenarMaterialStatus(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from materialStatus", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveMaterialStatus(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from materialStatus where idMaterialStatus = '" + row.Cells(0).Value().ToString() + "' )=0
begin 
	insert into materialStatus values('" + row.Cells(0).Value().ToString() + "')
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveMaterialStatus(ByVal MaterialStatus As List(Of String)) As Integer
        Dim cont As Integer = 1
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Integer = 0
            For Each dato As String In MaterialStatus
                If MaterialStatus IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from materialStatus where idMaterialStatus = '" + dato + "' )=0
begin 
	insert into materialStatus values('" + dato + "')
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery Then
                        flag = 0
                    Else
                        flag = cont
                    End If
                End If
            Next
            If flag = 0 Then
                tran.Commit()
                Return flag
            Else
                tran.Rollback()
                Return flag
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return cont
        Finally
            desconectar()
        End Try
    End Function

    Public Function updateMaterialStatus(ByVal nuevo As String, ByVal viejo As String) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            Dim cmd As New SqlCommand("
if (select count(*) from materialStatus where idMaterialStatus = '" + viejo + "' )=1
begin 
	update materialStatus set idMaterialStatus = '" + nuevo + "' where idMaterialStatus = '" + viejo + "'
end", conn)
            cmd.Transaction = tran
            If cmd.ExecuteNonQuery = 1 Then
                cont += 1
            Else
                tran.Rollback()
                flag = False
            End If
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsMaterialStatus(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from materialStatus where idMaterialStatus = '" + row.Cells(0).Value.ToString() + "' )=1
begin 
	delete from materialStatus where idMaterialStatus = '" + row.Cells(0).Value.ToString() + "'
end ", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Rental ===================================================================
    Public Function llenarRentaTypeCombo(ByVal combo As DataGridViewComboBoxCell) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select type from rental", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While reader.Read()
                combo.Items.Add(reader("type"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarRental(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select type as 'TYPE', CONVERT( varchar,leg,1 )as 'LEG$', plk as 'PLK',CONVERT(VARCHAR, deck, 1) as 'DECK$',CONVERT(VARCHAR, ladder,1) as 'LADDER$',truckLoad as 'Truck Load',CONVERT(VARCHAR, truck,1) as'Truck $' from rental", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarRental(ByVal tabla As Data.DataTable) As Boolean
        Try
            conectar()
            tabla.Clear()
            Dim cmd As New SqlCommand("select type as 'TYPE' from rental", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveRentalTable(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from rental where type = '" + row.Cells(0).Value.ToString() + "')=0
begin 
	insert into rental values('" + row.Cells(0).Value.ToString() + "'," + If(row.Cells(1).Value.ToString() = "", 0.0, row.Cells(1).Value.ToString.Replace(",", "")) + "," + If(row.Cells(2).Value.ToString() = "", 0.0, row.Cells(2).Value.ToString()) + "," + If(row.Cells(3).Value.ToString() = "", 0.0, row.Cells(3).Value.ToString.Replace(",", "")) + "," + If(row.Cells(4).Value.ToString() = "", 0.0, row.Cells(4).Value.ToString.Replace(",", "")) + "," + If(row.Cells(5).Value.ToString() = "", 0.0, row.Cells(5).Value.ToString()) + "," + If(row.Cells(6).Value.ToString() = "", 0.0, row.Cells(6).Value.ToString.Replace(",", "")) + ")
end
else if (select count(*) from rental where type = '" + row.Cells(0).Value.ToString() + "')=1
begin 
	update rental set leg = " + If(row.Cells(1).Value.ToString() = "", 0.0, row.Cells(1).Value.ToString.Replace(",", "")) + ",plk = " + If(row.Cells(2).Value.ToString() = "", 0.0, row.Cells(2).Value.ToString()) + ",deck= " + If(row.Cells(3).Value.ToString() = "", 0.0, row.Cells(3).Value.ToString().Replace(",", "")) + ",ladder= " + If(row.Cells(4).Value.ToString() = "", 0.0, row.Cells(4).Value.ToString()) + ",truck= " + If(row.Cells(5).Value.ToString() = "", 0.0, row.Cells(5).Value.ToString.Replace(",", "")) + ",truckLoad= " + If(row.Cells(6).Value.ToString() = "", 0.0, row.Cells(6).Value.ToString.Replace(",", "")) + " where type = '" + row.Cells(0).Value.ToString() + "'
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsRentalTable(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.SelectedRows()
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
 if (select count(*) from rental where type = '" + row.Cells(0).Value.ToString() + "')=1
begin 
    delete from rental where type = '" + row.Cells(0).Value.ToString() + "'	
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 1 Then
                        cont += 1
                    Else
                        tran.Rollback()
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                MsgBox("Error at line " + (cont + 1))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Supervisor ================================================================

    Public Function llenarSupervisor(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select numberEmploye as 'Employee ID', CONCAT(lastName,', ',middleName,' ',firstName)as 'Name', ct.phoneNumber1 as 'Phone',ct.phoneNumber2 as 'Movil' ,ct.email
from employees  as ep inner join contact as ct on ep.idContact = ct.idContact
where typeEmployee = 'Manager'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================== Product =====================================================================

    Public Function llenarProduct(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select pd.idProduct  as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,
quantity as 'QTY', pd.QID,PLF, PSQF
from product as pd 
inner join unitMeassurements as um on pd.um = um.um
inner join classification as cl on cl.class = pd.class
order by pd.idProduct", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarProduct(ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select pd.idProduct  as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,
quantity as 'QTY' , pd.QID, PLF, PSQF
from product as pd 
inner join unitMeassurements as um on pd.um = um.um
inner join classification as cl on cl.class = pd.class
order by pd.idProduct", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarProductByJobNo(ByVal tabla As DataTable, Optional jobNo As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select pd.idProduct as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,
pj.qty as 'QTY' , pd.QID, PLF, PSQF , pj.jobNo
from productJob as pj 
inner join product as pd on pd.idProduct = pj.idProduct
inner join unitMeassurements as um on pd.um = um.um
inner join classification as cl on cl.class = pd.class
" + If(jobNo = "", "", " where pj.jobNo = " + jobNo), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveProduct(ByVal tabla As DataTable) As List(Of Integer)
        Dim cont = 0
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Dim flag As Boolean = True
        Dim listFilasError As New List(Of Integer)
        Try
            For Each row As DataRow In tabla.Rows()
                Dim nameProduct = row.ItemArray(1).ToString.Replace("'", "''")
                Dim consultaProduct As New SqlCommand("
if (select count(*) from product as p where p.name= '" + nameProduct + "' or p.idProduct = " + row.ItemArray(0).ToString() + " or p.QID = '" + row.ItemArray(11).ToString() + "' ) = 0
begin 
    insert into product values(" + row.ItemArray(0).ToString() + ",'" + nameProduct + "'," + If(row.ItemArray(5).ToString() = "", "0", row.ItemArray(5).ToString()) + "," + If(row.ItemArray(6).ToString() = "", "0", row.ItemArray(6).ToString()) + "," + If(row.ItemArray(4).ToString() = "", "0.0", row.ItemArray(4).ToString()) + "," + If(row.ItemArray(7).ToString() = "", "0", row.ItemArray(7).ToString()) + "," + If(row.ItemArray(8).ToString() = "", "0", row.ItemArray(8).ToString()) + "," + If(row.ItemArray(9).ToString() = "", "0", row.ItemArray(9).ToString()) + ",'" + row.ItemArray(11).ToString() + "' ,'" + row.ItemArray(2).ToString() + "','" + row.ItemArray(3).ToString() + "', " + If(row.ItemArray(10).ToString() = "", "0", row.ItemArray(10).ToString()) + " , " + If(row.ItemArray(12).ToString() = "", "0", row.ItemArray(12).ToString()) + " , " + If(row.ItemArray(13).ToString() = "", "0", row.ItemArray(13).ToString()) + ")
end", conn)
                consultaProduct.Transaction = tran
                If consultaProduct.ExecuteNonQuery > 0 Then
                    cont += 1
                    flag = True
                Else
                    listFilasError.Add(cont)
                    flag = False
                End If
            Next
            If listFilasError.Count() > 0 Then
                If DialogResult.OK = MessageBox.Show("We found a errors in " + listFilasError.Count.ToString() + " rows Would you like to insert the other Records?", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) Then
                    tran.Commit()
                Else
                    tran.Rollback()
                End If
            Else
                tran.Commit()
            End If
            Return listFilasError
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            listFilasError.Add(cont)
            Return listFilasError
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveProducto(ByVal tabla As DataGridView, ByVal flagAllRows As Boolean) As List(Of Integer)
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Dim listError As New List(Of Integer)
        Try
            Dim flag As Integer = 0
            For Each row As DataGridViewRow In If(flagAllRows, tabla.Rows(), tabla.SelectedRows())
                If row.Cells(0).Value IsNot Nothing Then 'No es la ultima fila 
                    Dim nameProduct = row.Cells(1).Value.ToString.Replace("'", "''")
                    Dim cmd As New SqlCommand(
"if (select count(*) from product as p where p.name= '" + nameProduct + "' or p.idProduct = " + row.Cells(0).Value.ToString() + " or p.QID = '" + row.Cells(11).Value.ToString + "' ) = 0
begin 
    insert into product values(" + row.Cells(0).Value.ToString() + ",'" + nameProduct + "'," + If(row.Cells(4).Value.ToString() = "", "0.0", row.Cells(4).Value.ToString()) + "," + If(row.Cells(5).Value.ToString() = "", "0.0", row.Cells(5).Value.ToString()) + "," + If(row.Cells(6).Value.ToString() = "", "0.0", row.Cells(6).Value.ToString()) + "," + If(row.Cells(7).Value.ToString() = "", "0.0", row.Cells(7).Value.ToString()) + "," + If(row.Cells(8).Value.ToString() = "", "0.0", row.Cells(8).Value.ToString()) + "," + If(row.Cells(9).Value.ToString() = "", "0.0", row.Cells(9).Value.ToString()) + ",'" + row.Cells(11).Value.ToString() + "' ,'" + row.Cells(2).Value.ToString() + "','" + row.Cells(3).Value.ToString() + "', " + row.Cells(10).Value.ToString() + "," + row.Cells(12).Value.ToString() + "," + row.Cells(13).Value.ToString() + ")
end
else if(select count(*) from product as p where p.name= '" + nameProduct + "' or p.idProduct = " + row.Cells(0).Value.ToString() + "  or p.QID = '" + row.Cells(12).Value.ToString() + "' )=1
begin
	update product set name = '" + nameProduct + "' ,weight= " + If(row.Cells(4).Value.ToString() = "", "0.0", row.Cells(4).Value.ToString()) + ", weightMeasure = " + If(row.Cells(5).Value.ToString() = "", "0.0", row.Cells(5).Value.ToString()) + ",price = " + If(row.Cells(6).Value.ToString() = "", "0.0", row.Cells(6).Value.ToString()) + ", dailyRentalRate= " + If(row.Cells(7).Value.ToString() = "", "0.0", row.Cells(7).Value.ToString()) + " ,weeklyRentalRate = " + If(row.Cells(8).Value.ToString() = "", "0.0", row.Cells(8).Value.ToString()) + ",monthlyRentalRate = " + If(row.Cells(9).Value.ToString() = "", "0.0", row.Cells(9).Value.ToString()) + ", QID = '" + row.Cells(11).Value.ToString() + "', um='" + row.Cells(2).Value.ToString() + "',class='" + row.Cells(3).Value.ToString() + "',quantity = " + If(row.Cells(10).Value.ToString() = "", "0.0", row.Cells(10).Value.ToString()) + " , PLF = " + If(row.Cells(12).Value.ToString() = "", "0.0", row.Cells(12).Value.ToString()) + ",PSQF = " + If(row.Cells(13).Value.ToString() = "", "0.0", row.Cells(13).Value.ToString()) + " where idProduct = " + row.Cells(0).Value.ToString() + "
end", conn)
                    cmd.Transaction = tran
                        If cmd.ExecuteNonQuery > 0 Then
                            flag = +1
                        Else
                            listError.Add(flag)
                        End If

                End If
            Next
            If listError.Count = 0 Then
                tran.Commit()
            Else
                tran.Rollback()
            End If
            Return listError
        Catch ex As Exception
            tran.Rollback()
            Return listError
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarProduct(ByVal tabla As DataGridView, ByVal text As String, ByVal flagIdProduct As Boolean) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select pd.idProduct  as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,
quantity as 'QTY', pd.QID,PLF, PSQF
from product as pd 
inner join unitMeassurements as um on pd.um = um.um
inner join classification as cl on cl.class = pd.class " +
If(flagIdProduct, "where pd.idProduct = " + text + " or pd.QID = '" + text + "'", "where pd.name like '%" + text + "%' or pd.class Like '%" + text + "%' or cl.name like '%" + text + "%'") + " order by pd.idProduct", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim tablaAux As New DataTable
                da.Fill(tablaAux)
                tabla.DataSource = tablaAux
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarProductByJob(ByVal tabla As DataGridView, ByVal text As String, ByVal jobNo As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
select pd.idProduct, price, um,pd.name, pdj.qty as 'quantity',PLF, PSQF from productJob as pdj
inner join product as pd on pd.idProduct = pdj.idProduct
inner join classification as cl on cl.class = pd.class 
where (pd.idProduct like '%" + text + "%' or pd.QID like '%" + text + "%' or pd.name like '%" + text + "%' or cl.class Like '%" + text + "%' or cl.name like '%" + text + "%') and pdj.JobNo = " + jobNo + "
order by pd.idProduct", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim tablaAux As New DataTable
                da.Fill(tablaAux)
                tabla.DataSource = tablaAux
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarProductByJob(ByVal tabla As DataTable, ByVal jobNo As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select pd.idProduct, price, um,pd.name, pdj.qty as 'quantity',PLF, PSQF from productJob as pdj
inner join product as pd on pd.idProduct = pdj.idProduct
inner join classification as cl on cl.class = pd.class 
where pdj.JobNo = " + jobNo + "
order by pd.idProduct", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteRowsProducto(ByVal tabla As DataGridView, ByVal flagAllStatus As Boolean) As Boolean
        Try
            conectar()
            For Each row As DataGridViewRow In tabla.SelectedRows()
                Dim cmd As New SqlCommand("delete From product Where idProduct = " + row.Cells("ID").Value.ToString(), conn)
                cmd.ExecuteNonQuery()
            Next
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= In Comming ===========================================================
    Public Function llenarTicketsIncoming(ByVal tblTicketsIncoming As DataTable) As List(Of String)
        Dim list As New List(Of String)
        Try
            conectar()
            Dim cmdInComing As New SqlCommand("select * from incoming", conn)
            If cmdInComing.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmdInComing)
                tblTicketsIncoming.Clear()
                da.Fill(tblTicketsIncoming)
                If tblTicketsIncoming.Rows.Count > 0 Then
                    list.Add(tblTicketsIncoming.Rows(0).ItemArray(0))
                    list.Add(tblTicketsIncoming.Rows(0).ItemArray(1))
                    list.Add(tblTicketsIncoming.Rows(0).ItemArray(2))
                    list.Add(tblTicketsIncoming.Rows(0).ItemArray(3))
                    list.Add(tblTicketsIncoming.Rows(0).ItemArray(4))
                End If
            End If
            Return list
        Catch ex As Exception
            MsgBox(ex.Message())
            Return list
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarPoductosIncoming(ByVal tblProductosIncoming As DataGridView, ByVal idTicket As String) As Boolean
        Try
            conectar()
            Dim cmdPrductosInComing As New SqlCommand
            cmdPrductosInComing.CommandText = "select pic.quantity as 'QTY',pic.idProduct as 'ID',pd.price as '$UM',pd.um as 'UM',pd.name as 'Product Description' ,idProductInComing from productComing as pic inner join product as pd on pd.idProduct = pic.idProduct 
where ticketNum = '" + idTicket + "'"
            cmdPrductosInComing.Connection = conn
            If cmdPrductosInComing.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmdPrductosInComing)
                da.Fill(dt)
                tblProductosIncoming.Rows.Clear()
                For Each row As DataRow In dt.Rows()
                    tblProductosIncoming.Rows.Add(row.ItemArray())
                Next
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarInComming(ByVal tblProductos As DataGridView, ByVal tblTickets As DataTable, ByVal idClient As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            conectar()
            Dim cmdInComing As New SqlCommand("select * from incoming as inc " + If(idClient = "", "", "inner join job as jb on inc.jobNo = jb.jobNo where jb.idClient = '" + idClient + "'"), conn)
            If cmdInComing.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmdInComing)
                tblTickets.Clear()
                da.Fill(tblTickets)
                If tblTickets.Rows.Count > 0 Then
                    list.Add(tblTickets.Rows(0).ItemArray(0))
                    list.Add(tblTickets.Rows(0).ItemArray(1))
                    list.Add(tblTickets.Rows(0).ItemArray(2))
                    list.Add(tblTickets.Rows(0).ItemArray(3))
                    list.Add(tblTickets.Rows(0).ItemArray(4))
                End If
            End If
            Dim cmdPrductosInComing As New SqlCommand
            If list.Count > 0 Then
                cmdPrductosInComing.CommandText = "select pic.quantity as 'QTY',pic.idProduct as 'ID',pd.price as '$UM',pd.um as 'UM',pd.name as 'Product Description' ,idProductInComing from productComing as pic inner join product as pd on pd.idProduct = pic.idProduct 
where ticketNum = '" + list(0) + "'"
                cmdPrductosInComing.Connection = conn
            Else
                cmdPrductosInComing.CommandText = "select pic.quantity as 'QTY',pic.idProduct as 'ID',pd.price as '$UM',pd.um as 'UM',pd.name as 'Product Description' ,idProductInComing from productComing as pic inner join product as pd on pd.idProduct = pic.idProduct"
                cmdPrductosInComing.Connection = conn
            End If
            If cmdPrductosInComing.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmdPrductosInComing)
                da.Fill(dt)
                For Each row As DataRow In dt.Rows()
                    tblProductos.Rows.Add(row.ItemArray())
                Next
            End If
            Return list
        Catch ex As Exception
            MsgBox(ex.Message)
            Return list
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarTablaProductosIcomminOutgoing(ByVal tblProducts As DataTable, Optional jobno As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("", conn)
            If jobno <> "" Then
                cmd.CommandText = "select pd.idProduct, price, um,name, pdj.qty as 'quantity',PLF, PSQF from productJob as pdj
inner join product as pd on pd.idProduct = pdj.idProduct
where jobNo = " + jobno + ""
            Else
                cmd.CommandText = "select idProduct, price, um,name,quantity,PLF,PSQF from product"
            End If
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tblProducts)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function llenarTablaProductosByJobNo(ByVal tblProducts As DataGridView, Optional jobno As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("", conn)
            If jobno <> "" Then
                '                cmd.CommandText = "select pd.idProduct, price, um,name, pdj.qty as 'quantity',PLF, PSQF,QID from productJob as pdj
                'inner join product as pd on pd.idProduct = pdj.idProduct
                'where jobNo = " + jobno + ""
                cmd.CommandText = "select pd.idProduct, price, um,name, 
ISNULL((select sum(pinc.quantity) from productComing as pinc 
inner join incoming as inc on inc.ticketNum = pinc.ticketNum
where inc.jobNo = pdj.jobNo and pinc.idProduct = pdj.idProduct),0)
-
ISNULL((select sum(pout.quantity) from productOutGoing as pout 
inner join outgoing as outg on outg.ticketNum = pout.ticketNum
where outg.jobNo = pdj.jobNo and pout.idProduct = pdj.idProduct),0) as 'quantity',
PLF, PSQF,QID from productJob as pdj
inner join product as pd on pd.idProduct = pdj.idProduct
where jobNo =" + jobno
            Else
                cmd.CommandText = "select idProduct, price, um,name,quantity,PLF,PSQF,QID from product"
            End If
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblProducts.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function cargarDatosProductUtlization(ByVal tblSc As DataGridView, ByVal tblMd As DataGridView, ByVal tblDs As DataGridView, ByVal tblIn As DataGridView, ByVal tblOg As DataGridView, ByVal idproduct As String, Optional jobNO As String = "") As Boolean
        Try
            conectar()
            Dim cmdSC As New SqlCommand("select sc.tag, psc.idProduct,psc.quantity,CONVERT(varchar,sc.buildDate,101) as buildDate from productScaffold as psc 
inner join scaffoldTraking as sc on sc.tag = psc.tag
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb .jobNo = po.jobNo
where idProduct = " + idproduct + If(jobNO = "", "", " and jb.jobNo=" + jobNO + ""), conn)
            Dim dr1 As SqlDataReader = cmdSC.ExecuteReader()
            tblSc.Rows.Clear()
            While dr1.Read()
                tblSc.Rows.Add(dr1("tag"), dr1("idProduct"), dr1("quantity"), dr1("buildDate"))
            End While
            dr1.Close()

            Dim cmdMd As New SqlCommand("select md.tag, md.idModification, pmd.idProduct ,pmd.quantity,CONVERT(varchar,md.modificationDate,101) as modificationDate from productModification as pmd
inner join modification as md on md.idModAux = pmd.idModAux
inner join scaffoldTraking as sc on sc.tag = md.tag 
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO  and po.jobNo = wo.jobNo 
inner join job as jb on jb .jobNo = po.jobNo
where idProduct = " + idproduct + If(jobNO = "", "", " and jb.jobNo=" + jobNO + ""), conn)
            Dim dr2 As SqlDataReader = cmdMd.ExecuteReader()
            tblMd.Rows.Clear()
            While dr2.Read()
                tblMd.Rows.Add(dr2("tag"), dr2("idModification"), dr2("idProduct"), dr2("quantity"), dr2("modificationDate"))
            End While
            dr2.Close()

            Dim cmdDs As New SqlCommand("select ds.tag , pds.idProduct,pds.quantity,CONVERT(varchar,ds.dismantleDate,101)as dismantleDate from productDismantle as pds 
inner join dismantle as ds on ds.idDismantle = pds.idDismantle
inner join scaffoldTraking as sc on sc.tag = ds.tag 
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb .jobNo = po.jobNo
where idProduct = " + idproduct + If(jobNO = "", "", " and jb.jobNo=" + jobNO + ""), conn)
            Dim dr3 As SqlDataReader = cmdDs.ExecuteReader()
            tblDs.Rows.Clear()
            While dr3.Read()
                tblDs.Rows.Add(dr3("tag"), dr3("idProduct"), dr3("quantity"), dr3("dismantleDate"))
            End While
            dr3.Close()

            Dim cmdIn As New SqlCommand("select inc.ticketNum , CONVERT(varchar,inc.dateRecived,101) as dateRecived,pin.idProduct,pin.quantity from productComing as pin 
inner join incoming  as inc on inc.ticketNum = pin.ticketNum
where pin.idProduct = " + idproduct + If(jobNO = "", "", " and inc.jobNo=" + jobNO + ""), conn)
            Dim dr4 As SqlDataReader = cmdIn.ExecuteReader()
            tblIn.Rows.Clear()
            While dr4.Read()
                tblIn.Rows.Add(dr4("ticketNum"), dr4("dateRecived"), dr4("idProduct"), dr4("quantity"))
            End While
            dr4.Close()

            Dim cmdOg As New SqlCommand("select outg.ticketNum , CONVERT(varchar,outg.dateShipped,101) as dateShipped,pout.idProduct,pout.quantity from productOutGoing as pout 
inner join outgoing as outg on outg.ticketNum = pout.ticketNum
where pout.idProduct = " + idproduct + If(jobNO = "", "", " and outg.jobNo=" + jobNO + ""), conn)
            Dim dr5 As SqlDataReader = cmdOg.ExecuteReader()
            tblOg.Rows.Clear()
            While dr5.Read()
                tblOg.Rows.Add(dr5("ticketNum"), dr5("dateShipped"), dr5("idProduct"), dr5("quantity"))
            End While
            dr5.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboProductUtilization(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idProduct , name , quantity from product", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(CStr(dr("idProduct")) + "  " + CStr(dr("name")) + "  " + CStr(dr("quantity")))
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
    Public Function selectJobBytag(ByVal tag As String) As String
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from  scaffoldTraking as sc
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where tag like '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim job As String = ""
            While dr.Read()
                job = dr("jobNo")
            End While
            dr.Close()
            If job <> "" Then
                Return job
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarCellComboIDProduct(ByVal cmb As DataGridViewComboBoxCell, ByVal tablaPoductoIncoming As DataTable, Optional jobNo As String = "0") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand(If(jobNo = "", "select concat(idProduct,'    ',name)as product , idProduct, price, um,name,quantity,PLF,PSQF from product","select concat(pd.idProduct,'    ',pd.name)as product , pd.idProduct, pd.price, pd.um,pd.name,pj.qty,pd.PLF,pd.PSQF from productJob as pj inner join product as pd on pd.idProduct = pj.idProduct
where pj.jobNo = " + jobNo + ""), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                cmb.Items.Add(dr("product"))
            End While
            dr.Close()
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tablaPoductoIncoming)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarCellComboIDProductExistences(ByVal cmb As DataGridViewComboBoxCell, ByVal tablaPoductoIncoming As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select concat(idProduct,'    ',name)as product , idProduct, price, um,name,quantity,PLF, PSQF from product where quantity > 0", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                cmb.Items.Add(dr("product"))
            End While
            dr.Close()
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tablaPoductoIncoming)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarCellComboIdProductExistByJobNNo(ByVal cmb As DataGridViewComboBoxCell, ByVal jobNo As String, ByVal tablaPoductoJob As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select concat(pd.idProduct,'    ',name)as product , pd.idProduct, price, um,name, pdj.qty,PLF, PSQF jobNo , pdj.jobNo from productJob as pdj
inner join product as pd on pd.idProduct = pdj.idProduct
where jobNo = " + jobNo + "", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                cmb.Items.Add(dr("product"))
            End While
            dr.Close()
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tablaPoductoJob)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveInComing(ByVal tblProductos As DataGridView, ByVal datosTicket As List(Of String), ByVal allRows As Boolean) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Dim cont = 0
        Try
            Dim cmd As New SqlCommand("
If (select count(*) from incoming where ticketNum = '" + datosTicket(0) + "')= 0
begin 
	insert into incoming values ('" + datosTicket(0) + "','" + datosTicket(1) + "', '" + datosTicket(2) + "' ,'" + datosTicket(3) + "'," + datosTicket(4) + ")
end 
else if(select count(*) from incoming where ticketNum = '" + datosTicket(0) + "')=1
begin 
	update incoming set dateRecived='" + datosTicket(1) + "',recivedBy='" + datosTicket(2) + "',comment='" + datosTicket(3) + "',jobNo = " + datosTicket(4) + " where ticketNum = '" + datosTicket(0) + "'
end", conn)
            cmd.Transaction = tran
            Dim flag = True
            If cmd.ExecuteNonQuery Then
                For Each row As DataGridViewRow In If(allRows, tblProductos.Rows(), tblProductos.SelectedRows())
                    If row.Cells(0).Value IsNot Nothing Then
                        Dim Product = row.Cells(1).Value.ToString.Split(" ")
                        Dim cmdproduct As New SqlCommand("
if (select count(*) from productComing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "' )=0
begin 
	insert into productComing values(NEWID(),'" + datosTicket(0) + "'," + Product(0) + "," + row.Cells(0).Value.ToString() + ")
	update product set quantity = quantity + " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + "

    if (select COUNT(*) from productJob where idProduct = " + Product(0) + " and jobNo = " + datosTicket(4) + ")=0
    begin
	    insert into productJob values (" + Product(0) + ", " + datosTicket(4) + " , " + row.Cells(0).Value.ToString() + ")
    end 
    else
    begin 
	    update productJob set qty = qty + " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + " and jobNo = " + datosTicket(4) + "
    end

end
else if(select count(*) from productComing where idProduct =  " + Product(0) + " and ticketNum = '" + datosTicket(0) + "')=1
begin 
	update product set quantity = quantity - (select quantity from productComing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "') where idProduct = " + Product(0) + "
	update productComing set quantity = " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "'
	update product set quantity = quantity + " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + "
    update productJob set qty = qty + " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + " and jobNo = " + datosTicket(4) + "
end", conn)
                        cmdproduct.Transaction = tran
                        If cmdproduct.ExecuteNonQuery > 0 Then
                            flag = True
                            cont += 1
                        Else
                            flag = False
                            Exit For
                        End If
                    End If
                Next
                If flag Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    MsgBox("Error in the row " + CStr(cont + 1))
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
            Return True
        Catch ex As Exception
            tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteInComing(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Try
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            If tbl.SelectedRows.Count() > 0 Then
                For Each row As DataGridViewRow In tbl.SelectedRows()
                    If row.Cells("idProductInComing").Value <> "" Then
                        Dim idProduct() = row.Cells("ID").Value.ToString().Split("  ")
                        Dim cmdUpdateProduct As New SqlCommand("update product set quantity = quantity - (select quantity from productComing where idProductInComing = '" + row.Cells("idProductInComing").Value.ToString() + "') where idProduct = " + idProduct(0) + "", conn)
                        cmdUpdateProduct.Transaction = tran
                        If cmdUpdateProduct.ExecuteNonQuery > 0 Then
                            Dim cmdDeleteInComing As New SqlCommand("delete from productComing where idProductInComing = '" + row.Cells("idProductInComing").Value.ToString() + "'", conn)
                            cmdDeleteInComing.Transaction = tran
                            If cmdDeleteInComing.ExecuteNonQuery > 0 Then
                                flag = True
                                cont += 1
                            Else
                                flag = False
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                MessageBox.Show("Error at line " + CStr(cont) + ". We probably could not find it.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarComboIncommingTicket(ByVal cmb As ComboBox, Optional ByVal jobNo As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ticketNum from incoming" + If(jobNo = "", "", " where jobNo = '" + jobNo + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("ticketNum").ToString())
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '========================================================= Out Going ===========================================================

    Public Function llenarProductosOutGoing(ByVal tblProductosOutGoing As DataGridView, ByVal ticketOutGoing As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select po.quantity,po.idProduct, pd.um , pd.price , pd.name ,po.idProductOutGoing from productOutGoing as po inner join product as pd on po.idProduct = pd.idProduct 
where po.ticketNum = '" + ticketOutGoing + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tblProductosOutGoing.Rows.Clear()
                For Each row As DataRow In dt.Rows()
                    tblProductosOutGoing.Rows.Add(row.ItemArray())
                Next
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarTicketsOutGoing(ByVal tblTicketsOut As DataTable) As List(Of String)
        Dim list As New List(Of String)
        Try
            conectar()
            Dim cmdInComing As New SqlCommand("select * from outgoing", conn)
            If cmdInComing.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmdInComing)
                tblTicketsOut.Clear()
                da.Fill(tblTicketsOut)
                If tblTicketsOut.Rows.Count > 0 Then
                    list.Add(tblTicketsOut.Rows(0).ItemArray(0))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(1))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(2))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(3))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(4))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(5))
                End If
            End If
            Return list
        Catch ex As Exception
            MsgBox(ex.Message())
            Return list
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarOutGoing(ByVal tblProductosOutGoing As DataGridView, ByVal tblTicketsOut As DataTable, ByVal idClient As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            conectar()
            Dim cmdInComing As New SqlCommand("select * from outgoing as otg " + If(idClient = "", "", " inner join job as jb on otg.jobNo = jb.jobNo where jb.idClient = '" + idClient + "'"), conn)
            If cmdInComing.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmdInComing)
                tblTicketsOut.Clear()
                da.Fill(tblTicketsOut)
                If tblTicketsOut.Rows.Count > 0 Then
                    list.Add(tblTicketsOut.Rows(0).ItemArray(0))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(1))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(2))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(3))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(4))
                    list.Add(tblTicketsOut.Rows(0).ItemArray(5))
                End If
            End If
            Dim cmdPrductosInComing As New SqlCommand("select po.quantity,po.idProduct, pd.um , pd.price , pd.name ,po.idProductOutGoing from productOutGoing as po inner join product as pd on po.idProduct = pd.idProduct " + If(list.Count > 0, "where po.ticketNum = '" + list(0) + "'", ""), conn)
            If cmdPrductosInComing.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmdPrductosInComing)
                da.Fill(dt)
                For Each row As DataRow In dt.Rows()
                    tblProductosOutGoing.Rows.Add(row.ItemArray())
                Next
            End If
            Return list
        Catch ex As Exception
            MsgBox(ex.Message)
            Return list
        Finally
            desconectar()
        End Try
    End Function

    Public Function custumerJobNum(ByVal jobNum As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select CONCAT(cl.firstName,' ',cl.lastName,'',cl.middleName) as 'Costumer', CONCAT(ha.number , ' th, ',ha.avenue,' ',ha.providence,', ',ha.city,' ',ha.postalCode) as HomeAddress from 
job as jb 
inner join clients as cl on jb.idClient = cl.idClient 
inner join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress
where jb.jobNo = " + If(jobNum = "", 0, jobNum), conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                list.Add(rd("Costumer"))
                list.Add(rd("HomeAddress"))
            End While
            Return list
        Catch ex As Exception
            MsgBox(ex.Message())
            Return list
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveOutGoing(ByVal tblProductos As DataGridView, ByVal datosTicket As List(Of String), ByVal allRows As Boolean) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Dim cont = 0
        Try
            Dim cmd As New SqlCommand("
if (select COUNT(*) from outgoing where ticketNum = '" + datosTicket(0) + "' ) =0
begin 
	insert into outgoing values('" + datosTicket(0) + "','" + datosTicket(1) + "','" + datosTicket(2) + "','" + datosTicket(3) + "','" + datosTicket(4) + "'," + datosTicket(5) + ")
end
else if(select COUNT(*) from outgoing where ticketNum = '" + datosTicket(0) + "')=1
begin 
	update outgoing set dateShipped = '" + datosTicket(1) + "',comment= '" + datosTicket(2) + "' , shippedby='" + datosTicket(3) + "',superintendent = '" + datosTicket(4) + "',jobNo = " + datosTicket(5) + " where ticketNum = '" + datosTicket(0) + "'
end", conn)
            cmd.Transaction = tran
            Dim flag = True
            If cmd.ExecuteNonQuery Then
                For Each row As DataGridViewRow In If(allRows, tblProductos.Rows(), tblProductos.SelectedRows())
                    If row.Cells(0).Value IsNot Nothing Then
                        Dim Product() = row.Cells(1).Value.ToString.Split(" ")
                        Dim cmdproduct As New SqlCommand("
if (select COUNT(*) from productOutGoing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "')=0 
begin
	insert into productOutGoing values (NEWID(),'" + datosTicket(0) + "'," + Product(0) + "," + CStr(row.Cells(0).Value) + ")
	update product set quantity = quantity - " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + "
    update productJob set qty = qty - " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + " and jobNo = " + datosTicket(5) + "    
end
else if(select COUNT(*) from productOutGoing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "' )= 1
begin
	update product set quantity = quantity + (select quantity from productOutGoing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "') where idProduct = " + Product(0) + "
	update productOutGoing set quantity = " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "'
	update product set quantity = quantity - " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + "
    update productJob set qty = qty - " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + " and jobNo = " + datosTicket(5) + "
end", conn)
                        cmdproduct.Transaction = tran
                        If cmdproduct.ExecuteNonQuery > 0 Then
                            flag = True
                            cont += 1
                        Else
                            flag = False
                            Exit For
                        End If
                    End If
                Next
                If flag Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    MsgBox("Error in the row " + CStr(cont + 1))
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
            Return True
        Catch ex As Exception
            tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function DeleteOutGoing(ByVal tbl As DataGridView, ByVal JobNo As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Try
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            If tbl.SelectedRows.Count() > 0 Then
                For Each row As DataGridViewRow In tbl.SelectedRows()
                    If CStr(row.Cells(1).Value) <> "" And row.Cells(5).Value IsNot Nothing Then
                        Dim idProduct() = row.Cells(1).Value.ToString().Split("  ")
                        Dim cmdUpdateProduct As New SqlCommand("update product set quantity = quantity + (select quantity from productOutGoing where idProductOutGoing = '" + row.Cells(5).Value.ToString() + "') where idProduct = " + idProduct(0) + "", conn)
                        cmdUpdateProduct.Transaction = tran
                        If cmdUpdateProduct.ExecuteNonQuery > 0 Then
                            Dim cmdUpdateProductJob As New SqlCommand("update productJob set qty = qty + " + CStr(row.Cells(1).Value) + " where idProduct = " + idProduct(0) + " and jobNo = " + JobNo + "", conn)
                            cmdUpdateProductJob.Transaction = tran
                            If cmdUpdateProductJob.ExecuteNonQuery > 0 Then
                                Dim cmdDeleteInComing As New SqlCommand("delete from productOutGoing where idProductOutGoing = '" + row.Cells(5).Value.ToString() + "'", conn)
                                cmdDeleteInComing.Transaction = tran
                                If cmdDeleteInComing.ExecuteNonQuery > 0 Then
                                    flag = True
                                    cont += 1
                                Else
                                    flag = False
                                    Exit For
                                End If
                            Else
                                flag = False
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                MessageBox.Show("Error at line " + CStr(cont) + ". We probably could not find it.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboOutGoingTicket(ByVal cmb As ComboBox, Optional ByVal jobNo As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ticketNum from outgoing" + If(jobNo = "", "", " where jobNo = '" + jobNo + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("ticketNum").ToString())
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    '========================================= SCAFFOLD TRAKING ==============================================================

    Public Function llenarComboContact(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select contact from scaffoldTraking", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindStringExact(dr("contact")) = -1 Or cmb.FindStringExact(dr("contact")) = 0 Then
                    cmb.Items.Add(dr("contact"))
                End If
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarScaffold(ByVal tabla As DataTable, ByVal idCliente As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag, st.idAux,idJobCat,idArea,idSubJob, CONCAT(wo.idWO,'-',tk.task)as 'WO',st.status from scaffoldTraking as st
inner join task as tk on tk.idAux = st.idAux
inner join workOrder as wo on tk.idAuxWO = wo.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo inner join job as jb on jb.jobNo = po.jobNo" +
If(idCliente = "", "", " where jb.idClient='" + idCliente + "'"), conn)
            tabla.Rows.Clear()
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarScaffold(ByVal tag As String) As scaffold
        Dim sc As New scaffold
        Try
            conectar()
            Dim cmdDatosScaffold As New SqlCommand("select top 1 * from scaffoldTraking where tag ='" + tag + "'", conn)
            Dim dr As SqlDataReader = cmdDatosScaffold.ExecuteReader()
            While dr.Read()
                sc.tag = dr("tag")
                sc.dateBild = validarFechaParaVB(dr("buildDate"))
                sc.location = dr("location")
                sc.purpose = dr("location")
                sc.comments = dr("comments")
                sc.dateRecComp = validarFechaParaVB(dr("reqComp"))
                sc.contact = dr("contact")
                sc.foreman = dr("foreman")
                sc.erector = dr("erector")
                sc.task = dr("idAux")
                sc.jobcat = dr("idJobCat")
                sc.areaID = CStr(dr("idArea"))
                sc.idsubJob = CStr(dr("idSubJob"))
                sc.status = If(dr("status") = "f", False, True)
                sc.days = CInt(dr("days"))
                sc.latitude = dr("latitude")
                sc.longitude = dr("longitude")
                Exit While
            End While
            dr.Close()
            If sc.task <> Nothing Then
                Dim cmdTaskWorkOrder As New SqlCommand("select top 1 CONCAT(wo.idWO,'-',tk.task)as 'Wo' ,tk.description from workOrder as wo
inner join task as tk on wo.idAuxWO = tk.idAuxWO where tk.idAux = '" + sc.task + "'", conn)
                Dim dr1 As SqlDataReader = cmdTaskWorkOrder.ExecuteReader()
                While dr1.Read()
                    sc.wo = dr1("Wo")
                    sc.descriptionWO = dr1("description")
                    Exit While
                End While
                dr1.Close()
            End If
            If sc.jobcat <> Nothing Then
                Dim cmdJobCat As New SqlCommand("select top 1 cat from jobCat where idjobCAt = '" + sc.jobcat + "'", conn)
                Dim dr2 As SqlDataReader = cmdJobCat.ExecuteReader()
                While dr2.Read()
                    sc.category = dr2("cat")
                    Exit While
                End While
                dr2.Close()
            End If
            If sc.areaID <> Nothing Then
                Dim cmdAreaId As New SqlCommand("select top 1 name from areas where idArea = " + sc.areaID, conn)
                Dim dr3 As SqlDataReader = cmdAreaId.ExecuteReader(0)
                While dr3.Read()
                    sc.area = dr3("name")
                    Exit While
                End While
                dr3.Close()
            End If
            If sc.idsubJob <> Nothing Then
                Dim cmdSubJobs As New SqlCommand("select top 1 description from subJobs where idSubJob = " + sc.idsubJob, conn)
                Dim dr4 As SqlDataReader = cmdSubJobs.ExecuteReader()
                While dr4.Read()
                    sc.subjob = dr4("description")
                    Exit While
                End While
                dr4.Close()
            End If
            '================================ activuty hours ===============================================
            Dim cmdActivityHours As New SqlCommand("select top 1 * from activityHours where tag = '" + sc.tag + "'", conn)
            Dim dr5 As SqlDataReader = cmdActivityHours.ExecuteReader()
            While dr5.Read()
                sc.ahrIdActivityHours = dr5("idActivityHours")
                sc.ahrBuild = dr5("build")
                sc.ahrMaterial = dr5("material")
                sc.ahrTravel = dr5("travel")
                sc.ahrWeather = dr5("weather")
                sc.ahrAlarm = dr5("alarm")
                sc.ahrSafety = dr5("safety")
                sc.ahrOther = dr5("other")
                sc.ahrTotal = sc.ahrBuild + sc.ahrMaterial + sc.ahrTravel + sc.ahrWeather + sc.ahrAlarm + sc.ahrSafety + sc.ahrOther
                Exit While
            End While
            dr5.Close()
            '================================ scaffold information =========================================
            Dim cmdScaffoldInformation As New SqlCommand("select top 1 * from scaffoldInformation where tag = '" + tag + "'", conn)
            Dim dr6 As SqlDataReader = cmdScaffoldInformation.ExecuteReader()
            While dr6.Read()
                sc.idScaffoldinformation = dr6("idscaffoldInformation")
                sc.sciType = If(dr6("type") Is DBNull.Value, "", dr6("type"))
                sc.sciWidth = dr6("width")
                sc.sciLength = dr6("length")
                sc.sciHeigth = dr6("heigth")
                sc.sciDecks = dr6("descks")
                sc.sciKo = dr6("ko")
                sc.sciBase = dr6("base")
                sc.sciExtraDeck = dr6("extraDeck")
                Exit While
            End While
            dr6.Close()
            sc.products = sc.llenarTablaProductTag(sc.tag)
            sc.scfInfo = sc.llenarScfInfo(sc.tag)
            sc.materialHandeling = sc.llenarmaterialHandeling(sc.tag)
            Return sc
        Catch ex As Exception
            Return sc
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveScaffoldTraking(ByVal sc As scaffold) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Dim flagComplete As Boolean = True
        Try
            Dim falgTag As Boolean = True
            Dim cmdTraking As New SqlCommand("
if (select count(*) from scaffoldTraking where tag = '" + sc.tag + "') = 0
begin 
	insert into scaffoldTraking values('" + sc.tag + "','" + validaFechaParaSQl(sc.dateBild) + "','" + sc.location + "','" + sc.purpose + "','" + sc.comments + "','" + validaFechaParaSQl(sc.dateRecComp) + "','" + sc.contact + "','" + sc.foreman + "','" + sc.erector + "','" + sc.task + "','" + sc.jobcat + "'," + sc.areaID + "," + sc.idsubJob + ",'" + If(sc.status = True, "t", "f") + "', (select top 1 days from jobCat where idJobCat = '" + sc.jobcat + "' and idClient = '" + sc.IDClient + "') ," + sc.longitude.ToString() + "," + sc.latitude.ToString() + ")
end
else if (select count(*) from scaffoldTraking where tag = '" + sc.tag + "') = 1
begin 
	update scaffoldTraking set buildDate = '" + validaFechaParaSQl(sc.dateBild) + "',location = '" + sc.location + "',purpose ='" + sc.purpose + "',comments='" + sc.comments + "',reqComp='" + validaFechaParaSQl(sc.dateRecComp) + "',contact='" + sc.contact + "',foreman='" + sc.foreman + "',erector='" + sc.erector + "',idAux='" + sc.task + "',idJobCat='" + sc.jobcat + "',idArea=" + sc.areaID + ",idSubJob=" + sc.idsubJob + ", status = '" + If(sc.status = True, "t", "f") + "',days=" + CStr(sc.days) + " , longitude = " + CStr(sc.longitude) + ", latitude = " + CStr(sc.latitude) + " where tag= '" + sc.tag + "'
end", conn)
            cmdTraking.Transaction = tran
            If cmdTraking.ExecuteNonQuery > 0 Then 'si entra se tubo que insertar o actualizar si no hubo un error 
                Dim cmdScaffoflInfo As New SqlCommand("
if (select count(*) from scaffoldInformation where tag ='" + sc.tag + "' and idModAux is Null)=0
begin 
	insert into scaffoldInformation values(NEWID()," + If(sc.sciType = "", "Null", "'" + sc.sciType + "'") + "," + CStr(sc.sciWidth) + "," + CStr(sc.sciLength) + "," + CStr(sc.sciHeigth) + "," + CStr(sc.sciDecks) + "," + CStr(sc.sciKo) + "," + CStr(sc.sciBase) + "," + CStr(sc.sciExtraDeck) + ",'" + sc.tag + "',Null)
end
else if(select count(*) from scaffoldInformation where tag ='" + sc.tag + "' and idModAux is Null)=1 
begin 
	update scaffoldInformation set type=" + If(sc.sciType = "", "Null", "'" + sc.sciType + "'") + ",width=" + CStr(sc.sciWidth) + ",length=" + CStr(sc.sciLength) + ",heigth=" + CStr(sc.sciHeigth) + ",descks=" + CStr(sc.sciDecks) + ",ko=" + CStr(sc.sciKo) + ",base=" + CStr(sc.sciBase) + ",extraDeck=" + CStr(sc.sciExtraDeck) + " where idScaffoldInformation = '" + sc.idScaffoldinformation + "'
end", conn)
                cmdScaffoflInfo.Transaction = tran
                If cmdScaffoflInfo.ExecuteNonQuery Then 'si entra se tubo que insertar o actulzar la tabla de ScaffoldInformation
                    Dim cmdHours As New SqlCommand("
if (select count(*) from activityHours where tag ='" + sc.tag + "'  and idModAux is Null and idDismantle is Null)=0
begin 
	insert into activityHours values(NEWID()," + CStr(sc.ahrBuild) + "," + CStr(sc.ahrMaterial) + "," + CStr(sc.ahrTravel) + "," + CStr(sc.ahrWeather) + "," + CStr(sc.ahrAlarm) + "," + CStr(sc.ahrSafety) + "," + CStr(sc.ahrStdBy) + "," + CStr(sc.ahrOther) + ",'" + sc.tag + "',Null,Null)
end
else if(select count(*) from activityHours where tag ='" + sc.tag + "'  and idModAux is Null and idDismantle is Null)=1
begin 
	update activityHours set build=" + CStr(sc.ahrBuild) + ",material=" + CStr(sc.ahrMaterial) + ",travel=" + CStr(sc.ahrTravel) + ",weather=" + CStr(sc.ahrWeather) + ",alarm=" + CStr(sc.ahrAlarm) + ",safety=" + CStr(sc.ahrSafety) + ",stdBy=" + CStr(sc.ahrStdBy) + ",other=" + CStr(sc.ahrOther) + " where idActivityHours = '" + sc.ahrIdActivityHours + "'
end ", conn)
                    cmdHours.Transaction = tran
                    If cmdHours.ExecuteNonQuery > 0 Then 'si entra se tubo que insertar o actulzar la tabla de Activity Hours
                        Dim cmdScfInfo As New SqlCommand("
if(select count(*) from scfInfo where tag ='" + sc.tag + "')=0
begin
	insert into scfInfo values(NEWID(),'" + If(sc.scfInfo(0), "t", "f") + "','" + If(sc.scfInfo(1), "t", "f") + "','" + If(sc.scfInfo(2), "t", "f") + "','" + If(sc.scfInfo(3), "t", "f") + "','" + sc.tag + "')
end
else if(select count(*) from scfInfo where tag ='" + sc.tag + "')=1
begin 
	update scfInfo set csap='" + If(sc.scfInfo(0), "t", "f") + "',rolling='" + If(sc.scfInfo(1), "t", "f") + "',internal='" + If(sc.scfInfo(2), "t", "f") + "',hanging='" + If(sc.scfInfo(3), "t", "f") + "' where tag='" + sc.tag + "'
end", conn)
                        cmdScfInfo.Transaction = tran
                        If cmdScfInfo.ExecuteNonQuery > 0 Then 'si entra se tubo que isertar o actualizarr la tabla de scfInfo 
                            Dim cmdMaterialHandeling As New SqlCommand("
if (select count(*) from materialHandeling where tag='" + sc.tag + "' and idModAux is Null and idDismantle is Null)=0
begin 
	insert into materialHandeling values(NEWID(),'" + If(sc.materialHandeling(0), "t", "f") + "','" + If(sc.materialHandeling(1), "t", "f") + "','" + If(sc.materialHandeling(2), "t", "f") + "','" + If(sc.materialHandeling(3), "t", "f") + "','" + If(sc.materialHandeling(4), "t", "f") + "','" + If(sc.materialHandeling(5), "t", "f") + "','" + If(sc.materialHandeling(6), "t", "f") + "','" + sc.tag + "',Null,Null)
end
else if (select count(*) from materialHandeling where tag='" + sc.tag + "' and idModAux is Null and idDismantle is Null)=1
begin
	update materialHandeling set truck='" + If(sc.materialHandeling(0), "t", "f") + "',forklift='" + If(sc.materialHandeling(1), "t", "f") + "',trailer='" + If(sc.materialHandeling(2), "t", "f") + "',crane='" + If(sc.materialHandeling(3), "t", "f") + "',rope='" + If(sc.materialHandeling(4), "t", "f") + "',passed='" + If(sc.materialHandeling(5), "t", "f") + "',elevator='" + If(sc.materialHandeling(6), "t", "f") + "' where idMaterialHandeling ='" + sc.idMaterialHandeling + "' 
end", conn)
                            cmdMaterialHandeling.Transaction = tran
                            If cmdMaterialHandeling.ExecuteNonQuery > 0 Then 'Si entro se tubo que insertar o actualzar la tabla de Material handeling
                                Dim contProduct As Integer = 1
                                For Each row As DataRow In sc.products.Rows() 'Aqui se ejecuta las fila de la tabla de productosScaffold
                                    Dim array = CStr(row.ItemArray(1)).Split(" ")
                                    Dim idProduct = array(0)
                                    Dim cmdProduct As New SqlCommand("
declare @idPS as varchar(36)
declare @qty as float
declare @idProduct as int
declare @tag as varchar(20)
declare @lQTY as float 
declare @lIdProduct as int
declare @jobNo as bigint

set @idPS = '" + row.ItemArray(0).ToString() + "'
set @idProduct = " + idProduct + "
set @qty = " + row.ItemArray(2).ToString() + "
set @tag = '" + sc.tag + "'
set @jobNo = " + sc.job + "

if @idPS = ''
begin
	if(select count(*) from productScaffold where idProduct=@idProduct and tag = @tag)=0
	begin --NO HAY PRODUCTO EN PRODUCTSCAFFOLD REGISTRADO
		set @idPS = NEWID()
		insert into productScaffold values (@idPS,@tag,@idProduct,@qty)
		if (select COUNT(*) from productTotalScaffold where tag= @tag and idProduct = @idProduct)=0
		begin --DE NO EXISTIR EN PTS SE TIENE QUE AGREGAR A LA LISTA TOTAL DE PRODUCTOS
			insert into productTotalScaffold values(newid(),@qty,@idProduct,@tag,'t')
		end
		else --DE LO CONTRARIO SE ACTUALIZA EL VALOR 
		begin 
			update productTotalScaffold set quantity = (select quantity from productTotalScaffold where tag = @tag and idProduct = @idProduct)+@qty where idProduct =@idProduct and tag = @tag
		end
		update product set quantity = (select quantity from product where idProduct = @idProduct) - @qty where idProduct = @idProduct
		update productJob set qty = qty - @qty where idProduct = @idProduct and jobNo = @jobNo
	end
	else if (select count(*) from productScaffold where idProduct=@idProduct and tag = @tag)>0
	begin--SI HAY PRODUCTO EN PRODUCTSCAFFOLD REGISTRADO CON ESE TAG PERO NO ESTABA EN LA LISTA
		set @idPS = (select top 1 idProductScafold from productScaffold where idProduct = @idProduct and tag = @tag)
		set @lQTY = (select top 1 quantity from productScaffold where idProductScafold=@idPS) --OBTENGO LA CANTIDAD ANTERIORS
		update product set quantity = quantity + @lQTY where idProduct = @idProduct--RECUPERO LA CANTIDAD QUITADA EN EL ANTERIOR
		update productScaffold set quantity = @qty where idProductScafold = @idPS --ACTUALIZO LA CANTIDAD EN PTS
		update productJob set qty  = qty + @lQTY where idProduct = @idProduct and jobNo = @jobNo --RECUPERO LA CANTIDAD DEL QUE YA SE INSERTO Y LA VUELVO A SUMAR
		update productJob set qty  = qty - @qty where idProduct = @idProduct and jobNo = @jobNo --DISMINULLO LA CANTIDAD DEL VALOR ACTUAL ENVIADO
		update product set quantity = quantity - @qty where idProduct = @idProduct --DIMINULLO LA CANTIDAD DEL VALOR ACTUAL ENVIADO
		
		if (select COUNT(*) from productTotalScaffold where tag= @tag and idProduct = @idProduct)=0
		begin --DE NO EXISTIR EN PTS SE TIENE QUE AGREGAR A LA LISTA TOTAL DE PRODUCTOS
			insert into productTotalScaffold values(newid(),@qty,@idProduct,@tag,'t')
		end
		else --DE LO CONTRARIO SE ACTUALIZA EL VALOR 
		begin 
			update productTotalScaffold set quantity = (quantity - (@lQTY)) where idProduct = @idProduct and tag = @tag
			update productTotalScaffold set quantity = (quantity + (@qty)) where idProduct = @idProduct and tag = @tag
		end
	end
end
else if @idPS <> ''
begin --EXISTE UN IDPRODUCTSCAFFOLD 
	if(select count(idProduct) from productScaffold where idProductScafold =@idPS and idProduct = @idProduct)=1
	begin --EL PRODUCTO COINCIDE CON EL IDPRODCUTSACFFOLD SOLO SE ACTUALIZAN LOS VALORES
		set @lQTY =  (select top 1 quantity from productScaffold where idProductScafold = @idPS)
		update product set quantity = quantity + @lQTY where idProduct = @idProduct--RECUPARO LA CANTIDAD INSERTADA ANTERIORMENTE AL STOCK GENERAL
		update product set quantity = quantity - @qty where idProduct = @idProduct--DISMINULLO LA CANTIDAD ACTUAL AL STOCK GENERAL
		update productTotalScaffold set quantity = quantity - @lQTY where idProduct = @idProduct and tag = @tag--
		update productTotalScaffold set quantity = quantity + @qty where idProduct = @idProduct and tag = @tag
		update productScaffold set quantity = @qty where idProductScafold = @idPS
		update productJob set qty  = qty + @lQTY where idProduct = @idProduct and jobNo = @jobNo --RECUPERO LA CANTIDAD DEL QUE YA SE INSERTO Y LA VUELVO A SUMAR
		update productJob set qty  = qty - @qty where idProduct = @idProduct and jobNo = @jobNo --DISMINULLO LA CANTIDAD DEL VALOR ACTUAL 
	end
	else --EL PRODUCTO CAMBIO EN EL REGISTRO DEL IDPRODUCTSCAFFOLD 
	begin 
		-- REGRESANDO EL STOCK AL PRODUCTO VIEJO
		set @lQTY = (select top 1 quantity from productScaffold where idProductScafold = @idPS)
		set @lIdProduct =(select top 1 idProduct from productScaffold where idProductScafold = @idPS)
		print @lQTY
		print @lIdProduct
		update product set quantity = quantity + @lQTY where idProduct = @lIdProduct
		update productJob set qty = qty + @lQTY where idProduct = @lIdProduct and jobNo = @jobNo
		update productTotalScaffold set quantity = quantity - @lQTY where idProduct = @lIdProduct and tag = @tag
		-- ACTUALIZANDO EL STOCK DEL PRODUCT NUEVO
		update product set quantity = quantity - @qty where idProduct = @idProduct
		update productJob set qty = qty - @qty where idProduct = @idProduct and jobNo = @jobNo
		if (select COUNT(*) from productTotalScaffold where idProduct = @idProduct and tag = @tag)=0
		begin--NO TIENE REGISTRO EN TOTAL SACAFFOLD
			insert into productTotalScaffold values(NEWID(),@qty,@idProduct,@tag,'t')
			delete from productTotalScaffold where tag = @tag and quantity = 0
		end
		else
		begin--NO SE TIENE QUE BORRAR EL PRODUCT TOTAL SCAFFOLD POR QUE PUEDE TENER EXISTENCIAS EN MODIFICACION
			set @lQTY = (select top 1 quantity from productScaffold where idProduct = @idProduct and tag = @tag)
			update productTotalScaffold set quantity = quantity - @lQTY where  idProduct = @idProduct and tag = @tag
			update productTotalScaffold set quantity = quantity + @qty where  idProduct = @idProduct and tag = @tag
			delete from productTotalScaffold where tag = @tag and quantity = 0
		end
		update productScaffold set idProduct = @idProduct , quantity = @qty where idProductScafold = @idPS
	end
end", conn)
                                    cmdProduct.Transaction = tran
                                    If cmdProduct.ExecuteNonQuery > 0 Then
                                        contProduct += 1
                                    Else
                                        tran.Rollback()
                                        MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Products 'table' at row " + CStr(contProduct) + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        flagComplete = False
                                    End If
                                Next
                            Else
                                tran.Rollback()
                                MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Activity Hours 'table'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                flagComplete = False
                            End If
                        Else
                            tran.Rollback()
                            MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Activity Hours 'table'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            flagComplete = False
                        End If
                    Else
                        tran.Rollback()
                        MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Activity Hours 'table'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        flagComplete = False
                    End If
                Else
                    tran.Rollback()
                    MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Scaffold Information 'table'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    flagComplete = False
                End If
            Else
                tran.Rollback()
                MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Scaffold Information.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                flagComplete = False
            End If
            If flagComplete Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            'tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteRowsLeg(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("clmLegID").Value <> "" Then
                    Dim cmdDeleteLeg As New SqlCommand("delete from leg where legID = '" + row.Cells("legID").Value + "'", conn)
                    cmdDeleteLeg.Transaction = tran
                    If cmdDeleteLeg.ExecuteNonQuery() = 0 Then
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteRowsProductScaffold(ByVal tbl As DataGridView, ByVal tag As String, ByVal jobNo As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("clmIdProductScaffold").Value IsNot Nothing Then
                    Dim array() = row.Cells(1).Value.ToString.Split(" ")
                    Dim idPd = array(0)
                    Dim cmdDeletePS As New SqlCommand("
declare @idPS as varchar(36)
declare @idProduct as int
declare @tag as varchar(20)
declare @lQTY as float 
declare @lIdProduct as int
declare @jobNo as bigint

set @idPS = '" + row.Cells(0).Value + "'
set @idProduct = " + idPd + "
set @tag = '" + tag + "'
set @jobNo = " + jobNo + "

if (select COUNT(*) from productScaffold where idProduct = @idProduct and idProductScafold = @idPS)=1
begin --EL PRODUCTO DEL PS ES EL MISMO
	set @lQTY = (select top 1 quantity from productScaffold where idProductScafold=@idPS)
	update productTotalScaffold set quantity = quantity - @lQTY where idProduct = @idProduct and tag = @tag
	update product set quantity = quantity + @lQTY where idProduct = @idProduct
    update productJob set qty = qty + @lQTY where idProduct = @idProduct and jobNo = @jobNo
	delete from productScaffold where idProductScafold = @idPS
	delete from productTotalScaffold where quantity = 0 and tag = @tag
end", conn)
                    cmdDeletePS.Transaction = tran
                    If cmdDeletePS.ExecuteNonQuery() = 0 Then
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteScaffold(ByVal sc As scaffold) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmd As New SqlCommand("declare @tag as varchar(20) = '" + sc.tag + "'
declare @countProduct as int = (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't' )	
declare @qty as float = 0.0
declare @idProduct as int
	
while (@countProduct > 0) 
begin
	select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productTotalScaffold where tag = @tag and status = 't') as t1
	select quantity from product where idProduct = @idProduct
	update product set quantity = quantity + @qty where idProduct = @idProduct
	delete from productTotalScaffold where idProduct = @idProduct and tag = @tag
	set @countProduct = (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't')
end
if (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't')=0
begin
	delete from leg where tag	= @tag
	select *from materialHandeling where tag = @tag
	delete from materialHandeling where tag = @tag
	select * from activityHours where tag = @tag
	delete from activityHours where tag = @tag
	select * from scaffoldInformation where tag = @tag
	delete from scaffoldInformation	where tag = @tag
	select * from scfInfo where tag = @tag
	delete from scfInfo where tag = @tag
	select * from productDismantle where tag = @tag
	delete from productDismantle where tag = @tag
	select * from dismantle where tag = @tag
	delete from dismantle where tag = @tag 
	select * from productDismantle where tag = @tag
	delete from productModification where tag = @tag
	select * from modification where tag = @tag
	delete from modification where tag= @tag
	select * from productScaffold where tag = @tag
	delete from productScaffold where tag =@tag
    select * from productTotalScaffold where tag = @tag
	delete from productTotalScaffold where tag = @tag
	select * from scaffoldTraking where tag = @tag
	delete from scaffoldTraking where tag = @tag
end", conn)
            cmd.Transaction = tran
            If cmd.ExecuteNonQuery Then
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

    Public Function llenarTags(ByVal tabla As DataTable, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select  sc.tag, CONCAT(wo.idWO,'-',tk.task) as wo , wo.idPO, sc.[status] from scaffoldTraking as sc 
left join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient " + If(idClient = "ALL", "", " where cl.idClient = '" + idClient + "'"), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function findTags(ByVal query As String, ByVal tbl As DataGridView, ByVal idClient As String, ByVal isDate As Boolean) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag , CONCAT(wo.idWO , '-', tk.task) as 'project' ,jb.jobNo , sc.comments from scaffoldTraking as sc
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient " + If(isDate = False, "where 
(tag like '%" + query + "%' or
CONCAT(wo.idWO , '-', tk.task) like '%" + query + "%' or 
CONVERT(nvarchar, jb.jobNo) like '%" + query + "%' or 
comments like '%" + query + "%')", " where (ds.rentStopDate = '" + query + "')" +
If(idClient = "ALL", "", " and cl.idClient = '" + idClient + "'")), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function findTagsDismantle(ByVal query As String, ByVal tbl As DataGridView, ByVal idClient As String, ByVal isDate As Boolean) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ds.tag , CONCAT(wo.idWO , '-', tk.task) as 'project' ,jb.jobNo , ds.comments from dismantle as ds
inner join scaffoldTraking as sc on ds.tag = sc.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient " + If(isDate = False, "where
ds.tag like '%" + query + "%' or
CONCAT(wo.idWO , '-', tk.task) like '%" + query + "%' or 
CONVERT(nvarchar, jb.jobNo) like '%" + query + "%' or 
ds.comments like '%" + query + "%'", " where (ds.rentStopDate = '" + query + "')") +
If(idClient = "ALL", "", " and cl.idClient = '" + idClient + "'"), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tbl.DataSource = dt
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    '####################################################################################################################################################################################
    '############################### METODOS PARA LA MODIFICAION DEL SCAFFOLD ###########################################################################################################
    '####################################################################################################################################################################################
    Public Function llenarComboTagModificaion(ByVal cmb As ComboBox, ByVal idclient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag from scaffoldTraking as sc
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on tk.idAuxWO = wo.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on jb.idClient = cl.idClient
where sc.status = 'f' " + If(idclient = "", "", " and cl.idClient = '" + idclient.ToString() + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            While dr.Read
                cmb.Items.Add(dr("tag"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectMaxModId(ByVal tag As String) As String
        Try
            conectar()
            Dim maxModID As String = "1000"
            Dim cmd As New SqlCommand("select MAX(CONVERT(int, REPLACE(REPLACE(idModification,'-',''),' ','')))+1 As Maxvalue from modification " + If(CStr(tag) <> "", " where tag = '" + CStr(tag) + "'", ""), conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                maxModID = If(rd("Maxvalue") Is DBNull.Value, maxModID, rd("Maxvalue"))
                Exit While
            End While
            Return maxModID
        Catch ex As Exception
            'MsgBox(ex.Message())
            Return "1000"
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboReqCompany(ByVal combo As ComboBox) As Boolean
        Try
            conectar()
            combo.Items.Clear()
            Dim cmd As New SqlCommand("select distinct reqCompany from (select distinct reqCompany from dismantle
union 
select distinct reqCompany from modification) as t1", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                combo.Items.Add(rd("reqCompany"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarComboRequestBy(ByVal combo As ComboBox) As Boolean
        Try
            conectar()
            combo.Items.Clear()
            Dim cmd As New SqlCommand("select distinct requestBy from (select distinct requestBy from dismantle
union 
select distinct requestBy from modification) as t1", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                combo.Items.Add(rd("requestBy"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarModification(ByVal tabla As DataTable, ByVal idCliente As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select md.idModAux,md.idModification, ah.idActivityHours , si.idScaffoldInformation , mh.idMaterialHandeling ,md.tag from modification as md 
inner join activityHours as ah on md.idModAux = ah.idModAux 
left join scaffoldInformation as si on md.idModAux = si.idModAux
inner join materialHandeling as mh on md.idModAux = mh.idModAux
inner join scaffoldTraking as scf on scf.tag = md.tag
inner join task as tk on tk.idAux = scf.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo" +
If(idCliente = "", "", " where idClient ='" + idCliente + "'"), conn)
            tabla.Clear()
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarModificationData(ByVal idMod As String, ByVal tag As String) As ModificationSC
        Dim md As New ModificationSC
        Try
            conectar()
            Dim cmdMod As New SqlCommand("select * from modification where idModAux ='" + idMod + "' and tag='" + tag + "'", conn)
            Dim dr1 As SqlDataReader = cmdMod.ExecuteReader()
            While dr1.Read()
                md.ModAux = dr1("idModAux")
                md.ModID = dr1("idModification")
                md.reqCompany = dr1("reqCompany")
                md.requestBy = dr1("requestBy")
                md.ModDate = validarFechaParaVB(dr1("modificationDate").ToString())
                md.foreman = dr1("foreman")
                md.erector = dr1("erector")
                md.comments = dr1("comments")
                md.tag = dr1("tag")
                md.status = If(dr1("status") = "f", False, True)
                Exit While
            End While
            dr1.Close()
            md.llenarActivityHours(md.ModAux, md.tag)
            md.llenarMaterialHandeling(md.ModAux, md.tag)
            md.llenarSacffoldInformation(md.tag)
            md.productsAdds = md.llenarTablaProductMod(md.ModAux, md.tag)
            md.llenarTablaProductTag(md.tag)

            Return md
        Catch ex As Exception
            Return md
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveModification(ByVal md As ModificationSC) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Dim flagComplete As Boolean = True
        Try
            Dim cmdAvaibleMod As New SqlCommand("select [status] from scaffoldTraking where tag = '" + md.tag + "'", conn)
            cmdAvaibleMod.Transaction = tran
            Dim dr As SqlDataReader = cmdAvaibleMod.ExecuteReader()
            Dim flag As Boolean = False
            While dr.Read()
                flag = If(dr("status") = "f", True, False)
                Exit While
            End While
            dr.Close()
            If flag Then
                If md.ModAux = "" Then
                    Dim g As Guid
                    g = Guid.NewGuid()
                    md.ModAux = g.ToString()
                End If
                Dim cmdMod As New SqlCommand("if (select count (idModAux) from modification where idModAux='" + md.ModAux + "')=0
                begin
	                insert into modification values ('" + md.ModAux + "','" + md.ModID + "','" + md.reqCompany + "','" + md.requestBy + "','" + validaFechaParaSQl(md.ModDate) + "','" + md.foreman + "','" + md.erector + "','" + md.comments + "','" + md.tag + "','" + If(md.status = True, "t", "f") + "')
                end
                else if (select count (idModAux) from modification where idModAux='" + md.ModAux + "')=1
                begin
	                update modification set reqCompany='" + md.reqCompany + "',requestBy='" + md.requestBy + "',modificationDate='" + validaFechaParaSQl(md.ModDate) + "' ,foreman='" + md.foreman + "',erector='" + md.erector + "',comments='" + md.comments + "',tag='" + md.tag + "',status='" + If(md.status = True, "t", "f") + "' where idModAux = '" + md.ModAux + "'
                end", conn)
                cmdMod.Transaction = tran
                If cmdMod.ExecuteNonQuery = 1 Then 'Actualizar o Insertar la Modificacion 
                    Dim cmdActivityHour As New SqlCommand("if (select COUNT(*) from activityHours where idModAux = '" + md.ModAux + "' and tag = '" + md.tag + "')=0
                    begin 
	                    insert into activityHours values (NEWID()," + CStr(md.ahrBuild) + "," + CStr(md.ahrMaterial) + "," + CStr(md.ahrTravel) + "," + CStr(md.ahrWeather) + "," + CStr(md.ahrAlarm) + "," + CStr(md.ahrSafety) + "," + CStr(md.ahrStdBy) + "," + CStr(md.ahrOther) + ",'" + md.tag + "','" + md.ModAux + "',NULL)
                    end
                    else if(select COUNT(*) from activityHours where idModAux = '" + md.ModAux + "' and tag = '" + md.tag + "')=1
                    begin 
	                    update activityHours set build=" + CStr(md.ahrBuild) + ",material=" + CStr(md.ahrMaterial) + ",travel=" + CStr(md.ahrTravel) + ",weather=" + CStr(md.ahrWeather) + ",alarm=" + CStr(md.ahrAlarm) + ",safety=" + CStr(md.ahrSafety) + ",stdBy=" + CStr(md.ahrStdBy) + ",other=" + CStr(md.ahrOther) + " ,tag='" + md.tag + "' where idActivityHours = '" + md.ahrIdActivityHours + "'
                    end", conn)
                    cmdActivityHour.Transaction = tran
                    'If cmdActivityHour.ExecuteNonQuery = 1 Then 'Actualizar o Insertar las Horas de Actividades
                    '    Dim cmdScfInfo As New SqlCommand("if (select count(*) from scaffoldInformation where idModAux='" + md.ModAux + "' and tag = '" + md.tag + "')=0
                    '        begin 
                    '         insert into scaffoldInformation values(NEWID(),'" + md.sciType + "'," + CStr(md.sciWidth) + "," + CStr(md.sciLength) + "," + CStr(md.sciHeigth) + "," + CStr(md.sciDecks) + "," + CStr(md.sciKo) + "," + CStr(md.sciBase) + "," + CStr(md.sciExtraDeck) + ",'" + md.tag + "','" + md.ModAux + "')
                    '        end
                    '        else if (select count(*) from scaffoldInformation where idModAux='" + md.ModAux + "' and tag = '" + md.tag + "')=1
                    '        begin 
                    '         update scaffoldInformation set type='" + md.sciType + "',width=" + CStr(md.sciWidth) + ",length=" + CStr(md.sciLength) + ",heigth=" + CStr(md.sciHeigth) + ",descks=" + CStr(md.sciDecks) + ",ko=" + CStr(md.sciKo) + ",base=" + CStr(md.sciBase) + ",extraDeck=" + CStr(md.sciExtraDeck) + ",tag='" + md.tag + "' where idScaffoldInformation='" + md.idScaffoldinformation + "'
                    '        end", conn)
                    '    cmdScfInfo.Transaction = tran
                    If cmdActivityHour.ExecuteNonQuery = 1 Then 'Actualizar o Insertar la informacion del Andamio
                        Dim cmdMatHand As New SqlCommand("if(select COUNT(*) from materialHandeling where tag = '" + md.tag + "' and idModAux = '" + md.ModAux + "')=0
                            begin
	                            insert into materialHandeling values(NEWID(),'" + If(md.materialHandeling(0), "t", "f") + "','" + If(md.materialHandeling(1), "t", "f") + "','" + If(md.materialHandeling(2), "t", "f") + "','" + If(md.materialHandeling(3), "t", "f") + "','" + If(md.materialHandeling(4), "t", "f") + "','" + If(md.materialHandeling(5), "t", "f") + "','" + If(md.materialHandeling(6), "t", "f") + "','" + md.tag + "','" + md.ModAux + "', Null)
                            end
                            else if(select COUNT(*) from materialHandeling where tag = '" + md.tag + "' and idModAux = '" + md.ModAux + "')=1
                            begin
	                            update materialHandeling set truck='" + If(md.materialHandeling(0), "t", "f") + "',forklift='" + If(md.materialHandeling(1), "t", "f") + "',trailer='" + If(md.materialHandeling(2), "t", "f") + "',crane='" + If(md.materialHandeling(3), "t", "f") + "',rope='" + If(md.materialHandeling(4), "t", "f") + "',passed='" + If(md.materialHandeling(5), "t", "f") + "',elevator='" + If(md.materialHandeling(6), "t", "f") + "' ,tag='" + md.tag + "' where idMaterialHandeling ='" + md.idMaterialHandeling + "'
                            end", conn)
                        cmdMatHand.Transaction = tran
                        If cmdMatHand.ExecuteNonQuery = 1 Then 'Actualizar o Insertar la Manipulacion de materiales
                            Dim contProduct As Integer = 1
                            For Each row As DataRow In md.productsAdds.Rows()
                                Dim array() = row.ItemArray(1).ToString.Split(" ")
                                Dim idProduct = array(0).ToString
                                Dim idProductModification = row.ItemArray(0).ToString()
                                Dim cmdProductInsertUpdate As New SqlCommand("
declare @modID as varchar(36)
declare @cantidad as float
declare @idProduct as int
declare @tag as varchar(36)
declare @lqty as float
declare @jobNo as bigint

set @modID = '" + md.ModAux + "'
set @cantidad = " + row.ItemArray(2) + "
set @idProduct = " + idProduct + "
set @tag = '" + md.tag + "'
set @jobNo = (select top 1 jb.jobNo from modification as md 
inner join scaffoldTraking as sc on sc.tag = md.tag
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where md.idModAux = @modID )

if(select COUNT(*) from productModification where idProduct = @idProduct and idModAux = @modID)=0
begin --NO EXISTE PRODUCTO
	if(select COUNT(*) from productTotalScaffold where idProduct = @idProduct and tag=@tag)=0
	begin--PRODUCTO NUEVO EN SCAFFOLD Y MODIFICACION
		insert into productTotalScaffold values(NEWID(),@cantidad,@idProduct,@tag,'t')
		insert into productModification values(NEWID(),@modID,@idProduct,@cantidad,@tag)
		update product set quantity = quantity - IIF(@cantidad > 0,@cantidad,@cantidad*-1) where idProduct = @idProduct
        update productJob set qty = qty - IIF(@cantidad > 0,@cantidad,@cantidad*-1) where idProduct = @idProduct and jobNo = @jobNo
		delete from productTotalScaffold where quantity = 0 and tag = @tag
	end
	else if(select COUNT(*) from productTotalScaffold where idProduct = @idProduct and tag=@tag)>0
	begin--PRODUCTO EXISTE EN SCAFFOLDTOTAL PERO NO EN MODIFICACION
		insert into productModification values(NEWID(),@modID,@idProduct,@cantidad,@tag)
		update productTotalScaffold set quantity = quantity + @cantidad where tag= @tag and idProduct = @idProduct
		update product set quantity = quantity - IIF(@cantidad > 0 ,@cantidad,@cantidad*-1) where idProduct = @idProduct
        update productJob set qty = qty - IIF(@cantidad > 0,@cantidad,@cantidad*-1) where idProduct = @idProduct and jobNo = @jobNo
		delete from productTotalScaffold where quantity <= 0 and tag = @tag
	end
end
else 
if(select COUNT(*) from productModification where idProduct = @idProduct and idModAux = @modID)>0
begin --EXISTE PRODUCTO EN MODIFICACION 
	set @lqty = (select top 1 quantity from productModification where idModAux=@modID and idProduct=@idProduct)
	update product set quantity = quantity + (IIF(@lqty>0,@lqty,@lqty)) where idProduct = @idProduct --REGRESO EL VALOR ANTERIOR 
	update productJob set qty = qty + (IIF(@lqty>0,@lqty,@lqty)) where idProduct = @idProduct and jobNo	= @jobNo--REGRESO EL VALOR ANERIOR
	update productTotalScaffold set quantity = quantity - (IIF(@lqty>0,@lqty,@lqty*-1)) where tag = @tag and idProduct = @idProduct--REGRESO EL VALOR ANTERIOR 

	update product set quantity = quantity -  IIF(@cantidad>0,@cantidad,@cantidad*-1) where idProduct = @idProduct
	update productJob set qty = qty - IIF(@cantidad > 0,@cantidad,@cantidad*-1) where idProduct = @idProduct and jobNo = @jobNo
	update productTotalScaffold set quantity = quantity + @cantidad where idProduct= @idProduct and tag= @tag

	update productModification set quantity = @cantidad where  idModAux=@modID and idProduct=@idProduct 	
end", conn)
                                cmdProductInsertUpdate.Transaction = tran
                                If cmdProductInsertUpdate.ExecuteNonQuery > 0 Then
                                    contProduct += 1
                                Else
                                    tran.Rollback()
                                    MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Products 'table' at row " + CStr(contProduct) + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    flagComplete = False
                                End If
                            Next
                            flagComplete = True
                            'Else
                            '    flagComplete = False
                            '    MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Data of 'Material Handeling'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            'End If
                        Else
                            flagComplete = False
                            MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Table 'Scaffold Information'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        flagComplete = False
                        MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Table 'Activity Hours'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    flagComplete = False
                    MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the 'Modification Data', try a new ID.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                If flagComplete Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
                Return flagComplete
            Else
                MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is Probably that the Scaffold is Dismantled.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function insertProductModification(ByVal idProduct As String, ByVal quantity As String, ByVal idModification As String, ByVal tag As String) As String
        Try
            conectar()
            Dim cmdModAUX As New SqlCommand("select idModAux from modification where idModification = '" + idModification + "' and tag ='" + tag + "'", conn)
            Dim dr As SqlDataReader = cmdModAUX.ExecuteReader
            Dim modAUX As String = ""
            While dr.Read
                modAUX = dr("idModAux")
                Exit While
            End While
            If modAUX <> "" Then
                Dim cmdProductInsertUpdate As New SqlCommand("
declare @modID as varchar(36)
declare @cantidad as float
declare @idProduct as int
declare @tag as varchar(36)
declare @lqty as float
 
set @modID = '" + modAUX + "'
set @cantidad = " + quantity + "
set @idProduct = " + idProduct + "
set @tag = '" + tag + "'

if(select COUNT(*) from productModification where idProduct = @idProduct and idModAux = @modID)=0
begin --NO EXISTE PRODUCTO
	if(select COUNT(*) from productTotalScaffold where idProduct = @idProduct and tag=@tag)=0
	begin--PRODUCTO NUEVO EN SCAFFOLD Y MODIFICACION
		insert into productTotalScaffold values(NEWID(),@cantidad,@idProduct,@tag,'t')
		insert into productModification values(NEWID(),@modID,@idProduct,@cantidad,@tag)
		update product set quantity = quantity - IIF(@cantidad > 0,@cantidad,@cantidad*-1) where idProduct = @idProduct
		delete from productTotalScaffold where quantity = 0 and tag = @tag
	end
	else if(select COUNT(*) from productTotalScaffold where idProduct = @idProduct and tag=@tag)>0
	begin--PRODUCTO EXISTE EN SCAFFOLDTOTAL PERO NO EN MODIFICACION
		insert into productModification values(NEWID(),@modID,@idProduct,@cantidad,@tag)
		update productTotalScaffold set quantity = quantity + @cantidad where tag= @tag and idProduct = @idProduct
		update product set quantity = quantity - IIF(@cantidad > 0 ,@cantidad,@cantidad*-1) where idProduct = @idProduct
		delete from productTotalScaffold where quantity <= 0 and tag = @tag
	end
end
else 
if(select COUNT(*) from productModification where idProduct = @idProduct and idModAux = @modID)>0
begin --EXISTE PRODUCTO EN MODIFICACION 
	set @lqty = (select top 1 quantity from productModification where idModAux=@modID and idProduct=@idProduct)
	update product set quantity = quantity + (IIF(@lqty>0,@lqty,@lqty*-1)) where idProduct = @idProduct
	update productTotalScaffold set quantity = quantity - @lqty where tag = @tag and idProduct = @idProduct
	update product set quantity = quantity -  iif(@cantidad>0,@cantidad,@cantidad) where idProduct = @idProduct
	update productTotalScaffold set quantity = quantity + @cantidad where idProduct= @idProduct and tag= @tag
	update productModification set quantity = @cantidad where  idModAux=@modID and idProduct=@idProduct 	
	delete from productTotalScaffold where quantity <= 0 and tag = @tag
end", conn)

                If cmdProductInsertUpdate.ExecuteNonQuery > 0 Then
                    Return "Complete"
                Else
                    Return "Error Check the data of this product."
                End If
            Else
                Return "The Modification ID or TagID does not exist"
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function deleteRowsProductModification(ByVal tbl As DataGridView, ByVal tag As String, ByVal modAux As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("idProductM").Value IsNot Nothing Then
                    Dim array() = row.Cells(1).Value.ToString.Split(" ")
                    Dim idPd = array(0)
                    Dim cmdDeletePS As New SqlCommand("
declare @modID as varchar(36)
declare @tag as varchar(20)
declare @idProduct as int 
declare @qty as float
declare @jobNo as bigint 
set @modID = '" + modAux + "'
set @tag = '" + tag + "'
set @idProduct = " + row.Cells(1).Value.ToString() + "
set @jobNo = (select top 1 jb.jobNo from modification as md 
inner join scaffoldTraking as sc on sc.tag = md.tag
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where md.idModAux = @modID )
if (select COUNT(*) from productModification where idProduct = @idProduct and idModAux = @modID and tag=@tag )>0
begin 
	set @qty = (select top 1 quantity from productModification where idProduct = @idProduct and idModAux = @modID and tag=@tag)
	if @qty >= 0 
	begin 
		update product set quantity = quantity + @qty where idProduct = @idProduct
		update productTotalScaffold set quantity = quantity - @qty where idProduct = @idProduct and tag = @tag
		update productJob set qty = qty + @qty where idProduct = @idProduct and jobNo = @jobNo
		delete from productModification where idProduct = @idProduct and idModAux = @modID and tag = @tag
		delete from productTotalScaffold where quantity = 0 and tag = @tag
	end
	else IF @qty < 0
	begin --EL PRODUCT SE REGROSO AL ALMACEN ENTONCES SE TIENE QUE AGREGAR LA QTY A LA LISTA DE PS,PT, Y DISMINUIR PRUDCTOS
		--@QTY ES NEGATIVA POR ENDE SOLO CON QUE SE SUME RESTARA LOS REGISTROS  
		update product set quantity = quantity + @qty where idProduct = @idProduct 
		update productTotalScaffold set quantity = quantity + (@qty*-1) where idProduct = @idProduct and tag = @tag
		update productJob set qty = qty + @qty where idProduct = @idProduct and jobNo = @jobNo
		delete from productModification where idProduct = @idProduct and idModAux = @modID and tag = @tag
		delete from productTotalScaffold where quantity = 0 and tag = @tag
	end
end", conn)
                    cmdDeletePS.Transaction = tran
                    If cmdDeletePS.ExecuteNonQuery() = 0 Then
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteModificaion(ByVal tag As String, ByVal modIDAux As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_DeleteModAux")
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@tag", SqlDbType.VarChar, 20).Value = tag
            cmd.Parameters.Add("@modID", SqlDbType.VarChar, 36).Value = modIDAux
            cmd.Parameters.Add("@msg", SqlDbType.VarChar, 120).Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Dim resultado As String = cmd.Parameters("@msg").Value
            MsgBox(resultado)
            If resultado <> "Successful" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Public Function deleteDismantle(ByVal tag As String, ByVal idDismantle As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("declare @tag as varchar(20) = '" + tag + "' 
	declare @idDismantle as varchar(36) = '" + idDismantle + "'
	declare @countProduct as int = (select COUNT (*) from productTotalScaffold where tag = @tag and status = 'f')
	declare @qty as float
	declare @idProduct as int
    declare @error as int = 0
    declare @jobNo as bigint = (select top 1 jb.jobNo from scaffoldTraking as sc
    inner join task as tk on tk.idAux = sc.idAux 
    inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
    inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
    inner join job as jb on jb.jobNo = po.jobNo
    where sc.tag = @tag )
    begin tran
	begin try 
		if (select COUNT(*) from dismantle where tag = @tag or idDismantle = @idDismantle)=1
		begin 
			delete from activityHours where idDismantle = @idDismantle and tag = @tag 
			delete from materialHandeling where idDismantle = @idDismantle and tag = @tag 
			if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			if exists(select idDismantle from dismantle where idDismantle = @idDismantle)
			begin
				while (@countProduct > 0) 
				begin
	    			select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productTotalScaffold where tag = @tag and status = 'f') as t1
	    			--select quantity from product where idProduct = @idProduct
	    			if (select quantity from product where  idProduct = @idProduct) >=  @qty
					begin
						update product set quantity = quantity - @qty where idProduct = @idProduct
					end
					if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
	    			--select quantity from productTotalScaffold where idProduct = @idProduct and tag = @tag
					if (select qty from productJob where  idProduct = @idProduct and jobNo = @jobNo) >=  @qty
					begin
						update productJob set qty = qty - @qty where idProduct = @idProduct and jobNo = @jobNo
	    			end
					if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
					update productTotalScaffold set status = 't'  where tag = @tag and idProduct = @idProduct
					if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
					delete from productDismantle where idProduct = @idProduct and idDismantle= @idDismantle 
	    			if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
					set @countProduct = @countProduct-1
				end
				update scaffoldTraking set status = 'f' where tag = @tag
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				update modification set status = 'f' where tag = @tag
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				delete from dismantle where idDismantle = @idDismantle and tag = @tag 
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			end
		end
end try	
	begin catch
		goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
	end catch
commit tran 
solveproblem:
if @error <> 0
begin 
	rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Public Function llenarDismantleData(ByVal tag As String) As dismantle
        Dim ds As New dismantle
        Try
            conectar()
            Dim cmdDS As New SqlCommand("select  top 1 ds.idDismantle, ds.tag,ds.comments,ds.reqCompany,ds.requestBy,ds.rentStopDate,ds.dismantleDate,ds.foreman,ds.erector, 
(select CONCAT(wk.idWO,'-',tk.task) from scaffoldTraking as sc 
left join task as tk on sc.idAux = tk.idAux
left join workOrder as wk on wk.idAuxWO = tk.idAuxWO where sc.tag = ds.tag ) as WO 
from dismantle as ds
where ds.tag = '" + tag + "'", conn)
            Dim rd1 As SqlDataReader = cmdDS.ExecuteReader()
            ds.tag = tag
            While rd1.Read()
                ds.idDismantle = If(rd1("idDismantle") IsNot DBNull.Value, rd1("idDismantle"), "")
                ds.tag = If(rd1("tag") IsNot DBNull.Value, rd1("tag"), "")
                ds.comments = If(rd1("comments") IsNot DBNull.Value, rd1("comments"), "")
                ds.reqCompany = If(rd1("reqCompany") IsNot DBNull.Value, rd1("reqCompany"), "")
                ds.requestBy = If(rd1("requestBy") IsNot DBNull.Value, rd1("requestBy"), "")
                ds.stopDismantle = If(rd1("rentStopDate") IsNot DBNull.Value, validarFechaParaVB(rd1("rentStopDate")), System.DateTime.Today)
                ds.dismantleDate = If(rd1("dismantleDate") IsNot DBNull.Value, validarFechaParaVB(rd1("dismantleDate")), System.DateTime.Today)
                ds.foreman = If(rd1("foreman") IsNot DBNull.Value, rd1("foreman"), "")
                ds.erector = If(rd1("erector") IsNot DBNull.Value, rd1("erector"), "")
                ds.wo = If(rd1("WO") IsNot DBNull.Value, rd1("WO"), "")
                Exit While
            End While
            If (ds.idDismantle <> "") Then
                ds.llenarActivityHours(ds.idDismantle, tag)
                ds.llenarMaterialHandeling(ds.idDismantle, tag)
                ds.llenarTablaProductDismantle(ds.idDismantle, tag)
            End If
            ds.llenarTablaProductSC(tag)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ds
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveDismantle(ByVal ds As dismantle, ByVal showMessage As Boolean) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmd As New SqlCommand("
    declare @tag as varchar(20) = '" + ds.tag + "'
	declare @idDismantle as varchar(36) = " + If(ds.idDismantle = "", "NEWID()", "'" + ds.idDismantle + "'") + "
	declare @countProduct as int = (select COUNT (*) from productTotalScaffold where tag = @tag and status = 't')
	declare @qty as float
	declare @idProduct as int 
    declare @jobNo as bigint = (select top 1 jb.jobNo from scaffoldTraking as sc
    inner join task as tk on tk.idAux = sc.idAux 
    inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
    inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
    inner join job as jb on jb.jobNo = po.jobNo
    where sc.tag = @tag )

    if (select COUNT(*) from dismantle where tag = @tag or idDismantle = @idDismantle)=0
	begin 
		insert into dismantle values (@idDismantle,@tag,'" + ds.comments + "','" + ds.reqCompany + "','" + ds.requestBy + "','" + validaFechaParaSQl(ds.stopDismantle) + "','" + validaFechaParaSQl(ds.dismantleDate) + "','" + ds.foreman + "','" + ds.erector + "')	
        insert into materialHandeling values (NEWID(),'" + If(ds.materialHandeling(0), "t", "f") + "','" + If(ds.materialHandeling(1), "t", "f") + "','" + If(ds.materialHandeling(2), "t", "f") + "','" + If(ds.materialHandeling(3), "t", "f") + "','" + If(ds.materialHandeling(4), "t", "f") + "','" + If(ds.materialHandeling(5), "t", "f") + "','" + If(ds.materialHandeling(6), "t", "f") + "',@tag,NULL,@idDismantle)--True = t, False = f
	    insert into activityHours values (NEWID()," + ds.ahrDismantle.ToString() + "," + ds.ahrMaterial.ToString() + "," + ds.ahrTravel.ToString() + "," + ds.ahrWeather.ToString() + "," + ds.ahrAlarm.ToString() + "," + ds.ahrSafety.ToString() + "," + ds.ahrStdBy.ToString() + "," + ds.ahrOther.ToString() + ",@tag,Null,@idDismantle)--b,m,t,w,a,s,st,o
	end
	else
	begin 
		update dismantle set comments='" + ds.comments + "',reqCompany='" + ds.reqCompany + "',requestBy='" + ds.requestBy + "',rentStopDate='" + validaFechaParaSQl(ds.stopDismantle) + "',dismantleDate='" + validaFechaParaSQl(ds.dismantleDate) + "',foreman='" + ds.foreman + "',erector = '" + ds.erector + "' where idDismantle = @idDismantle or tag = @tag
		update materialHandeling set truck='" + If(ds.materialHandeling(0), "t", "f") + "',forklift='" + If(ds.materialHandeling(1), "t", "f") + "',trailer='" + If(ds.materialHandeling(2), "t", "f") + "',crane='" + If(ds.materialHandeling(3), "t", "f") + "',rope='" + If(ds.materialHandeling(4), "t", "f") + "',passed='" + If(ds.materialHandeling(5), "t", "f") + "',elevator='" + If(ds.materialHandeling(6), "t", "f") + "' where idDismantle = @idDismantle and tag = @tag
		update activityHours set build=" + ds.ahrDismantle.ToString() + ",material=" + ds.ahrMaterial.ToString() + ",travel=" + ds.ahrTravel.ToString() + ",weather=" + ds.ahrWeather.ToString() + ",alarm=" + ds.ahrAlarm.ToString() + ",safety=" + ds.ahrSafety.ToString() + ",stdBy=" + ds.ahrStdBy.ToString() + ",other=" + ds.ahrOther.ToString() + " where idDismantle = @idDismantle and tag = @tag
	end
    if exists(select idDismantle from dismantle where idDismantle = @idDismantle)
	begin
	    while (@countProduct > 0) 
	    begin
	    	select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productTotalScaffold where tag = @tag and status = 't') as t1
	    	--select quantity from product where idProduct = @idProduct
	    	update product set quantity = quantity + @qty where idProduct = @idProduct
	    	--select quantity from productTotalScaffold where idProduct = @idProduct and tag = @tag
            update productJob set qty = qty + @qty where idProduct = @idProduct and jobNo = @jobNo
	    	update productTotalScaffold set status = 'f' where tag = @tag and idProduct = @idProduct
            insert into productDismantle values (NEWID(),@qty,@idProduct,@tag,@idDismantle)
	    	set @countProduct = @countProduct-1
	    end
	    update scaffoldTraking set status = 't' where tag = @tag
        update modification set status = 't' where tag = @tag
    end", conn)
            cmd.Transaction = tran
            If cmd.ExecuteNonQuery Then
                tran.Commit()
                If showMessage Then
                    MessageBox.Show("Succesfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                Return True
            Else
                tran.Rollback()
                MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tran.Rollback()
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarTagSinDismantle(ByVal tbl As Data.DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag,status, buildDate from scaffoldTraking where status = 'f'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tbl)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    '###########################################################################################################################################################################
    '############################### METODOS PARA COSTUMERS AND JOBS ###########################################################################################################
    '###########################################################################################################################################################################
    Public Function selectCostumerInfo() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select cl.idClient ,cl.numberClient , cl.companyName , CONCAT(ha.number,'th ',ha.avenue) as 'Billing Addres', CONCAT(cl.firstName,' ',cl.middleName,', ',cl.lastName ) as 'Contact Name',
isnull(ha.city,'') as 'City', isnull(ha.providence,'') as 'Providence' , isnull(ha.postalCode,'') as 'CP' ,isnull(ct.phoneNumber1,'') as 'PH 1', isnull(ct.phoneNumber2,'') as 'PH 2',
isnull(ct.email,'') as 'Email'
from clients as cl
left join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress
left join contact as ct on ct.idContact = cl.idContact", conn)
            Dim dt As New DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectScaffoldProjectCostumer(ByVal idClient As String, ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select sc.tag as 'Tag' , CONCAT (scInf.[length],'x',scInf.width,'x',scInf.heigth) as 'Dimention',
sc.buildDate as 'SC Build Date'
, CONCAT(wo.idWO,'-',tk.task)as 'Work Order'
, po.idPO as 'PO', jb.jobNo as 'Job Num', sc.comments as 'Comments', iif(sc.[status]='f',0,1 ) as 'Is Dismantled'
, jc.cat as 'Job Cat' , sj.[description] as 'Sub Job' , ar.name as 'Area'
, (select COUNT(*) from modification as md where md.tag = sc.tag) as 'Modifications Count'
from scaffoldTraking as sc
left join jobCat as jc on sc.idJobCat = jc.idJobCat
left join subJobs as sj on sc.idSubJob = sj.idSubJob
left join areas as ar on sc.idArea = ar.idArea
left join scaffoldInformation as scInf on scInf.tag = sc.tag  
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.idClient = " + If(idClient = "", "'%%'", "'" + idClient + "'") + "", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("Tag"), dr("Dimention"), dr("SC Build Date"), dr("Work Order"), dr("PO"), dr("Job Num"), dr("Comments"), If(dr("Is Dismantled") = "1", True, False), dr("Job Cat"), dr("Sub Job"), dr("Area"), dr("Modifications Count"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    '###########################################################################################################################################################################
    '############################### METODOS PARA REPROTES DE SCAFFOLD #########################################################################################################
    '###########################################################################################################################################################################
    Public Function actualizarInvoiceExcel(ByVal startDate As String, ByVal finalDate As String, ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
declare @startDate as date = '" + startDate + "'
declare @FinalDate as date = '" + finalDate + "'
declare @numberClient as int = " + numberClient + "

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'dbo' and TABLE_NAME = 'invoiceExcel')
BEGIN 
	drop table invoiceExcel
END

select
distinct
T1.[Labor WO / Network #],T1.[Type (O,M,T,C)],T1.[Tag #],
SUM(T1.[Pieces]) OVER (PARTITION BY [Tag #] ,Work) as 'Pieces',
'' as 'SRLs',T1.[UNIT],CONVERT(nvarchar, T1.[Location])as 'Location',T1.[Date UP],T1.[Date Down],
SUM((T1.[Product Amount]*t1.[RDays])) OVER (PARTITION BY [TAG #], Work) as 'Invoice Amount',
T1.[ACTIVEDAYS],T1.[RDays],T1.[Work]
into InvoiceExcel
from (
select wo.idWO as 'Labor WO / Network #',
case  sj.[description] 
when 'Operation' then 'O'
when 'Maintenance' then 'M'
when 'T/A' then 'T'
when 'Capital' then 'C'
when 'Winterization' then 'W'
when 'All' then 'All'
when NULL then ''
else SUBSTRING(sj.[description],1,1) end  as 'Type (O,M,T,C)',
sc.tag as 'Tag #',
ISNULL((select sum(psc.quantity) from productScaffold as psc where psc.tag = sc.tag),0) as 'Pieces',
ar.name as 'UNIT',
sc.location as 'Location',
CONVERT(VARCHAR, sc.buildDate, 101) as 'Date UP',
ISNULL(CONVERT(VARCHAR, ds.dismantleDate, 101),'') as 'Date Down',
ISNULL((select sum(psc.quantity * pd.dailyRentalRate) from productScaffold as psc 
inner join product as pd on pd.idProduct = psc.idProduct
where psc.tag = sc.tag),0) as 'Product Amount',
DATEDIFF(day,sc.buildDate, IIF(ds.dismantleDate is Null,GETDATE(),ds.dismantleDate)) as 'ACTIVEDAYS',
IIF( ISNULL(ds.rentStopDate,GETDATE()) >= @startDate --and sc.buildDate <= @startDate,
, -- EL DIA DE DISMANTLE ES MAYOR AL STARTDATE POR ENDE AUN NO SE HA HECHO DISMANTLE PARA EL STARTDATE(PUEDE QUE TENGA DIAS QUE COBRAR)
	IIF( DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) <= @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR O IGUAL AL FINALDATE?
	,-- SI ES MENOR O IGUAL POR LO TANTO SI HAY DIAS QUE COBRAR (ESTA DENTRO DEL RANGO)
		IIF(DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) > @startDate -- (PUNTO DE INICIO) EL DIA FINAL DE RENTA GRATIS ES MAYOR AL STARTDATE?
		,--DIAFINAL DE RENTA GRATIS
			IIF(ISNULL(ds.rentStopDate,GETDATE()) < @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR QUE EL FINALDATE?
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),ds.rentStopDate)
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),@FinalDate))
		,--STARTDATE
			IIF(ISNULL(ds.rentStopDate,GETDATE()) < @FinalDate, 
				DATEDIFF(DAY,ISNULL(ds.rentStopDate,GETDATE()),DATEADD(DAY,-1 ,@startDate)), 
				DATEDIFF(DAY,DATEADD(DAY,-1 ,@startDate),@finalDate))
		)	,-- NO ES MENOR O IGUAL POR ENDE NO HAY DIAS QUE COBAR (NO ESTA DENTRO DEL RANGO)
	0),0) AS 'RDAYS',
'Build' as 'Work'
from scaffoldTraking as sc
left join dismantle as ds on ds.tag = sc.tag
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join jobCat as jc on jc.idJobCat = sc.idJobCat
left join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberClient
UNION ALL
select wo.idWO as 'Labor WO / NERWORK #',
case  sj.[description] 
when 'Operation' then 'O'
when 'Maintenance' then 'M'
when 'T/A' then 'T'
when 'Capital' then 'C'
when 'Winterization' then 'W'
when 'All' then 'All'
when NULL then ''
else SUBSTRING(sj.[description],1,1) end  as 'Type (O,M,T,C)',
md.tag as 'Tag #',
ISNULL((select sum(pmd.quantity) from productModification as pmd where pmd.idModAux = md.idModAux),0) as 'Pieces',
ar.name as 'UNIT',
sc.location as 'Location',
CONVERT(VARCHAR, md.modificationDate, 101) as 'Date UP',
ISNULL(CONVERT(VARCHAR, ds.dismantleDate, 101),'') as 'Date Down',
ISNULL((select sum(pmd.quantity * pd.dailyRentalRate) from productModification as pmd 
inner join product as pd on pd.idProduct = pmd.idProduct
where pmd.idModAux = md.idModAux),0) as 'Product Amount',
DATEDIFF(day,sc.buildDate, IIF(ds.dismantleDate is Null,GETDATE(),ds.dismantleDate)) as 'ACTIVEDAYS',
IIF( ISNULL(ds.rentStopDate,GETDATE()) >= @startDate --and sc.buildDate <= @startDate
,
	IIF( DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) <= @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR O IGUAL AL FINALDATE?
	,-- SI ES MENOR O IGUAL POR LO TANTO SI HAY DIAS QUE COBRAR (ESTA DENTRO DEL RANGO)
		IIF(DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) > @startDate -- (PUNTO DE INICIO) EL DIA FINAL DE RENTA GRATIS ES MAYOR AL STARTDATE?
		,--DIAFINAL DE RENTA GRATIS
			IIF(ISNULL(ds.rentStopDate,GETDATE()) < @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR QUE EL FINALDATE?
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),ds.rentStopDate)
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),@FinalDate))
		,--STARTDATE
			IIF(ISNULL(ds.rentStopDate,GETDATE()) < @FinalDate, 
				DATEDIFF(DAY,ISNULL(ds.rentStopDate,GETDATE()),DATEADD(DAY,-1 ,@startDate)), 
				DATEDIFF(DAY,DATEADD(DAY,-1 ,@startDate),@finalDate))
		)	,-- NO ES MENOR O IGUAL POR ENDE NO HAY DIAS QUE COBAR (NO ESTA DENTRO DEL RANGO)
	0),0) AS 'RDAYS',
'Mod' as 'Work'
from modification as md 
left join scaffoldTraking as sc on sc.tag = md.tag
left join dismantle as ds on ds.tag = sc.tag
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join jobCat as jc on jc.idJobCat = sc.idJobCat
left join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberClient
) AS T1
WHERE T1.Pieces > 0  and T1.RDAYS > 0", conn)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '======================== METODOS PARA KPI ====================================================================================================
    Public Function selectKPIByClient(ByVal tbl As DataGridView, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select kpi.idKPI,kpi.typeKPI,kpi.jobNo,(select top 1 CONCAT(wo.idWO,'-',tk.task) as 'wono' from task as tk inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO where tk.idAux = kpi.idAux) as 'wono'
,kpi.idAux,kpi.[description],kpi.thinck,kpi.size,CONVERT(varchar, kpi.dateWorked,101)as 'DateWorked',kpi.LF,kpi.SQF,kpi.qty90,kpi.qty45,kpi.TEE,kpi.VLV,kpi.RED,kpi.CAP,kpi.FLG,kpi.FIT,kpi.hoursST,kpi.hoursOT
,kpi.casePaint,kpi.install,kpi.lead,kpi.stResistence
from KPI as kpi
inner join job as jb on jb.jobNo = kpi.jobNo
inner join clients as cl on cl.idClient = jb.idClient 
where cl.idClient = '" + idClient + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read
                tbl.Rows.Add(dr("idKPI").ToString(), dr("typeKPI").ToString(), dr("jobNo").ToString(), dr("wono").ToString(), dr("idAux").ToString(), dr("description").ToString(), dr("thinck").ToString(), dr("size").ToString(), dr("DateWorked").ToString(), dr("LF").ToString(), dr("SQF").ToString(), dr("qty90").ToString(), dr("qty45").ToString(), dr("TEE").ToString(), dr("VLV").ToString(), dr("RED").ToString(), dr("CAP").ToString(), dr("FLG").ToString(), dr("FIT").ToString(), dr("hoursST").ToString(), dr("hoursOT").ToString(), dr("install").ToString(), dr("casePaint").ToString(), If(dr("lead") = 1, True, False), If(dr("stResistence") = 1, True, False))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Public Function saveUpdateKPI(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flagTran As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim query As String
                If validarRowKPI(row) Then
                    If row.Cells(0).Value = Nothing Then
                        query = "insert into KPI values('" + row.Cells("TypeKPIS").Value + "','" + row.Cells("CasePaintS").Value.ToString() + "'," + If(row.Cells("LeadS").Value = True, "1", "0") + "," + If(row.Cells("STResistenceS").Value = True, "1", "0") + ",'" + If(row.Cells("descriptionS").Value Is DBNull.Value, "", row.Cells("descriptionS").Value.ToString()) + "'," + row.Cells("JobNoS").Value.ToString() + ",'" + row.Cells("IdAuxS").Value.ToString() + "','" + validaFechaParaSQl(row.Cells("DateWorkedS").Value.ToString()) + "',
                        " + If(row.Cells("TinckS").Value = "", "0", row.Cells("TinckS").Value.ToString) + "," + If(row.Cells("SizeS").Value = "", "0", row.Cells("SizeS").Value.ToString) + "," + If(row.Cells("SQFTS").Value = "", "0", row.Cells("SQFTS").Value.ToString) + "," + If(row.Cells("LFS").Value = "", "0", row.Cells("LFS").Value.ToString) + ",
                        " + If(row.Cells("Qty90S").Value = "", "0", row.Cells("Qty90S").Value.ToString) + "," + If(row.Cells("Qty45S").Value = "", "0", row.Cells("Qty45S").Value.ToString) + "," + If(row.Cells("TEES").Value = "", "0", row.Cells("TEES").Value.ToString) + "," + If(row.Cells("REDS").Value = "", "0", row.Cells("REDS").Value.ToString) + "," + If(row.Cells("CAPS").Value = "", "0", row.Cells("CAPS").Value.ToString) + "," + If(row.Cells("FLGS").Value = "", "0", row.Cells("FLGS").Value.ToString) + "," + If(row.Cells("FITS").Value = "", "0", row.Cells("FITS").Value.ToString) + "," + If(row.Cells("ValvesS").Value = "", "0", row.Cells("ValvesS").Value.ToString) + ",
                        " + If(row.Cells("STS").Value = "", "0", row.Cells("STS").Value.ToString) + "," + If(row.Cells("OTS").Value = "", "0", row.Cells("OTS").Value.ToString) + ",'" + If(row.Cells("InstallS").Value = "", "", row.Cells("InstallS").Value.ToString) + "')"
                    Else
                        query = "update KPI set typeKPI ='" + row.Cells("TypeKPIS").Value.ToString() + "' ,casePaint = '" + row.Cells("CasePaintS").Value.ToString() + "',lead = " + If(row.Cells("LeadS").Value = True, "1", "0") + " , stResistence = " + If(row.Cells("STResistenceS").Value = True, "1", "0") + ",[description]='" + row.Cells("descriptionS").Value.ToString() + "',jobNo=" + row.Cells("JobNoS").Value.ToString() + ",idAux='" + row.Cells("IdAuxS").Value.ToString() + "',dateWorked ='" + validaFechaParaSQl(row.Cells("DateWorkedS").Value.ToString()) + "',
                        thinck = " + If(row.Cells("TinckS").Value.ToString() = "", "0", row.Cells("TinckS").Value.ToString()) + ",size=" + If(row.Cells("SizeS").Value.ToString() = "", "0", row.Cells("SizeS").Value.ToString()) + ",SQF=" + If(row.Cells("SQFTS").Value.ToString() = "", "0", row.Cells("SQFTS").Value.ToString()) + ",LF= " + If(row.Cells("LFS").Value.ToString() = "", "0", row.Cells("LFS").Value.ToString()) + ",
                        qty90 = " + If(row.Cells("Qty90S").Value.ToString() = "", "0", row.Cells("Qty90S").Value.ToString()) + ",qty45=" + If(row.Cells("Qty45S").Value.ToString() = "", "0", row.Cells("Qty45S").Value.ToString()) + ",TEE=" + If(row.Cells("TEES").Value.ToString() = "", "0", row.Cells("TEES").Value.ToString()) + ",RED=" + If(row.Cells("REDS").Value.ToString() = "", "0", row.Cells("REDS").Value.ToString()) + ",CAP=" + If(row.Cells("CAPS").Value.ToString() = "", "0", row.Cells("CAPS").Value.ToString()) + ",FLG=" + If(row.Cells("FLGS").Value.ToString() = "", "0", row.Cells("FLGS").Value.ToString()) + ",FIT=" + If(row.Cells("FITS").Value.ToString() = "", "0", row.Cells("FITS").Value.ToString()) + ",VLV=" + If(row.Cells("ValvesS").Value.ToString() = "", "0", row.Cells("ValvesS").Value.ToString()) + ",
                        hoursSt = " + If(row.Cells("STS").Value.ToString() = "", "0", row.Cells("STS").Value.ToString()) + ",hoursOT=" + If(row.Cells("OTS").Value.ToString() = "", "0", row.Cells("OTS").Value.ToString()) + ",install='" + If(row.Cells("InstallS").Value.ToString() = "", "", row.Cells("InstallS").Value.ToString()) + "'
                        where idKPI=" + row.Cells("idKPI").Value.ToString() + ""
                    End If
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 0 Then
                        If DialogResult.No = MessageBox.Show("Error at row number " + CStr(row.HeaderCell.Value) + vbCrLf + "Wold you like to Continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                            flagTran = False
                            Exit For
                        Else
                            flagTran = True
                        End If
                    End If
                Else
                    If DialogResult.Yes = MessageBox.Show("Error at row number " + CStr(row.HeaderCell.Value) + vbCrLf + "Wold you like to Continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                        flagTran = False
                        Exit For
                    Else
                        flagTran = True
                        MsgBox("Successful")
                    End If
                End If
            Next
            If flagTran Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Private Function validarRowKPI(ByVal row As DataGridViewRow) As Boolean
        Try
            Dim flag As Boolean = True
            For Each cell As DataGridViewCell In row.Cells()
                Select Case cell.ColumnIndex
                    Case row.Cells("TypeKPIS").ColumnIndex
                        If cell.Value Is DBNull.Value Then
                            flag = False
                            Exit For
                        End If
                    Case row.Cells("IdAuxS").ColumnIndex
                        If cell.Value Is DBNull.Value Then
                            flag = False
                            Exit For
                        End If
                    Case row.Cells("DateWorkedS").ColumnIndex
                        If cell.Value Is DBNull.Value Then
                            cell.Value = CStr(System.DateTime.Today.Month) + "/" + CStr(System.DateTime.Today.Day) + "/" + CStr(System.DateTime.Today.Year)
                        End If
                    Case 9 To 20
                        If cell.Value Is DBNull.Value Or cell.Value = "" Then
                            cell.Value = "0"
                        End If
                    Case 21 To 22
                        If cell.Value Is DBNull.Value Or cell.Value = "" Then
                            cell.Value = ""
                        End If
                End Select
            Next
            Return flag
        Catch ex As Exception

        End Try
    End Function
    Public Function InsertKPIs(ByVal tbl As DataGridView, ByVal TypeKPI As String, ByRef pgb As ProgressBar, ByRef lblMesage As Label) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            lblMesage.Text = "Message: Starting insert process..."

            Dim flagCommit As Boolean = False
            Dim indexRowError As Integer = 0
            pgb.Value = 5
            Dim rowstbl As Integer = tbl.Rows.Count
            Dim increment = (90 / rowstbl)

            Dim flagIncrement = If(increment > 1, CInt(90 / rowstbl), If(increment < 1 And increment > 0.5, 2, If(increment < 0.5 And increment > 0.25, 3, 4)))
            'lblMessage.Text = "Message: Reading Excel..."
            pgb.Value = pgb.Value + 5
            Dim countIncrement As Integer = 0

            For Each row As DataGridViewRow In tbl.Rows()
                Try
                    lblMesage.Text = "Message: Row number " + CStr(row.Index)
                    If Not row.IsNewRow Then
                        indexRowError = row.Index
                        Dim cmd As New SqlCommand("insert into KPI values('" + TypeKPI + "','" + row.Cells("CasePaint").Value.ToString() + "'," + If(row.Cells("Lead").Value = True, "1", "0") + "," + If(row.Cells("STResistence").Value = True, "1", "0") + ",'" + If(row.Cells("description").Value Is DBNull.Value, "", row.Cells("description").Value.ToString) + "'," + row.Cells("JobNo").Value.ToString() + ",'" + row.Cells("IdAux").Value.ToString() + "','" + validaFechaParaSQl(row.Cells("DateWorked").Value.ToString()) + "',
                        " + If(row.Cells("Tinck").Value = "", "0", row.Cells("Tinck").Value.ToString) + "," + If(row.Cells("Size").Value = "", "0", row.Cells("Size").Value.ToString) + "," + If(row.Cells("SQFT").Value = "", "0", row.Cells("SQFT").Value.ToString) + "," + If(row.Cells("LF").Value = "", "0", row.Cells("LF").Value.ToString) + ",
                        " + If(row.Cells("Qty90").Value = "", "0", row.Cells("Qty90").Value.ToString) + "," + If(row.Cells("Qty45").Value = "", "0", row.Cells("Qty45").Value.ToString) + "," + If(row.Cells("TEE").Value = "", "0", row.Cells("TEE").Value.ToString) + "," + If(row.Cells("RED").Value = "", "0", row.Cells("RED").Value.ToString) + "," + If(row.Cells("CAP").Value = "", "0", row.Cells("CAP").Value.ToString) + "," + If(row.Cells("FLG").Value = "", "0", row.Cells("FLG").Value.ToString) + "," + If(row.Cells("FIT").Value = "", "0", row.Cells("FIT").Value.ToString) + "," + If(row.Cells("Valves").Value = "", "0", row.Cells("Valves").Value.ToString) + ",
                        " + If(row.Cells("ST").Value = "", "0", row.Cells("ST").Value.ToString) + "," + If(row.Cells("OT").Value = "", "0", row.Cells("OT").Value.ToString) + ",'" + If(row.Cells("Install").Value = "", "", row.Cells("Install").Value.ToString) + "')")
                        cmd.Connection = conn
                        cmd.Transaction = tran
                        If cmd.ExecuteNonQuery > 0 Then
                            flagCommit = True
                            countIncrement += 1
                            If pgb.Value <= 96 Then
                                If flagIncrement = countIncrement Then
                                    pgb.Value = pgb.Value + 1
                                    countIncrement = 0
                                End If
                            End If
                        Else
                            If DialogResult.Yes = MessageBox.Show("Error at the row " + CStr(indexRowError) + ", Would you like to cancel the process?", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning) Then
                                pgb.Value = 100
                                flagCommit = False
                                Exit For
                            Else
                                flagCommit = True
                            End If
                        End If
                    End If
                Catch ex As Exception
                    If DialogResult.Yes = MessageBox.Show("Error at the row " + CStr(indexRowError) + ", Would you like to cancel the process?" + ex.Message(), "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning) Then
                        pgb.Value = 100
                        flagCommit = False
                    Else
                        flagCommit = True
                        Exit For
                    End If
                End Try
            Next
            If flagCommit Then
                tran.Commit()
                lblMesage.Text = "Message: End."
                pgb.Value = 100
            Else
                tran.Rollback()
                lblMesage.Text = "Message: Error."
                pgb.Value = 100
                MessageBox.Show("Error at the row " + CStr(indexRowError) + ", Please verify the Data and try Againg.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            desconectar()
        End Try
        Return False
    End Function

    Public Function deleteKPI(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flagTran As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim query As String
                If row.Cells(0).Value IsNot Nothing Then
                    query = "delete from KPI where idKPI=" + row.Cells("idKPI").Value.ToString() + ""
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery = 0 Then
                        MessageBox.Show("Error at row number " + CStr(row.HeaderCell.Value) + vbCrLf + "Is not posible delete the row.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        flagTran = False
                        Exit For
                    End If
                End If
            Next
            If flagTran Then
                tran.Commit()
                For Each row As DataGridViewRow In tbl.SelectedRows()
                    tbl.Rows.Remove(row)
                Next
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    '======================== METODOS PARA REPORTES ================================================================================================

    Public Function llenarTablaActiveScaffold(ByVal tbl As DataGridView, ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select T1.[WO#],T1.[Type (O,M,T,C)],T1.[Tag #],T1.[Pieces],T1.[Unit],T1.[Location],T1.[Build],T1.[ActiveDays] from ( 
select wo.idWO as 'WO#', 
case sj.[description] 
	when 'Maintenance' then 'M'
	when 'T/A' then 'T'
	when 'Capital' then 'C' 
	when 'Winterization' then 'W'
	when 'Operation' then 'O'
	when 'All' then 'All'
	when NULL then ''
	else sj.[description] 
end as 'Type (O,M,T,C)',
sc.tag as 'Tag #',
ISNULL((select SUM(pts.quantity) from productTotalScaffold as pts where pts.tag = sc.tag),0) as 'Pieces',
CONCAT(ar.idArea ,' ',ar.name) as 'Unit',
sc.location as 'Location',
sc.buildDate as 'Build'
,IIF(ds.dismantleDate is null , DATEDIFF(DAY,DATEADD(DAY, -1,sc.buildDate),GETDATE()),DATEDIFF(DAY,DATEADD(DAY, -1,sc.buildDate) ,ds.dismantleDate)) as 'ActiveDays'
,ISNULL(jc.[days],0) as 'Conctract Days'
from scaffoldTraking as sc
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join areas as ar on ar.idArea = sc.idArea
left join jobCat as jc on jc.idJobCat = sc.idJobCat
left join dismantle as ds on ds.tag = sc.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO= tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where ds.idDismantle is null and cl.numberClient = " + numberClient + "
) as T1 where T1.[ActiveDays] <= T1.[Conctract Days]", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            While dr.Read()
                tbl.Rows.Add(dr("WO#"), dr("Type (O,M,T,C)"), dr("Tag #"), dr("Pieces"), dr("Unit"), dr("Location"), CDate(dr("Build")).ToString("MM/dd/yyyy"), dr("ActiveDays"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class