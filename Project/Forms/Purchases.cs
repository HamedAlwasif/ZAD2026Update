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


using System.Drawing.Printing;
using System.IO;
using ZAD_Sales.DAL;
using ZAD_Sales.ClassProject;

namespace ZAD_Sales.Forms
{
    // public partial class Purchases :  BaseForm
    public partial class Purchases : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        int i = 0;

        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        string SystemPriceShera = AppSetting.PriceSheraaAcount;
        string AllowUser = AppSetting.AllowUser;

        string PriceSheraOld = "0";
        string PriceSheraNew = "0";
        string PriceShera = "0";
        string PriceGomla = "0";
        string PriceMostahlek = "0";
        string TotalQuantetyOld = "0";

        string PriceSheraa = "0";
        string PriceGomlaa = "0";
string PriceGomlaAlgomla = "0";
string PriceNesfAlgomla = "0";

        string PriceKatey = "0";

        string SystemPro = "";
        string RseedBox = "";
        string MoveBoxID = "";
        string FristGardID = "";
        string NumBill = "";
        string ClintID = "";
        string TypeClint = "";
        string CreditorClint = "";



        string FactionCatogrey = "";
        string CategoryID = "";
        string NumCategery = "";
        string TotalAndRemaninRasedClient = "";
        string RasedBox = "";
        string Kataey = "";
        string GomKataey = "";
        string IDCategory = "";
        string Barcode = "";
        string ValueTotalMoney = "0";
        string TypeCategorey = "";
        string MoveToCatMove2 = "وارد";

        string Number = "";

        string imageLogoUrl;

        string CompanyAddress = "";
        string CompanyPhone = "";
        string CompanyName = "";
        string NoteToBill = "";
        string Demo = "";
        string CompanyDescription = "";

        string PrinterBill = "";
        string SizePaperBill = ""; // الافتراضى

        string PaperSizePrint = ""; // النهائى


        //-------------------------------
        DataTable dt1 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt18 = new DataTable();
        //---------------------------------
        private SqlDataReader red;
        private SqlDataReader rad;
        private SqlDataReader reed;
        private SqlDataReader read;
        private SqlDataReader reeeeed;
        private SqlDataReader rred;
        private SqlDataReader raaad;
        private SqlDataReader reaad;

        Purchases Purchases1;
        Barcode Barcode1;
        //---------------------------------
        ReportDataSource rs = new ReportDataSource();



        private void LoadPaperSizes() // يعرض اسماء التقارير من كلاس ReportEngine
        {

            combPaperSize.Items.Clear();

            combPaperSize.Items.AddRange(
            ReportEngine.Reports.Keys.ToArray());

            combPaperSize.SelectedIndex = 0;

        }

        private void LoadPrinters()
        {
            combPrinters.Items.Clear();

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                combPrinters.Items.Add(printer);
            }

