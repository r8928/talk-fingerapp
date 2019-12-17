using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class ClockSelectionForm : Form
    {
        EmployeeEntry Employee;
        HelperClass hlp = HelperClass.getHelper();

        public ClockSelectionForm(EmployeeEntry emp)
        {
            InitializeComponent();

            Employee = emp;

            btn_LunchOut.Click += lunchClick;
            btn_ClockOut.Click += outClick;
            btn_LunchIn.Click += inClick;

            switch (emp.ClockStatus)
            {
                case "checkin":
                    flowLayoutPanel1.Controls.Add(btn_LunchOut);
                    flowLayoutPanel1.Controls.Add(btn_ClockOut);
                    break;
                case "lunchout":
                    flowLayoutPanel1.Controls.Add(btn_LunchIn);
                    break;
                case "lunch_back":
                    flowLayoutPanel1.Controls.Add(btn_ClockOut);
                    break;
                case "checkout":
                    flowLayoutPanel1.Controls.Add(lbl_Message);
                    lbl_Message.Text = "You are already clocked out for the day.";
                    break;
                default:
                    return;
            }

            int FormWidth = this.Width;
            int FlowWidth = flowLayoutPanel1.Width;
            flowLayoutPanel1.Left = (FormWidth / 2) - (FlowWidth / 2) - 5;
        }

        private void lunchClick(Object o, System.EventArgs e)
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