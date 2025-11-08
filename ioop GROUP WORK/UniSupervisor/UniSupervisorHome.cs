using ioop_GROUP_WORK.UniSupervisor;
using System;
using System.Collections;
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
    public partial class UniSupervisorHome : Form
    {
        View_Student_Profile student;
        public UniSupervisorHome()
        {
            InitializeComponent();
        }

        private void UniSupervisorHome_Load(object sender, EventArgs e)
        {
            
        }

        private void lst_Student_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_Student_Details();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (lst_Student_List.SelectedItem == null)
            {
                MessageBox.Show("Please select a student profile to review.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Student_Profile_Review profile = new Student_Profile_Review();
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {

        }

        private void Show_Student_Details()
        {
            lst_Student_List.Items.Clear();         // Clear existing items before adding new ones
            string student_id = ""; 
            string student_name ="";
            string email = "";
            string phone_number = "";
            string course_name = "";
            ArrayList student_details = View_Student_Profile.Get_Student_Details(student_id, student_name, email, phone_number, course_name);
            foreach (string details in student_details)
            {
                lst_Student_List.Items.Add(details);        // Add each student detail to the ListBox
            }
        }
    }
}
