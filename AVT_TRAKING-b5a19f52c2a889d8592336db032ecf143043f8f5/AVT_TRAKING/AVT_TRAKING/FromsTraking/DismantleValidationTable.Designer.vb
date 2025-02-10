<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DismantleValidationTable
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
    'No lo modifique connSQL el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sprFirstRow = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdateExcel = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.cmbDatos = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblDismantleSC = New System.Windows.Forms.DataGridView()
        Me.clmErrorD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTagID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWorkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Foreman = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Erector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RentStopDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DismantleDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Truck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Forklift = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Trailer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Crane = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rope = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Passed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Elevator = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Dismantle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Travel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weather = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alarm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Safety = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stdBY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Other = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pgbComplete = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprFirstRow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblDismantleSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1067, 554)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.Label2)
        Me.TitleBar.Controls.Add(Me.PictureBox4)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.PictureBox2)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Controls.Add(Me.sprFirstRow)
        Me.TitleBar.Controls.Add(Me.btnSave)
        Me.TitleBar.Controls.Add(Me.btnUpdateExcel)
        Me.TitleBar.Controls.Add(Me.txtFecha)
        Me.TitleBar.Controls.Add(Me.cmbDatos)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleBar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(1059, 90)
        Me.TitleBar.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(299, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "DismantleValidationTable"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox4.Location = New System.Drawing.Point(975, 4)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 38)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(979, 4)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(33, 30)
        Me.btnRestore.TabIndex = 14
        Me.btnRestore.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox2.Location = New System.Drawing.Point(1001, 44)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(53, 38)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1020, 4)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(35, 38)
        Me.btnMaximize.TabIndex = 1
        Me.btnMaximize.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(377, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "First Row To Read"
        '
        'sprFirstRow
        '
        Me.sprFirstRow.Location = New System.Drawing.Point(524, 57)
        Me.sprFirstRow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sprFirstRow.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.sprFirstRow.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.sprFirstRow.Name = "sprFirstRow"
        Me.sprFirstRow.Size = New System.Drawing.Size(84, 24)
        Me.sprFirstRow.TabIndex = 2
        Me.sprFirstRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.sprFirstRow.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save1
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(792, 49)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 38)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdateExcel
        '
        Me.btnUpdateExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateExcel.FlatAppearance.BorderSize = 0
        Me.btnUpdateExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.upload2
        Me.btnUpdateExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateExcel.Location = New System.Drawing.Point(631, 48)
        Me.btnUpdateExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdateExcel.Name = "btnUpdateExcel"
        Me.btnUpdateExcel.Size = New System.Drawing.Size(159, 38)
        Me.btnUpdateExcel.TabIndex = 3
        Me.btnUpdateExcel.Text = "Update Excel"
        Me.btnUpdateExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateExcel.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(195, 55)
        Me.txtFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(173, 24)
        Me.txtFecha.TabIndex = 1
        '
        'cmbDatos
        '
        Me.cmbDatos.DropDownWidth = 260
        Me.cmbDatos.FormattingEnabled = True
        Me.cmbDatos.Location = New System.Drawing.Point(12, 55)
        Me.cmbDatos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbDatos.Name = "cmbDatos"
        Me.cmbDatos.Size = New System.Drawing.Size(173, 25)
        Me.cmbDatos.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 102)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1059, 411)
        Me.Panel2.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1059, 411)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tblDismantleSC)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1051, 382)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Dismantle"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tblDismantleSC
        '
        Me.tblDismantleSC.AllowUserToAddRows = False
        Me.tblDismantleSC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tblDismantleSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDismantleSC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmErrorD, Me.clmTagID, Me.clmWorkNum, Me.ReqComp, Me.RequestBy, Me.Foreman, Me.Erector, Me.RentStopDate, Me.DismantleDate, Me.Truck, Me.Forklift, Me.Trailer, Me.Crane, Me.Rope, Me.Passed, Me.Elevator, Me.Dismantle, Me.Material, Me.Travel, Me.Weather, Me.Alarm, Me.Safety, Me.stdBY, Me.Other, Me.TotalHours, Me.Comments})
        Me.tblDismantleSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDismantleSC.Location = New System.Drawing.Point(4, 4)
        Me.tblDismantleSC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblDismantleSC.Name = "tblDismantleSC"
        Me.tblDismantleSC.RowHeadersWidth = 51
        Me.tblDismantleSC.Size = New System.Drawing.Size(1043, 374)
        Me.tblDismantleSC.TabIndex = 0
        '
        'clmErrorD
        '
        Me.clmErrorD.Frozen = True
        Me.clmErrorD.HeaderText = "Error"
        Me.clmErrorD.MinimumWidth = 6
        Me.clmErrorD.Name = "clmErrorD"
        Me.clmErrorD.ReadOnly = True
        Me.clmErrorD.Visible = False
        Me.clmErrorD.Width = 54
        '
        'clmTagID
        '
        Me.clmTagID.Frozen = True
        Me.clmTagID.HeaderText = "TagID"
        Me.clmTagID.MinimumWidth = 6
        Me.clmTagID.Name = "clmTagID"
        Me.clmTagID.Width = 74
        '
        'clmWorkNum
        '
        Me.clmWorkNum.HeaderText = "WorkNum"
        Me.clmWorkNum.MinimumWidth = 6
        Me.clmWorkNum.Name = "clmWorkNum"
        Me.clmWorkNum.Width = 96
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
        'RentStopDate
        '
        Me.RentStopDate.HeaderText = "Rent Stop Date"
        Me.RentStopDate.MinimumWidth = 6
        Me.RentStopDate.Name = "RentStopDate"
        Me.RentStopDate.Width = 117
        '
        'DismantleDate
        '
        Me.DismantleDate.HeaderText = "Dismantle Date"
        Me.DismantleDate.MinimumWidth = 6
        Me.DismantleDate.Name = "DismantleDate"
        Me.DismantleDate.Width = 118
        '
        'Truck
        '
        Me.Truck.HeaderText = "Truck"
        Me.Truck.MinimumWidth = 6
        Me.Truck.Name = "Truck"
        Me.Truck.Width = 47
        '
        'Forklift
        '
        Me.Forklift.HeaderText = "Forklift"
        Me.Forklift.MinimumWidth = 6
        Me.Forklift.Name = "Forklift"
        Me.Forklift.Width = 52
        '
        'Trailer
        '
        Me.Trailer.HeaderText = "Trailer"
        Me.Trailer.MinimumWidth = 6
        Me.Trailer.Name = "Trailer"
        Me.Trailer.Width = 52
        '
        'Crane
        '
        Me.Crane.HeaderText = "Crane"
        Me.Crane.MinimumWidth = 6
        Me.Crane.Name = "Crane"
        Me.Crane.Width = 49
        '
        'Rope
        '
        Me.Rope.HeaderText = "Rope"
        Me.Rope.MinimumWidth = 6
        Me.Rope.Name = "Rope"
        Me.Rope.Width = 47
        '
        'Passed
        '
        Me.Passed.HeaderText = "Passed"
        Me.Passed.MinimumWidth = 6
        Me.Passed.Name = "Passed"
        Me.Passed.Width = 60
        '
        'Elevator
        '
        Me.Elevator.HeaderText = "Elevator"
        Me.Elevator.MinimumWidth = 6
        Me.Elevator.Name = "Elevator"
        Me.Elevator.Width = 63
        '
        'Dismantle
        '
        Me.Dismantle.HeaderText = "Dismantle"
        Me.Dismantle.MinimumWidth = 6
        Me.Dismantle.Name = "Dismantle"
        Me.Dismantle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dismantle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Dismantle.Width = 73
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
        'stdBY
        '
        Me.stdBY.HeaderText = "stdBY"
        Me.stdBY.MinimumWidth = 6
        Me.stdBY.Name = "stdBY"
        Me.stdBY.Width = 72
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
        Me.TotalHours.HeaderText = "TotalHours"
        Me.TotalHours.MinimumWidth = 6
        Me.TotalHours.Name = "TotalHours"
        Me.TotalHours.Width = 103
        '
        'Comments
        '
        Me.Comments.HeaderText = "Comments"
        Me.Comments.MinimumWidth = 6
        Me.Comments.Name = "Comments"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.pgbComplete)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Location = New System.Drawing.Point(4, 521)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1059, 29)
        Me.Panel3.TabIndex = 2
        '
        'pgbComplete
        '
        Me.pgbComplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgbComplete.Location = New System.Drawing.Point(723, 0)
        Me.pgbComplete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(336, 29)
        Me.pgbComplete.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(74, 17)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Message:"
        '
        'DismantleValidationTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "DismantleValidationTable"
        Me.Text = "DimantleValidationTable"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprFirstRow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblDismantleSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents cmbDatos As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents sprFirstRow As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdateExcel As Button
    Friend WithEvents tblDismantleSC As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents pgbComplete As ProgressBar
    Friend WithEvents lblMessage As Label
    Friend WithEvents clmErrorD As DataGridViewTextBoxColumn
    Friend WithEvents clmTagID As DataGridViewTextBoxColumn
    Friend WithEvents clmWorkNum As DataGridViewTextBoxColumn
    Friend WithEvents ReqComp As DataGridViewTextBoxColumn
    Friend WithEvents RequestBy As DataGridViewTextBoxColumn
    Friend WithEvents Foreman As DataGridViewTextBoxColumn
    Friend WithEvents Erector As DataGridViewTextBoxColumn
    Friend WithEvents RentStopDate As DataGridViewTextBoxColumn
    Friend WithEvents DismantleDate As DataGridViewTextBoxColumn
    Friend WithEvents Truck As DataGridViewCheckBoxColumn
    Friend WithEvents Forklift As DataGridViewCheckBoxColumn
    Friend WithEvents Trailer As DataGridViewCheckBoxColumn
    Friend WithEvents Crane As DataGridViewCheckBoxColumn
    Friend WithEvents Rope As DataGridViewCheckBoxColumn
    Friend WithEvents Passed As DataGridViewCheckBoxColumn
    Friend WithEvents Elevator As DataGridViewCheckBoxColumn
    Friend WithEvents Dismantle As DataGridViewTextBoxColumn
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Travel As DataGridViewTextBoxColumn
    Friend WithEvents Weather As DataGridViewTextBoxColumn
    Friend WithEvents Alarm As DataGridViewTextBoxColumn
    Friend WithEvents Safety As DataGridViewTextBoxColumn
    Friend WithEvents stdBY As DataGridViewTextBoxColumn
    Friend WithEvents Other As DataGridViewTextBoxColumn
    Friend WithEvents TotalHours As DataGridViewTextBoxColumn
    Friend WithEvents Comments As DataGridViewTextBoxColumn
    Public WithEvents txtFecha As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents Label2 As Label
End Class
