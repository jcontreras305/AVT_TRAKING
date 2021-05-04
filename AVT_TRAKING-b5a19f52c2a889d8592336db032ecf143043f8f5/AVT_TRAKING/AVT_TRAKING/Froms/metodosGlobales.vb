
Imports System.Text.RegularExpressions

Module metodosGlobales

    Public Function imageToByte(ByVal img As Image) As Byte()
        Try
            Dim aux As New IO.MemoryStream()
            img.Save(aux, img.RawFormat)
            imageToByte = aux.GetBuffer()
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
            If Char.IsDigit(letra) Or letra = "." Then
                flag = True
            Else
                flag = False
                Exit For
            End If
        Next
        Return flag
    End Function

    ''' <summary>
    ''' Este metodo da formato de acuerdo a las dos zonas previstas para isertar en SQLServer 
    ''' </summary>
    ''' <param name="fecha">Necesita un valor de tipo Date</param>
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
                        Return CDate(fecha1)
                    Catch ex As Exception
                        fecha1 = array(0) + "/" + array(1) + "/" + array(2)
                        Return fecha1
                    End Try
                Else
                    Dim fecha1 As String = array(1) + "/" + array(0) + "/" + array(2)
                    Try
                        Return CDate(fecha1)
                    Catch ex As Exception
                        fecha1 = array(0) + "/" + array(1) + "/" + array(2)
                        Return CDate(fecha1)
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

    Public Sub LimparExcelNombres()

    End Sub


End Module
