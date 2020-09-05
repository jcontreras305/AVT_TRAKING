<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectMaterial
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNameMaterialSM = New System.Windows.Forms.TextBox()
        Me.tblMaterialSM = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbNombreVendorSM = New System.Windows.Forms.ComboBox()
        CType(Me.tblMaterialSM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Material"
        '
        'txtNameMaterialSM
        '
        Me.txtNameMaterialSM.Location = New System.Drawing.Point(59, 17)
        Me.txtNameMaterialSM.Name = "txtNameMaterialSM"
        Me.txtNameMaterialSM.Size = New System.Drawing.Size(170, 20)
        Me.txtNameMaterialSM.TabIndex = 1
        '
        'tblMaterialSM
        '
        Me.tblMaterialSM.AllowUserToAddRows = False
        Me.tblMaterialSM.AllowUserToDeleteRows = False
        Me.tblMaterialSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblMaterialSM.Location = New System.Drawing.Point(14, 74)
        Me.tblMaterialSM.MultiSelect = False
        Me.tblMaterialSM.Name = "tblMaterialSM"
        Me.tblMaterialSM.ReadOnly = True
        Me.tblMaterialSM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblMaterialSM.Size = New System.Drawing.Size(304, 252)
        Me.tblMaterialSM.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(142, 346)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(243, 346)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Vendor"
        '
        'cmbNombreVendorSM
        '
        Me.cmbNombreVendorSM.FormattingEnabled = True
        Me.cmbNombreVendorSM.Location = New System.Drawing.Point(59, 47)
        Me.cmbNombreVendorSM.Name = "cmbNombreVendorSM"
        Me.cmbNombreVendorSM.Size = New System.Drawing.Size(170, 21)
        Me.cmbNombreVendorSM.TabIndex = 6
        '
        'SelectMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 391)
        Me.Controls.Add(Me.cmbNombreVendorSM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.tblMaterialSM)
        Me.Controls.Add(Me.txtNameMaterialSM)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SelectMaterial"
        Me.Text = "SelectMaterial"
        CType(Me.tblMaterialSM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents Label2 As Label
    Public WithEvents txtNameMaterialSM As TextBox
    Public WithEvents tblMaterialSM As DataGridView
    Public WithEvents cmbNombreVendorSM As ComboBox
End Class
