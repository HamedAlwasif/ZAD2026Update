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
using System.Data.OleDb;
using System.Configuration;
using Microsoft.Reporting.WinForms;

namespace ZAD_Sales.Forms
{
    public partial class OsolSabta : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        string SystemPriceShera = AppSetting.PriceSheraaAcount;
        string AllowUser = AppSetting.AllowUser;

        //---------------------------------
        ReportDataSource rs = new ReportDataSource();


        public OsolSabta()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_OsolSabta
        {
            //Name,Company,TelHome,TelMobil,Address,PreviousBalance,ID
            public string ID { get; set; }
            public string NumBill { get; set; }
            public string Movement { get; set; }
            public string Date { get; set; }
            public string Report { get; set; }
            public string Akaar { get; set; }
            public string Arady { get; set; }
            public string Electric { get; set; }
            public string Asas { get; set; }
            public string Total { get; set; }
            public string Users { get; set; }
        }

        private void GetData ()
        {

            //------------------ ------------------
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from OsolSabta ", cn);
            da11.Fill(dt2);
            this.dataGridView1.DataSource = dt2;

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


            //---------------------------------------------------
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);


                }
                textTatalAll.Text = sum.ToString();
            }
            catch
            { }
        }
        private void OsolSabta_Load(object sender, EventArgs e)
        {
            textUser.Text = UserName;

            GetData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //===================== إضافة حركة الصنف الجديده 

            string Akaar = "";
            string Arady = "";
            string Electric = "";
            string Asas = "";



            if(comboType.Text== "اجهزة الكترونية")
            {
                 Akaar = "0";
                 Arady = "0";
                 Electric = textTotal.Text;
                 Asas = "0";
            }
            else if(comboType.Text == "اثاث")
            {
                Akaar = "0";
                Arady = "0";
                Electric = "0";
                Asas = textTotal.Text;
            }
            else if (comboType.Text == "اراضى")
            {
                Akaar = "0";
                Arady = textTotal.Text;
                Electric = "0";
                Asas = "0";
            }
            else if (comboType.Text == "عقار")
            {
                Akaar = textTotal.Text;
                Arady = "0";
                Electric = "0";
                Asas = "0";
            }


            sqlCommand1.CommandText = "insert into OsolSabta (Movement,Date,Report,Akaar,Arady,Electric,Asas,Total,Users)values ('" + comboType.Text+ "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','"+ textReport.Text+ "','" + Akaar + "','" + Arady + "','" + Electric + "','" + Asas + "','" + textTotal.Text + "','" + textUser.Text + "')";
            sqlCommand1.ExecuteNonQuery();


            GetData();
        }
    }
}
