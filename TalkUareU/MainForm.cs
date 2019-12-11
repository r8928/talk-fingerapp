using System.Windows.Forms;
using WindowsApplication1;

namespace TalkUareU
{
    public partial class MainForm : Form
    {

        HttpService http = new HttpService();
        HelperClass hlp = new HelperClass();
        private rowItem selectedRowItem;

        public MainForm()
        {
            InitializeComponent();
            refresh_listing();
            enable_btn(btn_refresh);
            enable_btn(btn_PunchIn);

        }

        private void refresh_listing()
        {

            listView1.Items.Clear();
            updatePunchButtonsStatus();

            string sap = this.txt_SAP.Text;

            if (sap.Length != 4)
            {
                hlp.msg.error("Invalid SAP selected");
                return;
            }

            HttpResponse re = http.get("finger/checkedreps?sap=" + sap);

            if (!re.ok)
            {
                hlp.msg.error("Connection error", "INTERNET ERROR");
            }
            else
            {
                //MessageBox.Show((string)re.json["data"][0]["sap"]);

                foreach (var item in re.json["data"])
                {

                    string[] row = {
                        (string) item["name"], //0
                        (string) item["display_name"], //1
                        (string) item["check_in"], //2
                        (string) item["status"], //3
                        (string) item["uid"], //4
                        (string) item["location_id"], //5
                        (string) item["role_id"], //6
                        (string) item["lunch_out"], //7
                        (string) item["lunch_in"], //8
                        (string) item["check_out"], //9
                    };
                    InsertEmployeeRows(row);
                }
            }

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
            string row_Checkin = row.SubItems[2].Text;
            string row_Status = row.SubItems[3].Text;
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

                default:
                    disable_btn(btn_LunchOut);
                    disable_btn(btn_LunchIn);
                    disable_btn(btn_PunchOut);
                    disable_btn(btn_LunchOut);
                    break;
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

        internal class rowItem
        {
            public string check_in;
            public string check_out;

            public string user_id;
            public string location_id;
            public string role_id;
            public string btnevent;

            public string ip_in;
            public string ip_out;

            // public string Name;
            // public string DName;
            // public string Lunch_out;
            // public string Lunch_in;
            public string Status;


            public rowItem(string ID, string LOCATION, string ROLE_ID, string STATUS, string CHECKIN = null, string BTNEVENT = null, string CHECKOUT = null)
            {
                user_id = ID;
                location_id = LOCATION;
                Status = STATUS;
                check_in = CHECKIN;

                role_id = ROLE_ID;
                btnevent = BTNEVENT;
                check_out = CHECKOUT;
            }
        }

        private void clockRequest(string clockEvent)
        {
            if (selectedRowItem == null)
            {
                return;
            }


            string url_subpart = "";
            switch (clockEvent)
            {
                case "day_clockin":
                    selectedRowItem.check_in = null;
                    selectedRowItem.check_out = hlp.curDateTime();
                    selectedRowItem.btnevent = "yes";
                    url_subpart = "checkin";
                    break;
                case "lunch_clockout":
                    selectedRowItem.check_in = hlp.curDateTime();
                    selectedRowItem.check_out = null;
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
                    selectedRowItem.check_in = hlp.curDateTime();
                    selectedRowItem.check_out = null;
                    selectedRowItem.btnevent = "yes";
                    url_subpart = "checkout";
                    break;
                default:
                    hlp.msg.error("BAD SELECTION");
                    return;
            }



            HttpResponse response = http.post("timepunch/" + url_subpart, selectedRowItem); //, http.jsonParse(json));

            if (!response.ok)
            {
                hlp.msg.error("Connection error: " + response.code, "INTERNET ERROR");
                this.richTextBox1.Text = response.resp;
            }
            else
            {
                //hlp.msg.success("GOOD");
                this.richTextBox1.Text = response.resp;

                if (response.resp.Contains("\"error\""))
                {
                    hlp.msg.warn((string)response.json["message"]);
                }
            }
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

        private void btn_PunchIn_Click(object sender, System.EventArgs e)
        {
            InputBoxResult test = InputBox.Show("hello");


            //clockRequest("day_clockin");
        }

        private void txt_token_TextChanged(object sender, System.EventArgs e)
        {
            HttpService.token = txt_token.Text;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string json = @"{  
              'Name': 'C-sharpcorner',  
              'Description': 'Share Knowledge'  
            }";
            HttpResponse re = http.get("timepunch/checkinoutstatus/11111/103"); //, http.jsonParse(json));

            if (!re.ok)
            {
                hlp.msg.error("Connection error: " + re.code, "INTERNET ERROR");
                this.richTextBox1.Text = re.resp;
            }
            else
            {
                //hlp.msg.success("GOOD");
                this.richTextBox1.Text = re.resp;
            }
        }

        private void btnGetToken_Click(object sender, System.EventArgs e)
        {
            string json = @"{  
              'name': 'Jenira.Griffith107',  
              'password': '12'  
            }";

            HttpResponse logout = http.get("logout/11111"); //, http.jsonParse(json));

            HttpResponse response = http.post("signin", http.jsonParse(json)); //, http.jsonParse(json));

            if (!response.ok)
            {
                hlp.msg.error("Connection error: " + response.code, "INTERNET ERROR");
                this.richTextBox1.Text = response.resp;
            }
            else
            {
                //hlp.msg.success("GOOD");
                richTextBox1.Text = response.resp;
                txt_token.Text = (string) response.json["token"];
            }
            refresh_listing();
        }
    }
}