using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TalkUareU
{

    public partial class EmployeeEntry : Panel
    {
        private string _ClockStatus;
        private string _EmpName;
        private string _ClockTimeString;
        public string user_id;
        public string role_id;
        public string location_id;


        public string btnevent;
        public string ip_in;
        public string ip_out;
        public string check_in;
        public string check_out;

        public string ClockStatus
        {
            set
            {
                switch (value)
                {
                    case "in":
                        pic_Icon.BackgroundImage = Properties.Resources.checkin;
                        break;
                    case "out":
                        pic_Icon.BackgroundImage = Properties.Resources.checkout;
                        break;
                    case "lunch":
                        pic_Icon.BackgroundImage = Properties.Resources.lunchout;
                        break;
                    default:
                        break;
                }
                pic_Icon.Refresh();
                _ClockStatus = value;
            }
            get => _ClockStatus;
        }

        public string EmpName
        {
            set
            {
                lbl_Name.Text = value;
                _EmpName = value;
            }
           get => _EmpName;
            
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

        public EmployeeEntry(string UserID, string Name, string Status, string TimeString, string RoleID)
        {
            InitializeComponent();


            EmpName = Name;
            ClockTimeString = TimeString;
            ClockStatus = Status;
            this.user_id = UserID;
            this.role_id = RoleID;


            Controls.Add(pic_Icon);
            Controls.Add(lbl_Name);
            Controls.Add(lbl_timeString);

            lbl_Name.Click += new System.EventHandler(childControl_Click);
            pic_Icon.Click += new System.EventHandler(childControl_Click);
            lbl_timeString.Click += new System.EventHandler(childControl_Click);

        }

        private void childControl_Click(object sender, EventArgs e)
        {
            // just raise user control's click event using inherited method OnClick()
            OnClick(e);
        }

       // [Category("Custom")]
       // [Browsable(true)]
       // [Description("Asdfds")]
       // [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Design.UITypeEditor))]

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
