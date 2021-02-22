Imports System.Data.SqlClient

Public Class MetodosJobs
    Inherits ConnectioDB
    'metodos work code y type work code
    'Public Sub selectWC(ByVal cmbTWC As ComboBox, ByVal listIDS As List(Of String))
    '    conectar()
    '    Try
    '        Dim cmd As New SqlCommand("select clasification , idTWorkCode from typeWorkCode", conn)
    '        Dim rd As SqlDataReader
    '        rd = cmd.ExecuteReader()
    '        While rd.Read()
    '            cmbTWC.Items.Add(rd("clasification"))
    '            listIDS.Add(rd("idTWorkCode"))
    '        End While
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    desconectar()
    'End Sub

    '########################################################################################################################
    '############  METODOS PARA WORKCODE ####################################################################################
    '########################################################################################################################


    Public Sub selectWC(ByVal tabla As DataGridView)
        conectar()
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "select idWorkCode as ID , name Name , description as Description, billingRate1 as BillingRT1, billingRateOT as BillingOT, billingRate3 as BillingRT3 , EQExq1,EQExq2 from workCode  "
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
            Dim cmd As New SqlCommand("update workCode set name='" + datos(1) + "',description ='" + datos(2) + "', billingRate1=" + datos(3) + ", billingRateOT=" + datos(4) + ",EQExq1='" + datos(6) + "',EQExq2='" + datos(7) + "' where idWorkCode =  " + datos(0), conn)
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
            Dim cmd As New SqlCommand("update expenses set expenseCode = '" + code + "' , description = '" + description + "' where idExpences = '" + id + "'", conn)
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
            Dim cmdIdPOMax As New SqlCommand("select MAX(idPO)+1 as idPOMax from projectOrder", conn)
            Dim idPOMax As String = ""
            Dim reader As SqlDataReader = cmdIdPOMax.ExecuteReader()
            While reader.Read()
                idPOMax = reader("idPOMax")
                If idPOMax <> "" Or idPOMax <> "Null" Then
                    Exit While
                Else
                    idPOMax = "60000000"
                End If
            End While
            reader.Close()
            Dim cmdJob As New SqlCommand("insert into job values (" + datosPO(0) + ",'" + datosPO(1) + "', '" + datosPO(2) + "'," + datosPO(3) + ", " + datosPO(4) + "," + datosPO(5) + ",'" + idClient + "')", conn)
            Dim cmdProyect As New SqlCommand("insert into projectOrder values (" + idPOMax + ",'','','',0.0,GETDATE(),DATEADD(MM,1,GETDATE()),'',0,0,'0'," + datosPO(0) + ")", conn)
            Dim cmdWO As New SqlCommand("insert into workOrder values (convert(varchar(14),(select MAX(cast(idWO as int))+ 1 from workOrder)),'" + idPOMax + "')", conn)
            Dim cmdTask As New SqlCommand("insert into task values ('',(select MAX(cast(idWO as int)) from workOrder),0.0)", conn)
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

    '########################################################################################################################

    Public Sub buscarHorasPorProjecto(ByVal tblHoras As DataGridView, ByVal idWO As String, ByVal idTask As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select
CONCAT (em.firstName , ' ',em.middleName,' ',em.lastName) as Employee,
wc.name as Work,
wc.billingRate1 as 'Billing Rate', 
hw.hoursST as 'Billable Rate',
wc.billingRateOT as 'Billable OT',
hw.hoursOT as 'Billing RateOT',
hw.dateWorked as 'Date Worked',
wc.description as 'Description'
from 
employees em inner join hoursWorked as hw on em.idEmployee = hw.idEmployee
inner join task  as tk on tk.idTask = hw.idTask
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
where  tk.idTask = '" + idTask + "' and tk.idWO = '" + idWO + "'", conn)
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
select * from expenses
select * from expensesUsed
select
expu.dateExpense as 'Date',
ex.expenseCode as 'Expense Code',
expu.amount as 'Amount',
expu.description as 'Description'
from
task as tk inner join expensesUsed as expu on tk.idTask = expu.idTask
inner join expenses as ex on expu.idExpense = ex.idExpenses
where tk.idTask = '" + idTask + "' and tk.idWO = '" + idWO + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblExpences.DataSource = dt
                desconectar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            desconectar()
        End Try
    End Sub

    Public Sub buscarMaterialesPorProyecto(ByVal tblMateriales As DataGridView, ByVal idWO As String, ByVal idTask As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select 
mu.dateMaterial,
concat(tk.idWO,' ',tk.idTask)as 'Work Order',
mu.amount,
mu.descripcion
from 
materialUsed as mu inner join task as tk on tk.idTask = mu.idTask
inner join material as mt on mu.idMaterial = mt.idMaterial
where tk.idTask = '" + idTask + "' and tk.idWO = '" + idWO + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblMateriales.DataSource = dt
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
tk.idWO, 
tk.idTask
from job as jb 
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO 
inner join task as tk on tk.idWO = wo.idWO
where jb.jobNo = " + If(jobNumber = "", "0", jobNumber), conn)
            If cmd1.ExecuteNonQuery Then
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
tk.idWO,
tk.idTask,
po.equipament,
po.manager,
po.idPO,
po.description,
po.estTotalBilling,
po.beginDate,
po.endDate,
po.estimateHours,
po.expCode,
po.accountNum,
po.status
from 
job as jb 
inner join clients as cl on jb.idClient = cl.idClient
inner join projectOrder as po on jb.jobNo = po.jobNo 
left join workOrder as wo on po.idPO = wo.idPO
left join task as tk on tk.idWO = wo.idWO
where jb.jobNo = " + If(idJob = "", "0", idJob).ToString(), conn)
            Dim lstDatosPO As New List(Of String)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lstDatosPO.Add(reader("Name"))
                lstDatosPO.Add(reader("idWo"))
                lstDatosPO.Add(reader("idTask"))
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
                Exit While
            End While
            desconectar()
            Return lstDatosPO
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        End Try
    End Function

    Public Function updatePO(ByVal idPON As String, ByVal idPOV As String) As Boolean
        Try
            conectar()
            Dim cmd1 As New SqlCommand("if (select COUNT(idPO) from projectOrder where idPO = " + idPOV + ") > 0 
	                                   begin 
		                                    update projectOrder set idPO = 	" + idPON + " where idPO-" + idPOV +
                                       "end ", conn)
            Dim cmd2 As New SqlCommand("update workOrder set idPO = " + idPON + " where idPO = " + idPOV, conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            If cmd1.ExecuteNonQuery = 1 Then
                If cmd2.ExecuteNonQuery > 0 Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function



End Class
