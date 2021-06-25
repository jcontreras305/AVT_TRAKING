Imports System.Data.SqlClient
Public Class scaffold
    Inherits ConnectioDB

    'scaffoldTraking
    Private _tag, _location, _purpose, _comments, _contact, _foreman, _erector, _task, _wo, _job, _descriptionWO, _jobcat, _category, _areaID, _area, _idsubJob, _subjob As String
    Private _dateBild, _dateRecComp As Date
    'scaffoldInformation
    Private _sciType, _idScaffoldinformation As String
    Private _sciWidth, _sciLength, _sciHeigth, _sciDecks, _sciKo, _sciBase, _sciExtraDeck As Double
    'activity hours
    Private _ahrIdActivityHours As String
    Private _ahrBuild, _ahrMaterial, _ahrTravel, _ahrWeather, _ahrAlarm, _ahrSafety, _ahrStdBy, _ahrOther, _ahrTotal As Double
    'productScaffold
    Private _products As DataTable
    'materialHandeling
    Private _materialHandeling(6) As Boolean
    'leg 
    Private _leg As DataTable
    'scfInfo
    Private _scfInfo(3) As Boolean

    Public Function Clear() As Boolean
        Try
            'scaffoldTraking
            _tag = ""
            _location = ""
            _purpose = ""
            _comments = ""
            _contact = ""
            _foreman = ""
            _erector = ""
            _task = ""
            _wo = ""
            _job = ""
            _descriptionWO = ""
            _jobcat = ""
            _category = ""
            _areaID = ""
            _area = ""
            _idsubJob = ""
            _subjob = ""
            _dateBild = System.DateTime.Today()
            _dateRecComp = System.DateTime.Today()
            'scaffoldInformation
            _sciType = ""
            _idScaffoldinformation = ""
            _sciWidth = 0.0
            _sciLength = 0.0
            _sciHeigth = 0.0
            _sciDecks = 0.0
            _sciKo = 0.0
            _sciBase = 0.0
            _sciExtraDeck = 0.0
            'activity hours
            _ahrIdActivityHours = 0.0
            _ahrBuild = 0.0
            _ahrMaterial = 0.0
            _ahrTravel = 0.0
            _ahrWeather = 0.0
            _ahrAlarm = 0.0
            _ahrSafety = 0.0
            _ahrStdBy = 0.0
            _ahrOther = 0.0
            _ahrTotal = 0.0
            'product
            If _products.Rows IsNot Nothing Then
                _products.Rows.Clear()
            End If
            'material handeling
            _materialHandeling = {False, False, False, False, False, False, False}
            'leg
            If _leg.Rows IsNot Nothing Then
                _leg.Rows.Clear()
            End If
            'scfInfo
            _scfInfo = {False, False, False, False}
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Property descriptionWO() As String
        Get
            If _descriptionWO Is Nothing Then
                _descriptionWO = ""
            End If
            Return _descriptionWO
        End Get
        Set(ByVal descriptionWO As String)
            _descriptionWO = descriptionWO
        End Set
    End Property
    Public Property idsubJob() As String
        Get
            If _subjob Is Nothing Then
                _subjob = ""
            End If
            Return _idsubJob
        End Get
        Set(ByVal idsubJob As String)
            _idsubJob = idsubJob
        End Set
    End Property
    Public Property area() As String
        Get
            If _area Is Nothing Then
                _area = ""
            End If
            Return _area
        End Get
        Set(ByVal area As String)
            _area = area
        End Set
    End Property
    Public Property category() As String
        Get
            If _category Is Nothing Then
                _category = ""
            End If
            Return _category
        End Get
        Set(ByVal category As String)
            _category = category
        End Set
    End Property
    Public Property dateRecComp() As Date
        Get
            If _dateRecComp = Nothing Then
                _dateRecComp = DateTime.Today
            End If
            Return _dateRecComp
        End Get
        Set(ByVal dateRecComp As Date)
            _dateRecComp = dateRecComp
        End Set
    End Property
    Public Property dateBild() As Date
        Get
            If _dateBild = Nothing Then
                _dateBild = DateTime.Today
            End If
            Return _dateBild
        End Get
        Set(ByVal dateBild As Date)
            _dateBild = dateBild
        End Set
    End Property
    Public Property subjob() As String
        Get
            If _idsubJob Is Nothing Then
                _idsubJob = ""
            End If
            Return _subjob
        End Get
        Set(ByVal subjob As String)
            _subjob = subjob
        End Set
    End Property
    Public Property areaID() As String
        Get
            If _areaID Is Nothing Then
                _areaID = ""
            End If
            Return _areaID
        End Get
        Set(ByVal areaID As String)
            _areaID = areaID
        End Set
    End Property
    Public Property jobcat() As String
        Get
            If _jobcat Is Nothing Then
                _jobcat = ""
            End If
            Return _jobcat
        End Get
        Set(ByVal jobcat As String)
            _jobcat = jobcat
        End Set
    End Property
    Public Property job() As String
        Get
            If _job Is Nothing Then
                _job = ""
            End If
            Return _job
        End Get
        Set(ByVal job As String)
            _job = job
        End Set
    End Property
    Public Property wo() As String
        Get
            If _wo Is Nothing Then
                _wo = ""
            End If
            Return _wo
        End Get
        Set(ByVal wo As String)
            _wo = wo
        End Set
    End Property
    Public Property task() As String
        Get
            If _task Is Nothing Then
                _task = ""
            End If
            Return _task
        End Get
        Set(ByVal task As String)
            _task = task
        End Set
    End Property
    Public Property erector() As String
        Get
            If _erector Is Nothing Then
                _erector = ""
            End If
            Return _erector
        End Get
        Set(ByVal erector As String)
            _erector = erector
        End Set
    End Property
    Public Property foreman() As String
        Get
            If _foreman Is Nothing Then
                _foreman = ""
            End If
            Return _foreman
        End Get
        Set(ByVal foreman As String)
            _foreman = foreman
        End Set
    End Property
    Public Property contact() As String
        Get
            If _contact Is Nothing Then
                _contact = ""
            End If
            Return _contact
        End Get
        Set(ByVal contact As String)
            _contact = contact
        End Set
    End Property
    Public Property comments() As String
        Get
            If _comments Is Nothing Then
                _comments = ""
            End If
            Return _comments
        End Get
        Set(ByVal comments As String)
            _comments = comments
        End Set
    End Property
    Public Property purpose() As String
        Get
            If _purpose Is Nothing Then
                _purpose = ""
            End If
            Return _purpose
        End Get
        Set(ByVal purpose As String)
            _purpose = purpose
        End Set
    End Property
    Public Property location() As String
        Get
            If _location Is Nothing Then
                _location = ""
            End If
            Return _location
        End Get
        Set(ByVal location As String)
            _location = location
        End Set
    End Property
    Public Property tag() As String
        Get
            Return _tag
        End Get
        Set(ByVal tag As String)
            _tag = tag
        End Set
    End Property
    Public Property sciExtraDeck() As Double
        Get
            If _sciExtraDeck = Nothing Then
                _sciExtraDeck = 0.0
            End If
            Return _sciExtraDeck
        End Get
        Set(ByVal sciExtraDeck As Double)
            _sciExtraDeck = sciExtraDeck
        End Set
    End Property
    Public Property sciBase() As Double
        Get
            If _sciBase = Nothing Then
                _sciBase = 0.0
            End If
            Return _sciBase
        End Get
        Set(ByVal sciBase As Double)
            _sciBase = sciBase
        End Set
    End Property
    Public Property sciKo() As Double
        Get
            If _sciKo = Nothing Then
                _sciKo = 0.0
            End If
            Return _sciKo
        End Get
        Set(ByVal sciKo As Double)
            _sciKo = sciKo
        End Set
    End Property
    Public Property sciDecks() As Double
        Get
            If _sciDecks = Nothing Then
                _sciDecks = 0.0
            End If
            Return _sciDecks
        End Get
        Set(ByVal sciDecks As Double)
            _sciDecks = sciDecks
        End Set
    End Property
    Public Property sciHeigth() As Double
        Get
            If _sciHeigth = Nothing Then
                _sciHeigth = 0.0
            End If
            Return _sciHeigth
        End Get
        Set(ByVal sciHeigth As Double)
            _sciHeigth = sciHeigth
        End Set
    End Property
    Public Property sciLength() As Double
        Get
            If _sciLength = Nothing Then
                _sciLength = 0.0
            End If
            Return _sciLength
        End Get
        Set(ByVal sciLength As Double)
            _sciLength = sciLength
        End Set
    End Property
    Public Property sciWidth() As Double
        Get
            If _sciWidth = Nothing Then
                _sciWidth = 0.0
            End If
            Return _sciWidth
        End Get
        Set(ByVal sciWidth As Double)
            _sciWidth = sciWidth
        End Set
    End Property
    Public Property idScaffoldinformation() As String
        Get
            If _idScaffoldinformation Is Nothing Then
                _idScaffoldinformation = ""
            End If
            Return _idScaffoldinformation
        End Get
        Set(ByVal idScaffoldinformation As String)
            _idScaffoldinformation = idScaffoldinformation
        End Set
    End Property
    Public Property sciType() As String
        Get
            If _sciType Is Nothing Then
                _sciType = ""
            End If
            Return _sciType
        End Get
        Set(ByVal sciType As String)
            _sciType = sciType
        End Set
    End Property
    Public Property ahrTotal() As Double
        Get
            If _ahrTotal = Nothing Then
                _ahrTotal = 0.0
            End If
            Return _ahrTotal
        End Get
        Set(ByVal ahrTotal As Double)
            _ahrTotal = ahrTotal
        End Set
    End Property
    Public Property ahrOther() As Double
        Get
            If _ahrOther = Nothing Then
                _ahrOther = 0.0
            End If
            Return _ahrOther
        End Get
        Set(ByVal ahrOther As Double)
            _ahrOther = ahrOther
        End Set
    End Property
    Public Property ahrStdBy() As Double
        Get
            If _ahrStdBy = Nothing Then
                _ahrStdBy = 0.0
            End If
            Return _ahrStdBy
        End Get
        Set(ByVal ahrStdBy As Double)
            _ahrStdBy = ahrStdBy
        End Set
    End Property
    Public Property ahrSafety() As Double
        Get
            If _ahrSafety = Nothing Then
                _ahrSafety = 0.0
            End If
            Return _ahrSafety
        End Get
        Set(ByVal ahrSafety As Double)
            _ahrSafety = ahrSafety
        End Set
    End Property
    Public Property ahrAlarm() As Double
        Get
            If _ahrAlarm = Nothing Then
                _ahrAlarm = 0.0
            End If
            Return _ahrAlarm
        End Get
        Set(ByVal ahrAlarm As Double)
            _ahrAlarm = ahrAlarm
        End Set
    End Property
    Public Property ahrWeather() As Double
        Get
            If _ahrWeather = Nothing Then
                _ahrWeather = 0.0
            End If
            Return _ahrWeather
        End Get
        Set(ByVal ahrWeather As Double)
            _ahrWeather = ahrWeather
        End Set
    End Property
    Public Property ahrTravel() As Double
        Get
            If _ahrTravel = Nothing Then
                _ahrTravel = 0.0
            End If
            Return _ahrTravel
        End Get
        Set(ByVal ahrTravel As Double)
            _ahrTravel = ahrTravel
        End Set
    End Property
    Public Property ahrMaterial() As Double
        Get
            If _ahrMaterial = Nothing Then
                _ahrMaterial = 0.0
            End If
            Return _ahrMaterial
        End Get
        Set(ByVal ahrMaterial As Double)
            _ahrMaterial = ahrMaterial
        End Set
    End Property
    Public Property ahrBuild() As Double
        Get
            If _ahrBuild = Nothing Then
                _ahrBuild = 0.0
            End If
            Return _ahrBuild
        End Get
        Set(ByVal ahrBuild As Double)
            _ahrBuild = ahrBuild
        End Set
    End Property
    Public Property ahrIdActivityHours() As String
        Get
            If _ahrIdActivityHours = Nothing Then
                _ahrIdActivityHours = ""
            End If
            Return _ahrIdActivityHours
        End Get
        Set(ByVal ahrIdActivityHours As String)
            _ahrIdActivityHours = ahrIdActivityHours
        End Set
    End Property

    Public Property products() As DataTable
        Get
            If _products Is Nothing Then
                _products = New DataTable
                _products.Columns.Add("idProductScaffold")
                _products.Columns.Add("idProduct")
                _products.Columns.Add("QTY")
                _products.Columns.Add("description")
                _products.Columns.Add("stock")
            End If
            Return _products
        End Get
        Set(ByVal products As DataTable)
            _products = products
        End Set
    End Property

    Public Function llenarTablaProductTag(ByVal tag As String) As DataTable
        Dim tablaProductos As New DataTable
        With tablaProductos
            tablaProductos.Columns.Add("idProductScaffold")
            tablaProductos.Columns.Add("idProduct")
            tablaProductos.Columns.Add("QTY")
            tablaProductos.Columns.Add("description")
            tablaProductos.Columns.Add("stock")
        End With
        Try
            conectar()
            Dim cmd As New SqlCommand("select ps.idProductScafold, pd.idProduct, ps.quantity,pd.name,pd.quantity as stock
from product as pd 
inner join productScaffold as ps on pd.idProduct = ps.idProduct
where ps.tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tablaProductos.Rows.Add(dr("idProductScafold"), dr("idProduct"), dr("quantity"), dr("name"), dr("stock"))
            End While
            Return tablaProductos
        Catch ex As Exception
            Return tablaProductos
        Finally
            desconectar()
        End Try
    End Function

    Public Property materialHandeling() As Boolean()
        Get
            If Not _materialHandeling.Length > 0 Then
                _materialHandeling = {False, False, False, False, False, False, False}
            End If
            Return _materialHandeling
        End Get
        Set(ByVal materialHandeling As Boolean())
            _materialHandeling = materialHandeling
        End Set
    End Property

    Public Function llenarmaterialHandeling(ByVal tag As String) As Boolean()
        Dim materialHandeling = {False, False, False, False, False, False, False}
        Try
            conectar()
            Dim cmd As New SqlCommand("select mh.truck,mh.forklift,mh.trailer,mh.crane,mh.rope,mh.passed,mh.elevator
from materialHandeling as mh
where mh.tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                materialHandeling(0) = If(dr("truck") = "t", True, False)
                materialHandeling(1) = If(dr("forklift") = "t", True, False)
                materialHandeling(2) = If(dr("trailer") = "t", True, False)
                materialHandeling(3) = If(dr("crane") = "t", True, False)
                materialHandeling(4) = If(dr("rope") = "t", True, False)
                materialHandeling(5) = If(dr("passed") = "t", True, False)
                materialHandeling(6) = If(dr("elevator") = "t", True, False)
                Exit While
            End While
            Return materialHandeling
        Catch ex As Exception
            Return materialHandeling
        Finally
            desconectar()
        End Try
    End Function

    Public Property leg() As DataTable
        Get
            If _leg Is Nothing Then
                _leg = New DataTable
                _leg.Columns.Add("legID")
                _leg.Columns.Add("qty")
                _leg.Columns.Add("heigth")
            End If
            Return _leg
        End Get
        Set(ByVal leg As DataTable)
            _leg = leg
        End Set
    End Property

    Public Function llenarLeg(ByVal tag As String) As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("legID")
        tabla.Columns.Add("qty")
        tabla.Columns.Add("heigth")
        Try
            conectar()
            Dim cmd As New SqlCommand("select legID , qty, heigth from leg where tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tabla.Rows.Add(dr("legID"), dr("qty"), dr("heigth"))
            End While
            Return tabla
        Catch ex As Exception
            Return tabla
        Finally
            desconectar()
        End Try
    End Function

    Public Property scfInfo() As Boolean()
        Get
            If Not _scfInfo.Length > 0 Then
                _scfInfo = {False, False, False, False}
            End If
            Return _scfInfo
        End Get
        Set(ByVal scfInfo() As Boolean)
            _scfInfo = scfInfo
        End Set
    End Property

    Public Function llenarScfInfo(ByVal tag As String) As Boolean()
        Dim scfInfo = {False, False, False, False}
        Try
            conectar()
            Dim cmd As New SqlCommand("select csap , rolling , internal , hanging from scfInfo where tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                scfInfo(0) = If(dr("csap") = "t", True, False)
                scfInfo(1) = If(dr("rolling") = "t", True, False)
                scfInfo(2) = If(dr("internal") = "t", True, False)
                scfInfo(3) = If(dr("hanging") = "t", True, False)
                Exit While
            End While
            Return scfInfo
        Catch ex As Exception
            Return scfInfo
        Finally
            desconectar()
        End Try
    End Function

End Class
