Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Diagnostics
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
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
            list.Items.Clear()
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
            If cmd.ExecuteNonQuery > 0 Then
                Return item
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
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

    '=================================================================================================================
    '=================================================================================================================
    '=================================================================================================================
    Public Function llenarComboMaterialClass(ByVal cmb As ComboBox) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select code, description from materialClass", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("code") + " " + dr("description"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarListMatClasss(ByVal list As ListView) As List(Of String)
        Try
            conectar()
            Dim cmd As New SqlCommand("select code,description from materialClass", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim lstMC As New List(Of String)
            list.Items.Clear()
            While dr.Read()
                Dim item As New ListViewItem()
                item.Text = dr("code")
                item.SubItems.Add(dr("description"))
                list.Items.Add(item)
                lstMC.Add(dr("code"))
            End While
            Return lstMC
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectMaterialCodes() As Data.DataTable
        Try
            conectar()
            Dim cmd As New SqlCommand("select code,description from materialClass", conn)
            Dim dt As New DataTable
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            Else
                dt.Columns.Add("code")
                dt.Columns.Add("description")
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function addMatClass(ByVal classM As String, ByVal desc As String) As ListViewItem
        Try
            conectar()
            Dim cmd As New SqlCommand("insert into materialClass values ('" + classM + "','" + desc + "')", conn)
            Dim item As New ListViewItem
            item.Text = classM
            item.SubItems.Add(desc)
            If cmd.ExecuteNonQuery > 0 Then
                Return item
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function addMatClass(ByVal tbl As DataTable) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataRow In tbl.Rows
                Dim cmd As New SqlCommand("if not exists (select * from materialClass where code = '" + row.ItemArray(0).ToString() + "')
begin 
	insert into materialClass values ('" + row.ItemArray(0).ToString() + "','" + row.ItemArray(1) + "')
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery = 0 Then
                    If DialogResult.No = MessageBox.Show("The MAterial Class '" + row.ItemArray(0) + "' was not inserted, it is likely that exist a Class with this Name exists. " + vbCrLf + "Wold you like to continue inserting the other Classes?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) Then
                        flag = False
                        Exit For
                    End If

                End If
            Next
            If flag Then
                tran.Commit()
                Return True
            Else
                tran.Rollback()
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function updateMatClass(ByVal matclass As String, ByVal matDesc As String, ByVal lastMatClass As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update materialClass set code = '" + matclass + "' , description = '" + matDesc + "' where code = '" + lastMatClass + "'", conn)
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
    Public Function deleteMatClass(ByVal matClass As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("update material set code = NULL where code = '" + matClass + "'", conn)
            Dim cmd1 As New SqlCommand("delete from materialClass where code = '" + matClass + "'", conn)
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction()
            cmd.Transaction = tran
            cmd1.Transaction = tran
            If cmd.ExecuteNonQuery() >= 0 Then
                If cmd1.ExecuteNonQuery > 0 Then
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
            Return False
        Finally
            desconectar()
        End Try
    End Function

    '=================================================================================================================
    '=================================================================================================================
    '=================================================================================================================
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

    Public Function llenarComboImage(ByVal cmb As ComboBox) As List(Of Byte())
        Try
            conectar()
            Dim list As New List(Of Byte())
            Dim cmd As New SqlCommand("select photo, companyName from clients ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            While dr.Read()
                If dr("photo") Is DBNull.Value Then
                    Dim img As Image = Global.AVT_TRAKING.My.Resources.NoImage
                    list.Add(imageToByte(img))
                Else
                    list.Add(dr("photo"))
                End If
                cmb.Items.Add(dr("companyName"))
            End While
            dr.Close()
            Return list
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectOwnEmail() As String()
        Try
            conectar()
            Dim cmd As New SqlCommand("Select * from ownEmail", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim ownemail As String = ""
            Dim ownpass As String = ""
            While dr.Read()
                ownemail = dr("email")
                ownpass = dr("pass")
                Exit While
            End While
            Dim datos() As String = {ownemail, ownpass}
            dr.Close()
            Return datos
        Catch ex As Exception
            MsgBox(ex.Message())
            Return {"", ""}
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectEmails(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("Select * from emails", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("email"), dr("name"), dr("status"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateOwnEmail(ByVal email As String, ByVal pass As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("If (Select count(*) from ownEmail) = 0
begin
	insert into ownEmail values ('" + email + "','" + pass + "')
end 
else if (select count(*) from ownEmail)>0
begin
	update ownEmail set email = '" + email + "' ,pass = '" + pass + "'
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return True
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateOtherEmail(ByVal emailN As String, ByVal NameN As String, ByVal Status As Boolean, ByVal email As String, ByVal name As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select count(*) from emails where email = '" + email + "' and name = '" + name + "')=0
begin
	insert into emails values ('" + emailN + "','" + NameN + "', " + If(Status, "1", "0") + ")
end 
else if (select count(*) from emails where email = '" + email + "' and name = '" + name + "')>0
begin
	update emails set email = '" + emailN + "' ,name = '" + NameN + "', status = " + If(Status, "1", "0") + " where email = '" + email + "' and name = '" + name + "'
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Successful")
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return True
        Finally
            desconectar()
        End Try
    End Function
    Public Function deleteOwnEmail() As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete * from ownEmail")
            If cmd.ExecuteNonQuery Then
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
    Public Function deleteOtherEmail(ByVal email As String, ByVal name As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("delete from emails where email = '" + email + "' and name = '" + name + "'", conn)
            If cmd.ExecuteNonQuery > 0 Then
                MsgBox("Succesfull")
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
    Public Function llenarTablaEmailReports(ByVal tbl As DataGridView, ByVal reportName As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select em.email , 
em.name , 
isnull( (select lem.statusSend from listEmailReport as lem where lem.email = em.email and lem.reportName='" + reportName + "'),0) as 'statusSend'
from emails as em where em.status = 1 ", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("email"), dr("name"), dr("statusSend"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateEmailReport(ByVal tbl As DataGridView, ByVal reportName As String, ByVal estatus As Boolean) As Boolean
        Try
            conectar()
            Dim flag As Boolean = True
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            For Each row As DataGridViewRow In tbl.SelectedRows()
                Dim cmd As New SqlCommand("
if (select COUNT(*) from ReportEmail where reportName = '" + reportName + "')=0
begin 
	insert into ReportEmail values ('" + reportName + "','','')
end
if (select COUNT(*) from listEmailReport as em where email='" + row.Cells(0).Value + "' and reportName= '" + reportName + "' ) = 0
begin 
	insert into listEmailReport values ('" + reportName + "','" + row.Cells(0).Value + "'," + If(estatus, "1", "0") + ")
end
else if (select COUNT(*) from listEmailReport as em where em.email='" + row.Cells(0).Value + "' and em.reportName= '" + reportName + "' ) >0
begin 
	update listEmailReport set statusSend = " + If(estatus, "1", "0") + " where email='" + row.Cells(0).Value + "' and reportName= '" + reportName + "' 
end", conn)
                cmd.Transaction = tran
                If cmd.ExecuteNonQuery() > 0 Then
                    flag = True
                Else
                    tran.Rollback()
                    flag = False
                    Exit For
                End If
            Next
            If flag Then
                tran.Commit()
                MsgBox("Successful")
                Return flag
            Else
                tran.Rollback()
                MsgBox("Error")
                Return flag
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function saveUpdateEmailReport(ByVal row As DataGridViewRow, ByVal reportName As String) As Boolean
        Try
            conectar()

            Dim cmd As New SqlCommand("if (select COUNT(*) from ReportEmail where reportName = '" + reportName + "')=0
begin 
	insert into ReportEmail values ('" + reportName + "','','')
end
if (select COUNT(*) from listEmailReport as em where email='" + row.Cells(0).Value + "' and reportName= '" + reportName + "' ) = 0
begin 
	insert into listEmailReport values ('" + reportName + "','" + row.Cells(0).Value + "'," + If(row.Cells(2).Value, "1", "0") + ")
end
else if (select COUNT(*) from listEmailReport as em where em.email='" + row.Cells(0).Value + "' and em.reportName= '" + reportName + "' ) >0
begin 
	update listEmailReport set statusSend = " + If(row.Cells(2).Value, "1", "0") + " where email='" + row.Cells(0).Value + "' and reportName= '" + reportName + "' 
end", conn)
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Successful")
                Return True
            Else
                MsgBox("Error")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectSubjectEmail(ByVal reportName As String) As String()
        Try
            conectar()
            Dim cmd As New SqlCommand("select [subject] , body from ReportEmail where reportName = '" + reportName + "'", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim email() As String = {"", ""}
            While dr.Read()
                email(0) = If(dr("subject") Is DBNull.Value, "", dr("subject"))
                email(1) = If(dr("body") Is DBNull.Value, "", dr("body"))
            End While
            dr.Close()
            Return email
        Catch ex As Exception
            MsgBox(ex.Message())
            Return {"", ""}
        End Try
    End Function
    Public Function saveUpdateSubjet(ByVal reportName As String, ByVal subject As String, ByVal body As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("if (select COUNT(*) from ReportEmail where reportName = '" + reportName + "')=0
begin 
	insert into ReportEmail values ('" + reportName + "','" + subject + "','" + body + "')
end
else if (select COUNT(*) from ReportEmail where reportName = '" + reportName + "')>0
begin
	update ReportEmail set [subject] = '" + subject + "' , body = '" + body + "' where reportName = '" + reportName + "'
end", conn)
            If cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function sendEmail(ByVal ownEmail As String, ByVal pswrdOwnEmail As String, ByVal subject As String, ByVal body As String, ByVal emails As List(Of String), ByVal document As System.IO.MemoryStream) As Boolean
        Try
            Dim mail As New MailMessage
            Dim sender As New SmtpClient
            mail.To.Clear()
            mail.Body = ""
            mail.Subject = ""
            mail.Body = body
            mail.Subject = subject
            mail.IsBodyHtml = True
            For Each email As String In emails
                mail.To.Add(Trim(email))
            Next

            If System.IO.Directory.Exists("C:\TMP") Then
                Dim ArchivoPDF As New System.IO.FileStream("C:\TMP\Rerport.pdf", IO.FileMode.Create)
                ArchivoPDF.Write(document.ToArray, 0, document.ToArray.Length)
                ArchivoPDF.Flush()
                Dim doc As Net.Mail.Attachment = New Net.Mail.Attachment("C:\TMP\Rerport.pdf")
                mail.Attachments.Add(doc)
            End If
            mail.From = New MailAddress(Trim(ownEmail))
            sender.Credentials = New NetworkCredential(ownEmail, pswrdOwnEmail)
            Dim domain As String() = Trim(ownEmail).Split("@")
            sender.Host = "smtp." & domain(1)
            sender.Port = 587
            sender.EnableSsl = True
            sender.Send(mail)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Dim mail As New MailMessage
    Dim sender As New SmtpClient
    Public Function sendEmail(ByVal ownEmail As String, ByVal pswrdOwnEmail As String, ByVal subject As String, ByVal body As String, ByVal emails As List(Of String), ByVal route As String) As Boolean
        Try
            Dim domain As String() = Trim(ownEmail).Split("@")
            If domain(1) = "outlook.com" Or domain(1) = "brockgroup.com .com" Then
                Dim app As Outlook.Application
                If Process.GetProcessesByName("OUTLOOK").Count() > 0 Then 'si es > 0 la apliaccion ya esta abierta de lo contrario incializa una nueva
                    app = DirectCast(Marshal.GetActiveObject("Outlook.Application"), Outlook.Application)
                Else 'si no esta la aplicacion abierta o enlazada con el correo pasamos el correo y la contrasenia para abrirlo 
                    app = New Outlook.Application()
                    Dim ns As Outlook.NameSpace = app.GetNamespace("MAPI")
                    ns.Logon(ownEmail, pswrdOwnEmail, Missing.Value, Missing.Value)
                    ns = Nothing
                End If
                Dim OutlookMessage As Outlook.MailItem
                Try
                    OutlookMessage = app.CreateItem(Outlook.OlItemType.olMailItem) 'creamos un email nuevo 
                    Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients 'creamos la lista de correos a enviar 
                    For Each email As String In emails
                        Recipents.Add(Trim(email)) ' los agregamos
                    Next
                    OutlookMessage.Attachments.Add(route) ' adjuntamos el archivo
                    OutlookMessage.Subject = subject ' pegamos el asunto del email
                    OutlookMessage.Body = body ' pegamos el cuerpo del email
                    OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatHTML ' le asignamos un formato para ser leido en el navegador
                    OutlookMessage.Send() ' lo enviamos 
                    MsgBox("Successful") ' de no haber problemas muestra mensaje de que se a enviado
                    Return True
                Catch ex As Exception
                    MessageBox.Show("The mail could not be sent." + vbCrLf + ex.Message) 'si hay un error lo mostrara en pantalla
                    Return False
                Finally
                    OutlookMessage = Nothing
                    app = Nothing
                End Try
            Else
                Try
                    mail.To.Clear() ' limpiamos los valores por si es que aun tiene
                    mail.Body = ""
                    mail.Subject = ""
                    mail.Body = body ' asignamos el asunto del email
                    mail.Subject = subject ' asignamos el cuerpo del email
                    mail.IsBodyHtml = True ' le asignamos un formato para ser leido en el navegador
                    For Each email As String In emails 'insertamos los correos que seran los remitentes
                        mail.To.Add(Trim(email))
                    Next
                    If System.IO.File.Exists(route) Then
                        Dim doc As Net.Mail.Attachment = New Net.Mail.Attachment(route) 'inicializamos el poder agregar archivos adjuntos
                        mail.Attachments.Add(doc) ' pegamos el archivo con la ruta del archivo
                    End If
                    mail.From = New MailAddress(Trim(ownEmail)) ' agrefamos nuestras referencias 
                    sender.Credentials = New NetworkCredential(Trim(ownEmail), Trim(pswrdOwnEmail)) ' correo del emisor y su contrasenia

                    If domain(1) = "gmail.com" Then ' virificamos cual es el dominio del correo emisor 
                        sender.Host = "smtp." & domain(1) ' asignamos el dominio del cual sera enviado el email
                        sender.EnableSsl = True 'activamos la seguridad del mensaje 
                        sender.Port = 587 ' asignamos el puerto de salida
                    ElseIf domain(1) = "outlook.com" Then
                        sender.Host = "smtp-mail." & domain(1)
                        sender.EnableSsl = True
                        sender.Port = 587
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls 'en el caso especiasl de outlook necesita de seguridad TLS (es igual que ssl pero mas seguro y nuevo)
                    Else
                        sender.Host = "smtp.mail" & domain(1)
                        sender.EnableSsl = True
                        sender.Port = 587 ' 25 o 265 
                    End If
                    sender.Send(mail) ' enviamos el correo
                    MsgBox("Successful") ' de ser enviado mostrara este mensaje 
                    Return True
                Catch ex As Exception
                    MsgBox("The mail could not be sent.")
                    mail = Nothing
                    Return False
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
End Class