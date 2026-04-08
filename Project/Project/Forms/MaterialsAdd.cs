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
using System.IO;

namespace ZAD_Sales.Forms
{
    public partial class MaterialsAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        int i = 0;

        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;

        string MoveBoxID = "";
        string SystemPro = "";
        string MaterialsID = "";

        private SqlDataReader red;
        private SqlDataReader reed;
        private SqlDataReader read;

        //-------------------------------
        DataTable dt1 = new DataTable();
        public MaterialsAdd()
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
               

                string[] com = { "قطعه", "طقم", "لفة", "علبة", "ربطه", "دستة", "كيس", "الف", "متر" };
               // ComTypeCategorey.DataSource = com;
                //comboBox1.SelectedIndex = comboBox1.Items.Count +0;
            }
            else  // جمله وقطاعى
            {
                SystemPro = "جمله وقطاعى";
             

                string[] com = { "كرتونه", "دسته", "قطعه", "طقم", "لفة", "علبة", "ربطه", "كيس" };
               // ComTypeCategorey.DataSource = com;

            }
            // نهاية البحث نظام العمل جملة او قطاعى
        }
        public void GetMoveBoxID()
        {



            //try
            //{
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
            //}
            //catch
            //{
            //    MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            //}



        }

        public void GetMaterialsID()
        {



            try
            {
                sqlCommand1.CommandText = "select * From Materials  Where ID =(select max(ID) from Materials) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["ID"].ToString());
                double aa = s + 1;
                MaterialsID = aa.ToString();

            }
            red.Close();

            if (MaterialsID == "")
            {
                MaterialsID = "1";
            }
            else
            { }
            }
            catch
            {
               // MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }



        }

        public class Class_MaterialsBill
        {
            public string ID { get; set; }
            public string MaterialsName { get; set; }
            public string Price { get; set; }
            public string Qunt { get; set; }
            public string Total { get; set; }
            public string DateExpiry { get; set; }
            public string Note { get; set; }


        }

        private void MaterialsAdd_Load(object sender, EventArgs e)
        {
            SystemProgram();
            GetMoveBoxID();
            textBoxID.Text = MoveBoxID;


            //------- رصيد الخزنة
            try
            {
                sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From BoxMove ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    txtReminngOLD.Text = "0";

                    double w = Convert.ToDouble(reed["wared"].ToString());
                    double s = Convert.ToDouble(reed["sader"].ToString());


                    double rr = w - s;
                    //txtReminngOLD.Text = rr.ToString();

                    txtReminngOLD.Text = Math.Round(rr, 0).ToString();

                }
                reed.Close();



                //-------------------------------------------

            }
            catch
            { }

            //textMoveBill.Text = FormName;
            //textUser.Text = UserName;



            //----------------- ايجاد الخامات --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select MaterialsName from Materials", cn);
                Da1.Fill(Dt1);
                combMaterial.DataSource = Dt1;
                combMaterial.DisplayMember = "MaterialsName";
            }
            catch
            { }

        }

        private void butAddMaterial_Click(object sender, EventArgs e)
        {
            //sqlCommand1.CommandText = "select ID from BoxMove where NumBill = '" + textBillingDataNumBill.Text + "' and  Move = '" + textMoveBill.Text + "'";
            //read = sqlCommand1.ExecuteReader();
            //while (read.Read())
            //{
            //    MoveBoxID = read["ID"].ToString();



            //}
            //read.Close();


            double a = Convert.ToDouble(textPrice.Text);
            double b = Convert.ToDouble(textQunt.Text);
            double c = Convert.ToDouble(txtTotalMaterial.Text);
            double d = Convert.ToDouble(textTotalQuentety.Text);


            double r = a*b;
            // txtRemainingNow.Text = r.ToString();
            txtTotalMaterial.Text = Math.Round(double.Parse(r.ToString()), 2).ToString();

            double h = b + d;
            // txtRemainingNow.Text = r.ToString();
            textTotalQuentety.Text = Math.Round(double.Parse(h.ToString()), 2).ToString();


            


            if(textBarcode.Text=="")
            {
                GetMaterialsID();
                textBarcode.Text = MaterialsID;
                sqlCommand1.CommandText = "insert into Materials (MaterialsName,Price,Qunt,DateExpiry)values ('" + combMaterial.Text + "','" + textPrice.Text + "','" + textQunt.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "')";
                sqlCommand1.ExecuteNonQuery();
            }
           else
            {
                sqlCommand1.CommandText = "update Materials set  Price ='" + textPrice.Text + "',Qunt = '" + textTotalQuentety.Text + "',DateExpiry = '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "' where  ID ='" + textBarcode.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
            }

            //=================إضافة الخامة    
            sqlCommand1.CommandText = "insert into MaterialsBill (BoxID,Date,MaterialsName,MaterialsID,Price,Qunt,Total,DateExpiry,Note)values ('" + textBoxID.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + combMaterial.Text + "','" + textBarcode.Text + "','" + textPrice.Text + "','" + textQunt.Text + "','" + txtTotalMaterial.Text + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + textNOTE.Text + "')";
            sqlCommand1.ExecuteNonQuery();


            //===================== ايجاد الاصناف فى الفاتورة
            dt1.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID,MaterialsName,MaterialsID,Price,Qunt,Total,DateExpiry,Note from MaterialsBill where BoxID = '" + textBoxID.Text + "' ", cn);

            da11.Fill(dt1);

            this.dataGridView1.DataSource = dt1;

            //===================== حساب إجمالى الفاتورة عدد الاصناف
            int rowNumber1 = 0;

            double sum1 = 0;
            for (int s = 0; s < dataGridView1.RowCount - 1; ++s)
            {
                sum1 += Convert.ToDouble(dataGridView1.Rows[s].Cells[4].Value);
                rowNumber1 = rowNumber1 + 1;

            }

            textBox1.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
            textNumMaterial.Text = rowNumber1.ToString();



            double c1 = Convert.ToDouble(txtReminngOLD.Text);
            double d1 = Convert.ToDouble(textBox1.Text);


            double r1 = c1 - d1;
            // txtRemainingNow.Text = r.ToString();
            string totalbox = Math.Round(double.Parse(r1.ToString()), 2).ToString();

            try
            {
              

                sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values" +
                    " ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + UserName + "','" + 0 + "', '" + txtReminngOLD .Text+ "', '" + textBox1.Text + "','" + 0 + "','" + totalbox + "','" + FormName + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                sqlCommand1.CommandText = "update BoxMove set Remaining = '" + txtReminngOLD.Text + "', Sader = '" + textBox1.Text + "', Total = '" + totalbox + "'  where ID = '" + textBoxID.Text + "'";
                sqlCommand1.ExecuteNonQuery();
            }


            combMaterial.Focus();

        }

        private void combMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void combMaterial_TextChanged(object sender, EventArgs e)
        {
            textPrice.Text = "0";
            textTotalQuentety.Text = "0";

            textQunt.Text = "0";
            textBarcode.Text = "";


            try
            {
                sqlCommand1.CommandText = "select * from Materials where MaterialsName Like'" + combMaterial.Text + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textPrice.Text = reed["Price"].ToString();
                    textTotalQuentety.Text = reed["Qunt"].ToString();

                    dateTimePicker2.Text = reed["DateExpiry"].ToString();
                    textBarcode.Text = reed["ID"].ToString();



                }
                reed.Close();

            }
            catch
            {

            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            dt1.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID,MaterialsName,MaterialsID,Price,Qunt,Total,DateExpiry,Note from MaterialsBill where Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ", cn);

            da11.Fill(dt1);

            this.dataGridView1.DataSource = dt1;

            //===================== حساب إجمالى الفاتورة عدد الاصناف
            int rowNumber1 = 0;

            double sum1 = 0;
            for (int s = 0; s < dataGridView1.RowCount - 1; ++s)
            {
                sum1 += Convert.ToDouble(dataGridView1.Rows[s].Cells[4].Value);
                rowNumber1 = rowNumber1 + 1;

            }

            textBox1.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();
            textNumMaterial.Text = rowNumber1.ToString();
        }

        private void textQunt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
