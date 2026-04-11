using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;


using ZAD_Sales.DAL;
using ZAD_Sales.Models;
using ZAD_Sales.ClassProject;

namespace ZAD_Sales.Forms
{
    public partial class Main : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        private readonly OccasionDAL occasionDAL;


        //-----------------------------------------------------
        private SqlDataReader rred;
        private SqlDataReader red;
        private SqlDataReader dr;
        private SqlDataReader reed;

        //----------------------------------
        string texthddserial1 = "";

        string BathBackup = "";
        //----------------
        Sales Sales1;
        Purchases Purchases1;
        string DataName = "";

        Expenses Expenses1;
        MoneyToBox MoneyToBox1;
        MoneyFromBox MoneyFromBox1;

        GroupAdd GroupAdd1;
        EmployeeAdd EmployeeAdd1;
        EmployeeSalaryPayment EmployeeSalaryPayment1;
        EmployeeSalaryMovement EmployeeSalaryMovement1;
        EmployeeBonusAdd EmployeeBonusAdd1;
        EmployeePenaltyAdd EmployeePenaltyAdd1;
        CarsAdd CarsAdd1;
        CarsExpenses CarsExpenses1;
        CarsExpensesMovement CarsExpensesMovement1;
        UserAdd UserAdd2;
        UserAddNew UserAdd1;
        BackupSave BackupSave1;
        BackupRestore BackupRestore1;
        SettingsGeneral SettingsGeneral1;
        SystemReset SystemReset1;
        License License1;
        CallUs CallUs1;

        ClientAdd ClientAdd1;
        ClientsMoney ClientsMoney1;
        ExplainSystem ExplainSystem1;
        Connection Connection1;
        ProducerNewAdd ProducerNewAdd1;
        StoreNewAdd StoreNewAdd1;
        Prices Prices1;
        ProducerUpdate ProducerUpdate1;
        Inventory Inventory1;
        Barcode Barcode1;
        ProducerIncomplete ProducerIncomplete1;
        StoreToStore StoreToStore1;
        ProductMovement ProductMovement1;
        BoxMovement BoxMovement1;
        ClientsList ClientsList1;
        BanksList BanksList1;
        Profits Profits1;
        DailySalesPurchases DailySalesPurchases1;
        DailyTransactions DailyTransactions1;
        FinancialStatements FinancialStatements1;
        BankAddAccount BankAddAccount1;

        CheckSaderWared CheckSaderWared1;
        CheckSave CheckSave1;
        BankStatement BankStatement1;
        BankToBank BankToBank1;
        ClientAccountStatement ClientAccountStatement1;
        ClientAddFrist ClientAddFrist1;
        MoneyWaredAndSaderOther MoneyWaredAndSaderOther1;
        ProducerMake ProducerMake1;
        ClientsMoneyToClients ClientsMoneyToClients1;
        MaterialsAdd MaterialsAdd;
        Installment Installment1;
        TypeProgram TypeProgram1;
        CategoryGroup CategoryGroup1;
        Events Events1;
        DailyClosing DailyClosing1;
        VersionNew VersionNew1;
        FactionCategoreyAdd FactionCategoreyAdd1;
        Statistical Statistical1;
        ProducerAddSN ProducerAddSN1;
        ProducerAddBarcodeFactory ProducerAddBarcodeFactory1;
        OsolSabta OsolSabta1;
        TermsandConditions TermsandConditions1;
        FrmBillingSummary FrmBillingSummary1;
        PriceViewer PriceViewer1;

        OccasionsForm OccasionsForm1; //---------المناسبات

