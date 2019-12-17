using System;
using System.Windows.Forms;

namespace TalkUareU
{

    public partial class EmployeeEntry : Panel
    {
        private string _ClockTimeString;

        public JsonItem data { get; }

        public string ClockStatus
        {
            set
            {
                if (value == null) return;
                pic_Icon.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(value);
                pic_Icon.Refresh();
                data.Status = value;
            }
            get => data.Status;
        }

        public string EmpName
        {
            set
            {
                lbl_Name.Text = value;
                data.DName = value;
            }
            get => data.DName;

        }
        public string ClockTimeString
        {
            set
            {
                lbl_timeString.Text = value;
                _ClockTimeString = value;
            }
            get => _ClockTimeString;

        }

        public EmployeeEntry(string uid, string location_id, string role_id, string name = null, string display_name = null, string check_in = null, string check_out = null, string lunch_in = null, string lunch_out = null, string status = null)
        {
            InitializeComponent();
            data = new JsonItem(
                       uid,
                       location_id,
                       role_id,
                       name,
                       display_name,
                       check_in,
                       check_out,
                       lunch_in,
                       lunch_out,
                       status
                   );
            EmpName = data.DName;
            ClockTimeString = data.getTimeString();
            ClockStatus = data.Status;

            Controls.Add(pic_Icon);
            Controls.Add(lbl_Name);
            Controls.Add(lbl_timeString);

            lbl_Name.Click += childControl_Click;
            pic_Icon.Click += childControl_Click; ;
            lbl_timeString.Click += childControl_Click;

        }

        private void childControl_Click(object sender, EventArgs e)
        {
            // just raise user control's click event using inherited method OnClick()
            OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}