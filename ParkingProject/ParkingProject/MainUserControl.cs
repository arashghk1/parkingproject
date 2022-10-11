using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject
{
    public class MainUserControl
    {

        public static void showControl(System.Windows.Forms.Control control, System.Windows.Forms.Control content)
        {

            content.Controls.Clear();

            control.Dock = System.Windows.Forms.DockStyle.Fill;

            control.BringToFront();

            control.Focus();

            content.Controls.Add(control);

        }

    }
}
