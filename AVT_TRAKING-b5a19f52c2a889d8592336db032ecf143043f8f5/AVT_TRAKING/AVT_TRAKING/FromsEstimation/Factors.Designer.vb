<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Factors
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
    'No lo modifique connSQL el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnDropWWSLR = New System.Windows.Forms.Button()
        Me.btnSaveWWSLR = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.tblWorkWeekScheduleLaborRates = New System.Windows.Forms.DataGridView()
        Me.IdLaborRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InsulRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbatRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaintRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScafRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnExcelTblElevationPaint = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.tblPaintElevation = New System.Windows.Forms.DataGridView()
        Me.idElevationPaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElevationPaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Increment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnExcelTblElvationFactor = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.tblScafElevation = New System.Windows.Forms.DataGridView()
        Me.idElevationSCF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElevationSCF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncrementSCF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelScaffoldUnitRates = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.tblSCFUnitsRates = New System.Windows.Forms.DataGridView()
        Me.IdUnitRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionURSCF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuildPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LaborProdBuild = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialBuild = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentBuild = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DimantlePercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LaborProdDis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialDis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentDis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelSCFEnviroment = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.tblEnviroment = New System.Windows.Forms.DataGridView()
        Me.idEnviroment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enviroment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevitionDueDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelUpdatePpInsUR = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.tblPpInsUnitRate = New System.Windows.Forms.DataGridView()
        Me.idSizePpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTypePpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThickPpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizePpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typePpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thickPpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborProdPpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.matRatePpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eqRatePpIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelUpdateEqInsUR = New System.Windows.Forms.Button()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.tblEqInsUnitRate = New System.Windows.Forms.DataGridView()
        Me.idTypeEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThickEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typeEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThickEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborProdEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.matRateEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eqRateEQIUR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel18 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelJacketPp = New System.Windows.Forms.Button()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.tblJacketPp = New System.Windows.Forms.DataGridView()
        Me.idJacketPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JacketTypePp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jacketNamePp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborProdJckPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.matFactorJckPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eqFactorJckPp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel19 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelJacketEq = New System.Windows.Forms.Button()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.tblJacketEq = New System.Windows.Forms.DataGridView()
        Me.idJacket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JacketType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jacketName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborProdJckEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.matFactorJckEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eqFactorJckEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelPpPntUnitRate = New System.Windows.Forms.Button()
        Me.tblPpPaintUnitRate = New System.Windows.Forms.DataGridView()
        Me.systemPPId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionPPId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sizePPId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SystemPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.optionPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sizePP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborProdPP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.matRatePP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eqRatePP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelEqPntUnitRate = New System.Windows.Forms.Button()
        Me.tblEqPaintUnitRate = New System.Windows.Forms.DataGridView()
        Me.SystemEqId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptionEQId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SystemEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptionEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laborProdEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.materialRateEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eqRateEq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelInsFitting = New System.Windows.Forms.Button()
        Me.tblInsFitting = New System.Windows.Forms.DataGridView()
        Me.typeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Support = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p90 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlangePair = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlangeVlv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlVlv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeldVlv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bebel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelPnpFitting = New System.Windows.Forms.Button()
        Me.tblPntFitting = New System.Windows.Forms.DataGridView()
        Me.idOption = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaintOption = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p90p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p45p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEEp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlangePairp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlangeVlvp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlVlvp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WeldedVlvp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel21 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel22 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelPipingIRHC = New System.Windows.Forms.Button()
        Me.tblPipingIRHC = New System.Windows.Forms.DataGridView()
        Me.idSizePPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTypePPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThicknessPPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizePPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypePPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThicknessPPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LaborProdPPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialRatePPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentRatePPIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel23 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelEquipmentIRHC = New System.Windows.Forms.Button()
        Me.tblEquipmentIRHC = New System.Windows.Forms.DataGridView()
        Me.idTypeEqIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThickIEqRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeEqIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThicknessEqIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LaborProdEqIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialRateEqIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentEqIRHC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel20 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelPipingMaterial = New System.Windows.Forms.Button()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.tblPipingMaterial = New System.Windows.Forms.DataGridView()
        Me.idSizeMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTypeMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThickMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThickMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel24 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelTblEquipmentMaterial = New System.Windows.Forms.Button()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.tblEquipmentMaterial = New System.Windows.Forms.DataGridView()
        Me.idTypeEqMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThickEqMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeEqMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThickEqMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceEqMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionEqMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel25 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnExcelPPFittingMaterial = New System.Windows.Forms.Button()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.tblPPFittingMaterial = New System.Windows.Forms.DataGridView()
        Me.idSizePPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTypePPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idThickPPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idFittingPPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizePPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypePPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThickPPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FittingPPFM = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PricePPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionPPFM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnDeleteFactorTbl = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnSaveFactorTbl = New System.Windows.Forms.Button()
        Me.pgbProgress = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.tblWorkWeekScheduleLaborRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.tblPaintElevation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.tblScafElevation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.tblSCFUnitsRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.tblEnviroment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TableLayoutPanel14.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.TableLayoutPanel16.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.tblPpInsUnitRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        Me.TableLayoutPanel15.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.tblEqInsUnitRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.TableLayoutPanel17.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TableLayoutPanel18.SuspendLayout()
        Me.Panel15.SuspendLayout()
        CType(Me.tblJacketPp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.TableLayoutPanel19.SuspendLayout()
        Me.Panel16.SuspendLayout()
        CType(Me.tblJacketEq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        CType(Me.tblPpPaintUnitRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        CType(Me.tblEqPaintUnitRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        CType(Me.tblInsFitting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        CType(Me.tblPntFitting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        Me.TableLayoutPanel21.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.TableLayoutPanel22.SuspendLayout()
        CType(Me.tblPipingIRHC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox16.SuspendLayout()
        Me.TableLayoutPanel23.SuspendLayout()
        CType(Me.tblEquipmentIRHC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage10.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.TableLayoutPanel20.SuspendLayout()
        Me.Panel17.SuspendLayout()
        CType(Me.tblPipingMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage11.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.TableLayoutPanel24.SuspendLayout()
        Me.Panel18.SuspendLayout()
        CType(Me.tblEquipmentMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage12.SuspendLayout()
        Me.TableLayoutPanel25.SuspendLayout()
        Me.Panel19.SuspendLayout()
        CType(Me.tblPPFittingMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.67505!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.32495!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1299, 644)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1291, 78)
        Me.Panel1.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Red
        Me.btnSalir.Image = Global.AVT_TRAKING.My.Resources.Resources._exit
        Me.btnSalir.Location = New System.Drawing.Point(1223, 4)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(57, 68)
        Me.btnSalir.TabIndex = 33
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(21, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 25)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Factors"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(4, 90)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1291, 494)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TabControl1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.14141!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.85859!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1291, 494)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1283, 185)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Work Week Schedules And Labor Rates"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 617.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel10, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1275, 162)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnDropWWSLR)
        Me.Panel4.Controls.Add(Me.btnSaveWWSLR)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(621, 4)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(264, 154)
        Me.Panel4.TabIndex = 1
        '
        'btnDropWWSLR
        '
        Me.btnDropWWSLR.FlatAppearance.BorderSize = 0
        Me.btnDropWWSLR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnDropWWSLR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDropWWSLR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDropWWSLR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDropWWSLR.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDropWWSLR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDropWWSLR.Location = New System.Drawing.Point(20, 54)
        Me.btnDropWWSLR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDropWWSLR.Name = "btnDropWWSLR"
        Me.btnDropWWSLR.Size = New System.Drawing.Size(120, 43)
        Me.btnDropWWSLR.TabIndex = 30
        Me.btnDropWWSLR.Text = "Delete"
        Me.btnDropWWSLR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDropWWSLR.UseVisualStyleBackColor = True
        '
        'btnSaveWWSLR
        '
        Me.btnSaveWWSLR.FlatAppearance.BorderSize = 0
        Me.btnSaveWWSLR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnSaveWWSLR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveWWSLR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveWWSLR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSaveWWSLR.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSaveWWSLR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveWWSLR.Location = New System.Drawing.Point(20, 4)
        Me.btnSaveWWSLR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaveWWSLR.Name = "btnSaveWWSLR"
        Me.btnSaveWWSLR.Size = New System.Drawing.Size(120, 43)
        Me.btnSaveWWSLR.TabIndex = 29
        Me.btnSaveWWSLR.Text = "Save"
        Me.btnSaveWWSLR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveWWSLR.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.tblWorkWeekScheduleLaborRates)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel10.Location = New System.Drawing.Point(4, 4)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(609, 154)
        Me.Panel10.TabIndex = 2
        '
        'tblWorkWeekScheduleLaborRates
        '
        Me.tblWorkWeekScheduleLaborRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblWorkWeekScheduleLaborRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblWorkWeekScheduleLaborRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdLaborRate, Me.Description, Me.InsulRate, Me.AbatRate, Me.PaintRate, Me.ScafRate})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblWorkWeekScheduleLaborRates.DefaultCellStyle = DataGridViewCellStyle1
        Me.tblWorkWeekScheduleLaborRates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblWorkWeekScheduleLaborRates.Location = New System.Drawing.Point(0, 0)
        Me.tblWorkWeekScheduleLaborRates.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblWorkWeekScheduleLaborRates.Name = "tblWorkWeekScheduleLaborRates"
        Me.tblWorkWeekScheduleLaborRates.RowHeadersWidth = 51
        Me.tblWorkWeekScheduleLaborRates.Size = New System.Drawing.Size(609, 154)
        Me.tblWorkWeekScheduleLaborRates.TabIndex = 0
        '
        'IdLaborRate
        '
        Me.IdLaborRate.HeaderText = "IdLaborRate"
        Me.IdLaborRate.MinimumWidth = 6
        Me.IdLaborRate.Name = "IdLaborRate"
        Me.IdLaborRate.Visible = False
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.MinimumWidth = 6
        Me.Description.Name = "Description"
        '
        'InsulRate
        '
        Me.InsulRate.HeaderText = "Insul. Rate"
        Me.InsulRate.MinimumWidth = 6
        Me.InsulRate.Name = "InsulRate"
        '
        'AbatRate
        '
        Me.AbatRate.HeaderText = "Abat. Rate"
        Me.AbatRate.MinimumWidth = 6
        Me.AbatRate.Name = "AbatRate"
        '
        'PaintRate
        '
        Me.PaintRate.HeaderText = "Paint. Rate"
        Me.PaintRate.MinimumWidth = 6
        Me.PaintRate.Name = "PaintRate"
        '
        'ScafRate
        '
        Me.ScafRate.HeaderText = "Scaf. Rate"
        Me.ScafRate.MinimumWidth = 6
        Me.ScafRate.Name = "ScafRate"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Controls.Add(Me.TabPage10)
        Me.TabControl1.Controls.Add(Me.TabPage11)
        Me.TabControl1.Controls.Add(Me.TabPage12)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(4, 197)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1283, 293)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Elevation Factors"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(4, 4)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1267, 256)
        Me.Panel5.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox3, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1267, 256)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Location = New System.Drawing.Point(637, 4)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(626, 248)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Paint Elevation"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 279.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Panel7, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Panel9, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(618, 225)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnExcelTblElevationPaint)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(283, 4)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(331, 217)
        Me.Panel7.TabIndex = 1
        '
        'btnExcelTblElevationPaint
        '
        Me.btnExcelTblElevationPaint.FlatAppearance.BorderSize = 0
        Me.btnExcelTblElevationPaint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelTblElevationPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelTblElevationPaint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelTblElevationPaint.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelTblElevationPaint.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelTblElevationPaint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTblElevationPaint.Location = New System.Drawing.Point(4, 4)
        Me.btnExcelTblElevationPaint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelTblElevationPaint.Name = "btnExcelTblElevationPaint"
        Me.btnExcelTblElevationPaint.Size = New System.Drawing.Size(133, 43)
        Me.btnExcelTblElevationPaint.TabIndex = 33
        Me.btnExcelTblElevationPaint.Text = "Upload"
        Me.btnExcelTblElevationPaint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTblElevationPaint.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.tblPaintElevation)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel9.Location = New System.Drawing.Point(4, 4)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(271, 217)
        Me.Panel9.TabIndex = 2
        '
        'tblPaintElevation
        '
        Me.tblPaintElevation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPaintElevation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPaintElevation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idElevationPaint, Me.ElevationPaint, Me.Increment})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblPaintElevation.DefaultCellStyle = DataGridViewCellStyle2
        Me.tblPaintElevation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPaintElevation.Location = New System.Drawing.Point(0, 0)
        Me.tblPaintElevation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPaintElevation.Name = "tblPaintElevation"
        Me.tblPaintElevation.RowHeadersWidth = 51
        Me.tblPaintElevation.Size = New System.Drawing.Size(271, 217)
        Me.tblPaintElevation.TabIndex = 0
        '
        'idElevationPaint
        '
        Me.idElevationPaint.HeaderText = "idElevationPaint"
        Me.idElevationPaint.MinimumWidth = 6
        Me.idElevationPaint.Name = "idElevationPaint"
        Me.idElevationPaint.Visible = False
        '
        'ElevationPaint
        '
        Me.ElevationPaint.HeaderText = "Elevation"
        Me.ElevationPaint.MinimumWidth = 6
        Me.ElevationPaint.Name = "ElevationPaint"
        '
        'Increment
        '
        Me.Increment.HeaderText = "%Increment"
        Me.Increment.MinimumWidth = 6
        Me.Increment.Name = "Increment"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(625, 248)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scaffold Elevation"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Panel6, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Panel8, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(617, 225)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnExcelTblElvationFactor)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(291, 4)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(322, 217)
        Me.Panel6.TabIndex = 1
        '
        'btnExcelTblElvationFactor
        '
        Me.btnExcelTblElvationFactor.FlatAppearance.BorderSize = 0
        Me.btnExcelTblElvationFactor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelTblElvationFactor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelTblElvationFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelTblElvationFactor.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelTblElvationFactor.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelTblElvationFactor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTblElvationFactor.Location = New System.Drawing.Point(4, 4)
        Me.btnExcelTblElvationFactor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelTblElvationFactor.Name = "btnExcelTblElvationFactor"
        Me.btnExcelTblElvationFactor.Size = New System.Drawing.Size(133, 43)
        Me.btnExcelTblElvationFactor.TabIndex = 32
        Me.btnExcelTblElvationFactor.Text = "Upload"
        Me.btnExcelTblElvationFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTblElvationFactor.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.tblScafElevation)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel8.Location = New System.Drawing.Point(4, 4)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(279, 217)
        Me.Panel8.TabIndex = 2
        '
        'tblScafElevation
        '
        Me.tblScafElevation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblScafElevation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblScafElevation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idElevationSCF, Me.ElevationSCF, Me.IncrementSCF})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.tblScafElevation.DefaultCellStyle = DataGridViewCellStyle3
        Me.tblScafElevation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblScafElevation.Location = New System.Drawing.Point(0, 0)
        Me.tblScafElevation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblScafElevation.Name = "tblScafElevation"
        Me.tblScafElevation.RowHeadersWidth = 51
        Me.tblScafElevation.Size = New System.Drawing.Size(279, 217)
        Me.tblScafElevation.TabIndex = 0
        '
        'idElevationSCF
        '
        Me.idElevationSCF.HeaderText = "idElevationSCF"
        Me.idElevationSCF.MinimumWidth = 6
        Me.idElevationSCF.Name = "idElevationSCF"
        Me.idElevationSCF.Visible = False
        '
        'ElevationSCF
        '
        Me.ElevationSCF.HeaderText = "Elevation"
        Me.ElevationSCF.MinimumWidth = 6
        Me.ElevationSCF.Name = "ElevationSCF"
        '
        'IncrementSCF
        '
        Me.IncrementSCF.HeaderText = "%Increment"
        Me.IncrementSCF.MinimumWidth = 6
        Me.IncrementSCF.Name = "IncrementSCF"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SCF Units Rates"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel7)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox4.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(1267, 256)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Scaffold Units Rates"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnExcelScaffoldUnitRates, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Panel11, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1259, 233)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'btnExcelScaffoldUnitRates
        '
        Me.btnExcelScaffoldUnitRates.FlatAppearance.BorderSize = 0
        Me.btnExcelScaffoldUnitRates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelScaffoldUnitRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelScaffoldUnitRates.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelScaffoldUnitRates.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelScaffoldUnitRates.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelScaffoldUnitRates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelScaffoldUnitRates.Location = New System.Drawing.Point(1130, 4)
        Me.btnExcelScaffoldUnitRates.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelScaffoldUnitRates.Name = "btnExcelScaffoldUnitRates"
        Me.btnExcelScaffoldUnitRates.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelScaffoldUnitRates.TabIndex = 33
        Me.btnExcelScaffoldUnitRates.Text = "Upload"
        Me.btnExcelScaffoldUnitRates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelScaffoldUnitRates.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.tblSCFUnitsRates)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel11.Location = New System.Drawing.Point(4, 4)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1118, 225)
        Me.Panel11.TabIndex = 0
        '
        'tblSCFUnitsRates
        '
        Me.tblSCFUnitsRates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblSCFUnitsRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblSCFUnitsRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdUnitRate, Me.DescriptionURSCF, Me.BuildPercent, Me.LaborProdBuild, Me.MaterialBuild, Me.EquipmentBuild, Me.DimantlePercent, Me.LaborProdDis, Me.MaterialDis, Me.EquipmentDis})
        Me.tblSCFUnitsRates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSCFUnitsRates.Location = New System.Drawing.Point(0, 0)
        Me.tblSCFUnitsRates.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblSCFUnitsRates.Name = "tblSCFUnitsRates"
        Me.tblSCFUnitsRates.RowHeadersWidth = 51
        Me.tblSCFUnitsRates.Size = New System.Drawing.Size(1118, 225)
        Me.tblSCFUnitsRates.TabIndex = 0
        '
        'IdUnitRate
        '
        Me.IdUnitRate.HeaderText = "IdUnitRate"
        Me.IdUnitRate.MinimumWidth = 6
        Me.IdUnitRate.Name = "IdUnitRate"
        Me.IdUnitRate.Visible = False
        '
        'DescriptionURSCF
        '
        Me.DescriptionURSCF.HeaderText = "Description"
        Me.DescriptionURSCF.MinimumWidth = 6
        Me.DescriptionURSCF.Name = "DescriptionURSCF"
        '
        'BuildPercent
        '
        Me.BuildPercent.HeaderText = "Build %"
        Me.BuildPercent.MinimumWidth = 6
        Me.BuildPercent.Name = "BuildPercent"
        '
        'LaborProdBuild
        '
        Me.LaborProdBuild.HeaderText = "Labor Prod. Build"
        Me.LaborProdBuild.MinimumWidth = 6
        Me.LaborProdBuild.Name = "LaborProdBuild"
        '
        'MaterialBuild
        '
        Me.MaterialBuild.HeaderText = "Material Build"
        Me.MaterialBuild.MinimumWidth = 6
        Me.MaterialBuild.Name = "MaterialBuild"
        '
        'EquipmentBuild
        '
        Me.EquipmentBuild.HeaderText = "Equipment Build"
        Me.EquipmentBuild.MinimumWidth = 6
        Me.EquipmentBuild.Name = "EquipmentBuild"
        '
        'DimantlePercent
        '
        Me.DimantlePercent.HeaderText = "Dismantle %"
        Me.DimantlePercent.MinimumWidth = 6
        Me.DimantlePercent.Name = "DimantlePercent"
        '
        'LaborProdDis
        '
        Me.LaborProdDis.HeaderText = "Labor Prod. Dis."
        Me.LaborProdDis.MinimumWidth = 6
        Me.LaborProdDis.Name = "LaborProdDis"
        '
        'MaterialDis
        '
        Me.MaterialDis.HeaderText = "Material Dis."
        Me.MaterialDis.MinimumWidth = 6
        Me.MaterialDis.Name = "MaterialDis"
        '
        'EquipmentDis
        '
        Me.EquipmentDis.HeaderText = "Equipment Dis."
        Me.EquipmentDis.MinimumWidth = 6
        Me.EquipmentDis.Name = "EquipmentDis"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "SCF Enviroment"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.TableLayoutPanel8)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(1275, 264)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Enviroment"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 731.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.btnExcelSCFEnviroment, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Panel12, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(1267, 241)
        Me.TableLayoutPanel8.TabIndex = 0
        '
        'btnExcelSCFEnviroment
        '
        Me.btnExcelSCFEnviroment.FlatAppearance.BorderSize = 0
        Me.btnExcelSCFEnviroment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelSCFEnviroment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelSCFEnviroment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelSCFEnviroment.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelSCFEnviroment.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelSCFEnviroment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelSCFEnviroment.Location = New System.Drawing.Point(540, 4)
        Me.btnExcelSCFEnviroment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelSCFEnviroment.Name = "btnExcelSCFEnviroment"
        Me.btnExcelSCFEnviroment.Size = New System.Drawing.Size(133, 43)
        Me.btnExcelSCFEnviroment.TabIndex = 33
        Me.btnExcelSCFEnviroment.Text = "Upload"
        Me.btnExcelSCFEnviroment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelSCFEnviroment.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.tblEnviroment)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel12.Location = New System.Drawing.Point(4, 4)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(528, 233)
        Me.Panel12.TabIndex = 0
        '
        'tblEnviroment
        '
        Me.tblEnviroment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEnviroment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEnviroment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idEnviroment, Me.Enviroment, Me.RevitionDueDay})
        Me.tblEnviroment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEnviroment.Location = New System.Drawing.Point(0, 0)
        Me.tblEnviroment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblEnviroment.Name = "tblEnviroment"
        Me.tblEnviroment.RowHeadersWidth = 51
        Me.tblEnviroment.Size = New System.Drawing.Size(528, 233)
        Me.tblEnviroment.TabIndex = 0
        '
        'idEnviroment
        '
        Me.idEnviroment.HeaderText = "idEnviroment"
        Me.idEnviroment.MinimumWidth = 6
        Me.idEnviroment.Name = "idEnviroment"
        Me.idEnviroment.Visible = False
        '
        'Enviroment
        '
        Me.Enviroment.HeaderText = "Enviroment"
        Me.Enviroment.MinimumWidth = 6
        Me.Enviroment.Name = "Enviroment"
        '
        'RevitionDueDay
        '
        Me.RevitionDueDay.HeaderText = "Revition Due Day"
        Me.RevitionDueDay.MinimumWidth = 6
        Me.RevitionDueDay.Name = "RevitionDueDay"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.TableLayoutPanel14)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "INS Units Rate"
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.ColumnCount = 2
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.GroupBox11, 1, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.GroupBox10, 0, 0)
        Me.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 1
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(1275, 264)
        Me.TableLayoutPanel14.TabIndex = 0
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.TableLayoutPanel16)
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox11.Location = New System.Drawing.Point(641, 4)
        Me.GroupBox11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox11.Size = New System.Drawing.Size(630, 256)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Piping Insulation Unit Rate"
        '
        'TableLayoutPanel16
        '
        Me.TableLayoutPanel16.ColumnCount = 2
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel16.Controls.Add(Me.btnExcelUpdatePpInsUR, 1, 0)
        Me.TableLayoutPanel16.Controls.Add(Me.Panel14, 0, 0)
        Me.TableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel16.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel16.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel16.Name = "TableLayoutPanel16"
        Me.TableLayoutPanel16.RowCount = 1
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel16.Size = New System.Drawing.Size(622, 233)
        Me.TableLayoutPanel16.TabIndex = 1
        '
        'btnExcelUpdatePpInsUR
        '
        Me.btnExcelUpdatePpInsUR.FlatAppearance.BorderSize = 0
        Me.btnExcelUpdatePpInsUR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelUpdatePpInsUR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelUpdatePpInsUR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelUpdatePpInsUR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelUpdatePpInsUR.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelUpdatePpInsUR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelUpdatePpInsUR.Location = New System.Drawing.Point(493, 4)
        Me.btnExcelUpdatePpInsUR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelUpdatePpInsUR.Name = "btnExcelUpdatePpInsUR"
        Me.btnExcelUpdatePpInsUR.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelUpdatePpInsUR.TabIndex = 35
        Me.btnExcelUpdatePpInsUR.Text = "Upload"
        Me.btnExcelUpdatePpInsUR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelUpdatePpInsUR.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.tblPpInsUnitRate)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel14.Location = New System.Drawing.Point(4, 4)
        Me.Panel14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(481, 225)
        Me.Panel14.TabIndex = 0
        '
        'tblPpInsUnitRate
        '
        Me.tblPpInsUnitRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPpInsUnitRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPpInsUnitRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idSizePpIUR, Me.idTypePpIUR, Me.idThickPpIUR, Me.SizePpIUR, Me.typePpIUR, Me.thickPpIUR, Me.laborProdPpIUR, Me.matRatePpIUR, Me.eqRatePpIUR})
        Me.tblPpInsUnitRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPpInsUnitRate.Location = New System.Drawing.Point(0, 0)
        Me.tblPpInsUnitRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPpInsUnitRate.Name = "tblPpInsUnitRate"
        Me.tblPpInsUnitRate.RowHeadersWidth = 51
        Me.tblPpInsUnitRate.Size = New System.Drawing.Size(481, 225)
        Me.tblPpInsUnitRate.TabIndex = 0
        '
        'idSizePpIUR
        '
        Me.idSizePpIUR.HeaderText = "idSizePpIUR"
        Me.idSizePpIUR.MinimumWidth = 6
        Me.idSizePpIUR.Name = "idSizePpIUR"
        Me.idSizePpIUR.Visible = False
        '
        'idTypePpIUR
        '
        Me.idTypePpIUR.HeaderText = "idTypePpIUR"
        Me.idTypePpIUR.MinimumWidth = 6
        Me.idTypePpIUR.Name = "idTypePpIUR"
        Me.idTypePpIUR.Visible = False
        '
        'idThickPpIUR
        '
        Me.idThickPpIUR.HeaderText = "idThickPpIUR"
        Me.idThickPpIUR.MinimumWidth = 6
        Me.idThickPpIUR.Name = "idThickPpIUR"
        Me.idThickPpIUR.Visible = False
        '
        'SizePpIUR
        '
        Me.SizePpIUR.HeaderText = "Size"
        Me.SizePpIUR.MinimumWidth = 6
        Me.SizePpIUR.Name = "SizePpIUR"
        '
        'typePpIUR
        '
        Me.typePpIUR.HeaderText = "Type"
        Me.typePpIUR.MinimumWidth = 6
        Me.typePpIUR.Name = "typePpIUR"
        '
        'thickPpIUR
        '
        Me.thickPpIUR.HeaderText = "Thick"
        Me.thickPpIUR.MinimumWidth = 6
        Me.thickPpIUR.Name = "thickPpIUR"
        '
        'laborProdPpIUR
        '
        Me.laborProdPpIUR.HeaderText = "Labor Prod."
        Me.laborProdPpIUR.MinimumWidth = 6
        Me.laborProdPpIUR.Name = "laborProdPpIUR"
        '
        'matRatePpIUR
        '
        Me.matRatePpIUR.HeaderText = "Mat. Rate"
        Me.matRatePpIUR.MinimumWidth = 6
        Me.matRatePpIUR.Name = "matRatePpIUR"
        '
        'eqRatePpIUR
        '
        Me.eqRatePpIUR.HeaderText = "Eq. Rate"
        Me.eqRatePpIUR.MinimumWidth = 6
        Me.eqRatePpIUR.Name = "eqRatePpIUR"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.TableLayoutPanel15)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox10.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox10.Size = New System.Drawing.Size(629, 256)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Equipment Insulation Unit Rate"
        '
        'TableLayoutPanel15
        '
        Me.TableLayoutPanel15.ColumnCount = 2
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel15.Controls.Add(Me.btnExcelUpdateEqInsUR, 1, 0)
        Me.TableLayoutPanel15.Controls.Add(Me.Panel13, 0, 0)
        Me.TableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel15.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        Me.TableLayoutPanel15.RowCount = 1
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel15.Size = New System.Drawing.Size(621, 233)
        Me.TableLayoutPanel15.TabIndex = 0
        '
        'btnExcelUpdateEqInsUR
        '
        Me.btnExcelUpdateEqInsUR.FlatAppearance.BorderSize = 0
        Me.btnExcelUpdateEqInsUR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelUpdateEqInsUR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelUpdateEqInsUR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelUpdateEqInsUR.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelUpdateEqInsUR.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelUpdateEqInsUR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelUpdateEqInsUR.Location = New System.Drawing.Point(492, 4)
        Me.btnExcelUpdateEqInsUR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelUpdateEqInsUR.Name = "btnExcelUpdateEqInsUR"
        Me.btnExcelUpdateEqInsUR.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelUpdateEqInsUR.TabIndex = 35
        Me.btnExcelUpdateEqInsUR.Text = "Upload"
        Me.btnExcelUpdateEqInsUR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelUpdateEqInsUR.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.tblEqInsUnitRate)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel13.Location = New System.Drawing.Point(4, 4)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(480, 225)
        Me.Panel13.TabIndex = 0
        '
        'tblEqInsUnitRate
        '
        Me.tblEqInsUnitRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEqInsUnitRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEqInsUnitRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idTypeEQIUR, Me.idThickEQIUR, Me.typeEQIUR, Me.ThickEQIUR, Me.laborProdEQIUR, Me.matRateEQIUR, Me.eqRateEQIUR})
        Me.tblEqInsUnitRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEqInsUnitRate.Location = New System.Drawing.Point(0, 0)
        Me.tblEqInsUnitRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblEqInsUnitRate.Name = "tblEqInsUnitRate"
        Me.tblEqInsUnitRate.RowHeadersWidth = 51
        Me.tblEqInsUnitRate.Size = New System.Drawing.Size(480, 225)
        Me.tblEqInsUnitRate.TabIndex = 0
        '
        'idTypeEQIUR
        '
        Me.idTypeEQIUR.HeaderText = "idTypeEQIUR"
        Me.idTypeEQIUR.MinimumWidth = 6
        Me.idTypeEQIUR.Name = "idTypeEQIUR"
        Me.idTypeEQIUR.Visible = False
        '
        'idThickEQIUR
        '
        Me.idThickEQIUR.HeaderText = "idThickEQIUR"
        Me.idThickEQIUR.MinimumWidth = 6
        Me.idThickEQIUR.Name = "idThickEQIUR"
        Me.idThickEQIUR.Visible = False
        '
        'typeEQIUR
        '
        Me.typeEQIUR.HeaderText = "Type"
        Me.typeEQIUR.MinimumWidth = 6
        Me.typeEQIUR.Name = "typeEQIUR"
        '
        'ThickEQIUR
        '
        Me.ThickEQIUR.HeaderText = "Thick"
        Me.ThickEQIUR.MinimumWidth = 6
        Me.ThickEQIUR.Name = "ThickEQIUR"
        '
        'laborProdEQIUR
        '
        Me.laborProdEQIUR.HeaderText = "Labor Prod."
        Me.laborProdEQIUR.MinimumWidth = 6
        Me.laborProdEQIUR.Name = "laborProdEQIUR"
        '
        'matRateEQIUR
        '
        Me.matRateEQIUR.HeaderText = "Mat. Rate"
        Me.matRateEQIUR.MinimumWidth = 6
        Me.matRateEQIUR.Name = "matRateEQIUR"
        '
        'eqRateEQIUR
        '
        Me.eqRateEQIUR.HeaderText = "Eq. Rate"
        Me.eqRateEQIUR.MinimumWidth = 6
        Me.eqRateEQIUR.Name = "eqRateEQIUR"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.TableLayoutPanel17)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "INS Jackets Rates"
        '
        'TableLayoutPanel17
        '
        Me.TableLayoutPanel17.ColumnCount = 2
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel17.Controls.Add(Me.GroupBox12, 1, 0)
        Me.TableLayoutPanel17.Controls.Add(Me.GroupBox13, 0, 0)
        Me.TableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel17.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel17.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        Me.TableLayoutPanel17.RowCount = 1
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel17.Size = New System.Drawing.Size(1275, 264)
        Me.TableLayoutPanel17.TabIndex = 1
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.TableLayoutPanel18)
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox12.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox12.Location = New System.Drawing.Point(641, 4)
        Me.GroupBox12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox12.Size = New System.Drawing.Size(630, 256)
        Me.GroupBox12.TabIndex = 1
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Piping"
        '
        'TableLayoutPanel18
        '
        Me.TableLayoutPanel18.ColumnCount = 2
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel18.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel18.Controls.Add(Me.btnExcelJacketPp, 1, 0)
        Me.TableLayoutPanel18.Controls.Add(Me.Panel15, 0, 0)
        Me.TableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel18.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel18.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel18.Name = "TableLayoutPanel18"
        Me.TableLayoutPanel18.RowCount = 1
        Me.TableLayoutPanel18.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel18.Size = New System.Drawing.Size(622, 233)
        Me.TableLayoutPanel18.TabIndex = 1
        '
        'btnExcelJacketPp
        '
        Me.btnExcelJacketPp.FlatAppearance.BorderSize = 0
        Me.btnExcelJacketPp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelJacketPp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelJacketPp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelJacketPp.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelJacketPp.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelJacketPp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelJacketPp.Location = New System.Drawing.Point(493, 4)
        Me.btnExcelJacketPp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelJacketPp.Name = "btnExcelJacketPp"
        Me.btnExcelJacketPp.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelJacketPp.TabIndex = 35
        Me.btnExcelJacketPp.Text = "Upload"
        Me.btnExcelJacketPp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelJacketPp.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.tblJacketPp)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel15.Location = New System.Drawing.Point(4, 4)
        Me.Panel15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(481, 225)
        Me.Panel15.TabIndex = 0
        '
        'tblJacketPp
        '
        Me.tblJacketPp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblJacketPp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblJacketPp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idJacketPp, Me.JacketTypePp, Me.jacketNamePp, Me.laborProdJckPp, Me.matFactorJckPp, Me.eqFactorJckPp})
        Me.tblJacketPp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblJacketPp.Location = New System.Drawing.Point(0, 0)
        Me.tblJacketPp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblJacketPp.Name = "tblJacketPp"
        Me.tblJacketPp.RowHeadersWidth = 51
        Me.tblJacketPp.Size = New System.Drawing.Size(481, 225)
        Me.tblJacketPp.TabIndex = 0
        '
        'idJacketPp
        '
        Me.idJacketPp.HeaderText = "idJacketPp"
        Me.idJacketPp.MinimumWidth = 6
        Me.idJacketPp.Name = "idJacketPp"
        Me.idJacketPp.Visible = False
        '
        'JacketTypePp
        '
        Me.JacketTypePp.HeaderText = "Jacket Type"
        Me.JacketTypePp.MinimumWidth = 6
        Me.JacketTypePp.Name = "JacketTypePp"
        '
        'jacketNamePp
        '
        Me.jacketNamePp.HeaderText = "Jacket Name"
        Me.jacketNamePp.MinimumWidth = 6
        Me.jacketNamePp.Name = "jacketNamePp"
        '
        'laborProdJckPp
        '
        Me.laborProdJckPp.HeaderText = "Labor Prod."
        Me.laborProdJckPp.MinimumWidth = 6
        Me.laborProdJckPp.Name = "laborProdJckPp"
        '
        'matFactorJckPp
        '
        Me.matFactorJckPp.HeaderText = "Mat. Factor"
        Me.matFactorJckPp.MinimumWidth = 6
        Me.matFactorJckPp.Name = "matFactorJckPp"
        '
        'eqFactorJckPp
        '
        Me.eqFactorJckPp.HeaderText = "Eq. Factor"
        Me.eqFactorJckPp.MinimumWidth = 6
        Me.eqFactorJckPp.Name = "eqFactorJckPp"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.TableLayoutPanel19)
        Me.GroupBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox13.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox13.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox13.Size = New System.Drawing.Size(629, 256)
        Me.GroupBox13.TabIndex = 0
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Equipment"
        '
        'TableLayoutPanel19
        '
        Me.TableLayoutPanel19.ColumnCount = 2
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel19.Controls.Add(Me.btnExcelJacketEq, 1, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.Panel16, 0, 0)
        Me.TableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel19.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel19.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel19.Name = "TableLayoutPanel19"
        Me.TableLayoutPanel19.RowCount = 1
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel19.Size = New System.Drawing.Size(621, 233)
        Me.TableLayoutPanel19.TabIndex = 0
        '
        'btnExcelJacketEq
        '
        Me.btnExcelJacketEq.FlatAppearance.BorderSize = 0
        Me.btnExcelJacketEq.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelJacketEq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelJacketEq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelJacketEq.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelJacketEq.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelJacketEq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelJacketEq.Location = New System.Drawing.Point(492, 4)
        Me.btnExcelJacketEq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelJacketEq.Name = "btnExcelJacketEq"
        Me.btnExcelJacketEq.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelJacketEq.TabIndex = 35
        Me.btnExcelJacketEq.Text = "Upload"
        Me.btnExcelJacketEq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelJacketEq.UseVisualStyleBackColor = True
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.tblJacketEq)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel16.Location = New System.Drawing.Point(4, 4)
        Me.Panel16.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(480, 225)
        Me.Panel16.TabIndex = 0
        '
        'tblJacketEq
        '
        Me.tblJacketEq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblJacketEq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblJacketEq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idJacket, Me.JacketType, Me.jacketName, Me.laborProdJckEq, Me.matFactorJckEq, Me.eqFactorJckEq})
        Me.tblJacketEq.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblJacketEq.Location = New System.Drawing.Point(0, 0)
        Me.tblJacketEq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblJacketEq.Name = "tblJacketEq"
        Me.tblJacketEq.RowHeadersWidth = 51
        Me.tblJacketEq.Size = New System.Drawing.Size(480, 225)
        Me.tblJacketEq.TabIndex = 0
        '
        'idJacket
        '
        Me.idJacket.HeaderText = "idJacket"
        Me.idJacket.MinimumWidth = 6
        Me.idJacket.Name = "idJacket"
        Me.idJacket.Visible = False
        '
        'JacketType
        '
        Me.JacketType.HeaderText = "Jacket Type"
        Me.JacketType.MinimumWidth = 6
        Me.JacketType.Name = "JacketType"
        '
        'jacketName
        '
        Me.jacketName.HeaderText = "Jacket Name"
        Me.jacketName.MinimumWidth = 6
        Me.jacketName.Name = "jacketName"
        '
        'laborProdJckEq
        '
        Me.laborProdJckEq.HeaderText = "Labor Prod."
        Me.laborProdJckEq.MinimumWidth = 6
        Me.laborProdJckEq.Name = "laborProdJckEq"
        '
        'matFactorJckEq
        '
        Me.matFactorJckEq.HeaderText = "Mat. Factor"
        Me.matFactorJckEq.MinimumWidth = 6
        Me.matFactorJckEq.Name = "matFactorJckEq"
        '
        'eqFactorJckEq
        '
        Me.eqFactorJckEq.HeaderText = "Eq. Factor"
        Me.eqFactorJckEq.MinimumWidth = 6
        Me.eqFactorJckEq.Name = "eqFactorJckEq"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.TableLayoutPanel11)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "PNT Unit Rates"
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.GroupBox9, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.GroupBox8, 0, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 1
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(1275, 264)
        Me.TableLayoutPanel11.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.TableLayoutPanel13)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox9.Location = New System.Drawing.Point(641, 4)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox9.Size = New System.Drawing.Size(630, 256)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Piping Paint Unit Rate"
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.ColumnCount = 2
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.btnExcelPpPntUnitRate, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.tblPpPaintUnitRate, 0, 0)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 1
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(622, 233)
        Me.TableLayoutPanel13.TabIndex = 1
        '
        'btnExcelPpPntUnitRate
        '
        Me.btnExcelPpPntUnitRate.FlatAppearance.BorderSize = 0
        Me.btnExcelPpPntUnitRate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelPpPntUnitRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelPpPntUnitRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelPpPntUnitRate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelPpPntUnitRate.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelPpPntUnitRate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelPpPntUnitRate.Location = New System.Drawing.Point(493, 4)
        Me.btnExcelPpPntUnitRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelPpPntUnitRate.Name = "btnExcelPpPntUnitRate"
        Me.btnExcelPpPntUnitRate.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelPpPntUnitRate.TabIndex = 36
        Me.btnExcelPpPntUnitRate.Text = "  Upload"
        Me.btnExcelPpPntUnitRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelPpPntUnitRate.UseVisualStyleBackColor = True
        '
        'tblPpPaintUnitRate
        '
        Me.tblPpPaintUnitRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPpPaintUnitRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPpPaintUnitRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.systemPPId, Me.optionPPId, Me.sizePPId, Me.SystemPP, Me.optionPP, Me.sizePP, Me.laborProdPP, Me.matRatePP, Me.eqRatePP})
        Me.tblPpPaintUnitRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPpPaintUnitRate.Location = New System.Drawing.Point(4, 4)
        Me.tblPpPaintUnitRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPpPaintUnitRate.Name = "tblPpPaintUnitRate"
        Me.tblPpPaintUnitRate.RowHeadersWidth = 51
        Me.tblPpPaintUnitRate.Size = New System.Drawing.Size(481, 225)
        Me.tblPpPaintUnitRate.TabIndex = 1
        '
        'systemPPId
        '
        Me.systemPPId.HeaderText = "systemPPId"
        Me.systemPPId.MinimumWidth = 6
        Me.systemPPId.Name = "systemPPId"
        Me.systemPPId.Visible = False
        '
        'optionPPId
        '
        Me.optionPPId.HeaderText = "optionPPId"
        Me.optionPPId.MinimumWidth = 6
        Me.optionPPId.Name = "optionPPId"
        Me.optionPPId.Visible = False
        '
        'sizePPId
        '
        Me.sizePPId.HeaderText = "sizePPId"
        Me.sizePPId.MinimumWidth = 6
        Me.sizePPId.Name = "sizePPId"
        Me.sizePPId.Visible = False
        '
        'SystemPP
        '
        Me.SystemPP.HeaderText = "System"
        Me.SystemPP.MinimumWidth = 6
        Me.SystemPP.Name = "SystemPP"
        '
        'optionPP
        '
        Me.optionPP.HeaderText = "Option"
        Me.optionPP.MinimumWidth = 6
        Me.optionPP.Name = "optionPP"
        '
        'sizePP
        '
        Me.sizePP.HeaderText = "Size"
        Me.sizePP.MinimumWidth = 6
        Me.sizePP.Name = "sizePP"
        '
        'laborProdPP
        '
        Me.laborProdPP.HeaderText = "Labor Prod."
        Me.laborProdPP.MinimumWidth = 6
        Me.laborProdPP.Name = "laborProdPP"
        '
        'matRatePP
        '
        Me.matRatePP.HeaderText = "Mat. Rate"
        Me.matRatePP.MinimumWidth = 6
        Me.matRatePP.Name = "matRatePP"
        '
        'eqRatePP
        '
        Me.eqRatePP.HeaderText = "Eq. Rate"
        Me.eqRatePP.MinimumWidth = 6
        Me.eqRatePP.Name = "eqRatePP"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TableLayoutPanel12)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox8.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox8.Size = New System.Drawing.Size(629, 256)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Equipment Paint Unit Rate"
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel12.Controls.Add(Me.btnExcelEqPntUnitRate, 1, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.tblEqPaintUnitRate, 0, 0)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 1
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(621, 233)
        Me.TableLayoutPanel12.TabIndex = 0
        '
        'btnExcelEqPntUnitRate
        '
        Me.btnExcelEqPntUnitRate.FlatAppearance.BorderSize = 0
        Me.btnExcelEqPntUnitRate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelEqPntUnitRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelEqPntUnitRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelEqPntUnitRate.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelEqPntUnitRate.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelEqPntUnitRate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelEqPntUnitRate.Location = New System.Drawing.Point(492, 4)
        Me.btnExcelEqPntUnitRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelEqPntUnitRate.Name = "btnExcelEqPntUnitRate"
        Me.btnExcelEqPntUnitRate.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelEqPntUnitRate.TabIndex = 35
        Me.btnExcelEqPntUnitRate.Text = "  Upload"
        Me.btnExcelEqPntUnitRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelEqPntUnitRate.UseVisualStyleBackColor = True
        '
        'tblEqPaintUnitRate
        '
        Me.tblEqPaintUnitRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEqPaintUnitRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEqPaintUnitRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SystemEqId, Me.OptionEQId, Me.SystemEq, Me.OptionEq, Me.laborProdEq, Me.materialRateEq, Me.eqRateEq})
        Me.tblEqPaintUnitRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEqPaintUnitRate.Location = New System.Drawing.Point(4, 4)
        Me.tblEqPaintUnitRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblEqPaintUnitRate.Name = "tblEqPaintUnitRate"
        Me.tblEqPaintUnitRate.RowHeadersWidth = 51
        Me.tblEqPaintUnitRate.Size = New System.Drawing.Size(480, 225)
        Me.tblEqPaintUnitRate.TabIndex = 0
        '
        'SystemEqId
        '
        Me.SystemEqId.HeaderText = "SystemEqId"
        Me.SystemEqId.MinimumWidth = 6
        Me.SystemEqId.Name = "SystemEqId"
        Me.SystemEqId.Visible = False
        '
        'OptionEQId
        '
        Me.OptionEQId.HeaderText = "OptionEQId"
        Me.OptionEQId.MinimumWidth = 6
        Me.OptionEQId.Name = "OptionEQId"
        Me.OptionEQId.Visible = False
        '
        'SystemEq
        '
        Me.SystemEq.HeaderText = "System"
        Me.SystemEq.MinimumWidth = 6
        Me.SystemEq.Name = "SystemEq"
        '
        'OptionEq
        '
        Me.OptionEq.HeaderText = "Option"
        Me.OptionEq.MinimumWidth = 6
        Me.OptionEq.Name = "OptionEq"
        '
        'laborProdEq
        '
        Me.laborProdEq.HeaderText = "Labor Prod."
        Me.laborProdEq.MinimumWidth = 6
        Me.laborProdEq.Name = "laborProdEq"
        '
        'materialRateEq
        '
        Me.materialRateEq.HeaderText = "Material Rate"
        Me.materialRateEq.MinimumWidth = 6
        Me.materialRateEq.Name = "materialRateEq"
        '
        'eqRateEq
        '
        Me.eqRateEq.HeaderText = "Eq. Rate"
        Me.eqRateEq.MinimumWidth = 6
        Me.eqRateEq.Name = "eqRateEq"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage7.Controls.Add(Me.GroupBox6)
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "INS Fitting"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TableLayoutPanel9)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(1275, 264)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Insulation Fitting Factors"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.btnExcelInsFitting, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.tblInsFitting, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(1267, 241)
        Me.TableLayoutPanel9.TabIndex = 0
        '
        'btnExcelInsFitting
        '
        Me.btnExcelInsFitting.FlatAppearance.BorderSize = 0
        Me.btnExcelInsFitting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelInsFitting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelInsFitting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelInsFitting.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelInsFitting.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelInsFitting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelInsFitting.Location = New System.Drawing.Point(1138, 4)
        Me.btnExcelInsFitting.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelInsFitting.Name = "btnExcelInsFitting"
        Me.btnExcelInsFitting.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelInsFitting.TabIndex = 34
        Me.btnExcelInsFitting.Text = "Upload"
        Me.btnExcelInsFitting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelInsFitting.UseVisualStyleBackColor = True
        '
        'tblInsFitting
        '
        Me.tblInsFitting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.tblInsFitting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblInsFitting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.typeId, Me.Type, Me.Support, Me.p90, Me.p45, Me.Bend, Me.TEE, Me.RED, Me.CAP, Me.FlangePair, Me.FlangeVlv, Me.ControlVlv, Me.WeldVlv, Me.Bebel, Me.CutOut})
        Me.tblInsFitting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblInsFitting.Location = New System.Drawing.Point(4, 4)
        Me.tblInsFitting.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblInsFitting.Name = "tblInsFitting"
        Me.tblInsFitting.RowHeadersWidth = 51
        Me.tblInsFitting.Size = New System.Drawing.Size(1126, 233)
        Me.tblInsFitting.TabIndex = 0
        '
        'typeId
        '
        Me.typeId.HeaderText = "typeId"
        Me.typeId.MinimumWidth = 6
        Me.typeId.Name = "typeId"
        Me.typeId.Visible = False
        Me.typeId.Width = 125
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.MinimumWidth = 6
        Me.Type.Name = "Type"
        Me.Type.Width = 68
        '
        'Support
        '
        Me.Support.HeaderText = "Support"
        Me.Support.MinimumWidth = 6
        Me.Support.Name = "Support"
        Me.Support.Width = 83
        '
        'p90
        '
        Me.p90.HeaderText = "90"
        Me.p90.MinimumWidth = 6
        Me.p90.Name = "p90"
        Me.p90.Width = 50
        '
        'p45
        '
        Me.p45.HeaderText = "45"
        Me.p45.MinimumWidth = 6
        Me.p45.Name = "p45"
        Me.p45.Width = 50
        '
        'Bend
        '
        Me.Bend.HeaderText = "Bend"
        Me.Bend.MinimumWidth = 6
        Me.Bend.Name = "Bend"
        Me.Bend.Width = 68
        '
        'TEE
        '
        Me.TEE.HeaderText = "TEE"
        Me.TEE.MinimumWidth = 6
        Me.TEE.Name = "TEE"
        Me.TEE.Width = 63
        '
        'RED
        '
        Me.RED.HeaderText = "RED"
        Me.RED.MinimumWidth = 6
        Me.RED.Name = "RED"
        Me.RED.Width = 65
        '
        'CAP
        '
        Me.CAP.HeaderText = "CAP"
        Me.CAP.MinimumWidth = 6
        Me.CAP.Name = "CAP"
        Me.CAP.Width = 63
        '
        'FlangePair
        '
        Me.FlangePair.HeaderText = "Flange Pair"
        Me.FlangePair.MinimumWidth = 6
        Me.FlangePair.Name = "FlangePair"
        Me.FlangePair.Width = 105
        '
        'FlangeVlv
        '
        Me.FlangeVlv.HeaderText = "Flange Vlv"
        Me.FlangeVlv.MinimumWidth = 6
        Me.FlangeVlv.Name = "FlangeVlv"
        '
        'ControlVlv
        '
        Me.ControlVlv.HeaderText = "ControlVlv"
        Me.ControlVlv.MinimumWidth = 6
        Me.ControlVlv.Name = "ControlVlv"
        Me.ControlVlv.Width = 97
        '
        'WeldVlv
        '
        Me.WeldVlv.HeaderText = "Weld Vlv"
        Me.WeldVlv.MinimumWidth = 6
        Me.WeldVlv.Name = "WeldVlv"
        Me.WeldVlv.Width = 90
        '
        'Bebel
        '
        Me.Bebel.HeaderText = "Bebel"
        Me.Bebel.MinimumWidth = 6
        Me.Bebel.Name = "Bebel"
        Me.Bebel.Width = 72
        '
        'CutOut
        '
        Me.CutOut.HeaderText = "Cut-Out"
        Me.CutOut.MinimumWidth = 6
        Me.CutOut.Name = "CutOut"
        Me.CutOut.Width = 79
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage8.Controls.Add(Me.GroupBox7)
        Me.TabPage8.Location = New System.Drawing.Point(4, 25)
        Me.TabPage8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "PNT Fitting"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TableLayoutPanel10)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Size = New System.Drawing.Size(1275, 264)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Paint Fitting Factors"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.btnExcelPnpFitting, 1, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.tblPntFitting, 0, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(1267, 241)
        Me.TableLayoutPanel10.TabIndex = 0
        '
        'btnExcelPnpFitting
        '
        Me.btnExcelPnpFitting.FlatAppearance.BorderSize = 0
        Me.btnExcelPnpFitting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelPnpFitting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelPnpFitting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelPnpFitting.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelPnpFitting.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelPnpFitting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelPnpFitting.Location = New System.Drawing.Point(1138, 4)
        Me.btnExcelPnpFitting.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelPnpFitting.Name = "btnExcelPnpFitting"
        Me.btnExcelPnpFitting.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelPnpFitting.TabIndex = 35
        Me.btnExcelPnpFitting.Text = "Upload"
        Me.btnExcelPnpFitting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelPnpFitting.UseVisualStyleBackColor = True
        '
        'tblPntFitting
        '
        Me.tblPntFitting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPntFitting.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idOption, Me.PaintOption, Me.p90p, Me.p45p, Me.TEEp, Me.FlangePairp, Me.FlangeVlvp, Me.ControlVlvp, Me.WeldedVlvp})
        Me.tblPntFitting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPntFitting.Location = New System.Drawing.Point(4, 4)
        Me.tblPntFitting.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPntFitting.Name = "tblPntFitting"
        Me.tblPntFitting.RowHeadersWidth = 51
        Me.tblPntFitting.Size = New System.Drawing.Size(1126, 233)
        Me.tblPntFitting.TabIndex = 0
        '
        'idOption
        '
        Me.idOption.HeaderText = "idOption"
        Me.idOption.MinimumWidth = 6
        Me.idOption.Name = "idOption"
        Me.idOption.Visible = False
        Me.idOption.Width = 125
        '
        'PaintOption
        '
        Me.PaintOption.HeaderText = "Option"
        Me.PaintOption.MinimumWidth = 6
        Me.PaintOption.Name = "PaintOption"
        Me.PaintOption.Width = 125
        '
        'p90p
        '
        Me.p90p.HeaderText = "90"
        Me.p90p.MinimumWidth = 6
        Me.p90p.Name = "p90p"
        Me.p90p.Width = 125
        '
        'p45p
        '
        Me.p45p.HeaderText = "45"
        Me.p45p.MinimumWidth = 6
        Me.p45p.Name = "p45p"
        Me.p45p.Width = 125
        '
        'TEEp
        '
        Me.TEEp.HeaderText = "TEE"
        Me.TEEp.MinimumWidth = 6
        Me.TEEp.Name = "TEEp"
        Me.TEEp.Width = 125
        '
        'FlangePairp
        '
        Me.FlangePairp.HeaderText = "Flange Pair"
        Me.FlangePairp.MinimumWidth = 6
        Me.FlangePairp.Name = "FlangePairp"
        Me.FlangePairp.Width = 125
        '
        'FlangeVlvp
        '
        Me.FlangeVlvp.HeaderText = "Flange Vlv"
        Me.FlangeVlvp.MinimumWidth = 6
        Me.FlangeVlvp.Name = "FlangeVlvp"
        Me.FlangeVlvp.Width = 125
        '
        'ControlVlvp
        '
        Me.ControlVlvp.HeaderText = "ControlVlvp"
        Me.ControlVlvp.MinimumWidth = 6
        Me.ControlVlvp.Name = "ControlVlvp"
        Me.ControlVlvp.Width = 125
        '
        'WeldedVlvp
        '
        Me.WeldedVlvp.HeaderText = "Welded Vlv"
        Me.WeldedVlvp.MinimumWidth = 6
        Me.WeldedVlvp.Name = "WeldedVlvp"
        Me.WeldedVlvp.Width = 125
        '
        'TabPage9
        '
        Me.TabPage9.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage9.Controls.Add(Me.TableLayoutPanel21)
        Me.TabPage9.Location = New System.Drawing.Point(4, 25)
        Me.TabPage9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage9.TabIndex = 8
        Me.TabPage9.Text = "IR HC "
        '
        'TableLayoutPanel21
        '
        Me.TableLayoutPanel21.ColumnCount = 2
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel21.Controls.Add(Me.GroupBox15, 1, 0)
        Me.TableLayoutPanel21.Controls.Add(Me.GroupBox16, 0, 0)
        Me.TableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel21.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel21.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel21.Name = "TableLayoutPanel21"
        Me.TableLayoutPanel21.RowCount = 1
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel21.Size = New System.Drawing.Size(1275, 264)
        Me.TableLayoutPanel21.TabIndex = 1
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.TableLayoutPanel22)
        Me.GroupBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox15.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox15.Location = New System.Drawing.Point(641, 4)
        Me.GroupBox15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox15.Size = New System.Drawing.Size(630, 256)
        Me.GroupBox15.TabIndex = 1
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Piping IR HC"
        '
        'TableLayoutPanel22
        '
        Me.TableLayoutPanel22.ColumnCount = 2
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel22.Controls.Add(Me.btnExcelPipingIRHC, 0, 0)
        Me.TableLayoutPanel22.Controls.Add(Me.tblPipingIRHC, 0, 0)
        Me.TableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TableLayoutPanel22.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel22.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel22.Name = "TableLayoutPanel22"
        Me.TableLayoutPanel22.RowCount = 1
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel22.Size = New System.Drawing.Size(622, 233)
        Me.TableLayoutPanel22.TabIndex = 1
        '
        'btnExcelPipingIRHC
        '
        Me.btnExcelPipingIRHC.FlatAppearance.BorderSize = 0
        Me.btnExcelPipingIRHC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelPipingIRHC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelPipingIRHC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelPipingIRHC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelPipingIRHC.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelPipingIRHC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelPipingIRHC.Location = New System.Drawing.Point(493, 4)
        Me.btnExcelPipingIRHC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelPipingIRHC.Name = "btnExcelPipingIRHC"
        Me.btnExcelPipingIRHC.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelPipingIRHC.TabIndex = 36
        Me.btnExcelPipingIRHC.Text = "  Upload"
        Me.btnExcelPipingIRHC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelPipingIRHC.UseVisualStyleBackColor = True
        '
        'tblPipingIRHC
        '
        Me.tblPipingIRHC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPipingIRHC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPipingIRHC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idSizePPIRHC, Me.idTypePPIRHC, Me.idThicknessPPIRHC, Me.SizePPIRHC, Me.TypePPIRHC, Me.ThicknessPPIRHC, Me.LaborProdPPIRHC, Me.MaterialRatePPIRHC, Me.EquipmentRatePPIRHC})
        Me.tblPipingIRHC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPipingIRHC.Location = New System.Drawing.Point(4, 4)
        Me.tblPipingIRHC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPipingIRHC.Name = "tblPipingIRHC"
        Me.tblPipingIRHC.RowHeadersWidth = 51
        Me.tblPipingIRHC.Size = New System.Drawing.Size(481, 225)
        Me.tblPipingIRHC.TabIndex = 1
        '
        'idSizePPIRHC
        '
        Me.idSizePPIRHC.HeaderText = "idSizePPIRHC"
        Me.idSizePPIRHC.MinimumWidth = 6
        Me.idSizePPIRHC.Name = "idSizePPIRHC"
        Me.idSizePPIRHC.Visible = False
        '
        'idTypePPIRHC
        '
        Me.idTypePPIRHC.HeaderText = "idTypePPIRHC"
        Me.idTypePPIRHC.MinimumWidth = 6
        Me.idTypePPIRHC.Name = "idTypePPIRHC"
        Me.idTypePPIRHC.Visible = False
        '
        'idThicknessPPIRHC
        '
        Me.idThicknessPPIRHC.HeaderText = "idThicknessPPIRHC"
        Me.idThicknessPPIRHC.MinimumWidth = 6
        Me.idThicknessPPIRHC.Name = "idThicknessPPIRHC"
        Me.idThicknessPPIRHC.Visible = False
        '
        'SizePPIRHC
        '
        Me.SizePPIRHC.HeaderText = "Size"
        Me.SizePPIRHC.MinimumWidth = 6
        Me.SizePPIRHC.Name = "SizePPIRHC"
        '
        'TypePPIRHC
        '
        Me.TypePPIRHC.HeaderText = "Type"
        Me.TypePPIRHC.MinimumWidth = 6
        Me.TypePPIRHC.Name = "TypePPIRHC"
        '
        'ThicknessPPIRHC
        '
        Me.ThicknessPPIRHC.HeaderText = "Thickness"
        Me.ThicknessPPIRHC.MinimumWidth = 6
        Me.ThicknessPPIRHC.Name = "ThicknessPPIRHC"
        '
        'LaborProdPPIRHC
        '
        Me.LaborProdPPIRHC.HeaderText = "Labor Prod."
        Me.LaborProdPPIRHC.MinimumWidth = 6
        Me.LaborProdPPIRHC.Name = "LaborProdPPIRHC"
        '
        'MaterialRatePPIRHC
        '
        Me.MaterialRatePPIRHC.HeaderText = "Material"
        Me.MaterialRatePPIRHC.MinimumWidth = 6
        Me.MaterialRatePPIRHC.Name = "MaterialRatePPIRHC"
        '
        'EquipmentRatePPIRHC
        '
        Me.EquipmentRatePPIRHC.HeaderText = "Eq. Rate"
        Me.EquipmentRatePPIRHC.MinimumWidth = 6
        Me.EquipmentRatePPIRHC.Name = "EquipmentRatePPIRHC"
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.TableLayoutPanel23)
        Me.GroupBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox16.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox16.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox16.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox16.Size = New System.Drawing.Size(629, 256)
        Me.GroupBox16.TabIndex = 0
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Equipment IR HC"
        '
        'TableLayoutPanel23
        '
        Me.TableLayoutPanel23.ColumnCount = 2
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel23.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel23.Controls.Add(Me.btnExcelEquipmentIRHC, 1, 0)
        Me.TableLayoutPanel23.Controls.Add(Me.tblEquipmentIRHC, 0, 0)
        Me.TableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TableLayoutPanel23.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel23.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel23.Name = "TableLayoutPanel23"
        Me.TableLayoutPanel23.RowCount = 1
        Me.TableLayoutPanel23.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel23.Size = New System.Drawing.Size(621, 233)
        Me.TableLayoutPanel23.TabIndex = 0
        '
        'btnExcelEquipmentIRHC
        '
        Me.btnExcelEquipmentIRHC.FlatAppearance.BorderSize = 0
        Me.btnExcelEquipmentIRHC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelEquipmentIRHC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelEquipmentIRHC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelEquipmentIRHC.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelEquipmentIRHC.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelEquipmentIRHC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelEquipmentIRHC.Location = New System.Drawing.Point(492, 4)
        Me.btnExcelEquipmentIRHC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelEquipmentIRHC.Name = "btnExcelEquipmentIRHC"
        Me.btnExcelEquipmentIRHC.Size = New System.Drawing.Size(125, 43)
        Me.btnExcelEquipmentIRHC.TabIndex = 35
        Me.btnExcelEquipmentIRHC.Text = "  Upload"
        Me.btnExcelEquipmentIRHC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelEquipmentIRHC.UseVisualStyleBackColor = True
        '
        'tblEquipmentIRHC
        '
        Me.tblEquipmentIRHC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEquipmentIRHC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEquipmentIRHC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idTypeEqIRHC, Me.idThickIEqRHC, Me.TypeEqIRHC, Me.ThicknessEqIRHC, Me.LaborProdEqIRHC, Me.MaterialRateEqIRHC, Me.EquipmentEqIRHC})
        Me.tblEquipmentIRHC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEquipmentIRHC.Location = New System.Drawing.Point(4, 4)
        Me.tblEquipmentIRHC.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblEquipmentIRHC.Name = "tblEquipmentIRHC"
        Me.tblEquipmentIRHC.RowHeadersWidth = 51
        Me.tblEquipmentIRHC.Size = New System.Drawing.Size(480, 225)
        Me.tblEquipmentIRHC.TabIndex = 0
        '
        'idTypeEqIRHC
        '
        Me.idTypeEqIRHC.HeaderText = "idTypeEqIRHC"
        Me.idTypeEqIRHC.MinimumWidth = 6
        Me.idTypeEqIRHC.Name = "idTypeEqIRHC"
        Me.idTypeEqIRHC.Visible = False
        '
        'idThickIEqRHC
        '
        Me.idThickIEqRHC.HeaderText = "idThicknessEqIRHC"
        Me.idThickIEqRHC.MinimumWidth = 6
        Me.idThickIEqRHC.Name = "idThickIEqRHC"
        Me.idThickIEqRHC.Visible = False
        '
        'TypeEqIRHC
        '
        Me.TypeEqIRHC.HeaderText = "Type"
        Me.TypeEqIRHC.MinimumWidth = 6
        Me.TypeEqIRHC.Name = "TypeEqIRHC"
        '
        'ThicknessEqIRHC
        '
        Me.ThicknessEqIRHC.HeaderText = "Thickness"
        Me.ThicknessEqIRHC.MinimumWidth = 6
        Me.ThicknessEqIRHC.Name = "ThicknessEqIRHC"
        '
        'LaborProdEqIRHC
        '
        Me.LaborProdEqIRHC.HeaderText = "Labor Prod."
        Me.LaborProdEqIRHC.MinimumWidth = 6
        Me.LaborProdEqIRHC.Name = "LaborProdEqIRHC"
        '
        'MaterialRateEqIRHC
        '
        Me.MaterialRateEqIRHC.HeaderText = "Material Rate"
        Me.MaterialRateEqIRHC.MinimumWidth = 6
        Me.MaterialRateEqIRHC.Name = "MaterialRateEqIRHC"
        '
        'EquipmentEqIRHC
        '
        Me.EquipmentEqIRHC.HeaderText = "Eq. Rete"
        Me.EquipmentEqIRHC.MinimumWidth = 6
        Me.EquipmentEqIRHC.Name = "EquipmentEqIRHC"
        '
        'TabPage10
        '
        Me.TabPage10.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage10.Controls.Add(Me.GroupBox14)
        Me.TabPage10.Location = New System.Drawing.Point(4, 25)
        Me.TabPage10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage10.TabIndex = 9
        Me.TabPage10.Text = "PIP MATERIAL"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.TableLayoutPanel20)
        Me.GroupBox14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox14.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox14.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox14.Size = New System.Drawing.Size(1275, 264)
        Me.GroupBox14.TabIndex = 0
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Piping Material"
        '
        'TableLayoutPanel20
        '
        Me.TableLayoutPanel20.ColumnCount = 3
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel20.Controls.Add(Me.btnExcelPipingMaterial, 1, 0)
        Me.TableLayoutPanel20.Controls.Add(Me.Panel17, 0, 0)
        Me.TableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel20.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel20.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel20.Name = "TableLayoutPanel20"
        Me.TableLayoutPanel20.RowCount = 1
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel20.Size = New System.Drawing.Size(1267, 241)
        Me.TableLayoutPanel20.TabIndex = 0
        '
        'btnExcelPipingMaterial
        '
        Me.btnExcelPipingMaterial.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExcelPipingMaterial.FlatAppearance.BorderSize = 0
        Me.btnExcelPipingMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelPipingMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelPipingMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelPipingMaterial.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelPipingMaterial.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelPipingMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelPipingMaterial.Location = New System.Drawing.Point(858, 4)
        Me.btnExcelPipingMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelPipingMaterial.Name = "btnExcelPipingMaterial"
        Me.btnExcelPipingMaterial.Size = New System.Drawing.Size(120, 43)
        Me.btnExcelPipingMaterial.TabIndex = 35
        Me.btnExcelPipingMaterial.Text = "Upload"
        Me.btnExcelPipingMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelPipingMaterial.UseVisualStyleBackColor = True
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.tblPipingMaterial)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel17.Location = New System.Drawing.Point(4, 4)
        Me.Panel17.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(846, 233)
        Me.Panel17.TabIndex = 36
        '
        'tblPipingMaterial
        '
        Me.tblPipingMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPipingMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPipingMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idSizeMat, Me.idTypeMat, Me.idThickMat, Me.SizeMat, Me.TypeMat, Me.ThickMat, Me.PriceMat, Me.DescriptionMat})
        Me.tblPipingMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPipingMaterial.Location = New System.Drawing.Point(0, 0)
        Me.tblPipingMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPipingMaterial.Name = "tblPipingMaterial"
        Me.tblPipingMaterial.RowHeadersWidth = 51
        Me.tblPipingMaterial.Size = New System.Drawing.Size(846, 233)
        Me.tblPipingMaterial.TabIndex = 36
        '
        'idSizeMat
        '
        Me.idSizeMat.HeaderText = "idSize"
        Me.idSizeMat.MinimumWidth = 6
        Me.idSizeMat.Name = "idSizeMat"
        Me.idSizeMat.Visible = False
        '
        'idTypeMat
        '
        Me.idTypeMat.HeaderText = "idType"
        Me.idTypeMat.MinimumWidth = 6
        Me.idTypeMat.Name = "idTypeMat"
        Me.idTypeMat.Visible = False
        '
        'idThickMat
        '
        Me.idThickMat.HeaderText = "idThick"
        Me.idThickMat.MinimumWidth = 6
        Me.idThickMat.Name = "idThickMat"
        Me.idThickMat.Visible = False
        '
        'SizeMat
        '
        Me.SizeMat.HeaderText = "Size"
        Me.SizeMat.MinimumWidth = 6
        Me.SizeMat.Name = "SizeMat"
        '
        'TypeMat
        '
        Me.TypeMat.HeaderText = "Type"
        Me.TypeMat.MinimumWidth = 6
        Me.TypeMat.Name = "TypeMat"
        '
        'ThickMat
        '
        Me.ThickMat.HeaderText = "Thick"
        Me.ThickMat.MinimumWidth = 6
        Me.ThickMat.Name = "ThickMat"
        '
        'PriceMat
        '
        Me.PriceMat.HeaderText = "Price"
        Me.PriceMat.MinimumWidth = 6
        Me.PriceMat.Name = "PriceMat"
        '
        'DescriptionMat
        '
        Me.DescriptionMat.HeaderText = "Description"
        Me.DescriptionMat.MinimumWidth = 6
        Me.DescriptionMat.Name = "DescriptionMat"
        '
        'TabPage11
        '
        Me.TabPage11.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage11.Controls.Add(Me.GroupBox17)
        Me.TabPage11.Location = New System.Drawing.Point(4, 25)
        Me.TabPage11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage11.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage11.TabIndex = 10
        Me.TabPage11.Text = "EQ Material"
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.TableLayoutPanel24)
        Me.GroupBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox17.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox17.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox17.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox17.Size = New System.Drawing.Size(1267, 256)
        Me.GroupBox17.TabIndex = 1
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Equipment Material"
        '
        'TableLayoutPanel24
        '
        Me.TableLayoutPanel24.ColumnCount = 3
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148.0!))
        Me.TableLayoutPanel24.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel24.Controls.Add(Me.btnExcelTblEquipmentMaterial, 1, 0)
        Me.TableLayoutPanel24.Controls.Add(Me.Panel18, 0, 0)
        Me.TableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel24.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel24.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel24.Name = "TableLayoutPanel24"
        Me.TableLayoutPanel24.RowCount = 1
        Me.TableLayoutPanel24.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel24.Size = New System.Drawing.Size(1259, 233)
        Me.TableLayoutPanel24.TabIndex = 0
        '
        'btnExcelTblEquipmentMaterial
        '
        Me.btnExcelTblEquipmentMaterial.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExcelTblEquipmentMaterial.FlatAppearance.BorderSize = 0
        Me.btnExcelTblEquipmentMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelTblEquipmentMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelTblEquipmentMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelTblEquipmentMaterial.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelTblEquipmentMaterial.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelTblEquipmentMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTblEquipmentMaterial.Location = New System.Drawing.Point(837, 4)
        Me.btnExcelTblEquipmentMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelTblEquipmentMaterial.Name = "btnExcelTblEquipmentMaterial"
        Me.btnExcelTblEquipmentMaterial.Size = New System.Drawing.Size(140, 43)
        Me.btnExcelTblEquipmentMaterial.TabIndex = 35
        Me.btnExcelTblEquipmentMaterial.Text = "Upload"
        Me.btnExcelTblEquipmentMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTblEquipmentMaterial.UseVisualStyleBackColor = True
        '
        'Panel18
        '
        Me.Panel18.Controls.Add(Me.tblEquipmentMaterial)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel18.Location = New System.Drawing.Point(4, 4)
        Me.Panel18.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(825, 225)
        Me.Panel18.TabIndex = 36
        '
        'tblEquipmentMaterial
        '
        Me.tblEquipmentMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblEquipmentMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblEquipmentMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idTypeEqMat, Me.idThickEqMat, Me.TypeEqMat, Me.ThickEqMat, Me.PriceEqMat, Me.DescriptionEqMat})
        Me.tblEquipmentMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblEquipmentMaterial.Location = New System.Drawing.Point(0, 0)
        Me.tblEquipmentMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblEquipmentMaterial.Name = "tblEquipmentMaterial"
        Me.tblEquipmentMaterial.RowHeadersWidth = 51
        Me.tblEquipmentMaterial.Size = New System.Drawing.Size(825, 225)
        Me.tblEquipmentMaterial.TabIndex = 36
        '
        'idTypeEqMat
        '
        Me.idTypeEqMat.HeaderText = "idType"
        Me.idTypeEqMat.MinimumWidth = 6
        Me.idTypeEqMat.Name = "idTypeEqMat"
        Me.idTypeEqMat.Visible = False
        '
        'idThickEqMat
        '
        Me.idThickEqMat.HeaderText = "idThick"
        Me.idThickEqMat.MinimumWidth = 6
        Me.idThickEqMat.Name = "idThickEqMat"
        Me.idThickEqMat.Visible = False
        '
        'TypeEqMat
        '
        Me.TypeEqMat.HeaderText = "Type"
        Me.TypeEqMat.MinimumWidth = 6
        Me.TypeEqMat.Name = "TypeEqMat"
        '
        'ThickEqMat
        '
        Me.ThickEqMat.HeaderText = "Thick"
        Me.ThickEqMat.MinimumWidth = 6
        Me.ThickEqMat.Name = "ThickEqMat"
        '
        'PriceEqMat
        '
        Me.PriceEqMat.HeaderText = "Price"
        Me.PriceEqMat.MinimumWidth = 6
        Me.PriceEqMat.Name = "PriceEqMat"
        '
        'DescriptionEqMat
        '
        Me.DescriptionEqMat.HeaderText = "Description"
        Me.DescriptionEqMat.MinimumWidth = 6
        Me.DescriptionEqMat.Name = "DescriptionEqMat"
        '
        'TabPage12
        '
        Me.TabPage12.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.TabPage12.Controls.Add(Me.TableLayoutPanel25)
        Me.TabPage12.Location = New System.Drawing.Point(4, 25)
        Me.TabPage12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Size = New System.Drawing.Size(1275, 264)
        Me.TabPage12.TabIndex = 11
        Me.TabPage12.Text = "PP Fitting MAT"
        '
        'TableLayoutPanel25
        '
        Me.TableLayoutPanel25.ColumnCount = 3
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.0!))
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel25.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.0!))
        Me.TableLayoutPanel25.Controls.Add(Me.btnExcelPPFittingMaterial, 1, 0)
        Me.TableLayoutPanel25.Controls.Add(Me.Panel19, 0, 0)
        Me.TableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel25.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel25.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel25.Name = "TableLayoutPanel25"
        Me.TableLayoutPanel25.RowCount = 1
        Me.TableLayoutPanel25.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel25.Size = New System.Drawing.Size(1275, 264)
        Me.TableLayoutPanel25.TabIndex = 1
        '
        'btnExcelPPFittingMaterial
        '
        Me.btnExcelPPFittingMaterial.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnExcelPPFittingMaterial.FlatAppearance.BorderSize = 0
        Me.btnExcelPPFittingMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnExcelPPFittingMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcelPPFittingMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelPPFittingMaterial.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExcelPPFittingMaterial.Image = Global.AVT_TRAKING.My.Resources.Resources.excel
        Me.btnExcelPPFittingMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelPPFittingMaterial.Location = New System.Drawing.Point(941, 4)
        Me.btnExcelPPFittingMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcelPPFittingMaterial.Name = "btnExcelPPFittingMaterial"
        Me.btnExcelPPFittingMaterial.Size = New System.Drawing.Size(124, 43)
        Me.btnExcelPPFittingMaterial.TabIndex = 35
        Me.btnExcelPPFittingMaterial.Text = "Upload"
        Me.btnExcelPPFittingMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelPPFittingMaterial.UseVisualStyleBackColor = True
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.tblPPFittingMaterial)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Panel19.Location = New System.Drawing.Point(4, 4)
        Me.Panel19.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(929, 256)
        Me.Panel19.TabIndex = 36
        '
        'tblPPFittingMaterial
        '
        Me.tblPPFittingMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tblPPFittingMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblPPFittingMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idSizePPFM, Me.idTypePPFM, Me.idThickPPFM, Me.idFittingPPFM, Me.SizePPFM, Me.TypePPFM, Me.ThickPPFM, Me.FittingPPFM, Me.PricePPFM, Me.DescriptionPPFM})
        Me.tblPPFittingMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPPFittingMaterial.Location = New System.Drawing.Point(0, 0)
        Me.tblPPFittingMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tblPPFittingMaterial.Name = "tblPPFittingMaterial"
        Me.tblPPFittingMaterial.RowHeadersWidth = 51
        Me.tblPPFittingMaterial.Size = New System.Drawing.Size(929, 256)
        Me.tblPPFittingMaterial.TabIndex = 36
        '
        'idSizePPFM
        '
        Me.idSizePPFM.HeaderText = "idSize"
        Me.idSizePPFM.MinimumWidth = 6
        Me.idSizePPFM.Name = "idSizePPFM"
        Me.idSizePPFM.Visible = False
        '
        'idTypePPFM
        '
        Me.idTypePPFM.HeaderText = "idType"
        Me.idTypePPFM.MinimumWidth = 6
        Me.idTypePPFM.Name = "idTypePPFM"
        Me.idTypePPFM.Visible = False
        '
        'idThickPPFM
        '
        Me.idThickPPFM.HeaderText = "idThick"
        Me.idThickPPFM.MinimumWidth = 6
        Me.idThickPPFM.Name = "idThickPPFM"
        Me.idThickPPFM.Visible = False
        '
        'idFittingPPFM
        '
        Me.idFittingPPFM.HeaderText = "idFitting"
        Me.idFittingPPFM.MinimumWidth = 6
        Me.idFittingPPFM.Name = "idFittingPPFM"
        Me.idFittingPPFM.Visible = False
        '
        'SizePPFM
        '
        Me.SizePPFM.HeaderText = "Size"
        Me.SizePPFM.MinimumWidth = 6
        Me.SizePPFM.Name = "SizePPFM"
        '
        'TypePPFM
        '
        Me.TypePPFM.HeaderText = "Type"
        Me.TypePPFM.MinimumWidth = 6
        Me.TypePPFM.Name = "TypePPFM"
        '
        'ThickPPFM
        '
        Me.ThickPPFM.HeaderText = "Thick"
        Me.ThickPPFM.MinimumWidth = 6
        Me.ThickPPFM.Name = "ThickPPFM"
        '
        'FittingPPFM
        '
        Me.FittingPPFM.HeaderText = "Part Fitting"
        Me.FittingPPFM.Items.AddRange(New Object() {"90°", "45°", "Bend", "TEE", "RED", "CAP", "Flange Pair", "Flange Valve", "Control Valve", "Weld Valve", "Bebel", "Cut-Out", "Support"})
        Me.FittingPPFM.MinimumWidth = 6
        Me.FittingPPFM.Name = "FittingPPFM"
        Me.FittingPPFM.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FittingPPFM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PricePPFM
        '
        Me.PricePPFM.HeaderText = "Price"
        Me.PricePPFM.MinimumWidth = 6
        Me.PricePPFM.Name = "PricePPFM"
        '
        'DescriptionPPFM
        '
        Me.DescriptionPPFM.HeaderText = "Description"
        Me.DescriptionPPFM.MinimumWidth = 6
        Me.DescriptionPPFM.Name = "DescriptionPPFM"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnDeleteFactorTbl)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Controls.Add(Me.btnSaveFactorTbl)
        Me.Panel3.Controls.Add(Me.pgbProgress)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 592)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1291, 48)
        Me.Panel3.TabIndex = 2
        '
        'btnDeleteFactorTbl
        '
        Me.btnDeleteFactorTbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteFactorTbl.FlatAppearance.BorderSize = 0
        Me.btnDeleteFactorTbl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnDeleteFactorTbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteFactorTbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteFactorTbl.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDeleteFactorTbl.Image = Global.AVT_TRAKING.My.Resources.Resources.delete
        Me.btnDeleteFactorTbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteFactorTbl.Location = New System.Drawing.Point(896, 2)
        Me.btnDeleteFactorTbl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDeleteFactorTbl.Name = "btnDeleteFactorTbl"
        Me.btnDeleteFactorTbl.Size = New System.Drawing.Size(116, 43)
        Me.btnDeleteFactorTbl.TabIndex = 32
        Me.btnDeleteFactorTbl.Text = "Delete"
        Me.btnDeleteFactorTbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDeleteFactorTbl.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(13, 16)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(67, 16)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Message:"
        '
        'btnSaveFactorTbl
        '
        Me.btnSaveFactorTbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveFactorTbl.FlatAppearance.BorderSize = 0
        Me.btnSaveFactorTbl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(79, Byte), Integer))
        Me.btnSaveFactorTbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveFactorTbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveFactorTbl.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSaveFactorTbl.Image = Global.AVT_TRAKING.My.Resources.Resources.save
        Me.btnSaveFactorTbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveFactorTbl.Location = New System.Drawing.Point(751, 2)
        Me.btnSaveFactorTbl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSaveFactorTbl.Name = "btnSaveFactorTbl"
        Me.btnSaveFactorTbl.Size = New System.Drawing.Size(120, 43)
        Me.btnSaveFactorTbl.TabIndex = 31
        Me.btnSaveFactorTbl.Text = "Save"
        Me.btnSaveFactorTbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveFactorTbl.UseVisualStyleBackColor = True
        '
        'pgbProgress
        '
        Me.pgbProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgbProgress.Location = New System.Drawing.Point(1025, 10)
        Me.pgbProgress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pgbProgress.Name = "pgbProgress"
        Me.pgbProgress.Size = New System.Drawing.Size(261, 28)
        Me.pgbProgress.TabIndex = 0
        '
        'Factors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1299, 644)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Factors"
        Me.Text = "Factors"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.tblWorkWeekScheduleLaborRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.tblPaintElevation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.tblScafElevation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.tblSCFUnitsRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.tblEnviroment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.TableLayoutPanel16.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        CType(Me.tblPpInsUnitRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.TableLayoutPanel15.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        CType(Me.tblEqInsUnitRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TableLayoutPanel17.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.TableLayoutPanel18.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        CType(Me.tblJacketPp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.TableLayoutPanel19.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        CType(Me.tblJacketEq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.TableLayoutPanel13.ResumeLayout(False)
        CType(Me.tblPpPaintUnitRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.TableLayoutPanel12.ResumeLayout(False)
        CType(Me.tblEqPaintUnitRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        CType(Me.tblInsFitting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        CType(Me.tblPntFitting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        Me.TableLayoutPanel21.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.TableLayoutPanel22.ResumeLayout(False)
        CType(Me.tblPipingIRHC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox16.ResumeLayout(False)
        Me.TableLayoutPanel23.ResumeLayout(False)
        CType(Me.tblEquipmentIRHC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage10.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.TableLayoutPanel20.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        CType(Me.tblPipingMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage11.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.TableLayoutPanel24.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        CType(Me.tblEquipmentMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage12.ResumeLayout(False)
        Me.TableLayoutPanel25.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        CType(Me.tblPPFittingMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents tblWorkWeekScheduleLaborRates As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents tblPaintElevation As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents tblScafElevation As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents lblMessage As Label
    Friend WithEvents pgbProgress As ProgressBar
    Friend WithEvents btnSaveWWSLR As Button
    Friend WithEvents btnDropWWSLR As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnExcelTblElevationPaint As Button
    Friend WithEvents btnExcelTblElvationFactor As Button
    Friend WithEvents btnDeleteFactorTbl As Button
    Friend WithEvents btnSaveFactorTbl As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents idElevationPaint As DataGridViewTextBoxColumn
    Friend WithEvents ElevationPaint As DataGridViewTextBoxColumn
    Friend WithEvents Increment As DataGridViewTextBoxColumn
    Friend WithEvents idElevationSCF As DataGridViewTextBoxColumn
    Friend WithEvents ElevationSCF As DataGridViewTextBoxColumn
    Friend WithEvents IncrementSCF As DataGridViewTextBoxColumn
    Friend WithEvents IdLaborRate As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents InsulRate As DataGridViewTextBoxColumn
    Friend WithEvents AbatRate As DataGridViewTextBoxColumn
    Friend WithEvents PaintRate As DataGridViewTextBoxColumn
    Friend WithEvents ScafRate As DataGridViewTextBoxColumn
    Friend WithEvents Panel10 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents btnExcelScaffoldUnitRates As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents tblSCFUnitsRates As DataGridView
    Friend WithEvents IdUnitRate As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionURSCF As DataGridViewTextBoxColumn
    Friend WithEvents BuildPercent As DataGridViewTextBoxColumn
    Friend WithEvents LaborProdBuild As DataGridViewTextBoxColumn
    Friend WithEvents MaterialBuild As DataGridViewTextBoxColumn
    Friend WithEvents EquipmentBuild As DataGridViewTextBoxColumn
    Friend WithEvents DimantlePercent As DataGridViewTextBoxColumn
    Friend WithEvents LaborProdDis As DataGridViewTextBoxColumn
    Friend WithEvents MaterialDis As DataGridViewTextBoxColumn
    Friend WithEvents EquipmentDis As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents btnExcelSCFEnviroment As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents tblEnviroment As DataGridView
    Friend WithEvents idEnviroment As DataGridViewTextBoxColumn
    Friend WithEvents Enviroment As DataGridViewTextBoxColumn
    Friend WithEvents RevitionDueDay As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents btnExcelInsFitting As Button
    Friend WithEvents tblInsFitting As DataGridView
    Friend WithEvents typeId As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Support As DataGridViewTextBoxColumn
    Friend WithEvents p90 As DataGridViewTextBoxColumn
    Friend WithEvents p45 As DataGridViewTextBoxColumn
    Friend WithEvents Bend As DataGridViewTextBoxColumn
    Friend WithEvents TEE As DataGridViewTextBoxColumn
    Friend WithEvents RED As DataGridViewTextBoxColumn
    Friend WithEvents CAP As DataGridViewTextBoxColumn
    Friend WithEvents FlangePair As DataGridViewTextBoxColumn
    Friend WithEvents FlangeVlv As DataGridViewTextBoxColumn
    Friend WithEvents ControlVlv As DataGridViewTextBoxColumn
    Friend WithEvents WeldVlv As DataGridViewTextBoxColumn
    Friend WithEvents Bebel As DataGridViewTextBoxColumn
    Friend WithEvents CutOut As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents btnExcelPnpFitting As Button
    Friend WithEvents tblPntFitting As DataGridView
    Friend WithEvents idOption As DataGridViewTextBoxColumn
    Friend WithEvents PaintOption As DataGridViewTextBoxColumn
    Friend WithEvents p90p As DataGridViewTextBoxColumn
    Friend WithEvents p45p As DataGridViewTextBoxColumn
    Friend WithEvents TEEp As DataGridViewTextBoxColumn
    Friend WithEvents FlangePairp As DataGridViewTextBoxColumn
    Friend WithEvents FlangeVlvp As DataGridViewTextBoxColumn
    Friend WithEvents ControlVlvp As DataGridViewTextBoxColumn
    Friend WithEvents WeldedVlvp As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel11 As TableLayoutPanel
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents TableLayoutPanel13 As TableLayoutPanel
    Friend WithEvents btnExcelPpPntUnitRate As Button
    Friend WithEvents tblPpPaintUnitRate As DataGridView
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents TableLayoutPanel12 As TableLayoutPanel
    Friend WithEvents btnExcelEqPntUnitRate As Button
    Friend WithEvents tblEqPaintUnitRate As DataGridView
    Friend WithEvents SystemEqId As DataGridViewTextBoxColumn
    Friend WithEvents OptionEQId As DataGridViewTextBoxColumn
    Friend WithEvents SystemEq As DataGridViewTextBoxColumn
    Friend WithEvents OptionEq As DataGridViewTextBoxColumn
    Friend WithEvents laborProdEq As DataGridViewTextBoxColumn
    Friend WithEvents materialRateEq As DataGridViewTextBoxColumn
    Friend WithEvents eqRateEq As DataGridViewTextBoxColumn
    Friend WithEvents systemPPId As DataGridViewTextBoxColumn
    Friend WithEvents optionPPId As DataGridViewTextBoxColumn
    Friend WithEvents sizePPId As DataGridViewTextBoxColumn
    Friend WithEvents SystemPP As DataGridViewTextBoxColumn
    Friend WithEvents optionPP As DataGridViewTextBoxColumn
    Friend WithEvents sizePP As DataGridViewTextBoxColumn
    Friend WithEvents laborProdPP As DataGridViewTextBoxColumn
    Friend WithEvents matRatePP As DataGridViewTextBoxColumn
    Friend WithEvents eqRatePP As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel14 As TableLayoutPanel
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents TableLayoutPanel16 As TableLayoutPanel
    Friend WithEvents btnExcelUpdatePpInsUR As Button
    Friend WithEvents Panel14 As Panel
    Friend WithEvents tblPpInsUnitRate As DataGridView
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents TableLayoutPanel15 As TableLayoutPanel
    Friend WithEvents btnExcelUpdateEqInsUR As Button
    Friend WithEvents Panel13 As Panel
    Friend WithEvents tblEqInsUnitRate As DataGridView
    Friend WithEvents TableLayoutPanel17 As TableLayoutPanel
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents TableLayoutPanel18 As TableLayoutPanel
    Friend WithEvents btnExcelJacketPp As Button
    Friend WithEvents Panel15 As Panel
    Friend WithEvents tblJacketPp As DataGridView
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents TableLayoutPanel19 As TableLayoutPanel
    Friend WithEvents btnExcelJacketEq As Button
    Friend WithEvents Panel16 As Panel
    Friend WithEvents tblJacketEq As DataGridView
    Friend WithEvents idJacket As DataGridViewTextBoxColumn
    Friend WithEvents JacketType As DataGridViewTextBoxColumn
    Friend WithEvents jacketName As DataGridViewTextBoxColumn
    Friend WithEvents laborProdJckEq As DataGridViewTextBoxColumn
    Friend WithEvents matFactorJckEq As DataGridViewTextBoxColumn
    Friend WithEvents eqFactorJckEq As DataGridViewTextBoxColumn
    Friend WithEvents idJacketPp As DataGridViewTextBoxColumn
    Friend WithEvents JacketTypePp As DataGridViewTextBoxColumn
    Friend WithEvents jacketNamePp As DataGridViewTextBoxColumn
    Friend WithEvents laborProdJckPp As DataGridViewTextBoxColumn
    Friend WithEvents matFactorJckPp As DataGridViewTextBoxColumn
    Friend WithEvents eqFactorJckPp As DataGridViewTextBoxColumn
    Friend WithEvents idSizePpIUR As DataGridViewTextBoxColumn
    Friend WithEvents idTypePpIUR As DataGridViewTextBoxColumn
    Friend WithEvents idThickPpIUR As DataGridViewTextBoxColumn
    Friend WithEvents SizePpIUR As DataGridViewTextBoxColumn
    Friend WithEvents typePpIUR As DataGridViewTextBoxColumn
    Friend WithEvents thickPpIUR As DataGridViewTextBoxColumn
    Friend WithEvents laborProdPpIUR As DataGridViewTextBoxColumn
    Friend WithEvents matRatePpIUR As DataGridViewTextBoxColumn
    Friend WithEvents eqRatePpIUR As DataGridViewTextBoxColumn
    Friend WithEvents idTypeEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents idThickEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents typeEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents ThickEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents laborProdEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents matRateEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents eqRateEQIUR As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents TableLayoutPanel20 As TableLayoutPanel
    Friend WithEvents btnExcelPipingMaterial As Button
    Friend WithEvents tblPipingMaterial As DataGridView
    Friend WithEvents idSizeMat As DataGridViewTextBoxColumn
    Friend WithEvents idTypeMat As DataGridViewTextBoxColumn
    Friend WithEvents idThickMat As DataGridViewTextBoxColumn
    Friend WithEvents SizeMat As DataGridViewTextBoxColumn
    Friend WithEvents TypeMat As DataGridViewTextBoxColumn
    Friend WithEvents ThickMat As DataGridViewTextBoxColumn
    Friend WithEvents PriceMat As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionMat As DataGridViewTextBoxColumn
    Friend WithEvents Panel17 As Panel
    Friend WithEvents TableLayoutPanel21 As TableLayoutPanel
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents TableLayoutPanel22 As TableLayoutPanel
    Friend WithEvents btnExcelPipingIRHC As Button
    Friend WithEvents tblPipingIRHC As DataGridView
    Friend WithEvents idSizePPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents idTypePPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents idThicknessPPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents SizePPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents TypePPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents ThicknessPPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents LaborProdPPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents MaterialRatePPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents EquipmentRatePPIRHC As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents TableLayoutPanel23 As TableLayoutPanel
    Friend WithEvents btnExcelEquipmentIRHC As Button
    Friend WithEvents tblEquipmentIRHC As DataGridView
    Friend WithEvents idTypeEqIRHC As DataGridViewTextBoxColumn
    Friend WithEvents idThickIEqRHC As DataGridViewTextBoxColumn
    Friend WithEvents TypeEqIRHC As DataGridViewTextBoxColumn
    Friend WithEvents ThicknessEqIRHC As DataGridViewTextBoxColumn
    Friend WithEvents LaborProdEqIRHC As DataGridViewTextBoxColumn
    Friend WithEvents MaterialRateEqIRHC As DataGridViewTextBoxColumn
    Friend WithEvents EquipmentEqIRHC As DataGridViewTextBoxColumn
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents GroupBox17 As GroupBox
    Friend WithEvents TableLayoutPanel24 As TableLayoutPanel
    Friend WithEvents btnExcelTblEquipmentMaterial As Button
    Friend WithEvents Panel18 As Panel
    Friend WithEvents tblEquipmentMaterial As DataGridView
    Friend WithEvents idTypeEqMat As DataGridViewTextBoxColumn
    Friend WithEvents idThickEqMat As DataGridViewTextBoxColumn
    Friend WithEvents TypeEqMat As DataGridViewTextBoxColumn
    Friend WithEvents ThickEqMat As DataGridViewTextBoxColumn
    Friend WithEvents PriceEqMat As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionEqMat As DataGridViewTextBoxColumn
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents TableLayoutPanel25 As TableLayoutPanel
    Friend WithEvents btnExcelPPFittingMaterial As Button
    Friend WithEvents Panel19 As Panel
    Friend WithEvents tblPPFittingMaterial As DataGridView
    Friend WithEvents idSizePPFM As DataGridViewTextBoxColumn
    Friend WithEvents idTypePPFM As DataGridViewTextBoxColumn
    Friend WithEvents idThickPPFM As DataGridViewTextBoxColumn
    Friend WithEvents idFittingPPFM As DataGridViewTextBoxColumn
    Friend WithEvents SizePPFM As DataGridViewTextBoxColumn
    Friend WithEvents TypePPFM As DataGridViewTextBoxColumn
    Friend WithEvents ThickPPFM As DataGridViewTextBoxColumn
    Friend WithEvents FittingPPFM As DataGridViewComboBoxColumn
    Friend WithEvents PricePPFM As DataGridViewTextBoxColumn
    Friend WithEvents DescriptionPPFM As DataGridViewTextBoxColumn
End Class
