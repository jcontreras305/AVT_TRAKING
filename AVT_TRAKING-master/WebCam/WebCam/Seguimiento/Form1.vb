Public Class Form1
    Dim time As Integer
    Dim img2 As Bitmap
    Dim ImgOriginal As Bitmap
    Dim ImgResultante As Bitmap


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'WebCam.Start()
        TimContrastes.Enabled = False
        Timer1.Enabled = False
        'ImgOriginal = PictureBox1.Image
        Timer2.Enabled = True
        'ImgOriginal = PictureBox1.Image


    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        WebCam.Stop()
        Timer1.Enabled = False
        TimContrastes.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        WebCam.Configuracion()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        WebCam.Start()
        TimContrastes.Enabled = False
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Image = WebCam.Imagen
        Dim img1 As Bitmap = PictureBox1.Image
        Dim img3 As Bitmap = PictureBox1.Image
        Dim Red1, Green1, Blue1, SumaX, SumaY, TotalPuntos As Integer
        Dim CentroX, CentroY, x, y, LimXDch, LimXIzq, LimYSup, LimYInf, xExp, yExp As Integer

        LimXDch = TraLimXDch.Value * TraResolucion.Value
        LimXIzq = TraLimXIzq.Value * TraResolucion.Value
        LimYSup = TraLimYSup.Value * TraResolucion.Value
        LimYInf = TraLimYInf.Value * TraResolucion.Value

        For y = 0 To img1.Height - 1 Step 20
            For x = 0 To img1.Width - 1 Step 20
                Red1 = img1.GetPixel(x, y).R
                Green1 = img1.GetPixel(x, y).G
                Blue1 = img1.GetPixel(x, y).B

                If Blue1 > (Red1 + TraTolerancia.Value) Then
                    If Blue1 > (Green1 + TraTolerancia.Value) Then

                        For yExp = y - 10 To y + 10 Step 3
                            For xExp = x - 10 To x + 10 Step 3
                                If yExp - 10 > 0 And xExp - 10 > 0 And yExp + 10 < img3.Height And xExp + 10 < img3.Width Then
                                    If img1.GetPixel(xExp, yExp).B > (img1.GetPixel(xExp, yExp).R + TraTolerancia.Value) Then
                                        If img1.GetPixel(xExp, yExp).B > (img1.GetPixel(xExp, yExp).G + TraTolerancia.Value) Then
                                            img3.SetPixel(xExp, yExp, Color.Yellow)
                                            img3.SetPixel(xExp + 1, yExp, Color.Yellow)
                                            img3.SetPixel(xExp + 1, yExp + 1, Color.Yellow)
                                            img3.SetPixel(xExp, yExp + 1, Color.Yellow)

                                            TotalPuntos = TotalPuntos + 1
                                            SumaX = SumaX + xExp
                                            SumaY = SumaY + yExp
                                        End If
                                    End If
                                End If
                            Next
        Next
                    End If

                Else
                    img3.SetPixel(x, y, Color.Black)
                End If

                If x = LimXDch Or x = LimXIzq Then
                    img3.SetPixel(x, y, Color.Red)
                    img3.SetPixel(x + 1, y, Color.Red)
                    img3.SetPixel(x + 1, y + 1, Color.Red)
                    img3.SetPixel(x, y + 1, Color.Red)

                End If
                If y = LimYSup Or y = LimYInf Then
                    img3.SetPixel(x, y, Color.Red)
                    img3.SetPixel(x + 1, y, Color.Red)
                    img3.SetPixel(x + 1, y + 1, Color.Red)
                    img3.SetPixel(x, y + 1, Color.Red)
                End If
            Next

        Next
        If SumaX <> 0 And SumaY <> 0 Then
            CentroX = (SumaX / (TotalPuntos + 1))
            CentroY = (SumaY / (TotalPuntos + 1))

            For y = CentroY To CentroY + 4
                For x = CentroX To CentroX + 4
                    If y < img3.Height Then If x < img3.Width Then img3.SetPixel(x, y, Color.HotPink)
                Next
            Next
        End If

        'Encuadre Dinámico
        Select Case (CentroX)
            Case Is > LimXDch
                RadDireDch.Checked = False
                RadDireIzq.Checked = True
            Case Is < LimXIzq
                RadDireDch.Checked = True
                RadDireIzq.Checked = False
            Case Else
                RadDireDch.Checked = True
                RadDireIzq.Checked = True
        End Select

        Select Case (CentroY)
            Case Is > LimYSup
                RadArriba.Checked = False
                RadAbajo.Checked = True
            Case Is < LimYInf
                RadArriba.Checked = True
                RadAbajo.Checked = False
            Case Else
                RadArriba.Checked = False
                RadAbajo.Checked = False
        End Select

        PictureBox1.Image = img3
        TrackBarX.Value = CentroX
        TrackBarY.Value = img3.Height - CentroY
    End Sub

   
    Private Sub TimContrastes_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimContrastes.Tick
        PictureBox1.Image = WebCam.Imagen
        ImgOriginal = PictureBox1.Image
        ImgResultante = PictureBox1.Image
        Dim Red1, Green1, Blue1, Tolerancia, SumaX, SumaY, TotalPuntos As Integer
        Dim CentroX, CentroY, x, y, LimXDch, LimXIzq, LimYSup, LimYInf As Integer

        LimXDch = TraLimXDch.Value * TraResolucion.Value
        LimXIzq = TraLimXIzq.Value * TraResolucion.Value
        LimYSup = TraLimYSup.Value * TraResolucion.Value
        LimYInf = TraLimYInf.Value * TraResolucion.Value

        For y = 0 To ImgOriginal.Height - 1 Step TraResolucion.Value
            For x = 0 To ImgOriginal.Width - 1 Step TraResolucion.Value
                Red1 = ImgOriginal.GetPixel(x, y).R
                Green1 = ImgOriginal.GetPixel(x, y).G
                Blue1 = ImgOriginal.GetPixel(x, y).B

                If (x - 10) > 0 Then
                    If ImgOriginal.GetPixel(x, y).B > (ImgOriginal.GetPixel(x - 10, y).B + TraTolerancia.Value) Then
                        ImgResultante.SetPixel(x, y, Color.Yellow)
                        ImgResultante.SetPixel(x + 1, y, Color.Yellow)
                        ImgResultante.SetPixel(x + 1, y + 1, Color.Yellow)
                        ImgResultante.SetPixel(x, y + 1, Color.Yellow)
                    Else
                        ImgResultante.SetPixel(x, y, Color.Black)
                    End If
                End If


                If x = LimXDch Or x = LimXIzq Then
                    ImgResultante.SetPixel(x, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y + 1, Color.Red)
                    ImgResultante.SetPixel(x, y + 1, Color.Red)

                End If
                If y = LimYSup Or y = LimYInf Then
                    ImgResultante.SetPixel(x, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y + 1, Color.Red)
                    ImgResultante.SetPixel(x, y + 1, Color.Red)
                End If

            Next

        Next


        PictureBox1.Image = ImgResultante
        TrackBarX.Value = CentroX
        TrackBarY.Value = ImgResultante.Height - CentroY
    End Sub

    Private Sub ButContrastes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButContrastes.Click
        WebCam.Start()
        Timer1.Enabled = False
        TimContrastes.Enabled = True

    End Sub

    Private Sub LabHash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabHash.Click
        Dim HashColor As System.Drawing.Color = Color.Pink
        LabHash.Text = HashColor.GetHue
    End Sub

    Private Sub ButHuh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButHuh.Click
        PictureBox1.Image = WebCam.Imagen
        ImgOriginal = PictureBox1.Image
        ImgResultante = PictureBox1.Image
        Dim Red1, Green1, Blue1, Tolerancia, SumaX, SumaY, TotalPuntos, Huh As Integer
        Dim CentroX, CentroY, x, y, LimXDch, LimXIzq, LimYSup, LimYInf As Integer

        LimXDch = TraLimXDch.Value * TraResolucion.Value
        LimXIzq = TraLimXIzq.Value * TraResolucion.Value
        LimYSup = TraLimYSup.Value * TraResolucion.Value
        LimYInf = TraLimYInf.Value * TraResolucion.Value

        For y = 0 To ImgOriginal.Height - 1 Step TraResolucion.Value
            For x = 0 To ImgOriginal.Width - 1 Step TraResolucion.Value
                Huh = ImgOriginal.GetPixel(x, y).GetHue
                'Green1 = ImgOriginal.GetPixel(x, y).G
                'Blue1 = ImgOriginal.GetPixel(x, y).B




                If (x - 10) > 0 Then
                    If ImgOriginal.GetPixel(x, y).B > (ImgOriginal.GetPixel(x - 10, y).B + TraTolerancia.Value) Then
                        ImgResultante.SetPixel(x, y, Color.Yellow)
                        ImgResultante.SetPixel(x + 1, y, Color.Yellow)
                        ImgResultante.SetPixel(x + 1, y + 1, Color.Yellow)
                        ImgResultante.SetPixel(x, y + 1, Color.Yellow)
                    Else
                        ImgResultante.SetPixel(x, y, Color.Black)
                    End If
                End If


                If x = LimXDch Or x = LimXIzq Then
                    ImgResultante.SetPixel(x, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y + 1, Color.Red)
                    ImgResultante.SetPixel(x, y + 1, Color.Red)

                End If
                If y = LimYSup Or y = LimYInf Then
                    ImgResultante.SetPixel(x, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y, Color.Red)
                    ImgResultante.SetPixel(x + 1, y + 1, Color.Red)
                    ImgResultante.SetPixel(x, y + 1, Color.Red)
                End If

            Next

        Next


        PictureBox1.Image = ImgResultante
        TrackBarX.Value = CentroX
        TrackBarY.Value = ImgResultante.Height - CentroY
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim img3 As Bitmap = PictureBox1.Image
        Dim img3 As Bitmap = PictureBox1.Image

        PictureBox1.Image = WebCam.Imagen
        'Dim img1 As Bitmap = WebCam.Imagen

        Dim Red1, Green1, Blue1, Tolerancia, SumaX, SumaY, TotalPuntos As Integer
        Dim CentroX, CentroY, x, y, LimXDch, LimXIzq, LimYSup, LimYInf As Integer
        'Dim Luminancia As System.Drawing.Color = Color.White
        Dim lumin As Integer '= Luminancia.ToString
        LabHash.Text = lumin
        LimXDch = TraLimXDch.Value * TraResolucion.Value
        LimXIzq = TraLimXIzq.Value * TraResolucion.Value
        LimYSup = TraLimYSup.Value * TraResolucion.Value
        LimYInf = TraLimYInf.Value * TraResolucion.Value

        For y = 0 To img3.Height - 1 Step 1
            For x = 0 To img3.Width - 1 Step 1
                lumin = im
                img3.SetPixel(x, y, Color.FromArgb(lumin))
            Next
        Next
        PictureBox1.Image = img3
        Timer2.Enabled = False
    End Sub
End Class
