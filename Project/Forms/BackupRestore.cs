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
    public partial class BackupRestore : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        SqlCommand cmd;
        public BackupRestore()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Backup Files(*.Bak)|*.bak";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    cmd = new SqlCommand("ALTER Database ZAD SET OFFLINE WITH ROLLBACK IMMEDIATE; Restore Database ZAD From Disk ='" + op.FileName + "'", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("       تم استرجاع نسخة إحتياطية بنجاح    ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception b)
            {
                MessageBox.Show(b.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BackupRestore_Load(object sender, EventArgs e)
        {

        }
    }
}
