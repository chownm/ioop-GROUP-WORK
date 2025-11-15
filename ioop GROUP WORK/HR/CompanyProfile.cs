using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ioop_GROUP_WORK.HR
{
    public partial class CompanyProfile : Form
    {
        public CompanyProfile()
        {
            InitializeComponent();
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {
            // 如果不需要可留空
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CompanyProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void txtContactPerson_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog  = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {      
                pbLogo.Image = Image.FromFile(openFileDialog.FileName);
                pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private byte[] getPhoto()
        {
            if (pbLogo.Image == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                pbLogo.Image.Save(ms, pbLogo.Image.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PersonalProfile PP = new PersonalProfile();
            string name = PP.getname();
            string password = PP.getpassword();

            byte[] logoBytes = getPhoto();

            CP company = new CP(txtCompanyName.Text, txtContactPerson.Text, txtEmail.Text, txtPhone.Text, richTextBox1.Text, rtbDescription.Text, logoBytes);


           MessageBox.Show(company.SaveInfo(name, password));
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompanyProfile_Load_1(object sender, EventArgs e)
        {
            PersonalProfile PP = new PersonalProfile();
            string name = PP.getname();
            string password = PP.getpassword();

            CP company = new CP(name,password);
            txtCompanyName.Text = company.Companyname;
            txtContactPerson.Text = company.Contactperson;
            txtEmail.Text = company.Email;
            txtPhone.Text = company.Contactnumber;
            richTextBox1.Text = company.Address;
            rtbDescription.Text = company.Companydescription;

            if (company.CompanyLogo != null)
            {
                using (MemoryStream ms = new MemoryStream(company.CompanyLogo))
                {
                    pbLogo.Image = Image.FromStream(ms);
                    pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pbLogo.Image = null;
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            

            HRHome back = new HRHome();
            this.Close();
            back.ShowDialog();
            
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
