Imports System.Net
Imports System.Runtime.InteropServices
Imports CrystalDecisions.ReportAppServer
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window

Public Class ReportTaxesCost
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Dim taxesM As New taxesMetodos
    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub ReportTaxesCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientByUser(cmbClients)
    End Sub

    Private Sub cmbClients_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClients.SelectedIndexChanged
        Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")
        Dim idclient As String = array(0)
        llenarComboJobByUser(cmbJobs, idclient)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbClients.SelectedItem IsNot Nothing Then
            If cmbJobs.SelectedItem IsNot Nothing Then
                Dim array() As String = cmbClients.SelectedItem.ToString.Split(" ")

                Dim idclient As String = array(0)
                Dim reportTS As New TaxesCost
                reportTS.SetParameterValue("@startDate", validaFechaParaSQl(dtpInitialDate.Value.Date))
                reportTS.SetParameterValue("@endDate", validaFechaParaSQl(dtpFinalDate.Value.Date))
                reportTS.SetParameterValue("@jobno", cmbJobs.SelectedItem)
                reportTS.SetParameterValue("@CompanyName", "brock")
                If connecReport(reportTS) Then
                    crvTaxesCost.ReportSource = reportTS
                End If
            Else
                MsgBox("Please select a Job No.")
            End If
        Else
            MsgBox("Please select a Client.")
        End If
    End Sub

    Private Sub btnReportExcel_Click(sender As Object, e As EventArgs) Handles btnReportExcel.Click
        Try
            If cmbClients.SelectedItem IsNot Nothing Then
                If cmbJobs.SelectedItem IsNot Nothing Then
                    Dim dt As New Data.DataTable
                    lblMessage.Text = "Message:" + "Loading Data..."
                    dt = taxesM.selectTaxes(cmbJobs.SelectedItem, validaFechaParaSQl(dtpInitialDate.Value.Date).ToString, validaFechaParaSQl(dtpFinalDate.Value.Date).ToString)
                    If dt IsNot Nothing Then
                        lblMessage.Text = "Message:" + "Open excel file..."
                        Dim xlApp As New Application
                        Dim xlLibro As Workbook = xlApp.Workbooks.Add()
                        Dim xlHoja As Worksheet = CType(xlLibro.Sheets(1), Worksheet)

                        ' Mejora de rendimiento
                        xlApp.ScreenUpdating = False
                        xlApp.Calculation = XlCalculation.xlCalculationManual

                        lblMessage.Text = "Message:" + "Writing Data..."
                        xlHoja.Cells(1, 1).Value = dt.Rows(0).Item(0)
                        xlHoja.Cells(1, 1).Value = dt.Rows(0).Item(1)

                        ' Encabezados
                        For cl = 2 To dt.Columns.Count - 1 'solo pegamos las columnas que no se companyName y JobNo 
                            xlHoja.Cells(2, cl - 1).Value = dt.Columns(cl).ColumnName
                            xlHoja.Cells(2, cl - 1).Interior.Color = RGB(204, 255, 204) 'color verde claro
                            xlHoja.Cells(2, cl - 1).Font.Color = RGB(255, 255, 255) 'color blanco
                        Next
                        xlHoja.Cells(2, dt.Columns.Count - 1).Value = "Total Cost Taxes"
                        xlHoja.Cells(2, dt.Columns.Count).Value = "Total Cost"

                        ' Datos
                        Dim actualJobNo As Int64 = 0
                        Dim Row As Integer = 0
                        For Each rowdt As Data.DataRow In dt.Rows

                            Dim totalHrs As Double = 0
                            Dim hrsST As Double = 0
                            Dim hrsOT As Double = 0

                            Dim rateST As Double = 0
                            Dim rateOt As Double = 0
                            Dim totalTaxes As Double = 0
                            For cl = 2 To dt.Columns.Count - 1 'Empezamos en la columna 2(3) ya que las otras son companyName y jobNo
                                Select Case cl
                                    Case 2, 3 'esta es la Fecha y Empleado
                                        xlHoja.Cells(Row + 3, (cl - 1)).Value = rowdt.Item(cl)
                                    Case 4 'estas son las horas ST
                                        hrsST = CDbl(rowdt.Item(cl))
                                        totalHrs += CDbl(rowdt.Item(cl))
                                        xlHoja.Cells(Row + 3, (cl - 1)).Value = rowdt.Item(cl)
                                    Case 5 'estas son las horas OT  
                                        hrsOT = CDbl(rowdt.Item(cl))
                                        totalHrs += CDbl(rowdt.Item(cl))
                                        xlHoja.Cells(Row + 3, (cl - 1)).Value = rowdt.Item(cl)
                                    Case 6 'este es el st
                                        rateST = CDbl(rowdt.Item(cl))
                                        xlHoja.Cells(Row + 3, (cl - 1)).Value = rowdt.Item(cl)
                                    Case 7 'este es el ot
                                        rateOt = CDbl(rowdt.Item(cl))
                                        xlHoja.Cells(Row + 3, (cl - 1)).Value = rowdt.Item(cl)
                                    Case Else 'estas son las taxes 
                                        xlHoja.Cells(Row + 3, (cl - 1)).Value = totalHrs * CDbl(rowdt.Item(cl))
                                        totalTaxes += totalHrs * CDbl(rowdt.Item(cl))
                                End Select

                            Next

                            xlHoja.Cells(Row + 3, dt.Columns.Count - 1).Value = totalTaxes
                            xlHoja.Cells(Row + 3, dt.Columns.Count).Value = totalTaxes + (hrsST * rateST) + (hrsOT * rateOt)
                            lblMessage.Text = "Message:" + "Writing Row (" + CStr(Row) + ")"
                            Row += 1

                        Next

                        ' Guardar
                        Dim sf As New SaveFileDialog
                        sf.Title = "Guardar archivo Excel"
                        sf.Filter = "Archivo Excel (*.xlsx)|*.xlsx"
                        sf.FileName = "TaxesCost"

                        If sf.ShowDialog() = DialogResult.OK Then
                            Dim rutaArchivo As String = sf.FileName
                            xlLibro.SaveAs(sf.FileName)
                        End If


                        xlLibro.Close(False)
                        xlApp.Quit()

                        ' Liberar objetos COM
                        Marshal.ReleaseComObject(xlHoja)
                        Marshal.ReleaseComObject(xlLibro)
                        Marshal.ReleaseComObject(xlApp)
                        xlHoja = Nothing
                        xlLibro = Nothing
                        xlApp = Nothing
                        GC.Collect()
                        GC.WaitForPendingFinalizers()
                        MsgBox("Sucessfull.")
                    End If
                End If
            End If



        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class
Public Class taxesMetodos
    Dim con As New ConnectioDB

    Public Function selectTaxes(jobNo As String, startDate As String, endDate As String) As Data.DataTable

        Try
            con.conectar()
            Dim cmd As New SqlCommand("sp_taxes_cost", con.conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@jobNo", SqlDbType.BigInt).Value = jobNo
            cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = CDate(startDate)
            cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = CDate(endDate)
            cmd.CommandTimeout = 280
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New Data.DataTable
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            con.desconectar()
        End Try
    End Function
End Class