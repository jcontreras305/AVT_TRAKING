<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DismantleValidationTable
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sprFirstRow = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdateExcel = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.cmbDatos = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.tblDismantleSC = New System.Windows.Forms.DataGridView()
        Me.clmErrorD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTagID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmWorkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReqComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Foreman = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Erector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RentStopDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DismantleDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Truck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Forklift = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Trailer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Crane = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rope = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Passed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Elevator = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Dismantle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Travel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weather = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alarm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Safety = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stdBY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Other = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pgbComplete = New System.Windows.Forms.ProgressBar()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.sprFirstRow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.tblDismantleSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.sprFirstRow)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnUpdateExcel)
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.cmbDatos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 44)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(283, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "First Row To Read"
        '
        'sprFirstRow
        '
        Me.sprFirstRow.Location = New System.Drawing.Point(385, 12)
        Me.sprFirstRow.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.sprFirstRow.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.sprFirstRow.Name = "sprFirstRow"
        Me.sprFirstRow.Size = New System.Drawing.Size(63, 20)
        Me.sprFirstRow.TabIndex = 2
        Me.sprFirstRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.sprFirstRow.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(682, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 31)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdateExcel
        '
        Me.btnUpdateExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateExcel.Location = New System.Drawing.Point(567, 6)
        Me.btnUpdateExcel.Name = "btnUpdateExcel"
        Me.btnUpdateExcel.Size = New System.Drawing.Size(103, 31)
        Me.btnUpdateExcel.TabIndex = 3
        Me.btnUpdateExcel.Text = "Update Excel"
        Me.btnUpdateExcel.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(146, 11)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(131, 20)
        Me.txtFecha.TabIndex = 1
        '
        'cmbDatos
        '
        Me.cmbDatos.FormattingEnabled = True
        Me.cmbDatos.Location = New System.Drawing.Point(9, 11)
        Me.cmbDatos.Name = "cmbDatos"
        Me.cmbDatos.Size = New System.Drawing.Size(131, 21)
        Me.cmbDatos.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 364)
        Me.Panel2.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(794, 364)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tblDismantleSC)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(786, 338)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Dismantle"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'tblDismantleSC
        '
        Me.tblDismantleSC.AllowUserToAddRows = False
        Me.tblDismantleSC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.tblDismantleSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblDismantleSC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmErrorD, Me.clmTagID, Me.clmWorkNum, Me.ReqComp, Me.RequestBy, Me.Foreman, Me.Erector, Me.RentStopDate, Me.DismantleDate, Me.Truck, Me.Forklift, Me.Trailer, Me.Crane, Me.Rope, Me.Passed, Me.Elevator, Me.Dismantle, Me.Material, Me.Travel, Me.Weather, Me.Alarm, Me.Safety, Me.stdBY, Me.Other, Me.TotalHours, Me.Comments})
        Me.tblDismantleSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblDismantleSC.Location = New System.Drawing.Point(3, 3)
        Me.tblDismantleSC.Name = "tblDismantleSC"
        Me.tblDismantleSC.Size = New System.Drawing.Size(780, 332)
        Me.tblDismantleSC.TabIndex = 0
        '
        'clmErrorD
        '
        Me.clmErrorD.Frozen = True
        Me.clmErrorD.HeaderText = "Error"
        Me.clmErrorD.Name = "clmErrorD"
        Me.clmErrorD.ReadOnly = True
        Me.clmErrorD.Visible = False
        Me.clmErrorD.Width = 54
        '
        'clmTagID
        '
        Me.clmTagID.Frozen = True
        Me.clmTagID.HeaderText = "TagID"
        Me.clmTagID.Name = "clmTagID"
        Me.clmTagID.Width = 62
        '
        'clmWorkNum
        '
        Me.clmWorkNum.HeaderText = "WorkNum"
        Me.clmWorkNum.Name = "clmWorkNum"
        Me.clmWorkNum.Width = 80
        '
        'ReqComp
        '
        Me.ReqComp.HeaderText = "ReqComp"
        Me.ReqComp.Name = "ReqComp"
        Me.ReqComp.Width = 79
        '
        'RequestBy
        '
        Me.RequestBy.HeaderText = "RequestBy"
        Me.RequestBy.Name = "RequestBy"
        Me.RequestBy.Width = 84
        '
        'Foreman
        '
        Me.Foreman.HeaderText = "Foreman"
        Me.Foreman.Name = "Foreman"
        Me.Foreman.Width = 73
        '
        'Erector
        '
        Me.Erector.HeaderText = "Erector"
        Me.Erector.Name = "Erector"
        Me.Erector.Width = 66
        '
        'RentStopDate
        '
        Me.RentStopDate.HeaderText = "Rent Stop Date"
        Me.RentStopDate.Name = "RentStopDate"
        Me.RentStopDate.Width = 97
        '
        'DismantleDate
        '
        Me.DismantleDate.HeaderText = "Dismantle Date"
        Me.DismantleDate.Name = "DismantleDate"
        Me.DismantleDate.Width = 96
        '
        'Truck
        '
        Me.Truck.HeaderText = "Truck"
        Me.Truck.Name = "Truck"
        Me.Truck.Width = 41
        '
        'Forklift
        '
        Me.Forklift.HeaderText = "Forklift"
        Me.Forklift.Name = "Forklift"
        Me.Forklift.Width = 44
        '
        'Trailer
        '
        Me.Trailer.HeaderText = "Trailer"
        Me.Trailer.Name = "Trailer"
        Me.Trailer.Width = 42
        '
        'Crane
        '
        Me.Crane.HeaderText = "Crane"
        Me.Crane.Name = "Crane"
        Me.Crane.Width = 41
        '
        'Rope
        '
        Me.Rope.HeaderText = "Rope"
        Me.Rope.Name = "Rope"
        Me.Rope.Width = 39
        '
        'Passed
        '
        Me.Passed.HeaderText = "Passed"
        Me.Passed.Name = "Passed"
        Me.Passed.Width = 48
        '
        'Elevator
        '
        Me.Elevator.HeaderText = "Elevator"
        Me.Elevator.Name = "Elevator"
        Me.Elevator.Width = 52
        '
        'Dismantle
        '
        Me.Dismantle.HeaderText = "Dismantle"
        Me.Dismantle.Name = "Dismantle"
        Me.Dismantle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dismantle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Dismantle.Width = 59
        '
        'Material
        '
        Me.Material.HeaderText = "Material"
        Me.Material.Name = "Material"
        Me.Material.Width = 69
        '
        'Travel
        '
        Me.Travel.HeaderText = "Travel"
        Me.Travel.Name = "Travel"
        Me.Travel.Width = 62
        '
        'Weather
        '
        Me.Weather.HeaderText = "Weather"
        Me.Weather.Name = "Weather"
        Me.Weather.Width = 73
        '
        'Alarm
        '
        Me.Alarm.HeaderText = "Alarm"
        Me.Alarm.Name = "Alarm"
        Me.Alarm.Width = 58
        '
        'Safety
        '
        Me.Safety.HeaderText = "Safety"
        Me.Safety.Name = "Safety"
        Me.Safety.Width = 62
        '
        'stdBY
        '
        Me.stdBY.HeaderText = "stdBY"
        Me.stdBY.Name = "stdBY"
        Me.stdBY.Width = 60
        '
        'Other
        '
        Me.Other.HeaderText = "Other"
        Me.Other.Name = "Other"
        Me.Other.Width = 58
        '
        'TotalHours
        '
        Me.TotalHours.HeaderText = "TotalHours"
        Me.TotalHours.Name = "TotalHours"
        Me.TotalHours.Width = 84
        '
        'Comments
        '
        Me.Comments.HeaderText = "Comments"
        Me.Comments.Name = "Comments"
        Me.Comments.Width = 81
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pgbComplete)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 423)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(794, 24)
        Me.Panel3.TabIndex = 2
        '
        'pgbComplete
        '
        Me.pgbComplete.Dock = System.Windows.Forms.DockStyle.Right
        Me.pgbComplete.Location = New System.Drawing.Point(542, 0)
        Me.pgbComplete.Name = "pgbComplete"
        Me.pgbComplete.Size = New System.Drawing.Size(252, 24)
        Me.pgbComplete.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(53, 13)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Message:"
        '
        'DismantleValidationTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "DismantleValidationTable"
        Me.Text = "DimantleValidationTable"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.sprFirstRow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.tblDismantleSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbDatos As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents sprFirstRow As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdateExcel As Button
    Friend WithEvents tblDismantleSC As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents pgbComplete As ProgressBar
    Friend WithEvents lblMessage As Label
    Friend WithEvents clmErrorD As DataGridViewTextBoxColumn
    Friend WithEvents clmTagID As DataGridViewTextBoxColumn
    Friend WithEvents clmWorkNum As DataGridViewTextBoxColumn
    Friend WithEvents ReqComp As DataGridViewTextBoxColumn
    Friend WithEvents RequestBy As DataGridViewTextBoxColumn
    Friend WithEvents Foreman As DataGridViewTextBoxColumn
    Friend WithEvents Erector As DataGridViewTextBoxColumn
    Friend WithEvents RentStopDate As DataGridViewTextBoxColumn
    Friend WithEvents DismantleDate As DataGridViewTextBoxColumn
    Friend WithEvents Truck As DataGridViewCheckBoxColumn
    Friend WithEvents Forklift As DataGridViewCheckBoxColumn
    Friend WithEvents Trailer As DataGridViewCheckBoxColumn
    Friend WithEvents Crane As DataGridViewCheckBoxColumn
    Friend WithEvents Rope As DataGridViewCheckBoxColumn
    Friend WithEvents Passed As DataGridViewCheckBoxColumn
    Friend WithEvents Elevator As DataGridViewCheckBoxColumn
    Friend WithEvents Dismantle As DataGridViewTextBoxColumn
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Travel As DataGridViewTextBoxColumn
    Friend WithEvents Weather As DataGridViewTextBoxColumn
    Friend WithEvents Alarm As DataGridViewTextBoxColumn
    Friend WithEvents Safety As DataGridViewTextBoxColumn
    Friend WithEvents stdBY As DataGridViewTextBoxColumn
    Friend WithEvents Other As DataGridViewTextBoxColumn
    Friend WithEvents TotalHours As DataGridViewTextBoxColumn
    Friend WithEvents Comments As DataGridViewTextBoxColumn
    Public WithEvents txtFecha As TextBox
End Class
