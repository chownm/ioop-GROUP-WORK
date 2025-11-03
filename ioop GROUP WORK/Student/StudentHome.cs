using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK
{
    public partial class StudentHome : Form
    {
        public static string name;
        public StudentHome(string n)
        {
            InitializeComponent();
            name = n;
        }

        private void StudentHome_Load(object sender, EventArgs e)
        {
            Student obj1 = new Student(name);
            Student.viewProfile(obj1);

            txtEmail.Text = obj1.Email;
            txtPhone.Text = obj1.PhoneNum;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student obj1 = new Student(name);
            MessageBox.Show(obj1.updateProfile(txtEmail.Text, txtPhone.Text));
        }
    }
}
