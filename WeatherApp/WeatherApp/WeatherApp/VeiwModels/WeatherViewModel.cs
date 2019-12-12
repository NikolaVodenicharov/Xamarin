using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        private string searchEntryText = string.Empty;

        private IList<string> citySuggestions;
        private bool isSuggestionsVisible = false;
        private string citySuggestionsSelectedItem;
        private bool isEntryCitySuggestion = false;

        public WeatherViewModel()
        {
            repository = new OpenWeatherApiRepository();
            GetWeatherCommand = new Command(GetWeather);
        }

        public string Title { get; set; } = string.Empty;
        public string Temperature { get; set; } = string.Empty;
        public string Wind { get; set; } = string.Empty;
        public string Humidity { get; set; } = string.Empty;
        public string Visibility { get; set; } = string.Empty;
        public string Sunrise { get; set; } = string.Empty;
        public string Sunset { get; set; } = string.Empty;

        public ICommand GetWeatherCommand { get; private set; }
        public string SearchEntryText
        {
            get => searchEntryText;
            set
            {
                searchEntryText = value;

                OnPropertyChanged(nameof(SearchEntryText));

                //extract in method?
                if (isEntryCitySuggestion)
                {
                    isEntryCitySuggestion = false;
                }
                else
                {
                    FillCitySuggestions(searchEntryText);
                }
            }
        }
        public IList<string> CitySuggestions 
        { 
            get => citySuggestions; 
            set
            {
                if (citySuggestions != value)
                {
                    citySuggestions = value;
                    OnPropertyChanged(nameof(CitySuggestions));
                }
            }
        }
        public string CitySuggestionsSelectedItem
        { 
            get => citySuggestionsSelectedItem; 
            set
            {
                citySuggestionsSelectedItem = value;

                if (citySuggestionsSelectedItem != null)
                {
                    OnCitySuggestionsSelectedItem();
                }
            }
        }
        public bool IsSuggestionsVisible 
        { 
            get => isSuggestionsVisible;
            set
            {
                isSuggestionsVisible = value;
                OnPropertyChanged(nameof(IsSuggestionsVisible));
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void GetWeather()
        {
            var searchEntry = SearchEntryText;

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
                ClearSearchEntryText();
            }
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
        private void ClearSearchEntryText()
        {
            SearchEntryText = string.Empty;
        }

        private void FillCitySuggestions(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return;
            }

            keyword = keyword.ToLower();

            var suggestions = App
                .cities.Where(c => c.ToLower().StartsWith(keyword))
                .Take(5)
                .ToList();

            CitySuggestions = suggestions;

            IsSuggestionsVisible = true;
        }

        private void OnCitySuggestionsSelectedItem()
        {
            SearchEntryText = citySuggestionsSelectedItem;
            IsSuggestionsVisible = false;

            // set suggestionCollection to null ?
        }

        //private async void CityNotFoundAlert(string cityName)
        //{
        //    await DisplayAlert(
        //        $"{cityName} was not found",
        //        "The city that you are searching is not found. Make sure that you type is correct.",
        //        "OK");
        //}
    }
}
