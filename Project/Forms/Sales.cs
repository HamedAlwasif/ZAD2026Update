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
using System.Drawing.Printing;
using System.IO;
using System.Media;



using ZAD_Sales.DAL;
using ZAD_Sales.ClassProject;




namespace ZAD_Sales.Forms
{
    public partial class Sales : Form
    {


        //protected override bool ProcessCmdKey(
        //ref Message msg,
        //Keys keyData)
        //{

        //    if (keyData == Keys.F9)
        //    {

        //        //MessageBox.Show("F9 works");
        //        if (keyData == Keys.F9)
        //        {

        //            DirectPrint();

        //            return true;

        //        }

        //        return true;

        //    }

        //    return base.ProcessCmdKey(
        //    ref msg,
        //    keyData);

        //}

        protected override bool ProcessCmdKey(
ref Message msg,
Keys keyData)
        {

            if (keyData == Keys.F9)
            {

                DirectPrint();

                return true;

            }

            return base.ProcessCmdKey(
            ref msg,
            keyData);

        }

        // if (File.Exists(Application.StartupPath.ToString() + "\\sound\\" + @"error.mp3"))
        //    {
        //        MessageBox.Show("Setup SQLEXPR2012_x64_ENU ");
        //        Process myProcess = new Process();
        //myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\SqlServer\\" + @"SQLEXPR2012_x64_ENU.exe";

        //        myProcess.Start();
        //        System.Threading.Thread.Sleep(1190);
        //        Properties.Settings.Default.Crystal = 2;
        //        Properties.Settings.Default.Save();
        //        Properties.Settings.Default.Upgrade();


        //    }

        // SoundPlayer SoundPlayer = new SoundPlayer(soundLocation: Application.StartupPath.ToString() + @"error.mp3");

        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        string LimitCredit = AppSetting.UseLimitCredit;
        string AllowUser = AppSetting.AllowUser;
        string DiscountBill = AppSetting.DiscountBill;
        string BarcodeSales = AppSetting.BarcodeSales;
        string BarcodeSalesType = AppSetting.BarcodeSalesType;

        string CollectionProduct = AppSetting.CollectionProduct;
        string HideBalance = AppSetting.HideBalance;

        string SystemPro = "";
        string RseedBox = "";
        string MoveBoxID = "";
        string NumBill = "";
        string ClintID = "";
        string TypeClint = "";
        string CreditorClint = "";

        string PriceGomla = "";
        string PriceMostahlek = "";


        string PriceGomlaAlgomla = "";
        string PriceNesfGomla = "";

        string FactionCatogrey = "";
        string CategoryID = "";
        string NumCategery = "";
        string TotalAndRemaninRasedClient = "0";
        string RasedBox = "";

        double Number_Sales = 0;
        string Selection_Category = "";

        string Number = "";

        string PrinterBill = "";
        string SizePaperBill = ""; // الافتراضى

        string PaperSizePrint = ""; // النهائى

        string TypeCurrency = "";

        string imageLogoUrl;

        string CompanyAddress = "";
        string CompanyPhone = "";
        string CompanyName = "";
        string NoteToBill = "";
         string Demo = "";


        string CompanyDescription = "";

        string Storage;

        int NumSnCategorey = 0;



        //-------------------------------
        DataTable dt1 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt18 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt8 = new DataTable();
        //---------------------------------
        private SqlDataReader red;
        private SqlDataReader rad;
        private SqlDataReader reed;
        private SqlDataReader read;
        private SqlDataReader reeeeed;
        private SqlDataReader rred;
        private SqlDataReader reeeed;
        private SqlDataReader readMoveBoxID;

        string currentMoveBoxID = "0";



        //---------------------------------
        ReportDataSource rs = new ReportDataSource();

        Sales Sales1;
        Installment Installment1;




        //============ خاص بطباعة الفواتير
        //public class InvoiceData
        //{

        //    public string CompanyName;

        //    public string Name;

        //    public string Date;

        //    public string Total;

        //    public string Sabek;

        //    public string Sabek1;

        //    public string Mosadad;

        //    public string Remaning;

        //    public string Discount;

        //    public string State;

        //    public string NumBill;

        //    public string Print;

        //    public string TypeBill;

        //    public string MoveBill;

        //    public string NoteToBill;

        //    public string CompanyDescription;

        //    public string CompanyAddress;

        //    public string CompanyPhone;

        //    public string ImageLogo;

        //    public string MosadadActual;

        //    public string ReturnValue;

        //    public string Demo;

        //    public string Note;

        //}

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

            data.UserPrint = textUser.Text;

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

            data.PaidAmountWords = textPaidAmountWords.Text;

            return data;

        }
        public Sales()
        {
            InitializeComponent();
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();

            //  cn.Open();
            sqlCommand1.Connection = cn;


            //-------- لتفعيل اختصار الزرار

            this.KeyPreview = true;

            this.KeyDown += Sales_KeyDown;
        }

        private void text_KeyPress(object sender, KeyPressEventArgs e) // - غلق كتابة الحروف وجعل الكتابة ارقام فقط
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        public void GetCategery()
        {
            //string[] listCategorey = new string[] { "صنية ميلامين الشريف", "صنية استيل الشريف", "", "طبق ميلاميت", "طبق استيل الشريف", "براد شاى استيل", "معالق استيل", "طقم ميلامين الصفوة", "شنطة معالق", "طقم سكاكين" };

        }
        public void ClosePanel()
        {
            panelBillDay.Visible = false;
            panelLastPrice.Visible = false;
            panelCilntData.Visible = false;
            panelDiscount.Visible = false;
            panel10.Visible = false;
            panel18.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel_SN.Visible = false;
            panelProfits.Visible = false;
            panelSettings.Visible = false;
            panel_PriceSheraa.Visible = false;
            panel17.Visible = false;

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
        public class Class_CategoreysBillCopy
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
        public class Class_BillDay
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string TotalBill { get; set; }
            public string Paid { get; set; }
            public string Remaining { get; set; }


        }
        public class Class_BillsClintSales
        {

            public string NumBill { get; set; }
            public string Date { get; set; }
            public string TotalBill { get; set; }



        }

