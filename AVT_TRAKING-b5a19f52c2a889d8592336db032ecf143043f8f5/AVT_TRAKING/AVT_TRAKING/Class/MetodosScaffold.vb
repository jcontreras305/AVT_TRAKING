Imports System.Data.SqlClient
Public Class MetodosScaffold
    Inherits ConnectioDB

    '========================================================= Job CAT ======================================================================= 
    Public Function llenarComboJobCat(ByVal combo As ComboBox) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("cmb")
        tabla.Columns.Add("id")
        tabla.Columns.Add("cat")
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJobCat as 'ID' , cat as 'Description' from jobCat", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("ID")) + " " + dr("Description"))
                tabla.Rows.Add(CStr(dr("ID")) + " " + dr("Description"), CStr(dr("ID")), CStr(dr("Description")))
            End While
            Return tabla
        Catch ex As Exception
            MsgBox(ex.Message())
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarJobCat(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJobCat as 'ID' , cat as 'Description' from jobCat", conn)
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

    Public Function SaveJobCat(ByVal tabla As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            Dim flag As Boolean = True
            Dim cont As Integer = 0
            For Each row As DataGridViewRow In tabla.Rows
                If row.Cells(0).Value() IsNot Nothing Then
                    Dim cmd As New SqlCommand("
if (select COUNT(*) from jobCat where idJobCat = '" + row.Cells(0).Value().ToString() + "' ) = 0
begin 
	insert into jobCat values('" + row.Cells(0).Value().ToString() + "', '" + row.Cells(1).Value().ToString() + "')
end
else if(select COUNT(*) from jobCat where idJobCat = '" + row.Cells(0).Value().ToString() + "' ) = 1
begin
	update jobCat set cat = '" + row.Cells(1).Value().ToString() + "' where idJobCat = '" + row.Cells(0).Value().ToString() + "' 
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
    Public Function llenarComboArea(ByVal combo As ComboBox) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("cmb")
        tabla.Columns.Add("id")
        tabla.Columns.Add("name")
        Try
            conectar()
            Dim cmd As New SqlCommand("select idArea as 'ID', name as 'Name' from areas", conn)
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
    Public Function llenarComboWO(ByVal combo As ComboBox) As DataTable
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
inner join workOrder as wo on wo.idPO = po.idPO
inner join task as tk on tk.idAuxWO = wo.idAuxWO", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("WO No")) + "    " + CStr(dr("Job No")) + "    " + dr("Description"))
                tabla.Rows.Add(CStr(dr("WO No")), CStr(dr("idWO")), CStr(dr("idAux")), CStr(dr("Job No")), CStr(dr("Description")), (CStr(dr("WO No")) + "    " + CStr(dr("Job No")) + "    " + dr("Description")))
            End While
            Return tabla
        Catch ex As Exception
            MsgBox(ex.Message())
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

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
    Public Function llenarComboSubJob(ByVal combo As ComboBox) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("cmb")
        tabla.Columns.Add("subJob")
        tabla.Columns.Add("description")
        Try
            conectar()
            Dim cmd As New SqlCommand("select idSubJob as 'Sub Job', description as 'Description' from subJobs", conn)
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
    insert into product values(" + row.Cells(0).Value.ToString() + ",'" + nameProduct + "'," + If(row.Cells(4).Value.ToString() = "", 0.0, row.Cells(4).Value.ToString()) + "," + If(row.Cells(5).Value.ToString() = "", 0.0, row.Cells(5).Value.ToString()) + "," + If(row.Cells(6).Value.ToString() = "", 0.0, row.Cells(6).Value.ToString()) + "," + If(row.Cells(7).Value.ToString() = "", 0.0, row.Cells(7).Value.ToString()) + "," + If(row.Cells(8).Value.ToString() = "", 0.0, row.Cells(8).Value.ToString()) + "," + If(row.Cells(9).Value.ToString() = "", 0.0, row.Cells(9).Value.ToString()) + ",'" + row.Cells(11).Value.ToString() + "' ,'" + row.Cells(2).Value.ToString() + "','" + row.Cells(3).Value.ToString() + "', " + row.Cells(10).Value.ToString() + "," + row.Cells(12).Value.ToString() + "," + row.Cells(13).Value.ToString() + ")
end
else if(select count(*) from product as p where p.name= '" + nameProduct + "' or p.idProduct = " + row.Cells(0).Value.ToString() + "  or p.QID = '" + row.Cells(11).Value.ToString() + "' )=1
begin
	update product set name = '" + nameProduct + "' ,weight= " + If(row.Cells(4).Value.ToString() = "", 0.0, row.Cells(4).Value.ToString()) + ", weightMeasure = " + If(row.Cells(5).Value.ToString() = "", 0.0, row.Cells(5).Value.ToString()) + ",price = " + If(row.Cells(6).Value.ToString() = "", 0.0, row.Cells(6).Value.ToString()) + ", dailyRentalRate= " + If(row.Cells(7).Value.ToString() = "", 0.0, row.Cells(7).Value.ToString()) + " ,weeklyRentalRate = " + If(row.Cells(8).Value.ToString() = "", 0.0, row.Cells(8).Value.ToString()) + ",monthlyRentalRate = " + If(row.Cells(9).Value.ToString() = "", 0.0, row.Cells(9).Value.ToString()) + ",um='" + row.Cells(2).Value.ToString() + "',class='" + row.Cells(3).Value.ToString() + "',quantity = " + If(row.Cells(10).Value.ToString() = "", "0.0", row.Cells(10).Value.ToString()) + " , PLF = " + If(row.Cells(12).Value.ToString() = "", "0.0", row.Cells(12).Value.ToString()) + ",PSQF = " + If(row.Cells(13).Value.ToString() = "", "0.0", row.Cells(13).Value.ToString()) + " where idProduct = " + row.Cells(0).Value.ToString() + "
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

    Public Function llenarCellComboIDProduct(ByVal cmb As DataGridViewComboBoxCell, ByVal tablaPoductoIncoming As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select concat(idProduct,'    ',name)as product , idProduct, price, um,name,quantity,PLF,PSQF from product", conn)
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

    Public Function llenarScaffold(ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tag, idAux,idJobCat,idArea,idSubJob from scaffoldTraking", conn)
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
            sc.leg = sc.llenarLeg(sc.tag)
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
	insert into scaffoldTraking values('" + sc.tag + "','" + validaFechaParaSQl(sc.dateBild) + "','" + sc.location + "','" + sc.purpose + "','" + sc.comments + "','" + validaFechaParaSQl(sc.dateRecComp) + "','" + sc.contact + "','" + sc.foreman + "','" + sc.erector + "','" + sc.task + "','" + sc.jobcat + "'," + sc.areaID + "," + sc.idsubJob + ")
end
else if (select count(*) from scaffoldTraking where tag = '" + sc.tag + "') = 1
begin 
	update scaffoldTraking set buildDate = '" + validaFechaParaSQl(sc.dateBild) + "',location = '" + sc.location + "',purpose ='" + sc.purpose + "',comments='" + sc.comments + "',reqComp='" + validaFechaParaSQl(sc.dateRecComp) + "',contact='" + sc.contact + "',foreman='" + sc.foreman + "',erector='" + sc.erector + "',idAux='" + sc.task + "',idJobCat='" + sc.jobcat + "',idArea=" + sc.areaID + ",idSubJob=" + sc.idsubJob + " where tag= '" + sc.tag + "'
end", conn)
            cmdTraking.Transaction = tran
            If cmdTraking.ExecuteNonQuery > 0 Then 'si entra se tubo que insertar o actualizar si no hubo un error 
                Dim cmdScaffoflInfo As New SqlCommand("
if (select count(*) from scaffoldInformation where tag ='" + sc.tag + "')=0
begin 
	insert into scaffoldInformation values(NEWID()," + If(sc.sciType = "", "Null", "'" + sc.sciType + "'") + "," + CStr(sc.sciWidth) + "," + CStr(sc.sciLength) + "," + CStr(sc.sciHeigth) + "," + CStr(sc.sciDecks) + "," + CStr(sc.sciKo) + "," + CStr(sc.sciBase) + "," + CStr(sc.sciExtraDeck) + ",'" + sc.tag + "')
end
else if(select count(*) from scaffoldInformation where tag ='" + sc.tag + "')=1 
begin 
	update scaffoldInformation set type=" + If(sc.sciType = "", "Null", "'" + sc.sciType + "'") + ",width=" + CStr(sc.sciWidth) + ",length=" + CStr(sc.sciLength) + ",heigth=" + CStr(sc.sciHeigth) + ",descks=" + CStr(sc.sciDecks) + ",ko=" + CStr(sc.sciKo) + ",base=" + CStr(sc.sciBase) + ",extraDeck=" + CStr(sc.sciExtraDeck) + " where tag = '" + sc.tag + "'
end", conn)
                cmdScaffoflInfo.Transaction = tran
                If cmdScaffoflInfo.ExecuteNonQuery Then 'si entra se tubo que insertar o actulzar la tabla de ScaffoldInformation
                    Dim cmdHours As New SqlCommand("
if (select count(*) from activityHours where tag ='" + sc.tag + "')=0
begin 
	insert into activityHours values(NEWID()," + CStr(sc.ahrBuild) + "," + CStr(sc.ahrMaterial) + "," + CStr(sc.ahrTravel) + "," + CStr(sc.ahrWeather) + "," + CStr(sc.ahrAlarm) + "," + CStr(sc.ahrSafety) + "," + CStr(sc.ahrStdBy) + "," + CStr(sc.ahrOther) + ",'" + sc.tag + "')
end
else if(select count(*) from activityHours where tag ='" + sc.tag + "')=1
begin 
	update activityHours set build=" + CStr(sc.ahrBuild) + ",material=" + CStr(sc.ahrMaterial) + ",travel=" + CStr(sc.ahrTravel) + ",weather=" + CStr(sc.ahrWeather) + ",alarm=" + CStr(sc.ahrAlarm) + ",safety=" + CStr(sc.ahrSafety) + ",stdBy=" + CStr(sc.ahrStdBy) + ",other=" + CStr(sc.ahrOther) + " where tag = '" + sc.tag + "'
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
if (select count(*) from materialHandeling where tag='" + sc.tag + "')=0
begin 
	insert into materialHandeling values(NEWID(),'" + If(sc.materialHandeling(0), "t", "f") + "','" + If(sc.materialHandeling(1), "t", "f") + "','" + If(sc.materialHandeling(2), "t", "f") + "','" + If(sc.materialHandeling(3), "t", "f") + "','" + If(sc.materialHandeling(4), "t", "f") + "','" + If(sc.materialHandeling(5), "t", "f") + "','" + If(sc.materialHandeling(6), "t", "f") + "','" + sc.tag + "')
end
else if (select count(*) from materialHandeling where tag='" + sc.tag + "')=1
begin
	update materialHandeling set truck='" + If(sc.materialHandeling(0), "t", "f") + "',forklift='" + If(sc.materialHandeling(1), "t", "f") + "',trailer='" + If(sc.materialHandeling(2), "t", "f") + "',crane='" + If(sc.materialHandeling(3), "t", "f") + "',rope='" + If(sc.materialHandeling(4), "t", "f") + "',passed='" + If(sc.materialHandeling(5), "t", "f") + "',elevator='" + If(sc.materialHandeling(6), "t", "f") + "' where tag ='" + sc.tag + "' 
end", conn)
                            cmdMaterialHandeling.Transaction = tran
                            If cmdMaterialHandeling.ExecuteNonQuery > 0 Then 'Si entro se tubo que insertar o actualzar la tabla de Material handeling
                                Dim contLeg As Integer = 1
                                For Each row As DataRow In sc.leg.Rows() 'Aqui se ejecuta las fila de la tabla Leg 
                                    Dim cmdLeg As New SqlCommand("
if (select count(*) from leg where legID = '" + If(row.ItemArray(0) Is DBNull.Value, "", row.ItemArray(0)) + "')=0
begin 
	insert into leg values(NEWID()," + row.ItemArray(1) + "," + row.ItemArray(2) + ",'" + sc.tag + "'," + row.ItemArray(3) + " )
end
else if (select count(*) from leg where legID = '" + If(row.ItemArray(0) Is DBNull.Value, "", row.ItemArray(0)) + "')=1
begin
	update leg set qty=" + row.ItemArray(1) + ",heigth=" + row.ItemArray(2) + ", idProduct = " + row.ItemArray(3) + "  where legID ='" + row.ItemArray(0) + "'
end", conn)
                                    cmdLeg.Transaction = tran
                                    If cmdLeg.ExecuteNonQuery > 0 Then
                                        contLeg += 1
                                    Else
                                        tran.Rollback()
                                        MessageBox.Show("Error, check the data and try again." + vbCrLf + "The error is likely in the Leg 'table' at row " + CStr(contLeg) + ".", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        flagComplete = False
                                    End If
                                Next

                                Dim contProduct As Integer = 1
                                For Each row As DataRow In sc.products.Rows() 'Aqui se ejecuta las fila de la tabla de productosScaffold
                                    Dim array = CStr(row.ItemArray(1)).Split(" ")
                                    Dim idProduct = array(0)
                                    Dim cmdProduct As New SqlCommand("
if(select count(*) from productScaffold where idProductScafold='" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "')=0
begin 
	insert into productScaffold values(NEWID(),'" + sc.tag + "'," + idProduct + "," + CStr(row.ItemArray(2)) + ")
	update product set quantity = quantity - (select quantity from product where idProduct = " + CStr(idProduct) + ") where idProduct = " + CStr(idProduct) + "
end
else if(select count(*) from productScaffold where idProductScafold='" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "')=1
begin 
	if(select count(idProduct) from productScaffold where idProductScafold ='" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "' and idProduct = " + idProduct + ")=1
	begin 
		update product set quantity = quantity + (select quantity from productScaffold where idProductScafold = '" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "') where idProduct = " + idProduct + "
		update productScaffold set quantity = " + CStr(row.ItemArray(2)) + " where idProductScafold ='" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "'
		update product set quantity = quantity - " + CStr(row.ItemArray(2)) + " where idProduct = " + idProduct + " 
	end
	else 
	begin 
		update product set quantity = quantity + (select quantity from productScaffold where idProductScafold = '" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "') where idProduct = (select idProduct from productScaffold where idProductScafold = '" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "')
		update productScaffold set idProduct = " + idProduct + " , quantity = " + CStr(row.ItemArray(2)) + " where idProductScafold ='" + If(row.ItemArray(0) Is DBNull.Value, "", CStr(row.ItemArray(0))) + "'
		update product set quantity = quantity - " + CStr(row.ItemArray(2)) + " where idProduct = " + idProduct + " 
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

    Public Function deleteRowsProductScaffold(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("clmIdProductScaffold").Value IsNot Nothing Then
                    Dim cmdDeletePS As New SqlCommand("if (select COUNT(*) from productScaffold where idProductScafold = '" + row.Cells("clmIdProductScaffold").Value + "') = 1
begin 
    if(select count(*) from leg where 
		tag = (select tag from productScaffold where idProductScafold='" + row.Cells("clmIdProductScaffold").Value + "') and
		idProduct = (select idProduct from productScaffold where idProductScafold='" + row.Cells("clmIdProductScaffold").Value + "'))>0
	begin
		delete from leg where tag = (select tag from productScaffold where idProductScafold='" + row.Cells("clmIdProductScaffold").Value + "') and
			idProduct = (select idProduct from productScaffold where idProductScafold='" + row.Cells("clmIdProductScaffold").Value + "')
	end
	update product set quantity = quantity + (select quantity from productScaffold where idProductScafold = '" + row.Cells("clmIdProductScaffold").Value + "') where idProduct = (select idProduct from productScaffold where idProductScafold = '" + row.Cells("clmIdProductScaffold").Value + "')
	delete productScaffold where idProductScafold = '" + row.Cells("clmIdProductScaffold").Value + "'
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



End Class


