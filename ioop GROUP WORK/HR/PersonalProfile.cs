using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Useridentify = userIdentity ?? "";
            this.password = Password ?? "";
        }

        public string getname()
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ContactPerson FROM CompanyProfile WHERE (Email = @identity OR ContactPerson = @identity)", con);
                cmd.Parameters.AddWithValue("@identity", Useridentify ?? "");

                object value = cmd.ExecuteScalar();

                if (value != null && value != DBNull.Value)
                {
                    return value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving company name: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return null;
        }

        public string getprofilename()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Username FROM users WHERE (Email = @identity OR Username = @identity) AND password = @password", con);

                cmd.Parameters.AddWithValue("@identity", Useridentify ?? "");
                cmd.Parameters.AddWithValue("@password", password ?? "");

                object value = cmd.ExecuteScalar();

                if (value != null && value != DBNull.Value)
                {
                    return value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving profile name: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return null;
        }

        public string getemail()
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT Email FROM users WHERE (Email = @identity OR Username = @identity) AND password = @password", con);

                cmd.Parameters.AddWithValue("@identity", Useridentify ?? "");
                cmd.Parameters.AddWithValue("@password", password ?? "");

                object value = cmd.ExecuteScalar();

                if (value != null && value != DBNull.Value)
                {
                    return value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving email: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return null;
        }
        
        public string getpassword()
        {
            return password ?? "";
        }

        public string UpdatePersonalProfile(string newusername, string newpassword, string newemail)
        {
            string message = "";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users SET Username = @newusername, password = @newpassword, Email = @newemail WHERE (Username = @oldusername OR Email = @oldemail) AND password = @oldpassword ", con);

                SqlCommand cmd1 = new SqlCommand("UPDATE CompanyProfile SET ContactPerson = @newusername, Email = @newemail, password = @newpassword WHERE (ContactPerson = @oldusername OR Email = @oldemail) AND password = @oldpassword", con);

                cmd.Parameters.AddWithValue("@newusername", newusername ?? "");
                cmd.Parameters.AddWithValue("@newpassword", newpassword ?? "");
                cmd.Parameters.AddWithValue("@newemail", newemail ?? "");
                cmd.Parameters.AddWithValue("@oldusername", Useridentify ?? "");
                cmd.Parameters.AddWithValue("@oldemail", Useridentify ?? "");
                cmd.Parameters.AddWithValue("@oldpassword", password ?? "");

                cmd1.Parameters.AddWithValue("@newusername", newusername ?? "");
                cmd1.Parameters.AddWithValue("@newpassword", newpassword ?? "");
                cmd1.Parameters.AddWithValue("@newemail", newemail ?? "");
                cmd1.Parameters.AddWithValue("@oldusername", Useridentify ?? "");
                cmd1.Parameters.AddWithValue("@oldemail", Useridentify ?? "");
                cmd1.Parameters.AddWithValue("@oldpassword", password ?? "");

                int rows = cmd.ExecuteNonQuery();
                int rows1 = cmd1.ExecuteNonQuery();

                if (rows > 0 )
                {
                    this.Useridentify = newusername ?? "";
                    this.password = newpassword ?? "";
                    this.Email = newemail ?? "";

                    message = "Profile updated successfully!";
                }
                else
                {
                    message = "Update failed: username/password incorrect or no records updated.";
                }
            }
            catch (Exception ex)
            {
                message = "Error updating profile: " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return message;
        }


    }
}
