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
    public partial class BoxMovement : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        DataTable dt12 = new DataTable();
        //--------------------------------
        SqlCommandBuilder cmdb;
        SqlDataAdapter adap;
        DataSet ds;
        private SqlDataReader reed;
        //int i = 0;
        //------------------------------------
        ReportDataSource rs = new ReportDataSource();


        public BoxMovement()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void Searching()
        {

            //string CategoryTotal;
            try
            {
                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From BoxMove Where Date <'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textBox6.Text = reed["wared"].ToString();
                    textBox7.Text = reed["sader"].ToString();



                }
                reed.Close();



                //-------------------------------------------
                txtReminngOLD.Text = "0";
                double nn = Convert.ToDouble(textBox6.Text);
                double mm = Convert.ToDouble(textBox7.Text);
                double rr = nn - mm;
               // txtReminngOLD.Text = rr.ToString();
                txtReminngOLD.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
            }
            catch
            {

            }

            //*****************************************




            //**************************************
            dataGrDetais.Columns.Clear();

            textBox11.Text = txtReminngOLD.Text;
            //---------------------------------------------


            adap = new SqlDataAdapter("Select ID,Date,Name,Move,Wared,Sader From BoxMove Where Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", cn);


            ds = new System.Data.DataSet();
            adap.Fill(ds, "BillingData_Detail");
            dataGrDetais.DataSource = ds.Tables[0];

            this.dataGrDetais.Columns[0].HeaderText = "م";
            this.dataGrDetais.Columns[1].HeaderText = "التاريخ";
            this.dataGrDetais.Columns[2].HeaderText = "الاسم";
            this.dataGrDetais.Columns[3].HeaderText = "البيان";
            this.dataGrDetais.Columns[4].HeaderText = "الوارد";
            this.dataGrDetais.Columns[5].HeaderText = "الصادر";
            dataGrDetais.Columns.Add("col6", "الرصيد");
            //this.dataGrDetais.Columns[7].HeaderText = "ملاحظات";



            this.dataGrDetais.Columns[0].Width = 60;
            this.dataGrDetais.Columns[1].Width = 100;
            this.dataGrDetais.Columns[2].Width = 120;
            this.dataGrDetais.Columns[3].Width = 300;
            this.dataGrDetais.Columns[4].Width = 60;
            this.dataGrDetais.Columns[5].Width = 60;
            this.dataGrDetais.Columns[6].Width = 100;
            //this.dataGrDetais.Columns[7].Width = 200;



            //------------  دائن مدين ------------
            double sum341 = 0;
            double sum531 = 0;
            for (int i = 0; i < dataGrDetais.RowCount; ++i)
            {
                sum341 += Convert.ToDouble(dataGrDetais.Rows[i].Cells[4].Value);
                sum531 += Convert.ToDouble(dataGrDetais.Rows[i].Cells[5].Value);


            }
            textBox5.Text = sum341.ToString(); //---- مدين
            textBox4.Text = sum531.ToString(); // --- دائن


            //-------------------------------------------

            double nn1 = Convert.ToDouble(textBox5.Text);
            double mm1 = Convert.ToDouble(textBox4.Text);
            double rr1 = nn1 - mm1;
            textBox10.Text = rr1.ToString();


            double nn11 = Convert.ToDouble(txtReminngOLD.Text);
            double mm11 = Convert.ToDouble(textBox10.Text);
            double rr11 = nn11 + mm11;
            txtRemainingNOW.Text = rr11.ToString();

            txtRemainingNOW.Text = Math.Round(double.Parse(txtRemainingNOW.Text), 2).ToString();

        }
        private void BoxMovement_Load(object sender, EventArgs e)
        {
           // Searching();


            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Searching();

            //*****************  حساب الباقى ****************
            foreach (DataGridViewRow item in dataGrDetais.Rows)
            {
                int i = item.Index;
                double t = Convert.ToDouble(textBox11.Text);
                dataGrDetais.Rows[i].Cells[6].Value =
                    ((Convert.ToDouble(dataGrDetais.Rows[i].Cells[4].Value) -
                     Convert.ToDouble(dataGrDetais.Rows[i].Cells[5].Value)) + t).ToString();

                //textBox11.Text = dataGrDetais.Rows[i].Cells[6].Value.ToString();
                textBox11.Text = Math.Round(double.Parse(dataGrDetais.Rows[i].Cells[6].Value.ToString()), 2).ToString();

            }
        }

        private void butSum_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    int n = item.Index;
            //    dataGridView1.Rows[n].Cells[10].Value =
            //        (Double.Parse(dataGridView1.Rows[n].Cells[7].Value.ToString()) -
            //         Double.Parse(dataGridView1.Rows[n].Cells[6].Value.ToString())).ToString();
            //}
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            Searching();

        }
        public class ClassReportBox
        {

            public int ID { get; set; }
            public string DateDay { get; set; }
            public string Name { get; set; }
            public string Move { get; set; }
            public double Sader { get; set; }
            public double Wared { get; set; }
            public double Remaining { get; set; }
        }
        private void butPrint_Click(object sender, EventArgs e)
        {
            try
            {

                //-----------------------
                AppSetting.date_From = dateTimePicker1.Text;
                AppSetting.date_To = dateTimePicker2.Text;

                //-------------اضافة رصيد بداية المدة-------
                List<ClassReportBox> BM = new List<ClassReportBox>();
                BM.Clear();

                ClassReportBox Box_Move1 = new ClassReportBox
                {
                    ID = 0,
                    DateDay = dateTimePicker1.Text,
                    Name = "",
                    Move = "رصيد بداية المدة",
                    Wared = 0,
                    Sader = 0,
                    Remaining = Convert.ToDouble(txtReminngOLD.Text)
                };
                BM.Add(Box_Move1);
                //---------------------------------------
                for (int i = 0; i < dataGrDetais.Rows.Count; i++)
                {
                    dateDateDay.Text = dataGrDetais.Rows[i].Cells[1].Value.ToString();

                    ClassReportBox Box_Move = new ClassReportBox
                    {
                        ID = Convert.ToInt32(dataGrDetais.Rows[i].Cells[0].Value),
                        DateDay = dateDateDay.Text.ToString(),
                        Name = dataGrDetais.Rows[i].Cells[2].Value.ToString(),
                        Move = dataGrDetais.Rows[i].Cells[3].Value.ToString(),
                        Wared = Convert.ToDouble(dataGrDetais.Rows[i].Cells[4].Value),
                        Sader = Convert.ToDouble(dataGrDetais.Rows[i].Cells[5].Value),
                        Remaining = Convert.ToDouble(dataGrDetais.Rows[i].Cells[6].Value)
                    };

                    BM.Add(Box_Move);
                }
                //-------------- رصيد نهاية المدة -------
                ClassReportBox Box_Move2 = new ClassReportBox
                {
                    ID = 0,
                    DateDay = dateTimePicker2.Text,
                    Name = "",
                    Move = "رصيد نهاية المدة",
                    Wared = Convert.ToDouble(textBox5.Text),
                    Sader = Convert.ToDouble(textBox4.Text),
                    Remaining = Convert.ToDouble(txtRemainingNOW.Text)
                };
                BM.Add(Box_Move2);
                //----------------------------------------
                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportBoxMovement rbm = new Reports.ReportBoxMovement();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                //rbm.reportViewer1.LocalReport.ReportEmbeddedResource = "إدارة المخازن.Reports.ReportBox.rdlc";
                rbm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("  تأكده من اختيارك الفترة الصحيحة     ", "  خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
