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
    public partial class AdminHome : Form
    {
        public static string name;

        public AdminHome(string n)
        {
            InitializeComponent();
            name = n;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            lblidentity.Text = $"Hello, {name}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent ad = new AddStudent();
            ad.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewStudent vs = new ViewStudent();
            vs.ShowDialog();
        }
    }
}
