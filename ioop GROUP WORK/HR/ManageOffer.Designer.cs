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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.lstStudentDetails = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblSelectStudent = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(535, 375);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 29);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(382, 375);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(109, 29);
            this.btnReject.TabIndex = 14;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(224, 375);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(109, 29);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(59, 375);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(109, 29);
            this.btnViewReport.TabIndex = 12;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            // 
            // lstStudentDetails
            // 
            this.lstStudentDetails.FormattingEnabled = true;
            this.lstStudentDetails.ItemHeight = 16;
            this.lstStudentDetails.Location = new System.Drawing.Point(59, 155);
            this.lstStudentDetails.Name = "lstStudentDetails";
            this.lstStudentDetails.Size = new System.Drawing.Size(312, 180);
            this.lstStudentDetails.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 100);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 10;
            // 
            // lblSelectStudent
            // 
            this.lblSelectStudent.AutoSize = true;
            this.lblSelectStudent.Location = new System.Drawing.Point(56, 103);
            this.lblSelectStudent.Name = "lblSelectStudent";
            this.lblSelectStudent.Size = new System.Drawing.Size(99, 16);
            this.lblSelectStudent.TabIndex = 9;
            this.lblSelectStudent.Text = "Select Student :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(13, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 16);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Manage Internship Offers";
            // 
            // ManageOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.lstStudentDetails);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblSelectStudent);
            this.Controls.Add(this.lblTitle);
            this.Name = "ManageOffer";
            this.Text = "ManageOffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.ListBox lstStudentDetails;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblSelectStudent;
        private System.Windows.Forms.Label lblTitle;
    }
}