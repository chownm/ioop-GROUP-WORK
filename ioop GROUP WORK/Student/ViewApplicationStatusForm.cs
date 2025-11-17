using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ViewApplicationStatusForm : Form
    {
        private string studentID;
        public ViewApplicationStatusForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
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
                lblJobTitle.Text = row.Cells["Position"].Value.ToString();  // Assuming "Position" column holds job title
                lblPosition.Text = row.Cells["Position"].Value.ToString();
                lblStartDate.Text = row.Cells["StartDate"].Value.ToString();
                lblEndDate.Text = row.Cells["EndDate"].Value.ToString();
                lblAllowance.Text = row.Cells["Allowance"].Value.ToString();  // Assuming the allowance column exists in your table
            }
        }



        private void LoadApplications()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Position, CompanyName, DateApplied, Status FROM StudentApplication WHERE StudentID = @studentID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvApplications.DataSource = dt;  // Bind data to the DataGridView

            }

            dgvApplications.Font = new Font("Times New Roman", 10);
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvApplications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvApplications.ScrollBars = ScrollBars.Both;
        }



        private void ViewApplicationStatusForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadApplications();
        }
    }
}