            if (combPrinters.Items.Count > 0)
                combPrinters.SelectedIndex = 0;
        }


        ReportDataSource PrepareItems()
        {

            List<InvoiceItem> list =
            new List<InvoiceItem>();

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                decimal.TryParse(
                dataGridView2.Rows[i].Cells[5].Value?.ToString(),
                out decimal price);

                decimal.TryParse(
                dataGridView2.Rows[i].Cells[6].Value?.ToString(),
                out decimal discount);

                decimal.TryParse(
                dataGridView2.Rows[i].Cells[7].Value?.ToString(),
                out decimal total);

                list.Add(new InvoiceItem
                {

                    Num =
                dataGridView2.Rows[i].Cells[0].Value?.ToString(),

                    Storage =
                dataGridView2.Rows[i].Cells[1].Value?.ToString(),

                    Category =
                dataGridView2.Rows[i].Cells[2].Value?.ToString(),

                    Quantity =
                dataGridView2.Rows[i].Cells[3].Value?.ToString(),

                    Type =
                dataGridView2.Rows[i].Cells[4].Value?.ToString(),

                    Price = price,

                    Discount = discount,

                    Total = total

                });

            }

            return new ReportDataSource(
            "DataSet1",
            list);

        }
        
        LocalReport PrepareReport()
        {
            try
            {

                LocalReport report = new LocalReport();



                if (!ReportEngine.Reports.ContainsKey(combPaperSize.Text))
                {
                    MessageBox.Show("لم يتم تعريف التقرير");
                    return null;
                }


                // string reportFile =Reports[combPaperSize.Text];


                string reportFile = ReportEngine.GetReportFile(PaperSizePrint);

                string reportPath = Path.Combine(Application.StartupPath, "Reports", reportFile);

                // التأكد أن التقرير موجود
                if (!File.Exists(reportPath))
                {

                    MessageBox.Show( "Report Not Found : " + reportPath);

                    return null;

                }

                report.ReportPath =
                reportPath;

                report.DataSources.Clear();

                report.DataSources.Add(PrepareItems());

                report.EnableExternalImages = true;
                //   SetParameters(report);

                var invoiceData = CollectInvoiceData();

                ReportParameterBuilder.SetParameters(report, invoiceData);

                report.Refresh();

                return report;

            }
            catch (Exception ex)
            {

                MessageBox.Show(
                "Report Error : " +
                ex.Message);

                return null;

            }

        }
        void DirectPrint()
        {

            if (dataGridView2.Rows.Count == 0)
            {

                MessageBox.Show("لا توجد أصناف");

                return;

            }

            LocalReport report =
            PrepareReport();

            if (report == null)
                return;

            ReportPrinter.Print( report, PrinterBill, PaperSizePrint );

            System.Media.SystemSounds.Asterisk.Play();

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.F9)
            {

                DirectPrint();

                return true;

            }

            return base.ProcessDialogKey(keyData);

        }

        public Purchases()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;

            //-------- لتفعيل اختصار الزرار

            this.KeyPreview = true;

         //   this.KeyDown += Sales_KeyDown;
        }

        ZAD_Sales.ClassProject.InvoiceData CollectInvoiceData()
        {

            InvoiceData data =
            new InvoiceData();

            data.CompanyName =
            CompanyName;

            data.Name =
            txtClintName.Text;

            data.Date =
            dateTimePicker1.Value
            .ToString("yyyy/MM/dd");

            data.Total =
            txtTotalBill.Text;

            data.Sabek =
            txtRemaningOld.Text;

            data.Sabek1 =
            txtRemaningOld.Text;

            data.Mosadad =
            txtMosadad.Text;

            data.Remaning =
            txtRemainingNow.Text;

            data.Discount =
            txtDic.Text;

            data.State =
            textNoteBill.Text;

            data.NumBill =
            textBillingDataNumBill.Text;

            data.UserPrint =
 textUser.Text;

            data.TypeBill =
            comTypeBill.Text;

            data.MoveBill =
            textMoveBill.Text;

            data.NoteToBill =
            NoteToBill;

            data.CompanyDescription =
            CompanyDescription;

            data.CompanyAddress =
            CompanyAddress;

            data.CompanyPhone =
            CompanyPhone;

            data.ImageLogo =
            imageLogoUrl;

            data.MosadadActual =
            textMosadadActual.Text;

            data.ReturnValue =
            textReturn.Text;

            data.Demo =
            Demo;

            data.Note =
            textNoteBill.Text;

            return data;

        }

        private void GetNumUnit()
        {
            textBox57.Text = "1";
            if (ComTypeCategorey.Text == "كرتونه")
            {

                //--- حساب سعر البيع والشراء

                //-- البيع
                textBox57.Text = textUnit.Text;



            }
            else if (ComTypeCategorey.Text == "دسته")
            {
                //--- حساب سعر البيع والشراء

                //-- البيع

                textBox57.Text = "12";

               
            }
            else
            {
                //--- حساب سعر البيع والشراء

                //-- البيع

                textBox57.Text = "1";


            }

            try
            {
                double a = Convert.ToDouble(PriceSheraa);
                double b = Convert.ToDouble(PriceGomlaa);
                double c = Convert.ToDouble(PriceKatey);

                double bb = Convert.ToDouble(PriceGomlaAlgomla);
                double cc = Convert.ToDouble(PriceNesfAlgomla);


                double d = Convert.ToDouble(textBox57.Text);

                double r = a * d;
                textPriceSheraa.Text = r.ToString();
                textPriceSheraa.Text = Math.Round(double.Parse(textPriceSheraa.Text), 2).ToString();
                double r1 = b * d;
                textPriceGomla.Text = r1.ToString();
                textPriceGomla.Text = Math.Round(double.Parse(textPriceGomla.Text), 2).ToString();
                double r2 = c * d;
                textPriceKatey.Text = r2.ToString();
                textPriceKatey.Text = Math.Round(double.Parse(textPriceKatey.Text), 2).ToString();


                double r3 = bb * d;
                textPriceGomlaAlgomla.Text = r3.ToString();
                textPriceGomlaAlgomla.Text = Math.Round(double.Parse(textPriceGomlaAlgomla.Text), 2).ToString();

                double r4 = cc * d;
                textPriceNesfGomla.Text = r4.ToString();
                textPriceNesfGomla.Text = Math.Round(double.Parse(textPriceNesfGomla.Text), 2).ToString();

            }
            catch
            { }
        }
        private void text_KeyPress(object sender, KeyPressEventArgs e) // - غلق كتابة الحروف وجعل الكتابة ارقام فقط
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
        public void CleanData()
        {
            textQuantetyShera.Text = "";


        }
        public void ClosePanel()
        {
            panel8.Visible = false;
            panel10.Visible = false;
            panel6.Visible = false;
            panel2.Visible = false;
            panelLastPrice.Visible = false;
            PanalClintsDay.Visible = false;
            panelProfits.Visible = false;
            panelprofitPercent.Visible = false;
        }
        public class Class_GetAllClintes
        {
            //Name,Company,TelHome,TelMobil,Address,PreviousBalance,ID
            public string ID { get; set; }
            public string Name { get; set; }
            public string Company { get; set; }
            public string TelHome { get; set; }
            public string TelMobil { get; set; }
            public string Address { get; set; }
            public string PreviousBalance { get; set; }
            public string StateRaseed { get; set; }
        }
        public class Class_CategoreysBillSheraa
        {

            public string Num { get; set; }
            public string Storage { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string Type { get; set; }
            public string Price { get; set; }
            public string Discount { get; set; }
            public string Total { get; set; }


        }
        public class Class_BillDaySheraa
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string TotalBillBuy { get; set; }
            public string Pay { get; set; }
            public string Remaining { get; set; }


        }

        public class Class_BillsClint
        {

            public string NumBill { get; set; }
            public string Date { get; set; }
            public string TotalBillBuy { get; set; }



        }
        public void SystemProgram()
        {


            // البحث نظام العمل جملة او قطاعى
            //sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
            //reed = sqlCommand1.ExecuteReader();
            //while (reed.Read())
            //{

            //    Kataey = reed["Kataey"].ToString();
            //    GomKataey = reed["GomlaKataey"].ToString();

            //}

            //reed.Close();

            GomKataey = AppSetting.textGomlaKataey;
            Kataey = AppSetting.textKataey;

            if (Kataey == "1") // قطاعى
            {
                label21.Visible = false;
                label37.Visible = false;
                textQuantetyK.Visible = false;
                textQuntetyTagzea.Visible = false;

                textBox57.Visible = false;
                textBox58.Visible = false;
                label36.Visible = false;
                label33.Visible = false;
                label32.Visible = false;

                //----------------- ايجاد الفئات --------------------

                String type = "K";

                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Faction from CategoryFaction where Type ='" + type + "'", cn);
                Da1.Fill(Dt1);
                ComTypeCategorey.DataSource = Dt1;
                ComTypeCategorey.DisplayMember = "Faction";

                //string[] com = { "قطعه", "كيلو", "طقم", "لفة", "علبة", "ربطه", "دستة", "كيس", "الف", "متر" };
                //ComTypeCategorey.DataSource = com;
            }
            else // جملة
            {
                //----------------- ايجاد الفئات --------------------

                String type = "G";

                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Faction from CategoryFaction where Type ='" + type + "'", cn);
                Da1.Fill(Dt1);
                ComTypeCategorey.DataSource = Dt1;
                ComTypeCategorey.DisplayMember = "Faction";

                //string[] com = { "كرتونه", "دسته", "قطعه", "كيلو", "طقم", "لفة", "علبة", "ربطه", "كيس" };
                //ComTypeCategorey.DataSource = com;
            }

        }
        public void GetRasedBox()
        {
            //---------  رصيد الخزنة
            try
            {
                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From BoxMove ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    RseedBox = "0";

                    double w = Convert.ToDouble(reed["wared"].ToString());
                    double s = Convert.ToDouble(reed["sader"].ToString());
                    double rr = w - s;
                    RseedBox = Math.Round(rr, 0).ToString();

                }
                reed.Close();

            }
            catch
            {

            }


        }

        public void GetMoveBoxID()
        {




            sqlCommand1.CommandText = "select * From BoxMove  Where ID =(select max(ID) from BoxMove) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["ID"].ToString());
                double aa = s + 1;
                MoveBoxID = aa.ToString();

            }
            red.Close();

            if (MoveBoxID == "")
            {
                MoveBoxID = "1";
            }
            else
            { }




        }
        public void GetNumBill()
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(NumBill), 0) FROM BillingData", cn))
            {
                cn.Open();

                object result = cmd.ExecuteScalar();

                double lastNumBill = Convert.ToDouble(result);
                double nextNumBill = lastNumBill + 1;

                textBillingDataNumBill.Text = nextNumBill.ToString();
            }

            //sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
            //red = sqlCommand1.ExecuteReader();
            //while (red.Read())
            //{
            //    double s = Convert.ToDouble(red["NumBill"].ToString());
            //    double aa = s + 1;
            //    textBillingDataNumBill.Text = aa.ToString();


            //}
            //red.Close();

            if (textBillingDataNumBill.Text == "")
            {
                textBillingDataNumBill.Text = "1";
            }
            else
            { }

            NumBill = textBillingDataNumBill.Text;


        }
        public void GetNumBillSheraa()
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(NumBill), 0) FROM BillingData1", cn))
            {
                cn.Open();

                object result = cmd.ExecuteScalar();

                double lastNumBill = Convert.ToDouble(result);
                double nextNumBill = lastNumBill + 1;

                textBillingData1NumBill.Text = nextNumBill.ToString();
            }


            //sqlCommand1.CommandText = "select NumBill From BillingData1  Where NumBill =(select max(NumBill) from BillingData1) ";
            //red = sqlCommand1.ExecuteReader();
            //while (red.Read())
            //{
            //    double s = Convert.ToDouble(red["NumBill"].ToString());
            //    double aa = s + 1;
            //    textBillingData1NumBill.Text = aa.ToString();


            //}
            //red.Close();

            if (textBillingData1NumBill.Text == "")
            {
                textBillingData1NumBill.Text = "1";
            }
            else
            { }




        }
        public class Class_GetAllCategry
        {

            public string Barcode { get; set; }
            public string Category { get; set; }
            public string Storage { get; set; }
            public string Total { get; set; }
            public string PriceMostahlek { get; set; }


        }
        private void GetAllCategry()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Category ", cn);
            da11.Fill(dt11);
            this.dataGridSearchCategory.DataSource = dt11;

        }
        private void GetAllCategryClients()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select Category,sum(Quantity) as Total from Billing Where ClinentID = '" + textClintID.Text + "'  GROUP BY Category ORDER BY Category ASC", cn); // ASC تصاعدى  --- DESC تنازلى
            da11.Fill(dt11);
            this.dataGridViewClientsCategory.DataSource = dt11;

        }
        private void GetAllClintes()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Clients ", cn);
            da11.Fill(dt11);
            this.dataGridSearchClint.DataSource = dt11;

        }
        private void saveEvents(string Event)
        {

            //=========================== تسجيل الحركات  ========================== 
            try
            {

                //string Event = "تم فتح شاشة  " + TransferData.FormName;


                sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                sqlCommand1.ExecuteNonQuery();

                //MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");


                //---------------


            }
            catch
            {
                // MessageBox.Show("    فشلللللللللللللللللللللللللللللللل   ", "فشل ");
            }

            //========================== ========================== ========================== 
        }

        //public string GetRemaningTreasury(SqlConnection cn, int id)
        //{
        //    string result = string.Empty;

        //    // لو الاتصال مقفول نفتحه
        //    if (cn.State == ConnectionState.Closed)
        //        cn.Open();

        //    string query = "SELECT RemaningTreasury FROM TreasuryRemaning WHERE ID = @ID";

        //    using (SqlCommand cmd = new SqlCommand(query, cn))
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@ID", id);

        //        object value = cmd.ExecuteScalar();

        //        if (value != null && value != DBNull.Value)
        //        {
        //            result = value.ToString();
        //        }
        //    }

        //    return result;
        //}


        // دالة مساعدة للتنسيق
        private string FormatNumber(object value)
        {
            if (value == DBNull.Value) return string.Empty;

            decimal number = Convert.ToDecimal(value);

            // لو الرقم صحيح (مفيش كسور) رجّعه صحيح
            if (number == Math.Truncate(number))
                return ((int)number).ToString();
            else
                return number.ToString();
        }
        private void GetProfitRate()
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                string query = @"SELECT TOP 1 
                        PriceKataeeProfitRate, 
                        PriceAlgomlaProfitRate, 
                        PriceNesfAlgomlaProfitRate, 
                        PriceGomlaAlgomlaProfitRate 
                     FROM SystemProgram";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textPriceKataeeProfitRate.Text = FormatNumber(reader["PriceKataeeProfitRate"]);
                    textPriceAlgomlaProfitRate.Text = FormatNumber(reader["PriceAlgomlaProfitRate"]);
                    textPriceNesfAlgomlaProfitRate.Text = FormatNumber(reader["PriceNesfAlgomlaProfitRate"]);
                    textPriceGomlaAlgomlaProfitRate.Text = FormatNumber(reader["PriceGomlaAlgomlaProfitRate"]);
                }

                reader.Close();
            }
        }

        void InitDefaultSelections()
        {

            // Paper size
            if (combPaperSize.Items.Contains(PaperSizePrint))
            {

                combPaperSize.Text =
                PaperSizePrint;

            }
            else
            {

                combPaperSize.SelectedIndex = 0;

                PaperSizePrint =
                combPaperSize.Text;

            }

            // Printer
            if (combPrinters.Items.Contains(
            PrinterBill))
            {

                combPrinters.Text =
                PrinterBill;

            }
            else
            {

                combPrinters.SelectedIndex = 0;

                PrinterBill =
                combPrinters.Text;

            }

        }

        private void Purchases_Load(object sender, EventArgs e)
        {
            imageLogoUrl = AppSetting.Comp_Logo;
            CompanyName = AppSetting.textCompany_Name;
            CompanyAddress = AppSetting.textCompany_Address;
            CompanyDescription = AppSetting.textCompany_Description;
            CompanyPhone = AppSetting.textCompany_Phone;
            NoteToBill = AppSetting.NoteToBill;
            Demo = AppSetting.DemoOnBill;

            //---------- ايجاد الطابعه الافتراضية وحجم الورقة -----

            SizePaperBill = AppSetting.SizePaperBill;

            PaperSizePrint = AppSetting.SizePaperBill;

            PrinterBill = AppSetting.PrinterBill;


            LoadPaperSizes();

            LoadPrinters();

            InitDefaultSelections();

            GetProfitRate();

            //------------------  اظهار الاسعار جملة الجملة ونصف الجملة-----------------

            string PricesAllShow = AppSetting.PricesAll; // --- اظهار الاسعار جملة الجملة ونصف الجملة

            if (PricesAllShow == "1")
            {
                label35.Visible = true;
                textPriceGomlaAlgomla.Visible = true;
                label34.Visible = true;
                textPriceNesfGomla.Visible = true;
            }
            else
            {
                label35.Visible = false;
                textPriceGomlaAlgomla.Visible = false;
                label34.Visible = false;
                textPriceNesfGomla.Visible = false;
            }



            if (AllowUser == "1") // الصلاحيات الخاصة الداخلية
            {
                butProfit.Visible = true; // اظهار زر ارباح الفاتورة
                //---------------------------
             
                //---------------------------
                button12.Visible = true; // اظهار زر تعديل التاريخ

                if (FormName == "مردودات مبيعات")
                {
                    butProfit.Visible = false;// اخفاء زر ارباح الفاتورة

              

                    button12.Visible = false; // اخفاء زر تعديل التاريخ
                }
            }

            else
            {
                butProfit.Visible = false;// اخفاء زر ارباح الفاتورة

               

                button12.Visible = false; // اخفاء زر تعديل التاريخ

            }


            //==========================  تسجيل الحركات  ========================== 

            saveEvents("تم فتح شاشة  " + TransferData.FormName);

            //========================== ========================== =================


            //textBox3.Text = PriceSheraOld;
            //textBox4.Text = TotalQuantetyOld;

            GetAllCategry();
            GetAllClintes();
            SystemProgram();
            GetMoveBoxID();
            //GetNumBill();
            //GetNumBillSheraa();
            //GetRasedBox();
            textMoveBill.Text = FormName;
            labelMoveBill.Text = FormName;
            textUser.Text = UserName;

            //--------------------------------------------
            //----------------- ايجاد العملاء --------------------

            SqlDataAdapter Da1;
            DataTable Dt1 = new DataTable();
            Da1 = new SqlDataAdapter("select Name from Clients", cn);
            Da1.Fill(Dt1);
            comClient.DataSource = Dt1;
            comClient.DisplayMember = "Name";


            //----------------- ايجاد المخزن --------------------

            SqlDataAdapter Da11;
            DataTable Dt11 = new DataTable();
            Da11 = new SqlDataAdapter("select Storage from Storage", cn);
            Da11.Fill(Dt11);
            combStorage.DataSource = Dt11;
            combStorage.DisplayMember = "Storage";


            //-----------------   ايجاد الاصناف --------------------

            SqlDataAdapter Da21;
            DataTable Dt21 = new DataTable();
            Da21 = new SqlDataAdapter("select Category from Category", cn);
            Da21.Fill(Dt21);
            combCategorys.DataSource = Dt21;
            combCategorys.DisplayMember = "Category";

            //-----------------------   إيجاد رصيد المخزن --------------------

            //sqlCommand1.CommandText = "select * From TreasuryRemaning  Where ID = '" + 1 + "' ";
            //rred = sqlCommand1.ExecuteReader();
            //while (rred.Read())
            //{

            //    RasedBox = rred["RemaningTreasury"].ToString();
            //}
            //rred.Close();


            // إيجاد حركة المشتريات


            if (textMoveBill.Text == "مردودات مبيعات")
            {
                textPriceGomla.Visible = false;
                textPriceKatey.Visible = false;
                label43.Visible = false;
                label44.Visible = false;

                label2.Text = "السعـــــر";

                radio_GetAllCategry.Visible = true;
                radio_GetAllCategry_Quntety.Visible = true;
                button3.Visible = false;

                //butLastPriceBilling.Visible = true;
                //butLastPriceBilling1.Visible = false;
            }
            //else if(textMoveBill.Text == "فاتورة مشتريات يدوية")
            //{
            //    butAddProduct.Visible = false;
            //    butAdd.Visible = true;
            //}
            else if (textMoveBill.Text == "فاتورة مشتريات")
            {
                radio_GetAllCategry.Visible = false;
                radio_GetAllCategry_Quntety.Visible = false;
                button3.Visible = true;
                //butLastPriceBilling.Visible = false;
                //butLastPriceBilling1.Visible = true;
            }
            //----------------- ايجاد المجموعات --------------------
            //try
            //{
            //    SqlDataAdapter Da2;
            //    DataTable Dt2 = new DataTable();
            //    Da2 = new SqlDataAdapter("select GroupName from Groups", cn);
            //    Da2.Fill(Dt2);
            //    comClintGroup.DataSource = Dt2;
            //    comClintGroup.DisplayMember = "GroupName";

            //}
            //catch
            //{

            //}

            //------------- مفتوحة من كشف الحساب
            string NumBillFromAcount = TransferData.NumBillFromAcount;
            if (NumBillFromAcount != "")
            {
                textBillingDataNumBill.Text = NumBillFromAcount;
                GetBill();
            }
            else
            { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();

            TransferData.FormName = "فاتورة مشتريات";

            if (Purchases1 == null || Purchases1.IsDisposed == true)
            {
                Purchases1 = new Purchases();
            }
            Purchases1.MdiParent = Main.ActiveForm;
            Purchases1.Show();
        }

        private void Searching()
        {

            try
            {

                sqlCommand1.CommandText = "select SUM(TotalBill) as TotalBill,SUM(Discount) as Discount,SUM(TotalBillBuy) as TotalBillBuy,SUM(DiscountBuy) as DiscountBuy,SUM(TotalBillInvalid) as TotalBillInvalid,SUM(TotalBillBuyInvalid) as TotalBillBuyInvalid,SUM(Creditor) as Creditor,SUM(Adding) as Adding,SUM(Pay) as Pay,SUM(Paid) as Paid From BillingData Where Name='" + comClient.Text + "'  ";
                reeeeed = sqlCommand1.ExecuteReader();
                while (reeeeed.Read())
                {
                    string TotalBill = reeeeed["TotalBill"].ToString();
                    string Discount = reeeeed["Discount"].ToString();
                    string TotalBillBuy = reeeeed["TotalBillBuy"].ToString();
                    string DiscountBuy = reeeeed["DiscountBuy"].ToString();
                    string TotalBillInvalid = reeeeed["TotalBillInvalid"].ToString();
                    string TotalBillBuyInvalid = reeeeed["TotalBillBuyInvalid"].ToString();
                    string Creditor = reeeeed["Creditor"].ToString();
                    string Adding = reeeeed["Adding"].ToString();
                    string Pay = reeeeed["Pay"].ToString();
                    string Paid = reeeeed["Paid"].ToString();

                    //-------------------------------------------
                    txtRemaningOld.Text = "0";
                    try
                    {
                        double t1 = Convert.ToDouble(TotalBill);
                        double t2 = Convert.ToDouble(DiscountBuy);
                        double t3 = Convert.ToDouble(TotalBillBuyInvalid);
                        double t4 = Convert.ToDouble(Adding);
                        double t5 = Convert.ToDouble(Pay);
                        double t6 = Convert.ToDouble(Discount);
                        double t7 = Convert.ToDouble(TotalBillBuy);
                        double t8 = Convert.ToDouble(TotalBillInvalid);
                        double t9 = Convert.ToDouble(Paid);
                        double total = (t1 + t2 + t3 + t4 + t5) - (t6 + t7 + t8 + t9);
                        txtRemaningOld.Text = total.ToString();
                        txtRemaningOld.Text = Math.Round(double.Parse(txtRemaningOld.Text), 2).ToString();

                    }
                    catch
                    {

                    }
                }
                reeeeed.Close();
            }
            catch { }





        }

        private void comClient_TextChanged(object sender, EventArgs e)
        {
            // textBox49.Text = "0";
            // textBox50.Text = "0";


            txtTotalBill.Text = "0";
            TxtNumCategorey.Text = "0";
            txtRemaningOld.Text = "0";
            //  TotalAndRemaninRasedClient = "0";
            txtDic.Text = "0";
            // textBox13.Text = "0";
            // txtRemaningOld1.Text = "0";
            txtMosadad.Text = "0";
            txtRemainingNow.Text = "0";
            // textBox29.Text = "";
            textClintID.Text = "";
            txtClintName.Text = "";
            textBox43.Text = "";
            // إيجاد رقم الفاتورة

            //int ii = int.Parse(comboBox6.Text);
            //int jj = ii + 1;
            //textMoveBoxNumBill.Text = jj.ToString();

            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comClient.Text + "' ";
                rad = sqlCommand1.ExecuteReader();
                while (rad.Read())
                {
                    textClintID.Text = rad["ID"].ToString();
                    //  txtRemaningOld1.Text = rad["Creditor"].ToString();
                    textBox43.Text = rad["Company"].ToString();
                    txtClintName.Text = rad["Name"].ToString();


                }
                rad.Close();
            }
            catch
            {

            }

            //-------------------
            Searching();
        }

        private void combCategorys_TextChanged(object sender, EventArgs e)
        {


            try
            {

                //- إيجاد الكميه الاول
                textQuantetyK.Text = "";
                textUnit.Text = "";
                comboBox7.Text = "";
                textTotalQuantety.Text = "";
                CategoryID = "";
                PriceSheraOld = "0";

                textBoxtextBarcode.Text = "";
                textIDCategory.Text = "";
                textPriceSheraa.Text = "0";
                textPriceGomla.Text = "0";
                textPriceGomlaAlgomla.Text = "0";
                textPriceNesfGomla.Text = "0";
                textPriceKatey.Text = "0";

                PriceSheraa = "0";
                PriceGomlaa = "0";
                PriceKatey = "0";

                PriceGomlaAlgomla = "0";
                PriceNesfAlgomla = "0";


                sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    CategoryID = reed["ID"].ToString();
                    textIDCategory.Text = reed["ID"].ToString();
                    textBoxtextBarcode.Text = reed["Barcode"].ToString();
                    textQuantetyK.Text = reed["Quantity"].ToString();
                    textQuntetyTagzea.Text = reed["QuantityT"].ToString();
                    PriceSheraOld = reed["Price"].ToString();
                    textUnit.Text = reed["Unity"].ToString();
                    comboBox7.Text = reed["Faction"].ToString();
                    textTotalQuantety.Text = reed["Total"].ToString();
                    TotalQuantetyOld = reed["Total"].ToString();

                    PriceSheraa = reed["Price"].ToString();
                    PriceGomlaa = reed["PriceGomla"].ToString();
                    PriceGomlaAlgomla = reed["PriceGomlaAlgomla"].ToString();
                    PriceNesfAlgomla = reed["PriceNesfAlgomla"].ToString();
                    PriceKatey = reed["PriceMostahlek"].ToString();

                    //textPriceSheraa.Text = reed["Price"].ToString();
                    //textPriceGomla.Text = reed["PriceGomla"].ToString();
                    //textPriceKatey.Text = reed["PriceMostahlek"].ToString();



                }

                reed.Close();

                //------- حساب السعر بالكرتونة ام بالدستى ام بالقطعه
                GetNumUnit();

                //double a = Convert.ToDouble(PriceSheraa);
                //double b = Convert.ToDouble(PriceGomla);
                //double c = Convert.ToDouble(PriceKatey);
                //double d = Convert.ToDouble(textBox57.Text);

                //double r = a * d;
                //textPriceSheraa.Text = r.ToString();
                //double r1 = b * d;
                //textPriceGomla.Text = r1.ToString();
                //double r2 = c * d;
                //textPriceKatey.Text = r2.ToString();


                // textPriceSheraa.Text = reed["PriceShraa"].ToString();
                // textPriceGomla.Text = reed["PriceGomla"].ToString();
                //textPriceKatey.Text = reed["PriceMostahlek"].ToString();


                //اظهار الوحدة والفئة اذا كان صنف جديد
                if (textUnit.Text == "")
                {
                    textUnit.Visible = true;
                    label22.Visible = true;
                    comboBox7.Visible = true;
                    label23.Visible = true;

                    if (Kataey == "1")
                    {
                        textUnit.Text = "1";
                        comboBox7.Text = "ق";

                        textUnit.Visible = false;
                        comboBox7.Visible = false;
                        label22.Visible = false;
                        label23.Visible = false;
                    }
                    else
                    { }
                }
                else
                {
                    textUnit.Visible = false;
                    label22.Visible = false;
                    comboBox7.Visible = false;
                    label23.Visible = false;
                }


                textQuantetyShera.Text = "";

                txtTotalProduct.Text = "";

                //textBox36.Text = "";
                //textBox39.Text = "";

                textBox60.Text = "0";
                textBox59.Text = "0";

                //textBox45.Text = "0";
                //textBox46.Text = "0";
                //textBox47.Text = "0";

                // -------------                


                groupBox5.Text = combCategorys.Text;

                //try
                //{
                //    sqlCommand1.CommandText = "select * from Billing1 where Category Like'" + combCategorys.Text + "' AND ClientName Like'" + textClientName.Text + "'   ";
                //    reed = sqlCommand1.ExecuteReader();
                //    while (reed.Read())
                //    {
                //        textPriceSheraa.Text = reed["Price"].ToString();

                //    }
                //    reed.Close();

                //}
                //catch
                //{

                //}

                //try
                //{
                //    sqlCommand1.CommandText = "select * from CategoryPrice where Category Like'" + combCategorys.Text + "'  ";
                //    reed = sqlCommand1.ExecuteReader();
                //    while (reed.Read())
                //    {
                //        textPriceSheraa.Text = reed["PriceShraa"].ToString();
                //        textPriceGomla.Text = reed["PriceGomla"].ToString();
                //        textPriceKatey.Text = reed["PriceMostahlek"].ToString();
                //        //textBox35.Text = reed["Faction"].ToString();
                //        //textBox36.Text = reed["PriceGomla"].ToString();
                //        //textBox39.Text = reed["PriceMostahlek"].ToString();

                //    }
                //    reed.Close();

                //}
                //catch
                //{

                //}

                //textBox37.Text = ComTypeCategorey.Text;

                //---------------- ايجاد اخر سعر ---------
                if (textMoveBill.Text == "مردودات مبيعات") //----------- فاتورة مردودات
                {


                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + txtClintName.Text + "'", cn);
                        da.Fill(dt);
                        this.dataGridLastPrice.DataSource = dt;
                        this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                        this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                        this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                        this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                        this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                        this.dataGridLastPrice.Columns[0].Width = 60;
                        this.dataGridLastPrice.Columns[1].Width = 80;
                        this.dataGridLastPrice.Columns[2].Width = 50;
                        this.dataGridLastPrice.Columns[3].Width = 50;
                        this.dataGridLastPrice.Columns[4].Width = 50;


                        //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                        //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";



                        //-------------- لترتيب الجدول حسب عمود
                        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                        int num = dataGridLastPrice.Rows.Count - 2;

                        //  textBox3.Text = num.ToString();

                        textPriceSheraa.Text = "";

                        textPriceSheraa.Text = dataGridLastPrice.Rows[num].Cells[4].Value.ToString();

                    }
                    catch
                    {

                    }
                }
                else // -------------- فاتورة مشتريات
                {


                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing1 where Category ='" + combCategorys.Text + "' AND ClientName ='" + txtClintName.Text + "'", cn);
                        da.Fill(dt);
                        this.dataGridLastPrice.DataSource = dt;
                        this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                        this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                        this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                        this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                        this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                        this.dataGridLastPrice.Columns[0].Width = 60;
                        this.dataGridLastPrice.Columns[1].Width = 80;
                        this.dataGridLastPrice.Columns[2].Width = 50;
                        this.dataGridLastPrice.Columns[3].Width = 50;
                        this.dataGridLastPrice.Columns[4].Width = 50;


                        //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                        //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";




                        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 260;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 60;

           

            panel6.Location = new Point(x, y);



            panel6.Location = new Point(673, 94); 
            this.panel6.Size = new System.Drawing.Size(306, 395);

            if (panel6.Visible == true)
            {

                panel6.Visible = false;

            }
            else
            {
                panel6.Visible = true;

                //------------------------------------
                DataTable dt33 = new DataTable();
                dt33.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from BillingData where Name = '" + comClient.Text + "' and Move Like'" + FormName + "' ", cn);
                da11.Fill(dt33);
                this.dataGridView1.DataSource = dt33;


                //-----------------
                textBox38.Text = comClient.Text;

            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            // GetPriceSheraFinal();

            //-------------------------------------------

            if (textBillingDataNumBill.Text == "")
            {
                GetNumBill();
                GetNumBillSheraa();
            }
            else
            { }

            //------------------------------------------
            TypeCategorey = ComTypeCategorey.Text;

            //-----------------------------------------

            if (txtClintName.Text == "")
            {
                MessageBox.Show("       من فضلك إختار اسم العميل من قائمة العملاء           ", "  خطأ  ");
                comClient.Focus();
            }
            else
            {
                if (ComTypeCategorey.Text == "")
                {
                    MessageBox.Show("       من فضلك إختار الفئة           ", "  خطأ  ");
                    ComTypeCategorey.Focus();
                }
                else
                {
                    if (textBillingData1NumBill.Text == "")
                    {
                        MessageBox.Show("       من فضلك أدخل رقم الفاتورة           ", "  خطأ  ");
                        textBillingData1NumBill.Focus();
                    }
                    else
                    {
                        if (combCategorys.Text == "")
                        {
                            MessageBox.Show("       من فضلك أكتب الصنف الجديد            ", "  خطأ  ");
                            textPriceSheraa.Focus();
                        }
                        else
                        {
                            if (textQuantetyShera.Text == "")
                            {
                                MessageBox.Show("      من فضلك أدخل الكمية            ", "  خطأ  ");
                                textQuantetyShera.Focus();
                            }
                            else
                            {
                                if (textClintID.Text == "")
                                {
                                    MessageBox.Show("       من فضلك إختار إسم العميل وإضغط إنتر           ", "  خطأ  ");

                                    comClient.Focus();
                                }
                                else
                                {
                                    if (textQuantetyShera.Text == "")
                                    {
                                        MessageBox.Show("       من فضلك أدخل الكمية المطلوبه           ", "  خطأ  ");
                                        textQuantetyShera.Focus();
                                    }
                                    else
                                    {
                                        if (textPriceSheraa.Text == "")
                                        {
                                            MessageBox.Show("       من فضلك أدخل سعر الوحدة           ", "  خطأ  ");

                                            textPriceSheraa.Focus();
                                        }
                                        else
                                        {
                                            if (textUnit.Text == "")
                                            {
                                                MessageBox.Show("         من فضلك أدخل وحدة الصنف        ", "  خطأ  ");
                                                textUnit.Focus();
                                            }
                                            else
                                            {
                                                if (comboBox7.Text == "")
                                                {
                                                    MessageBox.Show("         من فضلك أدخل فئة الصنف        ", "  خطأ  ");
                                                    comboBox7.Focus();
                                                }
                                                else
                                                {

                                                    if (textQuantetyK.Text == "") // -------- صنف  جديد 
                                                    {
                                                        AddProductNew();
                                                        textIDCategory.Text = IDCategory;

                                                    }
                                                    else // --------- الصنف موجود من قبل
                                                    {
                                                        AddProductOld();
                                                        IDCategory = textIDCategory.Text;
                                                    }

                                                    AddProduct();
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void CountRemaining()
        {
            double a = Convert.ToDouble(txtDic.Text);
            double b = Convert.ToDouble(txtMosadad.Text);
            //double c = Convert.ToDouble(txtAdd.Text);
            double d = Convert.ToDouble(txtRemaningOld.Text);
            double f = Convert.ToDouble(txtTotalBill.Text);


            double r = (d - f) + (a + b);
            txtRemainingNow.Text = r.ToString();


            // تحديث بيانات الفاتورة

            sqlCommand1.CommandText = "update BillingData1 set  Move='" + FormName + "',  TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "',PreviousBalance ='" + txtRemaningOld.Text + "' ,Creditor ='" + txtRemaningOld.Text + "', Total ='" + TotalAndRemaninRasedClient + "',Discount ='" + txtDic.Text + "',ReasonDiscount ='" + 0 + "',Adding ='" + 0 + "',ReasonAdd ='" + 0 + "' ,Paid ='" + txtMosadad.Text + "',Remaining ='" + txtRemainingNow.Text + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
            sqlCommand1.ExecuteNonQuery();

            if (FormName == "فاتورة مشتريات")
            {

                sqlCommand1.CommandText = "update BillingData set    TotalBillBuy='" + txtTotalBill.Text + "',Pay='" + txtMosadad.Text + "',DiscountBuy='" + txtDic.Text + "',ReasonDiscount='" + 0 + "',Adding='" + 0 + "',ReasonAdd='" + 0 + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "',  State ='" + label31.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

            }
            else if (FormName == "مردودات مبيعات")
            {

                sqlCommand1.CommandText = "update BillingData set    TotalBillInvalid='" + txtTotalBill.Text + "',Pay='" + txtMosadad.Text + "',DiscountBuy='" + txtDic.Text + "',ReasonDiscount='" + 0 + "',Adding='" + 0 + "',ReasonAdd='" + 0 + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "',  State ='" + label31.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();


            }
            else if (FormName == "جرد أول المدة")
            {

                sqlCommand1.CommandText = "update BillingData set    TotalBillBuy='" + txtTotalBill.Text + "',Pay='" + txtMosadad.Text + "',DiscountBuy='" + txtDic.Text + "',ReasonDiscount='" + 0 + "',Adding='" + 0 + "',ReasonAdd='" + 0 + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "',  State ='" + label31.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                try
                {
                    sqlCommand1.CommandText = "select ID from FristGard where NumBill ='" + textBillingDataNumBill.Text + "'";
                    raaad = sqlCommand1.ExecuteReader();
                    while (raaad.Read())
                    {
                        FristGardID = raaad["ID"].ToString();


                    }
                    raaad.Close();
                }
                catch
                {

                }
                try
                {
                    sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,NumBill,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + FristGardID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comClient.Text + "','" + textBillingDataNumBill.Text + "','" + txtTotalBill.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();



                }
                catch
                {
                    sqlCommand1.CommandText = "update FristGard set GardFrist ='" + txtTotalBill.Text + "'where ID ='" + FristGardID + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

            }

            // تعديل الرصيد فى جدول العملاء
            try
            {
                sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show(" pleas correct the data");
            }

            //    //----------  إضافة حركة الصندوق

            try
            {
                sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Sader = '" + txtMosadad.Text + "', Total = '" + 0 + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Name = '" + comClient.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
            }

        }
        private void butClientDay_Click(object sender, EventArgs e)
        {

            if (PanalClintsDay.Visible == true)
            {
                PanalClintsDay.Visible = false;
                //panel14.Visible = false;
                //panel10.Visible = false;
                //panel3.Visible = false;

            }
            else
            {
                PanalClintsDay.Visible = true;
                //panel14.Visible = false;
                //panel10.Visible = false;
                //panel3.Visible = false;



                //------------------------------------
                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  and Move like '" + FormName + "'  ", cn);
                da21.Fill(dt12);
                this.dataGridClientsDay.DataSource = dt12;

                try
                {
                    int sum = 0;
                    for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                    {
                        sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[3].Value);


                    }
                    textTotalBill.Text = sum.ToString();
                }
                catch
                { }

                try
                {
                    int sum = 0;
                    for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                    {
                        sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[4].Value);


                    }
                    textTotalTawred.Text = sum.ToString();
                }
                catch
                { }

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridClientsDay.Rows)
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
        }
        private void GET_TotalProduct()
        {
            try
            {
                //-------------- حساب اجمالى الصنف ----------------
                double nn = Convert.ToDouble(textQuantetyShera.Text);
                double dd = Convert.ToDouble(textPriceSheraa.Text);
                double mm = Convert.ToDouble(textBox59.Text);
                double rr = (nn * dd) - (nn * mm);
                txtTotalProduct.Text = rr.ToString();

                txtTotalProduct.Text = Math.Round(double.Parse(txtTotalProduct.Text), 2).ToString();

            }

            catch (FormatException)
            {
                txtTotalProduct.Text = "";
                //  MessageBox.Show("        يوجد خطأ فى البيانات   ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

            GET_TotalProduct();


        }

        private void textPriceSheraa_TextChanged(object sender, EventArgs e)
        {
            if (ComTypeCategorey.Text == "كرتونه")
            {

                try
                {
                    double nss = Convert.ToDouble(textPriceSheraa.Text);
                    double dss = Convert.ToDouble(textUnit.Text);
                    double rrss = nss / dss;
                    PriceShera = rrss.ToString();

                    PriceShera = Math.Round(double.Parse(PriceShera), 2).ToString();
                }
                catch
                { }

            }
            else
            {
                PriceShera = textPriceSheraa.Text;
            }


            //------------ حساب الاجمالى -------------

            GET_TotalProduct();


          //  CalculateSellingPrice();

        }

        private void textPriceGomla_TextChanged(object sender, EventArgs e)
        {
            if (ComTypeCategorey.Text == "كرتونه")
            {

                try
                {
                    double nss = Convert.ToDouble(textPriceGomla.Text);
                    double dss = Convert.ToDouble(textUnit.Text);
                    double rrss = nss / dss;
                    PriceGomla = rrss.ToString();

                    PriceGomla = Math.Round(double.Parse(PriceGomla), 4).ToString();
                }
                catch
                { }

            }
            else
            {
                PriceGomla = textPriceGomla.Text;
            }
        }

        private void textPriceKatey_TextChanged(object sender, EventArgs e)
        {
            if (ComTypeCategorey.Text == "كرتونه")
            {

                try
                {
                    double nss = Convert.ToDouble(textPriceKatey.Text);
                    double dss = Convert.ToDouble(textUnit.Text);
                    double rrss = nss / dss;
                    PriceMostahlek = rrss.ToString();

                    PriceMostahlek = Math.Round(double.Parse(PriceMostahlek), 4).ToString();
                }
                catch
                { }

            }
            else
            {
                PriceMostahlek = textPriceKatey.Text;
            }
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double ncsn = Convert.ToDouble(textPriceSheraa.Text);
                double dcsd = Convert.ToDouble(textBox60.Text);
                double rcsr = (ncsn * dcsd) / 100;
                textBox59.Text = rcsr.ToString();

                textBox59.Text = Math.Round(double.Parse(textBox59.Text), 2).ToString();
            }
            catch
            { }

            //------------ حساب الاجمالى -------------

            GET_TotalProduct();
        }

        private void textQuantetyShera_TextChanged(object sender, EventArgs e)
        {
            //----------------- الكرتونةوالدسته والقطع

            if (ComTypeCategorey.Text == "كرتونه")
            {

                //--- حساب سعر البيع والشراء

                //-- البيع
                textBox57.Text = textUnit.Text;


                //------------ حساب عدد القطع بع كتابة الكمية

                if (textQuantetyShera.Text == "")
                {

                    textBox58.Text = "0";
                }
                else
                {
                    double a = Convert.ToDouble(textQuantetyShera.Text);
                    double b = Convert.ToDouble(textBox57.Text);
                    double c = a * b;
                    textBox58.Text = c.ToString();

                    textBox58.Text = Math.Round(double.Parse(textBox58.Text), 2).ToString();

                }

            }
            else if (ComTypeCategorey.Text == "دسته")
            {
                //--- حساب سعر البيع والشراء

                //-- البيع

                textBox57.Text = "12";

                //------------ حساب عدد القطع بع كتابة الكمية
                if (textQuantetyShera.Text == "")
                {

                    textBox58.Text = "0";
                }
                else
                {
                    double a = Convert.ToDouble(textQuantetyShera.Text);
                    double b = Convert.ToDouble(textBox57.Text);
                    double c = a * b;
                    textBox58.Text = c.ToString();

                    textBox58.Text = Math.Round(double.Parse(textBox58.Text), 2).ToString();

                }
            }
            else
            {
                //--- حساب سعر البيع والشراء

                //-- البيع

                textBox57.Text = "1";


                //------------ حساب عدد القطع بع كتابة الكمية

                if (textQuantetyShera.Text == "")
                {

                    textBox58.Text = "0";
                }
                else
                {
                    double a = Convert.ToDouble(textQuantetyShera.Text);
                    double b = Convert.ToDouble(textBox57.Text);
                    double c = a * b;
                    textBox58.Text = c.ToString();

                    textBox58.Text = Math.Round(double.Parse(textBox58.Text), 2).ToString();

                }
            }

            //------------ حساب الاجمالى -------------

            GET_TotalProduct();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chBoxDeletCat.Checked == true)
            {
                combCategorys.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (combCategorys.Text == "")
                {

                }
                else
                {

                    // البحث عن الصنف فى الفاتورة 

                    sqlCommand1.CommandText = "select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        NumCategery = reed["Num"].ToString();
                        textQuantetyShera.Text = reed["Quantity"].ToString();
                        textPriceSheraa.Text = reed["Price"].ToString();
                        ComTypeCategorey.Text = reed["Type"].ToString();
                        textBox60.Text = reed["Discount"].ToString();
                        txtTotalProduct.Text = reed["Total"].ToString();
                        combStorage.Text = reed["Storage"].ToString();

                    }
                    reed.Close();

                    // حذف الصنف من الفاتورة

                    sqlCommand1.CommandText = "delete from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                    sqlCommand1.ExecuteNonQuery();

                    // حذف الصنف من جدول الحركة

                    sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                    sqlCommand1.ExecuteNonQuery();

                    // حذف الصنف من جدول الحركة الجديده

                    sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                    sqlCommand1.ExecuteNonQuery();

                    // حساب الاجمالى بعد الحذف
                    double n = Convert.ToDouble(txtTotalBill.Text);
                    double d = Convert.ToDouble(txtTotalProduct.Text);
                    double r = n - d;
                    txtTotalBill.Text = r.ToString();

                    // حساب الاجمالى الكلى بعد الحذف
                    //double nn = Convert.ToDouble(textBox10.Text);
                    //double dd = Convert.ToDouble(textBox3.Text);
                    //double rr = nn - dd;
                    //textBox10.Text = rr.ToString();


                    // حساب عدد الاصناف بعد الحذف
                    double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                    // double dd = Convert.ToDouble(textBox3.Text);
                    double rrr = nnn - 1;
                    TxtNumCategorey.Text = rrr.ToString();


                    //- إيجاد الكميه الاول

                    sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage = '" + combStorage.Text + "'   ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        CategoryID = reed["ID"].ToString();
                        textQuantetyK.Text = reed["Quantity"].ToString();
                        textUnit.Text = reed["Unity"].ToString();
                        comboBox7.Text = reed["Faction"].ToString();
                        textTotalQuantety.Text = reed["Total"].ToString();
                    }
                    reed.Close();


                    // -------------
                    groupBox5.Text = combCategorys.Text;


                    if (ComTypeCategorey.Text == "كرتونه")
                    {


                        double sn = Convert.ToDouble(textQuantetyShera.Text);
                        double sd = Convert.ToDouble(textQuantetyK.Text);
                        double sr = sd - sn;
                        textQuantetyK.Text = sr.ToString();

                        double an = Convert.ToDouble(textQuantetyShera.Text);
                        double ad = Convert.ToDouble(textUnit.Text);
                        double ar = an * ad;
                        //textBox42.Text = ar.ToString();

                        //double qn = Convert.ToDouble(textBox42.Text);
                        double qd = Convert.ToDouble(textTotalQuantety.Text);
                        double qr = qd - ar;
                        textTotalQuantety.Text = qr.ToString();

                        sqlCommand1.CommandText = "update Category set  Quantity='" + textQuantetyK.Text + "',  Total ='" + textTotalQuantety.Text + "'  where Category='" + combCategorys.Text + "'  and Storage = '" + combStorage.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + 0 + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();



                        // ايجاد الاصناف فى الفاتورة

                        //------------------------------------
                        dt11.Clear();
                        SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                        da11.Fill(dt11);
                        this.dataGridView2.DataSource = dt11;

                        //SqlDataReader dataReader;
                        //SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        //DataSet dataset3 = new DataSet();

                        //dataAdapter.SelectCommand = new SqlCommand("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' ", cn);
                        //dataAdapter.Fill(dataset3);
                        //sqlCommand1.Connection = cn;
                        //sqlCommand1.CommandText = "select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' ";
                        //dataReader = sqlCommand1.ExecuteReader();

                        //while (dataReader.Read())
                        //{
                        //    dataGridView2.DataSource = dataset3.Tables[0];
                        //    //checkedListBox1.Items.Add(dataReader["Name"]);
                        //    i = i + 1;

                        //}


                        //if (i == 0)
                        //    MessageBox.Show("This Name is not exist", "  Search");



                        //dataReader.Close();
                    }
                    else
                    {

                        double sn = Convert.ToDouble(textQuantetyShera.Text);
                        double sd = Convert.ToDouble(textTotalQuantety.Text);
                        double sr = sd - sn;
                        textTotalQuantety.Text = sr.ToString();


                        try
                        {
                            int ss = int.Parse(textQuantetyK.Text);
                            int gg = int.Parse(textTotalQuantety.Text);
                            int zz = gg / ss;

                            textQuantetyK.Text = zz.ToString();


                        }
                        catch
                        { }



                        //*****************
                        try
                        {
                            sqlCommand1.CommandText = "update Category set  Quantity='" + textQuantetyK.Text + "',  Total ='" + textTotalQuantety.Text + "'  where Category='" + combCategorys.Text + "' and Storage = '" + combStorage.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();
                        }
                        catch
                        { }

                        sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + 0 + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();



                        // ايجاد الاصناف فى الفاتورة

                        dt11.Clear();
                        SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                        da11.Fill(dt11);
                        this.dataGridView2.DataSource = dt11;
                    }
                }

                ////------------------- ترقيم الداتا جريد
                //int rowNumber = 1;
                //foreach (DataGridViewRow row in dataGridView2.Rows)
                //{
                //    if (row.IsNewRow) continue;
                //    row.HeaderCell.Value = "" + rowNumber + "";
                //    rowNumber = rowNumber + 1;
                //}
                //dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                //===================== حساب إجمالى الفاتورة عدد الاصناف
                int rowNumber1 = 0;

                double sum1 = 0;
                for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
                {
                    sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                    rowNumber1 = rowNumber1 + 1;

                }

                txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
                TxtNumCategorey.Text = rowNumber1.ToString();



                //-------- حساب الباقى -----------------
                button1.PerformClick();

                if (TxtNumCategorey.Text == "0")// لايوجد اصناف فى الفاتورة
                {
                    txtMosadad.Text = "0";
                    // حذف بيانات الفاتورة
                    try
                    {
                        sqlCommand1.CommandText = "delete from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'   ";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();



                    }
                    catch
                    { }

                }
                else
                { }

                // --------- حساب الربح


                double nn = Convert.ToDouble(textQuantetyShera.Text);
                double bb = Convert.ToDouble(textPriceKatey.Text);
                double dd = nn * bb;



                double cc = Convert.ToDouble(textTotalBeaa.Text);
                double rcsr = cc - dd;
                textTotalBeaa.Text = rcsr.ToString();
                textTotalBeaa.Text = Math.Round(double.Parse(textTotalBeaa.Text), 2).ToString();


                textTotalSheraa.Text = txtTotalBill.Text;
                double ncsn = Convert.ToDouble(textTotalSheraa.Text);
                double dcsd = Convert.ToDouble(textTotalBeaa.Text);
                double tttt = dcsd - ncsn;
                textTotalProfit.Text = tttt.ToString();

                textTotalProfit.Text = Math.Round(double.Parse(textTotalProfit.Text), 2).ToString();



            }
            else
            {

            }


            // ---- عدد قطع الاصناف
            getNumQun();
        }

        public void GetBill()
        {

            //textBox49.Text = "0";
            //textBox50.Text = "0";


            txtTotalBill.Text = "0";
            TxtNumCategorey.Text = "0";
            txtRemaningOld.Text = "0";
            //   textBox10.Text = "0";
            txtDic.Text = "0";
            //   textBox13.Text = "0";
            //  txtRemaningOld1.Text = "0";
            txtMosadad.Text = "0";
            txtRemainingNow.Text = "0";
            //  textBox29.Text = "";

            comClient.Text = "";

            sqlCommand1.CommandText = "select * from BillingData1 where NumBillBillingData = '" + textBillingDataNumBill.Text + "' ";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                textBillingData1NumBill.Text = read["NumBill"].ToString();
                comClient.Text = read["Name"].ToString();
                txtClintName.Text = read["Name"].ToString();
                textClintID.Text = read["ClientID"].ToString();
                txtTotalBill.Text = read["TotalBill"].ToString();
                TxtNumCategorey.Text = read["NumberCategory"].ToString();
                txtRemaningOld.Text = read["PreviousBalance"].ToString();
                //  textBox10.Text = read["Total"].ToString();
                txtDic.Text = read["Discount"].ToString();



                txtMosadad.Text = read["Paid"].ToString();
                txtRemainingNow.Text = read["Remaining"].ToString();

                dateTimePicker1.Text = read["Date"].ToString();

                //  textBox17.Text = read["Move"].ToString();

            }
            read.Close();

            sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "'";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                MoveBoxID = read["ID"].ToString();

            }
            read.Close();
            // ايجاد الاصناف فى الفاتورة

            try
            {


                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                da11.Fill(dt11);
                this.dataGridView2.DataSource = dt11;
            }
            catch
            { }

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;


            }
            dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);




            sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "' ";
            reaad = sqlCommand1.ExecuteReader();
            while (reaad.Read())
            {

                FormName = reaad["Move"].ToString();
                textUser.Text = reaad["NamePrint"].ToString();


            }
            reaad.Close();


        }
        private void dataGridClientsDay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBillingDataNumBill.Text = dataGridClientsDay.Rows[e.RowIndex].Cells[0].Value.ToString();


            //textBox49.Text = "0";
            //textBox50.Text = "0";


            txtTotalBill.Text = "0";
            TxtNumCategorey.Text = "0";
            txtRemaningOld.Text = "0";
            //   textBox10.Text = "0";
            txtDic.Text = "0";
            //   textBox13.Text = "0";
            //  txtRemaningOld1.Text = "0";
            txtMosadad.Text = "0";
            txtRemainingNow.Text = "0";
            //  textBox29.Text = "";

            comClient.Text = "";

            sqlCommand1.CommandText = "select * from BillingData1 where NumBillBillingData = '" + textBillingDataNumBill.Text + "' ";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                textBillingData1NumBill.Text = read["NumBill"].ToString();
                comClient.Text = read["Name"].ToString();
                txtClintName.Text = read["Name"].ToString();
                textClintID.Text = read["ClientID"].ToString();
                txtTotalBill.Text = read["TotalBill"].ToString();
                TxtNumCategorey.Text = read["NumberCategory"].ToString();
                txtRemaningOld.Text = read["PreviousBalance"].ToString();
                dateTimePicker1.Text = read["Date"].ToString();
                txtDic.Text = read["Discount"].ToString();



                txtMosadad.Text = read["Paid"].ToString();
                txtRemainingNow.Text = read["Remaining"].ToString();

                //  textBox17.Text = read["Move"].ToString();

            }
            read.Close();

            sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                MoveBoxID = read["ID"].ToString();

            }
            read.Close();
            // ايجاد الاصناف فى الفاتورة

            try
            {


                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da11.Fill(dt11);
                this.dataGridView2.DataSource = dt11;
            }
            catch
            { }

            ////------------------- ترقيم الداتا جريد
            //int rowNumber = 1;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    if (row.IsNewRow) continue;
            //    row.HeaderCell.Value = "" + rowNumber + "";
            //    rowNumber = rowNumber + 1;


            //}
            //dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);




            sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "' ";
            reaad = sqlCommand1.ExecuteReader();
            while (reaad.Read())
            {

                FormName = reaad["Move"].ToString();
                textUser.Text = reaad["NamePrint"].ToString();


            }
            reaad.Close();



            // ---- عدد قطع الاصناف
            getNumQun();


            //try
            //{
            //    label42.Text = "...............";
            //    label41.Text = "...............";

            //    //************************

            //    sqlCommand1.CommandText = "select * from BillingData where Name = '" + comClient.Text + "' ";
            //    read = sqlCommand1.ExecuteReader();
            //    while (read.Read())
            //    {
            //        label42.Text = read["Move"].ToString();
            //        label41.Text = read["Date"].ToString();


            //    }
            //    read.Close();
            //}
            //catch
            //{ }

        }

        private void Purchases_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CountRemaining();

            //-------------- مصاريف مشتريات

            //try  //----------  إضافة المصروفات
            //{
            //    sqlCommand1.CommandText = "insert into Expended (ID,Date,Name,move,Report,Paid)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + texUser.Text + "','" + comBoxMove.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            //    sqlCommand1.ExecuteNonQuery();


            //}
            //catch
            //{

            //}

            ////----------  إضافة حركة الصندوق

            //try
            //{
            //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comBoxMove.Text + "','" + texUser.Text + "','" + MoveBoxID + "','" + textBox16.Text + "','" + textBox2.Text + "','" + 0 + "','" + txtReminngOLD.Text + "','" + textBox1.Text + "')";
            //    sqlCommand1.ExecuteNonQuery();
            //}
            //catch
            //{

            //}



        }

        private void butLastPriceBilling1_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 300;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 210;



            panelLastPrice.Location = new Point(x, y);


           // panelLastPrice.Location = new Point(661, 220);
            this.panelLastPrice.Size = new System.Drawing.Size(314, 352);
            //--------------------------- اخر اسعار شراء من العميل ---------------------------

            if (panelLastPrice.Visible == true)
            {
                panelLastPrice.Visible = false;
            }
            else
            {
                panelLastPrice.Visible = true;

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing1 where Category ='" + combCategorys.Text + "' AND ClientName ='" + txtClintName.Text + "'", cn);
                    da.Fill(dt);
                    this.dataGridLastPrice.DataSource = dt;
                    this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                    this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                    this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                    this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                    this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                    this.dataGridLastPrice.Columns[0].Width = 60;
                    this.dataGridLastPrice.Columns[1].Width = 80;
                    this.dataGridLastPrice.Columns[2].Width = 50;
                    this.dataGridLastPrice.Columns[3].Width = 50;
                    this.dataGridLastPrice.Columns[4].Width = 50;


                    //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                    //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";




                    dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                }
                catch
                {

                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Category from Category where  Storage = '" + combStorage.Text + "' and Total >= '" + 0 + "'", cn);
                Da.Fill(Dt);
                combCategorys.DataSource = Dt;
                combCategorys.DisplayMember = "Category";
            }
            catch
            {

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Category from Category where Total >= '" + 0 + "'", cn);
                Da.Fill(Dt);
                combCategorys.DataSource = Dt;
                combCategorys.DisplayMember = "Category";
            }
            catch
            {

            }
        }

        private void butLastPrice_Click(object sender, EventArgs e)
        {

        }

        private void butLastPriceBilling_Click(object sender, EventArgs e)
        {
            //--------------------------- اخر اسعار بيع للعميل ---------------------------

            int x = label14.Location.X - 300;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 210;



            panelLastPrice.Location = new Point(x, y);


          //  panelLastPrice.Location = new Point(661, 220); 
            this.panelLastPrice.Size = new System.Drawing.Size(314, 352); 

            if (panelLastPrice.Visible == true)
            {
                panelLastPrice.Visible = false;
            }
            else
            {
                panelLastPrice.Visible = true;

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + txtClintName.Text + "'", cn);
                    da.Fill(dt);
                    this.dataGridLastPrice.DataSource = dt;
                    this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                    this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                    this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                    this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                    this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                    this.dataGridLastPrice.Columns[0].Width = 60;
                    this.dataGridLastPrice.Columns[1].Width = 80;
                    this.dataGridLastPrice.Columns[2].Width = 50;
                    this.dataGridLastPrice.Columns[3].Width = 50;
                    this.dataGridLastPrice.Columns[4].Width = 50;


                    //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                    //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";




                    dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                }
                catch
                {

                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            txtMosadad.Text = txtTotalBill.Text;

        }
        public class Class_CategoreysBill
        {

            public string Num { get; set; }
            public string Storage { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string Type { get; set; }
            public string Price { get; set; }
            public string Discount { get; set; }
            public string Total { get; set; }


        }
        string imageUrl = null;
        private void butPrint_Click(object sender, EventArgs e)
        {
            if (comClient.Text == "")
            {
                MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
                comClient.Focus();
            }
            else
            {
                AppSetting.ClintID = textClintID.Text;
                AppSetting.ClintName = comClient.Text;
                AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                AppSetting.TotalBill = txtTotalBill.Text;
                AppSetting.RemaningOld = txtRemaningOld.Text;
                //AppSetting.textBox27 = textBox27.Text;
                AppSetting.Mosadad = txtMosadad.Text;
                AppSetting.RemainingNow = txtRemainingNow.Text;
                AppSetting.Dic = txtDic.Text;
                //AppSetting.textBox30 = textBox30.Text;

                //AppSetting.dateTimePicker2 = dateTimePicker2.Text;
                AppSetting.textBox57 = textUser.Text;
                AppSetting.BillingDataNumBill = textBillingDataNumBill.Text;
                AppSetting.TypeBill = comTypeBill.Text;
                AppSetting.MoveBill = textMoveBill.Text;

                //Reports.Frm_PrintReportBill frm = new Reports.Frm_PrintReportBill();
                //da = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "'", cn);
                ////da.Fill(frm.elwesifDataSet84.Billing);
                //frm.reportViewerA5.Visible = false;
                //frm.reportViewerA5.RefreshReport();

                //frm.Show();

                List<Class_CategoreysBill> BM = new List<Class_CategoreysBill>();
                BM.Clear();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    Class_CategoreysBill Categoreys = new Class_CategoreysBill
                    {



                        Num = dataGridView2.Rows[i].Cells[0].Value.ToString(),
                        Storage = dataGridView2.Rows[i].Cells[1].Value.ToString(),
                        Category = dataGridView2.Rows[i].Cells[2].Value.ToString(),
                        Quantity = dataGridView2.Rows[i].Cells[3].Value.ToString(),
                        Type = dataGridView2.Rows[i].Cells[4].Value.ToString(),
                        Price = dataGridView2.Rows[i].Cells[5].Value.ToString(),
                        Discount = dataGridView2.Rows[i].Cells[6].Value.ToString(),
                        Total = dataGridView2.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
                rbm.reportViewerA5.LocalReport.DataSources.Clear();
                rbm.reportViewerA5.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerB5.LocalReport.DataSources.Clear();
                rbm.reportViewerB5.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerCasher.LocalReport.DataSources.Clear();
                rbm.reportViewerCasher.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerCasher_8cm.LocalReport.DataSources.Clear();
                rbm.reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
                rbm.reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------

                rbm.reportViewerDiscount.LocalReport.DataSources.Clear();
                rbm.reportViewerDiscount.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerRepEmp.LocalReport.DataSources.Clear();
                rbm.reportViewerRepEmp.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerRepEmpA4.LocalReport.DataSources.Clear();
                rbm.reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.reportViewerA4.LocalReport.DataSources.Clear();
                rbm.reportViewerA4.LocalReport.DataSources.Add(rs);



                rbm.ShowDialog();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 300;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 210;



            panelLastPrice.Location = new Point(x, y);


            // panelLastPrice.Location = new Point(661, 220);

            this.panelLastPrice.Size = new System.Drawing.Size(346, 243);

            if (textMoveBill.Text == "مردودات مبيعات")
            {
                //--------------------------- اخر اسعار بيع للعميل ---------------------------


                if (panelLastPrice.Visible == true)
                {
                    panelLastPrice.Visible = false;
                }
                else
                {
                    panelLastPrice.Visible = true;

                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + txtClintName.Text + "'", cn);
                        da.Fill(dt);
                        this.dataGridLastPrice.DataSource = dt;
                        this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                        this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                        this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                        this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                        this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                        this.dataGridLastPrice.Columns[0].Width = 60;
                        this.dataGridLastPrice.Columns[1].Width = 80;
                        this.dataGridLastPrice.Columns[2].Width = 50;
                        this.dataGridLastPrice.Columns[3].Width = 50;
                        this.dataGridLastPrice.Columns[4].Width = 50;


                        //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                        //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";




                        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                    }
                    catch
                    {
                       
                    }
                }


            }
            else if (textMoveBill.Text == "فاتورة مشتريات")
            {

                //--------------------------- اخر اسعار شراء من العميل --------------------------

                if (panelLastPrice.Visible == true)
                {
                    panelLastPrice.Visible = false;
                }
                else
                {
                    panelLastPrice.Visible = true;

                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing1 where Category ='" + combCategorys.Text + "' AND ClientName ='" + txtClintName.Text + "'", cn);
                        da.Fill(dt);
                        this.dataGridLastPrice.DataSource = dt;
                        this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                        this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                        this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                        this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                        this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                        this.dataGridLastPrice.Columns[0].Width = 60;
                        this.dataGridLastPrice.Columns[1].Width = 80;
                        this.dataGridLastPrice.Columns[2].Width = 50;
                        this.dataGridLastPrice.Columns[3].Width = 50;
                        this.dataGridLastPrice.Columns[4].Width = 50;


                        //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                        //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";




                        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                    }
                    catch
                    {

                    }
                }
            }


        }

        private void GetPriceSheraFinal()
        {
            //------------ حساب سعر الشراء للموجود فى المخزن -------
            if (SystemPriceShera == "السعر الجديد")
            {

                PriceSheraNew = PriceShera;

            }
            else if (SystemPriceShera == "السعر القديم")
            {
                PriceSheraNew = PriceSheraOld;
            }
            //else if (SystemPriceShera == "متوسط السعر")
            //{
            //    double a = Convert.ToDouble(PriceShera);  
            //    double b = Convert.ToDouble(PriceSheraOld);   
            //    double av = (a + b) / 2;

            //    PriceSheraNew = av.ToString();
            //}
            else if (SystemPriceShera == "متوسط السعر")
            {
                double a = Convert.ToDouble(PriceShera);
                double aq = Convert.ToDouble(textQuantetyShera.Text);
                double b = Convert.ToDouble(PriceSheraOld);
                double bq = Convert.ToDouble(textTotalQuantety.Text);
                double av = ((a * aq) + (b * bq)) / (aq + bq);

                PriceSheraNew = av.ToString();
            }
            else
            {
                PriceSheraNew = PriceShera;
            }
        }

        private void AddProductOld()
        {
            // حساب سعر الكميه المطلوبه
            try
            {
                double nn = Convert.ToDouble(textQuantetyShera.Text);
                double dd = Convert.ToDouble(textPriceSheraa.Text);
                double mm = Convert.ToDouble(textBox59.Text);
                double rr = (nn * dd) - (nn * mm);
                txtTotalProduct.Text = rr.ToString();

                txtTotalProduct.Text = Math.Round(double.Parse(txtTotalProduct.Text), 2).ToString();

            }

            catch (FormatException)
            {
                MessageBox.Show("يجب إدخال الكميه المطلوبه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // جمع الكميه من الكميه الكليه

            double nr = Convert.ToDouble(textTotalQuantety.Text);
            double dr = Convert.ToDouble(textBox58.Text);
            double rd = nr + dr;
            textTotalQuantety.Text = rd.ToString();

            // معرفة كمية الاجمالى بعد الخصم

            //int jjs = int.Parse(textTotalQuantety.Text);
            //int jsj = int.Parse(textUnit.Text);
            //int sjj = jjs / jsj;
            //textQuantetyK.Text = sjj.ToString();

            double jjs = Convert.ToDouble(textTotalQuantety.Text);
            double jsj = Convert.ToDouble(textUnit.Text);
            double sjj = jjs / jsj;
            textQuantetyK.Text = sjj.ToString();

            textQuantetyK.Text = Math.Round(double.Parse(textQuantetyK.Text), 0).ToString();


            //*********  حساب قيمة الاجمالى
            double nnnn = Convert.ToDouble(textTotalQuantety.Text);
            double dddd = Convert.ToDouble(PriceShera);
            double rrrr = nnnn * dddd;
            ValueTotalMoney = rrrr.ToString();

            //*********  حساب قيمة القطع
            double na = Convert.ToDouble(textTotalQuantety.Text);
            double da = Convert.ToDouble(textQuantetyK.Text);
            double ca = Convert.ToDouble(textUnit.Text);
            double ra = na - (da * ca);
            textQuntetyTagzea.Text = ra.ToString();



            //------------ حساب سعر الشراء للموجود فى المخزن -------
            if (SystemPriceShera == "السعر الجديد")
            {

                PriceSheraNew = PriceShera;

            }
            else if (SystemPriceShera == "السعر القديم")
            {
                PriceSheraNew = PriceSheraOld;
            }
            //else if (SystemPriceShera == "متوسط السعر")
            //{
            //    double a = Convert.ToDouble(PriceShera);  
            //    double b = Convert.ToDouble(PriceSheraOld);   
            //    double av = (a + b) / 2;

            //    PriceSheraNew = av.ToString();
            //}
            else if (SystemPriceShera == "متوسط السعر")
            {
                //textBox3.Text = PriceSheraOld;
                //textBox4.Text = TotalQuantetyOld;

                double a = Convert.ToDouble(PriceShera);
                double aq = Convert.ToDouble(textQuantetyShera.Text);
                double b = Convert.ToDouble(PriceSheraOld);
                double bq = Convert.ToDouble(TotalQuantetyOld);
                double av = ((a * aq) + (b * bq)) / (aq + bq);

                PriceSheraNew = Math.Round(av, 2).ToString();
                // PriceSheraNew = av.ToString();
            }
            else
            {
                PriceSheraNew = PriceShera;
            }

        }

        private void AddProductNew()
        {
            if (ComTypeCategorey.Text == "كرتونه")
            {
                textQuantetyK.Text = textQuantetyShera.Text; // كمية المخزن تساوى الكمية المشتراه
                textQuntetyTagzea.Text = "0";

                //==========================
                double nss = Convert.ToDouble(textQuantetyK.Text);  // الكميه ك
                double dss = Convert.ToDouble(textUnit.Text);   // الوحدة
                double rrss = nss * dss;
                textTotalQuantety.Text = rrss.ToString();  // الاجمالى بالقطعه
            }
            else
            {
                textQuntetyTagzea.Text = textQuantetyShera.Text;
                textTotalQuantety.Text = textQuantetyShera.Text;
                textQuantetyK.Text = "0";
            }

            //----------------------- اضافة الصنف فى الجدول  -------

            if (Kataey == "1") // قطاعى
            {
                FactionCatogrey = ComTypeCategorey.Text;
            }
            else // جملة
            {
                FactionCatogrey = comboBox7.Text;
            }



            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] byteImage = ms.ToArray();
            sqlCommand1.CommandText = "insert into Category (Category,Storage,Date,Quantity,Unity,Faction,Total,Near,Available,Image)values (@Category,@Storage,@Date,@Quantity,@Unity,@Faction,@Total,@Near,@Available,@Image)";
            sqlCommand1.Parameters.Add("@Category", SqlDbType.VarChar).Value = combCategorys.Text;
            sqlCommand1.Parameters.Add("@Storage", SqlDbType.VarChar).Value = combStorage.Text;
            sqlCommand1.Parameters.Add("@Date", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            sqlCommand1.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = textQuantetyK.Text;
            // sqlCommand1.Parameters.Add("@QuantityT", SqlDbType.VarChar).Value = "0";
            sqlCommand1.Parameters.Add("@Unity", SqlDbType.VarChar).Value = textUnit.Text;
            sqlCommand1.Parameters.Add("@Faction", SqlDbType.VarChar).Value = FactionCatogrey;
            sqlCommand1.Parameters.Add("@Total", SqlDbType.VarChar).Value = textTotalQuantety.Text;
            // sqlCommand1.Parameters.Add("@Price", SqlDbType.VarChar).Value = "0";
            //  sqlCommand1.Parameters.Add("@Value", SqlDbType.VarChar).Value = "0";
            sqlCommand1.Parameters.Add("@Near", SqlDbType.VarChar).Value = textNear.Text;
            sqlCommand1.Parameters.Add("@Available", SqlDbType.VarChar).Value = "نعم";
            //  sqlCommand1.Parameters.Add("@Emwared", SqlDbType.VarChar).Value = comboBox6.Text;
            sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();


            // ---------------------    ايجاد الكود الصنف ------------
            sqlCommand1.CommandText = "select * from Category where Category = '" + combCategorys.Text + "' ";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                IDCategory = read["ID"].ToString();
            }
            read.Close();

            //--------------حساب الباركود واضافة فى الجدول الاصناف -------------

            int b = 0;
            try
            {
                int aa = Convert.ToInt32(AppSetting.BarcodeStart);
                b = aa;
                if (b == 0)
                {

                    int a = Convert.ToInt32(IDCategory);
                    b = 10000000;
                    int s = a + b;
                    Barcode = s.ToString();



                }
                else
                {
                    int a = Convert.ToInt32(IDCategory);
                    int s = a + b;
                    Barcode = s.ToString();


                }

            }
            catch
            {
                int a = Convert.ToInt32(IDCategory);
                b = 1000000000;
                int s = a + b;
                Barcode = s.ToString();
            }


            textBoxtextBarcode.Text = Barcode;


            //=============== تعديل الباركود فى جدول الاصناف ===============
            sqlCommand1.CommandText = "update Category set  Barcode ='" + Barcode + "' where ID='" + IDCategory + "' ";
            sqlCommand1.ExecuteNonQuery();


            //-------------- حساب اجمالى الصنف ----------------
            double nn = Convert.ToDouble(textQuantetyShera.Text);
            double dd = Convert.ToDouble(textPriceSheraa.Text);
            double mm = Convert.ToDouble(textBox59.Text);
            double rr = (nn * dd) - (nn * mm);
            txtTotalProduct.Text = rr.ToString();

            txtTotalProduct.Text = Math.Round(double.Parse(txtTotalProduct.Text), 2).ToString();

            //*********  حساب قيمة الاجمالى فلوس
            double nnnn = Convert.ToDouble(textTotalQuantety.Text);
            double dddd = Convert.ToDouble(ValueTotalMoney);
            double rrrr = nnnn * dddd;
            ValueTotalMoney = rrrr.ToString();

            //********* حساب قيمة القطع
            double na = Convert.ToDouble(textTotalQuantety.Text);
            double da = Convert.ToDouble(textQuantetyK.Text);
            double ca = Convert.ToDouble(textUnit.Text);
            double ra = na - (da * ca);
            textQuntetyTagzea.Text = ra.ToString();


            //------------ حساب سعر الشراء للموجود فى المخزن -------

            PriceSheraNew = PriceShera;



        }
        private void AddProduct()
        {


            // حساب عدد الاصناف

            double nnn = Convert.ToDouble(TxtNumCategorey.Text);
            // double dd = Convert.ToDouble(textBox3.Text);
            double rrr = nnn + 1;
            TxtNumCategorey.Text = rrr.ToString();

            // حساب إجمالى الفاتورة

            double nrn = Convert.ToDouble(txtTotalProduct.Text);
            double drd = Convert.ToDouble(txtTotalBill.Text);
            double rnr = nrn + drd;
            txtTotalBill.Text = rnr.ToString();

            // حساب إجمالى الفاتورة مع الرصيد السابق

            double nsn = Convert.ToDouble(txtTotalBill.Text);
            double dsd = Convert.ToDouble(txtRemaningOld.Text);
            double rsr = nsn + dsd;
            TotalAndRemaninRasedClient = rsr.ToString();


            //------------------------ اضافة الاسعار 
            if (FormName == "فاتورة مشتريات")
            {
                try
                {
                    //=================إضافة الأسعار الشراء الجمله والمستهلك  
                    sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceGomlaAlgomla,PriceNesfAlgomla,PriceMostahlek,Faction)values ('" + IDCategory + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + PriceSheraNew + "','" + PriceGomla + "','" + textPriceGomlaAlgomla.Text + "','" + textPriceNesfGomla.Text + "','" + PriceMostahlek + "','" + comboBox7.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + PriceSheraNew + "',PriceGomla = '" + PriceGomla + "',PriceMostahlek = '" + PriceMostahlek + "',Faction= '" + comboBox7.Text + "' where  Category ='" + combCategorys.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                }
            }
            else
            {
            }

            // إضافة بيانات الفاتورة
            try
            {
                sqlCommand1.CommandText = "insert into BillingData1 (NumBill,NumBillBillingData,ClientID,Name,Date,Move,TotalBill,NumberCategory,PreviousBalance,Total,Discount,ReasonDiscount,Adding,ReasonAdd,Paid,Remaining)values ('" + textBillingData1NumBill.Text + "','" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtTotalBill.Text + "','" + TxtNumCategorey.Text + "','" + txtRemaningOld.Text + "','" + TotalAndRemaninRasedClient + "','" + txtDic.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "')";

                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
            }

            // إضافة بيانات الفاتورة
            if (FormName == "فاتورة مشتريات")
            {
                // إضافة بيانات الفاتورة
                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,NamePrint,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,State,NumberCategory,TotalBillBuyInvalid)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + comClient.Text + "','" + textBox43.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + textUser.Text + "','" + txtRemaningOld.Text + "','" + txtRemaningOld.Text + "','" + txtTotalBill.Text + "','" + txtDic.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + TotalAndRemaninRasedClient + "','" + txtMosadad.Text + "','" + 0 + "','" + txtRemainingNow.Text + "','" + label31.Text + "','" + TxtNumCategorey.Text + "','" + 0 + "')";

                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBillBuy='" + txtTotalBill.Text + "',Pay='" + txtMosadad.Text + "',DiscountBuy='" + txtDic.Text + "',ReasonDiscount='" + 0 + "',Adding='" + 0 + "',ReasonAdd='" + 0 + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "',  State ='" + label31.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";

                    sqlCommand1.ExecuteNonQuery();
                }

                try
                {
                    sqlCommand1.CommandText = "update Category set  Quantity ='" + textQuantetyK.Text + "',QuantityT ='" + textQuntetyTagzea.Text + "',Total = '" + textTotalQuantety.Text + "',Price = '" + PriceSheraNew + "',PriceGomla = '" + PriceGomla + "',PriceGomlaAlgomla = '" + textPriceGomlaAlgomla.Text + "',PriceNesfAlgomla = '" + textPriceNesfGomla.Text + "',PriceMostahlek = '" + PriceMostahlek + "',Value = '" + ValueTotalMoney + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "' ";

                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }
            }
            else if (FormName == "مردودات مبيعات")
            {
                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,NamePrint,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,State,NumberCategory,TotalBillBuyInvalid)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + comClient.Text + "','" + textBox43.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + textUser.Text + "','" + txtRemaningOld.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + txtDic.Text + "','" + 0 + "','" + txtTotalBill.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + TotalAndRemaninRasedClient + "','" + txtMosadad.Text + "','" + 0 + "','" + txtRemainingNow.Text + "','" + label31.Text + "','" + TxtNumCategorey.Text + "','" + 0 + "')";

                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBillInvalid='" + txtTotalBill.Text + "',Pay='" + txtMosadad.Text + "',DiscountBuy='" + txtDic.Text + "',ReasonDiscount='" + 0 + "',Adding='" + 0 + "',ReasonAdd='" + 0 + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "',  State ='" + label31.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";

                    sqlCommand1.ExecuteNonQuery();
                }
                try
                {
                    sqlCommand1.CommandText = "update Category set  Quantity ='" + textQuantetyK.Text + "',QuantityT ='" + textQuntetyTagzea.Text + "',Total = '" + textTotalQuantety.Text + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "' ";

                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }
            }
            else if (FormName == "جرد أول المدة")
            {
                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,NamePrint,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,State,NumberCategory,TotalBillBuyInvalid)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textBox43.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + textUser.Text + "','" + txtRemaningOld.Text + "','" + txtRemaningOld.Text + "','" + txtTotalBill.Text + "','" + txtDic.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + TotalAndRemaninRasedClient + "','" + txtMosadad.Text + "','" + 0 + "','" + txtRemainingNow.Text + "','" + label31.Text + "','" + TxtNumCategorey.Text + "','" + 0 + "')";

                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBillBuy='" + txtTotalBill.Text + "',Pay='" + txtMosadad.Text + "',DiscountBuy='" + txtDic.Text + "',ReasonDiscount='" + 0 + "',Adding='" + 0 + "',ReasonAdd='" + 0 + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "',  State ='" + label31.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";

                    sqlCommand1.ExecuteNonQuery();
                }

                try
                {
                    sqlCommand1.CommandText = "update Category set  Quantity ='" + textQuantetyK.Text + "',QuantityT ='" + textQuntetyTagzea.Text + "',Total = '" + textTotalQuantety.Text + "',Price = '" + PriceShera + "',PriceGomla = '" + PriceGomla + "',PriceGomlaAlgomla = '" + textPriceGomlaAlgomla.Text + "',PriceNesfAlgomla = '" + textPriceNesfGomla.Text + "',PriceMostahlek = '" + PriceMostahlek + "',Value = '" + ValueTotalMoney + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "' ";

                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }

            }
            //***************************////////////**********************
            // اضافة الصنف فى الفاتورة

            sqlCommand1.CommandText = "insert into Billing1 (NumBill,Num,ClinentID,ClientName,CategoryID,Storage,Category,Type,Date,Quantity,Price,Discount,Total)values ('" + textBillingData1NumBill.Text + "','" + TxtNumCategorey.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + IDCategory + "','" + combStorage.Text + "','" + combCategorys.Text + "','" + ComTypeCategorey.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textQuantetyShera.Text + "','" + textPriceSheraa.Text + "','" + textBox60.Text + "','" + txtTotalProduct.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== إضافة حركة الصنف 
            sqlCommand1.CommandText = "insert into CategoryMove (Category,Barcode,Storage,IDBill,Clients,Date,Move,Alwared,FactionAlwared,PriceSH,ValueAlwared,Alsader,FactionAlsader,PriceB,valueAlsader,BalanceK,BalanceT)values ('" + combCategorys.Text + "','" + IDCategory + "','" + combStorage.Text + "','" + textBillingData1NumBill.Text + "','" + comClient.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + textQuantetyShera.Text + "','" + ComTypeCategorey.Text + "','" + textPriceSheraa.Text + "','" + txtTotalProduct.Text + "','" + 0 + "','" + ComTypeCategorey.Text + "','" + 0 + "','" + 0 + "','" + textQuantetyK.Text + "','" + textTotalQuantety.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== إضافة حركة الصنف الجديده 
            sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorys.Text + "','" + combStorage.Text + "','" + comClient.Text + "','" + combStorage.Text + "','" + FormName + "','" + textBillingData1NumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + MoveToCatMove2 + "','" + textBox58.Text + "','" + 0 + "','" + textBox58.Text + "','" + textTotalQuantety.Text + "','" + textUser.Text + "')";
            sqlCommand1.ExecuteNonQuery();
            //------------------ايجاد الاصناف فى الفاتورة ------------------
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            da11.Fill(dt2);
            this.dataGridView2.DataSource = dt2;

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
               
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }


            dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //--------- حساب الباقى ----------------------
            CountRemaining();
            //------ الذهاب لمربع الصنف -----------------
            combCategorys.Focus();

            //------ غلق مربع العميل لعدم حدوث تغير ----
            if (comClient.Enabled == true)
            {
                comClient.Enabled = false;
            }
            else { }
        }

        private void getNumQun()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // نتأكد أن الصف مش فارغ (لأنه أحيانًا بيكون فيه صف جديد فارغ للكتابة)
                if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "")
                {
                    total += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            // عرض النتيجة في Label مثلًا
            TxtNumQuentity.Text = total.ToString("0.00");
        }
        private void butAddProduct_Click(object sender, EventArgs e)
        {
            // GetPriceSheraFinal();

            //-------------------------------------------

            if (textBillingDataNumBill.Text == "")
            {
                GetNumBill();
                GetNumBillSheraa();
            }
            else
            { }

            //------------------------------------------
            TypeCategorey = ComTypeCategorey.Text;

            //-----------------------------------------

            if (txtClintName.Text == "")
            {
                MessageBox.Show("       من فضلك إختار اسم العميل من قائمة العملاء           ", "  خطأ  ");
                comClient.Focus();
            }
            else
            {
                if (ComTypeCategorey.Text == "")
                {
                    MessageBox.Show("       من فضلك إختار الفئة           ", "  خطأ  ");
                    ComTypeCategorey.Focus();
                }
                else
                {
                    if (textBillingData1NumBill.Text == "")
                    {
                        MessageBox.Show("       من فضلك أدخل رقم الفاتورة           ", "  خطأ  ");
                        textBillingData1NumBill.Focus();
                    }
                    else
                    {
                        if (combCategorys.Text == "")
                        {
                            MessageBox.Show("       من فضلك أكتب الصنف الجديد            ", "  خطأ  ");
                            textPriceSheraa.Focus();
                        }
                        else
                        {
                            if (textQuantetyShera.Text == "")
                            {
                                MessageBox.Show("      من فضلك أدخل الكمية            ", "  خطأ  ");
                                textQuantetyShera.Focus();
                            }
                            else
                            {
                                if (textClintID.Text == "")
                                {
                                    MessageBox.Show("       من فضلك إختار إسم العميل وإضغط إنتر           ", "  خطأ  ");

                                    comClient.Focus();
                                }
                                else
                                {
                                    if (textQuantetyShera.Text == "")
                                    {
                                        MessageBox.Show("       من فضلك أدخل الكمية المطلوبه           ", "  خطأ  ");
                                        textQuantetyShera.Focus();
                                    }
                                    else
                                    {
                                        if (textPriceSheraa.Text == "")
                                        {
                                            MessageBox.Show("       من فضلك أدخل سعر الوحدة           ", "  خطأ  ");

                                            textPriceSheraa.Focus();
                                        }
                                        else
                                        {
                                            if (textUnit.Text == "")
                                            {
                                                MessageBox.Show("         من فضلك أدخل وحدة الصنف        ", "  خطأ  ");
                                                textUnit.Focus();
                                            }
                                            else
                                            {
                                                if (comboBox7.Text == "")
                                                {
                                                    MessageBox.Show("         من فضلك أدخل فئة الصنف        ", "  خطأ  ");
                                                    comboBox7.Focus();
                                                }
                                                else
                                                {

                                                    if (textQuantetyK.Text == "") // -------- صنف  جديد 
                                                    {
                                                        AddProductNew();
                                                        textIDCategory.Text = IDCategory;

                                                    }
                                                    else // --------- الصنف موجود من قبل
                                                    {
                                                        AddProductOld();
                                                        IDCategory = textIDCategory.Text;
                                                    }

                                                    AddProduct();

                                                    // --------- حساب الربح


                                                    double nn = Convert.ToDouble(textQuantetyShera.Text);
                                                    double bb = Convert.ToDouble(textPriceKatey.Text);
                                                    double dd = nn * bb;



                                                    double cc = Convert.ToDouble(textTotalBeaa.Text);
                                                    double rcsr = dd + cc;
                                                    textTotalBeaa.Text = rcsr.ToString();
                                                    textTotalBeaa.Text = Math.Round(double.Parse(textTotalBeaa.Text), 2).ToString();


                                                    textTotalSheraa.Text = txtTotalBill.Text;
                                                    double ncsn = Convert.ToDouble(textTotalSheraa.Text);
                                                    double dcsd = Convert.ToDouble(textTotalBeaa.Text);
                                                    double tttt = dcsd - ncsn;
                                                    textTotalProfit.Text = tttt.ToString();

                                                    textTotalProfit.Text = Math.Round(double.Parse(textTotalProfit.Text), 2).ToString();



                                                    //---------------- تفريغ البيانات ----------
                                                    CleanData();
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ---- عدد قطع الاصناف
            getNumQun();

        }

        private void dataGridLastPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textPriceSheraa.Text = dataGridLastPrice.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch
            { }
        }

        private void txtMosadad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // butLogin.Focus();
                button1.PerformClick();

            }
        }

        private void butDeleteBill_Click(object sender, EventArgs e)
        {
            // int Number = 1;
            //string Number = "";
            //  double sum1 = 0;
            //for (int i = 0; i < length; i++)
            //{

            //}
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد حذف الفاتورة نهائيا ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridView2.RowCount - 1);

                for (int j = 0; j < NumRows; j++)
                {
                    //sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                    //Number = Number + 1;



                    //  textBox1.Text = (dataGridView2.RowCount - 1).ToString();

                    // combCategorys.Text = dataGridView2.Rows[Number].Cells[2].Value.ToString();

                    //   Number = dataGridView2.Rows[0].Cells[0].Value.ToString();

                    combCategorys.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();


                    // البحث عن الصنف فى الفاتورة 

                    sqlCommand1.CommandText = "select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        NumCategery = reed["Num"].ToString();
                        textQuantetyShera.Text = reed["Quantity"].ToString();
                        textPriceSheraa.Text = reed["Price"].ToString();
                        ComTypeCategorey.Text = reed["Type"].ToString();
                        textBox60.Text = reed["Discount"].ToString();
                        txtTotalProduct.Text = reed["Total"].ToString();
                        combStorage.Text = reed["Storage"].ToString();
                        combCategorys.Text = reed["Category"].ToString();

                    }
                    reed.Close();

                    //sqlCommand1.CommandText = "select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Num='" + Number + "' ";
                    //reed = sqlCommand1.ExecuteReader();
                    //while (reed.Read())
                    //{
                    //    NumCategery = reed["Num"].ToString();
                    //    textQuntity.Text = reed["Quantity"].ToString();
                    //    textPrice.Text = reed["Price"].ToString();
                    //    ComTypeCategorey.Text = reed["Type"].ToString();
                    //    textDiscCategorey1.Text = reed["Discount"].ToString();
                    //    txtTotalCategory.Text = reed["Total"].ToString();
                    //    combStorage.Text = reed["Storage"].ToString();
                    //    combCategorys.Text = reed["Category"].ToString();

                    //}
                    //reed.Close();


                    if (combCategorys.Text == "")

                    {

                    }
                    else
                    {

                        // حذف الصنف من الفاتورة
                        // حذف الصنف من الفاتورة

                        sqlCommand1.CommandText = "delete from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة

                        sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة الجديده

                        sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حساب الاجمالى بعد الحذف
                        double n = Convert.ToDouble(txtTotalBill.Text);
                        double d = Convert.ToDouble(txtTotalProduct.Text);
                        double r = n - d;
                        txtTotalBill.Text = r.ToString();

                        // حساب الاجمالى الكلى بعد الحذف
                        //double nn = Convert.ToDouble(textBox10.Text);
                        //double dd = Convert.ToDouble(textBox3.Text);
                        //double rr = nn - dd;
                        //textBox10.Text = rr.ToString();


                        // حساب عدد الاصناف بعد الحذف
                        double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                        // double dd = Convert.ToDouble(textBox3.Text);
                        double rrr = nnn - 1;
                        TxtNumCategorey.Text = rrr.ToString();


                        //- إيجاد الكميه الاول

                        sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage = '" + combStorage.Text + "'   ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            CategoryID = reed["ID"].ToString();
                            textQuantetyK.Text = reed["Quantity"].ToString();
                            textUnit.Text = reed["Unity"].ToString();
                            comboBox7.Text = reed["Faction"].ToString();
                            textTotalQuantety.Text = reed["Total"].ToString();
                        }
                        reed.Close();


                        // -------------
                        groupBox5.Text = combCategorys.Text;


                        if (ComTypeCategorey.Text == "كرتونه")
                        {


                            double sn = Convert.ToDouble(textQuantetyShera.Text);
                            double sd = Convert.ToDouble(textQuantetyK.Text);
                            double sr = sd - sn;
                            textQuantetyK.Text = sr.ToString();

                            double an = Convert.ToDouble(textQuantetyShera.Text);
                            double ad = Convert.ToDouble(textUnit.Text);
                            double ar = an * ad;
                            //textBox42.Text = ar.ToString();

                            //double qn = Convert.ToDouble(textBox42.Text);
                            double qd = Convert.ToDouble(textTotalQuantety.Text);
                            double qr = qd - ar;
                            textTotalQuantety.Text = qr.ToString();

                            sqlCommand1.CommandText = "update Category set  Quantity='" + textQuantetyK.Text + "',  Total ='" + textTotalQuantety.Text + "'  where Category='" + combCategorys.Text + "'  and Storage = '" + combStorage.Text + "'  ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + 0 + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة

                            //------------------------------------
                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;

                            //SqlDataReader dataReader;
                            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
                            //DataSet dataset3 = new DataSet();

                            //dataAdapter.SelectCommand = new SqlCommand("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' ", cn);
                            //dataAdapter.Fill(dataset3);
                            //sqlCommand1.Connection = cn;
                            //sqlCommand1.CommandText = "select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' ";
                            //dataReader = sqlCommand1.ExecuteReader();

                            //while (dataReader.Read())
                            //{
                            //    dataGridView2.DataSource = dataset3.Tables[0];
                            //    //checkedListBox1.Items.Add(dataReader["Name"]);
                            //    i = i + 1;

                            //}


                            //if (i == 0)
                            //    MessageBox.Show("This Name is not exist", "  Search");



                            //dataReader.Close();
                        }
                        else
                        {

                            double sn = Convert.ToDouble(textQuantetyShera.Text);
                            double sd = Convert.ToDouble(textTotalQuantety.Text);
                            double sr = sd - sn;
                            textTotalQuantety.Text = sr.ToString();


                            try
                            {
                                int ss = int.Parse(textQuantetyK.Text);
                                int gg = int.Parse(textTotalQuantety.Text);
                                int zz = gg / ss;

                                textQuantetyK.Text = zz.ToString();


                            }
                            catch
                            { }



                            //*****************
                            try
                            {
                                sqlCommand1.CommandText = "update Category set  Quantity='" + textQuantetyK.Text + "',  Total ='" + textTotalQuantety.Text + "'  where Category='" + combCategorys.Text + "' and Storage = '" + combStorage.Text + "' ";
                                sqlCommand1.ExecuteNonQuery();
                            }
                            catch
                            { }

                            sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + 0 + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة

                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;
                        }
                    }

                    ////------------------- ترقيم الداتا جريد
                    //int rowNumber = 1;
                    //foreach (DataGridViewRow row in dataGridView2.Rows)
                    //{
                    //    if (row.IsNewRow) continue;
                    //    row.HeaderCell.Value = "" + rowNumber + "";
                    //    rowNumber = rowNumber + 1;
                    //}
                    //dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                    //===================== حساب إجمالى الفاتورة عدد الاصناف
                    int rowNumber1 = 0;

                    double sum1 = 0;
                    for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
                    {
                        sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                        rowNumber1 = rowNumber1 + 1;

                    }

                    txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
                    TxtNumCategorey.Text = rowNumber1.ToString();



                    //-------- حساب الباقى -----------------
                    button1.PerformClick();

                    if (TxtNumCategorey.Text == "0")// لايوجد اصناف فى الفاتورة
                    {
                        txtMosadad.Text = "0";
                        // حذف بيانات الفاتورة
                        try
                        {
                            sqlCommand1.CommandText = "delete from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'   ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                        }
                        catch
                        { }

                    }
                    else
                    { }


                    // تعديل الرصيد فى جدول العملاء
                    try
                    {
                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                    catch
                    {
                        MessageBox.Show(" pleas correct the data");
                    }


                    // Number = Number + 1;

                }

            }


            txtMosadad.Text = "0";
            txtRemainingNow.Text = "0";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //if (panel2.Visible == false)
            //{

            //    panel2.Visible = true;
            //    textBox1.Focus();
            //}
            //else
            //{
            //    panel2.Visible = false;
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            radio_GetAllCategry.Checked = true;

            DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,PriceMostahlek From Category where Category like '%" + textBox2.Text + "%' ", cn);

            da.Fill(dt);
            this.dataGridSearchCategory.DataSource = dt;
        }

        private void dataGridSearchCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridSearchCategory.Rows[e.RowIndex].Cells[1].Value.ToString();


            textBox1.Text = "";

            textQuantetyShera.Focus();


            //if (checkBox1.Checked == true)
            //{
            //    textQuntity.Text = "1";
            //    butAddCategorey.PerformClick();
            //    textBox1.Focus();
            //}
            //else
            //{
            //    panel2.Visible = false;
            //    textQuntity.Focus();



            //}
        }

        private void dataGridSearchCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butSearchCategory_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 612;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 40;

           

            panel2.Location = new Point(x, y);




            //panel2.Location = new Point(333, 194); 
            this.panel2.Size = new System.Drawing.Size(643, 380); 

            if (panel2.Visible == false)
            {

                panel2.Visible = true;
                textBox1.Focus();
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppSetting.NumBillToBarcodeForm = textBillingData1NumBill.Text;
            this.Close();

            TransferData.FormName = "الباركود";

            if (Barcode1 == null || Barcode1.IsDisposed == true)
            {
                Barcode1 = new Barcode();
            }
            Barcode1.MdiParent = Main.ActiveForm;
            Barcode1.Show();
        }

        private void Purchases_FormClosed(object sender, FormClosedEventArgs e)
        {
            //*************** تسجيل الحركات  ***********************

            saveEvents("تم غلق شاشة  " + TransferData.FormName);

            //********************************************************
        }

        private void butClientDays_Click(object sender, EventArgs e)
        {
           // PanalClintsDay.Location = new Point(37, 102); 
            this.PanalClintsDay.Size = new System.Drawing.Size(765, 286); 

            if (PanalClintsDay.Visible == true)
            {
                PanalClintsDay.Visible = false;
                //panel14.Visible = false;
                //panel10.Visible = false;
                //panel3.Visible = false;

            }
            else
            {
                if (FormName == "فاتورة مشتريات")
                {
                    //------------------------------------
                    DataTable dt12 = new DataTable();
                    dt12.Clear();
                    SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  and Move like '" + FormName + "'  ", cn);
                    da21.Fill(dt12);
                    this.dataGridClientsDay.DataSource = dt12;

                    try
                    {
                        int sum = 0;
                        for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                        {
                            sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[3].Value);


                        }
                        textTotalBill.Text = sum.ToString();
                    }
                    catch
                    { }
                }
                else if (FormName == "مردودات مبيعات")
                {
                    //------------------------------------
                    DataTable dt12 = new DataTable();
                    dt12.Clear();
                    SqlDataAdapter da21 = new SqlDataAdapter("select NumBill,Name,Type,TotalBillInvalid as TotalBillBuy,Pay,Remaining from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  and Move like '" + FormName + "'  ", cn);
                    da21.Fill(dt12);
                    this.dataGridClientsDay.DataSource = dt12;

                    try
                    {
                        int sum = 0;
                        for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                        {
                            sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[3].Value);


                        }
                        textTotalBill.Text = sum.ToString();
                    }
                    catch
                    { }

                }
                
                PanalClintsDay.Visible = true;
                //panel14.Visible = false;
                //panel10.Visible = false;
                //panel3.Visible = false;



              

                try
                {
                    int sum = 0;
                    for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                    {
                        sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[4].Value);


                    }
                    textTotalTawred.Text = sum.ToString();
                }
                catch
                { }

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridClientsDay.Rows)
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
        }

        private void butPrinting_Click(object sender, EventArgs e)
        {
            if (comClient.Text == "")
            {
                MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
                comClient.Focus();
            }
            else
            {
                AppSetting.ClintID = textClintID.Text;
                AppSetting.ClintName = comClient.Text;
                AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                AppSetting.TotalBill = txtTotalBill.Text;
                AppSetting.RemaningOld = txtRemaningOld.Text;
                //AppSetting.textBox27 = textBox27.Text;
                AppSetting.Mosadad = txtMosadad.Text;
                AppSetting.RemainingNow = txtRemainingNow.Text;
                AppSetting.Dic = txtDic.Text;
                //AppSetting.textBox30 = textBox30.Text;

                //AppSetting.dateTimePicker2 = dateTimePicker2.Text;
                AppSetting.textBox57 = textUser.Text;
                AppSetting.BillingDataNumBill = textBillingDataNumBill.Text;
                AppSetting.TypeBill = comTypeBill.Text;
                AppSetting.MoveBill = textMoveBill.Text;

                //Reports.Frm_PrintReportBill frm = new Reports.Frm_PrintReportBill();
                //da = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "'", cn);
                ////da.Fill(frm.elwesifDataSet84.Billing);
                //frm.reportViewerA5.Visible = false;
                //frm.reportViewerA5.RefreshReport();

                //frm.Show();

                List<Class_CategoreysBill> BM = new List<Class_CategoreysBill>();
                BM.Clear();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    Class_CategoreysBill Categoreys = new Class_CategoreysBill
                    {



                        Num = dataGridView2.Rows[i].Cells[0].Value.ToString(),
                        Storage = dataGridView2.Rows[i].Cells[1].Value.ToString(),
                        Category = dataGridView2.Rows[i].Cells[2].Value.ToString(),
                        Quantity = dataGridView2.Rows[i].Cells[3].Value.ToString(),
                        Type = dataGridView2.Rows[i].Cells[4].Value.ToString(),
                        Price = dataGridView2.Rows[i].Cells[5].Value.ToString(),
                        Discount = dataGridView2.Rows[i].Cells[6].Value.ToString(),
                        Total = dataGridView2.Rows[i].Cells[7].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }
                rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();

                rbm.ReportSource = rs;

                rbm.InvoiceDataObj =CollectInvoiceData();

                rbm.ShowDialog();


                //Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
                //rbm.reportViewerA5.LocalReport.DataSources.Clear();
                //rbm.reportViewerA5.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerB5.LocalReport.DataSources.Clear();
                //rbm.reportViewerB5.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerCasher.LocalReport.DataSources.Clear();
                //rbm.reportViewerCasher.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerCasher_8cm.LocalReport.DataSources.Clear();
                //rbm.reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
                //rbm.reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------

                //rbm.reportViewerDiscount.LocalReport.DataSources.Clear();
                //rbm.reportViewerDiscount.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerRepEmp.LocalReport.DataSources.Clear();
                //rbm.reportViewerRepEmp.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerRepEmpA4.LocalReport.DataSources.Clear();
                //rbm.reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerA4.LocalReport.DataSources.Clear();
                //rbm.reportViewerA4.LocalReport.DataSources.Add(rs);
                ////------------------------------------------------------
                //rbm.reportViewerCasher_6cm_Dis.LocalReport.DataSources.Clear();
                //rbm.reportViewerCasher_6cm_Dis.LocalReport.DataSources.Add(rs);



                //rbm.ShowDialog();
            }
        }

        private void butDeleteBilling_Click(object sender, EventArgs e)
        {
            // int Number = 1;
            //string Number = "";
            //  double sum1 = 0;
            //for (int i = 0; i < length; i++)
            //{

            //}
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد حذف الفاتورة نهائيا ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridView2.RowCount - 1);

                for (int j = 0; j < NumRows; j++)
                {
                    //sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                    //Number = Number + 1;



                    //  textBox1.Text = (dataGridView2.RowCount - 1).ToString();

                    // combCategorys.Text = dataGridView2.Rows[Number].Cells[2].Value.ToString();

                    //   Number = dataGridView2.Rows[0].Cells[0].Value.ToString();

                    combCategorys.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();


                    // البحث عن الصنف فى الفاتورة 

                    sqlCommand1.CommandText = "select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        NumCategery = reed["Num"].ToString();
                        textQuantetyShera.Text = reed["Quantity"].ToString();
                        textPriceSheraa.Text = reed["Price"].ToString();
                        ComTypeCategorey.Text = reed["Type"].ToString();
                        textBox60.Text = reed["Discount"].ToString();
                        txtTotalProduct.Text = reed["Total"].ToString();
                        combStorage.Text = reed["Storage"].ToString();
                        combCategorys.Text = reed["Category"].ToString();

                    }
                    reed.Close();

                    //sqlCommand1.CommandText = "select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Num='" + Number + "' ";
                    //reed = sqlCommand1.ExecuteReader();
                    //while (reed.Read())
                    //{
                    //    NumCategery = reed["Num"].ToString();
                    //    textQuntity.Text = reed["Quantity"].ToString();
                    //    textPrice.Text = reed["Price"].ToString();
                    //    ComTypeCategorey.Text = reed["Type"].ToString();
                    //    textDiscCategorey1.Text = reed["Discount"].ToString();
                    //    txtTotalCategory.Text = reed["Total"].ToString();
                    //    combStorage.Text = reed["Storage"].ToString();
                    //    combCategorys.Text = reed["Category"].ToString();

                    //}
                    //reed.Close();


                    if (combCategorys.Text == "")

                    {

                    }
                    else
                    {

                        // حذف الصنف من الفاتورة
                        // حذف الصنف من الفاتورة

                        sqlCommand1.CommandText = "delete from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة

                        sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة الجديده

                        sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingData1NumBill.Text + "' and Category='" + combCategorys.Text + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حساب الاجمالى بعد الحذف
                        double n = Convert.ToDouble(txtTotalBill.Text);
                        double d = Convert.ToDouble(txtTotalProduct.Text);
                        double r = n - d;
                        txtTotalBill.Text = r.ToString();

                        // حساب الاجمالى الكلى بعد الحذف
                        //double nn = Convert.ToDouble(textBox10.Text);
                        //double dd = Convert.ToDouble(textBox3.Text);
                        //double rr = nn - dd;
                        //textBox10.Text = rr.ToString();


                        // حساب عدد الاصناف بعد الحذف
                        double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                        // double dd = Convert.ToDouble(textBox3.Text);
                        double rrr = nnn - 1;
                        TxtNumCategorey.Text = rrr.ToString();


                        //- إيجاد الكميه الاول

                        sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage = '" + combStorage.Text + "'   ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            CategoryID = reed["ID"].ToString();
                            textQuantetyK.Text = reed["Quantity"].ToString();
                            textUnit.Text = reed["Unity"].ToString();
                            comboBox7.Text = reed["Faction"].ToString();
                            textTotalQuantety.Text = reed["Total"].ToString();
                        }
                        reed.Close();


                        // -------------
                        groupBox5.Text = combCategorys.Text;


                        if (ComTypeCategorey.Text == "كرتونه")
                        {


                            double sn = Convert.ToDouble(textQuantetyShera.Text);
                            double sd = Convert.ToDouble(textQuantetyK.Text);
                            double sr = sd - sn;
                            textQuantetyK.Text = sr.ToString();

                            double an = Convert.ToDouble(textQuantetyShera.Text);
                            double ad = Convert.ToDouble(textUnit.Text);
                            double ar = an * ad;
                            //textBox42.Text = ar.ToString();

                            //double qn = Convert.ToDouble(textBox42.Text);
                            double qd = Convert.ToDouble(textTotalQuantety.Text);
                            double qr = qd - ar;
                            textTotalQuantety.Text = qr.ToString();

                            sqlCommand1.CommandText = "update Category set  Quantity='" + textQuantetyK.Text + "',  Total ='" + textTotalQuantety.Text + "'  where Category='" + combCategorys.Text + "'  and Storage = '" + combStorage.Text + "'  ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + 0 + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة

                            //------------------------------------
                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;

                            //SqlDataReader dataReader;
                            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
                            //DataSet dataset3 = new DataSet();

                            //dataAdapter.SelectCommand = new SqlCommand("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' ", cn);
                            //dataAdapter.Fill(dataset3);
                            //sqlCommand1.Connection = cn;
                            //sqlCommand1.CommandText = "select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' ";
                            //dataReader = sqlCommand1.ExecuteReader();

                            //while (dataReader.Read())
                            //{
                            //    dataGridView2.DataSource = dataset3.Tables[0];
                            //    //checkedListBox1.Items.Add(dataReader["Name"]);
                            //    i = i + 1;

                            //}


                            //if (i == 0)
                            //    MessageBox.Show("This Name is not exist", "  Search");



                            //dataReader.Close();
                        }
                        else
                        {

                            double sn = Convert.ToDouble(textQuantetyShera.Text);
                            double sd = Convert.ToDouble(textTotalQuantety.Text);
                            double sr = sd - sn;
                            textTotalQuantety.Text = sr.ToString();


                            try
                            {
                                int ss = int.Parse(textQuantetyK.Text);
                                int gg = int.Parse(textTotalQuantety.Text);
                                int zz = gg / ss;

                                textQuantetyK.Text = zz.ToString();


                            }
                            catch
                            { }



                            //*****************
                            try
                            {
                                sqlCommand1.CommandText = "update Category set  Quantity='" + textQuantetyK.Text + "',  Total ='" + textTotalQuantety.Text + "'  where Category='" + combCategorys.Text + "' and Storage = '" + combStorage.Text + "' ";
                                sqlCommand1.ExecuteNonQuery();
                            }
                            catch
                            { }

                            sqlCommand1.CommandText = "update BillingData1 set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + 0 + "' where NumBill='" + textBillingData1NumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة

                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;
                        }
                    }

                    ////------------------- ترقيم الداتا جريد
                    //int rowNumber = 1;
                    //foreach (DataGridViewRow row in dataGridView2.Rows)
                    //{
                    //    if (row.IsNewRow) continue;
                    //    row.HeaderCell.Value = "" + rowNumber + "";
                    //    rowNumber = rowNumber + 1;
                    //}
                    //dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                    //===================== حساب إجمالى الفاتورة عدد الاصناف
                    int rowNumber1 = 0;

                    double sum1 = 0;
                    for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
                    {
                        sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                        rowNumber1 = rowNumber1 + 1;

                    }

                    txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
                    TxtNumCategorey.Text = rowNumber1.ToString();



                    //-------- حساب الباقى -----------------
                    button1.PerformClick();

                    if (TxtNumCategorey.Text == "0")// لايوجد اصناف فى الفاتورة
                    {
                        txtMosadad.Text = "0";
                        // حذف بيانات الفاتورة
                        try
                        {
                            sqlCommand1.CommandText = "delete from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'   ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                        }
                        catch
                        { }

                    }
                    else
                    { }


                    // تعديل الرصيد فى جدول العملاء
                    try
                    {
                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                    catch
                    {
                        MessageBox.Show(" pleas correct the data");
                    }


                    // Number = Number + 1;

                }

            }


            txtMosadad.Text = "0";
            txtRemainingNow.Text = "0";
        }

        private void butBarcode_Click(object sender, EventArgs e)
        {
            AppSetting.NumBillToBarcodeForm = textBillingData1NumBill.Text;
            this.Close();

            TransferData.FormName = "الباركود";

            if (Barcode1 == null || Barcode1.IsDisposed == true)
            {
                Barcode1 = new Barcode();
            }
            Barcode1.MdiParent = Main.ActiveForm;
            Barcode1.Show();
        }

        private void label27_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 260;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 50;



            panel6.Location = new Point(x, y);

            // panel6.Location = new Point(673, 94);
            this.panel6.Size = new System.Drawing.Size(306, 395);


          

           

            if (panel6.Visible == true)
            {

                panel6.Visible = false;

            }
            else
            {
                panel6.Visible = true;

                //------------------------------------
                DataTable dt33 = new DataTable();
                dt33.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from BillingData where Name = '" + comClient.Text + "' and Move Like'" + FormName + "' ", cn);
                da11.Fill(dt33);
                this.dataGridView1.DataSource = dt33;


                //-----------------
                textBox38.Text = comClient.Text;

            }
        }

        private void label33_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textPriceSheraa.Text);
            double b = Convert.ToDouble(textPriceGomla.Text);
            double c = Convert.ToDouble(textPriceKatey.Text);
            double d = Convert.ToDouble(textUnit.Text);

            double r = a / d;
            textPriceSheraa.Text = r.ToString();
            textPriceSheraa.Text = Math.Round(double.Parse(textPriceSheraa.Text), 2).ToString();
            double r1 = b / d;
            textPriceGomla.Text = r1.ToString();
            textPriceGomla.Text = Math.Round(double.Parse(textPriceGomla.Text), 2).ToString();
            double r2 = c / d;
            textPriceKatey.Text = r2.ToString();
            textPriceKatey.Text = Math.Round(double.Parse(textPriceKatey.Text), 2).ToString();
        }

        private void label36_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textPriceSheraa.Text);
            double b = Convert.ToDouble(textPriceGomla.Text);
            double c = Convert.ToDouble(textPriceKatey.Text);
            double d = Convert.ToDouble(textUnit.Text);

            double r = a * d;
            textPriceSheraa.Text = r.ToString();
            textPriceSheraa.Text = Math.Round(double.Parse(textPriceSheraa.Text), 2).ToString();
            double r1 = b * d;
            textPriceGomla.Text = r1.ToString();
            textPriceGomla.Text = Math.Round(double.Parse(textPriceGomla.Text), 2).ToString();
            double r2 = c * d;
            textPriceKatey.Text = r2.ToString();
            textPriceKatey.Text = Math.Round(double.Parse(textPriceKatey.Text), 2).ToString();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Select Files(*.xlsx)|*.xlsx";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data source='" + op.FileName + "';Extended properties='Excel 8.0;HDR=False'");
                    conn.Open();
                    OleDbCommand cmdd = new OleDbCommand(" select * from[Billing1$]", conn);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmdd;
                    DataTable dt = new DataTable();
                    dt.Clear();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;
                    conn.Close();

                    //OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data source=F:\Export.xlsx;Extended properties='Excel 8.0;HDR=False'");
                    //conn.Open();
                    //OleDbCommand cmdd = new OleDbCommand(" select * from[Billing1$]", conn);
                    //OleDbDataAdapter da = new OleDbDataAdapter();
                    //da.SelectCommand = cmdd;
                    //DataTable dt = new DataTable();
                    //dt.Clear();
                    //da.Fill(dt);
                    //dataGridView3.DataSource = dt;
                    //conn.Close();
               }
            }
            catch
            {

            }
        }

        private void butAddDataToBill_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد اضافة الاصناف  ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridView3.RowCount - 1);
                int num = 1;
                for (int j = 0; j < NumRows; j++) // rows
                {
                    //for (int i = 0; i <= 8; i++)// colom
                    //{
                    num = int.Parse(dataGridView3.Rows[j].Cells[0].Value.ToString());

                    combStorage.Text = dataGridView3.Rows[j].Cells[1].Value.ToString();
                    combCategorys.Text = dataGridView3.Rows[j].Cells[2].Value.ToString();
                    textQuantetyShera.Text = dataGridView3.Rows[j].Cells[3].Value.ToString();
                    ComTypeCategorey.Text = dataGridView3.Rows[j].Cells[4].Value.ToString();
                    textPriceSheraa.Text = dataGridView3.Rows[j].Cells[5].Value.ToString();
                    textPriceGomla.Text = dataGridView3.Rows[j].Cells[8].Value.ToString();
                    textPriceKatey.Text = dataGridView3.Rows[j].Cells[9].Value.ToString();

                    textBox60.Text = dataGridView3.Rows[j].Cells[6].Value.ToString();
                    txtTotalProduct.Text = dataGridView3.Rows[j].Cells[7].Value.ToString();

                    butAddProduct.PerformClick();
                    num++;


                    // }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 910;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 20;



            panel8.Location = new Point(x, y);




            //panel2.Location = new Point(333, 194); 
         //   this.panel8.Size = new System.Drawing.Size(1100, 600);


            //panel8.Location = new Point(74, 102); 
            //this.panel8.Size = new System.Drawing.Size(973, 505); 

            if (panel8.Visible==true)
            {
                panel8.Visible = false;
            }
            else
            {
                panel8.Visible = true;
            }
        }

        private void radio_GetAllCategry_CheckedChanged(object sender, EventArgs e)
        {
           // dataGridGetAllCategry_BestSeller.Visible = false;
            dataGridViewClientsCategory.Visible = false;
            dataGridSearchCategory.Visible = true;
            GetAllCategry();
        }

        private void radio_GetAllCategry_Quntety_CheckedChanged(object sender, EventArgs e)
        {

            dataGridViewClientsCategory.Visible = true;
            dataGridSearchCategory.Visible = false;
            GetAllCategryClients();
        }

        private void dataGridViewClientsCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridViewClientsCategory.Rows[e.RowIndex].Cells[0].Value.ToString();


           // textBox1.Text = "";

            textQuantetyShera.Focus();
        }

        private void ComTypeCategorey_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void ComTypeCategorey_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNumUnit();
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 690;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 35;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel10.Location = new Point(x, y);
            //this.panel10.Size = new System.Drawing.Size(742, 351);



            //panel10.Location = new Point(522, 138);
            this.panel10.Size = new System.Drawing.Size(748, 341); 
            if (panel10.Visible == false)
            {

                panel10.Visible = true;
                textSearchClint.Focus();
            }
            else
            {
                panel10.Visible = false;
            }
        }

        private void textSearchClint_TextChanged(object sender, EventArgs e)
        {
            //|| TelHome = '%" + textSearchClint.Text + "%' || TelMobil = '%" + textSearchClint.Text + "%' - Name like '%" + textSearchClint.Text + "%' ||
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter(@"Select ID,Name,Company,TelHome,TelMobil,Address,PreviousBalance From Clients where  Name like '%" + textSearchClint.Text + "%'", cn);

                da.Fill(dt);
                this.dataGridSearchClint.DataSource = dt;
            }
            catch
            { }
        }

        private void textSearchClintMobil_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter(@"Select ID,Name,Company,TelHome,TelMobil,Address,PreviousBalance From Clients where TelMobil like '%" + textSearchClintMobil.Text + "%' ", cn);

                da.Fill(dt);
                this.dataGridSearchClint.DataSource = dt;
            }
            catch
            { }
        }

        private void dataGridSearchClint_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comClient.Text = dataGridSearchClint.Rows[e.RowIndex].Cells[1].Value.ToString();
            panel10.Visible = false;
        }

        private void butProfit_Click(object sender, EventArgs e)
        {
            if (panelProfits.Visible == true)
            {
                panelProfits.Visible = false;
            }
            else
            {
                panelProfits.Visible = true;

               
                //GetProfitBill();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (FormName == "فاتورة مشتريات")
            {
                //------------------------------------
                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'   and Move like '" + FormName + "'  ", cn);
                da21.Fill(dt12);
                this.dataGridClientsDay.DataSource = dt12;

                try
                {
                    int sum = 0;
                    for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                    {
                        sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[3].Value);


                    }
                    textTotalBill.Text = sum.ToString();
                }
                catch
                { }
            }
            else if (FormName == "مردودات مبيعات")
            {
                //------------------------------------
                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select NumBill,Name,Type,TotalBillInvalid as TotalBillBuy,Pay,Remaining from BillingData where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'  and Move like '" + FormName + "'  ", cn);
                da21.Fill(dt12);
                this.dataGridClientsDay.DataSource = dt12;

                try
                {
                    int sum = 0;
                    for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                    {
                        sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[3].Value);


                    }
                    textTotalBill.Text = sum.ToString();
                }
                catch
                { }

            }

            PanalClintsDay.Visible = true;
            //panel14.Visible = false;
            //panel10.Visible = false;
            //panel3.Visible = false;





            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridClientsDay.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGridClientsDay.Rows[i].Cells[4].Value);


                }
                textTotalTawred.Text = sum.ToString();
            }
            catch
            { }

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            int rowNumber1 = 0;
            foreach (DataGridViewRow row in dataGridClientsDay.Rows)
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

        private void panel3_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void Purchases_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBillingData1NumBill.Text == "")
            {

                saveEvents("تم غلق شاشة  " + TransferData.FormName);
            }
            else
            {
                if (txtMosadad.Text == "0" || txtMosadad.Text == "")
                {
                    dynamic result = MessageBox.Show("   لم يتم دفع اى  مبلغ فى خانة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ    ", "المسدد من الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //  Application.Exit();

                        saveEvents("تم غلق شاشة  " + TransferData.FormName);
                    }

                    if (result == DialogResult.No)
                    {
                        //do something else
                        //  this.FormClosing = false;

                        e.Cancel = true;

                        //  MessageBox.Show("   بقاء الشاشة مفتوحة  ", "المسدد من الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMosadad.Focus();
                    }


                }
                else
                {


                    saveEvents("تم غلق شاشة  " + TransferData.FormName);
                }
            }
        }

        private void butPrintautoss_Click(object sender, EventArgs e)
        {
            DirectPrint();
        }

        private void butClosePanel_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void label44_Click(object sender, EventArgs e)
        {
            if (textPriceNesfGomla.Visible == true)
            {
                textPriceNesfGomla.Visible = false;
                textPriceGomlaAlgomla.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
            }
            else if (textPriceNesfGomla.Visible == false)
            {
                textPriceNesfGomla.Visible = true;
                textPriceGomlaAlgomla.Visible = true;
                label34.Visible = true;
                label35.Visible = true;

            }
        }

        private void label38_Click(object sender, EventArgs e)
        {
            //CalculateSellingPrice();

        }

        private void CalculateSellingPrice()
        {
            //if (decimal.TryParse(textPriceSheraa.Text, out decimal purchasePrice) &&
            //    decimal.TryParse(textPriceAlgomlaProfitRate.Text, out decimal profitPercent))
            //{
            //    decimal sellingPrice = purchasePrice + (purchasePrice * profitPercent / 100);
            //    textPriceGomlaAlgomla.Text = sellingPrice.ToString("0"); // يعرض بسعر عشريتين
            //}
            //else
            //{
            //    textPriceGomlaAlgomla.Text = string.Empty;
            //}

            if (decimal.TryParse(textPriceSheraa.Text, out decimal purchasePrice))
            {
                // البيع العادي
                if (decimal.TryParse(textPriceKataeeProfitRate.Text, out decimal profitPercent))
                {
                    decimal sellingPrice = purchasePrice + (purchasePrice * profitPercent / 100);
                    //textPriceKatey.Text = sellingPrice.ToString("0.0");

                    textPriceKatey.Text = purchasePrice < 20
                ? sellingPrice.ToString("0.0")
                : sellingPrice.ToString("0");
                }

                // الجملة
                if (decimal.TryParse(textPriceAlgomlaProfitRate.Text, out decimal wholesalePercent))
                {
                    decimal wholesalePrice = purchasePrice + (purchasePrice * wholesalePercent / 100);
                    //textPriceGomla.Text = wholesalePrice.ToString("0.0");
                         textPriceGomla.Text = purchasePrice < 20
                        ? wholesalePrice.ToString("0.0")
                        : wholesalePrice.ToString("0");
                }

                // نصف الجملة
                if (decimal.TryParse(textPriceNesfAlgomlaProfitRate.Text, out decimal halfWholesalePercent))
                {
                    decimal halfWholesalePrice = purchasePrice + (purchasePrice * halfWholesalePercent / 100);
                    //textPriceNesfGomla.Text = halfWholesalePrice.ToString("0.0");
                                textPriceNesfGomla.Text = purchasePrice < 20
                       ? halfWholesalePrice.ToString("0.0")
                       : halfWholesalePrice.ToString("0");
                }

                // جملة الجملة
                if (decimal.TryParse(textPriceGomlaAlgomlaProfitRate.Text, out decimal bulkWholesalePercent))
                {
                    decimal bulkWholesalePrice = purchasePrice + (purchasePrice * bulkWholesalePercent / 100);
                    //textPriceGomlaAlgomla.Text = bulkWholesalePrice.ToString("0.0");

                    textPriceGomlaAlgomla.Text = purchasePrice < 20 ? bulkWholesalePrice.ToString("0.0"): bulkWholesalePrice.ToString("0");
                }
            }
            else
            {
                textPriceKatey.Text = string.Empty;
                textPriceGomla.Text = string.Empty;
                textPriceNesfGomla.Text = string.Empty;
                textPriceGomlaAlgomla.Text = string.Empty;
            }


        }

        private void butProfitPercent_Click(object sender, EventArgs e)
        {
            CalculateSellingPrice();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int x = label14.Location.X - 130;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 210;



           

            panelprofitPercent.Location = new Point(x, y);

            // panel6.Location = new Point(673, 94);
            this.panelprofitPercent.Size = new System.Drawing.Size(180, 180);


            panelprofitPercent.Visible = true;
        }

        private void textPriceAlgomlaProfitRate_TextChanged(object sender, EventArgs e)
        {
            CalculateSellingPrice();
        }

        private void textPriceGomlaAlgomlaProfitRate_TextChanged(object sender, EventArgs e)
        {
            CalculateSellingPrice();
        }

        private void textPriceNesfAlgomlaProfitRate_TextChanged(object sender, EventArgs e)
        {
            CalculateSellingPrice();
        }

        private void textPriceKataeeProfitRate_TextChanged(object sender, EventArgs e)
        {
            CalculateSellingPrice();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //// تحديد النسب الافتراضية
            //textPriceKataeeProfitRate.Text = "35";       // البيع العادي 30%
            //textPriceAlgomlaProfitRate.Text = "20";      // الجملة 15%
            //textPriceNesfAlgomlaProfitRate.Text = "25";  // نصف الجملة 20%
            //textPriceGomlaAlgomlaProfitRate.Text = "10";  // جملة الجملة 8%
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // تحديد النسب الافتراضية
            textPriceKataeeProfitRate.Text = "35";       // البيع العادي 30%
            textPriceAlgomlaProfitRate.Text = "20";      // الجملة 15%
            textPriceNesfAlgomlaProfitRate.Text = "25";  // نصف الجملة 20%
            textPriceGomlaAlgomlaProfitRate.Text = "10";  // جملة الجملة 8%
        }

        int rowindex;

        private void butUP_Click(object sender, EventArgs e)
        {
            try
            {
                rowindex = dataGridView2.SelectedCells[0].OwningRow.Index;
                DataRow row = dt2.NewRow();
                row[0] = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
                row[1] = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
                row[2] = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();
                row[3] = dataGridView2.Rows[rowindex].Cells[3].Value.ToString();
                row[4] = dataGridView2.Rows[rowindex].Cells[4].Value.ToString();
                row[5] = dataGridView2.Rows[rowindex].Cells[5].Value.ToString();
                row[6] = dataGridView2.Rows[rowindex].Cells[6].Value.ToString();
                row[7] = dataGridView2.Rows[rowindex].Cells[7].Value.ToString();

                if (rowindex > 0)
                {
                    dt2.Rows.RemoveAt(rowindex);
                    dt2.Rows.InsertAt(row, rowindex - 1);
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[rowindex - 1].Selected = true;
                }
        }
            catch
            { }
        }

        private void butDown_Click(object sender, EventArgs e)
        {
            try
            {
                rowindex = dataGridView2.SelectedCells[0].OwningRow.Index;
                DataRow row = dt2.NewRow();
                row[0] = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
                row[1] = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
                row[2] = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();
                row[3] = dataGridView2.Rows[rowindex].Cells[3].Value.ToString();
                row[4] = dataGridView2.Rows[rowindex].Cells[4].Value.ToString();
                row[5] = dataGridView2.Rows[rowindex].Cells[5].Value.ToString();
                row[6] = dataGridView2.Rows[rowindex].Cells[6].Value.ToString();
                row[7] = dataGridView2.Rows[rowindex].Cells[7].Value.ToString();

                if (rowindex < dataGridView2.Rows.Count - 2)
                {
                    dt2.Rows.RemoveAt(rowindex);
                    dt2.Rows.InsertAt(row, rowindex + 1);
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[rowindex + 1].Selected = true;
                }
            }
            catch
            { }
        }

        private void buttprofitPercentOpen_Click(object sender, EventArgs e)
        {
            if (panelprofitPercent.Visible == true)
            {
                panelprofitPercent.Visible = false;
            }
            else
            {
                int x = label14.Location.X - 130;  // وضع البداية بدلالة label14 وضع مكان الكود  
                int y = label14.Location.Y + 210;





                panelprofitPercent.Location = new Point(x, y);

                // panel6.Location = new Point(673, 94);
                this.panelprofitPercent.Size = new System.Drawing.Size(180, 180);


                panelprofitPercent.Visible = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible == true)
            {
                panelSettings.Visible = false;
            }
            else
            {
                panelSettings.Visible = true;


            }
        }

        private void butUpdateSeting_Click(object sender, EventArgs e)
        {
            PaperSizePrint = combPaperSize.Text;

            PrinterBill = combPrinters.Text;
        }
    }
}
