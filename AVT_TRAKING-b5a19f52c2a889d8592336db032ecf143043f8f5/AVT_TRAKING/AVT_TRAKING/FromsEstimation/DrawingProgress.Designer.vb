<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrawingProgress
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAddRowEquipment = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmbDrawing = New System.Windows.Forms.ComboBox()
        Me.cmbJobNo = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblScaffold = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tblEquipment = New System.Windows.Forms.DataGridView()
        Me.EquipmentIdAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekendEqAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekendEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsRemovalEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsInstallEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaintEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tblPiping = New System.Windows.Forms.DataGridView()
        Me.PipingIdAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekendPpAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PipingId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekendPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsRemovalPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsInstallPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaintPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Demo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Build = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weekend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekendAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblScaffold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.tblPiping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(938, 442)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnAddRowEquipment)
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 389)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(932, 50)
        Me.Panel4.TabIndex = 36
        '
        'btnAddRowEquipment
        '
        Me.btnAddRowEquipment.FlatAppearance.BorderSize = 0
        Me.btnAddRowEquipment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnAddRowEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRowEquipment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRowEquipment.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAddRowEquipment.Image = Global.AVT_TRAKING.My.Resources.Resources.add
        Me.btnAddRowEquipment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddRowEquipment.Location = New System.Drawing.Point(7, 6)
        Me.btnAddRowEquipment.Name = "btnAddRowEquipment"
        Me.btnAddRowEquipment.Size = New System.Drawing.Size(77, 35)
        Me.btnAddRowEquipment.TabIndex = 34
        Me.btnAddRowEquipment.Text = "Add"
        Me.btnAddRowEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddRowEquipment.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(838, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 35)
        Me.btnDelete.TabIndex = 32
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(742, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 35)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(932, 62)
        Me.Panel1.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.btnSalir.Location = New System.Drawing.Point(885, 5)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(43, 55)
        Me.btnSalir.TabIndex = 35
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 18)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Progress by Weekending Date Per Drawing"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TextBox4)
        Me.Panel2.Controls.Add(Me.TextBox3)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.cmbDrawing)
        Me.Panel2.Controls.Add(Me.cmbJobNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(932, 94)
        Me.Panel2.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(451, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Client Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(220, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Description Dr."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(220, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Drawing"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(9, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(9, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(9, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Job No."
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(530, 4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(134, 20)
        Me.TextBox4.TabIndex = 5
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(302, 30)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(134, 20)
        Me.TextBox3.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(80, 56)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(134, 20)
        Me.TextBox2.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(80, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(134, 20)
        Me.TextBox1.TabIndex = 2
        '
        'cmbDrawing
        '
        Me.cmbDrawing.FormattingEnabled = True
        Me.cmbDrawing.Location = New System.Drawing.Point(302, 3)
        Me.cmbDrawing.Name = "cmbDrawing"
        Me.cmbDrawing.Size = New System.Drawing.Size(134, 21)
        Me.cmbDrawing.TabIndex = 1
        '
        'cmbJobNo
        '
        Me.cmbJobNo.FormattingEnabled = True
        Me.cmbJobNo.Location = New System.Drawing.Point(80, 3)
        Me.cmbJobNo.Name = "cmbJobNo"
        Me.cmbJobNo.Size = New System.Drawing.Size(134, 21)
        Me.cmbJobNo.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 171)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(932, 212)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tblScaffold)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(924, 186)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tblScaffold
        '
        Me.tblScaffold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblScaffold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblScaffold.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TagAux, Me.WeekendAux, Me.Tag, Me.Weekend, Me.Build, Me.Demo})
        Me.tblScaffold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScaffold.Location = New System.Drawing.Point(3, 3)
        Me.tblScaffold.Name = "tblScaffold"
        Me.tblScaffold.Size = New System.Drawing.Size(918, 180)
        Me.tblScaffold.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tblEquipment)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(924, 186)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tblEquipment
        '
        Me.tblEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EquipmentIdAux, Me.WeekendEqAux, Me.EquipmentId, Me.WeekendEq, Me.InsRemovalEq, Me.InsInstallEq, Me.PaintEq})
        Me.tblEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEquipment.Location = New System.Drawing.Point(3, 3)
        Me.tblEquipment.Name = "tblEquipment"
        Me.tblEquipment.Size = New System.Drawing.Size(918, 180)
        Me.tblEquipment.TabIndex = 0
        '
        'EquipmentIdAux
        '
        Me.EquipmentIdAux.HeaderText = "EquipmentIdAux"
        Me.EquipmentIdAux.Name = "EquipmentIdAux"
        Me.EquipmentIdAux.Visible = False
        '
        'WeekendEqAux
        '
        Me.WeekendEqAux.HeaderText = "WeekendEqAux"
        Me.WeekendEqAux.Name = "WeekendEqAux"
        Me.WeekendEqAux.Visible = False
        '
        'EquipmentId
        '
        Me.EquipmentId.HeaderText = "Equipment ID"
        Me.EquipmentId.Name = "EquipmentId"
        '
        'WeekendEq
        '
        Me.WeekendEq.HeaderText = "Weekend"
        Me.WeekendEq.Name = "WeekendEq"
        '
        'InsRemovalEq
        '
        Me.InsRemovalEq.HeaderText = "Ins Removal %"
        Me.InsRemovalEq.Name = "InsRemovalEq"
        '
        'InsInstallEq
        '
        Me.InsInstallEq.HeaderText = "Ins. Install %"
        Me.InsInstallEq.Name = "InsInstallEq"
        '
        'PaintEq
        '
        Me.PaintEq.HeaderText = "Paint %"
        Me.PaintEq.Name = "PaintEq"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tblPiping)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(924, 186)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tblPiping
        '
        Me.tblPiping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPiping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPiping.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PipingIdAux, Me.WeekendPpAux, Me.PipingId, Me.WeekendPp, Me.InsRemovalPP, Me.InsInstallPp, Me.PaintPp})
        Me.tblPiping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPiping.Location = New System.Drawing.Point(3, 3)
        Me.tblPiping.Name = "tblPiping"
        Me.tblPiping.Size = New System.Drawing.Size(918, 180)
        Me.tblPiping.TabIndex = 0
        '
        'PipingIdAux
        '
        Me.PipingIdAux.HeaderText = "PipingIdAux"
        Me.PipingIdAux.Name = "PipingIdAux"
        Me.PipingIdAux.Visible = False
        '
        'WeekendPpAux
        '
        Me.WeekendPpAux.HeaderText = "WeekendPpAux"
        Me.WeekendPpAux.Name = "WeekendPpAux"
        Me.WeekendPpAux.Visible = False
        '
        'PipingId
        '
        Me.PipingId.HeaderText = "Piping ID"
        Me.PipingId.Name = "PipingId"
        '
        'WeekendPp
        '
        Me.WeekendPp.HeaderText = "Weekend"
        Me.WeekendPp.Name = "WeekendPp"
        '
        'InsRemovalPP
        '
        Me.InsRemovalPP.HeaderText = "Ins. Removal %"
        Me.InsRemovalPP.Name = "InsRemovalPP"
        '
        'InsInstallPp
        '
        Me.InsInstallPp.HeaderText = "Ins. Install %"
        Me.InsInstallPp.Name = "InsInstallPp"
        '
        'PaintPp
        '
        Me.PaintPp.HeaderText = "Paint %"
        Me.PaintPp.Name = "PaintPp"
        '
        'Demo
        '
        Me.Demo.HeaderText = "Demo%"
        Me.Demo.Name = "Demo"
        '
        'Build
        '
        Me.Build.HeaderText = "Build %"
        Me.Build.Name = "Build"
        '
        'Weekend
        '
        Me.Weekend.HeaderText = "Weekend"
        Me.Weekend.Name = "Weekend"
        '
        'Tag
        '
        Me.Tag.HeaderText = "Tag No."
        Me.Tag.Name = "Tag"
        '
        'WeekendAux
        '
        Me.WeekendAux.HeaderText = "WeekendAux"
        Me.WeekendAux.Name = "WeekendAux"
        Me.WeekendAux.Visible = False
        '
        'TagAux
        '
        Me.TagAux.HeaderText = "TagAux"
        Me.TagAux.Name = "TagAux"
        Me.TagAux.Visible = False
        '
        'DrawingProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 442)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DrawingProgress"
        Me.Text = "Drawing Progress"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblScaffold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tblEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.tblPiping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnAddRowEquipment As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmbDrawing As ComboBox
    Friend WithEvents cmbJobNo As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tblScaffold As DataGridView
    Friend WithEvents tblEquipment As DataGridView
    Friend WithEvents EquipmentIdAux As DataGridViewTextBoxColumn
    Friend WithEvents WeekendEqAux As DataGridViewTextBoxColumn
    Friend WithEvents EquipmentId As DataGridViewTextBoxColumn
    Friend WithEvents WeekendEq As DataGridViewTextBoxColumn
    Friend WithEvents InsRemovalEq As DataGridViewTextBoxColumn
    Friend WithEvents InsInstallEq As DataGridViewTextBoxColumn
    Friend WithEvents PaintEq As DataGridViewTextBoxColumn
    Friend WithEvents tblPiping As DataGridView
    Friend WithEvents PipingIdAux As DataGridViewTextBoxColumn
    Friend WithEvents WeekendPpAux As DataGridViewTextBoxColumn
    Friend WithEvents PipingId As DataGridViewTextBoxColumn
    Friend WithEvents WeekendPp As DataGridViewTextBoxColumn
    Friend WithEvents InsRemovalPP As DataGridViewTextBoxColumn
    Friend WithEvents InsInstallPp As DataGridViewTextBoxColumn
    Friend WithEvents PaintPp As DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TagAux As DataGridViewTextBoxColumn
    Friend WithEvents WeekendAux As DataGridViewTextBoxColumn
    Friend WithEvents Tag As DataGridViewTextBoxColumn
    Friend WithEvents Weekend As DataGridViewTextBoxColumn
    Friend WithEvents Build As DataGridViewTextBoxColumn
    Friend WithEvents Demo As DataGridViewTextBoxColumn
End Class
