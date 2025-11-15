using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ioop_GROUP_WORK.UniSupervisor
{
    internal class Check_Internship_Progress
    {
        // Attributes
        private string student_id;
        private string student_name;
        private DateTime check_in_date

        // Constructors
        public Check_Internship_Progress(string student_id, string student_name, DateTime check_in_date)
        {
            this.student_id = student_id;
            this.student_name = student_name;
            this.check_in_date = check_in_date;
        }

        // Methods
        public List<Check_Internship_Progress> GetCheckInRecord()
        {
           List<Check_Internship_Progress> records = new List<Check_Internship_Progress>();

        }

    }
}
