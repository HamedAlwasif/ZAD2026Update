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
    public partial class ClientAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        //----------------- ConnectionStrings for web ------------------

        //static string constringweb = ConfigurationManager.ConnectionStrings["ConnectionStringDataforweb"].ConnectionString;
        //SqlConnection sqlConnectionweb = new SqlConnection(constringweb);
        //-------------------------------------------------------------
        private SqlDataReader reed;

        private SqlDataReader raaad;


         private SqlDataReader red;

        string FristGardID = "";
        string FormName = TransferData.FormName;



        public ClientAdd()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;

            //-------------------- فتح الاتصال بالويب -----------------
            //try
            //{
            //    sqlConnectionweb.Open();
            //    sqlCommand2.Connection = sqlConnectionweb;
            //}
            //catch
            //{ }


            //******************************************
            GetClints();
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
        private void GetAllClintes()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Clients ", sqlConnection1);
            da11.Fill(dt11);
            this.dataGridSearchClint.DataSource = dt11;

        }
        private void keys(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public void CleanData()
        {
            txtName.Text = "";


        }
            public void GetClints()
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

            //----------------- ايجاد العملاء --------------------
            try
            {
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Name from Clients", sqlConnection1);
                Da.Fill(Dt);


                listBox1.DataSource = Dt;
                listBox1.DisplayMember = "Name";
            }
            catch
            {

            }
        }
        private void butSearch_Click(object sender, EventArgs e)
        {
            txtID_Clint.Text = "";
            butUpdate.Enabled = false;
            butDelete.Enabled = false;
            panel1.Visible = false;


            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comClient.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    txtID_Clint.Text = reed["ID"].ToString();
                    txtName.Text = reed["Name"].ToString();
                    combGroups.Text = reed["Company"].ToString();
                    txeTell.Text = reed["TelHome"].ToString();
                    txtMobil.Text = reed["TelMobil"].ToString();
                    txtAdress.Text = reed["Address"].ToString();
                    combStateRaseed.Text = reed["StateRaseed"].ToString();
                    textLimitCredit.Text = reed["LimitCredit"].ToString();
                    //textDaen.Text = reed["Creditor"].ToString();

                }

                reed.Close();
            }
            catch
            {

            }

            //-----اظهار زر التعديل 
            if (txtID_Clint.Text == "")
            {

            }
            else
            {
                butUpdate.Enabled = true;
                butDelete.Enabled = true;


            }
        }

        private void butPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog og1 = new OpenFileDialog();

            var _with1 = og1;
            og1.Title = "(Select Image) (تحديد صورة)";
            og1.Filter = "JPEG,BMP,PNG  (تحديد صورة) (Select Image) |*.jpg;*.jpeg;*.bmp;*.png";

            if (og1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(og1.FileName);
            }
            else
            {
                MessageBox.Show("عفواً ألغي الأمر بناء على طلبك");
                this.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("    يجب كتابة اسم العميل    ", "  خطأ   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                
                //try
                //{
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();


                    sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed,LimitCredit) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed,@LimitCredit)";
                    sqlCommand1.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
                    sqlCommand1.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
                    sqlCommand1.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = txeTell.Text;
                    sqlCommand1.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = txtMobil.Text;
                    sqlCommand1.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAdress.Text;
                    sqlCommand1.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = "0";
                    sqlCommand1.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = "0";
                    sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                    sqlCommand1.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
                    sqlCommand1.Parameters.Add("@LimitCredit", SqlDbType.VarChar).Value = textLimitCredit.Text;
                    sqlCommand1.ExecuteNonQuery();
                    sqlCommand1.Parameters.Clear();

                    MessageBox.Show("          تمت الاضافة بنجاح        ", "  الاضافة   ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //------ تفريغ البيانات  ---------

                    CleanData();
                //}
                //catch
                //{ }

                //-------------------

                GetClints();
                EmptyData();
            }
        }

        public void EmptyData()
        {
            GetClints();
            //----------------------

            txtID_Clint.Text = "";
            txtName.Text = "";
            txtMobil.Text = "";
            txeTell.Text = "";
            txtAdress.Text = "";

            txtName.Focus();
            butUpdate.Enabled = false;
            butDelete.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            EmptyData();

            panel1.Visible = true;

        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد تعديل البيانات ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //MessageBox.Show("موافق", "موافق");

                try
                {

                    sqlCommand1.CommandText = "update Clients set  Name ='" + txtName.Text + "',  Company ='" + combGroups.Text + "',  TelHome ='" + txeTell.Text + "',TelMobil ='" + txtMobil.Text + "', Address ='" + txtAdress.Text + "' , StateRaseed ='" + combStateRaseed.Text + "', LimitCredit ='" + textLimitCredit.Text + "'  where ID='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update Billing set  ClientName ='" + txtName.Text + "'  where ClinentID ='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update Billing1 set  ClientName ='" + txtName.Text + "'  where ClinentID ='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update BillingData set  Name='" + txtName.Text + "'  where ClientID ='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update BillingData1 set  Name='" + txtName.Text + "'  where ClientID ='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update BillingInvalid set  ClinetName ='" + txtName.Text + "'  where ClinetID ='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update Final set  Name ='" + txtName.Text + "'  where ID ='" + txtID_Clint.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    //**********************
                    sqlCommand1.CommandText = "update SheekSave set  Name ='" + txtName.Text + "'  where Name ='" + comClient.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {

                }

                //----------------
                GetClints();
                //---------------
            }
            else
            {

            }
            }

        private void butDelete_Click(object sender, EventArgs e)
        {
            string numBiiil = "";
           

             try  // التاكد ان العميل له حسابات سابقة ام لا
                {
                   
                    sqlCommand1.CommandText = "select NumBill from BillingData where Name ='" + comClient.Text + "'   ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {

                        numBiiil = reed["NumBill"].ToString();
                        


                    }

                    reed.Close();
                }
                catch
                {

                }

            if (numBiiil == "")
            {
                DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد حذف العميل ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {


                    sqlCommand1.CommandText = "delete from Clients where ID = '" + txtID_Clint.Text + "'   ";
                    sqlCommand1.ExecuteNonQuery();


                    MessageBox.Show("  تم الحذف بنجاح  ", "   حذف   ");

                }
                else if (dialogResult == DialogResult.No)
                {


                }
                //---------------
                EmptyData();
                //------------------

            }
            else
            {
                MessageBox.Show("       لم يتم الحذف : العميل له معاملات سابقة ولا يمكن حذفه       ", "   ملحوظة   ");
            }


           
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            int index = comClient.FindString(txtName.Text);
            comClient.SelectedIndex = index;

            ////----------------- ايجاد العملاء --------------------
            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Clients where Name Like'%" + txtName.Text + "%' ", sqlConnection1);
                Da2.Fill(Dt2);


                listBox1.DataSource = Dt2;
                listBox1.DisplayMember = "Name";
            }
            catch
            {

            }
        }

        private void ClientAdd_Load(object sender, EventArgs e)
        {
            GetAllClintes();
            GetClints();

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

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";
                FormName = "إضافة عميل";
                textMaden.Enabled = false;
                textDaen.Enabled = false;

                butAddClient.Visible = true;
                butDaaen.Visible = false;
                butMadeen.Visible = false;



            }
            else if (radbutMaden.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "مدين أول المدة";
                textMaden.Enabled = true;
                textDaen.Enabled = false;

                butAddClient.Visible = false;
                butDaaen.Visible = false;
                butMadeen.Visible = true;
            }
            else if (radbutDaen.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "دائن أول المدة";
                textMaden.Enabled = false;
                textDaen.Enabled = true;

                butAddClient.Visible = false;
                butDaaen.Visible = true;
                butMadeen.Visible = false;
            }
            else
            {

            }
        }

        private void radbutMaden_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "إضافة عميل";
                textMaden.Enabled = false;
                textDaen.Enabled = false;

                butAddClient.Visible = true;
                butAddClient.Enabled = true;
                butDaaen.Visible = false;
                butMadeen.Visible = false;



            }
            else if (radbutMaden.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "مدين أول المدة";
                textMaden.Enabled = true;
                textDaen.Enabled = false;

                butAddClient.Visible = false;
                butDaaen.Visible = false;
                butMadeen.Visible = true;
                butMadeen.Enabled = true;

                textMaden.Focus();
            }
            else if (radbutDaen.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "دائن أول المدة";
                textMaden.Enabled = false;
                textDaen.Enabled = true;

                butAddClient.Visible = false;
                butDaaen.Visible = true;
                butDaaen.Enabled = true;
                butMadeen.Visible = false;
                textDaen.Focus();
            }
            else
            {

            }
        }

        private void radbutDaen_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "إضافة عميل";
                textMaden.Enabled = false;
                textDaen.Enabled = false;

                butAddClient.Visible = true;
                butDaaen.Visible = false;
                butMadeen.Visible = false;




            }
            else if (radbutMaden.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "مدين أول المدة";
                textMaden.Enabled = true;
                textDaen.Enabled = false;

                butAddClient.Visible = false;
                butDaaen.Visible = false;
                butMadeen.Visible = true;
                textMaden.Focus();
            }
            else if (radbutDaen.Checked == true)
            {
                textDaen.Text = "0";
                textMaden.Text = "0";

                FormName = "دائن أول المدة";
                textMaden.Enabled = false;
                textDaen.Enabled = true;

                butAddClient.Visible = false;
                butDaaen.Visible = true;
                butMadeen.Visible = false;
                textDaen.Focus();
            }
            else
            {

            }
        }

        private void butMadeen_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("    يجب كتابة اسم العميل    ", "  خطأ   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                sqlCommand1.CommandText = "select * from FristGard where Name ='" + txtName.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move ='" + FormName + "'";
                raaad = sqlCommand1.ExecuteReader();
                while (raaad.Read())
                {
                    FristGardID = raaad["ID"].ToString();


                }
                raaad.Close();


                try
                {
                    sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + FristGardID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtName.Text + "','" + 0 + "','" + textMaden.Text + "','" + textDaen.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update FristGard set    Madenon='" + textMaden.Text + "',  Daenon ='" + textDaen.Text + "'  where ID='" + FristGardID + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

                try
                {
                    //sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor)values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + txeTell.Text + "','" + txtMobil.Text + "','" + txtAdress.Text + "','" + textMaden.Text + "','" + textDaen.Text + "')";
                    //sqlCommand1.ExecuteNonQuery();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();


                    sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed)";
                    sqlCommand1.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
                    sqlCommand1.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
                    sqlCommand1.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = txeTell.Text;
                    sqlCommand1.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = txtMobil.Text;
                    sqlCommand1.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAdress.Text;
                    sqlCommand1.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = textMaden.Text;
                    sqlCommand1.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = "0";
                    sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                    sqlCommand1.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
                    sqlCommand1.Parameters.Add("@LimitCredit", SqlDbType.VarChar).Value = textLimitCredit.Text;
 
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
                    //    sqlCommand2.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = txeTell.Text;
                    //    sqlCommand2.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = txtMobil.Text;
                    //    sqlCommand2.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAdress.Text;
                    //    sqlCommand2.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = textMaden.Text;
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

                    MessageBox.Show("          تمت الاضافة بنجاح        ", "  الاضافة   ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch
                { }

                //----------------- ايجاد كود العميل 
                sqlCommand1.CommandText = "select * from Clients where Name ='" + txtName.Text + "' ";
                raaad = sqlCommand1.ExecuteReader();
                while (raaad.Read())
                {
                    txtID_Clint.Text = raaad["ID"].ToString();


                }
                raaad.Close();
                //------------------------------------------

                try
                {
                    string Move = "رصيد بداية المدة";
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + txtID_Clint.Text + "','" + txtName.Text + "','" + combGroups.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Move + "','" + textMaden.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textMaden.Text + "','" + 0 + "','" + textMaden.Text + "','" + 0 + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();

                }
                catch
                 {
               // MessageBox.Show(" pleas correct the data");
                 }
                //   butDaaen.Enabled = false;
                double a = Convert.ToDouble(textBillingDataNumBill.Text);
              
                double b = a + 1;
                textBillingDataNumBill.Text = b.ToString();


                //------ تفريغ البيانات  ---------

                CleanData();

                GetClints();
                EmptyData();
            }
        }

        private void butDaaen_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("    يجب كتابة اسم العميل    ", "  خطأ   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                //---------- تعديل القيمة بالسالب للدائن --------
                double a = Convert.ToDouble(textDaen.Text);
                double PreviousBalance = a * -1;
                //-------------------------------------------------


                sqlCommand1.CommandText = "select * from FristGard where Name ='" + txtName.Text + "' and Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and Move ='" + FormName + "'";
                raaad = sqlCommand1.ExecuteReader();
                while (raaad.Read())
                {
                    FristGardID = raaad["ID"].ToString();


                }
                raaad.Close();


                try
                {
                    sqlCommand1.CommandText = "insert into FristGard (ID,Date,Move,Name,GardFrist,Madenon,Daenon,Box,Building,Electronic,BasisOFFICE,Bank,adv)values ('" + FristGardID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtName.Text + "','" + 0 + "','" + textMaden.Text + "','" + textDaen.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update FristGard set    Madenon='" + textMaden.Text + "',  Daenon ='" + textDaen.Text + "'  where ID='" + FristGardID + "' ";
                    sqlCommand1.ExecuteNonQuery();
                }

                try
                {
                    //sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor)values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + txeTell.Text + "','" + txtMobil.Text + "','" + txtAdress.Text + "','" + textMaden.Text + "','" + textDaen.Text + "')";
                    //sqlCommand1.ExecuteNonQuery();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();


                    sqlCommand1.CommandText = "insert into Clients (Name,Company,TelHome,TelMobil,Address,PreviousBalance,Creditor,Image,StateRaseed) values (@Name,@Company,@TelHome,@TelMobil,@Address,@PreviousBalance,@Creditor,@Image,@StateRaseed)";
                    sqlCommand1.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
                    sqlCommand1.Parameters.Add("@Company", SqlDbType.VarChar).Value = combGroups.Text;
                    sqlCommand1.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = txeTell.Text;
                    sqlCommand1.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = txtMobil.Text;
                    sqlCommand1.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAdress.Text;
                    sqlCommand1.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = PreviousBalance;
                    sqlCommand1.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = "";
                    sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                    sqlCommand1.Parameters.Add("@StateRaseed", SqlDbType.VarChar).Value = "فعال";
                    sqlCommand1.Parameters.Add("@LimitCredit", SqlDbType.VarChar).Value = textLimitCredit.Text;

                    sqlCommand1.ExecuteNonQuery();
                    sqlCommand1.Parameters.Clear();

                    MessageBox.Show("          تمت الاضافة بنجاح        ", "  الاضافة   ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch
                { }

                //----------------- ايجاد كود العميل 
                sqlCommand1.CommandText = "select * from Clients where Name ='" + txtName.Text + "' ";
                raaad = sqlCommand1.ExecuteReader();
                while (raaad.Read())
                {
                    txtID_Clint.Text = raaad["ID"].ToString();


                }
                raaad.Close();
                //------------------------------------------


                try
                {
                    string Move = "رصيد بداية المدة";
                    sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,State,NumberCategory)values ('" + textBillingDataNumBill.Text + "','" + txtID_Clint.Text + "','" + txtName.Text + "','" + combGroups.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Move + "','" + PreviousBalance + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + textDaen.Text + "','" + PreviousBalance + "','" + 0 + "','" + 0 + "')";
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
                //    sqlCommand2.Parameters.Add("@TelHome", SqlDbType.VarChar).Value = txeTell.Text;
                //    sqlCommand2.Parameters.Add("@TelMobil", SqlDbType.VarChar).Value = txtMobil.Text;
                //    sqlCommand2.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAdress.Text;
                //    sqlCommand2.Parameters.Add("@PreviousBalance", SqlDbType.VarChar).Value = "";
                //    sqlCommand2.Parameters.Add("@Creditor", SqlDbType.VarChar).Value = textDaen.Text;
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
                //butMadeen.Enabled = false;
                double ac = Convert.ToDouble(textBillingDataNumBill.Text);
                double bc = ac + 1;
                textBillingDataNumBill.Text = bc.ToString();

                //------ تفريغ البيانات  ---------

                CleanData();

                GetClints();

                EmptyData();
            }
        }

        private void textMaden_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void textDaen_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void txeTell_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void txtMobil_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobil_KeyPress(object sender, KeyPressEventArgs e)
        {
            keys(sender, e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txtID_Clint.Text = "";
            butUpdate.Enabled = false;
            butDelete.Enabled = false;
            panel1.Visible = false;


            try
            {
                sqlCommand1.CommandText = "select * from Clients where ID ='" + txtID_ClintShearch.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    txtID_Clint.Text = reed["ID"].ToString();
                    txtName.Text = reed["Name"].ToString();
                    combGroups.Text = reed["Company"].ToString();
                    txeTell.Text = reed["TelHome"].ToString();
                    txtMobil.Text = reed["TelMobil"].ToString();
                    txtAdress.Text = reed["Address"].ToString();
                    combStateRaseed.Text = reed["StateRaseed"].ToString();
                    textLimitCredit.Text = reed["LimitCredit"].ToString();
                    //textDaen.Text = reed["Creditor"].ToString();

                }

                reed.Close();
            }
            catch
            {

            }

            //-----اظهار زر التعديل 
            if (txtID_Clint.Text == "")
            {

            }
            else
            {
                butUpdate.Enabled = true;
                butDelete.Enabled = true;


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                comClient.Enabled = true;
                butSearch.Enabled = true;
            }
            else
            {
                txtID_ClintShearch.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                
                txtID_ClintShearch.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                comClient.Enabled = false;
                butSearch.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void textSearchClint_TextChanged(object sender, EventArgs e)
        {
            //|| TelHome = '%" + textSearchClint.Text + "%' || TelMobil = '%" + textSearchClint.Text + "%' - Name like '%" + textSearchClint.Text + "%' ||
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter(@"Select ID,Name,Company,TelHome,TelMobil,Address,PreviousBalance From Clients where  Name like '%" + textSearchClint.Text + "%'", sqlConnection1);

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
                SqlDataAdapter da = new SqlDataAdapter(@"Select ID,Name,Company,TelHome,TelMobil,Address,PreviousBalance From Clients where TelMobil like '%" + textSearchClintMobil.Text + "%' ", sqlConnection1);

                da.Fill(dt);
                this.dataGridSearchClint.DataSource = dt;
            }
            catch
            { }
        }

        private void dataGridSearchClint_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comClient.Text = dataGridSearchClint.Rows[e.RowIndex].Cells[1].Value.ToString();
            panel10.Visible = false;
        }
    }
}
