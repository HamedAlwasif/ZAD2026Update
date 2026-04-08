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
    public partial class BackupSave : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        SqlCommand cmd;
        string DataName = "";

        public BackupSave()
        {
            InitializeComponent();

           // textUserName1.Text = AppSetting.user;
            DataName = Properties.Settings.Default.DataName; // يقرا اسم الداتا بيز من الخصائص
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Backup Files(*.Bak)|*.bak";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string Backup = "Backup Database " + DataName;

                  

                    cmd = new SqlCommand(Backup + " To Disk='" + sf.FileName + "'", cn);

                    //cmd = new SqlCommand("Backup Database ZAD To Disk='" + sf.FileName + "'", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("       تم أخذ نسخة إحتياطية بنجاح    ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void saveEvents(string Event)
        {

            //=========================== تسجيل الحركات  ========================== 
            try
            {
                cn.Open();
                //string Event = "تم فتح شاشة  " + TransferData.FormName;


                //sqlCommand1.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
                //sqlCommand1.ExecuteNonQuery();

                // MessageBox.Show("    تمت الاضافة بنجاح   ", "نجحت ");

                cn.Close();
                //---------------


            }
            catch
            {
                //MessageBox.Show("    فشلللللللللللللللللللللللللللللللل   ", "فشل ");
            }

            //========================== ========================== ========================== 
        }
        private void BackupSave_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