        private void keys(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public class Class_Category_BestSeller
        {

            public string LastDate { get; set; }
            public string Category_Barcode { get; set; }
            public string Category { get; set; }

            public string Number_Sales { get; set; }
            public string Selection { get; set; }



        }

        private void GetDataClint()
        {
            //-------------- الفواتير ----------------------
            DataTable dt33 = new DataTable();
            dt33.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from BillingData where Name = '" + comClient.Text + "' and Move Like'" + FormName + "' ", cn);
            da11.Fill(dt33);
            this.dataGridView3.DataSource = dt33;


            //------------ايجاد الشيكات التى لم تصرف
            DataTable dt55 = new DataTable();
            dt55.Clear();
            SqlDataAdapter da55 = new SqlDataAdapter("Select NumSkeek,ValueSheek,DateElestehkak From SheekSave where Name ='" + comClient.Text + "' and TypeMove ='" + FormName + "' and State ='" + textBox71.Text + "' ", cn);
            da55.Fill(dt55);
            this.dataGridView1.DataSource = dt55;
            this.dataGridView1.Columns[0].HeaderText = "رقم الشيك";
            this.dataGridView1.Columns[1].HeaderText = "القيمه";
            this.dataGridView1.Columns[2].HeaderText = "التاريخ";

            this.dataGridView1.Columns[0].Width = 100;
            this.dataGridView1.Columns[1].Width = 80;
            this.dataGridView1.Columns[2].Width = 90;

            //  panel11.Visible = false;

            // **** إجمالى الشيكات التى لم تحصل
            string TotalSheek = "";
            int sumab = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                sumab += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);

            }
            TotalSheek = sumab.ToString();
            textBox72.Text = TotalSheek;

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);



        }
        private void button29_Click(object sender, EventArgs e)
        {
            //int x = label14.Location.X - 270;  // وضع البداية بدلالة label14 وضع مكان الكود  
            //int y = label14.Location.Y + 60;

            ////textBox8.Text = x.ToString();
            ////textBox7.Text = y.ToString();

            //panelCilntData.Location = new Point(x, y);

            //this.panelCilntData.Size = new System.Drawing.Size(326, 425);


            ////if (panel13.Visible == true)
            ////{
            ////    panelCilntData.Visible = false;
            ////    panel11.Visible = false;
            ////    panel13.Visible = false;
            ////    panel5.Visible = false;
            ////    //panel18.Visible = false;
            ////    //panel19.Visible = false;
            ////}
            ////else
            ////{
            ////    //panel10.Visible = false;
            ////    //panel14.Visible = false;
            ////    panelCilntData.Visible = true;
            ////    panel5.Visible = false;
            //// //   panel13.Visible = true;
            ////    panel11.Visible = false;

            ////}

            ////------------------------------------
            //DataTable dt33 = new DataTable();
            //dt33.Clear();
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from BillingData where Name = '" + comClient.Text + "' and Move Like'" + FormName + "' ", cn);
            //da11.Fill(dt33);
            //this.dataGridView3.DataSource = dt33;

            ////-----------------
            ////textBox73.Text = comClient.Text;
        }
        public void SystemProgram()
        {
            //------------------- البحث نظام العمل جملة او قطاعى -------------

            string Kataey = "";
            string GomKataey = "";

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
                SystemPro = "قطاعى";
                groupBox5.Visible = false;

                //comTypeBill.Text = "نقدى";

                textUnityBeea.Visible = false;


                ComTypeCategorey.Text = "قطعه";
                comClient.Text = "عميل نقدى";
                combCategorys.Focus();



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
                //comboBox1.SelectedIndex = comboBox1.Items.Count +0;

                // MessageBox.Show("  قطــــــــــــــاعى   ", "    خطأ   ");

            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";
                radBtPriceGomla.Checked = true;
                comClient.Focus();

                textUnityBeea.Visible = true;
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


                //  MessageBox.Show("  جمله وقطاعى   ", "    خطأ   ");




            }
            // نهاية البحث نظام العمل جملة او قطاعى
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
        private int GetMoveBoxOldBillID(int numBill)
        {

            //static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
            //SqlConnection cn = new SqlConnection(constring);

            int id = 0;


            string query = "SELECT ID FROM BoxMove WHERE NumBill = @NumBill";

            //using (SqlConnection con = new SqlConnection(cn))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@NumBill", numBill);

                // cn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    id = Convert.ToInt32(result);
            }

            return id;

        }

        //public void GetcurrentMoveBoxID()
        //{
        //    // الآن currentMoveBoxID جاهز لكل عمليات الضغط على الزر

        //    try
        //    {
        //        sqlCommand1.CommandText = "select * From BoxMove  Where ID =(select max(ID) from BoxMove) ";
        //        red = sqlCommand1.ExecuteReader();
        //        while (red.Read())
        //        {
        //            double s = Convert.ToDouble(red["ID"].ToString());
        //            double aa = s + 1;
        //            MoveBoxID = aa.ToString();

        //        }
        //        red.Close();

        //        if (MoveBoxID == "")
        //        {
        //            MoveBoxID = "1";
        //        }
        //        else
        //        { }


        //        // الآن currentMoveBoxID جاهز لكل عمليات الضغط على الزر

        //    }
        //    catch
        //    {
        //        MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
        //    }

        //    // textMoveBoxID.Text = MoveBoxID;

        //}

        public void GetMoveBoxID()
        {


            // الآن currentMoveBoxID جاهز لكل عمليات الضغط على الزر

            try
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

                TxtNumBox.Text = MoveBoxID;

                // الآن currentMoveBoxID جاهز لكل عمليات الضغط على الزر

            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            // textMoveBoxID.Text = MoveBoxID;

        }
        public void GetNumBill()
        {
            try
            {


                sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["NumBill"].ToString());
                    double aa = s + 1;
                    textBillingDataNumBill.Text = aa.ToString();


                }
                red.Close();

                if (textBillingDataNumBill.Text == "0")
                {
                    textBillingDataNumBill.Text = "1";
                }
                else
                { }

                NumBill = textBillingDataNumBill.Text;

            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات1111111111111111111   ", "    خطأ   ");
            }
        }
        public void GetNumBill2()
        {
            //try
            //{


            sqlCommand1.CommandText = "select * From BillingData2  Where NumBill =(select max(NumBill) from BillingData2) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["NumBill"].ToString());
                double aa = s + 1;
                textBillingDataNumBill.Text = aa.ToString();


            }
            red.Close();

            if (textBillingDataNumBill.Text == "")
            {
                textBillingDataNumBill.Text = "1";
            }
            else
            { }

            NumBill = textBillingDataNumBill.Text;

            //}
            //catch
            //{
            //    MessageBox.Show("  يوجد خطأ فى البيانات1111111111111111111   ", "    خطأ   ");
            //}
        }
        private void butShekaat_Click(object sender, EventArgs e)
        {
            //int x = label14.Location.X - 270;  // وضع البداية بدلالة label14 وضع مكان الكود  
            //int y = label14.Location.Y + 60;

            ////textBox8.Text = x.ToString();
            ////textBox7.Text = y.ToString();

            //panelCilntData.Location = new Point(x, y);

            //this.panelCilntData.Size = new System.Drawing.Size(326, 425);


            //string TotalSheek = "";
            //// panel11.Visible = true;
            //if (panel11.Visible == true)
            //{
            //    panel11.Visible = false;
            //   // panel13.Visible = false;
            //    panel5.Visible = false;
            //    panelCilntData.Visible = false;
            //    //panel19.Visible = false;
            //}
            //else
            //{
            //    //panel10.Visible = false;
            //    //panel14.Visible = false;
            //    panelCilntData.Visible = true;
            //    panel5.Visible = false;
            //  //  panel13.Visible = false;
            //    panel11.Visible = true;

            //}

            ////------------ايجاد الشيكات التى لم تصرف
            //DataTable dt55 = new DataTable();
            //dt55.Clear();
            //SqlDataAdapter da55 = new SqlDataAdapter("Select NumSkeek,ValueSheek,DateElestehkak From SheekSave where Name ='" + comClient.Text + "' and TypeMove ='" + FormName + "' and State ='" + textBox71.Text + "' ", cn);
            //da55.Fill(dt55);
            //this.dataGridView1.DataSource = dt55;
            //this.dataGridView1.Columns[0].HeaderText = "رقم الشيك";
            //this.dataGridView1.Columns[1].HeaderText = "القيمه";
            //this.dataGridView1.Columns[2].HeaderText = "التاريخ";

            //this.dataGridView1.Columns[0].Width = 100;
            //this.dataGridView1.Columns[1].Width = 80;
            //this.dataGridView1.Columns[2].Width = 90;

            ////  panel11.Visible = false;

            //// **** إجمالى الشيكات التى لم تحصل
            //int sumab = 0;
            //for (int i = 0; i < dataGridView1.RowCount; ++i)
            //{
            //    sumab += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);

            //}
            //TotalSheek = sumab.ToString();
            //textBox72.Text = TotalSheek;

            ////------------------- ترقيم الداتا جريد
            //int rowNumber = 1;
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.IsNewRow) continue;
            //    row.HeaderCell.Value = "" + rowNumber + "";
            //    rowNumber = rowNumber + 1;
            //}
            //dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            //if (TotalSheek == "0")
            //{
            //    textBox66.Visible = false;
            //    label19.Visible = false;
            //}
            //else
            //{
            //    textBox66.Visible = true;
            //    label19.Visible = true;
            //}
        }

        private void butDataClient_Click(object sender, EventArgs e)
        {
            //int x = label14.Location.X - 270;  // وضع البداية بدلالة label14 وضع مكان الكود  
            //int y = label14.Location.Y + 60;

            ////textBox8.Text = x.ToString();
            ////textBox7.Text = y.ToString();

            //panelCilntData.Location = new Point(x, y);

            //this.panelCilntData.Size = new System.Drawing.Size(326, 425);

            //if (panel5.Visible == true)
            //{
            //    panel11.Visible = false;
            //  //  panel13.Visible = false;
            //    panel5.Visible = false;
            //    panelCilntData.Visible = false;
            //    //panel19.Visible = false;
            //}
            //else
            //{
            //    //panel10.Visible = false;
            //    //panel14.Visible = false;
            //    panelCilntData.Visible = true;
            //  //  panel13.Visible = false;
            //    panel11.Visible = false;
            //    panel5.Visible = true;

            //}
            //butAddClint.Visible = false;
        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            //SqlDataAdapter Da21;
            //DataTable Dt21 = new DataTable();
            //Da21 = new SqlDataAdapter("select Category from Category where  Storage = '" + combStorage.Text + "' and Total > '" + 0 + "'", cn);
            //Da21.Fill(Dt21);
            //combCategorys.DataSource = Dt21;
            //combCategorys.DisplayMember = "Category";
            //-------------------------------------------------------
            //string connetionString = null;
            //SqlConnection connection;
            //SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            //connetionString = "Data Source=.;Initial Catalog=pubs;User ID=sa;password=zen412";
            string sql = "select Category from Category";
            //connection = new SqlConnection(connetionString);
            try
            {
                //connection.Open();
                sqlCommand1 = new SqlCommand(sql, cn);
                adapter.SelectCommand = sqlCommand1;
                adapter.Fill(ds);
                adapter.Dispose();
                sqlCommand1.Dispose();
                //cn.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch /*(Exception ex)*/
            {
                MessageBox.Show("Can not open connection ! ");
            }
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

            //using (SqlConnection tempcn = new SqlConnection(cn.ConnectionString))
            //{
            //    tempcn.Open();
            //    DataTable dt11 = new DataTable();
            //    SqlDataAdapter da11 = new SqlDataAdapter("select * from Category", tempcn);
            //    da11.Fill(dt11);
            //    this.dataGridSearchCategory.DataSource = dt11;
            //}


        }

        private void GetAllCategry_Quntety()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Category where  Storage = '" + Storage + "' and Total > '" + 0 + "' ", cn);
            da11.Fill(dt11);
            this.dataGridSearchCategory.DataSource = dt11;

        }

        private void GetCategory_BestSeller()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select TOP 20 * from Category_BestSeller order by Number_Sales desc ", cn);
            da11.Fill(dt11);
            this.dataGridCategory_BestSeller.DataSource = dt11;

            //-------------- الترتيب بالاكثر مبيعا  -------
            dataGridCategory_BestSeller.Sort(dataGridCategory_BestSeller.Columns[2], ListSortDirection.Descending);

        }
        private void GetAllCategry_BestSeller()
        {

            string month = "";
            double a = Convert.ToDouble(dateTimePicker1.Value.ToString("MM")) - 1;
            month = a.ToString();


            string Date1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            string Date2 = dateTimePicker1.Value.ToString(a + "/dd/yyyy");

            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing  where Date <='" + Date1 + "' and Date >='" + Date2 + "'", cn);
            da11.Fill(dt11);
            this.dataGridGetAllCategry_BestSeller.DataSource = dt11;

            //--------------- حذف المكرر فى الجدول
            var results = dataGridGetAllCategry_BestSeller
             .Rows
             .OfType<DataGridViewRow>()
             .GroupBy(x => new { x.Cells[1].Value })
             .Select(group => new { Item = group.Key, Row = group, Count = group.Count() })
             .ToList();


            for (var index = 0; index < results.Count; index++)
            {
                Console.WriteLine(results[index].Row.FirstOrDefault()?.Cells[1].Value);
                results[index].Row.Skip(1).ToList().ForEach(row => dataGridGetAllCategry_BestSeller.Rows.Remove(row));
            }

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

            //========================== ========================== ========================== textMoveBill  labelMoveBill
        }

        //======================== دوال خاصة بالطباعه المباشرة
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
        private string GetReportPath(string paperSize)
        {
            switch (paperSize)
            {
                case "A4":
                    return @"Reports\ReportBillingA4.rdlc";

                case "A5":
                    return @"Reports\ReportBillingA5.rdlc";

                case "B5":
                    return @"Reports\ReportBillingB5.rdlc";

                case "Cashier 6":
                    return @"Reports\ReportBillingCasher.rdlc";

                case "Cashier 8":
                    return @"Reports\ReportBillingCasher_8cm_NoDis.rdlc";

                case "Cashier 8 Disc":
                    return @"Reports\ReportBillingCasher_8cm.rdlc";

                default:
                    return @"Reports\ReportBillingA4.rdlc";
            }
        }

        //======================== نهاية الدوال خاصة بالطباعه المباشرة

        //=======  دالة لجلب قيمه من جدول فى كمبوبوكس


        private void FillComboBox(ComboBox combo, string query, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
            {
                if (parameters != null)
                    da.SelectCommand.Parameters.AddRange(parameters);

                DataTable dt = new DataTable();
                da.Fill(dt);

                combo.DataSource = dt;
                combo.DisplayMember = dt.Columns[0].ColumnName; // أول عمود تلقائي
                combo.SelectedIndex = -1;
                combo.IntegralHeight = false;
                combo.DropDownHeight = 200;
            }
        }


        //private void FillComboBox(ComboBox combo,string tableName,string fieldName)
        //{



        //    string query = $"SELECT {fieldName} FROM {tableName}";

        //    using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
        //    {
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        combo.DataSource = dt;
        //        combo.DisplayMember = fieldName;
        //        combo.SelectedIndex = -1; // بدون اختيار افتراضي
        //    }
        //}

        //private void FillComboBoxByQuery(ComboBox combo, string query)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter(query, cn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    combo.DataSource = null;          // مهم
        //    combo.DisplayMember = null;

        //    combo.DataSource = dt;
        //    combo.DisplayMember = dt.Columns[0].ColumnName;

        //    // --- لو عاوز الكمبوبوكس يظهر فارغ  لا يعرض اول عنصر فعل السطر 
        //   // combo.SelectedIndex = -1;
        //}

        private void FillComboBoxByQuery(ComboBox combo, string query, bool selectFirstItem)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            combo.DataSource = null;
            combo.DisplayMember = null;

            combo.DataSource = dt;
            combo.DisplayMember = dt.Columns[0].ColumnName;

            if (selectFirstItem && dt.Rows.Count > 0)
                combo.SelectedIndex = 0;
        }

        void InitDefaultSelections()
        {

            // Paper size
            if (combPaperSize.Items.Contains(
            PaperSizePrint))
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

        private void Sales_Load(object sender, EventArgs e)
        {
            //---------- ايجاد الطابعه الافتراضية وحجم الورقة -----

            SizePaperBill = AppSetting.SizePaperBill;

            PaperSizePrint = AppSetting.SizePaperBill;

            PrinterBill = AppSetting.PrinterBill;

            LoadPaperSizes();

            LoadPrinters();

            InitDefaultSelections();


            //- لاكتشاف التقارير الناقصة 
            ReportEngine.ValidateReports();

            //
            
            reportViewer1.Visible = false;

            imageLogoUrl = AppSetting.Comp_Logo;


           // MessageBox.Show(" PaperSizePrint =   " + PaperSizePrint + " -------  PrinterBill =   " + PrinterBill, "ملحوظة ");

           // MessageBox.Show(" SizePaperBill =   " + SizePaperBill + " PaperSizePrint =   " + PaperSizePrint + " PrinterBill =   " + PrinterBill, "خطأ");



            //if (SizePaperBill == "A4")
            //{
            //    PaperSizePrint = "A4 فاتورة";

            //}
            //else if (SizePaperBill == "A5")
            //{


            //    PaperSizePrint = "A5 فاتورة";

            //}
            //else if (SizePaperBill == "B5")
            //{
            //    PaperSizePrint = "B5 فاتورة";

            //}
            //else if (SizePaperBill == "A5 - Discount")
            //{
            //    PaperSizePrint = "A5 فاتورة بخصم";
            //}
            //else if (SizePaperBill == "Casher 6 mm")
            //{
            //    PaperSizePrint = "كاشير 6 سم";


            //}
            //else if (SizePaperBill == "Casher 8 mm")
            //{
            //    PaperSizePrint = "كاشير 8 سم";

            //}

            //else if (SizePaperBill == "Casher 8 mm No Discount")
            //{

            //    PaperSizePrint = "كاشير 8 سم بدون خصم";

            //}
            //else if (SizePaperBill == "A4 List")
            //{

            //    PaperSizePrint = "A4 بيان بدون اسعار";

            //}
            //else if (SizePaperBill == "A5 List")
            //{

            //    PaperSizePrint = "A5 بيان بدون اسعار";

            //}
            //else
            //{
            //    MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
            //}

            //  MessageBox.Show(" SizePaperBill =   " + SizePaperBill + " PaperSizePrint =   " + PaperSizePrint + " PrinterBill =   " + PrinterBill, "خطأ");


            CompanyName = AppSetting.textCompany_Name;
            CompanyAddress = AppSetting.textCompany_Address;
            CompanyDescription = AppSetting.textCompany_Description;
            CompanyPhone = AppSetting.textCompany_Phone;
            NoteToBill = AppSetting.NoteToBill;
            Demo = AppSetting.DemoOnBill;


            comTypeBill.Text = AppSetting.TypeBillDefoult;

            //========= نهاية طباعه الفواتير النظام الجديد


            //------------- رصيد الصندوق
            decimal boxBalance = CashBoxHelper.GetCurrentBoxBalance();
            txtBoxRemining.Text = boxBalance.ToString("N2");



            // textBox7.Text = button10.Location.Y.ToString();

            if (AllowUser == "1") // الصلاحيات الخاصة الداخلية
            {
                butProfit.Visible = true; // اظهار زر ارباح الفاتورة
                //---------------------------
                label6.Visible = true;  // اظهار كلمة الصنف المفعلة
                label57.Visible = false;  // اخفاء كلمة الصنف الغير مفعلة
                //---------------------------
                //--------- رصيد ورقم الصندوق
                TxtNumBox.Visible = true;
                txtBoxRemining.Visible = true;
                label69.Visible = true;
                label70.Visible = true;


                button12.Visible = true; // اظهار زر تعديل التاريخ

                if (FormName == "مردودات مشتريات")
                {
                    butProfit.Visible = false;// اخفاء زر ارباح الفاتورة

                    label57.Visible = true; // اظهار كلمة الصنف الغير مفعلة
                    label6.Visible = false; // // اخفاء كلمة الصنف المفعلة

                    button12.Visible = false; // اخفاء زر تعديل التاريخ
                }
            }

            else
            {

                butProfit.Visible = false;// اخفاء زر ارباح الفاتورة

                label57.Visible = true; // اظهار كلمة الصنف الغير مفعلة
                label6.Visible = false; // // اخفاء كلمة الصنف المفعلة

                button12.Visible = false; // اخفاء زر تعديل التاريخ

                //--------- رصيد ورقم الصندوق
                TxtNumBox.Visible = false;
                txtBoxRemining.Visible = false;
                label69.Visible = false;
                label70.Visible = false;

            }

            if (BarcodeSales == "1") // الصلاحيات الخاصة الداخلية
            {
                chBoxBarcode.Checked = true;
                textBarcode.Focus();
            }
            else
            {
                chBoxBarcode.Checked = false;
            }

            if (BarcodeSalesType == "1") // الصلاحيات الخاصة الداخلية
            {
                radioB_Program.Checked = true;
            }
            else
            {
                radioB_Factory.Checked = true;
            }

            if (CollectionProduct == "1") // الصلاحيات الخاصة الداخلية
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }

            if (HideBalance == "1") // الصلاحيات الخاصة الداخلية
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }

            //==========================  تسجيل الحركات  ========================== 

            saveEvents("تم فتح شاشة  " + TransferData.FormName);

            //========================== ========================== =================

            if (FormName == "فاتورة مبيعات غير معتمدة") // فاتورة غير معتمدة
            {
                butAddCategorey.Visible = false;
                butAdd3.Visible = true;

            }
            else
            {


                butAddCategorey.Visible = true;
                butAdd3.Visible = false;
            }

           



            //------------------  اظهار الاسعار جملة الجملة ونصف الجملة-----------------

            string PricesAllShow = AppSetting.PricesAll; // --- اظهار الاسعار جملة الجملة ونصف الجملة

            if (PricesAllShow == "1")
            {
                radBtPriceGomlaAlgomla.Visible = true;
                radBtPriceNesfGomla.Visible = true;
            }
            else
            {
                radBtPriceGomlaAlgomla.Visible = false;
                radBtPriceNesfGomla.Visible = false;
            }



            //-------------- Report
            panel18.Visible = false;

            //---------------------------------
           

            SystemProgram();


            GetMoveBoxID();

            GetAllCategry();
            GetAllClintes();

            textMoveBill.Text = FormName;
            labelMoveBill.Text = FormName;
            textUser.Text = UserName;

            textMoveBill.Text = comMoveBill.Text;


            //----------------- ايجاد العملاء --------------------

            //SqlDataAdapter Da1;
            //DataTable Dt1 = new DataTable();
            //Da1 = new SqlDataAdapter("select Name from Clients", cn);
            //Da1.Fill(Dt1);
            //comClient.DataSource = Dt1;
            //comClient.DisplayMember = "Name";

            //cn.Close();


            string query1 = "select Name from Clients";

            FillComboBoxByQuery(comClient, query1, true);


            //----------------- ايجاد المخزن --------------------


            //============= الكود القديم  ===========

            //SqlDataAdapter Da11;
            //DataTable Dt11 = new DataTable();
            //Da11 = new SqlDataAdapter("select Storage from Storage", cn);
            //Da11.Fill(Dt11);
            //combStorage.DataSource = Dt11;
            //combStorage.DisplayMember = "Storage";


            //=======  الكود المعدل =========================
            //===== ملاحظة: سيتم استبدال الاستعلام المُعَلم في الإصدار القادم الأمان =====

            string query = "select Storage from Storage";

            FillComboBoxByQuery(combStorage, query, true);

            //=====================================

            //-----------------   ايجاد الاصناف الموجودة فقط --------------------
            SqlDataAdapter Da122;
            DataTable Dt122 = new DataTable();
            Da122 = new SqlDataAdapter("select Category from Category where  Storage = '" + combStorage.Text + "' and Total > '" + 0 + "'", cn);
            Da122.Fill(Dt122);
            combCategorys.DataSource = Dt122;
            combCategorys.DisplayMember = "Category";

            comboBox1.DataSource = Dt122;
            comboBox1.DisplayMember = "Category";


            // ملاحظة: سيتم استبدال الاستعلام المُعَلم في الإصدار القادم الأمان

            //string query = "select Category from Category  where  Storage = '" + combStorage.Text + "' and Total > '" + 0 + "'";

            //FillComboBoxByQuery(combCategorys, query);



            //-----------------------   إيجاد رصيد المخزن --------------------


            //if (cn.State == System.Data.ConnectionState.Closed)
            //    cn.Open();

            //string query = "SELECT * FROM TreasuryRemaning WHERE ID = @ID";

            //using (SqlCommand sqlCommand1 = new SqlCommand(query, cn))
            //{
            //    sqlCommand1.Parameters.AddWithValue("@ID", 1);

            //    using (SqlDataReader rred = sqlCommand1.ExecuteReader())
            //    {
            //        while (rred.Read())
            //        {
            //            RasedBox = rred["RemaningTreasury"].ToString();
            //        }
            //    }
            //}


            //----------------- ايجاد المجموعات --------------------
            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select GroupName from Groups", cn);
                Da2.Fill(Dt2);
                comClintGroup.DataSource = Dt2;
                comClintGroup.DisplayMember = "GroupName";

            }
            catch
            {

            }

            //------------- مفتوحة من كشف الحساب
            string NumBillFromAcount = TransferData.NumBillFromAcount;
            if (NumBillFromAcount != "")
            {
                textBillingDataNumBill.Text = NumBillFromAcount;
                GetBill();
            }
            else
            { }


            // افترض أن cn هي SqlConnection معرفة مسبقًا، سنستخدمها فقط للحصول على connection string

            //// تحميل العملاء
            //using (var connection = new SqlConnection(cn.ConnectionString))
            //{
            //    connection.Open();
            //    using (var da = new SqlDataAdapter("SELECT Name FROM Clients", connection))
            //    {
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        comClient.DataSource = dt;
            //        comClient.DisplayMember = "Name";
            //    }
            //}

            //// تحميل المخازن
            //using (var connection = new SqlConnection(cn.ConnectionString))
            //{
            //    connection.Open();
            //    using (var da = new SqlDataAdapter("SELECT Storage FROM Storage", connection))
            //    {
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        combStorage.DataSource = dt;
            //        combStorage.DisplayMember = "Storage";
            //    }
            //}

            //// تحميل الأصناف الموجودة فقط (مع باراميتر)
            //using (var connection = new SqlConnection(cn.ConnectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT Category FROM Category WHERE Storage = @Storage AND Total > 0";

            //    using (var da = new SqlDataAdapter(query, connection))
            //    {
            //        da.SelectCommand.Parameters.AddWithValue("@Storage", Storage);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        combCategorys.DataSource = dt;
            //        combCategorys.DisplayMember = "Category";

            //        comboBox1.DataSource = dt;
            //        comboBox1.DisplayMember = "Category";
            //    }
            //}

            //// إيجاد رصيد المخزن
            //string RasedBox = string.Empty;

            //using (var connection = new SqlConnection(cn.ConnectionString))
            //{
            //    connection.Open();
            //    string query = "SELECT RemaningTreasury FROM TreasuryRemaning WHERE ID = @ID";
            //    using (var cmd = new SqlCommand(query, connection))
            //    {
            //        cmd.Parameters.AddWithValue("@ID", 1);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                RasedBox = reader["RemaningTreasury"].ToString();
            //            }
            //        }
            //    }
            //}

            //// إيجاد المجموعات
            //try
            //{
            //    using (var connection = new SqlConnection(cn.ConnectionString))
            //    {
            //        connection.Open();
            //        using (var da = new SqlDataAdapter("SELECT GroupName FROM Groups", connection))
            //        {
            //            DataTable dt = new DataTable();
            //            da.Fill(dt);
            //            comClintGroup.DataSource = dt;
            //            comClintGroup.DisplayMember = "GroupName";
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // يمكن تسجيل الخطأ أو معالجته هنا
            //    MessageBox.Show("حدث خطأ أثناء تحميل المجموعات: " + ex.Message);
            //}

            //// التعامل مع بيانات كشف الحساب
            //string NumBillFromAcount = TransferData.NumBillFromAcount;
            //if (!string.IsNullOrEmpty(NumBillFromAcount))
            //{
            //    textBillingDataNumBill.Text = NumBillFromAcount;
            //    GetBill();
            //}


        }
        public void CountRemaining()
        {
            try
            {
                double a = Convert.ToDouble(txtDic.Text);
                double b = Convert.ToDouble(txtMosadad.Text);
                double c = Convert.ToDouble(txtAdd.Text);
                double d = Convert.ToDouble(txtRemaningOld.Text);
                double f = Convert.ToDouble(txtTotalBill.Text);


                double r = (c + d + f) - (a + b);
                // txtRemainingNow.Text = r.ToString();
                txtRemainingNow.Text = Math.Round(double.Parse(r.ToString()), 2).ToString();
            }
            catch
            {

            }





        }
        private void AddingBilling_Yadaey()
        {

            //string Quantity = "";
            //string TotalCategoryValue = "";
            //string NumCategorey = "";
            //if (checkBox2.Checked == true) //---- تجميع الاصناف المتشابهه
            //{
            //    //------------------- ايجاد كمية الصنف اذا كان مضاف من قبل ----
            //    string QuntityOLD = "0";
            //    string TotalCategory = "0";
            //    string TypeCategorey = "";
            //    try
            //    {
            //        sqlCommand1.CommandText = "select Quantity,Type,Num from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and CategoryID = '" + CategoryID + "'";
            //        read = sqlCommand1.ExecuteReader();
            //        while (read.Read())
            //        {

            //            QuntityOLD = read["Quantity"].ToString();
            //            TypeCategorey = read["Type"].ToString();
            //            NumCategorey = read["Num"].ToString();


            //        }
            //        read.Close();
            //    }
            //    catch
            //    { }

            //    if (ComTypeCategorey.Text == TypeCategorey) //---- نوع الصنف كرتونة او قطعه متشابهه
            //    {
            //        //----------- حذف الصنف من الفاتورة
            //        sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and CategoryID = '" + CategoryID + "' and Num = '" + NumCategorey + "' ";
            //        sqlCommand1.ExecuteNonQuery();

            //        //---------- حساب سعر الكميه المطلوبه مع الكمية القديمة للصنف ان وجد ---

            //        double nn = Convert.ToDouble(textQuntity.Text) + Convert.ToDouble(QuntityOLD);
            //        double dd = Convert.ToDouble(textPrice.Text);
            //        double mm = Convert.ToDouble(textDiscCategorey.Text);
            //        double rr = (nn * dd) - (nn * mm);
            //        TotalCategory = Math.Round(double.Parse(rr.ToString()), 2).ToString();
            //        TotalCategoryValue = TotalCategory;

            //        //---------- حساب سعر الكميه المطلوبه  ---

            //        double nn1 = Convert.ToDouble(textQuntity.Text);
            //        double rr1 = (nn1 * dd) - (nn * mm);
            //        txtTotalCategory.Text = Math.Round(double.Parse(rr1.ToString()), 2).ToString();

            //        //----- كمية الصنف بالاضافة للكمية القديمة
            //        double sum = Convert.ToDouble(textQuntity.Text) + Convert.ToDouble(QuntityOLD); //اضفنا القيمة القديمة ان كان اخدها قبل كده فى نفس الفاتورة
            //        Quantity = sum.ToString();



            //    }
            //    else
            //    {
            //        //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

            //        double nn = Convert.ToDouble(textQuntity.Text);
            //        double dd = Convert.ToDouble(textPrice.Text);
            //        double mm = Convert.ToDouble(textDiscCategorey.Text);
            //        double rr = (nn * dd) - (nn * mm);

            //        txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
            //        TotalCategoryValue = txtTotalCategory.Text;
            //        //----- كمية الصنف بدون للكمية القديمة
            //        Quantity = nn.ToString();

            //        //===================== حساب رقم الصنف
            //        double nnn = Convert.ToDouble(TxtNumCategorey.Text);
            //        double rrr = nnn + 1;
            //        textBox26.Text = rrr.ToString();
            //        NumCategorey = textBox26.Text;
            //    }
            //}

            //else //------ لا تجمع الاصناف المتشابهه
            //{
            //    //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

            //    double nn = Convert.ToDouble(textQuntity.Text);
            //    double dd = Convert.ToDouble(textPrice.Text);
            //    double mm = Convert.ToDouble(textDiscCategorey.Text);
            //    double rr = (nn * dd) - (nn * mm);

            //    txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
            //    TotalCategoryValue = txtTotalCategory.Text;
            //    //----- كمية الصنف بدون للكمية القديمة
            //    Quantity = nn.ToString();

            //    //===================== حساب رقم الصنف
            //    double nnn = Convert.ToDouble(TxtNumCategorey.Text);
            //    double rrr = nnn + 1;
            //    textBox26.Text = rrr.ToString();
            //    NumCategorey = textBox26.Text;

            //}
            ////----------------------------------------------------------------

            //// حساب سعر الشراء الكميه المطلوبه
            //try
            //{
            //    double nn = Convert.ToDouble(textQuntity.Text);
            //    double dd = Convert.ToDouble(textPriceSH.Text);
            //    double rr = nn * dd;
            //    textBox46.Text = rr.ToString();

            //}

            //catch (FormatException)
            //{
            //    textPriceSH.Text = "0";
            //    textBox46.Text = "0";
            //    MessageBox.Show("يجب إدخال الكميه المطلوبه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            ////===================== حساب ربح الصنف
            //string ValueTotal = "0";
            ////try
            ////{
            //double nar = Convert.ToDouble(txtTotalCategory.Text);
            //double dar = Convert.ToDouble(textBox46.Text);
            //double rad = nar - dar;
            //textBox47.Text = rad.ToString();

            ////===================== طرح الكميه من الكميه الكليه

            //double nr = Convert.ToDouble(textBox21.Text);
            //double dr = Convert.ToDouble(textBox69.Text);
            //double rd = nr - dr;
            //textBox21.Text = rd.ToString();
            //textBox21.Text = Math.Round(double.Parse(textBox21.Text), 2).ToString();




            ////===================== معرفة كمية الاجمالى بعد الخصم

            //double jjs = Convert.ToDouble(textBox21.Text);
            //double jsj = Convert.ToDouble(textBox19.Text); // -- الفئه
            //double sjj = jjs % jsj;            // باقى القسمه
            //textBox64.Text = sjj.ToString();
            //textBox64.Text = Math.Round(double.Parse(textBox64.Text), 2).ToString();

            ////===================== حساب قيمة الاجمالى
            //double nnnn = Convert.ToDouble(textBox21.Text);
            //double dddd = Convert.ToDouble(textPriceShraa.Text); //--- سعر الشراء
            //double rrrr = nnnn * dddd;
            //ValueTotal = rrrr.ToString();

            ////=====================  حساب قيمة القطع
            //double na = Convert.ToDouble(textBox21.Text); // ---  الاجمالى
            //double da = Convert.ToDouble(textBox64.Text); //---- الكمية ق
            //double ca = Convert.ToDouble(textBox19.Text); // ---- الفئه
            //double ra = (na - da) / ca;

            //textBox18.Text = ra.ToString(); //---- الكمية ق
            //textBox18.Text = Math.Round(double.Parse(textBox18.Text), 0).ToString();


            ////}
            ////catch
            ////{ }

            ////=====================نحدث البيانات علشان الكميه الجديده

            //try
            //{
            //    sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',QuantityT='" + textBox64.Text + "',Total = '" + textBox21.Text + "',Price = '" + textPriceShraa.Text + "',Value = '" + ValueTotal + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + Storage + "' ";
            //    sqlCommand1.ExecuteNonQuery();
            //    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
            //}
            //catch
            //{
            //    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            //}



            //===================== اضافة الصنف فى الفاتورة

            string Quantity = "1";
            // string TotalCategoryValue = "1";
            string NumCategorey = "";
            string CategoryID11 = "0";

            //===================== حساب رقم الصنف
            double nnn = Convert.ToDouble(TxtNumCategorey.Text);
            double rrr = nnn + 1;
            textBox26.Text = rrr.ToString();
            NumCategorey = textBox26.Text;

            sqlCommand1.CommandText = "insert into Billing (NumBill,Num,ClinentID,ClientName,CategoryID,Storage,Category,Date,Quantity,Type,Price,Discount,Total,CategorySN)values ('" + textBillingDataNumBill.Text + "','" + NumCategorey + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + CategoryID11 + "','" + Storage + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Quantity + "','" + ComTypeCategorey.Text + "','" + textPrice.Text + "','" + textDiscCategorey1.Text + "','" + txtTotalCategory.Text + "','" + textCategoreySN.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== ايجاد الاصناف فى الفاتورة
            dt2.Clear();
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            SqlDataAdapter da11 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);

            da11.Fill(dt2);

            this.dataGridView2.DataSource = dt2;
            //-------------------------------------------------------------------------
            //------------------- ترقيم الداتا جريد
            //int rowNumber = 1;
            //int rowNumber1 = 0;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    //if (row.IsNewRow) continue;
            //    //row.HeaderCell.Value = "" + rowNumber + "";
            //    //rowNumber = rowNumber + 1;

            //    rowNumber1 = rowNumber1 + 1;
            //}
            ////dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            ////عدد الفواتير
            //TxtNumCategorey.Text = rowNumber1.ToString();

            //===================== حساب إجمالى الفاتورة عدد الاصناف
            int rowNumber1 = 0;

            double sum1 = 0;
            double sumQuentity = 0;
            for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
            {
                sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                sumQuentity += Convert.ToDouble(dataGridView2.Rows[s].Cells[3].Value);
                rowNumber1 = rowNumber1 + 1;

            }

            txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();

            TxtNumQuentity.Text = Math.Round(double.Parse(sumQuentity.ToString()), 0).ToString();


            TxtNumCategorey.Text = rowNumber1.ToString();

            //-------------------------------------------------------------------------

            //------------------------- العميل النقدى -------------------

            if (comTypeBill.Text == "نقدى")
            {
                txtMosadad.Text = txtTotalBill.Text;
            }
            else
            {

            }

            //===================== حساب المتبقى والتحديث

            CountRemaining();

            // button13.PerformClick();






            //===================== إضافة بيانات الفاتورة
            if (FormName == "فاتورة مبيعات")
            {

                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,TypeBill,NamePrint,NameMandop,PreviousBalance,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,NumberCategory,TotalBillBuyInvalid,State)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textClientGroup.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comTypeBill.Text + "','" + textUser.Text + "','" + textBox57.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + 0 + "','" + txtTotalBill.Text + "','" + 0 + "','" + txtDic.Text + "','" + textBox12.Text + "','" + txtAdd.Text + "','" + textBox14.Text + "','" + TotalAndRemaninRasedClient + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + TxtNumCategorey.Text + "','" + 0 + "','" + textNoteBill.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

            }
            else if (FormName == "مردودات مشتريات")
            {

                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,TypeBill,NamePrint,NameMandop,PreviousBalance,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,NumberCategory,TotalBillBuyInvalid,State)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textClientGroup.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comTypeBill.Text + "','" + textUser.Text + "','" + textBox57.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtDic.Text + "','" + textBox12.Text + "','" + txtAdd.Text + "','" + textBox14.Text + "','" + TotalAndRemaninRasedClient + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + TxtNumCategorey.Text + "','" + txtTotalBill.Text + "','" + textNoteBill.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , NumberCategory ='" + TxtNumCategorey.Text + "', State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

            }

            //-------------------------------------------------------------------------



            //===================== إضافة أرباح اليوم

            sqlCommand1.CommandText = "insert into Profit (NumBill,Date,Category,Num,Quantity,Type,PriceShraa,PriceBeaa,Profit)values ('" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorys.Text + "','" + NumCategorey + "','" + textQuntityProfit.Text + "','" + textBox20.Text + "','" + textBox46.Text + "','" + txtTotalCategory.Text + "','" + textBox47.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== إضافة حركة الصنف 
            sqlCommand1.CommandText = "insert into CategoryMove (Category,Num,Storage,IDBill,Clients,Date,Move,Alwared,FactionAlwared,PriceSH,ValueAlwared,Alsader,FactionAlsader,PriceB,valueAlsader,Balancek,BalanceT)values ('" + combCategorys.Text + "','" + NumCategorey + "','" + Storage + "','" + textBillingDataNumBill.Text + "','" + comClient.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + 0 + "','" + ComTypeCategorey.Text + "','" + 0 + "','" + 0 + "','" + textQuntity.Text + "','" + ComTypeCategorey.Text + "','" + textPrice.Text + "','" + txtTotalCategory.Text + "','" + textBox18.Text + "','" + textBox21.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== إضافة حركة الصنف الجديده 
            sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Num,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorys.Text + "','" + NumCategorey + "','" + Storage + "','" + Storage + "','" + comClient.Text + "','" + FormName + "','" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + 0 + "','" + textQuntityProfit.Text + "','" + textQuntityProfit.Text + "','" + textBox21.Text + "','" + textUser.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== تعديل الرصيد فى جدول العملاء
            try
            {
                sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show(" pleas correct the data");
            }


            //----------  إضافة حركة الصندوق

            // -----   جلب دالة اضافة المسدد الى الرصيد فى الصندوق

            AddOrUpdateBoxMove();

            //============ القديم

            //try
            //{
            //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
            //    sqlCommand1.ExecuteNonQuery();
            //}
            //catch
            //{
            //    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
            //    sqlCommand1.ExecuteNonQuery();
            //}



            combCategorys.Focus();
        }
        private void AddingBilling()
        {

            string Quantity = "";
            string TotalCategoryValue = "";
            string NumCategorey = "";
            if (checkBox2.Checked == true) //---- تجميع الاصناف المتشابهه
            {
                //------------------- ايجاد كمية الصنف اذا كان مضاف من قبل ----
                string QuntityOLD = "0";
                string TotalCategory = "0";
                string TypeCategorey = "";
                try
                {
                    sqlCommand1.CommandText = "select Quantity,Type,Num from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and CategoryID = '" + CategoryID + "'";
                    read = sqlCommand1.ExecuteReader();
                    while (read.Read())
                    {

                        QuntityOLD = read["Quantity"].ToString();
                        TypeCategorey = read["Type"].ToString();
                        NumCategorey = read["Num"].ToString();


                    }
                    read.Close();
                }
                catch
                { }

                if (ComTypeCategorey.Text == TypeCategorey) //---- نوع الصنف كرتونة او قطعه متشابهه
                {
                    //----------- حذف الصنف من الفاتورة
                    sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and CategoryID = '" + CategoryID + "' and Num = '" + NumCategorey + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //---------- حساب سعر الكميه المطلوبه مع الكمية القديمة للصنف ان وجد ---

                    double nn = Convert.ToDouble(textQuntity.Text) + Convert.ToDouble(QuntityOLD);
                    double dd = Convert.ToDouble(textPrice.Text);
                    double mm = Convert.ToDouble(textDiscCategorey.Text);
                    double rr = (nn * dd) - (nn * mm);
                    TotalCategory = Math.Round(double.Parse(rr.ToString()), 2).ToString();
                    TotalCategoryValue = TotalCategory;

                    //---------- حساب سعر الكميه المطلوبه  ---

                    double nn1 = Convert.ToDouble(textQuntity.Text);
                    double rr1 = (nn1 * dd) - (nn * mm);
                    txtTotalCategory.Text = Math.Round(double.Parse(rr1.ToString()), 2).ToString();

                    //----- كمية الصنف بالاضافة للكمية القديمة
                    double sum = Convert.ToDouble(textQuntity.Text) + Convert.ToDouble(QuntityOLD); //اضفنا القيمة القديمة ان كان اخدها قبل كده فى نفس الفاتورة
                    Quantity = sum.ToString();



                }
                else
                {
                    //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                    double nn = Convert.ToDouble(textQuntity.Text);
                    double dd = Convert.ToDouble(textPrice.Text);
                    double mm = Convert.ToDouble(textDiscCategorey.Text);
                    double rr = (nn * dd) - (nn * mm);

                    txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
                    TotalCategoryValue = txtTotalCategory.Text;
                    //----- كمية الصنف بدون للكمية القديمة
                    Quantity = nn.ToString();

                    //===================== حساب رقم الصنف
                    double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                    double rrr = nnn + 1;
                    textBox26.Text = rrr.ToString();
                    NumCategorey = textBox26.Text;
                }
            }

            else //------ لا تجمع الاصناف المتشابهه
            {
                //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPrice.Text);
                double mm = Convert.ToDouble(textDiscCategorey.Text);
                double rr = (nn * dd) - (nn * mm);

                txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
                TotalCategoryValue = txtTotalCategory.Text;
                //----- كمية الصنف بدون للكمية القديمة
                Quantity = nn.ToString();

                //===================== حساب رقم الصنف
                double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                double rrr = nnn + 1;
                textBox26.Text = rrr.ToString();
                NumCategorey = textBox26.Text;

            }
            //----------------------------------------------------------------

            // حساب سعر الشراء الكميه المطلوبه
            try
            {
                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPriceSH.Text);
                double rr = nn * dd;
                textBox46.Text = rr.ToString();

            }

            catch (FormatException)
            {
                textPriceSH.Text = "0";
                textBox46.Text = "0";
                MessageBox.Show("يجب إدخال الكميه المطلوبه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //===================== حساب ربح الصنف
            string ValueTotal = "0";
            //try
            //{
            double nar = Convert.ToDouble(txtTotalCategory.Text);
            double dar = Convert.ToDouble(textBox46.Text);
            double rad = nar - dar;
            textBox47.Text = rad.ToString();

            //===================== طرح الكميه من الكميه الكليه

            double nr = Convert.ToDouble(textBox21.Text);
            double dr = Convert.ToDouble(textQuntityProfit.Text);
            double rd = nr - dr;
            textBox21.Text = rd.ToString();
            textBox21.Text = Math.Round(double.Parse(textBox21.Text), 2).ToString();




            //===================== معرفة كمية الاجمالى بعد الخصم

            double jjs = Convert.ToDouble(textBox21.Text);
            double jsj = Convert.ToDouble(textUnityCategrey.Text); // -- الفئه
            double sjj = jjs % jsj;            // باقى القسمه
            textBox64.Text = sjj.ToString();
            textBox64.Text = Math.Round(double.Parse(textBox64.Text), 2).ToString();

            //===================== حساب قيمة الاجمالى
            double nnnn = Convert.ToDouble(textBox21.Text);
            double dddd = Convert.ToDouble(textPriceShraa.Text); //--- سعر الشراء
            double rrrr = nnnn * dddd;
            ValueTotal = rrrr.ToString();

            //=====================  حساب قيمة القطع
            double na = Convert.ToDouble(textBox21.Text); // ---  الاجمالى
            double da = Convert.ToDouble(textBox64.Text); //---- الكمية ق
            double ca = Convert.ToDouble(textUnityCategrey.Text); // ---- الفئه
            double ra = (na - da) / ca;

            textBox18.Text = ra.ToString(); //---- الكمية ق
            textBox18.Text = Math.Round(double.Parse(textBox18.Text), 0).ToString();


            //}
            //catch
            //{ }

            //=====================نحدث البيانات علشان الكميه الجديده

            try
            {
                sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',QuantityT='" + textBox64.Text + "',Total = '" + textBox21.Text + "',Price = '" + textPriceShraa.Text + "',Value = '" + ValueTotal + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + Storage + "' ";
                sqlCommand1.ExecuteNonQuery();
                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }



            //===================== اضافة الصنف فى الفاتورة


            sqlCommand1.CommandText = "insert into Billing (NumBill,Num,ClinentID,ClientName,CategoryID,Storage,Category,Date,Quantity,Type,Price,Discount,Total,CategorySN)values ('" + textBillingDataNumBill.Text + "','" + NumCategorey + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + CategoryID + "','" + Storage + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Quantity + "','" + ComTypeCategorey.Text + "','" + textPrice.Text + "','" + textDiscCategorey1.Text + "','" + TotalCategoryValue + "','" + textCategoreySN.Text + "')";
            sqlCommand1.ExecuteNonQuery();



            //---------------------   حذف الصنف من جدول السرايل ان وجد له سريال   -----------------------

            if (NumSnCategorey > 0)
            {
                sqlCommand1.CommandText = "delete from CategorySN where ID = '" + textID_SN.Text + "'  ";
                sqlCommand1.ExecuteNonQuery();

                //---------------------- ايجاد السرايل بعد الحذف
                GETCategoreySN();

                textID_SN.Text = "0";


            }
            else
            {
                //------------------  لايوجد سريال مختار  
            }








            //===================== ايجاد الاصناف فى الفاتورة
            dt2.Clear();
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            SqlDataAdapter da11 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);

            da11.Fill(dt2);

            this.dataGridView2.DataSource = dt2;
            //-------------------------------------------------------------------------
            //------------------- ترقيم الداتا جريد
            //int rowNumber = 1;
            //int rowNumber1 = 0;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    //if (row.IsNewRow) continue;
            //    //row.HeaderCell.Value = "" + rowNumber + "";
            //    //rowNumber = rowNumber + 1;

            //    rowNumber1 = rowNumber1 + 1;
            //}
            ////dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            ////عدد الفواتير
            //TxtNumCategorey.Text = rowNumber1.ToString();
            //===================== حساب إجمالى الفاتورة عدد الاصناف
            int rowNumber1 = 0;

            //double sum1 = 0;
            //for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
            //{
            //    sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
            //    rowNumber1 = rowNumber1 + 1;

            //}

            //txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
            //TxtNumCategorey.Text = rowNumber1.ToString();

            double sum1 = 0;
            double sumQuentity = 0;
            for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
            {
                sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
                sumQuentity += Convert.ToDouble(dataGridView2.Rows[s].Cells[3].Value);
                rowNumber1 = rowNumber1 + 1;

            }

            txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();

            TxtNumQuentity.Text = Math.Round(double.Parse(sumQuentity.ToString()), 0).ToString();


            TxtNumCategorey.Text = rowNumber1.ToString();

            //-------------------------------------------------------------------------

            //------------------------- العميل النقدى -------------------

            if (comTypeBill.Text == "نقدى")
            {
                txtMosadad.Text = txtTotalBill.Text;
            }
            else
            {

            }

            //===================== حساب المتبقى والتحديث

            CountRemaining();

            // button13.PerformClick();






            //===================== إضافة بيانات الفاتورة
            if (FormName == "فاتورة مبيعات")
            {

                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,TypeBill,NamePrint,NameMandop,PreviousBalance,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,NumberCategory,TotalBillBuyInvalid,State)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textClientGroup.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comTypeBill.Text + "','" + textUser.Text + "','" + textBox57.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + 0 + "','" + txtTotalBill.Text + "','" + 0 + "','" + txtDic.Text + "','" + textBox12.Text + "','" + txtAdd.Text + "','" + textBox14.Text + "','" + TotalAndRemaninRasedClient + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + TxtNumCategorey.Text + "','" + 0 + "','" + textNoteBill.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

            }
            else if (FormName == "مردودات مشتريات")
            {

                try
                {
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,TypeBill,NamePrint,NameMandop,PreviousBalance,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,NumberCategory,TotalBillBuyInvalid,State)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textClientGroup.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comTypeBill.Text + "','" + textUser.Text + "','" + textBox57.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtDic.Text + "','" + textBox12.Text + "','" + txtAdd.Text + "','" + textBox14.Text + "','" + TotalAndRemaninRasedClient + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + TxtNumCategorey.Text + "','" + txtTotalBill.Text + "','" + textNoteBill.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , NumberCategory ='" + TxtNumCategorey.Text + "', State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

            }

            //-------------------------------------------------------------------------



            //===================== إضافة أرباح اليوم

            sqlCommand1.CommandText = "insert into Profit (NumBill,Date,Category,Num,Quantity,Type,PriceShraa,PriceBeaa,Profit)values ('" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorys.Text + "','" + NumCategorey + "','" + textQuntityProfit.Text + "','" + textBox20.Text + "','" + textBox46.Text + "','" + txtTotalCategory.Text + "','" + textBox47.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== إضافة حركة الصنف 
            sqlCommand1.CommandText = "insert into CategoryMove (Category,Num,Storage,IDBill,Clients,Date,Move,Alwared,FactionAlwared,PriceSH,ValueAlwared,Alsader,FactionAlsader,PriceB,valueAlsader,Balancek,BalanceT)values ('" + combCategorys.Text + "','" + NumCategorey + "','" + Storage + "','" + textBillingDataNumBill.Text + "','" + comClient.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + 0 + "','" + ComTypeCategorey.Text + "','" + 0 + "','" + 0 + "','" + textQuntity.Text + "','" + ComTypeCategorey.Text + "','" + textPrice.Text + "','" + txtTotalCategory.Text + "','" + textBox18.Text + "','" + textBox21.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== إضافة حركة الصنف الجديده 
            sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Num,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorys.Text + "','" + NumCategorey + "','" + Storage + "','" + Storage + "','" + comClient.Text + "','" + FormName + "','" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + 0 + "','" + textQuntityProfit.Text + "','" + textQuntityProfit.Text + "','" + textBox21.Text + "','" + textUser.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== تعديل الرصيد فى جدول العملاء
            try
            {
                sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show(" pleas correct the data");
            }


            //----------  إضافة حركة الصندوق


            // -----   جلب دالة اضافة المسدد الى الرصيد فى الصندوق

            AddOrUpdateBoxMove();

            //============ القديم



            //try
            //{
            //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
            //    sqlCommand1.ExecuteNonQuery();
            //}
            //catch
            //{
            //    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
            //    sqlCommand1.ExecuteNonQuery();
            //}



            combCategorys.Focus();
        }

        private void AddingBilling2()
        {

            string Quantity = "";
            string TotalCategoryValue = "";
            string NumCategorey = "";
            if (checkBox2.Checked == true) //---- تجميع الاصناف المتشابهه
            {
                //------------------- ايجاد كمية الصنف اذا كان مضاف من قبل ----
                string QuntityOLD = "0";
                string TotalCategory = "0";
                string TypeCategorey = "";
                try
                {
                    sqlCommand1.CommandText = "select Quantity,Type,Num from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and CategoryID = '" + CategoryID + "'";
                    read = sqlCommand1.ExecuteReader();
                    while (read.Read())
                    {

                        QuntityOLD = read["Quantity"].ToString();
                        TypeCategorey = read["Type"].ToString();
                        NumCategorey = read["Num"].ToString();


                    }
                    read.Close();
                }
                catch
                { }

                if (ComTypeCategorey.Text == TypeCategorey) //---- نوع الصنف كرتونة او قطعه متشابهه
                {
                    //----------- حذف الصنف من الفاتورة
                    sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and CategoryID = '" + CategoryID + "' and Num = '" + NumCategorey + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //---------- حساب سعر الكميه المطلوبه مع الكمية القديمة للصنف ان وجد ---

                    double nn = Convert.ToDouble(textQuntity.Text) + Convert.ToDouble(QuntityOLD);
                    double dd = Convert.ToDouble(textPrice.Text);
                    double mm = Convert.ToDouble(textDiscCategorey.Text);
                    double rr = (nn * dd) - (nn * mm);
                    TotalCategory = Math.Round(double.Parse(rr.ToString()), 2).ToString();
                    TotalCategoryValue = TotalCategory;

                    //---------- حساب سعر الكميه المطلوبه  ---

                    double nn1 = Convert.ToDouble(textQuntity.Text);
                    double rr1 = (nn1 * dd) - (nn * mm);
                    txtTotalCategory.Text = Math.Round(double.Parse(rr1.ToString()), 2).ToString();

                    //----- كمية الصنف بالاضافة للكمية القديمة
                    double sum = Convert.ToDouble(textQuntity.Text) + Convert.ToDouble(QuntityOLD); //اضفنا القيمة القديمة ان كان اخدها قبل كده فى نفس الفاتورة
                    Quantity = sum.ToString();



                }
                else
                {
                    //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                    double nn = Convert.ToDouble(textQuntity.Text);
                    double dd = Convert.ToDouble(textPrice.Text);
                    double mm = Convert.ToDouble(textDiscCategorey.Text);
                    double rr = (nn * dd) - (nn * mm);

                    txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
                    TotalCategoryValue = txtTotalCategory.Text;
                    //----- كمية الصنف بدون للكمية القديمة
                    Quantity = nn.ToString();

                    //===================== حساب رقم الصنف
                    double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                    double rrr = nnn + 1;
                    textBox26.Text = rrr.ToString();
                    NumCategorey = textBox26.Text;
                }
            }

            else //------ لا تجمع الاصناف المتشابهه
            {
                //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPrice.Text);
                double mm = Convert.ToDouble(textDiscCategorey.Text);
                double rr = (nn * dd) - (nn * mm);

                txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();
                TotalCategoryValue = txtTotalCategory.Text;
                //----- كمية الصنف بدون للكمية القديمة
                Quantity = nn.ToString();

                //===================== حساب رقم الصنف
                double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                double rrr = nnn + 1;
                textBox26.Text = rrr.ToString();
                NumCategorey = textBox26.Text;

            }
            //----------------------------------------------------------------

            // حساب سعر الشراء الكميه المطلوبه
            try
            {
                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPriceSH.Text);
                double rr = nn * dd;
                textBox46.Text = rr.ToString();

            }

            catch (FormatException)
            {
                textPriceSH.Text = "0";
                textBox46.Text = "0";
                MessageBox.Show("يجب إدخال الكميه المطلوبه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //===================== حساب ربح الصنف
            string ValueTotal = "0";
            //try
            //{
            double nar = Convert.ToDouble(txtTotalCategory.Text);
            double dar = Convert.ToDouble(textBox46.Text);
            double rad = nar - dar;
            textBox47.Text = rad.ToString();

            //===================== طرح الكميه من الكميه الكليه

            double nr = Convert.ToDouble(textBox21.Text);
            double dr = Convert.ToDouble(textQuntityProfit.Text);
            double rd = nr - dr;
            textBox21.Text = rd.ToString();
            textBox21.Text = Math.Round(double.Parse(textBox21.Text), 2).ToString();




            //===================== معرفة كمية الاجمالى بعد الخصم

            double jjs = Convert.ToDouble(textBox21.Text);
            double jsj = Convert.ToDouble(textUnityCategrey.Text); // -- الفئه
            double sjj = jjs % jsj;            // باقى القسمه
            textBox64.Text = sjj.ToString();
            textBox64.Text = Math.Round(double.Parse(textBox64.Text), 2).ToString();

            //===================== حساب قيمة الاجمالى
            double nnnn = Convert.ToDouble(textBox21.Text);
            double dddd = Convert.ToDouble(textPriceShraa.Text); //--- سعر الشراء
            double rrrr = nnnn * dddd;
            ValueTotal = rrrr.ToString();

            //=====================  حساب قيمة القطع
            double na = Convert.ToDouble(textBox21.Text); // ---  الاجمالى
            double da = Convert.ToDouble(textBox64.Text); //---- الكمية ق
            double ca = Convert.ToDouble(textUnityCategrey.Text); // ---- الفئه
            double ra = (na - da) / ca;

            textBox18.Text = ra.ToString(); //---- الكمية ق
            textBox18.Text = Math.Round(double.Parse(textBox18.Text), 0).ToString();


            //}
            //catch
            //{ }

            //=====================نحدث البيانات علشان الكميه الجديده

            try
            {
                //sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',QuantityT='" + textBox64.Text + "',Total = '" + textBox21.Text + "',Price = '" + textPriceShraa.Text + "',Value = '" + ValueTotal + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + Storage + "' ";
                //sqlCommand1.ExecuteNonQuery();
                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }



            //===================== اضافة الصنف فى الفاتورة


            sqlCommand1.CommandText = "insert into Billing2 (NumBill,Num,ClinentID,ClientName,CategoryID,Storage,Category,Date,Quantity,Type,Price,Discount,Total)values ('" + textBillingDataNumBill.Text + "','" + NumCategorey + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + CategoryID + "','" + Storage + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Quantity + "','" + ComTypeCategorey.Text + "','" + textPrice.Text + "','" + textDiscCategorey1.Text + "','" + TotalCategoryValue + "')";
            sqlCommand1.ExecuteNonQuery();

            //===================== ايجاد الاصناف فى الفاتورة
            dt2.Clear();
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            SqlDataAdapter da11 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing2 where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);

            da11.Fill(dt2);

            this.dataGridView2.DataSource = dt2;
            //-------------------------------------------------------------------------
            //------------------- ترقيم الداتا جريد
            //int rowNumber = 1;
            //int rowNumber1 = 0;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    //if (row.IsNewRow) continue;
            //    //row.HeaderCell.Value = "" + rowNumber + "";
            //    //rowNumber = rowNumber + 1;

            //    rowNumber1 = rowNumber1 + 1;
            //}
            ////dataGridView4.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            ////عدد الفواتير
            //TxtNumCategorey.Text = rowNumber1.ToString();
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

            //-------------------------------------------------------------------------

            //------------------------- العميل النقدى -------------------

            if (comTypeBill.Text == "نقدى")
            {
                txtMosadad.Text = txtTotalBill.Text;
            }
            else
            {

            }

            //===================== حساب المتبقى والتحديث

            // CountRemaining();

            // button13.PerformClick();






            //===================== إضافة بيانات الفاتورة
            if (FormName == "فاتورة مبيعات غير معتمدة")
            {

                try
                {
                    sqlCommand1.CommandText = "insert into BillingData2 (NumBill,ClientID,Name,Type,Date,Move,TypeBill,NamePrint,NameMandop,PreviousBalance,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,NumberCategory,TotalBillBuyInvalid,State)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textClientGroup.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comTypeBill.Text + "','" + textUser.Text + "','" + textBox57.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + 0 + "','" + txtTotalBill.Text + "','" + 0 + "','" + txtDic.Text + "','" + textBox12.Text + "','" + txtAdd.Text + "','" + textBox14.Text + "','" + TotalAndRemaninRasedClient + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + TxtNumCategorey.Text + "','" + 0 + "','" + textNoteBill.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update BillingData2 set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

            }
            else if (FormName == "مردودات مشتريات")
            {

                //try
                //{
                //    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,TypeBill,NamePrint,NameMandop,PreviousBalance,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,Discount,ReasonDiscount,Adding,ReasonAdd,Total,Pay,Paid,Remaining,NumberCategory,TotalBillBuyInvalid,State)values ('" + textBillingDataNumBill.Text + "','" + textClintID.Text + "','" + txtClintName.Text + "','" + textClientGroup.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comTypeBill.Text + "','" + textUser.Text + "','" + textBox57.Text + "','" + txtRemaningOld.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtDic.Text + "','" + textBox12.Text + "','" + txtAdd.Text + "','" + textBox14.Text + "','" + TotalAndRemaninRasedClient + "','" + 0 + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + TxtNumCategorey.Text + "','" + txtTotalBill.Text + "','" + textNoteBill.Text + "')";
                //    sqlCommand1.ExecuteNonQuery();
                //}
                //catch
                //{
                //    sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , NumberCategory ='" + TxtNumCategorey.Text + "', State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                //    sqlCommand1.ExecuteNonQuery();
                //}

            }

            //-------------------------------------------------------------------------



            ////===================== إضافة أرباح اليوم

            //sqlCommand1.CommandText = "insert into Profit (NumBill,Date,Category,Num,Quantity,Type,PriceShraa,PriceBeaa,Profit)values ('" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorys.Text + "','" + NumCategorey + "','" + textQuntityProfit.Text + "','" + textBox20.Text + "','" + textBox46.Text + "','" + txtTotalCategory.Text + "','" + textBox47.Text + "')";
            //sqlCommand1.ExecuteNonQuery();

            ////===================== إضافة حركة الصنف 
            //sqlCommand1.CommandText = "insert into CategoryMove (Category,Num,Storage,IDBill,Clients,Date,Move,Alwared,FactionAlwared,PriceSH,ValueAlwared,Alsader,FactionAlsader,PriceB,valueAlsader,Balancek,BalanceT)values ('" + combCategorys.Text + "','" + NumCategorey + "','" + Storage + "','" + textBillingDataNumBill.Text + "','" + comClient.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + 0 + "','" + ComTypeCategorey.Text + "','" + 0 + "','" + 0 + "','" + textQuntity.Text + "','" + ComTypeCategorey.Text + "','" + textPrice.Text + "','" + txtTotalCategory.Text + "','" + textBox18.Text + "','" + textBox21.Text + "')";
            //sqlCommand1.ExecuteNonQuery();

            ////===================== إضافة حركة الصنف الجديده 
            //sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Num,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorys.Text + "','" + NumCategorey + "','" + Storage + "','" + Storage + "','" + comClient.Text + "','" + FormName + "','" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + 0 + "','" + textQuntityProfit.Text + "','" + textQuntityProfit.Text + "','" + textBox21.Text + "','" + textUser.Text + "')";
            //sqlCommand1.ExecuteNonQuery();

            ////===================== تعديل الرصيد فى جدول العملاء
            //try
            //{
            //    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
            //    sqlCommand1.ExecuteNonQuery();

            //}
            //catch
            //{
            //    MessageBox.Show(" pleas correct the data");
            //}


            ////----------  إضافة حركة الصندوق

            //try
            //{
            //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
            //    sqlCommand1.ExecuteNonQuery();
            //}
            //catch
            //{
            //    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
            //    sqlCommand1.ExecuteNonQuery();
            //}



            combCategorys.Focus();
        }

        private void AddCategory_BestSeller()
        {

            try
            {
                sqlCommand1.CommandText = "select Category_Barcode,Number_Sales,Selection From Category_BestSeller where Category = '" + combCategorys.Text + "'";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    RseedBox = "0";

                    //  string Category_Barcode = reeeeed["Category_Barcode"].ToString();
                    Number_Sales = Convert.ToDouble(reed["Number_Sales"].ToString());
                    //  string Selection = reeeeed["Selection"].ToString();


                }
                reed.Close();


                if (Number_Sales == 0)
                {
                    sqlCommand1.CommandText = "insert into Category_BestSeller (LastDate,Category_Barcode,Category,Number_Sales,Selection)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBarcode.Text + "','" + combCategorys.Text + "','" + 1 + "','" + Selection_Category + "')";
                    sqlCommand1.ExecuteNonQuery();

                    // MessageBox.Show("    تم اضافة جديد   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    double a = Number_Sales;
                    double b = a + 1;

                    string Number_Sales2 = b.ToString();

                    sqlCommand1.CommandText = "update Category_BestSeller set LastDate = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', Number_Sales = '" + Number_Sales2 + "'  where Category = '" + combCategorys.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    Number_Sales = 0;


                    //   MessageBox.Show("   تم التعديل   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

            }
            catch
            {
                // MessageBox.Show("   خطا فى البحث   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }
        private void chekTextEmpty()
        {
            if (txtClintName.Text == "")
            {
                MessageBox.Show("       من فضلك إختار اسم العميل من قائمة العملاء           ", "  خطأ  ");
                comClient.Focus();
            }
            else
            {
                if (combCategorys.Text == "")
                {
                    MessageBox.Show("       من فضلك ادخل الصنف           ", "  خطأ  ");
                    combCategorys.Focus();
                }
                else
                {
                    if (textBillingDataNumBill.Text == "")
                    {
                        MessageBox.Show("       من فضلك أدخل رقم الفاتورة           ", "  خطأ  ");
                        textBillingDataNumBill.Focus();
                    }
                    else
                    {
                        if (textClintID.Text == "")
                        {
                            MessageBox.Show("       من فضلك إختار إسم العميل وإضغط إنتر           ", "  خطأ  ");
                            textClintID.Focus();
                        }
                        else
                        {
                            if (textQuntity.Text == "")
                            {
                                MessageBox.Show("       من فضلك أدخل الكمية المطلوبه           ", "  خطأ  ");
                                textQuntity.Focus();
                            }
                            else
                            {
                                if (textPrice.Text == "")
                                {
                                    MessageBox.Show("       من فضلك أدخل سعر الوحدة           ", "  خطأ  ");
                                    textPrice.Focus();
                                }
                                else
                                {
                                    if (textBox21.Text == "")
                                    {
                                        MessageBox.Show("      يوجد خطأ فى البيانات المدخله           ", "  خطأ  ");
                                        textBox21.Focus();
                                    }
                                    else
                                    {
                                        if (textBox18.Text == "")
                                        {
                                            MessageBox.Show("      يوجد خطأ فى البيانات المدخله           ", "  خطأ  ");
                                            textBox18.Focus();
                                        }
                                        else
                                        {
                                            if (radioButton2.Checked == true) // صنف خارج المخزن
                                            {
                                                AddingBilling_Yadaey();
                                                if (comClient.Enabled == true)
                                                {
                                                    comClient.Enabled = false;
                                                    dateTimePicker1.Enabled = false;
                                                    textBillingDataNumBill.Enabled = false;

                                                }
                                                else { }
                                            }
                                            else  // صنف من المخزن
                                            {
                                                // معرفة اذا كانت الكميه المجوده تكفى ولا لا
                                                double i = Convert.ToDouble(textQuntityProfit.Text);
                                                double j = Convert.ToDouble(textBox21.Text);
                                                if (i > j)
                                                {

                                                    System.Media.SystemSounds.Beep.Play(); //تشغيل انذار



                                                    //  MessageBox.Show("الكمية الموجودة لا تكفى", "Error");
                                                    DialogResult dialogResult = MessageBox.Show("ملحوظة : الكمية الموجودة لا تكفى هل تريد استكمال البيع بالسالب ", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (dialogResult == DialogResult.Yes)
                                                    {

                                                        // SoundPlayer.Play(); //تشغيل انذار

                                                        AddingBilling();
                                                        if (comClient.Enabled == true)
                                                        {
                                                            comClient.Enabled = false;
                                                            dateTimePicker1.Enabled = false;
                                                            textBillingDataNumBill.Enabled = false;
                                                        }
                                                        else { }


                                                    }
                                                    else if (dialogResult == DialogResult.No)
                                                    {

                                                    }
                                                }
                                                else
                                                {
                                                    //----------
                                                    AddingBilling();
                                                    if (comClient.Enabled == true)
                                                    {
                                                        comClient.Enabled = false;
                                                        dateTimePicker1.Enabled = false;
                                                        textBillingDataNumBill.Enabled = false;
                                                    }
                                                    else { }
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

        private void chekTextEmpty2()
        {
            if (txtClintName.Text == "")
            {
                MessageBox.Show("       من فضلك إختار اسم العميل من قائمة العملاء           ", "  خطأ  ");
                comClient.Focus();
            }
            else
            {
                if (combCategorys.Text == "")
                {
                    MessageBox.Show("       من فضلك ادخل الصنف           ", "  خطأ  ");
                    combCategorys.Focus();
                }
                else
                {
                    if (textBillingDataNumBill.Text == "")
                    {
                        MessageBox.Show("       من فضلك أدخل رقم الفاتورة           ", "  خطأ  ");
                        textBillingDataNumBill.Focus();
                    }
                    else
                    {
                        if (textClintID.Text == "")
                        {
                            MessageBox.Show("       من فضلك إختار إسم العميل وإضغط إنتر           ", "  خطأ  ");
                            textClintID.Focus();
                        }
                        else
                        {
                            if (textQuntity.Text == "")
                            {
                                MessageBox.Show("       من فضلك أدخل الكمية المطلوبه           ", "  خطأ  ");
                                textQuntity.Focus();
                            }
                            else
                            {
                                if (textPrice.Text == "")
                                {
                                    MessageBox.Show("       من فضلك أدخل سعر الوحدة           ", "  خطأ  ");
                                    textPrice.Focus();
                                }
                                else
                                {
                                    if (textBox21.Text == "")
                                    {
                                        MessageBox.Show("      يوجد خطأ فى البيانات المدخله           ", "  خطأ  ");
                                        textBox21.Focus();
                                    }
                                    else
                                    {
                                        if (textBox18.Text == "")
                                        {
                                            MessageBox.Show("      يوجد خطأ فى البيانات المدخله           ", "  خطأ  ");
                                            textBox18.Focus();
                                        }
                                        else
                                        {
                                            if (radioButton2.Checked == true) // صنف خارج المخزن
                                            {
                                                AddingBilling_Yadaey();
                                                if (comClient.Enabled == true)
                                                {
                                                    comClient.Enabled = false;
                                                    dateTimePicker1.Enabled = false;
                                                    textBillingDataNumBill.Enabled = false;

                                                }
                                                else { }
                                            }
                                            else  // صنف من المخزن
                                            {
                                                // معرفة اذا كانت الكميه المجوده تكفى ولا لا
                                                double i = Convert.ToDouble(textQuntityProfit.Text);
                                                double j = Convert.ToDouble(textBox21.Text);
                                                if (i > j)
                                                {
                                                    //  MessageBox.Show("الكمية الموجودة لا تكفى", "Error");
                                                    DialogResult dialogResult = MessageBox.Show("ملحوظة : الكمية الموجودة لا تكفى هل تريد استكمال البيع بالسالب ", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                    if (dialogResult == DialogResult.Yes)
                                                    {
                                                        AddingBilling2();
                                                        if (comClient.Enabled == true)
                                                        {
                                                            comClient.Enabled = false;
                                                            dateTimePicker1.Enabled = false;
                                                            textBillingDataNumBill.Enabled = false;
                                                        }
                                                        else { }


                                                    }
                                                    else if (dialogResult == DialogResult.No)
                                                    {

                                                    }
                                                }
                                                else
                                                {
                                                    //----------
                                                    AddingBilling2();
                                                    if (comClient.Enabled == true)
                                                    {
                                                        comClient.Enabled = false;
                                                        dateTimePicker1.Enabled = false;
                                                        textBillingDataNumBill.Enabled = false;
                                                    }
                                                    else { }
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

        DataTable table = new DataTable();
        private void butAddCategorey_Click(object sender, EventArgs e)
        {

            // ---------- اختبار الحد الائتمانى

            if (LimitCredit == "1") //--------- الحد الائتمانى مفعل
            {
                double al = Convert.ToDouble(textLimitCredit.Text);


                double a = Convert.ToDouble(txtTotalCategory.Text);
                double b = Convert.ToDouble(txtRemaningOld.Text);
                double c = Convert.ToDouble(txtTotalBill.Text);
                double aaa = a + b + c;
                if (aaa > al) // -------- الاجمالى والفاتورة والصنف اكبر من الحد الائتمانى
                {
                    MessageBox.Show("     لن يمكن اضافة الصنف الجديد لزيادة الاجمالى عن الحد الائتمانى      ", "الحد الائتمانى");
                }
                else
                {
                    if (textBillingDataNumBill.Text == "")
                    {
                        GetNumBill();


                    }
                    else
                    { }

                    try
                    {
                        if (radioButton2.Checked == true) // صنف خارج المخزن
                        {
                            chekTextEmpty();
                        }
                        else  // صنف من المخزن
                        {
                            double Price = Convert.ToDouble(textPrice.Text);
                            double PriceSH = Convert.ToDouble(textPriceSH.Text);
                            if (Price < PriceSH)
                            {
                                DialogResult dialogResult = MessageBox.Show("ملحوظة : سعر البيع أقل من سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    chekTextEmpty();
                                    //AddingBill();


                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                }
                            }

                            else if (Price == PriceSH)
                            {
                                DialogResult dialogResult2 = MessageBox.Show("ملحوظة : سعر البيع يساوى سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult2 == DialogResult.Yes)
                                {
                                    chekTextEmpty();


                                    //AddingBill();
                                }
                                else if (dialogResult2 == DialogResult.No)
                                {

                                }
                            }
                            else
                            {
                                chekTextEmpty();
                                //AddingBill();

                            }
                        }

                        AddCategory_BestSeller();
                        textPrice.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("    من فضلك تاكد من كتابة الارقام والعلامات العشرية بطريقة صحيحة   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else  //---------- الحد الائتمانى غير مفعل
            {

                if (textBillingDataNumBill.Text == "")
                {
                    GetNumBill();


                }
                else
                { }

                try
                {
                    if (radioButton2.Checked == true) // صنف خارج المخزن
                    {
                        chekTextEmpty();
                    }
                    else  // صنف من المخزن
                    {
                        double Price = Convert.ToDouble(textPrice.Text);
                        double PriceSH = Convert.ToDouble(textPriceSH.Text);
                        if (Price < PriceSH)
                        {

                            //  SoundPlayer.Play(); //تشغيل انذار

                            DialogResult dialogResult = MessageBox.Show("ملحوظة : سعر البيع أقل من سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                chekTextEmpty();
                                //AddingBill();


                            }
                            else if (dialogResult == DialogResult.No)
                            {

                            }
                        }

                        else if (Price == PriceSH)
                        {

                            //  SoundPlayer.Play(); //تشغيل انذار

                            DialogResult dialogResult2 = MessageBox.Show("ملحوظة : سعر البيع يساوى سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult2 == DialogResult.Yes)
                            {
                                chekTextEmpty();


                                //AddingBill();
                            }
                            else if (dialogResult2 == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            chekTextEmpty();
                            //AddingBill();

                        }
                    }

                    AddCategory_BestSeller();
                    textPrice.Text = "";

                    RebhCategory();
                }
                catch
                {
                    MessageBox.Show("    من فضلك تاكد من كتابة الارقام والعلامات العشرية بطريقة صحيحة   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void button24_Click(object sender, EventArgs e)
        {


        }

        private void butClientDay_Click(object sender, EventArgs e)
        {


            //if (dataGridView4.Visible == true)
            //{
            //    //panel14.Visible = false;
            //    //panel10.Visible = false;
            //    panelBillDay.Visible = false;
            //}
            //else
            //{
            //    //panel14.Visible = false;
            //    // panel10.Visible = false;
            //    panelBillDay.Visible = true;


            //    DataTable dt12 = new DataTable();
            //    dt12.Clear();
            //    SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move like '" + FormName + "' ", cn);
            //    da21.Fill(dt12);
            //    this.dataGridView4.DataSource = dt12;

            //    try
            //    {
            //        double sum = 0;
            //        double sum1 = 0;
            //        for (int i = 0; i < dataGridView4.RowCount; ++i)
            //        {
            //            sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
            //            sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);



            //        }
            //        textTotalBill.Text = sum.ToString();
            //        textTotalTahsel.Text = sum1.ToString();

            //    }
            //    catch
            //    { }

            //    //------------------- ترقيم الداتا جريد
            //    int rowNumber = 1;
            //    int rowNumber1 = 0;
            //    foreach (DataGridViewRow row in dataGridView4.Rows)
            //    {
            //        if (row.IsNewRow) continue;
            //        row.HeaderCell.Value = "" + rowNumber + "";
            //        rowNumber = rowNumber + 1;

            //        rowNumber1 = rowNumber1 + 1;
            //    }
            //    // dataGridClientsDay.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //    //عدد الفواتير
            //    textNumBill.Text = rowNumber1.ToString();
            //}
        }
        public void GetBill()
        {
            try
            {

                txtTotalBill.Text = "0";
                TxtNumCategorey.Text = "0";
                txtRemaningOld.Text = "0";
                TotalAndRemaninRasedClient = "0";
                txtDic.Text = "0";
                txtAdd.Text = "0";
                // textBox27.Text = "0";
                txtMosadad.Text = "0";
                // txtMosadad2.Text = "0";
                txtRemainingNow.Text = "0";
                //  textBox28.Text = "";
                textClintID.Text = "";


                //-----------

                comClient.Text = "";
                txtClintName.Text = "";

                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                dt18.Clear();
                SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "'  ", cn);
                da18.Fill(dt18);
                this.dataGridView2.DataSource = dt18;
                //------------------------------------



                sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    comClient.Text = read["Name"].ToString();
                    txtClintName.Text = read["Name"].ToString();

                    textBillingDataNumBill.Text = read["NumBill"].ToString();
                    txtTotalBill.Text = read["TotalBill"].ToString();
                    textClintID.Text = read["ClientID"].ToString();
                    textClientGroup.Text = read["Type"].ToString();
                    textUser.Text = read["NamePrint"].ToString();
                    textBox57.Text = read["NameMandop"].ToString();
                    comTypeBill.Text = read["TypeBill"].ToString();

                    TxtNumCategorey.Text = read["NumberCategory"].ToString();
                    txtRemaningOld.Text = read["PreviousBalance"].ToString();
                    TotalAndRemaninRasedClient = read["Total"].ToString();
                    txtDic.Text = read["Discount"].ToString();
                    textBox12.Text = read["ReasonDiscount"].ToString();
                    //  textBox27.Text = read["Creditor"].ToString();
                    txtAdd.Text = read["Adding"].ToString();
                    textBox14.Text = read["ReasonAdd"].ToString();
                    txtMosadad.Text = read["Paid"].ToString();
                    // txtMosadad2.Text = read["Paid"].ToString();
                    txtRemainingNow.Text = read["Remaining"].ToString();
                    //  textBox30.Text = read["State"].ToString();
                    dateTimePicker1.Text = read["Date"].ToString();

                }
                read.Close();


                sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    MoveBoxID = read["ID"].ToString();



                }
                read.Close();
            }
            catch
            {

            }
        }
        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkCopyBill.Checked == true)   // تحديد نسخ الاصناف
            {
                if (textBillingDataNumBill.Text == "")
                {

                    panel17.Visible = true;

                    textBillingDataNumBillCopy.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();


                    // ايجاد الاصناف فى الفاتورة

                    //------------------------------------
                    dt6.Clear();
                    SqlDataAdapter da6 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBillCopy.Text + "' ", cn);
                    da6.Fill(dt6);
                    this.dataGridView9.DataSource = dt6;
                    //------------------------------------
                }
                else
                {
                    MessageBox.Show("  يوجد فاتورة مفتوحة يرجى غلق الشاشة وفتحها مرة اخرى   ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else // عدم اختيار الاصناف
            {
                txtTotalBill.Text = "0";
                TxtNumCategorey.Text = "0";
                txtRemaningOld.Text = "0";
                TotalAndRemaninRasedClient = "0";
                txtDic.Text = "0";
                txtAdd.Text = "0";
                // textBox27.Text = "0";
                txtMosadad.Text = "0";
                // txtMosadad2.Text = "0";
                txtRemainingNow.Text = "0";
                //  textBox28.Text = "";
                textClintID.Text = "";


                textBillingDataNumBill.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTotalBill.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
                //try
                //{




                //-----------

                comClient.Text = "";
                txtClintName.Text = "";





                sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    comClient.Text = read["Name"].ToString();
                    txtClintName.Text = read["Name"].ToString();

                    textBillingDataNumBill.Text = read["NumBill"].ToString();
                    // txtTotalBill.Text = read["TotalBill"].ToString();
                    textClintID.Text = read["ClientID"].ToString();
                    textClientGroup.Text = read["Type"].ToString();
                    textUser.Text = read["NamePrint"].ToString();
                    textBox57.Text = read["NameMandop"].ToString();
                    comTypeBill.Text = read["TypeBill"].ToString();

                    TxtNumCategorey.Text = read["NumberCategory"].ToString();
                    txtRemaningOld.Text = read["PreviousBalance"].ToString();
                    TotalAndRemaninRasedClient = read["Total"].ToString();
                    txtDic.Text = read["Discount"].ToString();
                    textBox12.Text = read["ReasonDiscount"].ToString();
                    //  textBox27.Text = read["Creditor"].ToString();
                    txtAdd.Text = read["Adding"].ToString();
                    textBox14.Text = read["ReasonAdd"].ToString();
                    txtMosadad.Text = read["Paid"].ToString();
                    // txtMosadad2.Text = read["Paid"].ToString();
                    txtRemainingNow.Text = read["Remaining"].ToString();
                    //  textBox30.Text = read["State"].ToString();
                    dateTimePicker1.Text = read["Date"].ToString();
                    textNoteBill.Text = read["State"].ToString();

                }
                read.Close();





                //}
                //catch
                //{

                //}

                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                dt2.Clear();
                SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da18.Fill(dt2);
                this.dataGridView2.DataSource = dt2;
                //------------------------------------



                //============ ايجار رقم الصندوق  


                //GetMoveBoxOldBillID(int numBill)

                int numBill = int.Parse(textBillingDataNumBill.Text); // TextBox فيه رقم الفاتورة
                int moveBoxID = GetMoveBoxOldBillID(numBill);

                if (moveBoxID == 0)
                {
                    // MessageBox.Show("لم يتم العثور على السجل");
                }
                else
                {

                    //   textBox7.Text = moveBoxID.ToString();

                    MoveBoxID = moveBoxID.ToString();

                    //  MessageBox.Show("ID = " + moveBoxID);
                }



                // textBillingDataNumBill

                //sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' ";
                //readMoveBoxID = sqlCommand1.ExecuteReader();
                //while (readMoveBoxID.Read())
                //{
                //    MoveBoxID = readMoveBoxID["ID"].ToString();

                //    string MoveBoxID2 = readMoveBoxID["ID"].ToString();

                //    textBox7.Text = MoveBoxID2;


                //}
                //read.Close();


                //textMoveBoxID.Text = MoveBoxID;

                //MessageBox.Show(MoveBoxID, "MoveBoxID 3973", MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (comClient.Enabled == true)
                {
                    comClient.Enabled = false;
                    // dateTimePicker1.Enabled = false;
                    textBillingDataNumBill.Enabled = false;
                }
                else { }
            }
        }

        private void textBillingDataNumBill_TextChanged(object sender, EventArgs e)
        {
            //textBox49.Text = "0";
            //textBox50.Text = "0";
            //textBox51.Text = "0";
            //try
            //{

            //    txtTotalBill.Text = "0";
            //    TxtNumCategorey.Text = "0";
            //    txtRemaningOld.Text = "0";
            //    TotalAndRemaninRasedClient = "0";
            //    txtDic.Text = "0";
            //    txtAdd.Text = "0";
            //    // textBox27.Text = "0";
            //    txtMosadad.Text = "0";
            //    // txtMosadad2.Text = "0";
            //    txtRemainingNow.Text = "0";
            //    //  textBox28.Text = "";
            //    textClintID.Text = "";


            //    //-----------

            //    comClient.Text = "";
            //    txtClintName.Text = "";

            //    // ايجاد الاصناف فى الفاتورة

            //    //------------------------------------
            //    dt18.Clear();
            //    SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            //    da18.Fill(dt18);
            //    this.dataGridView2.DataSource = dt18;
            //    //------------------------------------



            //    sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'";
            //    read = sqlCommand1.ExecuteReader();
            //    while (read.Read())
            //    {
            //        comClient.Text = read["Name"].ToString();
            //        txtClintName.Text = read["Name"].ToString();

            //        textBillingDataNumBill.Text = read["NumBill"].ToString();
            //        txtTotalBill.Text = read["TotalBill"].ToString();
            //        textClintID.Text = read["ClientID"].ToString();
            //        textClientGroup.Text = read["Type"].ToString();
            //        textUser.Text = read["NamePrint"].ToString();
            //        textBox57.Text = read["NameMandop"].ToString();
            //        comTypeBill.Text = read["TypeBill"].ToString();

            //        TxtNumCategorey.Text = read["NumberCategory"].ToString();
            //        txtRemaningOld.Text = read["PreviousBalance"].ToString();
            //        TotalAndRemaninRasedClient = read["Total"].ToString();
            //        txtDic.Text = read["Discount"].ToString();
            //        textBox12.Text = read["ReasonDiscount"].ToString();
            //        //  textBox27.Text = read["Creditor"].ToString();
            //        txtAdd.Text = read["Adding"].ToString();
            //        textBox14.Text = read["ReasonAdd"].ToString();
            //        txtMosadad.Text = read["Paid"].ToString();
            //        // txtMosadad2.Text = read["Paid"].ToString();
            //        txtRemainingNow.Text = read["Remaining"].ToString();
            //        //  textBox30.Text = read["State"].ToString();
            //        dateTimePicker1.Text = read["Date"].ToString();

            //    }
            //    read.Close();


            //    sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
            //    read = sqlCommand1.ExecuteReader();
            //    while (read.Read())
            //    {
            //        MoveBoxID = read["ID"].ToString();



            //    }
            //    read.Close();
            //}
            //catch
            //{

            //}
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
            textClintID.Text = "";
            txtClintName.Text = "";
            textClientGroup.Text = "";
            //txtClintName.Text = comClient.Text;

            textClintNameNew.Text = comClient.Text;

            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comClient.Text + "' ";
                rad = sqlCommand1.ExecuteReader();
                while (rad.Read())
                {

                    textClintID.Text = rad["ID"].ToString();
                    txtClintName.Text = rad["Name"].ToString();
                    comClintGroup.Text = rad["Company"].ToString();
                    textClientGroup.Text = rad["Company"].ToString();
                    textClintTellHome.Text = rad["TelHome"].ToString();
                    textClintTellMobil.Text = rad["TelMobil"].ToString();
                    textClintAdress.Text = rad["Address"].ToString();
                    textLimitCredit.Text = rad["LimitCredit"].ToString();
                    //textBox9.Text = rad["PreviousBalance"].ToString();
                    //textBox27.Text = rad["Creditor"].ToString();


                }
                rad.Close();
            }
            catch
            {

            }
            //-------------- الحساب السابق --------------

            Searching();

            //--------------------------------------------

            try
            {
                textBox37.Text = "";
                textBox38.Text = "";

                //************************

                //sqlCommand1.CommandText = "select * from BillingData where Name = '" + comClient.Text + "' ";
                //read = sqlCommand1.ExecuteReader();
                //while (read.Read())
                //{

                //    label59.Text = read["Date"].ToString();
                //    label60.Text = read["Move"].ToString();

                //}
                //read.Close();
            }
            catch
            { }

            try
            {
                sqlCommand1.CommandText = "select * from BoxMove where Name ='" + comClient.Text + "' and NumBill ='" + textBillingDataNumBill.Text + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    MoveBoxID = reed["ID"].ToString();

                }
                reed.Close();

            }
            catch
            {

            }

            //-------------

            //  textBox66.Text = "0";
        }

        private void GETCategoreySN()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID, CategoryBarcode, CategoryName, CategorySN FROM CategorySN WHERE CategoryName = @CategoryName", cn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", combCategorys.Text);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView8.DataSource = dt;

                        // إعداد رؤوس الأعمدة
                        string[] headers = { "م", "الباركود", "الصنف", "السريال" };
                        int[] widths = { 60, 70, 200, 120 };
                        for (int i = 0; i < dataGridView8.Columns.Count; i++)
                        {
                            dataGridView8.Columns[i].HeaderText = headers[i];
                            dataGridView8.Columns[i].Width = widths[i];
                        }

                        NumSnCategorey = dt.Rows.Count;
                        textID_SN.Text = "0";

                        if (NumSnCategorey == 0)
                        {
                            panel_SN.Visible = false;
                            textCategoreySN.Text = string.Empty;
                            textCategoreySN.Enabled = false;

                            textQuntity.Text = string.Empty;
                            textQuntity.Enabled = true;
                        }
                        else
                        {
                            OpenPanelSN();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show("حدث خطأ أثناء تحميل السيريالات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //  حماية من حقن SQL.

            // كود أكثر تنظيمًا وقابلية للصيانة.

            // استخدام using يمنع تسرب الموارد.

            // مرونة أكبر في تعديل رؤوس الأعمدة أو العرض.

            // التعامل مع الخطأ يعرض رسالة واضحة للمستخدم.

        }





        //private void GETCategoreySN()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Clear();
        //        SqlDataAdapter da = new SqlDataAdapter("select ID,CategoryBarcode,CategoryName,CategorySN from CategorySN where CategoryName ='" + combCategorys.Text + "' ", cn);
        //        da.Fill(dt);

        //        this.dataGridView8.DataSource = dt;
        //        this.dataGridView8.Columns[0].HeaderText = "م";
        //        this.dataGridView8.Columns[1].HeaderText = "الباركود";
        //        this.dataGridView8.Columns[2].HeaderText = "الصنف";
        //        this.dataGridView8.Columns[3].HeaderText = "السريال";

        //        this.dataGridView8.Columns[0].Width = 60;
        //        this.dataGridView8.Columns[1].Width = 70;
        //        this.dataGridView8.Columns[2].Width = 200;
        //        this.dataGridView8.Columns[3].Width = 120;


        //        NumSnCategorey = dataGridView8.Rows.Count;


        //        textID_SN.Text = "0";



        //        if (NumSnCategorey == 0)
        //        {
        //            //MessageBox.Show("  لايوجد سرايل لهذا الصنف    ", "سريال", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            panel_SN.Visible = false;

        //            textCategoreySN.Text = "";
        //            textCategoreySN.Enabled = false;

        //            textQuntity.Text = "";
        //            textQuntity.Enabled = true;

        //        }
        //        else
        //        {
        //            // MessageBox.Show("  ممتاز يوجد سرايل لهذا الصنف    ", " هايل جدا سريال", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            OpenPanelSN();
        //        }



        //    }
        //    catch
        //    { }

        //}


        //============== دوال الخاصة بالكود المحسن==========
        private void ResetFields()
        {
            textBox18.Text = "0";
            textUnityCategrey.Text = "0";
            textBox20.Text = "";
            textBox21.Text = "0";

            PriceGomla = "0";
            PriceMostahlek = "0";
            textPriceKtBea.Text = "0";
            textDiscCategorey1.Text = "0";
            textDiscCategorey.Text = "0";
            textPriceShraa.Text = "0";
            txtTotalCategory2.Text = "0";
            textNear.Text = "0";
            textID_SN.Text = "0";
        }

        private void FillCategoryFields(SqlDataReader reader)
        {
            CategoryID = reader["ID"].ToString();
            textBarcode.Text = reader["Barcode"].ToString();
            textBox18.Text = reader["Quantity"].ToString();
            textBox64.Text = reader["QuantityT"].ToString();
            textUnityCategrey.Text = reader["Unity"].ToString();
            textBox20.Text = reader["Faction"].ToString();
            textBox21.Text = reader["Total"].ToString();
            textNear.Text = reader["Near"].ToString();

            PriceGomla = reader["PriceGomla"].ToString();
            PriceGomlaAlgomla = reader["PriceGomlaAlgomla"].ToString();
            PriceNesfGomla = reader["PriceNesfAlgomla"].ToString();
            PriceMostahlek = reader["PriceMostahlek"].ToString();
            textPriceShraa.Text = reader["Price"].ToString();
            FactionCatogrey = reader["Faction"].ToString();

            textBox4.Text = FormatPrice(PriceGomla);
            textBox5.Text = FormatPrice(PriceMostahlek);
        }

        private string FormatPrice(string price)
        {
            return double.TryParse(price, out double parsedPrice)
                ? Math.Round(parsedPrice, 2).ToString()
                : "0";
        }

        private void ClearEntryFields()
        {
            textQuntity.Text = "";
            textPrice.Text = "";
            txtTotalCategory.Text = "";
            textDiscCategorey1.Text = "0";
            textDiscCategorey.Text = "0";
        }

        private void ConfigureDataGridView()
        {
            string[] headers = { "الكود", "التاريخ", "ك", "الوحدة", "السعر" };
            int[] widths = { 60, 80, 50, 65, 50 };

            for (int i = 0; i < headers.Length; i++)
            {
                dataGridLastPrice.Columns[i].HeaderText = headers[i];
                dataGridLastPrice.Columns[i].Width = widths[i];
            }

            // يمكنك تفعيل هذا التنسيق حسب العملة:
            // dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";
        }

        //==============   نهاية دوال الخاصة بالكود المحسن  ==========

        private void combCategorys_TextChanged(object sender, EventArgs e)
        {
            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();

            //try
            //{
            //    string[] listCategorey = new string[] { "صنية ميلامين الشريف", "صنية استيل الشريف", "", "طبق ميلاميت", "طبق استيل الشريف", "براد شاى استيل", "معالق استيل", "طقم ميلامين الصفوة", "شنطة معالق", "طقم سكاكين" };

            //    combCategorys.DataSource = listCategorey.Where(x => x.Contains(combCategorys.Text));


            //}
            //catch
            //{ }

            //- إيجاد الكميه الاول
            textBox18.Text = "0";
            textUnityCategrey.Text = "0";
            textBox20.Text = "";
            textBox21.Text = "0";

            PriceGomla = "0";
            PriceMostahlek = "0";
            textPriceKtBea.Text = "0";
            //  textLastPrice.Text = "0";
            textDiscCategorey1.Text = "0";
            textDiscCategorey.Text = "0";

            textPriceShraa.Text = "0";
            txtTotalCategory2.Text = "0";
            textNear.Text = "0";

            textID_SN.Text = "0";


            //-----------------   ايجاد الاصناف الموجودة فقط --------------------


            try
            {


                sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "' AND Storage Like'" + Storage + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    CategoryID = reed["ID"].ToString();
                    textBarcode.Text = reed["Barcode"].ToString();
                    textBox18.Text = reed["Quantity"].ToString();
                    textBox64.Text = reed["QuantityT"].ToString();
                    textUnityCategrey.Text = reed["Unity"].ToString();
                    textBox20.Text = reed["Faction"].ToString();
                    // ComTypeCategorey.Text = reed["Faction"].ToString();
                    textBox21.Text = reed["Total"].ToString();
                    textNear.Text = reed["Near"].ToString();

                    //------------------------

                    PriceGomla = reed["PriceGomla"].ToString();
                    PriceGomlaAlgomla = reed["PriceGomlaAlgomla"].ToString();
                    PriceNesfGomla = reed["PriceNesfAlgomla"].ToString();

                    PriceMostahlek = reed["PriceMostahlek"].ToString();
                    textPriceShraa.Text = reed["Price"].ToString();
                    FactionCatogrey = reed["Faction"].ToString();

                    textBox4.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
                    textBox5.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();

                    //  textBox4.Text = PriceGomla;
                    // textBox5.Text = PriceMostahlek;
                }
                reed.Close();


                textQuntity.Text = "";
                textPrice.Text = "";
                txtTotalCategory.Text = "";
                textDiscCategorey1.Text = "0";
                textDiscCategorey.Text = "0";
                // -------------
                groupBox5.Text = combCategorys.Text;



                string Kataey = "";
                Kataey = AppSetting.textKataey;
                if (Kataey == "1") // قطاعى
                {
                    ComTypeCategorey.Text = FactionCatogrey;
                }
                else
                {
                    //  كرتونه
                    ComTypeCategorey.Text = "كرتونه";

                }

            }
            catch
            {

            }


            //----------------- الكرتونةوالدسته والقطع

            GetPriceKtBea();
            GetQuntity();

            GETCategoreySN();

            try
            {


                //-------------  ايجاد اخر سعر--------
                if (FormName == "فاتورة مبيعات")
                {
                    //try
                    //{
                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + comClient.Text + "'", cn);
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
                    this.dataGridLastPrice.Columns[3].Width = 65;
                    this.dataGridLastPrice.Columns[4].Width = 50;



                    dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                }
                else if (FormName == "مردودات مشتريات") //----------- فاتورة مردودات مشتريات
                {

                    try
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing1 where Category ='" + combCategorys.Text + "' AND ClientName ='" + comClient.Text + "'", cn);
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


                        int num = dataGridLastPrice.Rows.Count - 2;

                        //  textBox3.Text = num.ToString();

                        textPrice.Text = "";

                        textPrice.Text = dataGridLastPrice.Rows[num].Cells[4].Value.ToString();

                    }
                    catch
                    {

                    }

                }





            }
            catch
            { }


            // cn.Close();

        }

        private void butSum_Click(object sender, EventArgs e)
        {
            try
            {
                double n = Convert.ToDouble(textQuntity.Text);
                double d = Convert.ToDouble(textPrice.Text);
                double r = n * d;
                txtTotalCategory.Text = r.ToString();

            }

            catch (FormatException)
            {
                MessageBox.Show("you must enter the number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chBoxDeletCat.Checked == true)
            {
                string Number = "";
                Storage = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                combCategorys.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                Number = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (combCategorys.Text == "")

                {

                }
                else
                {
                    if (Storage == "خارج المخزن") // صنف خارج المخزن
                    {
                        // MessageBox.Show(" خارج المخزن");

                        // البحث عن الصنف فى الفاتورة 


                        sqlCommand1.CommandText = "select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "' ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            NumCategery = reed["Num"].ToString();
                            textQuntity.Text = reed["Quantity"].ToString();
                            textPrice.Text = reed["Price"].ToString();
                            ComTypeCategorey.Text = reed["Type"].ToString();
                            textDiscCategorey1.Text = reed["Discount"].ToString();
                            txtTotalCategory.Text = reed["Total"].ToString();
                            Storage = reed["Storage"].ToString();
                            textCategoreySN.Text = reed["CategorySN"].ToString();
                        }
                        reed.Close();

                        // حذف الصنف من الفاتورة

                        sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة

                        sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الارباح

                        sqlCommand1.CommandText = "delete from Profit where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        //  حذف الصنف من جدول الحركة الجديده

                        sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        //--- حساب الاجمالى
                        double n = Convert.ToDouble(txtTotalBill.Text);
                        double d = Convert.ToDouble(txtTotalCategory.Text);
                        double r = n - d;
                        txtTotalBill.Text = r.ToString();

                        double nn = Convert.ToDouble(TotalAndRemaninRasedClient);
                        double dd = Convert.ToDouble(txtTotalCategory.Text);
                        double rr = nn - dd;
                        TotalAndRemaninRasedClient = rr.ToString();


                        double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                        // double dd = Convert.ToDouble(textBox3.Text);
                        double rrr = nnn - 1;
                        TxtNumCategorey.Text = rrr.ToString();

                        sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();



                        // ايجاد الاصناف فى الفاتورة
                        //------------------------------------
                        dt11.Clear();
                        SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                        da11.Fill(dt11);
                        this.dataGridView2.DataSource = dt11;
                        //------------------------------------
                    }
                    else  // صنف من المخزن
                    {
                        // البحث عن الصنف فى الفاتورة 


                        sqlCommand1.CommandText = "select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "' ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            NumCategery = reed["Num"].ToString();
                            textQuntity.Text = reed["Quantity"].ToString();
                            textPrice.Text = reed["Price"].ToString();
                            ComTypeCategorey.Text = reed["Type"].ToString();
                            textDiscCategorey1.Text = reed["Discount"].ToString();
                            txtTotalCategory.Text = reed["Total"].ToString();
                            Storage = reed["Storage"].ToString();

                            textCategoreySN.Text = reed["CategorySN"].ToString();
                        }
                        reed.Close();

                        // حذف الصنف من الفاتورة

                        sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة

                        sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الارباح

                        sqlCommand1.CommandText = "delete from Profit where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        //  حذف الصنف من جدول الحركة الجديده

                        sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        //--- حساب الاجمالى
                        double n = Convert.ToDouble(txtTotalBill.Text);
                        double d = Convert.ToDouble(txtTotalCategory.Text);
                        double r = n - d;
                        txtTotalBill.Text = r.ToString();

                        double nn = Convert.ToDouble(TotalAndRemaninRasedClient);
                        double dd = Convert.ToDouble(txtTotalCategory.Text);
                        double rr = nn - dd;
                        TotalAndRemaninRasedClient = rr.ToString();


                        double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                        // double dd = Convert.ToDouble(textBox3.Text);
                        double rrr = nnn - 1;
                        TxtNumCategorey.Text = rrr.ToString();


                        //- إيجاد الكميه الفعلية الموجودة بالمخزن

                        sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "'and Storage like '" + Storage + "'   ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            CategoryID = reed["ID"].ToString();
                            textBox18.Text = reed["Quantity"].ToString();
                            textUnityCategrey.Text = reed["Unity"].ToString();
                            textBox20.Text = reed["Faction"].ToString();
                            textBox21.Text = reed["Total"].ToString();

                        }
                        reed.Close();


                        // -------------
                        groupBox5.Text = combCategorys.Text;


                        if (ComTypeCategorey.Text == "كرتونه")
                        {


                            double sn = Convert.ToDouble(textQuntity.Text);
                            double sd = Convert.ToDouble(textBox18.Text);
                            double sr = sn + sd;
                            textBox18.Text = sr.ToString();

                            double an = Convert.ToDouble(textQuntity.Text);
                            double ad = Convert.ToDouble(textUnityCategrey.Text);
                            double ar = an * ad;
                            //textBox25.Text = ar.ToString();

                            //double qn = Convert.ToDouble(textBox25.Text);
                            double qd = Convert.ToDouble(textBox21.Text);
                            double qr = ar + qd;
                            textBox21.Text = qr.ToString();



                            sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',  Total ='" + textBox21.Text + "'  where Category='" + combCategorys.Text + "'and Storage like '" + Storage + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة
                            //------------------------------------
                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;
                            //------------------------------------

                        }
                        else
                        {

                            double sn = Convert.ToDouble(textQuntity.Text);
                            double bn = Convert.ToDouble(textUnityBeea.Text);
                            double sd = Convert.ToDouble(textBox21.Text);
                            double sr = (sn * bn) + sd;
                            textBox21.Text = sr.ToString();

                            // معرفة كمية الاجمالى بعد الخصم

                            int jjs = int.Parse(textBox21.Text);
                            int jsj = int.Parse(textUnityCategrey.Text);
                            int sjj = jjs / jsj;
                            textBox18.Text = sjj.ToString();

                            sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',  Total ='" + textBox21.Text + "'  where Category='" + combCategorys.Text + "'and Storage like '" + Storage + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة
                            //------------------------------------
                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;
                            //------------------------------------


                        }
                    }
                }

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



                // حساب المتبقى
                CountRemaining();


                if (TxtNumCategorey.Text == "0")// لايوجد اصناف فى الفاتورة
                {
                   

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

                    txtMosadad.Text = "0";

                    //------- حذف رقم الفاتورة
                    textBillingDataNumBill.Text = "";

                }
                else
                {
                    // تحديث بيانات الفاتورة
                    if (FormName == "فاتورة مبيعات")
                    {
                        sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (FormName == "مردودات مشتريات")
                    {
                        sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }

                    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
                    sqlCommand1.ExecuteNonQuery();
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


                //---------------- اضافة السريال مرة اخرى

                if (textCategoreySN.Text == "")
                {

                }
                else
                {
                    sqlCommand1.CommandText = "insert into CategorySN (CategorySN,CategoryBarcode,CategoryName)values ('" + textCategoreySN.Text + "','" + textBarcode.Text + "','" + combCategorys.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }

            }
            else
            {

            }
        }

        private void comClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                combCategorys.Focus();

            }
            else
            { }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            //textMoveBoxID.Text = MoveBoxID;

            //MessageBox.Show( MoveBoxID, "MoveBoxID 3973", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (txtDic.Text == "")
            {
                txtDic.Text = "0";
            }

            if (DiscountBill == "")
            {
                DiscountBill = "0";

                CountRemaining();

                // تحديث بيانات الفاتورة
                if (FormName == "فاتورة مبيعات")
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "'  where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }
                else if (FormName == "مردودات مشتريات")
                {
                    sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "', State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
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

                //----------  إضافة حركة الصندوق

                // -----   جلب دالة اضافة المسدد الى الرصيد فى الصندوق

                AddOrUpdateBoxMove();

                // ============ القديم
                //try
                //{
                //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
                //    sqlCommand1.ExecuteNonQuery();
                //}
                //catch
                //{
                //    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
                //    sqlCommand1.ExecuteNonQuery();
                //}


            }
            else
            {
                double a = Convert.ToDouble(DiscountBill); // الخصم الافتراضى
                double b = Convert.ToDouble(textDiscount.Text); // خصم الفاتورة

                if (a >= b)
                {
                    CountRemaining();

                    // تحديث بيانات الفاتورة
                    if (FormName == "فاتورة مبيعات")
                    {
                        sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "'  where NumBill='" + textBillingDataNumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (FormName == "مردودات مشتريات")
                    {
                        sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "', State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
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

                    //----------  إضافة حركة الصندوق

                    // -----   جلب دالة اضافة المسدد الى الرصيد فى الصندوق

                    AddOrUpdateBoxMove();

                    //try
                    //{
                    //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
                    //    sqlCommand1.ExecuteNonQuery();
                    //}
                    //catch
                    //{
                    //    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
                    //    sqlCommand1.ExecuteNonQuery();
                    //}



                }
                else
                {
                    MessageBox.Show("   خصم الفاتورة اكبر من الخصم الافتراضى =       " + DiscountBill, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDic.Focus();
                }
            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            //this.Close();

            //TransferData.FormName = "فاتورة مبيعات";

            //if (Sales1 == null || Sales1.IsDisposed == true)
            //{
            //    Sales1 = new Sales();
            //}
            //Sales1.MdiParent = Main.ActiveForm;
            //Sales1.Show();


            string textOpenFormOther = AppSetting.OpenFormOther;

            if (textOpenFormOther == "0")
            {
                this.Close();

                TransferData.FormName = "فاتورة مبيعات";

                if (Sales1 == null || Sales1.IsDisposed == true)
                {
                    Sales1 = new Sales();
                }
                Sales1.MdiParent = Main.ActiveForm;
                Sales1.Show();
            }
            else if (textOpenFormOther == "1")
            {
                // this.Close();

                TransferData.FormName = "فاتورة مبيعات";


                Sales1 = new Sales();

                Sales1.MdiParent = Main.ActiveForm;
                Sales1.Show();
            }
            else
            { }





        }

        private void Sales_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void textQuntity_TextChanged(object sender, EventArgs e)
        {
            //GetPricesAndQuntity();

            // GetPriceKtBea();
            GetQuntity();

            //if (textPriceKtBea.Text == "")
            //{

            //    textPriceKtBea.Text = "0";
            //}
            //else
            //{ }

            ////----------------- الكرتونةوالدسته والقطع

            //if (ComTypeCategorey.Text == "كرتونه")
            //{

            //    //--- حساب سعر البيع والشراء

            //    //-- البيع
            //    textUnityBeea.Text = textUnityCategrey.Text;

            //    try
            //    {
            //        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
            //        double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //        double rcsr = ncsn * dcsd;
            //        textPrice.Text = rcsr.ToString();

            //        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

            //        //----------- سعر الشراء

            //        double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //        double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //        double rcssr = ncssn * dcssd;
            //        textPriceSH.Text = rcssr.ToString();

            //        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();

            //    }
            //    catch
            //    { }

            //    //------------ حساب عدد القطع بع كتابة الكمية

            //    if (textQuntity.Text == "")
            //    {
            //        //textBox1.Text = "0";
            //        //double a = Convert.ToDouble(textBox1.Text);
            //        //double b = Convert.ToDouble(textBox68.Text);
            //        //double c = a * b;
            //        //textBox69.Text = c.ToString();

            //        //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();
            //        textQuntityProfit.Text = "0";
            //    }
            //    else
            //    {
            //        double a = Convert.ToDouble(textQuntity.Text);
            //        double b = Convert.ToDouble(textUnityBeea.Text);
            //        double c = a * b;
            //        textQuntityProfit.Text = c.ToString();

            //        textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 2).ToString();

            //    }

            //}
            //else if (ComTypeCategorey.Text == "دسته")
            //{
            //    //--- حساب سعر البيع والشراء

            //    //-- البيع

            //    textUnityBeea.Text = "12";

            //    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
            //    double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcsr = ncsn * dcsd;
            //    textPrice.Text = rcsr.ToString();

            //    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 4).ToString();

            //    //----------- سعر الشراء

            //    double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //    double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcssr = ncssn * dcssd;
            //    textPriceSH.Text = rcssr.ToString();

            //    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 4).ToString();

            //    //------------ حساب عدد القطع بع كتابة الكمية
            //    if (textQuntity.Text == "")
            //    {
            //        //textBox1.Text = "0";
            //        //double a = Convert.ToDouble(textBox1.Text);
            //        //double b = Convert.ToDouble(textBox68.Text);
            //        //double c = a * b;
            //        //textBox69.Text = c.ToString();

            //        //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();
            //        textQuntityProfit.Text = "0";
            //    }
            //    else
            //    {
            //        double a = Convert.ToDouble(textQuntity.Text);
            //        double b = Convert.ToDouble(textUnityBeea.Text);
            //        double c = a * b;
            //        textQuntityProfit.Text = c.ToString();

            //        textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 2).ToString();

            //    }
            //}
            //else// if (comboBox3.Text == "قطعه")
            //{
            //    //--- حساب سعر البيع والشراء

            //    //-- البيع

            //    textUnityBeea.Text = "1";

            //    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
            //    double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcsr = ncsn * dcsd;
            //    textPrice.Text = rcsr.ToString();

            //    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 4).ToString();

            //    //----------- سعر الشراء

            //    double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //    double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcssr = ncssn * dcssd;
            //    textPriceSH.Text = rcssr.ToString();

            //    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 4).ToString();

            //    //------------ حساب عدد القطع بع كتابة الكمية

            //    if (textQuntity.Text == "")
            //    {

            //        textQuntityProfit.Text = "0";
            //    }
            //    else
            //    {
            //        try
            //        {
            //            double a = Convert.ToDouble(textQuntity.Text);
            //            double b = Convert.ToDouble(textUnityBeea.Text);
            //            double c = a * b;
            //            textQuntityProfit.Text = c.ToString();

            //            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 2).ToString();
            //        }
            //        catch
            //        {

            //        }



            //    }
            //}


            //----------- حساب الاجمالى ------------
            try
            {


                //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPrice.Text);
                double mm = Convert.ToDouble(textDiscCategorey.Text);
                double rr = (nn * dd) - (nn * mm);

                txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();




            }

            catch (FormatException)
            {
                // MessageBox.Show("you must enter the number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //--------- حساب ربح الصنف
            RebhCategory();

        }
        private void RebhCategory()
        {
            //----------- حساب ربح الصنف
            //if (radBtPriceGomla.Checked == true)
            //{
            //    textPriceKtBea.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
            //}
            //else if (radioBtPriceMostahlek.Checked == true)
            //{
            //    textPriceKtBea.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();
            //}


            // textPriceKtBea.Text = textPrice.Text;

            // textQuntityProfit.Text = textQuntity.Text;


            try
            {
                double bb = Convert.ToDouble(textPriceKtBea.Text);
                double cc = Convert.ToDouble(textQuntityProfit.Text);
                double gg = bb * cc;
                txtTotalCategory2.Text = gg.ToString();
                txtTotalCategory2.Text = Math.Round(double.Parse(txtTotalCategory2.Text), 2).ToString();

                double aas = Convert.ToDouble(textPriceShraa.Text);
                double b = Convert.ToDouble(textQuntityProfit.Text);
                double dd = aas * b;
                textBox46.Text = dd.ToString();
                textBox46.Text = Math.Round(double.Parse(textBox46.Text), 2).ToString();


                double x = Convert.ToDouble(txtTotalCategory2.Text);
                double y = Convert.ToDouble(textBox46.Text);
                double z = x - y;
                textBox47.Text = z.ToString();
                textBox47.Text = Math.Round(double.Parse(textBox47.Text), 2).ToString();
            }
            catch
            {

            }
        }

        private void GetPriceKtBea()
        {
            //try
            //{
            //    if (radBtPriceGomla.Checked == true)
            //    {
            //        textPriceKtBea.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
            //    }
            //    else if (radBtPriceGomlaAlgomla.Checked == true)
            //    {

            //        textPriceKtBea.Text = Math.Round(double.Parse(PriceGomlaAlgomla), 2).ToString();
            //    }
            //    else if (radBtPriceNesfGomla.Checked == true)
            //    {

            //        textPriceKtBea.Text = Math.Round(double.Parse(PriceNesfGomla), 2).ToString();
            //    }
            //    else if (radioBtPriceMostahlek.Checked == true)
            //    {

            //        textPriceKtBea.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();
            //    }
            //}
            //catch
            //{ }

            //================ الكود المحسن  ==============

            try
            {
                string selectedPrice = "";

                if (radBtPriceGomla.Checked)
                    selectedPrice = PriceGomla;
                else if (radBtPriceGomlaAlgomla.Checked)
                    selectedPrice = PriceGomlaAlgomla;
                else if (radBtPriceNesfGomla.Checked)
                    selectedPrice = PriceNesfGomla;
                else if (radioBtPriceMostahlek.Checked)
                    selectedPrice = PriceMostahlek;

                if (double.TryParse(selectedPrice, out double price))
                {
                    textPriceKtBea.Text = Math.Round(price, 2).ToString();
                }
                else
                {
                    textPriceKtBea.Text = "0";
                    // MessageBox.Show("قيمة السعر غير صحيحة أو غير رقمية.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("حدث خطأ أثناء تحديد السعر: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // استخدام TryParse لتفادي الاستثناءات عند التحويل.

            //تقليل التكرار في كتابة textPriceKtBea.Text = ....عرض رسالة للمستخدم عند وجود خطأ أو قيمة غير صحيحة.

            //مرونة أكبر في التوسعة المستقبلية إذا أُضيفت خيارات أسعار أخرى.


        }

        /// <summary>
        /// دالة مساعدة لحساب حاصل ضرب رقمين مع التحقق من صحتهما.
        /// </summary>
        private bool TryCalculate(string aText, string bText, out double result)
        {
            result = 0;
            if (double.TryParse(aText, out double a) && double.TryParse(bText, out double b))
            {
                result = a * b;
                return true;
            }
            return false;
        }

        private void GetQuntity()
        {
            // التأكد من أن السعر غير فارغ
            if (string.IsNullOrWhiteSpace(textPriceKtBea.Text))
                textPriceKtBea.Text = "0";

            // تحديد قيمة الوحدة بناءً على النوع
            switch (ComTypeCategorey.Text)
            {
                case "كرتونه":
                    textUnityBeea.Text = textUnityCategrey.Text;
                    break;
                case "دسته":
                    textUnityBeea.Text = "12";
                    break;
                default: // قطعه
                    textUnityBeea.Text = "1";
                    break;
            }

            // تنفيذ الحسابات
            if (TryCalculate(textPriceKtBea.Text, textUnityBeea.Text, out double salePrice))
                textPrice.Text = salePrice.ToString();
            //textPrice.Text = salePrice.ToString("F2");  //تنسيق موحد للأرقام باستخدام "F2"(رقمين بعد الفاصلة).
            else
                textPrice.Text = "0";

            if (TryCalculate(textPriceShraa.Text, textUnityBeea.Text, out double purchasePrice))
                textPriceSH.Text = purchasePrice.ToString();
            else
                textPriceSH.Text = "0";

            // حساب عدد القطع الناتجة من الكمية
            if (TryCalculate(textQuntity.Text, textUnityBeea.Text, out double totalUnits))
                textQuntityProfit.Text = totalUnits.ToString();
            else
                textQuntityProfit.Text = "0";


            //  تقليل التكرار بنسبة كبيرة.

            //تسهيل الصيانة المستقبلية.

            //تقليل احتمالية الأخطاء بسبب التحويلات.

            //تنسيق موحد للأرقام باستخدام "F2"(رقمين بعد الفاصلة).

            //التوسع مستقبلاً أسهل(مثلاً إضافة نوع جديد للوحدة).
        }


        //private void GetQuntity()
        //{


        //    if (textPriceKtBea.Text == "")
        //    {

        //        textPriceKtBea.Text = "0";
        //    }
        //    else
        //    { }

        //    //------------------------------ الدسته

        //    if (ComTypeCategorey.Text == "كرتونه")
        //    {
        //        textUnityBeea.Text = textUnityCategrey.Text;
        //        try
        //        {

        //            double ncsn = Convert.ToDouble(textPriceKtBea.Text);  // سعر القطعه للبيع
        //            double dcsd = Convert.ToDouble(textUnityBeea.Text);
        //            double rcsr = ncsn * dcsd;
        //            textPrice.Text = rcsr.ToString();  // السعر

        //            textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

        //            //----------- سعر الشراء

        //            double ncssn = Convert.ToDouble(textPriceShraa.Text);
        //            double dcssd = Convert.ToDouble(textUnityBeea.Text);
        //            double rcssr = ncssn * dcssd;
        //            textPriceSH.Text = rcssr.ToString();

        //            textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();

        //            //------------ حساب عدد القطع بع كتابة الكمية
        //            if (textQuntity.Text == "")
        //            {
        //                //textBox1.Text = "0";
        //                //double a = Convert.ToDouble(textBox1.Text);
        //                //double b = Convert.ToDouble(textBox68.Text);
        //                //double c = a * b;
        //                //textBox69.Text = c.ToString();

        //                //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();
        //                textQuntityProfit.Text = "0";
        //            }
        //            else
        //            {
        //                double a = Convert.ToDouble(textQuntity.Text);
        //                double b = Convert.ToDouble(textUnityBeea.Text);
        //                double c = a * b;
        //                textQuntityProfit.Text = c.ToString();

        //                textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 2).ToString();

        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }
        //    else if (ComTypeCategorey.Text == "دسته")
        //    {

        //        textUnityBeea.Text = "12";

        //        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
        //        double dcsd = Convert.ToDouble(textUnityBeea.Text);
        //        double rcsr = ncsn * dcsd;
        //        textPrice.Text = rcsr.ToString();

        //        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

        //        //----------- سعر الشراء

        //        double ncssn = Convert.ToDouble(textPriceShraa.Text);
        //        double dcssd = Convert.ToDouble(textUnityBeea.Text);
        //        double rcssr = ncssn * dcssd;
        //        textPriceSH.Text = rcssr.ToString();

        //        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();
        //        //------------ حساب عدد القطع بع كتابة الكمية
        //        if (textQuntity.Text == "")
        //        {
        //            //textBox1.Text = "0";
        //            //double a = Convert.ToDouble(textBox1.Text);
        //            //double b = Convert.ToDouble(textBox68.Text);
        //            //double c = a * b;
        //            //textBox69.Text = c.ToString();

        //            //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();
        //            textQuntityProfit.Text = "0";
        //        }
        //        else
        //        {
        //            double a = Convert.ToDouble(textQuntity.Text);
        //            double b = Convert.ToDouble(textUnityBeea.Text);
        //            double c = a * b;
        //            textQuntityProfit.Text = c.ToString();

        //            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 2).ToString();

        //        }
        //    }
        //    else /*if (ComTypeCategorey.Text == "قطعه")*/
        //    {
        //        textUnityBeea.Text = "1";

        //        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
        //        double dcsd = Convert.ToDouble(textUnityBeea.Text);
        //        double rcsr = ncsn * dcsd;
        //        textPrice.Text = rcsr.ToString();

        //        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

        //        //----------- سعر الشراء

        //        double ncssn = Convert.ToDouble(textPriceShraa.Text);
        //        double dcssd = Convert.ToDouble(textUnityBeea.Text);
        //        double rcssr = ncssn * dcssd;
        //        textPriceSH.Text = rcssr.ToString();

        //        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();
        //        //------------ حساب عدد القطع بع كتابة الكمية
        //        if (textQuntity.Text == "")
        //        {
        //            //textBox1.Text = "0";
        //            //double a = Convert.ToDouble(textBox1.Text);
        //            //double b = Convert.ToDouble(textBox68.Text);
        //            //double c = a * b;
        //            //textBox69.Text = c.ToString();

        //            //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();

        //            textQuntityProfit.Text = "0";
        //        }
        //        else
        //        {
        //            double a = Convert.ToDouble(textQuntity.Text);
        //            double b = Convert.ToDouble(textUnityBeea.Text);
        //            double c = a * b;
        //            textQuntityProfit.Text = c.ToString();

        //            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 2).ToString();

        //        }
        //    }
        //}


        private void ComTypeCategorey_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetPricesAndQuntity();

            GetPriceKtBea();
            GetQuntity();


            //if (textPriceKtBea.Text == "")
            //{

            //    textPriceKtBea.Text = "0";
            //}
            //else
            //{ }

            ////------------------------------ الدسته

            //if (ComTypeCategorey.Text == "كرتونه")
            //{
            //    textUnityBeea.Text = textUnityCategrey.Text;
            //    try
            //    {

            //        double ncsn = Convert.ToDouble(textPriceKtBea.Text);  // سعر القطعه للبيع
            //        double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //        double rcsr = ncsn * dcsd;
            //        textPrice.Text = rcsr.ToString();  // السعر

            //        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

            //        //----------- سعر الشراء

            //        double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //        double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //        double rcssr = ncssn * dcssd;
            //        textPriceSH.Text = rcssr.ToString();

            //        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();

            //        //------------ حساب عدد القطع بع كتابة الكمية
            //        if (textQuntity.Text == "")
            //        {
            //            //textBox1.Text = "0";
            //            //double a = Convert.ToDouble(textBox1.Text);
            //            //double b = Convert.ToDouble(textBox68.Text);
            //            //double c = a * b;
            //            //textBox69.Text = c.ToString();

            //            //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();
            //            textQuntityProfit.Text = "0";
            //        }
            //        else
            //        {
            //            double a = Convert.ToDouble(textQuntity.Text);
            //            double b = Convert.ToDouble(textUnityBeea.Text);
            //            double c = a * b;
            //            textQuntityProfit.Text = c.ToString();

            //            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
            //else if (ComTypeCategorey.Text == "دسته")
            //{

            //    textUnityBeea.Text = "12";

            //    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
            //    double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcsr = ncsn * dcsd;
            //    textPrice.Text = rcsr.ToString();

            //    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

            //    //----------- سعر الشراء

            //    double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //    double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcssr = ncssn * dcssd;
            //    textPriceSH.Text = rcssr.ToString();

            //    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();
            //    //------------ حساب عدد القطع بع كتابة الكمية
            //    if (textQuntity.Text == "")
            //    {
            //        //textBox1.Text = "0";
            //        //double a = Convert.ToDouble(textBox1.Text);
            //        //double b = Convert.ToDouble(textBox68.Text);
            //        //double c = a * b;
            //        //textBox69.Text = c.ToString();

            //        //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();
            //        textQuntityProfit.Text = "0";
            //    }
            //    else
            //    {
            //        double a = Convert.ToDouble(textQuntity.Text);
            //        double b = Convert.ToDouble(textUnityBeea.Text);
            //        double c = a * b;
            //        textQuntityProfit.Text = c.ToString();

            //        textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

            //    }
            //}
            //else /*if (ComTypeCategorey.Text == "قطعه")*/
            //{
            //    textUnityBeea.Text = "1";

            //    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
            //    double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcsr = ncsn * dcsd;
            //    textPrice.Text = rcsr.ToString();

            //    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

            //    //----------- سعر الشراء

            //    double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //    double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcssr = ncssn * dcssd;
            //    textPriceSH.Text = rcssr.ToString();

            //    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();
            //    //------------ حساب عدد القطع بع كتابة الكمية
            //    if (textQuntity.Text == "")
            //    {
            //        //textBox1.Text = "0";
            //        //double a = Convert.ToDouble(textBox1.Text);
            //        //double b = Convert.ToDouble(textBox68.Text);
            //        //double c = a * b;
            //        //textBox69.Text = c.ToString();

            //        //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();

            //        textQuntityProfit.Text = "0";
            //    }
            //    else
            //    {
            //        double a = Convert.ToDouble(textQuntity.Text);
            //        double b = Convert.ToDouble(textUnityBeea.Text);
            //        double c = a * b;
            //        textQuntityProfit.Text = c.ToString();

            //        textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

            //    }
            //}





            //else if (ComTypeCategorey.Text == "طقم")
            //{
            //    textUnityBeea.Text = "1";

            //    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
            //    double dcsd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcsr = ncsn * dcsd;
            //    textPrice.Text = rcsr.ToString();

            //    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();

            //    //----------- سعر الشراء

            //    double ncssn = Convert.ToDouble(textPriceShraa.Text);
            //    double dcssd = Convert.ToDouble(textUnityBeea.Text);
            //    double rcssr = ncssn * dcssd;
            //    textPriceSH.Text = rcssr.ToString();

            //    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();
            //    //------------ حساب عدد القطع بع كتابة الكمية
            //    if (textQuntity.Text == "")
            //    {
            //        //textBox1.Text = "0";
            //        //double a = Convert.ToDouble(textBox1.Text);
            //        //double b = Convert.ToDouble(textBox68.Text);
            //        //double c = a * b;
            //        //textBox69.Text = c.ToString();

            //        //textBox69.Text = Math.Round(double.Parse(textBox69.Text), 0).ToString();

            //        textQuntityProfit.Text = "0";
            //    }
            //    else
            //    {
            //        double a = Convert.ToDouble(textQuntity.Text);
            //        double b = Convert.ToDouble(textUnityBeea.Text);
            //        double c = a * b;
            //        textQuntityProfit.Text = c.ToString();

            //        textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panelDiscount.Visible == true)
            {
                panelDiscount.Visible = false;

            }
            else
            {

                panelDiscount.Visible = true;
            }
        }

        private void textBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    combCategorys.Text = "";

                    if (radioB_Program.Checked == true)
                    {
                        sqlCommand1.CommandText = "select * from Category where Barcode ='" + textBarcode.Text + "' AND Storage Like'" + Storage + "'   ";
                        reeeed = sqlCommand1.ExecuteReader();
                        while (reeeed.Read())
                        {

                            combCategorys.Text = reeeed["Category"].ToString();

                        }
                        reeeed.Close();
                    }
                    else if (radioB_Factory.Checked == true)
                    {
                        sqlCommand1.CommandText = "select * from Category where Barcode_Factory ='" + textBarcode.Text + "' AND Storage Like'" + Storage + "'   ";
                        reeeed = sqlCommand1.ExecuteReader();
                        while (reeeed.Read())
                        {

                            combCategorys.Text = reeeed["Category"].ToString();

                        }
                        reeeed.Close();
                    }


                    //***************************************

                    //- إيجاد الكميه الاول
                    textBox18.Text = "0";
                    textUnityCategrey.Text = "0";
                    textBox20.Text = "";
                    textBox21.Text = "0";

                    PriceGomla = "0";
                    PriceGomlaAlgomla = "0";
                    PriceNesfGomla = "0";
                    PriceMostahlek = "0";
                    textPriceKtBea.Text = "0";
                    //  textLastPrice.Text = "0";
                    textDiscCategorey1.Text = "0";
                    textDiscCategorey.Text = "0";

                    textPriceShraa.Text = "0";
                    try
                    {
                        sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "' AND Storage Like'" + Storage + "'   ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            CategoryID = reed["ID"].ToString();
                            textBox18.Text = reed["Quantity"].ToString();
                            textBox64.Text = reed["QuantityT"].ToString();
                            textUnityCategrey.Text = reed["Unity"].ToString();
                            textBox20.Text = reed["Faction"].ToString();
                            textBox21.Text = reed["Total"].ToString();

                            //-----------------------------

                            PriceGomla = reed["PriceGomla"].ToString();

                            PriceGomlaAlgomla = reed["PriceNesfAlgomla"].ToString();
                            PriceNesfGomla = reed["PriceMostahlek"].ToString();


                            PriceMostahlek = reed["PriceMostahlek"].ToString();
                            textPriceShraa.Text = reed["Price"].ToString();
                            FactionCatogrey = reed["Faction"].ToString();
                        }
                        reed.Close();

                        textQuntity.Text = "";
                        textPrice.Text = "";
                        txtTotalCategory.Text = "";
                        textDiscCategorey1.Text = "0";
                        textDiscCategorey.Text = "0";
                        // -------------
                        groupBox5.Text = combCategorys.Text;
                    }
                    catch
                    {

                    }


                    if (radBtPriceGomla.Checked == true)
                    {
                        textPriceKtBea.Text = PriceGomla;
                        textPrice.Text = PriceGomla;
                    }

                    else if (radBtPriceGomlaAlgomla.Checked == true)
                    {
                        textPriceKtBea.Text = PriceGomlaAlgomla;
                        textPrice.Text = PriceGomlaAlgomla;
                    }

                    else if (radBtPriceNesfGomla.Checked == true)
                    {
                        textPriceKtBea.Text = PriceNesfGomla;
                        textPrice.Text = PriceNesfGomla;
                    }

                    else if (radioBtPriceMostahlek.Checked == true)
                    {
                        textPriceKtBea.Text = PriceMostahlek;
                        textPrice.Text = PriceMostahlek;
                    }
                    else
                    { }


                    //----------------- الكرتونةوالدسته والقطع

                    if (ComTypeCategorey.Text == "كرتونه")
                    {
                        textUnityBeea.Text = textUnityCategrey.Text;

                        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                        double dcsd = Convert.ToDouble(textUnityBeea.Text);
                        double rcsr = ncsn * dcsd;
                        textPrice.Text = rcsr.ToString();

                        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 4).ToString();

                        //----------- سعر الشراء

                        double ncssn = Convert.ToDouble(textPriceShraa.Text);
                        double dcssd = Convert.ToDouble(textUnityBeea.Text);
                        double rcssr = ncssn * dcssd;
                        textPriceSH.Text = rcssr.ToString();

                        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 4).ToString();

                        //------------ حساب عدد القطع بع كتابة الكمية
                        if (textQuntity.Text == "")
                        {

                            textQuntityProfit.Text = "0";
                        }
                        else
                        {
                            double a = Convert.ToDouble(textQuntity.Text);
                            double b = Convert.ToDouble(textUnityBeea.Text);
                            double c = a * b;
                            textQuntityProfit.Text = c.ToString();

                            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

                        }
                    }
                    else if (ComTypeCategorey.Text == "دسته")
                    {

                        textUnityBeea.Text = "12";

                        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                        double dcsd = Convert.ToDouble(textUnityBeea.Text);
                        double rcsr = ncsn * dcsd;
                        textPrice.Text = rcsr.ToString();

                        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 4).ToString();

                        //----------- سعر الشراء

                        double ncssn = Convert.ToDouble(textPriceShraa.Text);
                        double dcssd = Convert.ToDouble(textUnityBeea.Text);
                        double rcssr = ncssn * dcssd;
                        textPriceSH.Text = rcssr.ToString();

                        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 4).ToString();

                        //------------ حساب عدد القطع بع كتابة الكمية
                        if (textQuntity.Text == "")
                        {

                            textQuntityProfit.Text = "0";
                        }
                        else
                        {
                            double a = Convert.ToDouble(textQuntity.Text);
                            double b = Convert.ToDouble(textUnityBeea.Text);
                            double c = a * b;
                            textQuntityProfit.Text = c.ToString();

                            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

                        }
                    }
                    else if (ComTypeCategorey.Text == "قطعه")
                    {
                        textUnityBeea.Text = "1";

                        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                        double dcsd = Convert.ToDouble(textUnityBeea.Text);
                        double rcsr = ncsn * dcsd;
                        textPrice.Text = rcsr.ToString();

                        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 4).ToString();

                        //----------- سعر الشراء

                        double ncssn = Convert.ToDouble(textPriceShraa.Text);
                        double dcssd = Convert.ToDouble(textUnityBeea.Text);
                        double rcssr = ncssn * dcssd;
                        textPriceSH.Text = rcssr.ToString();

                        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 4).ToString();

                        //------------ حساب عدد القطع بع كتابة الكمية
                        if (textQuntity.Text == "")
                        {
                            textQuntityProfit.Text = "0";
                        }
                        else
                        {
                            double a = Convert.ToDouble(textQuntity.Text);
                            double b = Convert.ToDouble(textUnityBeea.Text);
                            double c = a * b;
                            textQuntityProfit.Text = c.ToString();

                            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

                        }
                    }
                    else if (ComTypeCategorey.Text == "طقم")
                    {
                        textUnityBeea.Text = "1";

                        double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                        double dcsd = Convert.ToDouble(textUnityBeea.Text);
                        double rcsr = ncsn * dcsd;
                        textPrice.Text = rcsr.ToString();

                        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 4).ToString();

                        //----------- سعر الشراء

                        double ncssn = Convert.ToDouble(textPriceShraa.Text);
                        double dcssd = Convert.ToDouble(textUnityBeea.Text);
                        double rcssr = ncssn * dcssd;
                        textPriceSH.Text = rcssr.ToString();

                        textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 4).ToString();

                        //------------ حساب عدد القطع بع كتابة الكمية
                        if (textQuntity.Text == "")
                        {

                            textQuntityProfit.Text = "0";
                        }
                        else
                        {
                            double a = Convert.ToDouble(textQuntity.Text);
                            double b = Convert.ToDouble(textUnityBeea.Text);
                            double c = a * b;
                            textQuntityProfit.Text = c.ToString();

                            textQuntityProfit.Text = Math.Round(double.Parse(textQuntityProfit.Text), 0).ToString();

                        }
                    }



                    try
                    {
                        //DataTable dt = new DataTable();
                        //dt.Clear();
                        //SqlDataAdapter da = new SqlDataAdapter("select * from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + comClient.Text + "'", cn);
                        //da.Fill(dt);
                        //this.dataGridLastPrice.DataSource = dt;

                        //dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                        DataTable dt = new DataTable();
                        dt.Clear();
                        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + comClient.Text + "'", cn);
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
                        this.dataGridLastPrice.Columns[3].Width = 65;
                        this.dataGridLastPrice.Columns[4].Width = 50;



                        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);
                    }
                    catch
                    {

                    }

                    //***************************************
                }
                catch
                { }


                //------------------ البيع التلقائى -----------------
                if (chBoxBarcode.Checked == true)
                {
                    textQuntity.Text = "1";

                    if (combCategorys.Text == "")
                    {
                        MessageBox.Show("   كود الصنف غير موجود   ", "الصنف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        butAddCategorey.PerformClick();


                    }

                    textBarcode.Text = "";
                    textBarcode.Focus();
                }
                else
                {

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            //if (checkBox3.Checked==true)
            //{
            //    txtRemaningOld.Text = "0";
            //    CountRemaining(); 
            //}


            //if (comClient.Text == "")
            //{
            //    MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
            //    comClient.Focus();
            //}
            //else
            //{
            //    AppSetting.ClintID = textClintID.Text;
            //    AppSetting.ClintName = comClient.Text;
            //    AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //    AppSetting.TotalBill = txtTotalBill.Text;
            //    AppSetting.RemaningOld = txtRemaningOld.Text;
            //    //AppSetting.textBox27 = textBox27.Text;
            //    AppSetting.Mosadad = txtMosadad.Text;
            //    AppSetting.RemainingNow = txtRemainingNow.Text;
            //    AppSetting.Dic = txtDic.Text;
            //    //AppSetting.textBox30 = textBox30.Text;

            //    //AppSetting.dateTimePicker2 = dateTimePicker2.Text;
            //    AppSetting.textBox57 = textUser.Text;
            //    AppSetting.BillingDataNumBill = textBillingDataNumBill.Text;
            //    AppSetting.TypeBill = comTypeBill.Text;
            //    AppSetting.MoveBill = textMoveBill.Text;

            //    //Reports.Frm_PrintReportBill frm = new Reports.Frm_PrintReportBill();
            //    //da = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "'", cn);
            //    ////da.Fill(frm.elwesifDataSet84.Billing);
            //    //frm.reportViewerA5.Visible = false;
            //    //frm.reportViewerA5.RefreshReport();

            //    //frm.Show();

            //    List<Class_CategoreysBill> BM = new List<Class_CategoreysBill>();
            //    BM.Clear();
            //    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //    {
            //        Class_CategoreysBill Categoreys = new Class_CategoreysBill
            //        {



            //            Num = dataGridView2.Rows[i].Cells[0].Value.ToString(),
            //            Storage = dataGridView2.Rows[i].Cells[1].Value.ToString(),
            //            Category = dataGridView2.Rows[i].Cells[2].Value.ToString(),
            //            Quantity = dataGridView2.Rows[i].Cells[3].Value.ToString(),
            //            Type = dataGridView2.Rows[i].Cells[4].Value.ToString(),
            //            Price = dataGridView2.Rows[i].Cells[5].Value.ToString(),
            //            Discount = dataGridView2.Rows[i].Cells[6].Value.ToString(),
            //            Total = dataGridView2.Rows[i].Cells[7].Value.ToString()

            //        };

            //        BM.Add(Categoreys);
            //    }
            //    rs.Name = "DataSet1";
            //    rs.Value = BM;

            //    Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
            //    rbm.reportViewerA5.LocalReport.DataSources.Clear();
            //    rbm.reportViewerA5.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerB5.LocalReport.DataSources.Clear();
            //    rbm.reportViewerB5.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerCasher.LocalReport.DataSources.Clear();
            //    rbm.reportViewerCasher.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerCasher_8cm.LocalReport.DataSources.Clear();
            //    rbm.reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
            //    rbm.reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerDiscount.LocalReport.DataSources.Clear();
            //    rbm.reportViewerDiscount.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerRepEmp.LocalReport.DataSources.Clear();
            //    rbm.reportViewerRepEmp.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerRepEmpA4.LocalReport.DataSources.Clear();
            //    rbm.reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    rbm.reportViewerA4.LocalReport.DataSources.Clear();
            //    rbm.reportViewerA4.LocalReport.DataSources.Add(rs);



            //    rbm.ShowDialog();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (panelLastPrice.Visible == true)
            //{
            //    panelLastPrice.Visible = false;
            //}
            //else
            //{
            //    panelLastPrice.Visible = true;
            //}
        }

        private void textDiscCategorey1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double ncsn = Convert.ToDouble(textPrice.Text);
                double dcsd = Convert.ToDouble(textDiscCategorey1.Text);
                double rcsr = (ncsn * dcsd) / 100;
                textDiscCategorey.Text = rcsr.ToString();

                textDiscCategorey.Text = Math.Round(double.Parse(textDiscCategorey.Text), 2).ToString();
            }
            catch
            { }

            //----------- حساب الاجمالى ------------
            try
            {


                //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPrice.Text);
                double mm = Convert.ToDouble(textDiscCategorey.Text);
                double rr = (nn * dd) - (nn * mm);

                txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();


            }

            catch (FormatException)
            {
                // MessageBox.Show("you must enter the number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategorey_TextChanged(object sender, EventArgs e)
        {
            //SqlDataAdapter Da21;
            //DataTable Dt21 = new DataTable();
            //Da21 = new SqlDataAdapter("select Category from Category where  Category Like '%" + txtCategorey.Text + "%' and Storage = '" + combStorage.Text + "' and Total > '" + 0 + "'", cn);
            //Da21.Fill(Dt21);
            //combCategorys.DataSource = Dt21;
            //combCategorys.DisplayMember = "Category";


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            txtMosadad.Text = txtTotalBill.Text;

            double a = Convert.ToDouble(txtDic.Text);
            double b = Convert.ToDouble(txtTotalBill.Text);


            double r = b - a;
            txtMosadad.Text = Math.Round(double.Parse(r.ToString()), 2).ToString();
        }

        private void butSeting_Click(object sender, EventArgs e)
        {
            //if (panel14.Visible == true)
            //{
            //    panel14.Visible = false;
            //}
            //else
            //{
            //    panel14.Visible = true;
            //}
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //  ClosePanel();

            int x = label14.Location.X - 120;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 100;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel_PriceSheraa.Location = new Point(x, y);


            //panel2.Location = new Point(300, 219);
            this.panel_PriceSheraa.Size = new System.Drawing.Size(168, 260);

            if (panel_PriceSheraa.Visible == false)
            {
                //--------- حساب ربح الصنف
                RebhCategory();

                panel_PriceSheraa.Visible = true;
                //  textBox1.Focus();
            }
            else
            {
                panel_PriceSheraa.Visible = false;
            }

            //if (groupBox2.Visible == true)
            //{

            //    groupBox2.Visible = false;
            //}

            //else
            //{
            //    //--------- حساب ربح الصنف
            //    RebhCategory();


            //    groupBox2.Visible = true;
            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //double jjs = Convert.ToDouble(textBox21.Text);
            //double jsj = Convert.ToDouble(textBox19.Text); // -- الفئه
            //double sjj = jjs % jsj;
            //textBox1.Text = sjj.ToString();


        }

        private void combStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Storage = combStorage.Text;
            try
            {
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Category from Category where  Storage = '" + Storage + "' and Total > '" + 0 + "'", cn);
                Da.Fill(Dt);
                combCategorys.DataSource = Dt;
                combCategorys.DisplayMember = "Category";
            }
            catch
            {

            }
        }

        private void combStorage_TextChanged(object sender, EventArgs e)
        {
            //- إيجاد الكميه الاول
            textBox18.Text = "";
            textUnityCategrey.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            try
            {
                sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "' AND Storage Like'" + Storage + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    CategoryID = reed["ID"].ToString();
                    textBox18.Text = reed["Quantity"].ToString();
                    textUnityCategrey.Text = reed["Unity"].ToString();
                    textBox20.Text = reed["Faction"].ToString();
                    textBox21.Text = reed["Total"].ToString();
                }
                reed.Close();

                textQuntity.Text = "";
                textPrice.Text = "";
                txtTotalCategory.Text = "";
                // -------------
                groupBox5.Text = combCategorys.Text;
            }
            catch
            {

            }

            try
            {
                sqlCommand1.CommandText = "select * from Billing where Category Like'" + combCategorys.Text + "' AND ClientName Like'" + comClient.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textPrice.Text = reed["Price"].ToString();

                }
                reed.Close();

            }
            catch
            {

            }
        }

        private void dataGridLastPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textPrice.Text = dataGridLastPrice.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch
            { }
        }

        private void radBtPriceGomla_CheckedChanged(object sender, EventArgs e)
        {
            //string PriceGomla = "";
            //string PriceMostahlek = "";
            //string FactionCatogrey = "";
            PriceGomla = "0";
            PriceGomlaAlgomla = "0";
            PriceNesfGomla = "0";
            PriceMostahlek = "0";
            textPriceKtBea.Text = "0";
            //--------------------------------
            try
            {
                sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage ='" + Storage + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    PriceGomla = reed["PriceGomla"].ToString();
                    PriceGomlaAlgomla = reed["PriceGomlaAlgomla"].ToString();
                    PriceNesfGomla = reed["PriceNesfAlgomla"].ToString();
                    PriceMostahlek = reed["PriceMostahlek"].ToString();
                    FactionCatogrey = reed["Faction"].ToString();

                    textBox4.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
                    textBox5.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();

                    ////------------------------

                    //textPriceGomla.Text = reed["PriceGomla"].ToString();
                    //textPriceMostahlek.Text = reed["PriceMostahlek"].ToString();
                    //textPriceShraa.Text = reed["Price"].ToString();
                    //textFaction.Text = reed["Faction"].ToString();


                }
                reed.Close();





                textPriceKtBea.Text = PriceGomla;

                if (ComTypeCategorey.Text == "كرتونه")
                {

                    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPrice.Text = rcsr.ToString();

                    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();


                }
                else
                {

                    textPrice.Text = Math.Round(double.Parse(textPriceKtBea.Text), 2).ToString();

                }




            }
            catch
            {

            }

            try
            {
                if (ComTypeCategorey.Text == "كرتونه")
                {


                    double ncsn = Convert.ToDouble(textPriceShraa.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPriceSH.Text = rcsr.ToString();

                    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();



                }
                else
                {

                    textPriceSH.Text = textPriceShraa.Text;

                }
            }
            catch
            { }



        }

        private void radioBtPriceMostahlek_CheckedChanged(object sender, EventArgs e)
        {
            PriceGomla = "0";
            PriceGomlaAlgomla = "0";
            PriceNesfGomla = "0";
            PriceMostahlek = "0";
            textPriceKtBea.Text = "0";
            //**********
            //try
            //{
            sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "' and Storage ='" + Storage + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                PriceGomla = reed["PriceGomla"].ToString();
                PriceGomlaAlgomla = reed["PriceGomlaAlgomla"].ToString();
                PriceNesfGomla = reed["PriceNesfAlgomla"].ToString();
                PriceMostahlek = reed["PriceMostahlek"].ToString();
                FactionCatogrey = reed["Faction"].ToString();

                textBox4.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
                textBox5.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();

                //------------------------

                //textPriceGomla.Text = reed["PriceGomla"].ToString();
                //textPriceMostahlek.Text = reed["PriceMostahlek"].ToString();
                //textPriceShraa.Text = reed["Price"].ToString();
                //textFaction.Text = reed["Faction"].ToString();


            }
            reed.Close();

            //************



            textPriceKtBea.Text = PriceMostahlek;


            if (ComTypeCategorey.Text == "كرتونه")
            {


                double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                double rcsr = ncsn * dcsd;
                textPrice.Text = rcsr.ToString();

                textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();





            }
            else
            {

                textPrice.Text = Math.Round(double.Parse(textPriceKtBea.Text), 2).ToString();

            }




            //}
            //catch
            //{

            //}

            try
            {
                if (ComTypeCategorey.Text == "كرتونه")
                {


                    double ncsn = Convert.ToDouble(textPriceShraa.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPriceSH.Text = rcsr.ToString();

                    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();


                }
                else
                {

                    textPriceSH.Text = textPriceShraa.Text;

                }
            }
            catch
            { }

        }

        private void chBoxBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxBarcode.Checked == true)
            {
                textBarcode.Text = "";
                textBarcode.ReadOnly = false;
                textBarcode.Focus();
            }
            else
            {
                combCategorys.Focus();
                textBarcode.ReadOnly = true;
            }
        }

        private void txtMosadad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // butLogin.Focus();
                button13.PerformClick();

            }

            if (e.KeyCode == Keys.Enter)
            {
                CalculateValues();
                textMosadadActual.Focus(); // ينقل للمربع التالى
            }
        }

        private void txtMosadad_TextChanged(object sender, EventArgs e)
        {
           // CalculateValues();
        }

        private void butInstallment_Click(object sender, EventArgs e)
        {
            button13.PerformClick();

            try
            {

                double R = Convert.ToDouble(txtRemaningOld.Text);
                double T = Convert.ToDouble(txtTotalBill.Text);


                double r = R + T;
                // txtRemainingNow.Text = r.ToString();
                txtTotalAndRemaining.Text = Math.Round(double.Parse(r.ToString()), 2).ToString();
            }
            catch
            {

            }

            AppSetting.ClintID = textClintID.Text;
            AppSetting.ClintName = comClient.Text;
            AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            AppSetting.TotalBill = txtTotalAndRemaining.Text;
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



            if (Installment1 == null || Installment1.IsDisposed == true)
            {
                Installment1 = new Installment();
            }
            //Altarkhes.MdiParent = this;
            Installment1.ShowDialog();


            AppSetting.ClintID = "";
            AppSetting.ClintName = "";
            // AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            AppSetting.TotalBill = "";
            AppSetting.RemaningOld = "";
            //AppSetting.textBox27 = textBox27.Text;
            AppSetting.Mosadad = "";
            AppSetting.RemainingNow = "";
            AppSetting.Dic = "";
            //AppSetting.textBox30 = textBox30.Text;

            //AppSetting.dateTimePicker2 = dateTimePicker2.Text;
            AppSetting.textBox57 = "";
            AppSetting.BillingDataNumBill = "";
            AppSetting.TypeBill = "";
            AppSetting.MoveBill = "";
        }

        private void comTypeBill_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (comTypeBill.Text == "نقدى")
            {

                butInstallment.Enabled = false;

            }
            else if (comTypeBill.Text == "آجل")
            {
                butInstallment.Enabled = false;

            }
            else if (comTypeBill.Text == "تقسيط")
            {
                butInstallment.Enabled = true;
            }
        }

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {
            //txtDic.Text = "0";
        }

        private void labelDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                double ncsn = Convert.ToDouble(txtTotalBill.Text);
                double dcsd = Convert.ToDouble(txtDic.Text);
                double rcsr = (100 * dcsd) / ncsn;
                textDiscount.Text = rcsr.ToString();

                textDiscount.Text = Math.Round(double.Parse(textDiscount.Text), 2).ToString();


            }
            catch
            { }
        }

        private void labelDiscount2_Click(object sender, EventArgs e)
        {

        }

        private void txtDic_TextChanged(object sender, EventArgs e)
        {
            //textDiscount.Text = "0";

            try
            {
                double ncsn = Convert.ToDouble(txtTotalBill.Text);
                double dcsd = Convert.ToDouble(txtDic.Text);
                double rcsr = (100 * dcsd) / ncsn;
                textDiscount.Text = rcsr.ToString();

                textDiscount.Text = Math.Round(double.Parse(textDiscount.Text), 2).ToString();

                if (txtDic.Text == "")
                {
                    txtDic.Text = "0";
                }

            }
            catch
            { }
        }

        private void textDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double ncsn = Convert.ToDouble(txtTotalBill.Text);
                    double dcsd = Convert.ToDouble(textDiscount.Text);
                    double rcsr = (ncsn * dcsd) / 100;
                    txtDic.Text = rcsr.ToString();

                    txtDic.Text = Math.Round(double.Parse(txtDic.Text), 2).ToString();
                }
                catch
                { }

            }
        }

        private void txtDic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double ncsn = Convert.ToDouble(txtTotalBill.Text);
                    double dcsd = Convert.ToDouble(txtDic.Text);
                    double rcsr = (100 * dcsd) / ncsn;
                    textDiscount.Text = rcsr.ToString();

                    textDiscount.Text = Math.Round(double.Parse(textDiscount.Text), 2).ToString();


                }
                catch
                { }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comClient.Text == "")
            {
                MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
                comClient.Focus();
            }
            else
            {
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
                        TotalBill = dataGridView4.Rows[i].Cells[3].Value.ToString(),
                        Paid = dataGridView4.Rows[i].Cells[4].Value.ToString(),
                        Remaining = dataGridView4.Rows[i].Cells[5].Value.ToString(),

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
        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {
            // GetPricesAndQuntity();
            //if (textPrice.Text == "")
            //{
            //    textPrice.Text = "0";
            //}
            //else
            //{ }
            try  // حساب سع البيع حسب السعر المدخل اليدوى
            {
                double aa = Convert.ToDouble(textPrice.Text);
                double bb = Convert.ToDouble(textUnityBeea.Text);
                //  double mm = Convert.ToDouble(textDiscCategorey.Text);
                double rra = (aa / bb);

                textPriceKtBea.Text = Math.Round(rra, 2).ToString();
            }
            catch
            {

            }
            //----------- حساب الاجمالى ------------
            try
            {


                //---------- حساب سعر الكميه المطلوبه بدون الكمية القديمة للصنف ان وجد ---

                double nn = Convert.ToDouble(textQuntity.Text);
                double dd = Convert.ToDouble(textPrice.Text);
                double mm = Convert.ToDouble(textDiscCategorey.Text);
                double rr = (nn * dd) - (nn * mm);

                txtTotalCategory.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();


            }

            catch (FormatException)
            {
                // MessageBox.Show("you must enter the number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //--------- حساب ربح الصنف
            RebhCategory();

        }

        private void textBox68_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butDeleteBill_Click(object sender, EventArgs e)
        {
            //// int Number = 1;
            ////string Number = "";
            ////  double sum1 = 0;
            ////for (int i = 0; i < length; i++)
            ////{

            ////}
            //DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد حذف الفاتورة نهائيا ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Yes)
            //{

            //    int NumRows = Convert.ToInt32(dataGridView2.RowCount - 1);

            //    for (int j = 0; j < NumRows; j++)
            //    {
            //        //sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
            //        //Number = Number + 1;



            //        //  textBox1.Text = (dataGridView2.RowCount - 1).ToString();

            //        // combCategorys.Text = dataGridView2.Rows[Number].Cells[2].Value.ToString();

            //        Number = dataGridView2.Rows[0].Cells[0].Value.ToString();

            //        // البحث عن الصنف فى الفاتورة 


            //        sqlCommand1.CommandText = "select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Num='" + Number + "' ";
            //        reed = sqlCommand1.ExecuteReader();
            //        while (reed.Read())
            //        {
            //            NumCategery = reed["Num"].ToString();
            //            textQuntity.Text = reed["Quantity"].ToString();
            //            textPrice.Text = reed["Price"].ToString();
            //            ComTypeCategorey.Text = reed["Type"].ToString();
            //            textDiscCategorey1.Text = reed["Discount"].ToString();
            //            txtTotalCategory.Text = reed["Total"].ToString();
            //            Storage = reed["Storage"].ToString();
            //            combCategorys.Text = reed["Category"].ToString();

            //        }
            //        reed.Close();
            //        if (combCategorys.Text == "")

            //        {

            //        }
            //        else
            //        {

            //            // حذف الصنف من الفاتورة

            //            sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
            //            sqlCommand1.ExecuteNonQuery();

            //            // حذف الصنف من جدول الحركة

            //            sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
            //            sqlCommand1.ExecuteNonQuery();

            //            // حذف الصنف من جدول الارباح

            //            sqlCommand1.CommandText = "delete from Profit where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
            //            sqlCommand1.ExecuteNonQuery();

            //            //  حذف الصنف من جدول الحركة الجديده

            //            sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
            //            sqlCommand1.ExecuteNonQuery();

            //            //--- حساب الاجمالى
            //            double n = Convert.ToDouble(txtTotalBill.Text);
            //            double d = Convert.ToDouble(txtTotalCategory.Text);
            //            double r = n - d;
            //            txtTotalBill.Text = r.ToString();

            //            double nn = Convert.ToDouble(TotalAndRemaninRasedClient);
            //            double dd = Convert.ToDouble(txtTotalCategory.Text);
            //            double rr = nn - dd;
            //            TotalAndRemaninRasedClient = rr.ToString();


            //            double nnn = Convert.ToDouble(TxtNumCategorey.Text);
            //            // double dd = Convert.ToDouble(textBox3.Text);
            //            double rrr = nnn - 1;
            //            TxtNumCategorey.Text = rrr.ToString();


            //            //- إيجاد الكميه الفعلية الموجودة بالمخزن

            //            sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "'and Storage like '" + Storage + "'   ";
            //            reed = sqlCommand1.ExecuteReader();
            //            while (reed.Read())
            //            {
            //                CategoryID = reed["ID"].ToString();
            //                textBox18.Text = reed["Quantity"].ToString();
            //                textBox19.Text = reed["Unity"].ToString();
            //                textBox20.Text = reed["Faction"].ToString();
            //                textBox21.Text = reed["Total"].ToString();

            //            }
            //            reed.Close();


            //            // -------------
            //            groupBox5.Text = combCategorys.Text;


            //            if (ComTypeCategorey.Text == "كرتونه")
            //            {


            //                double sn = Convert.ToDouble(textQuntity.Text);
            //                double sd = Convert.ToDouble(textBox18.Text);
            //                double sr = sn + sd;
            //                textBox18.Text = sr.ToString();

            //                double an = Convert.ToDouble(textQuntity.Text);
            //                double ad = Convert.ToDouble(textBox19.Text);
            //                double ar = an * ad;
            //                //textBox25.Text = ar.ToString();

            //                //double qn = Convert.ToDouble(textBox25.Text);
            //                double qd = Convert.ToDouble(textBox21.Text);
            //                double qr = ar + qd;
            //                textBox21.Text = qr.ToString();



            //                sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',  Total ='" + textBox21.Text + "'  where Category='" + combCategorys.Text + "'and Storage like '" + Storage + "' ";
            //                sqlCommand1.ExecuteNonQuery();

            //                sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
            //                sqlCommand1.ExecuteNonQuery();



            //                // ايجاد الاصناف فى الفاتورة
            //                //------------------------------------
            //                dt11.Clear();
            //                SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            //                da11.Fill(dt11);
            //                this.dataGridView2.DataSource = dt11;
            //                //------------------------------------

            //            }
            //            else
            //            {

            //                double sn = Convert.ToDouble(textQuntity.Text);
            //                double bn = Convert.ToDouble(textBox68.Text);
            //                double sd = Convert.ToDouble(textBox21.Text);
            //                double sr = (sn * bn) + sd;
            //                textBox21.Text = sr.ToString();

            //                // معرفة كمية الاجمالى بعد الخصم

            //                int jjs = int.Parse(textBox21.Text);
            //                int jsj = int.Parse(textBox19.Text);
            //                int sjj = jjs / jsj;
            //                textBox18.Text = sjj.ToString();

            //                sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',  Total ='" + textBox21.Text + "'  where Category='" + combCategorys.Text + "'and Storage like '" + Storage + "' ";
            //                sqlCommand1.ExecuteNonQuery();

            //                sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
            //                sqlCommand1.ExecuteNonQuery();



            //                // ايجاد الاصناف فى الفاتورة
            //                //------------------------------------
            //                dt11.Clear();
            //                SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            //                da11.Fill(dt11);
            //                this.dataGridView2.DataSource = dt11;
            //                //------------------------------------


            //            }
            //        }

            //        //===================== حساب إجمالى الفاتورة عدد الاصناف
            //        int rowNumber1 = 0;

            //        double sum1 = 0;
            //        for (int s = 0; s < dataGridView2.RowCount - 1; ++s)
            //        {
            //            sum1 += Convert.ToDouble(dataGridView2.Rows[s].Cells[7].Value);
            //            rowNumber1 = rowNumber1 + 1;

            //        }

            //        txtTotalBill.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
            //        TxtNumCategorey.Text = rowNumber1.ToString();
            //        // حساب المتبقى
            //        CountRemaining();
            //        if (TxtNumCategorey.Text == "0")// لايوجد اصناف فى الفاتورة
            //        {
            //            txtMosadad.Text = "0";
            //            // حذف بيانات الفاتورة
            //            try
            //            {
            //                sqlCommand1.CommandText = "delete from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'   ";
            //                sqlCommand1.ExecuteNonQuery();


            //                sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' ";
            //                sqlCommand1.ExecuteNonQuery();

            //            }
            //            catch
            //            { }

            //        }
            //        else
            //        {
            //            // تحديث بيانات الفاتورة
            //            if (FormName == "فاتورة مبيعات")
            //            {
            //                sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
            //                sqlCommand1.ExecuteNonQuery();
            //            }
            //            else if (FormName == "مردودات مشتريات")
            //            {
            //                sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
            //                sqlCommand1.ExecuteNonQuery();
            //            }

            //            sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
            //            sqlCommand1.ExecuteNonQuery();
            //        }



            //        // تعديل الرصيد فى جدول العملاء
            //        try
            //        {
            //            sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  ID ='" + textClintID.Text + "' ";
            //            sqlCommand1.ExecuteNonQuery();

            //        }
            //        catch
            //        {
            //            MessageBox.Show(" pleas correct the data");
            //        }


            //        // Number = Number + 1;

            //    }

            //}


            //txtMosadad.Text = "0";
            //txtRemainingNow.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void butSearchCategory_Click(object sender, EventArgs e)
        {
            ClosePanel();

            int x = label14.Location.X - 625;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 100;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel2.Location = new Point(x, y);


            //panel2.Location = new Point(300, 219);
            this.panel2.Size = new System.Drawing.Size(677, 356);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            radio_GetAllCategry.Checked = true;

            DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,PriceMostahlek From Category where Category like '%" + textBox1.Text + "%' ", cn);

            da.Fill(dt);
            this.dataGridSearchCategory.DataSource = dt;






            //radio_GetAllCategry.Checked = true;

            //dataGridGetAllCategry_BestSeller.Visible = false;
            //dataGridCategory_BestSeller.Visible = false;
            //dataGridSearchCategory.Visible = true;
            //GetAllCategry();


            ////-------------


            //radio_GetAllCategry_Quntety.Checked = true;

            //dataGridGetAllCategry_BestSeller.Visible = false;
            //dataGridCategory_BestSeller.Visible = false;
            //dataGridSearchCategory.Visible = true;
            //GetAllCategry_Quntety();


            ////----------

            //radioButton5.Checked = true;

            //dataGridGetAllCategry_BestSeller.Visible = true;
            //dataGridSearchCategory.Visible = false;
            //dataGridCategory_BestSeller.Visible = false;
            //GetAllCategry_BestSeller();


            ////-----------------

            //radCategory_BestSeller.Checked = true;

            //dataGridGetAllCategry_BestSeller.Visible = false;
            //dataGridSearchCategory.Visible = false;
            //dataGridCategory_BestSeller.Visible = true;
            //GetCategory_BestSeller();






        }

        private void butSearchClint_Click(object sender, EventArgs e)
        {

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

        private void textID_Category_TextChanged(object sender, EventArgs e)
        {
            combCategorys.Text = "";

            String A = "";
            sqlCommand1.CommandText = "select * from Category where ID ='" + textID_Category.Text + "' AND Storage Like'" + Storage + "'   ";
            reeeed = sqlCommand1.ExecuteReader();
            while (reeeed.Read())
            {

                A = reeeed["Category"].ToString();

            }
            reeeed.Close();

            combCategorys.Text = A;

        }

        private void dataGridSearchCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridSearchCategory.Rows[e.RowIndex].Cells[1].Value.ToString();


            // textBox1.Text = "";



            if (checkBox1.Checked == true)
            {
                textQuntity.Text = textQuntetyAuto.Text;
                butAddCategorey.PerformClick();
                textBox1.Focus();
            }
            else
            {
                // panel2.Visible = false;
                textQuntity.Focus();



            }
        }

        private void textID_Category_Enter(object sender, EventArgs e)
        {

        }

        private void textID_Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textQuntity.Focus();
                //butLogin.PerformClick();

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {

            //if (comboBox1.Text == "")
            //{
            //    listBox1.Visible = false;
            //}
            //else
            //{
            //    listBox1.Visible = true;

            //    ////----------------- ايجاد العملاء --------------------
            //    try
            //    {
            //        SqlDataAdapter Da2;
            //        DataTable Dt2 = new DataTable();
            //        Da2 = new SqlDataAdapter("select Category from Category where Category Like'%" + comboBox1.Text + "%' ", cn);
            //        Da2.Fill(Dt2);


            //        listBox1.DataSource = Dt2;
            //        listBox1.DisplayMember = "Category";
            //    }
            //    catch
            //    {

            //    }


            //    //---------- مقاس ارتفاع الليست حسب العناصر اللى فيه
            //   listBox1.Height = listBox1.PreferredHeight;

            //    //---------- مقاس  الليست الارتفاع والعرض حسب العناصر اللى فيه

            //   // listBox1.Size = listBox1.PreferredSize;




            //    //int AAA = 0;

            //    //AAA = listBox1.Items.Count;

            //    //textBox3.Text = AAA.ToString();

            //    //textBox2.Text = listBox1.Items.Count.ToString();




            //    // int sizelist = AAA * 15;
            //    //  listBox1.Height = sizelist;
            // }


        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void getprameterreports(ReportViewer reportchange)

        {

            //***************** طباعه اللوجو 
            //string imagepath = "file:///" + "//logo.png";


            //reportchange.LocalReport.EnableExternalImages = true;
            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("parmImageUrl", imagepath);
            //reportchange.LocalReport.SetParameters(param);
            //reportchange.RefreshReport();

            FileInfo fi = new FileInfo(imageLogoUrl);
            //  ReportParameter pName = new ReportParameter("pName", fi.Name);
            ReportParameter pImageUrl = new ReportParameter("parmImageUrl", new Uri(imageLogoUrl).AbsoluteUri);
            reportchange.LocalReport.EnableExternalImages = true;
            reportchange.LocalReport.SetParameters(new ReportParameter[] { pImageUrl });
            reportchange.RefreshReport();

            //-------------------------------------------------------------



            List<ReportParameter> list_Company_Name = new List<ReportParameter>();
            ReportParameter parm_Company_Name = new ReportParameter("Parm_Company_Name", AppSetting.textCompany_Name);
            list_Company_Name.Add(parm_Company_Name);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });

            //***********************
            List<ReportParameter> list_Company_Address = new List<ReportParameter>();
            ReportParameter parm_Company_Address = new ReportParameter("Parm_Company_Address", AppSetting.textCompany_Address);
            list_Company_Address.Add(parm_Company_Address);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });



            //***********************

            //***********************

            List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            list_Company_Description.Add(parm_Company_Description);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


            //***********************



            List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
            ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
            list_Company_Phone.Add(parm_Company_Phone);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });


            //------------------------------------
            List<ReportParameter> list_NoteToBill = new List<ReportParameter>();
            ReportParameter parm_NoteToBill = new ReportParameter("Parm_NoteToBill", AppSetting.NoteToBill);
            list_NoteToBill.Add(parm_NoteToBill);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });

            //------------------------------------

            List<ReportParameter> list17 = new List<ReportParameter>();
            ReportParameter parm17 = new ReportParameter("Parm_MoveBill", AppSetting.MoveBill);
            list17.Add(parm17);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm17 });


            //------------------------------------
            List<ReportParameter> list1 = new List<ReportParameter>();
            ReportParameter parm1 = new ReportParameter("TypeBill", AppSetting.TypeBill);
            list1.Add(parm1);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            //------------------------------------
            List<ReportParameter> list2 = new List<ReportParameter>();
            ReportParameter parm2 = new ReportParameter("Name", AppSetting.ClintName);
            list2.Add(parm2);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            //------------------------------------

            List<ReportParameter> list3 = new List<ReportParameter>();
            ReportParameter parm3 = new ReportParameter("Print", AppSetting.user);
            list3.Add(parm3);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm3 });


            //------------------------------------

            List<ReportParameter> list4 = new List<ReportParameter>();
            ReportParameter parm4 = new ReportParameter("NumBill", AppSetting.BillingDataNumBill);
            list4.Add(parm4);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            //------------------------------------

            List<ReportParameter> list5 = new List<ReportParameter>();
            ReportParameter parm5 = new ReportParameter("Date", AppSetting.dateTimePicker1);
            list5.Add(parm5);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //------------------------------------

            List<ReportParameter> list6 = new List<ReportParameter>();
            ReportParameter parm6 = new ReportParameter("Total", AppSetting.TotalBill);
            list6.Add(parm6);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            //------------------------------------
            List<ReportParameter> list7 = new List<ReportParameter>();
            ReportParameter parm7 = new ReportParameter("Sabek", AppSetting.RemaningOld);
            list7.Add(parm7);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            //------------------------------------
            List<ReportParameter> list9 = new List<ReportParameter>();
            ReportParameter parm9 = new ReportParameter("Discount", AppSetting.Dic);
            list9.Add(parm9);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            //------------------------------------
            List<ReportParameter> list10 = new List<ReportParameter>();
            ReportParameter parm10 = new ReportParameter("Mosadad", AppSetting.Mosadad);
            list10.Add(parm10);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm10 });


            //------------------------------------
            List<ReportParameter> list11 = new List<ReportParameter>();
            ReportParameter parm11 = new ReportParameter("Remaning", AppSetting.RemainingNow);
            list11.Add(parm11);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm11 });



        }
        private void getprameterreports()

        {

            List<ReportParameter> list_Company_Name = new List<ReportParameter>();
            ReportParameter parm_Company_Name = new ReportParameter("Parm_Company_Name", AppSetting.textCompany_Name);
            list_Company_Name.Add(parm_Company_Name);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });


            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });


            //***********************
            List<ReportParameter> list_Company_Address = new List<ReportParameter>();
            ReportParameter parm_Company_Address = new ReportParameter("Parm_Company_Address", AppSetting.textCompany_Address);
            list_Company_Address.Add(parm_Company_Address);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });


            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });


            //***********************
            //List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            //ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            //list_Company_Description.Add(parm_Company_Name);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


            //***********************

            List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            list_Company_Description.Add(parm_Company_Description);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            //***********************



            List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
            ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
            list_Company_Phone.Add(parm_Company_Phone);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });



            //------------------------------------
            List<ReportParameter> list_NoteToBill = new List<ReportParameter>();
            ReportParameter parm_NoteToBill = new ReportParameter("Parm_NoteToBill", AppSetting.NoteToBill);
            list_NoteToBill.Add(parm_NoteToBill);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });


            //------------------------------------

            List<ReportParameter> list17 = new List<ReportParameter>();
            ReportParameter parm17 = new ReportParameter("Parm_MoveBill", AppSetting.MoveBill);
            list17.Add(parm17);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm17 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm17 });


            //------------------------------------
            List<ReportParameter> list1 = new List<ReportParameter>();
            ReportParameter parm1 = new ReportParameter("TypeBill", AppSetting.TypeBill);
            list1.Add(parm1);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            //------------------------------------
            List<ReportParameter> list2 = new List<ReportParameter>();
            ReportParameter parm2 = new ReportParameter("Name", AppSetting.ClintName);
            list2.Add(parm2);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            //------------------------------------

            List<ReportParameter> list3 = new List<ReportParameter>();
            ReportParameter parm3 = new ReportParameter("Print", AppSetting.user);
            list3.Add(parm3);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            //------------------------------------

            List<ReportParameter> list4 = new List<ReportParameter>();
            ReportParameter parm4 = new ReportParameter("NumBill", AppSetting.BillingDataNumBill);
            list4.Add(parm4);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            //------------------------------------

            List<ReportParameter> list5 = new List<ReportParameter>();
            ReportParameter parm5 = new ReportParameter("Date", AppSetting.dateTimePicker1);
            list5.Add(parm5);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //------------------------------------

            List<ReportParameter> list6 = new List<ReportParameter>();
            ReportParameter parm6 = new ReportParameter("Total", AppSetting.TotalBill);
            list6.Add(parm6);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            // reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            //------------------------------------
            List<ReportParameter> list7 = new List<ReportParameter>();
            ReportParameter parm7 = new ReportParameter("Sabek", AppSetting.RemaningOld);
            list7.Add(parm7);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            //------------------------------------
            List<ReportParameter> list9 = new List<ReportParameter>();
            ReportParameter parm9 = new ReportParameter("Discount", AppSetting.Dic);
            list9.Add(parm9);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            //------------------------------------
            List<ReportParameter> list10 = new List<ReportParameter>();
            ReportParameter parm10 = new ReportParameter("Mosadad", AppSetting.Mosadad);
            list10.Add(parm10);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm10 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm10 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm10 });

            //------------------------------------
            List<ReportParameter> list11 = new List<ReportParameter>();
            ReportParameter parm11 = new ReportParameter("Remaning", AppSetting.RemainingNow);
            list11.Add(parm11);
            reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm11 });


        }
        private void butPrintauto_Click(object sender, EventArgs e)
        {
            //if (checkBox3.Checked == true)
            //{
            //    txtRemaningOld.Text = "0";
            //    CountRemaining();
            //}


            //// if (panel18.Visible == false)
            //// {
            //if (comClient.Text == "")
            //    {
            //        MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
            //        comClient.Focus();
            //    }
            //    else
            //    {
            //        AppSetting.ClintID = textClintID.Text;
            //        AppSetting.ClintName = comClient.Text;
            //        AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //        AppSetting.TotalBill = txtTotalBill.Text;
            //        AppSetting.RemaningOld = txtRemaningOld.Text;
            //        //AppSetting.textBox27 = textBox27.Text;
            //        AppSetting.Mosadad = txtMosadad.Text;
            //        AppSetting.RemainingNow = txtRemainingNow.Text;
            //        AppSetting.Dic = txtDic.Text;
            //        //AppSetting.textBox30 = textBox30.Text;

            //        //AppSetting.dateTimePicker2 = dateTimePicker2.Text;
            //        AppSetting.textBox57 = textUser.Text;
            //        AppSetting.BillingDataNumBill = textBillingDataNumBill.Text;
            //        AppSetting.TypeBill = comTypeBill.Text;
            //        AppSetting.MoveBill = textMoveBill.Text;

            //        //Reports.Frm_PrintReportBill frm = new Reports.Frm_PrintReportBill();
            //        //da = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "'", cn);
            //        ////da.Fill(frm.elwesifDataSet84.Billing);
            //        //frm.reportViewerA5.Visible = false;
            //        //frm.reportViewerA5.RefreshReport();

            //        //frm.Show();

            //        List<Class_CategoreysBill> BM = new List<Class_CategoreysBill>();
            //        BM.Clear();
            //        for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //        {
            //            Class_CategoreysBill Categoreys = new Class_CategoreysBill
            //            {



            //                Num = dataGridView2.Rows[i].Cells[0].Value.ToString(),
            //                Storage = dataGridView2.Rows[i].Cells[1].Value.ToString(),
            //                Category = dataGridView2.Rows[i].Cells[2].Value.ToString(),
            //                Quantity = dataGridView2.Rows[i].Cells[3].Value.ToString(),
            //                Type = dataGridView2.Rows[i].Cells[4].Value.ToString(),
            //                Price = dataGridView2.Rows[i].Cells[5].Value.ToString(),
            //                Discount = dataGridView2.Rows[i].Cells[6].Value.ToString(),
            //                Total = dataGridView2.Rows[i].Cells[7].Value.ToString()

            //            };

            //            BM.Add(Categoreys);
            //        }
            //        rs.Name = "DataSet1";
            //        rs.Value = BM;

            //       // Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
            //        reportViewerA5.LocalReport.DataSources.Clear();
            //        reportViewerA5.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerB5.LocalReport.DataSources.Clear();
            //        reportViewerB5.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerCasher.LocalReport.DataSources.Clear();
            //        reportViewerCasher.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerCasher_8cm.LocalReport.DataSources.Clear();
            //        reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
            //        ////------------------------------------------------------
            //        reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
            //        reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerDiscount.LocalReport.DataSources.Clear();
            //        reportViewerDiscount.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerRepEmp.LocalReport.DataSources.Clear();
            //        reportViewerRepEmp.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerRepEmpA4.LocalReport.DataSources.Clear();
            //       reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
            //        //------------------------------------------------------
            //        reportViewerA4.LocalReport.DataSources.Clear();
            //        reportViewerA4.LocalReport.DataSources.Add(rs);

            //        //getprameterreports();

            //        if (SizePaperBill == "A4")
            //        {
            //            //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingA4.rdlc";
            //            getprameterreports(reportViewerA4);

            //            //reportViewerA4.Visible = true;
            //            //reportViewerA5.Visible = false;
            //            //reportViewerCasher.Visible = false;
            //            //reportViewerRepEmp.Visible = false;
            //            //reportViewerB5.Visible = false;
            //            //reportViewerDiscount.Visible = false;
            //            //reportViewerCasher_8cm.Visible = false;
            //            //reportViewerCasher_8cm_NoDis.Visible = false;
            //            //reportViewerRepEmpA4.Visible = false;


            //            this.reportViewerA4.RefreshReport();

            //             reportViewerA4.LocalReport.PrintToPrinter();

            //        }
            //        else if (SizePaperBill == "A5")
            //        {

            //        //------  معيانة بسيطة ----
            //        //panel18.Visible = true;

            //        //getprameterreports(reportViewerA5);

            //        //reportViewerA4.Visible = false;
            //        //reportViewerA5.Visible = true;
            //        //reportViewerCasher.Visible = false;
            //        //reportViewerRepEmp.Visible = false;
            //        //reportViewerB5.Visible = false;
            //        //reportViewerDiscount.Visible = false;
            //        //reportViewerCasher_8cm.Visible = false;
            //        //reportViewerCasher_8cm_NoDis.Visible = false;
            //        //reportViewerRepEmpA4.Visible = false;
            //        //this.reportViewerA5.RefreshReport();

            //        //--------- طباعه مباشرة ------
            //        getprameterreports(reportViewerA5);
            //        this.reportViewerA5.RefreshReport();

            //        reportViewerA5.LocalReport.PrintToPrinter();


            //         }
            //        else if (SizePaperBill == "B5")
            //        {
            //            getprameterreports(reportViewerB5);

            //            //reportViewerA4.Visible = false;
            //            //reportViewerA5.Visible = false;
            //            //reportViewerCasher.Visible = false;
            //            //reportViewerRepEmp.Visible = false;
            //            //reportViewerB5.Visible = true;
            //            //reportViewerDiscount.Visible = false;
            //            //reportViewerCasher_8cm.Visible = false;
            //            //reportViewerCasher_8cm_NoDis.Visible = false;
            //            //reportViewerRepEmpA4.Visible = false;

            //            this.reportViewerB5.RefreshReport();

            //             reportViewerB5.LocalReport.PrintToPrinter();

            //        }
            //        else if (SizePaperBill == "A5 - Discount")
            //        {
            //            getprameterreports(reportViewerA4);

            //            //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingDiscountA5.rdlc";
            //        }
            //        else if (SizePaperBill == "Casher 6 mm")
            //        {
            //        //------  معيانة بسيطة ----
            //        panel18.Visible = true;

            //        getprameterreports(reportViewerCasher);

            //        reportViewerA4.Visible = false;
            //        reportViewerA5.Visible = false;
            //        reportViewerCasher.Visible = true;
            //        reportViewerRepEmp.Visible = false;
            //        reportViewerB5.Visible = false;
            //        reportViewerDiscount.Visible = false;
            //        reportViewerCasher_8cm.Visible = false;
            //        reportViewerCasher_8cm_NoDis.Visible = false;
            //        reportViewerRepEmpA4.Visible = false;
            //        this.reportViewerCasher.RefreshReport();

            //        //--------- طباعه مباشرة ------
            //        //getprameterreports(reportViewerCasher);
            //        //this.reportViewerCasher.RefreshReport();

            //        //reportViewerCasher.LocalReport.PrintToPrinter();


            //        }
            //        else if (SizePaperBill == "Casher 8 mm")
            //        {
            //        //------  معيانة بسيطة ----
            //        panel18.Visible = true;

            //        getprameterreports(reportViewerCasher_8cm);

            //        reportViewerA4.Visible = false;
            //        reportViewerA5.Visible = false;
            //        reportViewerCasher.Visible = false;
            //        reportViewerRepEmp.Visible = false;
            //        reportViewerB5.Visible = false;
            //        reportViewerDiscount.Visible = false;
            //        reportViewerCasher_8cm.Visible = true;
            //        reportViewerCasher_8cm_NoDis.Visible = false;
            //        reportViewerRepEmpA4.Visible = false;
            //        this.reportViewerCasher_8cm.RefreshReport();

            //        //--------- طباعه مباشرة ------
            //        //getprameterreports(reportViewerCasher_8cm);
            //        //this.reportViewerCasher_8cm.RefreshReport();

            //        //reportViewerCasher_8cm.LocalReport.PrintToPrinter();




            //        }

            //        else if (SizePaperBill == "Casher 8 mm No Discount") // Casher 8 mm No Discount
            //        {

            //        //------  معيانة بسيطة ----
            //        panel18.Visible = true;

            //        getprameterreports(reportViewerCasher_8cm_NoDis);

            //        reportViewerA4.Visible = false;
            //        reportViewerA5.Visible = false;
            //        reportViewerCasher.Visible = false;
            //        reportViewerRepEmp.Visible = false;
            //        reportViewerB5.Visible = false;
            //        reportViewerDiscount.Visible = false;
            //        reportViewerCasher_8cm.Visible = false;
            //        reportViewerCasher_8cm_NoDis.Visible = true;
            //        reportViewerRepEmpA4.Visible = false;
            //        this.reportViewerCasher_8cm_NoDis.RefreshReport();

            //        //--------- طباعه مباشرة ------
            //        //getprameterreports(reportViewerCasher_8cm_NoDis);
            //        //this.reportViewerCasher_8cm_NoDis.RefreshReport();

            //        //reportViewerCasher_8cm_NoDis.LocalReport.PrintToPrinter();


            //    }
            //    else if (SizePaperBill == "A4 List")
            //        {
            //            getprameterreports(reportViewerRepEmpA4);

            //            //reportViewerA4.Visible = false;
            //            //reportViewerA5.Visible = false;
            //            //reportViewerCasher.Visible = false;
            //            //reportViewerRepEmp.Visible = false;
            //            //reportViewerB5.Visible = false;
            //            //reportViewerDiscount.Visible = false;
            //            //reportViewerCasher_8cm.Visible = false;
            //            //reportViewerCasher_8cm_NoDis.Visible = false;
            //            //reportViewerRepEmpA4.Visible = true;

            //            this.reportViewerRepEmpA4.RefreshReport();


            //            reportViewerRepEmpA4.LocalReport.PrintToPrinter();


            //        }
            //        else if (SizePaperBill == "A5 List")
            //        {
            //            getprameterreports(reportViewerRepEmp);

            //            //reportViewerA4.Visible = false;
            //            //reportViewerA5.Visible = false;
            //            //reportViewerCasher.Visible = false;
            //            //reportViewerRepEmp.Visible = true;
            //            //reportViewerB5.Visible = false;
            //            //reportViewerDiscount.Visible = false;
            //            //reportViewerCasher_8cm.Visible = false;
            //            //reportViewerCasher_8cm_NoDis.Visible = false;
            //            //reportViewerRepEmpA4.Visible = false;


            //            this.reportViewerRepEmp.RefreshReport();

            //             reportViewerRepEmp.LocalReport.PrintToPrinter();


            //        }
            //        else
            //        {
            //            MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
            //        }
            //    //    this.reportViewer1.RefreshReport();

            //     //   panel18.Visible = true;


            //       // reportViewer1.LocalReport.PrintToPrinter();






            //        //  LocalReport report = new LocalReport();
            //        //  report.ReportEmbeddedResource = "ReportBillingCasher_8cm_NoDis.rdlc";
            //        ////  report.DataSources.Add(new ReportDataSource("DataSet1",dataGridView1.DataSource));

            //        //  report.PrintToPrinter();


            //        // rbm.ShowDialog();

            //        //LocalReport localReport = new LocalReport();
            //        //localReport.ReportEmbeddedResource = "~/ReportBillingCasher_8cm_NoDis.rdlc";

            //        ////localReport.ReportPath = Application.StartupPath + "ReportBillingCasher_8cm_NoDis.rdlc";
            //        //PageSettings pageSettings = new PageSettings();

            //        //localReport.PrintToPrinter();
            //   }

            ////}
            ////else
            ////{
            ////    panel18.Visible = false;
            ////}



        }

        string imageUrl = null;
        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            //  int[] a = {  };


            //-------------------------------------
            string moveee = "فاتورة مبيعات";

            SqlDataAdapter Da25;
            DataTable Dt25 = new DataTable();
            Da25 = new SqlDataAdapter("select NumBill from BillingData where Move like'" + moveee + "' ", cn);
            Da25.Fill(Dt25);
            combPaperSize.DataSource = Dt25;
            combPaperSize.DisplayMember = "NumBill";



            for (int j = 0; j < combPaperSize.Items.Count; j++)
            {
                //***************************************
                // textBillingDataNumBill.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                // textBillingDataNumBill.Text = a[j].ToString();
                textBillingDataNumBill.Text = combPaperSize.Items[j].ToString();
                //try
                //{

                txtTotalBill.Text = "0";
                TxtNumCategorey.Text = "0";
                txtRemaningOld.Text = "0";
                TotalAndRemaninRasedClient = "0";
                txtDic.Text = "0";
                txtAdd.Text = "0";
                // textBox27.Text = "0";
                txtMosadad.Text = "0";
                // txtMosadad2.Text = "0";
                txtRemainingNow.Text = "0";
                //  textBox28.Text = "";
                textClintID.Text = "";


                //-----------

                comClient.Text = "";
                txtClintName.Text = "";

                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                dt18.Clear();
                SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da18.Fill(dt18);
                this.dataGridView2.DataSource = dt18;
                //------------------------------------



                sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    comClient.Text = read["Name"].ToString();
                    txtClintName.Text = read["Name"].ToString();

                    textBillingDataNumBill.Text = read["NumBill"].ToString();
                    txtTotalBill.Text = read["TotalBill"].ToString();
                    textClintID.Text = read["ClientID"].ToString();
                    textClientGroup.Text = read["Type"].ToString();
                    textUser.Text = read["NamePrint"].ToString();
                    textBox57.Text = read["NameMandop"].ToString();
                    comTypeBill.Text = read["TypeBill"].ToString();

                    TxtNumCategorey.Text = read["NumberCategory"].ToString();
                    txtRemaningOld.Text = read["PreviousBalance"].ToString();
                    TotalAndRemaninRasedClient = read["Total"].ToString();
                    txtDic.Text = read["Discount"].ToString();
                    textBox12.Text = read["ReasonDiscount"].ToString();
                    //  textBox27.Text = read["Creditor"].ToString();
                    txtAdd.Text = read["Adding"].ToString();
                    textBox14.Text = read["ReasonAdd"].ToString();
                    txtMosadad.Text = read["Paid"].ToString();
                    // txtMosadad2.Text = read["Paid"].ToString();
                    txtRemainingNow.Text = read["Remaining"].ToString();
                    //  textBox30.Text = read["State"].ToString();
                    dateTimePicker1.Text = read["Date"].ToString();
                    textNoteBill.Text = read["State"].ToString();

                }
                read.Close();


                sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    MoveBoxID = read["ID"].ToString();



                }
                read.Close();

                //****************************************

                // if (panel18.Visible == false)
                // {
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

                    // Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
                    reportViewerA5.LocalReport.DataSources.Clear();
                    reportViewerA5.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerB5.LocalReport.DataSources.Clear();
                    reportViewerB5.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerCasher.LocalReport.DataSources.Clear();
                    reportViewerCasher.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerCasher_8cm.LocalReport.DataSources.Clear();
                    reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
                    ////------------------------------------------------------
                    reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
                    reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerDiscount.LocalReport.DataSources.Clear();
                    reportViewerDiscount.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerRepEmp.LocalReport.DataSources.Clear();
                    reportViewerRepEmp.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerRepEmpA4.LocalReport.DataSources.Clear();
                    reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerA4.LocalReport.DataSources.Clear();
                    reportViewerA4.LocalReport.DataSources.Add(rs);

                    //getprameterreports();

                    if (SizePaperBill == "A4")
                    {
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingA4.rdlc";
                        getprameterreports(reportViewerA4);

                        //reportViewerA4.Visible = true;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;


                        this.reportViewerA4.RefreshReport();

                        reportViewerA4.LocalReport.PrintToPrinter();

                    }
                    else if (SizePaperBill == "A5")
                    {
                        getprameterreports(reportViewerA5);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = true;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;

                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerA5.RefreshReport();

                        reportViewerA5.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "B5")
                    {
                        getprameterreports(reportViewerB5);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = true;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerB5.RefreshReport();

                        reportViewerB5.LocalReport.PrintToPrinter();

                    }
                    else if (SizePaperBill == "A5 - Discount")
                    {
                        getprameterreports(reportViewerA4);

                        //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingDiscountA5.rdlc";
                    }
                    else if (SizePaperBill == "Casher 6 mm")
                    {
                        getprameterreports(reportViewerCasher);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = true;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerCasher.RefreshReport();

                        reportViewerCasher.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "Casher 8 mm")
                    {
                        getprameterreports(reportViewerCasher_8cm);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;

                        //reportViewerCasher_8cm.Visible = true;

                        this.reportViewerCasher_8cm.RefreshReport();


                        //  panel18.Visible = true;



                        reportViewerCasher_8cm.LocalReport.PrintToPrinter();


                    }

                    else if (SizePaperBill == "Casher 8 mm No Discount")
                    {
                        getprameterreports(reportViewerCasher_8cm_NoDis);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = true;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerCasher_8cm_NoDis.RefreshReport();

                        reportViewerCasher_8cm_NoDis.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "A4 List")
                    {
                        getprameterreports(reportViewerRepEmpA4);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = true;

                        this.reportViewerRepEmpA4.RefreshReport();


                        reportViewerRepEmpA4.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "A5 List")
                    {
                        getprameterreports(reportViewerRepEmp);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = true;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;


                        this.reportViewerRepEmp.RefreshReport();

                        reportViewerRepEmp.LocalReport.PrintToPrinter();


                    }
                    else
                    {
                        MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
                    }
                }
            }

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel18.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Sales_FormClosed(object sender, FormClosedEventArgs e)
        {
            //*************** تسجيل الحركات  ***********************

            //if (txtMosadad.Text == "0" || txtMosadad.Text == "")
            //{
            //    MessageBox.Show("   لم يتم قيمة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (DialogResult == DialogResult.Yes)
            //    {
            //        //do something

            //        MessageBox.Show("   لم يتم قيمة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (DialogResult == DialogResult.No)
            //    {
            //        //do something else
            //    }

            //   // FormClosed = false;
            //}
            //else
            //{


            //    saveEvents("تم غلق شاشة  " + TransferData.FormName);
            //}

            //********************************************************
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Storage = combStorage.Text;

            //-----------  SN ----------------
            label61.Enabled = false;
            textCategoreySN.Text = "";
            textCategoreySN.Enabled = false;

            //---------------------- اظهار مربع الكمية
            textQuntity.Text = "";
            textQuntity.Enabled = true;




            panel_SN.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Storage = "خارج المخزن";
            textBarcode.Text = "";

            //-----------  SN ----------------
            label61.Enabled = false;
            textCategoreySN.Text = "";
            textCategoreySN.Enabled = false;

            //---------------------- اظهار مربع الكمية
            textQuntity.Text = "";
            textQuntity.Enabled = true;


            panel_SN.Visible = false;
        }

        private void label42_Click(object sender, EventArgs e)
        {
            ClosePanel();

            //int x = label14.Location.X - 690;  // وضع البداية بدلالة label14 وضع مكان الكود  
            //int y = label14.Location.Y + 35;

            int x = label14.Location.X - 360;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 30;
            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel3.Location = new Point(x, y);
            this.panel3.Size = new System.Drawing.Size(400, 490);

            panel3.Visible = true;

            GetDataClint();
        }

        private void butClientDays_Click(object sender, EventArgs e)
        {
            //int x = label14.Location.X - 690;  // وضع البداية بدلالة label14 وضع مكان الكود  
            //int y = label14.Location.Y + 35;

            ////textBox8.Text = x.ToString();
            ////textBox7.Text = y.ToString();

            //panel10.Location = new Point(x, y);
            this.panelBillDay.Size = new System.Drawing.Size(690, 371);

            if (dataGridView4.Visible == true)
            {
                //panel14.Visible = false;
                //panel10.Visible = false;
                panelBillDay.Visible = false;
            }
            else
            {
                // panel14.Visible = false;
                // panel10.Visible = false;
                panelBillDay.Visible = true;

                if (FormName == "فاتورة مبيعات")
                {

                    DataTable dt12 = new DataTable();
                    dt12.Clear();
                    SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move like '" + FormName + "' ", cn);
                    da21.Fill(dt12);
                    this.dataGridView4.DataSource = dt12;

                    try
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int i = 0; i < dataGridView4.RowCount; ++i)
                        {
                            sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
                            sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);



                        }
                        textTotalBill.Text = sum.ToString();
                        textTotalTahsel.Text = sum1.ToString();

                    }
                    catch
                    { }

                }
                else if (FormName == "مردودات مشتريات")
                {
                    //            

                    DataTable dt12 = new DataTable();
                    dt12.Clear();
                    SqlDataAdapter da21 = new SqlDataAdapter("select NumBill,Name,Type,TotalBillBuyInvalid as TotalBill,Paid,Remaining from BillingData where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move like '" + FormName + "' ", cn);
                    da21.Fill(dt12);
                    this.dataGridView4.DataSource = dt12;

                    try
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int i = 0; i < dataGridView4.RowCount; ++i)
                        {
                            sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
                            sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);



                        }
                        textTotalBill.Text = sum.ToString();
                        textTotalTahsel.Text = sum1.ToString();

                    }
                    catch
                    { }


                }



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

                    Number = dataGridView2.Rows[0].Cells[0].Value.ToString();

                    // البحث عن الصنف فى الفاتورة 


                    sqlCommand1.CommandText = "select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Num='" + Number + "' ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        NumCategery = reed["Num"].ToString();
                        textQuntity.Text = reed["Quantity"].ToString();
                        textPrice.Text = reed["Price"].ToString();
                        ComTypeCategorey.Text = reed["Type"].ToString();
                        textDiscCategorey1.Text = reed["Discount"].ToString();
                        txtTotalCategory.Text = reed["Total"].ToString();
                        Storage = reed["Storage"].ToString();
                        combCategorys.Text = reed["Category"].ToString();

                    }
                    reed.Close();
                    if (combCategorys.Text == "")

                    {

                    }
                    else
                    {

                        // حذف الصنف من الفاتورة

                        sqlCommand1.CommandText = "delete from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الحركة

                        sqlCommand1.CommandText = "delete from CategoryMove where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        // حذف الصنف من جدول الارباح

                        sqlCommand1.CommandText = "delete from Profit where NumBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        //  حذف الصنف من جدول الحركة الجديده

                        sqlCommand1.CommandText = "delete from CategoryMove2 where IDBill = '" + textBillingDataNumBill.Text + "' and Category='" + combCategorys.Text + "' and Num='" + Number + "'  ";
                        sqlCommand1.ExecuteNonQuery();

                        //--- حساب الاجمالى
                        double n = Convert.ToDouble(txtTotalBill.Text);
                        double d = Convert.ToDouble(txtTotalCategory.Text);
                        double r = n - d;
                        txtTotalBill.Text = r.ToString();

                        double nn = Convert.ToDouble(TotalAndRemaninRasedClient);
                        double dd = Convert.ToDouble(txtTotalCategory.Text);
                        double rr = nn - dd;
                        TotalAndRemaninRasedClient = rr.ToString();


                        double nnn = Convert.ToDouble(TxtNumCategorey.Text);
                        // double dd = Convert.ToDouble(textBox3.Text);
                        double rrr = nnn - 1;
                        TxtNumCategorey.Text = rrr.ToString();


                        //- إيجاد الكميه الفعلية الموجودة بالمخزن

                        sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "'and Storage like '" + Storage + "'   ";
                        reed = sqlCommand1.ExecuteReader();
                        while (reed.Read())
                        {
                            CategoryID = reed["ID"].ToString();
                            textBox18.Text = reed["Quantity"].ToString();
                            textUnityCategrey.Text = reed["Unity"].ToString();
                            textBox20.Text = reed["Faction"].ToString();
                            textBox21.Text = reed["Total"].ToString();

                        }
                        reed.Close();


                        // -------------
                        groupBox5.Text = combCategorys.Text;


                        if (ComTypeCategorey.Text == "كرتونه")
                        {


                            double sn = Convert.ToDouble(textQuntity.Text);
                            double sd = Convert.ToDouble(textBox18.Text);
                            double sr = sn + sd;
                            textBox18.Text = sr.ToString();

                            double an = Convert.ToDouble(textQuntity.Text);
                            double ad = Convert.ToDouble(textUnityCategrey.Text);
                            double ar = an * ad;
                            //textBox25.Text = ar.ToString();

                            //double qn = Convert.ToDouble(textBox25.Text);
                            double qd = Convert.ToDouble(textBox21.Text);
                            double qr = ar + qd;
                            textBox21.Text = qr.ToString();



                            sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',  Total ='" + textBox21.Text + "'  where Category='" + combCategorys.Text + "'and Storage like '" + Storage + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة
                            //------------------------------------
                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;
                            //------------------------------------

                        }
                        else
                        {

                            double sn = Convert.ToDouble(textQuntity.Text);
                            double bn = Convert.ToDouble(textUnityBeea.Text);
                            double sd = Convert.ToDouble(textBox21.Text);
                            double sr = (sn * bn) + sd;
                            textBox21.Text = sr.ToString();

                            // معرفة كمية الاجمالى بعد الخصم

                            int jjs = int.Parse(textBox21.Text);
                            int jsj = int.Parse(textUnityCategrey.Text);
                            int sjj = jjs / jsj;
                            textBox18.Text = sjj.ToString();

                            sqlCommand1.CommandText = "update Category set  Quantity='" + textBox18.Text + "',  Total ='" + textBox21.Text + "'  where Category='" + combCategorys.Text + "'and Storage like '" + Storage + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',  NumberCategory ='" + TxtNumCategorey.Text + "' , Total ='" + TotalAndRemaninRasedClient + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();



                            // ايجاد الاصناف فى الفاتورة
                            //------------------------------------
                            dt11.Clear();
                            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                            da11.Fill(dt11);
                            this.dataGridView2.DataSource = dt11;
                            //------------------------------------


                        }
                    }

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
                    // حساب المتبقى
                    CountRemaining();
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
                    {
                        // تحديث بيانات الفاتورة
                        if (FormName == "فاتورة مبيعات")
                        {
                            sqlCommand1.CommandText = "update BillingData set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();
                        }
                        else if (FormName == "مردودات مشتريات")
                        {
                            sqlCommand1.CommandText = "update BillingData set    TotalBillBuyInvalid='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "' , Total ='" + TotalAndRemaninRasedClient + "', NumberCategory ='" + TxtNumCategorey.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();
                        }

                        sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
                        sqlCommand1.ExecuteNonQuery();
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


                    // Number = Number + 1;

                }

            }


            txtMosadad.Text = "0";
            txtRemainingNow.Text = "0";

            textBillingDataNumBill.Text = "";
        }

        private void butPrintautoss_Click(object sender, EventArgs e)
        {
            // LocalReport report = PrepareReport();

            // if (report == null)
            //     return;
            //  ReportPrinter.Print(report, PaperSizePrint, PaperSizePrint );

            //MessageBox.Show( " PaperSizePrint =   " + PaperSizePrint + " -------  PrinterBill =   " + PrinterBill, "ملحوظة ");

            DirectPrint();


            // ReportPrinter.Print(report, PrinterBill, PaperSizePrint);

            //combPaperSize

            // ReportPrinter.Print(report,combPrinters.Text);

            // ReportPrinter.Print(report, PrinterBill);



            //panel18.Location = new Point(197, 85);
            //this.panel18.Size = new System.Drawing.Size(731, 440);

            //if (checkBox3.Checked == true)
            //{
            //    txtRemaningOld.Text = "0";
            //    CountRemaining();
            //}

            //if (comClient.Text == "")
            //{
            //    MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
            //    comClient.Focus();
            //}
            //else
            //{
            //    AppSetting.ClintID = textClintID.Text;
            //    AppSetting.ClintName = comClient.Text;
            //    AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //    AppSetting.TotalBill = txtTotalBill.Text;
            //    AppSetting.RemaningOld = txtRemaningOld.Text;

            //    AppSetting.Mosadad = txtMosadad.Text;
            //    AppSetting.RemainingNow = txtRemainingNow.Text;
            //    AppSetting.Dic = txtDic.Text;

            //    AppSetting.textBox57 = textUser.Text;
            //    AppSetting.BillingDataNumBill = textBillingDataNumBill.Text;
            //    AppSetting.TypeBill = comTypeBill.Text;
            //    AppSetting.MoveBill = textMoveBill.Text;


            //    List<Class_CategoreysBill> BM = new List<Class_CategoreysBill>();
            //    BM.Clear();
            //    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //    {
            //        Class_CategoreysBill Categoreys = new Class_CategoreysBill
            //        {



            //            Num = dataGridView2.Rows[i].Cells[0].Value.ToString(),
            //            Storage = dataGridView2.Rows[i].Cells[1].Value.ToString(),
            //            Category = dataGridView2.Rows[i].Cells[2].Value.ToString(),
            //            Quantity = dataGridView2.Rows[i].Cells[3].Value.ToString(),
            //            Type = dataGridView2.Rows[i].Cells[4].Value.ToString(),
            //            Price = dataGridView2.Rows[i].Cells[5].Value.ToString(),
            //            Discount = dataGridView2.Rows[i].Cells[6].Value.ToString(),
            //            Total = dataGridView2.Rows[i].Cells[7].Value.ToString()

            //        };

            //        BM.Add(Categoreys);
            //    }
            //    rs.Name = "DataSet1";
            //    rs.Value = BM;

            //    // Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
            //    reportViewerA5.LocalReport.DataSources.Clear();
            //    reportViewerA5.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerB5.LocalReport.DataSources.Clear();
            //    reportViewerB5.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerCasher.LocalReport.DataSources.Clear();
            //    reportViewerCasher.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerCasher_8cm.LocalReport.DataSources.Clear();
            //    reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
            //    ////------------------------------------------------------
            //    reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
            //    reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerDiscount.LocalReport.DataSources.Clear();
            //    reportViewerDiscount.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerRepEmp.LocalReport.DataSources.Clear();
            //    reportViewerRepEmp.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerRepEmpA4.LocalReport.DataSources.Clear();
            //    reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
            //    //------------------------------------------------------
            //    reportViewerA4.LocalReport.DataSources.Clear();
            //    reportViewerA4.LocalReport.DataSources.Add(rs);

            //    //getprameterreports();

            //    if (SizePaperBill == "A4")
            //    {
            //        //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingA4.rdlc";
            //        getprameterreports(reportViewerA4);


            //        this.reportViewerA4.RefreshReport();

            //        reportViewerA4.LocalReport.PrintToPrinter();

            //    }
            //    else if (SizePaperBill == "A5")
            //    {



            //        //--------- طباعه مباشرة ------
            //        getprameterreports(reportViewerA5);
            //        this.reportViewerA5.RefreshReport();

            //        reportViewerA5.LocalReport.PrintToPrinter();


            //    }
            //    else if (SizePaperBill == "B5")
            //    {
            //        getprameterreports(reportViewerB5);


            //        this.reportViewerB5.RefreshReport();

            //        reportViewerB5.LocalReport.PrintToPrinter();

            //    }
            //    else if (SizePaperBill == "A5 - Discount")
            //    {
            //        getprameterreports(reportViewerA4);

            //    }
            //    else if (SizePaperBill == "Casher 6 mm")
            //    {
            //        //------  معيانة بسيطة ----
            //        panel18.Visible = true;

            //        getprameterreports(reportViewerCasher);

            //        reportViewerA4.Visible = false;
            //        reportViewerA5.Visible = false;
            //        reportViewerCasher.Visible = true;
            //        reportViewerRepEmp.Visible = false;
            //        reportViewerB5.Visible = false;
            //        reportViewerDiscount.Visible = false;
            //        reportViewerCasher_8cm.Visible = false;
            //        reportViewerCasher_8cm_NoDis.Visible = false;
            //        reportViewerRepEmpA4.Visible = false;
            //        this.reportViewerCasher.RefreshReport();

            //        //--------- طباعه مباشرة ------
            //        //getprameterreports(reportViewerCasher);
            //        //this.reportViewerCasher.RefreshReport();

            //        //reportViewerCasher.LocalReport.PrintToPrinter();


            //    }
            //    else if (SizePaperBill == "Casher 8 mm")
            //    {
            //        //------  معيانة بسيطة ----
            //        panel18.Visible = true;

            //        getprameterreports(reportViewerCasher_8cm);



            //        reportViewerA4.Visible = false;
            //        reportViewerA5.Visible = false;
            //        reportViewerCasher.Visible = false;
            //        reportViewerRepEmp.Visible = false;
            //        reportViewerB5.Visible = false;
            //        reportViewerDiscount.Visible = false;
            //        reportViewerCasher_8cm.Visible = true;
            //        reportViewerCasher_8cm_NoDis.Visible = false;
            //        reportViewerRepEmpA4.Visible = false;
            //        this.reportViewerCasher_8cm.RefreshReport();






            //    }

            //    else if (SizePaperBill == "Casher 8 mm No Discount") // Casher 8 mm No Discount
            //    {

            //        //------  معيانة بسيطة ----
            //        panel18.Visible = true;

            //        getprameterreports(reportViewerCasher_8cm_NoDis);

            //        reportViewerA4.Visible = false;
            //        reportViewerA5.Visible = false;
            //        reportViewerCasher.Visible = false;
            //        reportViewerRepEmp.Visible = false;
            //        reportViewerB5.Visible = false;
            //        reportViewerDiscount.Visible = false;
            //        reportViewerCasher_8cm.Visible = false;
            //        reportViewerCasher_8cm_NoDis.Visible = true;
            //        reportViewerRepEmpA4.Visible = false;
            //        this.reportViewerCasher_8cm_NoDis.RefreshReport();




            //    }
            //    else if (SizePaperBill == "A4 List")
            //    {
            //        getprameterreports(reportViewerRepEmpA4);


            //        this.reportViewerRepEmpA4.RefreshReport();


            //        reportViewerRepEmpA4.LocalReport.PrintToPrinter();


            //    }
            //    else if (SizePaperBill == "A5 List")
            //    {
            //        getprameterreports(reportViewerRepEmp);



            //        this.reportViewerRepEmp.RefreshReport();

            //        reportViewerRepEmp.LocalReport.PrintToPrinter();


            //    }
            //    else
            //    {
            //        MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
            //    }

            //}



        }

        private void butPrinting_Click(object sender, EventArgs e)
        {

            //-------------------- معرفة نسخة تجريبية ام لا لكتابة البيانات على الفاتورة فى التجريبى
            string Demo = Properties.Settings.Default.Demo; //يقرا من الخصائص نوع نسخة البرنامج تجربى ام لا
            if (Demo == "")
            {
            }
            else if (Demo == "no")
            {
                //TsmLicense.Enabled = true;

            }
            else if (Demo == "yes")
            {
                AppSetting.DemoOnBill = "برنامج زاد - الوصيف للبرمجيات  01224349933  ";
            }

            //-----------------------------------------------------------------
            if (checkBox3.Checked == true)
            {
                txtRemaningOld.Text = "0";
                CountRemaining();
            }


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




                //rbm.reportViewerMain.LocalReport.DataSources.Clear();
                //rbm.reportViewerMain.LocalReport.DataSources.Add(rs);

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

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد تعديل تاريخ الفاتورة ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                sqlCommand1.CommandText = "update Billing set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  NumBill ='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                // ..........................

                sqlCommand1.CommandText = "update BillingData set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  NumBill ='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "update BoxMove set Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  NumBill ='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "update Profit set Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  NumBill ='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "update CategoryMove2 set Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  IDBill ='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "update CategoryMove set Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  IDBill ='" + textBillingDataNumBill.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void butAllBillng_Click(object sender, EventArgs e)
        {
            //  int[] a = {  };


            //-------------------------------------
            string moveee = "فاتورة مبيعات";

            SqlDataAdapter Da25;
            DataTable Dt25 = new DataTable();
            Da25 = new SqlDataAdapter("select NumBill from BillingData where Move like'" + moveee + "' ", cn);
            Da25.Fill(Dt25);
            combPaperSize.DataSource = Dt25;
            combPaperSize.DisplayMember = "NumBill";



            for (int j = 0; j < combPaperSize.Items.Count; j++)
            {
                //***************************************
                // textBillingDataNumBill.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                // textBillingDataNumBill.Text = a[j].ToString();
                textBillingDataNumBill.Text = combPaperSize.Items[j].ToString();
                //try
                //{

                txtTotalBill.Text = "0";
                TxtNumCategorey.Text = "0";
                txtRemaningOld.Text = "0";
                TotalAndRemaninRasedClient = "0";
                txtDic.Text = "0";
                txtAdd.Text = "0";
                // textBox27.Text = "0";
                txtMosadad.Text = "0";
                // txtMosadad2.Text = "0";
                txtRemainingNow.Text = "0";
                //  textBox28.Text = "";
                textClintID.Text = "";


                //-----------

                comClient.Text = "";
                txtClintName.Text = "";

                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                dt18.Clear();
                SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da18.Fill(dt18);
                this.dataGridView2.DataSource = dt18;
                //------------------------------------



                sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    comClient.Text = read["Name"].ToString();
                    txtClintName.Text = read["Name"].ToString();

                    textBillingDataNumBill.Text = read["NumBill"].ToString();
                    txtTotalBill.Text = read["TotalBill"].ToString();
                    textClintID.Text = read["ClientID"].ToString();
                    textClientGroup.Text = read["Type"].ToString();
                    textUser.Text = read["NamePrint"].ToString();
                    textBox57.Text = read["NameMandop"].ToString();
                    comTypeBill.Text = read["TypeBill"].ToString();

                    TxtNumCategorey.Text = read["NumberCategory"].ToString();
                    txtRemaningOld.Text = read["PreviousBalance"].ToString();
                    TotalAndRemaninRasedClient = read["Total"].ToString();
                    txtDic.Text = read["Discount"].ToString();
                    textBox12.Text = read["ReasonDiscount"].ToString();
                    //  textBox27.Text = read["Creditor"].ToString();
                    txtAdd.Text = read["Adding"].ToString();
                    textBox14.Text = read["ReasonAdd"].ToString();
                    txtMosadad.Text = read["Paid"].ToString();
                    // txtMosadad2.Text = read["Paid"].ToString();
                    txtRemainingNow.Text = read["Remaining"].ToString();
                    //  textBox30.Text = read["State"].ToString();
                    dateTimePicker1.Text = read["Date"].ToString();
                    textNoteBill.Text = read["State"].ToString();

                }
                read.Close();


                sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    MoveBoxID = read["ID"].ToString();



                }
                read.Close();

                //****************************************

                // if (panel18.Visible == false)
                // {
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

                    // Reports.Frm_ReportBill rbm = new Reports.Frm_ReportBill();
                    reportViewerA5.LocalReport.DataSources.Clear();
                    reportViewerA5.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerB5.LocalReport.DataSources.Clear();
                    reportViewerB5.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerCasher.LocalReport.DataSources.Clear();
                    reportViewerCasher.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerCasher_8cm.LocalReport.DataSources.Clear();
                    reportViewerCasher_8cm.LocalReport.DataSources.Add(rs);
                    ////------------------------------------------------------
                    reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Clear();
                    reportViewerCasher_8cm_NoDis.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerDiscount.LocalReport.DataSources.Clear();
                    reportViewerDiscount.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerRepEmp.LocalReport.DataSources.Clear();
                    reportViewerRepEmp.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerRepEmpA4.LocalReport.DataSources.Clear();
                    reportViewerRepEmpA4.LocalReport.DataSources.Add(rs);
                    //------------------------------------------------------
                    reportViewerA4.LocalReport.DataSources.Clear();
                    reportViewerA4.LocalReport.DataSources.Add(rs);

                    //getprameterreports();

                    if (SizePaperBill == "A4")
                    {
                        //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingA4.rdlc";
                        getprameterreports(reportViewerA4);

                        //reportViewerA4.Visible = true;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;


                        this.reportViewerA4.RefreshReport();

                        reportViewerA4.LocalReport.PrintToPrinter();

                    }
                    else if (SizePaperBill == "A5")
                    {
                        getprameterreports(reportViewerA5);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = true;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;

                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerA5.RefreshReport();

                        reportViewerA5.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "B5")
                    {
                        getprameterreports(reportViewerB5);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = true;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerB5.RefreshReport();

                        reportViewerB5.LocalReport.PrintToPrinter();

                    }
                    else if (SizePaperBill == "A5 - Discount")
                    {
                        getprameterreports(reportViewerA4);

                        //reportViewer1.LocalReport.ReportEmbeddedResource = "ReportBillingDiscountA5.rdlc";
                    }
                    else if (SizePaperBill == "Casher 6 mm")
                    {
                        getprameterreports(reportViewerCasher);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = true;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerCasher.RefreshReport();

                        reportViewerCasher.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "Casher 8 mm")
                    {
                        getprameterreports(reportViewerCasher_8cm);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;

                        //reportViewerCasher_8cm.Visible = true;

                        this.reportViewerCasher_8cm.RefreshReport();


                        //  panel18.Visible = true;



                        reportViewerCasher_8cm.LocalReport.PrintToPrinter();


                    }

                    else if (SizePaperBill == "Casher 8 mm No Discount")
                    {
                        getprameterreports(reportViewerCasher_8cm_NoDis);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = true;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;

                        this.reportViewerCasher_8cm_NoDis.RefreshReport();

                        reportViewerCasher_8cm_NoDis.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "A4 List")
                    {
                        getprameterreports(reportViewerRepEmpA4);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = false;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = true;

                        this.reportViewerRepEmpA4.RefreshReport();


                        reportViewerRepEmpA4.LocalReport.PrintToPrinter();


                    }
                    else if (SizePaperBill == "A5 List")
                    {
                        getprameterreports(reportViewerRepEmp);

                        //reportViewerA4.Visible = false;
                        //reportViewerA5.Visible = false;
                        //reportViewerCasher.Visible = false;
                        //reportViewerRepEmp.Visible = true;
                        //reportViewerB5.Visible = false;
                        //reportViewerDiscount.Visible = false;
                        //reportViewerCasher_8cm.Visible = false;
                        //reportViewerCasher_8cm_NoDis.Visible = false;
                        //reportViewerRepEmpA4.Visible = false;


                        this.reportViewerRepEmp.RefreshReport();

                        reportViewerRepEmp.LocalReport.PrintToPrinter();


                    }
                    else
                    {
                        MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
                    }
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            ClosePanel();

            int x = label14.Location.X - 290;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 150;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panelLastPrice.Location = new Point(x, y);


            //panel2.Location = new Point(300, 219);
            this.panelLastPrice.Size = new System.Drawing.Size(342, 281);


            if (panelLastPrice.Visible == true)
            {
                panelLastPrice.Visible = false;
            }
            else
            {
                panelLastPrice.Visible = true;
            }
        }

        private void radio_GetAllCategry_Quntety_CheckedChanged(object sender, EventArgs e)
        {
            dataGridGetAllCategry_BestSeller.Visible = false;
            dataGridCategory_BestSeller.Visible = false;
            dataGridSearchCategory.Visible = true;
            GetAllCategry_Quntety();
        }

        private void radio_GetAllCategry_CheckedChanged(object sender, EventArgs e)
        {
            dataGridGetAllCategry_BestSeller.Visible = false;
            dataGridCategory_BestSeller.Visible = false;
            dataGridSearchCategory.Visible = true;
            GetAllCategry();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            dataGridGetAllCategry_BestSeller.Visible = true;
            dataGridSearchCategory.Visible = false;
            dataGridCategory_BestSeller.Visible = false;
            GetAllCategry_BestSeller();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridSearchCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridGetAllCategry_BestSeller_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridGetAllCategry_BestSeller.Rows[e.RowIndex].Cells[1].Value.ToString();


            // textBox1.Text = "";



            if (checkBox1.Checked == true)
            {
                // textQuntity.Text = textQuntetyAuto.Text;
                textQuntity.Text = textQuntetyAuto.Text;
                butAddCategorey.PerformClick();
                textBox1.Focus();
            }
            else
            {
                // panel2.Visible = false;
                textQuntity.Focus();



            }
        }

        private void radCategory_BestSeller_CheckedChanged(object sender, EventArgs e)
        {
            dataGridGetAllCategry_BestSeller.Visible = false;
            dataGridSearchCategory.Visible = false;
            dataGridCategory_BestSeller.Visible = true;
            GetCategory_BestSeller();
        }

        private void dataGridCategory_BestSeller_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridCategory_BestSeller.Rows[e.RowIndex].Cells[1].Value.ToString();








            if (checkBox1.Checked == true)
            {
                // textQuntity.Text = textQuntetyAuto.Text;
                textQuntity.Text = textQuntetyAuto.Text;
                butAddCategorey.PerformClick();
                textBox1.Focus();
            }
            else
            {
                // panel2.Visible = false;
                textQuntity.Focus();



            }


            //if (checkBox4.Checked == true)
            //{
            //    textBox1.Text = "";
            //}
            //else
            //{
            //    // textBox1.Text = "";



            //}
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Storage = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            //dataGridView2.Rows.Add("1","شاى", "10", "20", "", "", "", "100");
        }

        int rowindex;
        private bool bIsButtonClicked;
        private static object _threadProcessCCTV;

        private void buttonUP_Click(object sender, EventArgs e)
        {
            rowindex = dataGridView5.SelectedCells[0].OwningRow.Index;
            DataRow row = table.NewRow();
            row[0] = dataGridView5.Rows[rowindex].Cells[0].Value.ToString();
            row[1] = dataGridView5.Rows[rowindex].Cells[1].Value.ToString();
            row[2] = dataGridView5.Rows[rowindex].Cells[2].Value.ToString();
            row[3] = dataGridView5.Rows[rowindex].Cells[3].Value.ToString();
            row[4] = dataGridView5.Rows[rowindex].Cells[4].Value.ToString();
            row[5] = dataGridView5.Rows[rowindex].Cells[5].Value.ToString();
            row[6] = dataGridView5.Rows[rowindex].Cells[6].Value.ToString();
            row[7] = dataGridView5.Rows[rowindex].Cells[7].Value.ToString();

            if (rowindex > 0)
            {
                table.Rows.RemoveAt(rowindex);
                table.Rows.InsertAt(row, rowindex - 1);
                dataGridView5.ClearSelection();
                dataGridView5.Rows[rowindex - 1].Selected = true;
            }

            //rowindex = dataGridView2.SelectedCells[0].OwningRow.Index;
            //DataRow row = table.NewRow();
            //row[0] = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
            //row[1] = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
            //row[2] = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();
            //row[3] = dataGridView2.Rows[rowindex].Cells[3].Value.ToString();
            //row[4] = dataGridView2.Rows[rowindex].Cells[4].Value.ToString();
            //row[5] = dataGridView2.Rows[rowindex].Cells[5].Value.ToString();
            //row[6] = dataGridView2.Rows[rowindex].Cells[6].Value.ToString();
            //row[7] = dataGridView2.Rows[rowindex].Cells[7].Value.ToString();

            //if (rowindex > 0)
            //{
            //    table.Rows.RemoveAt(rowindex);
            //    table.Rows.InsertAt(row, rowindex - 1);
            //    dataGridView2.ClearSelection();
            //    dataGridView2.Rows[rowindex - 1].Selected = true;
            //}

        }

        private void buttondown_Click(object sender, EventArgs e)
        {
            rowindex = dataGridView5.SelectedCells[0].OwningRow.Index;
            DataRow row = table.NewRow();
            row[0] = dataGridView5.Rows[rowindex].Cells[0].Value.ToString();
            row[1] = dataGridView5.Rows[rowindex].Cells[1].Value.ToString();
            row[2] = dataGridView5.Rows[rowindex].Cells[2].Value.ToString();
            row[3] = dataGridView5.Rows[rowindex].Cells[3].Value.ToString();
            row[4] = dataGridView5.Rows[rowindex].Cells[4].Value.ToString();
            row[5] = dataGridView5.Rows[rowindex].Cells[5].Value.ToString();
            row[6] = dataGridView5.Rows[rowindex].Cells[6].Value.ToString();
            row[7] = dataGridView5.Rows[rowindex].Cells[7].Value.ToString();

            if (rowindex < dataGridView5.Rows.Count - 2)
            {
                table.Rows.RemoveAt(rowindex);
                table.Rows.InsertAt(row, rowindex + 1);
                dataGridView5.ClearSelection();
                dataGridView5.Rows[rowindex + 1].Selected = true;
            }

            //rowindex = dataGridView2.SelectedCells[0].OwningRow.Index;
            //DataRow row = table.NewRow();
            //row[0] = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
            //row[1] = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
            //row[2] = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();
            //row[3] = dataGridView2.Rows[rowindex].Cells[3].Value.ToString();
            //row[4] = dataGridView2.Rows[rowindex].Cells[4].Value.ToString();
            //row[5] = dataGridView2.Rows[rowindex].Cells[5].Value.ToString();
            //row[6] = dataGridView2.Rows[rowindex].Cells[6].Value.ToString();
            //row[7] = dataGridView2.Rows[rowindex].Cells[7].Value.ToString();

            //if (rowindex < dataGridView2.Rows.Count - 2)
            //{
            //    table.Rows.RemoveAt(rowindex);
            //    table.Rows.InsertAt(row, rowindex + 1);
            //    dataGridView2.ClearSelection();
            //    dataGridView2.Rows[rowindex + 1].Selected = true;
            //}
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

            //     public string Num { get; set; }
            //public string Storage { get; set; }
            //public string Category { get; set; }
            //public string Quantity { get; set; }
            //public string Type { get; set; }
            //public string Price { get; set; }
            //public string Discount { get; set; }
            //public string Total { get; set; }
            try
            {
                table.Columns.Add("Num", typeof(string));
                table.Columns.Add("Storage", typeof(string));
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Quantity", typeof(string));
                table.Columns.Add("Type", typeof(string));
                table.Columns.Add("Price", typeof(string));
                table.Columns.Add("Discount", typeof(string));
                table.Columns.Add("Total", typeof(string));
            }
            catch
            { }

            table.Rows.Add("1", combStorage.Text, combCategorys.Text, textQuntity.Text, ComTypeCategorey.Text, textPrice.Text, "0", txtTotalCategory.Text);

            dataGridView5.DataSource = table;
        }

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

        private void textQuntity_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void textDiscCategorey1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void txtTotalCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void textDiscCategorey_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////ClassProject.ClassCloseLettering.
            //ClassProject.ClassCloseLettering.keysCloseLettering(sender, e);

            keys(sender, e);


        }

        private void textNumBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTotalTahsel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textTotalBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void textDiscCategorey1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double ncsn = Convert.ToDouble(textPrice.Text);
                    double dcsd = Convert.ToDouble(textDiscCategorey1.Text);
                    double rcsr = (100 * dcsd) / ncsn;
                    textDiscCategorey.Text = rcsr.ToString();

                    textDiscCategorey.Text = Math.Round(double.Parse(textDiscCategorey.Text), 2).ToString();


                }
                catch
                { }

            }
        }

        private void textDiscCategorey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double ncsn = Convert.ToDouble(textPrice.Text);
                    double dcsd = Convert.ToDouble(textDiscCategorey.Text);
                    double rcsr = (100 * dcsd) / ncsn;
                    textDiscCategorey1.Text = rcsr.ToString();

                    textDiscCategorey1.Text = Math.Round(double.Parse(textDiscCategorey1.Text), 2).ToString();


                }
                catch
                { }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void butAdd3_Click(object sender, EventArgs e)
        {

            // ---------- اختبار الحد الائتمانى

            if (LimitCredit == "1") //--------- الحد الائتمانى مفعل
            {
                double al = Convert.ToDouble(textLimitCredit.Text);


                double a = Convert.ToDouble(txtTotalCategory.Text);
                double b = Convert.ToDouble(txtRemaningOld.Text);
                double c = Convert.ToDouble(txtTotalBill.Text);
                double aaa = a + b + c;
                if (aaa > al) // -------- الاجمالى والفاتورة والصنف اكبر من الحد الائتمانى
                {
                    MessageBox.Show("     لن يمكن اضافة الصنف الجديد لزيادة الاجمالى عن الحد الائتمانى      ", "الحد الائتمانى");
                }
                else
                {
                    if (textBillingDataNumBill.Text == "")
                    {
                        GetNumBill2();


                    }
                    else
                    { }

                    try
                    {
                        if (radioButton2.Checked == true) // صنف خارج المخزن
                        {
                            //chekTextEmpty();
                            MessageBox.Show("     الصنف الخارجى غير مفعل      ", "ملحوظة");

                        }
                        else  // صنف من المخزن
                        {
                            double Price = Convert.ToDouble(textPrice.Text);
                            double PriceSH = Convert.ToDouble(textPriceSH.Text);
                            if (Price < PriceSH)
                            {
                                DialogResult dialogResult = MessageBox.Show("ملحوظة : سعر البيع أقل من سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    chekTextEmpty2();



                                }
                                else if (dialogResult == DialogResult.No)
                                {

                                }
                            }

                            else if (Price == PriceSH)
                            {
                                DialogResult dialogResult2 = MessageBox.Show("ملحوظة : سعر البيع يساوى سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult2 == DialogResult.Yes)
                                {
                                    chekTextEmpty2();



                                }
                                else if (dialogResult2 == DialogResult.No)
                                {

                                }
                            }
                            else
                            {
                                chekTextEmpty2();


                            }
                        }

                        //  AddCategory_BestSeller();
                        textPrice.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("    من فضلك تاكد من كتابة الارقام والعلامات العشرية بطريقة صحيحة   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else  //---------- الحد الائتمانى غير مفعل
            {

                if (textBillingDataNumBill.Text == "")
                {
                    GetNumBill2();

                }
                else
                { }

                try
                {
                    if (radioButton2.Checked == true) // صنف خارج المخزن
                    {
                        //chekTextEmpty();
                        MessageBox.Show("     الصنف الخارجى غير مفعل      ", "ملحوظة");

                    }
                    else  // صنف من المخزن
                    {
                        double Price = Convert.ToDouble(textPrice.Text);
                        double PriceSH = Convert.ToDouble(textPriceSH.Text);
                        if (Price < PriceSH)
                        {
                            DialogResult dialogResult = MessageBox.Show("ملحوظة : سعر البيع أقل من سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                chekTextEmpty2();



                            }
                            else if (dialogResult == DialogResult.No)
                            {

                            }
                        }

                        else if (Price == PriceSH)
                        {
                            DialogResult dialogResult2 = MessageBox.Show("ملحوظة : سعر البيع يساوى سعر الشراء هل تريد استكمال البيع", "ملحوظة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult2 == DialogResult.Yes)
                            {
                                chekTextEmpty2();



                            }
                            else if (dialogResult2 == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            chekTextEmpty2();


                        }
                    }

                    // AddCategory_BestSeller();
                    textPrice.Text = "";

                    //  RebhCategory();
                }
                catch
                {
                    MessageBox.Show("    من فضلك تاكد من كتابة الارقام والعلامات العشرية بطريقة صحيحة   ", " خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void butBillingNoSave_Click(object sender, EventArgs e)
        {


            if (panelBillingNoSave.Visible == true)
            {
                //panel14.Visible = false;
                //panel10.Visible = false;
                panelBillingNoSave.Visible = false;
            }
            else
            {
                // panel14.Visible = false;
                // panel10.Visible = false;
                panelBillingNoSave.Visible = true;


                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData2  ", cn);
                da21.Fill(dt12);
                this.dataGridView6.DataSource = dt12;

                try
                {
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView6.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView6.Rows[i].Cells[3].Value);
                        sum1 += Convert.ToDouble(dataGridView6.Rows[i].Cells[4].Value);



                    }
                    textTotalBillNoSave.Text = sum.ToString();
                    //  textTotalTahsel.Text = sum1.ToString();

                }
                catch
                { }



                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber + "";
                    rowNumber = rowNumber + 1;

                    rowNumber1 = rowNumber1 + 1;
                }
                // dataGridClientsDay.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                //عدد الفواتير
                textNumBillNoSave.Text = rowNumber1.ToString();
            }
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            txtTotalBill.Text = "0";
            TxtNumCategorey.Text = "0";
            txtRemaningOld.Text = "0";
            TotalAndRemaninRasedClient = "0";
            txtDic.Text = "0";
            txtAdd.Text = "0";
            // textBox27.Text = "0";
            txtMosadad.Text = "0";
            // txtMosadad2.Text = "0";
            txtRemainingNow.Text = "0";
            //  textBox28.Text = "";
            textClintID.Text = "";


            textBillingDataNumBillNoSave.Text = dataGridView6.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTotalBillNoSave.Text = dataGridView6.Rows[e.RowIndex].Cells[3].Value.ToString();
            //try
            //{




            //-----------

            comClient.Text = "";
            txtClintName.Text = "";

            // ايجاد الاصناف فى الفاتورة

            comClient.Text = dataGridView6.Rows[e.RowIndex].Cells[1].Value.ToString();

            //------------------------------------
            dt2.Clear();
            SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing2 where NumBill = '" + textBillingDataNumBillNoSave.Text + "' ", cn);
            da18.Fill(dt2);
            this.dataGridView7.DataSource = dt2;
            //------------------------------------



            sqlCommand1.CommandText = "select * from BillingData2 where NumBill = '" + textBillingDataNumBillNoSave.Text + "'";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                //comClient.Text = read["Name"].ToString();
                //txtClintName.Text = read["Name"].ToString();

                textBillingDataNumBillNoSave.Text = read["NumBill"].ToString();
                //// txtTotalBill.Text = read["TotalBill"].ToString();
                //textClintID.Text = read["ClientID"].ToString();
                //textClientGroup.Text = read["Type"].ToString();
                //textUser.Text = read["NamePrint"].ToString();
                //textBox57.Text = read["NameMandop"].ToString();
                //comTypeBill.Text = read["TypeBill"].ToString();

                //TxtNumCategorey.Text = read["NumberCategory"].ToString();
                //txtRemaningOld.Text = read["PreviousBalance"].ToString();
                //TotalAndRemaninRasedClient = read["Total"].ToString();
                //txtDic.Text = read["Discount"].ToString();
                //textBox12.Text = read["ReasonDiscount"].ToString();
                ////  textBox27.Text = read["Creditor"].ToString();
                //txtAdd.Text = read["Adding"].ToString();
                //textBox14.Text = read["ReasonAdd"].ToString();
                //txtMosadad.Text = read["Paid"].ToString();
                //// txtMosadad2.Text = read["Paid"].ToString();
                //txtRemainingNow.Text = read["Remaining"].ToString();
                ////  textBox30.Text = read["State"].ToString();
                //dateTimePicker1.Text = read["Date"].ToString();
                //textNoteBill.Text = read["State"].ToString();

            }
            read.Close();


            //sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBillNoSave.Text + "' and  Move = '" + textMoveBill.Text + "'";
            //read = sqlCommand1.ExecuteReader();
            //while (read.Read())
            //{
            //    MoveBoxID = read["ID"].ToString();



            //}
            //read.Close();
            //}
            //catch
            //{

            //}

            if (comClient.Enabled == true)
            {
                comClient.Enabled = false;
                // dateTimePicker1.Enabled = false;
                textBillingDataNumBillNoSave.Enabled = false;
            }
            else { }

            textBox6.Text = Convert.ToInt32(dataGridView7.RowCount).ToString();
        }

        private void butAddDataToBill_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد اضافة الاصناف  ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridView7.RowCount - 1);
                int num = 1;
                for (int j = 0; j < NumRows; j++) // rows
                {
                    //for (int i = 0; i <= 8; i++)// colom
                    //{
                    num = int.Parse(dataGridView7.Rows[j].Cells[0].Value.ToString());

                    combStorage.Text = dataGridView7.Rows[j].Cells[1].Value.ToString();
                    combCategorys.Text = dataGridView7.Rows[j].Cells[2].Value.ToString();
                    textQuntity.Text = dataGridView7.Rows[j].Cells[3].Value.ToString();
                    ComTypeCategorey.Text = dataGridView7.Rows[j].Cells[4].Value.ToString();
                    textPrice.Text = dataGridView7.Rows[j].Cells[5].Value.ToString();
                    textDiscCategorey1.Text = dataGridView7.Rows[j].Cells[6].Value.ToString();


                    butAddCategorey.PerformClick();
                    num++;

                    textBox6.Text = num.ToString();

                    // }
                }


                sqlCommand1.CommandText = "delete from BillingData2 where NumBill = '" + textBillingDataNumBillNoSave.Text + "'   ";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "delete from Billing2 where NumBill = '" + textBillingDataNumBillNoSave.Text + "'   ";
                sqlCommand1.ExecuteNonQuery();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClosePanel();

            //textBox8.Text = label14.Location.X.ToString();
            //textBox7.Text = label14.Location.Y.ToString();

            int x = label14.Location.X - 690;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 35;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel10.Location = new Point(x, y);
            this.panel10.Size = new System.Drawing.Size(742, 351);

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
        private void GetProfitBill()
        {
            try
            {
                textTotalProfit.Text = "0"; // ROUND(sum(Quantity),2) as Quantity
                textTotalSheraa.Text = "0";
                textTotalBeaa.Text = "0";
                sqlCommand1.CommandText = "select ROUND(sum(PriceShraa),2) as PriceShraa,ROUND(sum(PriceBeaa),2) as PriceBeaa,ROUND(sum(Profit),2) as Profit from Profit where  NumBill='" + textBillingDataNumBill.Text + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    textTotalSheraa.Text = reed["PriceShraa"].ToString();
                    textTotalBeaa.Text = reed["PriceBeaa"].ToString();
                    textTotalProfit.Text = reed["Profit"].ToString();


                    //-------------------------------------------



                }
                reed.Close();
            }
            catch { }
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


                GetProfitBill();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (FormName == "فاتورة مبيعات")
            {

                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from BillingData where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' and Move like '" + FormName + "' ", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;

                try
                {
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
                        sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);



                    }
                    textTotalBill.Text = sum.ToString();
                    textTotalTahsel.Text = sum1.ToString();

                }
                catch
                { }

            }
            else if (FormName == "مردودات مشتريات")
            {
                //            

                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select NumBill,Name,Type,TotalBillBuyInvalid as TotalBill,Paid,Remaining from BillingData where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' and Move like '" + FormName + "' ", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;

                try
                {
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
                        sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);



                    }
                    textTotalBill.Text = sum.ToString();
                    textTotalTahsel.Text = sum1.ToString();

                }
                catch
                { }


            }



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

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {
            //textBox7.Text = label14.Location.Y.ToString();
            //textBox8.Text = label14.Location.X.ToString();
        }


        private void OpenPanelSN()
        {

            //-----------  SN ----------------

            label61.Enabled = true;
            textCategoreySN.Enabled = true;

            //----------------  فتح السرايل
            int x = label14.Location.X - 520;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 245;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel_SN.Location = new Point(x, y);


            //panel2.Location = new Point(300, 219);
            this.panel_SN.Size = new System.Drawing.Size(576, 248);



            panel_SN.Visible = true;


            //---------------------- اخفاء مربع الكمية
            textQuntity.Text = "1";
            textQuntity.Enabled = false;



        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            OpenPanelSN();

            //-----------  SN ----------------

            //label61.Enabled = true;
            //textCategoreySN.Enabled = true;

            ////----------------  فتح السرايل
            //int x = label14.Location.X - 520;  // وضع البداية بدلالة label14 وضع مكان الكود  
            //int y = label14.Location.Y + 345;

            ////textBox8.Text = x.ToString();
            ////textBox7.Text = y.ToString();

            //panel_SN.Location = new Point(x, y);


            ////panel2.Location = new Point(300, 219);
            //this.panel_SN.Size = new System.Drawing.Size(576, 248);


            //if (panel_SN.Visible == true)
            //{
            //    panel_SN.Visible = false;
            //}
            //else
            //{
            //    panel_SN.Visible = true;
            //}


            ////---------------------- اخفاء مربع الكمية
            //textQuntity.Text = "1";
            //textQuntity.Enabled = false;




        }

        private void label61_Click(object sender, EventArgs e)
        {
            ClosePanel();

            //OpenPanelSN();


            int x = label14.Location.X - 520;  // وضع البداية بدلالة label14 وضع مكان الكود  
            int y = label14.Location.Y + 345;

            //textBox8.Text = x.ToString();
            //textBox7.Text = y.ToString();

            panel_SN.Location = new Point(x, y);


            //panel2.Location = new Point(300, 219);
            this.panel_SN.Size = new System.Drawing.Size(576, 248);


            if (panel_SN.Visible == true)
            {
                panel_SN.Visible = false;
            }
            else
            {
                panel_SN.Visible = true;
            }
        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textID_SN.Text = dataGridView8.Rows[e.RowIndex].Cells[0].Value.ToString();
            textCategoreySN.Text = dataGridView8.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBillingDataNumBill.Text == "")
            {

                saveEvents("تم غلق شاشة  " + TransferData.FormName);
            }
            else
            {
                if (txtMosadad.Text == "0" || txtMosadad.Text == "")
                {
                    dynamic result = MessageBox.Show("   لم يتم دفع اى  مبلغ فى خانة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    dynamic result = MessageBox.Show("Do You Want To Exit?", "Application Name", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {
            //        Application.Exit();
            //    }

            //    if (result == DialogResult.No)
            //    {
            //        e.Cancel = true;

            //        if (txtMosadad.Text == "0" || txtMosadad.Text == "")
            //        {
            //            if (MessageBox.Show("Are you sure you want to close the form?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //                e.Cancel = false;
            //            else
            //                // Cancel the Closing event from closing the form.
            //                e.Cancel = true;
            //            MessageBox.Show("   لم يتم قيمة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        }
            //        else
            //        {


            //            saveEvents("تم غلق شاشة  " + TransferData.FormName);
            //        }
            //    }
            //}



            //*********************************************


            //if (e.CloseReason != CloseReason.UserClosing)
            //    return;
            //if (bIsButtonClicked == true)
            //{
            //    //if (_threadProcessCCTV.IsAlive)
            //    //{

            //    if (txtMosadad.Text == "0" || txtMosadad.Text == "")
            //    {
            //        if (MessageBox.Show("Are you sure you want to close the form?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //            e.Cancel = false;
            //        else
            //            // Cancel the Closing event from closing the form.
            //            e.Cancel = true;
            //        MessageBox.Show("   لم يتم قيمة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //    else
            //    {


            //        saveEvents("تم غلق شاشة  " + TransferData.FormName);
            //    }
            //    //}
            //}



            //if (txtMosadad.Text == "0" || txtMosadad.Text == "")
            //{
            //    MessageBox.Show("   لم يتم قيمة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (DialogResult == DialogResult.Yes)
            //    {
            //        //do something

            //        MessageBox.Show("   لم يتم قيمة المسدد هل تريد الاستكمال بدون تسديد اى مبلغ من العميل   ", "المسدد من الفاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else if (DialogResult == DialogResult.No)
            //    {
            //        //do something else
            //    }

            //   //  this.FormClosing= = false;
            //}
            //else
            //{


            //    saveEvents("تم غلق شاشة  " + TransferData.FormName);
            //}
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            ClosePanel();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textMoveBill.Text = comMoveBill.Text;
        }

        private void panel21_Click(object sender, EventArgs e)
        {
            ClosePanel();
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

        private void checkCopyBill_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // ايجاد الاصناف فى الفاتورة

            //------------------------------------
            dt8.Clear();
            SqlDataAdapter da8 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBillCopy.Text + "' ", cn);
            da8.Fill(dt8);
            this.dataGridView9.DataSource = dt8;
            //------------------------------------

            try
            {
                double sum = 0;
                //  double sum1 = 0;
                for (int i = 0; i < dataGridView9.RowCount; ++i)
                {
                    sum += Convert.ToDouble(dataGridView9.Rows[i].Cells[7].Value);
                    //  sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);



                }
                textTotalBill5.Text = sum.ToString();
                // textTotalTahsel.Text = sum1.ToString();

            }
            catch
            { }

        }

        private void butAddBill_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد اضافة الاصناف  ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {


                int NumRows = Convert.ToInt32(dataGridView9.RowCount - 1);
                int num = 1;

                for (int j = 0; j < NumRows; j++) // rows
                {

                    num = int.Parse(dataGridView9.Rows[j].Cells[0].Value?.ToString());

                    combStorage.Text = dataGridView9.Rows[j].Cells[1].Value?.ToString();
                    combCategorys.Text = dataGridView9.Rows[j].Cells[2].Value?.ToString();
                    textQuntity.Text = dataGridView9.Rows[j].Cells[3].Value?.ToString();
                    ComTypeCategorey.Text = dataGridView9.Rows[j].Cells[4].Value?.ToString();
                    String Price1 = dataGridView9.Rows[j].Cells[5].Value?.ToString();
                    String DiscCategorey1 = dataGridView9.Rows[j].Cells[6].Value?.ToString();


                    if (radioButOld.Checked == true)
                    {
                        textPrice.Text = Price1;
                        textDiscCategorey1.Text = DiscCategorey1;
                    }
                    else if (radioButNew.Checked == true)
                    {

                    }



                    butAddCategorey.PerformClick();

                    num++;




                }


            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBillingDataNumBill.Text == "")
            {
                panel17.Visible = true;
            }
            else
            {
                MessageBox.Show("  يوجد فاتورة مفتوحة يرجى غلق الشاشة وفتحها مرة اخرى   ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            // ComTypeCategorey.Text = FactionCatogrey;
        }

        private void radBtPriceGomlaAlgomla_CheckedChanged(object sender, EventArgs e)
        {
            //string PriceGomla = "";
            //string PriceMostahlek = "";
            //string FactionCatogrey = "";
            PriceGomla = "0";
            PriceGomlaAlgomla = "0";
            PriceNesfGomla = "0";
            PriceMostahlek = "0";
            textPriceKtBea.Text = "0";
            //--------------------------------
            try
            {
                sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage ='" + Storage + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    PriceGomla = reed["PriceGomla"].ToString();
                    PriceGomlaAlgomla = reed["PriceGomlaAlgomla"].ToString();
                    PriceNesfGomla = reed["PriceNesfAlgomla"].ToString();
                    PriceMostahlek = reed["PriceMostahlek"].ToString();
                    FactionCatogrey = reed["Faction"].ToString();

                    textBox4.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
                    textBox5.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();

                    ////------------------------

                    //textPriceGomla.Text = reed["PriceGomla"].ToString();
                    //textPriceMostahlek.Text = reed["PriceMostahlek"].ToString();
                    //textPriceShraa.Text = reed["Price"].ToString();
                    //textFaction.Text = reed["Faction"].ToString();


                }
                reed.Close();





                textPriceKtBea.Text = PriceGomlaAlgomla;

                if (ComTypeCategorey.Text == "كرتونه")
                {

                    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPrice.Text = rcsr.ToString();

                    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();


                }
                else
                {

                    textPrice.Text = Math.Round(double.Parse(textPriceKtBea.Text), 2).ToString();

                }




            }
            catch
            {

            }

            try
            {
                if (ComTypeCategorey.Text == "كرتونه")
                {


                    double ncsn = Convert.ToDouble(textPriceShraa.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPriceSH.Text = rcsr.ToString();

                    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();



                }
                else
                {

                    textPriceSH.Text = textPriceShraa.Text;

                }
            }
            catch
            { }


        }

        private void radBtPriceNesfGomla_CheckedChanged(object sender, EventArgs e)
        {
            //string PriceGomla = "";
            //string PriceMostahlek = "";
            //string FactionCatogrey = "";
            PriceGomla = "0";
            PriceGomlaAlgomla = "0";
            PriceNesfGomla = "0";
            PriceMostahlek = "0";
            textPriceKtBea.Text = "0";
            //--------------------------------
            try
            {
                sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage ='" + Storage + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    PriceGomla = reed["PriceGomla"].ToString();
                    PriceGomlaAlgomla = reed["PriceGomlaAlgomla"].ToString();
                    PriceNesfGomla = reed["PriceNesfAlgomla"].ToString();
                    PriceMostahlek = reed["PriceMostahlek"].ToString();
                    FactionCatogrey = reed["Faction"].ToString();

                    textBox4.Text = Math.Round(double.Parse(PriceGomla), 2).ToString();
                    textBox5.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();

                    ////------------------------

                    //textPriceGomla.Text = reed["PriceGomla"].ToString();
                    //textPriceMostahlek.Text = reed["PriceMostahlek"].ToString();
                    //textPriceShraa.Text = reed["Price"].ToString();
                    //textFaction.Text = reed["Faction"].ToString();


                }
                reed.Close();





                textPriceKtBea.Text = PriceNesfGomla;

                if (ComTypeCategorey.Text == "كرتونه")
                {

                    double ncsn = Convert.ToDouble(textPriceKtBea.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPrice.Text = rcsr.ToString();

                    textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();


                }
                else
                {

                    textPrice.Text = Math.Round(double.Parse(textPriceKtBea.Text), 2).ToString();

                }




            }
            catch
            {

            }

            try
            {
                if (ComTypeCategorey.Text == "كرتونه")
                {


                    double ncsn = Convert.ToDouble(textPriceShraa.Text);
                    double dcsd = Convert.ToDouble(textUnityCategrey.Text);
                    double rcsr = ncsn * dcsd;
                    textPriceSH.Text = rcsr.ToString();

                    textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();



                }
                else
                {

                    textPriceSH.Text = textPriceShraa.Text;

                }
            }
            catch
            { }


        }

        private void butSearchBill_Click(object sender, EventArgs e)
        {

            if (textBillingDataNumBill.Text == "")
            {
                MessageBox.Show("  يوجد فاتورة مفتوحة يرجى غلق الشاشة وفتحها مرة اخرى   ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                dt6.Clear();
                SqlDataAdapter da6 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "' ", cn);
                da6.Fill(dt6);
                this.dataGridView9.DataSource = dt6;




                txtTotalBill.Text = "0";
                TxtNumCategorey.Text = "0";
                txtRemaningOld.Text = "0";
                TotalAndRemaninRasedClient = "0";
                txtDic.Text = "0";
                txtAdd.Text = "0";
                // textBox27.Text = "0";
                txtMosadad.Text = "0";
                // txtMosadad2.Text = "0";
                txtRemainingNow.Text = "0";
                //  textBox28.Text = "";
                textClintID.Text = "";


                //-----------

                comClient.Text = "";
                txtClintName.Text = "";





                sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    comClient.Text = read["Name"].ToString();
                    txtClintName.Text = read["Name"].ToString();

                    textBillingDataNumBill.Text = read["NumBill"].ToString();
                    // txtTotalBill.Text = read["TotalBill"].ToString();
                    textClintID.Text = read["ClientID"].ToString();
                    textClientGroup.Text = read["Type"].ToString();
                    textUser.Text = read["NamePrint"].ToString();
                    textBox57.Text = read["NameMandop"].ToString();
                    comTypeBill.Text = read["TypeBill"].ToString();

                    TxtNumCategorey.Text = read["NumberCategory"].ToString();
                    txtRemaningOld.Text = read["PreviousBalance"].ToString();
                    TotalAndRemaninRasedClient = read["Total"].ToString();
                    txtDic.Text = read["Discount"].ToString();
                    textBox12.Text = read["ReasonDiscount"].ToString();
                    //  textBox27.Text = read["Creditor"].ToString();
                    txtAdd.Text = read["Adding"].ToString();
                    textBox14.Text = read["ReasonAdd"].ToString();
                    txtMosadad.Text = read["Paid"].ToString();
                    // txtMosadad2.Text = read["Paid"].ToString();
                    txtRemainingNow.Text = read["Remaining"].ToString();
                    //  textBox30.Text = read["State"].ToString();
                    dateTimePicker1.Text = read["Date"].ToString();
                    textNoteBill.Text = read["State"].ToString();

                }
                read.Close();


                sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
                read = sqlCommand1.ExecuteReader();
                while (read.Read())
                {
                    MoveBoxID = read["ID"].ToString();



                }
                read.Close();
                //}
                //catch
                //{

                //}

                // ايجاد الاصناف فى الفاتورة

                //------------------------------------
                dt2.Clear();
                SqlDataAdapter da18 = new SqlDataAdapter("select Num,Storage,Category,Quantity,Type,Price,Discount,Total from Billing where NumBill = '" + textBillingDataNumBill.Text + "'  ", cn);
                da18.Fill(dt2);
                this.dataGridView2.DataSource = dt2;
                //------------------------------------

                if (comClient.Enabled == true)
                {
                    comClient.Enabled = false;
                    // dateTimePicker1.Enabled = false;
                    textBillingDataNumBill.Enabled = false;
                }
                else { }
            }



        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        // -----   دالة اضافة المسدد الى الرصيد فى الصندوق
        private void AddOrUpdateBoxMove()
        {

            sqlCommand1.CommandText = "SELECT COUNT(*) FROM BoxMove WHERE ID = @ID"; // ايجاد رقم الصندوق للتحقق من وجوده

            sqlCommand1.Parameters.Clear();
            sqlCommand1.Parameters.AddWithValue("@ID", MoveBoxID);

            int exists = (int)sqlCommand1.ExecuteScalar();

            if (exists > 0)  // لو رقم الصندوق موجود من قبل نحدث البيانات
            {
                // UPDATE

                sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
                sqlCommand1.ExecuteNonQuery();

            }
            else  // لو رقم الصندوق مش موجود نضيف البيانات
            {
                // INSERT
                sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();

            }


            // تحديث الرصيد فورًا
            decimal boxBalance = CashBoxHelper.GetCurrentBoxBalance();
            txtBoxRemining.Text = boxBalance.ToString("N2");


            //try
            //{
            //    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtClintName.Text + "','" + textBillingDataNumBill.Text + "','" + RasedBox + "','" + 0 + "','" + txtMosadad.Text + "','" + 0 + "','" + 0 + "')";
            //    sqlCommand1.ExecuteNonQuery();
            //}
            //catch
            //{
            //    sqlCommand1.CommandText = "update BoxMove set Remaining = '" + RasedBox + "', Wared = '" + txtMosadad.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Move = '" + FormName + "'";
            //    sqlCommand1.ExecuteNonQuery();
            //}

            //// ===== استعلام موحد للإضافة أو التحديث =====
            //string query = @"
            //                    IF EXISTS (SELECT 1 FROM BoxMove WHERE ID = @MoveBoxID)
            //                    BEGIN
            //                        -- تحديث السجل إذا موجود
            //                        UPDATE BoxMove
            //                        SET Date = @Date,
            //                            Move = @Move,
            //                            Name = @Name,
            //                            NumBill = @NumBill,
            //                            Remaining = @Remaining,
            //                            Sader = @Sader,
            //                            Wared = @Wared,
            //                            Total = @Total,
            //                            Note = @Note
            //                        WHERE ID = @MoveBoxID
            //                    END
            //                    ELSE
            //                    BEGIN
            //                        -- إدخال سجل جديد إذا غير موجود
            //                        INSERT INTO BoxMove (ID, Date, Move, Name, NumBill, Remaining, Sader, Wared, Total, Note)
            //                        VALUES (@MoveBoxID, @Date, @Move, @Name, @NumBill, @Remaining, @Sader, @Wared, @Total, @Note)
            //                    END
            //                    ";

            //// ===== إعداد الباراميترات =====
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //        new SqlParameter("@MoveBoxID", System.Data.SqlDbType.Int) { Value = MoveBoxID },
            //        new SqlParameter("@Date", System.Data.SqlDbType.DateTime) { Value = dateTimePicker1.Value.ToString("dd-mm-yyyy") },
            //        new SqlParameter("@Move", System.Data.SqlDbType.NVarChar, 150) { Value = FormName },
            //        new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 150) { Value = txtClintName.Text.Trim() },
            //        new SqlParameter("@NumBill", System.Data.SqlDbType.BigInt) { Value = textBillingDataNumBill.Text },
            //        new SqlParameter("@Remaining", System.Data.SqlDbType.Float) { Value = 0 },
            //        new SqlParameter("@Sader", System.Data.SqlDbType.Float) { Value = 0.0 },
            //        new SqlParameter("@Wared", System.Data.SqlDbType.Float) { Value = txtMosadad.Text },
            //        new SqlParameter("@Total", System.Data.SqlDbType.Float) { Value = 0.0 },
            //        new SqlParameter("@Note", System.Data.SqlDbType.Text) { Value = 0 }
            //};

            //// ===== تنفيذ الاستعلام =====
            //try
            //{
            //    SqlHelperAll.ExecuteNonQuery(query, parameters);

            //    // تحديث الرصيد فورًا
            //    decimal boxBalance = CashBoxHelper.GetCurrentBoxBalance();
            //    txtBoxRemining.Text = boxBalance.ToString("N2");

            //  //  MessageBox.Show("تمت إضافة/تحديث الحركة بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        private void button19_Click(object sender, EventArgs e)
        {

            // -----   جلب دالة اضافة المسدد الى الرصيد فى الصندوق

            AddOrUpdateBoxMove();



        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }


        //private string GetDeviceInfo(string size)
        //{
        //    switch (size)
        //    {
        //        case "Cashier 6":
        //            return @"
        //                    <DeviceInfo>
        //                      <OutputFormat>EMF</OutputFormat>
        //                      <PageWidth>2.36in</PageWidth>
        //                      <PageHeight>11in</PageHeight>
        //                      <MarginTop>0in</MarginTop>
        //                      <MarginLeft>0in</MarginLeft>
        //                      <MarginRight>0in</MarginRight>
        //                      <MarginBottom>0in</MarginBottom>
        //                    </DeviceInfo>";

        //                                    case "Cashier 8":
        //                                    case "Cashier 8 NoDisc":
        //                                        return @"
        //                    <DeviceInfo>
        //                      <OutputFormat>EMF</OutputFormat>
        //                      <PageWidth>3.15in</PageWidth>
        //                      <PageHeight>11in</PageHeight>
        //                      <MarginTop>0in</MarginTop>
        //                      <MarginLeft>0in</MarginLeft>
        //                      <MarginRight>0in</MarginRight>
        //                      <MarginBottom>0in</MarginBottom>
        //                    </DeviceInfo>";

        //                                    case "A5":
        //                                        return @"
        //                    <DeviceInfo>
        //                      <OutputFormat>EMF</OutputFormat>
        //                      <PageWidth>5.83in</PageWidth>
        //                      <PageHeight>8.27in</PageHeight>
        //                      <MarginTop>0.25in</MarginTop>
        //                      <MarginLeft>0.25in</MarginLeft>
        //                      <MarginRight>0.25in</MarginRight>
        //                      <MarginBottom>0.25in</MarginBottom>
        //                    </DeviceInfo>";

        //                                    default: // A4
        //                                        return @"
        //                    <DeviceInfo>
        //                      <OutputFormat>EMF</OutputFormat>
        //                      <PageWidth>8.27in</PageWidth>
        //                      <PageHeight>11.69in</PageHeight>
        //                      <MarginTop>0.25in</MarginTop>
        //                      <MarginLeft>0.25in</MarginLeft>
        //                      <MarginRight>0.25in</MarginRight>
        //                      <MarginBottom>0.25in</MarginBottom>
        //                    </DeviceInfo>";
        //    }
        //}


        //============ بداية اكواد الطباعه المباشرة

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

        //void SetParameters(LocalReport report)
        //{

        //    ReportParameter[] param =
        //    {

        //        new ReportParameter(
        //        "Parm_Company_Name",
        //        CompanyName ?? ""),

        //        new ReportParameter(
        //        "Name",
        //        txtClintName.Text ?? ""),

        //        new ReportParameter(
        //        "Date",
        //        dateTimePicker1.Value.ToString("yyyy/MM/dd")),

        //        new ReportParameter(
        //        "Total",
        //        txtTotalBill.Text ?? "0"),

        //        new ReportParameter(
        //        "Sabek",
        //        txtRemaningOld.Text ?? "0"),

        //        new ReportParameter(
        //        "Sabek1",
        //        txtRemaningOld.Text ?? "0"),

        //        new ReportParameter(
        //        "Mosadad",
        //        txtMosadad.Text ?? "0"),

        //        new ReportParameter(
        //        "Remaning",
        //        txtRemainingNow.Text ?? "0"),

        //        new ReportParameter(
        //        "Discount",
        //        txtDic.Text ?? "0"),

        //        new ReportParameter(
        //        "State",
        //        textNoteBill.Text ?? ""),

        //        new ReportParameter(
        //        "NumBill",
        //        textBillingDataNumBill.Text ?? ""),

        //        new ReportParameter(
        //        "Print",
        //        textUser.Text ?? ""),

        //        new ReportParameter(
        //        "TypeBill",
        //        comTypeBill.Text ?? ""),

        //        new ReportParameter(
        //        "Parm_MoveBill",
        //        textMoveBill.Text ?? ""),

        //        new ReportParameter(
        //        "Parm_NoteToBill",
        //        textNoteBill.Text ?? ""),

        //        new ReportParameter(
        //        "Parm_Company_Description",
        //        CompanyDescription ?? ""),

        //        new ReportParameter(
        //        "Parm_Company_Address",
        //        CompanyAddress ?? ""),

        //        new ReportParameter(
        //        "Parm_Company_Phone",
        //        CompanyPhone ?? ""),

        //        new ReportParameter(
        //        "parmImageUrl",
        //        imageLogoUrl ?? ""),

        //        new ReportParameter(
        //        "Mosadad_Actual",
        //        textMosadadActual.Text ?? "0"),

        //        new ReportParameter(
        //        "Return",
        //        textReturn.Text ?? "0"),

        //        new ReportParameter(
        //        "Demo",
        //        SystemPro ?? ""),

        //        new ReportParameter(
        //        "Note",
        //        textNoteBill.Text ?? "")

        //        };

        //                    report.EnableExternalImages = true;

        //                    report.SetParameters(param);

        //}

        void SetParameters(LocalReport report)
        {

            try
            {

                Dictionary<string, string> allParams =
                new Dictionary<string, string>()
                {

        {"Parm_Company_Name",CompanyName ?? ""},

        {"Name",txtClintName.Text ?? ""},

        {"Date",
        dateTimePicker1.Value.ToString("yyyy/MM/dd")},

        {"Total",txtTotalBill.Text ?? "0"},

        {"Sabek",txtRemaningOld.Text ?? "0"},

        {"Sabek1",txtRemaningOld.Text ?? "0"},

        {"Mosadad",txtMosadad.Text ?? "0"},

        {"Remaning",txtRemainingNow.Text ?? "0"},

        {"Discount",txtDic.Text ?? "0"},

        {"State",textNoteBill.Text ?? ""},

        {"NumBill",
        textBillingDataNumBill.Text ?? ""},

        {"Print",textUser.Text ?? ""},

        {"TypeBill",comTypeBill.Text ?? ""},

        {"Parm_MoveBill",
        textMoveBill.Text ?? ""},

        {"Parm_NoteToBill",
        NoteToBill ?? ""},

        {"Parm_Company_Description",
        CompanyDescription ?? ""},

        {"Parm_Company_Address",
        CompanyAddress ?? ""},

        {"Parm_Company_Phone",
        CompanyPhone ?? ""},

        //{"parmImageUrl",
        //imageLogoUrl ?? ""},

        {"parmImageUrl",
        File.Exists(imageLogoUrl) ?
        new Uri(imageLogoUrl).AbsoluteUri :
        ""},

        {"Mosadad_Actual",
        textMosadadActual.Text ?? "0"},

        {"Return",
        textReturn.Text ?? "0"},

        {"Demo",
        Demo ?? ""},
       
        {"Note",
        textNoteBill.Text ?? ""}

                };

                List<ReportParameter> reportParams =
                new List<ReportParameter>();

                foreach (var rp in report.GetParameters())
                {

                    if (allParams.ContainsKey(rp.Name))
                    {

                        reportParams.Add(
                        new ReportParameter(
                        rp.Name,
                        allParams[rp.Name]));

                    }

                }

                report.EnableExternalImages = true;

                report.SetParameters(reportParams);

            }
            catch (Exception ex)
            {

                MessageBox.Show(
                "Parameter Error : " +
                ex.Message);

            }

        }

        LocalReport PrepareReport()
        {
            try
            {

                LocalReport report =
                new LocalReport();



                if (!ReportEngine.Reports.ContainsKey(combPaperSize.Text))
                {
                    MessageBox.Show("لم يتم تعريف التقرير");
                    return null;
                }


                // string reportFile =Reports[combPaperSize.Text];


                string reportFile = ReportEngine.GetReportFile(PaperSizePrint);

                string reportPath = Path.Combine(Application.StartupPath,"Reports",reportFile);

                // التأكد أن التقرير موجود
                if (!File.Exists(reportPath))
                {

                    MessageBox.Show(
                    "Report Not Found : " +
                    reportPath);

                    return null;

                }

                report.ReportPath =
                reportPath;

                report.DataSources.Clear();

                report.DataSources.Add(
                PrepareItems());

                report.EnableExternalImages = true;
                //   SetParameters(report);

                var invoiceData =CollectInvoiceData();

                ReportParameterBuilder.SetParameters(report,invoiceData);

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
        

        //Dictionary<string, string> Reports = new Dictionary<string, string>()
        //    {

        //            {"A4 فاتورة","ReportBillingA4.rdlc"},

        //            {"A5 فاتورة","ReportBillingA5.rdlc"},

        //            {"B5 فاتورة","ReportBillingB5.rdlc"},

        //            {"كاشير 6 سم",
        //            "ReportBillingCasher_6cm_Dis.rdlc"},

        //            {"كاشير 8 سم",
        //            "ReportBillingCasher_8cm.rdlc"},

        //            {"كاشير 8 سم بدون خصم",
        //            "ReportBillingCasher_8cm_NoDis.rdlc"}

        //    };

        private void butPrintOnLine_Click(object sender, EventArgs e)
        {
            
        }

        private void butUpdateSeting_Click(object sender, EventArgs e)
        {
            PaperSizePrint = combPaperSize.Text;

            PrinterBill = combPrinters.Text;


        }

        private void combPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void combPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void combPrinters_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //PrinterBill = combPrinters.Text;
            //AppSetting.PrinterBill = PrinterBill;
        }

        private void combPaperSize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //PaperSizePrint = combPaperSize.Text;
            //AppSetting.SizePaperBill = PaperSizePrint;
        }

        //void DirectPrint()
        //{

        //    if (dataGridView1.Rows.Count == 0)
        //        return;

        //    LocalReport report =
        //    PrepareReport();

        //    if (report == null)
        //        return;

        //    ReportPrinter.Print( report,PrinterBill,PaperSizePrint);



        // //   MessageBox.Show(" PaperSizePrint =   " + PaperSizePrint + " -------  PrinterBill =   " + PrinterBill, "ملحوظة ");


        //}

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

            ReportPrinter.Print(

            report,

            PrinterBill,

            PaperSizePrint

            );

            System.Media.SystemSounds.Asterisk.Play();

        }

        //protected override bool ProcessCmdKey(ref Message msg,Keys keyData)
        //{

        //    if (keyData == Keys.F9)
        //    {

        //        DirectPrint();

        //        MessageBox.Show("F9 works");

        //        return true;

        //    }

        //    return base.ProcessCmdKey(
        //    ref msg,
        //    keyData);

        //}

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.F9)
            {

                DirectPrint();

                return true;

            }

            return base.ProcessDialogKey(keyData);

        }

        private void Sales_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F9)
            //{

            //    DirectPrint();

            //    e.SuppressKeyPress = true;

            //}
        }


        private void CalculateValues()
        {
            if (!decimal.TryParse(textMosadadActual.Text, out decimal mosadadActual))
                return;

            if (!decimal.TryParse(txtMosadad.Text, out decimal mosadad))
                return;

            decimal returnValue = mosadadActual - mosadad;

            textReturn.Text = returnValue.ToString("0.00");

            if (returnValue < 0)
                returnValue = 0;

            //textPaidAmountWords.Text =
            //"تم دفع مبلغ " +
            //ArabicNumberToWords.Convert(mosadadActual) +
            //" ورد مبلغ " +
            //ArabicNumberToWords.Convert(returnValue) +
            //" وهذا للعلم";

            textPaidAmountWords.Text =  "تم دفع مبلغ " +  ArabicNumberToWords.Convert(mosadadActual) + " ورد مبلغ " + ArabicNumberToWords.Convert(returnValue);
        }
        //private void CalculateValues()
        //{
        //    decimal mosadadActual = 0;
        //    decimal mosadad = 0;

        //    decimal.TryParse(textMosadadActual.Text, out mosadadActual);
        //    decimal.TryParse(txtMosadad.Text, out mosadad);

        //    decimal returnValue = mosadadActual - mosadad;

        //    textReturn.Text = returnValue.ToString("0.00");

        //    textarabic.Text =
        //    "تم دفع مبلغ " +
        //    ArabicNumberToWords.Convert(mosadadActual) +
        //    " ورد مبلغ " +
        //    ArabicNumberToWords.Convert(returnValue);
        //}

        private void textMosadadActual_TextChanged(object sender, EventArgs e)
        {
           // CalculateValues();
        }

        private void textReturn_TextChanged(object sender, EventArgs e)
        {

        }

        private void textMosadadActual_Leave(object sender, EventArgs e)
        {
           // CalculateValues();
        }

        private void textMosadadActual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalculateValues();
                txtMosadad.Focus(); // ينقل للمربع التالى
            }
        }
    }
}