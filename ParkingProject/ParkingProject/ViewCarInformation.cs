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
    public partial class ViewCarInformation : Form
    {
        public ViewCarInformation()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            CarRegistere carRegistere = new CarRegistere();

            carRegistere.Show();
        }

       

        private void ViewCarInformation_Load(object sender, EventArgs e)
        {

            Class.dlCar dlCar = new Class.dlCar();

            bunifuDataGridView1.DataSource = null;
            
            bunifuDataGridView1.DataSource = dlCar.read();

            

        }


        public static int id;

        public static string carname;

        public static string color;

        public static string plate_number;

        public static string type;
        private void bunifuDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            id = (int)(bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value);

            carname = bunifuDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            color = bunifuDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            plate_number = bunifuDataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            type = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();



            this.Close();

        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}
