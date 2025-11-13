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



        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

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

        public CP(int companyId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM  WHERE CompanyProfile WHERE CompanyID=@id", con);
            cmd.Parameters.AddWithValue("@id", companyId);


            SqlDataReader reader = cmd.ExecuteReader();
            
                if (reader.Read())
                {
                    this.Companyname = reader["CompanyName"].ToString();
                    this.Contactperson = reader["ContactPerson"].ToString();
                    this.Email = reader["Email"].ToString();
                    this.Contactnumber = reader["Contactn"].ToString();
                    this.Address = reader["Address"].ToString();
                    this.Companydescription = reader["Company Description"].ToString();
                    this.CompanyLogo = reader["CompanyLogo"] as byte[];
                }
                reader.Close();
                con.Close();
        }
    


        public string SaveInfo()
        {
            string message = "";
            con.Open();

            SqlCommand cmd = new SqlCommand(
                "UPDATE CompanyProfile SET CompanyName = @companyn, ContactPerson = @contactp, Email = @e, Contactn = @cn, Address = @a, CompanyDescription = @Companyd, CompanyLogo = @logo WHERE Id = @id", con);

            cmd.Parameters.AddWithValue("@companyn", this.Companyname);
            cmd.Parameters.AddWithValue("@contactp", this.Contactperson);
            cmd.Parameters.AddWithValue("@e", this.Email);
            cmd.Parameters.AddWithValue("@cn", this.Contactnumber);
            cmd.Parameters.AddWithValue("a", this.Address);
            cmd.Parameters.AddWithValue("@Companyd", this.Companydescription);
            cmd.Parameters.AddWithValue("@logo", this.CompanyLogo);
            cmd.Parameters.AddWithValue("@id", 1);

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
