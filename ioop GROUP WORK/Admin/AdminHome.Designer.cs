// ============================================================================
// FILE: AdminHome.Designer.cs
// Purpose: Designer for AdminHome dashboard
// ============================================================================

namespace ioop_GROUP_WORK
{
    partial class AdminHome
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblTotalCompanies = new System.Windows.Forms.Label();
            this.lblTotalRecruiters = new System.Windows.Forms.Label();
            this.lblPendingApplications = new System.Windows.Forms.Label();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManageRecruiters = new System.Windows.Forms.Button();
            this.btnAssignSupervisors = new System.Windows.Forms.Button();
            this.btnGenerateReports = new System.Windows.Forms.Button();
            this.btnViewStatistics = new System.Windows.Forms.Button();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.groupBoxStats.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Administrator Dashboard";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(12, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(105, 13);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Admin";

            // groupBoxStats
            this.groupBoxStats.Controls.Add(this.lblTotalUsers);
            this.groupBoxStats.Controls.Add(this.lblTotalStudents);
            this.groupBoxStats.Controls.Add(this.lblTotalCompanies);
            this.groupBoxStats.Controls.Add(this.lblTotalRecruiters);
            this.groupBoxStats.Controls.Add(this.lblPendingApplications);
            this.groupBoxStats.Location = new System.Drawing.Point(12, 80);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(776, 100);
            this.groupBoxStats.TabIndex = 2;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "System Statistics";

            // lblTotalUsers
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.Location = new System.Drawing.Point(6, 25);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(67, 13);
            this.lblTotalUsers.TabIndex = 0;
            this.lblTotalUsers.Text = "Total Users: 0";

            // lblTotalStudents
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Location = new System.Drawing.Point(6, 50);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(81, 13);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "Total Students: 0";

            // lblTotalCompanies
            this.lblTotalCompanies.AutoSize = true;
            this.lblTotalCompanies.Location = new System.Drawing.Point(200, 25);
            this.lblTotalCompanies.Name = "lblTotalCompanies";
            this.lblTotalCompanies.Size = new System.Drawing.Size(89, 13);
            this.lblTotalCompanies.TabIndex = 2;
            this.lblTotalCompanies.Text = "Total Companies: 0";

            // lblTotalRecruiters
            this.lblTotalRecruiters.AutoSize = true;
            this.lblTotalRecruiters.Location = new System.Drawing.Point(200, 50);
            this.lblTotalRecruiters.Name = "lblTotalRecruiters";
            this.lblTotalRecruiters.Size = new System.Drawing.Size(83, 13);
            this.lblTotalRecruiters.TabIndex = 3;
            this.lblTotalRecruiters.Text = "Total Recruiters: 0";

            // lblPendingApplications
            this.lblPendingApplications.AutoSize = true;
            this.lblPendingApplications.Location = new System.Drawing.Point(400, 25);
            this.lblPendingApplications.Name = "lblPendingApplications";
            this.lblPendingApplications.Size = new System.Drawing.Size(110, 13);
            this.lblPendingApplications.TabIndex = 4;
            this.lblPendingApplications.Text = "Pending Applications: 0";

            // Buttons Panel
            int btnY = 200;
            int btnX = 12;
            int btnWidth = 120;
            int btnHeight = 30;
            int spacing = 15;

            // btnManageUsers
            this.btnManageUsers.Location = new System.Drawing.Point(btnX, btnY);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnManageUsers.TabIndex = 3;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.BtnManageUsers_Click);

            // btnManageRecruiters
            this.btnManageRecruiters.Location = new System.Drawing.Point(btnX + btnWidth + spacing, btnY);
            this.btnManageRecruiters.Name = "btnManageRecruiters";
            this.btnManageRecruiters.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnManageRecruiters.TabIndex = 4;
            this.btnManageRecruiters.Text = "Manage Recruiters";
            this.btnManageRecruiters.UseVisualStyleBackColor = true;
            this.btnManageRecruiters.Click += new System.EventHandler(this.BtnManageRecruiters_Click);

            // btnAssignSupervisors
            this.btnAssignSupervisors.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 2, btnY);
            this.btnAssignSupervisors.Name = "btnAssignSupervisors";
            this.btnAssignSupervisors.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnAssignSupervisors.TabIndex = 5;
            this.btnAssignSupervisors.Text = "Assign Supervisors";
            this.btnAssignSupervisors.UseVisualStyleBackColor = true;
            this.btnAssignSupervisors.Click += new System.EventHandler(this.BtnAssignSupervisors_Click);

            // btnGenerateReports
            this.btnGenerateReports.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 3, btnY);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnGenerateReports.TabIndex = 6;
            this.btnGenerateReports.Text = "Generate Reports";
            this.btnGenerateReports.UseVisualStyleBackColor = true;
            this.btnGenerateReports.Click += new System.EventHandler(this.BtnGenerateReports_Click);

            // btnViewStatistics
            this.btnViewStatistics.Location = new System.Drawing.Point(btnX, btnY + btnHeight + spacing);
            this.btnViewStatistics.Name = "btnViewStatistics";
            this.btnViewStatistics.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnViewStatistics.TabIndex = 7;
            this.btnViewStatistics.Text = "View Statistics";
            this.btnViewStatistics.UseVisualStyleBackColor = true;
            this.btnViewStatistics.Click += new System.EventHandler(this.BtnViewStatistics_Click);

            // btnSystemConfig
            this.btnSystemConfig.Location = new System.Drawing.Point(btnX + btnWidth + spacing, btnY + btnHeight + spacing);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnSystemConfig.TabIndex = 8;
            this.btnSystemConfig.Text = "System Config";
            this.btnSystemConfig.UseVisualStyleBackColor = true;
            this.btnSystemConfig.Click += new System.EventHandler(this.BtnSystemConfig_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 2, btnY + btnHeight + spacing);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 3, btnY + btnHeight + spacing);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            // AdminHome
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSystemConfig);
            this.Controls.Add(this.btnViewStatistics);
            this.Controls.Add(this.btnGenerateReports);
            this.Controls.Add(this.btnAssignSupervisors);
            this.Controls.Add(this.btnManageRecruiters);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Name = "AdminHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Dashboard";
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblTotalCompanies;
        private System.Windows.Forms.Label lblTotalRecruiters;
        private System.Windows.Forms.Label lblPendingApplications;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageRecruiters;
        private System.Windows.Forms.Button btnAssignSupervisors;
        private System.Windows.Forms.Button btnGenerateReports;
        private System.Windows.Forms.Button btnViewStatistics;
        private System.Windows.Forms.Button btnSystemConfig;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
    }
}