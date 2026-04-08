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
    public partial class Expenses : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------

        int i = 0;
        private SqlDataReader red;
        private SqlDataReader reed;
        //------------------------------------
        ReportDataSource rs = new ReportDataSource();
        //-------------------------

        string MoveBoxID = "";
        public Expenses()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public class Class_Expenses_rep
        {

            public string ID { get; set; }
            public string Date { get; set; }
            public string Name { get; set; }
            public string move { get; set; }
            public string Report { get; set; }
            public string Paid { get; set; }
        }

        public class Class_Masaref
        {

            public string ID { get; set; }
            public string Date { get; set; }
            public string Name { get; set; }
            public string move { get; set; }
            public string Report { get; set; }
            public string Paid { get; set; }
        }
        public void MasarefAll()
        {

            //------------------------------------
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended ", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;
            // ***  إجمالى المصاريف  ****
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


                }
                textBox3.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            }
            catch
            { }
        }
        public void GetMoveBoxID()
        {

            

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
           


        }
        public void GetRasedBox()
        {
            //---------  رصيد الخزنة
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
                    textBox16.Text = txtReminngOLD.Text;

                }
                reed.Close();



                //-------------------------------------------

            }
            catch
            {

            }
        }
        private void Expenses_Load(object sender, EventArgs e)
        {
            MasarefAll();
            GetMoveBoxID();
            GetRasedBox();

            string FormName = TransferData.FormName;
            string UserName = AppSetting.user;
            // إيجاد اسم المستخدم
            texUser.Text = UserName;



        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "insert into Expended (ID,Date,Name,move,Report,Paid)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + texUser.Text + "','" + comBoxMove.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                sqlCommand1.ExecuteNonQuery();


            }
            catch
            {

            }

            //---- حساب اجمالى الصندوق
            double q1S = Convert.ToDouble(textBox16.Text);
            double l1S = Convert.ToDouble(textBox2.Text);
            double w1S = q1S - l1S;
            txtReminngOLD.Text = w1S.ToString();

            sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + txtReminngOLD.Text + "' , Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
            sqlCommand1.ExecuteNonQuery();

            //----------  إضافة حركة الصندوق

            try
            {
                sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + comBoxMove.Text + "','" + texUser.Text + "','" + MoveBoxID + "','" + textBox16.Text + "','" + textBox2.Text + "','" + 0 + "','" + txtReminngOLD.Text + "','" + textBox1.Text + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {

            }

           

            // ايجاد المصروفات

            MasarefAll();

            //----------تفريغ البيانات لبند جديد ------
            int iiii = int.Parse(MoveBoxID);
            int jjjj = iiii + 1;
            MoveBoxID = jjjj.ToString();

            

            textBox1.Text = "";
            textBox2.Text = "0";
            textBox16.Text = txtReminngOLD.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended where  Date >='" + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + "' and  Date <='" + Dtp_ToDate.Value.ToString("MM/dd/yyyy") + "' ", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;
            // ***  إجمالى المصاريف  ****
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


                }
                textBox3.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            }
            catch
            { }

            
        }

        private void comSearchMove_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended where move = '" + comSearchMove.Text + "' ", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;
            // ***  إجمالى المصاريف  ****
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


                }
                textBox3.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            }
            catch
            { }

            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select ID as م,Date as التاريخ ,Name as المستخدم , move as الحركة , Report as البيان ,Paid as المبلغ   from Expended where Report like '%" + textBox7.Text + "%' ", cn);
            da11.Fill(dt11);
            this.dataGrData.DataSource = dt11;
            // ***  إجمالى المصاريف  ****
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGrData.RowCount; ++i)
                {
                    sum += Convert.ToInt32(dataGrData.Rows[i].Cells[5].Value);


                }
                textBox3.Text = Math.Round(Convert.ToDouble(sum.ToString()), 2).ToString();

            }
            catch
            { }

            
        }

        private void dataGrData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chBoxDeletCat.Checked == true)
            {
                MoveBoxID = dataGrData.Rows[e.RowIndex].Cells[0].Value.ToString();


                if (MoveBoxID == "")
                {
                    

                }
                else
                {
                    // ----------------

                    texUser.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "0";

                    //*****

                    sqlCommand1.CommandText = "select * from Expended where ID = '" + MoveBoxID + "' ";
                    reed = sqlCommand1.ExecuteReader();
                    while (reed.Read())
                    {
                        dateTimePicker1.Text = reed["Date"].ToString();
                        texUser.Text = reed["Name"].ToString();
                        textBox1.Text = reed["Report"].ToString();
                        textBox2.Text = reed["Paid"].ToString();
                        // textBox3.Text = reed["Total"].ToString();
                    }
                    reed.Close();

                    //---- حذف من قائمة المصاريف
                    try
                    {
                        sqlCommand1.CommandText = "delete from Expended where ID = '" + MoveBoxID + "'   ";
                        sqlCommand1.ExecuteNonQuery();

                        //this.expendedTableAdapter.Fill(this.elwesifDataSet66.Expended);


                    }
                    catch
                    {
                        MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                    }


                    //---------- حذف من حركة الصندوق
                    try
                    {
                        sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + MoveBoxID + "'   ";
                        sqlCommand1.ExecuteNonQuery();


                    }
                    catch
                    {
                        MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
                    }

                    GetRasedBox();

                    sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + txtReminngOLD.Text + "' , Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
                    sqlCommand1.ExecuteNonQuery();

                    // ايجاد المصروفات

                    MasarefAll();
                }


               
            }
            else
            {

            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            

            List<Class_Expenses_rep> BM = new List<Class_Expenses_rep>();
            BM.Clear();
            for (int i = 0; i < dataGrData.Rows.Count; i++)
            {


                Class_Expenses_rep Expenses = new Class_Expenses_rep
                {

                    ID = dataGrData.Rows[i].Cells[0].Value.ToString(),
                    Date = dataGrData.Rows[i].Cells[1].Value.ToString(),
                    Name = dataGrData.Rows[i].Cells[2].Value.ToString(),
                    move = dataGrData.Rows[i].Cells[3].Value.ToString(),
                    Report = dataGrData.Rows[i].Cells[4].Value.ToString(),
                    Paid = dataGrData.Rows[i].Cells[5].Value.ToString()
                };

                BM.Add(Expenses);
            }

            rs.Name = "DataSet1";
            rs.Value = BM;
            Reports.Frm_Expenses rbm = new Reports.Frm_Expenses ();
            rbm.reportViewer1.LocalReport.DataSources.Clear();
            rbm.reportViewer1.LocalReport.DataSources.Add(rs);

            rbm.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
