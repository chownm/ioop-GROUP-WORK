namespace ioop_GROUP_WORK.Admin
{
    partial class SystemConfiguration
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.lblStudentCount = new System.Windows.Forms.Label();
            this.lblApplicationCount = new System.Windows.Forms.Label();
            this.lblAdminCount = new System.Windows.Forms.Label();
            this.btnResetDatabase = new System.Windows.Forms.Button();
            this.btnBackupDatabase = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.groupBoxStats.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(400, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "System Configuration";
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.lblUserCount);
            this.groupBoxStats.Controls.Add(this.lblStudentCount);
            this.groupBoxStats.Controls.Add(this.lblApplicationCount);
            this.groupBoxStats.Controls.Add(this.lblAdminCount);
            this.groupBoxStats.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxStats.Location = new System.Drawing.Point(50, 90);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(400, 250);
            this.groupBoxStats.TabIndex = 1;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "System Statistics";
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCount.Location = new System.Drawing.Point(20, 40);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(150, 22);
            this.lblUserCount.TabIndex = 0;
            this.lblUserCount.Text = "Total Users: 0";
            // 
            // lblStudentCount
            // 
            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentCount.Location = new System.Drawing.Point(20, 85);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(180, 22);
            this.lblStudentCount.TabIndex = 1;
            this.lblStudentCount.Text = "Total Students: 0";
            // 
            // lblApplicationCount
            // 
            this.lblApplicationCount.AutoSize = true;
            this.lblApplicationCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationCount.Location = new System.Drawing.Point(20, 130);
            this.lblApplicationCount.Name = "lblApplicationCount";
            this.lblApplicationCount.Size = new System.Drawing.Size(220, 22);
            this.lblApplicationCount.TabIndex = 2;
            this.lblApplicationCount.Text = "Total Applications: 0";
            // 
            // lblAdminCount
            // 
            this.lblAdminCount.AutoSize = true;
            this.lblAdminCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminCount.Location = new System.Drawing.Point(20, 175);
            this.lblAdminCount.Name = "lblAdminCount";
            this.lblAdminCount.Size = new System.Drawing.Size(240, 22);
            this.lblAdminCount.TabIndex = 3;
            this.lblAdminCount.Text = "Total Administrators: 0";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnResetDatabase);
            this.groupBoxActions.Controls.Add(this.btnBackupDatabase);
            this.groupBoxActions.Controls.Add(this.btnViewLogs);
            this.groupBoxActions.Controls.Add(this.btnRefresh);
            this.groupBoxActions.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxActions.Location = new System.Drawing.Point(500, 90);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(650, 250);
            this.groupBoxActions.TabIndex = 2;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "System Actions";
            // 
            // btnResetDatabase
            // 
            this.btnResetDatabase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetDatabase.Location = new System.Drawing.Point(30, 40);
            this.btnResetDatabase.Name = "btnResetDatabase";
            this.btnResetDatabase.Size = new System.Drawing.Size(280, 45);
            this.btnResetDatabase.TabIndex = 0;
            this.btnResetDatabase.Text = "Reset Database";
            this.btnResetDatabase.UseVisualStyleBackColor = true;
            this.btnResetDatabase.Click += new System.EventHandler(this.btnResetDatabase_Click);
            // 
            // btnBackupDatabase
            // 
            this.btnBackupDatabase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupDatabase.Location = new System.Drawing.Point(340, 40);
            this.btnBackupDatabase.Name = "btnBackupDatabase";
            this.btnBackupDatabase.Size = new System.Drawing.Size(280, 45);
            this.btnBackupDatabase.TabIndex = 1;
            this.btnBackupDatabase.Text = "Backup Database";
            this.btnBackupDatabase.UseVisualStyleBackColor = true;
            this.btnBackupDatabase.Click += new System.EventHandler(this.btnBackupDatabase_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLogs.Location = new System.Drawing.Point(30, 110);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(280, 45);
            this.btnViewLogs.TabIndex = 2;
            this.btnViewLogs.Text = "View System Logs";
            this.btnViewLogs.UseVisualStyleBackColor = true;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(340, 110);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(280, 45);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh Status";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(50, 370);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.Size = new System.Drawing.Size(1100, 400);
            this.dgvLogs.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(950, 800);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 50);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SystemConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 900);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.lblTitle);
            this.Name = "SystemConfiguration";
            this.Text = "System Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.Label lblApplicationCount;
        private System.Windows.Forms.Label lblAdminCount;
        private System.Windows.Forms.Button btnResetDatabase;
        private System.Windows.Forms.Button btnBackupDatabase;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.GroupBox groupBoxActions;
    }
}