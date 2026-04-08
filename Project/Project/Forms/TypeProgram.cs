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
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace ZAD_Sales.Forms
{
    public partial class TypeProgram : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        //-----------------------------------------------------
        private SqlDataReader red;

        string texthddserial1 = "";
        License License1;
        public TypeProgram()
        {
            InitializeComponent();

            string Demo = Properties.Settings.Default.Demo; //يقرا من الخصائص

            if (Demo == "")
            {
                panel2.Visible = true;
                panelType.Visible = false;
                panelUser.Visible = false;



                //----- نختار نوع النسخة تجريبية او اصلية
                //MessageBox.Show("  اختار نسختك   ", "اختار", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //if (TypeProgram1 == null || TypeProgram1.IsDisposed == true)
                //{
                //    //TransferData.CodePrograms = Get_Procces_ID();
                //    TypeProgram1 = new TypeProgram();
                //}
                ////Altarkhes.MdiParent = this;
                //TypeProgram1.ShowDialog();


                //Application.Exit();
                //this.Close();
            }
            else if (Demo == "yes")
            {
                panelType.Visible = false;
                panelUser.Visible = true;



                //--- يفتح بدون ترخيص مع تفعيل كود الفترة التجريبية

                //----------------------- الفترة التجريبية -------------
                try
                {
                    sqlCommand1.Connection = sqlConnection1;


                    //    نسخةتجريبيةToolStripMenuItem.Visible = true;

                    string NumBill = "0";
                    sqlConnection1.Open();

                    sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
                    red = sqlCommand1.ExecuteReader();
                    while (red.Read())
                    {
                        double s = Convert.ToDouble(red["NumBill"].ToString());
                        double aa = s + 1;
                        NumBill = aa.ToString();


                    }
                    red.Close();
                    sqlConnection1.Close();
                    //  =============== فترة تجريبية ===================
                    double asa = Convert.ToDouble(NumBill);

                    if (asa >= 500)
                    {


                        MessageBox.Show("    نأسف تم انتهاء الفترة التجريبية اتصل بنا على 01224349933     ", "الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Information);



                        //Application.Exit();
                        // this.Close();

                        panel2.Visible = false;
                        panelType.Visible = false;
                        panelUser.Visible = false;
                        lab_SERVER.Visible = false;
                        panel3.Visible = true;

                        License FM = new License();
                        FM.Show();

                       
                    }
                    else
                    {

                    }
                }
                catch
                { }

            }
            else if (Demo == "no")
            {

                panelType.Visible = false;
                panelUser.Visible = true;


                // --- نضع هنا كود الترخيص

                //============================ ترخيص البرنامج =============================

                string texthddserial = Properties.Settings.Default.sn; //يقرا من الخصائص
                                                                       //string texthddserial1 = "";



                //****** يقرا من ملف *****************
                //StreamReader sr = new StreamReader(@".\zh.txt");
                //string hddsrial = sr.ReadLine();
                //texthddserial = hddsrial;
                //*****************************************


                //****** HDD SERIALNUMBER ايجار رقم الهارد*****************

                //ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
                //dsk.Get();
                //string id = dsk["VolumeSerialNumber"].ToString();
                //texthddserial1 = "H2646MHM545E." + id.ToString() + ".H2646MHM545E";

                //**************  ايجاد الماك ادرس******************

                //texthddserial1 = "H2646MHM545E." + GetMacAddress().ToString() + ".H2646MHM545E";

                //*********************************************


                texthddserial1 = Tashfer.Get_Procces_ID();
                texthddserial1 = "ZAD-" + texthddserial1.Remove(5) + "-" + texthddserial1.Substring(5, 5).ToUpper();

                texthddserial1 = Tashfer.Get_Tashfer(texthddserial1);

                if (texthddserial == texthddserial1)
                {


                    sqlCommand1.Connection = sqlConnection1;

                }
                else
                {
                    if (License1 == null || License1.IsDisposed == true)
                    {
                        //TransferData.CodePrograms = Get_Procces_ID();
                        License1 = new License();
                    }
                    //Altarkhes.MdiParent = this;
                    License1.ShowDialog();
                }

                //===================== نهاية الترخيص ===============================================
            }
        }

        private void butOreginal_Click(object sender, EventArgs e)
        {
            //this.Close();


            License1 = new License();
            License1.Show();





        }

        private void butDemo_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Demo = "yes";
            Properties.Settings.Default.Save();

            MessageBox.Show("  تم اختيار نسخة تجريبية تعمل لفترة معينة وتتوقف حتى يتم الترخيص   ", "نسخة تجريبية", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //---------------------------------------
            Main formm = new Main();
            formm.Show();

            this.Visible = false;

        }

        private void TypeProgram_Load(object sender, EventArgs e)
        {
            //textBox1.Text= Properties.Settings.Default.DataName;
        }
        public void User_Powers()
        {
            //RemoveChBox();
            string TestBasswordUser = "0";
            string TestIdUser = "0";
            string Sales = "0";
            string Purchases = "0";
            string Expenses = "0";
            string MoneyToBox = "0";
            string MoneyFromBox = "0";
            string GroupAdd = "0";
            string EmployeeAdd = "0";
            string EmployeeSalaryPayment = "0";
            string EmployeeSalaryMovement = "0";
            string EmployeeBonusAdd = "0";
            string EmployeePenaltyAdd = "0";
            string CarsAdd = "0";
            string CarsExpenses = "0";
            string CarsExpensesMovement = "0";
            string BackupSave = "0";
            string BackupRestore = "0";
            string SettingsGeneral = "0";
            string SystemReset = "0";
            string License = "0";
            string CallUs = "0";
            string ClientAdd = "0";
            string ClientsMoney = "0";
            string ExplainSystem = "0";
            string Connection = "0";
            string ProducerNewAdd = "0";
            string StoreNewAdd = "0";
            string Prices = "0";
            string ProducerUpdate = "0";
            string Inventory = "0";
            string Barcode = "0";
            string ProducerIncomplete = "0";
            string StoreToStore = "0";
            string ProductMovement = "0";
            string BoxMovement = "0";
            string ClientsList = "0";
            string BanksList = "0";
            string Profits = "0";
            string DailySalesPurchases = "0";
            string DailyTransactions = "0";
            string FinancialStatements = "0";
            string BankAddAccount = "0";
            string CheckSaderWared = "0";
            string CheckSave = "0";
            string BankStatement = "0";
            string BankToBank = "0";
            string ClientAccountStatement = "0";
            string UserAdd1 = "0";
            string AllowUser = "0";
            string Statistical = "0";
            string FirstAccounts = "0";
            string b = "0";
            string c = "0";
            string d = "0";
            string g = "0";


            sqlConnection1.Open();

            sqlCommand1.CommandText = "select * from Users where UserName ='" + textUserName.Text + "' ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                // textBox1.Text = red["UserName"].ToString();
                TestIdUser = red["ID"].ToString();
                TestBasswordUser = red["Bassword"].ToString();
                Sales = red["Sales"].ToString();
                Purchases = red["Purchases"].ToString();
                Expenses = red["Expenses"].ToString();
                MoneyToBox = red["MoneyToBox"].ToString();
                MoneyFromBox = red["MoneyFromBox"].ToString();
                GroupAdd = red["GroupAdd"].ToString();
                EmployeeAdd = red["EmployeeAdd"].ToString();
                EmployeeSalaryPayment = red["EmployeeSalaryPayment"].ToString();
                EmployeeSalaryMovement = red["EmployeeSalaryMovement"].ToString();
                EmployeeBonusAdd = red["EmployeeBonusAdd"].ToString();
                EmployeePenaltyAdd = red["EmployeePenaltyAdd"].ToString();
                CarsAdd = red["CarsAdd"].ToString();
                CarsExpenses = red["CarsExpenses"].ToString();
                CarsExpensesMovement = red["CarsExpensesMovement"].ToString();
                BackupSave = red["BackupSave"].ToString();
                BackupRestore = red["BackupRestore"].ToString();
                SettingsGeneral = red["SettingsGeneral"].ToString();
                SystemReset = red["SystemReset"].ToString();
                License = red["License"].ToString();
                CallUs = red["CallUs"].ToString();
                ClientAdd = red["ClientAdd"].ToString();
                ClientsMoney = red["ClientsMoney"].ToString();
                ExplainSystem = red["ExplainSystem"].ToString();
                Connection = red["Connection"].ToString();
                ProducerNewAdd = red["ProducerNewAdd"].ToString();
                StoreNewAdd = red["StoreNewAdd"].ToString();
                Prices = red["Prices"].ToString();
                ProducerUpdate = red["ProducerUpdate"].ToString();
                Inventory = red["Inventory"].ToString();
                Barcode = red["Barcode"].ToString();
                ProducerIncomplete = red["ProducerIncomplete"].ToString();
                StoreToStore = red["StoreToStore"].ToString();
                ProductMovement = red["ProductMovement"].ToString();
                BoxMovement = red["BoxMovement"].ToString();
                ClientsList = red["ClientsList"].ToString();
                BanksList = red["BanksList"].ToString();
                Profits = red["Profits"].ToString();
                DailySalesPurchases = red["DailySalesPurchases"].ToString();
                DailyTransactions = red["DailyTransactions"].ToString();
                FinancialStatements = red["FinancialStatements"].ToString();
                BankAddAccount = red["BankAddAccount"].ToString();
                CheckSaderWared = red["CheckSaderWared"].ToString();
                CheckSave = red["CheckSave"].ToString();
                BankStatement = red["BankStatement"].ToString();
                BankToBank = red["BankToBank"].ToString();
                ClientAccountStatement = red["ClientAccountStatement"].ToString();

                UserAdd1 = red["UserAdd1"].ToString();
                FirstAccounts = red["FirstAccounts"].ToString();
                AllowUser = red["AllowUser"].ToString();
                Statistical = red["Statistical"].ToString();

            }
            red.Close();


            if (textBassword.Text == TestBasswordUser)
            {


                AppSetting.user = textUserName.Text;// حفظ اسم المستخدم
                AppSetting.TestIdUser = TestIdUser;
                AppSetting.TestBasswordUser = TestBasswordUser;
                AppSetting.Sales = Sales;
                AppSetting.Purchases = Purchases;
                AppSetting.Expenses = Expenses;
                AppSetting.MoneyToBox = MoneyToBox;
                AppSetting.MoneyFromBox = MoneyFromBox;
                AppSetting.GroupAdd = GroupAdd;
                AppSetting.EmployeeAdd = EmployeeAdd;
                AppSetting.EmployeeSalaryPayment = EmployeeSalaryPayment;
                AppSetting.EmployeeSalaryMovement = EmployeeSalaryMovement;
                AppSetting.EmployeeBonusAdd = EmployeeBonusAdd;
                AppSetting.EmployeePenaltyAdd = EmployeePenaltyAdd;
                AppSetting.CarsAdd = CarsAdd;
                AppSetting.CarsExpenses = CarsExpenses;
                AppSetting.CarsExpensesMovement = CarsExpensesMovement;
                AppSetting.BackupSave = BackupSave;
                AppSetting.BackupRestore = BackupRestore;
                AppSetting.SettingsGeneral = SettingsGeneral;
                AppSetting.SystemReset = SystemReset;
                AppSetting.License = License;
                AppSetting.CallUs = CallUs;
                AppSetting.ClientAdd = ClientAdd;
                AppSetting.ClientsMoney = ClientsMoney;
                AppSetting.ExplainSystem = ExplainSystem;
                AppSetting.Connection = Connection;
                AppSetting.ProducerNewAdd = ProducerNewAdd;
                AppSetting.StoreNewAdd = StoreNewAdd;
                AppSetting.Prices = Prices;
                AppSetting.ProducerUpdate = ProducerUpdate;
                AppSetting.Inventory = Inventory;
                AppSetting.Barcode = Barcode;
                AppSetting.ProducerIncomplete = ProducerIncomplete;
                AppSetting.StoreToStore = StoreToStore;
                AppSetting.ProductMovement = ProductMovement;
                AppSetting.BoxMovement = BoxMovement;
                AppSetting.ClientsList = ClientsList;
                AppSetting.BanksList = BanksList;
                AppSetting.Profits = Profits;
                AppSetting.DailySalesPurchases = DailySalesPurchases;
                AppSetting.DailyTransactions = DailyTransactions;
                AppSetting.FinancialStatements = FinancialStatements;
                AppSetting.BankAddAccount = BankAddAccount;
                AppSetting.CheckSaderWared = CheckSaderWared;
                AppSetting.CheckSave = CheckSave;
                AppSetting.BankStatement = BankStatement;
                AppSetting.BankToBank = BankToBank;
                AppSetting.ClientAccountStatement = ClientAccountStatement;

                AppSetting.UserAdd1 = UserAdd1;
                AppSetting.FirstAccounts = FirstAccounts;
                AppSetting.AllowUser = AllowUser;
                AppSetting.Statistical = Statistical;

                //---------------------------------------
                Main formm = new Main();
                formm.Show();

                this.Visible = false;

            }
            else
            {
                MessageBox.Show("      يوجد خطأ فى كلمة السر أو الباسورد           ", "  خطأ  ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            sqlConnection1.Close();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            User_Powers();




            
        }

        private void textBassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // butLogin.Focus();
                butLogin.PerformClick();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Version = combVersion.Text;

            panel2.Visible = false;
            panelType.Visible = true;
        }

        private void lab_SERVER_Click(object sender, EventArgs e)
        {
            //if (Connection1 == null || Connection1.IsDisposed == true)
            //{
            //    Connection1 = new Connection();
            //}
            //Connection1.MdiParent = this;
            //Connection1.Show();


            //Form FM = new Form();

            Connection FM = new Connection();
            FM.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
