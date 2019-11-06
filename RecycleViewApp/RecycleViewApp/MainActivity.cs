using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;

namespace RecycleViewApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        RecyclerView.LayoutManager layoutManager;
        PhotoAlbumAdapter adapter;
        PhotoAlbum photoAlbum;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            this.photoAlbum = new PhotoAlbum();
            this.adapter = new PhotoAlbumAdapter(this.photoAlbum);
            this.adapter.ItemClick += this.OnItemClick;

            this.layoutManager = new LinearLayoutManager(this);
            this.recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            this.recyclerView.SetLayoutManager(this.layoutManager);
            this.recyclerView.SetAdapter(this.adapter);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void OnItemClick(object sender, int position)
        {
            int photoNumber = position + 1;
            Toast.MakeText(this, $"Photo number is {photoNumber}.", ToastLength.Short).Show();
        }
    }
}