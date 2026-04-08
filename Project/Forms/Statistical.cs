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
    public partial class Statistical : Form
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
        private SqlDataReader red;
        private SqlDataReader rred;

        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();

        string typeBill = "";

        ReportDataSource rs = new ReportDataSource();
        public Statistical()
        {
            InitializeComponent();
            sqlCommand1.Connection = cn;
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
            public string TotalValue { get; set; }
        }
        public class Class_Statistical
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
            public string TotalValue { get; set; }
        }

        private void GetSumValue()
        {
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                int i = item.Index;
                double b = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
                double m = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                double s = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
                double sa = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);

                double ms = Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
                double mssh = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

                double sss = (b + m + s + sa) - (ms + mssh);
                dataGridView2.Rows[i].Cells[19].Value = sss.ToString();


            }
        }
        private void GetData()
        {
            DataTable dtB = new DataTable();
            dtB.Clear();
            SqlDataAdapter daB = new SqlDataAdapter("select * from ProjectTotal  ", cn);

            daB.Fill(dtB);

            this.dataGridView1.DataSource = dtB;
            this.dataGridView2.DataSource = dtB;
            this.dataGridView3.DataSource = dtB;

        }
        private void Statistical_Load(object sender, EventArgs e)
        {
            SystemProgram();

            //=================================
            GetData();

            GetSumValue();


            string month = dateTimePicker1.Value.ToString("MM");
            string year = dateTimePicker1.Value.ToString("yyyy");

            comboBox1.Text = year;
            comboBox2.Text=month;

            //  butSUMM.PerformClick();

            //------------------- ايجاد القيمة الاجمالية 
            // -------------البضاعه + المديونيات + الصندوق + سحب الارباح - اجمالى المصاريف - مصروفات المشتريات
            //for (int i = 0; i < dataGridView2.RowCount; ++i)
            //{
            //    double b = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            //    double m = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            //    double s = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
            //    double sa = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);

            //    double ms = Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
            //    double mssh = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

            //    double sss = (b + m + s + sa) - (ms + mssh);
            //    dataGridView2.Rows[i].Cells[19].Value = sss.ToString();
            //}

            //foreach (DataGridViewRow item in dataGridView2.Rows)
            //{
            //    int i = item.Index;
            //    double b = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            //    double m = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            //    double s = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
            //    double sa = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);

            //    double ms = Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
            //    double mssh = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

            //    double sss = (b + m + s + sa) - (ms + mssh);
            //    dataGridView2.Rows[i].Cells[19].Value = sss.ToString();
            //    // double t = Convert.ToDouble(textBox11.Text);
            //    //dataGridView2.Rows[i].Cells[19].Value =
            //    //    ((Convert.ToDouble(dataGrDetais.Rows[i].Cells[4].Value) -
            //    //     Convert.ToDouble(dataGrDetais.Rows[i].Cells[5].Value)) + t).ToString();

            //    ////textBox11.Text = dataGrDetais.Rows[i].Cells[6].Value.ToString();
            //    //textBox11.Text = Math.Round(double.Parse(dataGrDetais.Rows[i].Cells[6].Value.ToString()), 2).ToString();

            //}
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            GetSumValue();

            List<Class_ProjectTotals> BM = new List<Class_ProjectTotals>();
            BM.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {


                Class_ProjectTotals Categoreys = new Class_ProjectTotals
                {

                    ID = dataGridView2.Rows[i].Cells[0].Value.ToString(),
                    Date = dataGridView2.Rows[i].Cells[1].Value.ToString(),
                    StoreValue = dataGridView2.Rows[i].Cells[2].Value.ToString(),
                    CustomerValue = dataGridView2.Rows[i].Cells[3].Value.ToString(),
                    BoxValue = dataGridView2.Rows[i].Cells[4].Value.ToString(),
                    Profits = dataGridView2.Rows[i].Cells[5].Value.ToString(),
                    TotalExpenses = dataGridView2.Rows[i].Cells[7].Value.ToString(),
                    PurchasingExpenses = dataGridView2.Rows[i].Cells[8].Value.ToString(),
                    WithdrawProfits = dataGridView2.Rows[i].Cells[6].Value.ToString(),
                    AddMoneyBox = dataGridView2.Rows[i].Cells[9].Value.ToString(),
                    DiscMoneyBox = dataGridView2.Rows[i].Cells[10].Value.ToString(),
                    Sales = dataGridView2.Rows[i].Cells[11].Value.ToString(),
                    DiscSales = dataGridView2.Rows[i].Cells[12].Value.ToString(),
                    Purchases = dataGridView2.Rows[i].Cells[13].Value.ToString(),
                    DiscPurchases = dataGridView2.Rows[i].Cells[14].Value.ToString(),
                    PurchaseReturns = dataGridView2.Rows[i].Cells[15].Value.ToString(),
                    SalesReturns = dataGridView2.Rows[i].Cells[16].Value.ToString(),
                    Taweredat = dataGridView2.Rows[i].Cells[17].Value.ToString(),
                    Tahselat = dataGridView2.Rows[i].Cells[18].Value.ToString(),
                    TotalValue = dataGridView2.Rows[i].Cells[19].Value.ToString()
                };

                BM.Add(Categoreys);
            }

            rs.Name = "DataSet1";
            rs.Value = BM;
            Reports.Frm_Statistical rbm = new Reports.Frm_Statistical();
            rbm.reportViewer1.LocalReport.DataSources.Clear();
            rbm.reportViewer1.LocalReport.DataSources.Add(rs);
           
            rbm.ShowDialog();
        }
        public void GetValueMonth()
        {
                cn.Open();


                string TotalBill = "";
                string Discount = "";
                string DiscountBuy = "";
                string TotalBillInvalid = "";
                string TotalBillBuyInvalid = "";
                string Creditor = "";
                string Adding = "";
                string Pay = "";
                string Paid = "";
                //----------------------
                string Month = "";
                string Year = "";
                string DateMonth = "";
                string ValueMonth = "";
                string MoshtriaatTotal = "";
                string Cars = "";
                //------------------------------
                string Moshtriat = "";
                string Nathria = "";
                string Advs = "";
                string Seiana = "";
                //-----------------------
                string Profits = "";
                string BoxMoney = "";
                string ClientValue = "";
                string TotalMasrofat2 = "";
                string text_Arbah = "";
                string Net = "";
                string Tell = "";
                string Water = "";
                string Kahraba = "";
                string Egar = "";

                //============================================

                Month = dateTimePicker1.Value.ToString("MM");
                Year = dateTimePicker1.Value.ToString("yyyy");

                DateMonth = Month + "-" + Year;

                //======================== تحديث اجمالى البضاعه شراء فى الداتا بيز  ====================


                sqlCommand1.CommandText = "update Category set  Value=Total*Price ";
                sqlCommand1.ExecuteNonQuery();



                //======================= اجمالى البضاعه الحالية ======================


                sqlCommand1.CommandText = "select ISNULL(SUM(Total*Price),0) as ValueShera From Category   ";
                rred = sqlCommand1.ExecuteReader();
                while (rred.Read())
                {
                    string ValueShera = rred["ValueShera"].ToString();

                    ValueMonth = Math.Round(double.Parse(ValueShera), 0).ToString();

                }
                rred.Close();


                //--------- المبيعات والمشتريات -------------


                sqlCommand1.CommandText = "select ISNULL(SUM(TotalBill),0) as TotalBill,ISNULL(SUM(Discount),0) as Discount,ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy,ISNULL(SUM(DiscountBuy),0) as DiscountBuy,ISNULL(SUM(TotalBillInvalid),0) as TotalBillInvalid,ISNULL(SUM(TotalBillBuyInvalid),0) as TotalBillBuyInvalid,ISNULL(SUM(Creditor),0) as Creditor,ISNULL(SUM(Adding),0) as Adding,ISNULL(SUM(Pay),0) as Pay,ISNULL(SUM(Paid),0) as Paid From BillingData  where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    TotalBill = reed["TotalBill"].ToString();
                    Discount = reed["Discount"].ToString();
                    DiscountBuy = reed["DiscountBuy"].ToString();
                    TotalBillInvalid = reed["TotalBillInvalid"].ToString();
                    TotalBillBuyInvalid = reed["TotalBillBuyInvalid"].ToString();
                    Creditor = reed["Creditor"].ToString();
                    Adding = reed["Adding"].ToString();
                    Pay = reed["Pay"].ToString();
                    Paid = reed["Paid"].ToString();

                    textMabeaat.Text = Math.Round(double.Parse(TotalBill), 0).ToString();
                    textDiscMabeaat.Text = Math.Round(double.Parse(Discount), 0).ToString();
                    textDisSheraa.Text = Math.Round(double.Parse(DiscountBuy), 0).ToString();
                    textHalekBeeea.Text = Math.Round(double.Parse(TotalBillInvalid), 0).ToString();
                    textHaleksheraa.Text = Math.Round(double.Parse(TotalBillBuyInvalid), 0).ToString();
                    textTawreed.Text = Math.Round(double.Parse(Pay), 0).ToString();
                    textTahseel.Text = Math.Round(double.Parse(Paid), 0).ToString();



                }
                reed.Close();


                //------------------ ايجاد قيمة المشتريات بدون بضاعة اول المدة 

                string Moveee = "فاتورة مشتريات";


                sqlCommand1.CommandText = "Select ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy From BillingData Where  Move like '" + Moveee + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    MoshtriaatTotal = reed["TotalBillBuy"].ToString();

                    MoshtriaatTotal = Math.Round(double.Parse(textMoshtriaatTotal.Text), 0).ToString();
                }
                reed.Close();


                //======================= المصروفات ===============================

                //------------ ايجاد مصاريف السيارات

                sqlCommand1.CommandText = "Select ISNULL(SUM(Total),0) as Total From SearchCar Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Cars = reed["Total"].ToString();
                    Cars = Math.Round(double.Parse(textCars.Text), 0).ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف مشتريات ----------------------------------
                string Masrofat = "مصاريف مشتريات";
                Moshtriat = "0";


                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Moshtriat = reed["Paid"].ToString();
                    Moshtriat = Math.Round(double.Parse(textMoshtriat.Text), 2).ToString();



                }
                reed.Close();


                //-------------------------------- مصاريف نثرية ----------------------------------
                string Masrofat1 = "مصاريف نثريه";
                Nathria = "0";


                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat1 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Nathria = reed["Paid"].ToString();


                }
                reed.Close();



                //-------------------------------- مصاريف دعاية ----------------------------------
                string Masrofat2 = "مصاريف دعاية";
                Advs = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat2 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Advs = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف صيانه ----------------------------------
                string Masrofat3 = "مصاريف صيانة";
                Seiana = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat3 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Seiana = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف ايجار ----------------------------------
                string Masrofat4 = "مصاريف ايجار";
                Egar = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat4 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Egar = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف كهرباء ----------------------------------
                string Masrofat5 = "فاتورة كهرباء";
                Kahraba = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat5 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Kahraba = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف مياه ----------------------------------
                string Masrofat6 = "فاتورة مياه";
                Water = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat6 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Water = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف تليفون ----------------------------------
                string Masrofat7 = "فاتورة تليفون";
                Tell = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat7 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Tell = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- مصاريف انترنت ----------------------------------
                string Masrofat8 = "فاتورة انترنت";
                Net = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat8 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Net = reed["Paid"].ToString();


                }
                reed.Close();


                //-------------------------------- الارباح المسحوبة ----------------------------------
                string Masrofat10 = "سحب ارباح";
                text_Arbah = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat10 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    text_Arbah = reed["Paid"].ToString();


                }
                reed.Close();


                //--------------------------------   اجمالى المصاريف بدون مصاريف الشراء و سحب ارباح ----------------------------------
                string Masrofat9 = "مصاريف مشتريات";
                string Masrofat999 = "سحب ارباح";
                TotalMasrofat2 = "0";

                sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move != '" + Masrofat999 + "' and move != '" + Masrofat9 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    TotalMasrofat2 = reed["Paid"].ToString();


                }
                reed.Close();


                //--------- الاموال الصادرة والواردة من الادارة -------------


                sqlCommand1.CommandText = "select ISNULL(SUM(Sader),0) as Sader,ISNULL(SUM(Wared),0) as Wared From Movemoney  where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    string Sader1 = reed["Sader"].ToString();
                    string Wared1 = reed["Wared"].ToString();
                    textWaredMoney.Text = Wared1;
                    textSadreMoney.Text = Sader1;
                }
                reed.Close();


                //======================= اجمالى المديونيات والدائنات =====================

                sqlCommand1.CommandText = "select sum(PreviousBalance) as PreviousBalance From Clients  ";
                rred = sqlCommand1.ExecuteReader();
                while (rred.Read())
                {

                    ClientValue = rred["PreviousBalance"].ToString();

                    // ClientValue = Math.Round(double.Parse(textClientValue.Text), 0).ToString();
                }
                rred.Close();


                //======================= اجمالى الصندوق=====================

                string wared = "0";
                string sader = "0";

                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From BoxMove   ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {

                    wared = red["wared"].ToString();
                    sader = red["sader"].ToString();
                    if (wared == null || wared == "")
                    {
                        wared = "0";
                    }

                    if (sader == null || sader == "")
                    {
                        sader = "0";
                    }


                }
                red.Close();


                double nn = Convert.ToDouble(wared);
                double mm = Convert.ToDouble(sader);
                double rr = nn - mm;

                BoxMoney = Math.Round(double.Parse(rr.ToString()), 0).ToString();

                //============================================

                string month = dateTimePicker1.Value.ToString("MM");
                string year = dateTimePicker1.Value.ToString("yyyy");
                dateTimePicker2.Text = "01/" + month + "/" + year;



                sqlCommand1.CommandText = "select SUM(Profit) as Profit From Profit  where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {

                    Profits = red["Profit"].ToString();

                }
                red.Close();


                try
                {
                    Profits = Math.Round(double.Parse(textProfits.Text), 0).ToString();
                }
                catch
                { }

                //============================================
                MessageBox.Show("  تم التحديث   ", "    اجمالى المصاريف = '" + TotalMasrofat2 + "'  ");

                try
                {

                    sqlCommand1.CommandText = "insert into ProjectTotal (Month,Year,Date,StoreValue,CustomerValue,BoxValue,Profits,DailyExpenses,AdvExpenses,SeianaExpenses,RentExpenses,ElectricityExpenses,WaterExpenses,PhoneExpenses,InternetExpenses,CarExpenses,Salaries,WithdrawProfits,TotalExpenses,PurchasingExpenses,AddMoneyBox,DiscMoneyBox,Sales,DiscSales,Purchases,DiscPurchases,PurchaseReturns,SalesReturns,Taweredat,Tahselat)values ('" + textMonth.Text + "','" + textYear.Text + "','" + textDateMonth.Text + "','" + textValueMonth.Text + "','" + textClientValue.Text + "','" + textBoxMoney.Text + "','" + textProfits.Text + "','" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "')";
                    sqlCommand1.ExecuteNonQuery();


                    //'" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah.Text + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "',
                    MessageBox.Show("   الحمد لله لقد تم إضافةالبيانات    ", "  إضافه ");
                }
                catch
                {

                    sqlCommand1.CommandText = "update ProjectTotal set  StoreValue='" + textValueMonth.Text + "',CustomerValue='" + textClientValue.Text + "',BoxValue = '" + textBoxMoney.Text + "',Profits = '" + textProfits.Text + "',DailyExpenses='" + textNathria.Text + "',AdvExpenses='" + textAdvs.Text + "',SeianaExpenses='" + textSeiana.Text + "',RentExpenses='" + textEgar.Text + "',ElectricityExpenses='" + textKahraba.Text + "',WaterExpenses='" + textWater.Text + "',PhoneExpenses='" + textTell.Text + "',InternetExpenses='" + textNet.Text + "',CarExpenses='" + textCars.Text + "',Salaries='" + textMortabat.Text + "',WithdrawProfits='" + text_Arbah + "',TotalExpenses='" + textTotalMasrofat2.Text + "',PurchasingExpenses='" + textMoshtriat.Text + "',AddMoneyBox='" + textWaredMoney.Text + "',DiscMoneyBox='" + textSadreMoney.Text + "',Sales='" + textMabeaat.Text + "',DiscSales='" + textDiscMabeaat.Text + "',Purchases='" + textMoshtriaatTotal.Text + "',DiscPurchases='" + textDisSheraa.Text + "',SalesReturns='" + textHalekBeeea.Text + "',PurchaseReturns='" + textHaleksheraa.Text + "',Taweredat='" + textTawreed.Text + "',Tahselat='" + textTahseel.Text + "' where  Date ='" + textDateMonth.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();



                    MessageBox.Show("             تم تحديث البيانات الشهرية                 ", "  البيانات الشهرية ");
                }


                //============================================

                cn.Close();



            





        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetValueMonth();
        }

        private void butSum_Click(object sender, EventArgs e)
        {
            //// ISNULL(SUM(TotalBill),0) as TotalBill,ISNULL(SUM(Discount),0) as Discount,ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy,ISNULL(SUM(DiscountBuy),0) as DiscountBuy,ISNULL(SUM(TotalBillInvalid),0) as TotalBillInvalid,ISNULL(SUM(TotalBillBuyInvalid),0) as TotalBillBuyInvalid,ISNULL(SUM(Creditor),0) as Creditor,ISNULL(SUM(Adding),0) as Adding,ISNULL(SUM(Pay),0) as Pay,ISNULL(SUM(Paid),0) as Paid From BillingData 
            //DataTable dtB = new DataTable();
            //dtB.Clear();
            //SqlDataAdapter daB = new SqlDataAdapter("select * from ProjectTotal  ", cn);

            //daB.Fill(dtB);

            //this.dataGridView1.DataSource = dtB;
            //this.dataGridView2.DataSource = dtB;
            //this.dataGridView3.DataSource = dtB;

            DataTable dtB = new DataTable();
            dtB.Clear();
            SqlDataAdapter daB = new SqlDataAdapter("select * from ProjectTotal Where Month=12 ", cn);

            daB.Fill(dtB);

            this.dataGridView1.DataSource = dtB;
            this.dataGridView2.DataSource = dtB;
            this.dataGridView3.DataSource = dtB;

            GetSumValue();
        }

        private void butSUMM_Click(object sender, EventArgs e)
        {
            GetData();
            GetSumValue();
            ////------------------- ايجاد القيمة الاجمالية 
            //// -------------البضاعه + المديونيات + الصندوق + سحب الارباح - اجمالى المصاريف - مصروفات المشتريات
            ////for (int i = 0; i < dataGridView2.RowCount; ++i)
            ////{
            ////    double b = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            ////    double m = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            ////    double s = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
            ////    double sa = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);

            ////    double ms = Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
            ////    double mssh = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

            ////    double sss = (b + m + s + sa) - (ms + mssh);
            ////    dataGridView2.Rows[i].Cells[19].Value = sss.ToString();
            ////}

            //foreach (DataGridViewRow item in dataGridView2.Rows)
            //{
            //    int i = item.Index;
            //    double b = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            //    double m = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            //    double s = Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value);
            //    double sa = Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value);

            //    double ms = Convert.ToDouble(dataGridView2.Rows[i].Cells[7].Value);
            //    double mssh = Convert.ToDouble(dataGridView2.Rows[i].Cells[8].Value);

            //    double sss = (b + m + s + sa) - (ms + mssh);
            //    dataGridView2.Rows[i].Cells[19].Value = sss.ToString();


            //}
        }

        private void Statistical_MouseClick(object sender, MouseEventArgs e)
        {
            GetSumValue();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            GetSumValue();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            DataTable dtB = new DataTable();
            dtB.Clear();
            SqlDataAdapter daB = new SqlDataAdapter("select * from ProjectTotal Where Year='"+comboBox1.Text+"' ", cn);

            daB.Fill(dtB);

            this.dataGridView1.DataSource = dtB;
            this.dataGridView2.DataSource = dtB;
            this.dataGridView3.DataSource = dtB;

            GetSumValue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dtB = new DataTable();
            dtB.Clear();
            SqlDataAdapter daB = new SqlDataAdapter("select * from ProjectTotal Where Month='" + comboBox2.Text + "' ", cn);

            daB.Fill(dtB);

            this.dataGridView1.DataSource = dtB;
            this.dataGridView2.DataSource = dtB;
            this.dataGridView3.DataSource = dtB;

            GetSumValue();
        }
    }
}
