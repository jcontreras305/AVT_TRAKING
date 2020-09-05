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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtClassDescription = New System.Windows.Forms.TextBox()
        Me.txtBillingRate3 = New System.Windows.Forms.TextBox()
        Me.txtBillingRateOT = New System.Windows.Forms.TextBox()
        Me.txtBillingRateST = New System.Windows.Forms.TextBox()
        Me.txtClassification = New System.Windows.Forms.TextBox()
        Me.txtWorkCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCraft = New System.Windows.Forms.TextBox()
        Me.txtSubJob = New System.Windows.Forms.TextBox()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.txtWorkCodeID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNewWork = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(2, 293)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(778, 140)
        Me.DataGridView1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 8)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 21)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Menu"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(731, 8)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 21)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(778, 254)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnNewWork)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtFiltro)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtClassDescription)
        Me.TabPage1.Controls.Add(Me.txtBillingRate3)
        Me.TabPage1.Controls.Add(Me.txtBillingRateOT)
        Me.TabPage1.Controls.Add(Me.txtBillingRateST)
        Me.TabPage1.Controls.Add(Me.txtClassification)
        Me.TabPage1.Controls.Add(Me.txtWorkCode)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtCraft)
        Me.TabPage1.Controls.Add(Me.txtSubJob)
        Me.TabPage1.Controls.Add(Me.txtJobNumber)
        Me.TabPage1.Controls.Add(Me.txtWorkCodeID)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(770, 228)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Work"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(770, 228)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sub Jobs"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(496, 206)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "Search"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(544, 204)
        Me.txtFiltro.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(138, 20)
        Me.txtFiltro.TabIndex = 46
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(613, 141)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(57, 23)
        Me.btnSave.TabIndex = 45
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(531, 50)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Class Description"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(531, 9)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "BillingRate3"
        '
        'txtClassDescription
        '
        Me.txtClassDescription.Location = New System.Drawing.Point(623, 48)
        Me.txtClassDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtClassDescription.Name = "txtClassDescription"
        Me.txtClassDescription.Size = New System.Drawing.Size(113, 20)
        Me.txtClassDescription.TabIndex = 41
        '
        'txtBillingRate3
        '
        Me.txtBillingRate3.Location = New System.Drawing.Point(623, 7)
        Me.txtBillingRate3.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBillingRate3.Name = "txtBillingRate3"
        Me.txtBillingRate3.Size = New System.Drawing.Size(113, 20)
        Me.txtBillingRate3.TabIndex = 40
        '
        'txtBillingRateOT
        '
        Me.txtBillingRateOT.Location = New System.Drawing.Point(369, 149)
        Me.txtBillingRateOT.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBillingRateOT.Name = "txtBillingRateOT"
        Me.txtBillingRateOT.Size = New System.Drawing.Size(111, 20)
        Me.txtBillingRateOT.TabIndex = 39
        '
        'txtBillingRateST
        '
        Me.txtBillingRateST.Location = New System.Drawing.Point(369, 97)
        Me.txtBillingRateST.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBillingRateST.Name = "txtBillingRateST"
        Me.txtBillingRateST.Size = New System.Drawing.Size(111, 20)
        Me.txtBillingRateST.TabIndex = 38
        '
        'txtClassification
        '
        Me.txtClassification.Location = New System.Drawing.Point(369, 48)
        Me.txtClassification.Margin = New System.Windows.Forms.Padding(2)
        Me.txtClassification.Name = "txtClassification"
        Me.txtClassification.Size = New System.Drawing.Size(111, 20)
        Me.txtClassification.TabIndex = 37
        '
        'txtWorkCode
        '
        Me.txtWorkCode.Location = New System.Drawing.Point(369, 7)
        Me.txtWorkCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWorkCode.Name = "txtWorkCode"
        Me.txtWorkCode.Size = New System.Drawing.Size(111, 20)
        Me.txtWorkCode.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(277, 151)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Billing Rate OT"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(277, 99)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Billing Rate ST"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(277, 50)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Classification"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(277, 9)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Work Code"
        '
        'txtCraft
        '
        Me.txtCraft.Location = New System.Drawing.Point(112, 147)
        Me.txtCraft.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCraft.Name = "txtCraft"
        Me.txtCraft.Size = New System.Drawing.Size(116, 20)
        Me.txtCraft.TabIndex = 31
        '
        'txtSubJob
        '
        Me.txtSubJob.Location = New System.Drawing.Point(112, 95)
        Me.txtSubJob.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSubJob.Name = "txtSubJob"
        Me.txtSubJob.Size = New System.Drawing.Size(116, 20)
        Me.txtSubJob.TabIndex = 30
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(112, 46)
        Me.txtJobNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(116, 20)
        Me.txtJobNumber.TabIndex = 29
        '
        'txtWorkCodeID
        '
        Me.txtWorkCodeID.Location = New System.Drawing.Point(112, 5)
        Me.txtWorkCodeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWorkCodeID.Name = "txtWorkCodeID"
        Me.txtWorkCodeID.Size = New System.Drawing.Size(116, 20)
        Me.txtWorkCodeID.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 151)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Craft"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 99)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Sub Job"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Job Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Work Code ID"
        '
        'btnNewWork
        '
        Me.btnNewWork.Location = New System.Drawing.Point(519, 141)
        Me.btnNewWork.Name = "btnNewWork"
        Me.btnNewWork.Size = New System.Drawing.Size(75, 23)
        Me.btnNewWork.TabIndex = 5
        Me.btnNewWork.Text = "New"
        Me.btnNewWork.UseVisualStyleBackColor = True
        '
        'WorkCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 439)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "WorkCodes"
        Me.Text = "WorkCodes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtClassDescription As TextBox
    Friend WithEvents txtBillingRate3 As TextBox
    Friend WithEvents txtBillingRateOT As TextBox
    Friend WithEvents txtBillingRateST As TextBox
    Friend WithEvents txtClassification As TextBox
    Friend WithEvents txtWorkCode As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCraft As TextBox
    Friend WithEvents txtSubJob As TextBox
    Friend WithEvents txtJobNumber As TextBox
    Friend WithEvents txtWorkCodeID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnNewWork As Button
End Class
