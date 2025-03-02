
using WeatherNotificationTelegramBot.Application.DTOs;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherUserRepository
    {
        Task AddRecord(UserWeatherRecordDto recordDto);
    }
}