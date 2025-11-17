using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ViewFeedbackForm : Form
    {
        private string studentID;
        private ViewFeedback feedbackLogic;

        public ViewFeedbackForm(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
            feedbackLogic = new ViewFeedback();
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
            try
            {
                // Get evaluation report from the ViewFeedback logic class
                DataTable evaluationReport = feedbackLogic.GetEvaluationReport(studentID);

                // Bind the data to the DataGridView
                dgvFeedback.DataSource = evaluationReport;

                dgvFeedback.Columns[0].HeaderText = "Position";
                dgvFeedback.Columns[1].HeaderText = "Performance";
                dgvFeedback.Columns[2].HeaderText = "Communication Skills";
                dgvFeedback.Columns[3].HeaderText = "Punctuality";
                dgvFeedback.Columns[4].HeaderText = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading evaluation report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
