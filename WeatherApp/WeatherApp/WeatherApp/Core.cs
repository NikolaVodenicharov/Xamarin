using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp
{
    public class Core
    {
        private const string BasePath = "http://api.openweathermap.org/data/2.5/weather?";
        private const string ByCityName = "q=";
        private const string ApiKey = "&APPID=a19463a4a4aa7bf6878d97455fa05d1a";
        private const string MetricUnit = "&units=metric";
        private const string Utc = "UTC";

        public static async Task<Weather> GetWeatherByCityName(string cityName)
        {
            var queryString = BasePath + ByCityName + cityName + ApiKey + MetricUnit;

            dynamic result = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            var isNull = result["weather"] == null;
            if (isNull)
            {
                return null;
            }

            var weather = new Weather();
            weather.Title = (string)result["name"];
            weather.Temperature = (string)result["main"]["temp"] + " \u2103";
            weather.Wind = (string)result["wind"]["speed"] + " km/h";
            weather.Humidity = (string)result["main"]["humidity"] + " %";
            weather.Visibility = (string)result["weather"][0]["main"];

            var unixTimeBeginning = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var sunriseSecondsFromBeginning = (double)result["sys"]["sunrise"]; // (double) ?
            var sunsetSecondsFromBeginning = (double)result["sys"]["sunset"];

            weather.Sunrise = unixTimeBeginning.AddSeconds(sunriseSecondsFromBeginning) + " " + Utc;
            weather.Sunset = unixTimeBeginning.AddSeconds(sunsetSecondsFromBeginning) + " " + Utc;

            return weather;
        }

    }
}
