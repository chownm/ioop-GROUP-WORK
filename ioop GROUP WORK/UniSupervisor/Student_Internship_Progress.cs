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
    public partial class frm_Student_Internship_Progress : Form
    {
        private string studentID;
        private string studentName;
        public frm_Student_Internship_Progress(string id, string name)
        {
            InitializeComponent();
            studentID = id;
            studentName = name;
        }

        private void frm_Student_Internship_Progress_Load(object sender, EventArgs e)
        {
            LoadStudentInternshipProgress();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadStudentInternshipProgress();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Student_Internship_Table frm = new frm_Student_Internship_Table();
            frm.ShowDialog();
        }

        private void LoadStudentInternshipProgress()
        {
            lbl_check_in_percentage.Text = "";
            lbl_student_id.Text = "";
            lbl_student_name.Text = "";
            lbl_student_id.Text = studentID;
            lbl_student_name.Text = studentName;

            Check_Internship_Progress checker = new Check_Internship_Progress(studentID, "", DateTime.Now);

            List<Check_Internship_Progress> records = checker.GetAllCheckInRecord();

            int totalWorkingDays = 20;
            double checkInRate = Check_Internship_Progress.CalculateCheckInPercentage(studentID, DateTime.Now, totalWorkingDays);
            lbl_check_in_percentage.Text = $"{checkInRate} %";


            DataTable dt = new DataTable();
            dt.Columns.Add("Check-In Date");

            foreach (var r in records)
            {
                dt.Rows.Add(r.Check_in_date.ToString("yyyy-MM-dd"));
            }

            dt.Rows.Add($"Monthly Attendance Rate: {checkInRate}%");

            dgv_record_view.DataSource = dt;

            int lastRow = dgv_record_view.Rows.Count - 1;
            var row = dgv_record_view.Rows[lastRow];

            row.DefaultCellStyle.BackColor = Color.LightYellow;
            row.DefaultCellStyle.Font = new Font(dgv_record_view.Font, FontStyle.Bold);
        }

        private void dgv_record_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
