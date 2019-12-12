using System.Windows.Forms;

namespace TalkUareU
{
    internal class HelperClass
    {

        HttpService http = new HttpService();
        
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
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            public void warn(string msg, string title = null)
            {
                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void clockRequest(EmployeeEntry emp, string clockEvent)
        {
            if (emp == null)
            {
                return;
            }
            

            string url_subpart = "";
            switch (clockEvent)
            {
                case "day_clockin":
                    emp.data.check_in = curDateTime();
                    emp.data.check_out = null;
                    emp.data.btnevent = "yes";
                    url_subpart = "checkin";
                    break;
                case "lunch_clockout":
                    emp.data.check_in = null;
                    emp.data.check_out = curDateTime();
                    emp.data.btnevent = clockEvent;
                    url_subpart = "checkout";
                    break;
                case "lunch_back":
                    emp.data.check_in = null;
                    emp.data.check_out = curDateTime();
                    emp.data.btnevent = clockEvent;
                    url_subpart = "checkin";
                    break;
                case "day_clockout":
                    emp.data.check_in = null;
                    emp.data.check_out = curDateTime();
                    emp.data.btnevent = "yes";
                    url_subpart = "checkout";
                    break;
                default:
                    msg.error("BAD SELECTION");
                    return;
            }

            //richTextBox1.Text = http.jsonStringify(emp) + "\n" + richTextBox1.Text;

            HttpResponse response = http.post("timepunch/" + url_subpart, http.jsonStringify(emp.data)); //, http.jsonParse(json));

            if (!response.ok)
            {
                msg.error("Connection error: " + response.code, "INTERNET ERROR");
                //richTextBox1.Text = response.resp + "\n" + richTextBox1.Text;
            }
            else
            {
                //msg.success("GOOD");
                //richTextBox1.Text = response.resp + "\n" + richTextBox1.Text;

                if (response.resp.Contains("\"error\""))
                {
                    msg.warn((string)response.json["message"]);
                }
            }
            //refresh_listing();
        }


    }
}