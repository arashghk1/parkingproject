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
    public partial class CarRegistere : Form
    {
        public CarRegistere()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region StaticField

        public static string carName;
        public static string plate;
        public static string color;
        public static string type;

        #endregion

        Class.dlCar dlCar = new Class.dlCar();  
        Class.dlCustomer dlCustomer = new Class.dlCustomer();

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

            try
            {
                if (carnameTextBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Car Name is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carnameTextBox1.Focus();
                }
                else if (platenumbereTextBox2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Plate number is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    platenumbereTextBox2.Focus();
                }
                else
                {
                    Class.Car car = new Class.Car();


                    CustomerRegisterForm form = new CustomerRegisterForm();

                    car.name = carnameTextBox1.Text;

                    car.color = colorTextBox3.Text;

                    car.plate_number = platenumbereTextBox2.Text;

                    if (cartypeDropdown1.SelectedIndex == 0)
                    {
                        car.type = Class.Car.typeCar.RegularCar;
                    }
                    else if (cartypeDropdown1.SelectedIndex == 1)
                    {
                        car.type = Class.Car.typeCar.Motorcycle;
                    }
                    else if (cartypeDropdown1.SelectedIndex == 2)
                    {
                        car.type = Class.Car.typeCar.Trucks;

                    }

                    carName = carnameTextBox1.Text;

                    plate = platenumbereTextBox2.Text;

                    color = colorTextBox3.Text;

                    //type = cartypeDropdown1.SelectedText;

                    Class.Customer customer = new Class.Customer();

                    customer.firstName = CustomerRegisterForm.firstname;

                    customer.familyName = CustomerRegisterForm.lastname;

                    customer.codeMelli = CustomerRegisterForm.codemelli;

                    customer.phone_number = CustomerRegisterForm.telephonenumber;

                    car.customer = customer;

                    customer.cars.Add(car);
              
                    MessageBox.Show("Register success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                }
            }
            catch 
            {
                MessageBox.Show("Register failiure.", "Failiure", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }







        }
    }
}
