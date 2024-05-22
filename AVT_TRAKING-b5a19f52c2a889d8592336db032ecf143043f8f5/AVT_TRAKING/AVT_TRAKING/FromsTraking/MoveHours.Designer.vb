<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MoveHours
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TitleBar = New System.Windows.Forms.Panel()
        Me.pcbMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbcMain = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.tblHours = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tblMaterial = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblPerdiem = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.tblScaffold = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbAllEmployees = New System.Windows.Forms.CheckBox()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbClientSender = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbWOGetter = New System.Windows.Forms.ComboBox()
        Me.cmbPOGetter = New System.Windows.Forms.ComboBox()
        Me.cmbJobGetter = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbWOSender = New System.Windows.Forms.ComboBox()
        Me.cmbPOSender = New System.Windows.Forms.ComboBox()
        Me.cmbJobSender = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pcbClose = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.pcbMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcMain.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.tblHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblPerdiem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.tblScaffold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbcMain, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1085, 559)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.pcbMinimize)
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label1)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Location = New System.Drawing.Point(4, 4)
        Me.TitleBar.Margin = New System.Windows.Forms.Padding(4)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(1077, 47)
        Me.TitleBar.TabIndex = 2
        '
        'pcbMinimize
        '
        Me.pcbMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcbMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.pcbMinimize.Location = New System.Drawing.Point(979, 5)
        Me.pcbMinimize.Margin = New System.Windows.Forms.Padding(4)
        Me.pcbMinimize.Name = "pcbMinimize"
        Me.pcbMinimize.Size = New System.Drawing.Size(39, 39)
        Me.pcbMinimize.TabIndex = 3
        Me.pcbMinimize.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1026, 4)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(39, 39)
        Me.btnRestore.TabIndex = 2
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1026, 5)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(39, 39)
        Me.btnMaximize.TabIndex = 1
        Me.btnMaximize.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Time Sheet And Per-Diem"
        '
        'tbcMain
        '
        Me.tbcMain.Controls.Add(Me.TabPage3)
        Me.tbcMain.Controls.Add(Me.TabPage2)
        Me.tbcMain.Controls.Add(Me.TabPage1)
        Me.tbcMain.Controls.Add(Me.TabPage4)
        Me.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcMain.Location = New System.Drawing.Point(4, 210)
        Me.tbcMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tbcMain.Name = "tbcMain"
        Me.tbcMain.SelectedIndex = 0
        Me.tbcMain.Size = New System.Drawing.Size(1077, 295)
        Me.tbcMain.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1069, 266)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Hours Worked"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 266.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1069, 266)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel6.Controls.Add(Me.tblHours)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(4, 4)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1061, 258)
        Me.Panel6.TabIndex = 1
        '
        'tblHours
        '
        Me.tblHours.AllowUserToAddRows = False
        Me.tblHours.AllowUserToDeleteRows = False
        Me.tblHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblHours.Location = New System.Drawing.Point(0, 0)
        Me.tblHours.Name = "tblHours"
        Me.tblHours.ReadOnly = True
        Me.tblHours.RowHeadersWidth = 51
        Me.tblHours.RowTemplate.Height = 24
        Me.tblHours.Size = New System.Drawing.Size(1061, 258)
        Me.tblHours.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tblMaterial)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1069, 266)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Material"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tblMaterial
        '
        Me.tblMaterial.AllowUserToAddRows = False
        Me.tblMaterial.AllowUserToDeleteRows = False
        Me.tblMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblMaterial.Location = New System.Drawing.Point(4, 4)
        Me.tblMaterial.Name = "tblMaterial"
        Me.tblMaterial.ReadOnly = True
        Me.tblMaterial.RowHeadersWidth = 51
        Me.tblMaterial.RowTemplate.Height = 24
        Me.tblMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblMaterial.Size = New System.Drawing.Size(1061, 258)
        Me.tblMaterial.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tblPerdiem)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1069, 266)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Perdiem"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tblPerdiem
        '
        Me.tblPerdiem.AllowUserToAddRows = False
        Me.tblPerdiem.AllowUserToDeleteRows = False
        Me.tblPerdiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPerdiem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPerdiem.Location = New System.Drawing.Point(0, 0)
        Me.tblPerdiem.Name = "tblPerdiem"
        Me.tblPerdiem.ReadOnly = True
        Me.tblPerdiem.RowHeadersWidth = 51
        Me.tblPerdiem.RowTemplate.Height = 24
        Me.tblPerdiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblPerdiem.Size = New System.Drawing.Size(1069, 266)
        Me.tblPerdiem.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.tblScaffold)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1069, 266)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "Scaffolds "
        '
        'tblScaffold
        '
        Me.tblScaffold.AllowUserToAddRows = False
        Me.tblScaffold.AllowUserToDeleteRows = False
        Me.tblScaffold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblScaffold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScaffold.Location = New System.Drawing.Point(0, 0)
        Me.tblScaffold.Name = "tblScaffold"
        Me.tblScaffold.ReadOnly = True
        Me.tblScaffold.RowHeadersWidth = 51
        Me.tblScaffold.RowTemplate.Height = 24
        Me.tblScaffold.Size = New System.Drawing.Size(1069, 266)
        Me.tblScaffold.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chbAllEmployees)
        Me.Panel1.Controls.Add(Me.cmbEmployee)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cmbClientSender)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpEndDate)
        Me.Panel1.Controls.Add(Me.dtpStartDate)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.pcbClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1079, 145)
        Me.Panel1.TabIndex = 6
        '
        'chbAllEmployees
        '
        Me.chbAllEmployees.AutoSize = True
        Me.chbAllEmployees.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllEmployees.Location = New System.Drawing.Point(727, 113)
        Me.chbAllEmployees.Name = "chbAllEmployees"
        Me.chbAllEmployees.Size = New System.Drawing.Size(111, 21)
        Me.chbAllEmployees.TabIndex = 47
        Me.chbAllEmployees.Text = "All Employee"
        Me.chbAllEmployees.UseVisualStyleBackColor = True
        '
        'cmbEmployee
        '
        Me.cmbEmployee.DropDownWidth = 200
        Me.cmbEmployee.FormattingEnabled = True
        Me.cmbEmployee.Location = New System.Drawing.Point(592, 112)
        Me.cmbEmployee.Name = "cmbEmployee"
        Me.cmbEmployee.Size = New System.Drawing.Size(129, 24)
        Me.cmbEmployee.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(512, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 17)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Employee"
        '
        'cmbClientSender
        '
        Me.cmbClientSender.DropDownWidth = 200
        Me.cmbClientSender.FormattingEnabled = True
        Me.cmbClientSender.Location = New System.Drawing.Point(90, 5)
        Me.cmbClientSender.Name = "cmbClientSender"
        Me.cmbClientSender.Size = New System.Drawing.Size(155, 24)
        Me.cmbClientSender.TabIndex = 15
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSearch.Image = Global.AVT_TRAKING.My.Resources.Resources.loupe
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(790, 56)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(125, 35)
        Me.btnSearch.TabIndex = 44
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Clients"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(592, 84)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(129, 22)
        Me.dtpEndDate.TabIndex = 21
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(592, 56)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(129, 22)
        Me.dtpStartDate.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbWOGetter)
        Me.GroupBox2.Controls.Add(Me.cmbPOGetter)
        Me.GroupBox2.Controls.Add(Me.cmbJobGetter)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(262, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 110)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Getter "
        '
        'cmbWOGetter
        '
        Me.cmbWOGetter.DropDownWidth = 200
        Me.cmbWOGetter.FormattingEnabled = True
        Me.cmbWOGetter.Location = New System.Drawing.Point(85, 76)
        Me.cmbWOGetter.Name = "cmbWOGetter"
        Me.cmbWOGetter.Size = New System.Drawing.Size(155, 24)
        Me.cmbWOGetter.TabIndex = 18
        '
        'cmbPOGetter
        '
        Me.cmbPOGetter.FormattingEnabled = True
        Me.cmbPOGetter.Location = New System.Drawing.Point(85, 47)
        Me.cmbPOGetter.Name = "cmbPOGetter"
        Me.cmbPOGetter.Size = New System.Drawing.Size(155, 24)
        Me.cmbPOGetter.TabIndex = 17
        '
        'cmbJobGetter
        '
        Me.cmbJobGetter.DropDownWidth = 200
        Me.cmbJobGetter.FormattingEnabled = True
        Me.cmbJobGetter.Location = New System.Drawing.Point(85, 18)
        Me.cmbJobGetter.Name = "cmbJobGetter"
        Me.cmbJobGetter.Size = New System.Drawing.Size(155, 24)
        Me.cmbJobGetter.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(4, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "JobNo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(5, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "PO"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label12.Location = New System.Drawing.Point(5, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 17)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Work Order"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbWOSender)
        Me.GroupBox1.Controls.Add(Me.cmbPOSender)
        Me.GroupBox1.Controls.Add(Me.cmbJobSender)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(5, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 110)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sender"
        '
        'cmbWOSender
        '
        Me.cmbWOSender.DropDownWidth = 200
        Me.cmbWOSender.FormattingEnabled = True
        Me.cmbWOSender.Location = New System.Drawing.Point(85, 73)
        Me.cmbWOSender.Name = "cmbWOSender"
        Me.cmbWOSender.Size = New System.Drawing.Size(155, 24)
        Me.cmbWOSender.TabIndex = 18
        '
        'cmbPOSender
        '
        Me.cmbPOSender.FormattingEnabled = True
        Me.cmbPOSender.Location = New System.Drawing.Point(85, 44)
        Me.cmbPOSender.Name = "cmbPOSender"
        Me.cmbPOSender.Size = New System.Drawing.Size(155, 24)
        Me.cmbPOSender.TabIndex = 17
        '
        'cmbJobSender
        '
        Me.cmbJobSender.DropDownWidth = 200
        Me.cmbJobSender.FormattingEnabled = True
        Me.cmbJobSender.Location = New System.Drawing.Point(85, 15)
        Me.cmbJobSender.Name = "cmbJobSender"
        Me.cmbJobSender.Size = New System.Drawing.Size(155, 24)
        Me.cmbJobSender.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label11.Location = New System.Drawing.Point(4, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "JobNo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(5, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "PO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(5, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Work Order"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(514, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "End Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label10.Location = New System.Drawing.Point(514, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 17)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Start Date"
        '
        'pcbClose
        '
        Me.pcbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pcbClose.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.pcbClose.Location = New System.Drawing.Point(1027, 7)
        Me.pcbClose.Margin = New System.Windows.Forms.Padding(4)
        Me.pcbClose.Name = "pcbClose"
        Me.pcbClose.Size = New System.Drawing.Size(39, 39)
        Me.pcbClose.TabIndex = 4
        Me.pcbClose.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblMessage)
        Me.Panel2.Controls.Add(Me.btnMove)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 512)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1079, 44)
        Me.Panel2.TabIndex = 7
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(142, 14)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(69, 17)
        Me.lblMessage.TabIndex = 47
        Me.lblMessage.Text = "Message:"
        '
        'btnMove
        '
        Me.btnMove.FlatAppearance.BorderSize = 0
        Me.btnMove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMove.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnMove.Image = Global.AVT_TRAKING.My.Resources.Resources.upload
        Me.btnMove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMove.Location = New System.Drawing.Point(12, 5)
        Me.btnMove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(101, 35)
        Me.btnMove.TabIndex = 45
        Me.btnMove.Text = "Move"
        Me.btnMove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'MoveHours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1085, 559)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MoveHours"
        Me.Text = "MoveHours"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.pcbMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcMain.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.tblHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tblMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblPerdiem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.tblScaffold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents tbcMain As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents pcbClose As PictureBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TitleBar As Panel
    Friend WithEvents pcbMinimize As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tblHours As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbWOGetter As ComboBox
    Friend WithEvents cmbPOGetter As ComboBox
    Friend WithEvents cmbJobGetter As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbWOSender As ComboBox
    Friend WithEvents cmbPOSender As ComboBox
    Friend WithEvents cmbJobSender As ComboBox
    Friend WithEvents cmbClientSender As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents tblMaterial As DataGridView
    Friend WithEvents tblPerdiem As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents chbAllEmployees As CheckBox
    Friend WithEvents cmbEmployee As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnMove As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents tblScaffold As DataGridView
End Class
