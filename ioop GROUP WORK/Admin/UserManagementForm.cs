using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Managers;

namespace InternshipTrackerSystem.Forms.Administrator
{
    public partial class UserManagementForm : Form
    {
        private Administrator currentAdmin;
        private List<User> users;

        public UserManagementForm(Administrator admin)
        {
            currentAdmin = admin;
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                users = UserManager.Instance.GetAllUsers();

                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users;

                ConfigureGrid();
                lblTotal.Text = $"Total Users: {users.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error");
            }
        }

        private void ConfigureGrid()
        {
            dgvUsers.Columns["UserId"].HeaderText = "ID";
            dgvUsers.Columns["Username"].HeaderText = "Username";
            dgvUsers.Columns["Email"].HeaderText = "Email";
            dgvUsers.Columns["Role"].HeaderText = "Role";
            dgvUsers.Columns["IsActive"].HeaderText = "Active";
            dgvUsers.Columns["Password"].Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit", "Information");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows.Cells["UserId"].Value);
            User selectedUser = users.Find(u => u.UserId == userId);

            EditUserForm editForm = new EditUserForm(selectedUser);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete", "Information");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to deactivate this user?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows.Cells["UserId"].Value);

                bool success = UserManager.Instance.DeactivateUser(userId);
                if (success)
                {
                    MessageBox.Show("User deactivated successfully", "Success");
                    LoadUsers();
                }
            }
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = cmbRoleFilter.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedRole) || selectedRole == "All")
            {
                LoadUsers();
            }
            else
            {
                var filteredUsers = users.FindAll(u => u.Role == selectedRole);
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = filteredUsers;
                lblTotal.Text = $"Filtered Users: {filteredUsers.Count}";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
