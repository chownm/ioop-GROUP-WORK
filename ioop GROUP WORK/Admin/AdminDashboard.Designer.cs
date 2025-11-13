namespace InternshipTrackerSystem.Forms.Administrator
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblAccessLevel;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageRecruiters;
        private System.Windows.Forms.Button btnAssignSupervisors;
        private System.Windows.Forms.Button btnGenerateReports;
        private System.Windows.Forms.Button btnViewApplications;
        private System.Windows.Forms.Button btnSystemSettings;
        private System.Windows.Forms.Button btnAuditLogs;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox grpUserStats;
        private System.Windows.Forms.GroupBox grpSystemStats;
        private System.Windows.Forms.Label lblTotalUsersLabel;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblTotalStudentsLabel;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblTotalCompaniesLabel;
        private System.Windows.Forms.Label lblTotalCompanies;
        private System.Windows.Forms.Label lblTotalRecruitersLabel;
        private System.Windows.Forms.Label lblTotalRecruiters;
        private System.Windows.Forms.Label lblTotalSupervisorsLabel;
        private System.Windows.Forms.Label lblTotalSupervisors;
        private System.Windows.Forms.Label lblTotalInternshipsLabel;
        private System.Windows.Forms.Label lblTotalInternships;
        private System.Windows.Forms.Label lblTotalApplicationsLabel;
        private System.Windows.Forms.Label lblTotalApplications;
        private System.Windows.Forms.Label lblPendingAppsLabel;
        private System.Windows.Forms.Label lblPendingApplications;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAccessLevel = new System.Windows.Forms.Label();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManageRecruiters = new System.Windows.Forms.Button();
            this.btnAssignSupervisors = new System.Windows.Forms.Button();
            this.btnGenerateReports = new System.Windows.Forms.Button();
            this.btnViewApplications = new System.Windows.Forms.Button();
            this.btnSystemSettings = new System.Windows.Forms.Button();
            this.btnAuditLogs = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpUserStats = new System.Windows.Forms.GroupBox();
            this.grpSystemStats = new System.Windows.Forms.GroupBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.pnlSidebar.Controls.Add(this.lblWelcome);
            this.pnlSidebar.Controls.Add(this.lblAccessLevel);
            this.pnlSidebar.Controls.Add(this.btnManageUsers);
            this.pnlSidebar.Controls.Add(this.btnManageRecruiters);
            this.pnlSidebar.Controls.Add(this.btnAssignSupervisors);
            this.pnlSidebar.Controls.Add(this.btnGenerateReports);
            this.pnlSidebar.Controls.Add(this.btnViewApplications);
            this.pnlSidebar.Controls.Add(this.btnSystemSettings);
            this.pnlSidebar.Controls.Add(this.btnAuditLogs);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(250, 700);

            // lblWelcome
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(10, 20);
            this.lblWelcome.Size = new System.Drawing.Size(230, 50);
            this.lblWelcome.Text = "Welcome, Administrator!";

            // lblAccessLevel
            this.lblAccessLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccessLevel.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccessLevel.Location = new System.Drawing.Point(10, 70);
            this.lblAccessLevel.Size = new System.Drawing.Size(230, 20);
            this.lblAccessLevel.Text = "Access: Full";

            // btnManageUsers
            this.btnManageUsers.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.Location = new System.Drawing.Point(10, 110);
            this.btnManageUsers.Size = new System.Drawing.Size(230, 45);
            this.btnManageUsers.Text = "👥 Manage Users";
            this.btnManageUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);

            // btnManageRecruiters
            this.btnManageRecruiters.BackColor = System.Drawing.Color.FromArgb(62, 62, 66);
            this.btnManageRecruiters.FlatAppearance.BorderSize = 0;
            this.btnManageRecruiters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageRecruiters.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManageRecruiters.ForeColor = System.Drawing.Color.White;
            this.btnManageRecruiters.Location = new System.Drawing.Point(10, 165);
            this.btnManageRecruiters.Size = new System.Drawing.Size(230, 45);
            this.btnManageRecruiters.Text = "👔 Manage Recruiters";
            this.btnManageRecruiters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageRecruiters.Click += new System.EventHandler(this.btnManageRecruiters_Click);

            // btnAssignSupervisors
            this.btnAssignSupervisors.BackColor = System.Drawing.Color.FromArgb(62, 62, 66);
            this.btnAssignSupervisors.FlatAppearance.BorderSize = 0;
            this.btnAssignSupervisors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignSupervisors.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAssignSupervisors.ForeColor = System.Drawing.Color.White;
            this.btnAssignSupervisors.Location = new System.Drawing.Point(10, 220);
            this.btnAssignSupervisors.Size = new System.Drawing.Size(230, 45);
            this.btnAssignSupervisors.Text = "🎓 Assign Supervisors";
            this.btnAssignSupervisors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignSupervisors.Click += new System.EventHandler(this.btnAssignSupervisors_Click);

            // btnGenerateReports
            this.btnGenerateReports.BackColor = System.Drawing.Color.FromArgb(62, 62, 66);
            this.btnGenerateReports.FlatAppearance.BorderSize = 0;
            this.btnGenerateReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenerateReports.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReports.Location = new System.Drawing.Point(10, 275);
            this.btnGenerateReports.Size = new System.Drawing.Size(230, 45);
            this.btnGenerateReports.Text = "📊 Generate Reports";
            this.btnGenerateReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateReports.Click += new System.EventHandler(this.btnGenerateReports_Click);

            // btnViewApplications
            this.btnViewApplications.BackColor = System.Drawing.Color.FromArgb(62, 62, 66);
            this.btnViewApplications.FlatAppearance.BorderSize = 0;
            this.btnViewApplications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewApplications.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewApplications.ForeColor = System.Drawing.Color.White;
            this.btnViewApplications.Location = new System.Drawing.Point(10, 330);
            this.btnViewApplications.Size = new System.Drawing.Size(230, 45);
            this.btnViewApplications.Text = "📝 View Applications";
            this.btnViewApplications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewApplications.Click += new System.EventHandler(this.btnViewApplications_Click);

            // btnSystemSettings
            this.btnSystemSettings.BackColor = System.Drawing.Color.FromArgb(62, 62, 66);
            this.btnSystemSettings.FlatAppearance.BorderSize = 0;
            this.btnSystemSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemSettings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSystemSettings.ForeColor = System.Drawing.Color.White;
            this.btnSystemSettings.Location = new System.Drawing.Point(10, 385);
            this.btnSystemSettings.Size = new System.Drawing.Size(230, 45);
            this.btnSystemSettings.Text = "⚙️ System Settings";
            this.btnSystemSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemSettings.Click += new System.EventHandler(this.btnSystemSettings_Click);

            // btnAuditLogs
            this.btnAuditLogs.BackColor = System.Drawing.Color.FromArgb(62, 62, 66);
            this.btnAuditLogs.FlatAppearance.BorderSize = 0;
            this.btnAuditLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAuditLogs.ForeColor = System.Drawing.Color.White;
            this.btnAuditLogs.Location = new System.Drawing.Point(10, 440);
            this.btnAuditLogs.Size = new System.Drawing.Size(230, 45);
            this.btnAuditLogs.Text = "🔍 Audit Logs";
            this.btnAuditLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditLogs.Click += new System.EventHandler(this.btnAuditLogs_Click);

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(10, 640);
            this.btnLogout.Size = new System.Drawing.Size(230, 45);
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Controls.Add(this.grpUserStats);
            this.pnlContent.Controls.Add(this.grpSystemStats);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(950, 700);

            // grpUserStats & grpSystemStats setup would go here

            // AdminDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Dashboard - Internship Tracker";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}