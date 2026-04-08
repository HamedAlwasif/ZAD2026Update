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
    public partial class ClientAccountStatement : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        Purchases Purchases1;
        Sales Sales1;
        //--------------------------------

        //int i = 0;
        int ii = 0;
        //int iij = 0;
        //int iii = 0;
        //int ij = 0;
        //int ji = 0;
        //private SqlDataReader red;
        private SqlDataReader reeeeed;
        private SqlDataReader reed;

        SqlCommandBuilder cmdb;
        SqlDataAdapter adap;
        DataSet ds;

        //------------------------------------
        ReportDataSource rs = new ReportDataSource();
        //-------------------------
        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();


        public ClientAccountStatement()
        {
            InitializeComponent();
            //cn.Open();
            sqlCommand1.Connection = cn;
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
        public class Class_ClientAccountStatement
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Move { get; set; }
            public string Date { get; set; }
            public string TotalBill { get; set; }
            public string Discount { get; set; }
            public string TotalBillBuy { get; set; }
            public string DiscountBuy { get; set; }
            public string TotalBillInvalid { get; set; }
            public string TotalBillBuyInvalid { get; set; }
            public string Adding { get; set; }
            public string Pay { get; set; }
            public string Paid { get; set; }
            public string Remaining { get; set; }
            public string NamePrint { get; set; }


        }

        private void Searching()
        {

            //string CategoryTotal;
            //try
            //{


            cn.Open();

            sqlCommand1.CommandText = "select SUM(TotalBill) as TotalBill,SUM(Discount) as Discount,SUM(TotalBillBuy) as TotalBillBuy,SUM(DiscountBuy) as DiscountBuy,SUM(TotalBillInvalid) as TotalBillInvalid,SUM(TotalBillBuyInvalid) as TotalBillBuyInvalid,SUM(Creditor) as Creditor,SUM(Adding) as Adding,SUM(Pay) as Pay,SUM(Paid) as Paid From BillingData Where Name='" + combNameClint.Text + "' and Date <'" + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                string TotalBill = reed["TotalBill"].ToString();
                string Discount = reed["Discount"].ToString();
                string TotalBillBuy = reed["TotalBillBuy"].ToString();
                string DiscountBuy = reed["DiscountBuy"].ToString();
                string TotalBillInvalid = reed["TotalBillInvalid"].ToString();
                string TotalBillBuyInvalid = reed["TotalBillBuyInvalid"].ToString();
                string Creditor = reed["Creditor"].ToString();
                string Adding = reed["Adding"].ToString();
                string Pay = reed["Pay"].ToString();
                string Paid = reed["Paid"].ToString();

                //-------------------------------------------
                txtReminngOLD.Text = "0";

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
                    txtReminngOLD.Text = total.ToString();
                }
                catch
                {

                }
            }
            reed.Close();

            //-------------------------------------------
            textBox11.Text = txtReminngOLD.Text;
            //---------------------------------------------
            cn.Close();



        }
        private void GetAllClintes()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Clients ", cn);
            da11.Fill(dt11);
            this.dataGridSearchClint.DataSource = dt11;

        }
        private void ClientAccountStatement_Load(object sender, EventArgs e)
        {
            ////------------------------------------
            //DataTable dt11 = new DataTable();
            //dt11.Clear();
            //SqlDataAdapter da11 = new SqlDataAdapter("select * from BillingData ", cn);
            //da11.Fill(dt11);
            //this.DGVkashfHesab.DataSource = dt11;
            ////------------------------------------
            GetAllClintes();

            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Clients", cn);
                Da2.Fill(Dt2);
                //comName.DataSource = Dt2;
                //comName.DisplayMember = "Name";
                combNameClint.DataSource = Dt2;
                combNameClint.DisplayMember = "Name";
            }
            catch { }
        }
        private void GetOldRasedClient()
        {

            try
            {
                txtRemaningOld.Text = "0";

                cn.Open();
                sqlCommand1.CommandText = "select SUM(TotalBill) as TotalBill,SUM(Discount) as Discount,SUM(TotalBillBuy) as TotalBillBuy,SUM(DiscountBuy) as DiscountBuy,SUM(TotalBillInvalid) as TotalBillInvalid,SUM(TotalBillBuyInvalid) as TotalBillBuyInvalid,SUM(Creditor) as Creditor,SUM(Adding) as Adding,SUM(Pay) as Pay,SUM(Paid) as Paid From BillingData Where Name='" + combNameClint.Text + "'  ";
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
            cn.Close();
        }
            catch { }





        }
        private void button20_Click(object sender, EventArgs e)
        {
            textBox11.Text = "0";

            //adap = new SqlDataAdapter("Select NumBill,Name,Type,Move,Date,TotalBill,Discount,TotalBillBuy,DiscountBuy,TotalBillInvalid,TotalBillBuyInvalid,Adding,Pay,Paid From BillingData Where  Name='" + combNameClint.Text + "' ", cn);
            //ds = new System.Data.DataSet();
            //adap.Fill(ds, "BillingData_Detail");
            //dataGrData.DataSource = ds.Tables[0];

            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select NumBill,Name,Type,Move,Date,TotalBill,Discount,TotalBillBuy,DiscountBuy,TotalBillInvalid,TotalBillBuyInvalid,Adding,Pay,Paid,NamePrint From BillingData Where  Name='" + combNameClint.Text + "'", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;

            //*****************  حساب الباقى ****************
            foreach (DataGridViewRow item in dataGrData.Rows)
            {
                int i = item.Index;
                double t = Convert.ToDouble(textBox11.Text);

                double a1 = Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                double a2 = Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                double a3 = Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                double a4 = Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                double a5 = Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                double a6 = Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                double a7 = Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                double a8 = Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                double a9 = Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);



                double total = (a1 + a2 + a3 + a4 + a5) - (a6 + a7 + a8 + a9);

                //dataGrData.Rows[i].Cells[14].Value = (total + t).ToString();

                dataGrData.Rows[i].Cells[14].Value = Math.Round((total+t), 2).ToString();




                //dataGrData.Rows[i].Cells[14].Value =
                //    ((Convert.ToDouble(dataGrData.Rows[i].Cells[4].Value) -
                //     Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value)) + t).ToString();

                textBox11.Text = dataGrData.Rows[i].Cells[14].Value.ToString();


            }

            //------------  دائن مدين ------------
            double s1 = 0;
            double s2 = 0;
            double s3 = 0;
            double s4 = 0;
            double s5 = 0;
            double s6 = 0;
            double s7 = 0;
            double s8 = 0;
            double s9 = 0;
            for (int i = 0; i < dataGrData.RowCount; ++i)
            {
                s1 += Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                s2 += Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                s3 += Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                s4 += Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                s5 += Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                s6 += Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                s7 += Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                s8 += Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                s9 += Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);

            }
            txtMabeaat.Text = s1.ToString();
            txtMoshtariat.Text = s7.ToString();
            txtDisMab.Text = s6.ToString();
            txtDisMosh.Text = s2.ToString();
            txtMardMab.Text = s8.ToString();
            txtMardMosh.Text = s3.ToString();
            txtAdd.Text = s4.ToString();
            txtDaf.Text = s5.ToString();
            txtTahsel.Text = s9.ToString();

            //---------- ايجاد الرصيد الحالى للعميل
            txtRemaningOld.Visible = true;
            label1.Visible = true;
            GetOldRasedClient();
        }

        private void btSearchFromTo_Click(object sender, EventArgs e)
        {
            Searching();

            //adap = new SqlDataAdapter("Select NumBill,Name,Type,Move,Date,TotalBill,Discount,TotalBillBuy,DiscountBuy,TotalBillInvalid,TotalBillBuyInvalid,Adding,Pay,Paid From BillingData Where  Name='" + combNameClint.Text + "' and Date >='" + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + "' and Date <='" + Dtp_ToDate.Value.ToString("MM/dd/yyyy") + "'", cn);


            //ds = new System.Data.DataSet();
            //adap.Fill(ds, "BillingData_Detail");
            //dataGrData.DataSource = ds.Tables[0];

            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select NumBill,Name,Type,Move,Date,TotalBill,Discount,TotalBillBuy,DiscountBuy,TotalBillInvalid,TotalBillBuyInvalid,Adding,Pay,Paid,NamePrint From BillingData Where  Name='" + combNameClint.Text + "' and Date >='" + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + "' and Date <='" + Dtp_ToDate.Value.ToString("MM/dd/yyyy") + "'", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;

            //*****************  حساب الباقى ****************
            foreach (DataGridViewRow item in dataGrData.Rows)
            {
                //textBox11.Text = "0";

                int i = item.Index;
                double t = Convert.ToDouble(textBox11.Text);

                double a1 = Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                double a2 = Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                double a3 = Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                double a4 = Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                double a5 = Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                double a6 = Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                double a7 = Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                double a8 = Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                double a9 = Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);



                double total = (a1 + a2 + a3 + a4 + a5) - (a6 + a7 + a8 + a9);

                //dataGrData.Rows[i].Cells[14].Value = (total + t).ToString();

                dataGrData.Rows[i].Cells[14].Value = Math.Round((total + t), 2).ToString();


                //dataGrData.Rows[i].Cells[14].Value =
                //    ((Convert.ToDouble(dataGrData.Rows[i].Cells[4].Value) -
                //     Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value)) + t).ToString();

                textBox11.Text = dataGrData.Rows[i].Cells[14].Value.ToString();


            }

            //------------  دائن مدين ------------
            double s1 = 0;
            double s2 = 0;
            double s3 = 0;
            double s4 = 0;
            double s5 = 0;
            double s6 = 0;
            double s7 = 0;
            double s8 = 0;
            double s9 = 0;
            for (int i = 0; i < dataGrData.RowCount; ++i)
            {
                s1 += Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                s2 += Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                s3 += Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                s4 += Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                s5 += Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                s6 += Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                s7 += Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                s8 += Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                s9 += Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);

            }
            txtMabeaat.Text = s1.ToString();
            txtMoshtariat.Text = s7.ToString();
            txtDisMab.Text = s6.ToString();
            txtDisMosh.Text = s2.ToString();
            txtMardMab.Text = s8.ToString();
            txtMardMosh.Text = s3.ToString();
            txtAdd.Text = s4.ToString();
            txtDaf.Text = s5.ToString();
            txtTahsel.Text = s9.ToString();

            //textBox5.Text = s1.ToString(); //---- مدين
            //textBox4.Text = s2.ToString(); // --- دائن

            //---------- ايجاد الرصيد الحالى للعميل
            txtRemaningOld.Visible = true;
            label1.Visible = true;
            GetOldRasedClient();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {

                //adap = new SqlDataAdapter("Select NumBill,Name,Type,Move,Date,TotalBill,Discount,TotalBillBuy,DiscountBuy,TotalBillInvalid,TotalBillBuyInvalid,Adding,Pay,Paid From BillingData Where Date >='" + Dtp_FromDate1.Value.ToString("MM/dd/yyyy") + "' and Date <='" + Dtp_ToDate1.Value.ToString("MM/dd/yyyy") + "'", cn);


                //ds = new System.Data.DataSet();
                //adap.Fill(ds, "BillingData_Detail");
                //dataGrData.DataSource = ds.Tables[0];

                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select NumBill,Name,Type,Move,Date,TotalBill,Discount,TotalBillBuy,DiscountBuy,TotalBillInvalid,TotalBillBuyInvalid,Adding,Pay,Paid,NamePrint From BillingData Where Date >='" + Dtp_FromDate1.Value.ToString("MM/dd/yyyy") + "' and Date <='" + Dtp_ToDate1.Value.ToString("MM/dd/yyyy") + "'", cn);
                da11.Fill(dt11);
                this.dataGrData.DataSource = dt11;

                //*****************  حساب الباقى ****************
                //foreach (DataGridViewRow item in dataGrData.Rows)
                //{
                //    int i = item.Index;
                //    double t = Convert.ToDouble(textBox11.Text);

                //    double a1 = Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                //    double a2 = Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                //    double a3 = Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                //    double a4 = Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                //    double a5 = Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                //    double a6 = Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                //    double a7 = Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                //    double a8 = Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                //    double a9 = Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);



                //    double total = (a1 + a2 + a3 + a4 + a5) - (a6 + a7 + a8 + a9);

                //    dataGrData.Rows[i].Cells[14].Value = (total + t).ToString();

                //    //dataGrData.Rows[i].Cells[14].Value =
                //    //    ((Convert.ToDouble(dataGrData.Rows[i].Cells[4].Value) -
                //    //     Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value)) + t).ToString();

                //    textBox11.Text = dataGrData.Rows[i].Cells[14].Value.ToString();


                //}

                //------------  دائن مدين ------------
                double s1 = 0;
                double s2 = 0;
                double s3 = 0;
                double s4 = 0;
                double s5 = 0;
                double s6 = 0;
                double s7 = 0;
                double s8 = 0;
                double s9 = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    s1 += Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                    s2 += Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                    s3 += Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                    s4 += Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                    s5 += Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                    s6 += Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                    s7 += Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                    s8 += Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                    s9 += Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);

                }
                txtMabeaat.Text = s1.ToString();
                txtMoshtariat.Text = s7.ToString();
                txtDisMab.Text = s6.ToString();
                txtDisMosh.Text = s2.ToString();
                txtMardMab.Text = s8.ToString();
                txtMardMosh.Text = s3.ToString();
                txtAdd.Text = s4.ToString();
                txtDaf.Text = s5.ToString();
                txtTahsel.Text = s9.ToString();

                //---------- ايجاد الرصيد الحالى للعميل
                //  GetOldRasedClient();
                txtRemaningOld.Visible = false;
                label1.Visible = false;


            }
            else if (checkBox1.Checked == true)
            {
                //-------------------- اجمالى العملاء

                DataTable dt126 = new DataTable();
                dt126.Clear();
                //  SqlDataAdapter daa = new SqlDataAdapter("Select TOP 15 Date,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit Where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);//BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);

                SqlDataAdapter da216 = new SqlDataAdapter("select Name,NumBill='" + 0 + "',Move='" + 0 + "',Type='" + 0 + "',ROUND(sum(TotalBill),2) as TotalBill,ROUND(sum(TotalBillBuy),2) as TotalBillBuy,ROUND(sum(DiscountBuy),2) as DiscountBuy,ROUND(sum(TotalBillInvalid),2) as TotalBillInvalid,ROUND(sum(TotalBillBuyInvalid), 2) as TotalBillBuyInvalid,ROUND(sum(Creditor), 2) as Creditor,ROUND(sum(Discount), 2) as Discount,ROUND(sum(Adding), 2) as Adding,ROUND(sum(Pay), 2) as Pay,ROUND(sum(Paid), 2) as Paid from BillingData Where Date >='" + Dtp_FromDate1.Value.ToString("MM/dd/yyyy") + "' and Date <='" + Dtp_ToDate1.Value.ToString("MM/dd/yyyy") + "' GROUP BY Name ORDER BY TotalBill DESC", cn); // ASC تصاعدى  --- DESC تنازلى


                //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
                da216.Fill(dt126);

                this.dataGrData.DataSource = dt126;

                //*****************  حساب الباقى ****************
                foreach (DataGridViewRow item in dataGrData.Rows)
                {
                    int i = item.Index;
                    double t = Convert.ToDouble(textBox11.Text);

                    double a1 = Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                    double a2 = Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                    double a3 = Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                    double a4 = Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                    double a5 = Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                    double a6 = Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                    double a7 = Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                    double a8 = Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                    double a9 = Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);



                    double total = (a1 + a2 + a3 + a4 + a5) - (a6 + a7 + a8 + a9);

                    //dataGrData.Rows[i].Cells[14].Value = (total + t).ToString();

                    dataGrData.Rows[i].Cells[14].Value = Math.Round((total + t), 2).ToString();




                    //dataGrData.Rows[i].Cells[14].Value =
                    //    ((Convert.ToDouble(dataGrData.Rows[i].Cells[4].Value) -
                    //     Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value)) + t).ToString();

                    // textBox11.Text = dataGrData.Rows[i].Cells[14].Value.ToString();


                }

                //------------  دائن مدين ------------
                double s1 = 0;
                double s2 = 0;
                double s3 = 0;
                double s4 = 0;
                double s5 = 0;
                double s6 = 0;
                double s7 = 0;
                double s8 = 0;
                double s9 = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    s1 += Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                    s2 += Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                    s3 += Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                    s4 += Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                    s5 += Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                    s6 += Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                    s7 += Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                    s8 += Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                    s9 += Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);

                }
                txtMabeaat.Text = s1.ToString();
                txtMoshtariat.Text = s7.ToString();
                txtDisMab.Text = s6.ToString();
                txtDisMosh.Text = s2.ToString();
                txtMardMab.Text = s8.ToString();
                txtMardMosh.Text = s3.ToString();
                txtAdd.Text = s4.ToString();
                txtDaf.Text = s5.ToString();
                txtTahsel.Text = s9.ToString();
            }
        }

        private void combNameClint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {
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
        public class Class_Clint_Move
        {

            public string NumBill { get; set; }
            public string Name { get; set; }
            public string Move { get; set; }
            public string dateDateDay { get; set; }
            public string Mabeaat { get; set; }
            public string DisMabeaat { get; set; }
            public string Moshtaraiat { get; set; }
            public string DisMoshtaraiat { get; set; }
            public string MardMabeaat { get; set; }
            public string MardMoshtaraiat { get; set; }
            public string Adding { get; set; }
            public string Tawreed { get; set; }
            public string Tahseel { get; set; }
            public string Remaining { get; set; }


        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false)
            {
                AppSetting.date_From = Dtp_FromDate1.Text;
                AppSetting.date_To = Dtp_ToDate1.Text;
                AppSetting.client_name = combNameClint.Text;
                AppSetting.Clientall = "Client";
                ////-----------------------------------------------
                List<Class_Clint_Move> BM = new List<Class_Clint_Move>();
                BM.Clear();
                //---------------- رصيد بداية المده -------------
                Class_Clint_Move Box_Move1 = new Class_Clint_Move
                {
                    //  Note = combNameClint.Text + " " + "الفترة من" + " " + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + " " + "الى" + " " + Dtp_ToDate.Value.ToString("MM/dd/yyyy");
                    NumBill = "#",
                    Move = "رصيد بداية المدة",
                    dateDateDay = Dtp_FromDate.Text,
                    Mabeaat = "0",
                    DisMabeaat = "0",
                    Moshtaraiat = "0",
                    DisMoshtaraiat = "0",
                    MardMabeaat = "0",
                    MardMoshtaraiat = "0",
                    Adding = "0",
                    Tawreed = "0",
                    Tahseel = "0",
                    Remaining = txtReminngOLD.Text

                };

                BM.Add(Box_Move1);
                //------------------------------------------------
                for (int i = 0; i < dataGrData.Rows.Count; i++)
                {
                    dateDateDay.Text = dataGrData.Rows[i].Cells[4].Value.ToString();

                    Class_Clint_Move Box_Move = new Class_Clint_Move
                    {
                        //  Note = combNameClint.Text + " " + "الفترة من" + " " + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + " " + "الى" + " " + Dtp_ToDate.Value.ToString("MM/dd/yyyy");
                        NumBill = dataGrData.Rows[i].Cells[0].Value.ToString(),
                        Move = dataGrData.Rows[i].Cells[3].Value.ToString(),
                        dateDateDay = dateDateDay.Text.ToString(),
                        Mabeaat = dataGrData.Rows[i].Cells[5].Value.ToString(),
                        DisMabeaat = dataGrData.Rows[i].Cells[6].Value.ToString(),
                        Moshtaraiat = dataGrData.Rows[i].Cells[7].Value.ToString(),
                        DisMoshtaraiat = dataGrData.Rows[i].Cells[8].Value.ToString(),
                        MardMabeaat = dataGrData.Rows[i].Cells[9].Value.ToString(),
                        MardMoshtaraiat = dataGrData.Rows[i].Cells[10].Value.ToString(),
                        Adding = dataGrData.Rows[i].Cells[11].Value.ToString(),
                        Tawreed = dataGrData.Rows[i].Cells[12].Value.ToString(),
                        Tahseel = dataGrData.Rows[i].Cells[13].Value.ToString(),
                        Remaining = dataGrData.Rows[i].Cells[14].Value.ToString()

                    };

                    BM.Add(Box_Move);
                }
                //---------------- رصيد نهاية المده -------------
                //Class_Clint_Move Box_Move2 = new Class_Clint_Move
                //{
                //    //  Note = combNameClint.Text + " " + "الفترة من" + " " + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + " " + "الى" + " " + Dtp_ToDate.Value.ToString("MM/dd/yyyy");
                //    NumBill = "#",
                //    Move = "رصيد بداية المدة",
                //    dateDateDay = Dtp_FromDate.Text,
                //    Mabeaat = "0",
                //    DisMabeaat = "0",
                //    Moshtaraiat = "0",
                //    DisMoshtaraiat = "0",
                //    MardMabeaat = "0",
                //    MardMoshtaraiat = "0",
                //    Adding = "0",
                //    Tawreed = "0",
                //    Tahseel = "0",
                //    Remaining = txtReminngOLD.Text

                //};

                //BM.Add(Box_Move2);
                //------------------------------------------------
                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportClientAccountStatement rbm = new Reports.ReportClientAccountStatement();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                rbm.ShowDialog();
                ////-----------------------------------------------
                ///
            }
            else if (checkBox1.Checked == true)
            {
                AppSetting.Clientall = "ClientAll";
                AppSetting.date_From = Dtp_FromDate1.Text;
                AppSetting.date_To = Dtp_ToDate1.Text;
              //  AppSetting.client_name = combNameClint.Text;

                ////-----------------------------------------------
                List<Class_ClientAccountStatement> BM = new List<Class_ClientAccountStatement>();
                BM.Clear();
                //---------------- رصيد بداية المده -------------
                //Class_Clint_Move Box_Move1 = new Class_Clint_Move
                //{
                //    //  Note = combNameClint.Text + " " + "الفترة من" + " " + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + " " + "الى" + " " + Dtp_ToDate.Value.ToString("MM/dd/yyyy");
                //    NumBill = "#",
                //    Move = "رصيد بداية المدة",
                //    dateDateDay = Dtp_FromDate.Text,
                //    Mabeaat = "0",
                //    DisMabeaat = "0",
                //    Moshtaraiat = "0",
                //    DisMoshtaraiat = "0",
                //    MardMabeaat = "0",
                //    MardMoshtaraiat = "0",
                //    Adding = "0",
                //    Tawreed = "0",
                //    Tahseel = "0",
                //    Remaining = txtReminngOLD.Text

                //};

                //BM.Add(Box_Move1);
                //------------------------------------------------
                for (int i = 0; i < dataGrData.Rows.Count; i++)
                {
                    // dateDateDay.Text = Dtp_ToDate.Value.ToString();
                    //            public string NumBill { get; set; }
                    //public string Name { get; set; }
                    //public string Type { get; set; }
                    //public string Move { get; set; }
                    //public string Date { get; set; }
                    //public string TotalBill { get; set; }
                    //public string Discount { get; set; }
                    //public string TotalBillBuy { get; set; }
                    //public string DiscountBuy { get; set; }
                    //public string TotalBillInvalid { get; set; }
                    //public string TotalBillBuyInvalid { get; set; }
                    //public string Adding { get; set; }
                    //public string Pay { get; set; }
                    //public string Paid { get; set; }
                    //public string Remaining { get; set; }
                    //public string NamePrint { get; set; }

                    Class_ClientAccountStatement Box_Move = new Class_ClientAccountStatement
                    {
                        //  Note = combNameClint.Text + " " + "الفترة من" + " " + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + " " + "الى" + " " + Dtp_ToDate.Value.ToString("MM/dd/yyyy");
                      //  NumBill = dataGrData.Rows[i].Cells[0].Value.ToString(),
                        Name = dataGrData.Rows[i].Cells[1].Value.ToString(),
                            // dateDateDay = dateDateDay.Text.ToString(),
                            TotalBill = dataGrData.Rows[i].Cells[5].Value.ToString(),
                        Discount = dataGrData.Rows[i].Cells[6].Value.ToString(),
                        TotalBillBuy = dataGrData.Rows[i].Cells[7].Value.ToString(),
                        DiscountBuy = dataGrData.Rows[i].Cells[8].Value.ToString(),
                        TotalBillInvalid = dataGrData.Rows[i].Cells[9].Value.ToString(),
                        TotalBillBuyInvalid = dataGrData.Rows[i].Cells[10].Value.ToString(),
                        Adding = dataGrData.Rows[i].Cells[11].Value.ToString(),
                        Pay = dataGrData.Rows[i].Cells[12].Value.ToString(),
                        Paid = dataGrData.Rows[i].Cells[13].Value.ToString(),
                        Remaining = dataGrData.Rows[i].Cells[14].Value.ToString()

                    };

                    BM.Add(Box_Move);
                }
               
                //------------------------------------------------
                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportClientAccountStatement rbm = new Reports.ReportClientAccountStatement();
                rbm.reportViewer2.LocalReport.DataSources.Clear();
                rbm.reportViewer2.LocalReport.DataSources.Add(rs);
                rbm.ShowDialog();
            }
        }

        private void dataGrData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Move = dataGrData.Rows[e.RowIndex].Cells[3].Value.ToString();
            string NumBill = dataGrData.Rows[e.RowIndex].Cells[0].Value.ToString();
            //textBox1.Text = dataGrData.Rows[e.RowIndex].Cells[3].Value.ToString();
            //textBox2.Text = dataGrData.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (Move == "فاتورة مبيعات")
            {
               // this.Close();

                TransferData.FormName = "فاتورة مبيعات";
                TransferData.NumBillFromAcount = NumBill;

                if (Sales1 == null || Sales1.IsDisposed == true)
                {
                    Sales1 = new Sales();
                }
                Sales1.MdiParent = Main.ActiveForm;
                Sales1.Show();

                TransferData.NumBillFromAcount = "";
            }
            else if (Move == "فاتورة مشتريات")
            {
                //this.Close();

                TransferData.FormName = "فاتورة مشتريات";
                TransferData.NumBillFromAcount = NumBill;

                if (Purchases1 == null || Purchases1.IsDisposed == true)
                {
                    Purchases1 = new Purchases();
                }
                Purchases1.MdiParent = Main.ActiveForm;
                Purchases1.Show();
                
                TransferData.NumBillFromAcount = "";
            }

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
            combNameClint.Text = dataGridSearchClint.Rows[e.RowIndex].Cells[1].Value.ToString();
            panel10.Visible = false;
        }

        private void butSumClients_Click(object sender, EventArgs e)
        {
            //-------------------- اجمالى العملاء

            DataTable dt126 = new DataTable();
            dt126.Clear();
            //  SqlDataAdapter daa = new SqlDataAdapter("Select TOP 15 Date,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit Where  Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);//BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'", cn);

            SqlDataAdapter da216 = new SqlDataAdapter("select Name,NumBill='" + 0 + "',Move='" + 0 + "',Type='" + 0 + "',ROUND(sum(TotalBill),2) as TotalBill,ROUND(sum(TotalBillBuy),2) as TotalBillBuy,ROUND(sum(DiscountBuy),2) as DiscountBuy,ROUND(sum(TotalBillInvalid),2) as TotalBillInvalid,ROUND(sum(TotalBillBuyInvalid), 2) as TotalBillBuyInvalid,ROUND(sum(Creditor), 2) as Creditor,ROUND(sum(Discount), 2) as Discount,ROUND(sum(Adding), 2) as Adding,ROUND(sum(Pay), 2) as Pay,ROUND(sum(Paid), 2) as Paid from BillingData Where Date >= '" + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + Dtp_ToDate.Value.ToString("MM/dd/yyyy") + "' GROUP BY Name ORDER BY TotalBill DESC", cn); // ASC تصاعدى  --- DESC تنازلى


            //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da216.Fill(dt126);

            this.dataGrData.DataSource = dt126;

            //*****************  حساب الباقى ****************
            foreach (DataGridViewRow item in dataGrData.Rows)
            {
                int i = item.Index;
                double t = Convert.ToDouble(textBox11.Text);

                double a1 = Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                double a2 = Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                double a3 = Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                double a4 = Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                double a5 = Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                double a6 = Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                double a7 = Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                double a8 = Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                double a9 = Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);



                double total = (a1 + a2 + a3 + a4 + a5) - (a6 + a7 + a8 + a9);

                //dataGrData.Rows[i].Cells[14].Value = (total + t).ToString();

                dataGrData.Rows[i].Cells[14].Value = Math.Round((total + t), 2).ToString();




                //dataGrData.Rows[i].Cells[14].Value =
                //    ((Convert.ToDouble(dataGrData.Rows[i].Cells[4].Value) -
                //     Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value)) + t).ToString();

               // textBox11.Text = dataGrData.Rows[i].Cells[14].Value.ToString();


            }

            //------------  دائن مدين ------------
            double s1 = 0;
            double s2 = 0;
            double s3 = 0;
            double s4 = 0;
            double s5 = 0;
            double s6 = 0;
            double s7 = 0;
            double s8 = 0;
            double s9 = 0;
            for (int i = 0; i < dataGrData.RowCount; ++i)
            {
                s1 += Convert.ToDouble(dataGrData.Rows[i].Cells[5].Value);
                s2 += Convert.ToDouble(dataGrData.Rows[i].Cells[8].Value);
                s3 += Convert.ToDouble(dataGrData.Rows[i].Cells[10].Value);
                s4 += Convert.ToDouble(dataGrData.Rows[i].Cells[11].Value);
                s5 += Convert.ToDouble(dataGrData.Rows[i].Cells[12].Value);
                s6 += Convert.ToDouble(dataGrData.Rows[i].Cells[6].Value);
                s7 += Convert.ToDouble(dataGrData.Rows[i].Cells[7].Value);
                s8 += Convert.ToDouble(dataGrData.Rows[i].Cells[9].Value);
                s9 += Convert.ToDouble(dataGrData.Rows[i].Cells[13].Value);

            }
            txtMabeaat.Text = s1.ToString();
            txtMoshtariat.Text = s7.ToString();
            txtDisMab.Text = s6.ToString();
            txtDisMosh.Text = s2.ToString();
            txtMardMab.Text = s8.ToString();
            txtMardMosh.Text = s3.ToString();
            txtAdd.Text = s4.ToString();
            txtDaf.Text = s5.ToString();
            txtTahsel.Text = s9.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
