using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeEntry1_Click(object sender, EventArgs e)
        {
            employeeEntry1.ClockStatus = "123456";
            employeeEntry1.EmpName = "asdf";
        }

        private void employeeEntry1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
