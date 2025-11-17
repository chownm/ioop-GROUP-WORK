using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ViewFeedbackForm : Form
    {
        private string studentID;
        public ViewFeedbackForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewFeedbackForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadEvaluationReport();
            dgvFeedback.Font = new Font("Times New Roman", 10);
            dgvFeedback.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFeedback.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvFeedback.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFeedback.ScrollBars = ScrollBars.Both;
        }

        private void LoadEvaluationReport()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    // Query to fetch student's evaluation data
                    string query = "SELECT Position, Performance, CommunicationSkills, Punctuality, Description FROM Student_Evaluation_Report WHERE studentID = @studentID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID); // Pass the studentID to fetch their evaluation report

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt); // Fill the DataTable with the fetched data

                    // Bind the DataTable to the DataGridView
                    dgvFeedback.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading evaluation report: {ex.Message}");
                }
            }
        }
    }
}
