Imports System.Data.SqlClient

Public Class MetodosOthers
    Inherits ConnectioDB

    Public Function llenarCbmTypeEmployes(ByVal cmbTypeEmployes As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("Select name from typeEmployee", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            Dim flag As Boolean = False
            While reader.Read()
                flag = True
                cmbTypeEmployes.Items.Add(reader("name"))
            End While
            desconectar()
            Return flag
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

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

    Public Function llenarCmbExpCodes(ByVal cmbExpCodes As ComboBox) As Boolean
        Try
            cmbExpCodes.Items.Clear()
            conectar()
            Dim cmd As New SqlCommand("select idExpCode, name from expCode", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            Dim dato As String = ""
            While reader.Read()
                dato = reader("idExpCode").ToString + " " + reader("name")
                cmbExpCodes.Items.Add(dato)
            End While
            If cmbExpCodes.Items.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

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

    Public Function llenarCmbWokTMLump(ByVal cmbWorkTMLump As ComboBox) As Boolean
        Try
            cmbWorkTMLump.Items.Clear()
            conectar()
            Dim cmd As New SqlCommand("select name from workTMLumpSum", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                cmbWorkTMLump.Items.Add(reader("name"))
            End While
            If cmbWorkTMLump.Items.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

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

    Public Function llenarCmbCostDistribution(ByVal cmbCostDistribution As ComboBox) As Boolean
        Try
            cmbCostDistribution.Items.Clear()
            conectar()
            Dim cmd As New SqlCommand("select idCostdistribution  from costDistribution", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                cmbCostDistribution.Items.Add(reader("idCostdistribution "))
            End While
            If cmbCostDistribution.Items.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

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

    Public Function llenarCmbCostCode(ByVal cmbCostCodeas As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select idCostCode from costCode", conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                cmbCostCodeas.Items.Add(reader("idCostCode"))
            End While
            If cmbCostCodeas.Items.Count > 0 Then
                Return True
            Else
                Return False
            End If
            desconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function


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

    Public Function primerDiaDeLaSemana(ByVal fecha As Date) As Date
        While fecha.DayOfWeek <> DayOfWeek.Monday
            fecha.AddDays(-1)
        End While
        Return fecha
    End Function

    Public Function llenarImageClientTable(ByVal tabla As DataGridView) As Boolean
        Try
            Dim flag As Boolean = False
            conectar()
            Dim cmd As New SqlCommand("select name, img, imgDefault from imageClient", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tabla.Rows.Clear()
            While dr.Read()
                tabla.Rows.Add(dr("name"), dr("img"), If(dr("imgDefault") = 0, False, True))
                flag = True
            End While
            Return False
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveImageClient(ByVal name As String, ByVal byteImage() As Byte, ByVal defaultImg As Boolean) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
insert into imageClient(name,img,imgDefault)  values(@name,@img,@imgDefault)
", conn)
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 30).Value = name
            cmd.Parameters.Add("@img", SqlDbType.Image).Value = byteImage.ToArray()
            cmd.Parameters.Add("@imgDefault", SqlDbType.Char, 1).Value = If(defaultImg = True, "1", "0")
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Succesfull")
                Return True
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            MsgBox("Error")
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function updateImge(ByVal lastName As String, ByVal newName As String, ByVal img() As Byte, ByVal defaultImg As Boolean) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update imageClient set name = @name1 ,img = @img1 ,imgDefault = @imgDefault1 where name = '" + lastName + "'", conn)
            cmd.Parameters.Add("@name1", SqlDbType.VarChar, 30).Value = newName
            cmd.Parameters.Add("@img1", SqlDbType.Image).Value = img.ToArray()
            cmd.Parameters.Add("@imgDefault1", SqlDbType.Char, 1).Value = If(defaultImg = True, "1", "0")
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Succesfull")
                Return True
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteImage(ByVal name As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from imageClient where name = '" + name + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
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
End Class