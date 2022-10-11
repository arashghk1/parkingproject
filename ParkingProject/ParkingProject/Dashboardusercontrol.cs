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
    public partial class Dashboardusercontrol : UserControl
    {
        public Dashboardusercontrol()
        {
            InitializeComponent();
        }

       

        private void Dashboardusercontrol_Load(object sender, EventArgs e)
        {
            timer1.Start();


        }

        DateTime dt = DateTime.Now;
        private void timer1_Tick(object sender, EventArgs e)
        {
           

            circularProgressBar1.Text = dt.Hour.ToString("00") + " : " + dt.Minute.ToString("00");

            circularProgressBar1.Value = dt.Second;

            string dayofweek = dt.Date.ToString("ddd");

            string dayofmonth = dt.Date.ToString("dd");

            string month = dt.Date.ToString("MMMM");

            string year = dt.Date.ToString("yyyy");

            Label1.Text = dayofmonth + " / " + dayofweek;

            Label2.Text = year + " / " + month + " : ";

            Label3.Text = dt.Second.ToString("00");

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            ViewCustomerInformation viewCustomerInformation = new ViewCustomerInformation();

            viewCustomerInformation.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            ViewCarInformation viewCarInformation = new ViewCarInformation();

            viewCarInformation.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Main main = new Main();

            main.invoice_number = Convert.ToInt64(InvoiceIDTextBox4.Text);

            main.time = dt.Hour.ToString("00") + ":" + dt.Minute.ToString("00") + ":" + dt.Second.ToString("00");

            main.date = dt.Date.ToString("D");

            main.invoice_flag = true;


        }
    }
}
