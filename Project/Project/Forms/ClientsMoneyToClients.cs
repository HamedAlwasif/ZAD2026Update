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
    public partial class ClientsMoneyToClients : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string RseedBox = "";
        string MoveBoxID = "";
        string NumBill = "";
        string ClintID1 = "";
        
        string TypeClint1 = "";
        string CreditorClint1 = "";

        string ClintID2 = "";
        string TypeClint2 = "";
        string CreditorClint2 = "";

        //-------------------------------
        private SqlDataReader red;
        private SqlDataReader rd;
        private SqlDataReader reed;
        private SqlDataReader reeeeed;
        private SqlDataReader read;
        private SqlDataReader reaad;

        ClientsMoney ClientsMoney1;

        //------------------------------------
        //ReportDataSource rs = new ReportDataSource();
        //-------------------------
        public ClientsMoneyToClients()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }
        public class Class_ClientsMoney
        {
            //NumBill,Date,Move,Paid,Discount,Adding.Pay
            public string NumBill { get; set; }
            public string Date { get; set; }
            public string Move { get; set; }
            public string Paid { get; set; }
            public string Pay { get; set; }
            public string Discount { get; set; }
            public string Adding { get; set; }


        }
        private void GetdataOldToTable()
        {

            DataTable dt12 = new DataTable();
            dt12.Clear();
            SqlDataAdapter da21 = new SqlDataAdapter("select TOP 10 NumBill,Date,Move,Paid,Discount,Adding from BillingData where  Name = '" + comNameTo.Text + "' ORDER BY NumBill DESC ", cn);
            //SqlDataAdapter da21 = new SqlDataAdapter("select NumBill,Date,Move,Paid from BillingData where  Name = '" + comName.Text + "' and Move like '" + comboBox3.Text + "' ", sqlConnection1);

            da21.Fill(dt12);
            this.dataGridView1.DataSource = dt12;


            //this.dataGridView1.Columns[0].HeaderText = "الرقم";
            //this.dataGridView1.Columns[0].Width = 50;

            //this.dataGridView1.Columns[1].HeaderText = "التاريخ";
            //this.dataGridView1.Columns[1].Width = 70;

            //this.dataGridView1.Columns[2].HeaderText = "الحركة";
            //this.dataGridView1.Columns[2].Width = 150;

            //this.dataGridView1.Columns[3].HeaderText = "المبلغ";
            //this.dataGridView1.Columns[3].Width = 70;

            //this.dataGridView1.Columns[4].HeaderText = "خصم";
            //this.dataGridView1.Columns[4].Width = 40;

            //this.dataGridView1.Columns[5].HeaderText = "اضافة";
            //this.dataGridView1.Columns[5].Width = 40;

            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

        }
        private void GetOldRasedClient()
        {

            try
            {

                sqlCommand1.CommandText = "select SUM(TotalBill) as TotalBill,SUM(Discount) as Discount,SUM(TotalBillBuy) as TotalBillBuy,SUM(DiscountBuy) as DiscountBuy,SUM(TotalBillInvalid) as TotalBillInvalid,SUM(TotalBillBuyInvalid) as TotalBillBuyInvalid,SUM(Creditor) as Creditor,SUM(Adding) as Adding,SUM(Pay) as Pay,SUM(Paid) as Paid From BillingData Where Name='" + comName.Text + "'  ";
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

        private void GetOldRasedClientTo()
        {

            try
            {

                sqlCommand1.CommandText = "select SUM(TotalBill) as TotalBill,SUM(Discount) as Discount,SUM(TotalBillBuy) as TotalBillBuy,SUM(DiscountBuy) as DiscountBuy,SUM(TotalBillInvalid) as TotalBillInvalid,SUM(TotalBillBuyInvalid) as TotalBillBuyInvalid,SUM(Creditor) as Creditor,SUM(Adding) as Adding,SUM(Pay) as Pay,SUM(Paid) as Paid From BillingData Where Name='" + comNameTo.Text + "'  ";
                rd = sqlCommand1.ExecuteReader();
                while (rd.Read())
                {
                    string TotalBill2 = rd["TotalBill"].ToString();
                    string Discount2 = rd["Discount"].ToString();
                    string TotalBillBuy2 = rd["TotalBillBuy"].ToString();
                    string DiscountBuy2 = rd["DiscountBuy"].ToString();
                    string TotalBillInvalid2 = rd["TotalBillInvalid"].ToString();
                    string TotalBillBuyInvalid2 = rd["TotalBillBuyInvalid"].ToString();
                    string Creditor2 = rd["Creditor"].ToString();
                    string Adding2 = rd["Adding"].ToString();
                    string Pay2 = rd["Pay"].ToString();
                    string Paid2 = rd["Paid"].ToString();

                    //-------------------------------------------
                    txtRemaningOld2.Text = "0";
                    try
                    {
                        double t1 = Convert.ToDouble(TotalBill2);
                        double t2 = Convert.ToDouble(DiscountBuy2);
                        double t3 = Convert.ToDouble(TotalBillBuyInvalid2);
                        double t4 = Convert.ToDouble(Adding2);
                        double t5 = Convert.ToDouble(Pay2);
                        double t6 = Convert.ToDouble(Discount2);
                        double t7 = Convert.ToDouble(TotalBillBuy2);
                        double t8 = Convert.ToDouble(TotalBillInvalid2);
                        double t9 = Convert.ToDouble(Paid2);
                        double total = (t1 + t2 + t3 + t4 + t5) - (t6 + t7 + t8 + t9);
                        txtRemaningOld2.Text = total.ToString();
                        txtRemaningOld2.Text = Math.Round(double.Parse(txtRemaningOld2.Text), 2).ToString();

                    }
                    catch
                    {

                    }
                }
                rd.Close();
            }
            catch { }





        }
        private void butSearch_Click(object sender, EventArgs e)
        {
           // GetdataOldToTable();

            GetOldRasedClient();

            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comName.Text + "'  ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    ClintID1 = red["ID"].ToString();

                    TypeClint1 = red["Company"].ToString();


                    CreditorClint1 = red["Creditor"].ToString();
                    //string ClintID = "";
                    //string TypeClint = "";
                    //string CreditorClint = "";
                }
                red.Close();

                //comName.Enabled = false;
                //butSearch.Enabled = false;
            }
            catch
            {
                MessageBox.Show("يوجد خطأ فى البحث", "Error");
            }

        }

        private void ClientsMoneyToClients_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Clients", cn);
                Da2.Fill(Dt2);
                comName.DataSource = Dt2;
                comName.DisplayMember = "Name";
                
            }
            catch { }

            try
            {
                SqlDataAdapter Da22;
                DataTable Dt22 = new DataTable();
                Da22 = new SqlDataAdapter("select Name from Clients", cn);
                Da22.Fill(Dt22);
                
                comNameTo.DataSource = Dt22;
                comNameTo.DisplayMember = "Name";
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetdataOldToTable();

            GetOldRasedClientTo();
            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comNameTo.Text + "'  ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    ClintID2 = red["ID"].ToString();

                    TypeClint2 = red["Company"].ToString();


                    CreditorClint2 = red["Creditor"].ToString();
                    //string ClintID = "";
                    //string TypeClint = "";
                    //string CreditorClint = "";
                }
                red.Close();

                //comName.Enabled = false;
                //butSearch.Enabled = false;
            }
            catch
            {
                MessageBox.Show("يوجد خطأ فى البحث", "Error");
            }


            //    sqlCommand1.CommandText = "select * from Clients where Name ='" + comNameTo.Text + "'  ";
            //    red = sqlCommand1.ExecuteReader();
            //    while (red.Read())
            //    {
            //        ClintID2 = red["ID"].ToString();

            //        TypeClint2 = red["Company"].ToString();


            //        CreditorClint2 = red["Creditor"].ToString();
            //        //string ClintID = "";
            //        //string TypeClint = "";
            //        //string CreditorClint = "";
            //    }
            //    red.Close();

            //    comNameTo.Enabled = false;
            //    button1.Enabled = false;
            ////}
            ////catch
            ////{
            ////    MessageBox.Show("يوجد خطأ فى البحث", "Error");
            ////}
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
                    textBillingDataNumBill1.Text = aa.ToString();


                }
                red.Close();

                if (textBillingDataNumBill1.Text == "0")
                {
                    textBillingDataNumBill1.Text = "1";
                }
                else
                { }

                NumBill = textBillingDataNumBill1.Text;

            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        public void CountRemainingClint()
        {
            double a = Convert.ToDouble(txtRemaningOld.Text);
            double b = Convert.ToDouble(txtRemaningOld2.Text);
            double c = Convert.ToDouble(txtTransform.Text);





            double clint1 = a - c;

            double clint2 = b + c;


            txtRemaningOld.Text = clint1.ToString();

            txtRemaningOld2.Text = clint2.ToString();

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            // ايجاد رقم الفاتورة
            GetNumBill();

            //-------------------------------------------

            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال العملية ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //string ClintID = "";
                //string TypeClint = "";
                //string CreditorClint = "";
                CountRemainingClint();
                


                // تحديث بيانات الفاتورة
                string Note = " تحويل : " +" من "+comName.Text+" الى "+ comNameTo.Text;
                //------------- اضافة البيانات العميل الاول
                sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,NumberCategory)values ('" + textBillingDataNumBill1.Text + "','" + ClintID1 + "','" + comName.Text + "','" + TypeClint1 + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "', '" + Note + "' ,'" + txtRemaningOld.Text + "','" + CreditorClint1 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtRemaningOld.Text + "','" + 0 + "','" + txtTransform.Text + "','" + txtRemaningOld.Text + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();


                
                // تغير رفم الحساب للعميل الثانى
                double NumBill1 = Convert.ToDouble(textBillingDataNumBill1.Text);
                
                double NumBill2 = NumBill1 + 1;
                
                //------------- اضافة البيانات العميل الثانى
                sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,NumberCategory)values ('" + NumBill2 + "','" + ClintID2 + "','" + comNameTo.Text + "','" + TypeClint2 + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "', '" + Note + "' ,'" + txtRemaningOld2.Text + "','" + CreditorClint2 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtRemaningOld2.Text + "','" + txtTransform.Text + "','" + 0 + "','" + txtRemaningOld2.Text + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();



                // تعديل الرصيد فى جدول العملاء
                try
                {
                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemaningOld.Text + "'  WHERE  Name ='" + comName.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemaningOld2.Text + "'  WHERE  Name ='" + comNameTo.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                }
                catch
                {
                    //MessageBox.Show(" pleas correct the data");
                }


                //------------------
                GetdataOldToTable();




            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void txtTransform_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
