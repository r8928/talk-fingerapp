using InputBoxApp;
using System;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class MainForm : Form
    {
        private HelperClass hlp;
        private MessageClass msg;
        private HttpService http;
        private AppData app;

        private Label err_lbl = new Label();

        public MainForm(AppData app, HelperClass hlp, HttpService http, MessageClass msg)
        {
            InitializeComponent();
            enableApp(false);

            this.hlp = hlp;
            this.http = http;
            this.msg = msg;
            this.app = app;

            validateApp();

            if (!String.IsNullOrEmpty(app.LocationId))
            {
                refresh_listing();
            }
        }

        private void validateApp()
        {

            lbl_SapName.Text = "Refreshing...";

            HttpResponse res = http.Post("finger/validateapp", hlp.getHardwareIds());
            if (res.ok && res.hasJson && res.resp.Contains("sap_id"))
            {
                app.LocationId = (string)res.json["sap_id"];
                app.LocationName = (string)res.json["sap_name"];
                app.LocationSap = (string)res.json["sap"];

                lbl_SapName.Text = app.LocationName;
                enableApp(true);
            }
            else
            {
                enableApp(false);
                if (res.hasJson)
                {
                    lbl_SapName.Text = (string)res.json["message"];
                }
                else
                {
                    lbl_SapName.Text = "Error connecting to BOOM, please click refresh to try again.";
                }

                http.StdErr(res);
            }
        }

        private void enableApp(bool enable)
        {
            flowPanel.Enabled = enable;
            btn_PunchIn.Enabled = enable;
            btn_refresh.Enabled = enable;
        }

        private void refresh_listing()
        {

            // VALIDATE APP
            if (String.IsNullOrEmpty(app.LocationId))
            {
                validateApp();

                if (String.IsNullOrEmpty(app.LocationId))
                {
                    return;
                }
            }




            // VALIDATE SAP
            if (String.IsNullOrEmpty(app.LocationSap) || app.LocationSap.Length < 4)
            {
                msg.error("Invalid SAP selected");
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
            HttpResponse response = http.Get("finger/checkedreps?sap=" + app.LocationSap);

            if (response.ok && response.hasJson && response.resp.Contains("sap_id"))
            {
                foreach (var item in response.json["data"])
                {
                    EmployeeEntry em = new EmployeeEntry(
                        (string)item["uid"],
                        (string)item["location_id"],
                        (string)item["role_id"],
                        (string)item["name"],
                        (string)item["display_name"],
                        (string)item["check_in"],
                        (string)item["check_out"],
                        (string)item["lunch_in"],
                        (string)item["lunch_out"],
                        (string)item["status"],
                        (string)item["btnevent"],
                        (string)item["punch_id"]
                    );
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
                    err_lbl.Padding = new Padding(10);
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

        private void EmployeeEntryClick(object sender, EventArgs e)
        {

            JsonItem data = ((EmployeeEntry)sender).data;


            // GET CHECKED IN REPS LISTING
            HttpResponse res = http.Get("finger/checkedreps?sap=" + app.LocationSap + "&punch_id=" + data.punch_id);

            if (res.ok && res.hasJson && res.resp.Contains("sap_id"))
            {
                var item = res.json["data"][0];

                JsonItem updatedData = new JsonItem(
                    (string)item["uid"],
                    (string)item["location_id"],
                    (string)item["role_id"],
                    (string)item["name"],
                    (string)item["display_name"],
                    (string)item["check_in"],
                    (string)item["check_out"],
                    (string)item["lunch_in"],
                    (string)item["lunch_out"],
                    (string)item["status"],
                    (string)item["btnevent"],
                    (string)item["punch_id"]
                    );

                new ClockSelectionForm(updatedData, app, hlp, http, msg).ShowDialog();
                refresh_listing();
            }
            else http.StdErr(res);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh_listing();
        }

        private void btn_PunchIn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(app.LocationId))
            {
                msg.error("App is not logged in, please try refreshing the listing and then try again");
            }

            InputBoxResult userName = InputBox.Show("Please enter your BOOM username.", "Username");

            if (!String.IsNullOrEmpty(userName.Text))
            {
                HttpResponse res = http.Get("finger/checkname?name=" + userName.Text);

                if (res.ok && res.hasJson)
                {
                    JsonItem data = new JsonItem(
                        (string)res.json["user"],
                        app.LocationId,
                        (string)res.json["role"]
                    );

                    hlp.clockRequest(data, "day_clockin");
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
                new AdminForm(hlp, http, msg).ShowDialog();

                validateApp();
                refresh_listing();
            }
            else
            {
                http.StdErr(res);
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            EnrollmentForm form = new EnrollmentForm(app, http, msg);

            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VerificationForm form = new VerificationForm(app);

            //form.ShowDialog();
        }
    }
}