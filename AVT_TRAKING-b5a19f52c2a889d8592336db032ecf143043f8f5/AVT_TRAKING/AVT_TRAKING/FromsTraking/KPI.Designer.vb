<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KPI
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chbData = New System.Windows.Forms.CheckBox()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbData = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnFindExcel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.cmbTypeKPI = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.sprData = New System.Windows.Forms.NumericUpDown()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tbcKPI = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblDatosKPI = New System.Windows.Forms.DataGridView()
        Me.jobNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tinck = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateWorked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SQFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty90 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valves = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Install = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CasePaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lead = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.STResistence = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblKPISearch = New System.Windows.Forms.DataGridView()
        Me.idKPI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeKPIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobNoS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wonoS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAuxS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TinckS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateWorkedS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LFS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SQFTS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty90S = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty45S = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValvesS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FITS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OTS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InstallS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CasePaintS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadS = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.STResistenceS = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnDeleteRow = New System.Windows.Forms.Button()
        Me.btnUpdateRow = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.pgbProgress = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.tbcKPI.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblDatosKPI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.tblKPISearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1067, 554)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1059, 54)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.material
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(59, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(250, 25)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Report Scaffold Ative"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(969, 7)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1013, 6)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(35, 36)
        Me.btnRestore.TabIndex = 11
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1013, 7)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(41, 36)
        Me.btnMaximize.TabIndex = 10
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chbData)
        Me.Panel2.Controls.Add(Me.txtData)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbData)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnFindExcel)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbClient)
        Me.Panel2.Controls.Add(Me.cmbTypeKPI)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.dtpDate)
        Me.Panel2.Controls.Add(Me.sprData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 66)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1059, 56)
        Me.Panel2.TabIndex = 1
        '
        'chbData
        '
        Me.chbData.AutoSize = True
        Me.chbData.Location = New System.Drawing.Point(684, 23)
        Me.chbData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chbData.Name = "chbData"
        Me.chbData.Size = New System.Drawing.Size(18, 17)
        Me.chbData.TabIndex = 22
        Me.chbData.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(423, 16)
        Me.txtData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(160, 22)
        Me.txtData.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(375, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Data"
        '
        'cmbData
        '
        Me.cmbData.FormattingEnabled = True
        Me.cmbData.Location = New System.Drawing.Point(447, 15)
        Me.cmbData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbData.Name = "cmbData"
        Me.cmbData.Size = New System.Drawing.Size(160, 24)
        Me.cmbData.TabIndex = 17
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(861, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 48)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnFindExcel
        '
        Me.btnFindExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindExcel.FlatAppearance.BorderSize = 0
        Me.btnFindExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnFindExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFindExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnFindExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindExcel.Location = New System.Drawing.Point(744, 5)
        Me.btnFindExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFindExcel.Name = "btnFindExcel"
        Me.btnFindExcel.Size = New System.Drawing.Size(109, 48)
        Me.btnFindExcel.TabIndex = 15
        Me.btnFindExcel.Text = "Find"
        Me.btnFindExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindExcel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(159, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Client"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(19, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "KPI"
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(205, 16)
        Me.cmbClient.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(160, 24)
        Me.cmbClient.TabIndex = 12
        '
        'cmbTypeKPI
        '
        Me.cmbTypeKPI.FormattingEnabled = True
        Me.cmbTypeKPI.Items.AddRange(New Object() {"Instalation", "Paint", "Remove"})
        Me.cmbTypeKPI.Location = New System.Drawing.Point(53, 15)
        Me.cmbTypeKPI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbTypeKPI.Name = "cmbTypeKPI"
        Me.cmbTypeKPI.Size = New System.Drawing.Size(92, 24)
        Me.cmbTypeKPI.TabIndex = 11
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1005, 4)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 42)
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(481, 15)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(160, 22)
        Me.dtpDate.TabIndex = 20
        '
        'sprData
        '
        Me.sprData.DecimalPlaces = 2
        Me.sprData.Location = New System.Drawing.Point(513, 15)
        Me.sprData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sprData.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.sprData.Name = "sprData"
        Me.sprData.Size = New System.Drawing.Size(161, 22)
        Me.sprData.TabIndex = 21
        Me.sprData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.tbcKPI)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 130)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1059, 371)
        Me.Panel3.TabIndex = 2
        '
        'tbcKPI
        '
        Me.tbcKPI.Controls.Add(Me.TabPage1)
        Me.tbcKPI.Controls.Add(Me.TabPage2)
        Me.tbcKPI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcKPI.Location = New System.Drawing.Point(0, 0)
        Me.tbcKPI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbcKPI.Name = "tbcKPI"
        Me.tbcKPI.SelectedIndex = 0
        Me.tbcKPI.Size = New System.Drawing.Size(1059, 371)
        Me.tbcKPI.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.tblDatosKPI)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1051, 342)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Insert KPI"
        '
        'tblDatosKPI
        '
        Me.tblDatosKPI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.tblDatosKPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDatosKPI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jobNo, Me.wono, Me.idAux, Me.Description, Me.Tinck, Me.Size, Me.DateWorked, Me.LF, Me.SQFT, Me.Qty90, Me.Qty45, Me.TEE, Me.Valves, Me.RED, Me.CAP, Me.FLG, Me.FIT, Me.ST, Me.OT, Me.Install, Me.CasePaint, Me.Lead, Me.STResistence})
        Me.tblDatosKPI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDatosKPI.Location = New System.Drawing.Point(4, 4)
        Me.tblDatosKPI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblDatosKPI.Name = "tblDatosKPI"
        Me.tblDatosKPI.RowHeadersWidth = 60
        Me.tblDatosKPI.Size = New System.Drawing.Size(1043, 334)
        Me.tblDatosKPI.TabIndex = 0
        '
        'jobNo
        '
        Me.jobNo.HeaderText = "Job#"
        Me.jobNo.MinimumWidth = 6
        Me.jobNo.Name = "jobNo"
        Me.jobNo.Width = 66
        '
        'wono
        '
        Me.wono.HeaderText = "W.O.#"
        Me.wono.MinimumWidth = 6
        Me.wono.Name = "wono"
        Me.wono.Width = 72
        '
        'idAux
        '
        Me.idAux.HeaderText = "idAux"
        Me.idAux.MinimumWidth = 6
        Me.idAux.Name = "idAux"
        Me.idAux.ReadOnly = True
        Me.idAux.Visible = False
        Me.idAux.Width = 58
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        Me.Description.Width = 104
        '
        'Tinck
        '
        Me.Tinck.HeaderText = "Tinck"
        Me.Tinck.MinimumWidth = 6
        Me.Tinck.Name = "Tinck"
        Me.Tinck.Width = 69
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.MinimumWidth = 6
        Me.Size.Name = "Size"
        Me.Size.Width = 62
        '
        'DateWorked
        '
        Me.DateWorked.HeaderText = "DateWorked"
        Me.DateWorked.MinimumWidth = 6
        Me.DateWorked.Name = "DateWorked"
        Me.DateWorked.Width = 113
        '
        'LF
        '
        Me.LF.HeaderText = "LF"
        Me.LF.MinimumWidth = 6
        Me.LF.Name = "LF"
        Me.LF.Width = 51
        '
        'SQFT
        '
        Me.SQFT.HeaderText = "SQFT"
        Me.SQFT.MinimumWidth = 6
        Me.SQFT.Name = "SQFT"
        Me.SQFT.Width = 72
        '
        'Qty90
        '
        Me.Qty90.HeaderText = "Qty: 90"
        Me.Qty90.MinimumWidth = 6
        Me.Qty90.Name = "Qty90"
        Me.Qty90.Width = 76
        '
        'Qty45
        '
        Me.Qty45.HeaderText = "Qty: 45"
        Me.Qty45.MinimumWidth = 6
        Me.Qty45.Name = "Qty45"
        Me.Qty45.Width = 76
        '
        'TEE
        '
        Me.TEE.HeaderText = "TEE"
        Me.TEE.MinimumWidth = 6
        Me.TEE.Name = "TEE"
        Me.TEE.Width = 63
        '
        'Valves
        '
        Me.Valves.HeaderText = "Valves"
        Me.Valves.MinimumWidth = 6
        Me.Valves.Name = "Valves"
        Me.Valves.Width = 78
        '
        'RED
        '
        Me.RED.HeaderText = "RED"
        Me.RED.MinimumWidth = 6
        Me.RED.Name = "RED"
        Me.RED.Width = 65
        '
        'CAP
        '
        Me.CAP.HeaderText = "CAP"
        Me.CAP.MinimumWidth = 6
        Me.CAP.Name = "CAP"
        Me.CAP.Width = 63
        '
        'FLG
        '
        Me.FLG.HeaderText = "FLG"
        Me.FLG.MinimumWidth = 6
        Me.FLG.Name = "FLG"
        Me.FLG.Width = 61
        '
        'FIT
        '
        Me.FIT.HeaderText = "FIT"
        Me.FIT.MinimumWidth = 6
        Me.FIT.Name = "FIT"
        Me.FIT.Width = 56
        '
        'ST
        '
        Me.ST.HeaderText = "ST"
        Me.ST.MinimumWidth = 6
        Me.ST.Name = "ST"
        Me.ST.Width = 54
        '
        'OT
        '
        Me.OT.HeaderText = "OT"
        Me.OT.MinimumWidth = 6
        Me.OT.Name = "OT"
        Me.OT.Width = 55
        '
        'Install
        '
        Me.Install.HeaderText = "Install"
        Me.Install.MinimumWidth = 6
        Me.Install.Name = "Install"
        Me.Install.Width = 70
        '
        'CasePaint
        '
        Me.CasePaint.HeaderText = "Case Painted"
        Me.CasePaint.MinimumWidth = 6
        Me.CasePaint.Name = "CasePaint"
        Me.CasePaint.Visible = False
        Me.CasePaint.Width = 95
        '
        'Lead
        '
        Me.Lead.HeaderText = "Lead"
        Me.Lead.MinimumWidth = 6
        Me.Lead.Name = "Lead"
        Me.Lead.Visible = False
        Me.Lead.Width = 37
        '
        'STResistence
        '
        Me.STResistence.HeaderText = "ST Resistence"
        Me.STResistence.MinimumWidth = 6
        Me.STResistence.Name = "STResistence"
        Me.STResistence.Visible = False
        Me.STResistence.Width = 83
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1051, 342)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "KPI's Search"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.tblKPISearch, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1043, 334)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'tblKPISearch
        '
        Me.tblKPISearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblKPISearch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idKPI, Me.TypeKPIS, Me.JobNoS, Me.wonoS, Me.idAuxS, Me.DescriptionS, Me.TinckS, Me.SizeS, Me.DateWorkedS, Me.LFS, Me.SQFTS, Me.Qty90S, Me.Qty45S, Me.TEES, Me.ValvesS, Me.REDS, Me.CAPS, Me.FLGS, Me.FITS, Me.STS, Me.OTS, Me.InstallS, Me.CasePaintS, Me.LeadS, Me.STResistenceS})
        Me.tblKPISearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblKPISearch.Location = New System.Drawing.Point(4, 4)
        Me.tblKPISearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblKPISearch.Name = "tblKPISearch"
        Me.tblKPISearch.RowHeadersWidth = 51
        Me.tblKPISearch.Size = New System.Drawing.Size(882, 326)
        Me.tblKPISearch.TabIndex = 0
        '
        'idKPI
        '
        Me.idKPI.HeaderText = "idKPI"
        Me.idKPI.MinimumWidth = 6
        Me.idKPI.Name = "idKPI"
        Me.idKPI.Visible = False
        Me.idKPI.Width = 125
        '
        'TypeKPIS
        '
        Me.TypeKPIS.HeaderText = "Type KPI"
        Me.TypeKPIS.MinimumWidth = 6
        Me.TypeKPIS.Name = "TypeKPIS"
        Me.TypeKPIS.Width = 125
        '
        'JobNoS
        '
        Me.JobNoS.HeaderText = "Job #"
        Me.JobNoS.MinimumWidth = 6
        Me.JobNoS.Name = "JobNoS"
        Me.JobNoS.Width = 125
        '
        'wonoS
        '
        Me.wonoS.HeaderText = "W.O.#"
        Me.wonoS.MinimumWidth = 6
        Me.wonoS.Name = "wonoS"
        Me.wonoS.Width = 125
        '
        'idAuxS
        '
        Me.idAuxS.HeaderText = "idAux"
        Me.idAuxS.MinimumWidth = 6
        Me.idAuxS.Name = "idAuxS"
        Me.idAuxS.Visible = False
        Me.idAuxS.Width = 125
        '
        'DescriptionS
        '
        Me.DescriptionS.HeaderText = "Description"
        Me.DescriptionS.MinimumWidth = 6
        Me.DescriptionS.Name = "DescriptionS"
        Me.DescriptionS.Width = 125
        '
        'TinckS
        '
        Me.TinckS.HeaderText = "TinckS"
        Me.TinckS.MinimumWidth = 6
        Me.TinckS.Name = "TinckS"
        Me.TinckS.Width = 125
        '
        'SizeS
        '
        Me.SizeS.HeaderText = "Size"
        Me.SizeS.MinimumWidth = 6
        Me.SizeS.Name = "SizeS"
        Me.SizeS.Width = 125
        '
        'DateWorkedS
        '
        Me.DateWorkedS.HeaderText = "Date Worked"
        Me.DateWorkedS.MinimumWidth = 6
        Me.DateWorkedS.Name = "DateWorkedS"
        Me.DateWorkedS.Width = 125
        '
        'LFS
        '
        Me.LFS.HeaderText = "LF"
        Me.LFS.MinimumWidth = 6
        Me.LFS.Name = "LFS"
        Me.LFS.Width = 125
        '
        'SQFTS
        '
        Me.SQFTS.HeaderText = "SQFT"
        Me.SQFTS.MinimumWidth = 6
        Me.SQFTS.Name = "SQFTS"
        Me.SQFTS.Width = 125
        '
        'Qty90S
        '
        Me.Qty90S.HeaderText = "Qty90"
        Me.Qty90S.MinimumWidth = 6
        Me.Qty90S.Name = "Qty90S"
        Me.Qty90S.Width = 125
        '
        'Qty45S
        '
        Me.Qty45S.HeaderText = "Qty45"
        Me.Qty45S.MinimumWidth = 6
        Me.Qty45S.Name = "Qty45S"
        Me.Qty45S.Width = 125
        '
        'TEES
        '
        Me.TEES.HeaderText = "TEE"
        Me.TEES.MinimumWidth = 6
        Me.TEES.Name = "TEES"
        Me.TEES.Width = 125
        '
        'ValvesS
        '
        Me.ValvesS.HeaderText = "Valves"
        Me.ValvesS.MinimumWidth = 6
        Me.ValvesS.Name = "ValvesS"
        Me.ValvesS.Width = 125
        '
        'REDS
        '
        Me.REDS.HeaderText = "RED"
        Me.REDS.MinimumWidth = 6
        Me.REDS.Name = "REDS"
        Me.REDS.Width = 125
        '
        'CAPS
        '
        Me.CAPS.HeaderText = "CAP"
        Me.CAPS.MinimumWidth = 6
        Me.CAPS.Name = "CAPS"
        Me.CAPS.Width = 125
        '
        'FLGS
        '
        Me.FLGS.HeaderText = "FLG"
        Me.FLGS.MinimumWidth = 6
        Me.FLGS.Name = "FLGS"
        Me.FLGS.Width = 125
        '
        'FITS
        '
        Me.FITS.HeaderText = "FIT"
        Me.FITS.MinimumWidth = 6
        Me.FITS.Name = "FITS"
        Me.FITS.Width = 125
        '
        'STS
        '
        Me.STS.HeaderText = "ST"
        Me.STS.MinimumWidth = 6
        Me.STS.Name = "STS"
        Me.STS.Width = 125
        '
        'OTS
        '
        Me.OTS.HeaderText = "OT"
        Me.OTS.MinimumWidth = 6
        Me.OTS.Name = "OTS"
        Me.OTS.Width = 125
        '
        'InstallS
        '
        Me.InstallS.HeaderText = "Install"
        Me.InstallS.MinimumWidth = 6
        Me.InstallS.Name = "InstallS"
        Me.InstallS.Width = 125
        '
        'CasePaintS
        '
        Me.CasePaintS.HeaderText = "CasePaint"
        Me.CasePaintS.MinimumWidth = 6
        Me.CasePaintS.Name = "CasePaintS"
        Me.CasePaintS.Width = 125
        '
        'LeadS
        '
        Me.LeadS.HeaderText = "Lead"
        Me.LeadS.MinimumWidth = 6
        Me.LeadS.Name = "LeadS"
        Me.LeadS.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeadS.Width = 125
        '
        'STResistenceS
        '
        Me.STResistenceS.HeaderText = "STResistence"
        Me.STResistenceS.MinimumWidth = 6
        Me.STResistenceS.Name = "STResistenceS"
        Me.STResistenceS.Width = 125
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnDeleteRow)
        Me.Panel5.Controls.Add(Me.btnUpdateRow)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(894, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(145, 326)
        Me.Panel5.TabIndex = 1
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnDeleteRow.FlatAppearance.BorderSize = 0
        Me.btnDeleteRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteRow.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteRow.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDeleteRow.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteRow.Location = New System.Drawing.Point(0, 230)
        Me.btnDeleteRow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(145, 48)
        Me.btnDeleteRow.TabIndex = 18
        Me.btnDeleteRow.Text = "Delete Row"
        Me.btnDeleteRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDeleteRow.UseVisualStyleBackColor = True
        '
        'btnUpdateRow
        '
        Me.btnUpdateRow.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnUpdateRow.FlatAppearance.BorderSize = 0
        Me.btnUpdateRow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateRow.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateRow.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateRow.Image = Global.AVT_TRAKING.My.Resources.Resources.update
        Me.btnUpdateRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateRow.Location = New System.Drawing.Point(0, 278)
        Me.btnUpdateRow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdateRow.Name = "btnUpdateRow"
        Me.btnUpdateRow.Size = New System.Drawing.Size(145, 48)
        Me.btnUpdateRow.TabIndex = 17
        Me.btnUpdateRow.Text = "Update Row"
        Me.btnUpdateRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateRow.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblMessage)
        Me.Panel4.Controls.Add(Me.pgbProgress)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(4, 509)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1059, 41)
        Me.Panel4.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(15, 15)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(67, 16)
        Me.lblMessage.TabIndex = 15
        Me.lblMessage.Text = "Message:"
        '
        'pgbProgress
        '
        Me.pgbProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgbProgress.Location = New System.Drawing.Point(824, 6)
        Me.pgbProgress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pgbProgress.Name = "pgbProgress"
        Me.pgbProgress.Size = New System.Drawing.Size(225, 28)
        Me.pgbProgress.TabIndex = 0
        '
        'KPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "KPI"
        Me.Text = "KPI"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.tbcKPI.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblDatosKPI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.tblKPISearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents cmbTypeKPI As ComboBox
    Friend WithEvents btnFindExcel As Button
    Friend WithEvents tblDatosKPI As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblMessage As Label
    Friend WithEvents pgbProgress As ProgressBar
    Friend WithEvents txtData As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbData As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents sprData As NumericUpDown
    Friend WithEvents chbData As CheckBox
    Friend WithEvents tbcKPI As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tblKPISearch As DataGridView
    Friend WithEvents jobNo As DataGridViewTextBoxColumn
    Friend WithEvents wono As DataGridViewTextBoxColumn
    Friend WithEvents idAux As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Tinck As DataGridViewTextBoxColumn
    Friend WithEvents Size As DataGridViewTextBoxColumn
    Friend WithEvents DateWorked As DataGridViewTextBoxColumn
    Friend WithEvents LF As DataGridViewTextBoxColumn
    Friend WithEvents SQFT As DataGridViewTextBoxColumn
    Friend WithEvents Qty90 As DataGridViewTextBoxColumn
    Friend WithEvents Qty45 As DataGridViewTextBoxColumn
    Friend WithEvents TEE As DataGridViewTextBoxColumn
    Friend WithEvents Valves As DataGridViewTextBoxColumn
    Friend WithEvents RED As DataGridViewTextBoxColumn
    Friend WithEvents CAP As DataGridViewTextBoxColumn
    Friend WithEvents FLG As DataGridViewTextBoxColumn
    Friend WithEvents FIT As DataGridViewTextBoxColumn
    Friend WithEvents ST As DataGridViewTextBoxColumn
    Friend WithEvents OT As DataGridViewTextBoxColumn
    Friend WithEvents Install As DataGridViewTextBoxColumn
    Friend WithEvents CasePaint As DataGridViewTextBoxColumn
    Friend WithEvents Lead As DataGridViewCheckBoxColumn
    Friend WithEvents STResistence As DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnUpdateRow As Button
    Friend WithEvents idKPI As DataGridViewTextBoxColumn
    Friend WithEvents TypeKPIS As DataGridViewTextBoxColumn
    Friend WithEvents JobNoS As DataGridViewTextBoxColumn
    Friend WithEvents wonoS As DataGridViewTextBoxColumn
    Friend WithEvents idAuxS As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionS As DataGridViewTextBoxColumn
    Friend WithEvents TinckS As DataGridViewTextBoxColumn
    Friend WithEvents SizeS As DataGridViewTextBoxColumn
    Friend WithEvents DateWorkedS As DataGridViewTextBoxColumn
    Friend WithEvents LFS As DataGridViewTextBoxColumn
    Friend WithEvents SQFTS As DataGridViewTextBoxColumn
    Friend WithEvents Qty90S As DataGridViewTextBoxColumn
    Friend WithEvents Qty45S As DataGridViewTextBoxColumn
    Friend WithEvents TEES As DataGridViewTextBoxColumn
    Friend WithEvents ValvesS As DataGridViewTextBoxColumn
    Friend WithEvents REDS As DataGridViewTextBoxColumn
    Friend WithEvents CAPS As DataGridViewTextBoxColumn
    Friend WithEvents FLGS As DataGridViewTextBoxColumn
    Friend WithEvents FITS As DataGridViewTextBoxColumn
    Friend WithEvents STS As DataGridViewTextBoxColumn
    Friend WithEvents OTS As DataGridViewTextBoxColumn
    Friend WithEvents InstallS As DataGridViewTextBoxColumn
    Friend WithEvents CasePaintS As DataGridViewTextBoxColumn
    Friend WithEvents LeadS As DataGridViewCheckBoxColumn
    Friend WithEvents STResistenceS As DataGridViewCheckBoxColumn
    Friend WithEvents btnDeleteRow As Button
End Class
