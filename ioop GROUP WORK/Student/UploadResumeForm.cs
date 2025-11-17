using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class UploadResumeForm : Form
    {
        private string internshipPosition;
        private string companyName;
        private UploadResume uploadResumeLogic;
        private string filePath;

        public UploadResumeForm(string position, string companyName)
        {
            InitializeComponent();
            internshipPosition = position;
            this.companyName = companyName;
            uploadResumeLogic = new UploadResume();

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
                picPreview.Width = 495;  // Set to A4 width
                picPreview.Height = 700; // Set to A4 height

                // Load the image into the PictureBox
                picPreview.ImageLocation = opd.FileName;
                filePath = opd.FileName;

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

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please upload a Resume Image before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Convert Image to Binary Data
                byte[] imageBytes = File.ReadAllBytes(filePath);

                // Fetch position from InternshipOffer table
                string position = uploadResumeLogic.GetPositionFromDatabase(internshipPosition);
                companyName = uploadResumeLogic.GetCompanyNameFromDatabase();

                // Save application to Database
                string result = uploadResumeLogic.SaveApplicationToDatabase(txtStuID.Text, txtStuName.Text, position, companyName, imageBytes);

                MessageBox.Show(result, "Application Status", MessageBoxButtons.OK, result.Contains("successfully") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (result.Contains("successfully"))
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadResumeForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
