Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Data.DataTable
Imports System.Runtime.InteropServices
Public Class TimeSheet
    Dim mtdEmployees As New MetodosEmployees
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim mtdJobs As New MetodosJobs
    Public tablaHour As New Data.DataTable
    Public tablaWorkCodes As New Data.DataTable
    Public tablaProject As New Data.DataTable
    Public tablaEmpleadosId As New Data.DataTable
    Public tablaExpeseCode As New Data.DataTable
    Public flagErrorContinue As Boolean
    Public correctionString As String
    Private Sub TimeSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdHPW.llenarTablaWorkCode(tablaWorkCodes)
        mtdHPW.llenarTablaProyecto(tablaProject)
        mtdHPW.llenarTablaExpenses(tablaExpeseCode)
        flagErrorContinue = False
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
                Dim textInsertExpUsed As String = "idExpenseUsed,dateExpense,amount,description,idExpense,idAux,idEmployee,idHoursWorked,dayInserted" & vbCrLf
                While perdiemSheet.Cells(cont, 2).Text <> ""
                    Dim idAux As String = ""
                    Dim jobNo As String = ""
                    Dim idExpense As String = ""
                    Dim idEmployee As String = ""
                    Dim idHrsW As String = ""
                    Dim flag2 As Boolean = False
                    Dim arrayExpense() As DataRow = tablaExpeseCode.Select("expenseCode = '" + If(perdiemSheet.Cells(cont, 6).text = "Per-Diem" Or perdiemSheet.Cells(cont, 6).text = "Per Diem", "Per-Diem", "Travel") + "'")
                    If arrayExpense.Length > 0 Then
                        idExpense = arrayExpense(0).ItemArray(0).ToString()
                        flag2 = True
                    End If
                    Dim flag3 As Boolean = False
                    Dim arrayEmp() As DataRow = tablaEmpleadosId.Select("numberEmploye = " + perdiemSheet.Cells(cont, 2).text)
                    If arrayEmp.Length > 0 Then
                        idEmployee = arrayEmp(0).ItemArray(0).ToString() 'idemployee
                        flag3 = True
                    End If

                    'For Each row As DataRow In tablaExpeseCode.Rows
                    '    If row.ItemArray(1) = perdiemSheet.Cells(cont, 6).Text Then
                    '        idExpense = row.ItemArray(0) 'ExpenseCode
                    '        flag2 = True
                    '        Exit For
                    '    Else
                    '        flag2 = False
                    '    End If
                    'Next
                    'Dim flag3 As Boolean = False


                    'Dim arrayProject() As DataRow = tablaProject.Select("project = '" + perdiemSheet.Cells(cont, 4).text + "' and idPO = " + perdiemSheet.Cells(cont, 5).Text)
                    'Dim tblProjectsEnabled As DataTable = mtdHPW.selectIdProject(validarFechaParaSQlDeExcel(perdiemSheet.Cells(cont, 3).text), perdiemSheet.Cells(cont, 2).text, perdiemSheet.Cells(cont, 4).text, perdiemSheet.Cells(cont, 5).text)

                    '
                    'For Each row As DataRow In tablaProject.Rows
                    '    If row.ItemArray(1) = perdiemSheet.Cells(cont, 4).Text And row.ItemArray(3) = perdiemSheet.Cells(cont, 5).Text Then
                    '        idAux = row.ItemArray(0).ToString() 'idAux
                    '        flag3 = True
                    '        Exit For
                    '    Else
                    '        flag3 = True
                    '    End If
                    'Next


                    Dim flag4 As Boolean = False

                    If flag2 And flag3 Then 'encontro empleado y expense
                        Dim tblProjectsEnabled As Data.DataTable = mtdHPW.selectIdProject(validarFechaParaSQlDeExcel(perdiemSheet.Cells(cont, 3).text), perdiemSheet.Cells(cont, 5).text, perdiemSheet.Cells(cont, 4).text, perdiemSheet.Cells(cont, 2).text)
                        If tblProjectsEnabled IsNot Nothing And tblProjectsEnabled.Rows.Count > 0 Then 'SI encontro horas trabajadas ese dia con ese projecto
                            idHrsW = tblProjectsEnabled.Rows(0).ItemArray(0)
                            idAux = tblProjectsEnabled.Rows(0).ItemArray(1)
                            jobNo = tblProjectsEnabled.Rows(0).ItemArray(6)
                            flag4 = True
                        Else 'NO encontro horas trabajadas ese dia con ese projecto
                            Dim datosHW(6) As String
                            datosHW(0) = validarFechaParaSQlDeExcel(perdiemSheet.Cells(cont, 3).text)
                            datosHW(1) = idEmployee
                            Dim arrayProject() As DataRow = tablaProject.Select("project = '" + perdiemSheet.Cells(cont, 4).text + "' and idPO = " + perdiemSheet.Cells(cont, 5).Text)
                            If arrayProject.Length > 0 Then
                                idAux = arrayProject(0).ItemArray(0).ToString() 'idAux
                                jobNo = arrayProject(0).ItemArray(0).ToString() ' jobNo
                                datosHW(2) = idAux
                                datosHW(3) = jobNo
                                idHrsW = mtdHPW.insertarRecordToPerdiem(datosHW)
                                flag4 = True
                            Else
                                flag4 = False
                            End If
                        End If
                    Else
                        flag4 = False
                    End If


                    'For Each row As DataRow In tablaEmpleadosId.Rows
                    '    If row.ItemArray(4) = perdiemSheet.Cells(cont, 2).Text Then 'idEmpleado
                    '        idEmployee = row.ItemArray(0)
                    '        flag4 = True
                    '        Exit For
                    '    Else
                    '        flag4 = False
                    '    End If
                    'Next
                    'If cont >= 200 Then
                    '    MsgBox("error")
                    'End If
                    Dim dayInserted As String = validaFechaParaSQl(Date.Today)
                    If flag2 = False Then 'Expense code
                        If flag3 = False Then 'employee
                            If flag4 = False Then 'Project
                                listError.Add("Row " + cont.ToString + ": the ExpenseCode, Employee Number and Project were not found.")
                            End If
                        Else
                            listError.Add("Row " + cont.ToString + ": the Employee and Expense Code were not found.")
                        End If
                        listError.Add("Row " + cont.ToString + ": the ExpenseCode was not Found.")
                    ElseIf flag3 = False Then 'Employee
                        If flag4 = False Then 'Project
                            listError.Add("Row " + cont.ToString + ": the Employee and Employee Number were not select.")
                        Else
                            listError.Add("Row " + cont.ToString + ": the Employee was not Found.")
                        End If
                    ElseIf flag4 = False Then 'Project
                        listError.Add("Row " + cont.ToString + ": the Project Number was not Found.")
                    ElseIf flag2 And flag3 And flag4 Then
                        Dim newId As Guid = Guid.NewGuid
                        textInsertExpUsed = textInsertExpUsed & newId.ToString & "," & validarFechaParaSQlDeExcel(perdiemSheet.Cells(cont, 3).text) & "," & perdiemSheet.Cells(cont, 7).text & "," & perdiemSheet.Cells(cont, 8).text & "," & idExpense & "," & idAux & "," & idEmployee & "," & idHrsW & "," & dayInserted & vbCrLf
                        'tblPerdiem.Rows.Add("", perdiemSheet.Cells(cont, 3).Text, perdiemSheet.Cells(cont, 7).Text, perdiemSheet.Cells(cont, 8).Text, idExpense, idAux, idEmployee)
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
                    txtSalidaPerdiem.Text = txtSalidaPerdiem.Text + vbCrLf + "Starting process to insert..."
                    If Not IO.Directory.Exists("C:\TMP") Then
                        My.Computer.FileSystem.CreateDirectory("C:\TMP")
                    End If
                    My.Computer.FileSystem.WriteAllText("C:\TMP\Perdiem.csv", textInsertExpUsed, False)
                    If flagContinue Then
                        If mtdHPW.execBulkInsertRecordsPerdiem() Then
                            txtSalidaPerdiem.Text = txtSalidaPerdiem.Text & vbCrLf & "The Process Records Insertion is over."
                        Else
                            txtSalidaPerdiem.Text = txtSalidaPerdiem.Text & vbCrLf & "The Process Records Insertion has a problem."
                        End If
                    End If
                    'Dim contRowsError As Integer = 2
                    'For Each row As Data.DataRow In tblPerdiem.Rows()
                    '    Dim listEU As New List(Of String)
                    '    listEU.Add(row.ItemArray(0).ToString)
                    '    listEU.Add(row.ItemArray(1).ToString)
                    '    listEU.Add(row.ItemArray(2).ToString)
                    '    listEU.Add(row.ItemArray(3).ToString)
                    '    listEU.Add(row.ItemArray(4).ToString)
                    '    listEU.Add(row.ItemArray(5).ToString)
                    '    listEU.Add(row.ItemArray(6).ToString)
                    '    If Not mtdHPW.insertExpensesUsed(listEU) Then
                    '        listError.Add("Excel Row " + contRowsError.ToString() + ".")
                    '    End If
                    '    contRowsError += 1
                    'Next
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
                        MsgSalida(txtSalidaCSV, "Verifying if exist new Work Orders... ")
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
                            Dim rowsWorkOrder() As DataRow = tablaProject.Select("project = '" + row.ItemArray(3).ToString + "' and idPO = " + row.ItemArray(8).ToString + " and jobNo = " + row.ItemArray(9).ToString + "")
                            If rowsWorkOrder.Length = 0 Then
                                listNewWorkOrders.Add(row)
                            End If
                            'For Each row1 As DataRow In tablaProject.Rows()
                            '    Dim workOrder() As String = row1.ItemArray(1).ToString().Split("-")
                            '    If row.ItemArray(3).ToString().Equals(row1.ItemArray(1).ToString()) And row.ItemArray(8).ToString.Equals(row1.ItemArray(3).ToString()) And row.ItemArray(9).ToString.Equals(row1.ItemArray(4).ToString()) Then
                            '        flagExistWO = True
                            '        Exit For
                            '    Else
                            '        flagExistWO = False
                            '    End If
                            'Next
                            'If Not flagExistWO Then
                            '   listNewWorkOrders.Add(row)
                            'End If
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
                                    Dim listRows() As DataRow = tablaProject.Select("idWO = '" + newPO.idWorkOrder + "' and idPO = " + newPO.idPO.ToString() + " and jobNo = " + newPO.jobNum.ToString() + " ")
                                    If listRows.Length > 0 Then
                                        newPO.idAuxWO = listRows(0).ItemArray(5)
                                    Else
                                        newPO.idAuxWO = ""
                                    End If
                                    If mtdJobs.insertarNuevaTarea(newPO) = False Then
                                        mensaje = If(mensaje = "", item.ItemArray(0), mensaje + ", " + item.ItemArray(0))
                                    Else
                                        mtdHPW.llenarTablaProyecto(tablaProject)
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
                            Dim textDoc As String = "idHWTMP,hoursST,hoursOT,hours3T,dateWorked,idEmployee,idWorkCode,idAux,schedule,jobNo,dayInserted" & vbCrLf
                            Dim listErrors As New List(Of String)
                            Dim msgAux As String = txtSalidaCSV.Text + vbCrLf
                            Dim tblErrors As New Data.DataTable
                            Dim dateInserted As String = validaFechaParaSQl(Date.Today)
                            Dim clms() As String = {"EmployeeName", "EmployeeNum", "DateWork", "WorkOrder", "PO", "Code", "HST", "HOT", "Shift", "Description"}
                            For Each clm As String In clms
                                tblErrors.Columns.Add(clm)
                            Next
                            While CStr(records.Cells(contRecord, 2).Value) <> ""
                                'Dim rowP As Data.DataRow = tblProjects.Rows.Cast(Of Data.DataRow).FirstOrDefault(Function(x) CStr(x.ItemArray(0)) = records.Cells(contRecord, 4).value)
                                Dim rowE() As Data.DataRow = tblEmp.Select("numberEmploye = " + CStr(records.Cells(contRecord, 2).value) + "") 'Buscando idEmployee
                                Dim dateRecord As String = validarFechaParaSQlDeExcel(records.Cells(contRecord, 3).Text)
                                Dim rowP() As Data.DataRow = tblProjects.Select("worknum = '" + CStr(records.Cells(contRecord, 4).value) + "' AND idPO = " + CStr(records.Cells(contRecord, 5).value) + "") 'Buscado task 

                                Dim newidRecord As Guid = Guid.NewGuid()

                                Dim hst As String = If(CStr(records.Cells(contRecord, 7).value) = "", "0", CStr(records.Cells(contRecord, 7).value))
                                Dim hot As String = If(CStr(records.Cells(contRecord, 8).value) = "", "0", CStr(records.Cells(contRecord, 8).value))
                                Dim schedule As String = If(records.Cells(contRecord, 9).value = "Day" Or records.Cells(contRecord, 9).value = "DAYS", "DAY", "NIGTHS")
                                If rowP.Length > 0 Then
                                    If rowE.Length > 0 Then
                                        'Buscando idWorkCode
                                        Dim rowWC() As Data.DataRow = tblWC.Select("name = '" + CStr(records.Cells(contRecord, 6).value) + "' and jobNo = " + rowP(0).ItemArray(6).ToString() + "")
                                        If rowWC.Length > 0 Then
                                            textDoc += newidRecord.ToString() & "," & hst & "," & hot & "," & "0" & "," & dateRecord & "," & CStr(rowE(0).ItemArray(2)) & "," & CStr(rowWC(0).ItemArray(0)) & "," & rowP(0).ItemArray(2) & "," & schedule & "," & rowP(0).ItemArray(6).ToString() & "," & dateInserted & vbCrLf
                                        Else
                                            'tratando de insertar el nuevo work code
                                            listErrors.Add("Row " + CStr(contRecord) + ": Work Code Not found Error.")
                                            If DialogResult.Yes = MessageBox.Show("The Work Code " + CStr(records.Cells(contRecord, 6).value) + " is not enabled, Would you like to add the WorkCode?", "Advertence", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                                rowWC = tblWC.Select("name = '" + CStr(records.Cells(contRecord, 6).value) + "'")
                                                Dim wcDatos(8) As String
                                                If rowWC.Length > 0 Then
                                                    wcDatos(0) = rowWC(0).ItemArray(0)
                                                    wcDatos(1) = rowWC(0).ItemArray(1)
                                                    wcDatos(2) = rowWC(0).ItemArray(2)
                                                    wcDatos(3) = "0.00"
                                                    wcDatos(4) = "0.00"
                                                    wcDatos(5) = "0.00"
                                                    wcDatos(6) = rowWC(0).ItemArray(5)
                                                    wcDatos(7) = rowWC(0).ItemArray(6)
                                                    wcDatos(8) = rowP(0).ItemArray(6).ToString()
                                                Else
                                                    wcDatos = {If(rowWC.Length = 0, "(isnull((select MAX(idWorkCode)+1 from workCode where jobNo = " + rowP(0).ItemArray(6).ToString() + "),0))", rowWC(rowWC.Length - 1).ItemArray(0).ToString()), CStr(records.Cells(contRecord, 6).value), "", "0.00", "0.00", "0.00", "", "", rowP(0).ItemArray(6).ToString()}
                                                End If
                                                If mtdJobs.nuevaWC(wcDatos) Then
                                                    tblWC = mtdHPW.lllenarTablaWorkCodes()
                                                    rowWC = tblWC.Select("name = '" + CStr(records.Cells(contRecord, 6).value) + "' and jobNo = " + rowP(0).ItemArray(6).ToString() + "")
                                                    If rowWC.Length > 0 Then
                                                        textDoc += newidRecord.ToString() & "," & hst & "," & hot & "," & "0" & "," & dateRecord & "," & CStr(rowE(0).ItemArray(2)) & "," & CStr(rowWC(0).ItemArray(0)) & "," & rowP(0).ItemArray(2) & "," & schedule & "," & rowP(0).ItemArray(6).ToString() & "," & dateInserted & vbCrLf
                                                    Else
                                                        MessageBox.Show("Was not posible to inseter the Work Code " + CStr(records.Cells(contRecord, 6).value) + ", Please try to insert it at another time.")
                                                        'tblErrors.Rows.Add("The Error is on the Work Code", newidRecord, rowE(0), rowE(1), dateRecord, rowP(0).ItemArray(3).ToString(), rowP(0).ItemArray(1).ToString(), rowP(0).ItemArray(4).ToString(), records.Cells(contRecord, 6).value, hst, hst, schedule, rowP(0).ItemArray(5).ToString())
                                                        tblErrors.Rows.Add(records.Cells(contRecord, 1).value, records.Cells(contRecord, 2).value, records.Cells(contRecord, 3).value, records.Cells(contRecord, 4).value, records.Cells(contRecord, 5).value, records.Cells(contRecord, 6).value, records.Cells(contRecord, 7).value, records.Cells(contRecord, 8).value, records.Cells(contRecord, 9).value, records.Cells(contRecord, 10).value)
                                                    End If
                                                Else
                                                    MessageBox.Show("Was not posible to inseter the Work Code " + CStr(records.Cells(contRecord, 6).value) + ", Please try to insert it at another time.")
                                                    'tblErrors.Rows.Add("The Error is on the Work Code", newidRecord, rowE(0), rowE(1), dateRecord, rowP(0).ItemArray(3).ToString(), rowP(0).ItemArray(1).ToString(), rowP(0).ItemArray(4).ToString(), records.Cells(contRecord, 6).value, hst, hst, schedule, rowP(0).ItemArray(5).ToString())
                                                    tblErrors.Rows.Add(records.Cells(contRecord, 1).value, records.Cells(contRecord, 2).value, records.Cells(contRecord, 3).value, records.Cells(contRecord, 4).value, records.Cells(contRecord, 5).value, records.Cells(contRecord, 6).value, records.Cells(contRecord, 7).value, records.Cells(contRecord, 8).value, records.Cells(contRecord, 9).value, records.Cells(contRecord, 10).value)
                                                End If
                                            Else
                                                tblErrors.Rows.Add(records.Cells(contRecord, 1).value, records.Cells(contRecord, 2).value, records.Cells(contRecord, 3).value, records.Cells(contRecord, 4).value, records.Cells(contRecord, 5).value, records.Cells(contRecord, 6).value, records.Cells(contRecord, 7).value, records.Cells(contRecord, 8).value, records.Cells(contRecord, 9).value, records.Cells(contRecord, 10).value)
                                            End If
                                        End If
                                    Else
                                        listErrors.Add("Row " + CStr(contRecord) + ": Number Employee Error.")
                                        'tblErrors.Rows.Add("The Employee was not found", newidRecord, records.Cells(contRecord, 0).value, records.Cells(contRecord, 1).value, dateRecord, rowP(0).ItemArray(3).ToString(), rowP(0).ItemArray(1).ToString(), rowP(0).ItemArray(4).ToString(), records.Cells(contRecord, 6).value, hst, hst, schedule, rowP(0).ItemArray(5).ToString())
                                        tblErrors.Rows.Add(records.Cells(contRecord, 1).value, records.Cells(contRecord, 2).value, records.Cells(contRecord, 3).value, records.Cells(contRecord, 4).value, records.Cells(contRecord, 5).value, records.Cells(contRecord, 6).value, records.Cells(contRecord, 7).value, records.Cells(contRecord, 8).value, records.Cells(contRecord, 9).value, records.Cells(contRecord, 10).value)
                                    End If
                                Else
                                    listErrors.Add("Row " + CStr(contRecord) + ": Work Order Error.")
                                    Dim po() As String = records.Cells(contRecord, 4).value.ToString.Split("-")
                                    'tblErrors.Rows.Add("The Employee was not found", newidRecord, records.Cells(contRecord, 0).value, records.Cells(contRecord, 1).value, dateRecord, If(po.Length = 2, po(0), ""), If(po.Length = 2, po(1), ""), records.Cells(contRecord, 5).value, records.Cells(contRecord, 6).value, hst, hst, schedule, "")
                                    tblErrors.Rows.Add(records.Cells(contRecord, 1).value, records.Cells(contRecord, 2).value, records.Cells(contRecord, 3).value, records.Cells(contRecord, 4).value, records.Cells(contRecord, 5).value, records.Cells(contRecord, 6).value, records.Cells(contRecord, 7).value, records.Cells(contRecord, 8).value, records.Cells(contRecord, 9).value, records.Cells(contRecord, 10).value)
                                End If
                                txtSalidaCSV.Text = msgAux + "Reading Excel Row: " + contRecord.ToString()
                                txtSalidaCSV.Select(txtSalidaCSV.Text.Length, 0)
                                txtSalidaCSV.ScrollToCaret()
                                contRecord += 1
                            End While
                            Dim flagConitnue As Boolean = True
                            If listErrors.Count > 0 Then
                                MsgSalida(txtSalidaCSV, "List Error :")
                                For Each item As String In listErrors
                                    MsgSalida(txtSalidaCSV, item)
                                Next
                                If DialogResult.Yes = MessageBox.Show("Erros was found, would you like to correct the mistakes?, if you deny, just the correct records will goin to insert.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) Then
                                    flagConitnue = True
                                Else
                                    flagConitnue = False
                                End If
                                If flagConitnue Then
                                    If tblErrors.Rows.Count > 0 Then
                                        Dim vts As New ValidarTimeSheet
                                        AddOwnedForm(vts)
                                        vts.Errors = tblErrors
                                        vts.ShowDialog()
                                        If flagErrorContinue Then
                                            textDoc = textDoc & correctionString
                                        End If
                                    End If
                                End If
                            End If
                            If Not IO.Directory.Exists("C:\TMP") Then
                                My.Computer.FileSystem.CreateDirectory("C:\TMP")
                            End If
                            Dim Write As New System.IO.StreamWriter("C:\TMP\TimeSheetTemp.csv")
                            Write.WriteLine(textDoc)
                            Write.Close()
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