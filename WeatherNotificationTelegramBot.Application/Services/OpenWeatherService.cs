using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class OpenWeatherService(IGeoCoordinatsService geoService) : IOpenWeatherService
    {
        private string _requestUrl = "https://api.openweathermap.org/data/3.0/onecall/overview?lat={lat}&lon={lon}&appid={token}";

        public async Task GetWeatherAsync(string location)
        {
            using HttpClient client = new HttpClient();
            var coordinats = await geoService.GetCoordinatesAsync(location);
            var response = await client.GetStringAsync(_requestUrl);
        }
    }
}
