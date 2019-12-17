using InputBoxApp;
using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class AdminForm : Form
    {
        HelperClass hlp;
        MessageClass msg;
        HttpService http;

        public AdminForm(HelperClass hlp, HttpService http, MessageClass msg)
        {
            InitializeComponent();

            this.hlp = hlp;
            this.msg = msg;
            this.http = http;

            chk_Debugging.Checked = HttpService.HttpDebuging;
        }

        private void btn_RegisterApp_Click(object sender, EventArgs e)
        {

            InputBoxResult SapID = InputBox.Show("Please enter the 4 digit SAP ID.", "SAP");

            if (String.IsNullOrEmpty(SapID.Text))
            {
                return;
            }

            HttpResponse res = http.Post("finger/registerapp", hlp.getHardwareIds(SapID.Text));

            if (res.ok && res.hasJson)
            {
                msg.success((string)res.json["message"]);
            }
            else
            {
                http.StdErr(res);
            }
        }

        private void chk_Debugging_CheckedChanged(object sender, EventArgs e)
        {
            HttpService.HttpDebuging = chk_Debugging.Checked;
        }
    }
}
