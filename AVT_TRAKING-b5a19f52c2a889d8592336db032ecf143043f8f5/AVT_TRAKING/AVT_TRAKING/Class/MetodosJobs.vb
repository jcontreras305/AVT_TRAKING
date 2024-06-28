Imports System.Data.SqlClient
Public Class MetodosJobs
    Inherits ConnectioDB

    '########################################################################################################################
    '############  METODOS PARA WORKCODE ####################################################################################
    '########################################################################################################################


    Public Sub selectWC(ByVal tabla As DataGridView, Optional ByVal jobNo As String = "")
        conectar()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = "select idWorkCode as ID , jobNo as 'JobNo' , name as Name , description as Description, billingRate1 as BillingRT1, billingRateOT as BillingOT, billingRate3 as BillingRT3 , EQExp1, EQExp2, Category, PayItemType as 'Pay Item Type', WorkType as 'Work Type', CostCode as 'Cost Code', CustomerPositionID as 'Customer Position ID', CustomerJobPositionDescription as 'Customer Job Position Description', CBSFullNumber as 'CBS Full Number',skillType as 'Skill Type' from workCode " + If(jobNo = "", "", " where jobNo = " & jobNo & "")
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

    Public Function nuevaWC(datos() As String, Optional showMessage As Boolean = True) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if not EXISTS (select idWorkCode from workCode where name = '" + datos(1) + "' and jobNo = " + datos(8) + ")
begin 
    insert into workCode values (" + datos(0) + "," + datos(8) + ",'" + datos(1) + "','" + datos(2) + "'," + datos(3) + "," + datos(4) + "," + datos(5) + ",'" + datos(6) + "','" + datos(7) + "','" + datos(9) + "','" + datos(10) + "','" + datos(11) + "','" + datos(12) + "','" + datos(13) + "','" + datos(14) + "','" + datos(15) + "','" + datos(16) + "')
