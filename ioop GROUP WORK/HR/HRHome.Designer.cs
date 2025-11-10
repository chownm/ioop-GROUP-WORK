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
            this.label2.Location = new System.Drawing.Point(292, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome HR!";
            // 
            // btnViewApplications
            // 
            this.btnViewApplications.Location = new System.Drawing.Point(61, 273);
            this.btnViewApplications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewApplications.Name = "btnViewApplications";
            this.btnViewApplications.Size = new System.Drawing.Size(137, 46);
            this.btnViewApplications.TabIndex = 2;
            this.btnViewApplications.Text = "View Applications";
            this.btnViewApplications.UseVisualStyleBackColor = true;
            this.btnViewApplications.Click += new System.EventHandler(this.btnViewApplications_Click);
            // 
            // btnManageOffers
            // 
            this.btnManageOffers.Location = new System.Drawing.Point(233, 273);
            this.btnManageOffers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageOffers.Name = "btnManageOffers";
            this.btnManageOffers.Size = new System.Drawing.Size(137, 46);
            this.btnManageOffers.TabIndex = 3;
            this.btnManageOffers.Text = "Manage Offers";
            this.btnManageOffers.UseVisualStyleBackColor = true;
            // 
            // btnCompanyProfile
            // 
            this.btnCompanyProfile.Location = new System.Drawing.Point(407, 273);
            this.btnCompanyProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompanyProfile.Name = "btnCompanyProfile";
            this.btnCompanyProfile.Size = new System.Drawing.Size(137, 46);
            this.btnCompanyProfile.TabIndex = 4;
            this.btnCompanyProfile.Text = "Company Profile";
            this.btnCompanyProfile.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(580, 273);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(137, 46);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // HRHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCompanyProfile);
            this.Controls.Add(this.btnManageOffers);
            this.Controls.Add(this.btnViewApplications);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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