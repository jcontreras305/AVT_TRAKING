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
	                        insert into scaffoldEst values ('" + row.Cells("Tag").Value.ToString() + "','" + row.Cells("Location").Value.ToString() + "'," + row.Cells("DaysUp").Value.ToString() + "," + row.Cells("Width").Value.ToString() + "," + row.Cells("Length").Value.ToString() + "," + row.Cells("Heigth").Value.ToString() + "," + row.Cells("Decks").Value.ToString() + "," + row.Cells("Build").Value.ToString() + ",'" + row.Cells("LaborRate").Value.ToString() + "','" + row.Cells("TypeSC").Value.ToString() + "','" + row.Cells("Enviroment").Value.ToString() + "','" + idDrawing + "')
                        end"
                    Else
                        cmbTags.CommandText = "if (select count(*) from scaffoldEst as scf 
                        inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
                        where scf.tag = '" + row.Cells("TagId").Value.ToString + "' and dr.projectId = '" + projectId + "')=1
                        begin 
	                        update scaffoldEst set tag='" + row.Cells("Tag").Value.ToString + "',location='" + row.Cells("Location").Value.ToString + "',[days]=" + row.Cells("DaysUp").Value.ToString + " , width=" + row.Cells("Width").Value.ToString + ",[length]= " + row.Cells("Length").Value.ToString + ",heigth= " + row.Cells("Heigth").Value.ToString + ",decks= " + row.Cells("Decks").Value.ToString + ",build= " + row.Cells("Build").Value.ToString + ",idLaborRate ='" + row.Cells("LaborRate").Value.ToString + "',idSCFUR= '" + row.Cells("TypeSC").Value.ToString + "',idEnviroment= '" + row.Cells("Enviroment").Value.ToString + "',idDrawingNum= '" + idDrawing + "' where tag = '" + row.Cells("TagId").Value.ToString + "'	 
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
        Finally
            desconectar()
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
                            insert into equipmentEst values(" + row.ItemArray(1) + ",'" + row.ItemArray(2) + "'," + row.ItemArray(3) + "," + If(row.ItemArray(4) = "NULL", "NULL", "'" + row.ItemArray(4) + "'") + "," + If(row.ItemArray(5) = "NULL", "NULL", "'" + row.ItemArray(5) + "'") + "," + If(row.ItemArray(6) = "NULL", "NULL", "'" + row.ItemArray(6) + "'") + "," + row.ItemArray(7) + "," + If(row.ItemArray(8) = "NULL", "NULL", "'" + row.ItemArray(8) + "'") + "," + If(row.ItemArray(9) = "Yes", "1", "0") + "," + If(row.ItemArray(10) = "NULL", "NULL", "'" + row.ItemArray(10) + "'") + "," + row.ItemArray(11) + "," + If(row.ItemArray(12) = "NULL", "NULL", "'" + row.ItemArray(12) + "'") + "," + row.ItemArray(13) + "," + If(row.ItemArray(14) = "NULL", "NULL", "'" + row.ItemArray(14) + "'") + "," + row.ItemArray(15) + "," + row.ItemArray(16) + "," + row.ItemArray(17) + "," + If(row.ItemArray(18) = "Yes", "1", "0") + ",'" + idDrawing + "')
                        end"
                    Else
                        cmbTags.CommandText = "if(select count(*) from equipmentEst where idEquimentEst=" + row.ItemArray(0) + ")=1
                        begin  
	                        update equipmentEst set idEquimentEst=" + row.ItemArray(1) + ",[description]='" + row.ItemArray(2) + "',elevation=" + row.ItemArray(3) + ",systemPntEq=" + If(row.ItemArray(4) = "NULL", "NULL", "'" + row.ItemArray(4) + "'") + ",pntOption=" + If(row.ItemArray(5) = "NULL", "NULL", "'" + row.ItemArray(5) + "'") + ",[type]=" + If(row.ItemArray(6) = "NULL", "NULL", "'" + row.ItemArray(6) + "'") + ",thick=" + row.ItemArray(7) + ",idJacket=" + If(row.ItemArray(8) = "NULL", "NULL", "'" + row.ItemArray(8) + "'") + ",remIns=" + If(row.ItemArray(9) = "Yes", "1", "0") + ",idLaborRateRmv=" + If(row.ItemArray(10) = "NULL", "NULL", "'" + row.ItemArray(10) + "'") + ",sqrFtRmv=" + row.ItemArray(11) + ",idLaborRatePnt=" + If(row.ItemArray(12) = "NULL", "NULL", "'" + row.ItemArray(12) + "'") + ",sqrFtPnt=" + row.ItemArray(13) + ",idLaborRateII=" + If(row.ItemArray(14) = "NULL", "NULL", "'" + row.ItemArray(14) + "'") + ",sqrFtII=" + row.ItemArray(15) + ",bevel=" + row.ItemArray(16) + ",cutout=" + row.ItemArray(17) + ",acm=" + If(row.ItemArray(18) = "Yes", "1", "0") + ",idDrawingNum='" + idDrawing + "' where idEquimentEst = " + row.ItemArray(0) + "
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
End Class
