namespace ioop_GROUP_WORK.Student
{
    partial class InternshipListForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpOfferDetails = new System.Windows.Forms.GroupBox();
            this.lblAllowance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.labell = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelll = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.grpOfferDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Navy;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(617, 911);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(659, 110);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(635, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 90);
            this.label1.TabIndex = 14;
            this.label1.Text = "Application Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvApplications);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(200, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 657);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // dgvApplications
            // 
            this.dgvApplications.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.GridColor = System.Drawing.Color.Gray;
            this.dgvApplications.Location = new System.Drawing.Point(17, 41);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.RowHeadersWidth = 62;
            this.dgvApplications.RowTemplate.Height = 28;
            this.dgvApplications.Size = new System.Drawing.Size(704, 600);
            this.dgvApplications.TabIndex = 0;
            this.dgvApplications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApplications_CellContentClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(234, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(247, 38);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "All Applications";
            // 
            // grpOfferDetails
            // 
            this.grpOfferDetails.Controls.Add(this.lblAllowance);
            this.grpOfferDetails.Controls.Add(this.label4);
            this.grpOfferDetails.Controls.Add(this.lblEndDate);
            this.grpOfferDetails.Controls.Add(this.lblStartDate);
            this.grpOfferDetails.Controls.Add(this.label5);
            this.grpOfferDetails.Controls.Add(this.label6);
            this.grpOfferDetails.Controls.Add(this.lblPosition);
            this.grpOfferDetails.Controls.Add(this.lblCompanyName);
            this.grpOfferDetails.Controls.Add(this.labell);
            this.grpOfferDetails.Controls.Add(this.label2);
            this.grpOfferDetails.Controls.Add(this.labelll);
            this.grpOfferDetails.Location = new System.Drawing.Point(960, 229);
            this.grpOfferDetails.Name = "grpOfferDetails";
            this.grpOfferDetails.Size = new System.Drawing.Size(741, 657);
            this.grpOfferDetails.TabIndex = 16;
            this.grpOfferDetails.TabStop = false;
            // 
            // lblAllowance
            // 
            this.lblAllowance.AutoSize = true;
            this.lblAllowance.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowance.ForeColor = System.Drawing.Color.Navy;
            this.lblAllowance.Location = new System.Drawing.Point(440, 490);
            this.lblAllowance.Name = "lblAllowance";
            this.lblAllowance.Size = new System.Drawing.Size(183, 37);
            this.lblAllowance.TabIndex = 27;
            this.lblAllowance.Text = "[Allowance]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(108, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 37);
            this.label4.TabIndex = 26;
            this.label4.Text = "Allowance (Monthly) : ";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.ForeColor = System.Drawing.Color.Navy;
            this.lblEndDate.Location = new System.Drawing.Point(282, 403);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(171, 37);
            this.lblEndDate.TabIndex = 25;
            this.lblEndDate.Text = "[End Date]";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.Navy;
            this.lblStartDate.Location = new System.Drawing.Point(282, 318);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(184, 37);
            this.lblStartDate.TabIndex = 24;
            this.lblStartDate.Text = "[Start Date]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(107, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 37);
            this.label5.TabIndex = 23;
            this.label5.Text = "End Date : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(108, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 37);
            this.label6.TabIndex = 22;
            this.label6.Text = "Start Date : ";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.Navy;
            this.lblPosition.Location = new System.Drawing.Point(282, 228);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(153, 37);
            this.lblPosition.TabIndex = 21;
            this.lblPosition.Text = "[Position]";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Navy;
            this.lblCompanyName.Location = new System.Drawing.Point(107, 147);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(257, 37);
            this.lblCompanyName.TabIndex = 20;
            this.lblCompanyName.Text = "[CompanyName]";
            // 
            // labell
            // 
            this.labell.AutoSize = true;
            this.labell.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labell.ForeColor = System.Drawing.Color.Navy;
            this.labell.Location = new System.Drawing.Point(107, 228);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(169, 37);
            this.labell.TabIndex = 19;
            this.labell.Text = "Postition : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(273, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 38);
            this.label2.TabIndex = 10;
            this.label2.Text = "Offer Details";
            // 
            // labelll
            // 
            this.labelll.AutoSize = true;
            this.labelll.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelll.ForeColor = System.Drawing.Color.Navy;
            this.labelll.Location = new System.Drawing.Point(107, 81);
            this.labelll.Name = "labelll";
            this.labelll.Size = new System.Drawing.Size(270, 37);
            this.labelll.TabIndex = 18;
            this.labelll.Text = "Company Name : ";
            // 
            // ViewApplicationStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.grpOfferDetails);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(9);
            this.Name = "ViewApplicationStatusForm";
            this.Text = "ViewApplicationStatusForm";
            this.Load += new System.EventHandler(this.ViewApplicationStatusForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.grpOfferDetails.ResumeLayout(false);
            this.grpOfferDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpOfferDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAllowance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label labell;
        private System.Windows.Forms.Label labelll;
    }
}