using System;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class StudentReportUpload
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        // Method to upload the report to the database
        public string UploadReport(string studentID, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return "Please select an image to upload.";
            }

            try
            {
                byte[] fileData = File.ReadAllBytes(filePath);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"INSERT INTO Student_Reports (studentID, Report, uploadDate)
                                     VALUES (@studentID, @Report, @uploadDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@Report", fileData);
                    cmd.Parameters.AddWithValue("@uploadDate", DateTime.Now);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        return "Report uploaded successfully!";
                    }
                    else
                    {
                        return "Report upload failed!";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error during file upload: {ex.Message}";
            }
        }
    }
}
