using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityTransportWork
{
    public partial class DriverForm : Form
    {
       
        public DriverForm()
        {
            InitializeComponent();
        }
        public int user_ID;
        
        private void DriverForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DriverSchedule driverSchedule = new DriverSchedule();
            driverSchedule.user_ID = user_ID;
            driverSchedule.Show();
        }
    }
}
