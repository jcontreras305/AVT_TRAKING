Imports System.Data.SqlClient
Imports System.Math
Public Class EstMeters
    Inherits ConnectioDB

    Public EstimationSC As EstimationSC

    Dim tblScfCost As New DataTable
    Dim tblTypeScf As New DataTable

    Dim _FACTOR, _DECKSNUM As Integer
    Dim _idEstMeters, _EstNumber, _idEstCost, _idTypeScf As String
    Dim _PMANHRS, _TLABOR, _LDECKBP, _LABORBP, _LDECKDP, _LABORDP, _DECKMAD, _MADPRICE, _MA2DP, _MA3DP, _DECKDP, _DPRICE, _M2DP, _M2EDP, _M2MDP, _M2LDP As Decimal
    Dim _M3DP, _M3EDP, _M3MDP, _M3LDP, _EDMA2C, _EDMA3C, _EDMA2, _EDMA3, _EDM2C, _EDM3C, _EDM2, _EDM3, _TIMESED, _DA, _DECKBP, _BPRICE, _M2BP, _M2EBP As Decimal
    Dim _M2MBP, _M2LBP, _M3BP, _M3EBP, _M3MBP, _M3LBP As Decimal

    Public Sub refreshValues(ByVal estSC As EstimationSC)
        EstimationSC = estSC
        If idEstCost <> "" And idTypeScf <> "" Then
            estSC.SelectScafEstCost(_idEstCost, tblScfCost)
            estSC.SelectScfTypeCost(_idTypeScf, tblTypeScf)
            If (tblScfCost IsNot Nothing And tblScfCost.Rows.Count > 0) And (tblTypeScf IsNot Nothing And tblTypeScf.Rows.Count > 0) Then

                M3LBP = Math.Round(addFactor(findValEst("M3LABORBP") + findValType("M3LBI")), 2, MidpointRounding.AwayFromZero)  'M3LBP = (M3LABORBP + M3LBI) * (1 + [HFactor])
                M3MBP = (findValEst("M3MATBP")) + (findValType("M3MBI")) ' M3MBP = (M3MATBP) + (M3MBI)
                M3EBP = (findValEst("M3EQBP")) + (findValType("M3EBI")) 'M3EBP = (M3EQBP) + (M3EBI)
                M3BP = (findValEst("M3LABORBP")) + (findValEst("M3MATBP")) + M3EBP 'M3BP = M3LABORBP + M3MATBP + M3EBP ---- M3EBP ESTA ABAJO

                M2LBP = Math.Round(addFactor((findValEst("M2LABORBP")) + findValType("M2LBI")), 2, MidpointRounding.AwayFromZero) 'M2LBP = (M2LABORBP + M2LBI) * (1+ [HFACTOR])  
                M2MBP = (findValEst("M2MATBP")) + (findValType("M2MBI")) 'M2MBP = M2MATBP + M2MBI
                M2EBP = (findValEst("M2EQBP")) + (findValType("M2EBI")) 'M2EBP =  M2EQBP + M2EBI
                M2BP = (findValEst("M2LABORBP")) + (findValEst("M2MATBP")) + M3EBP 'M2BP = M2LABORBP + M2MATBP + M3EBP ---- M2MBP ESTA ABAJO
                Dim M3 = estSC.M3
                Dim M2 = estSC.M2
                Dim MA3 = estSC.MA3
                Dim MA2 = estSC.MA2
                Dim DECKS = If(estSC.descks > 0, estSC.descks - 1, 0)
                Dim EDDAYS = (findValEst("EDDAYS"))
                Dim BILLINGDAYS = (findValEst("BILLINGDAYS"))

                BPRICE = Math.Round((M3) + (M3BP), 2, MidpointRounding.AwayFromZero) 'BPRICE = M3 + M3BP    ---- M3BP ESTA ABAJO 
                DECKBP = Math.Round((M2) * (DECKS) * M2BP, 2, MidpointRounding.AwayFromZero) 'DECKBP = M2 * DECKS * M2BP  ---- M2BP ESTA ABAJO 
                DA = estSC.daysActive 'DA = DAYSACTIVE ---- DE LA TABLA scfEstimation

                If EDDAYS > 0 Then
                    TIMESED = BILLINGDAYS * (DA * EDDAYS) 'timesed = BILLINGDAYS * ( DA *  EDDAYS )  ---- DA ESTA ABAJO
                Else
                    TIMESED = 0
                End If
                EDM3 = Math.Round(TIMESED * (findValEst("M3EDCHARGES")), 2, MidpointRounding.AwayFromZero) 'EDM3 = TIMESED * M3EDCHARGES   ----TIMESED ESTA ABAJO

                EDM2 = Math.Round(TIMESED * (findValEst("M2EDCHARGES")), 2, MidpointRounding.AwayFromZero) 'EDM2 = TIMESED * M2EDCHARGES   ----TIMESED ESTA ABAJO

                EDM3C = Math.Round((M3) * EDM3, 2, MidpointRounding.AwayFromZero) 'EDM3C = EDM3 * M3   ---- EDM3 ESTA ABAJO 

                EDM2C = Math.Round((M2) * EDM2, 2, MidpointRounding.AwayFromZero)  'EDM2C = EDM2 * M2   ---- EDM2 ESTA ABAJO

                EDMA3 = Math.Round(TIMESED * (findValEst("M3EDCHARGES")), 2, MidpointRounding.AwayFromZero) 'EDMA3 = TIMESED * M3EDCHARGES   ---- TIMESED ESTA ABAJO

                EDMA2 = Math.Round(TIMESED * (findValEst("M2EDCHARGES")), 2, MidpointRounding.AwayFromZero) 'EDMA2 = TIMESED * M2EDCHARGES   ---- TIMESED ESTA ABAJO

                EDMA3C = Math.Round(EDMA3 * (MA3), 2, MidpointRounding.AwayFromZero) 'EDMA3C = EDMA3 * M3   ---- EDMA3 ESTA ABAJO

                EDMA2C = Math.Round(EDMA2 * (MA2), 2, MidpointRounding.AwayFromZero) 'EDMA2C = EDMA2 * M2  ---- EDMA2 ESTA ABAJO

                M3LDP = Math.Round(addFactor((findValEst("M3LABORDP")) + (findValType("M3LDI"))), 2, MidpointRounding.AwayFromZero) 'M3LDP = (M3LABORDP + M3LDI) * (1 + [HFACTOR])  

                M3MDP = Math.Round((findValType("M3MDI")) + (findValEst("M3MATDP")), 2, MidpointRounding.AwayFromZero) 'M3MDP = M3MDI + M3MATDP
                M3EDP = Math.Round((findValEst("M3EQDP")) + (findValType("M3EDI")), 2, MidpointRounding.AwayFromZero) 'M3EDP = M3EQDP + M3EDI
                M3DP = M3LDP + M3MDP + M3EDP 'M3DP = M3LDP + M3MDP + M3EDP ---- M3LDP, M3MDP, M3EDP ESTAN ABAJO

                M2LDP = Math.Round(addFactor((findValEst("M2LABORDP")) + (findValType("M2LDI"))), 2, MidpointRounding.AwayFromZero) 'M2LDP = (M2LABORDP + M2LDI)*(1 + [HFACTOR])   

                M2MDP = Math.Round((findValEst("M2MATDP")) + (findValType("M2MDI")), 2, MidpointRounding.AwayFromZero) 'M2MDP = M2MATDP + M2MDI
                M2EDP = Math.Round((findValEst("M2EQDP")) + (findValType("M2EDI")), 2, MidpointRounding.AwayFromZero) 'M2EDP = M2EQDP + M2EDI
                M2DP = M2LDP + M2MDP + M2EDP 'M2DP = M2LDP + M2MDP + M2EDP ---- M2LDP, M2MDP, M2EDP ESTAN ABAJO

                DPRICE = Math.Round((M3 * M3DP), 2, MidpointRounding.AwayFromZero) 'DPRICE = M3 * M3DP   ---- M3DP ESTA ABAJO
                DECKDP = Math.Round(M2 * DECKS * M2DP, 2, MidpointRounding.AwayFromZero) 'DECKDP = M2 * DECKS * M2DP   ---- M2DP ESTA ABAJO
                MA3DP = Math.Round((findValEst("M2LABORDP")) + (findValEst("MA3MATDP")) + (findValEst("MA3EQDP")), 2, MidpointRounding.AwayFromZero)  'MA3DP = MA3LABORDP + MA3MATDP + MA3EQDP
                MA2DP = Math.Round((findValEst("MA2LABORDP")) + (findValEst("MA2MATDP")) + (findValEst("MA2EQDP")), 2, MidpointRounding.AwayFromZero) 'MA2DP = MA2LABORDP + MA2MATDP + MA2EQDP
                MADPRICE = Math.Round(M3 * MA3DP, 2, MidpointRounding.AwayFromZero) 'MADPRICE = MA3 * MA3DP   ---- MA3DP ESTA ABAJO
                DECKMAD = Math.Round(M3 * DECKS * MA2DP, 2, MidpointRounding.AwayFromZero)  'DECKMADP = MA2 * DECKS * MA2DP   ---- MA2DP ESTA ABAJO
                LABORDP = Math.Round(M3 * M3LDP, 2, MidpointRounding.AwayFromZero) 'LABORDP = M3 * M3LDP   ---- M3LDP ESTA ABAJO
                LDECKDP = Math.Round(M2 * DECKS * M2LDP, 2, MidpointRounding.AwayFromZero) 'LDECKDP = M2 * DECKS * M2LDP    ---- M2LDP ESTA ABAJO  
                LABORBP = Math.Round(M3 * M3LBP, 2, MidpointRounding.AwayFromZero) * FACTOR 'LABORBP = M3 * M3LBP   ----M3LBP ESTA ABAJO 
                LDECKBP = Math.Round(M2 * DECKS * M2LBP, 2, MidpointRounding.AwayFromZero) 'LDECKBP = M2 * DECKS * M2LBP  ---- M2LBP ESTA ABAJO
                TLABOR = Math.Round(((M3LBP + M3LDP) * M3) + ((M2LBP + M2LDP) * M2 * DECKS), 2, MidpointRounding.AwayFromZero) 'TLABOR = ((M3LBP + M3LDP) * M3) + (M2LBP + M2LDP) * M2 * (DESCKNUM - 1)  ---- M3LBP, M3LDP, M2LBP, M2LDP ESTAN ABAJO 
                PMANHRS = TLABOR / 20 'PMANHRS = TLABOR / 20 
            End If
        Else
            If idEstCost <> "" Then
                MsgBox("Select a type Estimation Cost By Costumer.")
            ElseIf idTypeScf <> "" Then
                MsgBox("Select a type Estimation Cost please.")
            End If
        End If
    End Sub

    Function findValEst(ByVal columnName As String) As Decimal
        Dim val = (tblScfCost.Rows(0).ItemArray(tblScfCost.Columns.IndexOf(columnName)))
        If val IsNot Nothing Then
            Return val
        Else
            Return 0
        End If
    End Function
    Function findValType(ByVal columnName As String) As Decimal
        Dim val = (tblTypeScf.Rows(0).ItemArray(tblTypeScf.Columns.IndexOf(columnName)))
        If val IsNot Nothing Then
            Return val
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Agrega el Factor al valor recivido (valor * (1+(factor)))
    ''' (donde de el fator es porcentaje de 0.01 a 1 dependiente de la altura total)
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    Function addFactor(ByVal valor As Double) As Double
        Try
            If FACTOR > 0 Then
                valor = Math.Round(valor * (1 + (FACTOR / 100)), 2, MidpointRounding.AwayFromZero)
            End If
            Return valor
        Catch ex As Exception
            Return valor
        End Try
    End Function
    Public Function cargarDatosEstMeters(ByVal idEstMeters As String, ByVal EstNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEstMeters,EstNumber,PMANHRS,TLABOR,LDECKBP,LABORBP,LDECKDP,LABORDP,
	DECKMAD,MADPRIC,MA2DP,MA3DP,DECKDP,DPRICE,M2DP,M2EDP,M2MDP,M2LDP,M3DP,
	M3EDP,M3MDP,M3LDP,EDMA2C,EDMA3C,EDMA2,EDMA3,EDM2C,EDM3C,EDM2,EDM3,
	TIMESED,DA,DECKBP,BPRICE,M2BP,M2EBP,M2MBP,M2LBP,M3BP,M3EBP,M3MBP,M3LDP from EstMeters where idEstMeters = '" + idEstMeters + "' or EstNumber= '" + EstNumber + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _M3LDP = rd("M3LDP")
                _M3MBP = rd("M3MBP")
                _M3EBP = rd("M3EBP")
                _M3EBP = rd("M3EBP")
                _M3BP = rd("M3BP")
                _M2LBP = rd("M2LBP")
                _M2MBP = rd("M2MBP")
                _M2EBP = rd("M2EBP")
                _M2BP = rd("M2BP")
                _BPRICE = rd("BPRICE")
                _DECKBP = rd("DECKBP")
                _DA = rd("DA")
                _TIMESED = rd("TIMESED")
                _EDM3 = rd("EDM3")
                _EDM2 = rd("EDM2")
                _EDM3C = rd("EDM3C")
                _EDM2C = rd("EDM2C")
                _EDMA3 = rd("EDMA3")
                _EDMA2 = rd("EDMA2")
                _EDMA3C = rd("EDMA3C")
                _EDMA2C = rd("EDMA2C")
                _M3LDP = rd("M3LDP")
                _M3MDP = rd("M3MDP")
                _M3EDP = rd("M3EDP")
                _M3DP = rd("M3DP")
                _M2LDP = rd("M2LDP")
                _M2MDP = rd("M2MDP")
                _M2EDP = rd("M2EDP")
                _M2DP = rd("M2DP")
                _DPRICE = rd("DPRICE")
                _DECKDP = rd("DECKDP")
                _MA3DP = rd("MA3DP")
                _MA2DP = rd("MA2DP")
                _MADPRICE = rd("MADPRICE")
                _DECKMAD = rd("DECKMAD")
                _LABORDP = rd("LABORDP")
                _LDECKDP = rd("LDECKDP")
                _LDECKBP = rd("LDECKBP")
                _TLABOR = rd("TLABOR")
                _PMANHRS = rd("PMANHRS")
                _EstNumber = rd("EstNumber")
                _idEstMeters = rd("idEstMeters")
                Exit While
            End While
            Return True
        Catch ex As Exception
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectEstimationProyect(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ccnum, unit from scfEstProyect", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(CStr(dr("ccnum")) + " " + CStr(dr("unit")))
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
            _idEstCost = ""
            _idTypeScf = ""
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
                Dim id As Guid = Guid.NewGuid()
                _idEstMeters = id.ToString()
                Return _idEstMeters
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
                Return "-1"
            Else
                Return _idEstCost
            End If
        End Get
        Set(ByVal idEstCost As String)
            _idEstCost = idEstCost
        End Set
    End Property
    Public Property idTypeScf() As String
        Get
            If _idTypeScf = Nothing Then
                Return "-1"
            Else
                Return _idTypeScf
            End If
        End Get
        Set(ByVal idTypeScf As String)
            _idTypeScf = idTypeScf
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
