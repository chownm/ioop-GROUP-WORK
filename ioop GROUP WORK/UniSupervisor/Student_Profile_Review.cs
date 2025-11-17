using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public partial class frm_Student_Profile_Review : Form
    {
        private string studentID;
        private string studentName;
        private string email;
        private string phone_number;
        private string course;

        public frm_Student_Profile_Review(string id, string name, string email, string phone_number, string course)
        {
            InitializeComponent();
            studentID = id;
            studentName = name;
            this.email = email;
            this.phone_number = phone_number;
            this.course = course;

            LoadStudentProfileDetails();
        }



        private void frm_Student_Profile_Review_Load(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadStudentProfileDetails();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Student_Table frm = new frm_Student_Table();
            frm.ShowDialog();
        }

        private void LoadStudentProfileDetails()
        {
            lbl_student_id.Text = studentID;
            lbl_name.Text = studentName;
            lbl_email.Text = email;
            lbl_phoneNumber.Text = phone_number;
            lbl_course.Text = course;
        }
    }
}