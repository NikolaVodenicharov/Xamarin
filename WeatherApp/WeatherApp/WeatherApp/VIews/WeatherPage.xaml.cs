using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.VIews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
        }

        private async void OnGetWeatherButtonClicked(object sender, EventArgs args)
        {
            if (String.IsNullOrEmpty(cityName.Text))
            {
                return;
            }

            var weather = await Core.GetWeatherByCityName(cityName.Text);
            this.BindingContext = weather;
            this.getWeatherButton.Text = "Search again";
        }
    }
}