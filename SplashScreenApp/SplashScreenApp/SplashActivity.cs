
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using System;
using System.Threading.Tasks;

namespace SplashScreenApp
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        private static readonly string Tag = "X" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistableBundle)
        {
            base.OnCreate(savedInstanceState, persistableBundle);
            Log.Debug(Tag, "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startWork = new Task(() => { SimulateStartup(); });
            startWork.Start();
        }

        private async void SimulateStartup()
        {
            Log.Debug(Tag, "Performing some startup work that takes a bit of time.");

            await Task.Delay(8000);

            Log.Debug(Tag, "Startup work is finished - starting MainActivity.");

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}