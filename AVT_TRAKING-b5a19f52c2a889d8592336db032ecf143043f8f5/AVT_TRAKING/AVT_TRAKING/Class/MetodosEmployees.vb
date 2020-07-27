Imports System.Data.SqlClient

Public Class MetodosEmployees
    Inherits ConnectioDB

    Dim consultaInner As String = " from employees as em inner join HomeAddress as ads 
		on em.idHomeAdress = ads.idHomeAdress 
	left join contact as con 
		on em.idContact = con.idContact 
	left join payRate as pr
		on em.idPayRate = pr.idPayRate "




    Public Sub cargarEmpleados(ByVal tblEmpledos As DataGridView, ByVal text As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select em.numberEmploye as Number, em.firstName  , em.lastName , em.middleName , 
con.phoneNumber1, con.phoneNumber2 , con.email , 
ads.city , ads.providence,
pr.payRate1 , pr.payRate2,pr.payRate3" + consultaInner +
" where em.numberEmploye like CONCAT('%','" + text + "','%') or 
	em.lastName like CONCAT('%','" + text + "','%') or 
	em.firstName like CONCAT('%','" + text + "','%') or
	em.middleName like CONCAT('%','" + text + "','%') or
	ads.city like CONCAT('%','" + text + "','%')  ", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblEmpledos.DataSource = dt
            Else
                MsgBox("Error in the connection to Data Base check your sever")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub guardarEmpleado(ByVal datosGeneralesEmpleado() As String, ByVal arraybyte() As Byte)
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_insert_Employee", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@numberEmploye", SqlDbType.VarChar, 25).Value = datosGeneralesEmpleado(0)
            cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 30).Value = datosGeneralesEmpleado(1)
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 25).Value = datosGeneralesEmpleado(2)
            cmd.Parameters.Add("@middleName", SqlDbType.VarChar, 25).Value = datosGeneralesEmpleado(3)
            cmd.Parameters.Add("@socialNumber", SqlDbType.VarChar, 14).Value = datosGeneralesEmpleado(4)
            cmd.Parameters.Add("@SAPNumber", SqlDbType.Int).Value = datosGeneralesEmpleado(5)
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = arraybyte
            cmd.Parameters.Add("@estatus", SqlDbType.Char, 1).Value = datosGeneralesEmpleado(6)
            'contacto
            cmd.Parameters.Add("@phoneNumber1", SqlDbType.VarChar, 13).Value = datosGeneralesEmpleado(7)
            cmd.Parameters.Add("@phoneNumber2", SqlDbType.VarChar, 13).Value = datosGeneralesEmpleado(8)
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = datosGeneralesEmpleado(9)
            'direccion
            cmd.Parameters.Add("@avenue", SqlDbType.VarChar, 80).Value = datosGeneralesEmpleado(10)
            cmd.Parameters.Add("@number", SqlDbType.Int).Value = datosGeneralesEmpleado(11)
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 20).Value = datosGeneralesEmpleado(12)
            cmd.Parameters.Add("@providence", SqlDbType.VarChar, 20).Value = datosGeneralesEmpleado(13)
            cmd.Parameters.Add("@postalCode", SqlDbType.Int).Value = datosGeneralesEmpleado(14)
            'pay
            cmd.Parameters.Add("@payRate1", SqlDbType.Float).Value = datosGeneralesEmpleado(15)
            cmd.Parameters.Add("@payRate2", SqlDbType.Float).Value = datosGeneralesEmpleado(16)
            cmd.Parameters.Add("@payRate3", SqlDbType.Float).Value = datosGeneralesEmpleado(17)
            If cmd.ExecuteNonQuery Then
                MsgBox("Successfull")
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

    Public Sub buscar_Employee(ByVal busqueda As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("", conn)
        Catch ex As Exception

        End Try
        desconectar()
    End Sub

    Public Function cargar_Imagen_De_Employee(ByVal firstName As String, ByVal number As String) As Byte()
        Try
            conectar()
            Dim cmd As New SqlCommand("select photo from employees where numberEmploye  = " + number + " and firstName = '" + firstName + "'", conn)
            Dim rd As SqlDataReader

            rd = cmd.ExecuteReader
            If rd.Read Then
                Dim arrayImage = rd("photo")
                Return arrayImage
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        desconectar()
    End Function

    Public Function datosEmpleado(ByVal firstName As String, ByVal number As String) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select * " + consultaInner + " where em.firstName = '" + firstName + "' and em.numberEmploye = " + number, conn)
            Dim rd As SqlDataReader
            rd = cmd.ExecuteReader
            Dim list As New List(Of String)
            While rd.Read()
                Dim cont As Int16 = 0
                Do
                    If cont <> 7 Then
                        list.Add(CStr(rd(cont)))
                    End If
                    cont += 1
                Loop While cont < 26
            End While
            Return list
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        desconectar()
    End Function

    Public Sub actualizar_Employee(ByVal datosNuevos() As String, ByVal idEmpleado As String, ByVal idAddress As String, ByVal idContancto As String, ByVal idPay As String, ByVal arraybyte As Byte())
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_update_Employee")
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            'ids 4
            cmd.Parameters.Add("@idEmployee", SqlDbType.VarChar, 36).Value = idEmpleado
            cmd.Parameters.Add("@idAddress", SqlDbType.VarChar, 36).Value = idAddress
            cmd.Parameters.Add("@idContact", SqlDbType.VarChar, 36).Value = idContancto
            cmd.Parameters.Add("@idPay", SqlDbType.VarChar, 36).Value = idPay
            'generales 8
            cmd.Parameters.Add("@numberEmploye", SqlDbType.VarChar, 25).Value = datosNuevos(0)
            cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 30).Value = datosNuevos(1)
            cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 25).Value = datosNuevos(2)
            cmd.Parameters.Add("@middleName", SqlDbType.VarChar, 25).Value = datosNuevos(3)
            cmd.Parameters.Add("@socialNumber", SqlDbType.VarChar, 14).Value = datosNuevos(4)
            cmd.Parameters.Add("@SAPNumber", SqlDbType.Int).Value = datosNuevos(5)
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = arraybyte
            cmd.Parameters.Add("@estatus", SqlDbType.Char, 1).Value = datosNuevos(6)
            'contacto 3
            cmd.Parameters.Add("@phoneNumber1", SqlDbType.VarChar, 13).Value = datosNuevos(7)
            cmd.Parameters.Add("@phoneNumber2", SqlDbType.VarChar, 13).Value = datosNuevos(8)
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = datosNuevos(9)
            'direccion 5 
            cmd.Parameters.Add("@avenue", SqlDbType.VarChar, 80).Value = datosNuevos(10)
            cmd.Parameters.Add("@number", SqlDbType.Int).Value = datosNuevos(11)
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 20).Value = datosNuevos(12)
            cmd.Parameters.Add("@providence", SqlDbType.VarChar, 20).Value = datosNuevos(13)
            cmd.Parameters.Add("@postalCode", SqlDbType.Int).Value = datosNuevos(14)
            'pay 4
            cmd.Parameters.Add("@payRate1", SqlDbType.Float).Value = datosNuevos(15)
            cmd.Parameters.Add("@payRate2", SqlDbType.Float).Value = datosNuevos(16)
            cmd.Parameters.Add("@payRate3", SqlDbType.Float).Value = datosNuevos(17)
            cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            If cmd.ExecuteNonQuery Then
                Dim resultado As String = cmd.Parameters("@msg").Value
                MsgBox(resultado)
            Else
                MsgBox("Error")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        desconectar()
    End Sub

End Class
