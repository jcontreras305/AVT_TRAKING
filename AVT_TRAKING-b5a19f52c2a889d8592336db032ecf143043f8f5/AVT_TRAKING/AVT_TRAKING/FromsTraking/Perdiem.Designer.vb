<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Perdiem
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSalida = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnFindExcel = New System.Windows.Forms.Button()
        Me.sprExcelRow = New System.Windows.Forms.NumericUpDown()
        Me.btnRefreshPerdiem = New System.Windows.Forms.Button()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblPerDiem = New System.Windows.Forms.DataGridView()
        Me.StatusCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubJobNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostDistribution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayOfWeek1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegularHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OverTimeHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtherHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtherHoursType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdjustmentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdjustmentAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeductionNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatchNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprExcelRow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblPerDiem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(983, 542)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtSalida)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnFindExcel)
        Me.Panel1.Controls.Add(Me.sprExcelRow)
        Me.Panel1.Controls.Add(Me.btnRefreshPerdiem)
        Me.Panel1.Controls.Add(Me.dtpStartDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 64)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(975, 83)
        Me.Panel1.TabIndex = 0
        '
        'txtSalida
        '
        Me.txtSalida.AutoSize = True
        Me.txtSalida.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSalida.Location = New System.Drawing.Point(12, 58)
        Me.txtSalida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.Size = New System.Drawing.Size(67, 16)
        Me.txtSalida.TabIndex = 6
        Me.txtSalida.Text = "Message:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(463, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Start Row Excel:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Start Date"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox1.Location = New System.Drawing.Point(920, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 41)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'btnFindExcel
        '
        Me.btnFindExcel.FlatAppearance.BorderSize = 0
        Me.btnFindExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnFindExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFindExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnFindExcel.Location = New System.Drawing.Point(676, 2)
        Me.btnFindExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFindExcel.Name = "btnFindExcel"
        Me.btnFindExcel.Size = New System.Drawing.Size(155, 50)
        Me.btnFindExcel.TabIndex = 3
        Me.btnFindExcel.Text = "Find Excel"
        Me.btnFindExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFindExcel.UseVisualStyleBackColor = True
        '
        'sprExcelRow
        '
        Me.sprExcelRow.Location = New System.Drawing.Point(597, 16)
        Me.sprExcelRow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sprExcelRow.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.sprExcelRow.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.sprExcelRow.Name = "sprExcelRow"
        Me.sprExcelRow.Size = New System.Drawing.Size(71, 22)
        Me.sprExcelRow.TabIndex = 2
        Me.sprExcelRow.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnRefreshPerdiem
        '
        Me.btnRefreshPerdiem.FlatAppearance.BorderSize = 0
        Me.btnRefreshPerdiem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnRefreshPerdiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshPerdiem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshPerdiem.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefreshPerdiem.Image = Global.AVT_TRAKING.My.Resources.Resources.refresh
        Me.btnRefreshPerdiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshPerdiem.Location = New System.Drawing.Point(332, 6)
        Me.btnRefreshPerdiem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRefreshPerdiem.Name = "btnRefreshPerdiem"
        Me.btnRefreshPerdiem.Size = New System.Drawing.Size(121, 38)
        Me.btnRefreshPerdiem.TabIndex = 1
        Me.btnRefreshPerdiem.Text = "Refresh"
        Me.btnRefreshPerdiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefreshPerdiem.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(101, 17)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(223, 22)
        Me.dtpStartDate.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 155)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(975, 383)
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
        Me.TabControl1.Size = New System.Drawing.Size(975, 383)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.tblPerDiem)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(967, 354)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Per-Diem"
        '
        'tblPerDiem
        '
        Me.tblPerDiem.AllowUserToAddRows = False
        Me.tblPerDiem.AllowUserToDeleteRows = False
        Me.tblPerDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPerDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPerDiem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StatusCode, Me.Company, Me.EmployeeNumber, Me.WeekNumber, Me.JobNumber, Me.SubJobNumber, Me.CostDistribution, Me.CostType, Me.DayOfWeek1, Me.RegularHours, Me.OverTimeHours, Me.OtherHours, Me.OtherHoursType, Me.AdjustmentType, Me.AdjustmentAmount, Me.DeductionNumber, Me.BatchNumber, Me.CheckType})
        Me.tblPerDiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPerDiem.Location = New System.Drawing.Point(4, 4)
        Me.tblPerDiem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPerDiem.Name = "tblPerDiem"
        Me.tblPerDiem.ReadOnly = True
        Me.tblPerDiem.RowHeadersWidth = 51
        Me.tblPerDiem.Size = New System.Drawing.Size(959, 346)
        Me.tblPerDiem.TabIndex = 0
        '
        'StatusCode
        '
        Me.StatusCode.HeaderText = "StatusCode"
        Me.StatusCode.MinimumWidth = 6
        Me.StatusCode.Name = "StatusCode"
        Me.StatusCode.ReadOnly = True
        '
        'Company
        '
        Me.Company.HeaderText = "Company"
        Me.Company.MinimumWidth = 6
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        '
        'EmployeeNumber
        '
        Me.EmployeeNumber.HeaderText = "Employee Number"
        Me.EmployeeNumber.MinimumWidth = 6
        Me.EmployeeNumber.Name = "EmployeeNumber"
        Me.EmployeeNumber.ReadOnly = True
        '
        'WeekNumber
        '
        Me.WeekNumber.HeaderText = "Week Number"
        Me.WeekNumber.MinimumWidth = 6
        Me.WeekNumber.Name = "WeekNumber"
        Me.WeekNumber.ReadOnly = True
        '
        'JobNumber
        '
        Me.JobNumber.HeaderText = "Job Number"
        Me.JobNumber.MinimumWidth = 6
        Me.JobNumber.Name = "JobNumber"
        Me.JobNumber.ReadOnly = True
        '
        'SubJobNumber
        '
        Me.SubJobNumber.HeaderText = "Sub Job Number"
        Me.SubJobNumber.MinimumWidth = 6
        Me.SubJobNumber.Name = "SubJobNumber"
        Me.SubJobNumber.ReadOnly = True
        '
        'CostDistribution
        '
        Me.CostDistribution.HeaderText = "Cost Distribution"
        Me.CostDistribution.MinimumWidth = 6
        Me.CostDistribution.Name = "CostDistribution"
        Me.CostDistribution.ReadOnly = True
        '
        'CostType
        '
        Me.CostType.HeaderText = "Cost Type"
        Me.CostType.MinimumWidth = 6
        Me.CostType.Name = "CostType"
        Me.CostType.ReadOnly = True
        '
        'DayOfWeek1
        '
        Me.DayOfWeek1.HeaderText = "Day Of Week"
        Me.DayOfWeek1.MinimumWidth = 6
        Me.DayOfWeek1.Name = "DayOfWeek1"
        Me.DayOfWeek1.ReadOnly = True
        '
        'RegularHours
        '
        Me.RegularHours.HeaderText = "Regular Hours"
        Me.RegularHours.MinimumWidth = 6
        Me.RegularHours.Name = "RegularHours"
        Me.RegularHours.ReadOnly = True
        '
        'OverTimeHours
        '
        Me.OverTimeHours.HeaderText = "Over Time Hours"
        Me.OverTimeHours.MinimumWidth = 6
        Me.OverTimeHours.Name = "OverTimeHours"
        Me.OverTimeHours.ReadOnly = True
        '
        'OtherHours
        '
        Me.OtherHours.HeaderText = "Other Hours"
        Me.OtherHours.MinimumWidth = 6
        Me.OtherHours.Name = "OtherHours"
        Me.OtherHours.ReadOnly = True
        '
        'OtherHoursType
        '
        Me.OtherHoursType.HeaderText = "Other Hours Type"
        Me.OtherHoursType.MinimumWidth = 6
        Me.OtherHoursType.Name = "OtherHoursType"
        Me.OtherHoursType.ReadOnly = True
        '
        'AdjustmentType
        '
        Me.AdjustmentType.HeaderText = "Adjustment Type"
        Me.AdjustmentType.MinimumWidth = 6
        Me.AdjustmentType.Name = "AdjustmentType"
        Me.AdjustmentType.ReadOnly = True
        '
        'AdjustmentAmount
        '
        Me.AdjustmentAmount.HeaderText = "Adjustment Amount"
        Me.AdjustmentAmount.MinimumWidth = 6
        Me.AdjustmentAmount.Name = "AdjustmentAmount"
        Me.AdjustmentAmount.ReadOnly = True
        '
        'DeductionNumber
        '
        Me.DeductionNumber.HeaderText = "Deduction Number"
        Me.DeductionNumber.MinimumWidth = 6
        Me.DeductionNumber.Name = "DeductionNumber"
        Me.DeductionNumber.ReadOnly = True
        '
        'BatchNumber
        '
        Me.BatchNumber.HeaderText = "Batch Number"
        Me.BatchNumber.MinimumWidth = 6
        Me.BatchNumber.Name = "BatchNumber"
        Me.BatchNumber.ReadOnly = True
        '
        'CheckType
        '
        Me.CheckType.HeaderText = "Check Type"
        Me.CheckType.MinimumWidth = 6
        Me.CheckType.Name = "CheckType"
        Me.CheckType.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TitleBar)
        Me.Panel3.Controls.Add(Me.PictureBox4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(975, 52)
        Me.Panel3.TabIndex = 2
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.PictureBox2)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label7)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Location = New System.Drawing.Point(0, 0)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(975, 52)
        Me.TitleBar.TabIndex = 16
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox2.Location = New System.Drawing.Point(893, 4)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 33)
        Me.PictureBox2.TabIndex = 42
        Me.PictureBox2.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(936, 4)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(31, 33)
        Me.btnRestore.TabIndex = 41
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(936, 4)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 31)
        Me.btnMaximize.TabIndex = 40
        Me.btnMaximize.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(27, 15)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 25)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Daily Per-Diem"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(925, 58)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(45, 41)
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        '
        'Perdiem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 542)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Perdiem"
        Me.Text = "Perdiem"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprExcelRow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblPerDiem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFindExcel As Button
    Friend WithEvents sprExcelRow As NumericUpDown
    Friend WithEvents btnRefreshPerdiem As Button
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tblPerDiem As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents txtSalida As Label
    Friend WithEvents StatusCode As DataGridViewTextBoxColumn
    Friend WithEvents Company As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNumber As DataGridViewTextBoxColumn
    Friend WithEvents WeekNumber As DataGridViewTextBoxColumn
    Friend WithEvents JobNumber As DataGridViewTextBoxColumn
    Friend WithEvents SubJobNumber As DataGridViewTextBoxColumn
    Friend WithEvents CostDistribution As DataGridViewTextBoxColumn
    Friend WithEvents CostType As DataGridViewTextBoxColumn
    Friend WithEvents DayOfWeek1 As DataGridViewTextBoxColumn
    Friend WithEvents RegularHours As DataGridViewTextBoxColumn
    Friend WithEvents OverTimeHours As DataGridViewTextBoxColumn
    Friend WithEvents OtherHours As DataGridViewTextBoxColumn
    Friend WithEvents OtherHoursType As DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentType As DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAmount As DataGridViewTextBoxColumn
    Friend WithEvents DeductionNumber As DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber As DataGridViewTextBoxColumn
    Friend WithEvents CheckType As DataGridViewTextBoxColumn
    Friend WithEvents TitleBar As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
End Class
