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
            string stat ;
            User obj1 = new User(txtUsername.Text, txtPassword.Text);
            stat = obj1.login();
            if(stat != null)
            {
                switch(stat)
                {
                    case "admin":
                        AdminHome adminHome = new AdminHome();
                        adminHome.Show();
                        this.Hide();
                        break;
                    case "student":
                        StudentHomeForm studentHome = new StudentHomeForm();
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
            txtUsername.Text = String.Empty;
            txtUsername.Text = String.Empty ;   
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
