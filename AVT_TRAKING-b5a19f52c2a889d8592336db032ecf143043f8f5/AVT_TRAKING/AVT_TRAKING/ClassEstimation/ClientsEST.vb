Imports System.Data.SqlClient
Public Class ClientsEST
    Inherits ConnectioDB

    Private _idclient, _contactName, _companyName, _plant As String
    Private _numberClient As Integer
    Private _idHomeAddress,_avenue, _city, _province As String
    Private _number, _postalCode As Integer
    Private _idContact, _phone1, _phone2 As String
    Public _tablaClientEst As New DataTable
    Public _tablaProjects As New DataTable
    Public Property tablaprojects() As DataTable
        Get
            If _tablaProjects Is Nothing Then
                Dim tbl As New DataTable
                tbl.Columns.Add("idClientEst")
                tbl.Columns.Add("projectId")
                tbl.Columns.Add("description")
                tbl.Columns.Add("unit")
                tbl.Columns.Add("releaseDate")
                tbl.Columns.Add("projectName")
                _tablaProjects = tbl
                Return _tablaProjects
            Else

                Return _tablaProjects
            End If
        End Get
        Set(ByVal tablaprojects As DataTable)
            _tablaProjects = tablaprojects
        End Set
    End Property
    Public Property tablaClientEst() As DataTable
        Get
            If _tablaClientEst Is Nothing Then
                Dim tbl As New DataTable
                tbl.Columns.Add("idClientEST")
                tbl.Columns.Add("numberClient")
                tbl.Columns.Add("contactName")
                tbl.Columns.Add("companyName")
                _tablaClientEst = tbl
                Return tbl
            Else
                Return _tablaClientEst
            End If
        End Get
        Set(ByVal tablaClientEst As DataTable)
            _tablaClientEst = tablaClientEst
        End Set
    End Property
    Public Property phone2() As String
        Get
            If _phone2 Is Nothing Then
                Return ""
            Else
                Return _phone2
            End If
        End Get
        Set(ByVal phone2 As String)
            _phone2 = phone2
        End Set
    End Property
    Public Property phone1() As String
        Get
            If _phone1 Is Nothing Then
                Return ""
            Else
                Return _phone1
            End If
        End Get
        Set(ByVal phone1 As String)
            _phone1 = phone1
        End Set
    End Property
    Public Property idContact() As String
        Get
            If _idContact Is Nothing Then
                Dim idCon As Guid = Guid.NewGuid()
                _idContact = idCon.ToString()
                Return _idContact
            Else
                Return _idContact
            End If
        End Get
        Set(ByVal idContact As String)
            _idContact = idContact
        End Set
    End Property
    Public Property idHomeAddress() As String
        Get
            If _idHomeAddress Is Nothing Then
                Dim idHomeAdd As Guid = Guid.NewGuid()
                _idHomeAddress = idHomeAdd.ToString()
                Return _idHomeAddress
            Else
                Return _idHomeAddress
            End If
        End Get
        Set(ByVal idHomeAddress As String)
            _idHomeAddress = idHomeAddress
        End Set
    End Property
    Public Property avenue() As String
        Get
            If _avenue Is Nothing Then
                Return ""
            Else
                Return _avenue
            End If
        End Get
        Set(ByVal avenue As String)
            _avenue = avenue
        End Set
    End Property
    Public Property city() As String
        Get
            If _city Is Nothing Then
                Return ""
            Else
                Return _city
            End If
        End Get
        Set(ByVal city As String)
            _city = city
        End Set
    End Property
    Public Property province() As String
        Get
            If _province Is Nothing Then
                Return ""
            Else
                Return _province
            End If
        End Get
        Set(ByVal province As String)
            _province = province
        End Set
    End Property
    Public Property number() As Integer
        Get
            If _number = Nothing Then
                Return 0
            Else
                Return _number
            End If
        End Get
        Set(ByVal number As Integer)
            _number = number
        End Set
    End Property
    Public Property postalCode() As Integer
        Get
            If _postalCode = Nothing Then
                Return 0
            Else
                Return _postalCode
            End If
        End Get
        Set(ByVal postalCode As Integer)
            _postalCode = postalCode
        End Set
    End Property
    Public Property numberClient() As Integer
        Get
            If _numberClient = Nothing Then
                _numberClient = 0
                Return _number
            Else
                Return _numberClient
            End If
        End Get
        Set(ByVal numberClient As Integer)
            _numberClient = numberClient
        End Set
    End Property
    Public Property plant() As String
        Get
            If _plant Is Nothing Then
                Return ""
            Else
                Return _plant
            End If
        End Get
        Set(ByVal plant As String)
            _plant = plant
        End Set
    End Property
    Public Property companyName() As String
        Get
            If _companyName Is Nothing Then
                Return ""
            Else
                Return _companyName
            End If
        End Get
        Set(ByVal companyName As String)
            _companyName = companyName
        End Set
    End Property
    Public Property contactName() As String
        Get
            If _contactName Is Nothing Then
                Return ""
            Else
                Return _contactName
            End If

        End Get
        Set(ByVal contactName As String)
            _contactName = contactName
        End Set
    End Property
    Public Property idClient() As String
        Get
            If _idclient = Nothing Then
                Dim idcl As Guid = Guid.NewGuid()
                _idclient = idcl.ToString()
                Return _idclient
            Else
                Return _idclient
            End If
        End Get
        Set(ByVal idclient As String)
            _idclient = idclient
        End Set
    End Property
    Public Function saveClient(ByVal cl As ClientsEST) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
