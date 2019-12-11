using System.Windows.Forms;

namespace TalkUareU
{
    internal class HelperClass
    {
        public MessageClass msg = new MessageClass();

        public HelperClass() { }

        public string curDateTime(string format = "yyyy-MM-dd h:mm")
        {
            return System.DateTime.Now.ToString(format);
        }

        internal class MessageClass
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
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            public void warn(string msg, string title = null)
            {
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}