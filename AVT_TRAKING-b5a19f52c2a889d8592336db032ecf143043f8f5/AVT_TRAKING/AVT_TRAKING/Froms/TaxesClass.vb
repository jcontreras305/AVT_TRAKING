Public Class TaxesClass
    Dim _idTaxes, _idTaxesP, _JobNo As String
    Dim _FICA, _FUI, _SUI, _WC, _GenLiab, _Umbr, _Pollution, _Healt, _Fringe, _Small, _PPE, _Consumable, _Scaffold, _YoYos, _Mesh, _Miselaneos, _Overhead, _Profit, _TotalHours As Double
    Dim _BWForeman, _BWJourneyman, _BWCraftsman, _BWApprentice, _BWHelper As Double
    Dim _QtyForeman, _QtyJourneyman, _QtyCraftsman, _QtyApprentice, _QtyHelper As Integer

    Dim _FICAP, _FUIP, _SUIP As Double
    Dim _BWForemanP, _BWJourneymanP, _BWCraftsmanP, _BWApprenticeP, _BWHelperP, _TotalHoursP As Double
    Dim _QtyForemanP, _QtyJourneymanP, _QtyCraftsmanP, _QtyApprenticeP, _QtyHelperP As Integer
    Public Function Clear() As Boolean
        _idTaxes = ""
        _idTaxesP = ""
        _JobNo = ""
        _FICA = 0.00
        _FUI = 0.00
        _SUI = 0.00
        _WC = 0.00
        _GenLiab = 0.00
        _Umbr = 0.00
        _Pollution = 0.00
        _Healt = 0.00
        _Fringe = 0.00
        _Small = 0.00
        _PPE = 0.00
        _Consumable = 0.00
        _Scaffold = 0.00
        _YoYos = 0.00
        _Mesh = 0.00
        _Miselaneos = 0.00
        _Overhead = 0.00
        _Profit = 0.00
        _TotalHours = 0.00
        _BWForeman = 0.00
        _BWJourneyman = 0.00
        _BWCraftsman = 0.00
        _BWApprentice = 0.00
        _BWHelper = 0.00
        _QtyForeman = 0
        _QtyJourneyman = 0
        _QtyCraftsman = 0
        _QtyApprentice = 0

        _FICAP = 0.00
        _FUIP = 0.00
        _SUIP = 0.00
        _BWForemanP = 0.00
        _BWJourneymanP = 0.00
        _BWCraftsmanP = 0.00
        _BWApprenticeP = 0.00
        _BWHelperP = 0.00
        _QtyForemanP = 0
        _QtyJourneymanP = 0
        _QtyCraftsmanP = 0
        _QtyApprenticeP = 0
        Return True
    End Function
    Public Property idTaxes() As String
        Get
            If _idTaxes = Nothing Then
                Return ""
            Else
                Return _idTaxes
            End If
        End Get
        Set(ByVal idTaxes As String)
            _idTaxes = idTaxes
        End Set
    End Property
    Public Property idTaxesP() As String
        Get
            If _idTaxesP = Nothing Then
                Return ""
            Else
                Return _idTaxesP
            End If
        End Get
        Set(ByVal idTaxesP As String)
            _idTaxesP = idTaxesP
        End Set
    End Property
    Public Property JobNo() As String
        Get
            If _JobNo = Nothing Then
                Return ""
            Else
                Return _JobNo
            End If
        End Get
        Set(ByVal JobNo As String)
            _JobNo = JobNo
        End Set
    End Property
    Public Property FICA() As Double
        Get
            If _FICA = Nothing Then
                Return 0.00
            Else
                Return _FICA
            End If
        End Get
        Set(ByVal FICA As Double)
            _FICA = FICA
        End Set
    End Property
    Public Property FUI() As Double
        Get
            If _FUI = Nothing Then
                Return 0.00
            Else
                Return _FUI
            End If
        End Get
        Set(ByVal FUI As Double)
            _FUI = FUI
        End Set
    End Property
    Public Property SUI() As Double
        Get
            If _SUI = Nothing Then
                Return 0.00
            Else
                Return _SUI
            End If
        End Get
        Set(ByVal SUI As Double)
            _SUI = SUI
        End Set
    End Property
    Public Property WC() As Double
        Get
            If _WC = Nothing Then
                Return 0.00
            Else
                Return _WC
            End If
        End Get
        Set(ByVal WC As Double)
            _WC = WC
        End Set
    End Property
    Public Property GenLiab() As Double
        Get
            If _GenLiab = Nothing Then
                Return 0.00
            Else
                Return _GenLiab
            End If
        End Get
        Set(ByVal GenLiab As Double)
            _GenLiab = GenLiab
        End Set
    End Property
    Public Property Umbr() As Double
        Get
            If _Umbr = Nothing Then
                Return 0.00
            Else
                Return _Umbr
            End If
        End Get
        Set(ByVal Umbr As Double)
            _Umbr = Umbr
        End Set
    End Property
    Public Property Pollution() As Double
        Get
            If _Pollution = Nothing Then
                Return 0.00
            Else
                Return _Pollution
            End If
        End Get
        Set(ByVal Pollution As Double)
            _Pollution = Pollution
        End Set
    End Property
    Public Property Healt() As Double
        Get
            If _Healt = Nothing Then
                Return 0.00
            Else
                Return _Healt
            End If
        End Get
        Set(ByVal Healt As Double)
            _Healt = Healt
        End Set
    End Property
    Public Property Fringe() As Double
        Get
            If _Fringe = Nothing Then
                Return 0.00
            Else
                Return _Fringe
            End If
        End Get
        Set(ByVal Fringe As Double)
            _Fringe = Fringe
        End Set
    End Property
    Public Property Small() As Double
        Get
            If _Small = Nothing Then
                Return 0.00
            Else
                Return _Small
            End If
        End Get
        Set(ByVal Small As Double)
            _Small = Small
        End Set
    End Property
    Public Property PPE() As Double
        Get
            If _PPE = Nothing Then
                Return 0.00
            Else
                Return _PPE
            End If
        End Get
        Set(ByVal PPE As Double)
            _PPE = PPE
        End Set
    End Property
    Public Property Consumable() As Double
        Get
            If _Consumable = Nothing Then
                Return 0.00
            Else
                Return _Consumable
            End If
        End Get
        Set(ByVal Consumable As Double)
            _Consumable = Consumable
        End Set
    End Property
    Public Property Scaffold() As Double
        Get
            If _Scaffold = Nothing Then
                Return 0.00
            Else
                Return _Scaffold
            End If
        End Get
        Set(ByVal Scaffold As Double)
            _Scaffold = Scaffold
        End Set
    End Property
    Public Property YoYos() As Double
        Get
            If _YoYos = Nothing Then
                Return 0.00
            Else
                Return _YoYos
            End If
        End Get
        Set(ByVal YoYos As Double)
            _YoYos = YoYos
        End Set
    End Property
    Public Property Mesh() As Double
        Get
            If _Mesh = Nothing Then
                Return 0.00
            Else
                Return _Mesh
            End If
        End Get
        Set(ByVal Mesh As Double)
            _Mesh = Mesh
        End Set
    End Property
    Public Property Miselaneos() As Double
        Get
            If _Miselaneos = Nothing Then
                Return 0.00
            Else
                Return _Miselaneos
            End If
        End Get
        Set(ByVal Miselaneos As Double)
            _Miselaneos = Miselaneos
        End Set
    End Property
    Public Property Overhead() As Double
        Get
            If _Overhead = Nothing Then
                Return 0.00
            Else
                Return _Overhead
            End If
        End Get
        Set(ByVal Overhead As Double)
            _Overhead = Overhead
        End Set
    End Property

    Public Property Profit() As Double
        Get
            If _Profit = Nothing Then
                Return 0.00
            Else
                Return _Profit
            End If
        End Get
        Set(ByVal Profit As Double)
            _Profit = Profit
        End Set
    End Property

    Public Property TotalHours() As Double
        Get
            If _TotalHours = Nothing Then
                Return 0.00
            Else
                Return _TotalHours
            End If
        End Get
        Set(ByVal TotalHours As Double)
            _TotalHours = TotalHours
        End Set
    End Property
    Public Property BWForeman() As Double
        Get
            If _BWForeman = Nothing Then
                Return 0.00
            Else
                Return _BWForeman
            End If
        End Get
        Set(ByVal BWForeman As Double)
            _BWForeman = BWForeman
        End Set
    End Property
    Public Property BWJourneyman() As Double
        Get
            If _BWJourneyman = Nothing Then
                Return 0.00
            Else
                Return _BWJourneyman
            End If
        End Get
        Set(ByVal BWJourneyman As Double)
            _BWJourneyman = BWJourneyman
        End Set
    End Property
    Public Property BWCraftsman() As Double
        Get
            If _BWCraftsman = Nothing Then
                Return 0.00
            Else
                Return _BWCraftsman
            End If
        End Get
        Set(ByVal BWCraftsman As Double)
            _BWCraftsman = BWCraftsman
        End Set
    End Property
    Public Property BWApprentice() As Double
        Get
            If _BWApprentice = Nothing Then
                Return 0.00
            Else
                Return _BWApprentice
            End If
        End Get
        Set(ByVal BWApprentice As Double)
            _BWApprentice = BWApprentice
        End Set
    End Property
    Public Property BWHelper() As Double
        Get
            If _BWHelper = Nothing Then
                Return 0.00
            Else
                Return _BWHelper
            End If
        End Get
        Set(ByVal BWHelper As Double)
            _BWHelper = BWHelper
        End Set
    End Property
    Public Property QtyForeman() As Integer
        Get
            If _QtyForeman = Nothing Then
                Return 0
            Else
                Return _QtyForeman
            End If
        End Get
        Set(ByVal QtyForeman As Integer)
            _QtyForeman = QtyForeman
        End Set
    End Property
    Public Property QtyJourneyman() As Integer
        Get
            If _QtyJourneyman = Nothing Then
                Return 0
            Else
                Return _QtyJourneyman
            End If
        End Get
        Set(ByVal QtyJourneyman As Integer)
            _QtyJourneyman = QtyJourneyman
        End Set
    End Property
    Public Property QtyCraftsman() As Integer
        Get
            If _QtyCraftsman = Nothing Then
                Return 0
            Else
                Return _QtyCraftsman
            End If
        End Get
        Set(ByVal QtyCraftsman As Integer)
            _QtyCraftsman = QtyCraftsman
        End Set
    End Property
    Public Property QtyApprentice() As Integer
        Get
            If _QtyApprentice = Nothing Then
                Return 0
            Else
                Return _QtyApprentice
            End If
        End Get
        Set(ByVal QtyApprentice As Integer)
            _QtyApprentice = QtyApprentice
        End Set
    End Property
    Public Property QtyHelper() As Integer
        Get
            If _QtyHelper = Nothing Then
                Return 0
            Else
                Return _QtyHelper
            End If
        End Get
        Set(ByVal QtyHelper As Integer)
            _QtyHelper = QtyHelper
        End Set
    End Property
    Public Property FICAP() As Double
        Get
            If _FICAP = Nothing Then
                Return 0.00
            Else
                Return _FICAP
            End If
        End Get
        Set(ByVal FICAP As Double)
            _FICAP = FICAP
        End Set
    End Property
    Public Property FUIP() As Double
        Get
            If _FUIP = Nothing Then
                Return 0.00
            Else
                Return _FUIP
            End If
        End Get
        Set(ByVal FUIP As Double)
            _FUIP = FUIP
        End Set
    End Property
    Public Property SUIP() As Double
        Get
            If _SUIP = Nothing Then
                Return 0.00
            Else
                Return _SUIP
            End If
        End Get
        Set(ByVal SUIP As Double)
            _SUIP = SUIP
        End Set
    End Property
    Public Property BWForemanP() As Double
        Get
            If _BWForemanP = Nothing Then
                Return 0.00
            Else
                Return _BWForemanP
            End If
        End Get
        Set(ByVal BWForemanP As Double)
            _BWForemanP = BWForemanP
        End Set
    End Property
    Public Property BWJourneymanP() As Double
        Get
            If _BWJourneymanP = Nothing Then
                Return 0.00
            Else
                Return _BWJourneymanP
            End If
        End Get
        Set(ByVal BWJourneymanP As Double)
            _BWJourneymanP = BWJourneymanP
        End Set
    End Property
    Public Property BWCraftsmanP() As Double
        Get
            If _BWCraftsmanP = Nothing Then
                Return 0.00
            Else
                Return _BWCraftsmanP
            End If
        End Get
        Set(ByVal BWCraftsmanP As Double)
            _BWCraftsmanP = BWCraftsmanP
        End Set
    End Property
    Public Property BWApprenticeP() As Double
        Get
            If _BWApprenticeP = Nothing Then
                Return 0.00
            Else
                Return _BWApprenticeP
            End If
        End Get
        Set(ByVal BWApprenticeP As Double)
            _BWApprenticeP = BWApprenticeP
        End Set
    End Property
    Public Property BWHelperP() As Double
        Get
            If _BWHelperP = Nothing Then
                Return 0.00
            Else
                Return _BWHelperP
            End If
        End Get
        Set(ByVal BWHelperP As Double)
            _BWHelperP = BWHelperP
        End Set
    End Property
    Public Property TotalHoursP() As Double
        Get
            If _TotalHoursP = Nothing Then
                Return 0.00
            Else
                Return _TotalHoursP
            End If
        End Get
        Set(ByVal TotalHoursP As Double)
            _TotalHoursP = TotalHoursP
        End Set
    End Property
    Public Property QtyForemanP() As Integer
        Get
            If _QtyForemanP = Nothing Then
                Return 0
            Else
                Return _QtyForemanP
            End If
        End Get
        Set(ByVal QtyForemanP As Integer)
            _QtyForemanP = QtyForemanP
        End Set
    End Property
    Public Property QtyJourneymanP() As Integer
        Get
            If _QtyJourneymanP = Nothing Then
                Return 0
            Else
                Return _QtyJourneymanP
            End If
        End Get
        Set(ByVal QtyJourneymanP As Integer)
            _QtyJourneymanP = QtyJourneymanP
        End Set
    End Property
    Public Property QtyCraftsmanP() As Integer
        Get
            If _QtyCraftsmanP = Nothing Then
                Return 0
            Else
                Return _QtyCraftsmanP
            End If
        End Get
        Set(ByVal QtyCraftsmanP As Integer)
            _QtyCraftsmanP = QtyCraftsmanP
        End Set
    End Property
    Public Property QtyApprenticeP() As Integer
        Get
            If _QtyApprenticeP = Nothing Then
                Return 0
            Else
                Return _QtyApprenticeP
            End If
        End Get
        Set(ByVal QtyApprenticeP As Integer)
            _QtyApprenticeP = QtyApprenticeP
        End Set
    End Property
    Public Property QtyHelperP() As Integer
        Get
            If _QtyHelperP = Nothing Then
                Return 0
            Else
                Return _QtyHelperP
            End If
        End Get
        Set(ByVal QtyHelperP As Integer)
            _QtyHelperP = QtyHelperP
        End Set
    End Property
End Class

