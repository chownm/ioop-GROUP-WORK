using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class InternshipListForm : Form
    {
        public InternshipListForm()
        {
            InitializeComponent();
        }



        private void InternshipListForm_Load(object sender, EventArgs e)
        {
            LoadIntershipOffers();
            // Ensure the DataGridView resizes with the form
            dgvIntern.Font = new Font("Times New Roman", 10);
            dgvIntern.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIntern.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvIntern.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIntern.ScrollBars = ScrollBars.Both;
        }



        private void LoadIntershipOffers()
        {
            // Code to load internship offers from the database and display them in the DataGridView
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Define the columns if they are not already defined in the designer
                dgvIntern.Columns.Add("InternshipID", "Internship ID");
                dgvIntern.Columns.Add("Position", "Position");
                dgvIntern.Columns.Add("Company", "Company Name");
                dgvIntern.Columns.Add("StartDate", "Start Date");
                dgvIntern.Columns.Add("EndDate", "End Date");
                dgvIntern.Columns.Add("Allowance", "Salary");

                string query = "SELECT Id, JobTitle, Position, StartDate, EndDate, Salary, CompanyName FROM InternshipOffer";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                // Clear existing data and display internship in DataGridView
                dgvIntern.Rows.Clear();

                while (reader.Read())
                {
                    int rowIndex = dgvIntern.Rows.Add();
                    // Map cells to existing columns in the grid (ensure grid has these column names)
                    dgvIntern.Rows[rowIndex].Cells["InternshipID"].Value = reader["Id"];
                    dgvIntern.Rows[rowIndex].Cells["Position"].Value = reader["Position"];
                    dgvIntern.Rows[rowIndex].Cells["Company"].Value = reader["CompanyName"];
                    dgvIntern.Rows[rowIndex].Cells["StartDate"].Value = reader["StartDate"];
                    dgvIntern.Rows[rowIndex].Cells["EndDate"].Value = reader["EndDate"];
                    dgvIntern.Rows[rowIndex].Cells["Allowance"].Value = reader["Salary"];
                }

                reader.Close();
                con.Close();
            }
        }



        private void lblStatus_Click(object sender, EventArgs e)
        {

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

                // Get the necessary details
                string internshipId = dgvIntern.Rows[selectedRowIndex].Cells["InternshipID"].Value.ToString();
                string position = dgvIntern.Rows[selectedRowIndex].Cells["Position"].Value.ToString();
                string companyName = dgvIntern.Rows[selectedRowIndex].Cells["Company"].Value.ToString();
                string startDate = dgvIntern.Rows[selectedRowIndex].Cells["StartDate"].Value.ToString();
                string endDate = dgvIntern.Rows[selectedRowIndex].Cells["EndDate"].Value.ToString();
                string salary = dgvIntern.Rows[selectedRowIndex].Cells["Allowance"].Value.ToString();

                MessageBox.Show($"You have applied for {position} at {companyName}.\n" +
                                $"Start Date: {startDate}\nEnd Date: {endDate}\nSalary: {salary}",
                                "Application Details");

                // Pass Position and Company Name to UploadResumeForm
                UploadResumeForm uploadForm = new UploadResumeForm(position, companyName);
                uploadForm.ShowDialog();
            }
            else
            {
                // Show an error message if no row is selected
                MessageBox.Show("Please select an internship before applying.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
