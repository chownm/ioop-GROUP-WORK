using System;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ioop_GROUP_WORK.Login
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // Student, CompanyHR, Recruiter, Supervisor, Administrator

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; } = true;
        //Attributes
        private string username;
        private string password;

        //Connect to database
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        //Constructor for login (2 parameters)
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        //Constructor for user creation (4 parameters: username, email, password, role)
        public User(string username, string email, string password, string role)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }

        //Constructor for user update (5 parameters: userId, username, email, password, role)
        public User(int userId, string username, string email, string password, string role)
        {
            this.UserId = userId;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Role = role;
        }

        //Methods
        public string login(string username, string password)
        {
            string role = null;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT role FROM Users WHERE username=@u AND password=@p", con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    role = rd["role"].ToString();
                }
                rd.Close();
            }


            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return role;
        }
    }
}
