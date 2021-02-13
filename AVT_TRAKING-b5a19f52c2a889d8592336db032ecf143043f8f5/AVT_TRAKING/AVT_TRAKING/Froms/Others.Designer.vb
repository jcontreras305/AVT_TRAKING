<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Others
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteCostDistribution = New System.Windows.Forms.Button()
        Me.btnUpdateCostDristribution = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAddWTMLS = New System.Windows.Forms.Button()
        Me.txtWTMLS = New System.Windows.Forms.TextBox()
        Me.lstWTMLS = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDeleteWTMLS = New System.Windows.Forms.Button()
        Me.btnUpdateWTMLS = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAddExpCode = New System.Windows.Forms.Button()
        Me.txtExpCode = New System.Windows.Forms.TextBox()
        Me.lstExpCode = New System.Windows.Forms.ListView()
        Me.clmNumerExpCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmNameExpCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDeleteExpCode = New System.Windows.Forms.Button()
        Me.btnUpdateExpCode = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtTypeEmployee = New System.Windows.Forms.TextBox()
        Me.btnDeleteTypeEmployee = New System.Windows.Forms.Button()
        Me.btnUpdateTypeEmploye = New System.Windows.Forms.Button()
        Me.lstTypeEmployee = New System.Windows.Forms.ListBox()
        Me.btnAddCostDristribution = New System.Windows.Forms.Button()
        Me.txtCostDistribution = New System.Windows.Forms.TextBox()
        Me.lstCostDistribution = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteCostCode = New System.Windows.Forms.Button()
        Me.btnUpdateCostCode = New System.Windows.Forms.Button()
        Me.btnAddCostCode = New System.Windows.Forms.Button()
        Me.txtCostCode = New System.Windows.Forms.TextBox()
        Me.lstCostCode = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(964, 472)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(964, 472)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(956, 446)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Others"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnAddCostDristribution)
        Me.GroupBox4.Controls.Add(Me.txtCostDistribution)
        Me.GroupBox4.Controls.Add(Me.lstCostDistribution)
        Me.GroupBox4.Controls.Add(Me.btnDeleteCostDistribution)
        Me.GroupBox4.Controls.Add(Me.btnUpdateCostDristribution)
        Me.GroupBox4.Location = New System.Drawing.Point(331, 225)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(298, 206)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cost Distribution"
        '
        'btnDeleteCostDistribution
        '
        Me.btnDeleteCostDistribution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteCostDistribution.Location = New System.Drawing.Point(191, 177)
        Me.btnDeleteCostDistribution.Name = "btnDeleteCostDistribution"
        Me.btnDeleteCostDistribution.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteCostDistribution.TabIndex = 2
        Me.btnDeleteCostDistribution.Text = "Delete"
        Me.btnDeleteCostDistribution.UseVisualStyleBackColor = True
        '
        'btnUpdateCostDristribution
        '
        Me.btnUpdateCostDristribution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateCostDristribution.Location = New System.Drawing.Point(191, 148)
        Me.btnUpdateCostDristribution.Name = "btnUpdateCostDristribution"
        Me.btnUpdateCostDristribution.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateCostDristribution.TabIndex = 1
        Me.btnUpdateCostDristribution.Text = "Update"
        Me.btnUpdateCostDristribution.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnAddWTMLS)
        Me.GroupBox3.Controls.Add(Me.txtWTMLS)
        Me.GroupBox3.Controls.Add(Me.lstWTMLS)
        Me.GroupBox3.Controls.Add(Me.btnDeleteWTMLS)
        Me.GroupBox3.Controls.Add(Me.btnUpdateWTMLS)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 225)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 206)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Work TM Lump Sum"
        '
        'btnAddWTMLS
        '
        Me.btnAddWTMLS.Location = New System.Drawing.Point(188, 46)
        Me.btnAddWTMLS.Name = "btnAddWTMLS"
        Me.btnAddWTMLS.Size = New System.Drawing.Size(75, 23)
        Me.btnAddWTMLS.TabIndex = 8
        Me.btnAddWTMLS.Text = "Add"
        Me.btnAddWTMLS.UseVisualStyleBackColor = True
        '
        'txtWTMLS
        '
        Me.txtWTMLS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWTMLS.Location = New System.Drawing.Point(188, 19)
        Me.txtWTMLS.Name = "txtWTMLS"
        Me.txtWTMLS.Size = New System.Drawing.Size(100, 20)
        Me.txtWTMLS.TabIndex = 7
        '
        'lstWTMLS
        '
        Me.lstWTMLS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lstWTMLS.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstWTMLS.FullRowSelect = True
        Me.lstWTMLS.HideSelection = False
        Me.lstWTMLS.Location = New System.Drawing.Point(3, 16)
        Me.lstWTMLS.MultiSelect = False
        Me.lstWTMLS.Name = "lstWTMLS"
        Me.lstWTMLS.Size = New System.Drawing.Size(179, 187)
        Me.lstWTMLS.TabIndex = 4
        Me.lstWTMLS.UseCompatibleStateImageBehavior = False
        Me.lstWTMLS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 175
        '
        'btnDeleteWTMLS
        '
        Me.btnDeleteWTMLS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteWTMLS.Location = New System.Drawing.Point(191, 177)
        Me.btnDeleteWTMLS.Name = "btnDeleteWTMLS"
        Me.btnDeleteWTMLS.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteWTMLS.TabIndex = 2
        Me.btnDeleteWTMLS.Text = "Delete"
        Me.btnDeleteWTMLS.UseVisualStyleBackColor = True
        '
        'btnUpdateWTMLS
        '
        Me.btnUpdateWTMLS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateWTMLS.Location = New System.Drawing.Point(191, 148)
        Me.btnUpdateWTMLS.Name = "btnUpdateWTMLS"
        Me.btnUpdateWTMLS.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateWTMLS.TabIndex = 1
        Me.btnUpdateWTMLS.Text = "Update"
        Me.btnUpdateWTMLS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddExpCode)
        Me.GroupBox2.Controls.Add(Me.txtExpCode)
        Me.GroupBox2.Controls.Add(Me.lstExpCode)
        Me.GroupBox2.Controls.Add(Me.btnDeleteExpCode)
        Me.GroupBox2.Controls.Add(Me.btnUpdateExpCode)
        Me.GroupBox2.Location = New System.Drawing.Point(330, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 182)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ExpCode"
        '
        'btnAddExpCode
        '
        Me.btnAddExpCode.Location = New System.Drawing.Point(192, 43)
        Me.btnAddExpCode.Name = "btnAddExpCode"
        Me.btnAddExpCode.Size = New System.Drawing.Size(75, 23)
        Me.btnAddExpCode.TabIndex = 6
        Me.btnAddExpCode.Text = "Add"
        Me.btnAddExpCode.UseVisualStyleBackColor = True
        '
        'txtExpCode
        '
        Me.txtExpCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExpCode.Location = New System.Drawing.Point(192, 16)
        Me.txtExpCode.Name = "txtExpCode"
        Me.txtExpCode.Size = New System.Drawing.Size(100, 20)
        Me.txtExpCode.TabIndex = 5
        '
        'lstExpCode
        '
        Me.lstExpCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstExpCode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmNumerExpCode, Me.clmNameExpCode})
        Me.lstExpCode.FullRowSelect = True
        Me.lstExpCode.HideSelection = False
        Me.lstExpCode.Location = New System.Drawing.Point(6, 16)
        Me.lstExpCode.MultiSelect = False
        Me.lstExpCode.Name = "lstExpCode"
        Me.lstExpCode.Size = New System.Drawing.Size(179, 160)
        Me.lstExpCode.TabIndex = 3
        Me.lstExpCode.UseCompatibleStateImageBehavior = False
        Me.lstExpCode.View = System.Windows.Forms.View.Details
        '
        'clmNumerExpCode
        '
        Me.clmNumerExpCode.Text = "Numer"
        Me.clmNumerExpCode.Width = 80
        '
        'clmNameExpCode
        '
        Me.clmNameExpCode.Text = "Name"
        Me.clmNameExpCode.Width = 100
        '
        'btnDeleteExpCode
        '
        Me.btnDeleteExpCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteExpCode.Location = New System.Drawing.Point(191, 153)
        Me.btnDeleteExpCode.Name = "btnDeleteExpCode"
        Me.btnDeleteExpCode.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteExpCode.TabIndex = 2
        Me.btnDeleteExpCode.Text = "Delete"
        Me.btnDeleteExpCode.UseVisualStyleBackColor = True
        '
        'btnUpdateExpCode
        '
        Me.btnUpdateExpCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateExpCode.Location = New System.Drawing.Point(191, 124)
        Me.btnUpdateExpCode.Name = "btnUpdateExpCode"
        Me.btnUpdateExpCode.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateExpCode.TabIndex = 1
        Me.btnUpdateExpCode.Text = "Update"
        Me.btnUpdateExpCode.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.txtTypeEmployee)
        Me.GroupBox1.Controls.Add(Me.btnDeleteTypeEmployee)
        Me.GroupBox1.Controls.Add(Me.btnUpdateTypeEmploye)
        Me.GroupBox1.Controls.Add(Me.lstTypeEmployee)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 182)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type Employees"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(191, 43)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtTypeEmployee
        '
        Me.txtTypeEmployee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTypeEmployee.Location = New System.Drawing.Point(191, 16)
        Me.txtTypeEmployee.Name = "txtTypeEmployee"
        Me.txtTypeEmployee.Size = New System.Drawing.Size(100, 20)
        Me.txtTypeEmployee.TabIndex = 3
        '
        'btnDeleteTypeEmployee
        '
        Me.btnDeleteTypeEmployee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteTypeEmployee.Location = New System.Drawing.Point(191, 153)
        Me.btnDeleteTypeEmployee.Name = "btnDeleteTypeEmployee"
        Me.btnDeleteTypeEmployee.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteTypeEmployee.TabIndex = 2
        Me.btnDeleteTypeEmployee.Text = "Delete"
        Me.btnDeleteTypeEmployee.UseVisualStyleBackColor = True
        '
        'btnUpdateTypeEmploye
        '
        Me.btnUpdateTypeEmploye.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateTypeEmploye.Location = New System.Drawing.Point(191, 124)
        Me.btnUpdateTypeEmploye.Name = "btnUpdateTypeEmploye"
        Me.btnUpdateTypeEmploye.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateTypeEmploye.TabIndex = 1
        Me.btnUpdateTypeEmploye.Text = "Update"
        Me.btnUpdateTypeEmploye.UseVisualStyleBackColor = True
        '
        'lstTypeEmployee
        '
        Me.lstTypeEmployee.AllowDrop = True
        Me.lstTypeEmployee.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstTypeEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTypeEmployee.FormattingEnabled = True
        Me.lstTypeEmployee.ItemHeight = 16
        Me.lstTypeEmployee.Location = New System.Drawing.Point(3, 16)
        Me.lstTypeEmployee.Name = "lstTypeEmployee"
        Me.lstTypeEmployee.Size = New System.Drawing.Size(169, 163)
        Me.lstTypeEmployee.TabIndex = 0
        '
        'btnAddCostDristribution
        '
        Me.btnAddCostDristribution.Location = New System.Drawing.Point(192, 40)
        Me.btnAddCostDristribution.Name = "btnAddCostDristribution"
        Me.btnAddCostDristribution.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCostDristribution.TabIndex = 11
        Me.btnAddCostDristribution.Text = "Add"
        Me.btnAddCostDristribution.UseVisualStyleBackColor = True
        '
        'txtCostDistribution
        '
        Me.txtCostDistribution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostDistribution.Location = New System.Drawing.Point(192, 13)
        Me.txtCostDistribution.Name = "txtCostDistribution"
        Me.txtCostDistribution.Size = New System.Drawing.Size(100, 20)
        Me.txtCostDistribution.TabIndex = 10
        '
        'lstCostDistribution
        '
        Me.lstCostDistribution.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstCostDistribution.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstCostDistribution.FullRowSelect = True
        Me.lstCostDistribution.HideSelection = False
        Me.lstCostDistribution.Location = New System.Drawing.Point(3, 16)
        Me.lstCostDistribution.MultiSelect = False
        Me.lstCostDistribution.Name = "lstCostDistribution"
        Me.lstCostDistribution.Size = New System.Drawing.Size(179, 187)
        Me.lstCostDistribution.TabIndex = 9
        Me.lstCostDistribution.UseCompatibleStateImageBehavior = False
        Me.lstCostDistribution.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Numer"
        Me.ColumnHeader1.Width = 175
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnAddCostCode)
        Me.GroupBox5.Controls.Add(Me.txtCostCode)
        Me.GroupBox5.Controls.Add(Me.lstCostCode)
        Me.GroupBox5.Controls.Add(Me.btnDeleteCostCode)
        Me.GroupBox5.Controls.Add(Me.btnUpdateCostCode)
        Me.GroupBox5.Location = New System.Drawing.Point(640, 28)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(298, 181)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Cost Code"
        '
        'btnDeleteCostCode
        '
        Me.btnDeleteCostCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteCostCode.Location = New System.Drawing.Point(191, 152)
        Me.btnDeleteCostCode.Name = "btnDeleteCostCode"
        Me.btnDeleteCostCode.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteCostCode.TabIndex = 2
        Me.btnDeleteCostCode.Text = "Delete"
        Me.btnDeleteCostCode.UseVisualStyleBackColor = True
        '
        'btnUpdateCostCode
        '
        Me.btnUpdateCostCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateCostCode.Location = New System.Drawing.Point(191, 123)
        Me.btnUpdateCostCode.Name = "btnUpdateCostCode"
        Me.btnUpdateCostCode.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateCostCode.TabIndex = 1
        Me.btnUpdateCostCode.Text = "Update"
        Me.btnUpdateCostCode.UseVisualStyleBackColor = True
        '
        'btnAddCostCode
        '
        Me.btnAddCostCode.Location = New System.Drawing.Point(194, 35)
        Me.btnAddCostCode.Name = "btnAddCostCode"
        Me.btnAddCostCode.Size = New System.Drawing.Size(75, 23)
        Me.btnAddCostCode.TabIndex = 14
        Me.btnAddCostCode.Text = "Add"
        Me.btnAddCostCode.UseVisualStyleBackColor = True
        '
        'txtCostCode
        '
        Me.txtCostCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCostCode.Location = New System.Drawing.Point(194, 8)
        Me.txtCostCode.Name = "txtCostCode"
        Me.txtCostCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCostCode.TabIndex = 13
        '
        'lstCostCode
        '
        Me.lstCostCode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstCostCode.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstCostCode.FullRowSelect = True
        Me.lstCostCode.HideSelection = False
        Me.lstCostCode.Location = New System.Drawing.Point(3, 16)
        Me.lstCostCode.MultiSelect = False
        Me.lstCostCode.Name = "lstCostCode"
        Me.lstCostCode.Size = New System.Drawing.Size(179, 162)
        Me.lstCostCode.TabIndex = 12
        Me.lstCostCode.UseCompatibleStateImageBehavior = False
        Me.lstCostCode.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Numer"
        Me.ColumnHeader3.Width = 175
        '
        'Others
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 472)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Others"
        Me.Text = "Others"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnDeleteCostDistribution As Button
    Friend WithEvents btnUpdateCostDristribution As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnDeleteWTMLS As Button
    Friend WithEvents btnUpdateWTMLS As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnDeleteExpCode As Button
    Friend WithEvents btnUpdateExpCode As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnDeleteTypeEmployee As Button
    Friend WithEvents btnUpdateTypeEmploye As Button
    Friend WithEvents lstTypeEmployee As ListBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtTypeEmployee As TextBox
    Friend WithEvents lstExpCode As ListView
    Public WithEvents clmNumerExpCode As ColumnHeader
    Public WithEvents clmNameExpCode As ColumnHeader
    Friend WithEvents btnAddExpCode As Button
    Friend WithEvents txtExpCode As TextBox
    Friend WithEvents btnAddWTMLS As Button
    Friend WithEvents txtWTMLS As TextBox
    Friend WithEvents lstWTMLS As ListView
    Public WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents btnAddCostDristribution As Button
    Friend WithEvents txtCostDistribution As TextBox
    Friend WithEvents lstCostDistribution As ListView
    Public WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnAddCostCode As Button
    Friend WithEvents txtCostCode As TextBox
    Friend WithEvents lstCostCode As ListView
    Public WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents btnDeleteCostCode As Button
    Friend WithEvents btnUpdateCostCode As Button
End Class