        public Main()
        {
            InitializeComponent();
            sqlCommand1.Connection = sqlConnection1;

            


            occasionDAL = new OccasionDAL(constring);


            textUserName1.Text = AppSetting.user;

            labelVersion.Text = Properties.Settings.Default.Version;

            string version = Properties.Settings.Default.Version; //   يقرا من الخصائص نوع نسخة البرنامج لايت - احترافى - متكامل
            DataName = Properties.Settings.Default.DataName; // يقرا اسم الداتا بيز من الخصائص

            labelDataBaseName.Text=Properties.Settings.Default.DataName; // يقرا اسم الداتا بيز من الخصائص

           

            if (version == "Lite")
            {
                
              //  panlMenu.Visible = true;

                TsmStoreToStore.Visible = false;
                TsmBarcode.Visible = false;
                TsmOtherExpensesRevenues.Visible = false;
                شئونموظفينToolStripMenuItem.Visible = false;
                TsmInstallment.Visible = false;
                toolStripMenuItem1.Visible = false;
                سياراتToolStripMenuItem1.Visible = false;
                TsmFinancialStatements.Visible = false;
                المستخدمينToolStripMenuItem1.Visible = false;
                البنوكToolStripMenuItem.Visible = false;

                


            }
            else if (version == "Professional")
            {

                //TsmStoreToStore.Visible = false;
                //TsmBarcode.Visible = false;
                //ToolStrip_CategoryOthers.Visible = false;
                شئونموظفينToolStripMenuItem.Visible = false;
                البنوكToolStripMenuItem.Visible = false;
                //TsmInstallment.Visible = false;
                //toolStripMenuItem1.Visible = false;
                //سياراتToolStripMenuItem1.Visible = false;
                //TsmFinancialStatements.Visible = false;
                //المستخدمينToolStripMenuItem1.Visible = false;


             //   panlMenu.Visible = true;

            }
            else if (version == "Enterprise")
            {
                
             //   panlMenu.Visible = true;

            }


            string Demo = Properties.Settings.Default.Demo; //يقرا من الخصائص نوع نسخة البرنامج تجربى ام لا
            if (Demo == "")
            { }
            else if (Demo == "no")
            {
                //TsmLicense.Enabled = true;

            }
            else if (Demo == "yes")
            {
                نسخةتجريبيةToolStripMenuItem.Visible = true;
                //TsmLicense.Enabled = false;
            }


                //if(Demo=="")
                //{
                //    //----- نختار نوع النسخة تجريبية او اصلية
                //    //MessageBox.Show("  اختار نسختك   ", "اختار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    if (TypeProgram1 == null || TypeProgram1.IsDisposed == true)
                //    {
                //        //TransferData.CodePrograms = Get_Procces_ID();
                //        TypeProgram1 = new TypeProgram();
                //    }
                //    //Altarkhes.MdiParent = this;
                //    TypeProgram1.ShowDialog();


                //    Application.Exit();
                //    this.Close();
                //}
                //else if(Demo=="yes")
                //{
                //    //--- يفتح بدون ترخيص مع تفعيل كود الفترة التجريبية

                //    //MessageBox.Show("  فترة تجريبية", "تجريبى", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    //----------------------- الفترة التجريبية -------------
                //    try
                //    {
                //        sqlCommand1.Connection = sqlConnection1;


                //        نسخةتجريبيةToolStripMenuItem.Visible = true;

                //        string NumBill = "0";
                //        sqlConnection1.Open();

                //        sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
                //        red = sqlCommand1.ExecuteReader();
                //        while (red.Read())
                //        {
                //            double s = Convert.ToDouble(red["NumBill"].ToString());
                //            double aa = s + 1;
                //            NumBill = aa.ToString();


                //        }
                //        red.Close();
                //        sqlConnection1.Close();
                //       //  =============== فترة تجريبية ===================
                //        double asa = Convert.ToDouble(NumBill);

                //        if (asa >= 100)
                //        {
                //            //if (Altarkhes == null || Altarkhes.IsDisposed == true)
                //            //{
                //            //    Altarkhes = new الترخيص();
                //            //}
                //            ////Altarkhes.MdiParent = this;
                //            //Altarkhes.ShowDialog();

                //            MessageBox.Show("    نأسف تم انتهاء الفترة التجريبية اتصل بنا على 01224349933     ", "الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //            Application.Exit();
                //            this.Close();
                //        }
                //        else
                //        {

                //        }
                //    }
                //    catch
                //    { }

                //}
                //else if(Demo=="no")
                //{
                //    // --- نضع هنا كود الترخيص

                //    //============================ ترخيص البرنامج =============================

                //    string texthddserial = Properties.Settings.Default.sn; //يقرا من الخصائص
                //                                                           //string texthddserial1 = "";



                //    //****** يقرا من ملف *****************
                //    //StreamReader sr = new StreamReader(@".\zh.txt");
                //    //string hddsrial = sr.ReadLine();
                //    //texthddserial = hddsrial;
                //    //*****************************************


                //    //****** HDD SERIALNUMBER ايجار رقم الهارد*****************

                //    //ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
                //    //dsk.Get();
                //    //string id = dsk["VolumeSerialNumber"].ToString();
                //    //texthddserial1 = "H2646MHM545E." + id.ToString() + ".H2646MHM545E";

                //    //**************  ايجاد الماك ادرس******************

                //    //texthddserial1 = "H2646MHM545E." + GetMacAddress().ToString() + ".H2646MHM545E";

                //    //*********************************************


                //    texthddserial1 = Tashfer.Get_Procces_ID();
                //    texthddserial1 = "ZAD-" + texthddserial1.Remove(5) + "-" + texthddserial1.Substring(5, 5).ToUpper();

                //    texthddserial1 = Tashfer.Get_Tashfer(texthddserial1);

                //    if (texthddserial == texthddserial1)
                //    {

                //        //sqlConnection1.Open();
                //        sqlCommand1.Connection = sqlConnection1;
                //        textUserName.Focus();


                //        //----------- اختبار الداتا بيز موجودة ولا لا
                //        //string DBname = "nnnn";
                //        //string ServerName = @".\SQLEXPRESS";
                //        //SqlConnection conDB = new SqlConnection(@"Data Source='" + ServerName + "';Initial Catalog=master;Integrated Security=True;");
                //        //if (conDB.State == ConnectionState.Closed)
                //        //    conDB.Open();
                //        //SqlCommand com = new SqlCommand("select count(*) from sys.databases WHERE name='" + DBname + "'", conDB);
                //        //if (((int)com.ExecuteScalar()) == 0)
                //        //{
                //        //    if (Connection1 == null || Connection1.IsDisposed == true)
                //        //    {
                //        //        Connection1 = new Connection();
                //        //    }
                //        //    Connection1.MdiParent = this;
                //        //    Connection1.Show();
                //        //}

                //        //else
                //        //{
                //        //    MessageBox.Show("  الداتا بيز موجودة من قبل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        //}
                //    }
                //    else
                //    {
                //        if (License1 == null || License1.IsDisposed == true)
                //        {
                //            //TransferData.CodePrograms = Get_Procces_ID();
                //            License1 = new License();
                //        }
                //        //Altarkhes.MdiParent = this;
                //        License1.ShowDialog();
                //    }

                //    //===================== نهاية الترخيص ===============================================
                //}

            }
      //----- ايجاد صلاحيات المستخدم
        public void User_Powers()
        {
            //RemoveChBox();
            //string TestBasswordUser = "0";
            //string TestIdUser = "0";
            //string Sales = "0";
            //string Purchases = "0";
            //string Expenses = "0";
            //string MoneyToBox = "0";
            //string MoneyFromBox = "0";
            //string GroupAdd = "0";
            //string EmployeeAdd = "0";
            //string EmployeeSalaryPayment = "0";
            //string EmployeeSalaryMovement = "0";
            //string EmployeeBonusAdd = "0";
            //string EmployeePenaltyAdd = "0";
            //string CarsAdd = "0";
            //string CarsExpenses = "0";
            //string CarsExpensesMovement = "0";
            //string BackupSave = "0";
            //string BackupRestore = "0";
            //string SettingsGeneral = "0";
            //string SystemReset = "0";
            //string License = "0";
            //string CallUs = "0";
            //string ClientAdd = "0";
            //string ClientsMoney = "0";
            //string ExplainSystem = "0";
            //string Connection = "0";
            //string ProducerNewAdd = "0";
            //string StoreNewAdd = "0";
            //string Prices = "0";
            //string ProducerUpdate = "0";
            //string Inventory = "0";
            //string Barcode = "0";
            //string ProducerIncomplete = "0";
            //string StoreToStore = "0";
            //string ProductMovement = "0";
            //string BoxMovement = "0";
            //string ClientsList = "0";
            //string BanksList = "0";
            //string Profits = "0";
            //string DailySalesPurchases = "0";
            //string DailyTransactions = "0";
            //string FinancialStatements = "0";
            //string BankAddAccount = "0";
            //string CheckSaderWared = "0";
            //string CheckSave = "0";
            //string BankStatement = "0";
            //string BankToBank = "0";
            //string ClientAccountStatement = "0";
            //string UserAdd1 = "0";

            //string FirstAccounts = "0";
            //string b = "0";
            //string c = "0";
            //string d = "0";
            //string g = "0";

            string TestBasswordUser = AppSetting.TestBasswordUser;
            string TestIdUser = AppSetting.TestIdUser;
            string Sales = AppSetting.Sales;
            string Purchases = AppSetting.Purchases;
            string Expenses = AppSetting.Expenses;
            string MoneyToBox = AppSetting.MoneyToBox;
            string MoneyFromBox = AppSetting.MoneyFromBox;
            string GroupAdd = AppSetting.GroupAdd;
            string EmployeeAdd = AppSetting.EmployeeAdd;
            string EmployeeSalaryPayment = AppSetting.EmployeeSalaryPayment;
            string EmployeeSalaryMovement = AppSetting.EmployeeSalaryMovement;
            string EmployeeBonusAdd = AppSetting.EmployeeBonusAdd;
            string EmployeePenaltyAdd = AppSetting.EmployeePenaltyAdd;
            string CarsAdd = AppSetting.CarsAdd;
            string CarsExpenses = AppSetting.CarsExpenses;
            string CarsExpensesMovement = AppSetting.CarsExpensesMovement;
            string BackupSave = AppSetting.BackupSave;
            string BackupRestore = AppSetting.BackupRestore;
            string SettingsGeneral = AppSetting.SettingsGeneral;
            string SystemReset = AppSetting.SystemReset;
            string License = AppSetting.License;
            string CallUs = AppSetting.CallUs;
            string ClientAdd = AppSetting.ClientAdd;
            string ClientsMoney = AppSetting.ClientsMoney;
            string ExplainSystem = AppSetting.ExplainSystem;
            string Connection = AppSetting.Connection;
            string ProducerNewAdd = AppSetting.ProducerNewAdd;
            string StoreNewAdd = AppSetting.StoreNewAdd;
            string Prices = AppSetting.Prices;
            string ProducerUpdate = AppSetting.ProducerUpdate;
            string Inventory = AppSetting.Inventory;
            string Barcode = AppSetting.Barcode;
            string ProducerIncomplete = AppSetting.ProducerIncomplete;
            string StoreToStore = AppSetting.StoreToStore;
            string ProductMovement = AppSetting.ProductMovement;
            string BoxMovement = AppSetting.BoxMovement;
            string ClientsList = AppSetting.ClientsList;
            string BanksList = AppSetting.BanksList;
            string Profits = AppSetting.Profits;
            string DailySalesPurchases = AppSetting.DailySalesPurchases;
            string DailyTransactions = AppSetting.DailyTransactions;
            string FinancialStatements = AppSetting.FinancialStatements;
            string BankAddAccount = AppSetting.BankAddAccount;
            string CheckSaderWared = AppSetting.CheckSaderWared;
            string CheckSave = AppSetting.CheckSave;
            string BankStatement = AppSetting.BankStatement;
            string BankToBank = AppSetting.BankToBank;
            string ClientAccountStatement = AppSetting.ClientAccountStatement;
            string UserAdd1 = AppSetting.UserAdd1;
            string Statistical = AppSetting.Statistical;
            string FirstAccounts = AppSetting.FirstAccounts;
            string b = AppSetting.b ;
            string c = AppSetting.c ;
            string d = AppSetting.d ;
            string g = AppSetting.g ;


            


              //  AppSetting.user = textUserName.Text;// حفظ اسم المستخدم

                if (FirstAccounts == "1")
                {
                    TsmFirstAccounts.Enabled = true;
                    
                }
                
                if (Statistical == "1")
                {

                    TsmStatistical.Enabled = true;
                    
                } 

                if (Sales == "1")
                {
                    TsmSales.Enabled = true;
                    TsmSalesReturns.Enabled = true;
                    TsmPurchaseReturns.Enabled = true;
                    TsmOtherExpensesRevenues.Enabled = true;
                    TsmBarcode.Enabled = true;
                    TsmProducerIncomplete.Enabled = true;
                }
                if (Purchases == "1")
                {
                    TsmPurchases.Enabled = true;
                }

                if (Expenses == "1")
                {
                    TsmExpenses.Enabled = true;
                }
                if (Sales == "1")
                {
                    TsmSales.Enabled = true;
                }
                if (Purchases == "1")
                {
                    TsmPurchases.Enabled = true;
                }
                if (Expenses == "1")
                {
                    TsmExpenses.Enabled = true;
                }
                if (MoneyToBox == "1")
                {
                    TsmMoneyToBox.Enabled = true;
                }
                if (MoneyFromBox == "1")
                {
                    TsmMoneyFromBox.Enabled = true;
                }
                if (GroupAdd == "1")
                {
                    TsmGroupAdd.Enabled = true;
                }
                if (EmployeeAdd == "1")
                {
                    TsmEmployeeAdd.Enabled = true;
                }
                if (EmployeeSalaryPayment == "1")
                {
                    TsmEmployeeSalaryPayment.Enabled = true;
                }
                if (EmployeeSalaryMovement == "1")
                {
                    TsmEmployeeSalaryMovement.Enabled = true;
                }
                if (EmployeeBonusAdd == "1")
                {
                    TsmEmployeeBonusAdd.Enabled = true;
                }
                if (EmployeePenaltyAdd == "1")
                {
                    TsmEmployeePenaltyAdd.Enabled = true;
                }
                if (CarsAdd == "1")
                {
                    TsmCarsAdd.Enabled = true;
                }
                if (CarsExpenses == "1")
                {
                    TsmCarsExpenses.Enabled = true;
                }
                if (CarsExpensesMovement == "1")
                {
                    TsmCarsExpensesMovement.Enabled = true;
                }
            if (BackupSave == "1")
            {
                TsmBackupSave.Enabled = true;

                ////----------------------- Backup -------------
                //try
                //{
                //    //SaveFileDialog sf = new SaveFileDialog();
                //    //sf.Filter = "Backup Files(*.Bak)|*.bak";
                //    if (BathBackup != "")
                //    {
                //        //---- Delete backup Old
                //        File.Delete(BathBackup);

                //        //--------- Creat Backup New
                //        sqlCommand1 = new SqlCommand("Backup Database ZAD To Disk='" + BathBackup + "'", sqlConnection1);
                //        sqlConnection1.Open();
                //        sqlCommand1.ExecuteNonQuery();
                //        sqlConnection1.Close();

                //        //  MessageBox.Show("       تم أخذ نسخة إحتياطية بنجاح    ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //catch (Exception b)
                //{
                //    MessageBox.Show(b.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //}
            }
                if (BackupRestore == "1")
                {
                    TsmBackupRestore.Enabled = true;
                }
                if (SettingsGeneral == "1")
                {
                    TsmSettingsGeneral.Enabled = true;
                }
                if (SystemReset == "1")
                {
                    TsmSystemReset.Enabled = true;
                }
                if (License == "1")
                {
                    //TsmLicense.Enabled = true;
                }
                if (CallUs == "1")
                {
                    //TsmCallUs.Enabled = true;
                }
                if (ClientAdd == "1")
                {
                    TsmAddClient.Enabled = true;
                }
                if (ClientsMoney == "1")
                {
                    TsmClientsMoneyFrom.Enabled = true;
                    TsmClientsMoneyTo.Enabled = true;
                }
                if (ExplainSystem == "1")
                {
                    //TsmExplainSystem.Enabled = true;
                }
                if (Connection == "1")
                {
                    //TsmConnection.Enabled = true;
                }
                if (ProducerNewAdd == "1")
                {
                    TsmProducerNewAdd.Enabled = true;
                }
                if (StoreNewAdd == "1")
                {
                    TsmStoreNewAdd.Enabled = true;
                }
                if (Prices == "1")
                {
                    TsmPrices.Enabled = true;
                }
                if (ProducerUpdate == "1")
                {
                    TsmProducerUpdate.Enabled = true;
                }
                if (Inventory == "1")
                {
                    TsmInventory.Enabled = true;
                }
                if (Barcode == "1")
                {
                    //TsmBarcode.Enabled = true;
                }
                if (ProducerIncomplete == "1")
                {
                    //TsmProducerIncomplete.Enabled = true;
                }
                if (StoreToStore == "1")
                {
                    TsmStoreToStore.Enabled = true;
                }
                if (ProductMovement == "1")
                {
                    TsmProductMovement.Enabled = true;
                }
                if (BoxMovement == "1")
                {
                    TsmBoxMovement.Enabled = true;
                }
                if (ClientsList == "1")
                {
                    TsmClientsList.Enabled = true;
                }
                if (BanksList == "1")
                {
                    TsmBanksList.Enabled = true;
                }
                if (Profits == "1")
                {
                    TsmProfits.Enabled = true;
                }
                if (DailySalesPurchases == "1")
                {
                    TsmDailySalesPurchases.Enabled = true;
                }
                if (DailyTransactions == "1")
                {
                    TsmDailyTransactions.Enabled = true;
                }
                if (FinancialStatements == "1")
                {
                    TsmFinancialStatements.Enabled = true;
                }
                if (BankAddAccount == "1")
                {
                    TsmBankAddAccount.Enabled = true;
                }
                if (CheckSaderWared == "1")
                {
                    //TsmCheckSaderWared.Enabled = true;
                    TsmCheckSaderAll.Enabled = true;
                    TsmCheckWaredAll.Enabled = true;
                    
                }
                if (CheckSave == "1")
                {
                    //TsmCheckSave.Enabled = true;
                    TsmCheckAddALL.Enabled = true;
                    TsmCheckDiscALL.Enabled = true;
                }

                if (BankStatement == "1")
                {
                    TsmBankStatement.Enabled = true;
                }

                if (BankToBank == "1")
                {
                    TsmBankToBank.Enabled = true;
                }

                if (ClientAccountStatement == "1")
                {
                    TsmClientAccountStatement.Enabled = true;
                }
                if (UserAdd1 == "1")
                {
                    TsmUserAdd.Enabled = true;
                }

                panelUser.Visible = false;
          


        }
        public void GetValueMonth999()// متغيرات محتاجة تظبيط
        {
            sqlConnection1.Open();


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

            string month = dateTimePicker1.Value.ToString("MM");
            string year = dateTimePicker1.Value.ToString("yyyy");
            dateTimePicker2.Text = "01/" + month + "/" + year;
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

            //string month = dateTimePicker1.Value.ToString("MM");
            //string year = dateTimePicker1.Value.ToString("yyyy");
            //dateTimePicker2.Text = "01/" + month + "/" + year;


         
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

                //sqlCommand1.CommandText = "insert into ProjectTotal (Month,Year,Date,StoreValue,CustomerValue,BoxValue,Profits,DailyExpenses,AdvExpenses,SeianaExpenses,RentExpenses,ElectricityExpenses,WaterExpenses,PhoneExpenses,InternetExpenses,CarExpenses,Salaries,WithdrawProfits,TotalExpenses,PurchasingExpenses,AddMoneyBox,DiscMoneyBox,Sales,DiscSales,Purchases,DiscPurchases,PurchaseReturns,SalesReturns,Taweredat,Tahselat)values ('" + textMonth.Text + "','" + textYear.Text + "','" + textDateMonth.Text + "','" + textValueMonth.Text + "','" + textClientValue.Text + "','" + textBoxMoney.Text + "','" + textProfits.Text + "','" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "')";
                //    sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "insert into ProjectTotal (Month,Year,Date,StoreValue,CustomerValue,BoxValue,Profits,DailyExpenses,AdvExpenses,SeianaExpenses,RentExpenses,ElectricityExpenses,WaterExpenses,PhoneExpenses,InternetExpenses,CarExpenses,Salaries,WithdrawProfits,TotalExpenses,PurchasingExpenses,AddMoneyBox,DiscMoneyBox,Sales,DiscSales,Purchases,DiscPurchases,PurchaseReturns,SalesReturns,Taweredat,Tahselat)values ('" + Month + "', '" + Year + "', '" + DateMonth + "', '" + ValueMonth + "', '" + ClientValue + "', '" + BoxMoney + "', '" + Profits + "', '" + Nathria + "', '" + Advs + "', '" + Seiana + "', '" + Egar + "', '" + Kahraba + "', '" + Water + "', '" + Tell + "', '" + Net + "', '" + Cars + "', '" + 0 + "', '" + text_Arbah + "', '" + TotalMasrofat2 + "', '" + Moshtriat+ "', '" + textWaredMoney.Text + "', '" + textSadreMoney.Text + "', '" + TotalBill + "', '" + Discount + "', '" + MoshtriaatTotal + "', '" + DiscountBuy + "', '" + TotalBillInvalid + "', '" + TotalBillBuyInvalid + "', '" + Pay + "', '" + Paid + "')";
                sqlCommand1.ExecuteNonQuery();

            MessageBox.Show("   الحمد لله لقد تم إضافةالبيانات    ", "  إضافه ");
        }
            catch
            {
             //('" + Month + "', '" + Year + "', '" + DateMonth + "', '" + ValueMonth + "', '" + ClientValue + "', '" + BoxMoney + "', '" + Profits + "', '" + Nathria + "', '" + Advs + "', '" + Seiana + "', '" + Egar + "', '" + Kahraba + "', '" + Water + "', '" + Tell + "', '" + Net + "', '" + Cars + "', '" + 0 + "', '" + text_Arbah + "', '" + TotalMasrofat2 + "', '" + Moshtriat+ "', '" + textWaredMoney.Text + "', '" + textSadreMoney.Text + "', '" + TotalBill + "', '" + Discount + "', '" + MoshtriaatTotal + "', '" + DiscountBuy + "', '" + TotalBillInvalid + "', '" + TotalBillBuyInvalid + "', '" + Pay + "', '" + Paid + "')
                sqlCommand1.CommandText = "update ProjectTotal set  StoreValue='" + ValueMonth + "',CustomerValue='" + ClientValue + "',BoxValue = '" + BoxMoney + "',Profits = '" + Profits + "',DailyExpenses='" + Nathria + "',AdvExpenses='" + Advs + "',SeianaExpenses='" + Seiana + "',RentExpenses='" + Egar + "',ElectricityExpenses='" + Kahraba + "',WaterExpenses='" + Water + "',PhoneExpenses='" + Tell + "',InternetExpenses='" + Net + "',CarExpenses='" + Cars + "',Salaries='" + 0 + "',WithdrawProfits='" + text_Arbah + "',TotalExpenses='" + TotalMasrofat2 + "',PurchasingExpenses='" + Moshtriat + "',AddMoneyBox='" + textWaredMoney.Text + "',DiscMoneyBox='" + textSadreMoney.Text + "',Sales='" + TotalBill + "',DiscSales='" + Discount + "',Purchases='" + MoshtriaatTotal + "',DiscPurchases='" + DiscountBuy + "',SalesReturns='" + TotalBillInvalid + "',PurchaseReturns='" + TotalBillBuyInvalid + "',Taweredat='" + Pay + "',Tahselat='" + Paid + "' where  Date ='" + textDateMonth.Text + "' ";
                sqlCommand1.ExecuteNonQuery();



                MessageBox.Show("             تم تحديث البيانات الشهرية                 ", "  البيانات الشهرية ");
            }


    //============================================

