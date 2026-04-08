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
    public partial class DailySalesPurchases : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        int i = 0;
        int ii = 0;
        int iij = 0;
        int iii = 0;
        int ij = 0;
        int ji = 0;
        //private SqlDataReader red;
        private SqlDataReader read;
        private SqlDataReader reed;

        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();
        public DailySalesPurchases()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_DailySalesPurchases
        {

            public string NumBill { get; set; }
            public string ClientName { get; set; }
            public string Date { get; set; }
            public string Num { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string Type { get; set; }
            public string Price { get; set; }
            public string Discount { get; set; }
            public string Total { get; set; }



        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                
                if (radioButton1.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where Date >= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' AND Date <= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and ClientName ='" + comName.Text + "' ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;


                }
                else if (radioButton2.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where Date >= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' AND Date <= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;


                }
                else if (radioButton3.Checked == true)
                {
                    if (checkBox1.Checked == true)
                    {
                        DataTable dt11 = new DataTable();
                        dt11.Clear();
                        SqlDataAdapter da11 = new SqlDataAdapter("select Category,ROUND(sum(Quantity),2) as Quantity from Billing where ClientName = '" + comName.Text + "' GROUP BY Category ORDER BY Category DESC ", cn);
                        da11.Fill(dt11);
                        this.dataGridView1.DataSource = dt11;
                    }
                    else
                    {
                        DataTable dt11 = new DataTable();
                        dt11.Clear();
                        SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where ClientName = '" + comName.Text + "' ", cn);
                        da11.Fill(dt11);
                        this.dataGridView1.DataSource = dt11;
                    }

                    // select TOP 15 Category,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit from Profit where


                }
                else if (radioButton4.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where  Category ='" + comCategory.Text + "' ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;



                }
            }
            else if (radioButton6.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where Date >= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' AND Date <= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and ClientName ='" + comName.Text + "' ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;


                }
                else if (radioButton2.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where Date >= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' AND Date <= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;


                }
                else if (radioButton3.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where ClientName = '" + comName.Text + "' ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;


                }
                else if (radioButton4.Checked == true)
                {
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where  Category ='" + comCategory.Text + "' ", cn);
                    da11.Fill(dt11);
                    this.dataGridView1.DataSource = dt11;



                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // PrintJbsaDataGridView.Print_Grid(dataGridView1);

        }

        
        private void DailySalesPurchases_Load(object sender, EventArgs e)
        {
            //------------------------------------
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing ", cn);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;
            //------------------------------------

            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Category from Category", cn);
                Da2.Fill(Dt2);
                comCategory.DataSource = Dt2;
                comCategory.DisplayMember = "Category";
            }
            catch { }
            //------------------------------------
            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Clients", cn);
                Da2.Fill(Dt2);
                comName.DataSource = Dt2;
                comName.DisplayMember = "Name";
            }
            catch { }
            //------------------------------------
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comCategory.Enabled = false;
                comName.Enabled = true;
                dateTimePicker4.Enabled = true;
                dateTimePicker1.Enabled = true;

                checkBox1.Visible = false;
            }
            else
            { }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comCategory.Enabled = false;
                comName.Enabled = true;
                dateTimePicker4.Enabled = false;
                dateTimePicker1.Enabled = false;

                checkBox1.Visible = true;
            }
            else
            {
                checkBox1.Visible = false;



            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                comCategory.Enabled = true;
                comName.Enabled = false;
                dateTimePicker4.Enabled = false;
                dateTimePicker1.Enabled = false;

                checkBox1.Visible = false;
            }
            else
            { }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comCategory.Enabled = false;
                comName.Enabled = false;
                dateTimePicker4.Enabled = true;
                dateTimePicker1.Enabled = true;

                checkBox1.Visible = false;
            }
            else
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing  ", cn);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1  ", cn);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;
        }
    }
}
