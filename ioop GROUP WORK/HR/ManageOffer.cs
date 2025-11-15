using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ioop_GROUP_WORK.HR
{
    public partial class ManageOffer : Form
    {
        private PersonalProfile PP;
        public ManageOffer()
        {
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
            cmbJobTitle.Items.Clear();
            string selectedDept = cmbJobTitle.SelectedItem.ToString();
            List<string> positions = MO.AddJobPosition(selectedDept);

            cmbJobTitle.Items.AddRange(positions.ToArray());

            if (cmbJobTitle.Items.Count > 0)
            {
              cmbJobTitle.SelectedIndex = 0;
            }
        }

        private void btnSendOffer_Click(object sender, EventArgs e)
        {
            string name = PP.getname();
            string password = PP.getpassword();

            CP company = new CP(name, password);
            string Cname = company.Companyname;

            double salary = double.Parse(txtSalary.Text);
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
            HRHome back = new HRHome();
            this.Close();
            back.ShowDialog();
        }
    }
}
