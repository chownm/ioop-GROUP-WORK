using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class Internship_Evaluation
    {
        // Attributes
        private string student_name;
        private string student_id;
        private string position;
        private DateTime evaluation_date;
        private double performance_rating;
        private double communication_skills_rating;
        private double punctuality_rating;
        private string description;

        // Constructor
        public Internship_Evaluation(string student_name, string student_id, string position, DateTime evaluation_date,double performance_rating, double communication_skills_rating, double punctuality_rating, string description)
        {
            this.student_name = student_name;
            this.student_id = student_id;
            this.position = position;
            this.evaluation_date = evaluation_date;
            this.performance_rating = performance_rating;
            this.communication_skills_rating = communication_skills_rating;
            this.punctuality_rating = punctuality_rating;
            this.description = description;
        }

        public Internship_Evaluation(string student_name, string student_id)            // This connstructor is used for GetStudentName()
        {
            this.student_name = student_name;
            this.student_id = student_id;
        }


        public string Student_name { get => student_name; set => student_name = value; }
        public string Student_id { get => student_id; set => student_id = value; }
        public string Position { get => position; set => position = value; }
        public double Performance_rating { get => performance_rating; set => performance_rating = value; }
        public double Communication_skills_rating { get => communication_skills_rating; set => communication_skills_rating = value; }
        public double Punctuality_rating { get => punctuality_rating; set => punctuality_rating = value; }
        public string Description { get => description; set => description = value; }
        public DateTime Evaluation_date { get => evaluation_date; set => evaluation_date = value; }

        // Methods

        public static List<Internship_Evaluation> GetStudentName()
        {
            List<Internship_Evaluation> students = new List<Internship_Evaluation>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {

                con.Open();
                string query_cmd = @"SELECT studentID, studentName FROM InternshipOffer";
                SqlCommand cmd = new SqlCommand(query_cmd, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Internship_Evaluation(
                        student_id: reader["studentID"].ToString(),
                        student_name: reader["studentName"].ToString()
                    ));
                }

            }
            return students;
        }

        public string Display_Student_Name()
        {
            return $"{student_id} | {student_name}";
        }

        public void InsertEvaluationsRecord()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
                {
                    con.Open();
                    string query_cmd = @"INSERT INTO Student_Evaluation_Report 
                                            (studentID, studentName, Position, EvaluationDate, Performance, CommunicationSkills, Punctuality, Description)
                                         VALUES
                                           (@id, @name, @position, @date, @performance, @communication, @punctuality, @description)";   // Key in the sql command to insert evaluation record
                            
                    using (SqlCommand cmd = new SqlCommand(query_cmd, con))
                    {
                        cmd.Parameters.AddWithValue("@id", this.student_id);
                        cmd.Parameters.AddWithValue("@name", this.student_name);
                        cmd.Parameters.AddWithValue("@position", this.position);
                        cmd.Parameters.AddWithValue("@date", this.evaluation_date == default(DateTime) ? DateTime.Now : this.evaluation_date);
                        cmd.Parameters.AddWithValue("@performance", this.performance_rating);
                        cmd.Parameters.AddWithValue("@communication", this.communication_skills_rating);
                        cmd.Parameters.AddWithValue("@punctuality", this.punctuality_rating);
                        cmd.Parameters.AddWithValue("@description", this.description);
                        
                        cmd.ExecuteNonQuery();
                    }

                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Error inserting evaluation record: " + ex.Message);
            }
        

        }
    }
}
