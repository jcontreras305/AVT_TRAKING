Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection

Public Class ReportsMenu
    Private Sub btnTimeSheet_Click(sender As Object, e As EventArgs) Handles btnTimeSheet.Click
        Dim tse As New ReporteEmployees
        tse.ShowDialog()
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnActAverage_Click(sender As Object, e As EventArgs) Handles btnActAverage.Click
        Dim tse As New ReportActiveAverageE
        tse.ShowDialog()
    End Sub
    Private Sub btnClientBilling_Click(sender As Object, e As EventArgs) Handles btnClientBilling.Click
        Dim tse As New ReportClientBillingProject
        tse.ShowDialog()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tse As New ReportCatsEmployeePorject
        tse.ShowDialog()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim tse As New ReportClientBillingsReCapBYProject
        tse.ShowDialog()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim tse As New ReportCompleteByDateRange
        tse.ShowDialog()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim tse As New ReportEmployeePerDiem
        tse.ShowDialog()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim tse As New ReportEmployeesTime
        tse.ShowDialog()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim tse As New ReportJNumber
        tse.ShowDialog()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim tse As New ReportAllJob
        tse.ShowDialog()
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim tse As New ReportHoursPerWeek
        tse.ShowDialog()
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim tse As New ReportYearFinalHours
        tse.ShowDialog()
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim tse As New ReportWONotComplete
        tse.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tse As New ReportTimeSheetsPO
        tse.ShowDialog()
    End Sub
    Private Sub btnVacationE_Click(sender As Object, e As EventArgs) Handles btnVacationE.Click
        Dim tse As New ReportVacationEmployee
        tse.ShowDialog()
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim tse As New ReportInvoice
        tse.ShowDialog()
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim tse As New ReportInvoiceDetails
        tse.ShowDialog()
    End Sub
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim tse As New ScaffoldHistoryByJobNo
        tse.ShowDialog()
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim tse As New ScaffoldHistoryByJobAndWO
        tse.ShowDialog()
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim tse As New ScaffoldHistoryByJobAndUnit
        tse.ShowDialog()
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim tse As New ScaffoldHistoryDismantled
        tse.ShowDialog()
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim tse As New ScaffoldHisoryByJob
        tse.ShowDialog()
    End Sub
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim tse As New ScaffoldRentalDatails
        tse.ShowDialog()
    End Sub
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim tse As New ScaffoldMaterialInventory
        tse.ShowDialog()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim tse As New DailyEquipmentRent
        tse.ShowDialog()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim tse As New ScaffoldActive
        tse.ShowDialog()
    End Sub
    Public datos As New List(Of String)
    Public cancelProcess As Boolean
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim resultMessage = MessageBox.Show("Would you like to Asign diferent Range of Date?", "Message", MessageBoxButtons.YesNoCancel)
        If resultMessage = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim rpData As New ReportDateExcel
            AddOwnedForm(rpData)
            rpData.startDate = True
            rpData.finalDate = False
            rpData.clients = False
            rpData.jobs = False
            rpData.windowStart = "UnderFourty"
            rpData.ShowDialog()
            If Not cancelProcess Then
                Dim mtdReportMenu As New ReportsExcel
                mtdReportMenu.createExcelUnderFourty(If(datos.Count > 0, datos(0), validaFechaParaSQl(System.DateTime.Today)))
                Cursor = Cursors.Default
            End If
        ElseIf resultMessage = DialogResult.No Then
            Cursor = Cursors.WaitCursor
            Dim mtdReportMenu As New ReportsExcel
            mtdReportMenu.createExcelUnderFourty(validaFechaParaSQl(System.DateTime.Today))
            Cursor = Cursors.Default
        Else
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim rpData As New ReportDateExcel
            AddOwnedForm(rpData)
            rpData.startDate = True
            rpData.finalDate = True
            rpData.clients = True
            rpData.jobs = True
            rpData.dtpStartDate.Value = New Date(System.DateTime.Today.Year, System.DateTime.Today.Month, 1)
            rpData.dtpFinalDate.Value = New Date(System.DateTime.Today.Year, System.DateTime.Today.Month, DateTime.DaysInMonth(System.DateTime.Today.Year, System.DateTime.Today.Month))
            rpData.windowStart = "MounthHours"
            rpData.ShowDialog()
            If Not cancelProcess Then
                Dim mtdReportMenu As New ReportsExcel
                mtdReportMenu.createExcelMoutlyHours(datos(2), datos(0), datos(1), If(datos(4) = "1", Nothing, datos(3)))
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim matd As New MaterialDetails
        matd.ShowDialog()
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim rptInc As New ScaffoldProductIncoming
        rptInc.Incoming = True
        rptInc.ShowDialog()
    End Sub
    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Dim rptInc As New ScaffoldProductIncoming
        rptInc.Incoming = False
        rptInc.ShowDialog()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "TimeSheet.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\TimeSheet.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "PBI.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\TableToPBI.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "InvocePieces.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\InvoicePieces.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "Scaffolds.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\tScaffolds.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "Working.xlsm"
            sd.Filter = "*|xlsm"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\Working.xlsm"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "Factors.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\Factors.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "Incomming.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\Incoming.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "Incomming.xlsx"
            sd.Filter = "*|xlsx"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\Outgoing.xlsx"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "MASTER Payroll.xlsm"
            sd.Filter = "*|xlsm"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\MASTER Payroll.xlsm"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        Try
            Dim sd As New SaveFileDialog()
            sd.FileName = "MASTER Per-Diem.xlsm"
            sd.Filter = "*|xlsm"
            If DialogResult.OK = sd.ShowDialog() Then
                Dim path As String = sd.FileName
                Dim doc = AppDomain.CurrentDomain.BaseDirectory + "Docs\MASTER Per-Diem.xlsm"
                'MsgBox(doc)
                saveDoc(path, doc)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function saveDoc(ByVal path As String, docPath As String) As Boolean
        Try
            If File.Exists(path) Then
                File.Delete(path)
            End If
            File.Copy(docPath, path, False)
            Process.Start(path, OpenMode.Random)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class