<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportInvoice
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
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chbAllPO = New System.Windows.Forms.CheckBox()
        Me.cmbPO = New System.Windows.Forms.ComboBox()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.crvIvoice = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.tblInvoiceCodes = New System.Windows.Forms.DataGridView()
        Me.PO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Invoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnSaveInvoiceNumbers = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.tblInvoices = New System.Windows.Forms.DataGridView()
        Me.clmInvoiceAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPOAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmInvoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFinalDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmInvoiceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmStatusAux = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.chbAllPOFilter = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbPOFilter = New System.Windows.Forms.ComboBox()
        Me.cmbClientFilter = New System.Windows.Forms.ComboBox()
        Me.btnDeleteInvoce = New System.Windows.Forms.Button()
        Me.btnRefreshInvoice = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.tblInvoiceCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.tblInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
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
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1248, 666)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnMinimize)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1240, 41)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.report
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimize.Location = New System.Drawing.Point(1151, 0)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(36, 36)
        Me.btnMinimize.TabIndex = 12
        Me.btnMinimize.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1195, 0)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(35, 36)
        Me.btnRestore.TabIndex = 11
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1195, 0)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(41, 36)
        Me.btnMaximize.TabIndex = 10
        Me.btnMaximize.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(61, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(300, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice Per Project Order"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnReport)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.chbAllPO)
        Me.Panel2.Controls.Add(Me.cmbPO)
        Me.Panel2.Controls.Add(Me.cmbClient)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dtpEndDate)
        Me.Panel2.Controls.Add(Me.dtpStartDate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Location = New System.Drawing.Point(4, 53)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1240, 79)
        Me.Panel2.TabIndex = 1
        '
        'btnReport
        '
        Me.btnReport.FlatAppearance.BorderSize = 0
        Me.btnReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReport.Image = Global.AVT_TRAKING.My.Resources.Resources.reportshow
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(639, 37)
        Me.btnReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(111, 41)
        Me.btnReport.TabIndex = 10
        Me.btnReport.Text = "Report"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1187, 6)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 36)
        Me.PictureBox4.TabIndex = 9
        Me.PictureBox4.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(263, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Project Oreder"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(263, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Client"
        '
        'chbAllPO
        '
        Me.chbAllPO.AutoSize = True
        Me.chbAllPO.Location = New System.Drawing.Point(535, 50)
        Me.chbAllPO.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllPO.Name = "chbAllPO"
        Me.chbAllPO.Size = New System.Drawing.Size(66, 20)
        Me.chbAllPO.TabIndex = 6
        Me.chbAllPO.Text = "All PO"
        Me.chbAllPO.UseVisualStyleBackColor = True
        '
        'cmbPO
        '
        Me.cmbPO.FormattingEnabled = True
        Me.cmbPO.Location = New System.Drawing.Point(364, 47)
        Me.cmbPO.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPO.Name = "cmbPO"
        Me.cmbPO.Size = New System.Drawing.Size(160, 24)
        Me.cmbPO.TabIndex = 5
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(364, 16)
        Me.cmbClient.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(160, 24)
        Me.cmbClient.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "End Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Start Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(84, 47)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(168, 22)
        Me.dtpEndDate.TabIndex = 1
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(84, 15)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(168, 22)
        Me.dtpStartDate.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 140)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1240, 522)
        Me.Panel3.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1240, 522)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1232, 493)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.45161!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.54839!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1224, 485)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.crvIvoice)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(4, 4)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(927, 477)
        Me.Panel4.TabIndex = 0
        '
        'crvIvoice
        '
        Me.crvIvoice.ActiveViewIndex = -1
        Me.crvIvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvIvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvIvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvIvoice.Location = New System.Drawing.Point(0, 0)
        Me.crvIvoice.Margin = New System.Windows.Forms.Padding(4)
        Me.crvIvoice.Name = "crvIvoice"
        Me.crvIvoice.Size = New System.Drawing.Size(927, 477)
        Me.crvIvoice.TabIndex = 0
        Me.crvIvoice.ToolPanelWidth = 150
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(939, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(281, 477)
        Me.Panel5.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.69307!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.30693!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(281, 477)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.tblInvoiceCodes)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(4, 4)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(273, 376)
        Me.Panel6.TabIndex = 0
        '
        'tblInvoiceCodes
        '
        Me.tblInvoiceCodes.AllowUserToAddRows = False
        Me.tblInvoiceCodes.AllowUserToDeleteRows = False
        Me.tblInvoiceCodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblInvoiceCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblInvoiceCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PO, Me.Invoice})
        Me.tblInvoiceCodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblInvoiceCodes.Location = New System.Drawing.Point(0, 0)
        Me.tblInvoiceCodes.Margin = New System.Windows.Forms.Padding(4)
        Me.tblInvoiceCodes.Name = "tblInvoiceCodes"
        Me.tblInvoiceCodes.RowHeadersWidth = 51
        Me.tblInvoiceCodes.Size = New System.Drawing.Size(273, 376)
        Me.tblInvoiceCodes.TabIndex = 0
        '
        'PO
        '
        Me.PO.HeaderText = "PO"
        Me.PO.MinimumWidth = 6
        Me.PO.Name = "PO"
        Me.PO.ReadOnly = True
        '
        'Invoice
        '
        Me.Invoice.HeaderText = "Invoice"
        Me.Invoice.MinimumWidth = 6
        Me.Invoice.Name = "Invoice"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnSaveInvoiceNumbers)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(4, 388)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(273, 85)
        Me.Panel7.TabIndex = 1
        '
        'btnSaveInvoiceNumbers
        '
        Me.btnSaveInvoiceNumbers.FlatAppearance.BorderSize = 0
        Me.btnSaveInvoiceNumbers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSaveInvoiceNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveInvoiceNumbers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveInvoiceNumbers.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSaveInvoiceNumbers.Image = Global.AVT_TRAKING.My.Resources.Resources.save1
        Me.btnSaveInvoiceNumbers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveInvoiceNumbers.Location = New System.Drawing.Point(67, 18)
        Me.btnSaveInvoiceNumbers.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveInvoiceNumbers.Name = "btnSaveInvoiceNumbers"
        Me.btnSaveInvoiceNumbers.Size = New System.Drawing.Size(153, 41)
        Me.btnSaveInvoiceNumbers.TabIndex = 11
        Me.btnSaveInvoiceNumbers.Text = "Save Invoice"
        Me.btnSaveInvoiceNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveInvoiceNumbers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveInvoiceNumbers.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1232, 493)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Invoices"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel8, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel9, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1224, 485)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.tblInvoices)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(4, 4)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(949, 477)
        Me.Panel8.TabIndex = 0
        '
        'tblInvoices
        '
        Me.tblInvoices.AllowUserToAddRows = False
        Me.tblInvoices.AllowUserToDeleteRows = False
        Me.tblInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmInvoiceAux, Me.clmPOAux, Me.clmInvoice, Me.clmPO, Me.clmClient, Me.clmStartDate, Me.clmFinalDate, Me.clmInvoiceDate, Me.clmStatus, Me.clmStatusAux})
        Me.tblInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblInvoices.Location = New System.Drawing.Point(0, 0)
        Me.tblInvoices.Margin = New System.Windows.Forms.Padding(4)
        Me.tblInvoices.Name = "tblInvoices"
        Me.tblInvoices.RowHeadersWidth = 51
        Me.tblInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblInvoices.Size = New System.Drawing.Size(949, 477)
        Me.tblInvoices.TabIndex = 0
        '
        'clmInvoiceAux
        '
        Me.clmInvoiceAux.HeaderText = "clmInvoiceAux"
        Me.clmInvoiceAux.MinimumWidth = 6
        Me.clmInvoiceAux.Name = "clmInvoiceAux"
        Me.clmInvoiceAux.ReadOnly = True
        Me.clmInvoiceAux.Visible = False
        '
        'clmPOAux
        '
        Me.clmPOAux.HeaderText = "clmPOAux"
        Me.clmPOAux.MinimumWidth = 6
        Me.clmPOAux.Name = "clmPOAux"
        Me.clmPOAux.ReadOnly = True
        Me.clmPOAux.Visible = False
        '
        'clmInvoice
        '
        Me.clmInvoice.HeaderText = "Invoice"
        Me.clmInvoice.MinimumWidth = 6
        Me.clmInvoice.Name = "clmInvoice"
        Me.clmInvoice.ReadOnly = True
        '
        'clmPO
        '
        Me.clmPO.HeaderText = "PO"
        Me.clmPO.MinimumWidth = 6
        Me.clmPO.Name = "clmPO"
        Me.clmPO.ReadOnly = True
        '
        'clmClient
        '
        Me.clmClient.HeaderText = "Client"
        Me.clmClient.MinimumWidth = 6
        Me.clmClient.Name = "clmClient"
        Me.clmClient.ReadOnly = True
        '
        'clmStartDate
        '
        Me.clmStartDate.HeaderText = "Start Date"
        Me.clmStartDate.MinimumWidth = 6
        Me.clmStartDate.Name = "clmStartDate"
        Me.clmStartDate.ReadOnly = True
        '
        'clmFinalDate
        '
        Me.clmFinalDate.HeaderText = "Final Date"
        Me.clmFinalDate.MinimumWidth = 6
        Me.clmFinalDate.Name = "clmFinalDate"
        Me.clmFinalDate.ReadOnly = True
        '
        'clmInvoiceDate
        '
        Me.clmInvoiceDate.HeaderText = "Invoice Date"
        Me.clmInvoiceDate.MinimumWidth = 6
        Me.clmInvoiceDate.Name = "clmInvoiceDate"
        Me.clmInvoiceDate.ReadOnly = True
        '
        'clmStatus
        '
        Me.clmStatus.HeaderText = "Status"
        Me.clmStatus.MinimumWidth = 6
        Me.clmStatus.Name = "clmStatus"
        Me.clmStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'clmStatusAux
        '
        Me.clmStatusAux.HeaderText = "clmStatusAux"
        Me.clmStatusAux.MinimumWidth = 6
        Me.clmStatusAux.Name = "clmStatusAux"
        Me.clmStatusAux.Visible = False
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Label8)
        Me.Panel9.Controls.Add(Me.dtpInvoiceDate)
        Me.Panel9.Controls.Add(Me.chbAllPOFilter)
        Me.Panel9.Controls.Add(Me.Label6)
        Me.Panel9.Controls.Add(Me.Label7)
        Me.Panel9.Controls.Add(Me.cmbPOFilter)
        Me.Panel9.Controls.Add(Me.cmbClientFilter)
        Me.Panel9.Controls.Add(Me.btnDeleteInvoce)
        Me.Panel9.Controls.Add(Me.btnRefreshInvoice)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(961, 4)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(259, 477)
        Me.Panel9.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(4, 219)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Start Date"
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(101, 219)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(160, 22)
        Me.dtpInvoiceDate.TabIndex = 14
        '
        'chbAllPOFilter
        '
        Me.chbAllPOFilter.AutoSize = True
        Me.chbAllPOFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllPOFilter.Location = New System.Drawing.Point(185, 79)
        Me.chbAllPOFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.chbAllPOFilter.Name = "chbAllPOFilter"
        Me.chbAllPOFilter.Size = New System.Drawing.Size(66, 20)
        Me.chbAllPOFilter.TabIndex = 13
        Me.chbAllPOFilter.Text = "All PO"
        Me.chbAllPOFilter.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(0, 48)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Project Oreder"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(0, 18)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Client"
        '
        'cmbPOFilter
        '
        Me.cmbPOFilter.FormattingEnabled = True
        Me.cmbPOFilter.Location = New System.Drawing.Point(101, 46)
        Me.cmbPOFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPOFilter.Name = "cmbPOFilter"
        Me.cmbPOFilter.Size = New System.Drawing.Size(160, 24)
        Me.cmbPOFilter.TabIndex = 10
        '
        'cmbClientFilter
        '
        Me.cmbClientFilter.FormattingEnabled = True
        Me.cmbClientFilter.Location = New System.Drawing.Point(101, 15)
        Me.cmbClientFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClientFilter.Name = "cmbClientFilter"
        Me.cmbClientFilter.Size = New System.Drawing.Size(160, 24)
        Me.cmbClientFilter.TabIndex = 9
        '
        'btnDeleteInvoce
        '
        Me.btnDeleteInvoce.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteInvoce.FlatAppearance.BorderSize = 0
        Me.btnDeleteInvoce.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteInvoce.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDeleteInvoce.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDeleteInvoce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteInvoce.Location = New System.Drawing.Point(135, 424)
        Me.btnDeleteInvoce.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteInvoce.Name = "btnDeleteInvoce"
        Me.btnDeleteInvoce.Size = New System.Drawing.Size(101, 37)
        Me.btnDeleteInvoce.TabIndex = 1
        Me.btnDeleteInvoce.Text = "Delete"
        Me.btnDeleteInvoce.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDeleteInvoce.UseVisualStyleBackColor = True
        '
        'btnRefreshInvoice
        '
        Me.btnRefreshInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshInvoice.FlatAppearance.BorderSize = 0
        Me.btnRefreshInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshInvoice.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRefreshInvoice.Image = Global.AVT_TRAKING.My.Resources.Resources.refresh
        Me.btnRefreshInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshInvoice.Location = New System.Drawing.Point(25, 424)
        Me.btnRefreshInvoice.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefreshInvoice.Name = "btnRefreshInvoice"
        Me.btnRefreshInvoice.Size = New System.Drawing.Size(101, 37)
        Me.btnRefreshInvoice.TabIndex = 0
        Me.btnRefreshInvoice.Text = "Refresh"
        Me.btnRefreshInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefreshInvoice.UseVisualStyleBackColor = True
        '
        'ReportInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 666)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReportInvoice"
        Me.Text = "ReportInvoice"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.tblInvoiceCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.tblInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnMinimize As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chbAllPO As CheckBox
    Friend WithEvents cmbPO As ComboBox
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnReport As Button
    Friend WithEvents crvIvoice As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents tblInvoiceCodes As DataGridView
    Friend WithEvents PO As DataGridViewTextBoxColumn
    Friend WithEvents Invoice As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnSaveInvoiceNumbers As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents tblInvoices As DataGridView
    Friend WithEvents Panel9 As Panel
    Friend WithEvents btnDeleteInvoce As Button
    Friend WithEvents btnRefreshInvoice As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbPOFilter As ComboBox
    Friend WithEvents cmbClientFilter As ComboBox
    Friend WithEvents chbAllPOFilter As CheckBox
    Friend WithEvents clmInvoiceAux As DataGridViewTextBoxColumn
    Friend WithEvents clmPOAux As DataGridViewTextBoxColumn
    Friend WithEvents clmInvoice As DataGridViewTextBoxColumn
    Friend WithEvents clmPO As DataGridViewTextBoxColumn
    Friend WithEvents clmClient As DataGridViewTextBoxColumn
    Friend WithEvents clmStartDate As DataGridViewTextBoxColumn
    Friend WithEvents clmFinalDate As DataGridViewTextBoxColumn
    Friend WithEvents clmInvoiceDate As DataGridViewTextBoxColumn
    Friend WithEvents clmStatus As DataGridViewCheckBoxColumn
    Friend WithEvents clmStatusAux As DataGridViewCheckBoxColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpInvoiceDate As DateTimePicker
End Class
