using ioop_GROUP_WORK.Student;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Login
{
    public class User
    {
        private string Useridentify;
        private string password;
        public User(string useridentify , string password)
        {
            this.Useridentify = useridentify;
            this.password = password;   
           
           
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
                cmd.Parameters.AddWithValue("@u", this.Useridentify);
                cmd.Parameters.AddWithValue("@e", this.Useridentify);
                cmd.Parameters.AddWithValue("@p", this.password);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    identifyrole = rd["Role"].ToString();
                }
                rd.Close();

                //FOR STUDENT PART (DO NOT DELETE)
                //Fetch student name if the role is student
                if (identifyrole == "student")
                {
                    SqlCommand studentCmd = new SqlCommand("SELECT StudentName FROM Students WHERE StudentID=@StudentID", con);
                    studentCmd.Parameters.AddWithValue("@StudentID", this.Useridentify);

                    SqlDataReader studentReader = studentCmd.ExecuteReader();
                    if (studentReader.Read())
                    {
                        studentName = studentReader["StudentName"].ToString(); 
                    }
                    studentReader.Close();
                }
                con.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show("Login Failed, Please Contact The Adminstrator.Thank you");
            }
            return (identifyrole, studentName);
                      
        }
        public string identify(string role, string studentName)
        {
            string message = $"Login Successful, Welcome To The {role} HomePage !";

            if (role == "Admin")
            {
                AdminHome a = new AdminHome();
                a.ShowDialog();

            }
            else if (role == "HR")
            {
                HRHome HR = new HRHome();
                HR.ShowDialog();

            }
            else if (role == "UniSupervisor")
            {
                //  UniSupervisorHome UniSuperHome = new UniSupervisorHome();
                // UniSuperHome.ShowDialog();
            }
            else if (role == "Student")
            {
                StudentHomeForm student = new StudentHomeForm(Useridentify, studentName);
                student.ShowDialog();
            }
            else
            {
                return("Incorrect username or password!");
            }
            return message;


        }
    }
}
