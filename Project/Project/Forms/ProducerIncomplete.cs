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
    public partial class ProducerIncomplete : Form
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
        public ProducerIncomplete()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
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
        private void ProducerIncomplete_Load(object sender, EventArgs e)
        {
            SystemProgram();
            //textValue.Visible = false;
            //label5.Visible = false;
            //butPrint.Visible = false;
            //butPrint2.Visible = true;

            //textValue.Text = "0";



            //----------------- ايجاد الاصناف --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select Category from Category", cn);
                Da1.Fill(Dt1);
                combCategorys.DataSource = Dt1;
                combCategorys.DisplayMember = "Category";
                combCategorys1.DataSource = Dt1;
                combCategorys1.DisplayMember = "Category";
            }
            catch
            {

            }
            //***********************************

           // dataGridReport.Columns.Clear();

            if (SystemPro == "قطاعى") //************** لو النظام قطاعى *****************
            {
                try
                {
                    DataTable dt2 = new DataTable();
                    dt2.Clear();
                    SqlDataAdapter da11 = new SqlDataAdapter("select Barcode,Category,Storage,Total,Faction,Near,Price,Emwared from Category where Total <= Near ", cn);
                    da11.Fill(dt2);
                    this.dataGridReport.DataSource = dt2;


                    //this.dataGridReport.Columns[0].HeaderText = "الكود";
                    //this.dataGridReport.Columns[0].Width = 80;

                    //this.dataGridReport.Columns[1].HeaderText = "الصنف";
                    //this.dataGridReport.Columns[1].Width = 120;

                    //this.dataGridReport.Columns[2].HeaderText = "المخزن";
                    //this.dataGridReport.Columns[2].Width = 80;

                    //this.dataGridReport.Columns[3].HeaderText = "الإجمالى";
                    //this.dataGridReport.Columns[3].Width = 80;

                    //this.dataGridReport.Columns[4].HeaderText = "الفئة";
                    //this.dataGridReport.Columns[4].Width = 60;

                    //this.dataGridReport.Columns[5].HeaderText = "الادنى";
                    //this.dataGridReport.Columns[5].Width = 80;

                    //this.dataGridReport.Columns[6].HeaderText = "السعر";
                    //this.dataGridReport.Columns[6].Width = 60;

                    //this.dataGridReport.Columns[7].HeaderText = "المستورد";
                    //this.dataGridReport.Columns[7].Width = 120;


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

                    //this.dataGridReport.Columns[0].HeaderText = "الكود";
                    //this.dataGridReport.Columns[0].Width = 80;

                    //this.dataGridReport.Columns[1].HeaderText = "المخزن";
                    //this.dataGridReport.Columns[1].Width = 80;

                    //this.dataGridReport.Columns[2].HeaderText = "الصنف";
                    //this.dataGridReport.Columns[2].Width = 200;

                    //this.dataGridReport.Columns[3].HeaderText = "ك";
                    //this.dataGridReport.Columns[3].Width = 60;

                    //this.dataGridReport.Columns[4].HeaderText = "ق";
                    //this.dataGridReport.Columns[4].Width = 60;

                    //this.dataGridReport.Columns[5].HeaderText = "الوحدة";
                    //this.dataGridReport.Columns[5].Width = 60;

                    //this.dataGridReport.Columns[6].HeaderText = "الفئة";
                    //this.dataGridReport.Columns[6].Width = 60;

                    //this.dataGridReport.Columns[7].HeaderText = "الاجمالى";
                    //this.dataGridReport.Columns[7].Width = 100;

                    //this.dataGridReport.Columns[8].HeaderText = "السعر";
                    //this.dataGridReport.Columns[8].Width = 80;

                    //this.dataGridReport.Columns[9].HeaderText = "القيمة";
                    //this.dataGridReport.Columns[9].Width = 80;



                    dataGridReport.Sort(dataGridReport.Columns[2], ListSortDirection.Ascending);
                }
                catch
                { }




            }

            //=========== ايجاد القيمة الاجمالية ========

            SumValue();

            //=================  الترقيم  ==========
            GridNumbers();

            //============= الاصناف المطلوبة

            GetCategoryIncomplete();


        }
        private void SumValue()
        {
            double sum1 = 0;
            for (int i = 0; i < dataGridReport2.RowCount; ++i)
            {
                sum1 += Convert.ToDouble(dataGridReport2.Rows[i].Cells[5].Value);

            }
            textTotals.Text = sum1.ToString();   
        }
        private void GetCategoryIncomplete()
        {
            //============= الاصناف المطلوبة

            try
            {
                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select Barcode,Category,Total,Faction,Price,Value,Emwared from CategoryIncomplete ", cn);
                da11.Fill(dt2);
                this.dataGridReport2.DataSource = dt2;


                //this.dataGridReport2.Columns[0].HeaderText = "الكود";
                //this.dataGridReport2.Columns[0].Width = 80;

                //this.dataGridReport2.Columns[1].HeaderText = "الصنف";
                //this.dataGridReport2.Columns[1].Width = 160;


                //this.dataGridReport2.Columns[2].HeaderText = "الكمية";
                //this.dataGridReport2.Columns[2].Width = 80;

                //this.dataGridReport2.Columns[3].HeaderText = "الفئة";
                //this.dataGridReport2.Columns[3].Width = 60;


                //this.dataGridReport2.Columns[4].HeaderText = "السعر";
                //this.dataGridReport2.Columns[4].Width = 60;

                //this.dataGridReport2.Columns[5].HeaderText = "المستورد";
                //this.dataGridReport2.Columns[5].Width = 160;


            }
            catch
            { }

            //------------------
            SumValue();
        }
        private void dataGridReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys1.Text = dataGridReport.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBarcode1.Text = dataGridReport.Rows[e.RowIndex].Cells[0].Value.ToString();

            textPrice1.Text = dataGridReport.Rows[e.RowIndex].Cells[6].Value.ToString();

            textElmwared1.Text = dataGridReport.Rows[e.RowIndex].Cells[7].Value.ToString();

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into CategoryIncomplete (Barcode,Category,Quantity,Faction,Price,Emwared)values ('" + textBarcode.Text + "','" + combCategorys.Text + "','" + textQuantety.Text + "','" + textFaction.Text + "','" + textPrice.Text + "','" + textElmwared.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                //sqlCommand1.CommandText = "update CategoryIncomplete set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }
        }

        private void butAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into CategoryIncomplete (Barcode,Category,Total,Faction,Price,Value,Emwared)values ('" + textBarcode.Text + "','" + combCategorys.Text + "','" + textQuantety.Text + "','" + textFaction.Text + "','" + textPrice.Text + "','" + textValue.Text + "','" + textElmwared.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                //sqlCommand1.CommandText = "update CategoryIncomplete set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }

            //------- جلب كود الجديد
            GetBarcodeNoCategorey();

            //--------- جلب الاصناف فى الجدول
            GetCategoryIncomplete();
        }

        private void butAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into CategoryIncomplete (Barcode,Category,Total,Faction,Price,Value,Emwared)values ('" + textBarcode1.Text + "','" + combCategorys1.Text + "','" + textQuantety1.Text + "','" + textFaction1.Text + "','" + textPrice1.Text + "','" + textValue1.Text + "','" + textElmwared1.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("هذا الصنف مضاف من قبل ", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //sqlCommand1.CommandText = "update CategoryIncomplete set    TotalBill='" + txtTotalBill.Text + "',Paid='" + txtMosadad.Text + "',Discount='" + txtDic.Text + "',ReasonDiscount='" + textBox12.Text + "',Adding='" + txtAdd.Text + "',ReasonAdd='" + textBox14.Text + "' , Remaining ='" + txtRemainingNow.Text + "', NumberCategory ='" + TxtNumCategorey.Text + "' , State ='" + textNoteBill.Text + "' where NumBill='" + textBillingDataNumBill.Text + "' ";
                //sqlCommand1.ExecuteNonQuery();
            }

            GetCategoryIncomplete();
        }

        private void combCategorys_TextChanged(object sender, EventArgs e)
        {
            if (chBoxBarcode.Checked == true)
            {
                textTotal.Text = "0";
                textPrice.Text = "0";
               // textBarcode.Text = "";
                textFaction.Text = "";
                textElmwared.Text = "";
            }
            else
            {
                textTotal.Text = "0";
                textPrice.Text = "0";
                textBarcode.Text = "";
                textFaction.Text = "";
                textElmwared.Text = "";


                //-----------------   ايجاد الاصناف الموجودة فقط --------------------


                try
                {


                    sqlCommand1.CommandText = "select * from Category where Category Like'" + combCategorys.Text + "'   ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        // CategoryID = reed["ID"].ToString();
                        textBarcode.Text = reed["Barcode"].ToString();

                        textFaction.Text = reed["Faction"].ToString();
                        textTotal.Text = reed["Total"].ToString();
                        // textNear.Text = reed["Near"].ToString();

                        //------------------------

                        // PriceGomla = reed["PriceGomla"].ToString();
                        // PriceMostahlek = reed["PriceMostahlek"].ToString();
                        textPrice.Text = reed["Price"].ToString();

                        textPrice.Text = Math.Round(double.Parse(textPrice.Text), 2).ToString();
                        // textBox5.Text = Math.Round(double.Parse(PriceMostahlek), 2).ToString();

                        //  textBox4.Text = PriceGomla;
                        // textBox5.Text = PriceMostahlek;
                    }
                    reed.Close();
                }
                catch
                {

                }

                //try
                //{
                //    //this code is used to search Name on the basis of textBox1.text
                //    ((DataTable)dataGridReport2.DataSource).DefaultView.RowFilter = string.Format("الصنف like '%{0}%'", combCategorys.Text.Trim().Replace("'", "''"));
                //    dataGridReport2.CurrentRow.Selected = true;
                //}
                //catch (Exception) { }
            }



        }

        private void textBarcode_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var searchValue = textBarcode.Text;
            //    var row = dataGridReport2.Rows.Cast<DataGridViewRow>()
            //        .Where(x => !x.IsNewRow)
            //        .Where(x => ((DataRowView)x.DataBoundItem)["Barcode"].ToString().Equals(searchValue))
            //        .FirstOrDefault();
            //    this.dataGridReport2.CurrentCell = row.Cells[0];
            //}
            //catch
            //{ }

            foreach (DataGridViewRow row in dataGridReport2.Rows)
            {
                // Test if the first column of the current row equals
                // the value in the text box
                if ((string)row.Cells[0].Value == textBarcode.Text)
                {
                    // we have a match
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            //=========================
            AppSetting.ValueeProducerIncomplete = textTotals.Text;
            //=========================


            List<Class_Producers> BM = new List<Class_Producers>();
            BM.Clear();
            for (int i = 0; i < dataGridReport2.Rows.Count; i++)
            {


                Class_Producers Categoreys = new Class_Producers
                {

                    Barcode = dataGridReport2.Rows[i].Cells[0].Value.ToString(),
                    Category = dataGridReport2.Rows[i].Cells[1].Value.ToString(),
                    Total = dataGridReport2.Rows[i].Cells[2].Value.ToString(),
                    Faction = dataGridReport2.Rows[i].Cells[3].Value.ToString(),
                    Price = dataGridReport2.Rows[i].Cells[4].Value.ToString(),
                    Value = dataGridReport2.Rows[i].Cells[5].Value.ToString(),
                    Emwared = dataGridReport2.Rows[i].Cells[6].Value.ToString()

                };

                BM.Add(Categoreys);
            }

            rs.Name = "DataSet1";
            rs.Value = BM;
            Reports.ReportProducer rbm = new Reports.ReportProducer();
            rbm.reportViewer3.LocalReport.DataSources.Clear();
            rbm.reportViewer3.LocalReport.DataSources.Add(rs);
            rbm.reportViewer1.Visible = false;
            rbm.reportViewer2.Visible = false;
            rbm.reportViewer3.Visible = true;
            rbm.ShowDialog();

            
        }

        private void butPrint2_Click(object sender, EventArgs e)
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
                    Near = dataGridReport.Rows[i].Cells[5].Value.ToString(),
                    Emwared = dataGridReport.Rows[i].Cells[7].Value.ToString()

                };

                BM.Add(Categoreys);
            }

            rs.Name = "DataSet1";
            rs.Value = BM;
            Reports.ReportProducer rbm = new Reports.ReportProducer();
            rbm.reportViewer2.LocalReport.DataSources.Clear();
            rbm.reportViewer2.LocalReport.DataSources.Add(rs);
            rbm.reportViewer1.Visible = false;
            rbm.reportViewer3.Visible = false;
            rbm.ShowDialog();
        }

        private void dataGridReport2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            combCategorys.Text = dataGridReport2.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBarcode.Text = dataGridReport2.Rows[e.RowIndex].Cells[0].Value.ToString();
            textQuantety.Text = dataGridReport2.Rows[e.RowIndex].Cells[2].Value.ToString();

            textFaction.Text = dataGridReport2.Rows[e.RowIndex].Cells[3].Value.ToString();
            textPrice.Text = dataGridReport2.Rows[e.RowIndex].Cells[4].Value.ToString();

            textElmwared.Text = dataGridReport2.Rows[e.RowIndex].Cells[5].Value.ToString();


            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد حذف الصنف من قائمة النواقص ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {


                sqlCommand1.CommandText = "delete from CategoryIncomplete where Barcode = '" + textBarcode.Text + "'   ";
                sqlCommand1.ExecuteNonQuery();


              //  MessageBox.Show("  تم الحذف بنجاح  ", "   حذف   ");

            }
            else if (dialogResult == DialogResult.No)
            {


            }

            GetCategoryIncomplete();
        }

        private void butDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد حذف الصنف من قائمة النواقص ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                sqlCommand1.CommandText = "delete from CategoryIncomplete where ID >= '" + 1 + "' ";
                sqlCommand1.ExecuteNonQuery();
            }
            else if (dialogResult == DialogResult.No)
            {


            }

            GetCategoryIncomplete();
        }
        private void GetBarcodeNoCategorey()
        {
            if (chBoxBarcode.Checked == true)
            {
                combCategorys2.Visible = true;
                combCategorys.Visible = false;

                // chBoxBarcode.Checked = false;
                textBarcode.Text = "";

                sqlCommand1.CommandText = "select * From CategoryIncomplete  Where ID =(select max(ID) from CategoryIncomplete) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["ID"].ToString());
                    double aa = s + 1;
                    textBarcode.Text = aa.ToString();


                }
                red.Close();

                if (textBarcode.Text == "")
                {
                    textBarcode.Text = "1";
                }
                else
                { }

            
                //--------------حساب الباركود واضافة فى الجدول الاصناف -------------
                int a = Convert.ToInt32(textBarcode.Text);
                int b = 60000000;
                int aaa = a + b;
                textBarcode.Text = aaa.ToString();
             
            }
            else
            {
                textBarcode.Text = "";
                combCategorys.Visible = true;
                combCategorys2.Visible = false;
                //chBoxBarcode.Checked = true;



            }
        }
        private void chBoxBarcode_CheckedChanged(object sender, EventArgs e)
        {
            GetBarcodeNoCategorey();

        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textPrice.Text);
                double b = Convert.ToDouble(textQuantety.Text);
                double aaa = a * b;
                textValue.Text = aaa.ToString();
                textValue.Text = Math.Round(double.Parse(textValue.Text), 2).ToString();
            }
            catch
            { }
        }

        private void textQuantety_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textPrice.Text);
                double b = Convert.ToDouble(textQuantety.Text);
                double aaa = a * b;
                textValue.Text = aaa.ToString();
                textValue.Text = Math.Round(double.Parse(textValue.Text), 2).ToString();
            }
            catch
            { }
        }

        private void textQuantety1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textPrice1.Text);
                double b = Convert.ToDouble(textQuantety1.Text);
                double aaa = a * b;
                textValue1.Text = aaa.ToString();
                textValue1.Text = Math.Round(double.Parse(textValue1.Text), 2).ToString();
            }
            catch
            { }
        }

        private void textPrice1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textPrice1.Text);
                double b = Convert.ToDouble(textQuantety1.Text);
                double aaa = a * b;
                textValue1.Text = aaa.ToString();
                textValue1.Text = Math.Round(double.Parse(textValue1.Text), 2).ToString();
            }
            catch
            { }
        }

        private void combCategorys2_TextChanged(object sender, EventArgs e)
        {
            combCategorys.Text = combCategorys2.Text;

        }

        private void butPrintNoPrice_Click(object sender, EventArgs e)
        {
            //=========================
            AppSetting.ValueeProducerIncomplete = "";
            //=========================


            List<Class_Producers> BM = new List<Class_Producers>();
            BM.Clear();
            for (int i = 0; i < dataGridReport2.Rows.Count; i++)
            {


                Class_Producers Categoreys = new Class_Producers
                {

                    Barcode = dataGridReport2.Rows[i].Cells[0].Value.ToString(),
                    Category = dataGridReport2.Rows[i].Cells[1].Value.ToString(),
                    Total = dataGridReport2.Rows[i].Cells[2].Value.ToString(),
                    Faction = dataGridReport2.Rows[i].Cells[3].Value.ToString(),
                    Price = "",
                    Value = "",
                    Emwared = dataGridReport2.Rows[i].Cells[6].Value.ToString()

                };

                BM.Add(Categoreys);
            }

            rs.Name = "DataSet1";
            rs.Value = BM;
            Reports.ReportProducer rbm = new Reports.ReportProducer();
            rbm.reportViewer3.LocalReport.DataSources.Clear();
            rbm.reportViewer3.LocalReport.DataSources.Add(rs);
            rbm.reportViewer1.Visible = false;
            rbm.reportViewer2.Visible = false;
            rbm.reportViewer3.Visible = true;
            rbm.ShowDialog();
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            //============= الاصناف المطلوبة

            try
            {
                DataTable dt2 = new DataTable();
                dt2.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select Barcode,Category,Total,Faction,Price,Value,Emwared from CategoryIncomplete  where Emwared like '%" + textElmwared2.Text + "%'  ", cn);
                da11.Fill(dt2);
                this.dataGridReport2.DataSource = dt2;


                //this.dataGridReport2.Columns[0].HeaderText = "الكود";
                //this.dataGridReport2.Columns[0].Width = 80;

                //this.dataGridReport2.Columns[1].HeaderText = "الصنف";
                //this.dataGridReport2.Columns[1].Width = 160;


                //this.dataGridReport2.Columns[2].HeaderText = "الكمية";
                //this.dataGridReport2.Columns[2].Width = 80;

                //this.dataGridReport2.Columns[3].HeaderText = "الفئة";
                //this.dataGridReport2.Columns[3].Width = 60;


                //this.dataGridReport2.Columns[4].HeaderText = "السعر";
                //this.dataGridReport2.Columns[4].Width = 60;

                //this.dataGridReport2.Columns[5].HeaderText = "المستورد";
                //this.dataGridReport2.Columns[5].Width = 160;


            }
            catch
            { }

            //------------------
            SumValue();
        }
    }
}
