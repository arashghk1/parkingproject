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
    public partial class ParkingOfficeUserControl : UserControl
    {
        public ParkingOfficeUserControl()
        {
            InitializeComponent();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            ParkingOffice_EntranceInvoice parkingOffice_EntranceInvoice = new ParkingOffice_EntranceInvoice();

            parkingOffice_EntranceInvoice.Show();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            ParkingOffice_AdvancedSearchForm advancedSearchForm = new ParkingOffice_AdvancedSearchForm();

            advancedSearchForm.Show();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Dashboardusercontrol dashboardusercontrol = new Dashboardusercontrol();

            MainUserControl.showControl(dashboardusercontrol, Content);
        }

      

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {

            ParkingOffice_Rates parkingOffice_Rates = new ParkingOffice_Rates();

            parkingOffice_Rates.Show();


        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            ParkingOffice_InternalFinancial parkingOffice_InternalFinancial = new ParkingOffice_InternalFinancial();

            parkingOffice_InternalFinancial.Show();
        }
    }
}
