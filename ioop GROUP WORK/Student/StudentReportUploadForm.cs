using System;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentReportUploadForm : Form
    {
        private string studentID;
        private string filePath;
        private StudentReportUpload reportUploadLogic;

        public StudentReportUploadForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.reportUploadLogic = new StudentReportUpload();
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
            string uploadResult = reportUploadLogic.UploadReport(studentID, filePath);
            MessageBox.Show(uploadResult, "Upload Status", MessageBoxButtons.OK, uploadResult.Contains("successfully") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (uploadResult.Contains("successfully"))
            {
                this.Close();
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
