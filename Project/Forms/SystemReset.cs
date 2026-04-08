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
    public partial class SystemReset : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //-------------------------
        SqlCommand cmd;

        public SystemReset()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearTableAndRestAutonumber(string tableName)
        {
            string YourDatabaseName = "ZAD";


            string conStr = (@"Server=.\sqlexpress; DataBase=" + YourDatabaseName + "; Integrated Security=SSPI");


            System.Data.SqlClient.SqlConnection DataBaseConnection = new System.Data.SqlClient.SqlConnection(conStr);


            try
            {
                string sql = "";


                sql = string.Format("TRUNCATE TABLE {0}", tableName.Trim());


                var CMD = new System.Data.SqlClient.SqlCommand(sql, DataBaseConnection);


                if (DataBaseConnection.State == ConnectionState.Open)
                    DataBaseConnection.Close();


                DataBaseConnection.Open();


                CMD.ExecuteNonQuery();


                CMD.Dispose();


                DataBaseConnection.Close();
            }

            catch
            {

            }
        }
        private void butDeleteAll_Click(object sender, EventArgs e)
        {
            // اخذ نسخة احتياطية 
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Backup Files(*.Bak)|*.bak";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                cmd = new SqlCommand("Backup Database ZAD To Disk='" + sf.FileName + "'", cn);
                //   sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                //  sqlConnection1.Close();


            }

            //------------------------------------
            if (textBox1.Text == "2042017")
            {
                DialogResult dialogResult = MessageBox.Show("مسح جميع البيانات" + Environment.NewLine + Environment.NewLine + "هل تريد مسح جميع البيانات وبدأ البرنامج من الصفر  ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                {
                    ClearTableAndRestAutonumber("Bank");
                    ClearTableAndRestAutonumber("BankHesab");
                    ClearTableAndRestAutonumber("Billing");
                    ClearTableAndRestAutonumber("Billing1");
                    ClearTableAndRestAutonumber("BillingData");
                    ClearTableAndRestAutonumber("BillingData1");
                    ClearTableAndRestAutonumber("BillingInvalid");
                    ClearTableAndRestAutonumber("BoxMove");
                    ClearTableAndRestAutonumber("Car");
                    ClearTableAndRestAutonumber("Category");
                    ClearTableAndRestAutonumber("CategoryCart");
                    ClearTableAndRestAutonumber("CategoryFaction");
                    ClearTableAndRestAutonumber("CategoryMove");
                    ClearTableAndRestAutonumber("CategoryMove2");
                    ClearTableAndRestAutonumber("CategoryOthers");
                    ClearTableAndRestAutonumber("CategoryPrice");
                    ClearTableAndRestAutonumber("CategorysMaterials");
                    ClearTableAndRestAutonumber("CategorysMaterialsData");
                    ClearTableAndRestAutonumber("CategoryTotal");
                    ClearTableAndRestAutonumber("Clients");
                    ClearTableAndRestAutonumber("Employed");
                    ClearTableAndRestAutonumber("EmployedSalary");
                    ClearTableAndRestAutonumber("Expended");
                    ClearTableAndRestAutonumber("Expended1");
                    ClearTableAndRestAutonumber("Final");
                    ClearTableAndRestAutonumber("FristGard");
                    ClearTableAndRestAutonumber("Groups");
                    ClearTableAndRestAutonumber("Invalid");
                    ClearTableAndRestAutonumber("KaematEldakhel");
                    ClearTableAndRestAutonumber("Materials");
                    ClearTableAndRestAutonumber("MaterialsBill");
                    ClearTableAndRestAutonumber("Mortagaat");
                    ClearTableAndRestAutonumber("Movemoney");
                    ClearTableAndRestAutonumber("OsolSabta");
                    ClearTableAndRestAutonumber("Profit");
                    ClearTableAndRestAutonumber("RasMoney");
                    ClearTableAndRestAutonumber("SavePass");
                    ClearTableAndRestAutonumber("SearchCar");
                    ClearTableAndRestAutonumber("SheekSave");
                    ClearTableAndRestAutonumber("Storage");
                    ClearTableAndRestAutonumber("SystemProgram");
                    ClearTableAndRestAutonumber("Transport");
                    ClearTableAndRestAutonumber("Treasury");
                    ClearTableAndRestAutonumber("TreasuryRemaning");
                    ClearTableAndRestAutonumber("User");
                    ClearTableAndRestAutonumber("Users");

                    ClearTableAndRestAutonumber("CategorysMaterials");
                    ClearTableAndRestAutonumber("CategorysMaterialsData");
                    ClearTableAndRestAutonumber("Materials");
                    ClearTableAndRestAutonumber("MaterialsBill");

                    ClearTableAndRestAutonumber("Installment");
                    ClearTableAndRestAutonumber("InstallmentData");


                    MessageBox.Show("  تم حذف جميع البيانات بنجاح   ", "    حذف البيانات   ",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }







                //DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد مسح جميع البيانات وبدأ البرنامج من الصفر  ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    MessageBox.Show("موافق", "موافق");

                //    sqlCommand1.CommandText = "delete from Billing where NumBill >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Billing1 where NumBill >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from BillingData where NumBill >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from BillingData1 where NumBill >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from BillingInvalid where NumBill >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Car where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Category where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from CategoryPrice where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Clients where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Employed where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from EmployedSalary where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Expended where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Final where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Profit where NumBill >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from SearchCar where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Storage where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Transport where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Treasury where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from CategoryMove where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from CategoryMove2 where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from FristGard where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Bank where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from BankHesab where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from SheekSave where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from SavePass where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();


                //    sqlCommand1.CommandText = "delete from BoxMove where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Groups where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from CategoryTotal where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

                //    sqlCommand1.CommandText = "delete from Movemoney where ID >= '" + 0 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();


                //    try
                //    {
                //        sqlCommand1.CommandText = "insert into CategoryTotal (Date,Total_Category)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + 0 + "')";
                //        sqlCommand1.ExecuteNonQuery();
                //    }
                //    catch
                //    {
                //    }


                //    try
                //    {
                //        sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + 0 + "', Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where  ID ='" + 1 + "'  ";
                //        sqlCommand1.ExecuteNonQuery();
                //    }
                //    catch
                //    {
                //        MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                //    }

                //    sqlCommand1.CommandText = "delete from Users where ID >= '" + 2 + "'   ";
                //    sqlCommand1.ExecuteNonQuery();

            }
            else
            {


            }
        }
           
        
    }
}
