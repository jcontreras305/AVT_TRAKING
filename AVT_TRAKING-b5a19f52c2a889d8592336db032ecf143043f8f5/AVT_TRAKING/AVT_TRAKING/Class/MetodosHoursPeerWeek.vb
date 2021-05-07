Imports System.Data.SqlClient
Public Class MetodosHoursPeerWeek
    Inherits ConnectioDB
    Dim mtdJobs As New MetodosJobs
    Public idEmpleadoFind As String
    Public Function llenarEmpleadosCombo(ByVal combo As ComboBox, ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEmployee, CONCAT(firstName,' ',middleName,' ',lastName) , photo as 'Photo', SAPNumber, numberEmploye from employees where estatus = 'E' ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
            End If
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
CONCAT(wo.idWO ,' ', tk.task) as 'Project',
tk.description as 'Project Description',
wc.name as 'Work Code',
wc.description as 'Clasification',
hw.hoursST as 'Hours ST',
hw.hoursOT as 'Hours OT',
hw.hours3 as 'Hours 3',
hw.schedule as 'Shift',
wc.billingRate1 as 'Billing Rate',
wc.billingRateOT as 'Billing Rate OT',
wc.billingRate3 as 'Billing Rate 3'
from employees as emp 
inner join hoursWorked as hw on emp.idEmployee = hw.idEmployee
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO "
    Public Function buscarHoras(ByRef tblHoras As DataGridView, ByVal idEmpleado As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaHoras + " where emp.idEmployee='" + idEmpleado + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tblHoras.DataSource = dt
                tblHoras.Columns("idHorsWorked").Visible = False
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
CONCAT(wo.idWO,' ',tk.task) as 'Project',
ex.expenseCode as 'Expense Code',
exu.amount as 'Amount',
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
            Dim cmd As New SqlCommand("select tk.idAux as 'task', CONCAT(wo.idWO,'-',tk.task) as 'project' , tk.description, po.idPO, jb.jobNo, wo.idAuxWO from workOrder as wo 
inner join task as tk on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
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



    Public Function llenarComboCellProject(ByVal cmbProyect As DataGridViewComboBoxCell, ByVal proyectTable As DataTable) As Boolean
        Try
            conectar()
            cmbProyect.Items.Clear()
            proyectTable.Clear()
            Dim cmd As New SqlCommand("select tk.idAux as 'task', CONCAT(wo.idWO,' ',tk.task) as 'project' , tk.description from workOrder as wo 
inner join task as tk on wo.idAuxWO = tk.idAuxWO", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(proyectTable)
                For Each row As DataRow In proyectTable.Rows
                    cmbProyect.Items.Add(row.ItemArray(1))
                Next
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

    Public Function llenarTablaWorkCode(ByVal workCodeTable As DataTable) As Boolean
        Try
            conectar()
            If workCodeTable IsNot Nothing Then
                workCodeTable.Clear()
            End If
            Dim cmd As New SqlCommand("select idWorkCode ,name , description , billingRate1 , billingRateOT , billingRate3 from workCode ", conn)
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
    Public Function llenarComboCellWorkCode(ByVal cmbWorkCode As DataGridViewComboBoxCell, ByVal workCodeTable As DataTable) As Boolean
        Try
            conectar()
            cmbWorkCode.Items.Clear()
            workCodeTable.Clear()
            Dim cmd As New SqlCommand("select idWorkCode ,name , description , billingRate1 , billingRateOT , billingRate3 from workCode ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(workCodeTable)
                For Each row As DataRow In workCodeTable.Rows
                    cmbWorkCode.Items.Add(row.ItemArray(1))
                Next
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

    Public Function llenarComboCellExpeseCode(ByVal cmbExpenseCode As DataGridViewComboBoxCell, ByVal expenseCodeTable As DataTable) As Boolean
        Try
            conectar()
            cmbExpenseCode.Items.Clear()
            expenseCodeTable.Clear()
            Dim cmd As New SqlCommand("select idExpenses , expenseCode from expenses ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(expenseCodeTable)
                For Each row As DataRow In expenseCodeTable.Rows
                    cmbExpenseCode.Items.Add(row.ItemArray(1))
                Next
                desconectar()
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
            Dim cmd As New SqlCommand("insert into hoursWorked values(NEWID()," + listDatos(1) + "," + listDatos(2) + "," + listDatos(3) + ",'" + listDatos(4) + "','" + listDatos(5) + "'," + listDatos(6) + ",'" + listDatos(7) + "','" + listDatos(8) + "')", conn)
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
            Dim cmd As New SqlCommand("insert into expensesUsed values (NEWID(),'" + datos(1) + "'," + datos(2) + ",'" + datos(3) + "','" + datos(4) + "','" + datos(5) + "','" + datos(6) + "')", conn)
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

End Class
