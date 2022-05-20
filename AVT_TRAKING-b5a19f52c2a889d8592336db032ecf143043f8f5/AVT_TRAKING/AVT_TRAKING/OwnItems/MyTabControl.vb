Imports System.Windows.Forms
Public Class MyTabControl
    Inherits TabControl

    Public Enum Style
        Flat
        Line
    End Enum
    Public Enum ItemScaleSize
        Width
        Heigth
    End Enum

    Private _TabStyle As Style
    Private _Heigth, _Width As Integer
    Private _BackColor() As Color = {Color.LightBlue, Color.LightGreen, Color.LightPink, Color.LightYellow, Color.LightGray, Color.Salmon, Color.LightSkyBlue, Color.LightCoral, Color.LightSteelBlue, Color.Green, Color.Yellow, Color.Blue, Color.Red, Color.Purple, Color.Orange}
    Private _ForeColor As Color = Color.Black
    Private _LinebackColor As Color = Color.Gainsboro
    Private _LineForeColor As Color = Color.FromArgb(0, 58, 115)

    Public Property TabStyle As Style
        Get
            Return _TabStyle
        End Get
        Set(value As Style)
            _TabStyle = value
            Invalidate()
        End Set
    End Property

    Public Property BackColor1 As Color()
        Get
            Return _BackColor
        End Get
        Set(value As Color())
            _BackColor = value
            Invalidate()
        End Set
    End Property

    Public Property ForeColor1 As Color
        Get
            Return _ForeColor
        End Get
        Set(value As Color)
            _ForeColor = value
            Invalidate()
        End Set
    End Property

    Public Property LinebackColor As Color
        Get
            Return _LinebackColor
        End Get
        Set(value As Color)
            _LinebackColor = value
            Invalidate()
        End Set
    End Property

    Public Property LineForeColor As Color
        Get
            Return _LineForeColor
        End Get
        Set(value As Color)
            _LineForeColor = value
            Invalidate()
        End Set
    End Property

    Public Property Heigth As Integer
        Get
            If _Heigth = Nothing Then
                Return 18
            Else
                Return _Heigth
            End If

        End Get
        Set(value As Integer)
            _Heigth = value
        End Set
    End Property

    Public Property Width1 As Integer
        Get
            If _Width = Nothing Then
                Return 100
            Else
                Return _Width
            End If

        End Get
        Set(value As Integer)
            _Width = value
        End Set
    End Property

    Public Sub New()
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(Width1, Heigth)
        _TabStyle = Style.Line
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using bitmap As New Bitmap(Width, Height)
            Using g As Graphics = Graphics.FromImage(bitmap)
                Dim contBckColor As Integer = 0
                For i = 0 To TabCount - 1
                    Dim tabRect As Rectangle = GetTabRect(i)
                    g.FillRectangle(New SolidBrush(BackColor1(contBckColor)), tabRect)
                    If TabStyle = Style.Line Then
                        g.DrawLine(New Pen(Color.FromArgb(0, 58, 115), 1), 0, tabRect.Bottom, Me.Width, tabRect.Bottom)
                    End If
                    If i = SelectedIndex Then
                        g.FillRectangle(New SolidBrush(Color.White), tabRect)
                    End If
                    g.DrawString(TabPages(i).Text, New Font("Verdana", 8.25), New SolidBrush(Color.Black), tabRect, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    contBckColor += 1
                    If contBckColor > BackColor1.Length - 1 Then
                        contBckColor = 0
                    End If
                Next
                MyBase.OnPaint(e)
                e.Graphics.DrawImage(bitmap.Clone, 0, 0)
                g.Dispose()
            End Using
        End Using

    End Sub

End Class
