Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Data.DataTable
Public Class TimeSheet
    Dim mtdEmployees As New MetodosEmployees
    Dim mtdHPW As New MetodosHoursPeerWeek
    Dim mtdJobs As New MetodosJobs
    Public tablaWorkCodes As New Data.DataTable
    Public tablaProject As New Data.DataTable
    Public tablaEmpleadosId As New Data.DataTable
    Private Sub TimeSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdHPW.llenarTablaWorkCode(tablaWorkCodes)
        mtdHPW.llenarTablaProyecto(tablaProject)
    End Sub

    Private Sub btnDownloadExcel_Click(sender As Object, e As EventArgs) Handles btnDownloadExcel.Click
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "Time Sheet"
            openFile.ShowDialog()
            txtSalida.Text = txtSalida.Text + vbCrLf + "Open file " + openFile.FileName
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim sheetWorkCodes As New Worksheet
            Try
                sheetWorkCodes = libro.Worksheets("WorkOrder")
                txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'WorkOrder.'"
            Catch ex As Exception
                sheetWorkCodes = libro.Worksheets("Work Order")
                txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Work Order.'"
            End Try
            Dim tablaWorkCodes = mtdHPW.selectWOTimeSheet()
            limpiarSheet(sheetWorkCodes, 2)
            If tablaWorkCodes IsNot Nothing And tablaWorkCodes.Rows.Count > 0 Then
                Dim cont As Integer = 2
                txtSalida.Text = txtSalida.Text + vbCrLf + tablaWorkCodes.Rows().Count.ToString() + " rows."
                For Each row As DataRow In tablaWorkCodes.Rows()
                    txtSalida.Text = txtSalida.Text + vbCrLf + "Reading row " + cont.ToString()
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
            txtSalida.Text = txtSalida.Text + vbCrLf + "Saving file."
            libro.Save()
            NAR(sheetWorkCodes)
            libro.Close(True)
            NAR(libro)
            NAR(ApExcel.Workbooks)
            ApExcel.Quit()
            NAR(ApExcel)
            txtSalida.Text = txtSalida.Text + vbCrLf + "Sleeping..."
            System.Threading.Thread.Sleep(5000)
            txtSalida.Text = txtSalida.Text + vbCrLf + "End Excel"
        Catch ex As Exception
            MsgBox(ex.Message())
            txtSalida.Text = txtSalida.Text + vbCrLf + "Error. " + ex.Message()
        End Try
    End Sub

    Private Sub btnUploadRecords_Click(sender As Object, e As EventArgs) Handles btnUploadRecords.Click
        Try
            '======================================== INSERTAR WORKCODES ==================================================
            mtdHPW.llenarTablaProyecto(tablaProject)
            txtSalida.Text = ""
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "Daily Time Sheet"
            openFile.ShowDialog()
            txtSalida.Text = txtSalida.Text + vbCrLf + "Open file " + openFile.FileName
            Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim workOrders As New Worksheet
            Try
                workOrders = libro.Worksheets("Work Order")
                txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'Work Order.'"
            Catch ex As Exception
                workOrders = libro.Worksheets("WorkOrder")
                txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet 'WorkOrder.'"
            End Try
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
            While workOrders.Cells(contwo, 2).Text <> ""
                Dim wo = workOrders.Cells(contwo, 2).Text.ToString().Replace(" ", "-")
                Dim workOrder() As String = wo.Split("-") 'workOrder y task
                tablaWO.Rows.Add(contwo - 1.ToString(), workOrder(0), workOrder(1), workOrders.Cells(contwo, 2).Text, workOrders.Cells(contwo, 3).Text, workOrders.Cells(contwo, 5).Text, workOrders.Cells(contwo, 6).Text, workOrders.Cells(contwo, 7).Text, workOrders.Cells(contwo, 8).Text, workOrders.Cells(contwo, 9).Text)
                contwo += 1
            End While
            Dim listNewWorlOrders As New List(Of Data.DataRow)
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
                    listNewWorlOrders.Add(row)
                End If
            Next
            If listNewWorlOrders.Count > 0 Then
                txtSalida.Text = txtSalida.Text + vbCrLf + listNewWorlOrders.Count.ToString() + " New 'Work Codes', trying to insert the new 'Work Orders'."
                If DialogResult.Yes = MessageBox.Show("New 'Work Orders' found. Would you like to insert the new 'Work Orders'?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
                    For Each item As DataRow In listNewWorlOrders
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
                            mensaje = mensaje + " " + item.ItemArray(0)
                        End If
                    Next
                    txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Work Order' insertion process is over."
                End If
            Else
                txtSalida.Text = txtSalida.Text + vbCrLf + listNewWorlOrders.Count.ToString() + " Work Codes News."
            End If
            Dim insertar As Boolean = True
            If mensaje <> "" Then
                If DialogResult.Yes = MessageBox.Show("Error at line (" + mensaje + "), Would you like to cotinue?" + vbCrLf + "You probably won't be able to insert the records if you continue.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                    insertar = True
                Else
                    insertar = False
                End If
            End If
            NAR(workOrders)
            libro.Close(False)
            NAR(libro)
            mtdHPW.llenarTablaProyecto(tablaProject)
            '======================================== INSERTAR RECORDS ==================================================
            If DialogResult.Yes = MessageBox.Show("Would you like to start the insertion Records Proccess?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim ApExcel1 = New Microsoft.Office.Interop.Excel.Application
                Dim libro1 = ApExcel1.Workbooks.Open(openFile.FileName)
                If insertar Then
                    Dim timesheet As New Worksheet
                    Try
                        timesheet = libro1.Worksheets("Time Sheet")
                        txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet Time Sheet"
                    Catch ex As Exception
                        timesheet = libro1.Worksheets("TimeSheet")
                        txtSalida.Text = txtSalida.Text + vbCrLf + "Open sheet TimeSheet"
                    End Try
                    Dim list As New List(Of String)
                    Dim cont As Integer = 2
                    Dim filasError1 As String = ""
                    Dim text = txtSalida.Text
                    While timesheet.Cells(cont, 1).Text <> ""
                        list.Clear()
                        txtSalida.Text = text + "Insert line " + cont.ToString()
                        list.Add("") 'idHoursWorked
                        list.Add(timesheet.Cells(cont, 7).Text) 'hours ST
                        list.Add(timesheet.Cells(cont, 8).Text) 'hours OT
                        list.Add(0) 'hours 3
                        list.Add(validarFechaParaSQlDeExcel(timesheet.Cells(cont, 3).Text)) 'date
                        For Each row As DataRow In tablaEmpleadosId.Rows
                            If row.ItemArray(4) = timesheet.Cells(cont, 2).Text Then 'idEmpleado
                                list.Add(row.ItemArray(0))
                                Exit For
                            End If
                        Next
                        If list.Count = 6 Then ' validando que se encotro el idEmpleado
                            For Each row As DataRow In tablaWorkCodes.Rows
                                If row.ItemArray(1) = timesheet.Cells(cont, 6).Text Then 'WorkCode
                                    list.Add(row.ItemArray(0))
                                    Exit For
                                End If
                            Next
                            If list.Count = 7 Then ' validando que se encotro el workCode
                                For Each row As DataRow In tablaProject.Rows
                                    If row.ItemArray(1) = timesheet.Cells(cont, 4).Text And timesheet.Cells(cont, 5).Text = row.ItemArray(3) Then 'idtask
                                        list.Add(row.ItemArray(0)) '
                                        Exit For

                                    End If
                                Next
                                If list.Count = 8 Then ' validando que se encotro el task
                                    list.Add(timesheet.Cells(cont, 9).Text) 'Shift
                                    If mtdHPW.InsertarRecord(list) Then
                                        cont += 1
                                    Else
                                        filasError1 = filasError1 + " " + cont
                                        cont += 1
                                    End If
                                Else
                                    txtSalida.Text = txtSalida.Text + vbCrLf + "Error at line(" + cont.ToString() + "), Could not insert the Record."
                                    filasError1 = filasError1 + " " + cont
                                    cont += 1
                                End If
                            Else
                                txtSalida.Text = txtSalida.Text + vbCrLf + "Error at line(" + cont.ToString() + "), Could not find the ''."
                                filasError1 = filasError1 + " " + cont
                                cont += 1
                            End If
                        Else
                            txtSalida.Text = txtSalida.Text + vbCrLf + "Error at line(" + cont.ToString() + "), Could not find the 'Employee ID'."
                            filasError1 = filasError1 + " " + cont
                            cont += 1
                        End If
                    End While
                    If filasError1 <> "" Then
                        txtSalida.Text = txtSalida.Text + vbCrLf + "Error at line(" + filasError + ")"
                    End If
                    txtSalida.Text = txtSalida.Text + vbCrLf + "The 'Records Employee Time' insertion process is over."
                End If
                txtSalida.Text = txtSalida.Text + vbCrLf + "Closing Excel..."
                libro1.Close(False)
                NAR(libro1)
            End If
            ApExcel.Quit()
            NAR(ApExcel)
            txtSalida.Text = txtSalida.Text + vbCrLf + "Sleeping..."
            System.Threading.Thread.Sleep(5000)
            txtSalida.Text = txtSalida.Text + vbCrLf + "End Excel"
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        mtdHPW.llenarTablaProyecto(tablaProject)
    End Sub

End Class