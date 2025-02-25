using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private const string ApiKey = "03340f679846ce4e71dc3996b298ae8a";
        private const string BaseUrl = """https://api.openweathermap.org/data/2.5/weather""";
        private string _requestUrl = @"?q={city name}&appid={API key}";

        public async Task GetWeatherAsync(string location)
        {
            using HttpClient client = new HttpClient();
            string url = $"{BaseUrl}?q={location}&appid={ApiKey}&units=metric";
            // var coordinats = await geoService.GetCoordinatesAsync(location);
            var response = await client.GetStringAsync(_requestUrl);
            Console.WriteLine();
        }
    }
}
