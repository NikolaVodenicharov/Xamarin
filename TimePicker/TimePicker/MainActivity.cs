using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace TimePicker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button pickTimeButton;
        private TextView displayTimeText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            this.displayTimeText = FindViewById<TextView>(Resource.Id.display_time_text);
            this.pickTimeButton = FindViewById<Button>(Resource.Id.pick_time_button);

            this.pickTimeButton.Click += this.TimeSelectedOnClick;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void TimeSelectedOnClick(object sender, EventArgs eventArgs)
        {
            var timePickerFragment = TimePickerFragment.CreateInstance(
                delegate (DateTime time)
                {
                    this.displayTimeText.Text = time.ToShortTimeString();
                });

            timePickerFragment.Show(base.FragmentManager, TimePickerFragment.Tag);
        }
    }
}