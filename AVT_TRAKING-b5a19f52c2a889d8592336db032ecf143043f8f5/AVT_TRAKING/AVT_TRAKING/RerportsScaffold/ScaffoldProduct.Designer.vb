﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScaffoldProductReport
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.lblMod = New System.Windows.Forms.Label()
        Me.lblTag = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.crvReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gruopSubjectEmail = New System.Windows.Forms.GroupBox()
        Me.btnSubjectEmail = New System.Windows.Forms.Button()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.btnDropEmailList = New System.Windows.Forms.Button()
        Me.tbnAddEmailList = New System.Windows.Forms.Button()
        Me.tblEmailsReports = New System.Windows.Forms.DataGridView()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Send = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtBodyEmail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
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
        CType(Me.tblEmailsReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
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
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(924, 501)
        Me.TableLayoutPanel1.TabIndex = 1
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(918, 48)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.project
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 42)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(56, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 18)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Scaffold Products"
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimize.Location = New System.Drawing.Point(850, 3)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(27, 29)
        Me.btnMinimize.TabIndex = 15
        Me.btnMinimize.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(883, 3)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(26, 29)
        Me.btnRestore.TabIndex = 14
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(883, 3)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 29)
        Me.btnMaximize.TabIndex = 13
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnSend)
        Me.Panel2.Controls.Add(Me.lblMod)
        Me.Panel2.Controls.Add(Me.lblTag)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.btnReport)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 57)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(918, 44)
        Me.Panel2.TabIndex = 1
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
        Me.btnSend.Location = New System.Drawing.Point(588, 3)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(93, 33)
        Me.btnSend.TabIndex = 15
        Me.btnSend.Text = "Send"
        Me.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'lblMod
        '
        Me.lblMod.AutoSize = True
        Me.lblMod.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMod.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMod.Location = New System.Drawing.Point(187, 14)
        Me.lblMod.Name = "lblMod"
        Me.lblMod.Size = New System.Drawing.Size(73, 18)
        Me.lblMod.TabIndex = 14
        Me.lblMod.Text = "Mod No:"
        '
        'lblTag
        '
        Me.lblTag.AutoSize = True
        Me.lblTag.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTag.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTag.Location = New System.Drawing.Point(9, 14)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(66, 18)
        Me.lblTag.TabIndex = 13
        Me.lblTag.Text = "Tag No:"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(877, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 29)
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
        Me.btnReport.Location = New System.Drawing.Point(463, 3)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(83, 33)
        Me.btnReport.TabIndex = 11
        Me.btnReport.Text = "Report"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 107)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(918, 391)
        Me.Panel3.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(918, 391)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.crvReport)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(910, 365)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report View"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'crvReport
        '
        Me.crvReport.ActiveViewIndex = -1
        Me.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReport.Location = New System.Drawing.Point(3, 3)
        Me.crvReport.Name = "crvReport"
        Me.crvReport.Size = New System.Drawing.Size(904, 359)
        Me.crvReport.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(910, 365)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "List Emails"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(904, 359)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.gruopSubjectEmail)
        Me.Panel4.Controls.Add(Me.btnDropEmailList)
        Me.Panel4.Controls.Add(Me.tbnAddEmailList)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(674, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(227, 353)
        Me.Panel4.TabIndex = 1
        '
        'gruopSubjectEmail
        '
        Me.gruopSubjectEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gruopSubjectEmail.Controls.Add(Me.TableLayoutPanel3)
        Me.gruopSubjectEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gruopSubjectEmail.Location = New System.Drawing.Point(3, 72)
        Me.gruopSubjectEmail.Name = "gruopSubjectEmail"
        Me.gruopSubjectEmail.Size = New System.Drawing.Size(221, 278)
        Me.gruopSubjectEmail.TabIndex = 15
        Me.gruopSubjectEmail.TabStop = False
        Me.gruopSubjectEmail.Text = "Email"
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
        Me.btnSubjectEmail.Location = New System.Drawing.Point(3, 222)
        Me.btnSubjectEmail.Name = "btnSubjectEmail"
        Me.btnSubjectEmail.Size = New System.Drawing.Size(209, 34)
        Me.btnSubjectEmail.TabIndex = 15
        Me.btnSubjectEmail.Text = "Save"
        Me.btnSubjectEmail.UseVisualStyleBackColor = True
        '
        'txtSubject
        '
        Me.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubject.Location = New System.Drawing.Point(3, 23)
        Me.txtSubject.Multiline = True
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(209, 48)
        Me.txtSubject.TabIndex = 14
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
        Me.btnDropEmailList.Location = New System.Drawing.Point(0, 33)
        Me.btnDropEmailList.Name = "btnDropEmailList"
        Me.btnDropEmailList.Size = New System.Drawing.Size(227, 33)
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
        Me.tbnAddEmailList.Name = "tbnAddEmailList"
        Me.tbnAddEmailList.Size = New System.Drawing.Size(227, 33)
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
        Me.tblEmailsReports.Location = New System.Drawing.Point(3, 3)
        Me.tblEmailsReports.Name = "tblEmailsReports"
        Me.tblEmailsReports.Size = New System.Drawing.Size(665, 353)
        Me.tblEmailsReports.TabIndex = 2
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'SendName
        '
        Me.SendName.HeaderText = "SendName"
        Me.SendName.Name = "SendName"
        Me.SendName.ReadOnly = True
        '
        'Send
        '
        Me.Send.HeaderText = "Send"
        Me.Send.Name = "Send"
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
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(215, 259)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'txtBodyEmail
        '
        Me.txtBodyEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBodyEmail.Location = New System.Drawing.Point(3, 96)
        Me.txtBodyEmail.Multiline = True
        Me.txtBodyEmail.Name = "txtBodyEmail"
        Me.txtBodyEmail.Size = New System.Drawing.Size(209, 120)
        Me.txtBodyEmail.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Subject"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Body"
        '
        'ScaffoldProductReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 501)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ScaffoldProductReport"
        Me.Text = "ScaffoldProductReport"
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
        CType(Me.tblEmailsReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
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
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnReport As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents crvReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblMod As Label
    Friend WithEvents lblTag As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnDropEmailList As Button
    Friend WithEvents tbnAddEmailList As Button
    Friend WithEvents tblEmailsReports As DataGridView
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents SendName As DataGridViewTextBoxColumn
    Friend WithEvents Send As DataGridViewCheckBoxColumn
    Friend WithEvents btnSend As Button
    Friend WithEvents gruopSubjectEmail As GroupBox
    Friend WithEvents btnSubjectEmail As Button
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBodyEmail As TextBox
    Friend WithEvents Label2 As Label
End Class
