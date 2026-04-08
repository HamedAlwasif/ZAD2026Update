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
    public partial class CategoryGroup : Form
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
        public CategoryGroup()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into CategoryGroup (Group_Name)values ('" + textBox1.Text + "')";
                sqlCommand1.ExecuteNonQuery();
                MessageBox.Show("   تم إضافة المجموعة الجديدة بنجاح    ", "  إضافه ");
            }
            catch
            {
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "select * from CategoryGroup where Group_Name ='" + comCatGroup.Text + "' ";
                rad = sqlCommand1.ExecuteReader();
                while (rad.Read())
                {
                    textBox1.Text = rad["Group_Name"].ToString();
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

        private void butNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
            textBox1.Focus();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = "delete from CategoryGroup where ID = '" + textBox4.Text + "' ";
            sqlCommand1.ExecuteNonQuery();
            MessageBox.Show("   تم حذف المجموعه  بنجاح    ", "  الحذف ");
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "update CategoryGroup set  Group_Name ='" + textBox1.Text + "' where  ID ='" + textBox4.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                MessageBox.Show("   تم التعديل اسم المجموعه بنجاح    ", "  التعديــــل ");
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        private void CategoryGroup_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Group_Name from CategoryGroup", cn);
                Da1.Fill(Dt1);
                comCatGroup.DataSource = Dt1;
                comCatGroup.DisplayMember = "Group_Name";
            }
            catch { }
        }
    }
}
