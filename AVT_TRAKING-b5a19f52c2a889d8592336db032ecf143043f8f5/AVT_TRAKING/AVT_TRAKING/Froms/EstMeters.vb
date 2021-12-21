Imports System.Data.SqlClient
Public Class EstMeters
    Inherits ConnectioDB

    Dim tblScfCost As New DataTable

    Dim _FACTOR, _DECKSNUM As Integer
    Dim _idEstMeters, _EstNumber, _idEstCost As String
    Dim _PMANHRS, _TLABOR, _LDECKBP, _LABORBP, _LDECKDP, _LABORDP, _DECKMAD, _MADPRIC, _MA2DP, _MA3DP, _DECKDP, _DPRICE, _M2DP, _M2EDP, _M2MDP, _M2LDP As Decimal
    Dim _M3DP, _M3EDP, _M3MDP, _M3LDP, _EDMA2C, _EDMA3C, _EDMA2, _EDMA3, _EDM2C, _EDM3C, _EDM2, _EDM3, _TIMESED, _DA, _DECKBP, _BPRICE, _M2BP, _M2EBP As Decimal
    Dim _M2MBP, _M2LBP, _M3BP, _M3EBP, _M3MBP, _M3LBP As Decimal
    Public Sub refreshValues(ByVal estSC As EstimationSC)
        If _idEstCost <> "" Then
            estSC.SelectEstCostSC(_idEstCost, tblScfCost)
            If tblScfCost IsNot Nothing And tblScfCost.Rows.Count > 0 Then
                _M3LBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3LABORBP")) + tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3LBI"))) * (1 + _FACTOR) 'M3LBP = (M3LABORBP + M3LBI) * (1 + [HFactor])
                _M3MBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3MATBP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3MBI")).Value) ' M3MBP = (M3MATBP) + (M3MBI)
                _M3EBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3EQBP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3EBI")).Value) 'M3EBP = (M3EQBP) + (M3EBI)
                _M3BP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3LABORBP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3MATBP")).Value) + _M3EBP 'M3BP = M3LABORBP + M3MATBP + M3EBP

                _M2LBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2LABORBP")) + tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2LBI"))) * (1 + _FACTOR) 'M2LBP = (M2LABORBP + M2LBI) * (1+ [HFACTOR]) 
                _M2MBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("MA2MATBP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2MBI")).Value) 'M2MBP = MA2MATBP + M2MBI
                _M2EBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2EQBP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2EBI")).Value) 'M2EBP =  M2EQBP + M2EBI
                _M2BP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2LABORBP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2MATBP")).Value) + _M2MBP 'M2BP = M2LABORBP + M2MATBP + M2MBP ---- M2MBP ESTA ABAJO

                _BPRICE = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3"))) + (_M3BP) 'BPRICE = M3 + M3BP ---- M3BP ESTA ABAJO
                _DECKBP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2"))) * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("DECKS"))) * _M2BP 'DECKBP = M2 * DECKS * M2BP ---- M2BP ESTA ABAJO 
                _DA = estSC.daysActive 'DA = DAYSACTIVE ---- DE LA TABLA scfEstimation
                Dim EDDAYS = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("EDDAYS")))
                Dim BILLINGDAYS = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("BILLINGDAYS")))
                _TIMESED = ((_DA / EDDAYS) + 1) * ((EDDAYS - BILLINGDAYS) / EDDAYS) - (If(((_DA + EDDAYS) / EDDAYS) = ((_DA + EDDAYS) + 1) And (_DA <= BILLINGDAYS), 1, 0)) 'TIMESED = ((DA / EDDAYS)+1)*EDDAYS-BILLINGDAYS/EDDAYS- IF{[((DA + EDDAYS) / EDDAYS)= (DA/EDDAYS)+1] AND [DA <= BILLINGDAYS], 1,0} ---- DA ESTA ABAJO

                _EDM3 = _TIMESED * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3EDCHARGES")))  'EDM3 = TIMESED * M3EDCHARGES ----TIMESED ESTA ABAJO
                _EDM2 = _TIMESED * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2EDCHARGES"))) 'EDM2 = TIMESED * M2EDCHARGES ----TIMESED ESTA ABAJO
                _EDM3C = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3"))) * _EDM3 'EDM3C = EDM3 * M3 ---- EDM3 ESTA ABAJO 
                _EDM2C = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2"))) * _EDM2  'EDM2C = EDM2 * M2 ---- EDM2 ESTA ABAJO
                _EDMA3 = _TIMESED * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3EDCHARGES"))) 'EDMA3 = TIMESED * M3EDCHARGES ---- TIMESED ESTA ABAJO
                _EDMA2 = _TIMESED * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2EDCHARGES"))) 'EDMA2 = TIMESED * M2EDCHARGES ---- TIMESED ESTA ABAJO
                _EDMA3C = _EDMA3 * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3"))) 'EDMA3C = EDMA3 * M3 ---- EDMA3 ESTA ABAJO
                _EDMA2C = _EDMA2 * (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2"))) 'EDMA2C = EDMA2 * M2 ---- EDMA2 ESTA ABAJO

                _M3LDP = ((tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3LABORDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3LDI")))) * (1 + _FACTOR) 'M3LDP = (M3LABORDP + M3LDI) * (1 + [HFACTOR])
                _M3MDP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3MDI"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3MATDP"))) 'M3MDP = M3MDI + M3MATDP
                _M3EDP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3EQDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3EDI"))) 'M3EDP = M3EQDP + M3EDI
                _M3DP = _M3LDP + _M3MDP + _M3EDP 'M3DP = M3LDP + M3MDP + M3EDP ---- M3LDP, M3MDP, M3EDP ESTAN ABAJO

                _M2LDP = ((tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2LABORDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2LDI")))) * (1 + _FACTOR) 'M2LDP = (M2LABORDP + M2LDI)*(1 + [HFACTOR])
                _M2MDP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2MATDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2MDI"))) 'M2MDP = M2MATDP + M2MDI
                _M2EDP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2EQDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2EDI"))) 'M2EDP = M2EQDP + M2EDI
                _M2DP = _M2LDP + _M2MDP + _M2EDP 'M2DP = M2LDP + M2MDP + M2EDP ---- M2LDP, M2MDP, M2EDP ESTAN ABAJO

                _DPRICE = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M3"))) * _M3DP 'DPRICE = M3 * M3DP ---- M3DP ESTA ABAJO
                _DECKDP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2"))) * estSC.descks * _M2DP 'DECKDP = M2 * DECKS * M2DP ---- M2DP ESTA ABAJO
                _MA3DP = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("M2LABORDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("MA3MATDP"))) + (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf("MA3EQDP")))  'MA3DP = MA3LABORDP + MA3MATDP + MA3EQDP
                _MA2DP = 0
                _MADPRIC = 0
                _DECKMAD = 0
                _LABORDP = 0
                _LDECKDP = 0
                _LABORBP = 0
                _LDECKBP = 0
                _TLABOR = 0
                _PMANHRS = 0
            End If
        Else
            MsgBox("Select a type Estimation Cost please.")
        End If
    End Sub

    Public Function Clear() As Boolean
        Try
            _idEstMeters = ""
            _EstNumber = ""
            _DECKSNUM = 0
            _FACTOR = 0
            _PMANHRS = 0
            _TLABOR = 0
            _LDECKBP = 0
            _LABORBP = 0
            _LDECKDP = 0
            _LABORDP = 0
            _DECKMAD = 0
            _MADPRIC = 0
            _MA2DP = 0
            _MA3DP = 0
            _DECKDP = 0
            _DPRICE = 0
            _M2DP = 0
            _M2EDP = 0
            _M2MDP = 0
            _M2LDP = 0
            _M3DP = 0
            _M3EDP = 0
            _M3MDP = 0
            _M3LDP = 0
            _EDMA2C = 0
            _EDMA3C = 0
            _EDMA2 = 0
            _EDMA3 = 0
            _EDM2C = 0
            _EDM3C = 0
            _EDM2 = 0
            _EDM3 = 0
            _TIMESED = 0
            _DA = 0
            _DECKBP = 0
            _BPRICE = 0
            _M2BP = 0
            _M2EBP = 0
            _M2MBP = 0
            _M2LBP = 0
            _M3BP = 0
            _M3EBP = 0
            _M3MBP = 0
            _M3LBP = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Property DECKSNUM() As Integer
        Get
            If _DECKSNUM = Nothing Then
                Return 0
            Else
                Return _DECKSNUM
            End If
        End Get
        Set(ByVal DECKSNUM As Integer)
            _DECKSNUM = DECKSNUM
        End Set
    End Property
    Public Property FACTOR() As Integer
        Get
            If _FACTOR = Nothing Then
                Return 0
            Else
                Return _FACTOR
            End If
        End Get
        Set(ByVal FACTOR As Integer)
            _FACTOR = FACTOR
        End Set
    End Property
    Public Property idEstMeters() As String
        Get
            If _idEstMeters = Nothing Then
                Return ""
            Else
                Return _idEstMeters
            End If
        End Get
        Set(ByVal idEstMeters As String)
            _idEstMeters = idEstMeters
        End Set
    End Property
    Public Property EstNumber() As String
        Get
            If _EstNumber = Nothing Then
                Return ""
            Else
                Return _EstNumber
            End If
        End Get
        Set(ByVal EstNumber As String)
            _EstNumber = EstNumber
        End Set
    End Property
    Public Property idEstCost() As String
        Get
            If _idEstCost = Nothing Then
                Return ""
            Else
                Return _idEstCost
            End If
        End Get
        Set(ByVal idEstCost As String)
            _idEstCost = idEstCost
        End Set
    End Property
    Public Property PMANHRS() As Decimal
        Get
            If _PMANHRS = Nothing Then
                Return 0
            Else
                Return _PMANHRS
            End If
        End Get
        Set(ByVal PMANHRS As Decimal)
            _PMANHRS = PMANHRS
        End Set
    End Property
    Public Property TLABOR() As Decimal
        Get
            If _TLABOR = Nothing Then
                Return 0
            Else
                Return _TLABOR
            End If
        End Get
        Set(ByVal TLABOR As Decimal)
            _TLABOR = TLABOR
        End Set
    End Property
    Public Property LDECKBP() As Decimal
        Get
            If _LDECKBP = Nothing Then
                Return 0
            Else
                Return _LDECKBP
            End If
        End Get
        Set(ByVal LDECKBP As Decimal)
            _LDECKBP = LDECKBP
        End Set
    End Property
    Public Property LABORBP() As Decimal
        Get
            If _LABORBP = Nothing Then
                Return 0
            Else
                Return _LABORBP
            End If
        End Get
        Set(ByVal LABORBP As Decimal)
            _LABORBP = LABORBP
        End Set
    End Property
    Public Property LDECKDP() As Decimal
        Get
            If _LDECKDP = Nothing Then
                Return 0
            Else
                Return _LDECKDP
            End If
        End Get
        Set(ByVal LDECKDP As Decimal)
            _LDECKDP = LDECKDP
        End Set
    End Property
    Public Property LABORDP() As Decimal
        Get
            If _LABORDP = Nothing Then
                Return 0
            Else
                Return _LABORDP
            End If
        End Get
        Set(ByVal LABORDP As Decimal)
            _LABORDP = LABORDP
        End Set
    End Property
    Public Property DECKMAD() As Decimal
        Get
            If _DECKMAD = Nothing Then
                Return 0
            Else
                Return _DECKMAD
            End If
        End Get
        Set(ByVal DECKMAD As Decimal)
            _DECKMAD = DECKMAD
        End Set
    End Property
    Public Property MADPRIC() As Decimal
        Get
            If _MADPRIC = Nothing Then
                Return 0
            Else
                Return _MADPRIC
            End If
        End Get
        Set(ByVal MADPRIC As Decimal)
            _MADPRIC = MADPRIC
        End Set
    End Property
    Public Property MA2DP() As Decimal
        Get
            If _MA2DP = Nothing Then
                Return 0
            Else
                Return _MA2DP
            End If
        End Get
        Set(ByVal MA2DP As Decimal)
            _MA2DP = MA3DP
        End Set
    End Property
    Public Property MA3DP() As Decimal
        Get
            If _MA3DP = Nothing Then
                Return 0
            Else
                Return _MA3DP
            End If
        End Get
        Set(ByVal MA3DP As Decimal)
            _MA3DP = MA3DP
        End Set
    End Property
    Public Property DECKDP() As Decimal
        Get
            If _DECKDP = Nothing Then
                Return 0
            Else
                Return _DECKDP
            End If
        End Get
        Set(ByVal DECKDP As Decimal)
            _DECKDP = DECKDP
        End Set
    End Property
    Public Property DPRICE() As Decimal
        Get
            If _DPRICE = Nothing Then
                Return 0
            Else
                Return _DPRICE
            End If
        End Get
        Set(ByVal DPRICE As Decimal)
            _DPRICE = DPRICE
        End Set
    End Property
    Public Property M2DP() As Decimal
        Get
            If _M2DP = Nothing Then
                Return 0
            Else
                Return _M2DP
            End If
        End Get
        Set(ByVal M2DP As Decimal)
            _M2DP = M2DP
        End Set
    End Property
    Public Property M2EDP() As Decimal
        Get
            If _M2EDP = Nothing Then
                Return 0
            Else
                Return _M2EDP
            End If
        End Get
        Set(ByVal M2EDP As Decimal)
            _M2EDP = M2EDP
        End Set
    End Property
    Public Property M2MDP() As Decimal
        Get
            If _M2MDP = Nothing Then
                Return 0
            Else
                Return _M2MDP
            End If
        End Get
        Set(ByVal M2MDP As Decimal)
            _M2MDP = M2MDP
        End Set
    End Property
    Public Property M2LDP() As Decimal
        Get
            If _M2LDP = Nothing Then
                Return 0
            Else
                Return _M2LDP
            End If
        End Get
        Set(ByVal M2LDP As Decimal)
            _M2LDP = M2LDP
        End Set
    End Property
    Public Property M3DP() As Decimal
        Get
            If _M3DP = Nothing Then
                Return 0
            Else
                Return _M3DP
            End If
        End Get
        Set(ByVal M3DP As Decimal)
            _M3DP = M3DP
        End Set
    End Property
    Public Property M3EDP() As Decimal
        Get
            If _M3EDP = Nothing Then
                Return 0
            Else
                Return _M3EDP
            End If
        End Get
        Set(ByVal M3EDP As Decimal)
            _M3EDP = M3EDP
        End Set
    End Property
    Public Property M3MDP() As Decimal
        Get
            If _M3MDP = Nothing Then
                Return 0
            Else
                Return _M3MDP
            End If
        End Get
        Set(ByVal M3MDP As Decimal)
            _M3MDP = M3MDP
        End Set
    End Property
    Public Property M3LDP() As Decimal
        Get
            If _M3LDP = Nothing Then
                Return 0
            Else
                Return _M3LDP
            End If
        End Get
        Set(ByVal M3LDP As Decimal)
            _M3LDP = M3LDP
        End Set
    End Property
    Public Property EDMA2C() As Decimal
        Get
            If _EDMA2C = Nothing Then
                Return 0
            Else
                Return _EDMA2C
            End If
        End Get
        Set(ByVal EDMA2C As Decimal)
            _EDMA2C = EDMA2C
        End Set
    End Property
    Public Property EDMA3C() As Decimal
        Get
            If _EDMA3C = Nothing Then
                Return 0
            Else
                Return _EDMA3C
            End If
        End Get
        Set(ByVal EDMA3C As Decimal)
            _EDMA3C = EDMA3C
        End Set
    End Property
    Public Property EDMA2() As Decimal
        Get
            If _EDMA2 = Nothing Then
                Return 0
            Else
                Return _EDMA2
            End If
        End Get
        Set(ByVal EDMA2 As Decimal)
            _EDMA2 = EDMA2
        End Set
    End Property
    Public Property EDMA3() As Decimal
        Get
            If _EDMA3 = Nothing Then
                Return 0
            Else
                Return _EDMA3
            End If
        End Get
        Set(ByVal EDMA3 As Decimal)
            _EDMA3 = EDMA3
        End Set
    End Property
    Public Property EDM2C() As Decimal
        Get
            If _EDM2C = Nothing Then
                Return 0
            Else
                Return _EDM2C
            End If
        End Get
        Set(ByVal EDM2C As Decimal)
            _EDM2C = EDM2C
        End Set
    End Property
    Public Property EDM3C() As Decimal
        Get
            If _EDM3C = Nothing Then
                Return 0
            Else
                Return _EDM3C
            End If
        End Get
        Set(ByVal EDM3C As Decimal)
            _EDM3C = EDM3C
        End Set
    End Property
    Public Property EDM2() As Decimal
        Get
            If _EDM2 = Nothing Then
                Return 0
            Else
                Return _EDM2
            End If
        End Get
        Set(ByVal EDM2 As Decimal)
            _EDM2 = EDM2
        End Set
    End Property
    Public Property EDM3() As Decimal
        Get
            If _EDM3 = Nothing Then
                Return 0
            Else
                Return _EDM3
            End If
        End Get
        Set(ByVal EDM3 As Decimal)
            _EDM3 = EDM3
        End Set
    End Property
    Public Property TIMESED() As Decimal
        Get
            If _TIMESED = Nothing Then
                Return 0
            Else
                Return _TIMESED
            End If
        End Get
        Set(ByVal TIMESED As Decimal)
            _TIMESED = TIMESED
        End Set
    End Property
    Public Property DA() As Decimal
        Get
            If _DA = Nothing Then
                Return 0
            Else
                Return _DA
            End If
        End Get
        Set(ByVal DA As Decimal)
            _DA = DA
        End Set
    End Property
    Public Property DECKBP() As Decimal
        Get
            If _DECKBP = Nothing Then
                Return 0
            Else
                Return _DECKBP
            End If
        End Get
        Set(ByVal DECKBP As Decimal)
            _DECKBP = DECKBP
        End Set
    End Property
    Public Property BPRICE() As Decimal
        Get
            If _BPRICE = Nothing Then
                Return 0
            Else
                Return _BPRICE
            End If
        End Get
        Set(ByVal BPRICE As Decimal)
            _BPRICE = BPRICE
        End Set
    End Property
    Public Property M2BP() As Decimal
        Get
            If _M2BP = Nothing Then
                Return 0
            Else
                Return _M2BP
            End If
        End Get
        Set(ByVal M2BP As Decimal)
            _M2BP = M2BP
        End Set
    End Property
    Public Property M2EBP() As Decimal
        Get
            If _M2EBP = Nothing Then
                Return 0
            Else
                Return _M2EBP
            End If
        End Get
        Set(ByVal M2EBP As Decimal)
            _M2EBP = M2EBP
        End Set
    End Property
    Public Property M2MBP() As Decimal
        Get
            If _M2MBP = Nothing Then
                Return 0
            Else
                Return _M2MBP
            End If
        End Get
        Set(ByVal M2MBP As Decimal)
            _M2MBP = M2MBP
        End Set
    End Property
    Public Property M2LBP() As Decimal
        Get
            If _M2LBP = Nothing Then
                Return 0
            Else
                Return _M2LBP
            End If
        End Get
        Set(ByVal M2LBP As Decimal)
            _M2LBP = M2LBP
        End Set
    End Property
    Public Property M3BP() As Decimal
        Get
            If _M3BP = Nothing Then
                Return 0
            Else
                Return _M3BP
            End If
        End Get
        Set(ByVal M3BP As Decimal)
            _M3BP = M3BP
        End Set
    End Property

    Public Property M3EBP() As Decimal
        Get
            If _M3EBP = Nothing Then
                Return 0
            Else
                Return _M3EBP
            End If
        End Get
        Set(ByVal M3EBP As Decimal)
            _M3EBP = M3EBP
        End Set
    End Property
    Public Property M3MBP() As Decimal
        Get
            If _M3MBP = Nothing Then
                Return 0
            Else
                Return _M3MBP
            End If
        End Get
        Set(ByVal M3MBP As Decimal)
            _M3MBP = M3MBP
        End Set
    End Property
    Public Property M3LBP() As Decimal
        Get
            If _M3LBP = Nothing Then
                Return 0
            Else
                Return _M3LBP
            End If
        End Get
        Set(ByVal M3LBP As Decimal)
            _M3LBP = M3LBP
        End Set
    End Property










End Class
