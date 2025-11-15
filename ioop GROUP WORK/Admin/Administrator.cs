using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.UniSupervisor;
using ioop_GROUP_WORK.Login;

namespace ioop_GROUP_WORK.Admin
{
    public class Administrator
    {
        public int AdminId { get; private set; }
        public int UserId
        {
            get
            {
                return UserId;
            }
            private set
            {
                UserId = value;
            }
        }
        public string FullName { get; private set; }
        public string Department { get; private set; }
        public string Phone { get; private set; }
        public string AccessLevel { get; private set; }

        // Constructor 1: Default
        public Administrator() : base()
        {
            AdminId = 0;
            UserId = 0;
            FullName = string.Empty;
            Department = string.Empty;
            Phone = string.Empty;
            AccessLevel = "Standard";
        }

        // Constructor 2
        public Administrator(int UserId)
        {
            AdminId = 0;
            FullName = string.Empty;
            Department = string.Empty;
            Phone = string.Empty;
            AccessLevel = "Standard";
        }

        // Constructor 3: Full initialization
        public Administrator(int userId, int adminId, string fullName,
            string department, string phone, string accessLevel)
        {
            UserId = userId;
            AdminId = adminId;
            FullName = fullName;
            Department = department;
            Phone = phone;
            AccessLevel = accessLevel;
        }

        // Load admin profile from database
        public bool LoadProfile()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT AdminId, FullName, Department, Phone, AccessLevel FROM dbo.Administrators WHERE UserId = @userId",
                        con);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        AdminId = Convert.ToInt32(reader["AdminId"]);
                        FullName = reader["FullName"].ToString();
                        Department = reader["Department"].ToString();
                        Phone = reader["Phone"].ToString();
                        AccessLevel = reader["AccessLevel"].ToString();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Update admin profile
        public string UpdateProfile(string fullName, string department, string phone)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE dbo.Administrators SET FullName = @fullName, Department = @dept, Phone = @phone " +
                        "WHERE UserId = @userId",
                        con);

                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0 ? "Profile Updated Successfully" : "Update Failed";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        // Get admin statistics
        public DataTable GetStatistics()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) AS TotalUsers, " +
                        "(SELECT COUNT(*) FROM dbo.Students) AS TotalStudents, " +
                        "(SELECT COUNT(*) FROM dbo.Companies) AS TotalCompanies, " +
                        "(SELECT COUNT(*) FROM dbo.Recruiters) AS TotalRecruiters, " +
                        "(SELECT COUNT(*) FROM dbo.Applications WHERE Status = 'Pending') AS PendingApplications " +
                        "FROM dbo.Users",
                        con);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error fetching statistics: " + ex.Message);
            }
            return dt;
        }
    }
}

