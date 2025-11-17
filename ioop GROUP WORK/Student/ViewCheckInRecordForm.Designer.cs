namespace ioop_GROUP_WORK.Student
{
    partial class ViewCheckInRecordForm
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
            this.btnDone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.labell = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.Navy;
            this.btnDone.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(581, 788);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(741, 110);
            this.btnDone.TabIndex = 20;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(657, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(618, 90);
            this.label1.TabIndex = 18;
            this.label1.Text = "Check-in Record";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRecords);
            this.groupBox1.Controls.Add(this.labell);
            this.groupBox1.Location = new System.Drawing.Point(581, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 541);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // dgvRecords
            // 
            this.dgvRecords.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.GridColor = System.Drawing.Color.Gray;
            this.dgvRecords.Location = new System.Drawing.Point(20, 51);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.RowHeadersWidth = 62;
            this.dgvRecords.RowTemplate.Height = 28;
            this.dgvRecords.Size = new System.Drawing.Size(704, 466);
            this.dgvRecords.TabIndex = 0;
            // 
            // labell
            // 
            this.labell.AutoSize = true;
            this.labell.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labell.Location = new System.Drawing.Point(299, 0);
            this.labell.Name = "labell";
            this.labell.Size = new System.Drawing.Size(136, 38);
            this.labell.TabIndex = 10;
            this.labell.Text = "Records";
            // 
            // ViewCheckInRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 49F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(9);
            this.Name = "ViewCheckInRecordForm";
            this.Text = "View Progress";
            this.Load += new System.EventHandler(this.ViewCheckInRecordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Label labell;
    }
}