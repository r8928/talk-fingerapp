using System;
using System.IO;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class EnrollmentForm : Form
    {
        private HttpService http;
        private MessageClass msg;

        // Constructor
        public EnrollmentForm(AppData data, HttpService http, MessageClass msg)
        {
            InitializeComponent();

            this.http = http;
            this.msg = msg;
            Data = data;                                        // Keep reference to the data
            Data.OnChange += delegate { ExchangeData(false); };   // Track data changes to keep the form synchronized
            ExchangeData(true);                                 // Init data with default control values;
            txt_Username.Select();
        }

        // Simple dialog data exchange (DDX) implementation.
        public void ExchangeData(bool read)
        {
            if (read)
            {   // read values from the form's controls to the data object
                Data.EnrolledFingersMask = enrollControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = enrollControl.MaxEnrollFingerCount;
                Data.Update();
            }
            else
            {   // read values from the data object to the form's controls
                enrollControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                enrollControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }

        // event handling
        public void EnrollmentControl_OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds)
            {
                //Data.Template = Template;          // store a finger template
                ExchangeData(true);                             // update other data



                MemoryStream ms = new MemoryStream();
                Template.Serialize(ms);
                ms.Position = 0;
                BinaryReader br = new BinaryReader(ms);
                Byte[] bytes_ = br.ReadBytes((Int32)ms.Length);
                string templateString = Convert.ToBase64String(bytes_);


                var formData = new { user = txt_Username.Text, token = txt_Token.Text, template = templateString, finger = Finger };
                HttpResponse res = http.Post("finger/registertemplate", http.jsonStringify(formData));
                if (res.ok && res.hasJson)
                {
                    msg.success((string)res.json["message"]);
                    this.Close();
                }
                else
                {
                    http.StdErr(res);
                }


                //MemoryStream msI = new MemoryStream(Convert.FromBase64String(templateString));
                //DPFP.Template t2 = new DPFP.Template();
                //t2.DeSerialize(msI);
                //Data.Template = t2;



                ListEvents.Items.Insert(0, String.Format("OnEnroll:asdfasdf finger {0}", Finger));
            }
            else
                Status = DPFP.Gui.EventHandlerStatus.Failure;   // force a "failure" status
        }

        public void EnrollmentControl_OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds)
            {
                Data.Template = new DPFP.Template();
                ExchangeData(true);                             // update other data

                ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", Finger));
            }
            else
                Status = DPFP.Gui.EventHandlerStatus.Failure;   // force a "failure" status
        }

        private void EnrollmentControl_OnCancelEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnReaderConnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnReaderDisconnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnFingerRemove(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnFingerTouch(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void EnrollmentControl_OnSampleQuality(object Control, string ReaderSerialNumber, int Finger, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback));
        }

        private void EnrollmentControl_OnComplete(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private AppData Data;

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            this.ListEvents.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_Validation.Visible = false;
        }

        private void btn_ValidateUser_Click(object sender, EventArgs e)
        {
            if (txt_Token.Text.Length > 0 && txt_Username.Text.Length > 0)
            {
                var formData = new { user = txt_Username.Text, token = txt_Token.Text };
                HttpResponse res = http.Post("finger/validatetemplatetoken", http.jsonStringify(formData));

                if (res.ok && res.hasJson)
                {
                    this.pnl_Validation.Visible = false;
                    this.enrollControl.Visible = true;
                }
                else
                {
                    http.StdErr(res);
                }
            }
            else
            {
                msg.error("Please enter username and token");
            }
        }
    }
}