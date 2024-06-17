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
where cl.numberClient like '" + text + "' 
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
            Dim cmd As New SqlCommand(consultaProyectos(" cln.idClient = '" + idCliente + "'"), conn)
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
                tabla.Columns("Taxes").Visible = False
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
            Dim cmd As New SqlCommand(consultaProyectos(" cln.idClient = '" + idCliente + "'"), conn)
            cmd.CommandTimeout = 350
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                tabla.DataSource = dt
            Else
                MsgBox("Error")
            End If
            tabla.Columns("jobNo").Visible = False
            tabla.Columns("workTMLumpSum").Visible = False
            tabla.Columns("costDistribution").Visible = False
            tabla.Columns("custumerNo").Visible = False
            tabla.Columns("contractNo").Visible = False
            tabla.Columns("costCode").Visible = False
            tabla.Columns("idClient").Visible = False
            tabla.Columns("idPO").Visible = False
            tabla.Columns("idTask").Visible = False
            tabla.Columns("idAuxWO").Visible = False
            tabla.Columns("idAux").Visible = False
            tabla.Columns("photo").Visible = False
            tabla.Columns("postingProject").Visible = False
            tabla.Columns("Taxes").Visible = False
            'Dim dr As SqlDataReader = cmd.ExecuteReader()
            'tabla.Rows.Clear()
            'While dr.Read()
            '    tabla.Rows.Add(dr("Work Order"), dr("Project Description"), If(dr("Cmp") = 0, False, True), dr("Total Spend"), dr("Total Hours ST"), dr("Total Amount ST"), dr("Total Hours OT"), dr("Total Amount OT"), dr("Total Hours 3"), dr("Total Amount 3"), dr("Total Expenses Spend"), dr("Total Material Spend"), dr("jobNo"), dr("workTMLumpSum"), dr("costDistribution"), dr("custumerNo"), dr("contractNo"), dr("costCode"), dr("idClient"), dr("idPO"), dr("idTask"), dr("idAuxWO"), dr("idAux"), dr("photo"), dr("postingProject"))
            'End While
            'dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message())
        Finally
            desconectar()
        End Try
    End Sub
    Private Function consultaProyectos(ByVal queryFilter As String) As String
        Dim consultaProyetosClients As String = "select T2.[Work Order],T2.[Project Description],T2.[Complete],
