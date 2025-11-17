using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

//Sync AdminManager as per my plans for the forms No Alterations
namespace ioop_GROUP_WORK.Admin
{
    /// <summary>
    /// AdminManager - Business Logic Layer for Administrator operations
    /// Implements Singleton pattern for database operations
    /// Provides centralized management of admin functions with validation
    /// </summary>
    internal class AdminManager
    {
        //=============================
        // Singleton Instance
        //=============================
        private static AdminManager instance = null;
        private static readonly object lockObject = new object();
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

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
        public string CreateUser(string id, string username, string email, string password, string role)
        {
            try
            {
                if (!ValidationHelper.ValidatePassword(password))
                {
                    return "Password must be at least 8 characters with uppercase, lowercase, and numbers!";
                }

                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    // Check if email exists
                    if (!string.IsNullOrEmpty(email))
                    {
                        if (!ValidationHelper.ValidateEmail(email))
                            return "Invalid email format";

                        string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE Email = @Email;";
                        using (SqlCommand checkCmd = new SqlCommand(checkEmailQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@Email", email);
                            int emailExists = (int)checkCmd.ExecuteScalar();
                            if (emailExists > 0)
                                return "Email already exists";
                        }
                    }

                    // Check if username exists
                    if (!string.IsNullOrEmpty(username))
                    {
                        if (!ValidationHelper.ValidateUsername(username))
                            return "Invalid username format";

                        string checkUsernameQuery = "SELECT COUNT(*) FROM users WHERE Username = @Username;";
                        using (SqlCommand checkCmd = new SqlCommand(checkUsernameQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@Username", username);
                            int usernameExists = (int)checkCmd.ExecuteScalar();
                            if (usernameExists > 0)
                                return "Username already exists";
                        }
                    }

                    // Insert user with parameterized query (SQL injection prevention)
                    // Database users table columns: Username, password, Email, role
                    string insertQuery = @"
                        INSERT INTO users (Username, password, Email, role)
                        VALUES (@Username, @password, @Email, @Role);";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username ?? "");
                        cmd.Parameters.AddWithValue("@Email", email ?? "");
                        cmd.Parameters.AddWithValue("@password", password ?? "");
                        cmd.Parameters.AddWithValue("@Role", role ?? "");

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
        public string UpdateUser(int userId, string field, string specificattribute)
        {
            try
            {
                // ✅ Validate email if updating Email field
                if (field.ToLower() == "email" && !ValidationHelper.ValidateEmail(specificattribute))
                    return "Invalid email format";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    // ✅ Build dynamic query based on which field to update
                    string updateQuery = "";

                    switch (field.ToLower())
                    {
                        case "username":
                            updateQuery = "UPDATE dbo.users SET Username = @specificattribute WHERE id = @id";
                            break;
                        case "email":
                            updateQuery = "UPDATE dbo.users SET Email = @specificattribute WHERE id = @id";
                            break;
                        case "password":
                            updateQuery = "UPDATE dbo.users SET password = @specificattribute WHERE id = @id";
                            break;
                        case "role":
                            updateQuery = "UPDATE dbo.users SET role = @specificattribute WHERE id = @id";
                            break;
                        default:
                            return "Invalid field name";
                    }

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@specificattribute", specificattribute ?? "");
                        cmd.Parameters.AddWithValue("@id", userId);

                        int result = cmd.ExecuteNonQuery();
                        return (result > 0)
                            ? $"User {field} updated successfully"
                            : "User not found";
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
        /// </summary>
        public string DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    string deleteQuery = "DELETE FROM users WHERE id = @id;";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        int result = cmd.ExecuteNonQuery();
                        return (result > 0) ? "User deleted successfully" : "User not found";
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
                    con.Open();
                    string query = @"
                        SELECT id AS UserId, Username, Email, role AS Role
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
                        SELECT id AS UserId, Username, Email, role AS Role
                        FROM users
                        WHERE Username LIKE @searchTerm 
                           OR Email LIKE @searchTerm 
                           OR role LIKE @searchTerm
                        ORDER BY Username;";

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
                            INSERT INTO users (Username, Email, password, role)
                            OUTPUT INSERTED.id
                            VALUES (@username, @email, @password, 'Recruiter');";

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
                            VALUES (@userId, @companyId, @fullName, @position, @phone, @email);";

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
                               u.Username, c.CompanyName
                        FROM Recruiters r
                        JOIN users u ON r.UserId = u.id
                        JOIN CompanyProfile c ON r.CompanyId = c.Id
                        WHERE r.CompanyId = @companyId
                        ORDER BY r.FullName;";

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
        public string AssignSupervisor(string studentId, int supervisorId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    // Attempt to update Students table if it has SupervisorId column
                    string query = @"
                        UPDATE Students 
                        SET SupervisorId = @supervisorId
                        WHERE studentID = @studentId;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@supervisorId", supervisorId);
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        try
                        {
                            int result = cmd.ExecuteNonQuery();
                            return (result > 0) ? "Supervisor assigned successfully" : "Failed to assign (no matching student)";
                        }
                        catch (SqlException sqlEx)
                        {
                            // Likely the Students table doesn't have SupervisorId column in the schema
                            return "Cannot assign supervisor: database schema does not contain a SupervisorId column on Students. " + sqlEx.Message;
                        }
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
        public int GetTotalUsersCount() // Make Dynamic for Totals for all Relevant Columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM users;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
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
        public int GetTotalStudentsCount() // Make Dynamic for Averages of All Relevant columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Students;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
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
        public int GetTotalCompaniesCount() // Make Dynamic for Max Values of Relevant Columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM CompanyProfile;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
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
        public int GetTotalRecruitersCount() // Make Dynamic for Min Values of Relevant Columns
        {
            try
            {
                using (SqlConnection con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Recruiters;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
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
                    string query = "SELECT COUNT(*) FROM StudentApplication WHERE Status = 'Pending';";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
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
                        SELECT StudentID, StudentName, Position, CompanyName, DateApplied, Status
                        FROM StudentApplication
                        WHERE Status = 'Pending'
                        ORDER BY DateApplied DESC;";

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
        public DataTable GetActivityLogs(string status)
        {
            DataTable dtLogs = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();
                string query = @"
            SELECT StudentID, StudentName, CompanyName, Position, DateApplied, Status
            FROM StudentApplication
            WHERE (@status = 'All' OR Status = @status)
            ORDER BY DateApplied DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtLogs);
                }
            }
            return dtLogs;
        }


        /// <summary>
        /// Export all users to CSV file
        /// </summary>

        //=============================
        // NEW: Table Export Functions (Simple SQL Way)
        //=============================

        /// <summary>
        /// Get all table names from Database1.mdf
        /// </summary>
        public DataTable GetAllTables()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting tables: " + ex.Message);
            }
        }

        /// <summary>
        /// Get table data (SQL)
        /// </summary>
        public DataTable GetTableData(string tableName)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = $"SELECT * FROM [{tableName}]";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandTimeout = 120;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting table data: " + ex.Message);
            }
        }


        /// <summary>
        /// Export to CSV excluding IDs and Passwords
        /// </summary>

        /// <summary>
        /// Remove sensitive columns like IDs and Passwords for export
        /// </summary>
        /// <summary>
        /// Calculate relevant aggregate statistics for any table
        /// Based on database schema - extracts meaningful metrics
        /// Examples: TotalStudents, AverageSalary, TotalPendingApplications
        /// </summary>
        /// <summary>
        /// Calculate relevant aggregate statistics for any table
        /// Excludes IDs and sensitive columns
        /// </summary>
        public DataTable CalculateAggregateStatistics(string tableName)
        {
            try
            {
                DataTable dt = GetTableData(tableName);
                if (dt == null || dt.Rows.Count == 0)
                    return null;

                DataTable stats = new DataTable();
                stats.Columns.Add("Metric", typeof(string));
                stats.Columns.Add("Value", typeof(string));

                // Basic Info
                stats.Rows.Add("Table", tableName);
                stats.Rows.Add("Total Records", dt.Rows.Count.ToString());
                stats.Rows.Add("", "");

                // Sensitive patterns to exclude
                var sensitivePatterns = new[] { "id", "password", "passwordhash", "salt", "token", "secret", "key", "credential" };

                // Relevant aggregates based on table schema
                switch (tableName.ToLower())
                {
                    case "students":
                        stats.Rows.Add("Total Students", dt.Rows.Count.ToString());
                        break;

                    case "studentapplication":
                        int totalApps = dt.Rows.Count;
                        int accepted = 0, rejected = 0, pending = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["Status"] != DBNull.Value)
                            {
                                string status = row["Status"].ToString().Trim().ToLower();
                                if (status == "accepted") accepted++;
                                else if (status == "rejected") rejected++;
                                else if (status == "pending") pending++;
                            }
                        }
                        stats.Rows.Add("Total Applications", totalApps.ToString());
                        stats.Rows.Add("Accepted", accepted.ToString());
                        stats.Rows.Add("Rejected", rejected.ToString());
                        stats.Rows.Add("Pending", pending.ToString());
                        break;

                    case "internshipoffer":
                        stats.Rows.Add("Total Internship Offers", dt.Rows.Count.ToString());
                        // Calculate average salary if exists
                        try
                        {
                            if (dt.Columns.Contains("Salary"))
                            {
                                decimal totalSalary = 0;
                                int salaryCount = 0;
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (row["Salary"] != DBNull.Value)
                                    {
                                        totalSalary += Convert.ToDecimal(row["Salary"]);
                                        salaryCount++;
                                    }
                                }
                                if (salaryCount > 0)
                                    stats.Rows.Add("Average Salary", (totalSalary / salaryCount).ToString("N2"));
                            }
                        }
                        catch { }
                        break;

                    case "users":
                        stats.Rows.Add("Total Users", dt.Rows.Count.ToString());
                        break;

                    case "recruiters":
                        stats.Rows.Add("Total Recruiters", dt.Rows.Count.ToString());
                        break;

                    case "supervisors":
                        stats.Rows.Add("Total Supervisors", dt.Rows.Count.ToString());
                        break;

                    case "companyprofile":
                        stats.Rows.Add("Total Companies", dt.Rows.Count.ToString());
                        break;

                    default:
                        // Generic numeric column aggregates (excluding IDs and sensitive columns)
                        foreach (DataColumn col in dt.Columns)
                        {
                            // Skip sensitive columns
                            bool isSensitive = false;
                            foreach (var pattern in sensitivePatterns)
                            {
                                if (col.ColumnName.ToLower().Contains(pattern))
                                {
                                    isSensitive = true;
                                    break;
                                }
                            }

                            if (isSensitive)
                                continue;

                            // Only calculate for numeric columns
                            if (col.DataType == typeof(int) || col.DataType == typeof(decimal) ||
                                col.DataType == typeof(double) || col.DataType == typeof(float))
                            {
                                try
                                {
                                    decimal sum = 0, max = decimal.MinValue, min = decimal.MaxValue;
                                    int count = 0;

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        if (row[col] != DBNull.Value)
                                        {
                                            decimal val = Convert.ToDecimal(row[col]);
                                            sum += val;
                                            if (val > max) max = val;
                                            if (val < min) min = val;
                                            count++;
                                        }
                                    }

                                    if (count > 0)
                                    {
                                        stats.Rows.Add($"{col.ColumnName} - Total", sum.ToString("N2"));
                                        stats.Rows.Add($"{col.ColumnName} - Average", (sum / count).ToString("N2"));
                                        stats.Rows.Add($"{col.ColumnName} - Maximum", max.ToString("N2"));
                                        stats.Rows.Add($"{col.ColumnName} - Minimum", min.ToString("N2"));
                                    }
                                }
                                catch { }
                            }
                        }
                        break;
                }

                stats.Rows.Add("", "");
                stats.Rows.Add("Last Updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating statistics: " + ex.Message);
            }
        }

