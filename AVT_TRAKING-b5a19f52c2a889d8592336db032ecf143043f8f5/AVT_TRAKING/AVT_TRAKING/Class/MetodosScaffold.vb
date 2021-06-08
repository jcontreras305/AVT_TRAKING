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
            tabla.Clear()
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

    Public Function llenarClassification(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select class as 'Class', name as 'Name' from classification", conn)
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
            Dim cmd As New SqlCommand("select pd.idProduct  as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,
quantity as 'QTY',
pd.QID
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
quantity as 'QTY' ,--ex.quantity as 'QTY' ,
pd.QID
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
    insert into product values(" + row.ItemArray(0).ToString() + ",'" + nameProduct + "'," + If(row.ItemArray(5).ToString() = "", "0", row.ItemArray(5).ToString()) + "," + If(row.ItemArray(6).ToString() = "", "0", row.ItemArray(6).ToString()) + "," + If(row.ItemArray(4).ToString() = "", "0.0", row.ItemArray(4).ToString()) + "," + If(row.ItemArray(7).ToString() = "", "0", row.ItemArray(7).ToString()) + "," + If(row.ItemArray(8).ToString() = "", "0", row.ItemArray(8).ToString()) + "," + If(row.ItemArray(9).ToString() = "", "0", row.ItemArray(9).ToString()) + ",'" + row.ItemArray(11).ToString() + "' ,'" + row.ItemArray(2).ToString() + "','" + row.ItemArray(3).ToString() + "', " + If(row.ItemArray(10).ToString() = "", "0", row.ItemArray(10).ToString()) + ")
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
    insert into product values(" + row.Cells(0).Value.ToString() + ",'" + nameProduct + "'," + If(row.Cells(4).Value.ToString() = "", 0.0, row.Cells(4).Value.ToString()) + "," + If(row.Cells(5).Value.ToString() = "", 0.0, row.Cells(5).Value.ToString()) + "," + If(row.Cells(6).Value.ToString() = "", 0.0, row.Cells(6).Value.ToString()) + "," + If(row.Cells(7).Value.ToString() = "", 0.0, row.Cells(7).Value.ToString()) + "," + If(row.Cells(8).Value.ToString() = "", 0.0, row.Cells(8).Value.ToString()) + "," + If(row.Cells(9).Value.ToString() = "", 0.0, row.Cells(9).Value.ToString()) + ",'" + row.Cells(11).Value.ToString() + "' ,'" + row.Cells(2).Value.ToString() + "','" + row.Cells(3).Value.ToString() + "', " + row.Cells(10).Value.ToString() + ")
end
else if(select count(*) from product as p where p.name= '" + nameProduct + "' or p.idProduct = " + row.Cells(0).Value.ToString() + "  or p.QID = '" + row.Cells(11).Value.ToString() + "' )=1
begin
	update product set name = '" + nameProduct + "' ,weight= " + If(row.Cells(4).Value.ToString() = "", 0.0, row.Cells(4).Value.ToString()) + ", weightMeasure = " + If(row.Cells(5).Value.ToString() = "", 0.0, row.Cells(5).Value.ToString()) + ",price = " + If(row.Cells(6).Value.ToString() = "", 0.0, row.Cells(6).Value.ToString()) + ", dailyRentalRate= " + If(row.Cells(7).Value.ToString() = "", 0.0, row.Cells(7).Value.ToString()) + " ,weeklyRentalRate = " + If(row.Cells(8).Value.ToString() = "", 0.0, row.Cells(8).Value.ToString()) + ",monthlyRentalRate = " + If(row.Cells(9).Value.ToString() = "", 0.0, row.Cells(9).Value.ToString()) + ",um='" + row.Cells(2).Value.ToString() + "',class='" + row.Cells(3).Value.ToString() + "',quantity = " + If(row.Cells(10).Value.ToString() = "", 0.0, row.Cells(10).Value.ToString()) + " where idProduct = " + row.Cells(0).Value.ToString() + "
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
            Dim cmd As New SqlCommand("select pd.idProduct  as 'ID', pd.name as 'Product Name', pd.um as 'UM',pd.class as 'Class', pd.price as 'Cost', pd.weight as 'Weigth', pd.weightMeasure as 'Weigth Measure',pd.price as '$UM',pd.dailyRentalRate as 'Daily Rental Rate' ,pd.weeklyRentalRate as 'Weekly Rental Rate', pd.monthlyRentalRate as 'Monthly Rental Rate' ,
quantity as 'QTY' ,--ex.quantity as 'QTY' ,
pd.QID
from product as pd 
inner join unitMeassurements as um on pd.um = um.um
inner join classification as cl on cl.class = pd.class " +
If(flagIdProduct, "where pd.idProduct = " + text + " or pd.QID = '" + text + "'", "where pd.class Like '%" + text + "%' or cl.name like '%" + text + "%'") + " order by pd.idProduct", conn)
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

    Public Function llenarInComming(ByVal tblProductos As DataGridView, ByVal tblTickets As DataTable) As List(Of String)
        Dim list As New List(Of String)
        Try
            conectar()
            Dim cmdInComing As New SqlCommand("select * from incoming", conn)
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
                cmdPrductosInComing.CommandText = "select pic.quantity as 'QTY',pic.idProduct as 'ID',pd.price as '$UM',pd.um as 'UM',pd.name as 'Product Description' ,idProductInComingfrom productComing as pic inner join product as pd on pd.idProduct = pic.idProduct"
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

    Public Function llenarCellComboIDProduct(ByVal cmb As DataGridViewComboBoxCell, ByVal tablaPoductoIncoming As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select concat(idProduct,'    ',name)as product , idProduct, price, um,name from product", conn)
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
            Dim cmd As New SqlCommand("select concat(idProduct,'    ',name)as product , idProduct, price, um,name,quantity from product where quantity > 0", conn)
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

    Public Function saveInComing(ByVal tblProductos As DataGridView, ByVal datosTicket As List(Of String), ByVal allRows As Boolean) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Dim cont = 0
        Try
            Dim cmd As New SqlCommand("
if (select count(*) from incoming where ticketNum = '" + datosTicket(0) + "')= 0
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
end
else if(select count(*) from productComing where idProduct =  " + Product(0) + " and ticketNum = '" + datosTicket(0) + "')=1
begin 
	update product set quantity = quantity - (select quantity from productComing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "') where idProduct = " + Product(0) + "
	update productComing set quantity = " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "'
	update product set quantity = quantity + " + row.Cells(0).Value.ToString() + " where idProduct = " + Product(0) + "
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

    '========================================================= In Comming ===========================================================

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

    Public Function llenarOutGoing(ByVal tblProductosOutGoing As DataGridView, ByVal tblTicketsOut As DataTable) As List(Of String)
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
end
else if(select COUNT(*) from productOutGoing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "' )= 1
begin
	update product set quantity = quantity + (select quantity from productOutGoing where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "') where idProduct = " + Product(0) + "
	update productOutGoing set quantity = " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + " and ticketNum = '" + datosTicket(0) + "'
	update product set quantity = quantity - " + CStr(row.Cells(0).Value) + " where idProduct = " + Product(0) + "
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

    Public Function DeleteOutGoing(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction()
        Try
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            If tbl.SelectedRows.Count() > 0 Then
                For Each row As DataGridViewRow In tbl.SelectedRows()
                    If CStr(row.Cells(1).Value) <> "" Then
                        Dim idProduct() = row.Cells(1).Value.ToString().Split("  ")
                        Dim cmdUpdateProduct As New SqlCommand("update product set quantity = quantity + (select quantity from productOutGoing where idProductOutGoing = '" + row.Cells(5).Value.ToString() + "') where idProduct = " + idProduct(0) + "", conn)
                        cmdUpdateProduct.Transaction = tran
                        If cmdUpdateProduct.ExecuteNonQuery > 0 Then
                            Dim cmdDeleteInComing As New SqlCommand("delete from productOutGoing where idProductOutGoing = '" + row.Cells(5).Value.ToString() + "'", conn)
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
End Class


