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
        private bool isShowingTwoFragments;

        public TitlesFragment()
        {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            // existing code
            base.OnActivityCreated(savedInstanceState);

            base.ListAdapter = new ArrayAdapter<string>(base.Activity, Android.Resource.Layout.SimpleListItemActivated1, Data.Titles);

            if (savedInstanceState != null)
            {
                this.titleDialogId = savedInstanceState.GetInt(TitleDialogIdKey, 0);
            }

            // Landscape/ 2 fragments
            var dialogContainer = base.Activity.FindViewById(Resource.Id.dialog_container);

            this.isShowingTwoFragments =
                dialogContainer != null &&
                dialogContainer.Visibility == Android.Views.ViewStates.Visible;

            if (this.isShowingTwoFragments)
            {
                base.ListView.ChoiceMode = Android.Widget.ChoiceMode.Single;
                this.ShowDialog(this.titleDialogId);
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

        private void ShowDialog(int id)
        {
            this.titleDialogId = id;

            if (this.isShowingTwoFragments)
            {
                base.ListView.SetItemChecked(this.titleDialogId, true);

                var dialogContainer =
                    base.FragmentManager
                    .FindFragmentById(Resource.Id.dialog_container)
                    as DialogFragment;

                var isContainerEmpty = dialogContainer == null;     // before first selected title
                var isDifferentDialogDisplayed = dialogContainer?.GetDalogId != this.titleDialogId; // if other dialog is currently displayed

                if (isContainerEmpty || isDifferentDialogDisplayed)
                {
                    var container = base.Activity.FindViewById(Resource.Id.dialog_container);
                    var dialogFragment = DialogFragment.CreateInstance(this.titleDialogId);

                    var fragmentTransaction = base.FragmentManager.BeginTransaction();
                    fragmentTransaction.Replace(Resource.Id.dialog_container, dialogFragment);
                    fragmentTransaction.AddToBackStack(null);
                    fragmentTransaction.SetTransition(Android.App.FragmentTransit.FragmentFade);
                    fragmentTransaction.Commit();
                }
            }
            else
            {
                var intent = new Intent(base.Activity, typeof(DialogActivity));
                intent.PutExtra(TitleDialogIdKey, id);
                base.StartActivity(intent);
            }
        }
    }
}