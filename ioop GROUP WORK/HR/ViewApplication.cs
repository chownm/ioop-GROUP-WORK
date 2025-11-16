using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ioop_GROUP_WORK.HR
{
    public partial class ViewApplication : Form
    {
        private string Identify;
        private string Password;
        public ViewApplication(string identify, string password)
        {
            Identify = identify;
            Password = password;
            InitializeComponent();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedStudent = comboBox1.SelectedItem.ToString();
                VP ac = new VP(selectedStudent);
                MessageBox.Show(ac.Reject());
            }
            else
            {
                MessageBox.Show("Please select a student from the list.");

            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem != null)
            {
                string selectedStudent = comboBox1.SelectedItem.ToString();
                VP ac = new VP(selectedStudent);
                MessageBox.Show(ac.Accept());

             }
            else
            {
                MessageBox.Show("Please select a student from the list.");

            }
        }
            

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {              
                string selectedStudent = comboBox1.SelectedItem.ToString();

                VP vp = new VP(selectedStudent);
                VP student = vp.ViewProfile();

                lstApplicationDetails.Items.Clear();
                lstApplicationDetails.Items.Add("Name: " + student.StudentName);
                lstApplicationDetails.Items.Add("Position: " + student.Position);
                lstApplicationDetails.Items.Add("Date Applied: " + student.DateApplied);
                lstApplicationDetails.Items.Add("Status: " + student.Status);
            }
            else
            {
                MessageBox.Show("Please select a student from the list.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HRHome back = new HRHome();
            back.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSelectStudent_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ViewApplication_Load(object sender, EventArgs e)
        {
            List<string> studentNames = VP.GetAllStudentNames(Identify,Password);
            comboBox1.Items.Clear();

            foreach (string name in studentNames)
            {
                comboBox1.Items.Add(name);
            }


            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
