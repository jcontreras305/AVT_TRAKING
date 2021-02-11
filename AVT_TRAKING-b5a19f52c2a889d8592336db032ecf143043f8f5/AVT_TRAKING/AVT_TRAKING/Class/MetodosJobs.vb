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

    Public Sub insertarNuevoProyecto(ByVal idClient As String, ByVal datosPO As List(Of String))
        Try
            conectar()
            Dim cmdJob As New SqlCommand("insert into job values (" + datosPO(0) + ",'" + datosPO(1) + "', '" + datosPO(2) + "'," + datosPO(3) + ", " + datosPO(4) + "," + datosPO(5) + ",'" + idClient + "')", conn)
            Dim cmdProyect As New SqlCommand("insert into projectOrder values ((select MAX(idPO)+1 from projectOrder),'','','',0.0,GETDATE(),DATEADD(MM,1,GETDATE()),'',0,0,'0'," + datosPO(0) + ")", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmdJob.Transaction = tran
            cmdProyect.Transaction = tran
            If cmdJob.ExecuteNonQuery Then
                If cmdProyect.ExecuteNonQuery Then
                    MsgBox("Succesfull")
                    tran.Commit()
                Else
                    tran.Rollback()
                    MsgBox("Error")
                End If
            Else
                tran.Rollback()
                MsgBox("Error")
            End If
            desconectar()
        Catch ex As Exception
            desconectar()

            MsgBox(ex.Message())
        End Try
    End Sub

    '########################################################################################################################


    Public Sub buscarHorasPorProjecto(ByVal tblHoras As DataGridView, ByVal idWO As String)
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
inner join workOrder as wo on wo.idWo = hw.idWO
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
where wo.idWo = '" + idWO + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblHoras.DataSource = dt
                desconectar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            desconectar()
        End Try
    End Sub

    Public Sub buscarExpencesPorProyecto(ByVal tblExpences As DataGridView, ByVal idWO As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select
expu.dateExpense as 'Date',
concat(emp.firstName,' ',emp.middleName,' ',emp.lastName) 'Employee',
ex.expenseCode as 'Expense Code',
expu.amount as 'Amount',
expu.description as 'Description'
from
workOrder as wo inner join expensesUsed as expu on wo.idWo = expu.idWorkOrder
inner join expenses as ex on expu.idExpense = ex.idExpenses
left join employees as emp on emp.idEmployee = expu.idEmployee
where wo.idWo ='" + idWO + "'", conn)
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

    Public Sub buscarMaterialesPorProyecto(ByVal tblMateriales As DataGridView, ByVal idWO As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
mu.dateMaterial,
wo.idWo,
mu.amount,
mu.descripcion
from 
materialUsed as mu inner join workOrder as wo on wo.idWo = mu.idWO
inner join material as mt on mu.idMaterial = mt.idMaterial
where wo.idWo = '" + idWO + "'", conn)
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
where cl.idClient = '" + idclient + "'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbJob.Items.Add(reader(0))
            End While
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub



End Class
