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
using System.Drawing.Printing;
using System.IO;
using System.Media;
using Microsoft.Reporting.WinForms;

namespace ZAD_Sales.Forms
{
    public partial class FrmBillingSummary : Form
    {

        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        
        string LimitCredit = AppSetting.UseLimitCredit;
        string AllowUser = AppSetting.AllowUser;
        string DiscountBill = AppSetting.DiscountBill;
        string BarcodeSales = AppSetting.BarcodeSales;
        string BarcodeSalesType = AppSetting.BarcodeSalesType;

        string CollectionProduct = AppSetting.CollectionProduct;
        string HideBalance = AppSetting.HideBalance;
        //----------------------

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        DataTable dt12 = new DataTable();
        //--------------------------------
        SqlCommandBuilder cmdb;
        SqlDataAdapter adap;
        DataSet ds;

        ReportDataSource rs = new ReportDataSource();

        public FrmBillingSummary()
        {
            InitializeComponent();

            if (cn.State == System.Data.ConnectionState.Closed)
                cn.Open();

            //  cn.Open();
          //  sqlCommand1.Connection = cn;
        }
        //dgvBillingSummary.Columns["Name"].HeaderText = "اسم العميل";
        //    dgvBillingSummary.Columns["TotalBill"].HeaderText = "المبيعات";
        //    dgvBillingSummary.Columns["Discount"].HeaderText = "خصم مبيعات";
        //    dgvBillingSummary.Columns["TotalBillBuy"].HeaderText = "المشتريات";
        //    dgvBillingSummary.Columns["DiscountBuy"].HeaderText = "خصم المشتريات";
        //    dgvBillingSummary.Columns["TotalBillInvalid"].HeaderText = "مردودات المبيعات";
        //    dgvBillingSummary.Columns["TotalBillBuyInvalid"].HeaderText = "مردودات مشتريات";
            
        //    dgvBillingSummary.Columns["Pay"].HeaderText = "دفع";
        //    dgvBillingSummary.Columns["Paid"].HeaderText = "تحصيل";
        //    dgvBillingSummary.Columns["Remaining"].HeaderText = "المتبقي";
        public class ClassFrmBillingSummary
        {

            public string Name { get; set; }
            public string TotalBill { get; set; }
            public string Discount { get; set; }
            public string TotalBillBuy { get; set; }
            public string DiscountBuy { get; set; }
            public string TotalBillInvalid { get; set; }
            public string TotalBillBuyInvalid { get; set; }
            public string Pay { get; set; }

            public string Paid { get; set; }

            public string Remaining { get; set; }

          

        }
        private void FillFooterTotals(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                txtTotalSales.Text = "0";
                txtTotalPaid.Text = "0";
                txtTotalRemaining.Text = "0";
                return;
            }

            decimal totalSales = dt.AsEnumerable()
                .Where(r => r["TotalBill"] != DBNull.Value)
                .Sum(r => Convert.ToDecimal(r["TotalBill"]));

            decimal totalPaid = dt.AsEnumerable()
                .Where(r => r["Paid"] != DBNull.Value)
                .Sum(r => Convert.ToDecimal(r["Paid"]));

            decimal totalRemaining = dt.AsEnumerable()
                .Where(r => r["Remaining"] != DBNull.Value)
                .Sum(r => Convert.ToDecimal(r["Remaining"]));

            txtTotalSales.Text = totalSales.ToString("N0");
            txtTotalPaid.Text = totalPaid.ToString("N0");
            txtTotalRemaining.Text = totalRemaining.ToString("N0");
        }


        private void FrmBillingSummary_Load(object sender, EventArgs e)
        {





            FormatFooterTextBox(txtTotalSales);
            FormatFooterTextBox(txtTotalPaid);
            FormatFooterTextBox(txtTotalRemaining);
            FormatFooterTextBox(txtTotalBuy);
            FormatFooterTextBox(txtSalesInvalid);
            FormatFooterTextBox(txtBuyInvalid);
            FormatFooterTextBox(txtDiscountSales);
            FormatFooterTextBox(txtDiscountBuy);
            FormatFooterTextBox(txtTotalPay);


            FillOrderByCombo();


            ReloadReport();

           // LoadBillingSummary();

            ////  تنسيقات الفورم

            //this.RightToLeft = RightToLeft.Yes;
            //this.RightToLeftLayout = true;
            //this.Font = new Font("Segoe UI", 10);
            //this.StartPosition = FormStartPosition.CenterScreen;

            ////-----------------------------------------


            //// تنسيقات txtGrandTotal

            //txtGrandTotal.ReadOnly = true;
            //txtGrandTotal.TextAlign = HorizontalAlignment.Center;
            //txtGrandTotal.BackColor = Color.LightYellow;
            //txtGrandTotal.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            ////---------------------------------------

            //// تنسيق زر البحث

            //btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            //btnSearch.ForeColor = Color.White;
            //btnSearch.FlatStyle = FlatStyle.Flat;


            //FormatGrid();
            //FillGrandTotalTextBox();
        }

