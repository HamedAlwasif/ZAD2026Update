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
    public partial class Events : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        private SqlDataReader reed;

        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();

        public Events()
        {
            InitializeComponent();
        }
        public class Class_EventsDay
        {

            public string ID { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Users { get; set; }
            public string Events { get; set; }
            


        }
        private void butShow_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="الله")
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }
        private void saveEvents(string Event)
        {

            //=========================== تسجيل الحركات  ========================== 
            try
            {
                cn.Open();
                //string Event = "تم فتح شاشة  " + TransferData.FormName;


                sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                sqlCommand1.ExecuteNonQuery();

                // MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");

                cn.Close();
                //---------------


            }
            catch
            {
                //MessageBox.Show("    فشلللللللللللللللللللللللللللللللل   ", "فشل ");
            }

            //========================== ========================== ========================== 
        }
        private void Events_Load(object sender, EventArgs e)
        {
            //==========================  تسجيل الحركات  ========================== 

            saveEvents("تم فتح شاشة  " + TransferData.FormName);

            //========================== ========================== =================

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Events ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }
        }

        private void butSearchUser_Click(object sender, EventArgs e)
        {
            //cn.Open();

            //DataTable dt12 = new DataTable();
            //dt12.Clear();
            //SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where  NumBill='" + textBox14.Text + "'", cn);
            //da21.Fill(dt12);
            //this.dataGridView4.DataSource = dt12;

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Events where  Users='" + comboBox1.Text + "' ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Events where  Date='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }
        }

        private void Events_FormClosed(object sender, FormClosedEventArgs e)
        {
            //*************** تسجيل الحركات  ***********************

            saveEvents("تم غلق شاشة  " + TransferData.FormName);

            //********************************************************
        }
    }
}
