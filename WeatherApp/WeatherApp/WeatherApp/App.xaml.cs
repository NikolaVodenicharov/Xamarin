using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using WeatherApp.VIews;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class App : Application
    {
        public static IList<string> cities = new List<string>(169000);

        public App()
        {
            InitializeComponent();

            var before = GC.GetTotalMemory(false);
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            PopulateCities();

            stopwatch.Stop();
            var after = GC.GetTotalMemory(false);

            var difference = after - before;
            var time = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Time in milliseconds is: {time}.");
            Console.WriteLine(difference);

            

            MainPage = new NavigationPage(new WeatherPage());
        }

        private static void PopulateCities()
        {
            if (cities.Count > 0)
            {
                return;
            }

            var assemby = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            var stream = assemby.GetManifestResourceStream("WeatherApp.Data.Files.OrderedOpenWeatherCities.txt");

            using (var reader = new System.IO.StreamReader(stream))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    cities.Add(line);
                }
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
