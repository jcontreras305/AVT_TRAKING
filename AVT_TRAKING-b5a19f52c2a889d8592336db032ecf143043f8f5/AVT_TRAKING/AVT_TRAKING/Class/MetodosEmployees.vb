Imports System.Data.SqlClient
Imports System.Collections.ArrayList


Public Class MetodosEmployees
    Inherits ConnectioDB

    Dim consultaInner As String = " from employees as em inner join HomeAddress as ads 
		on em.idHomeAdress = ads.idHomeAdress 
	left join contact as con 
		on em.idContact = con.idContact 
	left join(select pr.idPayRate,pr.payRate1,pr.payRate2,pr.payRate3,pr.idEmployee from payRate as pr inner join employees as em on em.idEmployee =  pr.idEmployee where datePayRate = (select MAX(datePayRate) from payRate where idEmployee = em.idEmployee)) as T1
		on em.idEmployee = T1.idEmployee "


    Public Sub llenarCmbType(ByVal cmb As ComboBox)
        Try
            conectar()
            Dim cmd As New SqlCommand("select name from typeEmployee", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                cmb.Items.Add(reader(0))
            End While
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub cargarEmpleados(ByVal tblEmpledos As DataGridView, ByVal text As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select  em1.numberEmploye as Number, em1.firstName  , em1.lastName , em1.middleName , 
con.phoneNumber1, con.phoneNumber2 , con.email , 
ads.city , ads.providence, T1.payRate1,T1.payRate2,T1.payRate3,typeEmployee from employees as em1 left join 
(select pr.payRate1,pr.payRate2,pr.payRate3,pr.idEmployee from payRate as pr inner join employees as em on em.idEmployee =  pr.idEmployee where datePayRate = (select MAX(datePayRate) from payRate where idEmployee = em.idEmployee)) 
as T1
on T1.idEmployee = em1.idEmployee 
inner join HomeAddress as ads on em1.idHomeAdress = ads.idHomeAdress 
left join contact as con on em1.idContact = con.idContact 
where em1.numberEmploye like CONCAT('%','" + text + "','%') or 
	em1.lastName like CONCAT('%','" + text + "','%') or 
	em1.firstName like CONCAT('%','" + text + "','%') or
	em1.middleName like CONCAT('%','" + text + "','%') or
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

    Public Function guardarEmpleado(ByVal datosGeneralesEmpleado() As String, ByVal arraybyte() As Byte) As Boolean
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
            cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = datosGeneralesEmpleado(18)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        desconectar()
    End Function

    Public Function insertNewPayRateEmployee(ByVal idEmployee As String, ByVal pay1 As Decimal, ByVal pay2 As Decimal, ByVal pay3 As Decimal) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into payRate values (NEWID()," + CStr(pay1) + "," + CStr(pay2) + "," + CStr(pay3) + ",'" + idEmployee + "',GETDATE())", conn)
            If cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

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
                Loop While cont < 27
            End While
            Return list
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        desconectar()
    End Function

    Public Sub actualizar_Employee(ByVal datosNuevos() As String, ByVal idEmpleado As String, ByVal idAddress As String, ByVal idContancto As String, ByVal arraybyte As Byte())
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_update_Employee")
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            'ids 4
            cmd.Parameters.Add("@idEmployee", SqlDbType.VarChar, 36).Value = idEmpleado
            cmd.Parameters.Add("@idAddress", SqlDbType.VarChar, 36).Value = idAddress
            cmd.Parameters.Add("@idContact", SqlDbType.VarChar, 36).Value = idContancto
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
            'cmd.Parameters.Add("@payRate1", SqlDbType.Float).Value = datosNuevos(15)
            'cmd.Parameters.Add("@payRate2", SqlDbType.Float).Value = datosNuevos(16)
            'cmd.Parameters.Add("@payRate3", SqlDbType.Float).Value = datosNuevos(17)
            cmd.Parameters.Add("@type", SqlDbType.VarChar, 20).Value = datosNuevos(18)
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

    Public Function selectEmployeeIDd() As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("SELECT numberEmploye FROM employees", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function

    '======================================================================================================
    '=============== METODOS PARA EMEPLEADOS DE LA SECCIONDE DE HORAS TRABAJADAS ==========================
    '======================================================================================================
    '======================================================================================================
    Public Function bucarEmpleados(ByVal tblEmpleados As DataGridView, ByVal consulta As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEmployee , numberEmploye as 'Employee Number' ,CONCAT(firstName,' ',middleName,' ',lastName) as 'Employee Name' , photo  from employees where estatus = 'E'
and (CONCAT(firstName,' ',middleName,' ',lastName) like '%" + consulta + "%' or numberEmploye like '%" + consulta + "%')", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblEmpleados.DataSource = dt
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function llenarCmbTypeEmployee(ByVal cmbEmployeManager As DataGridViewComboBoxCell) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select name from typeEmployee", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim lst As New List(Of String)
            While reader.Read()
                cmbEmployeManager.Items.Add(reader("name"))
            End While
            If cmbEmployeManager.Items.Count > 0 Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function llenarCmbEmpleadosManager(ByVal cmbEmployeManager As ComboBox) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEmployee, CONCAT(lastName,', ',middleName,' ',firstName) as name from employees where typeEmployee = 'Manager'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim lst As New List(Of String)
            While reader.Read()
                cmbEmployeManager.Items.Add(reader("name"))
                lst.Add(reader("idEmployee"))
            End While
            If cmbEmployeManager.Items.Count > 0 Then
                Return lst
            Else
                Return Nothing
            End If
            desconectar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '======================================================================================================
    '=============== METODOS PARA EMEPLEADOS DE LA VENTANA DE ABSENTS PARA EMPLEADOS ======================
    '======================================================================================================
    '======================================================================================================

    Public Function insertAbsents(ByVal datos As List(Of String)) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into absents values(NEWID(),'" + validaFechaParaSQl(datos(0)) + "'," + datos(1) + ",'" + datos(2) + "','" + datos(3) + "')", conn)
            If cmd.ExecuteNonQuery > 0 Then
                desconectar()
                Return True
            Else
                desconectar()
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    '======================================================================================================
    '=============== METODOS PARA EMEPLEADOS AL MOMENTO DE INSERTAR NEVOS RECORDS =========================
    '======================================================================================================
    '======================================================================================================

    Public Function selectEmployeeToTimeSheet() As DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select numberEmploye as 'CardTimeID', CONCAT(lastName,' ',firstName,', ',middleName) as 'Employee Name' from employees where estatus = 'E'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim table As New DataTable
                da.Fill(table)
                desconectar()
                Return table
            Else
                desconectar()
                Return Nothing
            End If
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message())
            Return Nothing
        End Try
    End Function



End Class
