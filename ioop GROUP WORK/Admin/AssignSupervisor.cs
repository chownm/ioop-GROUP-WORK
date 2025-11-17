using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK.Admin;

namespace ioop_GROUP_WORK.Admin
{
    public partial class AssignSupervisor : Form
    {
        private readonly AdminManager adminMgr;

        public AssignSupervisor()
        {
            InitializeComponent();
            adminMgr = AdminManager.Instance;
        }

        private void AssignSupervisor_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStudents();
                LoadSupervisors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadStudents()
        {
            try
            {
                DataTable dtStudents = new DataTable();
                dgvStudents.DataSource = dtStudents;
                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void LoadSupervisors()
        {
            try
            {
                DataTable dtSupervisors = new DataTable();
                dgvSupervisors.DataSource = dtSupervisors;
                dgvSupervisors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supervisors: " + ex.Message);
            }
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStudents.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a student.");
                    return;
                }

                if (cmbSupervisor.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a supervisor.");
                    return;
                }

                // studentID is varchar in DB, use string
                string studentId = dgvStudents.SelectedRows[0].Cells["StudentId"].Value.ToString();
                int supervisorId = int.Parse(cmbSupervisor.SelectedValue.ToString());

                string result = adminMgr.AssignSupervisor(studentId, supervisorId);
                MessageBox.Show(result);
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
