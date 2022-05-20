Imports System.ComponentModel
Imports System.ComponentModel.Design
Public Class MyComboBox
    Inherits ComboBox

    'Envía lso mensajes para que el método WndProc los procese 
    Private Declare Auto Function SendMessage Lib "user32.dll" (ByVal IPtr As IntPtr,
    ByVal Msg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Private Const CB_SIH As Int32 = &H153

    'Enumeramos los valores que podrá tener la propiedad ArrowStyle
    Public Enum enumArrowStyle
        Arrow3D = 0
        ArrowFlat = 1
    End Enum

    Dim varCArrowColor As Color = Color.FromArgb(255, 74, 97, 132)
    Dim varCArrowPersonalized As Boolean = False
    Dim varCArrowStyle As enumArrowStyle = enumArrowStyle.Arrow3D
    Dim varCBorderColor As Color = System.Drawing.SystemColors.ControlLightLight
    Dim varCSizeHeight As Integer = 21

    <Description("Define el color de la flecha del desplegable cuando la propiedad " &
    "ArrowPersonalized tiene el valor de 'true'."), Category("Apariencia")>
    Public Property ArrowColor() As Color
        Get
            Return varCArrowColor
        End Get
        Set(ByVal value As Color)
            varCArrowColor = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Indica si queremos que la flecha del desplegable tenga el " &
    "color personalizado que indicaremos en la propiedad ArrowColor."),
    Category("Apariencia")>
    Public Property ArrowPersonalized() As Boolean
        Get
            Return varCArrowPersonalized
        End Get
        Set(ByVal value As Boolean)
            varCArrowPersonalized = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Define el estilo de la flecha del desplegable cuando la propiedad " &
    "ArrowPersonalized tiene el valor de 'true'."), Category("Apariencia")>
    Public Property ArrowStyle() As enumArrowStyle
        Get
            Return varCArrowStyle
        End Get
        Set(ByVal value As enumArrowStyle)
            varCArrowStyle = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Color del borde del control cuando la propiedad FlatStyle " &
    "tenga el valor de 'Standard'."), Category("Apariencia")>
    Public Property BorderColor() As Color
        Get
            Return varCBorderColor
        End Get
        Set(ByVal value As Color)
            varCBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    <Description("Alto del control en píxeles."), Category("Diseño")>
    Public Property SizeHeight() As Integer
        Get
            If varCSizeHeight < 6 Then
                varCSizeHeight = 6
            End If
            Return varCSizeHeight
            subSComboBoxHeight(Me, varCSizeHeight)
        End Get
        Set(ByVal value As Integer)
            If value < 6 Then
                value = 6
            End If
            varCSizeHeight = value
            subSComboBoxHeight(Me, value)
        End Set
    End Property

    'El siguente método se utiliza para modificar el alto del control
    Private Sub subSComboBoxHeight(ByVal ctlComboBox As ComboBox,
    ByVal Height As Int32)
        SendMessage(ctlComboBox.Handle, CB_SIH, -1, Height - 6)
        Me.Refresh()
    End Sub

    'En el método Resize añadimos el código para que el control sólo se pueda modificar
    'desde la propiedad SizeHeight. Si no utilizamos este código, cada vez que cambiamos
    'el tamaño del control manualmente o desde las propiedades Width y Hei el control
    'vuelve a su altura predeterminada
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        If Not Me.Height = varCSizeHeight Then
            subSComboBoxHeight(Me, varCSizeHeight)
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef Mssg As Message)
        MyBase.WndProc(Mssg)

        If Mssg.Msg = &HF And Me.FlatStyle = Windows.Forms.FlatStyle.Standard Then
            Dim varSPen As Pen = New Pen(varCBorderColor, 1)
            Dim varSRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
            Dim varSe As New PaintEventArgs(Me.CreateGraphics, varSRectangle)

            'Creamos el borde del control, antes hemos definido un pen del color de
            'la propiedad BorderColor y con el tamaño de 1 pixel.
            'Se podría también variabilizar el tamaño del borde del control.
            'También hemos definido un rectángulo del tamaño exacto del control.
            '¡OJO!, si se varibiliza el borde se tendrían que cambiar los datos en
            'el constructor del rectángulo que quedaría de la siguiente forma:
            '(int(Borde/2), int(Borde/2), Me.Width - Borde, Me.Height - Borde)
            varSe.Graphics.DrawRectangle(varSPen, varSRectangle)

            varSPen.Dispose()
            varSRectangle = Nothing

            'Con este código dibujaremos la flechita del desplegable según el valor
            'de las propiedades ArrowColor y ArrowStyle.
            If varCArrowPersonalized Then
                Dim varSWidthIni = Me.Width - 14
                Dim varSHeightIni = Int((Me.Height - 6) / 2) + 1
                If Me.Height / 2 = Int(Me.Height / 2) Then
                    varSHeightIni = varSHeightIni - 1
                End If
                Dim varSpoint1 As Point
                Dim varSpoint2 As Point
                Dim varSpoint3 As Point
                Dim varSpoint4 As Point
                Dim varSpoint5 As Point
                Dim varSpoint6 As Point
                If varCArrowStyle = enumArrowStyle.Arrow3D Then
                    varSpoint1 = New Point(varSWidthIni, varSHeightIni + 1)
                    varSpoint2 = New Point(varSWidthIni + 1, varSHeightIni)
                    varSpoint3 = New Point(varSWidthIni + 4, varSHeightIni + 3)
                    varSpoint4 = New Point(varSWidthIni + 7, varSHeightIni)
                    varSpoint5 = New Point(varSWidthIni + 8, varSHeightIni + 1)
                    varSpoint6 = New Point(varSWidthIni + 4, varSHeightIni + 5)
                Else
                    varSpoint1 = New Point(varSWidthIni, varSHeightIni + 1)
                    varSpoint2 = New Point(varSWidthIni + 1, varSHeightIni - 1)
                    varSpoint3 = New Point(varSWidthIni + 4, varSHeightIni + 3)
                    varSpoint4 = New Point(varSWidthIni + 7, varSHeightIni - 1)
                    varSpoint5 = New Point(varSWidthIni + 9, varSHeightIni + 1)
                    varSpoint6 = New Point(varSWidthIni + 4, varSHeightIni + 6)
                End If
                Dim varSPoint() As Point = {varSpoint1, varSpoint2,
                varSpoint3, varSpoint4, varSpoint5, varSpoint6}

                varSe.Graphics.FillPolygon(New SolidBrush(varCArrowColor), varSPoint)
                varSPoint = Nothing
            End If
            varSe.Dispose()
        End If
    End Sub
End Class
