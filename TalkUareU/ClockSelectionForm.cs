using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class ClockSelectionForm : Form
    {
        JsonItem data;
        HelperClass hlp;

        public ClockSelectionForm(JsonItem data, HelperClass hlp)
        {
            InitializeComponent();

            this.hlp = hlp;
            this.data = data;


            btn_LunchOut.Click += lunchClick;
            btn_ClockOut.Click += outClick;
            btn_LunchIn.Click += inClick;

            switch (data.Status)
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
            hlp.clockRequest(data, "lunch_clockout");
            this.Close();
        }

        private void inClick(Object o, System.EventArgs e)
        {
            hlp.clockRequest(data, "lunch_back");
            this.Close();
        }
        private void outClick(Object o, System.EventArgs e)
        {
            hlp.clockRequest(data, "day_clockout");
            this.Close();
        }
    }
}