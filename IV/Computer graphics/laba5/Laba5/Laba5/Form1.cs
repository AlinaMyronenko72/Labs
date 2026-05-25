using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "D:\\Учеба\\8 семестр\\Комп. графіка\\laba5\\foto";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.* ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                Bitmap b = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = b;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap b = (Bitmap)pictureBox1.Image.Clone();
            var rect = new Rectangle(0, 0, b.Width, b.Height);
            BitmapData data = b.LockBits(rect, ImageLockMode.ReadWrite, b.PixelFormat);
            IntPtr ptr = data.Scan0;
            int bytes = data.Stride * b.Height;
            byte[] rgb = new byte[bytes];
            Marshal.Copy(ptr, rgb, 0, bytes);
            byte averageIntensity;
            for (int i = 0; i < rgb.Length - 3; i = i + 3)
            {
                averageIntensity = (byte)((rgb[i + 2] + rgb[i + 1] + rgb[i]) / 3);
                if (radioButton1.Checked)
                {
                    if (averageIntensity < CalculateThreshold(25))
                        rgb[i + 2] = rgb[i + 1] = rgb[i] = 0;
                    else
                        rgb[i + 2] = rgb[i + 1] = rgb[i] = 255;
                }
                if (radioButton2.Checked)
                {
                    if (averageIntensity < CalculateThreshold(50))
                        rgb[i + 2] = rgb[i + 1] = rgb[i] = 0;
                    else
                        rgb[i + 2] = rgb[i + 1] = rgb[i] = 255;
                }
                if (radioButton3.Checked)
                {
                    if (averageIntensity < CalculateThreshold(75))
                        rgb[i + 2] = rgb[i + 1] = rgb[i] = 0;
                    else
                        rgb[i + 2] = rgb[i + 1] = rgb[i] = 255;
                }

            }
            Marshal.Copy(rgb, 0, ptr, bytes);
            b.UnlockBits(data);
            pictureBox2.Image = b;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private double CalculateThreshold(int interest)
        {
            return (interest * 256) / 100;
        }
    }
}
