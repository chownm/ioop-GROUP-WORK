using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.UniSupervisor;
using ioop_GROUP_WORK.Login;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ioop_GROUP_WORK.Login
{
    [Table("users")]
    internal class User
    {
        private string _userIdentify;
        private string _password;

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        [Column("password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [Required]
        [StringLength(50)]
        [Column("role")]
        public string Role { get; set; }

        [NotMapped]
        public string UserIdentify
        {
            get { return _userIdentify; }
            set { _userIdentify = value; }
        }

        public User() { }

        public User(string userIdentify, string password)
        {
            this.UserIdentify = userIdentify ?? "";
            this.Password = password ?? "";

            if (IsEmail(userIdentify))
            {
                this.Email = userIdentify;
            }
            else
            {
                this.Username = userIdentify;
            }
        }

        // ✅ ADD 4-ARG CONSTRUCTOR
        public User(string username, string email, string password, string role)
        {
            this.Username = username ?? "";
            this.Email = email ?? "";
            this.Password = password ?? "";
            this.Role = role ?? "";
        }

        // ✅ ADD 5-ARG CONSTRUCTOR (Full constructor with ID)
        public User(int id, string username, string email, string password, string role)
        {
            this.Id = id;
            this.Username = username ?? "";
            this.Email = email ?? "";
            this.Password = password ?? "";
            this.Role = role ?? "";
        }

        private bool IsEmail(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            return input.Contains("@") && input.Contains(".");
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);
        
        //Methods
        //FOR STUDENT PART (DO NOT DELETE)
        public (string role, string studentName) login()
        {
            string identifyrole = "";
            string studentName = null;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Role FROM Users WHERE (Username=@u OR Email = @e) AND Password=@p", con);
                cmd.Parameters.AddWithValue("@u", UserIdentify ?? "");
                cmd.Parameters.AddWithValue("@e", UserIdentify ?? "");
                cmd.Parameters.AddWithValue("@p", Password ?? "");

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (rd["Role"] != DBNull.Value)
                        identifyrole = rd["Role"].ToString();
                }
                rd.Close();

                //FOR STUDENT PART (DO NOT DELETE)
                //Fetch student name if the role is student
                if (!string.IsNullOrEmpty(identifyrole) && identifyrole.ToLower() == "student")
                {
                    StudentV2 student = new StudentV2();
                    if (!string.IsNullOrEmpty(student.StudentID))
                    {
                        SqlCommand studentCmd = new SqlCommand("SELECT StudentName FROM Students WHERE StudentID=@studentID", con);
                        studentCmd.Parameters.AddWithValue("@studentID", student.StudentID ?? "");

                        SqlDataReader studentReader = studentCmd.ExecuteReader();
                        if (studentReader.Read())
                        {
                            if (studentReader["studentName"] != DBNull.Value)
                                studentName = studentReader["studentName"].ToString();
                        }
                        studentReader.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed, Please Contact The Administrator. Thank you. Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return (identifyrole, studentName);
        }

        public string identify(string role, string studentName)
        {
            string message = $"Login Successful, Welcome To The {role ?? "Unknown"} HomePage!";

            try
            {
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Incorrect username or password!");
                    return message;
                }

                switch (role.ToLower())
                {
                    case "admin":
                        AdminHome a = new AdminHome();
                        a.ShowDialog();
                        break;

                    case "hr":
                        HRHome HR = new HRHome(UserIdentify ?? "", Password ?? "");
                        HR.ShowDialog();
                        break;

                    case "supervisor":
                        frm_UniSupervisorHome UniSuperHome = new frm_UniSupervisorHome();
                        UniSuperHome.ShowDialog();
                        break;

                    case "student":
                        StudentHomeForm student = new StudentHomeForm(UserIdentify ?? "", studentName ?? "");
                        student.ShowDialog();
                        break;

                    default:
                        MessageBox.Show("Incorrect username or password!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to home: " + ex.Message);
            }

            return message;
        }
    }
}
