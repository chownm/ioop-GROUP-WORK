using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentProfileForm : Form
    {
        private string studentID;
        public StudentProfileForm(string id)
        {
            InitializeComponent();
            studentID = id;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Students SET email=@em, phoneNumber=@ph, course=@cs WHERE studentID=@id", con);

                cmd.Parameters.AddWithValue("@em", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ph", txtPhone.Text);
                cmd.Parameters.AddWithValue("@cs", txtCourse.Text);
                cmd.Parameters.AddWithValue("@id", studentID);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Profile updated successfully!");
                else
                    MessageBox.Show("Update failed! Please try again.");
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void StudentProfileForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                try
                {
                    con.Open();

                    // Correct SQL query to retrieve student info using studentID (which is stored in Username)
                    SqlCommand cmd = new SqlCommand(
                        "SELECT studentName, email, phoneNumber, course FROM Students WHERE StudentID=@id OR Email=@id", con);
                    cmd.Parameters.AddWithValue("@id", studentID);  // Use studentID (which is the Username)

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        // Display student data in the relevant fields
                        lblStudentID.Text = studentID;
                        lblName.Text = rd["studentName"].ToString();
                        txtEmail.Text = rd["email"].ToString();
                        txtPhone.Text = rd["phoneNumber"].ToString();
                        txtCourse.Text = rd["course"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Student data not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading student data: " + ex.Message);
                }
            }
        }

    }
}
