using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.UniSupervisor
{
    public partial class frm_Student_Table : Form
    {
        public frm_Student_Table()
        {
            InitializeComponent();
        }

        private void frm_Student_Table_Load(object sender, EventArgs e)
        {
            Show_Student_Details();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (lst_Student_Details.SelectedItem == null)
            {
                MessageBox.Show("No student selected. Please select a student from the list.");
                return;
            }

            string selectedText = lst_Student_Details.SelectedItem.ToString();
            string selectedStudentID = selectedText.Split('-')[0].Trim();

            frm_Student_Profile_Review profilePage = new Student_Profile_Review(selectedStudentID);
            profilePage.ShowDialog();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Show_Student_Details();
        }

        // 点击 “Exit” 按钮事件
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 显示学生资料列表
        private void Show_Student_Details()
        {
            lst_Student_Details.Items.Clear();

            // 调用数据库读取方法
            List<View_Student_Profile> students = View_Student_Profile.GetAllStudents();

            if (students.Count == 0)
            {
                lst_Student_Details.Items.Add("No student records found.");
                return;
            }

            // 添加到 ListBox，每项显示 "ID - Name - Course"
            foreach (var s in students)
            {
                lst_Student_Details.Items.Add($"{s.StudentID} - {s.StudentName} ({s.CourseName})");
            }
        }
    }
}