using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FanDuel.Droid
{
    #region MainActivity
    [Activity (Label = "FanDuel", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity // global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            this.Window.AddFlags(WindowManagerFlags.TranslucentStatus);

            global::Xamarin.Forms.Forms.Init (this, bundle);
			this.LoadApplication (new FanDuel.App ());
		}
	}
    #endregion
}

