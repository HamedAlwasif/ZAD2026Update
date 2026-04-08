using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;

namespace ZAD_Sales.Forms
{
    public partial class StoreToStore : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string UserName1 = AppSetting.user;
        //---------------------------------
        int i = 0;
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader DataRed;
        //private SqlDataReader read;
        //---------------------------------

        DataTable table = new DataTable();
        DataTable table2 = new DataTable();

        string Barcode = "";

        string Faction = "";


        public StoreToStore()
        {
            InitializeComponent();
            //if (cn.State == System.Data.ConnectionState.Closed)
            //    cn.Open();

            cn.Open();
            sqlCommand1.Connection = cn;

            //cn.Open();
            //sqlCommand1.Connection = cn;

            ////----------------- ايجاد المخزن 2 --------------------
            //try
            //{
            //    SqlDataAdapter Da;
            //    DataTable Dt = new DataTable();
            //    Da = new SqlDataAdapter("select Storage from Storage", cn);
            //    Da.Fill(Dt);

            //    combStorage1.DataSource = Dt;
            //    combStorage1.DisplayMember = "Storage";
            //}
            //catch
            //{

            //}

            //try
            //{

            //    DataTable dt = new DataTable();
            //    dt.Clear();
            //    SqlDataAdapter da = new SqlDataAdapter("Select * From Transport", cn);
            //    da.Fill(dt);
            //    this.dataGridView2.DataSource = dt;

            //}
            //catch
            //{

            //}
        }
        public class Class_StoreToStore
        {

            public string Date { get; set; }
            public string Category { get; set; }
            public string Quantity { get; set; }
            public string Part { get; set; }
            public string FromStorage { get; set; }
            public string ToStorage { get; set; }


        }
        public void SystemProgram()
        {
            //------------------- البحث نظام العمل جملة او قطاعى -------------

            //cn.Open();

            string Kataey = "";
                string GomKataey = "";
            try
            {
                  SqlDataReader reed;
                 sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    Kataey = reed["Kataey"].ToString();
                    GomKataey = reed["GomlaKataey"].ToString();


                }

                reed.Close();
            }
            catch
            { }




            if (Kataey == "1") // قطاعى
            {

                SystemPro = "قطاعى";

                panelKatey.Visible = true;
                panelGola.Visible = false;
            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";

                panelKatey.Visible = false;
                panelGola.Visible = true;

            }
            // نهاية البحث نظام العمل جملة او قطاعى

