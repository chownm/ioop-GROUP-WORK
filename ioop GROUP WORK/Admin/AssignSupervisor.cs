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
using ioop_GROUP_WORK.UniSupervisor;

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
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                DataTable dtStudents = adminMgr.GetAllStudents();
                dgvStudents.DataSource = dtStudents;
                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // ✅ Adjust column widths
                if (dgvStudents.Columns.Count > 0)
                {
                    dgvStudents.Columns[0].Width = 80;
                    dgvStudents.Columns[1].Width = 120;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSupervisors()
        {
            try
            {
                // ✅ Clear and populate dropdown from database
                cmbSupervisor.Items.Clear();
                cmbSupervisor.DisplayMember = "FullName";
                cmbSupervisor.ValueMember = "SupervisorId";

                DataTable dtSupervisors = adminMgr.GetAllSupervisors();

                if (dtSupervisors.Rows.Count > 0)
                {
                    cmbSupervisor.DataSource = dtSupervisors;
                    cmbSupervisor.SelectedIndex = -1; // ✅ No default selection
                }
                else
                {
                    MessageBox.Show("No supervisors found in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supervisors: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validate student selection
                if (dgvStudents.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a student from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Validate supervisor selection
                if (cmbSupervisor.SelectedIndex < 0 || cmbSupervisor.SelectedValue == null)
                {
                    MessageBox.Show("Please select a supervisor from the dropdown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Get values from UI
                string studentId = dgvStudents.SelectedRows[0].Cells["studentID"].Value.ToString();
                int supervisorId = (int)cmbSupervisor.SelectedValue;

                // ✅ Call AdminManager to assign
                string result = adminMgr.AssignSupervisor(studentId, supervisorId);
                MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Refresh list
                LoadStudents();
                cmbSupervisor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error assigning supervisor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
