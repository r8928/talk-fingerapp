using InputBoxApp;
using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class AdminForm : Form
    {
        HelperClass hlp;

        public AdminForm(HelperClass hlp)
        {
            InitializeComponent();

            this.hlp = hlp;
            chk_Debugging.Checked = http.HttpDebuging;
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
                hlp.msg.success((string)res.json["message"]);
            }
            else
            {
                http.StdErr(res);
            }
        }

        private void chk_Debugging_CheckedChanged(object sender, EventArgs e)
        {
            http.HttpDebuging = chk_Debugging.Checked;
        }
    }
}
