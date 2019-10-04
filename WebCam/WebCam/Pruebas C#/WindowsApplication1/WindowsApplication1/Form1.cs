using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap img1 = new Bitmap(@"C:\Proyectos\Vision Artificial\WebCam\Pruebas1\WindowsApplication1\WindowsApplication2\R100.bmp");
            Bitmap img2 = new Bitmap(@"C:\Proyectos\Vision Artificial\WebCam\Pruebas1\WindowsApplication1\WindowsApplication2\Lineas.bmp");
            Bitmap img3 = new Bitmap(@"C:\Proyectos\Vision Artificial\WebCam\Pruebas1\WindowsApplication1\WindowsApplication2\Blanco.bmp");
            
           int Red1, Red2, Green1, Green2, Blue1, Blue2, x, y;

           for (y = 0; y < img1.Height; y=y+1)
           {
               for (x = 0; x < img1.Width; x++)
               {
               
                   Red1 = img1.GetPixel(x, y).R - 1;
                   Red2 = img2.GetPixel(x, y).R - 1;
                   Green1 = img2.GetPixel(x, y).G - 1;
                   Green2 = img1.GetPixel(x, y).G - 1;
                   Blue1 = img2.GetPixel(x, y).B - 1;
                   Blue2 = img1.GetPixel(x, y).B - 1;
                   img3.SetPixel(x, y, Color.FromArgb(Red1 - Red2, Green1 - Green2, Blue1 - Blue2));
                   

               }
           }
           pictureBox3.Image = img3;
        }
    }
}