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
    public partial class MoneyWaredAndSaderOther : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;

        //--------------------------------
        DataTable dt11 = new DataTable();
        //private SqlDataReader rred;
        private SqlDataReader red;
        private SqlDataReader reed;

        string MoveBoxID = "";

        public MoneyWaredAndSaderOther()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        public void GetMoveBoxID()
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
        private void ShearchDateDay()
        {
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from CategoryOthers where Date ='" + dateDay.Value.ToString("MM/dd/yyyy") + "' ", cn);
            da11.Fill(dt11);
            this.dataGridShearch.DataSource = dt11;
            this.dataGridShearch.Columns[0].HeaderText = "الكود";
            this.dataGridShearch.Columns[1].HeaderText = "التاريخ";
            this.dataGridShearch.Columns[2].HeaderText = "مصروفات";
            this.dataGridShearch.Columns[3].HeaderText = "ايرادات";
            this.dataGridShearch.Columns[4].HeaderText = "البيان";

            this.dataGridShearch.Columns[0].Width = 60;
            this.dataGridShearch.Columns[1].Width = 90;
            this.dataGridShearch.Columns[2].Width = 70;
            this.dataGridShearch.Columns[3].Width = 70;
            this.dataGridShearch.Columns[4].Width = 250;

            double Masrofat = 0;
            double Eradat = 0;
            for (int i = 0; i < dataGridShearch.RowCount; ++i)
            {
                Masrofat += Convert.ToDouble(dataGridShearch.Rows[i].Cells[2].Value);
                Eradat += Convert.ToDouble(dataGridShearch.Rows[i].Cells[3].Value);


            }
            txtMasrofat.Text = Masrofat.ToString(); //---- مصروفات
            txtEradat.Text = Eradat.ToString(); // --- ايرادات
        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = "insert into CategoryOthers (Date,ExpensesOther,IncomeOther,Statement)values ('" + dateAdd.Value.ToString("MM/dd/yyyy") + "','" + txtExpensesOther.Text + "','" + txtIncomeOther.Text + "','" + txtStatement.Text + "')";
            sqlCommand1.ExecuteNonQuery();
            ShearchDateDay();

            //---- حساب اجمالى الصندوق
            double a = Convert.ToDouble(txtReminngOLD.Text);
            double b = Convert.ToDouble(txtIncomeOther.Text);
            double c = Convert.ToDouble(txtExpensesOther.Text);
            double s = (a + b) - c;
            textBoxManey2.Text = s.ToString();



            sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + textBoxManey2.Text + "' , Date ='" + dateAdd.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
            sqlCommand1.ExecuteNonQuery();
            //----------  إضافة حركة الصندوق

            try
            {
                sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateAdd.Value.ToString("MM/dd/yyyy") + "','" + txtMove.Text + "','" + txtClints.Text + "','" + 0 + "', '" + txtReminngOLD.Text + "', '" + txtExpensesOther.Text + "','" + txtIncomeOther.Text + "','" + textBoxManey2.Text + "','" + 0 + "')";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            {
                //sqlCommand1.CommandText = "update BoxMove set Remaining = '" + textBox62.Text + "', Wared = '" + textBox15.Text + "', Total = '" + textBox63.Text + "' , Date = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' where NumBill = '" + textBillingDataNumBill.Text + "' and Name = '" + comClient.Text + "'";
                //sqlCommand1.ExecuteNonQuery();
            }

            //---------------------------------
            double a1 = Convert.ToDouble(MoveBoxID);
            double s1 = a1 + 1;
            MoveBoxID = s1.ToString();

            txtReminngOLD.Text = textBoxManey2.Text;
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("    من فضلك اختار البند المطلوب تعديلة      ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sqlCommand1.CommandText = "update CategoryOthers set  Date='" + dateAdd.Value.ToString("MM/dd/yyyy") + "',  ExpensesOther ='" + txtExpensesOther.Text + "',  IncomeOther ='" + txtIncomeOther.Text + "',  Statement ='" + txtStatement.Text + "'  where ID='" + txtID.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                ShearchDateDay();
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("    من فضلك اختار البند المطلوب حذفه      ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sqlCommand1.CommandText = "delete from CategoryOthers where ID = '" + txtID.Text + "' ";
                sqlCommand1.ExecuteNonQuery();

                ShearchDateDay();
            }
        }

        private void radbutExpensesOther_CheckedChanged(object sender, EventArgs e)
        {
            if (radbutExpensesOther.Checked == true)
            {
                txtIncomeOther.Text = "0";
                txtIncomeOther.Visible = false;
                label3.Visible = false;
                //--------------------------------
                txtExpensesOther.Text = "0";
                txtExpensesOther.Visible = true;
                label2.Visible = true;
                //--------------------------------
                txtMove.Text = "مصروفات أخرى";
            }
            else if (radbutIncomeOther.Checked == true)
            {
                txtIncomeOther.Text = "0";
                txtIncomeOther.Visible = true;
                label3.Visible = true;
                //--------------------------------
                txtExpensesOther.Text = "0";
                txtExpensesOther.Visible = false;
                label2.Visible = false;
                //--------------------------------
                txtMove.Text = "إيرادات أخرى";
            }
            else
            { }
        }

        private void radbutIncomeOther_CheckedChanged(object sender, EventArgs e)
        {
            if (radbutExpensesOther.Checked == true)
            {
                txtIncomeOther.Text = "0";
                txtIncomeOther.Visible = false;
                label3.Visible = false;
                //--------------------------------
                txtExpensesOther.Text = "0";
                txtExpensesOther.Visible = true;
                label2.Visible = true;
                //--------------------------------
                txtMove.Text = "مصروفات أخرى";
            }
            else if (radbutIncomeOther.Checked == true)
            {
                txtIncomeOther.Text = "0";
                txtIncomeOther.Visible = true;
                label3.Visible = true;
                //--------------------------------
                txtExpensesOther.Text = "0";
                txtExpensesOther.Visible = false;
                label2.Visible = false;
                //--------------------------------
                txtMove.Text = "إيرادات أخرى";
            }
            else
            { }
        }

        private void MoneyWaredAndSaderOther_Load(object sender, EventArgs e)
        {
            ShearchDateDay();

            

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

            //-------------------------
            GetMoveBoxID();

        }

        private void butShearchDay_Click(object sender, EventArgs e)
        {
            ShearchDateDay();

        }
        private void ShearchDateFromTo()
        {
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from CategoryOthers where Date >='" + DateFrom.Value.ToString("MM/dd/yyyy") + "'AND  Date <='" + DateTo.Value.ToString("MM/dd/yyyy") + "' ", cn);
            da11.Fill(dt11);
            this.dataGridShearch.DataSource = dt11;
            this.dataGridShearch.Columns[0].HeaderText = "الكود";
            this.dataGridShearch.Columns[1].HeaderText = "التاريخ";
            this.dataGridShearch.Columns[2].HeaderText = "مصروفات";
            this.dataGridShearch.Columns[3].HeaderText = "ايرادات";
            this.dataGridShearch.Columns[4].HeaderText = "البيان";

            this.dataGridShearch.Columns[0].Width = 60;
            this.dataGridShearch.Columns[1].Width = 90;
            this.dataGridShearch.Columns[2].Width = 70;
            this.dataGridShearch.Columns[3].Width = 70;
            this.dataGridShearch.Columns[4].Width = 250;

            double Masrofat = 0;
            double Eradat = 0;
            for (int i = 0; i < dataGridShearch.RowCount; ++i)
            {
                Masrofat += Convert.ToDouble(dataGridShearch.Rows[i].Cells[2].Value);
                Eradat += Convert.ToDouble(dataGridShearch.Rows[i].Cells[3].Value);


            }
            txtMasrofat.Text = Masrofat.ToString(); //---- مصروفات
            txtEradat.Text = Eradat.ToString(); // --- ايرادات
        }
        private void butShearchDayFromTO_Click(object sender, EventArgs e)
        {
            ShearchDateFromTo();

        }

        private void dataGridShearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridShearch.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateAdd.Text = dataGridShearch.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtExpensesOther.Text = dataGridShearch.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtIncomeOther.Text = dataGridShearch.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtStatement.Text = dataGridShearch.Rows[e.RowIndex].Cells[4].Value.ToString();


            }

            catch
            { }
        }

        private void txtIncomeOther_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }
    }
}
