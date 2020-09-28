Module MetodosParaDocumentos

    Public Function countFilas(Hoja As Microsoft.Office.Interop.Excel.Worksheet)
        Dim nfila As Integer = 2
        Dim cont As Integer = 0
        Do While Hoja.Cells(nfila, 1).Text IsNot ""
            nfila = nfila + 1
            cont = cont + 1
        Loop
        Return cont
    End Function

End Module
