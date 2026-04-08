using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ZAD_Sales.DAL
{
    public static class CashBoxHelper
    {

        //----------------- ConnectionStrings ------------------
        public static readonly string constring =
    ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;




        /// <summary>
        /// إضافة حركة وارد أو صادر للصندوق
        /// </summary>
        public static bool AddBoxMove(
            int id,
            string moveType,        // "WARED" أو "SADER"
            string moveName,        // وصف الحركة
            string name,            // اسم الشخص / الجهة
            long numBill,           // رقم الفاتورة
            decimal amount,         // المبلغ
            string note = ""        // ملاحظات
        )
        {
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();

                try
                {
                    string query = @"
                        INSERT INTO BoxMove
                        (
                            ID, Date, Move, Name, NumBill,
                            Wared, Sader, Note
                        )
                        VALUES
                        (
                            @ID, GETDATE(), @Move, @Name, @NumBill,
                            @Wared, @Sader, @Note
                        )";

                    using (SqlCommand cmd = new SqlCommand(query, cn, tran))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@Move", SqlDbType.NVarChar, 150).Value = moveName;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = name;
                        cmd.Parameters.Add("@NumBill", SqlDbType.BigInt).Value = numBill;
                        cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = note ?? "";

                        if (moveType.ToUpper() == "WARED")
                        {
                            cmd.Parameters.Add("@Wared", SqlDbType.Decimal).Value = amount;
                            cmd.Parameters.Add("@Sader", SqlDbType.Decimal).Value = 0;
                        }
                        else if (moveType.ToUpper() == "SADER")
                        {
                            cmd.Parameters.Add("@Wared", SqlDbType.Decimal).Value = 0;
                            cmd.Parameters.Add("@Sader", SqlDbType.Decimal).Value = amount;
                        }
                        else
                        {
                            throw new Exception("نوع الحركة غير صحيح");
                        }

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }




        /// <summary>
        /// جلب رصيد الصندوق الحالي حتى الآن
        /// </summary>
        public static decimal GetCurrentBoxBalance()
        {
            decimal balance = 0;

            string query = @"
            SELECT 
                ISNULL(SUM(Wared), 0) - ISNULL(SUM(Sader), 0)
            FROM BoxMove";

            using (SqlConnection cn = new SqlConnection(constring))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                    balance = Convert.ToDecimal(result);
            }

            return balance;
        }
    }

}
