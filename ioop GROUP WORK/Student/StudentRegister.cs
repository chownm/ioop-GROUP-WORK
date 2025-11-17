using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class StudentRegister
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString;

        public bool DoesStudentIDExist(string studentID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Students WHERE studentID=@id", con);
                    checkCmd.Parameters.AddWithValue("@id", studentID ?? "");

                    object countObj = checkCmd.ExecuteScalar();
                    int exists = (countObj != null && int.TryParse(countObj.ToString(), out int count)) ? count : 0;

                    return exists > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking student ID: " + ex.Message);
            }
        }



        public string RegisterStudent(string studentID, string studentName, string email, string phone, string course, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Start a transaction so both inserts succeed or fail together
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // Insert into Students table
                        SqlCommand cmdStudent = new SqlCommand(
                            "INSERT INTO Students(studentID, studentName, email, phoneNumber, course, password) VALUES(@id,@name,@em,@ph,@cr,@pw)",
                            con, transaction);

                        cmdStudent.Parameters.AddWithValue("@id", studentID);
                        cmdStudent.Parameters.AddWithValue("@name", studentName);
                        cmdStudent.Parameters.AddWithValue("@em", email);
                        cmdStudent.Parameters.AddWithValue("@ph", phone);
                        cmdStudent.Parameters.AddWithValue("@cr", course);
                        cmdStudent.Parameters.AddWithValue("@pw", password);

                        int rowsStudent = cmdStudent.ExecuteNonQuery();

                        // Insert into Users table
                        SqlCommand cmdUser = new SqlCommand(
                            "INSERT INTO Users(username,password,email,role) VALUES(@id,@pw,@em,'student')",
                            con, transaction);

                        cmdUser.Parameters.AddWithValue("@id", studentID);
                        cmdUser.Parameters.AddWithValue("@pw", password);
                        cmdUser.Parameters.AddWithValue("@em", email);

                        int rowsUser = cmdUser.ExecuteNonQuery();

                        if (rowsStudent > 0 && rowsUser > 0)
                        {
                            transaction.Commit();
                            return "Registration successful!";
                        }
                        else
                        {
                            transaction.Rollback();
                            return "Registration failed. Please try again.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Error: " + ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
