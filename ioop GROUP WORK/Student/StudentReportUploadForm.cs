using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class StudentReportUploadForm : Form
    {
        // ✅ ADD 1-ARG CONSTRUCTOR
        public StudentReportUploadForm(string studentId)
        {
            InitializeComponent();
            this.Text = $"Upload Report - {studentId}";
        }

        public StudentReportUploadForm()
        {
            InitializeComponent();
        }
    }
}
