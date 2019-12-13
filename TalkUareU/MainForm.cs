using InputBoxApp;
using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class MainForm : Form
    {
        HelperClass hlp = HelperClass.getHelper();

        public static string appLocationId;
        private string appLocationName;
        private string appLocationSap;
        private Label err_lbl = new Label();

        EmployeeEntry curEmployee;

        public MainForm()
        {
            InitializeComponent();
            enableApp(false);

            validateApp();
            refresh_listing();

        }

        private void validateApp()
        {

            lbl_SapName.Text = "Refreshing...";

            HttpResponse res = http.Post("finger/validateapp", hlp.getHardwareIds());
            if (res.ok && res.hasJson && res.resp.Contains("sap_id"))
            {
                appLocationId = (string)res.json["sap_id"];
                appLocationName = (string)res.json["sap_name"];
                appLocationSap = (string)res.json["sap"];

                lbl_SapName.Text = appLocationName;
                enableApp(true);
            }
            else
            {
                enableApp(false);
                lbl_SapName.Text = "Error connecting to BOOM, please click refresh to try again.";

                http.StdErr(res);
            }
        }

        private void enableApp(bool enable)
        {
            flowPanel.Enabled = enable;
            btn_PunchIn.Enabled = enable;
        }

        private void getNewToken()
        {
            string json = @"{
              'name': 'Jenira.Griffith107',
              'password': '12'
            }";

            HttpResponse logout = http.Get("logout/11111");

            HttpResponse res = http.Post("signin", json);

            if (res.ok && res.hasJson)
            {
                http.token = (string)res.json["token"];
            }
            else
            {
                http.StdErr(res);
            }
        }

        private void refresh_listing()
        {

            // VALIDATE APP
            if (String.IsNullOrEmpty(appLocationId))
            {
                validateApp();
            }




            // VALIDATE SAP
            if (String.IsNullOrEmpty(appLocationSap) && appLocationSap.Length < 4)
            {
                hlp.msg.error("Invalid SAP selected");
                return;
            }




            // REMOVE PREVIOUS ITEMS
            try
            {
                flowPanel.Controls.Remove(err_lbl);
                flowPanel.BackColor = System.Drawing.Color.White;
            }
            catch (Exception)
            { }

            while (flowPanel.Controls.Count > 0)
            {
                var em = flowPanel.Controls[0];
                em.Click -= this.EmployeeEntryClick;
                flowPanel.Controls.Remove(em);
                em.Dispose();

            }




            // GET CHECKED IN REPS LISTING
            HttpResponse response = http.Get("finger/checkedreps?sap=" + appLocationSap);

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
                if (response.hasJson)
                {
                    err_lbl.Width = 700;
                    err_lbl.Height = 700;
                    err_lbl.Padding = new System.Windows.Forms.Padding(10);
                    flowPanel.Controls.Add(err_lbl);
                    err_lbl.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);

                    err_lbl.Text = (string)response.json["message"];
                }
                else
                {
                    err_lbl.Text = "Unknown error occured";
                }
            }
        }

        private void EmployeeEntryClick(object sender, System.EventArgs e)
        {
            curEmployee = (EmployeeEntry)sender;
            new ClockSelectionForm(curEmployee).ShowDialog();
            refresh_listing();
        }

        private void btn_refresh_Click(object sender, System.EventArgs e)
        {
            refresh_listing();
        }

        private void GetCheckinDetails(object sender, System.EventArgs e)
        {
            HttpResponse res = http.Get("timepunch/checkinoutstatus/11111/103"); //, http.jsonParse(json));

            if (!res.ok)
            {
                http.StdErr(res);
            }
        }

        private void btnGetToken_Click(object sender, System.EventArgs e)
        {
            getNewToken();
            refresh_listing();
        }

        private void btn_PunchIn_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(appLocationId))
            {
                hlp.msg.error("App is not logged in, please try refreshing the listing and then try again");
            }

            InputBoxResult userName = InputBox.Show("Please enter your BOOM username.", "Username");

            if (!String.IsNullOrEmpty(userName.Text))
            {
                HttpResponse res = http.Get("finger/checkname?name=" + userName.Text);

                if (res.ok && res.hasJson)
                {
                    EmployeeEntry emp = new EmployeeEntry(new JsonItem(
                        (string)res.json["user"],
                        appLocationId,
                        (string)res.json["role"]
                    ));

                    hlp.clockRequest(emp, "day_clockin");
                    refresh_listing();
                }
                else
                {
                    http.StdErr(res);
                }
            }
        }


        private void btn_Admin_Click(object sender, EventArgs e)
        {
            InputBoxResult AdminToken = InputBox.Show("Please enter your BOOM Admin token", "Token");

            if (String.IsNullOrEmpty(AdminToken.Text))
            {
                return;
            }

            var formData = new { token = new { AdminToken.Text } };

            HttpResponse res = http.Post("finger/validateadmintoken", http.jsonStringify(formData));
            if (res.ok && res.hasJson)
            {
                new AdminForm().ShowDialog();

                validateApp();
                refresh_listing();
            }
            else
            {
                http.StdErr(res);
            }
        }
    }
}