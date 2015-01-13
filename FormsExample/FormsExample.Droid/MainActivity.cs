using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsExample.Droid
{
    [Activity( Label = "FormsExample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate( Bundle bundle )
        {
            base.OnCreate( bundle );

            Forms.Init( this, bundle );
            LoadApplication( new App() );
        }
    }
}

