using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NotificationApp
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            var count = Intent.Extras.GetInt(MainActivity.CountKey);
            if (count <= 0)
            {
                return;
            }

            SetContentView(Resource.Layout.activity_second);
            var notificationTextView = (TextView)FindViewById(Resource.Id.notificationTextView);
            notificationTextView.Text = $"You clicked the button {count} times in the previous activity.";
        }
    }
}