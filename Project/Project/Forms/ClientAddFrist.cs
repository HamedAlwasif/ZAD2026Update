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
    public partial class ClientAddFrist : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        //----------------- ConnectionStrings for web ------------------

        //static string constringweb = ConfigurationManager.ConnectionStrings["ConnectionStringDataforweb"].ConnectionString;
        //SqlConnection sqlConnectionweb = new SqlConnection(constringweb);
        //-------------------------------------------------------------

        //int i = 0;
        private SqlDataReader raaad;
        private SqlDataReader reed;
        private SqlDataReader red;

        string FristGardID = "";
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;


        public ClientAddFrist()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
        }

        private void butDaaen_Click(object sender, EventArgs e)
        {
            //---------- تعديل القيمة بالسالب للدائن --------
            double a = Convert.ToDouble(textBox6.Text);
            double PreviousBalance = a * -1;
            //-------------------------------------------------


            sqlCommand1.CommandText = "select * from FristGard where Name ='" + textBox1.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move ='" + FormName + "'";
            raaad = sqlCommand1.ExecuteReader();
            while (raaad.Read())
            {
                FristGardID = raaad["ID"].ToString();


            }
            raaad.Close();


            try
            {
                sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + FristGardID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + textBox1.Text + "','" + 0 + "','" + textBox5.Text + "','" + textBox6.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update FristGard set    Madenon='" + textBox5.Text + "',  Daenon ='" + textBox6.Text + "'  where ID='" + FristGardID + "' ";
                sqlCommand1.ExecuteNonQuery();
            }

            try
            {
                //sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor)values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                //sqlCommand1.ExecuteNonQuery();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteImage = ms.ToArray();


                sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed)";
                sqlCommand1.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text;
                sqlCommand1.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
                sqlCommand1.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = textBox2.Text;
                sqlCommand1.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = textBox3.Text;
                sqlCommand1.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox4.Text;
                sqlCommand1.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = PreviousBalance;
                sqlCommand1.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = "";
                sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                sqlCommand1.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
                sqlCommand1.ExecuteNonQuery();
                sqlCommand1.Parameters.Clear();


            }
            catch
            { }

            //----------------- ايجاد كود العميل 
            sqlCommand1.CommandText = "select * from Clients where Name ='" + textBox1.Text + "' ";
            raaad = sqlCommand1.ExecuteReader();
            while (raaad.Read())
            {
                textBox14.Text = raaad["ID"].ToString();


            }
            raaad.Close();
            //------------------------------------------


            try
            {
                string Move = "رصيد بداية المدة";
                sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox14.Text + "','" + textBox1.Text + "','" + combGroups.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Move + "','" + PreviousBalance + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox6.Text + "','" + PreviousBalance + "','" + 0 + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show(" pleas correct the data");
            }

            //الاضافة على الويب
            //try
            //{
            //    System.IO.MemoryStream ms2 = new System.IO.MemoryStream();
            //    pictureBox1.Image.Save(ms2, pictureBox1.Image.RawFormat);
            //    byte[] byteImage2 = ms2.ToArray();


            //    sqlCommand2.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed)";
            //    sqlCommand2.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text;
            //    sqlCommand2.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
            //    sqlCommand2.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = textBox2.Text;
            //    sqlCommand2.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = textBox3.Text;
            //    sqlCommand2.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox4.Text;
            //    sqlCommand2.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = "";
            //    sqlCommand2.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = textBox6.Text;
            //    sqlCommand2.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage2;
            //    sqlCommand2.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
            //    sqlCommand2.ExecuteNonQuery();
            //    sqlCommand2.Parameters.Clear();

            //    MessageBox.Show("          تمت الاضافة بنجاح على الويب        ", "  الاضافة على الويب   ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    //MessageBox.Show("          تمت الاضافة بنجاح على الويب        ", "  الاضافة على الويب   ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            //-------------------------
            butMadeen.Enabled = false;

        }

        private void butMadeen_Click(object sender, EventArgs e)
        {
            //----------------------
            sqlCommand1.CommandText = "select * from FristGard where Name ='" + textBox1.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move ='" + FormName + "'";
            raaad = sqlCommand1.ExecuteReader();
            while (raaad.Read())
            {
                FristGardID = raaad["ID"].ToString();


            }
            raaad.Close();


            try
            {
                sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + FristGardID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + textBox1.Text + "','" + 0 + "','" + textBox5.Text + "','" + textBox6.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update FristGard set    Madenon='" + textBox5.Text + "',  Daenon ='" + textBox6.Text + "'  where ID='" + FristGardID + "' ";
                sqlCommand1.ExecuteNonQuery();
            }

            try
            {
                //sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor)values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                //sqlCommand1.ExecuteNonQuery();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteImage = ms.ToArray();


                sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed)";
                sqlCommand1.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text;
                sqlCommand1.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
                sqlCommand1.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = textBox2.Text;
                sqlCommand1.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = textBox3.Text;
                sqlCommand1.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox4.Text;
                sqlCommand1.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = textBox5.Text;
                sqlCommand1.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = "0";
                sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                sqlCommand1.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
                sqlCommand1.ExecuteNonQuery();
                sqlCommand1.Parameters.Clear();

                //الاضافة على الويب
                //try
                //{
                //    System.IO.MemoryStream ms3 = new System.IO.MemoryStream();
                //    pictureBox1.Image.Save(ms3, pictureBox1.Image.RawFormat);
                //    byte[] byteImage3 = ms3.ToArray();


                //    sqlCommand2.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed)";
                //    sqlCommand2.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text;
                //    sqlCommand2.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
                //    sqlCommand2.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = textBox2.Text;
                //    sqlCommand2.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = textBox3.Text;
                //    sqlCommand2.Parameters.Add("@Address", SqlDbType.VarChar).Value = textBox4.Text;
                //    sqlCommand2.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = textBox5.Text;
                //    sqlCommand2.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = "0";
                //    sqlCommand2.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                //    sqlCommand2.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
                //    sqlCommand2.ExecuteNonQuery();
                //    sqlCommand2.Parameters.Clear();


                //    MessageBox.Show("          تمت الاضافة بنجاح على الويب        ", "  الاضافة على الويب   ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //catch
                //{
                //    //MessageBox.Show("          تمت الاضافة بنجاح على الويب        ", "  الاضافة على الويب   ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            catch
            { }

            //----------------- ايجاد كود العميل 
            sqlCommand1.CommandText = "select * from Clients where Name ='" + textBox1.Text + "' ";
            raaad = sqlCommand1.ExecuteReader();
            while (raaad.Read())
            {
                textBox14.Text = raaad["ID"].ToString();


            }
            raaad.Close();
            //------------------------------------------

            try
            {
                string Move = "رصيد بداية المدة";
                sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + textBox14.Text + "','" + textBox1.Text + "','" + combGroups.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Move + "','" + textBox5.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textBox5.Text + "','" + 0 + "','" + textBox5.Text + "','" + 0 + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show(" pleas correct the data");
            }
            butDaaen.Enabled = false;
        }

        private void ClientAddFrist_Load(object sender, EventArgs e)
        {
            

            //----------------- ايجاد العملاء --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Name from Clients", sqlConnection1);
                Da1.Fill(Dt1);
                comClient.DataSource = Dt1;
                comClient.DisplayMember = "Name";
            }
            catch
            {

            }

            //----------------- ايجاد المجموعات --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select GroupName from Groups", sqlConnection1);
                Da1.Fill(Dt1);
                combGroups.DataSource = Dt1;
                combGroups.DisplayMember = "GroupName";
            }
            catch
            {

            }



            

            //------------------------------

            // إيجاد رقم الفاتورة
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
            //------------------------------



            // إيجاد رقم حساب اول الجرد
            try
            {
                sqlCommand1.CommandText = "select * From FristGard  Where ID =(select max(ID) from FristGard) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["ID"].ToString());
                    double aa = s + 1;
                    FristGardID = aa.ToString();

                }
                red.Close();

                if (FristGardID == "0")
                {
                    FristGardID = "1";
                }
                else
                { }
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            //================================




            //-------------------------
            if (FormName == "إضافة عميل")
            {
                label6.Visible = false;
                label7.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                //button1.Visible = true;

                this.Text = "إضافة عميل";

            }
            else if (FormName == "مدين أول المدة")
            {
                label6.Visible = true;
                label7.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = false;
                butMadeen.Visible = true;

                this.Text = "إضافة عميل مدين أول المدة";
                //--------------------------

            }
            else if (FormName == "دائن أول المدة")
            {
                label6.Visible = false;
                label7.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = true;
                butDaaen.Visible = true;

                this.Text = "إضافة عميل دائن أول المدة";
            }
            else if (FormName == "تصفية حساب")
            {
                this.Text = "تصفية حساب عميل";
                label6.Visible = true;
                label7.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                //button5.Visible = true;
                button2.Visible = false;
                label8.Visible = true;
                textBillingDataNumBill.Visible = true;
                label15.Visible = true;
                textBox11.Visible = true;
                //-------------------------
               
                //label9.Visible = true;
                //label10.Visible = true;
                label11.Visible = true;
                //textBox12.Visible = true;
                //textBox13.Visible = true;
                textBox14.Visible = true;
                comClient.Visible = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //---------- إضافة رقم حساب جرد اولى جديد
            int iii = int.Parse(FristGardID);
            int jj = iii + 1;
            FristGardID = jj.ToString();
            //--------------------------

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox1.Focus();
            butMadeen.Enabled = true;
            butDaaen.Enabled = true;
            //button1.Enabled = true;
        }

        private void search_Click(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = "select * from Clients where Name ='" + comClient.Text + "'   ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textBox14.Text = reed["ID"].ToString();
                textBox1.Text = reed["Name"].ToString();
                combGroups.Text = reed["Company"].ToString();
                textBox2.Text = reed["TelHome"].ToString();
                textBox3.Text = reed["TelMobil"].ToString();
                textBox4.Text = reed["Address"].ToString();
                textBox5.Text = reed["PreviousBalance"].ToString();
                textBox6.Text = reed["Creditor"].ToString();

            }

            reed.Close();

            //-------------------------------------
            //textBox13.Text = textBox5.Text;
            //textBox12.Text = textBox6.Text;

            //---------------- 
            //------------------
            sqlCommand1.CommandText = "select * from FristGard where Name ='" + comClient.Text + "'  and Move ='" + FormName+ "'";
            raaad = sqlCommand1.ExecuteReader();
            while (raaad.Read())
            {
                FristGardID = raaad["ID"].ToString();

            }
            raaad.Close();
        }
    }
}
