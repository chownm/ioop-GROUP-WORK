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
        private string studName;
        private string email;
        private string phoneNum;

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseInfo"].ConnectionString);

        public Student(string studName, string email, string phoneNum)
        {
            this.studName = studName;
            this.Email = email;
            this.PhoneNum = phoneNum;

        }
        public Student(string Studname)
        {
            this.studName = Studname;
        }

        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Email { get => email; set => email = value; }

        public string addStudent()
        {
            string status;
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into students(studentName, email, phoneNumber) values(@name, @em, @num)", con);

            SqlCommand cmd2 = new SqlCommand("insert into users (username,password,role) values(@name,'123','student')", con);
            cmd.Parameters.AddWithValue("@name", studName);
            cmd2.Parameters.AddWithValue("@name", studName);
            cmd.Parameters.AddWithValue("@em", email);
            cmd.Parameters.AddWithValue("@num", phoneNum);

            cmd2.ExecuteNonQuery();
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                status = "Registration Successful.";
            else
                status = "Unable to register.";
            con.Close();
            return status;

        }

        public static ArrayList viewAll()
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
        
        public static void viewProfile(Student o1)
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

        public string updateProfile(string em, string num)
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
