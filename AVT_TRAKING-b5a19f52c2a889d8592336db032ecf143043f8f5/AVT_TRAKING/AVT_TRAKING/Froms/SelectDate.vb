Public Class SelectDate
    Dim flagExtenion As Boolean
    Dim fechaStart, fechaEnd As Date
    Public HWPE As Boolean
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
        If hwpe Then
            Dim hwpe As HoursWeekPerEmployees = CType(Owner, HoursWeekPerEmployees)
            If fechaStart <> fechaEnd Then
                hwpe.txtFindFecha.Text = txtFechaStart.Text + " to " + txtFechaEnd.Text()
            Else
                hwpe.txtFindFecha.Text = txtFechaStart.Text
            End If
            hwpe.fechaStart = fechaStart
            hwpe.fechaEnd = fechaEnd
            Me.Close()
        Else
            Dim tvt As TagsValidationTable = CType(Owner, TagsValidationTable)
            tvt.fechaStart = fechaStart
            tvt.txtFecha.Text = fechaStart.ToShortDateString()
            Me.Close()
        End If
    End Sub

    Private Sub mtcCalendar_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mtcCalendar.DateChanged
        fechaStart = mtcCalendar.SelectionStart.ToShortDateString()
        fechaEnd = mtcCalendar.SelectionEnd.ToShortDateString()
        txtFechaStart.Text = If(mtcCalendar.SelectionStart.Month < 10, "0" + mtcCalendar.SelectionStart.Month.ToString(), mtcCalendar.SelectionStart.Month.ToString()) + "/" + If(mtcCalendar.SelectionStart.Day < 10, "0" + mtcCalendar.SelectionStart.Day.ToString(), mtcCalendar.SelectionStart.Day.ToString()) + "/" + mtcCalendar.SelectionStart.Year.ToString()
        txtFechaEnd.Text = If(mtcCalendar.SelectionEnd.Month < 10, "0" + mtcCalendar.SelectionEnd.Month.ToString(), mtcCalendar.SelectionEnd.Month.ToString()) + "/" + If(mtcCalendar.SelectionEnd.Day < 10, "0" + mtcCalendar.SelectionEnd.Day.ToString(), mtcCalendar.SelectionEnd.Day.ToString()) + "/" + mtcCalendar.SelectionEnd.Year.ToString()
    End Sub
End Class