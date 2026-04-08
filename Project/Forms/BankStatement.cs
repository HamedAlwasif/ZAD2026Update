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
    public partial class BankStatement : Form
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
        public BankStatement()
        {
            InitializeComponent();
            cn.Open();
            //sqlCommand1.Connection = cn;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            //----------------
            DataTable dt1 = new DataTable();
            dt1.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From BankHesab where NumHesab='" + comboBox1.Text + "' ", cn);
            da1.Fill(dt1);
            this.dataGridView1.DataSource = dt1;
        }

        private void BankStatement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elwesifDataSet130.BankHesab' table. You can move, or remove it, as needed.
            //      this.bankHesabTableAdapter.Fill(this.elwesifDataSet130.BankHesab);

            //---- إيجاد ارقام الحساب
            SqlDataAdapter Da3;
            DataTable Dt3 = new DataTable();

            Da3 = new SqlDataAdapter("select NumHesab from Bank ", cn);
            Da3.Fill(Dt3);
            comboBox1.DataSource = Dt3;
            comboBox1.DisplayMember = "NumHesab";

            //----------------------------------
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from BankHesab ", cn);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;
        }
    }
}
