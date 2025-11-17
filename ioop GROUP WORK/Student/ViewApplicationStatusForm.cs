using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ViewApplicationStatusForm : Form
    {
        private string studentID;
        private ViewApplicationStatus applicationStatusLogic;

        public ViewApplicationStatusForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            applicationStatusLogic = new ViewApplicationStatus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Ensure a valid row is selected
            {
                // Get the selected row
                DataGridViewRow row = dgvApplications.Rows[e.RowIndex];

                // Populate the labels with data from the selected row
                lblCompanyName.Text = row.Cells["CompanyName"].Value.ToString() ?? "N/A";
                lblPosition.Text = row.Cells["Position"].Value.ToString() ?? "N/A";
                lblStartDate.Text = row.Cells["StartDate"].Value.ToString() ?? "N/A";
                lblEndDate.Text = row.Cells["EndDate"].Value.ToString() ?? "N/A";
                lblAllowance.Text = row.Cells["Allowance"].Value.ToString() ?? "N/A";
            }
            else
            {
                lblCompanyName.Text = "N/A";
                lblPosition.Text = "N/A";
                lblStartDate.Text = "N/A";
                lblEndDate.Text = "N/A";
                lblAllowance.Text = "N/A";
            }
        }

        private void LoadApplications()
        {
            // Get application data from ViewApplicationStatus logic class
            DataTable applicationData = applicationStatusLogic.GetApplicationStatus(studentID);

            // Bind the data to the DataGridView
            dgvApplications.DataSource = applicationData;
            dgvApplications.ReadOnly = true;

            // Optionally, customize column headers
            dgvApplications.Columns["Position"].HeaderText = "Position";
            dgvApplications.Columns["JobTitle"].HeaderText = "Job Title";
            dgvApplications.Columns["StartDate"].HeaderText = "Start Date";
            dgvApplications.Columns["EndDate"].HeaderText = "End Date";
            dgvApplications.Columns["Allowance"].HeaderText = "Allowance";
            dgvApplications.Columns["CompanyName"].HeaderText = "Company Name";
        }

        private void ViewApplicationStatusForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadApplications();

            // Customize DataGridView settings
            dgvApplications.Font = new Font("Times New Roman", 10);
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvApplications.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvApplications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvApplications.ScrollBars = ScrollBars.Both;
        }
    }
}
