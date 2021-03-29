<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindEmployee
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
        Me.txtAsk = New System.Windows.Forms.TextBox()
        Me.btnFindEmployee = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.tblEmployees = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.tblEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAsk
        '
        Me.txtAsk.Location = New System.Drawing.Point(21, 25)
        Me.txtAsk.Name = "txtAsk"
        Me.txtAsk.Size = New System.Drawing.Size(152, 20)
        Me.txtAsk.TabIndex = 0
        '
        'btnFindEmployee
        '
        Me.btnFindEmployee.Location = New System.Drawing.Point(179, 23)
        Me.btnFindEmployee.Name = "btnFindEmployee"
        Me.btnFindEmployee.Size = New System.Drawing.Size(75, 23)
        Me.btnFindEmployee.TabIndex = 1
        Me.btnFindEmployee.Text = "Find"
        Me.btnFindEmployee.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(275, 22)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.TabIndex = 3
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'tblEmployees
        '
        Me.tblEmployees.AllowUserToAddRows = False
        Me.tblEmployees.AllowUserToDeleteRows = False
        Me.tblEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEmployees.Location = New System.Drawing.Point(0, 0)
        Me.tblEmployees.Name = "tblEmployees"
        Me.tblEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblEmployees.Size = New System.Drawing.Size(338, 222)
        Me.tblEmployees.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.tblEmployees)
        Me.Panel1.Location = New System.Drawing.Point(12, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 222)
        Me.Panel1.TabIndex = 5
        '
        'FindEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 297)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnFindEmployee)
        Me.Controls.Add(Me.txtAsk)
        Me.Name = "FindEmployee"
        Me.Text = "FindEmployee"
        CType(Me.tblEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFindEmployee As Button
    Public WithEvents txtAsk As TextBox
    Friend WithEvents btnSelect As Button
    Friend WithEvents tblEmployees As DataGridView
    Friend WithEvents Panel1 As Panel
End Class
