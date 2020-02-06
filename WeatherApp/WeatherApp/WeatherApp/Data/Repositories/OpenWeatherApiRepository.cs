using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Repositories;
using WeatherApp.Services.RestServices;

namespace WeatherApp.Data.Repositories
{
    public class OpenWeatherApiRepository : IWeatherRepository
    {
        private const string BasePath = "http://api.openweathermap.org/data/2.5/weather?";
        private const string ByCityName = "q=";
        private const string ById = "id=";
        private const string ApiKey = "&APPID=a19463a4a4aa7bf6878d97455fa05d1a";
        private const string MetricUnit = "&units=metric";

        private const string UtcKeyword = "UTC";
        private const string CelsiusSymbol = "\u2103";

        private IRestService restService;


        // api.openweathermap.org/data/2.5/weather?id=2172797

        public OpenWeatherApiRepository()
        {
            this.restService = new RestService();
        }
        public OpenWeatherApiRepository(IRestService restService)
        {
            this.restService = restService;
        }

        public async Task<Weather> ReadByCityNameAsync(string name)
        {
            var queryString = BasePath + ByCityName + name + ApiKey + MetricUnit;
            //dynamic data = await restService.GetAsync(queryString).ConfigureAwait(false);

            //var isNull = data["weather"] == null;
            //if (isNull)
            //{
            //    return null;
            //}

            //var weather = ExtractWeather(data);
            //return weather;

            return await ExtractWeather(queryString);
        }

        public async Task<Weather> ReadByIdAsync(string id)
        {
            var queryString = BasePath + ById + id + ApiKey + MetricUnit;

            return await ExtractWeather(queryString);
        }

        public Task<Weather> ReadByLocationAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        private async Task<Weather> ExtractWeather(string queryString)
        {
            dynamic data = await restService.GetAsync(queryString).ConfigureAwait(false);

            var isNull = data["weather"] == null;
            if (isNull)
            {
                return null;
            }

            var weather = new Weather();

            var sunriseSecondsFromBeginning = (long)data["sys"]["sunrise"];
            var sunsetSecondsFromBeginning = (long)data["sys"]["sunset"];
            var timeZoneCorrector = (long)data["timezone"];

            var sunrise = UnixTimeConverter(sunriseSecondsFromBeginning + timeZoneCorrector);
            var sunset = UnixTimeConverter(sunsetSecondsFromBeginning + timeZoneCorrector);

            weather.Sunrise = $"{sunrise} {UtcKeyword}";
            weather.Sunset = $"{sunset} {UtcKeyword}";
            weather.Title = (string)data["name"];
            weather.Temperature = (string)data["main"]["temp"] + " " + CelsiusSymbol;
            weather.Wind = (string)data["wind"]["speed"] + " km/h";
            weather.Humidity = (string)data["main"]["humidity"] + " %";
            weather.Visibility = (string)data["weather"][0]["main"];

            return weather;
        }
        private DateTime UnixTimeConverter(long seconds)
        {
            var unixTimeBeginning = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return unixTimeBeginning.AddSeconds(seconds);
        }
    }
}
