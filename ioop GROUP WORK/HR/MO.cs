using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.CompilerServices;


namespace ioop_GROUP_WORK.HR
{
    internal class MO
    {
        private string jobTitle;
        private string position;
        private DateTime start;
        private DateTime end;
        private double salary;
        private string jobDescription;
        

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public string JobTitle { get => jobTitle; private set => jobTitle = value; }
        public string Position { get => position; private set => position = value; }
        public DateTime Start { get => start; private set => start = value; }
        public DateTime End { get => end; private set => end = value; }
        public double Salary { get => salary; private set => salary = value; }
        public string JobDescription { get => jobDescription; private set => jobDescription = value; }

        public MO(string jobTitle, string position, DateTime start, DateTime end, double salary, string jobDescription)
        {
            JobTitle = jobTitle;
            Position = position;
            Start = start;
            End = end;
            Salary = salary;
            JobDescription = jobDescription;
        }

        public string SendApplication(string companyname)
        {
            string message = "";
            DateTime timenow = DateTime.Now;

            try
            {
                con.Open();

                // Compute next StudentID because InternshipOffer.StudentID is NOT NULL and not identity in schema
                int nextId = 1;
                using (SqlCommand idCmd = new SqlCommand("SELECT ISNULL(MAX(StudentID), 0) + 1 FROM InternshipOffer", con))
                {
                    object idObj = idCmd.ExecuteScalar();
                    if (idObj != null && int.TryParse(idObj.ToString(), out int parsed))
                        nextId = parsed;
                }
                               
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO InternshipOffer " +
                    "(StudentID, StudentName, Position, StartDate, EndDate, Salary, Description, DateOffered) " +
                    "VALUES (@studentId, @studentName, @position, @startDate, @endDate, @salary, @description, @dateO)", con);

                // Use jobTitle as StudentName field to preserve existing logic (UI supplies jobTitle)
                cmd.Parameters.AddWithValue("@studentId", nextId);
                cmd.Parameters.AddWithValue("@studentName", jobTitle ?? "");
                cmd.Parameters.AddWithValue("@position", Position ?? "");
                cmd.Parameters.AddWithValue("@startDate", Start);
                cmd.Parameters.AddWithValue("@endDate", End);
                cmd.Parameters.AddWithValue("@salary", Salary);
                cmd.Parameters.AddWithValue("@description", JobDescription ?? "");
                cmd.Parameters.AddWithValue("@dateO", timenow);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    message = "Application sent successfully!";
                else
                    message = "Failed to send application.";
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }

            return message;
        }
                
        public static List<string> AddJobPosition(string department)
        {

            List<string> positions = new List<string>();
            if (department == "Management & Administration")
            {
                positions.AddRange(new List<string>()
                {
                    "Chief Executive Officer (CEO)",
                    "General Manager (GM)",
                    "Operations Manager",
                    "Administrative Assistant",
                    "Office Clerk",
                    "Receptionist"
                });
            }
            else if (department == "Human Resources (HR)")
            {
                positions.AddRange(new List<string>()
                {
                    "HR Manager",
                    "HR Executive / Officer",
                    "Recruitment Specialist",
                    "Training Coordinator",
                    "Payroll Administrator"
                });
            }
            else if (department == "Finance & Accounting")
            {
                positions.AddRange(new List<string>()
                {
                    "Finance Manager",
                    "Accountant",
                    "Accounts Executive",
                    "Auditor",
                    "Billing Clerk"
                });
            }
            else if (department == "Information Technology (IT)")
            {
                positions.AddRange(new List<string>()
                {
                    "IT Manager",
                    "Software Developer",
                    "System Administrator",
                    "IT Support Technician",
                    "Database Administrator"
                });
            }
            else if (department == "Sales & Marketing")
            {
                positions.AddRange(new List<string>()
                {
                    "Sales Manager",
                    "Sales Executive / Representative",
                    "Marketing Manager",
                    "Digital Marketing Executive",
                    "Customer Service Officer"
                });
            }
            else if (department == "Production / Operations")
            {
                positions.AddRange(new List<string>()
                {
                    "Production Supervisor",
                    "Machine Operator",
                    "Quality Control Inspector",
                    "Warehouse Assistant",
                    "Logistics Coordinator"
                });
            }
            else if (department == "Maintenance & Support")
            {
                positions.AddRange(new List<string>()
                {
                    "Cleaner",
                    "Security Guard",
                    "Driver",
                    "Maintenance Technician"
                });
            }

            return positions;


        }
    }
}
