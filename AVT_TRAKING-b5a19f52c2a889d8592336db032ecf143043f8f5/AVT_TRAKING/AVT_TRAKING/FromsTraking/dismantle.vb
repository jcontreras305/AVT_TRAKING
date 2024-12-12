Imports System.Data.SqlClient
Public Class dismantle
    Inherits ConnectioDB
    'Dismantle 
    Dim _idDismantle, _tag, _wo, _comments, _reqCompany, _requestBy, _foreman, _erector As String
    Dim _stopDismantle, _dismantleDate, _scStartDate As Date
    'Activity Hours
    Private _ahrIdActivityHours As String
    Private _ahrDismantle, _ahrMaterial, _ahrTravel, _ahrWeather, _ahrAlarm, _ahrSafety, _ahrStdBy, _ahrOther, _ahrTotal As Double
    'MaterialHandeling
    Private _idMaterialHandelig As String
    Private _materialHandeling(6) As Boolean
    'Product
    Private _productsDS As DataTable
    'productSC
    Private _productsSC As DataTable
    Public Function Clear() As Boolean
        Try
            'Dismantle
            _idDismantle = ""
            _tag = ""
            _wo = ""
            _comments = ""
            _reqCompany = ""
            _requestBy = ""
            _foreman = ""
            _stopDismantle = System.DateTime.Today
            _dismantleDate = System.DateTime.Today
            'Activity Hours
            _ahrIdActivityHours = ""
            _ahrDismantle = 0.0
            _ahrMaterial = 0.0
            _ahrTravel = 0.0
            _ahrWeather = 0.0
            _ahrAlarm = 0.0
            _ahrSafety = 0.0
            _ahrStdBy = 0.0
            _ahrOther = 0.0
            _ahrTotal = 0.0
            'Material Handeling
            _idMaterialHandelig = ""
            _materialHandeling = {False, False, False, False, False, False, False}
            'products
            _productsDS.Rows.Clear()
            _productsSC.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Function

    Public Property idDismantle() As String
        Get
            If _idDismantle = Nothing Then
                _idDismantle = ""
            End If
            Return _idDismantle
        End Get
        Set(ByVal idDismantle As String)
            _idDismantle = idDismantle
        End Set
    End Property
    Public Property tag() As String
        Get
            If _tag = Nothing Then
                _tag = ""
            End If
            Return _tag
        End Get
        Set(ByVal tag As String)
            _tag = tag
        End Set
    End Property
    Public Property wo() As String
        Get
            If _wo = Nothing Then
                _wo = ""
            End If
            Return _wo
        End Get
        Set(ByVal wo As String)
            _wo = wo
        End Set
    End Property
    Public Property comments() As String
        Get
            If _comments = Nothing Then
                _comments = ""
            End If
            Return _comments
        End Get
        Set(ByVal comments As String)
            _comments = comments
        End Set
    End Property
    Public Property reqCompany() As String
        Get
            If _reqCompany = Nothing Then
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
            If _requestBy = Nothing Then
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
            If _foreman = Nothing Then
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
            If _erector = Nothing Then
                _erector = ""
            End If
            Return _erector
        End Get
        Set(ByVal erector As String)
            _erector = erector
        End Set
    End Property
    Public Property stopDismantle() As Date
        Get
            If _stopDismantle = Nothing Then
                _stopDismantle = System.DateTime.Today
            End If
            Return _stopDismantle
        End Get
        Set(ByVal stopDismantle As Date)
            _stopDismantle = stopDismantle
        End Set
    End Property
    Public Property dismantleDate() As Date
        Get
            If _dismantleDate = Nothing Then
                _dismantleDate = System.DateTime.Today
            End If
            Return _dismantleDate
        End Get
        Set(ByVal dismantleDate As Date)
            _dismantleDate = dismantleDate
        End Set
    End Property
    Public Property scStartDate() As Date
        Get
            If _scStartDate = Nothing Then
                _scStartDate = System.DateTime.Today
            End If
            Return _scStartDate
        End Get
        Set(ByVal scStartDate As Date)
            _scStartDate = scStartDate
        End Set
    End Property
    Public Function llenarActivityHours(ByVal DismantleId As String, ByVal tag As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idActivityHours,build,material,travel,weather,alarm,safety,stdBy,other from activityHours
                where idDismantle = '" + DismantleId + "' and tag= '" + tag + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _ahrIdActivityHours = If(rd("idActivityHours") Is DBNull.Value, "", rd("idActivityHours"))
                _ahrDismantle = If(rd("build") Is DBNull.Value, "", rd("build"))
                _ahrMaterial = If(rd("material") Is DBNull.Value, "", rd("material"))
                _ahrTravel = If(rd("travel") Is DBNull.Value, "", rd("travel"))
                _ahrWeather = If(rd("weather") Is DBNull.Value, "", rd("weather"))
                _ahrAlarm = If(rd("alarm") Is DBNull.Value, "", rd("alarm"))
                _ahrSafety = If(rd("safety") Is DBNull.Value, "", rd("safety"))
                _ahrStdBy = If(rd("stdBy") Is DBNull.Value, "", rd("stdBy"))
                _ahrOther = If(rd("other") Is DBNull.Value, "", rd("other"))
                _ahrTotal = (_ahrDismantle + _ahrMaterial + _ahrTravel + _ahrWeather + _ahrAlarm + _ahrSafety + _ahrStdBy + _ahrOther)
                Exit While
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
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
    Public Property ahrDismantle() As Double
        Get
            If _ahrDismantle = Nothing Then
                _ahrDismantle = 0.0
            End If
            Return _ahrDismantle
        End Get
        Set(ByVal ahrDismantle As Double)
            _ahrDismantle = ahrDismantle
        End Set
    End Property
    Public Function llenarMaterialHandeling(ByVal DismantleId As String, ByVal tag As String) As Boolean()
        Dim materialHandeling = {False, False, False, False, False, False, False}
        Try
            conectar()
            Dim cmd As New SqlCommand("select mh.idMaterialHandeling ,mh.truck,mh.forklift,mh.trailer,mh.crane,mh.rope,mh.passed,mh.elevator
from materialHandeling as mh
where mh.idDismantle='" + DismantleId + "' and mh.tag = '" + tag + "'", conn)
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
    Public Property idMaterialHandeling() As String
        Get
            If _idMaterialHandelig Is Nothing Then
                _idMaterialHandelig = ""
            End If
            Return _idMaterialHandelig
        End Get
        Set(ByVal idMaterialHandeling As String)
            _idMaterialHandelig = idMaterialHandeling
        End Set
    End Property
    Public Property materialHandeling() As Boolean()
        Get
            If _materialHandeling Is Nothing Then
                _materialHandeling = {False, False, False, False, False, False, False}
            End If
            Return _materialHandeling
        End Get
        Set(ByVal materialHandeling As Boolean())
            _materialHandeling = materialHandeling
        End Set
    End Property
    Public Property productsDS() As DataTable
        Get
            If _productsDS Is Nothing Then
                _productsDS = New DataTable
                _productsDS.Columns.Add("idPDS")
                _productsDS.Columns.Add("idProduct")
                _productsDS.Columns.Add("QTY")
                _productsDS.Columns.Add("Name")
            End If
            Return _productsDS
        End Get
        Set(ByVal productsDStbl As DataTable)
            _productsDS = productsDStbl
        End Set
    End Property
    Public Function llenarTablaProductDismantle(ByVal DisID As String, ByVal tag As String) As DataTable
        Try
            conectar()
            If _productsDS Is Nothing Then
                _productsDS = New DataTable
                _productsDS.Columns.Add("idPDS")
                _productsDS.Columns.Add("idProduct")
                _productsDS.Columns.Add("QTY")
                _productsDS.Columns.Add("Name")
            End If
            _productsDS.Rows.Clear()
            Dim cmd As New SqlCommand("select pds.idPDS,pds.idProduct,pds.quantity,pd.name
from productDismantle as pds
inner join product as pd on pd.idProduct = pds.idProduct
where pds.idDismantle = '" + DisID + "' and tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                _productsDS.Rows.Add(dr("idPDS"), dr("idProduct"), dr("quantity"), dr("Name"))
            End While
            Return _productsSC
        Catch ex As Exception
            Return _productsSC
        Finally
            desconectar()
        End Try
    End Function
    Public Property prodcutsSC() As DataTable
        Get
            If _productsSC Is Nothing Then
                _productsSC = New DataTable
                _productsSC.Columns.Add("idPTS")
                _productsSC.Columns.Add("idProduct")
                _productsSC.Columns.Add("QTY")
            End If
            Return _productsSC
        End Get
        Set(ByVal productSCtbl As DataTable)
            _productsSC = productSCtbl
        End Set
    End Property
    Public Function llenarTablaProductSC(ByVal tag As String) As DataTable
        Try
            conectar()
            If _productsSC Is Nothing Then
                _productsSC = New DataTable
                _productsSC.Columns.Add("idPTS")
                _productsSC.Columns.Add("idProduct")
                _productsSC.Columns.Add("QTY")
            End If
            _productsSC.Rows.Clear()
            Dim cmd As New SqlCommand("select * from productTotalScaffold where tag = '" + tag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                _productsSC.Rows.Add(dr("idPTS"), dr("idProduct"), dr("quantity"))
            End While
            Return _productsSC
        Catch ex As Exception
            Return _productsSC
        Finally
            desconectar()
        End Try
    End Function
    Public Function findJobNoByTag(ByVal idTag) As String
        Try
            Dim JobNo = ""
            conectar()
            Dim cmd As New SqlCommand("select jb.jobNo from dismantle  as ds
inner join scaffoldTraking as sc on sc.tag = ds.tag 
inner join task  as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO= wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where ds.tag = '" + idTag + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                JobNo = CStr(dr("jobNo"))
            End While
            dr.Close()
            Return JobNo
        Catch ex As Exception
            Return ""
        Finally
            desconectar()
        End Try
    End Function
End Class
