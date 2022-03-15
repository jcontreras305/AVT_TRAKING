Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class DismantleValidationTable
    Dim mtdScaffold As New MetodosScaffold
    Dim tblTagsSinDismantle As New Data.DataTable
    Dim cargaDatos As Boolean = False
    Dim flagClick As Boolean = True
    Public fechaStart As Date
    Private Sub DismantleValidationTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdScaffold.llenarTagSinDismantle(tblTagsSinDismantle)
        btnSave.Enabled = False
    End Sub
    Private Sub btnUpdateExcel_Click(sender As Object, e As EventArgs) Handles btnUpdateExcel.Click
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "tScaffolds"
            openFile.ShowDialog()

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim modSheet As Worksheet = New Worksheet
            Dim productSheet As Worksheet = New Worksheet
            pgbComplete.Value = 10
            Dim flagStatus As Boolean = True
            If DialogResult.OK = MessageBox.Show("The process to read the Excel will be start." + vbCr + "Please verify that the name of the Dismantle Sheet is 'tDismHours'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information) Then
                Try
                    modSheet = libro.Worksheets("tDismHours")
                    lblMessage.Text = "Message: Open sheet 'tDismHours'."
                    pgbComplete.Value = 10
                Catch ex As Exception
                    modSheet = libro.Worksheets(4)
                    lblMessage.Text = "Message: Open sheet 'Dismantle'."
                    pgbComplete.Value = 10
                End Try
                validarSheetDis(modSheet)
                If ExistError() Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If
                pgbComplete.Value = 100
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            ApExcel.Quit()
            NAR(ApExcel)
        End Try
    End Sub

    Private Function ExistError() As Boolean
        Dim exists As Boolean = False
        For Each row As DataGridViewRow In tblDismantleSC.Rows()
            If row.Cells("clmErrorD").Value <> "" Then
                exists = True
                Exit For
            End If
        Next
        Return exists
    End Function

    Private Sub validarSheetDis(ByVal sheet As Worksheet)
        Try
            lblMessage.Text = "Message: Reading Dismantle Sheet."
            tblDismantleSC.Rows.Clear()
            Dim contDis As Integer = 2
            While sheet.Cells(contDis, 1).Text <> "" Or sheet.Cells(contDis + 1, 1).Text <> ""
                If contDis >= sprFirstRow.Value Then
                    If sheet.Cells(contDis, 1).Text <> "" Then
                        tblDismantleSC.Rows.Add("", sheet.Cells(contDis, 1).Text, sheet.Cells(contDis, 2).Text, sheet.Cells(contDis, 3).Text, sheet.Cells(contDis, 4).Text, sheet.Cells(contDis, 5).Text, sheet.Cells(contDis, 6).Text, sheet.Cells(contDis, 7).Text, sheet.Cells(contDis, 8).Text, If(sheet.Cells(contDis, 9).Text = "Yes" Or sheet.Cells(contDis, 9).Text = "YES", True, False), If(sheet.Cells(contDis, 10).Text = "Yes" Or sheet.Cells(contDis, 10).Text = "YES", True, False), If(sheet.Cells(contDis, 11).Text = "Yes" Or sheet.Cells(contDis, 11).Text = "YES", True, False), If(sheet.Cells(contDis, 12).Text = "Yes" Or sheet.Cells(contDis, 12).Text = "YES", True, False), If(sheet.Cells(contDis, 13).Text = "Yes" Or sheet.Cells(contDis, 13).Text = "YES", True, False), If(sheet.Cells(contDis, 14).Text = "Yes" Or sheet.Cells(contDis, 14).Text = "YES", True, False), If(sheet.Cells(contDis, 15).Text = "Yes" Or sheet.Cells(contDis, 15).Text = "YES", True, False), sheet.Cells(contDis, 16).Text, sheet.Cells(contDis, 17).Text, sheet.Cells(contDis, 18).Text, sheet.Cells(contDis, 19).Text, sheet.Cells(contDis, 20).Text, sheet.Cells(contDis, 21).Text, sheet.Cells(contDis, 22).Text, sheet.Cells(contDis, 23).Text, sheet.Cells(contDis, 24).Text, sheet.Cells(contDis, 25).Text)
                        tblDismantleSC.Rows(tblDismantleSC.Rows.Count() - 1).HeaderCell.Value = contDis.ToString()
                    End If
                End If
                contDis += 1
            End While
            pgbComplete.Value = pgbComplete.Value + 20
            lblMessage.Text = "Message: Validating the values."
            For Each row1 As DataGridViewRow In tblDismantleSC.Rows()
                validarFilaDis(row1)
            Next
            pgbComplete.Value = pgbComplete.Value + 20
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Sub validarFilaDis(ByVal row As DataGridViewRow)
        Try
            row.DefaultCellStyle.BackColor = Color.White
            row.Cells("clmErrorD").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("clmTagID").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("clmErrorD").Value = ""
            If ExistTag(row.Cells("clmTagID").Value) Then
                Dim contR As Integer = 0
                For Each rowD As DataGridViewRow In tblDismantleSC.Rows()
                    If row.Cells("clmTagID").Value = rowD.Cells("clmTagID").Value Then
                        If contR > 1 Then
                            row.Cells("clmErrorD").Value = If(row.Cells("clmErrorD").Value = "", "The Tag ID is repeated.", row.Cells("clmErrorD").Value & ", The Tag ID is repeated.")
                            row.DefaultCellStyle.BackColor = Color.Yellow
                            row.Cells("clmErrorD").Style.BackColor = row.DefaultCellStyle.BackColor
                            row.Cells("clmTagID").Style.BackColor = Color.Red
                        End If
                        contR += 1
                    End If
                Next
            Else
                row.Cells("clmErrorD").Value = If(row.Cells("clmErrorD").Value = "", "The Tag ID is not inserted or has already been desmantled.", row.Cells("clmErrorD").Value & ", The Tag ID is not inserted or has already been desmantled.")
                row.DefaultCellStyle.BackColor = Color.Yellow
                row.Cells("clmErrorD").Style.BackColor = row.DefaultCellStyle.BackColor
                row.Cells("clmTagID").Style.BackColor = Color.Red
            End If
            If row.Cells("clmErrorD").Value <> "" Then
                tblDismantleSC.Columns("clmErrorD").Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function ExistTag(ByVal tag As String) As Boolean
        Try
            Dim exits As Boolean = False
            For Each row As Data.DataRow In tblTagsSinDismantle.Rows()
                If row.ItemArray(0) = tag Then
                    exits = True
                    Exit For
                End If
            Next
            Return exits
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub tblDismantleSC_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblDismantleSC.CellMouseClick
        flagClick = False
        Select Case e.ColumnIndex
            Case tblDismantleSC.Columns("clmTagID").Index
                cmbDatos.Items.Clear()
                cmbDatos.Items.Add("")
                For Each row As Data.DataRow In tblTagsSinDismantle.Rows()
                    cmbDatos.Items.Add(row.ItemArray(0))
                Next
                cmbDatos.Text = ""
                txtFecha.Enabled = False
                cmbDatos.Enabled = True
            Case tblDismantleSC.Columns("RentStopDate").Index
                Dim auxF1 As Date = fechaStart
                Dim selectFecha As New SelectDate
                AddOwnedForm(selectFecha)
                selectFecha.DVT = True
                selectFecha.ShowDialog()
                txtFecha.Enabled = True
                txtFecha.Text = fechaStart.ToShortDateString()
                cmbDatos.Enabled = False
            Case tblDismantleSC.Columns("DismantleDate").Index
                Dim auxF1 As Date = fechaStart
                Dim selectFecha As New SelectDate
                AddOwnedForm(selectFecha)
                selectFecha.DVT = True
                selectFecha.ShowDialog()
                txtFecha.Enabled = True
                txtFecha.Text = fechaStart.ToShortDateString()
                cmbDatos.Enabled = False
        End Select
        flagClick = True
    End Sub
    Private Sub cmbDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatos.SelectedIndexChanged
        If flagClick = True And cmbDatos.SelectedItem IsNot Nothing And tblDismantleSC.CurrentCell.ColumnIndex = 1 Then
            tblDismantleSC.CurrentCell.Value = cmbDatos.SelectedItem
            validarFilaDis(tblDismantleSC.Rows(tblDismantleSC.CurrentRow.Index))
            If Not ExistError() Then
                tblDismantleSC.Columns("clmErrorD").Visible = False
                btnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub txtFecha_TextChanged(sender As Object, e As EventArgs) Handles txtFecha.TextChanged
        If flagClick And tblDismantleSC.CurrentCell.ColumnIndex = tblDismantleSC.Columns("RentStopDate").Index And tblDismantleSC.CurrentCell.ColumnIndex = tblDismantleSC.Columns("DismantleDate").Index Then
            tblDismantleSC.CurrentCell.Value = txtFecha.Text
        End If
    End Sub
    Private Sub tblDismantleSC_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblDismantleSC.CellEndEdit
        validarFilaDis(tblDismantleSC.Rows(tblDismantleSC.CurrentCell.RowIndex))
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            lblMessage.Text = "Message: Starting Proccess"
            pgbComplete.Value = 10
            lblMessage.Text = "Message: Proccessing Data."
            Dim porcent = CInt(100 / tblDismantleSC.Rows.Count)
            For Each row As DataGridViewRow In tblDismantleSC.Rows
                Dim dis As New dismantle
                dis.tag = row.Cells("clmTagID").Value
                dis.reqCompany = row.Cells("ReqComp").Value
                dis.requestBy = row.Cells("RequestBy").Value
                dis.foreman = row.Cells("Foreman").Value
                dis.erector = row.Cells("Erector").Value
                dis.stopDismantle = validarFechaParaVB(row.Cells("RentStopDate").Value)
                dis.dismantleDate = validarFechaParaVB(row.Cells("DismantleDate").Value)
                dis.materialHandeling(0) = (row.Cells("Truck").Value)
                dis.materialHandeling(1) = (row.Cells("Forklift").Value)
                dis.materialHandeling(2) = (row.Cells("Trailer").Value)
                dis.materialHandeling(3) = (row.Cells("Crane").Value)
                dis.materialHandeling(4) = (row.Cells("Rope").Value)
                dis.materialHandeling(5) = (row.Cells("Passed").Value)
                dis.materialHandeling(6) = (row.Cells("Elevator").Value)
                dis.ahrDismantle = row.Cells("Dismantle").Value
                dis.ahrMaterial = row.Cells("Material").Value
                dis.ahrTravel = row.Cells("Travel").Value
                dis.ahrWeather = row.Cells("Weather").Value
                dis.ahrAlarm = row.Cells("Alarm").Value
                dis.ahrSafety = row.Cells("Safety").Value
                dis.ahrStdBy = row.Cells("stdBY").Value
                dis.ahrTotal = CDec(row.Cells("Dismantle").Value) + CDec(row.Cells("Material").Value) + CDec(row.Cells("Travel").Value) + CDec(row.Cells("Weather").Value) + CDec(row.Cells("Alarm").Value) + CDec(row.Cells("Safety").Value) + CDec(row.Cells("stdBY").Value)
                dis.comments = row.Cells("Comments").Value
                If mtdScaffold.saveDismantle(dis, False) Then
                    'pgbComplete.Value += If(pgbComplete.Value + porcent > 100, porcent, 99)
                Else
                    row.Cells("clmErrorD").Value = "Error, check the data."
                    If ExistError() Then
                        tblDismantleSC.Columns("clmErrorD").Visible = True
                    End If
                End If
            Next
            lblMessage.Text = "Message: Complete."
            pgbComplete.Value = 100
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
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
        WindowState = FormWindowState.Minimized
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
End Class