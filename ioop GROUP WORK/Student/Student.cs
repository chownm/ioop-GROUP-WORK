using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace ioop_GROUP_WORK
{
    internal class Student
    {
        //=============================
        //Atributes
        //=============================
        private string name;
        private string id;
        private string email;
        private string phoneno;
        private string course;
        private string password;

        //Shared SQL Connection string
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);


        //=============================
        //Constructor
        //=============================
        public Student(string stuName, string stuId, string stuEmail, string stuPhoneno, string stuCourse, string stuPassword)
        {
            this.name = stuName;
            this.id = stuId;
            this.email = stuEmail;
            this.phoneno = stuPhoneno;
            this.course = stuCourse;
            this.password = stuPassword;

        }


        //=============================
        //Methods
        //=============================
        public string AddStudent()
        {
            string status;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString))
            {
                con.Open();

                //Insert Into student table
                SqlCommand cmd = new SqlCommand("INSERT INTO students(studentName, studentID, email, phoneNumber, course, password) values(@name, @id, @em, @num, @course, @courseid)", con);
            }


        }

        public static ArrayList ViewAll()
        {
            ArrayList nm = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("select studentName from students", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                nm.Add(rd.GetString(0));
            }
            con.Close();
            return nm;
        }
        
        public static void ViewProfile(Student o1)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from students where studentName = @a", con);
            cmd.Parameters.AddWithValue("@a", o1.studName);

            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read()) 
            {
                o1.email = rd.GetString(2);
                o1.phoneNum =  rd.GetString(3);
            }
            con.Close();
                
        }

        public string UpdateProfile(string em, string num)
        {
            string status;
            con.Open();

            SqlCommand cmd = new SqlCommand("update students set email = @e, phoneNumber=@p where studentName =@nm", con);
            cmd.Parameters.AddWithValue("@e",em);
            cmd.Parameters.AddWithValue("@p", num);
            cmd.Parameters.AddWithValue("@nm", studName);

            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                status = "Update Succefully.";
            else
                status = "Unable to update";
            con.Close();
            
            return status;
        }
    }
}
