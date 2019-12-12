using InputBoxApp;
using System.Linq;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class MainForm : Form
    {

        HttpService http = new HttpService();
        HelperClass hlp = new HelperClass();
        private rowItem selectedRowItem;
        public static string appLocationId;
        private string appMAC;

        public MainForm()
        {
            InitializeComponent();


            //Form x = new Form1();
            //x.ShowDialog();

            getMAC();

            getNewToken();
            refresh_listing();
            enable_btn(btn_refresh);
            enable_btn(btn_PunchIn);

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

            listView1.Items.Clear();
            updatePunchButtonsStatus();

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

                    string[] row = {
                        (string) item["name"], //0
                        (string) item["display_name"], //1
                        (string) item["status"], //2
                        (string) item["check_in"], //3
                        (string) item["uid"], //4
                        (string) item["location_id"], //5
                        (string) item["role_id"], //6
                        (string) item["lunch_out"], //7
                        (string) item["lunch_in"], //8
                        (string) item["check_out"], //9
                    };
                    InsertEmployeeRows(row);



                    EmployeeEntry em = new EmployeeEntry(
                        (string)item["uid"],
                        (string)item["display_name"],
                        (string)item["status"],
                        (string)item["check_in"],
                        (string)item["role_id"]
                        );
                    em.Click += this.EmployeeEntryClick;

                    flowLayoutPanel1.Controls.Add(em);
                }
            }
        }


        private void EmployeeEntryClick(object sender, System.EventArgs e)
        {
            EmployeeEntry em = (EmployeeEntry)sender;
            //MessageBox.Show(em.EmpName);
            new Form1(em).ShowDialog();
        }


        private void InsertEmployeeRows(string[] data)
        {
            var listViewItem = new ListViewItem(data);
            listView1.Items.Add(listViewItem);

        }

        private void list_LostFocusEvent(object sender, System.EventArgs e)
        {
            //updatePunchButtonsStatus();
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (listView1.SelectedIndices.Count == 0)
            {
                updatePunchButtonsStatus();
                selectedRowItem = null;
                return;
            }

            ListViewItem row = listView1.SelectedItems[0];

            if (row == null)
            {
                updatePunchButtonsStatus();
                selectedRowItem = null;
                return;
            }

            string row_UName = row.SubItems[0].Text;
            string row_DName = row.SubItems[1].Text;
            string row_Status = row.SubItems[2].Text;
            string row_Checkin = row.SubItems[3].Text;
            string row_UId = row.SubItems[4].Text;
            string row_LocID = row.SubItems[5].Text;
            string row_RoleID = row.SubItems[6].Text;

            //hlp.msg.show(http.jsonStringify(rowItm));
            //MessageBox.Show (row_UName + " " + row_Status);

            updatePunchButtonsStatus(row_Status);

            selectedRowItem = new rowItem(row_UId, row_LocID, row_Status, row_RoleID);
        }

        private void updatePunchButtonsStatus(string status = null)
        {
            richTextBox1.Text = status + "\n" + richTextBox1.Text;

            switch (status)
            {
                case "Checked in":
                    enable_btn(btn_LunchOut);
                    disable_btn(btn_LunchIn);
                    enable_btn(btn_PunchOut);
                    break;

                case "Lunch break":
                    disable_btn(btn_LunchOut);
                    enable_btn(btn_LunchIn);
                    disable_btn(btn_PunchOut);
                    break;

                case "Checked out":
                case null:
                    disable_btn(btn_LunchOut);
                    disable_btn(btn_LunchIn);
                    disable_btn(btn_PunchOut);
                    disable_btn(btn_LunchOut);
                    break;

                default:
                    hlp.msg.error("INVALID SELECTION (" + status + ")");
                    return;
            }
        }

        private void disable_btn(Button btn)
        {
            btn.Enabled = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.No;
        }

        private void enable_btn(Button btn)
        {
            btn.Enabled = true;
            btn.FlatStyle = FlatStyle.Standard;
            btn.Cursor = Cursors.Hand;
        }

        private void btn_refresh_Click(object sender, System.EventArgs e)
        {
            refresh_listing();
        }

        private void btn_LunchOut_Click(object sender, System.EventArgs e)
        {
            clockRequest("lunch_clockout");
        }

        private void btn_LunchIn_Click(object sender, System.EventArgs e)
        {
            clockRequest("lunch_back");
        }

        private void btn_PunchOut_Click(object sender, System.EventArgs e)
        {
            clockRequest("day_clockout");
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
                    selectedRowItem = new rowItem((string)re.json["user"], appLocationId, (string)re.json["role"]);
                    clockRequest("day_clockin");
                }
                else
                {
                    hlp.msg.error(re.resp, "INTERNET ERROR");
                    richTextBox1.Text = re.resp;
                }
            }

            //clockRequest("day_clockin");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void clockRequest(string clockEvent)
        {
            if (selectedRowItem == null)
            {
                return;
            }

            string url_subpart = "";
            switch (clockEvent)
            {
                case "day_clockin":
                    selectedRowItem.check_in = hlp.curDateTime();
                    selectedRowItem.check_out = null;
                    selectedRowItem.btnevent = "yes";
                    url_subpart = "checkin";
                    break;
                case "lunch_clockout":
                    selectedRowItem.check_in = null;
                    selectedRowItem.check_out = hlp.curDateTime();
                    selectedRowItem.btnevent = clockEvent;
                    url_subpart = "checkout";
                    break;
                case "lunch_back":
                    selectedRowItem.check_in = null;
                    selectedRowItem.check_out = hlp.curDateTime();
                    selectedRowItem.btnevent = clockEvent;
                    url_subpart = "checkin";
                    break;
                case "day_clockout":
                    selectedRowItem.check_in = null;
                    selectedRowItem.check_out = hlp.curDateTime();
                    selectedRowItem.btnevent = "yes";
                    url_subpart = "checkout";
                    break;
                default:
                    hlp.msg.error("BAD SELECTION");
                    return;
            }

            richTextBox1.Text = http.jsonStringify(selectedRowItem) + "\n" + richTextBox1.Text;

            HttpResponse response = http.post("timepunch/" + url_subpart, http.jsonStringify(selectedRowItem)); //, http.jsonParse(json));

            if (!response.ok)
            {
                hlp.msg.error("Connection error: " + response.code, "INTERNET ERROR");
                richTextBox1.Text = response.resp + "\n" + richTextBox1.Text;
            }
            else
            {
                //hlp.msg.success("GOOD");
                richTextBox1.Text = response.resp + "\n" + richTextBox1.Text;

                if (response.resp.Contains("\"error\""))
                {
                    hlp.msg.warn((string)response.json["message"]);
                }
            }
            refresh_listing();
        }
    }
}