using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Printing;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using File = System.IO.File;
using Microsoft.Win32;

using System.Diagnostics;

namespace ZAD_Sales.Forms
{
    public partial class SettingsGeneral : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;

        string UseLimitCredit = "0";

        //-----------------------------
        public SettingsGeneral()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
        }

        private void GetData()
        {
            //------------  Barcode_Seting  ------------

            texBarcodeStart.Text = AppSetting.BarcodeStart;
            comPrinterBarcode.Text = AppSetting.BarcodePrinter;
            textBarcodeSize.Text = AppSetting.BarcodeSize;
            comTypeFont.Text = AppSetting.BarcodeTypeFont;
            txtFontSizeBarcode.Text = AppSetting.BarcodeFontSize;

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



            //----------- End Barcode_Seting---------------


            textCompany_Name.Text = AppSetting.textCompany_Name;
            textCompany_Phone.Text = AppSetting.textCompany_Phone;
            textCompany_Description.Text = AppSetting.textCompany_Description;
            textCompany_Address.Text = AppSetting.textCompany_Address;
           // picCompany_Logo.Image = AppSetting.pic_logo;
            textNoteToBill.Text = AppSetting.NoteToBill;
            comPrinterBill.Text = AppSetting.PrinterBill;
            comSizePaperBill.Text = AppSetting.SizePaperBill;
          //  comPrinterBarcode.Text = AppSetting.PrinterBarcode;
            TxtPrintName.Text = AppSetting.PrintNameComToBill;
            TxtLogoCom.Text = AppSetting.PrintLogoComToBill;
           // txtFontSizeBarcode.Text = AppSetting.FontSizeBarcode;
            textAddBath.Text = AppSetting.BathBackup;

            textImageUrl.Text = AppSetting.Comp_Logo;
           // texBarcodeStart.Text = AppSetting.BarcodeStart;
            comTypeBill.Text = AppSetting.TypeBillDefoult;
            comTypeCurrency.Text = AppSetting.TypeCurrency;
           // comTypeFont.Text = AppSetting.TypeFont;

            comboBox1.Text = AppSetting.TypePrinter;
           // textBarcodeSize.Text = AppSetting.BarcodeSize;

            
            string UseLimitCredit = AppSetting.UseLimitCredit;

            textDiscountBill.Text = AppSetting.DiscountBill;

            textBox1.Text = AppSetting.BarcodeSales;
            textBox5.Text = AppSetting.BarcodeSalesType;
            textBox2.Text = AppSetting.CollectionProduct;
            textBox3.Text = AppSetting.HideBalance;




            textOpenFormOther.Text = AppSetting.OpenFormOther;

            textBoxPrices.Text = AppSetting.PricesAll;


            if (textBoxPrices.Text == "0")
            {
                checkBoxPrices.Checked = false;
            }
            else if (textBoxPrices.Text == "1")
            {
                checkBoxPrices.Checked = true;
            }
            else
            { }


            if (textOpenFormOther.Text == "0")
            {
                checkBox6.Checked = false;
            }
            else if (textOpenFormOther.Text == "1")
            {
                checkBox6.Checked = true;
            }
            else
            { }




            if (UseLimitCredit == "0")
            {
                checkUseLimitCredit.Checked = false;
            }
            else if (UseLimitCredit == "1")
            {
                checkUseLimitCredit.Checked = true;
            }
            else
            { }

            try
            {
                picCompany_Logo.Image = Image.FromFile(AppSetting.Comp_Logo);
            }
            catch
            { }


            txtPriceSheraaAcount.Text = AppSetting.PriceSheraaAcount;
            if (txtPriceSheraaAcount.Text == "السعر الجديد")
            {
                rdPriceNew.Checked = true;
            }
            else if (txtPriceSheraaAcount.Text == "السعر القديم")
            {
                rdPriceOld.Checked = true;
            }
            else if (txtPriceSheraaAcount.Text == "متوسط السعر")
            {
                rdPriceAvarg.Checked = true;
            }
            else
            {
                rdPriceNew.Checked = true;
            }



            if (textBarcodeSize.Text == "50-40")
            {
                radbutPrint50_40.Checked = true;
            }
            else if (textBarcodeSize.Text == "38-25")
            {
                radbutPrint38_25.Checked = true;
            }
            else if (textBarcodeSize.Text == "50-25")
            {
                radbutPrint50_25.Checked = true;
            }
            else if (textBarcodeSize.Text == "38-12")
            {
                radbutPrint38_12.Checked = true;
            }

        }
        private void butEditAllBarcode_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "انتبه سوف يتم تغير جميع الباركود الخاص بالاصناف هل تريد الاستكمال ؟", "انتبه ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //int a = Convert.ToInt32(IDCategory);
                //int b = 1000000000;
                //int s = a + b;
                //Barcode = s.ToString();
                int b = 0;

                try
                {
                    int a = Convert.ToInt32(texBarcodeStart.Text);
                    b = a;
                    if (b == 0)
                    {
                        b = 1000000000;

                    }
                }
                catch
                {
                    b = 1000000000;
                }



                try
                {
                    sqlCommand1.CommandText = "update Category set  Barcode=('" + b + "'+ID)";
                    sqlCommand1.ExecuteNonQuery();
                    MessageBox.Show("  تم تكويد جميع الاصناف بالباركود بنجاح    ", "  ملحوظة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                }
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picCompany_Logo.Image.Save(ms, picCompany_Logo.Image.RawFormat);
            byte[] byteImage = ms.ToArray();


            sqlCommand1.CommandText = "update  SystemProgram set Company_Name=@Company_Name,Company_Description=@Company_Description,Company_Address=@Company_Address,Company_Phone=@Company_Phone,NoteToBill=@NoteToBill,PrinterBill=@PrinterBill,SizePaperBill=@SizePaperBill,PrinterBarcode=@PrinterBarcode,PrintNameComToBill=@PrintNameComToBill,PrintLogoComToBill=@PrintLogoComToBill,FontSizeBarcode=@FontSizeBarcode,PriceSheraaAcount=@PriceSheraaAcount,BathBackup=@BathBackup,Comp_Logo=@Comp_Logo,BarcodeStart=@BarcodeStart,TypeBillDefoult=@TypeBillDefoult,TypeCurrency=@TypeCurrency,TypeFont=@TypeFont,UseLimitCredit=@UseLimitCredit,DiscountBill=@DiscountBill where ID ='" + 1 + "'";
            sqlCommand1.Parameters.Add("@Company_Name", SqlDbType.VarChar).Value = textCompany_Name.Text;
            sqlCommand1.Parameters.Add("@Company_Description", SqlDbType.VarChar).Value = textCompany_Description.Text;
            sqlCommand1.Parameters.Add("@Company_Address", SqlDbType.VarChar).Value = textCompany_Address.Text;

            sqlCommand1.Parameters.Add("@Company_Phone", SqlDbType.VarChar).Value = textCompany_Phone.Text;
           // sqlCommand1.Parameters.Add("@Company_Logo", SqlDbType.Image).Value = byteImage;
            sqlCommand1.Parameters.Add("@NoteToBill", SqlDbType.VarChar).Value = textNoteToBill.Text;

            sqlCommand1.Parameters.Add("@PrinterBill", SqlDbType.VarChar).Value = comPrinterBill.Text;
            sqlCommand1.Parameters.Add("@SizePaperBill", SqlDbType.VarChar).Value = comSizePaperBill.Text;
            sqlCommand1.Parameters.Add("@PrinterBarcode", SqlDbType.VarChar).Value = comPrinterBarcode.Text;

            sqlCommand1.Parameters.Add("@PrintNameComToBill", SqlDbType.VarChar).Value = TxtPrintName.Text;

            sqlCommand1.Parameters.Add("@PrintLogoComToBill", SqlDbType.VarChar).Value = TxtLogoCom.Text;
            sqlCommand1.Parameters.Add("@FontSizeBarcode", SqlDbType.Float).Value = txtFontSizeBarcode.Text;
            sqlCommand1.Parameters.Add("@PriceSheraaAcount", SqlDbType.NVarChar).Value = txtPriceSheraaAcount.Text;
            sqlCommand1.Parameters.Add("@BathBackup", SqlDbType.NVarChar).Value = textAddBath.Text;
            sqlCommand1.Parameters.Add("@Comp_Logo", SqlDbType.NVarChar).Value = textImageUrl.Text;
            sqlCommand1.Parameters.Add("@BarcodeStart", SqlDbType.NVarChar).Value = texBarcodeStart.Text;
            sqlCommand1.Parameters.Add("@TypeBillDefoult", SqlDbType.NVarChar).Value = comTypeBill.Text;
            sqlCommand1.Parameters.Add("@TypeCurrency", SqlDbType.NVarChar).Value = comTypeCurrency.Text;
            sqlCommand1.Parameters.Add("@TypeFont", SqlDbType.NVarChar).Value = comTypeFont.Text;
            sqlCommand1.Parameters.Add("@UseLimitCredit", SqlDbType.NVarChar).Value = UseLimitCredit;
            sqlCommand1.Parameters.Add("@DiscountBill", SqlDbType.Float).Value = textDiscountBill.Text;
            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();


            //AppSetting.textGomlaKataey = textGomlaKataey;
            //AppSetting.textKataey = textKataey;
            AppSetting.textCompany_Name = textCompany_Name.Text;
            AppSetting.textCompany_Description = textCompany_Description.Text;
            AppSetting.textCompany_Address = textCompany_Address.Text;
            AppSetting.textCompany_Phone = textCompany_Phone.Text;
            //AppSetting.pic_logo = pic_logo;
            //-----------------------------------------------
            AppSetting.NoteToBill = textNoteToBill.Text;
            AppSetting.PrinterBill = comPrinterBill.Text;
            AppSetting.SizePaperBill = comSizePaperBill.Text;
            AppSetting.PrinterBarcode = comPrinterBarcode.Text;
            AppSetting.PrintNameComToBill = TxtPrintName.Text;
            AppSetting.PrintLogoComToBill = TxtLogoCom.Text;
            AppSetting.FontSizeBarcode = txtFontSizeBarcode.Text;
            AppSetting.PriceSheraaAcount = txtPriceSheraaAcount.Text;
            AppSetting.BarcodeStart = texBarcodeStart.Text;
            AppSetting.TypeBillDefoult = comTypeBill.Text;
            AppSetting.TypeCurrency = comTypeCurrency.Text;
            AppSetting.TypeFont = comTypeFont.Text;
            AppSetting.UseLimitCredit = UseLimitCredit;
            AppSetting.DiscountBill = textDiscountBill.Text;
            AppSetting.Comp_Logo = textImageUrl.Text;

            MessageBox.Show("تم حفظ البيانات بنجاح", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("البيانات غير صحيحة تاكد من البيانات", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void butShosePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog og1 = new OpenFileDialog();

            var _with1 = og1;
            og1.Title = "(Select Image) (تحديد صورة)";
            og1.Filter = "JPEG,BMP,PNG  (تحديد صورة) (Select Image) |*.jpg;*.jpeg;*.bmp;*.png";

            if (og1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picCompany_Logo.Image = Image.FromFile(og1.FileName);
                textImageUrl.Text = og1.FileName;
            }
            else
            {
                MessageBox.Show("عفواً ألغي الأمر بناء على طلبك");
                this.Focus();
            }
        }

        private void SettingsGeneral_Load(object sender, EventArgs e)
        {
            GetData();

            string AllowUser = AppSetting.AllowUser;
            if (AllowUser == "1") // الصلاحيات الخاصة الداخلية
            {
                textDiscountBill.Enabled = true;
            }
            else
            {
                textDiscountBill.Enabled = false;

            }

            //---------- عرض الطابعات المسطبةعلى الجهاز --------------
            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                comPrinterBill.Items.Add(printerName);
                comPrinterBarcode.Items.Add(printerName);
            }
        }

        private void rdPriceNew_CheckedChanged(object sender, EventArgs e)
        {
            if(rdPriceNew.Checked==true)
            {
                txtPriceSheraaAcount.Text = "السعر الجديد";
            }
            else if ( rdPriceOld.Checked==true)
            {
                txtPriceSheraaAcount.Text = "السعر القديم";

            }
            else if (rdPriceAvarg.Checked==true)
            {
                txtPriceSheraaAcount.Text = "متوسط السعر";

            }
            else
            { }

        }

        private void rdPriceOld_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPriceNew.Checked == true)
            {
                txtPriceSheraaAcount.Text = "السعر الجديد";
            }
            else if (rdPriceOld.Checked == true)
            {
                txtPriceSheraaAcount.Text = "السعر القديم";

            }
            else if (rdPriceAvarg.Checked == true)
            {
                txtPriceSheraaAcount.Text = "متوسط السعر";

            }
            else
            { }
        }

        private void rdPriceAvarg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPriceNew.Checked == true)
            {
                txtPriceSheraaAcount.Text = "السعر الجديد";
            }
            else if (rdPriceOld.Checked == true)
            {
                txtPriceSheraaAcount.Text = "السعر القديم";

            }
            else if (rdPriceAvarg.Checked == true)
            {
                txtPriceSheraaAcount.Text = "متوسط السعر";

            }
            else
            { }
        }

        private void TxtPrintName_TextChanged(object sender, EventArgs e)
        {
            if (TxtPrintName.Text == "1")

            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void butAddBath_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Backup Files(*.Bak)|*.bak";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    textAddBath.Text = sf.FileName;

                    //cmd = new SqlCommand("Backup Database ZAD To Disk='" + sf.FileName + "'", cn);
                    //cn.Open();
                    //cmd.ExecuteNonQuery();
                    //cn.Close();

                    //MessageBox.Show("       تم أخذ نسخة إحتياطية بنجاح    ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)

            {
                TxtPrintName.Text = "1";
            }
            else
            {
                TxtPrintName.Text = "0";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)

            {
                TxtLogoCom.Text = "1";
            }
            else
            {
                TxtLogoCom.Text = "0";
            }
        }

        private void TxtLogoCom_TextChanged(object sender, EventArgs e)
        {
            if (TxtLogoCom.Text == "1")

            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (textImageUrl.Visible == true)
            {
                textImageUrl.Visible = false;
            }
            else
            {
                textImageUrl.Visible = true;
            }
        }

        private void checkUseLimitCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUseLimitCredit.Checked == true)
            {
                UseLimitCredit = "1";
            }
            else
            {
                UseLimitCredit = "0";
            }
        }
        public void FontBarcode3of9BarcodeRegular()
        {
            if (File.Exists(Application.StartupPath.ToString() + "\\Fonts\\" + @"3of9BarcodeRegular.ttf") )
            {
                //MessageBox.Show("Setup SQLEXPR2012_x64_ENU ");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\Fonts\\" + @"3of9BarcodeRegular.ttf";

                myProcess.Start();
                System.Threading.Thread.Sleep(1190);
                //Properties.Settings.Default.Crystal = 2;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
            else
            {
                MessageBox.Show("        الملف المطلوب غير موجود    ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void linkLabelFont3of9Barcode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontBarcode3of9BarcodeRegular();
        }

        public void FontBarcodeFREE3OF9()
        {
            if (File.Exists(Application.StartupPath.ToString() + "\\Fonts\\" + @"FREE3OF9.TTF") )
            {
                //MessageBox.Show("Setup SQLEXPR2012_x64_ENU ");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\Fonts\\" + @"FREE3OF9.TTF";

                myProcess.Start();
                System.Threading.Thread.Sleep(1190);
                //Properties.Settings.Default.Crystal = 2;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
            else
            {
                 MessageBox.Show("        الملف المطلوب غير موجود    ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void linkLabelFontFREE3OF9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontBarcodeFREE3OF9();
        }

        public void FontCairoBlack()
        {
            if (File.Exists(Application.StartupPath.ToString() + "\\Fonts\\" + @"Cairo-Black.otf"))
            {
                //MessageBox.Show("Setup SQLEXPR2012_x64_ENU ");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\Fonts\\" + @"Cairo-Black.otf";

                myProcess.Start();
                System.Threading.Thread.Sleep(1190);
                //Properties.Settings.Default.Crystal = 2;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
            else
            {
                MessageBox.Show("        الملف المطلوب غير موجود    ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void linkLabelCairoBlack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontCairoBlack();
        }
        public void Fontidahc39mcode39barcoderegular()
        {
            if (File.Exists(Application.StartupPath.ToString() + "\\Fonts\\" + @"idahc39m-code-39-barcode.regular.TTF"))
            {
                //MessageBox.Show("Setup SQLEXPR2012_x64_ENU ");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\Fonts\\" + @"idahc39m-code-39-barcode.regular.TTF";

                myProcess.Start();
                System.Threading.Thread.Sleep(1190);
                //Properties.Settings.Default.Crystal = 2;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
            else
            {
                MessageBox.Show("        الملف المطلوب غير موجود    ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void linkLabelidahc39mcode39barcode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fontidahc39mcode39barcoderegular();
        }

        private void butOpenFolder_Click(object sender, EventArgs e)
        {
           // Process.Start("explorer",@"C:\temp");
            
            Process.Start("explorer", Application.StartupPath.ToString() + "\\Fonts\\");
        }
        public void FontCairoBold()
        {
            if (File.Exists(Application.StartupPath.ToString() + "\\Fonts\\" + @"Cairo-Bold.TTF"))
            {
                //MessageBox.Show("Setup SQLEXPR2012_x64_ENU ");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\Fonts\\" + @"Cairo-Bold.TTF";

                myProcess.Start();
                System.Threading.Thread.Sleep(1190);
                //Properties.Settings.Default.Crystal = 2;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
            else
            {
                MessageBox.Show("        الملف المطلوب غير موجود    ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void linkLabelCairoBold_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontCairoBold();
        }

        private void butUbdateBill_Click(object sender, EventArgs e)
        {
            try
            {
                double dicount = Convert.ToDouble(textDiscountBill.Text);

                sqlCommand1.CommandText = "update  SystemProgram set NoteToBill=@NoteToBill,PrinterBill=@PrinterBill,SizePaperBill=@SizePaperBill,PrintNameComToBill=@PrintNameComToBill,PrintLogoComToBill=@PrintLogoComToBill,TypeBillDefoult=@TypeBillDefoult,TypeCurrency=@TypeCurrency,DiscountBill=@DiscountBill,BarcodeSales=@BarcodeSales,CollectionProduct=@CollectionProduct,HideBalance=@HideBalance,BarcodeSalesType=@BarcodeSalesType,OpenFormOther=@OpenFormOther,PricesAll=@PricesAll where ID ='" + 1 + "'";
                
                sqlCommand1.Parameters.Add("@NoteToBill", SqlDbType.VarChar).Value = textNoteToBill.Text;
                sqlCommand1.Parameters.Add("@PrinterBill", SqlDbType.VarChar).Value = comPrinterBill.Text;
                sqlCommand1.Parameters.Add("@SizePaperBill", SqlDbType.VarChar).Value = comSizePaperBill.Text;             
                sqlCommand1.Parameters.Add("@PrintNameComToBill", SqlDbType.VarChar).Value = TxtPrintName.Text;
                sqlCommand1.Parameters.Add("@PrintLogoComToBill", SqlDbType.VarChar).Value = TxtLogoCom.Text;                           
                sqlCommand1.Parameters.Add("@TypeBillDefoult", SqlDbType.NVarChar).Value = comTypeBill.Text;
                sqlCommand1.Parameters.Add("@TypeCurrency", SqlDbType.NVarChar).Value = comTypeCurrency.Text;
                sqlCommand1.Parameters.Add("@DiscountBill", SqlDbType.Float).Value = textDiscountBill.Text;
                sqlCommand1.Parameters.Add("@BarcodeSales", SqlDbType.NVarChar).Value = textBox1.Text;
                sqlCommand1.Parameters.Add("@BarcodeSalesType", SqlDbType.NVarChar).Value = textBox5.Text;

                sqlCommand1.Parameters.Add("@CollectionProduct", SqlDbType.NVarChar).Value = textBox2.Text;
                sqlCommand1.Parameters.Add("@HideBalance", SqlDbType.VarChar).Value = textBox3.Text;
                sqlCommand1.Parameters.Add("@OpenFormOther", SqlDbType.VarChar).Value = textOpenFormOther.Text;
                sqlCommand1.Parameters.Add("@PricesAll", SqlDbType.VarChar).Value = textBoxPrices.Text;
                sqlCommand1.ExecuteNonQuery();
                sqlCommand1.Parameters.Clear();

                AppSetting.NoteToBill = textNoteToBill.Text;
                AppSetting.PrinterBill = comPrinterBill.Text;
                AppSetting.SizePaperBill = comSizePaperBill.Text;
                AppSetting.PrintNameComToBill = TxtPrintName.Text;
                AppSetting.PrintLogoComToBill = TxtLogoCom.Text;
                AppSetting.TypeBillDefoult = comTypeBill.Text;
                AppSetting.TypeCurrency = comTypeCurrency.Text;
                AppSetting.DiscountBill = textDiscountBill.Text;

                AppSetting.BarcodeSales = textBox1.Text;
                AppSetting.BarcodeSalesType = textBox5.Text;

                AppSetting.CollectionProduct = textBox2.Text;
                AppSetting.HideBalance = textBox3.Text;
                AppSetting.OpenFormOther = textOpenFormOther.Text;
                AppSetting.PricesAll = textBoxPrices.Text;


                MessageBox.Show("تم حفظ البيانات بنجاح", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //sqlCommand1.CommandText = "update Category set  Category='" + textBox1.Text + "',  Faction ='" + comboBox2.Text + "',  Available ='" + comboBox3.Text + "',  Near='" + textBox6.Text + "' where  ID ='" + textBox7.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
                //// MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

            }
            catch
            {
                //  MessageBox.Show("يوجد خطأ", "Error");
            }
        }

        private void chBoxBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxBarcode.Checked == true)

            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)

            {
                textBox2.Text = "1";
            }
            else
            {
                textBox2.Text = "0";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)

            {
                textBox3.Text = "1";
            }
            else
            {
                textBox3.Text = "0";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "1")

            {
                chBoxBarcode.Checked = true;
            }
            else
            {
                chBoxBarcode.Checked = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "1")

            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "1")

            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

            if (butEditAllBarcode.Enabled == true)
            {

                butEditAllBarcode.Enabled = false;
            }

            else
            {

                butEditAllBarcode.Enabled = true;
            }
        }

        private void butUbdateBarcode_Click(object sender, EventArgs e)
        {

            sqlCommand1.CommandText = "update  SystemProgram set PrinterBarcode=@PrinterBarcode,FontSizeBarcode=@FontSizeBarcode,BarcodeStart=@BarcodeStart,TypeFont=@TypeFont,TypePrinter=@TypePrinter,BarcodeSize=@BarcodeSize where ID ='" + 1 + "'";
            
            sqlCommand1.Parameters.Add("@PrinterBarcode", SqlDbType.VarChar).Value = comPrinterBarcode.Text;

            sqlCommand1.Parameters.Add("@FontSizeBarcode", SqlDbType.Float).Value = txtFontSizeBarcode.Text;
      
            sqlCommand1.Parameters.Add("@BarcodeStart", SqlDbType.NVarChar).Value = texBarcodeStart.Text;
           
            sqlCommand1.Parameters.Add("@TypeFont", SqlDbType.NVarChar).Value = comTypeFont.Text;

            sqlCommand1.Parameters.Add("@TypePrinter", SqlDbType.NVarChar).Value = comboBox1.Text;

            sqlCommand1.Parameters.Add("@BarcodeSize", SqlDbType.NVarChar).Value = textBarcodeSize.Text;

            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();


            //---------------  Barcode_Seting

            sqlCommand1.CommandText = "update  Barcode_Seting set BarcodeStart=@BarcodeStart,BarcodePrinter=@BarcodePrinter,BarcodeSize=@BarcodeSize,BarcodeTypeFont=@BarcodeTypeFont,BarcodeFontSize=@BarcodeFontSize,ProductSize=@ProductSize,MarginsCompaneyX=@MarginsCompaneyX,MarginsCompaneyY=@MarginsCompaneyY,MarginsBarcodeX=@MarginsBarcodeX,MarginsBarcodeY=@MarginsBarcodeY,MarginsCategorysX= @MarginsCategorysX,MarginsCategorysY= @MarginsCategorysX,MarginsCategoryIDX= @MarginsCategoryIDX,MarginsCategoryIDY= @MarginsCategoryIDY ,MarginsPriceX=@MarginsPriceX ,MarginsPriceY=@MarginsPriceY where ID ='" + 1 + "'";
            
            sqlCommand1.Parameters.Add("@BarcodeStart", SqlDbType.VarChar).Value = texBarcodeStart.Text;

            sqlCommand1.Parameters.Add("@BarcodePrinter", SqlDbType.NVarChar).Value = comPrinterBarcode.Text;

            sqlCommand1.Parameters.Add("@BarcodeSize", SqlDbType.NVarChar).Value = textBarcodeSize.Text;

            sqlCommand1.Parameters.Add("@BarcodeTypeFont", SqlDbType.NVarChar).Value = comTypeFont.Text;

            sqlCommand1.Parameters.Add("@BarcodeFontSize", SqlDbType.Float).Value = txtFontSizeBarcode.Text;

            sqlCommand1.Parameters.Add("@ProductSize", SqlDbType.Float).Value = texSizeFontProduct.Text;

            sqlCommand1.Parameters.Add("@MarginsCompaneyX", SqlDbType.Float).Value = TextNameX.Text;
            sqlCommand1.Parameters.Add("@MarginsCompaneyY", SqlDbType.Float).Value = TextNameY.Text;
            sqlCommand1.Parameters.Add("@MarginsBarcodeX", SqlDbType.Float).Value = textBarcodeX.Text;
            sqlCommand1.Parameters.Add("@MarginsBarcodeY", SqlDbType.Float).Value = textBarcodeY.Text;
            sqlCommand1.Parameters.Add("@MarginsCategorysX", SqlDbType.Float).Value = textCategorysX.Text;
            sqlCommand1.Parameters.Add("@MarginsCategorysY", SqlDbType.Float).Value = textCategorysY.Text;
            sqlCommand1.Parameters.Add("@MarginsCategoryIDX", SqlDbType.Float).Value = textCategoryIDX.Text;
            sqlCommand1.Parameters.Add("@MarginsCategoryIDY", SqlDbType.Float).Value = textCategoryIDY.Text;
            sqlCommand1.Parameters.Add("@MarginsPriceX", SqlDbType.Float).Value = textPriceX.Text;
            sqlCommand1.Parameters.Add("@MarginsPriceY", SqlDbType.Float).Value = textPriceY.Text;

            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();

            AppSetting.BarcodeStart = texBarcodeStart.Text;
            AppSetting.BarcodePrinter = comPrinterBarcode.Text;
            AppSetting.BarcodeSize = textBarcodeSize.Text;
            AppSetting.BarcodeTypeFont = comTypeFont.Text;
            AppSetting.BarcodeFontSize = txtFontSizeBarcode.Text;

            AppSetting.ProductSize = texSizeFontProduct.Text;
            AppSetting.MarginsCompaneyX = TextNameX.Text;
            AppSetting.MarginsCompaneyY = TextNameY.Text;
            AppSetting.MarginsBarcodeX = textBarcodeX.Text;
            AppSetting.MarginsBarcodeY = textBarcodeY.Text;

            AppSetting.MarginsCategorysX = textCategorysX.Text;
            AppSetting.MarginsCategorysY = textCategorysY.Text;
            AppSetting.MarginsCategoryIDX = textCategoryIDX.Text;
            AppSetting.MarginsCategoryIDY = textCategoryIDY.Text;
            AppSetting.MarginsPriceX = textPriceX.Text;
            AppSetting.MarginsPriceY = textPriceY.Text;






            AppSetting.TypePrinter = comboBox1.Text;



        MessageBox.Show("تم حفظ البيانات بنجاح", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = "update  SystemProgram set PriceSheraaAcount=@PriceSheraaAcount,BathBackup=@BathBackup,UseLimitCredit=@UseLimitCredit where ID ='" + 1 + "'";
            
            sqlCommand1.Parameters.Add("@PriceSheraaAcount", SqlDbType.NVarChar).Value = txtPriceSheraaAcount.Text;
            sqlCommand1.Parameters.Add("@BathBackup", SqlDbType.NVarChar).Value = textAddBath.Text;
            
            sqlCommand1.Parameters.Add("@UseLimitCredit", SqlDbType.NVarChar).Value = UseLimitCredit;
            
            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();


            //-----------------------------------------------
           
            AppSetting.PriceSheraaAcount = txtPriceSheraaAcount.Text;
            
            AppSetting.UseLimitCredit = UseLimitCredit;

            AppSetting.BathBackup = textAddBath.Text;


            MessageBox.Show("تم حفظ البيانات بنجاح", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radbutPrint50_40_CheckedChanged(object sender, EventArgs e)
        {
            if (radbutPrint50_40.Checked == true)

            {
                textBarcodeSize.Text = "50-40";
            }
            else
            {
                textBarcodeSize.Text = "";
            }

            groupBox8.Visible = false;
        }

        private void radbutPrint38_25_CheckedChanged(object sender, EventArgs e)
        {
            if (radbutPrint38_25.Checked == true)

            {
                textBarcodeSize.Text = "38-25";
            }
            else
            {
                textBarcodeSize.Text = "";
            }

            groupBox8.Visible = false;
        }

        private void radbutPrint50_25_CheckedChanged(object sender, EventArgs e)
        {
            if (radbutPrint50_25.Checked == true)

            {
                textBarcodeSize.Text = "50-25";
            }
            else
            {
                textBarcodeSize.Text = "";
            }

            groupBox8.Visible = false;
        }

        private void radbutPrint38_12_CheckedChanged(object sender, EventArgs e)
        {
            if (radbutPrint38_12.Checked == true)

            {
                textBarcodeSize.Text = "38-12";
            }
            else
            {
                textBarcodeSize.Text = "";
            }

            groupBox8.Visible = true;
        }

        private void radioB_Program_CheckedChanged(object sender, EventArgs e)
        {
            if (radioB_Program.Checked == true)

            {
                textBox5.Text = "1";
            }
            else
            {
                textBox5.Text = "0";
            }
        }

        private void radioB_Factory_CheckedChanged(object sender, EventArgs e)
        {
            if (radioB_Factory.Checked == true)

            {
                textBox5.Text = "0";
            }
            else
            {
                textBox5.Text = "1";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "1")

            {
                radioB_Program.Checked = true;
               // radioB_Factory.Checked = false;
            }
            else
            {
                radioB_Factory.Checked = true;
              //  radioB_Program.Checked = false;
            }
        }

        private void butMargins_Click(object sender, EventArgs e)
        {
            TextNameX.Text = "5";
            TextNameY.Text = "1";
            textBarcodeX.Text = "5";
            textBarcodeY.Text = "10";
            textCategorysX.Text = "5";
            textCategorysY.Text = "25";
            textCategoryIDX.Text = "5";
            textCategoryIDY.Text = "33";
            textPriceX.Text = "55";
            textPriceY.Text = "32";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)

            {
                textOpenFormOther.Text = "1";
            }
            else
            {
                textOpenFormOther.Text = "0";
            }
        }

        private void checkBoxPrices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPrices.Checked == true)

            {
                textBoxPrices.Text = "1";
            }
            else
            {
                textBoxPrices.Text = "0";
            }
        }
    }
}
