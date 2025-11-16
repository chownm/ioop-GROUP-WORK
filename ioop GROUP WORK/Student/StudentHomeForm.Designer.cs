namespace ioop_GROUP_WORK.Student
{
    partial class StudentHomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProgress = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnApplications = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUploadReport = new System.Windows.Forms.Button();
            this.btnInternship = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Navy;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(138, 98);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(484, 70);
            this.btnProfile.TabIndex = 12;
            this.btnProfile.Text = "View Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(607, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(701, 90);
            this.label1.TabIndex = 8;
            this.label1.Text = "Student Dashboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnProgress);
            this.groupBox1.Controls.Add(this.btnFeedback);
            this.groupBox1.Controls.Add(this.btnApplications);
            this.groupBox1.Controls.Add(this.btnLogout);
            this.groupBox1.Controls.Add(this.btnUploadReport);
            this.groupBox1.Controls.Add(this.btnInternship);
            this.groupBox1.Controls.Add(this.btnProfile);
            this.groupBox1.Controls.Add(this.lblWelcome);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(576, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 765);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btnProgress
            // 
            this.btnProgress.BackColor = System.Drawing.Color.Navy;
            this.btnProgress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProgress.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgress.ForeColor = System.Drawing.Color.White;
            this.btnProgress.Location = new System.Drawing.Point(138, 557);
            this.btnProgress.Name = "btnProgress";
            this.btnProgress.Size = new System.Drawing.Size(484, 70);
            this.btnProgress.TabIndex = 18;
            this.btnProgress.Text = "View Progress";
            this.btnProgress.UseVisualStyleBackColor = false;
            this.btnProgress.Click += new System.EventHandler(this.btnProgress_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.BackColor = System.Drawing.Color.Navy;
            this.btnFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFeedback.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedback.ForeColor = System.Drawing.Color.White;
            this.btnFeedback.Location = new System.Drawing.Point(138, 465);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(484, 70);
            this.btnFeedback.TabIndex = 17;
            this.btnFeedback.Text = "View Feedback";
            this.btnFeedback.UseVisualStyleBackColor = false;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // btnApplications
            // 
            this.btnApplications.BackColor = System.Drawing.Color.Navy;
            this.btnApplications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplications.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplications.ForeColor = System.Drawing.Color.White;
            this.btnApplications.Location = new System.Drawing.Point(138, 282);
            this.btnApplications.Name = "btnApplications";
            this.btnApplications.Size = new System.Drawing.Size(484, 70);
            this.btnApplications.TabIndex = 16;
            this.btnApplications.Text = "View Application Status";
            this.btnApplications.UseVisualStyleBackColor = false;
            this.btnApplications.Click += new System.EventHandler(this.btnApplications_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Navy;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(138, 647);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(484, 70);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUploadReport
            // 
            this.btnUploadReport.BackColor = System.Drawing.Color.Navy;
            this.btnUploadReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadReport.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadReport.ForeColor = System.Drawing.Color.White;
            this.btnUploadReport.Location = new System.Drawing.Point(138, 373);
            this.btnUploadReport.Name = "btnUploadReport";
            this.btnUploadReport.Size = new System.Drawing.Size(484, 70);
            this.btnUploadReport.TabIndex = 14;
            this.btnUploadReport.Text = " Upload Report";
            this.btnUploadReport.UseVisualStyleBackColor = false;
            this.btnUploadReport.Click += new System.EventHandler(this.btnUploadReport_Click);
            // 
            // btnInternship
            // 
            this.btnInternship.BackColor = System.Drawing.Color.Navy;
            this.btnInternship.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInternship.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInternship.ForeColor = System.Drawing.Color.White;
            this.btnInternship.Location = new System.Drawing.Point(138, 190);
            this.btnInternship.Name = "btnInternship";
            this.btnInternship.Size = new System.Drawing.Size(484, 70);
            this.btnInternship.TabIndex = 13;
            this.btnInternship.Text = "Internship List";
            this.btnInternship.UseVisualStyleBackColor = false;
            this.btnInternship.Click += new System.EventHandler(this.btnInternship_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblWelcome.Location = new System.Drawing.Point(40, 49);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblWelcome.Size = new System.Drawing.Size(335, 35);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "Welcome, [StudentName]";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.Silver;
            this.btnChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePass.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.Location = new System.Drawing.Point(752, 884);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(412, 51);
            this.btnChangePass.TabIndex = 18;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // StudentHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "StudentHomeForm";
            this.Text = "Student Home";
            this.Load += new System.EventHandler(this.StudentHomeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnInternship;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnApplications;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnUploadReport;
        private System.Windows.Forms.Button btnProgress;
    }
}