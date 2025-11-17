using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ChangePasswordForm : Form
    {
        string studentID;
        public ChangePasswordForm(string id)
        {
            InitializeComponent();
            studentID = id ?? "";
            lblDisUsername.Text = studentID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPass = txtOldPass?.Text?.Trim() ?? "";
                string newPass = txtNewPass?.Text?.Trim() ?? "";
                string confirm = txtNewPass2?.Text?.Trim() ?? "";

                if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(confirm))
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
                    checkCmd.Parameters.AddWithValue("@user", studentID ?? "");
                    checkCmd.Parameters.AddWithValue("@old", oldPass ?? "");
                    
                    object countObj = checkCmd.ExecuteScalar();
                    int exists = (countObj != null && int.TryParse(countObj.ToString(), out int count)) ? count : 0;

                    if (exists == 1)
                    {
                        // Update password
                        SqlCommand updateCmd = new SqlCommand("UPDATE Users SET password=@new WHERE username=@user AND role='student'", con);
                        updateCmd.Parameters.AddWithValue("@new", newPass ?? "");
                        updateCmd.Parameters.AddWithValue("@user", studentID ?? "");
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
