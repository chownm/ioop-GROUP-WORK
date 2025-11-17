using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class InternshipList
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        // Method to load internship offers from the database
        public DataTable LoadInternshipOffers()
        {
            DataTable internshipTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"SELECT io.Id AS InternshipID, 
                                        io.JobTitle, 
                                        io.Position, 
                                        io.StartDate, 
                                        io.EndDate, 
                                        io.Salary AS Allowance, 
                                        io.CompanyName
                                 FROM InternshipOffer io";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(internshipTable);
            }

            return internshipTable;
        }

        // Method to apply for an internship
        public string ApplyForInternship(string internshipId, string position, string companyName, string startDate, string endDate, string salary)
        {
            try
            {
                // Simulate application logic (this could involve database updates, etc.)
                return $"You have successfully applied for {position} at {companyName}.\nStart Date: {startDate}\nEnd Date: {endDate}\nSalary: {salary}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