end")
            cmd.Connection = conn
            If cmd.ExecuteNonQuery > 0 Then
                If showMessage Then
                    MsgBox("Succesfull")
                End If
                Return True
            Else
                MsgBox("Is probably that the Work Code " + datos(1) + " was inserted in this job.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Sub acualizarWC(datos() As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("if EXISTS (select idWorkCode from workCode where idWorkCode = " + datos(0) + " and jobNo = " + datos(8) + ")
begin 
    IF '" + datos(1) + "' = (select name from workCode where idWorkCode = " + datos(0) + " and jobNo = " + datos(8) + ")
    BEGIN 
        update workCode set description ='" + datos(2) + "', billingRate1=" + datos(3) + ", billingRateOT=" + datos(4) + ", billingRate3= " + datos(5) + ",EQExp1='" + datos(6) + "',EQExp2='" + datos(7) + "' , Category= '" + datos(9) + "',PayItemType = '" + datos(10) + "',WorkType= '" + datos(11) + "',CostCode= '" + datos(12) + "',CustomerPositionID= '" + datos(13) + "',CustomerJobPositionDescription= '" + datos(14) + "',CBSFullNumber= '" + datos(15) + "',skillType= '" + datos(16) + "' where idWorkCode =  " + datos(0) + " and jobNo = " + datos(8) + "
    END
    ELSE IF not EXISTS (select name from workCode where name = '" + datos(1) + "' and jobno = " + datos(8) + ")
	begin
        update workCode set name='" + datos(1) + "',description ='" + datos(2) + "', billingRate1=" + datos(3) + ", billingRateOT=" + datos(4) + ", billingRate3= " + datos(5) + ",EQExp1='" + datos(6) + "',EQExp2='" + datos(7) + "' , Category= '" + datos(9) + "',PayItemType = '" + datos(10) + "',WorkType= '" + datos(11) + "',CostCode= '" + datos(12) + "',CustomerPositionID= '" + datos(13) + "',CustomerJobPositionDescription= '" + datos(14) + "',CBSFullNumber= '" + datos(15) + "', skillType= '" + datos(16) + "' where idWorkCode =  " + datos(0) + " and jobNo = " + datos(8) + "
    end
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Succesfull")
            Else
                MsgBox("Is not posible update the WorkCode, because " + datos(1) + " is inserted in this job.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            desconectar()
        End Try
    End Sub

    Public Sub buscarWC(ByVal dato As String, ByVal tabla As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("select idWorkCode as ID , jobNo as 'JobNo' , name as Name , description as Description, billingRate1 as BillingRT1, billingRateOT as BillingOT, billingRate3 as BillingRT3 , EQExp1, EQExp2, Category, PayItemType as 'Pay Item Type',WorkType as 'Work Type', CostCode as 'Cost Code', CustomerPositionID as 'Customer Position ID', CustomerJobPositionDescription as 'Customer Job Position Description', CBSFullNumber as 'CBS Full Number',skillType as 'Skill Type' from workCode where idWorkCode like '" + dato + "' or  name like '%" + dato + "%' or description like '%" + dato + "%' ", conn)
            'Dim cmd As New SqlCommand("select idWorkCode as ID , jobNo as 'JobNo' , name as Name , description as Description, billingRate1 as BillingRT1, billingRateOT as BillingOT, billingRate3 as BillingRT3 , EQExp1,EQExp2 from workCode where idWorkCode like '" + dato + "' or  name like '%" + dato + "%' or description like '%" + dato + "%' ", conn)
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

    Public Function insertWorkCodeTable(ByVal tbl As DataTable, ByVal jobNO As String) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataRow In tbl.Rows
                'If row.ItemArray(8) = "" And assignJob = False Then
                '    Dim result As DialogResult = MessageBox.Show("You did not assign a job in the work code " + vbCrLf + "'" + row.ItemArray(1) + "'" + vbCrLf + "Would you like to use the job selected in the list?" + vbCrLf + "This job will be assigned for if another blanck appears.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                '    If result = DialogResult.OK Then
                '        assignJob = True
                '    Else
                '        flag = False
                '        Exit For
                '    End If
                'End If
                Dim cmd As New SqlCommand("If EXISTS (select idWorkCode from workCode where idWorkCode = '" + row.ItemArray(0) + "' and jobNo = " + If(jobNO = "", row.ItemArray(8), jobNO) + ")
                begin 
                    update workCode set  [name] = '" + row.ItemArray(1) + "' , [description] = '" + row.ItemArray(2) + "' ,[billingRate1]=" + row.ItemArray(3) + ",[billingRateOT]=" + row.ItemArray(4) + ",[billingRate3]=" + row.ItemArray(5) + ",[EQExp1]='" + row.ItemArray(6) + "',[EQExp2]='" + row.ItemArray(7) + "',[Category]='" + row.ItemArray(9) + "',[PayItemType] ='" + row.ItemArray(10) + "',[WorkType]='" + row.ItemArray(11) + "',[CostCode]='" + row.ItemArray(12) + "',[CustomerPositionID]='" + row.ItemArray(13) + "',[CustomerJobPositionDescription]='" + row.ItemArray(14) + "',[CBSFullNumber]='" + row.ItemArray(15) + "' ,[skillType]='" + row.ItemArray(16) + "'
	                where [idWorkCode] = '" + row.ItemArray(0) + "' and [jobNo] = " + If(jobNO = "", row.ItemArray(8), jobNO) + " 
                end
                else
                begin
                    insert into workCode values (" + row.ItemArray(0) + "," + If(jobNO = "", row.ItemArray(8), jobNO) + ",'" + row.ItemArray(1) + "','" + row.ItemArray(2) + "'," + row.ItemArray(3) + "," + row.ItemArray(4) + "," + row.ItemArray(5) + ",'" + row.ItemArray(6) + "','" + row.ItemArray(7) + "','" + If(row.ItemArray(9) = "", "0", row.ItemArray(9)) + "','" + If(row.ItemArray(10) = "", "0", row.ItemArray(10)) + "','" + If(row.ItemArray(11) = "", "0", row.ItemArray(11)) + "','" + If(row.ItemArray(12) = "", "0", row.ItemArray(12)) + "','" + If(row.ItemArray(13) = "", "0", row.ItemArray(13)) + "','" + If(row.ItemArray(14) = "", "0", row.ItemArray(14)) + "','" + If(row.ItemArray(15) = "", "'0'", row.ItemArray(15)) + "', '" + If(row.ItemArray(16) = "", "0", row.ItemArray(16)) + "')
                end")
                cmd.Connection = conn
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery = 0 Then
                    If Not DialogResult.Yes = MessageBox.Show("Is probably that the work code " + row.ItemArray(1) + " was inserted in this JobNo," + vbCrLf + "Would you like to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Succesfull")
                Return True
            Else
                tran.Rollback()
                MessageBox.Show("The process could not be completed successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '########################################################################################################################
    '############  METODOS PARA EXPENCES ####################################################################################
    '########################################################################################################################

    Public Sub buscarExpenses(ByVal tabla As DataGridView, Optional filter As String = "")
        Try
            conectar()
            Dim cmd As New SqlCommand("Select idExpenses ,expenseCode As 'Expense' , description as 'Description' from expenses" + If(filter = "", "", " where expenseCode like '%" + filter + "%' or [description] like '%" + filter + "%'"), conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns(0).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            desconectar()
        End Try

    End Sub

    Public Sub insertExpence(ByVal code As String, ByVal description As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT(*) from expenses where expenseCode = '" + code + "')=0
begin 
insert into expenses values (NEWID(), '" + code + "','" + description + "')
end")
            cmd.Connection = conn
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error:It is posible that the Expense Code was inserted")
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
    '############  METODOS PARA EXPENCES JOBS ###############################################################################
    '########################################################################################################################
    Public Function llenarComboExpenses(ByVal combo As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select [idExpenses],[expenseCode],[description] from expenses", conn) '
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("expenseCode")))
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

    Public Function selectExpensesByClient(ByVal tbl As DataGridView, Optional clientNum As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
select cl.numberClient, jb.jobNo ,ex.[expenseCode] as  'Expense',expj.[Category],expj.[PayItemType] as 'Pay Item Type',expj.[WorkType] as 'Work Type',expj.[CostCode] as 'Cost Code',expj.[CustomerPositionID] as 'Customer Postion ID',expj.[CustomerJobPositionDescription] as 'Customer Job Position Description',expj.[CBSFullNumber] as 'CBS Full Number',expj.[skillType]  as 'Skill Type'from expensesJobs as expj inner join expenses as ex on expj.idExpenses = ex.idExpenses
inner join job as jb on expj.jobNo=  jb.jobNo
inner join clients as cl on cl.idClient = jb.idClient" + If(clientNum = "", "", " where cl.numberClient = " + clientNum), conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
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

    Public Function insertarExpenseJob(ByVal expCode As String, ByVal jobNo As String, ByVal datos() As String, Optional tran As SqlTransaction = Nothing, Optional connection As SqlConnection = Nothing)
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT(*) from expensesJobs where jobNo = " + jobNo + " and idExpenses = (select top 1 idExpenses from expenses where expenseCode = '" + expCode + "')) =0 
begin
	insert into expensesJobs values ((select top 1 idExpenses from expenses where expenseCode = '" + expCode + "')" + "," + jobNo + ",'" + datos(0) + "','" + datos(1) + "','" + datos(2) + "','" + datos(3) + "','" + datos(4) + "','" + datos(5) + "','" + datos(6) + "','" + datos(7) + "')
end")
            'cmd.Connection = conn
            If tran IsNot Nothing Then 'son varios 
                cmd.Connection = connection
                cmd.Transaction = tran
            Else
                cmd.Connection = conn
            End If
            If cmd.ExecuteNonQuery > 0 Then
                If tran Is Nothing Then 'solo es uno 
                    MsgBox("Succesfull")
                End If
                Return True
            Else
                MsgBox("Error:Is posible that the Expense Code was inserted with this Job No")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function updateExpenseJob(ByVal expCode As String, ByVal jobNo As String, ByVal datos() As String, Optional tran As SqlTransaction = Nothing, Optional connection As SqlConnection = Nothing)
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT(*) from expensesJobs where jobNo = " + jobNo + " and idExpenses = (select top 1 idExpenses from expenses where expenseCode = '" + expCode + "')) =1 
begin
		update expensesJobs set Category = '" + datos(0) + "',PayItemType='" + datos(1) + "',WorkType='" + datos(2) + "',CostCode='" + datos(3) + "',CustomerPositionID='" + datos(4) + "',CustomerJobPositionDescription='" + datos(5) + "',CBSFullNumber='" + datos(6) + "',skillType='" + datos(7) + "'
	 where jobNo = " + jobNo + " and idExpenses = (select top 1 idExpenses from expenses where expenseCode = '" + expCode + "')
end")
            cmd.Connection = conn
            If tran IsNot Nothing Then 'son varios 
                cmd.Connection = connection
                cmd.Transaction = tran
            Else
                cmd.Connection = conn
            End If
            If cmd.ExecuteNonQuery > 0 Then
                If tran Is Nothing Then 'solo es uno 
                    MsgBox("Succesfull")
                End If
                Return True
            Else
                MsgBox("Error:Is not posible to update the Expense.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteExpenseJob(ByVal expCode As String, ByVal jobNo As String, Optional tran As SqlTransaction = Nothing, Optional connection As SqlConnection = Nothing)
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT(*) from expensesJobs where jobNo = " + jobNo + " and idExpenses = (select top 1 idExpenses from expenses where expenseCode = '" + expCode + "')) =1 
begin
	delete from expensesJobs where jobNo = " + jobNo + " and idExpenses = (select top 1 idExpenses from expenses where expenseCode = '" + expCode + "')
end")

            If tran IsNot Nothing Then 'son varios 
                cmd.Connection = connection
                cmd.Transaction = tran
            Else
                cmd.Connection = conn
            End If
            If cmd.ExecuteNonQuery > 0 Then
                If tran Is Nothing Then 'solo es uno 
                    MsgBox("Successful")
                End If

                Return True
            Else
                MsgBox("Error:Is not posible to delete the Expense.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    '########################################################################################################################
    '############  METODOS PARA PROYECTOS ###################################################################################
    '########################################################################################################################
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
when ISNUMERIC(Max(idWO)) = 0 then '5000'
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

            Dim cmdJob As New SqlCommand("insert into job values (" + datosPO(0) + ",'" + datosPO(1) + "', '" + datosPO(2) + "'," + If(datosPO(3) = "", "NULL", datosPO(3)) + ", " + If(datosPO(4) = "", "NULL", datosPO(4)) + "," + datosPO(5) + ",'" + idClient + "'," + datosPO(6) + "," + datosPO(7) + ")", conn)
            Dim cmdProyect As New SqlCommand("insert into projectOrder values (" + idPOMax + "," + datosPO(0) + ",0,'')", conn)
            Dim cmdWO As New SqlCommand("insert into workOrder values ('" + idAuxWO + "','" + idWOMax + "'," + idPOMax + ", " + datosPO(0) + " )", conn)
            Dim cmdTask As New SqlCommand("insert into task values (NEWID(),'','" + idAuxWO + "',0.0,'','','',0.0,GETDATE(),DATEADD(MM,1,GETDATE()),'','',0.0,'0',0,'')", conn)
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
            If flagJob > 0 Then ' validando que exista el jobNo de lo contrario no se podra  insertar lo demas 
                Dim cmdCosultaPO As New SqlCommand("select count(idPO) as 'cantidadPO' from projectOrder where jobNo = " + CStr(projectN.jobNum) + " and idPO = '" + projectN.idPO + "'", conn)
                Dim reader As SqlDataReader = cmdCosultaPO.ExecuteReader()
                Dim flagPO As String = ""
                While reader.Read()
                    flagPO = reader("cantidadPO")
                    Exit While
                End While
                reader.Close()
                Dim cmdCosultaWO As New SqlCommand("select count(idWO) as 'cantidadWO' from workOrder where idWO = '" + projectN.idWorkOrder + "' and idPO = '" + projectN.idPO + "' and jobNo = " + CStr(projectN.jobNum), conn)
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
                        values (NEWID(),'" + CStr(projectN.idTask) + "','" + projectN.idAuxWO + "',0.0,'" + projectN.equipament + "','" + projectN.manager + "'
                        ,'" + projectN.description.ToString.Replace("'", "''") + "'," + CStr(projectN.totalBilling) + ",'" + validaFechaParaSQl(projectN.beginDate) + "','" + validaFechaParaSQl(projectN.endDate) + "'
                        ,'" + projectN.expCode + "','" + projectN.accountNum + "'," + CStr(projectN.estimateHour) + ",'" + CStr(projectN.status) + "'," + CStr(projectN.PercentComplete) + ",'" + projectN.Area + "','" + projectN.Phase + "')", conn)
                            If cmdInsertTask1.ExecuteNonQuery = 1 Then
                                desconectar()
                                Return True
                            Else
                                desconectar()
                                Return False
                            End If
                        End If
                    Else
                        Dim newWO = System.Guid.NewGuid.ToString()
                        Dim cmdInsertNewWO As New SqlCommand("insert into workOrder values('" + newWO + "', '" + projectN.idWorkOrder + "'," + CStr(projectN.idPO) + ", " + CStr(projectN.jobNum) + ")", conn)
                        Dim cmdInsertTask2 As New SqlCommand("insert into task 
                        values (NEWID(),'" + CStr(projectN.idTask) + "','" + newWO + "',0.0,'" + projectN.equipament + "','" + projectN.manager + "'
                        ,'" + projectN.description.ToString.Replace("'", "''") + "'," + CStr(projectN.totalBilling) + ",'" + validaFechaParaSQl(projectN.beginDate) + "','" + validaFechaParaSQl(projectN.endDate) + "'
                        ,'" + projectN.expCode + "','" + projectN.accountNum + "'," + CStr(projectN.estimateHour) + ",'" + CStr(projectN.status) + "'," + CStr(projectN.PercentComplete) + ",'" + projectN.Area + "','" + projectN.Phase + "')", conn)
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
                Else ' en este caso se debe insertar un nuevo PO un WO y el nuevo TASK
                    Dim cmdInsertNewPO As New SqlCommand("insert into projectOrder values (" + projectN.idPO + "," + CStr(projectN.jobNum) + ",0,'')", conn)
                    Dim newWO = System.Guid.NewGuid.ToString()
                    Dim cmdInsertNewWO As New SqlCommand("insert into workOrder values('" + newWO + "','" + projectN.idWorkOrder + "'," + CStr(projectN.idPO) + ", " + CStr(projectN.jobNum) + ")", conn)
                    Dim cmdInsertTask2 As New SqlCommand("insert into task 
                        values (NEWID(),'" + CStr(projectN.idTask) + "','" + newWO + "',0.0,'" + projectN.equipament + "','" + projectN.manager + "'
                        ,'" + projectN.description.ToString.Replace("'", "''") + "'," + CStr(projectN.totalBilling) + ",'" + validaFechaParaSQl(projectN.beginDate) + "','" + validaFechaParaSQl(projectN.endDate) + "'
                        ,'" + projectN.expCode + "','" + projectN.accountNum + "'," + CStr(projectN.estimateHour) + ",'" + CStr(projectN.status) + "'," + CStr(projectN.PercentComplete) + ",'" + projectN.Area + "','" + projectN.Phase + "')", conn)
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
    Public Function deleteProject(ByVal idAux As String, ByVal idAuxWO As String, ByVal idPO As String, ByVal jobNo As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_delete_project", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idAux", idAux)
            cmd.Parameters.AddWithValue("@idAuxWO", idAuxWO)
            cmd.Parameters.AddWithValue("@idPO", idPO)
            cmd.Parameters.AddWithValue("@JobNo", jobNo)
            'cmd.Transaction = Trace
            If Not cmd.ExecuteNonQuery > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteProject(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows
                Dim cmd As New SqlCommand("sp_delete_project", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@idAux", row.Cells("idAux").Value)
                cmd.Parameters.AddWithValue("@idAuxWO", row.Cells("idAuxWO").Value)
                cmd.Parameters.AddWithValue("@idPO", row.Cells("IdPO").Value)
                cmd.Parameters.AddWithValue("@JobNo", row.Cells("jobNo").Value)
                cmd.Transaction = tran
                If Not cmd.ExecuteNonQuery > 0 Then
                    flag = False
                    Exit For
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
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
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
hw.hoursST as 'Billable Hrs. ST',
wc.billingRateOT as 'Billing RateOT',
hw.hoursOT as 'Billable Hrs. OT',
wc.billingRate3 as 'Billing Rate 3',
hw.hours3 as 'Billable Hrs. 3',
convert (varchar,hw.dateWorked,101 )as 'Date Worked',
wc.description as 'Description'
from hoursWorked as hw 
inner join employees as em on em.idEmployee = hw.idEmployee
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo= po.jobNo and jb.jobNo = wc.jobNo
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
            Dim cmd As New SqlCommand("select idMaterial,CONCAT(number,' ' ,name) as 'Material',code  as 'Class'from material", conn)
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
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Class"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
            End If
            While reader.Read()
                Dim row As DataRow
                row = tabla.NewRow()
                row("id") = reader("idMaterial")
                row("Material") = reader("Material")
                row("Class") = reader("Class")
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
    Public Function llenarComboCellMaterial(ByVal cmbMaterial As DataGridViewComboBoxCell, ByVal tabla As DataTable, Optional lastValue As String = "") As String
        Try
            conectar()
            Dim cmd As New SqlCommand("select idMaterial, number ,name , isnull(mt.code,'') as 'class'from material as mt 
left join materialClass as mc on mc.code = mt.code order by number", conn)
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
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Class"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
            End If
            Dim cmbValue As String = ""
            While reader.Read()
                Dim row As DataRow
                row = tabla.NewRow()
                row("id") = reader("idMaterial")
                row("Material") = CStr(reader("number")) + " " + reader("name")
                row("Class") = reader("class")
                tabla.Rows.Add(row)
                cmbMaterial.Items.Add(CStr(reader("number")) + " " + reader("name") + " " + reader("class"))
                If lastValue = CStr(reader("number")) Or lastValue = reader("name") Or lastValue = (CStr(reader("number")) + " " + reader("name")) Then
                    cmbValue = CStr(reader("number")) + " " + reader("name") + " " + reader("class")
                End If
            End While
            If tabla.Rows.Count > 0 Then
                Return cmbValue
            Else
                Return cmbValue
            End If
        Catch ex As Exception
            Return ""
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboCellMaterial(ByVal cmbMaterial As ComboBox) As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idMaterial, number ,name , isnull(mt.code,'') as 'class'from material as mt 
left join materialClass as mc on mc.code = mt.code", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim tabla As New Data.DataTable
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
                column.ColumnName = "Number"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Name"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
                column = New DataColumn()
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Class"
                column.AutoIncrement = False
                column.ReadOnly = False
                column.Unique = False
                tabla.Columns.Add(column)
            End If
            While reader.Read()
                Dim row As DataRow
                row = tabla.NewRow()
                row("id") = reader("idMaterial")
                row("Number") = CStr(reader("number"))
                row("Name") = reader("name")
                row("Class") = reader("class")
                tabla.Rows.Add(row)
                cmbMaterial.Items.Add(reader("class") + " " + reader("name"))
            End While
            reader.Close()
            If tabla.Rows.Count > 0 Then
                Return tabla
            Else
                Return tabla
            End If
        Catch ex As Exception
            desconectar()
            Return Nothing
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
mu.hoursST as 'Hours',
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

    Public Sub llenarComboClientPO(ByVal combo As ComboBox, ByVal idclient As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select po.idPO , jb.jobNo from projectOrder as po inner join job as jb on po.jobNo = jb.jobNo 
                where jb.idClient like '" + If(idclient = "", "%", idclient) + "'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While reader.Read()
                combo.Items.Add(reader(0))
            End While
            desconectar()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub llenarComboJob(ByVal cmbJob As ComboBox, ByVal idclient As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from job as jb inner join clients as cl on jb.idClient = cl.idClient 
where cl.idClient like '" + If(idclient = "", "%", idclient) + "'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            cmbJob.Items.Clear()
            While reader.Read()
                cmbJob.Items.Add(reader(0))
            End While
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Public Sub llenarComboJob(ByVal cmbJob As ComboBox, ByVal numClient As Integer)
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from job as jb inner join clients as cl on jb.idClient = cl.idClient 
where cl.numberClient =" + numClient.ToString() + "", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            cmbJob.Items.Clear()
            While reader.Read()
                cmbJob.Items.Add(reader(0))
            End While
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Public Sub consultaJobs(ByVal tabla As DataTable, Optional idClient As String = "")
        Try
            conectar()
            Dim cmd As New SqlCommand("select 
jb.jobNo,
jb.postingProject,
po.idPO,
wo.idWO, 
tk.task,
tk.idAux,
wo.idAuxWO,
po.line,
po.WBS,
jb.Taxes
from clients as cl inner join job as jb  on jb.idClient = cl.idClient
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.jobNo
inner join task as tk on tk.idAuxWO = wo.idAuxWO" + If(idClient <> "", "where cl.numberClient = " + idClient, ""), conn)
            If cmd.ExecuteNonQuery Then
                tabla.Clear()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                desconectar()
            Else
                desconectar()
            End If
        Catch ex As Exception

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
wo.idAuxWO,
po.line,
po.WBS,
jb.postingProject
from job as jb 
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.jobNo
inner join task as tk on tk.idAuxWO = wo.idAuxWO
where jb.jobNo " + If(jobNumber = "", "> 0", "=" + jobNumber) + " order by wo.idWO asc", conn)
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
    Public Sub consultaWOFind(ByVal consulta As String, ByVal tabla As DataTable, ByVal idClient As String)
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
inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.jobNo
inner join task as tk on tk.idAuxWO = wo.idAuxWO 
inner join clients as cl on cl.idClient = jb.idClient
" + consulta + If(idClient <> "", " and cl.IdClient = '" + idClient + "'", ""), conn)
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
    Public Function actualizarTaxes(ByVal taxes As String, ByVal jobNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update job set Taxes= " + taxes + " where jobNo = " + jobNumber, conn)
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
wo.idAuxWO,
tk.percentComplete,
po.Line,
po.WBS,
tk.Area,
jb.postingProject,
tk.phase,
jb.Taxes
from 
job as jb 
inner join clients as cl on jb.idClient = cl.idClient
inner join projectOrder as po on jb.jobNo = po.jobNo 
inner join workOrder as wo on po.idPO = wo.idPO and wo.jobNo = po.jobNo
left join task as tk on tk.idAuxWO = wo.idAuxWO 
where jb.jobNo = " + If(idJob = "", "0", idJob).ToString() + " order by wo.idWO asc", conn)
            Dim lstDatosPO As New List(Of String)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lstDatosPO.Add(reader("Name"))
                lstDatosPO.Add(If(reader("idWo") Is DBNull.Value, "", reader("idWo")))
                lstDatosPO.Add(If(reader("task") Is DBNull.Value, "", reader("task")))
                lstDatosPO.Add(If(reader("equipament") Is DBNull.Value, "", reader("equipament")))
                lstDatosPO.Add(If(reader("manager") Is DBNull.Value, "", reader("manager")))
                lstDatosPO.Add(If(reader("idPO") Is DBNull.Value, "", reader("idPO")))
                lstDatosPO.Add(If(reader("description") Is DBNull.Value, "", reader("description")))
                lstDatosPO.Add(If(reader("estTotalBilling") Is DBNull.Value, "0", reader("estTotalBilling")))
                lstDatosPO.Add(If(reader("beginDate") Is DBNull.Value, validarFechaParaVB(Date.Today.ToString()), reader("beginDate")))
                lstDatosPO.Add(If(reader("endDate") Is DBNull.Value, validarFechaParaVB(Date.Today.ToString()), reader("endDate")))
                lstDatosPO.Add(If(reader("estimateHours") Is DBNull.Value, "0", reader("estimateHours")))
                lstDatosPO.Add(If(reader("expCode") Is DBNull.Value, "", reader("expCode")))
                lstDatosPO.Add(If(reader("accountNum") Is DBNull.Value, "", reader("accountNum")))
                lstDatosPO.Add(If(reader("status") Is DBNull.Value, "0", reader("status")))
                lstDatosPO.Add(If(reader("idAux") Is DBNull.Value, "", reader("idAux")))
                lstDatosPO.Add(If(reader("idAuxWO") Is DBNull.Value, "", reader("idAuxWO")))
                lstDatosPO.Add(If(reader("percentComplete") Is DBNull.Value, 0, reader("percentComplete")))
                lstDatosPO.Add(If(reader("Line") Is DBNull.Value, "", reader("Line")))
                lstDatosPO.Add(If(reader("WBS") Is DBNull.Value, "", reader("WBS")))
                lstDatosPO.Add(If(reader("Area") Is DBNull.Value, "", reader("Area")))
                lstDatosPO.Add(If(reader("postingProject") Is DBNull.Value, "", reader("postingProject")))
                lstDatosPO.Add(If(reader("phase") Is DBNull.Value, "", reader("phase")))
                lstDatosPO.Add(If(reader("Taxes") Is DBNull.Value, "", reader("Taxes")))
                Exit While
            End While
            desconectar()
            Return lstDatosPO
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        End Try
    End Function

    Public Function cargarDatosProjectOrder(ByVal idJob As String, ByVal task As String, ByVal idAuxWO As String, Optional idPO As String = "") As List(Of String)
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
tk.percentComplete,
po.line,
po.WBS,
tk.Area,
jb.postingProject,
tk.phase,
jb.Taxes
from 
job as jb 
inner join clients as cl on jb.idClient = cl.idClient
inner join projectOrder as po on jb.jobNo = po.jobNo 
inner join workOrder as wo on po.idPO = wo.idPO and wo.jobNo = po.jobNo
left join task as tk on tk.idAuxWO = wo.idAuxWO
where jb.jobNo = " + If(idJob = "", "0", idJob).ToString() + " and tk.task = '" + task + "' and wo.idAuxWO ='" + idAuxWO + If(idPO = "", "", "' and po.idPO = " + idPO), conn)
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
                lstDatosPO.Add(reader("Line"))
                lstDatosPO.Add(reader("WBS"))
                lstDatosPO.Add(reader("Area"))
                lstDatosPO.Add(reader("postingProject"))
                lstDatosPO.Add(reader("phase"))
                lstDatosPO.Add(reader("Taxes"))
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

    Public Function updateArea(ByVal AreaN As String, ByVal AreaV As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            Dim cmd1 As New SqlCommand("
update task set Area = '" + AreaN + "' 
from task as tk 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO
inner join job as jb on jb.jobNo = po.jobNo 
where tk.idAux = '" + idAux + "' and wo.idAuxWO = '" + WO + "'", conn)
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            If cmd1.ExecuteNonQuery = 1 Then
                tran.Commit()
                desconectar()
                Return True
            Else
                tran.Rollback()
                desconectar()
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Dispose()
            Return False
        End Try
    End Function
    Public Function updateWBS(ByVal WBSN As String, ByVal WBSV As String, ByVal idJobNum As String, ByVal idPO As String) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            Dim cmd1 As New SqlCommand("
if (select COUNT(idPO) from projectOrder where idPO = " + idPO + " and jobNo = " + idJobNum + " and WBS = '" + WBSV + "') = 1 
		and (select COUNT(idPO) from projectOrder where idPO = " + idPO + " and jobNo = " + idJobNum + " and WBS ='" + WBSN + "') = 0   
begin 
   	update po set  po.WBS = '" + WBSN + "' from projectOrder as po 
	inner join job as jb on po.jobNo = jb.jobNo 
	inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = jb.jobNo
	where po.idPO = " + idPO + " and po.jobNo =  " + idJobNum + " and WBS = '" + WBSV + "' 
end  ", conn)
            ' Dim cmd2 As New SqlCommand("update wo set wo.idPO = " + idPON + " from workOrder as wo inner join projectOrder as po on wo.idPO = po.idPO where po.jobNo = " + idJobNum + " and po.idPO = " + idPON, conn)

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
            tran.Rollback()
            tran.Dispose()
            Return False
        End Try
    End Function
    Public Function updateLine(ByVal LineN As String, ByVal lineV As String, ByVal idJobNum As String, ByVal idPO As String) As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            Dim cmd1 As New SqlCommand("
if (select COUNT(idPO) from projectOrder where idPO = " + idPO + " and jobNo = " + idJobNum + " and Line = '" + lineV + "') = 1 
		and (select COUNT(idPO) from projectOrder where idPO = " + idPO + " and jobNo = " + idJobNum + " and Line ='" + LineN + "') = 0   
begin 
   	update po set  po.Line = '" + LineN + "' from projectOrder as po 
	inner join job as jb on po.jobNo = jb.jobNo 
	inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = jb.jobNo
	where po.idPO = " + idPO + " and po.jobNo =  " + idJobNum + " and Line = '" + lineV + "' 
end  ", conn)
            ' Dim cmd2 As New SqlCommand("update wo set wo.idPO = " + idPON + " from workOrder as wo inner join projectOrder as po on wo.idPO = po.idPO where po.jobNo = " + idJobNum + " and po.idPO = " + idPON, conn)

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
            tran.Rollback()
            tran.Dispose()
            Return False
        End Try
    End Function
    Public Function updatePO(ByVal idPON As String, ByVal idPOV As String, ByVal idJobNum As String, ByVal idWO As String, ByVal idtask As String, Optional line As String = "", Optional wbs As String = "") As Boolean
        Dim tran As SqlTransaction
        Try
            conectar()
            Dim cmd1 As New SqlCommand("if (select COUNT(*) from projectOrder where idPO = " + idPON + " and jobNo = " + idJobNum + ") = 1  -- existe el PO 
begin
	if (select COUNT(*) from task as tk inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
	where wo.idWO = '" + idWO + "' and tk.task = '" + idtask + "' and wo.idPO = " + idPON + " and wo.jobNo = " + idJobNum + ") = 0
	begin --no existe el WO en el PO ya insertado 
		update workOrder set idPO = " + idPON + "  where idAuxWO =  (select top 1 wo.idAuxWO from workOrder as wo 
                                                                    inner join task as tk on tk.idAuxWO =wo.idAuxWO 
                                                                    inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
                                                                    inner join job as jb on jb.jobNo = po.jobNo 
                                                                    where wo.idWO = '" + idWO + "' and task = '" + idtask + "' and po.idPO = " + idPOV + " and jb.jobNo = " + idJobNum + ")
	end 
end 
else -- aqui no existe el po nuevo 
begin 
	insert into projectOrder values (" + idPON + "," + idJobNum + "," + If(line = "", "", "'" + line + "'") + "," + If(wbs = "", "''", "'" + wbs + "'") + ")
	update workOrder set idPO = " + idPON + "  where idAuxWO =  (select top 1 wo.idAuxWO from workOrder as wo 
                                                                    inner join task as tk on tk.idAuxWO =wo.idAuxWO 
                                                                    inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
                                                                    inner join job as jb on jb.jobNo = po.jobNo 
                                                                    where wo.idWO = '" + idWO + "' and task = '" + idtask + "' and po.idPO = " + idPOV + " and jb.jobNo = " + idJobNum + ")
end", conn)
            ' Dim cmd2 As New SqlCommand("update wo set wo.idPO = " + idPON + " from workOrder as wo inner join projectOrder as po on wo.idPO = po.idPO where po.jobNo = " + idJobNum + " and po.idPO = " + idPON, conn)

            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            'cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery >= 1 Then
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
                MsgBox("Is probably that exist a diplicated WO.")
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            tran.Dispose()
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

    Public Function updatePostingProject(ByVal postingProject As String, ByVal jobNo As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
update job set postingProject = '" + postingProject + "' 
from job as jb
where jb.jobNo = '" + jobNo + "'", conn)
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
    Public Function updatePhase(ByRef phaseN As String, ByVal idAux As String, ByVal WO As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update task set phase = '" + phaseN + "'
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
            Dim cmd As New SqlCommand("update task set status = '" + If(status = True, "1", "0") + "'
where idAux = '" + idAux + "' and idAuxWO = '" + WO + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
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

    Public Function execBulkInsertMaterialUsed(ByVal path As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("Bulk INSERT 
	materialUsed 
FROM 
	'" + path + "'
WITH(
	FIELDTERMINATOR =',',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2,
	MAXERRORS = 1 --NORMALMENTE SE ENCUENTRA EN 10 
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

    Public Function insertMaterialUsed(ByVal datos As List(Of String), Optional tran As SqlTransaction = Nothing, Optional connection As SqlConnection = Nothing) As Boolean
        Try

            Dim cmd As New SqlCommand("insert into materialUsed values(NEWID(),'" + datos(1) + "',1," + datos(3) + ",'" + datos(6) + "','" + datos(2) + "','" + datos(4) + "'," + datos(5) + ")")
            If tran IsNot Nothing Then
                cmd.Connection = connection
                cmd.Transaction = tran
            Else
                conectar()
                cmd.Connection = conn
            End If
            If cmd.ExecuteNonQuery = 1 Then
                'UpdateTotalSpendTask(datos(5))
                If tran Is Nothing Then
                    desconectar()
                End If
                Return True
            Else
                If tran Is Nothing Then
                    desconectar()
                End If
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
                update materialUsed set dateMaterial = '" + datos(1) + "' , amount = " + datos(3) + " ,description = '" + datos(6) + "' , idAux = '" + datos(2) + "',idMaterial = '" + datos(4) + "' , hoursST = " + datos(5) + " where idMaterialUsed = '" + datos(0) + "'", conn)
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
