using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ioop_GROUP_WORK.UniSupervisor;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class View_Student_Profile
    {
        // Attributes (Student Details)

        private string student_id;
        private string student_name;
        private string email;
        private string phone_number;
        private string course;

        // Constructors
        public View_Student_Profile(string student_id, string student_name, string email, string phone_number, string course)
        {
            this.student_id = student_id;
            this.student_name = student_name;
            this.email = email;
            this.phone_number = phone_number;
            this.course = course;

        }

        public View_Student_Profile(string student_id, string student_name)      // This constructor is used for GetStudentIDAndName()
        {
            this.student_id = student_id;
            this.student_name = student_name;
        }

        public string Student_id { get => student_id; set => student_id = value; }
        public string Student_name { get => student_name; set => student_name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Course { get => course; set => course = value; }


        // Methods

        public static List<View_Student_Profile> GetAllStudent()        // used for displaying all student profiles
        {
           
            List<View_Student_Profile> students = new List<View_Student_Profile>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query_cmd = "SELECT studentID, studentName, email, phoneNumber, course FROM Students";
                SqlCommand cmd = new SqlCommand(query_cmd, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string student_id = reader["studentID"].ToString();
                    string student_name = reader["studentName"].ToString();
                    string email = reader["email"].ToString();
                    string phone_number = reader["phoneNumber"].ToString();
                    string course = reader["course"].ToString();
                    View_Student_Profile student = new View_Student_Profile(student_id, student_name, email, phone_number, course);
                    students.Add(student);
                }
            }
            return students;
        }

        public static List<View_Student_Profile> GetStudentIDAndName()      // used for choosing the student from list box
        { 
            List<View_Student_Profile> student_info = new List<View_Student_Profile>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query_cmd = "SELECT studentID, studentName FROM Students";
                SqlCommand cmd = new SqlCommand(query_cmd, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string student_id = reader["studentID"].ToString();
                    string student_name = reader["studentName"].ToString();
                    View_Student_Profile student = new View_Student_Profile(student_id, student_name);
                    student_info.Add(student);
                }
            }
            return student_info;
        }

        public string DisplayStudentInfo()      // used for displaying student ID and name in list box
        {
            return $"Student ID: {student_id} | Student Name: {student_name}";
        }
    }
}