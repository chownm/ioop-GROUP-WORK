using ioop_GROUP_WORK.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK
{
    public partial class HRHome : Form
    {
                        
        public HRHome(string userIdentity, string password)
        {
            PersonalProfile PP = new PersonalProfile(userIdentity, password);
            InitializeComponent();
        }

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
            this.Close();
            vp.ShowDialog();
               
        }

        private void btnCompanyProfile_Click(object sender, EventArgs e)
        {
            CompanyProfile cp = new CompanyProfile();
            this.Close();
            cp.ShowDialog();
        }

        private void btnManageOffers_Click(object sender, EventArgs e)
        {
            ManageOffer mo = new ManageOffer();
            this.Close();
            mo.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonalProfile_Click(object sender, EventArgs e)
        {
            PersonalProfileForm pp = new PersonalProfileForm();
            this.Close();
            pp.ShowDialog();
        }
    }
}
