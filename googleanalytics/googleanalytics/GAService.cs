using System;
using Android.Gms.Analytics;
using Android.Content;

namespace googleanalytics
{
	public class GAService
	{
		public string TrackingId = ""; // Place your ID here
		private static GoogleAnalytics GAInstance;
		private static Tracker GATracker;
		private static GAService thisRef;

		public GAService ()
		{}

		public static GAService GetGASInstance()
		{
			if (thisRef == null)
				// it's ok, we can call this constructor
				thisRef = new GAService();
			return thisRef;
		}

		public void Initialize(Context AppContext)
		{
			GAInstance = GoogleAnalytics.GetInstance(AppContext.ApplicationContext);
			GAInstance.SetLocalDispatchPeriod(10);

			GATracker = GAInstance.NewTracker(TrackingId);
			GATracker.EnableExceptionReporting(true);
			GATracker.EnableAdvertisingIdCollection(true);
			GATracker.EnableAutoActivityTracking(true);
		}

		public void Track_App_Page(String PageNameToTrack)
		{
			GATracker.SetScreenName(PageNameToTrack);
			GATracker.Send(new HitBuilders.ScreenViewBuilder().Build());
		}

		public void Track_App_Event(String GAEventCategory, String EventToTrack)
		{
			HitBuilders.EventBuilder builder = new HitBuilders.EventBuilder();
			builder.SetCategory(GAEventCategory);
			builder.SetAction(EventToTrack);
			builder.SetLabel("AppEvent");

			GATracker.Send(builder.Build());
		}

		public void Track_App_Exception(String ExceptionMessageToTrack, Boolean isFatalException)
		{
			HitBuilders.ExceptionBuilder builder = new HitBuilders.ExceptionBuilder();
			builder.SetDescription(ExceptionMessageToTrack);
			builder.SetFatal(isFatalException);

			GATracker.Send(builder.Build());
		}

		public struct GAEventCategory
		{
			public static String Category1 { get { return "Category1"; } set { } }
			public static String Category2 { get { return "Category2"; } set { } }
			public static String Category3 { get { return "Category3"; } set { } }
		};
	}
}

