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
    public partial class ClientsList : Form
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

        private SqlDataReader reed;
        private SqlDataReader raaad;

        //  SqlDataAdapter da;
        SqlDataAdapter daa;
        DataTable dt = new DataTable();
        //---------------------------------
        ReportDataSource rs = new ReportDataSource();

        public ClientsList()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_ClientsList
        {

            public string ID { get; set; }
            public string Name { get; set; }
            public string Company { get; set; }
            public string TelHome { get; set; }
            public string TelMobil { get; set; }
            public string Address { get; set; }
            public string PreviousBalance { get; set; }
            public string StateRaseed { get; set; }


        }

        private void ClientsList_Load(object sender, EventArgs e)
        {
            //----------------- ايجاد العملاء --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Name from Clients", cn);
                Da1.Fill(Dt1);
                comClient.DataSource = Dt1;
                comClient.DisplayMember = "Name";
            }
            catch
            {

            }

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Clients ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;



            }
            catch
            { }

            ////----------------- ايجاد العملاء --------------------
            //try
            //{
            //    SqlDataAdapter Da1;
            //    DataTable Dt1 = new DataTable();
            //    Da1 = new SqlDataAdapter("select Name from Clients", cn);
            //    Da1.Fill(Dt1);
            //    comClient.DataSource = Dt1;
            //    comClient.DisplayMember = "Name";
            //}
            //catch
            //{

            //}


            //****************
            //comboBox5.SelectedIndex = comboBox5.Items.Count - 1;

            //// إيجاد رقم الفاتورة

            //int ii = int.Parse(comboBox5.Text);
            //int jj = ii + 1;
            //textBox10.Text = jj.ToString();

            //textBox16.Text = textBox10.Text;

            //comboBox9.SelectedIndex = comboBox9.Items.Count - 1;

            //// إيجاد رقم حساب اول الجرد

            //int iiii = int.Parse(comboBox9.Text);
            //int jjjj = iiii + 1;
            //textBox53.Text = jjjj.ToString();

            //================================  إيجاد إجمالى الديون على الشركة

            //int sum = 0;
            //for (int i = 0; i < dataGridView1.RowCount; ++i)
            //{
            //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);


            //}
            //textBox8.Text = sum.ToString();
            //================================  إيجاد إجمالى الديون للشركة

            int sum1 = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);


            }
            textMadenon.Text = sum1.ToString();
            //----- إيجاد مجموعة العملاء -----
            SqlDataAdapter Da;
            // SqlDataAdapter Da1;
            DataTable Dt = new DataTable();

            Da = new SqlDataAdapter("select GroupName from Groups ", cn);
            Da.Fill(Dt);
            //comboBox1.DataSource = Dt;
            //comboBox1.DisplayMember = "GroupName";
            combGroups.DataSource = Dt;
            combGroups.DisplayMember = "GroupName";

            // إيجاد حركة اضافة العميل
            //comboBox4.Text = staticfield12.text1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "جميع العملاء")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = false;
                panelRemaining.Visible = false;
                //-----------------------------------------
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where PreviousBalance !='" + 0 + "'", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance >='" + 0 + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textMadenon.Text = reed["PreviousBalance"].ToString();

                }
                reed.Close();

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance <='" + 0 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                    //  double dd = a * (-1); //
                    textDaenon.Text = a.ToString();
                }
                reed.Close();



            }
            else if (comboBox2.Text == "العملاء المدينين")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = false;
                panelRemaining.Visible = false;
                //---------------------------------
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where PreviousBalance >'" + 0 + "'", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance >='" + 0 + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textMadenon.Text = reed["PreviousBalance"].ToString();

                }
                reed.Close();

                textDaenon.Text = "0";
            }
            else if (comboBox2.Text == "العملاء الدائنين")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = false;
                panelRemaining.Visible = false;

                //-------------------------------------
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where PreviousBalance <'" + 0 + "'", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------
                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance <='" + 0 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                    //  double dd = a * (-1); //
                    textDaenon.Text = a.ToString();
                }
                reed.Close();

                textMadenon.Text = "0";
            }
            else if (comboBox2.Text == "مجموعة عملاء")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = true;
                panelRemaining.Visible = false;


            }
            else if (comboBox2.Text == "مجموعة عملاء مدينين")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = true;
                panelRemaining.Visible = false;
            }
            else if (comboBox2.Text == "مجموعة عملاء دائنين")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = true;
                panelRemaining.Visible = false;
            }
            else if (comboBox2.Text == "جميع العملاء مجموعات")
            {
                panel1.Visible = true;
                PanalName.Visible = false;
                PanalGroup.Visible = false;
                panelRemaining.Visible = false;
                //-----------------------------------------
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where PreviousBalance !='" + 0 + "'", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance >='" + 0 + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textMadenon.Text = reed["PreviousBalance"].ToString();

                }
                reed.Close();

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance <='" + 0 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                    //  double dd = a * (-1); //
                    textDaenon.Text = a.ToString();
                }
                reed.Close();
            }
            else if (comboBox2.Text == "بحث عميل")
            {
                panel1.Visible = false;
                panelRemaining.Visible = false;
                PanalName.Visible = true;
                PanalGroup.Visible = false;
            }

            else if (comboBox2.Text == "حالة الرصيد")
            {
               // panel1.Visible = false;
                PanalName.Visible = false;
                PanalGroup.Visible = false;
                panelRemaining.Visible = true;
                //-----------------------------------------
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where StateRaseed ='" + combStateRaseed.Text + "'", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where StateRaseed ='" + combStateRaseed.Text + "' and PreviousBalance >='" + 0 + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textMadenon.Text = reed["PreviousBalance"].ToString();

                }
                reed.Close();

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where StateRaseed ='" + combStateRaseed.Text + "' and PreviousBalance <='" + 0 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                    //  double dd = a * (-1); //
                    textDaenon.Text = a.ToString();
                }
                reed.Close();
            }
         
            else
            {
                PanalName.Visible = false;
                PanalGroup.Visible = false;

                textDaenon.Text = "0";
                textMadenon.Text = "0";

                DataTable dt = new DataTable();
                dt.Clear();
                //SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where PreviousBalance !='" + 0 + "'", cn);
                //da.Fill(dt);
                this.dataGridView1.DataSource = dt;

            }
        }

        private void comClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select * from Clients where Name like '" + comClient.Text + "'", cn);
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

                dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "مجموعة عملاء")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients where Company = '" + combGroups.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients where Company = '" + combGroups.Text + "' and PreviousBalance >'" + 0 + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textMadenon.Text = reed["PreviousBalance"].ToString();

                }
                reed.Close();

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where Company = '" + combGroups.Text + "' and PreviousBalance <='" + 0 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                                                                                     //  double dd = a * (-1); //
                    textDaenon.Text = a.ToString();
                }
                reed.Close();

            }
            else if (comboBox2.Text == "مجموعة عملاء مدينين")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients where Company = '" + combGroups.Text + "' and PreviousBalance >'" + 0 + "' ", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients where Company = '" + combGroups.Text + "' and PreviousBalance >'" + 0 + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textMadenon.Text = reed["PreviousBalance"].ToString();

                }
                reed.Close();

                textDaenon.Text = "0";


            }
            else if (comboBox2.Text == "مجموعة عملاء دائنين")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Clients where Company = '" + combGroups.Text + "' and PreviousBalance <'" + 0 + "' ", cn);
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;

                    dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
                }
                catch
                {

                }


                ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------

                sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where Company = '" + combGroups.Text + "' and PreviousBalance <='" + 0 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                                                                                     //  double dd = a * (-1); //
                    textDaenon.Text = a.ToString();
                }
                reed.Close();

                textMadenon.Text = "0";
            }
            else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label7.Visible == false)
            {
                label7.Visible = true;
                label8.Visible = true;
                textMadenon.Visible = true;
                textDaenon.Visible = true;
            }
            else
            {
                label7.Visible = false;
                label8.Visible = false;
                textMadenon.Visible = false;
                textDaenon.Visible = false;
            }

        }

        private void butPrint_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "جميع العملاء")
            {
               
                AppSetting.TotalClientsMoney = textMadenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();


                //--------------------------------------------------
                //Reports.ReportClints frm = new Reports.ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where PreviousBalance !='" + 0 + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();



            }
            else if (comboBox2.Text == "العملاء المدينين")
            {
               
                AppSetting.TotalClientsMoney = textMadenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints frm = new ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where PreviousBalance >'" + 0 + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();

            }
            else if (comboBox2.Text == "العملاء الدائنين")
            {
                
                AppSetting.TotalClientsMoney = textDaenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints frm = new ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where PreviousBalance <'" + 0 + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else if (comboBox2.Text == "مجموعة عملاء")
            {
              
                AppSetting.TotalClientsMoney = textDaenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints frm = new ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where Company = '" + combGroups.Text + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else if (comboBox2.Text == "مجموعة عملاء مدينين")
            {
                AppSetting.TotalClientsMoney = textMadenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints frm = new ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where Company = '" + combGroups.Text + "' and PreviousBalance >'" + 0 + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else if (comboBox2.Text == "مجموعة عملاء دائنين")
            {
                

                AppSetting.TotalClientsMoney = textDaenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints frm = new ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where Company = '" + combGroups.Text + "' and PreviousBalance <'" + 0 + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else if (comboBox2.Text == "جميع العملاء مجموعات")
            {
                

                AppSetting.TotalClientsMoney = textMadenon.Text;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints2 frm = new ReportClints2();
                //daa = new SqlDataAdapter("select * from Clients where PreviousBalance != '" + 0 + "' ", cn);
                //daa.Fill(frm.elwesifDataSet165.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else if (comboBox2.Text == "حالة الرصيد")
            {
                string Total = "0";
                double a = Convert.ToDouble(textMadenon.Text);
                double b = Convert.ToDouble(textDaenon.Text);


                double r = a + b;
                // txtRemainingNow.Text = r.ToString();
                Total = Math.Round(double.Parse(r.ToString()), 2).ToString();

                AppSetting.TotalClientsMoney = Total;

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //ReportClints2 frm = new ReportClints2();
                //daa = new SqlDataAdapter("select * from Clients where PreviousBalance != '" + 0 + "' ", cn);
                //daa.Fill(frm.elwesifDataSet165.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else if (comboBox2.Text == "بحث عميل")
            {
                AppSetting.TotalClientsMoney = "0";

                List<Class_ClientsList> BM = new List<Class_ClientsList>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Class_ClientsList Categoreys = new Class_ClientsList
                    {

                        ID = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Company = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        TelHome = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TelMobil = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Address = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        PreviousBalance = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        StateRaseed = dataGridView1.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportClints rbm = new Reports.ReportClints();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
                //Reports.ReportClints frm = new Reports.ReportClints();
                //daa = new SqlDataAdapter("select * from Clients Where Name like'" + comClient.Text + "'", cn);
                //daa.Fill(frm.elwesifDataSet83.Clients);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();
            }
            else
            {
                MessageBox.Show("     لم يتم تحديد محتوى للطباعه    ", "ناسف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void combStateRaseed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select * from Clients  Where StateRaseed ='" + combStateRaseed.Text + "' and PreviousBalance !='" + 0 + "'", cn);
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

                dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
            }
            catch
            {

            }


            ////--------------------   اجمال الدائنين والمدينين الفعاليين ----------


            sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where StateRaseed ='" + combStateRaseed.Text + "' and PreviousBalance >='" + 0 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMadenon.Text = reed["PreviousBalance"].ToString();

            }
            reed.Close();

            sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where StateRaseed ='" + combStateRaseed.Text + "' and PreviousBalance <='" + 0 + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                                                                                 //  double dd = a * (-1); //
                textDaenon.Text = a.ToString();
            }
            reed.Close();
        }
    }
}
