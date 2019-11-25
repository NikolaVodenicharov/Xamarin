using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class Weather
    {
        public Weather()
        {

        }

        public string Title { get; set; } = String.Empty;
        public string Temperature { get; set; } = String.Empty;
        public string Wind { get; set; } = String.Empty;
        public string Humidity { get; set; } = String.Empty;
        public string Visibility { get; set; } = String.Empty;
        public string Sunrise { get; set; } = String.Empty;
        public string Sunset { get; set; } = String.Empty;
    }
}
