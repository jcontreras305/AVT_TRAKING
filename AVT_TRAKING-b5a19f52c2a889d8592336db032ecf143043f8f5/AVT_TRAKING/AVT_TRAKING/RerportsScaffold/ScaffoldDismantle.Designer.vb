<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScaffoldDismantle
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblClient = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chbAllJobs = New System.Windows.Forms.CheckBox()
        Me.chbAllTag = New System.Windows.Forms.CheckBox()
        Me.cmbTag = New System.Windows.Forms.ComboBox()
        Me.cmbJobNo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.lblTag = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblDismantles = New System.Windows.Forms.DataGridView()
        Me.clmSend = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmTag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDismantleDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmBuildDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmJobNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWorkOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmClient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.SelectAll = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.crvReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gruopSubjectEmail = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.btnSubjectEmail = New System.Windows.Forms.Button()
        Me.txtBodyEmail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDropEmailList = New System.Windows.Forms.Button()
        Me.tbnAddEmailList = New System.Windows.Forms.Button()
        Me.tblEmailsReports = New System.Windows.Forms.DataGridView()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Send = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.scfProduct1 = New AVT_TRAKING.SCFProduct()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.tblDismantles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.gruopSubjectEmail.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.tblEmailsReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1090, 703)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblClient)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnMinimize)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1082, 58)
        Me.Panel1.TabIndex = 0
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblClient.Location = New System.Drawing.Point(529, 19)
        Me.lblClient.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(0, 23)
        Me.lblClient.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(461, 19)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 23)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Client:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.project
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 52)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(75, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Scaffold Products Dismantle"
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimize.Location = New System.Drawing.Point(991, 4)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(36, 36)
        Me.btnMinimize.TabIndex = 15
        Me.btnMinimize.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1035, 4)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(35, 36)
        Me.btnRestore.TabIndex = 14
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1035, 4)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(41, 36)
        Me.btnMaximize.TabIndex = 13
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.chbAllJobs)
        Me.Panel2.Controls.Add(Me.chbAllTag)
        Me.Panel2.Controls.Add(Me.cmbTag)
        Me.Panel2.Controls.Add(Me.cmbJobNo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.btnSend)
        Me.Panel2.Controls.Add(Me.lblTag)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.btnReport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 70)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1082, 84)
        Me.Panel2.TabIndex = 1
        '
        'chbAllJobs
        '
        Me.chbAllJobs.AutoSize = True
        Me.chbAllJobs.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllJobs.Location = New System.Drawing.Point(245, 18)
        Me.chbAllJobs.Name = "chbAllJobs"
        Me.chbAllJobs.Size = New System.Drawing.Size(77, 20)
        Me.chbAllJobs.TabIndex = 20
        Me.chbAllJobs.Text = "All Jobs"
        Me.chbAllJobs.UseVisualStyleBackColor = True
        '
        'chbAllTag
        '
        Me.chbAllTag.AutoSize = True
        Me.chbAllTag.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chbAllTag.Location = New System.Drawing.Point(245, 46)
        Me.chbAllTag.Name = "chbAllTag"
        Me.chbAllTag.Size = New System.Drawing.Size(72, 20)
        Me.chbAllTag.TabIndex = 19
        Me.chbAllTag.Text = "All Tag"
        Me.chbAllTag.UseVisualStyleBackColor = True
        '
        'cmbTag
        '
        Me.cmbTag.FormattingEnabled = True
        Me.cmbTag.Location = New System.Drawing.Point(92, 44)
        Me.cmbTag.Name = "cmbTag"
        Me.cmbTag.Size = New System.Drawing.Size(147, 24)
        Me.cmbTag.TabIndex = 18
        '
        'cmbJobNo
        '
        Me.cmbJobNo.FormattingEnabled = True
        Me.cmbJobNo.Location = New System.Drawing.Point(92, 16)
        Me.cmbJobNo.Name = "cmbJobNo"
        Me.cmbJobNo.Size = New System.Drawing.Size(147, 24)
        Me.cmbJobNo.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(16, 17)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 23)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "JobNo:"
        '
        'btnSend
        '
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSend.Image = Global.AVT_TRAKING.My.Resources.Resources.download
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(784, 4)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(124, 41)
        Me.btnSend.TabIndex = 15
        Me.btnSend.Text = "Download"
        Me.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTag.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTag.Location = New System.Drawing.Point(9, 44)
        Me.lblTag.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(85, 23)
        Me.lblTag.TabIndex = 13
        Me.lblTag.Text = "Tag No:"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1027, 4)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 36)
        Me.PictureBox4.TabIndex = 12
        Me.PictureBox4.TabStop = False
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
        Me.btnReport.Location = New System.Drawing.Point(617, 4)
        Me.btnReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(111, 41)
        Me.btnReport.TabIndex = 11
        Me.btnReport.Text = "Report"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 162)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1082, 537)
        Me.Panel3.TabIndex = 2
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1082, 537)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TabControl1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1076, 531)
        Me.Panel5.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1076, 531)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1068, 502)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "List Tags"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.tblDismantles, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel7, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1068, 502)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'tblDismantles
        '
        Me.tblDismantles.AllowUserToAddRows = False
        Me.tblDismantles.AllowUserToDeleteRows = False
        Me.tblDismantles.AllowUserToOrderColumns = True
        Me.tblDismantles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblDismantles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDismantles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmSend, Me.clmTag, Me.clmDismantleDate, Me.clmBuildDate, Me.clmJobNo, Me.clmWorkOrder, Me.clmClient, Me.clmContact})
        Me.tblDismantles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDismantles.Location = New System.Drawing.Point(3, 3)
        Me.tblDismantles.MultiSelect = False
        Me.tblDismantles.Name = "tblDismantles"
        Me.tblDismantles.RowHeadersWidth = 51
        Me.tblDismantles.RowTemplate.Height = 24
        Me.tblDismantles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblDismantles.Size = New System.Drawing.Size(1062, 446)
        Me.tblDismantles.TabIndex = 0
        '
        'clmSend
        '
        Me.clmSend.HeaderText = "Send"
        Me.clmSend.MinimumWidth = 6
        Me.clmSend.Name = "clmSend"
        Me.clmSend.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmSend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'clmTag
        '
        Me.clmTag.HeaderText = "Tag"
        Me.clmTag.MinimumWidth = 6
        Me.clmTag.Name = "clmTag"
        Me.clmTag.ReadOnly = True
        '
        'clmDismantleDate
        '
        Me.clmDismantleDate.HeaderText = "Dismantle Date"
        Me.clmDismantleDate.MinimumWidth = 6
        Me.clmDismantleDate.Name = "clmDismantleDate"
        Me.clmDismantleDate.ReadOnly = True
        '
        'clmBuildDate
        '
        Me.clmBuildDate.HeaderText = "Build Date"
        Me.clmBuildDate.MinimumWidth = 6
        Me.clmBuildDate.Name = "clmBuildDate"
        Me.clmBuildDate.ReadOnly = True
        '
        'clmJobNo
        '
        Me.clmJobNo.HeaderText = "JobNo"
        Me.clmJobNo.MinimumWidth = 6
        Me.clmJobNo.Name = "clmJobNo"
        Me.clmJobNo.ReadOnly = True
        '
        'clmWorkOrder
        '
        Me.clmWorkOrder.HeaderText = "WorkOrder"
        Me.clmWorkOrder.MinimumWidth = 6
        Me.clmWorkOrder.Name = "clmWorkOrder"
        Me.clmWorkOrder.ReadOnly = True
        '
        'clmClient
        '
        Me.clmClient.HeaderText = "Client"
        Me.clmClient.MinimumWidth = 6
        Me.clmClient.Name = "clmClient"
        Me.clmClient.ReadOnly = True
        '
        'clmContact
        '
        Me.clmContact.HeaderText = "Contact"
        Me.clmContact.MinimumWidth = 6
        Me.clmContact.Name = "clmContact"
        Me.clmContact.ReadOnly = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.SelectAll)
        Me.Panel7.Controls.Add(Me.lblMessage)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 455)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1062, 44)
        Me.Panel7.TabIndex = 13
        '
        'SelectAll
        '
        Me.SelectAll.FlatAppearance.BorderSize = 0
        Me.SelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SelectAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectAll.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.SelectAll.Image = Global.AVT_TRAKING.My.Resources.Resources.ok
        Me.SelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SelectAll.Location = New System.Drawing.Point(10, 2)
        Me.SelectAll.Margin = New System.Windows.Forms.Padding(4)
        Me.SelectAll.Name = "SelectAll"
        Me.SelectAll.Size = New System.Drawing.Size(104, 41)
        Me.SelectAll.TabIndex = 12
        Me.SelectAll.Text = "Select All"
        Me.SelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.SelectAll.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(995, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(67, 16)
        Me.lblMessage.TabIndex = 13
        Me.lblMessage.Text = "Message:"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.crvReport)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1068, 502)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report View"
        '
        'crvReport
        '
        Me.crvReport.ActiveViewIndex = -1
        Me.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReport.Location = New System.Drawing.Point(4, 4)
        Me.crvReport.Margin = New System.Windows.Forms.Padding(4)
        Me.crvReport.Name = "crvReport"
        Me.crvReport.Size = New System.Drawing.Size(1060, 494)
        Me.crvReport.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(1068, 502)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "List Emails"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.33628!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.66372!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.tblEmailsReports, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1060, 494)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.gruopSubjectEmail)
        Me.Panel4.Controls.Add(Me.btnDropEmailList)
        Me.Panel4.Controls.Add(Me.tbnAddEmailList)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(791, 4)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(265, 486)
        Me.Panel4.TabIndex = 1
        '
        'gruopSubjectEmail
        '
        Me.gruopSubjectEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gruopSubjectEmail.Controls.Add(Me.TableLayoutPanel3)
        Me.gruopSubjectEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gruopSubjectEmail.Location = New System.Drawing.Point(4, 141)
        Me.gruopSubjectEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.gruopSubjectEmail.Name = "gruopSubjectEmail"
        Me.gruopSubjectEmail.Padding = New System.Windows.Forms.Padding(4)
        Me.gruopSubjectEmail.Size = New System.Drawing.Size(257, 342)
        Me.gruopSubjectEmail.TabIndex = 15
        Me.gruopSubjectEmail.TabStop = False
        Me.gruopSubjectEmail.Text = "Email"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtSubject, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSubjectEmail, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBodyEmail, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(249, 319)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 91)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Body"
        '
        'txtSubject
        '
        Me.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubject.Location = New System.Drawing.Point(4, 29)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubject.Multiline = True
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(241, 58)
        Me.txtSubject.TabIndex = 14
        '
        'btnSubjectEmail
        '
        Me.btnSubjectEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSubjectEmail.FlatAppearance.BorderSize = 0
        Me.btnSubjectEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSubjectEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubjectEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubjectEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSubjectEmail.Image = Global.AVT_TRAKING.My.Resources.Resources.save1
        Me.btnSubjectEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubjectEmail.Location = New System.Drawing.Point(4, 273)
        Me.btnSubjectEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubjectEmail.Name = "btnSubjectEmail"
        Me.btnSubjectEmail.Size = New System.Drawing.Size(241, 42)
        Me.btnSubjectEmail.TabIndex = 15
        Me.btnSubjectEmail.Text = "Save"
        Me.btnSubjectEmail.UseVisualStyleBackColor = True
        '
        'txtBodyEmail
        '
        Me.txtBodyEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBodyEmail.Location = New System.Drawing.Point(4, 118)
        Me.txtBodyEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBodyEmail.Multiline = True
        Me.txtBodyEmail.Name = "txtBodyEmail"
        Me.txtBodyEmail.Size = New System.Drawing.Size(241, 147)
        Me.txtBodyEmail.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Subject"
        '
        'btnDropEmailList
        '
        Me.btnDropEmailList.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDropEmailList.FlatAppearance.BorderSize = 0
        Me.btnDropEmailList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnDropEmailList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDropEmailList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDropEmailList.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDropEmailList.Image = Global.AVT_TRAKING.My.Resources.Resources.close2
        Me.btnDropEmailList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDropEmailList.Location = New System.Drawing.Point(0, 41)
        Me.btnDropEmailList.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDropEmailList.Name = "btnDropEmailList"
        Me.btnDropEmailList.Size = New System.Drawing.Size(265, 41)
        Me.btnDropEmailList.TabIndex = 13
        Me.btnDropEmailList.Text = "Drop"
        Me.btnDropEmailList.UseVisualStyleBackColor = True
        '
        'tbnAddEmailList
        '
        Me.tbnAddEmailList.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbnAddEmailList.FlatAppearance.BorderSize = 0
        Me.tbnAddEmailList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.tbnAddEmailList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbnAddEmailList.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnAddEmailList.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbnAddEmailList.Image = Global.AVT_TRAKING.My.Resources.Resources.add
        Me.tbnAddEmailList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tbnAddEmailList.Location = New System.Drawing.Point(0, 0)
        Me.tbnAddEmailList.Margin = New System.Windows.Forms.Padding(4)
        Me.tbnAddEmailList.Name = "tbnAddEmailList"
        Me.tbnAddEmailList.Size = New System.Drawing.Size(265, 41)
        Me.tbnAddEmailList.TabIndex = 12
        Me.tbnAddEmailList.Text = "Add"
        Me.tbnAddEmailList.UseVisualStyleBackColor = True
        '
        'tblEmailsReports
        '
        Me.tblEmailsReports.AllowUserToAddRows = False
        Me.tblEmailsReports.AllowUserToDeleteRows = False
        Me.tblEmailsReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEmailsReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEmailsReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Email, Me.SendName, Me.Send})
        Me.tblEmailsReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEmailsReports.Location = New System.Drawing.Point(4, 4)
        Me.tblEmailsReports.Margin = New System.Windows.Forms.Padding(4)
        Me.tblEmailsReports.Name = "tblEmailsReports"
        Me.tblEmailsReports.RowHeadersWidth = 51
        Me.tblEmailsReports.Size = New System.Drawing.Size(779, 486)
        Me.tblEmailsReports.TabIndex = 2
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.MinimumWidth = 6
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'SendName
        '
        Me.SendName.HeaderText = "SendName"
        Me.SendName.MinimumWidth = 6
        Me.SendName.Name = "SendName"
        Me.SendName.ReadOnly = True
        '
        'Send
        '
        Me.Send.HeaderText = "Send"
        Me.Send.MinimumWidth = 6
        Me.Send.Name = "Send"
        '
        'ScaffoldDismantle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1090, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ScaffoldDismantle"
        Me.Text = "ScaffoldDismantle"
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
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.tblDismantles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.gruopSubjectEmail.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.tblEmailsReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMinimize As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSend As Button
    Friend WithEvents lblTag As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnReport As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents crvReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents gruopSubjectEmail As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents btnSubjectEmail As Button
    Friend WithEvents txtBodyEmail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnDropEmailList As Button
    Friend WithEvents tbnAddEmailList As Button
    Friend WithEvents tblEmailsReports As DataGridView
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents SendName As DataGridViewTextBoxColumn
    Friend WithEvents Send As DataGridViewCheckBoxColumn
    Friend WithEvents tblDismantles As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents lblClient As Label
    Friend WithEvents cmbTag As ComboBox
    Friend WithEvents cmbJobNo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chbAllJobs As CheckBox
    Friend WithEvents chbAllTag As CheckBox
    Friend WithEvents clmSend As DataGridViewCheckBoxColumn
    Friend WithEvents clmTag As DataGridViewTextBoxColumn
    Friend WithEvents clmDismantleDate As DataGridViewTextBoxColumn
    Friend WithEvents clmBuildDate As DataGridViewTextBoxColumn
    Friend WithEvents clmJobNo As DataGridViewTextBoxColumn
    Friend WithEvents clmWorkOrder As DataGridViewTextBoxColumn
    Friend WithEvents clmClient As DataGridViewTextBoxColumn
    Friend WithEvents clmContact As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents SelectAll As Button
    Friend WithEvents scfProduct1 As SCFProduct
    Friend WithEvents lblMessage As Label
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Panel7 As Panel
End Class
