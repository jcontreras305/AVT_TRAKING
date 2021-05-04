<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeSheet
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
        Me.btnDownloadExcel = New System.Windows.Forms.Button()
        Me.btnUploadRecords = New System.Windows.Forms.Button()
        Me.txtSalida = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnDownloadExcel
        '
        Me.btnDownloadExcel.Location = New System.Drawing.Point(13, 31)
        Me.btnDownloadExcel.Name = "btnDownloadExcel"
        Me.btnDownloadExcel.Size = New System.Drawing.Size(127, 23)
        Me.btnDownloadExcel.TabIndex = 0
        Me.btnDownloadExcel.Text = "Update Excel"
        Me.btnDownloadExcel.UseVisualStyleBackColor = True
        '
        'btnUploadRecords
        '
        Me.btnUploadRecords.Location = New System.Drawing.Point(195, 31)
        Me.btnUploadRecords.Name = "btnUploadRecords"
        Me.btnUploadRecords.Size = New System.Drawing.Size(127, 23)
        Me.btnUploadRecords.TabIndex = 1
        Me.btnUploadRecords.Text = "Upload Records"
        Me.btnUploadRecords.UseVisualStyleBackColor = True
        '
        'txtSalida
        '
        Me.txtSalida.Location = New System.Drawing.Point(13, 102)
        Me.txtSalida.Multiline = True
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.ReadOnly = True
        Me.txtSalida.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSalida.Size = New System.Drawing.Size(309, 134)
        Me.txtSalida.TabIndex = 2
        '
        'TimeSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 245)
        Me.Controls.Add(Me.txtSalida)
        Me.Controls.Add(Me.btnUploadRecords)
        Me.Controls.Add(Me.btnDownloadExcel)
        Me.MaximizeBox = False
        Me.Name = "TimeSheet"
        Me.Text = "TimeSheet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDownloadExcel As Button
    Friend WithEvents btnUploadRecords As Button
    Friend WithEvents txtSalida As TextBox
End Class
