using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ViewCheckInRecordForm : Form
    {
        private string studentID;
        public ViewCheckInRecordForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }



        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void LoadCheckInRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "SELECT checkInDate, studentName " +
                                   "FROM Check_In_Record " +
                                   "WHERE studentID = @studentID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt); 

                    dgvRecords.DataSource = dt; // Bind the DataTable to the DataGridView

                    dgvRecords.Columns[0].HeaderText = "Check-in Date";
                    dgvRecords.Columns[1].HeaderText = "Student Name";

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading check-in records: {ex.Message}");
                }
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
