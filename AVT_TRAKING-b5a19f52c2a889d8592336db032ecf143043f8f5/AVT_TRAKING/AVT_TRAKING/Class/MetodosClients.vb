Imports System.Data.SqlClient

Public Class MetodosClients

    Inherits ConnectioDB
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand

    Public Function ConsultaClients() As Data.DataTable
        Try
            conectar()
            Dim tbl As New Data.DataTable
            tbl.Columns.Add("IdClient")
            tbl.Columns.Add("numberClient")
            tbl.Columns.Add("ClientName")
            Dim cmd As New SqlCommand("select idClient,numberClient,companyName from clients", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tbl.Rows.Add(dr("idClient"), dr("numberClient"), dr("companyName"))
            End While
            dr.Close()
            Return tbl
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function IdMasAlto()
        Try
            Dim idMaxIdCL As Integer = 0
            conectar()
            Dim cmd As New SqlCommand("select isnull(MAX(numberClient),100)as maxNumID from clients", conn)
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
    Sub InsertarClients(ByVal datos() As String, ByVal img As Byte())
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
            cmd.Parameters.AddWithValue("@payTerms", datos(17))
            'image
            cmd.Parameters.Add("@img", SqlDbType.Image).Value = img
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
select cl.idClient as 'ID Client',cl.numberClient as '# Client',cl.firstName as 'First Name',cl.middleName as 'Middlename',cl.lastName as 'Lastname',cl.companyName as 'Comapny Name',cl.estatus as 'Status',
ct.idContact ,ct.phoneNumber1, ct.phoneNumber2,ct.email,
ha.idHomeAdress, ha.avenue ,ha.number, ha.city ,ha.providence,ha.postalCode,photo,cl.payTerms from
" + consultaInner, conn)

            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tblClientes.DataSource = dt
            End If
            For Each colum As DataGridViewColumn In tblClientes.Columns
                If colum.Index = 0 Or colum.Index = 7 Or colum.Index = 11 Or colum.Index = 17 Or colum.Index = 18 Then
                    colum.Visible = False
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub actualizaCliente(ByVal dataList As List(Of String), ByVal img As Byte())
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
            cmd.Parameters.AddWithValue("@payTerms", dataList(17))
            cmd.Parameters.Add("@img", SqlDbType.Image).Value = img
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
                If tabla.Columns.Count = 24 Then
                    Dim clmChb As New DataGridViewCheckBoxColumn
                    tabla.Columns("idClient").Visible = False
                    clmChb.Name = "Complete"
                    tabla.Columns.Add(clmChb)
                    tabla.Columns("Complete").DisplayIndex = 3
                End If
                tabla.Columns("Cmp").Visible = False
                tabla.Columns("jobNo").Visible = False
                tabla.Columns("workTMLumpSum").Visible = False
                tabla.Columns("costDistribution").Visible = False
                tabla.Columns("custumerNo").Visible = False
                tabla.Columns("contractNo").Visible = False
                tabla.Columns("costCode").Visible = False
                tabla.Columns("idTask").Visible = False
                tabla.Columns("idAuxWO").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            desconectar()
        End Try
    End Sub
    Public Sub buscarProyectosDeClienteAll(ByVal tabla As DataGridView, ByVal idCliente As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyetosClientes + " cln.idClient = '" + idCliente + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tabla.Rows.Clear()
            While dr.Read()
                tabla.Rows.Add(dr("Work Order"), dr("Project Description"), If(dr("Cmp") = "0", False, True), dr("Total Spend"), dr("Total Hours ST"), dr("Total Amount ST"), dr("Total Hours OT"), dr("Total Amount OT"), dr("Total Hours 3"), dr("Total Amount 3"), dr("Total Expenses Spend"), dr("Total Material Spend"), dr("jobNo"), dr("workTMLumpSum"), dr("costDistribution"), dr("custumerNo"), dr("contractNo"), dr("costCode"), dr("idClient"), dr("idPO"), dr("idTask"), dr("idAuxWO"), dr("idAux"), dr("photo"))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            desconectar()
        End Try
    End Sub

    Dim consultaProyetosClientes As String = "select 
	(select CONCAT(wo.idWO,' ',tk.task)) as 'Work Order' , 
	
	ISNULL( tk.description ,'') as 'Project Description', 
	
	ISNULL( tk.status, 0 ) as 'Cmp',
	
	concat('$', (
		
			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  inner join clients as cl1 on cl1.idClient = jb1.idClient
			where cl1.idClient = cln.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=tk.idAux  )as T1    
			group by T1.idWorkCode) as T2)--Billing ST
			+
			(select  ISNULL( SUM(T2.Amount),0) as 'Billing OT' from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient 
			where cl1.idClient = cln.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=tk.idAux)as T1    
			group by T1.idWorkCode) as T2) --Billing OT
			+
			(select  ISNULL( SUM(T2.Amount),0) as 'Billing 3T' from 
			(select SUM(T1.hours3*T1.billingRate3) AS 'Amount'
			from (select hours3, hw.idWorkCode , billingRate3  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient 
			where cl1.idClient = cln.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=tk.idAux)as T1    
			group by T1.idWorkCode) as T2) --Billing 3T
			+
			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient 
			where cl1.idClient = cln.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=tk.idAux ),  0)--Expenses Used
			+
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient 
			where cl1.idClient = cln.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=tk.idAux), 0)-- Material Used
			)
		) as 'Total Spend',

	ISNULL( (select SUM(hoursST) from hoursWorked as hw where hw.idAux = tk.idAux) ,0)
	as 'Total Hours ST',

	(select CONCAT('$' ,ISNULL(SUM(T2.Amount),0)) as 'Total Amount ST' from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select idHorsWorked,hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=tk.idAux)as T1    
	group by T1.idWorkCode) as T2)
	as 'Total Amount ST',

	ISNULL( (select SUM(hoursOT) from hoursWorked as hw where hw.idAux = tk.idAux),0)
	as 'Total Hours OT',

	(select CONCAT('$' ,ISNULL(SUM(T2.Amount),0)) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select idHorsWorked,hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=tk.idAux)as T1 
	group by T1.idWorkCode) as T2)
	as 'Total Amount OT',

    ISNULL( (select SUM(hours3) from hoursWorked as hw where hw.idAux = tk.idAux),0)
	as 'Total Hours 3',
		
	(select CONCAT('$' ,ISNULL(SUM(T2.Amount),0)) from 
	(select SUM(T1.hours3*T1.billingRate3) AS 'Amount'
	from (select idHorsWorked,hours3, hw.idWorkCode , billingRate3  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=tk.idAux)as T1 
	group by T1.idWorkCode) as T2
	)
	as 'Total Amount 3',

	CONCAT('$' ,ISNULL((select SUM( amount) from expensesUsed where idAux = tk.idAux),'0')) AS 'Total Expenses Spend', 
	
	CONCAT('$' ,ISNULL((select sum (amount) from materialUsed where idAux = tk.idAux),'0')) AS 'Total Material Spend',
    
	jb.jobNo,
   	jb.workTMLumpSum,
	jb.costDistribution,
	ISNULL(jb.custumerNo,'')AS 'custumerNo' ,
	ISNULL(jb.contractNo,'')AS 'contractNo',
	jb.costCode,
    cln.idClient,
    po.idPO,
	ISNULL(tk.task ,'') AS 'idTask',
    ISNULL(wo.idAuxWO,'') AS 'idAuxWO',
	ISNULL(tk.idAux,'') AS 'idAux',
	cln.photo
