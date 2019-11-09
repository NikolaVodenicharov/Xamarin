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
    public class FlashCard
    {
        public string problem;

        public string answer;

        public string Problem { get { return problem; } }

        public string Answer { get { return answer; } }
    }
}