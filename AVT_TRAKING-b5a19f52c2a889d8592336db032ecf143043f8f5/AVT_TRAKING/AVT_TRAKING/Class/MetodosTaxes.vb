Imports System.Data.SqlClient
Public Class MetodosTaxes
    Inherits ConnectioDB

    Function selectTaxes(ByVal JobNo As String) As TaxesClass
        Try
            Dim tx As New TaxesClass
            tx.JobNo = JobNo
            conectar()
            'Datos para ST
            Dim cmd As New SqlCommand("select top 1 * from taxesST where jobNo = '" + JobNo + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                tx.idTaxes = rd("idTaxesST")
                tx.JobNo = rd("jobNo")
                'tx.TotalHours = rd("totalHours")
                tx.FICA = rd("FICA")
                tx.FUI = rd("FUI")
                tx.SUI = rd("SUI")
                tx.WC = rd("WC")
                tx.GenLiab = rd("GenLiab")
                tx.Umbr = rd("Umbr")
                tx.Pollution = rd("Pollution")
                tx.Healt = rd("Healt")
                tx.Fringe = rd("Fringe")
                tx.Small = rd("Small")
                tx.PPE = rd("PPE")
                tx.Consumable = rd("Consumable")
                tx.Scaffold = rd("Scaffold")
                tx.YoYos = rd("YoYo")
                tx.Mesh = rd("Mesh")
                tx.Miselaneos = rd("Miselaneos")
                tx.Overhead = rd("Overhead")
                tx.Profit = rd("Profit")
                tx.BWForeman = rd("BWForeman")
                tx.BWJourneyman = rd("BWJourneyman")
                tx.BWCraftsman = rd("BWCraftsman")
                tx.BWApprentice = rd("BWApprentice")
                tx.BWHelper = rd("BWHelper")
                tx.QtyForeman = rd("QtyForeman")
                tx.QtyJourneyman = rd("QtyJourneyman")
                tx.QtyCraftsman = rd("QtyCraftsman")
                tx.QtyApprentice = rd("QtyApprentice")
                tx.QtyHelper = rd("QtyHelper")
                'tx.BeginDaTe = If(rd("beginDate") Is DBNull.Value, System.DateTime.Today, rd("beginDate"))
                'tx.EndDate = If(rd("endDate") Is DBNull.Value, System.DateTime.Today, rd("endDate"))
            End While
            rd.Close()
            'Datos para OT
            Dim cmd1 As New SqlCommand("select top 1 * from taxesPT where jobNo = '" + JobNo + "'", conn)
            Dim rd1 As SqlDataReader = cmd1.ExecuteReader()
            While rd1.Read()
                tx.idTaxesP = rd1("idTaxesPT")
                'tx.TotalHoursP = rd1("totalHours")
                tx.FICAP = rd1("FICA")
                tx.FUIP = rd1("FUI")
                tx.SUIP = rd1("SUI")
                tx.WCP = rd1("WC")
                tx.GenLiabP = rd1("GenLiab")
                tx.UmbrP = rd1("Umbr")
                tx.PollutionP = rd1("Pollution")
                tx.HealtP = rd1("Healt")
                tx.FringeP = rd1("Fringe")
                tx.SmallP = rd1("Small")
                tx.PPEP = rd1("PPE")
                tx.ConsumableP = rd1("Consumable")
                tx.ScaffoldP = rd1("Scaffold")
                tx.YoYosP = rd1("Yoyo")
                tx.MeshP = rd1("Mesh")
                tx.MiselaneosP = rd1("Miselaneos")
                tx.OverheadP = rd1("Overhead")
                tx.ProfitP = rd1("Profit")
                tx.BWForemanP = rd1("BWForeman")
                tx.BWJourneymanP = rd1("BWJourneyman")
                tx.BWCraftsmanP = rd1("BWCraftsman")
                tx.BWApprenticeP = rd1("BWApprentice")
                tx.BWHelperP = rd1("BWHelper")
                tx.QtyForemanP = rd1("QtyForeman")
                tx.QtyJourneymanP = rd1("QtyJourneyman")
                tx.QtyCraftsmanP = rd1("QtyCraftsman")
                tx.QtyApprenticeP = rd1("QtyApprentice")
                tx.QtyHelperP = rd1("QtyHelper")
            End While
            Return tx
        Catch ex As Exception
            Dim tx1 As New TaxesClass
            tx1.Clear()
            Return tx1
        Finally
            desconectar()
        End Try
    End Function
    Public Function savetaxes(ByVal tx As TaxesClass) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
if(select COUNT(*) from taxesST where jobNo = '" & tx.JobNo & "' or idTaxesST = '" & tx.idTaxes & "')=0
begin
	insert into taxesST values(NEWID()," & tx.FICA.ToString() & "," & tx.FUI.ToString() & "," & tx.SUI.ToString() & "," & tx.WC.ToString() & "," & tx.GenLiab.ToString() & "," & tx.Umbr.ToString() & "," & tx.Pollution.ToString() & "," & tx.Healt.ToString() & "," & tx.Fringe.ToString() & "," & tx.Small.ToString() & "," & tx.PPE.ToString() & "," & tx.Consumable.ToString() & "," & tx.Scaffold.ToString() & "," & tx.YoYos.ToString() & "," & tx.Mesh.ToString() & "," & tx.Miselaneos.ToString() & "," & tx.Overhead.ToString() & "," & tx.Profit.ToString() & "," & tx.BWForeman.ToString() & "," & tx.BWJourneyman.ToString() & "," & tx.BWCraftsman.ToString() & "," & tx.BWApprentice.ToString() & "," & tx.BWHelper.ToString() & "," & tx.QtyForeman.ToString() & "," & tx.QtyJourneyman.ToString() & "," & tx.QtyCraftsman.ToString() & "," & tx.QtyApprentice.ToString() & "," & tx.QtyHelper.ToString() & ",'" & tx.JobNo & "')
	insert into taxesPT values(NEWID()," & tx.FICAP.ToString() & "," & tx.FUIP.ToString() & ", " & tx.SUIP.ToString() & "," & tx.WCP.ToString() & "," & tx.GenLiabP.ToString() & "," & tx.UmbrP.ToString() & "," & tx.PollutionP.ToString() & "," & tx.HealtP.ToString() & "," & tx.FringeP.ToString() & "," & tx.SmallP.ToString() & "," & tx.PPEP.ToString() & "," & tx.ConsumableP.ToString() & "," & tx.ScaffoldP.ToString() & "," & tx.YoYosP.ToString() & "," & tx.MeshP.ToString() & "," & tx.MiselaneosP.ToString() & "," & tx.OverheadP.ToString() & "," & tx.ProfitP.ToString() & "," & tx.BWForemanP.ToString() & "," & tx.BWJourneymanP.ToString() & "," & tx.BWCraftsmanP.ToString() & "," & tx.BWApprenticeP.ToString() & "," & tx.BWHelperP.ToString() & ", " & tx.QtyForemanP.ToString() & "," & tx.QtyJourneymanP.ToString() & "," & tx.QtyCraftsmanP.ToString() & "," & tx.QtyApprenticeP.ToString() & "," & tx.QtyHelperP.ToString() & ",'" & tx.JobNo & "')
end
else if (select COUNT(*) from taxesST where jobNo = '" + tx.JobNo + "' or idTaxesST = '" + tx.idTaxes + "')>0
begin
    update taxesST set FICA = " & tx.FICA.ToString() & ", FUI = " & tx.FUI.ToString() & ", SUI = " & tx.SUI.ToString() & ", WC = " & tx.WC.ToString() & ", GenLiab = " & tx.GenLiab.ToString() & ", Umbr = " & tx.Umbr.ToString() & ", Pollution = " & tx.Pollution.ToString() & ", Healt = " & tx.Healt.ToString() & ", Fringe = " & tx.Fringe.ToString() & ", Small = " & tx.Small.ToString() & ", PPE = " & tx.PPE.ToString() & " ,Consumable = " & tx.Consumable.ToString() & ", Scaffold = " & tx.Scaffold.ToString() & ", YoYo = " & tx.YoYos.ToString() & ", Mesh = " & tx.Mesh.ToString() & ", Miselaneos = " & tx.Miselaneos.ToString() & ", Overhead = " & tx.Overhead.ToString() & ", Profit = " & tx.Profit.ToString() & ",
        BWForeman = " & tx.BWForeman.ToString() & ", BWJourneyman = " & tx.BWJourneyman.ToString() & ", BWCraftsman = " & tx.BWCraftsman.ToString() & ", BWApprentice = " & tx.BWApprentice.ToString() & ", BWHelper = " & tx.BWHelper.ToString() & ",
        QtyForeman = " & tx.QtyForeman.ToString() & ", QtyJourneyman = " & tx.QtyJourneyman.ToString() & ", QtyCraftsman = " & tx.QtyCraftsman.ToString() & ", QtyApprentice = " & tx.QtyApprentice.ToString() & ", QtyHelper = " & tx.QtyHelper.ToString() & "
        where idTaxesST = '" & tx.idTaxes & "' or jobNo = '" & tx.JobNo & "'

    update taxesPT set FICA = " & tx.FICAP.ToString() & ", FUI = " & tx.FUIP.ToString() & ", SUI = " & tx.SUIP.ToString() & ", WC = " & tx.WCP.ToString() & ", GenLiab = " & tx.GenLiabP.ToString() & ", Umbr = " & tx.UmbrP.ToString() & ", Pollution = " & tx.PollutionP.ToString() & ", Healt = " & tx.HealtP.ToString() & ", Fringe = " & tx.FringeP.ToString() & ", Small = " & tx.SmallP.ToString() & ",PPE = " & tx.PPEP.ToString() & " ,Consumable = " & tx.ConsumableP.ToString() & ", Scaffold = " & tx.ScaffoldP.ToString() & ", YoYo = " & tx.YoYosP.ToString() & ", Mesh = " & tx.MeshP.ToString() & ", Miselaneos = " & tx.MiselaneosP.ToString() & ", Overhead = " & tx.OverheadP.ToString() & ", Profit = " & tx.ProfitP.ToString() & ",
        BWForeman = " & tx.BWForemanP.ToString() & ", BWJourneyman = " & tx.BWJourneymanP.ToString() & ", BWCraftsman = " & tx.BWCraftsmanP.ToString() & ", BWApprentice = " & tx.BWApprenticeP.ToString() & ", BWHelper = " & tx.BWHelperP.ToString() & ",
        QtyForeman = " & tx.QtyForemanP.ToString() & ", QtyJourneyman = " & tx.QtyJourneymanP.ToString() & ", QtyCraftsman = " & tx.QtyCraftsmanP.ToString() & ", QtyApprentice = " & tx.QtyApprenticeP.ToString() & ", QtyHelper = " & tx.QtyHelperP.ToString() & "
        where idTaxesPT = '" & tx.idTaxesP & "' or jobNO = '" & tx.JobNo & "'
            end", conn)
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectTotalHoursCount(ByVal jobNo As String, ByVal beginDate As Date, ByVal endDate As Date) As Decimal()
        Try
            conectar()
            Dim cmd As New SqlCommand("select ISNULL(SUM(hw.hoursST+hw.hoursOT + hours3),0.0) as 'HrsTotal', ISNULL(SUM(hw.hoursST),0.0) as 'HrsST', ISNULL(SUM(hw.hoursOT + hours3),0.0) AS 'HrsOT'  from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where jb.jobNo = " + jobNo + " and hw.dateWorked between '" + validaFechaParaSQl(beginDate) + "' and '" + validaFechaParaSQl(endDate) + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim Horas() As Decimal = {0.0, 0.0, 0.0}
            While dr.Read()
                Horas(0) = dr("HrsTotal")
                Horas(1) = dr("HrsST")
                Horas(2) = dr("HrsOT")
                Exit While
            End While
            dr.Close()
            Return Horas
        Catch ex As Exception
            MsgBox(ex.Message())
            Return {0.0, 0.0, 0.0}
        Finally
            desconectar()
        End Try
    End Function
End Class
