using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherNotificationTelegramBot.Application.Services
{
    using Geocoding;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using WeatherNotificationTelegramBot.Application.Abstractions;

    public class GeoCoordinatsService : IGeoCoordinatsService
    {
        private const string ApiKey = "03340f679846ce4e71dc3996b298ae8a";
        private const string BaseUrl = "https://api.openweathermap.org/geo/1.0/direct";

        public async Task<Location> GetCoordinatesAsync(string cityName)
        {
            using HttpClient _httpClient = new HttpClient();
            string url = $"{BaseUrl}?q={cityName}&limit=1&appid={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);

            var locations = JsonSerializer.Deserialize<Location[]>(response);
            if (locations != null && locations.Length > 0)
            {
                return new Location(locations[0].Latitude, locations[0].Longitude);
            }

            return new Location(0, 0);
        }
    }
}
