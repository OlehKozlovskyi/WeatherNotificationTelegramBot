using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.Entities;

namespace WeatherNotificationTelegramBot.Application.Helpers
{
    public class WeatherJsonParser : IWeatherParser
    {
        private readonly JsonSerializerOptions _options;

        public WeatherJsonParser(IOptions<JsonSerializerOptions> serializerOptions) 
        {
            _options = serializerOptions.Value;
        }
        public WeatherResponse Parse(string jsonData)
        {
            return JsonSerializer.Deserialize<WeatherResponse>(jsonData, _options);
        }
    }
}
