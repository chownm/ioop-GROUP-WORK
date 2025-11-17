using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ioop_GROUP_WORK.Login;
using ioop_GROUP_WORK.Admin;

namespace ioop_GROUP_WORK.Admin
{
    public partial class SystemConfiguration : Form
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        // ✅ FIX: Store Administrator object (NOT User)
        private Administrator _currentAdmin;

        // ✅ FIX: Property to expose the Administrator
        internal Administrator CurrentAdmin { get; private set; }

        // ✅ FIX: Constructor that CORRECTLY assigns the parameter
        internal SystemConfiguration(Administrator currentAdmin)
        {
            InitializeComponent();
            _currentAdmin = currentAdmin;  // ✅ ASSIGN PARAMETER (NOT admin property)
            CurrentAdmin = currentAdmin;   // ✅ Also set the public property
            LoadSystemSettings();
        }

        // ✅ KEEP: Empty constructor
        public SystemConfiguration()
        {
            InitializeComponent();
            LoadSystemSettings();
        }

        // ✅ LOAD SYSTEM SETTINGS FROM DATABASE
        private void LoadSystemSettings()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Load Users Count
                    string queryUsers = "SELECT COUNT(*) FROM dbo.users";
                    using (SqlCommand cmd = new SqlCommand(queryUsers, conn))
                    {
                        int userCount = (int)cmd.ExecuteScalar();
                        lblUserCount.Text = $"Total Users: {userCount}";
                    }

                    // Load Students Count
                    string queryStudents = "SELECT COUNT(*) FROM dbo.Students";
                    using (SqlCommand cmd = new SqlCommand(queryStudents, conn))
                    {
                        int studentCount = (int)cmd.ExecuteScalar();
                        lblStudentCount.Text = $"Total Students: {studentCount}";
                    }

                    // Load Applications Count
                    string queryApps = "SELECT COUNT(*) FROM dbo.StudentApplication";
                    using (SqlCommand cmd = new SqlCommand(queryApps, conn))
                    {
                        int appCount = (int)cmd.ExecuteScalar();
                        lblApplicationCount.Text = $"Total Applications: {appCount}";
                    }

                    // Load Administrators Count
                    string queryAdmins = "SELECT COUNT(*) FROM dbo.Administrators";
                    using (SqlCommand cmd = new SqlCommand(queryAdmins, conn))
                    {
                        int adminCount = (int)cmd.ExecuteScalar();
                        lblAdminCount.Text = $"Total Administrators: {adminCount}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading system settings: " + ex.Message);
            }
        }

        // ✅ RESET DATABASE (ADMIN ONLY)
        private void btnResetDatabase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset the database? This action cannot be undone!",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();

                        // Clear all application data (keep schema)
                        string[] clearQueries = new string[]
                        {
                            "DELETE FROM dbo.Student_Progress",
                            "DELETE FROM dbo.Student_Evaluation_Report",
                            "DELETE FROM dbo.Check_In_Record",
                            "DELETE FROM dbo.StudentApplication",
                            "DELETE FROM dbo.InternshipOffer",
                            "DELETE FROM dbo.Recruiters",
                            "DELETE FROM dbo.Supervisors",
                            "DELETE FROM dbo.Administrators WHERE AdminId != @currentAdminId"
                        };

                        foreach (string query in clearQueries)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                // ✅ FIX: Use AdminId (NOT UserId) and check for Administrator object
                                if (query.Contains("@currentAdminId") && _currentAdmin != null)
                                {
                                    cmd.Parameters.AddWithValue("@currentAdminId", _currentAdmin.AdminId);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Database reset successfully!");
                    LoadSystemSettings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error resetting database: " + ex.Message);
                }
            }
        }

        // ✅ BACKUP DATABASE
        private void btnBackupDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "SQL Backup Files (*.bak)|*.bak";
                saveDialog.FileName = $"Database_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        string backupQuery = $"BACKUP DATABASE [Database1] TO DISK = '{saveDialog.FileName}'";

                        using (SqlCommand cmd = new SqlCommand(backupQuery, conn))
                        {
                            cmd.CommandTimeout = 300; // 5 minutes
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Database backup completed successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error backing up database: " + ex.Message);
            }
        }

        // ✅ VIEW SYSTEM LOGS
        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            u.Username,
                            u.role,
                            u.Email,
                            'Active' as Status
                        FROM dbo.users u
                        ORDER BY u.Username";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLogs.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logs: " + ex.Message);
            }
        }

        // ✅ REFRESH SYSTEM STATUS
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSystemSettings();
            MessageBox.Show("System status refreshed!");
        }

        // ✅ CLOSE FORM
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}