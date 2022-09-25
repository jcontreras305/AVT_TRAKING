Public Class PpRow
    Dim mtdFactor As New MetodosFactor
    Dim mtdElevation As New ElevationEstimation
    Dim tblSystem As New Data.DataTable
    Dim tblInsType As New Data.DataTable
    Dim tblJkt As New Data.DataTable
    Dim tblMatrialSize As New Data.DataTable
    Dim _isSelected As Boolean
    Dim _RowIndex As Integer
    Dim _idPipingAux As String
    Private _idDrawing As String = ""
    Private loadingData As Boolean = False
    Private _itemArray() As String = {"", "NULL", "", "0", "NULL", "0", "NULL", "NULL", "NULL", "NULL", "NULL", "0", "NULL", "0", "0", "0", "0", "0", "0", "0", "0", "NULL", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "NULL"}
    Private _myDataSet As New DataSet
    Public Property MyDataSet As DataSet
        Get
            If _myDataSet Is Nothing Then
                _myDataSet.Tables.Add(mtdFactor.dataTablePpPntUnitRate()) 'Para los combos de System y Paint Option
                _myDataSet.Tables.Add(mtdFactor.dataTablePpInsUnitRate()) 'Para el combo de Insulation
                _myDataSet.Tables.Add(mtdFactor.dataTableJacketUnitRateByPiping()) 'Para el combo de Jacket
                _myDataSet.Tables.Add(mtdElevation.dataTableElvSCF()) 'Para el combo de Heigth
                _myDataSet.Tables.Add(mtdFactor.DataTableLaporRate()) 'Para los combos de labor 
            End If
            Return _myDataSet
        End Get
        Set(value As DataSet)
            _myDataSet = value
            tblSystem = _myDataSet.Tables(0)
            tblInsType = _myDataSet.Tables(1)
            tblJkt = _myDataSet.Tables(2)
            llenarCompos()
        End Set
    End Property
    Private Sub llenarCompos()
        Try
            cmbSystem.DataSource = MyDataSet.Tables(0).DefaultView.ToTable(True, "systemPntPP")
            cmbSystem.DisplayMember = "systemPntPP"
            cmbSystem.ValueMember = "systemPntPP"
            cmbSystem.SelectedIndex = -1
            cmbInsType.DataSource = MyDataSet.Tables(1).DefaultView.ToTable(True, "type")
            cmbInsType.DisplayMember = "type"
            cmbInsType.ValueMember = "type"
            cmbInsType.SelectedIndex = -1
            cmbJacked.DataSource = MyDataSet.Tables(2)
            cmbJacked.DisplayMember = "JacketName"
            cmbJacked.ValueMember = "idJacket"
            cmbJacked.SelectedIndex = -1
            cmbHeight.DataSource = MyDataSet.Tables(3)
            cmbHeight.DisplayMember = "elevation"
            cmbHeight.ValueMember = "elevation"
            cmbHeight.SelectedIndex = -1
            cmbLaborRateRmv.DataSource = MyDataSet.Tables(4)
            cmbLaborRateRmv.DisplayMember = "idLaborRate"
            cmbLaborRateRmv.ValueMember = "idLaborRate"
            cmbLaborRateRmv.SelectedIndex = -1
            cmbLaborRateII.DataSource = MyDataSet.Tables(4)
            cmbLaborRateII.DisplayMember = "idLaborRate"
            cmbLaborRateII.ValueMember = "idLaborRate"
            cmbLaborRateII.SelectedIndex = -1
            cmbLaborRatePnt.DataSource = MyDataSet.Tables(4)
            cmbLaborRatePnt.DisplayMember = "idLaborRate"
            cmbLaborRatePnt.ValueMember = "idLaborRate"
            cmbLaborRatePnt.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
    Public Function initializePpRow() As Boolean
        Try
            tblSystem = mtdFactor.llenarComboPpPntUnitRate(cmbSystem)
            _myDataSet.Tables.Add(tblSystem)

            tblInsType = mtdFactor.llenarComboPpInsUnitRate(cmbInsType)
            _myDataSet.Tables.Add(tblInsType)

            tblJkt = mtdFactor.llenarComboPpJacketUnitRate(cmbJacked)
            _myDataSet.Tables.Add(tblJkt)

            _myDataSet.Tables.Add(mtdElevation.llenarComboElvSCF(cmbHeight))

            mtdFactor.llenarComboLaporRate(cmbLaborRateRmv)
            mtdFactor.llenarComboLaporRate(cmbLaborRatePnt)
            mtdFactor.llenarComboLaporRate(cmbLaborRateII)
            _myDataSet.Tables.Add(mtdFactor.DataTableLaporRate)

            tblMatrialSize = mtdFactor.selectSizesMaterialPiping()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Property IsSelected As Boolean
        Get
            If _isSelected = Nothing Then
                _isSelected = False
            End If
            Return _isSelected
        End Get
        Set(value As Boolean)
            _isSelected = value
        End Set
    End Property

    Public Property RowIndex As Integer
        Get
            If RowIndex = Nothing Then
                RowIndex = -1
            End If
            Return _RowIndex
        End Get
        Set(value As Integer)
            _RowIndex = value
        End Set
    End Property

    Public Property IdDrawing As String
        Get
            If _idDrawing = "" Then
                Return "NULL"
            Else
                Return _idDrawing
            End If
            Return _idDrawing
        End Get
        Set(value As String)
            _idDrawing = value
        End Set
    End Property

    Public Property IdPipingAux As String
        Get
            Return _idPipingAux
        End Get
        Set(value As String)
            _idPipingAux = value
        End Set
    End Property

    Public Property ItemArray As String()
        Get
            Return _itemArray
        End Get
        Set(value As String())
            _itemArray = value
            cargarDatos()
        End Set
    End Property

    Private Sub btnRow_Click(sender As Object, e As EventArgs) Handles btnRow.Click
        If _isSelected Then
            btnRow.BackColor = SystemColors.ControlLightLight
            IsSelected = False
        Else
            btnRow.BackColor = Color.LightBlue
            IsSelected = True
        End If
    End Sub
    Public Function cargarDatos(ByVal dtRow As Data.DataRow) As Boolean
        Try
            ItemArray = {dtRow.ItemArray(0).ToString(), dtRow.ItemArray(1).ToString(), dtRow.ItemArray(2).ToString(), dtRow.ItemArray(3).ToString(), dtRow.ItemArray(4).ToString(), dtRow.ItemArray(5).ToString(), dtRow.ItemArray(6).ToString(), dtRow.ItemArray(7).ToString(), dtRow.ItemArray(8).ToString(), dtRow.ItemArray(9).ToString(), dtRow.ItemArray(10).ToString(), dtRow.ItemArray(11).ToString(), dtRow.ItemArray(12).ToString(), dtRow.ItemArray(13).ToString(), dtRow.ItemArray(14).ToString(), dtRow.ItemArray(15).ToString(), dtRow.ItemArray(16).ToString(), dtRow.ItemArray(17).ToString(), dtRow.ItemArray(18).ToString(), dtRow.ItemArray(19).ToString(), dtRow.ItemArray(20).ToString(), dtRow.ItemArray(21).ToString(), dtRow.ItemArray(22).ToString(), dtRow.ItemArray(23).ToString(), dtRow.ItemArray(24).ToString(), dtRow.ItemArray(25).ToString(), dtRow.ItemArray(26).ToString(), dtRow.ItemArray(27).ToString(), dtRow.ItemArray(28).ToString(), dtRow.ItemArray(29).ToString(), dtRow.ItemArray(30).ToString(), dtRow.ItemArray(31).ToString(), dtRow.ItemArray(32).ToString(), dtRow.ItemArray(33).ToString(), dtRow.ItemArray(34).ToString(), If(dtRow.ItemArray(35) = "True", "1", "0"), If(dtRow.ItemArray(36) = "True", "1", "0"), dtRow.ItemArray(37)}
            Return True
        Catch ex As Exception
            loadingData = False
            Return False
        End Try
    End Function
    Public Function cargarDatos() As Boolean
        Try
            loadingData = True
            IdPipingAux = ItemArray(0)
            txtIdPpDrawing.Text = ItemArray(1)
            txtLine.Text = ItemArray(2)
            txtSize.Text = ItemArray(3)
            If cmbInsType.FindString(ItemArray(4).ToString()) > -1 And ItemArray(4) <> "" Then
                cmbInsType.SelectedItem = cmbInsType.Items(cmbInsType.FindString(ItemArray(4).ToString()))
            End If
            txtThick.Text = ItemArray(5)
            If cmbSystem.FindString(ItemArray(6).ToString()) > -1 And ItemArray(6) <> "" Then
                cmbSystem.SelectedItem = cmbSystem.Items(cmbSystem.FindString(ItemArray(6).ToString()))
            End If
            If cmbPaintOption.FindString(ItemArray(7).ToString()) > -1 And ItemArray(7) <> "" Then
                cmbPaintOption.SelectedItem = cmbPaintOption.Items(cmbPaintOption.FindString(ItemArray(7).ToString()))
            End If
            If cmbJacked.FindString(ItemArray(8).ToString()) > -1 And ItemArray(8) <> "" Then
                cmbJacked.SelectedItem = cmbJacked.Items(cmbJacked.FindString(ItemArray(8).ToString()))
            End If
            If cmbHeight.FindString(ItemArray(9).ToString()) > -1 And ItemArray(9) <> "" Then
                cmbHeight.SelectedItem = cmbHeight.Items(cmbHeight.FindString(ItemArray(9).ToString()))
            End If
            If cmbLaborRateRmv.FindString(ItemArray(10).ToString()) > -1 And ItemArray(10) <> "" Then
                cmbLaborRateRmv.SelectedItem = cmbLaborRateRmv.Items(cmbLaborRateRmv.FindString(ItemArray(10).ToString()))
            End If
            txtLFtRmv.Text = ItemArray(11)
            If cmbLaborRatePnt.FindString(ItemArray(12).ToString()) > -1 And ItemArray(12) <> "" Then
                cmbLaborRatePnt.SelectedItem = cmbLaborRatePnt.Items(cmbLaborRatePnt.FindString(ItemArray(12).ToString()))
            End If
            txtLFtPnt.Text = ItemArray(13)
            txt90Pnt.Text = ItemArray(14)
            txt45Pnt.Text = ItemArray(15)
            txtTeePnt.Text = ItemArray(16)
            txtPairPnt.Text = ItemArray(17)
            txtValvePnt.Text = ItemArray(18)
            txtControlPnt.Text = ItemArray(19)
            txtWeldPnt.Text = ItemArray(20)
            If cmbLaborRateII.FindString(ItemArray(21).ToString()) > -1 And ItemArray(21) <> "" Then
                cmbLaborRateII.SelectedItem = cmbLaborRateII.Items(cmbLaborRateII.FindString(ItemArray(21).ToString()))
            End If
            txtLFtII.Text = ItemArray(22)
            txt90II.Text = ItemArray(23)
            txt45II.Text = ItemArray(24)
            txtBendII.Text = ItemArray(25)
            txtTeeII.Text = ItemArray(26)
            txtReductII.Text = ItemArray(27)
            txtCapsII.Text = ItemArray(28)
            txtPairII.Text = ItemArray(29)
            txtValveII.Text = ItemArray(30)
            txtControlII.Text = ItemArray(31)
            txtWeldII.Text = ItemArray(32)
            txtCutoutII.Text = ItemArray(33)
            txtSupportII.Text = ItemArray(34)
            chbAcm.Checked = If(ItemArray(35) = "1", True, False)
            chbST.Checked = If(ItemArray(36) = "1", True, False)
            _idDrawing = ItemArray(37)
            loadingData = False
            Return True
        Catch ex As Exception
            loadingData = False
            Return False
        End Try
    End Function

    Private Sub btnRow_KeyDown(sender As Object, e As KeyEventArgs) Handles btnRow.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.Dispose(True)
        End If
    End Sub
    Private Sub txtIdPpDrawing_Leave(sender As Object, e As EventArgs) Handles txtIdPpDrawing.Leave
        If txtIdPpDrawing.Text IsNot Nothing Then
            If soloNumero(txtIdPpDrawing.Text) Then
                ItemArray(1) = txtIdPpDrawing.Text
            Else
                txtIdPpDrawing.Text = ""
                ItemArray(1) = txtIdPpDrawing.Text
            End If
        End If
    End Sub
    Private Sub txtLine_Leave(sender As Object, e As EventArgs) Handles txtLine.Leave
        If txtLine.Text IsNot Nothing Then
            ItemArray(2) = txtLine.Text
        End If
    End Sub
    Private Sub txtSize_Leave(sender As Object, e As EventArgs) Handles txtSize.Leave
        If txtSize.Text IsNot Nothing Then
            If soloNumero(txtSize.Text) Then
                ItemArray(3) = txtSize.Text
            Else
                txtSize.Text = "0"
                ItemArray(3) = txtSize.Text
            End If
        End If
    End Sub
    Private Sub cmbInsType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInsType.SelectedIndexChanged
        If cmbInsType.SelectedItem IsNot Nothing Then
            ItemArray(4) = cmbInsType.SelectedItem.ToString()
        Else
            ItemArray(4) = "NULL"
        End If
    End Sub
    Private Sub txtThick_Leave(sender As Object, e As EventArgs) Handles txtThick.Leave
        If txtThick.Text IsNot Nothing Then
            If soloNumero(txtThick.Text) Then
                Dim arrayRows() As Data.DataRow = tblInsType.Select("thick = '" + txtThick.Text + "' and type= '" + cmbInsType.Text.ToString.Trim() + "'")
                If arrayRows.Length > 0 Then
                    ItemArray(5) = txtThick.Text
                Else
                    MessageBox.Show("The Thick inserted was not found.")
                    txtThick.Text = ""
                    ItemArray(5) = "NULL"
                End If
            Else
                txtThick.Text = ""
                ItemArray(5) = "NULL"
            End If
        End If
    End Sub
    Private Sub cmbSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSystem.SelectedIndexChanged
        Try
            Dim listRows() As Data.DataRow
            If cmbSystem.SelectedItem IsNot Nothing Then
                listRows = tblSystem.Select("systemPntPP = '" + cmbSystem.Text.ToString() + "'")
                ItemArray(6) = cmbSystem.SelectedItem.ToString()
            End If
            cmbPaintOption.Items.Clear()
