Public Class SelectDate
    Dim flagExtenion As Boolean
    Dim fechaStart, fechaEnd As Date
    Private Sub SelectDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flagExtenion = False
    End Sub

    Private Sub btnAmpliar_Click(sender As Object, e As EventArgs) Handles btnAmpliar.Click
        If flagExtenion Then
            flagExtenion = False
            mtcCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.WindowState = FormWindowState.Normal
        Else
            flagExtenion = True
            mtcCalendar.CalendarDimensions = New System.Drawing.Size(4, 3)
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btnAcept_Click(sender As Object, e As EventArgs) Handles btnAcept.Click
        Dim hwpe As HoursWeekPeerEmployees = CType(Owner, HoursWeekPeerEmployees)
        hwpe.txtFindFecha.Text = fechaStart.ToShortDateString() + " to " + fechaEnd.ToShortDateString()
        hwpe.fechaStart = fechaStart
        hwpe.fechaEnd = fechaEnd
        Me.Close()
    End Sub

    Private Sub mtcCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mtcCalendar.DateChanged
        fechaStart = mtcCalendar.SelectionStart.ToShortDateString()
        fechaEnd = mtcCalendar.SelectionEnd.ToShortDateString()
        txtFechaStart.Text = mtcCalendar.SelectionStart.ToShortDateString()
        txtFechaEnd.Text = mtcCalendar.SelectionEnd.ToShortDateString()
    End Sub
End Class