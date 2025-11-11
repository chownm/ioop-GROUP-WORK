using System;
using System.Drawing;
using System.Windows.Forms;
using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Managers;

namespace InternshipTrackerSystem.Forms.Administrator
{
    public partial class AdminDashboard : Form
    {
        private Administrator currentAdmin;

        public AdminDashboard(Administrator admin)
        {
            currentAdmin = admin;
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                lblWelcome.Text = $"Welcome, {currentAdmin.FullName}!";
                lblAccessLevel.Text = $"Access Level: {currentAdmin.AccessLevel}";

                // Get system-wide statistics
                int totalUsers = UserManager.Instance.GetTotalUsersCount();
                int totalStudents = UserManager.Instance.GetUserCountByRole("Student");
                int totalCompanies = UserManager.Instance.GetUserCountByRole("CompanyHR");
                int totalRecruiters = UserManager.Instance.GetUserCountByRole("Recruiter");
                int totalSupervisors = UserManager.Instance.GetUserCountByRole("Supervisor");

                lblTotalUsers.Text = totalUsers.ToString();
                lblTotalStudents.Text = totalStudents.ToString();
                lblTotalCompanies.Text = totalCompanies.ToString();
                lblTotalRecruiters.Text = totalRecruiters.ToString();
                lblTotalSupervisors.Text = totalSupervisors.ToString();

                // Get internship and application stats
                int totalInternships = InternshipManager.Instance.GetTotalInternshipsCount();
                int totalApplications = ApplicationManager.Instance.GetTotalApplicationsCount();
                int pendingApplications = ApplicationManager.Instance.GetApplicationsCountByStatus("Pending");

                lblTotalInternships.Text = totalInternships.ToString();
                lblTotalApplications.Text = totalApplications.ToString();
                lblPendingApplications.Text = pendingApplications.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message, "Error");
            }
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            UserManagementForm userForm = new UserManagementForm(currentAdmin);
            userForm.ShowDialog();
            LoadDashboardData();
        }

        private void btnManageRecruiters_Click(object sender, EventArgs e)
        {
            RecruiterManagementAdminForm recruiterForm = new RecruiterManagementAdminForm(currentAdmin);
            recruiterForm.ShowDialog();
            LoadDashboardData();
        }

        private void btnAssignSupervisors_Click(object sender, EventArgs e)
        {
            SupervisorAssignmentForm assignForm = new SupervisorAssignmentForm(currentAdmin);
            assignForm.ShowDialog();
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            ReportGenerationForm reportForm = new ReportGenerationForm(currentAdmin);
            reportForm.ShowDialog();
        }

        private void btnViewApplications_Click(object sender, EventArgs e)
        {
            PendingApplicationsForm pendingForm = new PendingApplicationsForm(currentAdmin);
            pendingForm.ShowDialog();
        }

        private void btnSystemSettings_Click(object sender, EventArgs e)
        {
            SystemSettingsForm settingsForm = new SystemSettingsForm(currentAdmin);
            settingsForm.ShowDialog();
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            AuditLogViewerForm auditForm = new AuditLogViewerForm(currentAdmin);
            auditForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Close();
            }
        }
    }
}