#Disable Warning
            If listRows IsNot Nothing Then
                For Each row As Data.DataRow In listRows
                    If cmbPaintOption.FindString(row.ItemArray(1)) = -1 Then
                        cmbPaintOption.Items.Add(row.ItemArray(1))
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbPaintOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaintOption.SelectedIndexChanged
        If cmbPaintOption.SelectedItem IsNot Nothing Then
            ItemArray(7) = cmbPaintOption.SelectedItem.ToString()
        Else
            ItemArray(7) = "NULL"
        End If
    End Sub
    Private Sub cmbJacked_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJacked.SelectedIndexChanged
        If cmbJacked.SelectedItem IsNot Nothing Then
            Dim array() As String = cmbJacked.SelectedItem.ToString.Split("|")
            ItemArray(8) = array(0)
        Else
            ItemArray(8) = "NULL"
        End If
    End Sub
    Private Sub cmbHeight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHeight.SelectedIndexChanged
        If cmbHeight.SelectedItem IsNot Nothing Then
            ItemArray(9) = cmbHeight.SelectedItem.ToString()
        Else
            ItemArray(9) = "NULL"
        End If
    End Sub
    Private Sub cmbLaborRateRmv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborRateRmv.SelectedIndexChanged
        If cmbLaborRateRmv.SelectedItem IsNot Nothing Then
            ItemArray(10) = cmbLaborRateRmv.SelectedItem.ToString()
        Else
            ItemArray(10) = "NULL"
        End If
    End Sub
    Private Sub txtLFtRmv_Leave(sender As Object, e As EventArgs) Handles txtLFtRmv.Leave
        If txtLFtRmv.Text IsNot Nothing Then
            If soloNumero(txtLFtRmv.Text) Then
                ItemArray(11) = txtLFtRmv.Text
            Else
                txtLFtRmv.Text = "0"
                ItemArray(11) = txtLFtRmv.Text
            End If
        End If
    End Sub
    Private Sub cmbLaborRatePnt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborRatePnt.SelectedIndexChanged
        If cmbLaborRatePnt.SelectedItem IsNot Nothing Then
            ItemArray(12) = cmbLaborRatePnt.SelectedItem.ToString()
        Else
            ItemArray(12) = "NULL"
        End If
    End Sub
    Private Sub txtLFtPnt_Leave(sender As Object, e As EventArgs) Handles txtLFtPnt.Leave
        If txtLFtPnt.Text IsNot Nothing Then
            If soloNumero(txtLFtPnt.Text) Then
                ItemArray(13) = txtLFtPnt.Text
            Else
                txtLFtPnt.Text = "0"
                ItemArray(13) = txtLFtPnt.Text
            End If
        End If
    End Sub
    Private Sub txt90Pnt_Leave(sender As Object, e As EventArgs) Handles txt90Pnt.Leave
        If txt90Pnt.Text IsNot Nothing Then
            If soloNumero(txt90Pnt.Text) Then
                ItemArray(14) = txt90Pnt.Text
            Else
                txt90Pnt.Text = "0"
                ItemArray(14) = txt90Pnt.Text
            End If
        End If
    End Sub
    Private Sub txt45Pnt_Leave(sender As Object, e As EventArgs) Handles txt45Pnt.Leave
        If txt45Pnt.Text IsNot Nothing Then
            If soloNumero(txt45Pnt.Text) Then
                ItemArray(15) = txt45Pnt.Text
            Else
                txt45Pnt.Text = "0"
                ItemArray(15) = txt45Pnt.Text
            End If
        End If
    End Sub
    Private Sub txtTeePnt_Leave(sender As Object, e As EventArgs) Handles txtTeePnt.Leave
        If txtTeePnt.Text IsNot Nothing Then
            If soloNumero(txtTeePnt.Text) Then
                ItemArray(16) = txtTeePnt.Text
            Else
                txtTeePnt.Text = "0"
                ItemArray(16) = txtTeePnt.Text
            End If
        End If
    End Sub
    Private Sub txtPairPnt_Leave(sender As Object, e As EventArgs) Handles txtPairPnt.Leave
        If txtPairPnt.Text IsNot Nothing Then
            If soloNumero(txtPairPnt.Text) Then
                ItemArray(17) = txtPairPnt.Text
            Else
                txtPairPnt.Text = "0"
                ItemArray(17) = txtPairPnt.Text
            End If
        End If
    End Sub
    Private Sub txtValvePnt_Leave(sender As Object, e As EventArgs) Handles txtValvePnt.Leave
        If txtValvePnt.Text IsNot Nothing Then
            If soloNumero(txtValvePnt.Text) Then
                ItemArray(18) = txtValvePnt.Text
            Else
                txtValvePnt.Text = "0"
                ItemArray(18) = txtValvePnt.Text
            End If
        End If
    End Sub
    Private Sub txtControlPnt_Leave(sender As Object, e As EventArgs) Handles txtControlPnt.Leave
        If txtControlPnt.Text IsNot Nothing Then
            If soloNumero(txtControlPnt.Text) Then
                ItemArray(19) = txtControlPnt.Text
            Else
                txtControlPnt.Text = "0"
                ItemArray(19) = txtControlPnt.Text
            End If
        End If
    End Sub
    Private Sub txtWeldPnt_Leave(sender As Object, e As EventArgs) Handles txtWeldPnt.Leave
        If txtWeldPnt.Text IsNot Nothing Then
            If soloNumero(txtWeldPnt.Text) Then
                ItemArray(20) = txtWeldPnt.Text
            Else
                txtWeldPnt.Text = "0"
                ItemArray(20) = txtWeldPnt.Text
            End If
        End If
    End Sub
    Private Sub cmbLaborRateII_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborRateII.SelectedIndexChanged
        If cmbLaborRateII.SelectedItem IsNot Nothing Then
            ItemArray(21) = cmbLaborRateII.SelectedItem.ToString()
        Else
            ItemArray(21) = "NULL"
        End If
    End Sub
    Private Sub txtLFtII_Leave(sender As Object, e As EventArgs) Handles txtLFtII.Leave
        If txtLFtII.Text IsNot Nothing Then
            If soloNumero(txtLFtII.Text) Then
                ItemArray(22) = txtLFtII.Text
            Else
                txtLFtII.Text = "0"
                ItemArray(22) = txtLFtII.Text
            End If
        End If
    End Sub
    Private Sub txt90II_Leave(sender As Object, e As EventArgs) Handles txt90II.Leave
        If txt90II.Text IsNot Nothing Then
            If soloNumero(txt90II.Text) Then
                ItemArray(23) = txt90II.Text
            Else
                txt90II.Text = "0"
                ItemArray(23) = txt90II.Text
            End If
        End If
    End Sub
    Private Sub txt45II_Leave(sender As Object, e As EventArgs) Handles txt45II.Leave
        If txt45II.Text IsNot Nothing Then
            If soloNumero(txt45II.Text) Then
                ItemArray(24) = txt45II.Text
            Else
                txt45II.Text = "0"
                ItemArray(24) = txt45II.Text
            End If
        End If
    End Sub

    Private Sub txtBendII_Leave(sender As Object, e As EventArgs) Handles txtBendII.Leave
        If txtBendII.Text IsNot Nothing Then
            If soloNumero(txtBendII.Text) Then
                ItemArray(25) = txtBendII.Text
            Else
                txtBendII.Text = "0"
                ItemArray(25) = txtBendII.Text
            End If
        End If
    End Sub
    Private Sub txtTeeII_Leave(sender As Object, e As EventArgs) Handles txtTeeII.Leave
        If txtTeeII.Text IsNot Nothing Then
            If soloNumero(txtTeeII.Text) Then
                ItemArray(26) = txtTeeII.Text
            Else
                txtTeeII.Text = "0"
                ItemArray(26) = txtTeeII.Text
            End If
        End If
    End Sub
    Private Sub txtReductII_Leave(sender As Object, e As EventArgs) Handles txtReductII.Leave
        If txtReductII.Text IsNot Nothing Then
            If soloNumero(txtReductII.Text) Then
                ItemArray(27) = txtReductII.Text
            Else
                txtReductII.Text = "0"
                ItemArray(27) = txtReductII.Text
            End If
        End If
    End Sub
    Private Sub txtCapsII_Leave(sender As Object, e As EventArgs) Handles txtCapsII.Leave
        If txtCapsII.Text IsNot Nothing Then
            If soloNumero(txtCapsII.Text) Then
                ItemArray(28) = txtCapsII.Text
            Else
                txtCapsII.Text = "0"
                ItemArray(28) = txtCapsII.Text
            End If
        End If
    End Sub
    Private Sub txtPairII_Leave(sender As Object, e As EventArgs) Handles txtPairII.Leave
        If txtPairII.Text IsNot Nothing Then
            If soloNumero(txtPairII.Text) Then
                ItemArray(29) = txtPairII.Text
            Else
                txtPairII.Text = "0"
                ItemArray(29) = txtPairII.Text
            End If
        End If
    End Sub
    Private Sub txtValveII_Leave(sender As Object, e As EventArgs) Handles txtValveII.Leave
        If txtValveII.Text IsNot Nothing Then
            If soloNumero(txtValveII.Text) Then
                ItemArray(30) = txtValveII.Text
            Else
                txtValveII.Text = ""
                ItemArray(30) = txtValveII.Text
            End If
        End If
    End Sub
    Private Sub txtControlII_Leave(sender As Object, e As EventArgs) Handles txtControlII.Leave
        If txtControlII.Text IsNot Nothing Then
            If soloNumero(txtControlII.Text) Then
                ItemArray(31) = txtControlII.Text
            Else
                txtControlII.Text = "0"
                ItemArray(31) = txtControlII.Text
            End If
        End If
    End Sub
    Private Sub txtWeldII_Leave(sender As Object, e As EventArgs) Handles txtWeldII.Leave
        If txtWeldII.Text IsNot Nothing Then
            If soloNumero(txtWeldII.Text) Then
                ItemArray(32) = txtWeldII.Text
            Else
                txtWeldII.Text = "0"
                ItemArray(32) = txtWeldII.Text
            End If
        End If
    End Sub
    Private Sub txtCutoutII_Leave(sender As Object, e As EventArgs) Handles txtCutoutII.Leave
        If txtCutoutII.Text IsNot Nothing Then
            If soloNumero(txtCutoutII.Text) Then
                ItemArray(33) = txtCutoutII.Text
            Else
                txtCutoutII.Text = "0"
                ItemArray(33) = txtCutoutII.Text
            End If
        End If
    End Sub
    Private Sub txtSupportII_Leave(sender As Object, e As EventArgs) Handles txtSupportII.Leave
        If txtSupportII.Text IsNot Nothing Then
            If soloNumero(txtSupportII.Text) Then
                ItemArray(34) = txtSupportII.Text
            Else
                txtSupportII.Text = "0"
                ItemArray(34) = txtSupportII.Text
            End If
        End If
    End Sub
    Private Sub chbST_CheckedChanged(sender As Object, e As EventArgs) Handles chbST.CheckedChanged
        If chbST.Checked And loadingData = False Then
            lastSize = If(txtSize.Text <> "", CDec(txtSize.Text), 0)
            Dim arrayRows() As Data.DataRow = tblMatrialSize.Select("size > " + lastSize.ToString())
            If arrayRows.Length > 0 Then
                txtSize.Text = arrayRows(0).ItemArray(0)
                ItemArray(3) = txtSize.Text
            End If
            ItemArray(35) = "1"
        ElseIf Not chbST.Checked And loadingData = False Then
            If txtSize.Text <> "0" Then
                Dim arrayRows() As Data.DataRow = tblMatrialSize.Select("size < '" + txtSize.Text + "'")
                If arrayRows.Length > 0 Then
                    txtSize.Text = arrayRows((arrayRows.Length - 1)).Item(0).ToString()
                    lastSize = txtSize.Text
                    ItemArray(3) = txtSize.Text
                End If
            Else
                txtSize.Text = lastSize.ToString()
            End If
            ItemArray(3) = txtSize.Text
            ItemArray(35) = "0"
        End If
    End Sub
    Dim lastSize As Decimal = 0
    Private Sub chbAcm_CheckedChanged(sender As Object, e As EventArgs) Handles chbAcm.CheckedChanged
        If chbAcm.Checked Then
            ItemArray(36) = "1"
        Else
            ItemArray(36) = "0"
        End If
    End Sub
End Class