        //private void FillGrandTotalTextBox()
        //{
        //    if (dgvBillingSummary.Rows.Count == 0) return;

        //    int lastRow = dgvBillingSummary.Rows.Count - 1;

        //    txtGrandTotal.Text = Convert.ToDecimal(
        //        dgvBillingSummary.Rows[lastRow].Cells["TotalBill"].Value
        //    ).ToString("N0");
        //}



        private void FormatGrid()
        {
            dgvBillingSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillingSummary.ReadOnly = true;
            dgvBillingSummary.AllowUserToAddRows = false;
            dgvBillingSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ===== توسيع عمود الاسم =====
            dgvBillingSummary.Columns["Name"].FillWeight = 200; // أكبر من باقي الأعمدة
            dgvBillingSummary.Columns["Name"].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            //  dgvBillingSummary.Columns["Name"].DefaultCellStyle.Font = new Font(dgvBillingSummary.Font, FontStyle.Bold);

            // dgvBillingSummary.Columns["Name"].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleRight;

            string[] numericCols =
            {
            "TotalBill","TotalBillBuy","DiscountBuy",
            "TotalBillInvalid","TotalBillBuyInvalid",
            "Discount","Pay","Paid","Remaining"
        };

            foreach (string col in numericCols)
            {
                dgvBillingSummary.Columns[col].FillWeight = 80; // عرض أقل
                dgvBillingSummary.Columns[col].DefaultCellStyle.Format = "N0"; // بدون كسور
                dgvBillingSummary.Columns[col].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            // ===== العناوين =====
            dgvBillingSummary.Columns["Name"].HeaderText = "اسم العميل";
            dgvBillingSummary.Columns["TotalBill"].HeaderText = "المبيعات";
            dgvBillingSummary.Columns["Discount"].HeaderText = "خصم مبيعات";
            dgvBillingSummary.Columns["TotalBillBuy"].HeaderText = "المشتريات";
            dgvBillingSummary.Columns["DiscountBuy"].HeaderText = "خصم المشتريات";
            dgvBillingSummary.Columns["TotalBillInvalid"].HeaderText = "مردودات المبيعات";
            dgvBillingSummary.Columns["TotalBillBuyInvalid"].HeaderText = "مردودات مشتريات";
            
            dgvBillingSummary.Columns["Pay"].HeaderText = "دفع";
            dgvBillingSummary.Columns["Paid"].HeaderText = "تحصيل";
            dgvBillingSummary.Columns["Remaining"].HeaderText = "المتبقي";

            // ===== تمييز صف الإجمالي =====
            //int lastRow = dgvBillingSummary.Rows.Count - 1;
            //dgvBillingSummary.Rows[lastRow].DefaultCellStyle.BackColor = Color.LightGray;
            //dgvBillingSummary.Rows[lastRow].DefaultCellStyle.Font =
            //    new Font(dgvBillingSummary.Font, FontStyle.Bold);
        }


        //void FormatFooterTextBox(TextBox txt)
        //{
        //    txt.ReadOnly = true;
        //    txt.TextAlign = HorizontalAlignment.Center;
        //    txt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    txt.BackColor = Color.LightYellow;
        //}


        private void FormatFooterTextBox(TextBox txt)
        {
            txt.ReadOnly = true;
            txt.TextAlign = HorizontalAlignment.Center;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.WhiteSmoke;
            txt.ForeColor = Color.Black;
            txt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            txt.TabStop = false;
        }


        //private void FormatGrid()
        //{
        //    dgvBillingSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvBillingSummary.ReadOnly = true;
        //    dgvBillingSummary.AllowUserToAddRows = false;
        //    dgvBillingSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        //    // ===== توسيع عمود الاسم =====
        //    dgvBillingSummary.Columns["Name"].FillWeight = 200; // أكبر من باقي الأعمدة
        //    dgvBillingSummary.Columns["Name"].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        //    //  dgvBillingSummary.Columns["Name"].DefaultCellStyle.Font = new Font(dgvBillingSummary.Font, FontStyle.Bold);

        //    // dgvBillingSummary.Columns["Name"].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleRight;

        //    string[] numericCols =
        //    {
        //        "TotalBill","TotalBillBuy","DiscountBuy",
        //        "TotalBillInvalid","TotalBillBuyInvalid",
        //        "Discount","Pay","Paid","Remaining"
        //    };

        //    foreach (string col in numericCols)
        //    {
        //        dgvBillingSummary.Columns[col].FillWeight = 80;
        //        dgvBillingSummary.Columns[col].DefaultCellStyle.Format = "N0";
        //        dgvBillingSummary.Columns[col].DefaultCellStyle.Alignment =
        //            DataGridViewContentAlignment.MiddleCenter;
        //    }

        //    dgvBillingSummary.Columns["Name"].FillWeight = 200;
        //    dgvBillingSummary.Columns["Name"].HeaderText = "اسم العميل";

        //    // ✅ تمييز صف الإجمالي بالاسم
        //    foreach (DataGridViewRow row in dgvBillingSummary.Rows)
        //    {
        //        if (row.Cells["Name"].Value?.ToString() == "الإجمالي")
        //        {
        //            row.DefaultCellStyle.BackColor = Color.LightGray;
        //            row.DefaultCellStyle.Font =
        //                new Font(dgvBillingSummary.Font, FontStyle.Bold);
        //            break;
        //        }
        //    }
        //}

        private void LoadBillingSummary(int? topCount = null)
        {
            string orderByColumn = GetOrderByColumn();

            string query = $@"
                            SELECT {(topCount.HasValue ? "TOP (@TopCount)" : "")}
                                Name,
                                SUM(TotalBill) AS TotalBill,
                                SUM(TotalBillBuy) AS TotalBillBuy,
                                SUM(DiscountBuy) AS DiscountBuy,
                                SUM(TotalBillInvalid) AS TotalBillInvalid,
                                SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
                                SUM(Discount) AS Discount,
                                SUM(Pay) AS Pay,
                                SUM(Paid) AS Paid,
                                SUM(TotalBill) - SUM(Paid) AS Remaining
                            FROM BillingData
                            WHERE [Date] >= @DateFrom
                              AND [Date] < DATEADD(DAY, 1, @DateTo)
                            GROUP BY Name
                            ORDER BY {orderByColumn} DESC;";

            DataTable dt = new DataTable();

           // using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime)
                    .Value = dtpDateFrom.Value.Date;

                cmd.Parameters.Add("@DateTo", SqlDbType.DateTime)
                    .Value = dtpDateTo.Value.Date;

                if (topCount.HasValue)
                    cmd.Parameters.Add("@TopCount", SqlDbType.Int).Value = topCount.Value;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dgvBillingSummary.DataSource = dt;
            FormatGrid();
            FillFooterTotals(dt);
            CalculateFooterTotals();


        }

        //private void LoadBillingSummary(int? topCount = null)
        //{
        //    string query = topCount.HasValue
        //        ? @"
        //        SELECT TOP (@TopCount)
        //            Name,
        //            SUM(TotalBill) AS TotalBill,
        //            SUM(TotalBillBuy) AS TotalBillBuy,
        //            SUM(DiscountBuy) AS DiscountBuy,
        //            SUM(TotalBillInvalid) AS TotalBillInvalid,
        //            SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //            SUM(Discount) AS Discount,
        //            SUM(Pay) AS Pay,
        //            SUM(Paid) AS Paid,
        //            SUM(TotalBill) - SUM(Paid) AS Remaining
        //        FROM BillingData
        //        WHERE [Date] >= @DateFrom
        //          AND [Date] <  DATEADD(DAY, 1, @DateTo)
        //        GROUP BY Name
        //        ORDER BY SUM(TotalBill) DESC;"
        //        : @"
        //        SELECT
        //            Name,
        //            SUM(TotalBill) AS TotalBill,
        //            SUM(TotalBillBuy) AS TotalBillBuy,
        //            SUM(DiscountBuy) AS DiscountBuy,
        //            SUM(TotalBillInvalid) AS TotalBillInvalid,
        //            SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //            SUM(Discount) AS Discount,
        //            SUM(Pay) AS Pay,
        //            SUM(Paid) AS Paid,
        //            SUM(TotalBill) - SUM(Paid) AS Remaining
        //        FROM BillingData
        //        WHERE [Date] >= @DateFrom
        //          AND [Date] <  DATEADD(DAY, 1, @DateTo)
        //        GROUP BY Name
        //        ORDER BY SUM(TotalBill) DESC;";

        //    //string query = topCount.HasValue
        //    //? @"
        //    //    SELECT TOP (@TopCount)
        //    //        Name,
        //    //        SUM(TotalBill) AS TotalBill,
        //    //        SUM(Discount) AS Discount,
        //    //        SUM(TotalBillBuy) AS TotalBillBuy,
        //    //        SUM(DiscountBuy) AS DiscountBuy,
        //    //        SUM(TotalBillInvalid) AS TotalBillInvalid,
        //    //        SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //    //        SUM(Pay) AS Pay,
        //    //        SUM(Paid) AS Paid,
        //    //        SUM(TotalBill) - SUM(Paid) AS Remaining
        //    //    FROM BillingData
        //    //    GROUP BY Name
        //    //    ORDER BY SUM(TotalBill) DESC;"
        //    //            : @"
        //    //    SELECT
        //    //        Name,
        //    //        SUM(TotalBill) AS TotalBill,
        //    //        SUM(Discount) AS Discount,
        //    //        SUM(TotalBillBuy) AS TotalBillBuy,
        //    //        SUM(DiscountBuy) AS DiscountBuy,
        //    //        SUM(TotalBillInvalid) AS TotalBillInvalid,
        //    //        SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //    //        SUM(Pay) AS Pay,
        //    //        SUM(Paid) AS Paid,
        //    //        SUM(TotalBill) - SUM(Paid) AS Remaining
        //    //    FROM BillingData
        //    //    GROUP BY Name
        //    //    ORDER BY SUM(TotalBill) DESC;";

        //    DataTable dt = new DataTable();

        //   // using (SqlConnection con = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, cn))
        //    {
        //        // ✅ التواريخ (مهم جدًا)

        //        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime)
        //    .Value = dtpDateFrom.Value.Date;

        //        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime)
        //            .Value = dtpDateTo.Value.Date;


        //        if (topCount.HasValue)
        //            cmd.Parameters.Add("@TopCount", SqlDbType.Int).Value = topCount.Value;

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);


