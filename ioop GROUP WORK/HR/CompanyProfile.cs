using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.HR
{
    public partial class CompanyProfile : Form
    {
        public CompanyProfile()
        {
            InitializeComponent();
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {
            // 如果不需要可留空
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student obj1 = new Student(txtName.Text, txtEmail.Text, txtPhone.Text);
            MessageBox.Show(obj1.addStudent());
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
