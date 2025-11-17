using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentReportUploadForm : Form
    {
        private string studentID;
        private string filePath;

        public StudentReportUploadForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }

        private void StudentReportUploadForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                lblFileName.Text = System.IO.Path.GetFileName(filePath);
                
                picPreview.Image = Image.FromFile(filePath);
                picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))  // Check if no file is selected
            {
                MessageBox.Show("Please select an image to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            try
            {
                byte[] fileData = File.ReadAllBytes(filePath); 

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"INSERT INTO Student_Reports (studentID, Report, uploadDate)
                                     VALUES (@studentID, @Report, @uploadDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);  
                    cmd.Parameters.AddWithValue("@Report", fileData); 
                    cmd.Parameters.AddWithValue("@uploadDate", DateTime.Now);  

                    int result = cmd.ExecuteNonQuery(); 

                    if (result > 0)
                    {
                        MessageBox.Show("✅ Report uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("❌ Report upload failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❗ Error during file upload: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
