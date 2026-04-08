using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ZAD_Sales.Class
{
    public class EventsAllSave
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //--------------------------------
        private SqlDataReader reed;

        SqlCommand cmd;
        public void saveEventOpenForm(string Event)
        {

            ////=========================== تسجيل الحركات  ========================== 
            try
            {
                cn.Open();
                //string Event = "تم فتح شاشة  " + TransferData.FormName;

                string date11 = DateTime.Now.ToString("M/d/yyyy"); 
                cmd.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + date11 + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";
             //   cmd.CommandText = "insert into Events (Date,Time,Users,Events)values ('" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" + AppSetting.user + "','" + Event + "')";

                cmd.ExecuteNonQuery();


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
    }
}
