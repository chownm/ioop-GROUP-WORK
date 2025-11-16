// ============================================================================
// UniSupervisorHome.Designer.cs - FIX (Move Review Student button ABOVE)
// ============================================================================

namespace ioop_GROUP_WORK.UniSupervisor
{
    partial class frm_UniSupervisorHome
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
            this.btn_evaluate_form_load = new System.Windows.Forms.Button();
            this.btn_internship_progress_load = new System.Windows.Forms.Button();
            this.btn_manage_profile_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(807, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "!!! Welcome to University Supervisor Home !!!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1187, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "You may click the button to choose the functionalities what you need :";
            // 
            // btn_evaluate_form_load
            // 
            this.btn_evaluate_form_load.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_evaluate_form_load.Location = new System.Drawing.Point(511, 215);
            this.btn_evaluate_form_load.Name = "btn_evaluate_form_load";
            this.btn_evaluate_form_load.Size = new System.Drawing.Size(428, 61);
            this.btn_evaluate_form_load.TabIndex = 1;
            this.btn_evaluate_form_load.Text = "Evaluate Student";
            this.btn_evaluate_form_load.UseVisualStyleBackColor = true;
            this.btn_evaluate_form_load.Click += new System.EventHandler(this.btn_evaluate_form_load_Click);
            // 
            // btn_manage_profile_load
            // 
            // ✅ FIX: MOVE "Review Student" ABOVE "Check Student Internship Progress" (Y=310)
            this.btn_manage_profile_load.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manage_profile_load.Location = new System.Drawing.Point(407, 310);
            this.btn_manage_profile_load.Name = "btn_manage_profile_load";
            this.btn_manage_profile_load.Size = new System.Drawing.Size(658, 68);
            this.btn_manage_profile_load.TabIndex = 1;
            this.btn_manage_profile_load.Text = "Review Student";
            this.btn_manage_profile_load.UseVisualStyleBackColor = true;
            this.btn_manage_profile_load.Click += new System.EventHandler(this.btn_manage_profile_load_Click);
            // 
            // btn_internship_progress_load
            // 
            // ✅ FIX: KEEP "Check Student Internship Progress" BELOW (Y=400)
            this.btn_internship_progress_load.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_internship_progress_load.Location = new System.Drawing.Point(407, 400);
            this.btn_internship_progress_load.Name = "btn_internship_progress_load";
            this.btn_internship_progress_load.Size = new System.Drawing.Size(658, 68);
            this.btn_internship_progress_load.TabIndex = 1;
            this.btn_internship_progress_load.Text = "Check Student Internship Progress";
            this.btn_internship_progress_load.UseVisualStyleBackColor = true;
            this.btn_internship_progress_load.Click += new System.EventHandler(this.btn_internship_progress_load_Click);

            // 
            // frm_UniSupervisorHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.btn_internship_progress_load);
            this.Controls.Add(this.btn_manage_profile_load);
            this.Controls.Add(this.btn_evaluate_form_load);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_UniSupervisorHome";
            this.Text = "UniSupervisorHome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_evaluate_form_load;
        private System.Windows.Forms.Button btn_internship_progress_load;
        private System.Windows.Forms.Button btn_manage_profile_load;
    }
}
