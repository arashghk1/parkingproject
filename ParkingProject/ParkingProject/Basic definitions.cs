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
    public partial class Basic_definitions : UserControl
    {
        public Basic_definitions()
        {
            InitializeComponent();
        }

        

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Employeeusercontrol employeeUserControl = new Employeeusercontrol();

            MainUserControl.showControl(employeeUserControl, Content);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Systemuser_usercontrol systemuserControl = new Systemuser_usercontrol();

            MainUserControl.showControl(systemuserControl, Content);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

            Dashboardusercontrol dashboarduserControl = new Dashboardusercontrol();

            MainUserControl.showControl(dashboarduserControl, Content);

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

            ParkingregisterUsereControl parkingregisterControl = new ParkingregisterUsereControl();

            MainUserControl.showControl(parkingregisterControl, Content);

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            CustomerRegisterForm customerRegisterForm = new CustomerRegisterForm();
            customerRegisterForm.Show();

        }
    }
}
