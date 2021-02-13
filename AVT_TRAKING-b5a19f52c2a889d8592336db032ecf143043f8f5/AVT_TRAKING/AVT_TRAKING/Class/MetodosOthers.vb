Imports System.Data.SqlClient

Public Class MetodosOthers
    Inherits ConnectioDB

    Public Function llenarListTyposEmployees(ByVal list As ListBox) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select name from typeEmployee", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim listR As New List(Of String)
            While reader.Read()
                list.Items.Add(reader(0))
                listR.Add(reader(0))
            End While
            Return listR
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub agregarTypeEmployee(ByVal type As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into typeEmployee values ('" + type + "')", conn)
            If cmd.ExecuteNonQuery Then
                Console.WriteLine("entro " + type)
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Sub deleteTypeEmployee(ByVal type As String)
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from typeEmployee where name = '" + type + "'", conn)
            If cmd.ExecuteNonQuery Then
                Console.WriteLine("entro " + type)
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Public Function updateTypeEmploye(ByVal ItemN As String, ByVal ItemV As String) As Boolean
        Try
            conectar()
            Dim cmd1 As New SqlCommand("update typeEmployee set name = '" + ItemN + "' where name = '" + ItemV + "'", conn)
            Dim cmd2 As New SqlCommand("update employees set typeEmployee = '" + ItemN + "' where typeEmployee = '" + ItemV + "'", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery Then
                If cmd2.ExecuteNonQuery >= 0 Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    '=================================================================================================================
    '=================================================================================================================
    '=================================================================================================================

    Public Function llenarListExpCodes(ByVal list As ListView) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select idExpCode, name from expcode", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim listR As New List(Of String)

            While reader.Read()
                Dim item As New ListViewItem()
                item.Text = reader("idExpCode")
                item.SubItems.Add(reader("name"))
                list.Items.Add(item)
                listR.Add(reader(0))
            End While
            Return listR
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function addExpCode(ByVal number As String, ByVal name As String) As ListViewItem
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into expCode values (" & number & ",'" & name & "')", conn)
            Dim item As New ListViewItem
            item.Text = number
            item.SubItems.Add(name)
            If cmd.ExecuteNonQuery Then
                Return item
            Else
                Return Nothing
            End If
            desconectar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function updateExpCode(ByVal ItemN As String, ByVal ItemV As String) As Boolean
        Try
            conectar()
            Dim cmd1 As New SqlCommand("update projectOrder set expCode = '" & ItemN & "' where expCode= '" & ItemV & "'", conn)
            Dim cmd2 As New SqlCommand("update expCode set name = '" & ItemN & "' where name = '" & ItemV & "'", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery >= 0 Then
                If cmd2.ExecuteNonQuery >= 0 Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteExpCode(ByVal name As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from expCode where name = '" + name + "'", conn)
            If cmd.ExecuteNonQuery Then
                Return True
                'Console.WriteLine("entro " + name)
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    '=================================================================================================================
    '=================================================================================================================
    '=================================================================================================================

    Public Function llenarListWorkTMLump(ByVal list As ListView) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select name from workTMLumpSum", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim listR As New List(Of String)

            While reader.Read()
                Dim item As New ListViewItem()
                item.Text = reader("name")
                list.Items.Add(item)
                listR.Add(reader(0))
            End While
            Return listR
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function addWTMLS(ByVal name As String) As ListViewItem
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into workTMLumpSum values ('" & name & "')", conn)
            Dim item As New ListViewItem
            item.Text = name
            If cmd.ExecuteNonQuery Then
                Return item
            Else
                Return Nothing
            End If
            desconectar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function updateWTMLS(ByVal ItemN As String, ByVal ItemV As String) As Boolean
        Try
            conectar()
            Dim cmd1 As New SqlCommand("update workTMLumpSum set name= '" & ItemN & "' where name = '" & ItemV & "'", conn)
            Dim cmd2 As New SqlCommand("update job set workTMLumpSum= '" & ItemN & "' where workTMLumpSum = '" & ItemV & "'", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery >= 0 Then
                If cmd2.ExecuteNonQuery >= 0 Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteWTMLS(ByVal name As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from workTMLumpSum where name = '" & name & "'", conn)
            If cmd.ExecuteNonQuery Then
                Return True
                'Console.WriteLine("entro " + name)
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    '=================================================================================================================
    '=================================================================================================================
    '=================================================================================================================

    Public Function llenarCostDistrinbution(ByVal list As ListView) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select idCostdistribution  from costDistribution", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim listR As New List(Of String)

            While reader.Read()
                Dim item As New ListViewItem()
                item.Text = reader("idCostdistribution")
                list.Items.Add(item)
                listR.Add(reader(0))
            End While
            Return listR
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function addCostDistribution(ByVal number As String) As ListViewItem
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into costDistribution values ('" & number & "','')", conn)
            Dim item As New ListViewItem
            item.Text = number
            If cmd.ExecuteNonQuery Then
                Return item
            Else
                Return Nothing
            End If
            desconectar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function updateCostDistribution(ByVal ItemN As String, ByVal ItemV As String) As Boolean
        Try
            conectar()

            Dim cmd1 As New SqlCommand("update costDistribution set idCostDistribution = " + ItemN + " where idCostDistribution = " + ItemV + " ", conn)
            Dim cmd2 As New SqlCommand("update job set costDistribution = '" + ItemN + "' where costDistribution = '" + ItemV + "'", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery >= 0 Then
                If cmd2.ExecuteNonQuery >= 0 Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteCostDostribution(ByVal number As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from costDistribution where idCostDistribution = " & number, conn)
            If cmd.ExecuteNonQuery Then
                Return True
                'Console.WriteLine("entro " + name)
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

    '=================================================================================================================
    '=================================================================================================================
    '=================================================================================================================

    Public Function llenarCostCode(ByVal list As ListView) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select idCostCode  from costCode", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim listR As New List(Of String)

            While reader.Read()
                Dim item As New ListViewItem()
                item.Text = reader("idCostCode")
                list.Items.Add(item)
                listR.Add(reader(0))
            End While
            Return listR
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function addCostCode(ByVal number As String) As ListViewItem
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into costCode values ('" & number & "','')", conn)
            Dim item As New ListViewItem
            item.Text = number
            If cmd.ExecuteNonQuery Then
                Return item
            Else
                Return Nothing
            End If
            desconectar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function updateCostCode(ByVal ItemN As String, ByVal ItemV As String) As Boolean
        Try
            conectar()

            Dim cmd1 As New SqlCommand("update costCode set idCostCode = " + ItemN + " where idCostCode = " + ItemV, conn)
            Dim cmd2 As New SqlCommand("update job set costCode = " + ItemN + " where costCode = " + ItemV, conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd1.Transaction = tran
            cmd2.Transaction = tran
            If cmd1.ExecuteNonQuery >= 0 Then
                If cmd2.ExecuteNonQuery >= 0 Then
                    tran.Commit()
                    Return True
                Else
                    tran.Rollback()
                    Return False
                End If
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function deleteCostCode(ByVal number As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from costCode where idCostCode = " & number, conn)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function

End Class