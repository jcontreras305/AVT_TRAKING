Imports System.Data.SqlClient
Imports System.Math
Public Class EstMeters
    Inherits ConnectioDB

    Dim tblScfCost As New DataTable

    Dim _FACTOR, _DECKSNUM As Integer
    Dim _idEstMeters, _EstNumber, _idEstCost As String
    Dim _PMANHRS, _TLABOR, _LDECKBP, _LABORBP, _LDECKDP, _LABORDP, _DECKMAD, _MADPRICE, _MA2DP, _MA3DP, _DECKDP, _DPRICE, _M2DP, _M2EDP, _M2MDP, _M2LDP As Decimal
    Dim _M3DP, _M3EDP, _M3MDP, _M3LDP, _EDMA2C, _EDMA3C, _EDMA2, _EDMA3, _EDM2C, _EDM3C, _EDM2, _EDM3, _TIMESED, _DA, _DECKBP, _BPRICE, _M2BP, _M2EBP As Decimal
    Dim _M2MBP, _M2LBP, _M3BP, _M3EBP, _M3MBP, _M3LBP As Decimal
    Public Sub refreshValues(ByVal estSC As EstimationSC)
        If _idEstCost <> "" Then
            estSC.SelectEstCostSC(_idEstCost, tblScfCost)
            If tblScfCost IsNot Nothing And tblScfCost.Rows.Count > 0 Then
                M3LBP = Math.Round((findVal("M3LABORBP")) + findVal("M3LBI") * (1 + FACTOR), 2, MidpointRounding.AwayFromZero) * FACTOR 'M3LBP = (M3LABORBP + M3LBI) * (1 + [HFactor]) * 1
                M3MBP = (findVal("M3MATBP")) + (findVal("M3MBI")) ' M3MBP = (M3MATBP) + (M3MBI)
                M3EBP = (findVal("M3EQBP")) + (findVal("M3EBI")) 'M3EBP = (M3EQBP) + (M3EBI)
                M3BP = (findVal("M3LABORBP")) + (findVal("M3MATBP")) + M3EBP 'M3BP = M3LABORBP + M3MATBP + M3EBP

                M2LBP = Math.Round((findVal("M2LABORBP")) + findVal("M2LBI") * (1 + FACTOR), 2, MidpointRounding.AwayFromZero) * FACTOR 'M2LBP = (M2LABORBP + M2LBI) * (1+ [HFACTOR]) * 1
                M2MBP = (findVal("MA2MATBP")) + (findVal("M2MBI")) 'M2MBP = MA2MATBP + M2MBI
                M2EBP = (findVal("M2EQBP")) + (findVal("M2EBI")) 'M2EBP =  M2EQBP + M2EBI
                M2BP = (findVal("M2LABORBP")) + (findVal("M2MATBP")) + M2MBP 'M2BP = M2LABORBP + M2MATBP + M2MBP ---- M2MBP ESTA ABAJO

                BPRICE = Math.Round((findVal("M3")) + (M3BP), 2, MidpointRounding.AwayFromZero) * FACTOR 'BPRICE = M3 + M3BP * 1  ---- M3BP ESTA ABAJO 
                DECKBP = Math.Round((findVal("M2")) * (findVal("DECKS")) * M2BP, 2, MidpointRounding.AwayFromZero) * FACTOR    'DECKBP = M2 * DECKS * M2BP * 1---- M2BP ESTA ABAJO 
                DA = estSC.daysActive 'DA = DAYSACTIVE ---- DE LA TABLA scfEstimation
                Dim EDDAYS = (findVal("EDDAYS"))
                Dim BILLINGDAYS = (findVal("BILLINGDAYS"))
                If EDDAYS > 0 Then
                    TIMESED = ((DA / EDDAYS) + 1) * ((EDDAYS - BILLINGDAYS) / EDDAYS) - (If(((DA + EDDAYS) / EDDAYS) = ((DA + EDDAYS) + 1) And (DA <= BILLINGDAYS), 1, 0)) 'TIMESED = ((DA / EDDAYS)+1)*EDDAYS-BILLINGDAYS/EDDAYS- IF{[((DA + EDDAYS) / EDDAYS)= (DA/EDDAYS)+1] AND [DA <= BILLINGDAYS], 1,0} ---- DA ESTA ABAJO
                Else
                    TIMESED = 0
                End If
                EDM3 = Math.Round(TIMESED * (findVal("M3EDCHARGES")), 2, MidpointRounding.AwayFromZero) * FACTOR 'EDM3 = TIMESED * M3EDCHARGES * 1 ----TIMESED ESTA ABAJO
                EDM2 = Math.Round(TIMESED * (findVal("M2EDCHARGES")), 2, MidpointRounding.AwayFromZero) * FACTOR 'EDM2 = TIMESED * M2EDCHARGES * 1 ----TIMESED ESTA ABAJO
                EDM3C = Math.Round((findVal("M3")) * EDM3, 2, MidpointRounding.AwayFromZero) * FACTOR 'EDM3C = EDM3 * M3 * 1 ---- EDM3 ESTA ABAJO 
                EDM2C = Math.Round((findVal("M2")) * EDM2, 2, MidpointRounding.AwayFromZero) * FACTOR 'EDM2C = EDM2 * M2 * 1 ---- EDM2 ESTA ABAJO
                EDMA3 = Math.Round(TIMESED * (findVal("M3EDCHARGES")), 2, MidpointRounding.AwayFromZero) * FACTOR 'EDMA3 = TIMESED * M3EDCHARGES * 1 ---- TIMESED ESTA ABAJO
                EDMA2 = Math.Round(TIMESED * (findVal("M2EDCHARGES")), 2, MidpointRounding.AwayFromZero) * FACTOR 'EDMA2 = TIMESED * M2EDCHARGES * 1 ---- TIMESED ESTA ABAJO
                EDMA3C = Math.Round(EDMA3 * (findVal("M3")), 2, MidpointRounding.AwayFromZero) * FACTOR 'EDMA3C = EDMA3 * M3 * 1 ---- EDMA3 ESTA ABAJO
                EDMA2C = Math.Round(EDMA2 * (findVal("M2")), 2, MidpointRounding.AwayFromZero) * FACTOR 'EDMA2C = EDMA2 * M2 * 1---- EDMA2 ESTA ABAJO

                M3LDP = Math.Round((findVal("M3LABORDP")) + (findVal("M3LDI")) * (1 + FACTOR), 2, MidpointRounding.AwayFromZero) * FACTOR 'M3LDP = (M3LABORDP + M3LDI) * (1 + [HFACTOR]) * 1
                M3MDP = (findVal("M3MDI")) + (findVal("M3MATDP")) 'M3MDP = M3MDI + M3MATDP
                M3EDP = (findVal("M3EQDP")) + (findVal("M3EDI")) 'M3EDP = M3EQDP + M3EDI
                M3DP = M3LDP + M3MDP + M3EDP 'M3DP = M3LDP + M3MDP + M3EDP ---- M3LDP, M3MDP, M3EDP ESTAN ABAJO

                M2LDP = Math.Round((findVal("M2LABORDP")) + (findVal("M2LDI")) * (1 + FACTOR), 2, MidpointRounding.AwayFromZero) * FACTOR 'M2LDP = (M2LABORDP + M2LDI)*(1 + [HFACTOR]) * 1 
                M2MDP = (findVal("M2MATDP")) + (findVal("M2MDI")) 'M2MDP = M2MATDP + M2MDI
                M2EDP = (findVal("M2EQDP")) + (findVal("M2EDI")) 'M2EDP = M2EQDP + M2EDI
                M2DP = M2LDP + M2MDP + M2EDP 'M2DP = M2LDP + M2MDP + M2EDP ---- M2LDP, M2MDP, M2EDP ESTAN ABAJO
                Dim M3 = (findVal("M3"))
                Dim M2 = (findVal("M2"))
                DPRICE = Math.Round((M3 * M3DP), 2) * FACTOR 'DPRICE = M3 * M3DP * 1 ---- M3DP ESTA ABAJO
                DECKDP = Math.Round(M2 * estSC.descks * M2DP, 2, MidpointRounding.AwayFromZero) * FACTOR 'DECKDP = M2 * DECKS * M2DP * 1 ---- M2DP ESTA ABAJO
                MA3DP = (findVal("M2LABORDP")) + (findVal("MA3MATDP")) + (findVal("MA3EQDP"))  'MA3DP = MA3LABORDP + MA3MATDP + MA3EQDP
                MA2DP = (findVal("MA2LABORDP")) + (findVal("MA2MATDP")) + (findVal("MA2EQDP")) 'MA2DP = MA2LABORDP + MA2MATDP + MA2EQDP
                MADPRICE = Math.Round(M3 * MA3DP, 2, MidpointRounding.AwayFromZero) * FACTOR 'MADPRICE = MA3 * MA3DP * 1 ---- MA3DP ESTA ABAJO
                DECKMAD = Math.Round(M3 * estSC.descks * MA2DP, 2, MidpointRounding.AwayFromZero) * FACTOR 'DECKMADP = MA2 * DECKS * MA2DP * 1 ---- MA2DP ESTA ABAJO
                LABORDP = Math.Round(M3 * M3LDP, 2, MidpointRounding.AwayFromZero) * FACTOR 'LABORDP = M3 * M3LDP * 1 ---- M3LDP ESTA ABAJO
                LDECKDP = Math.Round(M2 * estSC.descks * M2LDP, 2, MidpointRounding.AwayFromZero) * FACTOR 'LDECKDP = M2 * DECKS * M2LDP * 1  ---- M2LDP ESTA ABAJO  
                LABORBP = Math.Round(M3 * M3LBP, 2, MidpointRounding.AwayFromZero) * FACTOR 'LABORBP = M3 * M3LBP * 1 ----M3LBP ESTA ABAJO 
                LDECKBP = Math.Round(M2 * estSC.descks * M2LBP, 2, MidpointRounding.AwayFromZero) * FACTOR 'LDECKBP = M2 * DECKS * M2LBP * 1---- M2LBP ESTA ABAJO
                TLABOR = Math.Round((M3LBP + (M3LDP * M3)) + (M2LBP + M2LDP) * M2 * (DECKSNUM - 1), 2, MidpointRounding.AwayFromZero) * FACTOR 'TLABOR = (M3LBP + M3LDP * M3) + (M2LBP + M2LDP) * M2 * (DESCKNUM - 1) * 1---- M3LBP, M3LDP, M2LBP, M2LDP ESTAN ABAJO 
                PMANHRS = TLABOR / 20 'PMANHRS = TLABOR / 20 
            End If
        Else
            MsgBox("Select a type Estimation Cost please.")
        End If
    End Sub

    Function findVal(ByVal columnName As String) As Decimal
        Dim val = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf(columnName)))
        If val IsNot Nothing Then
            Return val
        Else
            Return 0
        End If
    End Function
    Public Function selectEstimation(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select EstNumber from estMeters", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("EstNumber"))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectFactor(ByVal heigth As Double) As Decimal
        Try
            conectar()
            Dim cmd As New SqlCommand("select top 1 hFactor from scfFactor where heigth= " + CStr(heigth) + " ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim hFactor As Decimal = 0
            While dr.Read()
                hFactor = If(dr("hFactor") Is DBNull.Value, 0.0, dr("hFactor"))
                Exit While
            End While
            Return hFactor
        Catch ex As Exception
            Return 0.0
        End Try
    End Function
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
            _MADPRICE = 0
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
    Public Property MADPRICE() As Decimal
        Get
            If _MADPRICE = Nothing Then
                Return 0
            Else
                Return _MADPRICE
            End If
        End Get
        Set(ByVal MADPRICE As Decimal)
            _MADPRICE = MADPRICE
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
