﻿using WeatherNotificationTelegramBot.Application.Entities;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IOpenWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string location);
    }
}