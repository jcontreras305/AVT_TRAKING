﻿Imports System.Data.SqlClient

Public Class MetodosJobs
    Inherits ConnectioDB
    'metodos work code y type work code
    'Public Sub selectWC(ByVal cmbTWC As ComboBox, ByVal listIDS As List(Of String))
    '    conectar()
    '    Try
    '        Dim cmd As New SqlCommand("select clasification , idTWorkCode from typeWorkCode", conn)
    '        Dim rd As SqlDataReader
    '        rd = cmd.ExecuteReader()
    '        While rd.Read()
    '            cmbTWC.Items.Add(rd("clasification"))
    '            listIDS.Add(rd("idTWorkCode"))
    '        End While
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    desconectar()
    'End Sub

    '########################################################################################################################
    '############  METODOS PARA WORKCODE ####################################################################################
    '########################################################################################################################


    Public Sub selectWC(ByVal tabla As DataGridView)
        conectar()
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "select idWorkCode as ID , name Name , description as Description, billingRate1 as BillingRT1, billingRateOT as BillingOT, billingRate3 as BillingRT3 , EQExq1,EQExq2 from workCode  "
            cmd.Connection = conn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub nuevaWC(datos() As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into workCode values (" + datos(0) + ",'" + datos(1) + "','" + datos(2) + "'," + datos(3) + "," + datos(4) + "," + datos(5) + ",'" + datos(6) + "','" + datos(7) + "')")
            cmd.Connection = conn
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub acualizarWC(datos() As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update workCode set name='" + datos(1) + "',description ='" + datos(2) + "', billingRate1=" + datos(3) + ", billingRateOT=" + datos(4) + ",EQExq1='" + datos(6) + "',EQExq2='" + datos(7) + "' where idWorkCode =  " + datos(0), conn)
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub buscarWC(ByVal dato As String, ByVal tabla As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from workCode where idWorkCode like '" + dato + "' or  name like '%" + dato + "%' or description like '%" + dato + "%' ", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    '########################################################################################################################
    '############  METODOS PARA EXPENCES ####################################################################################
    '########################################################################################################################

    Public Sub buscarExpences(ByVal tabla As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from expenses", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns(0).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    Public Sub buscarExpences(ByVal tabla As DataGridView, ByVal dato As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from expenses where expenseCode like '%" + dato + "%' or description like '%" + dato + "%'", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
                tabla.Columns(0).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    Public Sub insertExpence(ByVal code As String, ByVal description As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into expenses values (NEWID(), '" + code + "','" + description + "')")
            cmd.Connection = conn
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

    Public Sub actualizarExpence(ByVal id As String, ByVal code As String, ByVal description As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("update expenses set expenseCode = '" + code + "' , description = '" + description + "' where idExpences = '" + id + "'", conn)
            If cmd.ExecuteNonQuery Then
                MsgBox("Succesfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        desconectar()
    End Sub

End Class