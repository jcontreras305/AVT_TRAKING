Imports System.Data.SqlClient
Public Class MetodosFactor
    Inherits ConnectioDB

    '=====================================================================================================================================================================
    '=========== MOTODOS LABOR RATE ======================================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectLaborRat(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idLaborRate,idLaborRate as 'description',insRate,abatRate,paintRate,scafRate from laborRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idLaborRate"), dr("description"), dr("insRate"), dr("abatRate"), dr("paintRate"), dr("scafRate"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateLaborRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If row.Cells("IdLaborRate").Value Is Nothing Or row.Cells("IdLaborRate").Value = "" Then
                    cmd.CommandText = "if (select COUNT(*) from laborRate where idLaborRate = '" + row.Cells("Description").Value + "')=0
                        begin 
	                        insert into laborRate values('" + row.Cells("Description").Value.ToString() + "'," + row.Cells("InsulRate").Value.ToString() + "," + row.Cells("AbatRate").Value.ToString() + "," + row.Cells("PaintRate").Value.ToString() + "," + row.Cells("ScafRate").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if (select COUNT(*) from laborRate where idLaborRate = '" + row.Cells("IdLaborRate").Value + "')=1
                        begin
                            update laborRate set idLaborRate = '" + row.Cells("Description").Value.ToString() + "' , insRate = " + row.Cells("InsulRate").Value.ToString() + ",abatRate=" + row.Cells("AbatRate").Value.ToString() + ",paintRate=" + row.Cells("PaintRate").Value.ToString() + ",scafRate=" + row.Cells("ScafRate").Value.ToString() + " where idLaborRate = '" + row.Cells("IdLaborRate").Value.ToString() + "'
                        end"
                End If
                cmd.Connection = conn
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
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
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteLaborRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("IdLaborRate").Value IsNot Nothing Then
                    Dim cmd As New SqlCommand("delete from laborRate where idLaborRate = '" + row.Cells("IdLaborRate").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellLaporRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idLaborRate , insRate,abatRate,paintRate, scafRate from laborRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idLaborRate")
            dt.Columns.Add("insRate")
            dt.Columns.Add("abatRate")
            dt.Columns.Add("paintRate")
            dt.Columns.Add("scafRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idLaborRate"))
                dt.Rows.Add(dr("idLaborRate"), dr("insRate"), dr("abatRate"), dr("paintRate"), dr("scafRate"))
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
    '=====================================================================================================================================================================
    '=========== MOTODOS UNITS RATES =====================================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectScafUnitsRates(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idSCFUR , idSCFUR as 'description',buildPercent,laborB,materialB,equipmentB,dismantlePercent,laborD,materialD,equipmentD from scfUnitsRates", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idSCFUR"), dr("description"), dr("buildPercent"), dr("laborB"), dr("materialB"), dr("equipmentB"), dr("dismantlePercent"), dr("laborD"), dr("materialD"), dr("equipmentD"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateSCFUnitsRates(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If row.Cells("IdUnitRate").Value Is Nothing Or row.Cells("IdUnitRate").Value = "" Then
                    cmd.CommandText = "if(select count(*) from scfUnitsRates where idSCFUR = '" + row.Cells("DescriptionURSCF").Value.ToString() + "')=0
                        begin 
	                        insert into scfUnitsRates values('" + row.Cells("DescriptionURSCF").Value.ToString() + "'," + row.Cells("BuildPercent").Value.ToString() + "," + row.Cells("LaborProdBuild").Value.ToString() + "," + row.Cells("MaterialBuild").Value.ToString() + "," + row.Cells("EquipmentBuild").Value.ToString() + "," + row.Cells("DimantlePercent").Value.ToString() + "," + row.Cells("LaborProdDis").Value.ToString() + "," + row.Cells("MaterialDis").Value.ToString() + "," + row.Cells("EquipmentDis").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if (select count(*) from scfUnitsRates where idSCFUR = '" + row.Cells("IdUnitRate").Value.ToString() + "')=1
                        begin
	                        update scfUnitsRates set idSCFUR = '" + row.Cells("DescriptionURSCF").Value.ToString() + "' ,buildPercent=" + row.Cells("BuildPercent").Value.ToString() + ",laborB=" + row.Cells("LaborProdBuild").Value.ToString() + ",materialB=" + row.Cells("MaterialBuild").Value.ToString() + ",equipmentB=" + row.Cells("EquipmentBuild").Value.ToString() + ",dismantlePercent=" + row.Cells("DimantlePercent").Value.ToString() + ",laborD=" + row.Cells("LaborProdDis").Value.ToString() + ",materialD=" + row.Cells("MaterialDis").Value.ToString() + ",equipmentD=" + row.Cells("EquipmentDis").Value.ToString() + " where idSCFUR='" + row.Cells("IdUnitRate").Value.ToString() + "'
                        end"
                End If
                cmd.Connection = conn
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
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
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteSCFUnitsRates(ByVal tbl As DataGridView) As Boolean
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
    Public Function llenarComboCellUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idSCFUR,buildPercent,laborB,materialB,equipmentB,dismantlePercent,laborD,materialD,equipmentD from scfUnitsRates", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idSCFUR")
            dt.Columns.Add("buildPercent")
            dt.Columns.Add("laborB")
            dt.Columns.Add("materialB")
            dt.Columns.Add("equipmentB")
            dt.Columns.Add("dimantlePercent")
            dt.Columns.Add("laborD")
            dt.Columns.Add("materialD")
            dt.Columns.Add("equipmentD")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idSCFUR"))
                dt.Rows.Add(dr("idSCFUR").ToString(), dr("buildPercent").ToString(), dr("laborB").ToString(), dr("materialB").ToString(), dr("equipmentB").ToString(), dr("dismantlePercent").ToString(), dr("laborD").ToString(), dr("materialD").ToString(), dr("equipmentD").ToString())
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
    '=====================================================================================================================================================================
    '=========== MOTODOS ENVIROMENTS =====================================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectEnviroment(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEnviroment , idEnviroment as 'enviroment',dueDays from enviroment ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idEnviroment"), dr("enviroment"), dr("dueDays"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateEnviroment(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If row.Cells("idEnviroment").Value Is Nothing Or row.Cells("idEnviroment").Value = "" Then
                    cmd.CommandText = "if(select count(*) from enviroment where idEnviroment = '" + row.Cells("Enviroment").Value.ToString() + "')=0
                        begin
	                        insert into enviroment values('" + row.Cells("Enviroment").Value.ToString() + "'," + row.Cells("RevitionDueDay").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if (select count(*) from enviroment where dueDays = '" + row.Cells("idEnviroment").Value.ToString() + "')=1
                        begin
	                        update enviroment set idEnviroment = '" + row.Cells("Enviroment").Value.ToString() + "' ,dueDays=" + row.Cells("RevitionDueDay").Value.ToString() + " where idEnviroment='" + row.Cells("idEnviroment").Value.ToString() + "'
                        end"
                End If
                cmd.Connection = conn
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery > 0 Then
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
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteEnviroment(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("idEnviroment").Value IsNot Nothing Or row.Cells("idEnviroment").Value = "" Then
                    Dim cmd As New SqlCommand("delete from enviroment where idEnviroment = '" + row.Cells("idEnviroment").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellEnviroment(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEnviroment,dueDays from enviroment", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idEnviroment")
            dt.Columns.Add("dueDays")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idEnviroment"))
                dt.Rows.Add(dr("idEnviroment"), dr("dueDays"))
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
    '=====================================================================================================================================================================
    '===========  ========================================================================================================================================================
    '=====================================================================================================================================================================

End Class
