using System;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentProfileForm : Form
    {
        private string studentID;
        private StudentProfile studentProfileLogic;

        public StudentProfileForm(string id)
        {
            InitializeComponent();
            studentID = id;
            studentProfileLogic = new StudentProfile(studentID);
        }

        private void StudentProfileForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            var (studentName, email, phoneNumber, course, errorMessage) = studentProfileLogic.GetStudentProfile();

            if (string.IsNullOrEmpty(errorMessage))
            {
                lblStudentID.Text = studentID;
                lblName.Text = studentName;
                txtEmail.Text = email;
                txtPhone.Text = phoneNumber;
                txtCourse.Text = course;
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string course = txtCourse.Text.Trim();

            string resultMessage = studentProfileLogic.UpdateStudentProfile(email, phone, course);

            MessageBox.Show(resultMessage, "Profile Update", MessageBoxButtons.OK, resultMessage.StartsWith("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);

            if (resultMessage == "Profile updated successfully!")
            {
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
