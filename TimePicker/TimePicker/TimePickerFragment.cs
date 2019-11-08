using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Format;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TimePicker
{
    public class TimePickerFragment : DialogFragment, TimePickerDialog.IOnTimeSetListener
    {
        public static readonly string Tag = "MyTimePickerFragment";
        Action<DateTime> timeSelectedHandler = delegate { };

        public static TimePickerFragment CreateInstance(Action<DateTime> onTimeSelected)
        {
            var fragment = new TimePickerFragment();
            fragment.timeSelectedHandler = onTimeSelected;

            return fragment;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var currentTime = DateTime.Now;
            var is24Format = DateFormat.Is24HourFormat(base.Activity);
            var dialog = new TimePickerDialog(base.Activity, this, currentTime.Day, currentTime.Minute, is24Format);

            return dialog;
        }

        public void OnTimeSet(Android.Widget.TimePicker view, int hourOfDay, int minute)
        {
            var currentTime = DateTime.Now;
            var selectedTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hourOfDay, minute, 0);
            Log.Debug(Tag, selectedTime.ToLongTimeString());
            this.timeSelectedHandler(selectedTime);
        }
    }
}