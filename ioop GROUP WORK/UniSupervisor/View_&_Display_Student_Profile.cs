using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class View_Student_Profile
    {
        // Attributes
        public string student_name;
        public int student_id;
        public string email;
        public string phone_number;
        public string course_id;
        public string course_name;
        public string chapter_id;
        public string chapter_order;
        public string chapter_description;
        public double progress_percentage;

        // SQL Connection
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        // Constructor
        public View_Student_Profile(string student_name, int student_id, string email, string phone_number,
                                    string course_id, string course_name, string chapter_id,
                                    string chapter_order, string chapter_description, double progress_percentage)
        {
            this.student_name = student_name;
            this.student_id = student_id;
            this.email = email;
            this.phone_number = phone_number;
            this.course_id = course_id;
            this.course_name = course_name;
            this.chapter_id = chapter_id;
            this.chapter_order = chapter_order;
            this.chapter_description = chapter_description;
            this.progress_percentage = progress_percentage;
        }

        // Methods
        public static ArrayList Get_Student_Details(int student_id, string student_name)
        {
            ArrayList student_details = new ArrayList();

            string query_cmd = "SELECT Id, studentName, Email, PhoneNumber FROM students WHERE Id = @Student_Id OR studentName = @Student_Name";

            SqlCommand cmd = new SqlCommand(query_cmd, con);
            cmd.Parameters.AddWithValue("@Student_Id", student_id);
            cmd.Parameters.AddWithValue("@Student_Name", student_name);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                student_details.Add(new View_Student_Profile(
                    rd["studentName"].ToString(),
                    Convert.ToInt32(rd["Id"]),
                    rd["Email"].ToString(),
                    rd["PhoneNumber"].ToString(),
                    "", "", "", "", "", 0.0
                ));
            }

            rd.Close();
            con.Close();

            return student_details;
        }

        public static ArrayList Get_Student_Course_Progress(int student_id)
        {
            ArrayList course_progress = new ArrayList();
            string query_cmd = @"SELECT c.courseId, c.courseName, ch.chapterId, ch.chapterOrder, ch.chapterDescription, sp.progressPercentage
                                 FROM StudentProgress sp
                                 JOIN chapters ch ON sp.chapterId = ch.chapterId
                                 JOIN courses c ON ch.courseId = c.courseId
                                 WHERE sp.studentId = @Student_Id";
            SqlCommand cmd = new SqlCommand(query_cmd, con);
            cmd.Parameters.AddWithValue("@Student_Id", student_id);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                course_progress.Add(new View_Student_Profile(
                    "", student_id, "", "",
                    rd["courseId"].ToString(),
                    rd["courseName"].ToString(),
                    rd["chapterId"].ToString(),
                    rd["chapterOrder"].ToString(),
                    rd["chapterDescription"].ToString(),
                    Convert.ToDouble(rd["progressPercentage"])
                ));
            }
            rd.Close();
            con.Close();
            return course_progress;
        }
    }
}