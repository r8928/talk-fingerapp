using System;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace TalkUareU
{
    public class HelperClass
    {
        public MessageClass msg = new MessageClass();
        private static HelperClass helper;

        private HelperClass() { }

        public static HelperClass getHelper()
        {
            if (helper is null)
            {
                helper = new HelperClass();
            }
            return helper;
        }

        public string curDateTime(string format = "yyyy-MM-dd h:mm")
        {
            return DateTime.Now.ToString(format);
        }

        public void log(string newContent)
        {
            string currentContent = String.Empty;
            string filePath = "./log.txt";

            newContent =
            "Time: " +
            curDateTime() +
            Environment.NewLine +
            newContent +
             Environment.NewLine + Environment.NewLine +
             "================================================" +
             Environment.NewLine;

            if (System.IO.File.Exists(filePath))
            {
                currentContent = String.Join(Environment.NewLine, System.IO.File.ReadAllLines(filePath).Take(232));
            }
            System.IO.File.WriteAllText(filePath, newContent + currentContent);
        }

        public string getHardwareIds(string SapID = null)
        {
            string appComputerName = "";
            string appMAC = "";
            string appProcessorID = "";
            string appMotherboardID = "";

            if (!SystemInformation.Network)
            {
                msg.error("Could't connect to internet");
            }
            try
            {
                ManagementObjectCollection mbsList = null;
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
                mbsList = mbs.Get();
                foreach (ManagementObject mo in mbsList)
                {
                    appProcessorID = mo["ProcessorID"].ToString();
                }


                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();
                foreach (ManagementObject mo in moc)
                {
                    appMotherboardID = (string)mo["SerialNumber"];
                }


                appMAC = System.Net.NetworkInformation.NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(nic => nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && nic.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                    .Select(nic => nic.GetPhysicalAddress().ToString())
                    .FirstOrDefault();

                appComputerName = Environment.MachineName;
            }
            catch (Exception) { }

            if (String.IsNullOrEmpty(appComputerName))
            {
                msg.error("Unable to identify computer", "SECURITY FAILURE");
            }

            if (String.IsNullOrEmpty(appMAC))
            {
                msg.error("Unable to identify computer", "SECURITY FAILURE");
            }

            var formData = new { hardware_ids = new String[] { appMAC, appComputerName, appProcessorID, appMotherboardID }, sap = SapID };

            string json_string = http.jsonStringify(formData);

            http.hIdToken = Base64Encode(json_string);

            return json_string;
        }


        public string Base64Encode(string str)
        {
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(str));
        }


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

            HttpResponse res = http.Post("finger/" + url_subpart, http.jsonStringify(emp.data));

            if (!res.ok)
            {
                http.StdErr(res);
            }
        }
    }
}