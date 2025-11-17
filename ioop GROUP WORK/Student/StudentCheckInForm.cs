using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentCheckInForm : Form
    {
        private string studentID;
        private string studentName;

        public StudentCheckInForm(string studentID, string studentName)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.studentName = studentName;
        }



        private void StudentCheckInForm_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = studentName;
            lblStudentID.Text = studentID;
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }



        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = @"INSERT INTO Check_In_Record (studentID, studentName, checkInDate)
                                     VALUES (@studentID, @studentName, @checkInDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@studentID", studentID);
                    cmd.Parameters.AddWithValue("@studentName", studentName);

                    cmd.Parameters.AddWithValue("@checkInDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("✅ Check-in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnCheckIn.Enabled = false;

                        ViewCheckInRecordForm viewCheckIn = new ViewCheckInRecordForm(studentID);
                        viewCheckIn.ShowDialog();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("❌ Check-in failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❗ Error during check-in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
