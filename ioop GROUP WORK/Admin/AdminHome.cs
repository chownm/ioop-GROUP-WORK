using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ============================================================================
// FILE: AdminHome.cs
// Purpose: Administrator Dashboard
// ============================================================================
using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.UniSupervisor;

namespace ioop_GROUP_WORK
{
    public partial class AdminHome : Form
    {
        private readonly Administrator adminUser;

        public AdminHome()
        {
            InitializeComponent();
        }

        public AdminHome(Administrator admin)
        {
            InitializeComponent();
            this.adminUser = admin;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            try
            {
                // Load admin dashboard statistics
                if (adminUser != null)
                {
                    var stats = adminUser.GetStatistics();
                    if (stats.Rows.Count > 0)
                    {
                        lblTotalUsers.Text = "Total Users: " + stats.Rows[0]["TotalUsers"].ToString();
                        lblTotalStudents.Text = "Total Students: " + stats.Rows[0]["TotalStudents"].ToString();
                        lblTotalCompanies.Text = "Total Companies: " + stats.Rows[0]["TotalCompanies"].ToString();
                        lblTotalRecruiters.Text = "Total Recruiters: " + stats.Rows[0]["TotalRecruiters"].ToString();
                        lblPendingApplications.Text = "Pending: " + stats.Rows[0]["PendingApplications"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error");
            }
        }

        private void BtnManageUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Users form will open here.", "Info");
        }

        private void BtnManageRecruiters_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Recruiters form will open here.", "Info");
        }

        private void BtnAssignSupervisors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Assign Supervisors form will open here.", "Info");
        }

        private void BtnGenerateReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generate Reports form will open here.", "Info");
        }

        private void BtnViewStatistics_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Statistics form will open here.", "Info");
        }

        private void BtnSystemConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("System Configuration form will open here.", "Info");
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh dashboard statistics
            AdminHome_Load(this, null);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Logout and return to login
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }
    }
}
