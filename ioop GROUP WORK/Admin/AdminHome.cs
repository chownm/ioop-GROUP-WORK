using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;
using ioopGROUPWORK.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Admin
{
    public partial class AdminHome : Form
    {
        private readonly AdminManager adminUser;

        internal AdminHome()
        {
            InitializeComponent();
        }

        internal AdminHome(AdminManager admin)
        {
            InitializeComponent();
            this.adminUser = admin;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void BtnManageUsers_Click(object sender, EventArgs e)
        {
            try
            {
                ManageUsers manageUsers = new ManageUsers();
                manageUsers.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Manage Users: " + ex.Message);
            }
        }

        private void BtnManageRecruiters_Click(object sender, EventArgs e)
        {
            try
            {
                ManageRecruiters manageRecruiters = new ManageRecruiters();
                manageRecruiters.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Manage Recruiters: " + ex.Message);
            }
        }

        private void BtnAssignSupervisors_Click(object sender, EventArgs e)
        {
            try
            {
                AssignSupervisor assignSupervisor = new AssignSupervisor();
                assignSupervisor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Assign Supervisors: " + ex.Message);
            }
        }

        private void BtnGenerateReports_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateReports generateReports = new GenerateReports();
                generateReports.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Generate Reports: " + ex.Message);
            }
        }

        private void BtnViewStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                ViewStatistics viewStatistics = new ViewStatistics();
                viewStatistics.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening View Statistics: " + ex.Message);
            }
        }

        private void BtnSystemConfig_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConfiguration systemConfiguration = new SystemConfiguration();
                systemConfiguration.Show();
                MessageBox.Show("System Configuration coming soon.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening System Config: " + ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Refresh current form
                this.Refresh();
                MessageBox.Show("Dashboard refreshed.", "Info");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing: " + ex.Message);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                // Logout and return to login
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging out: " + ex.Message);
            }
        }
    }
}
