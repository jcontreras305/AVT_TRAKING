Imports System.Data.SqlClient
Public Class MetodosJobs
    Inherits ConnectioDB

    '########################################################################################################################
    '############  METODOS PARA WORKCODE ####################################################################################
    '########################################################################################################################


    Public Sub selectWC(ByVal tabla As DataGridView)
        conectar()
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "select idWorkCode as ID , name Name , description as Description, billingRate1 as BillingRT1, billingRateOT as BillingOT, billingRate3 as BillingRT3 , EQExp1,EQExp2 from workCode  "
            cmd.Connection = conn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub nuevaWC(datos() As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into workCode values (" + datos(0) + ",'" + datos(1) + "','" + datos(2) + "'," + datos(3) + "," + datos(4) + "," + datos(5) + ",'" + datos(6) + "','" + datos(7) + "')")
            cmd.Connection = conn
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub acualizarWC(datos() As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update workCode set name='" + datos(1) + "',description ='" + datos(2) + "', billingRate1=" + datos(3) + ", billingRateOT=" + datos(4) + ", billingRate3= " + datos(5) + ",EQExp1='" + datos(6) + "',EQExp2='" + datos(7) + "' where idWorkCode =  " + datos(0), conn)
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub buscarWC(ByVal dato As String, ByVal tabla As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from workCode where idWorkCode like '" + dato + "' or  name like '%" + dato + "%' or description like '%" + dato + "%' ", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    '########################################################################################################################
    '############  METODOS PARA EXPENCES ####################################################################################
    '########################################################################################################################

    Public Sub buscarExpences(ByVal tabla As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from expenses", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns(0).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    Public Sub buscarExpences(ByVal tabla As DataGridView, ByVal dato As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from expenses where expenseCode like '%" + dato + "%' or description like '%" + dato + "%'", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns(0).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    Public Sub insertExpence(ByVal code As String, ByVal description As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into expenses values (NEWID(), '" + code + "','" + description + "')")
            cmd.Connection = conn
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub actualizarExpence(ByVal id As String, ByVal code As String, ByVal description As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update expenses set expenseCode = '" + code + "' , description = '" + description + "' where idExpenses = '" + id + "'", conn)
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub


    '########################################################################################################################
    '############  METODOS PARA PROYECTOS ###################################################################################

    Public Function insertarNuevoProyecto(ByVal idClient As String, ByVal datosPO As List(Of String)) As String
        Try
            conectar()
            Dim cmdIdPOMax As New SqlCommand("
select 
	Case
	when  MAX(idPO)+1 is NULL then '6000'
	else  MAX(idPO)+1 
	end
as idPOMax from projectOrder", conn)
            Dim idPOMax As String = ""
            Dim reader As SqlDataReader = cmdIdPOMax.ExecuteReader()
            While reader.Read()
                idPOMax = reader("idPOMax")
            End While
            reader.Close()
            Dim cmdidMaxWO As New SqlCommand("
select
case 
when max(idWO)+1 is null then '5000'
else  max(idWO)+1 end
as idWOMax
from workOrder 
", conn)
            Dim idWOMax As String = ""
            Dim reader2 As SqlDataReader = cmdidMaxWO.ExecuteReader()
            While reader2.Read()
                idWOMax = reader2("idWOMax")
            End While
            reader2.Close()

            Dim cmdAuxWO As New SqlCommand("select NEWID() AS 'newidWO'", conn)
            Dim idAuxWO As String = ""
            Dim reader3 As SqlDataReader = cmdAuxWO.ExecuteReader()
            While reader3.Read()
                Dim guid1 As New Guid
                guid1 = reader3("newidWO")
                idAuxWO = guid1.ToString("D")
            End While
            reader3.Close()

            Dim cmdJob As New SqlCommand("insert into job values (" + datosPO(0) + ",'" + datosPO(1) + "', '" + datosPO(2) + "'," + If(datosPO(3) = "", "NULL", datosPO(3)) + ", " + If(datosPO(4) = "", "NULL", datosPO(4)) + "," + datosPO(5) + ",'" + idClient + "')", conn)
            Dim cmdProyect As New SqlCommand("insert into projectOrder values (" + idPOMax + "," + datosPO(0) + ")", conn)
            Dim cmdWO As New SqlCommand("insert into workOrder values ('" + idAuxWO + "','" + idWOMax + "'," + idPOMax + ")", conn)
            Dim cmdTask As New SqlCommand("insert into task values (NEWID(),'','" + idAuxWO + "',0.0,'','','',0.0,GETDATE(),DATEADD(MM,1,GETDATE()),'','',0.0,'0',0)", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmdJob.Transaction = tran
            cmdProyect.Transaction = tran
            cmdWO.Transaction = tran
            cmdTask.Transaction = tran
            If cmdJob.ExecuteNonQuery Then
                If cmdProyect.ExecuteNonQuery Then
                    If cmdWO.ExecuteNonQuery Then
                        If cmdTask.ExecuteNonQuery Then
                            MsgBox("Succesfull")
                            tran.Commit()
                            Return idPOMax
                        Else
                            tran.Rollback()
                            MsgBox("Error")
                            Return Nothing
                        End If
                    Else
                        tran.Rollback()
                        MsgBox("Error")
                        Return Nothing
                    End If
                Else
                    tran.Rollback()
                    MsgBox("Error")
                    Return Nothing
                End If
            Else
                tran.Rollback()
                MsgBox("Error")
                Return Nothing
            End If
            desconectar()
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message())
            Return Nothing
        End Try
    End Function

    Public Function insertarNuevaTarea(ByVal projectN As Project) As Boolean
        Try
            conectar()
            Dim cmdCosultaJob As New SqlCommand("select count(*) as cantJOB from job where jobNo = " + CStr(projectN.jobNum), conn)
            Dim reader0 As SqlDataReader = cmdCosultaJob.ExecuteReader()
            Dim flagJob As String = ""
            While reader0.Read()
                flagJob = reader0("cantJOB")
                Exit While
            End While
            reader0.Close()
            If flagJob > 0 Then ' validando que exista el jobb no de lo contrario no se podra  insertar lo demas 
                Dim cmdCosultaPO As New SqlCommand("select count(idPO) as 'cantidadPO' from projectOrder where jobNo = " + CStr(projectN.jobNum) + " and idPO = '" + projectN.idPO + "'", conn)
                Dim reader As SqlDataReader = cmdCosultaPO.ExecuteReader()
                Dim flagPO As String = ""
                While reader.Read()
                    flagPO = reader("cantidadPO")
                    Exit While
                End While
                reader.Close()
                Dim cmdCosultaWO As New SqlCommand("select count(idWO) as 'cantidadWO' from workOrder where idWO = '" + projectN.idWorkOrder + "' and idPO = '" + projectN.idPO + "'", conn)
                Dim reader1 As SqlDataReader = cmdCosultaWO.ExecuteReader()
                Dim flagWO As String = ""
                While reader1.Read()
                    flagWO = reader1("cantidadWO")
                    Exit While
                End While
                reader1.Close()
                Dim cmdCosultaTask As New SqlCommand("select count(task) as 'cantidadTask' from task where idAuxWO= '" + projectN.idAuxWO + "' and task = '" + CStr(projectN.idTask) + "'", conn)
                Dim reader2 As SqlDataReader = cmdCosultaTask.ExecuteReader()
                Dim flagTask As String = ""
                While reader2.Read()
                    flagTask = reader2("cantidadTask")
                    Exit While
                End While
                reader2.Close()
                If flagPO <> "0" Then 'existe ya el ProjectOrder
                    If flagWO <> "0" Then 'existe ya el WorkOrder
                        If flagTask <> "0" Then 'ya existe el task
                            'No se puede por que ya existe el task en este WO
                            MessageBox.Show("The task already exists, we couldn't insert. Try whit other task", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            desconectar()
                            Return False
                        Else
                            Dim cmdInsertTask1 As New SqlCommand("insert into task 
                        values (NEWID(),'" + CStr(projectN.idTask) + "'," + If(projectN.idAuxWO = "", "(select top 1 workOrder.idAuxWO  from workOrder where idWO = '" + CStr(projectN.idWorkOrder) + "' and idPO = '" + CStr(projectN.idPO) + "')", "Null") + ",0.0,'" + projectN.equipament + "','" + projectN.manager + "'
                        ,'" + projectN.description + "'," + CStr(projectN.totalBilling) + ",'" + validaFechaParaSQl(projectN.beginDate) + "','" + validaFechaParaSQl(projectN.endDate) + "'
                        ,'" + projectN.expCode + "','" + projectN.accountNum + "'," + CStr(projectN.estimateHour) + ",'" + CStr(projectN.status) + "'," + CStr(projectN.PercentComplete) + ")", conn)
                            If cmdInsertTask1.ExecuteNonQuery = 1 Then
                                desconectar()
                                Return True
                            Else
                                desconectar()
                                Return False
                            End If
                        End If
                    Else
                        Dim cmdInsertNewWO As New SqlCommand("insert into workOrder values('" + projectN.idWorkOrder + "'," + CStr(projectN.jobNum) + ")", conn)
                        Dim cmdInsertTask2 As New SqlCommand("insert into task 
                        values (NEWID(),'" + CStr(projectN.idTask) + "','" + projectN.idAuxWO + "',0.0,'" + projectN.equipament + "','" + projectN.manager + "'
                        ,'" + projectN.description + "'," + CStr(projectN.totalBilling) + ",'" + validaFechaParaSQl(projectN.beginDate) + "','" + validaFechaParaSQl(projectN.endDate) + "'
                        ,'" + projectN.expCode + "','" + projectN.accountNum + "'," + CStr(projectN.estimateHour) + ",'" + CStr(projectN.status) + "'," + CStr(projectN.PercentComplete) + ")", conn)
                        Dim tranWO As SqlTransaction
                        tranWO = conn.BeginTransaction
                        cmdInsertNewWO.Transaction = tranWO
                        cmdInsertTask2.Transaction = tranWO
                        If cmdInsertNewWO.ExecuteNonQuery > 0 Then
                            If cmdInsertTask2.ExecuteNonQuery > 0 Then
                                tranWO.Commit()
                                Return True
                            Else
                                tranWO.Rollback()
                                Return False
                            End If
                        Else
                            tranWO.Rollback()
                            Return False
                        End If
                    End If
                Else ' en este caso se debe insertar un nuevo PO un WO y el nuevo TASk
                    Dim cmdInsertNewPO As New SqlCommand("insert into projectOrder values (" + projectN.idPO + "," + CStr(projectN.jobNum) + ")", conn)
                    Dim newWO = System.Guid.NewGuid.ToString()
                    Dim cmdInsertNewWO As New SqlCommand("insert into workOrder values('" + newWO + "','" + projectN.idWorkOrder + "'," + CStr(projectN.idPO) + ")", conn)
                    Dim cmdInsertTask2 As New SqlCommand("insert into task 
                        values (NEWID(),'" + CStr(projectN.idTask) + "','" + newWO + "',0.0,'" + projectN.equipament + "','" + projectN.manager + "'
                        ,'" + projectN.description + "'," + CStr(projectN.totalBilling) + ",'" + validaFechaParaSQl(projectN.beginDate) + "','" + validaFechaParaSQl(projectN.endDate) + "'
                        ,'" + projectN.expCode + "','" + projectN.accountNum + "'," + CStr(projectN.estimateHour) + ",'" + CStr(projectN.status) + "'," + CStr(projectN.PercentComplete) + ")", conn)
                    Dim tranPO As SqlTransaction
                    tranPO = conn.BeginTransaction
                    cmdInsertNewPO.Transaction = tranPO
                    cmdInsertNewWO.Transaction = tranPO
                    cmdInsertTask2.Transaction = tranPO
                    Try
                        If cmdInsertNewPO.ExecuteNonQuery > 0 Then
                            If cmdInsertNewWO.ExecuteNonQuery > 0 Then
                                If cmdInsertTask2.ExecuteNonQuery > 0 Then
                                    tranPO.Commit()
                                    Return True
                                Else
                                    tranPO.Rollback()
                                    Return False
                                End If
                            Else
                                tranPO.Rollback()
                                Return False
                            End If
                        Else
                            tranPO.Rollback()
                            Return False
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message())
                        tranPO.Rollback()
                        desconectar()
                        Return False
                    End Try
                End If
            Else
                MessageBox.Show("Actually the PO " + projectN.jobNum.ToString() + " is not inserted.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function


    '########################################################################################################################

    Public Sub buscarHorasPorProjecto(ByVal tblHoras As DataGridView, ByVal idWO As String, ByVal idTask As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select
CONCAT (em.firstName , ' ',em.middleName,' ',em.lastName) as Employee,
wc.name as Work,
wc.billingRate1 as 'Billing Rate', 
hw.hoursST as 'Billable Rate',
wc.billingRateOT as 'Billing RateOT',
hw.hoursOT as 'Billable OT',
wc.billingRate3 as 'Billing Rate 3',
hw.hours3 as 'Billable 3',
convert (varchar,hw.dateWorked,101 )as 'Date Worked',
wc.description as 'Description'
from 
employees em inner join hoursWorked as hw on em.idEmployee = hw.idEmployee
inner join task  as tk on tk.idAux = hw.idAux
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
where  tk.task = '" + idTask + "' and tk.idAuxWO = '" + idWO + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblHoras.DataSource = dt
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Sub buscarExpencesPorProyecto(ByVal tblExpences As DataGridView, ByVal idWO As String, ByVal idTask As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select
expu.idExpenseUsed,
CONVERT (varchar,expu.dateExpense,101) as 'Date',
ex.expenseCode as 'Expense Code',
expu.amount as 'Amount',
expu.description as 'Description'
from
task as tk inner join expensesUsed as expu on tk.idAux = expu.idAux
inner join expenses as ex on expu.idExpense = ex.idExpenses
where tk.task = '" + idTask + "' and tk.idAuxWO = '" + idWO + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblExpences.DataSource = dt
                tblExpences.Columns("idExpenseUsed").Visible = False
                desconectar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            desconectar()
        End Try
    End Sub

    Public Function llenarComboCellExpCode(ByVal cmbExpCode As DataGridViewComboBoxCell, ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idExpenses , expenseCode from expenses", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            tabla.Clear()
            Dim cont = 0
            Dim column As DataColumn
            If tabla.Columns.Count = 0 Then
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "id"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "expenseCode"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
            End If
            While reader.Read()
                Dim row As DataRow
                row = tabla.NewRow()
                row("id") = reader("idExpenses")
                row("expenseCode") = reader("expenseCode")
                tabla.Rows.Add(Row)
                cmbExpCode.Items.Add(reader("expenseCode"))
            End While
            desconectar()
            If tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function

    Public Function llenarTablaMaterialsIds(ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idMaterial,CONCAT(number,' ' ,name) as name from material", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            tabla.Clear()
            Dim column As DataColumn
            If tabla.Columns.Count = 0 Then
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "id"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Material"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
            End If
            While reader.Read()
                Dim row As DataRow
                row = tabla.NewRow()
                row("id") = reader("idMaterial")
                row("Material") = reader("name")
                tabla.Rows.Add(row)
            End While
            desconectar()
            If tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function
    Public Function llenarComboCellMaterial(ByVal cmbMaterial As DataGridViewComboBoxCell, ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idMaterial,CONCAT(number,' ' ,name) as name from material", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            tabla.Clear()
            Dim cont = 0
            Dim column As DataColumn
            If tabla.Columns.Count = 0 Then
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "id"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Material"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
            End If
            While reader.Read()
                Dim row As DataRow
                row = tabla.NewRow()
                row("id") = reader("idMaterial")
                row("Material") = reader("name")
                tabla.Rows.Add(row)
                cmbMaterial.Items.Add(reader("name"))
            End While
            desconectar()
            If tabla.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            desconectar()
            Return False
        End Try
    End Function
    Public Sub buscarMaterialesPorProyecto(ByVal tblMateriales As DataGridView, ByVal idWO As String, ByVal idTask As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select 
mu.idMaterialUsed,
convert (varchar,mu.dateMaterial, 101) as 'Date',
concat(wo.idWO,' ',tk.task)as 'Work Order',
mu.amount as 'Amount',
concat(mt.number,' ', mt.name) as 'Material Code',
mu.description as 'Description'
from 
materialUsed as mu inner join task as tk on tk.idAux = mu.idAux
inner join material as mt on mu.idMaterial = mt.idMaterial
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
where tk.task = '" + idTask + "' and tk.idAuxWO = '" + idWO + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblMateriales.DataSource = dt
                tblMateriales.Columns("idMaterialUsed").Visible = False
                desconectar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            desconectar()
        End Try
    End Sub

    Public Sub llenarComboJob(ByVal cmbJob As ComboBox, ByVal idclient As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from job as jb inner join clients as cl on jb.idClient = cl.idClient 
where cl.idClient like '" + If(idclient = "", "%", idclient) + "'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbJob.Items.Add(reader(0))
            End While
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Sub consultaWO(ByVal jobNumber As String, ByVal tabla As DataTable)
        Try
            conectar()
            Dim cmd1 As New SqlCommand("select 
jb.jobNo,
po.idPO,
wo.idWO, 
tk.task,
tk.idAux,
wo.idAuxWO
from job as jb 
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO 
inner join task as tk on tk.idAuxWO = wo.idAuxWO
where jb.jobNo " + If(jobNumber = "", "> 0", "=" + jobNumber), conn)
            If cmd1.ExecuteNonQuery Then
                tabla.Clear()
                Dim da As New SqlDataAdapter(cmd1)
                da.Fill(tabla)
                desconectar()
            Else
                desconectar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Function deleteMaterial(ByVal idMaterialUsed As String, ByVal itask As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from materialUsed where idMaterialUsed = '" + idMaterialUsed + "'", conn)
            If cmd.ExecuteNonQuery > 1 Then
                UpdateTotalSpendTask(itask)
                desconectar()
                Return True
            Else
                desconectar()
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            desconectar()
            Return False
        End Try
    End Function

    '================================================================================================================================================
    '===============================  METODOS PARA ACTUALIZAR INMEDITATAMENTE AL PERDER EL FOCO =====================================================
    '================================================================================================================================================
    Public Function actualizarCostDistribution(ByVal costDistribution As String, ByVal jobNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update job set costDistribution = '" + costDistribution + "' where jobNo = " + jobNumber, conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarWorkTMLumpSum(ByVal workTMLumSum As String, ByVal jobNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update job set workTMLumSum= '" + workTMLumSum + "' where jobNo = " + jobNumber, conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarCustumerNo(ByVal CustumerNo As String, ByVal jobNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update job set custumerNo= " + CustumerNo + " where jobNo = " + jobNumber, conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarContractNo(ByVal contractNo As String, ByVal jobNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update job set contractNo = '" + contractNo + "' where jobNo = " + jobNumber, conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarCostCode(ByVal costCode As String, ByVal jobNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update job set costCode = '" + costCode + "' where jobNo = " + jobNumber, conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function


    '================================================================================================================================================
    '===============================  METODOS PARA COSTOS POR PROJECTOS =============================================================================
    '================================================================================================================================================

    Public Function cargarDatosProjectOrder(ByVal idJob As String) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select 
CONCAT (cl.firstName,' ',cl.middleName,' ',cl.lastName) as 'Name',
wo.idWO,
tk.task,
tk.equipament,
tk.manager,
po.idPO,
tk.description,
tk.estTotalBilling,
tk.beginDate,
tk.endDate,
tk.estimateHours,
tk.expCode,
tk.accountNum,
tk.status,
tk.idAux,
tk.idAuxWO,
tk.percentComplete
from 
job as jb 
inner join clients as cl on jb.idClient = cl.idClient
inner join projectOrder as po on jb.jobNo = po.jobNo 
inner join workOrder as wo on po.idPO = wo.idPO
left join task as tk on tk.idAuxWO = wo.idAuxWO 
where jb.jobNo = " + If(idJob = "", "0", idJob).ToString(), conn)
            Dim lstDatosPO As New List(Of String)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lstDatosPO.Add(reader("Name"))
                lstDatosPO.Add(reader("idWo"))
                lstDatosPO.Add(reader("task"))
                lstDatosPO.Add(reader("equipament"))
                lstDatosPO.Add(reader("manager"))
                lstDatosPO.Add(reader("idPO"))
                lstDatosPO.Add(reader("description"))
                lstDatosPO.Add(reader("estTotalBilling"))
                lstDatosPO.Add(reader("beginDate"))
                lstDatosPO.Add(reader("endDate"))
                lstDatosPO.Add(reader("estimateHours"))
                lstDatosPO.Add(reader("expCode"))
                lstDatosPO.Add(reader("accountNum"))
                lstDatosPO.Add(reader("status"))
                lstDatosPO.Add(reader("idAux"))
                lstDatosPO.Add(reader("idAuxWO"))
                lstDatosPO.Add(reader("percentComplete"))
                Exit While
            End While
            desconectar()
            Return lstDatosPO
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        End Try
    End Function

    Public Function cargarDatosProjectOrder(ByVal idJob As String, ByVal task As String, ByVal idAuxWO As String) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select 
CONCAT (cl.firstName,' ',cl.middleName,' ',cl.lastName) as 'Name',
wo.idWO,
tk.task,
tk.equipament,
tk.manager,
po.idPO,
tk.description,
tk.estTotalBilling,
tk.beginDate,
tk.endDate,
tk.estimateHours,
tk.expCode,
tk.accountNum,
tk.status,
tk.idAux,
tk.idAuxWO,
tk.percentComplete
from 
job as jb 
inner join clients as cl on jb.idClient = cl.idClient
inner join projectOrder as po on jb.jobNo = po.jobNo 
inner join workOrder as wo on po.idPO = wo.idPO
left join task as tk on tk.idAuxWO = wo.idAuxWO
where jb.jobNo = " + If(idJob = "", "0", idJob).ToString() + " and tk.task = '" + task + "' and wo.idAuxWO ='" + idAuxWO + "'", conn)
            Dim lstDatosPO As New List(Of String)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lstDatosPO.Add(reader("Name"))
                lstDatosPO.Add(reader("idWo"))
                lstDatosPO.Add(reader("task"))
                lstDatosPO.Add(reader("equipament"))
                lstDatosPO.Add(reader("manager"))
                lstDatosPO.Add(reader("idPO"))
                lstDatosPO.Add(reader("description"))
                lstDatosPO.Add(reader("estTotalBilling"))
                lstDatosPO.Add(reader("beginDate"))
                lstDatosPO.Add(reader("endDate"))
                lstDatosPO.Add(reader("estimateHours"))
                lstDatosPO.Add(reader("expCode"))
                lstDatosPO.Add(reader("accountNum"))
                lstDatosPO.Add(reader("status"))
                lstDatosPO.Add(reader("idAux"))
                lstDatosPO.Add(reader("idAuxWO"))
                lstDatosPO.Add(reader("percentComplete"))
                Exit While
            End While
            desconectar()
            Return lstDatosPO
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        End Try
    End Function

    Public Function existPO(ByVal idPO As String, ByVal jobNo As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select COUNT(idPO) as 'idPO' from projectOrder where idPO = " + idPO + " and jobNo = " + jobNo, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim count As String = "0"
            While reader.Read()
                count = reader("idPO")
                Exit While
            End While
            If CInt(count) >= 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Public Function updatePO(ByVal idPON As String, ByVal idPOV As String, ByVal idJobNum As String) As Boolean
        Try
            conectar()
            Dim cmd1 As New SqlCommand("
if (select COUNT(idPO) from projectOrder where idPO = " + idPOV + " and jobNo = " + idJobNum + ") = 1 
		and (select COUNT(idPO) from projectOrder where idPO = " + idPON + " and jobNo = " + idJobNum + ") = 0   
begin 
   	update po set  po.idPO = " + idPON + " from projectOrder as po 
	inner join job as jb on po.jobNo = jb.jobNo 
	inner join workOrder as wo on wo.idPO = po.idPO
	where po.idPO = " + idPOV + " and po.jobNo =  " + idJobNum + " 
end  ", conn)
            ' Dim cmd2 As New SqlCommand("update wo set wo.idPO = " + idPON + " from workOrder as wo inner join projectOrder as po on wo.idPO = po.idPO where po.jobNo = " + idJobNum + " and po.idPO = " + idPON, conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            'cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery = 1 Then
                'If cmd2.ExecuteNonQuery > 0 Then
                tran.Commit()
                desconectar()
                Return True
                'Else
                '    tran.Rollback()
                '    Return False
                'End If
            Else
                tran.Rollback()
                desconectar()
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Public Function updateEquipaMent(ByVal equipamentN As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
update task set equipament = '" + equipamentN + "' 
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateManeger(ByVal managerN As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set manager = '" + managerN + "' 
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateDescription(ByRef description As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set description = '" + description + "' 
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateTotalBilling(ByVal totalBillingN As Double, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
update task set estTotalBilling = " + CStr(totalBillingN) + "
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateHoursEstimate(ByVal HoursN As Double, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set estimateHours = " + CStr(HoursN) + "
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateBeginDate(ByVal beginDateN As Date, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set beginDate = '" + validaFechaParaSQl(beginDateN) + "'
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try

    End Function

    Public Function updateEndDate(ByVal EndDateN As Date, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set endDate = '" + validaFechaParaSQl(EndDateN) + "'
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
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

    Public Function updateAccont(ByRef accountN As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set accountNum = '" + accountN + "'
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateComplete(ByVal status As Boolean, ByVal idAux As String, ByVal WO As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set status = '" + status + "'
select * from task as tk 
inner join workOrder as wo on wo.idWO = tk.idWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idWO = " + WO, conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateCompleteProgress(ByVal percent As Double, ByVal idAux As String, ByVal WO As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set percentComplete  = " + percent.ToString() + "
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function updateWorkOrder(ByVal workOrderN As String, ByVal workOrderV As String, ByVal idPO As String, ByVal jobNO As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update workOrder set idWO = " + workOrderN + "  
from projectOrder as po 
inner join workOrder as wo on wo.idPO = po.idPO
inner join job as jb on jb.jobNo = po.jobNo
where  po.idPO = " + idPO + " and wo.idAuxWO = '" + workOrderV + "' and jb.jobNo = " + jobNO, conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function updateExxpCode(ByVal expCodeN As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set expCode = '" + expCodeN + "'
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function updateTask(ByVal taskN As String, ByVal idAux As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set  task = '" + taskN + "' where idAux = '" + idAux + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function soloCodigoExpCode(ByVal codigo As String) As String
        Dim array() As String = codigo.Split(" ")
        Return array(0)
    End Function

    Public Function updateOrInsertNewMaterialUsed(ByVal datos As List(Of String), ByVal idMaterial As String) As Boolean
        Try
            If idMaterial = "" Then
                conectar()
                Dim cmd As New SqlCommand("insert into materialUsed values(NEWID(),'" + datos(0) + "',1," + datos(1) + ",'" + datos(4) + "','task','idMaterial')", conn)
                If cmd.ExecuteNonQuery > 0 Then
                    UpdateTotalSpendTask(datos(5))
                    Return True
                Else
                    Return False
                End If
            Else
                conectar()
                Dim cmd As New SqlCommand("", conn)
                If cmd.ExecuteNonQuery Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function insertMaterialUsed(ByVal datos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
                insert into materialUsed values(NEWID(),'" + datos(1) + "',1," + datos(3) + ",'" + datos(5) + "','" + datos(2) + "','" + datos(4) + "')", conn)
            If cmd.ExecuteNonQuery = 1 Then
                UpdateTotalSpendTask(datos(5))
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

    Public Function updateMaterialUsed(ByVal datos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
                update materialUsed set dateMaterial = '" + datos(1) + "' , amount = " + datos(3) + " ,description = '" + datos(5) + "' , idAux = '" + datos(2) + If(datos(4).Length = 36, "',idMaterial = '" + datos(4), "") + "' where idMaterialUsed = '" + datos(0) + "'", conn)
            If cmd.ExecuteNonQuery = 1 Then
                UpdateTotalSpendTask(datos(5))
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

    Public Function insertExpensesUsed(ByVal datos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into expensesUsed values (NEWID(),'" + datos(1) + "'," + datos(3) + ",'" + datos(4) + "','" + datos(2) + "','" + datos(5) + "')", conn)
            If cmd.ExecuteNonQuery = 1 Then
                UpdateTotalSpendTask(datos(5))
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
            update expensesUsed set dateExpense = '" + datos(1) + "' , amount= " + datos(3) + " , description = '" + datos(4) + "' , idExpense = '" + datos(2) + "' , idAux= '" + datos(5) + "' where idExpenseUsed = '" + datos(0) + "' ", conn)
            If cmd.ExecuteNonQuery = 1 Then
                UpdateTotalSpendTask(datos(5))
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

    Public Function UpdateTotalSpendTask(ByVal idTask As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("exec sp_UpdateTotalSpendTask '" + idTask + "'", conn)
            If cmd.ExecuteNonQuery Then
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

    '============================================================================================
    '================ METODOS PARA INSERTAR WO Y PO DESDE EXCEL =================================
    '============================================================================================

    Public Function verificarWOYPO(ByVal idWO As String, ByVal PO As String, ByVal task As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select count(*) from projectOrder as po 
inner join workOrder as wo on po.idPO = wo.idPO
inner join task as tk on tk.idAuxWO = wo.idAuxWO
where wo.idWO = " + idWO + " and po.idPO = " + PO + " and tk.task=" + task, conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim count As Integer = 0
            While dr.Read()
                count = dr("idPO")
                Exit While
            End While
            If count >= 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
