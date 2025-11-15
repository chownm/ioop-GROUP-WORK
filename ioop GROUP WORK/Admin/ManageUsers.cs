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
using ioop_GROUP_WORK.Login;

namespace ioop_GROUP_WORK.Admin
{
    public partial class ManageUsers : Form
    {
        private readonly AdminManager adminMgr;

        public ManageUsers()
        {
            InitializeComponent();
            adminMgr = AdminManager.Instance;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAllUsers();
                LoadRoleComboBox();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load all users from database into DataGridView
        /// </summary>
        private void LoadAllUsers()
        {
            try
            {
                DataTable dtUsers = adminMgr.GetAllUsers();
                dgvUsers.DataSource = dtUsers;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        /// <summary>
        /// Load role values into ComboBox
        /// </summary>
        private void LoadRoleComboBox()
        {
            try
            {
                cmbRole.Items.Clear();
                cmbRole.Items.Add("Student");
                cmbRole.Items.Add("CompanyHR");
                cmbRole.Items.Add("Recruiter");
                cmbRole.Items.Add("Supervisor");
                cmbRole.Items.Add("Administrator");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                User newUser = new User(
                    txtUsername.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text.Trim(),
                    cmbRole.SelectedItem.ToString()
                );

                string result = adminMgr.CreateUser(newUser);
                MessageBox.Show(result, "Create User", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadAllUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Please select a user to update.");
                    return;
                }

                if (!ValidateInputs())
                    return;

                int userId = int.Parse(lblUserId.Text);
                User updatedUser = new User(
                    userId,
                    txtUsername.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text.Trim(),
                    cmbRole.SelectedItem.ToString()
                );

                string result = adminMgr.UpdateUser(updatedUser);
                MessageBox.Show(result);
                LoadAllUsers();
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
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Please select a user to delete.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this user?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    int userId = int.Parse(txtUserId.Text);
                    string result = adminMgr.DeleteUser(userId);
                    MessageBox.Show(result);
                    LoadAllUsers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadAllUsers();
                    return;
                }

                DataTable dtSearch = adminMgr.SearchUsers(searchTerm);
                dgvUsers.DataSource = dtSearch;

                if (dtSearch.Rows.Count == 0)
                {
                    MessageBox.Show("No users found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtSearch.Clear();
            LoadAllUsers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                    txtUserId.Text = row.Cells["UserId"].Value.ToString();
                    txtUsername.Text = row.Cells["Username"].Value.ToString();
                    txtEmail.Text = row.Cells["Email"].Value.ToString();
                    txtPassword.Text = "";
                    cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Validate all input fields
        /// </summary>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.");
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter email.");
                txtEmail.Focus();
                return false;
            }

            if (!ValidationHelper.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.");
                txtPassword.Focus();
                return false;
            }

            if (!ValidationHelper.ValidatePassword(txtPassword.Text))
            {
                MessageBox.Show("Password must be 8+ chars with uppercase, lowercase, and numbers.");
                txtPassword.Focus();
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.");
                cmbRole.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            txtUserId.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
        }
    }
}
