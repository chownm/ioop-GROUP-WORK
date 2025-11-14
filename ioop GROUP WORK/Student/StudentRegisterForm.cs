using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentRegisterForm : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);
        public StudentRegisterForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtStuName.Text.Trim();
            string id = txtStuID.Text.Trim();
            string email = txtStuEmail.Text.Trim();
            string contact = txtStuCont.Text.Trim();
            string course = txtStuCourse.Text.Trim();
            string password = txtStuPass.Text.Trim();

            if (name == "" || id == "" || email == "" || contact == "" || course == "" || password == "")
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            try
            {
                con.Open();

                // Check for duplicate studentID
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Students WHERE studentID=@id", con);
                check.Parameters.AddWithValue("@id", id);

                int exists = (int)check.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Student ID already exists!");
                    return;
                }

                // Insert into Students table
                SqlCommand cmd = new SqlCommand("INSERT INTO Students(studentID, studentName, email, phoneNumber, course, password) VALUES(@id,@name,@em,@ph,@cr,@pw)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@ph", contact);
                cmd.Parameters.AddWithValue("@cr", course);
                cmd.ExecuteNonQuery();

                // Insert into Users table
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Users(username,password,role) VALUES(@id,@pw,'student')", con);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.Parameters.AddWithValue("@pw", password);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Registration successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void StudentRegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
