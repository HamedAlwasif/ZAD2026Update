using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZAD_Sales.DAL;
using ZAD_Sales.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ZAD_Sales.Forms
{
    public partial class OccasionsForm : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);


        private readonly OccasionDAL dal;

        public OccasionsForm()
        {
            InitializeComponent();

            dal = new OccasionDAL(constring);
            LoadOccasions();

            

            //--------------------------
            // لون خلفية الفورم
         //   this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // تخصيص الأزرار
            btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);   // أخضر
            btnAdd.ForeColor = System.Drawing.Color.White;

            btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 123, 255); // أزرق
            btnUpdate.ForeColor = System.Drawing.Color.White;

            btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // أحمر
            btnDelete.ForeColor = System.Drawing.Color.White;

            btnLoad.BackColor = System.Drawing.Color.FromArgb(253, 126, 20);  // برتقالي
            btnLoad.ForeColor = System.Drawing.Color.White;

            // جعل الأزرار مسطحة وعصرية
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnLoad.FlatStyle = FlatStyle.Flat;

            btnAdd.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnLoad.FlatAppearance.BorderSize = 0;


            //----------- تنسيق الجدول

            //// ألوان عامة
            //dgvOccasions.BackgroundColor = System.Drawing.Color.White;
            //dgvOccasions.BorderStyle = BorderStyle.None;
            //dgvOccasions.RightToLeft = RightToLeft.Yes; // الاتجاه للغة العربية

            //// الرأس
            //dgvOccasions.EnableHeadersVisualStyles = false;
            //dgvOccasions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            //dgvOccasions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            //dgvOccasions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11, System.Drawing.FontStyle.Bold);
            //dgvOccasions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //// الصفوف
            //dgvOccasions.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Regular);
            //dgvOccasions.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            //dgvOccasions.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //dgvOccasions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            //dgvOccasions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //// عند التحديد
            //dgvOccasions.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(204, 229, 255);
            //dgvOccasions.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            //// إخفاء خط الحدود بين الصفوف
            //dgvOccasions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            //dgvOccasions.GridColor = System.Drawing.Color.LightGray;

            //// حجم الأعمدة تلقائي
            //dgvOccasions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvOccasions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //// منع التعديل المباشر من المستخدم
            //dgvOccasions.ReadOnly = true;
            //dgvOccasions.AllowUserToAddRows = false;
            //dgvOccasions.AllowUserToDeleteRows = false;



           // StyleDataGridView();

        }

        private void StyleDataGridView()
        {
            // ألوان عامة
            dgvOccasions.BackgroundColor = System.Drawing.Color.White;
            dgvOccasions.BorderStyle = BorderStyle.None;
            dgvOccasions.RightToLeft = RightToLeft.Yes; // الاتجاه للغة العربية

            // الرأس
            dgvOccasions.EnableHeadersVisualStyles = false;
            dgvOccasions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            dgvOccasions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvOccasions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11, System.Drawing.FontStyle.Bold);
            dgvOccasions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // الصفوف
            dgvOccasions.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10, System.Drawing.FontStyle.Regular);
            dgvOccasions.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvOccasions.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvOccasions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvOccasions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // عند التحديد
            dgvOccasions.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(204, 229, 255);
            dgvOccasions.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // حدود الصفوف
            dgvOccasions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvOccasions.GridColor = System.Drawing.Color.LightGray;

            // حجم الأعمدة
            dgvOccasions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOccasions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // إخفاء العمود الجانبي
            dgvOccasions.RowHeadersVisible = false;
            dgvOccasions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // منع التعديل المباشر
            dgvOccasions.ReadOnly = true;
            dgvOccasions.AllowUserToAddRows = false;
            dgvOccasions.AllowUserToDeleteRows = false;

            // الخط للصفوف
            dgvOccasions.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            // الخط للرأس
            dgvOccasions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            ////------ لو عاوز خط كلاسيكي
            //dgvOccasions.DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);
            //dgvOccasions.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);


            //---- خط أنيق (Cairo) — لازم يكون متسطب على الجهاز:

            //dgvOccasions.DefaultCellStyle.Font = new Font("Cairo", 11, FontStyle.Regular);
            //dgvOccasions.ColumnHeadersDefaultCellStyle.Font = new Font("Cairo", 12, FontStyle.Bold);



            // ✅ تعديل أسماء الأعمدة للهيدر بالعربية
          //  if (dgvOccasions.Columns.Contains("OccasionID"))
          //      dgvOccasions.Columns["OccasionID"].HeaderText = "م";
          // // dgvOccasions.Columns["OccasionID"].FillWeight = 5; // 30%


          //  if (dgvOccasions.Columns.Contains("OccasionName"))
          //    //  dgvOccasions.Columns["OccasionName"].HeaderText = "اسم المناسبة";
          ////  dgvOccasions.Columns["OccasionName"].FillWeight = 20; // 30%

          //  if (dgvOccasions.Columns.Contains("OccasionDate"))
          //    //  dgvOccasions.Columns["OccasionDate"].HeaderText = "تاريخ المناسبة";
          // // dgvOccasions.Columns["OccasionDate"].FillWeight = 10; // 20%

          //  if (dgvOccasions.Columns.Contains("ReminderDays"))
          //   //   dgvOccasions.Columns["ReminderDays"].HeaderText = "عدد ايام التذكير";
          // // dgvOccasions.Columns["ReminderDays"].FillWeight = 5; // 30%

          //  if (dgvOccasions.Columns.Contains("Description"))
          //  //    dgvOccasions.Columns["Description"].HeaderText = "ملاحظات";
          ////  dgvOccasions.Columns["Description"].FillWeight = 45; // 50% (الوصف أوسع)


          //  if (dgvOccasions.Columns.Contains("RepeatYearly"))
          //  //    dgvOccasions.Columns["RepeatYearly"].HeaderText = "تكرار السنوى";
          // // dgvOccasions.Columns["RepeatYearly"].FillWeight = 10; // 50% (الوصف أوسع)


          //  if (dgvOccasions.Columns.Contains("DayesLeft"))
          //   //   dgvOccasions.Columns["DayesLeft"].HeaderText = "المتبقى";
          //  // dgvOccasions.Columns["DayesLeft"].FillWeight = 5; // 50% (الوصف أوسع)


            
        }

        private void OccasionsForm_Load(object sender, EventArgs e)
        {
           
        }

        private void LoadOccasions()
        {
            List<Occasion> occasions = dal.GetAllOccasions();
            dgvOccasions.DataSource = occasions;

            //DataTable dt = new DataTable();
            //dt.Clear();
            //SqlDataAdapter da = new SqlDataAdapter("Select OccasionID,OccasionName,OccasionDate,ReminderDays,Description,RepeatYearly From Occasions ", con);

            //da.Fill(dt);

            //this.dgvOccasions.DataSource = dt;

            // //التأكد من توليد الأعمدة تلقائيًا من الخصائص
            // dgvOccasions.AutoGenerateColumns = true;

           // تغيير العناوين(الهيدر) وتحديد العرض المناسب لكل عمود
            dgvOccasions.Columns["OccasionID"].HeaderText = "م";
            dgvOccasions.Columns["OccasionID"].Width = 50;

            dgvOccasions.Columns["OccasionName"].HeaderText = "اسم المناسبة";
            dgvOccasions.Columns["OccasionName"].Width = 130;

            dgvOccasions.Columns["OccasionDate"].HeaderText = "التاريخ";
            dgvOccasions.Columns["OccasionDate"].Width = 80;

            dgvOccasions.Columns["ReminderDays"].HeaderText = "أيام التذكير";
            dgvOccasions.Columns["ReminderDays"].Width = 80;

            dgvOccasions.Columns["Description"].HeaderText = "الوصف";
            dgvOccasions.Columns["Description"].Width = 320;

            dgvOccasions.Columns["RepeatYearly"].HeaderText = "تذكير سنوي";
            dgvOccasions.Columns["RepeatYearly"].Width = 90;

            dgvOccasions.Columns["DaysLeft"].HeaderText = "المتبقي";
            dgvOccasions.Columns["DaysLeft"].Width = 50;


          //  dgvOccasions.Sort(dgvOccasions.Columns[2], ListSortDirection.Ascending);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOccasions();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Occasion occ = new Occasion
            {
                OccasionName = txtName.Text,
                OccasionDate = dtpDate.Value,
                ReminderDays = (int)numReminder.Value,
                Description = txtDescription.Text,
                RepeatYearly = chkRepeatYearly.Checked
            };

            dal.AddOccasion(occ);
            LoadOccasions();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOccasions.CurrentRow != null)
            {
                Occasion occ = new Occasion
                {
                    OccasionID = Convert.ToInt32(dgvOccasions.CurrentRow.Cells["OccasionID"].Value),
                    OccasionName = txtName.Text,
                    OccasionDate = dtpDate.Value,
                    ReminderDays = (int)numReminder.Value,
                    Description = txtDescription.Text,
                    RepeatYearly = chkRepeatYearly.Checked
                };

                dal.UpdateOccasion(occ);
                LoadOccasions();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOccasions.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvOccasions.CurrentRow.Cells["OccasionID"].Value);
                dal.DeleteOccasion(id);
                LoadOccasions();
            }
        }

        private void dgvOccasions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOccasions.CurrentRow != null)
            {
                txtName.Text = dgvOccasions.CurrentRow.Cells["OccasionName"].Value.ToString();
                dtpDate.Value = Convert.ToDateTime(dgvOccasions.CurrentRow.Cells["OccasionDate"].Value);
                numReminder.Value = Convert.ToInt32(dgvOccasions.CurrentRow.Cells["ReminderDays"].Value);
                txtDescription.Text = dgvOccasions.CurrentRow.Cells["Description"].Value.ToString();
                chkRepeatYearly.Checked = Convert.ToBoolean(dgvOccasions.CurrentRow.Cells["RepeatYearly"].Value);
            }
        }
    }
}
