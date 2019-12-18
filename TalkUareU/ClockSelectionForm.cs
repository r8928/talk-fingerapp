using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class ClockSelectionForm : Form
    {
        private JsonItem data;
        private HelperClass hlp;
        private HttpService http;
        private MessageClass msg;
        private AppData app;

        public ClockSelectionForm(JsonItem data, AppData app, HelperClass hlp, HttpService http, MessageClass msg)
        {
            InitializeComponent();

            this.app = app;
            this.hlp = hlp;
            this.http = http;
            this.msg = msg;
            this.data = data;


            btn_LunchOut.Click += lunchOutClick;
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

        private bool preClockChecks()
        {
            if (!getUpdatedRepStatus())
            {
                return false;
            }


            if (!hlp.validateFinger(app, data))
            {
                return false;
            }

            return true;
        }

        private bool getUpdatedRepStatus()
        {
            // GET CHECKED IN REPS LISTING
            HttpResponse res = http.Get("finger/checkedreps?sap=" + app.LocationSap + "&punch_id=" + data.punch_id);

            if (res.ok && res.hasJson && res.resp.Contains("sap_id"))
            {
                var item = res.json["data"][0];

                bool matched = ((string)item["status"] == data.Status);

                if (!matched)
                {
                    msg.error("An unknown error occured, please press refresh and try again");
                }

                return matched;
            }
            else return false;
        }

        private void lunchOutClick(Object o, System.EventArgs e)
        {
            if (preClockChecks())
            {
                hlp.clockRequest(data, "lunch_clockout");
                this.Close();
                this.Dispose();
            }

        }

        private void inClick(Object o, System.EventArgs e)
        {
            if (preClockChecks())
            {
                hlp.clockRequest(data, "lunch_back");
                this.Close();
                this.Dispose();
            }
        }

        private void outClick(Object o, System.EventArgs e)
        {
            if (preClockChecks())
            {
                hlp.clockRequest(data, "day_clockout");
                this.Close();
                this.Dispose();
            }
        }

    }
}