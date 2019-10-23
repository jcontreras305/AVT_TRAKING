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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEmployees = New System.Windows.Forms.Button()
        Me.btnClients = New System.Windows.Forms.Button()
        Me.btnMaterials = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnEmployees)
        Me.Panel1.Controls.Add(Me.btnClients)
        Me.Panel1.Controls.Add(Me.btnMaterials)
        Me.Panel1.Location = New System.Drawing.Point(2, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 443)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(454, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Work Codes"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnEmployees
        '
        Me.btnEmployees.Location = New System.Drawing.Point(326, 60)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.Size = New System.Drawing.Size(104, 37)
        Me.btnEmployees.TabIndex = 2
        Me.btnEmployees.Text = "Employees"
        Me.btnEmployees.UseVisualStyleBackColor = True
        '
        'btnClients
        '
        Me.btnClients.Location = New System.Drawing.Point(196, 60)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.Size = New System.Drawing.Size(98, 37)
        Me.btnClients.TabIndex = 1
        Me.btnClients.Text = "Clients"
        Me.btnClients.UseVisualStyleBackColor = True
        '
        'btnMaterials
        '
        Me.btnMaterials.Location = New System.Drawing.Point(45, 60)
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(104, 37)
        Me.btnMaterials.TabIndex = 0
        Me.btnMaterials.Text = "Materials"
        Me.btnMaterials.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(719, 402)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 30)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MainFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 449)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainFrom"
        Me.Text = "MainFrom"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnEmployees As Button
    Friend WithEvents btnClients As Button
    Friend WithEvents btnMaterials As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
