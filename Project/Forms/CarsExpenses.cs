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
    public partial class CarsExpenses : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        //-------------------------------
        private SqlDataReader reed;
        private SqlDataReader red;
        //---------------------------------
        string RasedBox = "";

        //--------------------------------
        string Move = "مصاريف سياراه رقم";
        int i = 0;
        //SqlCommand cmd;
        public CarsExpenses()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }
        public void Sum()
        {
            try
            {
                double a = Convert.ToDouble(textGhaseel.Text);
                double b = Convert.ToDouble(textFilter.Text);
                double c = Convert.ToDouble(textGas.Text);
                double d = Convert.ToDouble(textOil.Text);
                double f = Convert.ToDouble(textMekaneky.Text);
                double h = Convert.ToDouble(texKamaliat.Text);
                //double i = Convert.ToDouble(textBox7.Text);

                double aa = a + b + c + d + f + h;
                textTotal.Text = aa.ToString();
            }
            catch
            { }
        }
        private void butSearch_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";

            textGhaseel.Text = "0";
            textBox12.Text = "0";
            textFilter.Text = "0";
            textGas.Text = "0";
            textOil.Text = "0";
            textMekaneky.Text = "0";
            texKamaliat.Text = "0";
            textTotal.Text = "0";
            textNote.Text = "";
            textDriver.Text = "";


            // إيجاد رقم 
            try
            {
                int iiii = int.Parse(textMoveBoxID.Text);
                int jjjj = iiii + 1;
                textBox12.Text = jjjj.ToString();
            }
            catch
            { }


            try  // ** بحث لو العربة صرفت فى نفس اليوم
            {
                sqlCommand1.CommandText = "select * from SearchCar where NumCar ='" + comNumCar.Text + "' and date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'  ";
                reed = sqlCommand1.ExecuteReader();
                while (reed.Read())
                {
                    textGhaseel.Text = reed["Washed"].ToString();
                    textBox12.Text = reed["ID"].ToString();
                    textFilter.Text = reed["Filter"].ToString();
                    textGas.Text = reed["Petroleum"].ToString();
                    textOil.Text = reed["Oil"].ToString();
                    textMekaneky.Text = reed["Mechanical"].ToString();
                    texKamaliat.Text = reed["PartChange"].ToString();
                    textTotal.Text = reed["Total"].ToString();
                    textNote.Text = reed["Notice"].ToString();
                    comDriver.Text = reed["Driver"].ToString();

                }
                reed.Close();



            }
            catch
            {

            }

            //----
            Move = "مصاريف سيارة رقم   " + comNumCar.Text;

            int i = int.Parse(textBox12.Text);
            int j = int.Parse(textMoveBoxID.Text);
            if (i > j)
            {
                butAdd.Enabled = true;
                butDelete.Enabled = false;
                butEdit.Enabled = false;
            }
            else
            {
                butAdd.Enabled = false;
                butDelete.Enabled = true;
                butEdit.Enabled = true;
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "UPDATE SearchCar SET Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' ,Washed ='" + textGhaseel.Text + "' ,Filter ='" + textFilter.Text + "',Petroleum ='" + textGas.Text + "',Oil ='" + textOil.Text + "',Mechanical ='" + textMekaneky.Text + "',PartChange ='" + texKamaliat.Text + "' ,Total ='" + textTotal.Text + "',Notice ='" + textNote.Text + "' ,Driver ='" + textDriver.Text + "' WHERE  ID ='" + textBox12.Text + "' ";
                sqlCommand1.ExecuteNonQuery();
                MessageBox.Show("       تم التعديل بنجاح           ", "  ملحوظه  ");
            }
            catch
            {
                MessageBox.Show(" pleas correct the data");
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد حذف البيانات  ؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("موافق", "موافق");

                try
                {
                    sqlCommand1.CommandText = "delete from SearchCar where NumCar ='" + comNumCar.Text + "' and date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'   ";
                    sqlCommand1.ExecuteNonQuery();

                    MessageBox.Show("       تم الحذف بنجاح           ", "  ملحوظه  ");
                }
                catch
                { }

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void textGhaseel_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void textGas_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void textOil_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void textMekaneky_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void texKamaliat_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void comNumCar_TextChanged(object sender, EventArgs e)
        {
            Move = "مصاريف سيارة رقم   " + comNumCar.Text;
        }

        private void comDriver_TextChanged(object sender, EventArgs e)
        {
            textDriver.Text = comDriver.Text;
        }

        private void CarsExpenses_Load(object sender, EventArgs e)
        {
            //----------------- ايجاد ارقام السيارات --------------------
            try
            {
                SqlDataAdapter Da1;
                DataTable Dt1 = new DataTable();
                Da1 = new SqlDataAdapter("select NumCar from Car", cn);
                Da1.Fill(Dt1);
                comNumCar.DataSource = Dt1;
                comNumCar.DisplayMember = "NumCar";


                //------------------
                string Jop = "سائق";
                string State = "فعال";
                SqlDataAdapter Da11;
                DataTable Dt11 = new DataTable();
                Da11 = new SqlDataAdapter("select Name from Employed where Jop = '" + Jop + "' and State = '" + State + "'", cn);
                Da11.Fill(Dt11);
                comDriver.DataSource = Dt11;
                comDriver.DisplayMember = "Name";
            }
            catch
            {

            }

            comNumCar.Text = "";


            //comboBox9.SelectedIndex = comboBox9.Items.Count - 1;
            //textBox14.Text = comboBox9.Text;

            // إيجاد رقم حركة الصندوق

            try
            {
                sqlCommand1.CommandText = "select * From BoxMove  Where ID =(select max(ID) from BoxMove) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["ID"].ToString());
                    double aa = s + 1;
                    textMoveBoxID.Text = aa.ToString();

                }
                red.Close();

                if (textMoveBoxID.Text == "0")
                {
                    textMoveBoxID.Text = "1";
                }
                else
                { }
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            //// إيجاد رقم حساب اول الجرد

            //int iiii = int.Parse(textMoveBoxID11.Text);
            //int jjjj = iiii + 1;
            //textBox12.Text = jjjj.ToString();


            ////------  ايجاد رقم حركة الصندوق
            //comboBox4.SelectedIndex = comboBox4.Items.Count - 1;


            //int ai = int.Parse(comboBox4.Text);
            //int aj = ai + 1;
            //textMoveBoxID.Text = aj.ToString();


            ////*************** السائقين
            //SqlDataReader dataReader;
            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
            //DataSet dataset3 = new DataSet();

            //dataAdapter.SelectCommand = new SqlCommand("select * from Employed where Jop = '" + textBox9.Text + "' and State = '" + textBox11.Text + "' ", cn);
            //dataAdapter.Fill(dataset3);
            //sqlCommand1.Connection = cn;
            //sqlCommand1.CommandText = "select * from Employed where  Jop = '" + textBox9.Text + "' and State = '" + textBox11.Text + "' ";
            //dataReader = sqlCommand1.ExecuteReader();

            //while (dataReader.Read())
            //{
            //    listBox1.DataSource = dataset3.Tables[0];
            //    //checkedListBox1.Items.Add(dataReader["Name"]);
            //    i = i + 1;
            //}


            //if (i == 0)
            //    MessageBox.Show("   لا يوجد سائقين   ", " السائقين ");

            //dataReader.Close();


            //------- رصيد الخزنة

            try
            {
                sqlCommand1.CommandText = "select * From TreasuryRemaning  Where ID = '" + 1 + "' ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {

                    RasedBox = red["RemaningTreasury"].ToString();
                }
                red.Close();
            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }

            //---- الحركة
            Move = "مصاريف سيارة رقم   " + comNumCar.Text;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {

            if (textDriver.Text == "")
            {
                MessageBox.Show("       من فضلك أدخل إسم السائق           ", "  خطأ  ");
                textDriver.Focus();
            }
            else
            {
                sqlCommand1.CommandText = "insert into SearchCar (NumCar,Date,Washed,Filter,Petroleum,Oil,Mechanical,PartChange,Total,Notice,Driver)values ('" + comNumCar.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textGhaseel.Text + "','" + textFilter.Text + "','" + textGas.Text + "','" + textOil.Text + "','" + textMekaneky.Text + "','" + texKamaliat.Text + "','" + textTotal.Text + "','" + textNote.Text + "','" + textDriver.Text + "')";
                sqlCommand1.ExecuteNonQuery();
                MessageBox.Show("       تم الاضافة بنجاح           ", "  ملحوظه  ");
            }

            //---- حساب اجمالى الصندوق
            double q1S = Convert.ToDouble(RasedBox);
            double l1S = Convert.ToDouble(textTotal.Text);
            double w1S = q1S - l1S;
            RasedBox = w1S.ToString();

            sqlCommand1.CommandText = "update TreasuryRemaning set RemaningTreasury ='" + RasedBox + "' , Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' Where ID ='" + 1 + "'";
            sqlCommand1.ExecuteNonQuery();

            //----------  إضافة حركة الصندوق

            //try
            //{
            sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + textMoveBoxID.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + Move + "','" + textDriver.Text + "','" + textBox12.Text + "','" + RasedBox + "','" + textTotal.Text + "','" + 0 + "','" + RasedBox + "','" + textNote.Text + "')";
            sqlCommand1.ExecuteNonQuery();

            //}
            //catch
            //{

            //}
        }
    }
}
