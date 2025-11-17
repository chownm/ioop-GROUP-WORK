using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class ChangePassword
    {
        private string studentID;

        public ChangePassword(string id)
        {
            studentID = id ?? "";
        }

        public string ChangePasswordProcess(string oldPass, string newPass, string confirmPass)
        {
            try
            {
                if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(confirmPass))
                {
                    return "All fields are required.";
                }

                if (newPass != confirmPass)
                {
                    return "New password does not match.";
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

                        return "Password changed successfully!";
                    }
                    else
                    {
                        return "Incorrect old password.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
