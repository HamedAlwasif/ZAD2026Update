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
    public partial class MoneyFromBox : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection sqlConnection1 = new SqlConnection(constring);

        //--------------------------------

        //private SqlDataReader raaad;
        private SqlDataReader red;
        private SqlDataReader reed;
        DataTable dt2 = new DataTable();
        double s;

        string MoveBoxID = "";
       
        string TypeMoneyToBox = TransferData.TypeMoneyToBox;
        public MoneyFromBox()
        {
            InitializeComponent();
            //sqlConnection1.Open();
            sqlCommand1.Connection = sqlConnection1;
        }
        public void TotalMony()
        {
            sqlConnection1.Open();
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
            {

            }

            sqlConnection1.Close();

            GetDataTable();

            //try
            //{
            //    DataTable dt11 = new DataTable();
            //    dt11.Clear();
            //    SqlDataAdapter da11 = new SqlDataAdapter("select * from Movemoney where Wared >'" + 0 + "' ", sqlConnection1);
            //    da11.Fill(dt11);
            //    this.dataGridView1.DataSource = dt11;
            //    // ***  إجمالى المصاريف  ****
            //    try
            //    {
            //        //int sum = 0;
            //        int sum1 = 0;
            //        for (int i = 0; i < dataGridView1.RowCount; ++i)
            //        {
            //            //sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            //            sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);


            //        }
            //        //textSader.Text = sum.ToString();
            //        textWared.Text = sum1.ToString();

            //    }
            //    catch
            //    { }
            //}
            //catch
            //{ }

        }
        public void GetDataTable()
        {
            sqlConnection1.Open();

            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID as م ,Date as التاريخ,Name as الاسم,Report as البيان,Sader as الصادر from Movemoney where Sader >'" + 0 + "' ", sqlConnection1);
            da11.Fill(dt11);
            this.dataGridView1.DataSource = dt11;
            // ***  إجمالى المصاريف  ****
            try
            {
                int sum = 0;
                //int sum1 = 0;
                for (int i = 0; i < dataGridView1.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    


                }
                textSader.Text = sum.ToString();
               

            }
            catch
            { }

            sqlConnection1.Close();
        }
        public void GetMoveBoxID()
        {

            sqlConnection1.Open();

            try
            {
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
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
            sqlConnection1.Close();


        }
        private void MoneyFromBox_Load(object sender, EventArgs e)
        {
            texUser.Text = AppSetting.user;
            this.Text = TypeMoneyToBox;

            TotalMony();

            GetMoveBoxID();

           

            GetDataTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد خصم نقدية بالفعل ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                sqlConnection1.Open();

                sqlCommand1.CommandText = "insert into Movemoney (Date,Name,Report,Sader,Wared)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + texUser.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();

                //  ايجاد الكود

                sqlCommand1.CommandText = "select ID From Movemoney  Where ID =(select max(ID) from Movemoney) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    s = Convert.ToDouble(red["ID"].ToString());


                }
                red.Close();


                //---- حساب اجمالى الصندوق
                double q1S = Convert.ToDouble(txtReminngOLD.Text);
                double l1S = Convert.ToDouble(textBox1.Text);
                double w1S = q1S - l1S;
                //textBox25.Text = w1S.ToString();

                sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + w1S + "' , Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                sqlCommand1.ExecuteNonQuery();



                //try
                //{
                sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + TypeMoneyToBox + "','" + texUser.Text + "','" + s + "','" + txtReminngOLD.Text + "','" + textBox1.Text + "','" + 0 + "','" + w1S + "','" + textBox3.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                double n = Convert.ToDouble(MoveBoxID);
                double aa = n + 1;
                MoveBoxID = aa.ToString();

                sqlConnection1.Close();
                //----------- ايجاد الاجمالى---------
                TotalMony();
                
            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chBoxDeletCat.Checked == true)
            {
                texUser.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //    // حذف الصنف من الفاتورة

                sqlConnection1.Open();

                sqlCommand1.CommandText = "delete from Movemoney where ID = '" + id + "'  ";
                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + id + "' and Move='" + TypeMoneyToBox + "' ";
                sqlCommand1.ExecuteNonQuery();

                MessageBox.Show("Delete", "تم حذف هذا البند بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                sqlConnection1.Close();

                TotalMony();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
