Public Class Taxes
    Public task As String = ""
    Public idTask As String = ""
    Public wo As String = ""
    Public idWO As String = ""
    Public po As String = ""
    Public job As String = ""
    Private Sub Taxes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTask.Text = If(wo = "", "00000000", wo) + "-" + If(task = "", "0000", task)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
End Class