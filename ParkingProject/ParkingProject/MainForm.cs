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
    public partial class MainForm : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
           Basic_definitions basic_Definitions = new Basic_definitions();

            MainUserControl.showControl(basic_Definitions, Content);

           
            
        }

      

        private void MainForm_Load(object sender, EventArgs e)
        {

            Dashboardusercontrol dashboardusercontrol = new Dashboardusercontrol();

            MainUserControl.showControl(dashboardusercontrol, Content);

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            ParkingOfficeUserControl parkingOfficeUserControl = new ParkingOfficeUserControl();

            MainUserControl.showControl(parkingOfficeUserControl, Content);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            if ((MessageBox.Show("Are you sure you want to exit?", "Exit program", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                Application.Exit();

            }
        }

        
        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            FinancialUserControl financialUserControl = new FinancialUserControl();

            MainUserControl.showControl(financialUserControl, Content);
        }
    }
}
