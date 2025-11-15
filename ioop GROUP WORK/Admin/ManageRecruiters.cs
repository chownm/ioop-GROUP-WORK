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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCompanies()
        {
            try
            {
                cmbCompany.Items.Clear();
                cmbCompany.Items.Add("Select Company");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading companies: " + ex.Message);
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
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

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtRecruiterName.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return false;
            }

            if (!ValidationHelper.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.");
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
    }
}
