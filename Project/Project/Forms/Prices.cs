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
    public partial class Prices : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";

        string PriceGomla2 = "0";
        string PriceKataey2 = "0";
        string PriceShera2 = "0";
        string PriceGomlaAlgomla2 = "0";
        string PriceNesfAlgomla2 = "0";
        //---------------------------------
        private SqlDataReader red;

        ReportDataSource rs = new ReportDataSource();


        public Prices()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_PricesCategorey
        {

            public string Barcode { get; set; }
            public string Storage { get; set; }
            public string Category { get; set; }
            public string Faction { get; set; }
            public string Price { get; set; }
            public string PriceGomla { get; set; }
            public string PriceMostahlek { get; set; }


        }

        public class Class_PricesMoveDate
        {

            public string ID { get; set; }
            public string Date { get; set; }
            public string Move { get; set; }
            public string Ratio { get; set; }
            public string DecimalNumber { get; set; }
            public string Shera { get; set; }
            public string Gomla { get; set; }
            public string Kataee { get; set; }


        }
        public class Class_GetAllCategry
        {

            public string Barcode { get; set; }
            public string Category { get; set; }
            public string Storage { get; set; }
            public string Total { get; set; }
            public string PriceMostahlek { get; set; }


        }
        private void SearchCategory()
        {
            textPriceShera.Text = "0";
            textPriceGomla.Text = "0";
            textPriceKataey.Text = "0";
            textIDCategroy.Text = "";

            textPriceGomlaAlgomla.Text = "0";
            textPriceNesfGomla.Text = "0";

            groupBox1.Text = combCategorys.Text;

            //*********************
            try
            {
                sqlCommand1.CommandText = "select * from Category where Category ='" + combCategorys.Text + "' and Storage ='" + combStorage.Text + "' ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {

                    textIDCategroy.Text = red["ID"].ToString();
                    textTotalQuantity.Text = red["Total"].ToString();

                    //-------------------------
                    textPriceGomla.Text = red["PriceGomla"].ToString();
                    textPriceKataey.Text = red["PriceMostahlek"].ToString();
                    textPriceGomlaAlgomla.Text = red["PriceGomlaAlgomla"].ToString();
                    textPriceNesfGomla.Text = red["PriceNesfAlgomla"].ToString();
                    comboBox2.Text = red["Faction"].ToString();
                    textPriceShera.Text = red["Price"].ToString();

                    //-------------------------
                    PriceGomla2 = red["PriceGomla"].ToString();
                    PriceKataey2 = red["PriceMostahlek"].ToString();
                    //comboBox1= red["Faction"].ToString();
                  PriceShera2 = red["Price"].ToString();

                    PriceGomlaAlgomla2 = red["PriceGomla"].ToString();
                    PriceNesfAlgomla2 = red["PriceMostahlek"].ToString();


                }
                red.Close();
            }
            catch
            { }
        }
        private void butSearch_Click(object sender, EventArgs e)
        {
            SearchCategory();

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Category where  Category ='" + combCategorys.Text + "'  ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }

            textPriceShera.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //=================إضافة الأسعار الشراء الجمله والمستهلك  
                sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceMostahlek,Faction)values ('" + textIDCategroy.Text + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textPriceShera.Text + "','" + textPriceGomla.Text + "','" + textPriceKataey.Text + "','" + comboBox2.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + textPriceShera.Text + "',PriceGomla = '" + textPriceGomla.Text + "',PriceMostahlek = '" + textPriceKataey.Text + "',Faction= '" + comboBox2.Text + "' where ID ='" + textIDCategroy.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
            }



            //***************************
            // حساب القيمة
            double a1 = Convert.ToDouble(textPriceShera.Text);
            double b1 = Convert.ToDouble(textTotalQuantity.Text);
            double c = a1 * b1;
            textValue.Text = c.ToString();

            try
            {
                sqlCommand1.CommandText = "update Category set Price ='" + textPriceShera.Text + "' ,PriceGomla = '" + textPriceGomla.Text + "',PriceMostahlek = '" + textPriceKataey.Text + "',PriceGomlaAlgomla = '" + textPriceGomlaAlgomla.Text + "',PriceNesfAlgomla = '" + textPriceNesfGomla.Text + "', Value ='" + textValue.Text + "' where  ID='" + textIDCategroy.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                //  MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

            }
            catch
            {
                MessageBox.Show("يوجد خطأ", "Error");
            }

            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Category where  Category ='" + combCategorys.Text + "'  ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }

            //******************************

            combCategorys.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Category ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }

            textBox1.Text = (dataGridView1.RowCount - 1).ToString(); // عدد الاصناف
        }

        private void combCategorys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butSearch.Focus();

            }
        }

        private void GetAllCategry()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Category ", cn);
            da11.Fill(dt11);
            this.dataGridSearchCategory.DataSource = dt11;

        }
        private void Prices_Load(object sender, EventArgs e)
        {
            GetAllCategry();

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

            //-------------- حركة تغير الاسعار
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from PriceUpdateDate   ", cn);
            da11.Fill(dt11);
            this.dataGridView2.DataSource = dt11;
            this.dataGridView3.DataSource = dt11;

          

            //----------------- ايجاد المخزن --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Storage from Storage", cn);
                Da1.Fill(Dt1);
                combStorage.DataSource = Dt1;
                combStorage.DisplayMember = "Storage";
                comboBox1.DataSource = Dt1;
                comboBox1.DisplayMember = "Storage";
            }
            catch
            {

            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            //if (comClient.Text == "")
            //{
            //    MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
            //    comClient.Focus();
            //}
            //else
            //{
            //AppSetting.Total_Bill = textTotalBill.Text;


            

           
            AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");


            List<Class_PricesCategorey> BM = new List<Class_PricesCategorey>();
            BM.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Class_PricesCategorey BillDay = new Class_PricesCategorey
                {

                    Barcode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
                    Storage = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Category = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Faction = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    Price = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                    PriceGomla = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                    PriceMostahlek = dataGridView1.Rows[i].Cells[6].Value.ToString(),

                };

                BM.Add(BillDay);
            }
            rs.Name = "DataSet1";
            rs.Value = BM;

            Reports.Frm_PriceProducer rbm = new Reports.Frm_PriceProducer();

            if (radioAll.Checked == true)
            {
                AppSetting.TypePrice = "All";

                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
            }
            else if (radioSheraa.Checked == true)
            {
                AppSetting.TypePrice = "Sheraa";

                rbm.reportViewer2.LocalReport.DataSources.Clear();
                rbm.reportViewer2.LocalReport.DataSources.Add(rs);
            }
            else if (radioGomla.Checked == true)
            {
                AppSetting.TypePrice = "Gomla";
                rbm.reportViewer3.LocalReport.DataSources.Clear();
                rbm.reportViewer3.LocalReport.DataSources.Add(rs);
            }
            else if (radioKataey.Checked == true)
            {
                AppSetting.TypePrice = "Kataey";
                rbm.reportViewer4.LocalReport.DataSources.Clear();
                rbm.reportViewer4.LocalReport.DataSources.Add(rs);
            }



            




            rbm.ShowDialog();




            //if (radioAll.Checked == true)
            //{
            //    AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");


            //    List<Class_PricesCategorey> BM = new List<Class_PricesCategorey>();
            //    BM.Clear();
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        Class_PricesCategorey BillDay = new Class_PricesCategorey
            //        {

            //            Barcode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
            //            Storage = dataGridView1.Rows[i].Cells[1].Value.ToString(),
            //            Category = dataGridView1.Rows[i].Cells[2].Value.ToString(),
            //            Faction = dataGridView1.Rows[i].Cells[3].Value.ToString(),
            //            Price = dataGridView1.Rows[i].Cells[4].Value.ToString(),
            //            PriceGomla = dataGridView1.Rows[i].Cells[5].Value.ToString(),
            //            PriceMostahlek = dataGridView1.Rows[i].Cells[6].Value.ToString(),

            //        };

            //        BM.Add(BillDay);
            //    }
            //    rs.Name = "DataSet1";
            //    rs.Value = BM;

            //    Reports.Frm_PriceProducer rbm = new Reports.Frm_PriceProducer();
            //    rbm.reportViewer1.LocalReport.DataSources.Clear();
            //    rbm.reportViewer1.LocalReport.DataSources.Add(rs);




            //    rbm.ShowDialog();
            //}

            //else if (radioSheraa.Checked == true)
            //{
            //    AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");


            //    List<Class_PricesCategorey> BM = new List<Class_PricesCategorey>();
            //    BM.Clear();
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        Class_PricesCategorey BillDay = new Class_PricesCategorey
            //        {

            //            Barcode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
            //            Storage = dataGridView1.Rows[i].Cells[1].Value.ToString(),
            //            Category = dataGridView1.Rows[i].Cells[2].Value.ToString(),
            //            Faction = dataGridView1.Rows[i].Cells[3].Value.ToString(),
            //            Price = dataGridView1.Rows[i].Cells[4].Value.ToString(),
            //          //  PriceGomla = dataGridView1.Rows[i].Cells[5].Value.ToString(),
            //          //  PriceMostahlek = dataGridView1.Rows[i].Cells[6].Value.ToString(),

            //        };

            //        BM.Add(BillDay);
            //    }
            //    rs.Name = "DataSet1";
            //    rs.Value = BM;

            //    Reports.Frm_PriceProducer rbm = new Reports.Frm_PriceProducer();
            //    rbm.reportViewer1.LocalReport.DataSources.Clear();
            //    rbm.reportViewer1.LocalReport.DataSources.Add(rs);




            //    rbm.ShowDialog();


            //}

            //else if (radioGomla.Checked == true)
            //{
            //    AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");


            //    List<Class_PricesCategorey> BM = new List<Class_PricesCategorey>();
            //    BM.Clear();
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        Class_PricesCategorey BillDay = new Class_PricesCategorey
            //        {

            //            Barcode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
            //            Storage = dataGridView1.Rows[i].Cells[1].Value.ToString(),
            //            Category = dataGridView1.Rows[i].Cells[2].Value.ToString(),
            //            Faction = dataGridView1.Rows[i].Cells[3].Value.ToString(),
            //          //  Price = dataGridView1.Rows[i].Cells[4].Value.ToString(),
            //            PriceGomla = dataGridView1.Rows[i].Cells[5].Value.ToString(),
            //          //  PriceMostahlek = dataGridView1.Rows[i].Cells[6].Value.ToString(),

            //        };

            //        BM.Add(BillDay);
            //    }
            //    rs.Name = "DataSet1";
            //    rs.Value = BM;

            //    Reports.Frm_PriceProducer rbm = new Reports.Frm_PriceProducer();
            //    rbm.reportViewer1.LocalReport.DataSources.Clear();
            //    rbm.reportViewer1.LocalReport.DataSources.Add(rs);




            //    rbm.ShowDialog();

            //}

            //else if (radioKataey.Checked == true)
            //{
            //    AppSetting.dateTimePicker1 = dateTimePicker1.Value.ToString("yyyy/MM/dd");


            //    List<Class_PricesCategorey> BM = new List<Class_PricesCategorey>();
            //    BM.Clear();
            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {
            //        Class_PricesCategorey BillDay = new Class_PricesCategorey
            //        {

            //            Barcode = dataGridView1.Rows[i].Cells[0].Value.ToString(),
            //            Storage = dataGridView1.Rows[i].Cells[1].Value.ToString(),
            //            Category = dataGridView1.Rows[i].Cells[2].Value.ToString(),
            //            Faction = dataGridView1.Rows[i].Cells[3].Value.ToString(),
            //           // Price = dataGridView1.Rows[i].Cells[4].Value.ToString(),
            //          //  PriceGomla = dataGridView1.Rows[i].Cells[5].Value.ToString(),
            //            PriceMostahlek = dataGridView1.Rows[i].Cells[6].Value.ToString(),

            //        };

            //        BM.Add(BillDay);
            //    }
            //    rs.Name = "DataSet1";
            //    rs.Value = BM;

            //    Reports.Frm_PriceProducer rbm = new Reports.Frm_PriceProducer();
            //    rbm.reportViewer1.LocalReport.DataSources.Clear();
            //    rbm.reportViewer1.LocalReport.DataSources.Add(rs);




            //    rbm.ShowDialog();

            //}
            ////}
        }

        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textPriceShera_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textPriceGomla_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void labelDiscount_Click(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //=================إضافة الأسعار الشراء الجمله والمستهلك  
                sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceMostahlek,Faction)values ('" + textIDCategroy.Text + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + PriceShera2 + "','" + PriceGomla2 + "','" + PriceKataey2 + "','" + comboBox2.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + PriceShera2 + "',PriceGomla = '" + PriceGomla2 + "',PriceMostahlek = '" + PriceKataey2 + "',Faction= '" + comboBox2.Text + "' where ID ='" + textIDCategroy.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
            }



            //***************************
            // حساب القيمة
            double a1 = Convert.ToDouble(PriceShera2);
            double b1 = Convert.ToDouble(textTotalQuantity.Text);
            double c = a1 * b1;
            textValue.Text = c.ToString();

            try
            {
                sqlCommand1.CommandText = "update Category set Price ='" + PriceShera2 + "' ,PriceGomla = '" + PriceGomla2 + "',PriceMostahlek = '" + PriceKataey2 + "', Value ='" + textValue.Text + "' where  ID='" + textIDCategroy.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                //  MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

            }
            catch
            {
                MessageBox.Show("يوجد خطأ", "Error");
            }

            //try
            //{
            //    DataTable dt11 = new DataTable();
            //    dt11.Clear();
            //    SqlDataAdapter da11 = new SqlDataAdapter("select * from Category where  Category ='" + combCategorys.Text + "'  ", cn);
            //    da11.Fill(dt11);
            //    this.dataGridView1.DataSource = dt11;

            //}
            //catch
            //{ }

            ////******************************

            //combCategorys.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


        }

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                groupBox1.Visible = true;
                panel3.Visible = false;
            }
            else if (radioButton3.Checked == true)
            {
                panel3.Visible = true;
                groupBox1.Visible = false;
            }
        }
        private void GetPriceNew()
        {
            int Point = Int32.Parse(txtPoint.Text);

            if (radioButton1.Checked == true)
            {
                try
                {
                    //------------------------------------------------
                    double a = Convert.ToDouble(textPriceShera.Text);
                    double b = Convert.ToDouble(textPriceGomla.Text);
                    double c = Convert.ToDouble(textPriceKataey.Text);
                    double d = Convert.ToDouble(textDiscount.Text);

                    if (checkShera.Checked == true)
                    {
                        double Sh = (a * d) / 100;
                        double Sh1 = a + Sh;
                        PriceShera2 = Math.Round(Sh1, Point).ToString();
                    }

                    //------------------------------------------------
                    if (checkGomla.Checked == true)
                    {
                        double Go = (b * d) / 100;
                        double Go1 = b + Go;
                        PriceGomla2 = Math.Round(Go1, Point).ToString();
                    }
                    //------------------------------------------------
                    if (checkKataea.Checked == true)
                    {
                        double Ka = (c * d) / 100;
                        double Ka1 = c + Ka;
                        PriceKataey2 = Math.Round(Ka1, Point).ToString();
                    }


                }
                catch
                { }
            }
            else if (radioButton2.Checked == true)
            {
                try
                {
                    //------------------------------------------------
                    double a = Convert.ToDouble(textPriceShera.Text);
                    double b = Convert.ToDouble(textPriceGomla.Text);
                    double c = Convert.ToDouble(textPriceKataey.Text);
                    double d = Convert.ToDouble(textDiscount.Text);

                    if (checkShera.Checked == true)
                    {
                        double Sh = (a * d) / 100;
                        double Sh1 = a - Sh;
                        PriceShera2 = Math.Round(Sh1, Point).ToString();
                    }

                    //------------------------------------------------
                    if (checkGomla.Checked == true)
                    {
                        double Go = (b * d) / 100;
                        double Go1 = b - Go;
                        PriceGomla2 = Math.Round(Go1, Point).ToString();
                    }
                    //------------------------------------------------
                    if (checkKataea.Checked == true)
                    {
                        double Ka = (c * d) / 100;
                        double Ka1 = c - Ka;
                        PriceKataey2 = Math.Round(Ka1, Point).ToString();
                    }


                }
                catch
                { }
            }


        }

        private void UpdatePrice()
        {
            try
            {
                //=================إضافة الأسعار الشراء الجمله والمستهلك  
                sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceMostahlek,Faction)values ('" + textIDCategroy.Text + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + PriceShera2 + "','" + PriceGomla2 + "','" + PriceKataey2 + "','" + comboBox2.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + PriceShera2 + "',PriceGomla = '" + PriceGomla2 + "',PriceMostahlek = '" + PriceKataey2 + "',Faction= '" + comboBox2.Text + "' where ID ='" + textIDCategroy.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
            }



            //***************************
            // حساب القيمة
            double a1 = Convert.ToDouble(PriceShera2);
            double b1 = Convert.ToDouble(textTotalQuantity.Text);
            double c = a1 * b1;
            textValue.Text = c.ToString();

            try
            {
                sqlCommand1.CommandText = "update Category set Price ='" + PriceShera2 + "' ,PriceGomla = '" + PriceGomla2 + "',PriceMostahlek = '" + PriceKataey2 + "', Value ='" + textValue.Text + "' where  ID='" + textIDCategroy.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                //  MessageBox.Show("   الحمد لله لقد تم تعديل البيانات    ", "  update ");

            }
            catch
            {
                MessageBox.Show("يوجد خطأ", "Error");
            }
        }
        private void insertUpdatePrice()
        {
            //================= 
            string MovePrise = "";
            double Shera = 0;
            double Gomla = 0;
            double Kataee = 0;
            double Discount = Convert.ToDouble( textDiscount.Text);

            if (radioButton1.Checked==true)
            {
                MovePrise = "ارتفاع اسعار";
            }
            else if (radioButton2.Checked == true)
            {
                MovePrise = "انخفاض اسعار";
                Discount = Discount * -1;
            }


            if (checkShera.Checked == true)
            {
                Shera = Discount;


            }
            
            if (checkGomla.Checked == true)
            {
                
                Gomla = Discount;

            }

            if (checkKataea.Checked == true)
            {
                
                Kataee = Discount;
            }

            sqlCommand1.CommandText = "insert into PriceUpdateDate (Date,Move,Ratio,DecimalNumber,Shera,Gomla,Kataee)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + MovePrise + "','" + Discount + "','" + txtPoint.Text + "','" + Shera + "','" + Gomla + "','" + Kataee + "')";
            sqlCommand1.ExecuteNonQuery();
        }
        private void butUpdateAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد تعديل أسعار جميع الاصناف بالنسبة المكتوبة بالفعل ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (radioButAllProduct.Checked == true)
                    {
                        button4.PerformClick();  // عرض الكل فى الجدول
                    }
                    else if (radioButGroup.Checked == true)
                    {
                        butSearchGrop.PerformClick();  // عرض المجموعه فى الجدول
                    }

                    
                    int NumRows = Convert.ToInt32(dataGridView1.RowCount - 1);

                    for (int j = 0; j < NumRows; j++) // rows
                    {


                        combCategorys.Text = dataGridView1.Rows[j].Cells[2].Value.ToString();


                        SearchCategory();

                        GetPriceNew();

                        UpdatePrice();

                        




                    }


                    if (radioButAllProduct.Checked == true)
                    {
                        button4.PerformClick();  // عرض الكل فى الجدول
                    }
                    else if (radioButGroup.Checked == true)
                    {
                        butSearchGrop.PerformClick();  // عرض المجموعه فى الجدول
                    }


                    insertUpdatePrice(); // اضافة حركة تغير السعر

                    //-------------- حركة تغير الاسعار
                    DataTable dt11 = new DataTable();
                    dt11.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select * from PriceUpdateDate   ", cn);
                    da11.Fill(dt11);
                    this.dataGridView2.DataSource = dt11;
                    this.dataGridView3.DataSource = dt11;

                    MessageBox.Show("    تم تعديل جميع الاصناف بنجاح    ", "  تعديل ");
                }
                catch
                { }
            }
            else
            {

            }


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
            combCategorys.Text = dataGridSearchCategory.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comCatGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void butSearchGrop_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Category where Group_Name='" + comCatGroup.Text + "' ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }

            textBox1.Text = (dataGridView1.RowCount - 1).ToString(); // عدد الاصناف
        }

        private void radioButAllProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButAllProduct.Checked == true)
            {
                radioButGroup.Checked = false;
                comCatGroup.Visible = false;
                butSearchGrop.Visible = false;
            }
            else if (radioButGroup.Checked == true)
            {
                radioButAllProduct.Checked = false;
                comCatGroup.Visible = true;
                butSearchGrop.Visible = true;
            }

        }

        private void radioButGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButAllProduct.Checked == true)
            {
                radioButGroup.Checked = false;
                comCatGroup.Visible = false;
                butSearchGrop.Visible = false;
            }
            else if (radioButGroup.Checked == true)
            {
                radioButAllProduct.Checked = false;
                comCatGroup.Visible = true;
                butSearchGrop.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt11 = new DataTable();
                dt11.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Category where Total >= '" + textQunt.Text + "' and Storage = '" + comboBox1.Text + "' ", cn);
                da11.Fill(dt11);
                this.dataGridView1.DataSource = dt11;

            }
            catch
            { }

            textBox1.Text = (dataGridView1.RowCount - 1).ToString(); // عدد الاصناف
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            //if(radioAll.Checked==false)
            //{
                

            //    //radioAll.Checked = true;
            //    //radioSheraa.Checked = false;
            //    //radioGomla.Checked = false;
            //    //radioKataey.Checked = false;

            //    butPrint.Visible = false;
            //    button4.Visible = true;


            //}
            //else
            //{
            //    //radioAll.Checked = false;
            //    //radioSheraa.Checked = false;
            //    //radioGomla.Checked = false;
            //    //radioKataey.Checked = false;

            //    //butPrint.Visible = false;
            //    //button4.Visible = false;
            //}
        }

        private void radioSheraa_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioSheraa.Checked == false)
            //{

            //    //radioAll.Checked = false;
            //    //radioSheraa.Checked = true;
            //    //radioGomla.Checked = false;
            //    //radioKataey.Checked = false;

            //    butPrint.Visible = true;
            //    button4.Visible = false;

            //}
            //else
            //{
               

            //    //radioAll.Checked = false;
            //    //radioSheraa.Checked = false;
            //    //radioGomla.Checked = false;
            //    //radioKataey.Checked = false;

            //    //butPrint.Visible = false;
            //    //button4.Visible = false;
            //}
        }
    }
}
