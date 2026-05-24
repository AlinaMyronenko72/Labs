using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Curs4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.curs4DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "curs4DataSet.payview". При необходимости она может быть перемещена или удалена.
            this.payviewTableAdapter.Fill(this.curs4DataSet.payview);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "curs4DataSet.voucherview". При необходимости она может быть перемещена или удалена.
            this.voucherviewTableAdapter.Fill(this.curs4DataSet.voucherview);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "curs4DataSet.tourview". При необходимости она может быть перемещена или удалена.
            this.tourviewTableAdapter.Fill(this.curs4DataSet.tourview);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "curs4DataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.curs4DataSet.Client);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(cons);
                con.Open();      
                string date = dateTimePicker4.Value.Year.ToString() + "-" + dateTimePicker4.Value.Month.ToString() + "-" + dateTimePicker4.Value.Day.ToString();
                string s = "Insert into Client(Fam,Iniz,DateBirth,Phone) values('" + textBox5.Text + "','" + textBox6.Text + "','" + date + "','" + textBox7.Text + "')";               
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
                this.clientTableAdapter.Fill(this.curs4DataSet.Client);
                con.Close();
            }
            catch (Exception)
            {
                if (dateTimePicker4.Value.Year > 2006)
                    MessageBox.Show("Клиент, которому нет 16 лет, не может быть внесен в базу!");
                else
                    MessageBox.Show("Такой клиент уже есть в базе!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = clientDataGridView.CurrentRow.Index;
            string i = clientDataGridView.Rows[id].Cells[0].Value.ToString();         
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            try
            {
                string s = "Delete from Voucher where ClientID=" + i;
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
                s = "Delete from Client where ClientID=" + i;
                cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы удалили клиента из базы!");
            }
            this.clientTableAdapter.Fill(this.curs4DataSet.Client);
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            int i = clientDataGridView.CurrentRow.Index;
            string id = clientDataGridView.Rows[i].Cells[0].Value.ToString();
            try
            {
                string s = "";
                if (textBox5.Text != "")
                    s += "Update Client set Fam='" + textBox5.Text + "' where ClientID=" + id;
                if (textBox6.Text != "")
                    s += "Update Client set Iniz='" + textBox6.Text + "' where ClientID=" + id;
                string date = dateTimePicker4.Value.Year.ToString() + "-" + dateTimePicker4.Value.Month.ToString() + "-" + dateTimePicker4.Value.Day.ToString();
                if (dateTimePicker4.Value.ToShortDateString() != DateTime.Today.ToShortDateString())
                {
                    s += "Update Client set DateBirth='" + date + "' where ClientID=" + id;
                }
                if (textBox7.Text != "")
                    s += "Update Client set Phone='" + textBox7.Text + "' where ClientID=" + id;                
                SqlCommand cmd = new SqlCommand(s, con);
                int k = cmd.ExecuteNonQuery();
                this.clientTableAdapter.Fill(this.curs4DataSet.Client);
                con.Close();
            }
            catch (Exception)
            {
                if (dateTimePicker4.Value.Year > 2006)
                    MessageBox.Show("Клиент, которому нет 16 лет, не может быть внесен в базу!");
                else
                    MessageBox.Show("Такой клиент уже есть в базе!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filt = "1=1";
            if (checkedListBox1.Text != "")
            {
                filt += " and NameTour in(";
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        filt += "'" + checkedListBox1.Items[i].ToString() + "',";
                    }
                }
                filt = filt.Substring(0, filt.Length - 1);
                filt += ")";
            }
            if (checkedListBox2.Text != "")
            {
                filt += " and NameHotel in(";
                for (int i = 0; i <= (checkedListBox2.Items.Count - 1); i++)
                {
                    if (checkedListBox2.GetItemChecked(i))
                    {
                        filt += "'" + checkedListBox2.Items[i].ToString() + "',";
                    }
                }
                filt = filt.Substring(0, filt.Length - 1);
                filt += ")";
            }
            if (textBox1.Text != "")
                filt += "and Star>=" + textBox1.Text;
            if (textBox2.Text != "")
                filt += "and Star<=" + textBox2.Text;
            if (comboBox1.Text != "")
                filt += "and TypeFood='" + comboBox1.Text + "'";
            if (comboBox2.Text != "")
                filt += "and NameCountry='" + comboBox2.Text + "'";
            if (checkedListBox3.Text != "")
            {
                filt += " and NameCity in(";
                for (int i = 0; i <= (checkedListBox3.Items.Count - 1); i++)
                {
                    if (checkedListBox3.GetItemChecked(i))
                    {
                        filt += "'" + checkedListBox3.Items[i].ToString() + "',";
                    }
                }
                filt = filt.Substring(0, filt.Length - 1);
                filt += ")";
            }
            DateTime dateTime = new DateTime(1900, 01, 01);
            if (dateTimePicker1.Value.ToShortDateString() != dateTime.ToShortDateString())
            {
                filt += "and DateStart>='" + dateTimePicker1.Value.ToShortDateString() + "'";
            }
            if (dateTimePicker2.Value.ToShortDateString() != dateTime.ToShortDateString())
            {
                filt += "and DateEnd<='" + dateTimePicker2.Value.ToShortDateString() + "'";
            }
            if (textBox3.Text != "")
                filt += "and Price>=" + textBox3.Text;
            if (textBox4.Text != "")
                filt += "and Price<=" + textBox4.Text;

            tourviewBindingSource.Filter = filt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            SqlCommand cmd = new SqlCommand("hottour", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@date1";
            param.SqlDbType = SqlDbType.Date;
            dateTimePicker3.CustomFormat = "dd.MM.yyyy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            param.Value = dateTimePicker3.Value.ToShortDateString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@date2";
            param.SqlDbType = SqlDbType.Date;
            param.Value = dateTimePicker3.Value.AddDays(7).ToString();
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@name";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            label14.Text = "Количество горящих туров: " + cmd.Parameters["@name"].Value.ToString();
            //this.tourviewTableAdapter.Fill(this.curs4DataSet.tourview);
            con.Close();
            string filt = "1=1";
            filt += "and DateStart>='" + dateTimePicker3.Value.ToShortDateString() + "'";
            filt += "and DateStart<='" + dateTimePicker3.Value.AddDays(7).ToShortDateString() + "'";
            tourviewBindingSource.Filter = filt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            SqlCommand cmd = new SqlCommand("pricetour", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@name";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = 50;
            param.Value = comboBox3.Text;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@min";
            param.SqlDbType = SqlDbType.Money;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@max";
            param.SqlDbType = SqlDbType.Money;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            param = new SqlParameter();
            param.ParameterName = "@count";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            label17.Text = "Минимальная цена: " + cmd.Parameters["@min"].Value.ToString();
            label18.Text = "Максимальная цена: " + cmd.Parameters["@max"].Value.ToString();
            label19.Text = "Количество туров: " + cmd.Parameters["@count"].Value.ToString();
            //this.tourviewTableAdapter.Fill(this.curs4DataSet.tourview);
            con.Close();
            string filt = "1=1";
            filt += "and NameCountry='" + comboBox3.Text + "'";
            tourviewBindingSource.Filter = filt;
        }

        private void button4_Click(object sender, EventArgs e)
        {        
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, false);
            checkedListBox1.ClearSelected();
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
                checkedListBox2.SetItemChecked(i, false);
            checkedListBox2.ClearSelected();
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
                checkedListBox3.SetItemChecked(i, false);
            checkedListBox3.ClearSelected();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            DateTime dateTime = new DateTime(1900, 01, 01);
            dateTimePicker1.Value = dateTime;
            dateTimePicker2.Value = dateTime;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = voucherviewDataGridView.CurrentRow.Index;
            string id = voucherviewDataGridView.Rows[i].Cells[0].Value.ToString();
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            string s = "select ClientID from Client where Fam='" + id+"'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            string clientID = read[0].ToString();
            read.Close();
            s= "select VoucherID from Voucher where ClientID=" + clientID;
            cmd = new SqlCommand(s, con);
            read = cmd.ExecuteReader();
            read.Read();
            string voucherID = read[0].ToString();
            read.Close();
            s = "Delete from Voucher where VoucherID=" + voucherID;
            cmd = new SqlCommand(s, con);
            int k = cmd.ExecuteNonQuery();
            this.voucherviewTableAdapter.Fill(this.curs4DataSet.voucherview);
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            try
            {
                string date = dateTimePicker5.Value.Year.ToString() + "-" + dateTimePicker5.Value.Month.ToString() + "-" + dateTimePicker5.Value.Day.ToString();
                string s = "Insert into Client(Fam,Iniz,DateBirth,Phone) values('" + textBox9.Text + "','" + textBox10.Text + "','" + date + "','" + textBox11.Text + "')";
                SqlCommand cmd = new SqlCommand(s, con);
                int k = cmd.ExecuteNonQuery();
                s = "select ClientID from Client where(Phone ='" + textBox11.Text + "')";
                cmd = new SqlCommand(s, con);
                SqlDataReader read = cmd.ExecuteReader();
                read.Read();
                string clientID = read[0].ToString();
                read.Close();
                s = "select TourID from Tour where(NameTour ='" + comboBox4.Text + "')";
                cmd = new SqlCommand(s, con);
                read = cmd.ExecuteReader();
                read.Read();
                string tourID = read[0].ToString();
                read.Close();
                string date2 = dateTimePicker6.Value.Year.ToString() + "-" + dateTimePicker6.Value.Month.ToString() + "-" + dateTimePicker6.Value.Day.ToString();
                s = "Insert into Payment(DatePayment,SumPayment) values('" + date2 + "'," + textBox12.Text + ")";
                cmd = new SqlCommand(s, con);
                int f = cmd.ExecuteNonQuery();
                s = "select PaymentID from Payment where(DatePayment ='" + date2 + "'and SumPayment=" + textBox12.Text + ")";
                cmd = new SqlCommand(s, con);
                read = cmd.ExecuteReader();
                read.Read();
                string paymentID = read[0].ToString();
                read.Close();
                s = "select TypeTranspID from TypeTransp where(TypeTransp ='" + comboBox5.Text + "')";
                cmd = new SqlCommand(s, con);
                read = cmd.ExecuteReader();
                read.Read();
                string typetranspID = read[0].ToString();
                read.Close();
                s = "select CityID from City where(NameCity ='" + comboBox6.Text + "')";
                cmd = new SqlCommand(s, con);
                read = cmd.ExecuteReader();
                read.Read();
                string cityID = read[0].ToString();
                read.Close();
                s = "select top 1 TranspID from Transp where(TypeTranspID =" + typetranspID + " and CityID=" + cityID + ")";
                cmd = new SqlCommand(s, con);
                read = cmd.ExecuteReader();
                read.Read();
                string transpID = read[0].ToString();
                read.Close();
                s = "Insert into Voucher(ClientID,PaymentID,TourID,TranspID) values(" + clientID + "," + paymentID + "," + tourID + "," + transpID + ")";
                cmd = new SqlCommand(s, con);
                k = cmd.ExecuteNonQuery();
                this.voucherviewTableAdapter.Fill(this.curs4DataSet.voucherview);
                con.Close();
            }
            catch (Exception)
            {
                if (dateTimePicker5.Value.Year > 2006)
                    MessageBox.Show("Клиент, которому нет 16 лет, не может быть внесен в базу!");
                else
                    MessageBox.Show("Такой клиент уже есть в базе!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            string s = "select Price from Tour where(NameTour ='" + comboBox4.Text + "')";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            string price = read[0].ToString();
            label33.Text = price;
            read.Close();
            this.voucherviewTableAdapter.Fill(this.curs4DataSet.voucherview);
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();
            int i = voucherviewDataGridView.CurrentRow.Index;
            string id = voucherviewDataGridView.Rows[i].Cells[0].Value.ToString();
            string s = "select ClientID from Client where Fam='" + id + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            string clientID = read[0].ToString();
            read.Close();
            s = "select VoucherID from Voucher where ClientID=" + clientID;
            cmd = new SqlCommand(s, con);
            read = cmd.ExecuteReader();
            read.Read();
            string voucherID = read[0].ToString();
            read.Close();
            s = "select PaymentID from Voucher where(VoucherID =" + voucherID + ")";
            cmd = new SqlCommand(s, con);
            read = cmd.ExecuteReader();
            read.Read();
            string paymentID = read[0].ToString();
            read.Close();
            s = "select TourID from Voucher where(VoucherID =" + voucherID + ")";
            cmd = new SqlCommand(s, con);
            read = cmd.ExecuteReader();
            read.Read();
            string tourID = read[0].ToString();
            read.Close();
            s = "select TranspID from Voucher where(VoucherID =" + voucherID + ")";
            cmd = new SqlCommand(s, con);
            read = cmd.ExecuteReader();
            read.Read();
            string transpID = read[0].ToString();
            read.Close();
            s = "select TypeTranspID from Transp where(TranspID =" + transpID + ")";
            cmd = new SqlCommand(s, con);
            read = cmd.ExecuteReader();
            read.Read();
            string typetranspID = read[0].ToString();
            read.Close();
            s = "";
            if (textBox9.Text != "")
                s += "Update Client set Fam='" + textBox9.Text + "' where ClientID=" + clientID;
            if (textBox10.Text != "")
                s += "Update Client set Iniz='" + textBox10.Text + "' where ClientID=" + clientID;
            DateTime dateTime = new DateTime(1900, 01, 01);
            if (dateTimePicker6.Value.ToShortDateString() != dateTime.ToShortDateString())
            {
                string date2 = dateTimePicker6.Value.Year.ToString() + "-" + dateTimePicker6.Value.Month.ToString() + "-" + dateTimePicker6.Value.Day.ToString();
                s += "Update Payment set DatePayment='" + date2 + "' where PaymentID=" + paymentID;
            }
            if (textBox12.Text != "")
            {
                s += "Update Tour set Price=" + textBox12.Text + " where TourID=" + tourID;
            }
            if (comboBox5.Text != "")
            {
                s += "Update TypeTransp set TypeTransp='" + comboBox5.Text + "' where TypeTranspID=" + typetranspID;
            }
            if (comboBox6.Text != "")
            {
                string s1 = "select CityID from City where(NameCity ='" + comboBox6.Text + "')";
                cmd = new SqlCommand(s1, con);
                read = cmd.ExecuteReader();
                read.Read();
                string cityID = read[0].ToString();
                read.Close();
                string s2 = "select top 1 NumberTransp from Transp where(CityID=" + cityID + "and TypeTranspID=" + typetranspID + ")";
                cmd = new SqlCommand(s2, con);
                read = cmd.ExecuteReader();
                read.Read();
                string num = read[0].ToString();
                read.Close();
                s += "Update Transp set NumberTransp='" + num + "'where TranspID=" + transpID;
            }
            cmd = new SqlCommand(s, con);
            int k = cmd.ExecuteNonQuery();
            this.voucherviewTableAdapter.Fill(this.curs4DataSet.voucherview);
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string filt = "1=1";
            if (textBox15.Text != "")
                filt += " and Fam='" + textBox15.Text + "'";
            if (textBox16.Text != "")
                filt += " and Iniz='" + textBox16.Text + "'";
            if (textBox17.Text != "")
                filt += "and Phone='" + textBox17.Text + "'";
            if (textBox14.Text != "")
                filt += "and SumPayment>=" + textBox14.Text;
            if (textBox8.Text != "")
                filt += "and SumPayment<=" + textBox8.Text;
            if (comboBox7.Text != "")
                filt += "and NameTour='" + comboBox7.Text + "'";
            DateTime dateTime = new DateTime(1900, 01, 01);
            if (dateTimePicker7.Value.ToShortDateString() != dateTime.ToShortDateString())
            {
                filt += "and DatePayment>='" + dateTimePicker7.Value.ToShortDateString() + "'";
            }
            if (dateTimePicker8.Value.ToShortDateString() != dateTime.ToShortDateString())
            {
                filt += "and DatePayment<='" + dateTimePicker8.Value.ToShortDateString() + "'";

            }
            payviewBindingSource.Filter = filt;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox14.Clear();
            textBox8.Clear();
            comboBox7.Text = "";
            DateTime dateTime = new DateTime(1900, 01, 01);
            dateTimePicker7.Value = dateTime;
            dateTimePicker8.Value = dateTime;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string filt = "1=1";
            filt += " and DatePayment is NULL";
            payviewBindingSource.Filter = filt;
        }

        //private void button15_Click(object sender, EventArgs e)
        //{
        //    DateTime dateTime = new DateTime(1900, 01, 01);
        //    dateTimePicker1.Value = dateTime;
        //    dateTimePicker2.Value = dateTime;

        //}

        //private void button16_Click(object sender, EventArgs e)
        //{
        //    DateTime dateTime = new DateTime(1900, 01, 01);
        //    dateTimePicker7.Value = dateTime;
        //    dateTimePicker8.Value = dateTime;
        //}

        private void button17_Click(object sender, EventArgs e)
        {            
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            DateTime dateTime = new DateTime(1900, 01, 01);
            dateTimePicker6.Value = dateTime;
            dateTimePicker5.Value = DateTime.Today;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            dateTimePicker4.Value = DateTime.Today;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string filt = "1=1";
            string cons = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Curs4.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(cons);
            con.Open();

            string s = "select sum(Price)  from Country inner join City on Country.CountryID = City.CountryID inner join Hotel on City.CityID = Hotel.CityID inner join Tour on Hotel.HotelID = Tour.HotelID where NameCountry='" + comboBox2.Text + "'";





            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader read = cmd.ExecuteReader();
            read.Read();
            string sum = read[0].ToString();
            read.Close();
            label35.Text=sum;
            tourviewBindingSource.Filter = filt;
            con.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
