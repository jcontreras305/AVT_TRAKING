Imports System.Data.SqlClient
Public Class metodosCompany
    Inherits ConnectioDB
    Private _idCompany, _idContact, _idHomeAddress, _name, _address, _number, _city, _stateProvidence, _postalCode, _country, _paymentTerms, _invoiceDescr, _phoneNumber, _faxNumber, _email, _CP As String
    Private _img As Image
    Public Property img() As Image
        Get
            If _img Is Nothing Then
                Return Nothing
            Else
                Return _img
            End If
        End Get
        Set(ByVal img As Image)
            _img = img
        End Set
    End Property
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Public Property idCompany() As String
        Get
            Return _idCompany
        End Get
        Set(ByVal value As String)
            _idCompany = value
        End Set
    End Property

    Public Property idContact() As String
        Get
            Return _idContact
        End Get
        Set(ByVal value As String)
            _idContact = value
        End Set
    End Property

    Public Property idHomeAddres() As String
        Get
            Return _idHomeAddress
        End Get
        Set(ByVal value As String)
            _idHomeAddress = value
        End Set
    End Property

    Public Property address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Public Property number() As String
        Get
            Return _number
        End Get
        Set(ByVal value As String)
            _number = value
        End Set
    End Property
    Public Property city() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property

    Public Property stateProvidence() As String
        Get
            Return _stateProvidence
        End Get
        Set(ByVal value As String)
            _stateProvidence = value
        End Set
    End Property
    Public Property postalCode() As String
        Get
            Return _postalCode
        End Get
        Set(ByVal value As String)
            _postalCode = value
        End Set
    End Property

    Public Property country() As String
        Get
            Return _country
        End Get
        Set(ByVal value As String)
            _country = value
        End Set
    End Property

    Public Property paymentTerms() As String
        Get
            If _paymentTerms Is Nothing Then
                Return ""
            Else
                Return _paymentTerms
            End If

        End Get
        Set(ByVal value As String)
            _paymentTerms = value
        End Set
    End Property

    Public Property invoiceDescr() As String
        Get
            Return _invoiceDescr
        End Get
        Set(ByVal value As String)
            _invoiceDescr = value
        End Set
    End Property

    Public Property phoneNumber() As String
        Get
            Return _phoneNumber
        End Get
        Set(ByVal value As String)
            _phoneNumber = value
        End Set
    End Property

    Public Property faxNumber() As String
        Get
            Return _faxNumber
        End Get
        Set(ByVal value As String)
            _faxNumber = value
        End Set
    End Property

    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Public Sub updateCompany()
        Try
            conectar()
            Dim cmd As New SqlCommand("
update company set name = '" + _name + "' , country = '" + _country + "' ,payTerms ='" + _paymentTerms + "' ,invoiceDescr ='" + _invoiceDescr + "' where idCompany = '" + _idCompany + "'
update HomeAddress set avenue = '" + _address + "' , number = '" + _number + "' , city = '" + _city + "' , providence = '" + _stateProvidence + "' ,postalCode='" + _postalCode + "' where idHomeAdress= '" + _idHomeAddress + "'
update contact set phoneNumber1 = '" + _phoneNumber + "' , phoneNumber2= '" + _faxNumber + "' ,email = '" + _email + "' where	idContact = '" + _idContact + "' 
", conn)
            cmd.ExecuteNonQuery()
            If _img IsNot Nothing Then
                Dim cmdImage As New SqlCommand()
                With cmdImage
                    .CommandType = CommandType.Text
                    .CommandText = "update company set img = @Imagen where name = '" + _name + "'"
                    .Connection = conn
                    .Parameters.Add(New SqlParameter("@Imagen", SqlDbType.Image)).Value = imageToByte(_img)
                End With
                cmdImage.ExecuteNonQuery()
            End If
            desconectar()
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub cargarDatos()
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT (*) from company) = 0 
begin 
	declare @idAddress as varchar(36)
	set @idAddress = NEWID()
	declare @idContact as varchar(36)
	set @idContact = NEWID()
	insert into HomeAddress values(@idAddress,'',0,'','',0)
	insert into contact values(@idContact,'','','')
	insert into company values(NEWID(),'My Company','USA','','',@idAddress,@idContact,NULL)
	select TOP(1) * from company as cp 
	inner join HomeAddress as hm on cp.idHomeAddress = hm.idHomeAdress 
	inner join contact as cn on cp.idContact = cn.idContact
end
else
begin 
	select TOP(1) * from company as cp 
	inner join HomeAddress as hm on cp.idHomeAddress = hm.idHomeAdress 
	inner join contact as cn on cp.idContact = cn.idContact
end", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader
            While rd.Read()
                _idCompany = rd("idCompany")
                _name = rd("name")
                _country = rd("country")
                _paymentTerms = rd("payTerms")
                _invoiceDescr = rd("invoiceDescr")
                _idHomeAddress = rd("idHomeAddress")
                _idContact = rd("idContact")
                _address = rd("avenue")
                _number = rd("number")
                _city = rd("city")
                _stateProvidence = rd("providence")
                _postalCode = rd("postalCode")
                _phoneNumber = rd("phoneNumber1")
                _faxNumber = rd("phoneNumber2")
                _email = rd("email")
                _img = If(rd("img") Is DBNull.Value, Nothing, BytetoImage(CType(rd("img"), Byte())))
            End While
        Catch ex As Exception
            desconectar()
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
