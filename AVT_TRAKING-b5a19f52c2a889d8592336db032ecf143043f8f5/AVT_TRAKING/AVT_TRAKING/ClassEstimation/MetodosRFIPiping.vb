Imports System.Data.SqlClient
Public Class MetodosRFIPiping
    Inherits ConnectioDB
    Public Function selectRFIPo() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select cl.numberClient, po.projectId, dr.idDrawingNum , pp.idPipingEst as 'tag',ISNULL( rfi.idRFIEq,'' ) as 'idRFI' from pipingEst as pp
left join RFIEquipment as rfi on rfi.tag = pp.idPipingEst and pp.idDrawingNum = rfi.idDrawingNum 
inner join drawing as dr on dr.idDrawingNum =  pp.idDrawingNum 
inner join projectClientEst as po on po.projectId = dr.projectId 
inner join clientsEst as cl on cl.idClientEst = po.idClientEst", conn)
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("numberClient")
                dt.Columns.Add("projectId")
                dt.Columns.Add("idDrawingNum")
                dt.Columns.Add("tag")
                dt.Columns.Add("idRFI")
            End If
            Return dt
        Catch ex As Exception
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
    Public Function selectTagDrawing(ByVal idDrawing As String, Optional cmb As ComboBox = Nothing) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select pp.idPipingEst as 'idTag',pp.size,pp.elevation,pp.systemPntPP as 'system',pp.pntOption as 'option',pp.[type],pp.thick,pp.idJacket,
	pp.idLaborRatePnt,pp.lFtPnt,pp.p90Pnt,pp.p45Pnt,pTeePnt,pp.pPairPnt,pp.pVlvPnt,pp.pControlPnt,pp.pWeldPnt,
	pp.idLaborRateRmv,pp.lFtRmv,
    pp.idLaborRateII,pp.lFtII,pp.p90II,pp.p45II,pp.pBendII,pp.pTeeII,pp.pReducII,pp.pCapsII,pp.pPairII,pp.pVlvII,pp.pControlII,pp.pWeldII,pp.pCutOutII,pp.psupportII,
	dr.idDrawingNum from pipingEst as pp 
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
" + If(idDrawing = "", "", "where pp.idDrawingNum = '" + idDrawing + "'") + "
order by pp.idPipingEst asc", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim clmArray() As String = {"idTag", "size", "elevation", "system", "option", "type", "thick", "idJacket",
                "idLaborRatePnt", "lFtPnt", "p90Pnt", "p45Pnt", "pTeePnt", "pPairPnt", "pVlvPnt", "pControlPnt", "pWeldPnt",
                "idLaborRateRmv", "lFtRmv",
                "idLaborRateII", "lFtII", "p90II", "p45II", "pBendII", "pTeeII", "pReducII", "pCapsII", "pPairII", "pVlvII", "pControlII", "pWeldII", "pCutOutII", "psupportII", "idDrawingNum"}
            For Each element As String In clmArray
                dt.Columns.Add(element)
            Next
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("idTag"), dr("size"), dr("elevation"), dr("system"), dr("option"), dr("type"), dr("thick"), dr("idJacket"),
                dr("idLaborRatePnt"), dr("lFtPnt"), dr("p90Pnt"), dr("p45Pnt"), dr("pTeePnt"), dr("pPairPnt"), dr("pVlvPnt"), dr("pControlPnt"), dr("pWeldPnt"),
                dr("idLaborRateRmv"), dr("lFtRmv"),
                dr("idLaborRateII"), dr("lFtII"), dr("p90II"), dr("p45II"), dr("pBendII"), dr("pTeeII"), dr("pReducII"), dr("pCapsII"), dr("pPairII"), dr("pVlvII"), dr("pControlII"), dr("pWeldII"), dr("pCutOutII"), dr("psupportII"), dr("idDrawingNum"))
                If cmb IsNot Nothing Then
                    cmb.Items.Add(dr("idTag"))
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
    Public Function selectRFIPiping(ByVal tag As String, ByVal cmb As ComboBox, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select rfiPp.idRFIPp, CONVERT(nvarchar,rfiPp.reqDate,101) as 'reqDate',dr.idDrawingNum,dr.[description] as 'drDescription',po.projectId ,po.[description] as 'poDescription',po.unit, cl.numberClient from RFIPiping rfiPp
inner join pipingEst as pp on rfiPp.idDrawingNum= pp.idDrawingNum and rfiPp.tag = pp.idPipingEst
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
where rfiPp.tag = " + tag + " " + If(idDrawing <> "", "", "' and rfiPp.idDrawingNum = '" + idDrawing + "'") + "
order by idRFIPp asc", conn)
            Dim dt As New Data.DataTable
            cmb.Items.Clear()
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each row As Data.DataRow In dt.Rows
                    cmb.Items.Add(row.ItemArray(0) + "| " + row.ItemArray(1))
                Next
            Else
                Dim clmArray() As String = {"idRFIPp", "reqDate", "idDrawingNum", "drDescription", "projectId", "poDescription", "unit", "numberClient"}
                For Each element As String In clmArray
                    dt.Columns.Add(element)
                Next
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectRFIPiping(ByVal tag As String, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idRFIPp,tag as 'idTag',idDrawingNum,
	oldSize,oldElevation,oldSystem,oldOption,oldType,oldThick,oldIdJacket,
	oldIdLaborRatePnt,oldLFtPnt,oldP90Pnt,oldP45Pnt,oldPTeePnt,oldPPairPnt,oldPVlvPnt,oldPControlPnt,oldPWeldPnt,
	oldIdLaborRateRmv,oldLFtRmv,
	oldIdLaborRateII,oldLFtII,oldP90II,oldP45II,oldPBendII,oldPTeeII,oldPReducII,oldPCapsII,oldPPairII,oldPVlvII,oldPControlII,oldPWeldII,oldPCutOutII,oldPsupportII,
	newSize,newElevation,newSystem,newOption,newType,newThick,newIdJacket,
	newIdLaborRatePnt,newLFtPnt,newP90Pnt,newP45Pnt,newPTeePnt,newPPairPnt,newPVlvPnt,newPControlPnt,newPWeldPnt,
	newIdLaborRateRmv,newLFtRmv,
	newIdLaborRateII,newLFtII,newP90II,newP45II,newPBendII,newPTeeII,newPReducII,newPCapsII,newPPairII,newPVlvII,newPControlII,newPWeldII,newPCutOutII,newPsupportII,
    reqEmployee,reqTitleEmployee ,reqDate ,reqCompany ,chUpEmployee ,chUpTitleEmployee,chUpDate,basicFCR,weDate,note
 from RFIPiping as rfi where rfi.tag = " + tag + " " + If(idDrawing <> "", "", "' and rfi.idDrawingNum = '" + idDrawing + "'") + "
order by convert (decimal, idRFIPp) asc", conn)
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                Dim clmArray() As String = {"idRFIPp", "idTag", "idDrawingNum", "oldSize", "oldElevation", "oldSystem", "oldOption", "oldType", "oldThick", "oldIdJacket",
    "oldIdLaborRatePnt", "oldLFtPnt", "oldP90Pnt", "oldP45Pnt", "oldPTeePnt", "oldPPairPnt", "oldPVlvPnt", "oldPControlPnt", "oldPWeldPnt",
    "oldIdLaborRateRmv", "oldLFtRmv",
    "oldIdLaborRateII", "oldLFtII", "oldP90II", "oldP45II", "oldPBendII", "oldPTeeII", "oldPReducII", "oldPCapsII", "oldPPairII", "oldPVlvII", "oldPControlII", "oldPWeldII", "oldPCutOutII", "oldPsupportII",
    "newSize", "newElevation", "newSystem", "newOption", "newType", "newThick", "newIdJacket",
    "newIdLaborRatePnt", "newLFtPnt", "newP90Pnt", "newP45Pnt", "newPTeePnt", "newPPairPnt", "newPVlvPnt", "newPControlPnt", "newPWeldPnt",
    "newIdLaborRateRmv", "newLFtRmv",
    "newIdLaborRateII", "newLFtII", "newP90II", "newP45II", "newPBendII", "newPTeeII", "newPReducII", "newPCapsII", "newPPairII", "newPVlvII", "newPControlII", "newPWeldII", "newPCutOutII", "newPsupportII",
    "reqEmployee", "reqTitleEmployee", "reqDate", "reqCompany", "chUpEmployee", "chUpTitleEmployee", "chUpDate", "basicFCR", "weDate", "note"}
                For Each element As String In clmArray
                    dt.Columns.Add(element)
                Next
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '################################################################################################################################################################################################################################
    '########### METODOS PARA COMBOS EN LAS TABLAS ##################################################################################################################################################################################
    '################################################################################################################################################################################################################################
    '============= ELEVATION ========================================================================================================================================================================================================
    Public Function llenarComboElvPaint(ByVal cmb As DataGridViewComboBoxCell, Optional cellVal As String = "") As Data.DataTable
        Try
            conectar()
            Dim dt As New Data.DataTable
            dt.Columns.Add("elevation")
            dt.Columns.Add("percent")
            Dim cmd As New SqlCommand("select elevation,[percent] from factorElevationPaint", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("elevation"))
                dt.Rows.Add(dr("elevation"), dr("percent"))
            End While
            If cellVal <> "" And cellVal <> "0" Then
                Dim array() As Data.DataRow = dt.Select("elevation = " + cellVal)
                If array.Length > 0 Then
                    cmb.Value = cellVal
                End If
            End If
            dr.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '============= JACKET ========================================================================================================================================================================================================
    Public Function selectPpJacketUnitRate() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJacket,name,laborProd,matFactor,eqFactor from ppJktUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idJacket")
            dt.Columns.Add("name")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matFactor")
            dt.Columns.Add("eqFactor")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                dt.Rows.Add(dr("idJacket"), dr("name"), dr("laborProd"), dr("matFactor"), dr("eqFactor"))
            End While
            dr.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboJacket(ByVal cmb As DataGridViewComboBoxCell, Optional cellVal As String = "") As Data.DataTable
        Try
            conectar()
            Dim dt As New Data.DataTable
            dt.Columns.Add("idJacket")
            dt.Columns.Add("name")
            Dim cmd As New SqlCommand("select idJacket, name from ppJktUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idJacket"))
                dt.Rows.Add(dr("idJacket"), dr("name"))
            End While
            If cellVal <> "" And cellVal <> "0" Then
                Dim array() As Data.DataRow = dt.Select("idJacket = " + cellVal)
                If array.Length > 0 Then
                    cmb.Value = cellVal
                End If
            End If
            dr.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '============= LABOR RATE ========================================================================================================================================================================================================
    Public Function llenarComboLaporRate(ByVal cmb As DataGridViewComboBoxCell, Optional cellVal As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idLaborRate,insRate,abatRate,paintRate, scafRate from laborRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idLaborRate")
            dt.Columns.Add("insRate")
            dt.Columns.Add("abatRate")
            dt.Columns.Add("paintRate")
            dt.Columns.Add("scafRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim listAux As New List(Of String)
            cmb.Items.Clear()
            While dr.Read()
                If listAux.Contains(dr("idLaborRate")) = False Then
                    listAux.Add(dr("idLaborRate"))
                    cmb.Items.Add(dr("idLaborRate"))
                End If
                dt.Rows.Add(dr("idLaborRate"), dr("insRate"), dr("abatRate"), dr("paintRate"), dr("scafRate"))
            End While
            If cellVal <> "" Then
                Dim array() As Data.DataRow = dt.Select("idLaborRate= '" + cellVal.Replace("'", "''") + "'")
                If array.Length > 0 Then
                    cmb.Value = cellVal
                End If
            End If
            dr.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '============= SYSTEM & OPTION ========================================================================================================================================================================================================
    Public Function selectPpPntUnitRate() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select systemPntPP, pntOption, size, laborProd, matRate, eqRate from ppPaintUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("systemPntPP")
            dt.Columns.Add("pntOption")
            dt.Columns.Add("size")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matRate")
            dt.Columns.Add("eqRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                dt.Rows.Add(dr("systemPntPP"), dr("pntOption"), dr("size"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '============= TYPE & THICK ========================================================================================================================================================================================================
    Public Function selectPpInsUnitRate() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select size,[type],thick,laborProd,matRate,eqRate from ppInsUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("size")
            dt.Columns.Add("type")
            dt.Columns.Add("thick")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matRate")
            dt.Columns.Add("eqRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                dt.Rows.Add(dr("size"), dr("type"), dr("thick"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            dr.Close()
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '============= SIZE ========================================================================================================================================================================================================
    Public Function selectSizesMaterialPiping(Optional type As String = "", Optional thick As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select distinct size from pipingMaterial " + If(type <> "", " where " + " [type]='" + type + "'", "") + If(thick <> "", If(type <> "", " and ", "") + " thick=" + thick + "", ""), conn)
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                dt.Columns.Add("size")
                Return dt
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '==================================================================================================================================================================================================================================================================
    '======= METODOS PARA RFI PIPING ==================================================================================================================================================================================================================================
    '==================================================================================================================================================================================================================================================================

    Public Function selectMaxRFIPp(ByVal idTag As String, ByVal idDrawingNum As String) As Integer
        Try
            conectar()
            Dim cmd As New SqlCommand("select isnull( max(convert(decimal,idRFIPp))+1,1) as 'maxRFI' from RFIPiping where tag='" + idTag + "'and idDrawingNum= '" + idDrawingNum + "'", conn)
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
    Public Function SaveUpdateRFIPiping(ByVal RFI As RFIPPClass) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
                if (select COUNT(*) from RFIPiping where idRFIPp= '" + RFI.IdRFIPp + "' and tag = " + RFI.Tag.ToString() + " and idDrawingNum = '" + RFI.IdDrawingNum + "')=0
                begin 
	                insert into RFIPiping values ('" + RFI.IdRFIPp + "'," + RFI.Tag.ToString() + ",'" + RFI.IdDrawingNum + "'," + RFI.OldSize.ToString() + "," + RFI.OldElevation.ToString() + "," + If(RFI.OldSystem = "NULL", "NULL", "'" + RFI.OldSystem.ToString() + "'") + "," + If(RFI.OldOption = "NULL", "NULL", "'" + RFI.OldOption.ToString() + "'") + "," + If(RFI.OldType = "NULL", "NULL", "'" + RFI.OldType.ToString() + "'") + "," + RFI.OldThick.ToString() + "," + If(RFI.OldIdJacket = "NULL", "NULL", "'" + RFI.OldIdJacket.ToString() + "'") + ",
                        " + If(RFI.OldIdLaborRatePnt = "NULL", "NULL", "'" + RFI.OldIdLaborRatePnt.ToString.Replace("'", "''") + "'") + "," + RFI.OldLFtPnt.ToString() + "," + RFI.OldP90Pnt.ToString() + "," + RFI.OldP45Pnt.ToString() + "," + RFI.OldPTeePnt.ToString() + "," + RFI.OldPPairPnt.ToString() + "," + RFI.OldPVlvPnt.ToString() + "," + RFI.OldPControlPnt.ToString() + "," + RFI.OldPWeldPnt.ToString() + ",
                        " + If(RFI.OldIdLaborRateRmv = "NULL", "NULL", "'" + RFI.OldIdLaborRateRmv.ToString.Replace("'", "''") + "'") + "," + RFI.OldLFtRmv.ToString() + ",
                        " + If(RFI.OldIdLaborRateII = "NULL", "NULL", "'" + RFI.OldIdLaborRateII.ToString.Replace("'", "''") + "'") + "," + RFI.OldLFtII.ToString() + "," + RFI.OldP90II.ToString() + "," + RFI.OldP45II.ToString() + "," + RFI.OldPBendII.ToString() + "," + RFI.OldPTeeII.ToString() + "," + RFI.OldPReducII.ToString() + "," + RFI.OldPCapsII.ToString() + "," + RFI.OldPPairII.ToString() + "," + RFI.OldPVlvII.ToString() + "," + RFI.OldPControlII.ToString() + "," + RFI.OldPWeldII.ToString() + "," + RFI.OldPCutOutII.ToString() + "," + RFI.OldPsupportII.ToString() + ",
                        " + RFI.NewSize.ToString() + "," + RFI.NewElevation.ToString() + "," + If(RFI.NewSystem = "NULL", "NULL", "'" + RFI.NewSystem.ToString() + "'") + "," + If(RFI.NewOption = "NULL", "NULL", "'" + RFI.NewOption.ToString() + "'") + "," + If(RFI.NewType = "NULL", "NULL", "'" + RFI.NewType.ToString() + "'") + "," + RFI.NewThick.ToString() + "," + If(RFI.NewIdJacket = "NULL", "NULL", "'" + RFI.NewIdJacket.ToString() + "'") + ",
                        " + If(RFI.NewIdLaborRatePnt = "NULL", "NULL", "'" + RFI.NewIdLaborRatePnt.ToString.Replace("'", "''") + "'") + "," + RFI.NewLFtPnt.ToString() + "," + RFI.NewP90Pnt.ToString() + "," + RFI.NewP45Pnt.ToString() + "," + RFI.NewPTeePnt.ToString() + "," + RFI.NewPPairPnt.ToString() + "," + RFI.NewPVlvPnt.ToString() + "," + RFI.NewPControlPnt.ToString() + "," + RFI.NewPWeldPnt.ToString() + ",
                        " + If(RFI.NewIdLaborRateRmv = "NULL", "NULL", "'" + RFI.NewIdLaborRateRmv.ToString.Replace("'", "''") + "'") + "," + RFI.NewLFtRmv.ToString() + ",
                        " + If(RFI.NewIdLaborRateII = "NULL", "NULL", "'" + RFI.NewIdLaborRateII.ToString.Replace("'", "''") + "'") + "," + RFI.NewLFtRmv.ToString() + "," + RFI.NewP90II.ToString() + "," + RFI.NewP45II.ToString() + "," + RFI.NewPBendII.ToString() + "," + RFI.NewPTeeII.ToString() + "," + RFI.NewPReducII.ToString() + "," + RFI.NewPCapsII.ToString() + "," + RFI.NewPPairII.ToString() + "," + RFI.NewPVlvII.ToString() + "," + RFI.NewPControlII.ToString() + "," + RFI.NewPWeldII.ToString() + "," + RFI.NewPCutOutII.ToString() + "," + RFI.NewPsupportII.ToString() + ",
                        '" + RFI.ReqEmployee + "','" + RFI.ReqTitleEmployee + "','" + validaFechaParaSQl(RFI.ReqDate) + "','" + RFI.ReqCompany + "','" + RFI.ChUpEmployee + "','" + RFI.ChUpTitleEmployee + "','" + validaFechaParaSQl(RFI.ChUpDate) + "','" + RFI.BasicFCR.ToString() + "','" + validaFechaParaSQl(RFI.WeDate) + "','" + RFI.Note + "')
                       
                    update pipingEst set 
                     size = " + RFI.NewSize.ToString() + ",[type]=" + If(RFI.NewType = "NULL", "NULL", "'" + RFI.NewType.ToString() + "'") + ",thick=" + RFI.NewThick.ToString() + ",systemPntPP=" + If(RFI.NewSystem = "NULL", "NULL", "'" + RFI.NewSystem.ToString() + "'") + ",pntOption=" + If(RFI.NewOption = "NULL", "NULL", "'" + RFI.NewOption.ToString() + "'") + ",idJacket=" + If(RFI.NewIdJacket = "NULL", "NULL", "'" + RFI.NewIdJacket.ToString() + "'") + ",elevation=" + RFI.NewElevation.ToString() + ",
                     idLaborRateRmv = " + If(RFI.NewIdLaborRateRmv = "NULL", "NULL", "'" + RFI.NewIdLaborRateRmv.ToString.Replace("'", "''") + "'") + ",lFtRmv=" + RFI.NewLFtRmv.ToString() + ",
                     idLaborRatePnt = " + If(RFI.NewIdLaborRatePnt = "NULL", "NULL", "'" + RFI.NewIdLaborRatePnt.ToString.Replace("'", "''") + "'") + ",lFtPnt=" + RFI.NewLFtPnt.ToString() + ",p90Pnt=" + RFI.NewP90Pnt.ToString() + ",p45Pnt=" + RFI.NewP45Pnt.ToString() + ",pTeePnt=" + RFI.NewPTeePnt.ToString() + ",pPairPnt=" + RFI.NewPPairPnt.ToString() + ",pVlvPnt=" + RFI.NewPVlvPnt.ToString() + ",pControlPnt=" + RFI.NewPControlPnt.ToString() + ",pWeldPnt=" + RFI.NewPWeldPnt.ToString() + ",
                     idLaborRateII = " + If(RFI.NewIdLaborRateII = "NULL", "NULL", "'" + RFI.NewIdLaborRateII.ToString.Replace("'", "''") + "'") + ",lFtII=" + RFI.NewLFtII.ToString() + ",p90II=" + RFI.NewP90II.ToString() + ",p45II=" + RFI.NewP45II.ToString() + ",pBendII=" + RFI.NewPBendII.ToString() + ",pTeeII=" + RFI.NewPTeeII.ToString() + ",pReducII=" + RFI.NewPReducII.ToString() + ",pCapsII=" + RFI.NewPCapsII.ToString() + ",pPairII=" + RFI.NewPPairII.ToString() + ",pVlvII=" + RFI.NewPVlvII.ToString() + ",pControlII=" + RFI.NewPControlII.ToString() + ",pWeldII=" + RFI.NewPWeldPnt.ToString() + ",pCutOutII=" + RFI.NewPCutOutII.ToString() + ",psupportII=" + RFI.NewPsupportII.ToString() + "  
                     where idPipingEst = " + RFI.Tag.ToString() + " and idDrawingNum = '" + RFI.IdDrawingNum + "'
                    end
            else if (select COUNT(*) from RFIPiping where idRFIPp = '" + RFI.IdRFIPp + "' and tag = " + RFI.Tag.ToString() + " and idDrawingNum = '" + RFI.IdDrawingNum + "')=1
            begin
                update RFIPiping set oldSize=" + RFI.OldSize.ToString() + ", oldElevation = " + RFI.OldElevation.ToString.Replace("'", "''") + ",oldSystem=" + If(RFI.OldSystem = "NULL", "NULL", "'" + RFI.OldSystem.ToString() + "'") + ",oldOption=" + If(RFI.OldOption = "NULL", "NULL", "'" + RFI.OldOption.ToString() + "'") + ",oldType=" + If(RFI.OldType = "NULL", "NULL", "'" + RFI.OldType.ToString() + "'") + ",oldThick=" + RFI.OldThick.ToString() + ",oldIdJacket=" + If(RFI.OldIdJacket = "NULL", "NULL", "'" + RFI.OldIdJacket.ToString() + "'") + ",
                    oldIdLaborRatePnt = " + If(RFI.OldIdLaborRatePnt = "NULL", "NULL", "'" + RFI.OldIdLaborRatePnt.ToString.Replace("'", "''") + "'") + ",oldLFtPnt=" + RFI.OldLFtPnt.ToString() + ",oldP90Pnt=" + RFI.OldP90Pnt.ToString() + ",oldP45Pnt=" + RFI.OldP45Pnt.ToString() + ",oldPTeePnt=" + RFI.OldPTeePnt.ToString() + ",oldPPairPnt=" + RFI.OldPPairPnt.ToString() + ",oldPVlvPnt=" + RFI.OldPVlvPnt.ToString() + ",oldPControlPnt=" + RFI.OldPControlPnt.ToString() + ",oldPWeldPnt=" + RFI.OldPWeldPnt.ToString() + ",
                    oldIdLaborRateRmv = " + If(RFI.OldIdLaborRateRmv = "NULL", "NULL", "'" + RFI.OldIdLaborRateRmv.ToString.Replace("'", "''") + "'") + ",oldLFtRmv=" + RFI.OldLFtRmv.ToString() + ",
                    oldIdLaborRateII = " + If(RFI.OldIdLaborRateII = "NULL", "NULL", "'" + RFI.OldIdLaborRateII.ToString.Replace("'", "''") + "'") + ",oldLFtII=" + RFI.OldLFtII.ToString() + ",oldP90II=" + RFI.OldP90II.ToString() + ",oldP45II=" + RFI.OldP45II.ToString() + ",oldPBendII=" + RFI.OldPBendII.ToString() + ",oldPTeeII=" + RFI.OldPTeeII.ToString() + ",oldPReducII=" + RFI.OldPReducII.ToString() + ",oldPCapsII=" + RFI.OldPCapsII.ToString() + ",oldPPairII=" + RFI.OldPPairII.ToString() + ",oldPVlvII=" + RFI.OldPVlvII.ToString() + ",oldPControlII=" + RFI.OldPControlII.ToString() + ",oldPWeldII=" + RFI.OldPWeldII.ToString() + ",oldPCutOutII=" + RFI.OldPCutOutII.ToString() + ",oldPsupportII=" + RFI.OldPsupportII.ToString() + ",

                    newIdLaborRatePnt = " + If(RFI.NewIdLaborRatePnt = "NULL", "NULL", "'" + RFI.NewIdLaborRatePnt.ToString.Replace("'", "''") + "'") + ",newLFtPnt=" + RFI.NewLFtPnt.ToString() + ",newP90Pnt=" + RFI.NewP90Pnt.ToString() + ",newP45Pnt=" + RFI.NewP45Pnt.ToString() + ",newPTeePnt=" + RFI.NewPTeePnt.ToString() + ",newPPairPnt=" + RFI.NewPPairPnt.ToString() + ",newPVlvPnt=" + RFI.NewPVlvPnt.ToString() + ",newPControlPnt=" + RFI.NewPControlPnt.ToString() + ",newPWeldPnt=" + RFI.NewPWeldPnt.ToString() + ",
                    newIdLaborRateRmv = " + If(RFI.NewIdLaborRateRmv = "NULL", "NULL", "'" + RFI.NewIdLaborRateRmv.ToString.Replace("'", "''") + "'") + ",newLFtRmv=" + RFI.NewLFtRmv.ToString() + ",
                    newIdLaborRateII = " + If(RFI.NewIdLaborRateII = "NULL", "NULL", "'" + RFI.NewIdLaborRateII.ToString.Replace("'", "''") + "'") + ",newLFtII=" + RFI.NewLFtII.ToString() + ",newP90II=" + RFI.NewP90II.ToString() + ",newP45II=" + RFI.NewP45II.ToString() + ",newPBendII=" + RFI.NewPBendII.ToString() + ",newPTeeII=" + RFI.NewPTeeII.ToString() + ",newPReducII=" + RFI.NewPReducII.ToString() + ",newPCapsII=" + RFI.NewPCapsII.ToString() + ",newPPairII=" + RFI.NewPPairII.ToString() + ",newPVlvII=" + RFI.NewPVlvII.ToString() + ",newPControlII=" + RFI.NewPControlII.ToString() + ",newPWeldII=" + RFI.NewPWeldII.ToString() + ",newPCutOutII=" + RFI.NewPCutOutII.ToString() + ",newPsupportII=" + RFI.NewPsupportII.ToString() + ",
                    reqEmployee ='" + RFI.ReqEmployee + "',reqTitleEmployee='" + RFI.ReqTitleEmployee + "',reqDate='" + validaFechaParaSQl(RFI.ReqDate) + "',reqCompany='" + RFI.ReqCompany + "',chUpEmployee='" + RFI.ChUpEmployee + "',chUpTitleEmployee='" + RFI.ChUpTitleEmployee + "',chUpDate='" + validaFechaParaSQl(RFI.ChUpDate) + "',basicFCR='" + RFI.BasicFCR.ToString() + "',weDate='" + validaFechaParaSQl(RFI.WeDate) + "',note='" + RFI.Note + "'
                 where idRFIPp = '" + RFI.IdRFIPp + "' and tag = " + RFI.Tag.ToString() + " and idDrawingNum = '" + RFI.IdDrawingNum + "'
            if (select top 1 max(CONVERT(decimal,idRFIPp)) from RFIPiping) = " + RFI.IdRFIPp + "
            begin
                update pipingEst set 
                size = " + RFI.NewSize.ToString() + ",[type]=" + If(RFI.NewType = "NULL", "NULL", "'" + RFI.NewType.ToString() + "'") + ",thick=" + RFI.NewThick.ToString() + ",systemPntPP=" + If(RFI.NewSystem = "NULL", "NULL", "'" + RFI.NewSystem.ToString() + "'") + ",pntOption=" + If(RFI.NewOption = "NULL", "NULL", "'" + RFI.NewOption.ToString() + "'") + ",idJacket=" + If(RFI.NewIdJacket = "NULL", "NULL", "'" + RFI.NewIdJacket.ToString() + "'") + ",elevation=" + RFI.NewElevation.ToString() + ",
                idLaborRateRmv = " + If(RFI.NewIdLaborRateRmv = "NULL", "NULL", "'" + RFI.NewIdLaborRateRmv.ToString.Replace("'", "''") + "'") + ",lFtRmv=" + RFI.NewLFtRmv.ToString() + ",
                idLaborRatePnt = " + If(RFI.NewIdLaborRatePnt = "NULL", "NULL", "'" + RFI.NewIdLaborRatePnt.ToString.Replace("'", "''") + "'") + ",lFtPnt=" + RFI.NewLFtPnt.ToString() + ",p90Pnt=" + RFI.NewP90Pnt.ToString() + ",p45Pnt=" + RFI.NewP45Pnt.ToString() + ",pTeePnt=" + RFI.NewPTeePnt.ToString() + ",pPairPnt=" + RFI.NewPPairPnt.ToString() + ",pVlvPnt=" + RFI.NewPVlvPnt.ToString() + ",pControlPnt=" + RFI.NewPControlPnt.ToString() + ",pWeldPnt=" + RFI.NewPWeldPnt.ToString() + ",
                idLaborRateII = " + If(RFI.NewIdLaborRateII = "NULL", "NULL", "'" + RFI.NewIdLaborRateII.ToString.Replace("'", "''") + "'") + ",lFtII=" + RFI.NewLFtII.ToString() + ",p90II=" + RFI.NewP90II.ToString() + ",p45II=" + RFI.NewP45II.ToString() + ",pBendII=" + RFI.NewPBendII.ToString() + ",pTeeII=" + RFI.NewPTeeII.ToString() + ",pReducII=" + RFI.NewPReducII.ToString() + ",pCapsII=" + RFI.NewPCapsII.ToString() + ",pPairII=" + RFI.NewPPairII.ToString() + ",pVlvII=" + RFI.NewPVlvII.ToString() + ",pControlII=" + RFI.NewPControlII.ToString() + ",pWeldII=" + RFI.NewPWeldII.ToString() + ",pCutOutII=" + RFI.NewPCutOutII.ToString() + ",psupportII=" + RFI.NewPsupportII.ToString() + "
                where idPipingEst = " + RFI.Tag.ToString() + " and idDrawingNum = '" + RFI.IdDrawingNum + "'
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
    Public Function deleteRFIPiping(ByVal RFIDelete As String, ByVal idTag As String, ByVal idDrawingNum As String, Optional RFINext As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_deleteRFIPiping", conn)
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
