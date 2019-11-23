using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace DisplayPopUpApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string Alert = "Alert";
        private const string Cancel = "Cancel";
        private const string Ok = "Ok";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSimpleAlertClicked(object sender, EventArgs args)
        {
            await DisplayAlert(Alert, "You have been alerted", Ok);
        }

        private async void OnYesOrNoAlertClicked(object sender, EventArgs args)
        {
            var answer = await DisplayAlert("Question", "Do you like Xamarin pop ups ?", "Yes", "No");

            Debug.WriteLine($"The answer is: {answer}");
        }

        private async void OnSimpleActionSheetClicked(object sender, EventArgs args)
        {
            await DisplayActionSheet("What to do ?", Cancel, null, "Job 1", "Job 2", "Job 3");
        }

        private async void OnActionSheetClicked(object sender, EventArgs args)
        {
            await DisplayActionSheet("What to do ?", Cancel, "Delete", "Job 1", "Job 2", "Job 3");
        }
    }
}
