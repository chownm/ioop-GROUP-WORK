using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public partial class frm_Student_Profile_Review : Form
    {

        public frm_Student_Profile_Review()
        {
            InitializeComponent();
        }

        // Constructor accepting studentId parameter
        public frm_Student_Profile_Review(string studentId)
        {
            InitializeComponent();
            // Load student profile based on studentId
        }

        private void Student_Profile_Review_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            frm_Student_Table frm = new frm_Student_Table();
            frm.ShowDialog();
        }

        private void frm_Student_Profile_Review_Load(object sender, EventArgs e)
        {

        }
    }
}