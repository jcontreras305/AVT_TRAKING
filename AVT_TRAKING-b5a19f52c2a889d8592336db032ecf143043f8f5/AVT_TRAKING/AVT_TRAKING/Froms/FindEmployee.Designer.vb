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
        Me.tblFindEmployee = New System.Windows.Forms.DataGridView()
        CType(Me.tblFindEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnFindEmployee.Location = New System.Drawing.Point(179, 25)
        Me.btnFindEmployee.Name = "btnFindEmployee"
        Me.btnFindEmployee.Size = New System.Drawing.Size(75, 23)
        Me.btnFindEmployee.TabIndex = 1
        Me.btnFindEmployee.Text = "Find"
        Me.btnFindEmployee.UseVisualStyleBackColor = True
        '
        'tblFindEmployee
        '
        Me.tblFindEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblFindEmployee.Location = New System.Drawing.Point(12, 54)
        Me.tblFindEmployee.Name = "tblFindEmployee"
        Me.tblFindEmployee.Size = New System.Drawing.Size(442, 231)
        Me.tblFindEmployee.TabIndex = 2
        '
        'FindEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 297)
        Me.Controls.Add(Me.tblFindEmployee)
        Me.Controls.Add(Me.btnFindEmployee)
        Me.Controls.Add(Me.txtAsk)
        Me.Name = "FindEmployee"
        Me.Text = "FindEmployee"
        CType(Me.tblFindEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFindEmployee As Button
    Public WithEvents txtAsk As TextBox
    Public WithEvents tblFindEmployee As DataGridView
End Class
