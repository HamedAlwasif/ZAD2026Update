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
    public partial class DailyClosing : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        private SqlDataReader reed;

        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();

        string typeBill = "";

        ReportDataSource rs = new ReportDataSource();

        public DailyClosing()
        {
            InitializeComponent();
            //cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_Producers
        {

            public string Barcode { get; set; }
            public string Category { get; set; }
            public string Storage { get; set; }
            public string Quantity { get; set; }
            public string QuantityT { get; set; }
            public string Unity { get; set; }
            public string Faction { get; set; }
            public string Total { get; set; }
            public string Price { get; set; }
            public string Value { get; set; }
            public string Near { get; set; }
            public string Emwared { get; set; }


        }
        public class Class_CategoreysBill
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

        public void SystemProgram()
        {
            //------------------- البحث نظام العمل جملة او قطاعى -------------

            string Kataey = "";
            string GomKataey = "";

            cn.Open();
            sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                Kataey = reed["Kataey"].ToString();
                GomKataey = reed["GomlaKataey"].ToString();


            }

            reed.Close();

            cn.Close();


            if (Kataey == "1") // قطاعى
            {

                SystemPro = "قطاعى";
            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";

            }
            // نهاية البحث نظام العمل جملة او قطاعى
        }
        public class Class_CateorayDay
        {

           // public string NumBill { get; set; }
         //   public string Date { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
           // public string Type { get; set; }
           // public string PriceShraa { get; set; }
            public string PriceTotal { get; set; }
           // public string Profit { get; set; }


        }
        public class Class_BillDay
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Type { get; set; } 
            public string Move { get; set; }
            public string TotalBill { get; set; }
            public string Paid { get; set; }
            public string Remaining { get; set; }


        }

        public class Class_BillDay1
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Move { get; set; }
            public string TotalBillBuy { get; set; }
            public string Pay { get; set; }
            public string Remaining { get; set; }


        }

        public class Class_ProjectTotal
        {

            public string ID { get; set; }
            public string Month { get; set; }
            public string Year { get; set; }
            public string Date { get; set; }
            public string StoreValue { get; set; }
            public string CustomerValue { get; set; }
            public string BoxValue { get; set; }
            public string Profits { get; set; }
            public string DailyExpenses { get; set; }
            public string AdvExpenses { get; set; }
            public string SeianaExpenses { get; set; }
            public string RentExpenses { get; set; }
            public string ElectricityExpenses { get; set; }
            public string WaterExpenses { get; set; }
            public string PhoneExpenses { get; set; }
            public string InternetExpenses { get; set; }
            public string CarExpenses { get; set; }
            public string Salaries { get; set; }
            public string WithdrawProfits { get; set; }
            public string TotalExpenses { get; set; }
            public string PurchasingExpenses { get; set; }
            public string AddMoneyBox { get; set; }
            public string DiscMoneyBox { get; set; }
            public string Sales { get; set; }
            public string DiscSales { get; set; }
            public string Purchases { get; set; }
            public string DiscPurchases { get; set; }
            public string PurchaseReturns { get; set; }
            public string SalesReturns { get; set; }
            public string Taweredat { get; set; }
            public string Tahselat { get; set; }
        }

        public class Class_ProjectTotals
        {

            public string ID { get; set; }
            public string Month { get; set; }
            public string Year { get; set; }
            public string Date { get; set; }
            public string StoreValue { get; set; }
            public string CustomerValue { get; set; }
            public string BoxValue { get; set; }
            public string Profits { get; set; }
            public string DailyExpenses { get; set; }
            public string AdvExpenses { get; set; }
            public string SeianaExpenses { get; set; }
            public string RentExpenses { get; set; }
            public string ElectricityExpenses { get; set; }
            public string WaterExpenses { get; set; }
            public string PhoneExpenses { get; set; }
            public string InternetExpenses { get; set; }
            public string CarExpenses { get; set; }
            public string Salaries { get; set; }
            public string WithdrawProfits { get; set; }
            public string TotalExpenses { get; set; }
            public string PurchasingExpenses { get; set; }
            public string AddMoneyBox { get; set; }
            public string DiscMoneyBox { get; set; }
            public string Sales { get; set; }
            public string DiscSales { get; set; }
            public string Purchases { get; set; }
            public string DiscPurchases { get; set; }
            public string PurchaseReturns { get; set; }
            public string SalesReturns { get; set; }
            public string Taweredat { get; set; }
            public string Tahselat { get; set; }
        }
        private void DailyClosing_Load(object sender, EventArgs e)
        {
            SystemProgram();
            GetCategoreySale();
            GetBill();

            button1.PerformClick();
            button5.PerformClick();
            button11.PerformClick();
            buttonBill.PerformClick();
            //=================================

            DataTable dtB = new DataTable();
            dtB.Clear();
            SqlDataAdapter daB = new SqlDataAdapter("select * from ProjectTotal  ", cn); 

            daB.Fill(dtB);

            this.dataGridView3.DataSource = dtB;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //-------------------- اعلى الاصناف ارباحا

           // panel3.Visible = true;

            DataTable dt15 = new DataTable();
            dt15.Clear();
            SqlDataAdapter da215 = new SqlDataAdapter("select  Category,sum(Quantity) as Quantity,sum(Total) as PriceTotal from Billing where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' GROUP BY Category ORDER BY Category", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da215 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da215.Fill(dt15);

            this.dataGridView1.DataSource = dt15;


            //-------------------- فواتير



           
                // panel14.Visible = false;
                // panel10.Visible = false;
               // panelBillDay.Visible = true;


                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;

                try
                {
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);
                        sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[5].Value);



                    }
                    textTotalBill.Text = sum.ToString();
                    textTotalTahsel.Text = sum1.ToString();

                }
                catch
                { }

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber + "";
                    rowNumber = rowNumber + 1;

                    rowNumber1 = rowNumber1 + 1;
                }
                // dataGridClientsDay.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                //عدد الفواتير
                textNumBill.Text = rowNumber1.ToString();


            
        }
        private void GetCategoreySale()
        {
            DataTable dt15 = new DataTable();
            dt15.Clear();
            SqlDataAdapter da215 = new SqlDataAdapter("select  Category,sum(Quantity) as Quantity,sum(Total) as PriceTotal from Billing where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' GROUP BY Category ORDER BY Category ", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da215 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da215.Fill(dt15);

            this.dataGridView1.DataSource = dt15;

            //-------------------- فواتير




            // panel14.Visible = false;
            // panel10.Visible = false;
            // panelBillDay.Visible = true;


            if (radioButton2.Checked == true) //------------ ايجاد فواتير المشتريات
            {
                string typeBilling = "فاتورة مشتريات";

                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Move like '" + typeBilling + "' and Date >= '" + dateTimePicker6.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker7.Value.ToString("MM/dd/yyyy") + "'  ", cn);
                da21.Fill(dt12);
                this.dataGridView5.DataSource = dt12;

                try
                {
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView5.Rows[i].Cells[4].Value);
                        sum1 += Convert.ToDouble(dataGridView5.Rows[i].Cells[5].Value);



                    }
                    textTotalBill.Text = sum.ToString();
                    textTotalTahsel.Text = sum1.ToString();

                }
                catch
                { }

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber + "";
                    rowNumber = rowNumber + 1;

                    rowNumber1 = rowNumber1 + 1;
                }
                // dataGridClientsDay.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                //عدد الفواتير
                textNumBill.Text = rowNumber1.ToString();

             //   typeBill = "فواتير المشتريات";
            }
            else if (radioButton1.Checked == true)  //------------ ايجاد فواتير المبيعات
            {
                string typeBilling = "فاتورة مبيعات";

                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Move like '" + typeBilling +"' and Date >= '" + dateTimePicker6.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker7.Value.ToString("MM/dd/yyyy") + "'  ", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;

                try
                {
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);
                        sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[5].Value);



                    }
                    textTotalBill.Text = sum.ToString();
                    textTotalTahsel.Text = sum1.ToString();

                }
                catch
                { }

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber + "";
                    rowNumber = rowNumber + 1;

                    rowNumber1 = rowNumber1 + 1;
                }
                // dataGridClientsDay.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                //عدد الفواتير
                textNumBill.Text = rowNumber1.ToString();

            }
            else
            {

            }

               
        }
        private void button11_Click(object sender, EventArgs e)
        {
            GetCategoreySale();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-------------------- اعلى الاصناف ارباحا

            // panel3.Visible = true;



            //DataTable dt15 = new DataTable();
            //dt15.Clear();
            //SqlDataAdapter da215 = new SqlDataAdapter("select  Category,sum(Quantity) as Quantity,sum(Total) as PriceTotal from Billing where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' GROUP BY Category ORDER BY Category", cn); // ASC تصاعدى  --- DESC تنازلى

            ////  SqlDataAdapter da215 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            //da215.Fill(dt15);

            //this.dataGridView1.DataSource = dt15;


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,Faction,PriceMostahlek,(Total*PriceMostahlek) as Valuee From Category  ", cn);

                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الباركود";
                    this.dataGridReport.Columns[0].Width = 100;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 300;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "السعر";
                    this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    //this.dataGridReport.Columns[7].HeaderText = "ملاحظات";
                    //this.dataGridReport.Columns[7].Width = 150;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);






                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,Emwared from Category  ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    //this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    //this.dataGridReport.Columns[9].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "ملاحظات";
                    this.dataGridReport.Columns[9].Width = 150;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[9].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[7].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[8].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------



                }
                catch
                {

                }





            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //-----------------------
            AppSetting.date_From = dateTimePicker2.Text;
            AppSetting.date_To = dateTimePicker5.Text;


            List<Class_CateorayDay> BM1 = new List<Class_CateorayDay>();
            BM1.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Class_CateorayDay Categoreys1 = new Class_CateorayDay
                {

                    Category = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Quantity = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    PriceTotal = dataGridView1.Rows[i].Cells[2].Value.ToString(),


                };

                BM1.Add(Categoreys1);
            }

            //Class_DailyTransactionsBillingData Categoreys2 = new Class_DailyTransactionsBillingData
            //{


            //    NumBill = "",
            //    Name = "",
            //    Type = "",
            //    Move = "الاجمالى",
            //    TotalBill = txtTotalBill.Text,
            //    TotalBillBuy = txtTotalBillBuy.Text,
            //    TotalBillInvalid = txtTotalBillInvalid.Text,
            //    TotalBillBuyInvalid = txtTotalBillBuyInvalid.Text,
            //    Pay = txtPay.Text,
            //    Paid = txtPaid.Text,

            //};

            // BM.Add(Categoreys2);

            rs.Name = "DataSet1";
            rs.Value = BM1;

            Reports.Frm_ReportDailyCategry rbm = new Reports.Frm_ReportDailyCategry();

            rbm.reportViewer1.LocalReport.DataSources.Clear();
            rbm.reportViewer1.LocalReport.DataSources.Add(rs);



            rbm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppSetting.date_From = dateTimePicker2.Text;
            AppSetting.date_To = dateTimePicker5.Text;
            AppSetting.Total_Bill = textTotalBill.Text;
                AppSetting.Total_Paid = textTotalTahsel.Text;
                AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");


                List<Class_BillDay> BM = new List<Class_BillDay>();
                BM.Clear();
                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    Class_BillDay BillDay = new Class_BillDay
                    {
                        NumBill = dataGridView4.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView4.Rows[i].Cells[1].Value.ToString(),
                        Type = dataGridView4.Rows[i].Cells[2].Value.ToString(),
                        Move = dataGridView4.Rows[i].Cells[3].Value.ToString(),
                        TotalBill = dataGridView4.Rows[i].Cells[4].Value.ToString(),
                        Paid = dataGridView4.Rows[i].Cells[5].Value.ToString(),
                        Remaining = dataGridView4.Rows[i].Cells[6].Value.ToString(),

                    };

                    BM.Add(BillDay);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.Frm_BillDay rbm = new Reports.Frm_BillDay();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);




                rbm.ShowDialog();
            
        }

        private void butPrintautoss_Click(object sender, EventArgs e)
        {

            if (SystemPro == "قطاعى") // قطاعى
            {

                List<Class_Producers> BM = new List<Class_Producers>();
                BM.Clear();
                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {


                    Class_Producers Categoreys = new Class_Producers
                    {

                        Barcode = dataGridReport.Rows[i].Cells[0].Value.ToString(),
                        Storage = dataGridReport.Rows[i].Cells[1].Value.ToString(),
                        Category = dataGridReport.Rows[i].Cells[2].Value.ToString(),
                        Total = dataGridReport.Rows[i].Cells[3].Value.ToString(),
                        Price = dataGridReport.Rows[i].Cells[5].Value.ToString(),
                        Value = dataGridReport.Rows[i].Cells[6].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }

                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportProducer rbm = new Reports.ReportProducer();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                rbm.reportViewer2.Visible = false;
                rbm.ShowDialog();
                //PrintJbsaDataGridView.Print_Grid(dataGridView2);
            }
            else // جملة وقطاعى
            {
                List<Class_Producers> BM = new List<Class_Producers>();
                BM.Clear();
                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {


                    Class_Producers CategoreysGK = new Class_Producers
                    {

                        Barcode = dataGridReport.Rows[i].Cells[0].Value.ToString(),
                        Category = dataGridReport.Rows[i].Cells[2].Value.ToString(),
                        Storage = dataGridReport.Rows[i].Cells[1].Value.ToString(),
                        Quantity = dataGridReport.Rows[i].Cells[3].Value.ToString(),
                        QuantityT = dataGridReport.Rows[i].Cells[4].Value.ToString(),
                        Unity = dataGridReport.Rows[i].Cells[5].Value.ToString(),
                        Faction = dataGridReport.Rows[i].Cells[6].Value.ToString(),
                        Total = dataGridReport.Rows[i].Cells[7].Value.ToString(),
                        Price = dataGridReport.Rows[i].Cells[8].Value.ToString(),
                        Value = dataGridReport.Rows[i].Cells[9].Value.ToString()

                    };

                    BM.Add(CategoreysGK);
                }

                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportProducer_GK rbm = new Reports.ReportProducer_GK();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                rbm.ShowDialog();




                //PrintJbsaDataGridView.Print_Grid(dataGridView1);

            }
        }
        private void GetBill()
        {
            if (radButPurchases.Checked == true) //------------ ايجاد فواتير المشتريات
            {

                DataTable dtB = new DataTable();
                dtB.Clear();
                SqlDataAdapter daB = new SqlDataAdapter("select NumBill,ClientName,Date,Num,Category,Quantity,Type,Price,Discount,Total from Billing1 where  Date >= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' ORDER BY NumBill ", cn); // ASC تصاعدى  --- DESC تنازلى

                daB.Fill(dtB);

                this.dataGridView2.DataSource = dtB;

                typeBill = "فواتير المشتريات";
            }
            else if (radButSales.Checked == true)  //------------ ايجاد فواتير المبيعات
            {

                DataTable dtB = new DataTable();
                dtB.Clear();
                SqlDataAdapter daB = new SqlDataAdapter("select NumBill,ClientName,Date,Num,Category,Quantity,Type,Price,Discount,Total from Billing where  Date >= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' ORDER BY NumBill ", cn); // ASC تصاعدى  --- DESC تنازلى

                daB.Fill(dtB);

                this.dataGridView2.DataSource = dtB;

                typeBill = "فواتير المبيعات";
            }
            else
            { }
        }
        private void buttonBill_Click(object sender, EventArgs e)
        {
            GetBill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppSetting.TypeBill = typeBill;


            List<Class_CategoreysBill> BM = new List<Class_CategoreysBill>();
            BM.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                Class_CategoreysBill CategoreysBill = new Class_CategoreysBill
                {


                    NumBill = dataGridView2.Rows[i].Cells[0].Value.ToString(),
                    ClientName = dataGridView2.Rows[i].Cells[1].Value.ToString(),
                    Date = dataGridView2.Rows[i].Cells[2].Value.ToString(),
                    Num = dataGridView2.Rows[i].Cells[3].Value.ToString(),
                    Category = dataGridView2.Rows[i].Cells[4].Value.ToString(),
                    Quantity = dataGridView2.Rows[i].Cells[5].Value.ToString(),
                    Type = dataGridView2.Rows[i].Cells[6].Value.ToString(),
                    Price = dataGridView2.Rows[i].Cells[7].Value.ToString(),
                    Discount = dataGridView2.Rows[i].Cells[8].Value.ToString(),
                    Total = dataGridView2.Rows[i].Cells[9].Value.ToString(),

                };

                BM.Add(CategoreysBill);
            }
            rs.Name = "DataSet1";
            rs.Value = BM;

            Reports.Frm_AllBills rbm = new Reports.Frm_AllBills();
            rbm.reportViewer1.LocalReport.DataSources.Clear();
            rbm.reportViewer1.LocalReport.DataSources.Add(rs);
            rbm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetCategoreySale();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Visible = true;
            dataGridView5.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Visible = false;
            dataGridView5.Visible = true;
        }
    }
}
