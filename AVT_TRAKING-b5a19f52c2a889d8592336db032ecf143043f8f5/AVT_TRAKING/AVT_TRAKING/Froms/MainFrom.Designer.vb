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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbnoOthers = New System.Windows.Forms.Button()
        Me.btnMaterials = New System.Windows.Forms.Button()
        Me.btnWorkCodes = New System.Windows.Forms.Button()
        Me.btnClients = New System.Windows.Forms.Button()
        Me.btnEmployees = New System.Windows.Forms.Button()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(748, 8)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(45, 19)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.pnlImage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(201, 479)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Firebrick
        Me.Panel2.Controls.Add(Me.tbnoOthers)
        Me.Panel2.Controls.Add(Me.btnMaterials)
        Me.Panel2.Controls.Add(Me.btnWorkCodes)
        Me.Panel2.Controls.Add(Me.btnClients)
        Me.Panel2.Controls.Add(Me.btnEmployees)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(201, 386)
        Me.Panel2.TabIndex = 6
        '
        'tbnoOthers
        '
        Me.tbnoOthers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbnoOthers.Dock = System.Windows.Forms.DockStyle.Top
        Me.tbnoOthers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnoOthers.Location = New System.Drawing.Point(0, 140)
        Me.tbnoOthers.Margin = New System.Windows.Forms.Padding(2)
        Me.tbnoOthers.Name = "tbnoOthers"
        Me.tbnoOthers.Size = New System.Drawing.Size(201, 35)
        Me.tbnoOthers.TabIndex = 4
        Me.tbnoOthers.Text = "Others"
        Me.tbnoOthers.UseVisualStyleBackColor = True
        '
        'btnMaterials
        '
        Me.btnMaterials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMaterials.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMaterials.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaterials.Location = New System.Drawing.Point(0, 105)
        Me.btnMaterials.Margin = New System.Windows.Forms.Padding(2)
        Me.btnMaterials.Name = "btnMaterials"
        Me.btnMaterials.Size = New System.Drawing.Size(201, 35)
        Me.btnMaterials.TabIndex = 0
        Me.btnMaterials.Text = "Materials"
        Me.btnMaterials.UseVisualStyleBackColor = True
        '
        'btnWorkCodes
        '
        Me.btnWorkCodes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWorkCodes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnWorkCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkCodes.Location = New System.Drawing.Point(0, 70)
        Me.btnWorkCodes.Margin = New System.Windows.Forms.Padding(2)
        Me.btnWorkCodes.Name = "btnWorkCodes"
        Me.btnWorkCodes.Size = New System.Drawing.Size(201, 35)
        Me.btnWorkCodes.TabIndex = 3
        Me.btnWorkCodes.Text = "Work Codes"
        Me.btnWorkCodes.UseVisualStyleBackColor = True
        '
        'btnClients
        '
        Me.btnClients.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClients.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnClients.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClients.Location = New System.Drawing.Point(0, 35)
        Me.btnClients.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.Size = New System.Drawing.Size(201, 35)
        Me.btnClients.TabIndex = 1
        Me.btnClients.Text = "Clients"
        Me.btnClients.UseVisualStyleBackColor = True
        '
        'btnEmployees
        '
        Me.btnEmployees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEmployees.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmployees.Location = New System.Drawing.Point(0, 0)
        Me.btnEmployees.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEmployees.Name = "btnEmployees"
        Me.btnEmployees.Size = New System.Drawing.Size(201, 35)
        Me.btnEmployees.TabIndex = 2
        Me.btnEmployees.Text = "Employees"
        Me.btnEmployees.UseVisualStyleBackColor = True
        '
        'pnlImage
        '
        Me.pnlImage.BackColor = System.Drawing.Color.Firebrick
        Me.pnlImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlImage.Location = New System.Drawing.Point(0, 0)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(201, 93)
        Me.pnlImage.TabIndex = 4
        '
        'MainFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 479)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainFrom"
        Me.Text = "MainFrom"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnMaterials As Button
    Friend WithEvents btnWorkCodes As Button
    Friend WithEvents btnClients As Button
    Friend WithEvents btnEmployees As Button
    Friend WithEvents pnlImage As Panel
    Friend WithEvents tbnoOthers As Button
End Class