        //    }

        //    // ===== إضافة صف الإجمالي الحقيقي =====
        // //   AddTotalRow(dt);

        //    dgvBillingSummary.DataSource = dt;
        //    FormatGrid();
        //  //  FillFooterTotals(dt);

        //    CalculateFooterTotals();
        //}


        private void AddTotalRow(DataTable dt)
        {
            if (dt.Rows.Count == 0) return;

            DataRow totalRow = dt.NewRow();
            totalRow["Name"] = "الإجمالي";

            string[] numericCols =
            {
                "TotalBill","TotalBillBuy","DiscountBuy",
                "TotalBillInvalid","TotalBillBuyInvalid",
                "Discount","Pay","Paid","Remaining"
            };

            foreach (string col in numericCols)
            {
                totalRow[col] = dt.AsEnumerable()
                    .Where(r => r[col] != DBNull.Value)
                    .Sum(r => Convert.ToDecimal(r[col]));
            }

            dt.Rows.Add(totalRow);
        }

        //----------- دالة حساب  كل الإجماليات
        private void CalculateFooterTotals()
        {
            decimal totalSales = 0;
            decimal totalPaid = 0; 
            decimal totalRemaining = 0;
            decimal totalBuy = 0;
            decimal salesInvalid = 0;
            decimal buyInvalid = 0;
            decimal discountSales = 0;
            decimal discountBuy = 0;
            decimal totalPay = 0;
            foreach (DataGridViewRow row in dgvBillingSummary.Rows)
            {
                if (row.IsNewRow) continue;

                totalSales += Convert.ToDecimal(row.Cells["TotalBill"].Value ?? 0);
                totalPaid += Convert.ToDecimal(row.Cells["Paid"].Value ?? 0);
                totalPay += Convert.ToDecimal(row.Cells["Pay"].Value ?? 0);
                totalRemaining += Convert.ToDecimal(row.Cells["Remaining"].Value ?? 0);
                totalBuy += Convert.ToDecimal(row.Cells["TotalBillBuy"].Value ?? 0);
                salesInvalid += Convert.ToDecimal(row.Cells["TotalBillInvalid"].Value ?? 0);
                buyInvalid += Convert.ToDecimal(row.Cells["TotalBillBuyInvalid"].Value ?? 0);
                discountSales += Convert.ToDecimal(row.Cells["Discount"].Value ?? 0);
                discountBuy += Convert.ToDecimal(row.Cells["DiscountBuy"].Value ?? 0);
            }

            // عرض القيم بدون كسور
            txtTotalSales.Text = totalSales.ToString("N0");
            txtTotalPaid.Text = totalPaid.ToString("N0");
            txtTotalPay.Text = totalPay.ToString("N0");
            txtTotalRemaining.Text = totalRemaining.ToString("N0");
            txtTotalBuy.Text = totalBuy.ToString("N0");
            txtSalesInvalid.Text = salesInvalid.ToString("N0");
            txtBuyInvalid.Text = buyInvalid.ToString("N0");
            txtDiscountSales.Text = discountSales.ToString("N0");
            txtDiscountBuy.Text = discountBuy.ToString("N0");
        }


