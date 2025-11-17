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
        private string Identify;
        private string Password;
        private byte[] existingLogo;
        
        public CompanyProfile(string identify, string password)
        {
            Identify = identify;
            Password = password;
            InitializeComponent();
            
        }
        
        private void lblTitle_Click(object sender, EventArgs e)
        {
            
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
                return existingLogo; 

            using (MemoryStream ms = new MemoryStream())
            {
                
                using (Bitmap bmp = new Bitmap(pbLogo.Image))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = Identify;
            string password = Password;

            byte[] logoBytes = getPhoto();

            CP company = new CP(txtCompanyName.Text, txtContactPerson.Text, txtEmail.Text, txtPhone.Text, richTextBox1.Text, rtbDescription.Text, logoBytes);


            string result = company.SaveInfo(name, password);
            MessageBox.Show(result);

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompanyProfile_Load_1(object sender, EventArgs e)
        {
            PersonalProfile PP = new PersonalProfile(Identify, Password);
            string name = PP.getprofilename();
            string email = PP.getemail();
            string password = PP.getpassword();



            CP company = new CP(name,password);
            txtCompanyName.Text = company.Companyname;
            txtContactPerson.Text = name;
            txtEmail.Text = email;
            txtPhone.Text = company.Contactnumber;
            richTextBox1.Text = company.Address;
            rtbDescription.Text = company.Companydescription;

            existingLogo = company.CompanyLogo;
            if (existingLogo != null && existingLogo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(existingLogo))
                {
                    pbLogo.Image = new Bitmap(ms); 
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
            

            HRHome back = new HRHome(Identify,Password);
            this.Close();
            back.ShowDialog();
            
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
