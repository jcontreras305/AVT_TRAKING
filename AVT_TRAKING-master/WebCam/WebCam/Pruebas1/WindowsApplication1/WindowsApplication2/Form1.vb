Public Class Form1  'Esto lo genera solo

    'Subrutina del botón de toma de muestra
    Private Sub ButButMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButMuestra.Click
        WebCam1.Start() 'Activa la WebCam
        PicResultado.Image = WebCam1.Imagen 'Pasa una muestra al PictureBox para ver el resultado
    End Sub

    'Subrutina del botón Detener
    Private Sub ButDetener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDetener.Click
        WebCam1.Stop()  'Simplemente detiene la camara y deja los últimos fotogramas
        TimMuestreo.Enabled = False
    End Sub

    'Subrutina del botón de configuración
    Private Sub ButConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConfiguracion.Click
        WebCam1.Configuracion() 'Abre una pantalla de configuracion de la webcam
    End Sub

    'Subrutina del botón de Búsqueda de Azul
    Private Sub ButBuscaAzul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButBuscaAzul.Click
        WebCam1.Start() 'Activa la WebCam
        TimMuestreo.Enabled = True   'Activa el timer que nos generará el muestreo
    End Sub

    Private Sub TimMuestreo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimMuestreo.Tick
        'Pasamos el fotograma actial al PictureBox para ver lo que hay
        PicResultado.Image = WebCam1.Imagen

        'Declaramos un par de objetos Bitmap para trabajar sin que se vea.
        'Declararemos dos para facilitar la comprensión del código
        Dim ImgOriginal As Bitmap = PicResultado.Image
        Dim ImgResultante As Bitmap = PicResultado.Image

        'Declaramos una variable para cada color. Son de tipo entero porque 
        'Serán valores entre 0 y 255
        Dim Rojo, Verde, Azul As Integer

        'Necesitaremos dos variables para guardar las coordenadas del ultimo punto azul
        Dim UltimoAzulX, UltimoAzulY As Integer

        'La tolerancia nos permitira no ser tan estrictos con la selección de color
        Dim Tolerancia As Integer

        'Las variables x e y serviran para guardar coordenadas actuales
        Dim x, y As Integer

        'Pondremos una tolerancia de 5 unidades de color. cada uno 
        'debe ajustarla según sus necesidades
        Tolerancia = 1

        'Ahora recorreremos la imagen del objeto ImgOriginal como si fuese una 
        'matriz, de modo que iremos recorriendo las horizontales en orden.
        'Para no perder mucho tiempo en el analisis de cada pixel, haremos 
        'que los salte de 10 en 10 tanto en vertical como en horizontal
        For y = 0 To ImgOriginal.Height - 1 Step 5
            For x = 0 To ImgOriginal.Width - 1 Step 5
                'Guardamos los valores de los colores del pixel (x, y)
                Rojo = ImgOriginal.GetPixel(x, y).R
                Verde = ImgOriginal.GetPixel(x, y).G
                Azul = ImgOriginal.GetPixel(x, y).B

                'Ahora preguntaremos si en el pixel actual predomina el 
                'Azul sobre el rojo y el verde, teniendo en cuenta la tolerancia
                If Azul >= Rojo - Tolerancia Then   'Si hay más azul que rojo sigue
                    If Azul >= Verde - Tolerancia Then  'Si hay mas azul que verde sigue

                        'si llega hasta aqui es porque el pixel es suficientemente azul
                        'asi que lo pintamos con un punto de 2x2 en amarillo
                        'esta es una manera de pintar cuadrados, pero luego vemos otra
                        ImgResultante.SetPixel(x, y, Color.Yellow)
                        ImgResultante.SetPixel(x + 1, y, Color.Yellow)
                        ImgResultante.SetPixel(x + 1, y + 1, Color.Yellow)
                        ImgResultante.SetPixel(x, y + 1, Color.Yellow)
                        'Guardamos la posición x y de este pixel azul, si es el ultimo 
                        'se quedara aqui, porque no habra mas azules
                        UltimoAzulX = x
                        UltimoAzulY = y
                    End If

                Else
                    'si entra aqui es porque el pixel no era suficientemente azul
                    'asi que pondremos un punto de 1 pixel en negro
                    ImgResultante.SetPixel(x, y, Color.Black)

                End If
            Next    'Fin del analisis del pixel x, y

        Next    'Fin de la linea horizontal pasa a la siguiente (y+1)

        'Pintaremos un cuadrado de 4 x 4 en las coordenadas del ultimo pixel azul
        For y = UltimoAzulY To UltimoAzulY + 4
            For x = UltimoAzulX To UltimoAzulX + 4
                'Estos if sirven para no salirnos de la tabla (de la imagen), porque
                'si lo hacemos tendremos un error
                If y < ImgResultante.Height Then
                    If x < ImgResultante.Width Then ImgResultante.SetPixel(x, y, Color.Red)
                End If
            Next 'ya esta pintado el pixel con coordenadas UltimoAzulX y UltimoAzulY, a por otro
        Next    'ya estan los cuatro horizontales, a por la siguiente fila

        'Pasamos el objeto ImgResultante al PictureBox, para ver el análisis
        PicResultado.Image = ImgResultante

        'Ponemos los valores de las coordenadas ultimo pixel azul en las barras
        TrackBarX.Value = UltimoAzulX
        TrackBarY.Value = 250 - UltimoAzulY

    End Sub   'Fin del análisis, en menos de 200ms vendrá otro
End Class
