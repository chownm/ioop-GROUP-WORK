using System;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentHomeForm : Form
    {
        // Attributes
        private StudentHome studentHome;

        // Constructor
        public StudentHomeForm()
        {
            InitializeComponent();
        }

        public StudentHomeForm(string id, string name)
        {
            InitializeComponent();
            // Initialize the StudentHome object with student data
            studentHome = new StudentHome(id, name);

            // Display the welcome message on the label
            lblWelcome.Text = studentHome.GetWelcomeMessage();
        }

        // Button click handlers that delegate logic to StudentHome

        private void btnProfile_Click(object sender, EventArgs e)
        {
            studentHome.OpenProfileForm();
        }

        private void btnInternship_Click(object sender, EventArgs e)
        {
            studentHome.OpenInternshipForm();
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            studentHome.OpenApplicationsForm();
        }

        private void btnUploadReport_Click(object sender, EventArgs e)
        {
            studentHome.OpenReportUploadForm();
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            studentHome.OpenFeedbackForm();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            studentHome.OpenCheckInForm();
        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            studentHome.OpenProgressForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmation == DialogResult.Yes)
            {
                this.Close();
                new LoginPage().Show();
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            studentHome.OpenChangePasswordForm();
        }

        private void StudentHomeForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
