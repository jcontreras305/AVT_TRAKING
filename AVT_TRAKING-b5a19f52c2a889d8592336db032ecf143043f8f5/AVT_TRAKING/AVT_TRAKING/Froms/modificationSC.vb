Imports System.Data.SqlClient
Public Class ModificationSC
    Inherits ConnectioDB

    'Modification
    Private _ModAux, _ModID, _tag, _reqCompany, _requestBy, _foreman, _erector, _comments As String
    Private _ModDate As Date
    Private _status As Boolean
    'scaffoldInformation
    Private _sciType, _idScaffoldinformation As String
    Private _sciWidth, _sciLength, _sciHeigth, _sciDecks, _sciKo, _sciBase, _sciExtraDeck As Double
    'activity hours
    Private _ahrIdActivityHours As String
    Private _ahrBuild, _ahrMaterial, _ahrTravel, _ahrWeather, _ahrAlarm, _ahrSafety, _ahrStdBy, _ahrOther, _ahrTotal As Double
    'materialHandeling
    Private _idMaterialHandelig As String
    Private _materialHandeling(6) As Boolean
    'leg 
    Private _leg As DataTable
    'productAdds
    Private _ProductsAdds As DataTable
    'productSC
    Private _ProductsSC As DataTable

    Public Function Clear() As Boolean
        Try
            'Modification
            _ModAux = ""
            _ModID = ""
            _tag = ""
            _reqCompany = ""
            _requestBy = ""
            _foreman = ""
            _erector = ""
            _comments = ""
            _ModDate = System.DateTime.Today()
            _status = False
            'scaffold Information
            _sciType = ""
            _idScaffoldinformation = ""
            _sciWidth = 0.0
            _sciLength = 0.0
            _sciHeigth = 0.0
            _sciDecks = 0.0
            _sciKo = 0.0
            _sciBase = 0.0
            _sciExtraDeck = 0.0
            'Activity Hours
            _ahrIdActivityHours = ""
            _ahrBuild = 0.0
            _ahrMaterial = 0.0
            _ahrTravel = 0.0
            _ahrWeather = 0.0
            _ahrAlarm = 0.0
            _ahrSafety = 0.0
            _ahrStdBy = 0.0
            _ahrOther = 0.0
            _ahrTotal = 0.0
            'MaterialHandeling
            _idMaterialHandelig = ""
            _materialHandeling = {False, False, False, False, False, False, False}
            'Leg
            If _leg IsNot Nothing Then
                _leg.Rows.Clear()
            End If
            'ProductScaffold
            If _ProductsSC IsNot Nothing Then
                _ProductsSC.Rows.Clear()
            End If
            'ProductAdds
            If _ProductsAdds IsNot Nothing Then
                _ProductsAdds.Rows.Clear()
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Property ModAux() As String
        Get
            If _ModAux Is Nothing Then
                _ModAux = ""
            End If
            Return _ModAux
        End Get
        Set(ByVal ModAux As String)
            _ModAux = ModAux
        End Set
    End Property
    Public Property ModID() As String
        Get
            If _ModID Is Nothing Then
                _ModID = ""
            End If
            Return _ModID
        End Get
        Set(ByVal ModID As String)
            _ModID = ModID
        End Set
    End Property
    Public Property tag() As String
        Get
            If _tag Is Nothing Then
                _tag = ""
            End If
            Return _tag
        End Get
        Set(ByVal tag As String)
            _tag = tag
        End Set
    End Property
    Public Property reqCompany() As String
        Get
            If _reqCompany Is Nothing Then
                _reqCompany = ""
            End If
            Return _reqCompany
        End Get
        Set(ByVal reqCompany As String)
            _reqCompany = reqCompany
        End Set
    End Property
    Public Property requestBy() As String
        Get
            If _requestBy Is Nothing Then
                _requestBy = ""
            End If
            Return _requestBy
        End Get
        Set(ByVal requestBy As String)
            _requestBy = requestBy
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
    Public Property erector() As String
        Get
            If _erector Is Nothing Then
                _erector = "'"
            End If
            Return _erector
        End Get
        Set(ByVal erector As String)
            _erector = erector
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
    Public Property ModDate() As Date
        Get
            If _ModDate = Nothing Then
                _ModDate = System.DateTime.Today()
            End If
            Return _ModDate
        End Get
        Set(ByVal ModDate As Date)
            _ModDate = ModDate
        End Set
    End Property
    Public Property status() As Boolean
        Get
            If _status = Nothing Then
                _status = False
            End If
            Return _status
        End Get
        Set(ByVal status As Boolean)
            _status = status
        End Set
    End Property
    Public Function llenarSacffoldInformation(ByVal ModiAux As String, ByVal tag As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idScaffoldInformation,type,width,length,heigth,descks,ko,base,extraDeck from scaffoldInformation
                where tag = '" + tag + "' and idModAux='" + ModAux + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _idScaffoldinformation = If(rd("idScaffoldInformation") Is DBNull.Value, "", rd("idScaffoldInformation"))
                _sciType = If(rd("type") Is DBNull.Value, "", rd("type"))
                _sciWidth = If(rd("width") Is DBNull.Value, 0.0, CDbl(rd("width")))
                _sciLength = If(rd("length") Is DBNull.Value, 0.0, CDbl(rd("length")))
                _sciHeigth = If(rd("heigth") Is DBNull.Value, 0.0, CDbl(rd("heigth")))
                _sciDecks = If(rd("descks") Is DBNull.Value, 0.0, CDbl(rd("descks")))
                _sciKo = If(rd("ko") Is DBNull.Value, 0.0, CDbl(rd("ko")))
                _sciBase = If(rd("base") Is DBNull.Value, 0.0, CDbl(rd("base")))
                _sciExtraDeck = If(rd("extraDeck") Is DBNull.Value, 0.0, CDbl(rd("extraDeck")))
                Exit While
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
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
    Public Function llenarActivityHours(ByVal ModAux As String, ByVal tag As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idActivityHours,build,material,travel,weather,alarm,safety,stdBy,other from activityHours
                where idModAux = '" + ModAux + "' and tag= '" + tag + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _ahrIdActivityHours = If(rd("idActivityHours") Is DBNull.Value, "", rd("idActivityHours"))
                _ahrBuild = If(rd("build") Is DBNull.Value, "", rd("build"))
                _ahrMaterial = If(rd("material") Is DBNull.Value, "", rd("material"))
                _ahrTravel = If(rd("travel") Is DBNull.Value, "", rd("travel"))
                _ahrWeather = If(rd("weather") Is DBNull.Value, "", rd("weather"))
                _ahrAlarm = If(rd("alarm") Is DBNull.Value, "", rd("alarm"))
                _ahrSafety = If(rd("safety") Is DBNull.Value, "", rd("safety"))
                _ahrStdBy = If(rd("stdBy") Is DBNull.Value, "", rd("stdBy"))
                _ahrOther = If(rd("other") Is DBNull.Value, "", rd("other"))
                _ahrTotal = (_ahrBuild + _ahrMaterial + _ahrTravel + _ahrWeather + _ahrAlarm + _ahrSafety + _ahrStdBy + _ahrOther)
                Exit While
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
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
    Public Property idMaterialHandeling() As String
        Get
            Return _idMaterialHandelig
        End Get
        Set(ByVal idMaterialHandeling As String)
            _idMaterialHandelig = idMaterialHandeling
        End Set
    End Property
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
    Public Function llenarMaterialHandeling(ByVal ModAux As String, ByVal tag As String) As Boolean()
        Dim materialHandeling = {False, False, False, False, False, False, False}
        Try
            conectar()
            Dim cmd As New SqlCommand("select mh.idMaterialHandeling ,mh.truck,mh.forklift,mh.trailer,mh.crane,mh.rope,mh.passed,mh.elevator
from materialHandeling as mh
where mh.IdModAux='" + ModAux + "' and mh.tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                _idMaterialHandelig = If(dr("idMaterialHandeling") Is DBNull.Value, "", dr("idMaterialHandeling"))
                _materialHandeling(0) = If(dr("truck") = "t", True, False)
                _materialHandeling(1) = If(dr("forklift") = "t", True, False)
                _materialHandeling(2) = If(dr("trailer") = "t", True, False)
                _materialHandeling(3) = If(dr("crane") = "t", True, False)
                _materialHandeling(4) = If(dr("rope") = "t", True, False)
                _materialHandeling(5) = If(dr("passed") = "t", True, False)
                _materialHandeling(6) = If(dr("elevator") = "t", True, False)
                Exit While
            End While
            materialHandeling = _materialHandeling
            Return _materialHandeling
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
                _leg.Columns.Add("idProduct")
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
        tabla.Columns.Add("idProduct")
        tabla.Columns.Add("plf")
        tabla.Columns.Add("psqf")
        Try
            conectar()
            Dim cmd As New SqlCommand("select legID , qty, heigth, leg.idProduct , pd.PLF,pd.PSQF from leg 
left join product as pd on pd.idProduct = leg.idProduct where tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tabla.Rows.Add(dr("legID"), dr("qty"), dr("heigth"), dr("idProduct"), dr("plf"), dr("psqf"))
            End While
            _leg = tabla
            Return tabla
        Catch ex As Exception
            Return tabla
        Finally
            desconectar()
        End Try
    End Function
    Public Property productsAdds() As DataTable
        Get
            If _ProductsAdds Is Nothing Then
                _ProductsAdds = New DataTable
                _ProductsAdds.Columns.Add("idModification")
                _ProductsAdds.Columns.Add("idProduct")
                _ProductsAdds.Columns.Add("QTY")
                _ProductsAdds.Columns.Add("description")
                _ProductsAdds.Columns.Add("stock")
            End If
            Return _ProductsAdds
        End Get
        Set(ByVal products As DataTable)
            _ProductsAdds = products
        End Set
    End Property
    Public Function llenarTablaProductMod(ByVal ModAux As String, ByVal tag As String) As DataTable
        Dim tablaProductos As New DataTable
        With tablaProductos
            tablaProductos.Columns.Add("idModification")
            tablaProductos.Columns.Add("idProduct")
            tablaProductos.Columns.Add("QTY")
            tablaProductos.Columns.Add("description")
            tablaProductos.Columns.Add("stock")
        End With
        Try
            conectar()
            Dim cmd As New SqlCommand("select pm.idModAux, pd.idProduct,pm.quantity,pd.name,pd.quantity as stock 
from productModification as pm 
inner join product as pd on pm.idProduct = pd.idProduct
where pm.idModAux = '" + ModAux + "' and tag='" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                tablaProductos.Rows.Add(dr("idModAux"), dr("idProduct"), dr("quantity"), dr("name"), dr("stock"))
            End While
            _ProductsAdds = tablaProductos
            Return tablaProductos
        Catch ex As Exception
            Return tablaProductos
        Finally
            desconectar()
        End Try
    End Function
    Public Property productsSC() As DataTable
        Get
            If _ProductsSC Is Nothing Then
                _ProductsSC = New DataTable
                _ProductsSC.Columns.Add("idProductScaffold")
                _ProductsSC.Columns.Add("idProduct")
                _ProductsSC.Columns.Add("QTY")
                _ProductsSC.Columns.Add("description")
                _ProductsSC.Columns.Add("stock")
            End If
            Return _ProductsSC
        End Get
        Set(ByVal products As DataTable)
            _ProductsSC = products
        End Set
    End Property
    Public Function llenarTablaProductTag(ByVal tag As String) As DataTable
        Try
            conectar()
            If _ProductsSC Is Nothing Then
                _ProductsSC = New DataTable
                _ProductsSC.Columns.Add("idPTS")
                _ProductsSC.Columns.Add("QTY")
                _ProductsSC.Columns.Add("idProduct")
                _ProductsSC.Columns.Add("tag")
                _ProductsSC.Columns.Add("status")
            End If
            _ProductsSC.Rows.Clear()
            Dim cmd As New SqlCommand("select * from productTotalScaffold where tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                _ProductsSC.Rows.Add(dr("idPTS"), dr("quantity"), dr("idProduct"), dr("tag"), dr("status"))
            End While
            Return _ProductsSC
        Catch ex As Exception
            Return _ProductsSC
        Finally
            desconectar()
        End Try
    End Function

End Class
