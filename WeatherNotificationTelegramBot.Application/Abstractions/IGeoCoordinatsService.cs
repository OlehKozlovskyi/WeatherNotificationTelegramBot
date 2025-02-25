using Geocoding;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IGeoCoordinatsService
    {
        Task<Location> GetCoordinatesAsync(string cityName);
    }
}