using WeatherApp.VeiwModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.VIews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        //private IWeatherRepository repository;

        public WeatherPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<WeatherViewModel>(this, WeatherViewModel.CityNotFoundMessageKey, async (sender) =>
            {
                await DisplayAlert("City was not found.", "We were unable to find input city in our data. Please check is the input a correct.", "OK");
            });
        }
    }
}