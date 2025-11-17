using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.Login;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.UniSupervisor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Admin
{
    [Table("Administrators")]
    internal class Administrator
    {
        [Key]
        [Column("AdminId")]
        public int AdminId { get; private set; }
        [Required]
        [Column("UserId")]
        [ForeignKey("id")]
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
        [Required]
        [StringLength(100)]
        [Column("FullName")]
        public string FullName { get; private set; }
        [StringLength(100)]
        [Column("Department")]
        public string Department { get; private set; }
        [StringLength(20)]
        [Column("Phone")]
        public string Phone { get; private set; }
        [StringLength(20)]
        [Column("AccessLevel")]
        public string AccessLevel { get; private set; }

        // Constructor 1: Default
        public Administrator()
        {
        }

        // Constructor 2
        public Administrator(int UserId)
        {
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
                        "SELECT AdminId, FullName, Department, Phone, AccessLevel FROM dbo.Administrators WHERE UserId = @UserId;",
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
                        "UPDATE dbo.Administrators SET FullName = @FullName, Department = @Department, Phone = @Phone" +
                        "WHERE UserId = @UserId;",
                        con);

                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Dept", department);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@UserId", UserId);

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
                        "(SELECT COUNT(*) FROM dbo.users) AS TotalUsers, " +
                        "(SELECT COUNT(*) FROM dbo.Students) AS TotalStudents, " +
                        "(SELECT COUNT(*) FROM dbo.CompanyProfile) AS TotalCompanies, " +
                        "(SELECT COUNT(*) FROM dbo.Recruiters) AS TotalRecruiters, " +
                        "(SELECT COUNT(*) FROM dbo.StudentApplication WHERE Status = 'Pending') AS PendingApplications;",
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

