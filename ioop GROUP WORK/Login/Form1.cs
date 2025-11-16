using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK.Login;
using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Student;
using ioop_GROUP_WORK.UniSupervisor;
using ioop_GROUP_WORK.HR;

namespace ioop_GROUP_WORK
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string role;
            string studentName = null;
            // Create a User object with the username and password entered
            User obj1 = new User(txtUsername.Text, txtPassword.Text);

            //FOR STUDENT PART (DO NOT DELETE)
            (role, studentName) = obj1.login();

            // If the role is valid, navigate to the appropriate home form
            if (role != null)
            {
                switch (role)
                {
                    case "admin":
                        AdminHome adminHome = new AdminHome();
                        adminHome.Show();
                        this.Hide();
                        break;
                    case "student":
                        StudentHomeForm studentHome = new StudentHomeForm(txtUsername.Text, studentName); 
                        studentHome.Show();
                        this.Hide();
                        break;
                    case "HR":
                        HRHome companyHome = new HRHome();
                        companyHome.Show();
                        this.Hide();
                        break;
                    case "supervisor":
                        frm_UniSupervisorHome uniSupervisorHome = new frm_UniSupervisorHome();
                        uniSupervisorHome.Show();
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show("Invalid user role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // If role is null, show login failed message
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtUsername.Text = String.Empty;
            txtPassword.Text = String.Empty ;   
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