        private void FillOrderByCombo()
        {
            cmbOrderBy.Items.Add("إجمالي المبيعات");
            cmbOrderBy.Items.Add("إجمالي التحصيل");
            cmbOrderBy.Items.Add("إجمالي المتبقي");
            cmbOrderBy.Items.Add("إجمالي المشتريات");
            cmbOrderBy.Items.Add("مردودات المبيعات");
            cmbOrderBy.Items.Add("مردودات المشتريات");
            cmbOrderBy.Items.Add("خصم المشتريات");
            cmbOrderBy.Items.Add("خصم المبيعات");

            cmbOrderBy.SelectedIndex = 0; // افتراضي
        }

        private string GetOrderByColumn()
        {
            switch (cmbOrderBy.SelectedItem.ToString())
            {
                case "إجمالي المبيعات":
                    return "SUM(TotalBill)";
                case "إجمالي التحصيل":
                    return "SUM(Paid)";
                case "إجمالي المتبقي":
                    return "SUM(TotalBill) - SUM(Paid)";
                case "إجمالي المشتريات":
                    return "SUM(TotalBillBuy)";
                case "مردودات المبيعات":
                    return "SUM(TotalBillInvalid)";
                case "مردودات المشتريات":
                    return "SUM(TotalBillBuyInvalid)";
                case "خصم المشتريات":
                    return "SUM(DiscountBuy)";
                case "خصم المبيعات":
                    return "SUM(Discount)";
                default:
                    return "SUM(TotalBill)";
            }
        }



