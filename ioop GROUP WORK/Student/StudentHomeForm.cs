using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StudentProfileForm changeform = new StudentProfileForm();
            changeform.ShowDialog();
        }



        private void btnInternship_Click(object sender, EventArgs e)
        {
            InternshipListForm changeform = new InternshipListForm();
            changeform.ShowDialog();
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            ViewApplicationStatusForm changeform = new ViewApplicationStatusForm();
            changeform.ShowDialog();
        }


        private void btnFeedback_Click(object sender, EventArgs e)
        {
            ViewFeedbackForm changeform = new ViewFeedbackForm();
            changeform.ShowDialog();
        }


        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            UploadResumeForm changeform = new UploadResumeForm();
            changeform.ShowDialog();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginPage().Show();
        }


        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changeform = new ChangePasswordForm(username);
            changeform.ShowDialog();
        }


        private void StudentHomeForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}
