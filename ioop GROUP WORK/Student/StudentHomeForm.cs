using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Example: show username in a label
            lblWelcome.Text = $"Welcome, {username}";
        }
        private void btnProfile_Click(object sender, EventArgs e)
        {
            new StudentProfileForm().Show();
        }
        private void btnInternship_Click(object sender, EventArgs e)
        {
            new InternshipListForm().Show();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            new UploadResumeForm().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentHomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
