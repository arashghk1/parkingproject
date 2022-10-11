using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingProject
{
    public partial class Systemuser_registerform : Form
    {
        public Systemuser_registerform()
        {
            InitializeComponent();
        }

        Class.dlSystemUser dlSystemUser = new Class.dlSystemUser();

        public void cleartextbox(bool search = true)
        {
            Action<Control.ControlCollection, bool> cleartextboxes = null;

            cleartextboxes = (controls, searchch) =>
            {
                foreach (Control item in controls)
                {

                    Bunifu.UI.WinForms.BunifuTextBox tx = new Bunifu.UI.WinForms.BunifuTextBox();

                    tx = item as Bunifu.UI.WinForms.BunifuTextBox;

                    tx?.Clear();

                    if (searchch && item.HasChildren)
                    {

                        cleartextboxes(item.Controls, true);

                    }

                }
            };

            cleartextboxes(this.Controls, search);



        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            

            try
            {
                Class.SystemUser systemUser = new Class.SystemUser();

                systemUser.fullName = FirstnameTextBox1.Text;

                systemUser.username = usernameTextBox3.Text;

                systemUser.password = passwordTextBox4.Text;

                if (usertypeDropdown1.SelectedIndex == 0)
                {
                    systemUser.typeUser = Class.SystemUser.typeOfRoleSystem.regular_user;
                }
                else if (usertypeDropdown1.SelectedIndex == 1)
                {
                    systemUser.typeUser = Class.SystemUser.typeOfRoleSystem.admin;
                }

                dlSystemUser.register(systemUser);

                MessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cleartextbox();
            }
            catch 
            {
                MessageBox.Show("All fields are required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
            
            

            
    }
}
