<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectsActuals
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClientNumber = New System.Windows.Forms.TextBox()
        Me.txtUnitPO = New System.Windows.Forms.TextBox()
        Me.txtDescriptionPO = New System.Windows.Forms.TextBox()
        Me.cmbJobNo = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblHours = New System.Windows.Forms.DataGridView()
        Me.projectIdAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.weekAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeekendHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.scfHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rmvHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iiHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.scfHrsToDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rmvToDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iiToDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntToDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tblCost = New System.Windows.Forms.DataGridView()
        Me.projectIdCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.weekendCostAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.weekendCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.scfCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rmvCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iiCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.scfToDateCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rmvToDateCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iiToDateCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntToDateCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        CType(Me.tblHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.tblCost, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(922, 403)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 350)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(916, 50)
        Me.Panel4.TabIndex = 36
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
        Me.btnDelete.Location = New System.Drawing.Point(822, 6)
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
        Me.btnSave.Location = New System.Drawing.Point(726, 6)
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
        Me.Panel1.Size = New System.Drawing.Size(916, 62)
        Me.Panel1.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.btnSalir.Location = New System.Drawing.Point(869, 5)
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
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtClientNumber)
        Me.Panel2.Controls.Add(Me.txtUnitPO)
        Me.Panel2.Controls.Add(Me.txtDescriptionPO)
        Me.Panel2.Controls.Add(Me.cmbJobNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(916, 94)
        Me.Panel2.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(233, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Client Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(9, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(9, 64)
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
        'txtClientNumber
        '
        Me.txtClientNumber.Enabled = False
        Me.txtClientNumber.Location = New System.Drawing.Point(312, 4)
        Me.txtClientNumber.Name = "txtClientNumber"
        Me.txtClientNumber.Size = New System.Drawing.Size(65, 20)
        Me.txtClientNumber.TabIndex = 5
        '
        'txtUnitPO
        '
        Me.txtUnitPO.Enabled = False
        Me.txtUnitPO.Location = New System.Drawing.Point(80, 32)
        Me.txtUnitPO.Name = "txtUnitPO"
        Me.txtUnitPO.Size = New System.Drawing.Size(134, 20)
        Me.txtUnitPO.TabIndex = 3
        '
        'txtDescriptionPO
        '
        Me.txtDescriptionPO.Enabled = False
        Me.txtDescriptionPO.Location = New System.Drawing.Point(80, 61)
        Me.txtDescriptionPO.Name = "txtDescriptionPO"
        Me.txtDescriptionPO.Size = New System.Drawing.Size(297, 20)
        Me.txtDescriptionPO.TabIndex = 2
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
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 171)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(916, 173)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tblHours)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(908, 147)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Hours"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tblHours
        '
        Me.tblHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblHours.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.projectIdAux, Me.weekAux, Me.WeekendHrs, Me.scfHrs, Me.rmvHrs, Me.iiHrs, Me.pntHrs, Me.scfHrsToDate, Me.rmvToDate, Me.iiToDate, Me.pntToDate})
        Me.tblHours.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblHours.Location = New System.Drawing.Point(3, 3)
        Me.tblHours.Name = "tblHours"
        Me.tblHours.Size = New System.Drawing.Size(902, 141)
        Me.tblHours.TabIndex = 0
        '
        'projectIdAux
        '
        Me.projectIdAux.HeaderText = "projectIdAux"
        Me.projectIdAux.Name = "projectIdAux"
        Me.projectIdAux.Visible = False
        '
        'weekAux
        '
        Me.weekAux.HeaderText = "weekAux"
        Me.weekAux.Name = "weekAux"
        Me.weekAux.Visible = False
        '
        'WeekendHrs
        '
        Me.WeekendHrs.HeaderText = "Weekend"
        Me.WeekendHrs.Name = "WeekendHrs"
        '
        'scfHrs
        '
        Me.scfHrs.HeaderText = "SCF Hrs."
        Me.scfHrs.Name = "scfHrs"
        '
        'rmvHrs
        '
        Me.rmvHrs.HeaderText = "Rmv Hrs."
        Me.rmvHrs.Name = "rmvHrs"
        '
        'iiHrs
        '
        Me.iiHrs.HeaderText = "II Hrs."
        Me.iiHrs.Name = "iiHrs"
        '
        'pntHrs
        '
        Me.pntHrs.HeaderText = "Pnt Hrs."
        Me.pntHrs.Name = "pntHrs"
        '
        'scfHrsToDate
        '
        Me.scfHrsToDate.HeaderText = "SCF ToDate"
        Me.scfHrsToDate.Name = "scfHrsToDate"
        Me.scfHrsToDate.ReadOnly = True
        '
        'rmvToDate
        '
        Me.rmvToDate.HeaderText = "Rmv ToDate"
        Me.rmvToDate.Name = "rmvToDate"
        Me.rmvToDate.ReadOnly = True
        '
        'iiToDate
        '
        Me.iiToDate.HeaderText = "II ToDate"
        Me.iiToDate.Name = "iiToDate"
        Me.iiToDate.ReadOnly = True
        '
        'pntToDate
        '
        Me.pntToDate.HeaderText = "Pnt ToDate"
        Me.pntToDate.Name = "pntToDate"
        Me.pntToDate.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tblCost)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(908, 147)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cost"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'tblCost
        '
        Me.tblCost.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.projectIdCost, Me.weekendCostAux, Me.weekendCost, Me.scfCost, Me.rmvCost, Me.iiCost, Me.pntCost, Me.scfToDateCost, Me.rmvToDateCost, Me.iiToDateCost, Me.pntToDateCost})
        Me.tblCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblCost.Location = New System.Drawing.Point(3, 3)
        Me.tblCost.Name = "tblCost"
        Me.tblCost.Size = New System.Drawing.Size(902, 141)
        Me.tblCost.TabIndex = 0
        '
        'projectIdCost
        '
        Me.projectIdCost.HeaderText = "projectIdCost"
        Me.projectIdCost.Name = "projectIdCost"
        Me.projectIdCost.Visible = False
        '
        'weekendCostAux
        '
        Me.weekendCostAux.HeaderText = "weekendCostAux"
        Me.weekendCostAux.Name = "weekendCostAux"
        Me.weekendCostAux.Visible = False
        '
        'weekendCost
        '
        Me.weekendCost.HeaderText = "weekendCost"
        Me.weekendCost.Name = "weekendCost"
        '
        'scfCost
        '
        Me.scfCost.HeaderText = "SCF Cost"
        Me.scfCost.Name = "scfCost"
        '
        'rmvCost
        '
        Me.rmvCost.HeaderText = "Rmv Cost"
        Me.rmvCost.Name = "rmvCost"
        '
        'iiCost
        '
        Me.iiCost.HeaderText = " II. Cost"
        Me.iiCost.Name = "iiCost"
        '
        'pntCost
        '
        Me.pntCost.HeaderText = "Pnt Cost"
        Me.pntCost.Name = "pntCost"
        '
        'scfToDateCost
        '
        Me.scfToDateCost.HeaderText = "SCF ToDate"
        Me.scfToDateCost.Name = "scfToDateCost"
        '
        'rmvToDateCost
        '
        Me.rmvToDateCost.HeaderText = "Rmv ToDate"
        Me.rmvToDateCost.Name = "rmvToDateCost"
        '
        'iiToDateCost
        '
        Me.iiToDateCost.HeaderText = "II ToDate"
        Me.iiToDateCost.Name = "iiToDateCost"
        '
        'pntToDateCost
        '
        Me.pntToDateCost.HeaderText = "pnt ToDate"
        Me.pntToDateCost.Name = "pntToDateCost"
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
        'ProjectsActuals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 403)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ProjectsActuals"
        Me.Text = "ProjectsActuals"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tblCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtClientNumber As TextBox
    Friend WithEvents txtUnitPO As TextBox
    Friend WithEvents txtDescriptionPO As TextBox
    Friend WithEvents cmbJobNo As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents tblCost As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tblHours As DataGridView
    Friend WithEvents Demo As DataGridViewTextBoxColumn
    Friend WithEvents Build As DataGridViewTextBoxColumn
    Friend WithEvents Weekend As DataGridViewTextBoxColumn
    Friend WithEvents Tag As DataGridViewTextBoxColumn
    Friend WithEvents WeekendAux As DataGridViewTextBoxColumn
    Friend WithEvents TagAux As DataGridViewTextBoxColumn
    Friend WithEvents projectIdCost As DataGridViewTextBoxColumn
    Friend WithEvents weekendCostAux As DataGridViewTextBoxColumn
    Friend WithEvents weekendCost As DataGridViewTextBoxColumn
    Friend WithEvents scfCost As DataGridViewTextBoxColumn
    Friend WithEvents rmvCost As DataGridViewTextBoxColumn
    Friend WithEvents iiCost As DataGridViewTextBoxColumn
    Friend WithEvents pntCost As DataGridViewTextBoxColumn
    Friend WithEvents scfToDateCost As DataGridViewTextBoxColumn
    Friend WithEvents rmvToDateCost As DataGridViewTextBoxColumn
    Friend WithEvents iiToDateCost As DataGridViewTextBoxColumn
    Friend WithEvents pntToDateCost As DataGridViewTextBoxColumn
    Friend WithEvents projectIdAux As DataGridViewTextBoxColumn
    Friend WithEvents weekAux As DataGridViewTextBoxColumn
    Friend WithEvents WeekendHrs As DataGridViewTextBoxColumn
    Friend WithEvents scfHrs As DataGridViewTextBoxColumn
    Friend WithEvents rmvHrs As DataGridViewTextBoxColumn
    Friend WithEvents iiHrs As DataGridViewTextBoxColumn
    Friend WithEvents pntHrs As DataGridViewTextBoxColumn
    Friend WithEvents scfHrsToDate As DataGridViewTextBoxColumn
    Friend WithEvents rmvToDate As DataGridViewTextBoxColumn
    Friend WithEvents iiToDate As DataGridViewTextBoxColumn
    Friend WithEvents pntToDate As DataGridViewTextBoxColumn
End Class
