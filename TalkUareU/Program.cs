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
            
            HelperClass hlp = HelperClass.getHelper();

            Application.Run(new MainForm(hlp));
        }
    }
}
