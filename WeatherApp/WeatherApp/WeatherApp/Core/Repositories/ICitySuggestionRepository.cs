using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Core.Repositories
{
    public interface ICitySuggestionRepository
    {
        ICollection<string> ReadByKeyword(string keyword = null);
    }
}
