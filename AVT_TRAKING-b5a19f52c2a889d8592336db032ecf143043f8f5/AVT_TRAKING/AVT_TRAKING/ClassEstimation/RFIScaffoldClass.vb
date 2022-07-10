Public Class RFIScaffoldClass
    Private _tag As String
    Private _idDrawingNum As String
    Private _idRFI As String
    Private _newIdLaborRate As String
    Private _newIdSCFUR As String
    Private _lastIdLaborRate As String
    Private _lastIdSCFUR As String
    Private _reqEmployee As String
    Private _reqTitleEmployee As String
    Private _reqCompany As String
    Private _chUpEmployee As String
    Private _chUpTitleEmployee As String
    Private _note As String
    Private _newDays As Decimal
    Private _newWith As Decimal
    Private _newLength As Decimal
    Private _newHeigth As Decimal
    Private _newBuild As Decimal
    Private _newDecks As Decimal
    Private _lastDays As Decimal
    Private _lastWith As Decimal
    Private _lastLength As Decimal
    Private _lastHeigth As Decimal
    Private _lastBuild As Decimal
    Private _lastDecks As Decimal
    Private _basicFCR As Decimal
    Private _reqDate As Date
    Private _chUpDate As Date
    Private _weDate As Date
    Public Function Clear() As Integer
        Try
            _tag = ""
            _idDrawingNum = ""
            _idRFI = ""
            _newIdLaborRate = ""
            _newIdSCFUR = ""
            _lastIdLaborRate = ""
            _lastIdSCFUR = ""
            _reqEmployee = ""
            _reqTitleEmployee = ""
            _reqCompany = ""
            _chUpEmployee = ""
            _chUpTitleEmployee = ""
            _note = ""
            _newDays = 0
            _newWith = 0
            _newLength = 0
            _newHeigth = 0
            _newBuild = 0
            _newDecks = 0
            _lastDays = 0
            _lastWith = 0
            _lastLength = 0
            _lastHeigth = 0
            _lastBuild = 0
            _lastDecks = 0
            _basicFCR = 0
            _reqDate = Today.Date
            _chUpDate = Today.Date
            _weDate = Today.Date
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Property idTag() As String
        Get
            If _tag = Nothing Then
                _tag = ""
            End If
            Return _tag
        End Get
        Set(ByVal value As String)
            _tag = value
        End Set
    End Property
    Public Property idDrawingNum() As String
        Get
            If _idDrawingNum = Nothing Then
                _idDrawingNum = ""
            End If
            Return _idDrawingNum
        End Get
        Set(ByVal value As String)
            _idDrawingNum = value
        End Set
    End Property
    Public Property idRFI() As String
        Get
            If _idRFI = Nothing Then
                _idRFI = ""
            End If
            Return _idRFI
        End Get
        Set(ByVal value As String)
            _idRFI = value
        End Set
    End Property
    Public Property newIdLaborRate() As String
        Get
            If _newIdLaborRate = Nothing Then
                _newIdLaborRate = ""
            End If
            Return _newIdLaborRate
        End Get
        Set(ByVal value As String)
            _newIdLaborRate = value
        End Set
    End Property
    Public Property newIdSCFUR() As String
        Get
            If _newIdSCFUR = Nothing Then
                _newIdSCFUR = ""
            End If
            Return _newIdSCFUR
        End Get
        Set(ByVal value As String)
            _newIdSCFUR = value
        End Set
    End Property
    Public Property lastIdLaborRate() As String
        Get
            If _lastIdLaborRate = Nothing Then
                _lastIdLaborRate = ""
            End If
            Return _lastIdLaborRate
        End Get
        Set(ByVal value As String)
            _lastIdLaborRate = value
        End Set
    End Property
    Public Property lastIdSCFUR() As String
        Get
            If _lastIdSCFUR = Nothing Then
                _lastIdSCFUR = ""
            End If
            Return _lastIdSCFUR
        End Get
        Set(ByVal value As String)
            _lastIdSCFUR = value
        End Set
    End Property
    Public Property reqEmployee() As String
        Get
            If _reqEmployee = Nothing Then
                _reqEmployee = ""
            End If
            Return _reqEmployee
        End Get
        Set(ByVal value As String)
            _reqEmployee = value
        End Set
    End Property
    Public Property reqTitleEmployee() As String
        Get
            If _reqTitleEmployee = Nothing Then
                _reqTitleEmployee = ""
            End If
            Return _reqTitleEmployee
        End Get
        Set(ByVal value As String)
            _reqTitleEmployee = value
        End Set
    End Property
    Public Property reqCompany() As String
        Get
            If _reqCompany = Nothing Then
                _reqCompany = ""
            End If
            Return _reqCompany
        End Get
        Set(ByVal value As String)
            _reqCompany = value
        End Set
    End Property
    Public Property chUpEmployee() As String
        Get
            If _chUpEmployee = Nothing Then
                _chUpEmployee = ""
            End If
            Return _chUpEmployee
        End Get
        Set(ByVal value As String)
            _chUpEmployee = value
        End Set
    End Property
    Public Property chUpTitleEmployee() As String
        Get
            If _chUpTitleEmployee = Nothing Then
                _chUpTitleEmployee = ""
            End If
            Return _chUpTitleEmployee
        End Get
        Set(ByVal value As String)
            _chUpTitleEmployee = value
        End Set
    End Property
    Public Property note() As String
        Get
            If _note = Nothing Then
                _note = ""
            End If
            Return _note
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property
    Public Property newDays() As String
        Get
            If _newDays = Nothing Then
                _newDays = 0
            End If
            Return _newDays
        End Get
        Set(ByVal value As String)
            _newDays = value
        End Set
    End Property
    Public Property newWith() As String
        Get
            If _newWith = Nothing Then
                _newWith = 0
            End If
            Return _newWith
        End Get
        Set(ByVal value As String)
            _newWith = value
        End Set
    End Property
    Public Property newLength() As String
        Get
            If _newLength = Nothing Then
                _newLength = 0
            End If
            Return _newLength
        End Get
        Set(ByVal value As String)
            _newLength = value
        End Set
    End Property
    Public Property newHeigth() As String
        Get
            If _newHeigth = Nothing Then
                _newHeigth = 0
            End If
            Return _newHeigth
        End Get
        Set(ByVal value As String)
            _newHeigth = value
        End Set
    End Property
    Public Property newBuild() As String
        Get
            If _newBuild = Nothing Then
                _newBuild = 0
            End If
            Return _newBuild
        End Get
        Set(ByVal value As String)
            _newBuild = value
        End Set
    End Property
    Public Property newDecks() As String
        Get
            If _newDecks = Nothing Then
                _newDecks = 0
            End If
            Return _newDecks
        End Get
        Set(ByVal value As String)
            _newDecks = value
        End Set
    End Property
    Public Property lastDays() As String
        Get
            If _lastDays = Nothing Then
                _lastDays = 0
            End If
            Return _lastDays
        End Get
        Set(ByVal value As String)
            _lastDays = value
        End Set
    End Property
    Public Property lastWith() As String
        Get
            If _lastWith = Nothing Then
                _lastWith = 0
            End If
            Return _lastWith
        End Get
        Set(ByVal value As String)
            _lastWith = value
        End Set
    End Property
    Public Property lastLength() As String
        Get
            If _lastLength = Nothing Then
                _lastLength = 0
            End If
            Return _lastLength
        End Get
        Set(ByVal value As String)
            _lastLength = value
        End Set
    End Property
    Public Property lastHeigth() As String
        Get
            If _lastHeigth = Nothing Then
                _lastHeigth = 0
            End If
            Return _lastHeigth
        End Get
        Set(ByVal value As String)
            _lastHeigth = value
        End Set
    End Property
    Public Property lastBuild() As String
        Get
            If _lastBuild = Nothing Then
                _lastBuild = 0
            End If
            Return _lastBuild
        End Get
        Set(ByVal value As String)
            _lastBuild = value
        End Set
    End Property
    Public Property lastDecks() As String
        Get
            If _lastDecks = Nothing Then
                _lastDecks = 0
            End If
            Return _lastDecks
        End Get
        Set(ByVal value As String)
            _lastDecks = value
        End Set
    End Property
    Public Property basicFCRlastBuild() As String
        Get
            If _basicFCR = Nothing Then
                _basicFCR = 0
            End If
            Return _basicFCR
        End Get
        Set(ByVal value As String)
            _basicFCR = value
        End Set
    End Property

    Public Property reqDate() As Date
        Get
            If _reqDate = Nothing Then
                _reqDate = Today.Date
            End If
            Return _reqDate
        End Get
        Set(ByVal value As Date)
            _reqDate = value
        End Set
    End Property
    Public Property chUpDate() As Date
        Get
            If _chUpDate = Nothing Then
                _chUpDate = Today.Date
            End If
            Return _chUpDate
        End Get
        Set(ByVal value As Date)
            _chUpDate = value
        End Set
    End Property

    Public Property weDate() As Date
        Get
            If _weDate = Nothing Then
                _weDate = Today.Date
            End If
            Return _weDate
        End Get
        Set(ByVal value As Date)
            _weDate = value
        End Set
    End Property

End Class