        //private void FormatGrid()
        //{
        //    dgvBillingSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvBillingSummary.ReadOnly = true;
        //    dgvBillingSummary.AllowUserToAddRows = false;
        //    dgvBillingSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        //    string[] numericCols =
        //    {
        //        "TotalBill","TotalBillBuy","DiscountBuy",
        //        "TotalBillInvalid","TotalBillBuyInvalid",
        //        "Discount","Pay","Paid","Remaining"
        //     };

        //    foreach (string col in numericCols)
        //    {
        //        dgvBillingSummary.Columns[col].DefaultCellStyle.Format = "N0"; // بدون كسور
        //        dgvBillingSummary.Columns[col].DefaultCellStyle.Alignment =
        //            DataGridViewContentAlignment.MiddleCenter;
        //    }

        //    dgvBillingSummary.Columns["Name"].HeaderText = "اسم العميل";
        //    dgvBillingSummary.Columns["TotalBill"].HeaderText = "المبيعات";
        //    dgvBillingSummary.Columns["TotalBillBuy"].HeaderText = "المشتريات";
        //    dgvBillingSummary.Columns["DiscountBuy"].HeaderText = "خصم المشتريات";
        //    dgvBillingSummary.Columns["TotalBillInvalid"].HeaderText = "مردودات المبيعات";
        //    dgvBillingSummary.Columns["TotalBillBuyInvalid"].HeaderText = "مردودات مشتريات";
        //    dgvBillingSummary.Columns["Discount"].HeaderText = "خصم مبيعات";
        //    dgvBillingSummary.Columns["Pay"].HeaderText = "دفع";
        //    dgvBillingSummary.Columns["Paid"].HeaderText = "تحصيل";
        //    dgvBillingSummary.Columns["Remaining"].HeaderText = "المتبقي";


