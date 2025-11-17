using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.HR;
using ioop_GROUP_WORK.UniSupervisor;
using System.Windows.Navigation;

namespace ioop_GROUP_WORK
{
    public partial class AdminHome : Form
    {
        private readonly Administrator adminUser;

        public AdminHome()
        {
            InitializeComponent();
        }

        internal AdminHome(Administrator admin)
        {
            InitializeComponent();
            this.adminUser = admin;
        }

        private int lblTotalUsersint;
        private int lblTotalStudentsint;
        private int lblTotalCompaniesint;
        private int lblTotalRecruitersint;
        private int lblPendingApplicationsint;

        // Properties
        public int TotalUsers
        {
            get
            {
                return lblTotalUsersint;
            }
            private set
            {
                lblTotalUsersint = value;
            }
        }

        public int TotalStudents
        {
            get
            {
                return lblTotalStudentsint;
            }
            private set
            {
                lblTotalStudentsint = value;
            }
        }

        public int TotalCompanies
        {
            get
            {
                return lblTotalCompaniesint;
            }
            private set
            {
                lblTotalCompaniesint = value;
            }
        }

        public int TotalRecruiters
        {
            get
            {
                return lblTotalRecruitersint;
            }
            private set
            {
                lblTotalRecruitersint = value;
            }
        }

        public int PendingApplications
        {
            get
            {
                return lblPendingApplicationsint;
            }
            private set
            {
                lblPendingApplicationsint = value;
            }
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

                        // Set property values (this calls the private setters)
                        TotalUsers = Convert.ToInt32(stats.Rows[0]["TotalUsers"]);
                        TotalStudents = Convert.ToInt32(stats.Rows[0]["TotalStudents"]);
                        TotalCompanies = Convert.ToInt32(stats.Rows[0]["TotalCompanies"]);
                        TotalRecruiters = Convert.ToInt32(stats.Rows[0]["TotalRecruiters"]);
                        PendingApplications = Convert.ToInt32(stats.Rows[0]["PendingApplications"]);
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
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
        }

        private void BtnManageRecruiters_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manage Recruiters form will open here.", "Info");
            ManageRecruiters manageRecruiters = new ManageRecruiters();
            manageRecruiters.Show();
        }

        private void BtnAssignSupervisors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Assign Supervisors form will open here.", "Info");
            AssignSupervisor assignSupervisor = new AssignSupervisor();
            assignSupervisor.Show();
        }

        private void BtnGenerateReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generate Reports form will open here.", "Info");
            GenerateReports generateReports = new GenerateReports();
            generateReports.Show();
        }

        private void BtnViewStatistics_Click(object sender, EventArgs e)
        {
            MessageBox.Show("View Statistics form will open here.", "Info");
            ViewStatistics viewStatistics = new ViewStatistics();
            viewStatistics.Show();
        }

        private void BtnSystemConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show("System Configuration form will open here.", "Info");
            SystemConfiguration systemConfiguration = new SystemConfiguration();
            systemConfiguration.Show();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            AdminManager adm = AdminManager.Instance;
            lblTotalUsers.Text = "Total Users: " + adm.GetTotalUsersCount().ToString();
            lblTotalStudents.Text = "Total Students: " + adm.GetTotalStudentsCount().ToString();
            lblTotalCompanies.Text = "Total Companies: " + adm.GetTotalCompaniesCount().ToString();
            lblTotalRecruiters.Text = "Total Recruiters: " + adm.GetTotalRecruitersCount().ToString();
            lblPendingApplications.Text = "Pending: " + adm.GetPendingApplicationsCount().ToString();
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
