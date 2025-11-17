using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ioop_GROUP_WORK.Student
{
    public class StudentProfile
    {
        private string studentID;

        public StudentProfile(string id)
        {
            studentID = id ?? "";
        }

        // Method to get the student profile data from the database
        public (string studentName, string email, string phoneNumber, string course, string errorMessage) GetStudentProfile()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();

                    // Query to get student details
                    SqlCommand cmd = new SqlCommand("SELECT studentName, email, phoneNumber, course FROM Students WHERE StudentID=@id OR Email=@id", con);
                    cmd.Parameters.AddWithValue("@id", studentID);

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        // Return student data
                        return (rd["studentName"].ToString(), rd["email"].ToString(), rd["phoneNumber"].ToString(), rd["course"].ToString(), null);
                    }
                    else
                    {
                        return (null, null, null, null, "Student data not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                return (null, null, null, null, $"Error: {ex.Message}");
            }
        }

        // Method to update student profile data in the database
        public string UpdateStudentProfile(string email, string phone, string course)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        // Update the Students table
                        SqlCommand cmdStudent = new SqlCommand("UPDATE Students SET email=@em, phoneNumber=@ph, course=@cs WHERE studentID=@id", con, transaction);
                        cmdStudent.Parameters.AddWithValue("@em", email);
                        cmdStudent.Parameters.AddWithValue("@ph", phone);
                        cmdStudent.Parameters.AddWithValue("@cs", course);
                        cmdStudent.Parameters.AddWithValue("@id", studentID);

                        int rowsStudent = cmdStudent.ExecuteNonQuery();

                        // Update the Users table
                        SqlCommand cmdUser = new SqlCommand("UPDATE Users SET Email=@em WHERE Username=@id", con, transaction);
                        cmdUser.Parameters.AddWithValue("@em", email);
                        cmdUser.Parameters.AddWithValue("@id", studentID);

                        int rowsUser = cmdUser.ExecuteNonQuery();

                        if (rowsStudent > 0 && rowsUser > 0)
                        {
                            transaction.Commit();
                            return "Profile updated successfully!";
                        }
                        else
                        {
                            transaction.Rollback();
                            return "Update failed! Please try again.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return $"Error: {ex.Message}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
