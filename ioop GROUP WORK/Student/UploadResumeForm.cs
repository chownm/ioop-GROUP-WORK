using System;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public partial class UploadResumeForm : Form
    {
        public UploadResumeForm()
        {
            InitializeComponent();
        }

        

        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            opd.Title = "Select Resume Image";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                picPreview.ImageLocation = opd.FileName;
            }
        }



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStuName.Text) || string.IsNullOrEmpty(txtStuID.Text))
            {
                MessageBox.Show("Please enter both Student Name and Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(picPreview.ImageLocation))
            {
                MessageBox.Show("Please upload a Resume Image before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //Convert Image to Binary Data
                byte[] imageBytes = File.ReadAllBytes(picPreview.ImageLocation);

                //Fetch postition from InternshipOffer table
                string position = GetPositionFromDatabase();

                //Save application to Database
                SaveApplicationToDatabase(txtStuID.Text, txtStuName.Text, position, imageBytes);

                MessageBox.Show("Application submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string GetPositionFromDatabase()
        {
            string position = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    string query = "SELECT Position FROM InternshipOffer WHERE PositionID = @PositionID";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PositionID", 1);  // Example: Replace with actual PositionID from your form or logic

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        position = reader["Position"].ToString();  // Store the Position from the table
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return position;
        }



        private void SaveApplicationToDatabase(string studentID, string studentName, string position, byte[] resumeImage)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                string query = "INSERT INTO StudentApplication (StudentID, StudentName, Position, DateApplied, Status, Resume) " +
                               "VALUES (@StudentID, @StudentName, @Position, @DateApplied, @Status, @Resume)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", studentID);  
                cmd.Parameters.AddWithValue("@StudentName", studentName); 
                cmd.Parameters.AddWithValue("@Position", position); 
                cmd.Parameters.AddWithValue("@DateApplied", DateTime.Now);
                cmd.Parameters.AddWithValue("@Status", "Pending"); 
                cmd.Parameters.AddWithValue("@Resume", resumeImage);  
                con.Open();
                cmd.ExecuteNonQuery();  // Execute the insert query
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void UploadReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
