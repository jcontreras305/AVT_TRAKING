﻿Imports System.Data.SqlClient
Public Class MetodosMaterials
    Inherits ConnectioDB

    Public Function valueMaxVendor()
        Try
            conectar()
            Dim cmd As New SqlCommand("select max(numberVendor)+1 as max from vendor", conn)
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            If rd.Read() Then
                Dim valueMax = If(IsDBNull(rd("max")), 100, rd("max"))
                Return valueMax
            Else
                Return 100
            End If
        Catch ex As Exception
            Return 100
        End Try
        desconectar()
    End Function

    Public Function valueMaxMaterial()
        Try
            conectar()
            Dim cmd As New SqlCommand("select max(number)+1 as max from material", conn)
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            If rd.Read() Then
                Dim valueMax = If(IsDBNull(rd("max")), 100, rd("max"))
                Return valueMax
            Else
                Return 100
            End If
        Catch ex As Exception
            Dim valueMax = 100
            desconectar()
            Return valueMax
        End Try
    End Function

    Public Sub insertarVendor(ByVal datos() As String)
        conectar()
        Dim cmd As New SqlCommand("sp_insert_Vendor", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = datos(1)
        cmd.Parameters.Add("@numero", SqlDbType.Int).Value = datos(0)
        cmd.Parameters.Add("@description", SqlDbType.VarChar, 80).Value = datos(2)
        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = datos(3)
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100)
        cmd.Parameters("@msg").Direction = ParameterDirection.Output
        If cmd.ExecuteNonQuery() Then
            MsgBox(cmd.Parameters("@msg").Value.ToString)
        Else
            MsgBox("Error")
        End If
        desconectar()
    End Sub

    Public Sub insertarVendor(ByVal datos() As String, mensage As Boolean, validar As Boolean)
        conectar()
        Dim cmd As New SqlCommand("sp_insert_Vendor", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = datos(1)
        cmd.Parameters.Add("@numero", SqlDbType.Int).Value = datos(0)
        cmd.Parameters.Add("@description", SqlDbType.VarChar, 80).Value = datos(2)
        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = datos(3)
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100)
        cmd.Parameters("@msg").Direction = ParameterDirection.Output
        If cmd.ExecuteNonQuery() Then
            If mensage = True Then
                MsgBox(cmd.Parameters("@msg").Value.ToString)
                validar = True
            Else
                validar = True
            End If
        Else
            If mensage = True Then
                MsgBox("Error")
                validar = False
            Else
                validar = False
            End If
        End If
        desconectar()
    End Sub

    Public Function insertarMaterial(ByVal datos() As String, Optional tran As SqlTransaction = Nothing, Optional con As SqlConnection = Nothing) As Boolean
        Try

            Dim cmd As New SqlCommand("sp_insert_Material")
            If tran IsNot Nothing And conn IsNot Nothing Then
                cmd.Connection = con
                cmd.Transaction = tran
            Else
                conectar()
                cmd.Connection = conn
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 36).Value = datos(1)
            cmd.Parameters.Add("@numero", SqlDbType.Int).Value = datos(0)
            cmd.Parameters.Add("@idVendor", SqlDbType.VarChar, 50).Value = datos(3)
            cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = datos(2)
            cmd.Parameters.Add("@class", SqlDbType.VarChar, 20).Value = If(datos(4) = "NULL", "", datos(4))
            cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100)
            cmd.Parameters("@msg").Direction = ParameterDirection.Output
            If cmd.ExecuteNonQuery Then
                If cmd.Parameters("@msg").Value.ToString() <> "Successful" Then
                    MsgBox(cmd.Parameters("@msg").Value.ToString())
                    Return False
                Else
                    Return True
                End If
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            If con IsNot Nothing Then
                desconectar()
            End If
        End Try
    End Function

    Public Sub insertarMaterial(ByVal datos() As String, listdatosMaterial As List(Of String), message As Boolean, validar As Boolean)
        conectar()
        Dim cmd As New SqlCommand("sp_insert_Material_Excel", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 36).Value = datos(1)
        cmd.Parameters.Add("@numero", SqlDbType.Int).Value = datos(0)
        cmd.Parameters.Add("@idVendor", SqlDbType.VarChar, 50).Value = listdatosMaterial(6)
        cmd.Parameters.Add("@status", SqlDbType.Char, 1).Value = "E"
        cmd.Parameters.Add("@resourceMaterial", SqlDbType.VarChar, 50).Value = listdatosMaterial(0)
        cmd.Parameters.Add("@unitMesurement", SqlDbType.VarChar, 20).Value = listdatosMaterial(1)
        cmd.Parameters.Add("@type", SqlDbType.VarChar, 30).Value = listdatosMaterial(3)
        cmd.Parameters.Add("@price", SqlDbType.Float).Value = If(listdatosMaterial(4) = "", 0.0, listdatosMaterial(4))
        cmd.Parameters.Add("@description", SqlDbType.VarChar, 100).Value = listdatosMaterial(2)
        cmd.Parameters.Add("@size", SqlDbType.Float).Value = If(listdatosMaterial(5) = "", 0.0, listdatosMaterial(5))
        cmd.Parameters.Add("@partNum", SqlDbType.VarChar, 15).Value = If(listdatosMaterial(6) = "", "", listdatosMaterial(6))
        cmd.Parameters.Add("@code", SqlDbType.VarChar, 20).Value = If(listdatosMaterial(11) = "", "NULL", listdatosMaterial(11))
        If cmd.ExecuteNonQuery Then
            If message = True Then
                MsgBox("Successful")
            Else
                validar = True
            End If

        Else
            If message = True Then
                MsgBox("Error")
            Else
                validar = False
            End If
        End If
        desconectar()
    End Sub

    Public Sub actializarVendor(ByVal datos() As String)
        conectar()
        Dim cmd As New SqlCommand("update vendor set name = '" + datos(1) + "' , descriptions = '" + datos(2) + "' , estatus = '" + datos(3) + "' where idVendor= '" + datos(0) + "'", conn)
        If cmd.ExecuteNonQuery Then
            MsgBox("Successful.")
        Else
            MsgBox("Error, The data inserted is incorrect.")
        End If
        desconectar()
    End Sub

    Public Sub actualizarMaterial(ByVal newdatos() As String, ByVal idVendorOld As String)
        conectar()
        Dim cmd As New SqlCommand("sp_actualizaMaterial", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@idMaterial", SqlDbType.VarChar, 36).Value = newdatos(4)
        cmd.Parameters.Add("@nombreN", SqlDbType.VarChar, 50).Value = newdatos(0)
        cmd.Parameters.Add("@numeroN", SqlDbType.Int).Value = newdatos(1)
        cmd.Parameters.Add("@idVendorN", SqlDbType.VarChar, 36).Value = newdatos(2)
        cmd.Parameters.Add("@statusN", SqlDbType.Char, 1).Value = newdatos(3)
        cmd.Parameters.Add("@idVendorV", SqlDbType.VarChar, 36).Value = idVendorOld
        cmd.Parameters.Add("@class", SqlDbType.VarChar, 20).Value = newdatos(5)
        cmd.Parameters.Add("@msg", SqlDbType.VarChar, 100)
        cmd.Parameters("@msg").Direction = ParameterDirection.Output
        If cmd.ExecuteNonQuery Then
            MsgBox(cmd.Parameters("@msg").Value.ToString)
        Else
            MsgBox("Error, The data is likely to be wrong.")
        End If
    End Sub

    Public Sub selectVedor(ByVal tabla As DataGridView, ByVal consulta As String)
        conectar()
        If consulta.Length = 0 Then

            Dim cmd As New SqlCommand("select idVendor , numberVendor as 'ID' , name as 'Name' , descriptions as 'Description', 
                case estatus when 'E' then 'Enable' when 'D' then 'Disable' else 'Disab le' end as 'Status' from vendor", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns.Item(0).Visible = False
            End If
        Else
            Dim cmd As New SqlCommand("select idVendor , numberVendor as 'ID' , name as 'Name' , descriptions as 'Description', case estatus when 'E' then 'Enable' when 'D' then 'Disable' else 'Disab le' end as 'Status' 
from vendor as v
where v.name like concat('%', '" + consulta + "','%') 
or v.numberVendor like concat('%', '" + consulta + "','%') 
or v.estatus like concat('%', '" + consulta + "','%')", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns.Item(0).Visible = False
            End If
        End If
        desconectar()
    End Sub
    Public Function selectVendor() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select convert(nvarchar, numberVendor) as 'ID' , name as 'Name' , idVendor from vendor where estatus = 'E'", conn)
            Dim dt As New DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("ID")
                dt.Columns.Add("Name")
                dt.Columns.Add("idVendor")
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    Public Sub selectMaterial(ByVal tabla As DataGridView, ByVal consulta As String)
        conectar()
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        Try
            If consulta.Length = 0 Then
                cmd.CommandText = "select ma.idMaterial , vd.idVendor , ma.name As Name , ma.number as Number, case ma.estatus  when 'E' then 'Enable' when 'D' then 'Disable' else 'Disable'end as 'Status', vd.name as Vendor,isnull(mc.code,'') As 'Class'
from material as ma left join detalleMaterial as dm on ma.idMaterial = dm.idMaterial 
left join vendor as vd on vd.idVendor = dm.idVendor
left join materialClass as mc on mc.code = ma.code"
            Else
                cmd.CommandText = "select ma.idMaterial , vd.idVendor , ma.name As Name , ma.number as Number, case ma.estatus  when 'E' then 'Enable' when 'D' then 'Disable' else 'Disable'end as 'Status', vd.name as Vendor,isnull(mc.code,'') As 'Class'
from material as ma left join detalleMaterial as dm on ma.idMaterial = dm.idMaterial 
left join vendor as vd on vd.idVendor = dm.idVendor
left join materialClass as mc on mc.code = ma.code
where ma.name like concat('%','" + consulta + "','%')
or ma.number like concat('%','" + consulta + "','%')
or vd.name like concat('%','" + consulta + "','%')"
            End If
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns.Item(0).Visible = False
                tabla.Columns.Item(1).Visible = False
            End If
        Catch ex As Exception

        End Try
        desconectar()
    End Sub

    Public Sub selectMaterial(ByVal tabla As DataGridView, ByVal consulta As String, ByVal nombreVendor As String, ByVal mostrarTodo As Boolean)
        conectar()
        Dim cmd As New SqlCommand
        cmd.Connection = conn
        Try
            If consulta.Length > 0 And Not nombreVendor = "All" Then
                cmd.CommandText = "select  dm.idDM, mt.number as 'Material ID' , mt.name  as 'Material', vd.name as 'Vendor', dm.resourceMaterial as 'Resource Material' , dm.unitMesurement as 'Unit Measurement', dm.description as 'Description',dm.type as 'Type' , dm.price as 'Price', dm.size as 'Size', mt.idMaterial,  ex.quantity as 'Stocks' , dm.partNum as 'Part#'
from detalleMaterial as dm left join material as mt on dm.idMaterial = mt.idMaterial left join vendor as vd on dm.idVendor = vd.idVendor left join existences as ex on ex.idDM = dm.idDM
where vd.name like '%" + nombreVendor + "%'
and (mt.number like CONCAT ('%', '" + consulta + "','%')
OR mt.name like '%" + consulta + "%')"
            ElseIf consulta.Length > 0 And nombreVendor = "All" Then
                cmd.CommandText = "select  dm.idDM, mt.number as 'Material ID' , mt.name  as 'Material', vd.name as 'Vendor', dm.resourceMaterial as 'Resource Material' , dm.unitMesurement  as 'Unit Measurement', dm.description as 'Description',dm.type as 'Type' , dm.price as 'Price', dm.size as 'Size', mt.idMaterial , ex.quantity as 'Stocks' , dm.partNum as 'Part#'
from detalleMaterial as dm left join material as mt on dm.idMaterial = mt.idMaterial left join vendor as vd on dm.idVendor = vd.idVendor left join existences as ex on ex.idDM = dm.idDM
where 
mt.name like '%" + consulta + "%'
OR mt.number like CONCAT ('%', '" + consulta + "','%')"
            Else
                cmd.CommandText = "select  dm.idDM, mt.number as 'Material ID' , mt.name  as 'Material', vd.name as 'Vendor', dm.resourceMaterial as 'Resource Material' , dm.unitMesurement as 'Unit Measurement', dm.description as 'Description',dm.type as 'Type' , dm.price as 'Price', dm.size as 'Size', mt.idMaterial , ex.quantity as 'Stocks' , dm.partNum as 'Part#'
from detalleMaterial as dm left join material as mt on dm.idMaterial = mt.idMaterial left join vendor as vd on dm.idVendor = vd.idVendor"
            End If
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns.Item(0).Visible = mostrarTodo
                tabla.Columns.Item(4).Visible = mostrarTodo
                tabla.Columns.Item(5).Visible = mostrarTodo
                tabla.Columns.Item(6).Visible = mostrarTodo
                tabla.Columns.Item(7).Visible = mostrarTodo
                tabla.Columns.Item(8).Visible = mostrarTodo
                tabla.Columns.Item(9).Visible = mostrarTodo
                tabla.Columns.Item(10).Visible = mostrarTodo
                tabla.Columns.Item(11).Visible = mostrarTodo
                tabla.Columns.Item(12).Visible = mostrarTodo
            End If
        Catch ex As Exception

        End Try
        desconectar()
    End Sub

    Public Sub llenarVendorCombo(ByVal combo As ComboBox, ByVal listId As List(Of String))
        conectar()
        Try
            Dim cmd As New SqlCommand("select idVendor , name from vendor where estatus = 'E'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            combo.Items.Clear()
            While rd.Read()
                combo.Items.Add(rd("name"))
                listId.Add(rd("idVendor"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    Public Sub actualizarDatosMaterial(ByVal listDatosNuevos As List(Of String))
        conectar()
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "update detalleMaterial set resourceMaterial = '" + listDatosNuevos(1) + "', unitMesurement = '" + listDatosNuevos(2) + "', description = '" + listDatosNuevos(6) + "' , type = '" + listDatosNuevos(4) + "' , price = " + listDatosNuevos(5) + " , size = " + listDatosNuevos(3) + " , partNum = '" + listDatosNuevos(7) + "'
where idMaterial = '" + listDatosNuevos(0) + "'"
            cmd.Connection = conn
            If cmd.ExecuteNonQuery() Then
                MsgBox("Successful")
            Else
                MsgBox("Error , Check the data or try again. Probably connection to the server have been failed")
            End If
        Catch ex As Exception
            MsgBox("Error , Check the data or try again. Probably connection to the server have been failed")
        End Try
    End Sub

    Public Sub nuevaOrden(ByVal dataList As List(Of String))
        Try
            conectar()
            Dim tran As SqlTransaction
            Dim cmd As New SqlCommand
            cmd.CommandText = "insert into materialOrder values (NEWID()," + dataList(1) + "," + dataList(2) + ",'" + dataList(3) + "','" + dataList(0) + "')"
            cmd.Connection = conn
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "update existences set quantity = quantity + " + dataList(1) + " where idDM = '" + dataList(4) + "'"
            cmd1.Connection = conn
            tran = conn.BeginTransaction()
            cmd.Transaction = tran
            cmd1.Transaction = tran
            If MessageBox.Show("Are you sure to add this order, if you accept the stocks of this Material will change?", "Atention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If cmd.ExecuteNonQuery() > 0 Then
                    If cmd1.ExecuteNonQuery() > 0 Then
                        tran.Commit()
                    Else
                        tran.Rollback()
                    End If
                Else
                    tran.Rollback()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error , Check the data or try again. Probably connection to the server have been failed")
        End Try
    End Sub

    Public Sub selectOrdersMaterials(ByVal tabla As DataGridView, ByVal consulta As String)
        Try
            conectar()
            Dim cmd As New SqlCommand
            cmd.CommandText = "select mt.idMaterial, dt.idDM, mo.idOrder, mt.number as 'ID Materia', mt.name as 'Name' ,mo.price As 'Price', mo.fecha as 'Date',mo.quantity 'Quantity', vd.name 'Vendor', ex.quantity as 'Existences'
from materialOrder as mo
inner join material as mt on mt.idMaterial = mo.idMaterial
inner join detalleMaterial as dt on mt.idMaterial = dt.idMaterial 
left join vendor as vd on vd.idVendor = dt.idVendor
left join existences as ex on ex.idDM = dt.idDM
where vd.name like CONCAT ('%', '" + consulta + "','%')
OR mt.number like CONCAT ('%', '" + consulta + "','%')
OR mt.name like CONCAT ('%', '" + consulta + "','%')"
            cmd.Connection = conn
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns.Item(0).Visible = False
                tabla.Columns.Item(1).Visible = False
                tabla.Columns.Item(2).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub EliminarOrden(ByVal idOrder As String, cantidad As String, idDM As String)
        Try
            conectar()
            Dim cmd1 As New SqlCommand("update existences set quantity = quantity - " + cantidad + " where idDM = '" + idDM + "'", conn)
            Dim cmd As New SqlCommand("delete from materialOrder where idOrder = '" + idOrder + "'", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd.Transaction = tran
            cmd1.Transaction = tran
            If cmd1.ExecuteNonQuery Then
                If cmd.ExecuteNonQuery Then
                    MsgBox("Successful")
                    tran.Commit()
                Else
                    MsgBox("Error. Is probably that the order have been added to one job, if is it the case remove this order of the Job. Check it and try again")
                    tran.Rollback()
                End If
            Else
                MsgBox("Error. Is probably that the order have been added to one job, if is it the case remove this order of the Job. Check it and try again")
                tran.Rollback()
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateOrden(ByVal idOrder As String, ByVal cantidad As String, ByVal Precio As String, ByVal Fecha As String, ByVal idMaterial As String)
        Try
            conectar()
            Dim cmd As New SqlCommand
            cmd.CommandText = "update materialOrder set price = " + Precio + " , quantity = " + cantidad + "  , fecha = '" + Fecha + "' where idOrder = '" + idOrder + "'"
            cmd.Connection = conn
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "update existences set quantity = (quantity - (select mt.quantity from materialOrder as mt where mt.idOrder ='" + idOrder + "'))+ " + cantidad + " where idDM = (select dm.idDM from detalleMaterial as dm where idMaterial = '" + idMaterial + "')"
            cmd1.Connection = conn
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd.Transaction = tran
            cmd1.Transaction = tran
            If cmd1.ExecuteNonQuery Then
                If cmd.ExecuteNonQuery Then
                    tran.Commit()
                    MsgBox("Sucessfull")
                Else
                    tran.Rollback()
                End If
            Else
                tran.Rollback()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

End Class
