using System;
using System.Windows.Forms;

namespace TalkUareU
{

    public partial class EmployeeEntry : Panel
    {
        private string _ClockTimeString;
        public JsonItem data;

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

        public EmployeeEntry(JsonItem j)
        {
            InitializeComponent();
            data = j;
            EmpName = data.DName;
            ClockTimeString = data.getTimeString(); // need to fix
            ClockStatus = data.Status;

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