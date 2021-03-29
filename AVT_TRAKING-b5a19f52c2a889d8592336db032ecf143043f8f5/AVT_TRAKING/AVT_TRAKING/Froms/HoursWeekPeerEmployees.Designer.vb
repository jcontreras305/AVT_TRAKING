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
        Me.tblHourPeerDay = New System.Windows.Forms.DataGridView()
        Me.clmWeekending = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotalST = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotalOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotalHours3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.pcbPhoto = New System.Windows.Forms.PictureBox()
        Me.lblEmployeeNumber = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombreEmployee = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFindFecha = New System.Windows.Forms.TextBox()
        Me.clnFindFecha = New System.Windows.Forms.MonthCalendar()
        Me.btnSAP = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.btnNextEmploye = New System.Windows.Forms.Button()
        Me.btnLatsEmploye = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.btnExpenses = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnEmpleados = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnFindEmployee = New System.Windows.Forms.Button()
        Me.cmbEmpleados = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtHours3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalOT = New System.Windows.Forms.TextBox()
        Me.txtTotalHours = New System.Windows.Forms.TextBox()
        Me.txtTotalST = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpTimeWorked = New System.Windows.Forms.TabPage()
        Me.tblRecordEmployee = New System.Windows.Forms.DataGridView()
        Me.tbpExpenses = New System.Windows.Forms.TabPage()
        Me.tblExpenses = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.tblHourPeerDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pcbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpTimeWorked.SuspendLayout()
        CType(Me.tblRecordEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpExpenses.SuspendLayout()
        CType(Me.tblExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tblHourPeerDay)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.lblEmployeeNumber)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblNombreEmployee)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1174, 190)
        Me.Panel1.TabIndex = 0
        '
        'tblHourPeerDay
        '
        Me.tblHourPeerDay.AllowUserToAddRows = False
        Me.tblHourPeerDay.AllowUserToDeleteRows = False
        Me.tblHourPeerDay.AllowUserToResizeRows = False
        Me.tblHourPeerDay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblHourPeerDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblHourPeerDay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmWeekending, Me.clmEployeeName, Me.clmTotalST, Me.clmTotalOT, Me.clmTotalHours3, Me.clmMonST, Me.clmMonOT, Me.clmTueST, Me.clmTueOT, Me.clmWedST, Me.clmWedOT, Me.clmThuST, Me.clmThuOT, Me.clmFriST, Me.clmFriOT, Me.clmSatST, Me.clmSatOT, Me.clmSunST, Me.clmSunOT})
        Me.tblHourPeerDay.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tblHourPeerDay.Location = New System.Drawing.Point(0, 132)
        Me.tblHourPeerDay.MultiSelect = False
        Me.tblHourPeerDay.Name = "tblHourPeerDay"
        Me.tblHourPeerDay.ReadOnly = True
        Me.tblHourPeerDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblHourPeerDay.Size = New System.Drawing.Size(1174, 58)
        Me.tblHourPeerDay.TabIndex = 0
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
        'clmTotalHours3
        '
        Me.clmTotalHours3.HeaderText = "Total 3"
        Me.clmTotalHours3.Name = "clmTotalHours3"
        Me.clmTotalHours3.ReadOnly = True
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
        Me.Panel3.Controls.Add(Me.pcbPhoto)
        Me.Panel3.Location = New System.Drawing.Point(857, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(115, 112)
        Me.Panel3.TabIndex = 5
        '
        'pcbPhoto
        '
        Me.pcbPhoto.BackColor = System.Drawing.Color.White
        Me.pcbPhoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcbPhoto.Image = Global.AVT_TRAKING.My.Resources.Resources.user
        Me.pcbPhoto.InitialImage = Global.AVT_TRAKING.My.Resources.Resources.user
        Me.pcbPhoto.Location = New System.Drawing.Point(0, 0)
        Me.pcbPhoto.Name = "pcbPhoto"
        Me.pcbPhoto.Size = New System.Drawing.Size(115, 112)
        Me.pcbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbPhoto.TabIndex = 0
        Me.pcbPhoto.TabStop = False
        '
        'lblEmployeeNumber
        '
        Me.lblEmployeeNumber.AutoSize = True
        Me.lblEmployeeNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeNumber.Location = New System.Drawing.Point(467, 54)
        Me.lblEmployeeNumber.Name = "lblEmployeeNumber"
        Me.lblEmployeeNumber.Size = New System.Drawing.Size(71, 20)
        Me.lblEmployeeNumber.TabIndex = 4
        Me.lblEmployeeNumber.Text = "Number"
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 190)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1174, 482)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFindFecha)
        Me.GroupBox1.Controls.Add(Me.clnFindFecha)
        Me.GroupBox1.Controls.Add(Me.btnSAP)
        Me.GroupBox1.Controls.Add(Me.Button13)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.btnNextEmploye)
        Me.GroupBox1.Controls.Add(Me.btnLatsEmploye)
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.btnExpenses)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btnEmpleados)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnFindEmployee)
        Me.GroupBox1.Controls.Add(Me.cmbEmpleados)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1164, 125)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'txtFindFecha
        '
        Me.txtFindFecha.Location = New System.Drawing.Point(95, 68)
        Me.txtFindFecha.Name = "txtFindFecha"
        Me.txtFindFecha.Size = New System.Drawing.Size(171, 20)
        Me.txtFindFecha.TabIndex = 24
        '
        'clnFindFecha
        '
        Me.clnFindFecha.Location = New System.Drawing.Point(107, 78)
        Me.clnFindFecha.Name = "clnFindFecha"
        Me.clnFindFecha.TabIndex = 23
        '
        'btnSAP
        '
        Me.btnSAP.Location = New System.Drawing.Point(294, 67)
        Me.btnSAP.Name = "btnSAP"
        Me.btnSAP.Size = New System.Drawing.Size(75, 23)
        Me.btnSAP.TabIndex = 22
        Me.btnSAP.Text = "0"
        Me.btnSAP.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(944, 60)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(78, 32)
        Me.Button13.TabIndex = 20
        Me.Button13.Text = "Open Project"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(826, 60)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(112, 32)
        Me.Button12.TabIndex = 19
        Me.Button12.Text = "Dialv Peer Diem"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'btnNextEmploye
        '
        Me.btnNextEmploye.Location = New System.Drawing.Point(753, 60)
        Me.btnNextEmploye.Name = "btnNextEmploye"
        Me.btnNextEmploye.Size = New System.Drawing.Size(67, 32)
        Me.btnNextEmploye.TabIndex = 18
        Me.btnNextEmploye.Text = "Record ->"
        Me.btnNextEmploye.UseVisualStyleBackColor = True
        '
        'btnLatsEmploye
        '
        Me.btnLatsEmploye.Location = New System.Drawing.Point(680, 61)
        Me.btnLatsEmploye.Name = "btnLatsEmploye"
        Me.btnLatsEmploye.Size = New System.Drawing.Size(67, 32)
        Me.btnLatsEmploye.TabIndex = 17
        Me.btnLatsEmploye.Text = "<- Record"
        Me.btnLatsEmploye.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(607, 60)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(67, 32)
        Me.Button9.TabIndex = 16
        Me.Button9.Text = "<---"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(794, 18)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(71, 32)
        Me.Button8.TabIndex = 15
        Me.Button8.Text = "Time"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'btnExpenses
        '
        Me.btnExpenses.Location = New System.Drawing.Point(871, 17)
        Me.btnExpenses.Name = "btnExpenses"
        Me.btnExpenses.Size = New System.Drawing.Size(95, 32)
        Me.btnExpenses.TabIndex = 14
        Me.btnExpenses.Text = "Expenses"
        Me.btnExpenses.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(718, 18)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(70, 32)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Pay Roll"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(607, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(105, 32)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Material Entry From"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(512, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(89, 32)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Peer-Diem"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(512, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 32)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Wo-Peer-Diem"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnEmpleados
        '
        Me.btnEmpleados.Location = New System.Drawing.Point(397, 61)
        Me.btnEmpleados.Name = "btnEmpleados"
        Me.btnEmpleados.Size = New System.Drawing.Size(109, 32)
        Me.btnEmpleados.TabIndex = 9
        Me.btnEmpleados.Text = "Add Employee"
        Me.btnEmpleados.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(397, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 32)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Vacation / History"
        Me.Button1.UseVisualStyleBackColor = True
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
        'cmbEmpleados
        '
        Me.cmbEmpleados.FormattingEnabled = True
        Me.cmbEmpleados.Location = New System.Drawing.Point(95, 22)
        Me.cmbEmpleados.Name = "cmbEmpleados"
        Me.cmbEmpleados.Size = New System.Drawing.Size(230, 21)
        Me.cmbEmpleados.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 69)
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
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 324)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1174, 348)
        Me.Panel4.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtHours3)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.txtTotalOT)
        Me.Panel5.Controls.Add(Me.txtTotalHours)
        Me.Panel5.Controls.Add(Me.txtTotalST)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 299)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1174, 49)
        Me.Panel5.TabIndex = 1
        '
        'txtHours3
        '
        Me.txtHours3.Location = New System.Drawing.Point(615, 17)
        Me.txtHours3.Name = "txtHours3"
        Me.txtHours3.Size = New System.Drawing.Size(100, 20)
        Me.txtHours3.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(533, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total Hours 3"
        '
        'txtTotalOT
        '
        Me.txtTotalOT.Location = New System.Drawing.Point(416, 17)
        Me.txtTotalOT.Name = "txtTotalOT"
        Me.txtTotalOT.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalOT.TabIndex = 5
        '
        'txtTotalHours
        '
        Me.txtTotalHours.Location = New System.Drawing.Point(797, 17)
        Me.txtTotalHours.Name = "txtTotalHours"
        Me.txtTotalHours.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalHours.TabIndex = 4
        '
        'txtTotalST
        '
        Me.txtTotalST.Location = New System.Drawing.Point(218, 17)
        Me.txtTotalST.Name = "txtTotalST"
        Me.txtTotalST.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalST.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(735, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Total Hours"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(331, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Total Hours OT"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(150, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Hours ST"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1174, 348)
        Me.Panel2.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbpTimeWorked)
        Me.TabControl1.Controls.Add(Me.tbpExpenses)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1174, 348)
        Me.TabControl1.TabIndex = 0
        '
        'tbpTimeWorked
        '
        Me.tbpTimeWorked.Controls.Add(Me.tblRecordEmployee)
        Me.tbpTimeWorked.Location = New System.Drawing.Point(4, 22)
        Me.tbpTimeWorked.Name = "tbpTimeWorked"
        Me.tbpTimeWorked.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpTimeWorked.Size = New System.Drawing.Size(1166, 322)
        Me.tbpTimeWorked.TabIndex = 0
        Me.tbpTimeWorked.Text = "Time Worked"
        Me.tbpTimeWorked.UseVisualStyleBackColor = True
        '
        'tblRecordEmployee
        '
        Me.tblRecordEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblRecordEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblRecordEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblRecordEmployee.Location = New System.Drawing.Point(3, 3)
        Me.tblRecordEmployee.Name = "tblRecordEmployee"
        Me.tblRecordEmployee.Size = New System.Drawing.Size(1160, 316)
        Me.tblRecordEmployee.TabIndex = 0
        '
        'tbpExpenses
        '
        Me.tbpExpenses.Controls.Add(Me.tblExpenses)
        Me.tbpExpenses.Location = New System.Drawing.Point(4, 22)
        Me.tbpExpenses.Name = "tbpExpenses"
        Me.tbpExpenses.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpExpenses.Size = New System.Drawing.Size(1166, 322)
        Me.tbpExpenses.TabIndex = 1
        Me.tbpExpenses.Text = "Expenses"
        Me.tbpExpenses.UseVisualStyleBackColor = True
        '
        'tblExpenses
        '
        Me.tblExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblExpenses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblExpenses.Location = New System.Drawing.Point(3, 3)
        Me.tblExpenses.Name = "tblExpenses"
        Me.tblExpenses.Size = New System.Drawing.Size(1160, 316)
        Me.tblExpenses.TabIndex = 0
        '
        'HoursWeekPeerEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 672)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "HoursWeekPeerEmployees"
        Me.Text = "HoursWeekPeerEmployees"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.tblHourPeerDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pcbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbpTimeWorked.ResumeLayout(False)
        CType(Me.tblRecordEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpExpenses.ResumeLayout(False)
        CType(Me.tblExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents lblEmployeeNumber As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNombreEmployee As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pcbPhoto As PictureBox
    Friend WithEvents tblHourPeerDay As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnFindEmployee As Button
    Friend WithEvents cmbEmpleados As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents btnNextEmploye As Button
    Friend WithEvents btnLatsEmploye As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents btnExpenses As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents btnEmpleados As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtTotalOT As TextBox
    Friend WithEvents txtTotalHours As TextBox
    Friend WithEvents txtTotalST As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbpTimeWorked As TabPage
    Friend WithEvents tblRecordEmployee As DataGridView
    Friend WithEvents tbpExpenses As TabPage
    Friend WithEvents btnSAP As Button
    Friend WithEvents tblExpenses As DataGridView
    Friend WithEvents txtHours3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents clmWeekending As DataGridViewTextBoxColumn
    Friend WithEvents clmEployeeName As DataGridViewTextBoxColumn
    Friend WithEvents clmTotalST As DataGridViewTextBoxColumn
    Friend WithEvents clmTotalOT As DataGridViewTextBoxColumn
    Friend WithEvents clmTotalHours3 As DataGridViewTextBoxColumn
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
    Friend WithEvents txtFindFecha As TextBox
    Friend WithEvents clnFindFecha As MonthCalendar
End Class
