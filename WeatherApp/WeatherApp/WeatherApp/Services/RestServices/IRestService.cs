using System.Threading.Tasks;

namespace WeatherApp.Services.RestServices
{
    public interface IRestService
    {
        Task<dynamic> GetAsync(string queryString);
    }
}