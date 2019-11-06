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

namespace RecycleViewApp
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Caption { get; set; }
    }
}