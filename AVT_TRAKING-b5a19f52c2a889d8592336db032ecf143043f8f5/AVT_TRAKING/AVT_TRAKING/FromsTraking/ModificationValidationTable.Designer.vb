<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificationValidationTable
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pgbComplete = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chbEditModID = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sprFirstRow = New System.Windows.Forms.NumericUpDown()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.cmbDatos = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnSubirExcel = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpTags = New System.Windows.Forms.TabPage()
        Me.tblModificationScaffold = New System.Windows.Forms.DataGridView()
        Me.clmError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Foreman = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Erector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Truck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Forklift = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Trailer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Crane = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rope = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Passed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Elevator = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Build = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Travel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weather = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alarm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Safety = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stdBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Other = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpProducts = New System.Windows.Forms.TabPage()
        Me.tblProductSheet = New System.Windows.Forms.DataGridView()
        Me.clmErrorP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTagID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmModID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprFirstRow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tbpTags.SuspendLayout()
        CType(Me.tblModificationScaffold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpProducts.SuspendLayout()
        CType(Me.tblProductSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1197, 554)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.pgbComplete)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 527)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1189, 23)
        Me.Panel3.TabIndex = 3
        '
        'pgbComplete
        '
        Me.pgbComplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgbComplete.Location = New System.Drawing.Point(808, 0)
        Me.pgbComplete.Margin = New System.Windows.Forms.Padding(4)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(381, 23)
        Me.pgbComplete.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(74, 17)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Message:"
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.PictureBox4)
        Me.TitleBar.Controls.Add(Me.PictureBox3)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label2)
        Me.TitleBar.Controls.Add(Me.chbEditModID)
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Controls.Add(Me.sprFirstRow)
        Me.TitleBar.Controls.Add(Me.txtFecha)
        Me.TitleBar.Controls.Add(Me.cmbDatos)
        Me.TitleBar.Controls.Add(Me.btnSave)
        Me.TitleBar.Controls.Add(Me.btnSubirExcel)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleBar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TitleBar.Size = New System.Drawing.Size(1189, 103)
        Me.TitleBar.TabIndex = 1
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1140, 59)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(45, 41)
        Me.PictureBox4.TabIndex = 13
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(1101, 4)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(37, 32)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1143, 4)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(37, 32)
        Me.btnRestore.TabIndex = 11
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1147, 4)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(37, 32)
        Me.btnMaximize.TabIndex = 10
        Me.btnMaximize.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(4, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(324, 25)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ModificationValidationTable"
        '
        'chbEditModID
        '
        Me.chbEditModID.AutoSize = True
        Me.chbEditModID.Location = New System.Drawing.Point(683, 71)
        Me.chbEditModID.Margin = New System.Windows.Forms.Padding(4)
        Me.chbEditModID.Name = "chbEditModID"
        Me.chbEditModID.Size = New System.Drawing.Size(112, 21)
        Me.chbEditModID.TabIndex = 8
        Me.chbEditModID.Text = "Edit Mod ID"
        Me.chbEditModID.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(437, 78)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "First Row To Read"
        '
        'sprFirstRow
        '
        Me.sprFirstRow.Location = New System.Drawing.Point(587, 71)
        Me.sprFirstRow.Margin = New System.Windows.Forms.Padding(4)
        Me.sprFirstRow.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.sprFirstRow.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.sprFirstRow.Name = "sprFirstRow"
        Me.sprFirstRow.Size = New System.Drawing.Size(84, 24)
        Me.sprFirstRow.TabIndex = 5
        Me.sprFirstRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.sprFirstRow.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(245, 71)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(180, 24)
        Me.txtFecha.TabIndex = 4
        '
        'cmbDatos
        '
        Me.cmbDatos.DropDownHeight = 260
        Me.cmbDatos.FormattingEnabled = True
        Me.cmbDatos.IntegralHeight = False
        Me.cmbDatos.Location = New System.Drawing.Point(8, 71)
        Me.cmbDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDatos.Name = "cmbDatos"
        Me.cmbDatos.Size = New System.Drawing.Size(221, 25)
        Me.cmbDatos.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save1
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(980, 63)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 38)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnSubirExcel
        '
        Me.btnSubirExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubirExcel.FlatAppearance.BorderSize = 0
        Me.btnSubirExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSubirExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubirExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubirExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.upload2
        Me.btnSubirExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubirExcel.Location = New System.Drawing.Point(808, 64)
        Me.btnSubirExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubirExcel.Name = "btnSubirExcel"
        Me.btnSubirExcel.Size = New System.Drawing.Size(161, 38)
        Me.btnSubirExcel.TabIndex = 1
        Me.btnSubirExcel.Text = "Update Excel"
        Me.btnSubirExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubirExcel.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpTags)
        Me.TabControl1.Controls.Add(Me.tbpProducts)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(4, 115)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1189, 404)
        Me.TabControl1.TabIndex = 3
        '
        'tbpTags
        '
        Me.tbpTags.Controls.Add(Me.tblModificationScaffold)
        Me.tbpTags.Location = New System.Drawing.Point(4, 25)
        Me.tbpTags.Margin = New System.Windows.Forms.Padding(4)
        Me.tbpTags.Name = "tbpTags"
        Me.tbpTags.Padding = New System.Windows.Forms.Padding(4)
        Me.tbpTags.Size = New System.Drawing.Size(1181, 375)
        Me.tbpTags.TabIndex = 0
        Me.tbpTags.Text = "Tags"
        Me.tbpTags.UseVisualStyleBackColor = True
        '
        'tblModificationScaffold
        '
        Me.tblModificationScaffold.AllowUserToAddRows = False
        Me.tblModificationScaffold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.tblModificationScaffold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblModificationScaffold.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmError, Me.ModID, Me.TagNum, Me.WorkNum, Me.ReqComp, Me.RequestBy, Me.Foreman, Me.Erector, Me.DateModification, Me.Truck, Me.Forklift, Me.Trailer, Me.Crane, Me.Rope, Me.Passed, Me.Elevator, Me.Build, Me.Material, Me.Travel, Me.Weather, Me.Alarm, Me.Safety, Me.stdBy, Me.Other, Me.TotalHours, Me.Type, Me.Comment})
        Me.tblModificationScaffold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblModificationScaffold.Location = New System.Drawing.Point(4, 4)
        Me.tblModificationScaffold.Margin = New System.Windows.Forms.Padding(4)
        Me.tblModificationScaffold.Name = "tblModificationScaffold"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblModificationScaffold.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblModificationScaffold.RowHeadersWidth = 51
        Me.tblModificationScaffold.Size = New System.Drawing.Size(1173, 367)
        Me.tblModificationScaffold.TabIndex = 3
        '
        'clmError
        '
        Me.clmError.Frozen = True
        Me.clmError.HeaderText = "Error"
        Me.clmError.MinimumWidth = 6
        Me.clmError.Name = "clmError"
        Me.clmError.ReadOnly = True
        Me.clmError.Visible = False
        Me.clmError.Width = 54
        '
        'ModID
        '
        Me.ModID.Frozen = True
        Me.ModID.HeaderText = "ModID"
        Me.ModID.MinimumWidth = 6
        Me.ModID.Name = "ModID"
        Me.ModID.Width = 76
        '
        'TagNum
        '
        Me.TagNum.Frozen = True
        Me.TagNum.HeaderText = "TagNum"
        Me.TagNum.MinimumWidth = 6
        Me.TagNum.Name = "TagNum"
        Me.TagNum.Width = 89
        '
        'WorkNum
        '
        Me.WorkNum.HeaderText = "WorkNum"
        Me.WorkNum.MinimumWidth = 6
        Me.WorkNum.Name = "WorkNum"
        Me.WorkNum.Width = 96
        '
        'ReqComp
        '
        Me.ReqComp.HeaderText = "ReqComp"
        Me.ReqComp.MinimumWidth = 6
        Me.ReqComp.Name = "ReqComp"
        Me.ReqComp.Width = 98
        '
        'RequestBy
        '
        Me.RequestBy.HeaderText = "RequestBy"
        Me.RequestBy.MinimumWidth = 6
        Me.RequestBy.Name = "RequestBy"
        Me.RequestBy.Width = 103
        '
        'Foreman
        '
        Me.Foreman.HeaderText = "Foreman"
        Me.Foreman.MinimumWidth = 6
        Me.Foreman.Name = "Foreman"
        Me.Foreman.Width = 90
        '
        'Erector
        '
        Me.Erector.HeaderText = "Erector"
        Me.Erector.MinimumWidth = 6
        Me.Erector.Name = "Erector"
        Me.Erector.Width = 79
        '
        'DateModification
        '
        Me.DateModification.HeaderText = "DateModification"
        Me.DateModification.MinimumWidth = 6
        Me.DateModification.Name = "DateModification"
        Me.DateModification.Width = 137
        '
        'Truck
        '
        Me.Truck.HeaderText = "Truck"
        Me.Truck.MinimumWidth = 6
        Me.Truck.Name = "Truck"
        Me.Truck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Truck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Truck.Width = 70
        '
        'Forklift
        '
        Me.Forklift.HeaderText = "Forklift"
        Me.Forklift.MinimumWidth = 6
        Me.Forklift.Name = "Forklift"
        Me.Forklift.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Forklift.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Forklift.Width = 75
        '
        'Trailer
        '
        Me.Trailer.HeaderText = "Trailer"
        Me.Trailer.MinimumWidth = 6
        Me.Trailer.Name = "Trailer"
        Me.Trailer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Trailer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Trailer.Width = 75
        '
        'Crane
        '
        Me.Crane.HeaderText = "Crane"
        Me.Crane.MinimumWidth = 6
        Me.Crane.Name = "Crane"
        Me.Crane.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Crane.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Crane.Width = 72
        '
        'Rope
        '
        Me.Rope.HeaderText = "Rope"
        Me.Rope.MinimumWidth = 6
        Me.Rope.Name = "Rope"
        Me.Rope.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Rope.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Rope.Width = 70
        '
        'Passed
        '
        Me.Passed.HeaderText = "Passed"
        Me.Passed.MinimumWidth = 6
        Me.Passed.Name = "Passed"
        Me.Passed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Passed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Passed.Width = 83
        '
        'Elevator
        '
        Me.Elevator.HeaderText = "Elevator"
        Me.Elevator.MinimumWidth = 6
        Me.Elevator.Name = "Elevator"
        Me.Elevator.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Elevator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Elevator.Width = 86
        '
        'Build
        '
        Me.Build.HeaderText = "Build"
        Me.Build.MinimumWidth = 6
        Me.Build.Name = "Build"
        Me.Build.Width = 66
        '
        'Material
        '
        Me.Material.HeaderText = "Material"
        Me.Material.MinimumWidth = 6
        Me.Material.Name = "Material"
        Me.Material.Width = 84
        '
        'Travel
        '
        Me.Travel.HeaderText = "Travel"
        Me.Travel.MinimumWidth = 6
        Me.Travel.Name = "Travel"
        Me.Travel.Width = 75
        '
        'Weather
        '
        Me.Weather.HeaderText = "Weather"
        Me.Weather.MinimumWidth = 6
        Me.Weather.Name = "Weather"
        Me.Weather.Width = 87
        '
        'Alarm
        '
        Me.Alarm.HeaderText = "Alarm"
        Me.Alarm.MinimumWidth = 6
        Me.Alarm.Name = "Alarm"
        Me.Alarm.Width = 71
        '
        'Safety
        '
        Me.Safety.HeaderText = "Safety"
        Me.Safety.MinimumWidth = 6
        Me.Safety.Name = "Safety"
        Me.Safety.Width = 74
        '
        'stdBy
        '
        Me.stdBy.HeaderText = "stdBy"
        Me.stdBy.MinimumWidth = 6
        Me.stdBy.Name = "stdBy"
        Me.stdBy.Width = 70
        '
        'Other
        '
        Me.Other.HeaderText = "Other"
        Me.Other.MinimumWidth = 6
        Me.Other.Name = "Other"
        Me.Other.Width = 68
        '
        'TotalHours
        '
        Me.TotalHours.HeaderText = "Total Hours"
        Me.TotalHours.MinimumWidth = 6
        Me.TotalHours.Name = "TotalHours"
        Me.TotalHours.Width = 106
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.MinimumWidth = 6
        Me.Type.Name = "Type"
        Me.Type.Width = 68
        '
        'Comment
        '
        Me.Comment.HeaderText = "Comment"
        Me.Comment.MinimumWidth = 6
        Me.Comment.Name = "Comment"
        Me.Comment.Width = 93
        '
        'tbpProducts
        '
        Me.tbpProducts.Controls.Add(Me.tblProductSheet)
        Me.tbpProducts.Location = New System.Drawing.Point(4, 25)
        Me.tbpProducts.Margin = New System.Windows.Forms.Padding(4)
        Me.tbpProducts.Name = "tbpProducts"
        Me.tbpProducts.Padding = New System.Windows.Forms.Padding(4)
        Me.tbpProducts.Size = New System.Drawing.Size(1181, 375)
        Me.tbpProducts.TabIndex = 1
        Me.tbpProducts.Text = "List Product"
        Me.tbpProducts.UseVisualStyleBackColor = True
        '
        'tblProductSheet
        '
        Me.tblProductSheet.AllowUserToAddRows = False
        Me.tblProductSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblProductSheet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmErrorP, Me.clmTagID, Me.clmProductID, Me.clmQuantity, Me.clmModID})
        Me.tblProductSheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblProductSheet.Location = New System.Drawing.Point(4, 4)
        Me.tblProductSheet.Margin = New System.Windows.Forms.Padding(4)
        Me.tblProductSheet.Name = "tblProductSheet"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblProductSheet.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.tblProductSheet.RowHeadersWidth = 51
        Me.tblProductSheet.Size = New System.Drawing.Size(1173, 367)
        Me.tblProductSheet.TabIndex = 0
        '
        'clmErrorP
        '
        Me.clmErrorP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.clmErrorP.Frozen = True
        Me.clmErrorP.HeaderText = "Error"
        Me.clmErrorP.MinimumWidth = 6
        Me.clmErrorP.Name = "clmErrorP"
        Me.clmErrorP.ReadOnly = True
        Me.clmErrorP.Visible = False
        Me.clmErrorP.Width = 125
        '
        'clmTagID
        '
        Me.clmTagID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmTagID.HeaderText = "TagID"
        Me.clmTagID.MinimumWidth = 6
        Me.clmTagID.Name = "clmTagID"
        '
        'clmProductID
        '
        Me.clmProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmProductID.HeaderText = "ProductID"
        Me.clmProductID.MinimumWidth = 6
        Me.clmProductID.Name = "clmProductID"
        '
        'clmQuantity
        '
        Me.clmQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmQuantity.HeaderText = "Quantity"
        Me.clmQuantity.MinimumWidth = 6
        Me.clmQuantity.Name = "clmQuantity"
        '
        'clmModID
        '
        Me.clmModID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmModID.HeaderText = "ModID"
        Me.clmModID.MinimumWidth = 6
        Me.clmModID.Name = "clmModID"
        Me.clmModID.Visible = False
        '
        'ModificationValidationTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1197, 554)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ModificationValidationTable"
        Me.Text = "ModificationValidationTable"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprFirstRow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpTags.ResumeLayout(False)
        CType(Me.tblModificationScaffold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpProducts.ResumeLayout(False)
        CType(Me.tblProductSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pgbComplete As ProgressBar
    Friend WithEvents lblMessage As Label
    Friend WithEvents TitleBar As Panel
    Public WithEvents txtFecha As TextBox
    Friend WithEvents cmbDatos As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnSubirExcel As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbpTags As TabPage
    Friend WithEvents tblModificationScaffold As DataGridView
    Friend WithEvents tbpProducts As TabPage
    Friend WithEvents tblProductSheet As DataGridView
    Friend WithEvents clmError As DataGridViewTextBoxColumn
    Friend WithEvents ModID As DataGridViewTextBoxColumn
    Friend WithEvents TagNum As DataGridViewTextBoxColumn
    Friend WithEvents WorkNum As DataGridViewTextBoxColumn
    Friend WithEvents ReqComp As DataGridViewTextBoxColumn
    Friend WithEvents RequestBy As DataGridViewTextBoxColumn
    Friend WithEvents Foreman As DataGridViewTextBoxColumn
    Friend WithEvents Erector As DataGridViewTextBoxColumn
    Friend WithEvents DateModification As DataGridViewTextBoxColumn
    Friend WithEvents Truck As DataGridViewCheckBoxColumn
    Friend WithEvents Forklift As DataGridViewCheckBoxColumn
    Friend WithEvents Trailer As DataGridViewCheckBoxColumn
    Friend WithEvents Crane As DataGridViewCheckBoxColumn
    Friend WithEvents Rope As DataGridViewCheckBoxColumn
    Friend WithEvents Passed As DataGridViewCheckBoxColumn
    Friend WithEvents Elevator As DataGridViewCheckBoxColumn
    Friend WithEvents Build As DataGridViewTextBoxColumn
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Travel As DataGridViewTextBoxColumn
    Friend WithEvents Weather As DataGridViewTextBoxColumn
    Friend WithEvents Alarm As DataGridViewTextBoxColumn
    Friend WithEvents Safety As DataGridViewTextBoxColumn
    Friend WithEvents stdBy As DataGridViewTextBoxColumn
    Friend WithEvents Other As DataGridViewTextBoxColumn
    Friend WithEvents TotalHours As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents sprFirstRow As NumericUpDown
    Friend WithEvents chbEditModID As CheckBox
    Friend WithEvents clmErrorP As DataGridViewTextBoxColumn
    Friend WithEvents clmTagID As DataGridViewTextBoxColumn
    Friend WithEvents clmProductID As DataGridViewTextBoxColumn
    Friend WithEvents clmQuantity As DataGridViewTextBoxColumn
    Friend WithEvents clmModID As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
End Class
