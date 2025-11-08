using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

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
            string name = txtStuName.Text;
            string id = txtStuID.Text;
            string email = txtStuEmail.Text;
            string contact = txtStuCont.Text;
            string course = txtStuCourse.Text;
            string password = txtStuPass.Text;

            try
            {
                con.Open();

                // Insert into Students table
                SqlCommand cmd = new SqlCommand("INSERT INTO Students(studentID, studentName, email, phoneNumber, course, password) VALUES(@id,@name,@em,@ph,@cr,@pw)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@ph", contact);
                cmd.Parameters.AddWithValue("@cr", course);
                cmd.Parameters.AddWithValue("@pw", password);
                cmd.ExecuteNonQuery();

                // Insert into Users table
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Users(username,password,role) VALUES(@name,@pw,'student')", con);
                cmd2.Parameters.AddWithValue("@name", name);
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
