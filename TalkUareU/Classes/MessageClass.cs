using System.Windows.Forms;

namespace TalkUareU
{
    public class MessageClass
    {
        public void show(string msg, string title = null)
        {
            MessageBox.Show(msg, title);
        }
        public void error(string msg, string title = "ERROR")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void success(string msg, string title = null)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void warn(string msg, string title = null)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
