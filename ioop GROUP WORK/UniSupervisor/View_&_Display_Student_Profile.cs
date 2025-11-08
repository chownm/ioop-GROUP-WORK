using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class View_Student_Profile
    {
        // Attributes
        public string student_name;
        public string student_id;
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
        public View_Student_Profile(string student_name, string student_id, string email, string phone_number,
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

        // Get student basic info
        public static ArrayList Get_Student_Details(string student_id, string student_name, string email, string phone_number)
        {
            ArrayList student_details = new ArrayList();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString)) ;
            { 
                con.Open();
                string query_cmd = "SELECT Id, studentName, Email, PhoneNumber FROM students";
                SqlCommand cmd = new SqlCommand(query_cmd, con);
          
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string student_parameters = $"Student Id: {rd["Id"]} | Student Name: {rd["studentName"]} | Email: {rd["Email"]} | Contact Number: {rd["Phone_Number"]}";
                    student_details.Add(student_parameters);
                }

                rd.Close();
                con.Close();

                return student_details;
            }
           
        }

        // Get student's course progress
        public static ArrayList Get_Student_Course_Progress(int student_id)
        {
            ArrayList course_progress = new ArrayList();

            string query_cmd = @"SELECT 
                                    c.Course_Id, 
                                    c.Subject_Name, 
                                    ch.Chapter_Id, 
                                    ch.Chapter_Order, 
                                    ch.Description, 
                                    sp.Progress_Percentage
                                 FROM Student_Progress sp
                                 JOIN Chapters ch ON sp.Chapter_Id = ch.Chapter_Id
                                 JOIN Courses c ON ch.Course_Id = c.Course_Id
                                 WHERE sp.Student_Id = @Student_Id";

            SqlCommand cmd = new SqlCommand(query_cmd, con);
            cmd.Parameters.AddWithValue("@Student_Id", student_id);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                course_progress.Add(new View_Student_Profile(
                    "", student_id, "", "",
                    rd["Course_Id"].ToString(),
                    rd["Subject_Name"].ToString(),
                    rd["Chapter_Id"].ToString(),
                    rd["Chapter_Order"].ToString(),
                    rd["Description"].ToString(),
                    Convert.ToDouble(rd["Progress_Percentage"])
                ));
            }

            rd.Close();
            con.Close();

            return course_progress;
        }

        // Display functions
        public string Display_Student_Details()
        {
            return $"Student Name: {student_name}\n" +
                   $"Student ID: {student_id}\n" +
                   $"Email: {email}\n" +
                   $"Phone Number: {phone_number}\n";
        }

        public string Display_Course_Progress()
        {
            return $"Course ID: {course_id}\n" +
                   $"Course Name: {course_name}\n" +
                   $"Chapter ID: {chapter_id}\n" +
                   $"Chapter Order: {chapter_order}\n" +
                   $"Chapter Description: {chapter_description}\n" +
                   $"Progress Percentage: {progress_percentage}%\n";
        }
    }
}
