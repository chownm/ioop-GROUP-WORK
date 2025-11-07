using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ioop_GROUP_WORK;

namespace ioop_GROUP_WORK
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            ArrayList names = StudentV2.ViewAll();

            foreach (var item in names)
            {
                lstStudent.Items.Add(item);
            }
        }
    }
}
