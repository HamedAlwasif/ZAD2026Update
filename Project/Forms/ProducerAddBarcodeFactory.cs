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
    public partial class ProducerAddBarcodeFactory : Form
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
        private SqlDataReader reeeed;
        private SqlDataReader red;

        int NumSnCategorey = 0;
        public ProducerAddBarcodeFactory()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void ProducerAddBarcodeFactory_Load(object sender, EventArgs e)
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

        private void butSearch_Click(object sender, EventArgs e)
        {
            textBarcode2.Text = "";
            textCategory2.Text = "";

            panel2.Visible = false;


            // GetCategoreySn();

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
                textCategoreyBarcode_Factory.Text = reeeed["Barcode_Factory"].ToString();
                textCategoreyBarcode_Factory2.Text = reeeed["Barcode_Factory"].ToString();




            }
            red.Close();
        }

        private void comCategory_TextChanged(object sender, EventArgs e)
        {
            textBarcode2.Text = "";
            textCategory2.Text ="";

            panel2.Visible = false;


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
                    textCategoreyBarcode_Factory.Text = red["Barcode_Factory"].ToString();
                    textCategoreyBarcode_Factory2.Text = red["Barcode_Factory"].ToString();




                }
                red.Close();
            }
            catch
            {

            }

           
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            textBarcode2.Text = "";
            textCategory2.Text = "";

            panel2.Visible = false;

            try
            {

                sqlCommand1.CommandText = "select * from Category where Barcode_Factory ='" + textCategoreyBarcode_Factory.Text + "' ";
                reeeed = sqlCommand1.ExecuteReader();
                while (reeeed.Read())
                {

                    textBarcode2.Text = reeeed["Barcode"].ToString();
                    textCategory2.Text = reeeed["Category"].ToString();
                }
                reeeed.Close();

                //-------------------------------------------

                if (textBarcode2.Text != "")
                {
                    panel2.Visible = true;

                    MessageBox.Show("        هذا الباركود موجود من قبل ولا يمكن اضافة لصنف اخر     ", "خطأ تكرار باركود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    panel2.Visible = false;

                    sqlCommand1.CommandText = "update Category set Barcode_Factory = '" + textCategoreyBarcode_Factory.Text + "' where Barcode = '" + textBarcode.Text + "'";
                    sqlCommand1.ExecuteNonQuery();

                    MessageBox.Show("        تم اضافة باركود المصنع بنجاح     ", " باركود", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch
            { }

        }
    }
}
