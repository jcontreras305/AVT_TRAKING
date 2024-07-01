<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScaffoldRentalDatails
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDownloadExcel = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.dtpFinalDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.crvReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gruopSubjectEmail = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.btnSubjectEmail = New System.Windows.Forms.Button()
        Me.txtBodyEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDropEmailList = New System.Windows.Forms.Button()
        Me.tbnAddEmailList = New System.Windows.Forms.Button()
        Me.tblEmailsReports = New System.Windows.Forms.DataGridView()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Send = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1221, 700)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnMinimize)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1213, 58)
        Me.Panel1.TabIndex = 0
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
        Me.Label1.Size = New System.Drawing.Size(266, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Scaffold Rental Details"
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimize.Location = New System.Drawing.Point(1123, 4)
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
        Me.btnRestore.Location = New System.Drawing.Point(1167, 4)
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
        Me.btnMaximize.Location = New System.Drawing.Point(1167, 4)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(41, 36)
        Me.btnMaximize.TabIndex = 13
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnDownloadExcel)
        Me.Panel2.Controls.Add(Me.btnSend)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.btnReport)
        Me.Panel2.Controls.Add(Me.cmbClient)
        Me.Panel2.Controls.Add(Me.dtpFinalDate)
        Me.Panel2.Controls.Add(Me.dtpStartDate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 70)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1213, 97)
        Me.Panel2.TabIndex = 1
        '
        'btnDownloadExcel
        '
        Me.btnDownloadExcel.FlatAppearance.BorderSize = 0
        Me.btnDownloadExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnDownloadExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownloadExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownloadExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDownloadExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnDownloadExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDownloadExcel.Location = New System.Drawing.Point(915, 37)
        Me.btnDownloadExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDownloadExcel.Name = "btnDownloadExcel"
        Me.btnDownloadExcel.Size = New System.Drawing.Size(143, 42)
        Me.btnDownloadExcel.TabIndex = 17
        Me.btnDownloadExcel.Text = "Download"
        Me.btnDownloadExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDownloadExcel.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSend.Image = Global.AVT_TRAKING.My.Resources.Resources.Send1
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(783, 38)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(124, 41)
        Me.btnSend.TabIndex = 16
        Me.btnSend.Text = "Send"
        Me.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(369, 22)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Client"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Final Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Start Date"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1159, 4)
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
        Me.btnReport.Location = New System.Drawing.Point(645, 37)
        Me.btnReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(111, 41)
        Me.btnReport.TabIndex = 11
        Me.btnReport.Text = "Report"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(421, 14)
        Me.cmbClient.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(185, 24)
        Me.cmbClient.TabIndex = 2
        '
        'dtpFinalDate
        '
        Me.dtpFinalDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpFinalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFinalDate.Location = New System.Drawing.Point(92, 54)
        Me.dtpFinalDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFinalDate.Name = "dtpFinalDate"
        Me.dtpFinalDate.Size = New System.Drawing.Size(265, 22)
        Me.dtpFinalDate.TabIndex = 1
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(92, 15)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(265, 22)
        Me.dtpStartDate.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 175)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1213, 521)
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
        Me.TabControl1.Size = New System.Drawing.Size(1213, 521)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.crvReport)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1205, 492)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report"
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
        Me.crvReport.Size = New System.Drawing.Size(1197, 484)
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
        Me.TabPage2.Size = New System.Drawing.Size(1205, 492)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Email"
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
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1197, 484)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.gruopSubjectEmail)
        Me.Panel4.Controls.Add(Me.btnDropEmailList)
        Me.Panel4.Controls.Add(Me.tbnAddEmailList)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(893, 4)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(300, 476)
        Me.Panel4.TabIndex = 1
        '
        'gruopSubjectEmail
        '
        Me.gruopSubjectEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gruopSubjectEmail.Controls.Add(Me.TableLayoutPanel3)
        Me.gruopSubjectEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gruopSubjectEmail.Location = New System.Drawing.Point(4, 130)
        Me.gruopSubjectEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.gruopSubjectEmail.Name = "gruopSubjectEmail"
        Me.gruopSubjectEmail.Padding = New System.Windows.Forms.Padding(4)
        Me.gruopSubjectEmail.Size = New System.Drawing.Size(292, 342)
        Me.gruopSubjectEmail.TabIndex = 15
        Me.gruopSubjectEmail.TabStop = False
        Me.gruopSubjectEmail.Text = "Email"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtSubject, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSubjectEmail, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.txtBodyEmail, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 0, 0)
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(284, 319)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 91)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Body"
        '
        'txtSubject
        '
        Me.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubject.Location = New System.Drawing.Point(4, 29)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubject.Multiline = True
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(276, 58)
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
        Me.btnSubjectEmail.Size = New System.Drawing.Size(276, 42)
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
        Me.txtBodyEmail.Size = New System.Drawing.Size(276, 147)
        Me.txtBodyEmail.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Subject"
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
        Me.btnDropEmailList.Size = New System.Drawing.Size(300, 41)
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
        Me.tbnAddEmailList.Size = New System.Drawing.Size(300, 41)
        Me.tbnAddEmailList.TabIndex = 12
        Me.tbnAddEmailList.Text = "Add"
        Me.tbnAddEmailList.UseVisualStyleBackColor = True
        '
        'tblEmailsReports
        '
        Me.tblEmailsReports.AllowUserToDeleteRows = False
        Me.tblEmailsReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEmailsReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEmailsReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Email, Me.SendName, Me.Send})
        Me.tblEmailsReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEmailsReports.Location = New System.Drawing.Point(4, 4)
        Me.tblEmailsReports.Margin = New System.Windows.Forms.Padding(4)
        Me.tblEmailsReports.Name = "tblEmailsReports"
        Me.tblEmailsReports.RowHeadersWidth = 51
        Me.tblEmailsReports.Size = New System.Drawing.Size(881, 476)
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
        'ScaffoldRentalDatails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1221, 700)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ScaffoldRentalDatails"
        Me.Text = "ScaffoldRentalDatails"
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnReport As Button
    Friend WithEvents cmbClient As ComboBox
    Friend WithEvents dtpFinalDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents Panel3 As Panel
    Friend WithEvents crvReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents gruopSubjectEmail As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents btnSubjectEmail As Button
    Friend WithEvents txtBodyEmail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnDropEmailList As Button
    Friend WithEvents tbnAddEmailList As Button
    Friend WithEvents tblEmailsReports As DataGridView
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents SendName As DataGridViewTextBoxColumn
    Friend WithEvents Send As DataGridViewCheckBoxColumn
    Friend WithEvents btnSend As Button
    Friend WithEvents btnDownloadExcel As Button
End Class
