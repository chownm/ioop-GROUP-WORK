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
            Identify = identify ?? "";
            Password = password ?? "";
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1?.SelectedItem != null)
                {
                    string selectedStudent = comboBox1.SelectedItem.ToString() ?? "";
                    if (!string.IsNullOrEmpty(selectedStudent))
                    {
                        VP ac = new VP(selectedStudent);
                        string result = ac.Reject();
                        MessageBox.Show(result ?? "Operation completed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student from the list.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1?.SelectedItem != null)
                {
                    string selectedStudent = comboBox1.SelectedItem.ToString() ?? "";
                    if (!string.IsNullOrEmpty(selectedStudent))
                    {
                        VP ac = new VP(selectedStudent);
                        string result = ac.Accept();
                        MessageBox.Show(result ?? "Operation completed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student from the list.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1?.SelectedItem != null)
                {
                    string selectedStudent = comboBox1.SelectedItem.ToString() ?? "";
                    if (!string.IsNullOrEmpty(selectedStudent))
                    {
                        VP vp = new VP(selectedStudent);
                        VP student = vp.ViewProfile();

                        if (student != null)
                        {
                            lstApplicationDetails?.Items.Clear();
                            lstApplicationDetails?.Items.Add("Name: " + (student.StudentName ?? ""));
                            lstApplicationDetails?.Items.Add("Position: " + (student.Position ?? ""));
                            lstApplicationDetails?.Items.Add("Date Applied: " + student.DateApplied);
                            lstApplicationDetails?.Items.Add("Status: " + (student.Status ?? ""));
                        }
                        else
                        {
                            MessageBox.Show("Student profile not found.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student from the list.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                HRHome back = new HRHome(Identify, Password);
                back.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
            try
            {
                List<string> studentNames = VP.GetAllStudentNames(Identify, Password);
                
                if (comboBox1 != null)
                {
                    comboBox1.Items.Clear();

                    if (studentNames != null)
                    {
                        foreach (string name in studentNames)
                        {
                            if (!string.IsNullOrEmpty(name))
                                comboBox1.Items.Add(name);
                        }
                    }

                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application data: " + ex.Message);
            }
        }
    }
}
