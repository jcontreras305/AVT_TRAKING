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
End Module
