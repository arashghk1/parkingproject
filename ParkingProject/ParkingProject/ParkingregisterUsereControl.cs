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
    public partial class ParkingregisterUsereControl : UserControl
    {
        public ParkingregisterUsereControl()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            Basic_definitions basic_Definitions = new Basic_definitions();

            MainUserControl.showControl(basic_Definitions, Content);

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (nameTextBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Parking Name is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (capacityTextBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Parking Capacity is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Class.Parking parking = new Class.Parking();
                Class.dlParking dlparking = new Class.dlParking();
                parking.name = nameTextBox1.Text;
                parking.capacity = Convert.ToInt32(capacityTextBox2.Text);
                parking.operatingHours = operatinghoursTextBox3.Text;
                parking.number = numberTextBox4.Text;
                parking.address = addressTextBox5.Text;
                parking.description = descriptionTextBox6.Text;

                if (typeofparkingDropdown1.SelectedIndex == 0)
                {
                    parking.type = Class.Parking.typeOfParking.public_parking;
                }
                else if (typeofparkingDropdown1.SelectedIndex == 1)
                {
                    parking.type = Class.Parking.typeOfParking.private_parking;
                }
                else if (typeofparkingDropdown1.SelectedIndex == 2)
                {
                    parking.type = Class.Parking.typeOfParking.organizational_parking;
                }

                dlparking.register(parking);

                MessageBox.Show("Parking Registration success", "Registration successful", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }







        }
    }
}
