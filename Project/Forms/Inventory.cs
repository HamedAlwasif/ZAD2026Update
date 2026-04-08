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
    public partial class Inventory : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //---------------------------------
        int i = 0;
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader reed;
        private SqlDataReader red;
        //-------------------------------
        ReportDataSource rs = new ReportDataSource();


        public Inventory()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
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
            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";

            }
            // نهاية البحث نظام العمل جملة او قطاعى
        }
        private void GridNumbers()
        {
            //------------------- ترقيم الداتا جريد
            int rowNumber = 1;
            int rowNumber1 = 0;
            foreach (DataGridViewRow row in dataGridReport.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "" + rowNumber + "";
                rowNumber = rowNumber + 1;

                rowNumber1 = rowNumber1 + 1;
            }

            dataGridReport.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //عدد الفواتير
            dataGridReport.Text = rowNumber1.ToString();
        }
        private void SumValue()
        {
            try
            {
                if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
                {
                    double sum1 = 0;
                    for (int i = 0; i < dataGridReport.RowCount; ++i)
                    {
                        sum1 += Convert.ToDouble(dataGridReport.Rows[i].Cells[6].Value);

                    }
                    textValue.Text = sum1.ToString();
                    textValue.Text = Math.Round(double.Parse(textValue.Text), 0).ToString();
                }
                else  //************** لو النظام جملة *****************
                {
                    double sum1 = 0;
                    for (int i = 0; i < dataGridReport.RowCount; ++i)
                    {
                        sum1 += Convert.ToDouble(dataGridReport.Rows[i].Cells[9].Value);

                    }
                    textValue.Text = sum1.ToString();
                    textValue.Text = Math.Round(double.Parse(textValue.Text), 0).ToString();
                }
            }
            catch
            { }

        }
        private void Inventory_Load(object sender, EventArgs e)
        {
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


            //----------------- 1ايجاد المخزن --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Storage from Storage", cn);
                Da1.Fill(Dt1);
                combStorage.DataSource = Dt1;
                combStorage.DisplayMember = "Storage";
            }
            catch
            {

            }

            //-----------------  2 ايجاد المخزن --------------------
            try
            {
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Storage from Storage", cn);
                Da.Fill(Dt);
                combStorage1.DataSource = Dt;
                combStorage1.DisplayMember = "Storage";

                combStorage2.DataSource = Dt;
                combStorage2.DisplayMember = "Storage";
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
            }
            catch
            {

            }



            //// البحث نظام العمل جملة او قطاعى
            //sqlCommand1.CommandText = "select * from SystemProgram where ID ='" + 1 + "' ";
            //reed = sqlCommand1.ExecuteReader();
            //while (reed.Read())
            //{

            //    textSystemKataey.Text = reed["Kataey"].ToString();
            //    textSystemGomla.Text = reed["GomlaKataey"].ToString();

            //}

            //reed.Close();

            //------------
            SystemProgram();

            if (SystemPro == "قطاعى") // قطاعى
            {
                radioButton1.Visible = false;
                radioButton2.Checked = true;
                textBox3.Visible = false;
                textBox2.Visible = false;
                label3.Visible = false;
                butSearchTotal.Visible = false;



            }
            else // جملة وقطاعى
            {



            }
            // نهاية البحث نظام العمل جملة او قطاعى

            butSearchQuantity.PerformClick();

        }

        private void combCategorys_KeyPress(object sender, KeyPressEventArgs e)
        {
            textValue.Text = "0";

            dataGridReport.Columns.Clear();


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,Faction,PriceMostahlek,FLOOR(Total*PriceMostahlek)as Valueeee,Emwared From Category  where Category like '%" + combCategorys.Text + "%' ", cn);

                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الباركود";
                    this.dataGridReport.Columns[0].Width = 100;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 250;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "السعر";
                    this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    this.dataGridReport.Columns[7].HeaderText = "ملاحظات";
                    this.dataGridReport.Columns[7].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);






                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,FLOOR(PriceMostahlek*Total) as Valuee from Category where Category like '%" + combCategorys.Text + "%' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 80;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);


                }
                catch
                {

                }
            }
        }

        private void butSearchStore_Click(object sender, EventArgs e)
        {

            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,PriceMostahlek,FLOOR(Total*PriceMostahlek) as Valuee  from Category where Storage = '" + combStorage.Text + "'", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "السعر";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[3].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------




                }
                catch
                {

                }


            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,(PriceMostahlek*Total) as Valuee from Category where Storage = '" + combStorage.Text + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);


                }
                catch
                {

                }



            }

            //===========ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textValue.Visible = false;
            label5.Visible = false;
            butPrint.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,Faction,Emwared From Category where  Available = '" + comboBox4.Text + "' ", cn);

                    //SqlDataAdapter da = new SqlDataAdapter("select ID,Storage,Category,Total,Faction,Price from Category where Total >= '" + 1 + "' and Available = '" + comboBox3.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الباركود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    //this.dataGridReport.Columns[3].HeaderText = "ك";
                    //this.dataGridReport.Columns[3].Width = 60;

                    //this.dataGridReport.Columns[4].HeaderText = "ق";
                    //this.dataGridReport.Columns[4].Width = 60;

                    //this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    //this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "ملاحظات";
                    this.dataGridReport.Columns[5].Width = 80;

                    //this.dataGridReport.Columns[5].HeaderText = "سعر الشراء";
                    //this.dataGridReport.Columns[5].Width = 100;

                    //this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    //this.dataGridReport.Columns[9].Width = 100;

                    //dataGridReport.Columns.Add("col6", "القيمة");
                    //this.dataGridReport.Columns[6].Width = 60;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    ////------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[4].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------




                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,(PriceMostahlek*Total) as Valuee from Category where  Available = '" + comboBox4.Text + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);


                }
                catch
                {

                }
            }


            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butSearchQuantity_Click(object sender, EventArgs e)
        {
            textValue.Text = "0";
            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,Faction,PriceMostahlek,FLOOR(Total*PriceMostahlek)as Valueeee,Emwared From Category where Total >= '" + textBox1.Text + "' ", cn);

                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الباركود";
                    this.dataGridReport.Columns[0].Width = 100;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 250;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "السعر";
                    this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    this.dataGridReport.Columns[7].HeaderText = "ملاحظات";
                    this.dataGridReport.Columns[7].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);






                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,FLOOR(PriceMostahlek*Total) as Valuee from Category where Quantity >= '" + textBox1.Text + "' and Available = '" + comboBox3.Text + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[9].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[7].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[8].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------



                }
                catch
                {

                }





            }


            //===========ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butSearchTotal_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,FLOOR(PriceMostahlek*Total) as Valuee from Category where Total >= '" + textBox2.Text + "' and Available = '" + comboBox3.Text + "' ", cn);
                da1.Fill(dt1);
                this.dataGridReport.DataSource = dt1;

                this.dataGridReport.Columns[0].HeaderText = "الكود";
                this.dataGridReport.Columns[0].Width = 80;

                this.dataGridReport.Columns[1].HeaderText = "المخزن";
                this.dataGridReport.Columns[1].Width = 80;

                this.dataGridReport.Columns[2].HeaderText = "الصنف";
                this.dataGridReport.Columns[2].Width = 200;

                this.dataGridReport.Columns[3].HeaderText = "ك";
                this.dataGridReport.Columns[3].Width = 60;

                this.dataGridReport.Columns[4].HeaderText = "ق";
                this.dataGridReport.Columns[4].Width = 60;

                this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                this.dataGridReport.Columns[5].Width = 60;

                this.dataGridReport.Columns[6].HeaderText = "الفئة";
                this.dataGridReport.Columns[6].Width = 60;

                this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                this.dataGridReport.Columns[7].Width = 100;

                this.dataGridReport.Columns[8].HeaderText = "السعر";
                this.dataGridReport.Columns[8].Width = 80;

                this.dataGridReport.Columns[9].HeaderText = "القيمة";
                this.dataGridReport.Columns[9].Width = 80;



                dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
            }
            catch
            { }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            textValue.Visible = false;
            label5.Visible = false;
            butPrint.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("Select Barcode,Storage,Category,Total,Faction,Emwared From Category where  Storage = '" + combStorage1.Text + "' and  Total >= '" + textBox4.Text + "' and Available = '" + comboBox3.Text + "' ", cn);

                    //SqlDataAdapter da = new SqlDataAdapter("select ID,Storage,Category,Total,Faction,Price from Category where Total >= '" + 1 + "' and Available = '" + comboBox3.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الباركود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    //this.dataGridReport.Columns[3].HeaderText = "ك";
                    //this.dataGridReport.Columns[3].Width = 60;

                    //this.dataGridReport.Columns[4].HeaderText = "ق";
                    //this.dataGridReport.Columns[4].Width = 60;

                    //this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    //this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;



                    //this.dataGridReport.Columns[5].HeaderText = "سعر الشراء";
                    //this.dataGridReport.Columns[5].Width = 100;

                    //this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    //this.dataGridReport.Columns[9].Width = 100;

                    //dataGridReport.Columns.Add("col6", "القيمة");
                    //this.dataGridReport.Columns[6].Width = 60;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    ////------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[4].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------




                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,FLOOR(PriceMostahlek*Total) as Valuee from Category where Storage = '" + combStorage1.Text + "' and  Total >= '" + textBox4.Text + "' and Available = '" + comboBox3.Text + "'", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }
                //------------------


                //===========ايجاد القيمة الاجمالية ========

                SumValue();

                //=================  الترقيم  ==========
                GridNumbers();
                //-------------------------
            }
        }

        private void butAll2_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt1 = new DataTable();
                dt1.Clear();
                SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,FLOOR(PriceMostahlek*Total) as Valuee from Category where Storage = '" + combStorage1.Text + "' and Quantity >= '" + textBox3.Text + "' and Available = '" + comboBox3.Text + "' ", cn);
                da1.Fill(dt1);
                this.dataGridReport.DataSource = dt1;

                this.dataGridReport.Columns[0].HeaderText = "الكود";
                this.dataGridReport.Columns[0].Width = 80;

                this.dataGridReport.Columns[1].HeaderText = "المخزن";
                this.dataGridReport.Columns[1].Width = 80;

                this.dataGridReport.Columns[2].HeaderText = "الصنف";
                this.dataGridReport.Columns[2].Width = 200;

                this.dataGridReport.Columns[3].HeaderText = "ك";
                this.dataGridReport.Columns[3].Width = 60;

                this.dataGridReport.Columns[4].HeaderText = "ق";
                this.dataGridReport.Columns[4].Width = 60;

                this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                this.dataGridReport.Columns[5].Width = 80;

                this.dataGridReport.Columns[6].HeaderText = "الفئة";
                this.dataGridReport.Columns[6].Width = 80;

                this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                this.dataGridReport.Columns[7].Width = 100;

                this.dataGridReport.Columns[8].HeaderText = "السعر";
                this.dataGridReport.Columns[8].Width = 80;

                this.dataGridReport.Columns[9].HeaderText = "القيمة";
                this.dataGridReport.Columns[9].Width = 80;



                dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
            }
            catch
            { }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //============================================
        }

        private void butHide_Click(object sender, EventArgs e)
        {
            textValue.Text = "0";
            if (groupbutSearch.Visible == true)
            {
                groupbutSearch.Visible = false;
                // dataGridReport.Visible = false;
            }
            else
            {
                groupbutSearch.Visible = true;
                dataGridReport.Visible = true;
            }
        }

        private void butTotalShera_Click(object sender, EventArgs e)
        {
            textValue.Text = "0";
            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;
            butPrint2.Visible = false;

            dataGridReport.Columns.Clear();


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,Price,FLOOR(Total*Price) as Valuee  from Category where Total >= '" + textQunt.Text + "' and  Storage = '" + combStorage2.Text + "'  ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "سعر الشراء";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[3].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------





                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,Price,FLOOR(Price*Total) as Valuee from Category where Total >= '" + 1 + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }






            }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butTotalGomla_Click(object sender, EventArgs e)
        {
            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;
            butPrint2.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {

                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,PriceGomla,FLOOR(Total*PriceGomla) as Valuee from Category where Total >= '" + textQunt.Text + "' and  Storage = '" + combStorage2.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "سعر الجملة";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;




                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    ////------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[4].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------



                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceGomla,FLOOR(PriceGomla*Total) as Valuee from Category where Total >= '" + 1 + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }





            }

            //===========ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butTotalMostahlek_Click(object sender, EventArgs e)
        {
            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;
            butPrint2.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,PriceMostahlek,FLOOR(Total*PriceMostahlek) as Valuee  from Category where Total >= '" + textQunt.Text + "' and Storage = '" + combStorage2.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "السعر";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[3].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------




                }
                catch
                {

                }


            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,FLOOR(PriceMostahlek*Total) as Valuee from Category where Total >= '" + 1 + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }




            }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butCategorayEmpty_Click(object sender, EventArgs e)
        {
            textValue.Visible = false;
            label5.Visible = false;
            butPrint.Visible = false;
            butPrint2.Visible = true;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {
                    DataTable dt2 = new DataTable();
                    dt2.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select Barcode,Category,Storage,Total,Near,Emwared from Category where Total <= '" + textAladnaQuntity.Text + "' and Storage = '" + combStorage2.Text + "'", cn);
                    da11.Fill(dt2);
                    this.dataGridReport.DataSource = dt2;


                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "الصنف";
                    this.dataGridReport.Columns[1].Width = 120;

                    this.dataGridReport.Columns[2].HeaderText = "المخزن";
                    this.dataGridReport.Columns[2].Width = 80;

                    this.dataGridReport.Columns[3].HeaderText = "الإجمالى";
                    this.dataGridReport.Columns[3].Width = 80;

                    this.dataGridReport.Columns[4].HeaderText = "الادنى";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "المستورد";
                    this.dataGridReport.Columns[5].Width = 120;


                }
                catch
                { }


            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,(PriceMostahlek*Total) as Valuee from Category where Total <= '" + textAladnaQuntity.Text + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }




            }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            butAll2.Visible = false;
            butAll.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            butAll2.Visible = true;
            butAll.Visible = false;
        }

        private void butPrint_Click(object sender, EventArgs e)
        {

            if (SystemPro == "قطاعى") // قطاعى
            {

                List<Class_Producers> BM = new List<Class_Producers>();
                BM.Clear();
                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {


                    Class_Producers Categoreys = new Class_Producers
                    {

                        Barcode = dataGridReport.Rows[i].Cells[0].Value.ToString(),
                        Storage = dataGridReport.Rows[i].Cells[1].Value.ToString(),
                        Category = dataGridReport.Rows[i].Cells[2].Value.ToString(),
                        Total = dataGridReport.Rows[i].Cells[3].Value.ToString(),
                        Price = dataGridReport.Rows[i].Cells[5].Value.ToString(),
                        Value = dataGridReport.Rows[i].Cells[6].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }

                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportProducer rbm = new Reports.ReportProducer();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                rbm.reportViewer2.Visible = false;
                rbm.ShowDialog();
                //PrintJbsaDataGridView.Print_Grid(dataGridView2);
            }
            else // جملة وقطاعى
            {
                List<Class_Producers> BM = new List<Class_Producers>();
                BM.Clear();
                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {


                    Class_Producers CategoreysGK = new Class_Producers
                    {

                        Barcode = dataGridReport.Rows[i].Cells[0].Value.ToString(),
                        Category = dataGridReport.Rows[i].Cells[2].Value.ToString(),
                        Storage = dataGridReport.Rows[i].Cells[1].Value.ToString(),
                        Quantity = dataGridReport.Rows[i].Cells[3].Value.ToString(),
                        QuantityT = dataGridReport.Rows[i].Cells[4].Value.ToString(),
                        Unity = dataGridReport.Rows[i].Cells[5].Value.ToString(),
                        Faction = dataGridReport.Rows[i].Cells[6].Value.ToString(),
                        Total = dataGridReport.Rows[i].Cells[7].Value.ToString(),
                        Price = dataGridReport.Rows[i].Cells[8].Value.ToString(),
                        Value = dataGridReport.Rows[i].Cells[9].Value.ToString()

                    };

                    BM.Add(CategoreysGK);
                }

                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportProducer_GK rbm = new Reports.ReportProducer_GK();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                rbm.ShowDialog();




                //PrintJbsaDataGridView.Print_Grid(dataGridView1);

            }

        }
        public class Class_Producers2121
        {

            public string Barcode { get; set; }
            public string Storage { get; set; }
            public string Category { get; set; }
            public string Total { get; set; }
            public string Price { get; set; }
            public string Value { get; set; }

        }

        public class Class_Producers
        {

            public string Barcode { get; set; }
            public string Category { get; set; }
            public string Storage { get; set; }
            public string Quantity { get; set; }
            public string QuantityT { get; set; }
            public string Unity { get; set; }
            public string Faction { get; set; }
            public string Total { get; set; }
            public string Price { get; set; }
            public string Value { get; set; }
            public string Near { get; set; }
            public string Emwared { get; set; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textValue.Visible = false;
            label5.Visible = false;
            butPrint.Visible = false;

            butPrint2.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();


            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,Price,PriceGomla,PriceMostahlek  from Category where Total >= '" + textQunt.Text + "' and Storage = '" + combStorage2.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 250;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 80;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "الشراء";
                    this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[6].HeaderText = "الجملة";
                    this.dataGridReport.Columns[6].Width = 80;

                    this.dataGridReport.Columns[7].HeaderText = "المستهلك";
                    this.dataGridReport.Columns[7].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[3].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------





                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    //SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,Price,(Price*Total) as Valuee from Category where Total >= '" + 1 + "' ", cn);
                    //da1.Fill(dt1);
                    //this.dataGridReport.DataSource = dt1;

                    //this.dataGridReport.Columns[0].HeaderText = "الكود";
                    //this.dataGridReport.Columns[0].Width = 80;

                    //this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    //this.dataGridReport.Columns[1].Width = 80;

                    //this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    //this.dataGridReport.Columns[2].Width = 200;

                    ////this.dataGridReport.Columns[3].HeaderText = "ك";
                    ////this.dataGridReport.Columns[3].Width = 60;

                    ////this.dataGridReport.Columns[4].HeaderText = "ق";
                    ////this.dataGridReport.Columns[4].Width = 60;

                    ////this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    ////this.dataGridReport.Columns[5].Width = 60;

                    ////this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    ////this.dataGridReport.Columns[6].Width = 60;

                    //this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    //this.dataGridReport.Columns[7].Width = 100;

                    //this.dataGridReport.Columns[8].HeaderText = "السعر";
                    //this.dataGridReport.Columns[8].Width = 80;

                    //this.dataGridReport.Columns[5].HeaderText = "سعر الجملة";
                    //this.dataGridReport.Columns[5].Width = 100;

                    ////this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    ////this.dataGridReport.Columns[9].Width = 80;

                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,Price,PriceGomla,PriceMostahlek  from Category where Total >= '" + 1 + "'  ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;
                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 250;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 80;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "الشراء";
                    this.dataGridReport.Columns[5].Width = 80;

                    this.dataGridReport.Columns[6].HeaderText = "الجملة";
                    this.dataGridReport.Columns[6].Width = 80;

                    this.dataGridReport.Columns[7].HeaderText = "المستهلك";
                    this.dataGridReport.Columns[7].Width = 80;


                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }






            }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butSearch_Click(object sender, EventArgs e)
        {

            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {



                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,PriceMostahlek,FLOOR(Total*PriceMostahlek) as Valuee  from Category where Group_Name = '" + comCatGroup.Text + "'", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;
                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "السعر";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;

                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    //------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[3].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------




                }
                catch
                {

                }


            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,(PriceMostahlek*Total) as Valuee from Category where Group_Name = '" + comCatGroup.Text + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);


                }
                catch
                {

                }



            }

            //===========ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butCategorayMinimum_Click(object sender, EventArgs e)
        {
            textValue.Visible = false;
            label5.Visible = false;
            butPrint.Visible = false;
            butPrint2.Visible = true;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {
                    DataTable dt2 = new DataTable();
                    dt2.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select Barcode,Category,Storage,Total,Near,Emwared from Category where Total <= Near and Storage = '" + combStorage2.Text + "'", cn);
                    da11.Fill(dt2);
                    this.dataGridReport.DataSource = dt2;


                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "الصنف";
                    this.dataGridReport.Columns[1].Width = 120;

                    this.dataGridReport.Columns[2].HeaderText = "المخزن";
                    this.dataGridReport.Columns[2].Width = 80;

                    this.dataGridReport.Columns[3].HeaderText = "الإجمالى";
                    this.dataGridReport.Columns[3].Width = 80;

                    this.dataGridReport.Columns[4].HeaderText = "الادنى";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "المستورد";
                    this.dataGridReport.Columns[5].Width = 120;


                }
                catch
                { }


            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceMostahlek,(PriceMostahlek*Total) as Valuee from Category where Total <= Near ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }




            }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();
            //-------------------------
        }

        private void butPrint2_Click(object sender, EventArgs e)
        {

            if (SystemPro == "قطاعى") // قطاعى
            {

                List<Class_Producers> BM = new List<Class_Producers>();
                BM.Clear();
                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {


                    Class_Producers Categoreys = new Class_Producers
                    {

                        Barcode = dataGridReport.Rows[i].Cells[0].Value.ToString(),
                        Category = dataGridReport.Rows[i].Cells[1].Value.ToString(),
                        Storage = dataGridReport.Rows[i].Cells[2].Value.ToString(),

                        Total = dataGridReport.Rows[i].Cells[3].Value.ToString(),
                        Near = dataGridReport.Rows[i].Cells[4].Value.ToString(),
                        Emwared = dataGridReport.Rows[i].Cells[5].Value.ToString()

                    };

                    BM.Add(Categoreys);
                }

                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportProducer rbm = new Reports.ReportProducer();
                rbm.reportViewer2.LocalReport.DataSources.Clear();
                rbm.reportViewer2.LocalReport.DataSources.Add(rs);
                rbm.reportViewer1.Visible = false;
                rbm.ShowDialog();
                //PrintJbsaDataGridView.Print_Grid(dataGridView2);
            }
            else // جملة وقطاعى
            {
                List<Class_Producers> BM = new List<Class_Producers>();
                BM.Clear();
                for (int i = 0; i < dataGridReport.Rows.Count; i++)
                {


                    Class_Producers CategoreysGK = new Class_Producers
                    {

                        Barcode = dataGridReport.Rows[i].Cells[0].Value.ToString(),
                        Category = dataGridReport.Rows[i].Cells[2].Value.ToString(),
                        Storage = dataGridReport.Rows[i].Cells[1].Value.ToString(),
                        Quantity = dataGridReport.Rows[i].Cells[3].Value.ToString(),
                        QuantityT = dataGridReport.Rows[i].Cells[4].Value.ToString(),
                        Unity = dataGridReport.Rows[i].Cells[5].Value.ToString(),
                        Faction = dataGridReport.Rows[i].Cells[6].Value.ToString(),
                        Total = dataGridReport.Rows[i].Cells[7].Value.ToString(),
                        Price = dataGridReport.Rows[i].Cells[8].Value.ToString(),
                        Value = dataGridReport.Rows[i].Cells[9].Value.ToString()

                    };

                    BM.Add(CategoreysGK);
                }

                rs.Name = "DataSet1";
                rs.Value = BM;
                Reports.ReportProducer_GK rbm = new Reports.ReportProducer_GK();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                rbm.ShowDialog();




                //PrintJbsaDataGridView.Print_Grid(dataGridView1);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void butTotalGomlaAlgomla_Click(object sender, EventArgs e)
        {
            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;
            butPrint2.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {

                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,PriceGomlaAlgomla,FLOOR(Total*PriceGomlaAlgomla) as Valuee from Category where Total >= '" + textQunt.Text + "' and  Storage = '" + combStorage2.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "سعر الجملة";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;




                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    ////------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[4].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------



                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceGomlaAlgomla,FLOOR(PriceGomlaAlgomla*Total) as Valuee from Category where Total >= '" + 1 + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }



            }
        }

        private void butTotalNesfGomla_Click(object sender, EventArgs e)
        {
            textValue.Visible = true;
            label5.Visible = true;
            butPrint.Visible = true;
            butPrint2.Visible = false;

            textValue.Text = "0";

            dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {

                    DataTable dt = new DataTable();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter("select Barcode,Storage,Category,Total,Faction,PriceNesfAlgomla,FLOOR(Total*PriceNesfAlgomla) as Valuee from Category where Total >= '" + textQunt.Text + "' and  Storage = '" + combStorage2.Text + "' ", cn);
                    da.Fill(dt);
                    this.dataGridReport.DataSource = dt;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 120;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 100;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 280;

                    this.dataGridReport.Columns[3].HeaderText = "الكمية";
                    this.dataGridReport.Columns[3].Width = 100;

                    this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    this.dataGridReport.Columns[4].Width = 80;

                    this.dataGridReport.Columns[5].HeaderText = "سعر الجملة";
                    this.dataGridReport.Columns[5].Width = 100;

                    this.dataGridReport.Columns[6].HeaderText = "القيمة";
                    this.dataGridReport.Columns[6].Width = 80;




                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);

                    ////------------- ايجاد قيمة الاجمالى ----------------------------
                    //foreach (DataGridViewRow item in dataGridReport.Rows)
                    //{
                    //    int n = item.Index;
                    //    dataGridReport.Rows[n].Cells[6].Value =
                    //        (Double.Parse(dataGridReport.Rows[n].Cells[4].Value.ToString()) *
                    //         Double.Parse(dataGridReport.Rows[n].Cells[5].Value.ToString())).ToString();
                    //}
                    //----------------------------------------------------



                }
                catch
                {

                }



            }
            else //************** لو النظام جملة *****************
            {
                try
                {

                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    SqlDataAdapter da1 = new SqlDataAdapter("select Barcode,Storage,Category,Quantity,QuantityT,Unity,Faction,Total,PriceNesfAlgomla,FLOOR(PriceNesfAlgomla*Total) as Valuee from Category where Total >= '" + 1 + "' ", cn);
                    da1.Fill(dt1);
                    this.dataGridReport.DataSource = dt1;

                    this.dataGridReport.Columns[0].HeaderText = "الكود";
                    this.dataGridReport.Columns[0].Width = 80;

                    this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    this.dataGridReport.Columns[1].Width = 80;

                    this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    this.dataGridReport.Columns[2].Width = 200;

                    this.dataGridReport.Columns[3].HeaderText = "ك";
                    this.dataGridReport.Columns[3].Width = 60;

                    this.dataGridReport.Columns[4].HeaderText = "ق";
                    this.dataGridReport.Columns[4].Width = 60;

                    this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    this.dataGridReport.Columns[5].Width = 60;

                    this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    this.dataGridReport.Columns[6].Width = 60;

                    this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    this.dataGridReport.Columns[7].Width = 100;

                    this.dataGridReport.Columns[8].HeaderText = "السعر";
                    this.dataGridReport.Columns[8].Width = 80;

                    this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }

            }
        }
    }
        }