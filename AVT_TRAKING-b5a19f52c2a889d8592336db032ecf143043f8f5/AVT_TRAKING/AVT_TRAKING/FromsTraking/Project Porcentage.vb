Imports System.Runtime.InteropServices
Public Class Project_Porcentage
    Dim mtdPoPercent As New MetodosProjectPorcentage
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim tblProjectClient As DataTable

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Project_Porcentage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
        mtdPoPercent.selectProject(tblProjects, "'%'")
        tblProjectClient = mtdHPW.llenarTablaProjects()
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            Dim idClient As String = ""
            If cmbClient.SelectedIndex > -1 Then
                Dim array() As String = cmbClient.SelectedItem.ToString.Split(" ")
                idClient = array(0)
                llenarComboJobsReports(cmbJobNo, idClient)
                cmbJobNo.SelectedIndex = -1
                cmbProjectOrder.SelectedIndex = -1
                mtdPoPercent.selectProject(tblProjects, idClient)
            Else
                MessageBox.Show("Please select a client to continue.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbJobNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJobNo.SelectedIndexChanged
        Try
            Dim idClient As String = ""
            Dim jobNo As String = ""
            If cmbClient.SelectedIndex > -1 And cmbJobNo.SelectedIndex > -1 Then
                Dim arrayCL() As String = cmbClient.SelectedItem.ToString.Split(" ")
                idClient = arrayCL(0)
                jobNo = cmbJobNo.Items(cmbJobNo.SelectedIndex)
                llenarComboPOByClient(cmbProjectOrder, idClient, jobNo)
                cmbProjectOrder.SelectedIndex = -1
                mtdPoPercent.selectProject(tblProjects, idClient, jobNo)
            Else
                MessageBox.Show("Please select a Client to continue.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbProjectOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjectOrder.SelectedIndexChanged
        Try
            Dim idClient As String = ""
            Dim jobNo As String = ""
            Dim projectId As String = ""
            If cmbClient.SelectedIndex > -1 And cmbJobNo.SelectedIndex > -1 And cmbProjectOrder.SelectedIndex > -1 Then
                Dim arrayCL() As String = cmbClient.SelectedItem.ToString.Split(" ")
                idClient = arrayCL(0)
                jobNo = cmbJobNo.Items(cmbJobNo.SelectedIndex)
                projectId = cmbProjectOrder.Items(cmbProjectOrder.SelectedIndex)
                mtdPoPercent.selectProject(tblProjects, idClient, jobNo, projectId)
            Else
                MessageBox.Show("Please select a Client or a Job No to continue.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Add
            lblMessage.Text = "Message: " + "Creating a new excel file..."
            pgbComplete.Value = 10

            Dim colums() As String = {"Client No", "Job No", "PO", "WorkOrder", "Porcentage", "Phase", "Project Manager", "Est Total Billings"}
            For i As Int16 = 0 To colums.Length - 1
                libro.Sheets(1).cells(1, i + 1) = colums(i)
            Next
            With libro.Sheets(1).Range("A1:H1")
                .Font.Bold = True
                .Font.ColorIndex = 1
                With .Interior
                    .ColorIndex = 15
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
            End With
            lblMessage.Text = "Message: " + "Writing the excel Data..."
            pgbComplete.Value = 20
            Dim countRows = tblProjects.Rows.Count
            Dim percentAdd As Double = 80 / countRows
            Dim count = 2
            For Each row As DataGridViewRow In tblProjects.Rows
                Dim countC = 1
                For Each cell As DataGridViewCell In row.Cells
                    If cell.ColumnIndex > 1 Then
                        libro.Sheets(1).cells(count, countC).value = cell.Value
                        countC += 1
                    End If
                Next
                count += 1
                If pgbComplete.Value < 90 Then
                    pgbComplete.Value = pgbComplete.Value + 1
                Else
                    pgbComplete.Value = 90
                End If
            Next
            Dim sd As New SaveFileDialog
            lblMessage.Text = "Message: " + "Saving File..."
            sd.DefaultExt = "*.xlsx"
            sd.FileName = "ProjectPorcentajeList"
            sd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            pgbComplete.Value = 100
            sd.ShowDialog()
            libro.SaveAs(sd.FileName)
            NAR(libro.Sheets(1))
            libro.Close(False)
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            pgbComplete.Value = 0
            lblMessage.Text = "Message: "
        Catch ex As Exception
            MsgBox(ex.Message)
            lblMessage.Text = "Message: "
            pgbComplete.Value = 0
        End Try
    End Sub

    Private Sub btnUploadExcel_Click(sender As Object, e As EventArgs) Handles btnUploadExcel.Click
        Try
            lblMessage.Text = "Message: Opening excel file"
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsx"
            openFile.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
            openFile.ShowDialog()
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            lblMessage.Text = "Message: " + "Starting process to open the File " + openFile.FileName
            Dim Hoja1 As New Microsoft.Office.Interop.Excel.Worksheet
            Try
                Hoja1 = libro.Worksheets("Hoja1")
            Catch ex As Exception
                Hoja1 = libro.Worksheets("Sheet1")
            End Try
            lblMessage.Text = "Message:" + "The file has " + CStr(countFilas(Hoja1)) + " records..."

            Dim cont As Int64 = 0
            tblProjects.Rows.Clear()
            For i As Integer = 2 To countFilas(Hoja1) + 1
                Dim dato(9) As String
                dato(0) = Hoja1.Cells(i, 1).Text 'client num
                dato(1) = Hoja1.Cells(i, 2).Text 'jobno
                dato(2) = Hoja1.Cells(i, 3).Text 'po
                dato(3) = Hoja1.Cells(i, 4).Text 'workOrder
                If Not (Hoja1.Cells(i, 5).Text >= 0 And Hoja1.Cells(i, 5).Text <= 100) Then
                    dato(4) = "0" 'Percent
                Else
                    dato(4) = Hoja1.Cells(i, 5).Text 'Percent
                End If

                Dim arrayrow() As DataRow = tblProjectClient.Select("numberClient = " + dato(0) + " and jobNo = " + dato(1) + " and idPO = " + dato(2) + " and worknum = '" + dato(3) + "'")
                If arrayrow.Length > 0 Then
                    dato(5) = arrayrow(0).ItemArray(2)
                    dato(6) = ""
                Else
                    If tblProjects.Columns(1).Visible = False Then
                        tblProjects.Columns(1).Visible = True
                        dato(6) = "The project was not found"
                    Else
                        dato(6) = ""
                    End If
                End If
                dato(7) = Hoja1.Cells(i, 6).Text 'Phase
                dato(8) = Hoja1.Cells(i, 7).Text ' Project Manager  
                dato(9) = Hoja1.Cells(i, 8).Text ' Est Total Billing
                tblProjects.Rows.Add(dato(5), dato(6), dato(0), dato(1), dato(2), dato(3), dato(4), dato(6), dato(7), dato(8))
                If dato(6) <> "" Then
                    tblProjects.Rows(tblProjects.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
            lblMessage.Text = "Message:" + "The process to read the excel file is over."
            NAR(libro.Sheets(1))
            libro.Close(False)
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            lblMessage.Text = "Message:" + "The File is Closed."
        Catch ex As Exception
            MsgBox(ex.Message())
            lblMessage.Text = "Message:" + "Error"
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If tblProjects.SelectedRows.Count > 0 Then
                lblMessage.Text = "Message: " + " Reading the table..."
                Dim tblDataSelected As New DataTable
                tblDataSelected.Columns.Add("IdAux")
                tblDataSelected.Columns.Add("Percent")
                tblDataSelected.Columns.Add("Phase")
                tblDataSelected.Columns.Add("ProjectManager")
                tblDataSelected.Columns.Add("EstTotalBilling")
                For Each row As DataGridViewRow In tblProjects.SelectedRows
                    tblDataSelected.Rows.Add(row.Cells("idAux").Value, row.Cells("Porcentage").Value, row.Cells("clmPhase").Value, row.Cells("clmProjectManager").Value, row.Cells("clmEstTotalBilling").Value)
                Next
                lblMessage.Text = "Message: " + " Saving the changues..."
                If mtdPoPercent.updateProjectPercent(tblDataSelected, pgbComplete) Then
                    MsgBox("Successful.")
                    pgbComplete.Value = 100
                Else
                    MsgBox("Error please check the information.")
                End If
                pgbComplete.Value = 100
            Else
                MessageBox.Show("Please select a row to continue.")
                pgbComplete.Value = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            pgbComplete.Value = 100
        End Try
    End Sub

    Private Sub tblProjects_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblProjects.CellEndEdit
        Try
            Select Case tblProjects.CurrentCell.ColumnIndex
                Case tblProjects.Columns("Porcentage").Index
                    If soloNumero(tblProjects.CurrentCell.Value.ToString()) Then
                        If CInt(tblProjects.CurrentCell.Value) >= 100 Then
                            tblProjects.CurrentCell.Value = 100
                        ElseIf CInt(tblProjects.CurrentCell.Value) <= 0 Then
                            tblProjects.CurrentCell.Value = 0
                        End If
                    Else
                        tblProjects.CurrentCell.Value = 0
                    End If
                Case Else
                    Dim arrayrow() As DataRow = tblProjectClient.Select("numberClient = " + tblProjects.CurrentRow.Cells(2).Value + " and jobNo = " + tblProjects.CurrentRow.Cells(3).Value + " and idPO = " + tblProjects.CurrentRow.Cells(4).Value + " and worknum = '" + tblProjects.CurrentRow.Cells(5).Value + "'")
                    If arrayrow.Length > 0 Then
                        tblProjects.CurrentRow.Cells(0).Value = arrayrow(0).ItemArray(2)
                        tblProjects.CurrentRow.Cells(1).Value = ""
                        tblProjects.Rows(tblProjects.Rows.Count - 1).DefaultCellStyle.BackColor = Color.White
                    Else
                        If tblProjects.Columns(1).Visible = False Then
                            tblProjects.Columns(1).Visible = True
                        End If
                        tblProjects.CurrentRow.Cells(1).Value = "The project was not found"
                        tblProjects.Rows(tblProjects.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    If existError() Then
                        btnSave.Enabled = False
                        tblProjects.Columns(1).Visible = True
                    Else
                        btnSave.Enabled = True
                        tblProjects.Columns(1).Visible = False
                    End If
            End Select


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Private Function existError() As Boolean
        Dim flag As Boolean = False
        For Each row As DataGridViewRow In tblProjects.Rows
            If row.Cells("Errors").Value <> "" Then
                flag = True
                Exit For
            Else
                flag = False
            End If
        Next
        Return flag
    End Function

    Private Sub tblProjects_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles tblProjects.RowsRemoved
        If existError() Then
            btnSave.Enabled = False
            tblProjects.Columns(1).Visible = True
        Else
            btnSave.Enabled = True
            tblProjects.Columns(1).Visible = False
        End If
    End Sub
End Class