using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ioop_GROUP_WORK.UniSupervisor;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Data.SqlClient;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public class UniSupervisor
    {
        //Attributes

        public string student_name;
        public string student_id;
        public string student_email;
        public string student_phone;
        public string course_id;
        public string course_name;
        public string chapter_name;
        public double course_progress;

        // Connect to SQL Database
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        //Constructor
        public UniSupervisor(string student_name, string student_id, string student_email, string student_phone, string course_id, string course_name, string chapter_name)
        {
            this.student_name = student_name;
            this.student_id = student_id;
            this.student_email = student_email;
            this.student_phone = student_phone;
            this.course_name = course_name;
            this.chapter_name = chapter_name;
            this.course_id = course_id;
            this.course_progress = 0.00;
        }

        //Methods
        public static ArrayList Get_Student_Name() 
        {
            ArrayList student = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id, studentName FROM students", con);
            SqlDataReader reader = cmd.ExecuteReader();

            // Generate list of student names
            while (reader.Read())
            {
                student.Add(reader["Id"].ToString() + " - " + reader["studentName"].ToString());
            }
        }

        public void Display_Student_Details(int student_id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE Id = @student_id", con);
            cmd.Parameters.AddWithValue("@student_id", student_id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this.student_name = reader["studentName"].ToString();
                this.student_email = reader["email"].ToString();
                this.student_phone = reader["phoneNumber"].ToString();
                // Assuming course_progress is calculated or stored somewhere
            }
            con.Close();
        }

        public void Get_Course_Progress(int student_id, int course_id)
        {
            con.Open();
            string query_cmd = "SELECT Course_Id, Chapter_Id, Chapter_Name, Progress_Percecntage FROM Chapters INNER JOIN Courses ON Course_Id = Couse_Id LEFT JOIN Student_Progress ON Chapter_Id = Chapter_Id AND Student_Id = @student_id WHERE Course_Id = @course_id ORDER BY Chapter_Order";
            SqlCommand cmd = new SqlCommand(query_cmd, con);
            cmd.Parameters.AddWithValue("@student_id", student_id);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                this.course_progress = Convert.ToDouble(result);
            }
            con.Close();
        }
    }
}
