using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ============================================================================
// FILE 4: AssignSupervisor.Designer.cs (ID: 91)
// Database: dbo.Students ↔ dbo.Supervisors (FK)
// ============================================================================

namespace ioop_GROUP_WORK.Admin
{
    partial class AssignSupervisor
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
            this.lblStudentSection = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.lblSupervisorSection = new System.Windows.Forms.Label();
            this.dgvSupervisors = new System.Windows.Forms.DataGridView();
            this.pnlAssign = new System.Windows.Forms.Panel();
            this.lblSelectSupervisor = new System.Windows.Forms.Label();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisors)).BeginInit();
            this.pnlAssign.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(251, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Assign Supervisors";
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;

            // lblStudentSection
            this.lblStudentSection.AutoSize = true;
            this.lblStudentSection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblStudentSection.Location = new System.Drawing.Point(15, 60);
            this.lblStudentSection.Name = "lblStudentSection";
            this.lblStudentSection.Size = new System.Drawing.Size(89, 19);
            this.lblStudentSection.TabIndex = 1;
            this.lblStudentSection.Text = "Students";

            // dgvStudents
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(15, 85);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(450, 200);
            this.dgvStudents.TabIndex = 2;

            // lblSupervisorSection
            this.lblSupervisorSection.AutoSize = true;
            this.lblSupervisorSection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblSupervisorSection.Location = new System.Drawing.Point(480, 60);
            this.lblSupervisorSection.Name = "lblSupervisorSection";
            this.lblSupervisorSection.Size = new System.Drawing.Size(107, 19);
            this.lblSupervisorSection.TabIndex = 3;
            this.lblSupervisorSection.Text = "Supervisors";

            // dgvSupervisors
            this.dgvSupervisors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupervisors.Location = new System.Drawing.Point(480, 85);
            this.dgvSupervisors.Name = "dgvSupervisors";
            this.dgvSupervisors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupervisors.Size = new System.Drawing.Size(450, 200);
            this.dgvSupervisors.TabIndex = 4;

            // pnlAssign
            this.pnlAssign.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAssign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAssign.Controls.Add(this.lblSelectSupervisor);
            this.pnlAssign.Controls.Add(this.cmbSupervisor);
            this.pnlAssign.Location = new System.Drawing.Point(15, 300);
            this.pnlAssign.Name = "pnlAssign";
            this.pnlAssign.Size = new System.Drawing.Size(915, 60);
            this.pnlAssign.TabIndex = 5;

            // lblSelectSupervisor
            this.lblSelectSupervisor.AutoSize = true;
            this.lblSelectSupervisor.Font = new System.Drawing.Font("Arial", 11F);
            this.lblSelectSupervisor.Location = new System.Drawing.Point(10, 15);
            this.lblSelectSupervisor.Name = "lblSelectSupervisor";
            this.lblSelectSupervisor.Size = new System.Drawing.Size(145, 17);
            this.lblSelectSupervisor.TabIndex = 0;
            this.lblSelectSupervisor.Text = "Select Supervisor:";

            // cmbSupervisor
            this.cmbSupervisor.FormattingEnabled = true;
            this.cmbSupervisor.Location = new System.Drawing.Point(170, 12);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(300, 21);
            this.cmbSupervisor.TabIndex = 1;

            // btnAssign
            this.btnAssign.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(15, 375);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(120, 35);
            this.btnAssign.TabIndex = 6;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Click += new System.EventHandler(this.BtnAssign_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.DimGray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(810, 375);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 35);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);

            // AssignSupervisor
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 420);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.pnlAssign);
            this.Controls.Add(this.dgvSupervisors);
            this.Controls.Add(this.lblSupervisorSection);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.lblStudentSection);
            this.Controls.Add(this.lblTitle);
            this.Name = "AssignSupervisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Supervisor to Students";
            this.Load += new System.EventHandler(this.AssignSupervisor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupervisors)).EndInit();
            this.pnlAssign.ResumeLayout(false);
            this.pnlAssign.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentSection;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label lblSupervisorSection;
        private System.Windows.Forms.DataGridView dgvSupervisors;
        private System.Windows.Forms.Panel pnlAssign;
        private System.Windows.Forms.Label lblSelectSupervisor;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnBack;
    }
}

