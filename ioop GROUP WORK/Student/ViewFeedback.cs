using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class ViewFeedback
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        public DataTable GetEvaluationReport(string studentID)
        {
            DataTable evaluationReport = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Fetch student's evaluation data
                    string query = "SELECT Position, Performance, CommunicationSkills, Punctuality, Description " +
                                   "FROM Student_Evaluation_Report WHERE studentID = @studentID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(evaluationReport); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading evaluation report: {ex.Message}");
            }

            return evaluationReport;
        }
    }
}
