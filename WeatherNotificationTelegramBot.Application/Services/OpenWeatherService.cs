﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherNotificationTelegramBot.Application.Abstractions;
using WeatherNotificationTelegramBot.Application.Entities;
using WeatherNotificationTelegramBot.Application.Settings;

namespace WeatherNotificationTelegramBot.Application.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private IWeatherParser _weatherParser;
        private OpenWeatherApiOptions _apiOptions;

        public OpenWeatherService(IWeatherParser weatherParser, IOptions<OpenWeatherApiOptions> options)
        {
            _weatherParser = weatherParser;
            _apiOptions = options.Value;
        }

        public async Task<WeatherData> GetWeatherAsync(string location)
        {
            using HttpClient client = new HttpClient();
            string url = $"{_apiOptions.BaseUrl}?q={location}&appid={_apiOptions.ApiKey}&units=metric";
            var response = await client.GetStringAsync(url);
            WeatherData weatherData = _weatherParser.Parse(response);
            return weatherData;
        }
    }
}
