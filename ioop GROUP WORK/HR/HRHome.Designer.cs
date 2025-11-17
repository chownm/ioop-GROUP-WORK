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
            this.btnPersonalProfile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(581, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(830, 90);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome To HR Home !";
            // 
            // btnViewApplications
            // 
            this.btnViewApplications.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewApplications.Location = new System.Drawing.Point(680, 304);
            this.btnViewApplications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewApplications.Name = "btnViewApplications";
            this.btnViewApplications.Size = new System.Drawing.Size(589, 92);
            this.btnViewApplications.TabIndex = 2;
            this.btnViewApplications.Text = "View Applications";
            this.btnViewApplications.UseVisualStyleBackColor = true;
            this.btnViewApplications.Click += new System.EventHandler(this.btnViewApplications_Click);
            // 
            // btnManageOffers
            // 
            this.btnManageOffers.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageOffers.Location = new System.Drawing.Point(680, 423);
            this.btnManageOffers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageOffers.Name = "btnManageOffers";
            this.btnManageOffers.Size = new System.Drawing.Size(589, 97);
            this.btnManageOffers.TabIndex = 3;
            this.btnManageOffers.Text = "Manage Offers";
            this.btnManageOffers.UseVisualStyleBackColor = true;
            this.btnManageOffers.Click += new System.EventHandler(this.btnManageOffers_Click);
            // 
            // btnCompanyProfile
            // 
            this.btnCompanyProfile.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompanyProfile.Location = new System.Drawing.Point(680, 544);
            this.btnCompanyProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCompanyProfile.Name = "btnCompanyProfile";
            this.btnCompanyProfile.Size = new System.Drawing.Size(589, 85);
            this.btnCompanyProfile.TabIndex = 4;
            this.btnCompanyProfile.Text = "Company Profile";
            this.btnCompanyProfile.UseVisualStyleBackColor = true;
            this.btnCompanyProfile.Click += new System.EventHandler(this.btnCompanyProfile_Click);
            // 
            // btnPersonalProfile
            // 
            this.btnPersonalProfile.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonalProfile.Location = new System.Drawing.Point(680, 663);
            this.btnPersonalProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPersonalProfile.Name = "btnPersonalProfile";
            this.btnPersonalProfile.Size = new System.Drawing.Size(589, 92);
            this.btnPersonalProfile.TabIndex = 6;
            this.btnPersonalProfile.Text = "Change Personal Profile";
            this.btnPersonalProfile.UseVisualStyleBackColor = true;
            this.btnPersonalProfile.Click += new System.EventHandler(this.btnPersonalProfile_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(680, 793);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(589, 89);
            this.button1.TabIndex = 7;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HRHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(2404, 1325);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPersonalProfile);
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
        private System.Windows.Forms.Button btnPersonalProfile;
        private System.Windows.Forms.Button button1;
    }
}