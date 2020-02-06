using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public interface IWeatherRepository
    {
        Task<Weather> ReadByIdAsync(string id);
        Task<Weather> ReadByCityNameAsync(string name);
        Task<Weather> ReadByLocationAsync(double latitude, double longitude);
    }
}
