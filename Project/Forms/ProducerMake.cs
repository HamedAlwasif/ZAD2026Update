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
    public partial class ProducerMake : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        int i = 0;

        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        string SystemPriceShera = AppSetting.PriceSheraaAcount;
        string PriceSheraOld = "0";
        string PriceSheraNew = "0";
        string PriceShera = "0";
        string PriceGomla = "0";
        string PriceMostahlek = "0";
        string ValueTotalMoney = "0";

        //---------------------
        string RasedBox = "";
        string MoveBoxID = "";
        string NumBill = "";
        string RseedBox = "";
        string IDCategory = "";
        string CategoryID = "";
        string Barcode = "";


        //-----------------------------
        string CategoryIDProd = "";

        //-------------------------------
        DataTable dt1 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt18 = new DataTable();
        //---------------------------------
        private SqlDataReader red;
        private SqlDataReader rad;
        private SqlDataReader reed;
        private SqlDataReader read;
        private SqlDataReader reeeeed;
        private SqlDataReader rred;
        private SqlDataReader raaad;


        public ProducerMake()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;

            
        }

        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        public class Class_MaterialsBill
        {

            public string MaterialNum { get; set; }
            public string Date { get; set; }
            public string MaterialCategory { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
            public string Total { get; set; }



        }
        public class Class_CategorysMaterialsData
        {

            public string NumBill { get; set; }
            public string Category { get; set; }
            public string Date { get; set; }
            public string TotalCategorysMaterials { get; set; }
            public string CategoryQuantity { get; set; }
            public string CategoryCostPrice { get; set; }

            public string CategoryPrice { get; set; }
            public string State { get; set; }



        }
        public void GetRasedBox()
        {
            //---------  رصيد الخزنة
            try
            {
                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From BoxMove ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    RseedBox = "0";

                    double w = Convert.ToDouble(reed["wared"].ToString());
                    double s = Convert.ToDouble(reed["sader"].ToString());
                    double rr = w - s;
                    RseedBox = Math.Round(rr, 0).ToString();

                }
                reed.Close();

            }
            catch
            {

            }


        }

        public void GetMoveBoxID()
        {




            sqlCommand1.CommandText = "select * From BoxMove  Where ID =(select max(ID) from BoxMove) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["ID"].ToString());
                double aa = s + 1;
                MoveBoxID = aa.ToString();

            }
            red.Close();

            if (MoveBoxID == "")
            {
                MoveBoxID = "1";
            }
            else
            { }




        }
        public void GetNumBill()
        {


            sqlCommand1.CommandText = "select * From CategorysMaterialsData  Where NumBill =(select max(NumBill) from CategorysMaterialsData) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["NumBill"].ToString());
                double aa = s + 1;
                textNumBillMaterial.Text = aa.ToString();


            }
            red.Close();

            if (textNumBillMaterial.Text == "")
            {
                textNumBillMaterial.Text = "1";
            }
            else
            { }

            NumBill = textNumBillMaterial.Text;


        }

        public void GetBill()
        {

            ////textBox49.Text = "0";
            ////textBox50.Text = "0";


            //txtTotalBill.Text = "0";
            //TxtNumCategorey.Text = "0";
            //txtRemaningOld.Text = "0";
            ////   textBox10.Text = "0";
            //txtDic.Text = "0";
            ////   textBox13.Text = "0";
            ////  txtRemaningOld1.Text = "0";
            //txtMosadad.Text = "0";
            //txtRemainingNow.Text = "0";
            ////  textBox29.Text = "";

            //comClient.Text = "";

            //sqlCommand1.CommandText = "select * from BillingData1 where NumBillBillingData = '" + textBillingDataNumBill.Text + "' ";
            //read = sqlCommand1.ExecuteReader();
            //while (read.Read())
            //{
            //    textBillingData1NumBill.Text = read["NumBill"].ToString();
            //    comClient.Text = read["Name"].ToString();
            //    textClientName.Text = read["Name"].ToString();
            //    textClintID.Text = read["ClientID"].ToString();
            //    txtTotalBill.Text = read["TotalBill"].ToString();
            //    TxtNumCategorey.Text = read["NumberCategory"].ToString();
            //    txtRemaningOld.Text = read["PreviousBalance"].ToString();
            //    //  textBox10.Text = read["Total"].ToString();
            //    txtDic.Text = read["Discount"].ToString();



            //    txtMosadad.Text = read["Paid"].ToString();
            //    txtRemainingNow.Text = read["Remaining"].ToString();

            //    dateTimePicker1.Text = read["Date"].ToString();

            //    //  textBox17.Text = read["Move"].ToString();

            //}
            //read.Close();

            //sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "'";
            //read = sqlCommand1.ExecuteReader();
            //while (read.Read())
            //{
            //    MoveBoxID = read["ID"].ToString();

            //}
            //read.Close();
            //// ايجاد الاصناف فى الفاتورة

            //try
            //{


            //    // ايجاد الاصناف فى الفاتورة

            //    //------------------------------------
            //    DataTable dt11 = new DataTable();
            //    dt11.Clear();
            //    SqlDataAdapter da11 = new SqlDataAdapter("select * from Billing1 where NumBill = '" + textBillingData1NumBill.Text + "'  ", cn);
            //    da11.Fill(dt11);
            //    this.dataGridView2.DataSource = dt11;
            //}
            //catch
            //{ }

            ////------------------- ترقيم الداتا جريد
            //int rowNumber = 1;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    if (row.IsNewRow) continue;
            //    row.HeaderCell.Value = "" + rowNumber + "";
            //    rowNumber = rowNumber + 1;


            //}
            //dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);




            //sqlCommand1.CommandText = "select * from BillingData where NumBill = '" + textBillingDataNumBill.Text + "' ";
            //reaad = sqlCommand1.ExecuteReader();
            //while (reaad.Read())
            //{

            //    FormName = reaad["Move"].ToString();
            //    textUser.Text = reaad["NamePrint"].ToString();


            //}
            //reaad.Close();


        }
        private void ProducerMake_Load(object sender, EventArgs e)
        {

            //GetMoveBoxID();

            //----------------- ايجاد المخزن --------------------

            //SqlDataAdapter Da11;
            //DataTable Dt11 = new DataTable();
            //Da11 = new SqlDataAdapter("select Storage from Storage", cn);
            //Da11.Fill(Dt11);
            //comStorageMaterials.DataSource = Dt11;
            //comStorageMaterials.DisplayMember = "Storage";

            SqlDataAdapter Da111;
            DataTable Dt111 = new DataTable();
            Da111 = new SqlDataAdapter("select Storage from Storage", cn);
            Da111.Fill(Dt111);
            comStorageProduct.DataSource = Dt111;
            comStorageProduct.DisplayMember = "Storage";

            //-----------------   ايجاد الاصناف --------------------

            SqlDataAdapter Da21;
            DataTable Dt21 = new DataTable();
            Da21 = new SqlDataAdapter("select Category from Category Where Storage = '" + comStorageProduct.Text + "'", cn);
            Da21.Fill(Dt21);
            comProduct.DataSource = Dt21;
            comProduct.DisplayMember = "Category";

            comProduct.Text = "";
            //-----------------   ايجاد الخامات --------------------

            SqlDataAdapter Da211;
            DataTable Dt211 = new DataTable();
            Da211 = new SqlDataAdapter("select MaterialsName from Materials", cn);
            Da211.Fill(Dt211);
            comMaterials.DataSource = Dt211;
            comMaterials.DisplayMember = "MaterialsName";

            //-----------------------   إيجاد رصيد المخزن --------------------

            sqlCommand1.CommandText = "select * From TreasuryRemaning  Where ID = '" + 1 + "' ";
            rred = sqlCommand1.ExecuteReader();
            while (rred.Read())
            {

                RasedBox = rred["RemaningTreasury"].ToString();
            }
            rred.Close();



            



        }
        private void AddProductOld()
        {
            //// حساب سعر الكميه المطلوبه
            //try
            //{
            //    double nn = Convert.ToDouble(textQuantetyShera.Text);
            //    double dd = Convert.ToDouble(textPriceSheraa.Text);
            //    // double mm = Convert.ToDouble(textBox59.Text);
            //    double rr = nn * dd;
            //    txtTotalProduct.Text = rr.ToString();

            //    txtTotalProduct.Text = Math.Round(double.Parse(txtTotalProduct.Text), 2).ToString();

            //}

            //catch (FormatException)
            //{
            //    MessageBox.Show("يجب إدخال الكميه المطلوبه", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


            // جمع الكميه من الكميه الكليه

            double nr = Convert.ToDouble(txtQuentety.Text);
            double dr = Convert.ToDouble(textTotalQuantetyProd.Text);
            double rd = nr + dr;
            textTotalQuantetyProd.Text = rd.ToString();

           

            //----- ايجاد الكمية مقسومة على الوحدة
            double a = Convert.ToDouble(textTotalQuantetyProd.Text);  // الكميه الاجمالية بالقطع
            double b = Convert.ToDouble(textUnitProd.Text);   // الوحدة
            double c = a / b;
            textQuantetyKPord.Text = c.ToString();  // الاجمالى بالقطعه

            //--------- حساب اجمالى القطع الجزئى
            double aa = Convert.ToDouble(textTotalQuantetyProd.Text);
            double bb = Convert.ToDouble(textQuantetyKPord.Text);
            double cc = Convert.ToDouble(textUnitProd.Text);
            double d = aa - (bb * cc);
            textQuntetyTagzeaProd.Text = d.ToString();



            //------------ حساب سعر الشراء للموجود فى المخزن -------
            //if (SystemPriceShera == "السعر الجديد")
            //{

            //    PriceSheraNew = PriceShera;

            //}
            //else if (SystemPriceShera == "السعر القديم")
            //{
            //    PriceSheraNew = PriceSheraOld;
            //}
            //else if (SystemPriceShera == "متوسط السعر")
            //{
            //    double a = Convert.ToDouble(PriceShera);  // الكميه ك
            //    double b = Convert.ToDouble(PriceSheraOld);   // الوحدة
            //    double av = (a + b) / 2;

            //    PriceSheraNew = av.ToString();
            //}
            //else
            //{
            //    PriceSheraNew = PriceShera;
            //}

            try
            {
                sqlCommand1.CommandText = "update Category set  Quantity ='" + textQuantetyKPord.Text + "',QuantityT ='" + textQuntetyTagzeaProd.Text + "',Total = '" + textTotalQuantetyProd.Text + "',Price = '" + textPriceProd.Text + "',PriceGomla = '" + textPriceGomla.Text + "',PriceMostahlek = '" + txtPriceKata.Text + "',Value = '" + ValueTotalMoney + "' where  Category ='" + comProduct.Text + "' AND Storage ='" + comStorageProduct.Text + "' ";

                sqlCommand1.ExecuteNonQuery();
                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            try
            {
                //=================إضافة الأسعار الشراء الجمله والمستهلك  
                sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceMostahlek,Faction)values ('" + IDCategory + "','" + comProduct.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textPriceProd.Text + "','" + textPriceGomla.Text + "','" + txtPriceKata.Text + "','" + comFaction.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + textPriceProd.Text + "',PriceGomla = '" + textPriceGomla.Text + "',PriceMostahlek = '" + txtPriceKata.Text + "',Faction= '" + comFaction.Text + "' where  Category ='" + comProduct.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
            }



            //===================== إضافة حركة الصنف الجديده 
            sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + comProduct.Text + "','" + comStorageProduct.Text + "','" + FormName + "','" + comStorageProduct.Text + "','" + FormName + "','" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtQuentety.Text + "','" + 0 + "','" + txtQuentety.Text + "','" + textTotalQuantetyProd.Text + "','" + UserName + "')";
            sqlCommand1.ExecuteNonQuery();

        }

        private void AddProductNew()
        {
            


            textTotalQuantetyProd.Text = txtQuentety.Text; //الاجمالى يساوى العدد المصنع بالقطعه

            //----- ايجاد الكمية مقسومة على الوحدة
            double a = Convert.ToDouble(textTotalQuantetyProd.Text);  // الكميه الاجمالية بالقطع
            double b = Convert.ToDouble(textUnitProd.Text);   // الوحدة
            double c = a / b;
            textQuantetyKPord.Text = c.ToString();  // الاجمالى بالقطعه

            //--------- حساب اجمالى القطع الجزئى
            double aa = Convert.ToDouble(textTotalQuantetyProd.Text);
            double bb = Convert.ToDouble(textQuantetyKPord.Text);
            double cc = Convert.ToDouble(textUnitProd.Text);
            double d = aa - (bb * cc);
            textQuntetyTagzeaProd.Text = d.ToString();



            //----------------------- اضافة الصنف فى الجدول  -------

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] byteImage = ms.ToArray();
            sqlCommand1.CommandText = "insert into Category (Category,Storage,Date,Quantity,QuantityT,Unity,Faction,Total,Price,PriceGomla,PriceMostahlek,Near,Available,Image)values (@Category,@Storage,@Date,@Quantity,@QuantityT,@Unity,@Faction,@Total,@Price,@PriceGomla,@PriceMostahlek,@Near,@Available,@Image)";
            sqlCommand1.Parameters.Add("@Category", SqlDbType.VarChar).Value = comProduct.Text;
            sqlCommand1.Parameters.Add("@Storage", SqlDbType.VarChar).Value = comStorageProduct.Text;
            sqlCommand1.Parameters.Add("@Date", SqlDbType.VarChar).Value = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            sqlCommand1.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = textQuantetyKPord.Text;
            sqlCommand1.Parameters.Add("@QuantityT", SqlDbType.VarChar).Value = textQuntetyTagzeaProd.Text;
            sqlCommand1.Parameters.Add("@Unity", SqlDbType.VarChar).Value = textUnitProd.Text;
            sqlCommand1.Parameters.Add("@Faction", SqlDbType.VarChar).Value = comFaction.Text;
            sqlCommand1.Parameters.Add("@Total", SqlDbType.VarChar).Value = textTotalQuantetyProd.Text;
            sqlCommand1.Parameters.Add("@Price", SqlDbType.VarChar).Value = textPriceProd.Text;
            sqlCommand1.Parameters.Add("@PriceGomla", SqlDbType.VarChar).Value = textPriceGomla.Text;
            sqlCommand1.Parameters.Add("@PriceMostahlek", SqlDbType.VarChar).Value = txtPriceKata.Text;
            //  sqlCommand1.Parameters.Add("@Value", SqlDbType.VarChar).Value = "0";
            sqlCommand1.Parameters.Add("@Near", SqlDbType.VarChar).Value = "0";
            sqlCommand1.Parameters.Add("@Available", SqlDbType.VarChar).Value = "نعم";
            //  sqlCommand1.Parameters.Add("@Emwared", SqlDbType.VarChar).Value = comboBox6.Text;
            sqlCommand1.Parameters.Add("@Image", SqlDbType.Image).Value = byteImage;
            sqlCommand1.ExecuteNonQuery();
            sqlCommand1.Parameters.Clear();


            // ---------------------    ايجاد الكود الصنف ------------
            sqlCommand1.CommandText = "select * from Category where Category = '" + comProduct.Text + "' ";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                IDCategory = read["ID"].ToString();
            }
            read.Close();

            //--------------حساب الباركود واضافة فى الجدول الاصناف -------------
            int ad = Convert.ToInt32(IDCategory);
            int bs = 1000000000;
            int s = ad + bs;
            Barcode = s.ToString();
            //=============== تعديل الباركود فى جدول الاصناف ===============
            sqlCommand1.CommandText = "update Category set  Barcode ='" + Barcode + "' where ID='" + IDCategory + "' ";
            sqlCommand1.ExecuteNonQuery();


            //------------------------ اضافة الاسعار 
           
                try
                {
                    //=================إضافة الأسعار الشراء الجمله والمستهلك  
                    sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceMostahlek,Faction)values ('" + IDCategory + "','" + comProduct.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textPriceProd.Text + "','" + textPriceGomla.Text + "','" + txtPriceKata.Text + "','" + comFaction.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {
                    sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + textPriceProd.Text + "',PriceGomla = '" + textPriceGomla.Text + "',PriceMostahlek = '" + txtPriceKata.Text + "',Faction= '" + comFaction.Text + "' where  Category ='" + comProduct.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();
                    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                }
           


            //===================== إضافة حركة الصنف الجديده 
            sqlCommand1.CommandText = "insert into CategoryMove2 (Category,Storage,CategoryFrom,CategoryTo,MoveBill,IDBill,Date,Move,Wared,Sader,Quantity,Total,Users)values ('" + comProduct.Text + "','" + comStorageProduct.Text + "','" + FormName + "','" + comStorageProduct.Text + "','" + FormName + "','" + textBillingDataNumBill.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + txtQuentety.Text + "','" + 0 + "','" + txtQuentety.Text + "','" + textTotalQuantetyProd.Text + "','" + UserName + "')";
            sqlCommand1.ExecuteNonQuery();



        }
        private void AddProduct()
        {
                       
           
        
        }
        private void butAddMaterials_Click(object sender, EventArgs e)
        {
            if (textBillingDataNumBill.Text == "")
            {
                GetNumBill();


            }
            else
            { }

            if (textQuantetyKPord.Text == "") // -------- صنف  جديد 
            {
                AddProductNew();
            }
            else // --------- الصنف موجود من قبل
            {
                AddProductOld();
            }

            AddProduct();
        }

        private void combCategorys_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //- إيجاد الكميه الاول
                textQuantetyKPord.Text = "";
                //textUnit.Text = "";
                //comboBox7.Text = "";
                textTotalQuantetyProd.Text = "";
                CategoryID = "";
                PriceSheraOld = "0";

                sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' AND Storage ='" + combStorage.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    CategoryID = reed["ID"].ToString();
                    textBarcode.Text = reed["Barcode"].ToString();
                    textQuantetyKPord.Text = reed["Quantity"].ToString();
                    textQuntetyTagzeaProd.Text = reed["QuantityT"].ToString();
                    PriceSheraOld = reed["Price"].ToString();
                    //textUnit.Text = reed["Unity"].ToString();
                    //comboBox7.Text = reed["Faction"].ToString();
                    textTotalQuantetyProd.Text = reed["Total"].ToString();



                }

                reed.Close();

                //اظهار الوحدة والفئة اذا كان صنف جديد
                //if (textUnit.Text == "")
                //{
                //    textUnit.Visible = true;
                //    label22.Visible = true;
                //    comboBox7.Visible = true;
                //    label23.Visible = true;

                //    if (Kataey == "1")
                //    {
                //        textUnit.Text = "1";
                //        comboBox7.Text = "ق";

                //        textUnit.Visible = false;
                //        comboBox7.Visible = false;
                //        label22.Visible = false;
                //        label23.Visible = false;
                //    }
                //    else
                //    { }
                //}
                //else
                //{
                //    textUnit.Visible = false;
                //    label22.Visible = false;
                //    comboBox7.Visible = false;
                //    label23.Visible = false;
                //}


                textQuantetyShera.Text = "";
                textPriceSheraa.Text = "0";
                txtTotalProduct.Text = "";
                //textPriceGomla.Text = "0";
                textPriceKatey.Text = "0";
                //textBox36.Text = "";
                //textBox39.Text = "";

                //textBox60.Text = "0";
                //textBox59.Text = "0";

                //textBox45.Text = "0";
                //textBox46.Text = "0";
                //textBox47.Text = "0";

                // -------------                


                groupBox5.Text = combCategorys.Text;



                try
                {
                    sqlCommand1.CommandText = "select * from CategoryPrice where Category Like'" + combCategorys.Text + "'  ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        textPriceSheraa.Text = reed["PriceShraa"].ToString();
                        //textPriceGomla.Text = reed["PriceGomla"].ToString();
                        textPriceKatey.Text = reed["PriceMostahlek"].ToString();
                        //textBox35.Text = reed["Faction"].ToString();
                        //textBox36.Text = reed["PriceGomla"].ToString();
                        //textBox39.Text = reed["PriceMostahlek"].ToString();

                    }
                    reed.Close();

                }
                catch
                {

                }

                //textBox37.Text = ComTypeCategorey.Text;

                //---------------- ايجاد اخر سعر ---------
                //if (textMoveBill.Text == "مردودات مبيعات") //----------- فاتورة مردودات
                //{


                //    try
                //    {
                //        DataTable dt = new DataTable();
                //        dt.Clear();
                //        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing where Category ='" + combCategorys.Text + "' AND ClientName ='" + textClientName.Text + "'", cn);
                //        da.Fill(dt);
                //        this.dataGridLastPrice.DataSource = dt;
                //        this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                //        this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                //        this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                //        this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                //        this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                //        this.dataGridLastPrice.Columns[0].Width = 60;
                //        this.dataGridLastPrice.Columns[1].Width = 80;
                //        this.dataGridLastPrice.Columns[2].Width = 50;
                //        this.dataGridLastPrice.Columns[3].Width = 50;
                //        this.dataGridLastPrice.Columns[4].Width = 50;


                //        //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                //        //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";



                //        //-------------- لترتيب الجدول حسب عمود
                //        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                //    }
                //    catch
                //    {

                //    }
                //}
                //else // -------------- فاتورة مشتريات
                //{


                //    try
                //    {
                //        DataTable dt = new DataTable();
                //        dt.Clear();
                //        SqlDataAdapter da = new SqlDataAdapter("select NumBill,Date,Quantity,Type,Price from Billing1 where Category ='" + combCategorys.Text + "' AND ClientName ='" + textClientName.Text + "'", cn);
                //        da.Fill(dt);
                //        this.dataGridLastPrice.DataSource = dt;
                //        this.dataGridLastPrice.Columns[0].HeaderText = "الكود";
                //        this.dataGridLastPrice.Columns[1].HeaderText = "التاريخ";
                //        this.dataGridLastPrice.Columns[2].HeaderText = "ك";
                //        this.dataGridLastPrice.Columns[3].HeaderText = "الوحدة";
                //        this.dataGridLastPrice.Columns[4].HeaderText = "السعر";

                //        this.dataGridLastPrice.Columns[0].Width = 60;
                //        this.dataGridLastPrice.Columns[1].Width = 80;
                //        this.dataGridLastPrice.Columns[2].Width = 50;
                //        this.dataGridLastPrice.Columns[3].Width = 50;
                //        this.dataGridLastPrice.Columns[4].Width = 50;


                //        //---------- لوضع عملة البلد على حسب عملة الجهاز ----------------
                //        //    this.dataGridLastPrice.Columns[4].DefaultCellStyle.Format = "C";




                //        dataGridLastPrice.Sort(dataGridLastPrice.Columns[1], ListSortDirection.Ascending);

                //    }
                //    catch
                //    {

                //    }
                //}
            }
            catch
            {

            }
        }

        private void comStorageProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-----------------   ايجاد الاصناف --------------------

            SqlDataAdapter Da21;
            DataTable Dt21 = new DataTable();
            Da21 = new SqlDataAdapter("select Category from Category Where Storage = '" + comStorageProduct.Text + "'", cn);
            Da21.Fill(Dt21);
            comProduct.DataSource = Dt21;
            comProduct.DisplayMember = "Category";

        }

        private void comStorageMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////-----------------   ايجاد الخامات --------------------

            //SqlDataAdapter Da211;
            //DataTable Dt211 = new DataTable();
            //Da211 = new SqlDataAdapter("select Category from Category Where Storage = '" + comStorageMaterials.Text + "'", cn);
            //Da211.Fill(Dt211);
            //comMaterials.DataSource = Dt211;
            //comMaterials.DisplayMember = "Category";
        }

        private void butAddCategorey_Click(object sender, EventArgs e)
        {
            if (textBarcodeProd.Text == "")
            {
                MessageBox.Show("   من فضلك قم باختيار اسم المنتج النهائى    ", "  اسم المنتج ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comProduct.Focus();
            }
            else
            {
                double Qmawggod = Convert.ToDouble(textQuntMawgod.Text);
                double Qmatlob = Convert.ToDouble(textQuntityMaterial.Text);
                if (Qmatlob > Qmawggod)
                {
                    MessageBox.Show("  الكمية المطلوبة اكبر من الموجود فى المخزن   ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textQuntityMaterial.Focus();
                }
                else
                {


                    //*********  حساب قيمة الاجمالى 
                    double nnnn = Convert.ToDouble(textQuntityMaterial.Text);
                    double dddd = Convert.ToDouble(textPriceMaterial.Text);
                    double rrrr = nnnn * dddd;
                    txtMaterialTotal.Text = rrrr.ToString();
                    txtMaterialTotal.Text = Math.Round(double.Parse(txtMaterialTotal.Text), 2).ToString();

                    if (textNumBillMaterial.Text == "")
                    {
                        GetNumBill();


                    }
                    else
                    { }



                    //===================== حساب رقم الخامة
                    string NumCategorey = "";
                    double nnn = Convert.ToDouble(textNumMaterial.Text);
                    double rrr = nnn + 1;

                    NumCategorey = rrr.ToString();

                    //=================إضافة الخامة    
                    sqlCommand1.CommandText = "insert into CategorysMaterials (NumBill,MaterialNum,CategoryID,Category,Date,MaterialCategory,Quantity,Faction,Price,Total)values ('" + textNumBillMaterial.Text + "','" + NumCategorey + "','" + textBarcodeProd.Text + "','" + comProduct.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + comMaterials.Text + "','" + textQuntityMaterial.Text + "','" + 1 + "','" + textPriceMaterial.Text + "','" + txtMaterialTotal.Text + "')";
                    sqlCommand1.ExecuteNonQuery();

                    //===================== ايجاد الاصناف فى الفاتورة
                    dt1.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select MaterialNum,Date,MaterialCategory,Quantity,Price,Total from CategorysMaterials where NumBill = '" + textNumBillMaterial.Text + "' ", cn);

                    da11.Fill(dt1);

                    this.dataGridView5.DataSource = dt1;

                    //===================== حساب إجمالى الفاتورة عدد الاصناف
                    int rowNumber1 = 0;

                    double sum1 = 0;
                    for (int s = 0; s < dataGridView5.RowCount - 1; ++s)
                    {
                        sum1 += Convert.ToDouble(dataGridView5.Rows[s].Cells[5].Value);
                        rowNumber1 = rowNumber1 + 1;

                    }

                    txtTotalMaterial.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
                    textNumMaterial.Text = rowNumber1.ToString();


                    try
                    {
                        //=================إضافة البيانات   
                        sqlCommand1.CommandText = "insert into CategorysMaterialsData (NumBill,CategoryID,Category,Date,TotalCategorysMaterials,CategoryQuantity,CategoryCostPrice,CategoryPrice,State)values ('" + textNumBillMaterial.Text + "','" + textBarcodeProd.Text + "','" + comProduct.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + txtTotalMaterial.Text + "','" + txtQuentety.Text + "','" + textPriceProd.Text + "','" + txtPriceKata.Text + "','" + txtState.Text + "')";
                        sqlCommand1.ExecuteNonQuery();
                    }
                    catch
                    {
                        sqlCommand1.CommandText = "update CategorysMaterialsData set  TotalCategorysMaterials ='" + txtTotalMaterial.Text + "',CategoryQuantity = '" + txtQuentety.Text + "',CategoryCostPrice = '" + textPriceProd.Text + "',CategoryPrice = '" + txtPriceKata.Text + "',State= '" + txtState.Text + "' where  NumBill ='" + textNumBillMaterial.Text + "' ";
                        sqlCommand1.ExecuteNonQuery();
                        // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                    }

                    //*********  حساب الكمية بعد الخصم والتعديل فى جدول الخامات 
                    double a1 = Convert.ToDouble(textQuntMawgod.Text);
                    double b1 = Convert.ToDouble(textQuntityMaterial.Text);
                    double s1 = a1 - b1;
                   
                    textQuntMawgod.Text = Math.Round(double.Parse(s1.ToString()), 2).ToString();


                    sqlCommand1.CommandText = "update Materials set  Qunt = '" + textQuntMawgod.Text + "' where  ID ='" + textBarcode.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                }
            }

        }

        private void comProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //- إيجاد الكميه الاول
            textQuantetyKPord.Text = "";
            textQuntetyTagzeaProd.Text = "";
            textUnitProd.Text = "";
            txtSheraaPrice.Text = "0";
            textTotalQuantetyProd.Text = "";

            CategoryIDProd = "";
            textBarcodeProd.Text = "";

            try
            {

                

                sqlCommand1.CommandText = "select * from Category where Category ='" + comProduct.Text + "' AND Storage ='" + comStorageProduct.Text + "'   ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {

                    CategoryIDProd = reed["ID"].ToString();
                    textBarcodeProd.Text = reed["Barcode"].ToString();
                    textQuantetyKPord.Text = reed["Quantity"].ToString();
                    textQuntetyTagzeaProd.Text = reed["QuantityT"].ToString();
                    // PriceSheraOld = reed["Price"].ToString();
                    textUnitProd.Text = reed["Unity"].ToString();
                    comFaction.Text = reed["Faction"].ToString();
                    //comboBox7.Text = reed["Faction"].ToString();
                    textTotalQuantetyProd.Text = reed["Total"].ToString();



                }

                reed.Close();


                //textQuantetyShera.Text = "";
                textPriceProd.Text = "0";
                //txtTotalProduct.Text = "";
                //textPriceKatey.Text = "0";



                try
                {
                    sqlCommand1.CommandText = "select * from CategoryPrice where Category Like'" + comProduct.Text + "'  ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        txtSheraaPrice.Text = reed["PriceShraa"].ToString();


                    }
                    reed.Close();

                }
                catch
                {

                }


            }
            catch
            {

            }
        }

        private void butQuntAndPrice_Click(object sender, EventArgs e)
        {
            //if (grpProductQuntety.Enabled == true)
            //{
            //    grpProductQuntety.Enabled = false;

            //}
            //else
            //{
            //    grpProductQuntety.Enabled = true;
            //}

            //if (txtQuentety.Text == "")
            //{
            //    MessageBox.Show("   يجب ادخال الكمية الاجمالية المصنعه    ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtQuentety.Focus();
            //}
            //else
            //{
            //    //*********  حساب قيمة التكلفة 
            //    double a = Convert.ToDouble(txtTotalMaterial.Text);
            //    double b = Convert.ToDouble(txtQuentety.Text);
            //    double rrrr = a / b;
            //    textPriceProd.Text = rrrr.ToString();
            //    textPriceProd.Text = Math.Round(double.Parse(textPriceProd.Text), 2).ToString();
            //}

        }

        private void radbutFinshOld_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radbutFinshNew_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void butProductsMake_Click(object sender, EventArgs e)
        {
            string moveMake = "قيد التصنيع";

            if (dataGridView4.Visible == true)
            {
                //panel14.Visible = false;
                //panel10.Visible = false;
                panelBillDay.Visible = false;
            }
            else
            {
                //panel14.Visible = false;
                // panel10.Visible = false;
                panelBillDay.Visible = true;


                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from CategorysMaterialsData where  State like '" + moveMake + "' ", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;

                try
                {

                    textCountProduc.Text = "0";

                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
                        sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);


                        //----------- عدد الاصناف 
                        double a = Convert.ToDouble(textCountProduc.Text);
                        double rrrr = a +1;
                        textCountProduc.Text = rrrr.ToString();

                    }
                    textTotalMaterial.Text = sum.ToString();
                    textTotalQuentety.Text = sum1.ToString();

                }
                catch
                { }
            }
        }

        private void butProductsMakeFinsh_Click(object sender, EventArgs e)
        {
            string moveMake = "تم التصنيع";

            if (dataGridView4.Visible == true)
            {
                //panel14.Visible = false;
                //panel10.Visible = false;
                panelBillDay.Visible = false;
            }
            else
            {
                //panel14.Visible = false;
                // panel10.Visible = false;
                panelBillDay.Visible = true;


                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select * from CategorysMaterialsData where  State like '" + moveMake + "' ", cn);
                da21.Fill(dt12);
                this.dataGridView4.DataSource = dt12;

                try
                {
                    textCountProduc.Text = "0";
                    double sum = 0;
                    double sum1 = 0;
                    for (int i = 0; i < dataGridView4.RowCount; ++i)
                    {
                        sum += Convert.ToDouble(dataGridView4.Rows[i].Cells[3].Value);
                        sum1 += Convert.ToDouble(dataGridView4.Rows[i].Cells[4].Value);

                        //----------- عدد الاصناف 
                        double a = Convert.ToDouble(textCountProduc.Text);
                        double rrrr = a + 1;
                        textCountProduc.Text = rrrr.ToString();

                    }
                    textTotalMaterial.Text = sum.ToString();
                    textTotalQuentety.Text = sum1.ToString();

                }
                catch
                { }
        }
        }

        private void butFinshNew_Click(object sender, EventArgs e)
        {
            if (comProduct.Text == "")
            {
                MessageBox.Show("   من فضلك قم باختيار اسم المنتج النهائى    ", "  اسم المنتج ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comProduct.Focus();
            }
            else
            {



                if (txtQuentety.Text == "")
                {
                    MessageBox.Show("      من فضلك أدخل الكمية            ", "  خطأ  ");
                    txtQuentety.Focus();
                }
                else
                {

                    if (textPriceGomla.Text == "")
                    {
                        MessageBox.Show("       من فضلك ادخل سعر الجملة او اكتبة صفر           ", "  خطأ  ");
                        textPriceGomla.Focus();
                    }
                    else
                    {
                        if (txtPriceKata.Text == "")
                        {
                            MessageBox.Show("       من فضلك أدخل سعر بيع القطعة            ", "  خطأ  ");

                            txtPriceKata.Focus();
                        }
                        else
                        {
                            if (textUnitProd.Text == "")
                            {
                                MessageBox.Show("         من فضلك أدخل وحدة الصنف        ", "  خطأ  ");
                                textUnitProd.Focus();
                            }
                            else
                            {
                                if (comFaction.Text == "")
                                {
                                    MessageBox.Show("         من فضلك أدخل فئة الصنف        ", "  خطأ  ");
                                    comFaction.Focus();
                                }
                                else
                                {
                                    DialogResult dialogResult = MessageBox.Show(" فى حالة انهاء التصنيع لن تتمكن من اضافات خامات لهذا الصنف مرة اخرى" + Environment.NewLine + Environment.NewLine + "هل تريد انهاء التصنيع ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {

                                        if (textQuantetyKPord.Text == "") // -------- صنف  جديد 
                                        {
                                            AddProductNew();
                                            txtState.Text = "تم التصنيع";

                                            try
                                            {
                                                //=================إضافة البيانات   
                                                sqlCommand1.CommandText = "insert into CategorysMaterialsData (NumBill,CategoryID,Category,Date,TotalCategorysMaterials,CategoryQuantity,CategoryCostPrice,CategoryPrice,State)values ('" + textNumBillMaterial.Text + "','" + textBarcodeProd.Text + "','" + comProduct.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + txtTotalMaterial.Text + "','" + txtQuentety.Text + "','" + textPriceProd.Text + "','" + txtPriceKata.Text + "','" + txtState.Text + "')";
                                                sqlCommand1.ExecuteNonQuery();
                                            }
                                            catch
                                            {
                                                sqlCommand1.CommandText = "update CategorysMaterialsData set  TotalCategorysMaterials ='" + txtTotalMaterial.Text + "',CategoryQuantity = '" + txtQuentety.Text + "',CategoryCostPrice = '" + textPriceProd.Text + "',CategoryPrice = '" + txtPriceKata.Text + "',State= '" + txtState.Text + "' where  NumBill ='" + textNumBillMaterial.Text + "' ";
                                                sqlCommand1.ExecuteNonQuery();
                                                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                                            }
                                        }
                                        else // --------- الصنف موجود من قبل
                                        {
                                            AddProductOld();
                                            txtState.Text = "تم التصنيع";

                                            try
                                            {
                                                //=================إضافة البيانات   
                                                sqlCommand1.CommandText = "insert into CategorysMaterialsData (NumBill,CategoryID,Category,Date,TotalCategorysMaterials,CategoryQuantity,CategoryCostPrice,CategoryPrice,State)values ('" + textNumBillMaterial.Text + "','" + textBarcodeProd.Text + "','" + comProduct.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + txtTotalMaterial.Text + "','" + txtQuentety.Text + "','" + textPriceProd.Text + "','" + txtPriceKata.Text + "','" + txtState.Text + "')";
                                                sqlCommand1.ExecuteNonQuery();
                                            }
                                            catch
                                            {
                                                sqlCommand1.CommandText = "update CategorysMaterialsData set  TotalCategorysMaterials ='" + txtTotalMaterial.Text + "',CategoryQuantity = '" + txtQuentety.Text + "',CategoryCostPrice = '" + textPriceProd.Text + "',CategoryPrice = '" + txtPriceKata.Text + "',State= '" + txtState.Text + "' where  NumBill ='" + textNumBillMaterial.Text + "' ";
                                                sqlCommand1.ExecuteNonQuery();
                                                // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                                            }
                                        }

                                        MessageBox.Show("   تم الانتهاء من تصنيع المنتج     ", "  تم التصنيع ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    }
                                }

                            }
                        }
                    }
                }
            }

            

        }

        private void comProduct_TextChanged(object sender, EventArgs e)
        {
            //- إيجاد الكميه الاول
            textQuantetyKPord.Text = "";
            textQuntetyTagzeaProd.Text = "";
            textUnitProd.Text = "";
            textTotalQuantetyProd.Text = "";

            CategoryIDProd = "";
            // PriceSheraOld = "0";
            textBarcodeProd.Text = "";
        }
        public void countTaklefa()
        {
            try
            {
                if (txtQuentety.Text == "0" || txtQuentety.Text == "")
                {
                    textPriceProd.Text = "0";
                }
                else
                {
                    //*********  حساب قيمة التكلفة 
                    double a = Convert.ToDouble(txtTotalMaterial.Text);
                    double b = Convert.ToDouble(txtQuentety.Text);
                    double rrrr = a / b;
                    textPriceProd.Text = rrrr.ToString();
                    textPriceProd.Text = Math.Round(double.Parse(textPriceProd.Text), 2).ToString();
                }
            }
            catch
            { }
        }
        private void txtQuentety_TextChanged(object sender, EventArgs e)
        {
            countTaklefa();
        }

        private void txtTotalMaterial_TextChanged(object sender, EventArgs e)
        {
            countTaklefa();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textNumBillMaterial.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();

          
            txtTotalMaterial.Text = "0";
            textNumMaterial.Text = "0";
            comProduct.Text = "";

            txtQuentety.Text = "0";

            textPriceProd.Text = "0";
            txtSheraaPrice.Text = "0";
            textPriceGomla.Text = "0";
            txtPriceKata.Text = "0";
            textBarcodeProd.Text = "";



            //===================== ايجاد الاصناف فى الفاتورة
            dt1.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select MaterialNum,Date,MaterialCategory,Quantity,Price,Total from CategorysMaterials where NumBill = '" + textNumBillMaterial.Text + "' ", cn);

            da11.Fill(dt1);

            this.dataGridView5.DataSource = dt1;

            //===================== حساب إجمالى الفاتورة عدد الاصناف
            int rowNumber1 = 0;

            double sum1 = 0;
            for (int s = 0; s < dataGridView5.RowCount - 1; ++s)
            {
                sum1 += Convert.ToDouble(dataGridView5.Rows[s].Cells[5].Value);
                rowNumber1 = rowNumber1 + 1;

            }

            txtTotalMaterial.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
            textNumMaterial.Text = rowNumber1.ToString();



            sqlCommand1.CommandText = "select * from CategorysMaterialsData where NumBill = '" + textNumBillMaterial.Text + "'";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                textBarcodeProd.Text = read["CategoryID"].ToString();
                comProduct.Text = read["Category"].ToString();

                dateTimePicker2.Text = read["Date"].ToString();
                txtTotalMaterial.Text = read["TotalCategorysMaterials"].ToString();
                txtQuentety.Text = read["CategoryQuantity"].ToString();
                textPriceProd.Text = read["CategoryCostPrice"].ToString();
                txtPriceKata.Text = read["CategoryPrice"].ToString();
                txtState.Text = read["State"].ToString();
                

            }
            read.Close();

            if(txtState.Text== "تم التصنيع")
            {
                butFinshNew.Enabled = false;
                butAddCategorey.Enabled = false;
                comProduct.Enabled = false;
            }
            else
            {
                butFinshNew.Enabled = true;
                butAddCategorey.Enabled = true;
                comProduct.Enabled = true;
            }

            sqlCommand1.CommandText = "select * from Category where Category ='" + comProduct.Text + "' AND Storage ='" + comStorageProduct.Text + "'   ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                CategoryIDProd = reed["ID"].ToString();
                textBarcodeProd.Text = reed["Barcode"].ToString();
                textQuantetyKPord.Text = reed["Quantity"].ToString();
                textQuntetyTagzeaProd.Text = reed["QuantityT"].ToString();
                // PriceSheraOld = reed["Price"].ToString();
                textUnitProd.Text = reed["Unity"].ToString();
                comFaction.Text = reed["Faction"].ToString();
                //comboBox7.Text = reed["Faction"].ToString();
                textTotalQuantetyProd.Text = reed["Total"].ToString();



            }

            reed.Close();

            //sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
            //read = sqlCommand1.ExecuteReader();
            //while (read.Read())
            //{
            //    MoveBoxID = read["ID"].ToString();



            //}
            //read.Close();
            ////}
            ////catch
            ////{

            ////}
        }

        private void comMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            textPriceMaterial.Text = "0";
            textQuntMawgod.Text = "0";

            txtDateExpiry.Text = "";
            textBarcode.Text = "";
            textQuntityMaterial.Text = "0";
            txtMaterialTotal.Text = "0";


            try
            {
                sqlCommand1.CommandText = "select * from Materials where MaterialsName Like'" + comMaterials.Text + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textPriceMaterial.Text = reed["Price"].ToString();
                    textQuntMawgod.Text = reed["Qunt"].ToString();

                    txtDateExpiry.Text = reed["DateExpiry"].ToString();
                    textBarcode.Text = reed["ID"].ToString();



                }
                reed.Close();

            }
            catch
            {

            }
        }

        private void ProducerMake_MouseClick(object sender, MouseEventArgs e)
        {
            panelBillDay.Visible = false;
        }
    }
}
