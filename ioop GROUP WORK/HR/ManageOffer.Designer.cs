namespace ioop_GROUP_WORK.HR
{
    partial class ManageOffer
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnSendOffer = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.cmbJobTitle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(552, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(865, 90);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Manage Internship Offers";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(632, 219);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(190, 25);
            this.lblPosition.TabIndex = 11;
            this.lblPosition.Text = "Position Offered :";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(700, 305);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(125, 25);
            this.lblStartDate.TabIndex = 13;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Location = new System.Drawing.Point(839, 299);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(381, 34);
            this.dtpStartDate.TabIndex = 14;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(700, 374);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(121, 25);
            this.lblEndDate.TabIndex = 15;
            this.lblEndDate.Text = "End Date :";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Location = new System.Drawing.Point(839, 374);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(381, 34);
            this.dtpEndDate.TabIndex = 16;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(535, 462);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(274, 25);
            this.lblSalary.TabIndex = 17;
            this.lblSalary.Text = "Monthly Allowance (RM):";
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalary.Location = new System.Drawing.Point(839, 459);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(271, 34);
            this.txtSalary.TabIndex = 18;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(632, 537);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(177, 25);
            this.lblDescription.TabIndex = 19;
            this.lblDescription.Text = "Job Description:";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(839, 537);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(875, 198);
            this.rtbDescription.TabIndex = 20;
            this.rtbDescription.Text = "";
            // 
            // btnSendOffer
            // 
            this.btnSendOffer.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendOffer.Location = new System.Drawing.Point(579, 783);
            this.btnSendOffer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendOffer.Name = "btnSendOffer";
            this.btnSendOffer.Size = new System.Drawing.Size(285, 65);
            this.btnSendOffer.TabIndex = 21;
            this.btnSendOffer.Text = "Send Offer";
            this.btnSendOffer.UseVisualStyleBackColor = true;
            this.btnSendOffer.Click += new System.EventHandler(this.btnSendOffer_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(935, 783);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(285, 65);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // cmbPosition
            // 
            this.cmbPosition.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(839, 211);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(256, 33);
            this.cmbPosition.TabIndex = 23;
            this.cmbPosition.SelectedIndexChanged += new System.EventHandler(this.txtPosition_SelectedIndexChanged);
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobTitle.Location = new System.Drawing.Point(714, 144);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(113, 25);
            this.lblJobTitle.TabIndex = 24;
            this.lblJobTitle.Text = "Job Title :";
            // 
            // cmbJobTitle
            // 
            this.cmbJobTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJobTitle.FormattingEnabled = true;
            this.cmbJobTitle.Items.AddRange(new object[] {
            "Management & Administration",
            "Human Resources (HR)",
            "Finance & Accounting",
            "Information Technology (IT)",
            "Sales & Marketing",
            "Production / Operations",
            "Maintenance & Support"});
            this.cmbJobTitle.Location = new System.Drawing.Point(839, 140);
            this.cmbJobTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbJobTitle.Name = "cmbJobTitle";
            this.cmbJobTitle.Size = new System.Drawing.Size(256, 33);
            this.cmbJobTitle.TabIndex = 25;
            this.cmbJobTitle.SelectedIndexChanged += new System.EventHandler(this.cbJobTitle_SelectedIndexChanged);
            // 
            // ManageOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.cmbJobTitle);
            this.Controls.Add(this.lblJobTitle);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSendOffer);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageOffer";
            this.Text = "ManageOffer";
            this.Load += new System.EventHandler(this.ManageOffer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnSendOffer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.ComboBox cmbJobTitle;
    }
}