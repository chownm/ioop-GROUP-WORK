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
        private string studentname;
        private string jobTitle;
        private string position;
        private DateTime start;
        private DateTime end;
        private double salary;
        private string jobDescription;
        

        

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public string Studentname { get => studentname; set => studentname = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string Position { get => position; set => position = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public double Salary { get => salary; set => salary = value; }
        public string JobDescription { get => jobDescription; set => jobDescription = value; }

        public MO(string studentname,string jobTitle, string position, DateTime start, DateTime end, double salary, string jobDescription)
        {
            Studentname = studentname;
            JobTitle = jobTitle;
            Position = position;
            Start = start;
            End = end;
            Salary = salary;
            JobDescription = jobDescription;
            
  
        }

        public static List<string> GetAllStudentNames()
        {
            List<string> names = new List<string>();
            string newstatus = "Rejected";


            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT StudentName FROM StudentApplication WHERE Status = @status", con);
            cmd.Parameters.AddWithValue("@status", newstatus);


            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                names.Add(rd["StudentName"].ToString());
            }

            rd.Close();
            con.Close();

            return names;

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
