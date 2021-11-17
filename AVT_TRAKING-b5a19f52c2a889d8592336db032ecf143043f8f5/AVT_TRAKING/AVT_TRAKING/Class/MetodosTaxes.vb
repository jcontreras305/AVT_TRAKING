Imports System.Data.SqlClient
Public Class MetodosTaxes
    Inherits ConnectioDB

    Function selectTaxes(ByVal idAux As String) As TaxesClass
        Try
            Dim tx As New TaxesClass
            tx.idAux = idAux
            conectar()
            'Datos para ST
            Dim cmd As New SqlCommand("select top 1 * from taxesST where idAux = '" + idAux + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                tx.idTaxes = rd("idTaxesST")
                tx.idAux = rd("idAux")
                tx.TotalHours = rd("totalHours")
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
            End While
            rd.Close()
            'Datos para OT
            Dim cmd1 As New SqlCommand("select top 1 * from taxesPT where idAux = '" + idAux + "'", conn)
            Dim rd1 As SqlDataReader = cmd1.ExecuteReader()
            While rd1.Read()
                tx.idTaxesP = rd1("idTaxesPT")
                tx.TotalHoursP = rd1("totalHours")
                tx.FICAP = rd1("FICA")
                tx.FUIP = rd1("FUI")
                tx.SUIP = rd1("SUI")
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
if(select COUNT(*) from taxesST where idAux = '" + tx.idAux + "'or idTaxesST = '" + tx.idTaxes + "')=0
begin
	insert into taxesST values(NEWID(),'" + tx.idAux + "'," + tx.TotalHours.ToString() + "," + tx.FICA.ToString() + "," + tx.FUI.ToString() + "," + tx.SUI.ToString() + "," + tx.WC.ToString() + "," + tx.GenLiab.ToString() + "," + tx.Umbr.ToString() + "," + tx.Pollution.ToString() + "," + tx.Healt.ToString() + "," + tx.Fringe.ToString() + "," + tx.Small.ToString() + "," + tx.PPE.ToString() + "," + tx.Consumable.ToString() + "," + tx.Scaffold.ToString() + "," + tx.YoYos.ToString() + "," + tx.Mesh.ToString() + "," + tx.Miselaneos.ToString() + "," + tx.Overhead.ToString() + "," + tx.Profit.ToString() + "," + tx.BWForeman.ToString() + "," + tx.BWJourneyman.ToString() + "," + tx.BWCraftsman.ToString() + "," + tx.BWApprentice.ToString() + "," + tx.BWHelper.ToString() + "," + tx.QtyForeman.ToString() + "," + tx.QtyJourneyman.ToString() + "," + tx.QtyCraftsman.ToString() + "," + tx.QtyApprentice.ToString() + "," + tx.QtyHelper.ToString() + ")
	insert into taxesPT values(NEWID(),'" + tx.idAux + "'," + tx.TotalHours.ToString() + "," + tx.FICAP.ToString() + "," + tx.FUIP.ToString() + ", " + tx.SUIP.ToString() + "," + tx.BWForemanP.ToString() + "," + tx.BWJourneymanP.ToString() + "," + tx.BWCraftsmanP.ToString() + "," + tx.BWApprenticeP.ToString() + "," + tx.BWHelperP.ToString() + ", " + tx.QtyForemanP.ToString() + "," + tx.QtyJourneymanP.ToString() + "," + tx.QtyCraftsmanP.ToString() + "," + tx.QtyApprenticeP.ToString() + "," + tx.QtyHelperP.ToString() + ")
end
else if(select COUNT(*) from taxesST where idAux = '" + tx.idAux + "'or idTaxesST = '" + tx.idTaxes + "')>0
begin 
	update taxesST set totalHours = " + tx.TotalHours.ToString() + ",FICA= " + tx.FICA.ToString() + ",FUI= " + tx.FUI.ToString() + ",SUI= " + tx.SUI.ToString() + ",WC= " + tx.WC.ToString() + ",GenLiab= " + tx.GenLiab.ToString() + ",Umbr= " + tx.Umbr.ToString() + ",Pollution= " + tx.Pollution.ToString() + ",Healt= " + tx.Healt.ToString() + ",Fringe= " + tx.Fringe.ToString() + ",Small= " + tx.Small.ToString() + ",Consumable= " + tx.Consumable.ToString() + ",Scaffold= " + tx.Scaffold.ToString() + ",YoYo= " + tx.YoYos.ToString() + ",Mesh= " + tx.Mesh.ToString() + ",Miselaneos= " + tx.Miselaneos.ToString() + ",Overhead= " + tx.Overhead.ToString() + ",Profit= " + tx.Profit.ToString() + ",
	BWForeman= " + tx.BWForeman.ToString() + ",BWJourneyman= " + tx.BWJourneyman.ToString() + ",BWCraftsman= " + tx.BWCraftsman.ToString() + ",BWApprentice= " + tx.BWApprentice.ToString() + ",BWHelper= " + tx.BWHelper.ToString() + ",
	QtyForeman= " + tx.QtyForeman.ToString() + ",QtyJourneyman= " + tx.QtyJourneyman.ToString() + ",QtyCraftsman= " + tx.QtyCraftsman.ToString() + ",QtyApprentice= " + tx.QtyApprentice.ToString() + ",QtyHelper= " + tx.QtyHelper.ToString() + "
	where idTaxesST = '" + tx.idTaxes + "' or idAux = '" + tx.idAux + "'
	update taxesPT set totalHours = " + tx.TotalHours.ToString() + ",FICA= " + tx.FICAP.ToString() + ",FUI= " + tx.FUIP.ToString() + ",SUI= " + tx.SUIP.ToString() + ",
	BWForeman= " + tx.BWForemanP.ToString() + ",BWJourneyman= " + tx.BWJourneymanP.ToString() + ",BWCraftsman= " + tx.BWCraftsmanP.ToString() + ",BWApprentice= " + tx.BWApprenticeP.ToString() + ",BWHelper= " + tx.BWHelperP.ToString() + ",
	QtyForeman= " + tx.QtyForemanP.ToString() + ",QtyJourneyman= " + tx.QtyJourneymanP.ToString() + ",QtyCraftsman= " + tx.QtyCraftsmanP.ToString() + ",QtyApprentice= " + tx.QtyApprenticeP.ToString() + ",QtyHelper= " + tx.QtyHelperP.ToString() + "
	where idTaxesPT = '" + tx.idTaxesP + "' or idAux = '" + tx.idAux + "'
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

End Class