        //    // تمييز صف الإجمالي
        //    int lastRow = dgvBillingSummary.Rows.Count - 1;
        //    dgvBillingSummary.Rows[lastRow].DefaultCellStyle.BackColor = Color.LightGray;
        //    dgvBillingSummary.Rows[lastRow].DefaultCellStyle.Font =
        //        new Font(dgvBillingSummary.Font, FontStyle.Bold);
        //}
        //private void LoadBillingSummary(int? topCount = null)
        //{
        //    string query = topCount.HasValue
        //    ? @"
        //        SELECT TOP (@TopCount)
        //            Name,
        //            SUM(TotalBill) AS TotalBill,
        //            SUM(TotalBillBuy) AS TotalBillBuy,
        //            SUM(DiscountBuy) AS DiscountBuy,
        //            SUM(TotalBillInvalid) AS TotalBillInvalid,
        //            SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //            SUM(Discount) AS Discount,
        //            SUM(Pay) AS Pay,
        //            SUM(Paid) AS Paid,
        //            SUM(TotalBill) - SUM(Paid) AS Remaining
        //        FROM BillingData
        //        WHERE [Date] >= @DateFrom
        //          AND [Date] <= @DateTo
        //        GROUP BY Name
        //        ORDER BY SUM(TotalBill) DESC;"
        //    : @"
        //        SELECT
        //            Name,
        //            SUM(TotalBill) AS TotalBill,
        //            SUM(TotalBillBuy) AS TotalBillBuy,
        //            SUM(DiscountBuy) AS DiscountBuy,
        //            SUM(TotalBillInvalid) AS TotalBillInvalid,
        //            SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //            SUM(Discount) AS Discount,
        //            SUM(Pay) AS Pay,
        //            SUM(Paid) AS Paid,
        //            SUM(TotalBill) - SUM(Paid) AS Remaining
        //        FROM BillingData
        //        WHERE [Date] >= @DateFrom
        //          AND [Date] <= @DateTo
        //        GROUP BY Name
        //        ORDER BY SUM(TotalBill) DESC;";

        //   // using (SqlConnection con = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, cn))
        //    {
        //        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime)
        //            .Value = DateTime.Today.AddYears(-100); // أو الفترة الحالية

        //        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime)
        //            .Value = DateTime.Today.AddDays(1).AddSeconds(-1);

        //        if (topCount.HasValue)
        //            cmd.Parameters.Add("@TopCount", SqlDbType.Int).Value = topCount.Value;

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        dgvBillingSummary.DataSource = dt;
        //    }

        //    FormatGrid();
        //}


        //private void LoadBillingSummary()
        //{
        //    string query = @"
        //                        SELECT
        //                            Name,
        //                            SUM(TotalBill) AS TotalBill,
        //                            SUM(TotalBillBuy) AS TotalBillBuy,
        //                            SUM(DiscountBuy) AS DiscountBuy,
        //                            SUM(TotalBillInvalid) AS TotalBillInvalid,
        //                            SUM(TotalBillBuyInvalid) AS TotalBillBuyInvalid,
        //                            SUM(Discount) AS Discount,
        //                            SUM(Pay) AS Pay,
        //                            SUM(Paid) AS Paid,
        //                            SUM(TotalBill) - SUM(Paid) AS Remaining
        //                        FROM BillingData
        //                        WHERE [Date] >= @DateFrom
        //                          AND [Date] <= @DateTo
        //                        GROUP BY Name
        //                        ORDER BY SUM(TotalBill) DESC;
        //                        ";



        //    //  using (SqlConnection con = new SqlConnection(connectionString))
        //    using (SqlCommand cmd = new SqlCommand(query, cn))
        //    {
        //        cmd.Parameters.Add("@DateFrom", SqlDbType.DateTime).Value =
        //            dtpDateFrom.Value.Date;

        //        cmd.Parameters.Add("@DateTo", SqlDbType.DateTime).Value =
        //            dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        // ===== إضافة صف الإجمالي =====
        //        DataRow totalRow = dt.NewRow();
        //        totalRow["Name"] = "الإجمالي";

        //        string[] numericCols =
        //        {
        //            "TotalBill","TotalBillBuy","DiscountBuy",
        //            "TotalBillInvalid","TotalBillBuyInvalid",
        //            "Discount","Pay","Paid","Remaining"
        //         };

