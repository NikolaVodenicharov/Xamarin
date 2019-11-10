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

namespace FragmetApp
{
    [Activity(Label = "DialogActivity")]
    public class DialogActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var dialogId = base.Intent.Extras.GetInt(TitlesFragment.TitleDialogIdKey, 0);

            var dialogFragment = DialogFragment.CreateInstance(dialogId);

            base.FragmentManager
                .BeginTransaction()
                .Add(Android.Resource.Id.Content, dialogFragment)
                .Commit();
        }
    }
}