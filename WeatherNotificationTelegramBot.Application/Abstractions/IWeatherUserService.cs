using WeatherNotificationTelegramBot.Application.DTOs;

namespace WeatherNotificationTelegramBot.Application.Abstractions
{
    public interface IWeatherUserService
    {
        Task AddWeatherUserEntryAsync(UserWeatherRecordDto recordDto);
    }
}