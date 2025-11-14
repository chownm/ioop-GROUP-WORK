using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public partial class frm_Evaluation_From : Form
    {
        public frm_Evaluation_From()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frm_Evaluation_From_Load(object sender, EventArgs e)
        {
            ShowStudentDetails();
            cmb_studentName_studentID.SelectedIndex = -1;
            cmb_position.SelectedIndex = -1;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmb_studentName_studentID.SelectedItem == null)
                {
                    ClearForm();
                    MessageBox.Show("Please select a student.", "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Internship_Evaluation selectedStudent = cmb_studentName_studentID.SelectedItem as Internship_Evaluation;
                string studentID = selectedStudent.Student_id;
                string studentName = selectedStudent.Student_name;
                string position = cmb_position.SelectedItem.ToString();
                DateTime evaldate = dtp_datetime.Value;
                double performance = double.Parse(txt_performance_mark.Text);
                double communication = double.Parse(txt_communication_mark.Text);
                double punctuality = double.Parse(txt_punctuality_mark.Text);
                string description = rtxt_descriptions.Text;

                // Validate position
                if (cmb_position.SelectedItem == null)
                {
                    ClearForm();
                    MessageBox.Show("Please select a position.", "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validate performance mark
                if (!double.TryParse(txt_performance_mark.Text, out performance) || performance > 100.00 || performance < 0.00)
                {
                    ClearForm();
                    MessageBox.Show("Invalid performance mark.", "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validate communication mark
                if (!double.TryParse(txt_communication_mark.Text, out communication) || communication > 100.00 || communication < 0.00)
                {
                    ClearForm();
                    MessageBox.Show("Invalid communication mark.", "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validate punctuality mark
                if (!double.TryParse(txt_punctuality_mark.Text, out punctuality) || punctuality > 100.00 || punctuality < 0.00)
                {
                    ClearForm();
                    MessageBox.Show("Invalid punctuality mark.", "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validate evaluation date
                if (dtp_datetime.Value == null)
                {
                    ClearForm();
                    MessageBox.Show("Please select a valid evaluation date.", "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Continue with submission if all validations pass
                Internship_Evaluation eval = new Internship_Evaluation(
                        student_name: studentName,
                        student_id: studentID,
                        position: position,
                        evaluation_date: DateTime.Now,
                        performance_rating: performance,
                        communication_skills_rating: communication,
                        punctuality_rating: punctuality,
                        description: description
                );

                eval.InsertEvaluationsRecord();
                MessageBox.Show("Evaluation submitted successfully!", "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_UniSupervisorHome uniSupervisorHome = new frm_UniSupervisorHome();
            uniSupervisorHome.ShowDialog();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            ShowStudentDetails();
        }

        private void ShowStudentDetails()
        { 
            List<Internship_Evaluation> students = Internship_Evaluation.GetStudentName();
            cmb_studentName_studentID.DataSource = null;
            cmb_studentName_studentID.DataSource = students;
            cmb_studentName_studentID.DisplayMember = "Display_Student_Name";
            cmb_studentName_studentID.ValueMember = "student_id";

        }

        private void ClearForm()
        {
            cmb_studentName_studentID.SelectedItem = null;
            cmb_position.SelectedItem = null;
            dtp_datetime.Value = DateTime.Now;
            rtxt_descriptions.Clear();
            txt_communication_mark.Clear();
            txt_punctuality_mark.Clear();
            txt_performance_mark.Clear();
        }
    }   
}
