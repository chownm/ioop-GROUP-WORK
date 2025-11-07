using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

namespace ioop_GROUP_WORK
{
    internal class StudentV2
    {
        //=============================
        // Attributes
        //=============================
        private string name;
        private string id;
        private string email;
        private string phoneno;
        private string course;
        private string password;

        //=============================
        // Constructor
        //=============================
        public StudentV2(string stuName, string stuId, string stuEmail, string stuPhoneno, string stuCourse, string stuPassword)
        {
            this.name = stuName;
            this.id = stuId;
            this.email = stuEmail;
            this.phoneno = stuPhoneno;
            this.course = stuCourse;
            this.password = stuPassword;
        }

        //=============================
        // Methods
        //=============================

        // Add a new student to the database
        public string AddStudent()
        {
            string status;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO students(studentName, studentID, email, phoneNumber, course, password) " +
                        "VALUES(@name, @id, @em, @num, @course, @pass)", con);

                    cmd.Parameters.AddWithValue("@name", this.name);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@em", this.email);
                    cmd.Parameters.AddWithValue("@num", this.phoneno);
                    cmd.Parameters.AddWithValue("@course", this.course);
                    cmd.Parameters.AddWithValue("@pass", this.password);

                    int result = cmd.ExecuteNonQuery();
                    status = (result > 0) ? "Student Added Successfully." : "Failed to Add Student.";
                }
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

            return status;
        }

        // View all student names
        public static ArrayList ViewAll()
        {
            ArrayList studentNames = new ArrayList();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT studentName FROM students", con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        studentNames.Add(rd.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return studentNames;
        }

        // View full profile of a student
        public static void ViewProfile(StudentV2 student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE studentName = @name", con);
                    cmd.Parameters.AddWithValue("@name", student.name);

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        student.id = rd["studentID"].ToString();
                        student.email = rd["email"].ToString();
                        student.phoneno = rd["phoneNumber"].ToString();
                        student.course = rd["course"].ToString();
                        student.password = rd["password"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Update email and phone number
        public string UpdateProfile(string newEmail, string newPhone)
        {
            string status;
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE students SET email = @em, phoneNumber = @ph WHERE studentName = @name", con);

                    cmd.Parameters.AddWithValue("@em", newEmail);
                    cmd.Parameters.AddWithValue("@ph", newPhone);
                    cmd.Parameters.AddWithValue("@name", this.name);

                    int i = cmd.ExecuteNonQuery();
                    status = (i > 0) ? "Profile Updated Successfully." : "Unable to Update Profile.";
                }
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

            return status;
        }
    }
}
