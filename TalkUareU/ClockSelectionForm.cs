using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class ClockSelectionForm : Form
    {
        JsonItem data;
        HelperClass hlp;
        HttpService http;
        MessageClass msg;
        AppData app;

        public ClockSelectionForm(JsonItem data, AppData app, HelperClass hlp, HttpService http, MessageClass msg)
        {
            InitializeComponent();

            this.app = app;
            this.hlp = hlp;
            this.http = http;
            this.msg = msg;
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

        private bool verifyCurrentStatus()
        {
            // GET CHECKED IN REPS LISTING
            HttpResponse res = http.Get("finger/checkedreps?sap=" + app.LocationSap + "&punch_id=" + data.punch_id);

            if (res.ok && res.hasJson && res.resp.Contains("sap_id"))
            {
                var item = res.json["data"][0];

                return ((string)item["status"] == data.Status);
            }
            else return false;
        }


        private void lunchClick(Object o, System.EventArgs e)
        {
            if (!verifyCurrentStatus())
            {
                msg.error("An unknown error occured, please press refresh and try again");
                return;
            }
            hlp.clockRequest(data, "lunch_clockout");
            this.Close();
        }

        private void inClick(Object o, System.EventArgs e)
        {
            if (!verifyCurrentStatus())
            {
                msg.error("An unknown error occured, please press refresh and try again");
                return;
            }
            hlp.clockRequest(data, "lunch_back");
            this.Close();
        }
        private void outClick(Object o, System.EventArgs e)
        {
            if (!verifyCurrentStatus())
            {
                msg.error("An unknown error occured, please press refresh and try again");
                return;
            }
            hlp.clockRequest(data, "day_clockout");
            this.Close();
        }
    }
}