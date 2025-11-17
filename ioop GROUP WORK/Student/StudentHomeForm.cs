using System;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentHomeForm : Form
    {
        private string studentID;
        private string studentName;
        public StudentHomeForm()
        {
            InitializeComponent();
        }



        public StudentHomeForm(string id, string name)
        {
            InitializeComponent();
            studentID = id;
            studentName = name;

            // Display Name in a label
            lblWelcome.Text = $"Welcome, {studentName}";
        }



        private void btnProfile_Click(object sender, EventArgs e)
        {
            StudentProfileForm profile = new StudentProfileForm(studentID);
            profile.ShowDialog();
        }



        private void btnInternship_Click(object sender, EventArgs e)
        {
            InternshipListForm internship = new InternshipListForm();
            internship.ShowDialog();
        }



        private void btnApplications_Click(object sender, EventArgs e)
        {
            ViewApplicationStatusForm application = new ViewApplicationStatusForm(studentID);
            application.ShowDialog();
        }



        private void btnUploadReport_Click(object sender, EventArgs e)
        {
            StudentReportUploadForm report = new StudentReportUploadForm(studentID);
            report.ShowDialog();
        }



        private void btnFeedback_Click(object sender, EventArgs e)
        {
            ViewFeedbackForm feedback = new ViewFeedbackForm(studentID);
            feedback.ShowDialog();
        }



        private void btnProgress_Click(object sender, EventArgs e)
        {
            ViewProgressForm progress = new ViewProgressForm(studentID);
            progress.ShowDialog();
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
            ChangePasswordForm changepass = new ChangePasswordForm(studentID);
            changepass.ShowDialog();
        }

        private void StudentHomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
