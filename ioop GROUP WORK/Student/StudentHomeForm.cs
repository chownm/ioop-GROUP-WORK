using System;
using System.Windows.Forms;
using ioop_GROUP_WORK;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentHomeForm : Form
    {
        private string username;
        public StudentHomeForm()
        {
            InitializeComponent();
        }

        public StudentHomeForm(string username)
        {
            InitializeComponent();
            this.username = username;
            // Show username in a label
            lblWelcome.Text = $"Welcome, {username}";
        }


        private void btnProfile_Click(object sender, EventArgs e)
        {
            StudentProfileForm profile = new StudentProfileForm(username);
            profile.ShowDialog();
        }



        private void btnInternship_Click(object sender, EventArgs e)
        {
            InternshipListForm internship = new InternshipListForm();
            internship.ShowDialog();
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            ViewApplicationStatusForm application = new ViewApplicationStatusForm();
            application.ShowDialog();
        }


        private void btnFeedback_Click(object sender, EventArgs e)
        {
            ViewFeedbackForm feedback = new ViewFeedbackForm();
            feedback.ShowDialog();
        }


        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            UploadResumeForm resume = new UploadResumeForm();
            resume.ShowDialog();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginPage().Show();
        }


        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changepass = new ChangePasswordForm(username);
            changepass.ShowDialog();
        }


        private void StudentHomeForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
