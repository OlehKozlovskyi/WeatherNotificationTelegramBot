using WeatherNotificationTelegramBot.Application.Entities;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherParser
    {
        WeatherData Parse(string jsonData);
    }
}