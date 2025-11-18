using ioop_GROUP_WORK.Admin;
using ioop_GROUP_WORK.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioopGROUPWORK.Admin
{
    public partial class ManageUsers : Form
    {
        private readonly AdminManager adminMgr;
        private string currentTableName = "users";
        private DataTable currentData = null;
        private List<string> tableList = new List<string>();
        private Dictionary<string, List<string>> tableColumnsMap = new Dictionary<string, List<string>>();

        public ManageUsers()
        {
            InitializeComponent();
            adminMgr = AdminManager.Instance;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeTableList();
                InitializeExactDatabaseSchemaFromSQL();
                PromptTableSelection();
                LoadRoleComboBox();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Initialize table list
        private void InitializeTableList()
        {
            try
            {
                tableList = new List<string>
                {
                    "users",
                    "Students",
                    "Supervisors",
                    "Recruiters",
                    "CompanyProfile",
                    "StudentApplication",
                    "InternshipOffer",
                    "Administrators",
                    "Courses",
                    "Chapters",
                    "Check_In_Record",
                    "Student_Progress",
                    "Student_Evaluation_Report"
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing table list: " + ex.Message);
            }
        }

        // ✅ EXACT DATABASE SCHEMA FROM SQL CREATE TABLE STATEMENTS
        private void InitializeExactDatabaseSchemaFromSQL()
        {
            try
            {
                // CREATE TABLE [dbo].[users] - [id] [Username] [password] [Email] [role]
                tableColumnsMap["users"] = new List<string> { "id", "Username", "password", "Email", "role" };

                // CREATE TABLE [dbo].[Students] - [studentID] [studentName] [email] [phoneNumber] [course]
                tableColumnsMap["students"] = new List<string> { "studentID", "studentName", "email", "phoneNumber", "course" };

                // CREATE TABLE [dbo].[Supervisors] - [SupervisorId] [UserId] [FullName] [Department] [Phone] [Email] [CreatedDate] [IsActive]
                tableColumnsMap["supervisors"] = new List<string> { "SupervisorId", "UserId", "FullName", "Department", "Phone", "Email" };

                // CREATE TABLE [dbo].[Recruiters] - [RecruiterId] [UserId] [CompanyId] [FullName] [Position] [Phone] [Email] [CreatedDate] [IsActive]
                tableColumnsMap["recruiters"] = new List<string> { "RecruiterId", "UserId", "CompanyId", "FullName", "Position", "Phone", "Email" };

                // CREATE TABLE [dbo].[CompanyProfile] - [Id] [CompanyName] [ContactPerson] [Email] [ContactNumber] [Address] [CompanyDescription]
                tableColumnsMap["companyprofile"] = new List<string> { "Id", "CompanyName", "ContactPerson", "Email", "ContactNumber", "Address" };

                // CREATE TABLE [dbo].[StudentApplication] - [StudentID] [StudentName] [Position] [DateApplied] [Status] [CompanyName]
                tableColumnsMap["studentapplication"] = new List<string> { "StudentID", "StudentName", "Position", "DateApplied", "Status", "CompanyName" };

                // CREATE TABLE [dbo].[InternshipOffer] - [Id] [JobTitle] [Position] [StartDate] [EndDate] [Salary] [Description] [DateOffered] [CompanyName]
                tableColumnsMap["internshipoffer"] = new List<string> { "Id", "JobTitle", "Position", "StartDate", "EndDate", "Salary", "CompanyName" };

                // CREATE TABLE [dbo].[Administrators] - [AdminId] [UserId] [FullName] [Department] [Phone] [AccessLevel]
                tableColumnsMap["administrators"] = new List<string> { "AdminId", "UserId", "FullName", "Department", "Phone", "AccessLevel" };

                // CREATE TABLE [dbo].[Courses] - [Course_Id] [Subject_Name]
                tableColumnsMap["courses"] = new List<string> { "Course_Id", "Subject_Name" };

                // CREATE TABLE [dbo].[Chapters] - [Course_Id] [Chapter_Id] [Chapter_Name] [Chapter_Order] [Description]
                tableColumnsMap["chapters"] = new List<string> { "Chapter_Id", "Course_Id", "Chapter_Name", "Chapter_Order", "Description" };

                // CREATE TABLE [dbo].[Check_In_Record] - [CheckInID] [studentID] [studentName] [checkInDate]
                tableColumnsMap["check_in_record"] = new List<string> { "CheckInID", "studentID", "studentName", "checkInDate" };

                // CREATE TABLE [dbo].[Student_Progress] - [Subject_Id] [Chapter_Id] [Progress_Percentage] [studentID]
                tableColumnsMap["student_progress"] = new List<string> { "Subject_Id", "Chapter_Id", "Progress_Percentage", "studentID" };

                // CREATE TABLE [dbo].[Student_Evaluation_Report] - [ReportID] [studentID] [studentName] [Position] [EvaluationDate] [Performance] [CommunicationSkills] [Punctuality]
                tableColumnsMap["student_evaluation_report"] = new List<string> { "ReportID", "studentID", "studentName", "Position", "EvaluationDate", "Performance", "CommunicationSkills", "Punctuality" };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing schema: " + ex.Message);
            }
        }

        // ✅ Update Form Labels Based on Selected Table - EXACT SCHEMA COLUMNS DISPLAYED
        private void UpdateFormLabelsForTable(string tableName)
        {
            try
            {
                string tableKey = tableName.ToLower().Replace(" ", "_");

                // Hide all controls first
                HideAllFormControls();

                // Get columns for this table
                if (!tableColumnsMap.ContainsKey(tableKey))
                    return;

                List<string> columns = tableColumnsMap[tableKey];
                int controlIndex = 0;

                // Array of available controls in exact order
                Label[] labels = { lblUserId, lblUsername, lblEmail, lblPassword, lblDepartment, lblPhone };
                Control[] controls = { txtUserId, txtUsername, txtEmail, txtPassword, txtDepartment, txtPhone };

                // Display each column from schema
                foreach (string column in columns)
                {
                    if (controlIndex >= labels.Length)
                        break;

                    Label lbl = labels[controlIndex];
                    Control ctrl = controls[controlIndex];

                    if (lbl != null && ctrl != null)
                    {
                        // Set label to EXACT column name from SQL schema
                        lbl.Text = column + ":";
                        lbl.Visible = true;
                        ctrl.Visible = true;

                        // Clear control based on type
                        if (ctrl is TextBox txt)
                        {
                            txt.Clear();
                            // Mark ID fields as read-only
                            txt.ReadOnly = (column.ToLower().Contains("id"));
                        }
                        else if (ctrl is ComboBox cmb)
                        {
                            cmb.SelectedIndex = -1;
                        }

                        controlIndex++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating form labels: " + ex.Message);
            }
        }

        // ✅ Hide all form controls
        private void HideAllFormControls()
        {
            try
            {
                lblUserId.Visible = false;
                lblUsername.Visible = false;
                lblEmail.Visible = false;
                lblPassword.Visible = false;
                lblDepartment.Visible = false;
                lblPhone.Visible = false;
                lblRole.Visible = false;

                txtUserId.Visible = false;
                txtUsername.Visible = false;
                txtEmail.Visible = false;
                txtPassword.Visible = false;
                txtDepartment.Visible = false;
                txtPhone.Visible = false;
                cmbRole.Visible = false;
                chkActive.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error hiding controls: " + ex.Message);
            }
        }

        // ✅ Prompt user to select a table at form load
        private void PromptTableSelection()
        {
            try
            {
                string message = "Select a table to manage:\n\n";
                for (int i = 0; i < tableList.Count; i++)
                {
                    message += (i + 1) + ". " + tableList[i] + "\n";
                }

                string selectedTable = PromptForTableInput(message, "Manage Data - Select Table", "users");

                if (string.IsNullOrWhiteSpace(selectedTable))
                {
                    selectedTable = "users";
                }

                SwitchTable(selectedTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error prompting table selection: " + ex.Message);
                SwitchTable("users");
            }
        }

        // ✅ Helper method to prompt for table input with ComboBox
        private string PromptForTableInput(string message, string title, string defaultValue)
        {
            Form prompt = new Form()
            {
                Text = title,
                Width = 450,
                Height = 350,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScaleDimensions = new SizeF(6F, 13F),
                AutoScaleMode = AutoScaleMode.Font
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = message,
                Width = 400,
                Height = 180,
                AutoSize = false,
                Font = new Font("Arial", 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            ComboBox comboBox = new ComboBox()
            {
                Left = 20,
                Top = 210,
                Width = 400,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Button okBtn = new Button()
            {
                Text = "OK",
                Left = 220,
                Width = 90,
                Top = 250,
                DialogResult = DialogResult.OK,
                BackColor = Color.CornflowerBlue,
                ForeColor = Color.White,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };
            Button cancelBtn = new Button()
            {
                Text = "Cancel",
                Left = 330,
                Width = 90,
                Top = 250,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };

            comboBox.Items.AddRange(tableList.ToArray());
            comboBox.SelectedItem = defaultValue;

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(okBtn);
            prompt.Controls.Add(cancelBtn);
            prompt.AcceptButton = okBtn;
            prompt.CancelButton = cancelBtn;

            return prompt.ShowDialog() == DialogResult.OK ? comboBox.SelectedItem.ToString() : null;
        }

        // ✅ Switch between tables and load their data dynamically
        private void SwitchTable(string tableName)
        {
            try
            {
                currentTableName = tableName.ToLower().Replace(" ", "_");

                // Get data based on table name
                if (tableName.ToLower() == "users")
                    currentData = adminMgr.GetAllUsers();
                else if (tableName.ToLower() == "students")
                    currentData = adminMgr.GetAllStudents();
                else if (tableName.ToLower() == "supervisors")
                    currentData = adminMgr.GetAllSupervisors();
                else if (tableName.ToLower() == "recruiters")
                    currentData = adminMgr.GetAllRecruiters();
                else if (tableName.ToLower() == "companyprofile")
                    currentData = adminMgr.GetAllCompanies();
                else if (tableName.ToLower() == "studentapplication")
                    currentData = adminMgr.GetAllApplications();
                else if (tableName.ToLower() == "internshipoffer")
                    currentData = adminMgr.GetAllInternshipOffers();
                else if (tableName.ToLower() == "administrators")
                    currentData = Administrator.GetAll();
                else if (tableName.ToLower() == "courses")
                    currentData = adminMgr.GetAllCourses();
                else if (tableName.ToLower() == "chapters")
                    currentData = adminMgr.GetAllChapters();
                else if (tableName.ToLower() == "check_in_record")
                    currentData = adminMgr.GetAllCheckInRecords();
                else if (tableName.ToLower() == "student_progress")
                    currentData = adminMgr.GetAllStudentProgress();
                else if (tableName.ToLower() == "student_evaluation_report")
                    currentData = adminMgr.GetAllEvaluationReports();

                dgvUsers.DataSource = currentData;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.ReadOnly = true;

                // ✅ Update form labels to show EXACT database schema columns
                UpdateFormLabelsForTable(tableName);

                lblTitle.Text = $"Manage {tableName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error switching table: " + ex.Message);
            }
        }

        // ✅ Load role values into ComboBox
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

        // ✅ Create new record - DYNAMIC CRUD
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                string result = string.Empty;

                if (currentTableName == "administrators")
                {
                    result = Administrator.Create(
                        0,
                        int.Parse(txtUserId.Text.Trim()),
                        txtUsername.Text.Trim(),
                        txtDepartment.Text.Trim(),
                        txtPhone.Text.Trim(),
                        cmbRole.SelectedItem.ToString()
                    );
                }
                else if (currentTableName == "users")
                {
                    result = adminMgr.CreateUser(
                        txtUserId.Text.Trim(),
                        txtUsername.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtPassword.Text.Trim(),
                        cmbRole.SelectedItem.ToString()
                    );
                }

                MessageBox.Show(result, "Create Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result.Contains("successfully"))
                {
                    LoadTableData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Update existing record - DYNAMIC CRUD
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Please select a record to update!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string field = "";
                string specificattribute = "";

                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    field = currentTableName == "administrators" ? "FullName" : "Username";
                    specificattribute = txtUsername.Text.Trim();
                }
                else if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    field = "Email";
                    specificattribute = txtEmail.Text.Trim();
                }
                else if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    field = "password";
                    specificattribute = txtPassword.Text.Trim();
                }
                else if (!string.IsNullOrEmpty(txtDepartment.Text))
                {
                    field = "Department";
                    specificattribute = txtDepartment.Text.Trim();
                }
                else if (!string.IsNullOrEmpty(txtPhone.Text))
                {
                    field = "Phone";
                    specificattribute = txtPhone.Text.Trim();
                }
                else if (cmbRole.SelectedItem != null)
                {
                    field = currentTableName == "administrators" ? "AccessLevel" : "role";
                    specificattribute = cmbRole.SelectedItem.ToString();
                }

                if (string.IsNullOrEmpty(field))
                {
                    MessageBox.Show("Please modify at least one field!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string result = string.Empty;
                int recordId = int.Parse(txtUserId.Text);

                if (currentTableName == "administrators")
                {
                    result = Administrator.Update(recordId, field, specificattribute);
                }
                else
                {
                    result = adminMgr.UpdateUser(recordId, field, specificattribute);
                }

                MessageBox.Show(result, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableData();
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Delete record - DYNAMIC CRUD
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserId.Text))
                {
                    MessageBox.Show("Please select a record to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    string result = string.Empty;
                    int recordId = int.Parse(txtUserId.Text);

                    if (currentTableName == "administrators")
                    {
                        result = Administrator.Delete(recordId);
                    }
                    else
                    {
                        result = adminMgr.DeleteUser(recordId);
                    }

                    MessageBox.Show(result, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Search records
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadTableData();
                    return;
                }

                DataTable dtSearch;

                if (currentTableName == "administrators")
                {
                    dtSearch = Administrator.Search(searchTerm);
                }
                else if (currentTableName == "users")
                {
                    dtSearch = adminMgr.SearchUsers(searchTerm);
                }
                else
                {
                    MessageBox.Show("Search is only available for Users and Administrators.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvUsers.DataSource = dtSearch;

                if (dtSearch.Rows.Count == 0)
                    MessageBox.Show("No records found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Load current table data
        private void LoadTableData()
        {
            try
            {
                string tableName = "";
                foreach (var t in tableList)
                {
                    if (t.ToLower().Replace(" ", "_") == currentTableName)
                    {
                        tableName = t;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(tableName))
                {
                    SwitchTable(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading data: " + ex.Message);
            }
        }

        // ✅ Clear input fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtSearch.Clear();
            LoadTableData();
        }

        // ✅ Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ✅ Cell click to populate fields from DataGridView
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                // Get the primary key column (usually first column)
                if (row.Cells.Count > 0)
                    txtUserId.Text = row.Cells[0].Value?.ToString() ?? "";

                // Populate fields based on available columns
                if (row.Cells.Count > 1)
                    txtUsername.Text = row.Cells[1].Value?.ToString() ?? "";
                if (row.Cells.Count > 2)
                    txtEmail.Text = row.Cells[2].Value?.ToString() ?? "";
                if (row.Cells.Count > 3)
                {
                    string roleVal = row.Cells[3].Value?.ToString() ?? "";
                    if (cmbRole.Items.Contains(roleVal))
                        cmbRole.SelectedItem = roleVal;
                    else
                        txtPassword.Text = roleVal;
                }
                if (row.Cells.Count > 4)
                    txtDepartment.Text = row.Cells[4].Value?.ToString() ?? "";
                if (row.Cells.Count > 5)
                    txtPhone.Text = row.Cells[5].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ✅ Validate inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a name/username.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) && currentTableName == "users")
            {
                MessageBox.Show("Please enter email.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidationHelper.ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) && currentTableName == "users")
            {
                MessageBox.Show("Please enter password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !ValidationHelper.ValidatePassword(txtPassword.Text))
            {
                MessageBox.Show("Password must be 8 chars with uppercase, lowercase, and numbers.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (cmbRole.SelectedItem == null && currentTableName == "users")
            {
                MessageBox.Show("Please select a role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            return true;
        }

        // ✅ Clear all fields
        private void ClearFields()
        {
            txtUserId.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtDepartment.Clear();
            txtPhone.Clear();
            cmbRole.SelectedIndex = -1;
            chkActive.Checked = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // No timer to dispose
            }
            catch { }
            base.OnFormClosing(e);
        }
    }
}