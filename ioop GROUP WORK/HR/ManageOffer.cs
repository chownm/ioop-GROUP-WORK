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
        public ManageOffer()
        {
            InitializeComponent();
        }

        private void ManageOffer_Load(object sender, EventArgs e)
        {
            List<string> studentNames = MO.GetAllStudentNames();
            cmbStudent.Items.Clear();

            foreach (string name in studentNames)
            {
                cmbStudent.Items.Add(name);
            }


            if (cmbStudent.Items.Count > 0)
            {
                cmbStudent.SelectedIndex = 0;
            }
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
            cbJobTitle.Items.Clear();
            string selectedDept = cbJobTitle.SelectedItem.ToString();
            List<string> positions = MO.AddJobPosition(selectedDept);

            cbJobTitle.Items.AddRange(positions.ToArray());

            if (cbJobTitle.Items.Count > 0)
            {
              cbJobTitle.SelectedIndex = 0;
            }
        }

        private void btnSendOffer_Click(object sender, EventArgs e)
        {

        }
    }
}
