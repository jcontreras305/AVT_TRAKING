Public Class Project
    Private _idPO, _accountNum, _jobNum As Integer
    Private _equipament, _manager, _description, _expCode As String
    Private _beginDate, _endDate As Date
    Private _estimateHours, _totalBilling As Double
    Private _status As Char

    Public Property idPO As Integer
        Get
            Return _idPO
        End Get
        Set(value As Integer)
            _idPO = value
        End Set
    End Property

    Public Property accountNum As Integer
        Get
            Return _accountNum
        End Get
        Set(value As Integer)
            _accountNum = value
        End Set
    End Property

    Public Property jobNum As Integer
        Get
            Return _jobNum
        End Get
        Set(value As Integer)
            _jobNum = value
        End Set
    End Property

    Public Property equipament As String
        Get
            Return _equipament
        End Get
        Set(value As String)
            _equipament = value
        End Set
    End Property

    Public Property manager As String
        Get
            Return _manager
        End Get
        Set(value As String)
            _manager = value
        End Set
    End Property

    Public Property description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Property expCode As String
        Get
            Return _expCode
        End Get
        Set(value As String)
            _expCode = value
        End Set
    End Property

    Public Property beginDate As Date
        Get
            Return _beginDate
        End Get
        Set(value As Date)
            _beginDate = value
        End Set
    End Property

    Public Property endDate As Date
        Get
            Return _endDate
        End Get
        Set(value As Date)
            _endDate = value
        End Set
    End Property

    Public Property estimateHour As Double
        Get
            Return _estimateHours
        End Get
        Set(value As Double)
            _estimateHours = value
        End Set
    End Property

    Public Property status As Char
        Get
            Return _status
        End Get
        Set(value As Char)
            _status = value
        End Set
    End Property

    Public Property totalBilling As Double
        Get
            Return _totalBilling
        End Get
        Set(value As Double)
            _totalBilling = value
        End Set
    End Property

    Public Sub clear()
        _accountNum = 0
        _beginDate = System.DateTime.Today
        _description = ""
        _endDate = (System.DateTime.Today).AddMonths(2)
        _equipament = ""
        _estimateHours = 0
        _expCode = ""
        _idPO = 0
        _jobNum = 0
        _manager = ""
        _status = "0"
        _totalBilling = 0
    End Sub
End Class
