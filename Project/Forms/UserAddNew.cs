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
    public partial class UserAddNew : Form
    {
        long currentUserId = 0;

        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public UserAddNew()
        {
            InitializeComponent();
        }
        //-------- تحميل المستخدمين
        void LoadUsers()
        {
            cmbUsers.Items.Clear();

          //  SqlConnection con = new SqlConnection("YOUR_CONNECTION_STRING");
            SqlCommand cmd = new SqlCommand("SELECT ID, UserName FROM Users", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbUsers.Items.Add(new
                {
                    Text = dr["UserName"].ToString(),
                    Value = dr["ID"]
                });
            }

            con.Close();

            cmbUsers.DisplayMember = "Text";
            cmbUsers.ValueMember = "Value";
        }

        //---- أنشئ Dictionary في أعلى الفورم:
        Dictionary<string, string> permissionsNames = new Dictionary<string, string>()
        {
            {"Sales", "شاشة المبيعات"},
            {"Purchases", "شاشة المشتريات"},
            {"SalesReturns", "مردودات المبيعات"},
            {"PurchaseReturns", "مردودات المشتريات"},
            {"PriceViewer", "شاشة عرض ااسعار"},
            {"ProducerIncomplete", "منتجات ناقصة"},
            {"Installment", "شاشة التقسيط"},
            {"Expenses", "شاشة المصروفات"},
            {"MoneyToBox", "شاشة إضافة للخزنة"},
            {"MoneyFromBox", "شاشة سحب من الخزنة"},
            {"GroupAdd", "إضافة مجموعة"},
            
            {"ClientAdd", "إضافة عميل"},
            {"ClientsMoney", "أموال العملاء"},
           
            {"ProducerNewAdd", "إضافة منتج"},
            {"StoreNewAdd", "إضافة مخزن"},
            {"Prices", "الأسعار"},
            {"ProducerUpdate", "تعديل منتج"},
            {"Inventory", "الجرد"},
            {"Barcode", "الباركود"},

            {"Group_Name", "اضافة مجموعات للعملاء"},
            {"FactionCategoreyAdd", "اضافة فئات جديدة للاصناف"},
            {"AddSnToCategory", "اضافة سريلات للاصناف"},
            {"ProductMakeAddMateriall", "شاشة اضافة خامات التصنيع"},
            {"ProductMakeNeww", "شاشة تصنيع المنتجات"},
            {"OccasionsForm", "شاشة المناسبات"},
            {"StoreToStore", "نقل بين المخازن"},
            {"ProductMovement", "حركة المنتجات"},
            {"BoxMovement", "حركة الخزنة"},
            {"ClientsList", "قائمة العملاء"},
            {"BanksList", "قائمة البنوك"},
            {"Profits", "الأرباح"},
            {"DailySalesPurchases", "تقرير يومي"},
            {"DailyTransactions", "الحركات اليومية"},
            {"FinancialStatements", "القوائم المالية"},
            {"BankAddAccount", "إضافة حساب بنكي"},
            {"CheckSaderWared", "شيكات صادر/وارد"},
            {"CheckSave", "حفظ شيكات"},
            {"BankStatement", "كشف حساب"},
            {"BankToBank", "تحويل بنكي"},
            {"ClientAccountStatement", "كشف حساب عميل"},
            {"UserAdd1", "إضافة مستخدم"},
            {"FirstAccounts", "الحسابات الأولية"},
            {"AllowUser", "إدارة المستخدمين"},
            {"Statistical", "الاحصائيات"},
           
            
            {"ProducerAddBarcodeFactory", "اضافة باركود المصنع"},
            {"ClientsMoneyTo", "تحويل من عميل الى عميل"},
            {"DailyEvents", "الاحداث اليومية"},
            {"DailyClosing", "الختام اليومى"},
            {"StatisticalFrmBillingSummary", "تقارير اليومية"},
            {"OtherExpensesRevenues", "الختام اليومى"},
            
            {"SalesNoSave", "فاتورة غير معتمدة"},
          
            {"EmployeeAdd", "إضافة موظف"},
            {"EmployeeSalaryPayment", "صرف مرتبات"},
            {"EmployeeSalaryMovement", "حركة المرتبات"},
            {"EmployeeBonusAdd", "إضافة مكافأة"},
            {"EmployeePenaltyAdd", "إضافة جزاء"},
            {"CarsAdd", "إضافة سيارة"},
            {"CarsExpenses", "مصروفات السيارات"},
            {"CarsExpensesMovement", "حركة مصروفات السيارات"},
            {"BackupSave", "نسخة احتياطية"},
            {"BackupRestore", "استرجاع نسخة"},
            {"SettingsGeneral", "الإعدادات"},
            {"SystemReset", "إعادة ضبط النظام"},
            {"VersionNew", "شاشة جديد الاصدارات"},
            {"ExplainSystem", "موقعنا على الانترنت"},
            {"Connection", "ادارة قواعد البيانات"},
            {"Programs", "برامجنا"},
            {"TermsandConditions", "الشروط والاحكام"},
            {"License", "الرخصة"},
            {"CallUs", "اتصل بنا"},
        };
        //-------  تحميل الصلاحيات داخل الجدول

        void LoadPermissions()
        {
            dgvPermissions.Columns.Clear();
            dgvPermissions.Rows.Clear();

            dgvPermissions.AllowUserToAddRows = false;

            dgvPermissions.Columns.Add("Permission", "الصلاحية");

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "Value";
            chk.HeaderText = "السماح";
            dgvPermissions.Columns.Add(chk);

            foreach (var item in permissionsNames)
            {
                int rowIndex = dgvPermissions.Rows.Add(item.Value, false);

                // نخزن الاسم الإنجليزي هنا
                dgvPermissions.Rows[rowIndex].Tag = item.Key;
            }
        }
        private void UserAddNew_Load(object sender, EventArgs e)
        {
            dgvPermissions.Columns.Add("Permission", "الصلاحية");
           

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "Value";
            chk.HeaderText = "السماح";
            dgvPermissions.Columns.Add(chk);

          

            //---------  استدعاء الدالة عند فتح الفورم---------
            LoadPermissions();

            //------ خلي أي CheckBox افتراضي = false
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                row.Cells["Value"].Value = false;
            }

            //--------- تحميل المستخدمين

            LoadUsers();

            this.dgvPermissions.Columns[0].Width = 250;
            this.dgvPermissions.Columns[1].Width = 100;


            butAdd.Enabled = true;
            btnUpdate.Enabled = false;

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                // بناء الاستعلام
                string query = "INSERT INTO Users (UserName, Bassword";

                // الأعمدة
                foreach (var item in permissionsNames)
                {
                    query += "," + item.Key;
                }

                query += ") VALUES (@UserName,@Password";

                // القيم
                foreach (var item in permissionsNames)
                {
                    query += ",@" + item.Key;
                }

                query += ")";

                SqlCommand cmd = new SqlCommand(query, con);

                // بيانات المستخدم
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                // الصلاحيات
                foreach (DataGridViewRow row in dgvPermissions.Rows)
                {
                    if (row.IsNewRow) continue;

                    string name = row.Tag?.ToString();
                    if (string.IsNullOrEmpty(name)) continue;

                    var val = row.Cells["Value"].Value;
                    int value = val != null && (bool)val ? 1 : 0;

                    cmd.Parameters.AddWithValue("@" + name, value);
                }

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("تم إضافة المستخدم");

            LoadUsers();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            ResetForm();


            //currentUserId = 0;

            //txtUserName.Clear();
            //txtPassword.Clear();

            //foreach (DataGridViewRow row in dgvPermissions.Rows)
            //{
            //    row.Cells["Value"].Value = false;
            //}

            //cmbUsers.SelectedIndex = -1;

            //// حالة الأزرار
            //butAdd.Enabled = true;
            //btnUpdate.Enabled = false;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                if (row.IsNewRow) continue;

                row.Cells["Value"].Value = true;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                if (row.IsNewRow) continue;

                row.Cells["Value"].Value = false;
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            // أولًا نمسح الكل
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                if (row.IsNewRow) continue;

                row.Cells["Value"].Value = false;
            }

            // الصلاحيات الافتراضية
            string[] defaultPermissions =
            {
                "Sales",
                "Purchases",
                "Expenses",
                "ClientAdd",
                "SalesReturns",
                "PurchaseReturns",
                "PriceViewer",
                "Barcode",
                "ProducerIncomplete",
                "BoxMovement",
                "ProducerAddBarcodeFactory",
                "OccasionsForm",
                "Group_Name",
                "StoreNewAdd",
                "ExplainSystem",// موقعنا على الانترنت
                "AddSnToCategory"
            };

            // تحديد الافتراضي
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                if (row.IsNewRow) continue;

                string permName = row.Tag.ToString();

                if (defaultPermissions.Contains(permName))
                {
                    row.Cells["Value"].Value = true;
                }
            }
        }

        void LoadUserData(long userId)
        {
            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                row.Cells["Value"].Value = false;
            }

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE ID=@id", con);
                cmd.Parameters.AddWithValue("@id", userId);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        txtUserName.Text = dr["UserName"]?.ToString();
                        txtPassword.Text = dr["Bassword"]?.ToString();

                        // تحميل الصلاحيات
                        foreach (DataGridViewRow row in dgvPermissions.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string permName = row.Tag?.ToString();
                            if (string.IsNullOrEmpty(permName)) continue;

                            if (dr[permName] != DBNull.Value)
                            {
                                int val = Convert.ToInt32(dr[permName]);
                                row.Cells["Value"].Value = val == 1;
                            }
                            else
                            {
                                row.Cells["Value"].Value = false;
                            }
                        }
                    }
                }
            }
        }
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedItem == null) return;

            dynamic item = cmbUsers.SelectedItem;
            currentUserId = item.Value;

            LoadUserData(currentUserId);

            // تغيير حالة الأزرار
            butAdd.Enabled = false;
            btnUpdate.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentUserId == 0)
            {
                MessageBox.Show("اختر مستخدم أولاً");
                return;
            }

            using (SqlConnection con = new SqlConnection(constring))  // للتاكد من الاتصال للامان
            {
                con.Open();

                // بناء الاستعلام
                string query = @"UPDATE Users SET 
                         UserName=@UserName,
                         Bassword=@Password";

                foreach (var item in permissionsNames)
                {
                    query += "," + item.Key + "=@" + item.Key;
                }

                query += " WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(query, con);

                // البيانات الأساسية
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@ID", currentUserId);

                // الصلاحيات
                foreach (DataGridViewRow row in dgvPermissions.Rows)
                {
                    if (row.IsNewRow) continue;

                    string name = row.Tag.ToString();
                    var val = row.Cells["Value"].Value;

                    int value = val != null && (bool)val ? 1 : 0;

                    cmd.Parameters.AddWithValue("@" + name, value);
                }

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("تم تحديث المستخدم");

            LoadUsers();
        }

        void ResetForm()
        {
            currentUserId = 0;

            txtUserName.Clear();
            txtPassword.Clear();

            foreach (DataGridViewRow row in dgvPermissions.Rows)
            {
                row.Cells["Value"].Value = false;
            }

            cmbUsers.SelectedIndex = -1;

            butAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin")
            {
                MessageBox.Show("لا يمكن حذف المستخدم الرئيسي");
                return;
            }

            if (currentUserId == 0)
            {
                MessageBox.Show("اختر مستخدم أولاً");
                return;
            }

            // تأكيد الحذف
            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف المستخدم؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", currentUserId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("تم حذف المستخدم بنجاح");

            // تحديث القائمة
            LoadUsers();

            // تفريغ الفورم
            ResetForm();
        }
    }
}
