using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class ViewApplicationStatus
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        public DataTable GetApplicationStatus(string studentID)
        {
            DataTable applicationTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"SELECT sa.Position, io.JobTitle, io.StartDate, io.EndDate, io.Salary AS Allowance, sa.CompanyName, sa.Status
                                 FROM StudentApplication sa
                                 INNER JOIN InternshipOffer io ON sa.Position = io.Position
                                 WHERE sa.StudentID = @studentID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(applicationTable);
                con.Close();
            }

            return applicationTable;
        }
    }
}
