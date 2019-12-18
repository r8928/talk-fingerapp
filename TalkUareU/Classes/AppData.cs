namespace TalkUareU
{
	public delegate void OnChangeHandler();

	// Keeps application-wide data shared among forms and provides notifications about changes
	//
	// Everywhere in this application a "document-view" model is used, and this class provides
	// a "document" part, whereas forms implement a "view" parts.
	// Each form interested in this data keeps a reference to it and synchronizes it with own 
	// controls using the OnChange() event and the Update() notificator method.
	//
	public class AppData
	{
		internal Properties.Settings p { get; set; }



		// LOCATION VARIABLES
		public string LocationId = "";
		public string LocationSap = "";
		public string LocationName = "";


		// shared data
		public int EnrolledFingersMask = 0;
		public int MaxEnrollFingerCount = 1;
		public bool IsEventHandlerSucceeds = true;
		public bool IsFeatureSetMatched = false;
		public int FalseAcceptRate = 0;
		public DPFP.Template Template = new DPFP.Template();

		// data change notification
		public void Update() { OnChange(); }        // just fires the OnChange() event
		public event OnChangeHandler OnChange;
	}
}
