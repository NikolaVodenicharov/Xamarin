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

namespace ViewPagerUsingFragments
{
    public class FlashCardFragment : Android.Support.V4.App.Fragment
    {
        private const string FlashCardQuestion = "card_question";
        private const string FlashCardAnswer = "card_answer";
        private const string Empty = "";

        public static FlashCardFragment CreateInstance (string question, string answer)
        {
            var bundle = new Bundle();
            bundle.PutString(FlashCardQuestion, question);
            bundle.PutString(FlashCardAnswer, answer);

            var fragment = new FlashCardFragment();
            fragment.Arguments = bundle;

            return fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var question = base.Arguments.GetString(FlashCardQuestion, Empty);
            var answer = base.Arguments.GetString(FlashCardAnswer, Empty);

            var view = inflater.Inflate(Resource.Layout.flashcard_layout, container, false);

            var questionBox = view.FindViewById<TextView>(Resource.Id.flash_card_question);
            questionBox.Text = question;

            questionBox.Click += delegate
            {
                Toast
                .MakeText(
                    Activity.ApplicationContext, 
                    "Answer: " + answer, 
                    ToastLength.Short)
                .Show();
            };

            return view;
        }
    }
}