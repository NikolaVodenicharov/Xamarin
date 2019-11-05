using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using System;
using Android.Content;

namespace NotificationApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private static readonly string ChannelId = "location_notification";
        private static readonly int NotificationId = 1000;
        private static int Count = 0;

        public static readonly string CountKey = "count";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            this.CreateNotificationChannel();

            var notificationButton = (Button)FindViewById(Resource.Id.notificationButton);
            notificationButton.Click += this.ButtonOnCLick;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateNotificationChannel()
        {
            if(Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var name = Resources.GetString(Resource.String.channel_name);
            var description = Resources.GetString(Resource.String.channel_description);
            var channel = new NotificationChannel(ChannelId, name, NotificationImportance.Default)
            {
                Description = description
            };


            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private void ButtonOnCLick(object sender, EventArgs eventArgs)
        {
            var valuesForActivity = new Bundle();
            valuesForActivity.PutInt(CountKey, Count);

            var intent = new Intent(this, typeof(SecondActivity));
            intent.PutExtras(valuesForActivity);

            var stackBuilder = TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SecondActivity)));
            stackBuilder.AddNextIntent(intent);

            var pendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            var builder = new NotificationCompat.Builder(this, ChannelId)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Button clicked")
                .SetNumber(Count)
                .SetSmallIcon(Resource.Drawable.ic_stat_button_click)
                .SetContentText($"The button has been clicked {Count} times.");

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(NotificationId, builder.Build());

            Count++;
        }
    }
}