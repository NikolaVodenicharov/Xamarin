using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WeatherApp.Core.Models;
using WeatherApp.Core.Repositories;
using WeatherApp.Data.Repositories;
using Xamarin.Forms;
using Xamarin.Essentials;
using System;

namespace WeatherApp.VeiwModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public const string CityNotFoundMessageKey = "City was not found.";
        private static readonly char[] Digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };

        public event PropertyChangedEventHandler PropertyChanged;

        private IWeatherRepository repository;

        public WeatherViewModel()
        {
            repository = new OpenWeatherApiRepository();
            GetWeatherCommand = new Command(GetWeather);

            GetWeatherByCurrentLocationAsync();
        }

        public string Title { get; set; } = string.Empty;
        public string Temperature { get; set; } = string.Empty;
        public string Wind { get; set; } = string.Empty;
        public string Humidity { get; set; } = string.Empty;
        public string Visibility { get; set; } = string.Empty;
        public string Sunrise { get; set; } = string.Empty;
        public string Sunset { get; set; } = string.Empty;

        public ICommand GetWeatherCommand { get; private set; }

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

            Weather weather = null;
            if (isEntryCitySuggestion)
            {
                isEntryCitySuggestion = false;

                var cityId = CitySuggestions[searchEntry];

                weather = await repository.ReadByIdAsync(cityId);
            }
            else
            {
                weather = await repository.ReadByCityNameAsync((string)searchEntry);
            }

            if (weather == null)
            {
                MessagingCenter.Send(this, CityNotFoundMessageKey);
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

            IsWeatherInfoVisible = true;
        }
        private bool isWeatherInfoVisible = false;
        public bool IsWeatherInfoVisible
        {
            get => isWeatherInfoVisible;
            set
            {
                isWeatherInfoVisible = value;
                OnPropertyChanged(nameof(IsWeatherInfoVisible));
            }
        }


        private string searchEntryText = string.Empty;
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
        private bool isEntryCitySuggestion = false;
        private void ClearSearchEntryText()
        {
            SearchEntryText = string.Empty;
        }


        private IDictionary<string, string> citySuggestions = new Dictionary<string, string>();
        public IDictionary<string, string> CitySuggestions 
        {
            get => citySuggestions;
            set
            {
                if (citySuggestions != value)
                {
                    citySuggestions = value;
                    OnPropertyChanged(nameof(CitySuggestions));
                    OnPropertyChanged(nameof(CitySuggestionsList));
                }
            }
        }
        public IList<string> CitySuggestionsList
        {
            get => citySuggestions.Keys.ToList();
        }
        /// <summary>
        /// Fill dictionery of sity suggestions.
        /// The key is city name and country code.
        /// The value is city id in "Open weather" site.
        /// </summary>
        private void FillCitySuggestions(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return;
            }

            isEntryCitySuggestion = false;

            keyword = keyword.ToLower();

            var suggestions = App
                .cities
                .Where(c => c.ToLower().StartsWith(keyword))
                .Take(5)
                .ToList();

            // values of data dictionery are never used
            var data = new Dictionary<string, string>(5);

            foreach (var suggestion in suggestions)
            {
                var idStartIndex = suggestion.IndexOfAny(Digits);

                var cityWithCountry = suggestion.Substring(0, idStartIndex - 1);
                var cityId = suggestion.Substring(idStartIndex);

                data.Add(cityWithCountry, cityId);
            }

            //CitySuggestions = data.Keys.ToList();

            CitySuggestions = data;

            IsSuggestionsVisible = true;
        }


        private bool isSuggestionsVisible = false;
        public bool IsSuggestionsVisible
        {
            get => isSuggestionsVisible;
            set
            {
                isSuggestionsVisible = value;
                OnPropertyChanged(nameof(IsSuggestionsVisible));
            }
        }


        private string citySuggestionsSelectedItem;
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
        private void OnCitySuggestionsSelectedItem()
        {
            SearchEntryText = citySuggestionsSelectedItem;
            IsSuggestionsVisible = false;
            isEntryCitySuggestion = true;
        }

        // initial city weather by current location
        private async void GetWeatherByCurrentLocationAsync()
        {
            try
            {
                var latitude = 42.06;
                var longitude = 24.765;
                var weather = await repository.ReadByLocationAsync(latitude, longitude);
                SetWeatherProperties(weather);

                //var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                //var location = await Geolocation.GetLocationAsync(request); 

                //if (location != null)
                //{
                //    var weather = await repository.ReadByLocationAsync(location.Latitude, location.Longitude);
                //    SetWeatherProperties(weather);
                //}
            }
            catch (Exception e)
            {

            }
        }
    }
}
