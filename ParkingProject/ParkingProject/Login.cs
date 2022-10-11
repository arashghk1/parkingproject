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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


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


    

    
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
             cleartextbox();



            Class.dlSystemUser dlsu = new Class.dlSystemUser();

            if (dlsu.login(Usernametxtbox.Text, PasswordTextBox2.Text) == 0)
            {
                if (MessageBox.Show("User hasn't been registered. If you want to register click yes", "No user exists", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    UserRegister reg = new UserRegister();

                    reg.Show();

                }

            }
            else if (dlsu.login(Usernametxtbox.Text, PasswordTextBox2.Text) == 1)
            {
                MainForm mnf = new MainForm();

                mnf.Show();

                this.Close();
            }
            else
            {

                MessageBox.Show("Check username and password", "password and username is wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
    }
}