declare @numClient as int = " + CStr(cl.numberClient) + "
declare @error int
if (select COUNT(*) from clientsEst where numberClient = @numClient)=0
begin 
    begin tran 
	begin try
	declare @idClient as varchar(36) = '" + cl.idClient + "'
	declare @idContact as varchar(36) = '" + cl.idContact + "'
	declare @idHomeAddress as varchar(36) = '" + cl.idHomeAddress + "'
    insert into HomeAddress values (@idHomeAddress,'" + cl.avenue + "'," + CStr(cl.number) + ",'" + cl.city + "','" + cl.province + "'," + CStr(cl.postalCode) + ")
	insert into contact values (@idContact,'" + cl.phone1 + "','" + cl.phone2 + "','')
    insert into clientsEst  values (@idClient," + CStr(cl.numberClient) + ",'" + cl.contactName + "','" + cl.companyName + "','" + cl.plant + "',@idContact,@idHomeAddress)
    end try
	begin catch
        set @error = 1
		goto solveproblem
	end catch
	commit tran
	solveproblem:
	if @error <> 0
	begin 
		rollback tran 
	end
end 
else
begin
	update clientsEst set contactName = '" + cl.contactName + "',companyName= '" + cl.companyName + "' where numberClient = @numClient
	update HomeAddress set avenue = '" + cl.avenue + "' , number = " + CStr(cl.number) + " , city = '" + cl.city + "' ,providence='" + cl.province + "',postalCode = " + CStr(cl.postalCode) + " where idHomeAdress = '" + cl.idHomeAddress + "'
	update contact set phoneNumber1 = '" + cl.phone1 + "',phoneNumber2='" + cl.phone2 + "' where idContact = '" + cl.idContact + "'
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Public Sub Clear()
        _idclient = Nothing
        _idHomeAddress = Nothing
        _idContact = Nothing
        _avenue = Nothing
        _city = Nothing
        _companyName = Nothing
        _contactName = Nothing
        _number = Nothing
        _numberClient = Nothing
        _phone1 = Nothing
        _phone2 = Nothing
        _plant = Nothing
        _postalCode = Nothing
        _province = Nothing
        _tablaClientEst.Rows.Clear()
        _tablaProjects.Rows.Clear()
    End Sub
    Public Function cargarDatosClientEst(ByVal numberClient As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select top 1 cl.idClientEst,cl.numberClient,cl.contactName,cl.companyName,cl.plant,cl.idContact,cl.idHomeAdress
,ha.avenue,ha.number,ha.city,ha.providence,ha.postalCode
,ct.phoneNumber1,ct.phoneNumber2 from clientsEst as cl 
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
inner join contact as ct on ct.idContact = cl.idContact
where cl.numberClient = " + numberClient + "", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read
                _idclient = dr("idClientEst")
                _numberClient = dr("numberClient")
                _contactName = dr("contactName")
                _companyName = dr("companyName")
                _idContact = dr("idContact")
                _idHomeAddress = dr("idHomeAdress")
                _avenue = dr("avenue")
                _number = dr("number")
                _city = dr("city")
                _province = dr("providence")
                _postalCode = dr("postalCode")
                _phone1 = dr("phoneNumber1")
                _phone2 = dr("phoneNumber2")
                _plant = dr("plant")
            End While
            dr.Close()
            Dim cmd2 As New SqlCommand("select cl.idClientEst,pjc.projectId,pjc.[description],pjc.unit, iif(pjc.releaseDate is null,'',CONVERT(varchar, pjc.releaseDate,101))as 'releaseDate'  ,pjc.projectId as 'projectName'
from projectClientEst as pjc 
inner join clientsEst as cl on cl.idClientEst = pjc.idClientEst
where cl.numberClient =  " + numberClient + "", conn)
            If cmd2.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd2)
                da.Fill(dt)
                _tablaProjects = dt
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectClientsEst() As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idClientEst,numberClient,contactName,companyName from clientsEst", conn)
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                _tablaClientEst = dt
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
    '#########################################################################################################################################################################################
    '####################### METODOS PARA PROJECTS CLIENTS ESTIMATION ########################################################################################################################
    '#########################################################################################################################################################################################
    Public Function insertarActualizarProject(ByVal idClient As String, ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand("declare @idClient as varchar(36) = '" + idClient + "'
if (select COUNT(*) from projectClientEst where projectId = '" + If(row.Cells("ProjectName").Value Is Nothing, "", row.Cells("ProjectName").Value) + "' )=0
begin
	insert into projectClientEst values('" + row.Cells("Project").Value + "','" + row.Cells("Description").Value + "','" + row.Cells("Unit").Value + "'," + If(row.Cells("ReleaseDate").Value Is Nothing Or row.Cells("ReleaseDate").Value = "", "NULL", "'" + validaFechaParaSQl(row.Cells("ReleaseDate").Value) + "'") + ",@idClient)
end
else
begin
	update projectClientEst set projectId='" + row.Cells("Project").Value + "', [description]='" + row.Cells("Description").Value + "',unit='" + row.Cells("Unit").Value + "', releaseDate= " + If(row.Cells("ReleaseDate").Value Is Nothing Or row.Cells("ReleaseDate").Value = "", "NULL", "'" + validaFechaParaSQl(row.Cells("ReleaseDate").Value) + "'") + " where projectId = '" + If(row.Cells("ProjectName").Value Is Nothing, "", row.Cells("ProjectName").Value) + "' and idClientEst= @idClient 
end", conn)
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
    Public Function deleteProject(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("ProjectName").Value IsNot Nothing Then
                    Dim cmd As New SqlCommand("delete from projectClientEst where projectId = '" + row.Cells("ProjectName").Value + "' and idClientEst= '" + row.Cells("NumClient").Value + "'", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
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
    Public Function llenarComboClientsEst(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select cl.idClientEst, cl.numberClient ,cl.contactName,po.projectId, po.unit, po.[description] from clientsEst as cl
inner join projectClientEst as po on cl.idClientEst = po.idClientEst", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As New Data.DataTable
            dt.Columns.Add("idClient")
            dt.Columns.Add("numberClient")
            dt.Columns.Add("contactName")
            dt.Columns.Add("projectId")
            dt.Columns.Add("unit")
            dt.Columns.Add("description")
            cmb.Items.Clear()
            While dr.Read()
                dt.Rows.Add(dr("idClientEst").ToString(), dr("numberClient").ToString(), dr("contactName"), dr("projectId"), dr("unit").ToString(), dr("description").ToString())
                cmb.Items.Add(dr("numberClient").ToString() + " " + dr("contactName").ToString() + " " + dr("description").ToString())
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
End Class
