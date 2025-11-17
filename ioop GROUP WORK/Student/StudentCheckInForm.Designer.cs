namespace ioop_GROUP_WORK.Student
{
    partial class StudentCheckInForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(625, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(634, 90);
            this.label1.TabIndex = 12;
            this.label1.Text = "Student Check-in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDateTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.lblStudentName);
            this.groupBox1.Controls.Add(this.lblStudentID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCheckIn);
            this.groupBox1.Location = new System.Drawing.Point(486, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 670);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Navy;
            this.lblDateTime.Location = new System.Drawing.Point(278, 322);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(417, 53);
            this.lblDateTime.TabIndex = 19;
            this.lblDateTime.Text = "[CurrentDateTime]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(307, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(360, 49);
            this.label7.TabIndex = 18;
            this.label7.Text = "Current Datetime ";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Navy;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(31, 554);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(888, 100);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Cancel";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentName.ForeColor = System.Drawing.Color.Navy;
            this.lblStudentName.Location = new System.Drawing.Point(307, 53);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(301, 49);
            this.lblStudentName.TabIndex = 16;
            this.lblStudentName.Text = "[StudentName]";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.Navy;
            this.lblStudentID.Location = new System.Drawing.Point(307, 142);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(241, 49);
            this.lblStudentID.TabIndex = 15;
            this.lblStudentID.Text = "[StudentID]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(33, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 49);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name          : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(33, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 49);
            this.label2.TabIndex = 13;
            this.label2.Text = "Student ID : ";
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.Navy;
            this.btnCheckIn.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(31, 448);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(888, 100);
            this.btnCheckIn.TabIndex = 12;
            this.btnCheckIn.Text = "Check-in";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // StudentCheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(9);
            this.Name = "StudentCheckInForm";
            this.Text = "Student Check-in";
            this.Load += new System.EventHandler(this.StudentCheckInForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckIn;
    }
}