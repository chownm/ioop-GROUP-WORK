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
            try
            {
                string username = txtUsername?.Text?.Trim() ?? "";
                string password = txtPassword?.Text?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter username and password.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string role = null;
                string studentName = null;

                // Create a User object with the username and password entered
                User obj1 = new User(username, password);

                // Get the role and student name from the login method
                (role, studentName) = obj1.login();

                // If the role is valid, navigate to the appropriate home form
                if (!string.IsNullOrEmpty(role))
                {
                    switch (role.ToLower())
                    {
                        case "admin":
                            AdminHome adminHome = new AdminHome();
                            adminHome.Show();
                            this.Hide();
                            break;
                        case "student":
                            StudentHomeForm studentHome = new StudentHomeForm(username, studentName ?? "");
                            studentHome.Show();
                            this.Hide();
                            break;
                        case "hr":
                            HRHome companyHome = new HRHome(username, password);
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
                    // If role is null or empty, show login failed message
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clear text fields
                if (txtUsername != null) txtUsername.Text = String.Empty;
                if (txtPassword != null) txtPassword.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load_1(object sender, EventArgs e)
        {

        }
    }
}