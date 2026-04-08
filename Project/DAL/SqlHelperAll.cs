using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ZAD_Sales.DAL
{
    public static class SqlHelperAll
    {
        /// <summary>
        /// الحصول على اتصال SQL مفتوح وجاهز
        /// </summary>
        public static SqlConnection GetOpenConnection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
            SqlConnection cn = new SqlConnection(constring);
            cn.Open(); // يفتح الاتصال قبل إرجاعه
            return cn;
        }

        /// <summary>
        /// تنفيذ استعلام وارجاع SqlDataReader (المسؤولية على الفورم لغلق القارئ والاتصال)
        /// </summary>
        public static SqlDataReader ExecuteReader(string query, params SqlParameter[] parameters)
        {
            SqlConnection cn = GetOpenConnection();
            SqlCommand cmd = new SqlCommand(query, cn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            // القارئ المفتوح يجب غلقه في الفورم باستخدام using
            return cmd.ExecuteReader();
        }

        /// <summary>
        /// تنفيذ أمر (INSERT, UPDATE, DELETE) مع Transaction آمن
        /// </summary>
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection cn = GetOpenConnection())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// تنفيذ أمر Scalar (رجاع قيمة واحدة) مع Transaction آمن
        /// </summary>
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection cn = GetOpenConnection())
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}
