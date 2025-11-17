using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public partial class InternshipListForm : Form
    {
        private string studentID;
        private InternshipList internshipList; 

        public InternshipListForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.internshipList = new InternshipList(); 
        }



        private void InternshipListForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadInternshipOffers();

            dgvIntern.Font = new Font("Times New Roman", 10);
            dgvIntern.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIntern.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvIntern.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIntern.ScrollBars = ScrollBars.Both;
        }



        private void LoadInternshipOffers()
        {
            DataTable internshipTable = internshipList.LoadInternshipOffers();
            dgvIntern.DataSource = internshipTable;

            dgvIntern.Columns["InternshipID"].HeaderText = "Internship ID";
            dgvIntern.Columns["Position"].HeaderText = "Position";
            dgvIntern.Columns["JobTitle"].HeaderText = "Job Title";
            dgvIntern.Columns["StartDate"].HeaderText = "Start Date";
            dgvIntern.Columns["EndDate"].HeaderText = "End Date";
            dgvIntern.Columns["Allowance"].HeaderText = "Salary";
            dgvIntern.Columns["CompanyName"].HeaderText = "Company Name";

            dgvIntern.ReadOnly = true;
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvIntern.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvIntern.SelectedRows[0].Index;

                string internshipId = dgvIntern.Rows[selectedRowIndex].Cells["InternshipID"].Value.ToString();
                string position = dgvIntern.Rows[selectedRowIndex].Cells["Position"].Value.ToString();
                string companyName = dgvIntern.Rows[selectedRowIndex].Cells["CompanyName"].Value.ToString();
                string startDate = dgvIntern.Rows[selectedRowIndex].Cells["StartDate"].Value.ToString();
                string endDate = dgvIntern.Rows[selectedRowIndex].Cells["EndDate"].Value.ToString();
                string salary = dgvIntern.Rows[selectedRowIndex].Cells["Allowance"].Value.ToString();

                string applicationResult = internshipList.ApplyForInternship(internshipId, position, companyName, startDate, endDate, salary);

                MessageBox.Show(applicationResult, "Application Details");

                // Pass Position and Company Name to UploadResumeForm
                UploadResumeForm uploadForm = new UploadResumeForm(position, companyName);
                uploadForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an internship before applying.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
