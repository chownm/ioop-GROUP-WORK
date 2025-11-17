using System;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentRegisterForm : Form
    {
        private StudentRegister studentRegisterLogic;

        public StudentRegisterForm()
        {
            InitializeComponent();
            studentRegisterLogic = new StudentRegister();
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtStuName?.Text?.Trim() ?? "";
            string id = txtStuID?.Text?.Trim() ?? "";
            string email = txtStuEmail?.Text?.Trim() ?? "";
            string contact = txtStuCont?.Text?.Trim() ?? "";
            string course = txtStuCourse?.Text?.Trim() ?? "";
            string password = txtStuPass?.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(course) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            if (studentRegisterLogic.DoesStudentIDExist(id))
            {
                MessageBox.Show("Student ID already exists!");
                return;
            }

            // Register the student
            string resultMessage = studentRegisterLogic.RegisterStudent(id, name, email, contact, course, password);

            MessageBox.Show(resultMessage);

            if (resultMessage == "Registration successful!")
            {
                this.Close();
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void StudentRegisterForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
