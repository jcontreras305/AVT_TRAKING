Imports System.Data.SqlClient
Public Class MetodosHoursPeerWeek
    Inherits ConnectioDB
    Dim mtdJobs As New MetodosJobs
    Public idEmpleadoFind As String
    Public Function llenarEmpleadosCombo(ByVal combo As ComboBox, ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEmployee, CONCAT(firstName,' ',middleName,' ',lastName) , photo as 'Photo', SAPNumber, numberEmploye , perdiem from employees where estatus = 'E' ", conn)
            tabla.Rows.Clear()
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
            End If
            combo.Items.Clear()
            For Each row As DataRow In tabla.Rows
                combo.Items.Add(row.ItemArray(1))
            Next
            If combo.Items.Count > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Dim consultaHoras As String = "select 
hw.idHorsWorked,
CONVERT(varchar,hw.dateWorked,101) as 'Date',
CONCAT(wo.idWO ,'-', tk.task) as 'Project',
tk.description as 'Project Description',
wc.name as 'Work Code',
wc.description as 'Clasification',
hw.hoursST as 'Hours ST',
hw.hoursOT as 'Hours OT',
hw.hours3 as 'Hours 3',
hw.schedule as 'Shift',
wc.billingRate1 as 'Billing Rate',
wc.billingRateOT as 'Billing Rate OT',
wc.billingRate3 as 'Billing Rate 3',
hw.jobNo
from employees as emp 
inner join hoursWorked as hw on emp.idEmployee = hw.idEmployee
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and hw.jobNo = wc.jobNo
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO "
    Public Function buscarHoras(ByRef tblHoras As DataGridView, ByVal idEmpleado As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaHoras + " where emp.idEmployee='" + idEmpleado + "' order by hw.dateWorked desc", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tblHoras.DataSource = dt
                tblHoras.Columns("idHorsWorked").Visible = False
                tblHoras.Columns("jobNo").Visible = False
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function buscarHoras(ByVal tblHoras As DataGridView, ByVal idEmpleado As String, ByVal fechaStart As String, ByVal fechaEnd As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaHoras + " where emp.idEmployee='" + idEmpleado + "' and hw.dateWorked between '" + fechaStart + "' and '" + fechaEnd + "' order by hw.dateWorked asc", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tblHoras.DataSource = dt
                tblHoras.Columns("idHorsWorked").Visible = False
                tblHoras.Columns("jobNo").Visible = False
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function bucarExpensesEmpleado(ByVal tabla As DataGridView, ByVal idEmployee As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
exu.idExpenseUsed,
CONVERT(varchar,exu.dateExpense,101) as 'Date',
CONCAT(wo.idWO,'-',tk.task) as 'Project',
ex.expenseCode as 'Expense Code',
exu.amount as 'Amount $',
exu.description as 'Description'
from expensesUsed as exu
inner join expenses as ex on ex.idExpenses = exu.idExpense
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
where exu.idEmployee = '" + idEmployee + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns("idExpenseUsed").Visible = False
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function

    Public Function llenarTablaProyecto(ByVal proyectTable As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tk.idAux as 'task', CONCAT(wo.idWO,'-',tk.task) as 'project' , tk.description, po.idPO, jb.jobNo, wo.idAuxWO,wo.idWO,tk.task from workOrder as wo 
inner join task as tk on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo", conn)
            If cmd.ExecuteNonQuery Then
                proyectTable.Clear()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(proyectTable)
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function



    Public Function llenarComboCellProject(ByVal cmbProyect As DataGridViewComboBoxCell, ByVal proyectTable As DataTable, Optional lastValue As String = "") As String
        Try
            conectar()
            cmbProyect.Items.Clear()
            proyectTable.Clear()
            Dim cmd As New SqlCommand("select tk.idAux as 'task', CONCAT(wo.idWO,'-',tk.task) as 'project' , tk.description , po.idPO , jb.jobNo from workOrder as wo 
inner join task as tk on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on po.jobNo = jb.jobNo
order by jb.jobNo,po.idPO , CONCAT(wo.idWO,'-',tk.task) asc
", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(proyectTable)
                Dim cmbValue As String = ""
                For Each row As DataRow In proyectTable.Rows
                    cmbProyect.Items.Add(CStr(row.ItemArray(1)) + "    " + CStr(row.ItemArray(3)) + "    " + CStr(row.ItemArray(4)))
                    If lastValue = row.ItemArray(1) Then
                        cmbValue = CStr(row.ItemArray(1)) + "    " + CStr(row.ItemArray(3)) + "    " + CStr(row.ItemArray(4))
                    End If
                Next
                desconectar()
                Return cmbValue
            Else
                desconectar()
                Return ""
            End If
        Catch ex As Exception
            desconectar()
            Return ""
        End Try
    End Function

    Public Function llenarTablaWorkCode(ByVal workCodeTable As DataTable) As Boolean
        Try
            conectar()
            If workCodeTable IsNot Nothing Then
                workCodeTable.Clear()
            End If
            Dim cmd As New SqlCommand("select idWorkCode ,name , description , billingRate1 , billingRateOT , billingRate3 ,jobNo from workCode ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(workCodeTable)
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function
    Public Function llenarComboCellWorkCode(ByVal cmbWorkCode As DataGridViewComboBoxCell, ByVal jobNo As String, Optional lastValue As String = "") As String
        Try
            conectar()
            cmbWorkCode.Items.Clear()
            Dim cmd As New SqlCommand("select idWorkCode ,name , description , billingRate1 , billingRateOT , billingRate3 from workCode where jobNo = " + jobNo, conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim workCodeTable As New DataTable
                da.Fill(workCodeTable)
                Dim cmbValue As String = ""
                If cmbWorkCode.Items.Count > 0 Then
                    cmbWorkCode.Items.Clear()
                End If
                For Each row As DataRow In workCodeTable.Rows
                    cmbWorkCode.Items.Add(row.ItemArray(1))
                    If lastValue = row.ItemArray(1) Then
                        cmbValue = row.ItemArray(1).ToString()
                    End If
                Next
                desconectar()
                Return cmbValue
            Else
                desconectar()
                Return ""
            End If
        Catch ex As Exception
            desconectar()
            Return ""
        End Try
    End Function

    Public Function llenarComboCellExpeseCode(ByVal cmbExpenseCode As DataGridViewComboBoxCell, ByVal expenseCodeTable As DataTable, Optional lastValue As String = "") As String
        Try
            conectar()
            cmbExpenseCode.Items.Clear()
            expenseCodeTable.Clear()
            Dim cmd As New SqlCommand("select idExpenses , expenseCode from expenses ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(expenseCodeTable)
                Dim cmbValue As String = ""
                For Each row As DataRow In expenseCodeTable.Rows
                    cmbExpenseCode.Items.Add(row.ItemArray(1))
                    If lastValue = row.ItemArray(1) Then
                        cmbValue = row.ItemArray(1)
                    End If
                Next
                Return cmbValue
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

    Public Function llenarTablaExpenses(ByVal expensesTable As DataTable) As Boolean
        Try
            conectar()
            expensesTable.Clear()
            Dim cmd As New SqlCommand("select idExpenses , expenseCode from expenses ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(expensesTable)
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function

    Public Function InsertarRecord(ByVal listDatos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT(*) from hoursWorked where idAux = '" + listDatos(8) + "' and idEmployee = '" + listDatos(5) + "' and dateWorked = '" + listDatos(4) + "' and idWorkCode = " + listDatos(6) + " )=0
begin
insert into hoursWorked values(NEWID()," + listDatos(1) + "," + listDatos(2) + "," + listDatos(3) + ",'" + listDatos(4) + "','" + listDatos(5) + "'," + listDatos(6) + ",'" + listDatos(8) + "','" + listDatos(9) + "'," + listDatos(7) + ")
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                mtdJobs.UpdateTotalSpendTask(listDatos(7))
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            desconectar()
            Return False
        End Try
    End Function

    Public Function updateRecord(ByVal listDatos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update hoursWorked set hoursST = " + listDatos(1) + ", hoursOT = " + listDatos(2) + ", hours3= " + listDatos(3) + ",dateWorked = '" + listDatos(4) + "', idWorkCode = " + listDatos(6) + " , idAux = '" + listDatos(7) + "' , schedule = '" + listDatos(8) + "' where idHorsWorked ='" + listDatos(0) + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                mtdJobs.UpdateTotalSpendTask(listDatos(7))
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function

    Public Function insertExpensesUsed(ByVal datos As List(Of String)) As Boolean
        Try
            conectar()
            Dim id As Guid = Guid.NewGuid()
            Dim cmd As New SqlCommand("if (select count(*) from hoursWorked where idAux = '" + datos(5) + "' and dateWorked = '" + datos(1) + "') = 0
begin 
	insert into hoursWorked values ('" + id.ToString() + "',0,0,0,'" + datos(1) + "','" + datos(6) + "',NUll,'" + datos(5) + "','DAYS')
	insert into expensesUsed values (NEWID(),'" + datos(1) + "'," + datos(2) + ",'" + datos(3).ToString().Replace("'", "''") + "','" + datos(4) + "','" + datos(5) + "','" + datos(6) + "','" + id.ToString() + "')
end
else
begin 
	insert into expensesUsed values (NEWID(),'" + datos(1) + "'," + datos(2) + ",'" + datos(3) + "','" + datos(4) + "','" + datos(5) + "','" + datos(6) + "',(select top 1 idHorsWorked from hoursWorked where idAux = '" + datos(5) + "' and dateWorked = '" + datos(1) + "'))
end", conn)
            If cmd.ExecuteNonQuery >= 1 Then
                mtdJobs.UpdateTotalSpendTask(datos(5))
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateExpensesUsed(ByVal datos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
            update expensesUsed set dateExpense = '" + datos(1) + "' , amount= " + datos(2) + " , description = '" + datos(3) + "' , idExpense = '" + datos(4) + "' , idAux= '" + datos(5) + "' where idExpenseUsed = '" + datos(0) + "' ", conn)
            If cmd.ExecuteNonQuery = 1 Then
                mtdJobs.UpdateTotalSpendTask(datos(5))
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteRecordEmployee(ByVal idRecord As String, ByVal idTask As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from hoursWorked where idHorsWorked = '" + idRecord + "'", conn)
            If cmd.ExecuteNonQuery Then
                mtdJobs.UpdateTotalSpendTask(idTask)
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteExpense(ByVal idExpense As String, ByVal idTask As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from expensesUsed where idExpenseUsed = '" + idExpense + "'", conn)
            If cmd.ExecuteNonQuery Then
                mtdJobs.UpdateTotalSpendTask(idTask)
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    '============================================================================================================
    '=================== METODOS PARA WORKORDERS DENTRO DE TIMESHEET ============================================
    '============================================================================================================

    Public Function selectWOTimeSheet() As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
tk.equipament as 'Equipament',
concat(wo.idWO,'-',tk.task) as 'WorkOrder',
tk.description as 'Description',
tk.accountNum as 'Aco.N',
tk.expCode as 'ExpCode',
tk.estimateHours as 'Hours',
po.idPO,
po.jobNo
from task as tk 
inner join workOrder as wo on tk.idAuxWO = wo.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
where tk.status = 0 ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                desconectar()
                Return dt
            Else
                desconectar()
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex)
            desconectar()
            Return Nothing
        End Try
    End Function
    '================================================================================================
    '==================== METODOS PARA PEYROLL ======================================================
    '================================================================================================

    Public Function insertWeek(ByVal week As Date, ByVal weekNum As Integer) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select count(*) from weeks where dateWeek= '" + validaFechaParaSQl(week) + "')=0
begin
	insert into weeks values('" + validaFechaParaSQl(week) + "'," + CStr(weekNum) + ")
end
else if (select count(*) from weeks where dateWeek= '" + validaFechaParaSQl(week) + "')>0
begin
	update weeks set weekN = " + CStr(weekNum) + " where dateWeek='" + validaFechaParaSQl(week) + "'
end", conn)
            If cmd.ExecuteNonQuery() > 0 Then
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

    Public Function updateWeek(ByVal lastweek As Date, ByVal newWeek As Date, ByVal weekNum As Integer) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select count(*) from weeks where dateWeek = '" + validaFechaParaSQl(lastweek) + "' )=1
begin
	update weeks set weekN = " + CStr(weekNum) + " , dateWeek = '" + validaFechaParaSQl(newWeek) + "' where dateWeek = '" + validaFechaParaSQl(lastweek) + "'
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
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

    Public Function deleteWeek(ByVal week As Date) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from weeks where dateWeek = '" + validaFechaParaSQl(week) + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
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

    Public Function selectWeeks(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select convert(varchar, dateWeek,101) as 'dateWeek' ,weekN from weeks", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            While dr.Read()
                tbl.Rows.Add(dr("dateWeek"), CStr(dr("weekN")))
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

    Public Function selectPayroll(ByVal tbl As DataGridView, ByVal startDate As Date) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select distinct 
	em.numberEmploye, 
	case when (select top 1 weekN from weeks where dateWeek >=	hw.dateWorked order by dateWeek asc) is null then 0 
		else (select top 1 weekN from weeks where dateWeek >= hw.dateWorked order by dateWeek asc) end as 'WeekNumber',
	SUBSTRING(CONVERT(nvarchar , po.jobNo),0,LEN( CONVERT(nvarchar , po.jobNo))-2) as 'Job Number',
	SUBSTRING(CONVERT(nvarchar , po.jobNo),LEN( CONVERT(nvarchar , po.jobNo))-2,LEN( CONVERT(nvarchar , po.jobNo))+1) as 'Sub Job Number',
	jb.costDistribution,
	iif(DATEPART(dw,hw.dateWorked)='1',7,(convert (int ,DATEPART(dw,hw.dateWorked))-1)) as 'DayOfWeek',
	(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and not wc1.name like '%6.4%' ) as 'RegularHours',
	(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and not wc1.name like '%6.4%' ) as 'OvertimeHours',
	(select iif(SUM(hw1.hours3) is null,0,SUM(hw1.hours3))  from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and not wc1.name like '%6.4%' ) as 'OtherHours'
 from hoursWorked as hw
inner join employees as em  on hw.idEmployee = em.idEmployee
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where (hw.dateWorked between '" + validaFechaParaSQl(startDate) + "' and DATEADD(day,6,'" + validaFechaParaSQl(startDate) + "') and not wc.name like '%6.4%') 
order by em.numberEmploye", conn)
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tbl.Rows.Add("A", "5", dr("numberEmploye"), dr("WeekNumber"), dr("Job Number"), dr("Sub Job Number"), dr("costDistribution"), "L", dr("DayOfWeek"), dr("RegularHours"), dr("OvertimeHours"), dr("OtherHours"), "740", "R")
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

    Public Function selectNONBILLABLE(ByVal tbl As DataGridView, ByVal startDate As Date) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee',
em.numberEmploye,
SUBSTRING(CONVERT(nvarchar , po.jobNo),0,LEN( CONVERT(nvarchar , po.jobNo))-2) as 'Job Number',
SUBSTRING(CONVERT(nvarchar , po.jobNo),LEN( CONVERT(nvarchar , po.jobNo))-2,LEN( CONVERT(nvarchar , po.jobNo))+1) as 'Sub Job Number',
hw.dateWorked,
hw.hoursST,
hw.hoursOT,
(select payRate1 from payRate where datePayRate = (select MAX(datePayRate) from payRate where idEmployee = em.idEmployee))as 'STRate',
wc.name as 'description'
from hoursWorked as hw 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join employees as em on em.idEmployee = hw.idEmployee
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where (hw.dateWorked between '" + validaFechaParaSQl(startDate) + "' and DATEADD(day,6,'" + validaFechaParaSQl(startDate) + "')) and wc.name like '%6.4%'
order by em.numberEmploye", conn)
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tbl.Rows.Add(dr("Employee"), dr("numberEmploye"), dr("Job Number"), dr("Sub Job Number"), dr("dateWorked"), dr("hoursST"), dr("hoursOT"), dr("STRate"), dr("description"))
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
    '================================================================================================
    '==================== METODOS PARA PERDIEM ======================================================
    '================================================================================================
    Public Function selectPerdiem(ByVal tbl As DataGridView, ByVal startDate As Date) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
distinct
em.numberEmploye,
case when (select top 1 weekN from weeks where dateWeek >=	exu.dateExpense order by dateWeek asc) is null then 0 
	else (select top 1 weekN from weeks where dateWeek >= exu.dateExpense order by dateWeek asc) end as 'WeekNumber',
	SUBSTRING(CONVERT(nvarchar , po.jobNo),0,LEN( CONVERT(nvarchar , po.jobNo))-2) as 'Job Number',
    SUBSTRING(CONVERT(nvarchar , po.jobNo),LEN( CONVERT(nvarchar , po.jobNo))-2,LEN( CONVERT(nvarchar , po.jobNo))+1) as 'Sub Job Number',
	jb.costDistribution,
	iif(DATEPART(dw,exu.dateExpense)='1',7,(convert (int ,DATEPART(dw,exu.dateExpense))-1)) as 'DayOfWeek',
	(select iif(SUM(exu1.amount)is null,0,SUM(exu1.amount)) from expensesUsed as exu1 inner join expenses as ex1 on ex1.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where exu1.dateExpense = exu.dateExpense and em.idEmployee = exu1.idEmployee and jb.jobNo = jb1.jobNo ) as 'Adjustment Amount'
from expensesUsed as exu
inner join employees as em on em.idEmployee = exu.idEmployee
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where exu.dateExpense between '" + validaFechaParaSQl(startDate) + "' and DATEADD(day,6,'" + validaFechaParaSQl(startDate) + "') 
order by em.numberEmploye", conn)
            If tbl.Rows IsNot Nothing Then
                tbl.Rows.Clear()
            End If
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tbl.Rows.Add("A", "5", dr("numberEmploye"), dr("WeekNumber"), dr("Job Number"), dr("Sub Job Number"), dr("costDistribution"), "Y", dr("DayOfWeek"), "0", "0", "0", "0", "NT", dr("Adjustment Amount"), "050", "7400", "SB")
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        Finally
            desconectar()
        End Try
    End Function

    '##################################################################################################################################################################
    '############ METODOS PARA TRACK ##################################################################################################################################
    '##################################################################################################################################################################

    Public Function selectHorasTrack(ByVal beginDate As Date, ByVal endDate As Date, ByVal numberClient As String, ByVal job As String) As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
ROW_NUMBER() OVER(order by (select 1)) as 'Record ID',
T1.[Date],
T1.[Resource ID],
T1.[Resource Name],
T1.[Skill Type],
T1.Shifth,
T1.[Level 1 ID],
T1.[Level 2 ID],
T1.[S/T Hrs],
(iif(T1.[S/T Hrs] > 0 , 'NA','')) as 'S/T Hrs Activity Code',
T1.[O/T Hrs],
(iif(T1.[O/T Hrs] > 0 , 'NA','')) as 'O/T Hrs Activity Code',
T1.[D/T Hrs],
(iif(T1.[D/T Hrs] > 0 , 'NA','')) as 'D/T Hrs Activity Code',
'' as 'Extra Change'
 from (
	
	select    
	distinct
	REPLACE(CONVERT(nvarchar, hw.dateWorked),'-','') as 'Date', 
	iif(em.SAPNumber is null,'',em.SAPNumber) as 'Resource ID' ,
	CONCAT(em.lastName,', ',em.firstName,' ',em.middleName)as 'Resource Name', 
	wc.EQExp1 as 'Skill Type',
	hw.schedule as 'Shifth', 
	iif((select CHARINDEX('6.4',wc.name))>0,'NB',concat(wo.idWO,'-', tk.task)) as 'Level 1 ID',
	po.idPO as 'Level 2 ID',
	(select SUM( hw1.hoursST) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idworkcode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO =wo1.idPO and po1.jobNo = wo1.jobNo 
		where tk1.idAux = tk.idAux  and wo1.idAuxWO = wo.idAuxWO and po1.idPO =po.idPO and hw1.schedule = hw.schedule and hw1.idEmployee = hw.idEmployee and hw1.dateWorked = hw.dateWorked and  wc1.EQExp1 = wc.EQExp1)as 'S/T Hrs',
	(select SUM( hw1.hoursOT) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idworkcode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO =wo1.idPO and po1.jobNo = wo1.jobNo 
		where tk1.idAux = tk.idAux  and wo1.idAuxWO = wo.idAuxWO and po1.idPO =po.idPO and hw1.schedule = hw.schedule and hw1.idEmployee = hw.idEmployee and hw1.dateWorked = hw.dateWorked and wc1.EQExp1 = wc.EQExp1)as 'O/T Hrs',
	(select SUM( hw1.hours3) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idworkcode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO =wo1.idPO and po1.jobNo = wo1.jobNo 
		where tk1.idAux = tk.idAux  and wo1.idAuxWO = wo.idAuxWO and po1.idPO =po.idPO and hw1.schedule = hw.schedule and hw1.idEmployee = hw.idEmployee and hw1.dateWorked = hw.dateWorked and wc1.EQExp1 = wc.EQExp1)as 'D/T Hrs'
	from hoursWorked as hw 
	inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
	inner join employees as em on hw.idEmployee = em.idEmployee
	inner join task as tk on tk.idAux = hw.idAux
	inner join workOrder as wo on tk.idAuxWO = wo.idAuxWO 
	inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
	inner join job as jb on jb.jobNo = po.jobNo
	inner join clients as cl on cl.idClient = jb.idClient
	where hw.dateWorked between '" + validaFechaParaSQl(beginDate) + "' and '" + validaFechaParaSQl(endDate) + "' 
        and cl.numberClient = " + numberClient + "  " + If(job <> "", " and jb.jobNo = " + job + " ", "") + "
)as T1", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectPerdiemTrack(ByVal beginDate As Date, ByVal endDate As Date, ByVal numberClient As String, ByVal job As String) As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
distinct 
REPLACE(CONVERT(nvarchar, exu.dateExpense),'-','') as 'Date', 
iif(em.SAPNumber is null,'',em.SAPNumber) as 'Resource ID' ,
CONCAT(em.lastName,', ',em.firstName,' ',em.middleName)as 'Resource Name', 
concat(wo.idWO,'-', tk.task) as 'Level 1 ID',
po.idPO as 'Level 2 ID',
isnull( (select sum(exu1.amount) from expensesUsed as exu1 inner join task as tk1 on tk1.idAux = exu1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo=po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient 
	where tk.idAux = tk1.idAux and wo.idAuxWO = wo1.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and cl.idClient = cl1.idClient and exu.dateExpense = exu1.dateExpense and exu.idEmployee =exu1.idEmployee ),'') as 'Extra Change'
from expensesUsed as exu 
	inner join employees as em on exu.idEmployee = em.idEmployee
	inner join task as tk on tk.idAux = exu.idAux
	inner join workOrder as wo on tk.idAuxWO = wo.idAuxWO 
	inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
	inner join job as jb on jb.jobNo = po.jobNo
	inner join clients as cl on cl.idClient = jb.idClient
	where exu.dateExpense between '" + validaFechaParaSQl(beginDate) + "' and '" + validaFechaParaSQl(endDate) + "'
    and cl.numberClient = " + numberClient + "  " + If(job <> "", " and jb.jobNo = " + job + " ", ""), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarTablaDefaultElemtTrack(ByVal tbl As DataGridView, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from TrackDefaultElements as tde inner join clients as cl on cl.idClient =tde.idClient where cl.numberClient = " + idClient + "", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add("Force Or Reject", dr("Force Or Reject"))
                tbl.Rows.Add("Source", dr("Source"))
                tbl.Rows.Add("Order Type", dr("Order Type"))
                tbl.Rows.Add("Location ID", dr("Location ID"))
                tbl.Rows.Add("Company Code", dr("Company Code"))
                tbl.Rows.Add("Area", dr("Area"))
                tbl.Rows.Add("Group Name", dr("Group Name"))
                tbl.Rows.Add("Agreement", dr("Agreement"))
                tbl.Rows.Add("Level 3 ID", dr("Level 3 ID"))
                tbl.Rows.Add("Level 4 ID", dr("Level 4 ID"))
                tbl.Rows.Add("Hours Total", dr("Hours Total"))
                tbl.Rows.Add("Hours Total Activity Code", dr("Hours Total Activity Code"))
                tbl.Rows.Add("Extra Charges $ Activity Code", dr("Extra Charges $ Activity Code"))
                tbl.Rows.Add("Extra", dr("Extra"))
                tbl.Rows.Add("Extra 1", dr("Extra 1"))
                tbl.Rows.Add("Extra 2", dr("Extra 2"))
                tbl.Rows.Add("Add Time", dr("Add Time"))
                tbl.Rows.Add("Pay Type", dr("Pay Type"))
                tbl.Rows.Add("R4 (Hrs)", dr(20))
                tbl.Rows.Add("R5 (Hrs)", dr(21))
                tbl.Rows.Add("R6 (Hrs)", dr(22))
                tbl.Rows.Add("GL Account", dr("GL Account"))
                tbl.Rows.Add("ST Adders", dr("ST Adders"))
                tbl.Rows.Add("OT Adders", dr("OT Adders"))
                tbl.Rows.Add("DT Adders", dr("DT Adders"))
                tbl.Rows.Add("R4 Adders", dr("R4 Adders"))
                tbl.Rows.Add("R5 Adders", dr("R5 Adders"))
                tbl.Rows.Add("R6 Adders", dr("R6 Adders"))
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

    Public Function llenarTablaFormatColumns(ByVal tbl As DataGridView, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from TrackFormatColums as tfe inner join clients as cl on cl.idClient =tfe.idClient where cl.numberClient = " + idClient + "", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            Dim values() As String
            While dr.Read()
                values = seperarDatosFormatColumnsTable(dr("Record ID"))
                tbl.Rows.Add("Record ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Force Or Reject"))
                tbl.Rows.Add("Force Or Reject", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Source"))
                tbl.Rows.Add("Source", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Date"))
                tbl.Rows.Add("Date", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Order Type"))
                tbl.Rows.Add("Order Type", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Location ID"))
                tbl.Rows.Add("Location ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Company Code"))
                tbl.Rows.Add("Company Code", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Resource ID"))
                tbl.Rows.Add("Resource ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Resource Name"))
                tbl.Rows.Add("Resource Name", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Area"))
                tbl.Rows.Add("Area", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Group Name"))
                tbl.Rows.Add("Group Name", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Agreement"))
                tbl.Rows.Add("Agreement", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Skill Type"))
                tbl.Rows.Add("Skill Type", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Shift"))
                tbl.Rows.Add("Shift", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Level 1 ID"))
                tbl.Rows.Add("Level 1 ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Level 2 ID"))
                tbl.Rows.Add("Level 2 ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Level 3 ID"))
                tbl.Rows.Add("Level 3 ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Level 4 ID"))
                tbl.Rows.Add("Level 4 ID", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Hours Total"))
                tbl.Rows.Add("Hours Total", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Hours Total Activity Code"))
                tbl.Rows.Add("Hours Total Activity Code", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr(22))
                tbl.Rows.Add("S/T (Hrs)", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("S/T Hrs Activity Code"))
                tbl.Rows.Add("S/T Hrs Activity Code", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr(24))
                tbl.Rows.Add("O/T (Hrs)", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("O/T Hrs Activity Code"))
                tbl.Rows.Add("O/T Hrs Activity Code", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr(26))
                tbl.Rows.Add("D/T (Hrs)", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("D/T Hrs Activity Code"))
                tbl.Rows.Add("D/T Hrs Activity Code", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Extra Charges $"))
                tbl.Rows.Add("Extra Charges $", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Extra Charges $ Activity Code"))
                tbl.Rows.Add("Extra Charges $ Activity Code", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Extra"))
                tbl.Rows.Add("Extra", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Extra 1"))
                tbl.Rows.Add("Extra 1", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Extra 2"))
                tbl.Rows.Add("Extra 2", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Add Time"))
                tbl.Rows.Add("Add Time", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("Pay Type"))
                tbl.Rows.Add("Pay Type", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr(35))
                tbl.Rows.Add("R4 (Hrs)", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr(36))
                tbl.Rows.Add("R5 (Hrs)", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr(37))
                tbl.Rows.Add("R6 (Hrs)", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("GL Account"))
                tbl.Rows.Add("GL Account", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("ST Adders"))
                tbl.Rows.Add("ST Adders", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("OT Adders"))
                tbl.Rows.Add("OT Adders", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("DT Adders"))
                tbl.Rows.Add("DT Adders", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("R4 Adders"))
                tbl.Rows.Add("R4 Adders", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("R5 Adders"))
                tbl.Rows.Add("R5 Adders", If(values(1) = "1", True, False), values(0))

                values = seperarDatosFormatColumnsTable(dr("R6 Adders"))
                tbl.Rows.Add("R6 Adders", If(values(1) = "1", True, False), values(0))
                Exit While
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
    Private Function seperarDatosFormatColumnsTable(ByVal drVal As String) As String()
        Try
            Dim val1 = "", val2 = ""
            val1 = drVal.ToString.Remove(drVal.ToString.Length - 1)
            val2 = If(drVal.ToString.Chars(drVal.ToString.Length() - 1) = "1", "1", "0")
            Dim array() As String = {val1, val2}
            Return array
        Catch ex As Exception
            Return {"", "0"}
        End Try
    End Function
    Public Function updateHeaderColumn(ByVal columnName As String, ByVal headerText As String, ByVal visible As String, ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update trackFormatColums set [" + columnName + "] = '" + headerText + "" + visible + "' where idClient = (select top 1 idClient from clients where numberClient = " + numberClient + ")", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
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
    Public Function updateDefaultElement(ByVal columnName As String, ByVal defaultValue As String, ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update TrackDefaultElements set [" + columnName + "] = '" + defaultValue + "' where idClient = (select top 1 idClient from clients where numberClient = " + numberClient + ")", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
                Return True
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '###########################################################  consultas prueba insertar records ##################################################################
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
    Public Function lllenarTablaWorkCodes() As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idWorkCode , name , description, jobNo from workCode", conn)
            Dim dt As New DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("idWorkCode")
                dt.Columns.Add("name")
                dt.Columns.Add("description")
                dt.Columns.Add("jobnNo")
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarTablaEmpleado() As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select numberEmploye , CONCAT(lastName,', ',firstName , iif(middleName<>'' ,concat(' ',middleName),''))as name ,idEmployee from employees", conn)
            Dim dt As New DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("numberEmploye")
                dt.Columns.Add("name")
                dt.Columns.Add("idEmployee")
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function execBulkInsertRecords() As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("Bulk INSERT 
	hoursWorked
FROM 
	'C:\TMP\TimeSheetTemp.csv'
WITH(
	FIELDTERMINATOR =',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2,
	MAXERRORS = 3 --NORMALMENTE SE ENCUENTRA EN 10 
)", conn)
            If cmd.ExecuteNonQuery Then
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
End Class
