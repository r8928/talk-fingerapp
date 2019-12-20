using InputBoxApp;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class AdminForm : Form
    {
        private HelperClass hlp;
        private MessageClass msg;
        private HttpService http;
        private AppData app;

        public AdminForm(AppData app, HelperClass hlp, HttpService http, MessageClass msg)
        {
            InitializeComponent();

            this.app = app;
            this.hlp = hlp;
            this.msg = msg;
            this.http = http;

            chk_Debugging.Checked = HttpService.HttpDebuging;
            chk_RequireFinger.Checked = app.FingerValidationEnabled;
        }

        private async void btn_RegisterApp_Click(object sender, EventArgs e)
        {

            InputBoxResult SapID = InputBox.Show("Please enter the 4 digit SAP ID.", "SAP");

            if (String.IsNullOrEmpty(SapID.Text))
            {
                return;
            }

            HttpResponse res = null;
            await Task.Run(() => { res = http.Post("finger/registerapp", hlp.getHardwareIds(SapID.Text)); });
            
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

        private void chk_RequireFinger_CheckedChanged(object sender, EventArgs e)
        {
            app.FingerValidationEnabled = chk_RequireFinger.Checked;
        }
    }
}
