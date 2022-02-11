Imports System.Data.SqlClient
Public Class EstimationSC
    Inherits ConnectioDB

    Dim _list As New List(Of String)

    Dim _idClient, _ccNum, _idAux, _unit, _location, _idEstnumber, _idEstMeters As String
    Dim _descks, _groundheigth, _elevation, _IdEstCost, _scfTypeId As Integer
    Dim _daysActive, _width, _heigth, _length As Double
    Dim _M3, _M2, _MA3, _MA2, _ACHT, _DECKS, _TOTALHEIGTH As Double
    Dim _factor As Decimal

    Public Property M3() As Double
        Get
            If _M3 = Nothing Then
                _M3 = Format(((width * length * (heigth + elevation)) / 35.31467), "##,##0.00")
                Return _M3
            Else
                _M3 = Format(((width * length * (heigth + elevation)) / 35.31467), "##,##0.00")
                Return _M3
            End If
        End Get
        Set(ByVal M3 As Double)
            _M3 = M3
        End Set
    End Property
    Public Property M2() As Double
        Get
            If _M2 = Nothing Then
                _M2 = Format(((width * length) / 10.76391), "##,##0.00")
                Return _M2
            Else
                _M2 = Format(((width * length) / 10.76391), "##,##0.00")
                Return _M2
            End If
        End Get
        Set(ByVal M2 As Double)
            _M2 = M2
        End Set
    End Property
    Public Property MA3() As Double
        Get
            If _MA3 = Nothing Then
                _MA3 = Format(((width * length * (heigth - elevation)) / 35.31467), "##,##0.00")
                Return _MA3
            Else
                _MA3 = Format(((width * length * (heigth - elevation)) / 35.31467), "##,##0.00")
                Return _MA3
            End If
        End Get
        Set(ByVal MA3 As Double)
            _MA3 = MA3
        End Set
    End Property
    Public Property MA2() As Double
        Get
            If _MA2 = Nothing Then
                _MA2 = Format(((width * length) / 10.76391), "##,##0.00")
                Return _MA2
            Else
                _MA2 = Format(((width * length) / 10.76391), "##,##0.00")
                Return _MA2
            End If
        End Get
        Set(ByVal MA2 As Double)
            _MA2 = MA2
        End Set
    End Property
    Public Property ACHT() As Double
        Get
            If _ACHT = Nothing Then
                _ACHT = heigth + groundheigth
                Return _ACHT
            Else
                _ACHT = heigth + groundheigth
                Return _ACHT
            End If
        End Get
        Set(ByVal ACHT As Double)
            _ACHT = ACHT
        End Set
    End Property
    Public Property DECKS() As Double
        Get
            If _DECKS = Nothing Then
                _DECKS = If(descks > 0, descks - 1, 0)
                Return _DECKS
            Else
                _DECKS = If(descks > 0, descks - 1, 0)
                Return _DECKS
            End If
        End Get
        Set(ByVal Decks As Double)
            _DECKS = Decks
        End Set
    End Property
    Public Property TOTALHEIGTH() As Double
        Get
            If _TOTALHEIGTH = Nothing Then
                _TOTALHEIGTH = heigth + groundheigth
                Return _TOTALHEIGTH
            Else
                _TOTALHEIGTH = heigth + groundheigth
                Return _TOTALHEIGTH
            End If
        End Get
        Set(ByVal TotalHeigth As Double)
            _TOTALHEIGTH = TotalHeigth
        End Set
    End Property
    Public Property factor() As Double
        Get
            If _factor = Nothing Then
                _factor = 0
                Return _factor
            Else
                Return _factor
            End If
        End Get
        Set(ByVal factor As Double)
            _factor = factor
        End Set
    End Property

    Public Sub Clear()
        _list.Clear()
        _idClient = ""
        _ccNum = ""
        _idAux = ""
        _unit = ""
        _location = ""
        _idEstnumber = Nothing
        _idEstMeters = Nothing
        _descks = 0
        _groundheigth = 0
        _elevation = 0
        _daysActive = 0.0
        _IdEstCost = -1
        _scfTypeId = -1
        _width = 0.0
        _heigth = 0.0
        _length = 0.0
        _M3 = 0.0
        _M2 = 0.0
        _MA3 = 0.0
        _MA2 = 0.0
        _DECKS = 0.0
        _TOTALHEIGTH = 0.0
        _factor = 0
    End Sub
    Public Property list() As List(Of String)
        Get
            If _list.Count = 0 Then
                llenarListTypeScfCost()
                Return _list
            Else
                Return _list
            End If
        End Get
        Set(ByVal list As List(Of String))
            _list = list
        End Set
    End Property
    Public Property idClient() As String
        Get
            If _idClient = Nothing Then
                Return ""
            Else
                Return _idClient
            End If
        End Get
        Set(ByVal idClient As String)
            _idClient = idClient
        End Set
    End Property
    Public Property ccnum() As String
        Get
            If _ccNum = Nothing Then
                Return ""
            Else
                Return _ccNum
            End If
        End Get
        Set(ByVal ccNum As String)
            _ccNum = ccNum
        End Set
    End Property
    Public Property idAux() As String
        Get
            If _idAux = Nothing Then
                Return ""
            Else
                Return _idAux
            End If
        End Get
        Set(ByVal idAux As String)
            _idAux = idAux
        End Set
    End Property
    Public Property unit() As String
        Get
            If _unit = Nothing Then
                Return ""
            Else
                Return _unit
            End If
        End Get
        Set(ByVal unit As String)
            _unit = unit
        End Set
    End Property
    Public Property location() As String
        Get
            If _location = Nothing Then
                Return ""
            Else
                Return _location
            End If
        End Get
        Set(ByVal location As String)
            _location = location
        End Set
    End Property
    Public Property idEstnumber() As String
        Get
            If _idEstnumber Is Nothing Then
                Dim id As Guid = Guid.NewGuid()
                _idEstnumber = id.ToString()
                Return _idEstnumber
            Else
                Return _idEstnumber
            End If

        End Get
        Set(ByVal idEstnumber As String)
            _idEstnumber = idEstnumber
        End Set
    End Property
    Public Property idEstMeters() As String
        Get
            If _idEstMeters Is Nothing Then
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
    Public Property descks() As Integer
        Get
            If _descks = Nothing Then
                Return 0
            Else
                Return _descks
            End If
        End Get
        Set(ByVal descks As Integer)
            _descks = descks
        End Set
    End Property
    Public Property groundheigth() As Integer
        Get
            If _groundheigth = Nothing Then
                Return 0
            Else
                Return _groundheigth
            End If
        End Get
        Set(ByVal groundheigth As Integer)
            _groundheigth = groundheigth
        End Set
    End Property
    Public Property elevation() As Integer
        Get
            If _elevation = Nothing Then
                Return 0
            Else
                Return _elevation
            End If
        End Get
        Set(ByVal elevation As Integer)
            _elevation = elevation
        End Set
    End Property
    Public Property IdEstCost() As Integer
        Get
            If _IdEstCost = Nothing Then
                Return 0
            Else
                Return _IdEstCost
            End If
        End Get
        Set(ByVal IdEstCost As Integer)
            _IdEstCost = IdEstCost
        End Set
    End Property
    Public Property scfTypeId() As Integer
        Get
            If _scfTypeId = Nothing Then
                Return 0
            Else
                Return _scfTypeId
            End If
        End Get
        Set(ByVal scfTypeId As Integer)
            _scfTypeId = scfTypeId
        End Set
    End Property
    Public Property daysActive() As Double
        Get
            If _daysActive = Nothing Then
                Return 0.0
            Else
                Return _daysActive
            End If
        End Get
        Set(ByVal daysActive As Double)
            _daysActive = daysActive
        End Set
    End Property
    Public Property width() As Double
        Get
            If _width = Nothing Then
                Return 0.0
            Else
                Return _width
            End If
        End Get
        Set(ByVal width As Double)
            _width = width
        End Set
    End Property
    Public Property heigth() As Double
        Get
            If _heigth = Nothing Then
                Return 0.0
            Else
                Return _heigth
            End If
        End Get
        Set(ByVal heigth As Double)
            _heigth = heigth
        End Set
    End Property
    Public Property length() As Double
        Get
            If _length = Nothing Then
                Return 0.0
            Else
                Return _length
            End If
        End Get
        Set(ByVal length As Double)
            _length = length
        End Set
    End Property
    Public Function SelectScafEstCost(ByVal idEstCost As String, ByVal tbl As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select top 1 * from ScafEstCost where idEstCost = " + idEstCost, conn)
            If cmd.ExecuteNonQuery() Then
                tbl.Rows.Clear()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tbl)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function SelectScfTypeCost(ByVal idTypeCost As String, ByVal tbl As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select top 1 * from scfTypeCost where scfTypeId = " + idTypeCost, conn)
            If cmd.ExecuteNonQuery() Then
                tbl.Clear()
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tbl)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function SelectTypeCost(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from scfTypeCost", conn)
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveTypeScafCost(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            Dim rowi As String = ""
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each Row As DataGridViewRow In tbl.SelectedRows()
                If Row.Cells(1).Value IsNot "" Then
                    rowi = Row.Index
                    Dim cmd As New SqlCommand("
if (select COUNT(*) from scfTypeCost where scfTypeId = " + If(Row.Cells(0).Value Is DBNull.Value, "0", CStr(Row.Cells(0).Value)) + " )= 0 
begin
	insert into scfTypeCost values('" + CStr(Row.Cells(1).Value) + "'," + CStr(Row.Cells(2).Value) + "," + CStr(Row.Cells(3).Value) + "," + CStr(Row.Cells(4).Value) + "," + CStr(Row.Cells(5).Value) + "," + CStr(Row.Cells(6).Value) + "," + CStr(Row.Cells(7).Value) + "," + CStr(Row.Cells(8).Value) + "," + CStr(Row.Cells(9).Value) + "," + CStr(Row.Cells(10).Value) + "," + CStr(Row.Cells(11).Value) + "," + CStr(Row.Cells(12).Value) + "," + CStr(Row.Cells(13).Value) + "," + CStr(Row.Cells(14).Value) + "," + CStr(Row.Cells(15).Value) + "," + CStr(Row.Cells(16).Value) + "," + CStr(Row.Cells(17).Value) + "," + CStr(Row.Cells(18).Value) + "," + CStr(Row.Cells(19).Value) + "," + CStr(Row.Cells(20).Value) + "," + CStr(Row.Cells(20).Value) + "," + CStr(Row.Cells(21).Value) + "," + CStr(Row.Cells(22).Value) + "," + CStr(Row.Cells(23).Value) + "," + CStr(Row.Cells(23).Value) + "," + CStr(Row.Cells(24).Value) + "," + CStr(Row.Cells(25).Value) + ")
end
else if (select COUNT(*) from scfTypeCost where scfTypeId = " + If(Row.Cells(0).Value Is DBNull.Value, "0", CStr(Row.Cells(0).Value)) + " )> 0
begin 
	update scfTypeCost set SCTP = '" + CStr(Row.Cells(1).Value) + "',
	M3LBI =" + CStr(Row.Cells(2).Value) + ",M3MBI =" + CStr(Row.Cells(3).Value) + ",M3EBI =" + CStr(Row.Cells(4).Value) + ",M3LDI =" + CStr(Row.Cells(5).Value) + ",M3MDI =" + CStr(Row.Cells(6).Value) + ",M3EDI =" + CStr(Row.Cells(7).Value) + ",
	M2LBI =" + CStr(Row.Cells(8).Value) + ",M2MBI =" + CStr(Row.Cells(9).Value) + ",M2EBI =" + CStr(Row.Cells(10).Value) + ",M2LDI =" + CStr(Row.Cells(11).Value) + ",M2MDI =" + CStr(Row.Cells(12).Value) + ",M2EDI =" + CStr(Row.Cells(13).Value) + ",
	MA3LBI =" + CStr(Row.Cells(14).Value) + ",MA3MBI=" + CStr(Row.Cells(15).Value) + ",MA3EBI=" + CStr(Row.Cells(16).Value) + ",MA3LDI=" + CStr(Row.Cells(17).Value) + ",MA3MDI=" + CStr(Row.Cells(18).Value) + ",MA3EDI=" + CStr(Row.Cells(19).Value) + ",
	MA2LBI=" + CStr(Row.Cells(20).Value) + ",MA2MBI=" + CStr(Row.Cells(21).Value) + ",MA2EBI=" + CStr(Row.Cells(22).Value) + ",MA2LDI=" + CStr(Row.Cells(23).Value) + ",MA2MDI=" + CStr(Row.Cells(24).Value) + ",MA2EDI=" + CStr(Row.Cells(25).Value) + ",
	SCSN =" + CStr(Row.Cells(26).Value) + ",BDRATE=" + CStr(Row.Cells(27).Value) + " where scfTypeId = " + If(Row.Cells(0).Value Is DBNull.Value, "0", CStr(Row.Cells(0).Value)) + "
end  
", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Error in the row " + rowi + ". Check the Information.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteTypeScafCost(ByRef tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            Dim idEstCost As String = ""
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells(0).Value IsNot "" Then
                    idEstCost = row.Cells(0).Value
                    Dim cmd As New SqlCommand("delete from scfTypeCost where scfTypeId = " + idEstCost, conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Error in the row whit the ID " + idEstCost + ".Check the inforamtion.")
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function SelectScafEstCost(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from ScafEstCost", conn)
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                tbl.Columns(0).Visible = False
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveScafEstCost(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            Dim rowi As String = ""
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each Row As DataGridViewRow In tbl.SelectedRows()
                If Row.Cells(1).Value IsNot "" Then
                    rowi = Row.Index
                    Dim cmd As New SqlCommand("
if (select COUNT(*) from ScafEstCost where idEstCost = " + If(Row.Cells(0).Value Is DBNull.Value, "0", CStr(Row.Cells(0).Value)) + ")= 0 
begin 
	insert into ScafEstCost values ('" + CStr(Row.Cells(1).Value) + "',
        " + CStr(Row.Cells(2).Value) + "," + CStr(Row.Cells(3).Value) + "," + CStr(Row.Cells(4).Value) + "," + CStr(Row.Cells(5).Value) + ",
        " + CStr(Row.Cells(6).Value) + "," + CStr(Row.Cells(7).Value) + "," + CStr(Row.Cells(8).Value) + ",
        " + CStr(Row.Cells(9).Value) + "," + CStr(Row.Cells(10).Value) + "," + CStr(Row.Cells(11).Value) + ",
        " + CStr(Row.Cells(12).Value) + "," + CStr(Row.Cells(13).Value) + "," + CStr(Row.Cells(14).Value) + ",
        " + CStr(Row.Cells(15).Value) + "," + CStr(Row.Cells(16).Value) + "," + CStr(Row.Cells(17).Value) + ",
        " + CStr(Row.Cells(18).Value) + "," + CStr(Row.Cells(19).Value) + "," + CStr(Row.Cells(20).Value) + ",
        " + CStr(Row.Cells(21).Value) + "," + CStr(Row.Cells(22).Value) + "," + CStr(Row.Cells(23).Value) + ",
        " + CStr(Row.Cells(24).Value) + "," + CStr(Row.Cells(25).Value) + "," + CStr(Row.Cells(26).Value) + ",
        " + CStr(Row.Cells(27).Value) + "," + CStr(Row.Cells(28).Value) + "," + CStr(Row.Cells(29).Value) + ",
        " + CStr(Row.Cells(30).Value) + "," + CStr(Row.Cells(31).Value) + ")
end
else if(select COUNT(*) from ScafEstCost where idEstCost = " + If(Row.Cells(0).Value Is DBNull.Value, "0", CStr(Row.Cells(0).Value)) + ")> 0
begin 
	update ScafEstCost set 
	SCEC ='" + CStr(Row.Cells(1).Value) + "',
	M3EDCHARGES =" + CStr(Row.Cells(2).Value) + ",M2EDCHARGES =" + CStr(Row.Cells(3).Value) + ",MA3EDCHARGES=" + CStr(Row.Cells(4).Value) + ",MA2EDCHARGES=" + CStr(Row.Cells(5).Value) + ",
	M3LABORBP =" + CStr(Row.Cells(6).Value) + ",M3MATBP =" + CStr(Row.Cells(7).Value) + ",M3EQBP =" + CStr(Row.Cells(8).Value) + ",
	M3LABORDP=" + CStr(Row.Cells(9).Value) + ",M3MATDP=" + CStr(Row.Cells(10).Value) + ",M3EQDP=" + CStr(Row.Cells(11).Value) + ",
	M2LABORBP=" + CStr(Row.Cells(12).Value) + ",M2MATBP=" + CStr(Row.Cells(13).Value) + ",M2EQBP=" + CStr(Row.Cells(14).Value) + ",
	M2LABORDP=" + CStr(Row.Cells(15).Value) + ",M2MATDP =" + CStr(Row.Cells(16).Value) + ",M2EQDP=" + CStr(Row.Cells(17).Value) + ",
	MA3LABORBP=" + CStr(Row.Cells(18).Value) + ",MA3MATBP =" + CStr(Row.Cells(19).Value) + ",MA3EQBP =" + CStr(Row.Cells(20).Value) + ",
	MA3LABORDP =" + CStr(Row.Cells(21).Value) + ",MA3MATDP =" + CStr(Row.Cells(22).Value) + ",MA3EQDP =" + CStr(Row.Cells(23).Value) + ",
	MA2LABORBP=" + CStr(Row.Cells(24).Value) + ",MA2MATBP=" + CStr(Row.Cells(25).Value) + ",MA2EQBP=" + CStr(Row.Cells(26).Value) + ",
	MA2LABORDP=" + CStr(Row.Cells(27).Value) + ",MA2MATDP =" + CStr(Row.Cells(28).Value) + ",MA2EQDP =" + CStr(Row.Cells(29).Value) + ",
    BILLINGDAYS = " + CStr(Row.Cells(30).Value) + ",EDDAYS=" + CStr(Row.Cells(31).Value) + "
	where idEstCost  = " + If(Row.Cells(0).Value Is DBNull.Value, "0", CStr(Row.Cells(0).Value)) + "
end
", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Error in the row " + rowi + ". Check the Information.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteScafEstCost(ByRef tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            Dim idEstCost As String = ""
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells(0).Value IsNot "" Then
                    idEstCost = row.Cells(0).Value
                    Dim cmd As New SqlCommand("delete from ScafEstCost where idEstCost = " + idEstCost, conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Error in the row whit the ID " + idEstCost + ".Check the inforamtion.")
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectFactorSC(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select tpid as 'Type',heigth as 'Heigth', hFactor as 'Factor %' from scfFactor", conn)
            If cmd.ExecuteNonQuery() Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                da.Fill(dt)
                tbl.DataSource = dt
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function SaveFactorSC(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            Dim rowi As String = ""
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each Row As DataGridViewRow In tbl.SelectedRows()
                If Row.Cells(0).Value IsNot "" Then
                    rowi = CStr(Row.Cells(0).Value)
                    Dim cmd As New SqlCommand("
if (select count(*) from scfFactor where tpid = " + CStr(Row.Cells(0).Value) + " and heigth = " + CStr(Row.Cells(1).Value) + ")=0
begin
	insert into scfFactor values(" + CStr(Row.Cells(0).Value) + "," + CStr(Row.Cells(1).Value) + "," + CStr(Row.Cells(2).Value) + ")
end
else if(select count(*) from scfFactor where tpid = " + CStr(Row.Cells(0).Value) + " and heigth = " + CStr(Row.Cells(1).Value) + ")=1
begin
	update scfFactor set hFactor=" + CStr(Row.Cells(2).Value) + " where tpid = " + CStr(Row.Cells(0).Value) + " and heigth = " + CStr(Row.Cells(1).Value) + "
end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Error in the row whit the ID " + rowi + ". Check the Information.")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function deleteFactorSC(ByRef tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            Dim idEstCost As String = ""
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells(0).Value IsNot "" Then
                    idEstCost = row.Cells(0).Value
                    Dim cmd As New SqlCommand("delete from scfFactor where tpid = " + CStr(row.Cells(0).Value) + " and heigth = " + CStr(row.Cells(1).Value), conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return True
            Else
                tran.Rollback()
                MsgBox("Error in the row whit the ID " + idEstCost + ".Check the inforamtion.")
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function llenarComboTypeScfCost(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select scfTypeId , SCTP from scfTypeCost", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            cmb.Items.Add("")
            While rd.Read()
                cmb.Items.Add(CStr(rd("scfTypeId")) + " " + CStr(rd("SCTP")))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboScfEstCost(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEstCost , SCEC from ScafEstCost", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            cmb.Items.Add("")
            While rd.Read()
                cmb.Items.Add(CStr(rd("idEstCost")) + " " + CStr(rd("SCEC")))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboControlNumber(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ccnum , unit from scfEstProyect", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            cmb.Items.Add("")
            While rd.Read()
                cmb.Items.Add(CStr(rd("ccnum")) + " " + CStr(rd("unit")))
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarListTypeScfCost() As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select idEstCost , SCTP from ScafEstCost", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader
            _list.Clear()
            _list.Add("")
            While rd.Read()
                _list.Add(rd("SCTP"))
            End While
            Return _list
        Catch ex As Exception
            Dim listEX As New List(Of String)
            listEX.Add("")
            Return listEX
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenartablaEstimacion(ByVal tabla As DataTable, ByVal idCliente As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select scfE.EstNumber,scfE.ccnum,scfE.scfTypeId,scfE.idEstCost,scfE.idAux,scfE.idClient from scfEstimation as scfE 
inner join EstMeters as estM on scfE.EstNumber = estM.EstNumber" +
If(idCliente = "", "", " where scfE.idClient = '" + idCliente + "'"), conn)
            tabla.Rows.Clear()
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(tabla)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function cargarDatosEstimation(ByVal controlNum As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select ISNULL( idAux,'') as 'idAux',daysActive, 
	ISNULL((select unit from scfEstProyect where ccnum = sem.ccnum ),'') as 'unit',
	location,width,heigth,length,descks,groundHeigth,elevation,
	M3,M2,MA3,MA2,ACHT,IdEstCost,scfTypeId, 
	ISNULL(sem.ccnum,'')as 'ccnum', 
	emt.idEstMeters ,
	sem.EstNumber,
    ISNULL(sem.idClient,'') as 'idClient'
	from scfEstimation as sem 
	left join EstMeters as emt on emt.EstNumber = sem.EstNumber
	where sem.EstNumber = '" + controlNum + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _idEstnumber = controlNum
                _scfTypeId = If(rd("scfTypeId") Is DBNull.Value, -1, rd("scfTypeId"))
                _idAux = rd("idAux")
                _daysActive = rd("daysActive")
                _unit = rd("unit")
                _location = rd("location")
                _width = rd("width")
                _heigth = rd("heigth")
                _length = rd("length")
                _descks = rd("descks")
                _groundheigth = rd("groundHeigth")
                _elevation = rd("elevation")
                _M3 = rd("M3")
                _M2 = rd("M2")
                _MA3 = rd("MA3")
                _MA2 = rd("MA2")
                _ACHT = rd("ACHT")
                _IdEstCost = rd("IdEstCost")
                _ccNum = rd("ccnum")
                _idEstMeters = rd("idEstMeters")
                _idClient = rd("idClient")
                Exit While
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectEstMeters(ByVal controlNum As String, ByVal idEstMeters As String) As EstMeters
        Try
            conectar()
            Dim cmd As New SqlCommand("select top 1 * from EstMeters where EstNumber = '" + controlNum + "' and idEstMeters = '" + idEstMeters + "' ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim estMts As New EstMeters
            While dr.Read()
                estMts.idEstMeters = dr("idEstMeters").ToString()
                estMts.idEstCost = dr("EstNumber").ToString()
                estMts.PMANHRS = CDec(dr("PMANHRS"))
                estMts.TLABOR = CDec(dr("TLABOR"))
                estMts.LDECKBP = CDec(dr("LDECKBP"))
                estMts.LABORBP = CDec(dr("LABORBP"))
                estMts.LDECKDP = CDec(dr("LDECKDP"))
                estMts.LABORDP = CDec(dr("LABORDP"))
                estMts.DECKMAD = CDec(dr("DECKMAD"))
                estMts.MADPRICE = CDec(dr("MADPRIC"))
                estMts.MA2DP = CDec(dr("MA2DP"))
                estMts.MA3DP = CDec(dr("MA3DP"))
                estMts.DECKDP = CDec(dr("DECKDP"))
                estMts.DPRICE = CDec(dr("DPRICe"))
                estMts.M2DP = CDec(dr("M2DP"))
                estMts.M2EDP = CDec(dr("M2EDP"))
                estMts.M2MDP = CDec(dr("M2MDP"))
                estMts.M2LDP = CDec(dr("M2LDP"))
                estMts.M3DP = CDec(dr("M3DP"))
                estMts.M3EDP = CDec(dr("M3EDP"))
                estMts.M3MDP = CDec(dr("M3MDP"))
                estMts.M3LDP = CDec(dr("M3LDP"))
                estMts.EDMA2C = CDec(dr("EDMA2C"))
                estMts.EDMA3C = CDec(dr("EDMA3C"))
                estMts.EDMA2 = CDec(dr("EDMA2"))
                estMts.EDMA3 = CDec(dr("EDMA3"))
                estMts.EDM2C = CDec(dr("EDM2C"))
                estMts.EDM3C = CDec(dr("EDM3C"))
                estMts.EDM2 = CDec(dr("EDM2"))
                estMts.EDM3 = CDec(dr("EDM3"))
                estMts.TIMESED = CDec(dr("TIMESED"))
                estMts.DA = CDec(dr("DA"))
                estMts.DECKBP = CDec(dr("DECKBP"))
                estMts.BPRICE = CDec(dr("BPRICE"))
                estMts.M2BP = CDec(dr("M2BP"))
                estMts.M2EBP = CDec(dr("M2EBP"))
                estMts.M2MBP = CDec(dr("M2MBP"))
                estMts.M2LBP = CDec(dr("M2LBP"))
                estMts.M3BP = CDec(dr("M3BP"))
                estMts.M3EBP = CDec(dr("M3EBP"))
                estMts.M3MBP = CDec(dr("M3MBP"))
                estMts.M3LBP = CDec(dr("M3LBP"))
                Exit While
            End While
            dr.Close()
            Return estMts
        Catch ex As Exception
            Dim estMts1 As New EstMeters
            Return estMts1
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveEstimation(ByVal estM As EstMeters) As Boolean
        If Not (estM.idTypeScf = "-1" And estM.idEstCost = "-1") Then
            Dim tran As SqlTransaction
            Try
                conectar()
                tran = conn.BeginTransaction
                Dim cmdEstP As New SqlCommand("if (select COUNT(*) from scfEstProyect where ccnum = '" + estM.EstimationSC.ccnum + "')=0
begin
	insert into scfEstProyect values ('" + estM.EstimationSC.ccnum + "','" + estM.EstimationSC.unit + "')
end
else if (select COUNT(*) from scfEstProyect where ccnum = '" + estM.EstimationSC.ccnum + "')=1
begin
	update scfEstProyect set unit = '" + estM.EstimationSC.unit + "' where ccnum = '" + estM.EstimationSC.ccnum + "'
end", conn)
                cmdEstP.Transaction = tran
                Dim cmd As New SqlCommand("
if (select COUNT(*) from scfEstimation  where EstNumber = '" + idEstnumber + "')=0
begin
	insert into scfEstimation values ('" + idEstnumber + "'," + If(idAux = "", "NULL", "'" + idAux + "'") + "," + CStr(daysActive) + ",'" + location + "'," + CStr(width) + "," + CStr(heigth) + "," + CStr(length) + "," + CStr(descks) + "," + CStr(groundheigth) + "," + CStr(elevation) + "," + CStr(M3) + "," + CStr(M2) + "," + CStr(MA3) + "," + CStr(MA2) + "," + CStr(ACHT) + "," + If(CStr(IdEstCost) = "-1", "NULL", CStr(IdEstCost)) + "," + If(CStr(scfTypeId) = "-1", "NULL", CStr(scfTypeId)) + "," + If(CStr(ccnum) = "", "NULL", CStr(ccnum)) + "," + If(CStr(idClient) = "", "NULL", "'" + CStr(idClient) + "'") + ") 
end
else if (select COUNT(*) from scfEstimation  where EstNumber = '" + idEstnumber + "')>0
begin 
	update scfEstimation set idAux = " + If(idAux = "", "NULL", "'" + idAux + "'") + ",daysActive = " + CStr(daysActive) + ",location='" + location + "',width=" + CStr(width) + ",heigth=" + CStr(heigth) + ",length=" + CStr(length) + ",descks=" + CStr(descks) + ",groundHeigth=" + CStr(groundheigth) + ",elevation=" + CStr(elevation) + ", M3 = " + CStr(M3) + " , M2=" + CStr(M2) + ", MA3 = " + CStr(MA3) + " , MA2 = " + CStr(MA2) + ",ACHT=" + CStr(ACHT) + ",IdEstCost=" + If(CStr(IdEstCost) = "-1", "NULL", CStr(IdEstCost)) + ",scfTypeId= " + If(CStr(scfTypeId) = "-1", "NULL", CStr(scfTypeId)) + " , ccnum = " + If(CStr(ccnum) = "", "NULL", CStr(ccnum)) + " where EstNumber = '" + idEstnumber + "' 
end", conn)
                cmd.Transaction = tran
                Dim cmd1 As New SqlCommand("if (select count( *) from EstMeters where EstNumber = '" + idEstnumber + "' and idEstMeters = '" + estM.idEstMeters + "')=0
begin
	insert into EstMeters values('" + idEstMeters + "','" + idEstnumber + "'," + CStr(estM.PMANHRS) + "," + CStr(estM.TLABOR) + "," + CStr(estM.LDECKBP) + "," + CStr(estM.LABORBP) + "," + CStr(estM.LDECKDP) + "," + CStr(estM.LABORDP) + ",
    " + CStr(estM.DECKMAD) + "," + CStr(estM.MADPRICE) + ",
    " + CStr(estM.MA2DP) + "," + CStr(estM.MA3DP) + "," + CStr(estM.DECKDP) + "," + CStr(estM.DPRICE) + ",
    " + CStr(estM.M2DP) + "," + CStr(estM.M2EDP) + "," + CStr(estM.M2MDP) + "," + CStr(estM.M2LDP) + ",
    " + CStr(estM.M3DP) + "," + CStr(estM.M3EDP) + "," + CStr(estM.M3MDP) + "," + CStr(estM.M3LDP) + ",
    " + CStr(estM.EDMA2C) + "," + CStr(estM.EDMA3C) + "," + CStr(estM.EDMA2) + "," + CStr(estM.EDMA3) + ",
    " + CStr(estM.EDM2C) + "," + CStr(estM.EDM3C) + "," + CStr(estM.EDM2) + "," + CStr(estM.EDM3) + ",
    " + CStr(estM.TIMESED) + "," + CStr(estM.DA) + "," + CStr(estM.DECKBP) + "," + CStr(estM.BPRICE) + ",
    " + CStr(estM.M2BP) + "," + CStr(estM.M2EBP) + "," + CStr(estM.M2MBP) + "," + CStr(estM.M2LBP) + ",
    " + CStr(estM.M3BP) + "," + CStr(estM.M3BP) + "," + CStr(estM.M3MBP) + "," + CStr(estM.M3LBP) + ")
end
else if (select count( *) from EstMeters where EstNumber = '" + idEstnumber + "' and idEstMeters = '" + estM.idEstMeters + "')>0
begin 
	update EstMeters set 
		PMANHRS = " + CStr(estM.PMANHRS) + ", TLABOR= " + CStr(estM.TLABOR) + ",LDECKBP= " + CStr(estM.LDECKBP) + ",
		LABORBP = " + CStr(estM.LABORBP) + ", LDECKDP= " + CStr(estM.LDECKDP) + ", LABORDP= " + CStr(estM.LABORDP) + ",
		DECKMAD= " + CStr(estM.DECKMAD) + ",MADPRIC= " + CStr(estM.MADPRICE) + ",
		MA2DP= " + CStr(estM.MA2DP) + ",MA3DP= " + CStr(estM.MA3DP) + ",DECKDP= " + CStr(estM.DECKDP) + ",DPRICE= " + CStr(estM.DPRICE) + ",
		M2DP= " + CStr(estM.M2DP) + ",M2EDP= " + CStr(estM.M2EDP) + ",M2MDP= " + CStr(estM.M2MDP) + ",M2LDP= " + CStr(estM.M2LDP) + ",
		M3DP= " + CStr(estM.M3DP) + ",M3EDP= " + CStr(estM.M3EDP) + ",M3MDP= " + CStr(estM.M3MDP) + ",M3LDP= " + CStr(estM.M3LDP) + ",
		EDMA2C= " + CStr(estM.EDMA2C) + ",EDMA3C= " + CStr(estM.EDMA3C) + ",EDMA2= " + CStr(estM.EDMA2) + ",EDMA3= " + CStr(estM.EDMA3) + ",
		EDM2C= " + CStr(estM.EDM2C) + ",EDM3C= " + CStr(estM.EDMA3C) + ",EDM2= " + CStr(estM.EDM2) + ",EDM3= " + CStr(estM.EDM3) + ",
		TIMESED= " + CStr(estM.TIMESED) + ",DA= " + CStr(estM.DA) + ",DECKBP= " + CStr(estM.DECKBP) + ",BPRICE= " + CStr(estM.BPRICE) + ",
		M2BP= " + CStr(estM.M2BP) + ",M2EBP= " + CStr(estM.M2EBP) + ",M2MBP= " + CStr(estM.M2MBP) + ",M2LBP= " + CStr(estM.M2MBP) + ",
		M3BP= " + CStr(estM.M3BP) + ",M3EBP= " + CStr(estM.M3EBP) + ",M3MBP= " + CStr(estM.M3MBP) + ",M3LBP= " + CStr(estM.M3LBP) + "
	where EstNumber = '" + idEstnumber + "' and idEstMeters = '" + estM.idEstMeters + "'  
end", conn)
                cmd1.Transaction = tran
                If cmdEstP.ExecuteNonQuery > 0 Then
                    If cmd.ExecuteNonQuery > 0 Then
                        If cmd1.ExecuteNonQuery > 0 Then
                            MsgBox("Successful")
                            tran.Commit()
                            Return True
                        Else
                            MsgBox("Error Check the data.")
                            tran.Rollback()
                            Return False
                        End If
                    End If
                Else
                    MsgBox("Error Check the data.")
                    tran.Rollback()
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message())
                Return False
            Finally
                desconectar()
            End Try
        Else
            MessageBox.Show("Plaese select a " + If(estM.idTypeScf = "-1", " Type Scaffold", If(estM.idEstCost = "-1", " Cost By Costumer", "Cost By Costumer")), "Important", MessageBoxButtons.OK)
            Return False
        End If
    End Function

    Public Function deleteEstimation(ByVal controlNumber As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if(select COUNT(*) from scfEstimation where EstNumber = '" + controlNumber + "')>0
begin
	delete from scfEstimation where EstNumber = '" + controlNumber + "' 
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class
