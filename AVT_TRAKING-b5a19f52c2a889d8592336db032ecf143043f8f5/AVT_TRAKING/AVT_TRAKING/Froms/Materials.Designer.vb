<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Materials
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tblMaterial = New System.Windows.Forms.DataGridView()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCancelOrder = New System.Windows.Forms.Button()
        Me.btnUpdateOrder = New System.Windows.Forms.Button()
        Me.btnDeleteOrder = New System.Windows.Forms.Button()
        Me.sprPrice = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOrderSave = New System.Windows.Forms.Button()
        Me.chbOrden = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaOrden = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.sprCantidadOrden = New System.Windows.Forms.NumericUpDown()
        Me.sprPricioOrden = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.sprTamanio = New System.Windows.Forms.NumericUpDown()
        Me.cmbUnidadDeMedida = New System.Windows.Forms.ComboBox()
        Me.txtDMaterial = New System.Windows.Forms.TextBox()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.tblMaterialAndOrders = New System.Windows.Forms.DataGridView()
        Me.btnUpdateMareialData = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnCancelMaterial = New System.Windows.Forms.Button()
        Me.chbEnableMaterial = New System.Windows.Forms.CheckBox()
        Me.txtNumeroMaterial = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.btnUpdateMaterial = New System.Windows.Forms.Button()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.txtNameMaterials = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSaveMaterial = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnCancelVendor = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSearchVendedor = New System.Windows.Forms.TextBox()
        Me.txtNumeroVendedor = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnUpdateVendor = New System.Windows.Forms.Button()
        Me.chbEnableVendor = New System.Windows.Forms.CheckBox()
        Me.tblVendor = New System.Windows.Forms.DataGridView()
        Me.btnSaveVendor = New System.Windows.Forms.Button()
        Me.txtDescripcionVendedor = New System.Windows.Forms.TextBox()
        Me.txtNombreVendedor = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.tblMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.sprPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.sprCantidadOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPricioOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprTamanio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblMaterialAndOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.tblVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblMaterial
        '
        Me.tblMaterial.AllowUserToAddRows = False
        Me.tblMaterial.AllowUserToDeleteRows = False
        Me.tblMaterial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblMaterial.Location = New System.Drawing.Point(271, 87)
        Me.tblMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.tblMaterial.MultiSelect = False
        Me.tblMaterial.Name = "tblMaterial"
        Me.tblMaterial.ReadOnly = True
        Me.tblMaterial.RowHeadersWidth = 62
        Me.tblMaterial.RowTemplate.Height = 28
        Me.tblMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblMaterial.Size = New System.Drawing.Size(471, 291)
        Me.tblMaterial.TabIndex = 7
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(15, 8)
        Me.btnMenu.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(67, 21)
        Me.btnMenu.TabIndex = 2
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.ForeColor = System.Drawing.Color.Red
        Me.Button5.Location = New System.Drawing.Point(727, 8)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(48, 21)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Exit"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnCancelOrder)
        Me.TabPage2.Controls.Add(Me.btnUpdateOrder)
        Me.TabPage2.Controls.Add(Me.btnDeleteOrder)
        Me.TabPage2.Controls.Add(Me.sprPrice)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.sprTamanio)
        Me.TabPage2.Controls.Add(Me.cmbUnidadDeMedida)
        Me.TabPage2.Controls.Add(Me.txtDMaterial)
        Me.TabPage2.Controls.Add(Me.txtRM)
        Me.TabPage2.Controls.Add(Me.tblMaterialAndOrders)
        Me.TabPage2.Controls.Add(Me.btnUpdateMareialData)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtSearch)
        Me.TabPage2.Controls.Add(Me.txtDescripcion)
        Me.TabPage2.Controls.Add(Me.txtTipo)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(761, 403)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Materials bills"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.Location = New System.Drawing.Point(669, 297)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(72, 41)
        Me.btnCancelOrder.TabIndex = 16
        Me.btnCancelOrder.Text = "Cancel"
        Me.btnCancelOrder.UseVisualStyleBackColor = True
        '
        'btnUpdateOrder
        '
        Me.btnUpdateOrder.Location = New System.Drawing.Point(669, 245)
        Me.btnUpdateOrder.Name = "btnUpdateOrder"
        Me.btnUpdateOrder.Size = New System.Drawing.Size(72, 41)
        Me.btnUpdateOrder.TabIndex = 15
        Me.btnUpdateOrder.Text = "Update"
        Me.btnUpdateOrder.UseVisualStyleBackColor = True
        '
        'btnDeleteOrder
        '
        Me.btnDeleteOrder.Location = New System.Drawing.Point(669, 350)
        Me.btnDeleteOrder.Name = "btnDeleteOrder"
        Me.btnDeleteOrder.Size = New System.Drawing.Size(73, 40)
        Me.btnDeleteOrder.TabIndex = 17
        Me.btnDeleteOrder.Text = "Delete"
        Me.btnDeleteOrder.UseVisualStyleBackColor = True
        '
        'sprPrice
        '
        Me.sprPrice.DecimalPlaces = 2
        Me.sprPrice.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprPrice.Location = New System.Drawing.Point(351, 86)
        Me.sprPrice.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.sprPrice.Name = "sprPrice"
        Me.sprPrice.Size = New System.Drawing.Size(120, 20)
        Me.sprPrice.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(284, 89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Price"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnOrderSave)
        Me.GroupBox1.Controls.Add(Me.chbOrden)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaOrden)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.sprCantidadOrden)
        Me.GroupBox1.Controls.Add(Me.sprPricioOrden)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(477, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 234)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Order"
        '
        'btnOrderSave
        '
        Me.btnOrderSave.Enabled = False
        Me.btnOrderSave.Location = New System.Drawing.Point(89, 186)
        Me.btnOrderSave.Name = "btnOrderSave"
        Me.btnOrderSave.Size = New System.Drawing.Size(75, 33)
        Me.btnOrderSave.TabIndex = 13
        Me.btnOrderSave.Text = "Add"
        Me.btnOrderSave.UseVisualStyleBackColor = True
        '
        'chbOrden
        '
        Me.chbOrden.AutoSize = True
        Me.chbOrden.Location = New System.Drawing.Point(225, 33)
        Me.chbOrden.Name = "chbOrden"
        Me.chbOrden.Size = New System.Drawing.Size(48, 17)
        Me.chbOrden.TabIndex = 9
        Me.chbOrden.Text = "New"
        Me.chbOrden.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Price"
        '
        'dtpFechaOrden
        '
        Me.dtpFechaOrden.CustomFormat = "yyyy-MM-dd"
        Me.dtpFechaOrden.Enabled = False
        Me.dtpFechaOrden.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaOrden.Location = New System.Drawing.Point(78, 111)
        Me.dtpFechaOrden.Name = "dtpFechaOrden"
        Me.dtpFechaOrden.Size = New System.Drawing.Size(155, 20)
        Me.dtpFechaOrden.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 77)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Quantity"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 116)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Date"
        '
        'sprCantidadOrden
        '
        Me.sprCantidadOrden.DecimalPlaces = 2
        Me.sprCantidadOrden.Enabled = False
        Me.sprCantidadOrden.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprCantidadOrden.Location = New System.Drawing.Point(78, 73)
        Me.sprCantidadOrden.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.sprCantidadOrden.Name = "sprCantidadOrden"
        Me.sprCantidadOrden.Size = New System.Drawing.Size(130, 20)
        Me.sprCantidadOrden.TabIndex = 11
        '
        'sprPricioOrden
        '
        Me.sprPricioOrden.DecimalPlaces = 2
        Me.sprPricioOrden.Enabled = False
        Me.sprPricioOrden.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprPricioOrden.Location = New System.Drawing.Point(78, 34)
        Me.sprPricioOrden.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.sprPricioOrden.Name = "sprPricioOrden"
        Me.sprPricioOrden.Size = New System.Drawing.Size(130, 20)
        Me.sprPricioOrden.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Total"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTotal.Location = New System.Drawing.Point(120, 148)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 28)
        Me.lblTotal.TabIndex = 32
        Me.lblTotal.Text = "0.00"
        '
        'sprTamanio
        '
        Me.sprTamanio.AutoSize = True
        Me.sprTamanio.DecimalPlaces = 2
        Me.sprTamanio.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprTamanio.Location = New System.Drawing.Point(350, 19)
        Me.sprTamanio.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.sprTamanio.Name = "sprTamanio"
        Me.sprTamanio.Size = New System.Drawing.Size(120, 20)
        Me.sprTamanio.TabIndex = 4
        '
        'cmbUnidadDeMedida
        '
        Me.cmbUnidadDeMedida.FormattingEnabled = True
        Me.cmbUnidadDeMedida.Items.AddRange(New Object() {"Each", "Foot", "Yard", "Galon", "Ounce", "LB", "Square foot"})
        Me.cmbUnidadDeMedida.Location = New System.Drawing.Point(114, 117)
        Me.cmbUnidadDeMedida.Name = "cmbUnidadDeMedida"
        Me.cmbUnidadDeMedida.Size = New System.Drawing.Size(121, 21)
        Me.cmbUnidadDeMedida.TabIndex = 3
        '
        'txtDMaterial
        '
        Me.txtDMaterial.Location = New System.Drawing.Point(114, 20)
        Me.txtDMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDMaterial.Name = "txtDMaterial"
        Me.txtDMaterial.Size = New System.Drawing.Size(121, 20)
        Me.txtDMaterial.TabIndex = 1
        '
        'txtRM
        '
        Me.txtRM.Location = New System.Drawing.Point(112, 67)
        Me.txtRM.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRM.Name = "txtRM"
        Me.txtRM.Size = New System.Drawing.Size(123, 20)
        Me.txtRM.TabIndex = 2
        '
        'tblMaterialAndOrders
        '
        Me.tblMaterialAndOrders.AllowUserToAddRows = False
        Me.tblMaterialAndOrders.AllowUserToDeleteRows = False
        Me.tblMaterialAndOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblMaterialAndOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMaterialAndOrders.Location = New System.Drawing.Point(11, 244)
        Me.tblMaterialAndOrders.Margin = New System.Windows.Forms.Padding(2)
        Me.tblMaterialAndOrders.MultiSelect = False
        Me.tblMaterialAndOrders.Name = "tblMaterialAndOrders"
        Me.tblMaterialAndOrders.ReadOnly = True
        Me.tblMaterialAndOrders.RowHeadersWidth = 62
        Me.tblMaterialAndOrders.RowTemplate.Height = 28
        Me.tblMaterialAndOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblMaterialAndOrders.Size = New System.Drawing.Size(653, 146)
        Me.tblMaterialAndOrders.TabIndex = 20
        '
        'btnUpdateMareialData
        '
        Me.btnUpdateMareialData.Location = New System.Drawing.Point(14, 153)
        Me.btnUpdateMareialData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateMareialData.Name = "btnUpdateMareialData"
        Me.btnUpdateMareialData.Size = New System.Drawing.Size(70, 42)
        Me.btnUpdateMareialData.TabIndex = 8
        Me.btnUpdateMareialData.Text = "Update"
        Me.btnUpdateMareialData.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 206)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(297, 204)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(174, 20)
        Me.txtSearch.TabIndex = 14
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(350, 118)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(121, 20)
        Me.txtDescripcion.TabIndex = 7
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(351, 50)
        Me.txtTipo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(119, 20)
        Me.txtTipo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(284, 122)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Descripcion"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(286, 52)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(288, 22)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Size"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 121)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Unit of measurement"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 71)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Resource Material"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(29, 24)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Material"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnCancelMaterial)
        Me.TabPage1.Controls.Add(Me.chbEnableMaterial)
        Me.TabPage1.Controls.Add(Me.txtNumeroMaterial)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbVendedor)
        Me.TabPage1.Controls.Add(Me.btnUpdateMaterial)
        Me.TabPage1.Controls.Add(Me.txtFiltro)
        Me.TabPage1.Controls.Add(Me.tblMaterial)
        Me.TabPage1.Controls.Add(Me.txtNameMaterials)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.btnSaveMaterial)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(761, 403)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Materials"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnCancelMaterial
        '
        Me.btnCancelMaterial.Location = New System.Drawing.Point(155, 255)
        Me.btnCancelMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCancelMaterial.Name = "btnCancelMaterial"
        Me.btnCancelMaterial.Size = New System.Drawing.Size(81, 35)
        Me.btnCancelMaterial.TabIndex = 9
        Me.btnCancelMaterial.Text = "Cancel"
        Me.btnCancelMaterial.UseVisualStyleBackColor = True
        '
        'chbEnableMaterial
        '
        Me.chbEnableMaterial.AutoSize = True
        Me.chbEnableMaterial.Location = New System.Drawing.Point(177, 146)
        Me.chbEnableMaterial.Name = "chbEnableMaterial"
        Me.chbEnableMaterial.Size = New System.Drawing.Size(59, 17)
        Me.chbEnableMaterial.TabIndex = 4
        Me.chbEnableMaterial.Text = "Enable"
        Me.chbEnableMaterial.UseVisualStyleBackColor = True
        '
        'txtNumeroMaterial
        '
        Me.txtNumeroMaterial.Location = New System.Drawing.Point(99, 20)
        Me.txtNumeroMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNumeroMaterial.Name = "txtNumeroMaterial"
        Me.txtNumeroMaterial.Size = New System.Drawing.Size(137, 20)
        Me.txtNumeroMaterial.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Number"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.Location = New System.Drawing.Point(99, 109)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(137, 21)
        Me.cmbVendedor.TabIndex = 3
        '
        'btnUpdateMaterial
        '
        Me.btnUpdateMaterial.Location = New System.Drawing.Point(155, 186)
        Me.btnUpdateMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateMaterial.Name = "btnUpdateMaterial"
        Me.btnUpdateMaterial.Size = New System.Drawing.Size(81, 35)
        Me.btnUpdateMaterial.TabIndex = 8
        Me.btnUpdateMaterial.Text = "Update"
        Me.btnUpdateMaterial.UseVisualStyleBackColor = True
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(369, 48)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(144, 20)
        Me.txtFiltro.TabIndex = 6
        '
        'txtNameMaterials
        '
        Me.txtNameMaterials.Location = New System.Drawing.Point(99, 62)
        Me.txtNameMaterials.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNameMaterials.Name = "txtNameMaterials"
        Me.txtNameMaterials.Size = New System.Drawing.Size(137, 20)
        Me.txtNameMaterials.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(310, 51)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Search"
        '
        'btnSaveMaterial
        '
        Me.btnSaveMaterial.Location = New System.Drawing.Point(36, 186)
        Me.btnSaveMaterial.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSaveMaterial.Name = "btnSaveMaterial"
        Me.btnSaveMaterial.Size = New System.Drawing.Size(79, 35)
        Me.btnSaveMaterial.TabIndex = 5
        Me.btnSaveMaterial.Text = "Add"
        Me.btnSaveMaterial.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 112)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vendor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(33, 65)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Name"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 33)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(769, 429)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnCancelVendor)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtSearchVendedor)
        Me.TabPage3.Controls.Add(Me.txtNumeroVendedor)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.btnUpdateVendor)
        Me.TabPage3.Controls.Add(Me.chbEnableVendor)
        Me.TabPage3.Controls.Add(Me.tblVendor)
        Me.TabPage3.Controls.Add(Me.btnSaveVendor)
        Me.TabPage3.Controls.Add(Me.txtDescripcionVendedor)
        Me.TabPage3.Controls.Add(Me.txtNombreVendedor)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(761, 403)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Vendor"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnCancelVendor
        '
        Me.btnCancelVendor.Location = New System.Drawing.Point(118, 245)
        Me.btnCancelVendor.Name = "btnCancelVendor"
        Me.btnCancelVendor.Size = New System.Drawing.Size(76, 36)
        Me.btnCancelVendor.TabIndex = 26
        Me.btnCancelVendor.Text = "Cancel"
        Me.btnCancelVendor.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(282, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Search"
        '
        'txtSearchVendedor
        '
        Me.txtSearchVendedor.Location = New System.Drawing.Point(346, 22)
        Me.txtSearchVendedor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSearchVendedor.Name = "txtSearchVendedor"
        Me.txtSearchVendedor.Size = New System.Drawing.Size(135, 20)
        Me.txtSearchVendedor.TabIndex = 24
        '
        'txtNumeroVendedor
        '
        Me.txtNumeroVendedor.Location = New System.Drawing.Point(85, 22)
        Me.txtNumeroVendedor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNumeroVendedor.Name = "txtNumeroVendedor"
        Me.txtNumeroVendedor.Size = New System.Drawing.Size(108, 20)
        Me.txtNumeroVendedor.TabIndex = 23
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(21, 26)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Number"
        '
        'btnUpdateVendor
        '
        Me.btnUpdateVendor.Location = New System.Drawing.Point(118, 187)
        Me.btnUpdateVendor.Name = "btnUpdateVendor"
        Me.btnUpdateVendor.Size = New System.Drawing.Size(75, 32)
        Me.btnUpdateVendor.TabIndex = 19
        Me.btnUpdateVendor.Text = "Update"
        Me.btnUpdateVendor.UseVisualStyleBackColor = True
        '
        'chbEnableVendor
        '
        Me.chbEnableVendor.AutoSize = True
        Me.chbEnableVendor.Location = New System.Drawing.Point(85, 139)
        Me.chbEnableVendor.Name = "chbEnableVendor"
        Me.chbEnableVendor.Size = New System.Drawing.Size(59, 17)
        Me.chbEnableVendor.TabIndex = 18
        Me.chbEnableVendor.Text = "Enable"
        Me.chbEnableVendor.UseVisualStyleBackColor = True
        '
        'tblVendor
        '
        Me.tblVendor.AllowUserToAddRows = False
        Me.tblVendor.AllowUserToDeleteRows = False
        Me.tblVendor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblVendor.Location = New System.Drawing.Point(227, 59)
        Me.tblVendor.Margin = New System.Windows.Forms.Padding(2)
        Me.tblVendor.MultiSelect = False
        Me.tblVendor.Name = "tblVendor"
        Me.tblVendor.ReadOnly = True
        Me.tblVendor.RowHeadersWidth = 62
        Me.tblVendor.RowTemplate.Height = 28
        Me.tblVendor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblVendor.Size = New System.Drawing.Size(512, 340)
        Me.tblVendor.TabIndex = 17
        '
        'btnSaveVendor
        '
        Me.btnSaveVendor.Location = New System.Drawing.Point(24, 187)
        Me.btnSaveVendor.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSaveVendor.Name = "btnSaveVendor"
        Me.btnSaveVendor.Size = New System.Drawing.Size(68, 32)
        Me.btnSaveVendor.TabIndex = 15
        Me.btnSaveVendor.Text = "Add"
        Me.btnSaveVendor.UseVisualStyleBackColor = True
        '
        'txtDescripcionVendedor
        '
        Me.txtDescripcionVendedor.Location = New System.Drawing.Point(85, 98)
        Me.txtDescripcionVendedor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescripcionVendedor.Name = "txtDescripcionVendedor"
        Me.txtDescripcionVendedor.Size = New System.Drawing.Size(109, 20)
        Me.txtDescripcionVendedor.TabIndex = 14
        '
        'txtNombreVendedor
        '
        Me.txtNombreVendedor.Location = New System.Drawing.Point(85, 56)
        Me.txtNombreVendedor.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNombreVendedor.Name = "txtNombreVendedor"
        Me.txtNombreVendedor.Size = New System.Drawing.Size(108, 20)
        Me.txtNombreVendedor.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 103)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Descripcion"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 61)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Name"
        '
        'Materials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 468)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnMenu)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Materials"
        Me.Text = "Materials"
        CType(Me.tblMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.sprPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.sprCantidadOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprPricioOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprTamanio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblMaterialAndOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.tblVendor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tblMaterial As DataGridView
    Friend WithEvents btnMenu As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnUpdateMareialData As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnUpdateMaterial As Button
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents txtNameMaterials As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnSaveMaterial As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tblMaterialAndOrders As DataGridView
    Friend WithEvents sprPricioOrden As NumericUpDown
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents sprCantidadOrden As NumericUpDown
    Friend WithEvents txtNumeroMaterial As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbVendedor As ComboBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents tblVendor As DataGridView
    Friend WithEvents btnSaveVendor As Button
    Friend WithEvents txtDescripcionVendedor As TextBox
    Friend WithEvents txtNombreVendedor As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnUpdateVendor As Button
    Friend WithEvents chbEnableVendor As CheckBox
    Friend WithEvents txtNumeroVendedor As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSearchVendedor As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpFechaOrden As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnOrderSave As Button
    Friend WithEvents chbOrden As CheckBox
    Friend WithEvents chbEnableMaterial As CheckBox
    Friend WithEvents Label20 As Label
    Public WithEvents txtDescripcion As TextBox
    Public WithEvents txtTipo As TextBox
    Public WithEvents txtRM As TextBox
    Public WithEvents txtDMaterial As TextBox
    Public WithEvents sprTamanio As NumericUpDown
    Public WithEvents cmbUnidadDeMedida As ComboBox
    Friend WithEvents sprPrice As NumericUpDown
    Friend WithEvents btnDeleteOrder As Button
    Friend WithEvents btnUpdateOrder As Button
    Friend WithEvents btnCancelVendor As Button
    Friend WithEvents btnCancelMaterial As Button
    Friend WithEvents btnCancelOrder As Button
End Class
