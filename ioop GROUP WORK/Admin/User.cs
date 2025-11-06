
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;


namespace ioop_GROUP_WORK
{
    internal class User
    {
        private string username = " ";
        private string password = " ";


        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string login(string un, string pw)
        {
            string status = null;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ToString());

            con.Open();

            SqlCommand cmd2 = new SqlCommand("select role from users where username =@a and password =@b", con);
            cmd2.Parameters.AddWithValue("@a", un);
            cmd2.Parameters.AddWithValue("@b", pw);

            object result = cmd2.ExecuteScalar();
            if (result != null)
            {
                string userRole = result.ToString();
           
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
                else if (userRole == "HR")
                {
                     HRHome h = new HRHome();
                     h.ShowDialog();
                }
                else if (userRole == "Unisupervisor")
                {
                    UniSupervisorHome US = new UniSupervisorHome();
                    US.ShowDialog();
                }
                
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
