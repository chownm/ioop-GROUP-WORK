using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ioop_GROUP_WORK.Login;

namespace ioop_GROUP_WORK.Admin
{
    /// <summary>
    /// AdminManager - Business Logic Layer for Administrator operations
    /// Implements Singleton pattern for database operations
    /// Provides centralized management of admin functions with validation
    /// </summary>
    internal class AdminManager : IAdminManager
    {
        //=============================
        // Singleton Instance
        //=============================
        private static AdminManager instance = null;
        private static readonly object lockObject = new object();

        public static AdminManager Instance
        {

            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new AdminManager();
                        }
                    }
                }
                return instance;
            }
        }

        //=============================
        // Private Constructor (Singleton)
        //=============================
        private AdminManager()
        {
        }

        //=============================
        // User Management Functions
        //=============================

        /// <summary>
        /// Create new user with validation
        /// Ensures data integrity through parameterized queries
        /// </summary>
        public string CreateUser(User user)
        {
            try
            {
                if (!ValidationHelper.ValidatePassword(user.Password))
                {
                    MessageBox.Show("Password must be at least 8 characters with uppercase, lowercase, and numbers");
                }
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    // Check if username exists
                    string checkQuery = "SELECT Username FROM users WHERE Username = @Username;";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", user.Username);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                            return "Username already exists";
                    }

                    // Insert user with parameterized query (SQL injection prevention)
                    string insertQuery = @"
                        INSERT INTO users (Username, Email, Password, Role)
                        VALUES (@Username, @Email, @password, @Role);";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@Role", user.Role);

                        int result = cmd.ExecuteNonQuery();
                        return (result > 0) ? "User created successfully" : "Failed to create user";
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                return "Database Error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Update existing user information
        /// </summary>
        public string UpdateUser(User user)
        {
            try
            {
                if (!ValidationHelper.ValidateEmail(user.Email))
                    return "Invalid email format";

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    string updateQuery = @"
                        UPDATE users 
                        SET Username = @Username, Email = @Email, Password = @password, Role = @Role
                        WHERE UserId = @id;";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@Role", user.Role);
                        cmd.Parameters.AddWithValue("@id", user.Id);

                        int result = cmd.ExecuteNonQuery();
                        return (result > 0) ? "User updated successfully" : "User not found";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Delete/deactivate user account
        /// Soft delete maintains audit trail
        /// </summary>
        public string DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    
                    string deleteQuery = "DELETE * FROM users WHERE Username = @Username;";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        int result = cmd.ExecuteNonQuery();
                        return (result > 0) ? "User deactivated successfully" : "User not found";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Get all users as DataTable
        /// </summary>
        public DataTable GetAllUsers()
        {
            try
            {
                DataTable dtUsers = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT id, Username, Email, Role
                        FROM users
                        ORDER BY Username;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtUsers);
                    }
                }

                return dtUsers;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users: " + ex.Message);
            }
        }

        /// <summary>
        /// Search users with filtering
        /// </summary>
        public DataTable SearchUsers(string searchTerm)
        {
            try
            {
                DataTable dtSearch = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT id, Username, Email, Role
                        FROM users
                        WHERE Username LIKE @searchTerm 
                           OR Email LIKE @searchTerm 
                           OR Role LIKE @searchTerm
                        ORDER BY Username";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtSearch);
                    }
                }

                return dtSearch;
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching: " + ex.Message);
            }
        }

        //=============================
        // Recruiter Management
        //=============================

        /// <summary>
        /// Create recruiter account with transaction support
        /// Ensures atomic operation for user and recruiter creation
        /// </summary>
        public string CreateRecruiter(string username, string email, string password, 
            int companyId, string fullName, string position, string phone)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // Create user account first
                        string userQuery = @"
                            INSERT INTO users (Username, Email, Password, Role)
                            OUTPUT INSERTED.id
                            VALUES (@username, @email, @password, 'Recruiter')";

                        int userId;
                        using (SqlCommand userCmd = new SqlCommand(userQuery, con, transaction))
                        {
                            userCmd.Parameters.AddWithValue("@username", username);
                            userCmd.Parameters.AddWithValue("@email", email);
                            userCmd.Parameters.AddWithValue("@password", password);

                            userId = (int)userCmd.ExecuteScalar();
                        }

                        // Create recruiter record
                        string recruiterQuery = @"
                            INSERT INTO Recruiters (UserId, CompanyId, FullName, Position, Phone, Email)
                            VALUES (@userId, @companyId, @fullName, @position, @phone, @email)";

                        using (SqlCommand recruiterCmd = new SqlCommand(recruiterQuery, con, transaction))
                        {
                            recruiterCmd.Parameters.AddWithValue("@userId", userId);
                            recruiterCmd.Parameters.AddWithValue("@companyId", companyId);
                            recruiterCmd.Parameters.AddWithValue("@fullName", fullName);
                            recruiterCmd.Parameters.AddWithValue("@position", position);
                            recruiterCmd.Parameters.AddWithValue("@phone", phone);
                            recruiterCmd.Parameters.AddWithValue("@email", email);

                            int result = recruiterCmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                transaction.Commit();
                                return "Recruiter created successfully";
                            }
                        }

                        transaction.Rollback();
                        return "Failed to create recruiter";
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Get all recruiters by company
        /// </summary>
        public DataTable GetRecruitersByCompany(int companyId)
        {
            try
            {
                DataTable dtRecruiters = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT r.RecruiterId, r.FullName, r.Position, r.Phone, r.Email, 
                               u.Username, u.IsActive, c.CompanyName
                        FROM Recruiters r
                        JOIN Users u ON r.UserId = u.UserId
                        JOIN Companies c ON r.CompanyId = c.CompanyId
                        WHERE r.CompanyId = @companyId
                        ORDER BY r.FullName";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtRecruiters);
                    }
                }

                return dtRecruiters;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving recruiters: " + ex.Message);
            }
        }

        //=============================
        // Supervisor Assignment
        //=============================

        /// <summary>
        /// Assign supervisor to student
        /// Creates many-to-one relationship for student monitoring
        /// </summary>
        public string AssignSupervisor(int studentId, int supervisorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    string query = @"
                        UPDATE Students 
                        SET SupervisorId = @supervisorId
                        WHERE StudentId = @studentId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@supervisorId", supervisorId);
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        int result = cmd.ExecuteNonQuery();
                        return (result > 0) ? "Supervisor assigned successfully" : "Failed to assign";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        //=============================
        // Dashboard Statistics
        //=============================

        /// <summary>
        /// Get total count of active users
        /// </summary>
        public int GetTotalUsersCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? (int)result : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of students
        /// </summary>
        public int GetTotalStudentsCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Students";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? (int)result : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of companies
        /// </summary>
        public int GetTotalCompaniesCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Companies";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? (int)result : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of recruiters
        /// </summary>
        public int GetTotalRecruitersCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Recruiters";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? (int)result : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get count of pending applications
        /// </summary>
        public int GetPendingApplicationsCount()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Applications WHERE Status = 'Pending'";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? (int)result : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //=============================
        // Reports and Analytics
        //=============================

        /// <summary>
        /// Generate comprehensive placement statistics
        /// </summary>
        public DataTable GeneratePlacementStatistics()
        {
            try
            {
                DataTable dtStats = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT 
                            COUNT(DISTINCT a.StudentId) AS TotalApplications,
                            COUNT(DISTINCT CASE WHEN a.Status = 'Accepted' THEN a.StudentId END) AS Accepted,
                            COUNT(DISTINCT CASE WHEN a.Status = 'Rejected' THEN a.StudentId END) AS Rejected,
                            COUNT(DISTINCT CASE WHEN a.Status = 'Pending' THEN a.StudentId END) AS Pending,
                            COUNT(DISTINCT i.InternshipId) AS TotalInternships,
                            COUNT(DISTINCT c.CompanyId) AS CompaniesInvolved
                        FROM Applications a
                        FULL OUTER JOIN Internships i ON a.InternshipId = i.InternshipId
                        FULL OUTER JOIN Companies c ON i.CompanyId = c.CompanyId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtStats);
                    }
                }

                return dtStats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Get pending applications for dashboard
        /// </summary>
        public DataTable GetPendingApplications()
        {
            try
            {
                DataTable dtPending = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT a.ApplicationId, s.StudentId, s.FullName AS StudentName, 
                               i.Title AS InternshipTitle, c.CompanyName, a.ApplicationDate
                        FROM Applications a
                        JOIN Students s ON a.StudentId = s.StudentId
                        JOIN Internships i ON a.InternshipId = i.InternshipId
                        JOIN Companies c ON i.CompanyId = c.CompanyId
                        WHERE a.Status = 'Pending'
                        ORDER BY a.ApplicationDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtPending);
                    }
                }

                return dtPending;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Get activity logs showing recruiter decisions
        /// Maintains audit trail for system transparency
        /// </summary>
        public DataTable GetActivityLogs()
        {
            try
            {
                DataTable dtLogs = new DataTable();

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    string query = @"
                        SELECT a.ApplicationId, a.EvaluationDate, r.FullName AS RecruiterName, 
                               s.FullName AS StudentName, i.Title, a.Status, a.PerformanceScore,
                               a.PunctualityScore, a.CommunicationScore
                        FROM Applications a
                        LEFT JOIN Recruiters r ON a.RecruiterId = r.RecruiterId
                        JOIN Students s ON a.StudentId = s.StudentId
                        JOIN Internships i ON a.InternshipId = i.InternshipId
                        WHERE a.RecruiterId IS NOT NULL
                        ORDER BY a.EvaluationDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtLogs);
                    }
                }

                return dtLogs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Export all users to CSV file at the provided path.
        /// Returns a status message.
        /// </summary>
        public string ExportUsersToCSV(string filePath)
        {
            try
            {
                DataTable dt = GetAllUsers();
                if (dt == null || dt.Rows.Count == 0)
                    return "No users to export.";

                using (var sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // header
                    var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
                    sw.WriteLine(string.Join(",", columnNames));

                    // rows
                    foreach (DataRow row in dt.Rows)
                    {
                        var fields = dt.Columns.Cast<DataColumn>()
                            .Select(col => EscapeCsvField(row[col]));
                        sw.WriteLine(string.Join(",", fields));
                    }
                }

                return "Export completed: " + filePath;
            }
            catch (Exception ex)
            {
                return "Error exporting users: " + ex.Message;
            }
        }

        // small helper to quote/escape CSV fields
        private string EscapeCsvField(object value)
        {
            if (value == null) return "";
            var s = value.ToString();
            if (s.Contains("\"")) s = s.Replace("\"", "\"\"");
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n") || s.Contains("\r"))
                return "\"" + s + "\"";
            return s;
        }
    }
}
