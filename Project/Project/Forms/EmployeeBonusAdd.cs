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
    public partial class EmployeeBonusAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //-------------------------------
        SqlDataReader dr;

        SqlCommand cmd;
        public EmployeeBonusAdd()
        {
            InitializeComponent();
           
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("       من فضلك أدخل إسم المستخدم           ", "  خطأ  ");
                textBox8.Focus();
            }
            else
            {
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("       من فضلك أدخل إسم الحركة           ", "  خطأ  ");
                    comboBox2.Focus();
                }
                else
                {
                    double a = Convert.ToDouble(textBox5.Text);
                    if (a <= 0)
                    {
                        MessageBox.Show("       تأكد من المبلغ            ", "  خطأ  ");
                        textBox5.Focus();
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
                                cmd = new SqlCommand("insert into EmployedSalary (Date,IdEmployed,Employed,Salary,RemainingSalary,Move,Sarf,AddSalary,Remaining,Notice)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox3.Text + "','" + comEmployed.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + 0 + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", cn);
                                // cmd.CommandText = "insert into Employee (Name,Adress,Num_pers,Date_birth,Job,Salary,Date_Job)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "')";
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();

                                //---------------

                                //---------------
                                cmd = new SqlCommand("Update Employed set Remaining='" + textBox6.Text + "',DateRemaining='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + textBox3.Text + "'", cn);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();

                            }
                            catch
                            {

                            }

                        }
                        else if (dialogResult == DialogResult.No)
                        {


                        }
                    }
                }
            }
        }

        private void comEmployed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select Salary,ID From Employed  Where Name = '" + comEmployed.Text + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                textBox4.Text = dr["Salary"].ToString();
                textBox3.Text = dr["ID"].ToString();
                textBox9.Text = dr["Remaining"].ToString();
                dateTimePicker2.Text = dr["DateRemaining"].ToString();


            }
            catch
            {
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox9.Text = "0";

            }
            finally
            {
                dr.Close();
                cn.Close();

            }

            //********************

            double a = Convert.ToDouble(dateTimePicker1.Value.ToString("MM"));
            double c = Convert.ToDouble(dateTimePicker1.Value.ToString("yyyy"));
            double b = Convert.ToDouble(dateTimePicker2.Value.ToString("MM"));
            double d = Convert.ToDouble(dateTimePicker2.Value.ToString("yyyy"));

            textBox10.Text = a.ToString();
            textBox11.Text = c.ToString();

            textBox12.Text = b.ToString();
            textBox13.Text = d.ToString();

            if (d > c)
            {
                MessageBox.Show("تأكد من التريخ ( السنة )", "  خطأ");

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(dateTimePicker1.Value.ToString("MM"));
            double c = Convert.ToDouble(dateTimePicker1.Value.ToString("yyyy"));
            double b = Convert.ToDouble(dateTimePicker2.Value.ToString("MM"));
            double d = Convert.ToDouble(dateTimePicker2.Value.ToString("yyyy"));

            textBox10.Text = a.ToString();
            textBox11.Text = c.ToString();

            textBox12.Text = b.ToString();
            textBox13.Text = d.ToString();

            if (d > c)
            {
                MessageBox.Show("تأكد من التريخ ( السنة )", "  خطأ");

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox14.Text);
                double b = Convert.ToDouble(textBox5.Text);


                double s = a + b;
                textBox6.Text = s.ToString();
            }
            catch
            {
                MessageBox.Show("تأكد من البيانات", "  خطأ");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(dateTimePicker1.Value.ToString("MM"));
            double c = Convert.ToDouble(dateTimePicker1.Value.ToString("yyyy"));
            double b = Convert.ToDouble(dateTimePicker2.Value.ToString("MM"));
            double d = Convert.ToDouble(dateTimePicker2.Value.ToString("yyyy"));

            textBox10.Text = a.ToString();
            textBox11.Text = c.ToString();

            textBox12.Text = b.ToString();
            textBox13.Text = d.ToString();

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

        private void EmployeeBonusAdd_Load(object sender, EventArgs e)
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

        }
    }
}
