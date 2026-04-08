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
    public partial class CarsAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //-------------------------------
        public CarsAdd()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_Cars
        {
            public string ID { get; set; }
            public string TypeLicense { get; set; }
            public string TypeCar { get; set; }
            public string TypeLoha { get; set; }
            public string CharCar { get; set; }
            public string NumCar { get; set; }
            public string NumShaseh { get; set; }
            public string NumMotor { get; set; }
            public string Mark { get; set; }
            public string CapacityLiter { get; set; }
            public string DateMake { get; set; }
            public string Model { get; set; }
            public string Price { get; set; }


        }

        private void CarsAdd_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select * from Car", cn);
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

                // dataGridSearchCar.Sort(dataGridSearchCar.Columns[1], ListSortDirection.Ascending);
            }
            catch
            {


            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("    من فضلك أدخل رقم العربية   ", "خطأ");

                textBox2.Focus();
            }
            else
            {
                sqlCommand1.CommandText = "insert into Car (TypeLicense,TypeCar,TypeLoha,CharCar,NumCar,NumShaseh,NumMotor,Mark,CapacityLiter,DateMake,Model,Price)values ('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + textPriceCare.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //-------------
                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From Car ", cn);
                da1.Fill(dt1);
                this.dataGridView1.DataSource = dt1;
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
                    sqlCommand1.CommandText = "delete from Car where NumCar = '" + textBox2.Text + "'   ";
                    sqlCommand1.ExecuteNonQuery();

                    //-------------
                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("Select * From Car ", cn);
                    da1.Fill(dt1);
                    this.dataGridView1.DataSource = dt1;
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

        private void butEmpty_Click(object sender, EventArgs e)
        {
            comboBox7.Text = "";
            comboBox6.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            textPriceCare.Text = "0";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
