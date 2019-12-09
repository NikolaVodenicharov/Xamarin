using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services.FileServices
{
    public interface ITextFileService
    {
        List<string> ReadAllLines(string resourceName, Type assemblyAnchor = null);
    }
}
