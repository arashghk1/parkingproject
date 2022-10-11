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
    public partial class Employeeusercontrol : UserControl
    {
        public Employeeusercontrol()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Basic_definitions basic_Definitions = new Basic_definitions();

            MainUserControl.showControl(basic_Definitions, Content);
        }

        Class.dlEmployee dlemployee = new Class.dlEmployee();
        private void bunifuButton3_Click(object sender, EventArgs e)
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
                else if (employeeidTextBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Employee ID is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    employeeidTextBox1.Focus();
                }
                else if (salaryTextBox4.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Salary is required.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    salaryTextBox4.Focus();
                }
                else
                {
                    Class.Employee employee = new Class.Employee();

                    employee.firstName = FirstNameTextBox4.Text;

                    employee.familyName = lastNameTextBox5.Text;

                    employee.employee_ID = Convert.ToInt64(employeeidTextBox1.Text);

                    employee.age = Convert.ToByte(ageTextBox2.Text);

                    employee.codeMelli = codemelliTextBox3.Text;

                    employee.salary_Monthly = Convert.ToInt64(salaryTextBox4.Text);

                    if (employeetypeDropdown1.SelectedIndex == 0)
                    {
                        employee.type = Class.Employee.typeOfRole.regular_employee;
                    }
                    else if (employeetypeDropdown1.SelectedIndex == 1)
                    {
                        employee.type = Class.Employee.typeOfRole.manager_of_parking;
                    }
                    else if (employeetypeDropdown1.SelectedIndex == 2)
                    {
                        employee.type = Class.Employee.typeOfRole.owner_of_parking;
                    }

                    dlemployee.register(employee);

                    MessageBox.Show("Registration successful.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch 
            {

                MessageBox.Show("Registration Failiure", "Failiure", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }





        }
    }
}
