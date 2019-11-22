using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DaysBetweenDatesApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnDateSelected(object sender, EventArgs args)
        {
            this.Recalculate();
        }

        public void OnSwitchToggled(object sender, EventArgs args)
        {
            this.Recalculate();
        }

        private void Recalculate()
        {
            var timeSpan = endDatePicker.Date - startDatePicker.Date;

            if (includeSwitch.IsToggled)
            {
                timeSpan += TimeSpan.FromDays(1);
            }

            var dayWord = "day";
            if (timeSpan.Days > 1)
            {
                dayWord += "s";
            }

            resultLabel.Text = String.Format($"{timeSpan.Days} {dayWord} between dates.");
        }
    }
}