        //        foreach (string col in numericCols)
        //        {
        //            totalRow[col] = dt.AsEnumerable()
        //                .Where(r => r[col] != DBNull.Value)
        //                .Sum(r => Convert.ToDecimal(r[col]));
        //        }

        //        dt.Rows.Add(totalRow);

        //        dgvBillingSummary.DataSource = dt;
        //    }

        //    FormatGrid();
        //    FillGrandTotalTextBox();
        //}


        private void btnSearch_Click(object sender, EventArgs e)
        {

            ReloadReport();


            // LoadBillingSummary();

            //FormatGrid();
            //FillGrandTotalTextBox();

        }

        private void txtTopCount_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtTopCount.Text))
            //{
            //    LoadBillingSummary(); // عرض الكل
            //    return;
            //}

            //if (int.TryParse(txtTopCount.Text, out int topCount) && topCount > 0)
            //{
            //    LoadBillingSummary(topCount);
            //}
        }

        private bool IsValidDateRange()
        {
            return dtpDateFrom.Value.Date <= dtpDateTo.Value.Date;
        }

        private int? GetTopCount()
        {
            if (int.TryParse(txtTopCount.Text, out int value) && value > 0)
                return value;

            return null; // بدون TOP
        }


        private void ReloadReport()
        {
            if (!IsValidDateRange())
                return;

            int? topCount = GetTopCount();
            LoadBillingSummary(topCount);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFromDate_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTopCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadBillingSummary();

            ReloadReport();

        }

        private void txtTopCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReloadReport();
                e.SuppressKeyPress = true;
            }
        }


      
        private void butPrint_Click(object sender, EventArgs e)
        {



            try
            {

                //-----------------------
                AppSetting.date_From = dtpDateFrom.Text;
                AppSetting.date_To = dtpDateTo.Text;

                List<ClassFrmBillingSummary> BM = new List<ClassFrmBillingSummary>();
                BM.Clear();
                for (int i = 0; i < dgvBillingSummary.Rows.Count; i++)
                {
                    //public int Name { get; set; }
                    //public string TotalBill { get; set; }
                    //public string Discount { get; set; }
                    //public string TotalBillBuy { get; set; }
                    //public string DiscountBuy { get; set; }
                    //public double TotalBillInvalid { get; set; }
                    //public double TotalBillBuyInvalid { get; set; }
                    //public double Pay { get; set; }

                    //public double Paid { get; set; }

                    //public double Remaining { get; set; }

                    ClassFrmBillingSummary BillingSummary = new ClassFrmBillingSummary
                    {

                        Name = dgvBillingSummary.Rows[i].Cells[0].Value.ToString(),
                        TotalBill = dgvBillingSummary.Rows[i].Cells[1].Value.ToString(),
                        Discount = dgvBillingSummary.Rows[i].Cells[2].Value.ToString(),
                        TotalBillBuy = dgvBillingSummary.Rows[i].Cells[3].Value.ToString(),
                        DiscountBuy = dgvBillingSummary.Rows[i].Cells[4].Value.ToString(),
                        TotalBillInvalid = dgvBillingSummary.Rows[i].Cells[5].Value.ToString(),
                        TotalBillBuyInvalid = dgvBillingSummary.Rows[i].Cells[6].Value.ToString(),
                        Pay = dgvBillingSummary.Rows[i].Cells[7].Value.ToString(),
                        Paid = dgvBillingSummary.Rows[i].Cells[8].Value.ToString(),
                        Remaining = dgvBillingSummary.Rows[i].Cells[9].Value.ToString(),


                     };

                    BM.Add(BillingSummary);
                }

                rs.Name = "DsBillingSummary";
                rs.Value = BM;
                Reports.Frm_BillingSummaryReport rbm = new Reports.Frm_BillingSummaryReport();
                rbm.reportViewer1.LocalReport.DataSources.Clear();
                rbm.reportViewer1.LocalReport.DataSources.Add(rs);
               // rbm.reportViewer2.Visible = false;
                rbm.ShowDialog();



                //rs.Name = "DataSet1";
                //rs.Value = BM;
                //Reports.ReportBoxMovement rbm = new Reports.ReportBoxMovement();
                //rbm.reportViewer1.LocalReport.DataSources.Clear();
                //rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                ////rbm.reportViewer1.LocalReport.ReportEmbeddedResource = "إدارة المخازن.Reports.ReportBox.rdlc";
                //rbm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("  تأكده من اختيارك الفترة الصحيحة     ", "  خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
