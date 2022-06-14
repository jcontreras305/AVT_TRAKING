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
                    cmd.CommandText = "if (select COUNT(*) from laborRate where idLaborRate = '" + row.Cells("Description").Value.ToString.Replace("'", "''") + "')=0
                        begin 
	                        insert into laborRate values('" + row.Cells("Description").Value.ToString().ToString.Replace("'", "''") + "'," + row.Cells("InsulRate").Value.ToString() + "," + row.Cells("AbatRate").Value.ToString() + "," + row.Cells("PaintRate").Value.ToString() + "," + row.Cells("ScafRate").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if (select COUNT(*) from laborRate where idLaborRate = '" + row.Cells("IdLaborRate").Value.ToString.Replace("'", "''") + "')=1
                        begin
                            update laborRate set idLaborRate = '" + row.Cells("Description").Value.ToString().Replace("'", "''") + "' , insRate = " + row.Cells("InsulRate").Value.ToString() + ",abatRate=" + row.Cells("AbatRate").Value.ToString() + ",paintRate=" + row.Cells("PaintRate").Value.ToString() + ",scafRate=" + row.Cells("ScafRate").Value.ToString() + " where idLaborRate = '" + row.Cells("IdLaborRate").Value.ToString().ToString.Replace("'", "''") + "'
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
    Public Function llenarComboLaporRate(ByVal cmb As ComboBox) As Data.DataTable
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
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idLaborRate"))
                dt.Rows.Add(dr("idLaborRate"), dr("insRate"), dr("abatRate"), dr("paintRate"), dr("scafRate"))
            End While
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
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
    '=========== METODOS INSFITTING ======================================================================================================================================
    '=====================================================================================================================================================================

    Public Function selectInsFitting(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type] as 'idType', [type],support,p90,p45,bend,tee,red,cap,flangePair,flangeVlv,controlVlv,weldedVlv,bebel,cutOut from insFitting", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idType"), dr("type"), dr("support"), dr("p90"), dr("p45"), dr("bend"), dr("tee"), dr("red"), dr("cap"), dr("flangePair"), dr("flangeVlv"), dr("controlVlv"), dr("weldedVlv"), dr("bebel"), dr("cutOut"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateInsFitting(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If row.Cells("typeId").Value Is Nothing Or row.Cells("typeId").Value = "" Then
                    cmd.CommandText = "if (select count (*) from insFitting where [type]='" + row.Cells("Type").Value.ToString() + "')=0
                    begin
	                    insert into insFitting values('" + row.Cells("Type").Value.ToString() + "'," + row.Cells("Support").Value.ToString() + "," + row.Cells("p90").Value.ToString() + "," + row.Cells("p45").Value.ToString() + "," + row.Cells("Bend").Value.ToString() + "," + row.Cells("TEE").Value.ToString() + "," + row.Cells("RED").Value.ToString() + "," + row.Cells("CAP").Value.ToString() + "," + row.Cells("FlangePair").Value.ToString() + "," + row.Cells("FlangeVlv").Value.ToString() + "," + row.Cells("ControlVlv").Value.ToString() + "," + row.Cells("WeldVlv").Value.ToString() + "," + row.Cells("Bebel").Value.ToString() + "," + row.Cells("CutOut").Value.ToString() + ")
                    end"
                Else
                    cmd.CommandText = "if(select count(*) from insFitting where [type]='" + row.Cells("typeId").Value.ToString() + "')=1
                    begin 
	                    update insFitting set [type]='" + row.Cells("Type").Value.ToString() + "' ,support=" + row.Cells("Support").Value.ToString() + ",p90=" + row.Cells("p90").Value.ToString() + ",p45=" + row.Cells("p45").Value.ToString() + ",bend=" + row.Cells("Bend").Value.ToString() + ",tee=" + row.Cells("TEE").Value.ToString() + ",red=" + row.Cells("RED").Value.ToString() + ",cap=" + row.Cells("CAP").Value.ToString() + ",flangePair=" + row.Cells("FlangePair").Value.ToString() + ",flangeVlv=" + row.Cells("FlangeVlv").Value.ToString() + ",controlVlv=" + row.Cells("ControlVlv").Value.ToString() + ",weldedVlv=" + row.Cells("WeldVlv").Value.ToString() + ",bebel=" + row.Cells("Bebel").Value.ToString() + ",cutOut=" + row.Cells("CutOut").Value.ToString() + " where [type]='" + row.Cells("typeId").Value.ToString() + "'
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
    Public Function deleteInsFitting(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("typeId").Value IsNot Nothing Or row.Cells("typeId").Value = "" Then
                    Dim cmd As New SqlCommand("delete insFitting where [type]='" + row.Cells("typeId").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellInsFitting(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type] as 'idType', [type],support,p90,p45,bend,tee,red,cap,flangePair,flangeVlv,controlVlv,weldedVlv,bebel,cutOut from insFitting", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("type")
            dt.Columns.Add("support")
            dt.Columns.Add("p90")
            dt.Columns.Add("p45")
            dt.Columns.Add("bend")
            dt.Columns.Add("tee")
            dt.Columns.Add("red")
            dt.Columns.Add("cap")
            dt.Columns.Add("flangePair")
            dt.Columns.Add("flangeVlv")
            dt.Columns.Add("controlVlv")
            dt.Columns.Add("weldedVlv")
            dt.Columns.Add("bebel")
            dt.Columns.Add("cutOut")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("type"))
                dt.Rows.Add(dr("type"), dr("support"), dr("p90"), dr("p45"), dr("bend"), dr("tee"), dr("red"), dr("cap"), dr("flangePair"), dr("flangeVlv"), dr("controlVlv"), dr("weldedVlv"), dr("bebel"), dr("cutOut"))
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
    Public Function llenarComboInsFitting(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type] as 'idType', [type],support,p90,p45,bend,tee,red,cap,flangePair,flangeVlv,controlVlv,weldedVlv,bebel,cutOut from insFitting", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("type")
            dt.Columns.Add("support")
            dt.Columns.Add("p90")
            dt.Columns.Add("p45")
            dt.Columns.Add("bend")
            dt.Columns.Add("tee")
            dt.Columns.Add("red")
            dt.Columns.Add("cap")
            dt.Columns.Add("flangePair")
            dt.Columns.Add("flangeVlv")
            dt.Columns.Add("controlVlv")
            dt.Columns.Add("weldedVlv")
            dt.Columns.Add("bebel")
            dt.Columns.Add("cutOut")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(dr("type")) > -1 Then
                    cmb.Items.Add(dr("type"))
                End If
                dt.Rows.Add(dr("type"), dr("support"), dr("p90"), dr("p45"), dr("bend"), dr("tee"), dr("red"), dr("cap"), dr("flangePair"), dr("flangeVlv"), dr("controlVlv"), dr("weldedVlv"), dr("bebel"), dr("cutOut"))
            End While
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
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

    '=====================================================================================================================================================================
    '=========== METODOS PNTFITTING ======================================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectPntFitting(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select pntOption as 'idPntOption', pntOption,p90,p45,tee,flangePair,flangeVlv,controlVlv,weldedVlv from pntFitting", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idPntOption"), dr("pntOption"), dr("p90"), dr("p45"), dr("tee"), dr("flangePair"), dr("flangeVlv"), dr("controlVlv"), dr("weldedVlv"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdatePntFitting(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If row.Cells("idOption").Value Is Nothing Or row.Cells("idOption").Value = "" Then
                    cmd.CommandText = "if (select count (*) from pntFitting where pntOption='" + row.Cells("PaintOption").Value.ToString() + "')=0
                        begin
	                        insert into pntFitting values('" + row.Cells("PaintOption").Value.ToString() + "'," + row.Cells("p90p").Value.ToString() + "," + row.Cells("p45p").Value.ToString() + "," + row.Cells("TEEp").Value.ToString() + "," + row.Cells("FlangePairp").Value.ToString() + "," + row.Cells("FlangeVlvp").Value.ToString() + "," + row.Cells("ControlVlvp").Value.ToString() + "," + row.Cells("WeldedVlvp").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if(select count(*) from pntFitting where pntOption='" + row.Cells("idOption").Value.ToString() + "')=1
                        begin 
	                        update pntFitting set pntOption='" + row.Cells("PaintOption").Value.ToString() + "' ,p90=" + row.Cells("p90p").Value.ToString() + ",p45=" + row.Cells("p45p").Value.ToString() + ",tee=" + row.Cells("TEEp").Value.ToString() + ",flangePair=" + row.Cells("FlangePairp").Value.ToString() + ",flangeVlv=" + row.Cells("FlangeVlvp").Value.ToString() + ",controlVlv=" + row.Cells("ControlVlvp").Value.ToString() + ",weldedVlv=" + row.Cells("WeldedVlvp").Value.ToString() + " where pntOption='" + row.Cells("idOption").Value.ToString() + "'
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
    Public Function deletePntFitting(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("idOption").Value IsNot Nothing Or row.Cells("idOption").Value = "" Then
                    Dim cmd As New SqlCommand("delete pntFitting where pntOption='" + row.Cells("idOption").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellPntFitting(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select pntOption,p90,p45,tee,flangePair,flangeVlv,controlVlv,weldedVlv from pntFitting", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("pntOption")
            dt.Columns.Add("p90")
            dt.Columns.Add("p45")
            dt.Columns.Add("tee")
            dt.Columns.Add("flangePair")
            dt.Columns.Add("flangeVlv")
            dt.Columns.Add("controlVlv")
            dt.Columns.Add("weldedVlv")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("pntOption"))
                dt.Rows.Add(dr("pntOption"), dr("p90"), dr("p45"), dr("tee"), dr("flangePair"), dr("flangeVlv"), dr("controlVlv"), dr("weldedVlv"))
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
    '=========== METODOS EQUIPMENTPAINTUNITRATE ==========================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectEqPntUnitRate(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select systemPntEq,pntOption,laborProd,matRate,eqRate from eqPaintUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("systemPntEq"), dr("pntOption"), dr("systemPntEq"), dr("pntOption"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateEqPntUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells("SystemEqId").Value Is Nothing Or row.Cells("SystemEqId").Value = "") And (row.Cells("OptionEQId").Value Is Nothing Or row.Cells("OptionEQId").Value = "") Then
                    cmd.CommandText = "if(select COUNT(*) from eqPaintUnitRate where systemPntEq='" + row.Cells("SystemEq").Value.ToString() + "' and pntOption = '" + row.Cells("OptionEq").Value.ToString() + "')=0
begin
	insert into eqPaintUnitRate values('" + row.Cells("SystemEq").Value.ToString() + "','" + row.Cells("OptionEq").Value.ToString() + "'," + row.Cells("laborProdEq").Value.ToString() + "," + row.Cells("materialRateEq").Value.ToString() + "," + row.Cells("eqRateEq").Value.ToString() + ")
end"
                Else
                    cmd.CommandText = "if(select COUNT(*) from eqPaintUnitRate where systemPntEq='" + row.Cells("SystemEqId").Value.ToString() + "' and pntOption = '" + row.Cells("OptionEQId").Value.ToString() + "')=1
begin 
	update eqPaintUnitRate set systemPntEq='" + row.Cells("SystemEq").Value.ToString() + "',pntOption='" + row.Cells("OptionEq").Value.ToString() + "',laborProd=" + row.Cells("laborProdEq").Value.ToString() + ",matRate=" + row.Cells("materialRateEq").Value.ToString() + ",eqRate=" + row.Cells("eqRateEq").Value.ToString() + " where systemPntEq = '" + row.Cells("SystemEqId").Value.ToString() + "' and pntOption='" + row.Cells("OptionEQId").Value.ToString() + "'
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
    Public Function deleteEqPntUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (row.Cells("SystemEqId").Value IsNot Nothing Or row.Cells("SystemEqId").Value = "") And (row.Cells("OptionEQId").Value IsNot Nothing Or row.Cells("OptionEQId").Value = "") Then
                    Dim cmd As New SqlCommand("delete from eqPaintUnitRate where systemPntEq = '" + row.Cells("SystemEqId").Value.ToString() + "' and pntOption = '" + row.Cells("OptionEQId").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellEqPntUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select systemPntEq,pntOption,laborProd,matRate,eqRate from eqPaintUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("systemPntEq")
            dt.Columns.Add("pntOption")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matRate")
            dt.Columns.Add("eqRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("systemPntEq") + "|" + dr("pntOption"))
                dt.Rows.Add(dr("systemPntEq"), dr("pntOption"), dr("laborProd"), dr("matRate"), dr("eqRate"))
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
    Public Function llenarComboEqPntUnitRate(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select systemPntEq,pntOption,laborProd,matRate,eqRate from eqPaintUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("systemPntEq")
            dt.Columns.Add("pntOption")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matRate")
            dt.Columns.Add("eqRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(CStr(dr("systemPntEq"))) = -1 Then
                    cmb.Items.Add(dr("systemPntEq"))
                End If
                dt.Rows.Add(dr("systemPntEq"), dr("pntOption"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            dr.Close()
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '=====================================================================================================================================================================
    '=========== METODOS PIPINGPAINTUNITRATE =============================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectPpPntUnitRate(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select systemPntPP, pntOption, size, laborProd, matRate, eqRate from ppPaintUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("systemPntPP"), dr("pntOption"), dr("size"), dr("systemPntPP"), dr("pntOption"), dr("size"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdatePpPntUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells("systemPPId").Value Is Nothing Or row.Cells("systemPPId").Value = "") And (row.Cells("optionPPId").Value Is Nothing Or row.Cells("optionPPId").Value = "") And (row.Cells("sizePPId").Value Is Nothing Or row.Cells("sizePPId").Value = "") Then
                    cmd.CommandText = "if(select COUNT(*) from ppPaintUnitRate where systemPntPP='" + row.Cells("SystemPP").Value.ToString + "' and pntOption = '" + row.Cells("optionPP").Value.ToString + "' and size = " + row.Cells("sizePP").Value.ToString + ")=0
                        begin
	                        insert into ppPaintUnitRate values('" + row.Cells("SystemPP").Value.ToString() + "','" + row.Cells("optionPP").Value.ToString() + "'," + row.Cells("sizePP").Value.ToString() + "," + row.Cells("laborProdPP").Value.ToString() + "," + row.Cells("matRatePP").Value.ToString() + "," + row.Cells("eqRatePP").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if(select COUNT(*) from ppPaintUnitRate where systemPntpp ='" + row.Cells("systemPPId").Value.ToString() + "' and pntOption = '" + row.Cells("optionPPId").Value.ToString() + "' and size = " + row.Cells("sizePPId").Value.ToString() + ")=1
                        begin 
	                        update ppPaintUnitRate set systemPntPP='" + row.Cells("SystemPP").Value.ToString() + "',pntOption='" + row.Cells("optionPP").Value.ToString() + "',size=" + row.Cells("sizePP").Value.ToString() + ",laborProd=" + row.Cells("laborProdPP").Value.ToString() + ",matRate=" + row.Cells("matRatePP").Value.ToString() + ",eqRate=" + row.Cells("eqRatePP").Value.ToString() + " where systemPntPP = '" + row.Cells("systemPPId").Value.ToString() + "' and pntOption='" + row.Cells("optionPPId").Value.ToString() + "' and size = " + row.Cells("sizePPId").Value.ToString() + "
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
    Public Function deletePpPntUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (row.Cells("systemPPId").Value IsNot Nothing Or row.Cells("systemPPId").Value = "") And (row.Cells("optionPPId").Value IsNot Nothing Or row.Cells("optionPPId").Value = "") And (row.Cells("sizePPId").Value IsNot Nothing Or row.Cells("sizePPId").Value.ToString() = "") Then
                    Dim cmd As New SqlCommand("delete from ppPaintUnitRate where systemPntPP ='" + row.Cells("systemPPId").Value.ToString() + "' and pntOption = '" + row.Cells("optionPPId").Value.ToString() + "' and size =" + row.Cells("sizePPId").Value.ToString() + "", conn)
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
    Public Function llenarComboCellPpPntUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
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
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("systemPntPP") + "|" + dr("pntOption"))
                dt.Rows.Add(dr("systemPntPP"), dr("pntOption"), dr("size"), dr("laborProd"), dr("matRate"), dr("eqRate"))
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
    Public Function llenarComboPpPntUnitRate(ByVal cmb As ComboBox) As Data.DataTable
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
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(CStr(dr("systemPntPP"))) = -1 Then
                    cmb.Items.Add(dr("systemPntPP"))
                End If
                dt.Rows.Add(dr("systemPntPP"), dr("pntOption"), dr("size"), dr("laborProd"), dr("matRate"), dr("eqRate"))
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
    '=========== METODOS EQUIPMENTJACKETUNITRATE =========================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectEqJacketunitRate(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJacket,name,laborProd,matFactor,eqFactor from eqJktUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idJacket"), dr("idJacket"), dr("name"), dr("laborProd"), dr("matFactor"), dr("eqFactor"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateEqJacketUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells("idJacket").Value Is Nothing Or row.Cells("idJacket").Value = "") Then
                    cmd.CommandText = "if (select count (*) from eqJktUnitRate where idJacket = '" + row.Cells("JacketType").Value.ToString() + "')=0
                        begin
	                        insert into eqJktUnitRate values('" + row.Cells("JacketType").Value.ToString() + "','" + row.Cells("jacketName").Value.ToString() + "'," + row.Cells("laborProdJckEq").Value.ToString() + "," + row.Cells("matFactorJckEq").Value.ToString() + "," + row.Cells("eqFactorJckEq").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if(select count(*) from eqJktUnitRate where idJacket='" + row.Cells("idJacket").Value.ToString() + "')=1
                        begin 
	                        update eqJktUnitRate set idJacket='" + row.Cells("JacketType").Value.ToString() + "' ,name='" + row.Cells("jacketName").Value.ToString() + "',laborProd=" + row.Cells("laborProdJckEq").Value.ToString() + ",matFactor=" + row.Cells("matFactorJckEq").Value.ToString() + ",eqFactor=" + row.Cells("eqFactorJckEq").Value.ToString() + " where idJacket='" + row.Cells("idJacket").Value.ToString() + "'
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
    Public Function deleteEqJacketUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (row.Cells("idJacket").Value IsNot Nothing Or row.Cells("idJacket").Value = "") Then
                    Dim cmd As New SqlCommand("delete eqJktUnitRate where idJacket='" + row.Cells("idJacket").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellEqJacketUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJacket,name,laborProd,matFactor,eqFactor from eqJktUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idJacket")
            dt.Columns.Add("name")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matFactor")
            dt.Columns.Add("eqFactor")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idJacket") + "|" + dr("name"))
                dt.Rows.Add(dr("idJacket"), dr("name"), dr("labroProd"), dr("matFactor"), dr("eqFactor"))
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
    Public Function llenarComboEqJacketUnitRate(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJacket,name,laborProd,matFactor,eqFactor from eqJktUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("idJacket")
            dt.Columns.Add("name")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matFactor")
            dt.Columns.Add("eqFactor")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(dr("idJacket")) = -1 Then
                    cmb.Items.Add(dr("idJacket"))
                End If
                dt.Rows.Add(dr("idJacket"), dr("name"), dr("laborProd"), dr("matFactor"), dr("eqFactor"))
            End While
            dr.Close()
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '=====================================================================================================================================================================
    '=========== METODOS PINPINGJACKETUNITRATE ===========================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectPpJacketunitRate(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idJacket,name,laborProd,matFactor,eqFactor from ppJktUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("idJacket"), dr("idJacket"), dr("name"), dr("laborProd"), dr("matFactor"), dr("eqFactor"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdatePpJacketUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells("idJacketPp").Value Is Nothing Or row.Cells("idJacketPp").Value = "") Then
                    cmd.CommandText = "if (select count (*) from ppJktUnitRate where idJacket = '" + row.Cells("JacketTypePp").Value.ToString() + "')=0
                        begin
	                        insert into ppJktUnitRate values('" + row.Cells("JacketTypePp").Value.ToString() + "','" + row.Cells("jacketNamePp").Value.ToString() + "'," + row.Cells("laborProdJckPp").Value.ToString() + "," + row.Cells("matFactorJckPp").Value.ToString() + "," + row.Cells("eqFactorJckPp").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if(select count(*) from eqJktUnitRate where idJacket='" + row.Cells("idJacketPp").Value.ToString() + "')=1
                        begin 
	                        update eqJktUnitRate set idJacket='" + row.Cells("JacketTypePp").Value.ToString() + "' ,name='" + row.Cells("jacketNamePp").Value.ToString() + "',laborProd=" + row.Cells("laborProdJckPp").Value.ToString() + ",matFactor=" + row.Cells("matFactorJckPp").Value.ToString() + ",eqFactor=" + row.Cells("eqFactorJckPp").Value.ToString() + " where idJacket='" + row.Cells("idJacketPp").Value.ToString() + "'
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
    Public Function deletePpJacketUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (row.Cells("idJacketPp").Value IsNot Nothing Or row.Cells("idJacketPp").Value = "") Then
                    Dim cmd As New SqlCommand("delete ppJktUnitRate where idJacket='" + row.Cells("idJacketPp").Value.ToString() + "'", conn)
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
    Public Function llenarComboCellPpJacketUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
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
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("idJacket") + "|" + dr("name"))
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
    Public Function llenarComboPpJacketUnitRate(ByVal cmb As ComboBox) As Data.DataTable
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
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(dr("idJacket") + "|" + dr("name")) = -1 Then
                    cmb.Items.Add(dr("idJacket") + "|" + dr("name"))
                End If
                dt.Rows.Add(dr("idJacket"), dr("name"), dr("laborProd"), dr("matFactor"), dr("eqFactor"))
            End While
            dr.Close()
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
            End If
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message())
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    '=====================================================================================================================================================================
    '=========== METODOS EQUIPMENT INSULATION UNIT RATE ==================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectEqInsUnitRate(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type],thick,laborProd,matRate,eqRate from eqInsUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("type"), dr("thick"), dr("type"), dr("thick"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateEqInsUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (row.Cells("idTypeEQIUR").Value Is Nothing Or If(row.Cells("idTypeEQIUR").Value Is Nothing, "", row.Cells("idTypeEQIUR").Value.ToString()) = "") And (row.Cells("idThickEQIUR").Value Is Nothing Or If(row.Cells("idThickEQIUR").Value Is Nothing, "", row.Cells("idThickEQIUR").Value.ToString()) = "") Then
                    cmd.CommandText = "if (select count (*) from eqInsUnitRate where [type] = '" + row.Cells("typeEQIUR").Value.ToString() + "' and thick=" + row.Cells("ThickEQIUR").Value.ToString() + ")=0
                        begin
	                        insert into eqInsUnitRate values('" + row.Cells("typeEQIUR").Value.ToString() + "'," + row.Cells("ThickEQIUR").Value.ToString() + "," + row.Cells("laborProdEQIUR").Value.ToString() + "," + row.Cells("matRateEQIUR").Value.ToString() + "," + row.Cells("eqRateEQIUR").Value.ToString() + ")
                        end"
                Else
                    cmd.CommandText = "if(select count(*) from eqInsUnitRate where [type]='" + row.Cells("idTypeEQIUR").Value.ToString() + "' and thick = " + row.Cells("idThickEQIUR").Value.ToString() + ")=1
                        begin 
	                        update eqInsUnitRate set [type]='" + row.Cells("typeEQIUR").Value.ToString() + "' ,thick=" + row.Cells("ThickEQIUR").Value.ToString() + ",laborProd=" + row.Cells("laborProdEQIUR").Value.ToString() + ",matRate=" + row.Cells("matRateEQIUR").Value.ToString() + ",eqRate=" + row.Cells("eqRateEQIUR").Value.ToString() + " where [type]='" + row.Cells("idTypeEQIUR").Value.ToString() + "' and thick = " + row.Cells("idThickEQIUR").Value.ToString() + "
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
    Public Function deleteEqInsUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (row.Cells("idTypeEQIUR").Value IsNot Nothing Or If(row.Cells("idTypeEQIUR").Value Is Nothing, "", row.Cells("idTypeEQIUR").Value.ToString()) = "") And (row.Cells("idThickEQIUR").Value IsNot Nothing Or If(row.Cells("idThickEQIUR").Value Is Nothing, "", row.Cells("idThickEQIUR").Value.ToString) = "") Then
                    Dim cmd As New SqlCommand("delete eqInsUnitRate where [type]='" + row.Cells("idTypeEQIUR").Value.ToString() + "' and thick = " + row.Cells("idThickEQIUR").Value.ToString() + "", conn)
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
    Public Function llenarComboCellEqInsUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type],thick,laborProd,matRate,eqRate from eqInsUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("type")
            dt.Columns.Add("thick")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matRate")
            dt.Columns.Add("eqRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("type") + "|" + dr("thick"))
                dt.Rows.Add(dr("type"), dr("thick"), dr("laborProd"), dr("matRate"), dr("eqRate"))
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
    Public Function llenarComboEqInsUnitRate(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select [type],thick,laborProd,matRate,eqRate from eqInsUnitRate", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("type")
            dt.Columns.Add("thick")
            dt.Columns.Add("laborProd")
            dt.Columns.Add("matRate")
            dt.Columns.Add("eqRate")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(dr("type")) = -1 Then
                    cmb.Items.Add(dr("type"))
                End If
                dt.Rows.Add(dr("type"), dr("thick"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
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
    '=====================================================================================================================================================================
    '=========== METODOS PIPING INSULATION UNIT RATE =====================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectPpInsUnitRate(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select size,[type],thick,laborProd,matRate,eqRate from ppInsUnitRate", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("size"), dr("type"), dr("thick"), dr("size"), dr("type"), dr("thick"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdatePpInsUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (If(row.Cells("idSizePpIUR").Value Is Nothing, "", row.Cells("idSizePpIUR").Value.ToString) = "") And (If(row.Cells("idTypePpIUR").Value Is Nothing, "", row.Cells("idTypePpIUR").Value.ToString) = "") And (If(row.Cells("idThickPpIUR").Value Is Nothing, "", row.Cells("idThickPpIUR").Value.ToString()) = "") Then
                    cmd.CommandText = "if (select count (*) from ppInsUnitRate where size = " + row.Cells("SizePpIUR").Value.ToString() + " and [type] = '" + row.Cells("typePpIUR").Value.ToString() + "' and thick = " + row.Cells("thickPpIUR").Value.ToString() + ")=0
begin
	insert into ppInsUnitRate values(" + row.Cells("SizePpIUR").Value.ToString() + ",'" + row.Cells("typePpIUR").Value.ToString() + "'," + row.Cells("thickPpIUR").Value.ToString() + "," + row.Cells("laborProdPpIUR").Value.ToString() + "," + row.Cells("matRatePpIUR").Value.ToString() + "," + row.Cells("eqRatePpIUR").Value.ToString() + ")
end"
                Else
                    cmd.CommandText = "if(select count(*) from ppInsUnitRate where size=" + row.Cells("idSizePpIUR").Value.ToString() + " and [type]='" + row.Cells("idTypePpIUR").Value.ToString() + "' and thick=" + row.Cells("idThickPpIUR").Value.ToString() + ")=1
begin 
	update ppInsUnitRate set size=" + row.Cells("SizePpIUR").Value.ToString() + " ,[type]='" + row.Cells("typePpIUR").Value.ToString() + "',thick=" + row.Cells("thickPpIUR").Value.ToString() + ",laborProd=" + row.Cells("laborProdPpIUR").Value.ToString() + ",matRate=" + row.Cells("matRateEQIUR").Value.ToString() + ",eqRate=" + row.Cells("eqRateEQIUR").Value.ToString() + " where size=" + row.Cells("idSizePpIUR").Value.ToString() + " and [type]='" + row.Cells("idTypePpIUR").Value.ToString() + "' and thick = " + row.Cells("idThickPpIUR").Value.ToString() + "
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
    Public Function deletePpInsUnitRate(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (If(row.Cells("idSizePpIUR").Value Is Nothing, "", row.Cells("idSizePpIUR").Value.ToString()) <> "") And (If(row.Cells("idTypePpIUR").Value Is Nothing, "", row.Cells("idTypePpIUR").Value.ToString()) <> "") And (If(row.Cells("idThickPpIUR").Value Is Nothing, "", row.Cells("idThickPpIUR").Value.ToString()) <> "") Then
                    Dim cmd As New SqlCommand("delete ppInsUnitRate where size = " + row.Cells("idSizePpIUR").Value.ToString() + " and [type]='" + row.Cells("idTypePpIUR").Value.ToString() + "' and thick = " + row.Cells("idThickPpIUR").Value.ToString() + "", conn)
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
    Public Function llenarComboCellPpInsUnitRate(ByVal cmb As DataGridViewComboBoxCell) As Data.DataTable
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
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("size") + "|" + dr("type") + "|" + dr("thick"))
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
    Public Function llenarComboPpInsUnitRate(ByVal cmb As ComboBox) As Data.DataTable
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
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                If cmb.FindString(dr("type")) = -1 Then
                    cmb.Items.Add(dr("type"))
                End If
                dt.Rows.Add(dr("size"), dr("type"), dr("thick"), dr("laborProd"), dr("matRate"), dr("eqRate"))
            End While
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
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
    '=====================================================================================================================================================================
    '=========== METODOS PIPING INSULATION UNIT RATE =====================================================================================================================
    '=====================================================================================================================================================================
    Public Function selectSizesMaterialPiping() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select distinct size from pipingMaterial", conn)
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
    Public Function saveUpdatePipingMaterial(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Dim contRow As Integer = 0
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand
                If (If(row.Cells("idSizeMat").Value Is Nothing, "", row.Cells("idSizeMat").Value.ToString) = "") And (If(row.Cells("idTypeMat").Value Is Nothing, "", row.Cells("idTypeMat").Value.ToString) = "") And (If(row.Cells("idThickMat").Value Is Nothing, "", row.Cells("idThickMat").Value.ToString()) = "") Then
                    cmd.CommandText = "if (select count(*) from pipingMaterial where size = " + row.Cells("SizeMat").Value.ToString() + " and [type]='" + row.Cells("TypeMat").Value.ToString() + "' and thick = " + row.Cells("ThickMat").Value.ToString() + " )=0
                        begin 
	                        insert into pipingMaterial values (" + row.Cells("SizeMat").Value.ToString() + ",'" + row.Cells("TypeMat").Value.ToString() + "'," + row.Cells("ThickMat").Value.ToString() + "," + row.Cells("PriceMat").Value.ToString() + ",'" + row.Cells("DescriptionMat").Value.ToString() + "')
                        end"
                Else
                    cmd.CommandText = "if (select count(*) from pipingMaterial where size = " + row.Cells("idSizeMat").Value.ToString + " and [type]='" + row.Cells("idTypeMat").Value.ToString + "' and thick = " + row.Cells("TypeMat").Value.ToString + " )=1
                        begin 
	                        update pipingMaterial set size = " + row.Cells("SizeMat").Value.ToString() + " , [type]='" + row.Cells("TypeMat").Value.ToString() + "', thick= " + row.Cells("ThickMat").Value.ToString() + " , prize =" + row.Cells("PriceMat").Value.ToString() + ", [description]='" + row.Cells("DescriptionMat").Value.ToString() + "'where size = " + row.Cells("idSizeMat").Value.ToString() + " and [type]='" + row.Cells("idTypeMat").Value.ToString() + "' and thick=" + row.Cells("idThickMat").Value.ToString() + " 
                        end"
                End If
                contRow += 1
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
            MsgBox(ex.Message() + " " + contRow.ToString())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deletePipingMaterial(ByVal tbl As DataGridView) As Boolean
        conectar()
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction
        Try
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If (If(row.Cells("idSizeMat").Value Is Nothing, "", row.Cells("idSizeMat").Value.ToString()) <> "") And (If(row.Cells("idTypeMat").Value Is Nothing, "", row.Cells("idTypeMat").Value.ToString()) <> "") And (If(row.Cells("idThickMat").Value Is Nothing, "", row.Cells("idThickMat").Value.ToString()) <> "") Then
                    Dim cmd As New SqlCommand("delete from pipingMaterial where size = " + row.Cells("idSizeMat").Value.ToString() + " and [type] = '" + row.Cells("idTypeMat").Value.ToString() + "' and thick =" + row.Cells("idThickMat").Value.ToString() + "", conn)
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
    Public Function selectSizesMaterialPiping(ByVal tbl As DataGridView) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select size,[type],thick,prize,[description] from pipingMaterial", conn)
            Dim dt As New Data.DataTable
            dt.Columns.Add("size")
            dt.Columns.Add("type")
            dt.Columns.Add("thick")
            dt.Columns.Add("prize")
            dt.Columns.Add("description")
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                dt.Rows.Add(dr("size"), dr("type"), dr("thick"), dr("prize"), dr("description"))
                tbl.Rows.Add(dr("size"), dr("type"), dr("thick"), dr("size"), dr("type"), dr("thick"), dr("prize"), dr("description"))
            End While
            dr.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
End Class
