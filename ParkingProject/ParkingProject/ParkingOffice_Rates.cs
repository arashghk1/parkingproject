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
    public partial class ParkingOffice_Rates : Form
    {
        public ParkingOffice_Rates()
        {
            InitializeComponent();
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Car_For_Showing_Car_Info car_For_Showing_Car_Info = new Car_For_Showing_Car_Info();

            car_For_Showing_Car_Info.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        Class.dlRates dlRates = new Class.dlRates();
        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            try
            {
                Class.Rates rates = new Class.Rates();

                rates.rateType = RatetypeTextBox1.Text;

                rates.price = Convert.ToDouble(priceTextBox2.Text);

                rates.description = descriptionTextBox3.Text;

                dlRates.register(rates);

                MessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cleartextbox();
            }
            catch 
            {
                MessageBox.Show("Registration Failiure. Fill all the fields please", "Failiure", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }





        }
    }
}
