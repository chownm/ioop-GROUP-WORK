using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ViewCheckInRecordForm : Form
    {
        private string studentID;
        private ViewCheckInRecord checkInRecordLogic;

        public ViewCheckInRecordForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.checkInRecordLogic = new ViewCheckInRecord();
        }



        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void LoadCheckInRecords()
        {
            try
            {
                DataTable checkInRecords = checkInRecordLogic.GetCheckInRecords(studentID);

                // Bind the data to the DataGridView
                dgvRecords.DataSource = checkInRecords;

                dgvRecords.Columns[0].HeaderText = "Check-in Date";
                dgvRecords.Columns[1].HeaderText = "Student Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading check-in records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ViewCheckInRecordForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCheckInRecords();

            dgvRecords.Font = new Font("Times New Roman", 14);
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvRecords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRecords.ScrollBars = ScrollBars.Both;
            dgvRecords.ReadOnly = true;
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;
        }
    }
}
