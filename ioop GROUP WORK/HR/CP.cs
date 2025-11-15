using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Windows.Controls;

namespace ioop_GROUP_WORK.HR
{
    internal class CP
    {
        private string companyname;
        private string contactperson;
        private string email;
        private string contactnumber;
        private string address;
        private string companydescription;
        private byte[] companyLogo;



         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public string Companyname { get => companyname; private set => companyname = value; }
        public string Contactperson { get => contactperson; private set => contactperson = value; }
        public string Email { get => email; private set => email = value; }
        public string Contactnumber { get => contactnumber; private set => contactnumber = value; }
        public string Address { get => address; private set => address = value; }
        public string Companydescription { get => companydescription; private set => companydescription = value; }
        public byte[] CompanyLogo { get => companyLogo;private set => companyLogo = value; }

        public CP(string companyname, string contactperson, string email, string contactnumber, string address, string companydescription, byte[] companyLogo)
        {
            this.Companyname = companyname;
            this.Contactperson = contactperson;
            this.Email = email;
            this.Contactnumber = contactnumber;
            this.Address = address;
            this.Companydescription = companydescription;
            this.CompanyLogo = companyLogo;

        }

        public CP(string name, string password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CompanyProfile WHERE ContactPerson = @Contactp AND Password = password ", con);
            cmd.Parameters.AddWithValue("@Contactp", name);
            cmd.Parameters.AddWithValue("@password", password);
            
            SqlDataReader reader = cmd.ExecuteReader();
            
                if (reader.Read())
                {
                    this.Companyname = reader["CompanyName"].ToString();
                    this.Contactperson = reader["ContactPerson"].ToString();
                    this.Email = reader["Email"].ToString();
                    this.Contactnumber = reader["ContactNumber"].ToString();
                    this.Address = reader["Address"].ToString();
                    this.Companydescription = reader["CompanyDescription"].ToString();
                    this.CompanyLogo = reader["CompanyLogo"] as byte[];
                }
                reader.Close();
                con.Close();
        }
    


        public string SaveInfo(string name, string password)
        {
            string message = "";
            con.Open();

            SqlCommand checkCmd = new SqlCommand(
            "SELECT COUNT(*) FROM CompanyProfile WHERE ContactPerson = @contactp AND Password = @passw",con);
            checkCmd.Parameters.AddWithValue("@contactp", name);
            checkCmd.Parameters.AddWithValue("@passw", password);

            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                
                SqlCommand insertCmd = new SqlCommand(
                "INSERT INTO CompanyProfile (CompanyName, ContactPerson, Email, Contactn, Address, CompanyDescription, CompanyLogo, Password) " +
                "VALUES (@companyn, @contactp, @e, @cn, @a, @Companyd, @logo, @passw)", con);

                insertCmd.Parameters.AddWithValue("@companyn", this.Companyname);
                insertCmd.Parameters.AddWithValue("@contactp", this.contactperson);
                insertCmd.Parameters.AddWithValue("@e", this.Email);
                insertCmd.Parameters.AddWithValue("@cn", this.Contactnumber);
                insertCmd.Parameters.AddWithValue("@a", this.Address);
                insertCmd.Parameters.AddWithValue("@Companyd", this.Companydescription);
                insertCmd.Parameters.AddWithValue("@logo", this.CompanyLogo);
                insertCmd.Parameters.AddWithValue("@passw", password);

                int rows = insertCmd.ExecuteNonQuery();
                con.Close();

                if (rows > 0)
                    message = "Company profile created successfully!";
                else
                    message = "Insert failed.";

                return message;
            }

            else
            {

                SqlCommand cmd = new SqlCommand(
            "UPDATE CompanyProfile SET CompanyName = @companyn, ContactPerson = @contactp, Email = @e, Contactn = @cn, Address = @a, CompanyDescription = @Companyd, CompanyLogo = @logo WHERE ContactPerson = @checkperson AND Password = @passw ", con);

                cmd.Parameters.AddWithValue("@companyn", this.Companyname);
                cmd.Parameters.AddWithValue("@contactp", this.contactperson);
                cmd.Parameters.AddWithValue("@e", this.Email);
                cmd.Parameters.AddWithValue("@cn", this.Contactnumber);
                cmd.Parameters.AddWithValue("a", this.Address);
                cmd.Parameters.AddWithValue("@Companyd", this.Companydescription);
                cmd.Parameters.AddWithValue("@logo", this.CompanyLogo);
                cmd.Parameters.AddWithValue("@checkperson", name);
                cmd.Parameters.AddWithValue("@passw", password);

                int rows = cmd.ExecuteNonQuery();
                con.Close();


                if (rows > 0)
                {
                    message = "Company profile saved successfully!";
                }
                else
                {
                    message = "Save failed.";
                }
                return message;
            }
        }


       
    }
}
