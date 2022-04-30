Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class KPI
    Dim mtdSc As New MetodosScaffold
    Dim pointElement As New System.Drawing.Point(317, 13)
    Dim idClient As String
    Dim tblClients As New Data.DataTable
    Dim tblWono As New Data.DataTable
    Private Sub KPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        btnSave.Enabled = False
        txtData.Visible = True
        cmbData.Visible = False
        dtpDate.Visible = False
        sprData.Visible = False
        chbData.Visible = False
        txtData.Location = pointElement
        cmbData.Location = pointElement
        dtpDate.Location = pointElement
        sprData.Location = pointElement
        chbData.Location = New System.Drawing.Point(pointElement.X, pointElement.Y + 4)
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        tblDatosKPI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        tblKPISearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        WindowState = FormWindowState.Maximized
        tblDatosKPI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        tblKPISearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
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
            If tblClients.Rows.Count > 0 Then
                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                Dim arrayRows() As Data.DataRow = tblClients.Select("numberClient =" + array(0))
                idClient = arrayRows(0).ItemArray(0)
                tblWono = mtdSc.llenarComboWO(cmbData, idClient)
            End If
            mtdSc.selectKPIByClient(tblKPISearch, idClient)
            'enumerarFilas(tblKPISearch)
            For Each row As DataGridViewRow In tblDatosKPI.Rows
                Dim datos = validarDatos(row.Cells("JobNo").Value, row.Cells("wono").Value)
                If datos(0) = False Then
                    row.DefaultCellStyle.BackColor = Color.Red
                Else
                    row.Cells("IdAux").Value = datos(0)
                    row.DefaultCellStyle.BackColor = Color.White
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Dim flagLoading As Boolean = False
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

                        flagLoading = True
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
                            tblDatosKPI.Rows.Add(kpiSheet.Cells(cont, 1).text.ToString(), kpiSheet.Cells(cont, 2).text.ToString(), If(datos(0) = "False", "", datos(0)), kpiSheet.Cells(cont, 3).text.ToString(), kpiSheet.Cells(cont, 4).text.ToString(), kpiSheet.Cells(cont, 5).text.ToString(), kpiSheet.Cells(cont, 6).text.ToString(), kpiSheet.Cells(cont, 7).text.ToString(), kpiSheet.Cells(cont, 8).text.ToString(), kpiSheet.Cells(cont, 9).text.ToString(), kpiSheet.Cells(cont, 10).text.ToString(), kpiSheet.Cells(cont, 11).text.ToString(), kpiSheet.Cells(cont, 12).text.ToString(), "", "", kpiSheet.Cells(cont, 13).text.ToString(), "", kpiSheet.Cells(cont, 14).text.ToString(), kpiSheet.Cells(cont, 15).text.ToString(), kpiSheet.Cells(cont, 16).text.ToString(), "", False, False)
                            countIncrement += 1
                            If pgbProgress.Value <= 96 Then
                                If flagIncrement = countIncrement Then
                                    pgbProgress.Value = pgbProgress.Value + 1
                                    countIncrement = 0
                                End If
                            End If
                            cont += 1
                        End While
                        validarFilas()
                        If existeError() = False Then
                            btnSave.Enabled = True
                        Else
                            btnSave.Enabled = False
                        End If
                        'enumerarFilas(tblDatosKPI)
                        pgbProgress.Value = 100
                    Catch ex As Exception
                        pgbProgress.Value = 0
                    Finally
                        lblMessage.Text = "Message: Closing Excel..."
                        NAR(kpiSheet)
                        libro.Close(False)
                        lblMessage.Text = "Message: End Excel." + If(countErrors > 0, CStr(countErrors) + " It was not prossible to find some Wo-Num.", "")
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
            flagLoading = False
        End Try
    End Sub

    Private Function validarDatos(ByVal jobNum As String, ByVal wono As String) As String()
        Try
            Dim array() As String = Nothing
            Dim arrayRows() As Data.DataRow = tblWono.Select("job = " + jobNum + " and wono = '" + wono + "'")
            If arrayRows.Count > 0 Then
                array = {arrayRows(0).ItemArray(2).ToString(), jobNum, wono}
            Else
                array = {"False"}
            End If
            Return array
        Catch ex As Exception
            Return {"False"}
        End Try
    End Function
    Private Sub validarFilas()
        For Each row As DataGridViewRow In tblDatosKPI.Rows()
            If row.Cells("idAux").Value = "" And Not row.IsNewRow Then
                row.DefaultCellStyle.BackColor = Color.Red
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub enumerarFilas(ByVal tbl As DataGridView)
        For Each row As DataGridViewRow In tbl.Rows
            row.HeaderCell.Value = CStr(row.Index + 1)
        Next
    End Sub
    Private Sub tblKPISearch_CurrentCellChanged(sender As Object, e As EventArgs) Handles tblKPISearch.CurrentCellChanged
        If Not flagLoading Then
            Try
                If tblKPISearch.CurrentCell IsNot Nothing Then
                    Dim value As String = If(tblKPISearch.CurrentCell.Value Is Nothing, "", tblKPISearch.CurrentCell.Value.ToString())
                    Select Case tblKPISearch.CurrentCell.ColumnIndex
                        Case tblKPISearch.Columns("JobNoS").Index
                            If cmbClient.SelectedItem IsNot Nothing Then
                                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                                llenarComboJobsReports(cmbData, array(0))
                                cmbData.DropDownWidth = 300
                                cmbData.Visible = True
                                dtpDate.Visible = False
                                txtData.Visible = False
                                sprData.Visible = False
                                chbData.Visible = False
                                cmbData.Text = value
                            Else
                                MessageBox.Show("Please Select a Client to charge the WONO and Jobbs lists abiables.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Case tblKPISearch.Columns("wonoS").Index
                            If cmbClient.SelectedItem IsNot Nothing And idClient <> "" Then
                                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                                tblWono = mtdSc.llenarComboWO(cmbData, idClient)
                                cmbData.DropDownWidth = 300
                                cmbData.Visible = True
                                dtpDate.Visible = False
                                txtData.Visible = False
                                sprData.Visible = False
                                chbData.Visible = False
                                cmbData.Text = value
                            Else
                                MessageBox.Show("Please Select a Client to charge the WONO and Jobbs lists abiables.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Case tblKPISearch.Columns("TypeKPIS").Index
                            cmbData.Items.Clear()
                            cmbData.Items.Add("Instalation")
                            cmbData.Items.Add("Remove")
                            cmbData.Items.Add("Paint")
                            cmbData.DropDownWidth = 150
                            cmbData.Visible = True
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = False
                            cmbData.Text = value
                        Case tblKPISearch.Columns("InstallS").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = True
                            sprData.Visible = False
                            chbData.Visible = False
                            txtData.Text = value
                        Case tblKPISearch.Columns("DateWorkedS").Index
                            cmbData.Visible = False
                            dtpDate.Visible = True
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = False
                            Dim array() As String = value.Split("/")
                            If array.Length = 0 Then
                                Dim dateCell As Date = New Date(System.DateTime.Today.Year, System.DateTime.Today.Month, System.DateTime.Today.Day)
                                dtpDate.Value = dateCell
                            Else
                                Dim dateCell As Date = New Date(If(array(2).Length < 4, 2000 + CInt(array(2)), CInt(array(2))), CInt(array(0)), CInt(array(1)))
                                dtpDate.Value = dateCell
                            End If
                        Case tblKPISearch.Columns("DescriptionS").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = True
                            sprData.Visible = False
                            chbData.Visible = False
                            txtData.Text = value
                        Case tblKPISearch.Columns("CasePaintS").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = True
                            sprData.Visible = False
                            chbData.Visible = False
                            txtData.Text = value
                        Case tblKPISearch.Columns("LeadS").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = True
                            chbData.Checked = tblKPISearch.CurrentCell.Value
                        Case tblKPISearch.Columns("STResistenceS").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = True
                            chbData.Checked = tblKPISearch.CurrentCell.Value
                        Case Else
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = True
                            chbData.Visible = False
                            sprData.Value = CDec(If(value = "", "0", value))
                    End Select
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub tblDatosKPI_CurrentCellChanged(sender As Object, e As EventArgs) Handles tblDatosKPI.CurrentCellChanged
        If flagLoading = False Then
            Try
                If tblDatosKPI.CurrentCell IsNot Nothing Then
                    Dim value As String = If(tblDatosKPI.CurrentCell.Value Is Nothing, "", tblDatosKPI.CurrentCell.Value.ToString())
                    Select Case tblDatosKPI.CurrentCell.ColumnIndex
                        Case tblDatosKPI.Columns("JobNo").Index
                            If cmbClient.SelectedItem IsNot Nothing Then
                                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                                llenarComboJobsReports(cmbData, array(0))
                                cmbData.DropDownWidth = 300
                                cmbData.Visible = True
                                dtpDate.Visible = False
                                txtData.Visible = False
                                sprData.Visible = False
                                chbData.Visible = False
                                cmbData.Text = value
                            Else
                                MessageBox.Show("Please Select a Client to charge the WONO and Jobbs lists abiables.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Case tblDatosKPI.Columns("wono").Index
                            If cmbClient.SelectedItem IsNot Nothing And idClient <> "" Then
                                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                                tblWono = mtdSc.llenarComboWO(cmbData, idClient)
                                cmbData.DropDownWidth = 300
                                cmbData.Visible = True
                                dtpDate.Visible = False
                                txtData.Visible = False
                                sprData.Visible = False
                                chbData.Visible = False
                                cmbData.Text = value
                            Else
                                MessageBox.Show("Please Select a Client to charge the WONO and Jobbs lists abiables.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Case tblDatosKPI.Columns("Install").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = True
                            sprData.Visible = False
                            chbData.Visible = False
                            txtData.Text = value
                        Case tblDatosKPI.Columns("DateWorked").Index
                            cmbData.Visible = False
                            dtpDate.Visible = True
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = False
                            Dim array() As String = value.Split("/")
                            If array.Length = 0 Then
                                Dim dateCell As Date = New Date(System.DateTime.Today.Year, System.DateTime.Today.Month, System.DateTime.Today.Day)
                                dtpDate.Value = dateCell
                            Else
                                Dim dateCell As Date = New Date(If(array(2).Length < 4, 2000 + CInt(array(2)), CInt(array(2))), CInt(array(0)), CInt(array(1)))
                                dtpDate.Value = dateCell
                            End If
                        Case tblDatosKPI.Columns("Description").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = True
                            sprData.Visible = False
                            chbData.Visible = False
                            txtData.Text = value
                        Case tblDatosKPI.Columns("CasePaint").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = True
                            sprData.Visible = False
                            chbData.Visible = False
                            txtData.Text = value
                        Case tblDatosKPI.Columns("Lead").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = True
                            chbData.Checked = tblDatosKPI.CurrentCell.Value
                        Case tblDatosKPI.Columns("STResistence").Index
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = False
                            chbData.Visible = True
                            chbData.Checked = tblDatosKPI.CurrentCell.Value
                        Case Else
                            cmbData.Visible = False
                            dtpDate.Visible = False
                            txtData.Visible = False
                            sprData.Visible = True
                            chbData.Visible = False
                            sprData.Value = CDec(If(value = "", "0", value))
                    End Select
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmbData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbData.SelectedIndexChanged
        If tbcKPI.SelectedTab.Text = "Insert KPIs" Then
            If tblDatosKPI.CurrentCell.ColumnIndex = tblDatosKPI.Columns("wono").Index Then
                Dim idAux = tblWono.Rows(cmbData.SelectedIndex - 1)
                If tblDatosKPI.Rows(tblDatosKPI.CurrentCell.RowIndex).Cells("JobNo").Value <> idAux.ItemArray(3) Then
                    tblDatosKPI.Rows(tblDatosKPI.CurrentCell.RowIndex).Cells("JobNo").Value = idAux.ItemArray(3)
                End If
                tblDatosKPI.Rows(tblDatosKPI.CurrentCell.RowIndex).Cells("idAux").Value = idAux.ItemArray(2)
                tblDatosKPI.Rows(tblDatosKPI.CurrentCell.RowIndex).Cells("wono").Value = idAux.ItemArray(0)
                Dim datos = validarDatos(idAux.ItemArray(3), idAux.ItemArray(0))
                If datos(0) = "False" Then
                    tblDatosKPI.Rows(tblDatosKPI.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Red
                Else
                    tblDatosKPI.Rows(tblDatosKPI.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White
                End If
            ElseIf tblDatosKPI.CurrentCell.ColumnIndex = tblDatosKPI.Columns("JobNo").Index Then
                tblDatosKPI.Rows(tblDatosKPI.CurrentRow.Index).Cells("JobNo").Value = cmbData.SelectedItem.ToString()
                Dim datos = validarDatos(tblDatosKPI.Rows(tblDatosKPI.CurrentRow.Index).Cells("JobNo").Value, tblDatosKPI.Rows(tblDatosKPI.CurrentRow.Index).Cells("wono").Value)
                If datos(0) = "False" Then
                    tblDatosKPI.Rows(tblDatosKPI.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Red
                Else
                    tblDatosKPI.Rows(tblDatosKPI.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
                    tblDatosKPI.Rows(tblDatosKPI.CurrentRow.Index).Cells("IdAux").Value = datos(0)
                End If
            End If
            If existeError() = False Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        Else
            If tblKPISearch.CurrentCell.ColumnIndex = tblKPISearch.Columns("wonoS").Index Then
                Dim idAux = tblWono.Rows(cmbData.SelectedIndex - 1)
                If tblKPISearch.Rows(tblKPISearch.CurrentCell.RowIndex).Cells("JobNoS").Value <> idAux.ItemArray(3) Then
                    tblKPISearch.Rows(tblKPISearch.CurrentCell.RowIndex).Cells("JobNoS").Value = idAux.ItemArray(3)
                End If
                tblKPISearch.Rows(tblKPISearch.CurrentCell.RowIndex).Cells("idAuxS").Value = idAux.ItemArray(2)
                tblKPISearch.Rows(tblKPISearch.CurrentCell.RowIndex).Cells("wonoS").Value = idAux.ItemArray(0)
                Dim datos = validarDatos(idAux.ItemArray(3), idAux.ItemArray(0))
                If datos(0) = "False" Then
                    tblKPISearch.Rows(tblKPISearch.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.Red
                Else
                    tblKPISearch.Rows(tblKPISearch.CurrentCell.RowIndex).DefaultCellStyle.BackColor = Color.White
                End If
            ElseIf tblKPISearch.CurrentCell.ColumnIndex = tblKPISearch.Columns("JobNoS").Index Then
                tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).Cells("JobNoS").Value = cmbData.SelectedItem.ToString()
                Dim datos = validarDatos(tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).Cells("JobNoS").Value, tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).Cells("wonoS").Value)
                If datos(0) = "False" Then
                    tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Red
                Else
                    tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).DefaultCellStyle.BackColor = Color.White
                    tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).Cells("IdAuxS").Value = datos(0)
                End If
            ElseIf tblKPISearch.CurrentCell.ColumnIndex = tblKPISearch.Columns("TypeKPIS").Index Then
                tblKPISearch.Rows(tblKPISearch.CurrentRow.Index).Cells("TypeKPIS").Value = cmbData.SelectedItem.ToString()
            End If
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.TextChanged
        Try
            If tbcKPI.SelectedTab.Text = "Insert KPIs" Then
                Dim array() As String = tblDatosKPI.CurrentCell.Value.ToString.Split("/")
                Dim dateCell As Date = New Date(CInt(array(2)), CInt(array(0)), CInt(array(1)))
                If Not Date.Compare(dtpDate.Value, dateCell) = 0 Then
                    tblDatosKPI.CurrentCell.Value = CStr(dtpDate.Value.Month) + "/" + CStr(dtpDate.Value.Day) + "/" + CStr(dtpDate.Value.Year)
                End If
            Else
                Dim array() As String = tblKPISearch.CurrentCell.Value.ToString.Split("/")
                Dim dateCell As Date = New Date(CInt(array(2)), CInt(array(0)), CInt(array(1)))
                If Not Date.Compare(dtpDate.Value, dateCell) = 0 Then
                    tblKPISearch.CurrentCell.Value = CStr(dtpDate.Value.Month) + "/" + CStr(dtpDate.Value.Day) + "/" + CStr(dtpDate.Value.Year)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTypeKPI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeKPI.SelectedIndexChanged
        Select Case cmbTypeKPI.SelectedItem
            Case "Instalation"
                tblDatosKPI.Columns("Lead").Visible = False
                tblDatosKPI.Columns("STResistence").Visible = True
                tblDatosKPI.Columns("CasePaint").Visible = False
            Case "Remove"
                tblDatosKPI.Columns("Lead").Visible = True
                tblDatosKPI.Columns("STResistence").Visible = False
                tblDatosKPI.Columns("CasePaint").Visible = False
            Case "Paint"
                tblDatosKPI.Columns("Lead").Visible = False
                tblDatosKPI.Columns("STResistence").Visible = False
                tblDatosKPI.Columns("CasePaint").Visible = True
        End Select
        cleanCellNotVisibles(cmbTypeKPI.SelectedItem)
    End Sub

    Private Sub cleanCellNotVisibles(ByVal typeKPI As String)
        Try
            For Each row As DataGridViewRow In tblDatosKPI.Rows()
                Select Case typeKPI
                    Case "Instalation"
                        row.Cells("CasePaint").Value = ""
                        row.Cells("Lead").Value = False
                    Case "Remove"
                        row.Cells("CasePaint").Value = ""
                        row.Cells("STResistence").Value = False
                    Case "Paint"
                        row.Cells("Lead").Value = False
                        row.Cells("STResistence").Value = False
                End Select
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chbData_CheckedChanged(sender As Object, e As EventArgs) Handles chbData.CheckedChanged
        tblDatosKPI.CurrentCell.Value = chbData.Checked
    End Sub
    Private Function existeError() As Boolean
        Try
            Dim flagError As Boolean = False
            For Each row As DataGridViewRow In tblDatosKPI.Rows
                If row.DefaultCellStyle.BackColor = Color.Red Then
                    flagError = True
                    Exit For
                End If
            Next
            Return flagError
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            mtdSc.InsertKPIs(tblDatosKPI, cmbTypeKPI.SelectedItem, pgbProgress, lblMessage)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdateRow_Click(sender As Object, e As EventArgs) Handles btnUpdateRow.Click
        Try
            If tblKPISearch.SelectedRows.Count > 0 Then
                If mtdSc.saveUpdateKPI(tblKPISearch) Then
                    mtdSc.selectKPIByClient(tblKPISearch, idClient)
                End If
            Else
                MessageBox.Show("Please Select a row to meke the changes.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sprData_ValueChanged(sender As Object, e As EventArgs) Handles sprData.ValueChanged, sprData.Leave
        Try
            If Not flagLoading Then
                If tbcKPI.SelectedTab.Text = "Insert KPI" And tblDatosKPI.CurrentCell IsNot Nothing Then
                    Select Case tblDatosKPI.CurrentCell.ColumnIndex
                        Case 7 To 8
                            tblDatosKPI.CurrentCell.Value = CStr(sprData.Value)
                        Case 9 To 18
                            tblDatosKPI.CurrentCell.Value = CStr(CInt(sprData.Value))
                    End Select
                ElseIf tbcKPI.SelectedTab.Text = "KPI's Search" And tblKPISearch.CurrentCell IsNot Nothing Then
                    Select Case tblDatosKPI.CurrentCell.ColumnIndex
                        Case 6 To 7
                            tblKPISearch.CurrentCell.Value = CStr(sprData.Value)
                        Case 9 To 10
                            tblKPISearch.CurrentCell.Value = CStr(sprData.Value)
                        Case 11 To 20
                            tblKPISearch.CurrentCell.Value = CStr(CInt(sprData.Value))
                    End Select
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDeleteRow_Click(sender As Object, e As EventArgs) Handles btnDeleteRow.Click
        Try
            If tblKPISearch.SelectedRows.Count > 0 Then
                If mtdSc.deleteKPI(tblKPISearch) Then
                    If DialogResult.OK = MessageBox.Show("Wold you like to refresh the table?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                        mtdSc.selectKPIByClient(tblKPISearch, idClient)
                    End If
                End If
            Else
                MessageBox.Show("Please select a Row.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblKPISearch_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles tblKPISearch.RowsAdded
        Try
            tblKPISearch.Rows(tblKPISearch.Rows.Count - 1).HeaderCell.Value = CStr(tblKPISearch.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblDatosKPI_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles tblDatosKPI.RowsAdded
        Try
            tblDatosKPI.Rows(tblDatosKPI.Rows.Count - 1).HeaderCell.Value = CStr(tblDatosKPI.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub
End Class