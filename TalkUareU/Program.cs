using System;
using System.Windows.Forms;

namespace TalkUareU
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppData app = new AppData();
            HttpService http = new HttpService();
            MessageClass msg = new MessageClass();
            HelperClass hlp = new HelperClass();
            Properties.Settings p = Properties.Settings.Default;

            app.p = p;

            http.msg = msg;
            http.hlp = hlp;
            http.p = p;

            hlp.msg = msg;
            hlp.http = http;

            Application.Run(new MainForm(app, hlp, http, msg));
        }
    }
}
