<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportsMenu
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
        Me.btnTimeSheet = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTimeSheet
        '
        Me.btnTimeSheet.Location = New System.Drawing.Point(35, 30)
        Me.btnTimeSheet.Name = "btnTimeSheet"
        Me.btnTimeSheet.Size = New System.Drawing.Size(75, 23)
        Me.btnTimeSheet.TabIndex = 0
        Me.btnTimeSheet.Text = "Time Sheet"
        Me.btnTimeSheet.UseVisualStyleBackColor = True
        '
        'ReportsMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnTimeSheet)
        Me.Name = "ReportsMenu"
        Me.Text = "ReportsMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTimeSheet As Button
End Class
