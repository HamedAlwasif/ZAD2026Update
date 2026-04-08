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
    public partial class EmployeeSalaryPayment : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;

        //--------------------------------
        SqlDataReader dr;
        SqlCommand cmd;
        private SqlDataReader red;
        private SqlDataReader reed;
        //---------------------------------
        string MoveBoxID = "";
        string RasedBox = "";

        public EmployeeSalaryPayment()
        {
            InitializeComponent();
            //cn.Open();
            sqlCommand1.Connection = cn;
        }

        public void GetMoveBoxID()
        {



            //try
            //{
            sqlCommand1.CommandText = "select * From BoxMove  Where ID =(select max(ID) from BoxMove) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["ID"].ToString());
                double aa = s + 1;
                MoveBoxID = aa.ToString();

            }
            red.Close();

            if (MoveBoxID == "")
            {
                MoveBoxID = "1";
            }
            else
            { }
            //}
            //catch
            //{
            //    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            //}



        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            cn.Open();


            if (comboBox2.Text == "")
            {
                MessageBox.Show("       من فضلك أدخل إسم الحركة           ", "  خطأ  ");
                comboBox2.Focus();
            }
            else
            {
                double a = Convert.ToDouble(texMaoneyMadfoa.Text);
                if (a <= 0)
                {
                    MessageBox.Show("       تأكد من المبلغ            ", "  خطأ  ");
                    texMaoneyMadfoa.Focus();
                }
                else
                {


                    DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد تنفيذ العملية ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("موافق", "موافق");

                        try
                        {
                            //----------------
                            cmd = new SqlCommand("insert into EmployedSalary (Date,IdEmployed,Employed,Salary,RemainingSalary,Move,Sarf,AddSalary,Remaining,Notice)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox3.Text + "','" + comEmployed.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + texMaoneyMadfoa.Text + "','" + 0 + "','" + textBox6.Text + "','" + textBox7.Text + "')", cn);
                            // cmd.CommandText = "insert into Employee (Name,Adress,Num_pers,Date_birth,Job,Salary,Date_Job)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "')";

                            cmd.ExecuteNonQuery();


                            //---------------
                            cmd = new SqlCommand("Update Employed set Remaining='" + textBox6.Text + "',DateRemaining='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + textBox3.Text + "'", cn);

                            cmd.ExecuteNonQuery();

                        }
                        catch
                        {

                        }

                        string RemanBox = "";
                        //---- حساب اجمالى الصندوق
                        double q1S = Convert.ToDouble(RasedBox);
                        double l1S = Convert.ToDouble(texMaoneyMadfoa.Text);
                        double w1S = q1S - l1S;
                        RemanBox = w1S.ToString();

                        sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + RemanBox + "' , Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                        sqlCommand1.ExecuteNonQuery();

                        //----------  إضافة حركة الصندوق

                        //try
                        //{
                        //sqlCommand1.CommandText = "insert into BoxMove (Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox2.Text + "','" + comEmployed.Text + "','" + 0 + "','" + textBox16.Text + "','" + textBox5.Text + "','" + 0 + "','" + textBox25.Text + "','" + textBox7.Text + "')";
                        //sqlCommand1.ExecuteNonQuery();
                        //}
                        //catch
                        //{

                        //}
                        //try
                        //{
                        sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox2.Text + "','" + comEmployed.Text + "','" + 0 + "','" + RasedBox + "','" + texMaoneyMadfoa.Text + "','" + 0 + "','" + RemanBox + "','" + textBox7.Text + "')";
                        sqlCommand1.ExecuteNonQuery();

                        double n = Convert.ToDouble(MoveBoxID);
                        double aa = n + 1;
                        MoveBoxID = aa.ToString();
                        //}
                        //catch
                        //{

                        //}

                    }
                    else if (dialogResult == DialogResult.No)
                    {


                    }
                }

            }

            cn.Close();
        }

        private void comEmployed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * From Employed  Where Name = '" + comEmployed.Text + "'", cn);
                // cmd = new SqlCommand("select Salary From Employed ORDER BY Salary DESC  Where Employed= '" + comboBox1.Text + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox4.Text = dr["Salary"].ToString();
                textBox3.Text = dr["ID"].ToString();
                textBox9.Text = dr["Remaining"].ToString();
                dateTimePicker2.Text = dr["DateRemaining"].ToString();

                dr.Close();
            }
            catch
            {
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox9.Text = "0";

            }
            finally
            {

                cn.Close();

            }



            //********************
            string month = "";
            string year = "";

            string month1 = "";
            string year1 = "";

            double a = Convert.ToDouble(dateTimePicker1.Value.ToString("MM"));
            double c = Convert.ToDouble(dateTimePicker1.Value.ToString("yyyy"));
            double b = Convert.ToDouble(dateTimePicker2.Value.ToString("MM"));
            double d = Convert.ToDouble(dateTimePicker2.Value.ToString("yyyy"));

            month1 = a.ToString();
            year1 = c.ToString();

            month = b.ToString();
            year = d.ToString();

            if (d > c)
            {
                MessageBox.Show("تأكد من التاريخ ( السنة )", "  خطأ");

            }
            else if (d == c && b > a)
            {
                MessageBox.Show("تأكد من التاريخ الشهر", "  خطأ");
            }
            else
            {
                double g = Convert.ToDouble(textBox4.Text);
                double h = Convert.ToDouble(textBox9.Text);

                double s = (((a - b) * g) + h);
                textBox14.Text = s.ToString();

            }
        }

        private void texMaoneyMadfoa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox14.Text);
                double b = Convert.ToDouble(texMaoneyMadfoa.Text);


                double s = a - b;
                textBox6.Text = s.ToString();
            }
            catch
            {
                MessageBox.Show("تأكد من البيانات", "  خطأ");
            }
        }

        private void EmployeeSalaryPayment_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Employed", cn);
                Da2.Fill(Dt2);
                comEmployed.DataSource = Dt2;
                comEmployed.DisplayMember = "Name";
            }
            catch { }

            

            //------- رصيد الخزنة



            cn.Open();


            sqlCommand1.CommandText = "select RemaningTreasury From TreasuryRemaning  Where ID = '" + 1 + "' ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {

                RasedBox = red["RemaningTreasury"].ToString();
              //  textBox25.Text = red["RemaningTreasury"].ToString();
            }
            red.Close();

            //----------------------------------
            GetMoveBoxID();



            //-----------------------------
            cn.Close();
        }

    }
}
