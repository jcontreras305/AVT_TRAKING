Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Module metodosGlobales
    Dim con As New ConnectioDB
    ''' <summary>
    ''' Hace una consulta a la BD filtrando por el numberClient, retornando los jobs asignados a ese cliente.
    ''' </summary>
    ''' <param name="combo"></param>
    ''' <param name="numberClient"></param>
    ''' <returns>
    ''' etorna el combo lleno con los empleados en contrados en la BD
    ''' </returns>
    Public Function llenarComboJobsReports(ByVal combo As ComboBox, ByVal numberClient As String) As Boolean
        Try
            con.conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from job as jb inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient = " + numberClient + "", con.conn) '
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(dr("jobNo"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.desconectar()
        End Try
    End Function
    ''' <summary>
    ''' Hace una consulta a la BD, retornando los empleados con su numero de empleado
    ''' y su nombre (lastname, firstname y middlename).
    ''' </summary>
    ''' <param name="combo"></param>
    ''' <returns> 
    ''' Retorna el combo lleno con los empleados en contrados en la BD.
    ''' </returns>
    Public Function llenarComboEmployeeReports(ByVal combo As ComboBox) As Boolean
        Try
            con.conectar()
            Dim cmd As New SqlCommand("select numberEmploye, CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'name' from employees as em", con.conn) '
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
            con.desconectar()
        End Try
    End Function
    ''' <summary>
    ''' Hace una consulta a la BD, retornando los clientes con su numero de cliente, el nombre de la empresa
    ''' y su nombre (lastname, firstname y middlename).
    ''' </summary>
    ''' <param name="combo"></param>
    ''' <returns>Retorna el combo lleno con los empleados en contrados en la BD.
    ''' </returns>
    Public Function llenarComboClientsReports(ByVal combo As ComboBox) As Boolean
        Try
            con.conectar()
            Dim cmd As New SqlCommand("select numberClient , companyName , CONCAT(lastName,' ',firstName,' ',middleName) as name from clients", con.conn) '
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(CStr(dr("numberClient")) + " " + dr("companyName") + "|" + dr("name"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.desconectar()
        End Try
    End Function
    ''' <summary>
    ''' Hace una consulta a la BD, retornando los Project Order de un client
    ''' </summary>
    ''' <param name="combo"></param>
    ''' <param name="numberClient"></param>
    ''' <returns>Retorna un True si no hubo problemas con la consulta</returns>
    Public Function llenarComoboPOByClient(ByVal combo As ComboBox, ByVal numberClient As String) As Boolean
        Try
            con.conectar()
            Dim cmd As New SqlCommand("select distinct 
po.idPO
from projectOrder as po 
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient 
where cl.numberClient = '" + numberClient + "'", con.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While dr.Read()
                combo.Items.Add(dr("idPO"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function llenarTableInvoicePO(ByVal clientNumber As String, ByVal startDate As String, ByVal endDate As String, ByVal idPO As String, ByVal all As Boolean, ByVal tbl As DataGridView) As Boolean
        Try
            con.conectar()
            Dim cmd As New SqlCommand("select distinct
po.idPO from clients as cl 
inner join job as jb on cl.idClient = jb.idClient
inner join projectOrder as po on po.jobNo = jb.jobNo
inner join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.jobNo
inner join task as tk on tk.idAuxWO = wo.idAuxWO
inner join hoursWorked as hw on hw.idAux = tk.idAux
left join materialUsed as mtu on mtu.idAux = tk.idAux
left join expensesUsed as exu on exu.idAux = tk.idAux
where (hw.dateWorked between '" + startDate + "' and '" + endDate + "' 
	or exu.dateExpense between '" + startDate + "' and '" + endDate + "'
	or mtu.dateMaterial between '" + startDate + "' and '" + endDate + "') 
	and cl.numberClient = " + clientNumber + " and po.idPO like " + If(all, "'%%'", "'" + idPO + "' 
order by po.idPO asc"), con.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idPO"), "")
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            con.desconectar()
        End Try
    End Function
    Public Function existInvoice(ByVal idpo As String, ByVal invoice As String, ByVal startDate As String, ByVal finalDate As String) As Boolean
        Try
            con.conectar()
            Dim cmd As New SqlCommand("
if (select COUNT(*) from invoice where idPO = " + idpo + " and invoice = '" + invoice + "')> 0
begin
	if  (select COUNT(*) from invoice where idPO = " + idpo + " and invoice = '" + invoice + "' and startDate = '" + startDate + "' and FinalDate = '" + finalDate + "' )>0
	begin 
		select 0 as 'QTY' -- si existe pero no es con esa fecha (no se permite)
	end
	else
	begin 
		select 1 as 'QTY'--  si existe pero con esa fecha (se permite)
	end 
end
else
begin 
	select 0 as 'QTY' -- no existe
end", con.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim count As Integer = 0
            While dr.Read()
                count = dr("QTY")
                Exit While
            End While
            dr.Close()
            Return If(count = 0, True, False)
        Catch ex As Exception
            Return False
        Finally
            con.desconectar()
        End Try
    End Function
    Public Function actualizarInvoicePO(ByVal tbl As DataGridView, ByVal clientNumber As String, ByVal startDate As String, ByVal Finaldate As String) As Boolean
        con.conectar()
        Dim tran As SqlTransaction
        tran = con.conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            Dim cmdDeleteInv As New SqlCommand("delete from tempInvoice", con.conn)
            cmdDeleteInv.Transaction = tran
            cmdDeleteInv.ExecuteNonQuery()
            For Each row As DataGridViewRow In tbl.Rows()
                Dim cmd As New SqlCommand("
	                insert into tempInvoice values ('" + row.Cells(1).Value.ToString() + "'," + row.Cells(0).Value.ToString() + ",(select top 1 idClient from clients where numberClient = " + clientNumber + "),'" + startDate + "','" + Finaldate + "')", con.conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    tran.Rollback()
                    flag = False
                    Exit For
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        End Try
    End Function
    Public Function guardarInvoicePO() As Boolean
        con.conectar()
        Dim tran As SqlTransaction
        tran = con.conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            Dim cmd As New SqlCommand("insert into invoice (invoice,idPO,idClient,startDate,FinalDate) select * from tempInvoice", con.conn)
                cmd.Transaction = tran
            If cmd.ExecuteNonQuery > 0 Then
                flag = True
            Else
                tran.Rollback()
                flag = False
            End If
            If flag Then
                tran.Commit()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            tran.Rollback()
            Return False
        End Try
    End Function
    Public Function imageToByte(ByVal img As Image) As Byte()
        Try
            Dim aux As New IO.MemoryStream()
            img.Save(aux, img.RawFormat)
            'imageToByte = aux.GetBuffer()
            Return aux.GetBuffer()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BytetoImage(ByVal array As Byte()) As Image
        Try
            Dim aux As New IO.MemoryStream(array)
            Dim image As Image = Image.FromStream(aux)
            BytetoImage = Image.FromStream(aux)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function selecValorMaxColum(ByVal dtGV As DataGridView, ByVal column As Integer) As Integer
        Try
            If dtGV.Rows.Count > 0 Then
                Dim valmax As Integer = 0
                For Each ROW As DataGridViewRow In dtGV.Rows
                    If CInt(ROW.Cells(column).Value) > valmax Then
                        valmax = CInt(ROW.Cells(column).Value)
                    End If
                Next
                Return valmax
            Else
                Return 100
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function soloNumero(ByVal numerotext As String) As Boolean
        Dim flag As Boolean = False
        Dim array() As Char = numerotext.ToCharArray()
        For Each letra As Char In array
            If Char.IsDigit(letra) Or letra = "." Or letra = "-" Then
                flag = True
            Else
                flag = False
                Exit For
            End If
        Next
        Return flag
    End Function

    Public Function validarFechaParaSQlDeExcel(ByVal fecha As String) As String
        Dim zona As TimeZone = TimeZone.CurrentTimeZone
        If zona.DaylightName = "Hora de verano central (México)" Then
            Dim array() = fecha.Split("/")
            Dim fecha1 As String = array(2) + "-" + array(1) + "-" + array(0)
            Return fecha1
        Else
            Dim array() As String = CStr(fecha).Split("/")
            Dim fecha1 As String = array(0) + "-" + array(1) + "-" + array(2)
            Return fecha1
        End If
    End Function


    ''' <summary>
    ''' Este metodo da formato de acuerdo a las dos zonas previstas para isertar en SQLServer 
    ''' El string para Mexico es de dd/mm/yyyy y para USA es de yyyy/mm/dd
    ''' </summary>
    ''' <param name="fecha">Necesita un valor de tipo String </param>
    ''' <returns>Devuelbe un String con el formato necesario</returns>
    Public Function validaFechaParaSQl(ByVal fecha As String) As String
        Dim zona As TimeZone = TimeZone.CurrentTimeZone
        If zona.DaylightName = "Hora de verano central (México)" Then
            Dim array() = fecha.Split("/")
            Dim fecha1 As String = array(2) + "-" + array(0) + "-" + array(1)
            Return fecha1
        Else
            Dim array() As String = CStr(fecha).Split("/")
            Dim fecha1 As String = array(0) + "-" + array(1) + "-" + array(2)
            Return fecha1
        End If
    End Function

    ''' <summary>
    ''' Este metodo da formato de acuerdo a las dos zonas previstas para isertar en SQLServer 
    ''' </summary>
    ''' <param name="fecha">Necesita un valor de tipo Date</param>
    ''' <returns>Devuelbe un String con el formato necesario</returns>
    Public Function validaFechaParaSQl(ByVal fecha As Date) As String
        Dim zona As TimeZone = TimeZone.CurrentTimeZone
        If zona.DaylightName = "Hora de verano central (México)" Then
            Dim dataAux As String
            dataAux = fecha.ToShortDateString()
            Dim array() As String = CStr(dataAux).Split("/")
            Dim fecha1 As String = array(2) + "-" + array(1) + "-" + array(0)
            Return fecha1
        Else
            Dim dataAux As String
            dataAux = fecha.ToShortDateString()
            Dim array() As String = CStr(dataAux).Split("/")
            Dim fecha1 As String = array(0) + "-" + array(1) + "-" + array(2)
            Return fecha1
        End If
    End Function

    ''' <summary>
    ''' Esta funcion hace un Cast de un string con formato MM/dd/yyyy a date
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    Public Function validarFechaParaVB(ByVal fecha As String) As Date
        Dim zona As TimeZone = TimeZone.CurrentTimeZone
        If zona.DaylightName = "Hora de verano central (México)" Then
            If fecha IsNot Nothing Then
                Dim array() As String = CStr(fecha).Split("/")
                If array(2).Length > 4 Then
                    Dim aux() As String = array(2).Split(" ")
                    array(2) = aux(0)
                    Dim fecha1 As String = array(1) + "/" + array(0) + "/" + array(2)
                    Try
                        Dim newfecha As Date = New Date(CInt(array(2)), CInt(array(1)), CInt(array(0)))
                        Return CDate(fecha1)
                    Catch ex As Exception
                        fecha1 = array(0) + "/" + array(1) + "/" + array(2)
                        Return CDate(fecha1)
                    End Try
                Else
                    Try
                        Dim newfecha As Date = New Date(CInt(array(2)), CInt(array(1)), CInt(array(0)))
                        Return newfecha
                    Catch ex As Exception
                        Dim newfecha As Date = New Date(CInt(array(2)), CInt(array(0)), CInt(array(1)))
                        Return newfecha
                    End Try
                End If
            End If
        Else
            If fecha IsNot Nothing Then
                Dim array() As String = CStr(fecha).Split("/")
                If array(2).Length > 4 Then
                    Dim aux() As String = array(2).Split(" ")
                    array(2) = aux(0)
                    Dim fecha1 As String = array(0) + "/" + array(1) + "/" + array(2)
                    Return CDate(fecha1)
                Else
                    Dim fecha1 As String = array(0) + "/" + array(1) + "/" + array(2)
                    Return CDate(fecha1)
                End If
            Else
                fecha = System.DateTime.Today.ToShortDateString()
                Dim array() As String = CStr(fecha).Split("/")
                If array(2).Length > 4 Then
                    Dim aux() As String = array(2).Split(" ")
                    array(2) = aux(0)
                    Dim fecha1 As String = array(0) + "/" + array(1) + "/" + array(2)
                    Return CDate(fecha1)
                Else
                    Dim fecha1 As String = array(0) + "/" + array(1) + "/" + array(2)
                    Return CDate(fecha1)
                End If
            End If
        End If

        Return Nothing
    End Function

    Public Function primerDiaDeLaSemana(ByVal fecha As Date) As Date
        Dim flag As Boolean = False
        Dim fechaReturn As New Date
        Dim cont As Integer = 0
        While flag = False
            Dim aux As Date = fecha.AddDays(-cont)
            If aux.DayOfWeek = DayOfWeek.Monday Then
                flag = True
            Else
                cont += 1
            End If
        End While
        Return fecha.AddDays(-cont)
    End Function

    Public Function ultimoDiaDeLaSemana(ByVal fecha As Date) As Date
        Dim flag As Boolean = False
        Dim fechaReturn As New Date
        Dim cont As Integer = 0
        While flag = False
            Dim aux As Date = fecha.AddDays(cont)
            If aux.DayOfWeek = DayOfWeek.Sunday Then
                flag = True
            Else
                cont += 1
            End If
        End While
        Return fecha.AddDays(cont)
    End Function

    Public Function validar_Correo(ByVal mail As String) As Boolean
        Return Regex.IsMatch(mail, "^[_a-zA-B0-9]+(\._a-zA-B0-9+)*@[a-zA-B0-9-]+(\.[a-zA-B0-9-]+)*(\.[a-z]{2,4})$") '"^[_a-zA-B0-9]+(\._a-zA-B0-9+)*@[a-zA-B0-9-]+(\.[a-zA-B0-9-]+)*(\.[a-z]{2,4})$")     "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]{2,4}$"
    End Function

    Public Sub pegarFilas(ByVal filas As List(Of Object), ByVal tabla As DataGridView)
        Try
            Dim startRowCopy As Integer = If(tabla.SelectedRows(0).Cells(1).Value.ToString() = "", tabla.RowCount() - 1, tabla.SelectedRows(0).Index)
            For Each obj As Object In filas
                If tabla.Rows.Count() <= startRowCopy + 1 Then
                    Dim dataTableAux = DirectCast(tabla.DataSource(), DataTable)
                    Dim row As DataRow = dataTableAux.NewRow()
                    dataTableAux.Rows.Add(row)
                    tabla.DataSource = dataTableAux
                End If
                Dim dgvr = (DirectCast(obj, DataGridViewRow))
                Dim cont As Integer = 0
                For Each cell As DataGridViewCell In tabla.Rows(startRowCopy).Cells()
                    If cont > 0 Then
                        cell.Value = dgvr.Cells(cont).Value
                        cont += 1
                    Else
                        cont += 1
                    End If
                Next
                startRowCopy += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Sub pegarFilas(ByVal filas As List(Of String()), ByVal tabla As DataGridView)
        Try
            Dim startRowCopy As Integer = If(tabla.SelectedRows(0).Cells(1).Value.ToString() = "", tabla.RowCount() - 1, tabla.SelectedRows(0).Index)
            For Each obj As String() In filas
                If tabla.Rows.Count() <= startRowCopy + 1 Then
                    Dim dataTableAux = DirectCast(tabla.DataSource(), DataTable)
                    Dim row As DataRow = dataTableAux.NewRow()
                    dataTableAux.Rows.Add(row)
                    tabla.DataSource = dataTableAux
                End If
                Dim cont As Integer = 0
                For Each cell As DataGridViewCell In tabla.Rows(startRowCopy).Cells()
                    If cell.ColumnIndex <> 0 Then
                        cell.Value = obj(cont)
                        cont += 1
                    End If
                Next
                startRowCopy += 1
            Next
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Sub NAR(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
    ''' <summary>
    ''' Meotod que regresa la primer fila encontrada en Blanco sobre la Columna indicada.
    ''' </summary>
    ''' <param name="sheet"></param>
    ''' <param name="rowStar"></param>
    ''' <param name="nColum"></param>
    ''' <returns></returns>
    Public Function nreg(ByVal sheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal rowStart As Long, ByVal nColum As Long) As Long
        Do Until CStr(sheet.Cells(rowStart, nColum).Value) = ""
            rowStart += 1
        Loop
        Return rowStart
    End Function

    ''' <summary>
    ''' Metodo que limpia las filas de un Worsheet desde la fila indicada, utiliza el nColum para verirficar si en esa celda hay un valor, y el limCell como 
    ''' limite de celldas a borrar.
    ''' </summary>
    ''' <param name="sheet"></param>
    ''' <param name="rowStart"></param>
    ''' <param name="nColum"></param>
    ''' <param name="limCell"></param>
    Public Sub limpiarSheet(ByVal sheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal rowStart As Long, ByVal nColum As Long, ByVal limCell As Integer)
        Do Until sheet.Cells(rowStart, nColum).Value <> ""
            For index = 1 To limCell
                sheet.Cells(rowStart, index).value = ""
            Next
            rowStart += 1
        Loop
    End Sub

    ''' <summary>
    ''' Metodo que limpia las filas de un Worsheet desde la fila indicada, utiliza el nColum1 y nColum2 para verirficar si en esas celdas hay un valor, y el limCell como 
    ''' limite de celldas a borrar
    ''' </summary>
    ''' <param name="sheet"></param>
    ''' <param name="rowStart"></param>
    ''' <param name="nColum1"></param>
    ''' <param name="nColum2"></param>
    ''' <param name="limCell"></param>
    Public Sub limpiarSheet(ByVal sheet As Microsoft.Office.Interop.Excel.Worksheet, ByVal rowStart As Long, ByVal nColum1 As Long, ByVal nColum2 As Long, ByVal limCell As Integer)
        Do Until sheet.Cells(rowStart, nColum1).Value <> "" Or sheet.Cells(rowStart, nColum2).Value <> ""
            For index = 1 To limCell
                sheet.Cells(rowStart, index).value = ""
            Next
            rowStart += 1
        Loop
    End Sub

    ''' <summary>
    ''' Metodo para limpiar las Filas de un Worksheet 
    ''' </summary>
    ''' <param name="Hoja"></param>
    ''' <param name="rowStart"></param>
    Public Sub limpiarSheet(Hoja As Microsoft.Office.Interop.Excel.Worksheet, rowStart As Integer)
        Try
            Do While Hoja.Cells(rowStart, 1).Text <> "" Or Hoja.Cells(rowStart, 2).Text <> ""
                Hoja.Rows(rowStart).Clear()
                rowStart += 1
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
