using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace ZAD_Sales.Forms
{
    public partial class FactionCategoreyAdd : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = AppSetting.user;
        string SystemPriceShera = AppSetting.PriceSheraaAcount;
        string AllowUser = AppSetting.AllowUser;
        string Kataey = AppSetting.textKataey;
        string Kataey1 = "";
        public FactionCategoreyAdd()
        {
            InitializeComponent();
            cn.Open();
            sqlCommand1.Connection = cn;
        }
        private void GetFactions()
        {
            try
            {
                SqlDataAdapter Da;
                DataTable Dt = new DataTable();
                Da = new SqlDataAdapter("select Faction from CategoryFaction where Type ='" + Kataey1 + "'", cn);
                Da.Fill(Dt);


                listBox1.DataSource = Dt;
                listBox1.DisplayMember = "Faction";
            }
            catch
            {

            }
        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = "insert into CategoryFaction (Faction,Type)values ('" + textFaction.Text + "','" + Kataey1 + "')";
            sqlCommand1.ExecuteNonQuery();

            //-------------------------------
            GetFactions();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            sqlCommand1.CommandText = "delete from CategoryFaction where Faction = '" + textFaction.Text + "'   ";
            sqlCommand1.ExecuteNonQuery();


            MessageBox.Show("  تم الحذف بنجاح  ", "   حذف   ");


            //-------------------------------
            GetFactions();
        }

        private void FactionCategoreyAdd_Load(object sender, EventArgs e)
        {
            if (Kataey == "1") // قطاعى
            {
                Kataey1 = "K";
            }
            else // جملة
            {
                Kataey1 = "G";
            }

            //-------------------------
            GetFactions();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          //  textFaction.Text = listBox1.SelectedValue.ToString();
        }
    }
}
