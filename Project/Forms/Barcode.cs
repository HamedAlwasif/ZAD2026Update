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
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace ZAD_Sales.Forms
{
    public partial class Barcode : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;

        string TypePrinter = AppSetting.TypePrinter;
        string BarcodeSize = AppSetting.BarcodeSize;
        //---------------------------------
        int i = 0;
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader reed;
        private SqlDataReader reeeed;
        //---------------------------------
        //---------------------------------
        ReportDataSource rs = new ReportDataSource();

        public Barcode()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;


            //============ وصف للزر عند الوقوف عليه
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnMoveRowsSelected, "انقر لنقل الصفوف المحددة");
            toolTip1.SetToolTip(btnMoveRows, "انقر لنقل دفعة كاملة من الصفوف");

            toolTip1.SetToolTip(DeleteRows, "انقر لحذف الصفوف المحددة ");
            toolTip1.SetToolTip(button6, "انقر لتفريغ الجدول");

            toolTip1.SetToolTip(button4, "انقر لطباعة الباركود ");
            toolTip1.SetToolTip(button10, "انقر لطباعة الباركود ");
        }

        public class Class_CategoreysBillSheraa
        {

            public string Num { get; set; }//NumBill
            public string NumBill { get; set; }
            public string Storage { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string Type { get; set; }
            public string Price { get; set; }
            public string Discount { get; set; }
            public string Total { get; set; }


        }
        public class Class_CategoreysPrintBarcode
        {

            public string Num { get; set; }
            public string Category { get; set; }
            public string Barcode { get; set; }
            public string Price { get; set; }
            public string Total { get; set; }


        }

        private void GetDataBarcode_Seting()
        {
            //------------  Barcode_Seting  ------------

            // texBarcodeStart.Text = AppSetting.BarcodeStart;
            combPrinter.Text = AppSetting.BarcodePrinter;
           // textBarcodeSize.Text = AppSetting.BarcodeFontSize;
            textBarcodeSize.Text = AppSetting.BarcodeSize;
            comTypeFont.Text = AppSetting.BarcodeTypeFont;
            texSizeFontBarcode.Text = AppSetting.BarcodeFontSize;

            texSizeFontProduct.Text = AppSetting.ProductSize;

            TextNameX.Text = AppSetting.MarginsCompaneyX;
            TextNameY.Text = AppSetting.MarginsCompaneyY;
            textBarcodeX.Text = AppSetting.MarginsBarcodeX;
            textBarcodeY.Text = AppSetting.MarginsBarcodeY;

            textCategorysX.Text = AppSetting.MarginsCategorysX;
            textCategorysY.Text = AppSetting.MarginsCategorysY;
            textCategoryIDX.Text = AppSetting.MarginsCategoryIDX;
            textCategoryIDY.Text = AppSetting.MarginsCategoryIDY;
            textPriceX.Text = AppSetting.MarginsPriceX;
            textPriceY.Text = AppSetting.MarginsPriceY;

            textBarcodeSeparator.Text = AppSetting.BarcodeSeparator;

        }

        private void Barcode_Load(object sender, EventArgs e)
        {

            GetDataBarcode_Seting();


            TextName.Text = AppSetting.textCompany_Name;
            combPrinter.Text = AppSetting.PrinterBarcode;
            texSizeFontBarcode.Text = AppSetting.FontSizeBarcode;
            comTypeFont.Text = AppSetting.TypeFont;

            if (BarcodeSize == "50-40")
            {
                radbutPrint50_40.Checked = true;
            }
            else if (BarcodeSize == "38-25")
            {
                radbutPrint38_25.Checked = true;
            }
            else if (BarcodeSize == "50-25")
            {
                radbutPrint50_25.Checked = true;
            }
            else if (BarcodeSize == "38-12")
            {
                radbutPrint38_12.Checked = true;
            }


            //----------  معرفة الشاشة مفتوحة من فاتورة المشتريات ام لا  ---
            textBillingData1NumBill.Text = AppSetting.NumBillToBarcodeForm;

            if(textBillingData1NumBill.Text !="")
            {
                butSearchNumBill.PerformClick();
                AppSetting.NumBillToBarcodeForm = "";
            }
            else
            {
                butSearchDate.PerformClick();
                button11.PerformClick();
            }

            //---------------------------------------------
                


            //---------- عرض الطابعات المسطبةعلى الجهاز --------------
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                combPrinter.Items.Add(printerName);
            }
            //-----------------------------------------------------------
            //----------------- ايجاد الاصناف --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Category from Category", cn);
                Da1.Fill(Dt1);
                combCategorys.DataSource = Dt1;
                combCategorys.DisplayMember = "Category";

                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Category from Category", cn);
                Da2.Fill(Dt2);
                comboBox2.DataSource = Dt2;
                comboBox2.DisplayMember = "Category";

                SqlDataAdapter Da3;
                DataTable Dt3 = new DataTable();
                Da3 = new SqlDataAdapter("select Category from Category", cn);
                Da3.Fill(Dt3);
                comboBox1.DataSource = Dt3;
                comboBox1.DisplayMember = "Category";
            }
            catch
            {

            }

            //----------------- ايجاد المخزن --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Storage from Storage", cn);
                Da1.Fill(Dt1);
                combStorage.DataSource = Dt1;
                combStorage.DisplayMember = "Storage";
            }
            catch
            {

            }
            this.reportViewer1.RefreshReport();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            textCount.Text = "1";

            //-----------------------------------
            //textCategoryID.Text = "";
            textCategoryID1.Text = "";
            //textCategoryID2.Text = "";
            textQuntity.Text = "";
            textPriceShera.Text = "";
            textPriceGm.Text = "";
            textPriceKt.Text = "";
            textPrice.Text = "";
            labName.Text = "الصنف";

            textPricePrint.Text = "0";
            //----------------

            try
            {
                sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "'  AND Storage Like'" + combStorage.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    //textCategoryID.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCategoryID2.Text = "*" + reed["Barcode"].ToString() + "*";
                    
                    //textCodePreview2.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview3.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCategoryIDprint.Text = reed["Barcode"].ToString();
                    textQuntity.Text = reed["Total"].ToString();
                    textPriceShera.Text = reed["Price"].ToString();
                    textPriceGm.Text = reed["PriceGomla"].ToString();
                    textPriceKt.Text = reed["PriceMostahlek"].ToString();
                }
                reed.Close();
            }
            catch
            { }

            textCategorys.Text = combCategorys.Text;
          //  textCategoryIDprint.Text = textCategoryID1.Text;

            textPrice.Text = textPriceKt.Text;
          //  textPricePrint.Text = textPriceKt.Text;
            textPricePrint1.Text = textPriceKt.Text;



            // =========== تغير نوع الخط لخط الباركود المختار

            //string fontName = comTypeFont.Text.Trim();
            //// إنشاء خط جديد بنفس الحجم الحالي للتكست بوكس الهدف
            //Font newFont = new Font(fontName, textCodePreview3.Font.Size);

            //// تغيير خط التكست بوكس
            //textCodePreview3.Font = newFont;


            try
            {
                // قراءة اسم الخط من التكست بوكس
                string fontName = comTypeFont.Text.Trim();

                if (!string.IsNullOrEmpty(fontName))
                {
                    // إنشاء خط جديد بنفس الحجم الحالي للتكست بوكس الهدف
                    Font newFont = new Font(fontName, textCodePreview3.Font.Size);

                    // تغيير خط التكست بوكس
                    textCodePreview3.Font = newFont;
                }
                else
                {
                    MessageBox.Show("من فضلك اكتب اسم الخط في التكست بوكس.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("الخط المطلوب غير موجود على جهازك.");
            }
        }

        private void textCategoryID1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    combCategorys.Text = "";

                    sqlCommand1.CommandText = "select * from Category where Barcode ='" + textCategoryID1.Text + "' ";
                    reeeed = sqlCommand1.ExecuteReader();
                    while (reeeed.Read())
                    {

                        combCategorys.Text = reeeed["Category"].ToString();

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
        private void PrintPage50_40(object sender, PrintPageEventArgs ev)
        {
            string FontNameBarcode = comTypeFont.Text;

            int f = int.Parse(texSizeFontBarcode.Text);  // حجم خط الباركود

            int fP = int.Parse(texSizeFontProduct.Text); // حجم خط المنتج


            //--------------- الهوامش ------

            int NameX = int.Parse(TextNameX5040.Text);
            int NameY = int.Parse(TextNameY5040.Text);
            int BarcodeX = int.Parse(textBarcodeX5040.Text);
            int BarcodeY = int.Parse(textBarcodeY5040.Text);
            int CategorysX = int.Parse(textCategorysX5040.Text);
            int CategorysY = int.Parse(textCategorysY5040.Text);
            //int CategoryIDX = int.Parse(textCategoryIDX3825.Text);
            //int CategoryIDY = int.Parse(textCategoryIDY3825.Text); 
            int PriceX = int.Parse(textPriceX5040.Text);
            int PriceY = int.Parse(textPriceY5040.Text);



            ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, NameX, NameY, new StringFormat()); // اسم الشركة

            // ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, 5, 15, new StringFormat()); //الباركود

            ev.Graphics.DrawString(textCodePreview3.Text, new Font(FontNameBarcode, f), Brushes.Black, BarcodeX, BarcodeY, new StringFormat()); //الباركود


            // ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 7), Brushes.Black, 5, 35, new StringFormat()); // كود المنتج

            ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 7), Brushes.Black, PriceX, PriceY, new StringFormat()); // سعر المنتج


            ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, CategorysX, CategorysY, new StringFormat()); // اسم المنتج






            ////////int f = int.Parse(texSizeFontBarcode.Text);

            ////////RectangleF recAtZero = new RectangleF(0, 0, ev.PageBounds.Width, ev.PageBounds.Height);
            //////////------------ اتجاه النص من اليمين للشمال -----------------------------
            ////////StringFormat formatRL = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            //////////----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------
            ////////ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
            ////////                      80, 8, new StringFormat());
            ////////ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Arial", 5), Brushes.Black,
            ////////                     22, 8, new StringFormat());
            //////////ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
            ////////ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f ), Brushes.Black,
            ////////                       22, 17, new StringFormat());
            ////////ev.Graphics.DrawString(textPricePrint1.Text, new Font("Arial", 5), Brushes.Black,
            ////////                       38, 31, new StringFormat());
            //////////ev.Graphics.DrawString(": السعر", new Font("Arial", 8), Brushes.Black,
            //////////                     40, 50, new StringFormat());
            ////////ev.Graphics.DrawString(combCurrency.Text, new Font("Arial", 5), Brushes.Black,
            ////////                   24, 31, new StringFormat());
            ////////ev.Graphics.DrawString(textCategorys.Text, new Font("Arial", 5), Brushes.Black,
            ////////                      60, 31, new StringFormat());

            //------------------------------------------2-----------------------------------------------
        }
        private void PrintPage50_25(object sender, PrintPageEventArgs ev)
        {

            string FontNameBarcode = comTypeFont.Text;

            int f = int.Parse(texSizeFontBarcode.Text);  // حجم خط الباركود

            int fP = int.Parse(texSizeFontProduct.Text); // حجم خط المنتج


            //--------------- الهوامش ------

            int NameX = int.Parse(TextNameX5025.Text);
            int NameY = int.Parse(TextNameY5025.Text);
            int BarcodeX = int.Parse(textBarcodeX5025.Text);
            int BarcodeY = int.Parse(textBarcodeY5025.Text);
            int CategorysX = int.Parse(textCategorysX5025.Text);
            int CategorysY = int.Parse(textCategorysY5025.Text);
            //int CategoryIDX = int.Parse(textCategoryIDX3825.Text);
            //int CategoryIDY = int.Parse(textCategoryIDY3825.Text); 
            int PriceX = int.Parse(textPriceX5025.Text);
            int PriceY = int.Parse(textPriceY5025.Text);



            ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, NameX, NameY, new StringFormat()); // اسم الشركة

            // ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, 5, 15, new StringFormat()); //الباركود

            ev.Graphics.DrawString(textCodePreview3.Text, new Font(FontNameBarcode, f), Brushes.Black, BarcodeX, BarcodeY, new StringFormat()); //الباركود


            // ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 7), Brushes.Black, 5, 35, new StringFormat()); // كود المنتج

            ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 7), Brushes.Black, PriceX, PriceY, new StringFormat()); // سعر المنتج


            ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, CategorysX, CategorysY, new StringFormat()); // اسم المنتج





            //int f = int.Parse(texSizeFontBarcode.Text);

            //RectangleF recAtZero = new RectangleF(0, 0, ev.PageBounds.Width, ev.PageBounds.Height);
            ////------------ اتجاه النص من اليمين للشمال -----------------------------
            //StringFormat formatRL = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            ////----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------
            //ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
            //                       80, 8, new StringFormat());
            //ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Arial", 5), Brushes.Black,
            //                     22, 8, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black,

            //                      22, 17, new StringFormat());
            //ev.Graphics.DrawString(textPricePrint1.Text, new Font("Arial", 5), Brushes.Black,
            //                       38, 31, new StringFormat());
            ////ev.Graphics.DrawString(": السعر", new Font("Arial", 8), Brushes.Black,
            ////                     40, 50, new StringFormat());
            //ev.Graphics.DrawString(combCurrency.Text, new Font("Arial", 5), Brushes.Black,
            //                   24, 31, new StringFormat());
            //ev.Graphics.DrawString(textCategorys.Text, new Font("Arial", 5), Brushes.Black,
            //                      60, 31, new StringFormat());

            //------------------------------------------2-----------------------------------------------
        }
        private void PrintPage38_25(object sender, PrintPageEventArgs ev)
        {
            if(comTypeFont.Text== "IDAHC39M Code 39 Barcode")
            {
                //----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------

                string FontNameBarcode = comTypeFont.Text;

                int f = int.Parse(texSizeFontBarcode.Text);  // حجم خط الباركود

                int fP = int.Parse(texSizeFontProduct.Text); // حجم خط المنتج


                //--------------- الهوامش ------

                int NameX = int.Parse(TextNameX3825.Text); 
                int NameY = int.Parse(TextNameY3825.Text); 
                int BarcodeX = int.Parse(textBarcodeX3825.Text); 
                int BarcodeY = int.Parse(textBarcodeY3825.Text); 
                int CategorysX = int.Parse(textCategorysX3825.Text); 
                int CategorysY = int.Parse(textCategorysY3825.Text); 
                //int CategoryIDX = int.Parse(textCategoryIDX3825.Text);
                //int CategoryIDY = int.Parse(textCategoryIDY3825.Text); 
                int PriceX = int.Parse(textPriceX3825.Text); 
                int PriceY = int.Parse(textPriceY3825.Text); 



                ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, NameX, NameY, new StringFormat()); // اسم الشركة

               // ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, 5, 15, new StringFormat()); //الباركود

                ev.Graphics.DrawString(textCodePreview3.Text, new Font(FontNameBarcode, f), Brushes.Black, BarcodeX, BarcodeY, new StringFormat()); //الباركود


                // ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 7), Brushes.Black, 5, 35, new StringFormat()); // كود المنتج

               // ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 6), Brushes.Black, PriceX, PriceY + sum, new StringFormat()); // سعر المنتج


                ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 7), Brushes.Black, PriceX, PriceY, new StringFormat()); // سعر المنتج


                ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, CategorysX, CategorysY, new StringFormat()); // اسم المنتج

                

                // ev.Graphics.DrawString(": السعر", new Font("Arial", 5), Brushes.Black, 80, 36, new StringFormat()); // كتابة السعر

                //int f = int.Parse(texSizeFontBarcode.Text);

                //RectangleF recAtZero = new RectangleF(0, 0, ev.PageBounds.Width, ev.PageBounds.Height);
                ////------------ اتجاه النص من اليمين للشمال -----------------------------
                //StringFormat formatRL = new StringFormat(StringFormatFlags.DirectionRightToLeft);

                ////----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------
                //ev.Graphics.DrawString(TextName.Text, new Font("Arial", 8), Brushes.Black,
                //                      3, 8, new StringFormat());
                ////  ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Arial", 6), Brushes.Black,10, 22, new StringFormat());


                //ev.Graphics.DrawString(textCodePreview3.Text, new Font("IDAHC39M Code 39 Barcode", f), Brushes.Black,
                //                       2, 20, new StringFormat());
                //ev.Graphics.DrawString(textCategorys.Text, new Font("Arial", 6), Brushes.Black,
                //                     3, 72, new StringFormat());

                //ev.Graphics.DrawString(textPricePrint1.Text, new Font("Arial", 8), Brushes.Black,
                //                       90, 80, new StringFormat());
                ////ev.Graphics.DrawString(": السعر", new Font("Arial", 8), Brushes.Black,
                ////                     40, 50, new StringFormat());
                //ev.Graphics.DrawString(combCurrency.Text, new Font("Arial", 8), Brushes.Black,
                //                   60, 80, new StringFormat());

                ////MessageBox.Show("    IDAHC39M Code 39 Barcode    ", "الخط غير مدعوم ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (comTypeFont.Text == "3 of 9 Barcode")
            {
                string FontNameBarcode = comTypeFont.Text;

                int f = int.Parse(texSizeFontBarcode.Text);  // حجم خط الباركود

                int fP = int.Parse(texSizeFontProduct.Text); // حجم خط المنتج

                ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, 20, 5, new StringFormat()); // اسم الشركة

              //  ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, 5, 15, new StringFormat()); //الباركود

                ev.Graphics.DrawString(textCodePreview3.Text, new Font( FontNameBarcode, f), Brushes.Black, 5, 15, new StringFormat()); //الباركود


                ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 7), Brushes.Black, 5, 35, new StringFormat()); // كود المنتج

                ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 7), Brushes.Black, 70, 35, new StringFormat()); // سعر المنتج


                ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, 5, 45, new StringFormat()); // اسم المنتج


                //int f = int.Parse(texSizeFontBarcode.Text);

                //RectangleF recAtZero = new RectangleF(0, 0, ev.PageBounds.Width, ev.PageBounds.Height);
                ////------------ اتجاه النص من اليمين للشمال -----------------------------
                //StringFormat formatRL = new StringFormat(StringFormatFlags.DirectionRightToLeft);

                ////----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------
                //ev.Graphics.DrawString(TextName.Text, new Font("Arial", 8), Brushes.Black,
                //                      3, 8, new StringFormat());
                //ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Arial", 6), Brushes.Black,
                //                     10, 22, new StringFormat());
                //ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                //                       3, 40, new StringFormat());
                //ev.Graphics.DrawString(textCategorys.Text, new Font("Arial", 8), Brushes.Black,
                //                     3, 63, new StringFormat());

                //ev.Graphics.DrawString(textPricePrint1.Text, new Font("Arial", 8), Brushes.Black,
                //                       40, 75, new StringFormat());
                ////ev.Graphics.DrawString(": السعر", new Font("Arial", 8), Brushes.Black,
                ////                     40, 50, new StringFormat());
                //ev.Graphics.DrawString(combCurrency.Text, new Font("Arial", 8), Brushes.Black,
                //                   5, 75, new StringFormat());


                //MessageBox.Show("    3 of 9 Barcode    ", "الخط غير مدعوم ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("    نوع الخط غير مدعوم فى البرنامج    ", "الخط غير مدعوم ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





            //------------------------------------------2-----------------------------------------------
        }

        //============ دالتين بسيطتين في المشروع عشان تقدر تشتغل بالملي مباشرة بدل ما تحسب كل مرة:

        // التحويل من وحدة الطباعة (1/100 إنش) إلى ملم
        private float ToMM(float units)
        {
            return units * 0.254f;
        }

        // التحويل من ملم إلى وحدة الطباعة (1/100 إنش)
        private float FromMM(float mm)
        {
            return mm / 0.254f;
        }


        private void PrintPage38_12(object sender, PrintPageEventArgs ev)
        {
            int f = int.Parse(texSizeFontBarcode.Text);  // حجم خط الباركود

            int fP = int.Parse(texSizeFontProduct.Text); // حجم خط المنتج

            //--------------- الهوامش ------

            int NameX = int.Parse(TextNameX.Text); // حجم خط المنتج
            int NameY = int.Parse(TextNameY.Text); // حجم خط المنتج
            int BarcodeX = int.Parse(textBarcodeX.Text); // حجم خط المنتج
            int BarcodeY = int.Parse(textBarcodeY.Text); // حجم خط المنتج
            int CategorysX = int.Parse(textCategorysX.Text); // حجم خط المنتج
            int CategorysY = int.Parse(textCategorysY.Text); // حجم خط المنتج
            int CategoryIDX = int.Parse(textCategoryIDX.Text); // حجم خط المنتج
            int CategoryIDY = int.Parse(textCategoryIDY.Text); // حجم خط المنتج
            int PriceX = int.Parse(textPriceX.Text); // حجم خط المنتج
            int PriceY = int.Parse(textPriceY.Text); // حجم خط المنتج
            //-------------

            RectangleF recAtZero = new RectangleF(0, 0, ev.PageBounds.Width, ev.PageBounds.Height);
            //------------ اتجاه النص من اليمين للشمال -----------------------------
            StringFormat formatRL = new StringFormat(StringFormatFlags.DirectionRightToLeft);

           
            //----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------


            ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, NameX, NameY, new StringFormat()); // اسم الشركة

            ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, BarcodeX, BarcodeY, new StringFormat()); //الباركود

            ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, CategorysX, CategorysY, new StringFormat()) ; // اسم المنتج

            ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 6), Brushes.Black, CategoryIDX, CategoryIDY, new StringFormat()); // كود المنتج


            ev.Graphics.DrawString(textPricePrint1.Text, new Font("Tahoma", 6), Brushes.Black, PriceX, PriceY, new StringFormat()); // سعر المنتج

            // ev.Graphics.DrawString(": السعر", new Font("Arial", 5), Brushes.Black, 80, 36, new StringFormat()); // كتابة السعر


            // الاصل

            //ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, 40, 5, new StringFormat()); // اسم الشركة

            //ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 6), Brushes.Black, 5, 5, new StringFormat()); // كود المنتج

            //ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, 5, 15, new StringFormat()); //الباركود

            //ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, 5, 30, new StringFormat()); // اسم المنتج

            //ev.Graphics.DrawString(textPricePrint1.Text, new Font("Tahoma", 8), Brushes.Black, 70, 36, new StringFormat()); // سعر المنتج

           



        }


        private void PrintPage38_12_2(object sender, PrintPageEventArgs ev)
        {
            int f = int.Parse(texSizeFontBarcode.Text);  // حجم خط الباركود

            int fP = int.Parse(texSizeFontProduct.Text); // حجم خط المنتج

            //--------------- الهوامش ------

            int NameX = int.Parse(TextNameX.Text); // حجم خط المنتج
            int NameY = int.Parse(TextNameY.Text); // حجم خط المنتج
            int BarcodeX = int.Parse(textBarcodeX.Text); // حجم خط المنتج
            int BarcodeY = int.Parse(textBarcodeY.Text); // حجم خط المنتج
            int CategorysX = int.Parse(textCategorysX.Text); // حجم خط المنتج
            int CategorysY = int.Parse(textCategorysY.Text); // حجم خط المنتج
            int CategoryIDX = int.Parse(textCategoryIDX.Text); // حجم خط المنتج
            int CategoryIDY = int.Parse(textCategoryIDY.Text); // حجم خط المنتج
            int PriceX = int.Parse(textPriceX.Text); // حجم خط المنتج
            int PriceY = int.Parse(textPriceY.Text); // حجم خط المنتج
            //-------------

            RectangleF recAtZero = new RectangleF(0, 0, ev.PageBounds.Width, ev.PageBounds.Height);
            //------------ اتجاه النص من اليمين للشمال -----------------------------
            StringFormat formatRL = new StringFormat(StringFormatFlags.DirectionRightToLeft);


            //----------------------------------------1-----------------------Tahoma; 8.25pt; style=Bold--------------------------


            ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, NameX, NameY, new StringFormat()); // اسم الشركة

            ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, BarcodeX, BarcodeY, new StringFormat()); //الباركود

            ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, CategorysX, CategorysY, new StringFormat()); // اسم المنتج

            ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 6), Brushes.Black, CategoryIDX, CategoryIDY, new StringFormat()); // كود المنتج


            ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 6), Brushes.Black, PriceX, PriceY, new StringFormat()); // سعر المنتج


            //---------------------------------------------------------------

            int sum = int.Parse(textBarcodeSeparator.Text); // ------ اضافة نسبة الارتفاع للنسخة الثانية

            ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, NameX, NameY + sum, new StringFormat()); // اسم الشركة

            ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, BarcodeX, BarcodeY + sum, new StringFormat()); //الباركود

            ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, CategorysX, CategorysY + sum, new StringFormat()); // اسم المنتج

            ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 6), Brushes.Black, CategoryIDX, CategoryIDY + sum, new StringFormat()); // كود المنتج


            ev.Graphics.DrawString(textFristPriceCode.Text + textPricePrint1.Text, new Font("Tahoma", 6), Brushes.Black, PriceX, PriceY + sum, new StringFormat()); // سعر المنتج




            // ev.Graphics.DrawString(": السعر", new Font("Arial", 5), Brushes.Black, 80, 36, new StringFormat()); // كتابة السعر


            // الاصل

            //ev.Graphics.DrawString(TextName.Text, new Font("Tahoma", 6), Brushes.Black, 40, 5, new StringFormat()); // اسم الشركة

            //ev.Graphics.DrawString(textCategoryIDprint.Text, new Font("Tahoma", 6), Brushes.Black, 5, 5, new StringFormat()); // كود المنتج

            //ev.Graphics.DrawString(textCodePreview3.Text, new Font("3 of 9 Barcode", f), Brushes.Black, 5, 15, new StringFormat()); //الباركود

            //ev.Graphics.DrawString(textCategorys.Text, new Font("Tahoma", fP), Brushes.Black, 5, 30, new StringFormat()); // اسم المنتج

            //ev.Graphics.DrawString(textPricePrint1.Text, new Font("Tahoma", 8), Brushes.Black, 70, 36, new StringFormat()); // سعر المنتج





        }


        private void butPrintBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();

                //pd.PrintPage += new PrintPageEventHandler(PrintPage);
                if (radbutPrint50_40.Checked == true)
                {
                pd.PrintPage += new PrintPageEventHandler(PrintPage50_40);
                PaperSize ps = new PaperSize("50 x 40 mm", 196, 157);
                    pd.DefaultPageSettings.PaperSize = ps;

                }
                else if (radbutPrint50_25.Checked == true)
                {
                pd.PrintPage += new PrintPageEventHandler(PrintPage50_25);
                PaperSize ps = new PaperSize("50 x 25 mm", 196, 98);
                    pd.DefaultPageSettings.PaperSize = ps;
                }
                else if (radbutPrint38_25.Checked == true)
                {
                pd.PrintPage += new PrintPageEventHandler(PrintPage38_25);
                PaperSize ps = new PaperSize("38 x 25 mm", 149, 98);
                    pd.DefaultPageSettings.PaperSize = ps;
                }
                else if (radbutPrint38_12.Checked == true)
                {
                pd.PrintPage += new PrintPageEventHandler(PrintPage38_12);
                PaperSize ps = new PaperSize("38 x 12.5 mm", 149, 47);
                    pd.DefaultPageSettings.PaperSize = ps;

                }
                //PageSettings pa = new PageSettings();
                //pa.Margins = new Margins(5, 5, 5, 5);

                //pa.PrinterSettings.PrinterName = combPrinter.Text;
                //PrintDialog PrintDialog1 = new PrintDialog();
                Int16 n = Convert.ToInt16(textCount.Text);
                pd.PrinterSettings.Copies = n;
                pd.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
                pd.PrinterSettings.PrinterName = combPrinter.Text;

                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                // Response.Write("Error: " + ex.ToString());
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }
       
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {
            int f = int.Parse(texSizeFontBarcode.Text);

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                2, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                  12, i + 15, new StringFormat());

            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                220, i, new StringFormat());

                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                              230, i + 15, new StringFormat());

                //for (int j = 28; j < 1110; j = j + 50)
                //{
                //    ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                //                  230, j, new StringFormat());

                //}
            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                420, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                             430, i + 15, new StringFormat());

            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                620, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                             630, i + 15, new StringFormat());

            }

            ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 10), Brushes.Black,
                    2, 1110, new StringFormat());
            ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                10, 1128, new StringFormat());

            ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 10), Brushes.Black,
                                220, 1110, new StringFormat());
            ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                230, 1128, new StringFormat());

            ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 10), Brushes.Black,
                    420, 1110, new StringFormat());
            ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                430, 1128, new StringFormat());

            ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 10), Brushes.Black,
                    620, 1110, new StringFormat());
            ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                630, 1128, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 10, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 28, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 60, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 78, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 128, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 160, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 178, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 210, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 228, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 260, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 278, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 310, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 328, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 360, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 378, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 410, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 428, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 460, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 478, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 510, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 528, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 560, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 578, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 610, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 628, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 660, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 678, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 710, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 728, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 760, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 778, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 810, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 828, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 860, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 878, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 910, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 928, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 960, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 978, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 1010, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 1028, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    2, 1060, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 1078, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 10), Brushes.Black,
            //                    2, 1110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    12, 1128, new StringFormat());


            ////---------------------------------------------------------------------------------------------

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 10, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 28, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 60, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 78, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 128, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 160, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 178, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 210, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 228, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 260, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 278, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 310, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 328, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 360, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 378, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 410, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 428, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 460, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 478, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 510, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 528, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 560, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 578, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 610, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 628, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 660, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 678, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 710, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 728, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 760, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 778, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 810, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 828, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 860, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 878, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 910, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 928, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 960, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 978, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 1010, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 1028, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    220, 1060, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 1078, new StringFormat());


            //ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 10), Brushes.Black,
            //                    220, 1110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    230, 1128, new StringFormat());

            ////---------------------------------------------------------------------------------------------

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                  420, 10, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 28, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 60, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 78, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 128, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 160, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 178, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 210, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 228, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 260, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 278, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 310, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 328, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 360, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 378, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 410, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 428, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 460, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 478, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 510, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 528, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 560, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 578, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 610, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 628, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 660, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 678, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 710, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 728, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 760, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 778, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 810, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 828, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 860, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 878, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 910, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 928, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 960, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 978, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 1010, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 1028, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    420, 1060, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 1078, new StringFormat());


            //ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 10), Brushes.Black,
            //                    420, 1110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    430, 1128, new StringFormat());

            ////---------------------------------------------------------------------------------------------

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                 620, 10, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 28, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 60, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 78, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 110, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 128, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 160, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 178, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 210, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 228, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 260, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 278, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 310, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 328, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 360, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 378, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 410, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 428, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 460, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 478, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 510, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 528, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 560, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 578, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 610, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 628, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 660, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 678, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 710, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 728, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 760, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 778, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 810, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 828, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 860, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 878, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 910, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 928, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 960, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 978, new StringFormat());

            //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", 16), Brushes.Black,
            //                    620, 1010, new StringFormat());
            //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            //                    630, 1028, new StringFormat());

            //ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 16), Brushes.Black,
            //                    620, 1060, new StringFormat());
            ////ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            ////                    630, 1078, new StringFormat());

            ////ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 14), Brushes.Black,
            ////                    620, 1110, new StringFormat());
            ////ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
            ////                    630, 1128, new StringFormat());
        }

        private void butPrintAll_Click(object sender, EventArgs e)
        {
            if (this.printDialog2.ShowDialog() == DialogResult.OK)
            {
                this.printDocument2.Print();
            }
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs ev)
        {
            int f = int.Parse(texSizeFontBarcode.Text);
          //  string TypeFonts = comTypeFont.Text; //"3 of 9 Barcode"
            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 5), Brushes.Black,
                                     2, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                       2, i + 10, new StringFormat());
                ev.Graphics.DrawString(textPricePrint.Text, new Font("Arial", 6), Brushes.Black,
                                       15, i + 25, new StringFormat());

                ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
                                     5, i + 25, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                 65, i + 25, new StringFormat());
                //-----------------------------------------------------------
                //ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                //                2, i, new StringFormat());
                //ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                //                  12, i + 15, new StringFormat());

            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 5), Brushes.Black,
                                      220, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                       220, i + 10, new StringFormat());
                ev.Graphics.DrawString(textPricePrint.Text, new Font("Arial", 6), Brushes.Black,
                                       233, i + 25, new StringFormat());

                ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
                                     223, i + 25, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                283, i + 25, new StringFormat());
            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 5), Brushes.Black,
                                      420, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                       420, i + 10, new StringFormat());
                ev.Graphics.DrawString(textPricePrint.Text, new Font("Arial", 6), Brushes.Black,
                                       433, i + 25, new StringFormat());

                ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
                                     423, i + 25, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                483, i + 25, new StringFormat());

            }

            for (int i = 10; i < 1110; i = i + 50)
            {

                ev.Graphics.DrawString(combCategorys.Text, new Font("Arial", 5), Brushes.Black,
                                       620, i, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("3 of 9 Barcode", f), Brushes.Black,
                                       620, i + 10, new StringFormat());
                ev.Graphics.DrawString(textPricePrint.Text, new Font("Arial", 6), Brushes.Black,
                                       633, i + 25, new StringFormat());

                ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
                                     623, i + 25, new StringFormat());
                ev.Graphics.DrawString(textCodePreview.Text, new Font("Arial", 5), Brushes.Black,
                                683, i + 25, new StringFormat());

            }

        }

        private void label12_Click(object sender, EventArgs e)
        {
            textCount.Text = textQuntity.Text;
                
        }

        private void radioPrinterNormal_CheckedChanged(object sender, EventArgs e)
        {
            if(radioPrinterNormal.Checked==true)
            {
                panelPrinterNormal.Visible = true;
                panelPrinterBarcode.Visible = false;
            }
            else
            {
                panelPrinterNormal.Visible = false;
                panelPrinterBarcode.Visible = true;
            }
        }

        private void radioPrinterBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPrinterBarcode.Checked == true)
            {
                panelPrinterNormal.Visible = false;
                panelPrinterBarcode.Visible = true;
            }
            else
            {
                panelPrinterNormal.Visible = true;
                panelPrinterBarcode.Visible = false;
            }
        }

        private void butSearchDate_Click(object sender, EventArgs e)
        {
            //------------------ايجاد الاصناف المشتراه اليوم   ------------------
            DataTable dt2 = new DataTable();
            dt2.Clear();
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);

            da11.Fill(dt2);

            this.dataGridViewCategroyBill.DataSource = dt2;

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridViewCategroyBill.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
        }

        private void butSearchNumBill_Click(object sender, EventArgs e)
        {
            //------------------ايجاد الاصناف المشتراه اليوم   ------------------
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);

            da11.Fill(dt2);

            this.dataGridViewCategroyBill.DataSource = dt2;

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridViewCategroyBill.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
        }

        private void dataGridViewCategroyBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridViewCategroyBill.Rows[e.RowIndex].Cells[1].Value.ToString();

            butSearch.PerformClick();


            

            //--------- عدد الطباعه  -----
            if (checkBoxCount.Checked == true)
            {
                textCount.Text = dataGridViewCategroyBill.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            else
            {
                textCount.Text = "1";
            }

            //--------- الطباعه المباشرة  -----
            if (checkBoxPrintOnline.Checked==true)
            {
                butPrintBarcode.PerformClick();
            }


            //------------- اضافة فى جدول الطباعه العادية 
            comboBox2.Text = dataGridViewCategroyBill.Rows[e.RowIndex].Cells[1].Value.ToString();

            button2.PerformClick();

            textNum.Text = dataGridViewCategroyBill.Rows[e.RowIndex].Cells[2].Value.ToString();


            int t = int.Parse(textNumRows.Text);
            int n = int.Parse(textNum.Text);

            for (int i = 1; i <= n; i++)
            {
                if (t < 88)
                {
                    string Category = comboBox2.Text;
                    string Barcode1 = Bar.Text;
                    string Price = textBox1.Text;
                    string Total = textNum.Text;
                    string[] row = { Category, Barcode1, Price, Total };
                    dataGridView1.Rows.Add(row);


                    t = dataGridView1.Rows.Count;

                    textNumRows.Text = t.ToString();

                    label18.Text = (n - i).ToString(); // المتبقى من الصنف الواحد
                }
                else
                {

                    MessageBox.Show(" تم تجاوز العدد المسموح به 88 قطعه", " توقف ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    i = n + 1; // لكى يخرج من ال for

                }
            }
        }

        private void dataGridViewCategroyBill_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void dataGridViewCategroyBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butPrintAllTable_Click(object sender, EventArgs e)
        {

        }

        private void butPrintAllTableBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد طباعة جميع الباركود فى الجدول ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    int NumRows = Convert.ToInt32(dataGridViewCategroyBill.RowCount - 1);

                    for (int j = 0; j < NumRows; j++)
                    {

                        combCategorys.Text = dataGridViewCategroyBill.Rows[j].Cells[1].Value.ToString();


                        butSearch.PerformClick();


                        textCount.Text = dataGridViewCategroyBill.Rows[j].Cells[2].Value.ToString();

                        butPrintBarcode.PerformClick();
                    }
                }
            }
            catch
            {

            }
        }

        private void textCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textCount.Text = "1";

            //-----------------------------------
      
            Bar.Text = "";
            textNum.Text = "";
            textBox1.Text = "";
            labName.Text = "الصنف";

            textPricePrint.Text = "0";
            //----------------

            try
            {
                sqlCommand1.CommandText = "select * from Category where Category Like'" + comboBox2.Text + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textCategoryID1.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCategoryID2.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview2.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCodePreview3.Text = "*" + reed["Barcode"].ToString() + "*";
                    Bar.Text = reed["Barcode"].ToString();
                    textNum.Text = reed["Total"].ToString();
                    textBox1.Text = reed["PriceMostahlek"].ToString();
                    //   textPriceGm.Text = reed["PriceGomla"].ToString();
                    textPricePrint.Text = reed["PriceMostahlek"].ToString();
                }
                reed.Close();
            }
            catch
            { }

            //textCategorys.Text = combCategorys.Text;
            //textCategoryIDprint.Text = textCategoryID1.Text;

            //textPrice.Text = textPriceKt.Text;
            //textPricePrint.Text = textPriceKt.Text;
            //textPricePrint1.Text = textPriceKt.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)  // تصفير السعر
            {
                textBox1.Text = " ";
            }
            else
            { }

            int maxRowsToMove1 = 132;

            if (radioButton4.Checked == true)
            {
                maxRowsToMove1 = 132;
            }
            else if (radioButton3.Checked == true)
            {
                maxRowsToMove1 = 50;
            }

            int t = int.Parse(textNumRows.Text);
            int n = int.Parse(textNum.Text);

            for (int i = 1; i <= n; i++)
            {
                if (t < maxRowsToMove1)
                {
                    string Category = comboBox2.Text;
                    string Barcode1 = Bar.Text;
                    string Price = textBox1.Text;
                    string Total = textNum.Text;
                    string[] row = { Category, Barcode1, Price, Total };
                    dataGridView1.Rows.Add(row);

                  

                    t = dataGridView1.Rows.Count;

                    textNumRows.Text = t.ToString();

                    label18.Text = (n - i).ToString(); // المتبقى من الصنف الواحد
                }
                else
                {

                    MessageBox.Show(" تم تجاوز العدد المسموح به", " توقف ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    i = n + 1; // لكى يخرج من ال for

                }

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
               // int rowNumber1 = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.HeaderCell.Value = "" + rowNumber + "";
                    rowNumber = rowNumber + 1;

                  //  rowNumber1 = rowNumber1 + 1;
                }
                dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


            }




            comboBox2.Focus();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

            textCount.Text = "1";

            //-----------------------------------

            Bar.Text = "";
            textNum.Text = "";
            textBox1.Text = "";
            labName.Text = "الصنف";

            textPricePrint.Text = "0";
            //----------------

            try
            {
                sqlCommand1.CommandText = "select * from Category where Category Like'" + comboBox2.Text + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textCategoryID1.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCategoryID2.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview2.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCodePreview3.Text = "*" + reed["Barcode"].ToString() + "*";
                    Bar.Text = reed["Barcode"].ToString();
                    textNum.Text = reed["Total"].ToString();
                    textBox1.Text = reed["PriceMostahlek"].ToString();
                    //   textPriceGm.Text = reed["PriceGomla"].ToString();
                    textPricePrint.Text = reed["PriceMostahlek"].ToString();
                }
                reed.Close();
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Class_CategoreysPrintBarcode> BM = new List<Class_CategoreysPrintBarcode>();
            BM.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Class_CategoreysPrintBarcode BillDay = new Class_CategoreysPrintBarcode
                {
                   // Num = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Category = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Barcode = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Price = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                  

                };

                BM.Add(BillDay);
            }
            rs.Name = "DataSet1";
            rs.Value = BM;

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int t = int.Parse(textNumRows.Text);
            if (t >= 132)
            {
                if (this.printDialog2.ShowDialog() == DialogResult.OK)
                {
                    this.printDocument3.Print();
                }
            }
            else
            {
                MessageBox.Show("          العدد اقل من 88 صنف - لابد ان لا يقل العدد عند 132 صنف      ", "    توقف    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs ev)
        {

            int f = int.Parse(texSizeFontBarcode.Text);
            //  string TypeFonts = comTypeFont.Text; //"3 of 9 Barcode"
            int j = 0;
            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                     3, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                  3, i+25, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
                                       2, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
                                       3, i + 35, new StringFormat());

              //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 5, i + 25, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                 65, i + 35, new StringFormat());

                j = j + 1;

            }


            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   130, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                      130, i+25, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
                                       130, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
                                       130, i + 35, new StringFormat());

              //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,153, i + 25, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                193, i + 35, new StringFormat());

                j = j + 1;
            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   265, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                      265, i+25, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
                                       265, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
                                       265, i + 35, new StringFormat());

               // ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 343, i + 25, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                328, i + 35, new StringFormat());

                j = j + 1;

            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   405, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                       405, i+25, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
                                       405, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
                                       405, i + 35, new StringFormat());

              //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 543, i + 25, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                468, i + 35, new StringFormat());

                j = j + 1;

            }

            //************************************************

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   545, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                       545, i+25, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
                                       545, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
                                       545, i + 35, new StringFormat());

                //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 543, i + 25, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                608, i + 35, new StringFormat());

                j = j + 1;

            }

            for (int i = 10; i < 1110; i = i + 50)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   680, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                       680, i+25, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
                                       680, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
                                       680, i + 35, new StringFormat());

                //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 543, i + 25, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                743, i + 35, new StringFormat());

                j = j + 1;

            }

            //int f = int.Parse(texSizeFontBarcode.Text);
            ////  string TypeFonts = comTypeFont.Text; //"3 of 9 Barcode"
            //int j = 0;
            //for (int i = 10; i < 1110; i = i + 50)
            //{

            //        ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                          2, i, new StringFormat());
            //        ev.Graphics.DrawString("*"+ dataGridView1.Rows[j].Cells[1].Value.ToString() +"*", new Font("3 of 9 Barcode", f), Brushes.Black,
            //                               2, i + 10, new StringFormat());
            //        ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
            //                               15, i + 25, new StringFormat());

            //        ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
            //                             5, i + 25, new StringFormat());
            //        ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                         65, i + 25, new StringFormat());

            //    j = j + 1;

            //}


            //for (int i = 10; i < 1110; i = i + 50)
            //{
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                          220, i, new StringFormat());
            //    ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
            //                           220, i + 10, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
            //                           233, i + 25, new StringFormat());

            //    ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
            //                         223, i + 25, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                    283, i + 25, new StringFormat());

            //    j = j + 1;
            //}

            //for (int i = 10; i < 1110; i = i + 50)
            //{
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                          420, i, new StringFormat());
            //    ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
            //                           420, i + 10, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
            //                           433, i + 25, new StringFormat());

            //    ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
            //                         423, i + 25, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                    483, i + 25, new StringFormat());

            //    j = j + 1;

            //}

            //for (int i = 10; i < 1110; i = i + 50)
            //{

            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                           620, i, new StringFormat());
            //    ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
            //                           620, i + 10, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
            //                           633, i + 25, new StringFormat());

            //    ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,
            //                         623, i + 25, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                    683, i + 25, new StringFormat());

            //    j = j + 1;

            //}

        }

        private void butBarcodeAdd_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    DialogResult dialogResult = MessageBox.Show(
            //        "\n\nهل تريد جلب الاصناف فى الجدول ؟",
            //        "إستفسار",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question
            //    );

            //    if (dialogResult != DialogResult.Yes)
            //        return;

            //    int maxAllowedItems = 132;
            //    int rowCount = dataGridViewCategroyBill.RowCount - 1;

            //    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            //    {
            //        string categoryName = dataGridViewCategroyBill.Rows[rowIndex].Cells[1].Value?.ToString();
            //        string itemCountStr = dataGridViewCategroyBill.Rows[rowIndex].Cells[2].Value?.ToString();

            //        if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(itemCountStr))
            //            continue;

            //        comboBox2.Text = categoryName;
            //        button2.PerformClick(); // تحميل الباركود حسب الصنف المحدد
            //        textNum.Text = itemCountStr;

            //        if (!int.TryParse(textNum.Text, out int numItemsToAdd) || !int.TryParse(textNumRows.Text, out int currentRows))
            //            continue;

            //        for (int i = 1; i <= numItemsToAdd; i++)
            //        {
            //            if (currentRows >= maxAllowedItems)
            //            {
            //                MessageBox.Show("تم تجاوز العدد المسموح به 132 قطعة", "توقف", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                break;
            //            }

            //            string category = comboBox2.Text;
            //            string barcode = Bar.Text;
            //            string price = checkBox1.Checked ? "" : textBox1.Text;
            //            string total = textNum.Text;

            //            string[] newRow = { category, barcode, price, total };
            //            dataGridView1.Rows.Add(newRow);

            //            currentRows++;
            //            textNumRows.Text = currentRows.ToString();
            //            label18.Text = (numItemsToAdd - i).ToString(); // المتبقي من نفس الصنف
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("حدث خطأ أثناء جلب الأصناف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد جلب الاصناف فى الجدول ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridViewCategroyBill.RowCount - 1);

                for (int j = 0; j < NumRows; j++)
                {

                    comboBox2.Text = dataGridViewCategroyBill.Rows[j].Cells[1].Value.ToString();


                    button2.PerformClick();


                    textNum.Text = dataGridViewCategroyBill.Rows[j].Cells[2].Value.ToString();

                    // button3.PerformClick();
                    int t = int.Parse(textNumRows.Text);
                    int n = int.Parse(textNum.Text);

                    for (int i = 1; i <= n; i++)
                    {
                        if (t < 132)
                        {
                            string Category = comboBox2.Text;
                            string Barcode1 = Bar.Text;


                            if (checkBox1.Checked == true)  // تصفير السعر
                            {
                                textBox1.Text = " ";
                            }
                            else
                            { }
                            string Price = textBox1.Text;

                            string Total = textNum.Text;
                            string[] row = { Category, Barcode1, Price, Total };
                            dataGridView1.Rows.Add(row);


                            t = dataGridView1.Rows.Count;

                            textNumRows.Text = t.ToString();

                            label18.Text = (n - i).ToString(); // المتبقى من الصنف الواحد
                        }
                        else
                        {

                            MessageBox.Show(" تم تجاوز العدد المسموح به 132 قطعه", " توقف ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            i = n + 1; // لكى يخرج من ال for

                        }
                    }

                }
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void DeleteRows_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            // int rowNumber1 = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;

                //  rowNumber1 = rowNumber1 + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


         

            textNumRows.Text = (dataGridView1.Rows.Count).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            textNumRows.Text = (dataGridView1.Rows.Count).ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)  // تصفير السعر
            {
                textBox1.Text = "0";
            }
            else
            { }



            int t = int.Parse(textNumRows.Text);
            int n = int.Parse(textNum.Text);

            for (int i = 1; i <= n; i++)
            {
                //if (t < 88)
                //{
                    string Category = comboBox2.Text;
                    string Barcode1 = Bar.Text;
                    string Price = textBox1.Text;
                    string Total = textNum.Text;
                    string[] row = { Category, Barcode1, Price, Total };
                    dataGridView2.Rows.Add(row);



                //    t = dataGridView1.Rows.Count;

                    textNumRows.Text = t.ToString();

                    label18.Text = (n - i).ToString(); // المتبقى من الصنف الواحد
                //}
                //else
                //{

                //    MessageBox.Show(" تم تجاوز العدد المسموح به 88 قطعه", " توقف ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    i = n + 1; // لكى يخرج من ال for

                //}

                //------------------- ترقيم الداتا جريد
                int rowNumber = 1;
                // int rowNumber1 = 0;
                foreach (DataGridViewRow row1 in dataGridView2.Rows)
                {
                    if (row1.IsNewRow) continue;
                    row1.HeaderCell.Value = "" + rowNumber + "";
                    rowNumber = rowNumber + 1;

                    //  rowNumber1 = rowNumber1 + 1;
                }
                dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);


            }




            comboBox2.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //try
            //{
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد طباعة جميع الباركود فى الجدول ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridView2.RowCount - 1);

                for (int j = 0; j < 89; j++)
                {

                    comboBox2.Text = dataGridView2.Rows[j].Cells[0].Value.ToString();


                    button2.PerformClick();


                    //textNum.Text = dataGridView2.Rows[j].Cells[].Value.ToString();

                    // button3.PerformClick();
                    int t = int.Parse(textNumRows.Text);
                    int n = int.Parse(textNum.Text);

                    for (int i = 1; i <= n; i++)
                    {
                        if (t < 88)
                        {
                            string Category = comboBox2.Text;
                            string Barcode1 = Bar.Text;
                            string Price = textBox1.Text;
                            string Total = textNum.Text;
                            string[] row = { Category, Barcode1, Price, Total };
                            dataGridView1.Rows.Add(row);


                            t = dataGridView1.Rows.Count;

                            textNumRows.Text = t.ToString();

                            label18.Text = (n - i).ToString(); // المتبقى من الصنف الواحد
                        }
                        else
                        {

                            MessageBox.Show(" تم تجاوز العدد المسموح به 88 قطعه", " توقف ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            i = n + 1; // لكى يخرج من ال for

                        }
                    }

                }
            }
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {

            textCount.Text = "1";

            //-----------------------------------

            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            labName.Text = "الصنف";

            textPricePrint.Text = "0";
            //----------------

            try
            {
                sqlCommand1.CommandText = "select * from Category where Category Like'" + comboBox1.Text + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textCategoryID1.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCategoryID2.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview.Text = "*" + reed["Barcode"].ToString() + "*";
                    textCodePreview2.Text = "*" + reed["Barcode"].ToString() + "*";
                    //textCodePreview3.Text = "*" + reed["Barcode"].ToString() + "*";
                    textBox2.Text = reed["Barcode"].ToString();
                    textBox4.Text = reed["Total"].ToString();
                    textBox3.Text = reed["PriceMostahlek"].ToString();
                    //   textPriceGm.Text = reed["PriceGomla"].ToString();
                    textPricePrint.Text = reed["PriceMostahlek"].ToString();
                }
                reed.Close();
            }
            catch
            { }
        }

        private void comboBox1_TabIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            labName.Text = "الصنف";

            textPricePrint.Text = "0";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                texSizeFontBarcode1.Text = "14";
                button4.Visible = true;
                button10.Visible = false;

            }
            else if (radioButton3.Checked == true)
            {
                texSizeFontBarcode1.Text = "12";
                button10.Visible = true;
                button4.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                texSizeFontBarcode1.Text = "14";
                button4.Visible = true;
                button10.Visible = false;

            }
            else if (radioButton3.Checked == true)
            {
                texSizeFontBarcode1.Text = "12";
                button10.Visible = true;
                button4.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int t = int.Parse(textNumRows.Text);
            if (t >= 50)
            {
                if (this.printDialog2.ShowDialog() == DialogResult.OK)
                {
                    this.printDocument4.Print();
                }
            }
            else
            {
                MessageBox.Show("          العدد اقل من 50 صنف - لابد ان لا يقل العدد عند 50 صنف      ", "    توقف    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs ev)
        {
            int f = int.Parse(texSizeFontBarcode1.Text);
            //  string TypeFonts = comTypeFont.Text; //"3 of 9 Barcode"
            int j = 0;
            for (int i = 10; i < 1110; i = i + 110)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                     8, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                  8, i + 70, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("IDAHC39M Code 39 Barcode", f), Brushes.Black,
                                       8, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 8), Brushes.Black,
                                       8, i + 80, new StringFormat());

                //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 5, i + 25, new StringFormat());
                // ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,65, i + 60, new StringFormat());

                j = j + 1;

            }


            for (int i = 10; i < 1110; i = i + 110)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   165, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                      165, i + 70, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("IDAHC39M Code 39 Barcode", f), Brushes.Black,
                                       165, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 8), Brushes.Black,
                                       165, i + 80, new StringFormat());

                //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black,153, i + 25, new StringFormat());
                // ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,233, i + 35, new StringFormat());

                j = j + 1;
            }

            for (int i = 10; i < 1110; i = i + 110)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   335, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                      335, i + 70, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("IDAHC39M Code 39 Barcode", f), Brushes.Black,
                                       335, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 8), Brushes.Black,
                                       335, i + 80, new StringFormat());

                // ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 343, i + 25, new StringFormat());
                //  ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black, 328, i + 35, new StringFormat());

                j = j + 1;

            }

            for (int i = 10; i < 1110; i = i + 110)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   505, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                       505, i + 70, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("IDAHC39M Code 39 Barcode", f), Brushes.Black,
                                       505, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 8), Brushes.Black,
                                       505, i + 80, new StringFormat());

                //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 543, i + 25, new StringFormat());
                //   ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black, 468, i + 35, new StringFormat());

                j = j + 1;

            }

            //************************************************

            for (int i = 10; i < 1110; i = i + 110)
            {
                ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
                                   670, i, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
                                       670, i + 70, new StringFormat());
                ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("IDAHC39M Code 39 Barcode", f), Brushes.Black,
                                       670, i + 10, new StringFormat());
                ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 8), Brushes.Black,
                                       670, i + 80, new StringFormat());

                //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 543, i + 25, new StringFormat());
                //  ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,608, i + 35, new StringFormat());

                j = j + 1;

            }

            //for (int i = 10; i < 1110; i = i + 50)
            //{
            //    ev.Graphics.DrawString(TextName.Text, new Font("Arial", 5), Brushes.Black,
            //                       680, i, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[0].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                           680, i + 25, new StringFormat());
            //    ev.Graphics.DrawString("*" + dataGridView1.Rows[j].Cells[1].Value.ToString() + "*", new Font("3 of 9 Barcode", f), Brushes.Black,
            //                           680, i + 10, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[2].Value.ToString(), new Font("Arial", 6), Brushes.Black,
            //                           693, i + 35, new StringFormat());

            //    //  ev.Graphics.DrawString("ج", new Font("Arial", 8), Brushes.Black, 543, i + 25, new StringFormat());
            //    ev.Graphics.DrawString(dataGridView1.Rows[j].Cells[1].Value.ToString(), new Font("Arial", 5), Brushes.Black,
            //                    743, i + 35, new StringFormat());

            //    j = j + 1;

            //}
        }

        private void radbutPrint38_12_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox3.Visible= true;
            panelMargins3812.Visible = true;
            panelMargins3825.Visible = false;
            panelMargins5025.Visible = false;
            panelMargins5040.Visible = false;

            texSizeFontBarcode.Text = "18";
            texSizeFontProduct.Text = "7";

            comTypeFont.Text = "3 of 9 Barcode";

            //TextNameX.Text = "5";
            //TextNameY.Text = "3";
            //textBarcodeX.Text = "5";
            //textBarcodeY.Text = "16";
            //textCategorysX.Text = "5";
            //textCategorysY.Text = "27";
            //textCategoryIDX.Text = "5";
            //textCategoryIDY.Text = "34";
            //textPriceX.Text = "55";
            //textPriceY.Text = "20";
        }

        private void butMargins_Click(object sender, EventArgs e)
        {
            TextNameX.Text = "80";
            TextNameY.Text = "1";
            textBarcodeX.Text = "10";
            textBarcodeY.Text = "15";
            textCategorysX.Text = "10";
            textCategorysY.Text = "34";
            textCategoryIDX.Text = "10";
            textCategoryIDY.Text = "3";
            textPriceX.Text = "55";
            textPriceY.Text = "3";
            textBarcodeSeparator.Text = "50";


            texSizeFontBarcode.Text = "18";
            texSizeFontProduct.Text = "7";

            comTypeFont.Text = "3 of 9 Barcode";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked==true)
            {
                panelMargins3812.Visible = true;


            }
            else
            {
                panelMargins3812.Visible = false;

            }
        }

        private void radbutPrint50_25_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox3.Visible = false;
            panelMargins3825.Visible = false;
            panelMargins5025.Visible = true;
            panelMargins5040.Visible = false;
            panelMargins3812.Visible = false;

            texSizeFontBarcode.Text = "12";
            texSizeFontProduct.Text = "6";

            comTypeFont.Text = "IDAHC39M Code 39 Barcode";
        }

        private void radbutPrint38_25_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox3.Visible = false;
            panelMargins3812.Visible = false;
            panelMargins3825.Visible = true;
            panelMargins5025.Visible = false;
            panelMargins5040.Visible = false;


            texSizeFontBarcode.Text = "12";
            texSizeFontProduct.Text = "6";

            comTypeFont.Text = "IDAHC39M Code 39 Barcode";

        }

        private void radbutPrint50_40_CheckedChanged(object sender, EventArgs e)
        {
            // checkBox3.Visible = false;
            panelMargins5040.Visible = true;
            panelMargins3812.Visible = false;
            panelMargins3825.Visible = false;
            panelMargins5025.Visible = false;

            texSizeFontBarcode.Text = "12";
            texSizeFontProduct.Text = "6";

            comTypeFont.Text = "IDAHC39M Code 39 Barcode";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد جلب الاصناف فى الجدول ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int NumRows = Convert.ToInt32(dataGridViewCategroyBill.RowCount - 1);

                for (int j = 0; j < NumRows; j++)
                {

                    comboBox2.Text = dataGridViewCategroyBill.Rows[j].Cells[1].Value.ToString();


                    button2.PerformClick();


                    textNum.Text = dataGridViewCategroyBill.Rows[j].Cells[2].Value.ToString();

                    // button3.PerformClick();
                    int t = int.Parse(textNumRows.Text);
                    int n = int.Parse(textNum.Text);

                    for (int i = 1; i <= n; i++)
                    {
                        //if (t < 132)
                        //{
                            string Category = comboBox2.Text;
                            string Barcode1 = Bar.Text;


                            if (checkBox1.Checked == true)  // تصفير السعر
                            {
                                textBox1.Text = " ";
                            }
                            else
                            { }
                            string Price = textBox1.Text;

                            string Total = textNum.Text;
                            string[] row = { Category, Barcode1, Price, Total };
                            dataGridView3.Rows.Add(row);


                            t = dataGridView3.Rows.Count;

                            textNumRowsAll.Text = t.ToString();

                            label18.Text = (n - i).ToString(); // المتبقى من الصنف الواحد
                        //}
                        //else
                        //{

                        //    MessageBox.Show(" تم تجاوز العدد المسموح به 132 قطعه", " توقف ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //    i = n + 1; // لكى يخرج من ال for

                        //}
                    }

                }
            }
        }

        private void btnMoveRows_Click(object sender, EventArgs e)
        {


            int maxRowsToMove = 132;

            if(radioButton4.Checked==true)
            {
                maxRowsToMove = 132;
            }
            else if(radioButton3.Checked==true)
            {
                maxRowsToMove = 50;
            }

            int t = int.Parse(textNumRows.Text);
            int n = int.Parse(textNum.Text);

            if (t < maxRowsToMove)
            {
                // تحقق من عدد الصفوف القابلة للنقل
                int availableRows = dataGridView3.Rows.Count;
                if (availableRows == 0)
                {
                    MessageBox.Show("لا توجد صفوف لنقلها.");
                    return;
                }

                // نحدد عدد الصفوف التي سيتم نقلها (حتى لو كانت أقل من 132)
                int rowsToMove = Math.Min(maxRowsToMove, availableRows);

                // قائمة مؤقتة لتخزين الصفوف التي سيتم نقلها
                List<DataGridViewRow> rowsList = new List<DataGridViewRow>();

                for (int i = 0; i < rowsToMove; i++)
                {
                    DataGridViewRow row = dataGridView3.Rows[i];

                    // نسخ الصف إلى قائمة مؤقتة (وليس مباشرة إلى DataGridView2 لتفادي مشاكل الفهرسة)
                    rowsList.Add(row);
                }

                // نسخ الصفوف إلى DataGridView2
                foreach (DataGridViewRow row in rowsList)
                {
                    int newIndex = dataGridView1.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dataGridView1.Rows[newIndex].Cells[i].Value = row.Cells[i].Value;
                    }
                }

                // حذف الصفوف من DataGridView1 (من الأخير للأول لتجنب تغير الفهارس)
                for (int i = rowsToMove - 1; i >= 0; i--)
                {
                    dataGridView3.Rows.RemoveAt(i);
                }

                // حساب عدد الصفوف في DataGridView2 (مع تجاهل صف الإضافة الجديد)
                int countInDGV2 = dataGridView1.AllowUserToAddRows ? dataGridView1.Rows.Count - 1 : dataGridView1.Rows.Count;

                // عرض العدد في TextBox
                textNumRows.Text = countInDGV2.ToString();


                // حساب عدد الصفوف في DataGridView2 (مع تجاهل صف الإضافة الجديد)
                int countInDGV3 = dataGridView3.AllowUserToAddRows ? dataGridView3.Rows.Count - 1 : dataGridView3.Rows.Count;

                // عرض العدد في TextBox
                textNumRowsAll.Text = countInDGV3.ToString();
            }
            else
            {
                MessageBox.Show("تم تجاوز العدد");
            }

                    

            
        }

        private void btnMoveRowsSelected_Click(object sender, EventArgs e)
        {
            int maxRowsToMove = 132;

            if (radioButton4.Checked == true)
            {
                maxRowsToMove = 132;
            }
            else if (radioButton3.Checked == true)
            {
                maxRowsToMove = 50;
            }

            int t = int.Parse(textNumRows.Text);
            int n = int.Parse(textNum.Text);

            if (t < maxRowsToMove)
            {
                // لتفادي أخطاء تعديل مجموعة أثناء التكرار
                List<DataGridViewRow> rowsToMove = new List<DataGridViewRow>();

                // جمع الصفوف المحددة
                foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                {
                    // تجاهل الصف الفارغ الجديد (إن وجد)
                    if (!row.IsNewRow)
                    {
                        rowsToMove.Add(row);
                    }
                }

                // نقل الصفوف
                foreach (DataGridViewRow row in rowsToMove)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        dataGridView1.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value;
                    }

                    // حذف من DataGridView1
                    dataGridView3.Rows.Remove(row);
                }



                // حساب عدد الصفوف في DataGridView2 (مع تجاهل صف الإضافة الجديد)
                int countInDGV2 = dataGridView1.AllowUserToAddRows ? dataGridView1.Rows.Count - 1 : dataGridView1.Rows.Count;

                // عرض العدد في TextBox
                textNumRows.Text = countInDGV2.ToString();


                // حساب عدد الصفوف في DataGridView2 (مع تجاهل صف الإضافة الجديد)
                int countInDGV3 = dataGridView3.AllowUserToAddRows ? dataGridView3.Rows.Count - 1 : dataGridView3.Rows.Count;

                // عرض العدد في TextBox
                textNumRowsAll.Text = countInDGV3.ToString();
            }
            else
            {
                MessageBox.Show("تم تجاوز العدد");
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
               // int rowIndex = dataGridView1.Rows.Add();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[2].Value = TextFristPrice.Text + dataGridView1.Rows[i].Cells[2].Value + TextEndPrice.Text;
                }

                // حذف من DataGridView1
              //  dataGridView3.Rows.Remove(row);
            //}
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            // int rowIndex = dataGridView1.Rows.Add();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = "";
            }

            // حذف من DataGridView1
            //  dataGridView3.Rows.Remove(row);
            //}
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(textCount.Text, out count))
            {
                MessageBox.Show("من فضلك أدخل رقم صحيح فى خانة العدد ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();

                //pd.PrintPage += new PrintPageEventHandler(PrintPage);
                if (radbutPrint50_40.Checked == true)
                {
                    pd.PrintPage += new PrintPageEventHandler(PrintPage50_40);
                    PaperSize ps = new PaperSize("50 x 40 mm", 196, 157);
                    pd.DefaultPageSettings.PaperSize = ps;

                }
                else if (radbutPrint50_25.Checked == true)
                {
                    pd.PrintPage += new PrintPageEventHandler(PrintPage50_25);
                    PaperSize ps = new PaperSize("50 x 25 mm", 196, 98);
                    pd.DefaultPageSettings.PaperSize = ps;
                }
                else if (radbutPrint38_25.Checked == true)
                {
                    pd.PrintPage += new PrintPageEventHandler(PrintPage38_25);
                    PaperSize ps = new PaperSize("38 x 25 mm", 149, 98);
                    pd.DefaultPageSettings.PaperSize = ps;
                }
                else if (radbutPrint38_12.Checked == true)
                {
                    pd.PrintPage += new PrintPageEventHandler(PrintPage38_12_2);
                    PaperSize ps = new PaperSize("38 x 12.5 mm", 149, 98);
                    pd.DefaultPageSettings.PaperSize = ps;

                }
                //PageSettings pa = new PageSettings();
                //pa.Margins = new Margins(5, 5, 5, 5);

                //pa.PrinterSettings.PrinterName = combPrinter.Text;
                //PrintDialog PrintDialog1 = new PrintDialog();



              //  int n = Convert.ToInt32(textCount.Text);
                
                Int16 n = Convert.ToInt16(textCount.Text);

               

                if (radbutPrint38_12.Checked == true) // ---- فى حالة الباركود المقسوم حنطبع على المقاس 38-25  ولكن مع تكرار الباركود فى المقاس وقسمتة على 2
                {

                    int num = 0;
                    if (Convert.ToInt32(textCount.Text) % 2 == 0)
                    {
                        num = Convert.ToInt32(textCount.Text) / 2;
                    }
                    else
                    {
                        num = (Convert.ToInt32(textCount.Text) + 1) / 2;
                    }

                    pd.PrinterSettings.Copies = (short)num;
                }
                else
                {
                    pd.PrinterSettings.Copies = n;
                }


                pd.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);
                pd.PrinterSettings.PrinterName = combPrinter.Text;

                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                // Response.Write("Error: " + ex.ToString());
            }
        }

        private void butPrintAllTableBarcode2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد طباعة جميع الباركود فى الجدول ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    int NumRows = Convert.ToInt32(dataGridViewCategroyBill.RowCount - 1);

                    for (int j = 0; j < NumRows; j++)
                    {

                        combCategorys.Text = dataGridViewCategroyBill.Rows[j].Cells[1].Value.ToString();


                        butSearch.PerformClick();


                        textCount.Text = dataGridViewCategroyBill.Rows[j].Cells[2].Value.ToString();

                        button14.PerformClick();
                    }
                }
            }
            catch
            {

            }
        }

        private void comTypeFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            // =========== تغير نوع الخط لخط الباركود المختار

            //string fontName = comTypeFont.Text.Trim();
            //// إنشاء خط جديد بنفس الحجم الحالي للتكست بوكس الهدف
            //Font newFont = new Font(fontName, textCodePreview3.Font.Size);

            //// تغيير خط التكست بوكس
            //textCodePreview3.Font = newFont;


            try
            {
                // قراءة اسم الخط من التكست بوكس
                string fontName = comTypeFont.Text.Trim();

                if (!string.IsNullOrEmpty(fontName))
                {
                    // إنشاء خط جديد بنفس الحجم الحالي للتكست بوكس الهدف
                    Font newFont = new Font(fontName, textCodePreview3.Font.Size);

                    // تغيير خط التكست بوكس
                    textCodePreview3.Font = newFont;
                }
                else
                {
                    MessageBox.Show("من فضلك اكتب اسم الخط في التكست بوكس.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("الخط المطلوب غير موجود على جهازك.");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            TextNameX3825.Text = "60";
            TextNameY3825.Text = "10";
            textBarcodeX3825.Text = "8";
            textBarcodeY3825.Text = "22";
            textCategorysX3825.Text = "1";
            textCategorysY3825.Text = "85";
            
            textPriceX3825.Text = "10";
            textPriceY3825.Text = "10";


            texSizeFontBarcode.Text = "12";
            texSizeFontProduct.Text = "6";

            comTypeFont.Text = "IDAHC39M Code 39 Barcode";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            TextNameX5025.Text = "60";
            TextNameY5025.Text = "10";
            textBarcodeX5025.Text = "5";
            textBarcodeY5025.Text = "20";
            textCategorysX5025.Text = "1";
            textCategorysY5025.Text = "86";

            textPriceX5025.Text = "10";
            textPriceY5025.Text = "10";


            texSizeFontBarcode.Text = "13";
            texSizeFontProduct.Text = "6";

            comTypeFont.Text = "IDAHC39M Code 39 Barcode";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            TextNameX5040.Text = "60";
            TextNameY5040.Text = "10";
            textBarcodeX5040.Text = "5";
            textBarcodeY5040.Text = "20";
            textCategorysX5040.Text = "1";
            textCategorysY5040.Text = "86";

            textPriceX5040.Text = "10";
            textPriceY5040.Text = "10";


            texSizeFontBarcode.Text = "13";
            texSizeFontProduct.Text = "6";

            comTypeFont.Text = "IDAHC39M Code 39 Barcode";
        }
    }
    
}
