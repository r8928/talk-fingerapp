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
    public partial class ClockSelectionForm : Form
    {
        EmployeeEntry Employee;
        HelperClass hlp = new HelperClass();

        public ClockSelectionForm(EmployeeEntry emp)
        {
            InitializeComponent();

            Employee = emp;

            btn_LunchOut.Click += lunchClick;
            btn_ClockOut.Click += outClick;
            btn_LunchIn.Click += inClick;

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

        private void lunchClick(Object o,System.EventArgs e)
        {
            hlp.clockRequest(Employee, "lunch_clockout");
            this.Close();
        }

        private void inClick(Object o, System.EventArgs e)
        {
            hlp.clockRequest(Employee, "lunch_back");
            this.Close();
        }
        private void outClick(Object o, System.EventArgs e)
        {
            hlp.clockRequest(Employee, "day_clockout");
            this.Close();
        }
    }
}
