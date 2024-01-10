<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WrongHours
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
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chbAllWO = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbWO = New System.Windows.Forms.ComboBox()
        Me.chbAllPO = New System.Windows.Forms.CheckBox()
        Me.PO = New System.Windows.Forms.Label()
        Me.cmbPO = New System.Windows.Forms.ComboBox()
        Me.chbAllEmployees = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbEmployees = New System.Windows.Forms.ComboBox()
        Me.chbAllClient = New System.Windows.Forms.CheckBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.cmbFindDate = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.PictureBox()
        Me.chbAllJobs = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbJob = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbClients = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.tbcControl = New System.Windows.Forms.TabControl()
        Me.tbpHours = New System.Windows.Forms.TabPage()
        Me.tblHours = New System.Windows.Forms.DataGridView()
        Me.tbpPerdiem = New System.Windows.Forms.TabPage()
        Me.tblPerdiem = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tbcControl.SuspendLayout()
        Me.tbpHours.SuspendLayout()
        CType(Me.tblHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpPerdiem.SuspendLayout()
        CType(Me.tblPerdiem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1143, 554)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.btnMinimize)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label7)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(1135, 35)
        Me.TitleBar.TabIndex = 3
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimize.Location = New System.Drawing.Point(1044, 0)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(39, 36)
        Me.btnMinimize.TabIndex = 3
        Me.btnMinimize.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1088, 0)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(39, 36)
        Me.btnRestore.TabIndex = 2
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1089, 0)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(39, 36)
        Me.btnMaximize.TabIndex = 1
        Me.btnMaximize.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(8, 5)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 25)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Worng Hours"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.tbcControl, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 47)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.5098!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.4902!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1135, 503)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chbAllWO)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cmbWO)
        Me.Panel2.Controls.Add(Me.chbAllPO)
        Me.Panel2.Controls.Add(Me.PO)
        Me.Panel2.Controls.Add(Me.cmbPO)
        Me.Panel2.Controls.Add(Me.chbAllEmployees)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbEmployees)
        Me.Panel2.Controls.Add(Me.chbAllClient)
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.cmbFindDate)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.chbAllJobs)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmbJob)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbClients)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dtpEndDate)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dtpStartDate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1127, 99)
        Me.Panel2.TabIndex = 2
        '
        'chbAllWO
        '
        Me.chbAllWO.AutoSize = True
        Me.chbAllWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chbAllWO.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllWO.Location = New System.Drawing.Point(860, 40)
        Me.chbAllWO.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllWO.Name = "chbAllWO"
        Me.chbAllWO.Size = New System.Drawing.Size(76, 22)
        Me.chbAllWO.TabIndex = 37
        Me.chbAllWO.Text = "All WO"
        Me.chbAllWO.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(627, 40)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 18)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "WO"
        '
        'cmbWO
        '
        Me.cmbWO.FormattingEnabled = True
        Me.cmbWO.Location = New System.Drawing.Point(676, 39)
        Me.cmbWO.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbWO.Name = "cmbWO"
        Me.cmbWO.Size = New System.Drawing.Size(179, 24)
        Me.cmbWO.TabIndex = 35
        '
        'chbAllPO
        '
        Me.chbAllPO.AutoSize = True
        Me.chbAllPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chbAllPO.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllPO.Location = New System.Drawing.Point(860, 10)
        Me.chbAllPO.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllPO.Name = "chbAllPO"
        Me.chbAllPO.Size = New System.Drawing.Size(71, 22)
        Me.chbAllPO.TabIndex = 34
        Me.chbAllPO.Text = "All PO"
        Me.chbAllPO.UseVisualStyleBackColor = True
        '
        'PO
        '
        Me.PO.AutoSize = True
        Me.PO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.PO.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.PO.Location = New System.Drawing.Point(627, 11)
        Me.PO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PO.Name = "PO"
        Me.PO.Size = New System.Drawing.Size(30, 18)
        Me.PO.TabIndex = 33
        Me.PO.Text = "PO"
        '
        'cmbPO
        '
        Me.cmbPO.FormattingEnabled = True
        Me.cmbPO.Location = New System.Drawing.Point(676, 9)
        Me.cmbPO.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPO.Name = "cmbPO"
        Me.cmbPO.Size = New System.Drawing.Size(179, 24)
        Me.cmbPO.TabIndex = 32
        '
        'chbAllEmployees
        '
        Me.chbAllEmployees.AutoSize = True
        Me.chbAllEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chbAllEmployees.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllEmployees.Location = New System.Drawing.Point(519, 71)
        Me.chbAllEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllEmployees.Name = "chbAllEmployees"
        Me.chbAllEmployees.Size = New System.Drawing.Size(123, 22)
        Me.chbAllEmployees.TabIndex = 31
        Me.chbAllEmployees.Text = "All Employees"
        Me.chbAllEmployees.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(249, 74)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 18)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Employee"
        '
        'cmbEmployees
        '
        Me.cmbEmployees.DropDownWidth = 280
        Me.cmbEmployees.FormattingEnabled = True
        Me.cmbEmployees.Location = New System.Drawing.Point(335, 70)
        Me.cmbEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEmployees.Name = "cmbEmployees"
        Me.cmbEmployees.Size = New System.Drawing.Size(179, 24)
        Me.cmbEmployees.TabIndex = 29
        '
        'chbAllClient
        '
        Me.chbAllClient.AutoSize = True
        Me.chbAllClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chbAllClient.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllClient.Location = New System.Drawing.Point(519, 6)
        Me.chbAllClient.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllClient.Name = "chbAllClient"
        Me.chbAllClient.Size = New System.Drawing.Size(94, 22)
        Me.chbAllClient.TabIndex = 26
        Me.chbAllClient.Text = "All Clients"
        Me.chbAllClient.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFind.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnFind.Location = New System.Drawing.Point(950, 38)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(88, 47)
        Me.btnFind.TabIndex = 28
        Me.btnFind.Text = "Find"
        Me.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'cmbFindDate
        '
        Me.cmbFindDate.FormattingEnabled = True
        Me.cmbFindDate.Items.AddRange(New Object() {"Day Inserted", "Day Worked"})
        Me.cmbFindDate.Location = New System.Drawing.Point(92, 5)
        Me.cmbFindDate.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFindDate.Name = "cmbFindDate"
        Me.cmbFindDate.Size = New System.Drawing.Size(148, 24)
        Me.cmbFindDate.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(8, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 18)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Find Date"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.btnClose.Location = New System.Drawing.Point(1073, 9)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(45, 43)
        Me.btnClose.TabIndex = 2
        Me.btnClose.TabStop = False
        '
        'chbAllJobs
        '
        Me.chbAllJobs.AutoSize = True
        Me.chbAllJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chbAllJobs.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllJobs.Location = New System.Drawing.Point(519, 38)
        Me.chbAllJobs.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllJobs.Name = "chbAllJobs"
        Me.chbAllJobs.Size = New System.Drawing.Size(82, 22)
        Me.chbAllJobs.TabIndex = 25
        Me.chbAllJobs.Text = "All Jobs"
        Me.chbAllJobs.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(280, 41)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 18)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Jobs"
        '
        'cmbJob
        '
        Me.cmbJob.FormattingEnabled = True
        Me.cmbJob.Location = New System.Drawing.Point(335, 37)
        Me.cmbJob.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbJob.Name = "cmbJob"
        Me.cmbJob.Size = New System.Drawing.Size(179, 24)
        Me.cmbJob.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(280, 9)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 18)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Client"
        '
        'cmbClients
        '
        Me.cmbClients.FormattingEnabled = True
        Me.cmbClients.Location = New System.Drawing.Point(335, 5)
        Me.cmbClients.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClients.Name = "cmbClients"
        Me.cmbClients.Size = New System.Drawing.Size(179, 24)
        Me.cmbClients.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(12, 74)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "End Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(92, 70)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(148, 22)
        Me.dtpEndDate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(8, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start Date"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(92, 37)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(148, 22)
        Me.dtpStartDate.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSelectAll)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 442)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1127, 57)
        Me.Panel1.TabIndex = 3
        '
        'btnSelectAll
        '
        Me.btnSelectAll.FlatAppearance.BorderSize = 0
        Me.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnSelectAll.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSelectAll.Image = Global.AVT_TRAKING.My.Resources.Resources.ok
        Me.btnSelectAll.Location = New System.Drawing.Point(4, 5)
        Me.btnSelectAll.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(123, 47)
        Me.btnSelectAll.TabIndex = 30
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDelete.Location = New System.Drawing.Point(1020, 0)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(107, 57)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'tbcControl
        '
        Me.tbcControl.Controls.Add(Me.tbpHours)
        Me.tbcControl.Controls.Add(Me.tbpPerdiem)
        Me.tbcControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcControl.Location = New System.Drawing.Point(4, 111)
        Me.tbcControl.Margin = New System.Windows.Forms.Padding(4)
        Me.tbcControl.Name = "tbcControl"
        Me.tbcControl.SelectedIndex = 0
        Me.tbcControl.Size = New System.Drawing.Size(1127, 323)
        Me.tbcControl.TabIndex = 4
        '
        'tbpHours
        '
        Me.tbpHours.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.tbpHours.Controls.Add(Me.tblHours)
        Me.tbpHours.Location = New System.Drawing.Point(4, 25)
        Me.tbpHours.Margin = New System.Windows.Forms.Padding(4)
        Me.tbpHours.Name = "tbpHours"
        Me.tbpHours.Padding = New System.Windows.Forms.Padding(4)
        Me.tbpHours.Size = New System.Drawing.Size(1119, 294)
        Me.tbpHours.TabIndex = 0
        Me.tbpHours.Text = "Hours"
        '
        'tblHours
        '
        Me.tblHours.AllowUserToAddRows = False
        Me.tblHours.AllowUserToDeleteRows = False
        Me.tblHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblHours.Location = New System.Drawing.Point(4, 4)
        Me.tblHours.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tblHours.Name = "tblHours"
        Me.tblHours.ReadOnly = True
        Me.tblHours.RowHeadersWidth = 62
        Me.tblHours.RowTemplate.Height = 28
        Me.tblHours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblHours.Size = New System.Drawing.Size(1111, 286)
        Me.tblHours.TabIndex = 1
        '
        'tbpPerdiem
        '
        Me.tbpPerdiem.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.tbpPerdiem.Controls.Add(Me.tblPerdiem)
        Me.tbpPerdiem.Location = New System.Drawing.Point(4, 25)
        Me.tbpPerdiem.Margin = New System.Windows.Forms.Padding(4)
        Me.tbpPerdiem.Name = "tbpPerdiem"
        Me.tbpPerdiem.Padding = New System.Windows.Forms.Padding(4)
        Me.tbpPerdiem.Size = New System.Drawing.Size(1119, 294)
        Me.tbpPerdiem.TabIndex = 1
        Me.tbpPerdiem.Text = "Perdiem"
        '
        'tblPerdiem
        '
        Me.tblPerdiem.AllowUserToAddRows = False
        Me.tblPerdiem.AllowUserToDeleteRows = False
        Me.tblPerdiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPerdiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPerdiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPerdiem.Location = New System.Drawing.Point(4, 4)
        Me.tblPerdiem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tblPerdiem.Name = "tblPerdiem"
        Me.tblPerdiem.ReadOnly = True
        Me.tblPerdiem.RowHeadersWidth = 62
        Me.tblPerdiem.RowTemplate.Height = 28
        Me.tblPerdiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblPerdiem.Size = New System.Drawing.Size(1111, 286)
        Me.tblPerdiem.TabIndex = 2
        '
        'WrongHours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 554)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "WrongHours"
        Me.Text = "WrongHours"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.btnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.tbcControl.ResumeLayout(False)
        Me.tbpHours.ResumeLayout(False)
        CType(Me.tblHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpPerdiem.ResumeLayout(False)
        CType(Me.tblPerdiem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnClose As PictureBox
    Friend WithEvents TitleBar As Panel
    Friend WithEvents btnMinimize As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents tblHours As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents chbAllJobs As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbJob As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbClients As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbFindDate As ComboBox
    Friend WithEvents btnFind As Button
    Friend WithEvents chbAllClient As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents tbcControl As TabControl
    Friend WithEvents tbpHours As TabPage
    Friend WithEvents tbpPerdiem As TabPage
    Friend WithEvents chbAllEmployees As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbEmployees As ComboBox
    Friend WithEvents tblPerdiem As DataGridView
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents chbAllWO As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbWO As ComboBox
    Friend WithEvents chbAllPO As CheckBox
    Friend WithEvents PO As Label
    Friend WithEvents cmbPO As ComboBox
End Class
