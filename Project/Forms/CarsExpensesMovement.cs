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
    public partial class CarsExpensesMovement : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //-------------------------------
        SqlDataAdapter da;
        //---------------------------------
        ReportDataSource rs = new ReportDataSource();

        int ii = 0;
        public CarsExpensesMovement()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }
        public class Class_ExpensesMovement
        {
            public string ID { get; set; }
            public string NumCar { get; set; }
            public string Date { get; set; }
            public string Washed { get; set; }
            public string Filter { get; set; }
            public string Petroleum { get; set; }
            public string Oil { get; set; }
            public string Mechanical { get; set; }
            public string PartChange { get; set; }
            public string Total { get; set; }
            public string Notice { get; set; }
            public string Driver { get; set; }
            public string User { get; set; }


        }

        private void CarsExpensesMovement_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter("select * from SearchCar", cn);
                da.Fill(dt);
                this.dataGridSearchCar.DataSource = dt;

                // dataGridSearchCar.Sort(dataGridSearchCar.Columns[1], ListSortDirection.Ascending);
            }
            catch
            {

            }
            //----------------- ايجاد ارقام السيارات --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select NumCar from Car", cn);
                Da1.Fill(Dt1);
                comNumCar.DataSource = Dt1;
                comNumCar.DisplayMember = "NumCar";
            }
            catch
            {

            }
            try
            {
                string Jopp = "سائق";

                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Name from Employed where Jop = '" + Jopp + "'", cn);
                Da.Fill(Dt);
                comboBox2.DataSource = Dt;
                comboBox2.DisplayMember = "Name";

                comboBox2.Text = "";
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                try
                {
                    SqlDataReader dataReader;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    DataSet dataset3 = new DataSet();

                    dataAdapter.SelectCommand = new SqlCommand("select * from SearchCar where NumCar = '" + comNumCar.Text + "' and  Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' ", cn);

                    dataAdapter.Fill(dataset3);
                    sqlCommand1.Connection =cn;
                    sqlCommand1.CommandText = "select * from SearchCar where NumCar =  '" + comNumCar.Text + "' and Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'  ";
                    //   sqlCommand1.CommandText = "select * from BillingData1 where Date = '" + dateTimePicker3.Text + "'  ";
                    dataReader = sqlCommand1.ExecuteReader();

                    while (dataReader.Read())
                    {
                        dataGridSearchCar.DataSource = dataset3.Tables[0];
                        //checkedListBox1.Items.Add(dataReader["Name"]);
                        ii = ii + 1;


                        // groupBox2.Text = "  تقرير من  " + "" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "" + "  إلى  " + "" + dateTimePicker5.Value.ToString("yyyy/MM/dd") + "  ";

                    }


                    if (ii == 0)

                        MessageBox.Show("This Name is not exist", "  Search");



                    dataReader.Close();
                }
                catch
                {
                }

                //================================  إيجاد إجمالى الغسيل

                int sum1 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum1 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[2].Value);


                }
                textBox1.Text = sum1.ToString();
                //================================  إيجاد إجمالى تغير الفلتر

                int sum2 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum2 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[3].Value);


                }
                textBox2.Text = sum2.ToString();
                //================================  إيجاد إجمالى تفويل

                int sum3 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum3 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[4].Value);


                }
                textBox3.Text = sum3.ToString();
                //================================  إيجاد إجمالى تغير الزيت

                int sum4 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum4 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[5].Value);


                }
                textBox4.Text = sum4.ToString();
                //================================  إيجاد إجمال شغل ميكانيكى

                int sum5 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum5 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[6].Value);


                }
                textBox5.Text = sum5.ToString();
                //================================  إيجاد إجمالى قطع غيار

                int sum6 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum6 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[7].Value);


                }
                textBox6.Text = sum6.ToString();
                //================================  إيجاد إجمالى الإجمالى

                int sum7 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum7 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[8].Value);


                }
                textBox7.Text = sum7.ToString();


            }
            else if (radioButton2.Checked == true)
            {
                try
                {


                    SqlDataReader dataReader;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    DataSet dataset3 = new DataSet();

                    dataAdapter.SelectCommand = new SqlCommand("select * from SearchCar where Driver = '" + comboBox2.Text + "' and  Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' ", cn);

                    dataAdapter.Fill(dataset3);
                    sqlCommand1.Connection = cn;
                    sqlCommand1.CommandText = "select * from SearchCar where Driver = '" + comboBox2.Text + "' and Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'  ";
                    //   sqlCommand1.CommandText = "select * from BillingData1 where Date = '" + dateTimePicker3.Text + "'  ";
                    dataReader = sqlCommand1.ExecuteReader();

                    while (dataReader.Read())
                    {
                        dataGridSearchCar.DataSource = dataset3.Tables[0];
                        //checkedListBox1.Items.Add(dataReader["Name"]);
                        ii = ii + 1;


                        // groupBox2.Text = "  تقرير من  " + "" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "" + "  إلى  " + "" + dateTimePicker5.Value.ToString("yyyy/MM/dd") + "  ";

                    }


                    if (ii == 0)

                        MessageBox.Show("This Name is not exist", "  Search");



                    dataReader.Close();
                }
                catch
                { }
                //================================  إيجاد إجمالى الغسيل

                int sum1 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum1 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[2].Value);


                }
                textBox1.Text = sum1.ToString();
                //================================  إيجاد إجمالى تغير الفلتر

                int sum2 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum2 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[3].Value);


                }
                textBox2.Text = sum2.ToString();
                //================================  إيجاد إجمالى تفويل

                int sum3 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum3 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[4].Value);


                }
                textBox3.Text = sum3.ToString();
                //================================  إيجاد إجمالى تغير الزيت

                int sum4 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum4 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[5].Value);


                }
                textBox4.Text = sum4.ToString();
                //================================  إيجاد إجمال شغل ميكانيكى

                int sum5 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum5 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[6].Value);


                }
                textBox5.Text = sum5.ToString();
                //================================  إيجاد إجمالى قطع غيار

                int sum6 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum6 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[7].Value);


                }
                textBox6.Text = sum6.ToString();
                //================================  إيجاد إجمالى الإجمالى

                int sum7 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum7 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[8].Value);


                }
                textBox7.Text = sum7.ToString();
            }
            else if (radioButton3.Checked == true)
            {

                try
                {


                    SqlDataReader dataReader;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    DataSet dataset3 = new DataSet();

                    dataAdapter.SelectCommand = new SqlCommand("select * from SearchCar where  Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' ", cn);

                    dataAdapter.Fill(dataset3);
                    sqlCommand1.Connection = cn;
                    sqlCommand1.CommandText = "select * from SearchCar where Date >= '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'  ";
                    //   sqlCommand1.CommandText = "select * from BillingData1 where Date = '" + dateTimePicker3.Text + "'  ";
                    dataReader = sqlCommand1.ExecuteReader();

                    while (dataReader.Read())
                    {
                        dataGridSearchCar.DataSource = dataset3.Tables[0];
                        //checkedListBox1.Items.Add(dataReader["Name"]);
                        ii = ii + 1;


                        // groupBox2.Text = "  تقرير من  " + "" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "" + "  إلى  " + "" + dateTimePicker5.Value.ToString("yyyy/MM/dd") + "  ";

                    }


                    if (ii == 0)

                        MessageBox.Show("This Name is not exist", "  Search");



                    dataReader.Close();
                }
                catch
                { }
                //================================  إيجاد إجمالى الغسيل

                int sum1 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum1 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[2].Value);


                }
                textBox1.Text = sum1.ToString();
                //================================  إيجاد إجمالى تغير الفلتر

                int sum2 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum2 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[3].Value);


                }
                textBox2.Text = sum2.ToString();
                //================================  إيجاد إجمالى تفويل

                int sum3 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum3 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[4].Value);


                }
                textBox3.Text = sum3.ToString();
                //================================  إيجاد إجمالى تغير الزيت

                int sum4 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum4 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[5].Value);


                }
                textBox4.Text = sum4.ToString();
                //================================  إيجاد إجمال شغل ميكانيكى

                int sum5 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum5 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[6].Value);


                }
                textBox5.Text = sum5.ToString();
                //================================  إيجاد إجمالى قطع غيار

                int sum6 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum6 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[7].Value);


                }
                textBox6.Text = sum6.ToString();
                //================================  إيجاد إجمالى الإجمالى

                int sum7 = 0;
                for (int i = 0; i < dataGridSearchCar.RowCount; ++i)
                {
                    sum7 += Convert.ToInt32(dataGridSearchCar.Rows[i].Cells[8].Value);


                }
                textBox7.Text = sum7.ToString();
            }
            else
            { }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) //رقم العربية
            {
                // PrintJbsaDataGridView.Print_Grid(dataGridView2);
                if (comNumCar.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل رقم العربية    ", "خطأ");
                    comNumCar.Focus();
                }
                else
                {

                    AppSetting.staticfieldcar.text = comNumCar.Text;
                    AppSetting.staticfieldcar.text1 = comboBox2.Text;
                    AppSetting.staticfieldcar.text2 = dateTimePicker1.Text;
                    AppSetting.staticfieldcar.text3 = dateTimePicker2.Text;
                    AppSetting.staticfieldcar.text4 = textBox1.Text;
                    AppSetting.staticfieldcar.text5 = textBox2.Text;
                    AppSetting.staticfieldcar.text6 = textBox3.Text;
                    AppSetting.staticfieldcar.text7 = textBox4.Text;
                    AppSetting.staticfieldcar.text8 = textBox5.Text;
                    AppSetting.staticfieldcar.text9 = textBox6.Text;
                    AppSetting.staticfieldcar.text10 = textBox7.Text;


                    //Reports.ReportCarsExpensesMovement frm = new Reports.ReportCarsExpensesMovement();
                    //da = new SqlDataAdapter("select * from SearchCar where NumCar = '" + comNumCar.Text + "'and Date >='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", sqlConnection1);
                    //da.Fill(frm.elwesifDataSet102.SearchCar);
                    //frm.reportViewer1.RefreshReport();

                    //frm.Show();

                    List<Class_ExpensesMovement> BM = new List<Class_ExpensesMovement>();
                    BM.Clear();
                    for (int i = 0; i < dataGridSearchCar.Rows.Count - 1; i++)
                    {
                        Class_ExpensesMovement Categoreys = new Class_ExpensesMovement
                        {



                            //ID = dataGridSearchCar.Rows[i].Cells[0].Value.ToString(),
                            NumCar = dataGridSearchCar.Rows[i].Cells[0].Value.ToString(),
                            Date = dataGridSearchCar.Rows[i].Cells[1].Value.ToString(),
                            Washed = dataGridSearchCar.Rows[i].Cells[2].Value.ToString(),
                            Filter = dataGridSearchCar.Rows[i].Cells[3].Value.ToString(),
                            Petroleum = dataGridSearchCar.Rows[i].Cells[4].Value.ToString(),
                            Oil = dataGridSearchCar.Rows[i].Cells[5].Value.ToString(),
                            Mechanical = dataGridSearchCar.Rows[i].Cells[6].Value.ToString(),
                            PartChange = dataGridSearchCar.Rows[i].Cells[7].Value.ToString(),
                            Total = dataGridSearchCar.Rows[i].Cells[8].Value.ToString(),
                            Notice = dataGridSearchCar.Rows[i].Cells[9].Value.ToString(),
                            Driver = dataGridSearchCar.Rows[i].Cells[10].Value.ToString(),
                            //User = dataGridSearchCar.Rows[i].Cells[11].Value.ToString()

                        };

                        BM.Add(Categoreys);
                    }
                    rs.Name = "DataSet1";
                    rs.Value = BM;

                    Reports.ReportCarsExpensesMovement rbm = new Reports.ReportCarsExpensesMovement();
                    rbm.reportViewer1.LocalReport.DataSources.Clear();
                    rbm.reportViewer1.LocalReport.DataSources.Add(rs);

                    rbm.ShowDialog();
                    //-----------------------------------------------------

                }
            }
            else if (radioButton2.Checked == true) // السائق
            {
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم السائق    ", "خطأ");
                    comboBox2.Focus();
                }
                else
                {

                    AppSetting.staticfieldcar.text = comNumCar.Text;
                    AppSetting.staticfieldcar.text1 = comboBox2.Text;
                    AppSetting.staticfieldcar.text2 = dateTimePicker1.Text;
                    AppSetting.staticfieldcar.text3 = dateTimePicker2.Text;
                    AppSetting.staticfieldcar.text4 = textBox1.Text;
                    AppSetting.staticfieldcar.text5 = textBox2.Text;
                    AppSetting.staticfieldcar.text6 = textBox3.Text;
                    AppSetting.staticfieldcar.text7 = textBox4.Text;
                    AppSetting.staticfieldcar.text8 = textBox5.Text;
                    AppSetting.staticfieldcar.text9 = textBox6.Text;
                    AppSetting.staticfieldcar.text10 = textBox7.Text;

                    List<Class_ExpensesMovement> BM = new List<Class_ExpensesMovement>();
                    BM.Clear();
                    for (int i = 0; i < dataGridSearchCar.Rows.Count - 1; i++)
                    {
                        Class_ExpensesMovement Categoreys = new Class_ExpensesMovement
                        {



                            //ID = dataGridSearchCar.Rows[i].Cells[0].Value.ToString(),
                            NumCar = dataGridSearchCar.Rows[i].Cells[0].Value.ToString(),
                            Date = dataGridSearchCar.Rows[i].Cells[1].Value.ToString(),
                            Washed = dataGridSearchCar.Rows[i].Cells[2].Value.ToString(),
                            Filter = dataGridSearchCar.Rows[i].Cells[3].Value.ToString(),
                            Petroleum = dataGridSearchCar.Rows[i].Cells[4].Value.ToString(),
                            Oil = dataGridSearchCar.Rows[i].Cells[5].Value.ToString(),
                            Mechanical = dataGridSearchCar.Rows[i].Cells[6].Value.ToString(),
                            PartChange = dataGridSearchCar.Rows[i].Cells[7].Value.ToString(),
                            Total = dataGridSearchCar.Rows[i].Cells[8].Value.ToString(),
                            Notice = dataGridSearchCar.Rows[i].Cells[9].Value.ToString(),
                            Driver = dataGridSearchCar.Rows[i].Cells[10].Value.ToString(),
                            //User = dataGridSearchCar.Rows[i].Cells[11].Value.ToString()

                        };

                        BM.Add(Categoreys);
                    }
                    rs.Name = "DataSet1";
                    rs.Value = BM;

                    Reports.ReportCarsExpensesMovement rbm = new Reports.ReportCarsExpensesMovement();
                    rbm.reportViewer1.LocalReport.DataSources.Clear();
                    rbm.reportViewer1.LocalReport.DataSources.Add(rs);

                    rbm.ShowDialog();

                    //Reports.ReportCarsExpensesMovement frm = new Reports.ReportCarsExpensesMovement();
                    //da = new SqlDataAdapter("select * from SearchCar where Driver = '" + comboBox2.Text + "'and Date >='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", sqlConnection1);
                    //da.Fill();
                    //frm.reportViewer1.RefreshReport();

                    //frm.Show();

                }
            }
            else if (radioButton3.Checked == true) // التاريخ
            {


               AppSetting.staticfieldcar.text = comNumCar.Text;
                AppSetting.staticfieldcar.text1 = comboBox2.Text;
                AppSetting.staticfieldcar.text2 = dateTimePicker1.Text;
                AppSetting.staticfieldcar.text3 = dateTimePicker2.Text;
                AppSetting.staticfieldcar.text4 = textBox1.Text;
                AppSetting.staticfieldcar.text5 = textBox2.Text;
                AppSetting.staticfieldcar.text6 = textBox3.Text;
                AppSetting.staticfieldcar.text7 = textBox4.Text;
                AppSetting.staticfieldcar.text8 = textBox5.Text;
                AppSetting.staticfieldcar.text9 = textBox6.Text;
                AppSetting.staticfieldcar.text10 = textBox7.Text;

                List<Class_ExpensesMovement> BM = new List<Class_ExpensesMovement>();
                BM.Clear();
                for (int i = 0; i < dataGridSearchCar.Rows.Count - 1; i++)
                {
                    Class_ExpensesMovement Categoreys = new Class_ExpensesMovement
                    {



                        //ID = dataGridSearchCar.Rows[i].Cells[0].Value.ToString(),
                        NumCar = dataGridSearchCar.Rows[i].Cells[0].Value.ToString(),
                        Date = dataGridSearchCar.Rows[i].Cells[1].Value.ToString(),
                        Washed = dataGridSearchCar.Rows[i].Cells[2].Value.ToString(),
                        Filter = dataGridSearchCar.Rows[i].Cells[3].Value.ToString(),
                        Petroleum = dataGridSearchCar.Rows[i].Cells[4].Value.ToString(),
                        Oil = dataGridSearchCar.Rows[i].Cells[5].Value.ToString(),
                        Mechanical = dataGridSearchCar.Rows[i].Cells[6].Value.ToString(),
                        PartChange = dataGridSearchCar.Rows[i].Cells[7].Value.ToString(),
                        Total = dataGridSearchCar.Rows[i].Cells[8].Value.ToString(),
                        Notice = dataGridSearchCar.Rows[i].Cells[9].Value.ToString(),
                        Driver = dataGridSearchCar.Rows[i].Cells[10].Value.ToString(),
                        //User = dataGridSearchCar.Rows[i].Cells[11].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.ReportCarsExpensesMovement rbm = new Reports.ReportCarsExpensesMovement();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);

                rbm.ShowDialog();

                //Reports.ReportCarsExpensesMovement frm = new Reports.ReportCarsExpensesMovement();
                //da = new SqlDataAdapter("select * from SearchCar where Date >='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Date <='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'", sqlConnection1);
                //da.Fill(frm.elwesifDataSet102.SearchCar);
                //frm.reportViewer1.RefreshReport();

                //frm.Show();


            }
            else
            { }
        }
    }
}
