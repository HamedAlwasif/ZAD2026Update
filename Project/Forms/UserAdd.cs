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

namespace ZAD_Sales.Forms
{
    public partial class UserAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        //-----------------------------------------------------
        private SqlDataReader red;

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
        string FirstAccounts = "0";
        string AllowUser = "0";
        string Statistical = "0";


        string b = "0";
        string c = "0";
        string d = "0";
        string g = "0";

        public UserAdd()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
        }

        public void RemoveChBox()
        {
            chB_Sales.Checked = false;
            chB_Purchases.Checked = false;
            chB_Expenses.Checked = false;
            chB_MoneyToBox.Checked = false;
            chB_MoneyFromBox.Checked = false;
            chB_GroupAdd.Checked = false;
            chB_EmployeeAdd.Checked = false;
            chB_EmployeeSalaryPayment.Checked = false;
            chB_EmployeeSalaryMovement.Checked = false;
            chB_EmployeeBonusAdd.Checked = false;
            chB_EmployeePenaltyAdd.Checked = false;
            chB_CarsAdd.Checked = false;
            chB_CarsExpenses.Checked = false;
            chB_CarsExpensesMovement.Checked = false;
            chB_BackupSave.Checked = false;
            chB_BackupRestore.Checked = false;
            //chB_SettingsGeneral.Checked = false;
            chB_SystemReset.Checked = false;
            //chB_License.Checked = false;
            //chB_CallUs.Checked = false;
            chB_ClientAdd.Checked = false;
            chB_ClientsMoney.Checked = false;
            //chB_ExplainSystem.Checked = false;
            //chB_Connection.Checked = false;
            chB_ProducerNewAdd.Checked = false;
            chB_StoreNewAdd.Checked = false;
            chB_Prices.Checked = false;
            chB_ProducerUpdate.Checked = false;
            chB_Inventory.Checked = false;
            //chB_Barcode.Checked = false;
            //chB_ProducerIncomplete.Checked = false;
            chB_StoreToStore.Checked = false;
            chB_ProductMovement.Checked = false;
            chB_BoxMovement.Checked = false;
            chB_ClientsList.Checked = false;
            chB_BanksList.Checked = false;
            chB_Profits.Checked = false;
            chB_DailySalesPurchases.Checked = false;
            chB_DailyTransactions.Checked = false;
            chB_FinancialStatements.Checked = false;
            chB_BankAddAccount.Checked = false;
            chB_CheckSaderWared.Checked = false;
            chB_CheckSave.Checked = false;
            chB_BankStatement.Checked = false;
            chB_BankToBank.Checked = false;
            chB_ClientAccountStatement.Checked = false;
            chB_UserAdd.Checked = false;
            chB_FirstAccounts.Checked = false;
            chB_SettingsGeneral.Checked =false;
            chB_AllowUser.Checked =false;
            chB_Statistical.Checked =false;


        }

        private void chB_AddCategorey_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ProducerNewAdd.Checked == true)
            {
                ProducerNewAdd = "1";
            }
            else
            {
                ProducerNewAdd = "0";
            }
           
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCommand1.CommandText = "insert into Users (UserName,Bassword,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,bb,cc,dd,ee,ff,gg,hh,ii,jj,kk,ll,mm,nn,oo,pp,qq,rr,ss,tt,uu,vv,ww,xx,yy,zz)values ('" + textBox18.Text + "','" + textBox19.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox21.Text + "','" + textBox23.Text + "','" + textBox24.Text + "','" + textBox25.Text + "','" + textBox26.Text + "','" + textBox27.Text + "','" + textBox29.Text + "','" + textBox30.Text + "','" + textBox31.Text + "','" + textBox32.Text + "','" + textBox58.Text + "','" + textBox33.Text + "','" + textBox34.Text + "','" + textBox35.Text + "','" + textBox36.Text + "','" + textBox37.Text + "','" + textBox38.Text + "','" + textBox39.Text + "','" + textBox40.Text + "','" + textBox41.Text + "','" + textBox42.Text + "','" + textBox43.Text + "','" + textBox44.Text + "','" + textBox45.Text + "','" + textBox46.Text + "','" + textBox47.Text + "','" + textBox48.Text + "','" + textBox49.Text + "','" + textBox50.Text + "','" + textBox51.Text + "','" + textBox28.Text + "','" + textBox52.Text + "','" + textBox53.Text + "','" + textBox54.Text + "','" + textBox55.Text + "','" + textBox56.Text + "','" + textBox57.Text + "')";

                sqlCommand1.CommandText = "insert into Users (UserName,Bassword,Sales,Purchases,Expenses,MoneyToBox,MoneyFromBox,GroupAdd,EmployeeAdd,EmployeeSalaryPayment,EmployeeSalaryMovement,EmployeeBonusAdd,EmployeePenaltyAdd,CarsAdd,CarsExpenses,CarsExpensesMovement,BackupSave,BackupRestore,SettingsGeneral,SystemReset,License,CallUs,ClientAdd,ClientsMoney,ExplainSystem,Connection,ProducerNewAdd,StoreNewAdd,Prices,ProducerUpdate,Inventory,Barcode,ProducerIncomplete,StoreToStore,ProductMovement,BoxMovement,ClientsList,BanksList,Profits,DailySalesPurchases,DailyTransactions,FinancialStatements,BankAddAccount,CheckSaderWared,CheckSave,BankStatement,BankToBank,ClientAccountStatement,UserAdd1,FirstAccounts,AllowUser,Statistical,b,c,d,g) values ('" + textBox18.Text + "','" + textBox19.Text + "','" + Sales + "','" + Purchases + "','" + Expenses + "','" + MoneyToBox + "','" + MoneyFromBox + "','" + GroupAdd + "','" + EmployeeAdd + "','" + EmployeeSalaryPayment + "','" + EmployeeSalaryMovement + "','" + EmployeeBonusAdd + "','" + EmployeePenaltyAdd + "','" + CarsAdd + "','" + CarsExpenses + "','" + CarsExpensesMovement + "','" + BackupSave + "','" + BackupRestore + "','" + SettingsGeneral + "','" + SystemReset + "','" + License + "','" + CallUs + "','" + ClientAdd+ "','" + ClientsMoney + "','" + ExplainSystem + "','" + Connection + "','" + ProducerNewAdd + "','" + StoreNewAdd + "','" + Prices + "','" + ProducerUpdate + "','" + Inventory + "','" + Barcode + "','" + ProducerIncomplete + "','" + StoreToStore + "','" + ProductMovement + "','" + BoxMovement + "','" + ClientsList + "','" + BanksList + "','" + Profits + "','" + DailySalesPurchases + "','" + DailyTransactions + "','" + FinancialStatements + "','" + BankAddAccount + "','" + CheckSaderWared + "','" + CheckSave+ "','" + BankStatement + "','" + BankToBank + "','" + ClientAccountStatement + "','" + UserAdd1 + "','" + FirstAccounts+ "','" + AllowUser + "','" + Statistical + "','" + b + "','" + c + "','" + d + "','" + g + "')"; 
                sqlCommand1.ExecuteNonQuery();

                MessageBox.Show("    تم إضافة المستخدم الجديد بنجاح   ", "  الاضافة");

        }
            catch
            {

            }
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            //this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Tajawal", 10);


            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select UserName from Users", sqlConnection1);
                Da1.Fill(Dt1);
                comUsers.DataSource = Dt1;
                comUsers.DisplayMember = "UserName";
            }
            catch
            {

            }
        }

        private void chB_Prices_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Prices.Checked == true)
            {
                Prices = "1";
            }
            else
            {
                Prices = "0";
            }
           
        }

        private void chB_ProducerUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ProducerUpdate.Checked == true)
            {
                ProducerUpdate = "1";
            }
            else
            {
                ProducerUpdate = "0";
            }
        }

        private void chB_StoreNewAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_StoreNewAdd.Checked == true)
            {
                StoreNewAdd = "1";
            }
            else
            {
                StoreNewAdd = "0";
            }
        }

        private void chB_StoreToStore_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_StoreToStore.Checked == true)
            {
                StoreToStore = "1";
            }
            else
            {
                StoreToStore = "0";
            }
        }

        private void chB_Inventory_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Inventory.Checked == true)
            {
                Inventory = "1";
            }
            else
            {
                Inventory = "0";
            }
        }

        private void chB_ClientAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ClientAdd.Checked == true)
            {
                ClientAdd = "1";
            }
            else
            {
                ClientAdd = "0";
            }
        }

        private void chB_GroupAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_GroupAdd.Checked == true)
            {
                GroupAdd = "1";
            }
            else
            {
                GroupAdd = "0";
            }
        }

        private void chB_ClientsMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ClientsMoney.Checked == true)
            {
                ClientsMoney = "1";
            }
            else
            {
                ClientsMoney = "0";
            }
        }

        private void chB_Purchases_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Purchases.Checked == true)
            {
                Purchases = "1";
            }
            else
            {
                Purchases = "0";
            }
        }

        private void chB_Sales_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Sales.Checked == true)
            {
                Sales = "1";
            }
            else
            {
                Sales = "0";
            }
        }

        private void chB_PurchasesMaedodat_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_PurchasesMaedodat.Checked == true)
            {
                Purchases = "1";
            }
            else
            {
                Purchases = "0";
            }
        }

        private void chB_SalesMardodat_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_SalesMardodat.Checked == true)
            {
                Sales = "1";
            }
            else
            {
                Sales = "0";
            }
        }

        private void chB_Expenses_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Expenses.Checked == true)
            {
                Expenses = "1";
            }
            else
            {
                Expenses = "0";
            }
        }

        private void chB_MoneyToBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_MoneyToBox.Checked == true)
            {
                MoneyToBox = "1";
            }
            else
            {
                MoneyToBox = "0";
            }
        }

        private void chB_MoneyFromBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_MoneyFromBox.Checked == true)
            {
                MoneyFromBox = "1";
            }
            else
            {
                MoneyFromBox = "0";
            }
        }

        private void chB_UserAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_UserAdd.Checked == true)
            {
                UserAdd1 = "1";
            }
            else
            {
                UserAdd1 = "0";
            }
        }

        private void chB_CarsAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CarsAdd.Checked == true)
            {
                CarsAdd = "1";
            }
            else
            {
                CarsAdd = "0";
            }
        }

        private void chB_CarsExpenses_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CarsExpenses.Checked == true)
            {
                CarsExpenses = "1";
            }
            else
            {
                CarsExpenses = "0";
            }
        }

        private void chB_CarsExpensesMovement_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CarsExpensesMovement.Checked == true)
            {
                CarsExpensesMovement = "1";
            }
            else
            {
                CarsExpensesMovement = "0";
            }
        }

        private void chB_EmployeeAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_EmployeeAdd.Checked == true)
            {
                EmployeeAdd = "1";
            }
            else
            {
                EmployeeAdd = "0";
            }
        }

        private void chB_EmployeeSalaryPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_EmployeeSalaryPayment.Checked == true)
            {
                EmployeeSalaryPayment = "1";
            }
            else
            {
                EmployeeSalaryPayment = "0";
            }
        }

        private void chB_EmployeeSalaryMovement_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_EmployeeSalaryMovement.Checked == true)
            {
                EmployeeSalaryMovement = "1";
            }
            else
            {
                EmployeeSalaryMovement = "0";
            }
        }

        private void chB_EmployeeBonusAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_EmployeeBonusAdd.Checked == true)
            {
                EmployeeBonusAdd = "1";
            }
            else
            {
                EmployeeBonusAdd = "0";
            }
        }

        private void chB_EmployeePenaltyAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_EmployeePenaltyAdd.Checked == true)
            {
                EmployeePenaltyAdd = "1";
            }
            else
            {
                EmployeePenaltyAdd = "0";
            }
        }

        private void chB_BackupSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BackupSave.Checked == true)
            {
                BackupSave = "1";
            }
            else
            {
                BackupSave = "0";
            }
        }

        private void chB_BackupRestore_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BackupRestore.Checked == true)
            {
                BackupRestore = "1";
            }
            else
            {
                BackupRestore = "0";
            }
        }

        private void chB_SystemReset_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_SystemReset.Checked == true)
            {
                SystemReset = "1";
            }
            else
            {
                SystemReset = "0";
            }
        }

        private void chB_FinancialStatements_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_FinancialStatements.Checked == true)
            {
                FinancialStatements = "1";
            }
            else
            {
                FinancialStatements = "0";
            }
        }

        private void chB_DailyTransactions_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_DailyTransactions.Checked == true)
            {
                DailyTransactions = "1";
            }
            else
            {
                DailyTransactions = "0";
            }
        }

        private void chB_ProductMovement_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ProductMovement.Checked == true)
            {
                ProductMovement = "1";
            }
            else
            {
                ProductMovement = "0";
            }
        }

        private void chB_ClientsList_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ClientsList.Checked == true)
            {
                ClientsList = "1";
            }
            else
            {
                ClientsList = "0";
            }
        }

        private void chB_DailySalesPurchases_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_DailySalesPurchases.Checked == true)
            {
                DailySalesPurchases = "1";
            }
            else
            {
                DailySalesPurchases = "0";
            }
        }

        private void chB_BanksList_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BanksList.Checked == true)
            {
                BanksList = "1";
            }
            else
            {
                BanksList = "0";
            }
        }

        private void chB_BoxMovement_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BoxMovement.Checked == true)
            {
                BoxMovement = "1";
            }
            else
            {
                BoxMovement = "0";
            }
        }

        private void chB_ClientAccountStatement_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_ClientAccountStatement.Checked == true)
            {
                ClientAccountStatement = "1";
            }
            else
            {
                ClientAccountStatement = "0";
            }
        }

        private void chB_Profits_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Profits.Checked == true)
            {
                Profits = "1";
            }
            else
            {
                Profits = "0";
            }
        }

        private void checkBox57_CheckedChanged(object sender, EventArgs e)
        {
            //if (chB_UserAdd.Checked == true)
            //{
            //    UserAdd1 = "1";
            //}
            //else
            //{
            //    UserAdd1 = "0";
            //}
        }

        private void chB_BankAddAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BankAddAccount.Checked == true)
            {
                BankAddAccount = "1";
            }
            else
            {
                BankAddAccount = "0";
            }
        }

        private void chB_CheckSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CheckSave.Checked == true)
            {
                CheckSave = "1";
            }
            else
            {
                CheckSave = "0";
            }
        }

        private void chB_CheckSave2_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CheckSave.Checked == true)
            {
                CheckSave = "1";
            }
            else
            {
                CheckSave = "0";
            }
        }

        private void chB_BankStatement_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BankStatement.Checked == true)
            {
                BankStatement = "1";
            }
            else
            {
                BankStatement = "0";
            }
        }

        private void chB_CheckSaderWared_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CheckSaderWared.Checked == true)
            {
                CheckSaderWared = "1";
            }
            else
            {
                CheckSaderWared = "0";
            }
        }

        private void chB_CheckSaderWared2_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_CheckSaderWared2.Checked == true)
            {
                CheckSaderWared = "1";
            }
            else
            {
                CheckSaderWared = "0";
            }
        }

        private void chB_BankToBank_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_BankToBank.Checked == true)
            {
                BankToBank = "1";
            }
            else
            {
                BankToBank = "0";
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "update Users set  UserName='" + textBox18.Text + "',Bassword = '" + textBox19.Text + "',Sales= '" + Sales + "',Purchases= '" + Purchases + "',Expenses= '" + Expenses + "',MoneyToBox= '" + MoneyToBox + "',MoneyFromBox= '" + MoneyFromBox + "',GroupAdd= '" + GroupAdd + "',EmployeeAdd= '" + EmployeeAdd + "',EmployeeSalaryPayment= '" + EmployeeSalaryPayment + "',EmployeeSalaryMovement= '" + EmployeeSalaryMovement + "',EmployeeBonusAdd= '" + EmployeeBonusAdd + "',EmployeePenaltyAdd= '" + EmployeePenaltyAdd + "',CarsAdd= '" + CarsAdd + "',CarsExpenses= '" + CarsExpenses + "',CarsExpensesMovement= '" + CarsExpensesMovement + "',BackupSave= '" + BackupSave + "',BackupRestore= '" + BackupRestore + "',SettingsGeneral= '" + SettingsGeneral + "',SystemReset= '" + SystemReset + "',License= '" + License + "',CallUs= '" + CallUs + "',ClientAdd= '" + ClientAdd + "',ClientsMoney = '" + ClientsMoney + "',ExplainSystem = '" + ExplainSystem + "',Connection = '" + Connection + "',ProducerNewAdd = '" + ProducerNewAdd + "',StoreNewAdd = '" + StoreNewAdd + "',Prices = '" + Prices + "',ProducerUpdate = '" + ProducerUpdate + "',Inventory = '" + Inventory + "',Barcode = '" + Barcode + "',ProducerIncomplete = '" + ProducerIncomplete + "',StoreToStore = '" + StoreToStore + "',ProductMovement = '" + ProductMovement + "',BoxMovement = '" + BoxMovement + "',ClientsList = '" + ClientsList + "',BanksList = '" + BanksList + "',Profits = '" + Profits + "',DailySalesPurchases = '" + DailySalesPurchases + "',DailyTransactions = '" + DailyTransactions + "',FinancialStatements = '" + FinancialStatements + "',BankAddAccount = '" + BankAddAccount + "',CheckSaderWared = '" + CheckSaderWared + "',CheckSave = '" + CheckSave + "',BankStatement = '" + BankStatement + "',BankToBank = '" + BankToBank + "',ClientAccountStatement = '" + ClientAccountStatement + "',UserAdd1 = '" + UserAdd1 + "',FirstAccounts = '" + FirstAccounts + "',AllowUser = '" + AllowUser + "',Statistical = '" + Statistical + "',b = '" + b  + "',c = '" +  c + "',d = '" +  d + "',g = '" +  g + "' where  ID ='" + textBox20.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                MessageBox.Show("    تم التعديل بنجاح   ", "  التعديل");

            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "delete from Users where ID = '" + textBox20.Text + "'   ";
                sqlCommand1.ExecuteNonQuery();

                MessageBox.Show("    تم حذف المستخدم بنجاح   ", "  الحذف");
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buChekAll_Click(object sender, EventArgs e)
        {
            chB_Sales.Checked = true;
            chB_Purchases.Checked = true;
            chB_Expenses.Checked = true;
            chB_MoneyToBox.Checked = true;
            chB_MoneyFromBox.Checked = true;
            chB_GroupAdd.Checked = true;
            chB_EmployeeAdd.Checked = true;
            chB_EmployeeSalaryPayment.Checked = true;
            chB_EmployeeSalaryMovement.Checked = true;
            chB_EmployeeBonusAdd.Checked = true;
            chB_EmployeePenaltyAdd.Checked = true;
            chB_CarsAdd.Checked = true;
            chB_CarsExpenses.Checked = true;
            chB_CarsExpensesMovement.Checked = true;
            chB_BackupSave.Checked = true;
            chB_BackupRestore.Checked = true;
            //chB_SettingsGeneral.Checked = true;
            chB_SystemReset.Checked = true;
            //chB_License.Checked = true;
            //chB_CallUs.Checked = true;
            chB_ClientAdd.Checked = true;
            chB_ClientsMoney.Checked = true;
            //chB_ExplainSystem.Checked = true;
            //chB_Connection.Checked = true;
            chB_ProducerNewAdd.Checked = true;
            chB_StoreNewAdd.Checked = true;
            chB_Prices.Checked = true;
            chB_ProducerUpdate.Checked = true;
            chB_Inventory.Checked = true;
            //chB_Barcode.Checked = true;
            //chB_ProducerIncomplete.Checked = true;
            chB_StoreToStore.Checked = true;
            chB_ProductMovement.Checked = true;
            chB_BoxMovement.Checked = true;
            chB_ClientsList.Checked = true;
            chB_BanksList.Checked = true;
            chB_Profits.Checked = true;
            chB_DailySalesPurchases.Checked = true;
            chB_DailyTransactions.Checked = true;
            chB_FinancialStatements.Checked = true;
            chB_BankAddAccount.Checked = true;
            chB_CheckSaderWared.Checked = true;
            chB_CheckSave.Checked = true;
            chB_BankStatement.Checked = true;
            chB_BankToBank.Checked = true;
            chB_ClientAccountStatement.Checked = true;
            chB_UserAdd.Checked = true;
            chB_FirstAccounts.Checked = true;
            chB_SettingsGeneral.Checked = true;
            chB_AllowUser.Checked = true;

        }

        private void butChekAllRemove_Click(object sender, EventArgs e)
        {
            RemoveChBox();

            //chB_Sales.Checked = false;
            //chB_Purchases.Checked = false;
            //chB_Expenses.Checked = false;
            //chB_MoneyToBox.Checked = false;
            //chB_MoneyFromBox.Checked = false;
            //chB_GroupAdd.Checked = false;
            //chB_EmployeeAdd.Checked = false;
            //chB_EmployeeSalaryPayment.Checked = false;
            //chB_EmployeeSalaryMovement.Checked = false;
            //chB_EmployeeBonusAdd.Checked = false;
            //chB_EmployeePenaltyAdd.Checked = false;
            //chB_CarsAdd.Checked = false;
            //chB_CarsExpenses.Checked = false;
            //chB_CarsExpensesMovement.Checked = false;
            //chB_BackupSave.Checked = false;
            //chB_BackupRestore.Checked = false;
            ////chB_SettingsGeneral.Checked = false;
            //chB_SystemReset.Checked = false;
            ////chB_License.Checked = false;
            ////chB_CallUs.Checked = false;
            //chB_ClientAdd.Checked = false;
            //chB_ClientsMoney.Checked = false;
            ////chB_ExplainSystem.Checked = false;
            ////chB_Connection.Checked = false;
            //chB_ProducerNewAdd.Checked = false;
            //chB_StoreNewAdd.Checked = false;
            //chB_Prices.Checked = false;
            //chB_ProducerUpdate.Checked = false;
            //chB_Inventory.Checked = false;
            ////chB_Barcode.Checked = false;
            ////chB_ProducerIncomplete.Checked = false;
            //chB_StoreToStore.Checked = false;
            //chB_ProductMovement.Checked = false;
            //chB_BoxMovement.Checked = false;
            //chB_ClientsList.Checked = false;
            //chB_BanksList.Checked = false;
            //chB_Profits.Checked = false;
            //chB_DailySalesPurchases.Checked = false;
            //chB_DailyTransactions.Checked = false;
            //chB_FinancialStatements.Checked = false;
            //chB_BankAddAccount.Checked = false;
            //chB_CheckSaderWared.Checked = false;
            //chB_CheckSave.Checked = false;
            //chB_BankStatement.Checked = false;
            //chB_BankToBank.Checked = false;
            //chB_ClientAccountStatement.Checked = false;
            //chB_UserAdd.Checked = false;
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            RemoveChBox();

            sqlCommand1.CommandText = "select * from Users where UserName ='" + comUsers.Text + "' ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                // textBox1.Text = red["UserName"].ToString();
                textBox20.Text = red["ID"].ToString();
                textBox18.Text = red["UserName"].ToString();
                textBox19.Text = red["Bassword"].ToString();
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

                AllowUser = red["AllowUser"].ToString();

                Statistical = red["Statistical"].ToString();

            }
            red.Close();

            if (Sales == "1")
            {
                chB_Sales.Checked = true;
            }

           if (Statistical == "1")
            {
                chB_Statistical.Checked = true;
            }
            //-------------------------------
            if (Purchases == "1")
            {
                chB_Purchases.Checked = true;
            }
           
            if (Expenses == "1")
            {
                chB_Expenses.Checked = true;
            }
            if (Sales == "1")
            {
                chB_Sales.Checked = true;
            }
            if (Purchases == "1")
            {
                chB_Purchases.Checked = true;
            }
            if (Expenses == "1")
            {
                chB_Expenses.Checked = true;
            }
            if (MoneyToBox == "1")
            {
                chB_MoneyToBox.Checked = true;
            }
            if (MoneyFromBox == "1")
            {
                chB_MoneyFromBox.Checked = true;
            }
            if (GroupAdd == "1")
            {
                chB_GroupAdd.Checked = true;
            }
            if (EmployeeAdd == "1")
            {
                chB_EmployeeAdd.Checked = true;
            }
            if (EmployeeSalaryPayment == "1")
            {
                chB_EmployeeSalaryPayment.Checked = true;
            }
            if (EmployeeSalaryMovement == "1")
            {
                chB_EmployeeSalaryMovement.Checked = true;
            }
            if (EmployeeBonusAdd == "1")
            {
                chB_EmployeeBonusAdd.Checked = true;
            }
            if (EmployeePenaltyAdd == "1")
            {
                chB_EmployeePenaltyAdd.Checked = true;
            }
            if (CarsAdd == "1")
            {
                chB_CarsAdd.Checked = true;
            }
            if (CarsExpenses == "1")
            {
                chB_CarsExpenses.Checked = true;
            }
            if (CarsExpensesMovement == "1")
            {
                chB_CarsExpensesMovement.Checked = true;
            }
            if (BackupSave == "1")
            {
                chB_BackupSave.Checked = true;
            }
            if (BackupRestore == "1")
            {
                chB_BackupRestore.Checked = true;
            }
            if (SettingsGeneral == "1")
            {
                chB_SettingsGeneral.Checked = true;
            }
            if (SystemReset == "1")
            {
                chB_SystemReset.Checked = true;
            }
            if (License== "1")
            {
                //chB_License.Checked = true;
            }
            if (CallUs == "1")
            {
                //chB_CallUs.Checked = true;
            }
            if (ClientAdd == "1")
            {
                chB_ClientAdd.Checked = true;
            }
            if (ClientsMoney == "1")
            {
                chB_ClientsMoney.Checked = true;
            }
            if (ExplainSystem == "1")
            {
                //chB_ExplainSystem.Checked = true;
            }
            if (Connection == "1")
            {
                //chB_Connection.Checked = true;
            }
            if (ProducerNewAdd == "1")
            {
                chB_ProducerNewAdd.Checked = true;
            }
            if (StoreNewAdd == "1")
            {
                chB_StoreNewAdd.Checked = true;
            }
            if (Prices == "1")
            {
                chB_Prices.Checked = true;
            }
            if (ProducerUpdate == "1")
            {
                chB_ProducerUpdate.Checked = true;
            }
            if (Inventory == "1")
            {
                chB_Inventory.Checked = true;
            }
            if (Barcode == "1")
            {
                //chB_Barcode.Checked = true;
            }
            if (ProducerIncomplete == "1")
            {
                //chB_ProducerIncomplete.Checked = true;
            }
            if (StoreToStore == "1")
            {
                chB_StoreToStore.Checked = true;
            }
            if (ProductMovement == "1")
            {
                chB_ProductMovement.Checked = true;
            }
            if (BoxMovement == "1")
            {
                chB_BoxMovement.Checked = true;
            }
            if (ClientsList == "1")
            {
                chB_ClientsList.Checked = true;
            }
            if (BanksList == "1")
            {
                chB_BanksList.Checked = true;
            }
            if (Profits == "1")
            {
                chB_Profits.Checked = true;
            }
            if (DailySalesPurchases == "1")
            {
                chB_DailySalesPurchases.Checked = true;
            }
            if (DailyTransactions == "1")
            {
                chB_DailyTransactions.Checked = true;
            }
            if (FinancialStatements == "1")
            {
                chB_FinancialStatements.Checked = true;
            }
            if (BankAddAccount == "1")
            {
                chB_BankAddAccount.Checked = true;
            }
            if (CheckSaderWared == "1")
            {
                chB_CheckSaderWared.Checked = true;
            }
            if (CheckSave == "1")
            {
                chB_CheckSave.Checked = true;
            }

            if (BankStatement == "1")
            {
                chB_BankStatement.Checked = true;
            }

            if (BankToBank == "1")
            {
                chB_BankToBank.Checked = true;
            }

            if (ClientAccountStatement == "1")
            {
                chB_ClientAccountStatement.Checked = true;
            }
            if (UserAdd1 == "1")
            {
                chB_UserAdd.Checked = true;
            }

            if (AllowUser == "1")
            {
                chB_AllowUser.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            RemoveChBox();

            chB_Sales.Checked = true;
            chB_Purchases.Checked = true;
            chB_Expenses.Checked = true;
            chB_MoneyToBox.Checked = true;
            chB_MoneyFromBox.Checked = true;
            chB_GroupAdd.Checked = true;
            chB_EmployeeAdd.Checked = true;
            chB_EmployeeSalaryPayment.Checked = true;
            chB_EmployeeSalaryMovement.Checked = true;
           // chB_EmployeeBonusAdd.Checked = true;
         //   chB_EmployeePenaltyAdd.Checked = true;
           // chB_CarsAdd.Checked = true;
            chB_CarsExpenses.Checked = true;
            chB_CarsExpensesMovement.Checked = true;
            chB_BackupSave.Checked = true;
           // chB_BackupRestore.Checked = true;
            //chB_SettingsGeneral.Checked = true;
           // chB_SystemReset.Checked = true;
            //chB_License.Checked = true;
            //chB_CallUs.Checked = true;
            chB_ClientAdd.Checked = true;
            chB_ClientsMoney.Checked = true;
            //chB_ExplainSystem.Checked = true;
            //chB_Connection.Checked = true;
            chB_ProducerNewAdd.Checked = true;
           // chB_StoreNewAdd.Checked = true;
          //  chB_Prices.Checked = true;
          //  chB_ProducerUpdate.Checked = true;
            chB_Inventory.Checked = true;
            //chB_Barcode.Checked = true;
            //chB_ProducerIncomplete.Checked = true;
            chB_StoreToStore.Checked = true;
            chB_ProductMovement.Checked = true;
            chB_BoxMovement.Checked = true;
            chB_ClientsList.Checked = true;
            chB_BanksList.Checked = true;
         //   chB_Profits.Checked = true;
            chB_DailySalesPurchases.Checked = true;
            chB_DailyTransactions.Checked = true;
           // chB_FinancialStatements.Checked = true;
          //  chB_BankAddAccount.Checked = true;
            chB_CheckSaderWared.Checked = true;
            chB_CheckSave.Checked = true;
          //  chB_BankStatement.Checked = true;
          //  chB_BankToBank.Checked = true;
            chB_ClientAccountStatement.Checked = true;
          //  chB_UserAdd.Checked = true;
        }

        private void chB_FirstAccounts_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_FirstAccounts.Checked == true)
            {
                FirstAccounts = "1";
            }
            else
            {
                FirstAccounts = "0";
            }
        }

        private void chB_SettingsGeneral_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chB_SettingsGeneral.Checked == true)
            {
                SettingsGeneral = "1";
            }
            else
            {
                SettingsGeneral = "0";
            }
        }

        private void chB_AllowUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_AllowUser.Checked == true)
            {
                AllowUser = "1";
            }
            else
            {
                AllowUser = "0";
            }
        }

        private void chB_Statistical_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Statistical.Checked == true)
            {
                Statistical = "1";
            }
            else
            {
                Statistical = "0";
            }
        }
    }
}