from
clients as cln left join job as jb on jb.idClient = cln.idClient
inner join projectOrder as po on po.jobNo = jb.jobNo
left join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = jb.jobNo
left join task as tk on tk.idAuxWO = wo.idAuxWO
where "


    Public Sub buscarProyectosDeClientePorProyeto(ByVal tabla As DataGridView, ByVal consulta As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyetosClientes + "
cln.numberClient like '" + consulta + "'
Or
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
                If tabla.Columns.Count = 24 Then
                    Dim clmChb As New DataGridViewCheckBoxColumn
                    clmChb.Name = "Complete"
                    tabla.Columns.Add(clmChb)
                    tabla.Columns("Complete").DisplayIndex = 3
                End If
                tabla.Columns("idClient").Visible = False
                tabla.Columns("Cmp").Visible = False
                tabla.Columns("jobNo").Visible = True
                tabla.Columns("workTMLumpSum").Visible = False
                tabla.Columns("costDistribution").Visible = False
                tabla.Columns("custumerNo").Visible = False
                tabla.Columns("contractNo").Visible = False
                tabla.Columns("costCode").Visible = False
                tabla.Columns("idPO").Visible = False
                tabla.Columns("idAuxWO").Visible = False
                tabla.Columns("idAux").Visible = False
                tabla.Columns("photo").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Public Sub buscarProyectosDeClientePorProyetoAll(ByVal tabla As DataGridView, ByVal consulta As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyetosClientes + "
cln.numberClient like '" + consulta + "'
Or
cln.idClient Like '" + consulta + "' 
Or
CONCAT(wo.idWO , ' ', tk.task) like '%" + consulta + "%'
Or
jb.jobNo Like '" + consulta + "'
Or
cln.firstName Like '" + consulta + "'
Or
cln.middleName Like '" + consulta + "'
Or
cln.lastName Like '" + consulta + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tabla.Rows.Clear()
            While dr.Read()
                tabla.Rows.Add(dr("Work Order"), dr("Project Description"), If(dr("Cmp") = "0", False, True), dr("Total Spend"), dr("Total Hours ST"), dr("Total Amount ST"), dr("Total Hours OT"), dr("Total Amount OT"), dr("Total Hours 3"), dr("Total Amount 3"), dr("Total Expenses Spend"), dr("Total Material Spend"), dr("jobNo"), dr("workTMLumpSum"), dr("costDistribution"), dr("custumerNo"), dr("contractNo"), dr("costCode"), dr("idClient"), dr("idPO"), dr("idTask"), dr("idAuxWO"), dr("idAux"), dr("photo"))
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            desconectar()
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


    Public Function actualizarAddres(ByVal Address As String, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update HomeAddress set avenue = '" + Address + "' where idHomeAdress =(select idHomeAddress from clients where idClient = '" + idClient + "')", conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarCity(ByVal City As String, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update HomeAddress set city = '" + City + "' where idHomeAdress =(select idHomeAddress from clients where idClient = '" + idClient + "')", conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarProvidence(ByVal Providence As String, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update HomeAddress set providence = '" + Providence + "' where idHomeAdress =(select idHomeAddress from clients where idClient = '" + idClient + "')", conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarPostalCode(ByVal PostalCode As String, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update HomeAddress set postalCode = '" + PostalCode + "' where idHomeAdress =(select idHomeAddress from clients where idClient = '" + idClient + "')", conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function actualizarPhoneNumber(ByVal PhoneNumber As String, ByVal idClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update contact set phoneNumber1 = '" + PhoneNumber + "' where idContact =(select idContact from clients where idClient = '" + idClient + "')", conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class