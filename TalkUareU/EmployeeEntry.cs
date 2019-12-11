using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TalkUareU
{

    public partial class EmployeeEntry : Panel
    {
        public string ClockStatus
        {
            set
            {
                //pic_Icon.Image = Properties.Resources.cross;
                pic_Icon.Refresh();
                //MessageBox.Show("asdf");
            }
        }

        public string EmpName
        {
            set
            {
                lbl_Name.Text = value;
                //EmpName = value;
            }
            get
            {
                return EmpName;
            }
        }
        public string ClockTimeString
        {
            set
            {
                lbl_timeString.Text = value;
                //ClockTimeString = value;
            }
            get
            {
                return ClockTimeString;
            }
        }

        public EmployeeEntry()
        {
            InitializeComponent();

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

        [Category("Custom")]
        [Browsable(true)]
        [Description("Asdfds")]
        [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Design.UITypeEditor))]

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
