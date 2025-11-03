using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ioop_GROUP_WORK
{
    internal class User
    {
        private string username = " ";
        private string password = " ";
        public string login(string un)
        {
            string status = null;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ToString());

            con.Open();

            SqlCommand cmd2 = new SqlCommand("select count(*) from users where username =@a and password =@b", con);
            cmd2.Parameters.AddWithValue("@a", username);
            cmd2.Parameters.AddWithValue("@b", password);

            string userRole = cmd2.ExecuteScalar().ToString();

            if (userRole == "admin")
            {
                AdminHome a = new AdminHome(un);
                a.ShowDialog();
            }
            else if (userRole == "student")
            {
                StudentHome s = new StudentHome(un);
                s.ShowDialog();
            }
            else
            {
                status = "Incorrect username/password";

            }
            con.Close();

            return status;
            //status = null if login success
            //status = "Incorrect username/password" if login fail.
        }




    }
}
