<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkCodes
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtWorkCodeID = New System.Windows.Forms.TextBox()
        Me.TxtWorkCode = New System.Windows.Forms.TextBox()
        Me.txtEQExq1 = New System.Windows.Forms.TextBox()
        Me.txtEQExq2 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.sprBillingRate3 = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelWC = New System.Windows.Forms.Button()
        Me.sprBillingRateOT = New System.Windows.Forms.NumericUpDown()
        Me.sprBillingRate1 = New System.Windows.Forms.NumericUpDown()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnUpdateWorkCode = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAddWorkCode = New System.Windows.Forms.Button()
        Me.tblWK = New System.Windows.Forms.DataGridView()
        Me.txtBucar = New System.Windows.Forms.TextBox()
        Me.btnFindWK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.sprBillingRate3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBillingRateOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprBillingRate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblWK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Work Code ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Work Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Billing Rate"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Billing Rate OT"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 230)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "EQ Exq1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "EQ Exq2"
        '
        'txtWorkCodeID
        '
        Me.txtWorkCodeID.Location = New System.Drawing.Point(98, 21)
        Me.txtWorkCodeID.Name = "txtWorkCodeID"
        Me.txtWorkCodeID.Size = New System.Drawing.Size(120, 20)
        Me.txtWorkCodeID.TabIndex = 2
        '
        'TxtWorkCode
        '
        Me.TxtWorkCode.Location = New System.Drawing.Point(98, 55)
        Me.TxtWorkCode.Name = "TxtWorkCode"
        Me.TxtWorkCode.Size = New System.Drawing.Size(120, 20)
        Me.TxtWorkCode.TabIndex = 3
        '
        'txtEQExq1
        '
        Me.txtEQExq1.Location = New System.Drawing.Point(98, 230)
        Me.txtEQExq1.Name = "txtEQExq1"
        Me.txtEQExq1.Size = New System.Drawing.Size(120, 20)
        Me.txtEQExq1.TabIndex = 7
        '
        'txtEQExq2
        '
        Me.txtEQExq2.Location = New System.Drawing.Point(98, 265)
        Me.txtEQExq2.Name = "txtEQExq2"
        Me.txtEQExq2.Size = New System.Drawing.Size(120, 20)
        Me.txtEQExq2.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.sprBillingRate3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCancelWC)
        Me.GroupBox1.Controls.Add(Me.sprBillingRateOT)
        Me.GroupBox1.Controls.Add(Me.sprBillingRate1)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.btnUpdateWorkCode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtWorkCodeID)
        Me.GroupBox1.Controls.Add(Me.btnAddWorkCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtEQExq2)
        Me.GroupBox1.Controls.Add(Me.txtEQExq1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtWorkCode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 329)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "WorkCode"
        '
        'sprBillingRate3
        '
        Me.sprBillingRate3.DecimalPlaces = 2
        Me.sprBillingRate3.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBillingRate3.Location = New System.Drawing.Point(97, 196)
        Me.sprBillingRate3.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.sprBillingRate3.Name = "sprBillingRate3"
        Me.sprBillingRate3.Size = New System.Drawing.Size(120, 20)
        Me.sprBillingRate3.TabIndex = 13
        Me.sprBillingRate3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Billing Rate 3"
        '
        'btnCancelWC
        '
        Me.btnCancelWC.Location = New System.Drawing.Point(83, 291)
        Me.btnCancelWC.Name = "btnCancelWC"
        Me.btnCancelWC.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelWC.TabIndex = 10
        Me.btnCancelWC.Text = "Cancel"
        Me.btnCancelWC.UseVisualStyleBackColor = True
        '
        'sprBillingRateOT
        '
        Me.sprBillingRateOT.DecimalPlaces = 2
        Me.sprBillingRateOT.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBillingRateOT.Location = New System.Drawing.Point(96, 164)
        Me.sprBillingRateOT.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.sprBillingRateOT.Name = "sprBillingRateOT"
        Me.sprBillingRateOT.Size = New System.Drawing.Size(120, 20)
        Me.sprBillingRateOT.TabIndex = 6
        Me.sprBillingRateOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sprBillingRate1
        '
        Me.sprBillingRate1.DecimalPlaces = 2
        Me.sprBillingRate1.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.sprBillingRate1.Location = New System.Drawing.Point(98, 128)
        Me.sprBillingRate1.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.sprBillingRate1.Name = "sprBillingRate1"
        Me.sprBillingRate1.Size = New System.Drawing.Size(120, 20)
        Me.sprBillingRate1.TabIndex = 5
        Me.sprBillingRate1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(98, 93)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(121, 20)
        Me.txtDescription.TabIndex = 4
        '
        'btnUpdateWorkCode
        '
        Me.btnUpdateWorkCode.Location = New System.Drawing.Point(161, 291)
        Me.btnUpdateWorkCode.Name = "btnUpdateWorkCode"
        Me.btnUpdateWorkCode.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateWorkCode.TabIndex = 11
        Me.btnUpdateWorkCode.Text = "Update"
        Me.btnUpdateWorkCode.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Description"
        '
        'btnAddWorkCode
        '
        Me.btnAddWorkCode.Location = New System.Drawing.Point(4, 291)
        Me.btnAddWorkCode.Name = "btnAddWorkCode"
        Me.btnAddWorkCode.Size = New System.Drawing.Size(75, 23)
        Me.btnAddWorkCode.TabIndex = 9
        Me.btnAddWorkCode.Text = "Add"
        Me.btnAddWorkCode.UseVisualStyleBackColor = True
        '
        'tblWK
        '
        Me.tblWK.AllowUserToAddRows = False
        Me.tblWK.AllowUserToDeleteRows = False
        Me.tblWK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblWK.Location = New System.Drawing.Point(271, 67)
        Me.tblWK.Name = "tblWK"
        Me.tblWK.ReadOnly = True
        Me.tblWK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblWK.Size = New System.Drawing.Size(428, 272)
        Me.tblWK.TabIndex = 17
        '
        'txtBucar
        '
        Me.txtBucar.Location = New System.Drawing.Point(454, 29)
        Me.txtBucar.Name = "txtBucar"
        Me.txtBucar.Size = New System.Drawing.Size(164, 20)
        Me.txtBucar.TabIndex = 18
        '
        'btnFindWK
        '
        Me.btnFindWK.Location = New System.Drawing.Point(625, 27)
        Me.btnFindWK.Name = "btnFindWK"
        Me.btnFindWK.Size = New System.Drawing.Size(75, 23)
        Me.btnFindWK.TabIndex = 19
        Me.btnFindWK.Text = "Find"
        Me.btnFindWK.UseVisualStyleBackColor = True
        '
        'WorkCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 351)
        Me.Controls.Add(Me.btnFindWK)
        Me.Controls.Add(Me.txtBucar)
        Me.Controls.Add(Me.tblWK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WorkCodes"
        Me.Text = "WorkCodes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.sprBillingRate3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBillingRateOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprBillingRate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblWK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtWorkCodeID As TextBox
    Friend WithEvents TxtWorkCode As TextBox
    Friend WithEvents txtEQExq1 As TextBox
    Friend WithEvents txtEQExq2 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnAddWorkCode As Button
    Friend WithEvents btnUpdateWorkCode As Button
    Friend WithEvents sprBillingRate1 As NumericUpDown
    Friend WithEvents sprBillingRateOT As NumericUpDown
    Friend WithEvents btnCancelWC As Button
    Friend WithEvents sprBillingRate3 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents tblWK As DataGridView
    Friend WithEvents txtBucar As TextBox
    Friend WithEvents btnFindWK As Button
End Class
