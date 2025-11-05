namespace ioop_GROUP_WORK
{
    partial class HRHome
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewApplications = new System.Windows.Forms.Button();
            this.btnManageOffers = new System.Windows.Forms.Button();
            this.btnCompanyProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome HR!";
            // 
            // btnViewApplications
            // 
            this.btnViewApplications.Location = new System.Drawing.Point(46, 222);
            this.btnViewApplications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewApplications.Name = "btnViewApplications";
            this.btnViewApplications.Size = new System.Drawing.Size(103, 37);
            this.btnViewApplications.TabIndex = 2;
            this.btnViewApplications.Text = "View Applications";
            this.btnViewApplications.UseVisualStyleBackColor = true;
            this.btnViewApplications.Click += new System.EventHandler(this.btnViewApplications_Click);
            // 
            // btnManageOffers
            // 
            this.btnManageOffers.Location = new System.Drawing.Point(175, 222);
            this.btnManageOffers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManageOffers.Name = "btnManageOffers";
            this.btnManageOffers.Size = new System.Drawing.Size(103, 37);
            this.btnManageOffers.TabIndex = 3;
            this.btnManageOffers.Text = "Manage Offers";
            this.btnManageOffers.UseVisualStyleBackColor = true;
            // 
            // btnCompanyProfile
            // 
            this.btnCompanyProfile.Location = new System.Drawing.Point(305, 222);
            this.btnCompanyProfile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCompanyProfile.Name = "btnCompanyProfile";
            this.btnCompanyProfile.Size = new System.Drawing.Size(103, 37);
            this.btnCompanyProfile.TabIndex = 4;
            this.btnCompanyProfile.Text = "Company Profile";
            this.btnCompanyProfile.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(435, 222);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(103, 37);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // HRHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCompanyProfile);
            this.Controls.Add(this.btnManageOffers);
            this.Controls.Add(this.btnViewApplications);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HRHome";
            this.Text = "HRHome";
            this.Load += new System.EventHandler(this.HRHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewApplications;
        private System.Windows.Forms.Button btnManageOffers;
        private System.Windows.Forms.Button btnCompanyProfile;
        private System.Windows.Forms.Button btnLogout;
    }
}