using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// FILE 3: ViewStatistics.Designer.cs (ID: 90)
// Database: dbo.Applications + dbo.Internships
// ============================================================================

namespace ioop_GROUP_WORK.Admin
{
    partial class ViewStatistics
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
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalApps = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblInternships = new System.Windows.Forms.Label();
            this.dgvStatistics = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(314, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "System Statistics";
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;

            // pnlStats
            this.pnlStats.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lblTotalApps);
            this.pnlStats.Controls.Add(this.lblAccepted);
            this.pnlStats.Controls.Add(this.lblRejected);
            this.pnlStats.Controls.Add(this.lblPending);
            this.pnlStats.Controls.Add(this.lblInternships);
            this.pnlStats.Location = new System.Drawing.Point(20, 60);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(820, 100);
            this.pnlStats.TabIndex = 1;

            // lblTotalApps
            this.lblTotalApps.AutoSize = true;
            this.lblTotalApps.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalApps.Location = new System.Drawing.Point(10, 10);
            this.lblTotalApps.Name = "lblTotalApps";
            this.lblTotalApps.Size = new System.Drawing.Size(150, 19);
            this.lblTotalApps.TabIndex = 0;
            this.lblTotalApps.Text = "Total Applications: 0";
            this.lblTotalApps.ForeColor = System.Drawing.Color.DarkBlue;

            // lblAccepted
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccepted.Location = new System.Drawing.Point(10, 35);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(120, 19);
            this.lblAccepted.TabIndex = 1;
            this.lblAccepted.Text = "Accepted: 0";
            this.lblAccepted.ForeColor = System.Drawing.Color.ForestGreen;

            // lblRejected
            this.lblRejected.AutoSize = true;
            this.lblRejected.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblRejected.Location = new System.Drawing.Point(10, 60);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(120, 19);
            this.lblRejected.TabIndex = 2;
            this.lblRejected.Text = "Rejected: 0";
            this.lblRejected.ForeColor = System.Drawing.Color.Crimson;

            // lblPending
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblPending.Location = new System.Drawing.Point(200, 10);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(110, 19);
            this.lblPending.TabIndex = 3;
            this.lblPending.Text = "Pending: 0";
            this.lblPending.ForeColor = System.Drawing.Color.Orange;

            // lblInternships
            this.lblInternships.AutoSize = true;
            this.lblInternships.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblInternships.Location = new System.Drawing.Point(200, 35);
            this.lblInternships.Name = "lblInternships";
            this.lblInternships.Size = new System.Drawing.Size(130, 19);
            this.lblInternships.TabIndex = 4;
            this.lblInternships.Text = "Internships: 0";
            this.lblInternships.ForeColor = System.Drawing.Color.Purple;

            // dgvStatistics
            this.dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistics.Location = new System.Drawing.Point(20, 170);
            this.dgvStatistics.Name = "dgvStatistics";
            this.dgvStatistics.Size = new System.Drawing.Size(820, 300);
            this.dgvStatistics.TabIndex = 2;

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 485);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // btnExport
            this.btnExport.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(135, 485);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.DimGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(740, 485);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ViewStatistics
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 530);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvStatistics);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.lblTitle);
            this.Name = "ViewStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Statistics - Admin";
            this.Load += new System.EventHandler(this.ViewStatistics_Load);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblTotalApps;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblInternships;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBack;
    }
}

