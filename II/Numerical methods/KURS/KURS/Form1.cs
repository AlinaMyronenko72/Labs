using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
		private double f1(double x, double y, double z)
		{
			return 3 * y - z;
		}
		private double f2(double x, double y, double z)
		{
			return 10 * y - 4 * z;
		}
		private double f3(double x)
		{
			return Math.Exp(-2 * x);
		}
		private double f4(double x)
		{
			return 5 * Math.Exp(-2 * x);
		}
		private double[,] RungeKutta(double[] x, double[] y, double[] z)
		{
			x = new double[1000];
			y = new double[1000];
			z = new double[1000];
			x[0] = 0;
			y[0] = 1;
			z[0] = 5;
			double k1, k2, k3, k4, k1z, k2z, k3z, k4z;
			double h;
			int b = Convert.ToInt32(this.textBox1.Text);
			int N = Convert.ToInt32(this.textBox2.Text);
			int i = 0;
			h = (b - x[0]) / (double)N;
			double[,] RK = new double[N + 1, 3];
			for (i = 1; i <= N; i++)
			{
				x[i] = x[0] + i * h;
				k1 = h * f1(x[i - 1], y[i - 1], z[i - 1]);
				k1z = h * f2(x[i - 1], y[i - 1], z[i - 1]);
				k2 = h * f1(x[i - 1] + h / 2.0, y[i - 1] + k1 / 2.0, z[i - 1] + k1z / 2.0);
				k2z = h * f2(x[i - 1] + h / 2.0, y[i - 1] + k1 / 2.0, z[i - 1] + k1z / 2.0);
				k3 = h * f1(x[i - 1] + h / 2.0, y[i - 1] + k2 / 2.0, z[i - 1] + k2z / 2.0);
				k3z = h * f2(x[i - 1] + h / 2.0, y[i - 1] + k2 / 2.0, z[i - 1] + k2z / 2.0);
				k4 = h * f1(x[i - 1] + h, y[i - 1] + k3, z[i - 1] + k3z);
				k4z = h * f2(x[i - 1] + h, y[i - 1] + k3, z[i - 1] + k3z);
				y[i] = y[i - 1] + 1.0 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
				z[i] = z[i - 1] + 1.0 / 6.0 * (k1z + 2 * k2z + 2 * k3z + k4z);

			}
			dataGridView1.ColumnCount = 3;
			for (int j = 0; j <= N; j++)
			{
				string[] row = new string[] { x[j].ToString(), y[j].ToString(), z[j].ToString() };
				dataGridView1.Rows.Add(row);
			}
			
			for (int p = 0; p <= N; p++)
			{
				RK[p, 0] = x[p];
				RK[p, 1] = y[p];
				RK[p, 2] = z[p];
			}
			return RK;
		}
		private double[,] RungeKuttaMersona(double[] x, double[] y, double[] z)
		{
			x = new double[1000];
			y = new double[1000];
			z = new double[1000];
			double[] Ry = new double[1000];
			double[] Rz = new double[1000];
			x[0] = 0;
			y[0] = 1;
			z[0] = 5;
			double k1, k2, k3, k4, k1z, k2z, k3z, k4z, k5, k5z;
			double h;
			int b = Convert.ToInt32(this.textBox1.Text);
			int N = Convert.ToInt32(this.textBox2.Text);
			int i = 0;
			h = (b - x[0]) / (double)N;
			double[,] RKM = new double[N + 1, 3];
			for (i = 1; i <= N; i++)
			{
                
                k1 = f1(x[i - 1], y[i - 1], z[i - 1]);
                k1z = f2(x[i - 1], y[i - 1], z[i - 1]);
                k2 = f1(x[i - 1] + h / 3.0, y[i - 1] + k1 * h / 3.0, z[i - 1] + k1z * h / 3.0);
                k2z = f2(x[i - 1] + h / 3.0, y[i - 1] + k1 * h / 3.0, z[i - 1] + k1z * h / 3.0);
                k3 = f1(x[i - 1] + h / 3.0, y[i - 1] + k1 * h / 6.0 + k2 * h / 6.0, z[i - 1] + k1z * h / 6.0 + k2z * h / 6.0);
                k3z = f2(x[i - 1] + h / 3.0, y[i - 1] + k1 * h / 6.0 + k2 * h / 6.0, z[i - 1] + k1z * h / 6.0 + k2z * h / 6.0);
                k4 = f1(x[i - 1] + h / 2.0, y[i - 1] + k1 * h / 8.0 + k2 * 3.0 * h / 8.0, z[i - 1] + k1z * h / 8.0 + k2z * h * 3.0 / 8.0);
                k4z = f2(x[i - 1] + h / 2.0, y[i - 1] + k1 * h / 8.0 + k2 * 3.0 * h / 8.0, z[i - 1] + k1z * h / 8.0 + k2z * h * 3.0 / 8.0);
                k5 = f1(x[i - 1] + h, y[i - 1] + k1 * h / 2.0 - k3 * h * 3.0 / 2.0 + 2 * h * k4, z[i - 1] + k1z * h / 2.0 - k3z * h * 3.0 / 2.0 + 2 * h * k4z);
                k5z = f2(x[i - 1] + h, y[i - 1] + k1 * h / 2.0 - k3 * h * 3.0 / 2.0 + 2 * h * k4, z[i - 1] + k1z * h / 2.0 - k3z * h * 3.0 / 2.0 + 2 * h * k4z);
                y[i] = y[i - 1] + h / 6.0 * (k1 + 4 * k4 + k5);
                z[i] = z[i - 1] + h / 6.0 * (k1z + 4 * k4z + k5z);
                x[i] = x[0] + i * h;
			}
			dataGridView2.ColumnCount = 3;
			for (int j = 0; j <= N; j++)
			{
				string[] row = new string[] { x[j].ToString(), y[j].ToString(), z[j].ToString() };
				dataGridView2.Rows.Add(row);
			}
			for (int p = 0; p <= N; p++)
			{
				RKM[p, 0] = x[p];
				RKM[p, 1] = y[p];
				RKM[p, 2] = z[p];
			}
			return RKM;
		}
		private double[,] RungeKuttaFelberg(double[] x, double[] y, double[] z)
		{
			x = new double[1000];
			y = new double[1000];
			z = new double[1000];
			double[] y5 = new double[1000];
			double[] z5 = new double[1000];
			x[0] = 0;
			y[0] = 1;
			z[0] = 5;
			y5[0] = 1;
			z5[0] = 5;
			double k1, k2, k3, k4, k5, k6, k1z, k2z, k3z, k4z, k5z, k6z;
			double h;
			int b = Convert.ToInt32(this.textBox1.Text);
			int N = Convert.ToInt32(this.textBox2.Text);
			int i = 0;
			h = (b - x[0]) / (double)N;
			double[,] RKFN = new double[N + 1, 3];
			for (i = 1; i <= N; i++)
			{

				k1 = h * f1(x[i - 1], y[i - 1], z[i - 1]);
				k1z = h * f2(x[i - 1], y[i - 1], z[i - 1]);

				k2 = h * f1(x[i - 1] + h / 2.0, y[i - 1] + k1 / 2.0, z[i - 1] + k1z / 2.0);
				k2z = h * f2(x[i - 1] + h / 2.0, y[i - 1] + k1 / 2.0, z[i - 1] + k1z / 2.0);

				k3 = h * f1(x[i - 1] + h / 2.0, y[i - 1] + (k1 + k2) / 4.0, z[i - 1] + (k1z + k2z) / 4.0);
				k3z = h * f2(x[i - 1] + h / 2.0, y[i - 1] + (k1 + k2) / 4.0, z[i - 1] + (k1z + k2z) / 4.0);

				k4 = h * f1(x[i - 1] + h, y[i - 1] - k2 + 2 * k3, z[i - 1] - k2z + 2 * k3z);
				k4z = h * f2(x[i - 1] + h, y[i - 1] - k2 + 2 * k3, z[i - 1] - k2z + 2 * k3z);

				k5 = h * f1(x[i - 1] + 2 * h / 3.0, y[i - 1] + (7 * k1 + 10 * k2 + k4) / 27.0, z[i - 1] + (7 * k1z + 10 * k2z + k4z) / 27.0);
				k5z = h * f2(x[i - 1] + 2 * h / 3.0, y[i - 1] + (7 * k1 + 10 * k2 + k4) / 27.0, z[i - 1] + (7 * k1z + 10 * k2z + k4z) / 27.0);

				k6 = h * f1(x[i - 1] + h / 5.0, y[i - 1] + (28 * k1 - 125 * k2 + 546 * k3 + 54 * k4 - 378 * k5) / 625.0, z[i - 1] + (28 * k1z - 125 * k2z + 546 * k3z + 54 * k4z - 378 * k5z) / 625.0);
				k6z = h * f2(x[i - 1] + h / 5.0, y[i - 1] + (28 * k1 - 125 * k2 + 546 * k3 + 54 * k4 - 378 * k5) / 625.0, z[i - 1] + (28 * k1z - 125 * k2z + 546 * k3z + 54 * k4z - 378 * k5z) / 625.0);

				y[i] = y[i - 1] + 1.0 / 6.0 * (k1 + 4 * k3 + k4);
				z[i] = z[i - 1] + 1.0 / 6.0 * (k1z + 4 * k3z + k4z);

				x[i] = x[0] + i * h;


			}
			dataGridView3.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{
					string[] row = new string[] { x[j].ToString(), y[j].ToString(), z[j].ToString() };
					dataGridView3.Rows.Add(row);
				}
			
			for (int p = 0; p <= N; p++)
			{
				RKFN[p, 0] = x[p];
				RKFN[p, 1] = y[p];
				RKFN[p, 2] = z[p];
			}
			return RKFN;
		}
		private double[,] Test(double[] x)
		{
			x = new double[1000];
			y = new double[1000];
			z = new double[1000];

			double[] y5 = new double[1000];
			double[] z5 = new double[1000];
			x[0] = 0;
			y[0] = 1;
			z[0] = 5;
			double h;
			int b = Convert.ToInt32(this.textBox1.Text);
			int N = Convert.ToInt32(this.textBox2.Text);
			int i = 0;
			h = (b - x[0]) / (double)N;
			double[,] T = new double[N + 1, 3];
			for (i = 1; i <= N; i++)
			{
				x[i] = x[0] + i * h;
				y[i] = f3(x[i]);
				z[i] = f4(x[i]);
			}
			dataGridView4.ColumnCount = 3;
			for (int j = 0; j <= N; j++)
			{

				string[] row = new string[] { x[j].ToString(), y[j].ToString(), z[j].ToString() };
				dataGridView4.Rows.Add(row);
			}
			
			for (int p = 0; p <= N; p++)
			{
				T[p, 0] = x[p];
				T[p, 1] = y[p];
				T[p, 2] = z[p];
			}
			return T;
		}
		private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
			RungeKutta(x, y, z);

		}
        private void button3_Click(object sender, EventArgs e)
        {
			RungeKuttaMersona(x, y, z);
		}

        private void button4_Click(object sender, EventArgs e)
        {
			RungeKuttaFelberg(x, y, z);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Test(x);
		}

        private void button6_Click(object sender, EventArgs e)
        {
			int N = Convert.ToInt32(this.textBox2.Text);
			
			double[,] RK = new double[N + 1, 3];
			double[,] RKM = new double[N + 1, 3];
			double[,] RKF = new double[N + 1, 3];
			double[,] T = new double[N + 1, 3];
			RK=RungeKutta(x, y, z);
			RKM =RungeKuttaMersona(x, y, z);
			RKF=RungeKuttaFelberg(x, y, z);
			T =Test(x);
			if(checkedListBox1.GetItemChecked(0)&& checkedListBox1.GetItemChecked(1))
            {
				dataGridView5.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{

					string[] row = new string[] { RK[j,0].ToString(), Math.Abs(RK[j, 1]- RKM[j, 1]).ToString(), Math.Abs(RK[j, 2] - RKM[j, 2]).ToString() };
					dataGridView5.Rows.Add(row);
				}
			}
			if (checkedListBox1.GetItemChecked(0) && checkedListBox1.GetItemChecked(2))
			{
				dataGridView5.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{

					string[] row = new string[] { RK[j, 0].ToString(), Math.Abs(RK[j, 1] - RKF[j, 1]).ToString(), Math.Abs(RK[j, 2] - RKF[j, 2]).ToString() };
					dataGridView5.Rows.Add(row);
				}
			}
			if (checkedListBox1.GetItemChecked(0) && checkedListBox1.GetItemChecked(3))
			{
				dataGridView5.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{

					string[] row = new string[] { RK[j, 0].ToString(), Math.Abs(RK[j, 1] - T[j, 1]).ToString(), Math.Abs(RK[j, 2] - T[j, 2]).ToString() };
					dataGridView5.Rows.Add(row);
				}
			}
			if (checkedListBox1.GetItemChecked(1) && checkedListBox1.GetItemChecked(2))
			{
				dataGridView5.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{

					string[] row = new string[] { RK[j, 0].ToString(), Math.Abs(RKM[j, 1] - RKF[j, 1]).ToString(), Math.Abs(RKM[j, 2] - RKF[j, 2]).ToString() };
					dataGridView5.Rows.Add(row);
				}
			}
			if (checkedListBox1.GetItemChecked(1) && checkedListBox1.GetItemChecked(3))
			{
				dataGridView5.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{

					string[] row = new string[] { RK[j, 0].ToString(), Math.Abs(RKM[j, 1] - T[j, 1]).ToString(), Math.Abs(RKM[j, 2] - T[j, 2]).ToString() };
					dataGridView5.Rows.Add(row);
				}
			}
			if (checkedListBox1.GetItemChecked(2) && checkedListBox1.GetItemChecked(3))
			{
				dataGridView5.ColumnCount = 3;
				for (int j = 0; j <= N; j++)
				{

					string[] row = new string[] { RK[j, 0].ToString(), Math.Abs(RKF[j, 1] - T[j, 1]).ToString(), Math.Abs(RKF[j, 2] - T[j, 2]).ToString() };
					dataGridView5.Rows.Add(row);
				}
			}

		}

        private void button7_Click(object sender, EventArgs e)
        {
			dataGridView5.Rows.Clear();
		}
        private void button8_Click(object sender, EventArgs e)
        {
			dataGridView1.Rows.Clear();
			dataGridView2.Rows.Clear();
			dataGridView3.Rows.Clear();
			dataGridView4.Rows.Clear();
		}
        private void button9_Click(object sender, EventArgs e)
        {
			int N = Convert.ToInt32(this.textBox2.Text);
			double[,] RK = new double[N + 1, 3];
			double[,] RKM = new double[N + 1, 3];
			double[,] RKF = new double[N + 1, 3];
			double[,] T = new double[N + 1, 3];
			RK = RungeKutta(x, y, z);
			RKM = RungeKuttaMersona(x, y, z);
			RKF = RungeKuttaFelberg(x, y, z);
			T = Test(x);
			this.chart1.Series[0].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart1.Series[0].Points.AddXY(RK[k,0], RK[k, 1]);
			}
			this.chart1.Series[1].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart1.Series[1].Points.AddXY(RKM[k, 0], RKM[k, 1]);
			}
			this.chart1.Series[2].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart1.Series[2].Points.AddXY(RKF[k, 0], RKF[k, 1]);
			}
			this.chart1.Series[3].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart1.Series[3].Points.AddXY(T[k, 0], T[k, 1]);
			}
		}
        private void button10_Click(object sender, EventArgs e)
        {
			int N = Convert.ToInt32(this.textBox2.Text);
			double[,] RK = new double[N + 1, 3];
			double[,] RKM = new double[N + 1, 3];
			double[,] RKF = new double[N + 1, 3];
			double[,] T = new double[N + 1, 3];
			RK = RungeKutta(x, y, z);
			RKM = RungeKuttaMersona(x, y, z);
			RKF = RungeKuttaFelberg(x, y, z);
			T = Test(x);
			this.chart2.Series[0].Points.Clear();
            for (int k = 0; k <= N; k++)
            {
                this.chart2.Series[0].Points.AddXY(RK[k, 0], RK[k, 2]);
            }
			this.chart2.Series[1].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart2.Series[1].Points.AddXY(RKM[k, 0], RKM[k, 2]);
			}
			this.chart2.Series[2].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart2.Series[2].Points.AddXY(RKF[k, 0], RKF[k, 2]);
			}
			this.chart2.Series[3].Points.Clear();
			for (int k = 0; k <= N; k++)
			{
				this.chart2.Series[3].Points.AddXY(T[k, 0], T[k, 2]);
			}
		}
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