    sqlConnection1.Close();



        }

        public void GetValueMonth()
        {
            string month = dateTimePicker1.Value.ToString("MM");
            string year = dateTimePicker1.Value.ToString("yyyy");
            dateTimePicker2.Text = "01/" + month + "/" + year;


            if (sqlConnection1.State == ConnectionState.Open)
            {
                sqlConnection1.Close();
            }

            sqlConnection1.Open();

            

            //============================================

            textMonth.Text = dateTimePicker1.Value.ToString("MM");
            textYear.Text = dateTimePicker1.Value.ToString("yyyy");

            textDateMonth.Text = textMonth.Text + "-" + textYear.Text;

            //======================== تحديث اجمالى البضاعه شراء فى الداتا بيز  ====================

            sqlCommand1.CommandText = "update Category set  Value=Total*Price ";
            sqlCommand1.ExecuteNonQuery();

            //======================= اجمالى البضاعه الحالية ======================

            sqlCommand1.CommandText = "select ISNULL(SUM(Total*Price),0) as ValueShera From Category   ";
            rred = sqlCommand1.ExecuteReader();
            while (rred.Read())
            {
                string ValueShera = rred["ValueShera"].ToString();

                textValueMonth.Text = Math.Round(double.Parse(ValueShera), 0).ToString();

            }
            rred.Close();

            //--------- المبيعات والمشتريات -------------

            String d2 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            String d3 = dateTimePicker3.Value.ToString("MM/dd/yyyy");
            sqlCommand1.CommandText = "select ISNULL(SUM(TotalBill),0) as TotalBill,ISNULL(SUM(Discount),0) as Discount,ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy,ISNULL(SUM(DiscountBuy),0) as DiscountBuy,ISNULL(SUM(TotalBillInvalid),0) as TotalBillInvalid,ISNULL(SUM(TotalBillBuyInvalid),0) as TotalBillBuyInvalid,ISNULL(SUM(Creditor),0) as Creditor,ISNULL(SUM(Adding),0) as Adding,ISNULL(SUM(Pay),0) as Pay,ISNULL(SUM(Paid),0) as Paid From BillingData  where   Date >= '" + d2 + "' and Date <= '" + d3 + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                string TotalBill = reed["TotalBill"].ToString();
                string Discount = reed["Discount"].ToString();
                string DiscountBuy = reed["DiscountBuy"].ToString();
                string TotalBillInvalid = reed["TotalBillInvalid"].ToString();
                string TotalBillBuyInvalid = reed["TotalBillBuyInvalid"].ToString();
                string Creditor = reed["Creditor"].ToString();
                string Adding = reed["Adding"].ToString();
                string Pay = reed["Pay"].ToString();
                string Paid = reed["Paid"].ToString();

                textMabeaat.Text = Math.Round(double.Parse(TotalBill), 0).ToString();
                textDiscMabeaat.Text = Math.Round(double.Parse(Discount), 0).ToString();
                textDisSheraa.Text = Math.Round(double.Parse(DiscountBuy), 0).ToString();
                textHalekBeeea.Text = Math.Round(double.Parse(TotalBillInvalid), 0).ToString();
                textHaleksheraa.Text = Math.Round(double.Parse(TotalBillBuyInvalid), 0).ToString();
                textTawreed.Text = Math.Round(double.Parse(Pay), 0).ToString();
                textTahseel.Text = Math.Round(double.Parse(Paid), 0).ToString();

                //textMabeaat.Text = TotalBill;
                //textDiscMabeaat.Text = Discount;
                //textDisSheraa.Text = DiscountBuy;
                //textHalekBeeea.Text = TotalBillInvalid;
                //textHaleksheraa.Text = TotalBillBuyInvalid;
                //textTawreed.Text = Pay;
                //textTahseel.Text = Paid;


            }
            reed.Close();

            //------------------ ايجاد قيمة المشتريات بدون بضاعة اول المدة 

            string Moveee = "فاتورة مشتريات";

            sqlCommand1.CommandText = "Select ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy From BillingData Where  Move like '" + Moveee + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMoshtriaatTotal.Text = reed["TotalBillBuy"].ToString();

                textMoshtriaatTotal.Text = Math.Round(double.Parse(textMoshtriaatTotal.Text), 0).ToString();
            }
            reed.Close();

            //======================= المصروفات ===============================

            //------------ ايجاد مصاريف السيارات

            sqlCommand1.CommandText = "Select ISNULL(SUM(Total),0) as Total From SearchCar Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textCars.Text = reed["Total"].ToString();
                textCars.Text = Math.Round(double.Parse(textCars.Text), 0).ToString();


            }
            reed.Close();

            //-------------------------------- مصاريف مشتريات ----------------------------------
            string Masrofat = "مصاريف مشتريات";
            textMoshtriat.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMoshtriat.Text = reed["Paid"].ToString();
                textMoshtriat.Text = Math.Round(double.Parse(textMoshtriat.Text), 2).ToString();



            }
            reed.Close();
            //-------------------------------- مصاريف نثرية ----------------------------------
            string Masrofat1 = "مصاريف نثريه";
            textNathria.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat1 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textNathria.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف دعاية ----------------------------------
            string Masrofat2 = "مصاريف دعاية";
            textAdvs.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat2 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textAdvs.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف صيانه ----------------------------------
            string Masrofat3 = "مصاريف صيانة";
            textSeiana.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat3 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textSeiana.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف ايجار ----------------------------------
            string Masrofat4 = "مصاريف ايجار";
            textEgar.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat4 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textEgar.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف كهرباء ----------------------------------
            string Masrofat5 = "فاتورة كهرباء";
            textKahraba.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat5 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textKahraba.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف مياه ----------------------------------
            string Masrofat6 = "فاتورة مياه";
            textWater.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat6 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textWater.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف تليفون ----------------------------------
            string Masrofat7 = "فاتورة تليفون";
            textTell.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat7 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textTell.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف انترنت ----------------------------------
            string Masrofat8 = "فاتورة انترنت";
            textNet.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat8 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textNet.Text = reed["Paid"].ToString();


            }
            reed.Close();

            //-------------------------------- الارباح المسحوبة ----------------------------------
            string Masrofat10 = "سحب ارباح";
            textNet.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat10 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                text_Arbah.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //--------------------------------   اجمالى المصاريف بدون مصاريف الشراء و سحب ارباح ----------------------------------
            string Masrofat9 = "مصاريف مشتريات";
            string Masrofat999 = "سحب ارباح";
            textTotalMasrofat2.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move != '" + Masrofat999 + "' and move != '" + Masrofat9 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textTotalMasrofat2.Text = reed["Paid"].ToString();


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

                textClientValue.Text = rred["PreviousBalance"].ToString();

                textClientValue.Text = Math.Round(double.Parse(textClientValue.Text), 0).ToString();
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

            textBoxMoney.Text = Math.Round(double.Parse(rr.ToString()), 0).ToString();

            //============================================

            //string month = dateTimePicker1.Value.ToString("MM");
            //string year = dateTimePicker1.Value.ToString("yyyy");
            //dateTimePicker2.Text = "01/" + month + "/" + year;

            sqlCommand1.CommandText = "select SUM(Profit) as Profit From Profit  where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {

                textProfits.Text = red["Profit"].ToString();

            }
            red.Close();

            try
            {
                textProfits.Text = Math.Round(double.Parse(textProfits.Text), 0).ToString();
            }
            catch
            { }

            //============================================
         //   MessageBox.Show("  تم التحديث   ", "    اجمالى المصاريف = '" + textTotalMasrofat2.Text + "'  ");

            try
            {
                sqlCommand1.CommandText = "insert into ProjectTotal (Month,Year,Date,StoreValue,CustomerValue,BoxValue,Profits,DailyExpenses,AdvExpenses,SeianaExpenses,RentExpenses,ElectricityExpenses,WaterExpenses,PhoneExpenses,InternetExpenses,CarExpenses,Salaries,WithdrawProfits,TotalExpenses,PurchasingExpenses,AddMoneyBox,DiscMoneyBox,Sales,DiscSales,Purchases,DiscPurchases,PurchaseReturns,SalesReturns,Taweredat,Tahselat)values ('" + textMonth.Text + "','" + textYear.Text + "','" + textDateMonth.Text + "','" + textValueMonth.Text + "','" + textClientValue.Text + "','" + textBoxMoney.Text + "','" + textProfits.Text + "','" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah.Text + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //'" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah.Text + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "',
                MessageBox.Show("   الحمد لله لقد تم إضافةالبيانات    ", "  إضافه ");
            }
            catch
            {
                sqlCommand1.CommandText = "update ProjectTotal set  StoreValue='" + textValueMonth.Text + "',CustomerValue='" + textClientValue.Text + "',BoxValue = '" + textBoxMoney.Text + "',Profits = '" + textProfits.Text + "',DailyExpenses='" + textNathria.Text + "',AdvExpenses='" + textAdvs.Text + "',SeianaExpenses='" + textSeiana.Text + "',RentExpenses='" + textEgar.Text + "',ElectricityExpenses='" + textKahraba.Text + "',WaterExpenses='" + textWater.Text + "',PhoneExpenses='" + textTell.Text + "',InternetExpenses='" + textNet.Text + "',CarExpenses='" + textCars.Text + "',Salaries='" + textMortabat.Text + "',WithdrawProfits='" + text_Arbah.Text + "',TotalExpenses='" + textTotalMasrofat2.Text + "',PurchasingExpenses='" + textMoshtriat.Text + "',AddMoneyBox='" + textWaredMoney.Text + "',DiscMoneyBox='" + textSadreMoney.Text + "',Sales='" + textMabeaat.Text + "',DiscSales='" + textDiscMabeaat.Text + "',Purchases='" + textMoshtriaatTotal.Text + "',DiscPurchases='" + textDisSheraa.Text + "',SalesReturns='" + textHalekBeeea.Text + "',PurchaseReturns='" + textHaleksheraa.Text + "',Taweredat='" + textTawreed.Text + "',Tahselat='" + textTahseel.Text + "' where  Date ='" + textDateMonth.Text + "' ";
                sqlCommand1.ExecuteNonQuery();


             //   MessageBox.Show("             تم تحديث البيانات الشهرية                 ", "  البيانات الشهرية ");
            }


            //============================================

            sqlConnection1.Close();
        }//------ شغال


        public void GetValueMonth44()
        {
            string month = dateTimePicker1.Value.ToString("MM");
            string year = dateTimePicker1.Value.ToString("yyyy");
            dateTimePicker2.Text = "01/" + month + "/" + year;
            sqlConnection1.Open();

            //============================================

            string Month  = dateTimePicker1.Value.ToString("MM");
            string Year = dateTimePicker1.Value.ToString("yyyy");

            string DateMonth = textMonth.Text + "-" + textYear.Text;

            //======================== تحديث اجمالى البضاعه شراء فى الداتا بيز  ====================

            sqlCommand1.CommandText = "update Category set  Value=Total*Price ";
            sqlCommand1.ExecuteNonQuery();

            //======================= اجمالى البضاعه الحالية ======================

            sqlCommand1.CommandText = "select ISNULL(SUM(Total*Price),0) as ValueShera From Category   ";
            rred = sqlCommand1.ExecuteReader();
            while (rred.Read())
            {
                string ValueShera = rred["ValueShera"].ToString();

                textValueMonth.Text = Math.Round(double.Parse(ValueShera), 0).ToString();

            }
            rred.Close();

            //--------- المبيعات والمشتريات -------------


            sqlCommand1.CommandText = "select ISNULL(SUM(TotalBill),0) as TotalBill,ISNULL(SUM(Discount),0) as Discount,ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy,ISNULL(SUM(DiscountBuy),0) as DiscountBuy,ISNULL(SUM(TotalBillInvalid),0) as TotalBillInvalid,ISNULL(SUM(TotalBillBuyInvalid),0) as TotalBillBuyInvalid,ISNULL(SUM(Creditor),0) as Creditor,ISNULL(SUM(Adding),0) as Adding,ISNULL(SUM(Pay),0) as Pay,ISNULL(SUM(Paid),0) as Paid From BillingData  where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                string TotalBill = reed["TotalBill"].ToString();
                string Discount = reed["Discount"].ToString();
                string DiscountBuy = reed["DiscountBuy"].ToString();
                string TotalBillInvalid = reed["TotalBillInvalid"].ToString();
                string TotalBillBuyInvalid = reed["TotalBillBuyInvalid"].ToString();
                string Creditor = reed["Creditor"].ToString();
                string Adding = reed["Adding"].ToString();
                string Pay = reed["Pay"].ToString();
                string Paid = reed["Paid"].ToString();

                textMabeaat.Text = Math.Round(double.Parse(TotalBill), 0).ToString();
                textDiscMabeaat.Text = Math.Round(double.Parse(Discount), 0).ToString();
                textDisSheraa.Text = Math.Round(double.Parse(DiscountBuy), 0).ToString();
                textHalekBeeea.Text = Math.Round(double.Parse(TotalBillInvalid), 0).ToString();
                textHaleksheraa.Text = Math.Round(double.Parse(TotalBillBuyInvalid), 0).ToString();
                textTawreed.Text = Math.Round(double.Parse(Pay), 0).ToString();
                textTahseel.Text = Math.Round(double.Parse(Paid), 0).ToString();

                //textMabeaat.Text = TotalBill;
                //textDiscMabeaat.Text = Discount;
                //textDisSheraa.Text = DiscountBuy;
                //textHalekBeeea.Text = TotalBillInvalid;
                //textHaleksheraa.Text = TotalBillBuyInvalid;
                //textTawreed.Text = Pay;
                //textTahseel.Text = Paid;


            }
            reed.Close();

            //------------------ ايجاد قيمة المشتريات بدون بضاعة اول المدة 

            string Moveee = "فاتورة مشتريات";

            sqlCommand1.CommandText = "Select ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy From BillingData Where  Move like '" + Moveee + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMoshtriaatTotal.Text = reed["TotalBillBuy"].ToString();

                textMoshtriaatTotal.Text = Math.Round(double.Parse(textMoshtriaatTotal.Text), 0).ToString();
            }
            reed.Close();

            //======================= المصروفات ===============================

            //------------ ايجاد مصاريف السيارات

            sqlCommand1.CommandText = "Select ISNULL(SUM(Total),0) as Total From SearchCar Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textCars.Text = reed["Total"].ToString();
                textCars.Text = Math.Round(double.Parse(textCars.Text), 0).ToString();


            }
            reed.Close();

            //-------------------------------- مصاريف مشتريات ----------------------------------
            string Masrofat = "مصاريف مشتريات";
            textMoshtriat.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMoshtriat.Text = reed["Paid"].ToString();
                textMoshtriat.Text = Math.Round(double.Parse(textMoshtriat.Text), 2).ToString();



            }
            reed.Close();
            //-------------------------------- مصاريف نثرية ----------------------------------
            string Masrofat1 = "مصاريف نثريه";
            textNathria.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat1 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textNathria.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف دعاية ----------------------------------
            string Masrofat2 = "مصاريف دعاية";
            textAdvs.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat2 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textAdvs.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف صيانه ----------------------------------
            string Masrofat3 = "مصاريف صيانة";
            textSeiana.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat3 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textSeiana.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف ايجار ----------------------------------
            string Masrofat4 = "مصاريف ايجار";
            textEgar.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat4 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textEgar.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف كهرباء ----------------------------------
            string Masrofat5 = "فاتورة كهرباء";
            textKahraba.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat5 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textKahraba.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف مياه ----------------------------------
            string Masrofat6 = "فاتورة مياه";
            textWater.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat6 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textWater.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف تليفون ----------------------------------
            string Masrofat7 = "فاتورة تليفون";
            textTell.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat7 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textTell.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف انترنت ----------------------------------
            string Masrofat8 = "فاتورة انترنت";
            textNet.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat8 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textNet.Text = reed["Paid"].ToString();


            }
            reed.Close();

            //-------------------------------- الارباح المسحوبة ----------------------------------
            string Masrofat10 = "سحب ارباح";
            textNet.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat10 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                text_Arbah.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //--------------------------------   اجمالى المصاريف بدون مصاريف الشراء ----------------------------------
            string Masrofat9 = "مصاريف مشتريات";
            textTotalMasrofat2.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move != '" + Masrofat9 + "' and Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textTotalMasrofat2.Text = reed["Paid"].ToString();


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

                textClientValue.Text = rred["PreviousBalance"].ToString();

                textClientValue.Text = Math.Round(double.Parse(textClientValue.Text), 0).ToString();
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



            }
            red.Close();

            double nn = Convert.ToDouble(wared);
            double mm = Convert.ToDouble(sader);
            double rr = nn - mm;

            textBoxMoney.Text = Math.Round(double.Parse(rr.ToString()), 0).ToString();

            //============================================

            //string month = dateTimePicker1.Value.ToString("MM");
            //string year = dateTimePicker1.Value.ToString("yyyy");
            //dateTimePicker2.Text = "01/" + month + "/" + year;

            sqlCommand1.CommandText = "select SUM(Profit) as Profit From Profit  where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {

                textProfits.Text = red["Profit"].ToString();

            }
            red.Close();

            try
            {
                textProfits.Text = Math.Round(double.Parse(textProfits.Text), 0).ToString();
            }
            catch
            { }

            //============================================

            try
            {
                sqlCommand1.CommandText = "insert into ProjectTotal (Month,Year,Date,StoreValue,CustomerValue,BoxValue,Profits,DailyExpenses,AdvExpenses,SeianaExpenses,RentExpenses,ElectricityExpenses,WaterExpenses,PhoneExpenses,InternetExpenses,CarExpenses,Salaries,WithdrawProfits,TotalExpenses,PurchasingExpenses,AddMoneyBox,DiscMoneyBox,Sales,DiscSales,Purchases,DiscPurchases,PurchaseReturns,SalesReturns,Taweredat,Tahselat)values ('" + textMonth.Text + "','" + textYear.Text + "','" + textDateMonth.Text + "','" + textValueMonth.Text + "','" + textClientValue.Text + "','" + textBoxMoney.Text + "','" + textProfits.Text + "','" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah.Text + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                //'" + textNathria.Text + "','" + textAdvs.Text + "','" + textSeiana.Text + "','" + textEgar.Text + "','" + textKahraba.Text + "','" + textWater.Text + "','" + textTell.Text + "','" + textNet.Text + "','" + textCars.Text + "','" + textMortabat.Text + "','" + text_Arbah.Text + "','" + textTotalMasrofat2.Text + "','" + textMoshtriat.Text + "','" + textWaredMoney.Text + "','" + textSadreMoney.Text + "','" + textMabeaat.Text + "','" + textDiscMabeaat.Text + "','" + textMoshtriaatTotal.Text + "','" + textDisSheraa.Text + "','" + textHalekBeeea.Text + "','" + textHaleksheraa.Text + "','" + textTawreed.Text + "','" + textTahseel.Text + "',
                //MessageBox.Show("   الحمد لله لقد تم إضافةالبيانات    ", "  إضافه ");
            }
            catch
            {
                sqlCommand1.CommandText = "update ProjectTotal set  StoreValue='" + textValueMonth.Text + "',CustomerValue='" + textClientValue.Text + "',BoxValue = '" + textBoxMoney.Text + "',Profits = '" + textProfits.Text + "',DailyExpenses='" + textNathria.Text + "',AdvExpenses='" + textAdvs.Text + "',SeianaExpenses='" + textSeiana.Text + "',RentExpenses='" + textEgar.Text + "',ElectricityExpenses='" + textKahraba.Text + "',WaterExpenses='" + textWater.Text + "',PhoneExpenses='" + textTell.Text + "',InternetExpenses='" + textNet.Text + "',CarExpenses='" + textCars.Text + "',Salaries='" + textMortabat.Text + "',WithdrawProfits='" + text_Arbah.Text + "',TotalExpenses='" + textTotalMasrofat2.Text + "',PurchasingExpenses='" + textMoshtriat.Text + "',AddMoneyBox='" + textWaredMoney.Text + "',DiscMoneyBox='" + textSadreMoney.Text + "',Sales='" + textMabeaat.Text + "',DiscSales='" + textDiscMabeaat.Text + "',Purchases='" + textMoshtriaatTotal.Text + "',DiscPurchases='" + textDisSheraa.Text + "',SalesReturns='" + textHalekBeeea.Text + "',PurchaseReturns='" + textHaleksheraa.Text + "',Taweredat='" + textTawreed.Text + "',Tahselat='" + textTahseel.Text + "' where  Date ='" + textDateMonth.Text + "' ";
                sqlCommand1.ExecuteNonQuery();


                //MessageBox.Show("  تم التحديث   ", "    خطأ   ");
            }


            //============================================

            sqlConnection1.Close();

        }
        public void EnabledTsm()
        {
            TsmBarcode.Enabled = false;
            TsmProducerIncomplete.Enabled = false;
            TsmPurchases.Enabled = false;
            TsmExpenses.Enabled = false;
            TsmSales.Enabled = false;
            TsmSalesReturns.Enabled = false;
            TsmPurchaseReturns.Enabled = false;
            TsmOtherExpensesRevenues.Enabled = false;
            TsmPurchases.Enabled = false;
            TsmExpenses.Enabled = false;
            TsmMoneyToBox.Enabled = false;
            TsmMoneyFromBox.Enabled = false;
            TsmGroupAdd.Enabled = false;
            TsmEmployeeAdd.Enabled = false;
            TsmEmployeeSalaryPayment.Enabled = false;
            TsmEmployeeSalaryMovement.Enabled = false;
            TsmEmployeeBonusAdd.Enabled = false;
            TsmEmployeePenaltyAdd.Enabled = false;
            TsmCarsAdd.Enabled = false;
            TsmCarsExpenses.Enabled = false;
            TsmCarsExpensesMovement.Enabled = false;
            TsmBackupSave.Enabled = false;
            TsmBackupRestore.Enabled = false;
            TsmSystemReset.Enabled = false;
            TsmAddClient.Enabled = false;
            TsmClientsMoneyFrom.Enabled = false;
            TsmClientsMoneyTo.Enabled = false;

            //TsmExplainSystem.Enabled = false;
            //TsmConnection.Enabled = false;
            TsmProducerNewAdd.Enabled = false;
            TsmStoreNewAdd.Enabled = false;
            TsmPrices.Enabled = false;
            TsmProducerUpdate.Enabled = false;
            TsmInventory.Enabled = false;
            TsmStoreToStore.Enabled = false;
            TsmProductMovement.Enabled = false;
            TsmBoxMovement.Enabled = false;
            TsmClientsList.Enabled = false;
            TsmBanksList.Enabled = false;
            TsmProfits.Enabled = false;
            TsmDailySalesPurchases.Enabled = false;
            TsmDailyTransactions.Enabled = false;
            TsmFinancialStatements.Enabled = false;
            TsmBankAddAccount.Enabled = false;
            TsmCheckSaderAll.Enabled = false;
            TsmCheckWaredAll.Enabled = false;
            TsmCheckAddALL.Enabled = false;
            TsmCheckDiscALL.Enabled = false;
            TsmBankStatement.Enabled = false;
           

            TsmBankToBank.Enabled = false;
            TsmClientAccountStatement.Enabled = false;
            TsmUserAdd.Enabled = false;
            TsmFirstAccounts.Enabled = false;
            TsmSettingsGeneral.Enabled = false;


        }
        public void GetData()
        {


            try
            {
                sqlConnection1.Open();

                //---------------------------------------------
                sqlCommand1.CommandText = "select GomlaKataey,Kataey,Company_Name,Company_Description,Company_Address,Company_Phone,NoteToBill,PrinterBill,SizePaperBill,PrinterBarcode,PrintNameComToBill,PrintLogoComToBill,FontSizeBarcode,PriceSheraaAcount,Comp_Logo,BarcodeStart,BathBackup,TypeBillDefoult,TypeCurrency,TypeFont,UseLimitCredit,DiscountBill,BarcodeSales,CollectionProduct,HideBalance,TypePrinter,BarcodeSize,BarcodeSalesType,OpenFormOther,PricesAll from SystemProgram where ID = '" + 1 + "'";

                dr = sqlCommand1.ExecuteReader();

                while (dr.Read())
                {
                    //byte[] bytblobdata = new byte[dr.GetBytes(0, 0, null, 0, int.MaxValue)];
                    //dr.GetBytes(0, 0, bytblobdata, 0, bytblobdata.Length);
                    //MemoryStream strmblobdata = new MemoryStream(bytblobdata);

                    //Image pic_logo = Image.FromStream(strmblobdata);
                    string textGomlaKataey = dr["GomlaKataey"].ToString();
                    string textKataey = dr["Kataey"].ToString();
                    string textCompany_Name = dr["Company_Name"].ToString();
                    string textCompany_Description = dr["Company_Description"].ToString();
                    string textCompany_Address = dr["Company_Address"].ToString();
                    string textCompany_Phone = dr["Company_Phone"].ToString();
                    string NoteToBill = dr["NoteToBill"].ToString();
                    string PrinterBill = dr["PrinterBill"].ToString();
                    string SizePaperBill = dr["SizePaperBill"].ToString();
                    string PrinterBarcode = dr["PrinterBarcode"].ToString();
                    string PrintNameComToBill = dr["PrintNameComToBill"].ToString();
                    string PrintLogoComToBill = dr["PrintLogoComToBill"].ToString();
                    string FontSizeBarcode = dr["FontSizeBarcode"].ToString();
                    string PriceSheraaAcount = dr["PriceSheraaAcount"].ToString();
                    string Comp_Logo = dr["Comp_Logo"].ToString();
                    string BarcodeStart = dr["BarcodeStart"].ToString();
                    string TypeBillDefoult = dr["TypeBillDefoult"].ToString();
                    string TypeCurrency = dr["TypeCurrency"].ToString();
                    string TypeFont = dr["TypeFont"].ToString();
                    string UseLimitCredit = dr["UseLimitCredit"].ToString();
                    string DiscountBill = dr["DiscountBill"].ToString();

                    string BarcodeSales = dr["BarcodeSales"].ToString();

                    string BarcodeSalesType = dr["BarcodeSalesType"].ToString();

                    string CollectionProduct = dr["CollectionProduct"].ToString();
                    string HideBalance = dr["HideBalance"].ToString();
                    string TypePrinter = dr["TypePrinter"].ToString();
                    string BarcodeSize = dr["BarcodeSize"].ToString();
                    string OpenFormOther = dr["OpenFormOther"].ToString();
                    string PricesAll = dr["PricesAll"].ToString();
                    BathBackup = dr["BathBackup"].ToString();




                    // --------------------------------OpenFormOther

                    AppSetting.textGomlaKataey = textGomlaKataey;
                    AppSetting.textKataey = textKataey;
                    AppSetting.textCompany_Name = textCompany_Name;
                    AppSetting.textCompany_Description = textCompany_Description;
                    AppSetting.textCompany_Address = textCompany_Address;
                    AppSetting.textCompany_Phone = textCompany_Phone;
                    //AppSetting.pic_logo = pic_logo;
                    //-----------------------------------------------
                    AppSetting.NoteToBill = NoteToBill;
                    AppSetting.PrinterBill = PrinterBill;
                    AppSetting.SizePaperBill = SizePaperBill;
                    AppSetting.PrinterBarcode = PrinterBarcode;
                    AppSetting.PrintNameComToBill = PrintNameComToBill;
                    AppSetting.PrintLogoComToBill = PrintLogoComToBill;
                    AppSetting.FontSizeBarcode = FontSizeBarcode;
                    AppSetting.PriceSheraaAcount = PriceSheraaAcount;
                    AppSetting.BathBackup = BathBackup;
                    AppSetting.Comp_Logo = Comp_Logo;
                    AppSetting.BarcodeStart = BarcodeStart;
                    AppSetting.TypeBillDefoult = TypeBillDefoult;
                    AppSetting.TypeCurrency = TypeCurrency;
                    AppSetting.TypeFont = TypeFont;
                    AppSetting.UseLimitCredit = UseLimitCredit;
                    AppSetting.DiscountBill = DiscountBill;

                    AppSetting.BarcodeSales = BarcodeSales;
                    AppSetting.BarcodeSalesType = BarcodeSalesType;


                    AppSetting.CollectionProduct = CollectionProduct;
                    AppSetting.HideBalance = HideBalance;
                    AppSetting.TypePrinter = TypePrinter;
                    AppSetting.BarcodeSize = BarcodeSize;

                    AppSetting.OpenFormOther = OpenFormOther;
                    AppSetting.PricesAll = PricesAll;

                    try
                    {
                        picCompany_Logo.Image = Image.FromFile(AppSetting.Comp_Logo);
                    }
                    catch
                    { }




                }
                dr.Close();
                sqlCommand1.Dispose();
            }
            catch
            {
                //if (AddCompaneyDataa == null || AddCompaneyDataa.IsDisposed == true)
                //{
                //    AddCompaneyDataa = new AddCompaneyData();
                //}
                //AddCompaneyDataa.MdiParent = this;
                //AddCompaneyDataa.Show();
            }

            sqlConnection1.Close();



        }

        public void GetDataBarcode_Seting()
        {


            try
            {
                sqlConnection1.Open();

                //---------------------------------------------
                sqlCommand1.CommandText = "select BarcodeStart,BarcodePrinter,BarcodeSize,BarcodeTypeFont,BarcodeFontSize,ProductSize,MarginsCompaneyX,MarginsCompaneyY,MarginsBarcodeX,MarginsBarcodeY,MarginsCategorysX,MarginsCategorysY,MarginsCategoryIDX,MarginsCategoryIDY,MarginsPriceX,MarginsPriceY,BarcodeSeparator from Barcode_Seting where ID = '" + 1 + "'";

                dr = sqlCommand1.ExecuteReader();

                while (dr.Read())
                {
                    
                    string BarcodeStart = dr["BarcodeStart"].ToString();
                    string BarcodePrinter = dr["BarcodePrinter"].ToString();
                    string BarcodeSize = dr["BarcodeSize"].ToString();

                    string BarcodeTypeFont = dr["BarcodeTypeFont"].ToString();
                    string BarcodeFontSize = dr["BarcodeFontSize"].ToString();

                    string ProductSize = dr["ProductSize"].ToString();
                    string MarginsCompaneyX = dr["MarginsCompaneyX"].ToString();
                    string MarginsCompaneyY = dr["MarginsCompaneyY"].ToString();
                    string MarginsBarcodeX = dr["MarginsBarcodeX"].ToString();
                    string MarginsBarcodeY = dr["MarginsBarcodeY"].ToString();
                    string MarginsCategorysX = dr["MarginsCategorysX"].ToString();
                    string MarginsCategorysY = dr["MarginsCategorysY"].ToString();
                    string MarginsCategoryIDX = dr["MarginsCategoryIDX"].ToString();
                    string MarginsCategoryIDY = dr["MarginsCategoryIDY"].ToString();
                    string MarginsPriceX = dr["MarginsPriceX"].ToString();
                    string MarginsPriceY = dr["MarginsPriceY"].ToString();
                    string BarcodeSeparator = dr["BarcodeSeparator"].ToString();


                    AppSetting.BarcodeStart = BarcodeStart;
                    AppSetting.BarcodePrinter = BarcodePrinter;
                    AppSetting.BarcodeSize = BarcodeSize;
                    AppSetting.BarcodeTypeFont = BarcodeTypeFont;
                    AppSetting.BarcodeFontSize = BarcodeFontSize;

                    AppSetting.ProductSize = ProductSize;
                    AppSetting.MarginsCompaneyX = MarginsCompaneyX;
                    AppSetting.MarginsCompaneyY = MarginsCompaneyY;
                    AppSetting.MarginsBarcodeX = MarginsBarcodeX;
                    AppSetting.MarginsBarcodeY = MarginsBarcodeY;

                    AppSetting.MarginsCategorysX = MarginsCategorysX;
                    AppSetting.MarginsCategorysY = MarginsCategorysY;
                    AppSetting.MarginsCategoryIDX = MarginsCategoryIDX;
                    AppSetting.MarginsCategoryIDY = MarginsCategoryIDY;
                    AppSetting.MarginsPriceX = MarginsPriceX;
                    AppSetting.MarginsPriceY = MarginsPriceY;
                    AppSetting.BarcodeSeparator = BarcodeSeparator;





                }
                dr.Close();
                sqlCommand1.Dispose();
            }
            catch
            {
                //if (AddCompaneyDataa == null || AddCompaneyDataa.IsDisposed == true)
                //{
                //    AddCompaneyDataa = new AddCompaneyData();
                //}
                //AddCompaneyDataa.MdiParent = this;
                //AddCompaneyDataa.Show();
            }

            sqlConnection1.Close();



        }
        private void TsmSales_Click(object sender, EventArgs e)
        {

            
            TransferData.FormName = "فاتورة مبيعات";

            if (Sales1 == null || Sales1.IsDisposed == true)
            {
                Sales1 = new Sales();
            }
            Sales1.MdiParent = this;
            Sales1.Show();


        

        }

        private void TsmPurchases_Click(object sender, EventArgs e)
        {
            //textBox30.Text = "فاتورة مشتريات";
            //staticfield12.text1 = textBox30.Text;
            TransferData.FormName = "فاتورة مشتريات";

            //----------------------------
            if (Purchases1 == null || Purchases1.IsDisposed == true)
            {
                Purchases1 = new Purchases();
            }
            Purchases1.MdiParent = this;
            Purchases1.Show();
        }

        private void TsmSalesReturns_Click(object sender, EventArgs e)
        {
            ////--------------
            TransferData.FormName = "مردودات مبيعات";

            //staticfield12.text1 = textBox30.Text;

            //--------------------------------
            if (Purchases1 == null || Purchases1.IsDisposed == true)
            {
                Purchases1 = new Purchases();
            }
            Purchases1.MdiParent = this;
            Purchases1.Show();
        }

        private void TsmPurchaseReturns_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "مردودات مشتريات";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (Sales1 == null || Sales1.IsDisposed == true)
            {
                Sales1 = new Sales();
            }
            Sales1.MdiParent = this;
            Sales1.Show();
        }

        private void TsmAddClient_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة عميل";
            //staticfield12.text1 = textBox30.Text;

            //---------------------
            if (ClientAdd1 == null || ClientAdd1.IsDisposed == true)
            {
                ClientAdd1 = new ClientAdd();
            }
            ClientAdd1.MdiParent = this;
            ClientAdd1.Show();
        }

        private void TsmMoneyToBox_Click(object sender, EventArgs e)
        {
            TransferData.TypeMoneyToBox= "إضافة نقدية للصندوق";
            //TransferData.TypeMoneyToBox = "خصم نقدية من الصندوق";

            if (MoneyToBox1 == null || MoneyToBox1.IsDisposed == true)
            {
                MoneyToBox1 = new MoneyToBox();
            }
            MoneyToBox1.MdiParent = this;
            MoneyToBox1.Show();
        }

        private void TsmMoneyFromBox_Click(object sender, EventArgs e)
        {
            TransferData.TypeMoneyToBox = "خصم نقدية من الصندوق";

            if (MoneyFromBox1 == null || MoneyFromBox1.IsDisposed == true)
            {
                MoneyFromBox1 = new MoneyFromBox();
            }
            MoneyFromBox1.MdiParent = this;
            MoneyFromBox1.Show();
        }

        private void TsmExpenses_Click(object sender, EventArgs e)
        {
            if (Expenses1 == null || Expenses1.IsDisposed == true)
            {
                Expenses1 = new Expenses();
            }
            Expenses1.MdiParent = this;
            Expenses1.Show();
        }

        private void TsmEmployeeAdd_Click(object sender, EventArgs e)
        {
            if (EmployeeAdd1 == null || EmployeeAdd1.IsDisposed == true)
            {
                EmployeeAdd1 = new EmployeeAdd();
            }
            EmployeeAdd1.MdiParent = this;
            EmployeeAdd1.Show();
        }

        private void TsmEmployeeSalaryPayment_Click(object sender, EventArgs e)
        {
            if (EmployeeSalaryPayment1 == null || EmployeeSalaryPayment1.IsDisposed == true)
            {
                EmployeeSalaryPayment1 = new EmployeeSalaryPayment();
            }
            EmployeeSalaryPayment1.MdiParent = this;
            EmployeeSalaryPayment1.Show();
        }

        private void TsmEmployeeBonusAdd_Click(object sender, EventArgs e)
        {
            if (EmployeeBonusAdd1 == null || EmployeeBonusAdd1.IsDisposed == true)
            {
                EmployeeBonusAdd1 = new EmployeeBonusAdd();
            }
            EmployeeBonusAdd1.MdiParent = this;
            EmployeeBonusAdd1.Show();
        }

        private void TsmEmployeePenaltyAdd_Click(object sender, EventArgs e)
        {
            if (EmployeePenaltyAdd1 == null || EmployeePenaltyAdd1.IsDisposed == true)
            {
                EmployeePenaltyAdd1 = new EmployeePenaltyAdd();
            }
            EmployeePenaltyAdd1.MdiParent = this;
            EmployeePenaltyAdd1.Show();
        }

        private void TsmEmployeeSalaryMovement_Click(object sender, EventArgs e)
        {
            if (EmployeeSalaryMovement1 == null || EmployeeSalaryMovement1.IsDisposed == true)
            {
                EmployeeSalaryMovement1 = new EmployeeSalaryMovement();
            }
            EmployeeSalaryMovement1.MdiParent = this;
            EmployeeSalaryMovement1.Show();
        }

        private void TsmCarsAdd_Click(object sender, EventArgs e)
        {
            if (CarsAdd1 == null || CarsAdd1.IsDisposed == true)
            {
                CarsAdd1 = new CarsAdd();
            }
            CarsAdd1.MdiParent = this;
            CarsAdd1.Show();
        }

        private void TsmCarsExpenses_Click(object sender, EventArgs e)
        {
            if (CarsExpenses1 == null || CarsExpenses1.IsDisposed == true)
            {
                CarsExpenses1 = new CarsExpenses();
            }
            CarsExpenses1.MdiParent = this;
            CarsExpenses1.Show();
        }

        private void TsmCarsExpensesMovement_Click(object sender, EventArgs e)
        {
            if (CarsExpensesMovement1 == null || CarsExpensesMovement1.IsDisposed == true)
            {
                CarsExpensesMovement1 = new CarsExpensesMovement();
            }
            CarsExpensesMovement1.MdiParent = this;
            CarsExpensesMovement1.Show();
        }

        private void TsmUserAdd_Click(object sender, EventArgs e)
        {
            if (UserAdd1 == null || UserAdd1.IsDisposed == true)
            {
                UserAdd1 = new UserAddNew();
            }
            UserAdd1.MdiParent = this;
            UserAdd1.Show();
        }

        private void TsmBackupSave_Click(object sender, EventArgs e)
        {
            if (BackupSave1 == null || BackupSave1.IsDisposed == true)
            {
                BackupSave1 = new BackupSave();
            }
            BackupSave1.MdiParent = this;
            BackupSave1.Show();
        }

        private void TsmBackupRestore_Click(object sender, EventArgs e)
        {
            if (BackupRestore1 == null || BackupRestore1.IsDisposed == true)
            {
                BackupRestore1 = new BackupRestore();
            }
            BackupRestore1.MdiParent = this;
            BackupRestore1.Show();
        }

        private void TsmSystemReset_Click(object sender, EventArgs e)
        {
            if (SystemReset1 == null || SystemReset1.IsDisposed == true)
            {
                SystemReset1 = new SystemReset();
            }
            SystemReset1.MdiParent = this;
            SystemReset1.Show();
        }

        private void TsmSettingsGeneral_Click(object sender, EventArgs e)
        {
            if (SettingsGeneral1 == null || SettingsGeneral1.IsDisposed == true)
            {
                SettingsGeneral1 = new SettingsGeneral();
            }
            SettingsGeneral1.MdiParent = this;
            SettingsGeneral1.Show();
        }

        private void TsmExplainSystem_Click(object sender, EventArgs e)
        {
            //if (ExplainSystem1 == null || ExplainSystem1.IsDisposed == true)
            //{
            //    ExplainSystem1 = new ExplainSystem();
            //}
            //ExplainSystem1.MdiParent = this;
            //ExplainSystem1.Show();

            System.Diagnostics.Process.Start("https://zadsales.com");

            //http://alwasif.blogspot.com/2020/01/blog-post_15.html
        }

        private void TsmLicense_Click(object sender, EventArgs e)
        {
            if (License1 == null || License1.IsDisposed == true)
            {
                License1 = new License();
            }
            License1.MdiParent = Main.ActiveForm;
            License1.Show();
        }

        private void TsmCallUs_Click(object sender, EventArgs e)
        {
            if (CallUs1 == null || CallUs1.IsDisposed == true)
            {
                CallUs1 = new CallUs();
            }
            CallUs1.MdiParent = this;
            CallUs1.Show();
        }

        private void TsmClientsMoneyFrom_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "تحصيل نقدى";
            if (ClientsMoney1 == null || ClientsMoney1.IsDisposed == true)
            {
                ClientsMoney1 = new ClientsMoney();
            }
            ClientsMoney1.MdiParent = this;
            ClientsMoney1.Show();
        }

        private void TsmClientsMoneyTo_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "دفع نقدى";
            if (ClientsMoney1 == null || ClientsMoney1.IsDisposed == true)
            {
                ClientsMoney1 = new ClientsMoney();
            }
            ClientsMoney1.MdiParent = this;
            ClientsMoney1.Show();
        }

        private void TsmGroupAdd_Click(object sender, EventArgs e)
        {
            if (GroupAdd1 == null || GroupAdd1.IsDisposed == true)
            {
                GroupAdd1 = new GroupAdd();
            }
            GroupAdd1.MdiParent = this;
            GroupAdd1.Show();
        }

        private void TsmConnection_Click(object sender, EventArgs e)
        {
            if (Connection1 == null || Connection1.IsDisposed == true)
            {
                Connection1 = new Connection();
            }
            Connection1.MdiParent = this;
            Connection1.Show();
        }

        private void TsmMoneyToBoxFristTime_Click(object sender, EventArgs e)
        {
            //TransferData.TypeMoneyToBox = "إضافة نقدية للصندوق";
            TransferData.TypeMoneyToBox = "إضافة نقدية للصندوق أول المدة";

            if (MoneyToBox1 == null || MoneyToBox1.IsDisposed == true)
            {
                MoneyToBox1 = new MoneyToBox();
            }
            MoneyToBox1.MdiParent = this;
            MoneyToBox1.Show();
        }

        private void TsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TsmCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void TsmProducerNewAdd_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة منتج جديد";

            if (ProducerNewAdd1 == null || ProducerNewAdd1.IsDisposed == true)
            {
                ProducerNewAdd1 = new ProducerNewAdd();
            }
            ProducerNewAdd1.MdiParent = this;
            ProducerNewAdd1.Show();
        }

        private void TsmStoreNewAdd_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة مخزن جديد";

            if (StoreNewAdd1 == null || StoreNewAdd1.IsDisposed == true)
            {
                StoreNewAdd1 = new StoreNewAdd();
            }
            StoreNewAdd1.MdiParent = this;
            StoreNewAdd1.Show();
        }

        private void TsmPrices_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الاسعار";

            if (Prices1 == null || Prices1.IsDisposed == true)
            {
                Prices1 = new Prices();
            }
            Prices1.MdiParent = this;
            Prices1.Show();
        }

        private void TsmProducerUpdate_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "تعديل صنف";

            if (ProducerUpdate1 == null || ProducerUpdate1.IsDisposed == true)
            {
                ProducerUpdate1 = new ProducerUpdate();
            }
            ProducerUpdate1.MdiParent = this;
            ProducerUpdate1.Show();
        }

        private void TsmStoreToStore_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "نقل كمية من مخزن الى مخزن";

            if (StoreToStore1 == null || StoreToStore1.IsDisposed == true)
            {
                StoreToStore1 = new StoreToStore();
            }
            StoreToStore1.MdiParent = this;
            StoreToStore1.Show();
        }

        private void TsmInventory_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الجرد";

            if (Inventory1 == null || Inventory1.IsDisposed == true)
            {
                Inventory1 = new Inventory();
            }
            Inventory1.MdiParent = this;
            Inventory1.Show();
        }

        private void TsmBarcode_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الباركود";

            if (Barcode1 == null || Barcode1.IsDisposed == true)
            {
                Barcode1 = new Barcode();
            }
            Barcode1.MdiParent = this;
            Barcode1.Show();
        }

        private void TsmProducerIncomplete_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الاصناف الناقصه";

            if (ProducerIncomplete1 == null || ProducerIncomplete1.IsDisposed == true)
            {
                ProducerIncomplete1 = new ProducerIncomplete();
            }
            ProducerIncomplete1.MdiParent = this;
            ProducerIncomplete1.Show();
        }

        private void TsmProductMovement_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "حركة الاصناف";

            if (ProductMovement1 == null || ProductMovement1.IsDisposed == true)
            {
                ProductMovement1 = new ProductMovement();
            }
            ProductMovement1.MdiParent = this;
            ProductMovement1.Show();
        }

        private void TsmBoxMovement_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "حركة الصندوق";

            if (BoxMovement1 == null || BoxMovement1.IsDisposed == true)
            {
                BoxMovement1 = new BoxMovement();
            }
            BoxMovement1.MdiParent = this;
            BoxMovement1.Show();
        }

        private void TsmCustomerAccountStatement_Click(object sender, EventArgs e)
        {
            
        }

        private void TsmClientAccountStatement_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "كشف حساب عميل";

            if (ClientAccountStatement1 == null || ClientAccountStatement1.IsDisposed == true)
            {
                ClientAccountStatement1 = new ClientAccountStatement();
            }
            ClientAccountStatement1.MdiParent = this;
            ClientAccountStatement1.Show();

        }

        private void TsmClientsList_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "قائمة العملاء";

            if (ClientsList1 == null || ClientsList1.IsDisposed == true)
            {
                ClientsList1 = new ClientsList();
            }
            ClientsList1.MdiParent = this;
            ClientsList1.Show();
        }

        private void TsmBanksList_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "قائمة البنوك";

            if (BanksList1 == null || BanksList1.IsDisposed == true)
            {
                BanksList1 = new BanksList();
            }
            BanksList1.MdiParent = this;
            BanksList1.Show();
        }

        private void TsmProfits_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الارباح";

            if (Profits1 == null || Profits1.IsDisposed == true)
            {
                Profits1 = new Profits();
            }
            Profits1.MdiParent = this;
            Profits1.Show();
        }

        private void TsmDailySalesPurchases_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "يومية المبيعات والمشتريات";

            if (DailySalesPurchases1 == null || DailySalesPurchases1.IsDisposed == true)
            {
                DailySalesPurchases1 = new DailySalesPurchases();
            }
            DailySalesPurchases1.MdiParent = this;
            DailySalesPurchases1.Show();
        }

        private void TsmDailyTransactions_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "المعاملات اليومية";

            if (DailyTransactions1 == null || DailyTransactions1.IsDisposed == true)
            {
                DailyTransactions1 = new DailyTransactions();
            }
            DailyTransactions1.MdiParent = this;
            DailyTransactions1.Show();
        }

        private void TsmFinancialStatements_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "القوائم المالية";

            if (FinancialStatements1 == null || FinancialStatements1.IsDisposed == true)
            {
                FinancialStatements1 = new FinancialStatements();
            }
            FinancialStatements1.MdiParent = this;
            FinancialStatements1.Show();
        }

        private void TsmBankAddAccount_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "اضافة حساب بنك";

            if (BankAddAccount1 == null || BankAddAccount1.IsDisposed == true)
            {
                BankAddAccount1 = new BankAddAccount();
            }
            BankAddAccount1.MdiParent = this;
            BankAddAccount1.Show();
        }

        private void TsmCheckWared_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "شيك وارد";

            if (CheckSaderWared1 == null || CheckSaderWared1.IsDisposed == true)
            {
                CheckSaderWared1 = new CheckSaderWared();
            }
            CheckSaderWared1.MdiParent = this;
            CheckSaderWared1.Show();
        }

        private void TsmDraftWared_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "كمبيالة واردة";

            if (CheckSaderWared1 == null || CheckSaderWared1.IsDisposed == true)
            {
                CheckSaderWared1 = new CheckSaderWared();
            }
            CheckSaderWared1.MdiParent = this;
            CheckSaderWared1.Show();
        }

        private void TsmCheckSader_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "شيك صادر";

            if (CheckSaderWared1 == null || CheckSaderWared1.IsDisposed == true)
            {
                CheckSaderWared1 = new CheckSaderWared();
            }
            CheckSaderWared1.MdiParent = this;
            CheckSaderWared1.Show();
        }

        private void TsmDraftSader_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "كمبيالة صادرة";

            if (CheckSaderWared1 == null || CheckSaderWared1.IsDisposed == true)
            {
                CheckSaderWared1 = new CheckSaderWared();
            }
            CheckSaderWared1.MdiParent = this;
            CheckSaderWared1.Show();
        }

        private void TsmCheckWaredSave_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "حفظ شيك مدين";

            if (CheckSave1 == null || CheckSave1.IsDisposed == true)
            {
                CheckSave1 = new CheckSave();
            }
            CheckSave1.MdiParent = this;
            CheckSave1.Show();
        }

        private void TsmDraftWaredSave_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "حفظ كمبيالة مدين";

            if (CheckSave1 == null || CheckSave1.IsDisposed == true)
            {
                CheckSave1 = new CheckSave();
            }
            CheckSave1.MdiParent = this;
            CheckSave1.Show();
        }

        private void TsmCheckSaderSave_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "حفظ شيك دائن";

            if (CheckSave1 == null || CheckSave1.IsDisposed == true)
            {
                CheckSave1 = new CheckSave();
            }
            CheckSave1.MdiParent = this;
            CheckSave1.Show();
        }

        private void TsmDraftSaderSave_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "حفظ كمبيالة دائن";

            if (CheckSave1 == null || CheckSave1.IsDisposed == true)
            {
                CheckSave1 = new CheckSave();
            }
            CheckSave1.MdiParent = this;
            CheckSave1.Show();
        }

        private void TsmBankStatement_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "كشف حساب بنك";

            if (BankStatement1 == null || BankStatement1.IsDisposed == true)
            {
                BankStatement1 = new BankStatement();
            }
            BankStatement1.MdiParent = this;
            BankStatement1.Show();
        }

        private void TsmBankToBank_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "تحويل من بنك الى بنك";

            if (BankToBank1 == null || BankToBank1.IsDisposed == true)
            {
                BankToBank1 = new BankToBank();
            }
            BankToBank1.MdiParent = this;
            BankToBank1.Show();
        }

        private void saveEvents(string Event)
        {

            //=========================== تسجيل الحركات  ========================== 
            try
            {

                //string Event = "تم فتح شاشة  " + TransferData.FormName;

                sqlConnection1.Open();

                sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                sqlCommand1.ExecuteNonQuery();

                sqlConnection1.Close();
                //MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");


                //---------------


            }
            catch
            {
                // MessageBox.Show("    فشلللللللللللللللللللللللللللللللل   ", "فشل ");
            }

            //========================== ========================== ========================== 
        }

        private void CheckOccasions() //------ فحص هل يوجد رسالة تذكير مناسبات
        {
            

            List<Occasion> occasions = occasionDAL.GetUpcomingOccasions();

            foreach (var occ in occasions)
            {
                MessageBox.Show(
                    $"تنبيه: باقي {occ.DaysLeft} يوم على {occ.OccasionName}.\n{occ.Description}",
                    "تذكير مناسبة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        //private void CheckOccasions() //------ رسالة تذكير مناسبات
        //{
        //    using (SqlConnection conn = new SqlConnection(constring))
        //    {
        //        conn.Open();
        //        string query = @"
        //            DECLARE @Today DATE = CAST(GETDATE() AS DATE);
        //            SELECT OccasionName, OccasionDate, Description, 
        //                   DATEDIFF(DAY, @Today, OccasionDate) AS DaysLeft
        //            FROM Occasions
        //            WHERE 
        //                DATEDIFF(DAY, @Today, OccasionDate) BETWEEN 0 AND ReminderDays
        //                OR 
        //                (RepeatYearly = 1 AND DATEDIFF(DAY, @Today, DATEFROMPARTS(YEAR(@Today), MONTH(OccasionDate), DAY(OccasionDate))) BETWEEN 0 AND ReminderDays)
        //            ORDER BY OccasionDate;";

        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string name = reader["OccasionName"].ToString();
        //            string desc = reader["Description"].ToString();
        //            int daysLeft = Convert.ToInt32(reader["DaysLeft"]);

        //            MessageBox.Show(
        //                $"تنبيه: باقي {daysLeft} يوم على {name}.\n{desc}",
        //                "تذكير مناسبة",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information
        //            );
        //        }
        //    }
        //}

        void ApplyPermissions()
        {
            TsmFirstAccounts.Enabled = CurrentUser.FirstAccounts == 1;
            TsmStatistical.Enabled = CurrentUser.Statistical == 1;

            TsmSales.Enabled = CurrentUser.Sales == 1;
            TsmSalesReturns.Enabled = CurrentUser.Sales == 1;
            TsmPurchaseReturns.Enabled = CurrentUser.Sales == 1;
            TsmOtherExpensesRevenues.Enabled = CurrentUser.Sales == 1;
            TsmBarcode.Enabled = CurrentUser.Sales == 1;
            TsmProducerIncomplete.Enabled = CurrentUser.Sales == 1;

            TsmPurchases.Enabled = CurrentUser.Purchases == 1;
            TsmExpenses.Enabled = CurrentUser.Expenses == 1;

            TsmMoneyToBox.Enabled = CurrentUser.MoneyToBox == 1;
            TsmMoneyFromBox.Enabled = CurrentUser.MoneyFromBox == 1;

            TsmGroupAdd.Enabled = CurrentUser.GroupAdd == 1;
            TsmEmployeeAdd.Enabled = CurrentUser.EmployeeAdd == 1;
            TsmEmployeeSalaryPayment.Enabled = CurrentUser.EmployeeSalaryPayment == 1;
            TsmEmployeeSalaryMovement.Enabled = CurrentUser.EmployeeSalaryMovement == 1;
            TsmEmployeeBonusAdd.Enabled = CurrentUser.EmployeeBonusAdd == 1;
            TsmEmployeePenaltyAdd.Enabled = CurrentUser.EmployeePenaltyAdd == 1;

            TsmCarsAdd.Enabled = CurrentUser.CarsAdd == 1;
            TsmCarsExpenses.Enabled = CurrentUser.CarsExpenses == 1;
            TsmCarsExpensesMovement.Enabled = CurrentUser.CarsExpensesMovement == 1;

            TsmBackupSave.Enabled = CurrentUser.BackupSave == 1;
            TsmBackupRestore.Enabled = CurrentUser.BackupRestore == 1;

            TsmSettingsGeneral.Enabled = CurrentUser.SettingsGeneral == 1;
            TsmSystemReset.Enabled = CurrentUser.SystemReset == 1;

            TsmAddClient.Enabled = CurrentUser.ClientAdd == 1;
            TsmClientsMoneyFrom.Enabled = CurrentUser.ClientsMoney == 1;
            TsmClientsMoneyTo.Enabled = CurrentUser.ClientsMoney == 1;

            TsmProducerNewAdd.Enabled = CurrentUser.ProducerNewAdd == 1;
            TsmStoreNewAdd.Enabled = CurrentUser.StoreNewAdd == 1;
            TsmPrices.Enabled = CurrentUser.Prices == 1;
            TsmProducerUpdate.Enabled = CurrentUser.ProducerUpdate == 1;

            TsmInventory.Enabled = CurrentUser.Inventory == 1;

            TsmStoreToStore.Enabled = CurrentUser.StoreToStore == 1;
            TsmProductMovement.Enabled = CurrentUser.ProductMovement == 1;
            TsmBoxMovement.Enabled = CurrentUser.BoxMovement == 1;

            TsmClientsList.Enabled = CurrentUser.ClientsList == 1;
            TsmBanksList.Enabled = CurrentUser.BanksList == 1;

            TsmProfits.Enabled = CurrentUser.Profits == 1;
            TsmDailySalesPurchases.Enabled = CurrentUser.DailySalesPurchases == 1;
            TsmDailyTransactions.Enabled = CurrentUser.DailyTransactions == 1;
            TsmFinancialStatements.Enabled = CurrentUser.FinancialStatements == 1;

            TsmBankAddAccount.Enabled = CurrentUser.BankAddAccount == 1;

            TsmCheckSaderAll.Enabled = CurrentUser.CheckSaderWared == 1;
            TsmCheckWaredAll.Enabled = CurrentUser.CheckSaderWared == 1;

            TsmCheckAddALL.Enabled = CurrentUser.CheckSave == 1;
            TsmCheckDiscALL.Enabled = CurrentUser.CheckSave == 1;

            TsmBankStatement.Enabled = CurrentUser.BankStatement == 1;
            TsmBankToBank.Enabled = CurrentUser.BankToBank == 1;

            TsmClientAccountStatement.Enabled = CurrentUser.ClientAccountStatement == 1;

            TsmUserAdd.Enabled = CurrentUser.UserAdd1 == 1;
        }

        //Dictionary<string, Func<int>> menuPermissions = new Dictionary<string, Func<int>>()
        //    {
        //        { "TsmSales", () => CurrentUser.Sales },
        //        { "TsmPurchases", () => CurrentUser.Purchases },
        //        { "TsmExpenses", () => CurrentUser.Expenses },
        //        { "TsmClients", () => CurrentUser.ClientAdd },
        //        { "TsmUsers", () => CurrentUser.AllowUser }
        //    };
        Dictionary<string, Func<int>> menuPermissions = new Dictionary<string, Func<int>>()
        {
            //=== مبيعات ومشتريات
            { "TsmSales", () => CurrentUser.Sales },
            { "TsmPurchases", () => CurrentUser.Purchases },
            { "TsmSalesReturns", () => CurrentUser.Sales },//مردودات
            { "TsmPurchaseReturns", () => CurrentUser.Purchases },//مردودات
            //TsmOtherExpensesRevenues مصروفات وايرادات اخرى
            //TsmInstallment   التقسيط
            //TsmSalesNoSave فاتورة مبيعات غير معتمدة
            //======= نهاية قائمة المبيعات والمشتريات

            //======= شئون مالية
            { "TsmExpenses", () => CurrentUser.Expenses },
            { "TsmMoneyToBox", () => CurrentUser.MoneyToBox },
            { "TsmMoneyFromBox", () => CurrentUser.MoneyFromBox },
            //====== نهاية شئون مالية
            
            //===== العملاء
            { "TsmGroupAdd", () => CurrentUser.GroupAdd },
            { "TsmAddClient", () => CurrentUser.ClientAdd },
            { "TsmClientsMoneyFrom", () => CurrentUser.ClientsMoney },
            { "TsmClientsMoneyTo", () => CurrentUser.ClientsMoney },
            { "TsmClientsMoneyToClients", () => CurrentUser.ClientsMoney } ,// تحويل من عميل الى عميل

            //=== نهاية العملاء


            // ==== شئون العاملين
            { "TsmEmployeeAdd", () => CurrentUser.EmployeeAdd },
            { "TsmEmployeeSalaryPayment", () => CurrentUser.EmployeeSalaryPayment },
            { "TsmEmployeeSalaryMovement", () => CurrentUser.EmployeeSalaryMovement },
            { "TsmEmployeeBonusAdd", () => CurrentUser.EmployeeBonusAdd },
            { "TsmEmployeePenaltyAdd", () => CurrentUser.EmployeePenaltyAdd },
            //=== نهاية شئون العاملين

            //==== السيارات
            { "TsmCarsAdd", () => CurrentUser.CarsAdd },
            { "TsmCarsExpenses", () => CurrentUser.CarsExpenses },
            { "TsmCarsExpensesMovement", () => CurrentUser.CarsExpensesMovement },
           // نهاية اسيارات
            
            //=== قواعد البيانات
            { "TsmBackupSave", () => CurrentUser.BackupSave },
            { "TsmBackupRestore", () => CurrentUser.BackupRestore },
            { "TsmSettingsGeneral", () => CurrentUser.SettingsGeneral },
            { "TsmSystemReset", () => CurrentUser.SystemReset },
            // TsmOccasionsForm  المناسبات
            //TsmVersionNew جديد الاصدارات
            //========== نهاية قواعد البيانات

            //===المساعدة 
            { "TsmLicense", () => CurrentUser.License },
            { "TsmCallUs", () => CurrentUser.CallUs },
            //TsmPrograms برامجنا
            //TsmTermsandConditions الشروط والاحكام
            //TsmExplainSystem موقعنا على الانترنت
            //====== نهاية المساعدة

            
            { "TsmExplainSystem", () => CurrentUser.ExplainSystem }, // شرح النظام

            //==== الاصناف
            { "TsmProducerNewAdd", () => CurrentUser.ProducerNewAdd },
            { "TsmStoreNewAdd", () => CurrentUser.StoreNewAdd },
            //tsmGroup_Name اضافة مجموعه للاصناف
            //tsmFactionCategoreyAdd  اضافة فئات جديدة للاصناف
            { "TsmPrices", () => CurrentUser.Prices },
            { "TsmProducerUpdate", () => CurrentUser.ProducerUpdate },
            { "TsmStoreToStore", () => CurrentUser.StoreToStore },
            { "TsmInventory", () => CurrentUser.Inventory },
            { "TsmBarcode", () => CurrentUser.Barcode },
            { "TsmProducerIncomplete", () => CurrentUser.ProducerIncomplete },
            //TsmAddSnToCategory اضافة سريلات للاصناف
            { "TsmPriceViewer", () => CurrentUser.PriceViewer },
            { "TsmProducerAddBarcodeFactory", () => CurrentUser.ProducerAddBarcodeFactory },
            // ====نهاية الاصناف 

            //====== التقارير
            { "TsmProductMovement", () => CurrentUser.ProductMovement },
            { "TsmBoxMovement", () => CurrentUser.BoxMovement },
            { "TsmClientAccountStatement", () => CurrentUser.ClientAccountStatement },
            { "TsmClientsList", () => CurrentUser.ClientsList },
            { "TsmBanksList", () => CurrentUser.BanksList },
            { "TsmProfits", () => CurrentUser.Profits },
            { "TsmDailySalesPurchases", () => CurrentUser.DailySalesPurchases },
            { "TsmDailyTransactions", () => CurrentUser.DailyTransactions },
            { "TsmFinancialStatements", () => CurrentUser.FinancialStatements },
           //DailyEvents الاحداث اليومية
           //TsmDailyClosing الختام اليومى
           { "TsmStatistical", () => CurrentUser.Statistical },
           //TsmStatisticalFrmBillingSummary تقرير العملاء
           //====== نهاية التقارير

           //==== البنوك
            { "TsmBankAddAccount", () => CurrentUser.BankAddAccount },
            { "TsmCheckAddALL", () => CurrentUser.CheckSave },
            { "TsmCheckDiscALL", () => CurrentUser.CheckSave },
            { "TsmCheckWaredAll", () => CurrentUser.CheckSaderWared },
            { "TsmCheckSaderAll", () => CurrentUser.CheckSaderWared },
            { "TsmBankStatement", () => CurrentUser.BankStatement },
            { "TsmBankToBank", () => CurrentUser.BankToBank },
            //====== نهاية البنوك


            //===== المستخدمين
            { "TsmUserAdd", () => CurrentUser.UserAdd1 },

            //===== حسابات اول المدة القائمة كاملة
            { "TsmFirstAccounts", () => CurrentUser.FirstAccounts },
            
            


            //{ "TsmFirstAccounts", () => CurrentUser.FirstAccounts },
    
            //// مفيش مقابل واضح → ممكن تربطه أو تسيبه
            //{ "TsmStatistical", () => CurrentUser.Statistical },

            //{ "TsmSales", () => CurrentUser.Sales },
            //{ "TsmSalesReturns", () => CurrentUser.Sales },
            //{ "TsmPurchaseReturns", () => CurrentUser.Purchases },

            //{ "ToolStrip_CategoryOthers", () => 1 },

            //{ "TsmBarcode", () => CurrentUser.Barcode },
            //{ "TsmProducerIncomplete", () => CurrentUser.ProducerIncomplete },

            //{ "TsmPurchases", () => CurrentUser.Purchases },
            //{ "TsmExpenses", () => CurrentUser.Expenses },
            //{ "TsmMoneyToBox", () => CurrentUser.MoneyToBox },
            //{ "TsmMoneyFromBox", () => CurrentUser.MoneyFromBox },

            //{ "TsmGroupAdd", () => CurrentUser.GroupAdd },
            //{ "TsmEmployeeAdd", () => CurrentUser.EmployeeAdd },
            //{ "TsmEmployeeSalaryPayment", () => CurrentUser.EmployeeSalaryPayment },
            //{ "TsmEmployeeSalaryMovement", () => CurrentUser.EmployeeSalaryMovement },
            //{ "TsmEmployeeBonusAdd", () => CurrentUser.EmployeeBonusAdd },
            //{ "TsmEmployeePenaltyAdd", () => CurrentUser.EmployeePenaltyAdd },

            //{ "TsmCarsAdd", () => CurrentUser.CarsAdd },
            //{ "TsmCarsExpenses", () => CurrentUser.CarsExpenses },
            //{ "TsmCarsExpensesMovement", () => CurrentUser.CarsExpensesMovement },

            //{ "TsmBackupSave", () => CurrentUser.BackupSave },
            //{ "TsmBackupRestore", () => CurrentUser.BackupRestore },

            //{ "TsmSettingsGeneral", () => CurrentUser.SettingsGeneral },
            //{ "TsmSystemReset", () => CurrentUser.SystemReset },

            //{ "TsmAddClient", () => CurrentUser.ClientAdd },
            //{ "TsmClientsMoneyFrom", () => CurrentUser.ClientsMoney },
            //{ "TsmClientsMoneyTo", () => CurrentUser.ClientsMoney },

            //{ "TsmProducerNewAdd", () => CurrentUser.ProducerNewAdd },
            //{ "TsmStoreNewAdd", () => CurrentUser.StoreNewAdd },

            //{ "TsmPrices", () => CurrentUser.Prices },
            //{ "TsmProducerUpdate", () => CurrentUser.ProducerUpdate },

            //{ "TsmInventory", () => CurrentUser.Inventory },
            //{ "TsmStoreToStore", () => CurrentUser.StoreToStore },

            //{ "TsmProductMovement", () => CurrentUser.ProductMovement },
            //{ "TsmBoxMovement", () => CurrentUser.BoxMovement },

            //{ "TsmClientsList", () => CurrentUser.ClientsList },
            //{ "TsmBanksList", () => CurrentUser.BanksList },

            //{ "TsmProfits", () => CurrentUser.Profits },
            //{ "TsmDailySalesPurchases", () => CurrentUser.DailySalesPurchases },
            //{ "TsmDailyTransactions", () => CurrentUser.DailyTransactions },
            //{ "TsmFinancialStatements", () => CurrentUser.FinancialStatements },

            //{ "TsmBankAddAccount", () => CurrentUser.BankAddAccount },

            //// الشيكات كلها على نفس الصلاحية
            //{ "TsmCheckSaderAll", () => CurrentUser.CheckSaderWared },
            //{ "TsmCheckWaredAll", () => CurrentUser.CheckSaderWared },
            //{ "TsmCheckAddALL", () => CurrentUser.CheckSave },
            //{ "TsmCheckDiscALL", () => CurrentUser.CheckSave },

            //{ "TsmBankStatement", () => CurrentUser.BankStatement },
            //{ "TsmBankToBank", () => CurrentUser.BankToBank },

            //{ "TsmClientAccountStatement", () => CurrentUser.ClientAccountStatement },

            //{ "TsmUserAdd", () => CurrentUser.UserAdd1 },
            //{ "TsmExplainSystem", () => CurrentUser.ExplainSystem },
            //{ "TsmCallUs", () => CurrentUser.CallUs },
            //{ "TsmLicense", () => CurrentUser.License },
            //{ "TsmClientsMoneyToClients", () => CurrentUser.ClientsMoney },
            //{ "TsmPriceViewer", () => CurrentUser.PriceViewer },
            //{ "TsmProducerAddBarcodeFactory", () => CurrentUser.PriceViewer }

        };

        void ApplyPermissionsSmart()
        {
            foreach (ToolStripMenuItem item in GetAllMenuItems(menuStrip2))
            {
                if (menuPermissions.ContainsKey(item.Name))
                {
                    int value = menuPermissions[item.Name]();

                    item.Enabled = value == 1;
                    // أو
                    // item.Visible = value == 1;
                }
            }

            foreach (ToolStripMenuItem item in GetAllMenuItems(menuStrip2))
            {
                if (!menuPermissions.ContainsKey(item.Name))
                {
                    Console.WriteLine("Not Mapped: " + item.Name);
                }
            }
        }

        List<ToolStripMenuItem> GetAllMenuItems(MenuStrip menu)
        {
            List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();

            foreach (ToolStripItem item in menu.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    list.Add(menuItem);
                    GetSubItems(menuItem, list);
                }
            }

            return list;
        }

        void GetSubItems(ToolStripMenuItem parent, List<ToolStripMenuItem> list)
        {
            foreach (ToolStripItem sub in parent.DropDownItems)
            {
                if (sub is ToolStripMenuItem child)
                {
                    list.Add(child);
                    GetSubItems(child, list);
                }
            }
        }
        //--------- دالة مؤقتة
        void DebugPermissions()
        {
            foreach (ToolStripMenuItem item in GetAllMenuItems(menuStrip2))
            {
                string name = item.Name;

                if (menuPermissions.ContainsKey(name))
                {
                    int value = menuPermissions[name]();

                    Console.WriteLine($"{name} => Permission = {value}");
                }
                else
                {
                    Console.WriteLine($"{name} => Not Mapped");
                }
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            CheckOccasions(); //------ رسالة تذكير مناسبات




            GetValueMonth();

            //------- تحميل صلاحيات المستخدم النظام القديم

          //  User_Powers();

            //------- تحميل صلاحيات المستخدم النظام الجديدة
          
            ApplyPermissionsSmart();


            DebugPermissions(); // 👈 شغلها مؤقتًا

            //GetValueMonth();
            //  butUpdate.PerformClick();


            //==========================  تسجيل الحركات  ========================== 

            saveEvents("تم تسجيل الدخول للمستخدم  " + AppSetting.user);

            //========================== ========================== =================

            GetData();

            GetDataBarcode_Seting();

            //----------------------- Backup -------------
            try
            {
                //SaveFileDialog sf = new SaveFileDialog();
                //sf.Filter = "Backup Files(*.Bak)|*.bak";
                if (BathBackup != "")
                {
                    //---- Delete backup Old
                    File.Delete(BathBackup);



                    //--------- Creat Backup New


                    string Backup = "Backup Database " + DataName;

                    sqlCommand1 = new SqlCommand(Backup + " To Disk='" + BathBackup + "'", sqlConnection1);

                    //   sqlCommand1 = new SqlCommand("Backup Database ZAD To Disk='" + BathBackup + "'", sqlConnection1);

                    sqlConnection1.Open();
                    sqlCommand1.ExecuteNonQuery();
                    sqlConnection1.Close();

                    //  MessageBox.Show("       تم أخذ نسخة إحتياطية بنجاح    ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            //----------------------- الفترة التجريبية -------------
            //try
            //{
            //    نسخةتجريبيةToolStripMenuItem.Visible = true;

            //    string NumBill = "0";
            //    sqlConnection1.Open();

            //    sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
            //    red = sqlCommand1.ExecuteReader();
            //    while (red.Read())
            //    {
            //        double s = Convert.ToDouble(red["NumBill"].ToString());
            //        double aa = s + 1;
            //        NumBill = aa.ToString();


            //    }
            //    red.Close();
            //    sqlConnection1.Close();
            //     =============== فترة تجريبية ===================
            //    double asa = Convert.ToDouble(NumBill);

            //    if (asa >= 100)
            //    {
            //        if (Altarkhes == null || Altarkhes.IsDisposed == true)
            //        {
            //            Altarkhes = new الترخيص();
            //        }
            //        //Altarkhes.MdiParent = this;
            //        Altarkhes.ShowDialog();

            //        MessageBox.Show("    نأسف تم انتهاء الفترة التجريبية اتصل بنا على 01224349933     ", "الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        Application.Exit();
            //    }
            //    else
            //    {

            //    }
            //}
            //catch
            //{ }
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            User_Powers();
           
        }

        private void TsmLogin_Click(object sender, EventArgs e)
        {
            EnabledTsm();

            panelUser.Visible = true;

            textUserName.Text = "";
            textBassword.Text = "";

            textUserName.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TsmFirst_Term_Products_Click(object sender, EventArgs e)
        {
            
            TransferData.FormName = "جرد أول المدة";
            

           

            //----------------------------
            if (Purchases1 == null || Purchases1.IsDisposed == true)
            {
                Purchases1 = new Purchases();
            }
            Purchases1.MdiParent = this;
            Purchases1.Show();
        }

        private void TsmFirst_Term_Madenon_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "مدين أول المدة";

            //---------------------
            if (ClientAddFrist1 == null || ClientAddFrist1.IsDisposed == true)
            {
                ClientAddFrist1 = new ClientAddFrist();
            }
            ClientAddFrist1.MdiParent = this;
            ClientAddFrist1.Show();
        }

        private void TsmFirst_Term_Daenon_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "دائن أول المدة";
            //---------------------
            if (ClientAddFrist1 == null || ClientAddFrist1.IsDisposed == true)
            {
                ClientAddFrist1 = new ClientAddFrist();
            }
            ClientAddFrist1.MdiParent = this;
            ClientAddFrist1.Show();
        }

        private void textBassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // butLogin.Focus();
                butLogin.PerformClick();

            }
        }

        private void قناةالوصيفللقرآنالكريمToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/user/elwesiftv");
        }

        private void اليـــــــــــومالســـــــــابعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/ZadSale");
        }

        private void المصرىاليــــــــــــــــــــومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.almasryalyoum.com");
        }

        private void وزارةالأوقافأونلاينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.awkafonline.com");
        }

        private void الأزهرالشريفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alazhar.gov.eg");
        }

        private void وزارةالتربيةوالتعليمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://portal.moe.gov.eg/Pages/default.aspx");
        }

        private void الياهـــــــــــــــوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.yahoo.com");
        }

        private void الهوتميــــــــــــلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://login.live.com");
        }

        private void الفيسبـــــــــــوكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");
        }

        private void يــوتيــــــوبYoutubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com");
        }

        private void تويترToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com");
        }

        private void كورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.kooora.com");
        }

        private void ياللاكــــــــــــــــــــــــورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.yallakora.com");
        }

        private void الأهلىالمصــــــــــرىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.el-ahly.com");
        }

        private void الزمالـــــكالمصــــــــــرىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.zamalektoday.com");
        }

        private void نسخةتجريبيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("    عند انتهاء الفترة التجريبية اتصل بنا على 01224349933     ", "الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ToolStrip_CategoryOthers_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "مصروفا وايرادات اخرى";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (MoneyWaredAndSaderOther1 == null || MoneyWaredAndSaderOther1.IsDisposed == true)
            {
                MoneyWaredAndSaderOther1 = new MoneyWaredAndSaderOther();
            }
            MoneyWaredAndSaderOther1.MdiParent = this;
            MoneyWaredAndSaderOther1.Show();
        }

        private void التصنيعToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TsmCategorysMake_Click(object sender, EventArgs e)
        {
            
        }

        private void TsmClientsMoneyToClients_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "تحويل من عميل الى عميل";
            if (ClientsMoneyToClients1 == null || ClientsMoneyToClients1.IsDisposed == true)
            {
                ClientsMoneyToClients1 = new ClientsMoneyToClients();
            }
            ClientsMoneyToClients1.MdiParent = this;
            ClientsMoneyToClients1.Show();
        }

        private void TsmProductMake_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void TsmProductMakeNew_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "تصنيع منتج";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (ProducerMake1 == null || ProducerMake1.IsDisposed == true)
            {
                ProducerMake1 = new ProducerMake();
            }
            ProducerMake1.MdiParent = this;
            ProducerMake1.Show();
        }

        private void TsmProductMakeAddMaterial_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة خامات";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (MaterialsAdd == null || MaterialsAdd.IsDisposed == true)
            {
                MaterialsAdd = new MaterialsAdd();
            }
            MaterialsAdd.MdiParent = this;
            MaterialsAdd.Show();
        }

        private void textBassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TsmInstallment_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "التقسيط";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (Installment1 == null || Installment1.IsDisposed == true)
            {
                Installment1 = new Installment();
            }
            Installment1.MdiParent = this;
            Installment1.Show();
        }

        private void TsmProductMakeAddMateriall_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة خامات";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (MaterialsAdd == null || MaterialsAdd.IsDisposed == true)
            {
                MaterialsAdd = new MaterialsAdd();
            }
            MaterialsAdd.MdiParent = this;
            MaterialsAdd.Show();
        }

        private void TsmProductMakeNeww_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "تصنيع منتج";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (ProducerMake1 == null || ProducerMake1.IsDisposed == true)
            {
                ProducerMake1 = new ProducerMake();
            }
            ProducerMake1.MdiParent = this;
            ProducerMake1.Show();
        }

        private void TsmPrograms_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://alwasif.blogspot.com/search/label/%D8%A8%D8%B1%D8%A7%D9%85%D8%AC%20%D8%AD%D8%B3%D8%A7%D8%A8%D9%8A%D8%A9");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetValueMonth();
            //==========================  تسجيل الحركات  ========================== 

            saveEvents("تم غلق البرنامج وتسجيل الخروج للمستخدم  " + AppSetting.user);

            //========================== ========================== =================

            Application.Exit();
        }

        private void شئونماليهToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void شئونماليهToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void شئونماليهToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void شئونماليهToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            //شئونماليهToolStripMenuItem.ForeColor = Color.Red;
        }

        private void tsmGroup_Name_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة مجموعة للاصناف";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (CategoryGroup1 == null || CategoryGroup1.IsDisposed == true)
            {
                CategoryGroup1 = new CategoryGroup();
            }
            CategoryGroup1.MdiParent = this;
            CategoryGroup1.Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "فاتورة مبيعات";

            if (Sales1 == null || Sales1.IsDisposed == true)
            {
                Sales1 = new Sales();
            }
            Sales1.MdiParent = this;
            Sales1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "فاتورة مشتريات";

            //----------------------------
            if (Purchases1 == null || Purchases1.IsDisposed == true)
            {
                Purchases1 = new Purchases();
            }
            Purchases1.MdiParent = this;
            Purchases1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة عميل";
            //staticfield12.text1 = textBox30.Text;

            //---------------------
            if (ClientAdd1 == null || ClientAdd1.IsDisposed == true)
            {
                ClientAdd1 = new ClientAdd();
            }
            ClientAdd1.MdiParent = this;
            ClientAdd1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الجرد";

            if (Inventory1 == null || Inventory1.IsDisposed == true)
            {
                Inventory1 = new Inventory();
            }
            Inventory1.MdiParent = this;
            Inventory1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;


            TransferData.FormName = "المعاملات اليومية";

            if (DailyTransactions1 == null || DailyTransactions1.IsDisposed == true)
            {
                DailyTransactions1 = new DailyTransactions();
            }
            DailyTransactions1.MdiParent = this;
            DailyTransactions1.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            TransferData.FormName = "كشف حساب عميل";

            if (ClientAccountStatement1 == null || ClientAccountStatement1.IsDisposed == true)
            {
                ClientAccountStatement1 = new ClientAccountStatement();
            }
            ClientAccountStatement1.MdiParent = this;
            ClientAccountStatement1.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            TransferData.FormName = "قائمة العملاء";

            if (ClientsList1 == null || ClientsList1.IsDisposed == true)
            {
                ClientsList1 = new ClientsList();
            }
            ClientsList1.MdiParent = this;
            ClientsList1.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            TransferData.FormName = "حركة الصندوق";

            if (BoxMovement1 == null || BoxMovement1.IsDisposed == true)
            {
                BoxMovement1 = new BoxMovement();
            }
            BoxMovement1.MdiParent = this;
            BoxMovement1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Expenses1 == null || Expenses1.IsDisposed == true)
            {
                Expenses1 = new Expenses();
            }
            Expenses1.MdiParent = this;
            Expenses1.Show();
        }

        private void القائمةالجانبيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(panlMenu.Visible==true)
            {
                panlMenu.Visible = false;
            }
            else
            {
                panlMenu.Visible = true;
            }
        }

        private void الأحداثاليوميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الأحداث اليومية";
            if (Events1 == null || Events1.IsDisposed == true)
            {
                Events1 = new Events();
            }
            Events1.MdiParent = this;
            Events1.Show();
        }

        private void الوصيفللبرمجيــــــاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alwasif.blogspot.com");
        }

        private void TsmPurchases_Yadaey_Click(object sender, EventArgs e)
        {
            
        }

        private void TsmDailyClosing_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الختام اليومى";
            if (DailyClosing1 == null || DailyClosing1.IsDisposed == true)
            {
                DailyClosing1 = new DailyClosing();
            }
            DailyClosing1.MdiParent = this;
            DailyClosing1.Show();

        }

        private void TsmSalesNoSave_Click(object sender, EventArgs e)
        {


            TransferData.FormName = "فاتورة مبيعات غير معتمدة";

            if (Sales1 == null || Sales1.IsDisposed == true)
            {
                Sales1 = new Sales();
            }
            Sales1.MdiParent = this;
            Sales1.Show();

        }

        private void جديدالاصداراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VersionNew1 == null || VersionNew1.IsDisposed == true)
            {
                VersionNew1 = new VersionNew();
            }
            VersionNew1.MdiParent = this;
            VersionNew1.Show();
        }

        private void tsmFactionCategoreyAdd_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "إضافة فئة للاصناف";
            //staticfield12.text1 = textBox30.Text;

            //---------------------------------
            if (FactionCategoreyAdd1 == null || FactionCategoreyAdd1.IsDisposed == true)
            {
                FactionCategoreyAdd1 = new FactionCategoreyAdd();
            }
            FactionCategoreyAdd1.MdiParent = this;
            FactionCategoreyAdd1.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            GetValueMonth();


            if (panel4.Visible==true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
        }

        private void panlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            GetValueMonth();
        }

        private void TsmStatistical_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "الختام اليومى";
            if (Statistical1 == null || Statistical1.IsDisposed == true)
            {
                Statistical1 = new Statistical();
            }
            Statistical1.MdiParent = this;
            Statistical1.Show();

        }

        private void TsmRASMALL_Click(object sender, EventArgs e)
        {
            GetValueMonth();


            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void إضافةسريالاتالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "اضافة سريالات الاصناف";

            if (ProducerAddSN1 == null ||ProducerAddSN1.IsDisposed == true)
            {
                ProducerAddSN1 = new ProducerAddSN();
            }
            ProducerAddSN1.MdiParent = this;
            ProducerAddSN1.Show();
        }

        private void TsmProducerAddBarcodeFactory_Click(object sender, EventArgs e)
        {
            


            if (CurrentUser.ProducerAddBarcodeFactory == 0)
            {
                MessageBox.Show("ليس لديك صلاحية");
                return;
            }

            TransferData.FormName = "اضافة باركود المصنع";

            if (ProducerAddBarcodeFactory1 == null || ProducerAddBarcodeFactory1.IsDisposed == true)
            {
                ProducerAddBarcodeFactory1 = new ProducerAddBarcodeFactory();
            }
            ProducerAddBarcodeFactory1.MdiParent = this;
            ProducerAddBarcodeFactory1.Show();
        }

        private void TsmFirst_Term_Osol_Click(object sender, EventArgs e)
        {
            TransferData.FormName = "اضافة اصول ثابتة";

            if (OsolSabta1 == null || OsolSabta1.IsDisposed == true)
            {
                OsolSabta1 = new OsolSabta();
            }
            OsolSabta1.MdiParent = this;
            OsolSabta1.Show();
        }

        private void TsmOccasionsForm_Click(object sender, EventArgs e)
        {
            if (OccasionsForm1 == null || OccasionsForm1.IsDisposed == true)
            {
                OccasionsForm1 = new OccasionsForm();
            }
            OccasionsForm1.MdiParent = this;
            OccasionsForm1.Show();
        }

        private void TSMTermsandConditions_Click(object sender, EventArgs e)
        {
            if (TermsandConditions1 == null || TermsandConditions1.IsDisposed == true)
            {
                TermsandConditions1 = new TermsandConditions();
            }
            TermsandConditions1.MdiParent = this;
            TermsandConditions1.Show();
        }

        private void TsmStatisticalFrmBillingSummary_Click(object sender, EventArgs e)
        {
            if (FrmBillingSummary1 == null || FrmBillingSummary1.IsDisposed == true)
            {
                FrmBillingSummary1 = new FrmBillingSummary();
            }
            FrmBillingSummary1.MdiParent = this;
            FrmBillingSummary1.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //PriceViewer frm = new PriceViewer();
            //frm.Show();


            if (PriceViewer1 == null || PriceViewer1.IsDisposed == true)
            {
                PriceViewer1 = new PriceViewer();
            }
            PriceViewer1.MdiParent = this;
            PriceViewer1.Show();

        }

        private void TsmPriceViewer_Click(object sender, EventArgs e)
        {
            if (PriceViewer1 == null || PriceViewer1.IsDisposed == true)
            {
                PriceViewer1 = new PriceViewer();
            }
            PriceViewer1.MdiParent = this;
            PriceViewer1.Show();
        }
    }
}
