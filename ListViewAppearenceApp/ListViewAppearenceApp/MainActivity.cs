using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace ListViewAppearenceApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        private string[] items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            this.items = Resources.GetStringArray(Resource.Array.items);
            base.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemChecked, items);

            var listView = FindViewById<ListView>(Android.Resource.Id.List);
            listView.ChoiceMode = Android.Widget.ChoiceMode.Multiple;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = items[position];
            Toast.MakeText(this, t, ToastLength.Short).Show();
        }
    }
}