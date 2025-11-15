namespace ioop_GROUP_WORK.UniSupervisor
{
    partial class frm_Evaluation_Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.txt_performance_mark = new System.Windows.Forms.TextBox();
            this.txt_communication_mark = new System.Windows.Forms.TextBox();
            this.txt_punctuality_mark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rtxt_descriptions = new System.Windows.Forms.RichTextBox();
            this.cmb_studentName_studentID = new System.Windows.Forms.ComboBox();
            this.cmb_position = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.dtp_datetime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(767, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Evaluation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "Position :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "Student ID | Student Name :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(162, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(751, 37);
            this.label5.TabIndex = 1;
            this.label5.Text = "Enter the information below to proceed your evaluation :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(670, 37);
            this.label6.TabIndex = 1;
            this.label6.Text = "Marking Schemes (every attributes is up to 100%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(291, 380);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 37);
            this.label7.TabIndex = 1;
            this.label7.Text = "Performance :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(162, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(325, 37);
            this.label8.TabIndex = 1;
            this.label8.Text = "Communication Skills :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(310, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 37);
            this.label9.TabIndex = 1;
            this.label9.Text = "Punctuality :";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(298, 934);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(224, 52);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(1040, 934);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(224, 52);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // txt_performance_mark
            // 
            this.txt_performance_mark.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_performance_mark.Location = new System.Drawing.Point(515, 376);
            this.txt_performance_mark.Name = "txt_performance_mark";
            this.txt_performance_mark.Size = new System.Drawing.Size(341, 45);
            this.txt_performance_mark.TabIndex = 3;
            // 
            // txt_communication_mark
            // 
            this.txt_communication_mark.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_communication_mark.Location = new System.Drawing.Point(515, 429);
            this.txt_communication_mark.Name = "txt_communication_mark";
            this.txt_communication_mark.Size = new System.Drawing.Size(341, 45);
            this.txt_communication_mark.TabIndex = 3;
            // 
            // txt_punctuality_mark
            // 
            this.txt_punctuality_mark.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_punctuality_mark.Location = new System.Drawing.Point(515, 482);
            this.txt_punctuality_mark.Name = "txt_punctuality_mark";
            this.txt_punctuality_mark.Size = new System.Drawing.Size(341, 45);
            this.txt_punctuality_mark.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(293, 552);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 37);
            this.label10.TabIndex = 1;
            this.label10.Text = "Descriptions :";
            // 
            // rtxt_descriptions
            // 
            this.rtxt_descriptions.Location = new System.Drawing.Point(515, 552);
            this.rtxt_descriptions.Name = "rtxt_descriptions";
            this.rtxt_descriptions.Size = new System.Drawing.Size(1021, 309);
            this.rtxt_descriptions.TabIndex = 4;
            this.rtxt_descriptions.Text = "";
            // 
            // cmb_studentName_studentID
            // 
            this.cmb_studentName_studentID.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_studentName_studentID.FormattingEnabled = true;
            this.cmb_studentName_studentID.Location = new System.Drawing.Point(602, 128);
            this.cmb_studentName_studentID.Name = "cmb_studentName_studentID";
            this.cmb_studentName_studentID.Size = new System.Drawing.Size(413, 45);
            this.cmb_studentName_studentID.TabIndex = 5;
            // 
            // cmb_position
            // 
            this.cmb_position.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_position.FormattingEnabled = true;
            this.cmb_position.Location = new System.Drawing.Point(602, 192);
            this.cmb_position.Name = "cmb_position";
            this.cmb_position.Size = new System.Drawing.Size(413, 45);
            this.cmb_position.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "DateTime :";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(663, 934);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(224, 52);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // dtp_datetime
            // 
            this.dtp_datetime.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_datetime.Location = new System.Drawing.Point(602, 260);
            this.dtp_datetime.Name = "dtp_datetime";
            this.dtp_datetime.Size = new System.Drawing.Size(503, 45);
            this.dtp_datetime.TabIndex = 6;
            // 
            // frm_Evaluation_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.dtp_datetime);
            this.Controls.Add(this.cmb_position);
            this.Controls.Add(this.cmb_studentName_studentID);
            this.Controls.Add(this.rtxt_descriptions);
            this.Controls.Add(this.txt_punctuality_mark);
            this.Controls.Add(this.txt_communication_mark);
            this.Controls.Add(this.txt_performance_mark);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frm_Evaluation_Form";
            this.Text = "Evaluation_Form";
            this.Load += new System.EventHandler(this.frm_Evaluation_From_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TextBox txt_performance_mark;
        private System.Windows.Forms.TextBox txt_communication_mark;
        private System.Windows.Forms.TextBox txt_punctuality_mark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtxt_descriptions;
        private System.Windows.Forms.ComboBox cmb_studentName_studentID;
        private System.Windows.Forms.ComboBox cmb_position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DateTimePicker dtp_datetime;
    }
}