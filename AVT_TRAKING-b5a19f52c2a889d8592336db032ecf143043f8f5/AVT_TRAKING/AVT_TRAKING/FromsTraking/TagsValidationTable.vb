Imports Microsoft.Office.Interop.Excel
Imports System.Globalization
Imports System.Runtime.InteropServices
Public Class TagsValidationTable
    Public IdCliente As String
    Dim mtdScaffold As New MetodosScaffold
    Dim tblClassification As New Data.DataTable
    Dim tblTags As New Data.DataTable
    Dim tblAreas As New Data.DataTable
    Dim tblJobCat As New Data.DataTable
    Dim tblSubJob As New Data.DataTable
    Dim tblType As New Data.DataTable
    Dim tblProducts As New Data.DataTable
    Dim tblWO As New Data.DataTable
    Dim listTagExcel As New List(Of String)
    Dim listProduct As New List(Of String)
    Dim selectTable As String
    Public fechaStart As Date
    Private flagClick As Boolean
    Private Sub TagsValidationTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flagClick = False
        cmbDatos.Enabled = False
        txtFecha.Enabled = False
        btnSave.Enabled = False
        mtdScaffold.llenarAreas(tblAreas)
        mtdScaffold.llenarJobCat(tblJobCat)
        mtdScaffold.llenarScaffold(tblTags, IdCliente)
        mtdScaffold.llenarTableWO(tblWO, If(IdCliente = "", "ALL", IdCliente))
        mtdScaffold.llenarSubJobs(tblSubJob)
        mtdScaffold.llenarRental(tblType)
        mtdScaffold.llenarProduct(tblProducts)
        selectTable = TabControl1.SelectedTab.Text()
        For Each row As Data.DataRow In tblProducts.Rows
            listProduct.Add(row("ID").ToString())
        Next
    End Sub
    Private Sub btnSubirExcel_Click(sender As Object, e As EventArgs) Handles btnSubirExcel.Click
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "tScaffolds"
            openFile.ShowDialog()
            If openFile.FileName IsNot Nothing Then
                Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
                Dim scaffoldSheet As Worksheet = New Worksheet
                Dim productSheet As Worksheet = New Worksheet
                Dim flagStatus As Boolean = True
                If DialogResult.OK = MessageBox.Show("The process to read the Excel will be start." + vbCr + "Please verify that the name of the scaffold sheet is 'tScaffolds'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information) Then
                    Try
                        scaffoldSheet = libro.Worksheets("tScaffolds")
                        lblMessage.Text = "Message: Open sheet 'Scaffolds'."
                        pgbComplete.Value = 5
                    Catch ex As Exception
                        scaffoldSheet = libro.Worksheets(1)
                        lblMessage.Text = "Message: Open sheet 'tScaffolds'."
                        pgbComplete.Value = 5
                    End Try
                    validarSheetScaffold(scaffoldSheet)
                    Try
                        productSheet = libro.Worksheets("tMatBuilds")
                        lblMessage.Text = "Message: Open sheet 'tMatBuilds'."
                        pgbComplete.Value = pgbComplete.Value + 5
                    Catch ex As Exception
                        productSheet = libro.Worksheets(2)
                        lblMessage.Text = "Message: Open sheet 'tMatBuilds'."
                        pgbComplete.Value = pgbComplete.Value + 5
                    End Try
                    validarProductTags(productSheet)
                    If Not ExistError(tblTagsScaffold) Then
                        If Not ExistError(tblProductSheet) Then
                            btnSave.Enabled = True
                        End If
                    End If
                    lblMessage.Text = "Message: Finish."
                    pgbComplete.Value = 100
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            lblMessage.Text = "Message: Finish."
        Finally
            ApExcel.Quit()
            NAR(ApExcel)
        End Try
    End Sub

    Private Function validarProductTags(ByVal sheet As Worksheet) As Boolean
        Try
            lblMessage.Text = "Message: Reading Material Build Sheet"
            tblProductSheet.Rows.Clear()
            Dim contPs As Integer = 2
            Dim increment = Int(40 / nreg(sheet, 2, 1)) '40 porciento del progresbar
            Dim contIncrement As Integer = 0
            tblProductSheet.Columns("clmErrorP").Visible = False
            While sheet.Cells(contPs, 1).Text <> "" Or sheet.Cells(contPs + 1, 1).Text <> ""
                If sheet.Cells(contPs, 1).Text <> "" Then
                    tblProductSheet.Rows.Add("", sheet.Cells(contPs, 1).Text, sheet.Cells(contPs, 2).Text, sheet.Cells(contPs, 3).Text)
                    tblProductSheet.Rows(tblProductSheet.Rows.Count() - 1).HeaderCell.Value = contPs.ToString()
                End If
                contPs += 1
                contIncrement += increment
                If contIncrement > 1 And pgbComplete.Value <= 90 Then
                    pgbComplete.Value = pgbComplete.Value + If(increment > 1, CInt(increment), 1)
                    contIncrement = 0
                End If
            End While
            lblMessage.Text = "Message: Validating the values."
            pgbComplete.Value = pgbComplete.Value + 5
            For Each row As DataGridViewRow In tblProductSheet.Rows()
                validarFilaProduct(row)
            Next
            pgbComplete.Value = pgbComplete.Value + 5
            Return If(tblProductSheet.Columns("clmErrorP").Visible = True, False, True)
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Private Function existQuantity(ByVal idProduct As String) As Boolean
        Dim exist As Boolean = False
        Dim listRows() As Data.DataRow = tblProducts.Select("ID = " + CStr(idProduct))
        Dim qtyActually = TotalQtyProductSheet(idProduct)
        If qtyActually <= CDec(listRows(0).ItemArray(10)) Then
            exist = True
        Else
            exist = False
        End If
        Return exist
    End Function
    Public Function TotalQtyProductSheet(ByVal idProduct As String) As Double
        Try
            Dim qty As Double = 0.0
            For Each row As DataGridViewRow In tblProductSheet.Rows()
                If row.Cells("clmProductID").Value = idProduct Then
                    qty += If(row.Cells("clmQuantity").Value = "", 0, CDec(row.Cells("clmQuantity").Value))
                End If
            Next
            Return qty
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Function validarSheetScaffold(ByVal sheet As Worksheet) As Boolean
        Try
            lblMessage.Text = "Message: Reading Scaffold Sheet."
            tblTagsScaffold.Rows.Clear()
            Dim contSC As Integer = 2
            Dim increment = Int(40 / nreg(sheet, 2, 1))
            Dim contIncrement As Integer = 0
            While sheet.Cells(contSC, 1).Text <> "" Or sheet.Cells(contSC + 1, 1).Text <> ""
                If sheet.Cells(contSC, 1).Text <> "" Then
                    tblTagsScaffold.Rows.Add("", sheet.Cells(contSC, 1).Text, sheet.Cells(contSC, 2).Text, sheet.Cells(contSC, 3).Text, sheet.Cells(contSC, 5).Text, sheet.Cells(contSC, 6).Text, sheet.Cells(contSC, 7).Text, sheet.Cells(contSC, 9).Text, sheet.Cells(contSC, 10).Text, sheet.Cells(contSC, 11).Text, sheet.Cells(contSC, 12).Text, sheet.Cells(contSC, 13).Text, sheet.Cells(contSC, 14).Text, sheet.Cells(contSC, 15).Text, sheet.Cells(contSC, 16).Text, sheet.Cells(contSC, 17).Text, sheet.Cells(contSC, 18).Text, If(sheet.Cells(contSC, 19).Text = "Yes", True, False), If(sheet.Cells(contSC, 20).Text = "Yes", True, False), If(sheet.Cells(contSC, 21).Text = "Yes", True, False), If(sheet.Cells(contSC, 22).Text = "Yes", True, False), If(sheet.Cells(contSC, 23).Text = "Yes", True, False), If(sheet.Cells(contSC, 24).Text = "Yes", True, False), If(sheet.Cells(contSC, 25).Text = "Yes", True, False), If(sheet.Cells(contSC, 26).Text = "Yes", True, False), If(sheet.Cells(contSC, 27).Text = "Yes", True, False), If(sheet.Cells(contSC, 28).Text = "Yes", True, False), If(sheet.Cells(contSC, 29).Text = "Yes", True, False), sheet.Cells(contSC, 31).Text, sheet.Cells(contSC, 32).Text, sheet.Cells(contSC, 33).Text, sheet.Cells(contSC, 34).Text, sheet.Cells(contSC, 35).Text, sheet.Cells(contSC, 36).Text, sheet.Cells(contSC, 37).Text, sheet.Cells(contSC, 38).Text, sheet.Cells(contSC, 39).Text, sheet.Cells(contSC, 40).Text, sheet.Cells(contSC, 41).Text, sheet.Cells(contSC, 42).Text, sheet.Cells(contSC, 43).Text, sheet.Cells(contSC, 44).Text, If(sheet.Cells(contSC, 45).Text = "", "0", sheet.Cells(contSC, 45).Text), If(sheet.Cells(contSC, 46).TexT = "", "0", sheet.Cells(contSC, 46).TexT))
                    tblTagsScaffold.Rows(tblTagsScaffold.Rows.Count() - 1).HeaderCell.Value = contSC.ToString()
                End If
                contSC += 1
                contIncrement += increment
                If contIncrement > 1 And pgbComplete.Value <= 46 Then
                    pgbComplete.Value = pgbComplete.Value + If(increment > 1, CInt(increment), 1)
                    contIncrement = 0
                End If
            End While
            lblMessage.Text = "Message: Validating the values."
            mtdScaffold.llenarTablaProjects()
            For Each row1 As DataGridViewRow In tblTagsScaffold.Rows()
                validarFilaTags(row1)
            Next
            pgbComplete.Value = pgbComplete.Value + 5
            Return If(tblTagsScaffold.Columns("clmError").Visible = True, False, True)
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    Private Sub tblTagsScaffold_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblTagsScaffold.CellMouseClick
        Try
            flagClick = False
            Select Case e.ColumnIndex
                Case tblTagsScaffold.Columns("jobCat").Index
                    llenarCombo(cmbDatos, tblJobCat, 0, False)
                    cmbDatos.DropDownWidth = 167
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblTagsScaffold.Columns("AreaID").Index
                    llenarCombo(cmbDatos, tblAreas, 0, False)
                    cmbDatos.DropDownWidth = 167
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblTagsScaffold.Columns("WorkNum").Index
                    mtdScaffold.llenarComboWO(cmbDatos, IdCliente)
                    cmbDatos.DropDownWidth = 380
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblTagsScaffold.Columns("JobNum").Index
                    mtdScaffold.llenarComboWO(cmbDatos, IdCliente)
                    cmbDatos.DropDownWidth = 380
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblTagsScaffold.Columns("SubJob").Index
                    llenarCombo(cmbDatos, tblSubJob, 0, False)
                    cmbDatos.DropDownWidth = 167
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblTagsScaffold.Columns("Type").Index
                    llenarCombo(cmbDatos, tblType, 0, False)
                    cmbDatos.DropDownWidth = 167
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblTagsScaffold.Columns("DateBuild").Index
                    Dim auxF1 As Date = fechaStart
                    Dim selectFecha As New SelectDate
                    AddOwnedForm(selectFecha)
                    selectFecha.ShowDialog()
                    txtFecha.Enabled = True
                    txtFecha.Text = fechaStart.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                    cmbDatos.Enabled = False
                Case tblTagsScaffold.Columns("ReqComp").Index
                    Dim auxF1 As Date = fechaStart
                    Dim selectFecha As New SelectDate
                    AddOwnedForm(selectFecha)
                    selectFecha.ShowDialog()
                    txtFecha.Enabled = True
                    txtFecha.Text = fechaStart.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                    cmbDatos.Enabled = False
                Case Else
                    txtFecha.Enabled = False
                    cmbDatos.Enabled = False
            End Select
            flagClick = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblProductSheet_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblProductSheet.CellMouseClick
        Try
            flagClick = False
            Select Case e.ColumnIndex
                Case tblProductSheet.Columns("clmTagID").Index
                    llenarCombo(cmbDatos, tblTags, 0, True)
                    cmbDatos.DropDownWidth = 167
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblProductSheet.Columns("clmProductID").Index
                    llenarCombo(cmbDatos, tblProducts, 0, False)
                    cmbDatos.DropDownWidth = 380
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case Else
                    txtFecha.Enabled = False
                    cmbDatos.Enabled = False
            End Select
            flagClick = True
        Catch ex As Exception

        End Try
    End Sub
    Public Function llenarCombo(ByVal cmb As ComboBox, ByVal tbl As Data.DataTable, ByVal clmIndex As Integer, ByVal isTag As Boolean) As Boolean
        Try
            cmb.Items.Clear()
            cmb.Items.Add("")
            For Each row As Data.DataRow In tbl.Rows()
                If isTag Then
                    cmb.Items.Add(CStr(row.ItemArray(clmIndex)) + If(row.ItemArray.Length > 1, " " + row.ItemArray(5), ""))
                Else
                    cmb.Items.Add(CStr(row.ItemArray(clmIndex)) + If(row.ItemArray.Length > 1, " " + row.ItemArray(clmIndex + 1), ""))
                End If
            Next
            If isTag Then
                For Each row As DataGridViewRow In tblTagsScaffold.Rows
                    If cmbDatos.FindString(row.Cells("TagNum").Value) = -1 Then
                        cmbDatos.Items.Add(row.Cells("TagNum").Value + " " + row.Cells("WorkNum").Value)
                    End If
                Next
            End If
            cmb.Text = ""
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function existProduct(ByVal idProduct As String) As Boolean
        Dim exist As Boolean = False
        Dim index = listProduct.IndexOf(idProduct)
        If index > -1 Then
            exist = True
        Else
            exist = False
        End If
        Return exist
    End Function
    Private Function existTagExcel(ByVal tag As String) As Boolean
        Dim exist As Boolean = False
        Dim index = listTagExcel.IndexOf(tag)
        If index > -1 Then
            exist = True
        Else
            exist = False
        End If
        Return exist
    End Function
    Private Function existTag(ByVal tag As String) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblTags.Rows
            If tag = row.ItemArray(0) Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function
    Private Function existArea(ByVal area As String) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblAreas.Rows
            If area = row.ItemArray(0) Or area = row.ItemArray(0) Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function
    Private Function existJobCat(ByVal jobCat) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblJobCat.Rows
            If jobCat = row.ItemArray(0) Or jobCat = row.ItemArray(0) Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function
    Private Function existSubJob(ByVal subJob As String) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblSubJob.Rows
            If subJob = row.ItemArray(0) Or subJob = row.ItemArray(1) Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function
    Private Function existType(ByVal type As String) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblType.Rows
            If type = row.ItemArray(0) Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function

    Private Sub cmbDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatos.SelectedIndexChanged
        Try
            If flagClick Then
                If selectTable = TabControl1.TabPages(0).Text Then
                    If tblTagsScaffold.CurrentCell.ColumnIndex = tblTagsScaffold.Columns("WorkNum").Index Then
                        If cmbDatos.SelectedItem IsNot Nothing Then
                            Dim wn As String() = cmbDatos.SelectedItem.ToString().Split(" ")
                            tblTagsScaffold.Rows(tblTagsScaffold.CurrentCell.RowIndex).Cells("WorkNum").Value = wn(0)
                            tblTagsScaffold.Rows(tblTagsScaffold.CurrentCell.RowIndex).Cells("JobNum").Value = wn(1)
                        End If
                    ElseIf tblTagsScaffold.CurrentCell.ColumnIndex = tblTagsScaffold.Columns("JobNum").Index Then
                        If cmbDatos.SelectedItem IsNot Nothing Then
                            Dim wn As String() = cmbDatos.SelectedItem.ToString().Split("   ")
                            tblTagsScaffold.Rows(tblTagsScaffold.CurrentCell.RowIndex).Cells("WorkNum").Value = wn(0)
                            tblTagsScaffold.Rows(tblTagsScaffold.CurrentCell.RowIndex).Cells("JobNum").Value = wn(1)
                        End If
                    Else
                        Dim array() As String = cmbDatos.SelectedItem.ToString.Split(" ")
                        tblTagsScaffold.CurrentCell.Value = If(array(0) <> "", array(0), "")
                    End If
                    validarFilaTags(tblTagsScaffold.CurrentRow())
                ElseIf selectTable = TabControl1.TabPages(1).Text Then
                    If tblProductSheet.CurrentCell.ColumnIndex = tblProductSheet.Columns("clmTagID").Index Then
                        If cmbDatos.SelectedItem IsNot Nothing Then
                            Dim array() As String = cmbDatos.SelectedItem.ToString.Split(" ")
                            tblProductSheet.CurrentCell.Value = array(0)
                            validarFilaProduct(tblProductSheet.CurrentRow())
                        End If
                    ElseIf tblProductSheet.CurrentCell.ColumnIndex = tblProductSheet.Columns("clmProductID").Index Then
                        If cmbDatos.SelectedItem IsNot Nothing Then
                            Dim array() As String = cmbDatos.SelectedItem.ToString.Split(" ")
                            tblProductSheet.CurrentCell.Value = array(0)
                            validarFilaProduct(tblProductSheet.CurrentRow())
                        End If
                    End If

                End If
                If Not ExistError(tblTagsScaffold) Then
                    tblTagsScaffold.Columns("clmError").Visible = False
                    If Not ExistError(tblProductSheet) Then
                        tblProductSheet.Columns("clmErrorP").Visible = False
                        btnSave.Enabled = True
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        selectTable = TabControl1.SelectedTab.Text()
        cmbDatos.Items.Clear()
        cmbDatos.Enabled = False
        txtFecha.Text = ""
        txtFecha.Enabled = False
    End Sub

    Private Sub txtFecha_TextChanged(sender As Object, e As EventArgs) Handles txtFecha.TextChanged
        If selectTable = TabControl1.TabPages(0).Text Then
            tblTagsScaffold.CurrentCell.Value = txtFecha.Text
        End If
        If Not ExistError(tblTagsScaffold) Then
            tblTagsScaffold.Columns("clmError").Visible = False
        End If
        If Not ExistError(tblProductSheet) Then
            tblProductSheet.Columns("clmErrorP").Visible = False
        End If
    End Sub
    Public Function validarFilaTags(ByVal row1 As DataGridViewRow) As Boolean
        Try
            'Validamos que no existan tags repetidos
            row1.DefaultCellStyle.BackColor = Color.White
            row1.Cells("TagNum").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("jobCat").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("AreaID").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("WorkNum").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("JobNum").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("SubJob").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("Type").Style.BackColor = row1.DefaultCellStyle.BackColor
            row1.Cells("clmError").Value = ""
            Dim tag1 As String = row1.Cells("TagNum").Value
            Dim flagRepeat As Integer = 0
            If Not existTag(tag1) Then
                For Each row2 As DataGridViewRow In tblTagsScaffold.Rows()
                    If tag1 = row2.Cells("TagNum").Value Then
                        flagRepeat += 1
                        If flagRepeat > 1 Then
                            row2.DefaultCellStyle.BackColor = Color.Yellow
                            row2.Cells("TagNum").Style.BackColor = Color.Red
                            row2.Cells("clmError").Value = "Repeat tag"
                            tblTagsScaffold.Columns("clmError").Visible = True
                        Else
                            listTagExcel.Add(tag1)
                        End If
                    End If
                Next

            Else
                row1.Cells("clmError").Value = "The tag is inserted"
                tblTagsScaffold.Columns("clmError").Visible = True
            End If
            'validamos los jobCat
            If Not existJobCat(row1.Cells("jobCat").Value) Then
                row1.Cells("jobCat").Style.BackColor = Color.Red
                row1.Cells("clmError").Value = If(row1.Cells("clmError").Value = "", "The JobCat doesn't exist", row1.Cells("clmError").Value & ",The JobCat doesn't exist")
            End If
            'validamos las areas
            If Not existArea(row1.Cells("AreaID").Value) Then
                row1.Cells("AreaID").Style.BackColor = Color.Red
                row1.Cells("clmError").Value = If(row1.Cells("clmError").Value = "", "The Area doesn't exist", row1.Cells("clmError").Value & ",The Area doesn't exist")
            End If
            'validamos que exista el task o idAux
            If Not mtdScaffold.existWO(row1.Cells("WorkNum").Value, row1.Cells("JobNum").Value) Then
                row1.Cells("WorkNum").Style.BackColor = Color.Red
                row1.Cells("JobNum").Style.BackColor = Color.Red
                row1.Cells("clmError").Value = If(row1.Cells("clmError").Value = "", "WorkNum or JobNumb doesn't exist", row1.Cells("clmError").Value & ",WorkNum or JobNum doesn't exist")
            End If
            'validamos que exista el sub subjob
            If Not existSubJob(row1.Cells("SubJob").Value) Then
                row1.Cells("SubJob").Style.BackColor = Color.Red
                row1.Cells("clmError").Value = If(row1.Cells("clmError").Value = "", "SubJob doesn't exist", row1.Cells("clmError").Value & ",SubJob doesn't exist")
            End If
            'validamos que exista el type
            If Not existType(row1.Cells("Type").Value) Then
                row1.Cells("Type").Style.BackColor = Color.Red
                row1.Cells("clmError").Value = If(row1.Cells("clmError").Value = "", "Type doesn't exist", row1.Cells("clmError").Value & ",Type doesn't exist")
            End If
            'Pintamos las filas con error
            If row1.Cells("clmError").Value <> "" Then
                row1.DefaultCellStyle.BackColor = Color.Yellow
                tblTagsScaffold.Columns("clmError").Visible = True
                If Not row1.Cells("TagNum").Style.BackColor = Color.Red Then
                    row1.Cells("TagNum").Style.BackColor = Color.Yellow
                End If
                If Not row1.Cells("jobCat").Style.BackColor = Color.Red Then
                    row1.Cells("jobCat").Style.BackColor = Color.Yellow
                End If
                If Not row1.Cells("AreaID").Style.BackColor = Color.Red Then
                    row1.Cells("AreaID").Style.BackColor = Color.Yellow
                End If
                If Not row1.Cells("WorkNum").Style.BackColor = Color.Red Then
                    row1.Cells("WorkNum").Style.BackColor = Color.Yellow
                End If
                If Not row1.Cells("JobNum").Style.BackColor = Color.Red Then
                    row1.Cells("JobNum").Style.BackColor = Color.Yellow
                End If
                If Not row1.Cells("SubJob").Style.BackColor = Color.Red Then
                    row1.Cells("SubJob").Style.BackColor = Color.Yellow
                End If
                If Not row1.Cells("Type").Style.BackColor = Color.Red Then
                    row1.Cells("Type").Style.BackColor = Color.Yellow
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validarFilaProduct(ByVal row As DataGridViewRow) As Boolean
        Try
            'validar los tag
            row.DefaultCellStyle.BackColor = Color.White
            row.Cells("clmTagID").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("clmProductID").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("clmQuantity").Style.BackColor = row.DefaultCellStyle.BackColor

            row.Cells("clmErrorP").Value = ""

            'validamos que no exista productos repetidos 
            Dim contRepeat As Integer = 0
            For Each rowp2 As DataGridViewRow In tblProductSheet.Rows()
                If row.Cells("clmTagID").Value = rowp2.Cells("clmTagID").Value And row.Cells("clmProductID").Value = rowp2.Cells("clmProductID").Value Then
                    contRepeat += 1
                    If contRepeat > 1 Then
                        row.Cells("clmProductID").Style.BackColor = Color.Red
                        row.Cells("clmTagID").Style.BackColor = Color.Red
                        row.Cells("clmErrorP").Value = If(row.Cells("clmErrorP").Value <> "", row.Cells("clmErrorP").Value & ", The product is repeat.", "The product is repeat.")
                    End If
                End If
            Next
            Dim tagAfter() As String = {"", ""}
            If row.Cells("clmTagID").Value.ToString.Equals(tagAfter(0)) And Not tagAfter(0) <> "" Then
                row.Cells("clmTagID").Style.BackColor = Color.Red
                row.Cells("clmErrorP").Value = "The tag does not exist."
                tblProductSheet.Columns("clmErrorP").Visible = True
            Else
                If Not existTagExcel(row.Cells("clmTagID").Value) Then 'valdamos que este en la lista a insetar
                    If Not existTag(row.Cells("clmTagID").Value) Then ' o que este ya insertado
                        row.Cells("clmTagID").Style.BackColor = Color.Red
                        tagAfter(0) = row.Cells("clmTagID").Value
                        row.Cells("clmErrorP").Value = "The tag does not exist"
                        tagAfter(1) = row.Cells("clmErrorP").Value
                        tblProductSheet.Columns("clmErrorP").Visible = True
                    End If
                End If
            End If
            'validar exista el product clmQuantity
            If Not existProduct(row.Cells("clmProductID").Value) Then
                row.Cells("clmProductID").Style.BackColor = Color.Red
                row.Cells("clmErrorP").Value = If(row.Cells("clmErrorP").Value <> "", row.Cells("clmErrorP").Value & ", The Product does not exist", "The Product does not exist.")
                tblProductSheet.Columns("clmErrorP").Visible = True
            End If
            'validar las existencias 
            If Not existQuantity(row.Cells("clmProductID").Value) Then
                row.Cells("clmQuantity").Style.BackColor = Color.Red
                row.Cells("clmErrorP").Value = If(row.Cells("clmErrorP").Value <> "", row.Cells("clmErrorP").Value & ", The Quantity is not enougth", "The Quantity is not enougth.")
                tblProductSheet.Columns("clmErrorP").Visible = True
            End If

            If row.Cells("clmErrorP").Value <> "" Then
                row.DefaultCellStyle.BackColor = Color.Yellow
                If Not row.Cells("clmTagID").Style.BackColor = Color.Red Then
                    row.Cells("clmTagID").Style.BackColor = Color.Yellow
                End If
                If Not row.Cells("clmProductID").Style.BackColor = Color.Red Then
                    row.Cells("clmProductID").Style.BackColor = Color.Yellow
                End If
                If Not row.Cells("clmQuantity").Style.BackColor = Color.Red Then
                    row.Cells("clmQuantity").Style.BackColor = Color.Yellow
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If ExistError(tblTagsScaffold) = False And ExistError(tblProductSheet) = False Then
                Dim listTags As New List(Of scaffold)
                For Each row As DataGridViewRow In tblTagsScaffold.Rows()
                    Dim sc As New scaffold
                    sc.tag = row.Cells("TagNum").Value
                    sc.jobcat = row.Cells("jobCat").Value
                    sc.areaID = row.Cells("AreaID").Value
                    For Each rowtask As DataRow In tblWO.Rows()
                        Dim datos() = row.Cells("WorkNum").Value.ToString().Split(" ")
                        Dim task = row.Cells("WorkNum").Value.ToString().Replace(" ", "-")
                        If task = rowtask.ItemArray(0) Then
                            sc.wo = rowtask.ItemArray(3)
                            sc.task = rowtask.ItemArray(2)
                            sc.job = rowtask.ItemArray(4)
                            Exit For
                        End If
                    Next
                    sc.idsubJob = row.Cells("SubJob").Value
                    sc.dateBild = validarFechaParaVB(row.Cells("DateBuild").Value)
                    sc.location = row.Cells("Location").Value
                    sc.purpose = row.Cells("Porpuse").Value
                    sc.sciType = row.Cells("Type").Value
                    sc.sciWidth = If(row.Cells("Width").Value = "", 0, CDbl(row.Cells("Width").Value))
                    sc.sciLength = If(row.Cells("Length").Value = "", 0, CDbl(row.Cells("Length").Value))
                    sc.sciHeigth = If(row.Cells("Heigth").Value = "", 0, CDbl(row.Cells("Heigth").Value))
                    sc.sciDecks = If(row.Cells("Decks").Value = "", 0, CDbl(row.Cells("Decks").Value))
                    sc.sciKo = If(row.Cells("KO").Value = "", 0, CDbl(row.Cells("KO").Value))
                    sc.sciBase = If(row.Cells("Base").Value = "", 0, CDbl(row.Cells("Base").Value))
                    sc.scfInfo(0) = CBool(row.Cells("CSAP").Value)
                    sc.scfInfo(1) = CBool(row.Cells("Rolling").Value)
                    sc.scfInfo(2) = CBool(row.Cells("Internal").Value)
                    sc.scfInfo(3) = CBool(row.Cells("Hanging").Value)
                    sc.materialHandeling(0) = CBool(row.Cells("Truck").Value)
                    sc.materialHandeling(2) = CBool(row.Cells("Forklift").Value)
                    sc.materialHandeling(2) = CBool(row.Cells("Trailer").Value)
                    sc.materialHandeling(3) = CBool(row.Cells("Crane").Value)
                    sc.materialHandeling(4) = CBool(row.Cells("Rope").Value)
                    sc.materialHandeling(5) = CBool(row.Cells("Passed").Value)
                    sc.materialHandeling(6) = CBool(row.Cells("Elevator").Value)
                    sc.dateRecComp = validarFechaParaVB(row.Cells("ReqComp").Value)
                    sc.contact = row.Cells("RequestBy").Value
                    sc.foreman = row.Cells("Foreman").Value
                    sc.erector = row.Cells("Erector").Value
                    sc.ahrBuild = CDbl(row.Cells("Build").Value)
                    sc.ahrBuild = CDbl(row.Cells("Material").Value)
                    sc.ahrTravel = CDbl(row.Cells("Travel").Value)
                    sc.ahrWeather = CDbl(row.Cells("Weather").Value)
                    sc.ahrAlarm = CDbl(row.Cells("Alarm").Value)
                    sc.ahrSafety = CDbl(row.Cells("Safety").Value)
                    sc.ahrStdBy = CDbl(row.Cells("stdBy").Value)
                    sc.ahrOther = CDbl(row.Cells("Other").Value)
                    sc.ahrTotal = CDbl(sc.ahrBuild + sc.ahrBuild + sc.ahrTravel + sc.ahrWeather + sc.ahrAlarm + sc.ahrSafety + sc.ahrStdBy + sc.ahrOther)
                    sc.comments = row.Cells("Comment").Value
                    sc.latitude = CDbl(row.Cells("Latitude").Value)
                    sc.longitude = CDbl(row.Cells("Longitude").Value)
                    For Each rowp As DataGridViewRow In tblProductSheet.Rows()
                        If rowp.Cells("clmTagID").Value = sc.tag Then
                            sc.products.Rows.Add("", rowp.Cells("clmProductID").Value, rowp.Cells("clmQuantity").Value, "", "")
                        End If
                    Next
                    If Not mtdScaffold.saveScaffoldTraking(sc) Then
                        row.Cells("clmError").Value = "Error"
                        tblTagsScaffold.Columns("clmError").Visible = True
                    End If
                    lblMessage.Text = "Message: Inserting tag number: " + row.Cells("TagNum").Value.ToString()
                Next
                lblMessage.Text = "Message: Finish."
            Else
                MessageBox.Show("Exist error, tray reload the document or changue the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            lblMessage.Text = "Message: Error."
        End Try
    End Sub
    Private Function ExistError(ByVal tbl As DataGridView) As Boolean
        Try
            Dim exist As Boolean = False
            For Each row As DataGridViewRow In tbl.Rows()
                If row.Cells(0).Value <> "" Then
                    exist = True
                    Exit For
                End If
            Next
            Return exist
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Sub tblTagsScaffold_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblTagsScaffold.CellEndEdit
        validarFilaTags(tblTagsScaffold.Rows(tblTagsScaffold.CurrentCell.RowIndex()))
        If Not ExistError(tblTagsScaffold) Then
            tblTagsScaffold.Columns("clmError").Visible = False
            If Not ExistError(tblProductSheet) Then
                tblProductSheet.Columns("clmErrorP").Visible = False
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        Else
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub tblProductSheet_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblProductSheet.CellEndEdit
        validarFilaProduct(tblProductSheet.Rows(tblProductSheet.CurrentCell.RowIndex()))
        If Not ExistError(tblProductSheet) Then
            tblProductSheet.Columns("clmErrorP").Visible = False
            If Not ExistError(tblProductSheet) Then
                tblProductSheet.Columns("clmErrorP").Visible = False
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        Else
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub tblTagsScaffold_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles tblTagsScaffold.RowsRemoved
        If ExistError(tblProductSheet) = False And ExistError(tblTagsScaffold) = False Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
    End Sub
End Class