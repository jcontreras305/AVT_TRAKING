<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Taxes
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
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.sprHours = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.sprProfit = New System.Windows.Forms.NumericUpDown()
        Me.sprOverhead = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.sprMiselaneos = New System.Windows.Forms.NumericUpDown()
        Me.sprMesh = New System.Windows.Forms.NumericUpDown()
        Me.sprYoYos = New System.Windows.Forms.NumericUpDown()
        Me.sprScaffold = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.sprFringe = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.sprPPE = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.sprConsumable = New System.Windows.Forms.NumericUpDown()
        Me.sprSmall = New System.Windows.Forms.NumericUpDown()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.sprGenLiab = New System.Windows.Forms.NumericUpDown()
        Me.sprPollution = New System.Windows.Forms.NumericUpDown()
        Me.sprUmbr = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.sprHealt = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sprFICA = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sprSUI = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.sprWC = New System.Windows.Forms.NumericUpDown()
        Me.sprFUI = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblTaxesST = New System.Windows.Forms.DataGridView()
        Me.clmEmployee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FUI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GenLiab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Umbr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pollution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Healt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fringe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Small = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Scaffold = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YoYos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mesh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Miselaneos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Overhead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tblAverage = New System.Windows.Forms.DataGridView()
        Me.EmployeeBW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FICAAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FUIAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUIAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WCAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GenLiabAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UmbrAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PullutionAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HealtAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FringeAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PPEAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConsumableAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScaffoldAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YoyosAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiselaneosAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OverheadAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfitAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STTOTALAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.sprQtyHelper = New System.Windows.Forms.NumericUpDown()
        Me.sprBWHelper = New System.Windows.Forms.NumericUpDown()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.sprQtyApprentice = New System.Windows.Forms.NumericUpDown()
        Me.sprBWApprentice = New System.Windows.Forms.NumericUpDown()
        Me.sprQtyCraftsman = New System.Windows.Forms.NumericUpDown()
        Me.sprBWCraftsman = New System.Windows.Forms.NumericUpDown()
        Me.sprQtyJourneyman = New System.Windows.Forms.NumericUpDown()
        Me.sprBWJourneyman = New System.Windows.Forms.NumericUpDown()
        Me.sprQtyForeman = New System.Windows.Forms.NumericUpDown()
        Me.sprBWForeman = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.sprQtyHelperP = New System.Windows.Forms.NumericUpDown()
        Me.sprBWHelperP = New System.Windows.Forms.NumericUpDown()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.sprQtyApprenticeP = New System.Windows.Forms.NumericUpDown()
        Me.sprBWApprenticeP = New System.Windows.Forms.NumericUpDown()
        Me.sprQtyCraftsmanP = New System.Windows.Forms.NumericUpDown()
        Me.sprBWCraftsmanP = New System.Windows.Forms.NumericUpDown()
        Me.sprQtyJourneymanP = New System.Windows.Forms.NumericUpDown()
        Me.sprBWJourneymanP = New System.Windows.Forms.NumericUpDown()
        Me.sprQtyForemanP = New System.Windows.Forms.NumericUpDown()
        Me.sprBWForemanP = New System.Windows.Forms.NumericUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblTaxesPT = New System.Windows.Forms.DataGridView()
        Me.clmEmployeeP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FICAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FUIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PTTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.tblAverageP = New System.Windows.Forms.DataGridView()
        Me.EmployeeBWP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FICAAVP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FUIAVP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUIAVP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PTTOTALAV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.sprSUIP = New System.Windows.Forms.NumericUpDown()
        Me.sprFUIP = New System.Windows.Forms.NumericUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.sprFicaP = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TitleBar.SuspendLayout()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        CType(Me.sprProfit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprOverhead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        CType(Me.sprMiselaneos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprMesh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprYoYos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprScaffold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        CType(Me.sprFringe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPPE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprConsumable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSmall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        CType(Me.sprGenLiab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprPollution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprUmbr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprHealt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel14.SuspendLayout()
        CType(Me.sprFICA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprSUI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprWC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprFUI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.tblTaxesST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblAverage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.sprQtyHelper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWHelper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyApprentice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWApprentice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyCraftsman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWCraftsman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyJourneyman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWJourneyman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyForeman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWForeman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.sprQtyHelperP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWHelperP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyApprenticeP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWApprenticeP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyCraftsmanP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWCraftsmanP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyJourneymanP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWJourneymanP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprQtyForemanP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBWForemanP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.tblTaxesPT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.tblAverageP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel15.SuspendLayout()
        CType(Me.sprSUIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprFUIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprFicaP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TitleBar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(938, 535)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TitleBar
        '
        Me.TitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.TitleBar.Controls.Add(Me.btnRestore)
        Me.TitleBar.Controls.Add(Me.PictureBox3)
        Me.TitleBar.Controls.Add(Me.btnMaximize)
        Me.TitleBar.Controls.Add(Me.Label29)
        Me.TitleBar.Controls.Add(Me.btnSave)
        Me.TitleBar.Controls.Add(Me.lblTask)
        Me.TitleBar.Controls.Add(Me.Label28)
        Me.TitleBar.Controls.Add(Me.sprHours)
        Me.TitleBar.Controls.Add(Me.Label27)
        Me.TitleBar.Controls.Add(Me.PictureBox1)
        Me.TitleBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleBar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleBar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TitleBar.Location = New System.Drawing.Point(3, 3)
        Me.TitleBar.Name = "TitleBar"
        Me.TitleBar.Size = New System.Drawing.Size(932, 74)
        Me.TitleBar.TabIndex = 0
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(900, 3)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(29, 32)
        Me.btnRestore.TabIndex = 9
        Me.btnRestore.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(871, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 28)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(903, 3)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(29, 28)
        Me.btnMaximize.TabIndex = 7
        Me.btnMaximize.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(3, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(62, 18)
        Me.Label29.TabIndex = 6
        Me.Label29.Text = "Taxes"
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(384, 39)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 32)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblTask
        '
        Me.lblTask.AutoSize = True
        Me.lblTask.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.ForeColor = System.Drawing.Color.White
        Me.lblTask.Location = New System.Drawing.Point(181, 44)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(136, 18)
        Me.lblTask.TabIndex = 4
        Me.lblTask.Text = "00000000-000"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(138, 44)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(33, 13)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Task"
        '
        'sprHours
        '
        Me.sprHours.Location = New System.Drawing.Point(51, 42)
        Me.sprHours.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.sprHours.Name = "sprHours"
        Me.sprHours.Size = New System.Drawing.Size(67, 21)
        Me.sprHours.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 44)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 13)
        Me.Label27.TabIndex = 1
        Me.Label27.Text = "Hours"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox1.Location = New System.Drawing.Point(887, 37)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 34)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 83)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(932, 449)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(924, 423)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Breakdown- ST"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.21621!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.78379!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(918, 417)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Panel7, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel6, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel5, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(912, 111)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel7.Controls.Add(Me.TableLayoutPanel10)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel7.Location = New System.Drawing.Point(731, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(178, 105)
        Me.Panel7.TabIndex = 4
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.Label20, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.sprProfit, 1, 1)
        Me.TableLayoutPanel10.Controls.Add(Me.sprOverhead, 1, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.Label19, 0, 1)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 4
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(178, 105)
        Me.TableLayoutPanel10.TabIndex = 36
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Location = New System.Drawing.Point(3, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 26)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "Overhead"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprProfit
        '
        Me.sprProfit.DecimalPlaces = 2
        Me.sprProfit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprProfit.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprProfit.Location = New System.Drawing.Point(92, 29)
        Me.sprProfit.Name = "sprProfit"
        Me.sprProfit.Size = New System.Drawing.Size(83, 21)
        Me.sprProfit.TabIndex = 35
        Me.sprProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprOverhead
        '
        Me.sprOverhead.DecimalPlaces = 2
        Me.sprOverhead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprOverhead.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprOverhead.Location = New System.Drawing.Point(92, 3)
        Me.sprOverhead.Name = "sprOverhead"
        Me.sprOverhead.Size = New System.Drawing.Size(83, 21)
        Me.sprOverhead.TabIndex = 34
        Me.sprOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Location = New System.Drawing.Point(3, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 26)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Profit"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel6.Controls.Add(Me.TableLayoutPanel11)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel6.Location = New System.Drawing.Point(549, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(176, 105)
        Me.Panel6.TabIndex = 3
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.Label16, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.sprMiselaneos, 1, 3)
        Me.TableLayoutPanel11.Controls.Add(Me.sprMesh, 1, 2)
        Me.TableLayoutPanel11.Controls.Add(Me.sprYoYos, 1, 1)
        Me.TableLayoutPanel11.Controls.Add(Me.sprScaffold, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.Label15, 0, 1)
        Me.TableLayoutPanel11.Controls.Add(Me.Label14, 0, 2)
        Me.TableLayoutPanel11.Controls.Add(Me.Label13, 0, 3)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 4
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(176, 105)
        Me.TableLayoutPanel11.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(3, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 26)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Scaffold"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprMiselaneos
        '
        Me.sprMiselaneos.DecimalPlaces = 2
        Me.sprMiselaneos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprMiselaneos.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprMiselaneos.Location = New System.Drawing.Point(91, 81)
        Me.sprMiselaneos.Name = "sprMiselaneos"
        Me.sprMiselaneos.Size = New System.Drawing.Size(82, 21)
        Me.sprMiselaneos.TabIndex = 15
        Me.sprMiselaneos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprMesh
        '
        Me.sprMesh.DecimalPlaces = 2
        Me.sprMesh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprMesh.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprMesh.Location = New System.Drawing.Point(91, 55)
        Me.sprMesh.Name = "sprMesh"
        Me.sprMesh.Size = New System.Drawing.Size(82, 21)
        Me.sprMesh.TabIndex = 14
        Me.sprMesh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprYoYos
        '
        Me.sprYoYos.DecimalPlaces = 2
        Me.sprYoYos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprYoYos.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprYoYos.Location = New System.Drawing.Point(91, 29)
        Me.sprYoYos.Name = "sprYoYos"
        Me.sprYoYos.Size = New System.Drawing.Size(82, 21)
        Me.sprYoYos.TabIndex = 13
        Me.sprYoYos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprScaffold
        '
        Me.sprScaffold.DecimalPlaces = 2
        Me.sprScaffold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprScaffold.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprScaffold.Location = New System.Drawing.Point(91, 3)
        Me.sprScaffold.Name = "sprScaffold"
        Me.sprScaffold.Size = New System.Drawing.Size(82, 21)
        Me.sprScaffold.TabIndex = 12
        Me.sprScaffold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Location = New System.Drawing.Point(3, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 26)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Yo-Yo's"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Location = New System.Drawing.Point(3, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 26)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Mesh"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(3, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 27)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Miselaneos"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel5.Controls.Add(Me.TableLayoutPanel12)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel5.Location = New System.Drawing.Point(367, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(176, 105)
        Me.Panel5.TabIndex = 2
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.sprFringe, 1, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.Label11, 0, 1)
        Me.TableLayoutPanel12.Controls.Add(Me.sprPPE, 1, 2)
        Me.TableLayoutPanel12.Controls.Add(Me.Label10, 0, 2)
        Me.TableLayoutPanel12.Controls.Add(Me.Label9, 0, 3)
        Me.TableLayoutPanel12.Controls.Add(Me.sprConsumable, 1, 3)
        Me.TableLayoutPanel12.Controls.Add(Me.sprSmall, 1, 1)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 4
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(176, 105)
        Me.TableLayoutPanel12.TabIndex = 37
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 26)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Fringe"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprFringe
        '
        Me.sprFringe.DecimalPlaces = 2
        Me.sprFringe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprFringe.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprFringe.Location = New System.Drawing.Point(91, 3)
        Me.sprFringe.Name = "sprFringe"
        Me.sprFringe.Size = New System.Drawing.Size(82, 21)
        Me.sprFringe.TabIndex = 8
        Me.sprFringe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(3, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 26)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Small"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprPPE
        '
        Me.sprPPE.DecimalPlaces = 2
        Me.sprPPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprPPE.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprPPE.Location = New System.Drawing.Point(91, 55)
        Me.sprPPE.Name = "sprPPE"
        Me.sprPPE.Size = New System.Drawing.Size(82, 21)
        Me.sprPPE.TabIndex = 10
        Me.sprPPE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(3, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 26)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "PPE"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 27)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Consumable"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprConsumable
        '
        Me.sprConsumable.DecimalPlaces = 2
        Me.sprConsumable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprConsumable.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprConsumable.Location = New System.Drawing.Point(91, 81)
        Me.sprConsumable.Name = "sprConsumable"
        Me.sprConsumable.Size = New System.Drawing.Size(82, 21)
        Me.sprConsumable.TabIndex = 11
        Me.sprConsumable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprSmall
        '
        Me.sprSmall.DecimalPlaces = 2
        Me.sprSmall.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprSmall.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprSmall.Location = New System.Drawing.Point(91, 29)
        Me.sprSmall.Name = "sprSmall"
        Me.sprSmall.Size = New System.Drawing.Size(82, 21)
        Me.sprSmall.TabIndex = 9
        Me.sprSmall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel4.Controls.Add(Me.TableLayoutPanel13)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel4.Location = New System.Drawing.Point(185, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(176, 105)
        Me.Panel4.TabIndex = 1
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.ColumnCount = 2
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.sprGenLiab, 1, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.sprPollution, 1, 2)
        Me.TableLayoutPanel13.Controls.Add(Me.sprUmbr, 1, 1)
        Me.TableLayoutPanel13.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel13.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel13.Controls.Add(Me.sprHealt, 1, 3)
        Me.TableLayoutPanel13.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 4
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(176, 105)
        Me.TableLayoutPanel13.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 26)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Gen Liab"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprGenLiab
        '
        Me.sprGenLiab.DecimalPlaces = 2
        Me.sprGenLiab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprGenLiab.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprGenLiab.Location = New System.Drawing.Point(91, 3)
        Me.sprGenLiab.Name = "sprGenLiab"
        Me.sprGenLiab.Size = New System.Drawing.Size(82, 21)
        Me.sprGenLiab.TabIndex = 4
        Me.sprGenLiab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprPollution
        '
        Me.sprPollution.DecimalPlaces = 2
        Me.sprPollution.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprPollution.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprPollution.Location = New System.Drawing.Point(91, 55)
        Me.sprPollution.Name = "sprPollution"
        Me.sprPollution.Size = New System.Drawing.Size(82, 21)
        Me.sprPollution.TabIndex = 6
        Me.sprPollution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprUmbr
        '
        Me.sprUmbr.DecimalPlaces = 2
        Me.sprUmbr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprUmbr.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprUmbr.Location = New System.Drawing.Point(91, 29)
        Me.sprUmbr.Name = "sprUmbr"
        Me.sprUmbr.Size = New System.Drawing.Size(82, 21)
        Me.sprUmbr.TabIndex = 5
        Me.sprUmbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 26)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Pullution"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 27)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Healt"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprHealt
        '
        Me.sprHealt.DecimalPlaces = 2
        Me.sprHealt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprHealt.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprHealt.Location = New System.Drawing.Point(91, 81)
        Me.sprHealt.Name = "sprHealt"
        Me.sprHealt.Size = New System.Drawing.Size(82, 21)
        Me.sprHealt.TabIndex = 7
        Me.sprHealt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 26)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Umbr"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TableLayoutPanel14)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(176, 105)
        Me.Panel3.TabIndex = 0
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.ColumnCount = 2
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.sprFICA, 1, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel14.Controls.Add(Me.sprSUI, 1, 2)
        Me.TableLayoutPanel14.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel14.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel14.Controls.Add(Me.sprWC, 1, 3)
        Me.TableLayoutPanel14.Controls.Add(Me.sprFUI, 1, 1)
        Me.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 4
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(176, 105)
        Me.TableLayoutPanel14.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 26)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "FICA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprFICA
        '
        Me.sprFICA.DecimalPlaces = 2
        Me.sprFICA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprFICA.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprFICA.Location = New System.Drawing.Point(91, 3)
        Me.sprFICA.Name = "sprFICA"
        Me.sprFICA.Size = New System.Drawing.Size(82, 21)
        Me.sprFICA.TabIndex = 0
        Me.sprFICA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 26)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "FUI"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprSUI
        '
        Me.sprSUI.DecimalPlaces = 2
        Me.sprSUI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprSUI.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprSUI.Location = New System.Drawing.Point(91, 55)
        Me.sprSUI.Name = "sprSUI"
        Me.sprSUI.Size = New System.Drawing.Size(82, 21)
        Me.sprSUI.TabIndex = 2
        Me.sprSUI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 26)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "SUI"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 27)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "WC"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprWC
        '
        Me.sprWC.DecimalPlaces = 2
        Me.sprWC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprWC.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprWC.Location = New System.Drawing.Point(91, 81)
        Me.sprWC.Name = "sprWC"
        Me.sprWC.Size = New System.Drawing.Size(82, 21)
        Me.sprWC.TabIndex = 3
        Me.sprWC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprFUI
        '
        Me.sprFUI.DecimalPlaces = 2
        Me.sprFUI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprFUI.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprFUI.Location = New System.Drawing.Point(91, 29)
        Me.sprFUI.Name = "sprFUI"
        Me.sprFUI.Size = New System.Drawing.Size(82, 21)
        Me.sprFUI.TabIndex = 1
        Me.sprFUI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 120)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(912, 294)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.tblTaxesST, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tblAverage, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(174, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(735, 288)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'tblTaxesST
        '
        Me.tblTaxesST.AllowUserToAddRows = False
        Me.tblTaxesST.AllowUserToDeleteRows = False
        Me.tblTaxesST.BackgroundColor = System.Drawing.SystemColors.Window
        Me.tblTaxesST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblTaxesST.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmEmployee, Me.FICA, Me.FUI, Me.SUI, Me.WC, Me.GenLiab, Me.Umbr, Me.Pollution, Me.Healt, Me.Fringe, Me.Small, Me.PPE, Me.Consumable, Me.Scaffold, Me.YoYos, Me.Mesh, Me.Miselaneos, Me.Overhead, Me.Profit, Me.STTOTAL})
        Me.tblTaxesST.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTaxesST.Location = New System.Drawing.Point(3, 3)
        Me.tblTaxesST.Name = "tblTaxesST"
        Me.tblTaxesST.ReadOnly = True
        Me.tblTaxesST.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.tblTaxesST.Size = New System.Drawing.Size(729, 192)
        Me.tblTaxesST.TabIndex = 0
        '
        'clmEmployee
        '
        Me.clmEmployee.Frozen = True
        Me.clmEmployee.HeaderText = "Employee"
        Me.clmEmployee.Name = "clmEmployee"
        Me.clmEmployee.ReadOnly = True
        '
        'FICA
        '
        Me.FICA.HeaderText = "FICA"
        Me.FICA.Name = "FICA"
        Me.FICA.ReadOnly = True
        '
        'FUI
        '
        Me.FUI.HeaderText = "FUI"
        Me.FUI.Name = "FUI"
        Me.FUI.ReadOnly = True
        '
        'SUI
        '
        Me.SUI.HeaderText = "SUI"
        Me.SUI.Name = "SUI"
        Me.SUI.ReadOnly = True
        '
        'WC
        '
        Me.WC.HeaderText = "WC"
        Me.WC.Name = "WC"
        Me.WC.ReadOnly = True
        '
        'GenLiab
        '
        Me.GenLiab.HeaderText = "Gen Liab"
        Me.GenLiab.Name = "GenLiab"
        Me.GenLiab.ReadOnly = True
        '
        'Umbr
        '
        Me.Umbr.HeaderText = "Umbr"
        Me.Umbr.Name = "Umbr"
        Me.Umbr.ReadOnly = True
        '
        'Pollution
        '
        Me.Pollution.HeaderText = "Pollution"
        Me.Pollution.Name = "Pollution"
        Me.Pollution.ReadOnly = True
        '
        'Healt
        '
        Me.Healt.HeaderText = "Healt"
        Me.Healt.Name = "Healt"
        Me.Healt.ReadOnly = True
        '
        'Fringe
        '
        Me.Fringe.HeaderText = "Fringe"
        Me.Fringe.Name = "Fringe"
        Me.Fringe.ReadOnly = True
        '
        'Small
        '
        Me.Small.HeaderText = "Small"
        Me.Small.Name = "Small"
        Me.Small.ReadOnly = True
        '
        'PPE
        '
        Me.PPE.HeaderText = "PPE"
        Me.PPE.Name = "PPE"
        Me.PPE.ReadOnly = True
        '
        'Consumable
        '
        Me.Consumable.HeaderText = "Consumable"
        Me.Consumable.Name = "Consumable"
        Me.Consumable.ReadOnly = True
        '
        'Scaffold
        '
        Me.Scaffold.HeaderText = "Scaffold"
        Me.Scaffold.Name = "Scaffold"
        Me.Scaffold.ReadOnly = True
        '
        'YoYos
        '
        Me.YoYos.HeaderText = "Yo-Yo's"
        Me.YoYos.Name = "YoYos"
        Me.YoYos.ReadOnly = True
        '
        'Mesh
        '
        Me.Mesh.HeaderText = "Mesh"
        Me.Mesh.Name = "Mesh"
        Me.Mesh.ReadOnly = True
        '
        'Miselaneos
        '
        Me.Miselaneos.HeaderText = "Miselaneos"
        Me.Miselaneos.Name = "Miselaneos"
        Me.Miselaneos.ReadOnly = True
        '
        'Overhead
        '
        Me.Overhead.HeaderText = "Overhead"
        Me.Overhead.Name = "Overhead"
        Me.Overhead.ReadOnly = True
        '
        'Profit
        '
        Me.Profit.HeaderText = "Profit"
        Me.Profit.Name = "Profit"
        Me.Profit.ReadOnly = True
        '
        'STTOTAL
        '
        Me.STTOTAL.HeaderText = "ST TOTAL"
        Me.STTOTAL.Name = "STTOTAL"
        Me.STTOTAL.ReadOnly = True
        '
        'tblAverage
        '
        Me.tblAverage.AllowUserToAddRows = False
        Me.tblAverage.AllowUserToDeleteRows = False
        Me.tblAverage.BackgroundColor = System.Drawing.SystemColors.Window
        Me.tblAverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblAverage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeBW, Me.FICAAV, Me.FUIAV, Me.SUIAV, Me.WCAV, Me.GenLiabAV, Me.UmbrAV, Me.PullutionAV, Me.HealtAV, Me.FringeAV, Me.SmallAV, Me.PPEAV, Me.ConsumableAV, Me.ScaffoldAV, Me.YoyosAV, Me.MeshAV, Me.MiselaneosAV, Me.OverheadAV, Me.ProfitAV, Me.STTOTALAV})
        Me.tblAverage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblAverage.Location = New System.Drawing.Point(3, 201)
        Me.tblAverage.Name = "tblAverage"
        Me.tblAverage.ReadOnly = True
        Me.tblAverage.Size = New System.Drawing.Size(729, 84)
        Me.tblAverage.TabIndex = 1
        '
        'EmployeeBW
        '
        Me.EmployeeBW.Frozen = True
        Me.EmployeeBW.HeaderText = "EmployeeBW"
        Me.EmployeeBW.Name = "EmployeeBW"
        Me.EmployeeBW.ReadOnly = True
        '
        'FICAAV
        '
        Me.FICAAV.HeaderText = "FICA AV"
        Me.FICAAV.Name = "FICAAV"
        Me.FICAAV.ReadOnly = True
        '
        'FUIAV
        '
        Me.FUIAV.HeaderText = "FUI AV"
        Me.FUIAV.Name = "FUIAV"
        Me.FUIAV.ReadOnly = True
        '
        'SUIAV
        '
        Me.SUIAV.HeaderText = "SUI AV"
        Me.SUIAV.Name = "SUIAV"
        Me.SUIAV.ReadOnly = True
        '
        'WCAV
        '
        Me.WCAV.HeaderText = "WC AV"
        Me.WCAV.Name = "WCAV"
        Me.WCAV.ReadOnly = True
        '
        'GenLiabAV
        '
        Me.GenLiabAV.HeaderText = "GenLiab AV"
        Me.GenLiabAV.Name = "GenLiabAV"
        Me.GenLiabAV.ReadOnly = True
        '
        'UmbrAV
        '
        Me.UmbrAV.HeaderText = "Umbr AV"
        Me.UmbrAV.Name = "UmbrAV"
        Me.UmbrAV.ReadOnly = True
        '
        'PullutionAV
        '
        Me.PullutionAV.HeaderText = "Pullution AV"
        Me.PullutionAV.Name = "PullutionAV"
        Me.PullutionAV.ReadOnly = True
        '
        'HealtAV
        '
        Me.HealtAV.HeaderText = "Healt AV"
        Me.HealtAV.Name = "HealtAV"
        Me.HealtAV.ReadOnly = True
        '
        'FringeAV
        '
        Me.FringeAV.HeaderText = "Fringe AV"
        Me.FringeAV.Name = "FringeAV"
        Me.FringeAV.ReadOnly = True
        '
        'SmallAV
        '
        Me.SmallAV.HeaderText = "Small AV"
        Me.SmallAV.Name = "SmallAV"
        Me.SmallAV.ReadOnly = True
        '
        'PPEAV
        '
        Me.PPEAV.HeaderText = "PPE AV"
        Me.PPEAV.Name = "PPEAV"
        Me.PPEAV.ReadOnly = True
        '
        'ConsumableAV
        '
        Me.ConsumableAV.HeaderText = "Consumable AV"
        Me.ConsumableAV.Name = "ConsumableAV"
        Me.ConsumableAV.ReadOnly = True
        '
        'ScaffoldAV
        '
        Me.ScaffoldAV.HeaderText = "Scaffold AV"
        Me.ScaffoldAV.Name = "ScaffoldAV"
        Me.ScaffoldAV.ReadOnly = True
        '
        'YoyosAV
        '
        Me.YoyosAV.HeaderText = "Yoyos AV"
        Me.YoyosAV.Name = "YoyosAV"
        Me.YoyosAV.ReadOnly = True
        '
        'MeshAV
        '
        Me.MeshAV.HeaderText = "Mesh AV"
        Me.MeshAV.Name = "MeshAV"
        Me.MeshAV.ReadOnly = True
        '
        'MiselaneosAV
        '
        Me.MiselaneosAV.HeaderText = "Miselaneos AV"
        Me.MiselaneosAV.Name = "MiselaneosAV"
        Me.MiselaneosAV.ReadOnly = True
        '
        'OverheadAV
        '
        Me.OverheadAV.HeaderText = "Overhead AV"
        Me.OverheadAV.Name = "OverheadAV"
        Me.OverheadAV.ReadOnly = True
        '
        'ProfitAV
        '
        Me.ProfitAV.HeaderText = "Profit AV"
        Me.ProfitAV.Name = "ProfitAV"
        Me.ProfitAV.ReadOnly = True
        '
        'STTOTALAV
        '
        Me.STTOTALAV.HeaderText = "ST TOTAL AV"
        Me.STTOTALAV.Name = "STTOTALAV"
        Me.STTOTALAV.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label49)
        Me.Panel2.Controls.Add(Me.Label48)
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.Label46)
        Me.Panel2.Controls.Add(Me.Label35)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.sprQtyHelper)
        Me.Panel2.Controls.Add(Me.sprBWHelper)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.sprQtyApprentice)
        Me.Panel2.Controls.Add(Me.sprBWApprentice)
        Me.Panel2.Controls.Add(Me.sprQtyCraftsman)
        Me.Panel2.Controls.Add(Me.sprBWCraftsman)
        Me.Panel2.Controls.Add(Me.sprQtyJourneyman)
        Me.Panel2.Controls.Add(Me.sprBWJourneyman)
        Me.Panel2.Controls.Add(Me.sprQtyForeman)
        Me.Panel2.Controls.Add(Me.sprBWForeman)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(165, 288)
        Me.Panel2.TabIndex = 1
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(9, 231)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(15, 13)
        Me.Label49.TabIndex = 24
        Me.Label49.Text = "$"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(9, 184)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(15, 13)
        Me.Label48.TabIndex = 23
        Me.Label48.Text = "$"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(9, 134)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(15, 13)
        Me.Label47.TabIndex = 22
        Me.Label47.Text = "$"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(9, 87)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(15, 13)
        Me.Label46.TabIndex = 21
        Me.Label46.Text = "$"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(9, 32)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(15, 13)
        Me.Label35.TabIndex = 20
        Me.Label35.Text = "$"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(84, 231)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 19
        Me.Label30.Text = "Qty."
        '
        'sprQtyHelper
        '
        Me.sprQtyHelper.Location = New System.Drawing.Point(114, 229)
        Me.sprQtyHelper.Name = "sprQtyHelper"
        Me.sprQtyHelper.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyHelper.TabIndex = 18
        Me.sprQtyHelper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWHelper
        '
        Me.sprBWHelper.DecimalPlaces = 2
        Me.sprBWHelper.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.sprBWHelper.Location = New System.Drawing.Point(25, 229)
        Me.sprBWHelper.Name = "sprBWHelper"
        Me.sprBWHelper.Size = New System.Drawing.Size(55, 21)
        Me.sprBWHelper.TabIndex = 17
        Me.sprBWHelper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 209)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(69, 13)
        Me.Label31.TabIndex = 16
        Me.Label31.Text = "Scf. Helper"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(87, 184)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(30, 13)
        Me.Label26.TabIndex = 15
        Me.Label26.Text = "Qty."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(87, 134)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(30, 13)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Qty."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(87, 81)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(30, 13)
        Me.Label24.TabIndex = 13
        Me.Label24.Text = "Qty."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(87, 32)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 13)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Qty."
        '
        'sprQtyApprentice
        '
        Me.sprQtyApprentice.Location = New System.Drawing.Point(117, 182)
        Me.sprQtyApprentice.Name = "sprQtyApprentice"
        Me.sprQtyApprentice.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyApprentice.TabIndex = 11
        Me.sprQtyApprentice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWApprentice
        '
        Me.sprBWApprentice.DecimalPlaces = 2
        Me.sprBWApprentice.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.sprBWApprentice.Location = New System.Drawing.Point(28, 182)
        Me.sprBWApprentice.Name = "sprBWApprentice"
        Me.sprBWApprentice.Size = New System.Drawing.Size(55, 21)
        Me.sprBWApprentice.TabIndex = 10
        Me.sprBWApprentice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprQtyCraftsman
        '
        Me.sprQtyCraftsman.Location = New System.Drawing.Point(117, 132)
        Me.sprQtyCraftsman.Name = "sprQtyCraftsman"
        Me.sprQtyCraftsman.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyCraftsman.TabIndex = 9
        Me.sprQtyCraftsman.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWCraftsman
        '
        Me.sprBWCraftsman.DecimalPlaces = 2
        Me.sprBWCraftsman.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.sprBWCraftsman.Location = New System.Drawing.Point(28, 132)
        Me.sprBWCraftsman.Name = "sprBWCraftsman"
        Me.sprBWCraftsman.Size = New System.Drawing.Size(55, 21)
        Me.sprBWCraftsman.TabIndex = 8
        Me.sprBWCraftsman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprQtyJourneyman
        '
        Me.sprQtyJourneyman.Location = New System.Drawing.Point(117, 79)
        Me.sprQtyJourneyman.Name = "sprQtyJourneyman"
        Me.sprQtyJourneyman.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyJourneyman.TabIndex = 7
        Me.sprQtyJourneyman.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWJourneyman
        '
        Me.sprBWJourneyman.DecimalPlaces = 2
        Me.sprBWJourneyman.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.sprBWJourneyman.Location = New System.Drawing.Point(28, 79)
        Me.sprBWJourneyman.Name = "sprBWJourneyman"
        Me.sprBWJourneyman.Size = New System.Drawing.Size(55, 21)
        Me.sprBWJourneyman.TabIndex = 6
        Me.sprBWJourneyman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprQtyForeman
        '
        Me.sprQtyForeman.Location = New System.Drawing.Point(117, 30)
        Me.sprQtyForeman.Name = "sprQtyForeman"
        Me.sprQtyForeman.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyForeman.TabIndex = 5
        Me.sprQtyForeman.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWForeman
        '
        Me.sprBWForeman.DecimalPlaces = 2
        Me.sprBWForeman.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.sprBWForeman.Location = New System.Drawing.Point(28, 30)
        Me.sprBWForeman.Name = "sprBWForeman"
        Me.sprBWForeman.Size = New System.Drawing.Size(55, 21)
        Me.sprBWForeman.TabIndex = 4
        Me.sprBWForeman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 162)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Scf. Apprentice"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 111)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(92, 13)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Scf. Craftsman"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 59)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(102, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Scf. Journeyman"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Scf. Foreman"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(924, 423)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Breakdown- PT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel8, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel7, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(918, 417)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.73684!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.26316!))
        Me.TableLayoutPanel8.Controls.Add(Me.Panel8, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel9, 1, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 92)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(912, 322)
        Me.TableLayoutPanel8.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel8.Controls.Add(Me.Label54)
        Me.Panel8.Controls.Add(Me.Label53)
        Me.Panel8.Controls.Add(Me.Label52)
        Me.Panel8.Controls.Add(Me.Label51)
        Me.Panel8.Controls.Add(Me.Label50)
        Me.Panel8.Controls.Add(Me.Label36)
        Me.Panel8.Controls.Add(Me.sprQtyHelperP)
        Me.Panel8.Controls.Add(Me.sprBWHelperP)
        Me.Panel8.Controls.Add(Me.Label37)
        Me.Panel8.Controls.Add(Me.Label38)
        Me.Panel8.Controls.Add(Me.Label39)
        Me.Panel8.Controls.Add(Me.Label40)
        Me.Panel8.Controls.Add(Me.Label41)
        Me.Panel8.Controls.Add(Me.sprQtyApprenticeP)
        Me.Panel8.Controls.Add(Me.sprBWApprenticeP)
        Me.Panel8.Controls.Add(Me.sprQtyCraftsmanP)
        Me.Panel8.Controls.Add(Me.sprBWCraftsmanP)
        Me.Panel8.Controls.Add(Me.sprQtyJourneymanP)
        Me.Panel8.Controls.Add(Me.sprBWJourneymanP)
        Me.Panel8.Controls.Add(Me.sprQtyForemanP)
        Me.Panel8.Controls.Add(Me.sprBWForemanP)
        Me.Panel8.Controls.Add(Me.Label42)
        Me.Panel8.Controls.Add(Me.Label43)
        Me.Panel8.Controls.Add(Me.Label44)
        Me.Panel8.Controls.Add(Me.Label45)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel8.Location = New System.Drawing.Point(3, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(173, 316)
        Me.Panel8.TabIndex = 2
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(7, 231)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(15, 13)
        Me.Label54.TabIndex = 25
        Me.Label54.Text = "$"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(7, 184)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(15, 13)
        Me.Label53.TabIndex = 24
        Me.Label53.Text = "$"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(7, 134)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(15, 13)
        Me.Label52.TabIndex = 23
        Me.Label52.Text = "$"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(7, 81)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(15, 13)
        Me.Label51.TabIndex = 22
        Me.Label51.Text = "$"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(7, 32)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(15, 13)
        Me.Label50.TabIndex = 21
        Me.Label50.Text = "$"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(85, 231)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(30, 13)
        Me.Label36.TabIndex = 19
        Me.Label36.Text = "Qty."
        '
        'sprQtyHelperP
        '
        Me.sprQtyHelperP.Location = New System.Drawing.Point(116, 229)
        Me.sprQtyHelperP.Name = "sprQtyHelperP"
        Me.sprQtyHelperP.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyHelperP.TabIndex = 18
        Me.sprQtyHelperP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWHelperP
        '
        Me.sprBWHelperP.DecimalPlaces = 2
        Me.sprBWHelperP.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBWHelperP.Location = New System.Drawing.Point(25, 229)
        Me.sprBWHelperP.Name = "sprBWHelperP"
        Me.sprBWHelperP.Size = New System.Drawing.Size(55, 21)
        Me.sprBWHelperP.TabIndex = 17
        Me.sprBWHelperP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(3, 209)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(69, 13)
        Me.Label37.TabIndex = 16
        Me.Label37.Text = "Scf. Helper"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(88, 184)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(30, 13)
        Me.Label38.TabIndex = 15
        Me.Label38.Text = "Qty."
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(88, 134)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(30, 13)
        Me.Label39.TabIndex = 14
        Me.Label39.Text = "Qty."
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(88, 81)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(30, 13)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "Qty."
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(88, 32)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(30, 13)
        Me.Label41.TabIndex = 12
        Me.Label41.Text = "Qty."
        '
        'sprQtyApprenticeP
        '
        Me.sprQtyApprenticeP.Location = New System.Drawing.Point(119, 182)
        Me.sprQtyApprenticeP.Name = "sprQtyApprenticeP"
        Me.sprQtyApprenticeP.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyApprenticeP.TabIndex = 11
        Me.sprQtyApprenticeP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWApprenticeP
        '
        Me.sprBWApprenticeP.DecimalPlaces = 2
        Me.sprBWApprenticeP.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBWApprenticeP.Location = New System.Drawing.Point(28, 182)
        Me.sprBWApprenticeP.Name = "sprBWApprenticeP"
        Me.sprBWApprenticeP.Size = New System.Drawing.Size(55, 21)
        Me.sprBWApprenticeP.TabIndex = 10
        Me.sprBWApprenticeP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprQtyCraftsmanP
        '
        Me.sprQtyCraftsmanP.Location = New System.Drawing.Point(119, 132)
        Me.sprQtyCraftsmanP.Name = "sprQtyCraftsmanP"
        Me.sprQtyCraftsmanP.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyCraftsmanP.TabIndex = 9
        Me.sprQtyCraftsmanP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWCraftsmanP
        '
        Me.sprBWCraftsmanP.DecimalPlaces = 2
        Me.sprBWCraftsmanP.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBWCraftsmanP.Location = New System.Drawing.Point(28, 132)
        Me.sprBWCraftsmanP.Name = "sprBWCraftsmanP"
        Me.sprBWCraftsmanP.Size = New System.Drawing.Size(55, 21)
        Me.sprBWCraftsmanP.TabIndex = 8
        Me.sprBWCraftsmanP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprQtyJourneymanP
        '
        Me.sprQtyJourneymanP.Location = New System.Drawing.Point(119, 79)
        Me.sprQtyJourneymanP.Name = "sprQtyJourneymanP"
        Me.sprQtyJourneymanP.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyJourneymanP.TabIndex = 7
        Me.sprQtyJourneymanP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWJourneymanP
        '
        Me.sprBWJourneymanP.DecimalPlaces = 2
        Me.sprBWJourneymanP.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBWJourneymanP.Location = New System.Drawing.Point(28, 79)
        Me.sprBWJourneymanP.Name = "sprBWJourneymanP"
        Me.sprBWJourneymanP.Size = New System.Drawing.Size(55, 21)
        Me.sprBWJourneymanP.TabIndex = 6
        Me.sprBWJourneymanP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprQtyForemanP
        '
        Me.sprQtyForemanP.Location = New System.Drawing.Point(119, 30)
        Me.sprQtyForemanP.Name = "sprQtyForemanP"
        Me.sprQtyForemanP.Size = New System.Drawing.Size(45, 21)
        Me.sprQtyForemanP.TabIndex = 5
        Me.sprQtyForemanP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprBWForemanP
        '
        Me.sprBWForemanP.DecimalPlaces = 2
        Me.sprBWForemanP.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBWForemanP.Location = New System.Drawing.Point(28, 30)
        Me.sprBWForemanP.Name = "sprBWForemanP"
        Me.sprBWForemanP.Size = New System.Drawing.Size(55, 21)
        Me.sprBWForemanP.TabIndex = 4
        Me.sprBWForemanP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 162)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(93, 13)
        Me.Label42.TabIndex = 3
        Me.Label42.Text = "Scf. Apprentice"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(6, 111)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(92, 13)
        Me.Label43.TabIndex = 2
        Me.Label43.Text = "Scf. Craftsman"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(6, 59)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(102, 13)
        Me.Label44.TabIndex = 1
        Me.Label44.Text = "Scf. Journeyman"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(6, 14)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(82, 13)
        Me.Label45.TabIndex = 0
        Me.Label45.Text = "Scf. Foreman"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.tblTaxesPT, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Panel9, 0, 1)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(182, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 2
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.01205!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.98795!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(727, 316)
        Me.TableLayoutPanel9.TabIndex = 0
        '
        'tblTaxesPT
        '
        Me.tblTaxesPT.AllowUserToAddRows = False
        Me.tblTaxesPT.AllowUserToDeleteRows = False
        Me.tblTaxesPT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblTaxesPT.BackgroundColor = System.Drawing.SystemColors.Window
        Me.tblTaxesPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblTaxesPT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmEmployeeP, Me.FICAP, Me.FUIP, Me.SUIP, Me.PTTOTAL})
        Me.tblTaxesPT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTaxesPT.Location = New System.Drawing.Point(3, 3)
        Me.tblTaxesPT.Name = "tblTaxesPT"
        Me.tblTaxesPT.Size = New System.Drawing.Size(721, 240)
        Me.tblTaxesPT.TabIndex = 0
        '
        'clmEmployeeP
        '
        Me.clmEmployeeP.HeaderText = "Employee"
        Me.clmEmployeeP.Name = "clmEmployeeP"
        Me.clmEmployeeP.ReadOnly = True
        '
        'FICAP
        '
        Me.FICAP.HeaderText = "FICA"
        Me.FICAP.Name = "FICAP"
        Me.FICAP.ReadOnly = True
        '
        'FUIP
        '
        Me.FUIP.HeaderText = "FUI"
        Me.FUIP.Name = "FUIP"
        Me.FUIP.ReadOnly = True
        '
        'SUIP
        '
        Me.SUIP.HeaderText = "SUI"
        Me.SUIP.Name = "SUIP"
        Me.SUIP.ReadOnly = True
        '
        'PTTOTAL
        '
        Me.PTTOTAL.HeaderText = "PT TOTAL"
        Me.PTTOTAL.Name = "PTTOTAL"
        Me.PTTOTAL.ReadOnly = True
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.tblAverageP)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 249)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(721, 64)
        Me.Panel9.TabIndex = 1
        '
        'tblAverageP
        '
        Me.tblAverageP.AllowUserToAddRows = False
        Me.tblAverageP.AllowUserToDeleteRows = False
        Me.tblAverageP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblAverageP.BackgroundColor = System.Drawing.SystemColors.Window
        Me.tblAverageP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblAverageP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeBWP, Me.FICAAVP, Me.FUIAVP, Me.SUIAVP, Me.PTTOTALAV})
        Me.tblAverageP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblAverageP.Location = New System.Drawing.Point(0, 0)
        Me.tblAverageP.Name = "tblAverageP"
        Me.tblAverageP.ReadOnly = True
        Me.tblAverageP.Size = New System.Drawing.Size(721, 64)
        Me.tblAverageP.TabIndex = 0
        '
        'EmployeeBWP
        '
        Me.EmployeeBWP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.EmployeeBWP.Frozen = True
        Me.EmployeeBWP.HeaderText = "EmployeeBW"
        Me.EmployeeBWP.Name = "EmployeeBWP"
        Me.EmployeeBWP.ReadOnly = True
        Me.EmployeeBWP.Width = 170
        '
        'FICAAVP
        '
        Me.FICAAVP.HeaderText = "FICA AV"
        Me.FICAAVP.Name = "FICAAVP"
        Me.FICAAVP.ReadOnly = True
        '
        'FUIAVP
        '
        Me.FUIAVP.HeaderText = "FUI AV"
        Me.FUIAVP.Name = "FUIAVP"
        Me.FUIAVP.ReadOnly = True
        '
        'SUIAVP
        '
        Me.SUIAVP.HeaderText = "SUI AV"
        Me.SUIAVP.Name = "SUIAVP"
        Me.SUIAVP.ReadOnly = True
        '
        'PTTOTALAV
        '
        Me.PTTOTALAV.HeaderText = "PT TOTAL AV"
        Me.PTTOTALAV.Name = "PTTOTALAV"
        Me.PTTOTALAV.ReadOnly = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.06579!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.93421!))
        Me.TableLayoutPanel7.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Panel10, 1, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(912, 83)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TableLayoutPanel15)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(177, 77)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel15
        '
        Me.TableLayoutPanel15.ColumnCount = 2
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel15.Controls.Add(Me.sprSUIP, 1, 2)
        Me.TableLayoutPanel15.Controls.Add(Me.sprFUIP, 1, 1)
        Me.TableLayoutPanel15.Controls.Add(Me.Label34, 0, 2)
        Me.TableLayoutPanel15.Controls.Add(Me.Label32, 0, 0)
        Me.TableLayoutPanel15.Controls.Add(Me.sprFicaP, 1, 0)
        Me.TableLayoutPanel15.Controls.Add(Me.Label33, 0, 1)
        Me.TableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel15.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        Me.TableLayoutPanel15.RowCount = 3
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel15.Size = New System.Drawing.Size(177, 77)
        Me.TableLayoutPanel15.TabIndex = 0
        '
        'sprSUIP
        '
        Me.sprSUIP.DecimalPlaces = 2
        Me.sprSUIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprSUIP.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprSUIP.Location = New System.Drawing.Point(91, 53)
        Me.sprSUIP.Name = "sprSUIP"
        Me.sprSUIP.Size = New System.Drawing.Size(83, 21)
        Me.sprSUIP.TabIndex = 2
        Me.sprSUIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'sprFUIP
        '
        Me.sprFUIP.DecimalPlaces = 2
        Me.sprFUIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprFUIP.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprFUIP.Location = New System.Drawing.Point(91, 28)
        Me.sprFUIP.Name = "sprFUIP"
        Me.sprFUIP.Size = New System.Drawing.Size(83, 21)
        Me.sprFUIP.TabIndex = 1
        Me.sprFUIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label34.Location = New System.Drawing.Point(3, 50)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 27)
        Me.Label34.TabIndex = 18
        Me.Label34.Text = "SUI"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label32.Location = New System.Drawing.Point(3, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(82, 25)
        Me.Label32.TabIndex = 16
        Me.Label32.Text = "FICA"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sprFicaP
        '
        Me.sprFicaP.DecimalPlaces = 2
        Me.sprFicaP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sprFicaP.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.sprFicaP.Location = New System.Drawing.Point(91, 3)
        Me.sprFicaP.Name = "sprFicaP"
        Me.sprFicaP.Size = New System.Drawing.Size(83, 21)
        Me.sprFicaP.TabIndex = 0
        Me.sprFicaP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label33.Location = New System.Drawing.Point(3, 25)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(82, 25)
        Me.Label33.TabIndex = 17
        Me.Label33.Text = "FUI"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(186, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(723, 77)
        Me.Panel10.TabIndex = 2
        '
        'Taxes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 535)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Taxes"
        Me.Text = "Taxes"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TitleBar.ResumeLayout(False)
        Me.TitleBar.PerformLayout()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        CType(Me.sprProfit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprOverhead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        CType(Me.sprMiselaneos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprMesh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprYoYos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprScaffold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel12.PerformLayout()
        CType(Me.sprFringe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprPPE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprConsumable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSmall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.TableLayoutPanel13.PerformLayout()
        CType(Me.sprGenLiab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprPollution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprUmbr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprHealt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.TableLayoutPanel14.PerformLayout()
        CType(Me.sprFICA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprSUI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprWC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprFUI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.tblTaxesST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblAverage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.sprQtyHelper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWHelper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyApprentice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWApprentice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyCraftsman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWCraftsman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyJourneyman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWJourneyman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyForeman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWForeman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.sprQtyHelperP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWHelperP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyApprenticeP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWApprenticeP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyCraftsmanP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWCraftsmanP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyJourneymanP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWJourneymanP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprQtyForemanP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBWForemanP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel9.ResumeLayout(False)
        CType(Me.tblTaxesPT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        CType(Me.tblAverageP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel15.ResumeLayout(False)
        Me.TableLayoutPanel15.PerformLayout()
        CType(Me.sprSUIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprFUIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprFicaP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TitleBar As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents tblTaxesST As DataGridView
    Friend WithEvents sprProfit As NumericUpDown
    Friend WithEvents sprOverhead As NumericUpDown
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sprMiselaneos As NumericUpDown
    Friend WithEvents sprMesh As NumericUpDown
    Friend WithEvents sprYoYos As NumericUpDown
    Friend WithEvents sprScaffold As NumericUpDown
    Friend WithEvents sprConsumable As NumericUpDown
    Friend WithEvents sprPPE As NumericUpDown
    Friend WithEvents sprSmall As NumericUpDown
    Friend WithEvents sprFringe As NumericUpDown
    Friend WithEvents sprHealt As NumericUpDown
    Friend WithEvents sprPollution As NumericUpDown
    Friend WithEvents sprUmbr As NumericUpDown
    Friend WithEvents sprGenLiab As NumericUpDown
    Friend WithEvents sprWC As NumericUpDown
    Friend WithEvents sprSUI As NumericUpDown
    Friend WithEvents sprFUI As NumericUpDown
    Friend WithEvents sprFICA As NumericUpDown
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents sprQtyApprentice As NumericUpDown
    Friend WithEvents sprBWApprentice As NumericUpDown
    Friend WithEvents sprQtyCraftsman As NumericUpDown
    Friend WithEvents sprBWCraftsman As NumericUpDown
    Friend WithEvents sprQtyJourneyman As NumericUpDown
    Friend WithEvents sprBWJourneyman As NumericUpDown
    Friend WithEvents sprQtyForeman As NumericUpDown
    Friend WithEvents sprBWForeman As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lblTask As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents sprHours As NumericUpDown
    Friend WithEvents Label27 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Label30 As Label
    Friend WithEvents sprQtyHelper As NumericUpDown
    Friend WithEvents sprBWHelper As NumericUpDown
    Friend WithEvents Label31 As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label36 As Label
    Friend WithEvents sprQtyHelperP As NumericUpDown
    Friend WithEvents sprBWHelperP As NumericUpDown
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents sprQtyApprenticeP As NumericUpDown
    Friend WithEvents sprBWApprenticeP As NumericUpDown
    Friend WithEvents sprQtyCraftsmanP As NumericUpDown
    Friend WithEvents sprBWCraftsmanP As NumericUpDown
    Friend WithEvents sprQtyJourneymanP As NumericUpDown
    Friend WithEvents sprBWJourneymanP As NumericUpDown
    Friend WithEvents sprQtyForemanP As NumericUpDown
    Friend WithEvents sprBWForemanP As NumericUpDown
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents tblTaxesPT As DataGridView
    Friend WithEvents Panel9 As Panel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label32 As Label
    Friend WithEvents sprFicaP As NumericUpDown
    Friend WithEvents sprFUIP As NumericUpDown
    Friend WithEvents sprSUIP As NumericUpDown
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents clmEmployeeP As DataGridViewTextBoxColumn
    Friend WithEvents FICAP As DataGridViewTextBoxColumn
    Friend WithEvents FUIP As DataGridViewTextBoxColumn
    Friend WithEvents SUIP As DataGridViewTextBoxColumn
    Friend WithEvents PTTOTAL As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel11 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel12 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel14 As TableLayoutPanel
    Friend WithEvents tblAverage As DataGridView
    Friend WithEvents EmployeeBW As DataGridViewTextBoxColumn
    Friend WithEvents FICAAV As DataGridViewTextBoxColumn
    Friend WithEvents FUIAV As DataGridViewTextBoxColumn
    Friend WithEvents SUIAV As DataGridViewTextBoxColumn
    Friend WithEvents WCAV As DataGridViewTextBoxColumn
    Friend WithEvents GenLiabAV As DataGridViewTextBoxColumn
    Friend WithEvents UmbrAV As DataGridViewTextBoxColumn
    Friend WithEvents PullutionAV As DataGridViewTextBoxColumn
    Friend WithEvents HealtAV As DataGridViewTextBoxColumn
    Friend WithEvents FringeAV As DataGridViewTextBoxColumn
    Friend WithEvents SmallAV As DataGridViewTextBoxColumn
    Friend WithEvents PPEAV As DataGridViewTextBoxColumn
    Friend WithEvents ConsumableAV As DataGridViewTextBoxColumn
    Friend WithEvents ScaffoldAV As DataGridViewTextBoxColumn
    Friend WithEvents YoyosAV As DataGridViewTextBoxColumn
    Friend WithEvents MeshAV As DataGridViewTextBoxColumn
    Friend WithEvents MiselaneosAV As DataGridViewTextBoxColumn
    Friend WithEvents OverheadAV As DataGridViewTextBoxColumn
    Friend WithEvents ProfitAV As DataGridViewTextBoxColumn
    Friend WithEvents STTOTALAV As DataGridViewTextBoxColumn
    Friend WithEvents Label49 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents clmEmployee As DataGridViewTextBoxColumn
    Friend WithEvents FICA As DataGridViewTextBoxColumn
    Friend WithEvents FUI As DataGridViewTextBoxColumn
    Friend WithEvents SUI As DataGridViewTextBoxColumn
    Friend WithEvents WC As DataGridViewTextBoxColumn
    Friend WithEvents GenLiab As DataGridViewTextBoxColumn
    Friend WithEvents Umbr As DataGridViewTextBoxColumn
    Friend WithEvents Pollution As DataGridViewTextBoxColumn
    Friend WithEvents Healt As DataGridViewTextBoxColumn
    Friend WithEvents Fringe As DataGridViewTextBoxColumn
    Friend WithEvents Small As DataGridViewTextBoxColumn
    Friend WithEvents PPE As DataGridViewTextBoxColumn
    Friend WithEvents Consumable As DataGridViewTextBoxColumn
    Friend WithEvents Scaffold As DataGridViewTextBoxColumn
    Friend WithEvents YoYos As DataGridViewTextBoxColumn
    Friend WithEvents Mesh As DataGridViewTextBoxColumn
    Friend WithEvents Miselaneos As DataGridViewTextBoxColumn
    Friend WithEvents Overhead As DataGridViewTextBoxColumn
    Friend WithEvents Profit As DataGridViewTextBoxColumn
    Friend WithEvents STTOTAL As DataGridViewTextBoxColumn
    Friend WithEvents Panel10 As Panel
    Friend WithEvents tblAverageP As DataGridView
    Friend WithEvents TableLayoutPanel15 As TableLayoutPanel
    Friend WithEvents Label35 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents EmployeeBWP As DataGridViewTextBoxColumn
    Friend WithEvents FICAAVP As DataGridViewTextBoxColumn
    Friend WithEvents FUIAVP As DataGridViewTextBoxColumn
    Friend WithEvents SUIAVP As DataGridViewTextBoxColumn
    Friend WithEvents PTTOTALAV As DataGridViewTextBoxColumn
End Class
