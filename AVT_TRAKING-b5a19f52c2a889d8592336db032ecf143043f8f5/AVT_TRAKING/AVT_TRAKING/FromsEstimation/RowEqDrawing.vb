Public Class RowEqDrawing
    Dim mtdElevation As New ElevationEstimation
    Dim mtdFactor As New MetodosFactor
    Dim tblSystemPaint As New Data.DataTable
    Dim tblElevation As New Data.DataTable
    Dim tblInsType As New Data.DataTable
    Dim tblJacket As New Data.DataTable
    Dim tblLabor As New Data.DataTable
    Public textSelected As String = ""
    Dim rowIndex As Integer = 0
    Private isSelectRow As Boolean = False
    Dim itemArray() As String = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
    Private _idDrawing As String = ""
    Private _idEquipment As String = ""
    Private _idEquipmentAux As String = ""
    Private _eqDescription As String = ""
    Private _heightEq As String = ""
    Private _systemPaint As String = ""
    Private _optionPaint As String = ""
    Private _insType As String = ""
    Private _thick As String = ""
    Private _jacket As String = ""
    Private _remIns As Boolean = False
    Private _laborRateRmv As String = ""
    Private _sqrFtRmv As String = "0"
    Private _laborRatePnt As String = ""
    Private _sqrFtPnt As String = "0"
    Private _laborRateII As String = ""
    Private _sqrFtII As String = "0"
    Private _bavel As String = "0"
    Private _cutOut As String = "0"
    Private _acm As Boolean = False
    Public Property IdEquipment As String
        Get
            Return _idEquipment
            itemArray(1) = _idEquipment
        End Get
        Set(value As String)
            _idEquipment = value
            itemArray(1) = _idEquipment
        End Set
    End Property
    Public Property IdEquipmentAux As String
        Get
            Return _idEquipmentAux
            itemArray(0) = _idEquipmentAux
        End Get
        Set(value As String)
            _idEquipmentAux = value
            itemArray(0) = _idEquipmentAux
        End Set
    End Property
    Public Property EqDescription As String
        Get
            Return _eqDescription
            itemArray(2) = _eqDescription
        End Get
        Set(value As String)
            _eqDescription = value
            itemArray(2) = _eqDescription
        End Set
    End Property
    Public Property HeightEq As String
        Get
            Return _heightEq
            itemArray(3) = _heightEq
        End Get
        Set(value As String)
            _heightEq = value
            itemArray(3) = _heightEq
        End Set
    End Property
    Public Property SystemPaint As String
        Get
            Return _systemPaint
            itemArray(4) = _systemPaint
        End Get
        Set(value As String)
            _systemPaint = value
            itemArray(4) = _systemPaint
        End Set
    End Property
    Public Property OptionPaint As String
        Get
            Return _optionPaint
            itemArray(5) = _optionPaint
        End Get
        Set(value As String)
            _optionPaint = value
            itemArray(5) = _optionPaint
        End Set
    End Property
    Public Property InsType As String
        Get
            Return _insType
            itemArray(6) = _insType
        End Get
        Set(value As String)
            _insType = value
            itemArray(6) = _insType
        End Set
    End Property
    Public Property Thick As String
        Get
            Return _thick
            itemArray(7) = _thick
        End Get
        Set(value As String)
            _thick = value
            itemArray(7) = _thick
        End Set
    End Property
    Public Property Jacket As String
        Get
            Return _jacket
            itemArray(8) = _jacket
        End Get
        Set(value As String)
            _jacket = value
            itemArray(8) = _jacket
        End Set
    End Property
    Public Property RemIns As Boolean
        Get
            Return _remIns
            itemArray(9) = If(_remIns, "Yes", "No")
        End Get
        Set(value As Boolean)
            _remIns = value
            itemArray(9) = If(_remIns, "Yes", "No")
        End Set
    End Property
    Public Property LaborRateRmv As String
        Get
            Return _laborRateRmv
            itemArray(10) = _laborRateRmv
        End Get
        Set(value As String)
            _laborRateRmv = value
            itemArray(10) = _laborRateRmv
        End Set
    End Property
    Public Property SqrFtRmv As String
        Get
            Return _sqrFtRmv
            itemArray(11) = _sqrFtRmv
        End Get
        Set(value As String)
            _sqrFtRmv = value
            itemArray(11) = _sqrFtRmv
        End Set
    End Property
    Public Property LaborRatePnt As String
        Get
            Return _laborRatePnt
            itemArray(12) = _laborRatePnt
        End Get
        Set(value As String)
            _laborRatePnt = value
            itemArray(12) = _laborRatePnt
        End Set
    End Property
    Public Property SqrFtPnt As String
        Get
            Return _sqrFtPnt
            itemArray(13) = _sqrFtPnt
        End Get
        Set(value As String)
            _sqrFtPnt = value
            itemArray(13) = _sqrFtPnt
        End Set
    End Property
    Public Property LaborRateII As String
        Get
            Return _laborRateII
            itemArray(14) = _laborRateII
        End Get
        Set(value As String)
            _laborRateII = value
            itemArray(14) = _laborRateII
        End Set
    End Property
    Public Property SqrFtII As String
        Get
            Return _sqrFtII
            itemArray(15) = _sqrFtII
        End Get
        Set(value As String)
            _sqrFtII = value
            itemArray(15) = _sqrFtII
        End Set
    End Property
    Public Property ItemArray1 As String()
        Get
            Return itemArray
        End Get
        Set(value As String())
            itemArray = value
            cargardatos()
        End Set
    End Property
    Public Property Bavel As String
        Get
            Return _bavel
            itemArray(16) = _bavel
        End Get
        Set(value As String)
            _bavel = value
            itemArray(16) = _bavel
        End Set
    End Property
    Public Property CutOut As String
        Get
            Return _cutOut
            itemArray(17) = _cutOut
        End Get
        Set(value As String)
            _cutOut = value
            itemArray(17) = _cutOut
        End Set
    End Property
    Public Property ACM As String
        Get
            Return _acm
            itemArray(18) = If(_acm, "Yes", "No")
        End Get
        Set(value As String)
            _acm = value
            itemArray(18) = If(_acm, "Yes", "No")
        End Set
    End Property
    Public Property RowIndex1 As Integer
        Get
            Return rowIndex
        End Get
        Set(value As Integer)
            rowIndex = value
        End Set
    End Property
    Public Property isSelectRow1 As Boolean
        Get
            Return isSelectRow
        End Get
        Set(value As Boolean)
            isSelectRow = value
        End Set
    End Property
    Public Property IdDrawing As String
        Get
            Return _idDrawing
        End Get
        Set(value As String)
            _idDrawing = value
        End Set
    End Property



    ''' <summary>
    ''' Asigna los valores al itemArray propio del formulario en base al oreden de la consulta de la tabla equipmentEst de la base de datos
    ''' </summary>
    ''' <param name="dtRow">DataRow con itemArray con 18 valores</param>
    Public Sub cargardatos(ByVal dtRow As Data.DataRow)
        itemArray = {dtRow.ItemArray(0).ToString(), dtRow.ItemArray(1).ToString(), dtRow.ItemArray(2).ToString(), dtRow.ItemArray(3).ToString(), dtRow.ItemArray(4).ToString(), dtRow.ItemArray(5).ToString(), dtRow.ItemArray(6).ToString(), dtRow.ItemArray(7).ToString(), dtRow.ItemArray(8).ToString(), If(dtRow.ItemArray(9) = "Yes" Or dtRow.ItemArray(9) = "True", "Yes", "No"), dtRow.ItemArray(10).ToString(), dtRow.ItemArray(11).ToString(), dtRow.ItemArray(12).ToString(), dtRow.ItemArray(13).ToString(), dtRow.ItemArray(14).ToString(), dtRow.ItemArray(15).ToString(), dtRow.ItemArray(16).ToString(), dtRow.ItemArray(17).ToString(), If(dtRow.ItemArray(18) = "Yes" Or dtRow.ItemArray(18) = "True", "Yes", "No")}
        _idEquipmentAux = dtRow.ItemArray(0)
        _idEquipment = dtRow.ItemArray(1)
        _eqDescription = dtRow.ItemArray(2)
        _heightEq = dtRow.ItemArray(3)
        _systemPaint = dtRow.ItemArray(4)
        _optionPaint = dtRow.ItemArray(5)
        _insType = dtRow.ItemArray(6)
        _thick = dtRow.ItemArray(7)
        _jacket = dtRow.ItemArray(8)
        _remIns = If(dtRow.ItemArray(9) = "True", True, False)
        _laborRateRmv = dtRow.ItemArray(10)
        _sqrFtRmv = dtRow.ItemArray(11)
        _laborRatePnt = dtRow.ItemArray(12)
        _sqrFtPnt = dtRow.ItemArray(13)
        _laborRateII = dtRow.ItemArray(14)
        _sqrFtII = dtRow.ItemArray(15)
        _bavel = dtRow.ItemArray(16)
        _cutOut = dtRow.ItemArray(17)
        _acm = If(dtRow.ItemArray(18) = "True", True, False)
    End Sub
    ''' <summary>
    ''' Asigna los valores en la los valores en los elementos del formulario en base al itemArray asignado
    ''' </summary>
    Public Sub cargardatos()
        txtIdEquipment.Text = ItemArray1(1)
        IdEquipmentAux = ItemArray1(0)
        txtEqDescription.Text = ItemArray1(2)
        Dim Aux = cmbHeight.FindString(ItemArray1(3).ToString())
        If cmbHeight.FindString(ItemArray1(3).ToString()) > -1 And ItemArray1(2) <> "" Then
            cmbHeight.SelectedItem = cmbHeight.Items(cmbHeight.FindString(ItemArray1(3).ToString()))
        End If
        If cmbSystem.FindString(ItemArray1(4).ToString()) > -1 And ItemArray1(4) <> "" Then
            cmbSystem.SelectedItem = cmbSystem.Items(cmbSystem.FindString(ItemArray1(4).ToString()))
        End If
        If cmbPaintOption.FindString(ItemArray1(5).ToString()) > -1 And ItemArray1(5) <> "" Then
            cmbPaintOption.SelectedItem = cmbPaintOption.Items(cmbPaintOption.FindString(ItemArray1(5).ToString()))
        End If
        If cmbInstType.FindString(ItemArray1(6).ToString()) > -1 And ItemArray1(6) <> "" Then
            cmbInstType.SelectedItem = cmbInstType.Items(cmbInstType.FindString(ItemArray1(6).ToString()))
        End If
        txtThick.Text = ItemArray1(7).ToString
        If cmbJkt.FindString(ItemArray1(8).ToString()) > -1 And ItemArray1(8) > "" Then
            cmbJkt.SelectedItem = cmbJkt.Items(cmbJkt.FindString(ItemArray1(8).ToString()))
        End If
        chbRemIns.Checked = If(ItemArray1(9) = "Yes", True, False)
        If cmbLaborRateRmv.FindString(ItemArray1(10).ToString) > -1 And ItemArray1(10) <> "" Then
            cmbLaborRateRmv.SelectedItem = cmbLaborRateRmv.Items(cmbLaborRateRmv.FindString(ItemArray1(10).ToString))
        End If
        txtSqrFtRmv.Text = ItemArray1(11).ToString()
        If cmbLaborRatePnt.FindString(ItemArray1(12).ToString) > -1 And ItemArray1(12) <> "" Then
            cmbLaborRatePnt.SelectedItem = cmbLaborRatePnt.Items(cmbLaborRatePnt.FindString(ItemArray1(12).ToString()))
        End If
        txtSqrFtPnt.Text = ItemArray1(13).ToString()
        If cmbLaborRateII.FindString(ItemArray1(14).ToString) > -1 And ItemArray1(14) <> "" Then
            cmbLaborRateII.SelectedItem = cmbLaborRateII.Items(cmbLaborRateII.FindString(ItemArray1(14).ToString))
        End If
        txtSqrFtII.Text = ItemArray1(15)
        txtBevel.Text = ItemArray1(16)
        txtCutout.Text = ItemArray1(17)
        chbACM.Checked = If(ItemArray1(18) = "Yes", True, False)
    End Sub
    Private Sub RowEqDrawing_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbHeight.SizeHeight = lytMain.Height - 5
        cmbSystem.SizeHeight = lytMain.Height - 5
        cmbPaintOption.SizeHeight = lytMain.Height - 5
        cmbInstType.SizeHeight = lytMain.Height - 5
        cmbJkt.SizeHeight = lytMain.Height - 5
        cmbLaborRateRmv.SizeHeight = ((lytLaborRates.Height) / 3) - 22
        cmbLaborRatePnt.SizeHeight = ((lytLaborRates.Height) / 3) - 22
        cmbLaborRateII.SizeHeight = ((lytLaborRates.Height) / 3) - 22
        tblElevation = mtdElevation.llenarComboElvSCF(cmbHeight)
        tblSystemPaint = mtdFactor.llenarComboEqPntUnitRate(cmbSystem)
        tblInsType = mtdFactor.llenarComboEqInsUnitRate(cmbInstType)
        tblJacket = mtdFactor.llenarComboEqJacketUnitRate(cmbJkt)
        mtdFactor.llenarComboLaporRate(cmbLaborRateRmv)
        mtdFactor.llenarComboLaporRate(cmbLaborRatePnt)
        tblLabor = mtdFactor.llenarComboLaporRate(cmbLaborRateII)
        cargardatos()
    End Sub
    Private Sub TableLayoutPanel1_Resize(sender As Object, e As EventArgs) Handles lytMain.Resize
        cmbHeight.SizeHeight = lytMain.Height - 5
        cmbSystem.SizeHeight = lytMain.Height - 5
        cmbPaintOption.SizeHeight = lytMain.Height - 5
        cmbInstType.SizeHeight = lytMain.Height - 5
        cmbJkt.SizeHeight = lytMain.Height - 5
        cmbLaborRateRmv.SizeHeight = ((lytLaborRates.Height) / 3) - 22
        cmbLaborRatePnt.SizeHeight = ((lytLaborRates.Height) / 3) - 22
        cmbLaborRateII.SizeHeight = ((lytLaborRates.Height) / 3) - 22
    End Sub
    Private Sub textEndEdit_Leave(sender As Object, e As EventArgs) Handles txtCutout.Leave, txtBevel.Leave, txtThick.Leave, txtSqrFtRmv.Leave, txtSqrFtPnt.Leave, txtSqrFtII.Leave, txtCutout.Leave, txtBevel.Leave, txtIdEquipment.Leave, txtEqDescription.Leave
        Select Case textSelected
            Case "idEquipment"
                If txtIdEquipment.Text IsNot Nothing Then
                    If soloNumero(txtIdEquipment.Text) Then
                        IdEquipment = txtIdEquipment.Text
                    Else
                        txtIdEquipment.Text = IdEquipment
                    End If
                End If
            Case "description"
                If txtEqDescription.Text IsNot Nothing Then
                    EqDescription = txtEqDescription.Text
                End If
            Case "thick"
                If txtThick.Text IsNot Nothing Then
                    If soloNumero(txtThick.Text) And txtThick.Text <> "" Then
                        Dim listRows() As Data.DataRow = tblInsType.Select("type = '" + InsType + "' and thick = '" + txtThick.Text + "'")
                        If listRows.Length > 0 Then
                            Thick = txtThick.Text
                        Else
                            MessageBox.Show("This Thick is not found please insert a diferent Thinck.", "Importan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Thick = ""
                            txtThick.Text = ""
                        End If
                    Else
                        txtThick.Text = Thick
                    End If
                End If
            Case "sqrRmv"
                If txtSqrFtRmv.Text IsNot Nothing Then
                    If soloNumero(txtSqrFtRmv.Text) Then
                        SqrFtRmv = txtSqrFtRmv.Text
                    Else
                        txtSqrFtRmv.Text = SqrFtRmv
                    End If
                End If
            Case "sqrPnt"
                If txtSqrFtPnt.Text IsNot Nothing Then
                    If soloNumero(txtSqrFtPnt.Text) Then
                        SqrFtPnt = txtSqrFtPnt.Text
                    Else
                        txtSqrFtPnt.Text = SqrFtPnt
                    End If
                End If
            Case "sqrII"
                If txtSqrFtII.Text IsNot Nothing Then
                    If soloNumero(txtSqrFtII.Text) Then
                        SqrFtII = txtSqrFtII.Text
                    Else
                        txtSqrFtII.Text = SqrFtII
                    End If
                End If
            Case "bevel"
                If txtBevel.Text IsNot Nothing Then
                    If soloNumero(txtBevel.Text) Then
                        Bavel = txtBevel.Text
                    Else
                        txtBevel.Text = Bavel
                    End If
                End If
            Case "cutout"
                If txtCutout.Text IsNot Nothing Then
                    If soloNumero(txtCutout.Text) Then
                        CutOut = txtCutout.Text
                    Else
                        txtCutout.Text = CutOut
                    End If
                End If
        End Select
    End Sub
    Private Sub txtIdEquipment_Enter(sender As Object, e As EventArgs) Handles txtIdEquipment.Enter
        textSelected = "idEquipment"
    End Sub
    Private Sub txtEqDescription_Enter(sender As Object, e As EventArgs) Handles txtEqDescription.Enter
        textSelected = "description"
    End Sub
    Private Sub txtThick_Enter(sender As Object, e As EventArgs) Handles txtThick.Enter
        textSelected = "thick"
    End Sub
    Private Sub txtSqrFtRmv_Enter(sender As Object, e As EventArgs) Handles txtSqrFtRmv.Enter
        textSelected = "sqrRmv"
    End Sub
    Private Sub txtSqrFtPnt_Enter(sender As Object, e As EventArgs) Handles txtSqrFtPnt.Enter
        textSelected = "sqrPnt"
    End Sub
    Private Sub txtSqrFtII_Enter(sender As Object, e As EventArgs) Handles txtSqrFtII.Enter
        textSelected = "sqrII"
    End Sub
    Private Sub txtBevel_Enter(sender As Object, e As EventArgs) Handles txtBevel.Enter
        textSelected = "bevel"
    End Sub
    Private Sub txtCutout_Enter(sender As Object, e As EventArgs) Handles txtCutout.Enter
        textSelected = "cutout"
    End Sub
    Private Sub cmbSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSystem.SelectedIndexChanged
        Try
            Dim listRows() As Data.DataRow
            If cmbSystem.SelectedItem IsNot Nothing Then
                SystemPaint = cmbSystem.SelectedItem.ToString()
                listRows = tblSystemPaint.Select("systemPntEq = '" + cmbSystem.SelectedItem.ToString() + "'")
            Else
                SystemPaint = ""
            End If
            cmbPaintOption.Items.Clear()
#Disable Warning
            If listRows IsNot Nothing Then
                For Each row As Data.DataRow In listRows
                    cmbPaintOption.Items.Add(row.ItemArray(1))
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbHeight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHeight.SelectedIndexChanged
        If cmbHeight.SelectedItem IsNot Nothing Then
            HeightEq = cmbHeight.SelectedItem.ToString()
        Else
            HeightEq = ""
        End If
    End Sub
    Private Sub cmbInstType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInstType.SelectedIndexChanged
        Try
            If cmbInstType.SelectedItem IsNot Nothing Then
                InsType = cmbInstType.SelectedItem
            Else
                InsType = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbPaintOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaintOption.SelectedIndexChanged
        If cmbPaintOption.SelectedItem IsNot Nothing Then
            OptionPaint = cmbPaintOption.SelectedItem.ToString()
        Else
            OptionPaint = ""
        End If
    End Sub
    Private Sub cmbJkt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJkt.SelectedIndexChanged
        Try
            If cmbJkt.SelectedItem IsNot Nothing Then
                Jacket = cmbJkt.SelectedItem.ToString()
            Else
                Jacket = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub chbRemIns_CheckedChanged(sender As Object, e As EventArgs) Handles chbRemIns.CheckedChanged
        RemIns = chbRemIns.Checked()
    End Sub
    Private Sub chbACM_CheckedChanged(sender As Object, e As EventArgs) Handles chbACM.CheckedChanged
        ACM = chbACM.Checked()
    End Sub
    Private Sub cmbLaborRateRmv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborRateRmv.SelectedIndexChanged
        If cmbLaborRateRmv.SelectedItem IsNot Nothing Then
            LaborRateRmv = cmbLaborRateRmv.SelectedItem.ToString()
        Else
            LaborRateRmv = ""
        End If
    End Sub
    Private Sub cmbLaborRatePnt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborRatePnt.SelectedIndexChanged
        If cmbLaborRatePnt.SelectedItem IsNot Nothing Then
            LaborRatePnt = cmbLaborRatePnt.SelectedItem.ToString()
        Else
            LaborRatePnt = ""
        End If
    End Sub
    Private Sub cmbLaborRateII_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLaborRateII.SelectedIndexChanged
        If cmbLaborRateII.SelectedItem IsNot Nothing Then
            LaborRateII = cmbLaborRateII.SelectedItem.ToString()
        Else
            LaborRateII = ""
        End If
    End Sub
    Private Sub btnRow_Click(sender As Object, e As EventArgs) Handles btnRow.Click
        If btnRow.BackColor = Color.LightBlue Then
            btnRow.BackColor = Color.White
            isSelectRow = False
        Else
            btnRow.BackColor = Color.LightBlue
            isSelectRow = True
        End If
    End Sub
    Private Sub btnRow_KeyDown(sender As Object, e As KeyEventArgs) Handles btnRow.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.Close()
        End If
    End Sub


End Class