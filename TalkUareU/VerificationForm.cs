using System.Windows.Forms;

namespace TalkUareU
{
    public partial class VerificationForm : Form
    {

        private AppData app;
        public VerificationForm(AppData app)
        {
            InitializeComponent();

            this.app = app;
            this.app.IsFeatureSetMatched = false;
        }

        public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status)
        {
            DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
            DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();


            // Get template from storage.
            if (app.Template.Size > 0)
            {
                // Compare feature set with particular template.
                ver.Verify(FeatureSet, app.Template, ref result);

                app.IsFeatureSetMatched = result.Verified;
                app.FalseAcceptRate = result.FARAchieved;
            }


            if (!result.Verified)
            {
                Status = DPFP.Gui.EventHandlerStatus.Failure;
            }
            else
            {
                this.Close();
            }

            //Data.Update();
        }
    }
}