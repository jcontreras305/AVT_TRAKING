﻿Imports System.Runtime.InteropServices
Public Class Renta
    Private Sub Renta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Dim renta As MetodosRenta = New MetodosRenta


    Public Sub MostrarDatos()
        renta.ConsultaRenta("select * from renta")
        Me.DataGridView1.DataSource = renta.ds.Tables("renta")
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New All_Tables
        a.Show()
        Me.Finalize()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MostrarDatos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim agregar As String = "insert into renta values (" + txtPrecio.Text + ",'" + txtHerramienta.Text + "','" +
        txtMaterial.Text + ",'" + txtHorasRenta.Text + ",'" + txtCanHorasH.Text + ",'" + txtCanHorasM.Text + "')"

        If (renta.InsertarRenta(agregar)) Then
            MessageBox.Show("Datos agregados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al agregar")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        txtPrecio.Text = dgv.Cells(0).Value.ToString()
        txtHerramienta.Text = dgv.Cells(1).Value.ToString()
        txtMaterial.Text = dgv.Cells(2).Value.ToString()
        txtHorasRenta.Text = dgv.Cells(3).Value.ToString()
        txtCanHorasH.Text = dgv.Cells(4).Value.ToString()
        txtCanHorasM.Text = dgv.Cells(5).Value.ToString()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub


    Private Sub TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles TitleBar.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
        btnMaximize.Visible = False
        btnRestore.Visible = True
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        WindowState = FormWindowState.Normal
        btnRestore.Visible = False
        btnMaximize.Visible = True
    End Sub
End Class