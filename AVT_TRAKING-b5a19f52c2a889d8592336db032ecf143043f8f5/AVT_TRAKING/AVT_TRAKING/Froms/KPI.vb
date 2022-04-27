Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class KPI
    Dim mtdSc As New MetodosScaffold
    Dim pointElement As New System.Drawing.Point(317, 13)
    Dim idClient As String
    Dim tblClients As New Data.DataTable
    Private Sub KPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        txtData.Visible = True
        cmbData.Visible = False
        dtpDate.Visible = False
        txtData.Location = pointElement
        cmbData.Location = pointElement
        dtpDate.Location = pointElement
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            Dim mtdClients As New MetodosClients
            tblClients = mtdClients.ConsultaClients()
            Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
            Dim arrayRows() As Data.DataRow = tblClients.Select("numberClient =" + array(0))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub btnFindExcel_Click(sender As Object, e As EventArgs) Handles btnFindExcel.Click
        Try
            Dim flag As Boolean = True
            If cmbClient.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a Client to charge the WONO and Jobbs lists abiables.")
                flag = False
            End If
            If flag And DialogResult.OK = MessageBox.Show("Please verify that the information start at line 4.", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                pgbProgress.Value = 5
                lblMessage.Text = "Message: Opening the excel document..."
                Dim openFile As New OpenFileDialog
                openFile.DefaultExt = "*.xlsm"
                openFile.FileName = "KPI's"

                Dim countErrors As Integer = 0
                Dim flagRepeat As Boolean = False
                If DialogResult.OK = openFile.ShowDialog() Then
                    Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                    Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
                    lblMessage.Text = "Message: Starting to read the document..."
                    Dim kpiSheet As New Worksheet
                    Try
                        kpiSheet = libro.Worksheets(1)
                        lblMessage.Text = "Message: Open sheet '" + libro.Worksheets(1).Name + "'"


                        Dim mensaje As String = ""
                        Dim filasError As String = ""
                        Dim cont As Integer = 4
                        tblDatosKPI.Rows.Clear()
                        Dim Cum As String = ""
                        Dim um As String = ""
                        Dim description As String = ""

                        Dim rowsExcel As Long = nreg(kpiSheet, CLng(4), CLng(2))
                        Dim increment = (90 / rowsExcel)

                        Dim flagIncrement = If(increment > 1, CInt(90 / rowsExcel), If(increment < 1 And increment > 0.5, 2, If(increment < 0.5 And increment > 0.25, 3, 4)))
                        lblMessage.Text = "Message: Reading Excel..."
                        pgbProgress.Value = pgbProgress.Value + 5
                        Dim countIncrement As Integer = 0


                        While kpiSheet.Cells(cont, 1).Text <> "" And kpiSheet.Cells(cont, 2).Text <> ""
                            Dim datos = validarDatos(kpiSheet.Cells(cont, 1).Text, kpiSheet.Cells(cont, 2).Text)
                            tblDatosKPI.Rows.Add(kpiSheet.Cells(cont, 1).text.ToString(), kpiSheet.Cells(cont, 2).text.ToString(), "", kpiSheet.Cells(cont, 3).text.ToString(), kpiSheet.Cells(cont, 4).text.ToString(), kpiSheet.Cells(cont, 5).text.ToString(), kpiSheet.Cells(cont, 6).text.ToString(), kpiSheet.Cells(cont, 7).text.ToString(), kpiSheet.Cells(cont, 8).text.ToString(), kpiSheet.Cells(cont, 9).text.ToString(), kpiSheet.Cells(cont, 10).text.ToString(), kpiSheet.Cells(cont, 11).text.ToString(), kpiSheet.Cells(cont, 12).text.ToString(), "", "", kpiSheet.Cells(cont, 13).text.ToString(), "", "", kpiSheet.Cells(cont, 14).text.ToString(), kpiSheet.Cells(cont, 15).text.ToString(), kpiSheet.Cells(cont, 16).text.ToString())
                            'If datos(3) = "False" Then
                            '    tblDatosKPI.Rows(tblDatosKPI.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
                            '    countErrors += 1
                            'End If
                            countIncrement += 1
                            If pgbProgress.Value <= 96 Then
                                If flagIncrement = countIncrement Then
                                    pgbProgress.Value = pgbProgress.Value + 1
                                    countIncrement = 0
                                End If
                            End If
                            cont += 1
                        End While
                        pgbProgress.Value = 100
                    Catch ex As Exception
                        pgbProgress.Value = 0
                    Finally
                        lblMessage.Text = "Message: Closing Excel..."
                        NAR(kpiSheet)
                        libro.Close(False)
                        lblMessage.Text = "Message: End Excel." + If(countErrors > 0, CStr(countErrors) + " Products are not inserted check the Product ID.", "") + If(flagRepeat = True, " Some Products are repeat.", "")
                        NAR(libro)
                        ApExcel.Quit()
                        NAR(ApExcel)
                    End Try
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            pgbProgress.Value = 0
        Finally
            pgbProgress.Value = 100
        End Try
    End Sub

    Private Function validarDatos(ByVal jobNum As String, ByVal wono As String) As String()
        Try
            Dim array() As String

            Return array
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub tblDatosKPI_CurrentCellChanged(sender As Object, e As EventArgs) Handles tblDatosKPI.CurrentCellChanged
        Select Case tblDatosKPI.CurrentCell.ColumnIndex
            Case tblDatosKPI.Columns("JobNum").Index
                If cmbClient.SelectedItem IsNot Nothing Then
                    Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                    llenarComboJobsReports(cmbData, array(0))
                    cmbData.Location = New System.Drawing.Point(317, 13)
                    cmbData.Visible = True
                    dtpDate.Visible = False
                    txtData.Visible = False
                Else
                    MessageBox.Show("Please Select a Client to charge the WONO and Jobbs lists abiables.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case tblDatosKPI.Columns("wono").Index
                If cmbClient.SelectedItem IsNot Nothing Then
                    Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")


                    cmbData.Location = New System.Drawing.Point(317, 13)
                    cmbData.Visible = True
                    dtpDate.Visible = False
                    txtData.Visible = False
                Else
                    MessageBox.Show("Please Select a Client to charge the WONO and Jobbs lists abiables.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Case tblDatosKPI.Columns("").Index

        End Select
    End Sub


End Class