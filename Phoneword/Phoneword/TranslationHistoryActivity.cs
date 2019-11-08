
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "@string/translation_history")]
    public class TranslationHistoryActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var phoneNumbers = Intent.Extras.GetStringArrayList(MainActivity.PhoneNumberKey) ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);

        }
    }
}