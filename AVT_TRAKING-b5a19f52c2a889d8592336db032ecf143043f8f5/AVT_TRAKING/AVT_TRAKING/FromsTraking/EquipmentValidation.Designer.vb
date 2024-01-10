<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentValidation
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
        Me.lbljobNo = New System.Windows.Forms.Label()
        Me.dtpInformation = New System.Windows.Forms.DateTimePicker()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnMinimize = New System.Windows.Forms.PictureBox()
        Me.btnRestore = New System.Windows.Forms.PictureBox()
        Me.btnMaximize = New System.Windows.Forms.PictureBox()
        Me.btnUpdateMaterialExcel = New System.Windows.Forms.Button()
        Me.txtInformation = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.cmbInformation = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tblEquipment = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pgbComplete = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.ErrorClm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateEquip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProjectEquip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAux = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassEquip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmJobNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tblEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1067, 554)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lbljobNo)
        Me.Panel1.Controls.Add(Me.dtpInformation)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.btnMinimize)
        Me.Panel1.Controls.Add(Me.btnRestore)
        Me.Panel1.Controls.Add(Me.btnMaximize)
        Me.Panel1.Controls.Add(Me.btnUpdateMaterialExcel)
        Me.Panel1.Controls.Add(Me.txtInformation)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.cmbInformation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1059, 90)
        Me.Panel1.TabIndex = 0
        '
        'lbljobNo
        '
        Me.lbljobNo.AutoSize = True
        Me.lbljobNo.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbljobNo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbljobNo.Location = New System.Drawing.Point(315, 55)
        Me.lbljobNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbljobNo.Name = "lbljobNo"
        Me.lbljobNo.Size = New System.Drawing.Size(91, 23)
        Me.lbljobNo.TabIndex = 46
        Me.lbljobNo.Text = "Job No:"
        '
        'dtpInformation
        '
        Me.dtpInformation.CustomFormat = "MM/dd/yyyy"
        Me.dtpInformation.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInformation.Location = New System.Drawing.Point(12, 53)
        Me.dtpInformation.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpInformation.Name = "dtpInformation"
        Me.dtpInformation.Size = New System.Drawing.Size(180, 22)
        Me.dtpInformation.TabIndex = 4
        Me.dtpInformation.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Image = Global.AVT_TRAKING.My.Resources.Resources.save1
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(749, 41)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(92, 47)
        Me.btnSave.TabIndex = 45
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.PictureBox4.Location = New System.Drawing.Point(1009, 43)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(45, 38)
        Me.PictureBox4.TabIndex = 44
        Me.PictureBox4.TabStop = False
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.Image = Global.AVT_TRAKING.My.Resources.Resources.minimize2
        Me.btnMinimize.Location = New System.Drawing.Point(981, 4)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(35, 33)
        Me.btnMinimize.TabIndex = 43
        Me.btnMinimize.TabStop = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.Image = Global.AVT_TRAKING.My.Resources.Resources.restore2
        Me.btnRestore.Location = New System.Drawing.Point(1021, 5)
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(31, 33)
        Me.btnRestore.TabIndex = 42
        Me.btnRestore.TabStop = False
        '
        'btnMaximize
        '
        Me.btnMaximize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximize.Image = Global.AVT_TRAKING.My.Resources.Resources.maximize2
        Me.btnMaximize.Location = New System.Drawing.Point(1021, 7)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(31, 31)
        Me.btnMaximize.TabIndex = 41
        Me.btnMaximize.TabStop = False
        '
        'btnUpdateMaterialExcel
        '
        Me.btnUpdateMaterialExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateMaterialExcel.FlatAppearance.BorderSize = 0
        Me.btnUpdateMaterialExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnUpdateMaterialExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateMaterialExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnUpdateMaterialExcel.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnUpdateMaterialExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateMaterialExcel.Location = New System.Drawing.Point(607, 41)
        Me.btnUpdateMaterialExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateMaterialExcel.Name = "btnUpdateMaterialExcel"
        Me.btnUpdateMaterialExcel.Size = New System.Drawing.Size(135, 47)
        Me.btnUpdateMaterialExcel.TabIndex = 40
        Me.btnUpdateMaterialExcel.Text = "Find Excel"
        Me.btnUpdateMaterialExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateMaterialExcel.UseVisualStyleBackColor = True
        '
        'txtInformation
        '
        Me.txtInformation.Location = New System.Drawing.Point(41, 53)
        Me.txtInformation.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInformation.Name = "txtInformation"
        Me.txtInformation.Size = New System.Drawing.Size(180, 22)
        Me.txtInformation.TabIndex = 5
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTitle.Location = New System.Drawing.Point(4, 7)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(281, 23)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Material Validation Excel"
        '
        'cmbInformation
        '
        Me.cmbInformation.FormattingEnabled = True
        Me.cmbInformation.Location = New System.Drawing.Point(125, 53)
        Me.cmbInformation.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbInformation.Name = "cmbInformation"
        Me.cmbInformation.Size = New System.Drawing.Size(180, 24)
        Me.cmbInformation.TabIndex = 3
        Me.cmbInformation.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel2.Controls.Add(Me.tblEquipment)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 102)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1059, 406)
        Me.Panel2.TabIndex = 1
        '
        'tblEquipment
        '
        Me.tblEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ErrorClm, Me.DateEquip, Me.ProjectEquip, Me.idAux, Me.MaterialCode, Me.Amount, Me.Description, Me.ClassEquip, Me.STHrs, Me.clmJobNo})
        Me.tblEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEquipment.Location = New System.Drawing.Point(0, 0)
        Me.tblEquipment.Margin = New System.Windows.Forms.Padding(4)
        Me.tblEquipment.Name = "tblEquipment"
        Me.tblEquipment.RowHeadersWidth = 51
        Me.tblEquipment.Size = New System.Drawing.Size(1059, 406)
        Me.tblEquipment.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel3.Controls.Add(Me.pgbComplete)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 516)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1059, 34)
        Me.Panel3.TabIndex = 2
        '
        'pgbComplete
        '
        Me.pgbComplete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgbComplete.Location = New System.Drawing.Point(784, 4)
        Me.pgbComplete.Margin = New System.Windows.Forms.Padding(4)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(263, 28)
        Me.pgbComplete.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(28, 12)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(73, 17)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Message: "
        '
        'ErrorClm
        '
        Me.ErrorClm.HeaderText = "Error"
        Me.ErrorClm.MinimumWidth = 6
        Me.ErrorClm.Name = "ErrorClm"
        Me.ErrorClm.ReadOnly = True
        Me.ErrorClm.Visible = False
        '
        'DateEquip
        '
        Me.DateEquip.HeaderText = "Date"
        Me.DateEquip.MinimumWidth = 6
        Me.DateEquip.Name = "DateEquip"
        '
        'ProjectEquip
        '
        Me.ProjectEquip.HeaderText = "Project"
        Me.ProjectEquip.MinimumWidth = 6
        Me.ProjectEquip.Name = "ProjectEquip"
        '
        'idAux
        '
        Me.idAux.HeaderText = "idAux"
        Me.idAux.MinimumWidth = 6
        Me.idAux.Name = "idAux"
        '
        'MaterialCode
        '
        Me.MaterialCode.HeaderText = "MaterialCode"
        Me.MaterialCode.MinimumWidth = 6
        Me.MaterialCode.Name = "MaterialCode"
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.MinimumWidth = 6
        Me.Amount.Name = "Amount"
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        '
        'ClassEquip
        '
        Me.ClassEquip.HeaderText = "Class"
        Me.ClassEquip.MinimumWidth = 6
        Me.ClassEquip.Name = "ClassEquip"
        Me.ClassEquip.ReadOnly = True
        '
        'STHrs
        '
        Me.STHrs.HeaderText = "ST Hrs"
        Me.STHrs.MinimumWidth = 6
        Me.STHrs.Name = "STHrs"
        '
        'clmJobNo
        '
        Me.clmJobNo.HeaderText = "JobNo"
        Me.clmJobNo.MinimumWidth = 6
        Me.clmJobNo.Name = "clmJobNo"
        Me.clmJobNo.Visible = False
        '
        'EquipmentValidation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 554)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "EquipmentValidation"
        Me.Text = "EquipmentValidation"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRestore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.tblEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents tblEquipment As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pgbComplete As ProgressBar
    Friend WithEvents lblMessage As Label
    Friend WithEvents txtInformation As TextBox
    Friend WithEvents dtpInformation As DateTimePicker
    Friend WithEvents cmbInformation As ComboBox
    Friend WithEvents btnUpdateMaterialExcel As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnMinimize As PictureBox
    Friend WithEvents btnRestore As PictureBox
    Friend WithEvents btnMaximize As PictureBox
    Friend WithEvents btnSave As Button
    Friend WithEvents lbljobNo As Label
    Friend WithEvents ErrorClm As DataGridViewTextBoxColumn
    Friend WithEvents DateEquip As DataGridViewTextBoxColumn
    Friend WithEvents ProjectEquip As DataGridViewTextBoxColumn
    Friend WithEvents idAux As DataGridViewTextBoxColumn
    Friend WithEvents MaterialCode As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents ClassEquip As DataGridViewTextBoxColumn
    Friend WithEvents STHrs As DataGridViewTextBoxColumn
    Friend WithEvents clmJobNo As DataGridViewTextBoxColumn
End Class
