using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

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
        }



        private void LoadIntershipOffers()
        {
            // Code to load internship offers from the database and display them in the DataGridView
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT InternshipID, Position, Company, StartDate, EndDate, Allowance FROM InternshipOffer";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Clear existing data and display internship in DataGridView
                dgvIntern.Rows.Clear();

                while (reader.Read())
                {
                    int rowIndex = dgvIntern.Rows.Add();
                    dgvIntern.Rows[rowIndex].Cells["InternshipID"].Value = reader["InternshipID"];
                    dgvIntern.Rows[rowIndex].Cells["Position"].Value = reader["Position"];
                    dgvIntern.Rows[rowIndex].Cells["Company"].Value = reader["Company"];
                    dgvIntern.Rows[rowIndex].Cells["StartDate"].Value = reader["StartDate"];
                    dgvIntern.Rows[rowIndex].Cells["EndDate"].Value = reader["EndDate"];
                    dgvIntern.Rows[rowIndex].Cells["Allowance"].Value = reader["Allowance"];
                }

                reader.Close();
                con.Close();
            }
        }



        private void btnResume_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dgvIntern.SelectedCells[0].RowIndex;
            string position = dgvIntern.Rows[selectedRowIndex].Cells["Position"].Value.ToString();

            //Pass the selected position to UploadResumeForm
            UploadResumeForm uploadForm = new UploadResumeForm(position);
            uploadForm.ShowDialog();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
