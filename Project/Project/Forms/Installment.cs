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
    public partial class Installment : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;

        //-------------------------
        private SqlDataReader red;
        private SqlDataReader read;
        string InstallmentID = "";

        ClientsMoney ClientsMoney1;

        public Installment()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }

        private void closePanel()
        {
            panelAllInstallment.Visible = false;
        }
        public class Class_Installment
        {

            public string ID { get; set; }
            public string InstallmentID { get; set; }
            public string NumBill { get; set; }
            public string InstallmentHistory { get; set; }
            public string Recipient { get; set; }
            public string Date { get; set; }
            public string Paid { get; set; }



        }
        public class Class_InstallmentData
        {

            public string InstallmentID { get; set; }
            public string ClientName { get; set; }
            public string ClientID { get; set; }
            public string Date { get; set; }
            public string TotalBill { get; set; }
            public string Paid { get; set; }
            public string Remeaning { get; set; }



        }
        public void GetInstallmentID()
        {
            //try
            //{


            sqlCommand1.CommandText = "select * From InstallmentData  Where InstallmentID =(select max(InstallmentID) from InstallmentData) ";
            red = sqlCommand1.ExecuteReader();
            while (red.Read())
            {
                double s = Convert.ToDouble(red["InstallmentID"].ToString());
                double aa = s + 1;
                textInstallmentID.Text = aa.ToString();


            }
            red.Close();

            if (textInstallmentID.Text == "")
            {
                textInstallmentID.Text = "1";
            }
            else
            { }

            InstallmentID = textInstallmentID.Text;

            //}
            //catch
            //{
            //    MessageBox.Show("  يوجد خطأ فى البيانات1111111111111111111   ", "    خطأ   ");
            //}
        }
        private void Installment_Load(object sender, EventArgs e)
        {
            textClient.Text = AppSetting.ClintName;
            textClientID.Text = AppSetting.ClintID;
            textTotal.Text = AppSetting.TotalBill;
            textMokadam.Text = AppSetting.Mosadad;
            textRemaining.Text = AppSetting.RemainingNow;
            textNumBill.Text = AppSetting.BillingDataNumBill;

            
            //----------------------
            sqlCommand1.CommandText = "select * from InstallmentData where NumBill = '" + textNumBill.Text + "'";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                textInstallmentID.Text = read["InstallmentID"].ToString();

            }
            read.Close();

            if (textInstallmentID.Text != "")
            {
                //------------------------------------
                DataTable dt33 = new DataTable();
                dt33.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Installment where InstallmentID = '" + textInstallmentID.Text + "' ", cn);
                da11.Fill(dt33);
                this.dataGridView1.DataSource = dt33;

                //---------- اجمالى المدفوع
                double sum1 = 0;
                for (int s = 0; s < dataGridView1.RowCount; ++s)
                {
                    sum1 += Convert.ToDouble(dataGridView1.Rows[s].Cells[6].Value);


                }

                textTotalMosadad.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();

                //---------- اجمالى الباقى
                double a = Convert.ToDouble(textTotalMosadad.Text);
                double b = Convert.ToDouble(textRemaining.Text);
                double c = b - a;


                textTotalRemaining.Text = Math.Round(double.Parse(c.ToString()), 0).ToString();

                butSave.Enabled = false;
            }
            else
            { }

            //------------------------------------
            String State = "غير منتهى";
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from InstallmentData where State = '" + State + "' ", cn);
            da2.Fill(dt2);
            this.dataGridView2.DataSource = dt2;
        }

        private void butImageClint_Click(object sender, EventArgs e)
        {
            OpenFileDialog og1 = new OpenFileDialog();

            var _with1 = og1;
            og1.Title = "(Select Image) (تحديد صورة)";
            og1.Filter = "JPEG,BMP,PNG  (تحديد صورة) (Select Image) |*.jpg;*.jpeg;*.bmp;*.png";

            if (og1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picClientCard.Image = Image.FromFile(og1.FileName);
            }
            else
            {
                MessageBox.Show("عفواً ألغي الأمر بناء على طلبك");
                this.Focus();
            }
        }

        private void butImageClint2_Click(object sender, EventArgs e)
        {
            OpenFileDialog og1 = new OpenFileDialog();

            var _with1 = og1;
            og1.Title = "(Select Image) (تحديد صورة)";
            og1.Filter = "JPEG,BMP,PNG  (تحديد صورة) (Select Image) |*.jpg;*.jpeg;*.bmp;*.png";

            if (og1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picClientCard1.Image = Image.FromFile(og1.FileName);
            }
            else
            {
                MessageBox.Show("عفواً ألغي الأمر بناء على طلبك");
                this.Focus();
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            GetInstallmentID();

            if (textClient.Text == "")
            {
                MessageBox.Show("       من فضلك إختار اسم العميل            ", "  خطأ  ");
                textClient.Focus();
            }
            else
            {
                //----------------------- اضافة الصنف فى الجدول  -------

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                picClientCard.Image.Save(ms, picClientCard.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                System.IO.MemoryStream ms1 = new System.IO.MemoryStream();
                picClientCard.Image.Save(ms1, picClientCard.Image.RawFormat);
                byte[] byteImage1 = ms1.ToArray();

                sqlCommand1.CommandText = "insert into InstallmentData (ClientID,ClientName,ClientNumCard,ClientPhone,ClientImageCard,GuarantorName,GuarantorNumCard,GuarantorPhone,GuarantorImageCard,NumBill,Date,TotalBill,Paid,Remeaning,DateFristInstallment,NumInstallment,TypeInstallment,State)values" +
                    "(@ClientID,@ClientName,@ClientNumCard,@ClientPhone,@ClientImageCard,@GuarantorName,@GuarantorNumCard,@GuarantorPhone,@GuarantorImageCard,@NumBill,@Date,@TotalBill" +
                    ",@Paid,@Remeaning,@DateFristInstallment,@NumInstallment,@TypeInstallment,@State)";
                sqlCommand1.Parameters.Add("@ClientID", SqlDbType.VarChar).Value = textClientID.Text;
                sqlCommand1.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = textClient.Text;
                sqlCommand1.Parameters.Add("@ClientNumCard", SqlDbType.VarChar).Value = textNumCard.Text;
                sqlCommand1.Parameters.Add("@ClientPhone", SqlDbType.VarChar).Value = textPhone.Text;
                //sqlCommand1.Parameters.Add("@ClientImageCard", SqlDbType.VarChar).Value = combCategorys.Text;
                sqlCommand1.Parameters.Add("@GuarantorName", SqlDbType.VarChar).Value = textClient1.Text;
                sqlCommand1.Parameters.Add("@GuarantorNumCard", SqlDbType.VarChar).Value = textNumCard1.Text;
                sqlCommand1.Parameters.Add("@GuarantorPhone", SqlDbType.VarChar).Value = textPhone1.Text;
                //sqlCommand1.Parameters.Add("@GuarantorImageCard", SqlDbType.VarChar).Value = combCategorys.Text;
                sqlCommand1.Parameters.Add("@NumBill", SqlDbType.VarChar).Value = textNumBill.Text;
                sqlCommand1.Parameters.Add("@Date", SqlDbType.VarChar).Value = dateTimePicker2.Value.ToString("MM/dd/yyyy");
                sqlCommand1.Parameters.Add("@TotalBill", SqlDbType.VarChar).Value = textTotal.Text;
                sqlCommand1.Parameters.Add("@Paid", SqlDbType.VarChar).Value = textMokadam.Text;
                sqlCommand1.Parameters.Add("@Remeaning", SqlDbType.VarChar).Value = textRemaining.Text;
                sqlCommand1.Parameters.Add("@DateFristInstallment", SqlDbType.VarChar).Value = DateFristInstallment.Value.ToString("MM/dd/yyyy");
                sqlCommand1.Parameters.Add("@NumInstallment", SqlDbType.VarChar).Value = textNumInstallment.Text;
                sqlCommand1.Parameters.Add("@TypeInstallment", SqlDbType.VarChar).Value = combTypeInstallment.Text;
                sqlCommand1.Parameters.Add("@State", SqlDbType.VarChar).Value = textState.Text;


                sqlCommand1.Parameters.Add("@ClientImageCard", SqlDbType.Image).Value = byteImage;
                sqlCommand1.Parameters.Add("@GuarantorImageCard", SqlDbType.Image).Value = byteImage1;

                sqlCommand1.ExecuteNonQuery();

                sqlCommand1.Parameters.Clear();


                // ---------------------    ايجاد الكود الصنف ------------
                //sqlCommand1.CommandText = "select * from Category where Category = '" + combCategorys.Text + "' ";
                //read = sqlCommand1.ExecuteReader();
                //while (read.Read())
                //{
                //    IDCategory = read["ID"].ToString();
                //}
                //read.Close();



                try
                {
                    sqlCommand1.CommandText = "delete from Installment where InstallmentID = '" + textInstallmentID.Text + "'   ";
                    sqlCommand1.ExecuteNonQuery();
                }
                catch
                { }


                //--------------

                DateLastInstallment.Value = DateFristInstallment.Value; // تاريخ بداية القسط
                double num = Convert.ToDouble(textNumInstallment.Text);


                for (int i = 0; i < num; i++)
                {


                    sqlCommand1.CommandText = "insert into Installment (InstallmentID,NumBill,InstallmentHistory,Recipient,Paid) values ('" + textInstallmentID.Text + "','" + textNumBill.Text + "','" + DateLastInstallment.Value.ToString("MM/dd/yyyy") + "','" + textRecipient.Text + "','" + textPaid.Text + "')";
                    sqlCommand1.ExecuteNonQuery();
                    if (combTypeInstallment.Text == "شهرى")
                    {
                        DateLastInstallment.Value = DateLastInstallment.Value.AddMonths(1); // اضافة شهر
                    }
                    else if (combTypeInstallment.Text == "سنوى")
                    {
                        DateLastInstallment.Value = DateLastInstallment.Value.AddYears(1); // اضافة سنة

                    }
                    else if (combTypeInstallment.Text == "اسبوعى")
                    {
                        DateLastInstallment.Value = DateLastInstallment.Value.AddDays(7); // اضافة اسبوع

                    }
                }



                //try
                //{
                //    //=================إضافة الأسعار الشراء الجمله والمستهلك  
                //    sqlCommand1.CommandText = "insert into CategoryPrice (ID,Category,Date,PriceShraa,PriceGomla,PriceMostahlek,Faction)values ('" + IDCategory + "','" + combCategorys.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + PriceSheraNew + "','" + PriceGomla + "','" + PriceMostahlek + "','" + comboBox7.Text + "')";
                //    sqlCommand1.ExecuteNonQuery();
                //}
                //catch
                //{
                //    sqlCommand1.CommandText = "update CategoryPrice set  Date ='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',PriceShraa = '" + PriceSheraNew + "',PriceGomla = '" + PriceGomla + "',PriceMostahlek = '" + PriceMostahlek + "',Faction= '" + comboBox7.Text + "' where  Category ='" + combCategorys.Text + "' ";
                //    sqlCommand1.ExecuteNonQuery();
                //    // MessageBox.Show("   الحمد لله لقد تم إضافة الكميه للصنف    ", "  إضافه ");
                //}



                //------------------------------------
                DataTable dt33 = new DataTable();
                dt33.Clear();
                SqlDataAdapter da11 = new SqlDataAdapter("select * from Installment where InstallmentID = '" + textInstallmentID.Text + "' ", cn);
                da11.Fill(dt33);
                this.dataGridView1.DataSource = dt33;


                butSave.Enabled = false;
                butEdit.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand1.CommandText = "delete from Installment where InstallmentID = '" + textInstallmentID.Text + "'   ";
                sqlCommand1.ExecuteNonQuery();
            }
            catch
            { }


            //--------------

            DateLastInstallment.Value = DateFristInstallment.Value; // تاريخ بداية القسط
            double num = Convert.ToDouble(textNumInstallment.Text);


            for (int i = 0; i < num; i++)
            {
                
               
                sqlCommand1.CommandText = "insert into Installment (InstallmentID,NumBill,InstallmentHistory,Recipient,Paid) values ('" + textInstallmentID.Text + "','" + textNumBill.Text + "','" + DateLastInstallment.Value.ToString("MM/dd/yyyy") + "','" + textRecipient.Text + "','" + textPaid.Text + "')";
                sqlCommand1.ExecuteNonQuery();
                if (combTypeInstallment.Text == "شهرى")
                {
                    DateLastInstallment.Value = DateLastInstallment.Value.AddMonths(1); // اضافة شهر
                }
                else if (combTypeInstallment.Text == "سنوى")
                {
                    DateLastInstallment.Value = DateLastInstallment.Value.AddYears(1); // اضافة سنة

                }
                else if (combTypeInstallment.Text == "اسبوعى")
                {
                    DateLastInstallment.Value = DateLastInstallment.Value.AddDays(7); // اضافة اسبوع

                }
            }





            //------------------------------------
            DataTable dt33 = new DataTable();
            dt33.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Installment where InstallmentID = '" + textInstallmentID.Text + "' ", cn);
            da11.Fill(dt33);
            this.dataGridView1.DataSource = dt33;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //------------------------------------
            String State = "غير منتهى";
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from InstallmentData  ", cn);
            da2.Fill(dt2);
            this.dataGridView2.DataSource = dt2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //------------------------------------
            String State = "خالص";
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from InstallmentData where State = '" + State + "' ", cn);
            da2.Fill(dt2);
            this.dataGridView2.DataSource = dt2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //------------------------------------
            String State = "غير منتهى";
            DataTable dt2 = new DataTable();
            dt2.Clear();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from InstallmentData where State = '" + State + "' ", cn);
            da2.Fill(dt2);
            this.dataGridView2.DataSource = dt2;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textInstallmentID.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

            //----------------------------------
            textClientID.Text = "";
            textClient.Text = "";
            textNumCard.Text = "";
            textPhone.Text = "";
            textClient1.Text = "";
            textNumCard1.Text = "";
            textPhone1.Text = "";
            textNumBill.Text = "";
            //dateTimePicker2.Text = read["Date"].ToString();//----Date
            textTotal.Text = "";
            textMokadam.Text = "";
            textRemaining.Text = "";
            //DateFristInstallment.Text = read["DateFristInstallment"].ToString();//----Date
            textNumInstallment.Text = "";
            combTypeInstallment.Text = "";
            textState.Text = "";
            //----------------------------------

            sqlCommand1.CommandText = "select * from InstallmentData where InstallmentID = '" + textInstallmentID.Text + "'";
            read = sqlCommand1.ExecuteReader();
            while (read.Read())
            {
                textClientID.Text = read["ClientID"].ToString();
                textClient.Text = read["ClientName"].ToString();
                textNumCard.Text = read["ClientNumCard"].ToString();
                textPhone.Text = read["ClientPhone"].ToString();
                textClient1.Text = read["GuarantorName"].ToString();
                textNumCard1.Text = read["GuarantorNumCard"].ToString();
                textPhone1.Text = read["GuarantorPhone"].ToString();
                textNumBill.Text = read["NumBill"].ToString();
                dateTimePicker2.Text = read["Date"].ToString();//----Date
                textTotal.Text = read["TotalBill"].ToString();
                textMokadam.Text = read["Paid"].ToString();
                textRemaining.Text = read["Remeaning"].ToString();
                DateFristInstallment.Text = read["DateFristInstallment"].ToString();//----Date
                textNumInstallment.Text = read["NumInstallment"].ToString();
                combTypeInstallment.Text = read["TypeInstallment"].ToString();
                textState.Text = read["State"].ToString();

            }
            read.Close();

            //------------------------------------
            DataTable dt33 = new DataTable();
            dt33.Clear();
            SqlDataAdapter da11 = new SqlDataAdapter("select * from Installment where InstallmentID = '" + textInstallmentID.Text + "' ", cn);
            da11.Fill(dt33);
            this.dataGridView1.DataSource = dt33;

            //---------- اجمالى المدفوع
            double sum1 = 0;
            for (int s = 0; s < dataGridView1.RowCount ; ++s)
            {
                sum1 += Convert.ToDouble(dataGridView1.Rows[s].Cells[6].Value);
                

            }

            textTotalMosadad.Text = Math.Round(double.Parse(sum1.ToString()), 2).ToString();

            //---------- اجمالى الباقى
            double a = Convert.ToDouble(textTotalMosadad.Text);
            double b = Convert.ToDouble(textRemaining.Text);
            double c = b - a;


            textTotalRemaining.Text = Math.Round(double.Parse(c.ToString()), 0).ToString();

            butSave.Enabled = false;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string ClientName = textClient.Text;
            string NumInstallment = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();  // ------ رقم القسط
                                                                                               //textBox1.Text = dataGrData.Rows[e.RowIndex].Cells[3].Value.ToString();
                                                                                               //textBox2.Text = dataGrData.Rows[e.RowIndex].Cells[0].Value.ToString();

            // this.Close();

            TransferData.ClientName = textClient.Text;
            TransferData.NumInstallment = NumInstallment;
            TransferData.FormName = "تحصيل قسط"; 
            TransferData.InstallmentID = textInstallmentID.Text;

            if (ClientsMoney1 == null || ClientsMoney1.IsDisposed == true)
                {
                ClientsMoney1 = new ClientsMoney();
                }
                ClientsMoney1.MdiParent = Main.ActiveForm;
                ClientsMoney1.Show();

            TransferData.NumInstallment = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textNumInstallment_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClassProject.ClassCloseLettering kkey = new ClassProject.ClassCloseLettering();
            kkey.keysCloseLettering(sender, e);
        }

        private void buttonAllInstallment_Click(object sender, EventArgs e)
        {
            if(panelAllInstallment.Visible==true)
            {
                panelAllInstallment.Visible = false;
            }
            else
            {
                panelAllInstallment.Visible = true;
            }
        }

        private void Installment_Click(object sender, EventArgs e)
        {
            closePanel();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            closePanel();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            closePanel();
        }
    }
}
