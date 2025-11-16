using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK.UniSupervisor;
using ioop_GROUP_WORK.Login;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public partial class frm_UniSupervisorHome : Form
    {
        public frm_UniSupervisorHome()
        {
            InitializeComponent();
        }

        private void btn_evaluate_form_load_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Evaluation_Form frm = new frm_Evaluation_Form();
            frm.ShowDialog();
        }

        private void btn_internship_progress_load_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Student_Internship_Table frm = new frm_Student_Internship_Table();
            frm.ShowDialog();
        }
        private void btn_manage_profile_load_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_Student_Profile_Review frm = new frm_Student_Profile_Review();
            frm.ShowDialog();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage frm = new LoginPage();
            frm.ShowDialog();
        }
    }
}
