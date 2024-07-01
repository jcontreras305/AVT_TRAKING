Imports Microsoft.Office.Interop.Excel
Imports System.Globalization
Imports System.Runtime.InteropServices
Public Class ModificationValidationTable
    Public IdCliente As String
    Dim mtdScaffold As New MetodosScaffold
    Dim tblMod As New Data.DataTable
    Dim tblTags As New Data.DataTable
    Dim tblType As New Data.DataTable
    Dim tblProducts As New Data.DataTable
    Dim tblWO As New Data.DataTable
    Dim listTagExcel As New List(Of String)
    Dim listProduct As New List(Of String)
    Dim listModExcel As New List(Of String)
    Dim selectTable As String
    Public fechaStart As New Date
    Private flagClick As Boolean
    Private Sub ModificationValidationTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdScaffold.llenarModification(tblMod, IdCliente)
        mtdScaffold.llenarTags(tblTags, If(IdCliente = "", "ALL", IdCliente))
        mtdScaffold.llenarRental(tblType)
        mtdScaffold.llenarProductByJobNo(tblProducts)
        mtdScaffold.llenarTableWO(tblWO, If(IdCliente = "", "ALL", IdCliente))
        For Each row As Data.DataRow In tblProducts.Rows
            listProduct.Add(row("ID").ToString())
        Next
        btnSave.Enabled = False
    End Sub

    Private Sub btnSubirExcel_Click(sender As Object, e As EventArgs) Handles btnSubirExcel.Click
        Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
        Try
            Dim openFile As New OpenFileDialog
            openFile.DefaultExt = "*.xlsm"
            openFile.FileName = "tScaffolds"
            openFile.ShowDialog()

            Dim libro = ApExcel.Workbooks.Open(openFile.FileName)
            Dim modSheet As Worksheet = New Worksheet
            Dim productSheet As Worksheet = New Worksheet
            Dim flagStatus As Boolean = True
            If DialogResult.OK = MessageBox.Show("The process to read the Excel will be start." + vbCr + "Please verify that the name of the Modification sheet is 'MODI'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information) Then
                Try
                    modSheet = libro.Worksheets("MODI")
                    lblMessage.Text = "Message: Open sheet 'MODI'."
                    pgbComplete.Value = 10
                Catch ex As Exception
                    modSheet = libro.Worksheets(5)
                    lblMessage.Text = "Message: Open sheet 'MODI'."
                    pgbComplete.Value = 10
                End Try
                validarSheetMod(modSheet)
                Try
                    productSheet = libro.Worksheets("MOD")
                    lblMessage.Text = "Message: Open sheet 'MOD'."
                    pgbComplete.Value = pgbComplete.Value + 10
                Catch ex As Exception
                    productSheet = libro.Worksheets(2)
                    lblMessage.Text = "Message: Open sheet 'MOD'."
                    pgbComplete.Value = pgbComplete.Value + 10
                End Try

                validarProductMod(productSheet)
                If Not ExistError(tblModificationScaffold) And Not ExistError(tblProductSheet) Then
                    btnSave.Enabled = True
                Else
                    btnSave.Enabled = False
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
    Private Function validarProductMod(ByVal sheet As Worksheet) As Boolean
        Try
            lblMessage.Text = "Message: Reading Product Modification Sheet."
            tblProductSheet.Rows.Clear()
            tblProductSheet.Columns("clmErrorP").Visible = False
            Dim contPM As Integer = 2
            While sheet.Cells(contPM, 1).Text <> "" Or sheet.Cells(contPM + 1, 1).Text <> ""
                If sheet.Cells(contPM, 1).Text <> "" Then
                    tblProductSheet.Rows.Add("", sheet.Cells(contPM, 1).Text, sheet.Cells(contPM, 2).Text, sheet.Cells(contPM, 3).Text)
                    tblProductSheet.Rows(tblProductSheet.Rows.Count() - 1).HeaderCell.Value = contPM.ToString()
                End If
                If sheet.Cells(contPM + 1, 1).Text <> "" Then
                    tblProductSheet.Rows.Add("", sheet.Cells(contPM + 1, 1).Text, sheet.Cells(contPM + 1, 2).Text, sheet.Cells(contPM + 1, 3).Text)
                    tblProductSheet.Rows(tblProductSheet.Rows.Count() - 1).HeaderCell.Value = (contPM + 1).ToString()
                End If
                contPM += 2
            End While
            pgbComplete.Value = pgbComplete.Value + 20
            lblMessage.Text = "Message: Validating the values."
            For Each row As DataGridViewRow In tblProductSheet.Rows()
                validarFilasProduct(row)
                'asignModIDToProductM(row.Cells("clmTagID").Value, tblModificationScaffold)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validarFilasProduct(ByVal row As DataGridViewRow) As Boolean
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
            actualizarListTagExcel()
            If row.Cells("clmTagID").Value.ToString.Equals(tagAfter(0)) And Not tagAfter(0) <> "" Then
                row.Cells("clmTagID").Style.BackColor = Color.Red
                row.Cells("clmErrorP").Value = "The tag does not exist."
                tblProductSheet.Columns("clmErrorP").Visible = True
            Else
                If Not existTagExcel(row.Cells("clmTagID").Value) Then 'valdamos que este en la lista a insertar
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
            If CDec(row.Cells("clmQuantity").Value) > 0 Then
                If Not existQuantityPositivo(row.Cells("clmQuantity").Value, row.Cells("clmProductID").Value, row.Cells("clmTagID").Value) Then
                    row.Cells("clmQuantity").Style.BackColor = Color.Red
                    row.Cells("clmErrorP").Value = If(row.Cells("clmErrorP").Value <> "", row.Cells("clmErrorP").Value & ", The Quantity is not enougth", "The Quantity is not enougth.")
                    tblProductSheet.Columns("clmErrorP").Visible = True
                End If
            Else
                If Not existQuantityNegativo(row.Cells("clmQuantity").Value, row.Cells("clmProductID").Value, row.Cells("clmTagID").Value) Then
                    row.Cells("clmQuantity").Style.BackColor = Color.Red
                    row.Cells("clmErrorP").Value = If(row.Cells("clmErrorP").Value <> "", row.Cells("clmErrorP").Value & ", The Quantity it can not be negative", "The Quantity it can not be negative.")
                    tblProductSheet.Columns("clmErrorP").Visible = True
                End If
            End If
            If row.Cells("clmModID").Value = "" Then
                asignModIDToProductM(row.Cells("clmTagID").Value, tblModificationScaffold)
            End If
            If row.Cells("clmErrorP").Value <> "" Then
                tblProductSheet.Columns("clmErrorP").Visible = True
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
    Private Function existQuantityPositivo(ByVal QTY As String, ByVal idProduct As String, ByVal tagRow As String) As Boolean
        Dim exist As Boolean = False
        Dim TQP As Double = 0.0
        Dim idjob As String = mtdScaffold.selectJobBytag(tagRow)
        If Not idjob = "" Then
            For Each row1 As DataGridViewRow In tblProductSheet.Rows()
                If row1.Cells("clmProductID").Value = idProduct And CDbl(row1.Cells("clmQuantity").Value) > 0 Then
                    TQP = TQP + CDbl(row1.Cells("clmQuantity").Value)
                End If
            Next

            For Each row As Data.DataRow In tblProducts.Rows()
                If idProduct = row("ID").ToString() And CStr(row("QTY")) <> "" Then
                    If idjob = row("jobNo").ToString() Then
                        If row("QTY") >= CDec(QTY) And row("QTY") >= TQP Then
                            exist = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End If
        Return exist
    End Function

    Public Function existQuantityNegativo(ByVal QTY As String, ByVal idProduct As String, ByVal tag As String) As Boolean
        Try
            Dim md As New ModificationSC
            Dim tbl As Data.DataTable = md.llenarTablaProductTag(tag)
            Dim exist As Boolean = False
            For Each row As Data.DataRow In tbl.Rows()
                If idProduct = row.ItemArray(2) Then
                    If -1 * (QTY) <= row.ItemArray(1) Then
                        exist = True
                        Exit For
                    End If
                End If
            Next
            Return exist
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validarSheetMod(ByVal sheet As Worksheet) As Boolean
        Try
            lblMessage.Text = "Message: Reading Modification Sheet."
            tblModificationScaffold.Rows.Clear()
            tblModificationScaffold.Columns("clmError").Visible = False
            Dim contMD As Integer = 2

            While sheet.Cells(contMD, 1).Text <> "" Or sheet.Cells(contMD + 1, 1).Text <> ""
                If contMD >= sprFirstRow.Value Then
                    If sheet.Cells(contMD, 1).Text <> "" Then
                        tblModificationScaffold.Rows.Add("", sheet.Cells(contMD, 1).Text, sheet.Cells(contMD, 2).Text, sheet.Cells(contMD, 3).Text, sheet.Cells(contMD, 4).Text, sheet.Cells(contMD, 5).Text, sheet.Cells(contMD, 6).Text, sheet.Cells(contMD, 7).Text, sheet.Cells(contMD, 13).Text, If(sheet.Cells(contMD, 14).Text = "yes" Or sheet.Cells(contMD, 14).Text = "YES", True, False), If(sheet.Cells(contMD, 15).Text = "yes" Or sheet.Cells(contMD, 15).Text = "YES", True, False), If(sheet.Cells(contMD, 16).Text = "yes" Or sheet.Cells(contMD, 16).Text = "YES", True, False), If(sheet.Cells(contMD, 17).Text = "yes" Or sheet.Cells(contMD, 17).Text = "YES", True, False), If(sheet.Cells(contMD, 18).Text = "yes" Or sheet.Cells(contMD, 18).Text = "YES", True, False), If(sheet.Cells(contMD, 19).Text = "yes" Or sheet.Cells(contMD, 19).Text = "YES", True, False), If(sheet.Cells(contMD, 20).Text = "yes" Or sheet.Cells(contMD, 20).Text = "YES", True, False), sheet.Cells(contMD, 21).Text, sheet.Cells(contMD, 22).Text, sheet.Cells(contMD, 23).Text, sheet.Cells(contMD, 24).Text, sheet.Cells(contMD, 25).Text, sheet.Cells(contMD, 26).Text, sheet.Cells(contMD, 27).Text, sheet.Cells(contMD, 28).Text, sheet.Cells(contMD, 29).Text, sheet.Cells(contMD, 30).Text, sheet.Cells(contMD, 32).Text)
                        tblModificationScaffold.Rows(tblModificationScaffold.Rows.Count() - 1).HeaderCell.Value = contMD.ToString()
                    End If
                End If
                If contMD + 1 >= sprFirstRow.Value Then
                    If sheet.Cells(contMD + 1, 1).Text <> "" Then
                        tblModificationScaffold.Rows.Add("", sheet.Cells(contMD + 1, 1).Text, sheet.Cells(contMD + 1, 2).Text, sheet.Cells(contMD + 1, 3).Text, sheet.Cells(contMD + 1, 4).Text, sheet.Cells(contMD + 1, 5).Text, sheet.Cells(contMD + 1, 6).Text, sheet.Cells(contMD + 1, 7).Text, sheet.Cells(contMD + 1, 13).Text, If(sheet.Cells(contMD + 1, 14).Text = "yes" Or sheet.Cells(contMD + 1, 14).Text = "YES", True, False), If(sheet.Cells(contMD + 1, 15).Text = "yes" Or sheet.Cells(contMD + 1, 15).Text = "YES", True, False), If(sheet.Cells(contMD + 1, 16).Text = "yes" Or sheet.Cells(contMD + 1, 16).Text = "YES", True, False), If(sheet.Cells(contMD + 1, 17).Text = "yes" Or sheet.Cells(contMD + 1, 17).Text = "YES", True, False), If(sheet.Cells(contMD + 1, 18).Text = "yes" Or sheet.Cells(contMD + 1, 19).Text = "YES", True, False), If(sheet.Cells(contMD + 1, 19).Text = "yes" Or sheet.Cells(contMD + 1, 19).Text = "YES", True, False), If(sheet.Cells(contMD + 1, 20).Text = "yes" Or sheet.Cells(contMD + 1, 20).Text = "YES", True, False), sheet.Cells(contMD + 1, 21).Text, sheet.Cells(contMD + 1, 22).Text, sheet.Cells(contMD + 1, 23).Text, sheet.Cells(contMD + 1, 24).Text, sheet.Cells(contMD + 1, 25).Text, sheet.Cells(contMD + 1, 26).Text, sheet.Cells(contMD + 1, 27).Text, sheet.Cells(contMD + 1, 28).Text, sheet.Cells(contMD + 1, 29).Text, sheet.Cells(contMD + 1, 30).Text, sheet.Cells(contMD + 1, 32).Text)
                        tblModificationScaffold.Rows(tblModificationScaffold.Rows.Count() - 1).HeaderCell.Value = (contMD + 1).ToString()
                    End If
                End If
                contMD += 2
            End While
            pgbComplete.Value = pgbComplete.Value + 20
            lblMessage.Text = "Message: Validating the values."
            For Each row1 As DataGridViewRow In tblModificationScaffold.Rows()
                validarFilasModification(row1)
            Next
            pgbComplete.Value = pgbComplete.Value + 20
            Return If(tblModificationScaffold.Columns("clmError").Visible = True, False, True)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function validarFilasModification(ByVal row As DataGridViewRow) As Boolean
        Try
            'Validamos que no existan tags repetidos
            row.DefaultCellStyle.BackColor = Color.White
            row.Cells("ModID").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("TagNum").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("Type").Style.BackColor = row.DefaultCellStyle.BackColor
            row.Cells("clmError").Value = ""
            Dim Mod1 As String = row.Cells("ModID").Value
            Dim Tag1 As String = row.Cells("TagNum").Value
            Dim flagRepeat As Integer = 0
            If Not existMod(Mod1, Tag1) Then 'validamos que no exista un modid ya insertado en con ese tag
                For Each row2 As DataGridViewRow In tblModificationScaffold.Rows() 'validamos que no se repita en el excel con ese tag 
                    If Mod1 = row2.Cells("ModID").Value And Tag1 = row2.Cells("TagNum").Value Then
                        flagRepeat += 1
                        If flagRepeat > 1 Then
                            row2.DefaultCellStyle.BackColor = Color.Yellow
                            row2.Cells("ModID").Style.BackColor = Color.Red
                            row2.Cells("clmError").Value = "Repeat Mod-ID"
                            tblModificationScaffold.Columns("ModID").Visible = True
                            'Else
                            '    listTagExcel.Add(Tag1)
                        End If
                    End If
                Next
            Else
                row.Cells("clmError").Value = "The Mod ID is inserted whit this Tag."
                tblModificationScaffold.Columns("clmError").Visible = True
            End If
            'validamos que existe el tag    
            If Not existTag(row.Cells("TagNum").Value) Then
                row.Cells("TagNum").Style.BackColor = Color.Red
                row.Cells("clmError").Value = If(row.Cells("clmError").Value = "", "Tag Num doesn't exist or is Dismantled.", row.Cells("clmError").Value & ",Tag Num doesn't exist")
            End If
            'validamos que exista el type
            If Not existType(row.Cells("Type").Value) Then
                row.Cells("Type").Style.BackColor = Color.Red
                row.Cells("clmError").Value = If(row.Cells("clmError").Value = "", "Type doesn't exist", row.Cells("clmError").Value & ",Type doesn't exist")
            End If
            'Pintamos las filas con error
            If row.Cells("clmError").Value <> "" Then
                row.DefaultCellStyle.BackColor = Color.Yellow
                tblModificationScaffold.Columns("clmError").Visible = True
                If Not row.Cells("ModID").Style.BackColor = Color.Red Then
                    row.Cells("ModID").Style.BackColor = Color.Yellow
                End If
                If Not row.Cells("TagNum").Style.BackColor = Color.Red Then
                    row.Cells("TagNum").Style.BackColor = Color.Yellow
                End If
                If Not row.Cells("Type").Style.BackColor = Color.Red Then
                    row.Cells("Type").Style.BackColor = Color.Yellow
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function existMod(ByVal modID As String, ByVal tag As String) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblMod.Rows
            If modID = row.ItemArray(1) And tag = row.ItemArray(5) Then
                exist = True
                Exit For
            End If
        Next
        Return exist
    End Function
    Private Function existTag(ByVal tag As String) As Boolean
        Dim exist As Boolean = False
        For Each row As Data.DataRow In tblTags.Rows()
            If tag = row.ItemArray(0) Then
                If row.ItemArray(3) = "f" Then
                    exist = True
                Else
                    exist = False
                End If
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
    Public Function llenarCombo(ByVal cmb As ComboBox, ByVal tbl As Data.DataTable, ByVal clmIndex As Integer) As Boolean
        Try
            cmb.Items.Clear()
            cmb.Items.Add("")
            For Each row As Data.DataRow In tbl.Rows()
                cmb.Items.Add(CStr(row.ItemArray(clmIndex)) + If(row.ItemArray.Length > 1, " " + row.ItemArray(clmIndex + 1), "") + If(row.ItemArray.Length > 4, " QTY " + CStr(row.ItemArray(10)), ""))
            Next
            cmb.Text = ""
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function llenarCombo(ByVal cmb As ComboBox, ByVal list As List(Of String)) As Boolean
        Try
            cmb.Items.Clear()
            cmb.Items.Add("")
            For Each dato As String In list
                cmb.Items.Add(dato)
            Next
            cmb.Text = ""
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub txtFecha_TextChanged(sender As Object, e As EventArgs) Handles txtFecha.TextChanged
        If selectTable = TabControl1.TabPages(0).Text Then
            tblModificationScaffold.CurrentCell.Value = txtFecha.Text
        End If
        If Not ExistError(tblModificationScaffold) Then
            tblModificationScaffold.Columns("clmError").Visible = False
        End If
        If Not ExistError(tblProductSheet) Then
            tblProductSheet.Columns("clmErrorP").Visible = False
        End If
    End Sub

    Private Sub chbEditModID_CheckedChanged(sender As Object, e As EventArgs) Handles chbEditModID.CheckedChanged
        If chbEditModID.Checked Then
            tblProductSheet.Columns("clmModID").Visible = True
        Else
            tblProductSheet.Columns("clmModID").Visible = False
        End If
    End Sub
    Private Sub tblMosdificationScaffold_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblModificationScaffold.CellMouseClick
        Try
            flagClick = False
            selectTable = TabControl1.TabPages(0).Text
            Select Case e.ColumnIndex
                Case tblModificationScaffold.Columns("TagNum").Index
                    validarExistErrorTblProducts()
                    llenarCombo(cmbDatos, tblTags, 0)
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblModificationScaffold.Columns("Type").Index
                    llenarCombo(cmbDatos, tblType, 0)
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblModificationScaffold.Columns("ModID").Index
                    Dim tagRowSelected = tblModificationScaffold.CurrentRow.Cells("TagNum").Value
                    Dim maxModID = mtdScaffold.selectMaxModId(tagRowSelected)
                    For Each row As DataGridViewRow In tblModificationScaffold.Rows()
                        If row.Cells("TagNum").Value = tagRowSelected And CDec(maxModID) = CDec(row.Cells("ModID").Value.ToString.Remove("-")) Then
                            maxModID = (CInt(maxModID) + 1).ToString("D4")
                        End If
                    Next
                    tblModificationScaffold.CurrentCell.Value = maxModID
                    validarFilasModification(tblModificationScaffold.CurrentRow())
                    validarExistErrorTblProducts(tagRowSelected)
                    If Not ExistError(tblModificationScaffold) Then
                        tblModificationScaffold.Columns("clmError").Visible = False
                        If Not ExistError(tblProductSheet) Then
                            tblProductSheet.Columns("clmErrorP").Visible = False
                            btnSave.Enabled = True
                        End If
                    End If
                Case tblModificationScaffold.Columns("DateModification").Index
                    Dim auxF1 As Date = fechaStart
                    Dim selectFecha As New SelectDate
                    selectFecha.MVT = True
                    AddOwnedForm(selectFecha)
                    selectFecha.ShowDialog()
                    txtFecha.Enabled = True
                    txtFecha.Text = fechaStart.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
                    cmbDatos.Enabled = False
            End Select
            flagClick = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblProductSheet_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblProductSheet.CellMouseClick
        Try
            flagClick = False
            selectTable = TabControl1.TabPages(1).Text
            Select Case e.ColumnIndex
                Case tblProductSheet.Columns("clmTagID").Index
                    cmbDatos.DropDownWidth = 260
                    llenarCombo(cmbDatos, tblTags, 0)
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblProductSheet.Columns("clmProductID").Index
                    cmbDatos.DropDownWidth = 360
                    llenarCombo(cmbDatos, tblProducts, 0)
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblProductSheet.Columns("clmModID").Index
                    cmbDatos.DropDownWidth = 160
                    Dim tagCurrentRow As String = tblProductSheet.CurrentRow.Cells("clmTagID").Value
                    listModExcel.Clear()
                    For Each row As DataGridViewRow In tblModificationScaffold.Rows()
                        If tagCurrentRow = row.Cells("TagNum").Value Then
                            If Not listModExcel.IndexOf(row.Cells("ModID").Value) > 0 Then
                                listModExcel.Add(row.Cells("ModID").Value)
                            End If
                        End If
                    Next
                    For Each row As Data.DataRow In tblMod.Rows()
                        If row.ItemArray(5) = tagCurrentRow And listModExcel.IndexOf(row.ItemArray(1)) = -1 Then
                            listModExcel.Add(row.ItemArray(1))
                        End If
                    Next
                    llenarCombo(cmbDatos, listModExcel)
                    cmbDatos.Enabled = True
                    txtFecha.Enabled = False
                Case tblProductSheet.Columns("clmQuantity").Index
                    cmbDatos.Enabled = False
                    txtFecha.Enabled = False
            End Select
            flagClick = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub actualizarTagTblProductExcel(ByVal tbl As DataGridView, ByVal lastTag As String, ByVal newTag As String)
        Try
            For Each row As DataGridViewRow In tbl.Rows
                If row.Cells("clmTagID").Value = lastTag Then
                    row.Cells("clmTagID").Value = newTag
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbDatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatos.SelectedIndexChanged
        Try
            If flagClick Then
                If selectTable = TabControl1.TabPages(0).Text Then
                    If tblModificationScaffold.CurrentCell.ColumnIndex = tblModificationScaffold.Columns("TagNum").Index And cmbDatos.SelectedItem IsNot Nothing Then
                        Dim NewTag() As String = cmbDatos.SelectedItem.ToString().Split(" ")
                        actualizarTagTblProductExcel(tblProductSheet, tblModificationScaffold.CurrentCell.Value, NewTag(0))
                        tblModificationScaffold.CurrentCell.Value = NewTag(0)
                        If asignModIDToProductM(NewTag(0), tblModificationScaffold) = False Then
                            tblProductSheet.Columns("clmErrorP").Visible = True
                            For Each row1 As DataGridViewRow In tblProductSheet.Rows()
                                Dim array() As String = cmbDatos.SelectedItem.ToString.Split(" ")
                                If row1.Cells("clmTagID").Value = array(0) Then
                                    row1.Cells("clmErrorP").Value = If(row1.Cells("clmErrorP").Value = "", "No exist a Modification inserted o added in the Modification Table.", row1.Cells("clmErrorP").Value + ", No exist a Modification inserted o added in the Modification Table")
                                End If
                            Next
                        End If
                    ElseIf tblModificationScaffold.CurrentCell.ColumnIndex = tblModificationScaffold.Columns("Type").Index Then
                        Dim array() As String = cmbDatos.SelectedItem.ToString.Split(" ")
                        tblModificationScaffold.CurrentCell.Value = array(0)
                    End If
                    validarExistErrorTblProducts()
                    validarFilasModification(tblModificationScaffold.CurrentRow())
                ElseIf selectTable = TabControl1.TabPages(1).Text Then
                    If tblProductSheet.CurrentCell.ColumnIndex = tblProductSheet.Columns("clmTagID").Index Then
                        Dim array() As String = cmbDatos.SelectedItem.ToString().Split(" ")
                        tblProductSheet.CurrentCell.Value = array(0)
                    ElseIf tblProductSheet.CurrentCell.ColumnIndex = tblProductSheet.Columns("clmProductID").Index Then
                        Dim array() As String = cmbDatos.SelectedItem.ToString().Split(" ")
                        tblProductSheet.CurrentCell.Value = array(0)
                    ElseIf tblProductSheet.CurrentCell.ColumnIndex = tblProductSheet.Columns("clmModID").Index Then
                        For Each cells As DataGridViewCell In tblProductSheet.SelectedCells
                            If cells.ColumnIndex = tblProductSheet.Columns("clmModID").Index Then
                                cells.Value = cmbDatos.SelectedItem.ToString()
                            End If
                        Next
                    End If
                    validarFilasProduct(tblProductSheet.CurrentRow())
                End If
                If Not ExistError(tblModificationScaffold) Then
                    tblModificationScaffold.Columns("clmError").Visible = False
                    If Not ExistError(tblProductSheet) Then
                        tblProductSheet.Columns("clmErrorP").Visible = False
                        btnSave.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub actualizarListTagExcel()
        Try
            listTagExcel.Clear()
            For Each row As DataGridViewRow In tblModificationScaffold.Rows()
                If listTagExcel.IndexOf(row.Cells("TagNum").Value) Then
                    listTagExcel.Add(row.Cells("TagNum").Value)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub actualzarListMod()
        listModExcel.Clear()
        For Each row As DataGridViewRow In tblModificationScaffold.Rows
            If listModExcel.IndexOf(row.Cells("TagNum").Value) = -1 Then
                listModExcel.Add(row.Cells("TagNum").Value)
            End If
        Next
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        selectTable = TabControl1.SelectedTab.Text()
        cmbDatos.Items.Clear()
        cmbDatos.Enabled = False
        txtFecha.Text = ""
        txtFecha.Enabled = False
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

    Private Sub tblModificationScaffold_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblModificationScaffold.CellEndEdit
        validarFilasModification(tblModificationScaffold.Rows(tblModificationScaffold.CurrentCell.RowIndex()))
        If tblModificationScaffold.CurrentCell.RowIndex() = 1 Or tblModificationScaffold.CurrentCell.RowIndex() = 2 Then
            validarExistErrorTblProducts()
        End If
        If Not ExistError(tblModificationScaffold) Then
            tblModificationScaffold.Columns("clmError").Visible = False
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
        validarFilasProduct(tblProductSheet.Rows(tblProductSheet.CurrentCell.RowIndex()))
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
    Private Sub validarExistErrorTblProducts()
        Try
            For Each row As DataGridViewRow In tblProductSheet.Rows
                validarFilasProduct(row)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub validarExistErrorTblProducts(ByVal tag As String)
        Try
            For Each row As DataGridViewRow In tblProductSheet.Rows
                If tag = row.Cells("clmTagID").Value Then
                    validarFilasProduct(row)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function asignModIDToProductM(ByRef tag As String, ByVal tblMod As DataGridView) As Boolean
        Try
            Dim modId1 As String = ""
            For Each row As DataGridViewRow In tblMod.Rows()
                If tag = row.Cells("TagNum").Value Then
                    modId1 = row.Cells("ModID").Value
                    Exit For
                End If
            Next
            If modId1 <> "" Then
                For Each row1 As DataGridViewRow In tblProductSheet.Rows
                    If tag = row1.Cells("clmTagID").Value Then
                        row1.Cells("clmModID").Value = modId1
                    End If
                Next
                Return True
            Else
                Dim maxModID As String = mtdScaffold.selectMaxModId(tag)
                If maxModID <> "1000" Or maxModID <> "" Then
                    For Each row1 As DataGridViewRow In tblProductSheet.Rows
                        If tag = row1.Cells("clmTagID").Value Then
                            row1.Cells("clmTagID").Value = maxModID
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            lblMessage.Text = "Message: Starting Process."
            pgbComplete.Value = 0
            Dim porcentFilas = 100 / tblModificationScaffold.Rows.Count
            lblMessage.Text = "Message: Processing data."
            Dim rowInserted As Integer = 0
            Dim rowError As Integer = 0

            For Each rowModification As DataGridViewRow In tblModificationScaffold.Rows()
                Dim mod1 As New ModificationSC
                mod1.ModID = rowModification.Cells("ModID").Value
                mod1.tag = rowModification.Cells("TagNum").Value
                mod1.reqCompany = rowModification.Cells("ReqComp").Value
                mod1.requestBy = rowModification.Cells("RequestBy").Value
                mod1.foreman = rowModification.Cells("Foreman").Value
                mod1.erector = rowModification.Cells("Erector").Value
                mod1.ModDate = rowModification.Cells("DateModification").Value
                mod1.materialHandeling(0) = rowModification.Cells("Truck").Value
                mod1.materialHandeling(1) = rowModification.Cells("Forklift").Value
                mod1.materialHandeling(2) = rowModification.Cells("Trailer").Value
                mod1.materialHandeling(3) = rowModification.Cells("Crane").Value
                mod1.materialHandeling(4) = rowModification.Cells("Rope").Value
                mod1.materialHandeling(5) = rowModification.Cells("Passed").Value
                mod1.materialHandeling(6) = rowModification.Cells("Elevator").Value
                mod1.ahrBuild = rowModification.Cells("Build").Value
                mod1.ahrMaterial = rowModification.Cells("Material").Value
                mod1.ahrTravel = rowModification.Cells("Travel").Value
                mod1.ahrWeather = rowModification.Cells("Weather").Value
                mod1.ahrAlarm = rowModification.Cells("Alarm").Value
                mod1.ahrSafety = rowModification.Cells("Safety").Value
                mod1.ahrStdBy = rowModification.Cells("stdBY").Value
                mod1.ahrOther = rowModification.Cells("Other").Value
                mod1.ahrTotal = mod1.ahrBuild + mod1.ahrMaterial + mod1.ahrTravel + mod1.ahrWeather + mod1.ahrAlarm + mod1.ahrSafety + mod1.ahrStdBy + mod1.ahrOther
                mod1.comments = rowModification.Cells("Comment").Value
                For Each rowP As DataGridViewRow In tblProductSheet.Rows()
                    If rowP.Cells("clmModID").Value = mod1.ModID And rowP.Cells("clmTagID").Value = mod1.tag Then
                        mod1.productsAdds.Rows.Add("", rowP.Cells("clmProductID").Value, rowP.Cells("clmQuantity").Value, "", "")
                        rowP.Cells("clmErrorP").Value = "Complete"
                    End If
                Next
                If mtdScaffold.saveModification(mod1) Then
                    pgbComplete.Value = pgbComplete.Value + porcentFilas
                    rowInserted += 1
                Else
                    rowModification.Cells("clmError").Value = "Error"
                    rowError += 1
                End If
            Next
            For Each rowProducts As DataGridViewRow In tblProductSheet.Rows()
                If rowProducts.Cells("clmErrorp").Value <> "Complete" Then
                    If rowProducts.Cells("clmModID").Value <> "" Then
                        rowProducts.Cells("clmErrorP").Value = mtdScaffold.insertProductModification(rowProducts.Cells("clmProductID").Value, rowProducts.Cells("clmQuantity").Value, rowProducts.Cells("clmModID").Value, rowProducts.Cells("clmQuantity").Value)
                    Else
                        Dim maxid = CStr(CDec(mtdScaffold.selectMaxModId(rowProducts.Cells("clmTagID").Value)) + 1)
                        rowProducts.Cells("clmErrorP").Value = mtdScaffold.insertProductModification(rowProducts.Cells("clmProductID").Value, rowProducts.Cells("clmQuantity").Value, maxid, rowProducts.Cells("clmQuantity").Value)
                    End If
                End If
            Next
            lblMessage.Text = "Message: The Process is ended."
            MessageBox.Show("Sucessful")
            MessageBox.Show("Finish: " + If(rowError > 0, CStr(rowInserted) & " modification have not been inserted check the colmun error.", CStr(rowInserted) & " tags have been inserted."), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
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

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub
End Class