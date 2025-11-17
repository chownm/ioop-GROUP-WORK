using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class ViewCheckInRecord
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        public DataTable GetCheckInRecords(string studentID)
        {
            DataTable checkInRecords = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT checkInDate, studentName " +
                                   "FROM Check_In_Record " +
                                   "WHERE studentID = @studentID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(checkInRecords);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading check-in records: {ex.Message}");
            }

            return checkInRecords;
        }
    }
}
