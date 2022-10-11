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
    public partial class FinancialUserControl : UserControl
    {
        public FinancialUserControl()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {

            Dashboardusercontrol dashboardusercontrol = new Dashboardusercontrol();

            MainUserControl.showControl(dashboardusercontrol, Content);

        }
    }
}
