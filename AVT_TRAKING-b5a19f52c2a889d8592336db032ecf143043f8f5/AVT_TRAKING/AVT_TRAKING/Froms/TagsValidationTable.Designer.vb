<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagsValidationTable
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblTagsScaffold = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSubirExcel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.rowError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TagNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jobCat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AreaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateBuild = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porpuse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Length = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Heigth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Decks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Base = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CSAP = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rolling = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Internal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Hanging = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Truck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Forklift = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Trailer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Crane = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Rope = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Passed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Elevator = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ReqComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Foreman = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Erector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Build = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Travel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Weather = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alarm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Safety = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stdBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Other = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.tblTagsScaffold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 450)
        Me.Panel1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tblTagsScaffold, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMessage, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 450)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'tblTagsScaffold
        '
        Me.tblTagsScaffold.AllowUserToAddRows = False
        Me.tblTagsScaffold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.tblTagsScaffold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblTagsScaffold.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rowError, Me.TagNum, Me.jobCat, Me.AreaID, Me.WorkNum, Me.SubJob, Me.DateBuild, Me.Location, Me.Porpuse, Me.Type, Me.Width, Me.Length, Me.Heigth, Me.Decks, Me.KO, Me.Base, Me.CSAP, Me.Rolling, Me.Internal, Me.Hanging, Me.Truck, Me.Forklift, Me.Trailer, Me.Crane, Me.Rope, Me.Passed, Me.Elevator, Me.ReqComp, Me.RequestBy, Me.Foreman, Me.Erector, Me.Build, Me.Material, Me.Travel, Me.Weather, Me.Alarm, Me.Safety, Me.stdBy, Me.Other, Me.TotalHours, Me.Comment})
        Me.tblTagsScaffold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTagsScaffold.Location = New System.Drawing.Point(3, 89)
        Me.tblTagsScaffold.Name = "tblTagsScaffold"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tblTagsScaffold.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.tblTagsScaffold.Size = New System.Drawing.Size(794, 338)
        Me.tblTagsScaffold.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnSubirExcel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(794, 80)
        Me.Panel2.TabIndex = 1
        '
        'btnSubirExcel
        '
        Me.btnSubirExcel.Location = New System.Drawing.Point(561, 25)
        Me.btnSubirExcel.Name = "btnSubirExcel"
        Me.btnSubirExcel.Size = New System.Drawing.Size(103, 31)
        Me.btnSubirExcel.TabIndex = 1
        Me.btnSubirExcel.Text = "Update Excel"
        Me.btnSubirExcel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(682, 25)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(103, 31)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Location = New System.Drawing.Point(3, 430)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(794, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Message:"
        '
        'rowError
        '
        Me.rowError.HeaderText = "rowError"
        Me.rowError.Name = "rowError"
        Me.rowError.Visible = False
        Me.rowError.Width = 71
        '
        'TagNum
        '
        Me.TagNum.HeaderText = "TagNum"
        Me.TagNum.Name = "TagNum"
        Me.TagNum.Width = 73
        '
        'jobCat
        '
        Me.jobCat.HeaderText = "JobCat"
        Me.jobCat.Name = "jobCat"
        Me.jobCat.Width = 65
        '
        'AreaID
        '
        Me.AreaID.HeaderText = "AreaID"
        Me.AreaID.Name = "AreaID"
        Me.AreaID.Width = 65
        '
        'WorkNum
        '
        Me.WorkNum.HeaderText = "WorkNum"
        Me.WorkNum.Name = "WorkNum"
        Me.WorkNum.Width = 80
        '
        'SubJob
        '
        Me.SubJob.HeaderText = "SubJob"
        Me.SubJob.Name = "SubJob"
        Me.SubJob.Width = 68
        '
        'DateBuild
        '
        Me.DateBuild.HeaderText = "DateBuild"
        Me.DateBuild.Name = "DateBuild"
        Me.DateBuild.Width = 78
        '
        'Location
        '
        Me.Location.HeaderText = "Location"
        Me.Location.Name = "Location"
        Me.Location.Width = 73
        '
        'Porpuse
        '
        Me.Porpuse.HeaderText = "Porpuse"
        Me.Porpuse.Name = "Porpuse"
        Me.Porpuse.Width = 71
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.Width = 56
        '
        'Width
        '
        Me.Width.HeaderText = "Width"
        Me.Width.Name = "Width"
        Me.Width.Width = 60
        '
        'Length
        '
        Me.Length.HeaderText = "Length"
        Me.Length.Name = "Length"
        Me.Length.Width = 65
        '
        'Heigth
        '
        Me.Heigth.HeaderText = "Heigth"
        Me.Heigth.Name = "Heigth"
        Me.Heigth.Width = 63
        '
        'Decks
        '
        Me.Decks.HeaderText = "Decks"
        Me.Decks.Name = "Decks"
        Me.Decks.Width = 63
        '
        'KO
        '
        Me.KO.HeaderText = "KO"
        Me.KO.Name = "KO"
        Me.KO.Width = 47
        '
        'Base
        '
        Me.Base.HeaderText = "Base"
        Me.Base.Name = "Base"
        Me.Base.Width = 56
        '
        'CSAP
        '
        Me.CSAP.HeaderText = "CSAP"
        Me.CSAP.Name = "CSAP"
        Me.CSAP.Width = 41
        '
        'Rolling
        '
        Me.Rolling.HeaderText = "Rolling"
        Me.Rolling.Name = "Rolling"
        Me.Rolling.Width = 45
        '
        'Internal
        '
        Me.Internal.HeaderText = "Internal"
        Me.Internal.Name = "Internal"
        Me.Internal.Width = 48
        '
        'Hanging
        '
        Me.Hanging.HeaderText = "Hanging"
        Me.Hanging.Name = "Hanging"
        Me.Hanging.Width = 53
        '
        'Truck
        '
        Me.Truck.HeaderText = "Truck"
        Me.Truck.Name = "Truck"
        Me.Truck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Truck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Truck.Width = 60
        '
        'Forklift
        '
        Me.Forklift.HeaderText = "Forklift"
        Me.Forklift.Name = "Forklift"
        Me.Forklift.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Forklift.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Forklift.Width = 63
        '
        'Trailer
        '
        Me.Trailer.HeaderText = "Trailer"
        Me.Trailer.Name = "Trailer"
        Me.Trailer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Trailer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Trailer.Width = 61
        '
        'Crane
        '
        Me.Crane.HeaderText = "Crane"
        Me.Crane.Name = "Crane"
        Me.Crane.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Crane.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Crane.Width = 60
        '
        'Rope
        '
        Me.Rope.HeaderText = "Rope"
        Me.Rope.Name = "Rope"
        Me.Rope.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Rope.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Rope.Width = 58
        '
        'Passed
        '
        Me.Passed.HeaderText = "Passed"
        Me.Passed.Name = "Passed"
        Me.Passed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Passed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Passed.Width = 67
        '
        'Elevator
        '
        Me.Elevator.HeaderText = "Elevator"
        Me.Elevator.Name = "Elevator"
        Me.Elevator.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Elevator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Elevator.Width = 71
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
        'Build
        '
        Me.Build.HeaderText = "Build"
        Me.Build.Name = "Build"
        Me.Build.Width = 55
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
        'stdBy
        '
        Me.stdBy.HeaderText = "stdBy"
        Me.stdBy.Name = "stdBy"
        Me.stdBy.Width = 58
        '
        'Other
        '
        Me.Other.HeaderText = "Other"
        Me.Other.Name = "Other"
        Me.Other.Width = 58
        '
        'TotalHours
        '
        Me.TotalHours.HeaderText = "Total Hours"
        Me.TotalHours.Name = "TotalHours"
        Me.TotalHours.Width = 87
        '
        'Comment
        '
        Me.Comment.HeaderText = "Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.Width = 76
        '
        'TagsValidationTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TagsValidationTable"
        Me.Text = "TagsValidationTable"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.tblTagsScaffold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents tblTagsScaffold As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnSubirExcel As Button
    Friend WithEvents lblMessage As Label
    Friend WithEvents rowError As DataGridViewTextBoxColumn
    Friend WithEvents TagNum As DataGridViewTextBoxColumn
    Friend WithEvents jobCat As DataGridViewTextBoxColumn
    Friend WithEvents AreaID As DataGridViewTextBoxColumn
    Friend WithEvents WorkNum As DataGridViewTextBoxColumn
    Friend WithEvents SubJob As DataGridViewTextBoxColumn
    Friend WithEvents DateBuild As DataGridViewTextBoxColumn
    Friend WithEvents Location As DataGridViewTextBoxColumn
    Friend WithEvents Porpuse As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Width As DataGridViewTextBoxColumn
    Friend WithEvents Length As DataGridViewTextBoxColumn
    Friend WithEvents Heigth As DataGridViewTextBoxColumn
    Friend WithEvents Decks As DataGridViewTextBoxColumn
    Friend WithEvents KO As DataGridViewTextBoxColumn
    Friend WithEvents Base As DataGridViewTextBoxColumn
    Friend WithEvents CSAP As DataGridViewCheckBoxColumn
    Friend WithEvents Rolling As DataGridViewCheckBoxColumn
    Friend WithEvents Internal As DataGridViewCheckBoxColumn
    Friend WithEvents Hanging As DataGridViewCheckBoxColumn
    Friend WithEvents Truck As DataGridViewCheckBoxColumn
    Friend WithEvents Forklift As DataGridViewCheckBoxColumn
    Friend WithEvents Trailer As DataGridViewCheckBoxColumn
    Friend WithEvents Crane As DataGridViewCheckBoxColumn
    Friend WithEvents Rope As DataGridViewCheckBoxColumn
    Friend WithEvents Passed As DataGridViewCheckBoxColumn
    Friend WithEvents Elevator As DataGridViewCheckBoxColumn
    Friend WithEvents ReqComp As DataGridViewTextBoxColumn
    Friend WithEvents RequestBy As DataGridViewTextBoxColumn
    Friend WithEvents Foreman As DataGridViewTextBoxColumn
    Friend WithEvents Erector As DataGridViewTextBoxColumn
    Friend WithEvents Build As DataGridViewTextBoxColumn
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Travel As DataGridViewTextBoxColumn
    Friend WithEvents Weather As DataGridViewTextBoxColumn
    Friend WithEvents Alarm As DataGridViewTextBoxColumn
    Friend WithEvents Safety As DataGridViewTextBoxColumn
    Friend WithEvents stdBy As DataGridViewTextBoxColumn
    Friend WithEvents Other As DataGridViewTextBoxColumn
    Friend WithEvents TotalHours As DataGridViewTextBoxColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
End Class
