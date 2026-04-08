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
    public partial class DailyTransactions : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader red;
        private SqlDataReader rad;
        private SqlDataReader reed;
        //--------------------------------

        DataTable dta = new DataTable();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();

        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();
        DataTable dt13 = new DataTable();
        DataTable dt14 = new DataTable();
        //---------------------------------
        ReportDataSource rs = new ReportDataSource();


        SqlDataReader dr;

        SqlCommand cmd;

        public DailyTransactions()
        {
            InitializeComponent();
            //cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_DailyTransactionsBillingData
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Move { get; set; }
            public string TotalBill { get; set; }
            public string TotalBillBuy { get; set; }
            public string TotalBillInvalid { get; set; }
            public string TotalBillBuyInvalid { get; set; }
            public string Pay { get; set; }
            public string Paid { get; set; }


        }

        public class Class_DailyTransactionsExpended
        {

            public string ID { get; set; }
            public string Date { get; set; }
            public string Name { get; set; }
            public string Report { get; set; }
            public string Paid { get; set; }
            public string move { get; set; }
        }

        public class Class_DailyTransactionsCategoryOthers
        {

            public string ID { get; set; }
            public string Date { get; set; }
            public string ExpensesOther { get; set; }
            public string IncomeOther { get; set; }
            public string Statement { get; set; }
           
        }

        public class Class_DailyTransactionsCars
        {
            public string ID { get; set; }
            public string NumCar { get; set; }
            public string Date { get; set; }
            public string Washed { get; set; }
            public string Filter { get; set; }
            public string Petroleum { get; set; }
            public string Oil { get; set; }
            public string Mechanical { get; set; }
            public string PartChange { get; set; }
            public string Total { get; set; }
            public string Notice { get; set; }
            public string Driver { get; set; }
            public string User { get; set; }


        }

        public class Class_DailyTransactionsEmployedSalary
        {
            public string Date { get; set; }
            public string Employed { get; set; }
            public string Sarf { get; set; }


        }

        public class Class_CateorayDay
        {

            // public string NumBill { get; set; }
            //   public string Date { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            // public string Type { get; set; }
            // public string PriceShraa { get; set; }
            public string PriceTotal { get; set; }
            // public string Profit { get; set; }


        }

        private void DailyTransactions_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from EmployedSalary ", cn);
                da11.Fill(dt11);
                this.dataGridView4.DataSource = dt11;

            }
            catch
            { }

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select ID,Date,ExpensesOther,IncomeOther,Statement from CategoryOthers ", cn);
                da11.Fill(dt11);
                this.dataGridMasarefOkhra.DataSource = dt11;

            }
            catch
            { }

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from BillingData ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;



            }
            catch
            { }

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from SearchCar ", cn);
                da11.Fill(dt11);
                this.dataGridView2.DataSource = dt11;



            }
            catch
            { }

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Expended ", cn);
                da11.Fill(dt11);
                this.dataGridView3.DataSource = dt11;



            }
            catch
            { }

            //================================  إيجاد إجمالى توريد

            int sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);


            }
            txtPay.Text = sum.ToString();

            //================================  إيجاد إجمالى تحصيل

            int summ = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                summ += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);


            }
            txtPaid.Text = summ.ToString();

            //================================  إيجاد إجمالى مصاريف عربيات

            int summm = 0;
            for (int i = 0; i < dataGridView2.RowCount; ++i)
            {
                summm += Convert.ToInt32(dataGridView2.Rows[i].Cells[9].Value);


            }
            textBox5.Text = summm.ToString();
            //================================  إيجاد إجمالى مصاريف مخزن

            int summa = 0;
            for (int i = 0; i < dataGridView3.RowCount; ++i)
            {
                summa += Convert.ToInt32(dataGridView3.Rows[i].Cells[4].Value);


            }
            textBox4.Text = summa.ToString();

            //================================  إيجاد إجمالى مرتبات موظفين

            int summa1 = 0;
            for (int i = 0; i < dataGridView4.RowCount; ++i)
            {
                summa1 += Convert.ToInt32(dataGridView4.Rows[i].Cells[2].Value);


            }
            textBox13.Text = summa1.ToString();

            //**********************   صافى اليوم

            double a = Convert.ToDouble(txtPaid.Text);
            double b = Convert.ToDouble(txtPay.Text);
            double c = Convert.ToDouble(textBox5.Text);
            double d = Convert.ToDouble(textBox4.Text);
            double f = Convert.ToDouble(textBox13.Text);

            double s = (a - (b + c + d + f));
            textBox2.Text = s.ToString();



            // إيجاد اسم المستخدم
            textBox10.Text = UserName;

            //------- رصيد الخزنة
            try
            {
                //cmd = new SqlCommand("select RemaningTreasury,Date From TreasuryRemaning  Where ID = '" + 1 + "'", cn);
                //cn.Open();
                //dr = cmd.ExecuteReader();
                //dr.Read();
                //txtReminngOLD.Text = dr["RemaningTreasury"].ToString();
                //textBox12.Text = dr["Date"].ToString();


                cn.Open();
                sqlCommand1.CommandText = "select ISNULL(SUM(Wared),0) as wared,ISNULL(SUM(Sader),0) as sader From BoxMove ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    txtReminngOLD.Text = "0";

                    double w = Convert.ToDouble(reed["wared"].ToString());
                    double ss = Convert.ToDouble(reed["sader"].ToString());


                    double rr = w - ss;
                    //txtReminngOLD.Text = rr.ToString();

                    txtReminngOLD.Text = Math.Round(rr, 0).ToString();

                }
                reed.Close();


            }
            catch //(Exception ex)
            {
                txtReminngOLD.Text = "0";
                textBox12.Text = "";



                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //dr.Close();
                cn.Close();

            }
            //try
            //{




            //-------------------------------------------

            //}
            //catch
            //{
            //}


            if (panelEmploey.Visible == true || panelCars.Visible == true)
            {
                panelEmploey.Visible = false;
                panelCars.Visible = false;
            }
            else
            {
                //panelEmploey.Visible = true;
                //panelCars.Visible = false;
            }

            butSearching.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            txtReminngOLD.Text = "0";
            textBox12.Text = "";
            textBox2.Text = "0";
            textBox11.Text = "0";
            textBox3.Text = "0";
            textBox6.Text = "0";
            textBox9.Text = "";
            textBox14.Text = "0";
            textBox15.Text = "0";
            // ايجاد سابق المخزن
            try
            {
                cn.Open();
                sqlCommand1.CommandText = "select ISNULL(SUM(Wared),0) as wared,ISNULL(SUM(Sader),0) as sader From BoxMove ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    txtReminngOLD.Text = "0";

                    double w = Convert.ToDouble(reed["wared"].ToString());
                    double ss = Convert.ToDouble(reed["sader"].ToString());


                    double rr = w - ss;
                    //txtReminngOLD.Text = rr.ToString();

                    txtReminngOLD.Text = Math.Round(rr, 0).ToString();

                }
                reed.Close();


            }
            catch //(Exception ex)
            {
                txtReminngOLD.Text = "0";
                textBox12.Text = "";



                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //dr.Close();
                cn.Close();

            }
            //----------------ايجاد اجمالى المصروفات والايرادات الاخرى --------------
            //try
            //{
            //    cmd = new SqlCommand("select sumExpensesOther=SUM (ExpensesOther),sumIncomeOther=SUM (IncomeOther) From CategoryOthers Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            //    cn.Open();
            //    dr = cmd.ExecuteReader();
            //    dr.Read();
            //    textBox14.Text = dr["sumExpensesOther"].ToString();
            //    textBox15.Text = dr["sumIncomeOther"].ToString();


            //}
            //catch //(Exception ex)
            //{
            //    textBox14.Text = "0";
            //     textBox15.Text = "0";



            //    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    dr.Close();
            //    cn.Close();

            //}
            dta.Clear();
            SqlDataAdapter daa = new SqlDataAdapter("Select * From CategoryOthers Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            daa.Fill(dta);
            this.dataGridMasarefOkhra.DataSource = dta;
            //================================  إيجاد إجمالى المصروفات والايرادات الاخرى

            int sumEx = 0;
            int sumIn = 0;
            for (int i = 0; i < dataGridMasarefOkhra.RowCount; ++i)
            {
                sumEx += Convert.ToInt32(dataGridMasarefOkhra.Rows[i].Cells[2].Value);

                sumIn += Convert.ToInt32(dataGridMasarefOkhra.Rows[i].Cells[3].Value);


            }
            textBox14.Text = sumEx.ToString();
            textBox15.Text = sumIn.ToString();

            //----------------
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * From BillingData Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;

            //----------------

            dt1.Clear();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From SearchCar Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            da1.Fill(dt1);
            this.dataGridView2.DataSource = dt1;

            //----------------

            dt2.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Expended Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            da2.Fill(dt2);
            this.dataGridView3.DataSource = dt2;

            //----------------

            dt3.Clear();
            SqlDataAdapter da3 = new SqlDataAdapter("Select * From EmployedSalary Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            da3.Fill(dt3);
            this.dataGridView4.DataSource = dt3;
            //================================  إيجاد إجمالى توريد

            int sum = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);


            }
            txtPay.Text = sum.ToString();

            //================================  إيجاد إجمالى تحصيل

            int summ = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                summ += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);


            }
            txtPaid.Text = summ.ToString();

            //================================  إيجاد إجمالى مصاريف عربيات

            int summm = 0;
            for (int i = 0; i < dataGridView2.RowCount; ++i)
            {
                summm += Convert.ToInt32(dataGridView2.Rows[i].Cells[9].Value);


            }
            textBox5.Text = summm.ToString();
            //================================  إيجاد إجمالى مصاريف مخزن

            int summa = 0;
            for (int i = 0; i < dataGridView3.RowCount; ++i)
            {
                summa += Convert.ToInt32(dataGridView3.Rows[i].Cells[4].Value);


            }
            textBox4.Text = summa.ToString();

            //================================  إيجاد إجمالى مرتبات موظفين

            int summa1 = 0;
            for (int i = 0; i < dataGridView4.RowCount; ++i)
            {
                summa1 += Convert.ToInt32(dataGridView4.Rows[i].Cells[2].Value);


            }
            textBox13.Text = summa1.ToString();

            //**********************   صافى اليوم

            double a = Convert.ToDouble(txtPaid.Text);
            double b = Convert.ToDouble(txtPay.Text);
            double c = Convert.ToDouble(textBox5.Text);
            double d = Convert.ToDouble(textBox4.Text);
            double f = Convert.ToDouble(textBox13.Text);
            double g = Convert.ToDouble(textBox14.Text);
            double h = Convert.ToDouble(textBox15.Text);

            double s = ((a + h) - (b + c + d + f + g));
            textBox2.Text = s.ToString();

            //**************************************************
            try
            {
                cmd = new SqlCommand("select BalanceStored,AddStored,ExporTtreasury,Remaining,Notice From Treasury Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                txtReminngOLD.Text = dr["BalanceStored"].ToString();
                textBox11.Text = dr["AddStored"].ToString();
                textBox3.Text = dr["ExporTtreasury"].ToString();
                textBox6.Text = dr["Remaining"].ToString();
                textBox9.Text = dr["Notice"].ToString();

            }
            catch
            {

            }
            finally
            {
                dr.Close();
                cn.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dta.Clear();
            SqlDataAdapter daa = new SqlDataAdapter("Select * From CategoryOthers Where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);
            daa.Fill(dta);
            this.dataGridMasarefOkhra.DataSource = dta;
            //================================  إيجاد إجمالى المصروفات والايرادات الاخرى

            int sumEx = 0;
            int sumIn = 0;
            for (int i = 0; i < dataGridMasarefOkhra.RowCount; ++i)
            {
                sumEx += Convert.ToInt32(dataGridMasarefOkhra.Rows[i].Cells[2].Value);

                sumIn += Convert.ToInt32(dataGridMasarefOkhra.Rows[i].Cells[3].Value);


            }
            textBox14.Text = sumEx.ToString();
            textBox15.Text = sumIn.ToString();
            //----------------
            if (checkBox1.Checked == false)
            {
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("Select * From BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;
            }
             else if (checkBox1.Checked == true)
             {

                //-------------------- اجمالى العملاء

                DataTable dt126 = new DataTable();
                dt126.Clear();
                //  SqlDataAdapter daa = new SqlDataAdapter("Select TOP 15 Date,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit Where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);//BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);

                SqlDataAdapter da216 = new SqlDataAdapter("select Name,NumBill='" + 0 + "',Move='" + 0 + "',Type='" + 0 + "',ROUND(sum(TotalBill),2) as TotalBill,ROUND(sum(TotalBillBuy),2) as TotalBillBuy,ROUND(sum(DiscountBuy),2) as DiscountBuy,ROUND(sum(TotalBillInvalid),2) as TotalBillInvalid,ROUND(sum(TotalBillBuyInvalid), 2) as TotalBillBuyInvalid,ROUND(sum(Creditor), 2) as Creditor,ROUND(sum(Discount), 2) as Discount,ROUND(sum(Adding), 2) as Adding,ROUND(sum(Pay), 2) as Pay,ROUND(sum(Paid), 2) as Paid from BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' GROUP BY Name ORDER BY TotalBill DESC", cn); // ASC تصاعدى  --- DESC تنازلى


                //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
                da216.Fill(dt126);

                this.dataGridView1.DataSource = dt126;
            }
            //----------------

            dt12.Clear();
            SqlDataAdapter da12 = new SqlDataAdapter("Select * From SearchCar Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);
            da12.Fill(dt12);
            this.dataGridView2.DataSource = dt12;

            //----------------

            dt13.Clear();
            SqlDataAdapter da13 = new SqlDataAdapter("Select * From Expended Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);
            da13.Fill(dt13);
            this.dataGridView3.DataSource = dt13;

            //----------------

            dt14.Clear();
            SqlDataAdapter da14 = new SqlDataAdapter("Select * From EmployedSalary Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);
            da14.Fill(dt14);
            this.dataGridView4.DataSource = dt14;

            //------- الاصناف المباعه 
            DataTable dt15 = new DataTable();
            dt15.Clear();
            SqlDataAdapter da215 = new SqlDataAdapter("select  Category,sum(Quantity) as Quantity,sum(Total) as PriceTotal from Billing where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' GROUP BY Category ORDER BY Category ", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da215 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da215.Fill(dt15);

            this.dataGridView5.DataSource = dt15;

            //================================  إيجاد إجمالى توريد

            int sum = 0;
            int summ = 0;
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            for (int i = 0; i < dataGridView1.RowCount; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value);
                summ += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);
                sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                sum2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                sum3 += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                sum4 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);


            }
            txtPay.Text = sum.ToString();
            txtPaid.Text = summ.ToString();
            txtTotalBill.Text = sum1.ToString();
            txtTotalBillBuy.Text = sum2.ToString();
            txtTotalBillInvalid.Text = sum3.ToString();
            txtTotalBillBuyInvalid.Text = sum4.ToString();

            //================================  إيجاد إجمالى تحصيل

            //int summ = 0;
            //for (int i = 0; i < dataGridView1.RowCount; ++i)
            //{
            //    summ += Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value);


            //}
            //txtPaid.Text = summ.ToString();

            //================================  إيجاد إجمالى مصاريف عربيات

            int summm = 0;
            for (int i = 0; i < dataGridView2.RowCount; ++i)
            {
                summm += Convert.ToInt32(dataGridView2.Rows[i].Cells[9].Value);


            }
            textBox5.Text = summm.ToString();
            //================================  إيجاد إجمالى مصاريف مخزن

            int summa = 0;
            for (int i = 0; i < dataGridView3.RowCount; ++i)
            {
                summa += Convert.ToInt32(dataGridView3.Rows[i].Cells[4].Value);


            }
            textBox4.Text = summa.ToString();
            //================================  إيجاد إجمالى مصاريف مرتبات

            int summa1 = 0;
            for (int i = 0; i < dataGridView4.RowCount; ++i)
            {
                summa1 += Convert.ToInt32(dataGridView4.Rows[i].Cells[2].Value);


            }
            textBox13.Text = summa1.ToString();

            //**********************   صافى اليوم

            double a = Convert.ToDouble(txtPaid.Text);
            double b = Convert.ToDouble(txtPay.Text);
            double c = Convert.ToDouble(textBox5.Text);
            double d = Convert.ToDouble(textBox4.Text);
            double f = Convert.ToDouble(textBox13.Text);
            double g = Convert.ToDouble(textBox14.Text);
            double h = Convert.ToDouble(textBox15.Text);

            double s = ((a + h) - (b + c + d + f + g));
            textBox2.Text = s.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox3.Text = txtPaid.Text;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("       من فضلك أدخل إسم المستخدم           ", "  خطأ  ");
                textBox10.Focus();
            }
            else
            {
                try
                {
                    double a = Convert.ToDouble(textBox2.Text);
                    double b = Convert.ToDouble(txtReminngOLD.Text);
                    double c = Convert.ToDouble(textBox11.Text);
                    double d = Convert.ToDouble(textBox3.Text);

                    double s = ((a + b + c) - d);
                    textBox6.Text = s.ToString();

                }
                catch
                { }

                try
                {
                    //----------------
                    cmd = new SqlCommand("insert into Treasury (Date,Users,BalanceStored,Tahseel,Tawred,MassarefStored,MassarefCar,SafyStored,AddStored,ExporTtreasury,Remaining,Notice)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + txtReminngOLD.Text + "','" + txtPaid.Text + "','" + txtPay.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox11.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox9.Text + "')", cn);
                    // cmd.CommandText = "insert into Employee (Name,Adress,Num_pers,Date_birth,Job,Salary,Date_Job)values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "')";
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    //---------------
                    MessageBox.Show("      تم التوريد للخزينة الرئيسية    ", "  ملحوظة  ");

                    try
                    {
                        cmd = new SqlCommand("Update TreasuryRemaning set RemaningTreasury ='" + textBox6.Text + "' , Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    catch
                    { }

                }
                catch
                {

                    cmd = new SqlCommand("Update Treasury set Users='" + textBox10.Text + "',BalanceStored='" + txtReminngOLD.Text + "',Tahseel='" + txtPaid.Text + "',Tawred='" + txtPay.Text + "',MassarefStored='" + textBox4.Text + "',MassarefCar='" + textBox5.Text + "',SafyStored='" + textBox2.Text + "',AddStored='" + textBox11.Text + "',ExporTtreasury='" + textBox3.Text + "',Remaining='" + textBox6.Text + "',Notice='" + textBox9.Text + "' Where Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
                    //cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("      تم التعديل    ", "  ملحوظة  ");
                }

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (panelEmploey.Visible == true)
            {
                panelEmploey.Visible = false;
            }
            else
            {
                panelEmploey.Visible = true;
                panelCars.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (panelCars.Visible == true)
            {
                panelCars.Visible = false;
            }
            else
            {
                panelCars.Visible = true;
                panelEmploey.Visible = false;
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {

            //-----------------------
            AppSetting.date_From = dateTimePicker2.Text;
            AppSetting.date_To = dateTimePicker3.Text;

            //if (comClient.Text == "")
            //{
            //    MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
            //    comClient.Focus();
            //}
            //else
            //{
            //AppSetting.ClintID = textClintID.Text;
            //AppSetting.ClintName = comClient.Text;
            //AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            //AppSetting.TotalBill = txtTotalBill.Text;
            //AppSetting.RemaningOld = txtRemaningOld.Text;
            ////AppSetting.textBox27 = textBox27.Text;
            //AppSetting.Mosadad = txtMosadad.Text;
            //AppSetting.RemainingNow = txtRemainingNow.Text;
            //AppSetting.Dic = txtDic.Text;
            ////AppSetting.textBox30 = textBox30.Text;

            ////AppSetting.dateTimePicker2 = dateTimePicker2.Text;
            //AppSetting.textBox57 = textUser.Text;
            //AppSetting.BillingDataNumBill = textBillingDataNumBill.Text;
            //AppSetting.TypeBill = comTypeBill.Text;
            //AppSetting.MoveBill = textMoveBill.Text;

            //Reports.Frm_PrintReportBill frm = new Reports.Frm_PrintReportBill();
            //da = new SqlDataAdapter("select * from Billing where NumBill = '" + textBillingDataNumBill.Text + "'", cn);
            ////da.Fill(frm.elwesifDataSet84.Billing);
            //frm.reportViewerA5.Visible = false;
            //frm.reportViewerA5.RefreshReport();

            //frm.Show();

            List<Class_DailyTransactionsBillingData> BM = new List<Class_DailyTransactionsBillingData>();
                BM.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                if(dataGridView1.Rows[i].Cells[0].Value.ToString()==null)
                { }
                    Class_DailyTransactionsBillingData Categoreys = new Class_DailyTransactionsBillingData
                    {
                        // public string NumBill { get; set; }
                        //public string Name { get; set; }
                        //public string Type { get; set; }
                        //public string Move { get; set; }
                        //public string TotalBill { get; set; }
                        //public string TotalBillBuy { get; set; }
                        //public string TotalBillInvalid { get; set; }
                        //public string TotalBillBuyInvalid { get; set; }
                        //public string Pay { get; set; }
                        //public string Paid { get; set; }


                        NumBill = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        Type = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        Move = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        TotalBill = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        TotalBillBuy = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                        TotalBillInvalid = dataGridView1.Rows[i].Cells[6].Value.ToString(),
                        TotalBillBuyInvalid = dataGridView1.Rows[i].Cells[7].Value.ToString(),
                        Pay = dataGridView1.Rows[i].Cells[8].Value.ToString(),
                        Paid = dataGridView1.Rows[i].Cells[9].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }

            Class_DailyTransactionsBillingData Categoreys2 = new Class_DailyTransactionsBillingData
            {


                NumBill = "",
                Name = "",
                Type = "",
                Move = "الاجمالى",
                TotalBill = txtTotalBill.Text,
                TotalBillBuy = txtTotalBillBuy.Text,
                TotalBillInvalid = txtTotalBillInvalid.Text,
                TotalBillBuyInvalid = txtTotalBillBuyInvalid.Text,
                Pay = txtPay.Text,
                Paid = txtPaid.Text,

            };

            BM.Add(Categoreys2);
            rs.Name = "DataSet1";
                rs.Value = BM;

                Reports.Frm_ReportDailyTransactions rbm = new Reports.Frm_ReportDailyTransactions();
              
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);



                rbm.ShowDialog();
            //}
        }

        private void DailyTransactions_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void DailyTransactions_MouseClick(object sender, MouseEventArgs e)
        {
            if (panelEmploey.Visible == true || panelCars.Visible == true)
            {
                panelEmploey.Visible = false;
                panelCars.Visible = false;
            }
            else
            {
                //panelBilling.Visible = false;
                //panelEmploey.Visible = true;
                //panelCars.Visible = false;
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if (panelBilling.Visible == true)
            {
                panelBilling.Visible = false;
            }
            else
            {
                panelBilling.Visible = true;
                panelEmploey.Visible = false;
                panelCars.Visible = false;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            //-----------------------
            AppSetting.date_From = dateTimePicker2.Text;
            AppSetting.date_To = dateTimePicker3.Text;

            
            List<Class_CateorayDay> BM1 = new List<Class_CateorayDay>();
            BM1.Clear();
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                Class_CateorayDay Categoreys1 = new Class_CateorayDay
                {

                    Category = dataGridView5.Rows[i].Cells[0].Value.ToString(),
                    Quantity = dataGridView5.Rows[i].Cells[1].Value.ToString(),
                    PriceTotal = dataGridView5.Rows[i].Cells[2].Value.ToString(),
                    

                };

                BM1.Add(Categoreys1);
            }

            //Class_DailyTransactionsBillingData Categoreys2 = new Class_DailyTransactionsBillingData
            //{


            //    NumBill = "",
            //    Name = "",
            //    Type = "",
            //    Move = "الاجمالى",
            //    TotalBill = txtTotalBill.Text,
            //    TotalBillBuy = txtTotalBillBuy.Text,
            //    TotalBillInvalid = txtTotalBillInvalid.Text,
            //    TotalBillBuyInvalid = txtTotalBillBuyInvalid.Text,
            //    Pay = txtPay.Text,
            //    Paid = txtPaid.Text,

            //};

           // BM.Add(Categoreys2);

            rs.Name = "DataSet1";
            rs.Value = BM1;

            Reports.Frm_ReportDailyCategry rbm = new Reports.Frm_ReportDailyCategry();

            rbm.reportViewer1.LocalReport.DataSources.Clear();
            rbm.reportViewer1.LocalReport.DataSources.Add(rs);



            rbm.ShowDialog();
            //}
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panelCateorayDay.Visible == true)
            {
                panelCateorayDay.Visible = false;
            }
            else
            {
                panelCateorayDay.Visible = true;
                panelEmploey.Visible = false;
            }
        }

        private void butSumClients_Click(object sender, EventArgs e)
        {
            //-------------------- اجمالى العملاء

            DataTable dt126 = new DataTable();
            dt126.Clear();
            //  SqlDataAdapter daa = new SqlDataAdapter("Select TOP 15 Date,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit Where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);//BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);

            SqlDataAdapter da216 = new SqlDataAdapter("select Name,NumBill='"+0+ "',Move='" + 0 + "',Type='" + 0 + "',ROUND(sum(TotalBill),2) as TotalBill,ROUND(sum(TotalBillBuy),2) as TotalBillBuy,ROUND(sum(DiscountBuy),2) as DiscountBuy,ROUND(sum(TotalBillInvalid),2) as TotalBillInvalid,ROUND(sum(TotalBillBuyInvalid), 2) as TotalBillBuyInvalid,ROUND(sum(Creditor), 2) as Creditor,ROUND(sum(Discount), 2) as Discount,ROUND(sum(Adding), 2) as Adding,ROUND(sum(Pay), 2) as Pay,ROUND(sum(Paid), 2) as Paid from BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' GROUP BY Name ORDER BY TotalBill DESC", cn); // ASC تصاعدى  --- DESC تنازلى
            

            //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da216.Fill(dt126);

            this.dataGridView1.DataSource = dt126;
        }
    }
}
