using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Analytics;

namespace googleanalytics
{
	[Activity (Label = "googleanalytics", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Context con = ApplicationContext;

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			GAService.GetGASInstance().Initialize(con);

			GAService.GetGASInstance().Track_App_Page("Main Activity");

			GAService.GetGASInstance().Track_App_Event(GAService.GAEventCategory.Category1, "hey ! Category 1 type event ocurred !");   

			// Place try and catch and in your catch you need to place below line to track that error
			//GAService.GetGASInstance().Track_App_Exception(ex.Message, false);
		}


	}
}


