Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Data.DataTable
Imports System.Runtime.InteropServices
Public Class TimeSheet
    Dim mtdEmployees As New MetodosEmployees
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim mtdJobs As New MetodosJobs
    Public tablaWorkCodes As New Data.DataTable
    Public tablaProject As New Data.DataTable
    Public tablaEmpleadosId As New Data.DataTable
    Public tablaExpeseCode As New Data.DataTable
    Private Sub TimeSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdHPW.llenarTablaWorkCode(tablaWorkCodes)
        mtdHPW.llenarTablaProyecto(tablaProject)
        mtdHPW.llenarTablaExpenses(tablaExpeseCode)
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btnUpdatePerdiem_Click(sender As Object, e As EventArgs) Handles btnUpdatePerdiem.Click
        Try
            '======================================= INSERTAR PERDIEM =====================================================
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "Daily Perdiem Sheet"
            openFile.ShowDialog()
            txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Open file " + openFile.FileName
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim flag As Boolean = False
            Dim case1 As Integer = 0
            For i = 1 To libro.Worksheets.Count
                If libro.Worksheets(i).Name = "Perdiem" Then
                    flag = True
                    case1 = 1
                    Exit For
                ElseIf libro.Worksheets(i).Name = "PerDiem" Then
                    flag = True
                    case1 = 2
                    Exit For
                End If
            Next
            Dim perdiemSheet As New Worksheet
            If flag = True Then
                If case1 = 1 Then
                    perdiemSheet = libro.Worksheets("Perdiem")
                    txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Open sheet 'Perdiem'."
                Else
                    perdiemSheet = libro.Worksheets("PerDiem")
                    txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Open sheet 'PerDiem'."
                End If
                Dim cont As Integer = 2
                Dim tblPerdiem As New Data.DataTable
                tblPerdiem.Columns.Add("IdExpenseUsed")
                tblPerdiem.Columns.Add("DateEU")
                tblPerdiem.Columns.Add("Amount")
                tblPerdiem.Columns.Add("Description")
                tblPerdiem.Columns.Add("ExpenseCode")
                tblPerdiem.Columns.Add("Project")
                tblPerdiem.Columns.Add("Employee")
                txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Reding Data..." + vbCrLf + "reading row "
                Dim msgSalida = txtSalidaPerdiem.Text
                Dim listError As New List(Of String)
                While perdiemSheet.Cells(cont, 2).Text <> ""
                    Dim idAux As String = ""
                    Dim idExpense As String = ""
                    Dim idEmployee As String = ""
                    Dim flag2 As Boolean = False

                    For Each row As DataRow In tablaExpeseCode.Rows
                        If row.ItemArray(1) = perdiemSheet.Cells(cont, 6).Text Then
                            idExpense = row.ItemArray(0) 'ExpenseCode
                            flag2 = True
                            Exit For
                        Else
                            flag2 = False
                        End If
                    Next
                    Dim flag3 As Boolean = False
                    For Each row As DataRow In tablaProject.Rows
                        If row.ItemArray(1) = perdiemSheet.Cells(cont, 4).Text And row.ItemArray(3) = perdiemSheet.Cells(cont, 5).Text Then
                            idAux = row.ItemArray(0).ToString() 'idAux
                            flag3 = True
                            Exit For
                        Else
                            flag3 = True
                        End If
                    Next
                    Dim flag4 As Boolean = False
                    For Each row As DataRow In tablaEmpleadosId.Rows
                        If row.ItemArray(4) = perdiemSheet.Cells(cont, 2).Text Then 'idEmpleado
                            idEmployee = row.ItemArray(0)
                            flag4 = True
                            Exit For
                        Else
                            flag4 = False
                        End If
                    Next

                    If flag2 = False Then 'Expense code
                        If flag3 = False Then 'Project
                            If flag4 = False Then 'IdEmployee
                                listError.Add("Row " + cont.ToString + ": the ExpenseCode, Employee Number and Project were not select.")
                            End If
                        Else
                            listError.Add("Row " + cont.ToString + ": the ExpenseCode and Project were not select.")
                        End If
                        listError.Add("Row " + cont.ToString + ": the ExpenseCode was not select.")
                    ElseIf flag3 = False Then 'Project
                        If flag4 = False Then 'idEmployee
                            listError.Add("Row " + cont.ToString + ": the ExpenseCode and Employee Number were not select.")
                        Else
                            listError.Add("Row " + cont.ToString + ": the Project was not select.")
                        End If
                    ElseIf flag4 = False Then 'idEmplloyee
                        listError.Add("Row " + cont.ToString + ": the Employee Number was not select.")
                    ElseIf flag2 And flag3 And flag4 Then
                        tblPerdiem.Rows.Add("", perdiemSheet.Cells(cont, 3).Text, perdiemSheet.Cells(cont, 7).Text, perdiemSheet.Cells(cont, 8).Text, idExpense, idAux, idEmployee)
                    End If
                    txtSalidaPerdiem.Text = msgSalida + CStr(cont)
                    cont += 1
                End While
                Dim flagContinue As Boolean = True
                If listError.Count > 0 Then
                    For Each obj As String In listError
                        txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + obj
                    Next
                    If DialogResult.OK = MessageBox.Show("Exist Error in the excel, Would you like to continue?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) Then
                        flagContinue = True
                    Else
                        flagContinue = False
                    End If
                End If
                listError.Clear()
                If flagContinue Then
                    txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + "Stating process to insert..."
                    Dim contRowsError As Integer = 2
                    For Each row As Data.DataRow In tblPerdiem.Rows()
                        Dim listEU As New List(Of String)
                        listEU.Add(row.ItemArray(0).ToString)
                        listEU.Add(row.ItemArray(1).ToString)
                        listEU.Add(row.ItemArray(2).ToString)
                        listEU.Add(row.ItemArray(3).ToString)
                        listEU.Add(row.ItemArray(4).ToString)
                        listEU.Add(row.ItemArray(5).ToString)
                        listEU.Add(row.ItemArray(6).ToString)
                        If Not mtdHPW.insertExpensesUsed(listEU) Then
                            listError.Add("Excel Row " + contRowsError.ToString() + ".")
                        End If
                        contRowsError += 1
                    Next
                End If
                If listError.Count > 0 Then
                    txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Error in the next rows:"
                    For Each obj As String In listError
                        txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + obj
                    Next
                Else
                    MsgBox("Successful")
                End If
                txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Closing Excel."
                txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Sleeping..."
                NAR(perdiemSheet)
                libro.Close(True)
                NAR(libro)
                NAR(ApExcel.Workbooks)
                ApExcel.Quit()
                NAR(ApExcel)
                txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "End Excel."
            Else
                MessageBox.Show("The sheet 'Perdiem' is not found.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Me.Close()
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
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try 'general 
            txtSalidaCSV.Text = ""
            MsgSalida(txtSalidaCSV, "Opening the excel document...")
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            Dim countErrors As Integer = 0
            Dim flagRepeat As Boolean = False
            If DialogResult.OK = openFile.ShowDialog() Then
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
                Dim workOrders As New Worksheet
                Try
                    Try
                        MsgSalida(txtSalidaCSV, "Opening the excel document " + openFile.FileName + " ...")
                        Try
                            workOrders = libro.Worksheets("Work Order")
                            MsgSalida(txtSalidaCSV, "Open sheet 'Work Order.'")
                        Catch ex As Exception
                            workOrders = libro.Worksheets("WorkOrder")
                            MsgSalida(txtSalidaCSV, "Open sheet 'WorkOrder.'")
                        End Try
                        MsgSalida(txtSalidaCSV, "Start to Rading Excel... ")
                        Dim tablaWO As New Data.DataTable
                        tablaWO.Columns.Add("index")
                        tablaWO.Columns.Add("wo")
                        tablaWO.Columns.Add("task")
                        tablaWO.Columns.Add("workorder")
                        tablaWO.Columns.Add("description")
                        tablaWO.Columns.Add("account")
                        tablaWO.Columns.Add("expConde")
                        tablaWO.Columns.Add("horas")
                        tablaWO.Columns.Add("po")
                        tablaWO.Columns.Add("job")
                        tablaWO.Columns.Add("idAuxWO")
                        Dim mensaje As String = ""
                        Dim contwo As Integer = 2
                        Dim filasError As String = ""
                        MsgSalida(txtSalidaCSV, "Verifying if exist new Workrders... ")
                        While workOrders.Cells(contwo, 2).Text <> ""
                            Dim wo = workOrders.Cells(contwo, 2).Text.ToString().Replace(" ", "-")
                            Dim workOrder() As String = wo.Split("-") 'workOrder y task
                            tablaWO.Rows.Add(contwo - 1.ToString(), workOrder(0), workOrder(1), workOrders.Cells(contwo, 2).Text, workOrders.Cells(contwo, 3).Text, workOrders.Cells(contwo, 5).Text, workOrders.Cells(contwo, 6).Text, workOrders.Cells(contwo, 7).Text, workOrders.Cells(contwo, 8).Text, workOrders.Cells(contwo, 9).Text, workOrders.Cells(contwo, 1).Text)
                            contwo += 1
                        End While
                        Dim listNewWorkOrders As New List(Of Data.DataRow)
                        Dim flagExistWO As Boolean = False
                        For Each row As DataRow In tablaWO.Rows()
                            flagExistWO = False
                            For Each row1 As DataRow In tablaProject.Rows()
                                Dim workOrder() As String = row1.ItemArray(1).ToString().Split("-")
                                If row.ItemArray(3).ToString().Equals(row1.ItemArray(1).ToString()) And row.ItemArray(8).ToString.Equals(row1.ItemArray(3).ToString()) And row.ItemArray(9).ToString.Equals(row1.ItemArray(4).ToString()) Then
                                    flagExistWO = True
                                    Exit For
                                Else
                                    flagExistWO = False
                                End If
                            Next
                            If Not flagExistWO Then
                                listNewWorkOrders.Add(row)
                            End If
                        Next
                        If listNewWorkOrders.Count > 0 Then
                            txtSalidaCSV.Text = txtSalidaCSV.Text + vbCrLf + listNewWorkOrders.Count.ToString() + " New 'Work Codes', trying to insert the new 'Work Orders'."
                            If DialogResult.Yes = MessageBox.Show("New 'Work Orders' found. Would you like to insert the new 'Work Orders'?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                                For Each item As DataRow In listNewWorkOrders
                                    Dim newPO As New Project
                                    newPO.clear()
                                    newPO.idWorkOrder = item.ItemArray(1)
                                    newPO.idTask = item.ItemArray(2)
                                    newPO.description = item.ItemArray(4)
                                    newPO.accountNum = item.ItemArray(5)
                                    newPO.expCode = item.ItemArray(6)
                                    newPO.estimateHour = item.ItemArray(7)
                                    newPO.idPO = item.ItemArray(8)
                                    newPO.jobNum = item.ItemArray(9)
                                    newPO.equipament = item.ItemArray(10)
                                    For Each row As DataRow In tablaProject.Rows
                                        Dim wo() As String = row(1).ToString().Split("-")
                                        If newPO.idWorkOrder = wo(0) Then
                                            newPO.idAuxWO = row("idAuxWO")
                                            Exit For
                                        Else
                                            newPO.idAuxWO = ""
                                        End If
                                    Next
                                    If mtdJobs.insertarNuevaTarea(newPO) = False Then
                                        mensaje = If(mensaje = "", item.ItemArray(0), mensaje + ", " + item.ItemArray(0))
                                    End If
                                Next
                                MsgSalida(txtSalidaCSV, "The 'Work Order' insertion process is over.")
                            End If
                        Else
                            MsgSalida(txtSalidaCSV, " Work Codes News.")
                        End If
                        Dim insertar As Boolean = True
                        If mensaje <> "" Then
                            txtSalidaCSV.Text = txtSalidaCSV.Text + vbCrLf + mensaje
                            If DialogResult.Yes = MessageBox.Show("Error at workOrders (" + vbCrLf + mensaje + "." + "), Would you like to cotinue?" + vbCrLf + "You probably won't be able to insert the records if you continue.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                                insertar = True
                            Else
                                insertar = False
                            End If
                        End If
                    Catch ex As Exception

                    Finally
                        NAR(workOrders)
                        libro.Close(False)
                        NAR(libro)
                    End Try

                    mtdHPW.llenarTablaProyecto(tablaProject)

                    Try 'documento

                        '#########################  workcodes ########################################################################################################
                        MsgSalida(txtSalidaCSV, "Starting to read the document...")
                        Dim libro2 = ApExcel.Workbooks.Open(openFile.FileName)
                        Dim records As New Worksheet
                        Try
                            records = libro2.Worksheets("Time Sheet")
                            MsgSalida(txtSalidaCSV, "Open sheet 'Time Sheet.'")
                        Catch ex As Exception
                            records = libro2.Worksheets("TimeSheet")
                            txtSalidaCSV.Text = txtSalidaCSV.Text + vbCrLf + "Open sheet 'TimeSheet.'"
                            MsgSalida(txtSalidaCSV, "Open sheet 'TimeSheet.'")
                        End Try
                        MsgSalida(txtSalidaCSV, "Reading sheet '" + records.Name + "'...")
                        Try
                            Dim tblProjects As Data.DataTable = mtdHPW.llenarTablaProjects()
                            Dim tblWC As Data.DataTable = mtdHPW.lllenarTablaWorkCodes()
                            Dim tblEmp As Data.DataTable = mtdHPW.llenarTablaEmpleado()
                            Dim contRecord As Integer = 2
                            Dim textDoc As String = "idHWTMP,hoursST,hoursOT,hours3T,dateWorked,idEmployee,idWorkCode,idAux,schedule" & vbCrLf
                            Dim listErrors As New List(Of String)
                            Dim msgAux As String = txtSalidaCSV.Text + vbCrLf
                            While CStr(records.Cells(contRecord, 2).Value) <> ""
                                'Dim rowP As Data.DataRow = tblProjects.Rows.Cast(Of Data.DataRow).FirstOrDefault(Function(x) CStr(x.ItemArray(0)) = records.Cells(contRecord, 4).value)
                                Dim rowE() As Data.DataRow = tblEmp.Select("numberEmploye = " + CStr(records.Cells(contRecord, 2).value) + "") 'Buscando idEmployee
                                Dim dateRecord As String = validarFechaParaSQlDeExcel(records.Cells(contRecord, 3).Text)
                                Dim rowP() As Data.DataRow = tblProjects.Select("worknum = '" + CStr(records.Cells(contRecord, 4).value) + "' AND idPO = " + CStr(records.Cells(contRecord, 5).value) + "") 'Buscado task 
                                Dim rowWC() As Data.DataRow = tblWC.Select("name = '" + CStr(records.Cells(contRecord, 6).value) + "'") 'Buscando idWorkCode
                                Dim newidRecord As Guid = Guid.NewGuid()

                                Dim hst As String = If(CStr(records.Cells(contRecord, 7).value) = "", "0", CStr(records.Cells(contRecord, 7).value))
                                Dim hot As String = If(CStr(records.Cells(contRecord, 8).value) = "", "0", CStr(records.Cells(contRecord, 8).value))
                                Dim schedule As String = If(records.Cells(contRecord, 9).value = "Day", "DAYS", If(records.Cells(contRecord, 9).value = "DAYS", "DAYS", "NIGTHS"))
                                If rowP.Length > 0 Then
                                    If rowE.Length > 0 Then
                                        If rowWC.Length > 0 Then
                                            textDoc += newidRecord.ToString() & "," & hst & "," & hot & "," & "0" & "," & dateRecord & "," & CStr(rowE(0).ItemArray(2)) & "," & CStr(rowWC(0).ItemArray(0)) & "," & rowP(0).ItemArray(2) & "," & schedule & vbCrLf
                                        Else
                                            listErrors.Add("Row " + CStr(contRecord) + ": Work Code Error.")
                                        End If
                                    Else
                                        listErrors.Add("Row " + CStr(contRecord) + ": Number Employee Error.")
                                    End If
                                Else
                                    listErrors.Add("Row " + CStr(contRecord) + ": Work Order Error.")
                                End If
                                txtSalidaCSV.Text = msgAux + "Reading Excel Row: " + contRecord.ToString()
                                txtSalidaCSV.Select(txtSalidaCSV.Text.Length, 0)
                                txtSalidaCSV.ScrollToCaret()
                                contRecord += 1
                            End While
                            If Not IO.Directory.Exists("C:\TMP") Then
                                My.Computer.FileSystem.CreateDirectory("C:\TMP")
                            End If
                            My.Computer.FileSystem.WriteAllText("C:\TMP\TimeSheetTemp.csv", textDoc, False)
                            Dim flagConitnue As Boolean = True
                            If listErrors.Count > 0 Then
                                MsgSalida(txtSalidaCSV, "List Error :")
                                For Each item As String In listErrors
                                    MsgSalida(txtSalidaCSV, item)
                                Next
                                If DialogResult.Yes = MessageBox.Show("Errors were founff, Are you sure to continue?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                    flagConitnue = False
                                End If
                            End If
                            If flagConitnue Then
                                If mtdHPW.execBulkInsertRecords() Then
                                    MsgSalida(txtSalidaCSV, "The Process Records Insertion is over.")
                                Else
                                    MsgSalida(txtSalidaCSV, "The Process Records Insertion has a problem.")
                                End If
                            End If
                            MsgSalida(txtSalidaCSV, "Closing Excel...")
                        Catch ex As Exception
                            MsgBox(ex.Message())
                        Finally
                            NAR(records)
                            libro2.Close(False)
                            NAR(libro2)
                        End Try
                    Catch ex As Exception
                        MsgBox(ex.Message())
                    End Try
                Catch ex As Exception
                Finally
                    ApExcel.Quit()
                    NAR(ApExcel)
                    MsgSalida(txtSalidaCSV, "End Excel.")
                End Try
            End If
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Function MsgSalida(ByVal txt As System.Windows.Forms.TextBox, ByVal msg As String) As Boolean
        txt.Text = txt.Text + vbCrLf + msg
        txt.Select(txt.Text.Length, 0)
        txt.ScrollToCaret()
        Return True
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub btnRefreshWO_Click(sender As Object, e As EventArgs) Handles btnRefreshWO.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "Time Sheet"
            openFile.ShowDialog()
            MsgSalida(txtSalidaCSV, "Open file " + openFile.FileName)
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim sheetWorkCodes As New Worksheet
            Try
                sheetWorkCodes = libro.Worksheets("WorkOrder")
                MsgSalida(txtSalidaCSV, "Open sheet 'WorkOrder.'")
            Catch ex As Exception
                sheetWorkCodes = libro.Worksheets("Work Order")
                MsgSalida(txtSalidaCSV, "Open sheet 'Work Order.'")
            End Try
            Dim tablaWorkCodes = mtdHPW.selectWOTimeSheet()
            limpiarSheet(sheetWorkCodes, 2)
            If tablaWorkCodes IsNot Nothing And tablaWorkCodes.Rows.Count > 0 Then
                Dim cont As Integer = 2
                MsgSalida(txtSalidaCSV, tablaWorkCodes.Rows().Count.ToString() + " rows." + vbCrLf + "Iserting row ")
                Dim msgSalidaAux = txtSalidaCSV.Text
                For Each row As DataRow In tablaWorkCodes.Rows()
                    txtSalidaCSV.Text = msgSalidaAux + "Row: " + cont.ToString()
                    sheetWorkCodes.Cells(cont, 1) = row.Item("Equipament")
                    sheetWorkCodes.Cells(cont, 2) = row.Item("WorkOrder")
                    sheetWorkCodes.Cells(cont, 3) = row.Item("Description")
                    sheetWorkCodes.Cells(cont, 5) = row.Item("Aco.N")
                    sheetWorkCodes.Cells(cont, 6) = row.Item("ExpCode")
                    sheetWorkCodes.Cells(cont, 7) = row.Item("Hours")
                    sheetWorkCodes.Cells(cont, 8) = row.Item("idPO")
                    sheetWorkCodes.Cells(cont, 9) = row.Item("jobNo")
                    cont += 1
                Next
            End If
            MsgSalida(txtSalidaCSV, "Saving file.")
            libro.Save()
            NAR(sheetWorkCodes)
            libro.Close(True)
            NAR(libro)
            NAR(ApExcel.Workbooks)
            ApExcel.Quit()
            NAR(ApExcel)
            MsgSalida(txtSalidaCSV, "Sleeping...")
            System.Threading.Thread.Sleep(5000)
            MsgSalida(txtSalidaCSV, "End Excel")
        Catch ex As Exception
            MsgBox(ex.Message())
            MsgSalida(txtSalidaCSV, "Error. " + ex.Message())
        End Try
    End Sub
End Class