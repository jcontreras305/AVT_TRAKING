Imports System.Data.SqlClient
Public Class EstimationSC
    Inherits ConnectioDB

    Dim _list As New List(Of String)

    Dim _controlNum, _idAux, _unit, _location As String
    Dim _type, _descks, _groundheigth, _elevator As Integer
    Dim _daysActive, _width, _heigth, _length As Double

    Public Sub Clear()
        _list.Clear()
        _controlNum = ""
        _idAux = ""
        _unit = ""
        _location = ""
        _type = -1
        _descks = 0
        _groundheigth = 0
        _elevator = 0
        _daysActive = 0.0
        _width = 0.0
        _heigth = 0.0
        _length = 0.0
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
    Public Property controlNum() As String
        Get
            If _controlNum = Nothing Then
                Return ""
            Else
                Return _controlNum
            End If
        End Get
        Set(ByVal controlNum As String)
            _controlNum = controlNum
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
    Public Property type() As Integer
        Get
            If _type = Nothing Then
                Return -1
            Else
                Return _type
            End If
        End Get
        Set(ByVal type As Integer)
            _type = type
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
    Public Property elevator() As Integer
        Get
            If _elevator = Nothing Then
                Return 0
            Else
                Return _elevator
            End If
        End Get
        Set(ByVal elevator As Integer)
            _elevator = elevator
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

    Public Function SelectEstCostSC(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from ScafEstCost", conn)
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

    Public Function SaveEstCostSC(ByVal tbl As DataGridView) As Boolean
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
if (select COUNT(*) from scafEstCost where idEstCost = " + CStr(Row.Cells(0).Value) + ")=0
begin
    insert into scafEstCost values(" + CStr(Row.Cells(0).Value) + "," + CStr(Row.Cells(1).Value) + "," + CStr(Row.Cells(2).Value) + ",'" + CStr(Row.Cells(3).Value) + "'," + CStr(Row.Cells(4).Value) + "," + CStr(Row.Cells(5).Value) + "," + CStr(Row.Cells(6).Value) + "," + CStr(Row.Cells(7).Value) + "," + CStr(Row.Cells(8).Value) + "," + CStr(Row.Cells(9).Value) + "," + CStr(Row.Cells(10).Value) + "," + CStr(Row.Cells(11).Value) + ",
    " + CStr(Row.Cells(12).Value) + "," + CStr(Row.Cells(13).Value) + "," + CStr(Row.Cells(14).Value) + "," + CStr(Row.Cells(15).Value) + "," + CStr(Row.Cells(16).Value) + "," + CStr(Row.Cells(17).Value) + "," + CStr(Row.Cells(18).Value) + "," + CStr(Row.Cells(19).Value) + "," + CStr(Row.Cells(20).Value) + ",
    " + CStr(Row.Cells(21).Value) + "," + CStr(Row.Cells(22).Value) + "," + CStr(Row.Cells(23).Value) + "," + CStr(Row.Cells(24).Value) + "," + CStr(Row.Cells(25).Value) + "," + CStr(Row.Cells(26).Value) + "," + CStr(Row.Cells(27).Value) + "," + CStr(Row.Cells(28).Value) + "," + CStr(Row.Cells(29).Value) + "," + CStr(Row.Cells(30).Value) + ",
    " + CStr(Row.Cells(31).Value) + "," + CStr(Row.Cells(32).Value) + "," + CStr(Row.Cells(33).Value) + "," + CStr(Row.Cells(34).Value) + "," + CStr(Row.Cells(35).Value) + "," + CStr(Row.Cells(36).Value) + "," + CStr(Row.Cells(37).Value) + "," + CStr(Row.Cells(38).Value) + "," + CStr(Row.Cells(39).Value) + "," + CStr(Row.Cells(40).Value) + ",
    " + CStr(Row.Cells(41).Value) + "," + CStr(Row.Cells(42).Value) + "," + CStr(Row.Cells(43).Value) + "," + CStr(Row.Cells(44).Value) + "," + CStr(Row.Cells(45).Value) + "," + CStr(Row.Cells(46).Value) + "," + CStr(Row.Cells(47).Value) + "," + CStr(Row.Cells(48).Value) + "," + CStr(Row.Cells(49).Value) + "," + CStr(Row.Cells(50).Value) + ",
    " + CStr(Row.Cells(51).Value) + "," + CStr(Row.Cells(52).Value) + "," + CStr(Row.Cells(53).Value) + "," + CStr(Row.Cells(54).Value) + "," + CStr(Row.Cells(55).Value) + "," + CStr(Row.Cells(56).Value) + "," + CStr(Row.Cells(57).Value) + "," + CStr(Row.Cells(58).Value) + "," + CStr(Row.Cells(59).Value) + "," + CStr(Row.Cells(60).Value) + ",
    " + CStr(Row.Cells(61).Value) + "," + CStr(Row.Cells(62).Value) + ") 
end
else if (select COUNT(*) from scafEstCost where idEstCost = " + CStr(Row.Cells(0).Value) + ")>0
begin
	update ScafEstCost 
	set DECKS = " + CStr(Row.Cells(1).Value) + ",ACHT = " + CStr(Row.Cells(2).Value) + ",SCTP = '" + CStr(Row.Cells(3).Value) + "',BDRATE=" + CStr(Row.Cells(4).Value) + ",
	M3=" + CStr(Row.Cells(5).Value) + ",M2=" + CStr(Row.Cells(6).Value) + ",MA3=" + CStr(Row.Cells(7).Value) + ",MA2=" + CStr(Row.Cells(8).Value) + ",BILLINGDAYS=0,EDDAYS=" + CStr(Row.Cells(9).Value) + ",
	M3EDCHARGES=" + CStr(Row.Cells(10).Value) + ",M2EDCHARGES=" + CStr(Row.Cells(11).Value) + ",MA3EDCHARGES=" + CStr(Row.Cells(12).Value) + ",MA2EDCHARGES=" + CStr(Row.Cells(13).Value) + ",
	M3LABORBP=" + CStr(Row.Cells(14).Value) + ",M3MATBP=" + CStr(Row.Cells(15).Value) + ",M3EQBP=" + CStr(Row.Cells(16).Value) + ",M3LABORDP=" + CStr(Row.Cells(17).Value) + ",M3MATDP=" + CStr(Row.Cells(18).Value) + ",M3EQDP=" + CStr(Row.Cells(19).Value) + ",
	M2LABORBP=" + CStr(Row.Cells(20).Value) + ",M2MATBP=" + CStr(Row.Cells(21).Value) + ",M2EQBP=" + CStr(Row.Cells(22).Value) + ",M2LABORDP=" + CStr(Row.Cells(23).Value) + ",M2MATDP=" + CStr(Row.Cells(24).Value) + ",M2EQDP=" + CStr(Row.Cells(25).Value) + ",
	MA3LABORBP=" + CStr(Row.Cells(26).Value) + ",MA3MATBP=" + CStr(Row.Cells(27).Value) + ",MA3EQBP=" + CStr(Row.Cells(28).Value) + ",MA3LABORDP=" + CStr(Row.Cells(29).Value) + ",MA3MATDP=" + CStr(Row.Cells(30).Value) + ",MA3EQDP=" + CStr(Row.Cells(31).Value) + ",
	MA2LABORBP=" + CStr(Row.Cells(32).Value) + ",MA2MATBP=" + CStr(Row.Cells(33).Value) + ",MA2EQBP=" + CStr(Row.Cells(34).Value) + ",MA2LABORDP=" + CStr(Row.Cells(35).Value) + ",MA2MATDP=" + CStr(Row.Cells(36).Value) + ",MA2EQDP=" + CStr(Row.Cells(37).Value) + ",
	M3LBI=" + CStr(Row.Cells(38).Value) + ",M3MBI=" + CStr(Row.Cells(39).Value) + ",M3EBI=" + CStr(Row.Cells(40).Value) + ",M3LDI=" + CStr(Row.Cells(41).Value) + ",M3MDI=" + CStr(Row.Cells(42).Value) + ",M3EDI=" + CStr(Row.Cells(43).Value) + ",
	M2LBI=" + CStr(Row.Cells(44).Value) + ",M2MBI=" + CStr(Row.Cells(45).Value) + ",M2EBI=" + CStr(Row.Cells(46).Value) + ",M2LDI=" + CStr(Row.Cells(47).Value) + ",M2MDI=" + CStr(Row.Cells(48).Value) + ",M2EDI=" + CStr(Row.Cells(49).Value) + ",
	MA3LBI=" + CStr(Row.Cells(50).Value) + ",MA3MBI=" + CStr(Row.Cells(51).Value) + ",MA3EBI=" + CStr(Row.Cells(52).Value) + ",MA3LDI=" + CStr(Row.Cells(53).Value) + ",MA3MDI=" + CStr(Row.Cells(54).Value) + ",MA3EDI=" + CStr(Row.Cells(56).Value) + ",
	MA2LBI=" + CStr(Row.Cells(57).Value) + ",MA2MBI=" + CStr(Row.Cells(58).Value) + ",MA2EBI=" + CStr(Row.Cells(59).Value) + ",MA2LDI=" + CStr(Row.Cells(60).Value) + ",MA2MDI=" + CStr(Row.Cells(61).Value) + ",MA2EDI=" + CStr(Row.Cells(62).Value) + "
	WHERE idEstCost = " + CStr(Row.Cells(0).Value) + "
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
            Dim cmd As New SqlCommand("select idEstCost , SCTP from ScafEstCost", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader
            cmb.Items.Clear()
            cmb.Items.Add("")
            While rd.Read()
                cmb.Items.Add(CStr(rd("idEstCost")) + " " + CStr(rd("SCTP")))
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
    Public Function llenartablaEstimacion(ByVal tabla As DataTable) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select * from scfEstimation", conn)
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
            Dim cmd As New SqlCommand("select top 1 type,idAux,daysActive,unit,location,width,heigth,length,descks,groundHeigth,elevator from scfEstimation where EstNumber = '" + controlNum + "'", conn)
            Dim rd As SqlDataReader = cmd.ExecuteReader()
            While rd.Read()
                _controlNum = controlNum
                _type = If(rd("type") Is DBNull.Value, -1, rd("type"))
                _idAux = rd("idAux")
                _daysActive = rd("daysActive")
                _unit = rd("unit")
                _location = rd("location")
                _width = rd("width")
                _heigth = rd("heigth")
                _length = rd("length")
                _descks = rd("descks")
                _groundheigth = rd("groundHeigth")
                _elevator = rd("elevator")
                Exit While
            End While
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveEstimation() As Boolean
        If If(type = -1, If(DialogResult.OK = MessageBox.Show("You can't selected any Saffold Type, Would you like to continue?", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning), True, False), True) Then
            Try
                conectar()
                Dim cmd As New SqlCommand("
if (select COUNT(*) from scfEstimation  where EstNumber = '" + controlNum + "')=0
begin
	insert into scfEstimation values ('" + controlNum + "'," + If(type > -1, "Null", CStr(type)) + ",'" + idAux + "'," + CStr(daysActive) + ",'" + unit + "','" + location + "'," + CStr(width) + "," + CStr(heigth) + "," + CStr(length) + "," + CStr(descks) + "," + CStr(groundheigth) + "," + CStr(elevator) + ") 
end
else if (select COUNT(*) from scfEstimation  where EstNumber = '" + controlNum + "')>0
begin 
	update scfEstimation set type = " + CStr(type) + " ,idAux = '" + idAux + "',daysActive = " + CStr(daysActive) + ",unit='" + CStr(unit) + "',location='" + location + "',width=" + CStr(width) + ",heigth=" + CStr(heigth) + ",length=" + CStr(length) + ",descks=" + CStr(descks) + ",groundHeigth=" + CStr(groundheigth) + ",elevator=" + CStr(elevator) + " where EstNumber = '" + controlNum + "' 
end", conn)
                If cmd.ExecuteNonQuery > 0 Then
                    MsgBox("Successful")
                    Return True
                Else
                    MsgBox("Error Check the data.")
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message())
                Return False
            Finally
                desconectar()
            End Try
        Else
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
