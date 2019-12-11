using System;
using System.Linq;
using System.Text.RegularExpressions;
using WeatherApp.Core.Repositories;
using WeatherApp.Data.Repositories;
using WeatherApp.Services.FileServices;
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

            //this.repository = new OpenWeatherApiRepository();

            //this.searchEntry.TextChanged += this.OnSearchEntryTextChanged;
            //this.suggestionsList.ItemTapped += this.OnSuggestionListItemtapped;
        }

        //private async void OnGetWeatherButtonClicked(object sender, EventArgs args)
        //{
        //    var keyword = searchEntry.Text;

        //    if (String.IsNullOrEmpty(keyword))
        //    {
        //        return;
        //    }

        //    var isAutocompleteKeyword = keyword.Contains('(');
        //    if (isAutocompleteKeyword)
        //    {
        //        var pattern = @"[A-Za-z \-]+(?=[(])";
        //        keyword = Regex.Match(keyword, pattern).Value;
        //    }


        //    var weather = await repository.ReadByCityNameAsync(keyword);
        //    if (weather == null)
        //    {
        //        this.CityNotFoundAlert(keyword);
        //    }
        //    else
        //    {
        //        this.BindingContext = weather;
        //    }

        //    this.searchEntry.Text = string.Empty;
        //    this.searchEntry.Placeholder = "Enter city";
        //}
        //private async void CityNotFoundAlert(string cityName)
        //{
        //    await DisplayAlert(
        //        $"{cityName} was not found", 
        //        "The city that you are searching is not found. Make sure that you type is correct.", 
        //        "OK");
        //}

        //private void OnSearchEntryTextChanged(object sender, EventArgs args)
        //{
        //    var keyword = this.searchEntry.Text.ToLower();
        //    if (String.IsNullOrEmpty(keyword))
        //    {
        //        return;
        //    }

        //    var suggestions = App
        //        .cities.Where(c => c.ToLower().StartsWith(keyword))
        //        .Take(5)
        //        .ToList();

        //    this.suggestionsList.ItemsSource = suggestions;
        //    this.suggestionsList.IsVisible = true;
        //}

        //private void OnSuggestionListItemtapped(object sender, ItemTappedEventArgs e)
        //{
        //    var city = (string)e.Item;
        //    this.searchEntry.Text = city;

        //    this.suggestionsList.IsVisible = false;
        //    this.suggestionsList.ItemsSource = null;
        //}
    }
}