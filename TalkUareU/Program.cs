using System;
using System.Windows.Forms;

namespace TalkUareU
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HttpService http = new HttpService();
            MessageClass msg = new MessageClass();
            HelperClass hlp = new HelperClass();

            http.msg = msg;
            http.hlp = hlp;
            http.p = Properties.Settings.Default;

            hlp.msg = msg;
            hlp.http = http;

            Application.Run(new MainForm(hlp, http, msg));
        }
    }
}
