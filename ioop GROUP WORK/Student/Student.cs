using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;

namespace ioop_GROUP_WORK
{
    [Table("students")]
    internal class StudentV2
    {
        [Key]
        [Column("studentID")]
        [StringLength(50)]
        public string StudentID { get; private set; }

        [Required]
        [StringLength(50)]
        [Column("studentName")]
        public string StudentName { get; private set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; private set; }

        [Required]
        [StringLength(20)]
        [Column("phoneNumber")]
        public string PhoneNumber { get; private set; }

        [Required]
        [StringLength(100)]
        [Column("course")]
        public string Course { get; private set; }

        [Required]
        [StringLength(100)]
        [Column("password")]
        public string Password { get; private set; }
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
        public StudentV2()
        {
            name = "";
            id = "";
            email = "";
            phoneno = "";
            course = "";
            password = "";
        }
        public StudentV2(string stuName, string stuId, string stuEmail, string stuPhoneno, string stuCourse, string stuPassword)
        {
            name = stuName ?? "";
            id = stuId ?? "";
            email = stuEmail ?? "";
            phoneno = stuPhoneno ?? "";
            course = stuCourse ?? "";
            password = stuPassword ?? "";
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
                        "INSERT INTO Students(studentName, studentID, email, phoneNumber, course, password) " +
                        "VALUES(@name, @id, @em, @num, @course, @pass)", con);

                    cmd.Parameters.AddWithValue("@name", name ?? "");
                    cmd.Parameters.AddWithValue("@id", id ?? "");
                    cmd.Parameters.AddWithValue("@em", email ?? "");
                    cmd.Parameters.AddWithValue("@num", phoneno ?? "");
                    cmd.Parameters.AddWithValue("@course", course ?? "");
                    cmd.Parameters.AddWithValue("@pass", password ?? "");

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
                        if (rd[0] != DBNull.Value)
                            studentNames.Add(rd.GetString(0));
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }

            return studentNames;
        }

        // View full profile of a student
        public static void ViewProfile(StudentV2 student)
        {
            if (student == null) return;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM students WHERE studentName = @name", con);
                    cmd.Parameters.AddWithValue("@name", student.name ?? "");

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        student.id = rd["studentID"] != DBNull.Value ? rd["studentID"].ToString() : "";
                        student.email = rd["email"] != DBNull.Value ? rd["email"].ToString() : "";
                        student.phoneno = rd["phoneNumber"] != DBNull.Value ? rd["phoneNumber"].ToString() : "";
                        student.course = rd["course"] != DBNull.Value ? rd["course"].ToString() : "";
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
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

                    cmd.Parameters.AddWithValue("@em", newEmail ?? "");
                    cmd.Parameters.AddWithValue("@ph", newPhone ?? "");
                    cmd.Parameters.AddWithValue("@name", name ?? "");

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
