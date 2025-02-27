using WeatherNotificationTelegramBot.Application.Entities;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IOpenWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string location);
    }
}