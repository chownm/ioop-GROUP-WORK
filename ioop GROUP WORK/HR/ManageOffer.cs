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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ioop_GROUP_WORK.HR
{
    public partial class ManageOffer : Form
    {
        private string Identify;
        private string Password;
        public ManageOffer(string identify, string password)
        {
            Identify = identify;
            Password = password;
            InitializeComponent();
        }

        private void ManageOffer_Load(object sender, EventArgs e)
        {
            
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblStudent_Click(object sender, EventArgs e)
        {

        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            
        }

        private void cbJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guard against null selection
            if (cmbJobTitle.SelectedItem == null) return;

            string selectedDept = cmbJobTitle.SelectedItem.ToString();
            List<string> positions = MO.AddJobPosition(selectedDept);
            

            cmbPosition.Items.AddRange(positions.ToArray());

            if (cmbJobTitle.Items.Count > 0)
            {
              cmbJobTitle.SelectedIndex = 0;
            }
        }

        private void btnSendOffer_Click(object sender, EventArgs e)
        {
            PersonalProfile PP = new PersonalProfile(Identify, Password);
            string name = PP.getname();
            string password = PP.getpassword();

            CP company = new CP(name, password);
            string Cname = company.Companyname;

            double salary = 0;
            double.TryParse(txtSalary.Text, out salary);
            try
            {
                if (cmbJobTitle.SelectedItem == null || cmbPosition.SelectedItem == null)
                {
                    MessageBox.Show("Please select all fields before sending.");
                    return;
                }

                MO mo = new MO(
                    cmbJobTitle.SelectedItem.ToString(),
                    cmbPosition.SelectedItem.ToString(),
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    salary,
                    rtbDescription.Text);
                                
                string result = mo.SendApplication(Cname);
                    

                MessageBox.Show(result);
                clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
                
        private void clear()
        {
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtSalary.Clear();
            rtbDescription.Clear();
            cmbJobTitle.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            HRHome back = new HRHome(Identify, Password);
            this.Close();
            back.ShowDialog();
        }
    }
}
