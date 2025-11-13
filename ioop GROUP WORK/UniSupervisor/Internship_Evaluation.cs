using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class Internship_Evaluation
    {
        // Attributes
        private string student_name;
        private string student_id;
        private string position;
        private double performance_rating;
        private double communication_skills_rating;
        private double punctuality_rating;
        private string description;

        // Constructor
        public Internship_Evaluation(string student_name, string student_id, string position, double performance_rating, double communication_skills_rating, double punctuality_rating, string description)
        {
            this.student_name = student_name;
            this.student_id = student_id;
            this.position = position;
            this.performance_rating = performance_rating;
            this.communication_skills_rating = communication_skills_rating;
            this.punctuality_rating = punctuality_rating;
            this.description = description;

        }

        public string Student_name { get => student_name; set => student_name = value; }
        public string Student_id { get => student_id; set => student_id = value; }
        public string Position { get => position; set => position = value; }
        public double Performance_rating { get => performance_rating; set => performance_rating = value; }
        public double Communication_skills_rating { get => communication_skills_rating; set => communication_skills_rating = value; }
        public double Punctuality_rating { get => punctuality_rating; set => punctuality_rating = value; }
        public string Description { get => description; set => description = value; }

        // Methods

        public static List<student_details> GetStudentName()
        { 
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            { 
                List<student_details> students = new List<student_details>();
                con.Open();
                string query_cmd = @"SELECT studentID, studentName FROM InternshipOffer";
                SqlCommand cmd = new SqlCommand(query_cmd, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                { 
                    students.Add(new student_details(
                        studentID: reader["studentID"].ToString(),
                        studentName: reader["studentName"].ToString()
                    ));
                }

            }
            con.Close();
            return student_details;
        }

        public string Display_Student_Name()
        {
            return $"{studentID} | {studentName}";
        }
    }
