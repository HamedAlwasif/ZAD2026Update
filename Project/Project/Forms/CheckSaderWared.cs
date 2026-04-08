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
//using JbsaPrintDataGridView;

namespace ZAD_Sales.Forms
{
    public partial class CheckSaderWared : Form
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
        public CheckSaderWared()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void CheckSaderWared_Load(object sender, EventArgs e)
        {
            // إيجاد حركة 
            textBox6.Text = FormName;

            // ايجاد رقم الفاتورة
            try
            {


                sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["NumBill"].ToString());
                    double aa = s + 1;
                    textBillingDataNumBill.Text = aa.ToString();

                }
                red.Close();

                if (textBillingDataNumBill.Text == "0")
                {
                    textBillingDataNumBill.Text = "1";
                }
                else
                { }



            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            // إيجاد رقم حركة الصندوق

            try
            {
                sqlCommand1.CommandText = "select * From BoxMove  Where ID =(select max(ID) from BoxMove) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["ID"].ToString());
                    double aa = s + 1;
                    textMoveBoxID.Text = aa.ToString();

                }
                red.Close();

                if (textMoveBoxID.Text == "0")
                {
                    textMoveBoxID.Text = "1";
                }
                else
                { }
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            // ايجاد الاصناف فى الفاتورة
            //------------------------------------
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from SheekSave ", cn);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;

            //// إيجاد رقم حركة الصندوق
            //comboBox9.SelectedIndex = comboBox9.Items.Count - 1;

            //int iiii = int.Parse(comboBox9.Text);
            //int jjjj = iiii + 1;
            //textMoveBoxID.Text = jjjj.ToString();

            //// إيجاد رقم الفاتورة
            //comboBox5.SelectedIndex = comboBox5.Items.Count - 1;

            //int i = int.Parse(comboBox5.Text);
            //int j = i + 1;
            //textBillingDataNumBill.Text = j.ToString();

            //  textBox5.Text = textBox21.Text;

            //---- إيجاد ارقام الحساب
            SqlDataAdapter Da3;
            DataTable Dt3 = new DataTable();
            Da3 = new SqlDataAdapter("select NumHesab from Bank ", cn);
            Da3.Fill(Dt3);
            comboBox1.DataSource = Dt3;
            comboBox1.DisplayMember = "NumHesab";

            //---- إيجاد أسماء العملاء 
            SqlDataAdapter Da13;
            DataTable Dt13 = new DataTable();
            Da13 = new SqlDataAdapter("select Name from Clients ", cn);
            Da13.Fill(Dt13);
            comboBox2.DataSource = Dt13;
            comboBox2.DisplayMember = "Name";

            //---- إيجاد ارقام شيكات اليوم
            SqlDataAdapter Da31;
            DataTable Dt31 = new DataTable();
            Da31 = new SqlDataAdapter("select NumSkeek from BankHesab where Move ='" + textBox6.Text + "' ", cn);
            Da31.Fill(Dt31);
            listBox1.DataSource = Dt31;
            listBox1.DisplayMember = "NumSkeek";

            //-----------------------------------------------------
            if (textBox6.Text == "شيك وارد")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "مدين";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الواردة";

