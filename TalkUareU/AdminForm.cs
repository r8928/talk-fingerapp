using InputBoxApp;
using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class AdminForm : Form
    {
        HelperClass hlp = HelperClass.getHelper();

        public AdminForm()
        {
            InitializeComponent();
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
            }
            else
            {
                if (res.hasJson)
                {
                    hlp.msg.success((string)res.json["message"]);
                }
                else
                {
                    hlp.msg.error("Unknown error");
                }
            }
        }

        private void chk_Debugging_CheckedChanged(object sender, EventArgs e)
        {
            http.HttpDebuging = (bool) chk_Debugging.Checked;
        }
    }
}
