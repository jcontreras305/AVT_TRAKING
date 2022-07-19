Imports System.Data.SqlClient
Public Class MetodosRFIEquipment
    Inherits ConnectioDB
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
            Dim cmd As New SqlCommand("select eq.idEquimentEst as 'idTag',eq.[description], 
eq.elevation, 
ISNULL(eq.idLaborRatePnt,'')as 'wwPaint',ISNULL(eq.systemPntEq,'')as 'system',ISNULL(eq.pntOption,'') as 'option' , eq.sqrFtPnt ,
ISNULL(eq.idLaborRateRmv,'')as 'wwRemove',eq.remIns as 'remove',eq.sqrFtRmv,
ISNULL(eq.idLaborRateII,'')as 'wwInstall',ISNULL(eq.[type],'') as 'type',ISNULL(eq.thick,0) as 'thick',ISNULL(eq.idJacket,'') as 'jacket',eq.sqrFtII,eq.bevel,eq.cutout,
dr.idDrawingNum from equipmentEst as eq
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
" + If(idDrawing = "", "", "where eq.idDrawingNum = '" + idDrawing + "'") + "
order by eq.idEquimentEst asc", conn)
            Dim dt As New Data.DataTable
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim clmArray() As String = {"idTag", "description", "elevation", "wwPaint", "system", "option", "sqrFtPnt", "wwRemove", "remove", "sqrFtRmv", "wwInstall", "type", "thick", "jacket", "sqrFtII", "bevel", "cutout", "idDrawingNum"}
            For Each element As String In clmArray
                dt.Columns.Add(element)
            Next
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
                cmb.Text = ""
            End If
            While dr.Read()
                dt.Rows.Add(dr("idTag"), dr("description"), dr("elevation"), dr("wwPaint"), dr("system"), dr("option"), dr("sqrFtPnt"), dr("wwRemove"), dr("remove"), dr("sqrFtRmv"), dr("wwInstall"), dr("type"), dr("thick"), dr("jacket"), dr("sqrFtII"), dr("bevel"), dr("cutout"), dr("idDrawingNum"))
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

    Public Function selectRFIEquipment(ByVal tag As String, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idRFIEq, tag as 'idTag',idDrawingNum ,
newElevation , newWwPaint, newSystem, newOption, newSqrFtPnt, 
newWwRemove ,newRemove, newSqrFtRmv, 
newWwInstall, newType, newThick, newJacket, newSqrFtII, newBevel, newCutOut,
oldElevation, oldWwPaint, oldSystem, oldOption, oldSqrFtPnt,
oldWwRemove, oldRemove, oldSqrFtRmv, 
oldWwInstall, oldType, oldThick, oldJacket, oldSqrFtII, oldBevel, oldCutOut,
reqEmployee, reqTitleEmployee, CONVERT(nvarchar, reqDate,101) as 'reqDate',reqCompany,
chUpEmployee, chUpTitleEmployee, CONVERT(nvarchar,chUpDate,101) as 'chUpDate',
basicFCR,CONVERT(nvarchar, weDate,101) as 'weDate',note
from RFIEquipment as rfi where rfi.tag = " + tag + " " + If(idDrawing <> "", "", "' and rfi.idDrawingNum = '" + idDrawing + "'") + "
order by convert (decimal, idRFIEq) asc", conn)
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                Dim clmArray() As String = {"idRFIEq", "idTag", "idDrawingNum", "newElevation", "newWwPaint", "newSystem", "newOption", "newSqrFtPnt", "newWwRemove", "newRemove", "newSqrFtRmv", "newWwInstall", "newType", "newThick", "newJacket", "newSqrFtII", "newBevel", "newCutOut", "oldElevation", "oldWwPaint", "oldSystem", "oldOption", "oldSqrFtPnt", "oldWwRemove", "oldRemove", "oldSqrFtRmv", "oldWwInstall", "oldType", "oldThick", "oldJacket", "oldSqrFtII", "oldBevel", "oldCutOut"}
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
    Public Function selectRFIEquipment(ByVal tag As String, ByVal cmb As ComboBox, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select rfiEq.idRFIEq , CONVERT(nvarchar,rfiEq.reqDate,101) as 'reqDate',dr.idDrawingNum,dr.[description] as 'drDescription',po.projectId ,po.[description] as 'poDescription',po.unit,cl.numberClient from RFIEquipment as rfiEq
inner join equipmentEst as eq on rfiEq.idDrawingNum= eq.idDrawingNum and rfiEq.tag = eq.idEquimentEst
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
where rfiEq.tag = " + tag + " " + If(idDrawing <> "", "", "' and rfi.idDrawingNum = '" + idDrawing + "'") + "
order by convert (decimal, idRFIEq) asc", conn)
            Dim dt As New Data.DataTable
            cmb.Items.Clear()
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                For Each row As Data.DataRow In dt.Rows
                    cmb.Items.Add(row.ItemArray(0) + "| " + row.ItemArray(1))
                Next
            Else
                Dim clmArray() As String = {"rfiEq.idRFIEq", "reqDate", "idDrawingNum", "drDescription", "projectId", "poDescription", "unit", "numberClient"}
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

    Public Function selectMaxRFIEq(ByVal idTag As String, ByVal idDrawingNum As String) As Integer
        Try
            conectar()
            Dim cmd As New SqlCommand("select isnull( max(convert(decimal,idRFIEq))+1,1) as 'maxRFI' from RFIEquipment where tag='" + idTag + "'and idDrawingNum= '" + idDrawingNum + "'", conn)
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
    '################################################################################################################################################################################################################################
    '########### METODOS PARA COMBOS EN LAS TABLAS ##################################################################################################################################################################################
    '################################################################################################################################################################################################################################
    Public Function llenarCmbCellLabor(ByVal cmb As DataGridViewComboBoxCell) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idLaborRate from laborRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idLaborRate"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarCmbCellSystemPaint(ByVal cmb As DataGridViewComboBoxCell) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select distinct systemPntEq from eqPaintUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("systemPntEq"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarCmbCellPaintOption(ByVal cmb As DataGridViewComboBoxCell, Optional SystemPnt As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select distinct pntOption from eqPaintUnitRate " + If(SystemPnt = "", "", " where systemPntEq = '" + SystemPnt + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("pntOption"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarCmbCellEqInsUnitRate(Optional ByVal cmb As DataGridViewComboBoxCell = Nothing) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type],thick from eqInsUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
            End If
            Dim tbl As New Data.DataTable
            tbl.Columns.Add("type")
            tbl.Columns.Add("thick")
            While dr.Read()
                tbl.Rows.Add(dr("type"), dr("thick"))
            End While
            If cmb IsNot Nothing Then
                For Each row As Data.DataRow In tbl.Rows
                    If Not cmb.Items.Contains(row.ItemArray(0)) Then
                        cmb.Items.Add(row.ItemArray(0))
                    End If
                Next
            End If
            Return tbl
        Catch ex As Exception
            MsgBox(ex.Message)
            Dim tblAux As New Data.DataTable
            tblAux.Columns.Add("type")
            tblAux.Columns.Add("thick")
            Return tblAux
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarCmbCellEqJacket(ByVal cmb As DataGridViewComboBoxCell) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJacket from eqJktUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If cmb IsNot Nothing Then
                cmb.Items.Clear()
            End If
            While dr.Read()
                cmb.Items.Add(dr("idJacket"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    'else if (select COUNT(*) from RFIEquipment where  tag = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "' and idRFIEq = '" & rfiEq.IdRFIEq & "')=1
    'begin
    'update RFIEquipment set 
    '    newElevation = " & rfiEq.NewElevation.ToString() & ",newWwPaint=" & If(rfiEq.NewWwPaint = "NULL", "NULL", "'" & rfiEq.NewWwPaint.Replace("'", "''") & "'") & ",newSystem=" & If(rfiEq.NewSystem = "NULL", "NULL", "'" & rfiEq.NewSystem & "'") & ",newOption=" & If(rfiEq.NewOption = "NULL", "NULL", "'" & rfiEq.NewOption & "'") & ",newSqrFtPnt=" & rfiEq.NewSqrFtPnt.ToString() & ",
    '    newWwRemove = " & If(rfiEq.NewWwRemove = "NULL", "NULL", "'" & rfiEq.NewWwRemove.Replace("'", "''") & "'") & ",newRemove=" & If(rfiEq.NewRemove, "1", "0") & ",newSqrFtRmv=" & rfiEq.NewSqrFtRmv.ToString() & ",
    '    newWwInstall = " & If(rfiEq.NewWwInstall = "NULL", "NULL", "'" & rfiEq.NewWwInstall.Replace("'", "''") & "'") & ",newType=" & If(rfiEq.NewType = "NULL", "NULL", "'" & rfiEq.NewType & "'") & ",newThick=" & rfiEq.NewThick.ToString() & ",newJacket=" & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.NewJacket & "'") & ",newSqrFtII=" & rfiEq.NewSqrFtII.ToString() & ",newBevel=" & rfiEq.NewBevel.ToString() & ",newCutOut=" & rfiEq.NewCutOut.ToString() & ",
    '    oldElevation = " & rfiEq.OldElevation.ToString() & ",oldWwPaint=" & If(rfiEq.OldWwPaint = "NULL", "NULL", "'" & rfiEq.OldWwPaint.Replace("'", "''")) & "'" & ",oldSystem=" & If(rfiEq.OldSystem = "NULL", "NULL", "'" & rfiEq.OldSystem & "'") & ",oldOption=" & If(rfiEq.OldOption = "NULL", "NULL", "'" & rfiEq.OldOption & "'") & ",oldSqrFtPnt=" & rfiEq.OldSqrFtPnt.ToString() & ",
    '    oldWwRemove = " & If(rfiEq.OldWwRemove = "NULL", "NULL", "'" & rfiEq.OldWwRemove.Replace("'", "''") & "'") & ",oldRemove=" & If(rfiEq.OldRemove, "1", "0") & ",oldSqrFtRmv=" & rfiEq.OldSqrFtRmv.ToString() & ",
    '    oldWwInstall = " & If(rfiEq.OldWwInstall = "NULL", "NULL", "'" & rfiEq.OldWwInstall.Replace("'", "''") & "'") & ",oldType=" & If(rfiEq.OldType = "NULL", "NULL", "'" & rfiEq.OldType & "'") & ",oldThick=" & rfiEq.OldThick.ToString() & ",oldJacket=" & If(rfiEq.OldJacket = "NULL", "NULL", "'" & rfiEq.OldJacket & "'") & ",oldSqrFtII=" & rfiEq.OldSqrFtII.ToString() & ",oldBevel=" & rfiEq.OldBevel.ToString() & ",oldCutOut=" & rfiEq.OldCutOut.ToString() & ",
    '    reqEmployee ='" & rfiEq.ReqEmployee & "',reqTitleEmployee='" & rfiEq.ReqTitleEmployee & "',reqDate='" & validaFechaParaSQl(rfiEq.ReqDate) & "',reqCompany='" & rfiEq.ReqCompany & "',chUpEmployee='" & rfiEq.ChUpEmployee & "',chUpTitleEmployee='" & rfiEq.ChUpTitleEmployee & "',chUpDate='" & validaFechaParaSQl(rfiEq.ChUpDate) & "',basicFCR=" & rfiEq.BasicFCR & ",weDate='" & validaFechaParaSQl(rfiEq.WeDate) & "',note='" & rfiEq.Note & "' where  tag = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "' and idRFIEq = '" & rfiEq.IdRFIEq & "'
    '    if (select top 1 ISNULL(MAX(idRFIEq),1) from RFIEquipment where  tag = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "')= '" & rfiEq.IdRFIEq & "'
    '    begin
    '       update equipmentEst set elevation = " & rfiEq.NewElevation.ToString & " , systemPntEq = " & If(rfiEq.NewSystem = "NULL", "NULL", "'" & rfiEq.NewSystem & "'") & ", pntOption=" & If(rfiEq.NewOption = "NULL", "NULL", "'" & rfiEq.NewOption & "'") & ",[type]=" & If(rfiEq.NewType = "NULL", "NULL", "'" & rfiEq.NewType & "'") & ",thick=" & rfiEq.NewThick.ToString() & ",idJacket=" & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.NewJacket & "'") & ",remIns = " & If(rfiEq.NewRemove, "1", "0") & ",idLaborRateRmv=" & If(rfiEq.NewWwRemove = "NULL", "NULL", "'" & rfiEq.NewWwRemove.Replace("'", "''") & "'") & ",sqrFtRmv=" & rfiEq.NewSqrFtRmv.ToString & ",idLaborRatePnt=" & If(rfiEq.NewWwPaint = "NULL", "NULL", "'" & rfiEq.NewWwPaint.Replace("'", "''") & "'") & ",sqrFtPnt=" & rfiEq.NewSqrFtPnt.ToString() & ",idLaborRateII=" & If(rfiEq.NewWwInstall = "NULL", "NULL", "'" & rfiEq.NewWwInstall.Replace("'", "''") & "'") & ",sqrFtII=" & rfiEq.NewSqrFtII.ToString() & ",bevel=" & rfiEq.NewBevel.ToString() & ",cutout=" & rfiEq.NewCutOut.ToString() & " where idEquimentEst = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "'
    '   end
    'end
    Public Function saveUpdateRFIEq(ByVal rfiEq As RFIEqClass) As Integer
        Try
            conectar()
            Dim cmd As New SqlCommand(
    "if (select COUNT(*) from RFIEquipment where  tag = " & rfiEq.IdTag.ToString() & " and idDrawingNum = '" & rfiEq.IdDrawingNum.ToString() & "' and idRFIEq = '" & rfiEq.IdRFIEq.ToString() & "')=0
    begin 
    	insert into RFIEquipment values ('" & rfiEq.IdRFIEq & "'," & rfiEq.IdTag & ",'" & rfiEq.IdDrawingNum & "',
            " & rfiEq.NewElevation.ToString() & "," & If(rfiEq.NewWwPaint = "NULL", "NULL", "'" & rfiEq.NewWwPaint.Replace("'", "''") & "'") & "," & If(rfiEq.NewSystem = "NULL", "NULL", "'" & rfiEq.NewSystem & "'") & "," & If(rfiEq.NewOption = "NULL", "NULL", "'" & rfiEq.NewOption & "'") & "," & rfiEq.NewSqrFtPnt.ToString() & ",
            " & If(rfiEq.NewWwRemove = "NULL", "NULL", "'" & rfiEq.NewWwRemove.Replace("'", "''") & "'") & "," & If(rfiEq.NewRemove, "1", "0") & "," & rfiEq.NewSqrFtRmv.ToString() & ",
            " & If(rfiEq.NewWwInstall = "NULL", "NULL", "'" & rfiEq.NewWwInstall.Replace("'", "''") & "'") & "," & If(rfiEq.NewType = "NULL", "NULL", "'" & rfiEq.NewType & "'") & "," & rfiEq.NewThick.ToString() & "," & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.NewJacket & "'") & "," & rfiEq.NewSqrFtII.ToString() & "," & rfiEq.NewBevel.ToString() & "," & rfiEq.NewCutOut.ToString() & ", 
            " & rfiEq.OldElevation.ToString() & "," & If(rfiEq.OldWwPaint = "NULL", "NULL", "'" & rfiEq.OldWwPaint.Replace("'", "''") & "'") & "," & If(rfiEq.OldSystem = "NULL", "NULL", "'" & rfiEq.OldSystem & "'") & "," & If(rfiEq.OldOption = "NULL", "NULL", "'" & rfiEq.OldOption & "'") & "," & rfiEq.OldSqrFtPnt.ToString() & ",
            " & If(rfiEq.OldWwRemove = "NULL", "NULL", "'" & rfiEq.OldWwRemove.Replace("'", "''") & "'") & "," & If(rfiEq.OldRemove, "1", "0") & "," & rfiEq.OldSqrFtRmv.ToString() & ",
            " & If(rfiEq.OldWwInstall = "NULL", "NULL", "'" & rfiEq.OldWwInstall.Replace("'", "''") & "'") & "," & If(rfiEq.OldType = "NULL", "NULL", "'" & rfiEq.OldType & "'") & "," & rfiEq.OldThick.ToString() & "," & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.OldJacket & "'") & "," & rfiEq.OldSqrFtII.ToString() & "," & rfiEq.NewBevel.ToString() & "," & rfiEq.NewCutOut.ToString() & ",
            '" & rfiEq.ReqEmployee & "','" & rfiEq.ReqTitleEmployee & "','" & validaFechaParaSQl(rfiEq.ReqDate) & "','" & rfiEq.ReqCompany & "','" & rfiEq.ChUpEmployee & "','" & rfiEq.ChUpTitleEmployee & "','" & validaFechaParaSQl(rfiEq.ChUpDate) & "'," & rfiEq.BasicFCR & ",'" & validaFechaParaSQl(rfiEq.WeDate) & "','" & rfiEq.Note & "')
    	update equipmentEst set elevation = " & rfiEq.NewElevation.ToString() & " ,systemPntEq = " & If(rfiEq.NewSystem = "NULL", "NULL", "'" & rfiEq.NewSystem & "'") & ", pntOption=" & If(rfiEq.NewOption = "NULL", "NULL", "'" & rfiEq.NewOption & "'") & ",[type]=" & If(rfiEq.NewType = "NULL", "NULL", "'" & rfiEq.NewType & "'") & ",thick=" & rfiEq.NewThick.ToString() & ",idJacket=" & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.NewJacket & "'") & ",remIns = " & If(rfiEq.NewRemove, "1", "0") & ",idLaborRateRmv=" & If(rfiEq.NewWwRemove = "NULL", "NULL", "'" & rfiEq.NewWwRemove.Replace("'", "''") & "'") & ",sqrFtRmv=" & rfiEq.NewSqrFtRmv.ToString() & ",idLaborRatePnt=" & If(rfiEq.NewWwPaint = "NULL", "NULL", "'" & rfiEq.NewWwPaint.Replace("'", "''") & "'") & ",sqrFtPnt=" & rfiEq.NewSqrFtPnt.ToString() & ",idLaborRateII=" & If(rfiEq.NewWwInstall = "NULL", "NULL", "'" & rfiEq.NewWwInstall.Replace("'", "''") & "'") & ",sqrFtII=" & rfiEq.NewSqrFtII.ToString() & ",bevel=" & rfiEq.NewBevel.ToString() & ",cutout=" & rfiEq.NewCutOut.ToString() & " where idEquimentEst = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "'
    end	
      else if (select COUNT(*) from RFIEquipment where  tag = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "' and idRFIEq = '" & rfiEq.IdRFIEq & "')=1
    begin
    update RFIEquipment set 
        newElevation = " & rfiEq.NewElevation.ToString() & ",newWwPaint=" & If(rfiEq.NewWwPaint = "NULL", "NULL", "'" & rfiEq.NewWwPaint.Replace("'", "''") & "'") & ",newSystem=" & If(rfiEq.NewSystem = "NULL", "NULL", "'" & rfiEq.NewSystem & "'") & ",newOption=" & If(rfiEq.NewOption = "NULL", "NULL", "'" & rfiEq.NewOption & "'") & ",newSqrFtPnt=" & rfiEq.NewSqrFtPnt.ToString() & ",
        newWwRemove = " & If(rfiEq.NewWwRemove = "NULL", "NULL", "'" & rfiEq.NewWwRemove.Replace("'", "''") & "'") & ",newRemove=" & If(rfiEq.NewRemove, "1", "0") & ",newSqrFtRmv=" & rfiEq.NewSqrFtRmv.ToString() & ",
        newWwInstall = " & If(rfiEq.NewWwInstall = "NULL", "NULL", "'" & rfiEq.NewWwInstall.Replace("'", "''") & "'") & ",newType=" & If(rfiEq.NewType = "NULL", "NULL", "'" & rfiEq.NewType & "'") & ",newThick=" & rfiEq.NewThick.ToString() & ",newJacket=" & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.NewJacket & "'") & ",newSqrFtII=" & rfiEq.NewSqrFtII.ToString() & ",newBevel=" & rfiEq.NewBevel.ToString() & ",newCutOut=" & rfiEq.NewCutOut.ToString() & ",
        oldElevation = " & rfiEq.OldElevation.ToString() & ",oldWwPaint=" & If(rfiEq.OldWwPaint = "NULL", "NULL", "'" & rfiEq.OldWwPaint.Replace("'", "''")) & "'" & ",oldSystem=" & If(rfiEq.OldSystem = "NULL", "NULL", "'" & rfiEq.OldSystem & "'") & ",oldOption=" & If(rfiEq.OldOption = "NULL", "NULL", "'" & rfiEq.OldOption & "'") & ",oldSqrFtPnt=" & rfiEq.OldSqrFtPnt.ToString() & ",
        oldWwRemove = " & If(rfiEq.OldWwRemove = "NULL", "NULL", "'" & rfiEq.OldWwRemove.Replace("'", "''") & "'") & ",oldRemove=" & If(rfiEq.OldRemove, "1", "0") & ",oldSqrFtRmv=" & rfiEq.OldSqrFtRmv.ToString() & ",
        oldWwInstall = " & If(rfiEq.OldWwInstall = "NULL", "NULL", "'" & rfiEq.OldWwInstall.Replace("'", "''") & "'") & ",oldType=" & If(rfiEq.OldType = "NULL", "NULL", "'" & rfiEq.OldType & "'") & ",oldThick=" & rfiEq.OldThick.ToString() & ",oldJacket=" & If(rfiEq.OldJacket = "NULL", "NULL", "'" & rfiEq.OldJacket & "'") & ",oldSqrFtII=" & rfiEq.OldSqrFtII.ToString() & ",oldBevel=" & rfiEq.OldBevel.ToString() & ",oldCutOut=" & rfiEq.OldCutOut.ToString() & ",
        reqEmployee ='" & rfiEq.ReqEmployee & "',reqTitleEmployee='" & rfiEq.ReqTitleEmployee & "',reqDate='" & validaFechaParaSQl(rfiEq.ReqDate) & "',reqCompany='" & rfiEq.ReqCompany & "',chUpEmployee='" & rfiEq.ChUpEmployee & "',chUpTitleEmployee='" & rfiEq.ChUpTitleEmployee & "',chUpDate='" & validaFechaParaSQl(rfiEq.ChUpDate) & "',basicFCR=" & rfiEq.BasicFCR & ",weDate='" & validaFechaParaSQl(rfiEq.WeDate) & "',note='" & rfiEq.Note & "' where  tag = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "' and idRFIEq = '" & rfiEq.IdRFIEq & "'
        if (select top 1 ISNULL(MAX(idRFIEq),1) from RFIEquipment where  tag = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "')= '" & rfiEq.IdRFIEq & "'
        begin
           update equipmentEst set elevation = " & rfiEq.NewElevation.ToString & " , systemPntEq = " & If(rfiEq.NewSystem = "NULL", "NULL", "'" & rfiEq.NewSystem & "'") & ", pntOption=" & If(rfiEq.NewOption = "NULL", "NULL", "'" & rfiEq.NewOption & "'") & ",[type]=" & If(rfiEq.NewType = "NULL", "NULL", "'" & rfiEq.NewType & "'") & ",thick=" & rfiEq.NewThick.ToString() & ",idJacket=" & If(rfiEq.NewJacket = "NULL", "NULL", "'" & rfiEq.NewJacket & "'") & ",remIns = " & If(rfiEq.NewRemove, "1", "0") & ",idLaborRateRmv=" & If(rfiEq.NewWwRemove = "NULL", "NULL", "'" & rfiEq.NewWwRemove.Replace("'", "''") & "'") & ",sqrFtRmv=" & rfiEq.NewSqrFtRmv.ToString & ",idLaborRatePnt=" & If(rfiEq.NewWwPaint = "NULL", "NULL", "'" & rfiEq.NewWwPaint.Replace("'", "''") & "'") & ",sqrFtPnt=" & rfiEq.NewSqrFtPnt.ToString() & ",idLaborRateII=" & If(rfiEq.NewWwInstall = "NULL", "NULL", "'" & rfiEq.NewWwInstall.Replace("'", "''") & "'") & ",sqrFtII=" & rfiEq.NewSqrFtII.ToString() & ",bevel=" & rfiEq.NewBevel.ToString() & ",cutout=" & rfiEq.NewCutOut.ToString() & " where idEquimentEst = " & rfiEq.IdTag & " and idDrawingNum = '" & rfiEq.IdDrawingNum & "'
       end
    end  
    ", conn)
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
    Public Function deleteRFIEquipment(ByVal RFIDelete As String, ByVal idTag As String, ByVal idDrawingNum As String, Optional RFINext As String = "") As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_deleteRFIEquipment", conn)
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
