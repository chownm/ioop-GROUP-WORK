using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// FILE 5: ManageRecruiters.Designer.cs (ID: 92)
// Database: dbo.Recruiters + dbo.Companies + dbo.Users (JOINs)
// ============================================================================

namespace ioop_GROUP_WORK.Admin
{
    partial class ManageRecruiters
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
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.dgvRecruiters = new System.Windows.Forms.DataGridView();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRecruiterName = new System.Windows.Forms.Label();
            this.txtRecruiterName = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecruiters)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(243, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Recruiters";
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;

            // lblCompany
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Arial", 11F);
            this.lblCompany.Location = new System.Drawing.Point(15, 50);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(68, 17);
            this.lblCompany.TabIndex = 1;
            this.lblCompany.Text = "Company:";

            // cmbCompany
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(120, 47);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(250, 21);
            this.cmbCompany.TabIndex = 2;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);

            // dgvRecruiters
            this.dgvRecruiters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecruiters.Location = new System.Drawing.Point(15, 80);
            this.dgvRecruiters.Name = "dgvRecruiters";
            this.dgvRecruiters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecruiters.Size = new System.Drawing.Size(920, 180);
            this.dgvRecruiters.TabIndex = 3;

            // pnlForm
            this.pnlForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Location = new System.Drawing.Point(15, 270);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(920, 140);
            this.pnlForm.TabIndex = 4;

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(10, 10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 14);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(100, 7);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(150, 20);
            this.txtUsername.TabIndex = 1;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(270, 10);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 14);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(360, 7);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 3;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(530, 10);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 14);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(620, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 5;

            // lblRecruiterName
            this.lblRecruiterName.AutoSize = true;
            this.lblRecruiterName.Location = new System.Drawing.Point(10, 40);
            this.lblRecruiterName.Name = "lblRecruiterName";
            this.lblRecruiterName.Size = new System.Drawing.Size(92, 14);
            this.lblRecruiterName.TabIndex = 6;
            this.lblRecruiterName.Text = "Recruiter Name:";

            // txtRecruiterName
            this.txtRecruiterName.Location = new System.Drawing.Point(100, 37);
            this.txtRecruiterName.Name = "txtRecruiterName";
            this.txtRecruiterName.Size = new System.Drawing.Size(150, 20);
            this.txtRecruiterName.TabIndex = 7;

            // lblPosition
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(270, 40);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(53, 14);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "Position:";

            // txtPosition
            this.txtPosition.Location = new System.Drawing.Point(360, 37);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(150, 20);
            this.txtPosition.TabIndex = 9;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(530, 40);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(48, 14);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Phone:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(620, 37);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(120, 20);
            this.txtPhone.TabIndex = 11;

            // Add controls to pnlForm
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblRecruiterName);
            this.pnlForm.Controls.Add(this.txtRecruiterName);
            this.pnlForm.Controls.Add(this.lblPosition);
            this.pnlForm.Controls.Add(this.txtPosition);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.txtPhone);

            // btnCreate
            this.btnCreate.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(15, 420);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 35);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(150, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.DimGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(815, 420);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 35);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ManageRecruiters
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 470);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.dgvRecruiters);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblTitle);
            this.Name = "ManageRecruiters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Recruiters";
            this.Load += new System.EventHandler(this.ManageRecruiters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecruiters)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.DataGridView dgvRecruiters;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRecruiterName;
        private System.Windows.Forms.TextBox txtRecruiterName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}

