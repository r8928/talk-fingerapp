﻿using System;
using System.Collections.Generic;
using System.Text;

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
		private Properties.Settings _p = null;
		internal Properties.Settings p
		{
			get => _p;
			set
			{
				MaxEnrollFingerCount = value.MaxFingers;
				Templates = new DPFP.Template[value.MaxFingers];
				_p = value;
			}
		}


		// LOCATION VARIABLES
		public string LocationId;
		public string LocationName;
		public string LocationSap;


		// shared data
		public int EnrolledFingersMask = 0;
		public int MaxEnrollFingerCount;
		public bool IsEventHandlerSucceeds = true;
		public bool IsFeatureSetMatched = false;
		public int FalseAcceptRate = 0;
		//public DPFP.Template[] Templates = new DPFP.Template[MaxFingers];
		public DPFP.Template[] Templates;

		// data change notification
		public void Update() { OnChange(); }        // just fires the OnChange() event
		public event OnChangeHandler OnChange;
	}
}
