using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace ioop_GROUP_WORK.HR
{
    internal class VP
    {
        public string StudentName { get; set; }
        public string Position { get; set; }
        public DateTime DateApplied { get; set; }
        public string Status { get; set; }

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public VP(string student)
        {
            StudentName= student;
        }

        public VP ViewProfile()
        {
            VP student = null;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentApplication WHERE StudentName = @name", con);
            cmd.Parameters.AddWithValue("@name", StudentName);

            SqlDataReader rd = cmd. ExecuteReader();

            if (rd.Read())
            {
                student = new VP(rd["StudentName"].ToString())
                {  
                    Position = rd["Position"].ToString(),
                    DateApplied = Convert.ToDateTime(rd["DateApplied"]),
                    Status = rd["Status"].ToString()
                };
                
            }
           
            rd.Close();
            con.Close();

            return student;
        }

        public static List<string> GetAllStudentNames()
        {
            List<string> names = new List<string>();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT StudentName FROM StudentApplication", con);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                names.Add(rd["StudentName"].ToString());
            }

            rd.Close();
            con.Close();

            return names;
        }
    }
}
