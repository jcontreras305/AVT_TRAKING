Imports System.Data.SqlClient

Public Class MetodosClients

    Inherits ConnectioDB
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    Public Sub ConsultaClients(ByVal sql As String)
        conectar()
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conn)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, "clients")
    End Sub

    Public Function IdMasAlto()
        Try
            Dim idMaxIdCL As Integer = 0
            conectar()
            Dim cmd As New SqlCommand("select MAX(numberClient)as maxNumID from clients", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader

            While reader.Read()
                Dim dato As String = reader(0)
                idMaxIdCL = CInt(dato)
            End While
            Return idMaxIdCL + 1
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function
    Sub InsertarClients(ByVal datos() As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_Insert_Cient", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@ClientID", datos(1))
            cmd.Parameters.AddWithValue("@FirstName", datos(2))
            cmd.Parameters.AddWithValue("@MiddleName", datos(3))
            cmd.Parameters.AddWithValue("@LastName", datos(4))
            cmd.Parameters.AddWithValue("@CompanyName", datos(5))
            cmd.Parameters.AddWithValue("@Status", datos(6))
            'contacto
            cmd.Parameters.AddWithValue("@phoneNumer1", datos(8))
            cmd.Parameters.AddWithValue("@phoneNumer2", datos(9))
            cmd.Parameters.AddWithValue("@email", datos(10))
            'direccion
            cmd.Parameters.AddWithValue("@avenue", datos(12))
            cmd.Parameters.AddWithValue("@number", datos(13))
            cmd.Parameters.AddWithValue("@city", datos(14))
            cmd.Parameters.AddWithValue("@providence", datos(15))
            cmd.Parameters.AddWithValue("@postalcode", datos(16))
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

    Dim consultaInner As String = "clients as cl 
left join contact as ct on cl.idContact = ct.idContact
left join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress"

    Sub buscarCliente(ByVal tblClientes As DataGridView, ByVal text As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select cl.idClient,cl.numberClient,cl.firstName,cl.middleName,cl.lastName,cl.companyName,cl.estatus,
ct.idContact,ct.phoneNumber1, ct.phoneNumber2,ct.email,
ha.idHomeAdress, ha.avenue ,ha.number, ha.city ,ha.providence,ha.postalCode from
" + consultaInner + "
where cl.numberClient like " + text + " 
or cl.firstName like  concat('%','" + text + "','%')
or cl.lastName like concat('%','" + text + "','%')
or cl.companyName like concat('%','" + text + "','%')
or ha.city like concat('%','" + text + "','%')", conn)

            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblClientes.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub buscarClienteTodos(ByVal tblClientes As DataGridView)
        Try
            conectar()
            Dim cmd As New SqlCommand("
select cl.idClient,cl.numberClient,cl.firstName,cl.middleName,cl.lastName,cl.companyName,cl.estatus,
ct.idContact,ct.phoneNumber1, ct.phoneNumber2,ct.email,
ha.idHomeAdress, ha.avenue ,ha.number, ha.city ,ha.providence,ha.postalCode from
" + consultaInner, conn)

            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblClientes.DataSource = dt
            End If
            For Each colum As DataGridViewColumn In tblClientes.Columns
                If colum.Index = 0 Or colum.Index = 7 Or colum.Index = 11 Then
                    colum.Visible = False
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub actualizaCliente(ByVal dataList As List(Of String))
        Try
            conectar()
            Dim cmd As New SqlCommand("sp_Update_Client", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idCL", dataList(0))
            cmd.Parameters.AddWithValue("@ClientID", dataList(1))
            cmd.Parameters.AddWithValue("@FirstName", dataList(2))
            cmd.Parameters.AddWithValue("@MiddleName", dataList(3))
            cmd.Parameters.AddWithValue("@LastName", dataList(4))
            cmd.Parameters.AddWithValue("@CompanyName", dataList(5))
            cmd.Parameters.AddWithValue("@Status", dataList(6))
            'contacto
            cmd.Parameters.AddWithValue("@idContact", dataList(7))
            cmd.Parameters.AddWithValue("@phoneNumer1", dataList(8))
            cmd.Parameters.AddWithValue("@phoneNumer2", dataList(9))
            cmd.Parameters.AddWithValue("@email", dataList(10))
            'direccion
            cmd.Parameters.AddWithValue("@idAddres", dataList(11))
            cmd.Parameters.AddWithValue("@avenue", dataList(12))
            cmd.Parameters.AddWithValue("@number", dataList(13))
            cmd.Parameters.AddWithValue("@city", dataList(14))
            cmd.Parameters.AddWithValue("@providence", dataList(15))
            cmd.Parameters.AddWithValue("@postalcode", dataList(16))
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

    'Metodos para proyectos de clientes 

    Public Sub buscarProyectosDeCliente(ByVal tabla As DataGridView, ByVal idCliente As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyetosClientes + " cln.idClient = '" + idCliente + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt
                Dim clmChb As New DataGridViewCheckBoxColumn
                tabla.Columns("idClient").Visible = False
                clmChb.Name = "Complete"
                tabla.Columns.Add(clmChb)
                tabla.Columns("Complete").DisplayIndex = 3
                tabla.Columns("Cmp").Visible = False
                tabla.Columns("jobNo").Visible = False
                tabla.Columns("workTMLumpSum").Visible = False
                tabla.Columns("costDistribution").Visible = False
                tabla.Columns("custumerNo").Visible = False
                tabla.Columns("contractNo").Visible = False
                tabla.Columns("costCode").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Dim consultaProyetosClientes As String = "select 
	wo.idWO as 'Work Order' , po.description as 'Project Description', wo.totalSpend as 'Total Spend',po.status as 'Cmp',
	(select SUM(hoursST) from hoursWorked as hw where hw.idWO = wo.idWO)as 'Total Hours ST',
	(
	select SUM(T2.Amount) as 'Total Amount ST' from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select idHorsWorked,hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idWO=wo.idWo)as T1 
	group by T1.idWorkCode) as T2
	) as 'Total Amount ST',

	(select SUM(hoursOT) from hoursWorked as hw where hw.idWO = wo.idWO)as 'Total Hours OT',

	(select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select idHorsWorked,hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idWO=wo.idWo)as T1 
	group by T1.idWorkCode) as T2
	) as 'Total Amount OT',

	(select SUM( amount) from expensesUsed where idWorkOrder = wo.idWo) AS 'Total Expenses Spend', 

	(select sum (amount) from materialUsed where idWO=wo.idWo) as 'Total Material Spend',
    jb.jobNo,
   	jb.workTMLumpSum,
	jb.costDistribution,
	jb.custumerNo,
	jb.contractNo,
	jb.costCode,
    cln.idClient
from
clients as cln left join job as jb on jb.idClient = cln.idClient
inner join projectOrder as po on po.jobNo = jb.jobNo
left join workOrder as wo on wo.idPO = po.idPO
where"

    Public Sub buscarProyectosDeClientePorProyeto(ByVal tabla As DataGridView, ByVal consulta As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyetosClientes + " 
cln.idClient Like '" + consulta + "' 
Or
jb.jobNo Like '" + consulta + "'
Or
cln.firstName Like '" + consulta + "'
Or
cln.middleName Like '" + consulta + "'
Or
cln.lastName Like '" + consulta + "'", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tabla.DataSource = dt


                Dim clmChb As New DataGridViewCheckBoxColumn
                clmChb.Name = "Complete"
                tabla.Columns.Add(clmChb)
                tabla.Columns("Complete").DisplayIndex = 3
                tabla.Columns("idClient").Visible = False
                tabla.Columns("Cmp").Visible = False
                tabla.Columns("jobNo").Visible = False
                tabla.Columns("workTMLumpSum").Visible = False
                tabla.Columns("costDistribution").Visible = False
                tabla.Columns("custumerNo").Visible = False
                tabla.Columns("contractNo").Visible = False
                tabla.Columns("costCode").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Sub bucarClienteDatos(ByVal idClient As String, datos As List(Of String))
        Try
            conectar()
            Dim cmd As New SqlCommand("
select cl.idClient,cl.numberClient,cl.firstName,cl.middleName,cl.lastName,cl.companyName,cl.estatus,
ct.idContact,ct.phoneNumber1, ct.phoneNumber2,ct.email,
ha.idHomeAdress, ha.avenue ,ha.number, ha.city ,ha.providence,ha.postalCode from
" + consultaInner + " where idClient = '" + idClient + "'", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                datos.Add(reader(0))
                datos.Add(reader(2))
                datos.Add(reader(5))
                datos.Add(reader(12))
                datos.Add(reader(14))
                datos.Add(reader(15))
                datos.Add(reader(16))
                datos.Add(reader(8))
            End While
            desconectar()
        Catch ex As Exception
            desconectar()
        End Try
    End Sub

End Class