Imports System.Data.SqlClient
Public Class MetodosEstimating
    Inherits ConnectioDB
    Public Function selectProjectsDrawing() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idDrawingNum,dr.[description],dr. projectId,cl.numberClient from drawing as dr
                inner join projectClientEst as po on po.projectId = dr.projectId
                inner join clientsEst as cl on cl.idClientEst= po.idClientEst
                order by dr.projectId", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New Data.DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectSacffoldEst() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select sc.tag , dr.idDrawingNum,dr.[description],dr. projectId,cl.numberClient from
scaffoldEst as sc
inner join drawing as dr on dr.idDrawingNum = sc.idDrawingNum 
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst= po.idClientEst
order by dr.projectId", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New Data.DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectPipingEst() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("
select idPipingEst,line,pp.size,pp.[type],pp.thick,pp.systemPntPP,pp.pntOption,pp.idJacket,pp.elevation,pp.idLaborRateRmv,pp.lFtRmv, 
pp.idLaborRatePnt,pp.lFtPnt,pp.p90Pnt,pp.p45Pnt,pp.pTeePnt,pp.pPairPnt,pp.pVlvPnt,pp.pControlPnt,pp.pWeldPnt,
pp.idLaborRateII,pp.lFtII,pp.p90II,pp.p45II,pp.pBendII,pp.pTeeII,pp.pReducII,pp.pCapsII,pp.pPairII,pp.pVlvII,pp.pControlII,pp.pWeldII,pp.pCutOutII,pp.psupportII,
pp.acm,pp.st,pp.idDrawingNum from pipingEst as pp
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
order by po.projectId", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New Data.DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectSCFByProject(ByVal connection As SqlConnection, ByVal transaction As SqlTransaction, Optional numberClient As String = "", Optional project As String = "") As Data.DataTable
        Try
            Dim cmd As New SqlCommand("select po.projectId, dr.idDrawingNum, scf.tag as 'tagId', scf.tag,lb.idLaborRate,ur.idSCFUR,ev.idEnviroment,scf.location,scf.[days],scf.width,scf.[length],scf.heigth,scf.decks,scf.build from scaffoldEst as scf 
            inner Join laborRate as lb on lb.idLaborRate = scf.idLaborRate 
inner Join scfUnitsRates as ur on ur.idSCFUR = scf.idSCFUR
inner Join enviroment as ev on ev.idEnviroment = scf.idEnviroment
inner Join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
inner Join projectClientEst as po on po.projectId = dr.projectId
inner Join clientsEst as cl on cl.idClientEst= po.idClientEst
" + If(numberClient <> "", "where cl.numberClient = " + numberClient + " ", "") + If(project <> "", If(numberClient <> "", " And ", " where ") + " po.projectId = '" + project + "'", ""), connection)
            cmd.Transaction = transaction
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectSCFDrawingProject(ByVal tbl As DataGridView, ByVal numberClient As String, ByVal project As String, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select po.projectId,dr.idDrawingNum,scf.tag as 'tagId', scf.tag,lb.idLaborRate,ur.idSCFUR,ev.idEnviroment,scf.location,scf.[days],scf.width,scf.[length],scf.heigth,scf.decks,scf.build from scaffoldEst as scf 
inner join laborRate as lb on lb.idLaborRate = scf.idLaborRate 
inner join scfUnitsRates as ur on ur.idSCFUR = scf.idSCFUR
inner join enviroment as ev on ev.idEnviroment = scf.idEnviroment
inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst= po.idClientEst
where cl.numberClient = " + numberClient + " and po.projectId = '" + project + "'" + If(idDrawing = "", "", " and dr.idDrawingNum = '" + idDrawing + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            dt.Columns.Add("projectId")
            dt.Columns.Add("idDrawingNum")
            dt.Columns.Add("tagId")
            dt.Columns.Add("tag")
            dt.Columns.Add("idLaborRate")
            dt.Columns.Add("idSCFUR")
            dt.Columns.Add("idEnviroment")
            dt.Columns.Add("location")
            dt.Columns.Add("days")
            dt.Columns.Add("width")
            dt.Columns.Add("length")
            dt.Columns.Add("heigth")
            dt.Columns.Add("decks")
            dt.Columns.Add("build")
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("tagId"), dr("tag"), dr("idLaborRate"), dr("idSCFUR"), dr("idEnviroment"), dr("location"), dr("days"), dr("width"), dr("length"), dr("heigth"), dr("decks"), dr("build"))
                dt.Rows.Add(dr("projectId"), dr("idDrawingNum"), dr("tagId"), dr("tag"), dr("idLaborRate"), dr("idSCFUR"), dr("idEnviroment"), dr("location"), dr("days"), dr("width"), dr("length"), dr("heigth"), dr("decks"), dr("build"))
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
    Public Function saveUpdateSCFDrawing(ByVal tbl As DataGridView, ByVal idDrawing As String, ByVal descriptionDrawing As String, ByVal projectId As String, Optional lastIdDrawing As String = "") As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmdDrawing As New SqlCommand
            If lastIdDrawing = "" Then 'insert 
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=0
                    begin
	                    insert into drawing values('" + idDrawing + "','" + descriptionDrawing + "','" + projectId + "')
                    end"
            Else ' update
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=1
                    begin 
	                    update drawing set idDrawingNum='" + idDrawing + "',[description]='" + descriptionDrawing + "',projectId='" + projectId + "' where idDrawingNum = '" + lastIdDrawing + "'
                    end"
            End If
            cmdDrawing.Connection = conn
            cmdDrawing.Transaction = tran
            If cmdDrawing.ExecuteNonQuery > 0 Then
                Dim flag As Boolean = True
                For Each row As DataGridViewRow In tbl.SelectedRows()
                    Dim cmbTags As New SqlCommand
                    If row.Cells("TagId").Value Is Nothing Or row.Cells("TagId").Value = "" Then
                        cmbTags.CommandText = "if (select count(*) from scaffoldEst as scf 
                        inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
                        where scf.tag = '" + row.Cells("Tag").Value.ToString() + "' and dr.projectId = '" + projectId + "')=0
                        begin 
	                        insert into scaffoldEst values ('" + row.Cells("Tag").Value.ToString() + "','" + row.Cells("Location").Value.ToString() + "'," + row.Cells("DaysUp").Value.ToString() + "," + row.Cells("Width").Value.ToString() + "," + row.Cells("Length").Value.ToString() + "," + row.Cells("Heigth").Value.ToString() + "," + row.Cells("Decks").Value.ToString() + "," + row.Cells("Build").Value.ToString() + ",'" + row.Cells("LaborRate").Value.ToString().Replace("'", "''") + "','" + row.Cells("TypeSC").Value.ToString() + "','" + row.Cells("Enviroment").Value.ToString() + "','" + idDrawing + "')
                        end"
                    Else
                        cmbTags.CommandText = "if (select count(*) from scaffoldEst as scf 
                        inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
                        where scf.tag = '" + row.Cells("TagId").Value.ToString + "' and dr.projectId = '" + projectId + "')=1
                        begin 
	                        update scaffoldEst set tag='" + row.Cells("Tag").Value.ToString + "',location='" + row.Cells("Location").Value.ToString + "',[days]=" + row.Cells("DaysUp").Value.ToString + " , width=" + row.Cells("Width").Value.ToString + ",[length]= " + row.Cells("Length").Value.ToString + ",heigth= " + row.Cells("Heigth").Value.ToString + ",decks= " + row.Cells("Decks").Value.ToString + ",build= " + row.Cells("Build").Value.ToString + ",idLaborRate ='" + row.Cells("LaborRate").Value.ToString.Replace("'", "''") + "',idSCFUR= '" + row.Cells("TypeSC").Value.ToString + "',idEnviroment= '" + row.Cells("Enviroment").Value.ToString + "',idDrawingNum= '" + idDrawing + "' where tag = '" + row.Cells("TagId").Value.ToString + "'	 
                        end"
                    End If
                    cmbTags.Connection = conn
                    cmbTags.Transaction = tran
                    If cmbTags.ExecuteNonQuery > 0 Then
                        Dim cmdEstCostBuild As New SqlCommand("exec sp_insertUpdateEstCostBuild '" + row.Cells("Tag").Value.ToString().Replace("'", "''") + "','" + idDrawing + "'," + row.Cells("Width").Value.ToString() + "," + row.Cells("Length").Value.ToString() + "," + row.Cells("Decks").Value.ToString() + ",'" + row.Cells("TypeSC").Value.ToString().Replace("'", "''") + "','" + row.Cells("LaborRate").Value.ToString().Replace("'", "''") + "'", conn)
                        cmdEstCostBuild.Transaction = tran
                        If cmdEstCostBuild.ExecuteNonQuery > 0 Then
                            Dim cmdEstCostDism As New SqlCommand("exec sp_insertUpdateEstCostDism '" + row.Cells("Tag").Value.ToString().Replace(",", "''") + "','" + idDrawing + "'," + row.Cells("Width").Value.ToString() + "," + row.Cells("Length").Value.ToString() + "," + row.Cells("Decks").Value.ToString() + ",'" + row.Cells("TypeSC").Value.ToString().Replace("'", "''") + "','" + row.Cells("LaborRate").Value.ToString().Replace("'", "''") + "'", conn)
                            cmdEstCostDism.Transaction = tran
                            If cmdEstCostDism.ExecuteNonQuery > 0 Then
                                flag = True
                            Else
                                flag = False
                                Exit For
                            End If
                        End If
                    End If
                Next
                If flag Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                MessageBox.Show(If(lastIdDrawing = "", "Is not posible to Insert ", "Is not prosible Update") + "the Drawing Project Plese check that is not inserted.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tran.Rollback()
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteSCFDrawing(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("TagId").Value IsNot Nothing Or row.Cells("TagId").Value = "" Then
                    Dim cmd As New SqlCommand("delete scaffoldEst where tag = '" + row.Cells("TagId").Value.ToString() + "'", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    '################################################################################################################################################################################################################################################
    '############### METODOS PARA DRAWING EQUIPMENT #################################################################################################################################################################################################
    '################################################################################################################################################################################################################################################
    Public Function selectMaxIdEquipment(ByRef label As Label) As Integer
        Try
            conectar()
            Dim cmd As New SqlCommand("select max(idEquimentEst)+1 as 'ID'from equipmentEst", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim id As Integer = 0
            While dr.Read()
                id = dr("ID")
            End While
            dr.Close()
            If id <> 0 Then
                label.Text = id.ToString()
                Return id
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 1
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectEqByProject(ByVal connection As SqlConnection, ByVal transaction As SqlTransaction, Optional numberClient As String = "", Optional project As String = "") As Data.DataTable
        Try
            Dim cmd As New SqlCommand("select  
idEquimentEst,eq.[description],elevation,systemPntEq,pntOption,[type],thick,idJacket,remIns,idLaborRateRmv,sqrFtRmv,idLaborRatePnt,sqrFtPnt,idLaborRateII,sqrFtII,bevel,cutout,acm,eq.idDrawingNum from equipmentEst as eq
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst" +
 If(numberClient <> "", " where cl.numberClient = " + numberClient + "", "") + If(project <> "", If(numberClient = "", " Where ", " And ") + " po.projectId = '" + project + "'", ""), connection)
            cmd.Transaction = transaction
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectEqDrawingProject(ByVal numberClient As String, ByVal project As String, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select  
idEquimentEst,eq.[description],elevation,systemPntEq,pntOption,[type],thick,idJacket,remIns,idLaborRateRmv,sqrFtRmv,idLaborRatePnt,sqrFtPnt,idLaborRateII,sqrFtII,bevel,cutout,acm from equipmentEst as eq
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
where cl.numberClient = " + numberClient + " and po.projectId = '" + project + "'" + If(idDrawing = "", "", " and dr.idDrawingNum = '" + idDrawing + "'") + " order by idEquimentEst desc", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            dt.Columns.Add("idEquipmentEstAux")
            dt.Columns.Add("idEquipmentEst")
            dt.Columns.Add("description")
            dt.Columns.Add("elevation")
            dt.Columns.Add("systemPntEq")
            dt.Columns.Add("pntOption")
            dt.Columns.Add("type")
            dt.Columns.Add("thick")
            dt.Columns.Add("idJacket")
            dt.Columns.Add("remIns")
            dt.Columns.Add("idLaborRateRmv")
            dt.Columns.Add("sqrFtRmv")
            dt.Columns.Add("idLaborRatePnt")
            dt.Columns.Add("sqrFtPnt")
            dt.Columns.Add("idLaborRateII")
            dt.Columns.Add("sqrFtII")
            dt.Columns.Add("bevel")
            dt.Columns.Add("cutout")
            dt.Columns.Add("acm")
            While dr.Read()
                dt.Rows.Add(dr("idEquimentEst"), dr("idEquimentEst"), dr("description"), If(dr("elevation") Is DBNull.Value, "", dr("elevation")), If(dr("systemPntEq") Is DBNull.Value, "", dr("systemPntEq")), If(dr("pntOption") Is DBNull.Value, "", dr("pntOption")), If(dr("type") Is DBNull.Value, "", dr("type")), dr("thick"), If(dr("idJacket") Is DBNull.Value, "", dr("idJacket")), If(dr("remIns"), "Yes", "No"), If(dr("idLaborRateRmv") Is DBNull.Value, "", dr("idLaborRateRmv")), dr("sqrFtRmv"), If(dr("idLaborRatePnt") Is DBNull.Value, "", dr("idLaborRatePnt")), dr("sqrFtPnt"), If(dr("idLaborRateII") Is DBNull.Value, "", dr("idLaborRateII")), dr("sqrFtII"), dr("bevel"), dr("cutout"), If(dr("acm"), "Yes", "No"))
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
    Public Function saveUpdateEqDrawingProject(ByVal tbl As Data.DataTable, ByVal idDrawing As String, ByVal descriptionDrawing As String, ByVal projectId As String, Optional lastIdDrawing As String = "") As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmdDrawing As New SqlCommand
            If lastIdDrawing = "" Then 'insert 
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=0
                    begin
	                    insert into drawing values('" + idDrawing + "','" + descriptionDrawing + "','" + projectId + "')
                    end"
            Else ' update
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=1
                    begin 
	                    update drawing set idDrawingNum='" + idDrawing + "',[description]='" + descriptionDrawing + "',projectId='" + projectId + "' where idDrawingNum = '" + lastIdDrawing + "'
                    end"
            End If
            cmdDrawing.Connection = conn
            cmdDrawing.Transaction = tran
            If cmdDrawing.ExecuteNonQuery > 0 Then
                Dim flag As Boolean = True
                For Each row As DataRow In tbl.Rows()
                    Dim cmbTags As New SqlCommand
                    If row.ItemArray(0) = "" Then
                        cmbTags.CommandText = "if (select count (*) from equipmentEst where idEquimentEst = " + row.ItemArray(1) + " )=0
                        begin
                            insert into equipmentEst values(" + row.ItemArray(1) + ",'" + row.ItemArray(2) + "'," + row.ItemArray(3) + "," + If(row.ItemArray(4) = "NULL", "NULL", "'" + row.ItemArray(4) + "'") + "," + If(row.ItemArray(5) = "NULL", "NULL", "'" + row.ItemArray(5) + "'") + "," + If(row.ItemArray(6) = "NULL", "NULL", "'" + row.ItemArray(6) + "'") + "," + row.ItemArray(7) + "," + If(row.ItemArray(8) = "NULL", "NULL", "'" + row.ItemArray(8) + "'") + "," + If(row.ItemArray(9) = "Yes", "1", "0") + "," + If(row.ItemArray(10) = "NULL", "NULL", "'" + row.ItemArray(10).ToString.Replace("'", "''") + "'") + "," + row.ItemArray(11) + "," + If(row.ItemArray(12) = "NULL", "NULL", "'" + row.ItemArray(12).ToString.Replace("'", "''") + "'") + "," + row.ItemArray(13) + "," + If(row.ItemArray(14) = "NULL", "NULL", "'" + row.ItemArray(14).ToString.Replace("'", "''") + "'") + "," + row.ItemArray(15) + "," + row.ItemArray(16) + "," + row.ItemArray(17) + "," + If(row.ItemArray(18) = "Yes", "1", "0") + ",'" + idDrawing + "')
                        end"
                    Else
                        cmbTags.CommandText = "if(select count(*) from equipmentEst where idEquimentEst=" + row.ItemArray(0) + ")=1
                        begin  
	                        update equipmentEst set idEquimentEst=" + row.ItemArray(1) + ",[description]='" + row.ItemArray(2) + "',elevation=" + row.ItemArray(3) + ",systemPntEq=" + If(row.ItemArray(4) = "NULL", "NULL", "'" + row.ItemArray(4) + "'") + ",pntOption=" + If(row.ItemArray(5) = "NULL", "NULL", "'" + row.ItemArray(5) + "'") + ",[type]=" + If(row.ItemArray(6) = "NULL", "NULL", "'" + row.ItemArray(6) + "'") + ",thick=" + row.ItemArray(7) + ",idJacket=" + If(row.ItemArray(8) = "NULL", "NULL", "'" + row.ItemArray(8) + "'") + ",remIns=" + If(row.ItemArray(9) = "Yes", "1", "0") + ",idLaborRateRmv=" + If(row.ItemArray(10) = "NULL", "NULL", "'" + row.ItemArray(10).ToString.Replace("'", "''") + "'") + ",sqrFtRmv=" + row.ItemArray(11) + ",idLaborRatePnt=" + If(row.ItemArray(12) = "NULL", "NULL", "'" + row.ItemArray(12).ToString.Replace("'", "''") + "'") + ",sqrFtPnt=" + row.ItemArray(13) + ",idLaborRateII=" + If(row.ItemArray(14) = "NULL", "NULL", "'" + row.ItemArray(14).ToString.Replace("'", "''") + "'") + ",sqrFtII=" + row.ItemArray(15) + ",bevel=" + row.ItemArray(16) + ",cutout=" + row.ItemArray(17) + ",acm=" + If(row.ItemArray(18) = "Yes", "1", "0") + ",idDrawingNum='" + idDrawing + "' where idEquimentEst = " + row.ItemArray(0) + "
                        end"
                    End If
                    cmbTags.Connection = conn
                    cmbTags.Transaction = tran
                    If cmbTags.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Next
                If flag Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                MessageBox.Show(If(lastIdDrawing = "", "Is not posible to Insert ", "Is not prosible Update") + "the Drawing Project Plese check that is not inserted.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteEqDrawingProject(ByVal tbl As Data.DataTable) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As Data.DataRow In tbl.Rows()
                If row.ItemArray(0) IsNot Nothing Or row.ItemArray(0) = "" Then
                    Dim cmd As New SqlCommand("delete from equipmentEst where idEquimentEst = " + row.ItemArray(0).ToString() + "", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '########################################################################################################################################################################################################################################################
    '###################### METODOS PARA PIPING ESTIMATION ##################################################################################################################################################################################################
    '########################################################################################################################################################################################################################################################
    Public Function selectMaxIdPiping(ByRef label As Label) As Integer
        Try
            conectar()
            Dim cmd As New SqlCommand("select max(idPipingEst)+1 as 'ID'from pipingEst", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim id As Integer = 0
            While dr.Read()
                id = dr("ID")
            End While
            dr.Close()
            If id <> 0 Then
                label.Text = id.ToString()
                Return id
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 1
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectPpByProject(ByVal connection As SqlConnection, ByVal transaction As SqlTransaction, Optional numberClient As String = "", Optional project As String = "") As Data.DataTable
        Try
            Dim cmd As New SqlCommand("select idPipingEst,line,pp.size,pp.[type],pp.thick,pp.systemPntPP,pp.pntOption,pp.idJacket,pp.elevation,pp.idLaborRateRmv,pp.lFtRmv, 
pp.idLaborRatePnt,pp.lFtPnt,pp.p90Pnt,pp.p45Pnt,pp.pTeePnt,pp.pPairPnt,pp.pVlvPnt,pp.pControlPnt,pp.pWeldPnt,
pp.idLaborRateII,pp.lFtII,pp.p90II,pp.p45II,pp.pBendII,pp.pTeeII,pp.pReducII,pp.pCapsII,pp.pPairII,pp.pVlvII,pp.pControlII,pp.pWeldII,pp.pCutOutII,pp.psupportII,
pp.acm,pp.st,pp.idDrawingNum from pipingEst as pp
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst" +
If(numberClient <> "", " where cl.numberClient = " + numberClient + "", "") + If(project <> "", If(numberClient <> "", " Where ", " And ") + " po.projectId = '" + project + "'", ""), connection)
            cmd.Transaction = transaction
            Dim dt As New Data.DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function selectPipingProjectsEst(ByVal numberClient As String, ByVal project As String, Optional idDrawing As String = "") As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idPipingEst,line,pp.size,pp.[type],pp.thick,pp.systemPntPP,pp.pntOption,pp.idJacket,pp.elevation,pp.idLaborRateRmv,pp.lFtRmv, 
pp.idLaborRatePnt,pp.lFtPnt,pp.p90Pnt,pp.p45Pnt,pp.pTeePnt,pp.pPairPnt,pp.pVlvPnt,pp.pControlPnt,pp.pWeldPnt,
pp.idLaborRateII,pp.lFtII,pp.p90II,pp.p45II,pp.pBendII,pp.pTeeII,pp.pReducII,pp.pCapsII,pp.pPairII,pp.pVlvII,pp.pControlII,pp.pWeldII,pp.pCutOutII,pp.psupportII,
pp.acm,pp.st,pp.idDrawingNum from pipingEst as pp
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
where cl.numberClient = " + numberClient + " and po.projectId = '" + project + "'" + If(idDrawing = "", "", " and dr.idDrawingNum = '" + idDrawing + "'") + " order by pp.idPipingEst desc ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            Dim arrayColumns() As String = {"idPipingEstAux", "idPipingEst", "line", "size", "type", "thick", "systemPntPP", "pntOption", "idJacket", "elevation", "idLaborRateRmv", "lFtRmv", "idLaborRatePnt", "lFtPnt", "p90Pnt", "p45Pnt", "pTeePnt", "pPairPnt", "pVlvPnt", "pControlPnt", "pWeldPnt", "idLaborRateII", "lFtII", "p90II", "p45II", "pBendII", "pTeeII", "pReducII", "pCapsII", "pPairII", "pVlvII", "pControlII", "pWeldII", "pCutOutII", "psupportII", "acm", "st", "idDrawingNum"}
            For Each clm As String In arrayColumns
                dt.Columns.Add(clm)
            Next
            While dr.Read()
                dt.Rows.Add(dr("idPipingEst"), dr("idPipingEst"), dr("line"), dr("size"), If(dr("type") Is DBNull.Value, "", dr("type")), If(dr("thick") Is DBNull.Value, "", dr("thick")), If(dr("systemPntPP") Is DBNull.Value, "", dr("systemPntPP")), If(dr("pntOption") Is DBNull.Value, "", dr("pntOption")), If(dr("idJacket") Is DBNull.Value, "", dr("idJacket")), If(dr("elevation") Is DBNull.Value, "", dr("elevation")), If(dr("idLaborRateRmv") Is DBNull.Value, "", dr("idLaborRateRmv")), dr("lFtRmv"), If(dr("idLaborRatePnt") Is DBNull.Value, "", dr("idLaborRatePnt")), dr("lFtPnt"), dr("p90Pnt"), dr("p45Pnt"), dr("pTeePnt"), dr("pPairPnt"), dr("pVlvPnt"), dr("pControlPnt"), dr("pWeldPnt"), If(dr("idLaborRateII") Is DBNull.Value, "", dr("idLaborRateII")), dr("lFtII"), dr("p90II"), dr("p45II"), dr("pBendII"), dr("pTeeII"), dr("pReducII"), dr("pCapsII"), dr("pPairII"), dr("pVlvII"), dr("pControlII"), dr("pWeldII"), dr("pCutOutII"), dr("psupportII"), dr("acm"), dr("st"), dr("idDrawingNum"))
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
    Public Function saveUpdatePpDrawingProject(ByVal tbl As Data.DataTable, ByVal idDrawing As String, ByVal descriptionDrawing As String, ByVal projectId As String, Optional lastIdDrawing As String = "") As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmdDrawing As New SqlCommand
            If lastIdDrawing = "" Then 'insert 
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=0
                    begin
	                    insert into drawing values('" + idDrawing + "','" + descriptionDrawing + "','" + projectId + "')
                    end"
            Else ' update
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=1
                    begin 
	                    update drawing set idDrawingNum='" + idDrawing + "',[description]='" + descriptionDrawing + "',projectId='" + projectId + "' where idDrawingNum = '" + lastIdDrawing + "'
                    end"
            End If
            cmdDrawing.Connection = conn
            cmdDrawing.Transaction = tran
            If cmdDrawing.ExecuteNonQuery > 0 Then
                Dim flag As Boolean = True
                For Each row As DataRow In tbl.Rows()
                    Dim cmbTags As New SqlCommand
                    If row.ItemArray(0) = "" Then
                        cmbTags.CommandText = "if (select count(*) from pipingEst where idPipingEst = " + row.ItemArray(1).ToString() + " )=0
begin 
	insert into pipingEst values (" + row.ItemArray(1).ToString() + ",'" + row.ItemArray(2).ToString() + "'," + row.ItemArray(3).ToString() + "," + If(row.ItemArray(4) = "NULL", "NULL", "'" + row.ItemArray(4).ToString() + "'") + "," + row.ItemArray(5).ToString() + "," + If(row.ItemArray(6) = "NULL", "NULL", "'" + row.ItemArray(6).ToString() + "'") + "," + If(row.ItemArray(7) = "NULL", "NULL", "'" + row.ItemArray(7).ToString() + "'") + "," + If(row.ItemArray(8) = "NULL", "NULL", "'" + row.ItemArray(8).ToString() + "'") + "," + row.ItemArray(9).ToString() + "," + If(row.ItemArray(10) = "NULL", "NULL", "'" + row.ItemArray(10).ToString().ToString.Replace("'", "''") + "'") + "," + row.ItemArray(11).ToString() + "," + If(row.ItemArray(12) = "NULL", "NULL", "'" + row.ItemArray(12).ToString().ToString.Replace("'", "''") + "'") + "," + row.ItemArray(13).ToString() + "," + row.ItemArray(14).ToString() + "," + row.ItemArray(15).ToString() + "," + row.ItemArray(16).ToString() + "," + row.ItemArray(17).ToString() + "," + row.ItemArray(18).ToString() + "," + row.ItemArray(19).ToString() + "," + row.ItemArray(20).ToString() + "," + If(row.ItemArray(21) = "NULL", "NULL", "'" + row.ItemArray(21).ToString().ToString.Replace("'", "''") + "'") + "," + row.ItemArray(22).ToString() + "," + row.ItemArray(23).ToString() + "," + row.ItemArray(24).ToString() + "," + row.ItemArray(25).ToString() + "," + row.ItemArray(26).ToString() + "," + row.ItemArray(27).ToString() + "," + row.ItemArray(28).ToString() + "," + row.ItemArray(29).ToString() + "," + row.ItemArray(30).ToString() + "," + row.ItemArray(31).ToString() + "," + row.ItemArray(32).ToString() + "," + row.ItemArray(33).ToString() + "," + row.ItemArray(34).ToString() + "," + row.ItemArray(35).ToString() + "," + row.ItemArray(36).ToString() + ",'" + idDrawing + "')
end"
                    Else
                        cmbTags.CommandText = "if (select count(*) from pipingEst where idPipingEst = " + row.ItemArray(0).ToString() + " )=1
begin 
	update pipingEst set idPipingEst = " + row.ItemArray(1).ToString() + ",line='" + row.ItemArray(2).ToString() + "',size=" + row.ItemArray(3).ToString() + ",[type]=" + If(row.ItemArray(4) = "", "NULL", "'" + row.ItemArray(4).ToString() + "'") + ",thick = " + If(row.ItemArray(5) = "", "0", row.ItemArray(5).ToString()) + " ,systemPntPP=" + If(row.ItemArray(6) = "", "NULL", "'" + row.ItemArray(6).ToString() + "'") + ",pntOption=" + If(row.ItemArray(7) = "", "NULL", "'" + row.ItemArray(7).ToString() + "'") + ",idJacket=" + If(row.ItemArray(8) = "", "NULL", "'" + row.ItemArray(8).ToString() + "'") + ",elevation=" + row.ItemArray(9).ToString() + ",idLaborRateRmv=" + If(row.ItemArray(10) = "", "NULL", "'" + row.ItemArray(10).ToString().ToString.Replace("'", "''") + "'") + ",lFtRmv=" + row.ItemArray(11).ToString() + ",idLaborRatePnt=" + If(row.ItemArray(12) = "", "NULL", "'" + row.ItemArray(12).ToString().ToString.Replace("'", "''") + "'") + ",lFtPnt=" + row.ItemArray(13).ToString() + ",p90Pnt=" + row.ItemArray(14).ToString() + ",p45Pnt=" + row.ItemArray(15).ToString() + ",pTeePnt=" + row.ItemArray(16).ToString() + ",pPairPnt=" + row.ItemArray(17).ToString() + ",pVlvPnt=" + row.ItemArray(18).ToString() + ",pControlPnt=" + row.ItemArray(19).ToString() + ",pWeldPnt=" + row.ItemArray(20).ToString() + ",idLaborRateII=" + If(row.ItemArray(21) = "", "NULL", "'" + row.ItemArray(21).ToString().ToString.Replace("'", "''") + "'") + ",lFtII=" + row.ItemArray(22).ToString() + ",p90II=" + row.ItemArray(23).ToString() + ",p45II=" + row.ItemArray(24).ToString() + ",pBendII=" + row.ItemArray(25).ToString() + ",pTeeII=" + row.ItemArray(26).ToString() + ",pReducII=" + row.ItemArray(27).ToString() + ",pCapsII=" + row.ItemArray(28).ToString() + ",pPairII=" + row.ItemArray(29).ToString() + ",pVlvII=" + row.ItemArray(30).ToString() + ",pControlII=" + row.ItemArray(31).ToString() + ",pWeldII=" + row.ItemArray(32).ToString() + ",pCutOutII=" + row.ItemArray(33).ToString() + ",psupportII=" + row.ItemArray(34).ToString() + ",acm=" + row.ItemArray(35).ToString() + ",st=" + row.ItemArray(35).ToString() + " where idPipingEst = " + row.ItemArray(0).ToString() + " and idDrawingNum = '" + If(lastIdDrawing <> "", lastIdDrawing, idDrawing) + "' 
end"
                    End If
                    cmbTags.Connection = conn
                    cmbTags.Transaction = tran
                    If cmbTags.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Next
                If flag Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                MessageBox.Show(If(lastIdDrawing = "", "Is not posible to Insert ", "Is not prosible Update") + "the Drawing Project Plese check that is not inserted.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deletePpDrawingProject(ByVal tbl As Data.DataTable) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As Data.DataRow In tbl.Rows()
                If row.ItemArray(0) IsNot Nothing Or row.ItemArray(0) = "" Then
                    Dim cmd As New SqlCommand("delete from pipingEst where idPipingEst = " + row.ItemArray(0).ToString() + "", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function updateCostEstSCF(ByVal projectId As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = False
            Dim tbl As Data.DataTable = selectSCFByProject(conn, tran, "", projectId) 'consultamos la tabla acutalizada 
            For Each row As Data.DataRow In tbl.Rows ' ahora ejecutaremos el calculo de los registros de scaffold con ayuda del sp en caso de haber cambiados los parametros de la ventanda de Factor
                Dim cmdSp_insertUpdateEstCostScf As New SqlCommand("exec sp_insertUpdateEstCostScf @tagEst ,@days ,@width ,@length ,@heigth ,@decks ,@build ,@idLabor ,@idSCFUR ,@idDrawingNum ")
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@tagEst", row.ItemArray(2))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@days", CInt(row.ItemArray(8)))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@width", CInt(row.ItemArray(9)))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@length", CInt(row.ItemArray(10)))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@heigth", CInt(row.ItemArray(11)))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@decks", CInt(row.ItemArray(12)))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@build", CInt(row.ItemArray(13)))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@idLabor", row.ItemArray(4))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@idSCFUR", row.ItemArray(5))
                cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@idDrawingNum", row.ItemArray(1))
                cmdSp_insertUpdateEstCostScf.Connection = conn
                cmdSp_insertUpdateEstCostScf.Transaction = tran
                If cmdSp_insertUpdateEstCostScf.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    flag = False
                    Exit For
                End If
            Next
            If flag = True Then
                tran.Commit()
            Else
                tran.Rollback()
            End If
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function updateCostEstSCF(ByVal clientNum As String, ByVal idDrawing As String, ByVal projectId As String, Optional lastIdDrawing As String = "", Optional descriptionDrawing As String = "") As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmdDrawing As New SqlCommand
            If lastIdDrawing = "" Then 'insert 
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=0
                    begin
	                    insert into drawing values('" + idDrawing + "','" + descriptionDrawing + "','" + projectId + "')
                    end"
            Else ' update
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=1
                    begin 
	                    update drawing set idDrawingNum='" + idDrawing + "',[description]='" + descriptionDrawing + "',projectId='" + projectId + "' where idDrawingNum = '" + lastIdDrawing + "'
                    end"
            End If
            cmdDrawing.Connection = conn
            cmdDrawing.Transaction = tran
            Dim flag As Boolean = True
            If cmdDrawing.ExecuteNonQuery Then 'actulizamos los valores de drawing y projectId 
                Dim tbl As Data.DataTable = selectSCFByProject(conn, tran, clientNum, projectId) 'consultamos la tabla acutalizada 
                For Each row As Data.DataRow In tbl.Rows ' ahora ejecutaremos el calculo de los registros de scaffold con ayuda del sp en caso de haber cambiados los parametros de la ventanda de Factor
                    Dim cmdSp_insertUpdateEstCostScf As New SqlCommand("exec sp_insertUpdateEstCostScf @tagEst ,@days ,@width ,@length ,@heigth ,@decks ,@build ,@idLabor ,@idSCFUR ,@idDrawingNum ")
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@tagEst", row.ItemArray(2))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@days", CInt(row.ItemArray(8)))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@width", CInt(row.ItemArray(9)))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@length", CInt(row.ItemArray(10)))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@heigth", CInt(row.ItemArray(11)))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@decks", CInt(row.ItemArray(12)))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@build", CInt(row.ItemArray(13)))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@idLabor", row.ItemArray(4))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@idSCFUR", row.ItemArray(5))
                    cmdSp_insertUpdateEstCostScf.Parameters.AddWithValue("@idDrawingNum", row.ItemArray(1))
                    cmdSp_insertUpdateEstCostScf.Connection = conn
                    cmdSp_insertUpdateEstCostScf.Transaction = tran
                    If cmdSp_insertUpdateEstCostScf.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Next
                If flag = True Then
                    tran.Commit()
                Else
                    tran.Rollback()
                End If
            End If
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function updateCostEstEquipment(ByVal cleintNum As String, ByVal projectId As String, ByVal idDrawing As String, Optional lastIdDrawing As String = "", Optional descriptionDrawing As String = "") As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmdDrawing As New SqlCommand
            If lastIdDrawing = "" Then 'insert 
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=0
                    begin
	                    insert into drawing values('" + idDrawing + "','" + descriptionDrawing + "','" + projectId + "')
                    end"
            Else ' update
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=1
                    begin 
	                    update drawing set idDrawingNum='" + idDrawing + "',[description]='" + descriptionDrawing + "',projectId='" + projectId + "' where idDrawingNum = '" + lastIdDrawing + "'
                    end"
            End If
            cmdDrawing.Connection = conn
            cmdDrawing.Transaction = tran
            Dim flag As Boolean = True
            If cmdDrawing.ExecuteNonQuery Then 'actulizamos los valores de drawing y projectId 
                Dim tbl As Data.DataTable = selectEqByProject(conn, tran, cleintNum, projectId)
                For Each row As Data.DataRow In tbl.Rows ' ahora ejecutaremos el calculo de los registros de scaffold con ayuda del sp en caso de haber cambiados los parametros de la ventanda de Factor
                    Dim cmdSp_insertUpdateEstCostEq As New SqlCommand("exec sp_insertUpdateEstCostEq @idEquipmentEst , @elevation , @systemPntEq , @pntOption , @type , @thick , @idJacket , @remIns , @idLaborRmv , @sqrFtRmv , @idLaborPnt , @sqrFtPnt , @idLaborII , @sqrFtII, @bevel , @cutout, @acm ,@idDrawingNum ")
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idEquipmentEst", row.ItemArray(0))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@elevation", row.ItemArray(2))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@systemPntEq", row.ItemArray(3))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@pntOption", row.ItemArray(4))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@type ", row.ItemArray(5))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@thick", row.ItemArray(6))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idJacket", row.ItemArray(7))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@remIns", If(row.ItemArray(8) = True, 1, 0))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idLaborRmv", row.ItemArray(9))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@sqrFtRmv", row.ItemArray(10))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idLaborPnt", row.ItemArray(11))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@sqrFtPnt", row.ItemArray(12))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idLaborII", row.ItemArray(13))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@sqrFtII", row.ItemArray(14))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@bevel", row.ItemArray(15))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@cutout", row.ItemArray(16))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@acm", If(row.ItemArray(17) = True, 1, 0))
                    cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idDrawingNum", row.ItemArray(18))

                    cmdSp_insertUpdateEstCostEq.Connection = conn
                    cmdSp_insertUpdateEstCostEq.Transaction = tran
                    If cmdSp_insertUpdateEstCostEq.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Next
                If flag = True Then
                    tran.Commit()
                Else
                    tran.Rollback()
                End If
            End If
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
        Return True
    End Function
    Public Function updateCostEstEquipment(ByVal projectId As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            Dim tbl As Data.DataTable = selectEqByProject(conn, tran, "", projectId)
            For Each row As Data.DataRow In tbl.Rows ' ahora ejecutaremos el calculo de los registros de scaffold con ayuda del sp en caso de haber cambiados los parametros de la ventanda de Factor
                Dim cmdSp_insertUpdateEstCostEq As New SqlCommand("exec sp_insertUpdateEstCostEq @idEquipmentEst , @elevation , @systemPntEq , @pntOption , @type , @thick , @idJacket , @remIns , @idLaborRmv , @sqrFtRmv , @idLaborPnt , @sqrFtPnt , @idLaborII , @sqrFtII, @bevel , @cutout, @acm ,@idDrawingNum ")
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idEquipmentEst", row.ItemArray(0))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@elevation", row.ItemArray(2))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@systemPntEq", row.ItemArray(3))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@pntOption", row.ItemArray(4))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@type ", row.ItemArray(5))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@thick", row.ItemArray(6))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idJacket", row.ItemArray(7))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@remIns", If(row.ItemArray(8) = True, 1, 0))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idLaborRmv", row.ItemArray(9))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@sqrFtRmv", row.ItemArray(10))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idLaborPnt", row.ItemArray(11))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@sqrFtPnt", row.ItemArray(12))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idLaborII", row.ItemArray(13))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@sqrFtII", row.ItemArray(14))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@bevel", row.ItemArray(15))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@cutout", row.ItemArray(16))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@acm", If(row.ItemArray(17) = True, 1, 0))
                cmdSp_insertUpdateEstCostEq.Parameters.AddWithValue("@idDrawingNum", row.ItemArray(18))

                cmdSp_insertUpdateEstCostEq.Connection = conn
                cmdSp_insertUpdateEstCostEq.Transaction = tran
                If cmdSp_insertUpdateEstCostEq.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    flag = False
                    Exit For
                End If
            Next
            If flag = True Then
                tran.Commit()
            Else
                tran.Rollback()

            End If
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
        Return True
    End Function
    Public Function updateCostEstPiping(ByVal clientNum As String, ByVal projectId As String, ByVal idDrawing As String, Optional lastIdDrawing As String = "", Optional descriptionDrawing As String = "") As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim cmdDrawing As New SqlCommand
            If lastIdDrawing = "" Then 'insert 
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=0
                    begin
	                    insert into drawing values('" + idDrawing + "','" + descriptionDrawing + "','" + projectId + "')
                    end"
            Else ' update
                cmdDrawing.CommandText = "if (select COUNT (*) from drawing where idDrawingNum = '" + idDrawing + "')=1
                    begin 
	                    update drawing set idDrawingNum='" + idDrawing + "',[description]='" + descriptionDrawing + "',projectId='" + projectId + "' where idDrawingNum = '" + lastIdDrawing + "'
                    end"
            End If
            cmdDrawing.Connection = conn
            cmdDrawing.Transaction = tran
            Dim flag As Boolean = True
            If cmdDrawing.ExecuteNonQuery Then 'actulizamos los valores de drawing y projectId 
                Dim tbl As Data.DataTable = selectPpByProject(conn, tran, clientNum, projectId)
                For Each row As Data.DataRow In tbl.Rows ' ahora ejecutaremos el calculo de los registros de scaffold con ayuda del sp en caso de haber cambiados los parametros de la ventanda de Factor
                    Dim cmdSp_insertUpdateEstCostPp As New SqlCommand("exec sp_InsertUpdateEstCostPp @idPipingEst , @size , @type , @thick , @systemPntPP , @pntOption , @idJacket , @elevation , @idLaborRateRmv , @lFtRmv , @idLaborRatePnt , @lFtPnt , @p90Pnt , @p45Pnt , @pTeePnt ,	@pPairPnt , @pVlvPnt , @pControlPnt , @pWeldPnt , @idLaborRateII , @lFtII , @p90II , @p45II , @pBendII , @pTeeII , @pReducII ,	@pCapsII , @pPairII , @pVlvII	, @pControlII , @pWeldII , @pCutOutII , @psupportII , @acm , @idDrawingNum ")
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idPipingEst", row.ItemArray(0))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@size", row.ItemArray(2))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@type", row.ItemArray(3))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@thick", row.ItemArray(4))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@systemPntPP", row.ItemArray(5))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pntOption", row.ItemArray(6))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idJacket", row.ItemArray(7))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@elevation", row.ItemArray(8))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idLaborRateRmv", row.ItemArray(9))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@lFtRmv", row.ItemArray(10))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idLaborRatePnt", row.ItemArray(11))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@lFtPnt", row.ItemArray(12))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p90Pnt", row.ItemArray(13))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p45Pnt", row.ItemArray(14))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pTeePnt", row.ItemArray(15))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pPairPnt", row.ItemArray(16))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pVlvPnt", row.ItemArray(17))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pControlPnt", row.ItemArray(18))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pWeldPnt", row.ItemArray(19))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idLaborRateII", row.ItemArray(20))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@lFtII", row.ItemArray(21))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p90II", row.ItemArray(22))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p45II", row.ItemArray(23))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pBendII", row.ItemArray(24))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pTeeII", row.ItemArray(25))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pReducII", row.ItemArray(26))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pCapsII", row.ItemArray(27))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pPairII", row.ItemArray(28))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pVlvII", row.ItemArray(29))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pControlII", row.ItemArray(30))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pWeldII", row.ItemArray(31))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pCutOutII", row.ItemArray(32))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@psupportII", row.ItemArray(33))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@acm", row.ItemArray(34))
                    cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idDrawingNum", row.ItemArray(36))

                    cmdSp_insertUpdateEstCostPp.Connection = conn
                    cmdSp_insertUpdateEstCostPp.Transaction = tran
                    If cmdSp_insertUpdateEstCostPp.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Next
                If flag = True Then
                    tran.Commit()
                    flag = True
                Else
                    tran.Rollback()
                    flag = False
                End If
            End If
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
        Return True
    End Function
    Public Function updateCostEstPiping(ByVal projectId As String) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            Dim tbl As Data.DataTable = selectPpByProject(conn, tran, "", projectId)
            For Each row As Data.DataRow In tbl.Rows ' ahora ejecutaremos el calculo de los registros de scaffold con ayuda del sp en caso de haber cambiados los parametros de la ventanda de Factor
                Dim cmdSp_insertUpdateEstCostPp As New SqlCommand("exec sp_InsertUpdateEstCostPp @idPipingEst , @size , @type , @thick , @systemPntPP , @pntOption , @idJacket , @elevation , @idLaborRateRmv , @lFtRmv , @idLaborRatePnt , @lFtPnt , @p90Pnt , @p45Pnt , @pTeePnt ,	@pPairPnt , @pVlvPnt , @pControlPnt , @pWeldPnt , @idLaborRateII , @lFtII , @p90II , @p45II , @pBendII , @pTeeII , @pReducII ,	@pCapsII , @pPairII , @pVlvII	, @pControlII , @pWeldII , @pCutOutII , @psupportII , @acm , @idDrawingNum ")
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idPipingEst", row.ItemArray(0))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@size", row.ItemArray(2))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@type", row.ItemArray(3))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@thick", row.ItemArray(4))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@systemPntPP", row.ItemArray(5))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pntOption", row.ItemArray(6))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idJacket", row.ItemArray(7))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@elevation", row.ItemArray(8))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idLaborRateRmv", row.ItemArray(9))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@lFtRmv", row.ItemArray(10))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idLaborRatePnt", row.ItemArray(11))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@lFtPnt", row.ItemArray(12))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p90Pnt", row.ItemArray(13))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p45Pnt", row.ItemArray(14))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pTeePnt", row.ItemArray(15))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pPairPnt", row.ItemArray(16))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pVlvPnt", row.ItemArray(17))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pControlPnt", row.ItemArray(18))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pWeldPnt", row.ItemArray(19))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idLaborRateII", row.ItemArray(20))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@lFtII", row.ItemArray(21))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p90II", row.ItemArray(22))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@p45II", row.ItemArray(23))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pBendII", row.ItemArray(24))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pTeeII", row.ItemArray(25))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pReducII", row.ItemArray(26))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pCapsII", row.ItemArray(27))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pPairII", row.ItemArray(28))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pVlvII", row.ItemArray(29))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pControlII", row.ItemArray(30))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pWeldII", row.ItemArray(31))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@pCutOutII", row.ItemArray(32))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@psupportII", row.ItemArray(33))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@acm", row.ItemArray(34))
                cmdSp_insertUpdateEstCostPp.Parameters.AddWithValue("@idDrawingNum", row.ItemArray(36))

                cmdSp_insertUpdateEstCostPp.Connection = conn
                cmdSp_insertUpdateEstCostPp.Transaction = tran
                If cmdSp_insertUpdateEstCostPp.ExecuteNonQuery > 0 Then
                    flag = True
                Else
                    flag = False
                    Exit For
                End If
            Next
            If flag = True Then
                tran.Commit()
                flag = True
            Else
                tran.Rollback()
                flag = False
            End If
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
        Return True
    End Function
End Class
