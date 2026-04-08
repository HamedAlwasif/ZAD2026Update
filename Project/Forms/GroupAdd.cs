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
    public partial class GroupAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //----------------- ConnectionStrings for web ------------------

        //static string constringweb = ConfigurationManager.ConnectionStrings["ConnectionStringDataforweb"].ConnectionString;
        //SqlConnection sqlConnectionweb = new SqlConnection(constringweb);
        //-------------------------------------------------------------
        //----------------- ConnectionStrings ------------------



        //--------------------------------
        SqlDataReader dr;
        //private SqlDataReader reed;
        SqlCommand cmd;


        //private SqlDataReader reed;
        public GroupAdd()
        {
            InitializeComponent();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //----------------
                cmd = new SqlCommand("insert into Groups (GroupName,Information)values ('" + textGroup.Text + "','" + textInf.Text + "')", cn);
                // cmd.CommandText = "insert into Employee (Name,Adress,Num_pers,Date_birth,Job,Salary,Date_Job)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "')";
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");

                GetGroups();

                //---------------


            }
            catch
            {

                //cmd = new SqlCommand("Update Treasury set Users='" + textBox10.Text + "',BalanceStored='" + textBox8.Text + "',Tahseel='" + textBox1.Text + "',Tawred='" + textBox7.Text + "',MassarefStored='" + textBox4.Text + "',MassarefCar='" + textBox5.Text + "',SafyStored='" + textBox2.Text + "',AddStored='" + textBox11.Text + "',ExporTtreasury='" + textBox3.Text + "',Remaining='" + textBox6.Text + "',Notice='" + textBox9.Text + "' Where Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
                ////cn.Open();
                //cmd.ExecuteNonQuery();
                //cn.Close();
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            textGroup.Text = "";
            textInf.Text = "";
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("Update Groups set GroupName='" + textGroup.Text + "',Information='" + textInf.Text + "' Where GroupName ='" + comGroup.Text + "'", cn);
                //cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                

                GetGroups();

            }
            catch
            {
                MessageBox.Show("    لم يتم التعديل راجع البيانات   ", "خطأ ",MessageBoxButtons.OK,MessageBoxIcon.Error) ;

            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (textGroup.Text == "")
            {
                MessageBox.Show("    لا يوجد شئ للحذف  ", "خطأ");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد حذف هذه المجموعه بالفعل ؟" + textGroup.Text, "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("موافق", "موافق");
                    cn.Open();
                    cmd.CommandText = "delete from Groups where GroupName = '" + textGroup.Text + "'   ";
                    cmd.ExecuteNonQuery();

                    GetGroups();


                }
                else if (dialogResult == DialogResult.No)
                {


                }

            }
        }

        public void GetGroups()
        {
            SqlDataAdapter Da;
            DataTable Dt = new DataTable();

            Da = new SqlDataAdapter("select GroupName from Groups ", cn);
            Da.Fill(Dt);
            comGroup.DataSource = Dt;
            comGroup.DisplayMember = "GroupName";
        }
        private void GroupAdd_Load(object sender, EventArgs e)
        {
            GetGroups();
        }

        private void comGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * From Groups  Where GroupName = '" + comGroup.Text + "'", cn);
                // cmd = new SqlCommand("select Salary From Employed ORDER BY Salary DESC  Where Employed= '" + comboBox1.Text + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                textGroup.Text = dr["GroupName"].ToString();
                textInf.Text = dr["Information"].ToString();




            }
            catch
            {
                textGroup.Text = "";
                textInf.Text = "";


            }
            finally
            {
                //dr.Close();
                cn.Close();

            }
        }
    }
}
