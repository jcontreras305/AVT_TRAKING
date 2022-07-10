Imports System.Data.SqlClient

Public Class MetodosRFIScaffold
    Inherits ConnectioDB
    Public Function selectRFIScaffold(ByVal tag As String, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idRFI , tag , idDrawingNum,
newDays,newWith,newHeigth,newLength,newBuild,newDecks,ISNULL(newIdLaborRate,'') as 'newIdLaborRate',ISNULL(newIdSCFUR,'') as 'newIdSCFUR',
lastDays,lastWith,lastLength,lastHeigth,lastBuild,lastDecks,ISNULL(lastIdLaborRate,'') as 'lastIdLaborRate',ISNULL(lastIdSCFUR,'') as 'lastIdSCFUR',
reqEmployee,reqTitleEmployee,CONVERT(nvarchar,reqDate,101) as 'reqDate',reqCompany,
chUpEmployee,chUpTitleEmployee,CONVERT(nvarchar,chUpDate,101) as 'chUpDate',
basicFCR,convert(nvarchar, weDate,101) as 'weDate',note from RFIScaffoldEst where tag = '" + tag + "'" + If(idDrawing <> "", "", "' and idDrawingNum = '" + idDrawing + "'") + "
order by convert (decimal, idRFI) asc", conn)
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("idRFI") '0
                dt.Columns.Add("tag")
                dt.Columns.Add("idDrawingNum")
                dt.Columns.Add("newDays")
                dt.Columns.Add("newWith")
                dt.Columns.Add("newHeigth")
                dt.Columns.Add("newLength")
                dt.Columns.Add("newBuild")
                dt.Columns.Add("newDecks")
                dt.Columns.Add("newIdLaborRate")
                dt.Columns.Add("newIdSCFUR") '10
                dt.Columns.Add("lastDays")
                dt.Columns.Add("lastWith")
                dt.Columns.Add("lastLength")
                dt.Columns.Add("lastHeigth")
                dt.Columns.Add("lastBuild") '15
                dt.Columns.Add("lastDecks")
                dt.Columns.Add("lastIdLaborRate")
                dt.Columns.Add("lastIdSCFUR")
                dt.Columns.Add("reqEmployee")
                dt.Columns.Add("reqTitleEmployee") '20
                dt.Columns.Add("reqDate")
                dt.Columns.Add("reqCompany")
                dt.Columns.Add("chUpEmployee")
                dt.Columns.Add("chUpTitleEmployee")
                dt.Columns.Add("chUpDate") '25
                dt.Columns.Add("basicFCR")
                dt.Columns.Add("weDate")
                dt.Columns.Add("note")
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function selectDrawing(Optional cmb As ComboBox = Nothing, Optional projectId As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select dr.idDrawingNum,dr.[description] as 'drDescription',po.projectId,po.[description] as 'poDescription',po.unit,cl.numberClient from drawing as dr 
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
" + If(projectId = "", "", "where po.projectId = '" + projectId + "'") + "
order by po.projectId ,dr.idDrawingNum asc", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            dt.Columns.Add("projectId")
            dt.Columns.Add("poDescription")
            dt.Columns.Add("idDrawingNum")
            dt.Columns.Add("drDescription")
            dt.Columns.Add("unit")
            dt.Columns.Add("numberClient")
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("projectId"), dr("poDescription"), dr("idDrawingNum"), dr("drDescription"), dr("unit"), dr("numberClient"))
                If cmb IsNot Nothing Then
                    cmb.Items.Add(dr("idDrawingNum") + "| " + dr("projectId"))
                End If
            End While
            dr.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectRFI(ByVal tag As String, Optional cmb As ComboBox = Nothing) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select rfiSC.idRFI,convert(nvarchar, rfiSC.reqDate,101)as 'reqDate',scf.tag,dr.idDrawingNum,dr.[description] as 'drDescription',po.projectId,po.[description] as 'poDescription',
po.unit,cl.numberClient from 
RFIScaffoldEst as rfiSC 
inner join scaffoldEst as scf on rfiSC.idDrawingNum = scf.idDrawingNum and rfiSC.tag = scf.tag
inner join drawing as dr on scf.idDrawingNum = dr.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
" + If(tag <> "", "where scf.tag = '" + tag + "'", "") + "
order by po.projectId ,dr.idDrawingNum,scf.tag,rfiSC.idRFI asc
", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            dt.Columns.Add("idRFI")
            dt.Columns.Add("idTag")
            dt.Columns.Add("reqDate")
            dt.Columns.Add("idDrawingNum")
            dt.Columns.Add("drDescription")
            dt.Columns.Add("projectId")
            dt.Columns.Add("poDescription")
            dt.Columns.Add("unit")
            dt.Columns.Add("numberClient")
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("idRFI"), dr("tag"), dr("reqDate"), dr("idDrawingNum"), dr("drDescription"), dr("projectId"), dr("poDescription"), dr("unit"), dr("numberClient"))
                If cmb IsNot Nothing Then
                    cmb.Items.Add(dr("idRFI") + "| " + dr("reqDate"))
                End If
            End While
            dr.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectTagDrawing(ByVal idDrawing As String, Optional cmb As ComboBox = Nothing) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select scf.tag,scf.[days],scf.width,scf.[length],scf.heigth,scf.build,scf.decks,scf.idLaborRate,idSCFUR, dr.idDrawingNum from scaffoldEst as scf
inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum" + If(idDrawing = "", "", "
where scf.idDrawingNum = '" + idDrawing + "'") + " order by scf.tag asc", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            dt.Columns.Add("tag")
            dt.Columns.Add("days")
            dt.Columns.Add("width")
            dt.Columns.Add("length")
            dt.Columns.Add("heigth")
            dt.Columns.Add("build")
            dt.Columns.Add("decks")
            dt.Columns.Add("idLaborRate")
            dt.Columns.Add("idSCFUR")
            dt.Columns.Add("idDrawingNum")
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("tag"), dr("days"), dr("width"), dr("length"), dr("heigth"), dr("build"), dr("decks"), dr("idLaborRate"), dr("idSCFUR"), dr("idDrawingNum"))
                If cmb IsNot Nothing Then
                    cmb.Items.Add(dr("tag"))
                End If
            End While
            dr.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarCellComboBoxIdLabor(ByVal cmb As DataGridViewComboBoxCell, Optional cellValue As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idLaborRate from laborRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read
                cmb.Items.Add(dr("idLaborRate"))
                If dr("idLaborRate") = cellValue Then
                    cmb.Value = cellValue
                End If
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarCellComboBoxSCFUR(ByVal cmb As DataGridViewComboBoxCell, Optional cellValue As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idSCFUR from scfUnitsRates", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read
                cmb.Items.Add(dr("idSCFUR"))
                If dr("idSCFUR") = cellValue Then
                    cmb.Value = cellValue
                End If
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '==================================================================================================================================================================================================================================================================
    '======= METODOS PARA RFI SCAFFOLD ================================================================================================================================================================================================================================
    '==================================================================================================================================================================================================================================================================
    Public Function selectMaxRFI(ByVal idTag As String, ByVal idDrawingNum As String) As Integer
        Try
            conectar()
            Dim cmd As New SqlCommand("select isnull( max(convert(decimal,idRFI))+1,1) as 'maxRFI' from RFIScaffoldEst where tag='" + idTag + "'and idDrawingNum= '" + idDrawingNum + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim maxRFIScf As Integer = 0
            While dr.Read
                maxRFIScf = dr("maxRFI")
                Exit While
            End While
            dr.Close()
            Return maxRFIScf
        Catch ex As Exception
            MsgBox(ex.Message())
            Return 1
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveUpdateRFIScaffold(ByVal RFI As RFIScaffoldClass) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
if(select COUNT(*) from RFIScaffoldEst where idRFI = '" + RFI.idRFI + "' and tag= '" + RFI.idTag + "' and idDrawingNum = '" + RFI.idDrawingNum + "' )=0
begin
	insert into RFIScaffoldEst values ('" + RFI.idRFI + "','" + RFI.idTag + "','" + RFI.idDrawingNum + "'," + RFI.newDays + "," + RFI.newWith + "," + RFI.newLength + "," + RFI.newHeigth + "," + RFI.newBuild + "," + RFI.newDecks + "," + If(RFI.newIdLaborRate = "NULL", "NULL", "'" + RFI.newIdLaborRate.ToString().Replace("'", "''") + "'") + "," + If(RFI.newIdSCFUR = "NULL", "NULL", "'" + RFI.newIdSCFUR.ToString().Replace("'", "''") + "'") + "," + RFI.lastDays + "," + RFI.lastWith + "," + RFI.lastLength + "," + RFI.lastHeigth + "," + RFI.lastBuild + "," + RFI.lastDecks + ",'" + RFI.lastIdLaborRate.ToString.Replace("'", "''") + "','" + RFI.lastIdSCFUR.ToString.Replace("'", "''") + "','" + RFI.reqEmployee + "','" + RFI.reqTitleEmployee + "','" + validaFechaParaSQl(RFI.reqDate) + "','" + RFI.reqCompany + "','" + RFI.chUpTitleEmployee + "','" + RFI.chUpTitleEmployee + "','" + validaFechaParaSQl(RFI.chUpDate) + "','" + RFI.basicFCRlastBuild + "','" + validaFechaParaSQl(RFI.weDate) + "','" + RFI.note + "')
    update scaffoldEst set [days]=" + RFI.newDays + ",width=" + RFI.newWith + ",[length]=" + RFI.newLength + ",heigth=" + RFI.newHeigth + ",build=" + RFI.newBuild + ",decks = " + RFI.newDecks + " ,idLaborRate = " + If(RFI.newIdLaborRate = "NULL", "NULL", "'" + RFI.newIdLaborRate.ToString.Replace("'", "''") + "'") + ",idSCFUR= " + If(RFI.newIdSCFUR = "NULL", "NULL", "'" + RFI.newIdSCFUR.ToString.Replace("'", "''") + "'") + " where tag='" + RFI.idTag + "' and idDrawingNum='" + RFI.idDrawingNum + "'
end
else if(select COUNT(*) from RFIScaffoldEst where idRFI = '" + RFI.idRFI + "' and tag= '" + RFI.idTag + "' and idDrawingNum = '" + RFI.idDrawingNum + "' )>0
begin
	update RFIScaffoldEst set newDays= " + RFI.newDays + ",newWith =" + RFI.newWith + ",newLength = " + RFI.newLength + ",newHeigth=" + RFI.newHeigth + ",newBuild=" + RFI.newBuild + ",newIdLaborRate= " + If(RFI.newIdLaborRate = "NULL", "NULL", "'" + RFI.newIdLaborRate.ToString.Replace("'", "''") + "'") + ",newIdSCFUR= " + If(RFI.newIdSCFUR = "NULL", "NULL", "'" + RFI.newIdSCFUR.ToString.Replace("'", "''") + "'") + ",lastDays= " + RFI.lastDays + ",lastWith= " + RFI.lastWith + ",lastLength= " + RFI.lastLength + ",lastHeigth = " + RFI.lastHeigth + ",lastBuild= " + RFI.lastBuild + ",lastDecks =" + RFI.lastDecks + ",lastIdLaborRate= '" + RFI.lastIdLaborRate.ToString.Replace("'", "''") + "',lastIdSCFUR = '" + RFI.lastIdSCFUR.ToString.Replace("'", "''") + "',reqEmployee='" + RFI.reqEmployee + "',reqTitleEmployee= '" + RFI.reqTitleEmployee + "',reqDate='" + validaFechaParaSQl(RFI.reqDate) + "',reqCompany= '" + RFI.reqCompany + "',chUpEmployee= '" + RFI.chUpEmployee + "',chUpTitleEmployee = '" + RFI.chUpTitleEmployee + "',chUpDate = '" + validaFechaParaSQl(RFI.chUpDate) + "',basicFCR='" + RFI.basicFCRlastBuild + "',weDate='" + validaFechaParaSQl(RFI.weDate) + "',note= '" + RFI.note + "' where idRFI = '" + RFI.idRFI + "' and tag= '" + RFI.idTag + "' and idDrawingNum = '" + RFI.idDrawingNum + "'
    if (select top 1 max(convert(decimal,idRFI)) from RFIScaffoldEst where tag = '" + RFI.idTag + "' and idDrawingNum = '" + RFI.idDrawingNum + "') = convert(decimal,'" + RFI.idRFI + "')
	begin
        update scaffoldEst set [days]=" + RFI.newDays + ",width=" + RFI.newWith + ",[length]=" + RFI.newLength + ",heigth=" + RFI.newHeigth + ",build=" + RFI.newBuild + ",decks = " + RFI.newDecks + ",idLaborRate = " + If(RFI.newIdLaborRate = "NULL", "NULL", "'" + RFI.newIdLaborRate.ToString.Replace("'", "''") + "'") + ",idSCFUR= " + If(RFI.newIdSCFUR = "NULL", "NULL", "'" + RFI.newIdSCFUR.ToString.Replace("'", "''") + "'") + " where tag='" + RFI.idTag + "' and idDrawingNum='" + RFI.idDrawingNum + "'
    end
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
                Return True
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteRFIScaffold(ByVal RFIDelete As String, ByVal idTag As String, ByVal idDrawingNum As String, Optional RFINext As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_deleteRFIScaffold", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idRFIDelete", RFIDelete)
            cmd.Parameters.AddWithValue("@idRFINext", RFINext)
            cmd.Parameters.AddWithValue("@tag", idTag)
            cmd.Parameters.AddWithValue("@idDrawingNum", idDrawingNum)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
                Return True
            Else
                MsgBox("Error")
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
