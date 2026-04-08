using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace ZAD_Sales
{
    class AppSetting
    {
        Configuration config;




        //-------------------  Barcode_Seting  --------------------------

        public static string BarcodeStart = "";
        public static string BarcodePrinter = "";
        public static string BarcodeSize = "";
        public static string BarcodeTypeFont = "";
        public static string BarcodeFontSize = "";
        public static string ProductSize = "";
        public static string MarginsCompaneyX = "";
        public static string MarginsCompaneyY = "";
        public static string MarginsBarcodeX = "";
        public static string MarginsBarcodeY = "";
        public static string MarginsCategorysX = "";
        public static string MarginsCategorysY = "";
        public static string MarginsCategoryIDX = "";
        public static string MarginsCategoryIDY = "";
        public static string MarginsPriceX = "";
        public static string MarginsPriceY = "";

        public static string BarcodeSeparator = "";
        //------------------- End Barcode_Seting  -----------------------



        public static string textGomlaKataey = "";
        public static string textKataey = "";
        public static string textCompany_Name = "";
        public static string textCompany_Description = "";
        public static string textCompany_Address = "";
        public static string textCompany_Phone = "";
        public static Image pic_logo;
        public static string NoteToBill = "";
        public static string PrinterBill = "";
        public static string SizePaperBill = "";
        public static string PrinterBarcode = "";
        public static string FontSizeBarcode = "";
        public static string PriceSheraaAcount = "";
        public static string BathBackup = "";
        public static string Comp_Logo = "";
       // public static string BarcodeStart = "";
        public static string TypeBillDefoult = "";
        public static string TypeCurrency = "";
        public static string TypeFont = "";
        public static string UseLimitCredit = "";
        public static string NumBillToBarcodeForm = "";
        public static string DiscountBill = "0";
        public static string BarcodeSales = "0";
        public static string BarcodeSalesType = "0";

        public static string CollectionProduct = "0";
        public static string HideBalance = "0";
        public static string TypePrinter = "";
      //  public static string BarcodeSize = "";
        public static string OpenFormOther = ""; // --- فتح اكثر من شاشة مبيعات
        public static string PricesAll = ""; // --- اظهار الاسعار جملة الجملة ونصف الجملة






        //------ report setting -------------------
        public static string date_From = "";
        public static string date_To = "";
        public static string client_name = "";
        public static string PrintNameComToBill = "";
        public static string PrintLogoComToBill = "";
        public static string TypePrice = "";

        //----------------- Bill Print ------------------

        public static string ClintID = "";
        public static string ClintName = "";
        public static string dateTimePicker1 = "";
        public static string TotalBill = "";
        public static string RemaningOld = "";
        public static string textBox27 = "";
        public static string Mosadad = "";
        public static string RemainingNow = "";
        public static string Dic = "";
        public static string textBox30 = "";

        public static string dateTimePicker2 = "";
        public static string textBox57 = "";
        public static string BillingDataNumBill = "";
        public static string TypeBill = "";
        public static string MoveBill = "";
        public static string DemoOnBill = "";

        public static string Clientall = "";

        //--------------------------------

        public static string ValueeProducerIncomplete = "0";
        //--------------- ايصال ------------------
        public static string AddMoney = "";
        public static string Note = "";
        public static string NumRest = "";
        public static string TyprReceipt = "";
        //--------------- User Name --------------------
        public static string user = "";

        //--------------- Category Move --------------------
        public static string Category = "";

        public static string TotalClientsMoney = "";

        //----------------------------------
        
            public static string Total_Bill = "0";
        public static string Total_Paid = "0";
        //------------- الصلاحيات -------------------
        public static string TestBasswordUser = "0";
        public static string TestIdUser = "0";
        public static string Sales = "0";
        public static string Purchases = "0";
        public static string Expenses = "0";
        public static string MoneyToBox = "0";
        public static string MoneyFromBox = "0";
        public static string GroupAdd = "0";
        public static string EmployeeAdd = "0";
        public static string EmployeeSalaryPayment = "0";
        public static string EmployeeSalaryMovement = "0";
        public static string EmployeeBonusAdd = "0";
        public static string EmployeePenaltyAdd = "0";
        public static string CarsAdd = "0";
        public static string CarsExpenses = "0";
        public static string CarsExpensesMovement = "0";
        public static string BackupSave = "0";
        public static string BackupRestore = "0";
        public static string SettingsGeneral = "0";
        public static string SystemReset = "0";
        public static string License = "0";
        public static string CallUs = "0";
        public static string ClientAdd = "0";
        public static string ClientsMoney = "0";
        public static string ExplainSystem = "0";
        public static string Connection = "0";
        public static string ProducerNewAdd = "0";
        public static string StoreNewAdd = "0";
        public static string Prices = "0";
        public static string ProducerUpdate = "0";
        public static string Inventory = "0";
        public static string Barcode = "0";
        public static string ProducerIncomplete = "0";
        public static string StoreToStore = "0";
        public static string ProductMovement = "0";
        public static string BoxMovement = "0";
        public static string ClientsList = "0";
        public static string BanksList = "0";
        public static string Profits = "0";
        public static string DailySalesPurchases = "0";
        public static string DailyTransactions = "0";
        public static string FinancialStatements = "0";
        public static string BankAddAccount = "0";
        public static string CheckSaderWared = "0";
        public static string CheckSave = "0";
        public static string BankStatement = "0";
        public static string BankToBank = "0";
        public static string ClientAccountStatement = "0";
        public static string UserAdd1 = "0";
        public static string AllowUser = "0";
        public static string FirstAccounts = "0";
        public static string b = "0";
        public static string Statistical = "0";

        public static string c = "0";
        public static string d = "0";
        public static string g = "0";
        //-------------------------------------------




        public class staticfieldcar
        {
            public static string text = "";
            public static string text1 = "";
            public static string text2 = "";
            public static string text3 = "";
            public static string text4 = "";
            public static string text5 = "";
            public static string text6 = "";
            public static string text7 = "";
            public static string text8 = "";
            public static string text9 = "";
            public static string text10 = "";



            //عملاء

        }

        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public string GetconnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        public void SaveconnctionString(string key, string value)
        {
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            config.Save(ConfigurationSaveMode.Modified);
        }


    }
}
