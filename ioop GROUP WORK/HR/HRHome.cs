using ioop_GROUP_WORK.HR;
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
    public partial class HRHome : Form
    {
        public HRHome()
        {
            InitializeComponent();
        }

        private void HRHome_Load(object sender, EventArgs e)
        {

        }

        private void btnViewApplications_Click(object sender, EventArgs e)
        {
            ViewApplication vp = new ViewApplication();
               vp.Show();
               this.Hide();
        }
    }
}
