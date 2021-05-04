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

    Public Sub limpiarFilasExcel(Hoja As Microsoft.Office.Interop.Excel.Worksheet, rowStart As Integer)
        Try
            Do While Hoja.Cells(rowStart, 1).Text IsNot "" And Hoja.Cells(rowStart, 2).Text IsNot ""
                Hoja.Rows(rowStart).Clear()
                rowStart += 1
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



End Module
