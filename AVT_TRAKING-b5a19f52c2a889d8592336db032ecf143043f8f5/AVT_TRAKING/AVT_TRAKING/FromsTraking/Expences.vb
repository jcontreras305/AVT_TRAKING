Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Expences
    Dim mtdConn As New ConnectioDB
    Dim mtdJobs As MetodosJobs = New MetodosJobs()
    Dim idExpenceActualizar As String

    Private Sub Expences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdJobs.buscarExpenses(tblExpenses)
        limpiarCampos()
        activarCampos(False)
        btnUbdate.Enabled = False
        btnCancel.Enabled = False
        llenarComboClientByUser(cmbClient)
        llenarComboClientByUser(cmbFindExpJob)
        'llenarComboClientsReports(cmbClient)
        'llenarComboClientsReports(cmbFindExpJob)
        activarCamposExpJob(False)
        btnUpdateExpJob.Enabled = False
        btnCancelExpJob.Enabled = False
        mtdJobs.llenarComboExpenses(cmbExpense)
        mtdJobs.selectExpensesByClient(tblExpensesJobs)
    End Sub
    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs)
        Me.Close()
        ' Me.Finalize()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Add" Then
            btnSave.Text = "Save"
            btnCancel.Enabled = True
            btnUbdate.Enabled = False
            activarCampos(True)
            limpiarCampos()
        Else
            mtdJobs.insertExpence(txtExpenceCode.Text, txtDescription.Text)
            limpiarCampos()
            activarCampos(False)
            mtdJobs.buscarExpenses(tblExpenses)
            btnSave.Text = "Add"
            btnUbdate.Enabled = False
            btnCancel.Enabled = False
        End If

    End Sub

    Private Sub activarCampos(ByVal flag As Boolean)
        If flag Then
            txtDescription.Enabled = True
            txtExpenceCode.Enabled = True
        Else
            txtDescription.Enabled = False
            txtExpenceCode.Enabled = False
        End If


    End Sub

    Private Sub limpiarCampos()
        txtDescription.Text = ""
        txtExpenceCode.Text = ""
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If btnSave.Enabled = True Then
            If MessageBox.Show("Do you want to cancel this Expece?", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                limpiarCampos()
                activarCampos(False)
                btnCancel.Enabled = False
                btnSave.Text = "Add"
            End If

        Else
            If MessageBox.Show("Do you want to lost the changes of this Expece?", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                limpiarCampos()
                activarCampos(False)
                btnCancel.Enabled = False
                btnUbdate.Enabled = False
                btnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnUbdate_Click(sender As Object, e As EventArgs) Handles btnUbdate.Click
        mtdJobs.actualizarExpence(idExpenceActualizar, txtExpenceCode.Text, txtDescription.Text)
        btnSave.Enabled = True
        btnCancel.Enabled = False
        btnUbdate.Enabled = False
        limpiarCampos()
        mtdJobs.buscarExpenses(tblExpenses)
        activarCampos(False)
    End Sub

    Private Sub tblExpences_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblExpenses.CellMouseDoubleClick
        Try
            If tblExpenses.SelectedRows.Count() > 0 Then
                idExpenceActualizar = tblExpenses.CurrentRow.Cells(0).Value.ToString
                txtExpenceCode.Text = tblExpenses.CurrentRow.Cells(1).Value.ToString
                txtDescription.Text = tblExpenses.CurrentRow.Cells(2).Value.ToString
                btnUbdate.Enabled = True
                btnCancel.Enabled = True
                btnSave.Enabled = False
                activarCampos(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            If txtFind.Text = "" Then
                mtdJobs.buscarExpenses(tblExpenses)
            Else
                mtdJobs.buscarExpenses(tblExpenses, txtFind.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
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

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub cmbFindExpJob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFindExpJob.SelectedIndexChanged
        Try
            Dim array() As String = cmbFindExpJob.Items(cmbFindExpJob.SelectedIndex).ToString.Split(" ")
            If array.Length > 0 Then
                mtdJobs.selectExpensesByClient(tblExpensesJobs, array(0))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        Try
            If cmbClient.SelectedIndex >= 0 Then
                Dim array() As String = cmbClient.Items(cmbClient.SelectedIndex).ToString.Split(" ")
                llenarComboJobsReports(cmbJobNo, array(0))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddExpJob_Click(sender As Object, e As EventArgs) Handles btnAddExpJob.Click
        If btnAddExpJob.Text = "Add" Then
            btnAddExpJob.Text = "Save"
            btnCancelExpJob.Enabled = True
            btnUpdateExpJob.Enabled = False
            activarCamposExpJob(True)
            limpiarCamposExpJob()
        Else
            Dim datos = recoletarDatosExpJob()
            If cmbJobNo.SelectedIndex > -1 And cmbClient.SelectedIndex > -1 Then
                If mtdJobs.insertarExpenseJob(cmbExpense.Items(cmbExpense.SelectedIndex), cmbJobNo.Items(cmbJobNo.SelectedIndex), datos) Then
                    activarCamposExpJob(False)
                    limpiarCamposExpJob()
                    If cmbFindExpJob.SelectedIndex > -1 Then
                        Dim array() As String = cmbFindExpJob.Items(cmbFindExpJob.SelectedIndex).ToString.Split(" ")
                        mtdJobs.selectExpensesByClient(tblExpenses, array(0))
                    Else
                        mtdJobs.selectExpensesByClient(tblExpenses)
                    End If

                    btnAddExpJob.Text = "Add"
                    btnUpdateExpJob.Enabled = False
                    btnCancelExpJob.Enabled = False
                End If
            Else
                MsgBox("Please check that the Job or the Expense was selected.")
            End If
        End If
    End Sub
    Private Function recoletarDatosExpJob() As String()
        Dim datos() As String = {"", "", "", "", "", "", "", ""}
        Try
            datos(0) = txtCategory.Text
            datos(1) = txtPayItemType.Text
            datos(2) = txtWorkType.Text
            datos(3) = txtCostCode.Text
            datos(4) = txtCustomerPositionID.Text
            datos(5) = txtCustumerPositionJobDescription.Text
            datos(6) = txtCBSFulNumber.Text
            datos(7) = txtSkillType.Text
            Return datos
        Catch ex As Exception
            Return datos
        End Try
    End Function

    Private Sub limpiarCamposExpJob()
        cmbJobNo.Text = ""
        cmbJobNo.SelectedIndex = -1
        cmbExpense.SelectedIndex = -1
        cmbClient.SelectedIndex = -1
        txtCategory.Text = ""
        txtPayItemType.Text = ""
        txtWorkType.Text = ""
        txtCostCode.Text = ""
        txtCustomerPositionID.Text = ""
        txtCustumerPositionJobDescription.Text = ""
        txtCBSFulNumber.Text = ""
        txtSkillType.Text = ""
    End Sub

    Private Sub activarCamposExpJob(ByVal enable As Boolean)
        Try
            If cmbClient.Items IsNot Nothing Then
                cmbClient.SelectedIndex = -1
                cmbJobNo.Items.Clear()
            End If
            If cmbExpense.Items IsNot Nothing Then
                cmbExpense.SelectedIndex = -1
            End If
            cmbClient.Enabled = enable
            cmbJobNo.Enabled = enable
            cmbExpense.Enabled = enable
            txtCategory.Enabled = enable
            txtPayItemType.Enabled = enable
            txtWorkType.Enabled = enable
            txtCostCode.Enabled = enable
            txtCustomerPositionID.Enabled = enable
            txtCustumerPositionJobDescription.Enabled = enable
            txtCBSFulNumber.Enabled = enable
            txtSkillType.Enabled = enable
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelExpJob_Click(sender As Object, e As EventArgs) Handles btnCancelExpJob.Click
        If btnAddExpJob.Enabled = True Then
            If MessageBox.Show("Do you want to cancel this Expece ?", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                limpiarCamposExpJob()
                activarCamposExpJob(False)
                btnCancelExpJob.Enabled = False
                btnAddExpJob.Text = "Add"
            End If
        Else
            If MessageBox.Show("Do you want to lost the changes of this Expece?", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                limpiarCamposExpJob()
                activarCamposExpJob(False)
                btnCancelExpJob.Enabled = False
                btnUpdateExpJob.Enabled = False
                btnAddExpJob.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnUpdateExpJob_Click(sender As Object, e As EventArgs) Handles btnUpdateExpJob.Click
        Dim datos() As String = recoletarDatosExpJob()
        mtdJobs.updateExpenseJob(cmbExpense.Text, cmbJobNo.Text, datos, tblExpensesJobs.CurrentRow.Cells("Cost Code").Value, tblExpensesJobs.CurrentRow.Cells("CBS Full Number").Value,)
        btnAddExpJob.Enabled = True
        btnCancelExpJob.Enabled = False
        btnUpdateExpJob.Enabled = False
        limpiarCamposExpJob()
        If cmbFindExpJob.SelectedIndex > -1 Then
            Dim array() As String = cmbFindExpJob.Items(cmbFindExpJob.SelectedIndex).ToString.Split(" ")
            If array.Length > 0 Then
                mtdJobs.selectExpensesByClient(tblExpensesJobs, array(0))
            Else
                mtdJobs.selectExpensesByClient(tblExpensesJobs)
            End If
        End If
        activarCampos(False)
    End Sub

    Private Sub tblExpensesJobs_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tblExpensesJobs.MouseDoubleClick
        activarCamposExpJob(True)
        For Each cl As String In cmbClient.Items
            Dim array() = cl.Split(" ")
            If array(0) = tblExpensesJobs.CurrentRow.Cells("numberClient").Value.ToString() Then
                cmbClient.SelectedIndex = cmbClient.FindStringExact(cl)
                Exit For
            End If
        Next
        For Each jb As String In cmbJobNo.Items
            If jb = tblExpensesJobs.CurrentRow.Cells("jobNo").Value.ToString() Then
                cmbJobNo.SelectedIndex = cmbJobNo.FindStringExact(jb)
                Exit For
            End If
        Next
        If cmbExpense.Items IsNot Nothing Then
            cmbExpense.SelectedIndex = cmbExpense.FindStringExact(tblExpensesJobs.CurrentRow.Cells("Expense").Value)
        End If
        txtCategory.Text = tblExpensesJobs.CurrentRow.Cells("Category").Value
        txtPayItemType.Text = tblExpensesJobs.CurrentRow.Cells("Pay Item Type").Value
        txtWorkType.Text = tblExpensesJobs.CurrentRow.Cells("Work Type").Value
        txtCostCode.Text = tblExpensesJobs.CurrentRow.Cells("Cost Code").Value
        txtCustomerPositionID.Text = tblExpensesJobs.CurrentRow.Cells("Customer Postion ID").Value
        txtCustumerPositionJobDescription.Text = tblExpensesJobs.CurrentRow.Cells("Customer Job Position Description").Value
        txtCBSFulNumber.Text = tblExpensesJobs.CurrentRow.Cells("CBS Full Number").Value
        txtSkillType.Text = tblExpensesJobs.CurrentRow.Cells("Skill Type").Value
        btnAddExpJob.Enabled = False
        btnUpdateExpJob.Enabled = True
        btnCancelExpJob.Enabled = True

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim tran As SqlTransaction
            mtdConn.conectar()
            tran = mtdConn.conn.BeginTransaction
            Dim flag As Boolean = False
            Dim expAux As String = ""
            For Each row As DataGridViewRow In tblExpensesJobs.SelectedRows
                If mtdJobs.deleteExpenseJob(row.Cells("Expense").Value, row.Cells("jobNo").Value, tran, mtdConn.conn) Then
                    flag = False
                Else
                    flag = True
                    expAux = row.Cells("Expense").Value & " | " & row.Cells("jobNo").Value
                End If
            Next
            If flag Then
                tran.Rollback()
                MsgBox("Is not posible to delete the Expenses selected." + vbCrLf + "Error in " + expAux)
            Else
                tran.Commit()
                MsgBox("Successful")
                If cmbFindExpJob.SelectedIndex > -1 Then
                    Dim array() As String = cmbFindExpJob.Items(cmbFindExpJob.SelectedIndex).ToString.Split(" ")
                    mtdJobs.selectExpensesByClient(tblExpensesJobs, array(0))
                Else
                    mtdJobs.selectExpensesByClient(tblExpensesJobs)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            mtdConn.desconectar()
        End Try
    End Sub

    Private Sub btnExcelUpdate_Click(sender As Object, e As EventArgs) Handles btnExcelUpdate.Click
        Dim ruta As String = ""
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Dim libro = ApExcel.Workbooks.Add()
        Dim flagOpen As Boolean = False
        Try
            Dim Hoja1 = libro.Worksheets(1)
            Dim count As Integer = 1
            With Hoja1.Range("A1:J1")
                .Font.Bold = True
                .Font.ColorIndex = 1
                With .Interior
                    .ColorIndex = 15
                End With
                .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
            End With
            Dim countColum As Integer = 1
            Dim arClms() As String = {"ExpenseCode", "jobNo", "Category", "PayItemType", "WorkType", "CostCode", "CustomerPositionID", "CustomerJobPositionDescription", "CBSFullNumber", "SkillType"}

            For Each clm As String In arClms
                Hoja1.Cells(count, countColum) = clm
                countColum += 1
            Next
            Hoja1.Cells(count, countColum) = "Notes"
            count += 1
            Hoja1.Name = "ExpensesByJobs"
            Dim opFile As New SaveFileDialog
            opFile.DefaultExt = "xlsx"
            opFile.FileName = "Expenses_By_Jobs"
            If DialogResult.OK = opFile.ShowDialog() Then
                ruta = opFile.FileName
                libro.SaveAs(opFile.FileName)
                MsgBox("Successful")
                NAR(Hoja1)
                If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    flagOpen = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            libro.Close()
            NAR(libro)
            ApExcel.Quit()
            NAR(ApExcel)
            If flagOpen Then
                System.Diagnostics.Process.Start(ruta)
            End If
        End Try
    End Sub

    Private Sub btnExcelDownload_Click(sender As Object, e As EventArgs) Handles btnExcelDownload.Click
        Try
            Dim pgb As New ProgressBar
            Dim tbl As DataTable = leerExcel(Label15, pgb, "ExpensesByJobs")
            If tbl.Rows IsNot Nothing Then
                mtdConn.conectar()
                Dim connecion As SqlConnection = mtdConn.conn
                Dim tran As SqlTransaction
                Dim flag As Boolean = False
                Dim expAux As String = ""
                tran = connecion.BeginTransaction
                For Each row As DataRow In tbl.Rows
                    Dim expCode As String = row.ItemArray(0)
                    Dim jobNo As String = row.ItemArray(1)
                    Dim datos() As String = {row.ItemArray(2), row.ItemArray(3), row.ItemArray(4), row.ItemArray(5), row.ItemArray(6), row.ItemArray(7), row.ItemArray(8), row.ItemArray(9)}
                    If mtdJobs.insertarExpenseJob(expCode, jobNo, datos, tran, connecion) Then
                        flag = True
                    Else
                        flag = False
                        expAux = expCode & " | " & jobNo
                        Exit For
                    End If
                Next
                If flag Then
                    tran.Commit()
                    MsgBox("Successfull.")
                Else
                    tran.Rollback()
                    MsgBox("Is not posible to insert the Expenses. The Error was in the expense " & expAux & ".")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
End Class