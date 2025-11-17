using System;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public partial class UploadResumeForm : Form
    {
        private string internshipPosition;
        private string companyName;
        public UploadResumeForm(string position, string companyName)
        {
            InitializeComponent();
            internshipPosition = position;
            this.companyName = companyName;

            // Set the company name and position fields in the form
            lblCompanyName.Text = companyName; 
            lblPosition.Text = position;

            picPreview.Width = 495;
            picPreview.Height = 700;

            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }





        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            // Open file dialog to select the resume image
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            opd.Title = "Select Resume Image";

            if (opd.ShowDialog() == DialogResult.OK)
            {
                // Validate file extension
                string fileExtension = Path.GetExtension(opd.FileName).ToLower();
                if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                {
                    MessageBox.Show("Please upload a valid image file (JPEG, PNG).", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Exit the method if the file type is invalid
                }

                // Set the PictureBox size to A4 dimensions (portrait size)
                picPreview.Width = 495;  // Set to A4 width (portrait)
                picPreview.Height = 700; // Set to A4 height (portrait)

                // Load the image into the PictureBox
                picPreview.ImageLocation = opd.FileName;

                // Set the PictureBox SizeMode to Zoom to maintain aspect ratio
                picPreview.SizeMode = PictureBoxSizeMode.Zoom;
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
                companyName = GetCompanyNameFromDatabase();

                //Save application to Database
                SaveApplicationToDatabase(txtStuID.Text, txtStuName.Text, position, companyName, imageBytes);

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

                    string query = "SELECT Position FROM InternshipOffer WHERE Position = @Position";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Position", internshipPosition); 

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        position = reader["Position"].ToString();
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



        private string GetCompanyNameFromDatabase()
        {
            string companyName = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    string query = "SELECT CompanyName FROM CompanyProfile WHERE CompanyName IS NOT NULL";

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        companyName = reader["CompanyName"].ToString();
                    }

                    reader.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching company name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return companyName;
        }



        private void SaveApplicationToDatabase(string studentID, string studentName, string position, string companyName, byte[] resumeImage)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                string query = "INSERT INTO StudentApplication (StudentID, StudentName, Position, CompanyName, DateApplied, Status, Resume) " +
                               "VALUES (@StudentID, @StudentName, @Position, @CompanyName, @DateApplied, @Status, @Resume)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@StudentName", studentName);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@CompanyName", companyName);
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
