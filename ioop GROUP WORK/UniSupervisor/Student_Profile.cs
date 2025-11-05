using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ioop_GROUP_WORK.UniSupervisor;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public class Student_Profile
    {
        //Attributes
        public string student_name;
        public string student_id;
        public string student_email;
        public string student_phone;
        public double course_progress;

        //Constructor
        public Student_Profile(string student_name, string student_id, string student_email, string student_phone)
        {
            this.student_name = student_name;
            this.student_id = student_id;
            this.student_email = student_email;
            this.student_phone = student_phone;
            this.course_progress = 0.00;
        }

        //Methods
         
    }
}
