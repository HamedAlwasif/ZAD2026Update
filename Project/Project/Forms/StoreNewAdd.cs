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
    public partial class StoreNewAdd : Form
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


        public StoreNewAdd()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void StoreNewAdd_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Storage from Storage", cn);
                Da1.Fill(Dt1);
                comStorages.DataSource = Dt1;
                comStorages.DisplayMember = "Storage";
            }
            catch { }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into Storage (Storage,Place,Phone)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                sqlCommand1.ExecuteNonQuery();
                MessageBox.Show("   تم إضافة المخزن الجديد بنجاح    ", "  إضافه ");
            }
            catch
            {
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox1.Focus();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {

            sqlCommand1.CommandText = "delete from Storage where ID = '" + textBox4.Text + "' ";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("   تم حذف المخزن  بنجاح    ", "  الحذف ");
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "update Storage set  Storage ='" + textBox1.Text + "',Place = '" + textBox2.Text + "',Phone = '" + textBox3.Text + "' where  ID ='" + textBox4.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                MessageBox.Show("   تم التعديل المخزن بنجاح    ", "  التعديــــل ");
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "select * from Storage where Storage ='" + comStorages.Text + "' ";
                rad = sqlCommand1.ExecuteReader();
                while (rad.Read())
                {
                    textBox1.Text = rad["Storage"].ToString();
                    textBox2.Text = rad["Place"].ToString();
                    textBox3.Text = rad["Phone"].ToString();
                    textBox4.Text = rad["ID"].ToString();

                }
                rad.Close();

                butDelete.Enabled = true;
                butEdit.Enabled = true;
            }
            catch
            {

            }
        }
    }
}
