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
using System.IO;

namespace ZAD_Sales.Forms
{
    public partial class ProducerNewAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //--------------------------------
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader rad;
        private SqlDataReader dr;
        private SqlDataReader reed;

        string Barcode = "";


        public ProducerNewAdd()
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
                SystemPro = "قطاعى";
               

                string[] com = { "قطعه", "طقم", "لفة", "علبة", "ربطه", "دستة", "كيس", "الف", "متر" };
               // ComTypeCategorey.DataSource = com;
                //comboBox1.SelectedIndex = comboBox1.Items.Count +0;
            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";
                
                comClient.Focus();

                string[] com = { "كرتونه", "دسته", "قطعه", "طقم", "لفة", "علبة", "ربطه", "كيس" };
                //ComTypeCategorey.DataSource = com;

            }
            // نهاية البحث نظام العمل جملة او قطاعى
        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            if (textID.Text == "")
            {
                if (comboBox3.Text == "")
                {
                    MessageBox.Show("    يجب ادخال عدد القطع الموجوده فى الكرتونة   ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox3.Focus();
                }
                else
                {
                    if (comboBox4.Text == "")
                    {
                        MessageBox.Show("    يجب ادخال فئة القطع الموجوده فى الكرتونة   ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBox4.Focus();
                    }
                    else
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] byteImage = ms.ToArray();


                        sqlCommand1.CommandText = "insert into Category (Category,Storage,Group_Name,Date,Quantity,QuantityT,Unity,Faction,Total,Price,PriceGomla,PriceMostahlek,Value,Near,Available,Emwared,Image)values (@Category,@Storage,@Group_Name,@Date,@Quantity,@QuantityT,@Unity,@Faction,@Total,@Price,@PriceGomla,@PriceMostahlek,@Value,@Near,@Available,@Emwared,@Image)";
                        sqlCommand1.Parameters.Add("@Category", SqlDbType.VarChar).Value = combCategorys.Text;
                        sqlCommand1.Parameters.Add("@Storage", SqlDbType.VarChar).Value = combStorage.Text;
                        sqlCommand1.Parameters.Add("@Group_Name", SqlDbType.VarChar).Value = combGroup_Name.Text;
                        sqlCommand1.Parameters.Add("@Date", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                        sqlCommand1.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = "0";
                        sqlCommand1.Parameters.Add("@QuantityT", SqlDbType.VarChar).Value = "0";
                        sqlCommand1.Parameters.Add("@Unity", SqlDbType.VarChar).Value = comboBox3.Text;
                        sqlCommand1.Parameters.Add("@Faction", SqlDbType.VarChar).Value = comboBox4.Text;
                        sqlCommand1.Parameters.Add("@Total", SqlDbType.VarChar).Value = "0";
                        sqlCommand1.Parameters.Add("@Price", SqlDbType.VarChar).Value = textPriceSheraa.Text;
                        sqlCommand1.Parameters.Add("@PriceGomla", SqlDbType.VarChar).Value = textPriceGomla.Text;
                        sqlCommand1.Parameters.Add("@PriceMostahlek", SqlDbType.VarChar).Value = textPriceKataey.Text;
                        sqlCommand1.Parameters.Add("@Value", SqlDbType.VarChar).Value = "0";
                        sqlCommand1.Parameters.Add("@Near", SqlDbType.VarChar).Value = textBox1.Text;
                        sqlCommand1.Parameters.Add("@Available", SqlDbType.VarChar).Value = comboBox5.Text;
                        sqlCommand1.Parameters.Add("@Emwared", SqlDbType.VarChar).Value = comClient.Text;
                        sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
                        sqlCommand1.ExecuteNonQuery();
                        sqlCommand1.Parameters.Clear();

                        //------------------------------   ايجاد الكود
                        try
                        {
                            sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' ";
                            rad = sqlCommand1.ExecuteReader();
                            while (rad.Read())
                            {
                                textID.Text = rad["ID"].ToString();


                            }
                            rad.Close();
                        }
                        catch
                        {

                        }

                        //--------------حساب الباركود واضافة فى الجدول الاصناف -------------


                        //--------------حساب الباركود واضافة فى الجدول الاصناف -------------

                        int b = 0;
                        try
                        {
                            int aa = Convert.ToInt32(AppSetting.BarcodeStart);
                            b = aa;
                            if (b == 0)
                            {

                                int a = Convert.ToInt32(textID.Text);
                                b = 10000000;
                                int s = a + b;
                                Barcode = s.ToString();



                            }
                            else
                            {
                                int a = Convert.ToInt32(textID.Text);
                                int s = a + b;
                                Barcode = s.ToString();


                            }

                        }
                        catch
                        {
                            int a = Convert.ToInt32(textID.Text);
                            b = 10000000;
                            int s = a + b;
                            Barcode = s.ToString();
                        }


                        textBarcode.Text = Barcode;


                        //int a = Convert.ToInt32(textID.Text);
                        //int b = 10000000;
                        //int s = a + b;
                        //textBarcode.Text = s.ToString();
                        //=============== تعديل الباركود فى جدول الاصناف ===============
                        sqlCommand1.CommandText = "update Category set  Barcode ='" + textBarcode.Text + "' where ID='" + textID.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("    هذا الصنف موجود من قبل   ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                combCategorys.Focus();

            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void butNew_Click(object sender, EventArgs e)
        {
            //combStorage.Text = "";
            combCategorys.Text = "";
            comboBox3.Text = "1";
            comboBox4.Text = "ق";
            // comboBox5.Text = "";
            //  comClient.Text = "";
            textBox1.Text = "2";
            textID.Text = "";
            textBarcode.Text = "0";
            textPriceSheraa.Text = "0";
            textPriceGomla.Text = "0";
            textPriceKataey.Text = "0";

            combCategorys.Focus();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            //sqlCommand1.CommandText = "update Category set  Category='" + comboBox1.Text + "',  Storage='" + comboBox2.Text + "' where Barcode='" + textBox1.Text + "' ";
            //sqlCommand1.ExecuteNonQuery();

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] byteImage = ms.ToArray();


            sqlCommand1.CommandText = "update  Category set Category=@Category,Storage=@Storage,Unity=@Unity,Faction=@Faction,Near=@Near,Available=@Available,Emwared=@Emwared,Image=@Image where ID ='" + textID.Text + "'";
            sqlCommand1.Parameters.Add("@Category", SqlDbType.VarChar).Value = combCategorys.Text;
            sqlCommand1.Parameters.Add("@Storage", SqlDbType.VarChar).Value = combStorage.Text;
            //  sqlCommand1.Parameters.Add("@Date", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            //  sqlCommand1.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = "0";
            // sqlCommand1.Parameters.Add("@QuantityT", SqlDbType.VarChar).Value = "0";
            sqlCommand1.Parameters.Add("@Unity", SqlDbType.VarChar).Value = comboBox3.Text;
            sqlCommand1.Parameters.Add("@Faction", SqlDbType.VarChar).Value = comboBox4.Text;
            // sqlCommand1.Parameters.Add("@Total", SqlDbType.VarChar).Value = "0";
            // sqlCommand1.Parameters.Add("@Price", SqlDbType.VarChar).Value = "0";
            //sqlCommand1.Parameters.Add("@Value", SqlDbType.VarChar).Value = "0";
            sqlCommand1.Parameters.Add("@Near", SqlDbType.VarChar).Value = textBox1.Text;
            sqlCommand1.Parameters.Add("@Available", SqlDbType.VarChar).Value = comboBox5.Text;
            sqlCommand1.Parameters.Add("@Emwared", SqlDbType.VarChar).Value = comClient.Text;
            sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {

            sqlCommand1.CommandText = "select Image,ID,Storage,Unity,Faction,Near,Available,Emwared from Category where Category = '" + combCategorys.Text + "'";

            dr = sqlCommand1.ExecuteReader();

            while (dr.Read())
            {
                byte[] bytblobdata = new byte[dr.GetBytes(0, 0, null, 0, int.MaxValue)];
                dr.GetBytes(0, 0, bytblobdata, 0, bytblobdata.Length);
                MemoryStream strmblobdata = new MemoryStream(bytblobdata);

                pictureBox1.Image = Image.FromStream(strmblobdata);
                textID.Text = dr["ID"].ToString();
                combStorage.Text = dr["Storage"].ToString();
                comboBox3.Text = dr["Unity"].ToString();
                comboBox4.Text = dr["Faction"].ToString();
                textBox1.Text = dr["Near"].ToString();
                comboBox5.Text = dr["Available"].ToString();
                comClient.Text = dr["Emwared"].ToString();



            }
            dr.Close();
            sqlCommand1.Dispose();
        }

        private void ProducerNewAdd_Load(object sender, EventArgs e)
        {
            ////----- إيجاد أسماء العملاء -----
            SqlDataAdapter Da;
            DataTable Dt = new DataTable();

            Da = new SqlDataAdapter("select Category from Category ", cn);
            Da.Fill(Dt);
            combCategorys.DataSource = Dt;
            combCategorys.DisplayMember = "Category";

            //----- إيجاد المخازن -----
            SqlDataAdapter Da1;
            DataTable Dt1 = new DataTable();

            Da1 = new SqlDataAdapter("select Storage from Storage ", cn);
            Da1.Fill(Dt1);
            combStorage.DataSource = Dt1;
            combStorage.DisplayMember = "Storage";

            //----- إيجاد مجموعات الاصناف -----
            SqlDataAdapter Da13;
            DataTable Dt13 = new DataTable();

            Da13 = new SqlDataAdapter("select Group_Name from CategoryGroup ", cn);
            Da13.Fill(Dt13);
            combGroup_Name.DataSource = Dt13;
            combGroup_Name.DisplayMember = "Group_Name";

            //-----------------

            // البحث نظام العمل جملة او قطاعى

            SystemProgram();

            //sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
            //reed = sqlCommand1.ExecuteReader();
            //while (reed.Read())
            //{

            //    textBox77.Text = reed["Kataey"].ToString();
            //    textBox76.Text = reed["GomlaKataey"].ToString();

            //}

            //reed.Close();

            if (SystemPro== "قطاعى") // قطاعى
            {
                groupBox2.Enabled = false;
                comboBox3.Text = "1";
                comboBox4.Text = "ق";

            }
            else  // جمله
            {
                groupBox2.Visible = true;

            }
            // نهاية البحث نظام العمل جملة او قطاعى

            try
            {
                string comp = "موردين";
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Clients where  Company = '" + comp + "' ", cn);
                Da2.Fill(Dt2);
                comClient.DataSource = Dt2;
                comClient.DisplayMember = "Name";
            }
            catch
            {

            }
        }

        private void combCategorys_TextChanged(object sender, EventArgs e)
        {
            textID.Text = "";
            textPriceSheraa.Text = "0";
            textPriceGomla.Text = "0";
            textPriceKataey.Text = "0";


            if (SystemPro == "قطاعى") // قطاعى
            {
                groupBox2.Enabled = false;
                comboBox3.Text = "1";
                comboBox4.Text = "ق";

            }
            else  // جمله
            {
                groupBox2.Visible = true;
                comboBox3.Text = "";
                comboBox4.Text = "";

            }


            sqlCommand1.CommandText = "select Image,ID,Storage,Unity,Faction,Near,Available,Emwared from Category where Category = '" + combCategorys.Text + "'";

            dr = sqlCommand1.ExecuteReader();

            while (dr.Read())
            {
                try
                {
                    byte[] bytblobdata = new byte[dr.GetBytes(0, 0, null, 0, int.MaxValue)];
                    dr.GetBytes(0, 0, bytblobdata, 0, bytblobdata.Length);
                    MemoryStream strmblobdata = new MemoryStream(bytblobdata);

                    pictureBox1.Image = Image.FromStream(strmblobdata);
                }
                catch
                { }
                textID.Text = dr["ID"].ToString();
                combStorage.Text = dr["Storage"].ToString();
                comboBox3.Text = dr["Unity"].ToString();
                comboBox4.Text = dr["Faction"].ToString();
                textBox1.Text = dr["Near"].ToString();
                comboBox5.Text = dr["Available"].ToString();
                comClient.Text = dr["Emwared"].ToString();



            }
            dr.Close();
            sqlCommand1.Dispose();
        }

        private void combCategorys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
