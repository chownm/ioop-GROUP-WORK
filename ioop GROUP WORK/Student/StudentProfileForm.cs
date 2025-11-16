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
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Students SET email=@em, phoneNumber=@ph, course=@cs WHERE studentID=@id", con);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT studentName, email, phoneNumber, course FROM Students WHERE studentID=@id", con);
                cmd.Parameters.AddWithValue("@id", studentID);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lblStudentID.Text = studentID;
                    lblName.Text = rd["studentName"].ToString();
                    txtEmail.Text = rd["email"].ToString();
                    txtPhone.Text = rd["phoneNumber"].ToString();
                    txtCourse.Text = rd["course"].ToString();
                }
            }
        }

        
    }
}
