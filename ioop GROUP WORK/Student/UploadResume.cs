using System;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{

    public class UploadResume
    {
        
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        public string GetPositionFromDatabase(string internshipPosition)
        {
            string position = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT Position FROM InternshipOffer WHERE Position = @Position";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Position", internshipPosition);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        position = reader["Position"].ToString();
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching position: {ex.Message}");
            }

            return position;
        }



        public string SaveApplicationToDatabase(string studentID, string studentName, string position, string companyName, byte[] resumeImage)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO StudentApplication (StudentID, StudentName, Position, CompanyName, DateApplied, Status, Resume) " +
                                   "VALUES (@StudentID, @StudentName, @Position, @CompanyName, @DateApplied, @Status, @Resume)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    cmd.Parameters.AddWithValue("@Position", position);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Status", "Pending");
                    cmd.Parameters.AddWithValue("@Resume", resumeImage);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? "Application submitted successfully!" : "Failed to submit application.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving application: {ex.Message}");
            }
        }
    }
}
