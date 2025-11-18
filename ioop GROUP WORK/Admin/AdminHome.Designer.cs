using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ioop_GROUP_WORK.Admin
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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnManageRecruiters = new System.Windows.Forms.Button();
            this.btnAssignSupervisors = new System.Windows.Forms.Button();
            this.btnGenerateReports = new System.Windows.Forms.Button();
            this.btnViewStatistics = new System.Windows.Forms.Button();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Administrator Dashboard";

            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 10F);
            this.lblWelcome.Location = new System.Drawing.Point(12, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(105, 13);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Admin";

            // Buttons Panel
            int btnY = 100;
            int btnX = 12;
            int btnWidth = 120;
            int btnHeight = 30;
            int spacing = 15;

            // 
            // btnManageUsers
            // 
            this.btnManageUsers.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageUsers.ForeColor = System.Drawing.Color.White;
            this.btnManageUsers.Location = new System.Drawing.Point(btnX, btnY);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnManageUsers.TabIndex = 3;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = false;
            this.btnManageUsers.Click += new System.EventHandler(this.BtnManageUsers_Click);

            // 
            // btnManageRecruiters
            // 
            this.btnManageRecruiters.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnManageRecruiters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageRecruiters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageRecruiters.ForeColor = System.Drawing.Color.White;
            this.btnManageRecruiters.Location = new System.Drawing.Point(btnX + btnWidth + spacing, btnY);
            this.btnManageRecruiters.Name = "btnManageRecruiters";
            this.btnManageRecruiters.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnManageRecruiters.TabIndex = 4;
            this.btnManageRecruiters.Text = "Manage Recruiters";
            this.btnManageRecruiters.UseVisualStyleBackColor = false;
            this.btnManageRecruiters.Click += new System.EventHandler(this.BtnManageRecruiters_Click);

            // 
            // btnAssignSupervisors
            // 
            this.btnAssignSupervisors.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAssignSupervisors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignSupervisors.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnAssignSupervisors.ForeColor = System.Drawing.Color.White;
            this.btnAssignSupervisors.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 2, btnY);
            this.btnAssignSupervisors.Name = "btnAssignSupervisors";
            this.btnAssignSupervisors.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnAssignSupervisors.TabIndex = 5;
            this.btnAssignSupervisors.Text = "Assign Supervisors";
            this.btnAssignSupervisors.UseVisualStyleBackColor = false;
            this.btnAssignSupervisors.Click += new System.EventHandler(this.BtnAssignSupervisors_Click);

            // 
            // btnGenerateReports
            // 
            this.btnGenerateReports.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGenerateReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReports.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReports.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReports.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 3, btnY);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnGenerateReports.TabIndex = 6;
            this.btnGenerateReports.Text = "Generate Reports";
            this.btnGenerateReports.UseVisualStyleBackColor = false;
            this.btnGenerateReports.Click += new System.EventHandler(this.BtnGenerateReports_Click);

            // 
            // btnViewStatistics
            // 
            this.btnViewStatistics.BackColor = System.Drawing.Color.ForestGreen;
            this.btnViewStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStatistics.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewStatistics.ForeColor = System.Drawing.Color.White;
            this.btnViewStatistics.Location = new System.Drawing.Point(btnX, btnY + btnHeight + spacing);
            this.btnViewStatistics.Name = "btnViewStatistics";
            this.btnViewStatistics.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnViewStatistics.TabIndex = 7;
            this.btnViewStatistics.Text = "View Statistics";
            this.btnViewStatistics.UseVisualStyleBackColor = false;
            this.btnViewStatistics.Click += new System.EventHandler(this.BtnViewStatistics_Click);

            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSystemConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnSystemConfig.ForeColor = System.Drawing.Color.White;
            this.btnSystemConfig.Location = new System.Drawing.Point(btnX + btnWidth + spacing, btnY + btnHeight + spacing);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnSystemConfig.TabIndex = 8;
            this.btnSystemConfig.Text = "System Config";
            this.btnSystemConfig.UseVisualStyleBackColor = false;
            this.btnSystemConfig.Click += new System.EventHandler(this.BtnSystemConfig_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 2, btnY + btnHeight + spacing);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Crimson;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(btnX + (btnWidth + spacing) * 3, btnY + btnHeight + spacing);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            // 
            // AdminHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 300);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSystemConfig);
            this.Controls.Add(this.btnViewStatistics);
            this.Controls.Add(this.btnGenerateReports);
            this.Controls.Add(this.btnAssignSupervisors);
            this.Controls.Add(this.btnManageRecruiters);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Name = "AdminHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Dashboard";
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
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
