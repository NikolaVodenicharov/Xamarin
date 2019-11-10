using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmetApp
{
    public class TitlesFragment : ListFragment
    {
        public const string TitleDialogIdKey = "TitleDialogIdKey ";
        private int titleDialogId;

        public TitlesFragment()
        {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            base.ListAdapter = new ArrayAdapter<string>(base.Activity, Android.Resource.Layout.SimpleListItemActivated1, Data.Titles);

            if (savedInstanceState != null)
            {
                this.titleDialogId = savedInstanceState.GetInt(TitleDialogIdKey, 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(TitleDialogIdKey, titleDialogId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            this.ShowDialog(position);
        }

        private void ShowDialog(int position)
        {
            var intent = new Intent(base.Activity, typeof(DialogActivity));
            intent.PutExtra(TitleDialogIdKey, position);
            base.StartActivity(intent);
        }
    }
}