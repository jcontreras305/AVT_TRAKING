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
    'No lo modifique con el editor de código.
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
        Me.btnFindExcel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.cmbTypeKPI = New System.Windows.Forms.ComboBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tblDatosKPI = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.pgbProgress = New System.Windows.Forms.ProgressBar()
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
        Me.HOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Install = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbData = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.tblDatosKPI, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 44)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.material
        Me.PictureBox1.Location = New System.Drawing.Point(9, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 27)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(44, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 18)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Report Scaffold Ative"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.PictureBox3.Location = New System.Drawing.Point(727, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 29)
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(760, 5)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(26, 29)
        Me.btnRestore.TabIndex = 11
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(760, 6)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 29)
        Me.btnMaximize.TabIndex = 10
        Me.btnMaximize.TabStop = False
        '
        'Panel2
        '
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
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 46)
        Me.Panel2.TabIndex = 1
        '
        'btnFindExcel
        '
        Me.btnFindExcel.FlatAppearance.BorderSize = 0
        Me.btnFindExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnFindExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFindExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnFindExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindExcel.Location = New System.Drawing.Point(558, 4)
        Me.btnFindExcel.Name = "btnFindExcel"
        Me.btnFindExcel.Size = New System.Drawing.Size(82, 39)
        Me.btnFindExcel.TabIndex = 15
        Me.btnFindExcel.Text = "Find"
        Me.btnFindExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindExcel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(119, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Client"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "KPI"
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(154, 13)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(121, 21)
        Me.cmbClient.TabIndex = 12
        '
        'cmbTypeKPI
        '
        Me.cmbTypeKPI.FormattingEnabled = True
        Me.cmbTypeKPI.Items.AddRange(New Object() {"Instalation", "Paint", "Remove"})
        Me.cmbTypeKPI.Location = New System.Drawing.Point(40, 12)
        Me.cmbTypeKPI.Name = "cmbTypeKPI"
        Me.cmbTypeKPI.Size = New System.Drawing.Size(70, 21)
        Me.cmbTypeKPI.TabIndex = 11
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(754, 3)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox4.TabIndex = 10
        Me.PictureBox4.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.tblDatosKPI)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 105)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(794, 302)
        Me.Panel3.TabIndex = 2
        '
        'tblDatosKPI
        '
        Me.tblDatosKPI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblDatosKPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDatosKPI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.jobNo, Me.wono, Me.idAux, Me.Description, Me.Tinck, Me.Size, Me.DateWorked, Me.LF, Me.SQFT, Me.Qty90, Me.Qty45, Me.TEE, Me.Valves, Me.RED, Me.CAP, Me.FLG, Me.FIT, Me.HOT, Me.ST, Me.OT, Me.Install})
        Me.tblDatosKPI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDatosKPI.Location = New System.Drawing.Point(0, 0)
        Me.tblDatosKPI.Name = "tblDatosKPI"
        Me.tblDatosKPI.Size = New System.Drawing.Size(794, 302)
        Me.tblDatosKPI.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblMessage)
        Me.Panel4.Controls.Add(Me.pgbProgress)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 413)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(794, 34)
        Me.Panel4.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(11, 12)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(53, 13)
        Me.lblMessage.TabIndex = 15
        Me.lblMessage.Text = "Message:"
        '
        'pgbProgress
        '
        Me.pgbProgress.Location = New System.Drawing.Point(618, 5)
        Me.pgbProgress.Name = "pgbProgress"
        Me.pgbProgress.Size = New System.Drawing.Size(169, 23)
        Me.pgbProgress.TabIndex = 0
        '
        'jobNo
        '
        Me.jobNo.HeaderText = "Job#"
        Me.jobNo.Name = "jobNo"
        '
        'wono
        '
        Me.wono.HeaderText = "W.O.#"
        Me.wono.Name = "wono"
        '
        'idAux
        '
        Me.idAux.HeaderText = "idAux"
        Me.idAux.Name = "idAux"
        Me.idAux.ReadOnly = True
        Me.idAux.Visible = False
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        '
        'Tinck
        '
        Me.Tinck.HeaderText = "Tinck"
        Me.Tinck.Name = "Tinck"
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'DateWorked
        '
        Me.DateWorked.HeaderText = "DateWorked"
        Me.DateWorked.Name = "DateWorked"
        '
        'LF
        '
        Me.LF.HeaderText = "LF"
        Me.LF.Name = "LF"
        '
        'SQFT
        '
        Me.SQFT.HeaderText = "SQFT"
        Me.SQFT.Name = "SQFT"
        '
        'Qty90
        '
        Me.Qty90.HeaderText = "Qty: 90"
        Me.Qty90.Name = "Qty90"
        '
        'Qty45
        '
        Me.Qty45.HeaderText = "Qty: 45"
        Me.Qty45.Name = "Qty45"
        '
        'TEE
        '
        Me.TEE.HeaderText = "TEE"
        Me.TEE.Name = "TEE"
        '
        'Valves
        '
        Me.Valves.HeaderText = "Valves"
        Me.Valves.Name = "Valves"
        '
        'RED
        '
        Me.RED.HeaderText = "RED"
        Me.RED.Name = "RED"
        '
        'CAP
        '
        Me.CAP.HeaderText = "CAP"
        Me.CAP.Name = "CAP"
        '
        'FLG
        '
        Me.FLG.HeaderText = "FLG"
        Me.FLG.Name = "FLG"
        '
        'FIT
        '
        Me.FIT.HeaderText = "FIT"
        Me.FIT.Name = "FIT"
        '
        'HOT
        '
        Me.HOT.HeaderText = "HOT"
        Me.HOT.Name = "HOT"
        '
        'ST
        '
        Me.ST.HeaderText = "ST"
        Me.ST.Name = "ST"
        '
        'OT
        '
        Me.OT.HeaderText = "OT"
        Me.OT.Name = "OT"
        '
        'Install
        '
        Me.Install.HeaderText = "Install"
        Me.Install.Name = "Install"
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(646, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 39)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbData
        '
        Me.cmbData.FormattingEnabled = True
        Me.cmbData.Location = New System.Drawing.Point(335, 12)
        Me.cmbData.Name = "cmbData"
        Me.cmbData.Size = New System.Drawing.Size(121, 21)
        Me.cmbData.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(281, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Data"
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(317, 13)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(121, 20)
        Me.txtData.TabIndex = 19
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(361, 12)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpDate.TabIndex = 20
        '
        'KPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
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
        Me.Panel3.ResumeLayout(False)
        CType(Me.tblDatosKPI, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents HOT As DataGridViewTextBoxColumn
    Friend WithEvents ST As DataGridViewTextBoxColumn
    Friend WithEvents OT As DataGridViewTextBoxColumn
    Friend WithEvents Install As DataGridViewTextBoxColumn
    Friend WithEvents txtData As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbData As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents dtpDate As DateTimePicker
End Class
