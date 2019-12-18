using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalkUareU
{
  public partial class VerificationForm : Form {
    public VerificationForm(AppData data) {
      InitializeComponent();
      Data = data;
    }

    public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status) {
      DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
      DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();

      // Compare feature set with all stored templates.

        // Get template from storage.
        if (Data.Template.Size>0) {
          // Compare feature set with particular template.
          ver.Verify(FeatureSet, Data.Template, ref res);
          Data.IsFeatureSetMatched = res.Verified;
          Data.FalseAcceptRate = res.FARAchieved;
        }
      

      if (!res.Verified)
        Status = DPFP.Gui.EventHandlerStatus.Failure;

      Data.Update();
    }

    private AppData Data;
  }
}