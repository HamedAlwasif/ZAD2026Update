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
    public partial class ProducerAddSN : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        //-------------------------------

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

        int NumSnCategorey = 0;
        public ProducerAddSN()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void GetCategoreySn()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            SqlDataAdapter da = new SqlDataAdapter("select ID,CategoryBarcode,CategoryName,CategorySN from CategorySN where CategoryName ='" + comCategory.Text + "' ", cn);
            da.Fill(dt);

            this.dataGridView8.DataSource = dt;
            this.dataGridView8.Columns[0].HeaderText = "م";
            this.dataGridView8.Columns[1].HeaderText = "الباركود";
            this.dataGridView8.Columns[2].HeaderText = "الصنف";
            this.dataGridView8.Columns[3].HeaderText = "السريال";

            this.dataGridView8.Columns[0].Width = 60;
            this.dataGridView8.Columns[1].Width = 70;
            this.dataGridView8.Columns[2].Width = 200;
            this.dataGridView8.Columns[3].Width = 120;

            NumSnCategorey = dataGridView8.Rows.Count;


            textID_SN.Text = "0";



            if (NumSnCategorey == 0)
            {
                //MessageBox.Show("  لايوجد سرايل لهذا الصنف    ", "سريال", MessageBoxButtons.OK, MessageBoxIcon.Error);

                

                //textCategoreySN.Text = "";
                //textCategoreySN.Enabled = false;

            }
            else
            {
                // MessageBox.Show("  ممتاز يوجد سرايل لهذا الصنف    ", " هايل جدا سريال", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }

        }


        private void butSearch_Click(object sender, EventArgs e)
        {

            GetCategoreySn();

            //------------------------------------------------

            sqlCommand1.CommandText = "select * from Category where Category like'" + comCategory.Text + "' ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                textBarcode.Text = red["Barcode"].ToString();
                //textCategoreySN.Text = red["Category"].ToString();
                textBox2.Text = red["Quantity"].ToString();
                quntety = red["Quantity"].ToString();   // تخزين الكمية القديمة
                textBox3.Text = red["QuantityT"].ToString();
                //dateTimePicker1.Text = red["التاريخ"].ToString();
                textBox4.Text = red["Unity"].ToString();
                comboBox2.Text = red["Faction"].ToString();
                textBox5.Text = red["Total"].ToString();
                //textBox8.Text = red["Price"].ToString();
                //textBox9.Text = red["Value"].ToString();
                //textBox6.Text = red["Near"].ToString();
                //textBox10.Text = red["Emwared"].ToString();
                //comboBox3.Text = red["Available"].ToString();
                //comCatGroup.Text = red["Group_Name"].ToString();




            }
            red.Close();

        }

        private void ProducerAddSN_Load(object sender, EventArgs e)
        {
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
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "0")
            {
                MessageBox.Show("   الصنف لا يوجد له كمية فى المخزن لا بد من اضافة كمية عن طريق فاتورة شراء اولا    ", "  خطأ ");


            }
            else
            {

                double Total = Convert.ToDouble(textBox5.Text); //----------- الكمية الموجوده 

                if (NumSnCategorey >= Total)
                {
                    MessageBox.Show("   السريلات الموجودة للصنف اكبر من اوتساوى الكمية الموجودة لا بد من اضافة كمية جديدة عن طريق فاتورة شراء اولا   ", "  خطأ ");

                }
                else
                {

                                                         
                    if (textCategoreySN.Text == "")
                    {
                        MessageBox.Show("   اضف السريال قبل الضغط على اضافة    ", "  خطأ ");

                        textCategoreySN.Focus();
                    }
                    else
                    {

                        sqlCommand1.CommandText = "insert into CategorySN (CategorySN,CategoryBarcode,CategoryName)values ('" + textCategoreySN.Text + "','" + textBarcode.Text + "','" + comCategory.Text + "')";
                        sqlCommand1.ExecuteNonQuery();


                        GetCategoreySn();


                    }
                }
            }
        }

        private void dataGridView8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textID_SN.Text = dataGridView8.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBarcode.Text = dataGridView8.Rows[e.RowIndex].Cells[1].Value.ToString();
            comCategory.Text = dataGridView8.Rows[e.RowIndex].Cells[2].Value.ToString();
            textCategoreySN.Text = dataGridView8.Rows[e.RowIndex].Cells[3].Value.ToString();

            try
            {
                sqlCommand1.CommandText = "delete from CategorySN where ID = '" + textID_SN.Text + "'   ";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            { }

            GetCategoreySn();
        }

        private void comCategory_TextChanged(object sender, EventArgs e)
        {
            GetCategoreySn();

            //------------------------------------------------
            try
            {
                sqlCommand1.CommandText = "select * from Category where Category like'" + comCategory.Text + "' ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    textBarcode.Text = red["Barcode"].ToString();
                    //textCategoreySN.Text = red["Category"].ToString();
                    textBox2.Text = red["Quantity"].ToString();
                    quntety = red["Quantity"].ToString();   // تخزين الكمية القديمة
                    textBox3.Text = red["QuantityT"].ToString();
                    //dateTimePicker1.Text = red["التاريخ"].ToString();
                    textBox4.Text = red["Unity"].ToString();
                    comboBox2.Text = red["Faction"].ToString();
                    textBox5.Text = red["Total"].ToString();
                    //textBox8.Text = red["Price"].ToString();
                    //textBox9.Text = red["Value"].ToString();
                    //textBox6.Text = red["Near"].ToString();
                    //textBox10.Text = red["Emwared"].ToString();
                    //comboBox3.Text = red["Available"].ToString();
                    //comCatGroup.Text = red["Group_Name"].ToString();




                }
                red.Close();
            }
            catch
            {

            }
        }
    }
}
