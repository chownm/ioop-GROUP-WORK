namespace ioop_GROUP_WORK.UniSupervisor
{
    partial class frm_Student_Internship_Progress
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_student_id = new System.Windows.Forms.Label();
            this.lbl_student_name = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_check_in_percentage = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_record_view = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_record_view)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(583, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Check In Progress";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student Name ：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 38);
            this.label3.TabIndex = 1;
            this.label3.Text = "Student ID ：";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_student_id
            // 
            this.lbl_student_id.AutoSize = true;
            this.lbl_student_id.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_student_id.Location = new System.Drawing.Point(346, 107);
            this.lbl_student_id.Name = "lbl_student_id";
            this.lbl_student_id.Size = new System.Drawing.Size(30, 38);
            this.lbl_student_id.TabIndex = 1;
            this.lbl_student_id.Text = "s";
            this.lbl_student_id.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_student_name
            // 
            this.lbl_student_name.AutoSize = true;
            this.lbl_student_name.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_student_name.Location = new System.Drawing.Point(399, 172);
            this.lbl_student_name.Name = "lbl_student_name";
            this.lbl_student_name.Size = new System.Drawing.Size(30, 38);
            this.lbl_student_name.TabIndex = 1;
            this.lbl_student_name.Text = "s";
            this.lbl_student_name.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 38);
            this.label4.TabIndex = 1;
            this.label4.Text = "Check In Record View ：";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl_check_in_percentage
            // 
            this.lbl_check_in_percentage.AutoSize = true;
            this.lbl_check_in_percentage.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_check_in_percentage.Location = new System.Drawing.Point(490, 233);
            this.lbl_check_in_percentage.Name = "lbl_check_in_percentage";
            this.lbl_check_in_percentage.Size = new System.Drawing.Size(36, 38);
            this.lbl_check_in_percentage.TabIndex = 1;
            this.lbl_check_in_percentage.Text = "S";
            this.lbl_check_in_percentage.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(215, 944);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(260, 61);
            this.btn_refresh.TabIndex = 2;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.Location = new System.Drawing.Point(1070, 944);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(260, 61);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(99, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 38);
            this.label5.TabIndex = 1;
            this.label5.Text = "Check In Percentage ：";
            this.label5.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgv_record_view
            // 
            this.dgv_record_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_record_view.Location = new System.Drawing.Point(497, 317);
            this.dgv_record_view.Name = "dgv_record_view";
            this.dgv_record_view.RowHeadersWidth = 51;
            this.dgv_record_view.RowTemplate.Height = 24;
            this.dgv_record_view.Size = new System.Drawing.Size(816, 576);
            this.dgv_record_view.TabIndex = 3;
            // 
            // frm_Student_Internship_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.dgv_record_view);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.lbl_student_name);
            this.Controls.Add(this.lbl_student_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_check_in_percentage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_Student_Internship_Progress";
            this.Text = "Student_Internship_Progress";
            this.Load += new System.EventHandler(this.frm_Student_Internship_Progress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_record_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_student_id;
        private System.Windows.Forms.Label lbl_student_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_check_in_percentage;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_record_view;
    }
}