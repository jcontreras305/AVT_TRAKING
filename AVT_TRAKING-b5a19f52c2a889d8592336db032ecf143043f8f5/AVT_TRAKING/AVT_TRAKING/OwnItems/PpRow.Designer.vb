<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PpRow
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
    'No lo modifique connSQL el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlyMain = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.chbST = New System.Windows.Forms.CheckBox()
        Me.btnRow = New System.Windows.Forms.Button()
        Me.txtIdPpDrawing = New System.Windows.Forms.TextBox()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.txtThick = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lytII = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbLaborRateII = New AVT_TRAKING.MyComboBox()
        Me.txtLFtII = New System.Windows.Forms.TextBox()
        Me.txt90II = New System.Windows.Forms.TextBox()
        Me.txt45II = New System.Windows.Forms.TextBox()
        Me.txtBendII = New System.Windows.Forms.TextBox()
        Me.txtTeeII = New System.Windows.Forms.TextBox()
        Me.txtReductII = New System.Windows.Forms.TextBox()
        Me.txtCapsII = New System.Windows.Forms.TextBox()
        Me.txtPairII = New System.Windows.Forms.TextBox()
        Me.txtValveII = New System.Windows.Forms.TextBox()
        Me.txtControlII = New System.Windows.Forms.TextBox()
        Me.txtWeldII = New System.Windows.Forms.TextBox()
        Me.txtCutoutII = New System.Windows.Forms.TextBox()
        Me.txtSupportII = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lytPnt = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLFtPnt = New System.Windows.Forms.TextBox()
        Me.txt90Pnt = New System.Windows.Forms.TextBox()
        Me.txt45Pnt = New System.Windows.Forms.TextBox()
        Me.txtTeePnt = New System.Windows.Forms.TextBox()
        Me.txtPairPnt = New System.Windows.Forms.TextBox()
        Me.txtValvePnt = New System.Windows.Forms.TextBox()
        Me.txtControlPnt = New System.Windows.Forms.TextBox()
        Me.txtWeldPnt = New System.Windows.Forms.TextBox()
        Me.cmbLaborRatePnt = New AVT_TRAKING.MyComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lytRmv = New System.Windows.Forms.TableLayoutPanel()
        Me.txtLFtRmv = New System.Windows.Forms.TextBox()
        Me.chbAcm = New System.Windows.Forms.CheckBox()
        Me.cmbLaborRateRmv = New AVT_TRAKING.MyComboBox()
        Me.cmbSystem = New AVT_TRAKING.MyComboBox()
        Me.cmbPaintOption = New AVT_TRAKING.MyComboBox()
        Me.cmbInsType = New AVT_TRAKING.MyComboBox()
        Me.cmbJacked = New AVT_TRAKING.MyComboBox()
        Me.cmbHeight = New AVT_TRAKING.MyComboBox()
        Me.tlyMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.lytII.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.lytPnt.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.lytRmv.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlyMain
        '
        Me.tlyMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tlyMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tlyMain.ColumnCount = 11
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.429679!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.644518!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.920333!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.7141!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.483616!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.263153!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.69987!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.932458!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.152921!))
        Me.tlyMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.65007!))
        Me.tlyMain.Controls.Add(Me.Panel1, 3, 0)
        Me.tlyMain.Controls.Add(Me.btnRow, 0, 0)
        Me.tlyMain.Controls.Add(Me.txtIdPpDrawing, 1, 0)
        Me.tlyMain.Controls.Add(Me.txtLine, 2, 0)
        Me.tlyMain.Controls.Add(Me.txtThick, 7, 0)
        Me.tlyMain.Controls.Add(Me.TableLayoutPanel1, 10, 0)
        Me.tlyMain.Controls.Add(Me.cmbSystem, 4, 0)
        Me.tlyMain.Controls.Add(Me.cmbPaintOption, 5, 0)
        Me.tlyMain.Controls.Add(Me.cmbInsType, 6, 0)
        Me.tlyMain.Controls.Add(Me.cmbJacked, 8, 0)
        Me.tlyMain.Controls.Add(Me.cmbHeight, 9, 0)
        Me.tlyMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlyMain.Location = New System.Drawing.Point(0, 0)
        Me.tlyMain.Name = "tlyMain"
        Me.tlyMain.RowCount = 1
        Me.tlyMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlyMain.Size = New System.Drawing.Size(925, 148)
        Me.tlyMain.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSize)
        Me.Panel1.Controls.Add(Me.chbST)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(123, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(41, 144)
        Me.Panel1.TabIndex = 13
        '
        'txtSize
        '
        Me.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSize.Location = New System.Drawing.Point(0, 0)
        Me.txtSize.Multiline = True
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(41, 113)
        Me.txtSize.TabIndex = 5
        Me.txtSize.Text = "0"
        '
        'chbST
        '
        Me.chbST.AutoSize = True
        Me.chbST.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chbST.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chbST.Location = New System.Drawing.Point(0, 113)
        Me.chbST.Name = "chbST"
        Me.chbST.Size = New System.Drawing.Size(41, 31)
        Me.chbST.TabIndex = 6
        Me.chbST.Text = "ST"
        Me.chbST.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chbST.UseVisualStyleBackColor = True
        '
        'btnRow
        '
        Me.btnRow.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnRow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRow.FlatAppearance.BorderSize = 0
        Me.btnRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRow.Location = New System.Drawing.Point(4, 4)
        Me.btnRow.Name = "btnRow"
        Me.btnRow.Size = New System.Drawing.Size(14, 140)
        Me.btnRow.TabIndex = 0
        Me.btnRow.Text = ">"
        Me.btnRow.UseVisualStyleBackColor = False
        '
        'txtIdPpDrawing
        '
        Me.txtIdPpDrawing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIdPpDrawing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIdPpDrawing.Location = New System.Drawing.Point(25, 4)
        Me.txtIdPpDrawing.Multiline = True
        Me.txtIdPpDrawing.Name = "txtIdPpDrawing"
        Me.txtIdPpDrawing.Size = New System.Drawing.Size(33, 140)
        Me.txtIdPpDrawing.TabIndex = 1
        Me.txtIdPpDrawing.Text = "NULL"
        '
        'txtLine
        '
        Me.txtLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLine.Location = New System.Drawing.Point(65, 4)
        Me.txtLine.Multiline = True
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(53, 140)
        Me.txtLine.TabIndex = 2
        '
        'txtThick
        '
        Me.txtThick.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtThick.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtThick.Location = New System.Drawing.Point(344, 4)
        Me.txtThick.Multiline = True
        Me.txtThick.Name = "txtThick"
        Me.txtThick.Size = New System.Drawing.Size(36, 140)
        Me.txtThick.TabIndex = 17
        Me.txtThick.Text = "0"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(497, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(424, 140)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Controls.Add(Me.lytII)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(1, 93)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(422, 46)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Insulation Instalation"
        '
        'lytII
        '
        Me.lytII.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lytII.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.lytII.ColumnCount = 14
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692994!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.690018!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.690018!))
        Me.lytII.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.690018!))
        Me.lytII.Controls.Add(Me.cmbLaborRateII, 0, 0)
        Me.lytII.Controls.Add(Me.txtLFtII, 1, 0)
        Me.lytII.Controls.Add(Me.txt90II, 2, 0)
        Me.lytII.Controls.Add(Me.txt45II, 3, 0)
        Me.lytII.Controls.Add(Me.txtBendII, 4, 0)
        Me.lytII.Controls.Add(Me.txtTeeII, 5, 0)
        Me.lytII.Controls.Add(Me.txtReductII, 6, 0)
        Me.lytII.Controls.Add(Me.txtCapsII, 7, 0)
        Me.lytII.Controls.Add(Me.txtPairII, 8, 0)
        Me.lytII.Controls.Add(Me.txtValveII, 9, 0)
        Me.lytII.Controls.Add(Me.txtControlII, 10, 0)
        Me.lytII.Controls.Add(Me.txtWeldII, 11, 0)
        Me.lytII.Controls.Add(Me.txtCutoutII, 12, 0)
        Me.lytII.Controls.Add(Me.txtSupportII, 13, 0)
        Me.lytII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lytII.Location = New System.Drawing.Point(3, 13)
        Me.lytII.Name = "lytII"
        Me.lytII.RowCount = 1
        Me.lytII.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.lytII.Size = New System.Drawing.Size(416, 30)
        Me.lytII.TabIndex = 0
        '
        'cmbLaborRateII
        '
        Me.cmbLaborRateII.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbLaborRateII.ArrowPersonalized = False
        Me.cmbLaborRateII.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbLaborRateII.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbLaborRateII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLaborRateII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.cmbLaborRateII.FormattingEnabled = True
        Me.cmbLaborRateII.Location = New System.Drawing.Point(4, 4)
        Me.cmbLaborRateII.Name = "cmbLaborRateII"
        Me.cmbLaborRateII.Size = New System.Drawing.Size(66, 21)
        Me.cmbLaborRateII.SizeHeight = 21
        Me.cmbLaborRateII.TabIndex = 41
        '
        'txtLFtII
        '
        Me.txtLFtII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLFtII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLFtII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtLFtII.Location = New System.Drawing.Point(76, 3)
        Me.txtLFtII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLFtII.Multiline = True
        Me.txtLFtII.Name = "txtLFtII"
        Me.txtLFtII.Size = New System.Drawing.Size(21, 24)
        Me.txtLFtII.TabIndex = 28
        Me.txtLFtII.Text = "0"
        '
        'txt90II
        '
        Me.txt90II.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt90II.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt90II.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt90II.Location = New System.Drawing.Point(102, 3)
        Me.txt90II.Margin = New System.Windows.Forms.Padding(2)
        Me.txt90II.Multiline = True
        Me.txt90II.Name = "txt90II"
        Me.txt90II.Size = New System.Drawing.Size(21, 24)
        Me.txt90II.TabIndex = 29
        Me.txt90II.Text = "0"
        '
        'txt45II
        '
        Me.txt45II.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt45II.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt45II.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt45II.Location = New System.Drawing.Point(128, 3)
        Me.txt45II.Margin = New System.Windows.Forms.Padding(2)
        Me.txt45II.Multiline = True
        Me.txt45II.Name = "txt45II"
        Me.txt45II.Size = New System.Drawing.Size(21, 24)
        Me.txt45II.TabIndex = 30
        Me.txt45II.Text = "0"
        '
        'txtBendII
        '
        Me.txtBendII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBendII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBendII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtBendII.Location = New System.Drawing.Point(154, 3)
        Me.txtBendII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBendII.Multiline = True
        Me.txtBendII.Name = "txtBendII"
        Me.txtBendII.Size = New System.Drawing.Size(21, 24)
        Me.txtBendII.TabIndex = 31
        Me.txtBendII.Text = "0"
        '
        'txtTeeII
        '
        Me.txtTeeII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTeeII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTeeII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtTeeII.Location = New System.Drawing.Point(180, 3)
        Me.txtTeeII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTeeII.Multiline = True
        Me.txtTeeII.Name = "txtTeeII"
        Me.txtTeeII.Size = New System.Drawing.Size(21, 24)
        Me.txtTeeII.TabIndex = 32
        Me.txtTeeII.Text = "0"
        '
        'txtReductII
        '
        Me.txtReductII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReductII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtReductII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtReductII.Location = New System.Drawing.Point(206, 3)
        Me.txtReductII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtReductII.Multiline = True
        Me.txtReductII.Name = "txtReductII"
        Me.txtReductII.Size = New System.Drawing.Size(21, 24)
        Me.txtReductII.TabIndex = 33
        Me.txtReductII.Text = "0"
        '
        'txtCapsII
        '
        Me.txtCapsII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCapsII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCapsII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtCapsII.Location = New System.Drawing.Point(232, 3)
        Me.txtCapsII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCapsII.Multiline = True
        Me.txtCapsII.Name = "txtCapsII"
        Me.txtCapsII.Size = New System.Drawing.Size(21, 24)
        Me.txtCapsII.TabIndex = 34
        Me.txtCapsII.Text = "0"
        '
        'txtPairII
        '
        Me.txtPairII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPairII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPairII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtPairII.Location = New System.Drawing.Point(258, 3)
        Me.txtPairII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPairII.Multiline = True
        Me.txtPairII.Name = "txtPairII"
        Me.txtPairII.Size = New System.Drawing.Size(21, 24)
        Me.txtPairII.TabIndex = 35
        Me.txtPairII.Text = "0"
        '
        'txtValveII
        '
        Me.txtValveII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValveII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValveII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtValveII.Location = New System.Drawing.Point(284, 3)
        Me.txtValveII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtValveII.Multiline = True
        Me.txtValveII.Name = "txtValveII"
        Me.txtValveII.Size = New System.Drawing.Size(21, 24)
        Me.txtValveII.TabIndex = 36
        Me.txtValveII.Text = "0"
        '
        'txtControlII
        '
        Me.txtControlII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtControlII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtControlII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtControlII.Location = New System.Drawing.Point(310, 3)
        Me.txtControlII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtControlII.Multiline = True
        Me.txtControlII.Name = "txtControlII"
        Me.txtControlII.Size = New System.Drawing.Size(21, 24)
        Me.txtControlII.TabIndex = 37
        Me.txtControlII.Text = "0"
        '
        'txtWeldII
        '
        Me.txtWeldII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWeldII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWeldII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtWeldII.Location = New System.Drawing.Point(336, 3)
        Me.txtWeldII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWeldII.Multiline = True
        Me.txtWeldII.Name = "txtWeldII"
        Me.txtWeldII.Size = New System.Drawing.Size(21, 24)
        Me.txtWeldII.TabIndex = 38
        Me.txtWeldII.Text = "0"
        '
        'txtCutoutII
        '
        Me.txtCutoutII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCutoutII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCutoutII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtCutoutII.Location = New System.Drawing.Point(362, 3)
        Me.txtCutoutII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCutoutII.Multiline = True
        Me.txtCutoutII.Name = "txtCutoutII"
        Me.txtCutoutII.Size = New System.Drawing.Size(21, 24)
        Me.txtCutoutII.TabIndex = 39
        Me.txtCutoutII.Text = "0"
        '
        'txtSupportII
        '
        Me.txtSupportII.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSupportII.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSupportII.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtSupportII.Location = New System.Drawing.Point(388, 3)
        Me.txtSupportII.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSupportII.Multiline = True
        Me.txtSupportII.Name = "txtSupportII"
        Me.txtSupportII.Size = New System.Drawing.Size(25, 24)
        Me.txtSupportII.TabIndex = 40
        Me.txtSupportII.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Controls.Add(Me.lytPnt)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 47)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(422, 44)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paint"
        '
        'lytPnt
        '
        Me.lytPnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lytPnt.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.lytPnt.ColumnCount = 12
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38142!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.693018!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38142!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.lytPnt.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.lytPnt.Controls.Add(Me.txtLFtPnt, 1, 0)
        Me.lytPnt.Controls.Add(Me.txt90Pnt, 2, 0)
        Me.lytPnt.Controls.Add(Me.txt45Pnt, 3, 0)
        Me.lytPnt.Controls.Add(Me.txtTeePnt, 5, 0)
        Me.lytPnt.Controls.Add(Me.txtPairPnt, 7, 0)
        Me.lytPnt.Controls.Add(Me.txtValvePnt, 8, 0)
        Me.lytPnt.Controls.Add(Me.txtControlPnt, 9, 0)
        Me.lytPnt.Controls.Add(Me.txtWeldPnt, 10, 0)
        Me.lytPnt.Controls.Add(Me.cmbLaborRatePnt, 0, 0)
        Me.lytPnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lytPnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lytPnt.Location = New System.Drawing.Point(3, 13)
        Me.lytPnt.Name = "lytPnt"
        Me.lytPnt.RowCount = 1
        Me.lytPnt.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.lytPnt.Size = New System.Drawing.Size(416, 28)
        Me.lytPnt.TabIndex = 0
        '
        'txtLFtPnt
        '
        Me.txtLFtPnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLFtPnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLFtPnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtLFtPnt.Location = New System.Drawing.Point(76, 3)
        Me.txtLFtPnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLFtPnt.Multiline = True
        Me.txtLFtPnt.Name = "txtLFtPnt"
        Me.txtLFtPnt.Size = New System.Drawing.Size(21, 22)
        Me.txtLFtPnt.TabIndex = 19
        Me.txtLFtPnt.Text = "0"
        '
        'txt90Pnt
        '
        Me.txt90Pnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt90Pnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt90Pnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt90Pnt.Location = New System.Drawing.Point(102, 3)
        Me.txt90Pnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txt90Pnt.Multiline = True
        Me.txt90Pnt.Name = "txt90Pnt"
        Me.txt90Pnt.Size = New System.Drawing.Size(21, 22)
        Me.txt90Pnt.TabIndex = 20
        Me.txt90Pnt.Text = "0"
        '
        'txt45Pnt
        '
        Me.txt45Pnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt45Pnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt45Pnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txt45Pnt.Location = New System.Drawing.Point(128, 3)
        Me.txt45Pnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txt45Pnt.Multiline = True
        Me.txt45Pnt.Name = "txt45Pnt"
        Me.txt45Pnt.Size = New System.Drawing.Size(21, 22)
        Me.txt45Pnt.TabIndex = 21
        Me.txt45Pnt.Text = "0"
        '
        'txtTeePnt
        '
        Me.txtTeePnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTeePnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTeePnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtTeePnt.Location = New System.Drawing.Point(180, 3)
        Me.txtTeePnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTeePnt.Multiline = True
        Me.txtTeePnt.Name = "txtTeePnt"
        Me.txtTeePnt.Size = New System.Drawing.Size(21, 22)
        Me.txtTeePnt.TabIndex = 22
        Me.txtTeePnt.Text = "0"
        '
        'txtPairPnt
        '
        Me.txtPairPnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPairPnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPairPnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtPairPnt.Location = New System.Drawing.Point(257, 3)
        Me.txtPairPnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPairPnt.Multiline = True
        Me.txtPairPnt.Name = "txtPairPnt"
        Me.txtPairPnt.Size = New System.Drawing.Size(21, 22)
        Me.txtPairPnt.TabIndex = 23
        Me.txtPairPnt.Text = "0"
        '
        'txtValvePnt
        '
        Me.txtValvePnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValvePnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValvePnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtValvePnt.Location = New System.Drawing.Point(283, 3)
        Me.txtValvePnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtValvePnt.Multiline = True
        Me.txtValvePnt.Name = "txtValvePnt"
        Me.txtValvePnt.Size = New System.Drawing.Size(21, 22)
        Me.txtValvePnt.TabIndex = 24
        Me.txtValvePnt.Text = "0"
        '
        'txtControlPnt
        '
        Me.txtControlPnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtControlPnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtControlPnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtControlPnt.Location = New System.Drawing.Point(309, 3)
        Me.txtControlPnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtControlPnt.Multiline = True
        Me.txtControlPnt.Name = "txtControlPnt"
        Me.txtControlPnt.Size = New System.Drawing.Size(21, 22)
        Me.txtControlPnt.TabIndex = 25
        Me.txtControlPnt.Text = "0"
        '
        'txtWeldPnt
        '
        Me.txtWeldPnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWeldPnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWeldPnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtWeldPnt.Location = New System.Drawing.Point(335, 3)
        Me.txtWeldPnt.Margin = New System.Windows.Forms.Padding(2)
        Me.txtWeldPnt.Multiline = True
        Me.txtWeldPnt.Name = "txtWeldPnt"
        Me.txtWeldPnt.Size = New System.Drawing.Size(21, 22)
        Me.txtWeldPnt.TabIndex = 26
        Me.txtWeldPnt.Text = "0"
        '
        'cmbLaborRatePnt
        '
        Me.cmbLaborRatePnt.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbLaborRatePnt.ArrowPersonalized = False
        Me.cmbLaborRatePnt.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbLaborRatePnt.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbLaborRatePnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLaborRatePnt.FormattingEnabled = True
        Me.cmbLaborRatePnt.Location = New System.Drawing.Point(4, 4)
        Me.cmbLaborRatePnt.Name = "cmbLaborRatePnt"
        Me.cmbLaborRatePnt.Size = New System.Drawing.Size(66, 21)
        Me.cmbLaborRatePnt.SizeHeight = 21
        Me.cmbLaborRatePnt.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Controls.Add(Me.lytRmv)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(422, 44)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insulation Removal"
        '
        'lytRmv
        '
        Me.lytRmv.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lytRmv.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.lytRmv.ColumnCount = 4
        Me.lytRmv.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.lytRmv.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.69!))
        Me.lytRmv.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38!))
        Me.lytRmv.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.93!))
        Me.lytRmv.Controls.Add(Me.txtLFtRmv, 1, 0)
        Me.lytRmv.Controls.Add(Me.chbAcm, 2, 0)
        Me.lytRmv.Controls.Add(Me.cmbLaborRateRmv, 0, 0)
        Me.lytRmv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lytRmv.Location = New System.Drawing.Point(3, 13)
        Me.lytRmv.Margin = New System.Windows.Forms.Padding(2)
        Me.lytRmv.Name = "lytRmv"
        Me.lytRmv.RowCount = 1
        Me.lytRmv.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.lytRmv.Size = New System.Drawing.Size(416, 28)
        Me.lytRmv.TabIndex = 0
        '
        'txtLFtRmv
        '
        Me.txtLFtRmv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLFtRmv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLFtRmv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtLFtRmv.Location = New System.Drawing.Point(76, 3)
        Me.txtLFtRmv.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLFtRmv.Multiline = True
        Me.txtLFtRmv.Name = "txtLFtRmv"
        Me.txtLFtRmv.Size = New System.Drawing.Size(22, 22)
        Me.txtLFtRmv.TabIndex = 15
        Me.txtLFtRmv.Text = "0"
        '
        'chbAcm
        '
        Me.chbAcm.AutoSize = True
        Me.chbAcm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chbAcm.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.chbAcm.Location = New System.Drawing.Point(103, 3)
        Me.chbAcm.Margin = New System.Windows.Forms.Padding(2)
        Me.chbAcm.Name = "chbAcm"
        Me.chbAcm.Size = New System.Drawing.Size(48, 22)
        Me.chbAcm.TabIndex = 16
        Me.chbAcm.Text = "ACM"
        Me.chbAcm.UseVisualStyleBackColor = True
        '
        'cmbLaborRateRmv
        '
        Me.cmbLaborRateRmv.ArrowColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.cmbLaborRateRmv.ArrowPersonalized = False
        Me.cmbLaborRateRmv.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbLaborRateRmv.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbLaborRateRmv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbLaborRateRmv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.cmbLaborRateRmv.FormattingEnabled = True
        Me.cmbLaborRateRmv.Location = New System.Drawing.Point(4, 4)
        Me.cmbLaborRateRmv.Name = "cmbLaborRateRmv"
        Me.cmbLaborRateRmv.Size = New System.Drawing.Size(66, 21)
        Me.cmbLaborRateRmv.SizeHeight = 21
        Me.cmbLaborRateRmv.TabIndex = 17
        '
        'cmbSystem
        '
        Me.cmbSystem.ArrowColor = System.Drawing.Color.Silver
        Me.cmbSystem.ArrowPersonalized = False
        Me.cmbSystem.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbSystem.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbSystem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbSystem.FormattingEnabled = True
        Me.cmbSystem.Location = New System.Drawing.Point(169, 4)
        Me.cmbSystem.Name = "cmbSystem"
        Me.cmbSystem.Size = New System.Drawing.Size(54, 21)
        Me.cmbSystem.SizeHeight = 21
        Me.cmbSystem.TabIndex = 21
        '
        'cmbPaintOption
        '
        Me.cmbPaintOption.ArrowColor = System.Drawing.Color.Silver
        Me.cmbPaintOption.ArrowPersonalized = False
        Me.cmbPaintOption.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbPaintOption.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbPaintOption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPaintOption.FormattingEnabled = True
        Me.cmbPaintOption.Location = New System.Drawing.Point(230, 4)
        Me.cmbPaintOption.Name = "cmbPaintOption"
        Me.cmbPaintOption.Size = New System.Drawing.Size(51, 21)
        Me.cmbPaintOption.SizeHeight = 21
        Me.cmbPaintOption.TabIndex = 22
        '
        'cmbInsType
        '
        Me.cmbInsType.ArrowColor = System.Drawing.Color.Silver
        Me.cmbInsType.ArrowPersonalized = False
        Me.cmbInsType.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbInsType.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbInsType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbInsType.FormattingEnabled = True
        Me.cmbInsType.Location = New System.Drawing.Point(288, 4)
        Me.cmbInsType.Name = "cmbInsType"
        Me.cmbInsType.Size = New System.Drawing.Size(49, 21)
        Me.cmbInsType.SizeHeight = 21
        Me.cmbInsType.TabIndex = 23
        '
        'cmbJacked
        '
        Me.cmbJacked.ArrowColor = System.Drawing.Color.Silver
        Me.cmbJacked.ArrowPersonalized = False
        Me.cmbJacked.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbJacked.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbJacked.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbJacked.FormattingEnabled = True
        Me.cmbJacked.Location = New System.Drawing.Point(387, 4)
        Me.cmbJacked.Name = "cmbJacked"
        Me.cmbJacked.Size = New System.Drawing.Size(47, 21)
        Me.cmbJacked.SizeHeight = 21
        Me.cmbJacked.TabIndex = 24
        '
        'cmbHeight
        '
        Me.cmbHeight.ArrowColor = System.Drawing.Color.Silver
        Me.cmbHeight.ArrowPersonalized = False
        Me.cmbHeight.ArrowStyle = AVT_TRAKING.MyComboBox.enumArrowStyle.Arrow3D
        Me.cmbHeight.BorderColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbHeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbHeight.FormattingEnabled = True
        Me.cmbHeight.Location = New System.Drawing.Point(441, 4)
        Me.cmbHeight.Name = "cmbHeight"
        Me.cmbHeight.Size = New System.Drawing.Size(49, 21)
        Me.cmbHeight.SizeHeight = 21
        Me.cmbHeight.TabIndex = 25
        '
        'PpRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlyMain)
        Me.Name = "PpRow"
        Me.Size = New System.Drawing.Size(925, 148)
        Me.tlyMain.ResumeLayout(False)
        Me.tlyMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.lytII.ResumeLayout(False)
        Me.lytII.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.lytPnt.ResumeLayout(False)
        Me.lytPnt.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.lytRmv.ResumeLayout(False)
        Me.lytRmv.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlyMain As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSize As TextBox
    Friend WithEvents chbST As CheckBox
    Friend WithEvents btnRow As Button
    Friend WithEvents txtIdPpDrawing As TextBox
    Friend WithEvents txtLine As TextBox
    Friend WithEvents txtThick As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lytII As TableLayoutPanel
    Friend WithEvents txtLFtII As TextBox
    Friend WithEvents txt90II As TextBox
    Friend WithEvents txt45II As TextBox
    Friend WithEvents txtBendII As TextBox
    Friend WithEvents txtTeeII As TextBox
    Friend WithEvents txtReductII As TextBox
    Friend WithEvents txtCapsII As TextBox
    Friend WithEvents txtPairII As TextBox
    Friend WithEvents txtValveII As TextBox
    Friend WithEvents txtControlII As TextBox
    Friend WithEvents txtWeldII As TextBox
    Friend WithEvents txtCutoutII As TextBox
    Friend WithEvents txtSupportII As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lytPnt As TableLayoutPanel
    Friend WithEvents txtLFtPnt As TextBox
    Friend WithEvents txt90Pnt As TextBox
    Friend WithEvents txt45Pnt As TextBox
    Friend WithEvents txtTeePnt As TextBox
    Friend WithEvents txtPairPnt As TextBox
    Friend WithEvents txtValvePnt As TextBox
    Friend WithEvents txtControlPnt As TextBox
    Friend WithEvents txtWeldPnt As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lytRmv As TableLayoutPanel
    Friend WithEvents txtLFtRmv As TextBox
    Friend WithEvents chbAcm As CheckBox
    Friend WithEvents cmbSystem As MyComboBox
    Friend WithEvents cmbPaintOption As MyComboBox
    Friend WithEvents cmbInsType As MyComboBox
    Friend WithEvents cmbJacked As MyComboBox
    Friend WithEvents cmbHeight As MyComboBox
    Friend WithEvents cmbLaborRateII As MyComboBox
    Friend WithEvents cmbLaborRatePnt As MyComboBox
    Friend WithEvents cmbLaborRateRmv As MyComboBox
End Class
