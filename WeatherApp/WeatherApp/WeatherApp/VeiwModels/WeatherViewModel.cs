using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using WeatherApp.Core.Models;
using WeatherApp.Core.Repositories;
using WeatherApp.Data.Repositories;
using Xamarin.Forms;

namespace WeatherApp.VeiwModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IWeatherRepository repository;

        public WeatherViewModel()
        {
            repository = new OpenWeatherApiRepository();
            GetWeatherCommand = new Command<string>(GetWeather);
        }

        public string Title { get; set; } = String.Empty;
        public string Temperature { get; set; } = String.Empty;
        public string Wind { get; set; } = String.Empty;
        public string Humidity { get; set; } = String.Empty;
        public string Visibility { get; set; } = String.Empty;
        public string Sunrise { get; set; } = String.Empty;
        public string Sunset { get; set; } = String.Empty;

        public ICommand GetWeatherCommand { get; private set; }

        private async void GetWeather(string searchEntry)
        {
            if (string.IsNullOrEmpty(searchEntry))
            {
                return;
            }

            var isAutocompleteKeyword = searchEntry.Contains('(');
            if (isAutocompleteKeyword)
            {
                var pattern = @"[A-Za-z \-]+(?=[(])";
                searchEntry = Regex.Match((string)searchEntry, pattern).Value;
            }

            var weather = await repository.ReadByCityNameAsync((string)searchEntry);
            if (weather == null)
            {
                //this.CityNotFoundAlert(keyword);
            }
            else
            {
                SetWeatherProperties(weather);
            }

            //this.searchEntry.Text = string.Empty;
            //this.searchEntry.Placeholder = "Enter city";
        }
        private void SetWeatherProperties(Weather weather)
        {
            this.Title = weather.Title;
            OnPropertyChanged(nameof(Title));

            this.Temperature = weather.Temperature;
            OnPropertyChanged(nameof(Temperature));

            this.Wind = weather.Wind;
            OnPropertyChanged(nameof(Wind));

            this.Humidity = weather.Humidity;
            OnPropertyChanged(nameof(Humidity));

            this.Visibility = weather.Visibility;
            OnPropertyChanged(nameof(Visibility));

            this.Sunrise = weather.Sunrise;
            OnPropertyChanged(nameof(Sunrise));

            this.Sunset = weather.Sunset;
            OnPropertyChanged(nameof(Sunset));
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
