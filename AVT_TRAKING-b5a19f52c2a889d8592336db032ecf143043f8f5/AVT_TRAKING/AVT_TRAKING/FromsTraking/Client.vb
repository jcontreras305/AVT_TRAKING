Imports System.Data.SqlClient
Module Client
    Dim con As New ConnectioDB
    Private _idClient, _numberClient, _CompanyName, _firstName, _lastName, _middleName, _avenue, _city, _providence, _postalCode, _phoneNumber As String
    Private _img As Image
    Private _tblClient As New DataTable

    Public Property tblClient() As DataTable
        Get
            Return _tblClient
        End Get
        Set(ByVal tbl As DataTable)
            _tblClient = tbl
        End Set
    End Property
    Public Property idClient() As String
        Get
            Return _idClient
        End Get
        Set(ByVal id As String)
            _idClient = id
        End Set
    End Property
    Public Property NumberClient() As String
        Get
            Return _numberClient
        End Get
        Set(ByVal number As String)
            _numberClient = number
        End Set
    End Property
    Public Property CompanyName() As String
        Get
            If _CompanyName Is Nothing Then
                Return ""
            Else
                Return _CompanyName
            End If

        End Get
        Set(ByVal name As String)
            _CompanyName = name
        End Set
    End Property
    Public Property FirstName() As String
        Get
            If _firstName Is Nothing Then
                Return ""
            Else
                Return _firstName
            End If

        End Get
        Set(ByVal firstName As String)
            _firstName = firstName
        End Set
    End Property
    Public Property LastName() As String
        Get
            If _lastName Is Nothing Then
                Return ""
            Else
                Return _lastName
            End If
        End Get
        Set(ByVal lastName As String)
            _lastName = lastName
        End Set
    End Property
    Public Property MiddleName() As String
        Get
            If _middleName Is Nothing Then
                Return ""
            Else
                Return _middleName
            End If
        End Get
        Set(ByVal middleName As String)
            _middleName = middleName
        End Set
    End Property

    Public Property PhoneNumber() As String
        Get
            Return _phoneNumber
        End Get
        Set(ByVal phoneNumber As String)
            _phoneNumber = phoneNumber
        End Set
    End Property
    Public Property PostalCode() As String
        Get
            Return _postalCode
        End Get
        Set(ByVal postalcode As String)
            _postalCode = postalcode
        End Set
    End Property

    Public Property Providence() As String
        Get
            Return _providence
        End Get
        Set(ByVal prividence As String)
            _providence = prividence
        End Set
    End Property

    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal city As String)
            _city = city
        End Set
    End Property
    Public Property Avenue() As String
        Get
            Return _avenue
        End Get
        Set(ByVal avenue As String)
            _avenue = avenue
        End Set
    End Property

    Public Property ImageClient() As Image
        Get
            If _img Is Nothing Then
                Return Global.AVT_TRAKING.My.Resources.NoImage
            Else
                Return _img
            End If
        End Get
        Set(ByVal img As Image)
            _img = img
        End Set
    End Property

    Public Sub selectClient(ByVal Name As String)
        Try
            con.conectar()
            Dim arraycl As String() = Name.Split(" ")
            Dim cmd As New SqlCommand("Select idClient, numberClient, companyName , firstName , middleName , lastName , photo, ha.avenue , ha.city ,ha.providence,ha.postalCode ,ct.phoneNumber1 from clients as cl left join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress left join contact as ct on cl.idContact = ct.idContact where cl.numberClient =" + arraycl(0), con.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                idClient = dr("idClient")
                NumberClient = dr("numberClient")
                CompanyName = dr("companyName")
                FirstName = dr("firstName")
                MiddleName = dr("middleName")
                LastName = dr("lastName")
                Avenue = dr("avenue")
                City = dr("city")
                Providence = dr("providence")
                PostalCode = dr("postalCode")
                PhoneNumber = dr("phoneNumber1")
                ImageClient = BytetoImage(dr("photo"))
                Exit While
            End While
        Catch ex As Exception
        Finally
            con.desconectar()
        End Try
    End Sub
    Public Sub selectClient(ByVal Number As Integer)
        Try
            con.conectar()
            Dim cmd As New SqlCommand("Select idClient, numberClient, companyName , firstName , middleName , lastName , photo, ha.avenue , ha.city ,ha.providence,ha.postalCode ,ct.phoneNumber1 from clients as cl left join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress left join contact as ct on cl.idContact = ct.idContact where cl.numberClient = " + Number.ToString, con.conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                idClient = dr("idClient")
                NumberClient = dr("numberClient")
                CompanyName = dr("companyName")
                FirstName = dr("firstName")
                MiddleName = dr("middleName")
                LastName = dr("lastName")
                Avenue = dr("avenue")
                City = dr("city")
                Providence = dr("providence")
                PostalCode = dr("postalCode")
                PhoneNumber = dr("phoneNumber1")
                ImageClient = BytetoImage(dr("photo"))
                Exit While
            End While
            dr.Close()
        Catch ex As Exception
        Finally
            con.desconectar()
        End Try
    End Sub
    Public Sub selectFillClientTable()
        Try
            con.conectar()
            Dim cmd As New SqlCommand("select cl.idClient as 'ID Client',cl.numberClient as '# Client',cl.firstName as 'First Name',cl.middleName as 'Middlename',cl.lastName as 'Lastname',cl.companyName as 'Comapny Name',cl.estatus as 'Status',
ct.idContact ,ct.phoneNumber1, ct.phoneNumber2,ct.email,
ha.idHomeAdress, ha.avenue ,ha.number, ha.city ,ha.providence,ha.postalCode,photo,cl.payTerms from clients as cl 
left join contact as ct on cl.idContact = ct.idContact
left join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress", con.conn)
            If _tblClient IsNot Nothing Then
                _tblClient.Clear()
            End If
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(_tblClient)
            End If
        Catch ex As Exception
        Finally
            con.desconectar()
        End Try
    End Sub

End Module


