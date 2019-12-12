using InputBoxApp;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TalkUareU
{
    public partial class MainForm : Form
    {

        HttpService http = new HttpService();
        HelperClass hlp = new HelperClass();
        private JsonItem selectedRowItem;
        public static string appLocationId;
        private string appMAC;

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
            List<EmployeeEntry> l = new List<EmployeeEntry>();
            foreach (Control c in flowLayoutPanel1.Controls) {
                l.Add((EmployeeEntry)c);
            }
            foreach (EmployeeEntry em in l) {                
                em.Click -= this.EmployeeEntryClick;
                flowLayoutPanel1.Controls.Remove(em);
                em.Dispose();
            }


            string sap = txt_SAP.Text;

            if (sap.Length != 4)
            {
                hlp.msg.error("Invalid SAP selected");
                return;
            }

            HttpResponse response = http.get("finger/checkedreps?sap=" + sap);

            if (!response.ok)
            {
                richTextBox1.Text = response.resp + "\n" + richTextBox1.Text;

                if (response.resp.Contains("No one checked in"))
                {
                    hlp.msg.success("No one checked in");
                }
                else
                {
                    hlp.msg.error("Connection error", "INTERNET ERROR");
                }
            }
            else
            {
                //MessageBox.Show((string)re.json["data"][0]["sap"]);

                MainForm.appLocationId = (string)response.json["data"][0]["location_id"];

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

                    flowLayoutPanel1.Controls.Add(em);
                }
            }
        }


        private void EmployeeEntryClick(object sender, System.EventArgs e)
        {
            EmployeeEntry em = (EmployeeEntry)sender;            
            new Form1(em).ShowDialog();
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
                    richTextBox1.Text = re.resp;
                    //selectedRowItem = new JsonItem((string)re.json["user"], appLocationId, (string)re.json["role"]);
                    //clockRequest("day_clockin");
                }
                else
                {
                    hlp.msg.error(re.resp, "INTERNET ERROR");
                    richTextBox1.Text = re.resp;
                }
            }

            //clockRequest("day_clockin");
        }

    }
}