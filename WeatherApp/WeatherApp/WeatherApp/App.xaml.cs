using System;
using System.Collections.Generic;
using System.Reflection;
using WeatherApp.VIews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public static IList<string> cities = new List<string>(18000);

        public App()
        {
            InitializeComponent();
            PopulateCities();

            MainPage = new NavigationPage(new WeatherPage());
        }

        private static void PopulateCities()
        {
            if (cities.Count > 0)
            {
                return;
            }

            var assemby = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            var stream = assemby.GetManifestResourceStream("WeatherApp.Data.Files.Cities.txt");

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
