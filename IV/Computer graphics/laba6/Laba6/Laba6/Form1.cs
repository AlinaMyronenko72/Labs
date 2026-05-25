using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        float newX = 0;
        float newY = 0;
        float newX2 = 0;
        float newY2 = 0;
        float sizeX = 300;
        float sizeY = 300;
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen p1 = new Pen(Color.Black, 1);
            g.DrawPolygon(p1, points.ToArray());
            dataGridView1.ColumnCount = points.Count();
            for (int i = 0; i < points.Count(); i++)
            {
                dataGridView1.Columns[i].Name = "(x" + (i + 1) + ",y" + (i + 1) + ")";
            }
            PrintCoord();
        }

        private void PrintCoord()
        {
            int rowNumber = dataGridView1.Rows.Add();
            for (int i = 0; i < points.Count(); i++)
            {
                dataGridView1.Rows[rowNumber].Cells[i].Value = points[i];
            }
        }
        private void drawSystem(Pen p1, float x, float y, float x1, float y1, float x2, float y2,/*float sizeX, float sizeY,*/SolidBrush sb1)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(p1, x, y, x1, y1);
            g.DrawLine(p1, x, y, x2, y2);
            Font drawFont = new Font("Arial", 10);
            g.DrawString("x", drawFont, sb1, x1, y1);
            g.DrawString("y", drawFont, sb1, x2, y2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pen p1 = new Pen(Color.Black, 2);
            SolidBrush sb1 = new SolidBrush(Color.Black);
            drawSystem(p1, 0, 0, sizeX, 0, 0, sizeY, sb1);
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            points.Add(new Point(e.X, e.Y));
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush sb1 = new SolidBrush(Color.Black);
            g.FillRectangle(sb1, e.X, e.Y, 2, 2);
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            float dx = 0;
            float dy = 0;
            if (!textBox1.Text.Equals(""))
                dx = float.Parse(textBox1.Text);
            if (!textBox2.Text.Equals(""))
                dy = float.Parse(textBox2.Text);
            Pen p1 = new Pen(Color.Pink, 1);
            SolidBrush sb1 = new SolidBrush(Color.Pink);
            drawSystem(p1, newX2 + dx, newY2 + dy, sizeX + dx, newY + dy, newX + dx, sizeY + dy, sb1);
            newX += dx;
            newY += dy;
            newX2 += dx;
            newY2 += dy;
            sizeX += dx;
            sizeY += dy;
            for (int i = 0; i < points.Count(); i++)
            {
                Point p = points[i];
                p.X = points[i].X - (int)dx;
                points[i] = p;
                p.Y = points[i].Y - (int)dy;
                points[i] = p;
            }
            PrintCoord();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            float kx = 1;
            float ky = 1;
            if (!textBox3.Text.Equals(""))
                kx = float.Parse(textBox3.Text);
            if (!textBox4.Text.Equals(""))
                ky = float.Parse(textBox4.Text);
            Pen p1 = new Pen(Color.Red, 1);
            SolidBrush sb1 = new SolidBrush(Color.Red);
            drawSystem(p1, newX2, newY2, sizeX * kx, newY, newX, sizeY * ky, sb1);
            sizeX = sizeX * kx;
            sizeY = sizeY * ky;
            for (int i = 0; i < points.Count(); i++)
            {
                Point p = points[i];
                p.X = (int)(points[i].X / kx);
                points[i] = p;
                p.Y = (int)(points[i].Y / ky);
                points[i] = p;
            }
            PrintCoord();
        }

        private void button4_Click(object sender, EventArgs e)
        {           
            float alpha = 0;
            if (!textBox5.Text.Equals(""))
                alpha = float.Parse(textBox5.Text);
            alpha = (float)((alpha * Math.PI) / 180);
            Pen p1 = new Pen(Color.Green, 1);
            SolidBrush sb1 = new SolidBrush(Color.Green);
            float X1 = (float)(sizeX * Math.Cos(alpha) - newY * Math.Sin(alpha));
            float Y1 = (float)(newY * Math.Cos(alpha) + sizeX * Math.Sin(alpha));
            float X2 = (float)(newX * Math.Cos(alpha) - sizeY * Math.Sin(alpha));
            float Y2 = (float)(sizeY * Math.Cos(alpha) + newX * Math.Sin(alpha));
            drawSystem(p1, newX2, newY2, X1, Y1, X2, Y2, sb1);
            sizeX = X1;
            newY = Y1;
            newX = X2;
            sizeY = Y2;
            for (int i = 0; i < points.Count(); i++)
            {
                Point p = points[i];
                p.X = (int)(points[i].X * Math.Cos(alpha) + points[i].Y * Math.Sin(alpha));
                points[i] = p;
                p.Y = (int)(-points[i].X * Math.Sin(alpha) + points[i].Y * Math.Cos(alpha));
                points[i] = p;
            }
            PrintCoord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            dataGridView1.Rows.Clear();
            newX = 0;
            newY = 0;
            points = new List<Point>();
            sizeX = 300;
            sizeY = 300;
            newX2 = 0;
            newY2 = 0;

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
