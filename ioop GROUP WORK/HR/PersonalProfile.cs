using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Configuration;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.HR
{
    internal class PersonalProfile
    {
        public string Useridentify { get; private set; }
        public string password { get; private set; }
        public string Email { get; private set; }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public PersonalProfile(string userIdentity, string Password) 
        { 
            this.Useridentify = userIdentity;
            this.password = Password;
            
        }
        public PersonalProfile()
        {

        }


        public string getname()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT ContactPerson FROM CompanyProfile WHERE (Email = @identity OR ContactPerson = @identity) AND Password = @password", con);

            cmd.Parameters.AddWithValue("@identity", this.Useridentify);
            cmd.Parameters.AddWithValue("@password", this.password);

            object value = cmd.ExecuteScalar();
            con.Close();

            if (value != null)
            {
                string result = value.ToString();

                return result;
            }
            else
            {
                return null;
            }
            
        }

        public string getprofilename()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Email FROM \\\\ WHERE (Email = @identity OR Username = @identity) AND Password = @password", con);

            cmd.Parameters.AddWithValue("@identity", this.Useridentify);
            cmd.Parameters.AddWithValue("@password", this.password);

            object value = cmd.ExecuteScalar();
            con.Close();

            if (value != null)
            {
                string result = value.ToString();

                return result;
            }
            else
            {
                return null;
            }
        }

        public string getemail()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Email FROM \\\\ WHERE (Email = @identity OR \\\\ Username = @identity) AND Password = @password", con);

            cmd.Parameters.AddWithValue("@identity", this.Useridentify);
            cmd.Parameters.AddWithValue("@password", this.password);

            object value = cmd.ExecuteScalar();
            con.Close();

            if (value != null)
            {
                string result = value.ToString();

                return result;
            }
            else
            {
                return null;
            }
        }
        
        public string getpassword()
        {
            return this.password; 
        }

        public string UpdatePersonalProfile(string newusername, string newpassword, string newemail)
        {
            string message = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE \\\\ SET \\\\Username = @newusername, Password = @newpassword, Email = @newemail WHERE (Username = @oldusername OR Email = @oldemail) AND Password = @oldpassword ", con);

            SqlCommand cmd1 = new SqlCommand("UPDATE CompanyProfile SET ContactPerson = @newusername, Password = @newpassword, Email = @newemail WHERE (ContactPerson = @oldusername OR Email = @oldemail) AND Password = @oldpassword ", con);

            cmd.Parameters.AddWithValue("@newusername", newusername);
            cmd.Parameters.AddWithValue("@password", newpassword);
            cmd.Parameters.AddWithValue("@newemail", newemail);
            cmd.Parameters.AddWithValue("@oldusername", this.Useridentify);
            cmd.Parameters.AddWithValue("@oldemail", this.Useridentify);
            cmd.Parameters.AddWithValue("@oldpassword", this.password);

            cmd1.Parameters.AddWithValue("@newusername", newusername);
            cmd1.Parameters.AddWithValue("@password", newpassword);
            cmd1.Parameters.AddWithValue("@newemail", newemail);
            cmd1.Parameters.AddWithValue("@oldusername", this.Useridentify);
            cmd1.Parameters.AddWithValue("@oldemail", this.Useridentify);
            cmd1.Parameters.AddWithValue("@oldpassword", this.password);

            int rows = cmd.ExecuteNonQuery();
            int rows1 = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                this.Useridentify = newusername;
                this.password = newpassword;
                this.Email = newemail;

                message = "Profile updated successfully!";
            }
            else
            {
                message = "Update failed: username/password incorrect.";
            }

            con.Close();
            return message;
        }
    }

            
}
