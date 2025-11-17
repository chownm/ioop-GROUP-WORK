using System;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentCheckInForm : Form
    {
        private string studentID;
        private string studentName;
        private StudentCheckIn checkInLogic;

        public StudentCheckInForm(string studentID, string studentName)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.studentName = studentName;
            checkInLogic = new StudentCheckIn();
        }



        private void StudentCheckInForm_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = studentName;
            lblStudentID.Text = studentID;
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }



        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string resultMessage = checkInLogic.CheckIn(studentID, studentName);

            MessageBox.Show(resultMessage, "Check-in Status", MessageBoxButtons.OK, resultMessage.Contains("successful") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (resultMessage.Contains("successful"))
            {
                btnCheckIn.Enabled = false;

                ViewCheckInRecordForm viewCheckIn = new ViewCheckInRecordForm(studentID);
                viewCheckIn.ShowDialog();

                this.Close();
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
