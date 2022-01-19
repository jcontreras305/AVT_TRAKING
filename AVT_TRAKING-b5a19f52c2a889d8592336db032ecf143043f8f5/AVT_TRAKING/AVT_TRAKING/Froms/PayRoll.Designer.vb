<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayRoll
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindMasterPayroll = New System.Windows.Forms.Button()
        Me.sprRowStartNBL = New System.Windows.Forms.NumericUpDown()
        Me.sprRowStartTSD = New System.Windows.Forms.NumericUpDown()
        Me.btnReFresh = New System.Windows.Forms.Button()
        Me.dtpStartTime = New System.Windows.Forms.DateTimePicker()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tblTime = New System.Windows.Forms.DataGridView()
        Me.StatusCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubJobNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostDistribution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayWeek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegularHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OvertimeHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtherHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatchNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.tblNonBillable = New System.Windows.Forms.DataGridView()
        Me.NameEmployee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Job = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STHRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OTHRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STRATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblWeeks = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sprNumWeek = New System.Windows.Forms.NumericUpDown()
        Me.dtpWeek = New System.Windows.Forms.DateTimePicker()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnFindExcelWeeks = New System.Windows.Forms.Button()
        Me.btnDeleteWeek = New System.Windows.Forms.Button()
        Me.btnUpdateWeek = New System.Windows.Forms.Button()
        Me.btnAddWeek = New System.Windows.Forms.Button()
        Me.Weekend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMsgWk = New System.Windows.Forms.Label()
        Me.txtSalida = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.sprRowStartNBL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprRowStartTSD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.tblTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.tblNonBillable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.tblWeeks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.sprNumWeek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.44444!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.55556!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 49)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(756, 9)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox4.TabIndex = 14
        Me.PictureBox4.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 389)
        Me.Panel2.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(794, 389)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(786, 363)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Payroll"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TabControl2, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.53933!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.46067!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(780, 357)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtSalida)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.btnFindMasterPayroll)
        Me.Panel3.Controls.Add(Me.sprRowStartNBL)
        Me.Panel3.Controls.Add(Me.sprRowStartTSD)
        Me.Panel3.Controls.Add(Me.btnReFresh)
        Me.Panel3.Controls.Add(Me.dtpStartTime)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(774, 60)
        Me.Panel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(324, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Strat Row Excel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Start Date"
        '
        'btnFindMasterPayroll
        '
        Me.btnFindMasterPayroll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindMasterPayroll.Location = New System.Drawing.Point(605, 9)
        Me.btnFindMasterPayroll.Name = "btnFindMasterPayroll"
        Me.btnFindMasterPayroll.Size = New System.Drawing.Size(75, 23)
        Me.btnFindMasterPayroll.TabIndex = 4
        Me.btnFindMasterPayroll.Text = "..."
        Me.btnFindMasterPayroll.UseVisualStyleBackColor = True
        '
        'sprRowStartNBL
        '
        Me.sprRowStartNBL.Location = New System.Drawing.Point(503, 11)
        Me.sprRowStartNBL.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.sprRowStartNBL.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.sprRowStartNBL.Name = "sprRowStartNBL"
        Me.sprRowStartNBL.Size = New System.Drawing.Size(49, 20)
        Me.sprRowStartNBL.TabIndex = 3
        Me.sprRowStartNBL.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'sprRowStartTSD
        '
        Me.sprRowStartTSD.Location = New System.Drawing.Point(413, 11)
        Me.sprRowStartTSD.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.sprRowStartTSD.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.sprRowStartTSD.Name = "sprRowStartTSD"
        Me.sprRowStartTSD.Size = New System.Drawing.Size(49, 20)
        Me.sprRowStartTSD.TabIndex = 2
        Me.sprRowStartTSD.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnReFresh
        '
        Me.btnReFresh.Location = New System.Drawing.Point(231, 11)
        Me.btnReFresh.Name = "btnReFresh"
        Me.btnReFresh.Size = New System.Drawing.Size(75, 23)
        Me.btnReFresh.TabIndex = 1
        Me.btnReFresh.Text = "Refresh"
        Me.btnReFresh.UseVisualStyleBackColor = True
        '
        'dtpStartTime
        '
        Me.dtpStartTime.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartTime.Location = New System.Drawing.Point(76, 12)
        Me.dtpStartTime.Name = "dtpStartTime"
        Me.dtpStartTime.Size = New System.Drawing.Size(139, 20)
        Me.dtpStartTime.TabIndex = 0
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 69)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(774, 285)
        Me.TabControl2.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tblTime)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(766, 259)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Time Sheet Data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tblTime
        '
        Me.tblTime.AllowUserToAddRows = False
        Me.tblTime.AllowUserToDeleteRows = False
        Me.tblTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblTime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StatusCode, Me.Company, Me.EmployeeNumber, Me.WeekNumber, Me.JobNumber, Me.SubJobNumber, Me.CostDistribution, Me.CostType, Me.DayWeek, Me.RegularHours, Me.OvertimeHours, Me.OtherHours, Me.BatchNumber, Me.CheckType})
        Me.tblTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTime.Location = New System.Drawing.Point(3, 3)
        Me.tblTime.Name = "tblTime"
        Me.tblTime.Size = New System.Drawing.Size(760, 253)
        Me.tblTime.TabIndex = 1
        '
        'StatusCode
        '
        Me.StatusCode.HeaderText = "Status Code"
        Me.StatusCode.Name = "StatusCode"
        Me.StatusCode.ReadOnly = True
        '
        'Company
        '
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        '
        'EmployeeNumber
        '
        Me.EmployeeNumber.HeaderText = "Employee Number"
        Me.EmployeeNumber.Name = "EmployeeNumber"
        Me.EmployeeNumber.ReadOnly = True
        '
        'WeekNumber
        '
        Me.WeekNumber.HeaderText = "Week Number"
        Me.WeekNumber.Name = "WeekNumber"
        Me.WeekNumber.ReadOnly = True
        '
        'JobNumber
        '
        Me.JobNumber.HeaderText = "Job Number"
        Me.JobNumber.Name = "JobNumber"
        Me.JobNumber.ReadOnly = True
        '
        'SubJobNumber
        '
        Me.SubJobNumber.HeaderText = "Sub Job Number"
        Me.SubJobNumber.Name = "SubJobNumber"
        Me.SubJobNumber.ReadOnly = True
        '
        'CostDistribution
        '
        Me.CostDistribution.HeaderText = "Cost Distribution"
        Me.CostDistribution.Name = "CostDistribution"
        Me.CostDistribution.ReadOnly = True
        '
        'CostType
        '
        Me.CostType.HeaderText = "Cost Type"
        Me.CostType.Name = "CostType"
        Me.CostType.ReadOnly = True
        '
        'DayWeek
        '
        Me.DayWeek.HeaderText = "Day Week"
        Me.DayWeek.Name = "DayWeek"
        Me.DayWeek.ReadOnly = True
        '
        'RegularHours
        '
        Me.RegularHours.HeaderText = "Regular Hours"
        Me.RegularHours.Name = "RegularHours"
        Me.RegularHours.ReadOnly = True
        '
        'OvertimeHours
        '
        Me.OvertimeHours.HeaderText = "Overtime Hours"
        Me.OvertimeHours.Name = "OvertimeHours"
        Me.OvertimeHours.ReadOnly = True
        '
        'OtherHours
        '
        Me.OtherHours.HeaderText = "Other Hours"
        Me.OtherHours.Name = "OtherHours"
        Me.OtherHours.ReadOnly = True
        '
        'BatchNumber
        '
        Me.BatchNumber.HeaderText = "Batch Number"
        Me.BatchNumber.Name = "BatchNumber"
        Me.BatchNumber.ReadOnly = True
        '
        'CheckType
        '
        Me.CheckType.HeaderText = "Check Type"
        Me.CheckType.Name = "CheckType"
        Me.CheckType.ReadOnly = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.tblNonBillable)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(766, 259)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "NON-BILLABLE"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'tblNonBillable
        '
        Me.tblNonBillable.AllowUserToAddRows = False
        Me.tblNonBillable.AllowUserToDeleteRows = False
        Me.tblNonBillable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblNonBillable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblNonBillable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameEmployee, Me.EmpNum, Me.Job, Me.SubJob, Me.Date1, Me.STHRS, Me.OTHRS, Me.STRATE, Me.Description})
        Me.tblNonBillable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblNonBillable.Location = New System.Drawing.Point(3, 3)
        Me.tblNonBillable.Name = "tblNonBillable"
        Me.tblNonBillable.Size = New System.Drawing.Size(760, 253)
        Me.tblNonBillable.TabIndex = 0
        '
        'NameEmployee
        '
        Me.NameEmployee.HeaderText = "Name Employee"
        Me.NameEmployee.Name = "NameEmployee"
        Me.NameEmployee.ReadOnly = True
        '
        'EmpNum
        '
        Me.EmpNum.HeaderText = "Emp Num"
        Me.EmpNum.Name = "EmpNum"
        Me.EmpNum.ReadOnly = True
        '
        'Job
        '
        Me.Job.HeaderText = "Job"
        Me.Job.Name = "Job"
        Me.Job.ReadOnly = True
        '
        'SubJob
        '
        Me.SubJob.HeaderText = "SubJob"
        Me.SubJob.Name = "SubJob"
        Me.SubJob.ReadOnly = True
        '
        'Date1
        '
        Me.Date1.HeaderText = "Date"
        Me.Date1.Name = "Date1"
        Me.Date1.ReadOnly = True
        '
        'STHRS
        '
        Me.STHRS.HeaderText = "STHRS"
        Me.STHRS.Name = "STHRS"
        Me.STHRS.ReadOnly = True
        '
        'OTHRS
        '
        Me.OTHRS.HeaderText = "OTHRS"
        Me.OTHRS.Name = "OTHRS"
        Me.OTHRS.ReadOnly = True
        '
        'STRATE
        '
        Me.STRATE.HeaderText = "STRATE"
        Me.STRATE.Name = "STRATE"
        Me.STRATE.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(786, 363)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Weeks"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.tblWeeks, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(780, 357)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'tblWeeks
        '
        Me.tblWeeks.AllowUserToAddRows = False
        Me.tblWeeks.AllowUserToDeleteRows = False
        Me.tblWeeks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblWeeks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblWeeks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Weekend, Me.WeekNum})
        Me.tblWeeks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblWeeks.Location = New System.Drawing.Point(3, 3)
        Me.tblWeeks.Name = "tblWeeks"
        Me.tblWeeks.Size = New System.Drawing.Size(319, 351)
        Me.tblWeeks.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(328, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.57143!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.42857!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(449, 351)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.sprNumWeek)
        Me.Panel4.Controls.Add(Me.dtpWeek)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(443, 269)
        Me.Panel4.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "NumberWeek"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Week Ending"
        '
        'sprNumWeek
        '
        Me.sprNumWeek.Location = New System.Drawing.Point(103, 68)
        Me.sprNumWeek.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.sprNumWeek.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.sprNumWeek.Name = "sprNumWeek"
        Me.sprNumWeek.Size = New System.Drawing.Size(66, 20)
        Me.sprNumWeek.TabIndex = 1
        Me.sprNumWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.sprNumWeek.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtpWeek
        '
        Me.dtpWeek.CustomFormat = "MM/dd/yyyy"
        Me.dtpWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWeek.Location = New System.Drawing.Point(103, 28)
        Me.dtpWeek.Name = "dtpWeek"
        Me.dtpWeek.Size = New System.Drawing.Size(200, 20)
        Me.dtpWeek.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtMsgWk)
        Me.Panel5.Controls.Add(Me.btnFindExcelWeeks)
        Me.Panel5.Controls.Add(Me.btnDeleteWeek)
        Me.Panel5.Controls.Add(Me.btnUpdateWeek)
        Me.Panel5.Controls.Add(Me.btnAddWeek)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 278)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(443, 70)
        Me.Panel5.TabIndex = 1
        '
        'btnFindExcelWeeks
        '
        Me.btnFindExcelWeeks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindExcelWeeks.Location = New System.Drawing.Point(351, 17)
        Me.btnFindExcelWeeks.Name = "btnFindExcelWeeks"
        Me.btnFindExcelWeeks.Size = New System.Drawing.Size(75, 23)
        Me.btnFindExcelWeeks.TabIndex = 3
        Me.btnFindExcelWeeks.Text = "..."
        Me.btnFindExcelWeeks.UseVisualStyleBackColor = True
        '
        'btnDeleteWeek
        '
        Me.btnDeleteWeek.Location = New System.Drawing.Point(215, 17)
        Me.btnDeleteWeek.Name = "btnDeleteWeek"
        Me.btnDeleteWeek.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteWeek.TabIndex = 2
        Me.btnDeleteWeek.Text = "Delete"
        Me.btnDeleteWeek.UseVisualStyleBackColor = True
        '
        'btnUpdateWeek
        '
        Me.btnUpdateWeek.Location = New System.Drawing.Point(121, 17)
        Me.btnUpdateWeek.Name = "btnUpdateWeek"
        Me.btnUpdateWeek.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateWeek.TabIndex = 1
        Me.btnUpdateWeek.Text = "Update"
        Me.btnUpdateWeek.UseVisualStyleBackColor = True
        '
        'btnAddWeek
        '
        Me.btnAddWeek.Location = New System.Drawing.Point(24, 17)
        Me.btnAddWeek.Name = "btnAddWeek"
        Me.btnAddWeek.Size = New System.Drawing.Size(75, 23)
        Me.btnAddWeek.TabIndex = 0
        Me.btnAddWeek.Text = "Add"
        Me.btnAddWeek.UseVisualStyleBackColor = True
        '
        'Weekend
        '
        Me.Weekend.HeaderText = "Weekending"
        Me.Weekend.Name = "Weekend"
        Me.Weekend.ReadOnly = True
        '
        'WeekNum
        '
        Me.WeekNum.HeaderText = "Week Num"
        Me.WeekNum.Name = "WeekNum"
        Me.WeekNum.ReadOnly = True
        '
        'txtMsgWk
        '
        Me.txtMsgWk.AutoSize = True
        Me.txtMsgWk.Location = New System.Drawing.Point(15, 47)
        Me.txtMsgWk.Name = "txtMsgWk"
        Me.txtMsgWk.Size = New System.Drawing.Size(50, 13)
        Me.txtMsgWk.TabIndex = 4
        Me.txtMsgWk.Text = "Message"
        '
        'txtSalida
        '
        Me.txtSalida.AutoSize = True
        Me.txtSalida.Location = New System.Drawing.Point(7, 40)
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.Size = New System.Drawing.Size(53, 13)
        Me.txtSalida.TabIndex = 7
        Me.txtSalida.Text = "Message:"
        '
        'PayRoll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "PayRoll"
        Me.Text = "PayRoll"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.sprRowStartNBL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprRowStartTSD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.tblTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.tblNonBillable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.tblWeeks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.sprNumWeek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnFindMasterPayroll As Button
    Friend WithEvents sprRowStartNBL As NumericUpDown
    Friend WithEvents sprRowStartTSD As NumericUpDown
    Friend WithEvents btnReFresh As Button
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents tblWeeks As DataGridView
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents sprNumWeek As NumericUpDown
    Friend WithEvents dtpWeek As DateTimePicker
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnFindExcelWeeks As Button
    Friend WithEvents btnDeleteWeek As Button
    Friend WithEvents btnUpdateWeek As Button
    Friend WithEvents btnAddWeek As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents tblTime As DataGridView
    Friend WithEvents tblNonBillable As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents StatusCode As DataGridViewTextBoxColumn
    Friend WithEvents Company As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNumber As DataGridViewTextBoxColumn
    Friend WithEvents WeekNumber As DataGridViewTextBoxColumn
    Friend WithEvents JobNumber As DataGridViewTextBoxColumn
    Friend WithEvents SubJobNumber As DataGridViewTextBoxColumn
    Friend WithEvents CostDistribution As DataGridViewTextBoxColumn
    Friend WithEvents CostType As DataGridViewTextBoxColumn
    Friend WithEvents DayWeek As DataGridViewTextBoxColumn
    Friend WithEvents RegularHours As DataGridViewTextBoxColumn
    Friend WithEvents OvertimeHours As DataGridViewTextBoxColumn
    Friend WithEvents OtherHours As DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber As DataGridViewTextBoxColumn
    Friend WithEvents CheckType As DataGridViewTextBoxColumn
    Friend WithEvents NameEmployee As DataGridViewTextBoxColumn
    Friend WithEvents EmpNum As DataGridViewTextBoxColumn
    Friend WithEvents Job As DataGridViewTextBoxColumn
    Friend WithEvents SubJob As DataGridViewTextBoxColumn
    Friend WithEvents Date1 As DataGridViewTextBoxColumn
    Friend WithEvents STHRS As DataGridViewTextBoxColumn
    Friend WithEvents OTHRS As DataGridViewTextBoxColumn
    Friend WithEvents STRATE As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Weekend As DataGridViewTextBoxColumn
    Friend WithEvents WeekNum As DataGridViewTextBoxColumn
    Friend WithEvents txtMsgWk As Label
    Friend WithEvents txtSalida As Label
End Class
