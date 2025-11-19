using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK.UniSupervisor;


namespace ioop_GROUP_WORK.UniSupervisor
{
    public partial class frm_Student_Table : Form
    {
        public frm_Student_Table()
        {
            InitializeComponent();
        }

        private void frm_Student_Table_Load(object sender, EventArgs e)
        {
            Show_Student_Details();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (lst_Student_Details.SelectedItem == null)
            {
                MessageBox.Show("Please select a student from the list.");
                return;
            }

            View_Student_Profile selectedStudent = lst_Student_Details.SelectedItem as View_Student_Profile;

            frm_Student_Profile_Review frm = new frm_Student_Profile_Review(
                selectedStudent.Student_id,
                selectedStudent.Student_name,
                selectedStudent.Email,
                selectedStudent.Phone_number,
                selectedStudent.Course
            );

            frm.ShowDialog();
        }   

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Show_Student_Details();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_UniSupervisorHome frm = new frm_UniSupervisorHome();
            frm.ShowDialog();
        }

        private void Show_Student_Details()
        {
            lst_Student_Details.DataSource = null;
            var students = View_Student_Profile.GetAllStudent();

            lst_Student_Details.DataSource = students;
            lst_Student_Details.DisplayMember = "DisplayStudentInfo";  
            lst_Student_Details.ValueMember = "Student_id";            
        }

        private void lst_Student_Details_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}