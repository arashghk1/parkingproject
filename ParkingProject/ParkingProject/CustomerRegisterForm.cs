using ParkingProject.Class;
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
    public partial class CustomerRegisterForm : Form
    {


        public CustomerRegisterForm()
        {
            InitializeComponent();
        }


        #region StaticField

        public static string firstname;
        public static string lastname;
        public static string codemelli;
        public static string telephonenumber;

        #endregion
        private void bunifuButton7_Click(object sender, EventArgs e)
        {

            ViewCarInformation viewCarInformation = new ViewCarInformation();

            viewCarInformation.Show();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        Class.dlCustomer dlCustomer = new Class.dlCustomer();

        Class.dlCar dlCar = new Class.dlCar();

        CarRegistere CarRegistere = new CarRegistere();
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (FirstNameTextBox4.Text.Trim().Length == 0)
                {
                    MessageBox.Show("First Name is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    FirstNameTextBox4.Focus();
                }
                else if (lastNameTextBox5.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Family Name is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    lastNameTextBox5.Focus();
                }

                else
                {
                    Class.Customer customer = new Class.Customer();


                    customer.firstName = FirstNameTextBox4.Text;

                    customer.familyName = lastNameTextBox5.Text;

                    customer.codeMelli = codemelliTextBox6.Text;

                    customer.phone_number = phonenumberTextBox7.Text;

                    firstname = FirstNameTextBox4.Text;

                    lastname = lastNameTextBox5.Text;

                    codemelli = codemelliTextBox6.Text;

                    telephonenumber = phonenumberTextBox7.Text;


                    

                    Class.Car car = new Class.Car();

                    car.name = CarRegistere.carName;

                    car.plate_number = CarRegistere.plate;

                    car.color = CarRegistere.color;

                    //car.type = CarRegistere.type;

                    customer.cars.Add(car);

                    car.customer = customer;

                    dlCustomer.register(customer);
                   

                   dlCar.register(car);

                    MessageBox.Show("Registration successful.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

            }
            catch(Exception ex)
            {

                MessageBox.Show("Registration Failed", "Failiure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);

            }

        }

        private void CustomerRegisterForm_Activated(object sender, EventArgs e)
        {

            CarinformationTextBox1.Text = ViewCarInformation.carname;

        }
    }
}