                //----------------
                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da1.Fill(dt1);
                this.dataGridView1.DataSource = dt1;

            }
            else if (textBox6.Text == "كمبيالة واردة")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "مدين";

                radioButton1.Text = "صرف للبنك";
                radioButton2.Text = "صرف للخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الواردة";

                //----------------
                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da2.Fill(dt2);
                this.dataGridView1.DataSource = dt2;

            }
            else if (textBox6.Text == "شيك صادر")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt3 = new DataTable();
                dt3.Clear();
                SqlDataAdapter da3 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da3.Fill(dt3);
                this.dataGridView1.DataSource = dt3;
            }
            else if (textBox6.Text == "كمبيالة صادرة")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt4 = new DataTable();
                dt4.Clear();
                SqlDataAdapter da4 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da4.Fill(dt4);
                this.dataGridView1.DataSource = dt4;

            }

            // **** الشيكات الاجمالى
            int sum = 0;
            for (int aa = 0; aa < dataGridView1.RowCount; ++aa)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[aa].Cells[0].Value);


            }
            textBox26.Text = sum.ToString();

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (FormName == "شيك وارد")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "مدين";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الواردة";

                //----------------
                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da1.Fill(dt1);
                this.dataGridView1.DataSource = dt1;

            }
            else if (FormName == "كمبيالة واردة")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "مدين";

                radioButton1.Text = "صرف للبنك";
                radioButton2.Text = "صرف للخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الواردة";

                //----------------
                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da2.Fill(dt2);
                this.dataGridView1.DataSource = dt2;

            }
            else if (FormName == "شيك صادر")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt3 = new DataTable();
                dt3.Clear();
                SqlDataAdapter da3 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da3.Fill(dt3);
                this.dataGridView1.DataSource = dt3;
            }
            else if (FormName == "كمبيالة صادرة")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt4 = new DataTable();
                dt4.Clear();
                SqlDataAdapter da4 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox28.Text + "' ", cn);
                da4.Fill(dt4);
                this.dataGridView1.DataSource = dt4;

            }

            // **** الشيكات الاجمالى
            int sum = 0;
            for (int aa = 0; aa < dataGridView1.RowCount; ++aa)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[aa].Cells[0].Value);


            }
            textBox26.Text = sum.ToString();

            //---------------
            //  label15.Text = " الشيكات التى لم تصرف";

            //button7.Visible = false;
            button5.Visible = true;

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;

            if (textBox6.Text == "شيك وارد")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "مدين";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الواردة";

                //----------------
                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox29.Text + "' ", cn);
                da1.Fill(dt1);
                this.dataGridView1.DataSource = dt1;

            }
            else if (textBox6.Text == "كمبيالة واردة")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "مدين";

                radioButton1.Text = "صرف للبنك";
                radioButton2.Text = "صرف للخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الواردة";

                //----------------
                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox29.Text + "' ", cn);
                da2.Fill(dt2);
                this.dataGridView1.DataSource = dt2;

            }
            else if (textBox6.Text == "شيك صادر")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt3 = new DataTable();
                dt3.Clear();
                SqlDataAdapter da3 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox29.Text + "' ", cn);
                da3.Fill(dt3);
                this.dataGridView1.DataSource = dt3;
            }
            else if (textBox6.Text == "كمبيالة صادرة")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt4 = new DataTable();
                dt4.Clear();
                SqlDataAdapter da4 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "' and State ='" + textBox29.Text + "' ", cn);
                da4.Fill(dt4);
                this.dataGridView1.DataSource = dt4;

            }

            // **** الشيكات الاجمالى
            int sum = 0;
            for (int aa = 0; aa < dataGridView1.RowCount; ++aa)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[aa].Cells[0].Value);


            }
            textBox26.Text = sum.ToString();

            //---------------
            label15.Text = " الشيكات التى تم صرفها";


            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "شيك وارد")
            {
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "مدين";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الواردة";

                //----------------
                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "'  ", cn);
                da1.Fill(dt1);
                this.dataGridView1.DataSource = dt1;

            }
            else if (textBox6.Text == "كمبيالة واردة")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "مدين";

                radioButton1.Text = "صرف للبنك";
                radioButton2.Text = "صرف للخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الواردة";

                //----------------
                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "'  ", cn);
                da2.Fill(dt2);
                this.dataGridView1.DataSource = dt2;

            }
            else if (textBox6.Text == "شيك صادر")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = false;

                textBox7.Text = "شيك";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "الشيكــــــــــات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt3 = new DataTable();
                dt3.Clear();
                SqlDataAdapter da3 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "'  ", cn);
                da3.Fill(dt3);
                this.dataGridView1.DataSource = dt3;
            }
            else if (textBox6.Text == "كمبيالة صادرة")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;

                textBox7.Text = "كمبيالة";
                textBox8.Text = "دائن";

                radioButton1.Text = "صرف من البنك";
                radioButton2.Text = "صرف من الخزينة";

                label15.Text = "  الكمبيـــالات المحفوظـــــة الصادرة";

                //----------------
                DataTable dt4 = new DataTable();
                dt4.Clear();
                SqlDataAdapter da4 = new SqlDataAdapter("Select * From SheekSave where Move ='" + textBox7.Text + "' and TypeMove ='" + textBox8.Text + "'  ", cn);
                da4.Fill(dt4);
                this.dataGridView1.DataSource = dt4;

            }

            // **** الشيكات الاجمالى
            int sum = 0;
            for (int aa = 0; aa < dataGridView1.RowCount; ++aa)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[aa].Cells[0].Value);


            }
            textBox26.Text = sum.ToString();

            //---------------
            label15.Text = "  جميع الشيكات : صرفت - لم تصرف - حذفت";

            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //PrintJbsaDataGridView.Print_Grid(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //---  كمبياله صادرة
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال العملية ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (radioButton1.Checked == true) //----  صرف من البنك
                {
                    double n = Convert.ToDouble(textBox10.Text); //----- قيمة الكمبياله
                    double d = Convert.ToDouble(textBox14.Text);//-- رصيد البنك
                    double r = d - n;
                    textBox15.Text = r.ToString();

                    //------------------------ تعديل رصيد البنك
                    sqlCommand1.CommandText = "update Bank set  Rased='" + textBox15.Text + "',  DateLast ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  where NumHesab='" + comboBox1.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //------------------------ اضافة فى كشف حساب البنك
                    sqlCommand1.CommandText = "insert into BankHesab (NumHesab,BankName,Department,Date,Move,Remaining1,Maden,Daen,Remaining,NumSkeek,Name,ValueSheek,dateDay,DateElestehkak,Note)values ('" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox13.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox14.Text + "','" + textBox10.Text + "','" + 0 + "','" + textBox15.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + textBox12.Text + "')";
                    sqlCommand1.ExecuteNonQuery();

                    //-----------------------  حذف الشيك من المحفوظات
                    //sqlCommand1.CommandText = "delete from SheekSave where NumSkeek = '" + textBox9.Text + "'   ";
                    //sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //---  تعديل حساب العميل

                    //---  تعديل حساب العميل

                    double n1 = Convert.ToDouble(textBox17.Text); // رصيد للعميل
                    double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                    double r1 = n1 + d1;
                    textBox21.Text = r1.ToString();

                    double n11 = Convert.ToDouble(textBox21.Text); // اجمالى مالنا بعد اضافة القيمة الصادرة
                    double d11 = Convert.ToDouble(textBox18.Text); // رصيد له
                    if (n11 < d11) //--- له اكبر = دائن
                    {
                        double wwa = d11 - n11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "دائن";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (d11 < n11) // لنا اكبر = مدين
                    {
                        double wwa = n11 - d11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "مدين";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else //-------- خالص
                    {
                        textBox23.Text = "خالص";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                }
                else //---- صرف من الخزينة
                {
                    //---- حساب اجمالى الصندوق
                    double q1S = Convert.ToDouble(textBox16.Text); //-  رصيد الخزينة
                    double l1S = Convert.ToDouble(textBox10.Text); //-- قيمة الكمبياله
                    double w1S = q1S - l1S;
                    textBox25.Text = w1S.ToString();

                    sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + textBox25.Text + "' , Date ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //----------  إضافة حركة الصندوق

                    try
                    {
                        sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + textMoveBoxID.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + comboBox2.Text + "','" + textBillingDataNumBill.Text + "','" + textBox16.Text + "','" + textBox10.Text + "','" + 0 + "','" + textBox25.Text + "','" + textBox12.Text + "')";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    catch
                    {

                    }


                    //-----------------------  حذف الشيك من المحفوظات
                    //sqlCommand1.CommandText = "delete from SheekSave where NumSkeek = '" + textBox9.Text + "'   ";
                    //sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //---  تعديل حساب العميل

                    //---  تعديل حساب العميل

                    double n1 = Convert.ToDouble(textBox17.Text); // رصيد للعميل
                    double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                    double r1 = n1 + d1;
                    textBox21.Text = r1.ToString();

                    double n11 = Convert.ToDouble(textBox21.Text); // اجمالى مالنا بعد اضافة القيمة الصادرة
                    double d11 = Convert.ToDouble(textBox18.Text); // رصيد له
                    if (n11 < d11) //--- له اكبر = دائن
                    {
                        double wwa = d11 - n11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "دائن";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (d11 < n11) // لنا اكبر = مدين
                    {
                        double wwa = n11 - d11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "مدين";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else //-------- خالص
                    {
                        textBox23.Text = "خالص";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //---  شيك وارد

            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال العملية ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (radioButton1.Checked == true) //---- صرف للبنك
                {
                    double n = Convert.ToDouble(textBox10.Text);// قيمة الشيك
                    double d = Convert.ToDouble(textBox14.Text); // رصيد البنك
                    double r = n + d;
                    textBox15.Text = r.ToString();

                    //------------------------ تعديل حساب البنك
                    sqlCommand1.CommandText = "update Bank set  Rased='" + textBox15.Text + "',  DateLast ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  where NumHesab='" + comboBox1.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //------------------------  إضافة فى كشف حساب البنك
                    sqlCommand1.CommandText = "insert into BankHesab (NumHesab,BankName,Department,Date,Move,Remaining1,Maden,Daen,Remaining,NumSkeek,Name,ValueSheek,dateDay,DateElestehkak,Note)values ('" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox13.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox14.Text + "','" + textBox10.Text + "','" + 0 + "','" + textBox15.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + textBox12.Text + "')";
                    sqlCommand1.ExecuteNonQuery();


                    sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //---  تعديل حساب العميل

                    double n1 = Convert.ToDouble(textBox18.Text); // رصيد للعميل
                    double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                    double r1 = n1 + d1;
                    textBox21.Text = r1.ToString();

                    double n11 = Convert.ToDouble(textBox21.Text);  // اجمالى ماله بعد اضافة القيمة الوارده
                    double d11 = Convert.ToDouble(textBox17.Text); // رصيد لنا
                    if (n11 > d11) //--- له اكبر = دائن
                    {
                        double wwa = n11 - d11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "دائن";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (d11 > n11) // لنا اكبر = مدين
                    {
                        double wwa = d11 - n11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "مدين";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else //-------- خالص
                    {
                        textBox23.Text = "خالص";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                }
                else //---------  صرف للخزينة
                {
                    //---- حساب اجمالى الصندوق
                    double q1S = Convert.ToDouble(textBox16.Text);
                    double l1S = Convert.ToDouble(textBox10.Text);
                    double w1S = q1S + l1S;
                    textBox25.Text = w1S.ToString();

                    sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + textBox25.Text + "' , Date ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //----------  إضافة حركة الصندوق

                    try
                    {
                        sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + textMoveBoxID.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + comboBox2.Text + "','" + textBillingDataNumBill.Text + "','" + textBox16.Text + "','" + 0 + "','" + textBox10.Text + "','" + textBox25.Text + "','" + textBox12.Text + "')";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    catch
                    {

                    }



                    sqlCommand1.CommandText = "update SheekSave set State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //---  تعديل حساب العميل

                    double n1 = Convert.ToDouble(textBox18.Text); // رصيد للعميل
                    double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                    double r1 = n1 + d1;
                    textBox21.Text = r1.ToString();

                    double n11 = Convert.ToDouble(textBox21.Text);  // اجمالى ماله بعد اضافة القيمة الوارده
                    double d11 = Convert.ToDouble(textBox17.Text); // رصيد لنا
                    if (n11 > d11) //--- له اكبر = دائن
                    {
                        double wwa = n11 - d11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "دائن";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (d11 > n11) // لنا اكبر = مدين
                    {
                        double wwa = d11 - n11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "مدين";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else //-------- خالص
                    {
                        textBox23.Text = "خالص";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }

                }
            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                double n = Convert.ToDouble(textBox10.Text);
                double d = Convert.ToDouble(textBox14.Text);
                double r = n + d;
                textBox15.Text = r.ToString();

                //------------------------
                sqlCommand1.CommandText = "update Bank set  Rased='" + textBox15.Text + "',  DateLast ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  where NumHesab='" + comboBox1.Text + "'";
                sqlCommand1.ExecuteNonQuery();

                //------------------------
                sqlCommand1.CommandText = "insert into BankHesab (NumHesab,BankName,Department,Date,Move,Remaining1,Maden,Daen,Remaining,NumSkeek,Name,ValueSheek,dateDay,DateElestehkak,Note)values ('" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox13.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox14.Text + "','" + textBox10.Text + "','" + 0 + "','" + textBox15.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + textBox12.Text + "')";
                sqlCommand1.ExecuteNonQuery();



                sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                sqlCommand1.ExecuteNonQuery();

                //---  تعديل حساب العميل

                double n1 = Convert.ToDouble(textBox18.Text); // رصيد للعميل
                double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                double r1 = n1 + d1;
                textBox21.Text = r1.ToString();

                double n11 = Convert.ToDouble(textBox21.Text);  // اجمالى ماله بعد اضافة القيمة الوارده
                double d11 = Convert.ToDouble(textBox17.Text); // رصيد لنا
                if (n11 > d11) //--- له اكبر = دائن
                {
                    double wwa = n11 - d11;
                    textBox22.Text = wwa.ToString();

                    textBox23.Text = "دائن";

                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }
                else if (d11 > n11) // لنا اكبر = مدين
                {
                    double wwa = d11 - n11;
                    textBox22.Text = wwa.ToString();

                    textBox23.Text = "مدين";

                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }
                else //-------- خالص
                {
                    textBox23.Text = "خالص";

                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                }
            }
            else
            {
                //---- حساب اجمالى الصندوق
                double q1S = Convert.ToDouble(textBox16.Text);
                double l1S = Convert.ToDouble(textBox10.Text);
                double w1S = q1S + l1S;
                textBox25.Text = w1S.ToString();

                sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + textBox25.Text + "' , Date ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                sqlCommand1.ExecuteNonQuery();

                //----------  إضافة حركة الصندوق

                try
                {
                    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + textMoveBoxID.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + comboBox2.Text + "','" + textBillingDataNumBill.Text + "','" + textBox16.Text + "','" + 0 + "','" + textBox10.Text + "','" + textBox25.Text + "','" + textBox12.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {

                }


                sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                sqlCommand1.ExecuteNonQuery();

                //---  تعديل حساب العميل

                double n1 = Convert.ToDouble(textBox18.Text); // رصيد للعميل
                double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                double r1 = n1 + d1;
                textBox21.Text = r1.ToString();

                double n11 = Convert.ToDouble(textBox21.Text);  // اجمالى ماله بعد اضافة القيمة الوارده
                double d11 = Convert.ToDouble(textBox17.Text); // رصيد لنا
                if (n11 > d11) //--- له اكبر = دائن
                {
                    double wwa = n11 - d11;
                    textBox22.Text = wwa.ToString();

                    textBox23.Text = "دائن";

                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }
                else if (d11 > n11) // لنا اكبر = مدين
                {
                    double wwa = d11 - n11;
                    textBox22.Text = wwa.ToString();

                    textBox23.Text = "مدين";

                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }
                else //-------- خالص
                {
                    textBox23.Text = "خالص";

                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //----- شيك صادر
            //---  كمبياله صادرة
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال العملية ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (radioButton1.Checked == true) //----  صرف من البنك
                {
                    double n = Convert.ToDouble(textBox10.Text); //----- قيمة الكمبياله
                    double d = Convert.ToDouble(textBox14.Text);//-- رصيد البنك
                    double r = d - n;
                    textBox15.Text = r.ToString();

                    //------------------------ تعديل رصيد البنك
                    sqlCommand1.CommandText = "update Bank set  Rased='" + textBox15.Text + "',  DateLast ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "'  where NumHesab='" + comboBox1.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //------------------------ اضافة فى كشف حساب البنك
                    sqlCommand1.CommandText = "insert into BankHesab (NumHesab,BankName,Department,Date,Move,Remaining1,Maden,Daen,Remaining,NumSkeek,Name,ValueSheek,dateDay,DateElestehkak,Note)values ('" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox13.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox14.Text + "','" + textBox10.Text + "','" + 0 + "','" + textBox15.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + textBox10.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + textBox12.Text + "')";
                    sqlCommand1.ExecuteNonQuery();

                    //-----------------------  حذف الشيك من المحفوظات
                    //sqlCommand1.CommandText = "delete from SheekSave where NumSkeek = '" + textBox9.Text + "'   ";
                    //sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //---  تعديل حساب العميل

                    double n1 = Convert.ToDouble(textBox17.Text); // رصيد للعميل
                    double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                    double r1 = n1 + d1;
                    textBox21.Text = r1.ToString();

                    double n11 = Convert.ToDouble(textBox21.Text); // اجمالى مالنا بعد اضافة القيمة الصادرة
                    double d11 = Convert.ToDouble(textBox18.Text); // رصيد له
                    if (n11 < d11) //--- له اكبر = دائن
                    {
                        double wwa = d11 - n11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "دائن";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (d11 < n11) // لنا اكبر = مدين
                    {
                        double wwa = n11 - d11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "مدين";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else //-------- خالص
                    {
                        textBox23.Text = "خالص";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                }
                else //---- صرف من الخزينة
                {
                    //---- حساب اجمالى الصندوق
                    double q1S = Convert.ToDouble(textBox16.Text); //-  رصيد الخزينة
                    double l1S = Convert.ToDouble(textBox10.Text); //-- قيمة الكمبياله
                    double w1S = q1S - l1S;
                    textBox25.Text = w1S.ToString();

                    sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + textBox25.Text + "' , Date ='" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //----------  إضافة حركة الصندوق

                    try
                    {
                        sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + textMoveBoxID.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + comboBox2.Text + "','" + textBillingDataNumBill.Text + "','" + textBox16.Text + "','" + textBox10.Text + "','" + 0 + "','" + textBox25.Text + "','" + textBox12.Text + "')";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    catch
                    {

                    }



                    //-----------------------  حذف الشيك من المحفوظات
                    //sqlCommand1.CommandText = "delete from SheekSave where NumSkeek = '" + textBox9.Text + "'   ";
                    //sqlCommand1.ExecuteNonQuery();

                    sqlCommand1.CommandText = "update SheekSave set  State='" + textBox29.Text + "' where NumSkeek='" + textBox9.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    //---  تعديل حساب العميل

                    double n1 = Convert.ToDouble(textBox17.Text); // رصيد للعميل
                    double d1 = Convert.ToDouble(textBox10.Text); // القيمة
                    double r1 = n1 + d1;
                    textBox21.Text = r1.ToString();

                    double n11 = Convert.ToDouble(textBox21.Text); // اجمالى مالنا بعد اضافة القيمة الصادرة
                    double d11 = Convert.ToDouble(textBox18.Text); // رصيد له
                    if (n11 < d11) //--- له اكبر = دائن
                    {
                        double wwa = d11 - n11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "دائن";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + textBox22.Text + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else if (d11 < n11) // لنا اكبر = مدين
                    {
                        double wwa = n11 - d11;
                        textBox22.Text = wwa.ToString();

                        textBox23.Text = "مدين";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + textBox22.Text + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    else //-------- خالص
                    {
                        textBox23.Text = "خالص";

                        sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox19.Text + "','" + comboBox2.Text + "','" + textBox24.Text + "','" + dateTimePicker3.Value.ToString("MM/dd/yyyy") + "','" + textBox6.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox10.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + 0 + "')";
                        sqlCommand1.ExecuteNonQuery();

                        sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + 0 + "',Creditor ='" + 0 + "'  WHERE Name = '" + comboBox2.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "select * from Bank where NumHesab ='" + comboBox1.Text + "' ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    // textBox1.Text = red["UserName"].ToString();
                    textBox2.Text = red["Name"].ToString();
                    textBox1.Text = red["Alomala"].ToString();
                    textBox4.Text = red["PriceSarf"].ToString();
                    textBox3.Text = red["BankName"].ToString();
                    textBox13.Text = red["Department"].ToString();
                    textBox5.Text = red["Type"].ToString();
                    textBox14.Text = red["Rased"].ToString();


                }
                red.Close();
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comboBox2.Text + "'  ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {

                    textBox17.Text = red["PreviousBalance"].ToString();
                    textBox18.Text = red["Creditor"].ToString();
                    textBox19.Text = red["ID"].ToString();
                    textBox24.Text = red["Company"].ToString();

                }
                red.Close();

            }
            catch
            {
                MessageBox.Show("يوجد خطأ فى البحث", "Error");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox30.Text = textBox30.Text + " " + dateTimePicker3.Text;

            //-----------------------  حذف الشيك من المحفوظات
            //sqlCommand1.CommandText = "delete from SheekSave where NumSkeek = '" + textBox9.Text + "'   ";
            //sqlCommand1.ExecuteNonQuery();

            sqlCommand1.CommandText = "update SheekSave set  State='" + textBox30.Text + "' where NumSkeek='" + textBox9.Text + "'";
            sqlCommand1.ExecuteNonQuery();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
