Imports System.Data.SqlClient

Public Class Expences
    Dim mtdJobs As MetodosJobs = New MetodosJobs()
    Dim idExpenceActualizar As String

    Private Sub Expences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdJobs.buscarExpences(tblExpences)
        limpiarCampos()
        activarCampos(False)
        btnUbdate.Enabled = False
        btnCancel.Enabled = False
    End Sub
    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Me.Close()
        ' Me.Finalize()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Add" Then
            btnSave.Text = "Save"
            btnCancel.Enabled = True
            btnUbdate.Enabled = False
            activarCampos(True)
            limpiarCampos()
        Else
            mtdJobs.insertExpence(txtExpenceCode.Text, txtDescription.Text)
            limpiarCampos()
            activarCampos(False)
            mtdJobs.buscarExpences(tblExpences)
            btnSave.Text = "Save"
            btnUbdate.Enabled = False
            btnCancel.Enabled = False
        End If

    End Sub

    Private Sub activarCampos(ByVal flag As Boolean)
        If flag Then
            txtDescription.Enabled = True
            txtExpenceCode.Enabled = True
        Else
            txtDescription.Enabled = False
            txtExpenceCode.Enabled = False
        End If


    End Sub

    Private Sub limpiarCampos()
        txtDescription.Text = ""
        txtExpenceCode.Text = ""
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If btnSave.Enabled = True Then
            If MessageBox.Show("Do you want to cancel this Expece?", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                limpiarCampos()
                activarCampos(False)
                btnCancel.Enabled = False
                btnSave.Text = "Add"
            End If

        Else
            If MessageBox.Show("Do you want to lost the changes of this Expece?", "Advertence", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                limpiarCampos()
                activarCampos(False)
                btnCancel.Enabled = False
                btnUbdate.Enabled = False
                btnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnUbdate_Click(sender As Object, e As EventArgs) Handles btnUbdate.Click
        mtdJobs.actualizarExpence(idExpenceActualizar, txtExpenceCode.Text, txtDescription.Text)
        btnSave.Enabled = True
        btnCancel.Enabled = False
        btnUbdate.Enabled = False
        limpiarCampos()
        mtdJobs.buscarExpences(tblExpences)
        activarCampos(False)
    End Sub

    Private Sub tblExpences_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tblExpences.CellMouseDoubleClick
        If tblExpences.Rows.Count() > 0 Then
            idExpenceActualizar = tblExpences.CurrentRow.Cells(0).Value.ToString
            txtExpenceCode.Text = tblExpences.CurrentRow.Cells(1).Value.ToString
            txtDescription.Text = tblExpences.CurrentRow.Cells(2).Value.ToString
            btnUbdate.Enabled = True
            btnCancel.Enabled = True
            btnSave.Enabled = False
            activarCampos(True)
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

    End Sub
End Class