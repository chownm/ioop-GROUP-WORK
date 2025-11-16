using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;


namespace ioop_GROUP_WORK.HR
{
    internal class VP
    {
        
        public string StudentName { get; private set; }
        public string Position { get; private set; }
        public DateTime DateApplied { get; private set; }
        public string Status { get; private set; }

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public VP(string student)
        {
            StudentName = student ?? "";
        }

        public VP ViewProfile()
        {
            VP student = null;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM StudentApplication WHERE StudentName = @name", con);
                cmd.Parameters.AddWithValue("@name", StudentName ?? "");

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    string positionVal = rd["Position"] != DBNull.Value ? rd["Position"].ToString() : "";
                    DateTime dateVal = rd["DateApplied"] != DBNull.Value ? Convert.ToDateTime(rd["DateApplied"]) : DateTime.MinValue;
                    string statusVal = rd["Status"] != DBNull.Value ? rd["Status"].ToString() : "";

                    student = new VP(rd["StudentName"].ToString())
                    {  
                        Position = positionVal,
                        DateApplied = dateVal,
                        Status = statusVal
                    };
                }
                
                rd.Close();
            }
            finally
            {
                con.Close();
            }

            return student;
        }

        public static List<string> GetAllStudentNames(string identify, string _password)
        {
            List<string> names = new List<string>();
            
            try
            {
                PersonalProfile pp = new PersonalProfile(identify ?? "", _password ?? "");
                string useridentify = pp.getprofilename();
                string password = pp.getpassword();

                if (string.IsNullOrEmpty(useridentify))
                    return names;

                con.Open();
                SqlCommand getCompanyCmd = new SqlCommand("SELECT CompanyName FROM CompanyProfile WHERE (Email = @identity OR ContactPerson = @identity)", con);
                SqlCommand cmd = new SqlCommand("SELECT StudentName FROM StudentApplication WHERE CompanyName = @companyname", con);

                getCompanyCmd.Parameters.AddWithValue("@identity", useridentify ?? "");

                object result = getCompanyCmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return names;
                }

                string companyName = result.ToString();

                cmd.Parameters.AddWithValue("@companyname", companyName ?? "");
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string name = rd["StudentName"] != DBNull.Value ? rd["StudentName"].ToString() : "";
                    if (!string.IsNullOrEmpty(name))
                        names.Add(name);
                }

                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student names: " + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return names;
        }

        public string Accept()
        {
            string newstatus = "Accepted";
            string message = "";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE StudentApplication SET Status = @status WHERE StudentName = @SName", con);

                cmd.Parameters.AddWithValue("@status", newstatus);
                cmd.Parameters.AddWithValue("@SName", StudentName ?? "");

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    message = $"{StudentName} Student: Application accepted successfully.";
                }
                else
                {
                    message = $"{StudentName} Student: Already accepted or not found.";
                }
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return message;
        }

        public string Reject()
        {
            string newstatus = "Rejected";
            string message = "";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE StudentApplication SET Status = @status WHERE StudentName = @SName", con);

                cmd.Parameters.AddWithValue("@status", newstatus);
                cmd.Parameters.AddWithValue("@SName", StudentName ?? "");

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    message = $"{StudentName} Student: Application rejected successfully.";
                }
                else
                {
                    message = $"{StudentName} Student: Already rejected or not found.";
                }
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }

            return message;
        }
    }
}
