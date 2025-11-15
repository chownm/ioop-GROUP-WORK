using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// FILE 2: GenerateReports.Designer.cs (ID: 88)
// Database: dbo.Applications + dbo.Companies
// ============================================================================

namespace ioop_GROUP_WORK.Admin
{
    partial class GenerateReports
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
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.lblTotalApps = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblCompanies = new System.Windows.Forms.Label();
            this.lblPendingHeader = new System.Windows.Forms.Label();
            this.dgvPendingApps = new System.Windows.Forms.DataGridView();
            this.lblActivityHeader = new System.Windows.Forms.Label();
            this.dgvActivityLogs = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingApps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Generate Reports";
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;

            // pnlStatistics
            this.pnlStatistics.BackColor = System.Drawing.Color.LightBlue;
            this.pnlStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatistics.Controls.Add(this.lblTotalApps);
            this.pnlStatistics.Controls.Add(this.lblAccepted);
            this.pnlStatistics.Controls.Add(this.lblRejected);
            this.pnlStatistics.Controls.Add(this.lblPending);
            this.pnlStatistics.Controls.Add(this.lblCompanies);
            this.pnlStatistics.Location = new System.Drawing.Point(20, 60);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Size = new System.Drawing.Size(900, 80);
            this.pnlStatistics.TabIndex = 1;

            // lblTotalApps
            this.lblTotalApps.AutoSize = true;
            this.lblTotalApps.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalApps.Location = new System.Drawing.Point(10, 10);
            this.lblTotalApps.Name = "lblTotalApps";
            this.lblTotalApps.Size = new System.Drawing.Size(130, 18);
            this.lblTotalApps.TabIndex = 0;
            this.lblTotalApps.Text = "Total Applications: 0";

            // lblAccepted
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblAccepted.Location = new System.Drawing.Point(10, 35);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(100, 18);
            this.lblAccepted.TabIndex = 1;
            this.lblAccepted.Text = "Accepted: 0";
            this.lblAccepted.ForeColor = System.Drawing.Color.Green;

            // lblRejected
            this.lblRejected.AutoSize = true;
            this.lblRejected.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblRejected.Location = new System.Drawing.Point(200, 10);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(100, 18);
            this.lblRejected.TabIndex = 2;
            this.lblRejected.Text = "Rejected: 0";
            this.lblRejected.ForeColor = System.Drawing.Color.Red;

            // lblPending
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblPending.Location = new System.Drawing.Point(200, 35);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(90, 18);
            this.lblPending.TabIndex = 3;
            this.lblPending.Text = "Pending: 0";
            this.lblPending.ForeColor = System.Drawing.Color.Orange;

            // lblCompanies
            this.lblCompanies.AutoSize = true;
            this.lblCompanies.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblCompanies.Location = new System.Drawing.Point(400, 10);
            this.lblCompanies.Name = "lblCompanies";
            this.lblCompanies.Size = new System.Drawing.Size(110, 18);
            this.lblCompanies.TabIndex = 4;
            this.lblCompanies.Text = "Companies: 0";

            // lblPendingHeader
            this.lblPendingHeader.AutoSize = true;
            this.lblPendingHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblPendingHeader.Location = new System.Drawing.Point(20, 155);
            this.lblPendingHeader.Name = "lblPendingHeader";
            this.lblPendingHeader.Size = new System.Drawing.Size(169, 19);
            this.lblPendingHeader.TabIndex = 2;
            this.lblPendingHeader.Text = "Pending Applications";

            // dgvPendingApps
            this.dgvPendingApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingApps.Location = new System.Drawing.Point(20, 180);
            this.dgvPendingApps.Name = "dgvPendingApps";
            this.dgvPendingApps.Size = new System.Drawing.Size(900, 150);
            this.dgvPendingApps.TabIndex = 3;

            // lblActivityHeader
            this.lblActivityHeader.AutoSize = true;
            this.lblActivityHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblActivityHeader.Location = new System.Drawing.Point(20, 340);
            this.lblActivityHeader.Name = "lblActivityHeader";
            this.lblActivityHeader.Size = new System.Drawing.Size(129, 19);
            this.lblActivityHeader.TabIndex = 4;
            this.lblActivityHeader.Text = "Activity Logs";

            // dgvActivityLogs
            this.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLogs.Location = new System.Drawing.Point(20, 365);
            this.dgvActivityLogs.Name = "dgvActivityLogs";
            this.dgvActivityLogs.Size = new System.Drawing.Size(900, 150);
            this.dgvActivityLogs.TabIndex = 5;

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 530);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // btnExport
            this.btnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(135, 530);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.DimGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(820, 530);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // GenerateReports
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvActivityLogs);
            this.Controls.Add(this.lblActivityHeader);
            this.Controls.Add(this.dgvPendingApps);
            this.Controls.Add(this.lblPendingHeader);
            this.Controls.Add(this.pnlStatistics);
            this.Controls.Add(this.lblTitle);
            this.Name = "GenerateReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Reports - Admin Dashboard";
            this.Load += new System.EventHandler(this.GenerateReports_Load);
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingApps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label lblTotalApps;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblCompanies;
        private System.Windows.Forms.Label lblPendingHeader;
        private System.Windows.Forms.DataGridView dgvPendingApps;
        private System.Windows.Forms.Label lblActivityHeader;
        private System.Windows.Forms.DataGridView dgvActivityLogs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBack;
    }
}

