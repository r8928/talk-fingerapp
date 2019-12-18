using System.Windows.Forms;

namespace TalkUareU
{
    public partial class VerificationForm : Form
    {

        private AppData App;
        public VerificationForm(AppData app)
        {
            InitializeComponent();
            App = app;
        }

        public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status)
        {
            DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
            DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

            App.IsFeatureSetMatched = false;

            // Get template from storage.
            if (App.Template.Size > 0)
            {
                // Compare feature set with particular template.
                ver.Verify(FeatureSet, App.Template, ref result);

                App.IsFeatureSetMatched = result.Verified;
                App.FalseAcceptRate = result.FARAchieved;
            }


            if (!result.Verified)
                Status = DPFP.Gui.EventHandlerStatus.Failure;

            //Data.Update();
        }
    }
}