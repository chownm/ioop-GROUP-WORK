using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class StudentCheckIn
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        public string CheckIn(string studentID, string studentName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"INSERT INTO Check_In_Record (studentID, studentName, checkInDate)
                                     VALUES (@studentID, @studentName, @checkInDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@studentName", studentName);
                    cmd.Parameters.AddWithValue("@checkInDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? "✅ Check-in successful!" : "❌ Check-in failed!";
                }
            }
            catch (Exception ex)
            {
                return $"❗ Error during check-in: {ex.Message}";
            }
        }
    }
}
