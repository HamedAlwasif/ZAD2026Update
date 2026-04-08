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
    public partial class EmployeeAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;

        //--------------------------------
        private SqlDataReader red;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        public EmployeeAdd()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_GetEmployee
        {

            public string ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string NumIdentity { get; set; }
            public string Tel { get; set; }
            public string DateBirth { get; set; }
            public string DateRegistry { get; set; }
            public string Jop { get; set; }
            public string Salary { get; set; }
            public string DateEnd { get; set; }
            public string State { get; set; }
            


        }
        public class Class_GetEmployedSalary
        {

            public string Date { get; set; }
            public string Employed { get; set; }
            public string Salary { get; set; }
            public string RemainingSalary { get; set; }
            public string Move { get; set; }
            public string Sarf { get; set; }
            public string AddSalary { get; set; }
            public string Remaining { get; set; }
            public string Notice { get; set; }



        }
        public void EmployedSalaryAll()
        {

            //------------------------------------
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from EmployedSalary ", cn);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;


        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال إضافة الموظف ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("موافق", "موافق");
                try
                {
                    sqlCommand1.CommandText = "insert into Employed (Name,Address,NumIdentity,Tel,DateBirth,DateRegistry,Jop,Salary,State,Remaining,DateRemaining)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + comboBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }



                try
                {
                    //----------------
                    sqlCommand1.CommandText = "insert into EmployedSalary (Date,IdEmployed,Employed,Salary,RemainingSalary,Move,Sarf,AddSalary,Remaining,Notice)values ('" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + 0 + "','" + textBox1.Text + "','" + textBox4.Text + "','" + 0 + "','" + comboBox4.Text + "','" + 0 + "','" + 0 + "','" + textBox4.Text + "','" + 0 + "')";

                    sqlCommand1.ExecuteNonQuery();


                    //---------------


                }
                catch
                {

                }

                //----------------
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From Employed ", cn);
                da1.Fill(dt1);
                this.dataGridView2.DataSource = dt1;

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //----------------
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * From EmployedSalary Where Move = '" + comboBox6.Text + "'", cn);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void comEmployes1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //----------------
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * From EmployedSalary Where Employed = '" + comEmployes1.Text + "'", cn);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {

            //----------------- ايجاد الموظفين بالرواتب --------------------

            EmployedSalaryAll();

            //----------------- ايجاد الموظفين --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Name from Employed", cn);
                Da1.Fill(Dt1);
                comEmployes.DataSource = Dt1;
                comEmployes.DisplayMember = "Name";
                //------------------------
                comEmployes1.DataSource = Dt1;
                comEmployes1.DisplayMember = "Name";
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //----------------
            dt1.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Employed ", cn);
            da1.Fill(dt1);
            this.dataGridView2.DataSource = dt1;
        }

        private void comEmployes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "select * from Employed where Name ='" + comEmployes.Text + "' ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    // textBox1.Text = red["UserName"].ToString();
                    textBox6.Text = red["ID"].ToString();
                    textBox7.Text = red["ID"].ToString();
                    textBox1.Text = red["Name"].ToString();
                    textBox2.Text = red["Address"].ToString();
                    textBox3.Text = red["NumIdentity"].ToString();
                    textBox5.Text = red["Tel"].ToString();
                    dateTimePicker1.Text = red["DateBirth"].ToString();
                    dateTimePicker2.Text = red["DateRegistry"].ToString();
                    comboBox1.Text = red["Jop"].ToString();
                    textBox4.Text = red["Salary"].ToString();
                    dateTimePicker3.Text = red["DateEnd"].ToString();
                    comboBox3.Text = red["State"].ToString();

                }
                red.Close();
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            //----------------
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * From EmployedSalary Where Employed = '" + comEmployes1.Text + "'", cn);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;

            //----------------
            dt1.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Employed Where Name = '" + comEmployes.Text + "'", cn);
            da1.Fill(dt1);
            this.dataGridView2.DataSource = dt1;
        }

        private void butEmptey_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            textBox6.Text = "";
            textBox1.Focus();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد تعديل البيانات  ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("موافق", "موافق");

                try
                {
                    sqlCommand1.CommandText = "update Employed set Name ='" + textBox1.Text + "', Address = '" + textBox2.Text + "' , NumIdentity = '" + textBox3.Text + "' , Tel = '" + textBox5.Text + "' , DateBirth = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' , DateRegistry = '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' , Jop = '" + comboBox1.Text + "', Salary = '" + textBox4.Text + "', DateEnd = '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "', State = '" + comboBox3.Text + "' where  ID ='" + textBox6.Text + "'  ";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد حذف الموظف  ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("موافق", "موافق");

                try
                {
                    sqlCommand1.CommandText = "delete from Employed where Name = '" + comEmployes.Text + "'   ";
                    sqlCommand1.ExecuteNonQuery();

                    //----------------
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("Select * From Employed ", cn);
                    da1.Fill(dt1);
                    this.dataGridView2.DataSource = dt1;
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد مغادرةالموظف  ؟", "تنبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("موافق", "موافق");


                try
                {
                    try
                    {
                        sqlCommand1.CommandText = "update Employed set Name ='" + textBox1.Text + "', Address = '" + textBox2.Text + "' , NumIdentity = '" + textBox3.Text + "' , Tel = '" + textBox5.Text + "' , DateBirth = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' , DateRegistry = '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' , Jop = '" + comboBox1.Text + "', Salary = '" + textBox4.Text + "', DateEnd = '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "', State = '" + comboBox3.Text + "' where  ID ='" + textBox6.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                    }

                    //----------------
                    sqlCommand1.CommandText = "insert into EmployedSalary (Date,IdEmployed,Employed,Salary,RemainingSalary,Move,Sarf,AddSalary,Remaining,Notice)values ('" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox1.Text + "','" + 0 + "','" + 0 + "','" + comboBox4.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";

                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                }

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
