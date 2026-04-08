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
    public partial class BankAddAccount : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //--------------------------
        string SystemPro = "";
        string RseedBox = "";
        //---------------------------------
        private SqlDataReader red;
        private SqlDataReader rred;

        public BankAddAccount()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into Bank (NumHesab,Name,Alomala,PriceSarf,BankName,Department,Type,Address,Tel1,Tel2,Tel3,Fax,Rased,DateLast,Note)values ('" + comNumHesab.Text + "','" + textBox1.Text + "','" + comboBox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + textFristGard.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + textBox1.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox9.Text + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "insert into BankHesab (NumHesab,BankName,Department,Date,Move,Remaining1,Maden,Daen,Remaining)values ('" + comNumHesab.Text + "','" + textBox3.Text + "','" + comboBox4.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + 0 + "','" + textBox9.Text + "','" + 0 + "','" + textBox9.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                butAdd.Enabled = false;
            }
            catch
            {

            }
        }

        private void BankAddAccount_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'elwesifDataSetNumHesab.Bank' table. You can move, or remove it, as needed.
            //this.bankTableAdapter.Fill(this.elwesifDataSetNumHesab.Bank);

            //----------------- ايجاد المجموعات --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select NumHesab from Bank", cn);
                Da1.Fill(Dt1);
                comNumHesab.DataSource = Dt1;
                comNumHesab.DisplayMember = "NumHesab";
            }
            catch
            {

            }

            comNumHesab.Text = "";

            //***************** ايجاد اكبر عنصر FristGard 

            try
            {
                sqlCommand1.CommandText = "select * From FristGard  Where ID =(select max(ID) from FristGard) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["ID"].ToString());
                    double aa = s + 1;
                    textFristGard.Text = aa.ToString();

                }
                red.Close();

                if (textFristGard.Text == "")
                {
                    textFristGard.Text = "1";
                }
                else
                { }
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }


        }

        private void butNew_Click(object sender, EventArgs e)
        {
            //---------- إضافة رقم حساب جرد اولى جديد
            int iii = int.Parse(textFristGard.Text);
            int jj = iii + 1;
            textFristGard.Text = jj.ToString();
            //--------------------------
            butAdd.Enabled = true;

            textBox1.Text = "";
            comboBox3.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comNumHesab.Text = "";
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            //------------------------
            try  //----   إيجاد رصيد المخزن
            {
                sqlCommand1.CommandText = "select * From Bank Where NumHesab = '" + comNumHesab.Text + "' ";
                rred = sqlCommand1.ExecuteReader();
                while (rred.Read())
                {

                    textBox1.Text = rred["Name"].ToString();
                    comboBox3.Text = rred["Alomala"].ToString();
                    textBox2.Text = rred["PriceSarf"].ToString();
                    textBox3.Text = rred["BankName"].ToString();
                    comboBox4.Text = rred["Department"].ToString();
                    comboBox5.Text = rred["Type"].ToString();
                    textBox4.Text = rred["Address"].ToString();
                    textBox5.Text = rred["Tel1"].ToString();
                    textBox6.Text = rred["Tel2"].ToString();
                    textBox7.Text = rred["Tel3"].ToString();
                    textBox8.Text = rred["Fax"].ToString();
                }
                rred.Close();
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
