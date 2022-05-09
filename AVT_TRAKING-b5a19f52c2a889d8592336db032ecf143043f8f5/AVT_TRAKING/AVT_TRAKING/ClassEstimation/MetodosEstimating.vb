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
                If row.Cells("IdUnitRate").Value IsNot Nothing Or row.Cells("IdUnitRate").Value = "" Then
                    Dim cmd As New SqlCommand("delete from scfUnitsRates where idSCFUR = '" + row.Cells("IdUnitRate").Value.ToString() + "'", conn)
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
