Imports System.Data.SqlClient
Public Class MetodosScaffold
    Inherits ConnectioDB

    '========================================================= Areas ======================================================================= 
    Public Function llenarAreas(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ar.idArea as 'Area ID', ar.name as 'Area Name', cordinator AS 'Cordinator' from areas as ar", conn)
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

    Public Function SaveAreas(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select count(*) from areas where idArea = " + row.Cells(0).Value().ToString() + ") = 0
begin
	insert into areas values(" + row.Cells(0).Value().ToString() + ",'" + row.Cells(1).Value().ToString() + "','" + row.Cells(2).Value().ToString() + "') 
end
else if (select count(*) from areas where idArea = " + row.Cells(0).Value().ToString() + ") = 1
begin
	update areas set name ='" + row.Cells(1).Value().ToString() + "',cordinator = '" + row.Cells(2).Value().ToString() + "' where idArea=" + row.Cells(0).Value().ToString() + "
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

    Public Function llenarWO(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo as 'Job No', CONCAT(wo.idWO,'-',tk.task) as 'WO No', tk.description as 'Description'
from job as jb 
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO
inner join task as tk on tk.idAuxWO = wo.idAuxWO", conn)
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

    '========================================================= Sub Jobs ====================================================================
    Public Function llenarSubJobs(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idSubJob as 'Sub Job', description as 'Description' from subJobs", conn)
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

    Public Function SaveSubJobs(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("if (select count(*) from subJobs where idSubJob = " + row.Cells(0).Value().ToString() + " )= 0
begin
	insert into subJobs values(" + row.Cells(0).Value().ToString() + ",'" + row.Cells(1).Value().ToString() + "') 
end
else if (select count(*) from subJobs where idSubJob = " + row.Cells(0).Value().ToString() + ")= 1
begin
	update subJobs set description = '" + row.Cells(1).Value().ToString() + "' where idSubJob=" + row.Cells(0).Value().ToString() + "
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



    '========================================================= Empleados =================================================================
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

    Public Function llenarClassification(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from classification", conn)
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
    Public Function llenarUnitMeassurements(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from unitMeassurements", conn)
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
            Dim cmd As New SqlCommand("select pd.idProduct  as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,pd.existences as 'Order' , pd.QID
from product as pd 
inner join unitMeassurements as um on pd.um = um.um
inner join classification as cl on cl.class = pd.class
inner join materialStatus as ms on ms.idMaterialStatus = pd.status", conn)
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







End Class
