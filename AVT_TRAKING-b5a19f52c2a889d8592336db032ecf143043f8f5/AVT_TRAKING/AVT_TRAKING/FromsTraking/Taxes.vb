Imports System.Runtime.InteropServices
Public Class Taxes
    Dim mtdTX As New MetodosTaxes
    Dim tx As New TaxesClass
    Public task As String = ""
    Public idTask As String = ""
    Public wo As String = ""
    Public idWO As String = ""
    Public po As String = ""
    Public job As String = ""
    Public totalHoursJob As Decimal()
    Dim loadingData As Boolean
    Dim arraySprST(18) As NumericUpDown
    Dim arraySprPT(3) As NumericUpDown
    Private Sub Taxes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTask.Text = If(job = "", "", job)
        tblTaxesST.Rows.Add("Foreman", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesST.Rows.Add("Journeyman", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesST.Rows.Add("Craftsman", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesST.Rows.Add("Apprentise", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesST.Rows.Add("Helper", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblAverage.Rows.Add("$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "0.00")
        tblTaxesPT.Rows.Add("Foreman", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesPT.Rows.Add("Journeyman", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesPT.Rows.Add("Craftsman", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesPT.Rows.Add("Apprentice", "$0.00", "$0.00", "$0.00", "$0.00")
        tblTaxesPT.Rows.Add("Helper", "$0.00", "$0.00", "$0.00", "$0.00")
        tblAverageP.Rows.Add("$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblWkly.Rows.Add("$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        tblWkly.Rows.Add("$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00", "$0.00")
        arraySprST = {sprFICA, sprFUI, sprSUI, sprWC, sprGenLiab, sprUmbr, sprPollution, sprHealt, sprFringe, sprSmall, sprPPE, sprConsumable, sprScaffold, sprYoYos, sprMesh, sprMiselaneos, sprOverhead, sprProfit}
        arraySprPT = {sprFicaP, sprFUIP, sprSUIP}
        If task <> "" Then
            tx = mtdTX.selectTaxes(job)
            cargardatosTaxes(tx)
        Else
            btnSave.Enabled = False
        End If
    End Sub
    Private Function cargardatosTaxes(ByVal taxes As TaxesClass) As Boolean
        Try
            'loadingData = False
            sprFICA.Value = taxes.FICA
            sprFUI.Value = taxes.FUI
            sprSUI.Value = taxes.SUI
            sprWC.Value = taxes.WC
            sprGenLiab.Value = taxes.GenLiab
            sprUmbr.Value = taxes.Umbr
            sprPollution.Value = taxes.Pollution
            sprHealt.Value = taxes.Healt
            sprFringe.Value = taxes.Fringe
            sprSmall.Value = taxes.Small
            sprPPE.Value = taxes.PPE
            sprConsumable.Value = taxes.Consumable
            sprScaffold.Value = taxes.Scaffold
            sprYoYos.Value = taxes.YoYos
            sprMesh.Value = taxes.Mesh
            sprMiselaneos.Value = taxes.Miselaneos
            sprOverhead.Value = taxes.Overhead
            sprProfit.Value = taxes.Profit
            sprBWForeman.Value = taxes.BWForeman
            sprBWJourneyman.Value = taxes.BWJourneyman
            sprBWCraftsman.Value = taxes.BWCraftsman
            sprBWApprentice.Value = taxes.BWApprentice
            sprBWHelper.Value = taxes.BWHelper
            sprQtyForeman.Value = taxes.QtyForeman
            sprQtyJourneyman.Value = taxes.QtyJourneyman
            sprQtyCraftsman.Value = taxes.QtyCraftsman
            sprQtyApprentice.Value = taxes.QtyApprentice
            sprQtyHelper.Value = taxes.QtyHelper

            sprFicaP.Value = taxes.FICAP
            sprFUIP.Value = taxes.FUIP
            sprSUIP.Value = taxes.SUIP
            sprBWForemanP.Value = taxes.BWForemanP
            sprBWJourneymanP.Value = taxes.BWJourneymanP
            sprBWCraftsmanP.Value = taxes.BWCraftsmanP
            sprBWApprenticeP.Value = taxes.BWApprenticeP
            sprBWHelperP.Value = taxes.BWHelperP
            sprBWCraftsmanP.Value = taxes.BWCraftsmanP
            sprQtyForemanP.Value = taxes.QtyForemanP
            sprQtyJourneymanP.Value = taxes.QtyJourneymanP
            sprQtyCraftsmanP.Value = taxes.QtyCraftsmanP
            sprQtyApprenticeP.Value = taxes.QtyApprenticeP
            loadingData = False
            sprQtyHelperP.Value = taxes.QtyHelperP

            dtpBeginDate.Value = tx.BeginDaTe
            dtpEndDate.Value = tx.EndDate
            sprHours.Value = tx.TotalHours

            Dim horas = mtdTX.selectTotalHoursCount(job, tx.BeginDaTe, tx.EndDate)

            sprHours.Value = horas(0)
            sprHoursST.Value = horas(1)
            sprHoursOT.Value = horas(2)

            calcularPTTotal()
            calcularSTTotal()
            calcularFilaWklyAV()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcularPorcentaje(ByVal columnName As String, ByVal moneyF As Decimal, ByVal moneyJ As Decimal, ByVal moneyC As Decimal, ByVal moneyA As Decimal, ByVal moneyH As Decimal, ByVal percent As Decimal) As Boolean
        Try
            If tblTaxesST.Columns(columnName).Index <= 12 Or tblTaxesST.Columns(columnName).Index > 16 Then
                tblTaxesST.Rows(0).Cells(columnName).Value = "$" + Decimal.Round(((moneyF * percent) / 100), 2).ToString
                tblTaxesST.Rows(1).Cells(columnName).Value = "$" + Decimal.Round(((moneyJ * percent) / 100), 2).ToString
                tblTaxesST.Rows(2).Cells(columnName).Value = "$" + Decimal.Round(((moneyC * percent) / 100), 2).ToString
                tblTaxesST.Rows(3).Cells(columnName).Value = "$" + Decimal.Round(((moneyA * percent) / 100), 2).ToString
                tblTaxesST.Rows(4).Cells(columnName).Value = "$" + Decimal.Round(((moneyH * percent) / 100), 2).ToString
            Else
                tblTaxesST.Rows(0).Cells(columnName).Value = "$" + Decimal.Round((moneyF * percent), 2).ToString
                tblTaxesST.Rows(1).Cells(columnName).Value = "$" + Decimal.Round((moneyJ * percent), 2).ToString
                tblTaxesST.Rows(2).Cells(columnName).Value = "$" + Decimal.Round((moneyC * percent), 2).ToString
                tblTaxesST.Rows(3).Cells(columnName).Value = "$" + Decimal.Round((moneyA * percent), 2).ToString
                tblTaxesST.Rows(4).Cells(columnName).Value = "$" + Decimal.Round((moneyH * percent), 2).ToString
            End If
            calcularSTTotal()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub sprST_ValueChanged(sender As Object, e As EventArgs) Handles sprYoYos.ValueChanged, sprWC.ValueChanged, sprUmbr.ValueChanged, sprSUI.ValueChanged, sprSmall.ValueChanged, sprScaffold.ValueChanged, sprQtyJourneyman.ValueChanged, sprQtyHelper.ValueChanged, sprQtyForeman.ValueChanged, sprQtyCraftsman.ValueChanged, sprQtyApprentice.ValueChanged, sprProfit.ValueChanged, sprPPE.ValueChanged, sprPollution.ValueChanged, sprOverhead.ValueChanged, sprMiselaneos.ValueChanged, sprMesh.ValueChanged, sprHealt.ValueChanged, sprGenLiab.ValueChanged, sprFUI.ValueChanged, sprFringe.ValueChanged, sprFICA.ValueChanged, sprConsumable.ValueChanged, sprBWJourneyman.ValueChanged, sprBWHelper.ValueChanged, sprBWForeman.ValueChanged, sprBWCraftsman.ValueChanged, sprBWApprentice.ValueChanged
        If loadingData = False Then
            Dim dineroF As Decimal = sprBWForeman.Value
            Dim dineroJ As Decimal = sprBWJourneyman.Value
            Dim dineroC As Decimal = sprBWCraftsman.Value
            Dim dineroA As Decimal = sprBWApprentice.Value
            Dim dineroH As Decimal = sprBWHelper.Value
            Select Case sender.name
                Case "sprFICA"
                    Dim percent As Decimal = sprFICA.Value
                    calcularPorcentaje("FICA", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.FICA = percent
                Case "sprFUI"
                    Dim percent As Decimal = sprFUI.Value
                    calcularPorcentaje("FUI", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.FUI = percent
                Case "sprSUI"
                    Dim percent As Decimal = sprSUI.Value
                    calcularPorcentaje("SUI", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.SUI = percent
                Case "sprWC"
                    Dim percent As Decimal = sprWC.Value
                    calcularPorcentaje("WC", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.WC = percent
                Case "sprGenLiab"
                    Dim percent As Decimal = sprGenLiab.Value
                    calcularPorcentaje("GenLiab", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.GenLiab = percent
                Case "sprUmbr"
                    Dim percent As Decimal = sprUmbr.Value
                    calcularPorcentaje("Umbr", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Umbr = percent
                Case "sprPollution"
                    Dim percent As Decimal = sprPollution.Value
                    calcularPorcentaje("Pollution", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Pollution = percent
                Case "sprHealt"
                    Dim percent As Decimal = sprHealt.Value
                    calcularPorcentaje("Healt", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Healt = percent
                Case "sprFringe"
                    Dim percent As Decimal = sprFringe.Value
                    calcularPorcentaje("Fringe", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Fringe = percent
                Case "sprSmall"
                    Dim percent As Decimal = sprSmall.Value
                    calcularPorcentaje("Small", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Small = percent
                Case "sprPPE"
                    Dim percent As Decimal = sprPPE.Value
                    calcularPorcentaje("PPE", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.PPE = percent
                Case "sprConsumable"
                    Dim percent As Decimal = sprConsumable.Value
                    calcularPorcentaje("Consumable", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Consumable = percent
                Case "sprScaffold"
                    Dim percent As Decimal = sprScaffold.Value
                    calcularPorcentaje("Scaffold", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Scaffold = percent
                Case "sprYoYos"
                    Dim percent As Decimal = sprYoYos.Value
                    calcularPorcentaje("Yoyos", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.YoYos = percent
                Case "sprMesh"
                    Dim percent As Decimal = sprMesh.Value
                    calcularPorcentaje("Mesh", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Mesh = percent
                Case "sprMiselaneos"
                    Dim percent As Decimal = sprMiselaneos.Value
                    calcularPorcentaje("Miselaneos", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Miselaneos = percent
                Case "sprOverhead"
                    Dim percent As Decimal = sprOverhead.Value
                    calcularPorcentaje("OverHead", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Overhead = percent
                Case "sprProfit"
                    Dim percent As Decimal = sprProfit.Value
                    calcularPorcentaje("Profit", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                    calcularSTTotal()
                    tx.Profit = percent
            '################################# MONEY ##################################################################
                Case "sprBWForeman"
                    llenarFilaBW(sprBWForeman, 0)
                    tx.BWForeman = sprBWForeman.Value
                Case "sprBWJourneyman"
                    llenarFilaBW(sprBWJourneyman, 1)
                    tx.BWJourneyman = sprBWJourneyman.Value
                Case "sprBWCraftsman"
                    llenarFilaBW(sprBWCraftsman, 2)
                    tx.BWCraftsman = sprBWCraftsman.Value
                Case "sprBWApprentice"
                    llenarFilaBW(sprBWApprentice, 3)
                    tx.BWApprentice = sprBWApprentice.Value
                Case "sprBWHelper"
                    llenarFilaBW(sprBWHelper, 4)
                    tx.BWHelper = sprBWHelper.Value
            '################################# QTY ####################################################################
                Case "sprQtyForeman"
                    tx.QtyForeman = sprQtyForeman.Value
                Case "sprQtyJourneyman"
                    tx.QtyJourneyman = sprQtyJourneyman.Value
                Case "sprQtyCraftsman"
                    tx.QtyCraftsman = sprQtyCraftsman.Value
                Case "sprQtyApprentice"
                    tx.QtyApprentice = sprQtyApprentice.Value
                Case "sprQtyHelper"
                    tx.QtyHelper = sprQtyHelper.Value
            End Select
            calcularSTTotal()
            calcualarAverge()
            calcularFilaWklyAV()
        End If
    End Sub
    Private Function calcularSTTotal() As Boolean
        Try
            calcularSTTotal(0, sprBWForeman)
            calcularSTTotal(1, sprBWJourneyman)
            calcularSTTotal(2, sprBWCraftsman)
            calcularSTTotal(3, sprBWApprentice)
            calcularSTTotal(4, sprBWHelper)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcularSTTotal(ByVal rowIndex As Integer, ByVal spr As NumericUpDown) As Boolean
        Try
            Dim total As Decimal = spr.Value
            For Each cell As DataGridViewCell In tblTaxesST.Rows(rowIndex).Cells()
                If Not cell.ColumnIndex = tblTaxesST.Columns("STTOTAL").Index And Not cell.ColumnIndex = tblTaxesST.Columns("clmEmployee").Index Then
                    Dim array() As String = cell.Value.ToString().Split("$")
                    Dim val As Decimal = CDec(array(1))
                    total = total + val
                ElseIf cell.ColumnIndex = tblTaxesST.Columns("STTOTAL").Index Then
                    cell.Value = "$" + Decimal.Round(total, 2).ToString()
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function llenarFilaBW(ByVal spr As NumericUpDown, ByVal row As Integer) As Boolean
        Try
            Dim bw As Decimal = spr.Value
            Dim cont As Integer = 0
            Dim total = spr.Value
            For Each cell As DataGridViewCell In tblTaxesST.Rows(row).Cells()
                If cell.ColumnIndex > 0 And Not cell.ColumnIndex = tblTaxesST.Columns("STTOTAL").Index Then
                    Dim percent As Decimal = arraySprST(cont).Value
                    If cell.ColumnIndex <= 12 Or cell.ColumnIndex > 16 Then
                        cell.Value = "$" + Decimal.Round(((bw * percent) / 100), 2).ToString()
                        total = total + ((bw * percent) / 100)
                    Else
                        cell.Value = "$" + Decimal.Round(((bw * percent)), 2).ToString()
                        total = total + ((bw * percent))
                    End If
                    cont += 1
                ElseIf cell.ColumnIndex = tblTaxesST.Columns("STTOTAL").Index Then
                    cell.Value = "$" + Decimal.Round(total, 2).ToString()
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcualarAverge() As Integer
        Try
            Dim CostForeman As Decimal = tx.QtyForeman * tx.BWForeman
            Dim CostJourneyman As Decimal = tx.QtyJourneyman * tx.BWJourneyman
            Dim CostCraftsman As Decimal = tx.QtyCraftsman * tx.BWCraftsman
            Dim CostApprentice As Decimal = tx.QtyApprentice * tx.BWApprentice
            Dim CostHellper As Decimal = tx.QtyHelper * tx.BWHelper
            Dim totalCostAverge As Decimal = (((CostApprentice + CostHellper + CostCraftsman + CostJourneyman + CostForeman) / (tx.QtyForeman + tx.QtyJourneyman + tx.QtyCraftsman + tx.QtyApprentice + tx.QtyHelper))).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("EmployeeBW").Value = "$" + totalCostAverge.ToString()
            tblAverage.Rows(0).Cells("FICAAV").Value = "$" + (CDec((totalCostAverge * tx.FICA) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("FUIAV").Value = "$" + (CDec((totalCostAverge * tx.FUI) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("SUIAV").Value = "$" + (CDec((totalCostAverge * tx.SUI) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("WCAV").Value = "$" + (CDec((totalCostAverge * tx.WC) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("GenLiabAV").Value = "$" + (CDec((totalCostAverge * tx.GenLiab) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("UmbrAV").Value = "$" + (CDec((totalCostAverge * tx.Umbr) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("PullutionAV").Value = "$" + (CDec((totalCostAverge * tx.Pollution) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("HealtAV").Value = "$" + (CDec((totalCostAverge * tx.Healt) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("FringeAV").Value = "$" + (CDec((totalCostAverge * tx.Fringe) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("SmallAV").Value = "$" + (CDec((totalCostAverge * tx.Small) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("PPEAV").Value = "$" + (CDec((totalCostAverge * tx.PPE) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("ConsumableAV").Value = "$" + (CDec((totalCostAverge * tx.Consumable) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("ScaffoldAV").Value = "$" + (CDec(tx.Scaffold)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("YoyosAV").Value = "$" + (CDec(tx.YoYos)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("MeshAV").Value = "$" + (CDec(tx.Mesh)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("MiselaneosAV").Value = "$" + (CDec(tx.Miselaneos)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("OverheadAV").Value = "$" + (CDec((totalCostAverge * tx.Overhead) / 100)).ToString("#,##0.00")
            tblAverage.Rows(0).Cells("ProfitAV").Value = "$" + (CDec((totalCostAverge * tx.Profit) / 100)).ToString("#,##0.00")
            Dim STTotalAverge As Decimal = 0.00
            For Each cell As DataGridViewCell In tblAverage.Rows(0).Cells()
                If Not cell.ColumnIndex = tblAverage.Columns("STTOTALAV").Index Then
                    Dim array() As String = cell.Value.ToString.Split("$")
                    Dim val As Decimal = CDec(array(1))
                    STTotalAverge = STTotalAverge + val
                End If
            Next
            tblAverage.Rows(0).Cells("STTOTALAV").Value = "$" + (STTotalAverge).ToString("#,##0.00")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    '##########################################################################################################################################################################
    '####################### BREAK DOWN PT ####################################################################################################################################
    '##########################################################################################################################################################################
    Private Sub sprFicaP_ValueChanged(sender As Object, e As EventArgs) Handles sprQtyCraftsmanP.ValueChanged, sprSUIP.ValueChanged, sprQtyJourneymanP.ValueChanged, sprQtyHelperP.ValueChanged, sprQtyForemanP.ValueChanged, sprQtyApprenticeP.ValueChanged, sprFUIP.ValueChanged, sprFicaP.ValueChanged, sprBWJourneymanP.ValueChanged, sprBWHelperP.ValueChanged, sprBWForemanP.ValueChanged, sprBWCraftsmanP.ValueChanged, sprBWApprenticeP.ValueChanged
        If loadingData = False Then
            Try
                Dim dineroF As Decimal = sprBWForemanP.Value
                Dim dineroJ As Decimal = sprBWJourneymanP.Value
                Dim dineroC As Decimal = sprBWCraftsmanP.Value
                Dim dineroA As Decimal = sprBWApprenticeP.Value
                Dim dineroH As Decimal = sprBWHelperP.Value
                Select Case sender.name
                    Case "sprFicaP"
                        Dim percent As Decimal = sprFicaP.Value
                        calcularPorcentajeP("FICAP", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                        calcularPTTotal()
                        tx.FICAP = percent
                    Case "sprFUIP"
                        Dim percent As Decimal = sprFUIP.Value
                        calcularPorcentajeP("FUIP", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                        calcularPTTotal()
                        tx.FUIP = percent
                    Case "sprSUIP"
                        Dim percent As Decimal = sprSUIP.Value
                        calcularPorcentajeP("SUIP", dineroF, dineroJ, dineroC, dineroA, dineroH, percent)
                        calcularPTTotal()
                        tx.SUIP = percent
                    '##########################################################################################
                    Case "sprBWForemanP"
                        llenarFilaBWP(sprBWForemanP, 0)
                        tx.BWForemanP = sprBWForemanP.Value
                    Case "sprBWJourneymanP"
                        llenarFilaBWP(sprBWJourneymanP, 1)
                        tx.BWJourneymanP = sprBWJourneymanP.Value
                    Case "sprBWCraftsmanP"
                        llenarFilaBWP(sprBWCraftsmanP, 2)
                        tx.BWCraftsmanP = sprBWCraftsmanP.Value
                    Case "sprBWApprenticeP"
                        llenarFilaBWP(sprBWApprenticeP, 3)
                        tx.BWApprenticeP = sprBWApprenticeP.Value
                    Case "sprBWHelperP"
                        llenarFilaBWP(sprBWHelperP, 4)
                        tx.BWHelperP = sprBWHelperP.Value
                    '##########################################################################################
                    Case "sprQtyForemanP"
                        tx.QtyForemanP = sprQtyForemanP.Value
                    Case "sprQtyJourneymanP"
                        tx.QtyJourneymanP = sprQtyJourneymanP.Value
                    Case "sprQtyCraftsmanP"
                        tx.QtyCraftsmanP = sprQtyCraftsmanP.Value
                    Case "sprQtyApprenticeP"
                        tx.QtyApprenticeP = sprQtyApprenticeP.Value
                    Case "sprQtyHelperP"
                        tx.QtyHelperP = sprQtyHelperP.Value
                End Select
                calcualarAvergePT()
                calcularFilaWklyAV()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Function calcularPorcentajeP(ByVal columnName As String, ByVal moneyF As Decimal, ByVal moneyJ As Decimal, ByVal moneyC As Decimal, ByVal moneyA As Decimal, ByVal moneyH As Decimal, ByVal percent As Decimal) As Boolean
        Try
            tblTaxesPT.Rows(0).Cells(columnName).Value = "$" + Decimal.Round(((moneyF * percent) / 100), 2).ToString
            tblTaxesPT.Rows(1).Cells(columnName).Value = "$" + Decimal.Round(((moneyJ * percent) / 100), 2).ToString
            tblTaxesPT.Rows(2).Cells(columnName).Value = "$" + Decimal.Round(((moneyC * percent) / 100), 2).ToString
            tblTaxesPT.Rows(3).Cells(columnName).Value = "$" + Decimal.Round(((moneyA * percent) / 100), 2).ToString
            tblTaxesPT.Rows(4).Cells(columnName).Value = "$" + Decimal.Round(((moneyH * percent) / 100), 2).ToString
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcularPTTotal() As Boolean
        Try
            calcularPTTotal(0, sprBWForemanP)
            calcularPTTotal(1, sprBWJourneymanP)
            calcularPTTotal(2, sprBWCraftsmanP)
            calcularPTTotal(3, sprBWApprenticeP)
            calcularPTTotal(4, sprBWHelperP)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcularPTTotal(ByVal rowIndex As Integer, ByVal spr As NumericUpDown) As Boolean
        Try
            Dim total As Decimal = spr.Value
            For Each cell As DataGridViewCell In tblTaxesPT.Rows(rowIndex).Cells()
                If Not cell.ColumnIndex = tblTaxesPT.Columns("PTTOTAL").Index And Not cell.ColumnIndex = tblTaxesPT.Columns("clmEmployeeP").Index Then
                    Dim array() As String = cell.Value.ToString().Split("$")
                    Dim val As Decimal = CDec(array(1))
                    total = total + val
                ElseIf cell.ColumnIndex = tblTaxesPT.Columns("PTTOTAL").Index Then
                    cell.Value = "$" + Decimal.Round(total, 2).ToString()
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function llenarFilaBWP(ByVal spr As NumericUpDown, ByVal row As Integer) As Boolean
        Try
            Dim bw As Decimal = spr.Value
            Dim cont As Integer = 0
            Dim total = spr.Value
            For Each cell As DataGridViewCell In tblTaxesPT.Rows(row).Cells()
                If cell.ColumnIndex > 0 And Not cell.ColumnIndex = tblTaxesPT.Columns("PTTOTAL").Index Then
                    Dim percent As Decimal = arraySprPT(cont).Value
                    cell.Value = "$" + ((bw * percent) / 100).ToString("#,##0.00")
                    total = total + Math.Round(((bw * percent) / 100), 2)
                    cont += 1
                ElseIf cell.ColumnIndex = tblTaxesPT.Columns("PTTOTAL").Index Then
                    cell.Value = "$" + total.ToString("#,##0.00")
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function calcualarAvergePT() As Boolean
        Try
            Dim CostForeman As Decimal = tx.QtyForemanP * tx.BWForemanP
            Dim CostJourneyman As Decimal = tx.QtyJourneymanP * tx.BWJourneymanP
            Dim CostCraftsman As Decimal = tx.QtyCraftsmanP * tx.BWCraftsmanP
            Dim CostApprentice As Decimal = tx.QtyApprenticeP * tx.BWApprenticeP
            Dim CostHellper As Decimal = tx.QtyHelperP * tx.BWHelperP
            Dim totalCostAverge As Decimal = Decimal.Round(((CostApprentice + CostHellper + CostCraftsman + CostJourneyman + CostForeman) / (tx.QtyForemanP + tx.QtyJourneymanP + tx.QtyCraftsmanP + tx.QtyApprenticeP + tx.QtyHelperP)), 2).ToString
            tblAverageP.Rows(0).Cells("EmployeeBWP").Value = "$" + totalCostAverge.ToString()
            tblAverageP.Rows(0).Cells("FICAAVP").Value = "$" + Decimal.Round(CDec((totalCostAverge * tx.FICAP) / 100), 2).ToString()
            tblAverageP.Rows(0).Cells("FUIAVP").Value = "$" + Decimal.Round(CDec((totalCostAverge * tx.FUIP) / 100), 2).ToString()
            tblAverageP.Rows(0).Cells("SUIAVP").Value = "$" + Decimal.Round(CDec((totalCostAverge * tx.SUIP) / 100), 2).ToString()
            Dim PTTotalAverage As Decimal = 0.00
            For Each cell As DataGridViewCell In tblAverageP.Rows(0).Cells()
                If Not cell.ColumnIndex = tblAverageP.Columns("PTTOTALAV").Index Then
                    Dim array() As String = cell.Value.ToString.Split("$")
                    Dim val As Decimal = CDec(array(1))
                    PTTotalAverage = PTTotalAverage + val
                End If
            Next
            tblAverageP.Rows(0).Cells("PTTOTALAV").Value = "$" + Decimal.Round(PTTotalAverage, 2).ToString()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function calcularFilaWklyAV() As Boolean
        Try
            Dim valS As Decimal = 0.0
            Dim valP As Decimal = 0.0
            Dim sumRow0 As Decimal = 0.0
            Dim sumRow1 As Decimal = 0.0
            Dim rowST As DataGridViewRow = tblAverage.Rows(0)
            Dim rowOT As DataGridViewRow = tblAverageP.Rows(0)

            valS = CDec(rowST.Cells("EmployeeBW").Value.ToString.Replace("$", ""))
            valP = CDec(rowOT.Cells("EmployeeBWP").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("WklyBaseWage").Value = "$" + (((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("WklyBaseWage").Value = "$" + ((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)).ToString("#,##0.00")

            valS = CDec(rowST.Cells("FICAAV").Value.ToString.Replace("$", ""))
            valP = CDec(rowOT.Cells("FICAAVP").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("FicaWkly").Value = "$" + (((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("FicaWkly").Value = "$" + ((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)).ToString("#,##0.00")

            valS = CDec(rowST.Cells("FUIAV").Value.ToString.Replace("$", ""))
            valP = CDec(rowOT.Cells("FUIAVP").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("FUIWkly").Value = "$" + (((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("FUIWkly").Value = "$" + ((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)).ToString("#,##0.00")

            valS = CDec(rowST.Cells("SUIAV").Value.ToString.Replace("$", ""))
            valP = CDec(rowOT.Cells("SUIAVP").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("SUIWkly").Value = "$" + (((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("SUIWkly").Value = "$" + ((valS * sprHoursST.Value) + (valP * sprHoursOT.Value)).ToString("#,##0.00")

            valS = CDec(rowST.Cells("WCAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("WCWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("WCWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("GenLiabAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("GenLiabWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("GenLiabWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("UmbrAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("UmbrWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("UmbrWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("PullutionAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("PollutionWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("PollutionWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("HealtAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("HealtWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("HealtWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("FringeAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("FringeBinWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("FringeBinWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("SmallAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("SmallTools").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("SmallTools").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("PPEAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("PPEWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("PPEWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("ConsumableAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("ConsumablesWkly").Value = "$" + (((valS * sprHoursST.Value)) / sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("ConsumablesWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("ScaffoldAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("ScaffoldRentalWkly").Value = "$" + (sprScaffold.Value * sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("ScaffoldRentalWkly").Value = "$" + (sprScaffold.Value * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("YoyosAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("YoyosWkly").Value = "$" + (sprYoYos.Value * sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("YoyosWkly").Value = "$" + (sprYoYos.Value * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("MeshAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("MeshWkly").Value = "$" + (sprMesh.Value * sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("MeshWkly").Value = "$" + (sprMesh.Value * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("MiselaneosAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("MisWkly").Value = "$" + (sprMiselaneos.Value * sprHours.Value).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("MisWkly").Value = "$" + (sprMiselaneos.Value * sprHours.Value).ToString("#,##0.00")

            For Each column As DataGridViewColumn In tblWkly.Columns
                If Not column.Index = tblWkly.Columns("OverHeadWkly").Index Then
                    sumRow0 = sumRow0 + tblWkly.Rows(0).Cells(column.Index).Value.ToString().Replace("$", "")
                    sumRow1 = sumRow1 + tblWkly.Rows(1).Cells(column.Index).Value.ToString().Replace("$", "")
                Else
                    Exit For
                End If
            Next
            valS = CDec(rowST.Cells("OverHeadAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("OverHeadWkly").Value = "$" + (valS).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("OverHeadWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")

            valS = CDec(rowST.Cells("ProfitAV").Value.ToString.Replace("$", ""))
            tblWkly.Rows(0).Cells("ProfitWkly").Value = "$" + (valS).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("ProfitWkly").Value = "$" + (valS * sprHours.Value).ToString("#,##0.00")
            sumRow0 = sumRow0 + CDec(tblWkly.Rows(0).Cells("OverHeadWkly").Value.ToString().Replace("$", "")) + CDec(tblWkly.Rows(0).Cells("ProfitWkly").Value.ToString().Replace("$", ""))
            sumRow1 = sumRow1 + CDec(tblWkly.Rows(1).Cells("OverHeadWkly").Value.ToString().Replace("$", "")) + CDec(tblWkly.Rows(1).Cells("ProfitWkly").Value.ToString().Replace("$", ""))

            tblWkly.Rows(0).Cells("TotalWkly").Value = "$" + (sumRow0).ToString("#,##0.00")
            tblWkly.Rows(1).Cells("TotalWkly").Value = "$" + (sumRow1).ToString("#,##0.00")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    '##############################################################################################################################
    '################## CODIGO PARA EL DISENIO ####################################################################################
    '##############################################################################################################################
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        Me.WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub sprHours_ValueChanged(sender As Object, e As EventArgs) Handles sprHours.ValueChanged
        tx.TotalHours = sprHours.Value
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If mtdTX.savetaxes(tx) Then
            MsgBox("Successful.")
            tx = mtdTX.selectTaxes(tx.JobNo)
        End If
    End Sub

    Private Sub btnRefreshHours_Click(sender As Object, e As EventArgs) Handles btnRefreshHours.Click
        Try
            Dim horas = mtdTX.selectTotalHoursCount(lblTask.Text, dtpBeginDate.Value, dtpEndDate.Value)
            sprHours.Value = horas(0)
            sprHoursST.Value = horas(1)
            sprHoursOT.Value = horas(2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpBeginDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpBeginDate.ValueChanged
        Try
            tx.BeginDaTe = dtpBeginDate.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        Try
            tx.EndDate = dtpEndDate.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TableLayoutPanel10_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel10.Paint

    End Sub
End Class