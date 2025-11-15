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
    public partial class frm_Student_Internship_Table : Form
    {
        public frm_Student_Internship_Table()
        {
            InitializeComponent();
        }

        private void cmb_student_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_student_id.SelectedItem != null)
            {
                Internship_Evaluation selectedStudent = cmb_student_id.SelectedItem as Internship_Evaluation;
                lbl_student_name.Text = selectedStudent.Student_name;
            }
            else
            {
                lbl_student_name.Text = "";
            }
        }

        private void btn_select_Click(object sender, EventArgs e)       // Select Button
        {

        }

        private void button2_Click(object sender, EventArgs e)      // Refresh Button
        {
            ShowStudentDetails();
        }

        private void button3_Click(object sender, EventArgs e)      // Exit Button
        {

        }

        private void ShowStudentDetails()
        {
            List<Internship_Evaluation> students = Internship_Evaluation.GetStudentName();
            cmb_student_id.Items.Clear();
            lbl_student_name.Text = "";
            cmb_student_id.DataSource = null;
            cmb_student_id.DataSource = students;
            cmb_student_id.DisplayMember = "Display_Student_Name";
            cmb_student_id.ValueMember = "student_id";
        }

        private void frm_Student_Internship_Table_Load(object sender, EventArgs e)
        {
            ShowStudentDetails();
        }
    }
}
