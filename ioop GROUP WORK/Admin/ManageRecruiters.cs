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
using ioop_GROUP_WORK.HR;

namespace ioop_GROUP_WORK.Admin
{
    public partial class ManageRecruiters : Form
    {
        private AdminManager adminMgr;

        public ManageRecruiters()
        {
            InitializeComponent();
            adminMgr = AdminManager.Instance;
        }

        private void ManageRecruiters_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCompanies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompanies()
        {
            try
            {
                // ✅ Load companies from database
                cmbCompany.Items.Clear();
                cmbCompany.DisplayMember = "CompanyName";
                cmbCompany.ValueMember = "Id";

                DataTable dtCompanies = adminMgr.GetAllCompanies();

                if (dtCompanies.Rows.Count > 0)
                {
                    cmbCompany.DataSource = dtCompanies;
                    cmbCompany.SelectedIndex = -1; // ✅ No default selection
                }
                else
                {
                    MessageBox.Show("No companies found in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading companies: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // ✅ Clear grid if no company selected
                if (cmbCompany.SelectedIndex < 0 || cmbCompany.SelectedValue == null)
                {
                    dgvRecruiters.DataSource = null;
                    return;
                }

                int companyId = (int)cmbCompany.SelectedValue;
                DataTable dt = adminMgr.GetRecruitersByCompany(companyId);
                dgvRecruiters.DataSource = dt;
                dgvRecruiters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recruiters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                if (cmbCompany.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a company.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int companyId = (int)cmbCompany.SelectedValue;

                string result = adminMgr.CreateRecruiter(
                    txtUsername.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text.Trim(),
                    companyId,
                    txtRecruiterName.Text.Trim(),
                    txtPosition.Text.Trim(),
                    txtPhone.Text.Trim()
                );

                MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result.Contains("successfully"))
                {
                    cmbCompany_SelectedIndexChanged(null, null);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating recruiter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecruiters.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a recruiter to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this recruiter?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    int recruiterId = int.Parse(dgvRecruiters.SelectedRows[0].Cells["RecruiterId"].Value.ToString());
                    string result = adminMgr.DeleteRecruiter(recruiterId);
                    MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCompany_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting recruiter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtRecruiterName.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidationHelper.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtRecruiterName.Clear();
            txtPosition.Clear();
            txtPhone.Clear();
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                if (cmbCompany.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a company.");
                    return;
                }

                int companyId = int.Parse(cmbCompany.SelectedValue.ToString());
                string result = adminMgr.CreateRecruiter(
                    txtUsername.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text.Trim(),
                    companyId,
                    txtRecruiterName.Text.Trim(),
                    txtPosition.Text.Trim(),
                    txtPhone.Text.Trim()
                );

                MessageBox.Show(result);
                LoadRecruiters();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecruiters.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a recruiter to delete.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    int recruiterId = int.Parse(dgvRecruiters.SelectedRows[0].Cells["RecruiterId"].Value.ToString());
                    MessageBox.Show("Recruiter deleted.");
                    LoadRecruiters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadRecruiters()
        {
            try
            {
                if (cmbCompany.SelectedIndex > 0)
                {
                    int companyId = int.Parse(cmbCompany.SelectedValue.ToString());
                    DataTable dt = adminMgr.GetRecruitersByCompany(companyId);
                    dgvRecruiters.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
