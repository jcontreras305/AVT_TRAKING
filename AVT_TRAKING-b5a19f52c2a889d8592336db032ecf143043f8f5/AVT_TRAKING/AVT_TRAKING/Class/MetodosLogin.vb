﻿Imports System.Data.SqlClient

Public Class MetodosLogin

    Inherits ConnectioDB 'el inherit nos permite entre clases llamar las funcion y atributos publicos de otra calse como si fuese 1

    'Dim con As New ConnectioDB ' tambien podemos hacer una instacia de una clase pero es diferente la forma de llamar las funciones o atributos

    Public Function StartLogin(user As String, password As String) As Boolean
        Try
            conectar() 'esto es con el inherit 
            'con.conectar() 'esto es con la instancia a la clase
            Dim cmd As New SqlCommand("select * from users where nameUser = '" + user + "' and passwordUser = '" + password + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable ' es para tener una tabla igual como la que se muestra en las consultas en la DB
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Dim flag As Boolean = False
                For Each row As Data.DataRow In dt.Rows
                    If row.ItemArray(1).Equals(user) And row.ItemArray(2).Equals(password) Then
                        flag = True
                        Exit For
                    End If
                Next
                Return flag
            Else 'Si no se pudo ejecutar regresa falso
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
