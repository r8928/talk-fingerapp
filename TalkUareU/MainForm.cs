using InputBoxApp;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class MainForm : Form
    {

        HttpService http = new HttpService();
        HelperClass hlp = new HelperClass();
        public static string appLocationId;
        private string appLocationName;
        public static string appMAC;

        public MainForm()
        {
            InitializeComponent();

            getMAC();
            getNewToken();
            refresh_listing();
        }

        private void getMAC()
        {
            try
            {
                appMAC = System.Net.NetworkInformation.NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(nic => nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up && nic.NetworkInterfaceType != System.Net.NetworkInformation.NetworkInterfaceType.Loopback)
                    .Select(nic => nic.GetPhysicalAddress().ToString())
                    .FirstOrDefault();
            }
            catch (System.Exception)
            { }

            if (appMAC.Length == 0)
            {
                hlp.msg.error("Unable to get MAC", "SECURITY FAILURE");
                Close();
            }

            //hlp.msg.show(appMAC);
        }

        private void getNewToken()
        {
            string json = @"{
              'name': 'Jenira.Griffith107',
              'password': '12'
            }";

            HttpResponse logout = http.get("logout/11111"); //, http.jsonParse(json));

            HttpResponse response = http.post("signin", json); //, http.jsonParse(json));

            if (!response.ok)
            {
                hlp.msg.error("Connection error: " + response.code, "INTERNET ERROR");
                richTextBox1.Text = response.resp;
            }
            else
            {
                //hlp.msg.success("GOOD");
                richTextBox1.Text = response.resp;
                if (response.hasJson)
                {
                    txt_token.Text = (string)response.json["token"];
                }
            }
        }

        private void refresh_listing()
        {

            lbl_SapName.Text = "Refreshing...";

            List<EmployeeEntry> l = new List<EmployeeEntry>();
            foreach (Control c in flowPanel.Controls)
            {
                l.Add((EmployeeEntry)c);
            }
            foreach (EmployeeEntry em in l)
            {
                em.Click -= this.EmployeeEntryClick;
                flowPanel.Controls.Remove(em);
                em.Dispose();
            }


            string sap = txt_SAP.Text;

            if (sap.Length != 4)
            {
                hlp.msg.error("Invalid SAP selected");
                return;
            }

            HttpResponse response = http.get("finger/checkedreps?sap=" + sap);

            if (response.hasJson && response.resp.Contains("sap_id"))
            {
                appLocationId = (string)response.json["sap_id"];
                appLocationName = (string)response.json["sap_name"];
                lbl_SapName.Text = appLocationName;
            } else
            {
                lbl_SapName.Text = "Error connecting to BOOM, please click refresh to try again.";
            }

            if (response.ok && response.hasJson && response.resp.Contains("sap_id"))
            {


                foreach (var item in response.json["data"])
                {

                    JsonItem data = new JsonItem(
                        (string)item["uid"],
                        (string)item["location_id"],
                        (string)item["role_id"],
                        (string)item["name"],
                        (string)item["display_name"],
                        (string)item["check_in"],
                        (string)item["check_out"],
                        (string)item["lunch_in"],
                        (string)item["lunch_out"],
                        (string)item["status"]
                        );


                    EmployeeEntry em = new EmployeeEntry(data);

                    em.Click += this.EmployeeEntryClick;

                    flowPanel.Controls.Add(em);
                }
            }
            else
            {
                richTextBox1.Text = response.resp + "\n" + richTextBox1.Text;

                if (response.hasJson)
                {
                    hlp.msg.success((string) response.json["message"]);
                }
                else
                {
                    hlp.msg.error("Connection error", "INTERNET ERROR");
                }
            }
        }


        private void EmployeeEntryClick(object sender, System.EventArgs e)
        {
            EmployeeEntry em = (EmployeeEntry)sender;
            new ClockSelectionForm(em).ShowDialog();
            refresh_listing();
        }

        private void btn_refresh_Click(object sender, System.EventArgs e)
        {
            refresh_listing();
        }


        private void txt_token_TextChanged(object sender, System.EventArgs e)
        {
            HttpService.token = txt_token.Text;
        }

        private void txt_SAP_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                refresh_listing();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            HttpResponse re = http.get("timepunch/checkinoutstatus/11111/103"); //, http.jsonParse(json));

            if (!re.ok)
            {
                hlp.msg.error("Connection error: " + re.code, "INTERNET ERROR");
                richTextBox1.Text = re.resp;
            }
            else
            {
                //hlp.msg.success("GOOD");
                richTextBox1.Text = re.resp;
            }
        }

        private void btnGetToken_Click(object sender, System.EventArgs e)
        {
            richTextBox1.Text = "";
            getNewToken();
            refresh_listing();
        }

        private void btn_PunchIn_Click(object sender, System.EventArgs e)
        {
            InputBoxResult userName = InputBox.Show("Please enter your BOOM username.", "Username");

            if (userName.Text.Length > 0)
            {

                HttpResponse re = http.get("finger/checkname?name=" + userName.Text); //, http.jsonParse(json));

                if (re.ok && re.hasJson)
                {

                    EmployeeEntry emp = new EmployeeEntry(new JsonItem(
                        (string)re.json["user"],
                        appLocationId,
                        (string)re.json["role"]
                        ));
                    hlp.clockRequest(emp, "day_clockin");

                    //selectedRowItem = new JsonItem((string)re.json["user"], appLocationId, (string)re.json["role"]);
                    //clockRequest("day_clockin");
                }
                else
                {
                    hlp.msg.error(re.resp, "INTERNET ERROR");
                    richTextBox1.Text = re.resp;
                }
            }
        }

    }
}