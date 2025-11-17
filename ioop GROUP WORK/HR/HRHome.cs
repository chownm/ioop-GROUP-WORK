using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.Login;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK
{
    public partial class HRHome : Form
    {
        private string UserIdentity;
        private string Password;

        public HRHome(string userIdentity, string password)
        {
             UserIdentity = userIdentity;
             Password = password;


            InitializeComponent();
        }

        public HRHome()
        {
            InitializeComponent();
        }

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        internal static User login(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, Username, Email, password, role FROM dbo.users WHERE Username=@username AND password=@password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username ?? "");
                        cmd.Parameters.AddWithValue("@password", password ?? "");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ✅ USE 5-ARG CONSTRUCTOR
                                return new User(
                                    (int)reader["id"],
                                    reader["Username"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["password"].ToString(),
                                    reader["role"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error: " + ex.Message);
            }
            return null;
        }
        private void HRHome_Load(object sender, EventArgs e)
        {

        }

        private void btnViewApplications_Click(object sender, EventArgs e)
        {
            ViewApplication vp = new ViewApplication(UserIdentity, Password);
            this.Close();
            vp.ShowDialog();
               
        }

        private void btnCompanyProfile_Click(object sender, EventArgs e)
        {
            CompanyProfile cp = new CompanyProfile(UserIdentity, Password);
            this.Close();
            cp.ShowDialog();
        }

        private void btnManageOffers_Click(object sender, EventArgs e)
        {
            ManageOffer mo = new ManageOffer(UserIdentity, Password);
            this.Close();
            mo.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonalProfile_Click(object sender, EventArgs e)
        {
            PersonalProfileForm pp = new PersonalProfileForm(UserIdentity,Password);
            this.Close();
            pp.ShowDialog();
        }
    }
}
