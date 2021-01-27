<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HoursWeekPeerEmployees
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clmWeekending = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotalST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotalOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMonST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMonOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTueST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTueOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWedST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWedOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmThuST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmThuOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFriST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFriOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSatST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSatOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSunST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSunOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombreEmployee = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFindEmployee = New System.Windows.Forms.Button()
        Me.txtFechaDeRegistro = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblNombreEmployee)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1110, 228)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmWeekending, Me.clmEployeeName, Me.clmTotalST, Me.clmTotalOT, Me.clmMonST, Me.clmMonOT, Me.clmTueST, Me.clmTueOT, Me.clmWedST, Me.clmWedOT, Me.clmThuST, Me.clmThuOT, Me.clmFriST, Me.clmFriOT, Me.clmSatST, Me.clmSatOT, Me.clmSunST, Me.clmSunOT})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 149)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1101, 79)
        Me.DataGridView1.TabIndex = 0
        '
        'clmWeekending
        '
        Me.clmWeekending.HeaderText = "Weekending"
        Me.clmWeekending.Name = "clmWeekending"
        Me.clmWeekending.ReadOnly = True
        '
        'clmEployeeName
        '
        Me.clmEployeeName.HeaderText = "Eployee Name"
        Me.clmEployeeName.Name = "clmEployeeName"
        Me.clmEployeeName.ReadOnly = True
        '
        'clmTotalST
        '
        Me.clmTotalST.HeaderText = "Total ST"
        Me.clmTotalST.Name = "clmTotalST"
        Me.clmTotalST.ReadOnly = True
        '
        'clmTotalOT
        '
        Me.clmTotalOT.HeaderText = "Total OT"
        Me.clmTotalOT.Name = "clmTotalOT"
        Me.clmTotalOT.ReadOnly = True
        '
        'clmMonST
        '
        Me.clmMonST.HeaderText = "Mon ST"
        Me.clmMonST.Name = "clmMonST"
        Me.clmMonST.ReadOnly = True
        '
        'clmMonOT
        '
        Me.clmMonOT.HeaderText = "Mon OT"
        Me.clmMonOT.Name = "clmMonOT"
        Me.clmMonOT.ReadOnly = True
        '
        'clmTueST
        '
        Me.clmTueST.HeaderText = "Tue ST"
        Me.clmTueST.Name = "clmTueST"
        Me.clmTueST.ReadOnly = True
        '
        'clmTueOT
        '
        Me.clmTueOT.HeaderText = "Tue OT"
        Me.clmTueOT.Name = "clmTueOT"
        Me.clmTueOT.ReadOnly = True
        '
        'clmWedST
        '
        Me.clmWedST.HeaderText = "Wed ST"
        Me.clmWedST.Name = "clmWedST"
        Me.clmWedST.ReadOnly = True
        '
        'clmWedOT
        '
        Me.clmWedOT.HeaderText = "Wed OT"
        Me.clmWedOT.Name = "clmWedOT"
        Me.clmWedOT.ReadOnly = True
        '
        'clmThuST
        '
        Me.clmThuST.HeaderText = "Thu ST"
        Me.clmThuST.Name = "clmThuST"
        Me.clmThuST.ReadOnly = True
        '
        'clmThuOT
        '
        Me.clmThuOT.HeaderText = "Thu OT"
        Me.clmThuOT.Name = "clmThuOT"
        Me.clmThuOT.ReadOnly = True
        '
        'clmFriST
        '
        Me.clmFriST.HeaderText = "Fri ST"
        Me.clmFriST.Name = "clmFriST"
        Me.clmFriST.ReadOnly = True
        '
        'clmFriOT
        '
        Me.clmFriOT.HeaderText = "Fri OT"
        Me.clmFriOT.Name = "clmFriOT"
        Me.clmFriOT.ReadOnly = True
        '
        'clmSatST
        '
        Me.clmSatST.HeaderText = "Sat ST"
        Me.clmSatST.Name = "clmSatST"
        Me.clmSatST.ReadOnly = True
        '
        'clmSatOT
        '
        Me.clmSatOT.HeaderText = "Sat OT"
        Me.clmSatOT.Name = "clmSatOT"
        Me.clmSatOT.ReadOnly = True
        '
        'clmSunST
        '
        Me.clmSunST.HeaderText = "Sun ST"
        Me.clmSunST.Name = "clmSunST"
        Me.clmSunST.ReadOnly = True
        '
        'clmSunOT
        '
        Me.clmSunOT.HeaderText = "Sun OT"
        Me.clmSunOT.Name = "clmSunOT"
        Me.clmSunOT.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(826, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(125, 142)
        Me.Panel3.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.AVT_TRAKING.My.Resources.Resources.user
        Me.PictureBox1.InitialImage = Global.AVT_TRAKING.My.Resources.Resources.user
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(125, 142)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(467, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(468, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Employee Number"
        '
        'lblNombreEmployee
        '
        Me.lblNombreEmployee.AutoSize = True
        Me.lblNombreEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmployee.Location = New System.Drawing.Point(219, 54)
        Me.lblNombreEmployee.Name = "lblNombreEmployee"
        Me.lblNombreEmployee.Size = New System.Drawing.Size(71, 20)
        Me.lblNombreEmployee.TabIndex = 2
        Me.lblNombreEmployee.Text = "Nombre"
        Me.lblNombreEmployee.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(220, 23)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(127, 16)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Employee Name "
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(153, 228)
        Me.Panel2.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 228)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1110, 134)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFindEmployee)
        Me.GroupBox1.Controls.Add(Me.txtFechaDeRegistro)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1104, 125)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'btnFindEmployee
        '
        Me.btnFindEmployee.Location = New System.Drawing.Point(331, 22)
        Me.btnFindEmployee.Name = "btnFindEmployee"
        Me.btnFindEmployee.Size = New System.Drawing.Size(60, 22)
        Me.btnFindEmployee.TabIndex = 7
        Me.btnFindEmployee.Text = "Find"
        Me.btnFindEmployee.UseVisualStyleBackColor = True
        '
        'txtFechaDeRegistro
        '
        Me.txtFechaDeRegistro.Enabled = False
        Me.txtFechaDeRegistro.Location = New System.Drawing.Point(102, 72)
        Me.txtFechaDeRegistro.Name = "txtFechaDeRegistro"
        Me.txtFechaDeRegistro.Size = New System.Drawing.Size(113, 20)
        Me.txtFechaDeRegistro.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(95, 22)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(230, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(557, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Label7"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(286, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(541, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Label5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Date Entered"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employee"
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 362)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1110, 310)
        Me.Panel4.TabIndex = 2
        '
        'HoursWeekPeerEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 672)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "HoursWeekPeerEmployees"
        Me.Text = "HoursWeekPeerEmployees"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNombreEmployee As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents clmWeekending As DataGridViewTextBoxColumn
    Friend WithEvents clmEployeeName As DataGridViewTextBoxColumn
    Friend WithEvents clmTotalST As DataGridViewTextBoxColumn
    Friend WithEvents clmTotalOT As DataGridViewTextBoxColumn
    Friend WithEvents clmMonST As DataGridViewTextBoxColumn
    Friend WithEvents clmMonOT As DataGridViewTextBoxColumn
    Friend WithEvents clmTueST As DataGridViewTextBoxColumn
    Friend WithEvents clmTueOT As DataGridViewTextBoxColumn
    Friend WithEvents clmWedST As DataGridViewTextBoxColumn
    Friend WithEvents clmWedOT As DataGridViewTextBoxColumn
    Friend WithEvents clmThuST As DataGridViewTextBoxColumn
    Friend WithEvents clmThuOT As DataGridViewTextBoxColumn
    Friend WithEvents clmFriST As DataGridViewTextBoxColumn
    Friend WithEvents clmFriOT As DataGridViewTextBoxColumn
    Friend WithEvents clmSatST As DataGridViewTextBoxColumn
    Friend WithEvents clmSatOT As DataGridViewTextBoxColumn
    Friend WithEvents clmSunST As DataGridViewTextBoxColumn
    Friend WithEvents clmSunOT As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFindEmployee As Button
    Friend WithEvents txtFechaDeRegistro As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
End Class
