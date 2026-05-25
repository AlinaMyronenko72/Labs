using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int rob = 0;
        int cheb = 0;
        int line = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "D:\\Учеба\\8 семестр\\Комп. графіка\\laba8\\foto";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.* ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = b;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (line == 0)
            {
                Bitmap b = (Bitmap)pictureBox1.Image.Clone();
                b = Line(b);
                pictureBox2.Image = b;

            }
            else
            {
                Bitmap b = (Bitmap)pictureBox2.Image.Clone();
                b = Line(b);
                pictureBox2.Image = b;

            }
            line++;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Bitmap Line(Bitmap b)
        {
           
            double red = 0, green = 0, blue = 0;
            double sumR = 0, sumG = 0, sumB = 0;
            int m1 = 3;
            int n1 = 3;
            Color c;
            for (int y = 1; y < b.Height - 1; y++)
            {
                for (int x = 1; x < b.Width - 1; x++)
                {
                    sumR = sumB = sumG = 0;
                    for (int m = 0; m <m1; m++)
                    {
                        for (int n = 0; n <n1; n++)
                        {

                            c = b.GetPixel(x + m-1, y + n-1);

                            sumR += c.R != 0 ? 1.0 / c.R : 1.0;
                            sumG += c.G != 0 ? 1.0 / c.G : 1.0;
                            sumB += c.B != 0 ? 1.0 / c.B : 1.0;

                        }
                    }
                    red = (n1*m1)/ sumR;
                    green = (n1 * m1) / sumG;
                    blue = (n1 * m1) / sumB;
                    c = Color.FromArgb((int)red, (int)green, (int)blue);
                    b.SetPixel(x, y, c);
                }
            }
            return b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rob == 0)
            {
                Bitmap b = (Bitmap)pictureBox1.Image.Clone();
                b = Roberts(b);
                pictureBox2.Image = b;
                
            }else
            {
                Bitmap b = (Bitmap)pictureBox2.Image.Clone();
                b = Roberts(b);
                pictureBox2.Image = b;
              
            }
            rob++;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Bitmap Roberts(Bitmap b)
        {
            double redX = 0, greenX = 0, blueX = 0, redY = 0, greenY = 0, blueY = 0;
            double redG = 0, greenG = 0, blueG = 0;
            Color c;
            double[,] Hx = { { -1, 0 }, { 0, 1 } };
            double[,] Hy = { { 0, -1 }, { 1, 0 } };
            for (int y = 0; y < b.Height-1; y++)
            {
                for (int x = 0; x < b.Width-1; x++)
                {
                    redX = greenX = blueX = redY = greenY = blueY = 0;
                    for (int m = 0; m < Hx.GetLength(0); m++)
                    {
                        for (int n = 0; n < Hx.GetLength(1); n++)
                        {

                            c = b.GetPixel(x + m, y + n);
                            redX += c.R * Hx[m,n];
                            greenX += c.G * Hx[m, n];
                            blueX += c.B * Hx[m, n];
                            redY += c.R * Hy[m, n];
                            greenY += c.G * Hy[m, n];
                            blueY += c.B * Hy[m, n];
                        }
                    }
                     redG = Math.Abs(redX) + Math.Abs(redY);
                     greenG = Math.Abs(greenX) + Math.Abs(greenY);
                     blueG = Math.Abs(blueX) + Math.Abs(blueY);

                    redG = redG > 255 ? 255 : redG;
                    greenG = greenG > 255 ? 255 : greenG;
                    blueG = blueG > 255 ? 255 : blueG;

                    redG = redG < 0 ? 0 : redG;
                    greenG = greenG < 0 ? 0 : greenG;
                    blueG = blueG < 0 ? 0 : blueG;

                    c = Color.FromArgb((int)redG, (int)greenG, (int)blueG);
                    b.SetPixel(x, y, c);
                }
            }
            return b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cheb == 0)
            {
                Bitmap b = (Bitmap)pictureBox1.Image.Clone();
                b = Cheb(b);
                pictureBox2.Image = b;

            }
            else
            {
                Bitmap b = (Bitmap)pictureBox2.Image.Clone();
                b = Cheb(b);
                pictureBox2.Image = b;

            }
            cheb++;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private Bitmap Cheb(Bitmap b)
        {
            double[,] masR = new double[3,3];
            double[,] masG = new double[3, 3];
            double[,] masB = new double[3, 3];
            double red = 0, green = 0, blue = 0;
            double  minR= 0, minG = 0, minB = 0;
            double maxR = 0, maxG = 0, maxB = 0;
            Color c;
            for (int y = 1; y < b.Height - 1; y++)
            {
                for (int x = 1; x < b.Width - 1; x++)
                {

                    for (int m = 0; m <3; m++)
                    {
                        for (int n = 0; n <3; n++)
                        {

                            c = b.GetPixel(x + m-1, y + n-1);
                            masR[m,n] = c.R;
                            masG[m, n] = c.G;
                            masB[m, n] = c.B;
                        }
                    }
                    minR = FindMin(masR);
                    minG = FindMin(masG);
                    minB = FindMin(masB);
                    maxR = FindMax(masR);
                    maxG = FindMax(masG);
                    maxB = FindMax(masB);
                    red = 0.5 * (minR + maxR);
                    green = 0.5 * (minG + maxG);
                    blue = 0.5 * (minB + maxB);
                    c = Color.FromArgb((int)red, (int)green, (int)blue);
                    b.SetPixel(x, y, c);
                }
            }
            return b;
        }

        private double FindMin(double[,] arr)
        {
            double min = arr[0, 0];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }
            }

            return min;
        }
        private double FindMax(double[,] arr)
        {
            double max = arr[0, 0];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }
            }

            return max;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            cheb = 0;
            line = 0;
            rob = 0;
        }
    }
}
