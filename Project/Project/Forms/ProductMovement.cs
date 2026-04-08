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
using Microsoft.Reporting.WinForms;


namespace ZAD_Sales.Forms
{
    public partial class ProductMovement : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        //--------------------------------
        DataTable dt = new DataTable();
        //------------------------------------
        private SqlDataReader reed;
        private SqlDataReader reeeed;
        //------------------------------------
        SqlDataAdapter adap;
        DataSet ds;
        ReportDataSource rs = new ReportDataSource();


        public ProductMovement()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_ProductMovement
        {

            public string Users { get; set; }
            public string CategoryFrom { get; set; }
            public string CategoryTo { get; set; }
            public string MoveBill { get; set; }
            public string IDBill { get; set; }
            public string Date { get; set; }
            public string Move { get; set; }
            public string Wared { get; set; }
            public string Sader { get; set; }
            public string Total { get; set; }


        }
        private void ProductMovement_Load(object sender, EventArgs e)
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
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                txtReminngOLD.Text = "0";

                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From CategoryMove2 Where Category = '" + comCategory.Text + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    txtWaredTotal.Text = reed["wared"].ToString();
                    txtSaderTotal.Text = reed["sader"].ToString();



                }
                reed.Close();



                //-------------------------------------------
                txtRemainingNOW.Text = "0";
                double nn = Convert.ToDouble(txtWaredTotal.Text);
                double mm = Convert.ToDouble(txtSaderTotal.Text);
                double rr = nn - mm;
                txtRemainingNOW.Text = rr.ToString();

                //--------------------------------------------
                //dataGrDetais.Columns.Clear();

                txtReminngOLD1.Text = "0";
                //---------------------------------------------

                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select Users,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Total From CategoryMove2 Where Category = '" + comCategory.Text + "' ", cn);
                da11.Fill(dt11);
                this.dataGrDetais.DataSource = dt11;

                //--------------------------------------------

                //adap = new SqlDataAdapter("Select Users,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Total From CategoryMove2 Where Category = '" + comCategory.Text + "'  ", cn);


                //ds = new System.Data.DataSet();
                //adap.Fill(ds, "BillingData_Detail");
                //dataGrDetais.DataSource = ds.Tables[0];

                //this.dataGrDetais.Columns[0].HeaderText = "المستخدم";
                //this.dataGrDetais.Columns[1].HeaderText = "من";
                //this.dataGrDetais.Columns[2].HeaderText = "الى";
                //this.dataGrDetais.Columns[3].HeaderText = "فاتورة";
                //this.dataGrDetais.Columns[4].HeaderText = "رقم فاتورة";
                //this.dataGrDetais.Columns[5].HeaderText = "التاريخ";
                //this.dataGrDetais.Columns[6].HeaderText = "الحركة";
                //this.dataGrDetais.Columns[7].HeaderText = "وارد";
                //this.dataGrDetais.Columns[8].HeaderText = "صادر";
                //dataGrDetais.Columns.Add("col8", "الرصيد");
                ////this.dataGrDetais.Columns[7].HeaderText = "ملاحظات";


                //this.dataGrDetais.Columns[0].Width = 100;
                //this.dataGrDetais.Columns[1].Width = 100;
                //this.dataGrDetais.Columns[2].Width = 100;
                //this.dataGrDetais.Columns[3].Width = 120;
                //this.dataGrDetais.Columns[4].Width = 100;
                //this.dataGrDetais.Columns[5].Width = 70;
                //this.dataGrDetais.Columns[6].Width = 60;
                //this.dataGrDetais.Columns[7].Width = 80;
                //this.dataGrDetais.Columns[8].Width = 80;
                //this.dataGrDetais.Columns[9].Width = 100;

                //------------   ------------
                //double sum341 = 0;
                //double sum531 = 0;
                //for (int i = 0; i < dataGrDetais.RowCount; ++i)
                //{
                //    sum341 += Convert.ToDouble(dataGrDetais.Rows[i].Cells[7].Value);
                //    sum531 += Convert.ToDouble(dataGrDetais.Rows[i].Cells[8].Value);


                //}
                //txtWaredTotal.Text = sum341.ToString(); //---- مدين
                //txtSaderTotal.Text = sum531.ToString(); // --- دائن


                ////-------------------------------------------

                //double nn1 = Convert.ToDouble(txtWaredTotal.Text);
                //double mm1 = Convert.ToDouble(txtSaderTotal.Text);
                //double rr1 = nn1 - mm1;
                ////textBox10.Text = rr1.ToString();


                //double nn11 = Convert.ToDouble(txtReminngOLD.Text);
                ////double mm11 = Convert.ToDouble(textBox10.Text);
                //double rr11 = nn11 + rr1;
                //txtRemainingNOW.Text = rr11.ToString();

                //*****************  حساب الباقى ****************
                foreach (DataGridViewRow item in dataGrDetais.Rows)
                {
                    int i = item.Index;
                    double t = Convert.ToDouble(txtReminngOLD1.Text);
                    dataGrDetais.Rows[i].Cells[9].Value =
                        ((Convert.ToDouble(dataGrDetais.Rows[i].Cells[7].Value) -
                         Convert.ToDouble(dataGrDetais.Rows[i].Cells[8].Value)) + t).ToString();

                    txtReminngOLD1.Text = dataGrDetais.Rows[i].Cells[9].Value.ToString();
                }

            }
            catch
            {
                MessageBox.Show("يوجد خطا", "");
            }
        }

        private void Searching()
        {

            //string CategoryTotal;
            try
            {
                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From CategoryMove2 Where Category = '" + comCategory.Text + "'  and Storage = '" + comStorages.Text + "'and Date <'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    txtWared.Text = reed["wared"].ToString();
                    txtSader.Text = reed["sader"].ToString();



                }
                reed.Close();



                //-------------------------------------------
                txtReminngOLD.Text = "0";
                double nn = Convert.ToDouble(txtWared.Text);
                double mm = Convert.ToDouble(txtSader.Text);
                double rr = nn - mm;
                txtReminngOLD.Text = rr.ToString();
            }
            catch
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Searching();

            //-----------------------------
            //dt.Clear();
            //SqlDataAdapter da = new SqlDataAdapter("Select * From CategoryMove2 Where Category = '" + comCategory.Text + "'  and Storage = '" + comStorages.Text + "'", cn);
            //da.Fill(dt);
            //this.dataGridView1.DataSource = dt;


            txtReminngOLD1.Text = txtReminngOLD.Text;


            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select Users,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Total From CategoryMove2 Where Category = '" + comCategory.Text + "'  and  Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", cn);
            da11.Fill(dt11);
            this.dataGrDetais.DataSource = dt11;


            ////--------------------------

            //dataGrDetais.Columns.Clear();

            //txtReminngOLD1.Text = txtReminngOLD.Text;
            ////---------------------------------------------


            //adap = new SqlDataAdapter("Select Users,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Total From CategoryMove2 Where Category = '" + comCategory.Text + "'  and  Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", cn);


            //ds = new System.Data.DataSet();
            //adap.Fill(ds, "Class_ProductMovement");
            //dataGrDetais.DataSource = ds.Tables[0];

            //this.dataGrDetais.Columns[0].HeaderText = "المستخدم";
            //this.dataGrDetais.Columns[1].HeaderText = "من";
            //this.dataGrDetais.Columns[2].HeaderText = "الى";
            //this.dataGrDetais.Columns[3].HeaderText = "فاتورة";
            //this.dataGrDetais.Columns[4].HeaderText = "رقم فاتورة";
            //this.dataGrDetais.Columns[5].HeaderText = "التاريخ";
            //this.dataGrDetais.Columns[6].HeaderText = "الحركة";
            //this.dataGrDetais.Columns[7].HeaderText = "وارد";
            //this.dataGrDetais.Columns[8].HeaderText = "صادر";
            //dataGrDetais.Columns.Add("col8", "الرصيد");
            ////this.dataGrDetais.Columns[7].HeaderText = "ملاحظات";


            //this.dataGrDetais.Columns[0].Width = 100;
            //this.dataGrDetais.Columns[1].Width = 100;
            //this.dataGrDetais.Columns[2].Width = 100;
            //this.dataGrDetais.Columns[3].Width = 120;
            //this.dataGrDetais.Columns[4].Width = 100;
            //this.dataGrDetais.Columns[5].Width = 70;
            //this.dataGrDetais.Columns[6].Width = 60;
            //this.dataGrDetais.Columns[7].Width = 80;
            //this.dataGrDetais.Columns[8].Width = 80;
            //this.dataGrDetais.Columns[10].Width = 100;



            //------------   ------------
            double sum341 = 0;
            double sum531 = 0;
            for (int i = 0; i < dataGrDetais.RowCount; ++i)
            {
                sum341 += Convert.ToDouble(dataGrDetais.Rows[i].Cells[7].Value);
                sum531 += Convert.ToDouble(dataGrDetais.Rows[i].Cells[8].Value);


            }
            txtWaredTotal.Text = sum341.ToString(); //---- مدين
            txtSaderTotal.Text = sum531.ToString(); // --- دائن


            ////-------------------------------------------

            double nn1 = Convert.ToDouble(txtWaredTotal.Text);
            double mm1 = Convert.ToDouble(txtSaderTotal.Text);
            double rr1 = nn1 - mm1;
            //textBox10.Text = rr1.ToString();


            double nn11 = Convert.ToDouble(txtReminngOLD.Text);
            //double mm11 = Convert.ToDouble(textBox10.Text);
            double rr11 = nn11 + rr1;
            txtRemainingNOW.Text = rr11.ToString();

            //*****************  حساب الباقى ****************
            foreach (DataGridViewRow item in dataGrDetais.Rows)
            {
                int i = item.Index;
                double t = Convert.ToDouble(txtReminngOLD1.Text);
                dataGrDetais.Rows[i].Cells[9].Value =
                    ((Convert.ToDouble(dataGrDetais.Rows[i].Cells[7].Value) -
                     Convert.ToDouble(dataGrDetais.Rows[i].Cells[8].Value)) + t).ToString();

                txtReminngOLD1.Text = dataGrDetais.Rows[i].Cells[9].Value.ToString();
            }
        }

        private void textBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    comCategory.Text = "";

                    sqlCommand1.CommandText = "select * from Category where Barcode ='" + textBarcode.Text + "' ";
                    reeeed = sqlCommand1.ExecuteReader();
                    while (reeeed.Read())
                    {

                        comCategory.Text = reeeed["Category"].ToString();

                    }
                    reeeed.Close();


                    butSearch.PerformClick();
                }
                catch
                { }
            }
            else
            {

            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            AppSetting.date_From = dateTimePicker1.Text;
            AppSetting.date_To = dateTimePicker2.Text;
            AppSetting.Category = comCategory.Text;

            //-------------اضافة رصيد بداية المدة-------Category
            List<Class_Category_Move> BM = new List<Class_Category_Move>();
            BM.Clear();

            Class_Category_Move Box_Move1 = new Class_Category_Move
            {
                Date = dateTimePicker1.Text,
                Note = "رصيد بداية المدة",
                Wared = "0",
                Sader = "0",
                Remaining = txtReminngOLD.Text.ToString()
            };
            BM.Add(Box_Move1);
            //---------------------------------------
            for (int i = 0; i < dataGrDetais.Rows.Count; i++)
            {
                dateDateDay.Text = dataGrDetais.Rows[i].Cells[5].Value.ToString();

                string note = dataGrDetais.Rows[i].Cells[6].Value.ToString() + " " +
                            dataGrDetais.Rows[i].Cells[3].Value.ToString() + " من " +
                            dataGrDetais.Rows[i].Cells[1].Value.ToString() + " الى " +
                            dataGrDetais.Rows[i].Cells[2].Value.ToString();
                Class_Category_Move Box_Move = new Class_Category_Move
                {
                    //ID = Convert.ToInt32(dataGrDetais.Rows[i].Cells[0].Value),
                    Date = dateDateDay.Text.ToString(),
                    Note = note.ToString(),
                    Wared = dataGrDetais.Rows[i].Cells[7].Value.ToString(),
                    Sader = dataGrDetais.Rows[i].Cells[8].Value.ToString(),
                    Remaining = dataGrDetais.Rows[i].Cells[9].Value.ToString()
                };

                BM.Add(Box_Move);
            }
            //-------------- رصيد نهاية المدة -------
            Class_Category_Move Box_Move2 = new Class_Category_Move
            {
                Date = dateTimePicker2.Text,

                Note = "رصيد نهاية المدة",
                Wared = "0",
                Sader = "0",
                Remaining = txtRemainingNOW.Text.ToString()
            };
            BM.Add(Box_Move2);
            //----------------------------------------
            rs.Name = "DataSet1";
            rs.Value = BM;
            Reports.ReportProductMovement rbm = new Reports.ReportProductMovement();
            rbm.reportViewer1.LocalReport.DataSources.Clear();
            rbm.reportViewer1.LocalReport.DataSources.Add(rs);
            rbm.ShowDialog();
        }
        public class Class_Category_Move
        {

            public string Date { get; set; }
            public string Note { get; set; }
            public string Wared { get; set; }
            public string Sader { get; set; }
            public string Remaining { get; set; }


        }
    }
}
