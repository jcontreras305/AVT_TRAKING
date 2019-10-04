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
End Module
