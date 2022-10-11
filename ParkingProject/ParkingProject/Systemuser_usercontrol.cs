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
    public partial class Systemuser_usercontrol : UserControl
    {
        public Systemuser_usercontrol()
        {
            InitializeComponent();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Permission_Form permission_form = new Permission_Form();

            permission_form.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Basic_definitions basic_Definitions = new Basic_definitions();

            MainUserControl.showControl(basic_Definitions, Content);
        }
    }
}
