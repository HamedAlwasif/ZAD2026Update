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
using System.Configuration;

namespace ZAD_Sales.Forms
{
    public partial class CheckSave : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader red;
        private SqlDataReader rad;
        public CheckSave()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void CheckSave_Load(object sender, EventArgs e)
        {

            //---- إيجاد اسماء العملاء
            SqlDataAdapter Da;
            DataTable Dt = new DataTable();

            Da = new SqlDataAdapter("select Name from Clients ", cn);
            Da.Fill(Dt);
            comboBox1.DataSource = Dt;
            comboBox1.DisplayMember = "Name";

            //------------------------------------------

            ////---- إيجاد اسماء المخازن
            //SqlDataAdapter Da1;
            //DataTable Dt1 = new DataTable();

            //Da1 = new SqlDataAdapter("select Storage from Storage ", cn);
            //Da1.Fill(Dt1);
            //comboBox2.DataSource = Dt1;
            //comboBox2.DisplayMember = "Storage";

            //------------------------------------------
            //---- إيجاد ارقام الشيك الموجودة
            SqlDataAdapter Da2;
            DataTable Dt2 = new DataTable();

            Da2 = new SqlDataAdapter("select NumSkeek from SheekSave ", cn);
            Da2.Fill(Dt2);
            comboBox3.DataSource = Dt2;
            comboBox3.DisplayMember = "NumSkeek";

            //------------------------------------------
            //---- إيجاد ارقام الحساب
            SqlDataAdapter Da3;
            DataTable Dt3 = new DataTable();

            Da3 = new SqlDataAdapter("select NumHesab from Bank ", cn);
            Da3.Fill(Dt3);
            comboBox4.DataSource = Dt3;
            comboBox4.DisplayMember = "NumHesab";

            //------------------------------------------

            //---- إيجاد اسماء البنوك الموجودة
            SqlDataAdapter Da4;
            DataTable Dt4 = new DataTable();

            Da4 = new SqlDataAdapter("select BankName from Bank ", cn);
            Da4.Fill(Dt4);
            comboBox5.DataSource = Dt4;
            comboBox5.DisplayMember = "BankName";

            //------------------------------------------

            // إيجاد حركة اضافة العميل
            textBox1.Text = FormName;

            if (textBox1.Text == "حفظ شيك مدين")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;

                textBox2.Text = "شيك";
                textBox3.Text = "مدين";

            }
            else if (textBox1.Text == "حفظ كمبيالة مدين")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;

                textBox2.Text = "كمبيالة";
                textBox3.Text = "مدين";

                label5.Text = "رقم الكمبيالة";
                label6.Text = "قيمة الكمبيالة";

            }
            else if (textBox1.Text == "حفظ شيك دائن")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;

                textBox2.Text = "شيك";
                textBox3.Text = "دائن";
            }
            else if (textBox1.Text == "حفظ كمبيالة دائن")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;

                textBox2.Text = "كمبيالة";
                textBox3.Text = "دائن";

                label5.Text = "رقم الكمبيالة";
                label6.Text = "قيمة الكمبيالة";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into SheekSave (Move,TypeMove,Name,Storage,NumSkeek,ValueSheek,dateDay,DateElestehkak,NumHesab,BankName,Note,State)values ('" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox5.Text + "','" + textBox28.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + textBox53.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + textBox1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox9.Text + "','" + 0 + "')";
                //sqlCommand1.ExecuteNonQuery();

                button3.Enabled = false;
            }
            catch
            {
                //sqlCommand1.CommandText = "update FristGard set Building ='" + textBox1.Text + "', Electronic ='" + textBox2.Text + "' , BasisOFFICE ='" + textBox3.Text + "', Bank ='" + textBox4.Text + "'where ID ='" + textBox53.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into SheekSave (Move,TypeMove,Name,Storage,NumSkeek,ValueSheek,dateDay,DateElestehkak,NumHesab,BankName,Note,State)values ('" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox5.Text + "','" + textBox28.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + textBox53.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + textBox1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox9.Text + "','" + 0 + "')";
                //sqlCommand1.ExecuteNonQuery();

                button4.Enabled = false;
            }
            catch
            {
                //sqlCommand1.CommandText = "update FristGard set Building ='" + textBox1.Text + "', Electronic ='" + textBox2.Text + "' , BasisOFFICE ='" + textBox3.Text + "', Bank ='" + textBox4.Text + "'where ID ='" + textBox53.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into SheekSave (Move,TypeMove,Name,Storage,NumSkeek,ValueSheek,dateDay,DateElestehkak,NumHesab,BankName,Note,State)values ('" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox5.Text + "','" + textBox28.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + textBox53.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + textBox1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox9.Text + "','" + 0 + "')";
                //sqlCommand1.ExecuteNonQuery();

                button2.Enabled = false;
            }
            catch
            {
                //sqlCommand1.CommandText = "update FristGard set Building ='" + textBox1.Text + "', Electronic ='" + textBox2.Text + "' , BasisOFFICE ='" + textBox3.Text + "', Bank ='" + textBox4.Text + "'where ID ='" + textBox53.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into SheekSave (Move,TypeMove,Name,Storage,NumSkeek,ValueSheek,dateDay,DateElestehkak,NumHesab,BankName,Note,State)values ('" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox5.Text + "','" + textBox28.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + textBox53.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + textBox1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox9.Text + "','" + 0 + "')";
                //sqlCommand1.ExecuteNonQuery();

                button1.Enabled = false;
            }
            catch
            {
                //sqlCommand1.CommandText = "update FristGard set Building ='" + textBox1.Text + "', Electronic ='" + textBox2.Text + "' , BasisOFFICE ='" + textBox3.Text + "', Bank ='" + textBox4.Text + "'where ID ='" + textBox53.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox5.Text = "";
            textBox4.Text = "0";
            //-----------------------------------
            if (textBox1.Text == "حفظ شيك مدين")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;


            }
            else if (textBox1.Text == "حفظ كمبيالة مدين")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;


                label5.Text = "رقم الكمبيالة";
                label6.Text = "قيمة الكمبيالة";

            }
            else if (textBox1.Text == "حفظ شيك دائن")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;


            }
            else if (textBox1.Text == "حفظ كمبيالة دائن")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;


                label5.Text = "رقم الكمبيالة";
                label6.Text = "قيمة الكمبيالة";

            }
        }
    }
}
