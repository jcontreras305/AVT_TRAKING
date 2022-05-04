Public Class FindTagScaffold
    Public tagDis As String = ""
    Public OpenWindow As String = ""
    Dim mtdSCF As New MetodosScaffold
    Public idclient As String
    Private Sub FindTagScaffold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpFindByDate.Visible = False
            btnAccept.Enabled = False
            If OpenWindow = "Scaffold" Then
                lblTitle.Text = "Scaffold Traking"
                mtdSCF.findTags(txtFind.Text, tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            ElseIf OpenWindow = "Dismantle" Then
                lblTitle.Text = "Scaffold Dismantle"
                mtdSCF.findTagsDismantle(txtFind.Text, tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            Dim sc As scafoldTarking = CType(Owner, scafoldTarking)
            sc.tagFind = ""
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub chbFindByDate_CheckedChanged(sender As Object, e As EventArgs) Handles chbFindByDate.CheckedChanged
        If chbFindByDate.Checked Then
            dtpFindByDate.Visible = True
            txtFind.Visible = False
        Else
            dtpFindByDate.Visible = False
            txtFind.Visible = True
        End If
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        Try
            mtdSCF.findTags(txtFind.Text, tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            If OpenWindow = "Scaffold" Then
                mtdSCF.findTags(txtFind.Text, tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            ElseIf OpenWindow = "Dismantle" Then
                mtdSCF.findTagsDismantle(txtFind.Text, tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            End If
            btnAccept.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFindByDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFindByDate.ValueChanged
        Try
            If OpenWindow = "Scaffold" Then
                mtdSCF.findTags(validaFechaParaSQl(dtpFindByDate.Value), tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            ElseIf OpenWindow = "Dismantle" Then
                mtdSCF.findTagsDismantle(validaFechaParaSQl(dtpFindByDate.Value), tblFindTag, If(idclient = "ALL", "ALL", idclient), chbFindByDate.Checked)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tblFindTag_SelectionChanged(sender As Object, e As EventArgs) Handles tblFindTag.SelectionChanged, tblFindTag.MouseDoubleClick
        If tblFindTag.SelectedRows.Count > 0 Then
            btnAccept.Enabled = True
        Else
            btnAccept.Enabled = False
        End If
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Try
            Dim sc As scafoldTarking = CType(Owner, scafoldTarking)
            sc.tagFind = tblFindTag.SelectedRows(0).Cells(0).Value.ToString()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class