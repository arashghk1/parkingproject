using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoxLearn.License;

namespace ParkingProject
{
    public partial class UserRegister : Form
    {
        public UserRegister()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        Class.dlSystemUser dlsysu = new Class.dlSystemUser();
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Class.SystemUser sysu = new Class.SystemUser();

            if (fullnameTextBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Full name field is required. Please fill it.", "Field empty", MessageBoxButtons.OK, MessageBoxIcon.Error);

                fullnameTextBox2.Focus();
            }

            

            else if (usernameTextBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Username field is required. Please fill it.", "Field empty", MessageBoxButtons.OK, MessageBoxIcon.Error);

                usernameTextBox4.Focus();
            }

            else if (passwordTextBox6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Password field is required. Please fill it.", "Field empty", MessageBoxButtons.OK, MessageBoxIcon.Error);

                passwordTextBox6.Focus();
            }

            else
            {
                if (passwordTextBox6.Text == RepeatpasswordTextBox7.Text)
                {
                    sysu.fullName = fullnameTextBox2.Text;

                    sysu.username = usernameTextBox4.Text;

                    sysu.password = passwordTextBox6.Text;

                    if (TypeuserDropdown1.SelectedIndex == 0)
                    {
                        sysu.typeUser = Class.SystemUser.typeOfRoleSystem.regular_user;
                    }
                    else if (TypeuserDropdown1.SelectedIndex == 1)
                    {
                        sysu.typeUser = Class.SystemUser.typeOfRoleSystem.admin;
                    }

                    dlsysu.register(sysu);

                    MessageBox.Show("Register successful", "Registeration success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Password and its repeated password don't match", "Repeat password not matching", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }




        } 

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            KeyManager km = new KeyManager(SystemIDTextBox1.Text);

            string ProductKey = ProductKeyTextBox3.Text;

            if (km.ValidKey(ref ProductKey) == true)
            {

                KeyValuesClass kvc = new KeyValuesClass();

                if (km.DisassembleKey(ProductKey, ref kvc))
                {
                    LicenseInfo li = new LicenseInfo();

                    li.ProductKey = ProductKey;

                    li.FullName = "Parking account license activation";

                    if (kvc.Type == LicenseType.TRIAL)
                    {
                        li.Day = kvc.Expiration.Day;
                        li.Month = kvc.Expiration.Month;
                        li.Year = kvc.Expiration.Year;
                    }
                    km.SaveSuretyFile( string.Format(@"{0}\license information.lic", Application.StartupPath) , li );

                    MessageBox.Show("License activation successful", "Activation success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    bunifuGroupBox2.Enabled = true;
                }
                else
                {
                    if (MessageBox.Show("License activation Unsuccessful.\nWould you like to exit program? ", "Activation Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
                    {
                        Application.Exit();
                    }
                    
                }

            }

        }
    }
}
