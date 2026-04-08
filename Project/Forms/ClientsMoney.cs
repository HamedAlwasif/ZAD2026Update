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
    public partial class ClientsMoney : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        //string UserName = TransferData.UserName;
        string UserName = AppSetting.user;


        string RseedBox = "";
        string MoveBoxID = "";
        string NumBill = "";
        string ClintID = "";
        string TypeClint = "";
        string CreditorClint = "";

        string NumInstallment = "";
        string InstallmentID = "";
        string RemaningOld = "0";

        //-------------------------------
        private SqlDataReader red;
        private SqlDataReader reed;
        private SqlDataReader reeeeed;
        private SqlDataReader read;
        private SqlDataReader reaad;

        ClientsMoney ClientsMoney1;

        //------------------------------------
        //ReportDataSource rs = new ReportDataSource();
        //-------------------------




        public ClientsMoney()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }
        public class Class_GetAllClintes
        {
            //Name,Company,TelHome,TelMobil,Address,PreviousBalance,ID
            public string ID { get; set; }
            public string Name { get; set; }
            public string Company { get; set; }
            public string TelHome { get; set; }
            public string TelMobil { get; set; }
            public string Address { get; set; }
            public string PreviousBalance { get; set; }
            public string StateRaseed { get; set; }
        }
        private void GetAllClintes()
        {
            DataTable dt11 = new DataTable();
            dt11.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Clients ", cn);
            da11.Fill(dt11);
            this.dataGridSearchClint.DataSource = dt11;

        }
        public class Class_ClientsMoney
        {
            //NumBill,Date,Move,Paid,Discount,Adding.Pay
            public string NumBill { get; set; }
            public string Date { get; set; }
            public string Move { get; set; }
            public string Paid { get; set; }
            public string Pay { get; set; }
            public string Discount { get; set; }
            public string Adding { get; set; }


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
                    RseedBox = "0";

                    double w = Convert.ToDouble(reed["wared"].ToString());
                    double s = Convert.ToDouble(reed["sader"].ToString());
                    double rr = w - s;
                    RseedBox = Math.Round(rr, 0).ToString();

                }
                reed.Close();

            }
            catch
            {

            }


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
        public void GetNumBill()
        {
            try
            {


                sqlCommand1.CommandText = "select * From BillingData  Where NumBill =(select max(NumBill) from BillingData) ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    double s = Convert.ToDouble(red["NumBill"].ToString());
                    double aa = s + 1;
                    textBillingDataNumBill1.Text = aa.ToString();


                }
                red.Close();

                if (textBillingDataNumBill1.Text == "0")
                {
                    textBillingDataNumBill1.Text = "1";
                }
                else
                { }

                NumBill = textBillingDataNumBill1.Text;

            }
            catch
            {
                MessageBox.Show("  يوجد خطأ فى البيانات   ", "    خطأ   ");
            }
        }
        public void CountRemainingClint()
        {
            double a = Convert.ToDouble(txtDic.Text);
            double b = Convert.ToDouble(txtMosadad.Text);
            double c = Convert.ToDouble(txtAdd.Text);
            double d = Convert.ToDouble(txtRemaningOld.Text);
            double f = Convert.ToDouble(txtDafaa.Text);


            double r = (c + d + f) - (a + b);
            txtRemainingNow.Text = r.ToString();
          //  txtRemaningOld.Text = txtRemainingNow.Text;

            RemaningOld = txtRemainingNow.Text;
        }
        public void CountRemainingRasedBox()
        {
            double a = Convert.ToDouble(RseedBox);

            double b = Convert.ToDouble(txtMosadad.Text);
           
            double c = Convert.ToDouble(txtDafaa.Text);

            //--- RseedBox
            double r = (a + b) - c;
            RseedBox = r.ToString();

        }
        private void ClientsMoney_Load(object sender, EventArgs e)
        {
            GetRasedBox();
            GetAllClintes();

            textUserName.Text = UserName;


            //textBox1.Text= TransferData.NumInstallment; 
            //--------------------------------------
            try
            {
                SqlDataAdapter Da2;
                DataTable Dt2 = new DataTable();
                Da2 = new SqlDataAdapter("select Name from Clients", cn);
                Da2.Fill(Dt2);
                comName.DataSource = Dt2;
                comName.DisplayMember = "Name";
            }
            catch { }



            if (FormName == "تحصيل نقدى")
            {
               
                this.Text = "تحصيل نقدى";
                
                txtMosadad.Visible = true;
                label5.Visible = true;
            }
            else if (FormName == "دفع نقدى")
            {
                
                this.Text = "دفع نقدى";
                //251; 133; 0
                this.BackColor=Color.FromArgb(46, 145, 108);
                panel10.BackColor = Color.FromArgb(183, 228, 199);
                panel11.BackColor = Color.FromArgb(248, 249, 250);
                panel1.BackColor = Color.FromArgb(255, 82, 82);
                txtRemaningOld.ForeColor = Color.FromArgb(181, 52, 113);

                txtDafaa.Visible = true;
                label7.Visible = true;
            }
            else if(FormName == "تحصيل قسط")
            {
                this.Text = "تحصيل قسط";

                txtMosadad.Visible = true;
                label5.Visible = true;
                button5.Enabled = false;

                label14.Text = "المستلم";

                comName.Text = TransferData.ClientName;
                butSearch.PerformClick();

                NumInstallment = TransferData.NumInstallment;

                InstallmentID = TransferData.InstallmentID;

            }

           

            

            //---------------------------
            GetMoveBoxID();

        }
        private void GetOldRasedClient()
        {

            try
            {

                sqlCommand1.CommandText = "select SUM(TotalBill) as TotalBill,SUM(Discount) as Discount,SUM(TotalBillBuy) as TotalBillBuy,SUM(DiscountBuy) as DiscountBuy,SUM(TotalBillInvalid) as TotalBillInvalid,SUM(TotalBillBuyInvalid) as TotalBillBuyInvalid,SUM(Creditor) as Creditor,SUM(Adding) as Adding,SUM(Pay) as Pay,SUM(Paid) as Paid From BillingData Where Name='" + comName.Text + "'  ";
                reeeeed = sqlCommand1.ExecuteReader();
                while (reeeeed.Read())
                {
                    string TotalBill = reeeeed["TotalBill"].ToString();
                    string Discount = reeeeed["Discount"].ToString();
                    string TotalBillBuy = reeeeed["TotalBillBuy"].ToString();
                    string DiscountBuy = reeeeed["DiscountBuy"].ToString();
                    string TotalBillInvalid = reeeeed["TotalBillInvalid"].ToString();
                    string TotalBillBuyInvalid = reeeeed["TotalBillBuyInvalid"].ToString();
                    string Creditor = reeeeed["Creditor"].ToString();
                    string Adding = reeeeed["Adding"].ToString();
                    string Pay = reeeeed["Pay"].ToString();
                    string Paid = reeeeed["Paid"].ToString();

                    //-------------------------------------------
                    txtRemaningOld.Text = "0";
                    try
                    {
                        double t1 = Convert.ToDouble(TotalBill);
                        double t2 = Convert.ToDouble(DiscountBuy);
                        double t3 = Convert.ToDouble(TotalBillBuyInvalid);
                        double t4 = Convert.ToDouble(Adding);
                        double t5 = Convert.ToDouble(Pay);
                        double t6 = Convert.ToDouble(Discount);
                        double t7 = Convert.ToDouble(TotalBillBuy);
                        double t8 = Convert.ToDouble(TotalBillInvalid);
                        double t9 = Convert.ToDouble(Paid);
                        double total = (t1 + t2 + t3 + t4 + t5) - (t6 + t7 + t8 + t9);
                        txtRemaningOld.Text = total.ToString();
                        txtRemaningOld.Text = Math.Round(double.Parse(txtRemaningOld.Text), 2).ToString();

                        RemaningOld = txtRemaningOld.Text;

                    }
                    catch
                    {

                    }
                }
                reeeeed.Close();
            }
            catch { }





        }
        private void GetdataOldToTable()
        {
            if (FormName == "تحصيل نقدى")
            {
                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select TOP 10 NumBill,Date,Move,Paid,Discount,Adding from BillingData where  Name = '" + comName.Text + "' ORDER BY NumBill DESC ", cn);
                //SqlDataAdapter da21 = new SqlDataAdapter("select NumBill,Date,Move,Paid from BillingData where  Name = '" + comName.Text + "' and Move like '" + comboBox3.Text + "' ", sqlConnection1);

                da21.Fill(dt12);
                this.dataGridView1.DataSource = dt12;


                //this.dataGridView1.Columns[0].HeaderText = "الرقم";
                //this.dataGridView1.Columns[0].Width = 50;

                //this.dataGridView1.Columns[1].HeaderText = "التاريخ";
                //this.dataGridView1.Columns[1].Width = 70;

                //this.dataGridView1.Columns[2].HeaderText = "الحركة";
                //this.dataGridView1.Columns[2].Width = 150;

                //this.dataGridView1.Columns[3].HeaderText = "المبلغ";
                //this.dataGridView1.Columns[3].Width = 70;

                //this.dataGridView1.Columns[4].HeaderText = "خصم";
                //this.dataGridView1.Columns[4].Width = 40;

                //this.dataGridView1.Columns[5].HeaderText = "اضافة";
                //this.dataGridView1.Columns[5].Width = 40;

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            else if (FormName == "دفع نقدى")
            {
                DataTable dt12 = new DataTable();
                dt12.Clear();
                SqlDataAdapter da21 = new SqlDataAdapter("select TOP 10 NumBill,Date,Move,Pay,Discount,Adding from BillingData where  Name = '" + comName.Text + "' ORDER BY NumBill DESC ", cn);

                da21.Fill(dt12);
                this.dataGridView1.DataSource = dt12;


                //this.dataGridView1.Columns[0].HeaderText = "الرقم";
                //this.dataGridView1.Columns[0].Width = 50;

                //this.dataGridView1.Columns[1].HeaderText = "التاريخ";
                //this.dataGridView1.Columns[1].Width = 70;

                //this.dataGridView1.Columns[2].HeaderText = "الحركة";
                //this.dataGridView1.Columns[2].Width = 150;

                //this.dataGridView1.Columns[3].HeaderText = "المبلغ";
                //this.dataGridView1.Columns[3].Width = 70;

                //this.dataGridView1.Columns[4].HeaderText = "خصم";
                //this.dataGridView1.Columns[4].Width = 40;

                //this.dataGridView1.Columns[5].HeaderText = "اضافة";
                //this.dataGridView1.Columns[5].Width = 40;

               dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);

            }
            else { }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            GetdataOldToTable();

            GetOldRasedClient();

            try
            {
                sqlCommand1.CommandText = "select * from Clients where Name ='" + comName.Text + "'  ";
                red = sqlCommand1.ExecuteReader();
                while (red.Read())
                {
                    ClintID = red["ID"].ToString();
                    
                    TypeClint = red["Company"].ToString();

                   
                    CreditorClint = red["Creditor"].ToString();

                    textClintID.Text = ClintID;

                    //string ClintID = "";
                    //string TypeClint = "";
                    //string CreditorClint = "";
                }
                red.Close();

                comName.Enabled = false;
                butSearch.Enabled = false;
                button2.Enabled = false;
            }
            catch
            {
                MessageBox.Show("يوجد خطأ فى البحث", "Error");
            }



        }

        private void button11_Click(object sender, EventArgs e)
        {
            // ايجاد رقم الفاتورة
            GetNumBill();

            //-------------------------------------------

            DialogResult dialogResult = MessageBox.Show("" + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال العملية ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //string ClintID = "";
                //string TypeClint = "";
                //string CreditorClint = "";
                CountRemainingClint();
                CountRemainingRasedBox();
                // تحديث بيانات الفاتورة
                string Note = FormName + " : " + textNote.Text;
                sqlCommand1.CommandText = "insert into BillingData (NumBill,ClientID,Name,Type,Date,Move,PreviousBalance,Creditor,TotalBillBuy,DiscountBuy,TotalBill,TotalBillInvalid,TotalBillBuyInvalid,Discount,Adding,Total,Pay,Paid,Remaining,NumberCategory,NamePrint)values ('" + textBillingDataNumBill1.Text + "','" + ClintID + "','" + comName.Text + "','" + TypeClint + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "', '" + Note + "' ,'" + txtRemaningOld.Text + "','" + CreditorClint + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "','" + txtDic.Text + "','" + txtAdd.Text + "','" + txtRemainingNow.Text + "','" + txtDafaa.Text + "','" + txtMosadad.Text + "','" + txtRemainingNow.Text + "','" + 0 + "','" + textUserName.Text + "')";
                sqlCommand1.ExecuteNonQuery();

                try
                {
                    sqlCommand1.CommandText = "insert into BoxMove (ID,Date,Move,Name,NumBill,Remaining,Sader,Wared,Total,Note)values ('" + MoveBoxID + "','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + FormName + "','" + comName.Text + "','" + textBillingDataNumBill1.Text + "','" + RseedBox + "','" + txtDafaa.Text + "','" + txtMosadad.Text + "','" + RseedBox + "','" + Note + "')";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                {

                }

                // تعديل الرصيد فى جدول العملاء
                try
                {
                    sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  Name ='" + comName.Text + "' ";
                    sqlCommand1.ExecuteNonQuery();

                }
                catch
                {
                    MessageBox.Show(" pleas correct the data");
                }


                //------------- تعديل فى جدول الاقساط
                if(NumInstallment!="")
                {
                    sqlCommand1.CommandText = "UPDATE Installment SET Paid ='" + txtMosadad.Text + "',Recipient ='" + textNote.Text + "',Date ='" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'  WHERE  ID ='" + NumInstallment + "' ";
                    sqlCommand1.ExecuteNonQuery();

                    if (txtRemainingNow.Text == "0")
                    {
                        string h = "خالص";
                        sqlCommand1.CommandText = "UPDATE InstallmentData SET State ='" + h + "' WHERE  InstallmentID ='" + InstallmentID + "' ";
                        sqlCommand1.ExecuteNonQuery();
                    }
                }
                else
                {

                }


                //------------------
                GetdataOldToTable();

                button11.Enabled = false;



            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

           // TransferData.FormName = "تحصيل نقدى";
            if (ClientsMoney1 == null || ClientsMoney1.IsDisposed == true)
            {
                ClientsMoney1 = new ClientsMoney();
            }
            ClientsMoney1.MdiParent = Main.ActiveForm;
            ClientsMoney1.Show();


            //dataGridView1.Columns.Clear();

            //txtRemaningOld.Text = "";
            //comName.Enabled = true;
            //butSearch.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chBoxDeletCat.Checked == true)
            {
                DialogResult dialogResult = MessageBox.Show("نص الرسالة ." + Environment.NewLine + Environment.NewLine + "هل تريد إستكمال حذف البند المحدد ؟", "إستفسار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        string Move = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        string Move2 = Move.Substring(0, Move.IndexOf(" : "));
                        txtDic.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                        txtAdd.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                        if (Move2 == FormName)
                        {
                            textBillingDataNumBill1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                            string n = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                            textNote.Text = n.Substring(n.IndexOf(": ") + 2);

                            //***********************************
                            if (FormName == "تحصيل نقدى")
                            {

                                txtMosadad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                                double a = Convert.ToDouble(txtDic.Text);
                                double b = Convert.ToDouble(txtMosadad.Text);

                                double c = Convert.ToDouble(txtAdd.Text);
                                double d = Convert.ToDouble(RemaningOld);
                                double f = Convert.ToDouble(txtDafaa.Text);


                                double r = (c + d + f) + (a + b);
                                //double r = (a + b) - (c + d + f);
                                txtRemainingNow.Text = r.ToString();
                                txtRemainingNow.Text = Math.Round(double.Parse(txtRemainingNow.Text), 2).ToString();

                                txtRemaningOld.Text = txtRemainingNow.Text;

                            }
                            else if (FormName == "دفع نقدى")
                            {
                                txtDafaa.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                                double a = Convert.ToDouble(txtDic.Text);
                                double b = Convert.ToDouble(txtMosadad.Text);

                                double c = Convert.ToDouble(txtAdd.Text);
                                double d = Convert.ToDouble(RemaningOld);
                                double f = Convert.ToDouble(txtDafaa.Text);


                                double r = (a + d + b) - (c + f);
                                //double r = (a + b) - (c + d + f);
                                txtRemainingNow.Text = r.ToString();
                                txtRemainingNow.Text = Math.Round(double.Parse(txtRemainingNow.Text), 2).ToString();

                                txtRemaningOld.Text = txtRemainingNow.Text;

                            }
                            else { }


                            //---------------------- حذف االبند ------------------

                            sqlCommand1.CommandText = "delete from BillingData where NumBill = '" + textBillingDataNumBill1.Text + "'  ";
                            sqlCommand1.ExecuteNonQuery();

                            sqlCommand1.CommandText = "delete from BoxMove where NumBill = '" + textBillingDataNumBill1.Text + "'  ";
                            sqlCommand1.ExecuteNonQuery();





                            sqlCommand1.CommandText = "UPDATE Clients SET PreviousBalance ='" + txtRemainingNow.Text + "'  WHERE  Name ='" + comName.Text + "' ";
                            sqlCommand1.ExecuteNonQuery();

                            //--------------------

                            GetdataOldToTable();
                            chBoxDeletCat.Checked = false;
                            chBoxDeletCat.Enabled = false;

                        }
                        else
                        { }



                    }
                    catch
                    {

                    }

                }
                else if (dialogResult == DialogResult.No)
                {


                }
            }
            else
            { }
        }

        private void comName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // butLogin.Focus();
                butSearch.PerformClick();

            }
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
            if (txtRemaningOld.Text == "")
            {
                MessageBox.Show("لا يوجد عميل للطباعة إختار اسم العميل ", "خطأ");
                comName.Focus();
            }
            else
            {
                if (FormName == "تحصيل نقدى")
                {

                    AppSetting.TyprReceipt = "إيصال إستلام نقدية";

                    AppSetting.Mosadad = txtMosadad.Text;
                }
                else if (FormName == "دفع نقدى")
                {
                    AppSetting.TyprReceipt = "إيصال دفع نقدية";

                    AppSetting.Mosadad = txtDafaa.Text;
                }

                    
                AppSetting.ClintID = ClintID;
                AppSetting.ClintName = comName.Text;
                AppSetting.dateTimePicker1 = dateTimePicker2.Value.ToString("yyyy/MM/dd");
                AppSetting.RemaningOld = txtRemaningOld.Text;
               
                AppSetting.Dic = txtDic.Text;
                AppSetting.AddMoney = txtAdd.Text;
                AppSetting.RemainingNow = txtRemainingNow.Text;
                AppSetting.Note = textNote.Text;
                AppSetting.NumRest = textBillingDataNumBill1.Text;

                Reports.Frm_ReceiptOfCash rbm = new Reports.Frm_ReceiptOfCash();
                //rbm.reportViewer1.LocalReport.DataSources.Clear();
                //rbm.reportViewer1.LocalReport.DataSources.Add(rs);
                //------------------------------------------------------
                rbm.ShowDialog();

            }
        }

        private void txtDic_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
            // keys(sender, e);
        }

        private void txtAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
            // keys(sender, e);
        }

        private void txtMosadad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
            // keys(sender, e);
        }

        private void txtDafaa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
            //keys(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == false)
            {

                panel10.Visible = true;
                textSearchClint.Focus();
            }
            else
            {
                panel10.Visible = false;
            }
        }

        private void textSearchClint_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter(@"Select ID,Name,Company,TelHome,TelMobil,Address,PreviousBalance From Clients where  Name like '%" + textSearchClint.Text + "%'", cn);

                da.Fill(dt);
                this.dataGridSearchClint.DataSource = dt;
            }
            catch
            { }
        }

        private void textSearchClintMobil_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                SqlDataAdapter da = new SqlDataAdapter(@"Select ID,Name,Company,TelHome,TelMobil,Address,PreviousBalance From Clients where TelMobil like '%" + textSearchClintMobil.Text + "%' ", cn);

                da.Fill(dt);
                this.dataGridSearchClint.DataSource = dt;
            }
            catch
            { }
        }

        private void dataGridSearchClint_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comName.Text = dataGridSearchClint.Rows[e.RowIndex].Cells[1].Value.ToString();
            panel10.Visible = false;
            butSearch.PerformClick();
        }

        private void ClientsMoney_Click(object sender, EventArgs e)
        {
            if (panel10.Visible == true)
            {

                panel10.Visible = false;
                textSearchClint.Focus();
            }
            else
            {
                
            }
        }
    }
}