        /// <summary>
        /// Export to CSV with both data AND statistics (Excludes IDs and Passwords)
        /// </summary>
        /// <summary>
        /// Export to CSV with both data AND statistics (Excludes IDs and Passwords)
        /// </summary>
        public string ExportToCSVExcludingSensitive(string tableName, string filePath)
        {
            try
            {
                DataTable dt = GetTableData(tableName);
                if (dt == null || dt.Rows.Count == 0)
                    return "No data to export.";

                // Create a copy to preserve original
                DataTable dtCopy = dt.Copy();

                // Remove sensitive columns
                RemoveSensitiveColumnsForExport(dtCopy);

                if (dtCopy.Columns.Count == 0)
                    return "No columns available after removing sensitive data.";

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // ===== DATA SECTION =====
                    sw.WriteLine($"TABLE: {tableName}");
                    sw.WriteLine($"Export Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    sw.WriteLine($"Total Records: {dtCopy.Rows.Count}");
                    sw.WriteLine();

                    // Column headers
                    for (int i = 0; i < dtCopy.Columns.Count; i++)
                    {
                        sw.Write(dtCopy.Columns[i].ColumnName);
                        if (i < dtCopy.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();

                    // Data rows
                    for (int i = 0; i < dtCopy.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtCopy.Columns.Count; j++)
                        {
                            object val = dtCopy.Rows[i][j];
                            string strVal = (val == null || val == DBNull.Value) ? "" : val.ToString();

                            if (strVal.Contains(",") || strVal.Contains("\""))
                                strVal = "\"" + strVal.Replace("\"", "\"\"") + "\"";

                            sw.Write(strVal);
                            if (j < dtCopy.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();
                    }

                    // ===== AGGREGATE STATISTICS SECTION =====
                    sw.WriteLine();
                    sw.WriteLine("═════════════════════════════════════════");
                    sw.WriteLine("AGGREGATE STATISTICS");
                    sw.WriteLine("═════════════════════════════════════════");
                    sw.WriteLine();

                    try
                    {
                        DataTable dtStats = CalculateAggregateStatistics(tableName);
                        if (dtStats != null && dtStats.Rows.Count > 0)
                        {
                            foreach (DataRow statRow in dtStats.Rows)
                            {
                                string metric = statRow[0].ToString();
                                string value = statRow[1].ToString();
                                if (!string.IsNullOrWhiteSpace(metric))
                                    sw.WriteLine($"{metric},{value}");
                            }
                        }
                    }
                    catch { }
                }

                return "Export OK: " + System.IO.Path.GetFileName(filePath);
            }
            catch (System.IO.IOException ioEx)
            {
                return "File Error: " + ioEx.Message;
            }
            catch (SqlException sqlEx)
            {
                return "SQL Error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Remove sensitive columns like IDs and Passwords for export
        /// </summary>
        private void RemoveSensitiveColumnsForExport(DataTable dt)
        {
            var sensitivePatterns = new[] { "id", "password", "passwordhash", "salt", "token", "secret", "key", "credential" };
            var columnsToRemove = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                foreach (var pattern in sensitivePatterns)
                {
                    if (col.ColumnName.ToLower().Contains(pattern))
                    {
                        columnsToRemove.Add(col.ColumnName);
                        break;
                    }
                }
            }

            foreach (var colName in columnsToRemove)
            {
                dt.Columns.Remove(colName);
            }
        }
    }
}
