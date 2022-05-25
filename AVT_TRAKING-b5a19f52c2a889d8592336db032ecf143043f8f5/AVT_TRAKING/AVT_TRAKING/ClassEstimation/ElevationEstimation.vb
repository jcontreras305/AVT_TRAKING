Imports System.Data.SqlClient
Public Class ElevationEstimation
    Inherits ConnectioDB
    Public Function selectElevationSCF(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select elevation as 'elevationID',elevation,[percent] from factorElevationSCF", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("elevationID"), dr("elevation"), dr("percent"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function
    Public Function selectElevationPaint(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("select elevation as 'elevationID',elevation,[percent] from factorElevationPaint", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            tbl.Rows.Clear()
            While dr.Read()
                tbl.Rows.Add(dr("elevationID"), dr("elevation"), dr("percent"))
            End While
            dr.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function saveUpdateElevationSCF(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flagTran As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("ElevationSCF").Value IsNot Nothing And row.Cells("ElevationSCF").Value <> "" Then
                    Dim cmd As New SqlCommand("if (select COUNT(*) from factorElevationSCF where elevation = " + CStr(row.Cells("ElevationSCF").Value) + ")=0
                begin 
	                insert into factorElevationSCF values(" + CStr(row.Cells("ElevationSCF").Value) + "," + CStr(row.Cells("IncrementSCF").Value) + ")
                end
                else
                begin
	                update factorElevationSCF set elevation = " + CStr(row.Cells("ElevationSCF").Value) + " ,[percent]= " + CStr(row.Cells("IncrementSCF").Value) + " where elevation = " + If(CStr(row.Cells("idElevationSCF").Value) = "" Or row.Cells("idElevationSCF").Value Is Nothing, If(CStr(row.Cells("idElevationSCF").Value) = "", "NULL", row.Cells("idElevationSCF").Value), CStr(row.Cells("ElevationSCF").Value)) + "
                end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flagTran = True
                    Else
                        flagTran = False
                        Exit For
                    End If
                End If
            Next
            If flagTran Then
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
    Public Function saveUpdateElevationPaint(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flagTran As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("ElevationPaint").Value IsNot Nothing And CStr(row.Cells("ElevationPaint").Value) <> "" Then
                    Dim cmd As New SqlCommand("if (select COUNT(*) from factorElevationPaint where elevation = " + CStr(row.Cells("ElevationPaint").Value) + ")=0
                begin 
	                insert into factorElevationPaint values(" + CStr(row.Cells("ElevationPaint").Value) + "," + CStr(row.Cells("Increment").Value) + ")
                end
                else
                begin
	                update factorElevationPaint set elevation = " + CStr(row.Cells("ElevationPaint").Value) + " ,[percent]= " + CStr(row.Cells("Increment").Value) + " where elevation = " + If(CStr(row.Cells("idElevationPaint").Value) = "" Or row.Cells("idElevationPaint").Value Is Nothing, If(CStr(row.Cells("ElevationPaint").Value) = "", "Null", CStr(row.Cells("ElevationPaint").Value)), CStr(row.Cells("ElevationPaint").Value)) + "
                end", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flagTran = True
                    Else
                        flagTran = False
                        Exit For
                    End If
                End If
            Next
            If flagTran Then
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

    Public Function deleteElevationSCF(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("idElevationSCF").Value IsNot Nothing Then
                    Dim cmd As New SqlCommand("delete from factorElevationSCF where elevation = " + row.Cells("idElevationSCF").Value.ToString() + "", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
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
    Public Function deleteElevationPaint(ByVal tbl As DataGridView) As Boolean
        Try
            conectar()
            Dim tran As SqlTransaction
            tran = conn.BeginTransaction
            Dim flag As Boolean = True
            For Each row As DataGridViewRow In tbl.SelectedRows()
                If row.Cells("idElevationPaint").Value IsNot Nothing Then
                    Dim cmd As New SqlCommand("delete from factorElevationPaint where elevation = " + row.Cells("idElevationPaint").Value.ToString() + "", conn)
                    cmd.Transaction = tran
                    If cmd.ExecuteNonQuery > 0 Then
                        flag = True
                    Else
                        flag = False
                        Exit For
                    End If
                Else
                    flag = True
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
    Public Function llenarComboElvSCF(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim dt As New Data.DataTable
            dt.Columns.Add("elevation")
            dt.Columns.Add("percent")
            Dim cmd As New SqlCommand("select elevation,[percent] from factorElevationSCF", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("elevation"))
                dt.Rows.Add(dr("elevation"), dr("percent"))
            End While
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
            End If
            dr.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
    Public Function llenarComboElvPaint(ByVal cmb As ComboBox) As Data.DataTable
        Try
            conectar()
            Dim dt As New Data.DataTable
            dt.Columns.Add("elevation")
            dt.Columns.Add("percent")
            Dim cmd As New SqlCommand("select elevation,[percent] from factorElevationPaint", conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Dim item As String = If(cmb.SelectedItem Is Nothing, "", cmb.SelectedItem.ToString())
            cmb.Items.Clear()
            While dr.Read()
                cmb.Items.Add(dr("elevation"))
                dt.Rows.Add(dr("elevation"), dr("percent"))
            End While
            If item <> "" Then
                cmb.SelectedItem = cmb.Items(cmb.FindString(item))
            End If
            dr.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        Finally
            desconectar()
        End Try
    End Function
End Class
