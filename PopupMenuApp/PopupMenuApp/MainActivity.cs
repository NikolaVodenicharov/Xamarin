using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace PopupMenuApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);


            var showPopupButton = base.FindViewById<Button>(Resource.Id.show_popup_button);
            showPopupButton.Click += (s, args) =>
            {
                var menu = new PopupMenu(this, showPopupButton);
                menu.Inflate(Resource.Menu.popup_menu);

                menu.MenuItemClick += (s1, args1) =>
                {
                    System.Console.WriteLine($"{args1.Item.TitleFormatted} selected");
                };

                menu.DismissEvent += (s2, args2) =>
                {
                    System.Console.WriteLine("Menu dismissed.");
                };

                menu.Show();
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}