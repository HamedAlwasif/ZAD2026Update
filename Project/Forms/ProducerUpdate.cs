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
    public partial class ProducerUpdate : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        //-------------------------------
        SqlDataAdapter Da2;
        DataTable Dt2 = new DataTable();
        //---------------------------------
        int i = 0;
        string SystemPro = "";

        string quntety = "";
        //---------------------------------
        private SqlDataReader reed;
        private SqlDataReader red;

        public ProducerUpdate()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void text_KeyPress(object sender, KeyPressEventArgs e) // - غلق كتابة الحروف وجعل الكتابة ارقام فقط
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }


        public class Class_Categorey
        {

            public string Barcode { get; set; }
            public string Storage { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string QuantityT { get; set; }
            public string Unity { get; set; }
            public string Faction { get; set; }
            public string Total { get; set; }


        }
        public class Class_GetAllCategry
        {

            public string Barcode { get; set; }
            public string Category { get; set; }
            public string Storage { get; set; }
            public string Total { get; set; }
            public string PriceMostahlek { get; set; }


        }
        public void SystemProgram()
        {
            //------------------- البحث نظام العمل جملة او قطاعى -------------

            string Kataey = "";
            string GomKataey = "";

            sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                Kataey = reed["Kataey"].ToString();
                GomKataey = reed["GomlaKataey"].ToString();
                

            }

            reed.Close();




            if (Kataey == "1") // قطاعى
            {
                label8.Visible = false;
                label10.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                comboBox2.Visible = false;
                label3.Visible = false;
                label13.Visible = false;
                label7.Visible = false;
                textBox5.Visible = false;

                SystemPro = "قطاعى";

                //----------------- ايجاد الفئات --------------------

                String type = "K";

                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Faction from CategoryFaction where Type ='" + type + "'", cn);
                Da1.Fill(Dt1);
                ComTypeCategorey.DataSource = Dt1;
                ComTypeCategorey.DisplayMember = "Faction";
            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";

                //----------------- ايجاد الفئات --------------------

                String type = "G";

                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Faction from CategoryFaction where Type ='" + type + "'", cn);
                Da1.Fill(Dt1);
                ComTypeCategorey.DataSource = Dt1;
                ComTypeCategorey.DisplayMember = "Faction";
            }
            // نهاية البحث نظام العمل جملة او قطاعى
        }
        private void butSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dataReader;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                DataSet dataset3 = new DataSet();

                dataAdapter.SelectCommand = new SqlCommand("select * from Category where Category like '" + comCategory.Text + "' and Storage ='" + comStorages.Text + "' ", cn);
                dataAdapter.Fill(dataset3);
                sqlCommand1.Connection = cn;
                sqlCommand1.CommandText = "select * from Category where Category like '" + comCategory.Text + "' and Storage ='" + comStorages.Text + "' ";
                dataReader = sqlCommand1.ExecuteReader();

                while (dataReader.Read())
                {
                    dataGridView1.DataSource = dataset3.Tables[0];
                    //checkedListBox1.Items.Add(dataReader["Name"]);
                    i = i + 1;

                }


                if (i == 0)

                    MessageBox.Show("This Name is not exist", "  Search");



                dataReader.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show(" هذا الصنف غير موجود   ", " ملحوظه ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // -----------------------------

            sqlCommand1.CommandText = "select * from Category where Category like'" + comCategory.Text + "' and Storage ='" + comStorages.Text + "' ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                textBox7.Text = red["ID"].ToString();
                textBox1.Text = red["Category"].ToString();
                textBox2.Text = red["Quantity"].ToString();
                quntety= red["Quantity"].ToString();   // تخزين الكمية القديمة
                textBox3.Text = red["QuantityT"].ToString();
                //dateTimePicker1.Text = red["التاريخ"].ToString();
                textBox4.Text = red["Unity"].ToString();
                comboBox2.Text = red["Faction"].ToString();
                textBox5.Text = red["Total"].ToString();
                textBox8.Text = red["Price"].ToString();
                textBox9.Text = red["Value"].ToString();
                textBox6.Text = red["Near"].ToString();
                textBox10.Text = red["Emwared"].ToString();
                comboBox3.Text = red["Available"].ToString();
                comCatGroup.Text = red["Group_Name"].ToString();




            }
            red.Close();
        }
        private void saveEvents(string Event)
        {

            //=========================== تسجيل الحركات  ========================== 
            try
            {

                //string Event = "تم فتح شاشة  " + TransferData.FormName;


                sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                sqlCommand1.ExecuteNonQuery();

                //MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");


                //---------------


            }
            catch
            {
                // MessageBox.Show("    فشلللللللللللللللللللللللللللللللل   ", "فشل ");
            }

            //========================== ========================== ========================== 
        }
        private void GetAllCategry()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Category ", cn);
            da11.Fill(dt11);
            this.dataGridSearchCategory.DataSource = dt11;

        }
        private void ProducerUpdate_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;

            //==========================  تسجيل الحركات  ========================== 

            saveEvents("تم فتح شاشة  " + TransferData.FormName);

            //========================== ========================== =================


            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Storage from Storage", cn);
                Da1.Fill(Dt1);
                comStorages.DataSource = Dt1;
                comStorages.DisplayMember = "Storage";
            }
            catch { }

            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Category from Category", cn);
                Da2.Fill(Dt2);
                comCategory.DataSource = Dt2;
                comCategory.DisplayMember = "Category";
            }
            catch { }

            Da2 = new SqlDataAdapter("select *From Category ", cn);
            Da2.Fill(Dt2);
            this.dataGridView1.DataSource = Dt2;



            //----------------- 1ايجاد مجموعة الصنف --------------------

            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Group_Name from CategoryGroup", cn);
                Da1.Fill(Dt1);
                comCatGroup.DataSource = Dt1;
                comCatGroup.DisplayMember = "Group_Name";
            }
            catch { }

            // البحث نظام العمل جملة او قطاعى
            SystemProgram();
            GetAllCategry();
            //sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
            //reed = sqlCommand1.ExecuteReader();
            //while (reed.Read())
            //{

            //    textBox77.Text = reed["Kataey"].ToString();
            //    textBox76.Text = reed["GomlaKataey"].ToString();

            //}

            //reed.Close();

            //if (textBox77.Text == "1") // قطاعى
            //{
            //    label8.Visible = false;
            //    label10.Visible = false;
            //    textBox3.Visible = false;
            //    textBox4.Visible = false;
            //    comboBox2.Visible = false;
            //    label3.Visible = false;
            //    label13.Visible = false;
            //    label7.Visible = false;
            //    textBox5.Visible = false;

            //}
            //else  // جمله
            //{


            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (SystemPro == "قطاعى") // قطاعى
            {


                textBox3.Text = "0";

            }
            else  // جمله
            {

            }
            //----------------------
            if (radioButton1.Checked == true)
            {
                try
                {
                    sqlCommand1.CommandText = "update Category set  Category='" + textBox1.Text + "',  Faction ='" + comboBox2.Text + "',  Available ='" + comboBox3.Text + "',  Near='" + textBox6.Text + "' where  ID ='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }

                //------------------------

                try
                {
                    sqlCommand1.CommandText = "update Billing set  Category='" + textBox1.Text + "' where  Category ='" + comCategory.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    //  MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    // MessageBox.Show("يوجد خطأ", "Error");
                }

                //------------------------

                try
                {
                    sqlCommand1.CommandText = "update Billing1 set  Category='" + textBox1.Text + "' where  Category ='" + comCategory.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    // MessageBox.Show("يوجد خطأ", "Error");
                }

                //------------------------

                try
                {
                    sqlCommand1.CommandText = "update BillingInvalid set  Catogory='" + textBox1.Text + "' where  Category ='" + comCategory.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    // MessageBox.Show("يوجد خطأ", "Error");
                }

                //------------------------

                try
                {
                    sqlCommand1.CommandText = "update CategoryPrice set Category='" + textBox1.Text + "' where  Category ='" + comCategory.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    // MessageBox.Show("يوجد خطأ", "Error");
                }

                //------------------------

                try
                {
                    sqlCommand1.CommandText = "update Transport set Category='" + textBox1.Text + "' where  Category ='" + comCategory.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    //  MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    // MessageBox.Show("يوجد خطأ", "Error");
                }
                //------------------------

                try
                {
                    sqlCommand1.CommandText = "update Profit set Category='" + textBox1.Text + "' where  Category ='" + comCategory.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }
                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");
            }
            else if (radioButton2.Checked == true)
            {
                double www1 = Convert.ToDouble(textBox2.Text);
                double yyy1 = Convert.ToDouble(textBox4.Text);
                double ss = www1 * yyy1;
                textBox5.Text = ss.ToString();

                double wqw1 = Convert.ToDouble(textBox3.Text);
                double yqy1 = Convert.ToDouble(textBox5.Text);
                double sqs = wqw1 + yqy1;
                textBox5.Text = sqs.ToString();

                // حساب القيمة
                double a1 = Convert.ToDouble(textBox8.Text);
                double b1 = Convert.ToDouble(textBox5.Text);
                double c = a1 * b1;
                textBox9.Text = c.ToString();

                try
                {
                    sqlCommand1.CommandText = "update Category set  Quantity ='" + textBox2.Text + "', QuantityT ='" + textBox3.Text + "', Unity ='" + textBox4.Text + "',  Total ='" + textBox5.Text + "' ,Price ='" + textBox8.Text + "' ,  Value ='" + textBox9.Text + "' where  ID='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    MessageBox.Show("يوجد خطأ", "Error");
                }


                //---------------- اضافة التعديل فى حركة الصنف  
                string sader = "0";
                string wared = "0";
                double aa = Convert.ToDouble(quntety);
                double bb = Convert.ToDouble(textBox2.Text);

                if (aa > bb)
                {
                    double sss = aa - bb;
                    sader = sss.ToString();
                }
                else if (bb > aa)
                {
                    double sss = bb - aa;
                    wared = sss.ToString();
                }
                else
                {

                }



                string Move = "تعديل الكمية ";
                //===================== إضافة حركة الصنف الجديده 
                sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Num,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + comCategory.Text + "','" + 0 + "','" + comStorages.Text + "','" + comStorages.Text + "','" + comStorages.Text + "','" + FormName + "','" + 0 + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Move + "','" + wared + "','" + sader + "','" + textBox2.Text + "','" + 0 + "','" + UserName + "')";
                sqlCommand1.ExecuteNonQuery();


                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");


            }

            else if (radioButton3.Checked == true)
            {
                try
                {
                    sqlCommand1.CommandText = "update Category set Near='" + textBox6.Text + "' where  ID ='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }

                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");
            }

            else if (radioButton4.Checked == true)
            {
                try
                {
                    sqlCommand1.CommandText = "update Available ='" + comboBox3.Text + "' where  ID ='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }

                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");
            }
            else if (radioButton5.Checked == true)
            {
                try
                {
                    sqlCommand1.CommandText = "update Category set  Emwared='" + textBox10.Text + "' where  ID ='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }

                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");
            }

            else if (radioButton6.Checked == true)
            {
                try
                {
                    sqlCommand1.CommandText = "update Category set  Group_Name='" + comCatGroup.Text + "' where  ID ='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }

                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");
            }
            else if (radioButton7.Checked == true)
            {
                try
                {
                    sqlCommand1.CommandText = "update Category set  Faction='" + ComTypeCategorey.Text + "' where  ID ='" + textBox7.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

                }
                catch
                {
                    //  MessageBox.Show("يوجد خطأ", "Error");
                }

                MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");
            }

            butSearch.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد حذف البيانات  ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("موافق", "موافق");

                try
                {
                    sqlCommand1.CommandText = "delete from Category where ID = '" + textBox7.Text + "'   ";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                { }

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_Checked();
        }
        private void radioButton1_Checked()
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = false;
                ComTypeCategorey.Enabled = false;
                comCatGroup.Enabled = false;
                butAll.Visible = false;
                textBox1.Focus();
            }
            else if (radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = true;
                ComTypeCategorey.Enabled = false;
                comCatGroup.Enabled = false;
                butAll.Visible = false;

                textBox2.Focus();
            }
            else if (radioButton3.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = true;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                ComTypeCategorey.Enabled = false;
                comCatGroup.Enabled = false;
                butAll.Visible = false;
                textBox6.Focus();
            }
            else if (radioButton4.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = true;
                ComTypeCategorey.Enabled = false;
                comCatGroup.Enabled = false;
                butAll.Visible = false;
                comboBox3.Focus();
            }
            else if (radioButton5.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = true;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                ComTypeCategorey.Enabled = false;
                comCatGroup.Enabled = false;
                butAll.Visible = false;

                textBox10.Focus();
            } 
            else if (radioButton6.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                ComTypeCategorey.Enabled = false;
                comCatGroup.Enabled = true;
                butAll.Visible = false;

                comCatGroup.Focus();
            }
            else if (radioButton7.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                ComTypeCategorey.Enabled = true;
                comCatGroup.Enabled = false;
                butAll.Visible = true;
                ComTypeCategorey.Focus();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_Checked();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_Checked();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_Checked();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_Checked();
        }

        private void ProducerUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            //*************** تسجيل الحركات  ***********************

            saveEvents("تم غلق شاشة  " + TransferData.FormName);

            //********************************************************
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dt2.Clear();
            Da2 = new SqlDataAdapter("select *From Category ", cn);
            Da2.Fill(Dt2);
            this.dataGridView1.DataSource = Dt2;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_Checked();
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "update Category set  Faction='" + ComTypeCategorey.Text + "' where  ID >='" + 1 + "' ";
                sqlCommand1.ExecuteNonQuery();
                // MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

            }
            catch
            {
                //  MessageBox.Show("يوجد خطأ", "Error");
            }

            MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  تحديث البيانات ");


            button1.PerformClick();
        }

        private void butSearchCategory_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {

                panel2.Visible = true;
                textBox1.Focus();
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            

            DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,PriceMostahlek From Category where Category like '%" + textBox11.Text + "%' ", cn);

            da.Fill(dt);
            this.dataGridSearchCategory.DataSource = dt;
        }

        private void dataGridSearchCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comCategory.Text = dataGridSearchCategory.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
    }
}
