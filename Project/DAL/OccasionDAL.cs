using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.SqlClient;
using ZAD_Sales.Models;

namespace ZAD_Sales.DAL
{
    public class OccasionDAL
    {
        private readonly string connectionString;

        public OccasionDAL(string connString)
        {
            connectionString = connString;
        }

        public List<Occasion> GetUpcomingOccasions()
        {
            List<Occasion> occasions = new List<Occasion>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"DECLARE @Today DATETIME = CONVERT(DATE, GETDATE());

        SELECT 
            OccasionID,
            OccasionName,
            OccasionDate,
            ReminderDays,
            Description,
            RepeatYearly,
            CASE 
                WHEN RepeatYearly = 0 
                    THEN DATEDIFF(DAY, @Today, OccasionDate)
                ELSE DATEDIFF(
                        DAY,
                        @Today,
                        CONVERT(
                            DATETIME,
                            CAST(YEAR(@Today) AS VARCHAR(4)) + '-' +
                            RIGHT('0' + CAST(MONTH(OccasionDate) AS VARCHAR(2)), 2) + '-' +
                            RIGHT('0' + CAST(DAY(OccasionDate) AS VARCHAR(2)), 2)
                        )
                    )
            END AS DaysLeft
        FROM Occasions
        WHERE
            (
                RepeatYearly = 0
                AND DATEDIFF(DAY, @Today, OccasionDate) BETWEEN 0 AND ReminderDays
            )
            OR
            (
                RepeatYearly = 1
                AND DATEDIFF(
                        DAY,
                        @Today,
                        CONVERT(
                            DATETIME,
                            CAST(YEAR(@Today) AS VARCHAR(4)) + '-' +
                            RIGHT('0' + CAST(MONTH(OccasionDate) AS VARCHAR(2)), 2) + '-' +
                            RIGHT('0' + CAST(DAY(OccasionDate) AS VARCHAR(2)), 2)
                        )
                    ) BETWEEN 0 AND ReminderDays
            )
        ORDER BY OccasionDate;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        occasions.Add(new Occasion
                        {
                            OccasionID = Convert.ToInt32(reader["OccasionID"]),
                            OccasionName = reader["OccasionName"].ToString(),
                            OccasionDate = Convert.ToDateTime(reader["OccasionDate"]),
                            ReminderDays = Convert.ToInt32(reader["ReminderDays"]),
                            Description = reader["Description"].ToString(),
                            RepeatYearly = Convert.ToBoolean(reader["RepeatYearly"]),
                            DaysLeft = Convert.ToInt32(reader["DaysLeft"])
                        });
                    }
                }
            }

            return occasions;

            //List<Occasion> occasions = new List<Occasion>();

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            // ============================   الكود الغير متوافق مع sql2008
            //    string query = @"
            //        DECLARE @Today DATE = CAST(GETDATE() AS DATE);
            //        SELECT OccasionID, OccasionName, OccasionDate, ReminderDays, Description, RepeatYearly,
            //               DATEDIFF(DAY, @Today, OccasionDate) AS DaysLeft
            //        FROM Occasions
            //        WHERE 
            //            DATEDIFF(DAY, @Today, OccasionDate) BETWEEN 0 AND ReminderDays
            //            OR 
            //            (RepeatYearly = 1 AND 
            //             DATEDIFF(DAY, @Today, DATEFROMPARTS(YEAR(@Today), MONTH(OccasionDate), DAY(OccasionDate))) BETWEEN 0 AND ReminderDays)
            //        ORDER BY OccasionDate;";

            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            occasions.Add(new Occasion
            //            {
            //                OccasionID = Convert.ToInt32(reader["OccasionID"]),
            //                OccasionName = reader["OccasionName"].ToString(),
            //                OccasionDate = Convert.ToDateTime(reader["OccasionDate"]),
            //                ReminderDays = Convert.ToInt32(reader["ReminderDays"]),
            //                Description = reader["Description"].ToString(),
            //                RepeatYearly = Convert.ToBoolean(reader["RepeatYearly"]),
            //                DaysLeft = Convert.ToInt32(reader["DaysLeft"])
            //            });
            //        }
            //    }
            //}

            //return occasions;
        }

        public void AddOccasion(Occasion occ)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO Occasions (OccasionName, OccasionDate, ReminderDays, Description, RepeatYearly)
                       VALUES (@Name, @Date, @Reminder, @Desc, @Repeat)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", occ.OccasionName);
                    cmd.Parameters.AddWithValue("@Date", occ.OccasionDate);
                    cmd.Parameters.AddWithValue("@Reminder", occ.ReminderDays);
                    cmd.Parameters.AddWithValue("@Desc", (object)occ.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Repeat", occ.RepeatYearly);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOccasion(Occasion occ)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Occasions 
                       SET OccasionName=@Name, OccasionDate=@Date, ReminderDays=@Reminder, 
                           Description=@Desc, RepeatYearly=@Repeat
                       WHERE OccasionID=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", occ.OccasionID);
                    cmd.Parameters.AddWithValue("@Name", occ.OccasionName);
                    cmd.Parameters.AddWithValue("@Date", occ.OccasionDate);
                    cmd.Parameters.AddWithValue("@Reminder", occ.ReminderDays);
                    cmd.Parameters.AddWithValue("@Desc", (object)occ.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Repeat", occ.RepeatYearly);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOccasion(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Occasions WHERE OccasionID=@ID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Occasion> GetAllOccasions()
        {
            List<Occasion> occasions = new List<Occasion>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Occasions ORDER BY OccasionDate";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        occasions.Add(new Occasion
                        {
                            OccasionID = Convert.ToInt32(reader["OccasionID"]),
                            OccasionName = reader["OccasionName"].ToString(),
                            OccasionDate = Convert.ToDateTime(reader["OccasionDate"]),
                            ReminderDays = Convert.ToInt32(reader["ReminderDays"]),
                            Description = reader["Description"].ToString(),
                            RepeatYearly = Convert.ToBoolean(reader["RepeatYearly"])
                        });
                    }
                }
            }
            return occasions;
        }

    }
}
