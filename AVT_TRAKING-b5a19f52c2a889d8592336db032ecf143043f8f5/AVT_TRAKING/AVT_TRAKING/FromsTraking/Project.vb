Public Class Project
    Private _jobNum As Long
    Private _accountNum, _equipament, _manager, _description, _expCode, _idWO, _idAuxWO, _idPO, _idAux, _idTask, _Line, _WBS, _Area, _postingProject, _phase, _Taxes As String
    Private _beginDate, _endDate As Date
    Private _estimateHours, _totalBilling, _PercentComplete As Double
    Private _status As Char

    Public Property Taxes() As String
        Get
            If _Taxes Is Nothing Then
                _Taxes = "0"
            End If
            Return _Taxes
        End Get
        Set(ByVal value As String)
            _Taxes = value
        End Set
    End Property
    Public Property Phase() As String
        Get
            If _phase Is Nothing Then
                _phase = ""
            End If
            Return _phase
        End Get
        Set(ByVal value As String)
            _phase = value
        End Set
    End Property
    Public Property idAux() As String
        Get
            Return _idAux
        End Get
        Set(ByVal value As String)
            _idAux = value
        End Set
    End Property

    Public Property idAuxWO() As String
        Get
            Return _idAuxWO
        End Get
        Set(ByVal value As String)
            _idAuxWO = value
        End Set
    End Property
    Public Property idPO As String
        Get
            Return _idPO
        End Get
        Set(value As String)
            _idPO = value
        End Set
    End Property

    Public Property accountNum As String
        Get
            Return _accountNum
        End Get
        Set(value As String)
            _accountNum = value
        End Set
    End Property

    Public Property jobNum As Long
        Get
            Return _jobNum
        End Get
        Set(value As Long)
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

    Public Property Line() As String
        Get
            Return _Line
        End Get
        Set(ByVal value As String)
            _Line = value
        End Set
    End Property

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property
    Public Property WBS() As String
        Get
            Return _WBS
        End Get
        Set(ByVal value As String)
            _WBS = value
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

    Public Property PercentComplete() As Double
        Get
            If _PercentComplete <> Nothing Then
                Return _PercentComplete
            Else
                Return 0
            End If
        End Get
        Set(ByVal PercentComplete As Double)
            _PercentComplete = PercentComplete
        End Set
    End Property

    Public Property idWorkOrder() As String
        Get
            Return _idWO
        End Get
        Set(ByVal value As String)
            _idWO = value
        End Set
    End Property

    Public Property idTask() As String
        Get
            Return _idTask
        End Get
        Set(ByVal value As String)
            _idTask = value
        End Set
    End Property

    Public Property postingProject() As String
        Get
            Return _postingProject
        End Get
        Set(ByVal value As String)
            _postingProject = value
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
        _idWO = ""
        _idTask = ""
        _idAuxWO = ""
        _WBS = ""
        _Area = ""
        _postingProject = ""
        _phase = ""
    End Sub
End Class
