Imports System.Runtime.InteropServices
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class EquipmentValidation
    Dim con As New ConnectioDB
    Public idclient As String
    Dim mtdSC As New MetodosScaffold
    Dim mtdJobs As New MetodosJobs
    Dim tblProject As Data.DataTable
    Dim tblAllProject As New Data.DataTable
    Dim tblMaterial As Data.DataTable
    Public jobNo As String = ""
    Private Sub EquipmentValidation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbInformation.Location = New System.Drawing.Point(31, 43)
        dtpInformation.Location = New System.Drawing.Point(31, 43)
        tblMaterial = mtdJobs.llenarComboCellMaterial(cmbInformation)
        tblProject = mtdSC.llenarComboWO(cmbInformation, idclient, jobNo)
        mtdJobs.consultaJobs(tblAllProject)
        btnSave.Enabled = False
        lbljobNo.Text = "Job No: " + jobNo
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
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
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub tblEquipment_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles tblEquipment.CellEnter
        Select Case e.ColumnIndex
            Case tblEquipment.Columns("DateEquip").Index
                txtInformation.Visible = False
                dtpInformation.Visible = True
                cmbInformation.Visible = False
            Case tblEquipment.Columns("ProjectEquip").Index
                txtInformation.Visible = False
                dtpInformation.Visible = False
                cmbInformation.Visible = True
                cmbInformation.Items.Clear()
                cmbInformation.Text = ""
                tblProject = mtdSC.llenarComboWO(cmbInformation, idclient)
                cmbInformation.DropDownWidth = 330
            Case tblEquipment.Columns("MaterialCode").Index
                txtInformation.Visible = False
                dtpInformation.Visible = False
                cmbInformation.Visible = True
                cmbInformation.Items.Clear()
                cmbInformation.Text = ""
                tblMaterial = mtdJobs.llenarComboCellMaterial(cmbInformation)
                cmbInformation.DropDownWidth = 200
            Case tblEquipment.Columns("Amount").Index
                txtInformation.Visible = True
                dtpInformation.Visible = False
                cmbInformation.Visible = False
                txtInformation.Text = If(tblEquipment.CurrentCell.Value Is Nothing, "", tblEquipment.CurrentCell.Value.ToString())
            Case tblEquipment.Columns("Description").Index
                txtInformation.Visible = True
                dtpInformation.Visible = False
                cmbInformation.Visible = False
                txtInformation.Text = If(tblEquipment.CurrentCell.Value Is Nothing, "", tblEquipment.CurrentCell.Value.ToString())
            Case tblEquipment.Columns("STHrs").Index
                txtInformation.Visible = True
                dtpInformation.Visible = False
                cmbInformation.Visible = False
                txtInformation.Text = If(tblEquipment.CurrentCell.Value Is Nothing, "", tblEquipment.CurrentCell.Value.ToString())
        End Select
    End Sub
    Private Sub txtInformation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInformation.KeyPress
        If tblEquipment.CurrentCell IsNot Nothing Then
            Select Case tblEquipment.CurrentCell.ColumnIndex
                Case tblEquipment.Columns("Amount").Index
                    If Not (IsNumeric(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = vbBack Or e.KeyChar = vbCr) Then
                        e.Handled = True
                    End If
                Case tblEquipment.Columns("STHrs").Index
                    If Not (IsNumeric(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = vbBack Or e.KeyChar = vbCr) Then
                        e.Handled = True
                    End If
            End Select
        End If
    End Sub

    Private Sub txtInformation_TextChanged(sender As Object, e As EventArgs) Handles txtInformation.TextChanged
        If tblEquipment.CurrentCell.ColumnIndex <> tblEquipment.Columns("ClassEquip").Index Then
            tblEquipment.CurrentCell.Value = txtInformation.Text
        End If
    End Sub

    Private Sub cmbInformation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInformation.SelectedIndexChanged
        If tblEquipment.CurrentCell IsNot Nothing Then
            Select Case tblEquipment.CurrentCell.ColumnIndex
                Case tblEquipment.Columns("ProjectEquip").Index
                    If cmbInformation.SelectedItem IsNot Nothing Then
                        Dim array() As String = cmbInformation.SelectedItem.ToString.Split(" ")
                        Dim arrayWO() As String = array(0).ToString.Split("-")
                        Dim arrayRows() As DataRow = tblAllProject.Select("idWO like '" + arrayWO(0) + "' and task like '" + If(arrayWO.Length > 2, arrayWO(1) + "-" + arrayWO(2), arrayWO(1)) + "' and jobNo = " + array(1))
                        If arrayRows.Length > 0 Then
                            tblEquipment.CurrentCell.Value = arrayRows(0).ItemArray(3) + " " + arrayRows(0).ItemArray(4)
                            tblEquipment.CurrentRow.Cells("idAux").Value = arrayRows(0).ItemArray(5)
                            tblEquipment.CurrentRow.Cells("clmJobNo").Value = arrayRows(0).ItemArray(0).ToString()
                            tblEquipment.CurrentRow.DefaultCellStyle.BackColor = Color.White
                            tblEquipment.CurrentRow.Cells("ErrorClm").Value = ""
                            tblEquipment.Columns("ErrorClm").Visible = True
                        End If
                        'For Each row As Data.DataRow In tblProject.Rows
                        '    If array(0) = row.ItemArray(0) And array(1) = row.ItemArray(3) Then
                        '        tblEquipment.CurrentCell.Value = row(0) + " " + row(3)
                        '        tblEquipment.CurrentRow.Cells("idAux").Value = row(2)
                        '    End If
                        'Next
                    End If
                Case tblEquipment.Columns("MaterialCode").Index
                    If cmbInformation.SelectedItem IsNot Nothing Then
                        tblEquipment.CurrentCell.Value = cmbInformation.SelectedItem
                        Dim classMt() As String = cmbInformation.SelectedItem.ToString.Split(" ")
                        tblEquipment.Rows(tblEquipment.CurrentCell.RowIndex).Cells("ClassEquip").Value = classMt(0)
                    End If
            End Select
        End If
    End Sub

    Private Sub dtpInformation_ValueChanged(sender As Object, e As EventArgs) Handles dtpInformation.ValueChanged
        Dim dateVal As DateTime = dtpInformation.Value
        tblEquipment.CurrentCell.Value = dateVal.ToString("MM/dd/yyyy")
    End Sub
    Dim LoadingExcel As Boolean = False
    Private Sub btnUpdateMaterialExcel_Click(sender As Object, e As EventArgs) Handles btnUpdateMaterialExcel.Click
        Try
            Dim opFile As New OpenFileDialog()
            pgbComplete.Value = 0
            opFile.DefaultExt = "xlsx|xls"
            opFile.FileName = "Vehicle Tracker"
            lblMessage.Text = "Message: " + "Loading"
            If DialogResult.OK = opFile.ShowDialog() Then
                pgbComplete.Value = pgbComplete.Value + 5
                Cursor = Cursors.WaitCursor
                Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                lblMessage.Text = "Message: " + "Opening Document " + opFile.FileName
                Dim libro = ApExcel.Workbooks.Open(opFile.FileName)
                pgbComplete.Value = pgbComplete.Value + 5
                Try
                    Dim Hoja1 As New Worksheet
                    Dim sheetNumber1 As Integer = 1
                    Dim flagExist1 As Boolean = False
                    lblMessage.Text = "Message: " + "Verifying that the 'Upload' sheet exists..."
                    For Each sheet As Worksheet In libro.Worksheets
                        If sheet.Name = "Upload" Then
                            flagExist1 = True
                            Exit For
                        End If
                        sheetNumber1 += 1
                    Next
                    If flagExist1 Then
                        LoadingExcel = True
                        pgbComplete.Value = pgbComplete.Value + 10
                        tblEquipment.Rows.Clear()
                        Dim count As Integer = 2
                        Hoja1 = libro.Worksheets("Upload")
                        Dim numFilas = CInt(nreg(Hoja1, 2, 1))
                        Dim increment As Integer = 0
                        Dim everyIncrement As Integer = 0
                        If numFilas <= 75 Then
                            increment = CInt(75 / numFilas)
                            everyIncrement = 1
                        Else
                            increment = 1
                            everyIncrement = If(numFilas / 75 < 2, 1, CInt(numFilas / 75))
                        End If
                        Dim countRowsInc As Integer = 0
                        While Hoja1.Cells(count, 1).Text <> ""
                            Dim arrayDate() As String = Hoja1.Cells(count, 1).Text.split("/")
                            Dim dateStr As DateTime = New DateTime(CInt(arrayDate(2)), CInt(arrayDate(0)), CInt(arrayDate(1)))
                            tblEquipment.Rows.Add("", dateStr.ToString("MM/dd/yyyy"), Hoja1.Cells(count, 2).Text, "", Hoja1.Cells(count, 3).Text, Hoja1.Cells(count, 4).Text, Hoja1.Cells(count, 5).Text, Hoja1.Cells(count, 6).Text, Hoja1.Cells(count, 7).Text, Hoja1.Cells(count, 8).Text)
                            count += 1
                            lblMessage.Text = "Message: " + "Reading Row " + CStr(count)
                            countRowsInc += 1
                            If everyIncrement >= countRowsInc And pgbComplete.Value < 90 Then
                                pgbComplete.Value = pgbComplete.Value + increment
                                countRowsInc = 0
                            End If
                        End While
                        lblMessage.Text = "Message: " + " Data Validation..."
                        buscarIdAuxTable()
                        pgbComplete.Value = 94
                        'validarRepetidos()
                        pgbComplete.Value = 98
                        enumerarFilas()
                        If existError() Then
                            btnSave.Enabled = False
                        End If
                    Else
                        MessageBox.Show("Sheet Upload Not Found.", "Important")
                    End If
                    NAR(Hoja1)
                    lblMessage.Text = "Message: " + "Closing... "
                Catch ex As Exception
                    MessageBox.Show("Sheet Upload Not Found.", "Important")
                Finally
                    libro.Close()
                    NAR(libro)
                    ApExcel.Quit()
                    NAR(ApExcel)
                    pgbComplete.Value = 100
                    lblMessage.Text = "Message: " + "End."
                    LoadingExcel = False
                End Try
                Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub buscarIdAuxTable()
        For Each row As DataGridViewRow In tblEquipment.Rows()
            If Not row.IsNewRow Then
                Dim jobRow As String = row.Cells("clmJobNo").Value.ToString()
                Dim array() As String = row.Cells("ProjectEquip").Value.ToString().Split("-")
                Dim rows() As DataRow = tblAllProject.Select("idWO like '" + array(0) + "' " + If(array.Length > 2, " and task like '" + array(1) + "-" + array(2) + "'", " and task like '" + array(1) + "' ") + "  and jobNo = " + jobRow)
                If rows.Count > 0 Then
                    row.Cells("IdAux").Value = rows(0).ItemArray(5)
                Else
                    row.DefaultCellStyle.BackColor = Color.Yellow
                    row.Cells("ErrorClm").Value = "Project Not Found"
                    tblEquipment.Columns("ErrorClm").Visible = True
                End If
            End If
        Next
    End Sub

    Private Function validarRepetidos() As Boolean
        Try
            Dim flag As Boolean = False
            Dim contExist As Integer = 0
            For Each row As DataGridViewRow In tblEquipment.Rows()
                If Not row.IsNewRow Then
                    contExist = 0
                    For Each row1 As DataGridViewRow In tblEquipment.Rows()
                        If Not row.IsNewRow Then
                            If row.Cells("DateEquip").Value = row1.Cells("DateEquip").Value And row.Cells("idAux").Value = row1.Cells("idAux").Value And row.Cells("MaterialCode").Value = row1.Cells("MaterialCode").Value Then
                                contExist += 1
                                If contExist > 1 Then
                                    row.DefaultCellStyle.BackColor = Color.Yellow
                                    tblEquipment.Columns("ErrorClm").Visible = True
                                    row.Cells("ErrorClm").Value = If(row.Cells("ErrorClm").Value = "", "Reat.", row.Cells("ErrorClm").Value + ", Repeat.")
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Public Function validarFila(ByVal row As DataGridViewRow) As Boolean
        Try
            'LIMPIAMOS LA COLUMNA DE ERRORES
            row.DefaultCellStyle.BackColor = Color.White
            row.Cells("ErrorClm").Value = ""
            If Not existProjec(row) Then
                row.Cells("ErrorClm").Value = "Project Not Found"
            End If
            'VALIDAMOS QUE NO EXISTAN REPETIDOS
            'If validarRepetidos(row) Then
            '    row.Cells("ErrorClm").Value = If(row.Cells("ErrorClm").Value = "", "Repeat", row.Cells("ErrorClm").Value + ", Repeat")

            'End If

            If row.Cells("ErrorClm").Value <> "" Then
                row.DefaultCellStyle.BackColor = Color.Yellow
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validarRepetidos(ByVal row As DataGridViewRow) As Boolean
        Dim isRepeat As Boolean = False
        Dim contExist As Integer = 0
        If tblEquipment.Rows.Count() > 1 Then
            For Each row1 As DataGridViewRow In tblEquipment.Rows()
                If Not row.IsNewRow Then
                    If row.Cells("DateEquip").Value = row1.Cells("DateEquip").Value And row.Cells("idAux").Value = row1.Cells("idAux").Value And row.Cells("MaterialCode").Value = row1.Cells("MaterialCode").Value Then
                        contExist += 1
                        If contExist > 1 Then
                            isRepeat = True
                        End If
                    End If
                End If
            Next
        End If
        Return isRepeat
    End Function
    Private Function existProjec(ByVal row As DataGridViewRow) As Boolean
        Try
            If row.Cells("ProjectEquip").Value IsNot Nothing Or row.Cells("ProjectEquip").Value <> "" Then
                Dim array() As String = row.Cells("ProjectEquip").Value.ToString().Split("-")
                Dim rows() As DataRow = tblAllProject.Select("idWO like '" + array(0) + "' " + If(array.Length > 2, " and task like '" + array(1) + "-" + array(2) + "'", " and task like '" + array(1) + "' ") + "  and jobNo = " + row.Cells("clmJobNo").Value)
                If rows.Count > 0 Then
                    row.Cells("IdAux").Value = rows(0).ItemArray(5)
                Else
                    row.DefaultCellStyle.BackColor = Color.Yellow
                    row.Cells("ErrorClm").Value = "Project Not Found"
                    tblEquipment.Columns("ErrorClm").Visible = True
                End If

                If rows.Count > 0 Then
                    row.Cells("IdAux").Value = rows(0).ItemArray(5)
                    Return True
                Else
                    row.Cells("IdAux").Value = ""
                    Return False
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Private Sub tblEquipment_CellLeave(sender As Object, e As EventArgs) Handles tblEquipment.CurrentCellChanged
        If LoadingExcel = False Then
            If tblEquipment.CurrentCell IsNot Nothing Then
                If Not validarFila(tblEquipment.Rows(tblEquipment.CurrentCell.RowIndex)) Then
                    tblEquipment.Columns("ErrorClm").Visible = True
                End If
                If Not existError() Then
                    btnSave.Enabled = True
                Else
                    btnSave.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Function existError() As Boolean
        Dim existErrorClm As Boolean = False
        For Each row As DataGridViewRow In tblEquipment.Rows
            If Not row.IsNewRow Then
                If Not (row.Cells("ErrorClm").Value = "") Then
                    existErrorClm = True
                    Exit For
                End If
            End If
        Next
        Return existErrorClm
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If DialogResult.OK = MessageBox.Show("Are you sure to save the records?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) Then
                pgbComplete.Value = 10
                Dim datosMaterial As New List(Of String)
                Dim message As String = ""
                Dim errorRow As Boolean = False
                'Dim tran As SqlTransaction
                'con.conectar()
                'tran = con.conn.BeginTransaction
                Dim flagContine As Boolean = False
                Dim flagCommit As Boolean = True
                Dim numFilas = tblEquipment.Rows.Count - 1
                Dim increment As Integer = 0
                Dim everyIncrement As Integer = 0
                If numFilas <= 75 Then
                    increment = CInt(75 / numFilas)
                    everyIncrement = 1
                Else
                    increment = 1
                    everyIncrement = If(numFilas / 75 < 2, 1, CInt(numFilas / 75))
                End If
                Dim countRowsInc As Integer = 0
                lblMessage.Text = "Message: Starting..."
                Dim txtDoc As String = "idMaterialUsed,dateMaterial,quantity,amount,description,IdAux,idMaterial,hoursST"
                Dim contRow As Integer = 1
                For Each row As DataGridViewRow In tblEquipment.SelectedRows()
                    lblMessage.Text = "Message: Reading Row (" & contRow & ")..."
                    contRow += 1
                    If Not row.IsNewRow Then
                        Dim newId As Guid = Guid.NewGuid
                        datosMaterial.Add(newId.ToString.ToUpper)
                        If row.Cells("DateEquip").Value <> "" Then
                            datosMaterial.Add(row.Cells("DateEquip").Value)
                        Else
                            errorRow = True
                        End If
                        If row.Cells("idAux").Value <> "" Then
                            datosMaterial.Add(row.Cells("idAux").Value)
                        Else
                            errorRow = True
                        End If
                        If row.Cells("Amount").Value <> "" Then
                            datosMaterial.Add(CStr(row.Cells("Amount").Value))
                        Else
                            errorRow = True
                        End If
                        If row.Cells("MaterialCode").Value <> "" Then
                            Dim array() As String = row.Cells("MaterialCode").Value.ToString.Split(" ")
                            'Dim arrayRow() As Data.DataRow = tblMaterial.Select("Class like '" + array(0) + "' and Name like '" + array(1) + "'")
                            Dim arrayRow() As Data.DataRow = tblMaterial.Select("Number = " + array(0) + "")
                            datosMaterial.Add(arrayRow(0).ItemArray(0))
                        Else
                            errorRow = True
                        End If
                        If row.Cells("STHrs").Value <> "" Then
                            datosMaterial.Add(CStr(row.Cells("STHrs").Value))
                        Else
                            datosMaterial.Add("0")
                        End If
                        If row.Cells("Description").Value <> "" Then
                            datosMaterial.Add(row.Cells("Description").Value)
                        Else
                            errorRow = True
                        End If
                        If Not errorRow Then
                            txtDoc = txtDoc & vbCrLf & datosMaterial(0) & "," & datosMaterial(1) & "," & "1" & "," & datosMaterial(3) & "," & datosMaterial(6) & "," & datosMaterial(2) & "," & datosMaterial(4) & "," & datosMaterial(5)
                            'insert into materialUsed values(NEWID(),'" + datos(1) + "',1," + datos(3) + ",'" + datos(6) + "','" + datos(2) + "','" + datos(4) + "'," + datos(5) + ")"
                            'mtdJobs.insertMaterialUsed(datosMaterial, tran, con.conn)
                        Else
                            message = message + If(message = "", CStr(row.Index), " ," + CInt(row.Index))
                        End If
                        countRowsInc += 1
                        If everyIncrement >= countRowsInc And pgbComplete.Value < 90 Then
                            pgbComplete.Value = pgbComplete.Value + increment
                            countRowsInc = 0
                        End If
                    End If
                    datosMaterial.Clear()
                    'lblMessage.Text = "Message: Reading row " + CStr(row.HeaderCell.Value)
                Next
                If message <> "" Then
                    MessageBox.Show("Error at line: " + message + ". These rows are not Correct, please verify the information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    pgbComplete.Value = 100
                    lblMessage.Text = "Message: The Process Records Insertion has a problem."
                Else
                    pgbComplete.Value = 90
                    lblMessage.Text = "Message: Creating Doc Temp..."
                    If Not IO.Directory.Exists("C:\TMP") Then
                        My.Computer.FileSystem.CreateDirectory("C:\TMP")
                    End If
                    Dim Write As New System.IO.StreamWriter("C:\TMP\MaterialUsed.csv")
                    Write.WriteLine(txtDoc)
                    Write.Close()
                    pgbComplete.Value = 95
                    If Not errorRow Then
                        lblMessage.Text = "Message: Saving..."
                        If mtdJobs.execBulkInsertMaterialUsed() Then
                            lblMessage.Text = "Message: The Process Records Insertion is over."
                            MsgBox("Sucessfull")
                        Else
                            lblMessage.Text = "Message: The Process Records Insertion has a problem."
                        End If
                        pgbComplete.Value = 100
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            'con.desconectar()
        End Try
    End Sub

    Private Sub enumerarFilas()
        For Each row As DataGridViewRow In tblEquipment.Rows
            row.HeaderCell.Value = CStr(row.Index + 1)
        Next
    End Sub

    Private Sub tblEquipment_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles tblEquipment.RowsRemoved
        enumerarFilas()
    End Sub

    Private Sub tblEquipment_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles tblEquipment.RowsAdded
        enumerarFilas()
    End Sub

    Private Sub tblEquipment_Enter(sender As Object, e As EventArgs) Handles tblEquipment.Enter
        Try
            If tblEquipment.CurrentRow IsNot Nothing Then
                If tblEquipment.CurrentRow.Cells("clmJobNo").Value IsNot DBNull.Value Then
                    lbljobNo.Text = tblEquipment.CurrentRow.Cells("clmJobNo").Value
                Else
                    lbljobNo.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class