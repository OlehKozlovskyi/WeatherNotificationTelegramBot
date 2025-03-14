﻿using WeatherNotificationTelegramBot.Application.DTOs;
using WeatherNotificationTelegramBot.BusinessLogic.Entities;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherUserRepository
    {
        Task AddRecord(User user, WeatherRequest weatherRequest);
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetUsersAsync();
    }
}