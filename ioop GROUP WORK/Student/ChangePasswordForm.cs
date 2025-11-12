using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public partial class ChangePasswordForm : Form
    {
        string studentID;
        public ChangePasswordForm(string id)
        {
            InitializeComponent();
            studentID = id;
            lblDisUsername.Text = id;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string confirm = txtNewPass2.Text.Trim();

            if (newPass == "" || oldPass == "" || confirm == "")
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("New password does not match.");
                return;
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();

                // Verify old password
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE username=@user AND password=@old AND role='student'", con);
                checkCmd.Parameters.AddWithValue("@user", studentID);
                checkCmd.Parameters.AddWithValue("@old", oldPass);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists == 1)
                {
                    // Update password
                    SqlCommand updateCmd = new SqlCommand("UPDATE Users SET password=@new WHERE username=@user AND role='student'", con);
                    updateCmd.Parameters.AddWithValue("@new", newPass);
                    updateCmd.Parameters.AddWithValue("@user", studentID);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Password changed successfully!");
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Incorrect old password.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
