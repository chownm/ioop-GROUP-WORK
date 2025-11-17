using System;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.Student
{
    public partial class ChangePasswordForm : Form
    {
        private string studentID;
        private ChangePassword changePasswordLogic;

        public ChangePasswordForm(string id)
        {
            InitializeComponent();
            studentID = id ?? "";
            lblDisUsername.Text = studentID;

            changePasswordLogic = new ChangePassword(studentID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass?.Text?.Trim() ?? "";
            string newPass = txtNewPass?.Text?.Trim() ?? "";
            string confirm = txtNewPass2?.Text?.Trim() ?? "";

            string resultMessage = changePasswordLogic.ChangePasswordProcess(oldPass, newPass, confirm);

            MessageBox.Show(resultMessage);

            if (resultMessage == "Password changed successfully!")
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
