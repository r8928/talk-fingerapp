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
        EmployeeEntry Employee;

        public Form1(EmployeeEntry emp)
        {
            InitializeComponent();

            Employee = emp;

            switch (emp.ClockStatus)
            {
                case "in":
                    flowLayoutPanel1.Controls.Add(btn_LunchOut);
                    flowLayoutPanel1.Controls.Add(btn_ClockOut);
                    break;
                case "lunch":
                    flowLayoutPanel1.Controls.Add(btn_LunchIn);
                    break;
                case "out":
                    flowLayoutPanel1.Controls.Add(lbl_Message);
                    lbl_Message.Text = "You are already clocked out for the day.";
                    break;
                default:
                    return;
            }

            int FormWidth = this.Width;
            int FlowWidth = flowLayoutPanel1.Width;
            flowLayoutPanel1.Left = (FormWidth / 2) - (FlowWidth / 2) -5;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
