
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
            Dim fecha1 As String = array(1) + "-" + array(0) + "-" + array(2)
            Return fecha1
        End If
    End Function

    Public Function validarFechaParaVB(ByVal fecha As String) As Date
        Dim zona As TimeZone = TimeZone.CurrentTimeZone
        If zona.DaylightName = "Hora de verano central (México)" Then
            If fecha IsNot Nothing Then
                Dim array() As String = CStr(fecha).Split("/")
                Dim fecha1 As String = array(1) + "/" + array(0) + "/" + array(2)
                Return CDate(fecha1)
            End If
        Else
            If fecha IsNot Nothing Then
                Dim array() As String = CStr(fecha).Split("/")
                Dim fecha1 As String = array(1) + "/" + array(0) + "/" + array(2)
                Return CDate(fecha1)
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


End Module
