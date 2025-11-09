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
        // Attributes (Student Details)
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }

        // Attributes (Course Progress)
        public string ChapterID { get; set; }
        public string ChapterOrder { get; set; }
        public string ChapterDescription { get; set; }
        public double ProgressPercentage { get; set; }

        // Constructors
        public View_Student_Profile(string studentID, string studentName , string email, string phoneNumber,
                                    string courseID, string courseName, string chapterID,
                                    string chapterOrder, string chapterDescription , double progressPercentage)
        {
            StudentID = studentID;
            StudentName = studentName;
            Email = email;
            PhoneNumber = phoneNumber;
            CourseID = courseID;
            CourseName = courseName;
            ChapterID = chapterID;
            ChapterOrder = chapterOrder;
            ChapterDescription = chapterDescription;
            ProgressPercentage = progressPercentage;
        }

        public View_Student_Profile(string studentID, string courseID, string courseName, string chapterID, string chapterOrder, string chapterDescription, double progressPercentage)
        {
            StudentID = studentID;
            CourseID = courseID;
            CourseName = courseName;
            ChapterID = chapterID;
            ChapterOrder = chapterOrder;
            ChapterDescription = chapterDescription;
            ProgressPercentage = progressPercentage;
        }



        // Methods
        public static List<View_Student_Profile> GetAllStudents()
        {
            List<View_Student_Profile> students = new List<View_Student_Profile>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query = "SELECT studentID, studentName, email, phoneNumber, course FROM Students";
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        students.Add(new View_Student_Profile(
                            studentID: rd["studentID"].ToString(),
                            studentName: rd["studentName"].ToString(),
                            email: rd["email"].ToString(),
                            phoneNumber: rd["phoneNumber"].ToString(),
                            courseID: null,
                            courseName: rd["course"].ToString(),
                            chapterID: null,
                            chapterOrder: null,
                            chapterDescription: null,
                            progressPercentage: 0.0
                        ));
                    }
                }
            }

            return students;
        }

        // Get student details by ID
        public static View_Student_Profile GetStudentByID(string studentID)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query = "SELECT studentID, studentName, email, phoneNumber, course FROM Students WHERE studentID = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", studentID);
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return new View_Student_Profile(
                                studentID: rd["studentID"].ToString(),
                                studentName: rd["studentName"].ToString(),
                                email: rd["email"].ToString(),
                                phoneNumber: rd["phoneNumber"].ToString(),
                                courseID: null,
                                courseName: rd["course"].ToString(),
                                chapterID: null,
                                chapterOrder: null,
                                chapterDescription: null,
                                progressPercentage: 0.0
                            );
                        }
                    }
                }
            }

            return null;
        }

        // Get student course progress by student ID
        public static List<View_Student_Profile> GetStudentCourseProgress(string studentID)
        {
            List<View_Student_Profile> progressList = new List<View_Student_Profile>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query = @"
                    SELECT 
                        c.Course_Id, 
                        c.Subject_Name, 
                        ch.Chapter_Id, 
                        ch.Chapter_Order, 
                        ch.Description, 
                        sp.Progress_Percentage
                    FROM Student_Progress sp
                    JOIN Chapters ch ON sp.Chapter_Id = ch.Chapter_Id
                    JOIN Courses c ON ch.Course_Id = c.Course_Id
                    WHERE sp.Student_Id = @Student_Id
                ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Student_Id", studentID);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            progressList.Add(new View_Student_Profile(
                                studentID: studentID,
                                courseID: rd["Course_Id"].ToString(),
                                courseName: rd["Subject_Name"].ToString(),
                                chapterID: rd["Chapter_Id"].ToString(),
                                chapterOrder: rd["Chapter_Order"].ToString(),
                                chapterDescription: rd["Description"].ToString(),
                                progressPercentage: Convert.ToDouble(rd["Progress_Percentage"])
                            ));
                        }
                    }
                }
            }

            return progressList;
        }
    }
}