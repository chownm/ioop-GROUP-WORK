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
            ArrayList name = new ArrayList();

            name = Student.viewAll();
            foreach (var item in name)
            {
                lstStudent.Items.Add(item);
            }
        }
    }
}
