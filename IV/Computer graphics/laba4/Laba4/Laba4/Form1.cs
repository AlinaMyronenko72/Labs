using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\flags");
            FileInfo[] fiArr = di.GetFiles();
            label1.Text = "flags";
            Bitmap myMap = new Bitmap(@"D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\flags\\flagsJPEG.jpg");
            pictureBox1.Image = myMap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DrawDiag(fiArr);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\foto");
            FileInfo[] fiArr = di.GetFiles();
            label1.Text = "foto";
            Bitmap myMap = new Bitmap(@"D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\foto\\fotoJPEG.jpg");
            pictureBox1.Image = myMap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DrawDiag(fiArr);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\grayscale");
            FileInfo[] fiArr = di.GetFiles();
            label1.Text = "grayscale";
            Bitmap myMap = new Bitmap(@"D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\grayscale\\grayscaleJPEG.jpg");
            pictureBox1.Image = myMap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DrawDiag(fiArr);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\blackwhite");
            FileInfo[] fiArr = di.GetFiles();
            label1.Text = "blackwhite";
            Bitmap myMap = new Bitmap(@"D:\\Учеба\\8 семестр\\Комп. графіка\\laba4\\blackwhite\\bwJPEG.jpg");
            pictureBox1.Image = myMap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DrawDiag(fiArr);
        }
        private long[] Scale(long[] mas, int h)
        {
            long[] result = new long[6];
            long max = Max(mas);
            for (int i = 0; i < mas.Length; i++)
            {
                result[i] = (mas[i] * h) / max;
            }
            return result;
        }
        private long Max(long[] mas)
        {
            long max = 0;
            foreach(long element in mas)
            {
                if (element > max)
                    max = element;
            }
            return max;
        }
       
        private void DrawDiag(FileInfo[] fiArr)
        {
            long[] mas = new long[6];
            for (int i = 0; i < fiArr.Length; i++)
            {
                mas[i] = fiArr[i].Length;
                textBox1.Text += fiArr[i].Extension + " - " + fiArr[i].Length.ToString() + "     " + "\r\n";
            }
            Graphics g = pictureBox2.CreateGraphics();
            SolidBrush d = new SolidBrush(Color.Blue);
            mas = Scale(mas, pictureBox2.Height);
            int space = 10;
            int boxSize = (pictureBox2.Width - (mas.Length * space)) / mas.Length;
            for (int i = 0; i < mas.Length; i++)
            {
                g.FillRectangle(d, i * (space + boxSize), pictureBox2.Height - mas[i], boxSize, mas[i]);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            textBox1.Text = null;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
    
}
