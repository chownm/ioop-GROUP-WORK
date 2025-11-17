using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ioop_GROUP_WORK.Student
{
    public partial class InternshipListForm : Form
    {
        private string studentID;

        public InternshipListForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }

        private void InternshipListForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            // Load internship offers from the database and display them
            LoadInternshipOffers();

            // Ensure the DataGridView resizes with the form
            dgvIntern.Font = new Font("Times New Roman", 10);
            dgvIntern.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIntern.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvIntern.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIntern.ScrollBars = ScrollBars.Both;
        }

        private void LoadInternshipOffers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // SQL query to load internship offers, ensure JobTitle comes before Position
                string query = @"SELECT io.Id AS InternshipID, 
                                        io.JobTitle,  -- JobTitle is now first
                                        io.Position,  -- Position follows
                                        io.StartDate, 
                                        io.EndDate, 
                                        io.Salary AS Allowance, 
                                        io.CompanyName
                                 FROM InternshipOffer io";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable internshipTable = new DataTable();
                da.Fill(internshipTable);
                dgvIntern.DataSource = internshipTable;

                // Optionally, customize column headers
                dgvIntern.Columns["InternshipID"].HeaderText = "Internship ID";
                dgvIntern.Columns["JobTitle"].HeaderText = "Job Title"; // JobTitle is now first
                dgvIntern.Columns["Position"].HeaderText = "Position";  // Position comes second
                dgvIntern.Columns["StartDate"].HeaderText = "Start Date";
                dgvIntern.Columns["EndDate"].HeaderText = "End Date";
                dgvIntern.Columns["Allowance"].HeaderText = "Salary";
                dgvIntern.Columns["CompanyName"].HeaderText = "Company Name";

                dgvIntern.ReadOnly = true;
            }
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

                // Get the necessary details from the selected row
                string internshipId = dgvIntern.Rows[selectedRowIndex].Cells["InternshipID"].Value.ToString();
                string jobTitle = dgvIntern.Rows[selectedRowIndex].Cells["JobTitle"].Value.ToString();
                string position = dgvIntern.Rows[selectedRowIndex].Cells["Position"].Value.ToString();
                string companyName = dgvIntern.Rows[selectedRowIndex].Cells["CompanyName"].Value.ToString();
                string startDate = dgvIntern.Rows[selectedRowIndex].Cells["StartDate"].Value.ToString();
                string endDate = dgvIntern.Rows[selectedRowIndex].Cells["EndDate"].Value.ToString();
                string salary = dgvIntern.Rows[selectedRowIndex].Cells["Allowance"].Value.ToString();

                MessageBox.Show($"You have applied for {jobTitle} at {companyName}.\n" +
                                $"Position: {position}\nStart Date: {startDate}\nEnd Date: {endDate}\nSalary: {salary}",
                                "Application Details");

                // Pass JobTitle and Company Name to UploadResumeForm
                UploadResumeForm uploadForm = new UploadResumeForm(jobTitle, companyName);
                uploadForm.ShowDialog();
                this.Close();
            }
            else
            {
                // Show an error message if no row is selected
                MessageBox.Show("Please select an internship before applying.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
