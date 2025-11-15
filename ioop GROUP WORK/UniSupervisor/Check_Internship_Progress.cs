using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class Check_Internship_Progress
    {
        // Attributes
        private string student_id;
        private string student_name;
        private DateTime check_in_date;
        

        public string Student_id { get => student_id; set => student_id = value; }
        public string Student_name { get => student_name; set => student_name = value; }
        public DateTime Check_in_date { get => check_in_date; set => check_in_date = value; }

        // Constructors
        public Check_Internship_Progress(string student_id, string student_name, DateTime check_in_date)
        {
            this.student_id = student_id;
            this.student_name = student_name;
            this.check_in_date = check_in_date;
        }

        // Methods
        public List<Check_Internship_Progress> GetAllCheckInRecord()
        {
           List<Check_Internship_Progress> records = new List<Check_Internship_Progress>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            { 
                con.Open();
                string query_cmd = @"SELECT studentID, studentName, checkInDate FROM Check_In_Record WHERE studentID = @id ORDER BY checkInDate DESC";
                using (SqlCommand cmd = new SqlCommand(query_cmd, con))
                {
                    cmd.Parameters.AddWithValue("@id", this.student_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader.GetString(0);
                            string name = reader.GetString(1);
                            DateTime date = reader.GetDateTime(2);
                            records.Add(new Check_Internship_Progress(id, name, date));
                        }
                    }
                }
            }
            return records;
        }
        public static int GetMonthlyCheckInCount(string studentID, DateTime date)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(DBConnection.connectionString))
            {
                conn.Open();

                string query = @"SELECT COUNT(*) FROM Check_In_Record WHERE studentID = @StudentID AND MONTH(checkInDate) = @Month AND YEAR(checkInDate) = @Year";
                   
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Month", date.Month);
                    cmd.Parameters.AddWithValue("@Year", date.Year);

                    count = (int)cmd.ExecuteScalar();
                }
            }

            return count;
        }

        public static double CalculateCheckInPercentage(string studentID, DateTime date, int requiredDays)
        {
            if (requiredDays <= 0)
            { 
                return 0;
            }

            int actualDays = GetMonthlyCheckInCount(studentID, date);
            double percentage = ((double)actualDays / requiredDays) * 100;
        }
    }
}
