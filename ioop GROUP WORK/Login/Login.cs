using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ioop_GROUP_WORK.Login
{
    internal class User
    {
        //Attributes
        private string username;
        private string password;

        //Connect to database
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        //Constructor
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
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
