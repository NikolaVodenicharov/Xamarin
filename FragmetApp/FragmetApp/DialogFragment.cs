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
    public class DialogFragment : Fragment
    {

        public int GetDalogId => base.Arguments.GetInt(TitlesFragment.TitleDialogIdKey, 0);

        public static DialogFragment CreateInstance(int id)
        {
            var bundle = new Bundle();
            bundle.PutInt(TitlesFragment.TitleDialogIdKey, id);

            var fragment = new DialogFragment
            {
                Arguments = bundle
            };

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            var textView = new TextView(base.Activity);
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
            textView.Text = Data.Dialogue[this.GetDalogId];

            var scrollView = new ScrollView(base.Activity);
            scrollView.AddView(textView);

            return scrollView;
        }
    }
}