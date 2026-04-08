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
    public partial class PriceViewer : Form
    {
        private readonly string cn =
            ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        public PriceViewer()
        {
            InitializeComponent();
            SetupUi();
            // WireEvents();
        }

        private void PriceViewer_Load(object sender, EventArgs e)
        {
            //-----------------   ايجاد الاصناف الموجودة فقط --------------------
            SqlDataAdapter Da122;
            DataTable Dt122 = new DataTable();
            Da122 = new SqlDataAdapter("select Category from Category where Total > '" + 0 + "'", cn);
            Da122.Fill(Dt122);
            ComCategoryName.DataSource = Dt122;
            ComCategoryName.DisplayMember = "Category";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcodeScanner.Clear();
            txtBarcodeManual.Clear();
            // ComCategoryName.Clear();

            txtPrice.Text = "—";
            txtlItemName.Text = "";

            txtBarcodeScanner.Focus();
        }

        private void SetupUi()
        {
            txtPrice.Font = new Font("Times New Roman", 80, FontStyle.Bold);
            txtPrice.Text = "—";

            txtlItemName.Font = new Font("Times New Roman", 24, FontStyle.Bold);
            txtlItemName.Text = "";

            txtBarcodeScanner.Focus();
        }


        private void SearchByName(string categoryName)
        {
            txtlItemName.Text = "";
            txtBarcod.Text = "";

            txtPrice.Text = "0";
            txtQut.Text = "";


            //================================

            categoryName = (categoryName ?? "").Trim();
            if (categoryName == "") return;

            const string sql = @" SELECT TOP 1 Barcode, Category, PriceMostahlek,Total FROM Category WHERE Category LIKE @Name ORDER BY Category;";

            using (SqlConnection con = new SqlConnection(cn))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = "%" + categoryName + "%";

                con.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        string barcode = r["Barcode"]?.ToString() ?? "";
                        string name = r["Category"]?.ToString() ?? "";
                        string priceText = r["PriceMostahlek"]?.ToString() ?? "0";
                        string Qunt = r["Total"]?.ToString() ?? "0";
                        txtlItemName.Text = name;
                        txtPrice.Text = FormatPrice(priceText);

                        // اختياري: املأ الباركود اليدوي
                        txtBarcodeManual.Text = barcode;
                        txtBarcod.Text = barcode;

                        txtQut.Text = Qunt;
                    }
                    else
                    {
                        txtBarcod.Text = "";
                        txtlItemName.Text = "الصنف غير موجود";
                        txtPrice.Text = "—";
                        txtQut.Text = "";
                    }
                }
            }
        }

        private void SearchByBarcode(string barcode)
        {
            txtlItemName.Text = "";
            txtBarcod.Text = "";
            txtPrice.Text = "0";
            txtQut.Text = "";

            //================================



            barcode = (barcode ?? "").Trim();
            if (barcode == "") return;

            const string sql = @"SELECT TOP 1 Category, PriceMostahlek ,Barcode,Total FROM Category WHERE Barcode = @Barcode;";

            using (SqlConnection con = new SqlConnection(cn))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = barcode;

                con.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        string name = r["Category"]?.ToString() ?? "";
                        string Barcode = r["Barcode"]?.ToString() ?? "";
                        string priceText = r["PriceMostahlek"]?.ToString() ?? "0";
                        string Qunt = r["Total"]?.ToString() ?? "0";


                        txtlItemName.Text = name;
                        txtBarcod.Text = Barcode;
                        txtPrice.Text = FormatPrice(priceText);
                        txtQut.Text = Qunt;

                        // اختياري: املأ الاسم
                        ComCategoryName.Text = name;
                    }
                    else
                    {
                        txtlItemName.Text = "الصنف غير موجود";
                        txtPrice.Text = "—";
                        txtBarcod.Text = "";
                        txtQut.Text = "";
                    }
                }
            }
        }

        private string FormatPrice(string priceText)
        {
            // يدعم لو السعر decimal/float داخل الداتا
            if (decimal.TryParse(priceText, out var p))
                return p.ToString("0.##") + " ج";
            return priceText;
        }

        private void btnSearchScanner_Click(object sender, EventArgs e)
        {
            SearchByBarcode(txtBarcodeScanner.Text);
        }

        private void btnSearchManual_Click(object sender, EventArgs e)
        {
            SearchByBarcode(txtBarcodeManual.Text);
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            SearchByName(ComCategoryName.Text);
        }

        private void txtBarcodeScanner_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SearchByBarcode(txtBarcodeScanner.Text);
            //}


            //// حدّد النص كله عشان القراءة الجاية تستبدله
            //txtBarcodeScanner.SelectAll();

            // txtBarcodeScanner.Focus();

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // نفّذ البحث
                SearchByBarcode(txtBarcodeScanner.Text);

                // حدّد النص كله عشان القراءة الجاية تستبدله
                txtBarcodeScanner.SelectAll();
            }
        }

        private void ComCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByName(ComCategoryName.Text);
        }
        private void checkradio()
        {
            if (radBut1.Checked == true)
            {
                label1.Visible = true;
                txtBarcodeScanner.Visible = true;
              //  btnSearchScanner.Visible = true;


                label2.Visible = false;
                txtBarcodeManual.Visible = false;
                btnSearchManual.Visible = false;


                label3.Visible = false;
                ComCategoryName.Visible = false;
                btnSearchName.Visible = false;


            }
            else if (radBut2.Checked==true)
            {
                label1.Visible = false;
                txtBarcodeScanner.Visible = false;
                btnSearchScanner.Visible = false;


                label2.Visible = true;
                txtBarcodeManual.Visible = true;
                btnSearchManual.Visible = true;


                label3.Visible = false;
                ComCategoryName.Visible = false;
                btnSearchName.Visible = false;
            }
            else if (radBut3.Checked==true)
            {
                label1.Visible = false;
                txtBarcodeScanner.Visible = false;
                btnSearchScanner.Visible = false;


                label2.Visible = false;
                txtBarcodeManual.Visible = false;
                btnSearchManual.Visible = false;


                label3.Visible = true;
                ComCategoryName.Visible = true;
                btnSearchName.Visible = true;
            }
            else
            {

            }
        }
        private void radBut1_CheckedChanged(object sender, EventArgs e)
        {
            checkradio();
        }

        private void radBut2_CheckedChanged(object sender, EventArgs e)
        {
            checkradio();
        }

        private void radBut3_CheckedChanged(object sender, EventArgs e)
        {
            checkradio();
        }
    }
}