            //cn.Close();
        }

        //private void SetupGrid()
        //{
        //    if (table.Columns.Count == 0)
        //    {
        //        table.Columns.Add("Date");
        //        table.Columns.Add("Category");
        //        table.Columns.Add("Quantity");
        //        table.Columns.Add("FromStorage");
        //        table.Columns.Add("ToStorage");

        //        dataGridView1.DataSource = table;

        //        dataGridView1.Columns[0].HeaderText = "التاريخ";
        //        dataGridView1.Columns[1].HeaderText = "الصنف";
        //        dataGridView1.Columns[2].HeaderText = "الكمية";
        //        dataGridView1.Columns[3].HeaderText = "من المخزن";
        //        dataGridView1.Columns[4].HeaderText = "إلى المخزن";
        //    }
        //}


        private void GetData()
        {
            //----------------- ايجاد المخزن 1 --------------------



            try
            {
                SqlDataAdapter Da2;
                DataTable Dt11 = new DataTable();
                Da2 = new SqlDataAdapter("select Storage from Storage", cn);
                Da2.Fill(Dt11);
                combStorage.DataSource = Dt11;
                combStorage.DisplayMember = "Storage";


            }
            catch
            {

            }

            try
            {
                SqlDataAdapter Da3;
                DataTable Dt13 = new DataTable();
                Da3 = new SqlDataAdapter("select Storage from Storage", cn);
                Da3.Fill(Dt13);
                combStorage1.DataSource = Dt13;
                combStorage1.DisplayMember = "Storage";


            }
            catch
            {

            }

            //***************


            //----------------- ايجاد الاصناف --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Category from Category", cn);
                Da1.Fill(Dt1);
                combCategorys.DataSource = Dt1;
                combCategorys.DisplayMember = "Category";

                //-------------------------
                combCategorys1.DataSource = Dt1;
                combCategorys1.DisplayMember = "Category";
            }
            catch
            {

            }


            //=================== القطاعى ===============
            try
            {
                SqlDataAdapter Da4;
                DataTable Dt14 = new DataTable();
                Da4 = new SqlDataAdapter("select Storage from Storage", cn);
                Da4.Fill(Dt14);
                combStorageKatey1.DataSource = Dt14;
                combStorageKatey1.DisplayMember = "Storage";


            }
            catch
            {

            }


            try
            {
                SqlDataAdapter Da5;
                DataTable Dt15 = new DataTable();
                Da5 = new SqlDataAdapter("select Storage from Storage", cn);
                Da5.Fill(Dt15);
                combStorageKatey2.DataSource = Dt15;
                combStorageKatey2.DisplayMember = "Storage";


            }
            catch
            {

            }

            //----------------- ايجاد الاصناف --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Category from Category", cn);
                Da1.Fill(Dt1);
                combCategorys.DataSource = Dt1;
                combCategorys.DisplayMember = "Category";

                //-------------------------
                combCategorysKataey.DataSource = Dt1;
                combCategorysKataey.DisplayMember = "Category";
            }
            catch
            {

            }

        }
        private void StoreToStore_Load(object sender, EventArgs e)
        {
            //cn.Open();

            GetData();

            getdataDay();






            SystemProgram();

            textBox55.Text = UserName1;

            //cn.Close();


            //SetupGrid();

        }

        private void combCategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            //- إيجاد الكميه الاول

            textBox3.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
            textBox4.Text = "0";
            txtPriceShera.Text = "0";
            txtPriceMostahleh.Text = "0";
            txtPriceGomla.Text = "0";

            //try
            //{
                SqlDataReader DReed;
                sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "' AND Storage Like'" + combStorage.Text + "'  ";
            DReed = sqlCommand1.ExecuteReader();
                while (DReed.Read())
                {
                    textStorageBarcode.Text = DReed["Barcode"].ToString();
                    textStorageBarcode_Factory.Text = DReed["Barcode_Factory"].ToString();
                    textBox3.Text = DReed["Quantity"].ToString();
                    textBox24.Text = DReed["QuantityT"].ToString();
                    textBox5.Text = DReed["Unity"].ToString();
                    textBox6.Text = DReed["Faction"].ToString();
                    textBox4.Text = DReed["Total"].ToString();
                    txtPriceShera.Text = DReed["Price"].ToString();
                    txtPriceMostahleh.Text = DReed["PriceMostahlek"].ToString();
                    txtPriceGomla.Text = DReed["PriceGomla"].ToString();

                }
            DReed.Close();
            //}
            //catch
            //{ }

            //- إيجاد الكميه الاول

            textBox12.Text = "0";
            textBox10.Text = "0";
            textBox9.Text = "";
            textBox11.Text = "0";
            textBox13.Text = "0";

            SqlDataReader reed;

            sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "' AND Storage Like'" + combStorage1.Text + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                textStorageBarcode1.Text = reed["Barcode"].ToString();
                textStorageBarcode_Factory1.Text = reed["Barcode_Factory"].ToString();
                textBox12.Text = reed["Quantity"].ToString();
                textBox23.Text = reed["QuantityT"].ToString();
                textBox10.Text = reed["Unity"].ToString();
                textBox9.Text = reed["Faction"].ToString();
                textBox11.Text = reed["Total"].ToString();
                textBox13.Text = reed["Unity"].ToString();


            }
            reed.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combStorage.Text == combStorage1.Text)
            {
                MessageBox.Show("       يجب تغير المخزن            ", "  خطأ  ");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("       من فضلك أدخل الكمية            ", "  خطأ  ");
                    textBox1.Focus();
                }
                else
                {

                    // طرح الكميه من الكميه الكليه

                    double a = Convert.ToDouble(textBox5.Text);
                    double b = Convert.ToDouble(textBox1.Text);
                    double c = Convert.ToDouble(textBox2.Text);
                    double d = (b * a) + c;
                    textBox7.Text = d.ToString();

                    //*************
                    double ad = Convert.ToDouble(textBox4.Text);
                    double ab = Convert.ToDouble(textBox7.Text);
                    if (ab <= ad)
                    {

                        double dd = ad - ab;
                        textBox4.Text = dd.ToString();
                        // معرفة كمية الاجمالى بعد الخصم
                        try
                        {
                            int s = int.Parse(textBox4.Text);
                            int t = int.Parse(textBox5.Text);
                            int ss = s / t;
                            textBox3.Text = ss.ToString();

                            // حساب القطع
                            int k = s - (ss * t);
                            textBox24.Text = k.ToString();

                            //*****************************************

                            textBox10.Text = textBox5.Text;
                            textBox9.Text = textBox6.Text;

                            double a1 = Convert.ToDouble(textBox11.Text);
                            double b1 = Convert.ToDouble(textBox7.Text);
                            double d1 = a1 + b1;
                            textBox11.Text = d1.ToString();
                            // معرفة كمية الاجمالى بعد الاضافة

                            int s1 = int.Parse(textBox11.Text);
                            int t1 = int.Parse(textBox10.Text);
                            int ss1 = s1 / t1;
                            textBox12.Text = ss1.ToString();


                            // حساب القطع
                            int kk = s1 - (ss1 * t1);
                            textBox23.Text = kk.ToString();
                        }
                        catch
                        {
                            MessageBox.Show("       يوجد خطأ فى البيانات            ", "  خطأ  ");

                        }

                        //--- إيجاد قيمة المخزن القديم
                        double aa1 = Convert.ToDouble(txtPriceShera.Text);
                        double bb1 = Convert.ToDouble(textBox4.Text);
                        double dd1 = aa1 * bb1;
                        textBox16.Text = dd1.ToString();

                        //--- إيجاد قيمة المخزن الجديد
                        double aaa1 = Convert.ToDouble(txtPriceShera.Text);
                        double bbb1 = Convert.ToDouble(textBox11.Text);
                        double ddd1 = aaa1 * bbb1;
                        textBox17.Text = ddd1.ToString();

                        //***************************************
                        if (textBox13.Text == "0") // صنف ينقل لاول مرة
                        {
                            //تعدل الصنف فى المخزن القديم
                            sqlCommand1.CommandText = "update Category set  Quantity ='" + textBox3.Text + "',QuantityT ='" + textBox24.Text + "',Total = '" + textBox4.Text + "',Available = '" + textBox8.Text + "',Value = '" + textBox16.Text + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "insert into Category (Category,Storage,Date,Quantity,QuantityT,Unity,Faction,Total,Price,PriceGomla,PriceMostahlek,Value,Near,Available)values ('" + combCategorys.Text + "','" + combStorage1.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox12.Text + "','" + textBox23.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox11.Text + "','" + txtPriceShera.Text + "','" + txtPriceGomla.Text + "','" + txtPriceMostahleh.Text + "','" + textBox17.Text + "','" + 0 + "','" + textBox8.Text + "')";
                            sqlCommand1.ExecuteNonQuery();

                            //------------------------------------
                            SqlDataReader read;
                            sqlCommand1.CommandText = "select * from Category where Category = '" + combCategorys.Text + "' and Storage = '" + combStorage1.Text + "' ";
                            read = sqlCommand1.ExecuteReader();
                            while (read.Read())
                            {
                                textIDCategory.Text = read["ID"].ToString();
                            }
                            read.Close();
                            //--------------حساب الباركود واضافة فى الجدول الاصناف -------------
                            int aa = Convert.ToInt32(textIDCategory.Text);
                            int bb = 1000000000;
                            int s = aa + bb;
                            textBarcode.Text = s.ToString();
                            //=============== تعديل الباركود فى جدول الاصناف ===============
                            sqlCommand1.CommandText = "update Category set  Barcode ='" + textBarcode.Text + "' where ID='" + textIDCategory.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            // إضافة البيانات فى جدول النقل
                            sqlCommand1.CommandText = "insert into Transport (Date,Category,Quantity,Part,FromStorage,ToStorage)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorys.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + combStorage.Text + "','" + combStorage1.Text + "')";
                            sqlCommand1.ExecuteNonQuery();




                        }
                        else
                        {
                            try
                            {
                                //تعدل الصنف فى المخزن الجديد
                                sqlCommand1.CommandText = "update Category set  Quantity ='" + textBox12.Text + "',QuantityT ='" + textBox23.Text + "',Total = '" + textBox11.Text + "',Value = '" + textBox17.Text + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage1.Text + "' ";
                                sqlCommand1.ExecuteNonQuery();
                                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");

                                //تعدل الصنف فى المخزن القديم
                                sqlCommand1.CommandText = "update Category set  Quantity ='" + textBox3.Text + "',QuantityT ='" + textBox24.Text + "',Total = '" + textBox4.Text + "',Value = '" + textBox16.Text + "' where  Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "' ";
                                sqlCommand1.ExecuteNonQuery();
                                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                            }
                            catch
                            {

                            }


                            // إضافة البيانات فى جدول النقل
                            sqlCommand1.CommandText = "insert into Transport (Date,Category,Quantity,Part,FromStorage,ToStorage)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorys.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + combStorage.Text + "','" + combStorage1.Text + "')";
                            sqlCommand1.ExecuteNonQuery();
                        }

                        //=====================  إضافة حركة الصنف الجديده المخزن الصادر 
                        sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorys.Text + "','" + combStorage.Text + "','" + combStorage.Text + "','" + combStorage1.Text + "','" + textBox19.Text + "','" + textBox20.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox21.Text + "','" + 0 + "','" + textBox7.Text + "','" + textBox7.Text + "','" + textBox4.Text + "','" + textBox55.Text + "')";
                        sqlCommand1.ExecuteNonQuery();

                        //=====================  إضافة حركة الصنف الجديده المخزن الوارد 
                        sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorys.Text + "','" + combStorage1.Text + "','" + combStorage.Text + "','" + combStorage1.Text + "','" + textBox19.Text + "','" + textBox20.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox22.Text + "','" + textBox7.Text + "','" + 0 + "','" + textBox7.Text + "','" + textBox11.Text + "','" + textBox55.Text + "')";
                        sqlCommand1.ExecuteNonQuery();


                        combCategorys.Focus();

                        //**********************************
                        try
                        {
                            SqlDataReader dataReader;
                            SqlDataAdapter dataAdapter = new SqlDataAdapter();
                            DataSet dataset3 = new DataSet();

                            dataAdapter.SelectCommand = new SqlCommand("select Date,Category,Quantity,FromStorage,ToStorage from Transport where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' AND ToStorage ='" + combStorage1.Text + "' ", cn);
                            dataAdapter.Fill(dataset3);
                            sqlCommand1.Connection = cn;
                            sqlCommand1.CommandText = "select Date,Category,Quantity,FromStorage,ToStorage from Transport where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' AND ToStorage ='" + combStorage1.Text + "'  ";
                            dataReader = sqlCommand1.ExecuteReader();

                            while (dataReader.Read())
                            {
                                dataGridView2.DataSource = dataset3.Tables[0];
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

                        int rowNumber = 1;
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            if (row.IsNewRow) continue;
                            row.HeaderCell.Value = "" + rowNumber + "";
                            rowNumber = rowNumber + 1;
                        }
                        dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

                        //---------- حساب الاجمالى
                        double aad = Convert.ToDouble(textBox18.Text);
                        double bad = Convert.ToDouble(textBox17.Text);

                        double asd = aad + bad;
                        textBox18.Text = asd.ToString();
                    }
                    else
                    {
                        MessageBox.Show("   الكمية الموجودة لا تكفى    ", "  المخزن ");
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox14.Text = combStorage1.Text;
            combStorage1.Text = combStorage.Text;
            combStorage.Text = textBox14.Text;
        }

        private void combCategorys1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
                try
                {
                    table.Clear(); // يمسح الصفوف فقط

                    string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Category LIKE @cat + '%'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                    adapter.SelectCommand.Parameters.AddWithValue("@cat", combCategorys1.Text);

                    adapter.Fill(table); // يملأ نفس الجدول المرتبط بالجريد

                    // تخصيص عرض الأعمدة وتنسيق الهيدر بعد تحميل البيانات
                    this.dataGridView1.DataSource = table;

                    // تنسيق الهيدر وأعرض الأعمدة
                    this.dataGridView1.Columns[0].HeaderText = "التاريخ"; // تغيير اسم العمود الأول
                    this.dataGridView1.Columns[0].Width = 120; // تغيير عرض العمود الأول

                    this.dataGridView1.Columns[1].HeaderText = "الصنف"; // تغيير اسم العمود الثاني
                    this.dataGridView1.Columns[1].Width = 300; // تغيير عرض العمود الثاني

                    this.dataGridView1.Columns[2].HeaderText = "الكمية"; // تغيير اسم العمود الثالث
                    this.dataGridView1.Columns[2].Width = 100; // تغيير عرض العمود الثالث

                    this.dataGridView1.Columns[3].HeaderText = "من المخزن"; // تغيير اسم العمود الرابع
                    this.dataGridView1.Columns[3].Width = 120; // تغيير عرض العمود الرابع

                    this.dataGridView1.Columns[4].HeaderText = "إلى المخزن"; // تغيير اسم العمود الخامس
                    this.dataGridView1.Columns[4].Width = 120; // تغيير عرض العمود الخامس

                    if (table.Rows.Count == 0)
                    {
                       // MessageBox.Show("هذا الصنف غير موجود", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ أثناء تحميل البيانات: " + ex.Message);
                }
            


            //try
            //{
            //    table.Clear(); // يمسح الصفوف فقط

            //    string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Category LIKE @cat + '%'";
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
            //    adapter.SelectCommand.Parameters.AddWithValue("@cat", combCategorys1.Text);

            //    adapter.Fill(table); // يملأ نفس الجدول المرتبط بالجريد
            //    dataGridView1.DataSource = table; // أعد الربط لو حصل انفصال
            //    this.dataGridView1.Columns[0].HeaderText = "التاريخ";
            //    this.dataGridView1.Columns[0].Width = 120;
            //    if (table.Rows.Count == 0)
            //    {
            //       // MessageBox.Show("هذا الصنف غير موجود", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("خطأ أثناء تحميل البيانات: " + ex.Message);
            //}

            //try
            //{
            //    // مسح الصفوف فقط بدون التأثير على الأعمدة
            //    table.Clear();

            //    string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Category LIKE @cat + '%'";
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
            //    adapter.SelectCommand.Parameters.AddWithValue("@cat", combCategorys1.Text);

            //    adapter.Fill(table); // ملء الجدول بالبيانات الجديدة

            //    if (table.Rows.Count == 0)
            //    {
            //       // MessageBox.Show("هذا الصنف غير موجود", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



            //try
            //{
            //    dataGridView1.DataSource = null;
            //    //dataGridView1.Rows.Clear();

            //    string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Category LIKE @category + '%'";

            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
            //    dataAdapter.SelectCommand.Parameters.AddWithValue("@category", combCategorys1.Text);

            //    DataSet dataset = new DataSet();
            //    dataAdapter.Fill(dataset);

            //    if (dataset.Tables[0].Rows.Count > 0)
            //    {
            //        dataGridView1.DataSource = dataset.Tables[0];
            //    }
            //    else
            //    {
            //        MessageBox.Show("هذا الصنف غير موجود", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("حدث خطأ أثناء جلب البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



            //try
            //{
            //    SqlDataReader dataReader;
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter();
            //    DataSet dataset3 = new DataSet();

            //    dataAdapter.SelectCommand = new SqlCommand("select Date,Category,Quantity,FromStorage,ToStorage from Transport where Category like '" + combCategorys1.Text + "%' ", cn);
            //    dataAdapter.Fill(dataset3);
            //    sqlCommand1.Connection = cn;
            //    sqlCommand1.CommandText = "select Date,Category,Quantity,FromStorage,ToStorage from Transport where Category like '" + combCategorys1.Text + "%'  ";
            //    using (dataReader = sqlCommand1.ExecuteReader())
            //    {

            //        while (dataReader.Read())
            //        {
            //            dataGridView1.DataSource = dataset3.Tables[0];
            //            //checkedListBox1.Items.Add(dataReader["Name"]);
            //            i = i + 1;

            //        }


            //        if (i == 0)

            //            //MessageBox.Show("This Name is not exist", "  Search");



            //            dataReader.Close();
            //    }
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show(" هذا الصنف غير موجود   ", " ملحوظه ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                table2.Clear(); // يمسح الصفوف فقط

                // استعلام مع معلمة لتجنب مشاكل SQL Injection
                string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Date = @date";

                // استخدام SqlDataAdapter لملء DataSet
                SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                adapter.SelectCommand.Parameters.AddWithValue("@date", dateTimePicker2.Value.ToString("MM/dd/yyyy"));


                //string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Category LIKE @cat + '%'";
                //SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                //adapter.SelectCommand.Parameters.AddWithValue("@cat", combCategorys1.Text);

                adapter.Fill(table2); // يملأ نفس الجدول المرتبط بالجريد

                // تخصيص عرض الأعمدة وتنسيق الهيدر بعد تحميل البيانات
                this.dataGridView1.DataSource = table2;

                // تنسيق الهيدر وأعرض الأعمدة
                this.dataGridView1.Columns[0].HeaderText = "التاريخ"; // تغيير اسم العمود الأول
                this.dataGridView1.Columns[0].Width = 120; // تغيير عرض العمود الأول

                this.dataGridView1.Columns[1].HeaderText = "الصنف"; // تغيير اسم العمود الثاني
                this.dataGridView1.Columns[1].Width = 300; // تغيير عرض العمود الثاني

                this.dataGridView1.Columns[2].HeaderText = "الكمية"; // تغيير اسم العمود الثالث
                this.dataGridView1.Columns[2].Width = 100; // تغيير عرض العمود الثالث

                this.dataGridView1.Columns[3].HeaderText = "من المخزن"; // تغيير اسم العمود الرابع
                this.dataGridView1.Columns[3].Width = 120; // تغيير عرض العمود الرابع

                this.dataGridView1.Columns[4].HeaderText = "إلى المخزن"; // تغيير اسم العمود الخامس
                this.dataGridView1.Columns[4].Width = 120; // تغيير عرض العمود الخامس

                if (table.Rows.Count == 0)
                {
                    // MessageBox.Show("هذا الصنف غير موجود", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تحميل البيانات: " + ex.Message);
            }



            try
            {
                // إعادة تعيين مصدر البيانات من الـ DataGridView
                dataGridView1.DataSource = null;

                // استعلام مع معلمة لتجنب مشاكل SQL Injection
                string query = "SELECT Date, Category, Quantity, FromStorage, ToStorage FROM Transport WHERE Date = @date";

                // استخدام SqlDataAdapter لملء DataSet
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, cn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@date", dateTimePicker2.Value.ToString("MM/dd/yyyy"));

                // إنشاء DataSet لتحميل البيانات
                DataSet dataset3 = new DataSet();
                dataAdapter.Fill(dataset3);

                // التحقق إذا كانت البيانات موجودة في DataSet
                if (dataset3.Tables[0].Rows.Count > 0)
                {
                    // تعيين مصدر البيانات إلى DataGridView
                    dataGridView1.DataSource = dataset3.Tables[0];

                    // تنسيق الهيدر وأعرض الأعمدة
                    this.dataGridView1.Columns[0].HeaderText = "التاريخ"; // تغيير اسم العمود الأول
                    this.dataGridView1.Columns[0].Width = 120; // تغيير عرض العمود الأول

                    this.dataGridView1.Columns[1].HeaderText = "الصنف"; // تغيير اسم العمود الثاني
                    this.dataGridView1.Columns[1].Width = 300; // تغيير عرض العمود الثاني

                    this.dataGridView1.Columns[2].HeaderText = "الكمية"; // تغيير اسم العمود الثالث
                    this.dataGridView1.Columns[2].Width = 100; // تغيير عرض العمود الثالث

                    this.dataGridView1.Columns[3].HeaderText = "من المخزن"; // تغيير اسم العمود الرابع
                    this.dataGridView1.Columns[3].Width = 120; // تغيير عرض العمود الرابع

                    this.dataGridView1.Columns[4].HeaderText = "إلى المخزن"; // تغيير اسم العمود الخامس
                    this.dataGridView1.Columns[4].Width = 120; // تغيير عرض العمود الخامس
                }
                else
                {
                    // في حالة عدم وجود بيانات
                   // MessageBox.Show("لا توجد بيانات في هذا التاريخ", "بحث");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            //try
            //{

            //    dataGridView1.DataSource = null;


            //    SqlDataReader dataReader;
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter();
            //    DataSet dataset3 = new DataSet();

            //    dataAdapter.SelectCommand = new SqlCommand("select Date,Category,Quantity,FromStorage,ToStorage  from Transport where Date = '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' ", cn);
            //    dataAdapter.Fill(dataset3);
            //    sqlCommand1.Connection = cn;
            //    sqlCommand1.CommandText = "select Date,Category,Quantity,FromStorage,ToStorage  from Transport where Date = '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'  ";
            //    using (dataReader = sqlCommand1.ExecuteReader())
            //    {

            //        while (dataReader.Read())
            //        {
            //            dataGridView1.DataSource = dataset3.Tables[0];
            //            //checkedListBox1.Items.Add(dataReader["Name"]);
            //            i = i + 1;

            //        }


            //        if (i == 0)

            //            MessageBox.Show("This Name is not exist", "  Search");



            //        dataReader.Close();
            //    }
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show(" هذا الصنف غير موجود   ", " ملحوظه ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void LoadCategoryData(string category, string storage, TextBox barcodeField, TextBox idField, TextBox totalField,TextBox priceSheraaField = null, TextBox priceMostahlekField = null,
    TextBox priceGomlaField = null, TextBox priceGomlaAlgomlaField = null,
    TextBox priceNesfGomlaField = null)
        {
            string query = "SELECT * FROM Category WHERE Category = @Category AND Storage = @Storage";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Storage", storage);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        barcodeField.Text = reader["Barcode"].ToString();
                        idField.Text = reader["ID"].ToString();
                        totalField.Text = reader["Total"].ToString();

                        // القيم الإضافية لتخزين 1 فقط
                        priceSheraaField?.Invoke(new Action(() => priceSheraaField.Text = reader["Price"].ToString()));
                        priceMostahlekField?.Invoke(new Action(() => priceMostahlekField.Text = reader["PriceMostahlek"].ToString()));
                        priceGomlaField?.Invoke(new Action(() => priceGomlaField.Text = reader["PriceGomla"].ToString()));
                        priceGomlaAlgomlaField?.Invoke(new Action(() => priceGomlaAlgomlaField.Text = reader["PriceGomlaAlgomla"].ToString()));
                        priceNesfGomlaField?.Invoke(new Action(() => priceNesfGomlaField.Text = reader["PriceNesfAlgomla"].ToString()));
                    }
                }
            }
        }
        private void SearchCategoryFromStorages()
        {
            // --------------------------- تحسين الكود  ------
            // تصفير الحقول أولاً
            textTotalStogeKataey1.Text = "0";
            textTotalStogeKataey2.Text = "0";
            textTotalKataey.Text = "0";

            txtPriceShera.Text = "0";
            txtPriceMostahleh.Text = "0";
            txtPriceGomla.Text = "0";
            textPriceGomlaAlgomla.Text = "0";
            textPriceNesfGomla.Text = "0";

            textIDCategory.Text = "0";
            textIDCategory1.Text = "0";
            textStorage1Barcode.Text = "0";
            textStorage2Barcode.Text = "0";

            textBox12.Text = "0";
            textBox10.Text = "0";
            textBox9.Text = "";
            textBox11.Text = "0";

            // تحميل بيانات التخزين الأول
            LoadCategoryData(
                combCategorysKataey.Text, combStorageKatey1.Text,
                textStorage1Barcode, textIDCategory1, textTotalStogeKataey1,
                textPriceSheraa, textPriceKatey, textPriceGomla,
                textPriceGomlaAlgomla, textPriceNesfGomla
            );

            // تحميل بيانات التخزين الثاني
            LoadCategoryData(
                combCategorysKataey.Text, combStorageKatey2.Text,
                textStorage2Barcode, textIDCategory, textTotalStogeKataey2
            );


            //- إيجاد الكميه الاول
            //------------------------------************************
            //textTotalStogeKataey1.Text = "0";
            //textTotalStogeKataey2.Text = "0";

            //textTotalKataey.Text = "0";

            //txtPriceShera.Text = "0";
            //txtPriceMostahleh.Text = "0";
            //txtPriceGomla.Text = "0";

            //textPriceGomlaAlgomla.Text = "0";
            //textPriceNesfGomla.Text = "0";


            //textIDCategory.Text = "0";
            //textIDCategory1.Text = "0";


            //SqlDataReader DReed;
            //sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorysKataey.Text + "' AND Storage Like'" + combStorageKatey1.Text + "'  ";
            //using (DReed = sqlCommand1.ExecuteReader())
            //{
            //    while (DReed.Read())
            //    {
            //        textStorage1Barcode.Text = DReed["Barcode"].ToString();
            //        textIDCategory1.Text = DReed["ID"].ToString();
            //        //textBox3.Text = DReed["Quantity"].ToString();
            //        //textBox24.Text = DReed["QuantityT"].ToString();
            //        Faction = DReed["Faction"].ToString();
            //        //textBox6.Text = DReed["Faction"].ToString();
            //        textTotalStogeKataey1.Text = DReed["Total"].ToString();
            //        textPriceSheraa.Text = DReed["Price"].ToString();
            //        textPriceKatey.Text = DReed["PriceMostahlek"].ToString();
            //        textPriceGomla.Text = DReed["PriceGomla"].ToString();
            //        textPriceGomlaAlgomla.Text = DReed["PriceGomlaAlgomla"].ToString();
            //        textPriceNesfGomla.Text = DReed["PriceNesfAlgomla"].ToString();

            //    }
            //    DReed.Close();
            //}
            ////}
            ////catch
            ////{ }

            ////- إيجاد الكميه الاول

            //textBox12.Text = "0";
            //textBox10.Text = "0";
            //textBox9.Text = "";
            //textBox11.Text = "0";
            //textStorage2Barcode.Text = "0";

            //SqlDataReader reed;

            //sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorysKataey.Text + "' AND Storage Like'" + combStorageKatey2.Text + "'  ";
            //using (reed = sqlCommand1.ExecuteReader())
            //{
            //    while (reed.Read())
            //    {
            //        textStorage2Barcode.Text = reed["Barcode"].ToString();
            //        textIDCategory.Text = reed["ID"].ToString();
            //        //textBox12.Text = reed["Quantity"].ToString();
            //        //textBox23.Text = reed["QuantityT"].ToString();
            //        //textBox10.Text = reed["Unity"].ToString();
            //        //textBox9.Text = reed["Faction"].ToString();
            //        textTotalStogeKataey2.Text = reed["Total"].ToString();
            //        //textBox13.Text = reed["Unity"].ToString();


            //    }
            //    reed.Close();
            //}
        }
        private void combCategorysKataey_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCategoryFromStorages();
        }

        private void getdataDay()
        {
            try
            {
                string query = "SELECT * FROM Transport WHERE Date = @Date AND ToStorage = @ToStorage";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@ToStorage", combStorageKatey2.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    if (dataset.Tables[0].Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dataset.Tables[0];
                    }
                    else
                    {
                        // MessageBox.Show("لا توجد نتائج مطابقة", "تنبيه");
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("حدث خطأ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // ترقيم الصفوف
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber++;
            }
            dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            // جمع القيم في العمود الثالث (index = 2)
            double total = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                if (double.TryParse(row.Cells[2].Value?.ToString(), out double value))
                {
                    total += value;
                }
            }

            textBox18.Text = Math.Round(total, 2).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (combStorageKatey1.Text == combStorageKatey2.Text)
            {
                MessageBox.Show("       يجب تغير المخزن            ", "  خطأ  ");
            }
            else
            {
                if (textTotalKataey.Text == "" || textTotalKataey.Text == "0")
                {
                    MessageBox.Show("       من فضلك أدخل الكمية            ", "  خطأ  ");
                    textTotalKataey.Focus();
                }
                else
                {

                    // طرح الكميه من الكميه الكليه

                    double a = Convert.ToDouble(textBox5.Text);
                    double b = Convert.ToDouble(textBox1.Text);
                    double c = Convert.ToDouble(textBox2.Text);
                    double d = (b * a) + c;
                    textBox7.Text = d.ToString();

                    //*************
                    double ad = Convert.ToDouble(textBox4.Text);
                    double ab = Convert.ToDouble(textBox7.Text);
                    if (ab <= ad)
                    {

                        double dd = ad - ab;
                        textBox4.Text = dd.ToString();
                        // معرفة كمية الاجمالى بعد الخصم
                        try
                        {
                            double a1 = Convert.ToDouble(textTotalKataey.Text);
                            double b1 = Convert.ToDouble(textTotalStogeKataey1.Text);
                            double d1 = b1 - a1;
                            textTotalStogeKataey1.Text = d1.ToString();


                            double a2 = Convert.ToDouble(textTotalKataey.Text);
                            double b2 = Convert.ToDouble(textTotalStogeKataey2.Text);
                            double d2 = a2 + b2;
                            textTotalStogeKataey2.Text = d2.ToString();


                        }
                        catch
                        {
                            MessageBox.Show("       يوجد خطأ فى البيانات            ", "  خطأ  ");

                        }

                        //--- إيجاد قيمة المخزن القديم
                        double aa1 = Convert.ToDouble(txtPriceSheraKatey.Text);
                        double bb1 = Convert.ToDouble(textTotalStogeKataey1.Text);
                        double dd1 = aa1 * bb1;
                        txtPriceSheraKatey1.Text = dd1.ToString();

                        //--- إيجاد قيمة المخزن الجديد
                        double aaa1 = Convert.ToDouble(textPriceSheraa.Text);
                        double bbb1 = Convert.ToDouble(textTotalStogeKataey2.Text);
                        double ddd1 = aaa1 * bbb1;
                        txtTotalProduct.Text = ddd1.ToString();

                        //***************************************
                        if (textStorage2Barcode.Text == "0") // صنف ينقل لاول مرة لا يوجد له باركود
                        {
                            //تعدل الصنف فى المخزن القديم
                            sqlCommand1.CommandText = "update Category set  Quantity ='" + 0 + "',QuantityT ='" + 0 + "',Total = '" + textTotalStogeKataey1.Text + "',Available = '" + textBox8.Text + "',Value = '" + txtPriceSheraKatey1.Text + "' where  Category ='" + combCategorysKataey.Text + "' AND Storage ='" + combStorageKatey1.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "insert into Category (Category,Storage,Date,Quantity,QuantityT,Total,Price,PriceGomla,PriceMostahlek,PriceGomlaAlgomla,PriceNesfAlgomla,Value,Near,Available,Unity,Faction)values ('" + combCategorysKataey.Text + "','" + combStorageKatey2.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + 0 + "','" + 0 + "','" + textTotalStogeKataey2.Text + "','" + txtPriceShera.Text + "','" + txtPriceGomla.Text + "','" + txtPriceMostahleh.Text + "','" + textPriceGomlaAlgomla.Text + "','" + textPriceNesfGomla.Text + "','" + txtTotalProduct.Text + "','" + 0 + "','" + textBox8.Text + "','" + 1 + "','" + Faction + "')";
                            sqlCommand1.ExecuteNonQuery();

                            //------------------------------------
                            SqlDataReader read;
                            sqlCommand1.CommandText = "select * from Category where Category = '" + combCategorysKataey.Text + "' and Storage = '" + combStorageKatey2.Text + "' ";
                            read = sqlCommand1.ExecuteReader();
                            while (read.Read())
                            {
                                textIDCategory.Text = read["ID"].ToString();
                            }
                            read.Close();




                            //--------------حساب الباركود واضافة فى الجدول الاصناف -------------

                            int b2 = 0;
                            try
                            {
                                int aa2 = Convert.ToInt32(AppSetting.BarcodeStart);
                                b2 = aa2;
                                if (b2 == 0)
                                {

                                    int a2 = Convert.ToInt32(textIDCategory.Text);
                                    b2 = 10000000;
                                    int s2 = a2 + b2;
                                    Barcode = s2.ToString();



                                }
                                else
                                {
                                    int a22 = Convert.ToInt32(textIDCategory.Text);
                                    int s22 = a22 + b2;
                                    Barcode = s22.ToString();


                                }

                            }
                            catch
                            {
                                int a3 = Convert.ToInt32(textIDCategory.Text);
                                b2 = 1000000000;
                                int s3 = a3 + b2;
                                Barcode = s3.ToString();
                            }


                            textBarcode.Text = Barcode;


                            //=============== تعديل الباركود فى جدول الاصناف ===============
                            sqlCommand1.CommandText = "update Category set  Barcode ='" + textBarcode.Text + "' where ID='" + textIDCategory.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            // إضافة البيانات فى جدول النقل
                            sqlCommand1.CommandText = "insert into Transport (Date,Category,Quantity,Part,FromStorage,ToStorage)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorysKataey.Text + "','" + textTotalStogeKataey2.Text + "','" + textBox2.Text + "','" + combStorageKatey1.Text + "','" + combStorageKatey2.Text + "')";
                            sqlCommand1.ExecuteNonQuery();




                        }
                        else
                        {
                            try
                            {
                                //تعدل الصنف فى المخزن الجديد
                                sqlCommand1.CommandText = "update Category set  Quantity ='" + 0 + "',QuantityT ='" + 0 + "',Total = '" + textTotalStogeKataey2.Text + "',Value = '" + textPriceSheraa.Text + "' where  Category ='" + combCategorysKataey.Text + "' AND Storage ='" + combStorageKatey2.Text + "' ";
                                sqlCommand1.ExecuteNonQuery();
                                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");

                                //تعدل الصنف فى المخزن القديم
                                sqlCommand1.CommandText = "update Category set  Quantity ='" + 0 + "',QuantityT ='" + 0 + "',Total = '" + textTotalStogeKataey1.Text + "',Value = '" + txtPriceSheraKatey1.Text + "' where  Category ='" + combCategorysKataey.Text + "' AND Storage ='" + combStorageKatey1.Text + "' ";
                                sqlCommand1.ExecuteNonQuery();
                                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                            }
                            catch
                            {

                            }


                            // إضافة البيانات فى جدول النقل
                            sqlCommand1.CommandText = "insert into Transport (Date,Category,Quantity,Part,FromStorage,ToStorage)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combCategorysKataey.Text + "','" + textTotalKataey.Text + "','" + 0 + "','" + combStorageKatey1.Text + "','" + combStorageKatey2.Text + "')";
                            sqlCommand1.ExecuteNonQuery();
                        }

                        //=====================  إضافة حركة الصنف الجديده المخزن الصادر 
                        sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorysKataey.Text + "','" + combStorageKatey1.Text + "','" + combStorageKatey1.Text + "','" + combStorageKatey2.Text + "','" + textBox19.Text + "','" + textBox20.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox21.Text + "','" + 0 + "','" + textTotalKataey.Text + "','" + textTotalKataey.Text + "','" + textTotalStogeKataey1.Text + "','" + textBox55.Text + "')";
                        sqlCommand1.ExecuteNonQuery();

                        //=====================  إضافة حركة الصنف الجديده المخزن الوارد 
                        sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + combCategorysKataey.Text + "','" + combStorageKatey2.Text + "','" + combStorageKatey1.Text + "','" + combStorageKatey2.Text + "','" + textBox19.Text + "','" + textBox20.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox22.Text + "','" + textTotalKataey.Text + "','" + 0 + "','" + textTotalKataey.Text + "','" + textTotalStogeKataey2.Text + "','" + textBox55.Text + "')";
                        sqlCommand1.ExecuteNonQuery();


                        combCategorys.Focus();

                        //**********************************


                        getdataDay();


                    }
                    else
                    {
                     //   MessageBox.Show("   الكمية الموجودة لا تكفى    ", "  المخزن ");
                    }
                }
            }
        }

        private void combStorageKatey2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCategoryFromStorages();
        }

        private void combStorageKatey1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCategoryFromStorages();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = combStorageKatey1.Text;
            string b = combStorageKatey2.Text;

            combStorageKatey2.Text = a;
            combStorageKatey1.Text = b;

        }
    }
}
