<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrom
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
        Me.btnEmployees = New System.Windows.Forms.Button()
        Me.btnClients = New System.Windows.Forms.Button()
        Me.btnMaterials = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnEmployees)
        Me.Panel1.Controls.Add(Me.btnClients)
        Me.Panel1.Controls.Add(Me.btnMaterials)
        Me.Panel1.Location = New System.Drawing.Point(1, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 288)
        Me.Panel1.TabIndex = 0
        '
        'btnEmployees
        '
        Me.btnEmployees.Location = New System.Drawing.Point(217, 39)
        Me.btnEmployees.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.Size = New System.Drawing.Size(69, 24)
        Me.btnEmployees.TabIndex = 2
        Me.btnEmployees.Text = "Employees"
        Me.btnEmployees.UseVisualStyleBackColor = True
        '
        'btnClients
        '
        Me.btnClients.Location = New System.Drawing.Point(131, 39)
        Me.btnClients.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.Size = New System.Drawing.Size(65, 24)
        Me.btnClients.TabIndex = 1
        Me.btnClients.Text = "Clients"
        Me.btnClients.UseVisualStyleBackColor = True
        '
        'btnMaterials
        '
        Me.btnMaterials.Location = New System.Drawing.Point(30, 39)
        Me.btnMaterials.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(69, 24)
        Me.btnMaterials.TabIndex = 0
        Me.btnMaterials.Text = "Materials"
        Me.btnMaterials.UseVisualStyleBackColor = True
        '
        'MainFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "MainFrom"
        Me.Text = "MainFrom"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnEmployees As Button
    Friend WithEvents btnClients As Button
    Friend WithEvents btnMaterials As Button
End Class
