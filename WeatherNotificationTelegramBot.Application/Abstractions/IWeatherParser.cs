using WeatherNotificationTelegramBot.Application.Entities;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherParser
    {
        WeatherResponse Parse(string jsonData);
    }
}