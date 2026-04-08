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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace ZAD_Sales.Forms
{
    public partial class Profits : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        private SqlDataReader reed;

        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();


        public Profits()
        {
            InitializeComponent();
            //cn.Open();
            sqlCommand1.Connection = cn;
        }
        public class Class_Profits
        {

            public string NumBill { get; set; }
            public string Date { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string Type { get; set; }
            public string PriceShraa { get; set; }
            public string PriceBeaa { get; set; }
            public string Profit { get; set; }


        }
        private void saveEvents(string Event)
        {

            //=========================== تسجيل الحركات  ========================== 
            try
            {
                cn.Open();
                //string Event = "تم فتح شاشة  " + TransferData.FormName;

                string date11 = DateTime.Now.ToString("M/d/yyyy");
                sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + date11 + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                
                
                
                
                //   cmd.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";

                sqlCommand1.ExecuteNonQuery();

                //sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                //    sqlCommand1.ExecuteNonQuery();

                // MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");

                cn.Close();
                //---------------


            }
            catch
            {
                //MessageBox.Show("    فشلللللللللللللللللللللللللللللللل   ", "فشل ");
            }

            //========================== ========================== ========================== 
        }
        private void Profits_Load(object sender, EventArgs e)
        {
            panel7.Visible = false;
            panel10.Visible = false;

            //==========================  تسجيل الحركات  ========================== 


            saveEvents("تم فتح شاشة  " + TransferData.FormName);

            //========================== ========================== =================


            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Profit ", cn);
                da11.Fill(dt11);
                this.dataGridView4.DataSource = dt11;

            }
            catch
            { }


            //----------------- ايجاد الاصناف --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Category from Category", cn);
                Da1.Fill(Dt1);
                combCategorys.DataSource = Dt1;
                combCategorys.DisplayMember = "Category";
            }
            catch
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            textBox1.Visible = false;
            panel6.Visible = false;

            panel10.Visible = false;

            label8.Visible = true;
            TxtMsaref.Visible = true;

            label10.Visible = true;
            textRemeaning.Visible = true;

            textRemeaning.Text = "0";

            txtMasarefOther.Text = "0";
            txtEradatOther.Text = "0";

            label11.Visible = true;
            txtMasarefOther.Visible = true;

            label18.Visible = true;
            txtEradatOther.Visible = true;


            cn.Open();

            DataTable dt12 = new DataTable();
            dt12.Clear();
            SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'", cn);
            da21.Fill(dt12);
            this.dataGridView4.DataSource = dt12;

            //-------------------- اعلى الاصناف ارباحا

            panel3.Visible = true;

            DataTable dt15 = new DataTable();
            dt15.Clear();
            SqlDataAdapter da215 = new SqlDataAdapter("select TOP 15 Category,sum(Quantity) as Quantity,sum(Profit) as Profit from Profit where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' GROUP BY Category ORDER BY Profit DESC", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da215 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da215.Fill(dt15);

            this.dataGridView1.DataSource = dt15;

            //-------------------- اعلى الايام ارباحا خلال فترة

            DataTable dt126 = new DataTable();
            dt126.Clear();
            SqlDataAdapter da216 = new SqlDataAdapter("select TOP 15 Date,sum(Quantity) as Quantity,sum(Profit) as Profit from Profit where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' GROUP BY Date ORDER BY Profit DESC", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da216.Fill(dt126);

            this.dataGridView2.DataSource = dt126;

            //-------------------------------------------------
            TxtMsaref.Text = "0";
            //try
            //{


            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended where  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;



            int sum = 0;
            for (int i = 0; i < dataGrData.RowCount; ++i)
            {
                sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


            }
            TxtMsaref.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            //}
            //catch
            //{ }

            //------------------------------------------------

            // ايجاد الايرادات والمصاريف الاخرى




            //try
            //{


                DataTable dt111 = new DataTable();
                dt111.Clear();
                SqlDataAdapter da111 = new SqlDataAdapter("select ID as م ,Date as التاريخ ,ExpensesOther as الصادر ,IncomeOther as الوارد ,Statement as البيان  from CategoryOthers where  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ", cn);
                da111.Fill(dt111);
                this.dataGridView3.DataSource = dt111;

                //-----------------------------

                int sum2 = 0;
                int sum1 = 0;
                for (int i = 0; i < dataGridView3.RowCount; ++i)
                {
                    sum2 += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    sum1 += Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value);

                }
                txtMasarefOther.Text = Math.Round(Convert.ToDouble(sum2.ToString()), 2).ToString();
                txtEradatOther.Text = Math.Round(Convert.ToDouble(sum1.ToString()), 2).ToString();
            //}
            //catch
            //{ }


            //-------------------------------------------------
            try
            {
                TxtTotalDisc.Text = "0";
                sqlCommand1.CommandText = "select SUM(Discount) as Discount From BillingData Where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    TxtTotalDisc.Text = "0";
                    string Discount = reed["Discount"].ToString();


                    //-------------------------------------------

                    TxtTotalDisc.Text = Math.Round(double.Parse(Discount), 2).ToString();

                }
            }
            catch { }


            //------------------------------

            


            CountAll();


            cn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel6.Visible = false;

            panel10.Visible = false;

            label8.Visible = false;
            TxtMsaref.Visible = false;

            label10.Visible = true;
            textRemeaning.Visible = true;

            textRemeaning.Text = "0";

            txtMasarefOther.Text = "0";
            txtEradatOther.Text = "0";

            label11.Visible = false;
            txtMasarefOther.Visible = false;

            label18.Visible = false;
            txtEradatOther.Visible = false;

            cn.Open();

            DataTable dt12 = new DataTable();
            dt12.Clear();
            SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where  NumBill='" + textBox14.Text + "'", cn);
            da21.Fill(dt12);
            this.dataGridView4.DataSource = dt12;

            //-------------------------------------------------
            try
            {
                TxtTotalDisc.Text = "0";
                sqlCommand1.CommandText = "select SUM(Discount) as Discount From BillingData Where NumBill='" + textBox14.Text + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    TxtTotalDisc.Text = "0";
                    string Discount = reed["Discount"].ToString();


                    //-------------------------------------------

                    TxtTotalDisc.Text = Math.Round(double.Parse(Discount), 2).ToString();

                }
                reed.Close();
            }
            catch { }


            //------------------------------
            CountAll();

            cn.Close();
        }
        private void GetExpenses() // ايجاد المصاريف
        {
            TxtMsaref.Text = "0";
            try
            {
               

                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended where  Date >='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and  Date <='" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da11.Fill(dt11);
                this.dataGrData.DataSource = dt11;
            }
            catch
            { }


            // ***  إجمالى المصاريف  ****
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


                }
                TxtMsaref.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            }
            catch
            { }

            
        }
        private void button11_Click(object sender, EventArgs e)
        {
            label8.Visible = true;
            TxtMsaref.Visible = true;

            panel10.Visible = false;

            TxtMsaref.Text = "0";

            label10.Visible = true;
            textRemeaning.Visible = true;

            textRemeaning.Text = "0";
            txtMasarefOther.Text = "0";
            txtEradatOther.Text = "0";

            label11.Visible = true;
            txtMasarefOther.Visible = true;

            label18.Visible = true;
            txtEradatOther.Visible = true;


            cn.Open();

            try
            {
                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;
            }
            catch
            { }


            //-------------------- اعلى الاصناف ارباحا
            //Total = Math.Round(double.Parse(r.ToString()), 2).ToString();

            panel3.Visible = true;
            panel4.Visible = true;
            textBox1.Visible = false;
            panel6.Visible = false;

            try
            { 

            DataTable dt15 = new DataTable();
            dt15.Clear();
            SqlDataAdapter da215 = new SqlDataAdapter("select TOP 15 Category,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' GROUP BY Category ORDER BY Profit DESC", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da215 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da215.Fill(dt15);

            this.dataGridView1.DataSource = dt15;

            }
            catch
            { }


            //-------------------- اعلى الايام ارباحا خلال فترة

            try { 
            DataTable dt126 = new DataTable();
            dt126.Clear();
            SqlDataAdapter da216 = new SqlDataAdapter("select TOP 15 Date,ROUND(sum(Quantity),2) as Quantity,ROUND(sum(Profit),2) as Profit from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' GROUP BY Date ORDER BY Profit DESC", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da216.Fill(dt126);

            this.dataGridView2.DataSource = dt126;

            }
            catch
            { }

            //---------------------------------------------

            //GetExpenses(); // ايجاد المصاريف


            

            try
            {


                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended where  Date >='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and  Date <='" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da11.Fill(dt11);
                this.dataGrData.DataSource = dt11;
           
                //-----------------------------

                int sum = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


                }
                TxtMsaref.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            }
            catch
            { }

            //------------------------------------------------

            // ايجاد الايرادات والمصاريف الاخرى




            try
            {


                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select ID as م ,Date as التاريخ ,ExpensesOther as الصادر ,IncomeOther as الوارد ,Statement as البيان  from CategoryOthers where  Date >='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and  Date <='" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' ", cn);
                da11.Fill(dt11);
                this.dataGridView3.DataSource = dt11;

                //-----------------------------

                int sum = 0;
                int sum1 = 0;
                for (int i = 0; i < dataGridView3.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value);
                    sum1 += Convert.ToInt32(dataGridView3.Rows[i].Cells[3].Value);

                }
                txtMasarefOther.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();
                txtEradatOther.Text = Math.Round(Convert.ToDouble(sum1.ToString()), 2).ToString();
            }
            catch
            { }

            //-------------------------------------------------
            try
            {
                TxtTotalDisc.Text = "0";
                sqlCommand1.CommandText = "select SUM(Discount) as Discount From BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    TxtTotalDisc.Text = "0";
                    string Discount = reed["Discount"].ToString();


                    //-------------------------------------------

                    TxtTotalDisc.Text = Math.Round(double.Parse(Discount), 2).ToString();

                }
                reed.Close();
            }
            catch { }


            //------------------------------


            CountAll();

            cn.Close();
        }
        private void CountAll()
        {
            //================================  إيجاد إجمالى الأرباح

            int sum = 0;
            for (int ia = 0; ia < dataGridView4.RowCount; ++ia)
            {
                sum += Convert.ToInt32(dataGridView4.Rows[ia].Cells[7].Value);


            }
            textBox10.Text = sum.ToString();

            //===========================إيجاد إجمالى الشراء  
            int suum = 0;
            for (int iaa = 0; iaa < dataGridView4.RowCount; ++iaa)
            {
                suum += Convert.ToInt32(dataGridView4.Rows[iaa].Cells[5].Value);


            }
            textBox11.Text = suum.ToString();

            //================================  إيجاد إجمالى البيع

            int saum = 0;
            for (int ia = 0; ia < dataGridView4.RowCount; ++ia)
            {
                saum += Convert.ToInt32(dataGridView4.Rows[ia].Cells[6].Value);


            }
            textBox12.Text = saum.ToString();

            //================================  إيجاد إجمالى عدد القطع

            int ssum = 0;
            for (int ii = 0; ii < dataGridView4.RowCount; ++ii)
            {
                ssum += Convert.ToInt32(dataGridView4.Rows[ii].Cells[3].Value);


            }
            textBox13.Text = ssum.ToString();

            //================================  إيجاد صافى الربح بعد الخصم

            try
            {
                double a = Convert.ToDouble(textBox10.Text);
                double b = Convert.ToDouble(TxtTotalDisc.Text);
                double s = a - b;
                //TxtSafeRebh.Text = rcsr.ToString();

                TxtSafeRebh.Text = Math.Round(double.Parse(s.ToString()), 2).ToString();
            }
            catch
            { }
            //================================  إيجاد الصافى بعد المصاريف 

            try
            {
                double a = Convert.ToDouble(TxtSafeRebh.Text);
                double b = Convert.ToDouble(TxtMsaref.Text);
                double s = a - b;
                //TxtSafeRebh.Text = rcsr.ToString();

                textRemeaning.Text = Math.Round(double.Parse(s.ToString()), 2).ToString();
            }
            catch
            { }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            TxtMsaref.Visible = false;

            panel10.Visible = false;

            label10.Visible = false;
            textRemeaning.Visible = false;

            txtMasarefOther.Text = "0";
            txtEradatOther.Text = "0";

            label11.Visible = false;
            txtMasarefOther.Visible = false;

            label18.Visible = false;
            txtEradatOther.Visible = false;



            panel6.Visible = true;
            panel3.Visible = true;
            panel4.Visible = false;
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            textBox1.Visible = true;
            TxtTotalDisc.Text = "0";
            cn.Open();

            DataTable dt12 = new DataTable();
            dt12.Clear();
            SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where Date >= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "' and Category = '" + combCategorys.Text + "' ", cn);
            da21.Fill(dt12);
            this.dataGridView4.DataSource = dt12;

            //-------------------------------------------------

            //-------------------- اعلى الايام ارباحا خلال فترة

            DataTable dt126 = new DataTable();
            dt126.Clear();
            SqlDataAdapter da216 = new SqlDataAdapter("select TOP 30 Date,sum(Quantity) as Quantity,ROUND(sum(Profit),2) as Profit from Profit where   Date >= '" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker4.Value.ToString("MM/dd/yyyy") + "'  and Category = '" + combCategorys.Text + "' GROUP BY Date ORDER BY Profit DESC", cn); // ASC تصاعدى  --- DESC تنازلى

            da216.Fill(dt126);

            this.dataGridView2.DataSource = dt126;


            textBox1.Text = "أعلى الايام ارباح للصنف :  " + combCategorys.Text;
            //-----------------------ايجاد الكمية الموجوده -------

            sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "'   ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
               // CategoryID = reed["ID"].ToString();
              //  textBarcode.Text = reed["Barcode"].ToString();
               // textBox18.Text = reed["Quantity"].ToString();
              //  textBox64.Text = reed["QuantityT"].ToString();
               // textBox19.Text = reed["Unity"].ToString();
               // textBox20.Text = reed["Faction"].ToString();
                textBox2.Text = reed["Total"].ToString();

                //------------------------

               // PriceGomla = reed["PriceGomla"].ToString();
              //  PriceMostahlek = reed["PriceMostahlek"].ToString();
                textPriceShraa.Text = reed["Price"].ToString();
               // FactionCatogrey = reed["Faction"].ToString();
            }
            reed.Close();


            //----------- سعر الشراء

            double ncssn = Convert.ToDouble(textBox2.Text);
            double dcssd = Convert.ToDouble(textPriceShraa.Text);
            double rcssr = ncssn * dcssd;
            textValue.Text = rcssr.ToString();
            textValue.Text = Math.Round(double.Parse(textValue.Text),2).ToString();

            CountAll();

            cn.Close();
        }

        private void Profits_FormClosed(object sender, FormClosedEventArgs e)
        {
            //*************** تسجيل الحركات  ***********************

            saveEvents("تم غلق شاشة  " + TransferData.FormName);

            //********************************************************
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            TxtMsaref.Visible = false;

            panel3.Visible = true;

            cn.Open();

            DataTable dt12 = new DataTable();
            dt12.Clear();
            SqlDataAdapter da21 = new SqlDataAdapter("select TOP 15 Date,sum(Quantity) as Quantity,sum(Profit) as Profit from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "' GROUP BY Date ORDER BY Profit DESC", cn); // ASC تصاعدى  --- DESC تنازلى

            //  SqlDataAdapter da21 = new SqlDataAdapter("select * from Profit where   Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'", cn);
            da21.Fill(dt12);

            this.dataGridView2.DataSource = dt12;

            //-------------------------------------------------
            try
            {
                TxtTotalDisc.Text = "0";
                sqlCommand1.CommandText = "select SUM(Discount) as Discount From BillingData Where Date >= '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' and Date <= '" + dateTimePicker5.Value.ToString("MM/dd/yyyy") + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    TxtTotalDisc.Text = "0";
                    string Discount = reed["Discount"].ToString();


                    //-------------------------------------------

                    TxtTotalDisc.Text = Math.Round(double.Parse(Discount), 2).ToString();

                }
                reed.Close();
            }
            catch { }


            //------------------------------
            CountAll();

            cn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if(panel7.Visible==true)
            {
                panel7.Visible = false;
            }
            else
            {
                panel7.Visible = true;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {
                panel10.Visible = false;
            }
            else
            {
                panel10.Visible = true;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {
                panel10.Visible = false;
            }
            else
            {
                panel10.Visible = true;
            }
        }
    }
}
