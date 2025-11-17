using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.HR
{
    
    public partial class PersonalProfileForm : Form
    {
        private string Identify;
        private string Password;
        public PersonalProfileForm(string identify, string password)
        {
             Identify = identify;
             Password = password;
            InitializeComponent();
        }

        private void PersonalProfileForm_Load(object sender, EventArgs e)
        {
            PersonalProfile pp = new PersonalProfile(Identify, Password);
            txtUsername.Text = pp.getprofilename();
            txtPassword.Text = pp.getpassword();
            txtEmail.Text = pp.getemail();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HRHome back = new HRHome(Identify,Password);
            this.Close();
            back.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PersonalProfile pp = new PersonalProfile(Identify, Password);
            LoginPage back = new LoginPage();
            MessageBox.Show(pp.UpdatePersonalProfile(txtUsername.Text, txtPassword.Text, txtEmail.Text));
            Clear();

            this.Close();
            back.ShowDialog();
            MessageBox.Show("Pls Login Again");
            
            

        }

        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtUsername.Focus();
        }
    }
}