CONCAT('$',(T2.[Total Amount ST]+T2.[Total Amount OT]+T2.[Total Amount 3]+T2.[Total Expenses Spend]+T2.[Total Material Spend])*(iif( T2.[Taxes]>0,T2.[Taxes]/100,0))) as 'Total Taxes',
CONCAT('$',(T2.[Total Amount ST]+T2.[Total Amount OT]+T2.[Total Amount 3]+T2.[Total Expenses Spend]+T2.[Total Material Spend])+(T2.[Total Amount ST]+T2.[Total Amount OT]+T2.[Total Amount 3]+T2.[Total Expenses Spend]+T2.[Total Material Spend])*(iif( T2.[Taxes]>0,T2.[Taxes]/100,0))) as 'Total Spend', 
T2.[Total Hours ST],
CONCAT('$',T2.[Total Amount ST])as 'Total Amount ST',T2.[Total Hours OT],
CONCAT('$',T2.[Total Amount OT])as 'Total Amount OT',T2.[Total Hours 3],
CONCAT('$',T2.[Total Amount 3]) as 'Total Amount 3',
CONCAT('$',T2.[Total Expenses Spend]) as 'Total Expenses Spend',
CONCAT('$',T2.[Total Material Spend]) as 'Total Material Spend',
T2.[jobNo],T2.[workTMLumpSum],T2.[costDistribution],T2.[custumerNo],T2.[contractNo],T2.[costCode],T2.[idClient],T2.[idPO],T2.[idTask],T2.[idAuxWO],T2.[idAux],(select [photo] from clients where T2.idClient = idClient)as 'photo',T2.postingProject,T2.[Taxes] from (
select DISTINCT 
T1.[Work Order],
T1.[Project Description],
T1.[Complete],
SUM(T1.[Total Hours ST]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Hours ST',
SUM(T1.[Amount ST]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Amount ST',
SUM(T1.[Total Hours OT]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Hours OT',
SUM(T1.[Amount OT]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Amount OT',
SUM(T1.[Total Hours 3]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Hours 3',
SUM(T1.[Amount 3]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Amount 3',
SUM(T1.[Total Expenses Spend]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Expenses Spend',
SUM(T1.[Total Material Spend]) OVER (PARTITION BY T1.[idClient],T1.[jobNo],T1.[idPO],T1.[idAuxWO],T1.[idAux]) as 'Total Material Spend',
T1.[jobNo],
T1.[workTMLumpSum],
T1.[costDistribution],
T1.[custumerNo],
T1.[contractNo],
T1.[costCode],
T1.[idClient],
T1.[idPO],
T1.[idTask],
T1.[idAux],
T1.[idAuxWO],
T1.[postingProject],
T1.[Taxes]
 from (
select CONCAT(wo.idWO,' ',tk.task) as 'Work Order' , 
	
	ISNULL( tk.description ,'') as 'Project Description', 
	
	convert(bit,tk.status) as 'Complete',

	ISNULL( hw.hoursST , 0)	as 'Total Hours ST',

	ISNULL( hw.hoursST , 0)*wc.billingRate1 as 'Amount ST',

	ISNULL( hw.hoursOT , 0)	as 'Total Hours OT',
	
	ISNULL( hw.hoursOT , 0)*wc.billingRateOT as 'Amount OT',

	ISNULL( hw.hours3 , 0)	as 'Total Hours 3',
	
	ISNULL( hw.hours3 , 0)*wc.billingRate3 as 'Amount 3',

	0 AS 'Total Expenses Spend', 
	0 AS 'Total Material Spend',

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
    jb.postingProject,
    jb.Taxes as 'Taxes'
 from hoursWorked as hw
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO  and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cln on cln.idClient = jb.idClient
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and jb.jobNo = wc.jobNo
where @filter

union all

select CONCAT(wo.idWO,' ',tk.task) as 'Work Order' , 
	ISNULL( tk.description ,'') as 'Project Description', 
	convert(bit,tk.status) as 'Complete',
	0 as 'Total Hours ST',
	0 as 'Amount ST',
	0 as 'Total Hours OT',
	0 as 'Amount OT',
	0 as 'Total Hours OT',
	0 as 'Amount 3', 

	exu.amount AS 'Total Expenses Spend', 
	
	0 AS 'Total Material Spend',
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
    jb.postingProject,
    jb.Taxes as 'Taxes'
 from expensesUsed as exu
inner join task as tk on tk.idAux = exu.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO  and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cln on cln.idClient = jb.idClient
inner join expenses as ex on ex.idExpenses = exu.idExpense 
where @filter

union all

select CONCAT(wo.idWO,' ',tk.task) as 'Work Order' , 
	ISNULL( tk.description ,'') as 'Project Description', 
	convert(bit,tk.status) as 'Complete',
	0 as 'Total Hours ST',
	0 as 'Amount ST',
	0 as 'Total Hours OT',
	0 as 'Amount OT',
	0 as 'Total Hours OT',
	0 as 'Amount 3', 

	0 AS 'Total Expenses Spend', 
	
	mtu.amount AS 'Total Material Spend',
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
    jb.postingProject,
    jb.Taxes as 'Taxes'
 from materialUsed as mtu
inner join task as tk on tk.idAux = mtu.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO  and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cln on cln.idClient = jb.idClient
inner join material as mt on mt.idMaterial= mtu.idMaterial
where  @filter )as T1) as T2 "
        consultaProyetosClients = consultaProyetosClients.Replace("@filter", queryFilter)


        Return consultaProyetosClients
    End Function

    Public Sub buscarProyectosDeClientePorProyeto(ByVal tabla As DataGridView, ByVal consulta As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyectos("
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
cln.lastName Like '" + consulta + "'"), conn)
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
                tabla.Columns("postingProject").Visible = True
                tabla.Columns("Taxes").Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub
    Public Sub buscarProyectosDeClientePorProyetoAll(ByVal tabla As DataGridView, ByVal consulta As String)
        Try
            conectar()
            Dim cmd As New SqlCommand(consultaProyectos("
cln.numberClient like '" + consulta + "'
Or
cln.idClient Like '" + consulta + "' 
Or
CONCAT(wo.idWO , ' ', tk.task) like '%" + consulta + "%'
Or
CONCAT(wo.idWO , '-', tk.task) like '%" + consulta + "%'
Or 
wo.idWO like '%" + consulta + "%'
Or 
tk.task like '%" + consulta + "%'
Or
jb.jobNo Like '" + consulta + "'
Or
cln.firstName Like '" + consulta + "'
Or
cln.middleName Like '" + consulta + "'
Or
cln.lastName Like '" + consulta + "'"), conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tabla.Rows.Clear()
            While dr.Read()
                tabla.Rows.Add(dr("Work Order"), dr("Project Description"), If(dr("Cmp") = "0", False, True), dr("Total Spend"), dr("Total Hours ST"), dr("Total Amount ST"), dr("Total Hours OT"), dr("Total Amount OT"), dr("Total Hours 3"), dr("Total Amount 3"), dr("Total Expenses Spend"), dr("Total Material Spend"), dr("jobNo"), dr("workTMLumpSum"), dr("costDistribution"), dr("custumerNo"), dr("contractNo"), dr("costCode"), dr("idClient"), dr("idPO"), dr("idTask"), dr("idAuxWO"), dr("idAux"), dr("photo"), dr("postingProject"))
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