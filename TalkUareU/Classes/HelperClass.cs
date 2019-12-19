using System;
using System.IO;
using System.Linq;
using System.Management;

namespace TalkUareU
{
    public class HelperClass
    {
        public HttpService http;
        public MessageClass msg;


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

            HttpService.hIdToken = Base64Encode(json_string);

            return json_string;
        }


        public string Base64Encode(string str)
        {
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(str));
        }


        public void clockRequest(JsonItem data, string clockEvent)
        {
            if (data == null)
            {
                return;
            }

            string url_subpart = "";
            switch (clockEvent)
            {
                case "day_clockin":
                    data.check_in = curDateTime();
                    data.check_out = null;
                    data.btnevent = "yes";
                    url_subpart = "checkin";
                    break;
                case "lunch_clockout":
                    data.check_in = null;
                    data.check_out = curDateTime();
                    data.btnevent = clockEvent;
                    url_subpart = "checkout";
                    break;
                case "lunch_back":
                    data.check_in = null;
                    data.check_out = curDateTime();
                    data.btnevent = clockEvent;
                    url_subpart = "checkin";
                    break;
                case "day_clockout":
                    data.check_in = null;
                    data.check_out = curDateTime();
                    data.btnevent = "yes";
                    url_subpart = "checkout";
                    break;
                default:
                    msg.error("BAD SELECTION");
                    return;
            }

            HttpResponse res = http.Post("finger/" + url_subpart + "?punch_source=App", http.jsonStringify(data));

            if (!res.ok || res.resp.Contains("\"error\""))
            {
                http.StdErr(res);
            }
        }

        private void requestTemplate(AppData app, JsonItem data)
        {
            app.Template = new DPFP.Template();


            var formData = new { user = data.user_id };
            HttpResponse res = http.Post("finger/requesttemplate", http.jsonStringify(formData));
            if (res.ok && res.hasJson)
            {
                string TemplateString = (string)res.json["template"];


                MemoryStream msI = new MemoryStream(Convert.FromBase64String(TemplateString));
                app.Template.DeSerialize(msI);
            }
            else
            {
                http.StdErr(res);
            }
        }

        public bool validateFinger(AppData app, JsonItem data)
        {

            if (app.FingerValidationEnabled)
            {
                requestTemplate(app, data);
                if (app.Template.Size == 0)
                {
                    return false;
                }
                new VerificationForm(app).ShowDialog();

                if (!app.IsFeatureSetMatched)
                {
                    msg.error("Fingerprint validation failed");
                }

                return app.IsFeatureSetMatched;
            }
            else
            {
                return true;
            }
        }
    }
}