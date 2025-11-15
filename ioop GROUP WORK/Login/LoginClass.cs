using ioop_GROUP_WORK.Student;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
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
        public string login()
        {
            string identifyrole = "";

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
                con.Close();

                
            }


            catch (Exception ex)
            {
                MessageBox.Show("Login Failed, Please Contact The Adminstrator.Thank you");
            }
            return identifyrole;
                      
        }
        public string identify(string role)
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
                StudentHomeForm student = new StudentHomeForm();
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
